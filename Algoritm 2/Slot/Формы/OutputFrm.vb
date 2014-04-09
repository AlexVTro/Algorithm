Public Class OutputFrm

    Private Sub OutputFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = transInfc(Me.Text)
        Label1.Text = transInfc(Label1.Text)
        Label2.Text = transInfc(Label2.Text)
        Dim ind As Integer = TextBox1.Lines(0).Length + TextBox1.Lines(1).Length + TextBox1.Lines(2).Length + 6
        TextBox1.Text = TextBox1.Text.Substring(ind)
        TextBox1.SelectionStart = 0
    End Sub
End Class