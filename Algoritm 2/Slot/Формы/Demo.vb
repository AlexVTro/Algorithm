Public Class Demo

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Diagnostics.Process.Start(regGetBuyURL("Algorithm", "Algorithm - create your own program!", "0"))
    End Sub

    Private Sub Demo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.Tag <> "" Then End
    End Sub
    Private Sub Demo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Image.FromFile(OblozhkaPath)
        TextBox2.Text = LoadProgress()
        Me.Text = transInfc(Me.Text)
        Label1.Text = transInfc(Label1.Text)
        Label3.Text = transInfc(Label3.Text)
        Label4.Text = transInfc(Label4.Text)
        LinkLabel1.Text = transInfc(LinkLabel1.Text)
        LinkLabel2.Text = SiteAlg
        LinkLabel3.Text = transInfc(LinkLabel3.Text)
        TextBox1.Text = transInfc(TextBox1.Text)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
#If Full Or DebugFull Or Http Then
        ' Сравниваем
        If PerfomanceProgress(TextBox1.Text) Then
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\A" & "l" & "g").SetValue("A" & "c" & "t", "1")
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Notepad").SetValue("ShowTimeP", TextBox1.Text)
            MsgBox(transInfc("Продукт успешно зарегистрирован, спасибо!"), MsgBoxStyle.Information)
            Me.Hide()
            MainForm.RegistrMenu.Visible = False
        Else
            Dim i As Int16
            While i < 10000 : i += 1 : End While
            MsgBox(transInfc("Ключ неверен"))
        End If
#Else
        ' Подстава
        If TextBox1.Text.IndexOf("1") <> -1 Then
            MsgBox(transInfc("Продукт успешно зарегистрирован, спасибо!"), MsgBoxStyle.Information)
            Me.Hide()
            MainForm.RegistrMenu.Visible = False
        Else
            Dim i As Int16
            While i < 10000 : i += 1 : End While
            MsgBox(transInfc("Ключ неверен"))
        End If
#End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If lang_interface = "Russian" Then
            Diagnostics.Process.Start(SiteAlg & "/index.php?option=com_content&view=article&id=54&Itemid=65&ref=" & referral)
        Else
            Diagnostics.Process.Start(SiteAlg & "/index.php?option=com_content&view=article&id=54&Itemid=65")
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If lang_interface = "Russian" Then
            Diagnostics.Process.Start(SiteAlg & "/?ref=" & referral)
        Else
            Diagnostics.Process.Start(SiteAlg)
        End If
    End Sub


    Function regGetBuyURL(ByVal publisher As String, ByVal appName As String, ByVal appVer As String) As String
        If lang_interface = "Russian" Then
            Return SiteAlg & "/index.php?option=com_content&view=article&id=66&Itemid=66&ref=" & referral
        Else
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
                buyURL = SiteAlg & "/index.php?option=com_content&view=article&id=66&Itemid=66" '&ref=" & referral
            End If

            Return buyURL
        End If
    End Function
End Class