Public Class CreateIf
    Public WithEvents ShowObj As ShowObject
    Public EditPrUsually, EditPrPodIf As EditProperty
    Dim args As New Arguments()
    Public border As Integer = 0
    Public colBorder As Color

    Public Sub Shown()
        ifUsuallyPanel.Visible = True
        If proj.GetIfNameFromTreeNode Is Nothing Then
            IfPodIfPanel.Visible = False
            ifElsePanel.Visible = False
            IfPodIf.Checked = False
            ifElse.Checked = False
            ifUsually.Checked = True
        Else
            IfPodIfPanel.Visible = True
            ' Если элсе уже есть в данном условии
            If proj.GetElseOrElseIf(Tree.SelectedNode) Is Nothing = False Then
                ifElsePanel.Visible = False
                If ifElse.Checked = True Then
                    ifElse.Checked = False : ifUsually.Checked = True
                End If
            Else
                ifElsePanel.Visible = True
            End If
        End If
    End Sub
    Public Sub Shown(ByVal IfUsuallyVis As Boolean, ByVal IfPodIfVis As Boolean, ByVal IfElseVis As Boolean, ByVal check As String)
        ifUsuallyPanel.Visible = IfUsuallyVis
        IfPodIfPanel.Visible = IfPodIfVis
        ifElsePanel.Visible = IfElseVis
        ifUsually.Checked = False
        IfPodIf.Checked = False
        ifElse.Checked = False
        Select Case check
            Case "If" : ifUsually.Checked = True
            Case "ElseIf" : IfPodIf.Checked = True
            Case "Else" : IfPodIf.Checked = True
            Case Else : ifUsually.Checked = True
        End Select
    End Sub
    Overloads Property text(ByVal IfType As String) As String
        Get
            Return getText(IfType)
        End Get
        Set(ByVal value As String)
            If EditPrUsually Is Nothing Then Exit Property
            value = UbratKluchSlova(IfType, value)
            If IfType = "If" Then
                EditPrUsually.Text = value
            ElseIf IfType = "ElseIf" Then
                EditPrPodIf.Text = value
            End If
        End Set
    End Property

    Private Sub CreateIf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EditPrUsually = New EditProperty() : forEditPrUsually.Controls.Add(EditPrUsually)
        EditPrUsually.Dock = DockStyle.Fill
        ifUsually.Text = UCase(transInfc(ifUsually.Text))
        LabelIf.Text = UCase(trans(LabelIf.Text))
        LabelElseIf.Text = UCase(trans(LabelElseIf.Text))
        LabelThen.Text = UCase(trans(LabelThen.Text))
        LabelThen2.Text = UCase(trans(LabelThen2.Text))
        EditPrUsually.Text = proj.ActiveForm.obj.Props.name & "." & proj.ActiveForm.obj.Props.name & "." & trans("Текст") & " = " & proj.ActiveForm.obj.Props.name & "." & proj.ActiveForm.obj.Props.name & "." & trans("Текст")

        EditPrPodIf = New EditProperty() : forEditPrPodIf.Controls.Add(EditPrPodIf)
        EditPrPodIf.Dock = DockStyle.Fill
        IfPodIf.Text = transInfc(IfPodIf.Text)
        ifElse.Text = transInfc(ifElse.Text)
        EditPrPodIf.Text = proj.ActiveForm.obj.Props.name & "." & proj.ActiveForm.obj.Props.name & "." & trans("Текст") & " = " & proj.ActiveForm.obj.Props.name & "." & proj.ActiveForm.obj.Props.name & "." & trans("Текст")

        PalkaUsually.RefreshPic(SkinPictures)
        PalkaPodIf.RefreshPic(SkinPictures)

        help1.Image = Pictures32.Images("HelpMenu") : AddHandler help1.Click, AddressOf MainForm.Helps_Click
        help2.Image = Pictures32.Images("HelpMenu") : AddHandler help2.Click, AddressOf MainForm.Helps_Click
        help3.Image = Pictures32.Images("HelpMenu") : AddHandler help3.Click, AddressOf MainForm.Helps_Click
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = help1
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = help2
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = help3
    End Sub

    Public Function getText(Optional ByVal IfType As String = "") As String
        If ifUsually.Checked Or IfType = "If" Then
            Dim txt As String = EditPrUsually.Text
            If bistro_orfo = False Then txt = New CodeString(EditPrUsually.Text).Text
            Return SozdatKluchSlova("If", txt)
        ElseIf IfPodIf.Checked Or IfType = "ElseIf" Then
            Dim txt As String = EditPrPodIf.Text
            If bistro_orfo = False Then txt = New CodeString(EditPrPodIf.Text).Text
            Return SozdatKluchSlova("ElseIf", txt)
        ElseIf ifElse.Checked Or IfType = "Else" Then
            Return SozdatKluchSlova("Else", "")
        End If
    End Function
    Public Function getTypes() As String
        If ifUsually.Checked Then Return "Usually"
        If IfPodIf.Checked Then Return "podIf"
        If ifElse.Checked Then Return "Else"
    End Function

    Private Sub PalkaUsually_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PalkaUsually.click
        Dim master As New Master(New MasterPattern(EditPrUsually, , , True))
        master.ShowDialog(Me.TopLevelControl)
    End Sub
    Private Sub PalkaPodIf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PalkaPodIf.click
        Dim master As New Master(New MasterPattern(EditPrPodIf, , , True))
        master.ShowDialog(Me.TopLevelControl)
    End Sub

    Private Sub If_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ifUsually.Click, IfPodIf.Click, ifElse.Click
        ifUsually.Checked = False : IfPodIf.Checked = False : ifElse.Checked = False
        sender.Checked = True
    End Sub

End Class
