Imports System.IO
Imports System.Net

Public Class MainForm
    Dim otn As Double = 0.5 ' Отношение ширины первой колонки списка свойств к ширине списка
    Public SelNodes() As TreeNode
    Dim CopyTree, CopyUndoRedo As String
    Public CodeView As String, ObjTrs As ObjsTreesText
    Dim CopyObj As String
    Public SelNode, Pod4erkNode As TreeNode
    Dim SelType As TreeViewHitTestLocations
    Dim isEditTree, MouseD, MouseM As Boolean
    Public forMyButton As Object = SkinPictures
    Public EditNodeText, FindText As EditProperty
    Public debugNode As TreeNode, param As PropertysSobyt
    Public NI As NotifyIcon

    ' <<<<<< СОЗДАНИЕ КОМПОНЕНТОВ ФОРМЫ >>>>>>>
#Region "INITIALIZATE"

    Sub ni_dbl(ByVal s As Object, ByVal e As MouseEventArgs)
        Application.DoEvents()
        Me.WindowState = FormWindowState.Normal
        Me.Show()
        NI.Visible = False
    End Sub
    ' ЗАГРУЗКА АЛГОРИТМА
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        Me.Text = AppDomain.CurrentDomain.BaseDirectory & AppDomain.CurrentDomain.FriendlyName
        ' Ассоциировать с алджи файлы .alg
        If IsHttpCompil = False Then AssociateMyApp("Algoritm2", Environment.GetCommandLineArgs()(0), ".alg", SkinsPath & "\icon.ico")
        ' Инициализация, требующаяся для создания проекта
        InitializeBeforeProject()
        ' Загрузка програмы и проекта
        proj = New Project(trans("Проект"))
        proj.ActiveForm.proj = proj
        ' если используют в качестве компилятора
        If IsHttpCompil Then
            NI = New NotifyIcon
            NI.Icon = Me.Icon
            NI.Visible = False
            AddHandler NI.MouseDoubleClick, AddressOf ni_dbl
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = False : Timer3.Start()
        End If
        ' Остальная инициализация
        InitializeAfterProject()
        proj.f(proj.f.Length - 2).obj.contextmenustrip = ObjsMenu
        ' Открытие проекта из строки аргументов
        If Environment.GetCommandLineArgs().Length >= 2 Then OpenProj(Environment.GetCommandLineArgs()(1))

        ' Проверка обновлений
        If IsHttpCompil = False Then
            CheckNewVersion()
        End If

        ' Запуск либо обучения, либо демки
        If StartEdu = "Yes" Then
            Show()
            Dim ed As New Edu : ed.Show()
        Else
            ' If PerfomanceProgress() = False Then Dim dm As New Demo : dm.TopMost = True : dm.Show()
        End If

        
    End Sub
    ' ИНИЦИАЛИЗАЦИЯ, ТРЕБУЮЩАЯСЯ ДЛЯ СОЗДАНИЯ ПРОЕКТА
    Sub InitializeBeforeProject(Optional ByVal fromOptions As Boolean = False)
        ' попробовать получить параметры
        OpenOptions(True)
        ' Создание папок в директории юзера
        CreateUserFolders()

        If fromOptions = False Then
            ' Заставка
            intr.ShowInTaskbar = False
            intr.Show()
            intr.TopMost = False
            Application.DoEvents()
            intr.ProgressBarValue = 5
            ' загрузка всех настроек
            OptionsForm.OpenOptions()
            lang_name = lang_def
            If IsHttpCompil Then
                lang_name = "Russian" : lang_def = "Russian"
            End If
        End If
        ' Задание скина
        PicturesPath = SkinsPath & "\" & Skin
        ' Задание языка
        setLangs(Not (fromOptions))
        Pictures16.ColorDepth = ColorDepth.Depth32Bit
        Pictures32.ColorDepth = ColorDepth.Depth32Bit
        ' Создание дерева и имайдж листа
        Tree = TreeView : Tree.ImageList = Pictures16
        AddPictures(Pictures16.Images, PicturesPath, New String() {".ICO", ".BMP", ".PNG"}) : Pictures16.ImageSize = New Size(16, 16)
        AddPictures(Pictures32.Images, PicturesPath, New String() {".ICO", ".BMP", ".PNG"}) : Pictures32.ImageSize = New Size(32, 32)
        ReDim HelpObjs(0) : HelpObjs(HelpObjs.Length - 1) = Tree
        ' Создание массива полезных объектов
        CreatePoleznie()
        '============================
        intr.ProgressBarValue = 50
        '============================
        ' Делегат
        delegatNodeStop = New RunProj_NodeStop_delegate(AddressOf RunProj_NodeStop)
        delegatEnableds = New Enableds_delegate(AddressOf Enableds)

        ' РАБОТА СО СКИНОМ
        ' Сохранение цветов скина
        SkinColors.Clear()
        SkinColors = Get2List(PicturesPath & "\Colors.ini", " = ", AddressOf GetColorFromStr)
        ColKode = SkinColors("ColKode")
        ColProperty = SkinColors("ColProperty")
        ColMethod = SkinColors("ColMethod")
        ColObject = SkinColors("ColObject")
        ColFunction = SkinColors("ColFunction")
        ColConsts = SkinColors("ColConsts")
        ColKovi4ki = SkinColors("ColKovi4ki")
        ColBreakpoint = SkinColors("ColBreakpoint")
        ColDebugNode = SkinColors("ColDebugNode")
        ' Сохранение рисунков скина
        SkinPictures.Clear()
        AddPictures(SkinPictures, PicturesPath, PicExten)
        ' Сохранение опций скина
        SkinOptions.Clear()
        SkinOptions = Get2List(PicturesPath & "\Options.ini", " = ")
        AlphaPik = SkinOptions("AlphaPik")
        AlphaNiz = SkinOptions("AlphaNiz")

        ' Реферал
        referral = Trim(IO.File.ReadAllText(ObjectsPath & "Referral.txt", System.Text.Encoding.UTF8))
    End Sub
    ' Создание папок в директории юзера
    Private Sub CreateUserFolders()
        ' Папка Алгоритм 2 в пользователе
        If IO.Directory.Exists(UserPath) = False Then
            IO.Directory.CreateDirectory(UserPath)
        End If
        ' Папка Алгоритм 2 в АппДата
        If IO.Directory.Exists(AppDataPath) = False Then
            IO.Directory.CreateDirectory(AppDataPath)
        End If
        ' Папка проектов
        If IO.Directory.Exists(ProjectsPath) = False Then
            IO.Directory.CreateDirectory(ProjectsPath)
        End If
        ' Копирование папки примеров проектов
        If IO.Directory.Exists(SamplesPath) = False Or FirstLaunchAfterUpdate Then
            If IO.Directory.Exists(SamplesPathDefault) Then
                My.Computer.FileSystem.CopyDirectory(SamplesPathDefault, SamplesPath, True)
            End If
        End If
        ' Копирование папки компиляции
        If IO.Directory.Exists(CompilPath) = False Or FirstLaunchAfterUpdate Then
            If IO.Directory.Exists(CompilPathDefault) Then
                My.Computer.FileSystem.CopyDirectory(CompilPathDefault, CompilPath, True)
            End If
        End If
        ' Перенос файлов
        If IO.File.Exists(ParamFilePath) = False Then
            If IO.File.Exists(ParamFilePathDefault) Then
                My.Computer.FileSystem.CopyFile(ParamFilePathDefault, ParamFilePath, True)
            End If
        End If
        ' Перенос файлов
        If IO.File.Exists(OptionsFilePath) = False Then
            If IO.File.Exists(OptionsFilePathDefault) Then
                My.Computer.FileSystem.CopyFile(OptionsFilePathDefault, OptionsFilePath, True)
            End If
        End If

        FirstLaunchAfterUpdate = False
    End Sub
    ' Проверка обновлений
    Private Function CheckNewVersion(Optional ByVal ignoreSkipped As Boolean = False) As Boolean
        Dim newVersion As String = GetRequestResult(lastVersionUrl).Trim()

        If String.IsNullOrEmpty(newVersion) Or newVersion = Version Or (newVersion = SkippedVersion And Not ignoreSkipped) Then
            If String.IsNullOrEmpty(newVersion) And ignoreSkipped Then
                Throw New Exception(transInfc("Невозможно подключиться к * и проверить обновления программы").Replace("*", SiteAlg))
            End If
            Return False
        End If

        Dim updForm As Update = New Update()
        updForm.ShowDialog(newVersion)
        updForm.Dispose()

        Return True
    End Function
    ' Получить содиржимое по url
    Private Function GetRequestResult(ByVal url As String) As String
        Try
            Dim request As WebRequest = WebRequest.Create(url)
            Dim response As WebResponse = request.GetResponse()

            Dim sr As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8) ' Кодировка указывается в зависимости от кодировки ответа сервера
            Dim read(256) As Char
            Dim count As Integer = sr.Read(read, 0, 256)
            Dim result As String = ""
            While (count > 0)
                Dim str As String = New String(read, 0, count)
                result &= str
                count = sr.Read(read, 0, 256)
            End While

            Return result
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ' ПРОЧАЯ ИНИЦИАЛИЗАЦИЯ
    Sub InitializeAfterProject(Optional ByVal fromOptions As Boolean = False)
        Dim ts As ToolStripButton, i, j As Integer, str(0) As String

        MnFrm = Application.OpenForms.Item("MainForm")
        MnFrmPotok = Application.OpenForms.Item("MainForm")

        ' Прогресс-Форма
        ProgressForm.ShowInTaskbar = False

        ' Скрыть перемещатель 
        Peremeschatel.SendToBack()

        '============================
        intr.ProgressBarValue = 99 ' + (Convert.ToInt16(bistro_HW) * 65)
        intr.refresh()
        '============================

        ' СОЗДАНИЕ И НАСТРОЙКА СПИСОКA СВОЙСТВ
        ListView.Columns.Clear()
        ListView.Columns.Add("Property", transInfc("Свойства"), ListView.Width \ 2 - 3)
        ListView.Columns.Add("Value", transInfc("Значения"), ListView.Width \ 2 - 3)
        lwEditProperty = New EditProperty() : lwEditProperty.Visible = False
        ListView.Controls.Add(lwEditProperty) : lwEditProperty.BorderStyle = BorderStyle.FixedSingle
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = ListView
        lwEditPropertySet()

        ListView.BackColor = SkinColors("MainText")
        TreeView.BackColor = SkinColors("MainText")

        ' СОЗДАНИЕ НАБОРОВ И СПИСКОВ ДЛЯ МАСТЕРА

        CreateArrays()

        '============================
        intr.ProgressBarValue = 99 '+ (Convert.ToInt16(bistro_HW) * 50)
        intr.refresh()
        '============================

        CreateConstants()

        '============================
        intr.ProgressBarValue = 99 ' + (Convert.ToInt16(bistro_HW) * 50)
        '============================

        CreateHelpWords()

        Me.Visible = False

        If lang_interface = "Russian" Then
            SiteAlg = algDomenRu
        Else
            SiteAlg = algDomenEn
        End If

        ' ЗАДАНИЯ СПРАВОЧНОЙ ИНФОРМАЦИИ
        InfoObjs = Get2ListInfoObjs()
        InfoElems = Get2List(LanguagePath & "\" & lang_interface & "\" & "\InfoElems.info", "~~")
        InfoProps = Get2ListInfoProps()
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = InfoPropsLabel
        InfoPropsLabel.ForeColor = SkinColors("MainLabels")
        InfoPropsLabel.LinkColor = SkinColors("ColLink")
        InfoPropsLabel.ActiveLinkColor = SkinColors("ColActiveLink")
        InfoPropsLabel.BackColor = Color.Transparent

        ' Создание СТРОКИ ПОИСКА над деревом
        If FindText Is Nothing Then
            FindText = New EditProperty(True) : forFindText.Controls.Add(FindText)
            FindText.Left = -2 : FindText.Top = -2
            FindText.Width = forFindText.Width + 4 : FindText.Height = forFindText.Height + 4
            FindText.Anchor = AnchorStyles.Left + AnchorStyles.Top + AnchorStyles.Right + AnchorStyles.Bottom
            FindText.Name = "FindText" : FindText.Text = ""
            FindText.Tag = Me
        End If
        FindText.BackColor = SkinColors("MainText")
        FindLabel.Text = transInfc("Поиск") & ":"
        FindLabel.ForeColor = SkinColors("MainLabels")
        FindLabel.BackColor = Color.Transparent
        FindButton.Text = transInfc("Найти")
        FindButton.BackgroundImage = SkinPictures("MainButton")
        FindButton.ForeColor = SkinColors("MainLabels")
        FindCheck.BackColor = Color.Transparent
        FindCheck.ForeColor = SkinColors("MainLabels")
        FindCheck.Text = transInfc("Слово целиком")
        FindCombo.BackColor = SkinColors("MainText")
        FindCombo.Items.Clear()
        FindCombo.Items.Add(transInfc("Везде"))
        FindCombo.Items.Add(transInfc("В текущем окне"))
        FindCombo.Items.Add(transInfc("В текущем объекте"))
        FindCombo.Items.Add(transInfc("В текущем событии"))
        FindCombo.Items.Add(transInfc("На текущем уровне и ниже"))
        FindCombo.SelectedIndex = 0

        ' Создание СТРОКИ ПОД ДЕРЕВОМ трее
        If EditNodeText Is Nothing Then
            EditNodeText = New EditProperty(True) : forEditNodeText.Controls.Add(EditNodeText)
            EditNodeText.Left = -2 : EditNodeText.Top = -2
            EditNodeText.Width = forEditNodeText.Width + 4 : EditNodeText.Height = forEditNodeText.Height + 4
            EditNodeText.Anchor = AnchorStyles.Left + AnchorStyles.Top + AnchorStyles.Right + AnchorStyles.Bottom
            EditNodeText.Name = "EditNodeText" : EditNodeText.Text = ""
            EditNodeText.Tag = Me
            AddHandler EditNodeText.SelectedText, AddressOf SelectedText
        End If
        EditNodeText.BackColor = SkinColors("MainText")
        Apply.Text = transInfc("Применить")
        Apply.BackgroundImage = SkinPictures("MainButton")
        Apply.ForeColor = SkinColors("MainLabels")

        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = forEditNodeText

        ' СОЗДАНИЕ КОНСТРУКТОРА ДЕЙСТВИЙ
        tab = TabControl2 : tab.ImageList = Pictures16
        ' создание событий
        i = 0
        If SobytsTab Is Nothing Then SobytsTab = tab.TabPages("sobyts")
        SobytsTab.BackgroundImage = SkinPictures(SobytsTab.Name)
        SobytsTab.BackColor = SkinColors(SobytsTab.Name)
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = SobytsTab
        SobytsTab.Text = transInfc("События")
        SobytsTab.ImageKey = SobytsTab.Name : SobytsTab.Tag = i
        Label1.Text = transInfc(Label1.Text)
        Label1.ForeColor = SkinColors("SobytLabel")
        ComboBox1.BackColor = SkinColors("MainText")
        ComboBox2.BackColor = SkinColors("MainText")
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = SobytsTab
        ' создание Действий
        i += 1
        If DeistTab Is Nothing Then DeistTab = tab.TabPages("deistviya")
        DeistTab.BackgroundImage = SkinPictures(DeistTab.Name)
        DeistTab.BackColor = SkinColors(DeistTab.Name)
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = DeistTab
        DeistTab.Text = transInfc("Действия")
        DeistTab.ImageKey = DeistTab.Name : DeistTab.Tag = i
        If CreateDs Is Nothing = False Then DeistPanel.Controls.Remove(CreateDs)
        If CreateDs Is Nothing Then
            CreateDs = New CreateDeistv()
            CreateDs.Dock = DockStyle.Fill
        End If
        CreateDs.ForeColor = SkinColors("DeistLabel")
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CreateDs.forShowObj
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CreateDs.forEditPr
        DeistPanel.Controls.Add(CreateDs)
        ' создание Условий
        i += 1
        If ifTab Is Nothing Then ifTab = tab.TabPages("ifs")
        ifTab.BackgroundImage = SkinPictures(ifTab.Name)
        ifTab.BackColor = SkinColors(ifTab.Name)
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = ifTab
        ifTab.Text = transInfc("Условия")
        ifTab.ImageKey = ifTab.Name : ifTab.Tag = i
        If CreateIfs IsNot Nothing Then DeistPanel.Controls.Remove(CreateIfs)
        If CreateIfs Is Nothing Then
            CreateIfs = New CreateIf
            CreateIfs.Dock = DockStyle.Fill
        End If
        CreateIfs.ForeColor = SkinColors("ifLabel")
        'CreateIfs.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CreateIfs.ifUsuallyPanel
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CreateIfs.IfPodIfPanel
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CreateIfs.ifElsePanel
        ifPanel.Controls.Add(CreateIfs)
        ' создание Цикла
        i += 1
        If CycleTab Is Nothing Then CycleTab = tab.TabPages("cycles")
        CycleTab.BackgroundImage = SkinPictures(CycleTab.Name)
        CycleTab.BackColor = SkinColors(CycleTab.Name)
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CycleTab
        CycleTab.Text = transInfc("Циклы")
        CycleTab.ImageKey = CycleTab.Name : CycleTab.Tag = i
        If CreateCycles Is Nothing = False Then DeistPanel.Controls.Remove(CreateCycles)
        If CreateCycles Is Nothing Then
            CreateCycles = New CreateCycle
            CreateCycles.Dock = DockStyle.Fill
        End If
        CreateCycles.ForeColor = SkinColors("CycleLabel")
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CreateCycles.WhilePanel
        CyclePanel.Controls.Add(CreateCycles)
        ' создание комментариев
        i += 1
        If CommTab Is Nothing Then CommTab = tab.TabPages("comm")
        CommTab.BackgroundImage = SkinPictures(CommTab.Name)
        CommTab.BackColor = SkinColors(CommTab.Name)
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CommTab
        CommTab.Text = transInfc("Комментарии")
        CommTab.ImageKey = CommTab.Name : CommTab.Tag = i
        Label2.Text = transInfc(Label2.Text)
        Label2.ForeColor = SkinColors("CommLabel")
        If EditPrComm Is Nothing Then
            EditPrComm = New EditProperty() : forEditPrComm.Controls.Add(EditPrComm) : EditPrComm.Dock = DockStyle.Fill
        End If
        EditPrComm.Text = trans("Ваш пояснительный комментарий")
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = CommTab
        ' Настроить кнопочки конструктора
        Create1.Text = transInfc(Create1.Text) : Cancel1.Text = transInfc(Cancel1.Text)
        Create1.BackgroundImage = SkinPictures("MainButton")
        Create1.ForeColor = SkinColors("MainLabels")
        Cancel1.BackgroundImage = SkinPictures("MainButton")
        Cancel1.ForeColor = SkinColors("MainLabels")
        Tree.SelectedNode = Tree.Nodes(0)

        ' Обновление рисунков MyButton'ов
        NodeDel.RefreshPic(SkinPictures)
        NodeEdit.RefreshPic(SkinPictures)
        NodeUp.RefreshPic(SkinPictures)
        NodeDown.RefreshPic(SkinPictures)
        NodeBreakpoint.RefreshPic(SkinPictures)
        ' Настройка кнопок редактирования дерева
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = NodeEdit
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = NodeDel
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = NodeUp
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = NodeDown
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = NodeBreakpoint


        SaveFileDialog1.Filter = transInfc("Проекты Алгоритма") & " (*.alg)" & "|*.alg|" & transInfc("Готовые программы") & " (*.exe)" & "|*.exe|" & transInfc("Все файлы") & " (*.*)" & "|*.*"
        OpenFileDialog1.Filter = transInfc("Проекты Алгоритма") & " (*.alg)" & "|*.alg|" & transInfc("Все файлы") & " (*.*)" & "|*.*"
        SaveFileDialog2.Filter = transInfc("Готовые программы") & " (*.exe)" & "|*.exe|" & transInfc("Все файлы") & " (*.*)" & "|*.*"
        SaveFileDialog3.Filter = transInfc("Проекты VB.NET") & " (*.vbproj)" & "|*.vbproj|" & transInfc("Все файлы") & " (*.*)" & "|*.*"
        OpenFileDialog1.InitialDirectory = proj.pPath : SaveFileDialog1.InitialDirectory = proj.pPath
        SaveFileDialog2.InitialDirectory = proj.pPath : SaveFileDialog3.InitialDirectory = proj.pPath

        ' Создание пустышек
        CreatePustishki(Pustishki)

        ' Перевод всех меню
        transMenu(TreeMenu) : transMenu(TreeMiniMenu) : transMenu(ObjsMenu)
        transMenu(EditMiniMenu) : transMenu(MenuStrip1) : transMenu(EditPrMenu, True)
        ' Перевод всех пенелей
        transPanel(StandartPanel) : transPanel(ObjectPanel)
        ' Сортировка панелей
        sortPanel(ObjectPanel)
        ' Сортировка меню
        sortMenu(HelpWords)

        If PerfomanceProgress() Then
            HideRegMenu()
        Else
            RegistrMenu.Visible = True
            RegistrMenu.Tag = ""
        End If

        '============================
        intr.ProgressBarValue = 100
        '============================

        ' Скин
        DeistLabel.ForeColor = SkinColors(DeistLabel.Name)
        IfLabel.ForeColor = SkinColors(IfLabel.Name)
        CycleLabel.ForeColor = SkinColors(CycleLabel.Name)
        SplitListView.Panel2.BackgroundImage = SkinPictures("InfoProps")
        SplitListView.Panel2.BackColor = SkinColors("InfoPropsMain")
        SplitTreeView.Panel1.BackgroundImage = SkinPictures("TreeButtons")
        SplitTreeView.Panel1.BackColor = SkinColors("TreeButtonsColor")
        SplitTreeView.Panel2.BackgroundImage = SkinPictures("TreeButtons")
        SplitTreeView.Panel2.BackColor = SkinColors("TreeButtonsColor")
        SplitApply.Panel2.BackgroundImage = SkinPictures("Apply")
        SplitCreate.Panel2.BackgroundImage = SkinPictures("CreateCancel")
        SplitMain.BackColor = SkinColors("SplitsBack") : SplitMain.BorderStyle = SkinOptions("RamkaMain")
        SplitForms.BackColor = SkinColors("SplitsBack") : SplitForms.BorderStyle = SkinOptions("RamkaForms")
        SplitRight.BackColor = SkinColors("SplitsBack") : SplitRight.BorderStyle = SkinOptions("RamkaRight")
        SplitListView.BackColor = SkinColors("SplitsBack") : SplitListView.BorderStyle = SkinOptions("RamkaListView")
        SplitApply.BackColor = SkinColors("SplitsBack") : SplitApply.BorderStyle = SkinOptions("RamkaApply")
        SplitCreate.BackColor = SkinColors("SplitsBack") : SplitCreate.BorderStyle = SkinOptions("RamkaCreate")
        SplitCreate.Panel1.BackColor = SkinColors("Tab")
        SplitCreate.BackgroundImage = SkinPictures(SobytsTab.Name)
        SplitOutputRun.BackColor = SkinColors("SplitsBack")
        SplitTreeView.BackColor = SkinColors("SplitsBack") : SplitTreeView.BorderStyle = SkinOptions("RamkaTreeView")
        ListView.BackColor = SkinColors(ListView.Name)
        ObjectPanel.BackgroundImage = SkinPictures("Menu")
        StandartPanel.BackgroundImage = SkinPictures("Menu")
        MenuStrip1.BackgroundImage = SkinPictures("Menu")
        ToolStripContainer1.TopToolStripPanel.BackgroundImage = SkinPictures("Menu")
        ToolStripContainer1.LeftToolStripPanel.BackgroundImage = SkinPictures("Menu")
        ToolStripContainer1.RightToolStripPanel.BackgroundImage = SkinPictures("Menu")
        ToolStripContainer1.BottomToolStripPanel.BackgroundImage = SkinPictures("Menu")

        ' Создание значков быстрой справки (иконки с вопросиками)
        helps = New PictureBox() {help1, help2, help3, help4, help5, help6}
        For i = 0 To helps.Length - 1
            helps(i).Image = Pictures32.Images("HelpMenu")
            helps(i).SizeMode = PictureBoxSizeMode.StretchImage
            helps(i).Cursor = Cursors.Hand
            helps(i).Size = New Size(16, 16)
            helps(i).BackColor = Color.Transparent
            AddHandler helps(i).Click, AddressOf Helps_Click
            ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = helps(i)
        Next
        If proj Is Nothing = False And isDevelop Then
            For i = 0 To proj.f.Length - 2
                proj.f(i).SplitCont.BackColor = SkinColors("FormsTab")
                proj.f(i).SplitCont.Panel1.BackgroundImage = SkinPictures("FormsTab")
                proj.f(i).SplitCont.Panel2.BackgroundImage = SkinPictures("FormsTab")
            Next
        End If

        ToolStripContainer1.Tag = New Object() {ToolStripContainer1.TopToolStripPanel, ToolStripContainer1.LeftToolStripPanel, ToolStripContainer1.RightToolStripPanel, ToolStripContainer1.BottomToolStripPanel}
        OpenOptions()
        '  Me.WindowState = FormWindowState.Maximized
        ' SplitTreeView.SplitterDistance = 0
        'SplitApply.SplitterDistance = 99999
        Me.Visible = True
        intr.hide()


        'If fromOptions Then
        '    transObjects(False, True)
        'End If
    End Sub

    Public Sub HideRegMenu()
        RegistrMenu.Visible = False
        RegistrMenu.Tag = "Regs"
    End Sub

    ' ОБЕСПЕЧЕНИЕ ДРАГДРОПА
    Private Sub MainForm_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        If e.Data IsNot Nothing Then
            If e.Data.GetData("FileName") IsNot Nothing Then
                If Sohranilili() Then
                    OpenProj(e.Data.GetData("FileName")(0))
                End If
            End If
        End If
    End Sub
    Private Sub MainForm_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        e.Effect = DragDropEffects.Link
    End Sub

    ' Сохранение параметров окна
    Public Sub SaveParametrs()
        If IsHttpCompil Then Exit Sub
        Dim txt As String = ""
        MainForm_SizeChanged(Nothing, Nothing)
        ' форма
        txt &= "#SkippedVersion" & vbCrLf & SkippedVersion & vbCrLf & vbCrLf
        txt &= "#PayLink" & vbCrLf & PayLink & vbCrLf & vbCrLf
        txt &= "#FirstLaunchAfterUpdate" & vbCrLf & YesOrNo(FirstLaunchAfterUpdate) & vbCrLf & vbCrLf
        txt &= "#WindowState" & vbCrLf & Me.WindowState & vbCrLf & vbCrLf
        txt &= "#Left" & vbCrLf & MainX & vbCrLf & vbCrLf
        txt &= "#Top" & vbCrLf & MainY & vbCrLf & vbCrLf
        txt &= "#Height" & vbCrLf & MainHeight & vbCrLf & vbCrLf
        txt &= "#Width" & vbCrLf & MainWidth & vbCrLf & vbCrLf
        ' Панели и меню
        txt &= "#MainMenu" & vbCrLf & MenuStrip1.Parent.Tag & vbCrLf & vbCrLf
        txt &= "#MainMenuX" & vbCrLf & MenuStrip1.Left & vbCrLf & vbCrLf
        txt &= "#MainMenuY" & vbCrLf & MenuStrip1.Top & vbCrLf & vbCrLf
        txt &= "#StandartPanel" & vbCrLf & StandartPanel.Parent.Tag & vbCrLf & vbCrLf
        txt &= "#StandartPanelX" & vbCrLf & StandartPanel.Left & vbCrLf & vbCrLf
        txt &= "#StandartPanelY" & vbCrLf & StandartPanel.Top & vbCrLf & vbCrLf
        txt &= "#ObjectPanel" & vbCrLf & ObjectPanel.Parent.Tag & vbCrLf & vbCrLf
        txt &= "#ObjectPanelX" & vbCrLf & ObjectPanel.Left & vbCrLf & vbCrLf
        txt &= "#ObjectPanelY" & vbCrLf & ObjectPanel.Top & vbCrLf & vbCrLf
        ' режим запуска
        txt &= "#RunDrop" & vbCrLf & YesOrNo(RunDropPanel.Checked) & vbCrLf & vbCrLf
        txt &= "#RunSaveDrop" & vbCrLf & YesOrNo(RunSaveDropPanel.Checked) & vbCrLf & vbCrLf
        txt &= "#RunFormDrop" & vbCrLf & YesOrNo(RunFormDropPanel.Checked) & vbCrLf & vbCrLf
        ' прочее
        txt &= "#SplitListView" & vbCrLf & SplitListView.SplitterDistance & vbCrLf & vbCrLf
        txt &= "#SplitTreeView" & vbCrLf & SplitTreeView.SplitterDistance & vbCrLf & vbCrLf
        txt &= "#SplitApply" & vbCrLf & SplitApply.SplitterDistance + (SplitOutputRun.Height - SplitOutputRun.SplitterDistance) & vbCrLf & vbCrLf
        txt &= "#SplitCreate" & vbCrLf & SplitCreate.SplitterDistance & vbCrLf & vbCrLf
        txt &= "#SplitMain" & vbCrLf & SplitMain.SplitterDistance & vbCrLf & vbCrLf
        txt &= "#SplitForms" & vbCrLf & SplitForms.SplitterDistance & vbCrLf & vbCrLf
        txt &= "#SplitRight" & vbCrLf & SplitRight.SplitterDistance & vbCrLf & vbCrLf
        txt &= "#SplitOutputRun" & vbCrLf & SplitOutputRun.SplitterDistance & vbCrLf & vbCrLf
        txt &= "#MasterHeight" & vbCrLf & MasterHeight & vbCrLf & vbCrLf
        txt &= "#MasterWidth" & vbCrLf & MasterWidth & vbCrLf & vbCrLf
        txt &= "#MasterSplit" & vbCrLf & MasterSplit & vbCrLf & vbCrLf
        txt &= "#OptionsHeight" & vbCrLf & OptionsHeight & vbCrLf & vbCrLf
        txt &= "#OptionsWidth" & vbCrLf & OptionsWidth & vbCrLf & vbCrLf
        txt &= "#RecentProjcts" & vbCrLf & Join(RecentProjcts.ToArray, ",") & vbCrLf & vbCrLf
        Dim fl As IO.StreamWriter = IO.File.CreateText(ParamFilePath)
        fl.Write(txt) : fl.Close()
    End Sub
    Public Sub OpenOptions(Optional ByVal onlyFirst As Boolean = False)
        If Not IO.File.Exists(ParamFilePath) Then
            Exit Sub
        End If

        Dim fl As IO.StreamReader = IO.File.OpenText(ParamFilePath)
        Dim txt As String = fl.ReadToEnd : fl.Close()

        ' переменные обслуживания
        SkippedVersion = GetNuzhPunkt("#SkippedVersion", txt)
        PayLink = GetNuzhPunkt("#PayLink", txt)
        FirstLaunchAfterUpdate = YesOrNo(GetNuzhPunkt("#FirstLaunchAfterUpdate", txt))
        
        If (onlyFirst) Then Exit Sub

        ' форма
        Me.WindowState = GetNuzhPunkt("#WindowState", txt)
        MainX = GetNuzhPunkt("#Left", txt)
        MainY = GetNuzhPunkt("#Top", txt)
        MainHeight = GetNuzhPunkt("#Height", txt)
        MainWidth = GetNuzhPunkt("#Width", txt)
        Me.Left = MainX
        Me.Top = MainY
        Me.Height = MainHeight
        Me.Width = MainWidth
        ' Панели и меню. По ним надо пройтись 20 раза чтобы все встали в соответствии со своими X и Y
        Dim flag As Byte = 0
        While flag < 20
            Dim panel As String = GetNuzhPunkt("#MainMenu", txt)
            If panel <> "" Then ToolStripContainer1.Tag(panel).Controls.Add(MenuStrip1)
            MenuStrip1.Left = GetNuzhPunkt("#MainMenuX", txt)
            MenuStrip1.Top = GetNuzhPunkt("#MainMenuY", txt)
            panel = GetNuzhPunkt("#StandartPanel", txt)
            If panel <> "" Then ToolStripContainer1.Tag(panel).Controls.Add(StandartPanel)
            StandartPanel.Left = GetNuzhPunkt("#StandartPanelX", txt)
            StandartPanel.Top = GetNuzhPunkt("#StandartPanelY", txt)
            panel = GetNuzhPunkt("#ObjectPanel", txt)
            If panel <> "" Then ToolStripContainer1.Tag(panel).Controls.Add(ObjectPanel)
            ObjectPanel.Left = GetNuzhPunkt("#ObjectPanelX", txt)
            ObjectPanel.Top = GetNuzhPunkt("#ObjectPanelY", txt)
            flag += 1
        End While
        Me.Show()
        ' режим запуска
        RunDropPanel.Checked = YesOrNo(GetNuzhPunkt("#RunDrop", txt))
        RunSaveDropPanel.Checked = YesOrNo(GetNuzhPunkt("#RunSaveDrop", txt))
        RunFormDropPanel.Checked = YesOrNo(GetNuzhPunkt("#RunFormDrop", txt))
        If RunDropPanel.Checked = False And RunSaveDropPanel.Checked = False And RunFormDropPanel.Checked = False Then
            RunDropPanel.Checked = True
        End If
        ' прочее
        On Error Resume Next
        SplitMain.SplitterDistance = GetNuzhPunkt("#SplitMain", txt)
        SplitRight.SplitterDistance = GetNuzhPunkt("#SplitRight", txt)
        SplitForms.SplitterDistance = GetNuzhPunkt("#SplitForms", txt)
        SplitOutputRun.SplitterDistance = GetNuzhPunkt("#SplitOutputRun", txt)
        SplitListView.SplitterDistance = GetNuzhPunkt("#SplitListView", txt)
        SplitTreeView.SplitterDistance = 1 'GetNuzhPunkt("#SplitTreeView", txt)
        SplitApply.SplitterDistance = GetNuzhPunkt("#SplitApply", txt)
        SplitCreate.SplitterDistance = 9999 'GetNuzhPunkt("#SplitCreate", txt)
        MasterHeight = GetNuzhPunkt("#MasterHeight", txt)
        MasterWidth = GetNuzhPunkt("#MasterWidth", txt)
        MasterSplit = GetNuzhPunkt("#MasterSplit", txt)
        OptionsHeight = GetNuzhPunkt("#OptionsHeight", txt)
        OptionsWidth = GetNuzhPunkt("#OptionsWidth", txt)
        RecentProjcts.Clear()
        RecentProjcts.AddRange(GetNuzhPunkt("#RecentProjcts", txt).Split(","))
        RecentProjectsCreate()
        ' Задний фон элементов пенелей, которые не влезли и теперь в списке
        backgroundPanel(StandartPanel) : backgroundPanel(ObjectPanel)
    End Sub
    ' Создание подменю ПОСЛЕДНИЕ ПРОЕКТЫ
    Sub RecentProjectsCreate()
        ' очистка списка от пустых и уже не существующих проектов
        Dim i As Integer = 0
        While RecentProjcts.Count > i
            If i >= maxRecentProjs Then RecentProjcts.RemoveAt(i) : Continue While
            If IO.File.Exists(RecentProjcts(i)) = False Then RecentProjcts.RemoveAt(i) : i -= 1
            i += 1
        End While
        ' создание меню
        RecentProjects.DropDownItems.Clear()
        For i = 0 To RecentProjcts.Count - 1
            Dim mnIt As New ToolStripMenuItem()
            mnIt.Text = IO.Path.GetFileName(RecentProjcts(i))
            mnIt.Tag = RecentProjcts(i)
            mnIt.ToolTipText = RecentProjcts(i)
            If i < 9 Then mnIt.ShortcutKeys = Keys.Alt + Keys.D1 + i
            AddHandler mnIt.Click, AddressOf RecentProjects_Click
            RecentProjects.DropDownItems.Add(mnIt)
        Next
    End Sub
    ' НАСТРОЙКА EDITPROPERTY МЕНЮ
    Private Sub EditPrMenu_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditPrMenu.Opened
        EditPrMenu.Tag = EditPrMenu.SourceControl
    End Sub
    Sub AddHelpWordsToMenu(ByVal cat As String, ByVal hws() As String)
        Dim i As Integer
        Dim menuItem, HWmenuItem As ToolStripMenuItem
        ' Находим нужный пункт в меню
        HWmenuItem = EditPrMenu.Items("HelpWords")
        menuItem = HWmenuItem.DropDownItems(cat)
        ' Запихиваем все вспом слова в массив ToolStripMenuItem
        Dim itms(hws.Length - 1) As ToolStripItem
        For i = 0 To hws.Length - 1
            itms(i) = New ToolStripMenuItem(hws(i))
            AddHandler itms(i).Click, AddressOf HW_Click
        Next
        ' Добавляем
        menuItem.DropDownItems.Clear()
        menuItem.DropDownItems.AddRange(itms)
    End Sub
    Sub CreateHWMenu()
        Dim i As Integer
        ' СОЗДАНИЕ МЕНЮШКИ ВСЕХ ВСПОМОГАТЕЛЬНЫХ СЛОВ
        Dim HWmenuItem As ToolStripMenuItem = EditPrMenu.Items("HelpWords")

        ' Создание всех категорий
        HWmenuItem.DropDownItems.Clear()
        Dim itms(HWCategrsSort.Count - 1) As ToolStripItem
        For i = 0 To HWCategrsSort.Count - 1
            itms(i) = New ToolStripMenuItem(HWCategrsSort.GetKey(i).ToString)
            itms(i).Name = HWCategrsSort.GetKey(i).ToString
        Next
        HWmenuItem.DropDownItems.AddRange(itms)

        ' Добавление всех вспомагательных слов
        For i = 0 To HWCategrsSort.Count - 1
            AddHelpWordsToMenu(HWCategrsSort.GetKey(i), HWCategrsSort.GetByIndex(i))
            '============================
            'intr.ProgressBarValue = 50 + ((40 / HWCategrsSort.Count) * i)
            '============================
        Next

        ' Добавление "прочих" вспомогательных слов
        Dim eventMenuItem As ToolStripMenuItem
        For i = 0 To HWOthers.Length - 1
            eventMenuItem = HWmenuItem.DropDownItems.Add(HWOthers(i))
            AddHandler eventMenuItem.Click, AddressOf HW_Click
        Next

        ' Перевод меню
        transMenuRecurs(HelpWords, False)
        HelpWords.Text = transInfc("Вспомогательные слова")

        'menuItem = HWmenuItem.DropDownItems(trans("Цвета"))
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWCols.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWCols(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Papki")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWPapki.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWPapki(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("KnopkiMishi")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWKnopkiMishi.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWKnopkiMishi(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Klavishi")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWKeys.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWKeys(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        ''============================
        'intr.ProgressBarValue = 60
        ''============================
        'menuItem = HWmenuItem.DropDownItems("Anchori")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWAnchors.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWAnchors(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("bkImStyli")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWbkImStyles.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWbkImStyles(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Cursorri")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWCursori.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWCursori(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Docki")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWDocks.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWDocks(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("FlatStyli")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWFlatStyles.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWFlatStyles(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Aligni")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWAligns.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWAligns(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Fonti")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWFonts.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWFonts(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("TextImagi")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWTextImages.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWTextImages(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("BorderStyli")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWBorderStyles.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWBorderStyles(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Orientationi")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWOrientations.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWOrientations(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        ''============================
        'intr.ProgressBarValue = 65
        ''============================
        'menuItem = HWmenuItem.DropDownItems("FixedPaneli")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWFixedPanels.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWFixedPanels(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("DeskResolutioni")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWDeskResolution.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWDeskResolution(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("TypeRegistri")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWTypeRegistry.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWTypeRegistry(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("ScrollBari")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWScrollBarz.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWScrollBarz(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("DisplayStyli")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWDisplayStyles.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWDisplayStyles(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("TextDirectioni")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWTextDirections.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWTextDirections(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("ReadyStaty")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWReadyStates.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWReadyStates(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("DocumentEncodingi")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWDocumentEncodings.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWDocumentEncodings(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Refreshi")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWRefreshs.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWRefreshs(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("FormBorderStyly")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWFormBorderStyles.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWFormBorderStyles(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("StartPositioni")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWStartPositions.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWStartPositions(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("WindowsStaty")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWWindowStates.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWWindowStates(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Alignmentsz")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWAlignments.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWAlignments(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("CellBorderStyly")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWCellBorderStyles.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWCellBorderStyles(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        ''============================
        'intr.ProgressBarValue = 70
        ''============================
        'menuItem = HWmenuItem.DropDownItems("SelectionMody")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWSelectionModes.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWSelectionModes(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("EditMody")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWEditModes.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWEditModes(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("Filtri")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWFilters.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWFilters(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("LinkBehaviori")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWLinkBehaviors.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWLinkBehaviors(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("TextPositioni")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWTextPositions.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWTextPositions(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("MsgStyleButtoni")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWMsgStyleButtons.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWMsgStyleButtons(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("MsgStyleTypy")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWMsgStyleTypes.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWMsgStyleTypes(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("BdTypy")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWBdTypes.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWBdTypes(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("DateFormaty")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWDateFormats.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWDateFormats(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("TickStyly")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWTickStyles.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWTickStyles(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("FileEncodingy")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWFileEncodings.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWFileEncodings(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("SizeMody")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWSizeModes.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWSizeModes(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("InputTypy")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWInputTypes.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWInputTypes(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next
        'menuItem = HWmenuItem.DropDownItems("ClientServerStaty")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWClientServStates.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWClientServStates(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next

        'menuItem = HWmenuItem.DropDownItems("ContentTypy")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWContentTypes.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWContentTypes(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next

        'menuItem = HWmenuItem.DropDownItems("HttpMethody")
        'menuItem.DropDownItems.Clear()
        'For i = 0 To HWHttpMethods.Length - 1
        '    eventMenuItem = menuItem.DropDownItems.Add(HWHttpMethods(i))
        '    AddHandler eventMenuItem.Click, AddressOf HW_Click
        'Next

        '        sortMenu(HelpWords)
    End Sub
    Sub EditPrCreateMenu(ByVal ed As EditProperty)
        AddHandler EditPrMenu.Items("UndoMenu5").Click, AddressOf ed.UndoMenu5_Click
        AddHandler EditPrMenu.Items("RedoMenu5").Click, AddressOf ed.RedoMenu5_Click
        AddHandler EditPrMenu.Items("CutMenu5").Click, AddressOf ed.CutMenu5_Click
        AddHandler EditPrMenu.Items("CopyMenu5").Click, AddressOf ed.CopyMenu5_Click
        AddHandler EditPrMenu.Items("PasteMenu5").Click, AddressOf ed.PasteMenu5_Click
        AddHandler EditPrMenu.Items("DelMenu5").Click, AddressOf ed.DelMenu5_Click
        AddHandler EditPrMenu.Items("SelectAllMenu5").Click, AddressOf ed.SelectAllMenu5_Click
    End Sub
    ' КОГДА НАЖАЛИ НА НУЖНОЕ ВСПОМОГАТЕЛЬНОЕ СЛОВО
    Public Sub HW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rich As RichTextBox = EditPrMenu.Tag
        If sender.text = trans("Символ новой строки") Then
            rich.SelectedText = Chr(182)
        Else
            rich.SelectedText = sender.text
        End If
        proj.Podsvetka(rich)
    End Sub

#End Region

    ' <<<<<< ОБЩИЕ ФУНКЦИИ АЛГОРИТМА >>>>>>>
#Region "COMMON"

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not ReadyToCloseProgramm() Then
            e.Cancel = True
        End If
    End Sub

    ' Можно ли закрыть программу?
    Public Function ReadyToCloseProgramm() As Boolean
        Dim result As Boolean = True

        ' Сохранить параметры элементов окна (ширина, положение)
        SaveParametrs()
        ' Остановили ли проект
        If Me.Ostanovili = False Then Return False
        ' Сохранили ли проект
        If Me.Sohranilili = False Then result = False
        If RunProj Is Nothing = False Then RunProj.ClosAl = True

        Return result
    End Function
    ' ПОЛУЧАЕТ ПОЛНЫЙ КОД ПРОЕКТА
    Function GetCoding(Optional ByVal toExeFile As Boolean = False, Optional ByVal code As String = "", Optional ByRef ObjsTres As ObjsTreesText = Nothing) As String
        Dim i As Integer
        ' Бывает что передают уже сделаный код, т.к. нажимают "сохранить и запустить"
        If code = "" Then
            code = "Language = " & lang_name & vbCrLf
            If ObjsTres IsNot Nothing Then ObjsTres.popravka = code.Length
            For i = 0 To proj.f.Length - 2
                code &= Perevodi.ToStrFromObj(proj.f(i), True, True, , , ObjsTres)
            Next
        End If
        code &= "#ProjectParams" & vbCrLf
        ' переменные проекта, которые не нужны в полностью откомпилированной программе
        If toExeFile = False Then
            Dim comms() As TreeNode = getComms()
            If comms Is Nothing = False Then
                code &= "#Comms" & vbCrLf
                code &= GetCopyTree(comms, True, True) & vbCrLf
                code &= "#EndComms" & vbCrLf
            End If
            If Breaks Is Nothing = False Then
                If Breaks(0) Is Nothing = False Then
                    code &= "#Breaks" & vbCrLf
                    For i = 0 To Breaks.Length - 1
                        code &= Breaks(i).Name & vbCrLf
                    Next
                    code &= "#EndBreaks" & vbCrLf
                End If
            End If
            If proj.f.Length > 1 Then
                code &= "#PoleznieDistance" & vbCrLf
                For i = 0 To proj.f.Length - 2
                    code &= proj.f(i).SplitCont.Panel2.Height & vbCrLf
                Next
                code &= "#EndPoleznieDistance" & vbCrLf
            End If
            Dim Expands As String = GetNodesExpands(Tree.Nodes)
            If Expands <> "" Then code &= "#Expands" & vbCrLf & Expands & "#EndExpands" & vbCrLf
            If SelNode Is Nothing = False Then code &= "#SelNode" & vbCrLf & SelNode.Name & vbCrLf
            If proj.ActiveForm Is Nothing = False Then
                code &= "#ActiveForm" & vbCrLf & GetUNameObj(proj.ActiveForm) & vbCrLf
                If proj.ActiveForm.ActiveObj Is Nothing = False Then
                    If proj.ActiveForm.ActiveObj(0) IsNot Nothing Then
                        code &= "#ActiveObj" & vbCrLf & GetUNameObj(proj.ActiveForm.ActiveObj(0)) & vbCrLf
                    End If
                End If
            End If
        End If
        code &= "#ImagePath" & vbCrLf & proj.iPathShort & vbCrLf
        code &= "#ImageDefName" & vbCrLf & proj.pPicNameDef & vbCrLf
        code &= "#pProgressForm" & vbCrLf & proj.pProgressForm & vbCrLf
        code &= "#Icon" & vbCrLf & proj.pIcon & vbCrLf
        code &= "#EndProjectParams" & vbCrLf
        Return code
    End Function
    ' Получить комментарии, которые находятся в дереве 0 и 1 левеле
    Function getComms()
        Dim i, j As Integer, comms() As TreeNode = Nothing
        For i = 0 To Tree.Nodes.Count - 1
            If Tree.Nodes(i).Tag = "Comm" Then
                ReDims(comms) : comms(comms.Length - 1) = Tree.Nodes(i) : Continue For
            End If
            For j = 0 To Tree.Nodes(i).Nodes.Count - 1
                If Tree.Nodes(i).Nodes(j).Tag = "Comm" Then
                    ReDims(comms) : comms(comms.Length - 1) = Tree.Nodes(i).Nodes(j) : Continue For
                End If
            Next
        Next
        Return comms
    End Function
    ' Получить раскрытые ветки дерева
    Function GetNodesExpands(ByVal node As TreeNodeCollection) As String
        Dim i As Integer, str As String = ""
        For i = 0 To node.Count - 1
            If node(i).IsExpanded Then str &= node(i).Name & vbCrLf
            str &= GetNodesExpands(node(i).Nodes)
        Next
        Return str
    End Function

    ' ФУНКЦИЯ, ПРЕОБРАЗУЮЩАЯ СТРОКУ СО ЗНАЧЕНИЕМ, В ЦВЕТ БАЗИКА
    Function GetColorFromStr(ByVal str As String) As Object
        Dim col As Color = Nothing
        ' Если что-то не так, то возвращается по умолчанию черный
        If str Is Nothing Then Return Color.Black
        Dim split() As String = str.Split(";")
        ' Если цвет задается в формате *;*;*;
        If split.Length > 3 Then
            If split(3) <> "" Then
                col = Drawing.Color.FromArgb(split(0), split(1), split(2), split(3))
            Else
                col = Drawing.Color.FromArgb(split(0), split(1), split(2))
            End If
        ElseIf split.Length >= 3 Then
            col = Drawing.Color.FromArgb(split(0), split(1), split(2))
        End If
        If col = Nothing Then col = Drawing.Color.FromName(str)
        Return col
    End Function

    ' ФУНКЦИЯ ВОЗРАЩАЮЩАЯ СТРОКУ БЕЗ ИЗМЕНЕНИЙ (нужна как делегат для Get2List)
    Function GetStrFromStr(ByVal str As String) As Object
        Return str
    End Function

    ' ДОБАВЛЯЕТ В КОЛЛЕКЦИЮ ВСЕ РИСУНКИ ИЗ ПАПКИ path
    Sub AddPictures(ByRef PicList As Object, ByVal Path As String, ByVal ParamArray extend() As String)
        Dim i As Integer
        ' Все файлы заданной папки
        Dim pics() As String = IO.Directory.GetFiles(Path, "*", IO.SearchOption.AllDirectories)
        PicList.clear()
        For i = 0 To pics.Length - 1
            ' Если расширение как у рисунка
            If Array.IndexOf(extend, UCase(IO.Path.GetExtension(pics(i)))) <> -1 Then
                PicList.Add(IO.Path.GetFileNameWithoutExtension(pics(i)), Image.FromFile(pics(i)))
            End If
        Next
    End Sub

    ' ДЕЛАЕТ ФОРМУ АКТИВНОЙ
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim i As Integer
        If proj Is Nothing Or TabControl1.SelectedTab Is Nothing Then ListView.Items.Clear() : TabControl2.TabPages.Clear() : Exit Sub
        If proj.f Is Nothing Then ListView.Items.Clear() : TabControl2.TabPages.Clear() : Exit Sub
        For i = 0 To proj.f.Length - 1
            ' Если выделенный таб, есть таб просматриваемой формы
            If TabControl1.SelectedTab.Controls.IndexOf(proj.f(i).obj.Parent.Parent) <> -1 Then
                proj.ActiveForm = proj.f(i) : proj.f(i).FillListView() : Exit Sub
            End If
        Next
        proj.ActiveForm = proj.f(0)
    End Sub

    ' ПОКАЗЫВАЕТ МАРКЕРЫ ПОСЛЕ НЕБОЛЬШОЙ ЗАДЕРЖКИ
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        proj.ActiveForm.marker_vis(True) : Timer1.Stop()
    End Sub

    ' ПОКАЗЫВАЕТ МАРКЕРЫ ПРИ ИЗМЕНЕНИИ РАЗМЕРОВ СПЛИТ ЧАСТЕЙ
    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitMain.SplitterMoved
        If proj Is Nothing = False Then If proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis(True)
    End Sub
    Private Sub SplitContainer2_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitForms.SplitterMoved
        SplitContainer1_SplitterMoved(sender, e)
    End Sub

    Private Sub MainForm_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Me.Focus()
        If IsHttpCompil Then
            If Me.WindowState = FormWindowState.Minimized Then
                If NI IsNot Nothing Then NI.Visible = True
            End If
        Else
            If Me.WindowState = FormWindowState.Normal And Me.Visible = True Then
                MainHeight = Me.Height : MainWidth = Me.Width : MainX = Me.Left : MainY = Me.Top
            End If
        End If
    End Sub

    ' КНОПКА РЕДАКТИРОВАНИЯ УЗЛОВ, ВНИЗУ ДЕРЕВА
    Public Sub Apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Apply.Click
        'ToolStripContainer1.LeftToolStripPanel.Controls.Add(MenuStrip1)
        'Exit Sub
        '      Me.Left = Me.PreferredSize.Height 
        If EditNodeText.Enabled = False Then Exit Sub
        If Tree.SelectedNode Is Nothing Then Exit Sub
        If Tree.SelectedNode Is SelNode = False Then SelNode = Tree.SelectedNode
        If Tree.SelectedNode.Level <= 1 And Tree.SelectedNode.Tag <> "Comm" Then
            Dim oldSel As TreeNode = Tree.SelectedNode.Parent, oldInd As Integer = Tree.SelectedNode.Index
            Dim fl As Boolean
            Dim objs() As Object = GetMyObjsFromTreeNode(Tree.SelectedNode)
            If objs Is Nothing Then Exit Sub
            Dim i As Integer
            For i = 0 To objs.Length - 1
                If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                If objs(i).GetMyForm.SetPropertys(trans("Имя"), EditNodeText.ActiveTextBox.Text, objs(i)) = False Then fl = True
            Next
            If fl Then Exit Sub
            proj.ActiveForm.FillListView()
            ' Если перепрыгнул на верх дерева изза того что редактировали последний узел, то вернуть выделение на место
            If Tree.SelectedNode.Index = 0 Then
                Try : Tree.SelectedNode = oldSel.Nodes(oldInd) : Catch ex As Exception : End Try
            End If
        Else
            ' отформатировать текст если это не комментарий
            Dim txt As String = New CodeString(UbratKluchSlova(SelNode.Tag, EditNodeText.Text)).Text
            If Tree.SelectedNode.Tag <> "Comm" Then EditNodeText.Text = SozdatKluchSlova(SelNode.Tag, txt)
            If bistro_UnRe = False Then proj.UndoRedo("Изменение текста узла", Tree.SelectedNode.Name, EditNodeText.Text, Tree.SelectedNode.Text)
            Tree.SelectedNode.Text = EditNodeText.Text
        End If
    End Sub

    ' КНОПКА ПОИСКА В ДЕРЕВЕ
    Dim lastFind As Integer = -1
    Public Sub FindButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindButton.Click
        ' Определяем область поиска
        If FindCombo.SelectedIndex < 4 Then
            MaxLevel = FindCombo.SelectedIndex
        Else
            MaxLevel = SelNode.Level
        End If
        ' Определяем узел, с которого начинать поиск
        Dim fndNode As TreeNode
        If SelNode Is Nothing Then SelNode = Tree.SelectedNode
        If lastFind = -1 Then
            fndNode = FindFistNodeWithLevel(SelNode, MaxLevel)
        Else
            fndNode = SelNode
        End If

        ' СОБСТВЕННО ИЩЕМ
        lastFind = FindNext(fndNode, FindText.Text, lastFind + 1, FindCheck.Checked)

        ' Обрабатываем исключительные результаты
        If lastFind = -1 Then
            If MsgBoxResult.Yes = MsgBox(transInfc("Поиск дошел до конца выбранного участка дерева. Продолжить поиск, начиная с начала?"), MsgBoxStyle.YesNo) Then
                FindButton_Click(sender, e)
            Else
                EditNodeText.ActiveTextBox.Select()
                EditNodeText.ActiveTextBox.Focus()
            End If
        End If
    End Sub
    Function FindFistNodeWithLevel(ByVal nod As TreeNode, ByVal lev As Integer)
        If lev = 0 Then Return Tree.Nodes(0)
        While nod.PrevVisibleNode.Level >= lev
            nod = nod.PrevVisibleNode
        End While
        Return nod
    End Function
    Public MaxLevel As Integer
    Function FindNext(ByVal currNode As TreeNode, ByVal str As String, ByVal start As Integer, ByVal whole As Boolean) As Integer
        Dim ret As Integer
        If str = "" Then Return -1
        ' Ищем в узле текст
        ret = FindInNode(currNode, str, start, whole)
        ' Если нашли - выводим
        If ret >= 0 Then
            FindSuccess(currNode, str, ret)
            Return ret
        Else
            ' Если НЕ НАШЛИ в этом узле
            Dim nextNod As TreeNode = Nothing
            If currNode.Nodes.Count > 0 Then
                nextNod = currNode.Nodes(0)
            Else
                nextNod = currNode.NextVisibleNode
            End If
            If nextNod Is Nothing Then
                Return -1
            ElseIf nextNod.Level < MaxLevel Then
                Return -1
            Else
                Return FindNext(nextNod, str, 0, whole)
            End If
        End If
    End Function
    Function FindInNode(ByVal nod As TreeNode, ByVal str As String, ByVal start As Integer, ByVal whole As Boolean) As Integer
        If start > nod.Text.Length - 1 Then Return -1
        Dim ind As Integer = nod.Text.IndexOf(str, start, StringComparison.CurrentCultureIgnoreCase)
        ' Если надо искать слово целиком
        If ind <> -1 And whole = True Then
            If nod.Text.Length > ind + str.Length Then
                If Char.IsLetterOrDigit(nod.Text.Chars(ind + str.Length)) Then
                    Return FindInNode(nod, str, ind + str.Length, whole)
                End If
            End If
        End If
        Return ind
    End Function
    Sub FindSuccess(ByVal nod As TreeNode, ByVal str As String, ByVal start As Integer)
        Tree.SelectedNode = nod
        SelNode = nod
        SelNodes = Nothing
        TreeView1_AfterSelect(Tree, Nothing)
        EditNodeText.ActiveTextBox.Select()
        EditNodeText.ActiveTextBox.Focus()
        EditNodeText.ActiveTextBox.SelectionStart = start
        EditNodeText.ActiveTextBox.SelectionLength = str.Length
    End Sub


    ' СОРТИРОВКА ОБЪЕКТОВ И ФОРМ В ПРОГРАММЕ ПО ИХ ПОЛОЖЕНИЮ В ДЕРЕВЕ
    Sub ReSortMyObjs(ByVal node As TreeNode)
        Dim i, j, k As Integer
        If node Is Nothing Then Exit Sub
        ' Если передвигали объекты
        If node.Level = 1 And node.Tag = "Obj" Then
            Dim frm() As Object = proj.GetMyFormsFromName(node.Parent.Name)
            Dim nodes As TreeNodeCollection = node.Parent.Nodes
            ' просканировать все формы с именем такимже как и у формы выделенного объекта
            For i = 0 To frm.Length - 1
                Dim newMyObjs() As Object = Nothing
                ' просматриваем все узлы которые одного уровня с узлом выделенного объекта
                For j = 0 To nodes.Count - 1
                    Dim objs() As Object = GetMyObjsFromTreeNode(nodes(j))
                    If objs Is Nothing Then Exit Sub
                    ' Добавляем в будущий список объектов формы те объекты, которые были в ней до этого, но т.к. мы идет по узлам, они будут отсортированы в порядке узлов
                    For k = 0 To objs.Length - 1
                        If Array.IndexOf(frm(i).MyObjs, objs(k)) <> -1 Then
                            ReDims(newMyObjs) : newMyObjs(newMyObjs.Length - 1) = objs(k)
                        End If
                    Next
                Next
                ' Заменить список объектов формы на новый
                frm(i).MyObjs = newMyObjs
            Next
        ElseIf node.Level = 0 And node.Tag = "Obj" Then
            Dim newMyForms() As Forms = Nothing
            Dim newTabs() As TabPage = Nothing, selTab As TabPage = TabControl1.SelectedTab
            ' просматриваем все узлы форм
            For j = 0 To Tree.Nodes.Count - 1
                Dim frms() As Object = GetMyObjsFromTreeNode(Tree.Nodes(j))
                ' Добавляем в будущий список форм те формы, которые были в нем до этого, но т.к. мы идет по узлам, они будут отсортированы в порядке узлов
                For k = 0 To frms.Length - 1
                    ReDims(newMyForms) : newMyForms(newMyForms.Length - 1) = frms(k)
                    ReDims(newTabs) : newTabs(newTabs.Length - 1) = frms(k).tab
                Next
            Next
            ' добавить в новый список полезные объекты из старого списка
            ReDims(newMyForms) : newMyForms(newMyForms.Length - 1) = proj.f(proj.f.Length - 1)
            ' Заменить список объектов формы на новый
            proj.f = newMyForms
            ' Сделать новый список табов
            TabControl1.TabPages.Clear() : TabControl1.TabPages.AddRange(newTabs)
            TabControl1.SelectedTab = selTab
        End If
    End Sub
    ' СОРТИРОВКА СРАЗУ ВСЕХ ОБЪЕКТОВ И ФОРМ В ПРОГРАММЕ ПО ИХ ПОЛОЖЕНИЮ В ДЕРЕВЕ
    Sub ReSortMyObjs(ByVal tree As TreeView)
        Dim i As Integer
        ' сортировка всех форм
        If tree.Nodes.Count > 0 Then ReSortMyObjs(tree.Nodes(0))
        ' сортировка всех объектов
        For i = 0 To tree.Nodes.Count - 1
            If tree.Nodes(i).Nodes.Count > 0 Then ReSortMyObjs(tree.Nodes(i).Nodes(0))
        Next
    End Sub

#End Region

    ' <<<<<<<< ОБРАБОТЧИКИ КЛИКОВ ПО ПАНЕЛЯМ ОБЪЕКТОВ >>>>>>>>
#Region "PANELS"
    Function mozhnoObjEdit() As Boolean
        If StopMenu.Enabled = False Then Return True Else Return False
    End Function
    Private Sub tsF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window.Click
        If mozhnoObjEdit() Then proj.AddForm()
    End Sub
    Private Sub tsB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Button)
    End Sub
    Private Sub tsP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Panel)
    End Sub
    Private Sub tsDP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DPanel.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New DPanel)
    End Sub
    Private Sub tsTP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TPage.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New TPage)
    End Sub
    Private Sub tsM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Memory.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Memory)
    End Sub
    Private Sub mmenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmenu.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New MMenu)
    End Sub
    Private Sub cmenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenu.Click
        If proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New CMenu)
    End Sub
    Private Sub tsMd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Media.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Media)
    End Sub
    Private Sub tsA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Audio.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Audio)
    End Sub
    Private Sub TextBoks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoks.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New TextBoks)
    End Sub
    Private Sub CheckBoks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoks.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New CheckBoks)
    End Sub
    Private Sub RadioBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBut.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New RadioBut)
    End Sub
    Private Sub ToolPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TPanel.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New TPanel)
    End Sub
    Private Sub WBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBrowser.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New WBrowser)
    End Sub
    Private Sub Table_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Table.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Table)
    End Sub
    Private Sub ComboBoks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoks.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New ComboBoks)
    End Sub
    Private Sub CheckedList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedList.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New CheckedList)
    End Sub
    Private Sub ListBoks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoks.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New ListBoks)
    End Sub
    Private Sub Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Label)
    End Sub
    Private Sub LinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New LinkLabel)
    End Sub
    Private Sub RichText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichText.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New RichText)
    End Sub
    Private Sub ColorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorDialog.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New ColorDialog)
    End Sub
    Private Sub FontDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontDialog.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New FontDialog)
    End Sub
    Private Sub PathDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PathDialog.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New PathDialog)
    End Sub
    Private Sub SaveDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDialog.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New SaveDialog)
    End Sub
    Private Sub OpenDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenDialog.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New OpenDialog)
    End Sub
    Private Sub PrintDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDialog.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New PrintDialog)
    End Sub
    Private Sub Timer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Timer)
    End Sub
    Private Sub PictureBoks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoks.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New PictureBoks)
    End Sub
    Private Sub Calendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Calendar)
    End Sub
    Private Sub Trial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Trial.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New Trial)
    End Sub
    Private Sub TrackBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New TrackBar)
    End Sub
    Private Sub ClientServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientServer.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then
            Dim o As New ClientServer : SettingDevelop(o) : proj.ActiveForm.AddObject(o)
        End If
    End Sub
    Private Sub Internet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Internet.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then
            Dim o As New Internet : SettingDevelop(o) : proj.ActiveForm.AddObject(o)
        End If
    End Sub
    Private Sub ProgresBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar.Click
        If mozhnoObjEdit() And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.AddObject(New ProgressBar)
    End Sub

    Private Sub NewPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPanel.Click
        NewMenu_Click(sender, e)
    End Sub
    Private Sub OpenPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenPanel.Click
        OpenMenu_Click(sender, e)
    End Sub
    Private Sub SavePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePanel.Click
        SaveMenu_Click(SaveMenu, e)
    End Sub
    Private Sub SaveAsPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SaveAsMenu_Click(SaveAsMenu, e)
    End Sub
    Private Sub BuildPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuildPanel.Click
        BuildProgramMenu_Click(sender, e)
    End Sub

    Private Sub CopyPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyPanel.Click
        CopyMenu4_Click(sender, e)
    End Sub
    Private Sub CutPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutPanel.Click
        CutMenu4_Click(sender, e)
    End Sub
    Private Sub PastePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PastePanel.Click
        PasteMenu4_Click(sender, e)
    End Sub

    Private Sub tsUndo_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles UndoPanel.MouseMove, UndoMenu.MouseMove
        If proj.UndoAr Is Nothing Then Exit Sub
        Dim tool As String = proj.UndoAr(proj.UndoAr.Length - 1 - proj.UndoRedoCount)
        If tool = "" Then Exit Sub
        Dim start As Integer = tool.IndexOf("#New") + "#New".Length + 2
        sender.ToolTipText = trans("Отменить") & " " & trans("действие") & " "
        sender.ToolTipText &= tool.Substring(start, tool.IndexOf(vbCrLf, start) - start).ToLower
    End Sub
    Private Sub tsRedo_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles RedoPanel.MouseMove, RedoMenu.MouseMove
        If proj.RedoAr Is Nothing Then Exit Sub
        Dim tool As String = proj.RedoAr(proj.RedoAr.Length - proj.UndoRedoCount)
        If tool = "" Then Exit Sub
        Dim start As Integer = tool.IndexOf("#New") + "#New".Length + 2
        sender.ToolTipText = trans("Повторить") & " " & trans("действие") & " "
        sender.ToolTipText &= tool.Substring(start, tool.IndexOf(vbCrLf, start) - start).ToLower
    End Sub
    Private Sub tsUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UndoPanel.Click, UndoMenu.Click
        If proj.UndoAr Is Nothing Then Exit Sub
        proj.UndoRedoNoWrite = True
        If proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis(False)
        ProgressFormShow(transInfc("Отменение") & "...")

        Dim revers As Boolean = False
        Dim RunStr As String = proj.UndoAr(proj.UndoAr.Length - 1 - proj.UndoRedoCount)
        If RunStr.IndexOf("#Revers Undo") = 0 Then revers = True
        Console.Run(RunStr, revers)
        proj.UndoRedoCount += 1
        RedoPanel.Enabled = True : RedoMenu.Enabled = True
        If proj.UndoAr.Length - 1 - proj.UndoRedoCount < 0 Then
            UndoPanel.Enabled = False : UndoPanel.ToolTipText = "" : UndoMenu.Enabled = False : UndoMenu.ToolTipText = ""
        End If

        ProgressForm.Hide()
        proj.UndoRedoNoWrite = False
    End Sub
    Private Sub tsRedo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RedoPanel.Click, RedoMenu.Click
        proj.UndoRedoNoWrite = True
        proj.ActiveForm.marker_vis(False)
        ProgressFormShow(transInfc("Повторение") & "...")

        Dim revers As Boolean = False
        Dim RunStr As String = proj.RedoAr(proj.RedoAr.Length - proj.UndoRedoCount)
        If RunStr.IndexOf("#Revers Redo") = 0 Then revers = True
        Console.Run(RunStr, revers)
        proj.UndoRedoCount -= 1
        UndoPanel.Enabled = True : UndoMenu.Enabled = True
        If proj.RedoAr.Length - proj.UndoRedoCount >= proj.RedoAr.Length Then
            RedoPanel.Enabled = False : RedoPanel.ToolTipText = "" : RedoMenu.Enabled = False : RedoMenu.ToolTipText = ""
        End If

        ProgressForm.Hide()
        proj.UndoRedoNoWrite = False
    End Sub

    Private Sub RunPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunPanel.ButtonClick
        RunMenu_Click(sender, e)
    End Sub
    Private Sub RunDropPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunDropPanel.Click
        RunDropPanel.Checked = True
        RunSaveDropPanel.Checked = False : RunFormDropPanel.Checked = False
        RunMenu_Click(sender, e)
    End Sub
    Private Sub RunSaveDropPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunSaveDropPanel.Click
        RunSaveDropPanel.Checked = True
        RunDropPanel.Checked = False : RunFormDropPanel.Checked = False
        RunMenu_Click(sender, e)
    End Sub
    Private Sub RunFormDropPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunFormDropPanel.Click
        RunFormDropPanel.Checked = True
        RunSaveDropPanel.Checked = False : RunDropPanel.Checked = False
        RunMenu_Click(sender, e)
    End Sub
    Private Sub PausePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PausePanel.Click
        PauseMenu_Click(sender, e)
    End Sub
    Private Sub StopPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopPanel.Click
        StopMenu_Click(sender, e)
    End Sub
    Private Sub StepIntoPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepIntoPanel.Click
        StepIntoMenu_Click(sender, e)
    End Sub
    Private Sub StepOverPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepOverPanel.Click
        StepOverMenu_Click(sender, e)
    End Sub
    Private Sub StepOutPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepOutPanel.Click
        StepOutMenu_Click(sender, e)
    End Sub

    Private Sub HelpPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpPanel.Click
        HelpMenu_Click(sender, e)
    End Sub

    Private Sub AnswersPanel_Click(sender As Object, e As EventArgs) Handles AnswersPanel.Click
        AnswersMenu_Click(sender, e)
    End Sub

    ' Задний фон элементов пенелей инструментов, которые не влезли в размер формы и теперь находятся в списке в конце
    Private Sub Panels_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ObjectPanel.SizeChanged, StandartPanel.SizeChanged
        If intr.Visible = False And Me.Visible = True Then backgroundPanel(sender)
    End Sub
#End Region

    ' <<<<<< ПРОЦЕДУРА ЛОВЛИ НАЖАТИЯ КЛАВИШ НА ОБЪЕКТАХ >>>>>>>>>
#Region "PEREMESCHETEL"
    Private Sub Peremeschatel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Peremeschatel.KeyDown
        Dim i As Integer
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            Dim obj As Object = proj.ActiveForm.ActiveObj(i).obj
            Select Case e.KeyData
                Case Keys.Down : obj.Top += 1
                Case Keys.Down + Keys.Control : obj.Top += setka
                Case Keys.Down + Keys.Shift : obj.Height += 1
                Case Keys.Down + Keys.Shift + Keys.Control : obj.Height += setka
                Case Keys.Up : obj.Top -= 1
                Case Keys.Up + Keys.Control : obj.Top -= setka
                Case Keys.Up + Keys.Shift : obj.Height -= 1
                Case Keys.Up + Keys.Shift + Keys.Control : obj.Height -= setka
                Case Keys.Left : obj.Left -= 1
                Case Keys.Left + Keys.Control : obj.Left -= setka
                Case Keys.Left + Keys.Shift : obj.Width -= 1
                Case Keys.Left + Keys.Shift + Keys.Control : obj.Width -= setka
                Case Keys.Right : obj.Left += 1
                Case Keys.Right + Keys.Control : obj.Left += setka
                Case Keys.Right + Keys.Shift : obj.Width += 1
                Case Keys.Right + Keys.Shift + Keys.Control : obj.Width += setka
                Case Keys.Delete : DelMenu2_Click(Nothing, Nothing)
                Case Else : Exit For
            End Select
        Next
        Select Case e.Modifiers
            Case Keys.Control : proj.ActiveForm.ctrl = True
                '   Case Keys.Shift : proj.ActiveForm.ctrl = True
        End Select
        ' Скрывать маркеры всегда, кроме как нажат один контр или эквивалентный ему (напр шифт)
        If proj.ActiveForm.ctrl = False Then proj.ActiveForm.marker_vis(False)
    End Sub
    Private Sub Peremeschatel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Peremeschatel.KeyPress
        ListView_KeyPress(sender, e)
    End Sub
    Private Sub Peremeschatel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Peremeschatel.KeyUp
        Select Case e.KeyCode
            Case Keys.ControlKey : proj.ActiveForm.ctrl = False : Exit Sub
                '   Case Keys.ShiftKey : proj.ActiveForm.ctrl = False : Exit Sub
        End Select
        IzmenenieBylo()
        proj.ActiveForm.marker_vis(True) ' Сделать маркеры видимыми
    End Sub

#End Region

    ' <<<<<< ПРОЦЕДУРЫ ОБРАБОТКИ СПИСКА СВОЙСТВ >>>>>>>>>
#Region "LISTVIEWS"
    Dim bil As Boolean

    Private Sub ListView1_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ListView.ColumnWidthChanging
        lwEditPropertySet() : bil = True
        ' Узнать соотношение между ширинами колонки шириной списка
        Dim oldOtn As Double = otn
        otn = ListView.Columns("Property").Width / ListView.Width
        If otn <> oldOtn Then ListView1_Resize(Nothing, Nothing)
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.DoubleClick
        lwEditProperty.Focus()
        If lwEditProperty.ActiveTextBox Is Nothing = False Then
            lwEditProperty.ActiveTextBox.SelectionStart = lwEditProperty.ActiveTextBox.TextLength
        End If
    End Sub
    Private Sub ListView1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.GotFocus
        If ListView.SelectedItems.Count > 0 And proj.ActiveForm Is Nothing = False Then
            Dim nowValue As String = proj.ActiveForm.GetPropertys(ListView.SelectedItems(0).Text, proj.ActiveForm.ActiveObj).str
            If ListView.SelectedItems(0).SubItems(1).Text <> nowValue Then
                ' При получении фокуса обновить выделенное свойство
                ListView.SelectedItems(0).SubItems(1).Text = nowValue
            End If
        End If
        ListView1_SelectedIndexChanged(sender, e)
    End Sub
    Public Sub ListView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListView.KeyPress
        If lwEditProperty Is Nothing = False Then
            If lwEditProperty.ActiveTextBox Is Nothing = False Then
                If sender Is ListView = False Then
                    If Char.IsControl(e.KeyChar) = False Then
                        lwEditProperty.ActiveTextBox.Text = e.KeyChar
                        lwEditProperty.ActiveTextBox.SelectionStart = lwEditProperty.ActiveTextBox.TextLength
                    End If
                    ListView1_DoubleClick(sender, New EventArgs) 'lwEditProperty.ActiveTextBox.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub ListView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView.KeyDown
        If e.KeyData = Keys.Enter Then
            ListView1_DoubleClick(sender, New EventArgs)
        ElseIf e.KeyData = Keys.Right Then
            lwEditProperty.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            Peremeschatel.Focus()
        End If
    End Sub

    Private Sub ListView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView.MouseDown
        ' Посчитать на кокое свойство нажали
        If ListView.Items.Count = 0 Or ListView.TopItem Is Nothing Then lwEditProperty.Visible = False : Exit Sub
        Dim Ind As Integer = (e.Y - ListView.TopItem.Position.Y) \ iHeight + ListView.TopItem.Index

        If Ind < ListView.Items.Count And Ind >= 0 Then
            If ListView.SelectedItems.Count > 0 Then
                ' Выделить свойство, на которое нажали
                If Ind = ListView.SelectedIndices(0) Then ListView1_SelectedIndexChanged(sender, New EventArgs)
            End If
            ListView.Items(Ind).Selected = True : ListView.Items(Ind).Focused = True
        End If
    End Sub
    Private Sub ListView1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.Resize
        If ListView.Columns.Count = 2 Then
            lwEditProperty.Visible = False ' Скрыть мой элемент
            ListView.Columns("Property").Width = otn * ListView.Width
            ListView.Columns("Value").Width = ListView.Width - ListView.Columns("Property").Width - 22
            bil = True
        End If
    End Sub
    Private Sub ListView1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.SizeChanged
        If bil = False Then
            bil = True : ListView.Width += 1
        Else
            bil = False
        End If
    End Sub
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.SelectedIndexChanged
        If ListView.SelectedItems.Count > 0 Then
            ListView.Items(ListView.SelectedIndices(0)).Focused = True ' передать фокус выделенному свойству
            If proj.ActiveForm Is Nothing = False Then
                If proj.ActiveForm.ActiveObj Is Nothing = False Then
                    ' Отобразить в моём элементе значение выделенного свойтсва
                    lwEditProperty.ShowProp(ListView.SelectedItems(0).Text, proj.ActiveForm.ActiveObj)
                    InfoPropsShow(ListView.SelectedItems(0).Name, proj.ActiveForm.ActiveObj(0))
                    oldLVselect = ListView.SelectedItems(0).Name
                End If
            End If
        End If
        lwEditPropertySet()
    End Sub
    Sub lwEditPropertySet()
        If lwEditProperty Is Nothing = False Then
            If ListView.SelectedItems.Count > 0 Then
                ' Ностроить размеры моего элемента
                lwEditProperty.TextBox1.Font = ListView.Font
                lwEditProperty.Top = ListView.SelectedItems(0).Position.Y  '- ListView1.TopItem.Position.Y + ListTopItem - 1
                ' Если нажали на элемент, который выше видимого списка
                If ListView.SelectedItems(0).Position.Y < ListView.TopItem.Position.Y Then
                    lwEditProperty.Top = ListView.TopItem.Position.Y
                    ' Если нажали просто на строку
                ElseIf ListView.SelectedItems(0).Position.Y > ListView.Height - ListView.TopItem.Position.Y Then
                    lwEditProperty.Top = ListView.SelectedItems(0).Position.Y - (ListView.Height - ListView.SelectedItems(0).Position.Y - ListView.SelectedItems(0).Bounds.Height - 4)
                    ' Если нажали на строку ниже нижней строки (стрелка вниз на самой нижней строке)
                    If lwEditProperty.Top >= ListView.Height - lwEditProperty.Height - 4 Then
                        Dim newY As Integer = ListView.Items(ListView.SelectedItems(0).Index - 1).Position.Y
                        lwEditProperty.Top = newY ' - 1 '(ListView.Height - newY - ListView.SelectedItems(0).Bounds.Height - 4) 'newY - (ListView.Height - newY) - ListView.SelectedItems(0).Bounds.Height + 4
                    End If
                End If
                lwEditProperty.Left = ListView.Columns(0).Width
                lwEditProperty.Width = ListView.Columns("Value").Width
                lwEditProperty.Height = iHeight + 1
                lwEditProperty.Visible = True
                If lwEditProperty.TextBox2.Text <> "" Then
                    ' сделать чтобы показывалось имя файла, а не "С:\docume..."
                    lwEditProperty.TextBox2.SelectionStart = 0
                    lwEditProperty.TextBox2.SelectionStart = lwEditProperty.TextBox2.Text.Length - 1
                End If
            Else
                ' Если в списке свойств ничего не выделено то скрыть мой элемент
                lwEditProperty.Visible = False
            End If
        End If
    End Sub
    Sub RefreshListViewOneItem(ByVal itm As String, ByVal value As String)
        Dim a As ListViewItem = ListView.Items(itm)
        If a Is Nothing = False Then a.SubItems(1).Text = value
    End Sub
    Sub ReSelectedListViewOneItem()
        If ListView.SelectedIndices.Count > 0 Then
            Dim ii As Integer = ListView.SelectedIndices(0)
            ListView.Items(ii).Selected = False
            ListView.Items(ii).Selected = True
        End If
    End Sub
    Private Sub ListView1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView.MouseWheel
        lwEditProperty.Visible = False
    End Sub

    ' ВЫБОР ЭЛЕМЕНТА ВЕРХНЕГО СПИСКА (СПИСКА ВЫБОРА ОБЪЕКТОВ)
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedItem <> "" And ComboBox2.Tag <> "obrabotka" And proj IsNot Nothing Then
            Dim ob As Object = proj.GetMyObjFromUniqName(proj.ActiveForm.obj.name & "." & Trim(ComboBox2.SelectedItem.ToString.Split("-")(0)))
            If ob Is Nothing Then Exit Sub
            ob.GetMyForm.setActiveObject(ob) : ob.GetMyForm.marker_vis() : TabControl1.SelectedTab = ob.GetMyForm.tab
        End If
    End Sub
#End Region

    ' <<<<<< ПРОЦЕДУРЫ ДЕЙСТВИЙ >>>>>>>>>
#Region "TREE AND TABS"

    ' КОГДА ВЫДЕЛИЛИ КАКУЮ-ТО ВЕТКУ ДЕРЕВА ДЕЙСТВИЙ
    Public Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect
        If Tree.SelectedNode Is Nothing Or Tree.Tag = "nelzya" Then Exit Sub
        If e Is Nothing = False Then
            ' Если у ветки есть свой объект, то ветка нормальная
            If GetMyObjsFromTreeNode(e.Node) Is Nothing = False Then
                If Create1.Text = trans("Создать") Or e.Node.Level < 2 Then
                    ' настроить все закладки таба (Скрыть, появить и т.д.)
                    proj.DeistvRefresh(GetMyObjsFromTreeNode(e.Node))
                End If
                If CreateDs Is Nothing = False Then CreateDs.SetProperty()
            End If
        End If
        ' Сделать кнопки енаблнд фолсе или тру
        TabControl2_SelectedIndexChanged(sender, New EventArgs)
        ' Если выделяют несколько узлов, то выделенным должен быть узел, который выделили первым
        If Tree.SelectedNode.Level = 1 Or Tree.SelectedNode.Level >= 3 Then
            If SelNodes Is Nothing = False Then
                If SelNodes Is Nothing = False Then SelNode = Tree.SelectedNode
                If SelNode.Level = Tree.SelectedNode.Level Then
                    If Array.IndexOf(SelNodes, SelNode) = -1 Then
                        Tree.SelectedNode = SelNodes(0)
                    End If
                End If
            ElseIf SelNode Is Nothing = False Then
                If SelNode.Level = Tree.SelectedNode.Level Then
                    If Tree.SelectedNode Is SelNode = False Then Tree.SelectedNode = SelNode
                End If
            End If
        End If
        If EditNodeText Is Nothing = False And e Is Nothing = False Then
            Dim fl As Boolean
            If e.Node.Tag = "Sobyt" Then fl = True
            If e.Node.Tag = "EndIf" Or e.Node.Tag = "EndWhile" Or e.Node.Tag = "Else" Then fl = True
            If e.Node.Tag = "EmptyCycle" Or e.Node.Tag = "EmptyIf" Then fl = True
            If Tree.SelectedNode Is Nothing Then Exit Sub
            If e.Node.Level < 2 Then
                EditNodeText.Text(False) = Tree.SelectedNode.Text
            Else
                EditNodeText.Text = Tree.SelectedNode.Text
            End If
            If e.Node.Level <= 1 And e.Node.Tag <> "Comm" Then EditNodeText.ActiveTextBox.Multiline = False Else EditNodeText.ActiveTextBox.Multiline = True
            ' Если можно редактировать, тогда сдалать едитНодеТекст енабледом
            If fl = False Then
                EditNodeText.Enabled = True
            Else
                EditNodeText.Enabled = False
            End If
        End If
        If e Is Nothing = False Then RichTextBox3.Text = e.Node.Name
        Create1.Text = trans("Создать")
        Tree.Focus()
    End Sub

    ' ДЕЛАЕТ КНОПКИ ЕНАБЛНД ФЭЛСЕ ИЛИ ТРУ
    Public Sub TabControl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
        Try
            If tab.TabCount = 0 Then
                Create1.Enabled = False : Cancel1.Enabled = False : Apply.Enabled = False
                NodeDel.Enabled = False : NodeDown.Enabled = False : NodeUp.Enabled = False : NodeEdit.Enabled = False
            Else
                Create1.Enabled = True : Cancel1.Enabled = True : Apply.Enabled = True
                NodeDel.Enabled = True : NodeDown.Enabled = True : NodeUp.Enabled = True : NodeEdit.Enabled = True
                ' Отображение справки в InfoPropsLabel
                If TabControl2.SelectedTab Is DeistTab Then
                    InfoPropsShow(CreateDs.ShowObj.propertys.Text, _
                                  proj.GetMyAllFromName(CreateDs.ShowObj.objects.Text, , CreateDs.ShowObj.forms.Text))
                ElseIf TabControl2.SelectedTab Is SobytsTab Then
                    If proj.ActiveForm Is Nothing = False Then
                        If proj.ActiveForm.ActiveObj Is Nothing = False Then
                            InfoPropsShow(ComboBox1.Text, proj.ActiveForm.ActiveObj(0))
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' ЕСЛИ ПО НОДУ КЛИКНУЛИ, НО ОН УЖЕ БЫЛ ВЫДЕЛЕН, ТО ВЫЗВАТЬ ПРЦЕДУРУ ВЫДЕЛЕНИЯ ИСКУСТВЕННО
    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView.NodeMouseClick
        If Tree.SelectedNode Is e.Node And e.Button = Windows.Forms.MouseButtons.Left And e.X >= e.Node.Bounds.Left - 20 Then
            '       TreeView1_AfterSelect(Nothing, New TreeViewEventArgs(e.Node))
        End If
    End Sub

    ' СОЗДАЕТ СОбЫТИЕ
    Public Sub Create1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Create1.Click
        Dim sn As TreeNode = Tree.SelectedNode
        If sn Is Nothing Then Exit Sub
        Dim OldSel As TreeNode = sn.PrevNode
        Dim SelTab As TabPage = tab.SelectedTab
        Dim toAdds() As TreeNode = Nothing
        Dim fromEdit As Boolean
        Dim i As Integer
        Dim newSobyt As String = ComboBox1.SelectedItem
        ' Если Редактируют узел
        If Create1.Text = trans("Изменить") Then
            Dim isTop As Boolean
            ' чтобы tree_AfterSelect все не портил
            Tree.Tag = "nelzya"
            ' Если хотят изменить существующий узел, то удалить его, а потом на его месте создастся новый
            fromEdit = True
            proj.UndoRedo("#Revers Undo", "", "", "")
            For i = 0 To sn.Nodes.Count - 1
                ReDims(toAdds) : toAdds(i) = sn.Nodes(i)
            Next
            Dim nextNode As TreeNode = sn.NextNode
            If sn.Index = 0 Then isTop = True
            If isTop And SelNode.Tag <> "Sobyt" Then SelNode = Tree.SelectedNode.Parent : Tree.SelectedNode = SelNode
            DeleteTree(True, sn)
            Dim mOb As Object = proj.SobytMyObjs
            proj.SobytMyObjs = mOb
            If nextNode Is Nothing = False Then
                If (sn.Tag = "While" And nextNode.Tag = "EndWhile") Then
                    proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                    DeleteTree(True, nextNode)
                ElseIf ((sn.Tag = "If") And (nextNode.Tag = "EndIf" Or nextNode.Tag = "ElseIf")) Then
                    ' ендиф и элсеифы не надо удалять только если меняют текст условия
                    If tab.SelectedTab Is ifTab And nextNode.Tag = "ElseIf" Then
                    Else
                        ' Формирование массива узлов из елсеифоф, для их последующего удаления
                        Dim nn() As TreeNode = {nextNode} : i = 0
                        While nn(i).Tag <> "EndIf"
                            ReDims(nn) : i += 1
                            nn(i) = nn(i - 1).NextNode
                            If nn(i) Is Nothing Then DelDims(nn, nn.Length - 1) : Exit While
                        End While
                        For i = 0 To nn.Length - 1
                            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                            DeleteTree(True, nn(i))
                        Next

                    End If
                End If
            End If
            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            ' Выделить узел, который выше предыдущего, что бы потом новый узел добавился куда надо
            SelNodes = Nothing
            If OldSel Is Nothing = False Then
                Tree.Tag = "nelzya" ' чтобы не сбрасывались на текстовые поля редактора действий
                SelNode = OldSel : Tree.SelectedNode = OldSel
                Tree.Tag = ""
            End If
            Tree.Tag = "mozhno"
        End If
        ' Создание узла
        If SelTab Is SobytsTab Then
            proj.SetSobyts(newSobyt, proj.SobytMyObjs)
        ElseIf SelTab Is DeistTab Then
            proj.SetDeistvs(CreateDs.getText)
        ElseIf SelTab Is ifTab Then
            proj.SetIfs(CreateIfs.getText, CreateIfs.getTypes)
        ElseIf SelTab Is CycleTab Then
            proj.SetCycles(CreateCycles.getText)
        ElseIf SelTab Is CommTab Then
            proj.SetComm(EditPrComm.Text, fromEdit)
        End If
        ' Выделение, созданного узла или измененного
        If SelNode Is Nothing Or Tree.SelectedNode Is Nothing Then Exit Sub
        ' If Tree.SelectedNode.NextVisibleNode Is Nothing = False And SelNode.Tag <> "Comm" Then ' And OldSel.Index <> 0 Then
        ' SelNode = Tree.SelectedNode.NextVisibleNode : Tree.SelectedNode = SelNode
        '     End If
        ' Добавить внутрь ветки действия, если таковые есть (проходило редактирование ветки с действиями)
        If toAdds Is Nothing = False And Tree.SelectedNode.PrevVisibleNode Is Nothing = False Then
            Dim tip As String = Tree.SelectedNode.PrevVisibleNode.Tag
            If tip = "While" Or tip = "If" Or tip = "ElseIf" Or tip = "Else" Then
                Tree.SelectedNode.PrevVisibleNode.Nodes.AddRange(toAdds)
                Tree.SelectedNode.PrevVisibleNode.Nodes(0).Remove()
                proj.UndoRedoTree(True, True, toAdds)
            ElseIf Tree.SelectedNode.Tag = "Sobyt" Then
                Tree.SelectedNode.Nodes.AddRange(toAdds)
                proj.UndoRedoTree(True, True, toAdds)
            End If
        End If
        Create1.Text = trans("Создать")
    End Sub

    ' НЕ ПОЗВОЛЯЕТ ДАЛЕКО РАЗДЕЛЯТЬ КОНСТРУКТОР ДЕЙСТВИЙ
    Private Sub SplitContainer6_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitCreate.Resize
        'If SplitCreate.Height - 30 > 0 Then
        '    SplitCreate.SplitterDistance = SplitCreate.Height - 30
        'End If
    End Sub

    ' ВЫДЕЛЯЕТ ЦИКЛ/УСЛОВИЕ ЦЕЛИКОМ, ВКЛЮЧАЙ КОНЕЦ УСЛОВИЯ/ЦИКЛА
    Sub SelectIfCycles(ByVal sel As Boolean)
        Dim begs() As String = {"If|ElseIf|Else", "While"}
        Dim ends() As String = {"EndIf|ElseIf|Else", "EndWhile"}
        Dim tempNode As TreeNode = SelNode
        Dim i As Integer
        If SelNodes Is Nothing Then ReDim SelNodes(0) : SelNodes(0) = SelNode
        If SelNodes(0) Is Nothing Then Exit Sub
        For i = 0 To begs.Length - 1
            If Array.IndexOf(begs(i).Split("|"), SelNode.Tag) = 0 Then
                While SelNode.NextNode Is Nothing = False
                    SelNode = SelNode.NextNode
                    ' Если попался эндиф(элдвайл) и он еще невыделен/выделен
                    If Array.IndexOf(ends(i).Split("|"), SelNode.Tag) <> -1 Then
                        If SelNodes Is Nothing Then Exit Sub
                        If (sel = True And Array.IndexOf(SelNodes, SelNode) = -1) Or (sel = False And Array.IndexOf(SelNodes, SelNode) <> -1) Then
                            SelectOneMenu_Click(Nothing, Nothing)
                            If SelNode Is Nothing Then SelNode = SelNodes(0) : Exit While
                            If SelNode.Tag = ends(i).Split("|")(0) Then SelNode = tempNode : Exit Sub
                        End If
                    End If
                End While
            End If
        Next
        For i = 0 To ends.Length - 1
            If ends(i).Split("|")(0) = SelNode.Tag Then
                While SelNode.PrevNode Is Nothing = False
                    SelNode = SelNode.PrevNode
                    ' Если попался иф(вайл) и он еще невыделен/выделен
                    If Array.IndexOf(begs(i).Split("|"), SelNode.Tag) <> -1 Then
                        If SelNodes Is Nothing Then Exit Sub
                        If (sel = True And Array.IndexOf(SelNodes, SelNode) = -1) Or (sel = False And Array.IndexOf(SelNodes, SelNode) <> -1) Then
                            SelectOneMenu_Click(Nothing, Nothing)
                            If SelNode Is Nothing Then SelNode = SelNodes(0) : Exit While
                            If SelNode.Tag = begs(i).Split("|")(0) Then SelNode = tempNode : Exit Sub
                        End If
                    End If
                End While
            End If
        Next
        If SelNodes.Length = 1 Then SelNodes = Nothing : TreePaint(Tree.BackColor)
    End Sub
    Sub DelFromArray(ByRef arr() As TreeNode, ByVal ind As Integer)
        Dim i As Integer
        If arr.Length < 2 Then arr = Nothing : Exit Sub
        For i = ind To arr.Length - 2
            arr(i) = arr(i + 1)
        Next
        ReDim Preserve arr(arr.Length - 2)
    End Sub
    Sub SelectObj()
        Dim i, j, k As Integer, myObjs, ActObj As Object
        If SelNode Is Nothing Then SelNode = Tree.SelectedNode
        If SelNode Is Nothing Then Exit Sub
        If SelNode.Tag = "Comm" Then Exit Sub
        ' If SelNode.Level = 0 Then SelNode = SelNode.Nodes(SelNode.Name)
        If SelNode Is Nothing Then Exit Sub
        If SelNode.Level = 1 Then
            Dim frm() As Object = proj.GetMyFormsFromName(SelNode.FullPath.Split("\")(0))
            frm(0).SelectTab()
            For i = 0 To frm.Length - 1
                ActObj = frm(i).ActiveObj
                frm(i).clearActiveObject()
                If SelNodes Is Nothing = False Then
                    While j < SelNodes.Length
                        If SelNodes(j) Is Nothing = False Then
                            myObjs = proj.GetMyAllFromName(SelNodes(j).Text, , frm(i).obj.Props.name)
                        Else
                            myObjs = Nothing
                        End If
                        If myObjs Is Nothing Then
                            DelFromArray(SelNodes, j)
                            If SelNodes Is Nothing Then
                                Exit For
                            Else
                                j += 1 : Continue While
                            End If
                        End If
                        For k = 0 To myObjs.Length - 1
                            frm(i).AddActiveObject(myObjs(k), True)
                        Next
                        j += 1
                    End While
                Else
                    myObjs = proj.GetMyAllFromName(SelNode.Text)
                    If myObjs Is Nothing Then Exit Sub
                    For k = 0 To myObjs.Length - 1
                        frm(i).AddActiveObject(myObjs(k), True)
                    Next
                End If
            Next
            If myObjs Is Nothing = False And ActObj Is Nothing = False Then
                If ActObj(0) Is Nothing = False Then
                    If ActObj(0).obj.Props.name <> myObjs(0).obj.Props.name Then proj.ActiveForm.marker_vis()
                    proj.ActiveForm.FillListView()
                End If
            End If
        End If
    End Sub
    ' НЕ ПОЗВОЛИТЬ ВЫДЕЛЯТЬ СОБЫТИЯ, ИЛИ, НАПРИМЕР, ОДНОВРЕМЕННО ДЕЙСТВИЯ И ОБЪЕКТЫ
    Function maySelect() As Boolean
        If SelNode Is Nothing = False Then
            Dim temp As TreeNode
            If SelNodes Is Nothing = False Then
                temp = SelNodes(0)
                If SelNodes(0) Is Nothing Then Return False
            Else
                temp = Tree.SelectedNode
            End If
            If temp.Tag = "Comm" Or SelNode.Tag = "Comm" Then
                If temp.Tag <> "Comm" Or SelNode.Tag <> "Comm" Then Return False
            ElseIf temp.Level >= 3 Then
                If SelNode.Level < 3 Then Return False
            ElseIf temp.Level = 1 Or temp.Level = 2 Then
                If SelNode.Level <> temp.Level Then Return False
            Else
                Return False
            End If
        End If
        Return True
    End Function
    ' РАЗУКРАШИВАНИЕ ВЫДЕЛЕНЫХ УЗЛОВ
    Public Sub TreePaint(ByVal col As Color, Optional ByVal clrDebNod As Boolean = False)
        ' Прорисовка контрольных точек
        If Breaks Is Nothing = False Then
            Dim i As Integer
            For i = 0 To Breaks.Length - 1
                If i > Breaks.Length - 1 Then Exit For
                If Breaks(i) Is Nothing = False Then
                    Graphics.FromHwnd(Tree.Handle).DrawRectangle(New Pen(ColBreakpoint, 3), Breaks(i).Bounds)
                    If Breaks(i).TreeView Is Nothing Then DelDims(Breaks, i)
                Else
                    DelDims(Breaks, i)
                End If
            Next
        End If
        ' Прорисовка узла, который сейчас выполняется
        If debugNode Is Nothing = False And RunProj Is Nothing = False Then
            If RunProj.isRUN = False And clrDebNod = False Then
                Graphics.FromHwnd(Tree.Handle).DrawRectangle(New Pen(ColDebugNode, 2), debugNode.Bounds.X + 1, debugNode.Bounds.Y + 1, debugNode.Bounds.Width - 1, debugNode.Bounds.Height - 1)
            Else
                Graphics.FromHwnd(Tree.Handle).DrawRectangle(New Pen(Tree.BackColor, 2), debugNode.Bounds.X + 1, debugNode.Bounds.Y + 1, debugNode.Bounds.Width - 1, debugNode.Bounds.Height - 1)
            End If
        End If
        ' прорисовка выделенных узлов
        If SelNodes Is Nothing = False Then
            Dim i As Integer
            For i = 0 To SelNodes.Length - 1
                If SelNodes(i) Is Nothing = False Then
                    Graphics.FromHwnd(Tree.Handle).DrawRectangle(New Pen(col, 1), SelNodes(i).Bounds)
                End If
            Next
        End If
    End Sub
    Dim xx, yy As Integer
    Private Sub TreeView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView.MouseDown
        SelNode = Tree.HitTest(e.Location).Node
        SelType = Tree.HitTest(e.Location).Location
        If SelNode Is Nothing Then MouseD = False : Exit Sub
        If SelNode.Bounds.Left - 20 > e.X Or SelNode.Bounds.Right < e.X Then
            SelNode = Tree.SelectedNode : MouseD = False : Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Right And MouseD = True Then MouseD = False : MouseM = False : Exit Sub
        ' Если кликнули на рисунок узла или на его текст
        ' If proj.GetMyFormsFromName(SelNode.Name) Is Nothing = False And SelNode.Level = 0 Then Exit Sub
        If SelType = TreeViewHitTestLocations.Image Or SelType = TreeViewHitTestLocations.Label Then
            'MouseD = True
            xx = e.X : yy = e.Y
        End If


        Dim i, j As Integer
        ' ВЫДЕЛЕНИЕ УЗЛОВ

        ' Если хотят выделить несколько элементов
        If Control.ModifierKeys = Keys.Shift Or e.Delta = 13 Then
            ' Не позволить выделять события или например одновременно действи и объекты
            If maySelect() = False Then Exit Sub
            ' Если кликнули на рисунок узла или на его текст
            If SelType = TreeViewHitTestLocations.Image Or SelType = TreeViewHitTestLocations.Label Then
                ' Увеличить размерность селнодс на 1
                If SelNodes Is Nothing Then
                    If Tree.SelectedNode Is SelNode Then Exit Sub
                    ReDim SelNodes(1) : SelNodes(0) = Tree.SelectedNode
                Else
                    ReDim Preserve SelNodes(SelNodes.Length)
                End If
                ' Исключить узел из массива выделеных если на него кликнули повторно
                For i = 0 To SelNodes.Length - 1
                    If SelNodes(i) Is SelNode Then
                        TreePaint(Tree.BackColor)
                        If SelNodes.Length <= 3 Then
                            ' Чтобы единств. выделенным остался тот, по которому так и не кликнули
                            If SelNodes(0) Is SelNode Then
                                SelNode = SelNodes(1)
                            Else
                                SelNode = SelNodes(0)
                            End If
                            SelNodes = Nothing
                            Exit For
                        Else
                            DelFromArray(SelNodes, i) : j = 1
                            ReDim Preserve SelNodes(SelNodes.Length - 2)
                            SelectIfCycles(False)
                            Exit For
                        End If
                    End If
                Next
                ' Рас этот узел впервые кликнут то добавить его в массив и разукрасить
                If SelNodes Is Nothing = False And j = 0 Then
                    If SelNodes(SelNodes.Length - 1) Is Nothing Then
                        SelNodes(SelNodes.Length - 1) = SelNode
                        If e.Delta <> 13 Then SelectIfCycles(True)
                    End If
                End If
                TreeView1_MouseMove(sender, e)
            End If
        Else
            Dim fl As Boolean = 0
            If SelNodes Is Nothing = False Then
                If Array.IndexOf(SelNodes, SelNode) <> -1 Then fl = 1
            End If
            If fl = 0 Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    ' Если просто хотят выделить один объект
                    TreePaint(Tree.BackColor)
                    SelNodes = Nothing
                    SelectIfCycles(True)
                Else
                    SelNode = Tree.HitTest(e.Location).Node
                    SelectIfCycles(True)
                    Tree.Tag = "nelzya"
                    Tree.SelectedNode = SelNode
                    Tree.Tag = ""
                End If
            End If
        End If
        SelectObj()

        MouseD = True
    End Sub
    Private Sub TreeView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView.MouseMove
        TreePaint(ColKode)
        If Tree.SelectedNode Is Nothing Then Exit Sub
        'If Tree.SelectedNode.Tag = "Comm" Then SelNode = Tree.SelectedNode
        If SelNode Is Nothing Then Exit Sub
        If e Is Nothing Then Exit Sub
        If MouseD = True Then
            If e.X = xx And e.Y = yy Then Exit Sub
            Dim dropNode As TreeNode = Tree.HitTest(e.Location).Node
            If dropNode Is Nothing Then Exit Sub
            If MouseM = False Then
                If dropNode Is SelNode = False Then Exit Sub Else MouseM = True
            End If
            ' Если можно перемещать
            If MayPod4erk(SelNode, dropNode, False) Then
                ' то нарисовать подчеркивание
                Tree.Cursor = Cursors.SizeAll : Tree.SelectedNode = SelNode
                pod4erk(dropNode) : MouseM = True
            End If
        Else
            Tree.Cursor = Cursors.Default
        End If
    End Sub
    Function MayPod4erk(ByVal SelNode As TreeNode, ByVal dropNode As TreeNode, ByVal withMsg As Boolean) As Boolean
        Dim fl As Boolean = True
        If SelNode.Tag = "Comm" Then Return True
        If SelNode.Level = 0 Or dropNode.Level = 0 Then
            fl = False
        ElseIf (SelNode.Level = 2 Or SelNode.Level = 1) And (dropNode.Level > SelNode.Level Or dropNode.Level < SelNode.Level - 1) Then
            fl = False
        ElseIf proj.GetMyFormsFromName(SelNode.Name) Is Nothing = False Then
            fl = False
        ElseIf SelNode.Level >= 3 And dropNode.Level < 2 Then
            fl = False
        ElseIf SelNode.Name = dropNode.Name Then
            fl = False
            If SelNode.TreeView Is Nothing Then Return fl
            ' у объектов главное чтоб полный путь не совпадал
            If SelNode.Level = 1 And SelNode.FullPath <> dropNode.FullPath Then fl = True
            ' Если такое событие уже есть
            If SelNode.Tag = "Sobyt" And SelNode.FullPath <> dropNode.FullPath Then
                ' Спросить можно ли заменить его
                If withMsg Then
                    If MsgBox(transInfc("Событие") & " """ & SelNode.Name & """ " & transInfc("уже существует, замените его?"), MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        fl = True
                    End If
                Else
                    fl = True
                End If
            End If
        End If
        Return fl
    End Function
    Sub pod4erk(ByVal node As TreeNode)
        Static x1, x2, y As Integer
        Pod4erkNode = node
        ' стереть старую полосу
        If node Is Nothing Then
            Graphics.FromHwnd(Tree.Handle).DrawLine(New Pen(Tree.BackColor, 2), x1, y, x2, y)
            x1 = 0 : x2 = 0 : y = 0 : Exit Sub
        End If
        If y <> node.Bounds.Y + node.Bounds.Height - 1 Then
            Graphics.FromHwnd(Tree.Handle).DrawLine(New Pen(Tree.BackColor, 2), x1, y, x2, y)
            y = node.Bounds.Y + node.Bounds.Height - 1
            x1 = node.Bounds.X
            x2 = node.Bounds.X + node.Bounds.Width
        End If
        ' нарисовать полосу
        Graphics.FromHwnd(Tree.Handle).DrawLine(New Pen(Color.Black, 2), x1, y, x2, y)
    End Sub
    Private Sub TreeView_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView.MouseLeave
        MouseD = False : MouseM = False
    End Sub
    ' ПЕРЕМЕЩЕНИЕ УЗЛОВ ВНУТРИ ВЕТКИ
    Sub MoveNode(ByVal dropNode As Object, ByVal perenos As Boolean, ByVal ParamArray SNodes() As TreeNode)
        Dim PerenosTree As String
        If SNodes Is Nothing Then SNodes = getSelNods()
        PerenosTree = GetCopyTree(SNodes)
        ' ВСТВИТЬ(УЗЛЫ)
        Dim node() As TreeNode = PasteTree(dropNode, PerenosTree, True, True)
        ' УДАЛИТЬ скопированные узлы, если хотят перемещать а нe копировать
        If perenos = True Then
            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            DeleteTree(True, SNodes)
        End If
        If node Is Nothing = False Then
            SelNodes = node : TreeView1_AfterSelect(Nothing, Nothing)
            If SelNodes.Length > 1 Then
                TreePaint(ColKode)
            Else
                TreePaint(Tree.BackColor) : SelNode = node(0) : SelNodes = Nothing
            End If
        End If

        ' Dim i As Integer, tempSelNodes() As TreeNode
        ' If SelNodes Is Nothing Then Exit Sub
        ' For i = SelNodes.Length - 1 To 0 Step -1
        ' SelNodes(i).Remove()
        ' dropNode.Parent.Nodes.Insert(dropNode.Index + SelNodes.Length - i, SelNodes(i))
        ' ReDims(tempSelNodes) : tempSelNodes(tempSelNodes.Length - 1) = dropNode.Parent.Nodes(dropNode.Index + SelNodes.Length - i)
        ' Next
        ' SelNodes = tempSelNodes
        'Tree.SelectedNode = SelNodes(0)
    End Sub
    Private Sub TreeView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView.MouseUp
        Dim fl As Boolean, i, j As Integer
        Dim ModifKeys As Windows.Forms.Keys = Control.ModifierKeys
        ' Если функцию вызывает меню, появляющаяся после перемещения узла ПРАВОЙ кнопкой мыши
        If sender Is CopyMenu3 Then ModifKeys = Keys.Control
        If sender Is MoveMenu3 Then ModifKeys = Nothing
        If SelNode Is Nothing Then MouseD = False : MouseM = False : Exit Sub

        ' КОПИРОВАНИЕ И ПЕРЕМЕЩЕНИЕ УЗЛОВ
        ' Если перемещали Drag&Drop
        If MouseM = True Then
            proj.UndoRedo("#Revers Undo", "", "", "")
            If e.Button = Windows.Forms.MouseButtons.Right Then
                TreeMiniMenu.Tag = e.Location : TreeMiniMenu.Show(Tree, e.Location) : Exit Sub
            End If
            Dim dropNode As TreeNode '= Tree.HitTest(e.Location).Node
            '            If dropNode Is Nothing Then
            dropNode = Pod4erkNode
            If dropNode Is Nothing Then MouseD = False : MouseM = False : Exit Sub
            Tree.Cursor = Cursors.Default : pod4erk(Nothing)
            ' ЕСЛИ МОЖНО ПЕРЕМЕЩАТЬ
            fl = MayPod4erk(SelNode, dropNode, True)
            ' События нельзя перетаскивать внутри одного объекта
            '           If SelNode.Tag <> "Comm" Then
            If SelNode.Tag = "Sobyt" Then
                If SelNode.FullPath.Split("\")(1) = dropNode.FullPath.Split("\")(1) Then fl = False
            End If
            'End If
            ' ветки нельзя перетаскивать сами на себя
            If SelNode Is dropNode Then fl = False
            If SelNodes Is Nothing = False Then
                If Array.IndexOf(SelNodes, dropNode) <> -1 Then fl = False
            End If
            ' РАС МОЖНО ПЕРЕМЕЩАТЬ И КОПИРОВАТЬ

            If fl = True And (SelNode.Level > 1 Or SelNode.Tag = "Comm") Then
                Dim PerenosTree As String = GetCopyTree(getSelNods)
                ' ВСТВИТЬ(УЗЛЫ)
                Dim node() As TreeNode = PasteTree(dropNode, PerenosTree, True)
                ' удалить скопированные узлы, если хотят перемещать а нe копировать
                If ModifKeys <> Keys.Control And ModifKeys <> Keys.Shift And node Is Nothing = False Then
                    proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                    DelMenu_Click(Nothing, Nothing)
                End If
                If node Is Nothing = False Then
                    SelNodes = node : TreeView1_AfterSelect(Nothing, Nothing)
                    If SelNodes.Length > 1 Then TreePaint(ColKode) Else TreePaint(Tree.BackColor) : SelNodes = Nothing : SelNode = node(0) : Tree.SelectedNode = SelNode
                End If
            ElseIf fl = True And SelNode.Level = 1 And dropNode.Level = 1 Then
                ' Если хотят копировать/переместить узел из разных веток(пути до узла копируемого и то куда копирую не совпадают)
                If ModifKeys = Keys.Control Or sender Is CopyMenu3 Or SelNode.FullPath.Substring(0, SelNode.FullPath.LastIndexOf("\") + 1) <> dropNode.FullPath.Substring(0, dropNode.FullPath.LastIndexOf("\") + 1) Then
                    If SelNodes Is Nothing Then
                        ' Занесение в один масив всех элиментов, которые выделены, включая ВЛОЖЕННЫЕ В НИХ
                        Dim allSelNodeObjs() = proj.GetDo4ernieMyObjs(GetMyObjsFromTreeNode(SelNode))
                        If allSelNodeObjs Is Nothing Then Exit Sub
                        For j = 0 To allSelNodeObjs.Length - 1
                            If allSelNodeObjs(j).obj.GetType.ToString = ClassAplication & "F" Then
                                DelDims(allSelNodeObjs, j) : Exit For
                            End If
                        Next
                        PasteObj(CopyObjFun(allSelNodeObjs), GetMyObjsFromTreeNode(dropNode))
                        If sender Is CopyMenu3 = False Then
                            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                            DeleteObj(allSelNodeObjs)
                        End If
                    Else
                        Dim toSel() As TreeNode
                        For i = 0 To SelNodes.Length - 1
                            ' Занесение в один масив всех элиментов, которые выделены, включая ВЛОЖЕННЫЕ В НИХ
                            Dim allSelNodeObjs() = proj.GetDo4ernieMyObjs(GetMyObjsFromTreeNode(SelNodes(i)))
                            If allSelNodeObjs Is Nothing Then Exit Sub
                            ' Если форма попадет в список перетаскиваемых, то её надо удалить от туда
                            For j = 0 To allSelNodeObjs.Length - 1
                                If allSelNodeObjs(j).obj.GetType.ToString = ClassAplication & "F" Then
                                    DelDims(allSelNodeObjs, j) : Exit For
                                End If
                            Next
                            If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                            Dim objs = PasteObj(CopyObjFun(allSelNodeObjs), GetMyObjsFromTreeNode(dropNode))
                            ReDims(toSel) : toSel(toSel.Length - 1) = objs(0).GetNode
                            If sender Is CopyMenu3 = False Then
                                proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                                DeleteObj(allSelNodeObjs)
                            End If
                        Next
                        SelNodes = toSel
                    End If

                Else ' Если хотят переместить узел внутри ветки
                    If SelNodes Is Nothing Then
                        MoveNode(dropNode, True, SelNode)
                    Else
                        MoveNode(dropNode, True, SelNodes)
                    End If
                End If
                ReSortMyObjs(dropNode)
                SelNode = dropNode : Tree.SelectedNode = SelNode
            End If
        Else
            fl = False
        End If




        If Control.ModifierKeys = Keys.Shift Or Control.ModifierKeys = Keys.Control Or TreeMenu.Visible Then
        Else
            If MouseD = True And MouseM = False Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    ' Если просто хотят выделить один объект
                    TreePaint(Tree.BackColor)
                    SelNodes = Nothing
                    SelectIfCycles(True)
                Else
                    SelNodes = Nothing
                    SelNode = Tree.HitTest(e.Location).Node
                    Tree.Tag = "nelzya"
                    Tree.SelectedNode = SelNode
                    Tree.Tag = ""
                End If
            End If
        End If

        MouseD = False : MouseM = False

        If SelNode Is Nothing Or Tree.SelectedNode Is Nothing Then Exit Sub
        ' Если до этого не перетаскивали узлы и нажали на выделенный узел повторно, то дать возможность переименовать объект
        'If fl = False And Tree.SelectedNode.Name = SelNode.Name And Rnd(1) < 0.5 Then
        ' If Tree.SelectedNode.Level = 1 And e.Button <> Windows.Forms.MouseButtons.Right Then Tree.SelectedNode.BeginEdit()
        ' End If
        Tree.Focus()
    End Sub
    Private Sub TreeView1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView.MouseWheel
        TreeView1_MouseMove(Nothing, Nothing)
    End Sub

    ' РЕДАКТИРОВАНИЕ ДЕЙСТВИЯ
    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView.DoubleClick
        If SelNode.Nodes.Count = 0 Then EditNodeMenu_Click(Nothing, Nothing)
    End Sub
    Private Sub EditNodeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditNodeMenu.Click
        If Tree.SelectedNode Is Nothing = False Then
            ' Редактирование дейстия
            If Tree.SelectedNode.Tag = "Deist" Then
                Dim cs As New CodeString(Tree.SelectedNode.Text, , False)
                Dim ind As Integer = cs.IndexOf("=", , True)
                If ind = -1 Then ind = Tree.SelectedNode.Text.Length
                ' до знака "=" в cs хранится объект, которому присваивается
                If CreateDs.ShowObj Is Nothing Then Exit Sub
                CreateDs.ShowObj.SetObj(cs.Text.Substring(0, ind), False)
                ' после знака "=" в cs хранится значение, которое присваивается
                If CreateDs.args.Args Is Nothing = False Then
                    If ind + 2 < cs.Text.Length - 1 Then
                        CreateDs.args.Args(0).Text = cs.Text.Substring(ind + 2)
                    Else
                        CreateDs.args.Args(0).Text = ""
                    End If
                End If
                ind = Tree.SelectedNode.Text.Length
                tab.SelectedTab = DeistTab
                ' Редактирование события
            ElseIf Tree.SelectedNode.Tag = "Sobyt" Then
                If tab.TabPages(SobytsTab.Name) Is Nothing Then Exit Sub
                tab.SelectedTab = SobytsTab
                ComboBox1.Items.Clear()
                ComboBox1.Items.AddRange(GetMyObjsFromTreeNode(Tree.SelectedNode.Parent)(0).Sobyts)
                ComboBox1.SelectedItem = Tree.SelectedNode.Text
                ' Редактирование цикла
            ElseIf Tree.SelectedNode.Tag = "While" Then
                CreateCycles.Text = Tree.SelectedNode.Text
                tab.SelectedTab = CycleTab
            ElseIf Tree.SelectedNode.Tag = "If" Then
                CreateIfs.Shown(True, False, False, Tree.SelectedNode.Tag)
                CreateIfs.Text(Tree.SelectedNode.Tag) = Tree.SelectedNode.Text
                tab.SelectedTab = ifTab
            ElseIf Tree.SelectedNode.Tag = "ElseIf" Then
                Dim elseVis As Boolean
                If proj.GetElseOrElseIf(Tree.SelectedNode, "Else") Is Nothing Then elseVis = True
                CreateIfs.Shown(False, True, elseVis, Tree.SelectedNode.Tag)
                CreateIfs.Text(Tree.SelectedNode.Tag) = Tree.SelectedNode.Text
                tab.SelectedTab = ifTab
            ElseIf Tree.SelectedNode.Tag = "Else" Then
                CreateIfs.Shown(False, True, False, Tree.SelectedNode.Tag)
                tab.SelectedTab = ifTab
            ElseIf Tree.SelectedNode.Tag = "Comm" Then
                EditPrComm.Text = Tree.SelectedNode.Text
                tab.SelectedTab = CommTab
            Else
                Exit Sub
            End If
            Create1.Text = trans("Изменить")
        End If
    End Sub

    Private Sub TabControl2_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl2.Selecting
        If TabControl2.SelectedTab Is SobytsTab Then
            If e.TabPage Is SobytsTab = False Then Create1.Text = trans("Создать")
        End If
    End Sub

    Private Sub Cancel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel1.Click
        Create1.Text = trans("Создать")
    End Sub

    Private Sub TreeView_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles TreeView.Invalidated
        TreePaint(ColKode)
    End Sub
#End Region

    ' <<<<<<<< МЕНЮ OBJS >>>>>>>>>
#Region "CONTEXT MENU OBJS"

    Private Sub ObjsMenu_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles ObjsMenu.Closed
        If proj.ActiveForm.ActiveObj Is Nothing = False Then
            If proj.ActiveForm.ActiveObj.Length > 0 Then
                If Iz.IsMMs(proj.ActiveForm.ActiveObj(0)) Then proj.ActiveForm.marker_vis()
            End If
        End If
    End Sub

    ' СРАБАТЫВАЕТ ПРИ РАСКРЫТИИ КОНТЕКСТНОГО МЕНЮ
    Public Sub ObjsMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ObjsMenu.Opening
        Dim cmItem, temp, cmMassiv As ToolStripMenuItem, cmSeparat As ToolStripSeparator
        Dim i As Integer, sorce As Object
        ObjsMenu.Visible = False
        If mozhnoObjEdit() = False Then ObjsMenu.Enabled = False Else ObjsMenu.Enabled = True

        sorce = ObjsMenu.SourceControl
        If sorce Is Nothing Then Exit Sub
        If sorce.name = "Markers" Then sorce = sorce.tag.obj
        ObjsMenu.Tag = sorce

        ' МЕНЮ ПЕРЕМЕСТИТЬ
        cmItem = MoveMenu
        ' Если контекстное меню принадлежит полуобъекту
        If sorce.TypeObj = "PoluObj" Then
            cmItem.Visible = False
        Else
            ' Если есть выделенные объекты
            If proj.ActiveForm.ActiveObj Is Nothing = False Then
                cmItem.DropDownItems.Clear()
                ' Добавить в контекстное меню ПЕРЕМЕСТИТЬ все панели и форму
                For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                    If Iz.isPanel(proj.ActiveForm.MyObjs(i).obj) Then
                        If proj.ExistName(proj.ActiveForm.MyObjs(i).obj.Props.name, proj.ActiveForm.MyObjs(i).obj) Then
                            temp = New ToolStripMenuItem(proj.ActiveForm.MyObjs(i).obj.Props.name.ToString & " (" & proj.ActiveForm.MyObjs(i).obj.Props.index.ToString & ")")
                        Else
                            temp = New ToolStripMenuItem(proj.ActiveForm.MyObjs(i).obj.Props.name.ToString)
                        End If
                        If proj.ActiveForm.MyObjs(i).obj Is sorce = False Then cmItem.DropDownItems.Add(temp)
                        ' Если объект и так находится на форме то отметить его галкой
                        If proj.ActiveForm.MyObjs(i).obj Is sorce.Parent Then temp.Checked = True
                        AddHandler temp.Click, AddressOf MoveMenu_Click
                    End If
                Next
            End If
            ' Если панелей меньше одной, то скрыть меню ПЕРЕМЕСТИТЬ
            If cmItem.DropDownItems.Count > 1 Then
                cmItem.Visible = True : ObjsMenu.Visible = True ' : cmSeparat.Visible = True
            Else
                cmItem.Visible = False
            End If
        End If

        ' меню МАССИВ
        cmSeparat = MassiveUp : cmSeparat.Visible = False

        cmItem = CreateArrayMenu : cmItem.Visible = False
        ' Если есть выделенные объекты
        If proj.ActiveForm.ActiveObj Is Nothing = False Then
            ' Если выделенных объектов больше одного, то показать пункт
            If proj.ActiveForm.ActiveObj.Length > 1 Then
                cmItem.Visible = True : ObjsMenu.Visible = True : cmSeparat.Visible = True
            End If
        End If

        cmItem = CreateSubArrayMenu : cmItem.Visible = False
        ' Если есть выделенные объекты
        If proj.ActiveForm.ActiveObj Is Nothing = False Then
            For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
                If proj.ExistName(proj.ActiveForm.ActiveObj(i).obj.Props.name, proj.ActiveForm.ActiveObj(i).obj) Then
                    cmItem.Visible = True : ObjsMenu.Visible = True : cmSeparat.Visible = True : Exit For
                End If
            Next
        End If


        Dim mass() As String = proj.ActiveForm.GetAllMassives() ' Получить имена всех массивов формы
        cmMassiv = ArrayWorkMenu : cmMassiv.Visible = False
        ' Если есть массивы
        If mass Is Nothing = False Then
            cmMassiv.Visible = True : ObjsMenu.Visible = True : cmSeparat.Visible = True

            cmItem = UniteInSubArrayMenu : cmItem.Visible = False
            ' Если есть выделенные объекты
            If proj.ActiveForm.ActiveObj Is Nothing = False Then
                ' Если выделенных объектов больше одного
                If proj.ActiveForm.ActiveObj.Length > 1 Then
                    For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
                        If proj.ExistName(proj.ActiveForm.ActiveObj(i).obj.Props.name, proj.ActiveForm.ActiveObj(i).obj) Then
                            ' Только массивы второй степени и выше
                            If proj.ActiveForm.ActiveObj(i).obj.Props.index.split(",").length > 1 Then
                                cmItem.Visible = True : Exit For
                            End If
                        End If
                    Next
                End If
            End If

            cmItem = SelectArrayMenu : cmItem.Visible = False
            ' Если существует еще такоеже имя помимо имени этого объекта
            If proj.ExistName(sorce.Name, sorce) Then cmItem.Visible = True

            cmItem = SelectSubArrayMenu : cmItem.Visible = False
            ' Если существует еще такоеже имя помимо имени этого объекта, и это подмасив а не масив
            If proj.ExistName(sorce.Name, sorce) And ObjsMenu.Tag.Props.index.indexOf(",") <> -1 Then cmItem.Visible = True

            cmItem = AddToArrayMenu
            cmItem.Visible = False : cmItem.DropDownItems.Clear()
            ' Добавить в контекстное меню "добавить масив" все масивы
            For i = 0 To mass.Length - 1
                temp = New ToolStripMenuItem(mass(i))
                ' не добавлять имя родного массива
                If mass(i) <> sorce.Name Then cmItem.DropDownItems.Add(temp)
                AddHandler temp.Click, AddressOf MoveMassive_Click
            Next
            If cmItem.DropDownItems.Count > 0 Then cmItem.Visible = True

            cmItem = ExcludeFromArrayMenu : cmItem.Visible = False
            ' Если существует еще такоеже имя помимо имени этого объекта
            If proj.ExistName(sorce.Name, sorce) Then cmItem.Visible = True

        End If

        ' Меню ДОБАВИТЬ ВЛОЖЕННЫЙ ОБЪЕКТ
        cmItem = AddMenu : cmSeparat = AddUp
        If Iz.isHavePlusik(sorce) Then
            cmItem.Text = trans("Добавить") & " " & sorce.defaultName
            cmSeparat.Visible = True : cmItem.Visible = True
        Else
            cmSeparat.Visible = False : cmItem.Visible = False
        End If

        ' Меню УРОВНИ и ПЕРЕНЕСТИ
        cmItem = PlanMenu : cmSeparat = EditUp
        If sorce.GetType.ToString = ClassAplication & "MMs" Then
            cmSeparat.Visible = False : cmItem.Visible = False : MoveMenu.Visible = False
        Else
            cmSeparat.Visible = True : cmItem.Visible = True : MoveMenu.Visible = True
        End If
    End Sub

    ' МЕНЮ ПЕРЕМЕСТИТЬ. ПЕРЕМЕСТИТЬ НА ДРУГУЮ ПАНЕЛЬ ОБЪЕКТ CM.TAG
    Private Sub MoveMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Перемещать на панель, с именем, как текст у пункта меню
        Dim cont() As Object = proj.ActiveForm.GetMyObjsFromName(sender.text)
        Dim MyObjs() As Object = proj.ActiveForm.ActiveObj
        ' Если контенер не определился по имени, наверное он входит в массив и рядом с его именем индекс
        If cont Is Nothing Then
            Dim len As Integer = sender.text.lastindexof(" ")
            Dim skobka As Integer = sender.text.lastindexof(")")
            If len = -1 Or skobka = -1 Or sender.text.length < len + 3 Then Exit Sub
            ' Попробывать определить, куда перемещать, учитывая индекс
            cont = proj.ActiveForm.GetMyObjsFromName(sender.text.substring(0, len), sender.text.substring(len + 2, skobka - (len + 2)))
        End If
        MoveObj(cont(0), MyObjs)
    End Sub

    ' ПЕРЕМЕСТИТЬ ОБЪЕКТ В ДРУГОЙ МАССИВ
    Private Sub MoveMassive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        ' Перенести в массив - значит изменить индекс и имя
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "") Else proj.UndoRedo("#Revers Undo", "", "", "")
            proj.ActiveForm.ActiveObj(i).GetMyForm.SetPropertys(trans("Номер"), proj.ActiveForm.GetIndex(sender.text), proj.ActiveForm.ActiveObj(i))
            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            proj.ActiveForm.ActiveObj(i).GetMyForm.SetPropertys(trans("Имя"), sender.text, proj.ActiveForm.ActiveObj(i))

            proj.ActiveForm.ActiveObj(i).obj.refresh()
        Next : proj.ActiveForm.FillListView()
    End Sub

    ' СОЗДАТЬ НОВЫЙ МАССИВ
    Public Sub MassiveCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateArrayMenu.Click
        ' tag содержит SourceControl
        If ObjsMenu.Tag Is Nothing Or proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        proj.ActiveForm.CreateMassive(ObjsMenu.Tag.Name, proj.ActiveForm.ActiveObj)

    End Sub

    ' СОЗДАТЬ ПОДМАССИВ
    Public Sub podMassiveCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateSubArrayMenu.Click
        ' tag содержит SourceControl
        If ObjsMenu.Tag Is Nothing Or proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        proj.ActiveForm.CreatePodMassive(ObjsMenu.Tag, proj.ActiveForm.ActiveObj)
    End Sub

    ' ОБЪЕДИНИТЬ В ПОДМАССИВ НЕСКОЛЬКО ОБЪЕКТОВ
    Public Sub podMassiveUnited_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UniteInSubArrayMenu.Click
        ' tag содержит SourceControl
        If ObjsMenu.Tag Is Nothing Or proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        proj.ActiveForm.UnitedPodMassive(ObjsMenu.Tag, proj.ActiveForm.ActiveObj)
    End Sub

    ' ВЫДЕЛИТЬ МАССИВ ОБЪЕКТОВ МАРКЕРАМИ
    Public Sub MassiveSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectArrayMenu.Click
        If ObjsMenu.Tag Is Nothing Then Exit Sub ' tag содержит SourceControl
        proj.ActiveForm.MassiveSelect(ObjsMenu.Tag)
    End Sub

    ' ВЫДЕЛИТЬ ПОДМАССИВ ОБЪЕКТОВ МАРКЕРАМИ
    Public Sub podMassiveSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectSubArrayMenu.Click
        If ObjsMenu.Tag Is Nothing Then Exit Sub ' tag содержит SourceControl
        proj.ActiveForm.MassiveSelect(ObjsMenu.Tag, ObjsMenu.Tag.index.substring(0, ObjsMenu.Tag.index.LastIndexOf(",")))
    End Sub

    ' ИСКЛЮЧИТЬ ОБЪЕКТ ИЗ МАССИВА
    Public Sub MassiveExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcludeFromArrayMenu.Click
        If ObjsMenu.Tag Is Nothing Then Exit Sub ' tag содержит SourceControl
        proj.ActiveForm.MassiveExecute(proj.ActiveForm.ActiveObj)
    End Sub

    ' ВЫДЕЛИТЬ ВСЕ
    Private Sub SelectAllMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllMenu2.Click
        Dim i, formInd As Integer
        proj.ActiveForm.ActiveObj = Nothing
        formInd = Array.IndexOf(proj.ActiveForm.MyObjs, proj.ActiveForm)
        For i = 0 To proj.ActiveForm.MyObjs.Length - 1
            If i <> formInd Then
                ReDims(proj.ActiveForm.ActiveObj)
                proj.ActiveForm.ActiveObj(proj.ActiveForm.ActiveObj.Length - 1) = proj.ActiveForm.MyObjs(i)
            End If
        Next
        proj.ActiveForm.marker_vis()
    End Sub

    ' КОПИРОВАТЬ ВЫРЕЗАТЬ ВСТАВИТЬ УДАЛИТЬ
    Private Sub CopyMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMenu2.Click
        ' Прогресс-Форма
        If proj.ActiveForm.ActiveObj.Length > BeginProgress Then ProgressFormShow(transInfc("Копирование") & "...")
        ' Если хотят просмотреть код
        If sender Is CodeViewMenu2 Or sender Is CodeViewMenu Then
            ObjTrs = New ObjsTreesText(proj.ActiveForm.ActiveObj)
            CodeView = GetCoding(, , ObjTrs) ' CopyObjFun(proj.ActiveForm.ActiveObj)
        Else
            ' копирование
            CopyObj = CopyObjFun(proj.ActiveForm.ActiveObj)
            Try
                Clipboard.SetText(CopyObj, TextDataFormat.UnicodeText)
            Catch ex As Exception
            End Try
        End If
        ' Прогресс-Форма
        ProgressForm.Hide()
    End Sub
    Private Sub CutMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutMenu2.Click
        CopyMenu2_Click(Nothing, Nothing) : DelMenu2_Click(Nothing, Nothing)
    End Sub
    Private Sub PasteMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteMenu2.Click
        ' Извлечение из буфера
        If Iz.isMyObj(Clipboard.GetText(TextDataFormat.UnicodeText)) Then
            CopyObj = Clipboard.GetText(TextDataFormat.UnicodeText)
        Else
            CopyTree = Clipboard.GetText(TextDataFormat.UnicodeText)
        End If
        If CopyObj Is Nothing Or mozhnoObjEdit() = False Then Exit Sub
        ' Прогресс-Форма
        If CopyObj.Length > BeginProgress * 1000 Then ProgressFormShow(transInfc("Вставка") & "...")
        ' удаление
        If proj.ActiveForm Is Nothing Then PasteObj(CopyObj, Nothing) : ProgressForm.Hide() : Exit Sub
        PasteObj(CopyObj, proj.ActiveForm.ActiveObj)
        ' Прогресс-Форма
        ProgressForm.Hide() : proj.ActiveForm.marker_vis() : Peremeschatel.Focus()
    End Sub
    Private Sub DelMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelMenu2.Click
        If mozhnoObjEdit() = False Or proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        ' Прогресс-Форма
        If proj.ActiveForm.ActiveObj.Length > BeginProgress Then ProgressFormShow(transInfc("Удаление") & "...")
        ' удаление
        DeleteObj(proj.ActiveForm.ActiveObj)
        If proj.ActiveForm.obj.parent Is Nothing Then
            proj.ActiveForm = Nothing : ListView.Items.Clear() : ProgressForm.Hide() : Exit Sub
        End If
        ' Прогресс-Форма
        ProgressForm.Hide() : proj.ActiveForm.marker_vis() : Peremeschatel.Focus()
        proj.ActiveForm.SetActiveObject(proj.ActiveForm)
    End Sub

    ' ДОБАВИТЬ ПУНКТ МЕНЮ
    Public Sub AddMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMenu.Click
        Dim MyObj As Object = proj.ActiveForm.ActiveObj(0) 'proj.GetMyObjFromObj(AddMenu.Tag)
        If MyObj.obj.GetType.ToString = ClassAplication & "TP" Then
            MyObj.addTabPage(New TPages, True)
        ElseIf Iz.IsMM(MyObj) Or Iz.IsCM(MyObj) Or Iz.IsMMs(MyObj) Or Iz.IsTPl(MyObj) Then
            Dim mmenus As New MMenus
            ' У ToolPanel нужно задать для примера рисунок
            If Iz.IsTPl(MyObj) Then mmenus = New MMenus(, , , True)

            proj.ActiveForm.SetActiveObject(MyObj.addMMenuItem(mmenus, True))
            proj.ActiveForm.marker_vis()
        End If
    End Sub
#End Region

    ' <<<<<<<< МЕНЮ TREE >>>>>>>>>
#Region "CONTEXT MENU TREE"

    ' НАСТРОЙКА МЕНЮ ДЕРЕВА
    Private Sub TreeMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TreeMenu.Opening
        ' Скрыть/показать меню "выполнить действие"
        Dim isRun As Boolean
        If RunProj Is Nothing = False Then
            If RunProj.isRUN = False Then isRun = True
        End If
        If SelNode Is Nothing Then Exit Sub
        If isRun And (SelNode.Tag <> "Sobyt" And SelNode.Tag <> "Obj" And SelNode.Tag <> "Comm") Then
            RunDeistMenu.Visible = True : NotRunDeistMenu.Visible = True : RunDeistMenuSplit.Visible = True
        Else
            RunDeistMenu.Visible = False : NotRunDeistMenu.Visible = False : RunDeistMenuSplit.Visible = False
        End If
        ' Скрыть/показать меню "выделить один", "выделить все"
        If SelNode Is Nothing Then SelNode = Tree.SelectedNode
        If maySelect() Then
            SelectAllMenu.Enabled = True : SelectOneMenu.Enabled = True
        Else
            SelectAllMenu.Enabled = False : SelectOneMenu.Enabled = False
        End If
        ' Скрыть/показать меню "Комментировать", "Раскомментировать"
        If SelNode Is Nothing Then SelNode = Tree.SelectedNode
        If SelNode.Level > 1 Then
            CommMenu.Visible = True : UnCommMenu.Visible = True : CommSplit.Visible = True
        Else
            CommMenu.Visible = False : UnCommMenu.Visible = False : CommSplit.Visible = False
        End If
        ' Скрыть/показать меню "Убрать выделения"
        If SelNodes Is Nothing Then UnSelectMenu.Enabled = False Else UnSelectMenu.Enabled = True
        ' Скрыть/показать меню "Выделение"
        Dim i As Integer, fl As Boolean
        For i = 0 To SelectMenu.DropDownItems.Count - 1
            If SelectMenu.DropDownItems(i).Enabled = True Then
                fl = True : Exit For
            End If
        Next
        If fl = True Then SelectMenu.Visible = True Else SelectMenu.Visible = False
        ' Скрыть/показать меню "Вставить"
        If SelNode Is Nothing Then
            If CopyObj = "" And Iz.IsSobytCopy(CopyTree) = False Then PasteMenu.Enabled = False Else PasteMenu.Enabled = True
        ElseIf SelNode.Level > 1 Or Iz.IsCommCopy(CopyTree) Then
            If CopyTree = "" Then PasteMenu.Enabled = False Else PasteMenu.Enabled = True
        Else
            If CopyObj = "" And Iz.IsSobytCopy(CopyTree) = False Then PasteMenu.Enabled = False Else PasteMenu.Enabled = True
        End If
    End Sub

    Private Sub SelectOneMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectOneMenu.Click
        If SelNode Is Nothing Then Exit Sub
        TreeView1_MouseDown(Tree, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, SelNode.Bounds.Left + 1, SelNode.Bounds.Top + 1, 13))
    End Sub

    ' ПРОБЕГАЕТ ПО ДЕРЕВУ И ВЫДЕЛЯЕТ ВСЕ ЭЛЕМЕНТЫ ДЕРЕВА
    Private Sub SelectAllMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllMenu.Click
        If SelNode Is Nothing Then Exit Sub
        If SelNode.Parent Is Nothing Then Exit Sub
        recurs(SelNode.Parent)
        SelectObj()
        TreeView1_MouseMove(Nothing, Nothing)
    End Sub
    ' ПРОБЕГАЕТ ПО ДЕРЕВУ РЕКУРСИВНО И ВЫДЕЛЯЕТ ВСЕ ЭЛЕМЕНТЫ ДЕРЕВА
    Sub recurs(ByVal node As TreeNode)
        Dim i As Integer
        For i = 0 To node.Nodes.Count - 1
            If SelNodes Is Nothing = False Then
                If Array.IndexOf(SelNodes, node.Nodes(i)) <> -1 Then Continue For
            End If
            If SelNodes Is Nothing Then
                ReDim SelNodes(0)
            Else
                ReDim Preserve SelNodes(SelNodes.Length)
            End If
            SelNodes(SelNodes.Length - 1) = node.Nodes(i)
            If node.Nodes(i).Nodes.Count > 0 And node.Nodes(i).Level > 2 Then recurs(node.Nodes(i))
        Next
    End Sub
    Private Sub UnSelectMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnSelectMenu.Click
        TreePaint(Tree.BackColor)
        SelNodes = Nothing
        SelectObj()
    End Sub
    Function getSelNods() As TreeNode()
        Dim nodes() As TreeNode
        If SelNodes Is Nothing = False Then
            nodes = SelNodes
        Else
            ReDim nodes(0) : nodes(0) = SelNode
            If SelNode Is Nothing Then Return Nothing
        End If
        Return nodes
    End Function

    ' КОПИРОВАНИЕ ЭЛЕМЕНТОВ ДЕРЕВА
    Private Sub CopyMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMenu.Click
        If isEditTree Then Exit Sub
        Dim nodes() As TreeNode = getSelNods()
        If nodes Is Nothing Then Exit Sub
        ' Если копируют объекты, то отправить в процедуру ОбъМеню
        If nodes(0).Level <= 1 And nodes(0).Tag <> "Comm" Then ObjsMenu.Tag = proj.ActiveForm.ActiveObj(0).obj : CopyMenu2_Click(sender, e) : Exit Sub
        ' Если хотят просмотреть код
        If sender Is CodeViewMenu Then
            ObjTrs = New ObjsTreesText(GetMyObjsFromTreeNode(nodes(0)))
            CodeView = GetCoding(, , ObjTrs) ' CopyObjFun(proj.ActiveForm.ActiveObj)
        Else
            CopyTree = GetCopyTree(nodes)
            Try
                Clipboard.SetText(CopyTree, TextDataFormat.UnicodeText)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub PasteMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteMenu.Click
        If isEditTree Then Exit Sub
        ' Извлечение из буфера
        If Iz.isMyObj(Clipboard.GetText(TextDataFormat.UnicodeText)) Then
            CopyObj = Clipboard.GetText(TextDataFormat.UnicodeText)
        Else
            CopyTree = Clipboard.GetText(TextDataFormat.UnicodeText)
        End If
        ' Если вставляют объекты, то отправить в процедуру ОбъМеню
        If SelNode Is Nothing And CopyObj <> "" Then GoTo pasteobj
        If SelNode Is Nothing Then Exit Sub
        If SelNode.Level <= 1 And Iz.IsSobytCopy(CopyTree) = False And Iz.IsCommCopy(CopyTree) = False Then
pasteobj:   If proj.ActiveForm Is Nothing = False Then
                If proj.ActiveForm.ActiveObj Is Nothing = False Then
                    ObjsMenu.Tag = proj.ActiveForm.ActiveObj(0).obj
                Else
                    ObjsMenu.Tag = proj.ActiveForm
                End If
            End If
            PasteMenu2_Click(sender, e) : Exit Sub
        End If
        If CopyTree = Nothing Then Exit Sub
        Dim node() As TreeNode = PasteTree(SelNode, CopyTree)
        If node Is Nothing = False Then
            SelNodes = node : TreeView1_AfterSelect(Nothing, Nothing)
            If SelNodes.Length > 1 Then TreePaint(ColKode) Else TreePaint(Tree.BackColor) : SelNodes = Nothing
        End If
    End Sub

    Private Sub CutMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutMenu.Click
        CopyMenu_Click(sender, e) : DelMenu_Click(sender, e)
    End Sub

    Private Sub DelMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelMenu.Click
        If isEditTree Then Exit Sub
        DeleteTree(False, Nothing)
        RunDeistMenu_Click(Nothing, Nothing)
    End Sub
    ' ПРОБЕГАЕТ ПО УЗЛУ chto РЕКУРСИВНО И ИЩЕТ ТАМ УЗЛЫ ИЗ selNods
    Function HaveSelNodes(ByVal Chto As TreeNode, ByVal selNods() As Object, ByVal ind As Integer) As Boolean
        Dim ret As Boolean, i As Integer
        For i = 0 To Chto.Nodes.Count - 1
            ret = HaveSelNodes(Chto.Nodes(i), selNods, ind)
            If ret = True Then Return True
        Next
        If Array.IndexOf(selNods, Chto) > -1 And Array.IndexOf(selNods, Chto) <> ind Then Return True
        Return False
    End Function
    ' ПРОБЕГАЕТ ПО УЗЛУ chto РЕКУРСИВНО И ИЩЕТ ТАМ УЗЛЫ ИЗ selNods
    Function HaveSelNodesInt(ByRef Chto As TreeNode, ByRef selNods() As Object, ByVal ind As Integer) As Integer
        Dim ret As Integer, i As Integer
        For i = 0 To Chto.Nodes.Count - 1
            ret = HaveSelNodesInt(Chto.Nodes(i), selNods, ind)
            If ret <> -1 Then Return ret
        Next
        ret = -1
        For i = 0 To selNods.Length - 1
            If i > selNods.Length - 1 Then Exit For
            On Error GoTo errFullPath
            If selNods(i).TreeView Is Nothing = False And Chto.TreeView Is Nothing = False Then
                If selNods(i).FullPath = Chto.FullPath And selNods(i).name = Chto.Name Then ret = i
                If ret > -1 And ret <> ind Then Return ret
            End If
errFullPath:
        Next
        Return -1
    End Function


    ' МИНИ МЕНЮ КОТОРОЕ ПОЯВЛЯЕТСЯ ПОСЛЕ ПЕРЕТАСКИВАНИЯ УЗЛА ПРАВОЙ КНОПКОЙ МЫШИ
    Private Sub CopyMenu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMenu3.Click
        TreeView1_MouseUp(sender, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, TreeMiniMenu.Tag.x, TreeMiniMenu.Tag.y, 1))
    End Sub
    Private Sub MoveMenu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveMenu3.Click
        TreeView1_MouseUp(sender, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, TreeMiniMenu.Tag.x, TreeMiniMenu.Tag.y, 1))
    End Sub
    Private Sub CancelMenu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelMenu3.Click
        MouseD = False : MouseM = False
    End Sub

    ' МЕНЮ ПАНЕЛИ ПОЛУОБЪЕКТОВ
    Private Sub PasteMenu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteMenu3.Click
        PasteMenu2_Click(sender, e)
    End Sub

    ' НА ПЕРЕДНИЙ ПЛАН МЕНЮ
    Private Sub BringToFrontMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BringToFrontMenu.Click
        Dim i As Integer
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        ' УндоРедо
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            If bistro_UnRe = False Then proj.UndoRedo("На передний план", GetUNameObj(proj.ActiveForm.ActiveObj(i)), proj.ActiveForm.HistoryLevel.Count - 1, proj.ActiveForm.HistoryLevel.IndexOf(proj.ActiveForm.ActiveObj(i)))
            If i < proj.ActiveForm.ActiveObj.Length - 1 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
        Next
        ' Занос в хистори левел и перемещение на нужный план
        proj.ActiveForm.HistoryLevelRun("На передний план", proj.ActiveForm.ActiveObj)
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            proj.ActiveForm.HistoryLevel.Remove(proj.ActiveForm.ActiveObj(i))
            proj.ActiveForm.HistoryLevel.Add(proj.ActiveForm.ActiveObj(i))
            proj.ActiveForm.ActiveObj(i).HideMarker.BringToFront()
            proj.ActiveForm.ActiveObj(i).obj.BringToFront()
        Next
    End Sub
    ' НА ЗАДНИЙ ПЛАН МЕНЮ
    Private Sub SendToBackMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToBackMenu.Click
        Dim i As Integer
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        ' УндоРедо
        For i = proj.ActiveForm.ActiveObj.Length - 1 To 0 Step -1
            If bistro_UnRe = False Then proj.UndoRedo("На задний план", GetUNameObj(proj.ActiveForm.ActiveObj(i)), 0, proj.ActiveForm.HistoryLevel.IndexOf(proj.ActiveForm.ActiveObj(i)))
            If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
        Next
        ' Занос в хистори левел и перемещение на нужный план
        proj.ActiveForm.HistoryLevelRun("На задний план", proj.ActiveForm.ActiveObj)
        For i = proj.ActiveForm.ActiveObj.Length - 1 To 0 Step -1
            proj.ActiveForm.HistoryLevel.Remove(proj.ActiveForm.ActiveObj(i))
            proj.ActiveForm.HistoryLevel.Insert(0, proj.ActiveForm.ActiveObj(i))
            proj.ActiveForm.ActiveObj(i).obj.SendToBack()
            proj.ActiveForm.ActiveObj(i).HideMarker.SendToBack()
        Next
    End Sub
    Private Sub BringToFrontMenuOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BringToFrontMenuOne.Click
        Dim i As Integer, newUrov() As Object
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            ReDims(newUrov)
            newUrov(i) = proj.ActiveForm.HistoryLevel.IndexOf(proj.ActiveForm.ActiveObj(i)) + 1
            If newUrov(i) > proj.ActiveForm.HistoryLevel.Count - 1 Then newUrov(i) = -1
        Next
        SortUnion(newUrov, proj.ActiveForm.ActiveObj)
        ' УндоРедо
        proj.UndoRedo("#Revers Redo", "", "", "")
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            If newUrov(i) = -1 Then Continue For
            If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            If bistro_UnRe = False Then proj.UndoRedo("На передний план", GetUNameObj(proj.ActiveForm.ActiveObj(i)), newUrov(i), proj.ActiveForm.HistoryLevel.IndexOf(proj.ActiveForm.ActiveObj(i)))
        Next
        ' Занос в хистори левел и перемещение на нужный план
        For i = proj.ActiveForm.ActiveObj.Length - 1 To 0 Step -1
            If newUrov(i) = -1 Then Continue For
            proj.ActiveForm.HistoryLevelRun(newUrov(i), proj.ActiveForm.ActiveObj(i))
            proj.ActiveForm.ActiveObj(i).HideMarker.SendToBack()
        Next
        For i = proj.ActiveForm.ActiveObj.Length - 1 To 0 Step -1
            If newUrov(i) = -1 Then Continue For
            proj.ActiveForm.HistoryLevel.Remove(proj.ActiveForm.ActiveObj(i))
            proj.ActiveForm.HistoryLevel.Insert(newUrov(i), proj.ActiveForm.ActiveObj(i))
        Next
    End Sub
    Private Sub SendToBackMenuOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToBackMenuOne.Click
        Dim i As Integer, newUrov() As Object
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            ReDims(newUrov)
            newUrov(i) = proj.ActiveForm.HistoryLevel.IndexOf(proj.ActiveForm.ActiveObj(i)) - 1
            If newUrov(i) < 0 Then newUrov(i) = -1
        Next
        SortUnion(newUrov, proj.ActiveForm.ActiveObj)
        ' УндоРедо
        proj.UndoRedo("#Revers Undo", "", "", "") ': proj.UndoRedo("#Revers Redo", "", "", "")
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            If newUrov(i) = -1 Then Continue For
            If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            If bistro_UnRe = False Then proj.UndoRedo("На задний план", GetUNameObj(proj.ActiveForm.ActiveObj(i)), newUrov(i), proj.ActiveForm.HistoryLevel.IndexOf(proj.ActiveForm.ActiveObj(i)))
        Next
        ' Занос в хистори левел и перемещение на нужный план
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            If newUrov(i) = -1 Then Continue For
            proj.ActiveForm.HistoryLevelRun(newUrov(i), proj.ActiveForm.ActiveObj(i))
            proj.ActiveForm.ActiveObj(i).HideMarker.SendToBack()
        Next
        For i = proj.ActiveForm.ActiveObj.Length - 1 To 0 Step -1
            If newUrov(i) = -1 Then Continue For
            proj.ActiveForm.HistoryLevel.Remove(proj.ActiveForm.ActiveObj(i))
            proj.ActiveForm.HistoryLevel.Insert(newUrov(i), proj.ActiveForm.ActiveObj(i))
        Next
    End Sub
    Function SortUnion(ByRef ar1() As Object, ByRef ar2 As Object)
        Dim i As Integer, fl As Boolean = True, temp As Object
        While fl = True
            fl = False
            For i = 0 To ar1.Length - 2
                If ar1(i) > ar1(i + 1) Then
                    temp = ar1(i) : ar1(i) = ar1(i + 1) : ar1(i + 1) = temp
                    temp = ar2(i) : ar2(i) = ar2(i + 1) : ar2(i + 1) = temp
                    fl = True
                End If
            Next
        End While
    End Function

    ' СКРЫТЬ ВСЕ/РАЗВЕРНУТЬ ВСЕ
    Private Sub ShowAllMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllMenu2.Click
        If Tree.SelectedNode Is Nothing = False Then Tree.SelectedNode.ExpandAll()
    End Sub
    Private Sub HideAllMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideAllMenu2.Click
        If Tree.SelectedNode Is Nothing = False Then Tree.SelectedNode.Collapse(False) : Tree.SelectedNode.Expand()
    End Sub
    Private Sub ShowAllMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllMenu.Click
        Tree.ExpandAll()
    End Sub
    Private Sub HideAllMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideAllMenu.Click
        Tree.CollapseAll()
    End Sub

    Private Sub NodeEdit_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NodeEdit.click
        EditNodeMenu_Click(Nothing, Nothing)
    End Sub
    Private Sub NodeDel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NodeDel.click
        DeleteTree(Nothing, Nothing)
    End Sub
    Private Sub NodeBreakpoint_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NodeBreakpoint.click
        BreakpointMenu_Click(Nothing, Nothing)
    End Sub

    ' ПЕРЕМЕЩЕНИЕ УЗЛА НА ОДИН ПУНКТ ВВЕРХ
    Private Sub UpMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpMenu.Click
        NodeUp_click(Nothing, Nothing)
    End Sub
    Private Sub DownMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownMenu.Click
        NodeDown_click(Nothing, Nothing)
    End Sub
    Private Sub NodeUp_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NodeUp.click
        UpDownNode(True)
    End Sub
    Private Sub NodeDown_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NodeDown.click
        UpDownNode(False)
    End Sub
    Sub UpDownNode(ByVal UpOrDown As Boolean)
        Dim tempNode, SNode(), ToSel() As TreeNode, i, level As Integer, upNode As Object
        SNode = GetSortSelNodes(getSelNods, , UpOrDown)
        If SNode Is Nothing Then Exit Sub
        If SNode(0) Is Nothing Then Exit Sub
        level = SNode(0).Level
        For i = 0 To SNode.Length - 1
            If level <> SNode(i).Level Then Exit For
            If SNode(i).Level = 1 And proj.GetMyFormsFromName(SNode(i).Name) Is Nothing = False Then Exit For
            upNode = SledNode(SNode(i), UpOrDown) ' SNode(i).PrevNode
            If upNode Is Nothing Then Exit Sub
            If UpOrDown = True Then
                ' Когда перемещаю в вверх, то один раз сдалать превиювНоде - это оставитьь элемент на томже месте
                'If SNode(i).Tag <> "Comm" Then 
                upNode = SledNode(upNode, UpOrDown) 'SNode(i).PrevNode.PrevNode
            Else
                ' Когда перемещаю в вниз, то надо чтобы апНоде был ниже самого последнего выделенного элемента
                While Array.IndexOf(SNode, upNode) <> -1
                    upNode = SledNode(upNode, UpOrDown)
                    If upNode Is Nothing Then Exit Sub
                End While
            End If
            ' ЕлсеИфы и Eлсы можно меремещать тока внутри одного ифа

            ' ветка апНоде это то место куда нужно переместить селнод, но она может быль не подходящей веткой для перемещения нода
            If upNode Is Nothing Then
                ' если глюк или хотят поставить выше формы
                If UpOrDown = False Or SNode(i).Level = 1 Then Exit Sub
                upNode = SNode(i).PrevNode.Parent
                If upNode Is Nothing Then upNode = Tree 'If SNode(i).Tag = "Comm" Then upNode = Tree Else Exit Sub
            End If
            ' Если апноде это Иф, то он не подходит для перемещения, надо искать дальше(кроме IsRodnyeTree)
            While Iz.IsContenerTree(upNode) And upNode Is Nothing = False 'And Array.IndexOf(ToSel, upNode) = -1
                If upNode.Level <> level Then Exit While
                If ToSel Is Nothing = False Then If Array.IndexOf(ToSel, upNode) <> -1 Then Exit While
                tempNode = upNode
                upNode = SledNode(upNode, UpOrDown)
            End While
            ' Если дошли до конца, то нужно попобовать переместить ветку на первое место
            If upNode Is Nothing Then
                If UpOrDown = False Then Exit Sub
                upNode = SNode(i).Parent
                If upNode Is Nothing Then If SNode(i).Tag = "Comm" Then upNode = Tree Else Exit Sub
            End If
            ' Собственно перемещение
            If i > 0 Then
                proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            Else
                ' Порядок действий в ундо надо инвертировать
                proj.UndoRedo("#Revers Undo", "", "", "")
            End If
            MoveNode(upNode, True, SNode(i))
            ReDims(ToSel) : ToSel(ToSel.Length - 1) = SelNode
            If SelNodes Is Nothing = False Then ToSel(ToSel.Length - 1) = SelNodes(0)
        Next
        If ToSel Is Nothing = False Then ReSortMyObjs(ToSel(0)) : SelNodes = ToSel : Tree.SelectedNode = ToSel(0) : TreePaint(ColKode)
    End Sub
    Function SledNode(ByRef node As Object, ByVal UpOrDown As Boolean) As TreeNode
        If UpOrDown = True Then
            Return node.PrevNode
        Else
            'If node.Tag = "Comm" Then
            ' If node.NextNode Is Nothing = False Then
            ' Return node.NextNode.Nextnode
            ' Else
            ' Return Nothing
            'End If
            '   Else
            Return node.NextNode
            ' End If
        End If
    End Function

    ' Создание КОНТРОЛЬНОЙ ТОЧКИ
    Private Sub BreakpointMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BreakpointMenu.Click
        If SelNode Is Nothing Then Exit Sub
        If SelNode.Tag = "Comm" Then Exit Sub
        If Breaks Is Nothing Then
            GoTo addBp
        ElseIf Array.IndexOf(Breaks, SelNode) = -1 Then
addBp:      ReDims(Breaks) : Breaks(Breaks.Length - 1) = SelNode
        Else
            Dim ind As Integer = Array.IndexOf(Breaks, SelNode)
            Graphics.FromHwnd(Tree.Handle).DrawRectangle(New Pen(Tree.BackColor, 3), Breaks(ind).Bounds)
            DelDims(Breaks, ind)
        End If
        TreePaint(ColKode)
    End Sub

    ' Отмечает действие, которое должно будет выполнится после запуска проги
    Private Sub RunDeistMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunDeistMenu.Click
        TreePaint(ColKode, True) : debugNode = SelNode : param.bylBreakpoint = debugNode : TreePaint(ColKode)
    End Sub
    Private Sub NotRunDeistMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotRunDeistMenu.Click
        TreePaint(ColKode, True) : debugNode = Nothing : param.bylBreakpoint = Nothing
    End Sub

#End Region

    ' <<<<<<<< КОПИРОВАНИЕ УДАЛЕНИЕ ВСТАВКА >>>>>>>>>
#Region "COPY PASTE DEL"

    ' ПОЛУЧИТЬ КОПИЮ nodes В ТЕКСТОВОМ ВИДЕ
    Function GetCopyTree(ByVal nodes() As Object, Optional ByVal withParent As Boolean = False, Optional ByVal toEng As Boolean = False, Optional ByRef ObjsTres As ObjsTreesText = Nothing) As String
        Dim i As Integer, selParentNode, CopyNode, CopyNodes, clon As TreeNode, SortSelNodes() As Object
        Dim parent As String = ""

        ' создание моего буфера обмена
        CopyNodes = New TreeNode
        ' узлы должни быть сортированы по level узла
        SortSelNodes = GetSortSelNodes(nodes)

        If SortSelNodes Is Nothing Then Return Nothing
        If SortSelNodes(0) Is Nothing Then Return Nothing
        For i = 0 To SortSelNodes.Length - 1
            ' узнать, есть ли выделенный парент нод у даннового выделенного узла
            selParentNode = GetSelParentNode(SortSelNodes, SortSelNodes(i))
            ' если нет, то добавлять прямо в корень CopyNodes
            If selParentNode Is Nothing Then selParentNode = CopyNodes
            ' поиск в CopyNodes парентн нода в который надо добавить выделенный элемент
            CopyNode = proj.GetNode(selParentNode, CopyNodes)
            ' If CopyNode Is Nothing Then CopyNode = CopyNodes
            ' создать копию выделенного узла
            If SortSelNodes(i).Tag = "Sobyt" Or HaveSelNodes(SortSelNodes(i), SortSelNodes, i) = False Then
                clon = SortSelNodes(i).Clone
                'setUINs(clon.Nodes)
            Else
                clon = New TreeNode(SortSelNodes(i).Text)
                clon.ImageKey = SortSelNodes(i).ImageKey
                clon.SelectedImageKey = SortSelNodes(i).SelectedImageKey
                clon.Tag = SortSelNodes(i).Tag
                clon.Name = SortSelNodes(i).Name
            End If
            ' добавить копию выделенного узла в мой буфер обмена
            CopyNode.Nodes.Add(clon)
            ' Запись родительского узла для ундо редо
            If withParent Then
                If SortSelNodes(i).TreeView Is Nothing Then Continue For
                If SortSelNodes(i).Parent Is Nothing = False Then
                    If proj.isObject(SortSelNodes(i).Parent.Name) <> "" Then
                        parent &= "#Parent" & vbCrLf & SortSelNodes(i).Parent.FullPath & _
                                "(" & SortSelNodes(i).Parent.index & ")" & vbCrLf
                    Else
                        parent &= "#Parent" & vbCrLf & SortSelNodes(i).Parent.Name & vbCrLf
                    End If
                Else
                    ' Если это ветвь самая корневая, то у нее парента нет
                    parent &= "#Parent" & vbCrLf & "" & vbCrLf
                End If
                parent &= "#Index" & vbCrLf & SortSelNodes(i).Index & vbCrLf
            Else
                parent = ""
            End If
        Next
        ' Клонирование, для создании уникальных имен объектам
        'If withParent = False Then
        'CopyNodes = proj.CloneTreeNode(CopyNodes)
        'If ObjsTres IsNot Nothing Then ObjsTres.popravka += parent.Length
        ' перевод моего буфера обмена в текст
        Return parent & Perevodi.ToStrFromTree(CopyNodes, toEng, ObjsTres)
    End Function
    Function GetCopyTree(ByVal node As TreeNode, Optional ByVal withParent As Boolean = False, Optional ByVal toEng As Boolean = False) As String
        Dim nds(0) As TreeNode : nds(0) = node : Return GetCopyTree(nds, withParent, toEng)
    End Function

    ' СОРТИРОВАТЬ УЗЛЫ nodes ПО LEVEL УЗЛА
    Function GetSortSelNodes(ByRef nodes() As Object, Optional ByVal spervaKorni As Boolean = True, Optional ByVal spervaVerhInds As Boolean = True) As Object()
        Dim i As Integer, temp, SortSelNodes() As Object
        If nodes Is Nothing = False Then
            SortSelNodes = nodes
        Else
            Return Nothing
        End If
        If SortSelNodes.Length > 1 Then
            ' сортировать по level узла
            Do
                temp = Nothing
                For i = 0 To SortSelNodes.Length - 2
delNothings:        If SortSelNodes(i) Is Nothing Then DelDims(SortSelNodes, i)
                    If SortSelNodes Is Nothing Then Exit For
                    If i > SortSelNodes.Length - 2 Then Exit For
                    If SortSelNodes(i + 1) Is Nothing Then DelDims(SortSelNodes, i + 1) : GoTo delNothings
                    If i > SortSelNodes.Length - 2 Then Exit For
                    If SortSelNodes(i + 1).Level < SortSelNodes(i).Level Then
                        ' Если уровень следующего меньше чем предыдущий
                        If spervaKorni Then temp = SortSelNodes(i) : SortSelNodes(i) = SortSelNodes(i + 1) : SortSelNodes(i + 1) = temp
                    ElseIf SortSelNodes(i + 1).Level > SortSelNodes(i).Level Then
                        ' Если уровень следующего больше чем предыдущий, т.е. сперваВетки
                        If spervaKorni = False Then temp = SortSelNodes(i) : SortSelNodes(i) = SortSelNodes(i + 1) : SortSelNodes(i + 1) = temp
                    ElseIf SortSelNodes(i + 1).Level = SortSelNodes(i).Level Then
                        ' Рас уровни одинаковые, то проверить индексы и если не в правильном порядке, то переставить
                        If (spervaVerhInds And SortSelNodes(i + 1).Index < SortSelNodes(i).Index) Or (spervaVerhInds = False And SortSelNodes(i + 1).Index > SortSelNodes(i).Index) Then
                            temp = SortSelNodes(i) : SortSelNodes(i) = SortSelNodes(i + 1) : SortSelNodes(i + 1) = temp
                        End If
                    End If
                Next
            Loop While temp Is Nothing = False
        End If
        Return SortSelNodes
    End Function
    ' УЗНАТЬ, ЕСТЬ ЛИ ВЫДЕЛЕННЫЙ ПАРЕНТ НОД У ДАННОВОГО ВЫДЕЛЕННОГО УЗЛА
    Function GetSelParentNode(ByVal nodes() As Object, ByVal node As TreeNode)
        If node Is Nothing Then Return Nothing
        While node.Parent Is Nothing = False
            node = node.Parent
            If Array.IndexOf(nodes, node) <> -1 Then Return node
        End While
        Return Nothing
    End Function
    ' ПРИСВОИТЬ УНИКАЛЬНЫЕ ИМЕНА ВСЕМ ДЕЙСТВИЯМ
    Sub setUINs(ByVal nodes As TreeNodeCollection)
        Dim i As Integer
        For i = 0 To nodes.Count - 1
            nodes(i).Name = GetUIN()
            If nodes(i).Nodes.Count > 0 Then setUINs(nodes(i).Nodes)
        Next
    End Sub


    ' ПЕРЕНОС ОБЪЕКТА НА ДРУГОЙ КОНТЕНЕР
    Sub MoveObj(ByVal MyCont As Object, ByVal ParamArray MyObjs() As Object)
        Dim i As Integer, contener As Object
        If MyCont Is Nothing = False And MyObjs Is Nothing = False Then
            For i = 0 To MyObjs.Length - 1
                ' Если хотят перемистить объект на самого себя или хотят перемистить форму
                If MyCont.obj Is MyObjs(i).obj Or MyObjs(i).obj.GetType.ToString = ClassAplication & "F" Then Continue For
                ' Если объект и так на этом контенере
                If MyCont Is MyObjs(i).conteiner Then Continue For
                ' Встроенные объекты нельзя перемещать
                If MyObjs(i).obj.TypeObj = "IncludeObj" Then Continue For
                ' Если выделена двойная панель
                If MyCont.obj.GetType.ToString = ClassAplication & "DP" Then
                    Dim res As MsgBoxResult
                    If MyCont.ActivePanel = "" Then
                        res = MsgBox(transInfc("Вы хотите разместить объект на первой из двух панелей?"), MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question)
                    Else
                        If MyCont.ActivePanel = "Panel1" Then res = MsgBoxResult.Yes Else res = MsgBoxResult.No
                    End If
                    If res = MsgBoxResult.Yes Then
                        ' Разместить объект на первой панели
                        contener = MyCont.obj.panel1
                    ElseIf res = MsgBoxResult.No Then
                        ' Разместить объект на второй панели
                        contener = MyCont.obj.panel2
                    ElseIf res = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                Else
                    ' Разместить объект на высчитаном контейнере
                    contener = MyCont.obj
                End If
                If MyObjs(i).obj.GetType.ToString = ClassAplication & "DP" Then
                    contener.controls.add(MyObjs(i).HideMarker)
                Else
                    If Iz.isSostMyObj(MyObjs(i)) = False Then 'MyObjs(i).obj.GetType.ToString <> ClassAplication & "TP" Then
                        MyObjs(i).obj.controls.add(MyObjs(i).HideMarker)
                    End If
                End If
                ' Разместить объект в центре нового контенера
                MyObjs(i).obj.Location = proj.ActiveForm.GetXY(MyObjs(i).obj, contener, contener.Width / 2 - MyObjs(i).obj.Width / 2, contener.Height / 2 - MyObjs(i).obj.Height / 2)
                Try
                    Dim oldCont = MyObjs(i).conteiner
                    Dim oldContUName = GetUNameObj(oldCont, MyObjs(i))
                    contener.controls.add(MyObjs(i).obj)
                    MyObjs(i).conteiner = MyCont
                    If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                    If bistro_UnRe = False Then proj.UndoRedo("Переместить объект", GetUNameObj(MyObjs(i)), GetUNameObj(MyCont, MyObjs(i)), oldContUName)
                Catch ex As Exception
                    Errors.MessangeInfo(ex.Message)
                End Try
            Next
            If MyCont.obj.GetType.ToString = ClassAplication & "DP" Then MyCont.ActivePanel = ""
            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            BringToFrontMenu_Click(Nothing, Nothing)
            proj.ActiveForm.marker_vis()
        End If
    End Sub
    ' КОПИРОВАНИЕ ОБЪЕКТА
    Public Function CopyObjFun(ByVal ParamArray MyObjs() As Object) As String
        Return Perevodi.ToStrFromObj(MyObjs)
    End Function
    ' ВСТАВКА ОБЪЕКТА
    Public Function PasteObj(ByVal CopyStr As String, ByVal ParamArray kuda() As Object) As Object()
        Dim i As Integer, name, index As String, result As MsgBoxResult = MsgBoxResult.No, toSel(), forma As Object
        Dim MyObjs() As Object = Perevodi.ToObjFromStr(CopyStr), toUndoRedo As String = ""
        If MyObjs Is Nothing Then Exit Function
        If proj.ActiveForm Is Nothing = False Then proj.ActiveForm.ctrl = False
        If kuda Is Nothing = False Then
            If kuda.Length <> 0 Then ' Is Nothing = False Then
                If kuda(0) Is Nothing = False Then
                    kuda(0).getMyForm.selectTab() : kuda(0).getMyForm.ActiveObj = kuda
                    ObjsMenu.Tag = kuda(0).obj
                Else
                    kuda = Nothing
                End If
            ElseIf kuda.Length = 0 Then
                kuda = Nothing
            End If
        End If
        If ObjsMenu.Tag Is Nothing Then ObjsMenu.Tag = proj.ActiveForm.ActiveObj(0).obj
        ' Получить объект, который был активным, когда нажали ктрл+в или на котором открыли контекстроне меню
        Dim MyObj As Object = proj.GetMyObjFromObj(ObjsMenu.Tag)
        For i = 0 To MyObjs.Length - 1

            ' Прогресс-форма
            Dim jj As Integer = 0 : If proj.UndoRedoNoWrite Then jj = 1
            ProgressForm.ProgressBarValue = ((30 + 70 * jj) / (MyObjs.Length)) * i

            ' Инклуд объекты нельзя вставлять не в их составной объект
            If Iz.isIncludeObj(MyObjs(i).obj) And kuda Is Nothing Then
                If MyObjs(i).conteiner Is Nothing Then DeleteObj(MyObjs) : Exit Function
                'If MyObjs(i).obj.GetType.ToString.IndexOf(ObjsMenu.Tag.GetType.ToString) <> 0 Then DeleteObj(MyObjs) : Exit Function
            End If

            name = MyObjs(i).obj.Props.name : index = MyObjs(i).obj.Props.index : forma = MyObjs(i).GetMyForm
            If forma Is Nothing Then forma = proj.ActiveForm

            ' Если на форме есть объект с таким именем
            If forma.existName(MyObjs(i).obj.Props.name, MyObjs(i).obj) Or Iz.IsFORM(MyObjs(i)) Then
                ' Если на форме объект с таким же индексом, причем индекс больше 0
                If MyObjs(i).obj.Props.index <> 0 And proj.GetMyAllFromName(MyObjs(i).obj.Props.name, index, forma.obj.Props.name) Is Nothing = False Then
                    ' Спосить заносить ли объект в массив
                    result = MsgBox(Errors.CreateMassive(name), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
                    If result = MsgBoxResult.Yes Then
                        ' подобрать несуществующий индекс
                        forma.SetPropertys(trans("Номер"), forma.GetIndex(name), MyObjs(i))
                        ' MyObjs(i).obj.Props.index = forma.GetIndex(name)
                        forma.FillListView()
                    ElseIf result = MsgBoxResult.No Then
                        ' подобрать несуществующее имя
                        forma.SetPropertys(trans("Номер"), 0, MyObjs(i))
                        ' MyObjs(i).obj.Props.index = 0
                    ElseIf result = MsgBoxResult.Cancel Then
                        Continue For
                    End If
                End If
                ' если объект еще не включили в существующий массив (см. выше), то подобрать имя на основе defaultName
                If result <> MsgBoxResult.Yes Then
                    ' У инклудобъектов defaultName должно отражать имя своего контенера
                    If MyObjs(i).obj.TypeObj = "IncludeObj" Then
                        If MyObjs(i).conteiner Is Nothing = False Then
                            MyObjs(i).obj.defaultName = MyObjs(i).conteiner.obj.Props.Name & " " & MyObjs(i).obj.defaultName
                        Else
                            Dim SostObj As Object = proj.GetSostObjFromIncludeObj(MyObjs(i))
                            ' Если выделеный объект является родителем инклуд обхекта, то добавить его
                            If SostObj Is Nothing = False Then
                                MyObjs(i).obj.defaultName = SostObj.obj.Props.Name & " " & MyObjs(i).obj.defaultName
                            Else
                                MyObjs(i).obj.defaultName = forma.ActiveObj(0).obj.Props.Name & " " & MyObjs(i).obj.defaultName
                            End If
                        End If
                    End If

                    ' Если пришло с консоли(ктрл+з), то новые имена подбирать нельзя, они даны как надо
                    If isConsole = False Then
                        ' Если копировали с другой формы, то давать новое имя нужно обязательно
                        Dim drugForma As Boolean = False
                        If MyObjs(i).oldFormTemp <> forma.obj.Props.name Then drugForma = True
                        ' кроме случая,если копировали массив и пару элементов уже есть на форме
                        If proj.GetMyAllFromName(MyObjs(i).obj.Props.name, index, forma.obj.Props.name) Is Nothing Then
                            Dim exstNams() As Object = proj.GetMyAllFromName(MyObjs(i).obj.Props.name, , forma.obj.Props.name)
                            Dim ii As Integer
                            For ii = 0 To i - 1
                                If Array.IndexOf(exstNams, MyObjs(ii)) <> -1 Then drugForma = False : Exit For
                            Next
                        End If
                        ' Итак, подобрать имя на основе defaultName
                        If drugForma Or proj.GetMyAllFromName(MyObjs(i).obj.Props.name, index, forma.obj.Props.name) Is Nothing = False Then
                            Dim temp As TreeNode = MyObjs(i).nodeTemp
                            Dim oldN As String = MyObjs(i).obj.Props.name
                            MyObjs(i).obj.Props.name = proj.GiveName(MyObjs(i).obj.defaultName)
                            MyObjs(i).nodeTemp = temp
                            ' Заменить у остальных копируемых объектов имена на новые
                            Dim ii As Integer
                            For ii = i To MyObjs.Length - 1
                                If MyObjs(ii).obj.Props.name = oldN Then MyObjs(ii).obj.Props.name = MyObjs(i).obj.Props.name
                            Next
                        End If
                    End If

                End If
            End If
            name = MyObjs(i).obj.Props.name
            ' Сделать теперь такоеже имя и у узла объекта
            If MyObjs(i).nodeTemp Is Nothing = False Then
                MyObjs(i).nodeTemp.name = MyObjs(i).obj.Props.name : MyObjs(i).nodeTemp.text = MyObjs(i).obj.Props.name
            End If
            Dim novNode As TreeNode = Nothing
            ' объект, который был активным, когда нажали ктрл+в или на котором открыли контекстроне меню
            If MyObj Is Nothing Then
                ' Сделать чтоб полуобъекты могли тоже добавляться на сплит панель
                If ObjsMenu.Tag.GetType.ToString = "System.Windows.Forms.SplitterPanel" Then
                    MyObj = forma
                End If
            Else
                If MyObjs(i).GetMyForm Is Nothing Then
                    ' Найти в дереве узел для объекта
                    If MyObj.GetMyForm.GetNode Is Nothing = False Then
                        novNode = MyObj.GetMyForm.GetNode.Nodes(MyObjs(i).obj.Props.name)
                    End If
                Else
                    ' Найти в дереве узел для объекта
                    If MyObjs(i).GetMyForm.GetNode Is Nothing = False Then
                        novNode = MyObjs(i).GetMyForm.GetNode.Nodes(MyObjs(i).obj.Props.name)
                    End If
                End If
            End If

            ' Перебросать ветки из временного старого узла в новый конечный узел объекта
            If Iz.isPoluObj(MyObjs(i).obj) = False Then
                proj.PerebrosatTreeNodes(novNode, MyObjs(i).nodeTemp, MyObjs(i))
                MyObjs(i).nodeTemp = Nothing
            End If

            ' Теперь, когда с именами разобрались размещение, еще не размещенных объектов на выделенном
            If MyObjs(i).conteiner Is Nothing Then
                ReDims(toSel) : toSel(toSel.Length - 1) = MyObjs(i)
            End If
            ' Если это вложенный объект и ему еще не назначен контенер, то назначить можно только контенер такого же типа как сам инклудобъект
            ' If MyObjs(i).obj.TypeObj = "IncludeObj" And MyObjs(i).conteiner Is Nothing Then
            ' MyObjs(i).conteiner = Me ' т.е. MainForm
            ' End If
            ' Указать что объект куда-то вствляется
            MyObjs(i).VstavkaOrCreate = True

            ' РАЗМЕЩЕНИЕ ОБЪЕКТА
            If MyObjs(i).obj.TypeObj = "IncludeObj" And MyObjs(i).conteiner Is Nothing = False Then
                ' В этом случае объект уже создан
            Else
                If MyObjs(i).obj.TypeObj <> "IncludeObj" Then ' В этом случае объект создаться должен позднее
                    ' СОЗДАНИЕ ОБЪЕКТА
                    MyObjs(i).CreateObject(MyObjs(i).obj)
                    If Iz.isPoluObj(MyObjs(i).obj) Then
                        proj.PerebrosatTreeNodes(novNode, MyObjs(i).nodeTemp, MyObjs(i))
                        MyObjs(i).nodeTemp = Nothing
                    End If
                End If
            End If

            If MyObjs(i).obj.Props.name = "#NotCreateDP" Then
                'MyObj.GetMyForm.GetNode.Nodes(name).Remove()
                'If toSel Is Nothing = False Then DelDims(toSel, Array.IndexOf(toSel, MyObjs(i)))
                'Exit For
            End If

            If MyObjs(i).obj.GetType.ToString = ClassAplication & "F" Then
                proj.AddForm(MyObjs(i))
            ElseIf MyObjs(i).obj.TypeObj <> "IncludeObj" Then ' В этом случае инклуд объект уже создан (см. 10 строк выше)
                If forma.MyObjs Is Nothing = False Then
                    If Array.IndexOf(forma.MyObjs, MyObjs(i)) = -1 Then forma.AddObject(MyObjs(i), False)
                Else
                    forma.AddObject(MyObjs(i), False)
                End If
            ElseIf MyObjs(i).obj.TypeObj = "IncludeObj" Then
                Dim nado As Boolean = True
                ' Определение есть ли уже этот объект на форме
                If forma.MyObjs Is Nothing = False Then
                    If Array.IndexOf(forma.MyObjs, MyObjs(i)) > -1 Then nado = False
                End If
                ' Если инклуд объект не добавился из за того что вставляли целиком форму
                MyObjs(i).CreateObject(MyObjs(i).obj)
                If Array.IndexOf(forma.MyObjs, MyObjs(i)) = -1 Then forma.AddObject(MyObjs(i), False)
            End If
            ' Постоянное оставлять выделенным объект, который был активным, когда нажали ктрл+в или на котором открыли контекстроне меню
            If MyObj Is Nothing = False Then
                ReDim MyObj.GetMyForm.ActiveObj(0) : MyObj.GetMyForm.ActiveObj(0) = MyObj
            End If

            ' По идеи больше не надо что бы он кудато вставлялся
            MyObjs(i).VstavkaOrCreate = False
        Next

        ' Если был указан хисторилевел, то переместить объект на нужный уровень хисторилевела
        If MyObjs(0).HistoryTemp Is Nothing = False Then
            MyObjs = proj.GetSortMyObjsByHistoryTemp(MyObjs)
            For i = 0 To MyObjs.Length - 1
                If proj.UndoRedoNoWrite Then
                    MyObjs(i).GetMyForm.HistoryLevelRun(MyObjs(i).HistoryTemp, MyObjs(i))
                Else
                    MyObjs(i).GetMyForm.HistoryLevelRun("на передний план", MyObjs(i))
                End If
            Next
        End If

        ' Если у узлов объекта указывали #Parent, то разместить узлы в порядке #Index
        MyObjs = proj.GetSortMyObjsByIndexTemp(MyObjs)
        For i = 0 To MyObjs.Length - 1
            ' Отсортировать MyObj по IndexTemp
            If MyObjs(i).IndexTemp <> "" Then
                Dim nd As TreeNode, isForma As Boolean = False
                If Iz.IsFORM(MyObjs(i)) Then isForma = True

                nd = proj.GetNodeFromName(MyObjs(i).ParentTemp, , True)
                If nd Is Nothing = False Then
                    ' Переместить ноде на заданное IndexTemp место
                    Dim oNd As TreeNode = MyObjs(i).GetNode(, isForma)
                    If oNd Is Nothing = False Then oNd.Remove() : nd.Nodes.Insert(MyObjs(i).IndexTemp, oNd)
                End If
            End If
        Next

        If proj.UndoRedoNoWrite = False Then
            If toSel Is Nothing = False Then
                toSel(0).GetMyForm.ClearActiveObject()
                toSel(0).GetMyForm.SelectTab()
                toSel(0).GetMyForm.ActiveObj = toSel
                toSel(0).GetMyForm.marker_vis()
                toSel(0).GetMyForm.FillListView()
                ' чтобы пункты меню не скрывались за размерами объекта
                If Iz.IsTPl(toSel(0)) Or Iz.IsMM(toSel(0)) Then toSel(0).obj.width += 1 : toSel(0).obj.width -= 1
            End If
        End If

        ' Для ундо редо
        If bistro_UnRe = False Then
            If proj.UndoRedoNoWrite = False Then
                For i = 0 To MyObjs.Length - 1
                    ' Прогресс-форма
                    ProgressForm.ProgressBarValue = 30 + (70 / (MyObjs.Length)) * i
                    ' если контенер этого объекта присутствует в списке объектов, то ненадо его заносить в ундоредо
                    ' т.е. это сделал объект-контенер
                    Dim cnt As Object = MyObjs(i).conteiner
                    While cnt Is Nothing = False
                        If Array.IndexOf(MyObjs, cnt) <> -1 Or Iz.isPoluObj(MyObjs(i).obj) Then Continue For Else cnt = cnt.conteiner
                    End While
                    ' собственно создать ундоредо
                    toUndoRedo &= Perevodi.ToStrFromObj(MyObjs(i), True, , , False)
                Next
                proj.UndoRedo("Создать", "объект", toUndoRedo)
            End If
        End If


        Return toSel
    End Function

    ' ВСТАВИТЬ КОПИЮ nodes В ТЕКСТОВОМ ВИДЕ В РЕАЛЬНЫЙ КОРЕНЬ
    Function PasteTree(ByVal kuda As Object, ByVal CopyNodes As String, Optional ByVal sVoprosom As Boolean = True, Optional ByVal fromMove As Boolean = False) As TreeNode()
        Dim nodes, chto As TreeNode, index, i, j As Integer, uniq, fl As Boolean, Indexs() As String, Parents() As Object
        If CopyNodes = Nothing Or CopyNodes.Trim = "" Then Return Nothing

        ' ОПРЕДЕЛЕНИЕ МЕСТА КУДА ВСТАВЛЯТЬ, ЕСЛИ ОНО УКАЗАННО ПРИ ПОМОЩИ #Parent
        If kuda Is Nothing Then
            Dim strs() As String
            ' Создание массива строк
            Dim rtb As New RichTextBox : rtb.Text = CopyNodes : strs = rtb.Lines
            ' Проход по каждой строке
            For i = 0 To strs.Length - 2
                If strs(i) = "" Then Continue For
                If strs(i) <> "#Parent" Then Continue For
                ReDims(Parents) : Parents(Parents.Length - 1) = strs(i + 1) ' proj.GetNodeFromName(strs(i + 1), , isObj)
                ReDims(Indexs) : Indexs(Indexs.Length - 1) = strs(i + 3)
                j = i + 3
            Next
            If Parents Is Nothing = False Then CopyNodes = getStrFromArray(strs, j + 1)
        End If

        ' ПРЕВРАЩЕНИЕ ТЕКСТА В ЭЛЕМЕНТЫ ДЕРЕВА
        nodes = Perevodi.ToTreeFromStr(CopyNodes) ': ReDim sel(nodes.Nodes.Count - 1)
        If nodes.Nodes.Count = 0 And nodes.Text = "" Then Exit Function
        'сделать имена уникальными
        If proj.UndoRedoNoWrite = False Then
            nodes = proj.CloneTreeNode(nodes)
        End If
        ' Чтобы узнать что будет парентом(ветка формы с левел 0 или 1 при одинаковых именах), узнаем объекты ли вставляются или ветки
        Dim isObj As Boolean = False
        Dim isOb As String = proj.isObject(nodes.Nodes(0).Name)
        If isOb <> "" Or nodes.Nodes(0).Tag = "Comm" Then isObj = True

        ' ОПРЕДЕЛЕНИЕ ТОЧНОГО МЕСТА КУДА ВСТАВЛЯТЬ
        ' Если место куда вставлять не указанно при помощи #Рarent
        If Parents Is Nothing Then
            If kuda Is Nothing Then
                If proj.GetMyFormsFromName(isOb) Is Nothing = False Then
                    Tree.Nodes.Add(nodes.Nodes(0).Name, nodes.Nodes(0).Text, nodes.Nodes(0).ImageKey, nodes.Nodes(0).SelectedImageKey)
                    Tree.Nodes(0).Tag = nodes.Nodes(0).Tag
                    index = 0 : kuda = Tree.Nodes(0)
                Else
                    Return Nothing
                End If
            ElseIf nodes.Nodes(0).Tag = "Sobyt" Then
                If kuda.Level = 2 Then
                    index = kuda.Index + 1 : kuda = kuda.Parent
                ElseIf kuda.Level = 1 Then
                    index = 0
                Else
                    Return Nothing
                End If
                uniq = True
            ElseIf kuda Is Tree Then 'Or nodes.Nodes(0).Tag = "Comm" Then
                If kuda Is Tree = False Then
                    index = kuda.Index + 1
                    'If kuda.nodes.count > 0 Then index -= 1
                    'If fromMove Then index += 1
                    ' If kuda.nodes.Count > 0 And fromMove = False Then index = 0 Else kuda = kuda.parent
                    If kuda.level <= 2 And kuda.tag <> "Comm" And fromMove = False Then index -= 1
                    If Iz.IsContenerTree(kuda) = False Then kuda = kuda.Parent
                    If kuda Is Nothing Then kuda = Tree
                    If SelNode Is Nothing = False Then If index > 0 And SelNode.Nodes.Count > 0 Then index -= 1
                    'If index = kuda.nodes.count - 1 And Tree.SelectedNode.Tag <> "Sobyt" And fromMove Then index += 1
                Else
                    index = 0
                End If
            ElseIf kuda.Level = 0 Then
                If isOb = "" And nodes.Nodes(0).Tag <> "Comm" Then
                    Return Nothing
                Else
                    If proj.GetMyFormsFromName(isOb) Is Nothing = False Then
                        index = kuda.index + 1 : kuda = Tree
                    Else
                        index = 0
                    End If
                End If
            ElseIf kuda.Level = 1 Then
                If isOb = "" And nodes.Nodes(0).Tag <> "Comm" Then
                    Return Nothing : Else : index = kuda.Index + 1 : kuda = kuda.Parent
                End If
            ElseIf kuda.Level = 2 Or Iz.IsContenerTree(kuda) Then
                If (Iz.IsVnutreniyIf(nodes.Nodes(0)) Or nodes.Nodes(0).Tag = "EndIf") And (Iz.IsVnutreniyIf(kuda) Or kuda.Tag = "If") Then
                    If isOb <> "" Then Return Nothing Else index = kuda.Index + 1 : kuda = kuda.Parent
                ElseIf (nodes.Nodes(0).Tag = "EndWhile") And kuda.Tag = "While" Then
                    If isOb <> "" Then Return Nothing Else index = kuda.Index + 1 : kuda = kuda.Parent
                Else
                    If isOb <> "" Then Return Nothing Else index = 0
                End If
            ElseIf kuda.Level >= 3 Then
                If isOb <> "" Then Return Nothing Else index = kuda.Index + 1 : kuda = kuda.Parent
            End If
        End If


        ' ВСТАВКА УЗЛОВ
        For i = 0 To nodes.Nodes.Count - 1
            ' Если нужно, чтобы узлы не повторялись в одной ветке
            If uniq = True Then
                ' Если такое событие уже есть
                If proj.FindSobyt(nodes.Nodes(i).Text, kuda) Is Nothing = False Then
                    ' Спросить можно ли заменить его
                    If proj.FindSobyt(nodes.Nodes(i).Text, kuda).Nodes.Count > 0 And sVoprosom = True And fromMove = False Then
                        If MsgBox(transInfc("Событие") & " """ & nodes.Nodes(i).Text & """ " & transInfc("уже существует, замените его?"), MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Return Nothing
                    End If
                    DeleteTree(True, proj.FindSobyt(nodes.Nodes(i).Text, kuda))
                    proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                    ' proj.FindSobyt(nodes.Nodes(i).Text, kuda).Remove()
                    If index > kuda.Nodes.Count - 1 Then index = kuda.Nodes.Count
                End If
                ' Если скопированного события нет в списке событий объекта, в который вставляют это событие
                If kuda.Level = 1 Then
                    Dim obs() = proj.GetMyAllFromName(kuda.Name, , kuda.Parent.Name)
                    If obs Is Nothing = False Then
                        fl = False
                        For j = 0 To obs.Length - 1
                            If Array.IndexOf(obs(j).SobytsUp, UCase(nodes.Nodes(i).Text)) <> -1 Then fl = True : Continue For
                        Next
                    End If
                    If fl = False Then
                        MsgBox(transInfc("Событие") & " """ & nodes.Nodes(i).Text & """ " & transInfc("не улавливается объектом") & " """ & kuda.Name & """", MsgBoxStyle.Information)
                        Return Nothing
                    End If
                End If
            End If
            ' Если место куда вставлять не указанно при помощи #Рarent
            If Parents Is Nothing Then
                kuda.Nodes.Insert(index, nodes.Nodes(i))
                index += 1
            Else
                If i < Parents.Length Then
                    kuda = proj.GetNodeFromName(Parents(i), , isObj)
                Else
                    kuda = proj.GetNodeFromName(Parents(0), , isObj)
                    ReDim Preserve Indexs(i) : Indexs(i) = 0
                End If
                If kuda Is Nothing = False Then
                    ' Если ветки не сущ, то её добавить
                    If kuda.Nodes(nodes.Nodes(i).Name) Is Nothing Then
                        kuda.Nodes.Insert(Indexs(i), nodes.Nodes(i))
                    Else
                        If kuda.Nodes(nodes.Nodes(i).Name).Index = Indexs(i) Then
                            kuda.Nodes(nodes.Nodes(i).Name).Remove()
                        End If
                        kuda.Nodes.Insert(Indexs(i), nodes.Nodes(i))
                    End If
                End If
            End If
        Next

        ' Добавить отдельно узлы в паренты, которые не основного левела, а более высокого. А следовательно они не могли добавиться в прошлом цикле выше
        If Parents Is Nothing = False Then
            For i = nodes.Nodes.Count To Parents.Length - 1
                kuda = proj.GetNodeFromName(Parents(i), , isObj)
                chto = proj.GetNodeFromName(Parents(i), nodes, isObj)
                If kuda Is Nothing = False And chto Is Nothing = False Then
                    For j = 0 To chto.Nodes.Count - 1
                        ' Если ветки не сущ, то её добавить
                        If kuda.Nodes(chto.Nodes(j).Name) Is Nothing Then
                            kuda.Nodes.Insert(Indexs(i), chto.Nodes(j))
                        End If
                    Next
                End If
            Next
        End If

        ' Удаление пустых веток (EmptyIf) и раскрывание(ExpandAll) парентов
        Dim delEmp() As Object = Nothing
        If Parents Is Nothing Then
            ReDims(delEmp) : delEmp(0) = kuda
        Else
            For i = 0 To Parents.Length - 1
                ReDims(delEmp) : delEmp(i) = proj.GetNodeFromName(Parents(i), , isObj)
            Next
        End If
        For j = 0 To delEmp.Length - 1
            If delEmp(j) Is Nothing Then Continue For
            If delEmp(j) Is Tree Then Continue For
            delEmp(j).Expand() : i = 0
            '      If proj.UndoRedoNoWrite = False Then
            While i <= delEmp(j).Nodes.Count - 1
                If delEmp(j).Nodes(i).Tag = "EmptyIf" Or delEmp(j).Nodes(i).Tag = "EmptyCycle" And delEmp(j).Nodes.Count > 1 Then
                    delEmp(j).Nodes(i).Remove()
                End If
                i += 1
            End While
            '   End If
        Next
        ' ундо редо
        If bistro_UnRe = False Then proj.UndoRedo("Создать", "элемент дерева", GetCopyTree(TreeToArray(nodes), True))
        Return TreeToArray(nodes)
    End Function

    Function TreeToArray(ByVal node As TreeNode, Optional ByVal withSubNodes As Boolean = True) As TreeNode()
        Dim i, j As Integer, temp(), returs(node.Nodes.Count - 1) As TreeNode
        For i = 0 To node.Nodes.Count - 1
            returs(i) = node.Nodes(i)
            ' Если есть подНоды то их тоже добавить в массив
            If withSubNodes And node.Nodes(i).Nodes.Count > 0 And node.Nodes(i).Tag <> "Sobyt" Then
                temp = TreeToArray(node.Nodes(i))
                For j = 0 To temp.Length - 1
                    ReDim Preserve returs(returs.Length) : returs(returs.Length - 1) = temp(j)
                Next
            End If
        Next
        Return returs
    End Function
    Function TreeToArray(ByVal node() As Object, Optional ByVal withSubNodes As Boolean = True) As TreeNode()
        Dim i, j As Integer, temp(), returs(node.Length - 1) As TreeNode
        For i = 0 To node.Length - 1
            returs(i) = node(i)
            ' Если есть подНоды то их тоже добавить в массив
            If withSubNodes And node(i).Nodes.Count > 0 And node(i).Tag <> "Sobyt" Then
                temp = TreeToArray(node(i))
                For j = 0 To temp.Length - 1
                    ReDim Preserve returs(returs.Length) : returs(returs.Length - 1) = temp(j)
                Next
            End If
        Next
        Return returs
    End Function


    ' УДАЛЕНИЕ ОБЪЕКТА
    Public Sub DeleteObj(ByVal ParamArray MyObjs() As Object)
        Dim i, j, k As Integer, forma As Forms, addObjs() As Object  ', tempSelNode As TreeNode
        Dim HistoryDel As New ArrayList, toUndoRedo As String
        If MyObjs Is Nothing Then Exit Sub
        ' Сортировка, во избежании добавления сначала элементов, потом контенеров, сначала добавляются объекты имеющие вложенные эл-ты
        MyObjs = proj.GetSortMyObjsByLevelConteiner(MyObjs)
        For i = 0 To MyObjs.Length - 1

            ' НЕЗНАЮ ЗАЧЕМ ОНО БЫЛО, РАСКОМЕНТЬ ЕСЛИ ЗАГЛЮЧИЛО!!!
            ' If MyObjs(i).obj.parent Is Nothing Then Continue For

            ' Прогресс-форма
            ProgressForm.ProgressBarValue = (100 / (MyObjs.Length)) * i

            forma = MyObjs(i).GetMyForm(True)
            If forma Is Nothing Then Continue For
            forma.marker_vis(False)
            ' Создание текста для ундо редо
            If bistro_UnRe = False Then
                If proj.UndoRedoNoWrite = False Then toUndoRedo &= Perevodi.ToStrFromObj(MyObjs(i), True, , , False)
            End If

            ' Нужно удалять и все вложенные объекты
            MyObjs(i).vstavkaorcreate = False ' на всякий случай...
            addObjs = proj.GetDo4ernieMyObjs(MyObjs(i))
            HistoryDel.AddRange(addObjs)
            'ReDims(addObjs) : addObjs(addObjs.Length - 1) = MyObjs(i)
            For j = 0 To addObjs.Length - 1

                ' Если это контекстное меню, то удаление его упоминания в свойствах объектов
                If Iz.IsCM(addObjs(j)) Or Iz.IsMM(addObjs(j)) Then
                    Dim t As Integer
                    Dim frm As Forms = addObjs(j).GetMyForm
                    If frm IsNot Nothing Then
                        For t = 0 To frm.MyObjs.Length - 1
                            If Array.IndexOf(frm.MyObjs(t).PropertysUp, trans("Всплывающее меню").ToUpper) <> -1 Then
                                If UCase(frm.MyObjs(t).obj.props.ContextMenu) = UCase(addObjs(j).obj.name) Then
                                    frm.MyObjs(t).obj.props.ContextMenu = trans("Никакой")
                                End If
                            End If
                            If Array.IndexOf(frm.MyObjs(t).PropertysUp, trans("Главное меню").ToUpper) <> -1 Then
                                If UCase(frm.MyObjs(t).obj.props.MainMenuStrip) = UCase(addObjs(j).obj.name) Then
                                    frm.MyObjs(t).obj.props.MainMenuStrip = trans("Никакой")
                                End If
                            End If
                        Next
                    End If

                End If

                ' Удалить объект из формы
                If forma.MyObjs Is Nothing = False Then
                    DelDims(forma.MyObjs, Array.IndexOf(forma.MyObjs, addObjs(j)))
                End If
                If addObjs(j).obj.GetType.ToString = ClassAplication & "F" Then
                    TabControl1.TabPages.Remove(addObjs(j).tab)
                    DelDims(proj.f, Array.IndexOf(proj.f, addObjs(j)))
                End If


                ' Удаление УЗЛА
                If addObjs(j).GetNode Is Nothing = False Then
                    ' Удаление узла, если больше объектов с таким именем в проекте нет
                    Dim objs() As Object = proj.GetMyAllFromName(addObjs(j).obj.Props.name, , forma.obj.name)
                    If objs Is Nothing Then
                        addObjs(j).GetNode.Remove()
                        '    Else
                        '  If objs.Length <= 1 Then addObjs(j).GetNode.Remove()
                    End If
                End If

                ' Удалить все маркеры
                For k = 0 To addObjs(j).markers.Length - 1
                    If addObjs(j).markers(k) Is Nothing = False Then
                        addObjs(j).markers(k).Dispose()
                    End If
                Next
                If addObjs(j).hidemarker IsNot Nothing Then addObjs(j).hidemarker.Dispose()

                ' Удалить сам объект
                addObjs(j).obj.Dispose()

            Next
        Next
        ' Удалить объект из хисторилевел
        For i = 0 To HistoryDel.Count - 1
            forma = HistoryDel(i).GetMyForm(True)
            If forma Is Nothing = False Then forma.HistoryLevel.Remove(HistoryDel(i))
        Next
        proj.UndoRedo("Удалить", "объект", toUndoRedo)
        proj.ActiveForm.SetActiveObject(proj.ActiveForm)
        If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)
        If SelNode Is Nothing Then SelNode = Tree.SelectedNode : Tree.Focus()
    End Sub
    Public Sub DeleteTree(ByVal ignoreObj As Boolean, ByVal ParamArray TreeNodes() As Object)
        Dim fl As Boolean
        Dim nodes() As Object, i, j As Integer
        If TreeNodes Is Nothing Then
            nodes = getSelNods()
        Else
            nodes = TreeNodes
        End If
        If nodes Is Nothing Then Exit Sub
        ' Если удаляют объекты, то отправить в процедуру ОбъМеню
        If nodes(0).Level <= 1 And ignoreObj = False And nodes(0).tag <> "Comm" Then
            ' If proj.ActiveForm.ActiveObj Is Nothing Then proj.ActiveForm.AddActiveObject( proj.ActiveForm)
            'proj.ActiveForm.ActiveObj = GetMyObjsFromTreeNode(nodes(0))
            ObjsMenu.Tag = proj.ActiveForm.ActiveObj(0).obj
            DelMenu2_Click(Nothing, Nothing) : Exit Sub
        End If
        If bistro_UnRe = False Then proj.UndoRedo("Удалить", "элемент дерева", GetCopyTree(TreeToArray(nodes), True))
        'On Error Resume Next
        ' Получить отсортированный массив выделенных нодов и Упорядочить наоборот от большего уровня к меньшему
        nodes = GetSortSelNodes(nodes, True)
cycle:  For i = 0 To nodes.Length - 1
            If i > nodes.Length - 1 Then Exit For
            ' удалять, Если узел не содержит подузлов, а если содержит, то чтоб среди них не было выделенных
            If nodes(i).Nodes.Count = 0 Or fl = False Then ' Or (HaveSelNodes(nodes(i), nodes, i) = False And fl = False) Then
                ' все энд ифы , елсеифы удалит сам иф
                If (nodes(i).Tag = "EndIf" Or nodes(i).Tag = "EndWhile") And nodes.Length > 1 Then Continue For
                If nodes(i).Tag = "While" Then
                    If nodes(i).Parent Is Nothing = False Then
                        If nodes(i).Parent.Nodes.Count > nodes(i).Index + 1 Then
                            If nodes(i).Parent.Nodes(nodes(i).Index + 1) Is Nothing = False Then
                                If nodes(i).Parent.Nodes(nodes(i).Index + 1).Tag = "EndWhile" Then
                                    If Array.IndexOf(nodes, nodes(i).Parent.Nodes(nodes(i).Index + 1)) <> -1 Then
                                        nodes(Array.IndexOf(nodes, nodes(i).Parent.Nodes(nodes(i).Index + 1))).Remove()
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf nodes(i).Tag = "If" Then
                    j = 1
                    If nodes(i).Parent Is Nothing = False Then
                        While nodes(i).Index + 1 <= nodes(i).Parent.Nodes.Count - 1
                            If nodes(i).Parent.Nodes(nodes(i).Index + 1).Tag = "ElseIf" Or nodes(i).Parent.Nodes(nodes(i).Index + 1).Tag = "EndIf" Or nodes(i).Parent.Nodes(nodes(i).Index + 1).Tag = "Else" Then
                                If Array.IndexOf(nodes, nodes(i).Parent.Nodes(nodes(i).Index + 1)) <> -1 Then
                                    nodes(Array.IndexOf(nodes, nodes(i).Parent.Nodes(nodes(i).Index + 1))).Remove()
                                Else
                                    Exit While
                                End If
                            Else
                                Exit While
                            End If
                        End While
                    End If
                End If
                While (HaveSelNodesInt(nodes(i), nodes, i) <> -1 And fl = False)
                    DelDims(nodes, HaveSelNodesInt(nodes(i), nodes, i))
                End While
                ' удалить узел
                nodes(i).Remove()
            End If
        Next
        ' После прохода по циклу первый раз, не удалился иф, в котором были выделены все элементы, поэтому надо пройти два раза
        If fl = False Then fl = True : GoTo cycle
        SelNodes = Nothing : SelNode = Tree.SelectedNode : Tree.SelectedNode = SelNode ': TreeView1_AfterSelect(Nothing, Nothing)

    End Sub

#End Region

    ' <<<<<<<< ГЛАВНОГО МЕНЮ >>>>>>>>>
#Region "MAIN MENU"

    ' ФАЙЛ главного меню
    Private Sub NewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMenu.Click
        If Sohranilili() = False Then Exit Sub
        ' Создание програмы и проекта
        resetProj()
        ' Язык проекта
        If lang_def <> lang_name Then
            lang_name = lang_def : setLangs()
            ' Перезапись всех ключевых слов и функций
            CreateConstants() : CreateHelpWords()
        End If
        proj = New Project(trans("Проект"))
        proj.ActiveForm.proj = proj
        proj.ActiveForm.SetActiveObject(proj.ActiveForm)
        If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)
    End Sub
    Private Sub SaveMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMenu.Click
        If sender Is SaveMenu Then
            SaveProjInFile(proj.pPath & proj.pFileName)
        Else
            SaveProjInFile(proj.pPath & proj.pFileName, sender)
        End If
    End Sub
    Private Sub SaveAsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsMenu.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Path.GetExtension(SaveFileDialog1.FileName) = ".exe" Then
                Errors.MessangeInfo(transInfc("Чтобы создать exe-файл нажмите меню Файл -> Создать готовую программу"))
                Exit Sub
            End If

            If sender Is SaveAsMenu Then
                SaveProjInFile(SaveFileDialog1.FileName)
            Else
                SaveProjInFile(SaveFileDialog1.FileName, sender)
            End If
        End If
    End Sub
    Sub resetProj()
        proj.f = Nothing : proj.ActiveForm = Nothing : TabControl1.TabPages.Clear() : Tree.Nodes.Clear() : Breaks = Nothing
        proj.UndoAr = Nothing : proj.RedoAr = Nothing : proj.UndoRedoCount = 0
        UndoPanel.Enabled = False : UndoPanel.ToolTipText = "" : UndoMenu.Enabled = False : UndoMenu.ToolTipText = ""
        RedoPanel.Enabled = False : RedoPanel.ToolTipText = "" : RedoMenu.Enabled = False : RedoMenu.ToolTipText = ""
    End Sub
    Private Sub OpenMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMenu.Click
        ' Загрузка проекта
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Sohranilili() Then
                OpenProj(OpenFileDialog1.FileName)
            End If
        End If
    End Sub
    Sub SaveProjInFile(ByVal file As String, Optional ByVal code As String = "")
        ' Прогресс-Форма
        ProgressFormShow(transInfc("Сохранение") & "...")
        ' Сохранение в файл
        Dim fs As System.IO.StreamWriter
        ' запомнить объекты в их сейчашнем расположении в дереве
        '    ReSortMyObjs(Tree)
        ' если папки для файла не существует
        If System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(file)) = False Then
            SaveAsMenu_Click(code, Nothing) : Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        fs = System.IO.File.CreateText(file)
        fs.Write(GetCoding(, code)) : fs.Close()
        ' Задание переменных
        Pers(file)
        OpenFileDialog1.InitialDirectory = proj.pPath
        SaveFileDialog1.InitialDirectory = proj.pPath
        SaveFileDialog2.InitialDirectory = proj.pPath
        SaveFileDialog3.InitialDirectory = proj.pPath
        Me.Cursor = Cursors.Default
        tokaSohranil = True
        ' Меню последние проекты
        If RecentProjcts.IndexOf(file) <> -1 Then RecentProjcts.Remove(file)
        RecentProjcts.Insert(0, file)
        RecentProjectsCreate()
        SaveParametrs()
        ' Прогресс-Форма
        ProgressForm.Hide()
        SaveParametrs()
    End Sub
    Sub OpenProj(ByVal file As String)
        Dim code As String, ind As Integer
        Dim fs As System.IO.StreamReader
        ' Прогресс-Форма
        ProgressFormShow(transInfc("Открытие") & "...")
        ' открытие файла
        fs = System.IO.File.OpenText(file)
        code = fs.ReadToEnd : fs.Close()
        ' Задание переменных
        Pers(file)
        OpenFileDialog1.InitialDirectory = proj.pPath
        SaveFileDialog1.InitialDirectory = proj.pPath
        SaveFileDialog2.InitialDirectory = proj.pPath
        SaveFileDialog3.InitialDirectory = proj.pPath
        ' открытие
        resetProj()
        ' Собственно загрузка проекта
        CreateObjects(code, False, False, proj.f, Tree, Breaks, proj, True)
        If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)
        ' Меню последние проекты
        If RecentProjcts.IndexOf(file) <> -1 Then RecentProjcts.Remove(file)
        If IsHttpCompil = False Then
            RecentProjcts.Insert(0, file)
            RecentProjectsCreate()
        End If
        SaveParametrs()
        ' Прогресс-Форма
        ProgressForm.Hide()
        If proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
        If CreateDs.ShowObj IsNot Nothing Then CreateDs.ShowObj.objects_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    Sub Pers(ByVal file As String)
        proj.pPath = System.IO.Path.GetDirectoryName(file) & "\"
        proj.pFileName = System.IO.Path.GetFileName(file)
        proj.iPath = proj.pPath & ProjIpath & "\"
        Papks(LCase(trans("Папка проекта"))) = proj.pPath
        Papks(LCase(trans("Рисунки проекта"))) = proj.iPath
        Me.Text = proj.pPath & proj.pFileName & " - " & trans("АЛГОРИТМ 2")
    End Sub
    Public Sub BuildProgramMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuildMenu.Click
        Dim i As Integer, newDir As String

#If Full Or DebugFull Or Http Or DebugHttp Then
        If PerfomanceProgress() Then

            If IsHttpCompil = False Then
                If String.IsNullOrEmpty(proj.pIcon) Then
                    Dim result = MsgBox(transInfc("Создаваемому exe-файлу не назначена иконка. Желаете выбрать иконку в разделе Настройки проекта?") _
                           , MsgBoxStyle.Information + MsgBoxStyle.YesNo)

                    If result = MsgBoxResult.Yes Then
                        ProjectSettings_Click(Nothing, Nothing)
                        Exit Sub
                    End If
                End If

                ' Компилирования файлов в ту папку, которую укажут
                'SaveFileDialog2.InitialDirectory = proj.pPath
                SaveFileDialog2.FileName = proj.pFileName.Split(".")(0)
noAccess:
                If SaveFileDialog2.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                Try ' Проеверка файла на доступность 
                    System.IO.File.AppendAllText(SaveFileDialog2.FileName, "")
                Catch ex As Exception
                    Errors.FileNoAccess(ex.Message) : GoTo noAccess
                End Try
                newDir = IO.Path.GetDirectoryName(SaveFileDialog2.FileName)

                ' СБОРКА ПРОЕКТА - копирование всех нужных файлов (рисунков, библиотек) в папку проекта
                If Sborka(newDir) = False Then Exit Sub

                ' КОМПИЛЯЦИЯ ПРОЕКТА В КОМПИЛЯТОРЕ VBC.EXE
                ProgressFormShow(transInfc("Компиляция") & "...")
            Else
                newDir = CurDir()
                SaveFileDialog2.FileName = OutFile
            End If

            ' ГЕНЕРАЦИЯ КОДА ПРОГРАММЫ в синтаксисе vb.net и запись его в Code.vb Code2.vb
            Dim cod As String = Perevodi.ToStrCodeFromObj(proj.f)
            'Dim razdel As Integer = cod.IndexOf("Module CodeAlg2" & vbCrLf & vbCrLf)
            'Dim cod2 As String = cod.Substring(razdel)
            'cod = cod.Substring(0, razdel)
            IO.File.WriteAllText(CompilPath & "Code.vb", cod, Encoding.UTF8)
            'IO.File.WriteAllText(DataPath & "Compil\Code2.vb", cod2, Encoding.UTF8)

            ' расположение компилятора vbc
            Dim vbcPath As String = IO.Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.System)) & "\Microsoft.NET\Framework"
            Dim dirs() As String = IO.Directory.GetDirectories(vbcPath), lastVers As String = ""
            ' определение последней версии FrameWork'а
            For i = 0 To dirs.Length - 1
                Dim str As String = IO.Path.GetFileName(dirs(i))
                If str.IndexOf("v") = 0 And str.Length > 1 Then
                    If IsNumeric(str.Chars(1)) And Val(str.Chars(1)) = 2 Then
                        If lastVers < str.Substring(1) Then lastVers = str.Substring(1)
                    End If
                End If
            Next
            If lastVers <> "" Then vbcPath &= "\v" & lastVers & "\" Else Exit Sub
            Dim vbc As String = vbcPath & "vbc.exe"
            ' необходимые для компиляции библиотеки
            Dim references() As String = {"""" & ObjectsPath & "Interop.MSScriptControl.dll""" _
                                  , """" & ObjectsPath & "Kennedy.ManagedHooks.dll" & """" _
                                  , "System.dll", "System.Drawing.dll", "System.Data.dll", "System.XML.dll" _
                                  , "System.Windows.Forms.dll"}
            Dim reference As String = " /reference:" & Join(references, ",")
            ' импорты, использованные в алг
            Dim importy() As String = {"Microsoft.VisualBasic", "Microsoft.Win32", "System", "System.Collections" _
                                          , "System.Drawing", "System.Runtime.InteropServices", "System.Text" _
                                          , "System.Windows.Forms"}
            Dim import As String = " /imports:" & Join(importy, ",")

            ' иконка проекта
            Dim icoFl As String = Path.GetTempFileName(), icon As String = "" ' "C:\" & GetUIN(), icon As String = ""
            If (IsHttpCompil = False) Then
                If icoFl.IndexOf(" ") > 0 Then
                    MsgBox(trans("Имя пользователя windows содержит пробелы. Запустите компиляцию от пользователя с именем без пробелов, если хотите, чтобы у приложения была иконка."))
                Else
                    If File.Exists(GetMaxPath(proj.pIcon)) Then
                        File.Copy(GetMaxPath(proj.pIcon), icoFl, True)
                        icon = " /win32icon:" & icoFl
                    End If
                End If
            End If

            ' ресурсы
            ' reses.Add(" /res:""" & CompilPath & "ClientServer\ClientServer1.resx""")
            ' Dim res As String = "", sourcs, reses As New ArrayList
            ' If reses.Count > 0 Then res = Join(reses.ToArray(), "")
            ' прочие параметры, такие как непоказывать варнинги, создать вин32 приложение, главный модуль MainClass
            Dim othersParam As String = " /platform:x86 /nowarn /target:winexe /main:MainClass"
            ' выходной файл компиляции
            Dim out As String = " /out:""" & SaveFileDialog2.FileName & """"
            ' исходники для компиляции (все vb файлы папки)
            Dim sourc As String = " """ & CompilPath & "*.vb"""
            ' подключаем также в исходники объекты, хран-ся в папках
            Dim sourcs As ArrayList = ObjectsInPaths(proj.GetMyAllTypes())
            If sourcs.Count > 0 Then sourc &= Join(sourcs.ToArray(), "")

            ' СОБСТВЕННО ЗАПУСК КОМПИЛЯТОРА
            Dim args As String = reference & import & icon & othersParam & out & sourc
            Dim processprop As New System.Diagnostics.ProcessStartInfo()
            processprop.FileName = vbc
            processprop.Arguments = args
            processprop.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized
            processprop.UseShellExecute = False
            processprop.RedirectStandardOutput = True

            Dim process As Diagnostics.Process = Diagnostics.Process.Start(processprop)
            Dim compilOutput = process.StandardOutput.ReadToEnd()
            ' Ожидаем окончания компиляции
            process.WaitForExit()
            ' Пишем батник
            'Dim bat As String = vbcPath & "vbc.exe" & args '& vbCrLf & "cmd"
            'IO.File.WriteAllText(CompilBatFilePath, bat, Encoding.Default)
            ' Если произошла ошибка
            If process.ExitCode <> 0 Then
                ProgressForm.Hide()
                Dim Output As New OutputFrm
                ' Запускаем процесс, чтобы получить результат ошибки
                'Dim prOth As New PropertysOther(Nothing)
                'Dim s As String = prOth.RunWithResult(CompilBatFilePath, "", Encoding.GetEncoding(866).CodePage)
                Output.TextBox1.Text = compilOutput
                If IsHttpCompil = False Then
                    Output.Show()
                End If
                If IsHttpCompil Then
                    IO.File.Copy(ProjFile, IO.Path.GetDirectoryName(ProjFile) & "\ErrLog\" & uid_in & ".alg")
                    uid_out = "ErrorCompil" & vbCrLf & vbCrLf & Output.TextBox1.Text.Replace(CompilPath, "")
                End If
                If icon <> "" Then IO.File.Delete(icoFl)
                Exit Sub
            End If

            ' ЗАПИСЬ ЯЗЫКОВ В ФАЙЛ
            Dim langStr As String = IO.File.OpenText(LanguagePath & "\" & lang_name & "\" & lang_name & ".lng").ReadToEnd
            Dim langEngStr As String = IO.File.OpenText(LanguagePath & "\English\English.lng").ReadToEnd
            Try
                ' Запись в указанный файл кода программы и первоначальный размер файла
                Dim fo As System.IO.FileStream = System.IO.File.OpenRead(SaveFileDialog2.FileName)
                Dim size As String = fo.Length : fo.Close()
                size = size.PadLeft(15, "0")
                System.IO.File.AppendAllText(SaveFileDialog2.FileName, lang_name & "~~~" & langStr & "~~~" & langEngStr & "~~~" & "КОНЕЦ" & size, Encoding.UTF8)
                '            Errors.MessangeExclamen(ex.Message & ". " & vbCrLf & vbCrLf & trans("Для исправления ошибки скопируйте в папку с файлом который только что запустили библиотеки Kennedy.ManagedHooks.dll и SystemHookCore.dll. Они находятся в корне папки с Алгоритмом 2."))
            Catch ex As Exception
                Errors.FileNoAccess(ex.Message) : GoTo noAccess
            End Try

            If icon <> "" Then IO.File.Delete(icoFl)

            ProgressForm.Hide()
            If IsHttpCompil = False Then
                If MsgBox(transInfc("Поздравляем! Проект успешно скомпилирован в готовую программу и расположен по адресу") & ": " & vbCrLf & SaveFileDialog2.FileName & vbCrLf & vbCrLf & transInfc("Открыть папку с программой?"), MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Diagnostics.Process.Start(newDir & "\")
                End If
                '            If PerfomanceProgress() = False Then Dim dm As New Demo : dm.Show() : dm.Focus()
            End If
        Else
            Compile()
        End If
#Else
        Compile()
#End If
    End Sub
    Private Sub Compile()
#If Http Or DebugHttp Then
        MsgBox("Please register license of your Algorithm2")
#Else
        Try

            ' Если обычный режим, а не режим компитятора
            ProgressFormShow(transInfc("Компиляция") & "...")

            Dim code = GetCoding(True, "")
            Dim header = transInfc("Соединение") & "..."
            ProgressFormShow(header, 10)

            ' this is what we are sending
            Dim langPost = "ru"
            If (lang_name <> "Russian") Then
                langPost = "en"
            End If
            Dim post_data As String = "lang=" & langPost & "&proj=" & code

            ' create a request
            Dim request As HttpWebRequest = WebRequest.Create(recieveProjectUrl)
            request.KeepAlive = False
            request.ProtocolVersion = HttpVersion.Version10
            request.Method = "POST"

            ' turn our request string into a byte stream
            Dim postBytes As Byte() = Encoding.UTF8.GetBytes(post_data)

            ' this is important - make sure you specify type this way
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = postBytes.Length

            ' now send it
            Using requestStream As Stream = request.GetRequestStream()
                requestStream.Write(postBytes, 0, postBytes.Length)
            End Using

            ProgressFormShow(header, 80)

            ' and get response
            Dim uid_in As String = ""
            Using response As WebResponse = request.GetResponse()
                Using requestStream As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                    uid_in = requestStream.ReadToEnd()
                End Using
            End Using

            Dim errorResponse As String = "Error: "
            If uid_in.StartsWith(errorResponse) Then
                Dim errorText = uid_in.Substring(errorResponse.Length - 1)
                ProgressForm.Hide()
                MessangeCritic(errorText)
                Exit Sub
            End If

            ProgressFormShow(header, 90)

            Diagnostics.Process.Start(SiteAlg & "index.php/onlineCompile?Project=" & uid_in & GetEndingLink(True))

            ProgressForm.Hide()
        Catch ex As Exception
            ProgressForm.Hide()
            Errors.MessangeExclamen(transInfc("Невозможно соединиться с сервером компиляции. Попробуйте позже. Если ошибка повторится, обратитесь, пожалуйста, на support@algoritm2.ru. Подробности ошибки:") & vbCrLf & vbCrLf & ex.Message)
        End Try
#End If
    End Sub

    Public Sub ExportVBMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportVBMenu.Click
        Dim i As Integer

        ' Компилирования файлов в ту папку, которую укажут
        SaveFileDialog3.InitialDirectory = proj.pPath
        SaveFileDialog3.FileName = proj.pFileName.Split(".")(0)

        If SaveFileDialog3.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
        Dim newDir As String = IO.Path.GetDirectoryName(SaveFileDialog3.FileName)

        ' СБОРКА ПРОЕКТА - копирование всех нужных файлов (рисунков, библиотек) в папку проекта
        IO.Directory.CreateDirectory(newDir & "\bin\Debug\Languages")
        If Sborka(newDir & "\bin\Debug", True) = False Then Exit Sub
        IO.File.Copy(LanguagePath & lang_name & "\" & lang_name & ".lng", newDir & "\bin\Debug\Languages\" & lang_name & ".lng", True)
        IO.File.Copy(LanguagePath & "English\English.lng", newDir & "\bin\Debug\Languages\English.lng", True)

        ' ЭКСПОРТ
        ProgressFormShow(transInfc("Экспорт") & "...")

#If Full Or DebugFull Or Http Or DebugHttp Then
        If PerfomanceProgress() Then
            ' ГЕНЕРАЦИЯ КОДА ПРОГРАММЫ в синтаксисе vb.net и запись его в Code.vb Code2.vb
            Dim cod As String = Perevodi.ToStrCodeFromObj(proj.f)
            'Dim razdel As Integer = cod.IndexOf("Module CodeAlg2" & vbCrLf & vbCrLf)
            'Dim cod2 As String = cod.Substring(razdel)
            'cod = cod.Substring(0, razdel)
            IO.File.WriteAllText(CompilPath & "Code.vb", cod, Encoding.UTF8)
            'IO.File.WriteAllText(DataPath & "Compil\Code2.vb", cod2, Encoding.UTF8)

            ' КОПИРОВАНИЕ ПРОЕКТА
            Try
                Dim fls() As String = IO.Directory.GetFiles(CompilPath, "*.vb")
                For i = 0 To fls.Length - 1
                    System.IO.File.Copy(fls(i), (newDir & "\" & IO.Path.GetFileName(fls(i))).Replace("\\", "\"), True)
                Next
                Dim drs() As String = IO.Directory.GetDirectories(CompilPath)
                Dim fso = CreateObject("Scripting.FileSystemObject")
                For i = 0 To drs.Length - 1
                    fso.copyfolder(GetPathBezSlash(drs(i)), _
                        (newDir & "\" & IO.Path.GetFileName(drs(i))).Replace("\\", "\"), True)
                Next
                Dim pName As String = IO.Path.GetFileNameWithoutExtension(SaveFileDialog3.FileName)
                ' Копирование и изменение файла .vbproj
                ' очищаем pName от запрещенных символов
                i = 0
                While i < pName.Length
                    If Char.IsLetterOrDigit(pName(i)) = False And pName(i) <> " " Then
                        pName = pName.Remove(i, 1)
                    Else
                        i += 1
                    End If
                End While
                If pName = "" Then pName = "Project1"
                If Char.IsDigit(pName.Chars(0)) Then pName = "_" & pName
                Dim vbprojFileName As String = (newDir & "\" & pName & ".vbproj").Replace("\\", "\")
                System.IO.File.Copy(CompilPath & "Export.vbproj", vbprojFileName, True)
                pName = pName.Replace(" ", "_")
                Dim vbprojCode As String = IO.File.ReadAllText(vbprojFileName, Encoding.UTF8)
                vbprojCode = vbprojCode.Replace("<RootNamespace>Export</RootNamespace>", "<RootNamespace>" & pName & "</RootNamespace>")
                vbprojCode = vbprojCode.Replace("<AssemblyName>Export</AssemblyName>", "<AssemblyName>" & pName & "</AssemblyName>")
                vbprojCode = vbprojCode.Replace("<StartupObject>Export.MainClass</StartupObject>", "<StartupObject>" & pName & ".MainClass</StartupObject>")
                IO.File.WriteAllText(vbprojFileName, vbprojCode, Encoding.UTF8)
                ' Редактирование файла Main. Задание языка на котором делали алг проект.
                Dim vbMainFileName As String = (newDir & "\Main.vb").Replace("\\", "\")
                Dim vbMainCode As String = IO.File.ReadAllText(vbMainFileName, Encoding.UTF8)
                vbMainCode = vbMainCode.Replace("lang_name = ""Russian""", "lang_name = """ & lang_name & """")
                IO.File.WriteAllText(vbMainFileName, vbMainCode, Encoding.UTF8)
            Catch ex As Exception
                MessangeCritic(Errors.FileNotCreate(ex.Message)) : ProgressForm.Hide() : Exit Sub
            End Try
        Else
            Dim fls() As String = IO.Directory.GetFiles(ObjectsPath & "Demo\", "*")
            For i = 0 To fls.Length - 1
                System.IO.File.Copy(fls(i), (newDir & "\" & IO.Path.GetFileName(fls(i))).Replace("\\", "\"), True)
            Next
            Dim fls2() As String = IO.Directory.GetFiles(ObjectsPath & "Demo\My Project", "*")
            IO.Directory.CreateDirectory(newDir & "\My Project\")
            For i = 0 To fls2.Length - 1
                System.IO.File.Copy(fls2(i), (newDir & "\My Project\" & IO.Path.GetFileName(fls2(i))).Replace("\\", "\"), True)
            Next
        End If
#Else
            Dim fls() As String = IO.Directory.GetFiles(ObjectsPath & "Demo\", "*")
            For i = 0 To fls.Length - 1
                System.IO.File.Copy(fls(i), (newDir & "\" & IO.Path.GetFileName(fls(i))).Replace("\\", "\"), True)
            Next
            Dim fls2() As String = IO.Directory.GetFiles(ObjectsPath & "Demo\My Project", "*")
            IO.Directory.CreateDirectory(newDir & "\My Project\")
            For i = 0 To fls2.Length - 1
                System.IO.File.Copy(fls2(i), (newDir & "\My Project\" & IO.Path.GetFileName(fls2(i))).Replace("\\", "\"), True)
            Next
#End If


        ProgressForm.Hide()
        If MsgBox(transInfc("Поздравляем! Проект успешно экспортирован в VB.NET-проект и расположен по адресу") & ": " & vbCrLf & SaveFileDialog3.FileName & vbCrLf & vbCrLf & transInfc("Открыть папку с проектом?"), MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Diagnostics.Process.Start(newDir)
        End If
    End Sub
    Public Sub VisualStudioExpressMenuItem_Click(sender As Object, e As EventArgs) Handles VisualStudioExpressMenuItem.Click
        Diagnostics.Process.Start("https://www.google.com/search?q=visual+studio+express+desktop+download")
        Diagnostics.Process.Start("http://www.visualstudio.com/downloads/download-visual-studio-vs#d-express-windows-desktop")
    End Sub

    ' СБОРКА ПРОЕКТА - копирование всех нужных файлов (рисунков, библиотек) в папку проекта
    Function Sborka(ByVal newDir As String, Optional ByVal copyAllDlls As Boolean = False) As Boolean
        Dim i As Integer : newDir = newDir.Replace("\\", "\")
        ProgressFormShow(transInfc("Сборка") & "...")

        Try
            ' КОПИРОВАНИЕ РИСУНКИ 
            If IO.Directory.Exists(proj.iPath) Then
                Try
                    Dim fso = CreateObject("Scripting.FileSystemObject") 'Dim fso As new FileSystemObject 
                    If proj.iPath <> proj.pPath Then
                        fso.copyfolder(GetPathBezSlash(proj.iPath), (newDir & "\" & IO.Path.GetFileName(proj.iPath)).Replace("\\", "\"), True)
                    Else
                        fso.copyfolder(GetPathBezSlash(proj.iPath), newDir.Replace("\\", "\"), True)
                    End If
                Catch ex As Exception
                    MessangeCritic(Errors.FileNotCreate(ex.Message)) : ProgressForm.Hide() : Return False
                End Try
            End If
            ' КОПИРОВАТЬ БИБЛИОТЕКИ
            If copyAllDlls = False Then
                ' Получение алг-кода программы для определения, какие библиотеки нужно подключать
                Dim code As New CodeString(GetCoding(True), "None", False)
                ' Копирование библиотек ХУКОВ, если они нужны
                Dim HookMass() As String = {MyZnak & trans("Клавиша клавиатуры"), _
                        MyZnak & trans("Нажат альт"), MyZnak & trans("Нажат шифт"), _
                        MyZnak & trans("Нажат контрол"), MyZnak & trans("Нажата мыши левая"), _
                        MyZnak & trans("Нажата мыши правая"), MyZnak & trans("Вращается колесико")}
                For i = 0 To HookMass.Length - 1
                    If code.IndexOf(HookMass(i)) <> -1 Then i = -1 : Exit For
                Next
                If i = -1 Then ' Если нашлось свойство которому нужна библиотека
                    System.IO.File.Copy(DllKenMan, (newDir & "\" & IO.Path.GetFileName(DllKenMan)).Replace("\\", "\"), True)
                    System.IO.File.Copy(DllCoreHook, (newDir & "\" & IO.Path.GetFileName(DllCoreHook)).Replace("\\", "\"), True)
                End If
                ' Копирование библиотеки VBSCRIPT, если она нужна
                Dim VBsMass() As String = {MyZnak & trans("Выполнить код VBScript")}
                For i = 0 To VBsMass.Length - 1
                    If code.IndexOf(VBsMass(i)) <> -1 Then i = -1 : Exit For
                Next
                If i = -1 Then ' Если нашлось свойство которому нужна библиотека
                    System.IO.File.Copy(DllVBScript, (newDir & "\" & IO.Path.GetFileName(DllVBScript)).Replace("\\", "\"), True)
                End If
            Else
                System.IO.File.Copy(DllVBScript, (newDir & "\" & IO.Path.GetFileName(DllVBScript)).Replace("\\", "\"), True)
                System.IO.File.Copy(DllCoreHook, (newDir & "\" & IO.Path.GetFileName(DllCoreHook)).Replace("\\", "\"), True)
                System.IO.File.Copy(DllKenMan, (newDir & "\" & IO.Path.GetFileName(DllKenMan)).Replace("\\", "\"), True)
            End If
        Catch ex As Exception
            Errors.MessangeCritic(ex.Message) : ProgressForm.Hide() : Return False
        End Try
        ProgressForm.Hide()
        Return True
    End Function
    Private Sub RecentProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.tag Is Nothing Then Exit Sub
        If IO.File.Exists(sender.tag) = False Then
            MsgBox(ProjNotFound(sender.tag)) : RecentProjectsCreate() : Exit Sub
        End If
        If Sohranilili() Then OpenProj(sender.tag)
    End Sub
    Private Sub ExitMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitMenu2.Click
        Me.Hide() ' чтобы HookStops не тормозил закрытие
        HookStops() ' Вырубить весь хук клавиш и мыши
        Me.Dispose()
    End Sub
    ' Выдать запрос на сохранение файла и вернуть уже результат
    Function Sohranilili() As Boolean
        If isRUN() Then
            Dim res As MsgBoxResult = MsgBox(transInfc("Проект сейчас запущен, для продолжения его надо прервать. Остановить проект?"), MsgBoxStyle.Question + MsgBoxStyle.OkCancel, trans("АЛГОРИТМ 2"))
            If res = MsgBoxResult.Cancel Then Return False Else StopMenu_Click(Nothing, Nothing)
        End If
        If tokaSohranil Then Return True
        If proj.UndoAr Is Nothing = False Then
            If proj.UndoRedoCount <> proj.UndoAr.Length Then
                Dim res As MsgBoxResult = MsgBox(transInfc("Сохранить изменения перед закрытием данного проекта?"), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, trans("АЛГОРИТМ 2"))
                If res = MsgBoxResult.Yes Then
                    SaveMenu_Click(Nothing, Nothing)
                ElseIf res = MsgBoxResult.Cancel Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    ' Выдать запрос на сохранение файла и вернуть уже результат
    Function Ostanovili() As Boolean
        If isRUNorPause() = True Then
            Dim res As MsgBoxResult = MsgBox(transInfc("Проект запущен. Остановить выполнение проекта?"), MsgBoxStyle.Question + MsgBoxStyle.OkCancel, trans("АЛГОРИТМ 2"))
            If res = MsgBoxResult.Ok Then
                StopMenu_Click(Nothing, Nothing)
            ElseIf res = MsgBoxResult.Cancel Then
                Return False
            End If
        End If
        Return True
    End Function

    ' ПРАВКА главного меню
    Private Sub CopyMenu4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMenu4.Click
        If Tree.Focused Then
            CopyMenu_Click(Nothing, Nothing)
        ElseIf Peremeschatel.Focused Then
            CopyMenu2_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub CutMenu4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutMenu4.Click
        If Tree.Focused Then
            CutMenu_Click(Nothing, Nothing)
        ElseIf Peremeschatel.Focused Then
            CutMenu2_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub PasteMenu4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteMenu4.Click
        If Tree.Focused Then
            PasteMenu_Click(Nothing, Nothing)
        Else 'If Peremeschatel.Focused Then
            PasteMenu2_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub DelMenu4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelMenu4.Click
        If Tree.Focused Then
            DelMenu_Click(Nothing, Nothing)
        ElseIf Peremeschatel.Focused Then
            DelMenu2_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub SelectAllMenu4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllMenu4.Click
        If Tree.Focused Then
            SelectAllMenu_Click(Nothing, Nothing)
        ElseIf Peremeschatel.Focused Then
            SelectAllMenu2_Click(Nothing, Nothing)
        End If
    End Sub

    Function Parser() As Boolean
        Dim i, j As Integer, nms() As String = {}
        For i = 0 To proj.f.Length - 1
            For j = 0 To proj.f(i).MyObjs.Length - 1
                ReDims(nms)
                ' Проверяем, чтобы не было объектов, с одинаковыми именами
                If Array.IndexOf(nms, GetCompilName(proj.f(i).MyObjs(j)).ToUpper) <> -1 Then
                    MsgBox(ExistUniqName(proj.f(i).MyObjs(j).obj.name, proj.f(i).MyObjs(j).obj.props.index), MsgBoxStyle.Exclamation)
                    Return False
                End If
                nms(nms.Length - 1) = GetCompilName(proj.f(i).MyObjs(j)).ToUpper
                ' Проверяем, чтобы все ифы елсеифы елсы и енд ифы были правильно расположены
                Dim errIF As String = ParseIf(proj.f(i).MyObjs(j).GetNode())
                If errIF <> "" Then MsgBox(errIF, MsgBoxStyle.Exclamation) : Return False
            Next
        Next



        Return True
    End Function

    Function ParseIf(ByVal node As TreeNode) As String
        If node Is Nothing Then Return ""

        Dim i As Integer, errIf As String
        Dim ozhidaem() As String = {"If"}
        For i = 0 To node.Nodes.Count - 1
            If Iz.IsIfs(node.Nodes(i)) Then
                ' Если в данной ветке косяк выдаем ошибку, если что не так расположено. 
                If Array.IndexOf(ozhidaem, node.Nodes(i).Tag) = -1 Then
                    Return Errors.ParseIfError(node.Nodes(i).FullPath, Join(transArray(ozhidaem, True), """, """))
                End If
            End If
            ' если все ок, делаем новое ожидание
            If node.Nodes(i).Tag = "If" Or node.Nodes(i).Tag = "ElseIf" Then
                ozhidaem = New String() {"ElseIf", "Else", "EndIf"}
            ElseIf node.Nodes(i).Tag = "Else" Then
                ozhidaem = New String() {"EndIf"}
            ElseIf node.Nodes(i).Tag = "EndIf" Then
                ozhidaem = New String() {"If"}
            End If
            ' Смотрим дальше во внутренних ветках
            errIf = ParseIf(node.Nodes(i)) : If errIf <> "" Then Return errIf
        Next
        ' выдаем ошибку, если иф елсеиф или элсе так и не закрыли
        If Array.IndexOf(ozhidaem, "If") = -1 Then
            Return Errors.ParseIfError(node.Nodes(i - 1).FullPath, Join(transArray(ozhidaem, True), """, """))
        End If
        Return ""
    End Function

    ' ПРОЕКТ меню
    Private Sub RunMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunMenu.Click
        If RunPanel.Enabled = False Then RunProj.GotFoc = True : Exit Sub
        If RunProj Is Nothing Then
            ' Прогресс-Форма
            ProgressFormShow(transInfc("Компиляция") & "...")

            If Parser() = False Then ProgressForm.Hide() : Exit Sub

            Dim code As String = "", i As Integer
            code = "Language = " & lang_name & vbCrLf
            For i = 0 To proj.f.Length - 2
                If RunFormDropPanel.Checked Then
                    If proj.f(i) Is proj.ActiveForm = False Then Continue For
                End If
                code &= Perevodi.ToStrFromObj(proj.f(i), True, , True)
            Next
            ' Прогресс-Форма
            ProgressForm.Hide()

            RunProj = New RunProject(Tree, code) '    RunProj = New RunProject(code )
            RunProj.pPath = proj.pPath
            RunProj.iPath = proj.iPath
            RunProj.iPathShort = proj.iPathShort
            RunProj.pFileName = proj.pFileName
            RunProj.pIcon = proj.pIcon
            RunProj.pProgressForm = proj.pProgressForm
            RunProj.isONLYFORM = RunFormDropPanel.Checked
            If sender Is StepIntoMenu Then RunProj.isSTEP = True
            ' События run проекта
            AddHandler RunProj.NodeStop, AddressOf RunProj_NodeStop
            AddHandler RunProj.StopRun, AddressOf RunProj_StopRun

            ' ГЛАВНАЯ ПЕРЕМЕННАЯ, ОБОЗНАЧАЮЩАЯ ВЫПОЛНЯТЬ В ОТДЕЛЬНОМ ПОТОКЕ ИЛИ НЕТ
            RunProj.isPotok = True

            If RunProj.isPotok Then
                ' Запуск проекта
                runProc = New Threading.Thread(AddressOf RunProj.Run)
                runProc.Priority = Threading.ThreadPriority.AboveNormal
                runProc.SetApartmentState(Threading.ApartmentState.STA)
                If sender Is StepOverMenu Then RunProj.newStepOver = True
                If sender Is StepOutMenu Then RunProj.newStepOut = True
                runProc.Start()
            Else
                RunProj.Run()
            End If

            ' Сохранение проекта, если такой тип запуска
            If RunSaveDropPanel.Checked Then SaveMenu_Click(code, Nothing)
        Else
            If RunProj.isRUN = False Then
                TreePaint(ColKode)
                If sender Is StepIntoMenu Then RunProj.isSTEP = True Else RunProj.isSTEP = False
                ' If (RunProj.isSTEP = False Or debugNode Is Nothing = False) And (RunProj.Pause = False Or debugNode Is Nothing = False) Then
                '  If RunProj.isSTEP = False And debugNode Is Nothing = False And RunProj.Pause = False Then
                If debugNode Is Nothing = False Then
                    ' If debugNode Is Nothing Then Exit Sub
                    If debugNode.TreeView Is Nothing Then debugNode = SelNode
                    If debugNode Is Nothing Then Exit Sub
                    If debugNode.Tag = "Sobyt" Or debugNode.Tag = "Obj" Or debugNode.Tag = "Comm" Then
                        Errors.MessangeCritic(Errors.notRunNode(debugNode.Text)) : Exit Sub
                    End If
                End If
                Dim tmp As TreeNode = debugNode
                debugNode = Nothing : TreePaint(ColKode)
                If RunProj.isPotok Then
                    If tmp Is Nothing = False Then
                        RunProj.newParent = tmp.Parent
                        RunProj.newIndex = tmp.Index
                        RunProj.newParam = param
                        If sender Is StepOverMenu Then RunProj.newStepOver = True Else RunProj.newStepOver = False
                        If sender Is StepOutMenu Then RunProj.newStepOut = True Else RunProj.newStepOut = False
                    Else
                        RunProj.newParent = Nothing
                        RunProj.newIndex = Nothing
                        RunProj.newParam = Nothing
                        RunProj.newStepOver = False
                        RunProj.newStepOut = False
                    End If
                    RunProj.isRUN = True
                    ' Пауза говорит о том что нажали вручную паузу на панели
                    RunProj.Pause = False : RunProj.CallRunBlock = True
                Else
                    RunProj.isRUN = True
                    RunProj.RunBlock(tmp.Parent, tmp.Index, param, True)
                    If RunProj.isSTEP = False And isRUN() Then
                        RunProj.GotFocus()
                        param.MyObj.obj.focus()
                    End If
                End If
            End If
        End If
        'If isRUN() Then
        Enableds(False, True, True, False, False)
    End Sub
    Private Sub PauseMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseMenu.Click
        If RunProj Is Nothing Then Exit Sub
        ' если нажали на настоящую паузу
        If sender Is Nothing = False And RunProj.isPotok Then
            RunProj.Pause = True
        End If
        Output.Text = ""

        SplitOutputRun.Panel2Collapsed = False
        Enableds(True, False, True, True, True)
        Tree.Focus()
    End Sub
    Public Sub StopMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopMenu.Click
        ' Выставить флаг чтобы поток вызвал функцию CloseAll т.к. нельзя работать с объектами созданными не в этом потоке
        If RunProj Is Nothing Then GoTo enabli
        If RunProj.isPotok Then
            RunProj.ClosAl = True
        Else
            RunProj.CloseAll()
        End If
        HookStops()
        RunProj = Nothing
        ' Если функцию вызвал поток
enabli: If Me.InvokeRequired Then
            Me.Invoke(delegatEnableds, New Object() {True, False, False, True, False})
        Else
            Enableds(True, False, False, True, False)
        End If
    End Sub
    Private Sub StepIntoMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepIntoMenu.Click
        RunMenu_Click(StepIntoMenu, Nothing) ' т.к. sender то запустится пошагово
        If RunProj.isRUN Then Enableds(True, True, True, False, False)
    End Sub
    Private Sub StepOverMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepOverMenu.Click
        RunMenu_Click(StepOverMenu, Nothing) ' т.к. sender то запустится пошагово
        If RunProj.isRUN Then Enableds(True, True, True, False, False)
    End Sub
    Private Sub StepOutMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepOutMenu.Click
        RunMenu_Click(StepOutMenu, Nothing) ' т.к. sender то запустится пошагово
        If RunProj.isRUN Then Enableds(True, True, True, False, False)
    End Sub
    Sub Enableds(ByVal rn As Boolean, ByVal ps As Boolean, ByVal so As Boolean, ByVal sin As Boolean, ByVal sout As Boolean)
        RunMenu.Enabled = True : RunPanel.Enabled = rn
        PauseMenu.Enabled = ps : PausePanel.Enabled = ps
        StopMenu.Enabled = so : StopPanel.Enabled = so
        StepIntoMenu.Enabled = sin : StepIntoPanel.Enabled = sin
        StepOverMenu.Enabled = sin : StepOverPanel.Enabled = sin
        StepOutMenu.Enabled = sout : StepOutPanel.Enabled = sout
        If so = False Then SplitOutputRun.Panel2Collapsed = True : SplitOutputRun.Height += 1 : SplitOutputRun.Height -= 1
    End Sub

    ' ИНСТРУМЕНТЫ меню
    Private Sub Tools_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tools.DropDownOpening
        Dim eventMenuItem As ToolStripMenuItem, i As Integer
        TraslateProjMenu.DropDownItems.Clear()
        Dim dirs() As String = IO.Directory.GetDirectories(LanguagePath)
        ' Генерация списка языков и создание пунктов меню под них
        For i = 0 To dirs.Length - 1
            eventMenuItem = TraslateProjMenu.DropDownItems.Add(transInfc(trans(IO.Path.GetFileName(dirs(i)), , True)))
            eventMenuItem.Checked = (IO.Path.GetFileName(dirs(i)).ToUpper = lang_name.ToUpper)
            AddHandler eventMenuItem.Click, AddressOf TranslateProj_Click
        Next
    End Sub
    Private Sub TranslateProj_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Кликнули на пункт меню с языком программирования
        If sender.checked Or proj.f.Length <= 1 Then Exit Sub
        ' If MsgBox(transInfc("Внимание! Данная функция переводит только свойства объектов, значения свойств, события и некоторые ветки дерева программы. И не переводит основную часть программного кода дерева программы, ее вам следует переводить уже самостоятельно. Настоятельно рекомендуется сделать сначала резервную копию проекта. Все равно продолжить?"), MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ProgressFormShow(transInfc("Перевод"))
        isTranslate = True

        ' задание нового языка программирования, старый острается храниться в old'ах
        lang_name = trans(sender.text, True) : setLangs(False)
        ' Перезапись всех ключевых слов и функций
        CreatePoleznie() : CreateArrays() : CreateConstants() : CreateHelpWords()
        proj.f(proj.f.Length - 1).obj.name = MyZnak & trans("Полезные объекты")
        proj.f(proj.f.Length - 1).MyObjs = PoleznieObjs
        CreateDs.SetProperty(True)

        ' Перевод всех объектов и их веток дерева
        transObjects()
        ProgressForm.ProgressBarValue = 100
        ' Возврат переменных языка к обычному состоянию равенства
        lang_name_old = lang_name : langOld = lang : langLwOld = langLw

        isTranslate = False
        proj.ActiveForm.FillListView() : ProgressForm.Hide()
    End Sub
    Private Sub Options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsMenu.Click
        OptionsForm.Show()
    End Sub

    ' ПОМОЩЬ меню
    Private Sub AnswersMenu_Click(sender As Object, e As EventArgs) Handles AnswersMenu.Click
        Try
            Diagnostics.Process.Start(SiteAlg & answersAlgPath & GetEndingLink(False))
        Catch ex As Exception : MsgBox(ex.Message) : End Try
    End Sub
    Private Sub HelpMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpMenu.Click
        Try
            Diagnostics.Process.Start("iexplore.exe", HelpPath & "\index.html")
        Catch ex As Exception : MsgBox(ex.Message) : End Try
    End Sub
    Public Sub LessonsFirstMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LessonsFirstMenu.Click
        Try
            Diagnostics.Process.Start("iexplore.exe", LessonsPath & "Lesson1.htm")
        Catch ex As Exception : MsgBox(ex.Message) : End Try
    End Sub
    Public Sub LessonsOthersMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LessonsOthersMenu.Click
        Try
            Diagnostics.Process.Start(SiteAlg & lessonsAlgPath & GetEndingLink(False))
        Catch ex As Exception : MsgBox(ex.Message) : End Try
    End Sub
    Public Sub SamplesBaseMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SamplesBaseMenu.Click
        If IO.Directory.Exists(SamplesPath) Then
            Try
                Diagnostics.Process.Start(SamplesPath)
            Catch ex As Exception : MsgBox(ex.Message) : End Try
        ElseIf IO.Directory.Exists(SamplesPath) Then
            Try
                Diagnostics.Process.Start(SamplesPath)
            Catch ex As Exception : MsgBox(ex.Message) : End Try
        End If
    End Sub
    Public Sub SamplesOthersMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SamplesOthersMenu.Click
        Try
            Diagnostics.Process.Start(SiteAlg & samplesAlgPath & GetEndingLink(False))
        Catch ex As Exception : MsgBox(ex.Message) : End Try
    End Sub
    Private Sub UpdateMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateMenu.Click
        Try
            If CheckNewVersion(True) = False Then
                Errors.MessangeInfo(transInfc("У вас последняя версия программы"))
            End If
        Catch ex As Exception
            Errors.MessangeExclamen(ex.Message)
        End Try
    End Sub
    Private Sub RegistrMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrMenu.Click
        Dim dm As New Demo : dm.Show()
    End Sub
    Private Sub AboutMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutMenu.Click
        Dim ab As New About : ab.Show()
    End Sub

    ' Контекстное меню EditMiniMenu
    Private Sub UndoMenu6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoMenu6.Click
        EditMiniMenu.Tag.Undo()
    End Sub
    Private Sub RedoMenu6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoMenu6.Click
        EditMiniMenu.Tag.Redo()
    End Sub
    Private Sub CutMenu6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutMenu6.Click
        EditMiniMenu.Tag.Cut()
    End Sub
    Private Sub CopyMenu6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMenu6.Click
        EditMiniMenu.Tag.Copy()
    End Sub
    Private Sub PasteMenu6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteMenu6.Click
        EditMiniMenu.Tag.Paste()
    End Sub
    Private Sub DelMenu6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelMenu6.Click
        EditMiniMenu.Tag.SelectedText = ""
    End Sub
    Private Sub SelectAllMenu6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllMenu6.Click
        EditMiniMenu.Tag.SelectAll()
    End Sub
    Private Sub Output_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Output.GotFocus
        EditMiniMenu.Tag = sender
    End Sub
    Private Sub EditMiniMenu_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EditMiniMenu.Opening
        EditMiniMenu.Tag = EditMiniMenu.SourceControl
    End Sub

#End Region

    ' <<<<<< СОБЫТИЯ RUN ПРОЕКТА >>>>>>>
#Region "RUN EVENTS"
    Dim outTxt As String = ""
    Public Sub RunProj_NodeStop(ByVal objs As Object)
        RunProj_NodeStop(objs(0), objs(1))
    End Sub
    Public sem As Boolean = False
    Sub RunProj_NodeStop(ByVal node As TreeNode, ByVal param As PropertysSobyt)
        Static bylInvoke As Boolean = False
        If RunProj Is Nothing Then Exit Sub
        ' Если функция вызвалась из неродного потока то вызвать эту же фукцию через потоконезависимый Invoke
        If Me.InvokeRequired() Then
            ' флаг чтобы фунция OutputRun выполнялась не в Invoke а здесь чуть ниже
            bylInvoke = True
            ' Сохранение результатов OutputRun в outTxt
            Dim codeSt As New CodeString(node.Text, , False)
            If sem Then Exit Sub
            sem = True
            outTxt = OutputRun(node.Tag, codeSt.Split("naOdnomUrovne").texty, param)
            If Output.InvokeRequired = False Then Output.Text = outTxt
            sem = False
            ' Собственно выполнение RunProj_NodeStop через потоконезависимый Invoke
            Try
                Me.Invoke(delegatNodeStop, New Object() {node, param})
            Catch ex As Exception
            End Try
            ' Обнулить флаг, объявленный как Static
            bylInvoke = False
            Exit Sub
        End If
        SelNodes = Nothing
        SelNode = proj.GetNode(node)
        Tree.SelectedNode = SelNode
        debugNode = node
        param.bylBreakpoint = debugNode
        Me.param = param
        PauseMenu_Click(Nothing, Nothing)
        ' Если сейчас не поток
        If bylInvoke = False Then
            If SelNode Is Nothing Then Exit Sub
            Dim codeS As New CodeString(EditNodeText.Text)
            If Output.InvokeRequired = False Then Output.Text = OutputRun(SelNode.Tag, codeS.Split("naOdnomUrovne").texty, param)
        Else ' Если пришли с потока, то есть готовый outTxt
            Tree.SelectedNode = node : SelNode = node
            Output.Text = outTxt
        End If
        Me.Activate() : Output.Focus() : Tree.Focus() : TreePaint(ColKode)
    End Sub



    Sub RunProj_StopRun()
        StopMenu_Click(Nothing, Nothing)
    End Sub
    Private Sub SelectedText(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If RunProj Is Nothing = False And SelNode Is Nothing = False Then
            If RunProj.isRUN = False Then
                Dim txt As String = sender.selectedtext
                If bistro_orfo = False Then txt = New CodeString(sender.selectedtext).Text
                Output.Text = OutputRun(SelNode.Tag, New String() {txt}, param)
            End If
        End If
    End Sub

#End Region

    ' <<<<<< СПРАВОЧНАЯ ИНФОРМАЦИЯ >>>>>>>
#Region "HELP"
    ' ВЫВОДИТ В СТАТУСНУЮ СТРОКУ ФОРМЫ ИНФОРМАЦИЮ О НАВЕДЕННОМ МЫШКОЙ ОБЪЕКТЕ
    Private Sub HelpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpTimer.Tick
        If bistro_StatusLine Then Exit Sub
        Dim i = 0, j = 0, prioritet As Integer = Integer.MaxValue, hlp As String = "", bound As Rectangle
        For i = 0 To 28
            If i > HelpObjs.Length - 1 Then Exit For
            If HelpObjs(i) Is Nothing Then Exit For
            Dim p As New Point(MousePosition)
            If HelpObjs(i).InvokeRequired Then Exit Sub
            If HelpObjs(i).visible = False Or HelpObjs(i).parent Is Nothing Then Continue For
            ' If HelpObjs(i).TopLevelControl Is Nothing Then HelpObjs(i) = Nothing
            bound = New Rectangle(HelpObjs(i).PointToScreen(New Point(0, 0)), HelpObjs(i).size)
            If bound.Contains(MousePosition) Then
                If prioritet <= HelpObjs(i).height * HelpObjs(i).width Then
                    Continue For
                Else
                    prioritet = HelpObjs(i).height * HelpObjs(i).width
                End If
                If UCase(HelpObjs(i).name).ToString.IndexOf(UCase("Palka")) = 0 Then
                    hlp = InfoElems("Palka")
                ElseIf UCase(HelpObjs(i).name).ToString.IndexOf(UCase("Help")) = 0 Then
                    hlp = InfoElems("Help")
                Else
                    hlp = InfoElems(HelpObjs(i).name)
                End If
                ' взначит возможно это объект
                If hlp = "" Then
                    If HelpObjs(i).GetType.ToString.Split(".")(0) & "." = ClassAplication Then
                        hlp = InfoObjs(trans(HelpObjs(i).props.type, True))
                    End If
                End If
            End If
        Next
        StatusLabel1.Text = hlp
    End Sub
    Sub HelpDelete(ByVal obj As Object)
        Dim ind, j As Integer
        ind = Array.IndexOf(HelpObjs, obj)
        If ind <> -1 Then
            For j = ind To HelpObjs.Length - 2
                HelpObjs(j) = HelpObjs(j + 1)
            Next
            ReDim Preserve HelpObjs(HelpObjs.Length - 2)
        End If
    End Sub

    ' ОТОБРАЖАЮТ ИНФОРМАЦИЮ О СВОЙСТВЕ В lLabel
    Public Sub InfoPropsShow(ByVal prop As String, ByVal MyObj As Object, Optional ByVal lLabel As Windows.Forms.LinkLabel = Nothing)
        Dim prp As String = prop
        If prop = "" Then Exit Sub
        If lLabel Is Nothing Then lLabel = InfoPropsLabel
        If InfoProps(LCase(prop)) = "" Then prop = prop.Substring(MyZnak.Length)
        lLabel.Text = "<" & prp & ">" & vbCrLf & InfoProps(LCase(prop)) & " "
        If lLabel.Links.Count > 0 Then lLabel.Links(0).Length = 0
        If InfoProps(LCase(prop)) <> "" Then
            If lLabel.Links.Count = 0 Then lLabel.Links.Add(0, 0)
            lLabel.Links(0).Start = lLabel.Text.Length
            lLabel.Text &= trans("Подробнее") & "."
            lLabel.Links(0).Length = 100
            lLabel.Links(0).LinkData = MyObj
            lLabel.Links(0).Name = prop
            lLabel.Links(0).Tag = "PropEvent"
        End If
    End Sub
    Public Sub InfoArgsShow(ByVal arg As String, ByVal MyObj As Object, ByVal prop As String, Optional ByVal lLabel As Windows.Forms.LinkLabel = Nothing)
        If lLabel Is Nothing Then lLabel = InfoPropsLabel
        InfoPropsShow(arg, MyObj, lLabel)
        If lLabel.Links.Count > 0 Then
            lLabel.Links(0).Name = prop
            lLabel.Links(0).Tag = "Args"
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If proj.ActiveForm Is Nothing = False Then
            If proj.ActiveForm.ActiveObj Is Nothing = False Then
                InfoPropsShow(ComboBox1.SelectedItem, proj.ActiveForm.ActiveObj(0))
            End If
        End If
    End Sub
    ' КЛИК ПО ССЫЛКЕ "ПОДРОБНЕЕ", ССЫЛАЮЩЕЙСЯ НА СПРАВКУ
    Public Sub InfoPropsLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles InfoPropsLabel.LinkClicked
        Dim MyObj As Object = e.Link.LinkData
        If MyObj Is Nothing = False Then
            If IsArray(MyObj) Then MyObj = MyObj(0)
            Dim ob, tip, cat, propEven As String
            propEven = trans(e.Link.Name, True)
            tip = trans(MyObj.obj.props.type, True)
            If MyObj.obj.name.ToString.IndexOf(MyZnak) = 0 Then
                ob = "UsefulObjects"
                cat = "PropertiesCommands"
                If UCase(MyObj.obj.name) = UCase(MyZnak & trans("Объект события")) Then
                    tip = MyZnak & trans("Объект события", True)
                ElseIf UCase(MyObj.obj.name) = UCase(MyZnak & trans("Окно события")) Then
                    tip = MyZnak & trans("Окно события", True)
                ElseIf UCase(MyObj.obj.name).IndexOf(UCase(MyZnak & trans("Хозяин "))) = 0 Then
                    tip = MyZnak & trans("Хозяин меню", True)
                Else
                    If propEven.IndexOf(MyZnak) <> 0 Then propEven = MyZnak & propEven
                End If
                If tip.IndexOf(MyZnak) <> 0 Then tip = MyZnak & tip
            Else
                ob = "Objects"
                If Array.IndexOf(MyObj.SobytsUp, UCase(e.Link.Name)) = -1 Then
                    cat = "PropertiesCommands"
                Else
                    cat = "Events"
                End If
            End If

            Dim link As String = HelpPath & "\" & ob & "\" & tip & "\" & cat & "\" & propEven & ".html"
            If IO.File.Exists(link) Then
                Try
                    Diagnostics.Process.Start(link)
                Catch ex As Exception : MsgBox(ex.Message) : End Try
            End If
        Else
            If e.Link.Name = "Master" Then
                Dim link As String = HelpPath & "\Environment\Master.html"
                If IO.File.Exists(link) Then
                    Try
                        Diagnostics.Process.Start(link)
                    Catch ex As Exception : MsgBox(ex.Message) : End Try
                End If
            End If
        End If
    End Sub
    ' Получить по строке объекта (может быть только имя или "полезные объекты") ссылку на справку
    Public Function GetHelpLink(ByVal objStr As String) As String
        Dim mass() As String = objStr.Split(".")
        If mass.Length = 1 Then
            If UCase(mass(0)) = UCase(MyZnak & trans("Полезные объекты")) Then
                Return "UsefulObjects"
            ElseIf UCase(mass(0)) = UCase("Master") Then
                Return "Environment\Master"
            ElseIf UCase(mass(0)) = MyZnak & UCase("Объект события") _
            Or UCase(mass(0)) = MyZnak & UCase("Окно события") _
            Or UCase(mass(0)) = MyZnak & UCase("Хозяин меню") Then
                Return "UsefulObjects\" & trans(mass(0), True)
            Else
                Dim forma As Object = proj.GetMyAllFromName(mass(0))
                If forma Is Nothing = False Then
                    Return "Objects/" & trans(forma(0).obj.props.type, True)
                Else
                    Return ""
                End If
            End If
        ElseIf mass.Length = 3 Then
            Dim frm As String = mass(0)
            Dim obj As String = mass(1)
            Dim prp As String = mass(2)
            Dim MyObj As Object = proj.GetMyAllFromName(obj, , frm)
            If MyObj Is Nothing = False Then
                If IsArray(MyObj) Then MyObj = MyObj(0)
                Dim ob, tip, cat, propEven As String

                propEven = trans(prp, True)
                tip = trans(MyObj.obj.props.type, True)
                If obj.IndexOf(MyZnak) = 0 Then
                    ob = "UsefulObjects"
                    cat = "PropertiesCommands"
                    If UCase(obj) = UCase(MyZnak & trans("Объект события")) Or UCase(obj) = UCase(MyZnak & trans("Окно события")) Then
                        tip = trans(obj, True) ': cat = "" : propEven = ""
                    ElseIf UCase(obj).IndexOf(UCase(MyZnak & trans("Хозяин "))) = 0 Then
                        tip = trans("Хозяин меню", True) ': cat = "" : propEven = ""
                    Else
                        If propEven.IndexOf(MyZnak) <> 0 Then propEven = MyZnak & propEven
                    End If
                    If tip.IndexOf(MyZnak) <> 0 Then tip = MyZnak & tip
                Else
                    ob = "Objects"
                    If MyObj.SobytsUp IsNot Nothing Then
                        If Array.IndexOf(MyObj.SobytsUp, mass(2)) = -1 Then
                            cat = "PropertiesCommands"
                        Else
                            cat = "Events"
                        End If
                    End If
                End If
                If cat = "" And propEven = "" Then
                    Return ob & "\" & tip
                Else
                    Return ob & "\" & tip & "\" & cat & "\" & propEven
                End If
            Else
                Return ""
            End If
        End If

    End Function

    ' БЫСТРЫЕ СПРАВКИ (значки с вопросиками)
    Private Sub Labels_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Label1.SizeChanged, Label2.SizeChanged, CycleLabel.SizeChanged, IfLabel.SizeChanged, DeistLabel.SizeChanged
        If helps Is Nothing = False And sender.tag IsNot Nothing Then
            ' в таге хранится номер значка быстрой справки для этой лабели
            helps(sender.tag - 1).Left = sender.PreferredWidth + Math.Abs(sender.Width - sender.PreferredWidth) / 2
            If (sender.Width - sender.PreferredWidth) < 0 Then
                'If helps(sender.tag - 1).Parent Is Nothing = False Then
                helps(sender.tag - 1).Left = helps(sender.tag - 1).Parent.Width - helps(sender.tag - 1).Width - 2
                'Else
                '    helps(sender.tag - 1).Left = sender.Parent.Width - helps(sender.tag - 1).Width - 2
                'End If
            End If
            helps(sender.tag - 1).Top = sender.Top - 2
        End If
    End Sub
    Public Sub Labels_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Label1.TextChanged, Label2.TextChanged, CycleLabel.TextChanged, IfLabel.TextChanged, DeistLabel.TextChanged
        Labels_SizeChanged(sender, e)
    End Sub
    Public Sub Helps_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim link As String = HelpPath & "\" & sender.tag & ".html"
        If IO.File.Exists(link) Then
            Try
                Diagnostics.Process.Start(link)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    ' ВЫВОДИТ СООБЩЕНИЕ, ЧТО ЭТИ СВОЙСТВА ДОСТУПНЫ В МАСТЕРЕ СЛОЖНЫХ ДЕЙСТВИЙ
    Dim su As New Uvedomlenie()
    Public Sub ShowUved(ByVal prop As String)
        If StartUved = "Yes" And su.Visible = False Then
            prop = prop.Split(New String() {" - "}, StringSplitOptions.None)(0)
            su = New Uvedomlenie
            su.Label1.Text = transInfc(su.Label1.Text).Replace("*", prop.Trim)
            su.Show()
        End If
    End Sub
#End Region

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        HttpCompil.Main()
    End Sub

    Private Sub CodeViewMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeViewMenu2.Click
        CopyMenu2_Click(CodeViewMenu2, Nothing)
        Dim cve As New CodeVE() : cve.ShowDialog()
    End Sub

    Private Sub CodeViewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeViewMenu.Click
        CopyMenu_Click(CodeViewMenu, Nothing)
        Dim cve As New CodeVE() : cve.ShowDialog()
    End Sub


    Private Sub StatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusLabel1.Click
        If NI IsNot Nothing Then
            NI.Visible = True
            Me.Visible = False
            Me.ShowInTaskbar = False
        End If
    End Sub

    Private Sub CommMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommMenu.Click
        Dim nodes() As TreeNode = getSelNods()
        If nodes IsNot Nothing Then
            For Each nod As TreeNode In nodes
                If nod.Level > 1 Then
                    proj.UndoRedo("Изменение текста узла", nod.Name, "#" & nod.Text, nod.Text)
                    nod.Text = "#" & nod.Text
                End If
            Next
        End If
    End Sub

    Private Sub UnCommMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnCommMenu.Click
        Dim nodes() As TreeNode = getSelNods()
        If nodes IsNot Nothing Then
            For Each nod As TreeNode In nodes
                If nod.Text.IndexOf("#") = 0 And nod.Level > 1 Then
                    proj.UndoRedo("Изменение текста узла", nod.Name, nod.Text.Substring(1), nod.Text)
                    nod.Text = nod.Text.Substring(1)
                End If
            Next
        End If
    End Sub


    Private Sub ProjectSettings_Click(sender As Object, e As EventArgs) Handles ProjectSettings.Click
        OptionsForm.Show()
        OptionsForm.Tab1.SelectTab(OptionsForm.ProjectTab)
    End Sub


End Class