Public Class Master
    Dim lishnee As Size = New Size(Me.Width - Me.DisplayRectangle.Width, Me.Height - Me.DisplayRectangle.Height)
    Dim WithEvents blks As Bloks
    Dim Pattern As MasterPattern

    Public Sub New(ByVal Pattern As Object, Optional ByVal vHolostuyu As Boolean = False)
        If vHolostuyu Then Exit Sub
        InitializeComponent()
        Me.Pattern = Pattern

        Timer1.Start()
        Me.MinimumSize = New Size(1, 1)
        Me.Size = Me.MinimumSize
        Me.Text = transInfc("Мастер сложных действий")
        Dim text As New CodeString(Pattern.text, "None")
        If Pattern.withUslovie Then
            Me.Pattern.SetBloki(text.Split("Vezde", uslovs))
        Else
            Me.Pattern.SetBloki(text.Split("Vezde", opers))
        End If
        blks = New Bloks(Me.Pattern) : blks.Name = "MasterBloks"

        Master_Shown(Nothing, Nothing)
        Panel1.Controls.Add(blks)
        Panel1_SizeChanged(MasterPanel, Nothing)

        If blks.BlksCount = 1 Then blks.BlkTop.TudaSuda1_Click(Nothing, Nothing)
        Me.Width += 60
        InfoPropsLabel.Text = transInfc(InfoPropsLabel.Text)
        InfoPropsLabel.LinkArea = New LinkArea(InfoPropsLabel.Text.Length - 1 - transInfc("Мастер сложных действий").Length, 999)
        InfoPropsLabel.Links(0).Name = "Master"
    End Sub

    Private Sub ok_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Ok.KeyDown
        If e.KeyData = Keys.Escape Then blks.RemoveBlok(Nothing, True)
    End Sub

    Private Sub Master_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Параметры окна мастера
        MasterHeight = Me.Height : MasterSplit = Me.RamkaCDSplit.SplitterDistance
        If blks.BlksCount = 1 Then MasterWidth = Me.Width
    End Sub

    Private Sub Master_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' Параметры окна мастера
        If blks.BlksCount = 1 And MasterHeight <> 0 Then
            Me.Height = MasterHeight : Me.Width = MasterWidth : Me.RamkaCDSplit.SplitterDistance = MasterSplit
        End If

        Me.BackColor = SkinColors(Me.Name)
        Me.BackgroundImage = SkinPictures(Me.Name)
        RamkaCDSplit.Panel1.BackgroundImage = SkinPictures(Me.Name)
        RamkaCDSplit.Panel2.BackgroundImage = SkinPictures(Me.Name)
        MasterPanel.BackColor = SkinColors(MasterPanel.Name)
        MasterPanel.BackgroundImage = SkinPictures(MasterPanel.Name)
        ' MasterPanelLabel.ForeColor = SkinColors(MasterPanelLabel.Name)
        blks.ForeColor = SkinColors(blks.Name)
        RamkaCDSplit.BackColor = SkinColors(RamkaCDSplit.Name)
        RamkaCDSplit.Panel1.BackColor = Me.BackColor
        RamkaCDSplit.Panel2.BackColor = Me.BackColor
        InfoPropsLabel.ForeColor = blks.ForeColor
        InfoPropsLabel.LinkColor = SkinColors("ColLinkMaster")
        InfoPropsLabel.ActiveLinkColor = SkinColors("ColActiveLinkMaster")
        InfoPropsLabel.BackColor = Color.Transparent

        Ok.BackgroundImage = SkinPictures("MasterButton")
        Ok.ForeColor = SkinColors("MasterPanelLabel")
        Cancel.BackgroundImage = SkinPictures("MasterButton")
        Cancel.ForeColor = SkinColors("MasterPanelLabel")

    End Sub
    Private Sub Master_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Master_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Me.Focus()

        If Me.Width < MasterPanel.Width - 10 Then
            MasterPanel.Left = 0
            HScrollBar1.Maximum = MasterPanel.Width + 12
            HScrollBar1.SmallChange = 5
            HScrollBar1.LargeChange = (HScrollBar1.Maximum) / (HScrollBar1.Maximum / Me.Width)
            HScrollBar1.Visible = True
            HScrollBar1_Scroll(Nothing, Nothing)
        Else
            HScrollBar1.Visible = False
            MasterPanel.Left = (Me.Width - lishnee.Width) / 2 - MasterPanel.Width / 2
        End If
        Dim newY As Integer = (RamkaCDSplit.Panel1.Height - lishnee.Height) / 2 - MasterPanel.Height / 2  ' _
        '- (SplitContainer1.Height - SplitContainer1.SplitterDistance)
        If newY > 3 Then MasterPanel.Top = newY Else MasterPanel.Top = 3
        RamkaCDSplit.Panel1MinSize = MasterPanel.Height + MasterPanel.Top + 20
        Me.MinimumSize = New Size(Me.MinimumSize.Width, MasterPanel.Height + MasterPanel.Top + lishnee.Height + 20 + (RamkaCDSplit.Panel2.Height + RamkaCDSplit.SplitterWidth))
        RamkaCDSplit.Height = Me.Height - lishnee.Height
    End Sub
    Private Sub Master_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Me.Scroll
    End Sub

    Public Sub Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ok.Click
        If Pattern.ownTextBox.isDisposed Then Me.Close() : Exit Sub
        Pattern.ownTextBox.text = blks.GetText
        If Pattern.ownTextBox.name <> "indexs" Then proj.Podsvetka(Pattern.ownTextBox.ActiveTextBox)
        Me.Close()
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Private Sub Panel1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.SizeChanged
        Ok.Top = Panel1.Top + Panel1.Height + 3 : Cancel.Top = Ok.Top
        OkCancelLeft()
        MasterPanel.Height = Ok.Top + Ok.Height + 3
        MasterPanel.Width = Panel1.Width + 6
        Dim min As Integer
        If MasterPanel.Width > 950 Then min = 950 Else min = MasterPanel.Width + lishnee.Width
        If Timer1.Enabled = False Then
            'Dim plus As Integer = SplitContainer1.Height - SplitContainer1.SplitterDistance
            'If plus < 0 Then plus = SplitContainer1.Panel2.Height
            Me.MinimumSize = New Size(min, MasterPanel.Height + MasterPanel.Top + lishnee.Height + 20 + (RamkaCDSplit.Panel2.Height + RamkaCDSplit.SplitterWidth))
        Else
            Me.MinimumSize = New Size(min, 0)
        End If
        Master_Resize(Me, e)
        MasterPanel.Refresh()
    End Sub
    Private Sub OkCancelLeft()
        Dim PanelWidth As Integer = Panel1.Width
        If PanelWidth > RamkaCDSplit.Panel1.Width Then PanelWidth = RamkaCDSplit.Panel1.Width
        Ok.Left = HScrollBar1.Value + PanelWidth / 2 - Ok.Width / 2 - Cancel.Width / 2
        Cancel.Left = Ok.Left + Ok.Width + 3
    End Sub
    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        MasterPanel.Left = -HScrollBar1.Value + 3
        OkCancelLeft()
    End Sub

    Private Sub HScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        ' HScrollBar1_Scroll(sender, Nothing)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop() : Panel1_SizeChanged(Nothing, Nothing)
    End Sub

    ' ОТОБРАЖАЮТ ИНФОРМАЦИЮ О СВОЙСТВЕ В InfoPropsLabel МАСТЕРА
    Public Sub InfoPropsShow(ByVal prop As String, ByVal MyObj As Object)
        MainForm.InfoPropsShow(prop, MyObj, InfoPropsLabel)
    End Sub
    Public Sub InfoArgsShow(ByVal arg As String, ByVal MyObj As Object, ByVal prop As String)
        MainForm.InfoArgsShow(arg, MyObj, prop, InfoPropsLabel)
    End Sub

    Private Sub Master_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Me.Focus()
    End Sub

    Private Sub Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles RamkaCDSplit.SplitterMoved
        Master_Resize(sender, New EventArgs)
    End Sub

    Private Sub InfoPropsLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles InfoPropsLabel.LinkClicked
        MainForm.InfoPropsLabel_LinkClicked(sender, e)
    End Sub

End Class