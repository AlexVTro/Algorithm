Imports Microsoft.VisualBasic.FileIO

Public Class Update
    Public NewVersion As String

    Private Sub Update_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If SkipCheckBox.Checked Then
            SkippedVersion = NewVersion
            MnFrm.SaveParametrs()
        End If
    End Sub

    Private Sub Edu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Image.FromFile(OblozhkaPath)
        Label1.Text = transInfc(Label1.Text)
        DownloadLabel.Text = transInfc(DownloadLabel.Text)
        MainLabel.Text = transInfc(MainLabel.Text).Replace("*", NewVersion)
        SkipCheckBox.Text = transInfc(SkipCheckBox.Text)
        DownloadButton.Text = transInfc(DownloadButton.Text)
        DoneButton.Text = transInfc(DoneButton.Text)
        LaterButton.Text = transInfc(LaterButton.Text)
        Text = transInfc(Text)
        InfoPanel.Visible = True : UpdateFreePanel.Visible = False : UpdatePayPanel.Visible = False
    End Sub

    Public Overloads Function ShowDialog(ByVal newVer As String) As DialogResult
        NewVersion = newVer
        Return MyBase.ShowDialog()
    End Function

    Private Sub LaterButton_Click(sender As Object, e As EventArgs) Handles LaterButton.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click
        ' Если это бесплатная версия
        If MnFrm.RegistrMenu.Visible = True Then
            UpdateProgramm(lastFreeVersionDownloadUrl, True)
        Else ' Если это платная версия
            ShowPayPanel()
        End If
    End Sub

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        UrlTextBox.Text = Trim(UrlTextBox.Text)

        If UrlTextBox.Text.StartsWith("http://algoritm2.ru") Or _
           UrlTextBox.Text.StartsWith("http://www.algoritm2.ru") Or _
           UrlTextBox.Text.StartsWith("http://algorithm2.com") Or _
           UrlTextBox.Text.StartsWith("http://www.algorithm2.com") Then
            ' кроссдомен атака проверка пройдена
        Else
            ' кроссдомен атака проверка не пройдена
            MsgBox(transInfc("Неверная ссылка. Если проблема повторяется, обратитесь, пожалуйста, в support@algoritm2.ru"))
            Exit Sub
        End If

        PayLink = UrlTextBox.Text : MnFrm.SaveParametrs()
        UpdateProgramm(UrlTextBox.Text, False)
    End Sub

    Private Sub UpdateProgramm(ByVal url As String, ByVal versionFree As Boolean)
        Dim newFilePath As String = IO.Path.GetTempFileName() & ".exe"

        ShowDownloadPanel()

        ' Скачиваем алг с сайта
        Try
            If versionFree Then
                My.Computer.Network.DownloadFile(url, newFilePath, "", "", True, 10000, True, UICancelOption.ThrowException)
            Else
                My.Computer.Network.DownloadFile(url, newFilePath, "", "", False, 10000, True, UICancelOption.ThrowException)
            End If
        Catch ex As OperationCanceledException
            ShowInfoPanel()
            Exit Sub
        Catch ex As Exception
            MsgBox(transInfc("Невозможно скачать программу. Если проблема повторяется, обратитесь, пожалуйста, в support@algoritm2.ru") & vbCrLf & vbCrLf & ex.Message)
            If versionFree Then
                ShowInfoPanel()
            Else
                ShowPayPanel()
            End If
            Exit Sub
        End Try

        If MsgBox(transInfc("Для дальнейшей установки необходимо закрыть программу Алгоритм"), MsgBoxStyle.Information + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            ShowInfoPanel()
            Exit Sub
        End If

        If MnFrm.ReadyToCloseProgramm() = False Then
            MsgBox(transInfc("Установка обновления была отменена"))
            DialogResult = DialogResult.Cancel
            Exit Sub
        End If

        tokaSohranil = True ' для избежания повторного вопроса сохранения от ReadyToCloseProgramm
        MnFrm.Close()
        Diagnostics.Process.Start(newFilePath)
    End Sub

    Private Sub ShowInfoPanel()
        InfoPanel.Visible = True : UpdateFreePanel.Visible = False : UpdatePayPanel.Visible = False
    End Sub
    Private Sub ShowDownloadPanel()
        InfoPanel.Visible = False : UpdateFreePanel.Visible = True : UpdatePayPanel.Visible = False
        Application.DoEvents()
    End Sub
    Private Sub ShowPayPanel()
        UrlTextBox.Text = PayLink
        InfoPanel.Visible = False : UpdateFreePanel.Visible = False : UpdatePayPanel.Visible = True
    End Sub

End Class