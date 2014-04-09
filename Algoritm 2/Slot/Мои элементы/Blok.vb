Public Class Blok
    Public WithEvents ShowObj As ShowObject
    Dim EditPr As EditProperty
    Public lLink, rLink As Blok
    Public alf As Integer = 0
    Public Event Skobki()
    Public Event Remove(ByVal sender As Blok, ByVal escape As Boolean)
    Dim Pattern As MasterPattern
    Public Ramka As Integer = 0

    Public Sub New(ByVal Pattern As Object, Optional ByVal vHolostuyu As Boolean = False)
        If vHolostuyu Then Exit Sub
        InitializeComponent()
        Me.Pattern = Pattern
        ShowObj = New ShowObject : forShowObj.Controls.Add(ShowObj) : ShowObj.Name = "ShowObj"
        AddHandler ShowObj.SizeChanged, AddressOf Blok_SizeChanged
        AddHandler ShowObj.PropertyChange, AddressOf ShowObj_PropertyChange

        EditPr = New EditProperty() : forEditPr.Controls.Add(EditPr)
        EditPr.Dock = DockStyle.Fill
        EditPrLabel.Text = transInfc(EditPrLabel.Text)
        ShowObj.ShowObj(Pattern) : EditPr.ShowProp("", proj.SobytMyObjs)
        TudaSuda1.Top = forShowObj.Top + forShowObj.Height

        DopFunctions.Items.AddRange(DopFuns) : DopFunctions.SelectedIndex = 0
        DopFunctions.ForeColor = ColFunction : DopFunctionsLabel.Text = transInfc(DopFunctionsLabel.Text)

        Ramka = SkinOptions("RamkaBloks")
        ComboBoxWidth(DopFunctions)

        Remove1.BackgroundImage = SkinPictures("MasterButton")
        Remove1.ForeColor = SkinColors("MasterPanelLabel")

        Palka1.RefreshPic(SkinPictures)
        TudaSuda1.RefreshPic(SkinPictures)
        ' чтобы кнопочка тудасюда приняла нужный У, а то шоу объект долго свой хайт не выдает
        Timer1.Start()
    End Sub
    Sub ShowObj_PropertyChange(ByVal nowProp As String, ByVal typeChanged As String, ByVal MyObj As Object)
        MainForm.InfoPropsShow(nowProp, proj.GetMyAllFromName(ShowObj.objects.Text, , ShowObj.forms.Text))
    End Sub
    Sub SetBlok(ByVal text As String)
        Dim i, fl As Integer
        Dim indStr As Integer = 0
        Dim actStr As String = text
        Dim chr As Char = ""
        Dim inShowObj As Boolean
        Dim m As System.Text.RegularExpressions.Match = Nothing

        If text.Length > 1 Then
            If (text.Chars(0) = "(" Or text.Chars(text.Length - 1) = ")") Then
                m = System.Text.RegularExpressions.Regex.Match(text, "[^(]+") : indStr += m.Index
                m = System.Text.RegularExpressions.Regex.Match(m.Value, "[^)]+") : indStr += m.Index
                actStr = Trim(m.Value)
            End If
        End If
        ' m = System.Text.RegularExpressions.Regex.Match(actStr, "[^(]+")
        inShowObj = ShowObj.SetObj(actStr)
        If text.Length > actStr.Length + indStr Then chr = text.Chars(actStr.Length + indStr)
        If Array.IndexOf(DopFunsSimple, UCase(actStr)) <> -1 Then
            DopFunctions.SelectedItem = DopFuns(Array.IndexOf(DopFunsSimple, UCase(actStr)) + 1)
            fl = 1
        ElseIf inShowObj And chr = "(" Then
            fl = 1
        Else
            If m Is Nothing Then
                OpenCombo.Text = "" : CloseCombo.Text = ""
            ElseIf text.Length > 1 Then
                OpenCombo.Text = Trim(text.Substring(0, indStr))
                Dim ind As Integer = indStr + actStr.Length - 1
                If ind < 0 Then ind = 0
                CloseCombo.Text = Trim(text.Substring(ind))
            End If
        End If
        If fl = 1 Then
            actStr = Trim(text.Substring(indStr + actStr.Length))
vnutr:      OpenCombo.Text = Trim(text.Substring(0, indStr))
            If actStr.Length > 1 Then
                If actStr.Chars(0) = "(" Then
                    Dim skobok As Integer = 1
                    i = 0
                    While skobok > 0
                        i += 1 : If i > actStr.Length - 1 Then Exit While
                        If actStr.Chars(i) = "(" Then skobok += 1
                        If actStr.Chars(i) = ")" Then skobok -= 1
                    End While
                    If CloseCombo.Text = "" Then CloseCombo.Text = Trim(actStr.Substring(i + 1))
                    actStr = actStr.Substring(1, i - 1)
                End If
            End If
            If inShowObj = False Then
                m = System.Text.RegularExpressions.Regex.Match(actStr, "[^(]+")
                inShowObj = ShowObj.SetObj(m.Value)
                If inShowObj = True Then
                    actStr = Trim(actStr.Substring(m.Index + m.Length))
                    GoTo vnutr
                End If
            End If

            If inShowObj = True Then
                Dim temp() As String = New CodeString(actStr, "None").Split("naOdnomUrovne", ",").texty
                If ShowObj.args.Args Is Nothing = False Then
                    For i = 0 To ShowObj.args.Args.Length - 1
                        If i <= temp.Length - 1 Then ShowObj.args.Args(i).Text = temp(i)
                    Next
                End If
            End If
        End If
        If inShowObj = True Then
            Timer1.Start() : TudaSuda1.Type = "Up"
        Else
            EditPr.Text = actStr : TudaSuda1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub Combo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenCombo.TextChanged, CloseCombo.TextChanged
        Dim lab As Windows.Forms.Label
        If sender Is OpenCombo Then lab = OpenLabel Else lab = CloseLabel
        If NikakoiEsli(sender.Text) = trans("Никакой") Then
            lab.Text = lab.Tag
        Else
            Dim text As String = System.Text.RegularExpressions.Regex.Replace(sender.Text, "[^\" & sender.tag & "]", "")
            If sender.Text <> text Then
                Dim start As Integer = sender.SelectionStart
                sender.Text = text : sender.SelectionStart = start
            End If
            If sender.Text.Length > 0 Then lab.Text = sender.Text.Length Else lab.Text = ""
        End If
        RaiseEvent Skobki()
    End Sub
    Public Sub TudaSuda1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TudaSuda1.click
        If forShowObj.Visible = True Then
            TudaSuda1.Top = forEditPr.Top + forEditPr.Height + 3 : TudaSuda1.Type = "Down"
            forShowObj.Visible = False : forEditPr.Visible = True : EditPrLabel.Visible = True : Palka1.Visible = True
        Else
            TudaSuda1.Top = forShowObj.Top + forShowObj.Height : TudaSuda1.Type = "Up"
            forShowObj.Visible = True : forEditPr.Visible = False : EditPrLabel.Visible = False : Palka1.Visible = False
        End If
        Dim ob As Bloks = Me.Parent
        If ob Is Nothing = False Then ob.Vistroit(True)
    End Sub
    Public ReadOnly Property OpenSkobok()
        Get
            Return OpenCombo.Text.Length
        End Get
    End Property
    Public ReadOnly Property CloseSkobok()
        Get
            Return CloseCombo.Text.Length
        End Get
    End Property
    Function GetText()
        Dim str As String = "", dop As String = ""
        If forShowObj.Visible = True Then
            str = ShowObj.GetText
        Else
            str = EditPr.Text
            If bistro_orfo = False Then str = New CodeString(EditPr.Text).Text
        End If
        dop = DopFunctions.SelectedItem
        If UCase(dop) <> UCase(trans("Нет")) Then
            If dop.IndexOf(" (") <> -1 Then dop = dop.Substring(0, dop.IndexOf(" ("))
            str = dop & "(" & str & ")"
        End If
        str = Me.OpenCombo.Text & str & Me.CloseCombo.Text
        Return str
    End Function
    Function GetOperation()
        If Pattern.withUslovie = False Then
            Return opers(Me.Tag(0).SelectedIndex)
        Else
            Return uslovs(Me.Tag(0).SelectedIndex)
        End If
        '      Dim str As String = Me.Tag(0).SelectedItem
        '       If str.IndexOf(" (") <> -1 Then str = str.Substring(0, str.IndexOf(" ("))
        '        Return Trim(str)
    End Function
    Property Alpha()
        Get
            Return alf
        End Get
        Set(ByVal value)
            alf = value
        End Set
    End Property
    Public Sub Remove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remove1.Click
        RaiseEvent Remove(Me, (sender Is Nothing))
    End Sub
    Private Sub Blok_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If Ramka > 0 Then
            Dim col As Color = SkinColors("RamkaBloks")
            e.Graphics.DrawRectangle(New Pen(col, Ramka), New Rectangle(Ramka / 2, Ramka / 2, Me.Width - Ramka, Me.Height - Ramka))
        End If
    End Sub
    Private Sub Blok_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If forShowObj.Visible = False Then
            TudaSuda1.Top = forEditPr.Top + forEditPr.Height + 3
        Else
            TudaSuda1.Top = forShowObj.Top + forShowObj.Height
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Blok_SizeChanged(Nothing, Nothing) : Timer1.Stop()
    End Sub

    Private Sub Palka1_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Palka1.click
        Dim master As New Master(New MasterPattern(EditPr))
        master.TopMost = True
        master.Show() 'Dialog(Me.TopLevelControl)
    End Sub

End Class
