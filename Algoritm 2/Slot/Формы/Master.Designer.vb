<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Master
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
        Me.components = New System.ComponentModel.Container
        Me.Ok = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Cancel = New System.Windows.Forms.Button
        Me.MasterPanel = New System.Windows.Forms.Panel
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RamkaCDSplit = New System.Windows.Forms.SplitContainer
        Me.InfoPropsLabel = New System.Windows.Forms.LinkLabel
        Me.MasterPanel.SuspendLayout()
        Me.RamkaCDSplit.Panel1.SuspendLayout()
        Me.RamkaCDSplit.Panel2.SuspendLayout()
        Me.RamkaCDSplit.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ok
        '
        Me.Ok.BackColor = System.Drawing.Color.Transparent
        Me.Ok.Location = New System.Drawing.Point(3, 206)
        Me.Ok.Name = "Ok"
        Me.Ok.Size = New System.Drawing.Size(57, 35)
        Me.Ok.TabIndex = 0
        Me.Ok.Text = "Ok"
        Me.Ok.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(0, 0)
        Me.Panel1.TabIndex = 1
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.Color.Transparent
        Me.Cancel.Location = New System.Drawing.Point(66, 206)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(57, 35)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "Отмена"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'MasterPanel
        '
        Me.MasterPanel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MasterPanel.AutoSize = True
        Me.MasterPanel.BackColor = System.Drawing.Color.Tan
        Me.MasterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MasterPanel.Controls.Add(Me.Panel1)
        Me.MasterPanel.Controls.Add(Me.Cancel)
        Me.MasterPanel.Controls.Add(Me.Ok)
        Me.MasterPanel.Location = New System.Drawing.Point(0, -1)
        Me.MasterPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MasterPanel.Name = "MasterPanel"
        Me.MasterPanel.Size = New System.Drawing.Size(132, 246)
        Me.MasterPanel.TabIndex = 3
        Me.MasterPanel.Tag = """)"""
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar1.LargeChange = 20
        Me.HScrollBar1.Location = New System.Drawing.Point(0, 260)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(402, 17)
        Me.HScrollBar1.SmallChange = 5
        Me.HScrollBar1.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'RamkaCDSplit
        '
        Me.RamkaCDSplit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RamkaCDSplit.BackColor = System.Drawing.Color.Transparent
        Me.RamkaCDSplit.Location = New System.Drawing.Point(0, 0)
        Me.RamkaCDSplit.Name = "RamkaCDSplit"
        Me.RamkaCDSplit.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'RamkaCDSplit.Panel1
        '
        Me.RamkaCDSplit.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.RamkaCDSplit.Panel1.Controls.Add(Me.HScrollBar1)
        Me.RamkaCDSplit.Panel1.Controls.Add(Me.MasterPanel)
        '
        'RamkaCDSplit.Panel2
        '
        Me.RamkaCDSplit.Panel2.Controls.Add(Me.InfoPropsLabel)
        Me.RamkaCDSplit.Panel2MinSize = 0
        Me.RamkaCDSplit.Size = New System.Drawing.Size(402, 365)
        Me.RamkaCDSplit.SplitterDistance = 278
        Me.RamkaCDSplit.SplitterWidth = 2
        Me.RamkaCDSplit.TabIndex = 5
        '
        'InfoPropsLabel
        '
        Me.InfoPropsLabel.AutoEllipsis = True
        Me.InfoPropsLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InfoPropsLabel.LinkArea = New System.Windows.Forms.LinkArea(70, 100)
        Me.InfoPropsLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.InfoPropsLabel.LinkColor = System.Drawing.Color.OrangeRed
        Me.InfoPropsLabel.Location = New System.Drawing.Point(0, 0)
        Me.InfoPropsLabel.Name = "InfoPropsLabel"
        Me.InfoPropsLabel.Size = New System.Drawing.Size(402, 85)
        Me.InfoPropsLabel.TabIndex = 3
        Me.InfoPropsLabel.TabStop = True
        Me.InfoPropsLabel.Text = "В этом окне вы можете создавать действия любой сложности. Подробнее о Мастере сло" & _
            "жных действий"
        Me.InfoPropsLabel.UseCompatibleTextRendering = True
        Me.InfoPropsLabel.VisitedLinkColor = System.Drawing.Color.Gold
        '
        'Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(402, 364)
        Me.Controls.Add(Me.RamkaCDSplit)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(410, 300)
        Me.Name = "Master"
        Me.Text = "Master"
        Me.MasterPanel.ResumeLayout(False)
        Me.MasterPanel.PerformLayout()
        Me.RamkaCDSplit.Panel1.ResumeLayout(False)
        Me.RamkaCDSplit.Panel1.PerformLayout()
        Me.RamkaCDSplit.Panel2.ResumeLayout(False)
        Me.RamkaCDSplit.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ok As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents MasterPanel As System.Windows.Forms.Panel
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents RamkaCDSplit As System.Windows.Forms.SplitContainer
    Public WithEvents InfoPropsLabel As System.Windows.Forms.LinkLabel
End Class
