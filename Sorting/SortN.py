# SortN is a simple algorithm I came up with to sort distinct and discrete positive number arrays in O(n) time
# I don't know if there's anything similar in literature, if so please comment :)

def sortN(array):
    for i in range(0, len(array) - 1):
        if i != array[i]:
            temp = array[i]
            swapper = array[temp]
            array[i] = swapper
            array[temp] = temp
    return array

arrayo = sortN([5,4,3,2,1,0])
print(arrayo)
