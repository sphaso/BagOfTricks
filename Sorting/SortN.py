# SortN is a simple algorithm I came up with to sort distinct and discrete positive number arrays in O(n) time
# Practically you could just generate one from scratch, of course, but I thought it was a nice exercise nonetheless

def sortN(array):
    for i in range(0, len(array) - 1):
        if i != array[i]:
            temp = array[i]
            swapper = array[temp]
            array[i] = swapper
            array[temp] = temp
    return array

def sortNFrom(array, leftmost):
    newArray = range(0, leftmost) + array
    plus = sortN(newArray)
    return plus[leftmost:]

arrayo = sortNFrom([100,99,98,97,96,95], 95)
print(arrayo)
