<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Tab1 = New System.Windows.Forms.TabControl()
        Me.CommonTab = New System.Windows.Forms.TabPage()
        Me.iPathTextDef = New System.Windows.Forms.TextBox()
        Me.Help6 = New System.Windows.Forms.PictureBox()
        Me.iPathDescrDef = New System.Windows.Forms.Label()
        Me.iPathLabelDef = New System.Windows.Forms.Label()
        Me.pPathBrows = New System.Windows.Forms.Button()
        Me.pPathText = New System.Windows.Forms.TextBox()
        Me.Help5 = New System.Windows.Forms.PictureBox()
        Me.pPathDescr = New System.Windows.Forms.Label()
        Me.pPathLabel = New System.Windows.Forms.Label()
        Me.help3 = New System.Windows.Forms.PictureBox()
        Me.Help2 = New System.Windows.Forms.PictureBox()
        Me.help1 = New System.Windows.Forms.PictureBox()
        Me.ScinLabelDescr = New System.Windows.Forms.Label()
        Me.Language2LabelDescr = New System.Windows.Forms.Label()
        Me.Language2Box = New System.Windows.Forms.ComboBox()
        Me.Language2Label = New System.Windows.Forms.Label()
        Me.LanguageLabelDescr = New System.Windows.Forms.Label()
        Me.SkinBox = New System.Windows.Forms.ComboBox()
        Me.ScinLabel = New System.Windows.Forms.Label()
        Me.LanguageBox = New System.Windows.Forms.ComboBox()
        Me.LanguageLabel = New System.Windows.Forms.Label()
        Me.ProjectTab = New System.Windows.Forms.TabPage()
        Me.iconBrows = New System.Windows.Forms.Button()
        Me.iconText = New System.Windows.Forms.TextBox()
        Me.Help10 = New System.Windows.Forms.PictureBox()
        Me.iconDescr = New System.Windows.Forms.Label()
        Me.iconLabel = New System.Windows.Forms.Label()
        Me.pProgressFormDescr = New System.Windows.Forms.Label()
        Me.Help9 = New System.Windows.Forms.PictureBox()
        Me.pProgressFormCheckBox = New System.Windows.Forms.CheckBox()
        Me.pPicNameDefText = New System.Windows.Forms.TextBox()
        Me.Help8 = New System.Windows.Forms.PictureBox()
        Me.pPicNameDefDescr = New System.Windows.Forms.Label()
        Me.pPicNameDefLabel = New System.Windows.Forms.Label()
        Me.iPathText = New System.Windows.Forms.TextBox()
        Me.Help7 = New System.Windows.Forms.PictureBox()
        Me.iPathDescr = New System.Windows.Forms.Label()
        Me.iPathLabel = New System.Windows.Forms.Label()
        Me.ProcessorTab = New System.Windows.Forms.TabPage()
        Me.bistro_StatusLineDescr = New System.Windows.Forms.Label()
        Me.Help14 = New System.Windows.Forms.PictureBox()
        Me.bistro_StatusLineCheckBox = New System.Windows.Forms.CheckBox()
        Me.bistro_podsvKovCheckBox = New System.Windows.Forms.CheckBox()
        Me.bistro_podsvPMsCheckBox = New System.Windows.Forms.CheckBox()
        Me.bistro_podsvObsCheckBox = New System.Windows.Forms.CheckBox()
        Me.bistro_podsvHWCheckBox = New System.Windows.Forms.CheckBox()
        Me.bistro_podsvDescr = New System.Windows.Forms.Label()
        Me.Help13 = New System.Windows.Forms.PictureBox()
        Me.bistro_podsvFunCheckBox = New System.Windows.Forms.CheckBox()
        Me.bistro_UnReDescr = New System.Windows.Forms.Label()
        Me.Help12 = New System.Windows.Forms.PictureBox()
        Me.bistro_UnReCheckBox = New System.Windows.Forms.CheckBox()
        Me.bistro_orfoDescr = New System.Windows.Forms.Label()
        Me.Help11 = New System.Windows.Forms.PictureBox()
        Me.bistro_orfoCheckBox = New System.Windows.Forms.CheckBox()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Ok = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.iconDescr2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Tab1.SuspendLayout()
        Me.CommonTab.SuspendLayout()
        CType(Me.Help6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Help5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.help3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Help2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.help1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProjectTab.SuspendLayout()
        CType(Me.Help10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Help9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Help8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Help7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProcessorTab.SuspendLayout()
        CType(Me.Help14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Help13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Help12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Help11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab1.Controls.Add(Me.CommonTab)
        Me.Tab1.Controls.Add(Me.ProjectTab)
        Me.Tab1.Controls.Add(Me.ProcessorTab)
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Multiline = True
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedIndex = 0
        Me.Tab1.Size = New System.Drawing.Size(328, 300)
        Me.Tab1.TabIndex = 0
        '
        'CommonTab
        '
        Me.CommonTab.Controls.Add(Me.iPathTextDef)
        Me.CommonTab.Controls.Add(Me.Help6)
        Me.CommonTab.Controls.Add(Me.iPathDescrDef)
        Me.CommonTab.Controls.Add(Me.iPathLabelDef)
        Me.CommonTab.Controls.Add(Me.pPathBrows)
        Me.CommonTab.Controls.Add(Me.pPathText)
        Me.CommonTab.Controls.Add(Me.Help5)
        Me.CommonTab.Controls.Add(Me.pPathDescr)
        Me.CommonTab.Controls.Add(Me.pPathLabel)
        Me.CommonTab.Controls.Add(Me.help3)
        Me.CommonTab.Controls.Add(Me.Help2)
        Me.CommonTab.Controls.Add(Me.help1)
        Me.CommonTab.Controls.Add(Me.ScinLabelDescr)
        Me.CommonTab.Controls.Add(Me.Language2LabelDescr)
        Me.CommonTab.Controls.Add(Me.Language2Box)
        Me.CommonTab.Controls.Add(Me.Language2Label)
        Me.CommonTab.Controls.Add(Me.LanguageLabelDescr)
        Me.CommonTab.Controls.Add(Me.SkinBox)
        Me.CommonTab.Controls.Add(Me.ScinLabel)
        Me.CommonTab.Controls.Add(Me.LanguageBox)
        Me.CommonTab.Controls.Add(Me.LanguageLabel)
        Me.CommonTab.Location = New System.Drawing.Point(4, 22)
        Me.CommonTab.Name = "CommonTab"
        Me.CommonTab.Padding = New System.Windows.Forms.Padding(3)
        Me.CommonTab.Size = New System.Drawing.Size(320, 274)
        Me.CommonTab.TabIndex = 0
        Me.CommonTab.Text = "Общие"
        Me.CommonTab.UseVisualStyleBackColor = True
        '
        'iPathTextDef
        '
        Me.iPathTextDef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iPathTextDef.Location = New System.Drawing.Point(11, 225)
        Me.iPathTextDef.Name = "iPathTextDef"
        Me.iPathTextDef.Size = New System.Drawing.Size(304, 20)
        Me.iPathTextDef.TabIndex = 41
        '
        'Help6
        '
        Me.Help6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help6.Location = New System.Drawing.Point(300, 207)
        Me.Help6.Name = "Help6"
        Me.Help6.Size = New System.Drawing.Size(16, 16)
        Me.Help6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help6.TabIndex = 40
        Me.Help6.TabStop = False
        Me.Help6.Tag = "Environment/Options"
        '
        'iPathDescrDef
        '
        Me.iPathDescrDef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iPathDescrDef.BackColor = System.Drawing.Color.Transparent
        Me.iPathDescrDef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.iPathDescrDef.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.iPathDescrDef.Location = New System.Drawing.Point(6, 246)
        Me.iPathDescrDef.Name = "iPathDescrDef"
        Me.iPathDescrDef.Size = New System.Drawing.Size(308, 18)
        Me.iPathDescrDef.TabIndex = 39
        Me.iPathDescrDef.Tag = "1"
        Me.iPathDescrDef.Text = "Папка в проекте, куда будут сохраняться рисунки проекта"
        Me.iPathDescrDef.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'iPathLabelDef
        '
        Me.iPathLabelDef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iPathLabelDef.BackColor = System.Drawing.Color.Transparent
        Me.iPathLabelDef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.iPathLabelDef.ForeColor = System.Drawing.Color.Black
        Me.iPathLabelDef.Location = New System.Drawing.Point(6, 204)
        Me.iPathLabelDef.Name = "iPathLabelDef"
        Me.iPathLabelDef.Size = New System.Drawing.Size(291, 18)
        Me.iPathLabelDef.TabIndex = 38
        Me.iPathLabelDef.Tag = "1"
        Me.iPathLabelDef.Text = "Папка с рисунками проекта по умолчанию"
        Me.iPathLabelDef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pPathBrows
        '
        Me.pPathBrows.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pPathBrows.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pPathBrows.Location = New System.Drawing.Point(294, 169)
        Me.pPathBrows.Name = "pPathBrows"
        Me.pPathBrows.Size = New System.Drawing.Size(22, 15)
        Me.pPathBrows.TabIndex = 37
        Me.pPathBrows.Text = "•••"
        Me.pPathBrows.UseVisualStyleBackColor = False
        '
        'pPathText
        '
        Me.pPathText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pPathText.Location = New System.Drawing.Point(11, 165)
        Me.pPathText.Name = "pPathText"
        Me.pPathText.Size = New System.Drawing.Size(277, 20)
        Me.pPathText.TabIndex = 36
        '
        'Help5
        '
        Me.Help5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help5.Location = New System.Drawing.Point(300, 147)
        Me.Help5.Name = "Help5"
        Me.Help5.Size = New System.Drawing.Size(16, 16)
        Me.Help5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help5.TabIndex = 35
        Me.Help5.TabStop = False
        Me.Help5.Tag = "Environment/Options"
        '
        'pPathDescr
        '
        Me.pPathDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pPathDescr.BackColor = System.Drawing.Color.Transparent
        Me.pPathDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pPathDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.pPathDescr.Location = New System.Drawing.Point(6, 186)
        Me.pPathDescr.Name = "pPathDescr"
        Me.pPathDescr.Size = New System.Drawing.Size(308, 18)
        Me.pPathDescr.TabIndex = 34
        Me.pPathDescr.Tag = "1"
        Me.pPathDescr.Text = "Папка, в которую по умолчанию сохраняются проекты"
        Me.pPathDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pPathLabel
        '
        Me.pPathLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pPathLabel.BackColor = System.Drawing.Color.Transparent
        Me.pPathLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pPathLabel.ForeColor = System.Drawing.Color.Black
        Me.pPathLabel.Location = New System.Drawing.Point(6, 144)
        Me.pPathLabel.Name = "pPathLabel"
        Me.pPathLabel.Size = New System.Drawing.Size(291, 18)
        Me.pPathLabel.TabIndex = 32
        Me.pPathLabel.Tag = "1"
        Me.pPathLabel.Text = "Папка с проектами"
        Me.pPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'help3
        '
        Me.help3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.help3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help3.Location = New System.Drawing.Point(300, 103)
        Me.help3.Name = "help3"
        Me.help3.Size = New System.Drawing.Size(16, 16)
        Me.help3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help3.TabIndex = 31
        Me.help3.TabStop = False
        Me.help3.Tag = "Environment/Options"
        '
        'Help2
        '
        Me.Help2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help2.Location = New System.Drawing.Point(300, 56)
        Me.Help2.Name = "Help2"
        Me.Help2.Size = New System.Drawing.Size(16, 16)
        Me.Help2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help2.TabIndex = 30
        Me.Help2.TabStop = False
        Me.Help2.Tag = "Environment/Options"
        '
        'help1
        '
        Me.help1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.help1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help1.Location = New System.Drawing.Point(300, 10)
        Me.help1.Name = "help1"
        Me.help1.Size = New System.Drawing.Size(16, 16)
        Me.help1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help1.TabIndex = 29
        Me.help1.TabStop = False
        Me.help1.Tag = "Environment/Options"
        '
        'ScinLabelDescr
        '
        Me.ScinLabelDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScinLabelDescr.BackColor = System.Drawing.Color.Transparent
        Me.ScinLabelDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ScinLabelDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.ScinLabelDescr.Location = New System.Drawing.Point(8, 124)
        Me.ScinLabelDescr.Name = "ScinLabelDescr"
        Me.ScinLabelDescr.Size = New System.Drawing.Size(309, 18)
        Me.ScinLabelDescr.TabIndex = 9
        Me.ScinLabelDescr.Tag = "1"
        Me.ScinLabelDescr.Text = "Стиль оформления среды разработки Алгоритм 2"
        Me.ScinLabelDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Language2LabelDescr
        '
        Me.Language2LabelDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Language2LabelDescr.BackColor = System.Drawing.Color.Transparent
        Me.Language2LabelDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Language2LabelDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Language2LabelDescr.Location = New System.Drawing.Point(6, 77)
        Me.Language2LabelDescr.Name = "Language2LabelDescr"
        Me.Language2LabelDescr.Size = New System.Drawing.Size(310, 18)
        Me.Language2LabelDescr.TabIndex = 8
        Me.Language2LabelDescr.Tag = "1"
        Me.Language2LabelDescr.Text = "На котором по умолчанию программируют в Алгоритме2"
        Me.Language2LabelDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Language2Box
        '
        Me.Language2Box.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Language2Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Language2Box.FormattingEnabled = True
        Me.Language2Box.Location = New System.Drawing.Point(149, 54)
        Me.Language2Box.MaxDropDownItems = 16
        Me.Language2Box.Name = "Language2Box"
        Me.Language2Box.Size = New System.Drawing.Size(148, 21)
        Me.Language2Box.TabIndex = 7
        '
        'Language2Label
        '
        Me.Language2Label.BackColor = System.Drawing.Color.Transparent
        Me.Language2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Language2Label.ForeColor = System.Drawing.Color.Black
        Me.Language2Label.Location = New System.Drawing.Point(3, 54)
        Me.Language2Label.Name = "Language2Label"
        Me.Language2Label.Size = New System.Drawing.Size(140, 18)
        Me.Language2Label.TabIndex = 6
        Me.Language2Label.Tag = "1"
        Me.Language2Label.Text = "Язык программирования"
        Me.Language2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LanguageLabelDescr
        '
        Me.LanguageLabelDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LanguageLabelDescr.BackColor = System.Drawing.Color.Transparent
        Me.LanguageLabelDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LanguageLabelDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LanguageLabelDescr.Location = New System.Drawing.Point(8, 31)
        Me.LanguageLabelDescr.Name = "LanguageLabelDescr"
        Me.LanguageLabelDescr.Size = New System.Drawing.Size(307, 18)
        Me.LanguageLabelDescr.TabIndex = 5
        Me.LanguageLabelDescr.Tag = "1"
        Me.LanguageLabelDescr.Text = "Язык среды разработки Алгоритм2"
        Me.LanguageLabelDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SkinBox
        '
        Me.SkinBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SkinBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SkinBox.FormattingEnabled = True
        Me.SkinBox.Location = New System.Drawing.Point(149, 101)
        Me.SkinBox.MaxDropDownItems = 16
        Me.SkinBox.Name = "SkinBox"
        Me.SkinBox.Size = New System.Drawing.Size(148, 21)
        Me.SkinBox.TabIndex = 4
        '
        'ScinLabel
        '
        Me.ScinLabel.BackColor = System.Drawing.Color.Transparent
        Me.ScinLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ScinLabel.ForeColor = System.Drawing.Color.Black
        Me.ScinLabel.Location = New System.Drawing.Point(8, 101)
        Me.ScinLabel.Name = "ScinLabel"
        Me.ScinLabel.Size = New System.Drawing.Size(135, 18)
        Me.ScinLabel.TabIndex = 3
        Me.ScinLabel.Tag = "1"
        Me.ScinLabel.Text = "Скин"
        Me.ScinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LanguageBox
        '
        Me.LanguageBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LanguageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguageBox.FormattingEnabled = True
        Me.LanguageBox.Location = New System.Drawing.Point(149, 8)
        Me.LanguageBox.MaxDropDownItems = 16
        Me.LanguageBox.Name = "LanguageBox"
        Me.LanguageBox.Size = New System.Drawing.Size(148, 21)
        Me.LanguageBox.TabIndex = 2
        '
        'LanguageLabel
        '
        Me.LanguageLabel.BackColor = System.Drawing.Color.Transparent
        Me.LanguageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LanguageLabel.ForeColor = System.Drawing.Color.Black
        Me.LanguageLabel.Location = New System.Drawing.Point(3, 8)
        Me.LanguageLabel.Name = "LanguageLabel"
        Me.LanguageLabel.Size = New System.Drawing.Size(140, 18)
        Me.LanguageLabel.TabIndex = 1
        Me.LanguageLabel.Tag = "1"
        Me.LanguageLabel.Text = "Язык интерфейса"
        Me.LanguageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProjectTab
        '
        Me.ProjectTab.Controls.Add(Me.LinkLabel1)
        Me.ProjectTab.Controls.Add(Me.iconDescr2)
        Me.ProjectTab.Controls.Add(Me.iconBrows)
        Me.ProjectTab.Controls.Add(Me.iconText)
        Me.ProjectTab.Controls.Add(Me.Help10)
        Me.ProjectTab.Controls.Add(Me.iconDescr)
        Me.ProjectTab.Controls.Add(Me.iconLabel)
        Me.ProjectTab.Controls.Add(Me.pProgressFormDescr)
        Me.ProjectTab.Controls.Add(Me.Help9)
        Me.ProjectTab.Controls.Add(Me.pProgressFormCheckBox)
        Me.ProjectTab.Controls.Add(Me.pPicNameDefText)
        Me.ProjectTab.Controls.Add(Me.Help8)
        Me.ProjectTab.Controls.Add(Me.pPicNameDefDescr)
        Me.ProjectTab.Controls.Add(Me.pPicNameDefLabel)
        Me.ProjectTab.Controls.Add(Me.iPathText)
        Me.ProjectTab.Controls.Add(Me.Help7)
        Me.ProjectTab.Controls.Add(Me.iPathDescr)
        Me.ProjectTab.Controls.Add(Me.iPathLabel)
        Me.ProjectTab.Location = New System.Drawing.Point(4, 22)
        Me.ProjectTab.Name = "ProjectTab"
        Me.ProjectTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ProjectTab.Size = New System.Drawing.Size(320, 274)
        Me.ProjectTab.TabIndex = 1
        Me.ProjectTab.Text = "Настройки проекта"
        Me.ProjectTab.UseVisualStyleBackColor = True
        '
        'iconBrows
        '
        Me.iconBrows.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iconBrows.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.iconBrows.Location = New System.Drawing.Point(292, 155)
        Me.iconBrows.Name = "iconBrows"
        Me.iconBrows.Size = New System.Drawing.Size(22, 15)
        Me.iconBrows.TabIndex = 57
        Me.iconBrows.Text = "•••"
        Me.iconBrows.UseVisualStyleBackColor = False
        '
        'iconText
        '
        Me.iconText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iconText.Location = New System.Drawing.Point(10, 150)
        Me.iconText.Name = "iconText"
        Me.iconText.Size = New System.Drawing.Size(278, 20)
        Me.iconText.TabIndex = 56
        '
        'Help10
        '
        Me.Help10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help10.Location = New System.Drawing.Point(299, 132)
        Me.Help10.Name = "Help10"
        Me.Help10.Size = New System.Drawing.Size(16, 16)
        Me.Help10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help10.TabIndex = 55
        Me.Help10.TabStop = False
        Me.Help10.Tag = "Environment/Options"
        '
        'iconDescr
        '
        Me.iconDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iconDescr.BackColor = System.Drawing.Color.Transparent
        Me.iconDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.iconDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.iconDescr.Location = New System.Drawing.Point(5, 171)
        Me.iconDescr.Name = "iconDescr"
        Me.iconDescr.Size = New System.Drawing.Size(308, 18)
        Me.iconDescr.TabIndex = 54
        Me.iconDescr.Tag = "1"
        Me.iconDescr.Text = "Значок exe-файла вашей будущей программы"
        Me.iconDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'iconLabel
        '
        Me.iconLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iconLabel.BackColor = System.Drawing.Color.Transparent
        Me.iconLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.iconLabel.Location = New System.Drawing.Point(5, 129)
        Me.iconLabel.Name = "iconLabel"
        Me.iconLabel.Size = New System.Drawing.Size(291, 18)
        Me.iconLabel.TabIndex = 53
        Me.iconLabel.Tag = "1"
        Me.iconLabel.Text = "Иконка программы"
        Me.iconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pProgressFormDescr
        '
        Me.pProgressFormDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pProgressFormDescr.BackColor = System.Drawing.Color.Transparent
        Me.pProgressFormDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pProgressFormDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.pProgressFormDescr.Location = New System.Drawing.Point(5, 251)
        Me.pProgressFormDescr.Name = "pProgressFormDescr"
        Me.pProgressFormDescr.Size = New System.Drawing.Size(310, 18)
        Me.pProgressFormDescr.TabIndex = 52
        Me.pProgressFormDescr.Tag = "1"
        Me.pProgressFormDescr.Text = "Окно загрузки появляется при запуске вашей программы"
        Me.pProgressFormDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Help9
        '
        Me.Help9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help9.Location = New System.Drawing.Point(299, 232)
        Me.Help9.Name = "Help9"
        Me.Help9.Size = New System.Drawing.Size(16, 16)
        Me.Help9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help9.TabIndex = 51
        Me.Help9.TabStop = False
        Me.Help9.Tag = "Environment/Options"
        '
        'pProgressFormCheckBox
        '
        Me.pProgressFormCheckBox.AutoSize = True
        Me.pProgressFormCheckBox.Location = New System.Drawing.Point(10, 231)
        Me.pProgressFormCheckBox.Name = "pProgressFormCheckBox"
        Me.pProgressFormCheckBox.Size = New System.Drawing.Size(274, 17)
        Me.pProgressFormCheckBox.TabIndex = 50
        Me.pProgressFormCheckBox.Text = "Показывать окно загрузки при запуске проекта"
        Me.pProgressFormCheckBox.UseVisualStyleBackColor = True
        '
        'pPicNameDefText
        '
        Me.pPicNameDefText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pPicNameDefText.Location = New System.Drawing.Point(10, 89)
        Me.pPicNameDefText.Name = "pPicNameDefText"
        Me.pPicNameDefText.Size = New System.Drawing.Size(304, 20)
        Me.pPicNameDefText.TabIndex = 49
        '
        'Help8
        '
        Me.Help8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help8.Location = New System.Drawing.Point(299, 71)
        Me.Help8.Name = "Help8"
        Me.Help8.Size = New System.Drawing.Size(16, 16)
        Me.Help8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help8.TabIndex = 48
        Me.Help8.TabStop = False
        Me.Help8.Tag = "Environment/Options"
        '
        'pPicNameDefDescr
        '
        Me.pPicNameDefDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pPicNameDefDescr.BackColor = System.Drawing.Color.Transparent
        Me.pPicNameDefDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pPicNameDefDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.pPicNameDefDescr.Location = New System.Drawing.Point(3, 110)
        Me.pPicNameDefDescr.Name = "pPicNameDefDescr"
        Me.pPicNameDefDescr.Size = New System.Drawing.Size(312, 18)
        Me.pPicNameDefDescr.TabIndex = 47
        Me.pPicNameDefDescr.Tag = "1"
        Me.pPicNameDefDescr.Text = "В папке рисунков проекта будут файлы с такими именами"
        Me.pPicNameDefDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pPicNameDefLabel
        '
        Me.pPicNameDefLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pPicNameDefLabel.BackColor = System.Drawing.Color.Transparent
        Me.pPicNameDefLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pPicNameDefLabel.Location = New System.Drawing.Point(5, 68)
        Me.pPicNameDefLabel.Name = "pPicNameDefLabel"
        Me.pPicNameDefLabel.Size = New System.Drawing.Size(291, 18)
        Me.pPicNameDefLabel.TabIndex = 46
        Me.pPicNameDefLabel.Tag = "1"
        Me.pPicNameDefLabel.Text = "Имя для файлов рисунков по умолчанию"
        Me.pPicNameDefLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'iPathText
        '
        Me.iPathText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iPathText.Location = New System.Drawing.Point(10, 29)
        Me.iPathText.Name = "iPathText"
        Me.iPathText.Size = New System.Drawing.Size(304, 20)
        Me.iPathText.TabIndex = 45
        '
        'Help7
        '
        Me.Help7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help7.Location = New System.Drawing.Point(299, 11)
        Me.Help7.Name = "Help7"
        Me.Help7.Size = New System.Drawing.Size(16, 16)
        Me.Help7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help7.TabIndex = 44
        Me.Help7.TabStop = False
        Me.Help7.Tag = "Environment/Options"
        '
        'iPathDescr
        '
        Me.iPathDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iPathDescr.BackColor = System.Drawing.Color.Transparent
        Me.iPathDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.iPathDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.iPathDescr.Location = New System.Drawing.Point(5, 50)
        Me.iPathDescr.Name = "iPathDescr"
        Me.iPathDescr.Size = New System.Drawing.Size(308, 18)
        Me.iPathDescr.TabIndex = 43
        Me.iPathDescr.Tag = "1"
        Me.iPathDescr.Text = "Папка в проекте, куда сохраняются рисунки проекта"
        Me.iPathDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'iPathLabel
        '
        Me.iPathLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iPathLabel.BackColor = System.Drawing.Color.Transparent
        Me.iPathLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.iPathLabel.Location = New System.Drawing.Point(5, 8)
        Me.iPathLabel.Name = "iPathLabel"
        Me.iPathLabel.Size = New System.Drawing.Size(291, 18)
        Me.iPathLabel.TabIndex = 42
        Me.iPathLabel.Tag = "1"
        Me.iPathLabel.Text = "Папка с рисунками этого проекта"
        Me.iPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProcessorTab
        '
        Me.ProcessorTab.Controls.Add(Me.bistro_StatusLineDescr)
        Me.ProcessorTab.Controls.Add(Me.Help14)
        Me.ProcessorTab.Controls.Add(Me.bistro_StatusLineCheckBox)
        Me.ProcessorTab.Controls.Add(Me.bistro_podsvKovCheckBox)
        Me.ProcessorTab.Controls.Add(Me.bistro_podsvPMsCheckBox)
        Me.ProcessorTab.Controls.Add(Me.bistro_podsvObsCheckBox)
        Me.ProcessorTab.Controls.Add(Me.bistro_podsvHWCheckBox)
        Me.ProcessorTab.Controls.Add(Me.bistro_podsvDescr)
        Me.ProcessorTab.Controls.Add(Me.Help13)
        Me.ProcessorTab.Controls.Add(Me.bistro_podsvFunCheckBox)
        Me.ProcessorTab.Controls.Add(Me.bistro_UnReDescr)
        Me.ProcessorTab.Controls.Add(Me.Help12)
        Me.ProcessorTab.Controls.Add(Me.bistro_UnReCheckBox)
        Me.ProcessorTab.Controls.Add(Me.bistro_orfoDescr)
        Me.ProcessorTab.Controls.Add(Me.Help11)
        Me.ProcessorTab.Controls.Add(Me.bistro_orfoCheckBox)
        Me.ProcessorTab.Location = New System.Drawing.Point(4, 22)
        Me.ProcessorTab.Name = "ProcessorTab"
        Me.ProcessorTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ProcessorTab.Size = New System.Drawing.Size(320, 274)
        Me.ProcessorTab.TabIndex = 2
        Me.ProcessorTab.Text = "Быстродействие"
        Me.ProcessorTab.UseVisualStyleBackColor = True
        '
        'bistro_StatusLineDescr
        '
        Me.bistro_StatusLineDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bistro_StatusLineDescr.BackColor = System.Drawing.Color.Transparent
        Me.bistro_StatusLineDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.bistro_StatusLineDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.bistro_StatusLineDescr.Location = New System.Drawing.Point(3, 28)
        Me.bistro_StatusLineDescr.Name = "bistro_StatusLineDescr"
        Me.bistro_StatusLineDescr.Size = New System.Drawing.Size(308, 18)
        Me.bistro_StatusLineDescr.TabIndex = 68
        Me.bistro_StatusLineDescr.Tag = "1"
        Me.bistro_StatusLineDescr.Text = "Рекомендуется для медленных машин"
        Me.bistro_StatusLineDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Help14
        '
        Me.Help14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help14.Location = New System.Drawing.Point(296, 9)
        Me.Help14.Name = "Help14"
        Me.Help14.Size = New System.Drawing.Size(16, 16)
        Me.Help14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help14.TabIndex = 67
        Me.Help14.TabStop = False
        Me.Help14.Tag = "Environment/Options"
        '
        'bistro_StatusLineCheckBox
        '
        Me.bistro_StatusLineCheckBox.AutoSize = True
        Me.bistro_StatusLineCheckBox.Location = New System.Drawing.Point(7, 8)
        Me.bistro_StatusLineCheckBox.Name = "bistro_StatusLineCheckBox"
        Me.bistro_StatusLineCheckBox.Size = New System.Drawing.Size(224, 17)
        Me.bistro_StatusLineCheckBox.TabIndex = 66
        Me.bistro_StatusLineCheckBox.Text = "Мягкая оптимизация (рекомендуется!)"
        Me.bistro_StatusLineCheckBox.UseVisualStyleBackColor = True
        '
        'bistro_podsvKovCheckBox
        '
        Me.bistro_podsvKovCheckBox.AutoSize = True
        Me.bistro_podsvKovCheckBox.Location = New System.Drawing.Point(8, 233)
        Me.bistro_podsvKovCheckBox.Name = "bistro_podsvKovCheckBox"
        Me.bistro_podsvKovCheckBox.Size = New System.Drawing.Size(233, 17)
        Me.bistro_podsvKovCheckBox.TabIndex = 65
        Me.bistro_podsvKovCheckBox.Text = "Отключить подсветку текста в кавычках"
        Me.bistro_podsvKovCheckBox.UseVisualStyleBackColor = True
        '
        'bistro_podsvPMsCheckBox
        '
        Me.bistro_podsvPMsCheckBox.AutoSize = True
        Me.bistro_podsvPMsCheckBox.Location = New System.Drawing.Point(8, 210)
        Me.bistro_podsvPMsCheckBox.Name = "bistro_podsvPMsCheckBox"
        Me.bistro_podsvPMsCheckBox.Size = New System.Drawing.Size(230, 17)
        Me.bistro_podsvPMsCheckBox.TabIndex = 64
        Me.bistro_podsvPMsCheckBox.Text = "Отключить подсветку свойств и команд"
        Me.bistro_podsvPMsCheckBox.UseVisualStyleBackColor = True
        '
        'bistro_podsvObsCheckBox
        '
        Me.bistro_podsvObsCheckBox.AutoSize = True
        Me.bistro_podsvObsCheckBox.Location = New System.Drawing.Point(8, 187)
        Me.bistro_podsvObsCheckBox.Name = "bistro_podsvObsCheckBox"
        Me.bistro_podsvObsCheckBox.Size = New System.Drawing.Size(216, 17)
        Me.bistro_podsvObsCheckBox.TabIndex = 63
        Me.bistro_podsvObsCheckBox.Text = "Отключить подсветку имен объектов"
        Me.bistro_podsvObsCheckBox.UseVisualStyleBackColor = True
        '
        'bistro_podsvHWCheckBox
        '
        Me.bistro_podsvHWCheckBox.AutoSize = True
        Me.bistro_podsvHWCheckBox.Location = New System.Drawing.Point(8, 164)
        Me.bistro_podsvHWCheckBox.Name = "bistro_podsvHWCheckBox"
        Me.bistro_podsvHWCheckBox.Size = New System.Drawing.Size(257, 17)
        Me.bistro_podsvHWCheckBox.TabIndex = 62
        Me.bistro_podsvHWCheckBox.Text = "Отключить подсветку вспомогательных слов"
        Me.bistro_podsvHWCheckBox.UseVisualStyleBackColor = True
        '
        'bistro_podsvDescr
        '
        Me.bistro_podsvDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bistro_podsvDescr.BackColor = System.Drawing.Color.Transparent
        Me.bistro_podsvDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.bistro_podsvDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.bistro_podsvDescr.Location = New System.Drawing.Point(-7, 253)
        Me.bistro_podsvDescr.Name = "bistro_podsvDescr"
        Me.bistro_podsvDescr.Size = New System.Drawing.Size(331, 18)
        Me.bistro_podsvDescr.TabIndex = 61
        Me.bistro_podsvDescr.Tag = "1"
        Me.bistro_podsvDescr.Text = "Ускоряет создание действий благодаря отсутствию цветов"
        Me.bistro_podsvDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Help13
        '
        Me.Help13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help13.Location = New System.Drawing.Point(297, 142)
        Me.Help13.Name = "Help13"
        Me.Help13.Size = New System.Drawing.Size(16, 16)
        Me.Help13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help13.TabIndex = 60
        Me.Help13.TabStop = False
        Me.Help13.Tag = "Environment/Options"
        '
        'bistro_podsvFunCheckBox
        '
        Me.bistro_podsvFunCheckBox.AutoSize = True
        Me.bistro_podsvFunCheckBox.Location = New System.Drawing.Point(8, 141)
        Me.bistro_podsvFunCheckBox.Name = "bistro_podsvFunCheckBox"
        Me.bistro_podsvFunCheckBox.Size = New System.Drawing.Size(269, 17)
        Me.bistro_podsvFunCheckBox.TabIndex = 59
        Me.bistro_podsvFunCheckBox.Text = "Отключить подсветку дополнительных функций"
        Me.bistro_podsvFunCheckBox.UseVisualStyleBackColor = True
        '
        'bistro_UnReDescr
        '
        Me.bistro_UnReDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bistro_UnReDescr.BackColor = System.Drawing.Color.Transparent
        Me.bistro_UnReDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.bistro_UnReDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.bistro_UnReDescr.Location = New System.Drawing.Point(4, 110)
        Me.bistro_UnReDescr.Name = "bistro_UnReDescr"
        Me.bistro_UnReDescr.Size = New System.Drawing.Size(308, 18)
        Me.bistro_UnReDescr.TabIndex = 58
        Me.bistro_UnReDescr.Tag = "1"
        Me.bistro_UnReDescr.Text = "Ускорит при вставке большого количества объектов"
        Me.bistro_UnReDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Help12
        '
        Me.Help12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help12.Location = New System.Drawing.Point(297, 91)
        Me.Help12.Name = "Help12"
        Me.Help12.Size = New System.Drawing.Size(16, 16)
        Me.Help12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help12.TabIndex = 57
        Me.Help12.TabStop = False
        Me.Help12.Tag = "Environment/Options"
        '
        'bistro_UnReCheckBox
        '
        Me.bistro_UnReCheckBox.AutoSize = True
        Me.bistro_UnReCheckBox.Location = New System.Drawing.Point(8, 90)
        Me.bistro_UnReCheckBox.Name = "bistro_UnReCheckBox"
        Me.bistro_UnReCheckBox.Size = New System.Drawing.Size(265, 17)
        Me.bistro_UnReCheckBox.TabIndex = 56
        Me.bistro_UnReCheckBox.Text = "Отключить возможность Отменить/Повторить"
        Me.bistro_UnReCheckBox.UseVisualStyleBackColor = True
        '
        'bistro_orfoDescr
        '
        Me.bistro_orfoDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bistro_orfoDescr.BackColor = System.Drawing.Color.Transparent
        Me.bistro_orfoDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.bistro_orfoDescr.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.bistro_orfoDescr.Location = New System.Drawing.Point(4, 69)
        Me.bistro_orfoDescr.Name = "bistro_orfoDescr"
        Me.bistro_orfoDescr.Size = New System.Drawing.Size(308, 18)
        Me.bistro_orfoDescr.TabIndex = 55
        Me.bistro_orfoDescr.Tag = "1"
        Me.bistro_orfoDescr.Text = "Перед созданием действий не будет провряться верность"
        Me.bistro_orfoDescr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Help11
        '
        Me.Help11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Help11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help11.Location = New System.Drawing.Point(297, 50)
        Me.Help11.Name = "Help11"
        Me.Help11.Size = New System.Drawing.Size(16, 16)
        Me.Help11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Help11.TabIndex = 54
        Me.Help11.TabStop = False
        Me.Help11.Tag = "Environment/Options"
        '
        'bistro_orfoCheckBox
        '
        Me.bistro_orfoCheckBox.AutoSize = True
        Me.bistro_orfoCheckBox.Location = New System.Drawing.Point(8, 49)
        Me.bistro_orfoCheckBox.Name = "bistro_orfoCheckBox"
        Me.bistro_orfoCheckBox.Size = New System.Drawing.Size(265, 17)
        Me.bistro_orfoCheckBox.TabIndex = 53
        Me.bistro_orfoCheckBox.Text = "Отключить проверку написания команд и кода"
        Me.bistro_orfoCheckBox.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Cancel.BackColor = System.Drawing.Color.Transparent
        Me.Cancel.Location = New System.Drawing.Point(245, 302)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 1
        Me.Cancel.Text = "Отмена"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Ok
        '
        Me.Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ok.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Ok.BackColor = System.Drawing.Color.Transparent
        Me.Ok.Location = New System.Drawing.Point(164, 302)
        Me.Ok.Name = "Ok"
        Me.Ok.Size = New System.Drawing.Size(75, 23)
        Me.Ok.TabIndex = 2
        Me.Ok.Text = "Ok"
        Me.Ok.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'iconDescr2
        '
        Me.iconDescr2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iconDescr2.BackColor = System.Drawing.Color.Transparent
        Me.iconDescr2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.iconDescr2.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.iconDescr2.Location = New System.Drawing.Point(0, 189)
        Me.iconDescr2.Name = "iconDescr2"
        Me.iconDescr2.Size = New System.Drawing.Size(320, 18)
        Me.iconDescr2.TabIndex = 58
        Me.iconDescr2.Tag = "1"
        Me.iconDescr2.Text = "Для создания иконки из рисунка воспользуйтесь сайтом"
        Me.iconDescr2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(0, 207)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(320, 14)
        Me.LinkLabel1.TabIndex = 59
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "ConvertIcon.com"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(326, 328)
        Me.Controls.Add(Me.Ok)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Tab1)
        Me.MinimumSize = New System.Drawing.Size(334, 309)
        Me.Name = "OptionsForm"
        Me.Text = "Настройки"
        Me.Tab1.ResumeLayout(False)
        Me.CommonTab.ResumeLayout(False)
        Me.CommonTab.PerformLayout()
        CType(Me.Help6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Help5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.help3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Help2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.help1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProjectTab.ResumeLayout(False)
        Me.ProjectTab.PerformLayout()
        CType(Me.Help10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Help9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Help8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Help7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProcessorTab.ResumeLayout(False)
        Me.ProcessorTab.PerformLayout()
        CType(Me.Help14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Help13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Help12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Help11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As System.Windows.Forms.TabControl
    Friend WithEvents CommonTab As System.Windows.Forms.TabPage
    Friend WithEvents LanguageLabel As System.Windows.Forms.Label
    Friend WithEvents LanguageBox As System.Windows.Forms.ComboBox
    Friend WithEvents SkinBox As System.Windows.Forms.ComboBox
    Friend WithEvents ScinLabel As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Ok As System.Windows.Forms.Button
    Friend WithEvents LanguageLabelDescr As System.Windows.Forms.Label
    Friend WithEvents Language2LabelDescr As System.Windows.Forms.Label
    Friend WithEvents Language2Box As System.Windows.Forms.ComboBox
    Friend WithEvents Language2Label As System.Windows.Forms.Label
    Friend WithEvents ScinLabelDescr As System.Windows.Forms.Label
    Friend WithEvents help1 As System.Windows.Forms.PictureBox
    Friend WithEvents help3 As System.Windows.Forms.PictureBox
    Friend WithEvents Help2 As System.Windows.Forms.PictureBox
    Friend WithEvents Help5 As System.Windows.Forms.PictureBox
    Friend WithEvents pPathDescr As System.Windows.Forms.Label
    Friend WithEvents pPathLabel As System.Windows.Forms.Label
    Friend WithEvents pPathText As System.Windows.Forms.TextBox
    Friend WithEvents pPathBrows As System.Windows.Forms.Button
    Friend WithEvents iPathTextDef As System.Windows.Forms.TextBox
    Friend WithEvents Help6 As System.Windows.Forms.PictureBox
    Friend WithEvents iPathDescrDef As System.Windows.Forms.Label
    Friend WithEvents iPathLabelDef As System.Windows.Forms.Label
    Friend WithEvents ProjectTab As System.Windows.Forms.TabPage
    Friend WithEvents iPathText As System.Windows.Forms.TextBox
    Friend WithEvents Help7 As System.Windows.Forms.PictureBox
    Friend WithEvents iPathDescr As System.Windows.Forms.Label
    Friend WithEvents iPathLabel As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents pPicNameDefText As System.Windows.Forms.TextBox
    Friend WithEvents Help8 As System.Windows.Forms.PictureBox
    Friend WithEvents pPicNameDefDescr As System.Windows.Forms.Label
    Friend WithEvents pPicNameDefLabel As System.Windows.Forms.Label
    Friend WithEvents pProgressFormDescr As System.Windows.Forms.Label
    Friend WithEvents Help9 As System.Windows.Forms.PictureBox
    Friend WithEvents pProgressFormCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents iconText As System.Windows.Forms.TextBox
    Friend WithEvents Help10 As System.Windows.Forms.PictureBox
    Friend WithEvents iconDescr As System.Windows.Forms.Label
    Friend WithEvents iconLabel As System.Windows.Forms.Label
    Friend WithEvents iconBrows As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProcessorTab As System.Windows.Forms.TabPage
    Friend WithEvents bistro_orfoDescr As System.Windows.Forms.Label
    Friend WithEvents Help11 As System.Windows.Forms.PictureBox
    Friend WithEvents bistro_orfoCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents bistro_UnReDescr As System.Windows.Forms.Label
    Friend WithEvents Help12 As System.Windows.Forms.PictureBox
    Friend WithEvents bistro_UnReCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents bistro_podsvDescr As System.Windows.Forms.Label
    Friend WithEvents Help13 As System.Windows.Forms.PictureBox
    Friend WithEvents bistro_podsvFunCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents bistro_podsvKovCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents bistro_podsvPMsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents bistro_podsvObsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents bistro_podsvHWCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents bistro_StatusLineDescr As System.Windows.Forms.Label
    Friend WithEvents Help14 As System.Windows.Forms.PictureBox
    Friend WithEvents bistro_StatusLineCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents iconDescr2 As System.Windows.Forms.Label
End Class
