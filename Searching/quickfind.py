#	Quickfind
#	Genius algorithm to check for connected points on a graph.
#	This is a transcription from the Java implementation of
#	Sedgewick in his book "Algorithms in Java parts 1-4"
#	What Sedgewick doesn't mention:
#		- From the result you cannot tell if a point is connected to itself
#		- In case of non-commutative connections, you cannot distinguish what
#			is connected to what from the result (you need to assume that
#			connections will be ordered ASC or DESC and implement accordingly)

__capacity = 10
__sorter = [i for i in range(0, __capacity)]

def quickfind(first, second):
	sortFirst = __sorter[first]
	sortSecond = __sorter[second]
	if(sortFirst == sortSecond):
		return __sorter
	for i in range(0, __capacity):
		if (__sorter[i] == sortFirst):
			__sorter[i] = sortSecond
	return __sorter

def test():
	quickfind(1,2)
	quickfind(2,3)
	quickfind(3,4)

test()
print(__sorter)
