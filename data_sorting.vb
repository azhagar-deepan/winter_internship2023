Sub SORT()
Application.ScreenUpdating = False
n = Range(Range("a1").End(xlToRight), Range("a1").End(xlToRight).End(xlToRight)).Count
For i = 1 To n
Range(Range("a1"), Range("a1").End(xlToRight).End(xlToRight)).EntireColumn.SORT key1:=Range(Cells(1, i + 3).Address), order1:=xlAscending, Header:=xlYes '#SORTING COMMAND
Range("c2:c11").Font.Color = vbRed '#ASCENDING HEAD COLOR
Range(Range("c1").End(xlDown).End(xlDown).Offset(rowOffset:=-9, columnOffset:=0), Range("c1").End(xlDown).End(xlDown).Address).Font.Color = RGB(33, 115, 70) '#DESCENDING HEAD COLOR
Range("c2:c11").Copy Cells(Range("c1").End(xlDown).End(xlDown).Row + 10, i + 3) '#COPY ASCENDING HEAD
Range(Range("c1").End(xlDown).End(xlDown).Offset(rowOffset:=-9, columnOffset:=0), Range("c1").End(xlDown).End(xlDown).Address).Copy Cells(Range("c1").End(xlDown).End(xlDown).Row + 25, i + 3) '#COPY DESCENDING HEAD
Range(Range("a1").End(xlToRight), Range("a1").End(xlToRight).End(xlToRight)).EntireColumn.AutoFit '#ADJUSTING COLUMNS
Next i
Application.ScreenUpdating = True

End Sub
