Public Class Sinner

    Private Sub Sinner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Url = New Uri(ObjectsPath & "sinner.htm")
    End Sub
End Class