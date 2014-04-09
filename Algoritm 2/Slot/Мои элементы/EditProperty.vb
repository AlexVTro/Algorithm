Public Class EditProperty
    Public ActiveTextBox As RichTextBox
    Public MyObjs() As Object ' ��� ��������  ��������
    Public MayChangeProperty As Boolean ' ���������� �������� �� ������� ��������
    Dim WithEvents tagBox As RichTextBox
    Public WithEvents List As ListBox
    Dim defH, defW, defX, defY, markers_perenos As Integer
    Dim Undo(), Redo(), sledush As String
    Dim isUndo, isRedo As Boolean
    Dim markers(4) As PictureBox, closeBut, defBut As Windows.Forms.Button
    Public type, prop As String ' ��� �������� �������� � ���� ��������
    Dim bezRazshirPole As Boolean
    Public bezPodsvetki As Boolean = False
    Public Event SelectedText(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    Public Sub New()
        InitializeComponent()
        List = New ListBox()
    End Sub
    Public Sub New(ByVal bezRazshirPole As Boolean, Optional ByVal bezPodsvetki As Boolean = False)
        Me.new()
        Me.bezRazshirPole = bezRazshirPole
        Me.bezPodsvetki = bezPodsvetki
    End Sub

    ' <<<<<< ������� ��������, ����������� �� ���� ��������  >>>>>>>>>
#Region "INPUT OBJS SOBYTS"
    Dim timer As New Windows.Forms.Timer()

    ' �������� ���� ��������
    Private Sub EditProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        TextBox1.ContextMenuStrip = MainForm.EditPrMenu
        TextBox2.ContextMenuStrip = MainForm.EditPrMenu
        TextBox3.ContextMenuStrip = MainForm.EditPrMenu

        TextBox1.BackColor = SkinColors("MainText")
        TextBox2.BackColor = SkinColors("MainText")
        TextBox3.BackColor = SkinColors("MainText")

        MainForm.EditPrCreateMenu(Me)

        EditText.BringToFront()
        If bezRazshirPole = False Then
            ' �������� ������������ ���� (����� ������, �.�. ��� ����� ��������� �� ��� ��������� �����)
            timer.Interval = 1 : AddHandler timer.Tick, AddressOf CreateRasshirPole : timer.Start()
            ShowHideBut.Visible = True : ShowHideBut.BringToFront()
        Else
            TextBox1.Multiline = True : TextBox1.ScrollBars = RichTextBoxScrollBars.Vertical
            TextBox1.Dock = DockStyle.Fill
            ShowHideBut.Visible = False
        End If
    End Sub

    ' ����� ������ �� ������ ��������������� �����
    Public Sub HW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rich As RichTextBox = MainForm.EditPrMenu.Tag
        rich.SelectedText = sender.text
        TextBox_KeyUp(rich, New KeyEventArgs(Nothing)) ' ���������� ���������
    End Sub

    ' �������� �������� �� ����� ��� ����������
    Sub CreateRasshirPole(ByVal sender As System.Object, ByVal e As System.EventArgs)
        timer.Stop()
        ' ������� TagBox
        tagBox = New RichTextBox() : tagBox.Multiline = True : tagBox.Visible = False
        tagBox.ContextMenuStrip = MainForm.EditPrMenu
        tagBox.EnableAutoDragDrop = True
        ' ������� � ��������� �������
        Dim i As Integer
        For i = 0 To markers.Length - 1
            markers(i) = New PictureBox()
            markers(i).Width = markerX : markers(i).Height = markerY : markers(i).Visible = False
            markers(i).BackColor = Color.White : markers(i).BorderStyle = BorderStyle.FixedSingle
            AddHandler markers(i).MouseDown, AddressOf markers_MouseDown
            AddHandler markers(i).MouseUp, AddressOf markers_MouseUp
            AddHandler markers(i).MouseMove, AddressOf markers_MouseMove
        Next
        markers(0).Cursor = Cursors.SizeWE : markers(2).Cursor = Cursors.SizeNESW
        markers(1).Cursor = Cursors.SizeWE : markers(3).Cursor = Cursors.SizeNS
        markers(4).Cursor = Cursors.SizeNWSE
        ' ������� ������
        closeBut = New Windows.Forms.Button : closeBut.Text = "X"
        closeBut.UseVisualStyleBackColor = True
        closeBut.Width = markerX * 2.1 : closeBut.Height = markerY * 2.2
        closeBut.Font = New Font("Arial", 4) : closeBut.Visible = False
        AddHandler closeBut.Click, AddressOf CloseButt_Click
        ' ������� ������
        defBut = New Windows.Forms.Button : defBut.Text = "O"
        defBut.UseVisualStyleBackColor = True
        defBut.Width = markerX * 2.1 : defBut.Height = markerY * 2.2
        defBut.Font = New Font("Arial", 4) : defBut.Visible = False
        AddHandler defBut.Click, AddressOf DefButt_Click
        ' ���������� ��� �� �����
        If Me.TopLevelControl Is Nothing = False Then
            Me.TopLevelControl.Controls.Add(tagBox)
            Me.TopLevelControl.Controls.Add(closeBut)
            Me.TopLevelControl.Controls.Add(defBut)
            Me.TopLevelControl.Controls.AddRange(markers)
        End If
        markers_perenos = -1
    End Sub
    Private Sub markers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        markers_perenos = Array.IndexOf(markers, sender) ' ������ �������� �������
        If markers_perenos = -1 Then Exit Sub
        tagBoxVisible(True, False, False) ' ������ ��� �������
    End Sub
    Private Sub markers_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If markers_perenos <> -1 Then
            Dim cx, cy As Integer
            markers(markers_perenos).Left = markers(markers_perenos).Left + e.X
            markers(markers_perenos).Top = markers(markers_perenos).Top + e.Y
            cx = markers(markers_perenos).Left
            cy = markers(markers_perenos).Top
            Select Case markers_perenos
                Case 0 ' ����� ������� ������
                    tagBox.Width = (tagBox.Left - cx) + tagBox.Width - markers(markers_perenos).Width
                    tagBox.Left = cx + markers(markers_perenos).Width
                Case 1 ' ������ ������� ������
                    tagBox.Width = cx - tagBox.Left
                Case 2 ' ����� ������ ������
                    tagBox.Width = (tagBox.Left - cx) + tagBox.Width - markers(markers_perenos).Width
                    tagBox.Height = cy - tagBox.Top
                    tagBox.Left = cx + markers(markers_perenos).Width
                Case 3
                    tagBox.Height = cy - tagBox.Top
                Case 4
                    tagBox.Width = cx - tagBox.Left
                    tagBox.Height = cy - tagBox.Top
            End Select
        End If
    End Sub
    Private Sub markers_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        tagBoxVisible(True, True, True) ' ������� ������� ��������
        markers_perenos = -1
    End Sub
    Private Sub CloseButt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Timer1_Tick(Nothing, Nothing)
        ActiveTextBox.Focus() : tagBoxVisible(False, False, False)
    End Sub
    Private Sub DefButt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        tagBox.Width = defW : tagBox.Height = defH : tagBox.Left = defX : tagBox.Top = defY
        tagBoxVisible(True, True, True) : tagBox.Focus()
    End Sub

    ' ��������� ������� � ��������� ��������
    Private Sub TextBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click, TextBox2.Click, TextBox3.Click
        Dim charWidth As Double = 7.3
        If bezRazshirPole Then Exit Sub
        If tagBox Is Nothing Then CreateRasshirPole(sender, e)
        Dim minW, minH, maxW, maxH, sredW, sredH, x, y As Integer, nadoMenyat As Boolean
        Dim pogrX, pogrY As Integer, frm As Form = tagBox.TopLevelControl
        If frm Is Nothing Then frm = Me.TopLevelControl
        pogrX = frm.Width - frm.DisplayRectangle.Width
        pogrY = frm.Height - frm.DisplayRectangle.Height
        ' C ������ ����� ������� ������
        Dim le As Integer = MaxLenLine(tagBox) * charWidth - sender.width
        If le < 0 Then le = 0
        x = sender.PointToScreen(New Point(0, 0)).x - frm.Left - pogrX - le
        y = sender.PointToScreen(New Point(0, 0)).y - frm.Top - pogrY + sender.height + 8
        If defY <> y Or defX <> x Then nadoMenyat = True
        If x < 15 Then le = le - x - 15 : x = 15
        tagBox.Left = x : tagBox.Top = y
        minW = sender.width : minH = sender.height * 2
        maxW = frm.Width - tagBox.Left - pogrX - 12 : maxH = frm.Height - tagBox.Top - pogrY - 12
        sredW = frm.Width - x - 45
        sredH = (MaxLineCount(tagBox) + 2) * sender.Font.Height + 10 '(minH + maxH) / 2
        If minW < 60 Then
            minW = 60
        End If
        'If sredW < minW * 2 Then
        '    If minW * 2 > maxW Then
        '        sredW = maxW
        '    Else
        '        sredW = minW * 2
        '    End If
        '    ElseIf sredW > frm.DisplayRectangle.Width - 100 Then
        '        sredW = frm.DisplayRectangle.Width - 100
        'End If
        'If sredH < minH * 2 Then
        '    If minH * 3 > maxH Then
        '        sredH = maxH
        '    Else
        '        sredH = minH * 3
        '    End If
        If sredH > maxH Then
            sredH = maxH
        End If
        'If nadoMenyat Then
        tagBox.Width = sredW : tagBox.Height = sredH : defW = sredW : defH = sredH : defX = x : defY = y
        'End If
        If List Is Nothing = False And List.Visible = True Then List.Visible = False
        'perevesti(ActiveTextBox, tagBox, Chr(182), vbCrLf.Substring(1))
        'tagBoxVisible(True, True, True) : ActiveTextBox.Focus()
    End Sub
    Function MaxLenLine(ByVal sender As RichTextBox)
        Dim i, max As Integer
        Dim rt As New RichTextBox()
        rt.Text = perevesti(sender.Text, True)
        For i = 0 To rt.Lines.Length - 1
            If rt.Lines(i).Length > max Then max = rt.Lines(i).Length
        Next
        Return max
    End Function
    Function MaxLineCount(ByVal sender As RichTextBox)
        Dim i, max As Integer
        Dim rt As New RichTextBox()
        rt.Text = perevesti(sender.Text, True)
        Return rt.Lines.Length
    End Function
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus
        MainForm.EditPrMenu.Tag = sender
        TextBox_Click(sender, e)
    End Sub
    ' �������� � ���������� ������� � ��� ���������
    Sub tagBoxVisible(ByVal visTagB As Boolean, ByVal visMar As Boolean, ByVal visButt As Boolean)
        ' ��������� ��������
        If visMar = True Then
            markers(0).Left = tagBox.Left - markerX
            markers(0).Top = tagBox.Top + (tagBox.Height - markerY) / 2
            markers(2).Left = tagBox.Left - markerX
            markers(2).Top = tagBox.Top + tagBox.Height
            markers(1).Left = tagBox.Left + tagBox.Width
            markers(1).Top = tagBox.Top + (tagBox.Height - markerY) / 2
            markers(3).Left = tagBox.Left + (tagBox.Width - markerX) / 2
            markers(3).Top = tagBox.Top + tagBox.Height
            markers(4).Left = tagBox.Left + tagBox.Width
            markers(4).Top = tagBox.Top + tagBox.Height
        End If
        Dim i As Integer
        For i = 0 To markers.Length - 1 : markers(i).BringToFront() : markers(i).Visible = visMar : Next
        ' ��������� ������
        If visButt = True Then
            closeBut.Left = tagBox.Left - closeBut.Width
            closeBut.Top = tagBox.Top
            defBut.Left = closeBut.Left
            defBut.Top = closeBut.Top + closeBut.Height + 1
            closeBut.BringToFront() : defBut.BringToFront()
        End If
        closeBut.Visible = visButt : defBut.Visible = visButt
        ' ��������� ��������
        tagBox.Visible = visTagB : tagBox.BringToFront()
        If List Is Nothing = False Then List.Visible = False
    End Sub

    Dim idetKeyDown As Boolean = False
    ' ��������� ���������� ��������
    Private Sub TextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown, TextBox3.KeyDown
        idetKeyDown = True
        If bezRazshirPole Then
            If e.KeyData = Keys.Enter Then

                ' ���� ��� ��������� ���� �� MainForm
                If Me.Tag Is Nothing = False Then
                    If Me.Name = "EditNodeText" Then
                        Me.Tag.Apply_Click(Nothing, Nothing) : e.Handled = True
                    ElseIf Me.Name = "FindText" Then
                        Me.Tag.FindButton_Click(Nothing, Nothing) : e.Handled = True
                    End If
                End If

            End If
            idetKeyDown = False
            Exit Sub
        End If
        ' ���������� ��� �� ����� ����� � ������� ��� �� ������
        If e.KeyCode <> Keys.ShiftKey And e.KeyCode <> Keys.ControlKey And e.KeyCode <> Keys.Menu And e.KeyCode <> Keys.Left And e.KeyCode <> Keys.Right And e.KeyCode <> Keys.Up And e.KeyCode <> Keys.Down Then
            Timer1.Start() '(Nothing, Nothing)
        End If

        If e.KeyData = Keys.Enter + Keys.Control Or e.KeyData = Keys.Down Then
            tagBox.Tag = "obrabotka"
            tagBoxVisible(True, True, True)
            Timer1_Tick(Nothing, Nothing)
            tagBox.Focus()
            tagBox.Tag = ""
        ElseIf e.KeyData = Keys.Enter Then
            If MayChangeProperty = True Then ' ���� ����� �������� �������� �������� ���� ������
                Dim gladko As Boolean = proj.ActiveForm.SetPropertys(prop, sender.text, MyObjs)
                If gladko = True Then Me.Parent.Focus()
                tagBoxVisible(False, False, False)
            Else
                If Me.TopLevelControl Is MainForm Then
                    MainForm.Create1_Click(Nothing, Nothing) : e.Handled = True
                Else
                    Dim masterForm As Master = Me.TopLevelControl
                    masterForm.Ok_Click(Nothing, Nothing)
                End If

                '                If tagBox.Visible = False Then
                'tagBoxVisible(True, True, True) : tagBox.Focus()
                'Else
                'tagBoxVisible(False, False, False)
                ' End If
            End If
        ElseIf e.KeyData = Keys.Escape Then
            If MayChangeProperty = True Then ' ���� ����� �������� �������� �������� ���� ������
                MayChangeProperty = False ' �������, ����� �� ��������� ���������� �������� � LostFocus'e
                Me.Parent.Focus()
                MayChangeProperty = True ' ������� ������� �������� 
                tagBoxVisible(False, False, False)
            ElseIf tagBox.Visible = True Then
                tagBoxVisible(False, False, False)
            Else
                Dim masterForm As New Master(Nothing, True)
                If Me.TopLevelControl.GetType Is masterForm.GetType Then
                    Dim bl As New Blok(Nothing, True), obj As Object = Me.Parent
                    While obj Is Nothing = False
                        If obj.GetType Is bl.GetType Then obj.Remove1_Click(Nothing, Nothing)
                        obj = obj.parent
                    End While
                End If
            End If
        ElseIf (e.KeyData = Keys.Left And MayChangeProperty _
        And ActiveTextBox.GetPositionFromCharIndex(ActiveTextBox.SelectionStart).X = 0) Then
            If Array.IndexOf(ReadOnlyProps, UCase(prop)) = -1 Then TextBox_KeyDown(sender, New KeyEventArgs(Keys.Enter))
            Me.Parent.Focus()
        End If
        idetKeyDown = False
    End Sub
    ' ��������� ���������� ��������
    Private Sub TagBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tagBox.KeyDown
        If bezRazshirPole Then Exit Sub


        If (e.KeyData = Keys.Enter + Keys.Control Or e.KeyData = Keys.Escape) _
        Or (e.KeyData = Keys.Up And _
        tagBox.GetPositionFromCharIndex(tagBox.SelectionStart).Y = 1) Then
            CloseButt_Click(Nothing, Nothing)
        End If
    End Sub

    ' �� ��������� ������� ����� ���� ��� �������� �����
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress, tagBox.KeyPress
        If UCase(prop) = UCase(trans("�����")) Then
            If Iz.isDouble(e.KeyChar) = False And e.KeyChar <> "," Then e.Handled = True Else Exit Sub
        End If
        If type = trans("�����") And MayChangeProperty = True Then
            If Iz.isDouble(e.KeyChar) = False And e.KeyChar <> "-" Then e.Handled = True
        End If
    End Sub
    ' � ����������� �� ���� �������� ����������� ������������
    Private Sub TextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp, TextBox2.KeyUp, TextBox3.KeyUp, tagBox.KeyUp
        Dim type As String
        If MyObjs Is Nothing Then
            type = trans("�����") ' ��� ��������
        Else
            type = GetTypeProperty(prop) ' ��� ��������
        End If
        If type = trans("����") Then
            If FromMyColor(sender.Text) <> Nothing Then
                PictureBox1.Image = Nothing : PictureBox1.BackColor = FromMyColor(sender.Text)
            End If
        ElseIf type = trans("�������") Then
            Dim file As String = UbratKovich(GetMaxPath(UbratKovich(sender.Text).str)).str
            Try : If IO.File.Exists(file) Then PictureBox1.Image = Image.FromFile(file)
            Catch ex As Exception : Errors.MessangeCritic(ex.Message) : End Try
        End If
        ' ���� ���� ������ �������� ������ � �� ����, �� ��������� � ���������� ��������� ����� 300 ��
        If e.Modifiers = 0 Then
            ' ������ ��� �� �������� ��� ��� ��� ������ ��� �������� ���� ������ -> �������
            'If e.KeyData = Keys.Delete Then
            '    If Me.TopLevelControl Is MainForm Then
            '        If sender.SelectionLength = 0 And TextBox1.SelectionStart < TextBox1.TextLength Then
            '            sender.SelectionLength = 1
            '        End If
            '        sender.SelectedText = ""
            '    End If
            'End If
            Timer1.Stop() : Timer1.Start()
            If sender.SelectedText <> "" Then RaiseEvent SelectedText(sender, Nothing)
            If sender Is tagBox Then TextBox_Click(ActiveTextBox, e) : tagBoxVisible(True, True, True)
        End If
    End Sub
    ' ��� ������ ���� ������� �������� �������
    Private Sub TextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, tagBox.LostFocus
        If bezRazshirPole Or tagBox Is Nothing Or ActiveTextBox Is Nothing Then Exit Sub
        If ActiveTextBox.Focused = False And tagBox.Focused = False And tagBox.Tag <> "obrabotka" _
        And closeBut.Focused = False And defBut.Focused = False And ShowHideBut.Focused = False Then
            tagBoxVisible(False, False, False)
        End If
        ' ���������� �������� ��� ������ ������ � ���� ����� ��������
        If MayChangeProperty And ShowHideBut.Focused = False And tagBox.Focused = False Then
            ' ����������� ������, ����� �������� ����������� ������ ��� ������� msgbox
            If idetKeyDown = False Then
                If MainForm.ListView.Items.Count > 0 And Array.IndexOf(ReadOnlyProps, UCase(prop)) = -1 Then
                    If sender Is tagBox = False Then
                        TextBox_KeyDown(sender, New KeyEventArgs(Keys.Enter))
                    ElseIf sender Is tagBox And ActiveTextBox.Focused = False Then
                        TextBox_KeyDown(sender, New KeyEventArgs(Keys.Enter))
                    End If
                End If
            End If
        End If
    End Sub
    ' ��������� ����� � ������� � �������, ����� ���� ��������� �����, ���� �����
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        If tagBox Is Nothing Then
            If MayChangeProperty = False And bezPodsvetki = False Then proj.Podsvetka(ActiveTextBox)
        Else
            If tagBox.Focused = False Then
                If MayChangeProperty = False And bezPodsvetki = False Then proj.Podsvetka(ActiveTextBox)
                If tagBox.Visible = True Then
                    perevesti(ActiveTextBox, tagBox, New String() {Chr(182), Chr(183)}, vbCrLf.Substring(1))
                    tagBox.SelectionStart = ActiveTextBox.SelectionStart
                    TextBox_Click(ActiveTextBox, Nothing) : tagBoxVisible(True, True, True)
                End If
            Else
                If MayChangeProperty = False And bezPodsvetki = False Then proj.Podsvetka(tagBox)
                perevesti(tagBox, ActiveTextBox, New String() {vbCrLf.Substring(1)}, Chr(182))
                ActiveTextBox.SelectionStart = tagBox.SelectionStart
            End If
        End If
    End Sub

    ' ���������� ���� ������ �����
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = trans("��� �����") & "|*.*" & "|" & _
            trans("��� �������") & " (jpg, jpeg, gif, bmp, ico, wmf, png)" & _
            "|*.jpg; *.jpeg; *.gif; *.bmp; *.ico; *.wmf; *.png" & "|" & _
            trans("��� ����������") & " (mp3, mp4, ogg, wma, wav, mid)" & _
            "|*.mp3; *.mp4; *.ogg; *.wma; *.wav; *.mid" & "|" & _
            trans("��� ����������") & " (avi, wmv, mpg, mpeg, flv, mov, vob, mkv, divx)" & _
            "|*.avi; *.wmv; *.mpg; *.mpeg; *.flv; *.mov; *.vob; *.mkv; *.divx"

        If IO.File.Exists(UbratKovich(TextBox2.Text).str) Then
            OpenFileDialog1.FileName = UbratKovich(TextBox2.Text).str
        End If
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = GetMinPath(OpenFileDialog1.FileName)
            If MayChangeProperty Then
                TextBox_KeyDown(TextBox2, New KeyEventArgs(Keys.Enter))
                TextBox_KeyUp(TextBox2, New KeyEventArgs(Keys.Enter))
            Else
                TextBox2.Text = """" & TextBox2.Text & """"
                TextBox_KeyUp(TextBox2, New KeyEventArgs(Keys.Enter))
            End If
        End If
    End Sub
    ' ���������� ���� ������ �����
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = ToMyColor(ColorDialog1.Color)
            TextBox_KeyDown(TextBox2, New KeyEventArgs(Keys.Enter))
            TextBox_KeyUp(TextBox2, New KeyEventArgs(Keys.Enter))
        End If
    End Sub
    ' ���������� ������ �����
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If List.Parent Is Nothing Then Me.TopLevelControl.Controls.Add(List) : List.Visible = False
        If List.Visible = False Then
            List.Location = Me.TopLevelControl.PointToClient(Me.PointToScreen(New Point(0, Button3.Top + Button3.Height)))
            List.Visible = True : List.Focus() : List.BringToFront()
        Else
            List.Visible = False
        End If
    End Sub
    ' ������� � ��������� ��������, ��������� �� ������
    Private Sub List_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List.DoubleClick
        TextBox3.Text = List.SelectedItem : TextBox3.Focus() : List.Visible = False
        If MayChangeProperty Then TextBox_KeyDown(sender, New KeyEventArgs(Keys.Enter))
        Timer1_Tick(Nothing, Nothing)
    End Sub
    Private Sub List_KeDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles List.KeyDown
        If e.KeyCode = Keys.Enter Then List_DoubleClick(sender, Nothing)
        If e.KeyCode = Keys.Escape Then List_LostFocus(sender, Nothing) : Me.Focus()
    End Sub
    Private Sub List_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles List.LostFocus
        List.Visible = False
    End Sub

    Private Sub ShowHideBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHideBut.Click
        If tagBox Is Nothing Then Exit Sub
        If tagBox.Visible = False Then
            TextBox_Click(ActiveTextBox, Nothing)
            TextBox_KeyDown(ActiveTextBox, New KeyEventArgs(Keys.Control + Keys.Enter))
        Else
            CloseButt_Click(ActiveTextBox, Nothing)
        End If
    End Sub

    Private Sub List_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles List.SelectedIndexChanged
        If UCase(type) = UCase(trans("�����")) Then
            Try
                ActiveTextBox.Font = New Font(List.SelectedItem.ToString, ActiveTextBox.Font.Size, MyObjs(0).obj.Font.Style, ActiveTextBox.Font.Unit)
            Catch ex As Exception
                ' MsgBox(Errors.FontNotSupport(List.SelectedItem.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
#End Region

    ' <<<<<< ��������� ��������� ������� >>>>>>>>>
#Region "EDIT PROPERTY"
    Public Sub ShowProp(ByVal pr As String, ByVal ParamArray MyObjects() As Object)
        MyObjs = MyObjects : prop = pr
        If MyObjs Is Nothing Then Exit Sub
        ' ������� ����, ����� �� �������� �������� �������� �� ����� ��������
        If Me.Parent Is MainForm.ListView Then MayChangeProperty = True
        ' ��� ��������
        type = GetTypeProperty(prop)
        HideAllPanels()
        ' ��������� ����������� ��������
        Props.ShowPropInEditProperty(Me)
        Undo = Nothing : Redo = Nothing
    End Sub
    Public Sub ShowPropArgs(ByVal pr As String, ByVal def As String)
        ' ������� ����������������� �� ��������� ����� � �������� ������� ����� 1) ���� ��� ���� �������� � ����� ��
        ' ��������� ��� ��������� 2)���� � ������ � ArgTypes ��� ���� �������� ����� ������� ������������� ����
        If proj.isPropertyMethod(LCase(pr)) <> "" Or proj.isPropertyMethod(MyZnak & LCase(pr)) <> "" _
        Or Array.IndexOf(ArgTypes, UCase(pr)) <> -1 Then
            prop = pr
            ' ��� ��������
            type = GetTypeProperty(prop)
            HideAllPanels()
            ' ��������� ����������� ��������
            Props.ShowPropInEditProperty(Me)
        End If
        Text = def
        Undo = Nothing : Redo = Nothing
    End Sub
    Public Overrides Property Text() As String
        Get
            Return Text(True)
        End Get
        Set(ByVal value As String)
            Text(True) = value
        End Set
    End Property
    Public Overloads Property Text(ByVal withPodsvet As Boolean) As String
        Get
            If ActiveTextBox Is Nothing Then ActiveTextBox = TextBox1
            If bezRazshirPole Then
                Dim res As New RichTextBox
                perevesti(ActiveTextBox, res, New String() {vbCrLf.Substring(1)}, Chr(182))
                Return res.Text
            End If
            Return ActiveTextBox.Text
        End Get
        Set(ByVal value As String)
            If ActiveTextBox Is Nothing Then ActiveTextBox = TextBox1
            ActiveTextBox.Text = value

            sledush = ActiveTextBox.SelectionStart & "|" & ActiveTextBox.Rtf
            Undo = Nothing : Redo = Nothing

            If bezRazshirPole Then perevesti(ActiveTextBox, ActiveTextBox, New String() {Chr(182), Chr(183)}, vbCrLf.Substring(1))
            If withPodsvet Then proj.Podsvetka(ActiveTextBox, bezPodsvetki)
        End Set
    End Property
    Sub HideAllPanels() ' ������ ��� ������ ����� ����������
        Dim i As Integer
        For i = 0 To Me.Controls.Count - 1
            If Me.Controls(i).Parent Is Me Then Me.Controls(i).Visible = False
        Next
    End Sub
#End Region

    ' <<<<<< ��������� ������� ������������ ���� >>>>>>>>>
#Region "EditPrMenu"
    Public Sub UndoMenu5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Undo Is Nothing Then Exit Sub
        Dim selSt, ind As Integer, rtf, RedoRtf, RedoSel As String
        ind = Undo(Undo.Length - 1).IndexOf("|")
        selSt = Undo(Undo.Length - 1).Substring(0, ind)
        rtf = Undo(Undo.Length - 1).Substring(ind + 1)
        ' �������� �������� ����. ���� � ���������� ���� �������� �� ����
        Dim Tbox As RichTextBox = GetTextBox()
        If tagBox Is Nothing = False Then If tagBox.Focused Then Tbox = tagBox
        If Tbox Is Nothing Then Exit Sub
        isUndo = True
        RedoRtf = Tbox.Rtf : RedoSel = Tbox.SelectionStart
        Tbox.Rtf = rtf : Tbox.SelectionStart = selSt
        sledush = selSt & "|" & rtf
        Timer1_Tick(sender, e)        ' ������� ������ �� ��. ����� ���� (����. �������)
        isUndo = False
        ' ���������� � ���� �������� ����, ������� ���� ������ ��� ������������
        If Redo Is Nothing = False Then
            ReDim Preserve Redo(Redo.Length)
        Else
            ReDim Redo(0)
        End If
        Dim UndoRft As String = Undo(Undo.Length - 1).Substring(Undo(Undo.Length - 1).IndexOf("|") + 1)
        If UndoRft <> RedoRtf Then
            Redo(Redo.Length - 1) = RedoSel & "|" & RedoRtf
        Else
            ReDim Preserve Redo(Redo.Length - 2)
        End If
        ' ������� �������������� �������� ����
        If Undo.Length - 2 >= 0 Then
            ReDim Preserve Undo(Undo.Length - 2)
        Else
            ReDim Preserve Undo(0)
        End If
        'Timer1.Start()
    End Sub
    Public Sub RedoMenu5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Redo Is Nothing Then Exit Sub
        Dim selSt, ind As Integer, rtf As String
        ind = Redo(Redo.Length - 1).IndexOf("|")
        selSt = Redo(Redo.Length - 1).Substring(0, ind)
        rtf = Redo(Redo.Length - 1).Substring(ind + 1)
        ' �������� �������� ����. ���� � ���������� ���� �������� �� ����
        Dim Tbox As RichTextBox = GetTextBox()
        If tagBox Is Nothing = False Then If tagBox.Focused Then Tbox = tagBox
        If Tbox Is Nothing Then Exit Sub
        isRedo = True
        Tbox.Rtf = rtf : Tbox.SelectionStart = selSt
        Timer1.Start() ' ������� ������ �� ��. ����� ���� (����. �������)
        isRedo = False
        sledush = selSt & "|" & rtf
        ' ���������� � ���� �������� ����, ������� ���� ������ ��� ������������
        If Undo(Undo.Length - 1) <> Redo(Redo.Length - 1) And Redo.Length - 1 > 0 Then
            If Undo Is Nothing = False Then
                ReDim Preserve Undo(Undo.Length)
            Else
                ReDim Undo(0)
            End If
            Undo(Undo.Length - 1) = Redo(Redo.Length - 1)
        End If
        ' ������� �������������� �������� ����
        If Redo.Length - 2 >= 0 Then
            ReDim Preserve Redo(Redo.Length - 2)
        Else
            ReDim Preserve Redo(0)
        End If

    End Sub
    Public Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged, tagBox.TextChanged
        If isUndo Or isRedo Then Exit Sub
        Dim Tbox As RichTextBox = GetTextBox()
        If tagBox Is Nothing = False Then If tagBox.Focused Then Tbox = tagBox
        If Tbox Is Nothing Then Exit Sub
        If sledush <> "" Then
            ' ���� �������� �����, � �� ��������������
            Dim ind As Integer = sledush.IndexOf("|")
            Dim t As New RichTextBox() : t.Rtf = sledush.Substring(ind + 1)
            If t.Text = Tbox.Text Then Exit Sub
            ' ��������� ����������� ���� � ��������� ����� ��� �����������
            Dim num As Integer
            If Undo Is Nothing = False Then
                ReDim Preserve Undo(Undo.Length) : num = Undo.Length - 2
            Else
                ReDim Undo(0) : num = 0
            End If
            ' �������� � ���� ���������� �������� ������, ���� ��� ��� �� ��������
            If Undo(num) <> sledush Then
                Undo(Undo.Length - 1) = sledush
            Else
                ReDim Preserve Undo(num)
            End If
            Redo = Nothing
        End If
        ' ����� ������������� �� ��� ����� ���� ���� ���������, ����������� �������� � �������
        Timer2.Start()
    End Sub
    Public Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Dim Tbox As RichTextBox = GetTextBox()
        If tagBox Is Nothing = False Then If tagBox.Focused Then Tbox = tagBox
        If Tbox Is Nothing Then Exit Sub
        sledush = Tbox.SelectionStart & "|" & Tbox.Rtf
    End Sub

    Public Sub CopyMenu5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Tbox As RichTextBox = GetTextBox()
        If tagBox Is Nothing = False Then If tagBox.Focused Then Tbox = tagBox
        If Tbox Is Nothing Then Exit Sub
        Try
            If Tbox.SelectedText <> "" Then System.Windows.Forms.Clipboard.SetText(Tbox.SelectedText)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub PasteMenu5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Tbox As RichTextBox = GetTextBox()
        If tagBox Is Nothing = False Then If tagBox.Focused Then Tbox = tagBox
        If Tbox Is Nothing Then Exit Sub

        ' If Clipboard.GetData(DataFormats.Rtf) <> "" Then
        ' Tbox.SelectedRtf = Clipboard.GetData(DataFormats.Rtf)
        ' Else
        Tbox.SelectedText = Clipboard.GetText(TextDataFormat.Text)
        ' End If
        Timer1.Start() ' ������� ������ �� ��. ����� ����
    End Sub
    Public Sub CutMenu5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CopyMenu5_Click(sender, e)
        DelMenu5_Click(sender, e)
    End Sub
    Public Sub DelMenu5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Tbox As RichTextBox = GetTextBox()
        If tagBox Is Nothing = False Then If tagBox.Focused Then Tbox = tagBox
        If Tbox Is Nothing Then Exit Sub
        If Tbox.SelectedText <> "" Then
            Tbox.SelectedText = ""
            Timer1.Start() ' ������� ������ �� ��. ����� ����
        End If
    End Sub
    Public Sub SelectAllMenu5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Tbox As RichTextBox = GetTextBox()
        If tagBox Is Nothing = False Then If tagBox.Focused Then Tbox = tagBox
        If Tbox Is Nothing Then Exit Sub
        Tbox.SelectAll()
    End Sub

    Function GetTextBox() As RichTextBox
        Try
            If MainForm.EditPrMenu.Tag Is Nothing = False Then
                If ActiveTextBox Is MainForm.EditPrMenu.Tag = False Then Return Nothing
            End If
            Return ActiveTextBox
        Catch ex As Exception
            'End
            Return Nothing
        End Try
    End Function
#End Region

    ' <<<<<< ��� ������� ��������� ������ >>>>>>>>>
#Region "MYSELECT"
    Dim isClick As Boolean, selSt As Integer, bukvaLen As Integer = 6.1, nachalDaleko As Integer = 0
    Private Sub TextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseDown, TextBox2.MouseDown, TextBox3.MouseDown, tagBox.MouseDown
        isClick = False
        ' ��� ������� ��������� ������������, ���� �� ����� ����
        If sender.ModifierKeys = Keys.None Then
            ' ����������� ������� ������� �� �����������
            selSt = sender.GetCharIndexFromPosition(e.Location)
            isClick = True
        ElseIf sender.ModifierKeys = Keys.Shift Then
            ' ���� ����� ����, �� �������� ��� ����� � ������
            isClick = True
            TextBox1_MouseMove(sender, e)
        End If
        ' ���� ��� ������� ����, ���� �������� ������ �� �������� ��� ����� ���������
        If e.Clicks > 1 Or sender.SelectedText.length > 0 Then TextBox1_DoubleClick(sender, e)
    End Sub
    Private Sub TextBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseMove, TextBox2.MouseMove, TextBox3.MouseMove, tagBox.MouseMove
        ' ���� ������� �������� ���������
        If isClick Then
            ' ����������� ���������� ������� ������� �� �����������
            Dim nowPos As Integer = sender.GetCharIndexFromPosition(e.Location)
            ' ����������� ������� ������ ����� � ������ �� �����������
            Dim InLineFirstPos As Integer = sender.GetFirstCharIndexFromLine(sender.GetLineFromCharIndex(nowPos))

            ' ��������, ����� ����������� ��������� ������ (���� vb)
            If e.X / (nowPos - InLineFirstPos + 1) > bukvaLen And sender.ModifierKeys = Keys.None And nowPos <> 0 Then
                nachalDaleko = 1
            End If

            ' ���� �������� ����� �������
            If nowPos - selSt > 0 Then
                Dim plus As Byte = 0
                ' ��������, ����� ����������� ��������� ������ (���� vb)
                If e.X / (nowPos - InLineFirstPos + 1) > bukvaLen Then plus = 1
                ' ��������� ������
                sender.SelectionStart = selSt
                sender.SelectionLength = nowPos - selSt + plus
                nachalDaleko = 0
            ElseIf nowPos - selSt < 0 Then ' ���� �������� ����� ������
                'Dim minus As Byte = 1
                'If e.X < 1 Or Math.Abs(nowPos - selSt) <= 1 Then minus = 0
                sender.SelectionStart = nowPos '+ minus
                sender.SelectionLength = selSt - nowPos + nachalDaleko '- minus
            End If
        End If
    End Sub
    Private Sub TextBox_SelectedText(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseUp, TextBox2.MouseUp, TextBox3.MouseUp, tagBox.MouseUp
        If sender Is tagBox = False Then
            If sender.SelectedText <> "" Then RaiseEvent SelectedText(sender, e)
        End If
        ' �������� �������� ���������
        isClick = False : nachalDaleko = 0
        ' �������� ������� ��������� ���������, ����� ����� ������������ ��, ���� �������� ����� ����'��
        If sender.SelectedText = "" Then selSt = sender.GetCharIndexFromPosition(e.Location)
    End Sub
    Private Sub TextBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.DoubleClick, TextBox2.DoubleClick, TextBox3.DoubleClick, tagBox.DoubleClick
        ' �������� �������� ���������
        isClick = False : nachalDaleko = 0
    End Sub
#End Region

    Private Sub Button3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button3.KeyDown
        If e.KeyCode = Keys.Escape Then TextBox_KeyDown(sender, New KeyEventArgs(Keys.Escape))
    End Sub
End Class