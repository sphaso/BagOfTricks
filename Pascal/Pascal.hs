
pascal :: Int -> [Int]
pascal 0 = [1]
pascal 1 = [1,2,1]
pascal n = zipWith (+) (previous ++ [0]) ([0] ++ previous)
		where previous = pascal (n - 1)
