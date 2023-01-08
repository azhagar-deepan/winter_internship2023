Sub code()
    Application.ScreenUpdating = False
    Columns("c:c").AutoFilter Field:=1, Criteria1:="-"
    For Each cel In Range(Cells(1, "c"), Cells(Rows.Count, "c").End(xlUp)).SpecialCells(xlCellTypeVisible)
    If Not IsEmpty(cel) Then
    cel.Value = 0
    cel.NumberFormat = "General"
    cel.Interior.Color = vbRed
    End If
    Next cel
    Columns("c:c").AutoFilter
    Range("b:j").Copy Range("m:u")
    Columns("a:b").AutoFilter Field:=2, Criteria1:="<>(A)", Criteria2:="<>Total"
    
    Columns("a:b").AutoFilter Field:=1, Criteria1:="<>WEIGHTED BASE", Criteria2:="<>UNWEIGHTED BASE"
    For Each cel In Range(Cells(1, "b"), Cells(Rows.Count, "b").End(xlUp)).SpecialCells(xlCellTypeVisible)
        If cel.Value <> 0 And Not (IsEmpty(cel)) And (IsNumeric(cel)) Then
        Cells(cel.Row, "m").Value = 100
            With Range(Cells(cel.Row, "N"), Cells(cel.Row, "u"))
                .Formula = "=100*" & CStr(Cells(cel.Row, cel.Column + 1).Address(ColumnAbsolute:=False)) & "/" & CStr(cel.Address)
        End With
        End If
    Next cel
    
    With Columns("m:u")
            
        .NumberFormat = "General"
        .NumberFormat = "0"
    End With
Columns("a:b").AutoFilter
    With Columns("n:u").SpecialCells(xlCellTypeFormulas, xlErrors)
        .Value = "-"
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        
    End With
For Each cel In Range(Cells(1, "c"), Cells(Rows.Count, "c").End(xlUp))
If cel.Interior.Color = vbRed Then
With cel
        .Value = "-"
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .Interior.ColorIndex = 0
End With
With Cells(cel.Row, "n")
        .Value = "-"
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .Interior.ColorIndex = 0
End With
End If
Next cel
Application.ScreenUpdating = True
End Sub


