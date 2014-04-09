<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mecenat
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
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label5 = New System.Windows.Forms.Label
        Me.LabelBenef = New System.Windows.Forms.LinkLabel
        Me.LabelModers = New System.Windows.Forms.LinkLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.LinkColor = System.Drawing.Color.CornflowerBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 282)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(106, 13)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "www.Algorithm2.com"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(238, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 57)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Pantograph" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Daiomik" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Saraev"
        '
        'LabelBenef
        '
        Me.LabelBenef.BackColor = System.Drawing.Color.Transparent
        Me.LabelBenef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelBenef.LinkColor = System.Drawing.Color.White
        Me.LabelBenef.Location = New System.Drawing.Point(64, 9)
        Me.LabelBenef.Name = "LabelBenef"
        Me.LabelBenef.Size = New System.Drawing.Size(127, 19)
        Me.LabelBenef.TabIndex = 5
        Me.LabelBenef.TabStop = True
        Me.LabelBenef.Text = "Благотворители:"
        '
        'LabelModers
        '
        Me.LabelModers.BackColor = System.Drawing.Color.Transparent
        Me.LabelModers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelModers.LinkColor = System.Drawing.Color.White
        Me.LabelModers.Location = New System.Drawing.Point(238, 9)
        Me.LabelModers.Name = "LabelModers"
        Me.LabelModers.Size = New System.Drawing.Size(127, 19)
        Me.LabelModers.TabIndex = 8
        Me.LabelModers.TabStop = True
        Me.LabelModers.Text = "Модераторы:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(64, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "SnowBars"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(64, 28)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(100, 13)
        Me.LinkLabel2.TabIndex = 10
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Sinner (rasskaz.net)"
        '
        'Mecenat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 300)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelModers)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LabelBenef)
        Me.Controls.Add(Me.LinkLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Mecenat"
        Me.Text = "Благотворители"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LabelBenef As System.Windows.Forms.LinkLabel
    Friend WithEvents LabelModers As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
End Class
