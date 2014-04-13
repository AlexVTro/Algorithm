<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowObject
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.propertys = New System.Windows.Forms.ComboBox
        Me.indexs = New System.Windows.Forms.ComboBox
        Me.objects = New System.Windows.Forms.ComboBox
        Me.forms = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.forArgs = New System.Windows.Forms.Panel
        Me.Palka1 = New MyButton.MyButton
        Me.help1 = New System.Windows.Forms.PictureBox
        Me.help2 = New System.Windows.Forms.PictureBox
        Me.help3 = New System.Windows.Forms.PictureBox
        Me.help4 = New System.Windows.Forms.PictureBox
        CType(Me.help1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.help2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.help3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.help4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(4, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Объект"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(5, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Номер"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(4, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Свойство"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'propertys
        '
        Me.propertys.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.propertys.DropDownWidth = 300
        Me.propertys.FormattingEnabled = True
        Me.propertys.Location = New System.Drawing.Point(4, 123)
        Me.propertys.Name = "propertys"
        Me.propertys.Size = New System.Drawing.Size(178, 21)
        Me.propertys.TabIndex = 4
        '
        'indexs
        '
        Me.indexs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.indexs.DropDownWidth = 300
        Me.indexs.FormattingEnabled = True
        Me.indexs.Items.AddRange(New Object() {"дл", "щз", "ьб"})
        Me.indexs.Location = New System.Drawing.Point(4, 87)
        Me.indexs.Name = "indexs"
        Me.indexs.Size = New System.Drawing.Size(155, 21)
        Me.indexs.TabIndex = 2
        '
        'objects
        '
        Me.objects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.objects.DropDownWidth = 300
        Me.objects.FormattingEnabled = True
        Me.objects.Location = New System.Drawing.Point(4, 51)
        Me.objects.Name = "objects"
        Me.objects.Size = New System.Drawing.Size(178, 21)
        Me.objects.TabIndex = 1
        '
        'forms
        '
        Me.forms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.forms.DropDownWidth = 300
        Me.forms.FormattingEnabled = True
        Me.forms.Location = New System.Drawing.Point(4, 15)
        Me.forms.Name = "forms"
        Me.forms.Size = New System.Drawing.Size(178, 21)
        Me.forms.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(4, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Окно"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'forArgs
        '
        Me.forArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forArgs.AutoSize = True
        Me.forArgs.BackColor = System.Drawing.Color.Transparent
        Me.forArgs.Location = New System.Drawing.Point(2, 148)
        Me.forArgs.Name = "forArgs"
        Me.forArgs.Size = New System.Drawing.Size(184, 0)
        Me.forArgs.TabIndex = 9
        '
        'Palka1
        '
        Me.Palka1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Palka1.BackColor = System.Drawing.Color.Transparent
        Me.Palka1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Palka1.ImageList = Nothing
        Me.Palka1.Location = New System.Drawing.Point(160, 86)
        Me.Palka1.Name = "Palka1"
        Me.Palka1.Size = New System.Drawing.Size(22, 22)
        Me.Palka1.TabIndex = 27
        Me.Palka1.Type = "Master"
        '
        'help1
        '
        Me.help1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.help1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help1.Location = New System.Drawing.Point(110, 1)
        Me.help1.Name = "help1"
        Me.help1.Size = New System.Drawing.Size(14, 14)
        Me.help1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help1.TabIndex = 28
        Me.help1.TabStop = False
        Me.help1.Tag = "Environment/EventPart"
        '
        'help2
        '
        Me.help2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.help2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help2.Location = New System.Drawing.Point(113, 37)
        Me.help2.Name = "help2"
        Me.help2.Size = New System.Drawing.Size(14, 14)
        Me.help2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help2.TabIndex = 29
        Me.help2.TabStop = False
        Me.help2.Tag = "Environment/EventPart"
        '
        'help3
        '
        Me.help3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.help3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help3.Location = New System.Drawing.Point(112, 73)
        Me.help3.Name = "help3"
        Me.help3.Size = New System.Drawing.Size(14, 14)
        Me.help3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help3.TabIndex = 30
        Me.help3.TabStop = False
        Me.help3.Tag = "Environment/EventPart"
        '
        'help4
        '
        Me.help4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.help4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help4.Location = New System.Drawing.Point(119, 109)
        Me.help4.Name = "help4"
        Me.help4.Size = New System.Drawing.Size(14, 14)
        Me.help4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help4.TabIndex = 31
        Me.help4.TabStop = False
        Me.help4.Tag = "Environment/EventPart"
        '
        'ShowObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Palka1)
        Me.Controls.Add(Me.objects)
        Me.Controls.Add(Me.propertys)
        Me.Controls.Add(Me.indexs)
        Me.Controls.Add(Me.help4)
        Me.Controls.Add(Me.help3)
        Me.Controls.Add(Me.help2)
        Me.Controls.Add(Me.help1)
        Me.Controls.Add(Me.forArgs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.forms)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "ShowObject"
        Me.Size = New System.Drawing.Size(186, 151)
        CType(Me.help1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.help2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.help3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.help4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents objects As System.Windows.Forms.ComboBox
    Friend WithEvents forms As System.Windows.Forms.ComboBox
    Friend WithEvents indexs As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents propertys As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents forArgs As System.Windows.Forms.Panel
    Friend WithEvents Palka1 As MyButton.MyButton
    Friend WithEvents help1 As System.Windows.Forms.PictureBox
    Friend WithEvents help2 As System.Windows.Forms.PictureBox
    Friend WithEvents help3 As System.Windows.Forms.PictureBox
    Friend WithEvents help4 As System.Windows.Forms.PictureBox

End Class
