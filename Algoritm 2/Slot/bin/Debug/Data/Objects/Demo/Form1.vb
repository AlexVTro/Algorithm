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
        Diagnostics.Process.Start("http://www.algorithm2.com/")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Diagnostics.Process.Start(regGetBuyURL("Algorithm", "Algorithm - create your own program!", "0"))
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Diagnostics.Process.Start("http://www.algorithm2.com/index.php?option=com_content&view=article&id=54&Itemid=65&ref=" & referral)
    End Sub

    Function regGetBuyURL(ByVal publisher As String, ByVal appName As String, ByVal appVer As String) As String
        ' form the registry key path
        Dim keyPath As String
        keyPath = "\SOFTWARE\Digital River\SoftwarePassport\" & publisher & "\" & appName & "\" & appVer

        Dim buyURL As String

        ' open the registry key
        ' try to get from HKEY_LOCAL_MACHINE first
        buyURL = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE" & keyPath, "BuyURL", Nothing)

        ' if fail to get from HKEY_LOCAL_MACHINE branch, try HKEY_CURRENT_USER
        If buyURL Is Nothing Then
            buyURL = My.Computer.Registry.GetValue("HKEY_CURRENT_USER" & keyPath, "BuyURL", Nothing)
        End If

        If buyURL Is Nothing Then
            ' BuyURL doesn't exsits in registry, default it
            buyURL = "http://www.algorithm2.com/index.php?option=com_content&view=article&id=66&Itemid=66" '&ref=" & referral
        End If

        Return buyURL
    End Function
End Class
