Public Class CodeVE

    Dim EdPr As New EditProperty(True, True)
    Private Sub Edu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Image.FromFile(OblozhkaPath)
        Button1.Text = transInfc(Button1.Text)
        Button3.Text = transInfc(Button3.Text)
        Me.Text = transInfc(Me.Text)
        forEditProperty.Controls.Add(EdPr)
        EdPr.Dock = DockStyle.Fill
        CheckBox1.Text = transInfc(CheckBox1.Text)

        ' Заносим в едитпроперти все свойства
        Dim o As ObjsTreesText = MainForm.ObjTrs
        Dim i As Integer, str As String = ""
        For i = 0 To o.Objs.Length - 1
            o.Origs(i) = MainForm.CodeView.Substring(o.Starts(i), o.Lengs(i))
            str &= o.Origs(i)
        Next
        EdPr.Text = str
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        EdPr.bezPodsvetki = Not CheckBox1.Checked
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' Получаем по порядку обновленные объекты
        Dim endStr As String = (vbCrLf & "#End" & vbCrLf & vbCrLf)
        Dim cod As String = EdPr.ActiveTextBox.Text.Replace(vbCrLf.Substring(1, 1), vbCrLf) & vbCrLf & vbCrLf & vbCrLf
        Dim strs() As String = {}
        Dim St As Integer = cod.IndexOf(vbCrLf & "#End"), oSt As Integer = 0
        While St <> -1
            St += endStr.Length
            ReDims(strs) : strs(strs.Length - 1) = cod.Substring(oSt, St - oSt)
            oSt = St : St = cod.IndexOf(vbCrLf & "#End", St)
        End While
        ' Заменяем
        Dim i As Integer, s As String = MainForm.CodeView
        For i = 0 To strs.Length - 1
            s = s.Replace(MainForm.ObjTrs.Origs(i), strs(i))
        Next
        ' Применяем
        MainForm.resetProj()
        CreateObjects(s, False, False, proj.f, Tree, Breaks, proj, True)

        Me.Close()
    End Sub
End Class