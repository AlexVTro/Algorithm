<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateIf
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ifUsuallyPanel = New System.Windows.Forms.Panel
        Me.help1 = New System.Windows.Forms.PictureBox
        Me.forEditPrUsually = New System.Windows.Forms.Panel
        Me.ifUsually = New System.Windows.Forms.RadioButton
        Me.PalkaUsually = New MyButton.MyButton
        Me.IfPodIfPanel = New System.Windows.Forms.Panel
        Me.help2 = New System.Windows.Forms.PictureBox
        Me.forEditPrPodIf = New System.Windows.Forms.Panel
        Me.IfPodIf = New System.Windows.Forms.RadioButton
        Me.PalkaPodIf = New MyButton.MyButton
        Me.ifElsePanel = New System.Windows.Forms.Panel
        Me.help3 = New System.Windows.Forms.PictureBox
        Me.ifElse = New System.Windows.Forms.RadioButton
        Me.LabelIf = New System.Windows.Forms.Label
        Me.LabelThen = New System.Windows.Forms.Label
        Me.LabelElseIf = New System.Windows.Forms.Label
        Me.LabelThen2 = New System.Windows.Forms.Label
        Me.ifUsuallyPanel.SuspendLayout()
        CType(Me.help1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IfPodIfPanel.SuspendLayout()
        CType(Me.help2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ifElsePanel.SuspendLayout()
        CType(Me.help3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ifUsuallyPanel
        '
        Me.ifUsuallyPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ifUsuallyPanel.BackColor = System.Drawing.Color.Transparent
        Me.ifUsuallyPanel.Controls.Add(Me.forEditPrUsually)
        Me.ifUsuallyPanel.Controls.Add(Me.PalkaUsually)
        Me.ifUsuallyPanel.Controls.Add(Me.LabelThen)
        Me.ifUsuallyPanel.Controls.Add(Me.LabelIf)
        Me.ifUsuallyPanel.Controls.Add(Me.help1)
        Me.ifUsuallyPanel.Controls.Add(Me.ifUsually)
        Me.ifUsuallyPanel.Location = New System.Drawing.Point(4, 4)
        Me.ifUsuallyPanel.Name = "ifUsuallyPanel"
        Me.ifUsuallyPanel.Size = New System.Drawing.Size(292, 54)
        Me.ifUsuallyPanel.TabIndex = 0
        '
        'help1
        '
        Me.help1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.help1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help1.Location = New System.Drawing.Point(247, 7)
        Me.help1.Name = "help1"
        Me.help1.Size = New System.Drawing.Size(16, 16)
        Me.help1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help1.TabIndex = 8
        Me.help1.TabStop = False
        Me.help1.Tag = "Environment/IfPart"
        '
        'forEditPrUsually
        '
        Me.forEditPrUsually.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forEditPrUsually.AutoSize = True
        Me.forEditPrUsually.BackColor = System.Drawing.Color.Transparent
        Me.forEditPrUsually.Location = New System.Drawing.Point(44, 23)
        Me.forEditPrUsually.Name = "forEditPrUsually"
        Me.forEditPrUsually.Size = New System.Drawing.Size(174, 26)
        Me.forEditPrUsually.TabIndex = 4
        '
        'ifUsually
        '
        Me.ifUsually.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ifUsually.Checked = True
        Me.ifUsually.Location = New System.Drawing.Point(8, 3)
        Me.ifUsually.Name = "ifUsually"
        Me.ifUsually.Size = New System.Drawing.Size(256, 21)
        Me.ifUsually.TabIndex = 2
        Me.ifUsually.TabStop = True
        Me.ifUsually.Text = "Создать условие"
        Me.ifUsually.UseVisualStyleBackColor = True
        '
        'PalkaUsually
        '
        Me.PalkaUsually.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PalkaUsually.BackColor = System.Drawing.Color.Transparent
        Me.PalkaUsually.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PalkaUsually.ImageList = Nothing
        Me.PalkaUsually.Location = New System.Drawing.Point(220, 23)
        Me.PalkaUsually.Name = "PalkaUsually"
        Me.PalkaUsually.Size = New System.Drawing.Size(22, 22)
        Me.PalkaUsually.TabIndex = 26
        Me.PalkaUsually.Type = "Master"
        '
        'IfPodIfPanel
        '
        Me.IfPodIfPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IfPodIfPanel.BackColor = System.Drawing.Color.Transparent
        Me.IfPodIfPanel.Controls.Add(Me.forEditPrPodIf)
        Me.IfPodIfPanel.Controls.Add(Me.PalkaPodIf)
        Me.IfPodIfPanel.Controls.Add(Me.LabelThen2)
        Me.IfPodIfPanel.Controls.Add(Me.help2)
        Me.IfPodIfPanel.Controls.Add(Me.IfPodIf)
        Me.IfPodIfPanel.Controls.Add(Me.LabelElseIf)
        Me.IfPodIfPanel.Location = New System.Drawing.Point(5, 64)
        Me.IfPodIfPanel.Name = "IfPodIfPanel"
        Me.IfPodIfPanel.Size = New System.Drawing.Size(292, 54)
        Me.IfPodIfPanel.TabIndex = 1
        '
        'help2
        '
        Me.help2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.help2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help2.Location = New System.Drawing.Point(246, 7)
        Me.help2.Name = "help2"
        Me.help2.Size = New System.Drawing.Size(16, 16)
        Me.help2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help2.TabIndex = 27
        Me.help2.TabStop = False
        Me.help2.Tag = "Environment/IfPart"
        '
        'forEditPrPodIf
        '
        Me.forEditPrPodIf.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forEditPrPodIf.AutoSize = True
        Me.forEditPrPodIf.BackColor = System.Drawing.Color.Transparent
        Me.forEditPrPodIf.Location = New System.Drawing.Point(70, 23)
        Me.forEditPrPodIf.Name = "forEditPrPodIf"
        Me.forEditPrPodIf.Size = New System.Drawing.Size(147, 26)
        Me.forEditPrPodIf.TabIndex = 4
        '
        'IfPodIf
        '
        Me.IfPodIf.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IfPodIf.Location = New System.Drawing.Point(8, 3)
        Me.IfPodIf.Name = "IfPodIf"
        Me.IfPodIf.Size = New System.Drawing.Size(255, 21)
        Me.IfPodIf.TabIndex = 2
        Me.IfPodIf.Text = "Создать подУсловие"
        Me.IfPodIf.UseVisualStyleBackColor = True
        '
        'PalkaPodIf
        '
        Me.PalkaPodIf.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PalkaPodIf.BackColor = System.Drawing.Color.Transparent
        Me.PalkaPodIf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PalkaPodIf.ImageList = Nothing
        Me.PalkaPodIf.Location = New System.Drawing.Point(219, 23)
        Me.PalkaPodIf.Name = "PalkaPodIf"
        Me.PalkaPodIf.Size = New System.Drawing.Size(22, 22)
        Me.PalkaPodIf.TabIndex = 26
        Me.PalkaPodIf.Type = "Master"
        '
        'ifElsePanel
        '
        Me.ifElsePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ifElsePanel.BackColor = System.Drawing.Color.Transparent
        Me.ifElsePanel.Controls.Add(Me.help3)
        Me.ifElsePanel.Controls.Add(Me.ifElse)
        Me.ifElsePanel.Location = New System.Drawing.Point(5, 124)
        Me.ifElsePanel.Name = "ifElsePanel"
        Me.ifElsePanel.Size = New System.Drawing.Size(292, 22)
        Me.ifElsePanel.TabIndex = 2
        '
        'help3
        '
        Me.help3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.help3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help3.Location = New System.Drawing.Point(247, 3)
        Me.help3.Name = "help3"
        Me.help3.Size = New System.Drawing.Size(16, 16)
        Me.help3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help3.TabIndex = 28
        Me.help3.TabStop = False
        Me.help3.Tag = "Environment/IfPart"
        '
        'ifElse
        '
        Me.ifElse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ifElse.Location = New System.Drawing.Point(8, 0)
        Me.ifElse.Name = "ifElse"
        Me.ifElse.Size = New System.Drawing.Size(255, 21)
        Me.ifElse.TabIndex = 2
        Me.ifElse.Text = "Создать раздел: ""во всех остальных случаях"""
        Me.ifElse.UseVisualStyleBackColor = True
        '
        'LabelIf
        '
        Me.LabelIf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelIf.Location = New System.Drawing.Point(3, 26)
        Me.LabelIf.Name = "LabelIf"
        Me.LabelIf.Size = New System.Drawing.Size(42, 23)
        Me.LabelIf.TabIndex = 27
        Me.LabelIf.Text = "ЕСЛИ"
        Me.LabelIf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelThen
        '
        Me.LabelThen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelThen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelThen.Location = New System.Drawing.Point(240, 30)
        Me.LabelThen.Name = "LabelThen"
        Me.LabelThen.Size = New System.Drawing.Size(50, 15)
        Me.LabelThen.TabIndex = 28
        Me.LabelThen.Text = "ТОГДА"
        Me.LabelThen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelElseIf
        '
        Me.LabelElseIf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelElseIf.Location = New System.Drawing.Point(4, 27)
        Me.LabelElseIf.Name = "LabelElseIf"
        Me.LabelElseIf.Size = New System.Drawing.Size(68, 22)
        Me.LabelElseIf.TabIndex = 29
        Me.LabelElseIf.Text = "ИЛИЕСЛИ"
        Me.LabelElseIf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelThen2
        '
        Me.LabelThen2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelThen2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelThen2.Location = New System.Drawing.Point(239, 32)
        Me.LabelThen2.Name = "LabelThen2"
        Me.LabelThen2.Size = New System.Drawing.Size(49, 13)
        Me.LabelThen2.TabIndex = 29
        Me.LabelThen2.Text = "ТОГДА"
        '
        'CreateIf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.ifElsePanel)
        Me.Controls.Add(Me.IfPodIfPanel)
        Me.Controls.Add(Me.ifUsuallyPanel)
        Me.Name = "CreateIf"
        Me.Size = New System.Drawing.Size(303, 149)
        Me.ifUsuallyPanel.ResumeLayout(False)
        Me.ifUsuallyPanel.PerformLayout()
        CType(Me.help1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IfPodIfPanel.ResumeLayout(False)
        Me.IfPodIfPanel.PerformLayout()
        CType(Me.help2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ifElsePanel.ResumeLayout(False)
        CType(Me.help3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ifUsuallyPanel As System.Windows.Forms.Panel
    Friend WithEvents forEditPrUsually As System.Windows.Forms.Panel
    Friend WithEvents ifUsually As System.Windows.Forms.RadioButton
    Friend WithEvents IfPodIfPanel As System.Windows.Forms.Panel
    Friend WithEvents forEditPrPodIf As System.Windows.Forms.Panel
    Friend WithEvents IfPodIf As System.Windows.Forms.RadioButton
    Friend WithEvents ifElsePanel As System.Windows.Forms.Panel
    Friend WithEvents ifElse As System.Windows.Forms.RadioButton
    Friend WithEvents PalkaUsually As MyButton.MyButton
    Friend WithEvents PalkaPodIf As MyButton.MyButton
    Friend WithEvents help1 As System.Windows.Forms.PictureBox
    Friend WithEvents help2 As System.Windows.Forms.PictureBox
    Friend WithEvents help3 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelIf As System.Windows.Forms.Label
    Friend WithEvents LabelThen As System.Windows.Forms.Label
    Friend WithEvents LabelThen2 As System.Windows.Forms.Label
    Friend WithEvents LabelElseIf As System.Windows.Forms.Label

End Class
