Public Class Edu

    Private Sub Edu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If CheckBox1.Checked Then StartEdu = "No" : OptionsForm.SaveOptions()
    End Sub

    Private Sub Edu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Image.FromFile(SkinsPath & "\oblozhka.jpg")
        If associateError <> "" Then
            Label2.Text = transInfc("Внимание! Программа запущена НЕ от имени Администратора. Это может повлечь ограничение некоторых функций программы и ошибки. Настоятельно рекомендуем запустить программу от имени Администратора. Для этого кликните правой кнопкой мыши по Алгоритм2.ехе и выберите пункт ""Запуск от имени Администратора"")") ' & associateError
            Me.Height += Label2.Height
        End If
        Label1.Text = transInfc(Label1.Text)
        Label2.Text = transInfc(Label2.Text)
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
        Diagnostics.Process.Start(ProjectsPath & "\" & trans("Примеры"))
        Me.Close()
    End Sub
End Class