<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientServerMy
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.pbServer = New System.Windows.Forms.ProgressBar
        Me.ComboType = New System.Windows.Forms.ComboBox
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.txtSend = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdSendFile = New System.Windows.Forms.Button
        Me.cmdCreateConn = New System.Windows.Forms.Button
        Me.cmdSendText = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'pbServer
        '
        Me.pbServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbServer.Location = New System.Drawing.Point(3, 264)
        Me.pbServer.Name = "pbServer"
        Me.pbServer.Size = New System.Drawing.Size(282, 14)
        Me.pbServer.TabIndex = 26
        '
        'ComboType
        '
        Me.ComboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboType.FormattingEnabled = True
        Me.ComboType.Items.AddRange(New Object() {"Сервер", "Клиент"})
        Me.ComboType.Location = New System.Drawing.Point(3, 3)
        Me.ComboType.Name = "ComboType"
        Me.ComboType.Size = New System.Drawing.Size(72, 21)
        Me.ComboType.TabIndex = 20
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Location = New System.Drawing.Point(3, 54)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(282, 204)
        Me.txtLog.TabIndex = 25
        '
        'txtSend
        '
        Me.txtSend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSend.Location = New System.Drawing.Point(3, 28)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(72, 20)
        Me.txtSend.TabIndex = 24
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Enabled = False
        Me.cmdClose.Location = New System.Drawing.Point(185, 1)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(100, 23)
        Me.cmdClose.TabIndex = 23
        Me.cmdClose.Text = "Стоп поиск"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdSendFile
        '
        Me.cmdSendFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSendFile.Enabled = False
        Me.cmdSendFile.Location = New System.Drawing.Point(185, 26)
        Me.cmdSendFile.Name = "cmdSendFile"
        Me.cmdSendFile.Size = New System.Drawing.Size(100, 23)
        Me.cmdSendFile.TabIndex = 22
        Me.cmdSendFile.Text = "Отправить файл"
        Me.cmdSendFile.UseVisualStyleBackColor = True
        '
        'cmdCreateConn
        '
        Me.cmdCreateConn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateConn.Location = New System.Drawing.Point(81, 1)
        Me.cmdCreateConn.Name = "cmdCreateConn"
        Me.cmdCreateConn.Size = New System.Drawing.Size(100, 23)
        Me.cmdCreateConn.TabIndex = 19
        Me.cmdCreateConn.Text = "Создать"
        Me.cmdCreateConn.UseVisualStyleBackColor = True
        '
        'cmdSendText
        '
        Me.cmdSendText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSendText.Enabled = False
        Me.cmdSendText.Location = New System.Drawing.Point(81, 26)
        Me.cmdSendText.Name = "cmdSendText"
        Me.cmdSendText.Size = New System.Drawing.Size(100, 23)
        Me.cmdSendText.TabIndex = 21
        Me.cmdSendText.Text = "Отправить текст"
        Me.cmdSendText.UseVisualStyleBackColor = True
        '
        'ClientServerMy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Controls.Add(Me.pbServer)
        Me.Controls.Add(Me.ComboType)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.txtSend)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSendFile)
        Me.Controls.Add(Me.cmdCreateConn)
        Me.Controls.Add(Me.cmdSendText)
        Me.Name = "ClientServerMy"
        Me.Size = New System.Drawing.Size(288, 281)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbServer As System.Windows.Forms.ProgressBar
    Friend WithEvents ComboType As System.Windows.Forms.ComboBox
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdSendFile As System.Windows.Forms.Button
    Friend WithEvents cmdCreateConn As System.Windows.Forms.Button
    Friend WithEvents cmdSendText As System.Windows.Forms.Button

End Class
