Public Class CreateDeistv
    Public WithEvents ShowObj As ShowObject
    'Dim EditPr As EditProperty
    Public args As New Arguments()
    Public border As Integer = 0
    Public colBorder As Color

    Private Sub CreateDeistv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        border = SkinOptions("RamkaCD")
        colBorder = SkinColors("RamkaCD")

        ShowObj = New ShowObject : forShowObj.Controls.Add(ShowObj)
        ShowObj.Left = 0 : ShowObj.Top = 0
        ShowObj.Dock = DockStyle.Top
        ShowObj.border = SkinOptions("RamkaCDShowObj")
        ShowObj.colBorder = SkinColors("RamkaCDShowObj")
        'ShowObj.Anchor = AnchorStyles.Left + AnchorStyles.Top + AnchorStyles.Right
        AddHandler ShowObj.PropertyChange, AddressOf ShowObj_PropertyChange
        AddHandler ShowObj.ObjectChange, AddressOf ShowObj_ObjectChange
        AddHandler ShowObj.SizeChanged, AddressOf CreateDeistv_Resize

        'EditPr = New EditProperty :
        args.Dock = DockStyle.Top
        forEditPr.Controls.Add(args)

        'args.Dock = DockStyle.Fill
        TopLabel.Text = transInfc(TopLabel.Text)
        SetProperty()
    End Sub
    Sub ShowObj_PropertyChange(ByVal nowProp As String, ByVal propOld As String, ByVal MyObj As Object)
        If proj.isProperty(nowProp) <> "" Then
            Dim tempArgs() As String = GetArguments(nowProp, MyObj)
            If tempArgs Is Nothing = False Then
                If tempArgs(tempArgs.Length - 1) = "" Then GoTo nenadoArga
            End If
            If UCase(MainForm.Create1.Text) = UCase(trans("Изменить")) Then
                If GetTypeProperty(nowProp) = GetTypeProperty(propOld) Then Exit Sub 
                If tempArgs Is Nothing And GetArguments(propOld, MyObj) Is Nothing And args.Args Is Nothing = False Then Exit Sub
            End If
            args.ShowArgs(New String() {transInfc("на следующее значение")}, Nothing, "")
            args.borderIn = SkinOptions("RamkaCDEditPrIn")
            args.colBorder = SkinColors("RamkaCDEditPr")
            TopLabel.Text = transInfc("Изменить следующее свойство")
        Else
nenadoArga: args.ShowArgs(Nothing, Nothing, "")
            TopLabel.Text = transInfc("Выполнить следующую команду")
        End If
        ' MainForm.InfoPropsShow(nowProp, proj.GetMyAllFromName(ShowObj.objects.Text, , ShowObj.forms.Text))
        CreateDeistv_Resize(Nothing, Nothing) : Me.Refresh()
    End Sub
    Sub ShowObj_ObjectChange(ByVal nowObj As String)
        CreateDeistv_Resize(Nothing, Nothing)
        ' MainForm.InfoPropsShow(ShowObj.propertys.Text, proj.GetMyAllFromName(ShowObj.objects.Text, , ShowObj.forms.Text))
    End Sub
    Sub SetProperty(Optional ByVal reazon As Boolean = False)
        Static fl As Boolean = False
        ' Только в очень ограничеченом варианте случаев(reazon = True) перезапускать шоу объект
        If (ShowObj Is Nothing = False And fl = False) Or (reazon = True And fl = True) Then
            ShowObj.ShowObj(New MasterPattern(Nothing, "All", False)) : fl = True : Exit Sub
        End If
        ' событОбъекты должны измениться чаще - при изменения выбранного узла в разных событиях
        If ShowObj Is Nothing = False Then
            If ShowObj.Sobyt <> proj.GetSobytNameFromTreeNode Then
                ShowObj.Sobyt = proj.GetSobytNameFromTreeNode() : ShowObj.MySobyt = proj.GetSobytObj()
                ShowObj.objects_SelectedIndexChanged(MainForm, Nothing)
            End If
        End If
    End Sub
    Public Function getText() As String
        Dim text As String
        text = ShowObj.GetText
        If args.isMethodProp = False Then
            If proj.isProperty(ShowObj.GetProperty) <> "" Then
                text &= " = " & args.GetText(False)
            End If
        End If
        Return text
    End Function

    Private Sub CreateDeistv_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If border > 0 Then
            e.Graphics.DrawRectangle(New Pen(colBorder, border), New Rectangle(border / 2, border / 2, Me.Width - border, Me.Height - border))
        End If
    End Sub
    Private Sub CreateDeistv_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If ShowObj Is Nothing = False Then

            If Me.VScroll = False Then Me.AutoScroll = False

            forShowObj.Height = ShowObj.Height
            forEditPr.Height = args.Height

            Dim wids As Integer = CreateDs.Width - 8
            If Me.VScroll = True Then wids = CreateDs.Width - 8 - 20
            forShowObj.Width = wids
            forEditPr.Width = wids
            TopLabel.Width = wids

            Dim summa As Integer = TopLabel.Height + forShowObj.Height + forEditPr.Height + 10
            If summa > Me.Height Then summa = Me.Height
            'TopLabel.Top = (Me.Height - summa) / 2 + 1
            ' forShowObj.Top = TopLabel.Height + TopLabel.Top + 1
            forEditPr.Top = forShowObj.Height + forShowObj.Top + 3

            If Me.AutoScroll = False Then Me.AutoScroll = True
            'TopLabel.Width -= 1
            'CreateDeistv_SizeChanged(Nothing, Nothing)
        End If
    End Sub
  
End Class
