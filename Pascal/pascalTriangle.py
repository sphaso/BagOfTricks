# Given the definition of a Pascal triange (i.e.)
# 1
# 1 1
# 1 2 1
# 1 3 3 1
# ...
# Return the number in the sequence standing in
# column "c" and row "r"

def pascal(col, row):
    def calculateLine(lastRow):
        if (len(lastRow) == row + 1):
            return lastRow[col]
        thisRow = [1] + [lastRow[i] + lastRow[i - 1] for i in range(1, len(lastRow))] + [1]
        return calculateLine(thisRow)
    return calculateLine([1])
