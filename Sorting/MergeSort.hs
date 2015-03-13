sort :: (Ord a) => [a] -> [a]
sort = halve

halve :: (Ord a) => [a] -> [a]
halve [x] = [x]
halve xs  = merge (halve $ take n xs) (halve $ drop n xs)
		where n = div (length xs) 2

merge :: (Ord a) => [a] -> [a] -> [a]
merge [] ys        = ys
merge xs []        = xs
merge (x:xs) (y:ys)
       	           | x >= y  = y : merge (x:xs) ys
	           | x < y   = x : merge xs (y:ys)
