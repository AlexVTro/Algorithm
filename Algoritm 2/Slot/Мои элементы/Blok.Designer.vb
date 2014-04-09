<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Blok
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
        Me.DopFunctions = New System.Windows.Forms.ComboBox
        Me.DopFunctionsLabel = New System.Windows.Forms.Label
        Me.forShowObj = New System.Windows.Forms.Panel
        Me.forEditPr = New System.Windows.Forms.Panel
        Me.EditPrLabel = New System.Windows.Forms.Label
        Me.OpenCombo = New System.Windows.Forms.ComboBox
        Me.OpenLabel = New System.Windows.Forms.Label
        Me.CloseCombo = New System.Windows.Forms.ComboBox
        Me.CloseLabel = New System.Windows.Forms.Label
        Me.Remove1 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Palka1 = New MyButton.MyButton
        Me.TudaSuda1 = New MyButton.MyButton
        Me.SuspendLayout()
        '
        'DopFunctions
        '
        Me.DopFunctions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DopFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DopFunctions.DropDownWidth = 1
        Me.DopFunctions.FormattingEnabled = True
        Me.DopFunctions.Location = New System.Drawing.Point(37, 34)
        Me.DopFunctions.Name = "DopFunctions"
        Me.DopFunctions.Size = New System.Drawing.Size(106, 21)
        Me.DopFunctions.TabIndex = 11
        '
        'DopFunctionsLabel
        '
        Me.DopFunctionsLabel.Location = New System.Drawing.Point(37, 19)
        Me.DopFunctionsLabel.Name = "DopFunctionsLabel"
        Me.DopFunctionsLabel.Size = New System.Drawing.Size(106, 15)
        Me.DopFunctionsLabel.TabIndex = 12
        Me.DopFunctionsLabel.Text = "Доп. функция"
        Me.DopFunctionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'forShowObj
        '
        Me.forShowObj.AutoSize = True
        Me.forShowObj.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.forShowObj.Location = New System.Drawing.Point(-2, 57)
        Me.forShowObj.Name = "forShowObj"
        Me.forShowObj.Size = New System.Drawing.Size(0, 0)
        Me.forShowObj.TabIndex = 14
        '
        'forEditPr
        '
        Me.forEditPr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forEditPr.Location = New System.Drawing.Point(3, 74)
        Me.forEditPr.Name = "forEditPr"
        Me.forEditPr.Size = New System.Drawing.Size(151, 22)
        Me.forEditPr.TabIndex = 15
        Me.forEditPr.Visible = False
        '
        'EditPrLabel
        '
        Me.EditPrLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditPrLabel.Location = New System.Drawing.Point(3, 57)
        Me.EditPrLabel.Name = "EditPrLabel"
        Me.EditPrLabel.Size = New System.Drawing.Size(175, 17)
        Me.EditPrLabel.TabIndex = 17
        Me.EditPrLabel.Text = "Значение"
        Me.EditPrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.EditPrLabel.Visible = False
        '
        'OpenCombo
        '
        Me.OpenCombo.DropDownWidth = 1
        Me.OpenCombo.Font = New System.Drawing.Font("Rockwell Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenCombo.FormattingEnabled = True
        Me.OpenCombo.Items.AddRange(New Object() {"", "(", "((", "(((", "((((", "((((("})
        Me.OpenCombo.Location = New System.Drawing.Point(3, 35)
        Me.OpenCombo.Name = "OpenCombo"
        Me.OpenCombo.Size = New System.Drawing.Size(32, 21)
        Me.OpenCombo.TabIndex = 18
        Me.OpenCombo.Tag = "("
        '
        'OpenLabel
        '
        Me.OpenLabel.Location = New System.Drawing.Point(3, 18)
        Me.OpenLabel.Name = "OpenLabel"
        Me.OpenLabel.Size = New System.Drawing.Size(32, 15)
        Me.OpenLabel.TabIndex = 19
        Me.OpenLabel.Tag = """("""
        Me.OpenLabel.Text = """("""
        Me.OpenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseCombo
        '
        Me.CloseCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseCombo.DropDownWidth = 1
        Me.CloseCombo.Font = New System.Drawing.Font("Rockwell Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseCombo.FormattingEnabled = True
        Me.CloseCombo.Items.AddRange(New Object() {"", ")", "))", ")))", "))))", ")))))"})
        Me.CloseCombo.Location = New System.Drawing.Point(146, 35)
        Me.CloseCombo.Name = "CloseCombo"
        Me.CloseCombo.Size = New System.Drawing.Size(32, 21)
        Me.CloseCombo.TabIndex = 20
        Me.CloseCombo.Tag = ")"
        '
        'CloseLabel
        '
        Me.CloseLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseLabel.Location = New System.Drawing.Point(146, 18)
        Me.CloseLabel.Name = "CloseLabel"
        Me.CloseLabel.Size = New System.Drawing.Size(32, 15)
        Me.CloseLabel.TabIndex = 22
        Me.CloseLabel.Tag = """)"""
        Me.CloseLabel.Text = """)"""
        Me.CloseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Remove1
        '
        Me.Remove1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Remove1.Font = New System.Drawing.Font("Arial", 3.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Remove1.ForeColor = System.Drawing.Color.Black
        Me.Remove1.Location = New System.Drawing.Point(166, 3)
        Me.Remove1.Name = "Remove1"
        Me.Remove1.Size = New System.Drawing.Size(14, 14)
        Me.Remove1.TabIndex = 23
        Me.Remove1.Text = "X"
        Me.Remove1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Palka1
        '
        Me.Palka1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Palka1.BackColor = System.Drawing.Color.Transparent
        Me.Palka1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Palka1.ImageList = Nothing
        Me.Palka1.Location = New System.Drawing.Point(156, 74)
        Me.Palka1.Name = "Palka1"
        Me.Palka1.Size = New System.Drawing.Size(22, 22)
        Me.Palka1.TabIndex = 24
        Me.Palka1.Type = "Master"
        '
        'TudaSuda1
        '
        Me.TudaSuda1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TudaSuda1.BackColor = System.Drawing.Color.Transparent
        Me.TudaSuda1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TudaSuda1.ImageList = Nothing
        Me.TudaSuda1.Location = New System.Drawing.Point(78, 102)
        Me.TudaSuda1.Name = "TudaSuda1"
        Me.TudaSuda1.Size = New System.Drawing.Size(22, 22)
        Me.TudaSuda1.TabIndex = 25
        Me.TudaSuda1.Type = "Down"
        '
        'Blok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Remove1)
        Me.Controls.Add(Me.CloseLabel)
        Me.Controls.Add(Me.CloseCombo)
        Me.Controls.Add(Me.OpenLabel)
        Me.Controls.Add(Me.OpenCombo)
        Me.Controls.Add(Me.EditPrLabel)
        Me.Controls.Add(Me.forEditPr)
        Me.Controls.Add(Me.DopFunctionsLabel)
        Me.Controls.Add(Me.DopFunctions)
        Me.Controls.Add(Me.forShowObj)
        Me.Controls.Add(Me.Palka1)
        Me.Controls.Add(Me.TudaSuda1)
        Me.MaximumSize = New System.Drawing.Size(182, 0)
        Me.Name = "Blok"
        Me.Size = New System.Drawing.Size(182, 127)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DopFunctions As System.Windows.Forms.ComboBox
    Friend WithEvents DopFunctionsLabel As System.Windows.Forms.Label
    Friend WithEvents forShowObj As System.Windows.Forms.Panel
    Friend WithEvents forEditPr As System.Windows.Forms.Panel
    Friend WithEvents EditPrLabel As System.Windows.Forms.Label
    Friend WithEvents OpenCombo As System.Windows.Forms.ComboBox
    Friend WithEvents OpenLabel As System.Windows.Forms.Label
    Friend WithEvents CloseCombo As System.Windows.Forms.ComboBox
    Friend WithEvents CloseLabel As System.Windows.Forms.Label
    Friend WithEvents Remove1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Palka1 As MyButton.MyButton
    Friend WithEvents TudaSuda1 As MyButton.MyButton

End Class
