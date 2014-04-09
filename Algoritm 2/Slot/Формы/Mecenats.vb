Public Class Mecenat

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = Image.FromFile(SkinsPath & "\oblozhka.jpg")
            If lang_interface = "Russian" Then
                LinkLabel1.Text = "www.Algoritm2.ru"
            Else
                LinkLabel1.Text = "www.Algorithm2.com"
            End If
            Me.Text = transInfc(Me.Text)
            LabelBenef.Text = transInfc(LabelBenef.Text.Replace(":", "")) & ":"
            LabelModers.Text = transInfc(LabelModers.Text.Replace(":", "")) & ":"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Diagnostics.Process.Start(LinkLabel1.Text, "")
    End Sub

    Private Sub LabelBenef_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LabelBenef.LinkClicked
        If lang_interface = "Russian" Then
            Diagnostics.Process.Start(SiteAlg & "/index.php?option=com_hello&task=donate&Itemid=11")
        Else
            Diagnostics.Process.Start("https://www.regnow.com/softsell/nph-softsell.cgi?item=24231-1")
        End If
    End Sub

    Private Sub LabelModers_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LabelModers.LinkClicked
        If lang_interface = "Russian" Then
            Diagnostics.Process.Start(SiteAlg & "/forum/viewtopic.php?f=4&t=636&start=0")
        Else
            Diagnostics.Process.Start(SiteAlg & "/forum_en/viewtopic.php?f=2&t=4&p=5#p5")
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim s As New Sinner
        s.ShowDialog()
    End Sub
End Class