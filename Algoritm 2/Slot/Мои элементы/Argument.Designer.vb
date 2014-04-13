<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Argument
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
        Me.ArgLabel = New System.Windows.Forms.Label
        Me.forEditPr = New System.Windows.Forms.Panel
        Me.Palka1 = New MyButton.MyButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'ArgLabel
        '
        Me.ArgLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ArgLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ArgLabel.Location = New System.Drawing.Point(5, 2)
        Me.ArgLabel.Name = "ArgLabel"
        Me.ArgLabel.Size = New System.Drawing.Size(307, 14)
        Me.ArgLabel.TabIndex = 2
        Me.ArgLabel.Text = "Аргумент1"
        Me.ArgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'forEditPr
        '
        Me.forEditPr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forEditPr.BackColor = System.Drawing.Color.Transparent
        Me.forEditPr.Location = New System.Drawing.Point(3, 19)
        Me.forEditPr.Name = "forEditPr"
        Me.forEditPr.Size = New System.Drawing.Size(287, 22)
        Me.forEditPr.TabIndex = 3
        '
        'Palka1
        '
        Me.Palka1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Palka1.BackColor = System.Drawing.Color.Transparent
        Me.Palka1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Palka1.ImageList = Nothing
        Me.Palka1.Location = New System.Drawing.Point(292, 19)
        Me.Palka1.Name = "Palka1"
        Me.Palka1.Size = New System.Drawing.Size(22, 22)
        Me.Palka1.TabIndex = 10
        Me.Palka1.Type = "Master"
        '
        'Argument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Palka1)
        Me.Controls.Add(Me.forEditPr)
        Me.Controls.Add(Me.ArgLabel)
        Me.Name = "Argument"
        Me.Size = New System.Drawing.Size(314, 44)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ArgLabel As System.Windows.Forms.Label
    Friend WithEvents forEditPr As System.Windows.Forms.Panel
    Friend WithEvents Palka1 As MyButton.MyButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
