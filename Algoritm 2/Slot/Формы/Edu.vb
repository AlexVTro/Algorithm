Public Class Edu

    Private Sub Edu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If CheckBox1.Checked Then StartEdu = "No" : OptionsForm.SaveOptions()
    End Sub

    Private Sub Edu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Image.FromFile(OblozhkaPath)
        Label1.Text = transInfc(Label1.Text)
        Label3.Text = transInfc(Label3.Text)
        CheckBox1.Text = transInfc(CheckBox1.Text)
        Button1.Text = transInfc(Button1.Text)
        Button2.Text = transInfc(Button2.Text)
        Button3.Text = transInfc(Button3.Text)
        Me.Text = transInfc(Me.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MainForm.LessonsFirstMenu_Click(sender, e)
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Diagnostics.Process.Start(HelpPath & "\First.html")
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Diagnostics.Process.Start(SamplesPath)
        Me.Close()
    End Sub
End Class