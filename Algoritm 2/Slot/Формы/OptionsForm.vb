Public Class OptionsForm
    Dim helps() As PictureBox

    Private Sub OptionsForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Параметры окна настроек
        OptionsHeight = Me.Height : OptionsWidth = Me.Width
    End Sub
    Private Sub OptionsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        ' Создание значков быстрой справки (иконки с вопросиками)
        helps = New PictureBox() {help1, Help2, help3, Help5, Help6, Help7, Help8, Help9, Help10, Help11, Help12, Help13, Help14}
        For i = 0 To helps.Length - 1
            helps(i).Image = Pictures32.Images("HelpMenu")
            AddHandler helps(i).Click, AddressOf MainForm.Helps_Click
            ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = helps(i)
        Next

        ' Перевод всех надисей
        Me.Text = transInfc(Me.Text)

        CommonTab.Text = transInfc(CommonTab.Text)
        LanguageLabel.Text = transInfc(LanguageLabel.Text)
        LanguageLabelDescr.Text = transInfc(LanguageLabelDescr.Text)
        Language2Label.Text = transInfc(Language2Label.Text)
        Language2LabelDescr.Text = transInfc(Language2LabelDescr.Text)
        ScinLabel.Text = transInfc(ScinLabel.Text)
        ScinLabelDescr.Text = transInfc(ScinLabelDescr.Text)
        pPathLabel.Text = transInfc(pPathLabel.Text)
        pPathDescr.Text = transInfc(pPathDescr.Text)
        iPathLabelDef.Text = transInfc(iPathLabelDef.Text)
        iPathDescrDef.Text = transInfc(iPathDescrDef.Text)
        iconLabel.Text = transInfc(iconLabel.Text)
        iconText.Text = transInfc(iconText.Text)

        ProjectTab.Text = transInfc(ProjectTab.Text)
        iPathLabel.Text = transInfc(iPathLabel.Text)
        iPathDescr.Text = transInfc(iPathDescr.Text)
        pPicNameDefLabel.Text = transInfc(pPicNameDefLabel.Text)
        pPicNameDefDescr.Text = transInfc(pPicNameDefDescr.Text)
        iconLabel.Text = transInfc(iconLabel.Text)
        iconDescr.Text = transInfc(iconDescr.Text)
        pProgressFormCheckBox.Text = transInfc(pProgressFormCheckBox.Text)
        pProgressFormDescr.Text = transInfc(pProgressFormDescr.Text)

        ProcessorTab.Text = transInfc(ProcessorTab.Text)
        bistro_StatusLineCheckBox.Text = transInfc(bistro_StatusLineCheckBox.Text)
        bistro_StatusLineDescr.Text = transInfc(bistro_StatusLineDescr.Text)
        bistro_orfoCheckBox.Text = transInfc(bistro_orfoCheckBox.Text)
        bistro_orfoDescr.Text = transInfc(bistro_orfoDescr.Text)
        bistro_UnReCheckBox.Text = transInfc(bistro_UnReCheckBox.Text)
        bistro_UnReDescr.Text = transInfc(bistro_UnReDescr.Text)
        bistro_podsvFunCheckBox.Text = transInfc(bistro_podsvFunCheckBox.Text)
        bistro_podsvHWCheckBox.Text = transInfc(bistro_podsvHWCheckBox.Text)
        bistro_podsvKovCheckBox.Text = transInfc(bistro_podsvKovCheckBox.Text)
        bistro_podsvObsCheckBox.Text = transInfc(bistro_podsvObsCheckBox.Text)
        bistro_podsvPMsCheckBox.Text = transInfc(bistro_podsvPMsCheckBox.Text)
        bistro_podsvDescr.Text = transInfc(bistro_podsvDescr.Text)

        ' загрузка списка языков
        Dim dirs() As String = IO.Directory.GetDirectories(LanguagePath)
        For i = 0 To dirs.Length - 1
            LanguageBox.Items.Add(transInfc(trans(IO.Path.GetFileName(dirs(i)), , True)))
            Language2Box.Items.Add(transInfc(trans(IO.Path.GetFileName(dirs(i)), , True)))
        Next
        LanguageBox.SelectedItem = transInfc(trans(lang_interface, , True))
        Language2Box.SelectedItem = transInfc(trans(lang_def, , True))

        ' загрузка списка скинов
        Dim skns() As String = IO.Directory.GetDirectories(SkinsPath)
        For i = 0 To skns.Length - 1
            SkinBox.Items.Add(trans(IO.Path.GetFileName(skns(i)), , True))
        Next
        SkinBox.SelectedItem = trans(Skin, , True)

        pPathText.Text = ProjectsPath : FolderBrowserDialog1.SelectedPath = pPathText.Text
        iPathTextDef.Text = ProjIpath
        iPathText.Text = proj.iPathShort
        pPicNameDefText.Text = proj.pPicNameDef
        iconText.Text = proj.pIcon
        OpenFileDialog1.Filter = transInfc("Иконки") & " (*.ico)" & "|*.ico|" & transInfc("Все файлы") & " (*.*)" & "|*.*"
        If proj.pProgressForm = "yes" Then pProgressFormCheckBox.Checked = True Else pProgressFormCheckBox.Checked = False
        bistro_StatusLineCheckBox.Checked = (bistro_StatusLine)
        bistro_orfoCheckBox.Checked = (bistro_orfo)
        bistro_UnReCheckBox.Checked = (bistro_UnRe)
        bistro_podsvFunCheckBox.Checked = (bistro_podsvFun)
        bistro_podsvHWCheckBox.Checked = (bistro_podsvHW)
        bistro_podsvKovCheckBox.Checked = (bistro_podsvKov)
        bistro_podsvObsCheckBox.Checked = (bistro_podsvObs)
        bistro_podsvPMsCheckBox.Checked = (bistro_podsvPMs)
    End Sub
    Private Sub OptionsForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' Параметры окна настроек
        If OptionsHeight <> 0 Then Me.Height = OptionsHeight : Me.Width = OptionsWidth

        Me.BackColor = SkinColors(Me.Name)
        Me.BackgroundImage = SkinPictures(Me.Name)

        CommonTab.BackColor = SkinColors(CommonTab.Name)
        CommonTab.BackgroundImage = SkinPictures(CommonTab.Name)

        ProjectTab.BackColor = SkinColors(ProjectTab.Name)
        ProjectTab.BackgroundImage = SkinPictures(ProjectTab.Name)

        LanguageLabel.ForeColor = SkinColors("OptionLabel")
        LanguageLabelDescr.ForeColor = SkinColors("OptionDescr")
        Language2Label.ForeColor = SkinColors("OptionLabel")
        Language2LabelDescr.ForeColor = SkinColors("OptionDescr")
        ScinLabel.ForeColor = SkinColors("OptionLabel")
        ScinLabelDescr.ForeColor = SkinColors("OptionDescr")
        pPathLabel.ForeColor = SkinColors("OptionLabel")
        pPathDescr.ForeColor = SkinColors("OptionDescr")
        iPathLabelDef.ForeColor = SkinColors("OptionLabel")
        iPathDescrDef.ForeColor = SkinColors("OptionDescr")
        iPathLabel.ForeColor = SkinColors("OptionLabel")
        iPathDescr.ForeColor = SkinColors("OptionDescr")
        pPicNameDefLabel.ForeColor = SkinColors("OptionLabel")
        pPicNameDefDescr.ForeColor = SkinColors("OptionDescr")
        iconLabel.ForeColor = SkinColors("OptionLabel")
        iconDescr.ForeColor = SkinColors("OptionDescr")
        pProgressFormDescr.ForeColor = SkinColors("OptionDescr")
        pProgressFormCheckBox.BackColor = Color.Transparent
        bistro_StatusLineCheckBox.BackColor = Color.Transparent
        bistro_StatusLineDescr.ForeColor = SkinColors("OptionDescr")
        bistro_orfoCheckBox.BackColor = Color.Transparent
        bistro_orfoDescr.ForeColor = SkinColors("OptionDescr")
        bistro_UnReCheckBox.BackColor = Color.Transparent
        bistro_UnReDescr.ForeColor = SkinColors("OptionDescr")
        bistro_podsvFunCheckBox.BackColor = Color.Transparent
        bistro_podsvHWCheckBox.BackColor = Color.Transparent
        bistro_podsvKovCheckBox.BackColor = Color.Transparent
        bistro_podsvObsCheckBox.BackColor = Color.Transparent
        bistro_podsvPMsCheckBox.BackColor = Color.Transparent
        bistro_podsvDescr.ForeColor = SkinColors("OptionDescr")

        pPathText.BackColor = SkinColors("OptionText")
        iPathTextDef.BackColor = SkinColors("OptionText")
        iPathText.BackColor = SkinColors("OptionText")
        pPicNameDefText.BackColor = SkinColors("OptionText")
        iconText.BackColor = SkinColors("OptionText")
        LanguageBox.BackColor = SkinColors("OptionText")
        Language2Box.BackColor = SkinColors("OptionText")
        SkinBox.BackColor = SkinColors("OptionText")

        Ok.BackgroundImage = SkinPictures("OptionButton")
        Cancel.BackgroundImage = SkinPictures("OptionButton")
        pPathBrows.BackgroundImage = SkinPictures("OptionButton")
        iconBrows.BackgroundImage = SkinPictures("OptionButton")
        bistro_StatusLineCheckBox.BackgroundImage = SkinPictures("OptionButton")
        bistro_orfoCheckBox.BackgroundImage = SkinPictures("OptionButton")
        bistro_UnReCheckBox.BackgroundImage = SkinPictures("OptionButton")
        bistro_podsvFunCheckBox.BackgroundImage = SkinPictures("OptionButton")
        bistro_podsvHWCheckBox.BackgroundImage = SkinPictures("OptionButton")
        bistro_podsvKovCheckBox.BackgroundImage = SkinPictures("OptionButton")
        bistro_podsvObsCheckBox.BackgroundImage = SkinPictures("OptionButton")
        bistro_podsvPMsCheckBox.BackgroundImage = SkinPictures("OptionButton")

        Ok.ForeColor = SkinColors("OptionLabel")
        Cancel.ForeColor = SkinColors("OptionLabel")
        pPathBrows.ForeColor = SkinColors("OptionLabel")
        iconBrows.ForeColor = SkinColors("OptionLabel")
        pProgressFormCheckBox.ForeColor = SkinColors("OptionLabel")
        bistro_StatusLineCheckBox.ForeColor = SkinColors("OptionLabel")
        bistro_orfoCheckBox.ForeColor = SkinColors("OptionLabel")
        bistro_UnReCheckBox.ForeColor = SkinColors("OptionLabel")
        bistro_podsvFunCheckBox.ForeColor = SkinColors("OptionLabel")
        bistro_podsvHWCheckBox.ForeColor = SkinColors("OptionLabel")
        bistro_podsvKovCheckBox.ForeColor = SkinColors("OptionLabel")
        bistro_podsvObsCheckBox.ForeColor = SkinColors("OptionLabel")
        bistro_podsvPMsCheckBox.ForeColor = SkinColors("OptionLabel")

        Dim i As Integer
        For i = 0 To helps.Length - 1
            helps(i).BackColor = Color.Transparent
        Next
    End Sub

    Public Sub SaveOptions()
        Dim txt As String = ""
        txt &= "#Lang_interface" & vbCrLf & lang_interface & vbCrLf & vbCrLf
        txt &= "#lang_def" & vbCrLf & lang_def & vbCrLf & vbCrLf
        txt &= "#Skin" & vbCrLf & Skin & vbCrLf & vbCrLf
        txt &= "#ProjectsPath" & vbCrLf & ProjectsPath & vbCrLf & vbCrLf
        txt &= "#ProjIpath" & vbCrLf & ProjIpath & vbCrLf & vbCrLf
        txt &= "#StartEdu" & vbCrLf & StartEdu & vbCrLf & vbCrLf
        txt &= "#StartUved" & vbCrLf & StartUved & vbCrLf & vbCrLf
        txt &= "#bistro_StatusLine" & vbCrLf & YesOrNo(bistro_StatusLine) & vbCrLf & vbCrLf
        txt &= "#bistro_orfo" & vbCrLf & YesOrNo(bistro_orfo) & vbCrLf & vbCrLf
        txt &= "#bistro_UnRe" & vbCrLf & YesOrNo(bistro_UnRe) & vbCrLf & vbCrLf
        txt &= "#bistro_podsvFun" & vbCrLf & YesOrNo(bistro_podsvFun) & vbCrLf & vbCrLf
        txt &= "#bistro_podsvHW" & vbCrLf & YesOrNo(bistro_podsvHW) & vbCrLf & vbCrLf
        txt &= "#bistro_podsvKov" & vbCrLf & YesOrNo(bistro_podsvKov) & vbCrLf & vbCrLf
        txt &= "#bistro_podsvObs" & vbCrLf & YesOrNo(bistro_podsvObs) & vbCrLf & vbCrLf
        txt &= "#bistro_podsvPMs" & vbCrLf & YesOrNo(bistro_podsvPMs) & vbCrLf & vbCrLf
        Dim fl As IO.StreamWriter = IO.File.CreateText(OptionsFilePath)
        fl.Write(txt) : fl.Close()
    End Sub
    Public Sub OpenOptions()
        Dim fl As IO.StreamReader = IO.File.OpenText(OptionsFilePath)
        Dim txt As String = fl.ReadToEnd : fl.Close()
        lang_interface = IsNull(GetNuzhPunkt("#Lang_interface", txt), lang_interface)
        lang_def = IsNull(GetNuzhPunkt("#lang_def", txt), lang_def)
        Skin = GetNuzhPunkt("#Skin", txt)
        ProjectsPath = IsNull(GetNuzhPunkt("#ProjectsPath", txt), ProjectsPath)
        'If IO.Directory.Exists(AppPath & ProjectsPath) Then ProjectsPath = AppPath & ProjectsPath
        ProjIpath = IsNull(GetNuzhPunkt("#ProjIpath", txt), ProjIpath)
        StartEdu = IsNull(GetNuzhPunkt("#StartEdu", txt), StartEdu)
        StartUved = IsNull(GetNuzhPunkt("#StartUved", txt), StartUved)
        bistro_StatusLine = YesOrNo(GetNuzhPunkt("#bistro_StatusLine", txt))
        bistro_orfo = YesOrNo(GetNuzhPunkt("#bistro_orfo", txt))
        bistro_UnRe = YesOrNo(GetNuzhPunkt("#bistro_UnRe", txt))
        bistro_podsvFun = YesOrNo(GetNuzhPunkt("#bistro_podsvFun", txt))
        bistro_podsvHW = YesOrNo(GetNuzhPunkt("#bistro_podsvHW", txt))
        bistro_podsvKov = YesOrNo(GetNuzhPunkt("#bistro_podsvKov", txt))
        bistro_podsvObs = YesOrNo(GetNuzhPunkt("#bistro_podsvObs", txt))
        bistro_podsvPMs = YesOrNo(GetNuzhPunkt("#bistro_podsvPMs", txt))
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ok.Click
        Dim fl As Boolean = False, flPic As Boolean = False

        ' Язык интерфейса
        If trans(LanguageBox.SelectedItem, True) <> lang_interface Then
            lang_interface = trans(LanguageBox.SelectedItem, True) : setLangs(False) : fl = True
        End If

        ' Язык программирования по умолчанию
        If trans(Language2Box.SelectedItem, True) <> lang_def Then
            lang_def = trans(Language2Box.SelectedItem, True)
        End If

        ' Скин
        If trans(SkinBox.SelectedItem, True) <> Skin Then
            Skin = trans(SkinBox.SelectedItem, True) : fl = True
        End If

        ' Папка проектов
        If pPathText.Text <> ProjectsPath Then ProjectsPath = pPathText.Text

        ' Папка рисунков проектов по умолчанию
        If iPathTextDef.Text <> ProjIpath Then ProjIpath = iPathTextDef.Text

        ' Папка рисунков проекта
        ' If iPathText.Text.IndexOf("\") <> 0 Then iPathText.Text = iPathText.Text
        If iPathText.Text = "\" Then iPathText.Text = ""
        ' Если папка была изменена
        If iPathText.Text <> proj.iPathShort Then
            ' изменить основные переменные
            If iPathText.Text = "" Then iPathText.Text = "\"
            proj.iPathShort = iPathText.Text
            proj.iPath = proj.pPath & proj.iPathShort
            If proj.iPathShort = "\" Then proj.iPath = proj.pPath
            ' отметить флаг того, что надо будет пройтись по всем рисункам
            flPic = True
        End If

        ' Имя файла рисунков по умолчанию
        If pPicNameDefText.Text <> proj.pPicNameDef Then proj.pPicNameDef = pPicNameDefText.Text : flPic = True

        ' иконка
        If iconText.Text <> proj.pIcon Then
            If iconText.Text <> "" Then proj.pIcon = GetMinPath(iconText.Text) Else proj.pIcon = ""
        End If

        If pProgressFormCheckBox.Checked Then proj.pProgressForm = "yes" Else proj.pProgressForm = "no"
        bistro_StatusLine = (bistro_StatusLineCheckBox.Checked)
        bistro_orfo = (bistro_orfoCheckBox.Checked)
        bistro_UnRe = (bistro_UnReCheckBox.Checked)
        bistro_podsvFun = (bistro_podsvFunCheckBox.Checked)
        bistro_podsvHW = (bistro_podsvHWCheckBox.Checked)
        bistro_podsvKov = (bistro_podsvKovCheckBox.Checked)
        bistro_podsvObs = (bistro_podsvObsCheckBox.Checked)
        bistro_podsvPMs = (bistro_podsvPMsCheckBox.Checked)

        Me.Close()

        ' Если требуется перегрузка программы для применения свойств
        If fl = True Then
            intr = ProgressForm
            ProgressFormShow(transInfc("Применение"))
            MainForm.InitializeBeforeProject(True)
            MainForm.InitializeAfterProject(True)
            setLangs()
            ProgressForm.Hide()
        End If

        ' Если требуется пройтись по всем рисункам
        If flPic = True Then
            ProgressFormShow(transInfc("Рисунки"))
            Dim i, j, k As Integer
            Dim typs() As String = {UCase(trans("Рисунок"))}
            ' Пройтись по объектам и изменить их свойства типа Рисунок
            For i = 0 To proj.f.Length - 2
                For j = 0 To proj.f(i).MyObjs.Length - 1
                    ProgressForm.ProgressBarValue = 10 + (90 / (proj.f.Length - 1)) / proj.f(i).MyObjs.Length * (j) + ((90 / (proj.f.Length - 1)) * (i))
                    ' Перевод всех рисунков на новую папку
                    If proj.f(i).MyObjs(j).Propertys Is Nothing = False Then
                        For k = 0 To proj.f(i).MyObjs(j).Propertys.Length - 1
                            Dim typ As String = UCase(GetTypeProperty(proj.f(i).MyObjs(j).Propertys(k)))
                            Dim prop As String = proj.f(i).MyObjs(j).Propertys(k)

                            ' Если свойтво типа Рисунок и оно не только для чтения
                            If (Array.IndexOf(typs, typ) <> -1 And Array.IndexOf(ReadOnlyProps, UCase(prop)) = -1) Then
                                ' Присвоить всем свойствам типа Рисунок принудительно заново их рисунок, скопированный функцией copyImage в новую папку рисунков
                                SetProperty(proj.f(i).MyObjs(j), prop, copyImage(GetMaxPath(GetProperty(proj.f(i).MyObjs(j), prop).str), True))
                            End If
                        Next
                    End If
                Next
            Next
            ProgressForm.ProgressBarValue = 100
            If proj.iPathShort = "\" Then proj.iPathShort = "" : proj.iPath = proj.pPath & proj.iPathShort
            ProgressForm.Hide()
        End If

        SaveOptions()
    End Sub

    Private Sub pPathBrows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pPathBrows.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            pPathText.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub iconBrows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iconBrows.Click
        If iconText.Text = "" Then
            OpenFileDialog1.InitialDirectory = proj.pPath
            OpenFileDialog1.FileName = ""
        Else
            OpenFileDialog1.FileName = GetMaxPath(iconText.Text)
        End If
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            iconText.Text = OpenFileDialog1.FileName
        End If
    End Sub


End Class