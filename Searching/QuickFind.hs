--	Quickfind
--	Genius algorithm to check for connected points on a graph.
--	This is a transcription from the Java implementation of
--	Sedgewick in his book "Algorithms in Java parts 1-4"
--	What Sedgewick doesn't mention:
--		- From the result you cannot tell if a point is connected to itself
--		- In case of non-commutative connections, you cannot distinguish what
--			is connected to what from the result (you need to assume that
--			connections will be ordered ASC or DESC and implement accordingly)

slice :: Int -> Int -> [Int] -> [Int]
slice from to xs = take (to - from + 1) (drop from xs)

replace :: Int -> Int -> Int -> [Int] -> [Int]
replace from to middleman xs = (slice from (to - 1) xs) ++ [middleman] ++ (slice (to + 1) (length xs) xs)

search :: Int -> Int-> Int -> [Int] -> [Int]
search f s i lista  
				| i >= (length lista) = lista
				| (lista !! i) == (lista !! f) = search f s (succ i) (replace 0 i (lista !! s) lista)
				| otherwise = search f s (succ i) lista

quickFind :: Int -> Int -> [Int] -> [Int]
quickFind f s sorter 
				| (sorter !! f) == (sorter !! s) = sorter 
				| otherwise = search f s 0 sorter

--tests
first = quickFind 0 1 [0..10]
second = quickFind 1 2 first
third = quickFind 2 3 second

main = print(third)
