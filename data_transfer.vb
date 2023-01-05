Sub CODE()
Application.ScreenUpdating = False

a = "7" ' Provide Sheet Name
Sheets.Add.Name = a
Sheets("Data").Activate
Range("a1").EntireRow.Copy
Sheets(a).Select
Range("a1").Select
ActiveSheet.Paste
Sheets("Data").Activate
i = 2
For Each cel In Range(Range("b2"), Range("b2").End(xlDown)).Cells
    If (cel.Value = "Transfer") Then
        cel.EntireRow.Copy
        Sheets(a).Select
        Cells(i, 1).EntireRow.Select
        ActiveSheet.Paste
        i = i + 1
        Sheets("Data").Activate
    End If
Next cel
Application.CutCopyMode = False


Application.ScreenUpdating = True
End Sub

