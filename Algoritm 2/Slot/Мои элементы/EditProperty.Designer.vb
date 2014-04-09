<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditProperty
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
        Me.components = New System.ComponentModel.Container
        Me.EditPicColor = New System.Windows.Forms.Panel
        Me.TextBox2 = New System.Windows.Forms.RichTextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.EditText = New System.Windows.Forms.Panel
        Me.TextBox1 = New System.Windows.Forms.RichTextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.EditOther = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.RichTextBox
        Me.ShowHideBut = New System.Windows.Forms.Button
        Me.EditPicColor.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EditText.SuspendLayout()
        Me.EditOther.SuspendLayout()
        Me.SuspendLayout()
        '
        'EditPicColor
        '
        Me.EditPicColor.BackColor = System.Drawing.Color.Transparent
        Me.EditPicColor.Controls.Add(Me.TextBox2)
        Me.EditPicColor.Controls.Add(Me.Button2)
        Me.EditPicColor.Controls.Add(Me.Button1)
        Me.EditPicColor.Controls.Add(Me.PictureBox1)
        Me.EditPicColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditPicColor.Location = New System.Drawing.Point(0, 0)
        Me.EditPicColor.Name = "EditPicColor"
        Me.EditPicColor.Size = New System.Drawing.Size(303, 42)
        Me.EditPicColor.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.EnableAutoDragDrop = True
        Me.TextBox2.Location = New System.Drawing.Point(18, 15)
        Me.TextBox2.Multiline = False
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(246, 15)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = ""
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.Location = New System.Drawing.Point(268, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 15)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "•••"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(268, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 15)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "•••"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Location = New System.Drawing.Point(2, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'EditText
        '
        Me.EditText.BackColor = System.Drawing.Color.Transparent
        Me.EditText.Controls.Add(Me.TextBox1)
        Me.EditText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditText.Location = New System.Drawing.Point(0, 0)
        Me.EditText.Name = "EditText"
        Me.EditText.Size = New System.Drawing.Size(303, 42)
        Me.EditText.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.CausesValidation = False
        Me.TextBox1.EnableAutoDragDrop = True
        Me.TextBox1.Location = New System.Drawing.Point(5, 15)
        Me.TextBox1.Multiline = False
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(284, 13)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "kljfg"
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'Timer2
        '
        Me.Timer2.Interval = 1
        '
        'EditOther
        '
        Me.EditOther.BackColor = System.Drawing.Color.Transparent
        Me.EditOther.Controls.Add(Me.Button3)
        Me.EditOther.Controls.Add(Me.TextBox3)
        Me.EditOther.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditOther.Location = New System.Drawing.Point(0, 0)
        Me.EditOther.Name = "EditOther"
        Me.EditOther.Size = New System.Drawing.Size(303, 42)
        Me.EditOther.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button3.Location = New System.Drawing.Point(3, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(20, 15)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "V"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.EnableAutoDragDrop = True
        Me.TextBox3.Location = New System.Drawing.Point(28, 15)
        Me.TextBox3.Multiline = False
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(262, 15)
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.Text = ""
        '
        'ShowHideBut
        '
        Me.ShowHideBut.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ShowHideBut.BackColor = System.Drawing.Color.Transparent
        Me.ShowHideBut.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ShowHideBut.Location = New System.Drawing.Point(285, 12)
        Me.ShowHideBut.Margin = New System.Windows.Forms.Padding(0)
        Me.ShowHideBut.Name = "ShowHideBut"
        Me.ShowHideBut.Size = New System.Drawing.Size(14, 15)
        Me.ShowHideBut.TabIndex = 5
        Me.ShowHideBut.Text = "v"
        Me.ShowHideBut.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ShowHideBut.UseVisualStyleBackColor = False
        '
        'EditProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.ShowHideBut)
        Me.Controls.Add(Me.EditPicColor)
        Me.Controls.Add(Me.EditText)
        Me.Controls.Add(Me.EditOther)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "EditProperty"
        Me.Size = New System.Drawing.Size(303, 42)
        Me.EditPicColor.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EditText.ResumeLayout(False)
        Me.EditOther.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EditPicColor As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents EditText As System.Windows.Forms.Panel
    Friend WithEvents TextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents EditOther As System.Windows.Forms.Panel
    Friend WithEvents TextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ShowHideBut As System.Windows.Forms.Button

End Class
