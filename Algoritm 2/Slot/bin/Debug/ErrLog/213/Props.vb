Module Props
    Public Function GetProperty(ByVal MyObj As Object, ByVal prop As String, Optional ByVal word As String = "") As ErrString
        prop = UCase(prop)
        If MyObj Is Nothing Then Return New ErrString(Nothing)
        If MyObj.PropertysUp Is Nothing Then Return New ErrString(Nothing)
        If Array.IndexOf(MyObj.PropertysUp, prop) = -1 Then Return New ErrString(Nothing) ' ���� ��� ������ �������� �� ����� �� �������
        Return GetPropertyMethod(MyObj, prop, word, Nothing)
    End Function
    Function GetPropertyMethod(ByVal MyObj As Object, ByVal prop As String, ByVal word As String, ByVal args() As String) As ErrString
        Dim oldprop As String = prop
        Dim vParamah As Boolean = False
        Dim obj As Object = MyObj.obj
        Dim es As ErrString, i As Integer
        prop = UCase(prop)
        ' ���� �������� � �������������� ���������� (����. _������ ����)
        If MyObj.isRun Then
            If RunProj Is Nothing Then Exit Function
            If RunProj.Param.Paramy Is Nothing = False Then
                If RunProj.Param.ParamyUp.IndexOfKey(UCase(prop)) <> -1 Then vParamah = True
            End If
        End If
        ' ���� ��� ������ �������� �� ����� �� �������
        If MyObj.PropertysUp Is Nothing And MyObj.MethodsUp Is Nothing Then Return New ErrString("", Errors.notPropertyMethod(oldprop))
        If MyObj.PropertysUp Is Nothing = False Then
            If Array.IndexOf(MyObj.PropertysUp, prop) = -1 And Array.IndexOf(MyObj.MethodsUp, prop) = -1 And vParamah = False Then
                Return New ErrString("", Errors.notPropertyMethod(oldprop))
            End If
        Else
            If Array.IndexOf(MyObj.MethodsUp, prop) = -1 And vParamah = False Then
                Return New ErrString("", Errors.notPropertyMethod(oldprop))
            End If
        End If
        If isObjSobitiya(MyObj.obj) Then Return New ErrString("")
        ' �������� � ���������� ��� ���� �� ������
        If args Is Nothing = False Then
            For i = 0 To args.Length - 1
                args(i) = perevesti(args(i), True)
            Next
        End If

        If vParamah Then GoTo PropVParam
        Select Case prop

            ' OBJECTS
            Case UCase(trans("���")) : Return New ErrString(obj.Props.Name)
            Case UCase(trans("������� �������")) : Return New ErrString(obj.Props.BackgroundImage)
            Case UCase(trans("������� �������1")) : Return New ErrString(obj.Props.BackgroundImage1)
            Case UCase(trans("������� �������2")) : Return New ErrString(obj.Props.BackgroundImage2)
            Case UCase(trans("����")) : Return New ErrString(obj.Props.BackColor)
            Case UCase(trans("����1")) : Return New ErrString(obj.Props.BackColor1)
            Case UCase(trans("����2")) : Return New ErrString(obj.Props.BackColor2)
            Case UCase(trans("�����")) : Return New ErrString(obj.Props.index)
            Case UCase(trans("�������")) : Return New ErrString(obj.Props.position)
            Case UCase(trans("������� �����")) : Return New ErrString(obj.Props.mainform)
            Case UCase(trans("����������� ����")) : Return New ErrString(obj.Props.ContextMenu)
            Case UCase(trans("����������� ����1")) : Return New ErrString(obj.Props.ContextMenu1)
            Case UCase(trans("����������� ����2")) : Return New ErrString(obj.Props.ContextMenu2)
            Case UCase(trans("��������� ��������")) : Return New ErrString(obj.Props.ForbidClose)
            Case UCase(trans("��������")) : Return New ErrString(obj.Props.Anchor)
            Case UCase(trans("�������������")) : Return New ErrString(obj.Props.AutoEllipsis)
            Case UCase(trans("����� ����")) : Return New ErrString(obj.Props.BackgroundImageLayout)
            Case UCase(trans("����� ����1")) : Return New ErrString(obj.Props.BackgroundImageLayout1)
            Case UCase(trans("����� ����2")) : Return New ErrString(obj.Props.BackgroundImageLayout2)
            Case UCase(trans("����� �������")) : Return New ErrString(obj.Props.SizeMode)
            Case UCase(trans("������")) : Return New ErrString(obj.Props.Cursor)
            Case UCase(trans("������1")) : Return New ErrString(obj.Props.Cursor1)
            Case UCase(trans("������2")) : Return New ErrString(obj.Props.Cursor2)
            Case UCase(trans("��������")) : Return New ErrString(obj.Props.Dock)
            Case UCase(trans("��������")) : Return New ErrString(obj.Props.Enabled)
            Case UCase(trans("����� ������")) : Return New ErrString(obj.Props.FlatStyle)
            Case UCase(trans("����� �����")) : Return New ErrString(obj.Props.BorderStyle)
            Case UCase(trans("�����")) : Return New ErrString(obj.Props.FontFamily)
            Case UCase(trans("����� ������")) : Return New ErrString(obj.Props.FontBold)
            Case UCase(trans("����� ������")) : Return New ErrString(obj.Props.FontItalic)
            Case UCase(trans("����� ������������")) : Return New ErrString(obj.Props.FontUnderline)
            Case UCase(trans("����� �����������")) : Return New ErrString(obj.Props.FontStrikeout)
            Case UCase(trans("����� ������")) : Return New ErrString(obj.Props.FontSize)
            Case UCase(trans("���� ������")) : Return New ErrString(obj.Props.ForeColor)
            Case UCase(trans("�������")) : Return New ErrString(obj.Props.Image)
            Case UCase(trans("��������� �������")) : Return New ErrString(obj.Props.ImageAlign)
            Case UCase(trans("X")) : Return New ErrString(obj.Props.X)
            Case UCase(trans("Y")) : Return New ErrString(obj.Props.Y)
            Case UCase(trans("������������ ������")) : Return New ErrString(obj.Props.MaximumWidth)
            Case UCase(trans("������������ ������")) : Return New ErrString(obj.Props.MaximumHeight)
            Case UCase(trans("����������� ������")) : Return New ErrString(obj.Props.MinimumWidth)
            Case UCase(trans("����������� ������")) : Return New ErrString(obj.Props.MinimumHeight)
            Case UCase(trans("���� �����")) : Return New ErrString(obj.Props.PaddingLeft)
            Case UCase(trans("���� ������")) : Return New ErrString(obj.Props.PaddingTop)
            Case UCase(trans("���� ������")) : Return New ErrString(obj.Props.PaddingRight)
            Case UCase(trans("���� �����")) : Return New ErrString(obj.Props.PaddingBottom)
            Case UCase(trans("������")) : Return New ErrString(obj.Props.Width)
            Case UCase(trans("������")) : Return New ErrString(obj.Props.Height)
            Case UCase(trans("��������")) : Return New ErrString(obj.Props.TabIndex)
            Case UCase(trans("�������")) : Return New ErrString(obj.Props.TabStop)
            Case UCase(trans("��������������� ����")) : Return New ErrString(obj.Props.Tag)
            Case UCase(trans("�����")) : Return New ErrString(obj.Props.Text)
            Case UCase(trans("��������� ������")) : Return New ErrString(obj.Props.TextAlign)
            Case UCase(trans("������������ ������")) : Return New ErrString(obj.Props.TextPosition)
            Case UCase(trans("����� � �������")) : Return New ErrString(obj.Props.TextImageRelation)
            Case UCase(trans("�������")) : Return New ErrString(obj.Props.Visible)
            Case UCase(trans("���������")) : Return New ErrString(obj.Props.Scroll)
            Case UCase(trans("���������1")) : Return New ErrString(obj.Props.Scroll1)
            Case UCase(trans("���������2")) : Return New ErrString(obj.Props.Scroll2)
            Case UCase(trans("������������� �����")) : Return New ErrString(obj.Props.FixedPanel)
            Case UCase(trans("������������� �����������")) : Return New ErrString(obj.Props.FixedSplitter)
            Case UCase(trans("����������")) : Return New ErrString(obj.Props.Orientation)
            Case UCase(trans("������1 ������")) : Return New ErrString(obj.Props.Panel1Collapsed)
            Case UCase(trans("������2 ������")) : Return New ErrString(obj.Props.Panel2Collapsed)
            Case UCase(trans("������ �����������")) : Return New ErrString(obj.Props.SplitterWidth)
            Case UCase(trans("���������� �����������")) : Return New ErrString(obj.Props.SplitterDistance)
            Case UCase(trans("��������� �����������")) : Return New ErrString(obj.Props.SplitterIncrement)
            Case UCase(trans("������1 �������")) : Return New ErrString(obj.Props.Panel1MinSize)
            Case UCase(trans("������2 �������")) : Return New ErrString(obj.Props.Panel2MinSize)
            Case UCase(trans("� ������")) : Return New ErrString(obj.Props.Focused)
            Case UCase(trans("���")) : Return New ErrString(obj.Props.Type)
            Case UCase(trans("���� ������������")) : Return New ErrString(obj.Props.FileNamePlayed)
            Case UCase(trans("�������������")) : Return New ErrString(obj.Props.Played)
            Case UCase(trans("���������")) : Return New ErrString(obj.Props.Volume)
            Case UCase(trans("������")) : Return New ErrString(obj.Props.Balance)
            Case UCase(trans("���� ��������")) : Return New ErrString(obj.Props.Mute)
            Case UCase(trans("��������")) : Return New ErrString(obj.Props.Speed)
            Case UCase(trans("������������ �����")) : Return New ErrString(obj.Props.TotalPosition)
            Case UCase(trans("������� ������������")) : Return New ErrString(obj.Props.PlayPosition)
            Case UCase(trans("����������� �������")) : Return New ErrString(obj.Props.PlayTime)
            Case UCase(trans("������������ �����")) : Return New ErrString(obj.Props.TotalTime)
            Case UCase(trans("������������ ������")) : Return New ErrString(obj.Props.OriginalHeight)
            Case UCase(trans("������������ ������")) : Return New ErrString(obj.Props.OriginalWidth)
            Case UCase(trans("�������� ���������")) : Return New ErrString(obj.Props.HideSelection)
            Case UCase(trans("������������ ������")) : Return New ErrString(obj.Props.MaximumLength)
            Case UCase(trans("���������������")) : Return New ErrString(obj.Props.Multiline)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.PasswordChar)
            Case UCase(trans("������ ��� ������")) : Return New ErrString(obj.Props.ReadOnly)
            Case UCase(trans("������ ���������")) : Return New ErrString(obj.Props.ScrollBars)
            Case UCase(trans("������� �� ������")) : Return New ErrString(obj.Props.WordWrap)
            Case UCase(trans("���������� �����")) : Return New ErrString(obj.Props.SelectedText)
            Case UCase(trans("������ ���������")) : Return New ErrString(obj.Props.SelectionStart)
            Case UCase(trans("������ ���������")) : Return New ErrString(obj.Props.SelectionLength)
            Case UCase(trans("��������")) : Return New ErrString(obj.Props.Checked)
            Case UCase(trans("���������� ������������")) : Return New ErrString(obj.Props.OrientationTools)
            Case UCase(trans("���������� �����")) : Return New ErrString(obj.Props.Alignment)
            Case UCase(trans("���������� ���������")) : Return New ErrString(obj.Props.AutoToolTip)
            Case UCase(trans("������� �� �����")) : Return New ErrString(obj.Props.CheckOnClick)
            Case UCase(trans("����� �����������")) : Return New ErrString(obj.Props.DisplayStyle)
            Case UCase(trans("������������ ����")) : Return New ErrString(obj.Props.OwnerMenu)
            Case UCase(trans("������������ �����")) : Return New ErrString(obj.Props.OwnerItem)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.OwnerObject)
            Case UCase(trans("��������� ����������� ����")) : Return New ErrString(obj.Props.DropDown)
            Case UCase(trans("������� ��������")) : Return New ErrString(obj.Props.ImageScaling)
            Case UCase(trans("���������� ���� �������")) : Return New ErrString(obj.Props.ImageTransparentColor)
            Case UCase(trans("������� �������")) : Return New ErrString(obj.Props.ShortcutKeys)
            Case UCase(trans("���������� ������� �������")) : Return New ErrString(obj.Props.ShowShortcutKeys)
            Case UCase(trans("����������� ������")) : Return New ErrString(obj.Props.TextDirection)
            Case UCase(trans("����������� ���������")) : Return New ErrString(obj.Props.ToolTipText)
            Case UCase(trans("������� ������ � ����")) : Return New ErrString(obj.Props.ControlBox)
            Case UCase(trans("����� ����")) : Return New ErrString(obj.Props.FormBorderStyle)
            Case UCase(trans("������� ����")) : Return New ErrString(obj.Props.MainMenuStrip)
            Case UCase(trans("������������")) : Return New ErrString(obj.Props.Opacity)
            Case UCase(trans("���������� ������")) : Return New ErrString(obj.Props.ShowIcon)
            Case UCase(trans("���������� � ������ �����")) : Return New ErrString(obj.Props.ShowInTaskbar)
            Case UCase(trans("��������� �������")) : Return New ErrString(obj.Props.StartPosition)
            Case UCase(trans("������ ���� ����")) : Return New ErrString(obj.Props.TopMost)
            Case UCase(trans("������ ����")) : Return New ErrString(obj.Props.WindowState)
            Case UCase(trans("��������� ����������� ������")) : Return New ErrString(obj.Props.AutoScrollMinSizeWidth)
            Case UCase(trans("��������� ����������� ������")) : Return New ErrString(obj.Props.AutoScrollMinSizeHeight)
            Case UCase(trans("���������� �� X")) : Return New ErrString(obj.Props.AutoScrollPositionX)
            Case UCase(trans("���������� �� Y")) : Return New ErrString(obj.Props.AutoScrollPositionY)
            Case UCase(trans("������ ���������")) : Return New ErrString(obj.Props.CaptionHeight)
            Case UCase(trans("������")) : Return New ErrString(obj.Props.Icon)
            Case UCase(trans("���������� ����")) : Return New ErrString(obj.Props.TransparentcyKey)
            Case UCase(trans("��������� ��������")) : Return New ErrString(obj.Props.TabAlignment)
            Case UCase(trans("����� ���������� ��������")) : Return New ErrString(obj.Props.SelectedTabIndex)
            Case UCase(trans("������� ���������� ��������")) : Return New ErrString(obj.Props.SelectedTabPosition)
            Case UCase(trans("���� �� �����������")) : Return New ErrString(obj.Props.PaddingX)
            Case UCase(trans("���� �� ���������")) : Return New ErrString(obj.Props.PaddingY)
            Case UCase(trans("��������")) : Return New ErrString(obj.Props.Value)
            Case UCase(trans("������ ��������������� ������")) : Return New ErrString(obj.Props.DropDownHeight)
            Case UCase(trans("������ ��������������� ������")) : Return New ErrString(obj.Props.DropDownWidth)
            Case UCase(trans("������ ����������")) : Return New ErrString(obj.Props.DropDownStyle)
            Case UCase(trans("������ ������� ������")) : Return New ErrString(obj.Props.ItemHeight)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.Items)
            Case UCase(trans("���������� �������������� �������")) : Return New ErrString(obj.Props.MaxDropDownItems)
            Case UCase(trans("���������� ������")) : Return New ErrString(obj.Props.Sorted)
            Case UCase(trans("������ �������")) : Return New ErrString(obj.Props.DroppedDown)
            Case UCase(trans("����� ���������� ������")) : Return New ErrString(obj.Props.SelectedIndex)
            Case UCase(trans("���������� ������")) : Return New ErrString(obj.Props.SelectedItem)
            Case UCase(trans("������ �� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If obj.items.count <= args(0) Then es.err = Errors.noItems(prop, args(0)) : Return es
                Return New ErrString(obj.Props.ItemsItem(args))
            Case UCase(trans("����� ����� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ItemsIndexOf(args))
            Case UCase(trans("���������� �������")) : Return New ErrString(obj.Props.ItemsCount)
            Case UCase(trans("������ ������� ������")) : Return New ErrString(obj.Props.ColumnWidth)
            Case UCase(trans("�������������� ���������")) : Return New ErrString(obj.Props.HorizontalScrollBar)
            Case UCase(trans("���������������")) : Return New ErrString(obj.Props.MultiColumn)
            Case UCase(trans("��������� �������� ������")) : Return New ErrString(obj.Props.SelectionModeList)
            Case UCase(trans("������ ��������� �������")) : Return New ErrString(obj.Props.CheckedIndices)
            Case UCase(trans("���������� ������")) : Return New ErrString(obj.Props.CheckedItems)
            Case UCase(trans("������ ���������� �������")) : Return New ErrString(obj.Props.SelectedIndices)
            Case UCase(trans("���������� ������")) : Return New ErrString(obj.Props.SelectedItems)
            Case UCase(trans("���� �������� ������")) : Return New ErrString(obj.Props.ActiveLinkColor)
            Case UCase(trans("���� ��������� ������")) : Return New ErrString(obj.Props.DisabledLinkColor)
            Case UCase(trans("���� ������")) : Return New ErrString(obj.Props.LinkColor)
            Case UCase(trans("���� ���������� ������")) : Return New ErrString(obj.Props.VisitedLinkColor)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.LinkStart)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.LinkLength)
            Case UCase(trans("����� �������������")) : Return New ErrString(obj.Props.LinkBehavior)
            Case UCase(trans("������ ��������")) : Return New ErrString(obj.Props.LinkVisited)
            Case UCase(trans("������ �������")) : Return New ErrString(obj.Props.LinkEnabled)
            Case UCase(trans("���������� � �������� �� ������")) : Return New ErrString(obj.Props.InternetLink)
            Case UCase(trans("������ �������")) : Return New ErrString(obj.Props.LinkName)
            Case UCase(trans("������������ ������")) : Return New ErrString(obj.Props.DetectUrls)
            Case UCase(trans("��������� ������� �����������")) : Return New ErrString(obj.Props.EnableAutoDragDrop)
            Case UCase(trans("�������")) : Return New ErrString(obj.Props.ZoomFactor)
            Case UCase(trans("RTF ��� ���������")) : Return New ErrString(obj.Props.Rtf)
            Case UCase(trans("���������� RTF")) : Return New ErrString(obj.Props.SelectedRtf)
            Case UCase(trans("���������� ��������� ������")) : Return New ErrString(obj.Props.SelectionAlignment)
            Case UCase(trans("���������� ������ ���")) : Return New ErrString(obj.Props.SelectionBackColor)
            Case UCase(trans("���������� ���� ������")) : Return New ErrString(obj.Props.SelectionColor)
            Case UCase(trans("���������� ������ ������� ������")) : Return New ErrString(obj.Props.SelectionHangingIndent)
            Case UCase(trans("���������� ������ �����")) : Return New ErrString(obj.Props.SelectionIndent)
            Case UCase(trans("���������� ������ ������")) : Return New ErrString(obj.Props.SelectionRightIndent)
            Case UCase(trans("���������� ����� ������")) : Return New ErrString(obj.Props.SelectionBullet)
            Case UCase(trans("���������� ������������ ��������")) : Return New ErrString(obj.Props.SelectionCharOffset)
            Case UCase(trans("���������� �����")) : Return New ErrString(obj.Props.SelectionFontFamily)
            Case UCase(trans("���������� ����� ������")) : Return New ErrString(obj.Props.SelectionFontBold)
            Case UCase(trans("���������� ����� ������")) : Return New ErrString(obj.Props.SelectionFontItalic)
            Case UCase(trans("���������� ����� ������������")) : Return New ErrString(obj.Props.SelectionFontUnderline)
            Case UCase(trans("���������� ����� �����������")) : Return New ErrString(obj.Props.SelectionFontStrikeout)
            Case UCase(trans("���������� ����� ������")) : Return New ErrString(obj.Props.SelectionFontSize)
            Case UCase(trans("���������� ����� ������������")) : Return New ErrString(obj.Props.SelectionProtected)
            Case UCase(trans("��������� ����")) : Return New ErrString(obj.Props.DialogColor)
            Case UCase(trans("���� ������ ������")) : Return New ErrString(obj.Props.WasCancel)
            Case UCase(trans("��������� �������� ����")) : Return New ErrString(obj.Props.ShowColor)
            Case UCase(trans("��������� �������� �������������")) : Return New ErrString(obj.Props.ShowEffects)
            Case UCase(trans("������� � ����")) : Return New ErrString(obj.Props.Description)
            Case UCase(trans("��������� �����")) : Return New ErrString(obj.Props.SelectedPath)
            Case UCase(trans("��������� ���������� �����")) : Return New ErrString(obj.Props.DefaultExt)
            Case UCase(trans("��������� ������� �����")) : Return New ErrString(obj.Props.CheckFileExists)
            Case UCase(trans("��������� ������� �����")) : Return New ErrString(obj.Props.CheckPathExists)
            Case UCase(trans("��� �����")) : Return New ErrString(obj.Props.FileName)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.Filter)
            Case UCase(trans("����� �������")) : Return New ErrString(obj.Props.FilterIndex)
            Case UCase(trans("��������� �����")) : Return New ErrString(obj.Props.InitialDirectory)
            Case UCase(trans("���������")) : Return New ErrString(obj.Props.Title)
            Case UCase(trans("����� ���������� ������")) : Return New ErrString(obj.Props.MultiSelectFiles)
            Case UCase(trans("����� �� ������")) : Return New ErrString(obj.Props.PrintText)
            Case UCase(trans("�������� �� ������")) : Return New ErrString(obj.Props.PrintDocument)
            Case UCase(trans("������� �� ������")) : Return New ErrString(obj.Props.PrintTable)
            Case UCase(trans("������ �� ������")) : Return New ErrString(obj.Props.PrintObject)
            Case UCase(trans("������� �� ������")) : Return New ErrString(obj.Props.PrintPicture)
            Case UCase(trans("������� � ������")) : Return New ErrString(obj.Props.TableOnCenter)
            Case UCase(trans("�������� �������")) : Return New ErrString(obj.Props.Interval)
            Case UCase(trans("������ ����������")) : Return New ErrString(obj.Props.IntervalCount)
            Case UCase(trans("������ ����")) : Return New ErrString(obj.Props.CalendarDateFormat)
            Case UCase(trans("������ ���� �� ������")) : Return New ErrString(obj.Props.CustomDateFormat)
            Case UCase(trans("������ ����� ����")) : Return New ErrString(obj.Props.ShowUpDown)
            Case UCase(trans("��������� ����")) : Return New ErrString(obj.Props.SelectedDate)
            Case UCase(trans("����� �������")) : Return New ErrString(obj.Props.LargeChange)
            Case UCase(trans("����� �����")) : Return New ErrString(obj.Props.SmallChange)
            Case UCase(trans("��������")) : Return New ErrString(obj.Props.Maximum)
            Case UCase(trans("�������")) : Return New ErrString(obj.Props.Minimum)
            Case UCase(trans("����� �������")) : Return New ErrString(obj.Props.TickStyle)
            Case UCase(trans("������� �������")) : Return New ErrString(obj.Props.TickFrequency)
            Case UCase(trans("���������� � ����")) : Return New ErrString(obj.Props.ShowInTray)
            Case UCase(trans("���������")) : Return New ErrString(obj.Props.ToolTip)
            Case UCase(trans("�������� � ������������")) : Return New ErrString(obj.Props.AutoRun)
            Case UCase(trans("��������� ������ �����")) : Return New ErrString(obj.Props.AllowRunCopies)
            Case UCase(trans("��������� �������")) : Return New ErrString(obj.Props.AllowInput)
            Case UCase(trans("����� ��������")) : Return New ErrString(obj.Props.StyleProgress)
            Case UCase(trans("�������� ��������")) : Return New ErrString(obj.Props.MarqueeAnimationSpeed)
            Case UCase(trans("��� ��������")) : Return New ErrString(obj.Props.StepProgress)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.RightToLeftLayout)
            Case UCase(trans("��������� ��������������")) : Return New ErrString(obj.Props.ForbidMinimize)
            Case UCase(trans("��������� �������������")) : Return New ErrString(obj.Props.ForbidMaximize)
            Case UCase(trans("������������� � ������������")) : Return New ErrString(obj.Props.AssociateWithExtensions)
            Case UCase(trans("�������������� �������� ����")) : Return New ErrString(obj.Props.AssociationPassedFile)
            Case UCase(trans("�������� ������ ������")) : Return New ErrString(obj.Props.FromPage)
            Case UCase(trans("�������� ����� ������")) : Return New ErrString(obj.Props.ToPage)
            Case UCase(trans("����� �����")) : Return New ErrString(obj.Props.Copies)
            Case UCase(trans("������ ��������")) : Return New ErrString(obj.Props.WidthOfColumns)
            Case UCase(trans("������ �����")) : Return New ErrString(obj.Props.HeightOfRows)
            Case UCase(trans("�� ���� �����")) : Return New ErrString(obj.Props.OnFullScreen)


                ' webbrowser
            Case UCase(trans("���������� �� ��������")) : Return New ErrString(obj.Props.AllowNavigation)
            Case UCase(trans("��������� ��������������")) : Return New ErrString(obj.Props.AllowWebBrowserDrop)
            Case UCase(trans("����� ��������")) : Return New ErrString(obj.Props.CanGoBack)
            Case UCase(trans("������ ��������")) : Return New ErrString(obj.Props.CanGoForward)
            Case UCase(trans("����� ��������")) : Return New ErrString(obj.Props.DocumentText)
            Case UCase(trans("��������� ��������")) : Return New ErrString(obj.Props.DocumentTitle)
            Case UCase(trans("��� ��������")) : Return New ErrString(obj.Props.DocumentType)
            Case UCase(trans("������� �����")) : Return New ErrString(obj.Props.isBusy)
            Case UCase(trans("������� offline")) : Return New ErrString(obj.Props.isOffline)
            Case UCase(trans("����������� ���� ��������")) : Return New ErrString(obj.Props.isWebBrowserContextMunuEnabled)
            Case UCase(trans("������ ����������")) : Return New ErrString(obj.Props.ReadyState)
            Case UCase(trans("��������� ������")) : Return New ErrString(obj.Props.StatusText)
            Case UCase(trans("���������� ������ ���������")) : Return New ErrString(obj.Props.ScriptErrorsSuppressed)
            Case UCase(trans("������ ��������� �������")) : Return New ErrString(obj.Props.ScrollBarsEnabled)
            Case UCase(trans("������")) : Return New ErrString(obj.Props.Url)
            Case UCase(trans("������� ������� ��������")) : Return New ErrString(obj.Props.WebBrowserShortcutsEnabled)
            Case UCase(trans("���������")) : Return New ErrString(obj.Props.DocumentEncoding)
            Case UCase(trans("��������� �� ���������")) : Return New ErrString(obj.Props.EncodingDefault)
            Case UCase(trans("����")) : Return New ErrString(obj.Props.Cookie)
            Case UCase(trans("�������� ������ ������ ����")) : Return New ErrString(obj.Props.OpenNewWindowLink)

                ' �����
            Case UCase(trans("����� ������")) : Return New ErrString(obj.Props.TextButton)
            Case UCase(trans("����� ����")) : Return New ErrString(obj.Props.TextField)
            Case UCase(trans("��������� �������� ���������")) : Return New ErrString(obj.Props.MessageValid)
            Case UCase(trans("��������� ��������� ���������")) : Return New ErrString(obj.Props.MessageInValid)
            Case UCase(trans("ID ������������")) : Return New ErrString(obj.Props.IdUser)
            Case UCase(trans("ID ���������")) : Return New ErrString(obj.Props.IdProgram)
            Case UCase(trans("ID � �������")) : Return New ErrString(obj.Props.IdRegistryProgram)
            Case UCase(trans("���� ����������")) : Return New ErrString(obj.Props.KeyEncryption)
            Case UCase(trans("���� ������ �����")) : Return New ErrString(obj.Props.DaysAll)
            Case UCase(trans("���� ������ ��������")) : Return New ErrString(obj.Props.DaysLeft)
            Case UCase(trans("������������")) : Return New ErrString(obj.Props.Activation)
            Case UCase(trans("����������")) : Return New ErrString(obj.Props.Remark)
            Case UCase(trans("��������� ������ �������")) : Return New ErrString(obj.Props.TrialStarted)
            Case UCase(trans("���� ��������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.KeyIssue(args))
            Case UCase(trans("���� ��������� ���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.KeyValidation(args))

                ' ClientServer
            Case UCase(trans("���� ������������")) : Return New ErrString(obj.Props.FileIsSent)
            Case UCase(trans("������ �������� ������")) : Return New ErrString(obj.Props.HideSendingFiles)
            Case UCase(trans("������ �������� ������")) : Return New ErrString(obj.Props.HideSendingText)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.HideComboBox)
            Case UCase(trans("����������� ������")) : Return New ErrString(obj.Props.CommandSymbol)
            Case UCase(trans("�������� �������")) : Return New ErrString(obj.Props.ReceivedCommand)
            Case UCase(trans("�������� �����")) : Return New ErrString(obj.Props.ReceivedText)
            Case UCase(trans("�������� ����")) : Return New ErrString(obj.Props.ReceivedFile)
            Case UCase(trans("������������ �������")) : Return New ErrString(obj.Props.SentCommand)
            Case UCase(trans("����������� �����")) : Return New ErrString(obj.Props.SentText)
            Case UCase(trans("����������� ����")) : Return New ErrString(obj.Props.SentFile)
            Case UCase(trans("��� � ����")) : Return New ErrString(obj.Props.NameInNetwork)
            Case UCase(trans("IP ��� ����������")) : Return New ErrString(obj.Props.RemoteHost)
            Case UCase(trans("���� ��� ����������")) : Return New ErrString(obj.Props.RemotePort)
            Case UCase(trans("����� ��� ��������")) : Return New ErrString(obj.Props.PathForDownloads)
            Case UCase(trans("��� ������ �������")) : Return New ErrString(obj.Props.ClientServerType)
            Case UCase(trans("����� ��������")) : Return New ErrString(obj.Props.ClientsNames)
            Case UCase(trans("����� ���� �����")) : Return New ErrString(obj.Props.TextBoxString)
            Case UCase(trans("����� ���� ����")) : Return New ErrString(obj.Props.TextBoxLog)
            Case UCase(trans("Ip ��������")) : Return New ErrString(obj.Props.ClientsIPs)
            Case UCase(trans("Ip �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.GetClientIp(args))

                ' internet
            Case UCase(trans("���������� ����������")) : Return New ErrString(obj.Props.KeepAlive)
            Case UCase(trans("������������� ����������������")) : Return New ErrString(obj.Props.AllowAutoRedirect)
            Case UCase(trans("������ �������")) : Return New ErrString(obj.Props.UrlToGo)
            Case UCase(trans("������ ������ ������")) : Return New ErrString(obj.Props.UrlReferer)
            Case UCase(trans("������ ���������������")) : Return New ErrString(obj.Props.UrlRedirect)
            Case UCase(trans("��� ��������")) : Return New ErrString(obj.Props.UserAgent)
            Case UCase(trans("���������")) : Return New ErrString(obj.Props.Accept)
            Case UCase(trans("������ IP")) : Return New ErrString(obj.Props.ProxyIp)
            Case UCase(trans("������ ����")) : Return New ErrString(obj.Props.ProxyPort)
            Case UCase(trans("��������� ��������")) : Return New ErrString(obj.Props.EncodingPage)
            Case UCase(trans("���� ��������")) : Return New ErrString(obj.Props.LanguagePage)
            Case UCase(trans("���������� �������")) : Return New ErrString(obj.Props.ContentQuery)
            Case UCase(trans("��� �����������")) : Return New ErrString(obj.Props.ContentType)
            Case UCase(trans("������ �����������")) : Return New ErrString(obj.Props.ContentLength)
            Case UCase(trans("����� �������")) : Return New ErrString(obj.Props.HttpMethod)
            Case UCase(trans("��� ����������")) : Return New ErrString(obj.Props.ResultCode)
            Case UCase(trans("�������")) : Return New ErrString(obj.Props.TimeOut)
            Case UCase(trans("����� ��������")) : Return New ErrString(obj.Props.TimeDelay)
            Case UCase(trans("��������� �������")) : Return New ErrString(obj.Props.Headers)
            Case UCase(trans("���� ��������")) : Return New ErrString(obj.Props.CookiesQueries)
            Case UCase(trans("��������� �������")) : Return New ErrString(obj.Props.ResultQuery)
            Case UCase(trans("������ ������")) : Return New ErrString(obj.Props.BufferSize)
            Case UCase(trans("����������� ����")) : Return New ErrString(obj.Props.FileDownloading)
            Case UCase(trans("������ �����")) : Return New ErrString(obj.Props.DownloadPause)
            Case UCase(trans("������� ����������")) : Return New ErrString(obj.Props.CheckConnect)



                ' table
            Case UCase(trans("��������� ��������� ������")) : Return New ErrString(obj.Props.AllowUserToAddRows)
            Case UCase(trans("��������� ������� ������")) : Return New ErrString(obj.Props.AllowUserToDeleteRows)
            Case UCase(trans("��������� ������������ �������")) : Return New ErrString(obj.Props.AllowUserToOrderColumns)
            Case UCase(trans("��������� ����������� �������")) : Return New ErrString(obj.Props.AllowUserToResizeColumns)
            Case UCase(trans("��������� ����������� ������")) : Return New ErrString(obj.Props.AllowUserToResizeRows)
            Case UCase(trans("����� ����� ������")) : Return New ErrString(obj.Props.CellBorderStyle)
            Case UCase(trans("���������� ��������� ��������")) : Return New ErrString(obj.Props.ColumnHeadersVisible)
            Case UCase(trans("���������� ����������� �������")) : Return New ErrString(obj.Props.RowHeadersVisible)
            Case UCase(trans("������ ���������� ��������")) : Return New ErrString(obj.Props.ColumnHeadersHeight)
            Case UCase(trans("�������")) : Return New ErrString(obj.Props.Columns)
            Case UCase(trans("������")) : Return New ErrString(obj.Props.Rows)
            Case UCase(trans("���� ���� �����")) : Return New ErrString(obj.Props.DefaultCellStyleBackColor)
            Case UCase(trans("���� ���� ���������� �����")) : Return New ErrString(obj.Props.DefaultCellStyleSelectionBackColor)
            Case UCase(trans("���� ������ �����")) : Return New ErrString(obj.Props.DefaultCellStyleForeColor)
            Case UCase(trans("���� ������ ���������� �����")) : Return New ErrString(obj.Props.DefaultCellStyleSelectionForeColor)
            Case UCase(trans("����� ��������������")) : Return New ErrString(obj.Props.EditMode)
            Case UCase(trans("���� �����")) : Return New ErrString(obj.Props.GridColor)
            Case UCase(trans("����� ���������� �����")) : Return New ErrString(obj.Props.MultiSelect)
            Case UCase(trans("����� ���������� �������")) : Return New ErrString(obj.Props.MultiSelectItems)
            Case UCase(trans("������ ��� ������ �������")) : Return New ErrString(obj.Props.ReadOnlyTable)
            Case UCase(trans("����� ���������")) : Return New ErrString(obj.Props.SelectionMode)
            Case UCase(trans("������ ���������� �����")) : Return New ErrString(obj.Props.SelectedRows)
            Case UCase(trans("������ ���������� ��������")) : Return New ErrString(obj.Props.SelectedColumns)
            Case UCase(trans("���������� ����� �������")) : Return New ErrString(obj.Props.RowsCount)
            Case UCase(trans("���������� ��������")) : Return New ErrString(obj.Props.ColumnsCount)
            Case UCase(trans("���������� ���������� �����")) : Return New ErrString(obj.Props.SelectedRowsCount)
            Case UCase(trans("���������� ���������� ��������")) : Return New ErrString(obj.Props.SelectedColumnsCount)
            Case UCase(trans("�������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(GetArguments(prop, MyObj)(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(GetArguments(prop, MyObj)(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(GetArguments(prop, MyObj)(0), args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(GetArguments(prop, MyObj)(1), args(1)) : Return es
                Return New ErrString(obj.Props.ItemValue(args))
            Case UCase(trans("������ ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(prop, args(1)) : Return es
                Return New ErrString(obj.Props.ItemSelected(args))
            Case UCase(trans("������ ������ ��� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                Return New ErrString(obj.Props.RowsReadOnly(args))
            Case UCase(trans("������� ������ ��� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                Return New ErrString(obj.Props.ColumnReadOnly(args))
            Case UCase(trans("������ ������ ��� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(prop, args(1)) : Return es
                Return New ErrString(obj.Props.ItemReadOnly(args))
            Case UCase(trans("������ �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                Return New ErrString(obj.Props.ColumnsWidth(args))
            Case UCase(trans("������ ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                Return New ErrString(obj.Props.RowsHeight(args))
            Case UCase(trans("����� ������ ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = NikakoiEsli(args(0))
                Dim ind As Integer = Filters.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWFilters) : Return es
                Return New ErrString(obj.Props.GetFirstRow(args))
            Case UCase(trans("����� ��������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = NikakoiEsli(args(0))
                Dim ind As Integer = Filters.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWFilters) : Return es
                Return New ErrString(obj.Props.GetLastRow(args))
            Case UCase(trans("����� ��������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                args(1) = NikakoiEsli(args(1))
                Dim ind As Integer = Filters.IndexOfKey(LCase(args(1)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(1), HWFilters) : Return es
                Return New ErrString(obj.Props.GetNextRow(args))
            Case UCase(trans("����� ���������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                args(1) = NikakoiEsli(args(1))
                Dim ind As Integer = Filters.IndexOfKey(LCase(args(1)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(1), HWFilters) : Return es
                Return New ErrString(obj.Props.GetPreviousRow(args))
            Case UCase(trans("�������� �� �����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.HitTest(args))
            Case UCase(trans("����� ������ �� �����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.HitTestRow(args))
            Case UCase(trans("����� ������� �� �����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.HitTestColumn(args))
            Case UCase(trans("�������� ��������� �����"))
                Return New ErrString(obj.Props.SelectedItemsValue())
            Case UCase(trans("����� � �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 5 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(3)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(4)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.SearchInTable(args))
            Case UCase(trans("����� � ��������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.SearchInSelectedCells(args))


                ' PATH and FILES
            Case UCase(MyZnak & trans("�������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Hider(args))
            Case UCase(MyZnak & trans("������ ��� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.FileReadOnly(args))
            Case UCase(MyZnak & trans("��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Archive(args))
            Case UCase(MyZnak & trans("�����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Papka(args))
            Case UCase(MyZnak & trans("�������������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Encrypted(args))
            Case UCase(MyZnak & trans("�� �������������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.NotIndexer(args))
            Case UCase(MyZnak & trans("���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Systemiy(args))
            Case UCase(MyZnak & trans("���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Temp(args))
            Case UCase(MyZnak & trans("����� ��������"))
                If args Is Nothing Then Return New ErrString(ToMyDate(Now))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.CreateTime(args))
            Case UCase(MyZnak & trans("����� �������"))
                If args Is Nothing Then Return New ErrString(ToMyDate(Now))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.AccessTime(args))
            Case UCase(MyZnak & trans("����� ���������"))
                If args Is Nothing Then Return New ErrString(ToMyDate(Now))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.EditTime(args))
            Case UCase(MyZnak & trans("���������� ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return New ErrString(trans("���"))
                Return New ErrString(obj.Props.ExistFile(args))
            Case UCase(MyZnak & trans("���������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return New ErrString(trans("���"))
                Return New ErrString(obj.Props.ExistPath(args))
            Case UCase(MyZnak & trans("�������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.GetFiles(args))
            Case UCase(MyZnak & trans("�������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If obj.Props.ExistPath(args) = trans("���") Then es.err = Errors.PathNotExist(args(0)) : Return es
                Return New ErrString(obj.Props.GetPaths(args))
            Case UCase(MyZnak & trans("�������� �����"))
                Return New ErrString(obj.Props.GetDrives)
            Case UCase(MyZnak & trans("���������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.GetRoot(args))
            Case UCase(MyZnak & trans("���������� ������������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetParent(args))
            Case UCase(MyZnak & trans("���������� ��� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.GetPathName(args))
            Case UCase(MyZnak & trans("���������� ��� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetFileName(args))
            Case UCase(MyZnak & trans("���������� ����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetExtension(args))
            Case UCase(MyZnak & trans("���������� ��� ����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetFileNameWithoutExtension(args))
            Case UCase(MyZnak & trans("���������� ������ �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetFileSize(args))
            Case UCase(MyZnak & trans("����� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If NikakoiEsli(args(1)) = trans("�������") Then Return es
                If (args(1)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(1)) : Return es
                End If
                Return New ErrString(obj.Props.FindFile(args))
            Case MyZnak & UCase(trans("������� ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                args(1) = NikakoiEsli(args(1))
                Return New ErrString(obj.props.OpenFile(args))
            Case UCase(MyZnak & trans("���������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.FilesCount(args))
            Case UCase(MyZnak & trans("���������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.DirectoriesCount(args))

                ' PRERIVANIYA
            Case UCase(MyZnak & trans("��������� ���������")) : Return obj.Props.BreakApplication
            Case UCase(MyZnak & trans("��������� �������")) : Return obj.Props.BreakEvent
            Case UCase(MyZnak & trans("��������� ����")) : Return obj.Props.BreakLoop
            Case UCase(MyZnak & trans("��������� �������")) : Return obj.Props.StopIf
            Case UCase(MyZnak & trans("���������� ������")) : Return obj.Props.IgnoreErrors

                ' EKRAN
            Case UCase(MyZnak & trans("������� �������� �����")) : Return New ErrString(obj.Props.WallPaper)
            Case UCase(MyZnak & trans("����� �������� �����")) : Return New ErrString(obj.Props.DesktopStyle)
            Case UCase(MyZnak & trans("���������� ������")) : Return New ErrString(obj.Props.DesktopResolution)
            Case UCase(MyZnak & trans("������� ������")) : Return New ErrString(obj.Props.DesktopFrequency)
            Case UCase(MyZnak & trans("�������� �������������")) : Return New ErrString(obj.Props.DesktopBits)
            Case UCase(MyZnak & trans("��������")) : Return New ErrString(obj.Props.ScreenSaver)
            Case UCase(MyZnak & trans("��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NetTakNet(args(0)) = trans("�������") Then es.err = Errors.notDaOrNet(args(0)) : Return es
                args(0) = NetTakNet(args(0))
                Return New ErrString(obj.Props.ScreenShot(args))
            Case UCase(MyZnak & trans("�������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ScreenshotOfObject(args))



                ' SYSTEM
            Case UCase(MyZnak & trans("���� X")) : Return New ErrString(obj.Props.MouseX)
            Case UCase(MyZnak & trans("���� Y")) : Return New ErrString(obj.Props.MouseY)
            Case UCase(MyZnak & trans("������� ����������")) : Return New ErrString(obj.Props.KeyboardKey)
            Case UCase(MyZnak & trans("����� ����")) : Return New ErrString(obj.Props.KeyboardAlt)
            Case UCase(MyZnak & trans("����� ����")) : Return New ErrString(obj.Props.KeyboardShift)
            Case UCase(MyZnak & trans("����� �������")) : Return New ErrString(obj.Props.KeyboardControl)
            Case UCase(MyZnak & trans("������ ���� �����")) : Return New ErrString(obj.Props.MouseLeft)
            Case UCase(MyZnak & trans("������ ���� ������")) : Return New ErrString(obj.Props.MouseRight)
            Case UCase(MyZnak & trans("������� ������ ������")) : Return New ErrString(obj.Props.ClipboardPicture)
            Case UCase(MyZnak & trans("����� ������ ������")) : Return New ErrString(obj.Props.ClipboardText)
            Case UCase(MyZnak & trans("��������� � �����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.RunWithResult(args))
            Case UCase(MyZnak & trans("�������� �������")) : Return New ErrString(obj.Props.ProcessesList)
            Case UCase(MyZnak & trans("���� �������")) : Return New ErrString(obj.Props.WindowsList)
            Case UCase(MyZnak & trans("���� � ������")) : Return New ErrString(obj.Props.WindowInFocus)



                ' REGISTRY
            Case UCase(MyZnak & trans("�������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                Return New ErrString(obj.Props.Key(args))
            Case UCase(MyZnak & trans("���� ����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ExistKey(args))
            Case UCase(MyZnak & trans("����� ����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ExistSubKey(args))
            Case UCase(MyZnak & trans("��� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.TypeKey(args))

                ' TEXT BOKS
            Case UCase(trans("����� ������� �� �����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.GetCharIndexFromPosition(args))
            Case UCase(trans("����� ������� ������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.GetFirstCharIndexFromLine(args))
            Case UCase(trans("����� ������� ������� ������� ������")) : Return New ErrString(obj.Props.GetFirstCharIndexOfCurrentLine)
            Case UCase(trans("����� ������ �� ������ �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.GetLineFromCharIndex(args))
            Case UCase(trans("X �� ������ �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.GetXFromCharIndex(args))
            Case UCase(trans("Y �� ������ �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.GetYFromCharIndex(args))
            Case UCase(trans("������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.Line(args))
            Case UCase(trans("���������� �����")) : Return New ErrString(obj.Props.LinesCount)
            Case UCase(trans("������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.Chars(args))
            Case UCase(trans("���������� ��������")) : Return New ErrString(obj.Props.CharsLength)

                ' TEXTS POLEZNIE
            Case MyZnak & UCase(trans("������ �� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If args(1) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1)) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                Return New ErrString(obj.Props.Chars(args))
            Case MyZnak & UCase(trans("�������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Compare(args))
            Case MyZnak & UCase(trans("����� ������� ��"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ConsistAll(args))
            Case MyZnak & UCase(trans("����� ���� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.isNumberText(args))
            Case MyZnak & UCase(trans("����� ���� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.isNumericText(args))
            Case MyZnak & UCase(trans("����� ������ ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.IndexOfLine(args))
            Case MyZnak & UCase(trans("����� � ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.IndexOfIgnoreCase(args))
            Case MyZnak & UCase(trans("����� � ������ ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.IndexOf(args))
            Case MyZnak & UCase(trans("����� � ������ � �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                'If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.LastIndexOfIgnoreCase(args))
            Case MyZnak & UCase(trans("����� � ����������� �����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.IndexOfRegular(args))
            Case MyZnak & UCase(trans("���������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.CharsLength(args))
            Case MyZnak & UCase(trans("������� �� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.Split(args))
            Case MyZnak & UCase(trans("����� ����� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If args(1) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1)) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                ' If args(1) - 1 + args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1) - 1 + args(2)) : Return es
                Return New ErrString(obj.Props.Substring(args))
            Case MyZnak & UCase(trans("���������� ������ ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.SplitCount(args))
            Case MyZnak & UCase(trans("������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DeleteQuotes(args))
            Case MyZnak & UCase(trans("��������� ���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.PutInQuotes(args))
            Case MyZnak & UCase(trans("����� ��� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.IndexOfWithoutQuotes(args))
            Case MyZnak & UCase(trans("������� �� ����� ��� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.SplitWithoutQuotes(args))
            Case MyZnak & UCase(trans("���������� ������ ��� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.SplitWithoutQuotesCount(args))
            Case MyZnak & UCase(trans("����� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Consist(args))
            Case MyZnak & UCase(trans("����� �� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ConsistNo(args))
            Case MyZnak & UCase(trans("������ �� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                Return New ErrString(obj.Props.Line(args))
            Case MyZnak & UCase(trans("���������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.LinesCount(args))
            Case MyZnak & UCase(trans("����������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.EncryptText(args))
            Case MyZnak & UCase(trans("������������ �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DecryptText(args))

            Case MyZnak & UCase(trans("�������� ������� � �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If args(1) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1)) : Return es
                Return New ErrString(obj.Props.Insert(args))
            Case MyZnak & UCase(trans("������� ����� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If args(1) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1)) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                'If args(1) - 1 + args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1) - 1 + args(2)) : Return es
                Return New ErrString(obj.Props.Remove(args))
            Case MyZnak & UCase(trans("��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ReplaceOne(args))
            Case MyZnak & UCase(trans("�������� ���"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ReplaceAll(args))
            Case MyZnak & UCase(trans("������� ����� ����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.toLower(args))
            Case MyZnak & UCase(trans("������� ����� ����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.toUpper(args))
            Case MyZnak & UCase(trans("������ �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.TrimAll(args))
            Case MyZnak & UCase(trans("������ ������� � ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.TrimStart(args))
            Case MyZnak & UCase(trans("������ ������� � �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.TrimEnd(args))

                ' ���������
            Case MyZnak & UCase(trans("���� ������ ������")) : Return New ErrString(obj.Props.WasCancel)
            Case MyZnak & UCase(trans("���� ������ ��")) : Return New ErrString(obj.Props.WasOk)
            Case MyZnak & UCase(trans("���� ������ ���������")) : Return New ErrString(obj.Props.WasRetry)
            Case MyZnak & UCase(trans("���� ������ ��")) : Return New ErrString(obj.Props.WasYes)
            Case MyZnak & UCase(trans("���� ������ ���")) : Return New ErrString(obj.Props.WasNo)
            Case MyZnak & UCase(trans("���� ������ ��������")) : Return New ErrString(obj.Props.WasAbort)
            Case MyZnak & UCase(trans("���� ������ ����������")) : Return New ErrString(obj.Props.WasIgnore)
            Case MyZnak & UCase(trans("���� ������ �������")) : Return New ErrString(obj.Props.WasHelp)

                ' DATE
            Case MyZnak & UCase(trans("���� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DayOfMonth(args))
            Case MyZnak & UCase(trans("���� ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DayOfYear(args))
            Case MyZnak & UCase(trans("���� � ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DayOfWeek(args))
            Case MyZnak & UCase(trans("���"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Hour(args))
            Case MyZnak & UCase(trans("������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Minute(args))
            Case MyZnak & UCase(trans("�������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Second(args))
            Case MyZnak & UCase(trans("�������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Quarter(args))
            Case MyZnak & UCase(trans("������ � ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.WeekOfYear(args))
            Case MyZnak & UCase(trans("���"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Year(args))
            Case MyZnak & UCase(trans("�����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Month(args))
            Case MyZnak & UCase(trans("�����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Time(args))
            Case MyZnak & UCase(trans("������ ����� � ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Ticks(args))
            Case MyZnak & UCase(trans("���� � ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                If Int(args(0)) > 9999 Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If Int(args(1)) > 12 Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DaysInMonth(args))
            Case MyZnak & UCase(trans("������")) : Return New ErrString(obj.Props.Now)
            Case MyZnak & UCase(trans("�������")) : Return New ErrString(obj.Props.Today)
            Case MyZnak & UCase(trans("��������� ���"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddDay(args))
            Case MyZnak & UCase(trans("��������� ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddHour(args))
            Case MyZnak & UCase(trans("��������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddMinute(args))
            Case MyZnak & UCase(trans("��������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddSecond(args))
            Case MyZnak & UCase(trans("��������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddQuarter(args))
            Case MyZnak & UCase(trans("��������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddWeek(args))
            Case MyZnak & UCase(trans("��������� ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddYear(args))
            Case MyZnak & UCase(trans("��������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddMonth(args))
            Case MyZnak & UCase(trans("������� � ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffDay(args))
            Case MyZnak & UCase(trans("������� � �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffHour(args))
            Case MyZnak & UCase(trans("������� � �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffMinute(args))
            Case MyZnak & UCase(trans("������� � ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffSecond(args))
            Case MyZnak & UCase(trans("������� � ���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffQuarter(args))
            Case MyZnak & UCase(trans("������� � �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffWeek(args))
            Case MyZnak & UCase(trans("������� � �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffYear(args))
            Case MyZnak & UCase(trans("������� � �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffMonth(args))
            Case MyZnak & UCase(trans("���� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.WeekdayName(args))
            Case MyZnak & UCase(trans("�������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.MonthName(args))
            Case MyZnak & UCase(trans("���� � ������������ �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If Int(args(1)) > 53 Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.GetDateTimeFormats(args))

                ' SOBYTS PROPERTY
            Case Else
                ' ����� ��� �������� �������
PropVParam:     If vParamah Then
                    ' ����� ������ �������, �� ������� �� ��������� ������������ ��� ��������� ������ Param
                    If RunProj.Param.ParamyUp.IndexOfKey(UCase(prop)) <> -1 And MyObj.isrun Then
                        Return New ErrString(RunProj.Param.Paramy.GetByIndex(RunProj.Param.ParamyUp.IndexOfKey(UCase(prop))))
                    End If
                Else
                    ' ����� ����� ��������
                    Dim SobytObjs As New Sobitiya(MyZnak & "All")
                    If SobytObjs.EstProperty(prop) And MyObj.isrun Then
                        Return New ErrString(RunProj.Param.Paramy.GetByIndex(RunProj.Param.ParamyUp.IndexOfKey(UCase(prop))))
                    End If
                End If




        End Select
        Return New ErrString(word)
    End Function

    Public Function SetProperty(ByVal MyObj As Object, ByVal prop As String, ByVal value As String, Optional ByVal fromEng As Boolean = False) As MsgBoxResult
        prop = UCase(prop)
        If MyObj Is Nothing Then Exit Function
        If Array.IndexOf(MyObj.PropertysUp, prop) = -1 Then Return MsgBoxResult.Yes ' ���� ��� ������ �������� �� ����� �� �������
        Dim es As ErrString = SetPropertyMethod(MyObj, prop, value, Nothing, fromEng)
        If es.err <> "" Then
            If es.str = "Cancel" Then Return MsgBoxResult.Cancel
            If es.str <> "MsgBox ne nado" And IsHttpCompil = False Then MsgBox(es.err, MsgBoxStyle.Exclamation)
            Return MsgBoxResult.No
        End If
        Return MsgBoxResult.Yes
    End Function
    Public Function SetPropertyMethod(ByVal MyObj As Object, ByVal prop As String, ByVal value As String, ByVal args() As String, Optional ByVal fromEng As Boolean = False) As ErrString
        Dim obj As Object = MyObj.obj, j As Integer
        prop = UCase(prop) : Dim refresh As Boolean, es As ErrString

        ' ������ ��� ������
        If Array.IndexOf(ReadOnlyProps, prop) <> -1 Then es.err = Errors.isReadOnly(prop) : Return es

        ' �������� ������ |� �� ������
        value = perevesti(value, True)
        ' �������� � ���������� ��� ���� �� ������
        If prop <> MyZnak & UCase(trans("��������� ��� ���������2")) Then
            If args Is Nothing = False Then
                For j = 0 To args.Length - 1
                    args(j) = perevesti(args(j), True)
                Next
            End If
        End If

        Select Case prop
            Case UCase(trans("���"))
                If ValidName(value) = False Then es.err = Errors.NameInvalid(value) : es.str = "MsgBox ne nado" : Return es
                If MyObj.isRun = False And fromEng = False And isConsole = False Then
                    If proj.ExistName(value, obj) Then ' ���� ��� ��� ����������
                        If obj.Props.index = 0 Then
                            Dim result As MsgBoxResult ' ���������� ������� ������
                            If obj.parent Is Nothing = False Then
                                result = MsgBox(Errors.CreateMassive(value), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
                            Else
                                ' ���� ���� �������, �� �������� ��������� �� ����
                                result = MsgBoxResult.Retry
                            End If
                            If result = MsgBoxResult.Yes Then
                                proj.ActiveForm.CreateMassive(value, MyObj) ' ������� ������
                                proj.ActiveForm.recur = True
                                'proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                            ElseIf result = MsgBoxResult.No Then
                                MsgBox(Errors.NameExist(value), MsgBoxStyle.Exclamation)
                                es.err = "!" : es.str = "MsgBox ne nado" : Return es ' ����� ��������� ������ MsgBoxResult.No, �� ��� ��������
                            ElseIf result = MsgBoxResult.Cancel Then
                                es.err = "!" : es.str = "Cancel" : Return es ' ����� ��������� ������ MsgBoxResult.No, �� ��� ��������
                            Else
                            End If
                        Else ' ���� ����� ������ ��� ����, �� ���� ��� ������, �������� ��� ���
                            obj.Props.index = MyObj.GetMyForm.GetIndex(value, obj, obj.Props.index) : refresh = True
                        End If : obj.refresh() ' ���� ����������� �������
                    End If
                End If

                obj.Props.Name = value
                If MyObj.isRun Then Return es

                If refresh = True Then
                    proj.ActiveForm.FillListView()
                Else
                    If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)
                End If
                If Iz.IsFORM(MyObj) Then MyObj.TabTextRefresh()
            Case UCase(trans("������� �������"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("�������") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.BackgroundImage = value
            Case UCase(trans("������� �������1"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("�������") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.BackgroundImage1 = value
            Case UCase(trans("������� �������2"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("�������") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.BackgroundImage2 = value
            Case UCase(trans("����"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.BackColor = col
            Case UCase(trans("����1"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.BackColor1 = col
            Case UCase(trans("����2"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.BackColor2 = col
            Case UCase(trans("�����"))
                If MyObj.getmyform Is Nothing = False Then
                    If MyObj.getmyform.ExistIndex(MyObj.obj, MyObj.obj.Props.name, value) Then
                        es.err = "!" : es.str = "MsgBox ne nado"
                        If proj.UndoRedoNoWrite = False Then es.err = Errors.InvalidIndex(value) : es.str = ""
                        Return es
                    End If
                End If
                If value = "" Then value = MyObj.GetMyForm.GetIndex(obj.Props.name, obj, "0")
                obj.Props.index = value

                If MyObj.isRun Then Return es
                obj.refresh()
                If Iz.IsFORM(MyObj) Then MyObj.TabTextRefresh()
            Case UCase(trans("�������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.position = value
            Case UCase(trans("������� �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.mainform = value
            Case UCase(trans("����������� ����"))
                obj.Props.contextmenu = value
            Case UCase(trans("����������� ����1"))
                obj.Props.contextmenu1 = value
            Case UCase(trans("����������� ����2"))
                obj.Props.contextmenu2 = value
            Case UCase(trans("��������� ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ForbidClose = value
            Case UCase(trans("��������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Anchors.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWAnchors) : Return es
                obj.Props.Anchor = value
            Case UCase(trans("�������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AutoEllipsis = value
            Case UCase(trans("����� ����"))
                value = NikakoiEsli(value)
                Dim ind As Integer = bkImStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWbkImStyles) : Return es
                obj.Props.BackgroundImageLayout = value
            Case UCase(trans("����� ����1"))
                value = NikakoiEsli(value)
                Dim ind As Integer = bkImStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWbkImStyles) : Return es
                obj.Props.BackgroundImageLayout1 = value
            Case UCase(trans("����� ����2"))
                value = NikakoiEsli(value)
                Dim ind As Integer = bkImStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWbkImStyles) : Return es
                obj.Props.BackgroundImageLayout2 = value
            Case UCase(trans("����� �������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = SizeModes.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWSizeModes) : Return es
                obj.Props.SizeMode = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Cursori.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWCursori) : Return es
                obj.Props.Cursor = value
            Case UCase(trans("������1"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Cursori.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWCursori) : Return es
                obj.Props.Cursor1 = value
            Case UCase(trans("������2"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Cursori.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWCursori) : Return es
                obj.Props.Cursor2 = value
            Case UCase(trans("��������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Docks.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWDocks) : Return es
                obj.Props.Dock = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Enabled = value
            Case UCase(trans("����� ������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = FlatStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFlatStyles) : Return es
                obj.Props.FlatStyle = value
            Case UCase(trans("����� �����"))
                value = NikakoiEsli(value)
                Dim ind As Integer = BorderStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWBorderStyles) : Return es
                obj.Props.BorderStyle = value
            Case UCase(trans("�����"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Fonts.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFonts) : Return es
                obj.Props.FontFamily = value
            Case UCase(trans("����� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FontBold = value
            Case UCase(trans("����� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FontItalic = value
            Case UCase(trans("����� ������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FontUnderline = value
            Case UCase(trans("����� �����������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FontStrikeOut = value
            Case UCase(trans("����� ������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.FontSize = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("���� ������"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.ForeColor = col
            Case UCase(trans("�������"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("�������") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.Image = value
            Case UCase(trans("��������� �������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Aligns.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWAligns) : Return es
                obj.Props.ImageAlign = value
            Case UCase(trans("X"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.X = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Y"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.Y = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("������������ ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MaximumWidth = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("������������ ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MaximumHeight = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("����������� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MinimumWidth = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("����������� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MinimumHeight = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("���� �����"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.PaddingLeft = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("���� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.PaddingTop = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("���� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.PaddingRight = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("���� �����"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.PaddingBottom = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.Height = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.Width = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("��������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.TabIndex = value
            Case UCase(trans("�������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.TabStop = value
            Case UCase(trans("��������������� ����"))
                obj.Props.Tag = value
            Case UCase(trans("�����"))
                obj.Props.Text = value
            Case UCase(trans("��������� ������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Aligns.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWAligns) : Return es
                obj.Props.TextAlign = value
            Case UCase(trans("������������ ������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TextPositions.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTextPositions) : Return es
                obj.Props.TextPosition = value
            Case UCase(trans("����� � �������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TextImages.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTextImages) : Return es
                obj.Props.TextImageRelation = value
            Case UCase(trans("�������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Visible = value
            Case UCase(trans("���������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Scroll = value
            Case UCase(trans("���������1"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Scroll1 = value
            Case UCase(trans("���������2"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Scroll2 = value
            Case UCase(trans("������������� �����"))
                value = NikakoiEsli(value)
                Dim ind As Integer = FixedPanels.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFixedPanels) : Return es
                obj.Props.FixedPanel = value
            Case UCase(trans("������������� �����������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FixedSplitter = value
            Case UCase(trans("������1 ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Panel1Collapsed = value
            Case UCase(trans("������2 ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Panel2Collapsed = value
            Case UCase(trans("����������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Orientations.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWOrientations) : Return es
                obj.Props.Orientation = value
            Case UCase(trans("������ �����������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.SplitterWidth = value
            Case UCase(trans("���������� �����������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SplitterDistance = value
            Case UCase(trans("��������� �����������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SplitterIncrement = value
            Case UCase(trans("������1 �������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Panel1MinSize = value
            Case UCase(trans("������2 �������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Panel2MinSize = value
            Case MyZnak & UCase(trans("�������� �����������"))
                If RunProj.Param.ParamyUp.ContainsKey(MyZnak & UCase(trans("�������� �����������"))) Then
                    RunProj.Param.ParamyUp(MyZnak & UCase(trans("�������� �����������"))) = value
                Else
                    es.err = "!"
                End If
            Case MyZnak & UCase(trans("�������� ����"))
                If RunProj.Param.ParamyUp.ContainsKey(MyZnak & UCase(trans("�������� ����"))) Then
                    RunProj.Param.ParamyUp(MyZnak & UCase(trans("�������� ����"))) = value
                Else
                    es.err = "!"
                End If
            Case MyZnak & UCase(trans("�������� �������"))
                If RunProj.Param.ParamyUp.ContainsKey(MyZnak & UCase(trans("�������� �������"))) Then
                    RunProj.Param.ParamyUp(MyZnak & UCase(trans("�������� �������"))) = value
                Else
                    es.err = "!"
                End If
            Case MyZnak & UCase(trans("�������� � ����� ����"))
                If RunProj.Param.ParamyUp.ContainsKey(MyZnak & UCase(trans("�������� � ����� ����"))) Then
                    RunProj.Param.ParamyUp(MyZnak & UCase(trans("�������� � ����� ����"))) = value
                Else
                    es.err = "!"
                End If
            Case UCase(trans("�������� ���������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.HideSelection = value
            Case UCase(trans("������������ ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MaximumLength = value
            Case UCase(trans("���������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Multiline = value
            Case UCase(trans("������ ������"))
                If NikakoiEsli(value) = trans("�������") Then value = ""
                If value.Length > 1 Then es.err = Errors.notChar(value) : Return es
                obj.Props.PasswordChar = value
            Case UCase(trans("������ ��� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ReadOnly = value
            Case UCase(trans("������ ���������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = ScrollBarz.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWScrollBarz) : Return es
                obj.Props.ScrollBars = value
            Case UCase(trans("������� �� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.WordWrap = value
            Case UCase(trans("���������� �����"))
                obj.Props.SelectedText = value
            Case UCase(trans("������ ���������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.SelectionStart = value
            Case UCase(trans("������ ���������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.SelectionLength = value
            Case UCase(trans("��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Checked = value
            Case UCase(trans("���������� ������������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Orientations.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWOrientations) : Return es
                obj.Props.OrientationTools = value
            Case UCase(trans("���������� �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Alignment = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("���������� ���������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AutoToolTip = value
            Case UCase(trans("������� �� �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.CheckOnClick = value
            Case UCase(trans("����� �����������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = DisplayStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWDisplayStyles) : Return es
                obj.Props.DisplayStyle = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("��������� ����������� ����"))
                obj.Props.DropDown = value
            Case UCase(trans("������� ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ImageScaling = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("���������� ���� �������"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.ImageTransparentColor = col
            Case UCase(trans("������� �������"))
                es = UbratKovich(value)
                If es.err <> "" Then Return es
                obj.Props.ShortcutKeys = es.str
            Case UCase(trans("���������� ������� �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowShortcutKeys = value
            Case UCase(trans("����������� ������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TextDirections.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTextDirections) : Return es
                obj.Props.TextDirection = value
            Case UCase(trans("����������� ���������"))
                obj.Props.ToolTipText = value
            Case UCase(trans("���������� �� ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowNavigation = value
            Case UCase(trans("��������� ��������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowWebBrowserDrop = value
            Case UCase(trans("����� ��������"))
                obj.Props.DocumentText = value
            Case UCase(trans("����������� ���� ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.isWebBrowserContextMunuEnabled = value
            Case UCase(trans("���������� ������ ���������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ScriptErrorsSuppressed = value
            Case UCase(trans("������ ��������� �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ScrollBarsEnabled = value
            Case UCase(trans("������"))
                obj.Props.Url = value
            Case UCase(trans("������ �������"))
                obj.Props.LinkName = value
            Case UCase(trans("������� ������� ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.WebBrowserShortcutsEnabled = value
            Case UCase(trans("���������"))
                value = NikakoiEsli(value)
                ' Dim ind As Integer = DocumentEncodings.IndexOfKey(LCase(value))
                'If ind = -1 Then es.err = Errors.notCollection(prop, value, HWDocumentEncodings) : Return es
                obj.Props.DocumentEncoding = value
            Case UCase(trans("����"))
                obj.Props.Cookie = value
            Case UCase(trans("�������� ������ ������ ����"))
                obj.Props.OpenNewWindowLink = value
            Case UCase(trans("������� � ����� ����"))
                obj.props.NavigateNewPage()
            Case MyZnak & UCase(trans("������� � ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.props.NavigateInFrame(args)
            Case UCase(trans("�������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Dim ind As Integer = Refreshs.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWRefreshs) : Return es
                obj.Props.RefreshPage(args)
            Case UCase(trans("������� ������ � ����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ControlBox = value
            Case UCase(trans("����� ����"))
                value = NikakoiEsli(value)
                Dim ind As Integer = FormBorderStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFormBorderStyles) : Return es
                obj.Props.FormBorderStyle = value
            Case UCase(trans("������� ����"))
                obj.Props.MainMenuStrip = value
            Case UCase(trans("������������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                If Int(value) > 100 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.Opacity = value
            Case UCase(trans("���������� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowIcon = value
            Case UCase(trans("���������� � ������ �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowInTaskbar = value
            Case UCase(trans("��������� �������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = StartPositions.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWStartPositions) : Return es
                obj.Props.StartPosition = value
            Case UCase(trans("������ ���� ����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.TopMost = value
            Case UCase(trans("������ ����"))
                value = NikakoiEsli(value)
                Dim ind As Integer = WindowStates.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWWindowStates) : Return es
                obj.Props.WindowState = value
            Case UCase(trans("��������� ����������� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.AutoScrollMinSizeWidth = value
            Case UCase(trans("��������� ����������� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.AutoScrollMinSizeHeight = value
            Case UCase(trans("���������� �� X"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.AutoScrollPositionX = value
            Case UCase(trans("���������� �� Y"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.AutoScrollPositionY = value
            Case UCase(trans("������"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("�������") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.Icon = value
            Case UCase(trans("���������� ����"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.TransparentcyKey = col
            Case UCase(trans("��������� ��������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Alignments.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWAlignments) : Return es
                obj.Props.TabAlignment = value
            Case UCase(trans("������� ���������� ��������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                'If Int(value) > obj.TabCount - 1 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.SelectedTabPosition = value
            Case UCase(trans("���� �� �����������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.PaddingX = value
            Case UCase(trans("���� �� ���������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.PaddingX = value
            Case UCase(trans("��������"))
                obj.Props.Value = value
            Case UCase(trans("���������"))
                obj.Props.ToolTip = value
            Case UCase(trans("�������� � ������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AutoRun = value
            Case UCase(trans("��������� ������ �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowRunCopies = value
            Case UCase(trans("��������� �������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = InputTypes.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWInputTypes) : Return es
                obj.Props.AllowInput = value
            Case UCase(trans("�������� ������ ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.FromPage = value
            Case UCase(trans("�������� ����� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.ToPage = value
            Case UCase(trans("����� �����"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Copies = value
            Case UCase(trans("������ ��������"))
                obj.Props.WidthOfColumns = value
            Case UCase(trans("������ �����"))
                obj.Props.HeightOfRows = value


                ' �������
            Case UCase(trans("��������� ��������� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToAddRows = value
            Case UCase(trans("��������� ������� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToDeleteRows = value
            Case UCase(trans("��������� ������������ �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToOrderColumns = value
            Case UCase(trans("��������� ����������� �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToResizeColumns = value
            Case UCase(trans("��������� ����������� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToResizeRows = value
            Case UCase(trans("���������� ����� �������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.RowsCount = value
            Case UCase(trans("���������� ��������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.ColumnsCount = value
            Case UCase(trans("����� ����� ������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = CellBorderStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWCellBorderStyles) : Return es
                obj.Props.CellBorderStyle = value
            Case UCase(trans("���������� ��������� ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ColumnHeadersVisible = value
            Case UCase(trans("���������� ����������� �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.RowHeadersVisible = value
            Case UCase(trans("������ ���������� ��������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.ColumnHeadersHeight = value
            Case UCase(trans("�������"))
                obj.Props.Columns = value
            Case UCase(trans("������"))
                obj.Props.Rows = value
            Case UCase(trans("���� ���� �����"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DefaultCellStyleBackColor = col
            Case UCase(trans("���� ���� ���������� �����"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DefaultCellStyleSelectionBackColor = col
            Case UCase(trans("���� ������ �����"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DefaultCellStyleForeColor = col
            Case UCase(trans("���� ������ ���������� �����"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DefaultCellStyleSelectionForeColor = col
            Case UCase(trans("����� ��������������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = EditModes.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWEditModes) : Return es
                obj.Props.EditMode = value
            Case UCase(trans("���� �����"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.GridColor = col
            Case UCase(trans("����� ���������� �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MultiSelect = value
            Case UCase(trans("����� ���������� �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MultiSelectItems = value
            Case UCase(trans("������ ��� ������ �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ReadOnlyTable = value
            Case UCase(trans("����� ���������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = SelectionModes.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWSelectionModes) : Return es
                obj.Props.SelectionMode = value
            Case UCase(trans("������ ���������� �����"))
                Dim str() As String = value.Split(","), i As Integer
                For i = 0 To str.Length - 1
                    If str(i) <> "" Then
                        If Iz.isInteger(str(i)) = False Then es.err = Errors.notInt(str(i), prop) : Return es
                        If Int(str(i)) < 0 Then es.err = Errors.notInt(str(i), prop) : Return es
                    End If
                Next
                obj.Props.SelectedRows = value
            Case UCase(trans("������ ���������� ��������"))
                Dim str() As String = value.Split(","), i As Integer
                For i = 0 To str.Length - 1
                    If str(i) <> "" Then
                        If Iz.isInteger(str(i)) = False Then es.err = Errors.notInt(str(i), prop) : Return es
                        If Int(str(i)) < 0 Then es.err = Errors.notInt(str(i), prop) : Return es
                    End If
                Next
                obj.Props.SelectedColumns = value
            Case UCase(trans("�������� ������"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ItemValue(args) = value
            Case UCase(trans("������ ��������"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(prop, args(1)) : Return es
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ItemSelected(args) = value
            Case UCase(trans("������ ������ ��� ������"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.RowsReadOnly(args) = value
            Case UCase(trans("������� ������ ��� ������"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ColumnReadOnly(args) = value
            Case UCase(trans("������ ������ ��� ������"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(prop, args(1)) : Return es
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ItemReadOnly(args) = value
            Case UCase(trans("������ �������"))
                value = NullTakNull(value)
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isDouble(value) = False Then
                '    es.err = Errors.notInt(value, prop) : Return es
                'Else : value = Int(value) : End If
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                obj.Props.ColumnsWidth(args) = value
            Case UCase(trans("������ ������"))
                value = NullTakNull(value)
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isDouble(value) = False Then
                '    es.err = Errors.notInt(value, prop) : Return es
                'Else : value = Int(value) : End If
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                obj.Props.RowsHeight(args) = value
            Case UCase(trans("�������� ����� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = Trim(args(0).Split(",")(0))
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If args(0) >= obj.rows.count Then es.err = Errors.notRowCount(args(0), prop) : Return es
                If Int(args(0)) + args(1) > obj.rows.count Then es.err = Errors.notRowCount(Int(args(0)) + args(1), prop) : Return es
                obj.Props.RowsAddCopies(args)
            Case UCase(trans("�������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = Trim(args(0).Split(",")(0))
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If args(0) > obj.rows.count Then es.err = Errors.notRowCount(args(0), prop) : Return es
                obj.Props.RowsInsert(args)
            Case UCase(trans("�������� ����� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = Trim(args(0).Split(",")(0))
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                args(1) = Trim(args(1).Split(",")(0))
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(0) > obj.rows.count Then es.err = Errors.notRowCount(args(0), prop) : Return es
                If args(1) >= obj.rows.count Then es.err = Errors.notRowCount(args(1), prop) : Return es
                If Int(args(1)) + args(2) > obj.rows.count Then es.err = Errors.notRowCount(Int(args(1)) + args(2), prop) : Return es
                obj.Props.RowsInsertCopies(args)
            Case UCase(trans("������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.RowsRemove(args)
            Case UCase(trans("��������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.SaveTable(args)
            Case UCase(trans("������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.OpenTable(args)
            Case UCase(trans("�����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If args(0) >= obj.columns.count Then es.err = Errors.notRowCount(args(0), prop) : Return es
                obj.Props.SortTable(args)
            Case UCase(trans("������� Access"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                If NikakoiEsli(args(1)) = trans("�������") Then Return es
                obj.props.OpenAccess(args)
            Case UCase(trans("������� Excel"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                If NikakoiEsli(args(1)) = trans("�������") Then Return es
                obj.props.OpenExcel(args)
            Case UCase(trans("��������� Access"))
                obj.props.SaveAccess()
            Case UCase(trans("�������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = Trim(args(0).Split(",")(0))
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If args(0) > obj.columns.count Then es.err = Errors.notColumnCount(args(0), prop) : Return es
                obj.Props.ColumnsInsert(args)
            Case UCase(trans("������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ColumnsRemove(args)
            Case UCase(trans("�������� ������"))
                obj.Props.RowsAdd(args)
            Case UCase(trans("�������� �������"))
                obj.Props.ColumnsAdd(args)
            Case UCase(trans("SQL ������ �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = NikakoiEsli(args(0))
                Dim ind As Integer = BdTypes.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWBdTypes) : Return es
                obj.Props.SQLquerySelect(args)
            Case UCase(trans("SQL ������ ���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = NikakoiEsli(args(0))
                Dim ind As Integer = BdTypes.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWBdTypes) : Return es
                obj.Props.SQLqueryInto(args)
            Case UCase(trans("����� � ����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 5 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(3)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(4)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                obj.Props.SearchWithSelect(args)
            Case UCase(trans("�������� ��������� �����"))
                obj.Props.SelectedItemsValue() = value



                ' ������
            Case UCase(trans("������ ��������������� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.DropDownHeight = value
            Case UCase(trans("������ ��������������� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.DropDownWidth = value
            Case UCase(trans("������ ����������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.DropDownStyle = value
            Case UCase(trans("������ ������"))
                obj.Props.Items = value
            Case UCase(trans("���������� �������������� �������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.MaxDropDownItems = value
            Case UCase(trans("���������� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Sorted = value
            Case UCase(trans("������ �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.DroppedDown = value
            Case UCase(trans("����� ���������� ������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then Return es
                If obj.items.count <= value Then es.err = Errors.noItems(prop, value) : Return es
                obj.Props.SelectedIndex = value
            Case UCase(trans("���������� ������"))
                obj.Props.SelectedItem = value
            Case UCase(trans("������ �� ������"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If obj.items.count <= args(0) Then es.err = Errors.noItems(prop, args(0)) : Return es
                obj.Props.ItemsItem(args) = value
            Case UCase(trans("����� ����� ������"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ItemsIndexOf(args) = value
            Case UCase(trans("�������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ItemsAdd(args)
            Case UCase(trans("�������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If obj.items.count < args(0) Then es.err = Errors.noItems(prop, args(0)) : Return es
                obj.Props.ItemsInsert(args)
            Case UCase(trans("������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ItemsRemove(args)
            Case UCase(trans("������� ������ �� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If obj.items.count <= args(0) Then es.err = Errors.noItems(prop, args(0)) : Return es
                obj.Props.ItemsRemoveAt(args)
            Case UCase(trans("������ ������� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.ColumnWidth = value
            Case UCase(trans("�������������� ���������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.HorizontalScrollBar = value
            Case UCase(trans("���������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MultiColumn = value
            Case UCase(trans("��������� �������� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionModeList = value
            Case UCase(trans("������ ��������� �������"))
                obj.Props.CheckedIndices = value
            Case UCase(trans("���������� ������"))
                obj.Props.CheckedItems = value
            Case UCase(trans("������ ���������� �������"))
                obj.Props.SelectedIndices = value
            Case UCase(trans("���������� ������"))
                obj.Props.SelectedItems = value

                ' ������
            Case UCase(trans("���� �������� ������"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.ActiveLinkColor = col
            Case UCase(trans("���� ��������� ������"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DisabledLinkColor = col
            Case UCase(trans("���� ������"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.LinkColor = col
            Case UCase(trans("���� ���������� ������"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.VisitedLinkColor = col
            Case UCase(trans("������ ������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.LinkStart = value
            Case UCase(trans("������ ������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.LinkLength = value
            Case UCase(trans("����� �������������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = LinkBehaviors.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWLinkBehaviors) : Return es
                obj.Props.LinkBehavior = value
            Case UCase(trans("������ ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.LinkVisited = value
            Case UCase(trans("������ �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.LinkEnabled = value
            Case UCase(trans("���������� � �������� �� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.InternetLink = value

                ' ��������� ��������
            Case UCase(trans("������������ ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.DetectUrls = value
            Case UCase(trans("��������� ������� �����������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.EnableAutoDragDrop = value
            Case UCase(trans("�������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.ZoomFactor = value
            Case UCase(trans("RTF ��� ���������"))
                obj.Props.Rtf = value
            Case UCase(trans("���������� RTF"))
                obj.Props.SelectedRtf = value
            Case UCase(trans("���������� ������ ���"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.SelectionBackColor = col
            Case UCase(trans("���������� ���� ������"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.SelectionColor = col
            Case UCase(trans("���������� ��������� ������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TextPositions.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTextPositions) : Return es
                obj.Props.SelectionAlignment = value
            Case UCase(trans("���������� ������ ������� ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SelectionHangingIndent = value
            Case UCase(trans("���������� ������ �����"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SelectionIndent = value
            Case UCase(trans("���������� ������ ������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SelectionRightIndent = value
            Case UCase(trans("���������� ����� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionBullet = value
            Case UCase(trans("���������� ������������ ��������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SelectionCharOffset = value
            Case UCase(trans("���������� �����"))
                value = NikakoiEsli(value)
                If value = trans("�������") Then Return es
                Dim ind As Integer = Fonts.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFonts) : Return es
                obj.Props.SelectionFontFamily = value
            Case UCase(trans("���������� ����� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionFontBold = value
            Case UCase(trans("���������� ����� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionFontItalic = value
            Case UCase(trans("���������� ����� ������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionFontUnderline = value
            Case UCase(trans("���������� ����� �����������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionFontStrikeOut = value
            Case UCase(trans("���������� ����� ������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.SelectionFontSize = value
            Case UCase(trans("���������� ����� ������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionProtected = value
            Case UCase(trans("��������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.SaveFile(args)
            Case UCase(trans("������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.OpenFile(args)

                ' �������
            Case UCase(trans("��������� ����"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DialogColor = col
            Case UCase(trans("��������� �������� ����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowColor = value
            Case UCase(trans("��������� �������� �������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowEffects = value
            Case UCase(trans("������� � ����"))
                obj.props.Description = value
            Case UCase(trans("��������� �����"))
                If value.Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(value) : Return es
                End If
                obj.props.SelectedPath = value
            Case UCase(trans("��������� ���������� �����"))
                obj.props.DefaultExt = value
            Case UCase(trans("��������� ������� �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.CheckFileExists = value
            Case UCase(trans("��������� ������� �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.CheckPathExists = value
            Case UCase(trans("��� �����"))
                If value.Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(value) : Return es
                End If
                obj.props.FileName = value
            Case UCase(trans("������ ������"))
                obj.props.Filter = value
            Case UCase(trans("����� �������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.FilterIndex = value
            Case UCase(trans("��������� �����"))
                If value.Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(value) : Return es
                End If
                obj.props.InitialDirectory = value
            Case UCase(trans("���������"))
                obj.props.Title = value
            Case UCase(trans("����� ���������� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MultiSelectFiles = value
            Case UCase(trans("����� �� ������"))
                obj.props.PrintText = value
            Case UCase(trans("������ �� ������"))
                obj.props.PrintObject = value
            Case UCase(trans("�������� �� ������"))
                obj.props.PrintDocument = value
            Case UCase(trans("������� �� ������"))
                obj.props.PrintTable = value
            Case UCase(trans("������� � ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.TableOnCenter = value
            Case UCase(trans("������� �� ������"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("�������") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.PrintPicture = value
            Case UCase(trans("�������� �������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.Interval = value
            Case UCase(trans("������ ����������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.IntervalCount = value
            Case UCase(trans("������ ������"))
                obj.Props.OwnerObject = value
            Case UCase(trans("���������� � ����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowInTray = value

                ' ������
            Case UCase(trans("��������"))
                obj.Props.refresh()
            Case UCase(trans("�������� �����"))
                obj.Props.Focus()
            Case UCase(trans("��������� �������"))
                obj.Props.BringToFront()
            Case UCase(trans("��������� �����"))
                obj.Props.SendToBack()
            Case UCase(trans("��������"))
                obj.Props.clear()
            Case UCase(trans("��������"))
                obj.Props.Cut()
            Case UCase(trans("����������"))
                obj.Props.Copy()
            Case UCase(trans("��������"))
                obj.Props.Paste()
            Case UCase(trans("�������� ���"))
                obj.Props.SelectAll()
            Case UCase(trans("��������"))
                obj.Props.Undo()
            Case UCase(trans("���������"))
                obj.Props.Redo()
            Case UCase(trans("�����"))
                obj.Props.GoBack()
            Case UCase(trans("������"))
                obj.Props.GoForward()
            Case UCase(trans("�����"))
                obj.Props.GoHome()
            Case UCase(trans("�������� ������"))
                obj.Props.GoSearch()
            Case UCase(trans("������"))
                obj.Props.Printing()
            Case UCase(trans("���� ���������� ��������"))
                obj.Props.ShowPageSetupDialog()
            Case UCase(trans("���� ������"))
                obj.Props.ShowPrintDialog()
            Case UCase(trans("���� ���������������� ���������"))
                obj.Props.ShowPrintPreviewDialog()
            Case UCase(trans("���� �������"))
                obj.Props.ShowPropertiesDialog()
            Case UCase(trans("���� ���������"))
                obj.Props.ShowSaveAsDialog()
            Case UCase(trans("����������"))
                obj.Props.Stop()
            Case UCase(trans("������"))
                obj.Props.Hide()
            Case UCase(trans("�������"))
                obj.Props.Close()
            Case UCase(trans("��������"))
                obj.Props.Show()
            Case UCase(trans("�������� �������"))
                obj.Props.ClearTable()
            Case UCase(trans("������� � �������� �� ������"))
                obj.Props.GoInternetLink()
            Case UCase(trans("���������� �� �������"))
                obj.Props.ScrollToCaret()
            Case UCase(trans("��������� ����"))
                obj.Props.ShowDialog()
            Case UCase(trans("��������� ��������������� ��������"))
                obj.Props.ShowPrevDialog()
            Case UCase(trans("��������� ��������� ��������"))
                obj.Props.ShowPageDialog()
            Case UCase(trans("��������� ���� ������"))
                obj.Props.ShowPrinDialog()
            Case UCase(trans("����������"))
                obj.Props.Print()
            Case UCase(trans("�����"))
                obj.Props.Start()
            Case UCase(trans("����"))
                obj.Props.Stop()
            Case UCase(trans("�������� � ����"))
                obj.Props.MinimizeToTray()
            Case UCase(trans("���������� �� ����"))
                obj.Props.MaximizeFromTray()

                ' PATH and FILES
            Case MyZnak & UCase(trans("�������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Hider(args) = value
            Case MyZnak & UCase(trans("������ ��� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.FileReadOnly(args) = value
            Case MyZnak & UCase(trans("��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.archive(args) = value
            Case MyZnak & UCase(trans("�����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Papka(args) = value
            Case MyZnak & UCase(trans("�������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Encrypted(args) = value
            Case MyZnak & UCase(trans("�� �������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.NotIndexer(args) = value
            Case MyZnak & UCase(trans("���������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Sys(args) = value
            Case MyZnak & UCase(trans("���������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Temp(args) = value
            Case MyZnak & UCase(trans("����� ��������"))
                Dim dat As Date = FromMyDate(value)
                If dat = Nothing Then es.err = Errors.notDate(value) : Return es
                obj.Props.CreateTime(args) = dat
            Case MyZnak & UCase(trans("����� �������"))
                Dim dat As Date = FromMyDate(value)
                If dat = Nothing Then es.err = Errors.notDate(value) : Return es
                obj.Props.AccessTime(args) = dat
            Case MyZnak & UCase(trans("����� ���������"))
                Dim dat As Date = FromMyDate(value)
                If dat = Nothing Then es.err = Errors.notDate(value) : Return es
                obj.Props.EditTime(args) = dat
            Case MyZnak & UCase(trans("��������� � �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                args(2) = NikakoiEsli(args(2))
                obj.props.SaveInFile(args)
            Case MyZnak & UCase(trans("�������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                args(2) = NikakoiEsli(args(2))
                obj.props.AppendText(args)
            Case MyZnak & UCase(trans("��������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Or NikakoiEsli(args(1)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                es = FileExistInArgs(args, 1, es)
                If es.err <> "" Then Return es
                obj.props.SavePicture(args)
            Case MyZnak & UCase(trans("����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Or NikakoiEsli(args(1)) = trans("�������") Then Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If (args(1)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(1)) : Return es
                End If
                obj.props.Copy(args)
            Case MyZnak & UCase(trans("�������������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Or NikakoiEsli(args(1)) = trans("�������") Then Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If (args(1)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(1)) : Return es
                End If
                obj.props.Rename(args)
            Case MyZnak & UCase(trans("�����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Or NikakoiEsli(args(1)) = trans("�������") Then Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If (args(1)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(1)) : Return es
                End If
                obj.props.Move(args)
            Case MyZnak & UCase(trans("�����������"))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.props.Encrypt(args)
            Case MyZnak & UCase(trans("������������"))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.props.Decrypt(args)
            Case MyZnak & UCase(trans("�������"))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.props.Delete(args)
            Case MyZnak & UCase(trans("������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("�������") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.CreateDirectory(args)

                ' EKRAN
            Case MyZnak & UCase(trans("������� �������� �����"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("�������") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                End If
                obj.props.WallPaper = value
            Case MyZnak & UCase(trans("����� �������� �����"))
                obj.props.DesktopStyle = value
            Case MyZnak & UCase(trans("���������� ������"))
                If value.IndexOf("x") < 0 Then
                    es.err = Errors.notCollection(trans("���������� ������"), value, HWDeskResolution) : Return es
                End If
                If isInteger(value.Split("x")(0)) = False Or isInteger(value.Split("x")(1)) = False Or value.Split("x")(0) = "" Or value.Split("x")(1) = "" Then
                    es.err = Errors.notCollection(trans("���������� ������"), value, HWDeskResolution) : Return es
                End If
                obj.props.DesktopResolution = value
            Case MyZnak & UCase(trans("�������� �������������"))
                If value = "" Or isInteger(value) = False Then
                    Dim strs() As String = {"8", "16", "32"}
                    es.err = Errors.notCollection(trans("�������� �������������"), value, strs) : Return es
                End If
                obj.props.DesktopBits = value
            Case MyZnak & UCase(trans("������� ������"))
                If value = "" Or isInteger(value) = False Then
                    es.err = Errors.notInt(value, trans("������� ������")) : Return es
                End If
                obj.props.DesktopFrequency = value
            Case MyZnak & UCase(trans("��������"))
                If NikakoiEsli(value) = trans("�������") Then value = trans("�������")
                If (value).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(value) : Return es
                End If
                obj.props.ScreenSaver = value
            Case MyZnak & UCase(trans("������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NetTakNet(args(0)) = trans("�������") Then es.err = Errors.notDaOrNet(args(0)) : Return es
                args(0) = NetTakNet(args(0))
                obj.Props.ScreenshotToClipboard(args)
            Case MyZnak & UCase(trans("������� �������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ScreenshotOfObjectToClipboard(args)


                ' MEDIA
            Case UCase(trans("���� ������������"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("�������") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.FileNamePlayed = value
            Case UCase(trans("�������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Played = value
            Case UCase(trans("���������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                If Int(value) > 2000 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.Volume = value
            Case UCase(trans("������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                If Int(value) > 2000 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.Balance = value
            Case UCase(trans("���� ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Mute = value
            Case UCase(trans("��������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                If Int(value) > 2000 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.Speed = value
            Case UCase(trans("������� ������������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.PlayPosition = value
            Case UCase(trans("����������� �������"))
                Dim ts As TimeSpan = FromMyTimeSpan(value)
                If ts = TimeSpan.MaxValue Then es.err = Errors.notTime(value) : Return es
                obj.Props.PlayTime = value
            Case UCase(trans("����"))
                obj.Props.PlayMovie()
            Case UCase(trans("������� ���������"))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.OpenMovie(args)
            Case UCase(trans("������� ����"))
                obj.Props.CloseMovie()
            Case UCase(trans("���� �����"))
                obj.Props.StopMovie()
            Case UCase(trans("�����"))
                obj.Props.PauseMovie()

                ' SYSTEM
            Case MyZnak & UCase(trans("���� X"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MouseX = value
            Case MyZnak & UCase(trans("���� Y"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MouseY = value
            Case MyZnak & UCase(trans("������� ����������"))
                es = UbratKovich(value)
                If es.err <> "" Then Return es
                obj.Props.KeyBoardKey = es.str
            Case MyZnak & UCase(trans("����� ����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.KeyboardAlt = value
            Case MyZnak & UCase(trans("����� ����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.KeyboardShift = value
            Case MyZnak & UCase(trans("����� �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.KeyboardControl = value
            Case MyZnak & UCase(trans("������ ���� �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MouseLeft = value
            Case MyZnak & UCase(trans("������ ���� ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MouseRight = value
            Case MyZnak & UCase(trans("��������� ��������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MouseWheel = value
            Case MyZnak & UCase(trans("������� ������ ������"))
                es = FileExistInArgs(value, es)
                If es.err <> "" Then Return es
                obj.Props.ClipboardPicture = value
            Case MyZnak & UCase(trans("����� ������ ������"))
                obj.Props.ClipboardText = value
            Case MyZnak & UCase(trans("���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.Run(args)
            Case MyZnak & UCase(trans("�������� ����� ������"))
                obj.Props.ClipboardClear()
            Case MyZnak & UCase(trans("������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                obj.Props.WheelRun(args)
            Case MyZnak & UCase(trans("��������� ���������"))
                obj.Props.ShutDown()
            Case MyZnak & UCase(trans("������������� ���������"))
                obj.Props.Restart()
            Case MyZnak & UCase(trans("������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.TypeText(args)
            Case MyZnak & UCase(trans("������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.KillProcess(args)
            Case MyZnak & UCase(trans("���� � ������"))
                obj.Props.WindowInFocus = value



                ' REGYSTRI
            Case UCase(MyZnak & trans("�������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.Key(args) = value
            Case UCase(MyZnak & trans("������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.DeleteKey(args)
            Case UCase(MyZnak & trans("������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.DeleteSubKey(args)
            Case UCase(MyZnak & trans("������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.CreateSubKey(args)
            Case UCase(MyZnak & trans("������� ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.CreateKey(args)

                ' SOOBSHENIE
            Case MyZnak & UCase(trans("��������� ���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 4 Then es.err = Errors.noArguments(prop) : Return es
                args(1) = NikakoiEsli(args(1))
                Dim ind As Integer = MsgStyleButtons.IndexOfKey(LCase(args(1)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(1), HWMsgStyleButtons) : Return es
                args(2) = NikakoiEsli(args(2))
                ind = MsgStyleTypes.IndexOfKey(LCase(args(2)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(2), HWMsgStyleTypes) : Return es
                obj.Props.ShowMessage(args)

                ' DATE
            Case MyZnak & UCase(trans("�������� ����� ����������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SetSystemData(args)

                ' RASSHIR
            Case MyZnak & UCase(trans("��������� ��� VBScript"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.runVBScript(args)
            Case MyZnak & UCase(trans("��������� ��� ���������2"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.runAlgoritm2(args)
            Case MyZnak & UCase(trans("��������� ��� VBNet"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.runVBNet(args)
            Case MyZnak & UCase(trans("��������� ��� CSharp"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.runCSharp(args)

                ' PRERIVANIYA
            Case UCase(MyZnak & trans("��������� ���������")) : Return obj.Props.BreakApplication
            Case UCase(MyZnak & trans("��������� �������")) : Return obj.Props.BreakEvent
            Case UCase(MyZnak & trans("��������� ����")) : Return obj.Props.BreakLoop
            Case UCase(MyZnak & trans("��������� �������")) : Return obj.Props.StopIf
            Case UCase(MyZnak & trans("���������� ������")) : Return obj.Props.IgnoreErrors

                ' ���������
            Case UCase(trans("������ ����"))
                value = NikakoiEsli(value)
                Dim ind As Integer = DateFormats.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWDateFormats) : Return es
                obj.Props.CalendarDateFormat = value
            Case UCase(trans("������ ���� �� ������"))
                obj.Props.CustomDateFormat = value
            Case UCase(trans("������ ����� ����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowUpDown = value
            Case UCase(trans("��������� ����"))
                obj.Props.SelectedDate = value

                ' �������
            Case UCase(trans("����� �������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.LargeChange = value
            Case UCase(trans("����� �����"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.SmallChange = value
            Case UCase(trans("��������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Maximum = value
            Case UCase(trans("�������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Minimum = value
            Case UCase(trans("����� �������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TickStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTickStyles) : Return es
                obj.Props.TickStyle = value
            Case UCase(trans("������� �������"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.TickFrequency = value



                ' �����
            Case UCase(trans("����� ������"))
                obj.Props.TextButton = value
            Case UCase(trans("����� ����"))
                obj.Props.TextField = value
            Case UCase(trans("��������� �������� ���������"))
                obj.Props.MessageValid = value
            Case UCase(trans("��������� ��������� ���������"))
                obj.Props.MessageInValid = value
            Case UCase(trans("ID ������������"))
                obj.Props.IdUser = value
            Case UCase(trans("ID ���������"))
                obj.Props.IdProgram = value
            Case UCase(trans("ID � �������"))
                obj.Props.IdRegistryProgram = value
            Case UCase(trans("���� ����������"))
                obj.Props.KeyEncryption = value
            Case UCase(trans("���� ������ �����"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.DaysAll = value
            Case UCase(trans("������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Activation() = value
            Case UCase(trans("��������� ������ �������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.TrialStarted() = value
            Case UCase(trans("���� ��������� ������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.KeyIssue(args)
            Case UCase(trans("���� ��������� ���������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.KeyValidation(args)
            Case UCase(trans("��������� ������ ���������"))
                obj.Props.TrialStart()
            Case UCase(trans("��������� ��������"))
                obj.Props.ActivationCancel()


                ' ClientServer
            Case UCase(trans("���� ������������")) : obj.Props.FileIsSent() = value
            Case UCase(trans("������ �������� ������")) : obj.Props.HideSendingFiles() = value
            Case UCase(trans("������ �������� ������")) : obj.Props.HideSendingText() = value
            Case UCase(trans("������ ������")) : obj.Props.HideComboBox() = value
            Case UCase(trans("����������� ������")) : obj.Props.CommandSymbol() = value
            Case UCase(trans("�������� �������")) : obj.Props.ReceivedCommand() = value
            Case UCase(trans("�������� �����")) : obj.Props.ReceivedText() = value
            Case UCase(trans("�������� ����")) : obj.Props.ReceivedFile() = value
            Case UCase(trans("������������ �������")) : obj.Props.SentCommand() = value
            Case UCase(trans("����������� �����")) : obj.Props.SentText() = value
            Case UCase(trans("����������� ����")) : obj.Props.SentFile() = value
            Case UCase(trans("��� � ����"))
                Try
                    obj.Props.NameInNetwork() = value
                Catch ex As Exception
                    es.err = ex.Message : Return es
                End Try
            Case UCase(trans("IP ��� ����������")) : obj.Props.RemoteHost() = value
            Case UCase(trans("���� ��� ����������")) : obj.Props.RemotePort() = value
            Case UCase(trans("����� ��� ��������")) : obj.Props.PathForDownloads() = value
            Case UCase(trans("��� ������ �������")) : obj.Props.ClientServerType() = value
            Case UCase(trans("����� ��������")) : obj.Props.ClientsNames() = value
            Case UCase(trans("����� ���� �����")) : obj.Props.TextBoxString() = value
            Case UCase(trans("����� ���� ����")) : obj.Props.TextBoxLog() = value
            Case UCase(trans("Ip ��������")) : obj.Props.ClientsIPs() = value
            Case UCase(trans("Ip �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.GetClientIp(args)
                ' ������ ClientServer
            Case UCase(trans("��������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendToServer(args)
            Case UCase(trans("��������� ���� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendFileToServer(args)
            Case UCase(trans("��������� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendToClients(args)
            Case UCase(trans("��������� �������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendToClientsBut(args)
            Case UCase(trans("��������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendToClient(args)
            Case UCase(trans("��������� ���� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendFileToClients(args)
            Case UCase(trans("��������� ���� �������� �����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendFileToClientsBut(args)
            Case UCase(trans("��������� ���� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendFileToClient(args)
            Case UCase(trans("�������� � ���"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.Log(args)
            Case UCase(trans("��������� �������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.RunCommand(args)
            Case UCase(trans("����������� � ��������")) : obj.Props.ConnectToServer()
            Case UCase(trans("������� ������")) : obj.Props.CreateServer()
            Case UCase(trans("������ ���������")) : obj.Props.BeginListen()
            Case UCase(trans("��������� ������")) : obj.Props.CloseServer()
            Case UCase(trans("��������� ���������")) : obj.Props.CloseListener()
            Case UCase(trans("�����������")) : obj.Props.CloseClient()

                ' Internet
            Case UCase(trans("���������� ����������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.KeepAlive = value
            Case UCase(trans("������������� ����������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowAutoRedirect = value
            Case UCase(trans("����������� ����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FileDownloading = value
            Case UCase(trans("������ �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.DownloadPause = value
            Case UCase(trans("������ �������")) : obj.Props.UrlToGo = value
            Case UCase(trans("������ ������ ������")) : obj.Props.UrlReferer = value
            Case UCase(trans("������ ���������������")) : obj.Props.UrlRedirect = value
            Case UCase(trans("��� ��������")) : obj.Props.UserAgent = value
            Case UCase(trans("���������")) : obj.Props.Accept = value
            Case UCase(trans("������ IP")) : obj.Props.ProxyIp = value
            Case UCase(trans("������ ����"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.ProxyPort = value
            Case UCase(trans("��������� ��������")) : obj.Props.EncodingPage = value
            Case UCase(trans("���� ��������")) : obj.Props.LanguagePage = value
            Case UCase(trans("���������� �������")) : obj.Props.ContentQuery = value
            Case UCase(trans("��� �����������")) : obj.Props.ContentType = value
            Case UCase(trans("����� �������")) : obj.Props.HttpMethod = value
            Case UCase(trans("�������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.TimeOut = value
            Case UCase(trans("����� ��������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.TimeDelay = value
            Case UCase(trans("������ ������"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.BufferSize = value
            Case UCase(trans("���� ��������")) : obj.Props.CookiesQueries = value
            Case UCase(trans("��������� �������")) : obj.Props.ResultQuery = value
                ' ������ ��������� 
            Case UCase(trans("�������� ��� ��������"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.GetSourceCodePage(args)
            Case UCase(trans("������� ����"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NetTakNet(args(1)) = trans("�������") Then es.err = Errors.notDaOrNet(args(1)) : Return es
                args(1) = NetTakNet(args(1))
                obj.Props.DownloadFile(args)
            Case UCase(trans("��������� ������")) : obj.Props.ExecuteQuery()
            Case UCase(trans("�������� ����")) : obj.Props.ClearCookie()
            Case UCase(trans("������ ��������")) : obj.Props.DownloadCancel()
            Case UCase(trans("������ �����������")) : obj.Props.DownloadResume()

            Case UCase(trans("����� ��������"))
                value = NikakoiEsli(value)
                Dim ind As Integer = StylesProgress.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWStylesProgress) : Return es
                obj.Props.StyleProgress = value
            Case UCase(trans("�������� ��������")) : obj.Props.MarqueeAnimationSpeed = value
            Case UCase(trans("��� ��������")) : obj.Props.StepProgress = value
            Case UCase(trans("������ ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.RightToLeftLayout = value
            Case MyZnak & UCase(trans("������� �����"))
                obj.Props.OpenDirectory(args)
            Case UCase(trans("������ ������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.RightToLeftLayout = value
            Case UCase(trans("��������� ��������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ForbidMinimize = value
            Case UCase(trans("��������� �������������"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ForbidMaximize = value
            Case UCase(trans("������������� � ������������"))
                obj.Props.AssociateWithExtensions = value
            Case UCase(trans("�������������� �������� ����"))
                obj.Props.AssociationPassedFile = value
            Case UCase(trans("�� ���� �����"))
                If NetTakNet(value) = trans("�������") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.OnFullScreen = value




            Case Else

                ' ����� ��� ����� ��������� ������� "������� �������"
                If Iz.IsSobytCalls(MyObj) And prop.Split("_").Length = 3 Then
                    MyObj.CreateSobytCalls()
                    Dim frm As String = prop.Split("_")(0)
                    Dim obc As String = prop.Split("_")(1)
                    Dim sob As String = prop.Split("_")(2)
                    Dim obcO As Object = RunProj.GetMyAllFromName(obc, , frm)
                    If obcO Is Nothing Then es.err = Errors.ObjIsNothing(obc) : Return es
                    If RunProj.FindSobyt(sob, obcO(0).Getnode(, True)) Is Nothing Then es.err = Errors.notPropertyMethod(prop) : Return es
                    obcO(0).RunSobyt(obcO(0), sob, New EventArgs, (New EventArgs).GetType)
                    Return es
                End If

                ' � ���������� �������
                es.err = "!"
        End Select
        Return es
    End Function

    ' ������ ��� ������
    Sub SetReadOnlys()
        ' �������� ������ ������� ������ ��� ������
        Dim TempRO() As String = {UCase(trans("� ������")), UCase(trans("���")), _
            UCase(MyZnak & trans("���������� ����")), UCase(MyZnak & trans("���������� �����")), _
            UCase(MyZnak & trans("�������� �����")), UCase(MyZnak & trans("�������� �����")), _
            UCase(MyZnak & trans("���������� ��������")), UCase(MyZnak & trans("����� ������")), _
            UCase(MyZnak & trans("���������� ������������")), UCase(MyZnak & trans("�������� �����")), _
            UCase(MyZnak & trans("���������� ��� �����")), UCase(MyZnak & trans("���������� ��� �����")), _
            UCase(MyZnak & trans("���������� ����������")), UCase(MyZnak & trans("���������� ��� ����������")), _
            UCase(trans("������������ �����")), UCase(trans("������������ �����")), _
            UCase(trans("������������ ������")), UCase(trans("������������ ������")), _
            UCase(MyZnak & trans("��������� ��������")), _
            UCase(MyZnak & trans("���� ����������")), UCase(MyZnak & trans("����� ����������")), _
            UCase(MyZnak & trans("��� �����")) _
            , UCase(trans("����� ������� �� �����������")), UCase(trans("����� ������� ������� ������")) _
            , UCase(trans("����� ������� ������� ������� ������")), UCase(trans("����� ������ �� ������ �������")) _
            , UCase(trans("X �� ������ �������")), UCase(trans("Y �� ������ �������")) _
            , UCase(trans("������")), UCase(trans("���������� �����")), UCase(trans("������� offline")) _
            , UCase(trans("������")), UCase(trans("���������� ��������")), UCase(trans("������������ ����")) _
            , UCase(trans("����� ��������")), UCase(trans("������ ��������")), UCase(trans("������������ �����")) _
            , UCase(trans("��������� ��������")), UCase(trans("��� ��������")), UCase(trans("������� �����")) _
            , UCase(trans("������ ����������")), UCase(trans("��������� ������")), UCase(trans("��������� �� ���������")) _
            , UCase(trans("������ ���������")), UCase(trans("����� ���������� ��������")) _
            , UCase(trans("����� ������ ������")), UCase(trans("����� ��������� ������")) _
            , UCase(trans("����� ��������� ������")), UCase(trans("����� ���������� ������")) _
            , UCase(trans("�������� �� �����������")), UCase(trans("����� ������ �� �����������")) _
            , UCase(trans("����� ������� �� �����������")) _
            , UCase(trans("������ ������� ������")), UCase(trans("���������� �������")) _
            , UCase(trans("������ ��������� �������")), UCase(trans("���������� ������")) _
            , UCase(trans("���� ������ ������")) _
            , UCase(trans("���������� ���������� �����")), UCase(trans("���������� ���������� ��������")) _
            , UCase(trans("���� ������ ��������")), UCase(trans("ID ������������")) _
            , UCase(trans("����������")) _
            , UCase(MyZnak & trans("������ �� ������")), UCase(MyZnak & trans("�������� ������")) _
            , UCase(MyZnak & trans("����� � ������")) _
            , UCase(MyZnak & trans("����� ������ ������")), UCase(MyZnak & trans("����� � ������ ��������")) _
            , UCase(MyZnak & trans("����� � ������ � �����")), UCase(MyZnak & trans("����� � ����������� �����������")) _
            , UCase(MyZnak & trans("���������� ��������")), UCase(MyZnak & trans("������� �� �����")) _
            , UCase(MyZnak & trans("����� ����� ������")), UCase(MyZnak & trans("���������� ������ ������")) _
            , UCase(MyZnak & trans("������� ������")), UCase(MyZnak & trans("��������� ���������")) _
            , UCase(MyZnak & trans("����� ��� �������")), UCase(MyZnak & trans("������� �� ����� ��� �������")) _
            , UCase(MyZnak & trans("����� ��������")), UCase(MyZnak & trans("����� �� ��������")) _
            , UCase(MyZnak & trans("������ �� ������")), UCase(MyZnak & trans("���������� �����")) _
            , UCase(MyZnak & trans("�������� ������� � �����")), UCase(MyZnak & trans("������� ����� ������")) _
            , UCase(MyZnak & trans("��������")), UCase(MyZnak & trans("�������� ���")) _
            , UCase(MyZnak & trans("������� ����� ����������")), UCase(MyZnak & trans("������� ����� ����������")) _
            , UCase(MyZnak & trans("������ �������")), UCase(MyZnak & trans("������ ������� � ������")) _
            , UCase(MyZnak & trans("������ ������� � �����")) _
            , UCase(MyZnak & trans("���������� ������ ��� �������")) _
            , UCase(MyZnak & trans("���� ������ ������")), UCase(MyZnak & trans("���� ������ ��")) _
            , UCase(MyZnak & trans("���� ������ ���������")), UCase(MyZnak & trans("���� ������ ��")) _
            , UCase(MyZnak & trans("���� ������ ���")), UCase(MyZnak & trans("���� ������ ��������")) _
            , UCase(MyZnak & trans("���� ������ ����������")), UCase(MyZnak & trans("���� ������ �������")) _
            , UCase(MyZnak & trans("���� ������")), UCase(MyZnak & trans("���� ����")) _
            , UCase(MyZnak & trans("���� � ������")), UCase(MyZnak & trans("���")) _
            , UCase(MyZnak & trans("������")), UCase(MyZnak & trans("�������")) _
            , UCase(MyZnak & trans("�������")), UCase(MyZnak & trans("������ � ����")) _
            , UCase(MyZnak & trans("���")), UCase(MyZnak & trans("�����")) _
            , UCase(MyZnak & trans("������ ����� � ����")), UCase(MyZnak & trans("���� � ������")) _
            , UCase(MyZnak & trans("������")), UCase(MyZnak & trans("�������")) _
            , UCase(MyZnak & trans("��������� ���")), UCase(MyZnak & trans("��������� ����")) _
            , UCase(MyZnak & trans("��������� ������")), UCase(MyZnak & trans("��������� �������")) _
            , UCase(MyZnak & trans("��������� ��������")), UCase(MyZnak & trans("��������� ������")) _
            , UCase(MyZnak & trans("��������� ����")), UCase(MyZnak & trans("��������� ������")) _
            , UCase(MyZnak & trans("������� � ����")), UCase(MyZnak & trans("������� � �����")) _
            , UCase(MyZnak & trans("������� � �������")), UCase(MyZnak & trans("������� � ��������")) _
            , UCase(MyZnak & trans("������� � ���������")), UCase(MyZnak & trans("������� � �������")) _
            , UCase(MyZnak & trans("������� � �����")), UCase(MyZnak & trans("������� � �������")) _
            , UCase(MyZnak & trans("���� ������")), UCase(MyZnak & trans("�������� ������")) _
            , UCase(MyZnak & trans("���� � ������������ �������")), UCase(trans("����� ����� ������")) _
            , UCase(MyZnak & trans("����� ������� ��")), UCase(MyZnak & trans("����� ���� �����")) _
            , UCase(MyZnak & trans("����� ���� �����")), UCase(MyZnak & trans("���������� ������ �����")) _
            , UCase(MyZnak & trans("������� ����")), UCase(MyZnak & trans("��������� � �����������")) _
            , UCase(MyZnak & trans("����������� �����")), UCase(MyZnak & trans("������������ �����")) _
            , UCase(MyZnak & trans("���������� ������")), UCase(MyZnak & trans("���������� �����")) _
            , UCase(MyZnak & trans("��������� � �����������")) _
            , UCase(MyZnak & trans("�������� �������")), UCase(MyZnak & trans("���� �������")) _
            , UCase(MyZnak & trans("��������")), UCase(MyZnak & trans("�������� �������")) _
            , UCase(trans("������� ����������")) _
            , UCase(trans("����� ��������")), UCase(trans("Ip ��������")), UCase(trans("Ip �������")) _
            , UCase(trans("������ �����������")), UCase(trans("��� ����������")), UCase(trans("��������� �������")) _
            , UCase(trans("�������������� �������� ����")) _
            , UCase(trans("����� � �������")), UCase(trans("����� � ��������� �������")) _
        }
        ReadOnlyProps = TempRO

        ' �������� ������ ������� ������ ��� ������,������� ����������� ���������(����� ������������ ���� � ��������� �������)
        Dim TempMCP() As String = { _
            trans("����� ������� �� �����������").ToUpper, trans("����� ������� ������� ������").ToUpper _
            , trans("����� ������� ������� ������� ������").ToUpper, trans("����� ������ �� ������ �������").ToUpper _
            , trans("X �� ������ �������").ToUpper, trans("Y �� ������ �������").ToUpper _
            , trans("������").ToUpper, trans("������").ToUpper _
            , trans("������ �� ������").ToUpper, trans("����� ����� ������").ToUpper _
            , trans("���� ��������� ������").ToUpper, trans("���� ��������� ���������").ToUpper _
            , trans("Ip �������").ToUpper _
            , trans("����� � �������").ToUpper, trans("����� � ��������� �������").ToUpper _
        }
        MayChangeProps = TempMCP

        ' ���������, � ������� ���� ���, �������� �� �����
        Dim tempArgTypes() As String = {UCase(trans("����������� �� �����������")), _
            UCase(trans("������� �������")), UCase(trans("������ ���������")), UCase(trans("��� ���������")), _
            UCase(trans("��� ���� ������")), UCase(trans("����� ��� ������ � ������")), _
            UCase(trans("��������� ������")), UCase(trans("�������� � ����")), _
            UCase(trans("������ ����� ����� �������")), UCase(trans("������ �������� ����� �������")), _
            UCase(trans("��� �����")), UCase(trans("����� ���� ���������")), _
            UCase(trans("C ������ ��������")), UCase(trans("����� �������")), _
            UCase(trans("������ ������")), UCase(trans("������ �������� ����")) _
        }
        ArgTypes = tempArgTypes

        ' �������� ������ ������� �������, ������� �� ��� ������
        Dim TempSnRO() As String = {UCase(MyZnak & trans("�������� �����������")), UCase(MyZnak & trans("�������� ����")) _
            , UCase(MyZnak & trans("�������� � ����� ����")), UCase(MyZnak & trans("�������� �������"))}
        SobytsNotReadOnly = TempSnRO

        ' �������� ������ �������, ������� �� ���� ������� �� �������� � �� ���� ��������� �� ��� ���������� �������
        Dim TempNoSaveProps() As String = {UCase(trans("���������� RTF")), UCase(trans("���������� ��������� ������")) _
            , UCase(trans("���������� ������ ���")), UCase(trans("���������� ���� ������")) _
            , UCase(trans("���������� ������ ������� ������")), UCase(trans("���������� ������ �����")) _
            , UCase(trans("���������� ������ ������")), UCase(trans("���������� ����� ������")) _
            , UCase(trans("���������� ������������ ��������")), UCase(trans("���������� ����� ������")) _
            , UCase(trans("���������� �����")), UCase(trans("���������� ����� ������")), UCase(trans("���������� ����� ������")) _
            , UCase(trans("���������� ����� ������������")), UCase(trans("���������� ����� �����������")) _
            , UCase(trans("���������� ����� ������������")) _
            , UCase(trans("��������� ������ �������")), UCase(trans("������������")) _
       }
        NoSaveProps = TempNoSaveProps

    End Sub

    ' ���������� ��� ����, ��� ����� ��������
    Public Function GetTypeProperty(ByVal prop As String) As String
        prop = UCase(prop)

        If prop = UCase(trans("�����")) Or prop = UCase(trans("���")) Or prop = UCase(trans("��������������� ����")) _
        Or prop = MyZnak & UCase(trans("����� ��������")) Or prop = MyZnak & UCase(trans("����� �������")) _
        Or prop = MyZnak & UCase(trans("����� ���������")) _
        Or prop = UCase(trans("������������ �����")) Or prop = UCase(trans("����������� �������")) _
        Or prop = UCase(trans("������")) Or prop = UCase(trans("������")) _
        Or prop = UCase(trans("���������� �����")) Or prop = UCase(trans("������ ������")) _
        Or prop = MyZnak & UCase(trans("�������� �������")) Or prop = UCase(trans("����������� ���������")) _
        Or prop = UCase(trans("����� ��������")) Or prop = UCase(trans("��������� ��������")) _
        Or prop = UCase(trans("��� ��������")) Or prop = UCase(trans("����")) _
        Or prop = UCase(trans("��������� ������")) Or prop = UCase(trans("������")) Or prop = UCase(trans("��������")) _
        Or prop = UCase(trans("�������")) Or prop = UCase(trans("������")) _
        Or prop = UCase(trans("������ ���������� �����")) Or prop = UCase(trans("������ ���������� ��������")) _
        Or prop = UCase(trans("�������� ������")) Or prop = UCase(trans("�������� �� �����������")) _
        Or prop = UCase(trans("������ ������")) Or prop = UCase(trans("���������� ������")) _
        Or prop = UCase(trans("������ �� ������")) Or prop = UCase(trans("������ �������")) _
        Or prop = UCase(trans("������ ��������� �������")) Or prop = UCase(trans("���������� ������")) _
        Or prop = UCase(trans("������ ���������� �������")) Or prop = UCase(trans("���������� ������")) _
        Or prop = UCase(trans("RTF ��� ���������")) Or prop = UCase(trans("���������� RTF")) _
        Or prop = UCase(trans("������� � ����")) Or prop = UCase(trans("��������� �����")) _
        Or prop = UCase(trans("��������� ���������� �����")) Or prop = UCase(trans("��� �����")) _
        Or prop = UCase(trans("������ ������")) Or prop = UCase(trans("���������� RTF")) _
        Or prop = UCase(trans("��������� �����")) Or prop = UCase(trans("���������")) _
        Or prop = UCase(trans("����� �� ������")) _
        Or prop = UCase(trans("������������ ����")) Or prop = UCase(trans("������������ �����")) _
        Or prop = MyZnak & UCase(trans("������ �� ������")) Or prop = MyZnak & UCase(trans("������� �� �����")) _
        Or prop = MyZnak & UCase(trans("����� ����� ������")) Or prop = MyZnak & UCase(trans("������� ������")) _
        Or prop = MyZnak & UCase(trans("��������� ���������")) Or prop = MyZnak & UCase(trans("������� �� ����� ��� �������")) _
        Or prop = MyZnak & UCase(trans("������ �� ������")) Or prop = MyZnak & UCase(trans("�������� ������� � �����")) _
        Or prop = MyZnak & UCase(trans("������� ����� ������")) Or prop = MyZnak & UCase(trans("��������")) _
        Or prop = MyZnak & UCase(trans("�������� ���")) Or prop = MyZnak & UCase(trans("������� ����� ����������")) _
        Or prop = MyZnak & UCase(trans("������� ����� ����������")) Or prop = MyZnak & UCase(trans("������ �������")) _
        Or prop = MyZnak & UCase(trans("������ ������� � ������")) Or prop = MyZnak & UCase(trans("������ ������� � �����")) _
        Or prop = MyZnak & UCase(trans("�������� �������")) Or prop = MyZnak & UCase(trans("���� �������")) _
        Or prop = MyZnak & UCase(trans("���� � ������")) _
        Or prop = UCase(trans("���")) Or prop = UCase(trans("���������")) _
        Or prop = UCase(trans("��������� ����")) Or prop = UCase(trans("������ ���� �� ������")) _
        Or prop = MyZnak & UCase(trans("�����")) _
        Or prop = UCase(trans("����� ������")) Or prop = UCase(trans("��������� �������� ���������")) _
        Or prop = UCase(trans("��������� ��������� ���������")) Or prop = UCase(trans("ID ������������")) _
        Or prop = UCase(trans("ID ���������")) Or prop = UCase(trans("ID � �������")) _
        Or prop = UCase(trans("���� ����������")) Or prop = UCase(trans("KeyEncryption")) _
        Or prop = UCase(trans("����������")) Or prop = UCase(trans("����� ����")) _
        Or prop = UCase(trans("����������� ������")) Or prop = UCase(trans("�������� �������")) _
        Or prop = UCase(trans("�������� �����")) Or prop = UCase(trans("IP ��� ����������")) _
        Or prop = UCase(trans("��� � ����")) Or prop = UCase(trans("�������� ����")) _
        Or prop = UCase(trans("���� ��� ����������")) Or prop = UCase(trans("����� ��� ��������")) _
        Or prop = UCase(trans("����� ��������")) Or prop = UCase(trans("����� ���� �����")) _
        Or prop = UCase(trans("����� ���� ����")) Or prop = UCase(trans("Ip ��������")) _
        Or prop = UCase(trans("Ip �������")) _
        Or prop = UCase(trans("������������ �������")) Or prop = UCase(trans("����������� ����")) _
        Or prop = UCase(trans("����������� �����")) _
        Or prop = UCase(trans("������ �������")) Or prop = UCase(trans("������ ������ ������")) _
        Or prop = UCase(trans("������ ���������������")) Or prop = UCase(trans("��� ��������")) _
        Or prop = UCase(trans("���������")) Or prop = UCase(trans("������ IP")) _
        Or prop = UCase(trans("������ ����")) Or prop = UCase(trans("��������� ��������")) _
        Or prop = UCase(trans("���� ��������")) Or prop = UCase(trans("���������� �������")) _
        Or prop = UCase(trans("���� ��������")) Or prop = UCase(trans("��������� �������")) _
        Or prop = UCase(trans("�������������� �������� ����")) _
        Or prop = UCase(trans("�������� ��������� �����")) Or prop = UCase(trans("����� � �������")) _
        Or prop = UCase(trans("����� � ���������")) Or prop = UCase(trans("������ ��������")) _
         Or prop = UCase(trans("������ �����")) _
      Then
            Return trans("�����")



        ElseIf prop = UCase(trans("������� �����")) Or prop = UCase(trans("��������� ��������")) _
        Or prop = UCase(trans("�������������")) Or prop = UCase(trans("��������")) Or prop = UCase(trans("�������")) _
       Or prop = UCase(trans("����� ������")) Or prop = UCase(trans("����� ������")) _
       Or prop = UCase(trans("����� �����������")) Or prop = UCase(trans("����� ������������")) _
       Or prop = UCase(trans("���������1")) Or prop = UCase(trans("���������")) Or prop = UCase(trans("���������2")) _
       Or prop = UCase(trans("������������� �����������")) Or prop = UCase(trans("������1 ������")) _
       Or prop = UCase(trans("������2 ������")) Or prop = UCase(trans("� ������")) Or prop = UCase(trans("�������")) _
       Or prop = UCase(trans("�������� ���������")) Or prop = UCase(trans("���������������")) _
       Or prop = UCase(trans("������ ��� ������")) Or prop = UCase(trans("������� �� ������")) _
       Or prop = MyZnak & UCase(trans("�������� �����������")) Or prop = MyZnak & UCase(trans("�������� � ����� ����")) _
       Or prop = MyZnak & UCase(trans("�������� �������")) Or prop = MyZnak & UCase(trans("�������� ����")) _
       Or prop = MyZnak & UCase(trans("������ ��� ������")) Or prop = MyZnak & UCase(trans("�������")) _
       Or prop = MyZnak & UCase(trans("��������")) Or prop = MyZnak & UCase(trans("�����")) _
       Or prop = MyZnak & UCase(trans("�������������")) Or prop = MyZnak & UCase(trans("�� �������������")) _
       Or prop = MyZnak & UCase(trans("���������")) Or prop = MyZnak & UCase(trans("���������")) _
       Or prop = MyZnak & UCase(trans("���������� ����")) Or prop = UCase(trans("�������������")) _
       Or prop = UCase(trans("���� ��������")) Or prop = UCase(trans("��������")) _
       Or prop = MyZnak & UCase(trans("����� ����")) Or prop = MyZnak & UCase(trans("����� ����")) _
       Or prop = MyZnak & UCase(trans("����� �������")) Or prop = MyZnak & UCase(trans("������ ���� �����")) _
       Or prop = MyZnak & UCase(trans("������ ���� ������")) Or prop = UCase(trans("��������� ��������")) _
       Or prop = MyZnak & UCase(trans("���� ����������")) Or prop = UCase(trans("����� ����������")) _
       Or prop = UCase(trans("���������� �����")) Or prop = UCase(trans("���������� ���������")) _
       Or prop = UCase(trans("������� �� �����")) Or prop = UCase(trans("������� ��������")) _
       Or prop = UCase(trans("���������� ������� �������")) _
       Or prop = UCase(trans("���������� �� ��������")) Or prop = UCase(trans("��������� ��������������")) _
       Or prop = UCase(trans("����� ��������")) Or prop = UCase(trans("������ ��������")) _
       Or prop = UCase(trans("������� �����")) Or prop = UCase(trans("������� offline")) _
       Or prop = UCase(trans("����������� ���� ��������")) Or prop = UCase(trans("���������� ������ ���������")) _
       Or prop = UCase(trans("������ ��������� �������")) Or prop = UCase(trans("������� ������� ��������")) _
       Or prop = UCase(trans("������� ������ � ����")) Or prop = UCase(trans("���������� ������")) _
       Or prop = UCase(trans("���������� � ������ �����")) Or prop = UCase(trans("������ ���� ����")) _
       Or prop = UCase(trans("��������� ��������� ������")) Or prop = UCase(trans("��������� ������� ������")) _
       Or prop = UCase(trans("��������� ������������ �������")) Or prop = UCase(trans("��������� ����������� �������")) _
       Or prop = UCase(trans("��������� ����������� ������")) Or prop = UCase(trans("���������� ��������� ��������")) _
       Or prop = UCase(trans("����� ���������� �����")) Or prop = UCase(trans("������ ��� ������ �������")) _
       Or prop = UCase(trans("������ ��������")) Or prop = UCase(trans("������ ������ ��� ������")) _
       Or prop = UCase(trans("������� ������ ��� ������")) Or prop = UCase(trans("������ ������ ��� ������")) _
       Or prop = UCase(trans("����������� �� �����������")) _
       Or prop = UCase(trans("����� ���������� �������")) _
       Or prop = UCase(trans("������ ����������")) Or prop = UCase(trans("���������� ������")) _
       Or prop = UCase(trans("������ �������")) Or prop = UCase(trans("��������� �������� ������")) _
       Or prop = UCase(trans("�������������� ���������")) Or prop = UCase(trans("���������������")) _
       Or prop = UCase(trans("������ ��������")) Or prop = UCase(trans("������ �������")) _
       Or prop = UCase(trans("���������� � �������� �� ������")) _
       Or prop = UCase(trans("������������ ������")) Or prop = UCase(trans("��������� ������� �����������")) _
       Or prop = UCase(trans("���������� ����� ������")) Or prop = UCase(trans("���������� ����� ������")) _
       Or prop = UCase(trans("���������� ����� ������")) Or prop = UCase(trans("���������� ����� ������������")) _
       Or prop = UCase(trans("���������� ����� �����������")) Or prop = UCase(trans("���������� ����� ������������")) _
       Or prop = UCase(trans("���� ������ ������")) _
       Or prop = UCase(trans("��������� �������� ����")) Or prop = UCase(trans("��������� �������� �������������")) _
       Or prop = UCase(trans("��������� ������� �����")) Or prop = UCase(trans("��������� ������� �����")) _
       Or prop = UCase(trans("����� ���������� ������")) Or prop = UCase(trans("������� � ������")) _
       Or prop = UCase(trans("���������� ����������� �������")) Or prop = UCase(trans("������ ����� ����")) _
       Or prop = MyZnak & UCase(trans("�������� ������")) Or prop = MyZnak & UCase(trans("����� ��������")) _
       Or prop = MyZnak & UCase(trans("����� �� ��������")) _
       Or prop = MyZnak & UCase(trans("���� ������ ������")) Or prop = MyZnak & UCase(trans("���� ������ ��")) _
       Or prop = MyZnak & UCase(trans("���� ������ ���������")) Or prop = MyZnak & UCase(trans("���� ������ ��")) _
       Or prop = MyZnak & UCase(trans("���� ������ ���")) Or prop = MyZnak & UCase(trans("���� ������ ��������")) _
       Or prop = MyZnak & UCase(trans("���� ������ ����������")) Or prop = MyZnak & UCase(trans("���� ������ �������")) _
       Or prop = MyZnak & UCase(trans("����� ������� ��")) Or prop = MyZnak & UCase(trans("����� ���� �����")) _
       Or prop = MyZnak & UCase(trans("����� ���� �����")) Or prop = UCase(trans("������������")) _
       Or prop = UCase(trans("�������� � ����")) Or prop = UCase(trans("��������� ������ �������")) _
       Or prop = UCase(trans("���������� � ����")) _
       Or prop = UCase(trans("�������� � ������������")) Or prop = UCase(trans("��������� ������ �����")) _
       Or prop = UCase(trans("���� ������������")) _
       Or prop = UCase(trans("������ �������� ������")) Or prop = UCase(trans("������ �������� ������")) _
       Or prop = UCase(trans("������ ������")) Or prop = UCase(trans("������ �������� ������")) _
       Or prop = UCase(trans("���������� ����������")) Or prop = UCase(trans("������������� ����������������")) _
       Or prop = UCase(trans("����������� ����")) Or prop = UCase(trans("������ �����")) _
       Or prop = UCase(trans("����� ���� ���������")) Or prop = UCase(trans("������ ������")) _
       Or prop = UCase(trans("��������� ��������������")) Or prop = UCase(trans("��������� �������������")) _
       Or prop = UCase(trans("C ������ ��������")) Or prop = UCase(trans("����� �������")) _
        Or prop = UCase(trans("������ �������� ����")) Or prop = UCase(trans("�� ���� �����")) _
      Then
            Return trans("�����")

        ElseIf prop = UCase(trans("������� �������")) Or prop = UCase(trans("������� �������1")) _
                              Or prop = UCase(trans("������� �������2")) Or prop = UCase(trans("�������")) _
                              Or prop = MyZnak & UCase(trans("������� �������� �����")) _
                              Or prop = MyZnak & UCase(trans("������� ������ ������")) Or prop = UCase(trans("������")) _
                              Or prop = UCase(trans("������� �� ������")) _
                              Then
            Return trans("�������")

        ElseIf prop = UCase(trans("���� ������������")) Or prop = MyZnak & UCase(trans("��������")) _
               Then
            Return trans("����")

        ElseIf prop = UCase(trans("����")) Or prop = UCase(trans("����1")) Or prop = UCase(trans("����2")) _
        Or prop = UCase(trans("���� ������")) Or prop = UCase(trans("���������� ���� �������")) _
        Or prop = UCase(trans("���������� ����")) Or prop = UCase(trans("���� �����")) _
        Or prop = UCase(trans("���� ���� �����")) Or prop = UCase(trans("���� ���� ���������� �����")) _
        Or prop = UCase(trans("���� ������ �����")) Or prop = UCase(trans("���� ������ ���������� �����")) _
        Or prop = UCase(trans("���� �������� ������")) Or prop = UCase(trans("���� ��������� ������")) _
        Or prop = UCase(trans("���� ������")) Or prop = UCase(trans("���� ���������� ������")) _
        Or prop = UCase(trans("���������� ������ ���")) Or prop = UCase(trans("���������� ���� ������")) _
        Or prop = UCase(trans("��������� ����")) _
        Then
            Return trans("����")

        ElseIf prop = UCase(trans("X")) Or prop = UCase(trans("Y")) Or prop = UCase(trans("�����")) _
        Or prop = UCase(trans("������������ ������")) Or prop = UCase(trans("������������ ������")) _
        Or prop = UCase(trans("����������� ������")) Or prop = UCase(trans("����������� ������")) _
        Or prop = UCase(trans("���� �����")) Or prop = UCase(trans("���� ������")) _
        Or prop = UCase(trans("���� ������")) Or prop = UCase(trans("���� �����")) _
        Or prop = UCase(trans("������ �����������")) Or prop = UCase(trans("���������� �����������")) _
        Or prop = UCase(trans("��������� �����������")) Or prop = UCase(trans("������1 �������")) _
        Or prop = UCase(trans("������2 �������")) _
        Or prop = UCase(trans("������")) Or prop = UCase(trans("������")) Or prop = UCase(trans("��������")) _
        Or prop = MyZnak & UCase(trans("������� ������")) Or prop = MyZnak & UCase(trans("�������� �������������")) _
        Or prop = UCase(trans("���������")) Or prop = UCase(trans("������")) Or prop = UCase(trans("��������")) _
        Or prop = UCase(trans("������������ �����")) Or prop = UCase(trans("������� ������������")) _
        Or prop = UCase(trans("������������ ������")) Or prop = UCase(trans("������������ ������")) _
        Or prop = UCase(trans("������������ ������")) Or prop = UCase(trans("������ ���������")) _
        Or prop = UCase(trans("����� ������� �� �����������")) Or prop = UCase(trans("����� ������� ������� ������")) _
        Or prop = UCase(trans("����� ������� ������� ������� ������")) _
        Or prop = UCase(trans("����� ������ �� ������ �������")) Or prop = UCase(trans("������ ���������")) _
        Or prop = UCase(trans("X �� ������ �������")) Or prop = UCase(trans("Y �� ������ �������")) _
        Or prop = UCase(trans("���������� �����")) Or prop = UCase(trans("���������� ��������")) _
        Or prop = UCase(trans("������������ ������")) Or prop = UCase(trans("������������ ������")) _
        Or prop = UCase(trans("������������ ������")) Or prop = UCase(trans("������������ ������")) _
        Or prop = MyZnak & UCase(trans("���� X")) Or prop = MyZnak & UCase(trans("���� Y")) _
        Or prop = UCase(trans("��������� ����������� ������")) Or prop = UCase(trans("��������� ����������� ������")) _
        Or prop = UCase(trans("���������� �� X")) Or prop = UCase(trans("���������� �� Y")) _
        Or prop = UCase(trans("������ ���������")) Or prop = UCase(trans("������������")) _
        Or prop = UCase(trans("����� ���������� ��������")) Or prop = UCase(trans("������� ���������� ��������")) _
        Or prop = UCase(trans("���� �� �����������")) Or prop = UCase(trans("���� �� ���������")) _
        Or prop = UCase(trans("������ ���������� ��������")) Or prop = UCase(trans("������ �������")) _
        Or prop = UCase(trans("����� ������ ������")) Or prop = UCase(trans("����� ��������� ������")) _
        Or prop = UCase(trans("����� ��������� ������")) Or prop = UCase(trans("����� ���������� ������")) _
        Or prop = UCase(trans("����� ������ �� �����������")) Or prop = UCase(trans("����� ������� �� �����������")) _
        Or prop = UCase(trans("���������� ����� �������")) Or prop = UCase(trans("���������� ��������")) _
        Or prop = UCase(trans("������ ��������������� ������")) Or prop = UCase(trans("������ ��������������� ������")) _
        Or prop = UCase(trans("������ ������� ������")) Or prop = UCase(trans("���������� �������������� �������")) _
        Or prop = UCase(trans("����� ���������� ������")) Or prop = UCase(trans("����� ����� ������")) _
        Or prop = UCase(trans("���������� �������")) Or prop = UCase(trans("������ ������� ������")) _
        Or prop = UCase(trans("������ ������")) Or prop = UCase(trans("������ ������")) _
        Or prop = UCase(trans("�������")) Or prop = UCase(trans("���������� ������ ������� ������")) _
        Or prop = UCase(trans("���������� ������ �����")) Or prop = UCase(trans("���������� ������ ������")) _
        Or prop = UCase(trans("���������� ������������ ��������")) Or prop = UCase(trans("����� �������")) _
        Or prop = UCase(trans("����� ������")) Or prop = UCase(trans("���������� ����� ������")) _
        Or prop = UCase(trans("�������� �������")) Or prop = UCase(trans("������ ����������")) _
        Or prop = MyZnak & UCase(trans("����� � ������")) Or prop = MyZnak & UCase(trans("����� � ������ ��������")) _
        Or prop = MyZnak & UCase(trans("����� � ������ � �����")) Or prop = MyZnak & UCase(trans("����� � ����������� �����������")) _
        Or prop = MyZnak & UCase(trans("���������� ��������")) Or prop = MyZnak & UCase(trans("���������� ������ ������")) _
        Or prop = MyZnak & UCase(trans("����� ��� �������")) Or prop = MyZnak & UCase(trans("���������� �����")) _
        Or prop = MyZnak & UCase(trans("���������� ������ ��� �������")) _
        Or prop = UCase(trans("����� �������")) Or prop = UCase(trans("����� �����")) _
        Or prop = UCase(trans("��������")) Or prop = UCase(trans("�������")) Or prop = UCase(trans("������� �������")) _
        Or prop = UCase(trans("���������� ���������� �����")) Or prop = UCase(trans("���������� ���������� ��������")) _
        Or prop = UCase(trans("���� ������ �����")) Or prop = UCase(trans("���� ������ ��������")) _
        Or prop = UCase(trans("�������")) Or prop = UCase(trans("����� ��������")) _
        Or prop = UCase(trans("������ ������")) _
        Or prop = UCase(trans("�������� ��������")) Or prop = UCase(trans("��� ��������")) _
        Or prop = UCase(trans("�������� ������ ������")) Or prop = UCase(trans("�������� ����� ������")) _
        Or prop = UCase(trans("����� �����")) _
               Or prop = UCase(trans("������ ������")) _
  Then
            Return trans("�����")

        ElseIf prop = UCase(trans("��������� ������")) Or prop = UCase(trans("��������� �������")) Then
            Return trans("���������")

        ElseIf prop = UCase(trans("����������� ����")) Or prop = UCase(trans("����������� ����1")) _
        Or prop = UCase(trans("����������� ����2")) Or prop = UCase(trans("��������� ����������� ����")) Then
            Return trans("����������� ����")

        ElseIf prop = MyZnak & UCase(trans("��� �����")) Then
            Return trans("��� �����")

        ElseIf prop = UCase(trans("������������ ������")) Or prop = UCase(trans("���������� ��������� ������")) Then
            Return trans("������������ ������")

        Else
            Return prop
        End If
    End Function

    ' ����������� �������� � ������������
    Public Sub ShowPropInEditProperty(ByVal EditPr As Object)
        peremens2.ShowPropInEditProperty(EditPr)
    End Sub

    ' �������� ������ ���������� �������� ��� ������
    Public Function GetArguments(ByVal meth As String, ByVal MyObj As Object) As String()
        meth = UCase(meth)

        If meth = UCase(MyZnak & trans("��������� � �����")) Or meth = UCase(MyZnak & trans("�������� �����")) Then
            Dim temp() As String = {trans("���� � �����"), trans("��� ���������"), trans("��������� ������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("������� ����")) Then
            Dim temp() As String = {trans("���� � �����"), trans("��������� ������"), "�������"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("��������� �������")) Then
            Dim temp() As String = {trans("���� � �����"), trans("������� ��� ����������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("���������")) Then
            Dim temp() As String = {trans("������� Windows ��� ��� �����"), trans("���������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("��������� � �����������")) Then
            Dim temp() As String = {trans("������� Windows ��� ��� �����"), trans("���������"), _
                                    trans("��������� ������"), "�������"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("������� �����")) Then
            Dim temp() As String = {trans("������������ ����� ���������� ������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("������� ��������")) Then
            Dim temp() As String = {trans("������ ��������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("����� ������")) Then
            Dim temp() As String = {trans("���� � �����"), trans("��� ������"), "�������"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("������� ��������")) Then
            Dim temp() As String = {trans("������ �������� ����")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("��������")) Then
            Dim temp() As String = {trans("������ �������� ����"), "�������"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("������� �������� �������")) Then
            Dim temp() As String = {trans("������ ������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("�������� �������")) Then
            Dim temp() As String = {trans("������ ������"), "�������"}
            Return temp



        ElseIf meth = UCase(MyZnak & trans("�����������")) Or meth = UCase(MyZnak & trans("������������")) _
        Or meth = UCase(MyZnak & trans("�������")) Or meth = UCase(MyZnak & trans("������� �����")) _
        Or meth = UCase(trans("������� ���������")) _
        Or meth = UCase(trans("��������� �������")) Or meth = UCase(trans("������� �������")) _
        Or meth = UCase(trans("��������� ��������")) Or meth = UCase(trans("������� ��������")) _
        Or meth = UCase(trans("��������� ���� ��������")) Or meth = UCase(trans("��������� ���� �������")) _
        Then
            Dim temp() As String = {trans("���� � �����")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("����������")) Or meth = UCase(MyZnak & trans("�����������")) Then
            Dim temp() As String = {trans("���� � �����"), trans("����� ���� � �����")}
            Return temp


        ElseIf meth = UCase(MyZnak & trans("�������")) Or meth = UCase(MyZnak & trans("������ ��� ������")) _
        Or meth = UCase(MyZnak & trans("��������")) Or meth = UCase(MyZnak & trans("�����")) _
        Or meth = UCase(MyZnak & trans("�������������")) Or meth = UCase(MyZnak & trans("�� �������������")) _
        Or meth = UCase(MyZnak & trans("���������")) Or meth = UCase(MyZnak & trans("���������")) _
        Then
            Dim temp() As String = {trans("���� � ����� ��� �����"), trans("�������� ��������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("���������� ����")) Or meth = UCase(MyZnak & trans("���������� �����")) _
        Or meth = UCase(MyZnak & trans("�������� �����")) Or meth = UCase(MyZnak & trans("�������� �����")) _
        Or meth = UCase(MyZnak & trans("���������� ��������")) Or meth = UCase(MyZnak & trans("���������� ������������")) _
        Or meth = UCase(MyZnak & trans("���������� ��� �����")) _
        Or meth = UCase(MyZnak & trans("���������� ��� �����")) Or meth = UCase(MyZnak & trans("���������� ����������")) _
        Or meth = UCase(MyZnak & trans("���������� ��� ����������")) Or meth = UCase(MyZnak & trans("���������� ������ �����")) _
        Then
            Dim temp() As String = {trans("���� � ����� ��� �����"), "�������"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("����� ��������")) Or meth = UCase(MyZnak & trans("����� �������")) _
        Or meth = UCase(MyZnak & trans("����� ���������")) Then
            Dim temp() As String = {trans("���� � ����� ��� �����"), trans("�����")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("������� ��������")) Then
            Dim temp() As String = {trans("���� ���������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("������� ��������")) _
        Or meth = UCase(MyZnak & trans("������� �����")) Or meth = UCase(MyZnak & trans("������� ��������")) _
        Then
            Dim temp() As String = {trans("���� �������")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("�������� �������")) Or meth = UCase(MyZnak & trans("���� ����������")) _
        Or meth = UCase(MyZnak & trans("����� ����������")) Or meth = UCase(MyZnak & trans("��� �����")) _
        Then
            Dim temp() As String = {trans("���� �������"), "�������"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("������� ����")) Then
            Dim temp() As String = {trans("���� �������"), trans("�������� �����"), trans("��� �����")}
            Return temp

        ElseIf meth = UCase(trans("����� ������� �� �����������")) Or meth = UCase(trans("�������� �� �����������")) _
        Or meth = UCase(trans("����� ������ �� �����������")) Or meth = UCase(trans("����� ������� �� �����������")) _
        Then
            Dim temp() As String = {trans("X"), trans("Y"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("����� ������� ������� ������")) Or meth = UCase(trans("������")) Then
            Dim temp() As String = {trans("���������� ����� ������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("����� ������ �� ������ �������")) Or meth = UCase(trans("������")) _
        Or meth = UCase(trans("X �� ������ �������")) Or meth = UCase(trans("Y �� ������ �������")) _
        Then
            Dim temp() As String = {trans("���������� ����� �������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("�������� ��������")) Then
            Dim temp() As String = {trans("�������� ��������")}
            Return temp


            ' �������

        ElseIf meth = UCase(trans("��� ���� ������")) Then
            Dim temp() As String = {trans("��� ���� ������")}
            Return temp

        ElseIf meth = UCase(trans("�������� ������")) Or meth = UCase(trans("������ ��������")) _
        Or meth = UCase(trans("������ ������ ��� ������")) Then
            Dim temp() As String = {trans("������ ����� ����� �������"), trans("������ �������� ����� �������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("������ ������ ��� ������")) Then
            Dim temp() As String = {trans("������ ����� ����� �������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("������� ������ ��� ������")) Or meth = UCase(trans("������ �������")) Then
            Dim temp() As String = {trans("������ �������� ����� �������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("������ ������")) Then
            Dim temp() As String = {trans("������ ����� ����� �������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("�������� ������")) Then
            If MyObj Is Nothing Then Return Nothing
            Dim i As Integer, temp(MyObj(0).obj.columns.count - 1) As String
            For i = 0 To MyObj(0).obj.columns.count - 1
                temp(i) = trans("���������� ��� �������") & " """ & MyObj(0).obj.columns(i).HeaderText & """ (" & i & ")"
            Next
            Return temp

        ElseIf meth = UCase(trans("�������� ����� �����")) Then
            Dim temp() As String = {trans("��������� ������ �����������"), trans("���������� ����� ��� �����������")}
            Return temp

        ElseIf meth = UCase(trans("����� ������ ������")) Or meth = UCase(trans("����� ��������� ������")) Then
            Dim temp() As String = {trans("������� �������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("����� ��������� ������")) Or meth = UCase(trans("����� ���������� ������")) Then
            Dim temp() As String = {trans("����� ��������� ������"), trans("������� �������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("�������� ������")) Then
            If MyObj Is Nothing Then Return Nothing
            Dim i As Integer, temp(MyObj(0).obj.columns.count - 1 + 1) As String
            temp(0) = trans("����� ������ ���� ���������")
            For i = 0 To MyObj(0).obj.columns.count - 1
                temp(i + 1) = trans("���������� ��� �������") & i & " """ & MyObj(0).obj.columns(i).HeaderText & """"
            Next
            Return temp

        ElseIf meth = UCase(trans("�������� ����� �����")) Then
            Dim temp() As String = {trans("����� ������ ���� ���������"), trans("��������� ������ �����������"), _
                                    trans("���������� ����� ��� �����������")} : Return temp

        ElseIf meth = UCase(trans("������� ������")) Then
            Dim temp() As String = {trans("������ ����� ����� �������")}
            Return temp

        ElseIf meth = UCase(trans("������� �������")) Then
            Dim temp() As String = {trans("������ �������� ����� �������")}
            Return temp

        ElseIf meth = UCase(trans("�������� �������")) Then
            Dim temp() As String = {trans("����� ������� ���� ���������"), trans("����� ��������� �������")}
            Return temp

        ElseIf meth = UCase(trans("�������� �������")) Then
            Dim temp() As String = {trans("����� ��������� �������")}
            Return temp

        ElseIf meth = UCase(trans("������� Access")) Or meth = UCase(trans("������� Excel")) Then
            Dim temp() As String = {trans("���� � �����"), trans("�������� �������")}
            Return temp

        ElseIf meth = UCase(trans("SQL ������ �������")) Then
            Dim temp() As String = {trans("��� ���� ������"), trans("���� � �����"), _
                                    trans("SQL ������ ������� �� ���� ������")}
            Return temp

        ElseIf meth = UCase(trans("SQL ������ ���������")) Then
            Dim temp() As String = {trans("��� ���� ������"), trans("���� � �����"), _
                                    trans("SQL ������ ��������� ���� ������")}
            Return temp

        ElseIf meth = UCase(trans("�����������")) Then
            Dim temp() As String = {trans("����� �������"), trans("����������� �� �����������")}
            Return temp

        ElseIf meth = UCase(trans("������ �� ������")) Then
            Dim temp() As String = {trans("����� ������ � ������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("����� ����� ������")) Then
            Dim temp() As String = {trans("������ �� ������"), "�������"}
            Return temp

        ElseIf meth = UCase(trans("�������� ������")) Or meth = UCase(trans("������� ������")) Then
            Dim temp() As String = {trans("����� ������")}
            Return temp

        ElseIf meth = UCase(trans("�������� ������")) Then
            Dim temp() As String = {trans("����� ��� ������ � ������"), trans("����� ������")}
            Return temp

        ElseIf meth = UCase(trans("������� ������ �� ������")) Then
            Dim temp() As String = {trans("����� ������ � ������")}
            Return temp

        ElseIf meth = UCase(trans("����� � �������")) Then
            Dim temp() As String = {trans("��� ������ � �������"), trans("C ������ ��������"), trans("����� �������"), _
                                    trans("������ ������ �������� �����"), trans("������� ������ �������� �����"), ""}
            Return temp

        ElseIf meth = UCase(trans("����� � ����������")) Then
            Dim temp() As String = {trans("��� ������ � �������"), trans("C ������ ��������"), trans("����� �������"), _
                                    trans("������ ������ �������� �����"), trans("������� ������ �������� �����")}
            Return temp

        ElseIf meth = UCase(trans("����� � ��������� �������")) Then
            Dim temp() As String = {trans("��� ������ � �������"), trans("C ������ ��������"), trans("����� �������"), ""}
            Return temp




            ' ����� �������� ������

        ElseIf meth = MyZnak & UCase(trans("������ �� ������")) Then
            Dim temp() As String = {trans("�������� �����"), trans("���������� ����� ������� � ������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("�������� ������")) Then
            Dim temp() As String = {trans("�������� �����"), trans("����� � ������� ����������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("����� � ������")) Or meth = MyZnak & UCase(trans("����� ������ ������")) _
        Or meth = MyZnak & UCase(trans("����� � ������ ��������")) _
        Or meth = MyZnak & UCase(trans("����� � ������ � �����")) _
        Or meth = MyZnak & UCase(trans("����� ��� �������")) _
        Then
            Dim temp() As String = {trans("�������� �����"), trans("��� ������ � ������"), _
                                    trans("����� ������� ������ �������� �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("����� � ����������� �����������")) Then
            Dim temp() As String = {trans("�������� �����"), trans("������ ����������� ���������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("���������� ��������")) _
        Or meth = MyZnak & UCase(trans("������� ������")) Or meth = MyZnak & UCase(trans("��������� ���������")) _
        Or meth = MyZnak & UCase(trans("���������� �����")) _
        Or meth = MyZnak & UCase(trans("������� ����� ����������")) _
        Or meth = MyZnak & UCase(trans("������� ����� ����������")) _
        Or meth = MyZnak & UCase(trans("������ �������")) _
        Or meth = MyZnak & UCase(trans("������ ������� � ������")) _
        Or meth = MyZnak & UCase(trans("������ ������� � �����")) _
        Or meth = MyZnak & UCase(trans("����� ���� �����")) _
        Or meth = MyZnak & UCase(trans("����� ���� �����")) _
        Then
            Dim temp() As String = {trans("�������� �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("������� �� �����")) _
        Or meth = MyZnak & UCase(trans("������� �� ����� ��� �������")) _
        Then
            Dim temp() As String = {trans("�������� �����"), trans("������ ���������� ������"), _
                                    trans("����� ������ �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("����� ����� ������")) _
        Or meth = MyZnak & UCase(trans("������� ����� ������")) Then
            Dim temp() As String = {trans("�������� �����"), trans("����� ������� ������ �����"), _
                                    trans("������ �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("���������� ������ ������")) _
        Or meth = MyZnak & UCase(trans("���������� ������ ��� �������")) _
        Then
            Dim temp() As String = {trans("�������� �����"), trans("������ ���������� ������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("����� ��������")) Then
            Dim temp() As String = {trans("�������� �����"), trans("������ ������� ������� ������ ��������� �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("����� �� ��������")) Then
            Dim temp() As String = {trans("�������� �����"), _
                                    trans("������ ������� ������� �� ������ ��������� �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("����� ������� ��")) Then
            Dim temp() As String = {trans("�������� �����"), _
                                    trans("������ ������� �� ������� ������ �������� �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("������ �� ������")) Then
            Dim temp() As String = {trans("�������� �����"), trans("���������� ����� ������ � ������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("�������� ������� � �����")) Then
            Dim temp() As String = {trans("�������� �����"), trans("����� ������� ���� ���������"), _
                                    trans("����� ������� ���� ��������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("��������")) Or meth = MyZnak & UCase(trans("�������� ���")) Then
            Dim temp() As String = {trans("�������� �����"), trans("��� ��������"), trans("�� ��� ��������"), "�������"}
            Return temp

            ' ��������� 

        ElseIf meth = MyZnak & UCase(trans("��������� ���������")) Then
            Dim temp() As String = {trans("����� ���������"), trans("������ ���������"), trans("��� ���������"), _
                                    trans("���������")}
            Return temp

            ' ����

        ElseIf meth = MyZnak & UCase(trans("���� ������")) Or meth = MyZnak & UCase(trans("���� ����")) _
        Or meth = MyZnak & UCase(trans("���� � ������")) Or meth = MyZnak & UCase(trans("���")) _
        Or meth = MyZnak & UCase(trans("������")) Or meth = MyZnak & UCase(trans("�������")) _
        Or meth = MyZnak & UCase(trans("�������")) Or meth = MyZnak & UCase(trans("������ � ����")) _
        Or meth = MyZnak & UCase(trans("���")) Or meth = MyZnak & UCase(trans("�����")) _
        Or meth = MyZnak & UCase(trans("������ ����� � ����")) Or meth = MyZnak & UCase(trans("���� ������")) _
        Or meth = MyZnak & UCase(trans("�������� ������")) Or meth = MyZnak & UCase(trans("�����")) _
        Then
            Dim temp() As String = {trans("���� �� ������� �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("��������� ���")) Or meth = MyZnak & UCase(trans("��������� ����")) _
        Or meth = MyZnak & UCase(trans("��������� ������")) Or meth = MyZnak & UCase(trans("��������� �������")) _
        Or meth = MyZnak & UCase(trans("��������� ��������")) Or meth = MyZnak & UCase(trans("��������� ������")) _
        Or meth = MyZnak & UCase(trans("��������� ����")) Or meth = MyZnak & UCase(trans("��������� ������")) _
        Then
            Dim temp() As String = {trans("���� � ������� ����������"), trans("������� ���������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("������� � ����")) Or meth = MyZnak & UCase(trans("������� � �����")) _
        Or meth = MyZnak & UCase(trans("������� � �������")) Or meth = MyZnak & UCase(trans("������� � ��������")) _
        Or meth = MyZnak & UCase(trans("������� � ���������")) Or meth = MyZnak & UCase(trans("������� � �������")) _
        Or meth = MyZnak & UCase(trans("������� � �����")) Or meth = MyZnak & UCase(trans("������� � �������")) _
        Then
            Dim temp() As String = {trans("����1 ������� ��������"), trans("����2 �� ������� ��������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("���� � ������")) Then
            Dim temp() As String = {trans("���"), trans("�����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("���� � ������������ �������")) Then
            Dim temp() As String = {trans("����"), trans("����� ������� ������ (�� 1 �� 52)"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("�������� ����� ����������")) Then
            Dim temp() As String = {trans("����� ���� � �����")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("��������� ��� VBScript")) Then
            Dim temp() As String = {trans("��� VBScript")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("��������� ��� ���������2")) Then
            Dim temp() As String = {trans("��� ��������� 2")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("��������� ��� VBNet")) Then
            Dim temp() As String = {trans("��� VBNet")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("��������� ��� CSharp")) Then
            Dim temp() As String = {trans("��� CSharp")}
            Return temp

        ElseIf meth = UCase(trans("���� ��������� ������")) Then
            Dim temp() As String = {trans("ID ������������"), trans("�������� � ����"), ""}
            Return temp

        ElseIf meth = UCase(trans("���� ��������� ���������")) Then
            Dim temp() As String = {trans("���� ���������"), trans("�������� � ����"), ""}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("�������������")) Then
            Dim temp() As String = {trans("���� � ����� ��� �����"), trans("����� ���"), ""}
            Return temp

            ' ������ - ������
        ElseIf meth = UCase(trans("Ip �������")) Then
            Dim temp() As String = {trans("��� �������"), ""}
            Return temp

        ElseIf meth = UCase(trans("��������� �������")) Or meth = UCase(trans("��������� ��������")) Then
            Dim temp() As String = {trans("���������� ���������")}
            Return temp

        ElseIf meth = UCase(trans("��������� ���� �������")) Or meth = UCase(trans("��������� ���� ��������")) _
        Or meth = UCase(MyZnak & trans("������� �����")) _
        Then
            Dim temp() As String = {trans("���� � ����� ��� �����")}
            Return temp

        ElseIf meth = UCase(trans("��������� �������� �����")) Then
            Dim temp() As String = {trans("����� ��������, ������� �� ����������"), trans("���������� ���������")}
            Return temp

        ElseIf meth = UCase(trans("��������� �������")) Then
            Dim temp() As String = {trans("����� ��������"), trans("���������� ���������")}
            Return temp

        ElseIf meth = UCase(trans("��������� ���� �������� �����")) Then
            Dim temp() As String = {trans("����� ��������, ������� �� ����������"), trans("���� � ����� ��� �����")}
            Return temp

        ElseIf meth = UCase(trans("��������� ���� �������")) Then
            Dim temp() As String = {trans("����� ��������"), trans("���� � ����� ��� �����")}
            Return temp

        ElseIf meth = UCase(trans("�������� � ���")) Then
            Dim temp() As String = {trans("����������� �����")}
            Return temp

        ElseIf meth = UCase(trans("��������� �������")) Then
            Dim temp() As String = {trans("�������")}
            Return temp

            ' ��������
        ElseIf meth = UCase(trans("�������� ��� ��������")) Then
            Dim temp() As String = {trans("������")}
            Return temp

        ElseIf meth = UCase(trans("������� ����")) Then
            Dim temp() As String = {trans("������"), trans("����� ���� ���������")}
            Return temp

            ' ������
        ElseIf meth = MyZnak & UCase(trans("���������� ������")) Or meth = MyZnak & UCase(trans("���������� �����")) Then
            Dim temp() As String = {trans("���� � �����"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("����������� �����")) Or meth = MyZnak & UCase(trans("������������ �����")) Then
            Dim temp() As String = {trans("�����"), trans("���� ���������� ������"), "�������"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("������� �����")) Then
            Dim temp() As String = {trans("��� ��������")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("���� � ������")) Then
            Dim temp() As String = {trans("��������� ����")}
            Return temp

        Else
            Return Nothing
        End If

    End Function

    ' �������� �������� ��������� � �������� ��� ������ �� ���������
    Public Function DefaultValue(ByVal arg As String) As String
        arg = UCase(arg)
        If arg = UCase(trans("���� � �����")) Or arg = UCase(trans("����� ���� � �����")) _
        Or arg = UCase(trans("���� � ����� ��� �����")) Then
            Return """\" & proj.iPathShort & "\" & proj.pPicNameDef & ".jpg"""
        ElseIf arg = UCase(trans("���� � �����")) Then
            Return """\" & proj.iPathShort & """"
        ElseIf arg = UCase(trans("����� ���")) Then
            Return """" & trans("����") & ".txt"""
        ElseIf arg = UCase(trans("��� ���������")) Then
            Return trans("����") & "1." & trans("����") & "1." & trans("�����")
        ElseIf arg = UCase(trans("��� ������")) Then
            Return """*.*"""
        ElseIf arg = UCase(trans("������� ��� ����������")) Then
            Return trans("����") & "1." & trans("����") & "1." & trans("������� �������")
        ElseIf arg = UCase(trans("�������� ����������� �����")) Then
            Return trans("��")
        ElseIf arg = UCase(trans("������ �������� ����")) Then
            Return trans("���")
        ElseIf arg = UCase(trans("������������ ����� ���������� ������")) Then
            Return """" & trans("���� ����� �������� ���������") & """"
        ElseIf arg = UCase(trans("������� Windows ��� ��� �����")) Then
            Return """" & trans("explorer.exe") & """"
        ElseIf arg = UCase(trans("���������")) Then
            Return """" & trans("C:\") & """"
        ElseIf arg = UCase(trans("������ ��������")) Then
            Return """" & trans("100") & """"
        ElseIf arg = UCase(trans("���� �������")) Then
            Return """" & trans("HKEY_CURRENT_USER\Control Panel\Mouse") & """"
        ElseIf arg = UCase(trans("��� �����")) Then
            Return trans("������")
        ElseIf arg = UCase(trans("X")) Or arg = UCase(trans("X")) Or arg = UCase(trans("���������� ����� ������")) _
        Or arg = UCase(trans("���������� ����� �������")) Or arg = UCase(trans("Y")) Or arg = UCase(trans("�")) Then
            Return trans("0")
        ElseIf arg = UCase(trans("�������� ��������")) Then
            Return trans("������")
        ElseIf arg = UCase(trans("������� �������")) Then
            Return trans("��� �������")
        ElseIf arg = UCase(trans("������� �������")) Then
            Return trans("��� �������")
        ElseIf arg = UCase(trans("����������� �� �����������")) Then
            Return trans("��")
        ElseIf arg = UCase(trans("���������� ����� ������� � ������")) _
        Or arg = UCase(trans("����� ������� ������ �������� �����")) _
        Or arg = UCase(trans("����� ������ �����")) _
        Or arg = UCase(trans("����� ������� ������ �����")) Or arg = UCase(trans("������ �����")) _
        Or arg = UCase(trans("������ ������� ������� ������ ��������� �����")) _
        Or arg = UCase(trans("������ ������� ������� ������ �� ��������� �����")) _
        Or arg = UCase(trans("���������� ����� ������ � ������")) _
        Or arg = UCase(trans("����� ������� ���� ���������")) _
        Then
            Return "1"
        ElseIf arg = UCase(trans("������ ���������")) Then
            Return trans("��")
        ElseIf arg = UCase(trans("��� ���������")) Then
            Return trans("�������")
        ElseIf arg = UCase(trans("��������� ������")) Then
            Return trans("�� ���������")
        ElseIf arg = UCase(trans("����� ���� � �����")) _
        Or arg = UCase(trans("����")) Or arg = UCase(trans("����1 ������� ��������")) _
        Or arg = UCase(trans("����2 �� ������� ��������")) Or arg = UCase(trans("���� � ������� ����������")) _
        Or arg = UCase(trans("���� �� ������� �����")) _
        Then
            Return ToMyDate(Now)
        ElseIf arg = UCase(trans("����� ������� ������ (�� 1 �� 52)")) Then
            Return "11"
        ElseIf arg = UCase(trans("���")) Then
            Return Now.Year
        ElseIf arg = UCase(trans("�����")) Then
            Return Now.Month
        ElseIf arg = UCase(trans("������� ���������")) Then
            Return "1"
        ElseIf arg = UCase(trans("��� VBScript")) Then
            Return """Sub main()" & Chr(182) & " msgbox(""""" & trans("������") & "!"""")" & Chr(182) & "End Sub"""
        ElseIf arg = UCase(trans("��� ��������� 2")) Then
            Return """_" & trans("�������� �������") & "._" & trans("�������� ���������") & "._" & _
                    trans("��������� ���������") & "(""""" & trans("������") & "!"""", " & _
                    trans("��") & ", " & trans("�������") & ", )"""
        ElseIf arg = UCase(trans("��� VBNet")) Then
            Return """Imports System.Windows.Forms" & Chr(182) & _
                    "'" & trans("����� MainClass � ������� Main ������ ����������� ��������������") & Chr(182) & _
                    "Public Class MainClass " & Chr(182) & _
                    "   Public Function Main()" & Chr(182) & _
                    "       Dim frm as New Form" & Chr(182) & _
                    "       frm.Text=""""" & trans("������") & "!""""" & Chr(182) & _
                    "       frm.Show" & Chr(182) & _
                    "   End Function" & Chr(182) & _
                    "End Class"""
        ElseIf arg = UCase(trans("��� CSharp")) Then
            Return """using System.Windows.Forms;" & Chr(182) & _
                    "//" & trans("����� MainClass � ������� Main ������ ����������� ��������������") & Chr(182) & _
                    "public class MainClass  {" & Chr(182) & _
                    "   public void Main() {" & Chr(182) & _
                    "       Form frm = new Form();" & Chr(182) & _
                    "       frm.Text=""""" & trans("������") & "!"""";" & Chr(182) & _
                    "       frm.Show();" & Chr(182) & _
                    "   }" & Chr(182) & _
                    "}"""
        ElseIf arg = UCase(trans("SQL ������ ������� �� ���� ������")) Then
            Return """SELECT * FROM " & trans("�������") & "1"""
        ElseIf arg = UCase(trans("SQL ������ ��������� ���� ������")) Then
            Return """INSERT INTO " & trans("�������") & "1 VALUES ('1', 'a')"""
        ElseIf arg = UCase(trans("��� ���� ������")) Then
            Return "Access"
        ElseIf arg = UCase(trans("�������� �������")) Then
            Return """" & trans("�������") & "1"""
        ElseIf arg = UCase(trans("����� ��������")) Or arg = UCase(trans("����� ��������, ������� �� ����������")) Then
            Return """" & trans("������") & "1," & trans("������") & "2," & trans("������") & "3" & """"
        ElseIf arg = UCase(trans("��� �����")) Then
            Return """" & trans("image/gif") & """"
        ElseIf arg = UCase(trans("����� ���� ���������")) Then
            Return trans("��")
        ElseIf arg = UCase(trans("����� ���������")) Then
            Return """" & trans("����� ���������") & """"
        ElseIf arg = UCase(trans("���������")) Then
            Return """" & trans("���������") & """"
        ElseIf arg = UCase(trans("���� ���������� ������")) Then
            Return """" & trans("�����12345") & """"
        ElseIf arg = UCase(trans("��� ������ � �������")) Then
            Return """" & trans("�����") & """"
        ElseIf arg = UCase(trans("C ������ ��������")) Then
            Return trans("���")
        ElseIf arg = UCase(trans("����� �������")) Then
            Return trans("���")
        ElseIf arg = UCase(trans("������ ������ �������� �����")) Then
            Return 0
        ElseIf arg = UCase(trans("������� ������ �������� �����")) Then
            Return 0
        ElseIf arg = UCase(trans("������ ������")) Then
            Return """" & trans("����") & "1"""


        Else
            Return ""
        End If
    End Function

    ' ���������, ����� �� ������������ ����� ���
    Function ValidName(ByVal name As String) As Boolean
        Dim i As Integer
        ' ������ �����
        If name.Length = 0 Then
            If IsHttpCompil = False Then MsgBox(Errors.NameInvalidLength(name), MsgBoxStyle.Exclamation)
            Return False
        End If
        ' ������������ �������
        For i = 0 To name.Length - 1
            If Char.IsLetter(name(i)) = False And Char.IsDigit(name(i)) = False And name(i) <> " " Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidSimvols(name), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        ' ������ � ������
        If name(0) = " " Then
            If IsHttpCompil = False Then MsgBox(Errors.NameInvalidProbels(name), MsgBoxStyle.Exclamation)
            Return False
        End If
        If Char.IsDigit(name(0)) Then
            If IsHttpCompil = False Then MsgBox(Errors.NameInvalidDigit(name), MsgBoxStyle.Exclamation)
            Return False
        End If
        ' ���������� � ������ �������
        For i = 0 To AllFuncs.Length - 1
            If LCase(AllFuncs(i)) = LCase(name) Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidFuns(AllFuncs(i)), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        ' ���������� � ���������������� �������
        For i = 0 To AllHW.Length - 1
            If LCase(AllHW(i)) = LCase(name) Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidHW(AllHW(i)), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        ' ���������� � ������� ��������� �������
        For i = 0 To VBKeyWords.Length - 1
            If LCase(VBKeyWords(i)) = LCase(name) Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidHW(VBKeyWords(i)), MsgBoxStyle.Exclamation)
                Return False
            ElseIf LCase(name).IndexOf(" " & LCase(VBKeyWords(i)) & " ") <> -1 Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidHW(VBKeyWords(i)), MsgBoxStyle.Exclamation)
                Return False
            ElseIf LCase(name).IndexOf(LCase(VBKeyWords(i)) & " ") = 0 Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidHW(VBKeyWords(i)), MsgBoxStyle.Exclamation)
                Return False
            ElseIf LCase(name).IndexOf(" " & LCase(VBKeyWords(i))) <> -1 And LCase(name).IndexOf(" " & LCase(VBKeyWords(i))) = name.Length - (" " & VBKeyWords(i)).Length Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidHW(VBKeyWords(i)), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        Return True
    End Function

    ' ����� ������� � � � � ��������. � � ����+� ����.
    Sub IzmenenieBylo(Optional ByVal withNoMarkerVis As Boolean = True)
        Dim i As Integer, MyObj As Object, mozhno As Boolean = False
        'If fromIzmenenieBylo = True Then Exit Sub
        '  fromIzmenenieBylo = True
        If proj.ActiveForm Is Nothing Then Exit Sub
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            IzmenenieBylo2(proj.ActiveForm.ActiveObj(i), mozhno)
        Next

        If mozhno Then MainForm.ReSelectedListViewOneItem()
        If withNoMarkerVis = False And MainForm.Peremeschatel.Focused = False Then proj.ActiveForm.marker_vis()
        fromIzmenenieBylo = False
    End Sub
    Sub IzmenenieBylo2(ByVal myObj As Object, Optional ByRef mozhno As Boolean = False)
        If fromIzmenenieBylo = True Then Exit Sub
        fromIzmenenieBylo = True
        If Iz.IsRT(myObj) = False Then
            izmenit(UCase(trans("�����")), myObj.obj.Text, myObj, mozhno)
        End If
        If Iz.IsTr(myObj) Then
            izmenit(UCase(trans("����� ����")), myObj.obj.TextB.Text, myObj, mozhno)
        End If
        If Iz.IsFORM(myObj) = False Then
            izmenit(UCase(trans("X")), myObj.obj.Left, myObj, mozhno)
            izmenit(UCase(trans("Y")), myObj.obj.Top, myObj, mozhno)
        End If
        izmenit(UCase(trans("������")), myObj.obj.Height, myObj, mozhno)
        izmenit(UCase(trans("������")), myObj.obj.Width, myObj, mozhno)
        If Iz.IsDP(myObj) Then
            izmenit(UCase(trans("���������� �����������")), myObj.obj.SplitterDistance, myObj, mozhno)
        End If
        If Iz.IsTP(myObj) Then
            izmenit(UCase(trans("������� ���������� ��������")), myObj.obj.SelectedIndex, myObj, mozhno)
        End If
        If Iz.IsC(myObj) Or Iz.IsL(myObj) Or Iz.IsCL(myObj) Then
            izmenit(UCase(trans("����� ���������� ������")), myObj.obj.SelectedIndex, myObj, mozhno)
            izmenit(UCase(trans("���������� ������")), myObj.obj.SelectedItem, myObj, mozhno)
        End If
        If Iz.IsL(myObj) Then
            izmenit(UCase(trans("������ ���������� �������")), myObj.obj.SelectedIndex, myObj, mozhno)
            izmenit(UCase(trans("���������� ������")), myObj.obj.SelectedItem, myObj, mozhno)
        End If
        fromIzmenenieBylo = False
    End Sub
    Sub izmenit(ByVal prop As String, ByVal value As String, ByVal myObj As Object, ByRef mozhno As Boolean)
        If myObj.PropertysUp Is Nothing Then Exit Sub
        If GetProperty(myObj, prop).str <> value And Array.IndexOf(myObj.PropertysUp, prop) <> -1 Then
            If mozhno = True Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            If myObj.GetMyForm IsNot Nothing Then myObj.GetMyForm.SetPropertys(prop, value, "", myObj)
            mozhno = True
            MainForm.RefreshListViewOneItem(prop, value)
        End If
    End Sub
    ' ����� ������� � ��������� � � ������ � ��������, ������� ��� ����������� � ������������
    Sub IzmenenieByloExpert()
        Dim i As Integer, MyObj As Object, bilo As Boolean = False
        If fromIzmenenieBylo = True Then Exit Sub
        fromIzmenenieBylo = True
        If proj.ActiveForm Is Nothing Then Exit Sub
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            MyObj = proj.ActiveForm.ActiveObj(i)

            If Iz.IsTl(MyObj) Then
                izmenitExp(UCase(trans("������ ���������� �����")), MyObj.obj.Props.selRows, MyObj.obj.Props.SelectedRows, bilo)
                izmenitExp(UCase(trans("������ ���������� ��������")), MyObj.obj.Props.selCol, MyObj.obj.Props.SelectedColumns, bilo)
                izmenitExp(UCase(trans("������ ��������")), MyObj.obj.Props.colsWids, MyObj.obj.Props.WidthOfColumns, bilo)
                izmenitExp(UCase(trans("������ �����")), MyObj.obj.Props.RowsH, MyObj.obj.Props.HeightOfRows, bilo)
            End If

        Next
        If bilo Then MainForm.ReSelectedListViewOneItem()
        fromIzmenenieBylo = False
    End Sub
    Sub izmenitExp(ByVal prop As String, ByRef varPrivatePropertys As Object, ByVal varPublicPropertys As Object, ByRef bilo As Boolean)
        varPrivatePropertys = varPublicPropertys : bilo = True
        MainForm.RefreshListViewOneItem(prop, varPublicPropertys)
    End Sub

    ' ��������������� ����� ������� ���� ���������� � ������
    Function SrazuPerevoditHW(ByVal word As String) As String
        If Papks.ContainsKey(LCase(word)) Then
            If isCompilBest = False Then
                Return """" & Papks(LCase(word)) & """"
            Else
                Return "Papks(LCase(""" & word & """))"
            End If
        End If
        Return Nothing
    End Function

    ' C������� ��������� �������, ����� ��� ���������, ���� � �.�.
    Sub CreateConstants()
        Try
            IO.Path.GetTempFileName()
        Catch ex As Exception
            MsgBox(trans("����� � ���������� ������� �����������! �������� �. ��� ���������, ����� �� ������� Ok."))
            Diagnostics.Process.Start("explorer", IO.Path.GetTempPath)
            End
        End Try
        Dim i As Integer
        ' �������� �������� ��������
        Colors.Clear()
        Colors.Add(LCase(trans("����")), Color.Aqua)
        Colors.Add(LCase(trans("������")), Color.Black)
        Colors.Add(LCase(trans("�����")), Color.Blue)
        Colors.Add(LCase(trans("����������")), Color.Brown)
        Colors.Add(LCase(trans("����������")), Color.Chocolate)
        Colors.Add(LCase(trans("���������")), Color.Coral)
        Colors.Add(LCase(trans("�����")), Color.Gray)
        Colors.Add(LCase(trans("���������")), Color.GreenYellow)
        Colors.Add(LCase(trans("������")), Color.Indigo)
        Colors.Add(LCase(trans("����")), Color.Lime)
        Colors.Add(LCase(trans("�������")), Color.Magenta)
        Colors.Add(LCase(trans("����������")), Color.Violet)
        Colors.Add(LCase(trans("����������")), Color.Silver)
        Colors.Add(LCase(trans("���������")), Color.Orange)
        Colors.Add(LCase(trans("����")), Color.DarkKhaki)
        Colors.Add(LCase(trans("����")), Color.Teal)
        Colors.Add(LCase(trans("���������")), Color.DodgerBlue)
        Colors.Add(LCase(trans("���������")), Color.Purple)
        Colors.Add(LCase(trans("���������")), SystemColors.Control)
        Colors.Add(LCase(trans("��������� ������")), SystemColors.ControlDark)
        Colors.Add(LCase(trans("�����")), Color.White)
        Colors.Add(LCase(trans("�������")), Color.Red)
        Colors.Add(LCase(trans("�������")), Color.Green)
        Colors.Add(LCase(trans("������")), Color.Yellow)

        ' �������� �������� ��������
        Anchors.Clear()
        Anchors.Add(LCase(trans("�������")), 0)
        Anchors.Add(LCase(trans("�����")), 4)
        Anchors.Add(LCase(trans("������")), 8)
        Anchors.Add(LCase(trans("������")), 1)
        Anchors.Add(LCase(trans("�����")), 2)
        Anchors.Add(LCase(trans("�����_������")), 5)
        Anchors.Add(LCase(trans("�����_�����")), 6)
        Anchors.Add(LCase(trans("������_�����")), 12)
        Anchors.Add(LCase(trans("������_������")), 9)
        Anchors.Add(LCase(trans("������_�����")), 10)
        Anchors.Add(LCase(trans("������_�����")), 3)
        Anchors.Add(LCase(trans("�����_������_�����")), 7)
        Anchors.Add(LCase(trans("������_������_�����")), 11)
        Anchors.Add(LCase(trans("������_�����_������")), 13)
        Anchors.Add(LCase(trans("������_�����_�����")), 14)
        Anchors.Add(LCase(trans("������_�����_������_�����")), 15)

        ' �������� �������� ����� ����   
        bkImStyles.Clear()
        bkImStyles.Add(LCase(trans("�������")), ImageLayout.None)
        bkImStyles.Add(LCase(trans("������")), ImageLayout.Tile)
        bkImStyles.Add(LCase(trans("�� ������")), ImageLayout.Center)
        bkImStyles.Add(LCase(trans("����������")), ImageLayout.Stretch)
        bkImStyles.Add(LCase(trans("����������������")), ImageLayout.Zoom)

        ' �������� �������� ����� ����  
        Cursori.Clear()
        Cursori.Add(LCase(trans("�������")), Cursors.Default)
        Cursori.Add(LCase(trans("����� ����������")), Cursors.AppStarting)
        Cursori.Add(LCase(trans("�����������")), Cursors.Cross)
        Cursori.Add(LCase(trans("����")), Cursors.Hand)
        Cursori.Add(LCase(trans("������")), Cursors.Help)
        Cursori.Add(LCase(trans("�������������� �����������")), Cursors.HSplit)
        Cursori.Add(LCase(trans("���������")), Cursors.IBeam)
        Cursori.Add(LCase(trans("�����������")), Cursors.No)
        Cursori.Add(LCase(trans("����������� �����������")), Cursors.NoMove2D)
        Cursori.Add(LCase(trans("����������� �� �����������")), Cursors.NoMoveHoriz)
        Cursori.Add(LCase(trans("����������� �� ���������")), Cursors.NoMoveVert)
        Cursori.Add(LCase(trans("����������� ������")), Cursors.PanEast)
        Cursori.Add(LCase(trans("����������� ��")), Cursors.PanNE)
        Cursori.Add(LCase(trans("����������� �����")), Cursors.PanNorth)
        Cursori.Add(LCase(trans("����������� ��")), Cursors.PanNW)
        Cursori.Add(LCase(trans("����������� ��")), Cursors.PanSE)
        Cursori.Add(LCase(trans("����������� ��")), Cursors.PanSouth)
        Cursori.Add(LCase(trans("����������� ��")), Cursors.PanSW)
        Cursori.Add(LCase(trans("����������� �����")), Cursors.PanWest)
        Cursori.Add(LCase(trans("������������ �����")), Cursors.SizeAll)
        Cursori.Add(LCase(trans("������������ ����")), Cursors.SizeNESW)
        Cursori.Add(LCase(trans("������������ ��")), Cursors.SizeNS)
        Cursori.Add(LCase(trans("������������ ����")), Cursors.SizeNWSE)
        Cursori.Add(LCase(trans("������������ ��")), Cursors.SizeWE)
        Cursori.Add(LCase(trans("������� �����")), Cursors.UpArrow)
        Cursori.Add(LCase(trans("������������ �����������")), Cursors.VSplit)
        Cursori.Add(LCase(trans("��������")), Cursors.WaitCursor)

        ' �������� �������� ����������
        Docks.Clear()
        Docks.Add(LCase(trans("�������")), DockStyle.None)
        Docks.Add(LCase(trans("�� �����")), DockStyle.Top)
        Docks.Add(LCase(trans("�� ����")), DockStyle.Bottom)
        Docks.Add(LCase(trans("�����")), DockStyle.Left)
        Docks.Add(LCase(trans("������")), DockStyle.Right)
        Docks.Add(LCase(trans("�����")), DockStyle.Fill)

        ' �������� �������� ����� ������
        FlatStyles.Clear()
        FlatStyles.Add(LCase(trans("�������")), FlatStyle.Flat)
        FlatStyles.Add(LCase(trans("�������������")), FlatStyle.Popup)
        FlatStyles.Add(LCase(trans("�������")), FlatStyle.Standard)
        FlatStyles.Add(LCase(trans("���������")), FlatStyle.System)

        ' �������� �������� ������
        Dim ff As New Drawing.Text.InstalledFontCollection
        Fonts.Clear()
        For i = 0 To ff.Families.Length - 1
            Fonts.Add(LCase(ff.Families(i).Name), ff.Families(i).Name)
        Next

        ' �������� �������� ���������
        Aligns.Clear()
        Aligns.Add(LCase(trans("���� �����")), ContentAlignment.TopLeft)
        Aligns.Add(LCase(trans("����")), ContentAlignment.TopCenter)
        Aligns.Add(LCase(trans("���� ������")), ContentAlignment.TopRight)
        Aligns.Add(LCase(trans("�����")), ContentAlignment.MiddleLeft)
        Aligns.Add(LCase(trans("�����")), ContentAlignment.MiddleCenter)
        Aligns.Add(LCase(trans("������")), ContentAlignment.MiddleRight)
        Aligns.Add(LCase(trans("��� �����")), ContentAlignment.BottomLeft)
        Aligns.Add(LCase(trans("���")), ContentAlignment.BottomCenter)
        Aligns.Add(LCase(trans("��� ������")), ContentAlignment.BottomRight)

        ' �������� �������� ���������
        TextImages.Clear()
        TextImages.Add(LCase(trans("������")), TextImageRelation.Overlay)
        TextImages.Add(LCase(trans("�����")), TextImageRelation.TextBeforeImage)
        TextImages.Add(LCase(trans("������")), TextImageRelation.TextAboveImage)
        TextImages.Add(LCase(trans("�����")), TextImageRelation.ImageAboveText)
        TextImages.Add(LCase(trans("������")), TextImageRelation.ImageBeforeText)

        ' �������� �������� ����� �����
        BorderStyles.Clear()
        BorderStyles.Add(LCase(trans("�������")), BorderStyle.None)
        BorderStyles.Add(LCase(trans("�����")), BorderStyle.FixedSingle)
        BorderStyles.Add(LCase(trans("�����")), BorderStyle.Fixed3D)

        ' �������� �������� �������
        FixedPanels.Clear()
        FixedPanels.Add(LCase(trans("�������")), FixedPanel.None)
        FixedPanels.Add(LCase(trans("������1")), FixedPanel.Panel1)
        FixedPanels.Add(LCase(trans("������2")), FixedPanel.Panel2)

        ' �������� �������� ����������
        Orientations.Clear()
        Orientations.Add(LCase(trans("��������������")), Orientation.Horizontal)
        Orientations.Add(LCase(trans("������������")), Orientation.Vertical)

        ' �������� �������� �����
        Papks.Clear()
        If isHelp = False Then
            Papks.Add(LCase(trans("����� �������")), proj.pPath)
            Papks.Add(LCase(trans("������� �������")), proj.iPath)
        Else
            Papks.Add(LCase(trans("����� �������")), "")
            Papks.Add(LCase(trans("������� �������")), "")
        End If
        Papks.Add(MyZnak & LCase(trans("����")), Environment.GetFolderPath(Environment.SpecialFolder.Cookies) & "\")
        Papks.Add(MyZnak & LCase(trans("������� ����")), Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\")
        Papks.Add(MyZnak & LCase(trans("���������")), Environment.GetFolderPath(Environment.SpecialFolder.Favorites) & "\")
        Papks.Add(MyZnak & LCase(trans("������")), Environment.GetFolderPath(Environment.SpecialFolder.History) & "\")
        Papks.Add(MyZnak & LCase(trans("�������� ���")), Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\")
        Papks.Add(MyZnak & LCase("ApplicationData"), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\")
        Papks.Add(MyZnak & LCase(trans("��� ���������")), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\")
        Papks.Add(MyZnak & LCase(trans("��� ���������")), Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) & "\")
        Papks.Add(MyZnak & LCase(trans("��� ������")), Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) & "\")
        Papks.Add(MyZnak & LCase(trans("��� �������")), Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) & "\")
        Papks.Add(MyZnak & LCase("ProgramFiles"), Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\")
        Papks.Add(MyZnak & LCase(trans("����-���������")), Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\")
        Papks.Add(MyZnak & LCase(trans("�������� �����")), Environment.GetFolderPath(Environment.SpecialFolder.Recent) & "\")
        Papks.Add(MyZnak & LCase(trans("���������")), Environment.GetFolderPath(Environment.SpecialFolder.SendTo) & "\")
        Papks.Add(MyZnak & LCase(trans("����")), Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\")
        Papks.Add(MyZnak & LCase(trans("������������")), Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\")
        Papks.Add(MyZnak & LCase("System32"), Environment.GetFolderPath(Environment.SpecialFolder.System) & "\")
        Papks.Add(MyZnak & LCase("Windows"), IO.Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.System)) & "\")
        Papks.Add(MyZnak & LCase(trans("��������� �����")), IO.Path.GetTempPath & "\")
        Papks.Add(MyZnak & LCase(trans("��������� ����")), IO.Path.GetTempFileName)
        Papks.Add(MyZnak & LCase(trans("����� ������������")), Environment.GetEnvironmentVariable("USERPROFILE") & "\")
        Papks.Add(MyZnak & LCase(trans("��� ������������")), Environment.GetEnvironmentVariable("ALLUSERSPROFILE") & "\")
        If Environment.GetCommandLineArgs.Length > 0 Then
            Papks.Add(LCase(trans("��� �����")), Environment.GetCommandLineArgs(0))
        End If

        ' �������� �������� ������
        Dim a As New Keys
        Dim mass() As Object = {[Enum].GetNames(a.GetType()), [Enum].GetValues(a.GetType())}
        Keyz.Clear()
        For i = 0 To mass(0).Length - 1
            Keyz.Add(LCase(mass(0)(i)), mass(1)(i))
        Next

        ' �������� �������� ������� �������� �����
        DeskStyle.Clear()
        DeskStyle.Add(LCase(trans("������")), "0,1")
        DeskStyle.Add(LCase(trans("�� ������")), "1,0")
        DeskStyle.Add(LCase(trans("����������")), "2,0")

        ' �������� �������� ��� ���� ����� ��������
        TypeRegistry.Clear()
        TypeRegistry.Add(LCase(trans("�������� �����")), Microsoft.Win32.RegistryValueKind.Binary)
        TypeRegistry.Add(LCase(trans("�����")), Microsoft.Win32.RegistryValueKind.DWord)
        TypeRegistry.Add(LCase(trans("����������� ������")), Microsoft.Win32.RegistryValueKind.ExpandString)
        TypeRegistry.Add(LCase(trans("������������")), Microsoft.Win32.RegistryValueKind.MultiString)
        TypeRegistry.Add(LCase(trans("������� �����")), Microsoft.Win32.RegistryValueKind.QWord)
        TypeRegistry.Add(LCase(trans("������")), Microsoft.Win32.RegistryValueKind.String)

        ' �������� �������� ����������
        ScrollBarz.Clear()
        ScrollBarz.Add(LCase(trans("���")), ScrollBars.None)
        ScrollBarz.Add(LCase(trans("��������������")), ScrollBars.Horizontal)
        ScrollBarz.Add(LCase(trans("������������")), ScrollBars.Vertical)
        ScrollBarz.Add(LCase(trans("���")), ScrollBars.Both)

        ' �������� �������� ������������ ������ 
        TextPositions.Clear()
        TextPositions.Add(LCase(trans("�����")), HorizontalAlignment.Left)
        TextPositions.Add(LCase(trans("������")), HorizontalAlignment.Right)
        TextPositions.Add(LCase(trans("�����")), HorizontalAlignment.Center)

        ' �������� �������� ����� �����������
        DisplayStyles.Clear()
        DisplayStyles.Add(LCase(trans("���")), ToolStripItemDisplayStyle.None)
        DisplayStyles.Add(LCase(trans("�����")), ToolStripItemDisplayStyle.Text)
        DisplayStyles.Add(LCase(trans("�������")), ToolStripItemDisplayStyle.Image)
        DisplayStyles.Add(LCase(trans("������� � �����")), ToolStripItemDisplayStyle.ImageAndText)

        ' �������� �������� ����������� ������
        TextDirections.Clear()
        TextDirections.Add(LCase(trans("��������������")), ToolStripTextDirection.Horizontal)
        TextDirections.Add(LCase(trans("������������ 90")), ToolStripTextDirection.Vertical90)
        TextDirections.Add(LCase(trans("������������ 270")), ToolStripTextDirection.Vertical270)

        ' �������� �������� ������� ����������
        ReadyStates.Clear()
        ReadyStates.Add(LCase(trans("�������� ���")), WebBrowserReadyState.Uninitialized)
        ReadyStates.Add(LCase(trans("�������� �����������")), WebBrowserReadyState.Loading)
        ReadyStates.Add(LCase(trans("�������� ���������")), WebBrowserReadyState.Loaded)
        ReadyStates.Add(LCase(trans("��������������� ����������")), WebBrowserReadyState.Interactive)
        ReadyStates.Add(LCase(trans("�������� ��������� ������")), WebBrowserReadyState.Complete)

        ' �������� �������� ���������
        DocumentEncodings.Clear()
        DocumentEncodings.Add(LCase("Western"), LCase("Windows-1252"))
        DocumentEncodings.Add(LCase("ASCII"), LCase("us-ascii"))
        DocumentEncodings.Add(LCase("Central European (ISO)"), LCase("iso-8859-2"))
        DocumentEncodings.Add(LCase("Central European (Windows)"), LCase("Windows-1250"))
        DocumentEncodings.Add(LCase("Cyrillic (Windows)"), LCase("Windows-1251"))
        DocumentEncodings.Add(LCase("Greek (Windows)"), LCase("Windows-1253"))
        DocumentEncodings.Add(LCase("Turkish (Windows)"), LCase("Windows-1254"))
        DocumentEncodings.Add(LCase("Japanese (Shift-JIS)"), LCase("shift_jis"))
        DocumentEncodings.Add(LCase("Japanese (EUC)"), LCase("x-euc-jp"))
        DocumentEncodings.Add(LCase("Japanese (JIS)"), LCase("iso-2022-jp"))
        DocumentEncodings.Add(LCase("Baltic (Windows)"), LCase("Windows-1257"))
        DocumentEncodings.Add(LCase("Traditional Chinese (BIG5) "), LCase("big5"))
        DocumentEncodings.Add(LCase("Simplified Chinese (GB2312)"), LCase("gb2312"))
        DocumentEncodings.Add(LCase("Cyrillic (KOI8-R)"), LCase("koi8-r"))
        DocumentEncodings.Add(LCase("Korean (KSC5601)"), LCase("ks_c_5601"))
        DocumentEncodings.Add(LCase("Hebrew (ISO-logical)"), LCase("Windows-1255"))
        DocumentEncodings.Add(LCase("Hebrew (ISO-Visual)"), LCase("iso-8859-8"))
        DocumentEncodings.Add(LCase("Hebrew (DOS)"), LCase("dos-862"))
        DocumentEncodings.Add(LCase("Arabic (Windows)"), LCase("Windows-1256"))
        DocumentEncodings.Add(LCase("Arabic (DOS)"), LCase("dos-720"))
        DocumentEncodings.Add(LCase("Thai"), LCase("Windows-874"))
        DocumentEncodings.Add(LCase("Vietnamese"), LCase("Windows-1258"))
        DocumentEncodings.Add(LCase("Unicode UTF-8"), LCase("UTF-8"))
        DocumentEncodings.Add(LCase("Unicode UTF-7"), LCase("UTF-7"))
        DocumentEncodings.Add(LCase("Korean (ISO)"), LCase("ISO-2022-KR"))
        DocumentEncodings.Add(LCase("Simplified Chinese (HZ)"), LCase("HZ-GB-2312"))
        DocumentEncodings.Add(LCase("Baltic (ISO)"), LCase("iso-8869-4"))
        DocumentEncodings.Add(LCase("Cyrillic (ISO)"), LCase("iso_8859-5"))
        DocumentEncodings.Add(LCase("Greek (ISO)"), LCase("iso-8859-7"))
        DocumentEncodings.Add(LCase("Turkish (ISO)"), LCase("iso-8859-9"))

        ' �������� �������� ����������
        Refreshs.Clear()
        Refreshs.Add(LCase(trans("������")), WebBrowserRefreshOption.Normal)
        Refreshs.Add(LCase(trans("���������")), WebBrowserRefreshOption.Completely)
        Refreshs.Add(LCase(trans("���� ��������")), WebBrowserRefreshOption.IfExpired)

        ' �������� �������� ����� ����
        FormBorderStyles.Clear()
        FormBorderStyles.Add(LCase(trans("�������")), FormBorderStyle.None)
        FormBorderStyles.Add(LCase(trans("������������� �������")), FormBorderStyle.FixedSingle)
        FormBorderStyles.Add(LCase(trans("������������� ��������")), FormBorderStyle.Fixed3D)
        FormBorderStyles.Add(LCase(trans("������������� ����")), FormBorderStyle.FixedDialog)
        FormBorderStyles.Add(LCase(trans("����������")), FormBorderStyle.Sizable)
        FormBorderStyles.Add(LCase(trans("���� ������������")), FormBorderStyle.SizableToolWindow)
        FormBorderStyles.Add(LCase(trans("������������� ���� ������������")), FormBorderStyle.FixedToolWindow)

        ' �������� �������� ��������� �������
        StartPositions.Clear()
        StartPositions.Add(LCase(trans("�������� ������������")), FormStartPosition.Manual)
        StartPositions.Add(LCase(trans("�� ������ ������")), FormStartPosition.CenterScreen)
        StartPositions.Add(LCase(trans("������ �� ���������")), FormStartPosition.WindowsDefaultBounds)
        StartPositions.Add(LCase(trans("������������ �� ���������")), FormStartPosition.WindowsDefaultLocation)

        ' �������� �������� ������ ����
        WindowStates.Clear()
        WindowStates.Add(LCase(trans("����������")), FormWindowState.Normal)
        WindowStates.Add(LCase(trans("��������")), FormWindowState.Minimized)
        WindowStates.Add(LCase(trans("����������")), FormWindowState.Maximized)

        ' �������� �������� ��������� �������� ����
        Alignments.Clear()
        Alignments.Add(LCase(trans("������")), TabAlignment.Top)
        Alignments.Add(LCase(trans("�����")), TabAlignment.Bottom)
        Alignments.Add(LCase(trans("�����")), TabAlignment.Left)
        Alignments.Add(LCase(trans("������")), TabAlignment.Right)

        ' �������� �������� ����� ����� ������
        CellBorderStyles.Clear()
        CellBorderStyles.Add(LCase(trans("�������")), DataGridViewCellBorderStyle.None)
        CellBorderStyles.Add(LCase(trans("��������")), DataGridViewCellBorderStyle.Raised)
        CellBorderStyles.Add(LCase(trans("�������� ������������")), DataGridViewCellBorderStyle.RaisedVertical)
        CellBorderStyles.Add(LCase(trans("�������� ��������������")), DataGridViewCellBorderStyle.RaisedHorizontal)
        CellBorderStyles.Add(LCase(trans("�������")), DataGridViewCellBorderStyle.Single)
        CellBorderStyles.Add(LCase(trans("������� ������������")), DataGridViewCellBorderStyle.SingleVertical)
        CellBorderStyles.Add(LCase(trans("������� ��������������")), DataGridViewCellBorderStyle.SingleHorizontal)
        CellBorderStyles.Add(LCase(trans("��������")), DataGridViewCellBorderStyle.Sunken)
        CellBorderStyles.Add(LCase(trans("�������� ������������")), DataGridViewCellBorderStyle.SunkenVertical)
        CellBorderStyles.Add(LCase(trans("�������� ��������������")), DataGridViewCellBorderStyle.SunkenHorizontal)

        ' �������� �������� ������ ��������������
        EditModes.Clear()
        EditModes.Add(LCase(trans("���")), DataGridViewEditMode.EditProgrammatically)
        EditModes.Add(LCase(trans("��� ��������� ������")), DataGridViewEditMode.EditOnEnter)
        EditModes.Add(LCase(trans("�� ������� F2")), DataGridViewEditMode.EditOnF2)
        EditModes.Add(LCase(trans("�������")), DataGridViewEditMode.EditOnKeystroke)
        EditModes.Add(LCase(trans("������� � F2")), DataGridViewEditMode.EditOnKeystrokeOrF2)

        ' �������� �������� ������ ���������
        SelectionModes.Clear()
        SelectionModes.Add(LCase(trans("������")), DataGridViewSelectionMode.CellSelect)
        SelectionModes.Add(LCase(trans("������")), DataGridViewSelectionMode.FullRowSelect)
        SelectionModes.Add(LCase(trans("������ � ������")), DataGridViewSelectionMode.RowHeaderSelect)

        ' �������� �������� ������ ���������
        Filters.Clear()
        Filters.Add(LCase(trans("��� �������")), DataGridViewElementStates.None)
        Filters.Add(LCase(trans("������������ �� ������")), DataGridViewElementStates.Displayed)
        Filters.Add(LCase(trans("���������� �����")), DataGridViewElementStates.Selected)

        ' �������� �������� ������ ���������
        LinkBehaviors.Clear()
        LinkBehaviors.Add(LCase(trans("�� ���������")), LinkBehavior.SystemDefault)
        LinkBehaviors.Add(LCase(trans("������")), LinkBehavior.AlwaysUnderline)
        LinkBehaviors.Add(LCase(trans("��� ���������")), LinkBehavior.HoverUnderline)
        LinkBehaviors.Add(LCase(trans("�������")), LinkBehavior.NeverUnderline)

        ' �������� �������� ������ ���������
        MsgStyleButtons.Clear()
        MsgStyleButtons.Add(LCase(trans("�������� �������� ����������")), MsgBoxStyle.AbortRetryIgnore)
        MsgStyleButtons.Add(LCase(trans("�� �������")), MsgBoxStyle.MsgBoxHelp)
        MsgStyleButtons.Add(LCase(trans("�� ������")), MsgBoxStyle.OkCancel)
        MsgStyleButtons.Add(LCase(trans("��")), MsgBoxStyle.OkOnly)
        MsgStyleButtons.Add(LCase(trans("��������� ������")), MsgBoxStyle.RetryCancel)
        MsgStyleButtons.Add(LCase(trans("�� ���")), MsgBoxStyle.YesNo)
        MsgStyleButtons.Add(LCase(trans("�� ��� ������")), MsgBoxStyle.YesNoCancel)

        ' �������� �������� ���� ���������
        MsgStyleTypes.Clear()
        MsgStyleTypes.Add(LCase(trans("�������")), 0)
        MsgStyleTypes.Add(LCase(trans("������")), MsgBoxStyle.Critical)
        MsgStyleTypes.Add(LCase(trans("��������")), MsgBoxStyle.Exclamation)
        MsgStyleTypes.Add(LCase(trans("��������������")), MsgBoxStyle.Information)
        MsgStyleTypes.Add(LCase(trans("��������������")), MsgBoxStyle.Question)

        ' �������� �������� ���� ���� ������
        BdTypes.Clear()
        BdTypes.Add(LCase("Access"), "Access")
        BdTypes.Add(LCase("Excel"), "Excel")

        ' �������� �������� ������� ���� � ���������
        DateFormats.Clear()
        DateFormats.Add(LCase(trans("������� ����")), DateTimePickerFormat.Long)
        DateFormats.Add(LCase(trans("�������� ����")), DateTimePickerFormat.Short)
        DateFormats.Add(LCase(trans("�����")), DateTimePickerFormat.Time)
        DateFormats.Add(LCase(trans("�� ������")), DateTimePickerFormat.Custom)

        ' �������� �������� ����� �������
        TickStyles.Clear()
        TickStyles.Add(LCase(trans("�������")), Windows.Forms.TickStyle.TopLeft)
        TickStyles.Add(LCase(trans("������")), Windows.Forms.TickStyle.BottomRight)
        TickStyles.Add(LCase(trans("�������")), Windows.Forms.TickStyle.Both)
        TickStyles.Add(LCase(trans("�������")), Windows.Forms.TickStyle.None)

        ' �������� �������� ����� �������
        FileEncodings.Clear()
        FileEncodings.Add(LCase(trans("�� ���������")), System.Text.Encoding.Default)
        FileEncodings.Add(LCase("ASCII"), System.Text.Encoding.ASCII)
        FileEncodings.Add(LCase("BigEndian"), System.Text.Encoding.BigEndianUnicode)
        FileEncodings.Add(LCase(trans("������")), System.Text.Encoding.Unicode)
        FileEncodings.Add(LCase(trans("������") & "32"), System.Text.Encoding.UTF32)
        FileEncodings.Add(LCase(trans("������") & "7"), System.Text.Encoding.UTF7)
        FileEncodings.Add(LCase(trans("������") & "8"), System.Text.Encoding.UTF8)
        FileEncodings.Add("""" & "DOS-866" & """", System.Text.Encoding.GetEncoding(866))
        Dim encs() As EncodingInfo = System.Text.Encoding.GetEncodings
        For i = 0 To encs.Length - 1
            If FileEncodings.ContainsKey("""" & encs(i).Name & """") = False Then
                FileEncodings.Add("""" & encs(i).Name & """", encs(i).GetEncoding)
            End If
        Next

        ' �������� �������� ����� �������
        SizeModes.Clear()
        SizeModes.Add(LCase(trans("�� ���������")), PictureBoxSizeMode.Normal)
        SizeModes.Add(LCase(trans("����������")), PictureBoxSizeMode.StretchImage)
        SizeModes.Add(LCase(trans("����������")), PictureBoxSizeMode.AutoSize)
        SizeModes.Add(LCase(trans("�� ������")), PictureBoxSizeMode.CenterImage)
        SizeModes.Add(LCase(trans("����������������")), PictureBoxSizeMode.Zoom)

        ' �������� �������� ���� �����
        InputTypes.Clear()
        InputTypes.Add(LCase(trans("���")), trans("���"))
        InputTypes.Add(LCase(trans("������ �����")), trans("������ �����"))
        InputTypes.Add(LCase(trans("������ �����")), trans("������ �����"))
        InputTypes.Add(LCase(trans("������ ��������� �����")), trans("������ ��������� �����"))
        InputTypes.Add(LCase(trans("������ ����� � �����")), trans("������ ����� � �����"))
        InputTypes.Add(LCase(trans("������ ��������� ����� � �����")), trans("������ ��������� ����� � �����"))

        ' �������� �������� �������� ������-�������
        ClientServStates.Clear()
        ClientServStates.Add(LCase(trans("������")), 0)
        ClientServStates.Add(LCase(trans("��������������")), 1)
        ClientServStates.Add(LCase(trans("����������� ����")), 2)
        ClientServStates.Add(LCase(trans("���������� ����")), 3)
        ClientServStates.Add(LCase(trans("����������")), 4)
        ClientServStates.Add(LCase(trans("����������")), 5)
        ClientServStates.Add(LCase(trans("��������")), 6)

        ' �������� �������� ����� ������-�������
        ClientServerTypes.Clear()
        ClientServerTypes.Add(LCase(trans("������")), trans("������"))
        ClientServerTypes.Add(LCase(trans("������")), trans("������"))

        ' �������� �������� ����� ����������� �������
        ContentTypes.Clear()
        ContentTypes.Add((("""*/*""")), ("""*/*"""))
        ContentTypes.Add((("""application/x-www-form-urlencoded""")), ("""application/x-www-form-urlencoded"""))
        ContentTypes.Add((("""text/html""")), ("""text/html"""))
        ContentTypes.Add((("""text/plain""")), ("""text/plain"""))
        ContentTypes.Add((("""text/x-server-parsed-html""")), ("""text/x-server-parsed-html"""))
        ContentTypes.Add((("""text/css""")), ("""text/css"""))
        ContentTypes.Add((("""multipart/mixed""")), ("""multipart/mixed"""))
        ContentTypes.Add((("""multipart/alternative""")), ("""multipart/alternative"""))
        ContentTypes.Add((("""multipart/x-mixed-replace""")), ("""multipart/x-mixed-replace"""))
        ContentTypes.Add((("""multipart/form-data""")), ("""multipart/form-data"""))
        ContentTypes.Add((("""image/gif""")), ("""image/gif"""))
        ContentTypes.Add((("""image/jpeg""")), ("""image/jpeg"""))
        ContentTypes.Add((("""image/bmp""")), ("""image/bmp"""))
        ContentTypes.Add((("""audio/wav""")), ("""audio/wav"""))
        ContentTypes.Add((("""audio/midi""")), ("""audio/midi"""))
        ContentTypes.Add((("""audio/mpeg""")), ("""audio/mpeg"""))
        ContentTypes.Add((("""audio/x-wav""")), ("""audio/x-wav"""))
        ContentTypes.Add((("""video/avi""")), ("""video/avi"""))
        ContentTypes.Add((("""video/mpeg""")), ("""video/mpeg"""))
        ContentTypes.Add((("""application/msword""")), ("""application/msword"""))
        ContentTypes.Add((("""application/pdf""")), ("""application/pdf"""))
        ContentTypes.Add((("""application/rtf""")), ("""application/rtf"""))
        ContentTypes.Add((("""application/zip""")), ("""application/zip"""))
        ContentTypes.Add((("""application/x-shockwave-flash""")), ("""application/x-shockwave-flash"""))

        ' �������� �������� ������ �������
        HttpMethods.Clear()
        HttpMethods.Add(("GET"), """GET""")
        HttpMethods.Add(("POST"), """POST""")

        ' �������� �������� ����� ������ ��������
        StylesProgress.Clear()
        StylesProgress.Add(LCase(trans("�����")), ProgressBarStyle.Blocks)
        StylesProgress.Add(LCase(trans("�������������")), ProgressBarStyle.Continuous)
        StylesProgress.Add(LCase(trans("��������")), ProgressBarStyle.Marquee)

    End Sub
    Sub CreateHelpWords()
        ' ����������� ������� ������ ��� ������
        SetReadOnlys()

        Dim i, j, ind As Integer
        ' �������� ������ ���� ��������������� ����
        ReDim HWAnchors(Anchors.Count - 1) : Anchors.Keys.CopyTo(HWAnchors, 0)
        ReDim HWbkImStyles(bkImStyles.Count - 1) : bkImStyles.Keys.CopyTo(HWbkImStyles, 0)
        ReDim HWCursori(Cursori.Count - 1) : Cursori.Keys.CopyTo(HWCursori, 0)
        ReDim HWDocks(Docks.Count - 1) : Docks.Keys.CopyTo(HWDocks, 0)
        ReDim HWFlatStyles(FlatStyles.Count - 1) : FlatStyles.Keys.CopyTo(HWFlatStyles, 0)
        ReDim HWKeys(Keyz.Count - 1) : Keyz.Keys.CopyTo(HWKeys, 0)
        ReDim HWFonts(Fonts.Count - 1) : Fonts.Keys.CopyTo(HWFonts, 0)
        ReDim HWAligns(Aligns.Count - 1) : Aligns.Keys.CopyTo(HWAligns, 0)
        ReDim HWTextImages(TextImages.Count - 1) : TextImages.Keys.CopyTo(HWTextImages, 0)
        ReDim HWBorderStyles(BorderStyles.Count - 1) : BorderStyles.Keys.CopyTo(HWBorderStyles, 0)
        ReDim HWFixedPanels(FixedPanels.Count - 1) : FixedPanels.Keys.CopyTo(HWFixedPanels, 0)
        ReDim HWOrientations(Orientations.Count - 1) : Orientations.Keys.CopyTo(HWOrientations, 0)
        ReDim HWPapki(Papks.Count - 1) : Papks.Keys.CopyTo(HWPapki, 0)
        ReDim HWDeskStyle(DeskStyle.Count - 1) : DeskStyle.Keys.CopyTo(HWDeskStyle, 0)
        ReDim HWScrollBarz(ScrollBarz.Count - 1) : ScrollBarz.Keys.CopyTo(HWScrollBarz, 0)
        ReDim HWCols(Colors.GetKeyList.Count - 1) : Colors.GetKeyList.CopyTo(HWCols, 0)
        ReDim HWTypeRegistry(TypeRegistry.GetKeyList.Count - 1) : TypeRegistry.GetKeyList.CopyTo(HWTypeRegistry, 0)
        ReDim HWTextPositions(TextPositions.GetKeyList.Count - 1) : TextPositions.GetKeyList.CopyTo(HWTextPositions, 0)
        ReDim HWDisplayStyles(DisplayStyles.GetKeyList.Count - 1) : DisplayStyles.GetKeyList.CopyTo(HWDisplayStyles, 0)
        ReDim HWTextDirections(TextDirections.GetKeyList.Count - 1) : TextDirections.GetKeyList.CopyTo(HWTextDirections, 0)
        ReDim HWReadyStates(ReadyStates.GetKeyList.Count - 1) : ReadyStates.GetKeyList.CopyTo(HWReadyStates, 0)
        ReDim HWDocumentEncodings(DocumentEncodings.GetKeyList.Count - 1) : DocumentEncodings.GetKeyList.CopyTo(HWDocumentEncodings, 0)
        ReDim HWRefreshs(Refreshs.GetKeyList.Count - 1) : Refreshs.GetKeyList.CopyTo(HWRefreshs, 0)
        ReDim HWFormBorderStyles(FormBorderStyles.GetKeyList.Count - 1) : FormBorderStyles.GetKeyList.CopyTo(HWFormBorderStyles, 0)
        ReDim HWStartPositions(StartPositions.GetKeyList.Count - 1) : StartPositions.GetKeyList.CopyTo(HWStartPositions, 0)
        ReDim HWWindowStates(WindowStates.GetKeyList.Count - 1) : WindowStates.GetKeyList.CopyTo(HWWindowStates, 0)
        ReDim HWAlignments(Alignments.GetKeyList.Count - 1) : Alignments.GetKeyList.CopyTo(HWAlignments, 0)
        ReDim HWCellBorderStyles(CellBorderStyles.GetKeyList.Count - 1) : CellBorderStyles.GetKeyList.CopyTo(HWCellBorderStyles, 0)
        ReDim HWSelectionModes(SelectionModes.GetKeyList.Count - 1) : SelectionModes.GetKeyList.CopyTo(HWSelectionModes, 0)
        ReDim HWEditModes(EditModes.GetKeyList.Count - 1) : EditModes.GetKeyList.CopyTo(HWEditModes, 0)
        ReDim HWFilters(Filters.GetKeyList.Count - 1) : Filters.GetKeyList.CopyTo(HWFilters, 0)
        ReDim HWLinkBehaviors(LinkBehaviors.GetKeyList.Count - 1) : LinkBehaviors.GetKeyList.CopyTo(HWLinkBehaviors, 0)
        ReDim HWMsgStyleButtons(MsgStyleButtons.GetKeyList.Count - 1) : MsgStyleButtons.GetKeyList.CopyTo(HWMsgStyleButtons, 0)
        ReDim HWMsgStyleTypes(MsgStyleTypes.GetKeyList.Count - 1) : MsgStyleTypes.GetKeyList.CopyTo(HWMsgStyleTypes, 0)
        ReDim HWBdTypes(BdTypes.GetKeyList.Count - 1) : BdTypes.GetKeyList.CopyTo(HWBdTypes, 0)
        ReDim HWDateFormats(DateFormats.GetKeyList.Count - 1) : DateFormats.GetKeyList.CopyTo(HWDateFormats, 0)
        ReDim HWTickStyles(TickStyles.GetKeyList.Count - 1) : TickStyles.GetKeyList.CopyTo(HWTickStyles, 0)
        ReDim HWFileEncodings(FileEncodings.GetKeyList.Count - 1) : FileEncodings.GetKeyList.CopyTo(HWFileEncodings, 0)
        ReDim HWSizeModes(SizeModes.GetKeyList.Count - 1) : SizeModes.GetKeyList.CopyTo(HWSizeModes, 0)
        ReDim HWInputTypes(InputTypes.GetKeyList.Count - 1) : InputTypes.GetKeyList.CopyTo(HWInputTypes, 0)
        ReDim HWClientServStates(ClientServStates.GetKeyList.Count - 1) : ClientServStates.GetKeyList.CopyTo(HWClientServStates, 0)
        ReDim HWClientServerTypes(ClientServerTypes.GetKeyList.Count - 1) : ClientServerTypes.GetKeyList.CopyTo(HWClientServerTypes, 0)
        ReDim HWContentTypes(ContentTypes.GetKeyList.Count - 1) : ContentTypes.GetKeyList.CopyTo(HWContentTypes, 0)
        ReDim HWHttpMethods(HttpMethods.GetKeyList.Count - 1) : HttpMethods.GetKeyList.CopyTo(HWHttpMethods, 0)
        ReDim HWStylesProgress(StylesProgress.GetKeyList.Count - 1) : StylesProgress.GetKeyList.CopyTo(HWStylesProgress, 0)

        ' �����
        ind = 0 : ReDim Preserve HWDaNet(ind) : HWDaNet(ind) = trans("��")
        ind += 1 : ReDim Preserve HWDaNet(ind) : HWDaNet(ind) = trans("���")
        ' ����������
        ind = 0 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("�����")
        ind += 1 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("������")
        ind += 1 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("��������")
        ind += 1 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("���������1")
        ind += 1 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("���������2")
        ' ���������� ������
        ind = 0 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "640x480"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "800x600"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1024x768"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1152x864"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1280x768"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1280x800"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1280x960"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1280x1024"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1400x1050"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1440x900"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1600x900"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1600x1200"
        ind += 1 : ReDim Preserve HWDeskResolution(ind) : HWDeskResolution(ind) = "1920x1080"
        ' ������
        ind = 0 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("�������")
        ind += 1 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("��")
        ind += 1 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("���")
        ind += 1 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("���")
        ind += 1 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("������ ����� ������")

        ' ��� ��������������� �����
        ind = 0 : Dim Massivs2() As Object = {HWOthers, HWCols, HWPapki, HWKnopkiMishi, HWKeys, _
                                              HWAnchors, HWbkImStyles, HWCursori, HWDocks, HWFlatStyles, HWFonts, _
                                              HWAligns, HWTextImages, HWBorderStyles, HWFixedPanels, HWOrientations, _
                                              HWDeskStyle, HWDeskResolution, HWTypeRegistry, HWTextPositions, HWScrollBarz, _
                                              HWDisplayStyles, HWTextDirections, HWReadyStates, HWDocumentEncodings, _
                                              HWRefreshs, HWFormBorderStyles, HWStartPositions, HWWindowStates, _
                                              HWAlignments, HWCellBorderStyles, HWEditModes, HWSelectionModes, _
                                              HWFilters, HWLinkBehaviors, HWMsgStyleButtons, HWMsgStyleTypes, HWBdTypes, _
                                              HWDateFormats, HWTickStyles, HWFileEncodings, HWSizeModes, HWInputTypes, _
                                              HWClientServStates, HWClientServerTypes, HWContentTypes, HWHttpMethods, _
                                              HWStylesProgress}
        HWCategrs2 = Massivs2
        For i = 0 To Massivs2.Length - 1
            For j = 0 To Massivs2(i).Length - 1
                ReDim Preserve AllHW(ind) : AllHW(ind) = Massivs2(i)(j) : ind += 1
            Next
        Next
        ' ��� ��������������� ����� � ������� ��������
        ReDim AllHWUp(AllHW.Length - 1)
        For i = 0 To AllHW.Length - 1 : AllHWUp(i) = UCase(AllHW(i)) : Next

        CreateHWCategrs()
        If isDevelop And isRUN() = False Then CreateHWMenu()
    End Sub
    Sub CreateHWCategrs()
        ' ������ � HWCategrs ���� ��������� �������������� ����
        Dim tempHWCats() As String = { _
            trans("������"), trans("�����"), trans("�����"), trans("������ ����"), trans("�������") _
            , trans("��������"), trans("����� ����"), trans("�������"), trans("��������"), trans("����� ������"), trans("�����") _
            , trans("���������"), trans("����� � �������"), trans("������������� ������"), trans("����� �����"), trans("����������") _
            , trans("����� �������� �����"), trans("���������� ������"), trans("��� ����� �������"), trans("������������ ������"), trans("������ ���������") _
            , trans("����� �����������"), trans("����������� ������"), trans("������ ����������"), trans("���������") _
            , trans("�������� ��������"), trans("����� ����"), trans("��������� �������"), trans("������ ����") _
            , trans("��������� ��������"), trans("����� ����� ������"), trans("����� ��������������"), trans("����� ���������") _
            , trans("�������"), trans("����� �������������"), trans("������ ���������"), trans("��� ���������") _
            , trans("��� ���� ������"), trans("������ ���� ���������"), trans("����� �������") _
            , trans("��������� ������"), trans("����� �������"), trans("��� �����"), trans("������ ������ �������") _
            , trans("��� ������ �������"), trans("��� �����������"), trans("����� �������"), trans("����� ��������") _
        }
        HWCategrs = tempHWCats
        HWCategrsSort.Clear()
        If isHelp = False Then
            Dim i As Integer
            For i = 0 To HWCategrs.Length - 1
                HWCategrsSort.Add(HWCategrs(i), HWCategrs2(i))
            Next
        End If
    End Sub
    Sub CreateHWMenu()
        MainForm.CreateHWMenu()
    End Sub
    ' �������� ������� � ������� ��� �������
    Sub CreateArrays()
        Dim i, j As Integer
        ' �������� ������ �������������� �������
        Dim TempF() As String = { _
            trans("���"), trans("������"), trans("������3"), trans("�������"), trans("������"), _
            trans("�����"), trans("�������"), trans("�������"), _
            trans("��������"), trans("����������"), trans("����������"), _
            trans("����������"), trans("��������"), trans("��������10"), _
            trans("���������"), trans("��������� ��������"), trans("������� ���� (+/-)"), _
            trans("������������� (��/���)"), trans("��������� ����� (�� 1 �� ����������)")}
        DopFuns = TempF

        ' �������� ������ �������������� �������, �� ������ �� ������� ������ ������ - "���"
        ReDim DopFunsSimple(DopFuns.Length - 2)
        For i = 0 To DopFuns.Length - 2
            If DopFuns(i + 1).IndexOf(" (") <> -1 Then
                DopFunsSimple(i) = UCase(DopFuns(i + 1).Substring(0, DopFuns(i + 1).IndexOf(" (")))
            Else
                DopFunsSimple(i) = UCase(DopFuns(i + 1))
            End If
        Next

        ' �������� ������ �������������� ��������
        Dim TempO() As String = {"&    (" & transInfc("������� ������") & ")", _
            "+    (" & transInfc("�������") & ")", "-     (" & transInfc("�������") & ")", _
            "*    (" & transInfc("��������") & ")", "/    (" & transInfc("���������") & ")", _
            "\    (" & transInfc("��������� ������") & ")", "%    (" & transInfc("������� �������") & ")", _
            "^    (" & transInfc("���������� � �������") & ")"}
        Operations = TempO
        ReDim opers(Operations.Length - 1)
        For i = 0 To Operations.Length - 1
            opers(i) = Operations(i)
            If Operations(i).IndexOf(" (") <> -1 Then
                opers(i) = opers(i).Substring(0, opers(i).IndexOf(" ("))
            End If
            opers(i) = Trim(opers(i))
        Next
        ' �������� ������ ���������� ��������
        Dim TempU() As String = { _
            "=    (" & transInfc("���� �����") & ")", "<=>    (" & transInfc("����� c ������ ��������") & ")", _
            "<>   (" & transInfc("���� �������") & ")", _
            ">    (" & transInfc("���� ������") & ")", "<   (" & transInfc("���� ������") & ")", _
            ">=    (" & transInfc("������ ���� �����") & ")", "<=   (" & transInfc("������ ���� �����") & ")", _
            trans("_�"), trans("_���")}
        Dim ind As Integer = TempU.Length
        For i = 0 To Operations.Length - 1
            ReDim Preserve TempU(ind) : TempU(ind) = Operations(i) : ind += 1
        Next
        Usloviya = TempU
        ReDim uslovs(Usloviya.Length - 1)
        For i = 0 To Usloviya.Length - 1
            uslovs(i) = Usloviya(i)
            If Usloviya(i).IndexOf(" (") <> -1 Then
                uslovs(i) = uslovs(i).Substring(0, uslovs(i).IndexOf(" ("))
            End If
            uslovs(i) = Trim(uslovs(i))
        Next
        ReDims(uslovs) : uslovs(uslovs.Length - 1) = "And"
        ReDims(uslovs) : uslovs(uslovs.Length - 1) = "Or"

        ' ��������� ���� ���������� �� �����������
        Dim TempP0() As String = {"&"}
        Dim TempP1() As String = {"^"}
        Dim TempP2() As String = {"*", "/", "\", "%"}
        Dim TempP3() As String = {"+", "-"}
        Dim TempP4() As String = {"=", "<=>", "<", ">", "<>", "<=", ">=", "=<", "=>"}
        Dim TempP5() As String = {trans("_�"), trans("_���")}
        Dim TempP() As Object = {TempP0, TempP1, TempP2, TempP3, TempP4, TempP5}
        Prioritets = TempP
        ' �������� ������ ������ ����������������� ��������
        Dim TempOther() As String = {",", "(", ")", "[", "]", """"}
        othersSimb = TempOther
        ' �������� ������� ������ ����������������� ��������
        Dim mass() As Object = {uslovs, othersSimb}
        For i = 0 To mass.Length - 1
            For j = 0 To mass(i).Length - 1
                ReDim Preserve allSimb(i + j) : allSimb(i + j) = mass(i)(j)
            Next
        Next
        ' ������ �������� ���� VB ��� ��������� ������ � �����������
        VBKeyWords = New String() {"and", "or", "not", "nothing", "is", "isnot", _
                                   "dim", "as", "string", "object", "integer", "char", "new", "public", "private", _
                                   "class", "module", "array", "function", "event", "handles", "redim", "preserve", _
                                   "if", "then", "else", "elseif", "end", _
                                   "for", "to", "next", "step", "while", "do", "loop", "until"}
        ' �������� �������� ������ ��������� ��������
        noSimb = "[^\."
        For i = 0 To allSimb.Length - 1
            noSimb &= "\" & allSimb(i)
        Next : noSimb &= "]"

        ' �������� ������ ���� ��������� �������
        ind = 0 : Dim Massivs() As Object = {DopFunsSimple}
        For i = 0 To Massivs.Length - 1
            For j = 0 To Massivs(i).Length - 1
                ReDim Preserve AllFuncs(ind) : AllFuncs(ind) = Massivs(i)(j) : ind += 1
            Next
        Next
    End Sub

    ' �������� ��������
    Sub CreatePustishki(ByRef Pustishki As SortedList)
        Pustishki.Clear()
        Pustishki.Add("F", New Forms(True))
        Pustishki.Add("B", New Button(True))
        Pustishki.Add("P", New Panel(True))
        Pustishki.Add("M", New Memory(True))
        Pustishki.Add("DP", New DPanel(True))
        Pustishki.Add("TP", New TPage(True))
        Pustishki.Add("TPs", New TPages(True))
        Pustishki.Add("MM", New MMenu(True))
        Pustishki.Add("CM", New CMenu(True))
        Pustishki.Add("MMs", New MMenus(True))
        Pustishki.Add("Md", New Media(True))
        Pustishki.Add("A", New Audio(True))
        Pustishki.Add("T", New TextBoks(True))
        Pustishki.Add("CB", New CheckBoks(True))
        Pustishki.Add("RB", New RadioBut(True))
        Pustishki.Add("TPl", New TPanel(True))
        Pustishki.Add("W", New WBrowser(True))
        Pustishki.Add("Tl", New Table(True))
        Pustishki.Add("C", New ComboBoks(True))
        Pustishki.Add("L", New ListBoks(True))
        Pustishki.Add("CL", New CheckedList(True))
        Pustishki.Add("Lb", New Label(True))
        Pustishki.Add("LLb", New LinkLabel(True))
        Pustishki.Add("RT", New RichText(True))
        Pustishki.Add("CD", New ColorDialog(True))
        Pustishki.Add("FD", New FontDialog(True))
        Pustishki.Add("PD", New PathDialog(True))
        Pustishki.Add("SD", New SaveDialog(True))
        Pustishki.Add("OD", New OpenDialog(True))
        Pustishki.Add("PrD", New PrintDialog(True))
        Pustishki.Add("Tm", New Timer(True))
        Pustishki.Add("Pb", New PictureBoks(True))
        Pustishki.Add("�r", New Calendar(True))
        Pustishki.Add("Tb", New TrackBar(True))
        Pustishki.Add("Tr", New Trial(True))
        Pustishki.Add("CS", New ClientServer(True))
        Pustishki.Add("I", New Internet(True))
        Pustishki.Add("PrB", New ProgressBar(True))
    End Sub
    Sub CreateNewMyObjs(ByVal type As String, ByRef MyObjs As Object, ByVal isRun As Boolean, ByVal fromEng As Boolean)
        Select Case type
            Case "F" : MyObjs(MyObjs.Length - 1) = New Forms(True, , isRun, fromEng)
            Case "B" : MyObjs(MyObjs.Length - 1) = New Button(True, isRun, fromEng)
            Case "P" : MyObjs(MyObjs.Length - 1) = New Panel(True, isRun, fromEng)
            Case "M" : MyObjs(MyObjs.Length - 1) = New Memory(True, isRun, fromEng)
            Case "DP" : MyObjs(MyObjs.Length - 1) = New DPanel(True, isRun, fromEng)
            Case "TP" : MyObjs(MyObjs.Length - 1) = New TPage(True, isRun, fromEng)
            Case "TPs" : MyObjs(MyObjs.Length - 1) = New TPages(True, isRun, fromEng)
            Case "MM" : MyObjs(MyObjs.Length - 1) = New MMenu(True, isRun, fromEng)
            Case "CM" : MyObjs(MyObjs.Length - 1) = New CMenu(True, isRun, fromEng)
            Case "MMs" : MyObjs(MyObjs.Length - 1) = New MMenus(True, isRun, fromEng)
            Case "Md" : MyObjs(MyObjs.Length - 1) = New Media(True, isRun, fromEng)
            Case "A" : MyObjs(MyObjs.Length - 1) = New Audio(True, isRun, fromEng)
            Case "T" : MyObjs(MyObjs.Length - 1) = New TextBoks(True, isRun, fromEng)
            Case "CB" : MyObjs(MyObjs.Length - 1) = New CheckBoks(True, isRun, fromEng)
            Case "RB" : MyObjs(MyObjs.Length - 1) = New RadioBut(True, isRun, fromEng)
            Case "TPl" : MyObjs(MyObjs.Length - 1) = New TPanel(True, isRun, fromEng)
            Case "W" : MyObjs(MyObjs.Length - 1) = New WBrowser(True, isRun, fromEng)
            Case "Tl" : MyObjs(MyObjs.Length - 1) = New Table(True, isRun, fromEng)
            Case "C" : MyObjs(MyObjs.Length - 1) = New ComboBoks(True, isRun, fromEng)
            Case "L" : MyObjs(MyObjs.Length - 1) = New ListBoks(True, isRun, fromEng)
            Case "CL" : MyObjs(MyObjs.Length - 1) = New CheckedList(True, isRun, fromEng)
            Case "Lb" : MyObjs(MyObjs.Length - 1) = New Label(True, isRun, fromEng)
            Case "LLb" : MyObjs(MyObjs.Length - 1) = New LinkLabel(True, isRun, fromEng)
            Case "RT" : MyObjs(MyObjs.Length - 1) = New RichText(True, isRun, fromEng)
            Case "CD" : MyObjs(MyObjs.Length - 1) = New ColorDialog(True, isRun, fromEng)
            Case "FD" : MyObjs(MyObjs.Length - 1) = New FontDialog(True, isRun, fromEng)
            Case "PD" : MyObjs(MyObjs.Length - 1) = New PathDialog(True, isRun, fromEng)
            Case "SD" : MyObjs(MyObjs.Length - 1) = New SaveDialog(True, isRun, fromEng)
            Case "OD" : MyObjs(MyObjs.Length - 1) = New OpenDialog(True, isRun, fromEng)
            Case "PrD" : MyObjs(MyObjs.Length - 1) = New PrintDialog(True, isRun, fromEng)
            Case "Tm" : MyObjs(MyObjs.Length - 1) = New Timer(True, isRun, fromEng)
            Case "Pb" : MyObjs(MyObjs.Length - 1) = New PictureBoks(True, isRun, fromEng)
            Case "Cr" : MyObjs(MyObjs.Length - 1) = New Calendar(True, isRun, fromEng)
            Case "Tb" : MyObjs(MyObjs.Length - 1) = New TrackBar(True, isRun, fromEng)
            Case "Tr" : MyObjs(MyObjs.Length - 1) = New Trial(True, isRun, fromEng)
            Case "CS" : MyObjs(MyObjs.Length - 1) = New ClientServer(True, isRun, fromEng)
            Case "I" : MyObjs(MyObjs.Length - 1) = New Internet(True, isRun, fromEng)
            Case "PrB" : MyObjs(MyObjs.Length - 1) = New ProgressBar(True, isRun, fromEng)
        End Select
        ' ���� ��� ������� ������� ������, �� ��������� ��� ���, ����� ����������� ������� �� �������� � ����� �����
        If isDevelop And isRun = False Then SettingDevelop(MyObjs(MyObjs.Length - 1))
    End Sub
    Sub CreatePoleznie()
        PoleznieObjs = Nothing
        ' �������� ������� �������� ��������
        Dim ind As Integer = 0 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("�����"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("����� � �����"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("����������"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("�������"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("������"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("������� �������"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("�����"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("�������� ���������"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("����"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("����������� �����������"))
    End Sub
    ' ���� ������ USERCONTROL
    Function ObjectsInPaths(ByVal ListTypes() As String) As ArrayList
        ' ������� ���������� � ��������� ������. ����� �� �����, ����� ���������� ��� ����������
        Dim sourcs As New ArrayList
        ' ��������! �������� ��������� �������� � Peremens3.vb ���� �����!
        If Array.IndexOf(ListTypes, "ClientServer") <> -1 Then sourcs.Add(" """ & CompilPath & "ClientServer\*.vb""")
        If Array.IndexOf(ListTypes, "Internet") <> -1 Then sourcs.Add(" """ & CompilPath & "Internet\*.vb""")
        ' ��������! �������� ��������� �������� � Peremens3.vb ���� �����!
        Return sourcs
    End Function
    Sub SettingDevelop(ByVal MyObj As Object)
        ' ���� ��� ������� ������� ������, �� ��������� ��� ���, ����� ����������� ������� �� �������� � ����� �����
        If Iz.IsI(MyObj) Or Iz.IsCS(MyObj) Then
            MyObj.obj.isDevelop = True
        End If
    End Sub


    ' ���. ������
    Function Radical(ByVal vl As String) As Double
        Return Math.Sqrt(Val(vl.Replace(",", ".")))
    End Function
    Function Radical3(ByVal vl As String) As Double
        Return Math.Pow(Val(vl.Replace(",", ".")), 0.33333333333333331)
    End Function
    Function Square(ByVal vl As String) As Double
        Return Math.Pow(Val(vl.Replace(",", ".")), 2)
    End Function
    Function Absolute(ByVal vl As String) As Double
        Return Math.Abs(Val(vl.Replace(",", ".")))
    End Function
    Function Sine(ByVal vl As String) As Double
        Return Math.Sin(Val(vl.Replace(",", ".")))
    End Function
    Function Cosine(ByVal vl As String) As Double
        Return Math.Cos(Val(vl.Replace(",", ".")))
    End Function
    Function Tangent(ByVal vl As String) As Double
        Return Math.Tan(Val(vl.Replace(",", ".")))
    End Function
    Function ArcSine(ByVal vl As String) As Double
        Return Math.Asin(Val(vl.Replace(",", ".")))
    End Function
    Function ArcCosine(ByVal vl As String) As Double
        Return Math.Acos(Val(vl.Replace(",", ".")))
    End Function
    Function ArcTangent(ByVal vl As String) As Double
        Return Math.Atan(Val(vl.Replace(",", ".")))
    End Function
    Function Exhibitor(ByVal vl As String) As Double
        Return Math.Exp(Val(vl.Replace(",", ".")))
    End Function
    Function Logarithm(ByVal vl As String) As Double
        Return Math.Log(Val(vl.Replace(",", ".")))
    End Function
    Function Logarithm10(ByVal vl As String) As Double
        Return Math.Log10(Val(vl.Replace(",", ".")))
    End Function
    Function Round(ByVal vl As String) As Double
        Return Math.Round(Val(vl.Replace(",", ".")))
    End Function
    Function RoundMoney(ByVal vl As String) As Double
        Return Math.Round(Val(vl.Replace(",", ".")), 2)
    End Function
    Function ChangeSign(ByVal vl As String) As Double
        Return (-1 * Val(vl.Replace(",", ".")))
    End Function
    Dim rnd As New Random()
    Function RandomNumber(ByVal vl As String) As Integer
        Return rnd.Next(1, Val(vl.Replace(",", ".")))
    End Function
    Function Invert(ByVal vl As String) As String
        If Trim(vl) = "1" Or UCase(Trim(vl)) = UCase(Trim(trans("��"))) Then
            Return """" & trans("���") & """"
        ElseIf Trim(vl) = "0" Or UCase(Trim(vl)) = UCase(Trim(trans("���"))) Then
            Return """" & trans("��") & """"
        Else
            Return ""
        End If
    End Function


End Module