<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateDeistv
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
        Me.forShowObj = New System.Windows.Forms.Panel
        Me.TopLabel = New System.Windows.Forms.Label
        Me.forEditPr = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'forShowObj
        '
        Me.forShowObj.BackColor = System.Drawing.Color.Transparent
        Me.forShowObj.Location = New System.Drawing.Point(4, 19)
        Me.forShowObj.Name = "forShowObj"
        Me.forShowObj.Size = New System.Drawing.Size(292, 84)
        Me.forShowObj.TabIndex = 0
        '
        'TopLabel
        '
        Me.TopLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TopLabel.Location = New System.Drawing.Point(1, 0)
        Me.TopLabel.Name = "TopLabel"
        Me.TopLabel.Size = New System.Drawing.Size(298, 16)
        Me.TopLabel.TabIndex = 1
        Me.TopLabel.Text = "Изменить следующее свойство"
        Me.TopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'forEditPr
        '
        Me.forEditPr.BackColor = System.Drawing.Color.Transparent
        Me.forEditPr.Location = New System.Drawing.Point(4, 107)
        Me.forEditPr.Name = "forEditPr"
        Me.forEditPr.Size = New System.Drawing.Size(292, 10)
        Me.forEditPr.TabIndex = 3
        '
        'CreateDeistv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.forEditPr)
        Me.Controls.Add(Me.TopLabel)
        Me.Controls.Add(Me.forShowObj)
        Me.Name = "CreateDeistv"
        Me.Size = New System.Drawing.Size(303, 122)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents forShowObj As System.Windows.Forms.Panel
    Friend WithEvents TopLabel As System.Windows.Forms.Label
    Friend WithEvents forEditPr As System.Windows.Forms.Panel

End Class
