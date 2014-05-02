/*
	Given the definition of a Pascal triange (i.e.)
	1
	1	1
	1	2	1
	1	3	3	1
	...
	Return the number in the sequence standing in
	column "c" and row "r"
*/

def pascal(c: Int, r: Int): Int = {
    def sliceIt(ss: List[Int]): List[Int] = {
      if (ss.length < 2) List() else List(ss(0) + ss(1)) ++ sliceIt(ss.tail)
    }
    def rower(xs: List[Int]): Int = {
      if (xs.length == r + 1) xs(c) else rower(List(1) ++ sliceIt(xs) ++ List(1))
    }
    
    rower(List(1))
  }