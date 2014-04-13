Public Class Uvedomlenie

    Private Sub Edu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If CheckBox1.Checked Then StartUved = "No" : OptionsForm.SaveOptions()
    End Sub

    Private Sub Edu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Image.FromFile(OblozhkaPath)
        Me.PictureBox1.Image = Image.FromFile(SkinsPath & "\master.png")
        Label3.Text = transInfc(Label3.Text)
        CheckBox1.Text = transInfc(CheckBox1.Text)
        Me.Text = transInfc(Me.Text)
    End Sub

End Class