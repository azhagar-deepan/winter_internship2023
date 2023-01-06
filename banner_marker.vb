Sub Code()
Application.ScreenUpdating = False
Cells.Interior.ColorIndex = 0
x = InputBox("Enter Number of Letters")
g = 0
i = 1
h = -1
While (g < 2)
    If Application.WorksheetFunction.CountA(Columns(i)) = 0 Then
        g = g + 1
    End If
    If (g = 1) Then
        h = h + 1
        If (h Mod 2 = 0) And (h <> 0) Then
            For Each cel In Range(Cells(1, h + 3), Cells(Rows.Count, h + 3).End(xlUp))
                If (Len(cel) >= CInt(x)) Then
                        Select Case Len(cel)
                            Case CInt(x)
                                cel.Offset(, -1).Interior.Color = vbYellow
                            Case Is > CInt(x)
                            cel.Offset(, -1).Interior.Color = vbGreen
                        End Select
                End If
            Next cel
        End If
    End If
    i = i + 1
Wend
Application.ScreenUpdating = False
End Sub


