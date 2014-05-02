def pascal(col, row):
    def calculateLine(lastRow):
        if (len(lastRow) == row + 1):
            return lastRow[col]
        thisRow = [1] + [lastRow[i] + lastRow[i - 1] for i in range(1, len(lastRow))] + [1]
        return calculateLine(thisRow)
    return calculateLine([1])
