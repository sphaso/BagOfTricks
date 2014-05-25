--
-- This is a translation from Scala of my solution
-- for the fourth week's assignment of "Functional Programming using Scala" in Coursera.
-- It's basically an implementation of the Huffman string compression algorithm
-- using both CodeTree and CodeTable
--

import Data.Function (on)
import Data.List (sortBy, isInfixOf)

data CodeTree = Fork (CodeTree, CodeTree, [Char], Int)
			  | Leaf (Char, Int)

leafToTuple :: CodeTree -> (Char, Int)
leafToTuple (Leaf(c, w)) = (c, w)

weight :: CodeTree -> Int
weight (Fork (l, r, _, _)) =  weight(l) + weight(r)
weight (Leaf (_, w)) = w

chars :: CodeTree -> [Char]
chars (Fork (l, r, _, _)) = chars(l) ++ chars(r)
chars (Leaf (c, _)) = [c]

makeCodeTree :: CodeTree -> CodeTree -> CodeTree
makeCodeTree a b = Fork (a, b, chars(a) ++ chars(b), weight(a) + weight(b))

times :: [Char] -> [CodeTree]
times ccs = case ccs of (x:xs) -> [Leaf (x, length (filter (==x) ccs))] ++ times(filter (/=x) xs)

makeOrderedLeafList :: [CodeTree] -> [CodeTree]
makeOrderedLeafList [] = []
makeOrderedLeafList leafs = map Leaf (sortBy (compare `on` snd) (map leafToTuple leafs))

makeOrderedCodeTree :: [CodeTree] -> [CodeTree]
makeOrderedCodeTree [] = []
makeOrderedCodeTree ct = sortBy (compare `on` weight) ct

singleton :: [CodeTree] -> Bool
singleton trees = case trees of
							[x] -> True
							_ -> False

combine :: [CodeTree] -> [CodeTree]
combine tree = case tree of (a:b:xs) 
				-> makeOrderedCodeTree ([Fork(a, b, chars(a) ++ chars(b), weight(a) + weight(b))] ++ xs)

makeRoot :: [CodeTree] -> CodeTree
makeRoot trees 
		| (singleton trees) = head trees
		| otherwise = makeRoot $ combine trees

createCodeTree :: [Char] -> CodeTree
createCodeTree chs = makeRoot (makeOrderedLeafList (times chs))

decode :: CodeTree -> [Int] -> [Char]
decode tree bits = acc tree bits
					where
						acc :: CodeTree -> [Int] -> [Char]
						acc (Fork(l, _, _, _)) (0:xs) = acc l xs
						acc (Fork(_, r, _, _)) (1:xs) = acc r xs
						acc (Leaf(c, _)) [] = [c]
						acc (Leaf(c, _)) xs = [c] ++ (decode tree xs)
						acc _ _ = []

encode :: CodeTree -> [Char] -> [Int]
encode tree text = concat [acc tree x | x <- text]
					where
						acc :: CodeTree -> Char -> [Int]
						acc thatTree c = case thatTree of
									(Fork(l, r, _, _)) -> if isInfixOf [c] (chars l) then [0] ++ (acc l c)
														  else [1] ++ (acc r c)
									_ -> []

-- using codeTables

type CodeTable = [(Char, [Int])]

codeBits :: CodeTable -> Char -> [Int]
codeBits table char = snd (head (filter (\n -> (fst n) == char) table))

convert :: CodeTree -> CodeTable
convert tree = case tree of
				(Fork(l, r, _, _)) -> mergeCodeTables (convert l) (convert r)
				(Leaf(c, _)) -> [(c, [])]

mergeCodeTables :: CodeTable -> CodeTable -> CodeTable
mergeCodeTables a b = (map (\(c, bi) -> (c, [0] ++ bi)) a) ++ (map (\(c, bi) -> (c, [1] ++ bi)) b)

quickEncode :: CodeTree -> [Char] -> [Int]
quickEncode tree text = case text of
							[] -> []
							(x:xs) -> (codeBits (convert tree) x) ++ (quickEncode tree xs)

-- tests

t1 :: CodeTree
t1 = Fork (Leaf ('a', 2), Leaf ('b', 3), ['a', 'b'], 5)

t2 :: CodeTree
t2 = Fork(t1, Leaf ('d', 4), ['a', 'b', 'd'], 9)

frenchCode :: CodeTree
frenchCode = Fork(Fork(Fork(Leaf('s',121895),Fork(Leaf('d',56269),Fork(Fork(Fork(Leaf('x',5928),Leaf('j',8351),['x','j'],14279),Leaf('f',16351),['x','j','f'],30630),Fork(Fork(Fork(Fork(Leaf('z',2093),Fork(Leaf('k',745),Leaf('w',1747),['k','w'],2492),['z','k','w'],4585),Leaf('y',4725),['z','k','w','y'],9310),Leaf('h',11298),['z','k','w','y','h'],20608),Leaf('q',20889),['z','k','w','y','h','q'],41497),['x','j','f','z','k','w','y','h','q'],72127),['d','x','j','f','z','k','w','y','h','q'],128396),['s','d','x','j','f','z','k','w','y','h','q'],250291),Fork(Fork(Leaf('o',82762),Leaf('l',83668),['o','l'],166430),Fork(Fork(Leaf('m',45521),Leaf('p',46335),['m','p'],91856),Leaf('u',96785),['m','p','u'],188641),['o','l','m','p','u'],355071),['s','d','x','j','f','z','k','w','y','h','q','o','l','m','p','u'],605362),Fork(Fork(Fork(Leaf('r',100500),Fork(Leaf('c',50003),Fork(Leaf('v',24975),Fork(Leaf('g',13288),Leaf('b',13822),['g','b'],27110),['v','g','b'],52085),['c','v','g','b'],102088),['r','c','v','g','b'],202588),Fork(Leaf('n',108812),Leaf('t',111103),['n','t'],219915),['r','c','v','g','b','n','t'],422503),Fork(Leaf('e',225947),Fork(Leaf('i',115465),Leaf('a',117110),['i','a'],232575),['e','i','a'],458522),['r','c','v','g','b','n','t','e','i','a'],881025),['s','d','x','j','f','z','k','w','y','h','q','o','l','m','p','u','r','c','v','g','b','n','t','e','i','a'],1486387)

secret :: [Int]
secret = [0,0,1,1,1,0,1,0,1,1,1,0,0,1,1,0,1,0,0,1,1,0,1,0,1,1,0,0,1,1,1,1,1,0,1,0,1,1,0,0,0,0,1,0,1,1,1,0,0,1,0,0,1,0,0,0,1,0,0,0,1,0,1]


main = do 
	   print $ weight(t1) == 5
	   print $ chars(t2) == ['a', 'b', 'd']
	   print $ leafToTuple (head (makeOrderedLeafList([Leaf('t', 2), Leaf('e', 1), Leaf('x', 3)]))) == ('e', 1)
	   print $ decode t1 (encode t1 "ab") == "ab"   
	   print $ decode frenchCode secret == "huffmanestcool"
	   print $ (encode frenchCode "huffmanestcool") == secret
	   print $ (encode t1 "ab") == (quickEncode t1 "ab")
