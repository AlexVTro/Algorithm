Public Class Bloks
    Dim blks As BlokiVRyad
    Dim neRisovat As Boolean
    'Dim OwnerScroll As Object
    Public oldHS As Integer
    Dim Pattern As MasterPattern

    Public Sub New(ByVal Pattern As Object)
        InitializeComponent()
        Me.Pattern = Pattern
        Me.ForeColor = SkinColors("MasterBloks")
        PlusLeft.BackgroundImage = SkinPictures("MasterButton")
        PlusLeft.ForeColor = SkinColors("MasterPanelLabel")
        PlusRight.BackgroundImage = SkinPictures("MasterButton")
        PlusRight.ForeColor = SkinColors("MasterPanelLabel")

        If Me.Pattern.estBls = True Then
            AddBloks()
        Else
            PlusRight_Click(Nothing, Nothing)
            If Pattern.withUslovie = True Then PlusRight_Click(Nothing, Nothing)
            Vistroit()
        End If
    End Sub
    Public Function BlksCount() As Integer
        If blks.top Is blks.Last Then Return 1 Else Return 0
    End Function
    Public Function BlkTop() As Blok
        Return blks.top
    End Function

    Private Sub Bloks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'PlusRight_Click(sender, e)
        'If Pattern.withUslovie = True Then PlusRight_Click(sender, e)
        'Vistroit()
    End Sub
    Private Sub Blok_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        neRisovat = True : Timer1.Start()
    End Sub
    Sub AddBloks()
        Dim i, j, ind, skobs As Integer
        Dim fl As Integer = 0, actStr As String
        Dim m As System.Text.RegularExpressions.Match
        If Pattern.Bloki.texty Is Nothing Then Exit Sub
        For i = 0 To Pattern.Bloki.texty.Length - 1
            Dim bl As Blok = New Blok(Pattern)
            If Pattern.Bloki.texty(i) Is Nothing Then Continue For
            ' сделать чтоб если функция или метод, то полылалась вся строка в скобках
            m = System.Text.RegularExpressions.Regex.Match(Pattern.Bloki.texty(i), "[^(]+")
            If Array.IndexOf(DopFunsSimple, UCase(m.Value)) <> -1 Then
                actStr = Trim(Pattern.Bloki.texty(i).Substring(m.Index + m.Length)) : fl = 1
            ElseIf bl.ShowObj.SetObj(m.Value) Then
                actStr = Trim(Pattern.Bloki.texty(i).Substring(m.Index + m.Length)) : fl = 1
            End If
            If fl = 1 Then
                skobs = proj.PodshetSkobok(actStr)
                For j = i + 1 To Pattern.Bloki.texty.Length - 1
                    If skobs <= 0 Then Exit For
                    skobs += proj.PodshetSkobok(Pattern.Bloki.texty(j))
                    Pattern.Bloki.texty(i) &= " " & Pattern.Bloki.splity(j - 1) & " " & Pattern.Bloki.texty(j)
                    Pattern.Bloki.texty(j) = Nothing
                Next
                If skobs > 0 Then
                    For j = 1 To skobs : Pattern.Bloki.texty(i) &= ")" : Next
                End If
                fl = 0
            End If

            bl.SetBlok(Pattern.Bloki.texty(i))
            blks.Add(bl)
            AddHandler bl.SizeChanged, AddressOf Blok_SizeChanged
            PreferenceBlok(bl) : bl.ForeColor = Me.ForeColor

            If Pattern.Bloki.splity Is Nothing = False Then
                j = i - 1
                If i >= 1 And j <= Pattern.Bloki.splity.Length - 1 Then
                    If Pattern.withUslovie = False Then
                        ind = Array.IndexOf(opers, Pattern.Bloki.splity(j))
                        If ind <> -1 Then bl.Tag(0).SelectedItem = Operations(ind)
                    Else
                        ind = Array.IndexOf(uslovs, Pattern.Bloki.splity(j))
                        If ind <> -1 Then bl.Tag(0).SelectedItem = Usloviya(ind)
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub PlusRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlusRight.Click
        'OwnerScroll.autoscroll = False
        Dim bl As Blok = New Blok(Pattern) : blks.Add(bl)
        AddHandler bl.SizeChanged, AddressOf Blok_SizeChanged
        PreferenceBlok(bl) : bl.ForeColor = Me.ForeColor
    End Sub
    Private Sub PlusLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlusLeft.Click
        'OwnerScroll.autoscroll = False
        Dim bl As Blok = New Blok(Pattern) : blks.Insert(bl, sender.tag)
        AddHandler bl.SizeChanged, AddressOf Blok_SizeChanged
        PreferenceBlok(bl) : bl.ForeColor = Me.ForeColor
    End Sub
    Sub PreferenceBlok(ByVal bl As Blok)
        neRisovat = True
        Dim attrib() As Object = {New Windows.Forms.ComboBox, New Windows.Forms.Button}
        attrib(0).MaxDropDownItems = 20
        If Pattern.withUslovie = False Then
            attrib(0).items.addrange(Operations)
        Else
            attrib(0).items.addrange(Usloviya)
        End If
        attrib(0).selectedIndex = 0 : attrib(0).DropDownStyle = 2 : ComboBoxWidth(attrib(0))
        attrib(0).Size = New Point(40, 21)
        Dim eventOb As ComboBox = attrib(0)
        AddHandler eventOb.SelectedIndexChanged, AddressOf SelIndChange
        attrib(1).Size = PlusLeft.Size : attrib(1).Text = PlusLeft.Text : attrib(1).forecolor = PlusLeft.ForeColor

        Dim eventObj As Control = attrib(1)
        AddHandler eventObj.Click, AddressOf PlusLeft_Click
        eventObj.BackgroundImage = SkinPictures("MasterButton")
        eventObj.ForeColor = SkinColors("MasterPanelLabel")
        bl.Tag = attrib : attrib(1).tag = bl

        bl.Top = 3 : Me.Controls.Add(bl)
        AddHandler bl.Skobki, AddressOf Razrisovat
        AddHandler bl.Remove, AddressOf RemoveBlok
        Me.Controls.Add(attrib(0)) : Me.Controls.Add(attrib(1))
        Vistroit()
    End Sub
    Sub SelIndChange(ByVal sender As Object, ByVal e As EventArgs)
        '    Dim sel As String = sender.SelectedItem
        '     Dim konec As Integer = sel.IndexOf(" ")
        '      If konec = -1 Then konec = sel.Length
        '       sender.Width = 26 + sel.Substring(0, konec).Length * LiterWidth
    End Sub
    Sub Vistroit(Optional ByVal onlyScroll As Boolean = False)
        If onlyScroll = False Then
            Dim top As Blok = blks.top
            'OwnerScroll.autoscroll = False
            top.Left = PlusLeft.Left + PlusLeft.Width + 6
            top.Tag(0).visible = False : top.Tag(1).visible = False
            Do Until top.rLink Is Nothing
                top = top.rLink
                Dim ii As Integer = top.lLink.Left + top.lLink.Width + top.Tag(0).Width + 6
                If ii <> top.Left Then
                    top.Left = ii
                    top.Tag(0).left = top.Left - top.Tag(0).Width - 3
                    top.Tag(0).top = (PlusLeft.Top + PlusLeft.Height / 2) - top.Tag(0).height
                    top.Tag(1).left = top.Left - top.Tag(1).Width - (top.Tag(0).Width - top.Tag(1).Width) / 2 - 3
                    top.Tag(1).top = top.Tag(0).Top + top.Tag(1).height
                End If
                top.Tag(0).visible = True : top.Tag(1).visible = True
            Loop
            PlusLeft.Top = 80 / 2 - PlusLeft.Height / 2 : PlusRight.Top = PlusLeft.Top
            PlusRight.Left = top.Left + top.Width + 3
        End If
        Razrisovat()
    End Sub
    Sub Razrisovat()
        Dim temp As Blok, uroven = 1, max = 1, i, shag As Integer
        temp = blks.top
        Do Until temp Is Nothing
            uroven += temp.OpenSkobok
            If uroven > max Then max = uroven
            uroven -= temp.CloseSkobok
            temp = temp.rLink
        Loop
        If uroven <> 1 Then Exit Sub
        shag = (AlphaPik - AlphaNiz) \ max
        For i = 1 To max
            temp = blks.top : uroven = 1
            Do Until temp Is Nothing
                uroven += temp.OpenSkobok
                If uroven = i Then temp.Alpha = AlphaNiz + shag * (i - 1)
                uroven -= temp.CloseSkobok
                temp = temp.rLink
            Loop
        Next : Timer1.Start() ': Timer2.Start()
    End Sub
    Private Sub Bloks_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim temp As Blok = blks.top, rect As Rectangle, dopL, dopR As Integer
        If neRisovat = False Then
            Do Until temp Is Nothing
                If temp Is blks.top And temp Is blks.Last Then
                    dopL = 99 : dopR = 99
                ElseIf temp Is blks.top Then
                    dopL = 99 : dopR = dopL / 2 + (temp.Tag(0).width + 6) / 4
                ElseIf temp Is blks.Last Then
                    dopR = 99 : dopL = (temp.Tag(0).width + 6) / 2
                Else
                    dopL = (temp.Tag(0).width + 6) / 2 : dopR = dopL
                End If
                rect = New Rectangle(temp.Left - dopL, temp.Top - 300, temp.Width + dopR * 2, temp.Height + 300 * 2)
                e.Graphics.FillRectangle(New Pen(Color.FromArgb(temp.Alpha, SkinColors("MasterRazrisovat"))).Brush, rect)
                temp = temp.rLink
            Loop
        End If
    End Sub
    Public Sub RemoveBlok(ByVal sender As Blok, ByVal escape As Boolean)
        If escape And blks.Last Is blks.top Then Me.TopLevelControl.Hide() : Exit Sub
        If sender Is Nothing Then Exit Sub
        neRisovat = True
        blks.Remove(sender) : Me.Parent.Parent.Width -= 1 : Vistroit()
    End Sub
    Function GetText() As String
        Dim temp As Blok = blks.top, str As String = ""
        Do Until temp Is Nothing
            str &= temp.GetText
            temp = temp.rLink
            If temp Is Nothing = False Then str &= " " & temp.GetOperation() & " "
        Loop
        Return str
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        neRisovat = False : Me.Invalidate() : Timer1.Stop()
    End Sub

    Private Sub PlusRight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PlusRight.KeyDown
        If e.KeyData = Keys.Escape Then RemoveBlok(blks.Last, True)
    End Sub
End Class
