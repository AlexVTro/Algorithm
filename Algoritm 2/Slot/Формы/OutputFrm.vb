Public Class OutputFrm

    Private Sub OutputFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = transInfc(Me.Text)
        Label1.Text = transInfc(Label1.Text)
        Label2.Text = transInfc(Label2.Text)
        Label3.Text = transInfc(Label3.Text)
        Label4.Text = transInfc(Label4.Text)
        ExportVbButton.Text = transInfc(ExportVbButton.Text)
        VisualStudioButton.Text = transInfc(VisualStudioButton.Text)
        Dim ind As Integer = TextBox1.Lines(0).Length '+ TextBox1.Lines(1).Length + TextBox1.Lines(2).Length + 6
        TextBox1.Text = TextBox1.Text.Substring(ind)
        TextBox1.SelectionStart = 0
    End Sub

    Private Sub VisualStudioButton_Click(sender As Object, e As EventArgs) Handles VisualStudioButton.Click
        MnFrm.VisualStudioExpressMenuItem_Click(sender, e)
    End Sub

    Private Sub ExportVbButton_Click(sender As Object, e As EventArgs) Handles ExportVbButton.Click
        MnFrm.ExportVBMenu_Click(sender, e)
    End Sub
End Class