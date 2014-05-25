data CodeTree = Fork (CodeTree, CodeTree, [Char], Int)
			  | Leaf (Char, Int)

weight :: CodeTree -> Int
weight (Fork (l, r, _, _)) =  weight(l) + weight(r)
weight (Leaf (_, w)) = w

chars :: CodeTree -> [Char]
chars (Fork (l, r, _, _)) = chars(l) ++ chars(r)
chars (Leaf (c, _)) = [c]

makeCodeTree :: CodeTree -> CodeTree -> CodeTree
makeCodeTree a b = Fork (a, b, chars(a) ++ chars(b), weight(a) + weight(b))

countEquals ::Eq a => a -> [a] -> Int
countEquals a l = length (filter (\n -> n == a) l)

times :: [Char] -> [Leaf]
times ccs = case ccs of (x:xs) -> [Leaf (x, countEquals(x ccs))] ++ times(filter (/=x) xs)

prova :: CodeTree
prova = Fork (Leaf ('c', 3), Leaf ('a', 3), ['c', 'a'], 6)

main = print (countEquals 1 [1,1,1,2])
