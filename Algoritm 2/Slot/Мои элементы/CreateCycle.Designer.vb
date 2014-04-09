<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateCycle
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
        Me.WhilePanel = New System.Windows.Forms.Panel
        Me.WhileLabel = New System.Windows.Forms.Label
        Me.forEditPrWhile = New System.Windows.Forms.Panel
        Me.PalkaWhile = New MyButton.MyButton
        Me.WhilePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'WhilePanel
        '
        Me.WhilePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WhilePanel.BackColor = System.Drawing.Color.Transparent
        Me.WhilePanel.Controls.Add(Me.WhileLabel)
        Me.WhilePanel.Controls.Add(Me.forEditPrWhile)
        Me.WhilePanel.Controls.Add(Me.PalkaWhile)
        Me.WhilePanel.Location = New System.Drawing.Point(0, 0)
        Me.WhilePanel.Name = "WhilePanel"
        Me.WhilePanel.Size = New System.Drawing.Size(281, 54)
        Me.WhilePanel.TabIndex = 0
        '
        'WhileLabel
        '
        Me.WhileLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WhileLabel.Location = New System.Drawing.Point(3, 7)
        Me.WhileLabel.Name = "WhileLabel"
        Me.WhileLabel.Size = New System.Drawing.Size(275, 13)
        Me.WhileLabel.TabIndex = 10
        Me.WhileLabel.Text = "Повторяться пока выполняется условие:"
        Me.WhileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'forEditPrWhile
        '
        Me.forEditPrWhile.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forEditPrWhile.AutoSize = True
        Me.forEditPrWhile.BackColor = System.Drawing.Color.Transparent
        Me.forEditPrWhile.Location = New System.Drawing.Point(3, 23)
        Me.forEditPrWhile.Name = "forEditPrWhile"
        Me.forEditPrWhile.Size = New System.Drawing.Size(249, 26)
        Me.forEditPrWhile.TabIndex = 4
        '
        'PalkaWhile
        '
        Me.PalkaWhile.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PalkaWhile.BackColor = System.Drawing.Color.Transparent
        Me.PalkaWhile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PalkaWhile.ImageList = Nothing
        Me.PalkaWhile.Location = New System.Drawing.Point(256, 23)
        Me.PalkaWhile.Name = "PalkaWhile"
        Me.PalkaWhile.Size = New System.Drawing.Size(22, 22)
        Me.PalkaWhile.TabIndex = 25
        Me.PalkaWhile.Type = "Master"
        '
        'CreateCycle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.WhilePanel)
        Me.Name = "CreateCycle"
        Me.Size = New System.Drawing.Size(283, 55)
        Me.WhilePanel.ResumeLayout(False)
        Me.WhilePanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WhilePanel As System.Windows.Forms.Panel
    Friend WithEvents forEditPrWhile As System.Windows.Forms.Panel
    Friend WithEvents WhileLabel As System.Windows.Forms.Label
    Friend WithEvents PalkaWhile As MyButton.MyButton

End Class
