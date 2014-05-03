object Main {
  
	def main(args: Array[String]) = {
	  println(bubbleSort(List(6,5,4,3,2,1)))
	  println(bubbleSort(List(5,6,4,2,1,3)))
	}

  	def bubbleSort(xs: List[Int]): List[Int] = {
	  def sortIt(cs: List[Int], index: Int): List[Int] = {
	    if(index == cs.length - 1) cs
	    else if (cs(index) > cs(index + 1)) 
	      sortIt(cs.slice(0, index) ++ List(cs(index + 1)) ++ List(cs(index)) ++ cs.slice(index + 2, cs.length), 0)
	    else sortIt(cs, index + 1)
	  }
	  
	  sortIt(xs, 0)
	}
}