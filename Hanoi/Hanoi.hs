type Peg = String
type Move = (Peg, Peg)

hanoi :: Integer -> Peg -> Peg -> Peg -> [Move]
hanoi 0 _   _    _    = []
hanoi n src dest temp = (hanoi (n - 1) src temp dest) ++
                        [(src, dest)] ++
                        (hanoi (n - 1) temp dest src)

main = print (hanoi 3 "A" "C" "B")