<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Update
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
        Me.MainLabel = New System.Windows.Forms.Label()
        Me.DownloadButton = New System.Windows.Forms.Button()
        Me.SkipCheckBox = New System.Windows.Forms.CheckBox()
        Me.InfoPanel = New System.Windows.Forms.Panel()
        Me.LaterButton = New System.Windows.Forms.Button()
        Me.UpdateFreePanel = New System.Windows.Forms.Panel()
        Me.DownloadLabel = New System.Windows.Forms.Label()
        Me.UpdatePayPanel = New System.Windows.Forms.Panel()
        Me.DoneButton = New System.Windows.Forms.Button()
        Me.UrlTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.InfoPanel.SuspendLayout()
        Me.UpdateFreePanel.SuspendLayout()
        Me.UpdatePayPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainLabel
        '
        Me.MainLabel.BackColor = System.Drawing.Color.Transparent
        Me.MainLabel.ForeColor = System.Drawing.Color.AliceBlue
        Me.MainLabel.Location = New System.Drawing.Point(5, 4)
        Me.MainLabel.Name = "MainLabel"
        Me.MainLabel.Size = New System.Drawing.Size(370, 33)
        Me.MainLabel.TabIndex = 0
        Me.MainLabel.Text = "Доступна новая версия программы - *! Загрузить её сейчас?"
        Me.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DownloadButton
        '
        Me.DownloadButton.BackColor = System.Drawing.Color.Transparent
        Me.DownloadButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownloadButton.Location = New System.Drawing.Point(90, 40)
        Me.DownloadButton.Name = "DownloadButton"
        Me.DownloadButton.Size = New System.Drawing.Size(98, 38)
        Me.DownloadButton.TabIndex = 2
        Me.DownloadButton.Text = "Загрузить"
        Me.DownloadButton.UseVisualStyleBackColor = False
        '
        'SkipCheckBox
        '
        Me.SkipCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.SkipCheckBox.ForeColor = System.Drawing.Color.AliceBlue
        Me.SkipCheckBox.Location = New System.Drawing.Point(93, 141)
        Me.SkipCheckBox.Name = "SkipCheckBox"
        Me.SkipCheckBox.Size = New System.Drawing.Size(199, 17)
        Me.SkipCheckBox.TabIndex = 3
        Me.SkipCheckBox.Text = "Пропустить это обновление"
        Me.SkipCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SkipCheckBox.UseVisualStyleBackColor = False
        '
        'InfoPanel
        '
        Me.InfoPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InfoPanel.BackColor = System.Drawing.Color.Transparent
        Me.InfoPanel.Controls.Add(Me.LaterButton)
        Me.InfoPanel.Controls.Add(Me.SkipCheckBox)
        Me.InfoPanel.Controls.Add(Me.DownloadButton)
        Me.InfoPanel.Controls.Add(Me.MainLabel)
        Me.InfoPanel.Location = New System.Drawing.Point(12, 2)
        Me.InfoPanel.Name = "InfoPanel"
        Me.InfoPanel.Size = New System.Drawing.Size(376, 163)
        Me.InfoPanel.TabIndex = 7
        '
        'LaterButton
        '
        Me.LaterButton.BackColor = System.Drawing.Color.Transparent
        Me.LaterButton.Location = New System.Drawing.Point(194, 40)
        Me.LaterButton.Name = "LaterButton"
        Me.LaterButton.Size = New System.Drawing.Size(98, 38)
        Me.LaterButton.TabIndex = 5
        Me.LaterButton.Text = "Напомнить позже"
        Me.LaterButton.UseVisualStyleBackColor = False
        '
        'UpdateFreePanel
        '
        Me.UpdateFreePanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UpdateFreePanel.BackColor = System.Drawing.Color.Transparent
        Me.UpdateFreePanel.Controls.Add(Me.DownloadLabel)
        Me.UpdateFreePanel.Location = New System.Drawing.Point(12, 5)
        Me.UpdateFreePanel.Name = "UpdateFreePanel"
        Me.UpdateFreePanel.Size = New System.Drawing.Size(376, 160)
        Me.UpdateFreePanel.TabIndex = 8
        '
        'DownloadLabel
        '
        Me.DownloadLabel.BackColor = System.Drawing.Color.Transparent
        Me.DownloadLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownloadLabel.ForeColor = System.Drawing.Color.AliceBlue
        Me.DownloadLabel.Location = New System.Drawing.Point(3, 12)
        Me.DownloadLabel.Name = "DownloadLabel"
        Me.DownloadLabel.Size = New System.Drawing.Size(370, 39)
        Me.DownloadLabel.TabIndex = 6
        Me.DownloadLabel.Text = "Загрузка..."
        Me.DownloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UpdatePayPanel
        '
        Me.UpdatePayPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UpdatePayPanel.BackColor = System.Drawing.Color.Transparent
        Me.UpdatePayPanel.Controls.Add(Me.DoneButton)
        Me.UpdatePayPanel.Controls.Add(Me.UrlTextBox)
        Me.UpdatePayPanel.Controls.Add(Me.Label1)
        Me.UpdatePayPanel.Location = New System.Drawing.Point(12, 9)
        Me.UpdatePayPanel.Name = "UpdatePayPanel"
        Me.UpdatePayPanel.Size = New System.Drawing.Size(377, 156)
        Me.UpdatePayPanel.TabIndex = 9
        '
        'DoneButton
        '
        Me.DoneButton.Location = New System.Drawing.Point(298, 48)
        Me.DoneButton.Name = "DoneButton"
        Me.DoneButton.Size = New System.Drawing.Size(75, 23)
        Me.DoneButton.TabIndex = 8
        Me.DoneButton.Text = "Готово"
        Me.DoneButton.UseVisualStyleBackColor = True
        '
        'UrlTextBox
        '
        Me.UrlTextBox.Location = New System.Drawing.Point(3, 50)
        Me.UrlTextBox.Name = "UrlTextBox"
        Me.UrlTextBox.Size = New System.Drawing.Size(289, 20)
        Me.UrlTextBox.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.AliceBlue
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(370, 48)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Введите, пожалуйста, ссылку для скачивания Алгоритма, которая вам пришла в пункте" & _
    " 2 в письме с ключем для Алгоритма"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Update
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 164)
        Me.Controls.Add(Me.InfoPanel)
        Me.Controls.Add(Me.UpdatePayPanel)
        Me.Controls.Add(Me.UpdateFreePanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Update"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Обновление"
        Me.TopMost = True
        Me.InfoPanel.ResumeLayout(False)
        Me.UpdateFreePanel.ResumeLayout(False)
        Me.UpdatePayPanel.ResumeLayout(False)
        Me.UpdatePayPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainLabel As System.Windows.Forms.Label
    Friend WithEvents DownloadButton As System.Windows.Forms.Button
    Friend WithEvents SkipCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents InfoPanel As System.Windows.Forms.Panel
    Friend WithEvents LaterButton As System.Windows.Forms.Button
    Friend WithEvents UpdateFreePanel As System.Windows.Forms.Panel
    Friend WithEvents DownloadLabel As System.Windows.Forms.Label
    Friend WithEvents UpdatePayPanel As System.Windows.Forms.Panel
    Friend WithEvents DoneButton As System.Windows.Forms.Button
    Friend WithEvents UrlTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
