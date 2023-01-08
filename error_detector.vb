Sub CODE()
Application.ScreenUpdating = False
Sheets.Add.Name = "Output"
Sheet1.Activate
i = 1
For Each cel In Range(Cells(1, 1), Cells(Rows.Count, 1).End(xlUp))
If InStr(cel, "Number") Then
        cel.Copy
        Sheets("Output").Select
        Cells(i, 2).Select
        ActiveSheet.Paste
        Cells(i, 1).Value = cel.Address
        i = i + 1
        Sheet1.Activate
End If
Next cel
Sheets("Output").Select
Range("b:b").TextToColumns , xlDelimited, xlDoubleQuote, True, , , , True
Range("a1:j1").EntireColumn.Sort key1:=Range("f1"), order1:=xlDescending, Header:=xlNo
For Each cel In Range(Range("a1"), Range("a1").End(xlDown))
ActiveSheet.Hyperlinks.Add Range(cel.Address), Address:="", SubAddress:="'" & "Sheet1" & "'!" & cel.Value
Next cel
Application.ScreenUpdating = False
End Sub


