Public Class Form1
    Dim referral As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim txt As String = IO.File.ReadAllText(Environment.GetCommandLineArgs()(0))
        Dim ind As Integer = txt.LastIndexOf("referral=")
        If ind = -1 Then
            referral = "admin"
        Else
            referral = Trim(txt.Substring(ind + "referral=".Length))
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Diagnostics.Process.Start("http://www.algoritm2.ru/?ref=" & referral)
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Diagnostics.Process.Start("http://algoritm2.ru/index.php?option=com_content&view=article&id=66&Itemid=66&ref=" & referral)
    End Sub

End Class
