Public Class Objetus
    Public eventObj As Windows.Forms.Control ' Переменная для объкта, что бы можно было ему задать события
    Public obj, MyObj, MyForm As Object ' Переменая где собственно и хранится объект 
    Public conteiner As Object ' Контейнер объекта как мой класс, а не Windows.Forms.Control
    Dim click As Boolean
    Public dx, dy, mdx, mdy As Integer
    Dim markers_perenos As Integer = -1
    Public markers(MarkCount - 1) As PictureBox
    Dim raznicaSize(), raznicaLoc() As Point
    Public HideMarker As PictureBox ' Маркеры для того, чтобы не мешал скролинг изменять размеры и положение
    Public na4Point, endPoint As Point ' Начальная точки прямоугольника и его размер
    Public NodeTemp As TreeNode ' хранит узел при копировании
    Public ParentTemp, IndexTemp As String ' хранит куда добавлять узел при копировании
    Public HistoryTemp As String  ' хранит уровень хисторилевела
    Public OldFormTemp As String  ' хранит прошлую форму объекта
    Public VstavkaOrCreate As Boolean ' вставляется ли сейчас объект или просто создается новый
    Public SplitCont As Windows.Forms.SplitContainer 'делит пространство между формой и полуобъектами
    Public Sobytia(), VBname As String
    Public tree As TreeView
    Public proj As Object = proj
    Public isRun As Boolean
    Public ToolTipa As ToolTip

    '<<<<<<<< СОЗДАНИЕ ОБЪЕКТА >>>>>>>>>
#Region "CREATE"
    Public Sub CreateObject(ByVal ob As Object, Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False) ' Создание нового объкта
        Dim i As Integer, cont As Object
        If isRun = False Then proj = peremens2.proj
        If proj Is Nothing = False Then
            If proj.f Is Nothing = False Then
                ' Чтобы когда удалили все формы (кроме полезн.объектов) нельзя было создавать кнопки, панели и т.д.
                If proj.f.Length <= 1 And ob.GetType.ToString <> ClassAplication & "F" And holostoi = False Then Exit Sub
            End If
        End If
        ' Настройка и размещение созданного объкта
        obj = ob : MyObj = Me : Me.isRun = isRun : obj.MyObj = MyObj
        ' Пункт не может быть типом Контрол
        If isHelp Then Exit Sub
        If Iz.IsMMs(MyObj) = False Then
            If Iz.isNoControlObj(obj) = False Then eventObj = obj
            If isRun = False And proj Is Nothing = False And isDevelop And Not (IsHttpCompil) Then obj.ContextMenuStrip = MnFrm.ObjsMenu
        End If
        If obj.TypeObj = "Polezniy" Then Exit Sub
        If Iz.IsFORM(MyObj) And isRun = False Then
            If MyObj.tab Is Nothing Then
                ' Создание и настройка таба
                MyObj.tab = New TabPage(obj.Props.Name) : MyObj.tab.Name = obj.Props.name : MyObj.tab.BackColor = Color.White
                MyObj.tab.UseVisualStyleBackColor = True
            End If
        End If

        ToolTipa = New ToolTip(New System.ComponentModel.Container)

        If isRun Then
            If Iz.IsMMs(MyObj) Then
                ' У элементов меню евентОбъект свой
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
                ' У контекстного меню свой евент
                Dim eventObj As ContextMenuStrip = ob.cnmn
                AddHandler eventObj.Opening, AddressOf obj_OpeningRun
                AddHandler eventObj.Opened, AddressOf obj_OpenedRun
                AddHandler eventObj.Closing, AddressOf obj_ClosingRun
                AddHandler eventObj.Closed, AddressOf obj_ClosedRun
            ElseIf Iz.IsDP(MyObj) Then
                ' У двойной панели свои события
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


                ' Мышь
                If Array.IndexOf(Sobytia, trans("Клик").ToUpper) <> -1 Then
                    AddHandler eventObj.Click, AddressOf obj_ClickRun
                End If
                If Array.IndexOf(Sobytia, trans("Нажатие кнопки мыши").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseDown, AddressOf obj_MouseDownRun
                End If
                If Array.IndexOf(Sobytia, trans("Отжатие кнопки мыши").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseUp, AddressOf obj_MouseUpRun
                End If
                If Array.IndexOf(Sobytia, trans("Наведение курсора").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseEnter, AddressOf obj_MouseEnterRun
                End If
                If Array.IndexOf(Sobytia, trans("Отведение курсора").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseLeave, AddressOf obj_MouseLeaveRun
                End If
                If Array.IndexOf(Sobytia, trans("Курсор на объекте").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseHover, AddressOf obj_MouseHoverRun
                End If
                If Array.IndexOf(Sobytia, trans("Движение курсора").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseMove, AddressOf obj_MouseMoveRun
                End If
                If Array.IndexOf(Sobytia, trans("Двойной клик").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseDoubleClick, AddressOf obj_DoubleClickRun
                End If
                If Array.IndexOf(Sobytia, trans("Вращение колесика").ToUpper) <> -1 Then
                    AddHandler eventObj.MouseWheel, AddressOf obj_MouseWheelRun
                End If

                ' Клавиатура
                If Array.IndexOf(Sobytia, trans("Нажатие клавиатуры").ToUpper) <> -1 Then
                    AddHandler eventObj.KeyPress, AddressOf obj_KeyPressRun
                End If
                If Array.IndexOf(Sobytia, trans("Нажатие вниз кнопки").ToUpper) <> -1 Then
                    AddHandler eventObj.KeyDown, AddressOf obj_KeyDownRun
                End If
                If Array.IndexOf(Sobytia, trans("Отжатие кнопки").ToUpper) <> -1 Then
                    AddHandler eventObj.KeyUp, AddressOf obj_KeyUpRun
                End If

                ' Прочие
                If Array.IndexOf(Sobytia, trans("Изменение текста").ToUpper) <> -1 Then
                    AddHandler eventObj.TextChanged, AddressOf obj_TextChangedRun
                End If
                If Array.IndexOf(Sobytia, trans("Получение фокуса").ToUpper) <> -1 Then
                    AddHandler eventObj.GotFocus, AddressOf obj_GotFocusRun
                End If
                If Array.IndexOf(Sobytia, trans("Потеря фокуса").ToUpper) <> -1 Then
                    AddHandler eventObj.LostFocus, AddressOf obj_LostFocusRun
                End If
                If Array.IndexOf(Sobytia, trans("Прорисовка").ToUpper) <> -1 Then
                    AddHandler eventObj.Paint, AddressOf obj_PaintRun
                End If
                If Array.IndexOf(Sobytia, trans("Прокрутка").ToUpper) <> -1 Then
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
                If Array.IndexOf(Sobytia, trans("Изменение размеров").ToUpper) <> -1 Then
                    Dim panel As Windows.Forms.Panel = eventObj
                    AddHandler Panel.Resize, AddressOf obj_ResizeRun
                End If
                If Array.IndexOf(Sobytia, trans("Закрытие окна").ToUpper) <> -1 Then
                    Dim panel As runF = eventObj
                    AddHandler panel.FormClosing, AddressOf obj_FormClosingRun
                End If
                If Array.IndexOf(Sobytia, trans("Изменились размеры").ToUpper) <> -1 Then
                    AddHandler eventObj.SizeChanged, AddressOf obj_SizeChangedRun
                End If
                If Array.IndexOf(Sobytia, trans("Изменились размеры").ToUpper) <> -1 Then
                    AddHandler eventObj.VisibleChanged, AddressOf obj_VisibleChangedRun
                End If

                ' Браузер
                If Iz.IsW(MyObj) Then
                    Dim panel As runW = eventObj
                    If Array.IndexOf(Sobytia, trans("Назад можно изменилось").ToUpper) <> -1 Then
                        AddHandler Panel.CanGoBackChanged, AddressOf WebBrowser1_CanGoBackChanged
                    End If
                    If Array.IndexOf(Sobytia, trans("Вперед можно изменилось").ToUpper) <> -1 Then
                        AddHandler Panel.CanGoForwardChanged, AddressOf WebBrowser1_CanGoForwardChanged
                    End If
                    If Array.IndexOf(Sobytia, trans("Страница загрузилась").ToUpper) <> -1 Then
                        AddHandler Panel.DocumentCompleted, AddressOf WebBrowser1_DocumentCompleted
                    End If
                    If Array.IndexOf(Sobytia, trans("Страница загружается").ToUpper) <> -1 Then
                        AddHandler Panel.FileDownload, AddressOf WebBrowser1_FileDownload
                    End If
                    If Array.IndexOf(Sobytia, trans("Перешел по ссылке").ToUpper) <> -1 Then
                        AddHandler Panel.Navigated, AddressOf WebBrowser1_Navigated
                    End If
                    If Array.IndexOf(Sobytia, trans("Переходит по ссылке").ToUpper) <> -1 Then
                        AddHandler Panel.Navigating, AddressOf WebBrowser1_Navigating
                    End If
                    If Array.IndexOf(Sobytia, trans("Открытие в новом окне").ToUpper) <> -1 Then
                        AddHandler Panel.NewWindow, AddressOf WebBrowser1_NewWindow
                    End If
                    If Array.IndexOf(Sobytia, trans("Статусная строка изменилась").ToUpper) <> -1 Then
                        AddHandler Panel.StatusTextChanged, AddressOf WebBrowser1_StatusTextChanged
                    End If
                End If

                ' табпейдж
                If Iz.IsTP(MyObj) Then
                    Dim panel As runTP = eventObj
                    If Array.IndexOf(Sobytia, trans("Снялось выделение закладки").ToUpper) <> -1 Then
                        AddHandler Panel.Deselected, AddressOf TabControl_Deselected
                    End If
                    If Array.IndexOf(Sobytia, trans("Снимается выделение закладки").ToUpper) <> -1 Then
                        AddHandler Panel.Deselecting, AddressOf TabControl_Deselecting
                    End If
                    If Array.IndexOf(Sobytia, trans("Выделили закладку").ToUpper) <> -1 Then
                        AddHandler Panel.SelectedIndexChanged, AddressOf TabControl_SelectedIndexChanged
                    End If
                    If Array.IndexOf(Sobytia, trans("Выделяют закладку").ToUpper) <> -1 Then
                        AddHandler Panel.Selecting, AddressOf TabControl_Selecting
                    End If
                End If

                ' таблица
                If Iz.IsTl(MyObj) Then
                    Dim panel As runTl = eventObj
                    If Array.IndexOf(Sobytia, trans("Изменилось выделение").ToUpper) <> -1 Then
                        AddHandler Panel.SelectionChanged, AddressOf Table_SelectionChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Начало редактирования ячейки").ToUpper) <> -1 Then
                        AddHandler Panel.CellBeginEdit, AddressOf Table_CellBeginEditRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Клик по ячейке").ToUpper) <> -1 Then
                        AddHandler Panel.CellClick, AddressOf Table_CellClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Клик по выделенной ячейке").ToUpper) <> -1 Then
                        AddHandler Panel.CellMouseDown, AddressOf Table_CellMouseDownRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Двойной клик по ячейке").ToUpper) <> -1 Then
                        AddHandler Panel.CellDoubleClick, AddressOf Table_CellDoubleClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Конец редактирования ячеки").ToUpper) <> -1 Then
                        AddHandler Panel.CellEndEdit, AddressOf Table_CellEndEditRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Ячейка в фокусе").ToUpper) <> -1 Then
                        AddHandler Panel.CellEnter, AddressOf Table_CellEnterRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Ячека потеряла фокус").ToUpper) <> -1 Then
                        AddHandler Panel.CellLeave, AddressOf Table_CellLeaveRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Столбец переместили").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnDisplayIndexChanged, AddressOf Table_ColumnDisplayIndexChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Клик по заголовку столбца").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnHeaderMouseClick, AddressOf Table_ColumnHeaderMouseClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Двойной клик по заголовку столбца").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnHeaderMouseDoubleClick, AddressOf Table_ColumnHeaderMouseDoubleClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Сортировка столбца").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnSortModeChanged, AddressOf Table_ColumnSortModeChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Изменилась ширина столбца").ToUpper) <> -1 Then
                        AddHandler Panel.ColumnWidthChanged, AddressOf Table_ColumnWidthChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Клик по заголовку строки").ToUpper) <> -1 Then
                        AddHandler Panel.RowHeaderMouseClick, AddressOf Table_RowHeaderMouseClickRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Изменилась вышина строки").ToUpper) <> -1 Then
                        AddHandler Panel.RowHeightChanged, AddressOf Table_RowHeightChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Добавли строку").ToUpper) <> -1 Then
                        AddHandler Panel.RowsAdded, AddressOf Table_RowsAddedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Удалили строку").ToUpper) <> -1 Then
                        AddHandler Panel.RowsRemoved, AddressOf Table_RowsRemovedRun
                    End If
                End If

                ' список
                If Iz.IsC(MyObj) Then
                    Dim panel As runC = eventObj
                    If Array.IndexOf(Sobytia, trans("Изменение выбранной записи").ToUpper) <> -1 Then
                        AddHandler Panel.SelectedIndexChanged, AddressOf obj_SelectedIndexChangedRun
                    End If
                End If
                If Iz.IsL(MyObj) Then
                    Dim panel As runL = eventObj
                    If Array.IndexOf(Sobytia, trans("Изменение выбранной записи").ToUpper) <> -1 Then
                        AddHandler panel.SelectedIndexChanged, AddressOf obj_SelectedIndexChangedRun
                    End If
                End If
                If Iz.IsCL(MyObj) Then
                    Dim panel As runCL = eventObj
                    If Array.IndexOf(Sobytia, trans("Изменение выбранной записи").ToUpper) <> -1 Then
                        AddHandler panel.SelectedIndexChanged, AddressOf obj_SelectedIndexChangedRun
                    End If
                End If

                If Iz.IsCr(MyObj) Then
                    Dim panel As runCr = eventObj
                    If Array.IndexOf(Sobytia, trans("Календарь закрылся").ToUpper) <> -1 Then
                        AddHandler Panel.CloseUp, AddressOf obj_CloseUp
                    End If
                    If Array.IndexOf(Sobytia, trans("Календарь раскрылся").ToUpper) <> -1 Then
                        AddHandler Panel.DropDown, AddressOf obj_DropDown
                    End If
                    If Array.IndexOf(Sobytia, trans("Значение изменилось").ToUpper) <> -1 Then
                        AddHandler Panel.ValueChanged, AddressOf obj_ValueChanged
                    End If
                End If

                If Iz.IsTb(MyObj) Then
                    Dim panel As runTb = eventObj
                    If Array.IndexOf(Sobytia, trans("Значение изменилось").ToUpper) <> -1 Then
                        AddHandler Panel.ValueChanged, AddressOf obj_ValueChanged
                    End If
                    If Array.IndexOf(Sobytia, trans("Движение бегунка").ToUpper) <> -1 Then
                        AddHandler Panel.Scroll, AddressOf obj_ScrollRun
                    End If
                End If

                ' Клиент сервер
                If Iz.IsCS(MyObj) Then
                    Dim panel As IWinSockEvents = eventObj
                    If Array.IndexOf(Sobytia, trans("Присоединились к серверу").ToUpper) <> -1 Then
                        AddHandler panel.ConnectedToServer, AddressOf obj_ConnectedToServerRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Присоединился клиент").ToUpper) <> -1 Then
                        AddHandler panel.ConnectionClient, AddressOf obj_ConnectionClientRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Изменилось число клиентов").ToUpper) <> -1 Then
                        AddHandler panel.CountChanged, AddressOf obj_CountChangedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Пришел текст").ToUpper) <> -1 Then
                        AddHandler panel.TextReceived, AddressOf obj_TextReceivedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Пришла команда").ToUpper) <> -1 Then
                        AddHandler panel.CommandReceived, AddressOf obj_CommandReceivedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Пришел файл").ToUpper) <> -1 Then
                        AddHandler panel.FileReceived, AddressOf obj_FileReceivedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Отключение").ToUpper) <> -1 Then
                        AddHandler panel.Disconnected, AddressOf obj_DisconnectedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Произошла ошибка").ToUpper) <> -1 Then
                        AddHandler panel.ErrorReceived, AddressOf obj_ErrorReceivedRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Отправился текст").ToUpper) <> -1 Then
                        AddHandler panel.SendTextComplete, AddressOf obj_SendTextCompleteRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Отправился файл").ToUpper) <> -1 Then
                        AddHandler panel.SendFileComplete, AddressOf obj_SendFileCompleteRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Идет отправление").ToUpper) <> -1 Then
                        AddHandler panel.SendProgress, AddressOf obj_SendProgressRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Идет прием данных").ToUpper) <> -1 Then
                        AddHandler panel.ReceiveProgress, AddressOf obj_ReceiveProgressRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Изменился статус").ToUpper) <> -1 Then
                        AddHandler panel.StateChanged, AddressOf obj_StateChangedRun
                    End If
                End If

                ' Интернет
                If Iz.IsI(MyObj) Then
                    Dim panel As IInternetEvents = eventObj
                    If Array.IndexOf(Sobytia, trans("Отправляется запрос").ToUpper) <> -1 Then
                        AddHandler panel.SendingQuery, AddressOf obj_SendingQueryRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Отправился запрос").ToUpper) <> -1 Then
                        AddHandler panel.SentQuery, AddressOf obj_SentQueryRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Пришел ответ").ToUpper) <> -1 Then
                        AddHandler panel.ReceivedResponse, AddressOf obj_ReceivedResponseRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Идет прием данных").ToUpper) <> -1 Then
                        AddHandler panel.ReceiveProgress, AddressOf obj_ReceiveProgressRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Загрузка отменена").ToUpper) <> -1 Then
                        AddHandler panel.DownloadCancelled, AddressOf obj_DownloadCancelledRun
                    End If
                End If


                ' Редкие
                If Iz.IsFORM(MyObj) Then
                    Dim panel As runF = eventObj
                    If Array.IndexOf(Sobytia, trans("Сворачивание").ToUpper) <> -1 Then
                        AddHandler panel.Minimize, AddressOf Minimize
                    End If
                    If Array.IndexOf(Sobytia, trans("Двойной клик по трею").ToUpper) <> -1 Then
                        AddHandler panel.DoubleClickTray, AddressOf DoubleClickTray
                    End If
                End If
                If Array.IndexOf(Sobytia, trans("Конец проигрывания").ToUpper) <> -1 Then
                    If Iz.IsMd(MyObj) Then
                        Dim panel As runMd = eventObj
                        AddHandler panel.OnEnd, AddressOf obj_OnEndRun
                    Else
                        Dim panel As runA = eventObj
                        AddHandler panel.OnEnd, AddressOf obj_OnEndRun
                    End If
                End If
                If Array.IndexOf(Sobytia, trans("Изменение отметки").ToUpper) <> -1 Then
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
                    If Array.IndexOf(Sobytia, trans("Изменение значения").ToUpper) <> -1 Then
                        AddHandler panel.ChangingValue, AddressOf obj_ChangingValueRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Изменилось значение").ToUpper) <> -1 Then
                        AddHandler panel.ChangedValue, AddressOf obj_ChangedValueRun
                    End If
                End If
                If Iz.IsLLb(MyObj) Then
                    Dim panel As runLLb = eventObj
                    If Array.IndexOf(Sobytia, trans("Клик по ссылке").ToUpper) <> -1 Then
                        AddHandler panel.LinkClicked, AddressOf obj_LinkClicked
                    End If
                End If
                If Iz.IsRT(MyObj) Then
                    Dim panel As runRT = eventObj
                    If Array.IndexOf(Sobytia, trans("Горизонтальная прокрутка").ToUpper) <> -1 Then
                        AddHandler panel.HScroll, AddressOf obj_HScroll
                    End If
                    If Array.IndexOf(Sobytia, trans("Вертикальная прокрутка").ToUpper) <> -1 Then
                        AddHandler panel.VScroll, AddressOf obj_VScroll
                    End If
                    If Array.IndexOf(Sobytia, trans("Клик по ссылке документа").ToUpper) <> -1 Then
                        AddHandler panel.LinkClicked, AddressOf obj_LinkClicked
                    End If
                End If
                If Iz.IsTm(MyObj) Then
                    Dim panel As runTm = obj
                    If Array.IndexOf(Sobytia, trans("Тикнул").ToUpper) <> -1 Then
                        AddHandler panel.Tick, AddressOf obj_Tick
                    End If
                End If
                If Iz.IsTr(MyObj) Then
                    Dim spis As runTr = eventObj
                    If Array.IndexOf(Sobytia, trans("Клик кнопки").ToUpper) <> -1 Then
                        AddHandler spis.ClickButton, AddressOf obj_ClickButtonRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Активация успешная").ToUpper) <> -1 Then
                        AddHandler spis.ActivationSuccessul, AddressOf obj_ActivationSuccessulRun
                    End If
                    If Array.IndexOf(Sobytia, trans("Активация неудачная").ToUpper) <> -1 Then
                        AddHandler spis.ActivationFailed, AddressOf obj_ActivationFailedRun
                    End If
                End If



                ' Нужные программе2
                If Iz.isNoControlObj(obj) = False Then
                    AddHandler eventObj.Disposed, AddressOf obj_DisposedNado
                    AddHandler eventObj.Resize, AddressOf obj_ResizeNado
                End If
                ' нужные программе1
                If Iz.IsW(MyObj) Then
                    Dim panel As runW = obj
                    AddHandler panel.NewWindow, AddressOf WebBrowser_NewWindowNado
                    AddHandler panel.StatusTextChanged, AddressOf WebBrowser_StatusTextChangedNado
                End If

            End If

            ' мои
            Dim MyEventObj As MyEvents = obj
            If Array.IndexOf(Sobytia, trans("Создание").ToUpper) <> -1 Then
                AddHandler MyEventObj.Created, AddressOf obj_LoadRun
            End If
        End If

        If holostoi = True And fromEng = False Then Exit Sub
        ' #### Конец холостого обоъекта ###

        If Iz.IsFORM(MyObj) Then 'And isRun = False Then
            ' Создание СплитКонтрола для таба
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

        ' Если сейчас не происходит открытие проекта, а просто создается очередной объект пользователем
        '    If fromEng = False Then
        ' Dim frma As Forms = conteiner ' это  для полуобъектов
        ' Если объект еще нигде не размещен
        ' Если объект не является лишь составной частью большого объекта
        If obj.TypeObj <> "IncludeObj" And MyObj.conteiner Is Nothing Or Iz.isPoluObj(obj) Then
            ' Если создается форма, то её не надо размещать, это сделает конструктор Forms
            If Iz.IsFORM(MyObj) = False Then

                If obj.TypeObj = "PoluObj" Then ' Если это полуобъкет, то контейнер для него сплитпанель
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
                Else ' Если это обычный объект, то его контейнер может быть форма, панель, панель в панели и т.д.
                    conteiner = proj.ActiveForm
                    If proj.ActiveForm Is Nothing = False Then
                        If proj.ActiveForm.ActiveObj Is Nothing = False Then
                            If proj.ActiveForm.ActiveObj(0) Is Nothing = False Then
                                ' Если это панель, то можно разместить на ней
                                If Iz.isPanel(proj.ActiveForm.ActiveObj(0).obj) Then
                                    If proj.ActiveForm.ActiveObj.Length = 1 Then
                                        conteiner = proj.ActiveForm.ActiveObj(0) ' Контейнером будет выделеная панель
                                    ElseIf proj.ActiveForm.ActiveObj(0).conteiner Is Nothing = False Then
                                        ' Если контенер выделенного объекта не панель для полуобъектов
                                        If proj.ActiveForm.ActiveObj(0).conteiner Is proj.ActiveForm.SplitCont.Panel2 = False Then
                                            conteiner = proj.ActiveForm.ActiveObj(0).conteiner ' Контейнером будет контейнер выделенного объекта
                                        End If
                                    End If
                                Else
                                    conteiner = proj.ActiveForm.ActiveObj(0).conteiner
                                End If
                            End If
                        End If
                    End If

                    ' Сохранить найденый контенер в переменной
                    If Iz.IsDP(conteiner) Then ' Если выделена двойная панель
                        Dim res As MsgBoxResult
                        If conteiner.ActivePanel = "" Then
                            res = MsgBox(transInfc("Вы хотите разместить объект на первой из двух панелей?"), MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question)
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

                ' В составные объекты нельзя вставлять не в их инклуд объекты
                If Iz.isSostObj(cont) Then
                    If obj.GetType.ToString.IndexOf(cont.GetType.ToString) <> 0 Then conteiner = proj.activeForm : cont = proj.activeform.obj
                End If
                ' Последяя проверка, что на вычисленный контенер можно добавлять объекты
                If Iz.isIncludeObj(obj) = False And Iz.isPoluObj(obj) = False Then
                    While Iz.isPanel(cont) = False And cont.GetType.ToString <> "System.Windows.Forms.SplitterPanel"
                        cont = cont.myobj.conteiner.obj
                    End While
                End If

                ' Задать х и у в контенере
                Dim loc As Point
                If obj.TypeObj <> "PoluObj" Then
                    ' Разместить объект в центре формы и если там уже чтото есть то сместить его в другое место
                    Loc = GetXY(obj, cont, cont.Width / 2 - eventObj.Width / 2, cont.Height / 2 - eventObj.Height / 2)
                Else
                    ' если на этом месте в сплитПанели2 уже чтото есть, то сместить объект в другое место
                    Loc = GetXY(obj, cont, setka, setka) : BackPoluObj(True, MyObj)
                End If
                If Iz.isNoMove(obj) Then
                    obj.left = Loc.X : obj.top = Loc.Y
                Else
                    ' Если объекты вставляется, то надо их пропорциональное расстояние 
                    If proj.UndoRedoNoWrite Then
                    ElseIf VstavkaOrCreate Then
                        obj.Props.X += setka : obj.Props.Y += setka
                    Else
                        obj.Props.X = Loc.X : obj.Props.Y = Loc.Y
                    End If
                End If



                ' ДОБАВИТЬ ОБЪЕКТ В КОНТЕНЕР
                cont.Controls.Add(obj)

                ' Добавить две начальные закладки, если это не загрузка проекта
                If Iz.IsTP(MyObj) And fromEng = False Then
                    If MyObj.obj.tabPages.Count = 0 And VstavkaOrCreate = False Then addTabPage(New TPages) : addTabPage(New TPages)
                ElseIf (Iz.IsMM(MyObj) Or Iz.IsCM(MyObj) Or Iz.IsTPl(MyObj)) And fromEng = False Then
                    If MyObj.obj.items.Count = 0 And VstavkaOrCreate = False Then
                        Dim mmenus As New MMenus
                        ' У ToolPanel нужно задать для примера рисунок
                        If Iz.IsTPl(MyObj) Then MMenus = New MMenus(, , , True)

                        addMMenuItem(MMenus, False)
                    End If
                ElseIf Iz.IsTl(MyObj) And fromEng = False Then
                    If MyObj.obj.Columns.Count = 0 And VstavkaOrCreate = False Then
                        'MyObj.obj.props.Columns = """" & trans("Столбец") & "1"", """ & trans("Столбец") & "2"""
                        'MyObj.obj.props.Rows = """" & trans("Строка") & "1"" | """ & trans("Строка") & "1"", " & _
                        '                       """" & trans("Строка") & "2"" | """ & trans("Строка") & "2"""
                        MyObj.obj.props.Columns = trans("Столбец") & "1, " & trans("Столбец") & "2"
                        MyObj.obj.props.Rows = trans("Строка") & "1 | " & trans("Строка") & "1, " & _
                                               trans("Строка") & "2 | " & trans("Строка") & "2"
                    End If
                ElseIf (Iz.IsC(MyObj) Or Iz.IsL(MyObj) Or Iz.IsCL(MyObj)) And fromEng = False Then
                    If MyObj.obj.Items.Count = 0 And VstavkaOrCreate = False Then
                        'MyObj.obj.props.Items = """" & trans("Запись") & "1"", """ & trans("Запись") & "2"""
                        'MyObj.obj.props.text = trans("Запись") & "1"
                        MyObj.obj.props.Items = trans("Запись") & "1, " & trans("Запись") & "2"
                        MyObj.obj.props.text = trans("Запись") & "1"
                        MyObj.obj.props.SelectedItem = MyObj.obj.props.Text
                    End If
                End If

            End If
        ElseIf obj.TypeObj = "IncludeObj" And VstavkaOrCreate = True And MyObj.conteiner Is Nothing Then
            ' Это условие срабатывает, если вставляют инлудобъект из буфера
            ' Если это вложенный объект и ему еще не назначен контенер, то назначить можно только контенер такого же типа как сам инклудобъект
            Dim SostObj As Object = proj.GetSostObjFromIncludeObj(MyObj)
            ' Если выделеный объект является родителем инклуд объекта, то добавить его
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
            ' У элементов меню евентОбъект свой
            Dim eventObj As ToolStripItem = ob
            AddHandler eventObj.MouseDown, AddressOf obj_MouseDown
            AddHandler eventObj.MouseMove, AddressOf obj_MouseMove
            AddHandler eventObj.MouseUp, AddressOf obj_MouseUp
            AddHandler eventObj.DoubleClick, AddressOf obj_DoubleClick
            AddHandler eventObj.Click, AddressOf obj_Click
            AddHandler eventObj.Paint, AddressOf obj_Paint
        ElseIf Iz.IsDP(MyObj) Then
            ' У двойной панели свои события
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
            ' У таблицы много своих дополнительных событий
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

        ' Создать и настроить маркеры
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
        ' Настроить курсоры маркеров
        If obj.TypeObj <> "PoluObj" Then
            markers(0).Cursor = Cursors.SizeNWSE : markers(7).Cursor = Cursors.SizeNWSE
            markers(1).Cursor = Cursors.SizeNS : markers(6).Cursor = Cursors.SizeNS
            markers(2).Cursor = Cursors.SizeNESW : markers(5).Cursor = Cursors.SizeNESW
            markers(3).Cursor = Cursors.SizeWE : markers(4).Cursor = Cursors.SizeWE
            ' У Формы добалять всего надо побольше
            If Iz.IsFORM(MyObj) = False Then
                GetMyForm.tab.Controls.AddRange(markers)
            Else
                ' Размещение всего
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
        ' Создание мнимого маркера, чтобы скролинг не мешал менять размеры формы
        HideMarker = New PictureBox : HideMarker.SendToBack()
        HideMarker.BackColor = Color.Transparent : HideMarker.Width = markerX : HideMarker.Height = markerY
        ' Форма добавляет мнимый маркер в свое место
        If Iz.IsFORM(MyObj) Then
            SplitCont.Panel1.Controls.Add(HideMarker)
        ElseIf obj.TypeObj <> "PoluObj" And obj.TypeObj <> "IncludeObj" Then
            If obj.parent Is Nothing Then Exit Sub
            obj.parent.Controls.Add(HideMarker)
        End If
        ' Добавить объект в дерево действий
        If fromEng = False Then AddNode()
        ' Добавить объект в историю ХисториЛевел
        If Iz.IsFORM(MyObj) = False And Iz.IsMMs(MyObj) = False And fromEng = False Then
            GetMyForm.HistoryLevelRun("на передний план", MyObj)
        End If
        ' И в конце дать фокус созданному объекту
        obj_GotFocus(obj, New EventArgs)
        ' Настроить свойства ФОРМЫ
        If Iz.IsFORM(MyObj) Then
            If proj Is Nothing = False Then
                If proj.f Is Nothing = False Then
                    If fromEng Then ReDims(proj.f) : proj.f(proj.f.Length - 1) = MyObj : proj.activeform = MyObj
                    If proj.f.length > 2 Then MyObj.obj.Props.mainform = trans("Нет")
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
            proj.UndoRedo("Создать", "объект", Perevodi.ToStrFromObj(MyObj, True, , , False))
        End If
    End Sub
    Function addTabPage(ByVal TabPage As TPages, Optional ByVal withUndo As Boolean = False, Optional ByVal isPaste As Boolean = False) As TPages
        Dim oldNam As String = TabPage.obj.Props.name
        If TabPage.obj.Props.name = MyZnak & "none" Then
            TabPage.obj.Props.name = proj.GiveName(obj.Props.name & " " & trans("Закладка"))
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
            proj.UndoRedo("Создать", "объект", Perevodi.ToStrFromObj(TabPage, True))
        End If
        Return TabPage
    End Function
    Function addMMenuItem(ByVal MMenus As MMenus, Optional ByVal withUndo As Boolean = False) As MMenus
        Dim oldNam As String = MMenus.obj.Props.name
        ' При создании пункта меню по умолчанию, присвоить стандартные имена и текст
        If MMenus.obj.Props.name = MyZnak & "none" Then
            MMenus.obj.Props.name = proj.GiveName(obj.Props.name & " " & trans("Пункт"))
            MMenus.obj.Props.text = MMenus.obj.Props.name
        End If
        ' Создать объект
        MMenus.conteiner = MyObj
        If GetMyForm() Is Nothing = False Then
            GetMyForm.AddObject(MMenus)
        End If
        ' Определить какого типа коллекция у контенера
        Dim contCollec As System.Windows.Forms.ToolStripItemCollection
        If obj.GetType.ToString = ClassAplication & "MM" Or obj.GetType.ToString = ClassAplication & "runMM" _
        Or obj.GetType.ToString = ClassAplication & "CM" Or obj.GetType.ToString = ClassAplication & "runCM" _
        Or obj.GetType.ToString = ClassAplication & "TPl" Or obj.GetType.ToString = ClassAplication & "runTPl" _
        Then
            contCollec = obj.items
        Else
            contCollec = obj.DropDownItems
        End If
        ' Добавление пункта меню в коллекцию
        contCollec.Add(MMenus.obj)
        ' Высчитать позицию объекта или переместить в позицию указанную в свойстве объекта
        If oldNam = MyZnak & "none" Then
            MMenus.obj.Props.position = contCollec.Count - 1
        Else
            MMenus.obj.moveToPosition()
        End If
        If oldNam = MyZnak & "none" Then MMenus.NodeRefresh(MyZnak & "none")
        If withUndo Then
            proj.UndoRedo("Создать", "объект", Perevodi.ToStrFromObj(MMenus, True))
        End If
        ' для преобразования в сепаратор если надо
        MMenus.obj.props.text = MMenus.obj.props.text
        Return MMenus
    End Function
    Function GetXY(ByVal obj As Object, ByVal cont As Object, ByVal na4alX As Integer, ByVal na4alY As Integer) As Point
        Dim i As Integer
        If proj.ActiveForm Is Nothing Then Exit Function
        If proj.ActiveForm.MyObjs Is Nothing = False Then
            ' Если в na4x и na4y уже есть какойто объект то сместить координаты в другое место
            For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                ' Объеты сравниваются с объектами, полуобъекты с полуобъетами
                If proj.ActiveForm.MyObjs(i).obj.TypeObj = obj.TypeObj Then
                    If proj.ActiveForm.MyObjs(i).obj.left = na4alX And proj.ActiveForm.MyObjs(i).obj.Top = na4alY Then
                        Return GetXY(obj, cont, na4alX + setka, na4alY + setka)
                    End If
                End If
            Next
        End If
        If obj.TypeObj = "PoluObj" And na4alY > cont.height - obj.height Then 'полуобъекты не должны заходить за панель
            Return GetXY(obj, cont, na4alX, na4alY - setka / 2)
        End If
        Return New Point(na4alX, na4alY)
    End Function
#End Region

    '<<<<<<<< ПРОЦЕДУРЫ МАРКЕРОВ >>>>>>>>>
#Region "MARKERS SUBS"
    Private Sub markers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'cm.Close()
        MainForm.Peremeschatel.Focus()
        markers_perenos = Array.IndexOf(markers, sender) ' Индекс нажатого маркера
        If markers_perenos = -1 Then Exit Sub
        mdx = e.X : mdy = e.Y  ' Высчитать разницу в координатах для операции перемещения
        proj.ActiveForm.marker_vis(False) ' Скрыть все маркеры
        SolvRaznica() ' занести в массивы raznicaSize и raznicaLoc разницу координат и размеров объектов относительно obj
        If markers_perenos = 8 And Iz.isNoMove(obj) Then proj.ActiveForm.marker_vis()
    End Sub
    Private Sub markers_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim i As Integer
        If markers_perenos = 8 And Iz.isNoMove(obj) Then Exit Sub
        If (mdx = e.X And mdy = e.Y) Or markers_perenos = 9 Then Exit Sub ' Если никакого перемещения небыло
        If markers_perenos <> -1 Then
            If Control.ModifierKeys = Keys.Control Then ' Если удерживается ктрл, то перемещать по пиксельно
                markers(markers_perenos).Left = markers(markers_perenos).Left + e.X - mdx
                markers(markers_perenos).Top = markers(markers_perenos).Top + e.Y - mdy
            Else ' Перемещать по сетке
                '  If obj.TypeObj<>"PoluObj" Then ' Учитывать скрол формы, она же может прокручиваться
                'markers(markers_perenos).Left = ((markers(markers_perenos).Left + e.X - mdx) \ setka) * setka
                'markers(markers_perenos).Top = ((markers(markers_perenos).Top + e.Y - mdy) \ setka) * setka
                'Else
                markers(markers_perenos).Left = ((markers(markers_perenos).Left + e.X - mdx) \ setka) * setka
                markers(markers_perenos).Top = ((markers(markers_perenos).Top + e.Y - mdy) \ setka) * setka
                ' End If
            End If
            ' Менять размеры у всех активных объектов
            For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
                Dim cx, cy As Integer
                cx = markers(markers_perenos).Left  ' - proj.ActiveForm.SplitCont.Panel1.HorizontalScroll.Value
                cy = markers(markers_perenos).Top '- proj.ActiveForm.SplitCont.Panel1.VerticalScroll.Value
                ' Учитывание вложенных контенеров
                Dim cont As Point = proj.ActiveForm.ContenerAbsXY(Me)
                ' У двойной панели надо учитывать в какой панели объект
                'If obj.Parent.Parent.GetType.ToString = ClassAplication & "DP" Then
                ' cx -= obj.Parent.Parent.ParentPanelLeft(obj)
                ' cy -= obj.Parent.Parent.ParentPanelTop(obj)
                ' Else
                cx -= cont.X : cy -= cont.Y
                'End If
                Dim aObj = proj.ActiveForm.ActiveObj(i).obj ' Один из активных объектов
                Dim left = aObj.Left, top = aObj.Top, hei = aObj.height, wid As Double = aObj.Width
                Select Case markers_perenos
                    Case 0 ' Левый верхний маркер, меняет размеры только своего объекта, а не всех активных
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
                    Case 4 ' Правый средний маркер, меняет размеры всех активных объектов
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
                    Case 8 ' Маркер для перемещения объекта
                        left = cx - raznicaLoc(i).X - markerX
                        top = cy - raznicaLoc(i).Y + markers(markers_perenos).Height
                End Select
                If Control.ModifierKeys = Keys.Control Then ' Если удерживается ктрл, то перемещать по пиксельно
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
        BackPoluObj(proj.ActiveForm.ActiveObj) ' Если полуобъект ушел за границы контейнера, то вернуть его
        proj.ActiveForm.marker_vis(True) ' сделать маркеры видимыми
        ' Обработка нажатия плюсика
        If markers_perenos = 9 Then
            If e.Button = MouseButtons.Left Then
                MainForm.AddMenu_Click(Nothing, Nothing)
            ElseIf e.Button = MouseButtons.Right Then
                markers(markers_perenos).ContextMenuStrip.Show(markers(markers_perenos), 2, 2)
            End If
        Else
            If obj.TypeObj <> "PoluObj" Then ' Чтобы скролинг не мешал менять размеры и положене объекта
                HideMarker.Left = obj.Left + obj.width - HideMarker.Width
                HideMarker.Top = obj.Top + obj.height - HideMarker.Height
                If Iz.IsFORM(MyObj) Then
                    HideMarker.Left += HideMarker.Width : HideMarker.Top += HideMarker.Height
                End If
                proj.ActiveForm.marker_vis(True)
            End If
            ' Если перемещение маркера было
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

    '<<<<<<<< ПРОЦЕДУРЫ ОБЪЕКТА OBJ >>>>>>>>>
#Region "OBJ SUBS"
    Dim zashita As Boolean
    Public Sub obj_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ' Форму и панели нельзя перемещать
            If Iz.isPanel(obj) Then
                na4Point = e.Location : click = True : Exit Sub
            End If
        End If
        ' Выделить объект если он небыл выделен и если не хотят сделать мультивыделение (не нажат ктрл)
        If (proj.ActiveForm.IsActiveObject(Me) = False And Control.ModifierKeys <> Keys.Control) Or proj.ActiveForm.ActiveObj Is Nothing Then

            proj.ActiveForm.SetActiveObject(Me)

            If Me.markers(8).Visible = False Then proj.ActiveForm.marker_vis(True)
        End If
        ' Если на объект нажали не левой кнопкой, но он не выделен, то выделить его
        If e.Button = MouseButtons.Left Or proj.ActiveForm.IsActiveObject(Me) = False Then
            perenos = True : dx = e.X : dy = e.Y : click = True
            If Iz.isMoveOnlyMarker(MyObj.obj) = False Then obj.Cursor = Cursors.NoMove2D ' proj.ActiveForm.marker_vis(False)
            SolvRaznica() ' занести в массивы raznicaSize и raznicaLoc разницу координат и размеров объектов относительно obj
        End If
        zashita = True
    End Sub
    Public Sub obj_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim i As Integer
        If Iz.isNoMove(obj) Then perenos = False : Exit Sub
        If Iz.isMoveOnlyMarker(MyObj.obj) Then Exit Sub
        If zashita = True Then zashita = False : dx = e.X : dy = e.Y : Exit Sub
        ' Форму и панели нельзя перемещать
        If na4Point <> Nothing Then
            If Iz.isPanel(obj) Then
                click = False ': proj.ActiveForm.ClearActiveObject()
                endPoint = e.Location : sender.refresh()
            End If
            Exit Sub
        End If
        If perenos = True And (e.X <> dx Or e.Y <> dy) Then ' Если перемещение началось
            If proj.ActiveForm.ActiveObj Is Nothing Or raznicaLoc Is Nothing Then perenos = False : Exit Sub
            If Iz.isMoveOnlyMarker(sender) Then perenos = False : Exit Sub
            ' Переместить активные объекты относительно obj
            If raznicaLoc.Length = proj.ActiveForm.ActiveObj.length Then
                For i = 0 To raznicaLoc.Length - 1
                    If Iz.IsFORM(proj.ActiveForm.ActiveObj(i)) Then Continue For ' форму нельзя перемещать
                    If Control.ModifierKeys = Keys.Control Then
                        proj.ActiveForm.ActiveObj(i).obj.Left = obj.Bounds.X + e.X - dx - raznicaLoc(i).X
                        proj.ActiveForm.ActiveObj(i).obj.Top = obj.Bounds.Y + e.Y - dy - raznicaLoc(i).Y
                    Else
                        proj.ActiveForm.ActiveObj(i).obj.Left = ((obj.Bounds.X + e.X - dx - raznicaLoc(i).X) \ setka) * setka
                        proj.ActiveForm.ActiveObj(i).obj.Top = ((obj.Bounds.Y + e.Y - dy - raznicaLoc(i).Y) \ setka) * setka
                    End If
                Next
                click = False ' рас что-то перемещали, то это уже не клик по объекту
            End If
        ElseIf perenos = False Then
            obj.Cursor = Cursori(obj.Props.cursor) 'Cursors.Default
        End If
    End Sub
    Public Sub obj_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim i As Integer
        'tree.Tag = "nelzya" : tree.SelectedNode = GetNode() : tree.Tag = ""
        perenos = False
        ' Если панель, то возможно растягивали прямоугольник
        If e.Button = MouseButtons.Left Or proj.ActiveForm.IsActiveObject(Me) = False Then
            If Iz.isMoveOnlyMarker(MyObj.obj) Then Exit Sub
            If Iz.isPanel(obj) Then
                If click = False Then
                    With proj.ActiveForm
                        If Control.ModifierKeys <> Keys.Control Then .ClearActiveObject() ' Если хотели просто выделить объект
                        If .MyObjs Is Nothing = False Then
                            For i = 0 To .MyObjs.Length - 1
                                If .MyObjs(i).conteiner Is Nothing Then Continue For ' Пропустить форму
                                If sender Is proj.ActiveForm.SplitCont.Panel2 Then ' если sender панель полуобъектов
                                    If .MyObjs(i).obj.TypeObj <> "PoluObj" Then Continue For ' Пропускать не полуобъекты
                                Else
                                    If .MyObjs(i).obj.TypeObj = "PoluObj" Then Continue For ' Пропускать полуобъекты
                                End If

                                ' Если объект находится в нужном контенере (на котором растягивается прямоугольник) и сам не является этим контенером
                                If (.MyObjs(i).obj.parent Is sender) And (.MyObjs(i).obj Is sender = False) Then
                                    ' Если объект входит в выделенную зону, то добавить его в активные
                                    If .inRectangle(.MyObjs(i).obj, na4Point, endPoint) Then
                                        .AddActiveObject(proj.ActiveForm.MyObjs(i), True)
                                    End If
                                End If
                            Next
                            .FillListView()
                        End If
                        If sender Is proj.ActiveForm.SplitCont.Panel2 = False Then ' если sender не панель полуобъектов
                            If .ActiveObj Is Nothing And click = False Then .SetActiveObject(Me)
                        End If
                    End With
                End If
                na4Point = Nothing : endPoint = Nothing : sender.refresh()
            End If
            na4Point = Nothing : endPoint = Nothing
            If click = True Then ' Если это был клик а не перемещение
                If Control.ModifierKeys = Keys.Control Then
                    proj.ActiveForm.AddActiveObject(Me)
                Else
                    If proj.ActiveForm.activeobj Is Nothing Then proj.ActiveForm.SetActiveObject(Me)
                    If proj.ActiveForm.activeobj(0) Is Me = False Then
                        proj.ActiveForm.SetActiveObject(Me)
                    End If
                End If

                ' Вывести при клике без движения контекстное меню одноименного элемента
                If Iz.IsCM(MyObj) Then MyObj.obj.CnMn.Show(obj, e.X, e.Y)
            Else
                BackPoluObj(proj.ActiveForm.ActiveObj) ' Если полуобъект ушел за границы контейнера, то вернуть его
            End If

            If obj.TypeObj <> "PoluObj" Then ' Чтобы скролинг не мешал менять размеры и положене объекта
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
        ' Передать фокус текст. полю перемещателю, что бы можно было управлять объкектом с клавиатуры
        If Iz.isMoveOnlyMarker(MyObj.obj) = False Then MainForm.Peremeschatel.Focus()
    End Sub
    Sub BackPoluObj(ByVal ob() As Object) ' Если полуобъект ушел за границы контейнера, то вернуть его
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
    Sub BackPoluObj(ByVal odin As Boolean, ByVal ob As Object)    ' Если полуобъект ушел за границы контейнера, то вернуть его
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
            If Iz.IsM(MyObj) Then ' У памяти негде писать
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
        ' Рисование сетки на форме
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
        ' Если сейчас не критическая секция
        If obj.Props.semaforSelect = False Then
            IzmenenieByloExpert()
        End If
    End Sub
    Private Sub obj_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IzmenenieBylo()
    End Sub

#End Region

    '<<<<<<<< RUN-ПРОЦЕДУРЫ ОБЪЕКТА OBJ >>>>>>>>>
#Region "RUN OBJ SUBS"
    Sub RunSobyt(ByVal sender As Object, ByVal sobyt As String, ByVal e As Object, ByVal type As System.Type)
        Dim es As ErrString
        If tree Is Nothing Or peremens.isRUN = False Then Exit Sub
        ' Ищем в ноде объекта нужное событие
        Dim eventNode As TreeNode = proj.FindSobyt(sobyt, GetNode(, True))
        If eventNode Is Nothing Then Exit Sub
        ' Выполняем найденное событие
        Try
            es = proj.RunBlock(eventNode, 0, New PropertysSobyt(sender, e, type), True)
            If es.err <> "" Then Errors.MessangeCritic(es.err)
        Catch ex As Exception
            If IgnorEr = False Then
                Dim deist As String
                If peremens.isRUN Then
                    If proj.NowNode Is Nothing = False Then
                        deist = vbCrLf & trans("Действие") & ": """ & proj.NowNode.text & """"
                    End If
                End If
                Errors.MessangeCritic(ex.Message & vbCrLf & trans("Событие") & ": """ & eventNode.FullPath & """" & deist)
            Else
                If proj.NowNode Is Nothing = False Then
                    proj.RunBlock(proj.NowNode, 0, New PropertysSobyt(sender, e, type), True)
                End If
            End If
        End Try
        proj.recurs = 0
    End Sub

    ' СОБЫТИЯ МЫШИ
    Public Sub obj_ClickRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Клик"), e, e.GetType)
    End Sub
    Public Sub obj_MouseDownRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RunSobyt(MyObj, trans("Нажатие кнопки мыши"), e, e.GetType)
    End Sub
    Public Sub obj_MouseUpRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RunSobyt(MyObj, trans("Отжатие кнопки мыши"), e, e.GetType)
    End Sub
    Public Sub obj_MouseMoveRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If proj.alreadyRun Then Exit Sub
        RunSobyt(MyObj, trans("Движение курсора"), e, e.GetType)
    End Sub
    Public Sub obj_MouseEnterRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Наведение курсора"), e, e.GetType)
    End Sub
    Public Sub obj_MouseLeaveRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Отведение курсора"), e, e.GetType)
    End Sub
    Public Sub obj_MouseHoverRun(ByVal sender As Object, ByVal e As System.EventArgs)
        If proj.alreadyRun Then Exit Sub
        RunSobyt(MyObj, trans("Курсор на объекте"), e, e.GetType)
    End Sub
    Public Sub obj_MouseWheelRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RunSobyt(MyObj, trans("Вращение колесика"), e, e.GetType)
    End Sub
    Public Sub obj_DoubleClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        RunSobyt(MyObj, trans("Двойной клик"), e, e.GetType)
    End Sub

    ' СОБЫТИЯ КЛАВИАТУРЫ
    Private Sub obj_KeyPressRun(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = TextBoxAllow(sender, e)
        If e.Handled Then Exit Sub
        RunSobyt(MyObj, trans("Нажатие клавиатуры"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить ввод"))) = trans("Да") Then e.Handled = True
        End If
    End Sub
    Private Sub obj_KeyDownRun(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        RunSobyt(MyObj, trans("Нажатие вниз кнопки"), e, e.GetType)
    End Sub
    Private Sub obj_KeyUpRun(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        RunSobyt(MyObj, trans("Отжатие кнопки"), e, e.GetType)
    End Sub

    ' СОБЫТИЯ МЕНЮ
    Private Sub obj_DropDownClosedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Вложенное меню закрылось"), e, e.GetType)
    End Sub
    Private Sub obj_DropDownOpenedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Вложенное меню открылось"), e, e.GetType)
    End Sub
    Private Sub obj_DropDownOpeningRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Вложенное меню открывается"), e, e.GetType)
    End Sub

    ' ПРОЧИЕ СОБЫТИЯ
    Private Sub obj_TextChangedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Изменение текста"), e, e.GetType)
    End Sub
    Public Sub obj_GotFocusRun(ByVal sender As Object, ByVal e As System.EventArgs)
        If proj.isINITIALIZATED = False Then
            RunSobyt(MyObj, trans("Получение фокуса"), e, e.GetType)
        End If
    End Sub
    Private Sub obj_LostFocusRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Потеря фокуса"), e, e.GetType)
    End Sub
    Public Sub obj_PaintRun(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        If proj.isINITIALIZATED = False Then
            ' If proj.alreadyRun Then Exit Sub
            RunSobyt(MyObj, trans("Прорисовка"), e, e.GetType)
        End If
    End Sub
    Public Sub obj_LoadRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("Создание"), e, e.GetType)
    End Sub
    Public Sub obj_ScrollRun(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        RunSobyt(MyObj, trans("Прокрутка"), e, e.GetType)
    End Sub
    Public Sub obj_ScrollRun1(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        RunSobyt(MyObj, trans("Прокрутка1"), e, e.GetType)
    End Sub
    Public Sub obj_ScrollRun2(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        RunSobyt(MyObj, trans("Прокрутка2"), e, e.GetType)
    End Sub
    Public Sub obj_ScrollRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Движение бегунка"), e, e.GetType)
    End Sub
    Public Sub obj_ResizeRun(ByVal sender As Object, ByVal e As System.EventArgs)
        ' obj.props.height = obj.height
        '  obj.props.width = obj.width
    End Sub
    'Private Sub obj_DisposedRun(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If UCase(obj.Props.mainForm) = UCase(trans("Да")) Then proj.StopProject()
    'End Sub
    Private Sub obj_FormClosingRun(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        RunSobyt(MyObj, trans("Закрытие окна"), New EventArgs, (New EventArgs).GetType)
        If UCase(obj.Props.ForbidClose) = UCase(trans("Да")) Then e.Cancel = True : Exit Sub
        If UCase(obj.Props.mainForm) = UCase(trans("Да")) And proj.isCLOSING = False Then
            obj.hide() : HookStops()
            ' Выставить флаг чтобы поток вызвал функцию StopProject т.к. нельзя работать с объектами созданными не в этом потоке
            If proj.isPotok Then proj.StopPr = True Else proj.StopProject()
        Else
            ' Если проекты запущен в режиме только АКТИВНОЕ окно
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
        RunSobyt(MyObj, trans("Разделитель перемещен"), e, e.GetType)
    End Sub
    Private Sub obj_SplitterMovingRun(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs)
        'obj.props.SplitterDistance = obj.SplitterDistance
        RunSobyt(MyObj, trans("Разделитель перемещается"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить перемещение"))) = trans("Да") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_SizeChangedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        If Iz.IsFORM(MyObj) Then If MyObj.MyObjs Is Nothing Then Exit Sub
        RunSobyt(MyObj, trans("Изменились размеры"), e, e.GetType)
    End Sub
    Private Sub obj_VisibleChangedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        If proj.isINITIALIZATED = False Then
            RunSobyt(MyObj, trans("Изменилась видимость"), e, e.GetType)
        End If
    End Sub

    ' СОБЫТИЯ БРАУЗЕРА
    Private Sub WebBrowser1_CanGoBackChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Назад можно изменилось"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_CanGoForwardChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Вперед можно изменилось"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        RunSobyt(MyObj, trans("Страница загрузилась"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_FileDownload(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Страница загружается"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs)
        RunSobyt(MyObj, trans("Перешел по ссылке"), e, e.GetType)
    End Sub
    Private Sub WebBrowser1_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs)
        RunSobyt(MyObj, trans("Переходит по ссылке"), e, e.GetType)
    End Sub

    Private Sub WebBrowser1_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        RunSobyt(MyObj, trans("Открытие в новом окне"), e, e.GetType)
        'If proj.Param.ParamyUp Is Nothing = False Then
        '    If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить в новом окне"))) = trans("Да") Then e.Cancel = True
        'End If
    End Sub
    Private Sub WebBrowser1_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Статусная строка изменилась"), e, e.GetType)
    End Sub
    '' Значит нам передали имя браузера в виде Окно.Браузер
    'Dim brw, frm, ob, indx As String
    'brw = obj.props.OpenNewWindowLink
    '' Разделяем имя на имя окна и имя браузера
    'Dim spl() As String = brw.Split(".")
    'If spl.Length <> 2 Then Errors.MessangeExclamen(Errors.InvalidWebBrowser(brw)) : Exit Sub
    '' Заносим предварительное имя
    'frm = spl(0)
    'ob = spl(1)
    'indx = 0
    '' Если браузер с индексом, то извлечь его из имени
    'If ob.IndexOf("[") <> -1 Then
    '    If ob.IndexOf("]") = -1 Then Errors.MessangeExclamen(Errors.InvalidWebBrowser(brw)) : Exit Sub
    '    indx = ob.Split("[")(1).Split("]")(0)
    '    ob = ob.Split("[")(0)
    'End If


    ' СОБЫТИЯ ТАБПЕЙДЖ
    Private Sub TabControl_Deselected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs)
        RunSobyt(MyObj, trans("Снялось выделение закладки"), e, e.GetType)
    End Sub
    Private Sub TabControl_Deselecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
        RunSobyt(MyObj, trans("Снимается выделение закладки"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить событие"))) = trans("Да") Then e.Cancel = True
        End If
    End Sub
    Private Sub TabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Выделили закладку"), e, e.GetType)
    End Sub
    Private Sub TabControl_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
        RunSobyt(MyObj, trans("Выделяют закладку"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить событие"))) = trans("Да") Then e.Cancel = True
        End If
    End Sub

    ' СОБЫТИЯ ТАБЛИЦ
    Private Sub Table_SelectionChangedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Изменилось выделение"), e, e.GetType)
    End Sub
    Private Sub Table_CellBeginEditRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        RunSobyt(MyObj, trans("Начало редактирования ячейки"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить событие"))) = trans("Да") Then e.Cancel = True
        End If
    End Sub
    Private Sub Table_CellClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("Клик по ячейке"), e, e.GetType)
    End Sub
    Private Sub Table_CellMouseDownRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            If obj.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True Then
                RunSobyt(MyObj, trans("Клик по выделенной ячейке"), e, e.GetType)
            End If
        End If
    End Sub
    Private Sub Table_CellDoubleClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("Двойной клик по ячейке"), e, e.GetType)
    End Sub
    Private Sub Table_CellEndEditRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("Конец редактирования ячеки"), e, e.GetType)
    End Sub
    Private Sub Table_CellEnterRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("Ячейка в фокусе"), e, e.GetType)
    End Sub
    Private Sub Table_CellLeaveRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RunSobyt(MyObj, trans("Ячека потеряла фокус"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnDisplayIndexChangedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
        RunSobyt(MyObj, trans("Столбец переместили"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnHeaderMouseClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        RunSobyt(MyObj, trans("Клик по заголовку столбца"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnHeaderMouseDoubleClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        RunSobyt(MyObj, trans("Двойной клик по заголовку столбца"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnSortModeChangedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
        RunSobyt(MyObj, trans("Сортировка столбца"), e, e.GetType)
    End Sub
    Private Sub Table_ColumnWidthChangedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
        RunSobyt(MyObj, trans("Изменилась ширина столбца"), e, e.GetType)
    End Sub
    Private Sub Table_RowHeaderMouseClickRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        RunSobyt(MyObj, trans("Клик по заголовку строки"), e, e.GetType)
    End Sub
    Private Sub Table_RowHeightChangedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        RunSobyt(MyObj, trans("Изменилась вышина строки"), e, e.GetType)
    End Sub
    Private Sub Table_RowsAddedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        If obj.props.isSelecExecute = False Then RunSobyt(MyObj, trans("Добавли строку"), e, e.GetType)
    End Sub
    Private Sub Table_RowsRemovedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        If obj.props.isSelecExecute = False Then RunSobyt(MyObj, trans("Удалили строку"), e, e.GetType)
    End Sub

    ' СОБЫТИЯ СПИСКА И ЛИНКЛАБЕЛИ
    Private Sub obj_SelectedIndexChangedRun(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Изменение выбранной записи"), e, e.GetType)
    End Sub
    Private Sub obj_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If DaOrNet(MyObj.obj.props.InternetLink) Then MyObj.obj.props.GoInternetLink()
        RunSobyt(MyObj, trans("Клик по ссылке"), e, e.GetType)
    End Sub

    ' СОБЫТИЯ КАЛЕНДАРЯ
    Private Sub obj_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Календарь закрылся"), e, e.GetType)
    End Sub
    Private Sub obj_DropDown(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Календарь раскрылся"), e, e.GetType)
    End Sub
    Private Sub obj_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Значение изменилось"), e, e.GetType)
    End Sub

    ' КОНТЕКСТНОЕ МЕНЮ
    Private Sub obj_OpeningRun(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        RunSobyt(MyObj, trans("Открытие"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить событие"))) = trans("Да") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_ClosedRun(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs)
        RunSobyt(MyObj, trans("Закрылось"), e, e.GetType)
    End Sub
    Private Sub obj_ClosingRun(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs)
        RunSobyt(MyObj, trans("Закрытие"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить событие"))) = trans("Да") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_OpenedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Открылось"), e, e.GetType)
    End Sub

    '  КЛИЕНТ-СЕРВЕР
    Private Sub obj_ConnectedToServerRun(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs)
        RunSobyt(MyObj, trans("Присоединились к серверу"), e, e.GetType)
    End Sub
    Private Sub obj_ConnectionClientRun(ByVal sender As Object, ByVal e As WinsockConnectionRequestEventArgs)
        RunSobyt(MyObj, trans("Присоединился клиент"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить событие"))) = trans("Да") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_CountChangedRun(ByVal sender As Object, ByVal e As WinsockCollectionCountChangedEventArgs)
        RunSobyt(MyObj, trans("Изменилось число клиентов"), e, e.GetType)
    End Sub
    Private Sub obj_TextReceivedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Пришел текст"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_CommandReceivedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Пришла команда"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_FileReceivedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Пришел файл"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_DisconnectedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Отключение"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_ErrorReceivedRun(ByVal sender As Object, ByVal e As WinsockErrorReceivedEventArgs)
        RunSobyt(MyObj, trans("Произошла ошибка"), e, e.GetType)
    End Sub
    Private Sub obj_SendTextCompleteRun(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
        RunSobyt(MyObj, trans("Отправился текст"), e, e.GetType)
    End Sub
    Private Sub obj_SendFileCompleteRun(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
        RunSobyt(MyObj, trans("Отправился файл"), e, e.GetType)
    End Sub
    Private Sub obj_SendProgressRun(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
        RunSobyt(MyObj, trans("Идет отправление"), e, e.GetType)
    End Sub
    Private Sub obj_ReceiveProgressRun(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs)
        RunSobyt(MyObj, trans("Идет прием данных"), e, e.GetType)
    End Sub
    Private Sub obj_StateChangedRun(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs)
        RunSobyt(MyObj, trans("Изменился статус"), e, e.GetType)
    End Sub

    ' ИНТЕРНЕТ
    Private Sub obj_SendingQueryRun(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        RunSobyt(MyObj, trans("Отправляется запрос"), e, e.GetType)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить событие"))) = trans("Да") Then e.Cancel = True
        End If
    End Sub
    Private Sub obj_SentQueryRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("Отправился запрос"), e, e.GetType)
    End Sub
    Private Sub obj_ReceivedResponseRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("Пришел ответ"), e, e.GetType)
    End Sub
    Private Sub obj_DownloadCancelledRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("Загрузка отменена"), e, e.GetType)
    End Sub

    ' РЕДКИЕ
    Sub Minimize(ByVal s As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("Сворачивание"), Nothing, Me.GetType)
    End Sub
    Sub DoubleClickTray(ByVal s As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("Двойной клик по трею"), Nothing, Me.GetType)
    End Sub
    Private Sub obj_ChangingValueRun(ByVal sender As Object, ByVal e As String)
        RunSobyt(MyObj, trans("Изменение значения"), e, e.GetType)
    End Sub
    Private Sub obj_ChangedValueRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Изменилось значение"), e, e.GetType)
    End Sub
    Private Sub obj_OnEndRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Конец проигрывания"), Nothing, Me.GetType)
    End Sub
    Public Sub obj_CheckedChangedRun(ByVal sender As Object, ByVal e As EventArgs)
        RunSobyt(MyObj, trans("Изменение отметки"), e, e.GetType)
    End Sub
    Private Sub obj_HScroll(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Горизонтальная прокрутка"), e, e.GetType)
    End Sub
    Private Sub obj_VScroll(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Вертикальная прокрутка"), e, e.GetType)
    End Sub
    Private Sub obj_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs)
        If DaOrNet(MyObj.obj.props.InternetLink) Then MyObj.obj.props.GoInternetLink(e.LinkText)
        RunSobyt(MyObj, trans("Клик по ссылке документа"), e, e.GetType)
    End Sub
    Private Sub obj_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If proj.alreadyRun Then Exit Sub
        obj.props.IntervalCount += 1
        RunSobyt(MyObj, trans("Тикнул"), e, e.GetType)
    End Sub
    Public Sub obj_ClickButtonRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Клик кнопки"), e, e.GetType)
    End Sub
    Public Sub obj_ActivationSuccessulRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Активация успешная"), e, e.GetType)
    End Sub
    Public Sub obj_ActivationFailedRun(ByVal sender As Object, ByVal e As System.EventArgs)
        RunSobyt(MyObj, trans("Активация неудачная"), e, e.GetType)
    End Sub

    ' нужные
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
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить в новом окне"))) = trans("Да") Then
                proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить в новом окне"))) = ""
                e.Cancel = True : Exit Sub
            End If
        End If
        If e.Cancel = False And obj.lastLink <> "" Then
            If UCase(obj.props.OpenNewWindowLink) = UCase(trans("В данном браузере")) Then
                obj.Navigate(obj.lastlink)
                e.Cancel = True
            ElseIf UCase(obj.props.OpenNewWindowLink) = UCase(trans("По умолчанию")) Then
            Else
                ' Пробуем получить переданный браузер
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

    '<<<<<<<< ДЕЙСТВИЯ >>>>>>>>>
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
        If obj.TypeObj = "PoluObj" Then ' Определение формы для полуобъектов
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
            ' если проект не в запуске
            If proj.ActiveForm Is Nothing = False Then Return Nothing
            ' если проект run
            MyForm = proj.f(proj.f.Length - 1) : Return MyForm
        Else ' Определение формы для обычных объектов
            Dim iters As Integer
            While cont.conteiner Is Nothing = False
                cont = cont.conteiner
                If Iz.IsCM(cont) Then MyForm = cont.GetMyForm : Return MyForm
                iters += 1
                If iters > 200 Then Throw New Exception("Ошибка объекта " + cont.conteiner.NodeTemp.Text)
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
        ' Обновление имени
        ' Если ветки с новым инемен еще не существует или её переименовывают
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
