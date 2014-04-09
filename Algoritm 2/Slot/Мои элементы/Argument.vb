Public Class Argument
    Dim WithEvents EditPr As New EditProperty
    Dim myObj As Object, prop As String
    Public Sub New()
        InitializeComponent()
        forEditPr.Controls.Add(EditPr)
        EditPr.Dock = DockStyle.Fill
        ArgLabel.Text = transInfc(ArgLabel.Text)
    End Sub
    Private Sub Palka1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Palka1.click
        Dim master As New Master(New MasterPattern(EditPr))
        master.TopMost = True
        master.Show()  'Me.TopLevelControl)
    End Sub
    Public Sub ShowArg(ByVal arg As String, ByVal MyObj As Object, ByVal prop As String)
        If EditPr.MyObjs Is Nothing Then EditPr.MyObjs = New Object() {MyObj}
        If UCase(arg) = UCase(transInfc("на следующее значение")) Then
            EditPr.ShowProp(CreateDs.ShowObj.GetProperty, CreateDs.ShowObj.GetMyObjs)
            ArgLabel.Text = arg
            ArgLabel.Font = New Font(ArgLabel.Font, FontStyle.Bold)
        Else
            EditPr.ShowPropArgs(arg, DefaultValue(arg))
            ArgLabel.Text = arg
            ArgLabel.Font = New Font(ArgLabel.Font, FontStyle.Regular)
            ToolTip1.SetToolTip(ArgLabel, ArgLabel.Text)
            ' переменные для infoPropsLabel
            Me.myObj = MyObj : Me.prop = prop
        End If
        Palka1.RefreshPic(SkinPictures)
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = Palka1
    End Sub
    Public Overrides Property Text() As String
        Get
            If bistro_orfo = False Then EditPr.Text = New CodeString(EditPr.Text).Text
            'proj.Podsvetka(EditPr.ActiveTextBox)
            Return EditPr.Text
        End Get
        Set(ByVal value As String)
            EditPr.Text = value
        End Set
    End Property
    Sub EditPr_Activate(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditPr.Enter
        If LCase(ArgLabel.Text) <> LCase(transInfc("на следующее значение")) Then
            Dim forma As Object = Me.TopLevelControl
            If forma Is Nothing = False Then forma.InfoArgsShow(ArgLabel.Text, myObj, prop)
        End If
    End Sub

End Class
