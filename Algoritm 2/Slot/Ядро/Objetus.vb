Public Class Objetus
    Public eventObj As Windows.Forms.Control ' ���������� ��� ������, ��� �� ����� ���� ��� ������ �������
    Public obj, MyObj, MyForm As Object ' ��������� ��� ���������� � �������� ������ 
    Public conteiner As Object ' ��������� ������� ��� ��� �����, � �� Windows.Forms.Control
    Dim click As Boolean
    Public dx, dy, mdx, mdy As Integer
    Dim markers_perenos As Integer = -1
    Public markers(MarkCount - 1) As PictureBox
    Dim raznicaSize(), raznicaLoc() As Point
    Public HideMarker As PictureBox ' ������� ��� ����, ����� �� ����� �������� �������� ������� � ���������
    Public na4Point, endPoint As Point ' ��������� ����� �������������� � ��� ������
    Public NodeTemp As TreeNode ' ������ ���� ��� �����������
    Public ParentTemp, IndexTemp As String ' ������ ���� ��������� ���� ��� �����������
    Public HistoryTemp As String  ' ������ ������� �������������
    Public OldFormTemp As String  ' ������ ������� ����� �������
    Public VstavkaOrCreate As Boolean ' ����������� �� ������ ������ ��� ������ ��������� �����
    Public SplitCont As Windows.Forms.SplitContainer '����� ������������ ����� ������ � �������������
    Public Sobytia(), VBname As String
    Public tree As TreeView
    Public proj As Object = proj
    Public isRun As Boolean
    Public ToolTipa As ToolTip

    '<<<<<<<< �������� ������� >>>>>>>>>
#Region "CREATE"
    Public Sub CreateObject(ByVal ob As Object, Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False) ' �������� ������ ������
        Dim i As Integer, cont As Object
        If isRun = False Then proj = peremens2.proj
        If proj Is Nothing = False Then
            If proj.f Is Nothing = False Then
                ' ����� ����� ������� ��� ����� (����� ������.��������) ������ ���� ��������� ������, ������ � �.�.
                If proj.f.Length <= 1 And ob.GetType.ToString <> ClassAplication & "F" And holostoi = False Then Exit Sub
            End If
        End If
        ' ��������� � ���������� ���������� ������
        obj = ob : MyObj = Me : Me.isRun = isRun : obj.MyObj = MyObj
        ' ����� �� ����� ���� ����� �������
        If isHelp Then Exit Sub
        If Iz.IsMMs(MyObj) = False Then
            If Iz.isNoControlObj(obj) = False Then eventObj = obj
            If isRun = False And proj Is Nothing = False And isDevelop And Not (IsHttpCompil) Then obj.ContextMenuStrip = MnFrm.ObjsMenu
        End If
        If obj.TypeObj = "Polezniy" Then Exit Sub
        If Iz.IsFORM(MyObj) And isRun = False Then
            If MyObj.tab Is Nothing Then
                ' �������� � ��������� ����
                MyObj.tab = New TabPage(obj.Props.Name) : MyObj.tab.Name = obj.Props.name : MyObj.tab.BackColor = Color.White
                MyObj.tab.UseVisualStyleBackColor = True
            End If
        End If

        ToolTipa = New ToolTip(New System.ComponentModel.Container)

        If isRun Then
            If Iz.IsMMs(MyObj) Then
                ' � ��������� ���� ����������� ����
                Dim eventObj As ToolStripMenuItem = ob
                AddHandler eventObj.Click, AddressOf obj_ClickRun
                AddHandler eventObj.MouseDown, AddressOf obj_MouseDownRun
                AddHandler eventObj.MouseMove, AddressOf obj_MouseMoveRun
                AddHandler eventObj.MouseUp, AddressOf obj_MouseUpRun
                AddHandler eventObj.Paint, AddressOf obj_PaintRun
                AddHandler eventObj.DropDownClosed, AddressOf obj_DropDownClosedRun
                AddHandler eventObj.DropDownOpened, AddressOf obj_DropDownOpenedRun
                AddHandler eventObj.DropDownOpening, AddressOf obj_DropDownOpeningRun
            ElseIf Iz.IsCM(MyObj) Then
                ' � ������������ ���� ���� �����
                Dim eventObj As ContextMenuStrip = ob.cnmn
                AddHandler eventObj.Opening, AddressOf obj_OpeningRun
                AddHandler eventObj.Opened, AddressOf obj_OpenedRun
                AddHandler eventObj.Closing, AddressOf obj_ClosingRun
                AddHandler eventObj.Closed, AddressOf obj_ClosedRun
            ElseIf Iz.IsDP(MyObj) Then
                ' � ������� ������ ���� �������
                Dim eventObj As runDP = ob
                AddHandler eventObj.Click, AddressOf obj_ClickRun
                AddHandler eventObj.Panel1.Click, AddressOf obj_ClickRun
                AddHandler eventObj.Panel2.Click, AddressOf obj_ClickRun
                AddHandler eventObj.MouseDown, AddressOf obj_MouseDownRun
                AddHandler eventObj.Panel1.MouseDown, AddressOf obj_MouseDownRun
                AddHandler eventObj.Panel2.MouseDown, AddressOf obj_MouseDownRun
                AddHandler eventObj.MouseMove, AddressOf obj_MouseMoveRun
                AddHandler eventObj.Panel1.MouseMove, AddressOf obj_MouseMoveRun
                AddHandler eventObj.Panel2.MouseMove, AddressOf obj_MouseMoveRun
                AddHandler eventObj.MouseUp, AddressOf obj_MouseUpRun
                AddHandler eventObj.Panel1.MouseUp, AddressOf obj_MouseUpRun
                AddHandler eventObj.Panel2.MouseUp, AddressOf obj_MouseUpRun

                AddHandler eventObj.MouseEnter, AddressOf obj_MouseEnterRun
                AddHandler eventObj.Panel1.MouseEnter, AddressOf obj_MouseEnterRun
                AddHandler eventObj.Panel2.MouseEnter, AddressOf obj_MouseEnterRun
                AddHandler eventObj.MouseLeave, AddressOf obj_MouseLeaveRun
                AddHandler eventObj.Panel1.MouseLeave, AddressOf obj_MouseLeaveRun
                AddHandler eventObj.Panel2.MouseLeave, AddressOf obj_MouseLeaveRun
                AddHandler eventObj.MouseHover, AddressOf obj_MouseHoverRun
                AddHandler eventObj.Panel1.MouseHover, AddressOf obj_MouseHoverRun
                AddHandler eventObj.Panel2.MouseHover, AddressOf obj_MouseHoverRun
                AddHandler eventObj.MouseDoubleClick, AddressOf obj_DoubleClickRun
                AddHandler eventObj.Panel1.MouseDoubleClick, AddressOf obj_DoubleClickRun
                AddHandler eventObj.Panel2.MouseDoubleClick, AddressOf obj_DoubleClickRun
                AddHandler eventObj.MouseWheel, AddressOf obj_MouseWheelRun
                AddHandler eventObj.Panel1.MouseWheel, AddressOf obj_MouseWheelRun
                AddHandler eventObj.Panel2.MouseWheel, AddressOf obj_MouseWheelRun

                AddHandler eventObj.KeyPress, AddressOf obj_KeyPressRun
                AddHandler eventObj.Panel1.KeyPress, AddressOf obj_KeyPressRun
                AddHandler eventObj.Panel2.KeyPress, AddressOf obj_KeyPressRun
                AddHandler eventObj.KeyDown, AddressOf obj_KeyDownRun
                AddHandler eventObj.Panel1.KeyDown, AddressOf obj_KeyDownRun
                AddHandler eventObj.Panel2.KeyDown, AddressOf obj_KeyDownRun
                AddHandler eventObj.KeyUp, AddressOf obj_KeyUpRun
                AddHandler eventObj.Panel1.KeyUp, AddressOf obj_KeyUpRun
                AddHandler eventObj.Panel2.KeyUp, AddressOf obj_KeyUpRun

                AddHandler eventObj.GotFocus, AddressOf obj_GotFocusRun
                AddHandler eventObj.Panel1.GotFocus, AddressOf obj_GotFocusRun
                AddHandler eventObj.Panel2.GotFocus, AddressOf obj_GotFocusRun
                AddHandler eventObj.LostFocus, AddressOf obj_LostFocusRun
                AddHandler eventObj.Panel1.LostFocus, AddressOf obj_LostFocusRun
                AddHandler eventObj.Panel2.LostFocus, AddressOf obj_LostFocusRun
                AddHandler eventObj.Scroll, AddressOf obj_ScrollRun
                AddHandler eventObj.Panel1.Scroll, AddressOf obj_ScrollRun1
                AddHandler eventObj.Panel2.Scroll, AddressOf obj_ScrollRun2
                AddHandler eventObj.Paint, AddressOf obj_PaintRun
                AddHandler eventObj.Panel1.Paint, AddressOf obj_PaintRun
                AddHandler eventObj.Panel2.Paint, AddressOf obj_PaintRun
                AddHandler eventObj.SplitterMoved, AddressOf obj_SplitterMovedRun
                AddHandler eventObj.SplitterMoving, AddressOf obj_SplitterMovingRun
            Else


                ' ����
                If Array.IndexOf(Sobytia, trans("����").ToUpper) <> -1 Then
                    AddHandler eventObj.Click, AddressOf obj_ClickRun
                End If
                If Array.IndexOf(Sobytia, trans("������� ������ ����").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseDown, AddressOf obj_MouseDownRun
                End If
                If Array.IndexOf(Sobytia, trans("������� ������ ����").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseUp, AddressOf obj_MouseUpRun
                End If
                If Array.IndexOf(Sobytia, trans("��������� �������").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseEnter, AddressOf obj_MouseEnterRun
                End If
                If Array.IndexOf(Sobytia, trans("��������� �������").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseLeave, AddressOf obj_MouseLeaveRun
                End If
                If Array.IndexOf(Sobytia, trans("������ �� �������").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseHover, AddressOf obj_MouseHoverRun
                End If
                If Array.IndexOf(Sobytia, trans("�������� �������").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseMove, AddressOf obj_MouseMoveRun
                End If
                If Array.IndexOf(Sobytia, trans("������� ����").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseDoubleClick, AddressOf obj_DoubleClickRun
                End If
                If Array.IndexOf(Sobytia, trans("�������� ��������").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseWheel, AddressOf obj_MouseWheelRun
                End If

                ' ����������
                If Array.IndexOf(Sobytia, trans("������� ����������").ToUpper) <> -1 Then
                    AddHandler eventObj.KeyPress, AddressOf obj_KeyPressRun
                End If
                If Array.IndexOf(Sobytia, trans("������� ���� ������").ToUpper) <> -1 Then
                    AddHandler eventObj.KeyDown, AddressOf obj_KeyDownRun
                End If
                If Array.IndexOf(Sobytia, trans("������� ������").ToUpper) <> -1 Then
                    AddHandler eventObj.KeyUp, AddressOf obj_KeyUpRun
                End If

                ' ������
                If Array.IndexOf(Sobytia, trans("��������� ������").ToUpper) <> -1 Then
                    AddHandler eventObj.TextChanged, AddressOf obj_TextChangedRun
                End If
                If Array.IndexOf(Sobytia, trans("��������� ������").ToUpper) <> -1 Then
                    AddHandler eventObj.GotFocus, AddressOf obj_GotFocusRun
                End If
                If Array.IndexOf(Sobytia, trans("������ ������").ToUpper) <> -1 Then
                    AddHandler eventObj.LostFocus, AddressOf obj_LostFocusRun
                End If
                If Array.IndexOf(Sobytia, trans("����������").ToUpper) <> -1 Then
                    AddHandler eventObj.Paint, AddressOf obj_PaintRun
                End If
                If Array.IndexOf(Sobytia, trans("���������").ToUpper) <> -1 Then
                    If Iz.IsFORM(MyObj) Then
                        Dim panel As runF = eventObj
                        AddHandler Panel.Scroll, AddressOf obj_ScrollRun
                    ElseIf Iz.IsTl(MyObj) Then
                        Dim panel As runTl = eventObj
                        AddHandler Panel.Scroll, AddressOf obj_ScrollRun
                    Else
                        Dim panel As Windows.Forms.Panel = eventObj
                        AddHandler Panel.Scroll, AddressOf obj_ScrollRun
                    End If
                End If
                If Array.IndexOf(Sobytia, trans("��������� ��������").ToUpper) <> -1 Then
                    Dim panel As Windows.Forms.Panel = eventObj
                    AddHandler Panel.Resize, AddressOf obj_ResizeRun
                End If
                If Array.IndexOf(Sobytia, trans("�������� ����").ToUpper) <> -1 Then
                    Dim panel As runF = eventObj
                    AddHandler panel.FormClosing, AddressOf obj_FormClosingRun
                End If
                If Array.IndexOf(Sobytia, trans("���������� �������").ToUpper) <> -1 Then
                    AddHandler eventObj.SizeChanged, AddressOf obj_SizeChangedRun
                End If
                If Array.IndexOf(Sobytia, trans("���������� �������").ToUpper) <> -1 Then
                    AddHandler eventObj.VisibleChanged, AddressOf obj_VisibleChangedRun
                End If

                ' �������
                If Iz.IsW(MyObj) Then
                    Dim panel As runW = eventObj
                    If Array.IndexOf(Sobytia, trans("����� ����� ����������").ToUpper) <> -1 Then
                        AddHandler Panel.CanGoBackChanged, AddressOf WebBrowser1_CanGoBackChanged
                    End If
                    If Array.IndexOf(Sobytia, trans("������ ����� ����������").ToUpper) <> -1 Then
                        AddHandler Panel.CanGoForwardChanged, AddressOf WebBrowser1_CanGoForwardChanged
                    End If
                    If Array.IndexOf(Sobytia, trans("�������� �����������").ToUpper) <> -1 Then
                        AddHandler Panel.DocumentCompleted, AddressOf WebBrowser1_DocumentCompleted
                    End If
                    If Array.IndexOf(Sobytia, trans("�������� �����������").ToUpper) <> -1 Then
                        AddHandler Panel.FileDownload, AddressOf WebBrowser1_FileDownload
                    End If
                    If Array.IndexOf(Sobytia, trans("������� �� ������").ToUpper) <> -1 Then
                        AddHandler Panel.Navigated, AddressOf WebBrowser1_Navigated
                    End If
                    If Array.IndexOf(Sobytia, trans("��������� �� ������").ToUpper) <> -1 Then
                        AddHandler Panel.Navigating, AddressOf WebBrowser1_Navigating
                    End If
                    If Array.IndexOf(Sobytia, trans("�������� � ����� ����").ToUpper) <> -1 Then
                        AddHandler Panel.NewWindow, AddressOf WebBrowser1_NewWindow
                    End If
                    If Array.IndexOf(Sobytia, trans("��������� ������ ����������").ToUpper) <> -1 Then
                        AddHandler Panel.StatusTextChanged, AddressOf WebBrowser1_StatusTextChanged
                    End If
                End If

                ' ��������
                If Iz.IsTP(MyObj) Then
                    Dim panel As runTP = eventObj
                    If Array.IndexOf(Sobytia, trans("������� ��������� ��������").ToUpper) <> -1 Then
                        AddHandler Panel.Deselected, AddressOf TabControl_Deselected
                    End If
                    If Array.IndexOf(Sobytia, trans("��������� ��������� ��������").ToUpper) <> -1 Then
                        AddHandler Panel.Deselecting, AddressOf TabControl_Deselecting
                    End If
                    If Array.IndexOf(Sobytia, trans("�������� ��������").ToUpper) <> -1 Then
                        AddHandler Panel.SelectedIndexChanged, AddressOf TabControl_SelectedIndexChanged
                    End If
                    If Array.IndexOf(Sobytia, trans("�������� ��������").ToUpper) <> -1 Then
                        AddHandler Panel.Selecting, AddressOf TabControl_Selecting
                    End If
                End If

                ' �������
                If Iz.IsTl(MyObj) Then
                    Dim panel As runTl = eventObj
                    If Array.IndexOf(Sobytia, trans("���������� ���������").ToUpper) <> -1 Then
                        AddHandler Panel.SelectionChanged, AddressOf Table_SelectionChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������ �������������� ������").ToUpper) <> -1 Then
                        AddHandler Panel.CellBeginEdit, AddressOf Table_CellBeginEditRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���� �� ������").ToUpper) <> -1 Then
                        AddHandler Panel.CellClick, AddressOf Table_CellClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���� �� ���������� ������").ToUpper) <> -1 Then
                        AddHandler Panel.CellMouseDown, AddressOf Table_CellMouseDownRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������� ���� �� ������").ToUpper) <> -1 Then
                        AddHandler Panel.CellDoubleClick, AddressOf Table_CellDoubleClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("����� �������������� �����").ToUpper) <> -1 Then
                        AddHandler Panel.CellEndEdit, AddressOf Table_CellEndEditRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������ � ������").ToUpper) <> -1 Then
                        AddHandler Panel.CellEnter, AddressOf Table_CellEnterRun
                    End If
                    If Array.IndexOf(Sobytia, trans("����� �������� �����").ToUpper) <> -1 Then
                        AddHandler Panel.CellLeave, AddressOf Table_CellLeaveRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������� �����������").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnDisplayIndexChanged, AddressOf Table_ColumnDisplayIndexChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���� �� ��������� �������").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnHeaderMouseClick, AddressOf Table_ColumnHeaderMouseClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������� ���� �� ��������� �������").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnHeaderMouseDoubleClick, AddressOf Table_ColumnHeaderMouseDoubleClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���������� �������").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnSortModeChanged, AddressOf Table_ColumnSortModeChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���������� ������ �������").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnWidthChanged, AddressOf Table_ColumnWidthChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���� �� ��������� ������").ToUpper) <> -1 Then
                        AddHandler Panel.RowHeaderMouseClick, AddressOf Table_RowHeaderMouseClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���������� ������ ������").ToUpper) <> -1 Then
                        AddHandler Panel.RowHeightChanged, AddressOf Table_RowHeightChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������� ������").ToUpper) <> -1 Then
                        AddHandler Panel.RowsAdded, AddressOf Table_RowsAddedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������� ������").ToUpper) <> -1 Then
                        AddHandler Panel.RowsRemoved, AddressOf Table_RowsRemovedRun
                    End If
                End If

                ' ������
                If Iz.IsC(MyObj) Then
                    Dim panel As runC = eventObj
                    If Array.IndexOf(Sobytia, trans("��������� ��������� ������").ToUpper) <> -1 Then
                        AddHandler Panel.SelectedIndexChanged, AddressOf obj_SelectedIndexChangedRun
                    End If
                End If
                If Iz.IsL(MyObj) Then
                    Dim panel As runL = eventObj
                    If Array.IndexOf(Sobytia, trans("��������� ��������� ������").ToUpper) <> -1 Then
                        AddHandler panel.SelectedIndexChanged, AddressOf obj_SelectedIndexChangedRun
                    End If
                End If
                If Iz.IsCL(MyObj) Then
                    Dim panel As runCL = eventObj
                    If Array.IndexOf(Sobytia, trans("��������� ��������� ������").ToUpper) <> -1 Then
                        AddHandler panel.SelectedIndexChanged, AddressOf obj_SelectedIndexChangedRun
                    End If
                End If

                If Iz.IsCr(MyObj) Then
                    Dim panel As runCr = eventObj
                    If Array.IndexOf(Sobytia, trans("��������� ��������").ToUpper) <> -1 Then
                        AddHandler Panel.CloseUp, AddressOf obj_CloseUp
                    End If
                    If Array.IndexOf(Sobytia, trans("��������� ���������").ToUpper) <> -1 Then
                        AddHandler Panel.DropDown, AddressOf obj_DropDown
                    End If
                    If Array.IndexOf(Sobytia, trans("�������� ����������").ToUpper) <> -1 Then
                        AddHandler Panel.ValueChanged, AddressOf obj_ValueChanged
                    End If
                End If

                If Iz.IsTb(MyObj) Then
                    Dim panel As runTb = eventObj
                    If Array.IndexOf(Sobytia, trans("�������� ����������").ToUpper) <> -1 Then
                        AddHandler Panel.ValueChanged, AddressOf obj_ValueChanged
                    End If
                    If Array.IndexOf(Sobytia, trans("�������� �������").ToUpper) <> -1 Then
                        AddHandler Panel.Scroll, AddressOf obj_ScrollRun
                    End If
                End If

                ' ������ ������
                If Iz.IsCS(MyObj) Then
                    Dim panel As IWinSockEvents = eventObj
                    If Array.IndexOf(Sobytia, trans("�������������� � �������").ToUpper) <> -1 Then
                        AddHandler panel.ConnectedToServer, AddressOf obj_ConnectedToServerRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������������� ������").ToUpper) <> -1 Then
                        AddHandler panel.ConnectionClient, AddressOf obj_ConnectionClientRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���������� ����� ��������").ToUpper) <> -1 Then
                        AddHandler panel.CountChanged, AddressOf obj_CountChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������ �����").ToUpper) <> -1 Then
                        AddHandler panel.TextReceived, AddressOf obj_TextReceivedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������ �������").ToUpper) <> -1 Then
                        AddHandler panel.CommandReceived, AddressOf obj_CommandReceivedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������ ����").ToUpper) <> -1 Then
                        AddHandler panel.FileReceived, AddressOf obj_FileReceivedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("����������").ToUpper) <> -1 Then
                        AddHandler panel.Disconnected, AddressOf obj_DisconnectedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("��������� ������").ToUpper) <> -1 Then
                        AddHandler panel.ErrorReceived, AddressOf obj_ErrorReceivedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���������� �����").ToUpper) <> -1 Then
                        AddHandler panel.SendTextComplete, AddressOf obj_SendTextCompleteRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���������� ����").ToUpper) <> -1 Then
                        AddHandler panel.SendFileComplete, AddressOf obj_SendFileCompleteRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���� �����������").ToUpper) <> -1 Then
                        AddHandler panel.SendProgress, AddressOf obj_SendProgressRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���� ����� ������").ToUpper) <> -1 Then
                        AddHandler panel.ReceiveProgress, AddressOf obj_ReceiveProgressRun
                    End If
                    If Array.IndexOf(Sobytia, trans("��������� ������").ToUpper) <> -1 Then
                        AddHandler panel.StateChanged, AddressOf obj_StateChangedRun
                    End If
                End If

                ' ��������
                If Iz.IsI(MyObj) Then
                    Dim panel As IInternetEvents = eventObj
                    If Array.IndexOf(Sobytia, trans("������������ ������").ToUpper) <> -1 Then
                        AddHandler panel.SendingQuery, AddressOf obj_SendingQueryRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���������� ������").ToUpper) <> -1 Then
                        AddHandler panel.SentQuery, AddressOf obj_SentQueryRun
                    End If
                    If Array.IndexOf(Sobytia, trans("������ �����").ToUpper) <> -1 Then
                        AddHandler panel.ReceivedResponse, AddressOf obj_ReceivedResponseRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���� ����� ������").ToUpper) <> -1 Then
                        AddHandler panel.ReceiveProgress, AddressOf obj_ReceiveProgressRun
                    End If
                    If Array.IndexOf(Sobytia, trans("�������� ��������").ToUpper) <> -1 Then
                        AddHandler panel.DownloadCancelled, AddressOf obj_DownloadCancelledRun
                    End If
                End If


                ' ������
                If Iz.IsFORM(MyObj) Then
                    Dim panel As runF = eventObj
                    If Array.IndexOf(Sobytia, trans("������������").ToUpper) <> -1 Then
                        AddHandler panel.Minimize, AddressOf Minimize
                    End If
                    If Array.IndexOf(Sobytia, trans("������� ���� �� ����").ToUpper) <> -1 Then
                        AddHandler panel.DoubleClickTray, AddressOf DoubleClickTray
                    End If
                End If
                If Array.IndexOf(Sobytia, trans("����� ������������").ToUpper) <> -1 Then
                    If Iz.IsMd(MyObj) Then
                        Dim panel As runMd = eventObj
                        AddHandler panel.OnEnd, AddressOf obj_OnEndRun
                    Else
                        Dim panel As runA = eventObj
                        AddHandler panel.OnEnd, AddressOf obj_OnEndRun
                    End If
                End If
                If Array.IndexOf(Sobytia, trans("��������� �������").ToUpper) <> -1 Then
                    If Iz.IsCB(MyObj) Then
                        Dim check As CheckBox = eventObj
                        AddHandler check.CheckedChanged, AddressOf obj_CheckedChangedRun
                    Else
                        Dim check As RadioButton = eventObj
                        AddHandler check.CheckedChanged, AddressOf obj_CheckedChangedRun
                    End If
                End If
                If Iz.IsM(MyObj) Then
                    Dim panel As runM = eventObj
                    If Array.IndexOf(Sobytia, trans("��������� ��������").ToUpper) <> -1 Then
                        AddHandler panel.ChangingValue, AddressOf obj_ChangingValueRun
                    End If
                    If Array.IndexOf(Sobytia, trans("���������� ��������").ToUpper) <> -1 Then
                        AddHandler panel.ChangedValue, AddressOf obj_ChangedValueRun
                    End If
                End If
                If Iz.IsLLb(MyObj) Then
                    Dim panel As runLLb = eventObj
                    If Array.IndexOf(Sobytia, trans("���� �� ������").ToUpper) <> -1 Then
                        AddHandler panel.LinkClicked, AddressOf obj_LinkClicked
                    End If
                End If
                If Iz.IsRT(MyObj) Then
                    Dim panel As runRT = eventObj
                    If Array.IndexOf(Sobytia, trans("�������������� ���������").ToUpper) <> -1 Then
                        AddHandler panel.HScroll, AddressOf obj_HScroll
                    End If
                    If Array.IndexOf(Sobytia, trans("������������ ���������").ToUpper) <> -1 Then
                        AddHandler panel.VScroll, AddressOf obj_VScroll
                    End If
                    If Array.IndexOf(Sobytia, trans("���� �� ������ ���������").ToUpper) <> -1 Then
                        AddHandler panel.LinkClicked, AddressOf obj_LinkClicked
                    End If
                End If
                If Iz.IsTm(MyObj) Then
                    Dim panel As runTm = obj
                    If Array.IndexOf(Sobytia, trans("������").ToUpper) <> -1 Then
                        AddHandler panel.Tick, AddressOf obj_Tick
                    End If
                End If
                If Iz.IsTr(MyObj) Then
                    Dim spis As runTr = eventObj
                    If Array.IndexOf(Sobytia, trans("���� ������").ToUpper) <> -1 Then
                        AddHandler spis.ClickButton, AddressOf obj_ClickButtonRun
                    End If
                    If Array.IndexOf(Sobytia, trans("��������� ��������").ToUpper) <> -1 Then
                        AddHandler spis.ActivationSuccessul, AddressOf obj_ActivationSuccessulRun
                    End If
                    If Array.IndexOf(Sobytia, trans("��������� ���������").ToUpper) <> -1 Then
                        AddHandler spis.ActivationFailed, AddressOf obj_ActivationFailedRun
                    End If
                End If



                ' ������ ���������2
                If Iz.isNoControlObj(obj) = False Then
                    AddHandler eventObj.Disposed, AddressOf obj_DisposedNado
                    AddHandler eventObj.Resize, AddressOf obj_ResizeNado
                End If
                ' ������ ���������1
                If Iz.IsW(MyObj) Then
                    Dim panel As runW = obj
                    AddHandler panel.NewWindow, AddressOf WebBrowser_NewWindowNado
                    AddHandler panel.StatusTextChanged, AddressOf WebBrowser_StatusTextChangedNado
                End If

            End If

            ' ���
            Dim MyEventObj As MyEvents = obj
            If Array.IndexOf(Sobytia, trans("��������").ToUpper) <> -1 Then
                AddHandler MyEventObj.Created, AddressOf obj_LoadRun
            End If
        End If

        If holostoi = True And fromEng = False Then Exit Sub
        ' #### ����� ��������� �������� ###

        If Iz.IsFORM(MyObj) Then 'And isRun = False Then
            ' �������� ������������� ��� ����
            SplitCont = New Windows.Forms.SplitContainer()
            SplitCont.Orientation = Orientation.Horizontal
            SplitCont.Panel1.AutoScroll = True : SplitCont.Panel2.AutoScroll = False
            SplitCont.Panel2.BorderStyle = BorderStyle.FixedSingle
            SplitCont.Panel2.BackColor = SystemColors.Control
            SplitCont.Dock = DockStyle.Fill
            AddHandler SplitCont.Panel1.Scroll, AddressOf Scroll
            AddHandler SplitCont.SplitterMoved, AddressOf SplitterMoved
            AddHandler SplitCont.Panel2.MouseDown, AddressOf obj_MouseDown
            AddHandler SplitCont.Panel2.MouseMove, AddressOf obj_MouseMove
            AddHandler SplitCont.Panel2.MouseUp, AddressOf obj_MouseUp
            AddHandler SplitCont.Panel2.DoubleClick, AddressOf obj_DoubleClick
            AddHandler SplitCont.Panel2.Click, AddressOf obj_Click
            AddHandler SplitCont.Panel2.Paint, AddressOf obj_Paint
        End If

        ' ���� ������ �� ���������� �������� �������, � ������ ��������� ��������� ������ �������������
        '    If fromEng = False Then
        ' Dim frma As Forms = conteiner ' ���  ��� ������������
        ' ���� ������ ��� ����� �� ��������
        ' ���� ������ �� �������� ���� ��������� ������ �������� �������
        If obj.TypeObj <> "IncludeObj" And MyObj.conteiner Is Nothing Or Iz.isPoluObj(obj) Then
            ' ���� ��������� �����, �� � �� ���� ���������, ��� ������� ����������� Forms
            If Iz.IsFORM(MyObj) = False Then

                If obj.TypeObj = "PoluObj" Then ' ���� ��� ����������, �� ��������� ��� ���� �����������
                    Dim splt As SplitContainer
                    If conteiner Is Nothing = False Then
                        splt = conteiner.SplitCont
                    Else
                        splt = proj.ActiveForm.SplitCont
                    End If
                    conteiner = splt.Panel2
                    splt.Panel2MinSize = 25
                    If splt.SplitterDistance > splt.Height - splt.Panel2MinSize Then
                        splt.SplitterDistance = splt.Height - splt.Panel2MinSize
                    End If
                    cont = conteiner
                Else ' ���� ��� ������� ������, �� ��� ��������� ����� ���� �����, ������, ������ � ������ � �.�.
                    conteiner = proj.ActiveForm
                    If proj.ActiveForm Is Nothing = False Then
                        If proj.ActiveForm.ActiveObj Is Nothing = False Then
                            If proj.ActiveForm.ActiveObj(0) Is Nothing = False Then
                                ' ���� ��� ������, �� ����� ���������� �� ���
                                If Iz.isPanel(proj.ActiveForm.ActiveObj(0).obj) Then
                                    If proj.ActiveForm.ActiveObj.Length = 1 Then
                                        conteiner = proj.ActiveForm.ActiveObj(0) ' ����������� ����� ��������� ������
                                    ElseIf proj.ActiveForm.ActiveObj(0).conteiner Is Nothing = False Then
                                        ' ���� �������� ����������� ������� �� ������ ��� ������������
                                        If proj.ActiveForm.ActiveObj(0).conteiner Is proj.ActiveForm.SplitCont.Panel2 = False Then
                                            conteiner = proj.ActiveForm.ActiveObj(0).conteiner ' ����������� ����� ��������� ����������� �������
                                        End If
                                    End If
                                Else
                                    conteiner = proj.ActiveForm.ActiveObj(0).conteiner
                                End If
                            End If
                        End If
                    End If

                    ' ��������� �������� �������� � ����������
                    If Iz.IsDP(conteiner) Then ' ���� �������� ������� ������
                        Dim res As MsgBoxResult
                        If conteiner.ActivePanel = "" Then
                            res = MsgBox(transInfc("�� ������ ���������� ������ �� ������ �� ���� �������?"), MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question)
                        Else
                            If conteiner.ActivePanel = "Panel1" Then res = MsgBoxResult.Yes Else res = MsgBoxResult.No
                            conteiner.ActivePanel = ""
                        End If
                        If res = MsgBoxResult.Yes Then
                            cont = conteiner.obj.panel1
                        ElseIf res = MsgBoxResult.No Then
                            cont = conteiner.obj.panel2
                        ElseIf res = MsgBoxResult.Cancel Then
                            obj.Props.name = "#NotCreateDP" : Exit Sub
                        End If
                    ElseIf conteiner.GetType.ToString = "System.Windows.Forms.SplitterPanel" Then
                        conteiner = proj.activeForm
                        cont = conteiner.obj
                    ElseIf Iz.IsMMs(conteiner) Then
                        conteiner = proj.activeForm
                        cont = conteiner.obj
                    Else
                        cont = conteiner.obj
                    End If
                End If

                ' � ��������� ������� ������ ��������� �� � �� ������ �������
                If Iz.isSostObj(cont) Then
                    If obj.GetType.ToString.IndexOf(cont.GetType.ToString) <> 0 Then conteiner = proj.activeForm : cont = proj.activeform.obj
                End If
                ' �������� ��������, ��� �� ����������� �������� ����� ��������� �������
                If Iz.isIncludeObj(obj) = False And Iz.isPoluObj(obj) = False Then
                    While Iz.isPanel(cont) = False And cont.GetType.ToString <> "System.Windows.Forms.SplitterPanel"
                        cont = cont.myobj.conteiner.obj
                    End While
                End If

                ' ������ � � � � ���������
                Dim loc As Point
                If obj.TypeObj <> "PoluObj" Then
                    ' ���������� ������ � ������ ����� � ���� ��� ��� ����� ���� �� �������� ��� � ������ �����
                    Loc = GetXY(obj, cont, cont.Width / 2 - eventObj.Width / 2, cont.Height / 2 - eventObj.Height / 2)
                Else
                    ' ���� �� ���� ����� � �����������2 ��� ����� ����, �� �������� ������ � ������ �����
                    Loc = GetXY(obj, cont, setka, setka) : BackPoluObj(True, MyObj)
                End If
                If Iz.isNoMove(obj) Then
                    obj.left = Loc.X : obj.top = Loc.Y
                Else
                    ' ���� ������� �����������, �� ���� �� ���������������� ���������� 
                    If proj.UndoRedoNoWrite Then
                    ElseIf VstavkaOrCreate Then
                        obj.Props.X += setka : obj.Props.Y += setka
                    Else
                        obj.Props.X = Loc.X : obj.Props.Y = Loc.Y
                    End If
                End If



                ' �������� ������ � ��������
                cont.Controls.Add(obj)

                ' �������� ��� ��������� ��������, ���� ��� �� �������� �������
                If Iz.IsTP(MyObj) And fromEng = False Then
                    If MyObj.obj.tabPages.Count = 0 And VstavkaOrCreate = False Then addTabPage(New TPages) : addTabPage(New TPages)
                ElseIf (Iz.IsMM(MyObj) Or Iz.IsCM(MyObj) Or Iz.IsTPl(MyObj)) And fromEng = False Then
                    If MyObj.obj.items.Count = 0 And VstavkaOrCreate = False Then
                        Dim mmenus As New MMenus
                        ' � ToolPanel ����� ������ ��� ������� �������
                        If Iz.IsTPl(MyObj) Then MMenus = New MMenus(, , , True)

                        addMMenuItem(MMenus, False)
                    End If
                ElseIf Iz.IsTl(MyObj) And fromEng = False Then
                    If MyObj.obj.Columns.Count = 0 And VstavkaOrCreate = False Then
                        'MyObj.obj.props.Columns = """" & trans("�������") & "1"", """ & trans("�������") & "2"""
                        'MyObj.obj.props.Rows = """" & trans("������") & "1"" | """ & trans("������") & "1"", " & _
                        '                       """" & trans("������") & "2"" | """ & trans("������") & "2"""
                        MyObj.obj.props.Columns = trans("�������") & "1, " & trans("�������") & "2"
                        MyObj.obj.props.Rows = trans("������") & "1 | " & trans("������") & "1, " & _
                                               trans("������") & "2 | " & trans("������") & "2"
                    End If
                ElseIf (Iz.IsC(MyObj) Or Iz.IsL(MyObj) Or Iz.IsCL(MyObj)) And fromEng = False Then
                    If MyObj.obj.Items.Count = 0 And VstavkaOrCreate = False Then
                        'MyObj.obj.props.Items = """" & trans("������") & "1"", """ & trans("������") & "2"""
                        'MyObj.obj.props.text = trans("������") & "1"
                        MyObj.obj.props.Items = trans("������") & "1, " & trans("������") & "2"
                        MyObj.obj.props.text = trans("������") & "1"
                        MyObj.obj.props.SelectedItem = MyObj.obj.props.Text
                    End If
                End If

            End If
        ElseIf obj.TypeObj = "IncludeObj" And VstavkaOrCreate = True And MyObj.conteiner Is Nothing Then
            ' ��� ������� �����������, ���� ��������� ����������� �� ������
            ' ���� ��� ��������� ������ � ��� ��� �� �������� ��������, �� ��������� ����� ������ �������� ������ �� ���� ��� ��� ������������
            Dim SostObj As Object = proj.GetSostObjFromIncludeObj(MyObj)
            ' ���� ��������� ������ �������� ��������� ������ �������, �� �������� ���
            If SostObj Is Nothing = False Then
                If Iz.IsTP(SostObj) Then SostObj.addTabPage(MyObj, , True)
                If Iz.IsMM(SostObj) Or Iz.IsCM(SostObj) Or Iz.IsMMs(SostObj) Or Iz.IsTPl(SostObj) Then SostObj.addMMenuItem(MyObj)
            Else
                If VstavkaOrCreate = False Then MsgBox(Errors.NotSupportIncludeObj(), MsgBoxStyle.Exclamation)
                obj.Props.name = "" : Exit Sub
            End If
        End If
        ' End If

        If Iz.IsMMs(MyObj) Then
            ' � ��������� ���� ����������� ����
            Dim eventObj As ToolStripItem = ob
            AddHandler eventObj.MouseDown, AddressOf obj_MouseDown
            AddHandler eventObj.MouseMove, AddressOf obj_MouseMove
            AddHandler eventObj.MouseUp, AddressOf obj_MouseUp
            AddHandler eventObj.DoubleClick, AddressOf obj_DoubleClick
            AddHandler eventObj.Click, AddressOf obj_Click
            AddHandler eventObj.Paint, AddressOf obj_Paint
        ElseIf Iz.IsDP(MyObj) Then
            ' � ������� ������ ���� �������
            Dim eventObj As DP = ob
            AddHandler eventObj.Panel1.MouseDown, AddressOf obj_MouseDown
            AddHandler eventObj.Panel2.MouseDown, AddressOf obj_MouseDown
            AddHandler eventObj.Panel1.MouseMove, AddressOf obj_MouseMove
            AddHandler eventObj.Panel2.MouseMove, AddressOf obj_MouseMove
            AddHandler eventObj.Panel1.MouseUp, AddressOf obj_MouseUp
            AddHandler eventObj.Panel2.MouseUp, AddressOf obj_MouseUp
            AddHandler eventObj.Panel1.DoubleClick, AddressOf obj_DoubleClick
            AddHandler eventObj.Panel2.DoubleClick, AddressOf obj_DoubleClick
            AddHandler eventObj.Panel1.Click, AddressOf obj_Click
            AddHandler eventObj.Panel2.Click, AddressOf obj_Click
            AddHandler eventObj.Panel1.Paint, AddressOf obj_Paint
            AddHandler eventObj.Panel2.Paint, AddressOf obj_Paint
            AddHandler eventObj.SizeChanged, AddressOf obj_Resize
            AddHandler eventObj.SplitterMoved, AddressOf obj_SplitterMoved
            eventObj.Panel1.Tag = "Panel1" : eventObj.Panel2.Tag = "Panel2"
        Else
            AddHandler eventObj.MouseDown, AddressOf obj_MouseDown
            AddHandler eventObj.MouseUp, AddressOf obj_MouseUp
            AddHandler eventObj.MouseMove, AddressOf obj_MouseMove
            AddHandler eventObj.DoubleClick, AddressOf obj_DoubleClick
            AddHandler eventObj.Click, AddressOf obj_Click
            AddHandler eventObj.GotFocus, AddressOf obj_GotFocus
            AddHandler eventObj.Paint, AddressOf obj_Paint
            AddHandler eventObj.SizeChanged, AddressOf obj_Resize
            If Iz.isPanel(obj) Then
                Dim scrol As Windows.Forms.Panel = eventObj
                'scrol.AutoScroll = True
                AddHandler scrol.Scroll, AddressOf obj_Scroll
                AddHandler scrol.Resize, AddressOf obj_ResizeNado
            End If
            ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = obj
            ' � ������� ����� ����� �������������� �������
            If Iz.IsTl(MyObj) Then
                Dim tbl As Windows.Forms.DataGridView = eventObj
                AddHandler tbl.CellClick, AddressOf obj_CellContentClick
                AddHandler tbl.SelectionChanged, AddressOf obj_SelectionChanged
            ElseIf Iz.IsC(MyObj) Then
                Dim spis As Windows.Forms.ComboBox = eventObj
                AddHandler spis.SelectedIndexChanged, AddressOf obj_SelectedIndexChanged
            ElseIf Iz.IsCL(MyObj) Then
                Dim spis As Windows.Forms.CheckedListBox = eventObj
                AddHandler spis.SelectedIndexChanged, AddressOf obj_SelectedIndexChanged
            ElseIf Iz.IsL(MyObj) Then
                Dim spis As Windows.Forms.ListBox = eventObj
                AddHandler spis.SelectedIndexChanged, AddressOf obj_SelectedIndexChanged
            End If
        End If

        'If isRun Then Exit Sub

        ' ������� � ��������� �������
        For i = 0 To MarkCount - 1
            markers(i) = New PictureBox()
            markers(i).Width = markerX : markers(i).Height = markerY : markers(i).Visible = False
            markers(i).BackColor = Color.White : markers(i).BorderStyle = BorderStyle.FixedSingle
            AddHandler markers(i).MouseDown, AddressOf markers_MouseDown
            AddHandler markers(i).MouseUp, AddressOf markers_MouseUp
            AddHandler markers(i).MouseMove, AddressOf markers_MouseMove
            If i = 8 Then
                markers(i).Width *= 1.5 : markers(i).Height *= 1.5
                markers(i).Image = Pictures32.Images("MoveMarker")
                markers(i).SizeMode = PictureBoxSizeMode.StretchImage
            ElseIf i = 9 Then
                markers(i).Width *= 1.5 : markers(i).Height *= 1.5
                markers(i).Image = Pictures32.Images("AddIncludeObj")
                markers(i).SizeMode = PictureBoxSizeMode.StretchImage
            End If
            markers(i).ContextMenuStrip = MainForm.ObjsMenu
            markers(i).Tag = MyObj : markers(i).Name = "Markers"
        Next
        ' ��������� ������� ��������
        If obj.TypeObj <> "PoluObj" Then
            markers(0).Cursor = Cursors.SizeNWSE : markers(7).Cursor = Cursors.SizeNWSE
            markers(1).Cursor = Cursors.SizeNS : markers(6).Cursor = Cursors.SizeNS
            markers(2).Cursor = Cursors.SizeNESW : markers(5).Cursor = Cursors.SizeNESW
            markers(3).Cursor = Cursors.SizeWE : markers(4).Cursor = Cursors.SizeWE
            ' � ����� �������� ����� ���� ��������
            If Iz.IsFORM(MyObj) = False Then
                GetMyForm.tab.Controls.AddRange(markers)
            Else
                ' ���������� �����
                SplitCont.Panel1.Controls.Add(obj) : MyObj.tab.Controls.Add(SplitCont) : MyObj.tab.Controls.AddRange(markers)
                SplitCont.Panel2MinSize = 0 : SplitCont.SplitterDistance = SplitCont.Height
                SplitCont.BackColor = SkinColors("FormsTab")
                SplitCont.Panel1.BackgroundImage = SkinPictures("FormsTab")
                SplitCont.Panel2.BackgroundImage = SkinPictures("FormsTab")
                MyObj.splitCont = SplitCont
                MainForm.TabControl1.TabPages().Add(MyObj.tab)
                ReDim MyObj.MyObjs(0) : MyObj.MyObjs(0) = Me
                SplitCont.SplitterDistance = 9999 : SplitCont.SplitterWidth = 2
            End If
        Else
            If conteiner Is Nothing = False Then

                GetMyForm.tab.Controls.Add(markers(8))
                GetMyForm.tab.Controls.Add(markers(9))

            Else
                proj.ActiveForm.tab.Controls.Add(markers(8))
                proj.ActiveForm.tab.Controls.Add(markers(9))
            End If
        End If
        markers(8).Cursor = Cursors.SizeAll : markers(9).Cursor = Cursors.Hand
        ' �������� ������� �������, ����� �������� �� ����� ������ ������� �����
        HideMarker = New PictureBox : HideMarker.SendToBack()
        HideMarker.BackColor = Color.Transparent : HideMarker.Width = markerX : HideMarker.Height = markerY
        ' ����� ��������� ������ ������ � ���� �����
        If Iz.IsFORM(MyObj) Then
            SplitCont.Panel1.Controls.Add(HideMarker)
        ElseIf obj.TypeObj <> "PoluObj" And obj.TypeObj <> "IncludeObj" Then
            If obj.parent Is Nothing Then Exit Sub
            obj.parent.Controls.Add(HideMarker)
        End If
        ' �������� ������ � ������ ��������
        If fromEng = False Then AddNode()
        ' �������� ������ � ������� ������������
        If Iz.IsFORM(MyObj) = False And Iz.IsMMs(MyObj) = False And fromEng = False Then
            GetMyForm.HistoryLevelRun("�� �������� ����", MyObj)
        End If
        ' � � ����� ���� ����� ���������� �������
        obj_GotFocus(obj, New EventArgs)
        ' ��������� �������� �����
        If Iz.IsFORM(MyObj) Then
            If proj Is Nothing = False Then
                If proj.f Is Nothing = False Then
                    If fromEng Then ReDims(proj.f) : proj.f(proj.f.Length - 1) = MyObj : proj.activeform = MyObj
                    If proj.f.length > 2 Then MyObj.obj.Props.mainform = trans("���")
                    MyObj.SetActiveObject(Me) : MyObj.marker_vis(True)
                Else
                    If fromEng Then
                        Dim ff(0) As Forms : ff(0) = MyObj
                        proj.f = ff : proj.activeform = MyObj
                    End If
                End If
            End If
        End If
        If VstavkaOrCreate = False And proj Is Nothing = False And MyObj.obj.Props.name <> MyZnak & "none" And fromEng = False Then
            proj.UndoRedo("�������", "������", Perevodi.ToStrFromObj(MyObj, True, , , False))
        End If
    End Sub
    Function addTabPage(ByVal TabPage As TPages, Optional ByVal withUndo As Boolean = False, Optional ByVal isPaste As Boolean = False) As TPages
        Dim oldNam As String = TabPage.obj.Props.name
        If TabPage.obj.Props.name = MyZnak & "none" Then
            TabPage.obj.Props.name = proj.GiveName(obj.Props.name & " " & trans("��������"))
            TabPage.obj.Props.text = TabPage.obj.Props.name
        End If
        TabPage.conteiner = MyObj
        If GetMyForm() Is Nothing = False Then
            GetMyForm().AddObject(TabPage)
        End If
        obj.TabPages.Add(TabPage.obj)
        If oldNam = MyZnak & "none" Then
            TabPage.obj.Props.position = obj.TabPages.count - 1
        Else
            TabPage.obj.moveToPosition()
        End If
        If oldNam = MyZnak & "none" Then TabPage.NodeRefresh(MyZnak & "none")
        If withUndo Then
            proj.UndoRedo("�������", "������", Perevodi.ToStrFromObj(TabPage, True))
        End If
        Return TabPage
    End Function
    Function addMMenuItem(ByVal MMenus As MMenus, Optional ByVal withUndo As Boolean = False) As MMenus
        Dim oldNam As String = MMenus.obj.Props.name
        ' ��� �������� ������ ���� �� ���������, ��������� ����������� ����� � �����
        If MMenus.obj.Props.name = MyZnak & "none" Then
            MMenus.obj.Props.name = proj.GiveName(obj.Props.name & " " & trans("�����"))
            MMenus.obj.Props.text = MMenus.obj.Props.name
        End If
        ' ������� ������
        MMenus.conteiner = MyObj
        If GetMyForm() Is Nothing = False Then
            GetMyForm.AddObject(MMenus)
        End If
        ' ���������� ������ ���� ��������� � ���������
        Dim contCollec As System.Windows.Forms.ToolStripItemCollection
        If obj.GetType.ToString = ClassAplication & "MM" Or obj.GetType.ToString = ClassAplication & "runMM" _
        Or obj.GetType.ToString = ClassAplication & "CM" Or obj.GetType.ToString = ClassAplication & "runCM" _
        Or obj.GetType.ToString = ClassAplication & "TPl" Or obj.GetType.ToString = ClassAplication & "runTPl" _
        Then
            contCollec = obj.items
        Else
            contCollec = obj.DropDownItems
        End If
        ' ���������� ������ ���� � ���������
        contCollec.Add(MMenus.obj)
        ' ��������� ������� ������� ��� ����������� � ������� ��������� � �������� �������
        If oldNam = MyZnak & "none" Then
            MMenus.obj.Props.position = contCollec.Count - 1
        Else
            MMenus.obj.moveToPosition()
        End If
        If oldNam = MyZnak & "none" Then MMenus.NodeRefresh(MyZnak & "none")
        If withUndo Then
            proj.UndoRedo("�������", "������", Perevodi.ToStrFromObj(MMenus, True))
        End If
        ' ��� �������������� � ��������� ���� ����
        MMenus.obj.props.text = MMenus.obj.props.text
        Return MMenus
    End Function
    Function GetXY(ByVal obj As Object, ByVal cont As Object, ByVal na4alX As Integer, ByVal na4alY As Integer) As Point
        Dim i As Integer
        If proj.ActiveForm Is Nothing Then Exit Function
        If proj.ActiveForm.MyObjs Is Nothing = False Then
            ' ���� � na4x � na4y ��� ���� ������� ������ �� �������� ���������� � ������ �����
            For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                ' ������ ������������ � ���������, ����������� � ������������
                If proj.ActiveForm.MyObjs(i).obj.TypeObj = obj.TypeObj Then
                    If proj.ActiveForm.MyObjs(i).obj.left = na4alX And proj.ActiveForm.MyObjs(i).obj.Top = na4alY Then
                        Return GetXY(obj, cont, na4alX + setka, na4alY + setka)
                    End If
                End If
            Next
        End If
        If obj.TypeObj = "PoluObj" And na4alY > cont.height - obj.height Then '����������� �� ������ �������� �� ������
            Return GetXY(obj, cont, na4alX, na4alY - setka / 2)
        End If
        Return New Point(na4alX, na4alY)
    End Function
#End Region

    '<<<<<<<< ��������� �������� >>>>>>>>>
#Region "MARKERS SUBS"
    Private Sub markers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'cm.Close()
        MainForm.Peremeschatel.Focus()
        markers_perenos = Array.IndexOf(markers, sender) ' ������ �������� �������
        If markers_perenos = -1 Then Exit Sub
        mdx = e.X : mdy = e.Y  ' ��������� ������� � ����������� ��� �������� �����������
        proj.ActiveForm.marker_vis(False) ' ������ ��� �������
        SolvRaznica() ' ������� � ������� raznicaSize � raznicaLoc ������� ��������� � �������� �������� ������������ obj
        If markers_perenos = 8 And Iz.isNoMove(obj) Then proj.ActiveForm.marker_vis()
    End Sub
    Private Sub markers_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim i As Integer
        If markers_perenos = 8 And Iz.isNoMove(obj) Then Exit Sub
        If (mdx = e.X And mdy = e.Y) Or markers_perenos = 9 Then Exit Sub ' ���� �������� ����������� ������
        If markers_perenos <> -1 Then
            If Control.ModifierKeys = Keys.Control Then ' ���� ������������ ����, �� ���������� �� ���������
                markers(markers_perenos).Left = markers(markers_perenos).Left + e.X - mdx
                markers(markers_perenos).Top = markers(markers_perenos).Top + e.Y - mdy
            Else ' ���������� �� �����
                '  If obj.TypeObj<>"PoluObj" Then ' ��������� ����� �����, ��� �� ����� ��������������
                'markers(markers_perenos).Left = ((markers(markers_perenos).Left + e.X - mdx) \ setka) * setka
                'markers(markers_perenos).Top = ((markers(markers_perenos).Top + e.Y - mdy) \ setka) * setka
                'Else
                markers(markers_perenos).Left = ((markers(markers_perenos).Left + e.X - mdx) \ setka) * setka
                markers(markers_perenos).Top = ((markers(markers_perenos).Top + e.Y - mdy) \ setka) * setka
                ' End If
            End If
            ' ������ ������� � ���� �������� ��������
            For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
                Dim cx, cy As Integer
                cx = markers(markers_perenos).Left  ' - proj.ActiveForm.SplitCont.Panel1.HorizontalScroll.Value
                cy = markers(markers_perenos).Top '- proj.ActiveForm.SplitCont.Panel1.VerticalScroll.Value
                ' ���������� ��������� ����������
                Dim cont As Point = proj.ActiveForm.ContenerAbsXY(Me)
                ' � ������� ������ ���� ��������� � ����� ������ ������
                'If obj.Parent.Parent.GetType.ToString = ClassAplication & "DP" Then
                ' cx -= obj.Parent.Parent.ParentPanelLeft(obj)
                ' cy -= obj.Parent.Parent.ParentPanelTop(obj)
                ' Else
                cx -= cont.X : cy -= cont.Y
                'End If
                Dim aObj = proj.ActiveForm.ActiveObj(i).obj ' ���� �� �������� ��������
                Dim left = aObj.Left, top = aObj.Top, hei = aObj.height, wid As Double = aObj.Width
                Select Case markers_perenos
                    Case 0 ' ����� ������� ������, ������ ������� ������ ������ �������, � �� ���� ��������
                        wid = (obj.Left - cx) + obj.Width - markers(markers_perenos).Width - raznicaSize(i).X
                        hei = (obj.Top - cy) + obj.Height - markers(markers_perenos).Height - raznicaSize(i).Y
                        left = cx + markers(markers_perenos).Width - raznicaLoc(i).X
                        top = cy + markers(markers_perenos).Height - raznicaLoc(i).Y
                    Case 1
                        hei = (obj.Top - cy) + obj.Height - markers(markers_perenos).Height - raznicaSize(i).Y
                        top = cy + markers(markers_perenos).Height - raznicaLoc(i).Y
                    Case 2
                        wid = (cx - obj.Left) - raznicaSize(i).X + markers(markers_perenos).Width
                        hei = (obj.Top - cy) + obj.Height - markers(markers_perenos).Height - raznicaSize(i).Y
                        top = cy + markers(markers_perenos).Height - raznicaLoc(i).Y
                    Case 3
                        wid = (obj.Left - cx) + obj.Width - markers(markers_perenos).Width - raznicaSize(i).X
                        left = cx + markers(markers_perenos).Width - raznicaLoc(i).X
                    Case 4 ' ������ ������� ������, ������ ������� ���� �������� ��������
                        If aObj.TypeObj = "PoluObj" Then Exit Select
                        wid = cx - obj.Left - raznicaSize(i).X
                    Case 5
                        wid = (obj.Left - cx) + obj.Width - markers(markers_perenos).Width - raznicaSize(i).X
                        hei = cy - obj.Top - raznicaSize(i).Y + markers(markers_perenos).Height
                        left = cx + markers(markers_perenos).Width - raznicaLoc(i).X
                    Case 6
                        If aObj.TypeObj = "PoluObj" Then Exit Select
                        hei = cy - obj.Top - raznicaSize(i).Y + markers(markers_perenos).Height
                    Case 7
                        If aObj.TypeObj = "PoluObj" Then Exit Select
                        wid = cx - obj.Left - raznicaSize(i).X + markers(markers_perenos).Width
                        hei = cy - obj.Top - raznicaSize(i).Y + markers(markers_perenos).Height
                    Case 8 ' ������ ��� ����������� �������
                        left = cx - raznicaLoc(i).X - markerX
                        top = cy - raznicaLoc(i).Y + markers(markers_perenos).Height
                End Select
                If Control.ModifierKeys = Keys.Control Then ' ���� ������������ ����, �� ���������� �� ���������
                    aObj.Width = wid
                    aObj.Height = hei
                    aObj.Left = left
                    aObj.Top = top
                Else
                    aObj.Width = ((wid) \ setka) * setka + 3
                    aObj.Height = ((hei) \ setka) * setka + 3
                    aObj.Left = ((left) \ setka) * setka
                    aObj.Top = ((top) \ setka) * setka
                End If
            Next
        End If
    End Sub
    Private Sub markers_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If markers_perenos = 8 And Iz.isNoMove(obj) Then Exit Sub
        BackPoluObj(proj.ActiveForm.ActiveObj) ' ���� ���������� ���� �� ������� ����������, �� ������� ���
        proj.ActiveForm.marker_vis(True) ' ������� ������� ��������
        ' ��������� ������� �������
        If markers_perenos = 9 Then
            If e.Button = MouseButtons.Left Then
                MainForm.AddMenu_Click(Nothing, Nothing)
            ElseIf e.Button = MouseButtons.Right Then
                markers(markers_perenos).ContextMenuStrip.Show(markers(markers_perenos), 2, 2)
            End If
        Else
            If obj.TypeObj <> "PoluObj" Then ' ����� �������� �� ����� ������ ������� � �������� �������
                HideMarker.Left = obj.Left + obj.width - HideMarker.Width
                HideMarker.Top = obj.Top + obj.height - HideMarker.Height
                If Iz.IsFORM(MyObj) Then
                    HideMarker.Left += HideMarker.Width : HideMarker.Top += HideMarker.Height
                End If
                proj.ActiveForm.marker_vis(True)
            End If
            ' ���� ����������� ������� ����
            If mdx <> e.X Or mdy <> e.Y Then obj.ContextMenuStrip.visible = False : IzmenenieBylo()
        End If
        markers_perenos = -1
    End Sub
    Sub SolvRaznica()
        Dim i As Integer
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        ReDim raznicaSize(proj.ActiveForm.ActiveObj.Length - 1)
        ReDim raznicaLoc(proj.ActiveForm.ActiveObj.Length - 1)
        For i = 0 To raznicaSize.Length - 1
            raznicaSize(i).X = obj.width - proj.ActiveForm.ActiveObj(i).obj.width
            raznicaSize(i).Y = obj.Height - proj.ActiveForm.ActiveObj(i).obj.Height
            raznicaLoc(i).X = obj.left - proj.ActiveForm.ActiveObj(i).obj.left
            raznicaLoc(i).Y = obj.top - proj.ActiveForm.ActiveObj(i).obj.top
        Next
    End Sub
#End Region

    '<<<<<<<< ��������� ������� OBJ >>>>>>>>>
#Region "OBJ SUBS"
    Dim zashita As Boolean
    Public Sub obj_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ' ����� � ������ ������ ����������
            If Iz.isPanel(obj) Then
                na4Point = e.Location : click = True : Exit Sub
            End If
        End If
        ' �������� ������ ���� �� ����� ������� � ���� �� ����� ������� ��������������� (�� ����� ����)
        If (proj.ActiveForm.IsActiveObject(Me) = False And Control.ModifierKeys <> Keys.Control) Or proj.ActiveForm.ActiveObj Is Nothing Then

            proj.ActiveForm.SetActiveObject(Me)

            If Me.markers(8).Visible = False Then proj.ActiveForm.marker_vis(True)
        End If
        ' ���� �� ������ ������ �� ����� �������, �� �� �� �������, �� �������� ���
        If e.Button = MouseButtons.Left Or proj.ActiveForm.IsActiveObject(Me) = False Then
            perenos = True : dx = e.X : dy = e.Y : click = True
            If Iz.isMoveOnlyMarker(MyObj.obj) = False Then obj.Cursor = Cursors.NoMove2D ' proj.ActiveForm.marker_vis(False)
            SolvRaznica() ' ������� � ������� raznicaSize � raznicaLoc ������� ��������� � �������� �������� ������������ obj
        End If
        zashita = True
    End Sub
    Public Sub obj_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim i As Integer
        If Iz.isNoMove(obj) Then perenos = False : Exit Sub
        If Iz.isMoveOnlyMarker(MyObj.obj) Then Exit Sub
        If zashita = True Then zashita = False : dx = e.X : dy = e.Y : Exit Sub
        ' ����� � ������ ������ ����������
        If na4Point <> Nothing Then
            If Iz.isPanel(obj) Then
                click = False ': proj.ActiveForm.ClearActiveObject()
                endPoint = e.Location : sender.refresh()
            End If
            Exit Sub
        End If
        If perenos = True And (e.X <> dx Or e.Y <> dy) Then ' ���� ����������� ��������
            If proj.ActiveForm.ActiveObj Is Nothing Or raznicaLoc Is Nothing Then perenos = False : Exit Sub
            If Iz.isMoveOnlyMarker(sender) Then perenos = False : Exit Sub
            ' ����������� �������� ������� ������������ obj
            If raznicaLoc.Length = proj.ActiveForm.ActiveObj.length Then
                For i = 0 To raznicaLoc.Length - 1
                    If Iz.IsFORM(proj.ActiveForm.ActiveObj(i)) Then Continue For ' ����� ������ ����������
                    If Control.ModifierKeys = Keys.Control Then
                        proj.ActiveForm.ActiveObj(i).obj.Left = obj.Bounds.X + e.X - dx - raznicaLoc(i).X
                        proj.ActiveForm.ActiveObj(i).obj.Top = obj.Bounds.Y + e.Y - dy - raznicaLoc(i).Y
                    Else
                        proj.ActiveForm.ActiveObj(i).obj.Left = ((obj.Bounds.X + e.X - dx - raznicaLoc(i).X) \ setka) * setka
                        proj.ActiveForm.ActiveObj(i).obj.Top = ((obj.Bounds.Y + e.Y - dy - raznicaLoc(i).Y) \ setka) * setka
                    End If
                Next
                click = False ' ��� ���-�� ����������, �� ��� ��� �� ���� �� �������
            End If
        ElseIf perenos = False Then
            obj.Cursor = Cursori(obj.Props.cursor) 'Cursors.Default
        End If
    End Sub
    Public Sub obj_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim i As Integer
        'tree.Tag = "nelzya" : tree.SelectedNode = GetNode() : tree.Tag = ""
        perenos = False
        ' ���� ������, �� �������� ����������� �������������
        If e.Button = MouseButtons.Left Or proj.ActiveForm.IsActiveObject(Me) = False Then
            If Iz.isMoveOnlyMarker(MyObj.obj) Then Exit Sub
            If Iz.isPanel(obj) Then
                If click = False Then
                    With proj.ActiveForm
                        If Control.ModifierKeys <> Keys.Control Then .ClearActiveObject() ' ���� ������ ������ �������� ������
                        If .MyObjs Is Nothing = False Then
                            For i = 0 To .MyObjs.Length - 1
                                If .MyObjs(i).conteiner Is Nothing Then Continue For ' ���������� �����
                                If sender Is proj.ActiveForm.SplitCont.Panel2 Then ' ���� sender ������ ������������
                                    If .MyObjs(i).obj.TypeObj <> "PoluObj" Then Continue For ' ���������� �� �����������
                                Else
                                    If .MyObjs(i).obj.TypeObj = "PoluObj" Then Continue For ' ���������� �����������
                                End If

                                ' ���� ������ ��������� � ������ ��������� (�� ������� ������������� �������������) � ��� �� �������� ���� ����������
                                If (.MyObjs(i).obj.parent Is sender) And (.MyObjs(i).obj Is sender = False) Then
                                    ' ���� ������ ������ � ���������� ����, �� �������� ��� � ��������
                                    If .inRectangle(.MyObjs(i).obj, na4Point, endPoint) Then
                                        .AddActiveObject(proj.ActiveForm.MyObjs(i), True)
                                    End If
                                End If
                            Next
                            .FillListView()
                        End If
                        If sender Is proj.ActiveForm.SplitCont.Panel2 = False Then ' ���� sender �� ������ ������������
                            If .ActiveObj Is Nothing And click = False Then .SetActiveObject(Me)
                        End If
                    End With
                End If
                na4Point = Nothing : endPoint = Nothing : sender.refresh()
            End If
            na4Point = Nothing : endPoint = Nothing
            If click = True Then ' ���� ��� ��� ���� � �� �����������
                If Control.ModifierKeys = Keys.Control Then
                    proj.ActiveForm.AddActiveObject(Me)
                Else
                    If proj.ActiveForm.activeobj Is Nothing Then proj.ActiveForm.SetActiveObject(Me)
                    If proj.ActiveForm.activeobj(0) Is Me = False Then
                        proj.ActiveForm.SetActiveObject(Me)
                    End If
                End If

                ' ������� ��� ����� ��� �������� ����������� ���� ������������ ��������
                If Iz.IsCM(MyObj) Then MyObj.obj.CnMn.Show(obj, e.X, e.Y)
            Else
                BackPoluObj(proj.ActiveForm.ActiveObj) ' ���� ���������� ���� �� ������� ����������, �� ������� ���
            End If

            If obj.TypeObj <> "PoluObj" Then ' ����� �������� �� ����� ������ ������� � �������� �������
                HideMarker.Left = obj.Left + obj.width - HideMarker.Width
                HideMarker.Top = obj.Top + obj.height - HideMarker.Height
                If Iz.IsFORM(MyObj) Then
                    HideMarker.Left += HideMarker.Width : HideMarker.Top += HideMarker.Height
                End If
            End If
            perenos = False : proj.ActiveForm.marker_vis(True) : obj_GotFocus(sender, New EventArgs)
        End If
        If e.Button = MouseButtons.Right And Iz.IsMMs(MyObj) Then
            obj.Select()
            MainForm.ObjsMenu.Show(markers(9), 2, 2)
        End If
        HideMarker.SendToBack()
        IzmenenieBylo()
        obj_GotFocus(sender, e)
    End Sub
    Dim ob_cl As Object, tm As New Date
    Public Sub obj_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'System.Windows.Forms.MouseEventArgs)
        If ob_cl Is sender AndAlso Date.Now - tm <= New TimeSpan(4000000) Then
            obj_DoubleClick(sender, e)
        End If
        ob_cl = sender : tm = Now
    End Sub
    Public Sub obj_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) 'System.Windows.Forms.MouseEventArgs)
        MainForm.SelNodes = Nothing
        MainForm.SelNode = MyObj.getNode
        tree.SelectedNode = MyObj.getNode
        'MainForm.TreeView1_AfterSelect(sender, New TreeViewEventArgs(MyObj.getNode))
    End Sub
    Private Sub obj_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' �������� ����� �����. ���� ������������, ��� �� ����� ���� ��������� ��������� � ����������
        If Iz.isMoveOnlyMarker(MyObj.obj) = False Then MainForm.Peremeschatel.Focus()
    End Sub
    Sub BackPoluObj(ByVal ob() As Object) ' ���� ���������� ���� �� ������� ����������, �� ������� ���
        Dim i As Integer
        If ob Is Nothing Or proj.ActiveForm Is Nothing Then Exit Sub
        For i = 0 To ob.Length - 1
            If ob(i).obj.TypeObj = "PoluObj" Then
                If ob(i).obj.top < 0 Then ob(i).obj.top = 0
                If ob(i).obj.left < 0 Then ob(i).obj.left = 0
                If ob(i).obj.left > proj.ActiveForm.SplitCont.Width - ob(i).obj.Width Then ob(i).obj.left = proj.ActiveForm.SplitCont.Width - ob(i).obj.Width
                If ob(i).obj.top > proj.ActiveForm.SplitCont.Panel2.Height - ob(i).obj.Height Then ob(i).obj.top = proj.ActiveForm.SplitCont.Panel2.Height - ob(i).obj.Height
            End If
        Next
    End Sub
    Sub BackPoluObj(ByVal odin As Boolean, ByVal ob As Object)    ' ���� ���������� ���� �� ������� ����������, �� ������� ���
        Dim o(0) As Object : o(0) = ob : BackPoluObj(o)
    End Sub
    Private Sub obj_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        obj_ResizeNado(sender, New EventArgs) : proj.ActiveForm.Scroll(sender, e)
    End Sub
    Private Sub obj_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        ' IzmenenieBylo()
    End Sub
    Public Sub obj_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        If na4Point <> Nothing Then
            Dim ppp(3) As Point
            ppp(0) = na4Point : ppp(1) = New Point(endPoint.X, na4Point.Y)
            ppp(2) = endPoint : ppp(3) = New Point(na4Point.X, endPoint.Y)
            e.Graphics.DrawPolygon(Pens.Black, ppp)
        End If
        If obj.Props.index <> "0" Then 'Or proj.ExistName(obj.Props.name, obj) Then
            If Iz.IsM(MyObj) Then ' � ������ ����� ������
                e.Graphics.FillRectangle(Brushes.White, 2, 2, (obj.Props.index.length + 2) * 3, 6)
                e.Graphics.DrawString("(" & obj.Props.index & ")", New Font("Arial", 6), Brushes.Black, 0, 0)
            Else
                e.Graphics.FillRectangle(Brushes.White, 4, 4, (obj.Props.index.length + 2) * 3, 6)
                e.Graphics.DrawString("(" & obj.Props.index & ")", New Font("Arial", 6), Brushes.Black, 2, 2)
                e.Graphics.DrawString(obj.Props.name, New Font("Arial", 6, FontStyle.Bold), Brushes.Black, 2, obj.height - 6 * 2)
            End If
        End If
        If Iz.IsMMs(MyObj) Then
            If proj.activeform.IsActiveObject(MyObj) Then
                e.Graphics.DrawRectangle(Pens.Black, 3, 3, obj.width - 6, obj.height - 6)
            End If
        End If
        ' ��������� ����� �� �����
        If (Iz.isPanel(sender)) Then
            Dim drawSetka As Integer = setka * 2
            Dim pn As New Pen(Color.Black, 1), i As Integer
            pn.DashStyle = Drawing2D.DashStyle.Dot
            pn.DashPattern = New Single() {1, drawSetka - 1}
            For i = 0 To obj.Height / drawSetka
                e.Graphics.DrawLine(pn, +1, i * drawSetka + 1, obj.width, i * drawSetka + 1)
            Next
        End If
    End Sub
    Public Sub Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        MyObj.marker_vis(False) : MainForm.Timer1.Start()
    End Sub
    Private Sub SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs)
        MyObj.marker_vis(True)
    End Sub
    Private Sub obj_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs)
        IzmenenieBylo()
    End Sub
    Private Sub obj_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        MyObj.obj.Visible = False : MyObj.obj.Visible = True
    End Sub
    Private Sub obj_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' ���� ������ �� ����������� ������
        If obj.Props.semaforSelect = False Then
            IzmenenieByloExpert()
        End If
    End Sub
    Private Sub obj_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IzmenenieBylo()
    End Sub

#End Region

    '<<<<<<<< RUN-��������� ������� OBJ >>>>>>>>>
#Region "RUN OBJ SUBS"
    Sub RunSobyt(ByVal sender As Object, ByVal sobyt As String, ByVal e As Object, ByVal type As System.Type)
        Dim es As ErrString
        If tree Is Nothing Or peremens.isRUN = False Then Exit Sub
        ' ���� � ���� ������� ������ �������
        Dim eventNode As TreeNode = proj.FindSobyt(sobyt, GetNode(, True))
        If eventNode Is Nothing Then Exit Sub
        ' ��������� ��������� �������
        Try
            es = proj.RunBlock(eventNode, 0, New PropertysSobyt(sender, e, type), True)
            If es.err <> "" Then Errors.MessangeCritic(es.err)
        Catch ex As Exception
            If IgnorEr = False Then
                Dim deist As String
                If peremens.isRUN Then
                    If proj.NowNode Is Nothing = False Then
                        deist = vbCrLf & trans("��������") & ": """ & proj.NowNode.text & """"
                    End If
                End If
                Errors.MessangeCritic(ex.Message & vbCrLf & trans("�������") & ": """ & eventNode.FullPath & """" & deist)
            Else
                If proj.NowNode Is Nothing = False Then
                    proj.RunBlock(proj.NowNode, 0, New PropertysSobyt(sender, e, type), True)
                End If
            End If
        End Try
        proj.recurs = 0
    End Sub

    ' ������� ����
    Public Sub obj_ClickRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("����"), e, e.GetType)
    End Sub
    Public Sub obj_MouseDownRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RunSobyt(MyObj, trans("������� ������ ����"), e, e.GetType)
    End Sub
    Public Sub obj_MouseUpRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RunSobyt(MyObj, trans("������� ������ ����"), e, e.GetType)
    End Sub
    Public Sub obj_MouseMoveRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If proj.alreadyRun Then Exit Sub
        RunSobyt(MyObj, trans("�������� �������"), e, e.GetType)
    End Sub
    Public Sub obj_MouseEnterRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� �������"), e, e.GetType)
    End Sub
    Public Sub obj_MouseLeaveRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� �������"), e, e.GetType)
    End Sub
    Public Sub obj_MouseHoverRun(ByVal sender As Object, ByVal e As System.EventArgs)
        If proj.alreadyRun Then Exit Sub
        RunSobyt(MyObj, trans("������ �� �������"), e, e.GetType)
    End Sub
    Public Sub obj_MouseWheelRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RunSobyt(MyObj, trans("�������� ��������"), e, e.GetType)
    End Sub
    Public Sub obj_DoubleClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RunSobyt(MyObj, trans("������� ����"), e, e.GetType)
    End Sub

    ' ������� ����������
    Private Sub obj_KeyPressRun(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = TextBoxAllow(sender, e)
        If e.Handled Then Exit Sub
        RunSobyt(MyObj, trans("������� ����������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� ����"))) = trans("��") Then e.Handled = True
        End If
    End Sub
    Private Sub obj_KeyDownRun(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        RunSobyt(MyObj, trans("������� ���� ������"), e, e.GetType)
    End Sub
    Private Sub obj_KeyUpRun(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        RunSobyt(MyObj, trans("������� ������"), e, e.GetType)
    End Sub

    ' ������� ����
    Private Sub obj_DropDownClosedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ���� ���������"), e, e.GetType)
    End Sub
    Private Sub obj_DropDownOpenedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ���� ���������"), e, e.GetType)
    End Sub
    Private Sub obj_DropDownOpeningRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ���� �����������"), e, e.GetType)
    End Sub

    ' ������ �������
    Private Sub obj_TextChangedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ������"), e, e.GetType)
    End Sub
    Public Sub obj_GotFocusRun(ByVal sender As Object, ByVal e As System.EventArgs)
        If proj.isINITIALIZATED = False Then
            RunSobyt(MyObj, trans("��������� ������"), e, e.GetType)
        End If
    End Sub
    Private Sub obj_LostFocusRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("������ ������"), e, e.GetType)
    End Sub
    Public Sub obj_PaintRun(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        If proj.isINITIALIZATED = False Then
            ' If proj.alreadyRun Then Exit Sub
            RunSobyt(MyObj, trans("����������"), e, e.GetType)
        End If
    End Sub
    Public Sub obj_LoadRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("��������"), e, e.GetType)
    End Sub
    Public Sub obj_ScrollRun(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        RunSobyt(MyObj, trans("���������"), e, e.GetType)
    End Sub
    Public Sub obj_ScrollRun1(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        RunSobyt(MyObj, trans("���������1"), e, e.GetType)
    End Sub
    Public Sub obj_ScrollRun2(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        RunSobyt(MyObj, trans("���������2"), e, e.GetType)
    End Sub
    Public Sub obj_ScrollRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("�������� �������"), e, e.GetType)
    End Sub
    Public Sub obj_ResizeRun(ByVal sender As Object, ByVal e As System.EventArgs)
        ' obj.props.height = obj.height
        '  obj.props.width = obj.width
    End Sub
    'Private Sub obj_DisposedRun(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If UCase(obj.Props.mainForm) = UCase(trans("��")) Then proj.StopProject()
    'End Sub
    Private Sub obj_FormClosingRun(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        RunSobyt(MyObj, trans("�������� ����"), New EventArgs, (New EventArgs).GetType)
        If UCase(obj.Props.ForbidClose) = UCase(trans("��")) Then e.Cancel = True : Exit Sub
        If UCase(obj.Props.mainForm) = UCase(trans("��")) And proj.isCLOSING = False Then
            obj.hide() : HookStops()
            ' ��������� ���� ����� ����� ������ ������� StopProject �.�. ������ �������� � ��������� ���������� �� � ���� ������
            If proj.isPotok Then proj.StopPr = True Else proj.StopProject()
        Else
            ' ���� ������� ������� � ������ ������ �������� ����
            If proj.isONLYFORM Then
                If proj.isPotok Then proj.StopPr = True Else proj.StopProject()
                Exit Sub
            End If

            e.Cancel = True : obj.hide()
        End If
    End Sub
    'Private Sub obj_ClosingRun(ByRef cancel As Boolean)
    'End Sub
    Private Sub obj_SplitterMovedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs)
        '  obj.props.SplitterDistance = obj.SplitterDistance
        RunSobyt(MyObj, trans("����������� ���������"), e, e.GetType)
    End Sub
    Private Sub obj_SplitterMovingRun(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs)
        'obj.props.SplitterDistance = obj.SplitterDistance
        RunSobyt(MyObj, trans("����������� ������������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� �����������"))) = trans("��") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_SizeChangedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        If Iz.IsFORM(MyObj) Then If MyObj.MyObjs Is Nothing Then Exit Sub
        RunSobyt(MyObj, trans("���������� �������"), e, e.GetType)
    End Sub
    Private Sub obj_VisibleChangedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        If proj.isINITIALIZATED = False Then
            RunSobyt(MyObj, trans("���������� ���������"), e, e.GetType)
        End If
    End Sub

    ' ������� ��������
    Private Sub WebBrowser1_CanGoBackChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("����� ����� ����������"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_CanGoForwardChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("������ ����� ����������"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        RunSobyt(MyObj, trans("�������� �����������"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_FileDownload(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("�������� �����������"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs)
        RunSobyt(MyObj, trans("������� �� ������"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs)
        RunSobyt(MyObj, trans("��������� �� ������"), e, e.GetType)
    End Sub

    Private Sub WebBrowser1_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        RunSobyt(MyObj, trans("�������� � ����� ����"), e, e.GetType)
        'If proj.Param.ParamyUp Is Nothing = False Then
        '    If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� � ����� ����"))) = trans("��") Then e.Cancel = True
        'End If
    End Sub
    Private Sub WebBrowser1_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ������ ����������"), e, e.GetType)
    End Sub
    '' ������ ��� �������� ��� �������� � ���� ����.�������
    'Dim brw, frm, ob, indx As String
    'brw = obj.props.OpenNewWindowLink
    '' ��������� ��� �� ��� ���� � ��� ��������
    'Dim spl() As String = brw.Split(".")
    'If spl.Length <> 2 Then Errors.MessangeExclamen(Errors.InvalidWebBrowser(brw)) : Exit Sub
    '' ������� ��������������� ���
    'frm = spl(0)
    'ob = spl(1)
    'indx = 0
    '' ���� ������� � ��������, �� ������� ��� �� �����
    'If ob.IndexOf("[") <> -1 Then
    '    If ob.IndexOf("]") = -1 Then Errors.MessangeExclamen(Errors.InvalidWebBrowser(brw)) : Exit Sub
    '    indx = ob.Split("[")(1).Split("]")(0)
    '    ob = ob.Split("[")(0)
    'End If


    ' ������� ��������
    Private Sub TabControl_Deselected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs)
        RunSobyt(MyObj, trans("������� ��������� ��������"), e, e.GetType)
    End Sub
    Private Sub TabControl_Deselecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
        RunSobyt(MyObj, trans("��������� ��������� ��������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� �������"))) = trans("��") Then e.Cancel = True
        End If
    End Sub
    Private Sub TabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("�������� ��������"), e, e.GetType)
    End Sub
    Private Sub TabControl_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
        RunSobyt(MyObj, trans("�������� ��������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� �������"))) = trans("��") Then e.Cancel = True
        End If
    End Sub

    ' ������� ������
    Private Sub Table_SelectionChangedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("���������� ���������"), e, e.GetType)
    End Sub
    Private Sub Table_CellBeginEditRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        RunSobyt(MyObj, trans("������ �������������� ������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� �������"))) = trans("��") Then e.Cancel = True
        End If
    End Sub
    Private Sub Table_CellClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("���� �� ������"), e, e.GetType)
    End Sub
    Private Sub Table_CellMouseDownRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            If obj.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True Then
                RunSobyt(MyObj, trans("���� �� ���������� ������"), e, e.GetType)
            End If
        End If
    End Sub
    Private Sub Table_CellDoubleClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("������� ���� �� ������"), e, e.GetType)
    End Sub
    Private Sub Table_CellEndEditRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("����� �������������� �����"), e, e.GetType)
    End Sub
    Private Sub Table_CellEnterRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("������ � ������"), e, e.GetType)
    End Sub
    Private Sub Table_CellLeaveRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("����� �������� �����"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnDisplayIndexChangedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
        RunSobyt(MyObj, trans("������� �����������"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnHeaderMouseClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        RunSobyt(MyObj, trans("���� �� ��������� �������"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnHeaderMouseDoubleClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        RunSobyt(MyObj, trans("������� ���� �� ��������� �������"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnSortModeChangedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
        RunSobyt(MyObj, trans("���������� �������"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnWidthChangedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
        RunSobyt(MyObj, trans("���������� ������ �������"), e, e.GetType)
    End Sub
    Private Sub Table_RowHeaderMouseClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        RunSobyt(MyObj, trans("���� �� ��������� ������"), e, e.GetType)
    End Sub
    Private Sub Table_RowHeightChangedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        RunSobyt(MyObj, trans("���������� ������ ������"), e, e.GetType)
    End Sub
    Private Sub Table_RowsAddedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        If obj.props.isSelecExecute = False Then RunSobyt(MyObj, trans("������� ������"), e, e.GetType)
    End Sub
    Private Sub Table_RowsRemovedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        If obj.props.isSelecExecute = False Then RunSobyt(MyObj, trans("������� ������"), e, e.GetType)
    End Sub

    ' ������� ������ � ����������
    Private Sub obj_SelectedIndexChangedRun(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ��������� ������"), e, e.GetType)
    End Sub
    Private Sub obj_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If DaOrNet(MyObj.obj.props.InternetLink) Then MyObj.obj.props.GoInternetLink()
        RunSobyt(MyObj, trans("���� �� ������"), e, e.GetType)
    End Sub

    ' ������� ���������
    Private Sub obj_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ��������"), e, e.GetType)
    End Sub
    Private Sub obj_DropDown(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ���������"), e, e.GetType)
    End Sub
    Private Sub obj_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("�������� ����������"), e, e.GetType)
    End Sub

    ' ����������� ����
    Private Sub obj_OpeningRun(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        RunSobyt(MyObj, trans("��������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� �������"))) = trans("��") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_ClosedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs)
        RunSobyt(MyObj, trans("���������"), e, e.GetType)
    End Sub
    Private Sub obj_ClosingRun(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs)
        RunSobyt(MyObj, trans("��������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� �������"))) = trans("��") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_OpenedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("���������"), e, e.GetType)
    End Sub

    '  ������-������
    Private Sub obj_ConnectedToServerRun(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs)
        RunSobyt(MyObj, trans("�������������� � �������"), e, e.GetType)
    End Sub
    Private Sub obj_ConnectionClientRun(ByVal sender As Object, ByVal e As WinsockConnectionRequestEventArgs)
        RunSobyt(MyObj, trans("������������� ������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� �������"))) = trans("��") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_CountChangedRun(ByVal sender As Object, ByVal e As WinsockCollectionCountChangedEventArgs)
        RunSobyt(MyObj, trans("���������� ����� ��������"), e, e.GetType)
    End Sub
    Private Sub obj_TextReceivedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("������ �����"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_CommandReceivedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("������ �������"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_FileReceivedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("������ ����"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_DisconnectedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("����������"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_ErrorReceivedRun(ByVal sender As Object, ByVal e As WinsockErrorReceivedEventArgs)
        RunSobyt(MyObj, trans("��������� ������"), e, e.GetType)
    End Sub
    Private Sub obj_SendTextCompleteRun(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
        RunSobyt(MyObj, trans("���������� �����"), e, e.GetType)
    End Sub
    Private Sub obj_SendFileCompleteRun(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
        RunSobyt(MyObj, trans("���������� ����"), e, e.GetType)
    End Sub
    Private Sub obj_SendProgressRun(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
        RunSobyt(MyObj, trans("���� �����������"), e, e.GetType)
    End Sub
    Private Sub obj_ReceiveProgressRun(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs)
        RunSobyt(MyObj, trans("���� ����� ������"), e, e.GetType)
    End Sub
    Private Sub obj_StateChangedRun(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs)
        RunSobyt(MyObj, trans("��������� ������"), e, e.GetType)
    End Sub

    ' ��������
    Private Sub obj_SendingQueryRun(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        RunSobyt(MyObj, trans("������������ ������"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� �������"))) = trans("��") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_SentQueryRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("���������� ������"), e, e.GetType)
    End Sub
    Private Sub obj_ReceivedResponseRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("������ �����"), e, e.GetType)
    End Sub
    Private Sub obj_DownloadCancelledRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("�������� ��������"), e, e.GetType)
    End Sub

    ' ������
    Sub Minimize(ByVal s As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("������������"), Nothing, Me.GetType)
    End Sub
    Sub DoubleClickTray(ByVal s As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("������� ���� �� ����"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_ChangingValueRun(ByVal sender As Object, ByVal e As String)
        RunSobyt(MyObj, trans("��������� ��������"), e, e.GetType)
    End Sub
    Private Sub obj_ChangedValueRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("���������� ��������"), e, e.GetType)
    End Sub
    Private Sub obj_OnEndRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("����� ������������"), Nothing, Me.GetType)
    End Sub
    Public Sub obj_CheckedChangedRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("��������� �������"), e, e.GetType)
    End Sub
    Private Sub obj_HScroll(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("�������������� ���������"), e, e.GetType)
    End Sub
    Private Sub obj_VScroll(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("������������ ���������"), e, e.GetType)
    End Sub
    Private Sub obj_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs)
        If DaOrNet(MyObj.obj.props.InternetLink) Then MyObj.obj.props.GoInternetLink(e.LinkText)
        RunSobyt(MyObj, trans("���� �� ������ ���������"), e, e.GetType)
    End Sub
    Private Sub obj_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If proj.alreadyRun Then Exit Sub
        obj.props.IntervalCount += 1
        RunSobyt(MyObj, trans("������"), e, e.GetType)
    End Sub
    Public Sub obj_ClickButtonRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("���� ������"), e, e.GetType)
    End Sub
    Public Sub obj_ActivationSuccessulRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ��������"), e, e.GetType)
    End Sub
    Public Sub obj_ActivationFailedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("��������� ���������"), e, e.GetType)
    End Sub

    ' ������
    Private Sub obj_DisposedNado(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Integer
        If Iz.IsFORM(MyObj) Then
            For i = 0 To MyObj.MyObjs.length - 1
                If Iz.isPoluObj(MyObj.MyObjs(i).obj) Then MyObj.MyObjs(i).obj.Dispose()
            Next
        End If
        If Iz.IsMd(MyObj) Or Iz.IsA(MyObj) Then obj.props.CloseMovie()
    End Sub
    Private Sub obj_ResizeNado(ByVal sender As Object, ByVal e As System.EventArgs)
        If Iz.IsMd(MyObj) Then obj.props.fit()
    End Sub
    Private Sub WebBrowser_NewWindowNado(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("�������� � ����� ����"))) = trans("��") Then
                proj.Param.ParamyUp(UCase(MyZnak & trans("�������� � ����� ����"))) = ""
                e.Cancel = True : Exit Sub
            End If
        End If
        If e.Cancel = False And obj.lastLink <> "" Then
            If UCase(obj.props.OpenNewWindowLink) = UCase(trans("� ������ ��������")) Then
                obj.Navigate(obj.lastlink)
                e.Cancel = True
            ElseIf UCase(obj.props.OpenNewWindowLink) = UCase(trans("�� ���������")) Then
            Else
                ' ������� �������� ���������� �������
                Dim brws As Object = RunProj.GetObjFromUniqName(obj.props.OpenNewWindowLink)
                If brws Is Nothing Then Errors.MessangeExclamen(Errors.InvalidWebBrowser(obj.props.OpenNewWindowLink)) : Exit Sub
                brws.props.Url = obj.lastLink
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub WebBrowser_StatusTextChangedNado(ByVal sender As Object, ByVal e As System.EventArgs)
        If obj.StatusText <> "" Then
            If Uri.IsWellFormedUriString(obj.StatusText, UriKind.RelativeOrAbsolute) Then obj.lastLink = obj.StatusText
        End If
    End Sub
#End Region

    '<<<<<<<< �������� >>>>>>>>>
#Region "DEISTVIA"
    Sub AddNode(Optional ByVal name As String = "", Optional ByVal index As Integer = -1)
        If name = "" Then name = obj.Props.name
        If Iz.IsFORM(MyObj) = False Then
            If GetMyForm() Is Nothing Then Exit Sub
            If GetMyForm.GetNode Is Nothing Then Exit Sub
            If GetMyForm.GetNode.Nodes(name) Is Nothing Then
                If index < 0 Or index > GetMyForm.GetNode.Nodes.Count Then
                    index = GetMyForm.GetNode.Nodes.Count
                End If
                If NodeTemp Is Nothing = False Then
                    GetMyForm.GetNode.Nodes.Insert(index, NodeTemp)
                    GetMyForm.GetNode.Nodes(index).Tag = "Obj"
                    NodeTemp = Nothing
                Else
                    GetMyForm.GetNode.Nodes.Insert(index, name, name, MyObj.picture, MyObj.picture)
                    GetMyForm.GetNode.Nodes(index).Tag = "Obj"
                End If
                GetMyForm.GetNode.Expand()
            End If
        Else
            If index < 0 Or index > tree.Nodes.Count Then
                index = tree.Nodes.Count
            End If
            If tree.Nodes(name) Is Nothing = False Then Exit Sub
            tree.Nodes.Insert(index, name, name, MyObj.picture, MyObj.picture)
            tree.Nodes(index).Tag = "Obj"
            If NodeTemp Is Nothing = False Then
                If NodeTemp.TreeView Is Nothing = False Then NodeTemp.Remove()
                tree.Nodes(name).Nodes.Add(NodeTemp)
                tree.Nodes(index).Nodes(0).Tag = "Obj"
                NodeTemp = Nothing
            Else
                tree.Nodes(name).Nodes.Add(name, name, MyObj.picture, MyObj.picture)
                tree.Nodes(name).Nodes(0).Tag = "Obj"
            End If
            ' Tree.Nodes(name).Expand()
        End If
    End Sub
    Sub RemoveNode(Optional ByVal name As String = "", Optional ByVal isObj As Boolean = False)
        If name = "" Then name = obj.Props.name
        If Iz.IsFORM(MyObj) = False Or isObj = True Then
            GetMyForm.GetNode.Nodes.RemoveByKey(name)
        Else
            tree.Nodes(name).Nodes.RemoveByKey(name)
        End If
    End Sub
    Function ExistNode(Optional ByVal name As String = "", Optional ByVal oldName As String = "") As Boolean
        If name = "" Then name = obj.Props.name
        Try
            If Iz.IsFORM(MyObj) = False Or oldName <> "" Then
                If Iz.IsFORM(MyObj) = False Then oldName = ""
                If oldName = "" Then
                    If GetMyForm.GetNode.Nodes(name) Is Nothing Then Return False
                Else
                    If tree.Nodes(oldName).Nodes(name) Is Nothing Then Return False
                End If
            Else
                If tree.Nodes(name) Is Nothing Then Return False
                'If Tree.Nodes(name).Nodes(name) Is Nothing Then  Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Function GetNode(Optional ByVal name As String = "", Optional ByVal withObj As Boolean = False) As Object
        If name = "" Then name = obj.Props.name
        If name = "" Then Return Nothing
        If Iz.IsFORM(MyObj) = False Then
            Dim frm As Object = GetMyForm()
            If frm Is Nothing Then Return Nothing
            If frm.GetNode Is Nothing Then Return Nothing
            Return frm.GetNode.Nodes(name)
        Else
            If withObj = False Then
                Return tree.Nodes(name)
            Else
                If tree.Nodes(name) Is Nothing = False Then
                    Return tree.Nodes(name).Nodes(name)
                Else
                    Return Nothing
                End If
            End If
        End If
    End Function
    Function GetMyForm(Optional ByVal withNothing As Boolean = False) As Forms
        If MyForm IsNot Nothing Then If isRun = True Then Return MyForm
        If isPoleznie(MyObj.obj) Then MyForm = peremens2.proj.f(peremens2.proj.f.Length - 1) : Return MyForm
        Dim cont = MyObj, i, j As Integer
        If Iz.IsCM(cont.conteiner) Then MyForm = cont.conteiner.GetMyForm : Return MyForm
        If obj.TypeObj = "PoluObj" Then ' ����������� ����� ��� ������������
            If MyObj.conteiner Is Nothing = False Then
                If Iz.IsFORM(MyObj.conteiner) Then MyForm = MyObj.conteiner : Return MyForm
            End If
            If proj.f Is Nothing Then Return Nothing
            For i = 0 To proj.f.Length - 1
                If MyObj.conteiner Is Nothing = False Then
                    If MyObj.conteiner.parent Is proj.f(i).splitcont Then MyForm = proj.f(i).MyObjs(0) : Return MyForm
                End If
                For j = 0 To proj.f(i).MyObjs.Length - 1
                    If MyObj Is proj.f(i).MyObjs(j) Then If Iz.IsFORM(proj.f(i).MyObjs(0)) Then MyForm = proj.f(i).MyObjs(0) : Return MyForm
                Next
            Next
            ' ���� ������ �� � �������
            If proj.ActiveForm Is Nothing = False Then Return Nothing
            ' ���� ������ run
            MyForm = proj.f(proj.f.Length - 1) : Return MyForm
        Else ' ����������� ����� ��� ������� ��������
            Dim iters As Integer
            While cont.conteiner Is Nothing = False
                cont = cont.conteiner
                If Iz.IsCM(cont) Then MyForm = cont.GetMyForm : Return MyForm
                iters += 1
                If iters > 200 Then Throw New Exception("������ ������� " + cont.conteiner.NodeTemp.Text)
            End While
            If cont.obj.TypeObj = "IncludeObj" And withNothing = False Then MyForm = proj.ActiveForm : Return MyForm
            If Iz.IsFORM(MyObj) Then MyForm = cont : Return MyForm
            If Iz.IsFORM(cont) Then MyForm = cont : Return MyForm
            If obj.parent Is Nothing Then
                If proj.f Is Nothing Then Return Nothing
                For i = 0 To proj.f.Length - 1
                    For j = 0 To proj.f(i).MyObjs.Length - 1
                        If MyObj Is proj.f(i).MyObjs(j) Then MyForm = proj.f(i).MyObjs(0) : Return MyForm
                    Next
                Next
                If withNothing Then Return Nothing
                MyForm = proj.ActiveForm : Return MyForm
            End If
            If cont.GetType.ToString = ClassAplication & "Forms" Then MyForm = cont : Return MyForm Else Return Nothing
        End If
    End Function
    Sub NodeRefresh(Optional ByVal oldName As String = Nothing)
        Dim name As String = obj.Props.name ', i, j As Integer
        If oldName = Nothing Then oldName = obj.Props.name
        If ExistNode(oldName) = False Then Exit Sub
        ' ���������� �����
        ' ���� ����� � ����� ������ ��� �� ���������� ��� � ���������������
        If ExistNode(name, oldName) = False Or name <> oldName Then
            Dim temp
            Try
                temp = MyObj.GetNode(MyObj)
            Catch ex As Exception
                temp = Nothing
            End Try
            proj.PerebrosatTreeNodes(temp, MyObj.GetNode(oldName), MyObj)
        End If
    End Sub
#End Region

    Public Sub New()
        If isHelp Then Exit Sub
        Try
            If isDevelop = False Then tree = RunProj.tree : Exit Sub
            tree = MainForm.TreeView
        Catch ex As Exception
            Try
                tree = MnFrm.TreeView
            Catch exp As Exception
                End
            End Try
        End Try
    End Sub
End Class
