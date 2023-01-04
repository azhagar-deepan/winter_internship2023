Sub code()
Range("AS1:BW1").EntireColumn.Delete
Range("T1:AH1").EntireColumn.Delete
Range("C1:P1").EntireColumn.Delete
Range("A1").EntireRow.Insert
Range("a1:o1").Merge
Range("a1").Value = "orders_export"
Range("A1").Font.Size = 12
Range("a1").VerticalAlignment = xlCenter
Range("a1").HorizontalAlignment = xlCenter
Range("A1").Font.Name = "Helvetica Neue"
Range("A1").EntireRow.RowHeight = 30
Range("A2:O2").EntireRow.RowHeight = 25
Range("A2:O2").Font.Bold = True
Range("A2:O2").Interior.Color = RGB(189, 192, 191)
Range("A2:O2").Font.Name = "Helvetica Neue"
Range("A2:O2").VerticalAlignment = xlTop
Range("A2:O2").Font.Size = 10
Range("A2:O2").Borders(xlEdgeBottom).Color = RGB(165, 165, 165)
Range("A2:O2").Borders(xlEdgeTop).Color = RGB(165, 165, 165)
Range("A2:O2").Borders(xlEdgeRight).Color = RGB(165, 165, 165)
Range("A2:O2").Borders(xlEdgeLeft).Color = RGB(165, 165, 165)
Range("A2:O2").Borders(xlInsideVertical).Color = RGB(165, 165, 165)
Range("A2:O2").EntireColumn.AutoFit
Range("p1", Range("p1").End(xlToRight)).EntireColumn.Hidden = True
For Each i In Range(Cells(3, 1), Cells(Rows.Count, 1).End(xlUp)).Rows
  i.Font.Bold = True
  i.Interior.Color = RGB(219, 219, 219)
  i.Font.Name = "Helvetica Neue"
  i.Font.Size = 10
Next i
For Each cel In Range(Cells(3, 12), Cells(Rows.Count, 12).End(xlUp))
  cel.Value = WorksheetFunction.Replace(cel.Value, 1, 1, "")
  cel.NumberFormat = "00000"

Next cel

End Sub




