Public Class Help1

    Private Sub Help1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Button1_Click(Nothing, Nothing)
    End Sub
    Private Sub Help1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If System.Environment.GetCommandLineArgs().Length >= 3 Then
            Hlps = New Helps(System.Environment.GetCommandLineArgs()(1) _
                            , System.Environment.GetCommandLineArgs()(2) _
                            , System.Environment.GetCommandLineArgs()(3) _
                            , System.Environment.GetCommandLineArgs()(4) _
                            , System.Environment.GetCommandLineArgs()(5) _
                            )
            runCreateHelp()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Hlps = New Helps(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        runCreateHelp()
    End Sub
    Sub runCreateHelp()
        isDevelop = False
        isHelp = True
        proj = New project
        CreateConstants()
        Hlps.CreateHelp()
        'End
    End Sub
    Class project
        Public f As Object
        Function GiveName(ByVal defaultName)
        End Function
        Function ChangeName(ByVal obj, ByVal oldName)
        End Function
    End Class


End Class

Public Module H
    Public Perevodi, rp As Object
    Function ToTreeFromAlgCode(ByVal ParamArray a())
    End Function
    Function getCompilLineLength(ByVal ParamArray a())
    End Function
    Function GetCompilName(ByVal ParamArray a())
    End Function
End Module