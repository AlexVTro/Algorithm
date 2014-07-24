Public Class About

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = Image.FromFile(OblozhkaPath)
            If lang_interface = "Russian" Then
                LinkLabel1.Text = "www.Algoritm2.ru"
            Else
                LinkLabel1.Text = "www.Algorithm2.com"
            End If
            Me.Text = transInfc(Me.Text)
            VersionLabel.Text = AppNameWithVersion
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Diagnostics.Process.Start(LinkLabel1.Text & GetEndingLink(False), "")
    End Sub
End Class