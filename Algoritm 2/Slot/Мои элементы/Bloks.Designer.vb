<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bloks
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
        Me.PlusRight = New System.Windows.Forms.Button
        Me.PlusLeft = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'PlusRight
        '
        Me.PlusRight.ForeColor = System.Drawing.Color.Black
        Me.PlusRight.Location = New System.Drawing.Point(37, 3)
        Me.PlusRight.Name = "PlusRight"
        Me.PlusRight.Size = New System.Drawing.Size(22, 22)
        Me.PlusRight.TabIndex = 17
        Me.PlusRight.Text = "+"
        Me.PlusRight.UseVisualStyleBackColor = True
        '
        'PlusLeft
        '
        Me.PlusLeft.ForeColor = System.Drawing.Color.Black
        Me.PlusLeft.Location = New System.Drawing.Point(3, 3)
        Me.PlusLeft.Name = "PlusLeft"
        Me.PlusLeft.Size = New System.Drawing.Size(22, 22)
        Me.PlusLeft.TabIndex = 18
        Me.PlusLeft.Text = "+"
        Me.PlusLeft.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Bloks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PlusLeft)
        Me.Controls.Add(Me.PlusRight)
        Me.Name = "Bloks"
        Me.Size = New System.Drawing.Size(62, 28)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlusRight As System.Windows.Forms.Button
    Friend WithEvents PlusLeft As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
