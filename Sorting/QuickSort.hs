-- This is not exactly Quicksort, it only translates the general idea of the algorithm but the performances will be much worse. Why?
-- 1) it's scanning the whole array to find elements smaller \ bigger than the pivot twice. The number of comparisons won't allow this to be O(nlogn)
-- 2) it's constructing arrays at each recursion, the original algorithm uses only one array
-- 3) the pivot is not randomized, lessening the chances of a good performance
-- This algorithm is usually considered the poster child for Haskell: bad marketing!

quicksort :: Ord a => [a] -> [a]
quicksort [] = []
quicksort (x:xs) = (quicksort [y | y<-xs, y <= x]) ++ [x] ++ (quicksort [z | z<-xs, z > x])

