Public Class Arguments
    Public Args() As Argument
    Public border As Integer = 0
    Public borderIn As Integer = 0
    Public colBorder As Color

    Public Sub ShowArgs(ByVal argi() As String, ByVal MyObj As Object, ByVal prop As String)
        Dim temp() As Argument = Nothing
        If argi Is Nothing Then NoArg() : Exit Sub
        If argi(0) Is Nothing Then NoArg() : Exit Sub
        If IsArray(MyObj) Then MyObj = MyObj(0)

        Dim i As Integer
        If Args Is Nothing = False Then
            For i = 0 To Args.Length - 1
                ReDim Preserve temp(i) : temp(i) = Args(i)
            Next
        End If
        Dim ind As Integer = 0
        For i = 0 To argi.Length - 1
            If argi(i) = "" Then Continue For
            ReDim Preserve Args(ind) : Args(ind) = New Argument()
            Args(ind).ShowArg(argi(i), MyObj, prop)
            Args(ind).Top = i * (Args(ind).Height + 3)
            ind += 1
        Next
        Me.Controls.AddRange(Args)
        ClearArgs(temp)
        Arguments_Resize(Nothing, Nothing) : Me.Refresh()
    End Sub
    Function GetText(Optional ByVal withSkobki As Boolean = True) As String
        Dim str As String, i As Integer
        If Args Is Nothing Then Return ""
        If Args(0) Is Nothing Then Return ""
        If withSkobki = True Then str = "("
        For i = 0 To Args.Length - 1
            str &= Args(i).Text
            If i < Args.Length - 1 Then str &= ", "
        Next
        If withSkobki = True Then str &= ")"
        Return str
    End Function
    Function isMethodProp() As Boolean
        If Args Is Nothing Then Return True
    End Function
    Sub NoArg()
        Me.BorderStyle = Windows.Forms.BorderStyle.None
        ClearArgs(Args)
    End Sub
    Sub ClearArgs(ByRef argi() As Argument)
        Dim i As Integer
        If argi Is Nothing Then Exit Sub
        For i = 0 To argi.Length - 1
            MainForm.HelpDelete(argi(i).Palka1)
            Me.Controls.Remove(argi(i))
        Next
        argi = Nothing
    End Sub

    Private Sub Arguments_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If border > 0 Then
            e.Graphics.DrawRectangle(New Pen(colBorder, border), New Rectangle(border / 2, border / 2, Me.Width - border, Me.Height - border))
        ElseIf borderIn > 0 Then
            If Args Is Nothing = False Then
                Dim sdvig As Integer = Args(0).ArgLabel.Height + Args(0).ArgLabel.Top
                e.Graphics.DrawRectangle(New Pen(colBorder, borderIn), New Rectangle(border / 2, sdvig + border / 2, Me.Width - border - 1, Me.Height - border - sdvig - 3))
            End If
        End If
    End Sub

    Private Sub Arguments_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim i As Integer
        If Args Is Nothing Then Exit Sub
        For i = 0 To Args.Length - 1
            Args(i).Width = Me.Width - 6
        Next
    End Sub

End Class
