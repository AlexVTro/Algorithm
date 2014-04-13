Module Props
    Public Function GetProperty(ByVal MyObj As Object, ByVal prop As String, Optional ByVal word As String = "") As ErrString
        prop = UCase(prop)
        If MyObj Is Nothing Then Return New ErrString(Nothing)
        If MyObj.PropertysUp Is Nothing Then Return New ErrString(Nothing)
        If Array.IndexOf(MyObj.PropertysUp, prop) = -1 Then Return New ErrString(Nothing) ' Если нет такого свойства то выйти из функции
        Return GetPropertyMethod(MyObj, prop, word, Nothing)
    End Function
    Function GetPropertyMethod(ByVal MyObj As Object, ByVal prop As String, ByVal word As String, ByVal args() As String) As ErrString
        Dim oldprop As String = prop
        Dim vParamah As Boolean = False
        Dim obj As Object = MyObj.obj
        Dim es As ErrString, i As Integer
        prop = UCase(prop)
        ' Если свойство в дополнительных параметрах (напр. _Кнопка мыши)
        If MyObj.isRun Then
            If RunProj Is Nothing Then Exit Function
            If RunProj.Param.Paramy Is Nothing = False Then
                If RunProj.Param.ParamyUp.IndexOfKey(UCase(prop)) <> -1 Then vParamah = True
            End If
        End If
        ' Если нет такого свойства то выйти из функции
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
        ' заменить в аргументах мой знак на интеры
        If args Is Nothing = False Then
            For i = 0 To args.Length - 1
                args(i) = perevesti(args(i), True)
            Next
        End If

        If vParamah Then GoTo PropVParam
        Select Case prop

            ' OBJECTS
            Case UCase(trans("Имя")) : Return New ErrString(obj.Props.Name)
            Case UCase(trans("Фоновой рисунок")) : Return New ErrString(obj.Props.BackgroundImage)
            Case UCase(trans("Фоновой рисунок1")) : Return New ErrString(obj.Props.BackgroundImage1)
            Case UCase(trans("Фоновой рисунок2")) : Return New ErrString(obj.Props.BackgroundImage2)
            Case UCase(trans("Цвет")) : Return New ErrString(obj.Props.BackColor)
            Case UCase(trans("Цвет1")) : Return New ErrString(obj.Props.BackColor1)
            Case UCase(trans("Цвет2")) : Return New ErrString(obj.Props.BackColor2)
            Case UCase(trans("Номер")) : Return New ErrString(obj.Props.index)
            Case UCase(trans("Позиция")) : Return New ErrString(obj.Props.position)
            Case UCase(trans("Главная форма")) : Return New ErrString(obj.Props.mainform)
            Case UCase(trans("Всплывающее меню")) : Return New ErrString(obj.Props.ContextMenu)
            Case UCase(trans("Всплывающее меню1")) : Return New ErrString(obj.Props.ContextMenu1)
            Case UCase(trans("Всплывающее меню2")) : Return New ErrString(obj.Props.ContextMenu2)
            Case UCase(trans("Запретить закрытие")) : Return New ErrString(obj.Props.ForbidClose)
            Case UCase(trans("Привязка")) : Return New ErrString(obj.Props.Anchor)
            Case UCase(trans("АвтоТроеточие")) : Return New ErrString(obj.Props.AutoEllipsis)
            Case UCase(trans("Стиль фона")) : Return New ErrString(obj.Props.BackgroundImageLayout)
            Case UCase(trans("Стиль фона1")) : Return New ErrString(obj.Props.BackgroundImageLayout1)
            Case UCase(trans("Стиль фона2")) : Return New ErrString(obj.Props.BackgroundImageLayout2)
            Case UCase(trans("Стиль рисунка")) : Return New ErrString(obj.Props.SizeMode)
            Case UCase(trans("Курсор")) : Return New ErrString(obj.Props.Cursor)
            Case UCase(trans("Курсор1")) : Return New ErrString(obj.Props.Cursor1)
            Case UCase(trans("Курсор2")) : Return New ErrString(obj.Props.Cursor2)
            Case UCase(trans("Растяжка")) : Return New ErrString(obj.Props.Dock)
            Case UCase(trans("Работает")) : Return New ErrString(obj.Props.Enabled)
            Case UCase(trans("Стиль кнопки")) : Return New ErrString(obj.Props.FlatStyle)
            Case UCase(trans("Стиль рамки")) : Return New ErrString(obj.Props.BorderStyle)
            Case UCase(trans("Шрифт")) : Return New ErrString(obj.Props.FontFamily)
            Case UCase(trans("Шрифт жирный")) : Return New ErrString(obj.Props.FontBold)
            Case UCase(trans("Шрифт курсив")) : Return New ErrString(obj.Props.FontItalic)
            Case UCase(trans("Шрифт подчеркнутый")) : Return New ErrString(obj.Props.FontUnderline)
            Case UCase(trans("Шрифт зачеркнутый")) : Return New ErrString(obj.Props.FontStrikeout)
            Case UCase(trans("Шрифт размер")) : Return New ErrString(obj.Props.FontSize)
            Case UCase(trans("Цвет шрифта")) : Return New ErrString(obj.Props.ForeColor)
            Case UCase(trans("Рисунок")) : Return New ErrString(obj.Props.Image)
            Case UCase(trans("Положение рисунка")) : Return New ErrString(obj.Props.ImageAlign)
            Case UCase(trans("X")) : Return New ErrString(obj.Props.X)
            Case UCase(trans("Y")) : Return New ErrString(obj.Props.Y)
            Case UCase(trans("Максимальная ширина")) : Return New ErrString(obj.Props.MaximumWidth)
            Case UCase(trans("Максимальная вышина")) : Return New ErrString(obj.Props.MaximumHeight)
            Case UCase(trans("Минимальная ширина")) : Return New ErrString(obj.Props.MinimumWidth)
            Case UCase(trans("Минимальная вышина")) : Return New ErrString(obj.Props.MinimumHeight)
            Case UCase(trans("Поле слева")) : Return New ErrString(obj.Props.PaddingLeft)
            Case UCase(trans("Поле сверху")) : Return New ErrString(obj.Props.PaddingTop)
            Case UCase(trans("Поле справа")) : Return New ErrString(obj.Props.PaddingRight)
            Case UCase(trans("Поле снизу")) : Return New ErrString(obj.Props.PaddingBottom)
            Case UCase(trans("Ширина")) : Return New ErrString(obj.Props.Width)
            Case UCase(trans("Вышина")) : Return New ErrString(obj.Props.Height)
            Case UCase(trans("ТабНомер")) : Return New ErrString(obj.Props.TabIndex)
            Case UCase(trans("ТабСтоп")) : Return New ErrString(obj.Props.TabStop)
            Case UCase(trans("Вспомогательное поле")) : Return New ErrString(obj.Props.Tag)
            Case UCase(trans("Текст")) : Return New ErrString(obj.Props.Text)
            Case UCase(trans("Положение текста")) : Return New ErrString(obj.Props.TextAlign)
            Case UCase(trans("Расположение текста")) : Return New ErrString(obj.Props.TextPosition)
            Case UCase(trans("Текст и рисунок")) : Return New ErrString(obj.Props.TextImageRelation)
            Case UCase(trans("Видимый")) : Return New ErrString(obj.Props.Visible)
            Case UCase(trans("Прокрутка")) : Return New ErrString(obj.Props.Scroll)
            Case UCase(trans("Прокрутка1")) : Return New ErrString(obj.Props.Scroll1)
            Case UCase(trans("Прокрутка2")) : Return New ErrString(obj.Props.Scroll2)
            Case UCase(trans("Фиксированная часть")) : Return New ErrString(obj.Props.FixedPanel)
            Case UCase(trans("Фиксированный разделитель")) : Return New ErrString(obj.Props.FixedSplitter)
            Case UCase(trans("Ориентация")) : Return New ErrString(obj.Props.Orientation)
            Case UCase(trans("Панель1 скрыта")) : Return New ErrString(obj.Props.Panel1Collapsed)
            Case UCase(trans("Панель2 скрыта")) : Return New ErrString(obj.Props.Panel2Collapsed)
            Case UCase(trans("Ширина разделителя")) : Return New ErrString(obj.Props.SplitterWidth)
            Case UCase(trans("Расстояние разделителя")) : Return New ErrString(obj.Props.SplitterDistance)
            Case UCase(trans("Инкремент разделителя")) : Return New ErrString(obj.Props.SplitterIncrement)
            Case UCase(trans("Панель1 минимум")) : Return New ErrString(obj.Props.Panel1MinSize)
            Case UCase(trans("Панель2 минимум")) : Return New ErrString(obj.Props.Panel2MinSize)
            Case UCase(trans("В фокусе")) : Return New ErrString(obj.Props.Focused)
            Case UCase(trans("Тип")) : Return New ErrString(obj.Props.Type)
            Case UCase(trans("Файл проигрывания")) : Return New ErrString(obj.Props.FileNamePlayed)
            Case UCase(trans("Проигрывается")) : Return New ErrString(obj.Props.Played)
            Case UCase(trans("Громкость")) : Return New ErrString(obj.Props.Volume)
            Case UCase(trans("Баланс")) : Return New ErrString(obj.Props.Balance)
            Case UCase(trans("Звук отключен")) : Return New ErrString(obj.Props.Mute)
            Case UCase(trans("Скорость")) : Return New ErrString(obj.Props.Speed)
            Case UCase(trans("Длительность общая")) : Return New ErrString(obj.Props.TotalPosition)
            Case UCase(trans("Позиция проигрывания")) : Return New ErrString(obj.Props.PlayPosition)
            Case UCase(trans("Проигралось времени")) : Return New ErrString(obj.Props.PlayTime)
            Case UCase(trans("Длительность время")) : Return New ErrString(obj.Props.TotalTime)
            Case UCase(trans("Оригинальная вышина")) : Return New ErrString(obj.Props.OriginalHeight)
            Case UCase(trans("Оригинальная ширина")) : Return New ErrString(obj.Props.OriginalWidth)
            Case UCase(trans("Скрывать выделение")) : Return New ErrString(obj.Props.HideSelection)
            Case UCase(trans("Максимальная длинна")) : Return New ErrString(obj.Props.MaximumLength)
            Case UCase(trans("Многострочность")) : Return New ErrString(obj.Props.Multiline)
            Case UCase(trans("Символ пароля")) : Return New ErrString(obj.Props.PasswordChar)
            Case UCase(trans("Только для чтения")) : Return New ErrString(obj.Props.ReadOnly)
            Case UCase(trans("Полосы прокрутки")) : Return New ErrString(obj.Props.ScrollBars)
            Case UCase(trans("Перенос по словам")) : Return New ErrString(obj.Props.WordWrap)
            Case UCase(trans("Выделенный текст")) : Return New ErrString(obj.Props.SelectedText)
            Case UCase(trans("Начало выделения")) : Return New ErrString(obj.Props.SelectionStart)
            Case UCase(trans("Длинна выделения")) : Return New ErrString(obj.Props.SelectionLength)
            Case UCase(trans("Отмечено")) : Return New ErrString(obj.Props.Checked)
            Case UCase(trans("Ориентация инструментов")) : Return New ErrString(obj.Props.OrientationTools)
            Case UCase(trans("Расположен слева")) : Return New ErrString(obj.Props.Alignment)
            Case UCase(trans("Показывать подсказку")) : Return New ErrString(obj.Props.AutoToolTip)
            Case UCase(trans("Отметка по клику")) : Return New ErrString(obj.Props.CheckOnClick)
            Case UCase(trans("Стиль отображения")) : Return New ErrString(obj.Props.DisplayStyle)
            Case UCase(trans("Родительское меню")) : Return New ErrString(obj.Props.OwnerMenu)
            Case UCase(trans("Родительский пункт")) : Return New ErrString(obj.Props.OwnerItem)
            Case UCase(trans("Хозяин объект")) : Return New ErrString(obj.Props.OwnerObject)
            Case UCase(trans("Вложенное всплывающее меню")) : Return New ErrString(obj.Props.DropDown)
            Case UCase(trans("Рисунок растянут")) : Return New ErrString(obj.Props.ImageScaling)
            Case UCase(trans("Прозрачный цвет рисунка")) : Return New ErrString(obj.Props.ImageTransparentColor)
            Case UCase(trans("Горячая клавиша")) : Return New ErrString(obj.Props.ShortcutKeys)
            Case UCase(trans("Отображать горячие клавиши")) : Return New ErrString(obj.Props.ShowShortcutKeys)
            Case UCase(trans("Направление текста")) : Return New ErrString(obj.Props.TextDirection)
            Case UCase(trans("Всплывающая подсказка")) : Return New ErrString(obj.Props.ToolTipText)
            Case UCase(trans("Оконные кнопки и меню")) : Return New ErrString(obj.Props.ControlBox)
            Case UCase(trans("Стиль окна")) : Return New ErrString(obj.Props.FormBorderStyle)
            Case UCase(trans("Главное меню")) : Return New ErrString(obj.Props.MainMenuStrip)
            Case UCase(trans("Прозрачность")) : Return New ErrString(obj.Props.Opacity)
            Case UCase(trans("Показывать иконку")) : Return New ErrString(obj.Props.ShowIcon)
            Case UCase(trans("Отображать в панели задач")) : Return New ErrString(obj.Props.ShowInTaskbar)
            Case UCase(trans("Стартовая позиция")) : Return New ErrString(obj.Props.StartPosition)
            Case UCase(trans("Поверх всех окон")) : Return New ErrString(obj.Props.TopMost)
            Case UCase(trans("Статус окна")) : Return New ErrString(obj.Props.WindowState)
            Case UCase(trans("Прокрутка минимальная ширина")) : Return New ErrString(obj.Props.AutoScrollMinSizeWidth)
            Case UCase(trans("Прокрутка минимальная вышина")) : Return New ErrString(obj.Props.AutoScrollMinSizeHeight)
            Case UCase(trans("Прокручено по X")) : Return New ErrString(obj.Props.AutoScrollPositionX)
            Case UCase(trans("Прокручено по Y")) : Return New ErrString(obj.Props.AutoScrollPositionY)
            Case UCase(trans("Высота заголовка")) : Return New ErrString(obj.Props.CaptionHeight)
            Case UCase(trans("Иконка")) : Return New ErrString(obj.Props.Icon)
            Case UCase(trans("Прозрачный цвет")) : Return New ErrString(obj.Props.TransparentcyKey)
            Case UCase(trans("Положение закладок")) : Return New ErrString(obj.Props.TabAlignment)
            Case UCase(trans("Номер выделенной закладки")) : Return New ErrString(obj.Props.SelectedTabIndex)
            Case UCase(trans("Позиция выделенной закладки")) : Return New ErrString(obj.Props.SelectedTabPosition)
            Case UCase(trans("Поле по горизонтали")) : Return New ErrString(obj.Props.PaddingX)
            Case UCase(trans("Поле по вертикали")) : Return New ErrString(obj.Props.PaddingY)
            Case UCase(trans("Значение")) : Return New ErrString(obj.Props.Value)
            Case UCase(trans("Высота раскрывающегося списка")) : Return New ErrString(obj.Props.DropDownHeight)
            Case UCase(trans("Ширина раскрывающегося списка")) : Return New ErrString(obj.Props.DropDownWidth)
            Case UCase(trans("Список упрощенный")) : Return New ErrString(obj.Props.DropDownStyle)
            Case UCase(trans("Высота записей списка")) : Return New ErrString(obj.Props.ItemHeight)
            Case UCase(trans("Записи списка")) : Return New ErrString(obj.Props.Items)
            Case UCase(trans("Количество раскрывающихся записей")) : Return New ErrString(obj.Props.MaxDropDownItems)
            Case UCase(trans("Сортирован список")) : Return New ErrString(obj.Props.Sorted)
            Case UCase(trans("Список раскрыт")) : Return New ErrString(obj.Props.DroppedDown)
            Case UCase(trans("Номер выделенной записи")) : Return New ErrString(obj.Props.SelectedIndex)
            Case UCase(trans("Выделенная запись")) : Return New ErrString(obj.Props.SelectedItem)
            Case UCase(trans("Запись по номеру"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If obj.items.count <= args(0) Then es.err = Errors.noItems(prop, args(0)) : Return es
                Return New ErrString(obj.Props.ItemsItem(args))
            Case UCase(trans("Найти номер записи"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ItemsIndexOf(args))
            Case UCase(trans("Количество записей")) : Return New ErrString(obj.Props.ItemsCount)
            Case UCase(trans("Ширина колонок списка")) : Return New ErrString(obj.Props.ColumnWidth)
            Case UCase(trans("Горизонтальная прокрутка")) : Return New ErrString(obj.Props.HorizontalScrollBar)
            Case UCase(trans("Многоколонность")) : Return New ErrString(obj.Props.MultiColumn)
            Case UCase(trans("Позволить выбирать записи")) : Return New ErrString(obj.Props.SelectionModeList)
            Case UCase(trans("Номера отмеченых записей")) : Return New ErrString(obj.Props.CheckedIndices)
            Case UCase(trans("Отмеченные записи")) : Return New ErrString(obj.Props.CheckedItems)
            Case UCase(trans("Номера выделенных записей")) : Return New ErrString(obj.Props.SelectedIndices)
            Case UCase(trans("Выделенные записи")) : Return New ErrString(obj.Props.SelectedItems)
            Case UCase(trans("Цвет активной ссылки")) : Return New ErrString(obj.Props.ActiveLinkColor)
            Case UCase(trans("Цвет нерабочей ссылки")) : Return New ErrString(obj.Props.DisabledLinkColor)
            Case UCase(trans("Цвет ссылки")) : Return New ErrString(obj.Props.LinkColor)
            Case UCase(trans("Цвет посещенной ссылки")) : Return New ErrString(obj.Props.VisitedLinkColor)
            Case UCase(trans("Начало ссылки")) : Return New ErrString(obj.Props.LinkStart)
            Case UCase(trans("Длинна ссылки")) : Return New ErrString(obj.Props.LinkLength)
            Case UCase(trans("Стиль подчеркивания")) : Return New ErrString(obj.Props.LinkBehavior)
            Case UCase(trans("Ссылка посещена")) : Return New ErrString(obj.Props.LinkVisited)
            Case UCase(trans("Ссылка рабочая")) : Return New ErrString(obj.Props.LinkEnabled)
            Case UCase(trans("Переходить в интернет по ссылке")) : Return New ErrString(obj.Props.InternetLink)
            Case UCase(trans("Ссылка надписи")) : Return New ErrString(obj.Props.LinkName)
            Case UCase(trans("Подсвечивать ссылки")) : Return New ErrString(obj.Props.DetectUrls)
            Case UCase(trans("Позволить перенос выделенного")) : Return New ErrString(obj.Props.EnableAutoDragDrop)
            Case UCase(trans("Масштаб")) : Return New ErrString(obj.Props.ZoomFactor)
            Case UCase(trans("RTF код документа")) : Return New ErrString(obj.Props.Rtf)
            Case UCase(trans("Выделенный RTF")) : Return New ErrString(obj.Props.SelectedRtf)
            Case UCase(trans("Выделенное положение текста")) : Return New ErrString(obj.Props.SelectionAlignment)
            Case UCase(trans("Выделенный задний фон")) : Return New ErrString(obj.Props.SelectionBackColor)
            Case UCase(trans("Выделенный цвет текста")) : Return New ErrString(obj.Props.SelectionColor)
            Case UCase(trans("Выделенный размер красной строки")) : Return New ErrString(obj.Props.SelectionHangingIndent)
            Case UCase(trans("Выделенный отступ слева")) : Return New ErrString(obj.Props.SelectionIndent)
            Case UCase(trans("Выделенный отступ справа")) : Return New ErrString(obj.Props.SelectionRightIndent)
            Case UCase(trans("Выделенный имеет маркер")) : Return New ErrString(obj.Props.SelectionBullet)
            Case UCase(trans("Выделенное вертикальное смещение")) : Return New ErrString(obj.Props.SelectionCharOffset)
            Case UCase(trans("Выделенный шрифт")) : Return New ErrString(obj.Props.SelectionFontFamily)
            Case UCase(trans("Выделенный шрифт жирный")) : Return New ErrString(obj.Props.SelectionFontBold)
            Case UCase(trans("Выделенный шрифт курсив")) : Return New ErrString(obj.Props.SelectionFontItalic)
            Case UCase(trans("Выделенный шрифт подчеркнутый")) : Return New ErrString(obj.Props.SelectionFontUnderline)
            Case UCase(trans("Выделенный шрифт зачеркнутый")) : Return New ErrString(obj.Props.SelectionFontStrikeout)
            Case UCase(trans("Выделенный шрифт размер")) : Return New ErrString(obj.Props.SelectionFontSize)
            Case UCase(trans("Выделенный текст заблокирован")) : Return New ErrString(obj.Props.SelectionProtected)
            Case UCase(trans("Выбранный цвет")) : Return New ErrString(obj.Props.DialogColor)
            Case UCase(trans("Была нажата отмена")) : Return New ErrString(obj.Props.WasCancel)
            Case UCase(trans("Позволить выбирать цвет")) : Return New ErrString(obj.Props.ShowColor)
            Case UCase(trans("Позволить выбирать подчеркивания")) : Return New ErrString(obj.Props.ShowEffects)
            Case UCase(trans("Надпись в окне")) : Return New ErrString(obj.Props.Description)
            Case UCase(trans("Выбранная папка")) : Return New ErrString(obj.Props.SelectedPath)
            Case UCase(trans("Добавлять расширение файлу")) : Return New ErrString(obj.Props.DefaultExt)
            Case UCase(trans("Проверять наличие файла")) : Return New ErrString(obj.Props.CheckFileExists)
            Case UCase(trans("Проверять наличие папки")) : Return New ErrString(obj.Props.CheckPathExists)
            Case UCase(trans("Имя файла")) : Return New ErrString(obj.Props.FileName)
            Case UCase(trans("Фильтр файлов")) : Return New ErrString(obj.Props.Filter)
            Case UCase(trans("Номер фильтра")) : Return New ErrString(obj.Props.FilterIndex)
            Case UCase(trans("Начальная папка")) : Return New ErrString(obj.Props.InitialDirectory)
            Case UCase(trans("Заголовок")) : Return New ErrString(obj.Props.Title)
            Case UCase(trans("Выбор нескольких файлов")) : Return New ErrString(obj.Props.MultiSelectFiles)
            Case UCase(trans("Текст на печать")) : Return New ErrString(obj.Props.PrintText)
            Case UCase(trans("Документ на печать")) : Return New ErrString(obj.Props.PrintDocument)
            Case UCase(trans("Таблица на печать")) : Return New ErrString(obj.Props.PrintTable)
            Case UCase(trans("Объект на печать")) : Return New ErrString(obj.Props.PrintObject)
            Case UCase(trans("Рисунок на печать")) : Return New ErrString(obj.Props.PrintPicture)
            Case UCase(trans("Таблица в центре")) : Return New ErrString(obj.Props.TableOnCenter)
            Case UCase(trans("Интервал отсчета")) : Return New ErrString(obj.Props.Interval)
            Case UCase(trans("Прошло интервалов")) : Return New ErrString(obj.Props.IntervalCount)
            Case UCase(trans("Формат даты")) : Return New ErrString(obj.Props.CalendarDateFormat)
            Case UCase(trans("Формат даты по выбору")) : Return New ErrString(obj.Props.CustomDateFormat)
            Case UCase(trans("Кнопки вверх вниз")) : Return New ErrString(obj.Props.ShowUpDown)
            Case UCase(trans("Выбранная дата")) : Return New ErrString(obj.Props.SelectedDate)
            Case UCase(trans("Сдвиг большой")) : Return New ErrString(obj.Props.LargeChange)
            Case UCase(trans("Сдвиг малый")) : Return New ErrString(obj.Props.SmallChange)
            Case UCase(trans("Максимум")) : Return New ErrString(obj.Props.Maximum)
            Case UCase(trans("Минимум")) : Return New ErrString(obj.Props.Minimum)
            Case UCase(trans("Стиль бегунка")) : Return New ErrString(obj.Props.TickStyle)
            Case UCase(trans("Частота отметок")) : Return New ErrString(obj.Props.TickFrequency)
            Case UCase(trans("Отображать в трее")) : Return New ErrString(obj.Props.ShowInTray)
            Case UCase(trans("Подсказка")) : Return New ErrString(obj.Props.ToolTip)
            Case UCase(trans("Добавить в автозагрузку")) : Return New ErrString(obj.Props.AutoRun)
            Case UCase(trans("Разрешить запуск копий")) : Return New ErrString(obj.Props.AllowRunCopies)
            Case UCase(trans("Разрешить вводить")) : Return New ErrString(obj.Props.AllowInput)
            Case UCase(trans("Стиль загрузки")) : Return New ErrString(obj.Props.StyleProgress)
            Case UCase(trans("Скорость анимации")) : Return New ErrString(obj.Props.MarqueeAnimationSpeed)
            Case UCase(trans("Шаг загрузки")) : Return New ErrString(obj.Props.StepProgress)
            Case UCase(trans("Справа налево")) : Return New ErrString(obj.Props.RightToLeftLayout)
            Case UCase(trans("Запретить минимизировать")) : Return New ErrString(obj.Props.ForbidMinimize)
            Case UCase(trans("Запретить разворачивать")) : Return New ErrString(obj.Props.ForbidMaximize)
            Case UCase(trans("Ассоциировать с расширениями")) : Return New ErrString(obj.Props.AssociateWithExtensions)
            Case UCase(trans("Ассоциированый принятый файл")) : Return New ErrString(obj.Props.AssociationPassedFile)
            Case UCase(trans("Страница начала печати")) : Return New ErrString(obj.Props.FromPage)
            Case UCase(trans("Страница конца печати")) : Return New ErrString(obj.Props.ToPage)
            Case UCase(trans("Число копий")) : Return New ErrString(obj.Props.Copies)
            Case UCase(trans("Ширина столбцов")) : Return New ErrString(obj.Props.WidthOfColumns)
            Case UCase(trans("Вышина строк")) : Return New ErrString(obj.Props.HeightOfRows)
            Case UCase(trans("На весь экран")) : Return New ErrString(obj.Props.OnFullScreen)


                ' webbrowser
            Case UCase(trans("Переходить по сссылкам")) : Return New ErrString(obj.Props.AllowNavigation)
            Case UCase(trans("Разрешить перетаскивания")) : Return New ErrString(obj.Props.AllowWebBrowserDrop)
            Case UCase(trans("Назад возможно")) : Return New ErrString(obj.Props.CanGoBack)
            Case UCase(trans("Вперед возможно")) : Return New ErrString(obj.Props.CanGoForward)
            Case UCase(trans("Текст страницы")) : Return New ErrString(obj.Props.DocumentText)
            Case UCase(trans("Заголовок страницы")) : Return New ErrString(obj.Props.DocumentTitle)
            Case UCase(trans("Тип страницы")) : Return New ErrString(obj.Props.DocumentType)
            Case UCase(trans("Браузер занят")) : Return New ErrString(obj.Props.isBusy)
            Case UCase(trans("Браузер offline")) : Return New ErrString(obj.Props.isOffline)
            Case UCase(trans("Всплывающее меню браузера")) : Return New ErrString(obj.Props.isWebBrowserContextMunuEnabled)
            Case UCase(trans("Статус готовности")) : Return New ErrString(obj.Props.ReadyState)
            Case UCase(trans("Статусная строка")) : Return New ErrString(obj.Props.StatusText)
            Case UCase(trans("Отображать ошибки сценариев")) : Return New ErrString(obj.Props.ScriptErrorsSuppressed)
            Case UCase(trans("Полосы прокрутки активны")) : Return New ErrString(obj.Props.ScrollBarsEnabled)
            Case UCase(trans("Ссылка")) : Return New ErrString(obj.Props.Url)
            Case UCase(trans("Горячие клавиши работают")) : Return New ErrString(obj.Props.WebBrowserShortcutsEnabled)
            Case UCase(trans("Кодировка")) : Return New ErrString(obj.Props.DocumentEncoding)
            Case UCase(trans("Кодировка по умолчанию")) : Return New ErrString(obj.Props.EncodingDefault)
            Case UCase(trans("Куки")) : Return New ErrString(obj.Props.Cookie)
            Case UCase(trans("Открытие ссылок нового окна")) : Return New ErrString(obj.Props.OpenNewWindowLink)

                ' Триал
            Case UCase(trans("Текст кнопки")) : Return New ErrString(obj.Props.TextButton)
            Case UCase(trans("Текст поля")) : Return New ErrString(obj.Props.TextField)
            Case UCase(trans("Сообщение успешной активации")) : Return New ErrString(obj.Props.MessageValid)
            Case UCase(trans("Сообщение неудачной активации")) : Return New ErrString(obj.Props.MessageInValid)
            Case UCase(trans("ID пользователя")) : Return New ErrString(obj.Props.IdUser)
            Case UCase(trans("ID программы")) : Return New ErrString(obj.Props.IdProgram)
            Case UCase(trans("ID в реестре")) : Return New ErrString(obj.Props.IdRegistryProgram)
            Case UCase(trans("Ключ шифрования")) : Return New ErrString(obj.Props.KeyEncryption)
            Case UCase(trans("Дней триала всего")) : Return New ErrString(obj.Props.DaysAll)
            Case UCase(trans("Дней триала осталось")) : Return New ErrString(obj.Props.DaysLeft)
            Case UCase(trans("Активирована")) : Return New ErrString(obj.Props.Activation)
            Case UCase(trans("Примечание")) : Return New ErrString(obj.Props.Remark)
            Case UCase(trans("Триальный период запущен")) : Return New ErrString(obj.Props.TrialStarted)
            Case UCase(trans("Ключ активации выдать"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.KeyIssue(args))
            Case UCase(trans("Ключ активации проверить"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.KeyValidation(args))

                ' ClientServer
            Case UCase(trans("Файл отправляется")) : Return New ErrString(obj.Props.FileIsSent)
            Case UCase(trans("Скрыть отправку файлов")) : Return New ErrString(obj.Props.HideSendingFiles)
            Case UCase(trans("Скрыть отправку текста")) : Return New ErrString(obj.Props.HideSendingText)
            Case UCase(trans("Скрыть список")) : Return New ErrString(obj.Props.HideComboBox)
            Case UCase(trans("Обозначение команд")) : Return New ErrString(obj.Props.CommandSymbol)
            Case UCase(trans("Принятая команда")) : Return New ErrString(obj.Props.ReceivedCommand)
            Case UCase(trans("Принятый текст")) : Return New ErrString(obj.Props.ReceivedText)
            Case UCase(trans("Принятый файл")) : Return New ErrString(obj.Props.ReceivedFile)
            Case UCase(trans("Отправленная команда")) : Return New ErrString(obj.Props.SentCommand)
            Case UCase(trans("Отправленый текст")) : Return New ErrString(obj.Props.SentText)
            Case UCase(trans("Отправленый файл")) : Return New ErrString(obj.Props.SentFile)
            Case UCase(trans("Имя в сети")) : Return New ErrString(obj.Props.NameInNetwork)
            Case UCase(trans("IP для соединения")) : Return New ErrString(obj.Props.RemoteHost)
            Case UCase(trans("Порт для соединения")) : Return New ErrString(obj.Props.RemotePort)
            Case UCase(trans("Папка для загрузок")) : Return New ErrString(obj.Props.PathForDownloads)
            Case UCase(trans("Тип клиент сервера")) : Return New ErrString(obj.Props.ClientServerType)
            Case UCase(trans("Имена клиентов")) : Return New ErrString(obj.Props.ClientsNames)
            Case UCase(trans("Текст поля ввода")) : Return New ErrString(obj.Props.TextBoxString)
            Case UCase(trans("Текст поля лога")) : Return New ErrString(obj.Props.TextBoxLog)
            Case UCase(trans("Ip клиентов")) : Return New ErrString(obj.Props.ClientsIPs)
            Case UCase(trans("Ip клиента"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.GetClientIp(args))

                ' internet
            Case UCase(trans("Удерживать соединение")) : Return New ErrString(obj.Props.KeepAlive)
            Case UCase(trans("Автоматически перенаправляться")) : Return New ErrString(obj.Props.AllowAutoRedirect)
            Case UCase(trans("Ссылка запроса")) : Return New ErrString(obj.Props.UrlToGo)
            Case UCase(trans("Ссылка откуда пришли")) : Return New ErrString(obj.Props.UrlReferer)
            Case UCase(trans("Ссылка перенаправления")) : Return New ErrString(obj.Props.UrlRedirect)
            Case UCase(trans("Тип браузера")) : Return New ErrString(obj.Props.UserAgent)
            Case UCase(trans("Принимать")) : Return New ErrString(obj.Props.Accept)
            Case UCase(trans("Прокси IP")) : Return New ErrString(obj.Props.ProxyIp)
            Case UCase(trans("Прокси порт")) : Return New ErrString(obj.Props.ProxyPort)
            Case UCase(trans("Кодировка страницы")) : Return New ErrString(obj.Props.EncodingPage)
            Case UCase(trans("Язык страницы")) : Return New ErrString(obj.Props.LanguagePage)
            Case UCase(trans("Содержимое запроса")) : Return New ErrString(obj.Props.ContentQuery)
            Case UCase(trans("Тип содержимого")) : Return New ErrString(obj.Props.ContentType)
            Case UCase(trans("Длинна содержимого")) : Return New ErrString(obj.Props.ContentLength)
            Case UCase(trans("Метод запроса")) : Return New ErrString(obj.Props.HttpMethod)
            Case UCase(trans("Код результата")) : Return New ErrString(obj.Props.ResultCode)
            Case UCase(trans("Таймаут")) : Return New ErrString(obj.Props.TimeOut)
            Case UCase(trans("Время задержки")) : Return New ErrString(obj.Props.TimeDelay)
            Case UCase(trans("Заголовки запроса")) : Return New ErrString(obj.Props.Headers)
            Case UCase(trans("Куки запросов")) : Return New ErrString(obj.Props.CookiesQueries)
            Case UCase(trans("Результат запроса")) : Return New ErrString(obj.Props.ResultQuery)
            Case UCase(trans("Размер буфера")) : Return New ErrString(obj.Props.BufferSize)
            Case UCase(trans("Скачивается файл")) : Return New ErrString(obj.Props.FileDownloading)
            Case UCase(trans("Скачка пауза")) : Return New ErrString(obj.Props.DownloadPause)
            Case UCase(trans("Наличие соединения")) : Return New ErrString(obj.Props.CheckConnect)



                ' table
            Case UCase(trans("Позволить добавлять строки")) : Return New ErrString(obj.Props.AllowUserToAddRows)
            Case UCase(trans("Позволить удалять строки")) : Return New ErrString(obj.Props.AllowUserToDeleteRows)
            Case UCase(trans("Позволить переставлять столбцы")) : Return New ErrString(obj.Props.AllowUserToOrderColumns)
            Case UCase(trans("Позволить растягивать столбцы")) : Return New ErrString(obj.Props.AllowUserToResizeColumns)
            Case UCase(trans("Позволить растягивать строки")) : Return New ErrString(obj.Props.AllowUserToResizeRows)
            Case UCase(trans("Стиль рамки ячейки")) : Return New ErrString(obj.Props.CellBorderStyle)
            Case UCase(trans("Отображать заголовки столбцов")) : Return New ErrString(obj.Props.ColumnHeadersVisible)
            Case UCase(trans("Отображать специальный столбец")) : Return New ErrString(obj.Props.RowHeadersVisible)
            Case UCase(trans("Вышина заголовков столбцов")) : Return New ErrString(obj.Props.ColumnHeadersHeight)
            Case UCase(trans("Столбцы")) : Return New ErrString(obj.Props.Columns)
            Case UCase(trans("Строки")) : Return New ErrString(obj.Props.Rows)
            Case UCase(trans("Цвет фона ячеек")) : Return New ErrString(obj.Props.DefaultCellStyleBackColor)
            Case UCase(trans("Цвет фона выделенных ячеек")) : Return New ErrString(obj.Props.DefaultCellStyleSelectionBackColor)
            Case UCase(trans("Цвет шрифта ячеек")) : Return New ErrString(obj.Props.DefaultCellStyleForeColor)
            Case UCase(trans("Цвет шрифта выделенных ячеек")) : Return New ErrString(obj.Props.DefaultCellStyleSelectionForeColor)
            Case UCase(trans("Режим редактирования")) : Return New ErrString(obj.Props.EditMode)
            Case UCase(trans("Цвет сетки")) : Return New ErrString(obj.Props.GridColor)
            Case UCase(trans("Выбор нескольких ячеек")) : Return New ErrString(obj.Props.MultiSelect)
            Case UCase(trans("Выбор нескольких записей")) : Return New ErrString(obj.Props.MultiSelectItems)
            Case UCase(trans("Только для чтения таблица")) : Return New ErrString(obj.Props.ReadOnlyTable)
            Case UCase(trans("Режим выделения")) : Return New ErrString(obj.Props.SelectionMode)
            Case UCase(trans("Номера выделенных строк")) : Return New ErrString(obj.Props.SelectedRows)
            Case UCase(trans("Номера выделенных столбцов")) : Return New ErrString(obj.Props.SelectedColumns)
            Case UCase(trans("Количество строк таблицы")) : Return New ErrString(obj.Props.RowsCount)
            Case UCase(trans("Количество столбцов")) : Return New ErrString(obj.Props.ColumnsCount)
            Case UCase(trans("Количество выделенных строк")) : Return New ErrString(obj.Props.SelectedRowsCount)
            Case UCase(trans("Количество выделенных столбцов")) : Return New ErrString(obj.Props.SelectedColumnsCount)
            Case UCase(trans("Значение ячейки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(GetArguments(prop, MyObj)(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(GetArguments(prop, MyObj)(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(GetArguments(prop, MyObj)(0), args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(GetArguments(prop, MyObj)(1), args(1)) : Return es
                Return New ErrString(obj.Props.ItemValue(args))
            Case UCase(trans("Ячейка выделена"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(prop, args(1)) : Return es
                Return New ErrString(obj.Props.ItemSelected(args))
            Case UCase(trans("Строка только для чтения"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                Return New ErrString(obj.Props.RowsReadOnly(args))
            Case UCase(trans("Столбец только для чтения"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                Return New ErrString(obj.Props.ColumnReadOnly(args))
            Case UCase(trans("Ячейка только для чтения"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(prop, args(1)) : Return es
                Return New ErrString(obj.Props.ItemReadOnly(args))
            Case UCase(trans("Ширина столбца"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                Return New ErrString(obj.Props.ColumnsWidth(args))
            Case UCase(trans("Вышина строки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                Return New ErrString(obj.Props.RowsHeight(args))
            Case UCase(trans("Номер первой строки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = NikakoiEsli(args(0))
                Dim ind As Integer = Filters.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWFilters) : Return es
                Return New ErrString(obj.Props.GetFirstRow(args))
            Case UCase(trans("Номер последней строки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = NikakoiEsli(args(0))
                Dim ind As Integer = Filters.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWFilters) : Return es
                Return New ErrString(obj.Props.GetLastRow(args))
            Case UCase(trans("Номер следующей строки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                args(1) = NikakoiEsli(args(1))
                Dim ind As Integer = Filters.IndexOfKey(LCase(args(1)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(1), HWFilters) : Return es
                Return New ErrString(obj.Props.GetNextRow(args))
            Case UCase(trans("Номер предыдущей строки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                args(1) = NikakoiEsli(args(1))
                Dim ind As Integer = Filters.IndexOfKey(LCase(args(1)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(1), HWFilters) : Return es
                Return New ErrString(obj.Props.GetPreviousRow(args))
            Case UCase(trans("Значение по координатам"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.HitTest(args))
            Case UCase(trans("Номер строки по координатам"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.HitTestRow(args))
            Case UCase(trans("Номер столбца по координатам"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.HitTestColumn(args))
            Case UCase(trans("Значение выделеных ячеек"))
                Return New ErrString(obj.Props.SelectedItemsValue())
            Case UCase(trans("Поиск в таблице"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 5 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(3)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(4)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.SearchInTable(args))
            Case UCase(trans("Поиск в выделеных ячейках"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.SearchInSelectedCells(args))


                ' PATH and FILES
            Case UCase(MyZnak & trans("Скрытый"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Hider(args))
            Case UCase(MyZnak & trans("Только для чтения"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.FileReadOnly(args))
            Case UCase(MyZnak & trans("Архивный"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Archive(args))
            Case UCase(MyZnak & trans("Папка"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Papka(args))
            Case UCase(MyZnak & trans("Зашифрованный"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Encrypted(args))
            Case UCase(MyZnak & trans("Не индексируется"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.NotIndexer(args))
            Case UCase(MyZnak & trans("Системный"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Systemiy(args))
            Case UCase(MyZnak & trans("Временный"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.Temp(args))
            Case UCase(MyZnak & trans("Время создания"))
                If args Is Nothing Then Return New ErrString(ToMyDate(Now))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.CreateTime(args))
            Case UCase(MyZnak & trans("Время доступа"))
                If args Is Nothing Then Return New ErrString(ToMyDate(Now))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.AccessTime(args))
            Case UCase(MyZnak & trans("Время изменения"))
                If args Is Nothing Then Return New ErrString(ToMyDate(Now))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.EditTime(args))
            Case UCase(MyZnak & trans("Существует файл"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return New ErrString(trans("Нет"))
                Return New ErrString(obj.Props.ExistFile(args))
            Case UCase(MyZnak & trans("Существует папка"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return New ErrString(trans("Нет"))
                Return New ErrString(obj.Props.ExistPath(args))
            Case UCase(MyZnak & trans("Получить файлы"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.GetFiles(args))
            Case UCase(MyZnak & trans("Получить папки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If obj.Props.ExistPath(args) = trans("Нет") Then es.err = Errors.PathNotExist(args(0)) : Return es
                Return New ErrString(obj.Props.GetPaths(args))
            Case UCase(MyZnak & trans("Получить диски"))
                Return New ErrString(obj.Props.GetDrives)
            Case UCase(MyZnak & trans("Определить корневую"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.GetRoot(args))
            Case UCase(MyZnak & trans("Определить родительскую"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetParent(args))
            Case UCase(MyZnak & trans("Определить имя папки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                Return New ErrString(obj.Props.GetPathName(args))
            Case UCase(MyZnak & trans("Определить имя файла"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetFileName(args))
            Case UCase(MyZnak & trans("Определить расширение"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetExtension(args))
            Case UCase(MyZnak & trans("Определить без расширения"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetFileNameWithoutExtension(args))
            Case UCase(MyZnak & trans("Определить размер файла"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.GetFileSize(args))
            Case UCase(MyZnak & trans("Поиск файлов"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If NikakoiEsli(args(1)) = trans("Никакой") Then Return es
                If (args(1)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(1)) : Return es
                End If
                Return New ErrString(obj.Props.FindFile(args))
            Case MyZnak & UCase(trans("Открыть файл"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                args(1) = NikakoiEsli(args(1))
                Return New ErrString(obj.props.OpenFile(args))
            Case UCase(MyZnak & trans("Количество файлов"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.FilesCount(args))
            Case UCase(MyZnak & trans("Количество папок"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                Return New ErrString(obj.Props.DirectoriesCount(args))

                ' PRERIVANIYA
            Case UCase(MyZnak & trans("Завершить программу")) : Return obj.Props.BreakApplication
            Case UCase(MyZnak & trans("Завершить событие")) : Return obj.Props.BreakEvent
            Case UCase(MyZnak & trans("Завершить цикл")) : Return obj.Props.BreakLoop
            Case UCase(MyZnak & trans("Завершить условие")) : Return obj.Props.StopIf
            Case UCase(MyZnak & trans("Пропускать ошибки")) : Return obj.Props.IgnoreErrors

                ' EKRAN
            Case UCase(MyZnak & trans("Рисунок рабочего стола")) : Return New ErrString(obj.Props.WallPaper)
            Case UCase(MyZnak & trans("Стиль рабочего стола")) : Return New ErrString(obj.Props.DesktopStyle)
            Case UCase(MyZnak & trans("Разрешение экрана")) : Return New ErrString(obj.Props.DesktopResolution)
            Case UCase(MyZnak & trans("Частота экрана")) : Return New ErrString(obj.Props.DesktopFrequency)
            Case UCase(MyZnak & trans("Качество цветопередачи")) : Return New ErrString(obj.Props.DesktopBits)
            Case UCase(MyZnak & trans("Заставка")) : Return New ErrString(obj.Props.ScreenSaver)
            Case UCase(MyZnak & trans("Скриншот"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NetTakNet(args(0)) = trans("Никакой") Then es.err = Errors.notDaOrNet(args(0)) : Return es
                args(0) = NetTakNet(args(0))
                Return New ErrString(obj.Props.ScreenShot(args))
            Case UCase(MyZnak & trans("Скриншот объекта"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ScreenshotOfObject(args))



                ' SYSTEM
            Case UCase(MyZnak & trans("Мышь X")) : Return New ErrString(obj.Props.MouseX)
            Case UCase(MyZnak & trans("Мышь Y")) : Return New ErrString(obj.Props.MouseY)
            Case UCase(MyZnak & trans("Клавиша клавиатуры")) : Return New ErrString(obj.Props.KeyboardKey)
            Case UCase(MyZnak & trans("Нажат альт")) : Return New ErrString(obj.Props.KeyboardAlt)
            Case UCase(MyZnak & trans("Нажат шифт")) : Return New ErrString(obj.Props.KeyboardShift)
            Case UCase(MyZnak & trans("Нажат контрол")) : Return New ErrString(obj.Props.KeyboardControl)
            Case UCase(MyZnak & trans("Нажата мыши левая")) : Return New ErrString(obj.Props.MouseLeft)
            Case UCase(MyZnak & trans("Нажата мыши правая")) : Return New ErrString(obj.Props.MouseRight)
            Case UCase(MyZnak & trans("Рисунок буфера обмена")) : Return New ErrString(obj.Props.ClipboardPicture)
            Case UCase(MyZnak & trans("Текст буфера обмена")) : Return New ErrString(obj.Props.ClipboardText)
            Case UCase(MyZnak & trans("Выполнить с результатом"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.RunWithResult(args))
            Case UCase(MyZnak & trans("Процессы системы")) : Return New ErrString(obj.Props.ProcessesList)
            Case UCase(MyZnak & trans("Окна системы")) : Return New ErrString(obj.Props.WindowsList)
            Case UCase(MyZnak & trans("Окно в фокусе")) : Return New ErrString(obj.Props.WindowInFocus)



                ' REGISTRY
            Case UCase(MyZnak & trans("Значение реестра"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                Return New ErrString(obj.Props.Key(args))
            Case UCase(MyZnak & trans("Ключ существует"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ExistKey(args))
            Case UCase(MyZnak & trans("Папка существует"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ExistSubKey(args))
            Case UCase(MyZnak & trans("Тип ключа"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.TypeKey(args))

                ' TEXT BOKS
            Case UCase(trans("Номер символа по координатам"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.GetCharIndexFromPosition(args))
            Case UCase(trans("Номер первого символа строки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.GetFirstCharIndexFromLine(args))
            Case UCase(trans("Номер первого символа текущей строки")) : Return New ErrString(obj.Props.GetFirstCharIndexOfCurrentLine)
            Case UCase(trans("Номер строки по номеру символа"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.GetLineFromCharIndex(args))
            Case UCase(trans("X по номеру символа"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.GetXFromCharIndex(args))
            Case UCase(trans("Y по номеру символа"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.GetYFromCharIndex(args))
            Case UCase(trans("Строка"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.Line(args))
            Case UCase(trans("Количество строк")) : Return New ErrString(obj.Props.LinesCount)
            Case UCase(trans("Символ"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                Return New ErrString(obj.Props.Chars(args))
            Case UCase(trans("Количество символов")) : Return New ErrString(obj.Props.CharsLength)

                ' TEXTS POLEZNIE
            Case MyZnak & UCase(trans("Символ по номеру"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If args(1) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1)) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                Return New ErrString(obj.Props.Chars(args))
            Case MyZnak & UCase(trans("Сравнить тексты"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Compare(args))
            Case MyZnak & UCase(trans("Текст состоит из"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ConsistAll(args))
            Case MyZnak & UCase(trans("Текст есть число"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.isNumberText(args))
            Case MyZnak & UCase(trans("Текст есть цифры"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.isNumericText(args))
            Case MyZnak & UCase(trans("Поиск номера строки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.IndexOfLine(args))
            Case MyZnak & UCase(trans("Поиск в тексте"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.IndexOfIgnoreCase(args))
            Case MyZnak & UCase(trans("Поиск с учетом регистра"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.IndexOf(args))
            Case MyZnak & UCase(trans("Поиск в тексте с конца"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                'If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.LastIndexOfIgnoreCase(args))
            Case MyZnak & UCase(trans("Поиск с регулярными выражениями"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.IndexOfRegular(args))
            Case MyZnak & UCase(trans("Количество символов"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.CharsLength(args))
            Case MyZnak & UCase(trans("Разбить на части"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.Split(args))
            Case MyZnak & UCase(trans("Взять кусок текста"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If args(1) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1)) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                ' If args(1) - 1 + args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1) - 1 + args(2)) : Return es
                Return New ErrString(obj.Props.Substring(args))
            Case MyZnak & UCase(trans("Количество частей текста"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.SplitCount(args))
            Case MyZnak & UCase(trans("Кавычки убрать"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DeleteQuotes(args))
            Case MyZnak & UCase(trans("Кавычками обособить"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.PutInQuotes(args))
            Case MyZnak & UCase(trans("Поиск без кавычек"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(2)) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.IndexOfWithoutQuotes(args))
            Case MyZnak & UCase(trans("Разбить на части без кавычек"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                If Int(args(2)) <= 0 Then es.err = Errors.notLessEqZero(args(2), prop) : Return es
                Return New ErrString(obj.Props.SplitWithoutQuotes(args))
            Case MyZnak & UCase(trans("Количество частей без кавычек"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.SplitWithoutQuotesCount(args))
            Case MyZnak & UCase(trans("Текст содержит"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Consist(args))
            Case MyZnak & UCase(trans("Текст не содержит"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ConsistNo(args))
            Case MyZnak & UCase(trans("Строка по номеру"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                Return New ErrString(obj.Props.Line(args))
            Case MyZnak & UCase(trans("Количество строк"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.LinesCount(args))
            Case MyZnak & UCase(trans("Зашифровать текст"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.EncryptText(args))
            Case MyZnak & UCase(trans("Расшифровать текст"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DecryptText(args))

            Case MyZnak & UCase(trans("Вставить символы в текст"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If args(1) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1)) : Return es
                Return New ErrString(obj.Props.Insert(args))
            Case MyZnak & UCase(trans("Удалить кусок текста"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If args(1) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1)) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If Iz.isInteger(args(2)) = False Then es.err = Errors.notInt(args(2), prop) : Return es
                'If args(1) - 1 + args(2) > args(0).Length + 1 Then es.err = Errors.notLength(prop, args(0), args(1) - 1 + args(2)) : Return es
                Return New ErrString(obj.Props.Remove(args))
            Case MyZnak & UCase(trans("Заменить"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ReplaceOne(args))
            Case MyZnak & UCase(trans("Заменить все"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.ReplaceAll(args))
            Case MyZnak & UCase(trans("Сделать буквы прописными"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.toLower(args))
            Case MyZnak & UCase(trans("Сделать буквы заглавными"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.toUpper(args))
            Case MyZnak & UCase(trans("Убрать пробелы"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.TrimAll(args))
            Case MyZnak & UCase(trans("Убрать пробелы в начале"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.TrimStart(args))
            Case MyZnak & UCase(trans("Убрать пробелы в конце"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.TrimEnd(args))

                ' СООБЩЕНИЕ
            Case MyZnak & UCase(trans("Была нажата Отмена")) : Return New ErrString(obj.Props.WasCancel)
            Case MyZnak & UCase(trans("Была нажата Ок")) : Return New ErrString(obj.Props.WasOk)
            Case MyZnak & UCase(trans("Была нажата Повторить")) : Return New ErrString(obj.Props.WasRetry)
            Case MyZnak & UCase(trans("Была нажата Да")) : Return New ErrString(obj.Props.WasYes)
            Case MyZnak & UCase(trans("Была нажата Нет")) : Return New ErrString(obj.Props.WasNo)
            Case MyZnak & UCase(trans("Была нажата Прервать")) : Return New ErrString(obj.Props.WasAbort)
            Case MyZnak & UCase(trans("Была нажата Пропустить")) : Return New ErrString(obj.Props.WasIgnore)
            Case MyZnak & UCase(trans("Была нажата Справка")) : Return New ErrString(obj.Props.WasHelp)

                ' DATE
            Case MyZnak & UCase(trans("День месяца"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DayOfMonth(args))
            Case MyZnak & UCase(trans("День года"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DayOfYear(args))
            Case MyZnak & UCase(trans("День в неделе"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DayOfWeek(args))
            Case MyZnak & UCase(trans("Час"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Hour(args))
            Case MyZnak & UCase(trans("Минута"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Minute(args))
            Case MyZnak & UCase(trans("Секунда"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Second(args))
            Case MyZnak & UCase(trans("Квартал"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Quarter(args))
            Case MyZnak & UCase(trans("Неделя в году"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.WeekOfYear(args))
            Case MyZnak & UCase(trans("Год"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Year(args))
            Case MyZnak & UCase(trans("Месяц"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Month(args))
            Case MyZnak & UCase(trans("Время"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Time(args))
            Case MyZnak & UCase(trans("Секунд всего в дате"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.Ticks(args))
            Case MyZnak & UCase(trans("Дней в месяце"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Int(args(0)) <= 0 Then es.err = Errors.notLessEqZero(args(0), prop) : Return es
                If Int(args(0)) > 9999 Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If Int(args(1)) > 12 Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DaysInMonth(args))
            Case MyZnak & UCase(trans("Сейчас")) : Return New ErrString(obj.Props.Now)
            Case MyZnak & UCase(trans("Сегодня")) : Return New ErrString(obj.Props.Today)
            Case MyZnak & UCase(trans("Прибавить дни"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddDay(args))
            Case MyZnak & UCase(trans("Прибавить часы"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddHour(args))
            Case MyZnak & UCase(trans("Прибавить минуты"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddMinute(args))
            Case MyZnak & UCase(trans("Прибавить секунды"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddSecond(args))
            Case MyZnak & UCase(trans("Прибавить кварталы"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddQuarter(args))
            Case MyZnak & UCase(trans("Прибавить недели"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddWeek(args))
            Case MyZnak & UCase(trans("Прибавить годы"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddYear(args))
            Case MyZnak & UCase(trans("Прибавить месяцы"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.DateAddMonth(args))
            Case MyZnak & UCase(trans("Разница в днях"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffDay(args))
            Case MyZnak & UCase(trans("Разница в часах"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffHour(args))
            Case MyZnak & UCase(trans("Разница в минутах"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffMinute(args))
            Case MyZnak & UCase(trans("Разница в секундах"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffSecond(args))
            Case MyZnak & UCase(trans("Разница в кварталах"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffQuarter(args))
            Case MyZnak & UCase(trans("Разница в неделях"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffWeek(args))
            Case MyZnak & UCase(trans("Разница в годах"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffYear(args))
            Case MyZnak & UCase(trans("Разница в месяцах"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.DateDiffMonth(args))
            Case MyZnak & UCase(trans("День недели"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.WeekdayName(args))
            Case MyZnak & UCase(trans("Название месяца"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Return New ErrString(obj.Props.MonthName(args))
            Case MyZnak & UCase(trans("Дата в определенном формате"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If Int(args(1)) <= 0 Then es.err = Errors.notLessEqZero(args(1), prop) : Return es
                If Int(args(1)) > 53 Then es.err = Errors.notInt(args(1), prop) : Return es
                Return New ErrString(obj.Props.GetDateTimeFormats(args))

                ' SOBYTS PROPERTY
            Case Else
                ' Может это свойство события
PropVParam:     If vParamah Then
                    ' Когда проект запущен, то гораздо не тормознее использовать уже созданный объект Param
                    If RunProj.Param.ParamyUp.IndexOfKey(UCase(prop)) <> -1 And MyObj.isrun Then
                        Return New ErrString(RunProj.Param.Paramy.GetByIndex(RunProj.Param.ParamyUp.IndexOfKey(UCase(prop))))
                    End If
                Else
                    ' очень редко выпадает
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
        If Array.IndexOf(MyObj.PropertysUp, prop) = -1 Then Return MsgBoxResult.Yes ' Если нет такого свойства то выйти из функции
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

        ' ТОЛЬКО ДЛЯ ЧТЕНИЯ
        If Array.IndexOf(ReadOnlyProps, prop) <> -1 Then es.err = Errors.isReadOnly(prop) : Return es

        ' Заменить символ |Р на интеры
        value = perevesti(value, True)
        ' заменить в аргументах мой знак на интеры
        If prop <> MyZnak & UCase(trans("Выполнить код Алгоритма2")) Then
            If args Is Nothing = False Then
                For j = 0 To args.Length - 1
                    args(j) = perevesti(args(j), True)
                Next
            End If
        End If

        Select Case prop
            Case UCase(trans("Имя"))
                If ValidName(value) = False Then es.err = Errors.NameInvalid(value) : es.str = "MsgBox ne nado" : Return es
                If MyObj.isRun = False And fromEng = False And isConsole = False Then
                    If proj.ExistName(value, obj) Then ' Если имя уже существует
                        If obj.Props.index = 0 Then
                            Dim result As MsgBoxResult ' Предложить создать массив
                            If obj.parent Is Nothing = False Then
                                result = MsgBox(Errors.CreateMassive(value), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
                            Else
                                ' Если идет вставка, то выводить сообщения не надо
                                result = MsgBoxResult.Retry
                            End If
                            If result = MsgBoxResult.Yes Then
                                proj.ActiveForm.CreateMassive(value, MyObj) ' создать массив
                                proj.ActiveForm.recur = True
                                'proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                            ElseIf result = MsgBoxResult.No Then
                                MsgBox(Errors.NameExist(value), MsgBoxStyle.Exclamation)
                                es.err = "!" : es.str = "MsgBox ne nado" : Return es ' Чтобы сетпропер вернул MsgBoxResult.No, но без мсгбокса
                            ElseIf result = MsgBoxResult.Cancel Then
                                es.err = "!" : es.str = "Cancel" : Return es ' Чтобы сетпропер вернул MsgBoxResult.No, но без мсгбокса
                            Else
                            End If
                        Else ' Если такой массив уже есть, то дать ему индекс, которого еще нет
                            obj.Props.index = MyObj.GetMyForm.GetIndex(value, obj, obj.Props.index) : refresh = True
                        End If : obj.refresh() ' Чтоб пропечатать индексы
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
            Case UCase(trans("Фоновой рисунок"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("Никакой") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.BackgroundImage = value
            Case UCase(trans("Фоновой рисунок1"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("Никакой") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.BackgroundImage1 = value
            Case UCase(trans("Фоновой рисунок2"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("Никакой") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.BackgroundImage2 = value
            Case UCase(trans("Цвет"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.BackColor = col
            Case UCase(trans("Цвет1"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.BackColor1 = col
            Case UCase(trans("Цвет2"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.BackColor2 = col
            Case UCase(trans("Номер"))
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
            Case UCase(trans("Позиция"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.position = value
            Case UCase(trans("Главная форма"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.mainform = value
            Case UCase(trans("Всплывающее меню"))
                obj.Props.contextmenu = value
            Case UCase(trans("Всплывающее меню1"))
                obj.Props.contextmenu1 = value
            Case UCase(trans("Всплывающее меню2"))
                obj.Props.contextmenu2 = value
            Case UCase(trans("Запретить закрытие"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ForbidClose = value
            Case UCase(trans("Привязка"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Anchors.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWAnchors) : Return es
                obj.Props.Anchor = value
            Case UCase(trans("АвтоТроеточие"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AutoEllipsis = value
            Case UCase(trans("Стиль фона"))
                value = NikakoiEsli(value)
                Dim ind As Integer = bkImStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWbkImStyles) : Return es
                obj.Props.BackgroundImageLayout = value
            Case UCase(trans("Стиль фона1"))
                value = NikakoiEsli(value)
                Dim ind As Integer = bkImStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWbkImStyles) : Return es
                obj.Props.BackgroundImageLayout1 = value
            Case UCase(trans("Стиль фона2"))
                value = NikakoiEsli(value)
                Dim ind As Integer = bkImStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWbkImStyles) : Return es
                obj.Props.BackgroundImageLayout2 = value
            Case UCase(trans("Стиль рисунка"))
                value = NikakoiEsli(value)
                Dim ind As Integer = SizeModes.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWSizeModes) : Return es
                obj.Props.SizeMode = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Курсор"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Cursori.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWCursori) : Return es
                obj.Props.Cursor = value
            Case UCase(trans("Курсор1"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Cursori.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWCursori) : Return es
                obj.Props.Cursor1 = value
            Case UCase(trans("Курсор2"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Cursori.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWCursori) : Return es
                obj.Props.Cursor2 = value
            Case UCase(trans("Растяжка"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Docks.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWDocks) : Return es
                obj.Props.Dock = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Работает"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Enabled = value
            Case UCase(trans("Стиль кнопки"))
                value = NikakoiEsli(value)
                Dim ind As Integer = FlatStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFlatStyles) : Return es
                obj.Props.FlatStyle = value
            Case UCase(trans("Стиль рамки"))
                value = NikakoiEsli(value)
                Dim ind As Integer = BorderStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWBorderStyles) : Return es
                obj.Props.BorderStyle = value
            Case UCase(trans("Шрифт"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Fonts.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFonts) : Return es
                obj.Props.FontFamily = value
            Case UCase(trans("Шрифт жирный"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FontBold = value
            Case UCase(trans("Шрифт курсив"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FontItalic = value
            Case UCase(trans("Шрифт подчеркнутый"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FontUnderline = value
            Case UCase(trans("Шрифт зачеркнутый"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FontStrikeOut = value
            Case UCase(trans("Шрифт размер"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.FontSize = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Цвет шрифта"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.ForeColor = col
            Case UCase(trans("Рисунок"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("Никакой") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.Image = value
            Case UCase(trans("Положение рисунка"))
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
            Case UCase(trans("Максимальная ширина"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MaximumWidth = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Максимальная вышина"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MaximumHeight = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Минимальная ширина"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MinimumWidth = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Минимальная вышина"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MinimumHeight = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Поле слева"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.PaddingLeft = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("Поле сверху"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.PaddingTop = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("Поле справа"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.PaddingRight = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("Поле снизу"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.PaddingBottom = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("Вышина"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.Height = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("Ширина"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.Width = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False Then IzmenenieBylo(False)
            Case UCase(trans("ТабНомер"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.TabIndex = value
            Case UCase(trans("ТабСтоп"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.TabStop = value
            Case UCase(trans("Вспомогательное поле"))
                obj.Props.Tag = value
            Case UCase(trans("Текст"))
                obj.Props.Text = value
            Case UCase(trans("Положение текста"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Aligns.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWAligns) : Return es
                obj.Props.TextAlign = value
            Case UCase(trans("Расположение текста"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TextPositions.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTextPositions) : Return es
                obj.Props.TextPosition = value
            Case UCase(trans("Текст и рисунок"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TextImages.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTextImages) : Return es
                obj.Props.TextImageRelation = value
            Case UCase(trans("Видимый"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Visible = value
            Case UCase(trans("Прокрутка"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Scroll = value
            Case UCase(trans("Прокрутка1"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Scroll1 = value
            Case UCase(trans("Прокрутка2"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Scroll2 = value
            Case UCase(trans("Фиксированная часть"))
                value = NikakoiEsli(value)
                Dim ind As Integer = FixedPanels.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFixedPanels) : Return es
                obj.Props.FixedPanel = value
            Case UCase(trans("Фиксированный разделитель"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FixedSplitter = value
            Case UCase(trans("Панель1 скрыта"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Panel1Collapsed = value
            Case UCase(trans("Панель2 скрыта"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Panel2Collapsed = value
            Case UCase(trans("Ориентация"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Orientations.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWOrientations) : Return es
                obj.Props.Orientation = value
            Case UCase(trans("Ширина разделителя"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.SplitterWidth = value
            Case UCase(trans("Расстояние разделителя"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SplitterDistance = value
            Case UCase(trans("Инкремент разделителя"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SplitterIncrement = value
            Case UCase(trans("Панель1 минимум"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Panel1MinSize = value
            Case UCase(trans("Панель2 минимум"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Panel2MinSize = value
            Case MyZnak & UCase(trans("Отменить перемещение"))
                If RunProj.Param.ParamyUp.ContainsKey(MyZnak & UCase(trans("Отменить перемещение"))) Then
                    RunProj.Param.ParamyUp(MyZnak & UCase(trans("Отменить перемещение"))) = value
                Else
                    es.err = "!"
                End If
            Case MyZnak & UCase(trans("Отменить ввод"))
                If RunProj.Param.ParamyUp.ContainsKey(MyZnak & UCase(trans("Отменить ввод"))) Then
                    RunProj.Param.ParamyUp(MyZnak & UCase(trans("Отменить ввод"))) = value
                Else
                    es.err = "!"
                End If
            Case MyZnak & UCase(trans("Отменить событие"))
                If RunProj.Param.ParamyUp.ContainsKey(MyZnak & UCase(trans("Отменить событие"))) Then
                    RunProj.Param.ParamyUp(MyZnak & UCase(trans("Отменить событие"))) = value
                Else
                    es.err = "!"
                End If
            Case MyZnak & UCase(trans("Отменить в новом окне"))
                If RunProj.Param.ParamyUp.ContainsKey(MyZnak & UCase(trans("Отменить в новом окне"))) Then
                    RunProj.Param.ParamyUp(MyZnak & UCase(trans("Отменить в новом окне"))) = value
                Else
                    es.err = "!"
                End If
            Case UCase(trans("Скрывать выделение"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.HideSelection = value
            Case UCase(trans("Максимальная длинна"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MaximumLength = value
            Case UCase(trans("Многострочность"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Multiline = value
            Case UCase(trans("Символ пароля"))
                If NikakoiEsli(value) = trans("Никакой") Then value = ""
                If value.Length > 1 Then es.err = Errors.notChar(value) : Return es
                obj.Props.PasswordChar = value
            Case UCase(trans("Только для чтения"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ReadOnly = value
            Case UCase(trans("Полосы прокрутки"))
                value = NikakoiEsli(value)
                Dim ind As Integer = ScrollBarz.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWScrollBarz) : Return es
                obj.Props.ScrollBars = value
            Case UCase(trans("Перенос по словам"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.WordWrap = value
            Case UCase(trans("Выделенный текст"))
                obj.Props.SelectedText = value
            Case UCase(trans("Начало выделения"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.SelectionStart = value
            Case UCase(trans("Длинна выделения"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.SelectionLength = value
            Case UCase(trans("Отмечено"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Checked = value
            Case UCase(trans("Ориентация инструментов"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Orientations.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWOrientations) : Return es
                obj.Props.OrientationTools = value
            Case UCase(trans("Расположен слева"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Alignment = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("Показывать подсказку"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AutoToolTip = value
            Case UCase(trans("Отметка по клику"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.CheckOnClick = value
            Case UCase(trans("Стиль отображения"))
                value = NikakoiEsli(value)
                Dim ind As Integer = DisplayStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWDisplayStyles) : Return es
                obj.Props.DisplayStyle = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("Вложенное всплывающее меню"))
                obj.Props.DropDown = value
            Case UCase(trans("Рисунок растянут"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ImageScaling = value
                If MyObj.isRun = False And proj.UndoRedoNoWrite = False And proj.ActiveForm Is Nothing = False Then proj.ActiveForm.marker_vis()
            Case UCase(trans("Прозрачный цвет рисунка"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.ImageTransparentColor = col
            Case UCase(trans("Горячая клавиша"))
                es = UbratKovich(value)
                If es.err <> "" Then Return es
                obj.Props.ShortcutKeys = es.str
            Case UCase(trans("Отображать горячие клавиши"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowShortcutKeys = value
            Case UCase(trans("Направление текста"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TextDirections.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTextDirections) : Return es
                obj.Props.TextDirection = value
            Case UCase(trans("Всплывающая подсказка"))
                obj.Props.ToolTipText = value
            Case UCase(trans("Переходить по сссылкам"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowNavigation = value
            Case UCase(trans("Разрешить перетаскивания"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowWebBrowserDrop = value
            Case UCase(trans("Текст страницы"))
                obj.Props.DocumentText = value
            Case UCase(trans("Всплывающее меню браузера"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.isWebBrowserContextMunuEnabled = value
            Case UCase(trans("Отображать ошибки сценариев"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ScriptErrorsSuppressed = value
            Case UCase(trans("Полосы прокрутки активны"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ScrollBarsEnabled = value
            Case UCase(trans("Ссылка"))
                obj.Props.Url = value
            Case UCase(trans("Ссылка надписи"))
                obj.Props.LinkName = value
            Case UCase(trans("Горячие клавиши работают"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.WebBrowserShortcutsEnabled = value
            Case UCase(trans("Кодировка"))
                value = NikakoiEsli(value)
                ' Dim ind As Integer = DocumentEncodings.IndexOfKey(LCase(value))
                'If ind = -1 Then es.err = Errors.notCollection(prop, value, HWDocumentEncodings) : Return es
                obj.Props.DocumentEncoding = value
            Case UCase(trans("Куки"))
                obj.Props.Cookie = value
            Case UCase(trans("Открытие ссылок нового окна"))
                obj.Props.OpenNewWindowLink = value
            Case UCase(trans("Открыть в новом окне"))
                obj.props.NavigateNewPage()
            Case MyZnak & UCase(trans("Открыть в фрейме"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.props.NavigateInFrame(args)
            Case UCase(trans("Обновить страницу"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                Dim ind As Integer = Refreshs.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWRefreshs) : Return es
                obj.Props.RefreshPage(args)
            Case UCase(trans("Оконные кнопки и меню"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ControlBox = value
            Case UCase(trans("Стиль окна"))
                value = NikakoiEsli(value)
                Dim ind As Integer = FormBorderStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFormBorderStyles) : Return es
                obj.Props.FormBorderStyle = value
            Case UCase(trans("Главное меню"))
                obj.Props.MainMenuStrip = value
            Case UCase(trans("Прозрачность"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                If Int(value) > 100 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.Opacity = value
            Case UCase(trans("Показывать иконку"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowIcon = value
            Case UCase(trans("Отображать в панели задач"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowInTaskbar = value
            Case UCase(trans("Стартовая позиция"))
                value = NikakoiEsli(value)
                Dim ind As Integer = StartPositions.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWStartPositions) : Return es
                obj.Props.StartPosition = value
            Case UCase(trans("Поверх всех окон"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.TopMost = value
            Case UCase(trans("Статус окна"))
                value = NikakoiEsli(value)
                Dim ind As Integer = WindowStates.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWWindowStates) : Return es
                obj.Props.WindowState = value
            Case UCase(trans("Прокрутка минимальная ширина"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.AutoScrollMinSizeWidth = value
            Case UCase(trans("Прокрутка минимальная вышина"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.AutoScrollMinSizeHeight = value
            Case UCase(trans("Прокручено по X"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.AutoScrollPositionX = value
            Case UCase(trans("Прокручено по Y"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.AutoScrollPositionY = value
            Case UCase(trans("Иконка"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("Никакой") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.Icon = value
            Case UCase(trans("Прозрачный цвет"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.TransparentcyKey = col
            Case UCase(trans("Положение закладок"))
                value = NikakoiEsli(value)
                Dim ind As Integer = Alignments.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWAlignments) : Return es
                obj.Props.TabAlignment = value
            Case UCase(trans("Позиция выделенной закладки"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                'If Int(value) > obj.TabCount - 1 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.SelectedTabPosition = value
            Case UCase(trans("Поле по горизонтали"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.PaddingX = value
            Case UCase(trans("Поле по вертикали"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.PaddingX = value
            Case UCase(trans("Значение"))
                obj.Props.Value = value
            Case UCase(trans("Подсказка"))
                obj.Props.ToolTip = value
            Case UCase(trans("Добавить в автозагрузку"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AutoRun = value
            Case UCase(trans("Разрешить запуск копий"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowRunCopies = value
            Case UCase(trans("Разрешить вводить"))
                value = NikakoiEsli(value)
                Dim ind As Integer = InputTypes.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWInputTypes) : Return es
                obj.Props.AllowInput = value
            Case UCase(trans("Страница начала печати"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.FromPage = value
            Case UCase(trans("Страница конца печати"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.ToPage = value
            Case UCase(trans("Число копий"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Copies = value
            Case UCase(trans("Ширина столбцов"))
                obj.Props.WidthOfColumns = value
            Case UCase(trans("Вышина строк"))
                obj.Props.HeightOfRows = value


                ' Таблица
            Case UCase(trans("Позволить добавлять строки"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToAddRows = value
            Case UCase(trans("Позволить удалять строки"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToDeleteRows = value
            Case UCase(trans("Позволить переставлять столбцы"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToOrderColumns = value
            Case UCase(trans("Позволить растягивать столбцы"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToResizeColumns = value
            Case UCase(trans("Позволить растягивать строки"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowUserToResizeRows = value
            Case UCase(trans("Количество строк таблицы"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.RowsCount = value
            Case UCase(trans("Количество столбцов"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.ColumnsCount = value
            Case UCase(trans("Стиль рамки ячейки"))
                value = NikakoiEsli(value)
                Dim ind As Integer = CellBorderStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWCellBorderStyles) : Return es
                obj.Props.CellBorderStyle = value
            Case UCase(trans("Отображать заголовки столбцов"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ColumnHeadersVisible = value
            Case UCase(trans("Отображать специальный столбец"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.RowHeadersVisible = value
            Case UCase(trans("Вышина заголовков столбцов"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.ColumnHeadersHeight = value
            Case UCase(trans("Столбцы"))
                obj.Props.Columns = value
            Case UCase(trans("Строки"))
                obj.Props.Rows = value
            Case UCase(trans("Цвет фона ячеек"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DefaultCellStyleBackColor = col
            Case UCase(trans("Цвет фона выделенных ячеек"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DefaultCellStyleSelectionBackColor = col
            Case UCase(trans("Цвет шрифта ячеек"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DefaultCellStyleForeColor = col
            Case UCase(trans("Цвет шрифта выделенных ячеек"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DefaultCellStyleSelectionForeColor = col
            Case UCase(trans("Режим редактирования"))
                value = NikakoiEsli(value)
                Dim ind As Integer = EditModes.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWEditModes) : Return es
                obj.Props.EditMode = value
            Case UCase(trans("Цвет сетки"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.GridColor = col
            Case UCase(trans("Выбор нескольких ячеек"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MultiSelect = value
            Case UCase(trans("Выбор нескольких записей"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MultiSelectItems = value
            Case UCase(trans("Только для чтения таблица"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ReadOnlyTable = value
            Case UCase(trans("Режим выделения"))
                value = NikakoiEsli(value)
                Dim ind As Integer = SelectionModes.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWSelectionModes) : Return es
                obj.Props.SelectionMode = value
            Case UCase(trans("Номера выделенных строк"))
                Dim str() As String = value.Split(","), i As Integer
                For i = 0 To str.Length - 1
                    If str(i) <> "" Then
                        If Iz.isInteger(str(i)) = False Then es.err = Errors.notInt(str(i), prop) : Return es
                        If Int(str(i)) < 0 Then es.err = Errors.notInt(str(i), prop) : Return es
                    End If
                Next
                obj.Props.SelectedRows = value
            Case UCase(trans("Номера выделенных столбцов"))
                Dim str() As String = value.Split(","), i As Integer
                For i = 0 To str.Length - 1
                    If str(i) <> "" Then
                        If Iz.isInteger(str(i)) = False Then es.err = Errors.notInt(str(i), prop) : Return es
                        If Int(str(i)) < 0 Then es.err = Errors.notInt(str(i), prop) : Return es
                    End If
                Next
                obj.Props.SelectedColumns = value
            Case UCase(trans("Значение ячейки"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ItemValue(args) = value
            Case UCase(trans("Ячейка выделена"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(prop, args(1)) : Return es
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ItemSelected(args) = value
            Case UCase(trans("Строка только для чтения"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.RowsReadOnly(args) = value
            Case UCase(trans("Столбец только для чтения"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If obj.Columns.Count <= args(0) Then es.err = Errors.noColumns(prop, args(0)) : Return es
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ColumnReadOnly(args) = value
            Case UCase(trans("Ячейка только для чтения"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                'If obj.Rows.Count <= args(0) Then es.err = Errors.noRows(prop, args(0)) : Return es
                'If obj.Columns.Count <= args(1) Then es.err = Errors.noColumns(prop, args(1)) : Return es
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ItemReadOnly(args) = value
            Case UCase(trans("Ширина столбца"))
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
            Case UCase(trans("Вышина строки"))
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
            Case UCase(trans("Добавить копию строк"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = Trim(args(0).Split(",")(0))
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If Iz.isInteger(args(1)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                If args(0) >= obj.rows.count Then es.err = Errors.notRowCount(args(0), prop) : Return es
                If Int(args(0)) + args(1) > obj.rows.count Then es.err = Errors.notRowCount(Int(args(0)) + args(1), prop) : Return es
                obj.Props.RowsAddCopies(args)
            Case UCase(trans("Вставить строку"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = Trim(args(0).Split(",")(0))
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If args(0) > obj.rows.count Then es.err = Errors.notRowCount(args(0), prop) : Return es
                obj.Props.RowsInsert(args)
            Case UCase(trans("Вставить копию строк"))
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
            Case UCase(trans("Удалить строку"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.RowsRemove(args)
            Case UCase(trans("Сохранить таблицу"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.SaveTable(args)
            Case UCase(trans("Открыть таблицу"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.OpenTable(args)
            Case UCase(trans("Сортировать"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If args(0) >= obj.columns.count Then es.err = Errors.notRowCount(args(0), prop) : Return es
                obj.Props.SortTable(args)
            Case UCase(trans("Открыть Access"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                If NikakoiEsli(args(1)) = trans("Никакой") Then Return es
                obj.props.OpenAccess(args)
            Case UCase(trans("Открыть Excel"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                If NikakoiEsli(args(1)) = trans("Никакой") Then Return es
                obj.props.OpenExcel(args)
            Case UCase(trans("Сохранить Access"))
                obj.props.SaveAccess()
            Case UCase(trans("Вставить столбец"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = Trim(args(0).Split(",")(0))
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If args(0) > obj.columns.count Then es.err = Errors.notColumnCount(args(0), prop) : Return es
                obj.Props.ColumnsInsert(args)
            Case UCase(trans("Удалить столбец"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ColumnsRemove(args)
            Case UCase(trans("Добавить строку"))
                obj.Props.RowsAdd(args)
            Case UCase(trans("Добавить столбец"))
                obj.Props.ColumnsAdd(args)
            Case UCase(trans("SQL запрос выборки"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = NikakoiEsli(args(0))
                Dim ind As Integer = BdTypes.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWBdTypes) : Return es
                obj.Props.SQLquerySelect(args)
            Case UCase(trans("SQL запрос изменения"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                args(0) = NikakoiEsli(args(0))
                Dim ind As Integer = BdTypes.IndexOfKey(LCase(args(0)))
                If ind = -1 Then es.err = Errors.notCollection(prop, args(0), HWBdTypes) : Return es
                obj.Props.SQLqueryInto(args)
            Case UCase(trans("Поиск с выделением"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 5 Then es.err = Errors.noArguments(prop) : Return es
                'If Iz.isInteger(args(3)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                'If Iz.isInteger(args(4)) = False Then es.err = Errors.notInt(args(1), prop) : Return es
                obj.Props.SearchWithSelect(args)
            Case UCase(trans("Значение выделеных ячеек"))
                obj.Props.SelectedItemsValue() = value



                ' Списки
            Case UCase(trans("Высота раскрывающегося списка"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.DropDownHeight = value
            Case UCase(trans("Ширина раскрывающегося списка"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.DropDownWidth = value
            Case UCase(trans("Список упрощенный"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.DropDownStyle = value
            Case UCase(trans("Записи списка"))
                obj.Props.Items = value
            Case UCase(trans("Количество раскрывающихся записей"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.MaxDropDownItems = value
            Case UCase(trans("Сортирован список"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Sorted = value
            Case UCase(trans("Список раскрыт"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.DroppedDown = value
            Case UCase(trans("Номер выделенной записи"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then Return es
                If obj.items.count <= value Then es.err = Errors.noItems(prop, value) : Return es
                obj.Props.SelectedIndex = value
            Case UCase(trans("Выделенная запись"))
                obj.Props.SelectedItem = value
            Case UCase(trans("Запись по номеру"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If obj.items.count <= args(0) Then es.err = Errors.noItems(prop, args(0)) : Return es
                obj.Props.ItemsItem(args) = value
            Case UCase(trans("Найти номер записи"))
                If isRUN() = False Then es.str = "MsgBox ne nado"
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ItemsIndexOf(args) = value
            Case UCase(trans("Добавить запись"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ItemsAdd(args)
            Case UCase(trans("Вставить запись"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If obj.items.count < args(0) Then es.err = Errors.noItems(prop, args(0)) : Return es
                obj.Props.ItemsInsert(args)
            Case UCase(trans("Удалить запись"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ItemsRemove(args)
            Case UCase(trans("Удалить запись по номеру"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                If obj.items.count <= args(0) Then es.err = Errors.noItems(prop, args(0)) : Return es
                obj.Props.ItemsRemoveAt(args)
            Case UCase(trans("Ширина колонок списка"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.ColumnWidth = value
            Case UCase(trans("Горизонтальная прокрутка"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.HorizontalScrollBar = value
            Case UCase(trans("Многоколонность"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MultiColumn = value
            Case UCase(trans("Позволить выбирать записи"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionModeList = value
            Case UCase(trans("Номера отмеченых записей"))
                obj.Props.CheckedIndices = value
            Case UCase(trans("Отмеченные записи"))
                obj.Props.CheckedItems = value
            Case UCase(trans("Номера выделенных записей"))
                obj.Props.SelectedIndices = value
            Case UCase(trans("Выделенные записи"))
                obj.Props.SelectedItems = value

                ' Ссылка
            Case UCase(trans("Цвет активной ссылки"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.ActiveLinkColor = col
            Case UCase(trans("Цвет нерабочей ссылки"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DisabledLinkColor = col
            Case UCase(trans("Цвет ссылки"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.LinkColor = col
            Case UCase(trans("Цвет посещенной ссылки"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.VisitedLinkColor = col
            Case UCase(trans("Начало ссылки"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) < 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.LinkStart = value
            Case UCase(trans("Длинна ссылки"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.LinkLength = value
            Case UCase(trans("Стиль подчеркивания"))
                value = NikakoiEsli(value)
                Dim ind As Integer = LinkBehaviors.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWLinkBehaviors) : Return es
                obj.Props.LinkBehavior = value
            Case UCase(trans("Ссылка посещена"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.LinkVisited = value
            Case UCase(trans("Ссылка рабочая"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.LinkEnabled = value
            Case UCase(trans("Переходить в интернет по ссылке"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.InternetLink = value

                ' текстовый документ
            Case UCase(trans("Подсвечивать ссылки"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.DetectUrls = value
            Case UCase(trans("Позволить перенос выделенного"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.EnableAutoDragDrop = value
            Case UCase(trans("Масштаб"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.ZoomFactor = value
            Case UCase(trans("RTF код документа"))
                obj.Props.Rtf = value
            Case UCase(trans("Выделенный RTF"))
                obj.Props.SelectedRtf = value
            Case UCase(trans("Выделенный задний фон"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.SelectionBackColor = col
            Case UCase(trans("Выделенный цвет текста"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.SelectionColor = col
            Case UCase(trans("Выделенное положение текста"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TextPositions.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTextPositions) : Return es
                obj.Props.SelectionAlignment = value
            Case UCase(trans("Выделенный размер красной строки"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SelectionHangingIndent = value
            Case UCase(trans("Выделенный отступ слева"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SelectionIndent = value
            Case UCase(trans("Выделенный отступ справа"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SelectionRightIndent = value
            Case UCase(trans("Выделенный имеет маркер"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionBullet = value
            Case UCase(trans("Выделенное вертикальное смещение"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.SelectionCharOffset = value
            Case UCase(trans("Выделенный Шрифт"))
                value = NikakoiEsli(value)
                If value = trans("Никакой") Then Return es
                Dim ind As Integer = Fonts.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWFonts) : Return es
                obj.Props.SelectionFontFamily = value
            Case UCase(trans("Выделенный Шрифт жирный"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionFontBold = value
            Case UCase(trans("Выделенный Шрифт курсив"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionFontItalic = value
            Case UCase(trans("Выделенный Шрифт подчеркнутый"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionFontUnderline = value
            Case UCase(trans("Выделенный Шрифт зачеркнутый"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionFontStrikeOut = value
            Case UCase(trans("Выделенный Шрифт размер"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.SelectionFontSize = value
            Case UCase(trans("Выделенный текст заблокирован"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.SelectionProtected = value
            Case UCase(trans("Сохранить документ"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.SaveFile(args)
            Case UCase(trans("Открыть документ"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.OpenFile(args)

                ' диалоги
            Case UCase(trans("Выбранный цвет"))
                value = NikakoiEsli(value)
                Dim col = ToMyColor(FromMyColor(value, True))
                If col Is Nothing Then es.err = Errors.notCollectionCols(prop, value, HWCols) : Return es
                obj.Props.DialogColor = col
            Case UCase(trans("Позволить выбирать цвет"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowColor = value
            Case UCase(trans("Позволить выбирать подчеркивания"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowEffects = value
            Case UCase(trans("Надпись в окне"))
                obj.props.Description = value
            Case UCase(trans("Выбранная папка"))
                If value.Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(value) : Return es
                End If
                obj.props.SelectedPath = value
            Case UCase(trans("Добавлять расширение файлу"))
                obj.props.DefaultExt = value
            Case UCase(trans("Проверять наличие файла"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.CheckFileExists = value
            Case UCase(trans("Проверять наличие папки"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.CheckPathExists = value
            Case UCase(trans("Имя файла"))
                If value.Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(value) : Return es
                End If
                obj.props.FileName = value
            Case UCase(trans("Фильтр файлов"))
                obj.props.Filter = value
            Case UCase(trans("Номер фильтра"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.FilterIndex = value
            Case UCase(trans("Начальная папка"))
                If value.Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(value) : Return es
                End If
                obj.props.InitialDirectory = value
            Case UCase(trans("Заголовок"))
                obj.props.Title = value
            Case UCase(trans("Выбор нескольких файлов"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MultiSelectFiles = value
            Case UCase(trans("Текст на печать"))
                obj.props.PrintText = value
            Case UCase(trans("Объект на печать"))
                obj.props.PrintObject = value
            Case UCase(trans("Документ на печать"))
                obj.props.PrintDocument = value
            Case UCase(trans("Таблица на печать"))
                obj.props.PrintTable = value
            Case UCase(trans("Таблица в центре"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.TableOnCenter = value
            Case UCase(trans("Рисунок на печать"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("Никакой") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.PrintPicture = value
            Case UCase(trans("Интервал отсчета"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) <= 0 Then es.err = Errors.notLessEqZero(value, prop) : Return es
                obj.Props.Interval = value
            Case UCase(trans("Прошло интервалов"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.IntervalCount = value
            Case UCase(trans("Хозяин объект"))
                obj.Props.OwnerObject = value
            Case UCase(trans("Отображать в трее"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowInTray = value

                ' МЕТОДЫ
            Case UCase(trans("Обновить"))
                obj.Props.refresh()
            Case UCase(trans("Получить фокус"))
                obj.Props.Focus()
            Case UCase(trans("Перенести наперед"))
                obj.Props.BringToFront()
            Case UCase(trans("Перенести назад"))
                obj.Props.SendToBack()
            Case UCase(trans("Очистить"))
                obj.Props.clear()
            Case UCase(trans("Вырезать"))
                obj.Props.Cut()
            Case UCase(trans("Копировать"))
                obj.Props.Copy()
            Case UCase(trans("Вставить"))
                obj.Props.Paste()
            Case UCase(trans("Выделить все"))
                obj.Props.SelectAll()
            Case UCase(trans("Отменить"))
                obj.Props.Undo()
            Case UCase(trans("Повторить"))
                obj.Props.Redo()
            Case UCase(trans("Назад"))
                obj.Props.GoBack()
            Case UCase(trans("Вперед"))
                obj.Props.GoForward()
            Case UCase(trans("Домой"))
                obj.Props.GoHome()
            Case UCase(trans("Страница поиска"))
                obj.Props.GoSearch()
            Case UCase(trans("Печать"))
                obj.Props.Printing()
            Case UCase(trans("Окно параметров страницы"))
                obj.Props.ShowPageSetupDialog()
            Case UCase(trans("Окно печати"))
                obj.Props.ShowPrintDialog()
            Case UCase(trans("Окно предварительного просмотра"))
                obj.Props.ShowPrintPreviewDialog()
            Case UCase(trans("Окно свойств"))
                obj.Props.ShowPropertiesDialog()
            Case UCase(trans("Окно сохранить"))
                obj.Props.ShowSaveAsDialog()
            Case UCase(trans("Остановить"))
                obj.Props.Stop()
            Case UCase(trans("Скрыть"))
                obj.Props.Hide()
            Case UCase(trans("Закрыть"))
                obj.Props.Close()
            Case UCase(trans("Показать"))
                obj.Props.Show()
            Case UCase(trans("Очистить таблицу"))
                obj.Props.ClearTable()
            Case UCase(trans("Перейти в интернет по ссылке"))
                obj.Props.GoInternetLink()
            Case UCase(trans("Прокрутить до курсора"))
                obj.Props.ScrollToCaret()
            Case UCase(trans("Запустить окно"))
                obj.Props.ShowDialog()
            Case UCase(trans("Запустить предварительный просмотр"))
                obj.Props.ShowPrevDialog()
            Case UCase(trans("Запустить настройки страницы"))
                obj.Props.ShowPageDialog()
            Case UCase(trans("Запустить окно печати"))
                obj.Props.ShowPrinDialog()
            Case UCase(trans("Напечатать"))
                obj.Props.Print()
            Case UCase(trans("Старт"))
                obj.Props.Start()
            Case UCase(trans("Стоп"))
                obj.Props.Stop()
            Case UCase(trans("Свернуть в трей"))
                obj.Props.MinimizeToTray()
            Case UCase(trans("Развернуть из трея"))
                obj.Props.MaximizeFromTray()

                ' PATH and FILES
            Case MyZnak & UCase(trans("Скрытый"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Hider(args) = value
            Case MyZnak & UCase(trans("Только для чтения"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.FileReadOnly(args) = value
            Case MyZnak & UCase(trans("Архивный"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.archive(args) = value
            Case MyZnak & UCase(trans("Папка"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Papka(args) = value
            Case MyZnak & UCase(trans("Зашифрованный"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Encrypted(args) = value
            Case MyZnak & UCase(trans("Не индексируется"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.NotIndexer(args) = value
            Case MyZnak & UCase(trans("Системный"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Sys(args) = value
            Case MyZnak & UCase(trans("Временный"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.Temp(args) = value
            Case MyZnak & UCase(trans("Время создания"))
                Dim dat As Date = FromMyDate(value)
                If dat = Nothing Then es.err = Errors.notDate(value) : Return es
                obj.Props.CreateTime(args) = dat
            Case MyZnak & UCase(trans("Время доступа"))
                Dim dat As Date = FromMyDate(value)
                If dat = Nothing Then es.err = Errors.notDate(value) : Return es
                obj.Props.AccessTime(args) = dat
            Case MyZnak & UCase(trans("Время изменения"))
                Dim dat As Date = FromMyDate(value)
                If dat = Nothing Then es.err = Errors.notDate(value) : Return es
                obj.Props.EditTime(args) = dat
            Case MyZnak & UCase(trans("Сохранить в файле"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                args(2) = NikakoiEsli(args(2))
                obj.props.SaveInFile(args)
            Case MyZnak & UCase(trans("Добавить текст"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 3 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                args(2) = NikakoiEsli(args(2))
                obj.props.AppendText(args)
            Case MyZnak & UCase(trans("Сохранить рисунок"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Or NikakoiEsli(args(1)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                es = FileExistInArgs(args, 1, es)
                If es.err <> "" Then Return es
                obj.props.SavePicture(args)
            Case MyZnak & UCase(trans("Копировать"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Or NikakoiEsli(args(1)) = trans("Никакой") Then Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If (args(1)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(1)) : Return es
                End If
                obj.props.Copy(args)
            Case MyZnak & UCase(trans("Переименовать"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Or NikakoiEsli(args(1)) = trans("Никакой") Then Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If (args(1)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(1)) : Return es
                End If
                obj.props.Rename(args)
            Case MyZnak & UCase(trans("Переместить"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Or NikakoiEsli(args(1)) = trans("Никакой") Then Return es
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                If (args(1)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(1)) : Return es
                End If
                obj.props.Move(args)
            Case MyZnak & UCase(trans("Зашифровать"))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.props.Encrypt(args)
            Case MyZnak & UCase(trans("Расшифровать"))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.props.Decrypt(args)
            Case MyZnak & UCase(trans("Удалить"))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.props.Delete(args)
            Case MyZnak & UCase(trans("Создать папку"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NikakoiEsli(args(0)) = trans("Никакой") Then Return es
                If (args(0)).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(args(0)) : Return es
                End If
                obj.props.CreateDirectory(args)

                ' EKRAN
            Case MyZnak & UCase(trans("Рисунок рабочего стола"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("Никакой") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                End If
                obj.props.WallPaper = value
            Case MyZnak & UCase(trans("Стиль рабочего стола"))
                obj.props.DesktopStyle = value
            Case MyZnak & UCase(trans("Разрешение экрана"))
                If value.IndexOf("x") < 0 Then
                    es.err = Errors.notCollection(trans("Разрешение экрана"), value, HWDeskResolution) : Return es
                End If
                If isInteger(value.Split("x")(0)) = False Or isInteger(value.Split("x")(1)) = False Or value.Split("x")(0) = "" Or value.Split("x")(1) = "" Then
                    es.err = Errors.notCollection(trans("Разрешение экрана"), value, HWDeskResolution) : Return es
                End If
                obj.props.DesktopResolution = value
            Case MyZnak & UCase(trans("Качество цветопередачи"))
                If value = "" Or isInteger(value) = False Then
                    Dim strs() As String = {"8", "16", "32"}
                    es.err = Errors.notCollection(trans("Качество цветопередачи"), value, strs) : Return es
                End If
                obj.props.DesktopBits = value
            Case MyZnak & UCase(trans("Частота экрана"))
                If value = "" Or isInteger(value) = False Then
                    es.err = Errors.notInt(value, trans("Частота экрана")) : Return es
                End If
                obj.props.DesktopFrequency = value
            Case MyZnak & UCase(trans("Заставка"))
                If NikakoiEsli(value) = trans("Никакой") Then value = trans("Никакой")
                If (value).Split(IO.Path.GetInvalidPathChars).Length > 1 Then
                    es.err = Errors.InvalidPathChars(value) : Return es
                End If
                obj.props.ScreenSaver = value
            Case MyZnak & UCase(trans("Сделать скриншот"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If NetTakNet(args(0)) = trans("Никакой") Then es.err = Errors.notDaOrNet(args(0)) : Return es
                args(0) = NetTakNet(args(0))
                obj.Props.ScreenshotToClipboard(args)
            Case MyZnak & UCase(trans("Сделать скриншот объекта"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.ScreenshotOfObjectToClipboard(args)


                ' MEDIA
            Case UCase(trans("Файл проигрывания"))
                value = GetMaxPath(value)
                If IsHttpCompil = False Then
                    If IO.File.Exists(value) = False And value <> trans("Никакой") Then
                        es.err = Errors.notFile(value) : Return es
                    End If
                    If MyObj.isRun = False Then value = copyImage(value)
                End If
                obj.Props.FileNamePlayed = value
            Case UCase(trans("Проигрывается"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Played = value
            Case UCase(trans("Громкость"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                If Int(value) > 2000 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.Volume = value
            Case UCase(trans("Баланс"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                If Int(value) > 2000 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.Balance = value
            Case UCase(trans("Звук отключен"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Mute = value
            Case UCase(trans("Скорость"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                If Int(value) > 2000 Then es.err = Errors.notInt(value, prop) : Return es
                obj.Props.Speed = value
            Case UCase(trans("Позиция проигрывания"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.PlayPosition = value
            Case UCase(trans("Проигралось времени"))
                Dim ts As TimeSpan = FromMyTimeSpan(value)
                If ts = TimeSpan.MaxValue Then es.err = Errors.notTime(value) : Return es
                obj.Props.PlayTime = value
            Case UCase(trans("Плей"))
                obj.Props.PlayMovie()
            Case UCase(trans("Открыть медиафайл"))
                es = FileExistInArgs(args, 0, es)
                If es.err <> "" Then Return es
                obj.Props.OpenMovie(args)
            Case UCase(trans("Закрыть файл"))
                obj.Props.CloseMovie()
            Case UCase(trans("Стоп медиа"))
                obj.Props.StopMovie()
            Case UCase(trans("Пауза"))
                obj.Props.PauseMovie()

                ' SYSTEM
            Case MyZnak & UCase(trans("Мышь X"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MouseX = value
            Case MyZnak & UCase(trans("Мышь Y"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                obj.Props.MouseY = value
            Case MyZnak & UCase(trans("Клавиша клавиатуры"))
                es = UbratKovich(value)
                If es.err <> "" Then Return es
                obj.Props.KeyBoardKey = es.str
            Case MyZnak & UCase(trans("Нажат альт"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.KeyboardAlt = value
            Case MyZnak & UCase(trans("Нажат шифт"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.KeyboardShift = value
            Case MyZnak & UCase(trans("Нажат контрол"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.KeyboardControl = value
            Case MyZnak & UCase(trans("Нажата мыши левая"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MouseLeft = value
            Case MyZnak & UCase(trans("Нажата мыши правая"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MouseRight = value
            Case MyZnak & UCase(trans("Вращается колесико"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.MouseWheel = value
            Case MyZnak & UCase(trans("Рисунок буфера обмена"))
                es = FileExistInArgs(value, es)
                If es.err <> "" Then Return es
                obj.Props.ClipboardPicture = value
            Case MyZnak & UCase(trans("Текст буфера обмена"))
                obj.Props.ClipboardText = value
            Case MyZnak & UCase(trans("Выполнить"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.Run(args)
            Case MyZnak & UCase(trans("Очистить буфер обмена"))
                obj.Props.ClipboardClear()
            Case MyZnak & UCase(trans("Вращать колесико"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If Iz.isInteger(args(0)) = False Then es.err = Errors.notInt(args(0), prop) : Return es
                obj.Props.WheelRun(args)
            Case MyZnak & UCase(trans("Выключить компьютер"))
                obj.Props.ShutDown()
            Case MyZnak & UCase(trans("Перезагрузить компьютер"))
                obj.Props.Restart()
            Case MyZnak & UCase(trans("Набрать текст"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.TypeText(args)
            Case MyZnak & UCase(trans("Процесс убить"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.KillProcess(args)
            Case MyZnak & UCase(trans("Окно в фокусе"))
                obj.Props.WindowInFocus = value



                ' REGYSTRI
            Case UCase(MyZnak & trans("Значение реестра"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.Key(args) = value
            Case UCase(MyZnak & trans("Удалить значение"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.DeleteKey(args)
            Case UCase(MyZnak & trans("Удалить папку"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.DeleteSubKey(args)
            Case UCase(MyZnak & trans("Создать подпапку"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.CreateSubKey(args)
            Case UCase(MyZnak & trans("Создать ключ"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If GetRegistryKey(args(0), "") Is Nothing Then es.err = Errors.notRegistry(args(0)) : Return es
                obj.Props.CreateKey(args)

                ' SOOBSHENIE
            Case MyZnak & UCase(trans("Запустить сообщение"))
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
            Case MyZnak & UCase(trans("Изменить время компьютера"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SetSystemData(args)

                ' RASSHIR
            Case MyZnak & UCase(trans("Выполнить код VBScript"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.runVBScript(args)
            Case MyZnak & UCase(trans("Выполнить код Алгоритма2"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.runAlgoritm2(args)
            Case MyZnak & UCase(trans("Выполнить код VBNet"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.runVBNet(args)
            Case MyZnak & UCase(trans("Выполнить код CSharp"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.runCSharp(args)

                ' PRERIVANIYA
            Case UCase(MyZnak & trans("Завершить программу")) : Return obj.Props.BreakApplication
            Case UCase(MyZnak & trans("Завершить событие")) : Return obj.Props.BreakEvent
            Case UCase(MyZnak & trans("Завершить цикл")) : Return obj.Props.BreakLoop
            Case UCase(MyZnak & trans("Завершить условие")) : Return obj.Props.StopIf
            Case UCase(MyZnak & trans("Пропускать ошибки")) : Return obj.Props.IgnoreErrors

                ' КАЛЕНДАРЬ
            Case UCase(trans("Формат даты"))
                value = NikakoiEsli(value)
                Dim ind As Integer = DateFormats.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWDateFormats) : Return es
                obj.Props.CalendarDateFormat = value
            Case UCase(trans("Формат даты по выбору"))
                obj.Props.CustomDateFormat = value
            Case UCase(trans("Кнопки вверх вниз"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ShowUpDown = value
            Case UCase(trans("Выбранная дата"))
                obj.Props.SelectedDate = value

                ' БЕГУНОК
            Case UCase(trans("Сдвиг большой"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.LargeChange = value
            Case UCase(trans("Сдвиг малый"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.SmallChange = value
            Case UCase(trans("Максимум"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Maximum = value
            Case UCase(trans("Минимум"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.Minimum = value
            Case UCase(trans("Стиль бегунка"))
                value = NikakoiEsli(value)
                Dim ind As Integer = TickStyles.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWTickStyles) : Return es
                obj.Props.TickStyle = value
            Case UCase(trans("Частота отметок"))
                value = NullTakNull(value)
                If Iz.isDouble(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.TickFrequency = value



                ' ТРИАЛ
            Case UCase(trans("Текст кнопки"))
                obj.Props.TextButton = value
            Case UCase(trans("Текст поля"))
                obj.Props.TextField = value
            Case UCase(trans("Сообщение успешной активации"))
                obj.Props.MessageValid = value
            Case UCase(trans("Сообщение неудачной активации"))
                obj.Props.MessageInValid = value
            Case UCase(trans("ID пользователя"))
                obj.Props.IdUser = value
            Case UCase(trans("ID программы"))
                obj.Props.IdProgram = value
            Case UCase(trans("ID в реестре"))
                obj.Props.IdRegistryProgram = value
            Case UCase(trans("Ключ шифрования"))
                obj.Props.KeyEncryption = value
            Case UCase(trans("Дней триала всего"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.DaysAll = value
            Case UCase(trans("Активирована"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.Activation() = value
            Case UCase(trans("Триальный период запущен"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.TrialStarted() = value
            Case UCase(trans("Ключ активации выдать"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.KeyIssue(args)
            Case UCase(trans("Ключ активации проверить"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.KeyValidation(args)
            Case UCase(trans("Триальный период запустить"))
                obj.Props.TrialStart()
            Case UCase(trans("Активацию отменить"))
                obj.Props.ActivationCancel()


                ' ClientServer
            Case UCase(trans("Файл отправляется")) : obj.Props.FileIsSent() = value
            Case UCase(trans("Скрыть отправку файлов")) : obj.Props.HideSendingFiles() = value
            Case UCase(trans("Скрыть отправку текста")) : obj.Props.HideSendingText() = value
            Case UCase(trans("Скрыть список")) : obj.Props.HideComboBox() = value
            Case UCase(trans("Обозначение команд")) : obj.Props.CommandSymbol() = value
            Case UCase(trans("Принятая команда")) : obj.Props.ReceivedCommand() = value
            Case UCase(trans("Принятый текст")) : obj.Props.ReceivedText() = value
            Case UCase(trans("Принятый файл")) : obj.Props.ReceivedFile() = value
            Case UCase(trans("Отправленная команда")) : obj.Props.SentCommand() = value
            Case UCase(trans("Отправленый текст")) : obj.Props.SentText() = value
            Case UCase(trans("Отправленый файл")) : obj.Props.SentFile() = value
            Case UCase(trans("Имя в сети"))
                Try
                    obj.Props.NameInNetwork() = value
                Catch ex As Exception
                    es.err = ex.Message : Return es
                End Try
            Case UCase(trans("IP для соединения")) : obj.Props.RemoteHost() = value
            Case UCase(trans("Порт для соединения")) : obj.Props.RemotePort() = value
            Case UCase(trans("Папка для загрузок")) : obj.Props.PathForDownloads() = value
            Case UCase(trans("Тип клиент сервера")) : obj.Props.ClientServerType() = value
            Case UCase(trans("Имена клиентов")) : obj.Props.ClientsNames() = value
            Case UCase(trans("Текст поля ввода")) : obj.Props.TextBoxString() = value
            Case UCase(trans("Текст поля лога")) : obj.Props.TextBoxLog() = value
            Case UCase(trans("Ip клиентов")) : obj.Props.ClientsIPs() = value
            Case UCase(trans("Ip клиента"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.GetClientIp(args)
                ' методы ClientServer
            Case UCase(trans("Отправить серверу"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendToServer(args)
            Case UCase(trans("Отправить файл серверу"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendFileToServer(args)
            Case UCase(trans("Отправить клиентам"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendToClients(args)
            Case UCase(trans("Отправить клиентам кроме"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendToClientsBut(args)
            Case UCase(trans("Отправить клиенту"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendToClient(args)
            Case UCase(trans("Отправить файл клиентам"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendFileToClients(args)
            Case UCase(trans("Отправить файл клиентам кроме"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendFileToClientsBut(args)
            Case UCase(trans("Отправить файл клиенту"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.SendFileToClient(args)
            Case UCase(trans("Добавить в лог"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.Log(args)
            Case UCase(trans("Выполнить команду"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.RunCommand(args)
            Case UCase(trans("Соединиться с сервером")) : obj.Props.ConnectToServer()
            Case UCase(trans("Создать сервер")) : obj.Props.CreateServer()
            Case UCase(trans("Начать прослушку")) : obj.Props.BeginListen()
            Case UCase(trans("Отключить сервер")) : obj.Props.CloseServer()
            Case UCase(trans("Отключить прослушку")) : obj.Props.CloseListener()
            Case UCase(trans("Отключиться")) : obj.Props.CloseClient()

                ' Internet
            Case UCase(trans("Удерживать соединение"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.KeepAlive = value
            Case UCase(trans("Автоматически перенаправляться"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.AllowAutoRedirect = value
            Case UCase(trans("Скачивается файл"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.FileDownloading = value
            Case UCase(trans("Скачка пауза"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.DownloadPause = value
            Case UCase(trans("Ссылка запроса")) : obj.Props.UrlToGo = value
            Case UCase(trans("Ссылка откуда пришли")) : obj.Props.UrlReferer = value
            Case UCase(trans("Ссылка перенаправления")) : obj.Props.UrlRedirect = value
            Case UCase(trans("Тип браузера")) : obj.Props.UserAgent = value
            Case UCase(trans("Принимать")) : obj.Props.Accept = value
            Case UCase(trans("Прокси IP")) : obj.Props.ProxyIp = value
            Case UCase(trans("Прокси порт"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.ProxyPort = value
            Case UCase(trans("Кодировка страницы")) : obj.Props.EncodingPage = value
            Case UCase(trans("Язык страницы")) : obj.Props.LanguagePage = value
            Case UCase(trans("Содержимое запроса")) : obj.Props.ContentQuery = value
            Case UCase(trans("Тип содержимого")) : obj.Props.ContentType = value
            Case UCase(trans("Метод запроса")) : obj.Props.HttpMethod = value
            Case UCase(trans("Таймаут"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.TimeOut = value
            Case UCase(trans("Время задержки"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.TimeDelay = value
            Case UCase(trans("Размер буфера"))
                value = NullTakNull(value)
                If Iz.isInteger(value) = False Then
                    es.err = Errors.notInt(value, prop) : Return es
                Else : value = Int(value) : End If
                If Int(value) < 0 Then es.err = Errors.notLessZero(value, prop) : Return es
                obj.Props.BufferSize = value
            Case UCase(trans("Куки запросов")) : obj.Props.CookiesQueries = value
            Case UCase(trans("Результат запроса")) : obj.Props.ResultQuery = value
                ' методы интернета 
            Case UCase(trans("Получить код страницы"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 1 Then es.err = Errors.noArguments(prop) : Return es
                obj.Props.GetSourceCodePage(args)
            Case UCase(trans("Скачать файл"))
                If args Is Nothing Then es.err = Errors.noArguments(prop) : Return es
                If args.Length < 2 Then es.err = Errors.noArguments(prop) : Return es
                If NetTakNet(args(1)) = trans("Никакой") Then es.err = Errors.notDaOrNet(args(1)) : Return es
                args(1) = NetTakNet(args(1))
                obj.Props.DownloadFile(args)
            Case UCase(trans("Выполнить запрос")) : obj.Props.ExecuteQuery()
            Case UCase(trans("Очистить куки")) : obj.Props.ClearCookie()
            Case UCase(trans("Скачка отменить")) : obj.Props.DownloadCancel()
            Case UCase(trans("Скачка возобновить")) : obj.Props.DownloadResume()

            Case UCase(trans("Стиль загрузки"))
                value = NikakoiEsli(value)
                Dim ind As Integer = StylesProgress.IndexOfKey(LCase(value))
                If ind = -1 Then es.err = Errors.notCollection(prop, value, HWStylesProgress) : Return es
                obj.Props.StyleProgress = value
            Case UCase(trans("Скорость анимации")) : obj.Props.MarqueeAnimationSpeed = value
            Case UCase(trans("Шаг загрузки")) : obj.Props.StepProgress = value
            Case UCase(trans("Справа налево"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.RightToLeftLayout = value
            Case MyZnak & UCase(trans("Открыть папку"))
                obj.Props.OpenDirectory(args)
            Case UCase(trans("Справа налево"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.RightToLeftLayout = value
            Case UCase(trans("Запретить минимизировать"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ForbidMinimize = value
            Case UCase(trans("Запретить разворачивать"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.ForbidMaximize = value
            Case UCase(trans("Ассоциировать с расширениями"))
                obj.Props.AssociateWithExtensions = value
            Case UCase(trans("Ассоциированый принятый файл"))
                obj.Props.AssociationPassedFile = value
            Case UCase(trans("На весь экран"))
                If NetTakNet(value) = trans("Никакой") Then es.err = Errors.notDaOrNet(value) : Return es
                value = NetTakNet(value)
                obj.Props.OnFullScreen = value




            Case Else

                ' Может это метод полезного объекта "Вызвать событие"
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

                ' В ОСТАВШИХСЯ СЛУЧАЯХ
                es.err = "!"
        End Select
        Return es
    End Function

    ' ТОЛЬКО ДЛЯ ЧТЕНИЯ
    Sub SetReadOnlys()
        ' Создание списка свойств ТОЛЬКО ДЛЯ ЧТЕНИЯ
        Dim TempRO() As String = {UCase(trans("В фокусе")), UCase(trans("Тип")), _
            UCase(MyZnak & trans("Существует файл")), UCase(MyZnak & trans("Существует папка")), _
            UCase(MyZnak & trans("Получить файлы")), UCase(MyZnak & trans("Получить папки")), _
            UCase(MyZnak & trans("Определить корневую")), UCase(MyZnak & trans("Поиск файлов")), _
            UCase(MyZnak & trans("Определить родительскую")), UCase(MyZnak & trans("Получить диски")), _
            UCase(MyZnak & trans("Определить имя папки")), UCase(MyZnak & trans("Определить имя файла")), _
            UCase(MyZnak & trans("Определить расширение")), UCase(MyZnak & trans("Определить без расширения")), _
            UCase(trans("Длительность общая")), UCase(trans("Длительность время")), _
            UCase(trans("Оригинальная вышина")), UCase(trans("Оригинальная ширина")), _
            UCase(MyZnak & trans("Вращается колесико")), _
            UCase(MyZnak & trans("Ключ существует")), UCase(MyZnak & trans("Папка существует")), _
            UCase(MyZnak & trans("Тип ключа")) _
            , UCase(trans("Номер символа по координатам")), UCase(trans("Номер первого символа строки")) _
            , UCase(trans("Номер первого символа текущей строки")), UCase(trans("Номер строки по номеру символа")) _
            , UCase(trans("X по номеру символа")), UCase(trans("Y по номеру символа")) _
            , UCase(trans("Строка")), UCase(trans("Количество строк")), UCase(trans("Браузер offline")) _
            , UCase(trans("Символ")), UCase(trans("Количество символов")), UCase(trans("Родительское меню")) _
            , UCase(trans("Назад возможно")), UCase(trans("Вперед возможно")), UCase(trans("Родительский пункт")) _
            , UCase(trans("Заголовок страницы")), UCase(trans("Тип страницы")), UCase(trans("Браузер занят")) _
            , UCase(trans("Статус готовности")), UCase(trans("Статусная строка")), UCase(trans("Кодировка по умолчанию")) _
            , UCase(trans("Высота заголовка")), UCase(trans("Номер выделенной закладки")) _
            , UCase(trans("Номер первой строки")), UCase(trans("Номер последней строки")) _
            , UCase(trans("Номер следующей строки")), UCase(trans("Номер предыдущей строки")) _
            , UCase(trans("Значение по координатам")), UCase(trans("Номер строки по координатам")) _
            , UCase(trans("Номер столбца по координатам")) _
            , UCase(trans("Высота записей списка")), UCase(trans("Количество записей")) _
            , UCase(trans("Номера отмеченых записей")), UCase(trans("Отмеченные записи")) _
            , UCase(trans("Была нажата отмена")) _
            , UCase(trans("Количество выделенных строк")), UCase(trans("Количество выделенных столбцов")) _
            , UCase(trans("Дней триала осталось")), UCase(trans("ID пользователя")) _
            , UCase(trans("Примечание")) _
            , UCase(MyZnak & trans("Символ по номеру")), UCase(MyZnak & trans("Сравнить тексты")) _
            , UCase(MyZnak & trans("Поиск в тексте")) _
            , UCase(MyZnak & trans("Поиск номера строки")), UCase(MyZnak & trans("Поиск с учетом регистра")) _
            , UCase(MyZnak & trans("Поиск в тексте с конца")), UCase(MyZnak & trans("Поиск с регулярными выражениями")) _
            , UCase(MyZnak & trans("Количество символов")), UCase(MyZnak & trans("Разбить на части")) _
            , UCase(MyZnak & trans("Взять кусок текста")), UCase(MyZnak & trans("Количество частей текста")) _
            , UCase(MyZnak & trans("Кавычки убрать")), UCase(MyZnak & trans("Кавычками обособить")) _
            , UCase(MyZnak & trans("Поиск без кавычек")), UCase(MyZnak & trans("Разбить на части без кавычек")) _
            , UCase(MyZnak & trans("Текст содержит")), UCase(MyZnak & trans("Текст не содержит")) _
            , UCase(MyZnak & trans("Строка по номеру")), UCase(MyZnak & trans("Количество строк")) _
            , UCase(MyZnak & trans("Вставить символы в текст")), UCase(MyZnak & trans("Удалить кусок текста")) _
            , UCase(MyZnak & trans("Заменить")), UCase(MyZnak & trans("Заменить все")) _
            , UCase(MyZnak & trans("Сделать буквы прописными")), UCase(MyZnak & trans("Сделать буквы заглавными")) _
            , UCase(MyZnak & trans("Убрать пробелы")), UCase(MyZnak & trans("Убрать пробелы в начале")) _
            , UCase(MyZnak & trans("Убрать пробелы в конце")) _
            , UCase(MyZnak & trans("Количество частей без кавычек")) _
            , UCase(MyZnak & trans("Была нажата Отмена")), UCase(MyZnak & trans("Была нажата Ок")) _
            , UCase(MyZnak & trans("Была нажата Повторить")), UCase(MyZnak & trans("Была нажата Да")) _
            , UCase(MyZnak & trans("Была нажата Нет")), UCase(MyZnak & trans("Была нажата Прервать")) _
            , UCase(MyZnak & trans("Была нажата Пропустить")), UCase(MyZnak & trans("Была нажата Справка")) _
            , UCase(MyZnak & trans("День месяца")), UCase(MyZnak & trans("День года")) _
            , UCase(MyZnak & trans("День в неделе")), UCase(MyZnak & trans("Час")) _
            , UCase(MyZnak & trans("Минута")), UCase(MyZnak & trans("Секунда")) _
            , UCase(MyZnak & trans("Квартал")), UCase(MyZnak & trans("Неделя в году")) _
            , UCase(MyZnak & trans("Год")), UCase(MyZnak & trans("Месяц")) _
            , UCase(MyZnak & trans("Секунд всего в дате")), UCase(MyZnak & trans("Дней в месяце")) _
            , UCase(MyZnak & trans("Сейчас")), UCase(MyZnak & trans("Сегодня")) _
            , UCase(MyZnak & trans("Прибавить дни")), UCase(MyZnak & trans("Прибавить часы")) _
            , UCase(MyZnak & trans("Прибавить минуты")), UCase(MyZnak & trans("Прибавить секунды")) _
            , UCase(MyZnak & trans("Прибавить кварталы")), UCase(MyZnak & trans("Прибавить недели")) _
            , UCase(MyZnak & trans("Прибавить годы")), UCase(MyZnak & trans("Прибавить месяцы")) _
            , UCase(MyZnak & trans("Разница в днях")), UCase(MyZnak & trans("Разница в часах")) _
            , UCase(MyZnak & trans("Разница в минутах")), UCase(MyZnak & trans("Разница в секундах")) _
            , UCase(MyZnak & trans("Разница в кварталах")), UCase(MyZnak & trans("Разница в неделях")) _
            , UCase(MyZnak & trans("Разница в годах")), UCase(MyZnak & trans("Разница в месяцах")) _
            , UCase(MyZnak & trans("День недели")), UCase(MyZnak & trans("Название месяца")) _
            , UCase(MyZnak & trans("Дата в определенном формате")), UCase(trans("Найти номер записи")) _
            , UCase(MyZnak & trans("Текст состоит из")), UCase(MyZnak & trans("Текст есть число")) _
            , UCase(MyZnak & trans("Текст есть цифры")), UCase(MyZnak & trans("Определить размер файла")) _
            , UCase(MyZnak & trans("Открыть файл")), UCase(MyZnak & trans("Выполнить с результатом")) _
            , UCase(MyZnak & trans("Зашифровать текст")), UCase(MyZnak & trans("Расшифровать текст")) _
            , UCase(MyZnak & trans("Количество файлов")), UCase(MyZnak & trans("Количество папок")) _
            , UCase(MyZnak & trans("Выполнить с результатом")) _
            , UCase(MyZnak & trans("Процессы системы")), UCase(MyZnak & trans("Окна системы")) _
            , UCase(MyZnak & trans("Скриншот")), UCase(MyZnak & trans("Скриншот объекта")) _
            , UCase(trans("Наличие соединения")) _
            , UCase(trans("Имена клиентов")), UCase(trans("Ip клиентов")), UCase(trans("Ip клиента")) _
            , UCase(trans("Длинна содержимого")), UCase(trans("Код результата")), UCase(trans("Заголовки запроса")) _
            , UCase(trans("Ассоциированый принятый файл")) _
            , UCase(trans("Поиск в таблице")), UCase(trans("Поиск в выделеных ячейках")) _
        }
        ReadOnlyProps = TempRO

        ' Создание списка свойств ТОЛЬКО ДЛЯ ЧТЕНИЯ,которым обязательны аргументы(можно использовать тока в запущеном проекте)
        Dim TempMCP() As String = { _
            trans("Номер символа по координатам").ToUpper, trans("Номер первого символа строки").ToUpper _
            , trans("Номер первого символа текущей строки").ToUpper, trans("Номер строки по номеру символа").ToUpper _
            , trans("X по номеру символа").ToUpper, trans("Y по номеру символа").ToUpper _
            , trans("Строка").ToUpper, trans("Символ").ToUpper _
            , trans("Запись по номеру").ToUpper, trans("Найти номер записи").ToUpper _
            , trans("Ключ активации выдать").ToUpper, trans("Ключ активации проверить").ToUpper _
            , trans("Ip клиента").ToUpper _
            , trans("Поиск в таблице").ToUpper, trans("Поиск в выделеных ячейках").ToUpper _
        }
        MayChangeProps = TempMCP

        ' Аргументы, у которых есть Тип, отличный от Текст
        Dim tempArgTypes() As String = {UCase(trans("Сортировать по возрастанию")), _
            UCase(trans("Область выборки")), UCase(trans("Кнопки сообщения")), UCase(trans("Тип сообщения")), _
            UCase(trans("Тип базы данных")), UCase(trans("Место для записи в списке")), _
            UCase(trans("Кодировка текста")), UCase(trans("Показать в окне")), _
            UCase(trans("Номера строк через запятую")), UCase(trans("Номера столбцов через запятую")), _
            UCase(trans("Тип файла")), UCase(trans("Ждать пока скачается")), _
            UCase(trans("C учетом регистра")), UCase(trans("Слово целиком")), _
            UCase(trans("Объект съемки")), UCase(trans("Только активное окно")) _
        }
        ArgTypes = tempArgTypes

        ' Создание списка свойств СОБЫТИЙ, которые НЕ ДЛЯ ЧТЕНИЯ
        Dim TempSnRO() As String = {UCase(MyZnak & trans("Отменить перемещение")), UCase(MyZnak & trans("Отменить ввод")) _
            , UCase(MyZnak & trans("Отменить в новом окне")), UCase(MyZnak & trans("Отменить событие"))}
        SobytsNotReadOnly = TempSnRO

        ' Создание списка свойств, которые не надо считать за свойства и не надо сохранять их при сохранении проекта
        Dim TempNoSaveProps() As String = {UCase(trans("Выделенный RTF")), UCase(trans("Выделенное положение текста")) _
            , UCase(trans("Выделенный задний фон")), UCase(trans("Выделенный цвет текста")) _
            , UCase(trans("Выделенный размер красной строки")), UCase(trans("Выделенный отступ слева")) _
            , UCase(trans("Выделенный отступ справа")), UCase(trans("Выделенный имеет маркер")) _
            , UCase(trans("Выделенное вертикальное смещение")), UCase(trans("Выделенный шрифт размер")) _
            , UCase(trans("Выделенный шрифт")), UCase(trans("Выделенный шрифт жирный")), UCase(trans("Выделенный шрифт курсив")) _
            , UCase(trans("Выделенный шрифт подчеркнутый")), UCase(trans("Выделенный шрифт зачеркнутый")) _
            , UCase(trans("Выделенный текст заблокирован")) _
            , UCase(trans("Триальный период запущен")), UCase(trans("Активирована")) _
       }
        NoSaveProps = TempNoSaveProps

    End Sub

    ' ВОЗВРАЩАЕТ ТИП ТОГО, ИЛИ ИНОГО СВОЙСТВА
    Public Function GetTypeProperty(ByVal prop As String) As String
        prop = UCase(prop)

        If prop = UCase(trans("Текст")) Or prop = UCase(trans("Имя")) Or prop = UCase(trans("Вспомогательное поле")) _
        Or prop = MyZnak & UCase(trans("Время создания")) Or prop = MyZnak & UCase(trans("Время доступа")) _
        Or prop = MyZnak & UCase(trans("Время изменения")) _
        Or prop = UCase(trans("Длительность время")) Or prop = UCase(trans("Проигралось времени")) _
        Or prop = UCase(trans("Строка")) Or prop = UCase(trans("Символ")) _
        Or prop = UCase(trans("Выделенный текст")) Or prop = UCase(trans("Символ пароля")) _
        Or prop = MyZnak & UCase(trans("Значение реестра")) Or prop = UCase(trans("Всплывающая подсказка")) _
        Or prop = UCase(trans("Текст страницы")) Or prop = UCase(trans("Заголовок страницы")) _
        Or prop = UCase(trans("Тип страницы")) Or prop = UCase(trans("Куки")) _
        Or prop = UCase(trans("Статусная строка")) Or prop = UCase(trans("Ссылка")) Or prop = UCase(trans("Значение")) _
        Or prop = UCase(trans("Столбцы")) Or prop = UCase(trans("Строки")) _
        Or prop = UCase(trans("Номера выделенных строк")) Or prop = UCase(trans("Номера выделенных столбцов")) _
        Or prop = UCase(trans("Значение ячейки")) Or prop = UCase(trans("Значение по координатам")) _
        Or prop = UCase(trans("Записи списка")) Or prop = UCase(trans("Выделенная запись")) _
        Or prop = UCase(trans("Запись по номеру")) Or prop = UCase(trans("Ссылка надписи")) _
        Or prop = UCase(trans("Номера отмеченых записей")) Or prop = UCase(trans("Отмеченные записи")) _
        Or prop = UCase(trans("Номера выделенных записей")) Or prop = UCase(trans("Выделенные записи")) _
        Or prop = UCase(trans("RTF код документа")) Or prop = UCase(trans("Выделенный RTF")) _
        Or prop = UCase(trans("Надпись в окне")) Or prop = UCase(trans("Выбранная папка")) _
        Or prop = UCase(trans("Добавлять расширение файлу")) Or prop = UCase(trans("Имя файла")) _
        Or prop = UCase(trans("Фильтр файлов")) Or prop = UCase(trans("Выделенный RTF")) _
        Or prop = UCase(trans("Начальная папка")) Or prop = UCase(trans("Заголовок")) _
        Or prop = UCase(trans("Текст на печать")) _
        Or prop = UCase(trans("Родительское меню")) Or prop = UCase(trans("Родительский пункт")) _
        Or prop = MyZnak & UCase(trans("Символ по номеру")) Or prop = MyZnak & UCase(trans("Разбить на части")) _
        Or prop = MyZnak & UCase(trans("Взять кусок текста")) Or prop = MyZnak & UCase(trans("Кавычки убрать")) _
        Or prop = MyZnak & UCase(trans("Кавычками обособить")) Or prop = MyZnak & UCase(trans("Разбить на части без кавычек")) _
        Or prop = MyZnak & UCase(trans("Строка по номеру")) Or prop = MyZnak & UCase(trans("Вставить символы в текст")) _
        Or prop = MyZnak & UCase(trans("Удалить кусок текста")) Or prop = MyZnak & UCase(trans("Заменить")) _
        Or prop = MyZnak & UCase(trans("Заменить все")) Or prop = MyZnak & UCase(trans("Сделать буквы прописными")) _
        Or prop = MyZnak & UCase(trans("Сделать буквы заглавными")) Or prop = MyZnak & UCase(trans("Убрать пробелы")) _
        Or prop = MyZnak & UCase(trans("Убрать пробелы в начале")) Or prop = MyZnak & UCase(trans("Убрать пробелы в конце")) _
        Or prop = MyZnak & UCase(trans("Процессы системы")) Or prop = MyZnak & UCase(trans("Окна системы")) _
        Or prop = MyZnak & UCase(trans("Окно в фокусе")) _
        Or prop = UCase(trans("Тип")) Or prop = UCase(trans("Подсказка")) _
        Or prop = UCase(trans("Выбранная дата")) Or prop = UCase(trans("Формат даты по выбору")) _
        Or prop = MyZnak & UCase(trans("Время")) _
        Or prop = UCase(trans("Текст кнопки")) Or prop = UCase(trans("Сообщение успешной активации")) _
        Or prop = UCase(trans("Сообщение неудачной активации")) Or prop = UCase(trans("ID пользователя")) _
        Or prop = UCase(trans("ID программы")) Or prop = UCase(trans("ID в реестре")) _
        Or prop = UCase(trans("Ключ шифрования")) Or prop = UCase(trans("KeyEncryption")) _
        Or prop = UCase(trans("Примечание")) Or prop = UCase(trans("Текст поля")) _
        Or prop = UCase(trans("Обозначение команд")) Or prop = UCase(trans("Принятая команда")) _
        Or prop = UCase(trans("Принятый текст")) Or prop = UCase(trans("IP для соединения")) _
        Or prop = UCase(trans("Имя в сети")) Or prop = UCase(trans("Принятый файл")) _
        Or prop = UCase(trans("Порт для соединения")) Or prop = UCase(trans("Папка для загрузок")) _
        Or prop = UCase(trans("Имена клиентов")) Or prop = UCase(trans("Текст поля ввода")) _
        Or prop = UCase(trans("Текст поля лога")) Or prop = UCase(trans("Ip клиентов")) _
        Or prop = UCase(trans("Ip клиента")) _
        Or prop = UCase(trans("Отправленная команда")) Or prop = UCase(trans("Отправленый файл")) _
        Or prop = UCase(trans("Отправленый текст")) _
        Or prop = UCase(trans("Ссылка запроса")) Or prop = UCase(trans("Ссылка откуда пришли")) _
        Or prop = UCase(trans("Ссылка перенаправления")) Or prop = UCase(trans("Тип браузера")) _
        Or prop = UCase(trans("Принимать")) Or prop = UCase(trans("Прокси IP")) _
        Or prop = UCase(trans("Прокси порт")) Or prop = UCase(trans("Кодировка страницы")) _
        Or prop = UCase(trans("Язык страницы")) Or prop = UCase(trans("Содержимое запроса")) _
        Or prop = UCase(trans("Куки запросов")) Or prop = UCase(trans("Результат запроса")) _
        Or prop = UCase(trans("Ассоциированый принятый файл")) _
        Or prop = UCase(trans("Значение выделеных ячеек")) Or prop = UCase(trans("Поиск в таблице")) _
        Or prop = UCase(trans("Поиск в выделеных")) Or prop = UCase(trans("Ширина столбцов")) _
         Or prop = UCase(trans("Вышина строк")) _
      Then
            Return trans("Текст")



        ElseIf prop = UCase(trans("Главная форма")) Or prop = UCase(trans("Запретить закрытие")) _
        Or prop = UCase(trans("АвтоТроеточие")) Or prop = UCase(trans("Работает")) Or prop = UCase(trans("Видимый")) _
       Or prop = UCase(trans("Шрифт жирный")) Or prop = UCase(trans("Шрифт курсив")) _
       Or prop = UCase(trans("Шрифт зачеркнутый")) Or prop = UCase(trans("Шрифт подчеркнутый")) _
       Or prop = UCase(trans("Прокрутка1")) Or prop = UCase(trans("Прокрутка")) Or prop = UCase(trans("Прокрутка2")) _
       Or prop = UCase(trans("Фиксированный разделитель")) Or prop = UCase(trans("Панель1 скрыта")) _
       Or prop = UCase(trans("Панель2 скрыта")) Or prop = UCase(trans("В фокусе")) Or prop = UCase(trans("ТабСтоп")) _
       Or prop = UCase(trans("Скрывать выделение")) Or prop = UCase(trans("Многострочность")) _
       Or prop = UCase(trans("Только для чтения")) Or prop = UCase(trans("Перенос по словам")) _
       Or prop = MyZnak & UCase(trans("Отменить перемещение")) Or prop = MyZnak & UCase(trans("Отменить в новом окне")) _
       Or prop = MyZnak & UCase(trans("Отменить событие")) Or prop = MyZnak & UCase(trans("Отменить ввод")) _
       Or prop = MyZnak & UCase(trans("Только для чтения")) Or prop = MyZnak & UCase(trans("Скрытый")) _
       Or prop = MyZnak & UCase(trans("Архивный")) Or prop = MyZnak & UCase(trans("Папка")) _
       Or prop = MyZnak & UCase(trans("Зашифрованный")) Or prop = MyZnak & UCase(trans("Не индексируется")) _
       Or prop = MyZnak & UCase(trans("Системный")) Or prop = MyZnak & UCase(trans("Временный")) _
       Or prop = MyZnak & UCase(trans("Существует файл")) Or prop = UCase(trans("Проигрывается")) _
       Or prop = UCase(trans("Звук отключен")) Or prop = UCase(trans("Отмечено")) _
       Or prop = MyZnak & UCase(trans("Нажат альт")) Or prop = MyZnak & UCase(trans("Нажат шифт")) _
       Or prop = MyZnak & UCase(trans("Нажат контрол")) Or prop = MyZnak & UCase(trans("Нажата мыши левая")) _
       Or prop = MyZnak & UCase(trans("Нажата мыши правая")) Or prop = UCase(trans("Вращается колесико")) _
       Or prop = MyZnak & UCase(trans("Ключ существует")) Or prop = UCase(trans("Папка существует")) _
       Or prop = UCase(trans("Расположен слева")) Or prop = UCase(trans("Показывать подсказку")) _
       Or prop = UCase(trans("Отметка по клику")) Or prop = UCase(trans("Рисунок растянут")) _
       Or prop = UCase(trans("Отображать горячие клавиши")) _
       Or prop = UCase(trans("Переходить по сссылкам")) Or prop = UCase(trans("Разрешить перетаскивания")) _
       Or prop = UCase(trans("Назад возможно")) Or prop = UCase(trans("Вперед возможно")) _
       Or prop = UCase(trans("Браузер занят")) Or prop = UCase(trans("Браузер offline")) _
       Or prop = UCase(trans("Всплывающее меню браузера")) Or prop = UCase(trans("Отображать ошибки сценариев")) _
       Or prop = UCase(trans("Полосы прокрутки активны")) Or prop = UCase(trans("Горячие клавиши работают")) _
       Or prop = UCase(trans("Оконные кнопки и меню")) Or prop = UCase(trans("Показывать иконку")) _
       Or prop = UCase(trans("Отображать в панели задач")) Or prop = UCase(trans("Поверх всех окон")) _
       Or prop = UCase(trans("Позволить добавлять строки")) Or prop = UCase(trans("Позволить удалять строки")) _
       Or prop = UCase(trans("Позволить переставлять столбцы")) Or prop = UCase(trans("Позволить растягивать столбцы")) _
       Or prop = UCase(trans("Позволить растягивать строки")) Or prop = UCase(trans("Отображать заголовки столбцов")) _
       Or prop = UCase(trans("Выбор нескольких ячеек")) Or prop = UCase(trans("Только для чтения таблица")) _
       Or prop = UCase(trans("Ячейка выделена")) Or prop = UCase(trans("Строка только для чтения")) _
       Or prop = UCase(trans("Столбец только для чтения")) Or prop = UCase(trans("Ячейка только для чтения")) _
       Or prop = UCase(trans("Сортировать по возрастанию")) _
       Or prop = UCase(trans("Выбор нескольких записей")) _
       Or prop = UCase(trans("Список упрощенный")) Or prop = UCase(trans("Сортирован список")) _
       Or prop = UCase(trans("Список раскрыт")) Or prop = UCase(trans("Позволить выбирать записи")) _
       Or prop = UCase(trans("Горизонтальная прокрутка")) Or prop = UCase(trans("Многоколонность")) _
       Or prop = UCase(trans("Ссылка посещена")) Or prop = UCase(trans("Ссылка рабочая")) _
       Or prop = UCase(trans("Переходить в интернет по ссылке")) _
       Or prop = UCase(trans("Подсвечивать ссылки")) Or prop = UCase(trans("Позволить перенос выделенного")) _
       Or prop = UCase(trans("Выделенный имеет маркер")) Or prop = UCase(trans("Выделенный шрифт жирный")) _
       Or prop = UCase(trans("Выделенный шрифт курсив")) Or prop = UCase(trans("Выделенный шрифт подчеркнутый")) _
       Or prop = UCase(trans("Выделенный шрифт зачеркнутый")) Or prop = UCase(trans("Выделенный текст заблокирован")) _
       Or prop = UCase(trans("Была нажата отмена")) _
       Or prop = UCase(trans("Позволить выбирать цвет")) Or prop = UCase(trans("Позволить выбирать подчеркивания")) _
       Or prop = UCase(trans("Проверять наличие файла")) Or prop = UCase(trans("Проверять наличие папки")) _
       Or prop = UCase(trans("Выбор нескольких файлов")) Or prop = UCase(trans("Таблица в центре")) _
       Or prop = UCase(trans("Отображать специальный столбец")) Or prop = UCase(trans("Кнопки вверх вниз")) _
       Or prop = MyZnak & UCase(trans("Сравнить тексты")) Or prop = MyZnak & UCase(trans("Текст содержит")) _
       Or prop = MyZnak & UCase(trans("Текст не содержит")) _
       Or prop = MyZnak & UCase(trans("Была нажата Отмена")) Or prop = MyZnak & UCase(trans("Была нажата Ок")) _
       Or prop = MyZnak & UCase(trans("Была нажата Повторить")) Or prop = MyZnak & UCase(trans("Была нажата Да")) _
       Or prop = MyZnak & UCase(trans("Была нажата Нет")) Or prop = MyZnak & UCase(trans("Была нажата Прервать")) _
       Or prop = MyZnak & UCase(trans("Была нажата Пропустить")) Or prop = MyZnak & UCase(trans("Была нажата Справка")) _
       Or prop = MyZnak & UCase(trans("Текст состоит из")) Or prop = MyZnak & UCase(trans("Текст есть число")) _
       Or prop = MyZnak & UCase(trans("Текст есть цифры")) Or prop = UCase(trans("Активирована")) _
       Or prop = UCase(trans("Показать в окне")) Or prop = UCase(trans("Триальный период запущен")) _
       Or prop = UCase(trans("Отображать в трее")) _
       Or prop = UCase(trans("Добавить в автозагрузку")) Or prop = UCase(trans("Разрешить запуск копий")) _
       Or prop = UCase(trans("Файл отправляется")) _
       Or prop = UCase(trans("Скрыть отправку файлов")) Or prop = UCase(trans("Скрыть отправку текста")) _
       Or prop = UCase(trans("Скрыть список")) Or prop = UCase(trans("Скрыть отправку текста")) _
       Or prop = UCase(trans("Удерживать соединение")) Or prop = UCase(trans("Автоматически перенаправляться")) _
       Or prop = UCase(trans("Скачивается файл")) Or prop = UCase(trans("Скачка пауза")) _
       Or prop = UCase(trans("Ждать пока скачается")) Or prop = UCase(trans("Справа налево")) _
       Or prop = UCase(trans("Запретить минимизировать")) Or prop = UCase(trans("Запретить разворачивать")) _
       Or prop = UCase(trans("C учетом регистра")) Or prop = UCase(trans("Слово целиком")) _
        Or prop = UCase(trans("Только активное окно")) Or prop = UCase(trans("На весь экран")) _
      Then
            Return trans("ДаНет")

        ElseIf prop = UCase(trans("Фоновой рисунок")) Or prop = UCase(trans("Фоновой рисунок1")) _
                              Or prop = UCase(trans("Фоновой рисунок2")) Or prop = UCase(trans("Рисунок")) _
                              Or prop = MyZnak & UCase(trans("Рисунок рабочего стола")) _
                              Or prop = MyZnak & UCase(trans("Рисунок буфера обмена")) Or prop = UCase(trans("Иконка")) _
                              Or prop = UCase(trans("Рисунок на печать")) _
                              Then
            Return trans("Рисунок")

        ElseIf prop = UCase(trans("Файл проигрывания")) Or prop = MyZnak & UCase(trans("Заставка")) _
               Then
            Return trans("Файл")

        ElseIf prop = UCase(trans("Цвет")) Or prop = UCase(trans("Цвет1")) Or prop = UCase(trans("Цвет2")) _
        Or prop = UCase(trans("Цвет шрифта")) Or prop = UCase(trans("Прозрачный цвет рисунка")) _
        Or prop = UCase(trans("Прозрачный цвет")) Or prop = UCase(trans("Цвет сетки")) _
        Or prop = UCase(trans("Цвет фона ячеек")) Or prop = UCase(trans("Цвет фона выделенных ячеек")) _
        Or prop = UCase(trans("Цвет шрифта ячеек")) Or prop = UCase(trans("Цвет шрифта выделенных ячеек")) _
        Or prop = UCase(trans("Цвет активной ссылки")) Or prop = UCase(trans("Цвет нерабочей ссылки")) _
        Or prop = UCase(trans("Цвет ссылки")) Or prop = UCase(trans("Цвет посещенной ссылки")) _
        Or prop = UCase(trans("Выделенный задний фон")) Or prop = UCase(trans("Выделенный цвет текста")) _
        Or prop = UCase(trans("Выбранный цвет")) _
        Then
            Return trans("Цвет")

        ElseIf prop = UCase(trans("X")) Or prop = UCase(trans("Y")) Or prop = UCase(trans("Номер")) _
        Or prop = UCase(trans("Максимальная ширина")) Or prop = UCase(trans("Максимальная вышина")) _
        Or prop = UCase(trans("Минимальная ширина")) Or prop = UCase(trans("Минимальная вышина")) _
        Or prop = UCase(trans("Поле слева")) Or prop = UCase(trans("Поле сверху")) _
        Or prop = UCase(trans("Поле справа")) Or prop = UCase(trans("Поле снизу")) _
        Or prop = UCase(trans("Ширина разделителя")) Or prop = UCase(trans("Расстояние разделителя")) _
        Or prop = UCase(trans("Инкремент разделителя")) Or prop = UCase(trans("Панель1 минимум")) _
        Or prop = UCase(trans("Панель2 минимум")) _
        Or prop = UCase(trans("Ширина")) Or prop = UCase(trans("Вышина")) Or prop = UCase(trans("ТабНомер")) _
        Or prop = MyZnak & UCase(trans("Частота экрана")) Or prop = MyZnak & UCase(trans("Качество цветопередачи")) _
        Or prop = UCase(trans("Громкость")) Or prop = UCase(trans("Баланс")) Or prop = UCase(trans("Скорость")) _
        Or prop = UCase(trans("Длительность общая")) Or prop = UCase(trans("Позиция проигрывания")) _
        Or prop = UCase(trans("Оригинальная вышина")) Or prop = UCase(trans("Оригинальная ширина")) _
        Or prop = UCase(trans("Максимальная длинна")) Or prop = UCase(trans("Начало выделения")) _
        Or prop = UCase(trans("Номер символа по координатам")) Or prop = UCase(trans("Номер первого символа строки")) _
        Or prop = UCase(trans("Номер первого символа текущей строки")) _
        Or prop = UCase(trans("Номер строки по номеру символа")) Or prop = UCase(trans("Длинна выделения")) _
        Or prop = UCase(trans("X по номеру символа")) Or prop = UCase(trans("Y по номеру символа")) _
        Or prop = UCase(trans("Количество строк")) Or prop = UCase(trans("Количество символов")) _
        Or prop = UCase(trans("Оригинальная вышина")) Or prop = UCase(trans("Оригинальная ширина")) _
        Or prop = UCase(trans("Оригинальная вышина")) Or prop = UCase(trans("Оригинальная ширина")) _
        Or prop = MyZnak & UCase(trans("Мышь X")) Or prop = MyZnak & UCase(trans("Мышь Y")) _
        Or prop = UCase(trans("Прокрутка минимальная ширина")) Or prop = UCase(trans("Прокрутка минимальная вышина")) _
        Or prop = UCase(trans("Прокручено по X")) Or prop = UCase(trans("Прокручено по Y")) _
        Or prop = UCase(trans("Высота заголовка")) Or prop = UCase(trans("Прозрачность")) _
        Or prop = UCase(trans("Номер выделенной закладки")) Or prop = UCase(trans("Позиция выделенной закладки")) _
        Or prop = UCase(trans("Поле по горизонтали")) Or prop = UCase(trans("Поле по вертикали")) _
        Or prop = UCase(trans("Вышина заголовков столбцов")) Or prop = UCase(trans("Ширина столбца")) _
        Or prop = UCase(trans("Номер первой строки")) Or prop = UCase(trans("Номер последней строки")) _
        Or prop = UCase(trans("Номер следующей строки")) Or prop = UCase(trans("Номер предыдущей строки")) _
        Or prop = UCase(trans("Номер строки по координатам")) Or prop = UCase(trans("Номер столбца по координатам")) _
        Or prop = UCase(trans("Количество строк таблицы")) Or prop = UCase(trans("Количество столбцов")) _
        Or prop = UCase(trans("Высота раскрывающегося списка")) Or prop = UCase(trans("Ширина раскрывающегося списка")) _
        Or prop = UCase(trans("Высота записей списка")) Or prop = UCase(trans("Количество раскрывающихся записей")) _
        Or prop = UCase(trans("Номер выделенной записи")) Or prop = UCase(trans("Найти номер записи")) _
        Or prop = UCase(trans("Количество записей")) Or prop = UCase(trans("Ширина колонок списка")) _
        Or prop = UCase(trans("Начало ссылки")) Or prop = UCase(trans("Длинна ссылки")) _
        Or prop = UCase(trans("Масштаб")) Or prop = UCase(trans("Выделенный размер красной строки")) _
        Or prop = UCase(trans("Выделенный отступ слева")) Or prop = UCase(trans("Выделенный отступ справа")) _
        Or prop = UCase(trans("Выделенное вертикальное смещение")) Or prop = UCase(trans("Номер фильтра")) _
        Or prop = UCase(trans("Шрифт размер")) Or prop = UCase(trans("Выделенный Шрифт размер")) _
        Or prop = UCase(trans("Интервал отсчета")) Or prop = UCase(trans("Прошло интервалов")) _
        Or prop = MyZnak & UCase(trans("Поиск в тексте")) Or prop = MyZnak & UCase(trans("Поиск с учетом регистра")) _
        Or prop = MyZnak & UCase(trans("Поиск в тексте с конца")) Or prop = MyZnak & UCase(trans("Поиск с регулярными выражениями")) _
        Or prop = MyZnak & UCase(trans("Количество символов")) Or prop = MyZnak & UCase(trans("Количество частей текста")) _
        Or prop = MyZnak & UCase(trans("Поиск без кавычек")) Or prop = MyZnak & UCase(trans("Количество строк")) _
        Or prop = MyZnak & UCase(trans("Количество частей без кавычек")) _
        Or prop = UCase(trans("Сдвиг большой")) Or prop = UCase(trans("Сдвиг малый")) _
        Or prop = UCase(trans("Максимум")) Or prop = UCase(trans("Минимум")) Or prop = UCase(trans("Частота отметок")) _
        Or prop = UCase(trans("Количество выделенных строк")) Or prop = UCase(trans("Количество выделенных столбцов")) _
        Or prop = UCase(trans("Дней триала всего")) Or prop = UCase(trans("Дней триала осталось")) _
        Or prop = UCase(trans("Таймаут")) Or prop = UCase(trans("Время задержки")) _
        Or prop = UCase(trans("Размер буфера")) _
        Or prop = UCase(trans("Скорость анимации")) Or prop = UCase(trans("Шаг загрузки")) _
        Or prop = UCase(trans("Страница начала печати")) Or prop = UCase(trans("Страница конца печати")) _
        Or prop = UCase(trans("Число копий")) _
               Or prop = UCase(trans("Вышина строки")) _
  Then
            Return trans("Число")

        ElseIf prop = UCase(trans("Положение текста")) Or prop = UCase(trans("Положение рисунка")) Then
            Return trans("Положение")

        ElseIf prop = UCase(trans("Всплывающее меню")) Or prop = UCase(trans("Всплывающее меню1")) _
        Or prop = UCase(trans("Всплывающее меню2")) Or prop = UCase(trans("Вложенное всплывающее меню")) Then
            Return trans("Всплывающее меню")

        ElseIf prop = MyZnak & UCase(trans("Тип ключа")) Then
            Return trans("Тип ключа")

        ElseIf prop = UCase(trans("Расположение текста")) Or prop = UCase(trans("Выделенное положение текста")) Then
            Return trans("Расположение текста")

        Else
            Return prop
        End If
    End Function

    ' ОТОБРАЖЕНИЕ СВОЙСТВА В ЕДИТПРОПЕРТИ
    Public Sub ShowPropInEditProperty(ByVal EditPr As Object)
        peremens2.ShowPropInEditProperty(EditPr)
    End Sub

    ' ПОЛУЧИТЬ СПИСОК АРГУМЕНТОВ СВОЙСТВА ИЛИ МЕТОДА
    Public Function GetArguments(ByVal meth As String, ByVal MyObj As Object) As String()
        meth = UCase(meth)

        If meth = UCase(MyZnak & trans("Сохранить в файле")) Or meth = UCase(MyZnak & trans("Добавить текст")) Then
            Dim temp() As String = {trans("Путь к файлу"), trans("Что сохранять"), trans("Кодировка текста")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Открыть файл")) Then
            Dim temp() As String = {trans("Путь к файлу"), trans("Кодировка текста"), "неважно"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Сохранить рисунок")) Then
            Dim temp() As String = {trans("Путь к файлу"), trans("Рисунок для сохранения")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Выполнить")) Then
            Dim temp() As String = {trans("Команда Windows или имя файла"), trans("Аргументы")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Выполнить с результатом")) Then
            Dim temp() As String = {trans("Команда Windows или имя файла"), trans("Аргументы"), _
                                    trans("Кодировка текста"), "неважно"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Набрать текст")) Then
            Dim temp() As String = {trans("Симулировать набор следующего текста")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Вращать колесико")) Then
            Dim temp() As String = {trans("Размер вращения")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Поиск файлов")) Then
            Dim temp() As String = {trans("Путь к папке"), trans("Что искать"), "неважно"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Сделать скриншот")) Then
            Dim temp() As String = {trans("Только активное окно")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Скриншот")) Then
            Dim temp() As String = {trans("Только активное окно"), "неважно"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Сделать скриншот объекта")) Then
            Dim temp() As String = {trans("Объект съемки")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Скриншот объекта")) Then
            Dim temp() As String = {trans("Объект съемки"), "неважно"}
            Return temp



        ElseIf meth = UCase(MyZnak & trans("Зашифровать")) Or meth = UCase(MyZnak & trans("Расшифровать")) _
        Or meth = UCase(MyZnak & trans("Удалить")) Or meth = UCase(MyZnak & trans("Создать папку")) _
        Or meth = UCase(trans("Открыть медиафайл")) _
        Or meth = UCase(trans("Сохранить таблицу")) Or meth = UCase(trans("Открыть таблицу")) _
        Or meth = UCase(trans("Сохранить документ")) Or meth = UCase(trans("Открыть документ")) _
        Or meth = UCase(trans("Отправить файл клиентам")) Or meth = UCase(trans("Отправить файл серверу")) _
        Then
            Dim temp() As String = {trans("Путь к файлу")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Копировать")) Or meth = UCase(MyZnak & trans("Переместить")) Then
            Dim temp() As String = {trans("Путь к файлу"), trans("Новый путь к файлу")}
            Return temp


        ElseIf meth = UCase(MyZnak & trans("Скрытый")) Or meth = UCase(MyZnak & trans("Только для чтения")) _
        Or meth = UCase(MyZnak & trans("Архивный")) Or meth = UCase(MyZnak & trans("Папка")) _
        Or meth = UCase(MyZnak & trans("Зашифрованный")) Or meth = UCase(MyZnak & trans("Не индексируется")) _
        Or meth = UCase(MyZnak & trans("Системный")) Or meth = UCase(MyZnak & trans("Временный")) _
        Then
            Dim temp() As String = {trans("Путь к файлу или папке"), trans("Значение атрибута")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Существует файл")) Or meth = UCase(MyZnak & trans("Существует папка")) _
        Or meth = UCase(MyZnak & trans("Получить файлы")) Or meth = UCase(MyZnak & trans("Получить папки")) _
        Or meth = UCase(MyZnak & trans("Определить корневую")) Or meth = UCase(MyZnak & trans("Определить родительскую")) _
        Or meth = UCase(MyZnak & trans("Определить имя папки")) _
        Or meth = UCase(MyZnak & trans("Определить имя файла")) Or meth = UCase(MyZnak & trans("Определить расширение")) _
        Or meth = UCase(MyZnak & trans("Определить без расширения")) Or meth = UCase(MyZnak & trans("Определить размер файла")) _
        Then
            Dim temp() As String = {trans("Путь к файлу или папке"), "неважно"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Время создания")) Or meth = UCase(MyZnak & trans("Время доступа")) _
        Or meth = UCase(MyZnak & trans("Время изменения")) Then
            Dim temp() As String = {trans("Путь к файлу или папке"), trans("Время")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Сделать скриншот")) Then
            Dim temp() As String = {trans("Куда сохранить")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Удалить значение")) _
        Or meth = UCase(MyZnak & trans("Удалить папку")) Or meth = UCase(MyZnak & trans("Создать подпапку")) _
        Then
            Dim temp() As String = {trans("Путь реестра")}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Значение реестра")) Or meth = UCase(MyZnak & trans("Ключ существует")) _
        Or meth = UCase(MyZnak & trans("Папка существует")) Or meth = UCase(MyZnak & trans("Тип ключа")) _
        Then
            Dim temp() As String = {trans("Путь реестра"), "неважно"}
            Return temp

        ElseIf meth = UCase(MyZnak & trans("Создать ключ")) Then
            Dim temp() As String = {trans("Путь реестра"), trans("Значение ключа"), trans("Тип ключа")}
            Return temp

        ElseIf meth = UCase(trans("Номер символа по координатам")) Or meth = UCase(trans("Значение по координатам")) _
        Or meth = UCase(trans("Номер строки по координатам")) Or meth = UCase(trans("Номер столбца по координатам")) _
        Then
            Dim temp() As String = {trans("X"), trans("Y"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Номер первого символа строки")) Or meth = UCase(trans("Строка")) Then
            Dim temp() As String = {trans("Порядковый номер строки"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Номер строки по номеру символа")) Or meth = UCase(trans("Символ")) _
        Or meth = UCase(trans("X по номеру символа")) Or meth = UCase(trans("Y по номеру символа")) _
        Then
            Dim temp() As String = {trans("Порядковый номер символа"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Обновить страницу")) Then
            Dim temp() As String = {trans("Обновить страницу")}
            Return temp


            ' ТАБЛИЦА

        ElseIf meth = UCase(trans("Тип базы данных")) Then
            Dim temp() As String = {trans("Тип базы данных")}
            Return temp

        ElseIf meth = UCase(trans("Значение ячейки")) Or meth = UCase(trans("Ячейка выделена")) _
        Or meth = UCase(trans("Ячейка только для чтения")) Then
            Dim temp() As String = {trans("Номера строк через запятую"), trans("Номера столбцов через запятую"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Строка только для чтения")) Then
            Dim temp() As String = {trans("Номера строк через запятую"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Столбец только для чтения")) Or meth = UCase(trans("Ширина столбца")) Then
            Dim temp() As String = {trans("Номера столбцов через запятую"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Вышина строки")) Then
            Dim temp() As String = {trans("Номера строк через запятую"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Добавить строку")) Then
            If MyObj Is Nothing Then Return Nothing
            Dim i As Integer, temp(MyObj(0).obj.columns.count - 1) As String
            For i = 0 To MyObj(0).obj.columns.count - 1
                temp(i) = trans("Содержимое для столбца") & " """ & MyObj(0).obj.columns(i).HeaderText & """ (" & i & ")"
            Next
            Return temp

        ElseIf meth = UCase(trans("Добавить копию строк")) Then
            Dim temp() As String = {trans("Начальная строка копирования"), trans("Количество строк для копирования")}
            Return temp

        ElseIf meth = UCase(trans("Номер первой строки")) Or meth = UCase(trans("Номер последней строки")) Then
            Dim temp() As String = {trans("Область выборки"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Номер следующей строки")) Or meth = UCase(trans("Номер предыдущей строки")) Then
            Dim temp() As String = {trans("Номер начальной строки"), trans("Область выборки"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Вставить строку")) Then
            If MyObj Is Nothing Then Return Nothing
            Dim i As Integer, temp(MyObj(0).obj.columns.count - 1 + 1) As String
            temp(0) = trans("Номер строки куда вставлять")
            For i = 0 To MyObj(0).obj.columns.count - 1
                temp(i + 1) = trans("Содержимое для столбца") & i & " """ & MyObj(0).obj.columns(i).HeaderText & """"
            Next
            Return temp

        ElseIf meth = UCase(trans("Вставить копию строк")) Then
            Dim temp() As String = {trans("Номер строки куда вставлять"), trans("Начальная строка копирования"), _
                                    trans("Количество строк для копирования")} : Return temp

        ElseIf meth = UCase(trans("Удалить строку")) Then
            Dim temp() As String = {trans("Номера строк через запятую")}
            Return temp

        ElseIf meth = UCase(trans("Удалить столбец")) Then
            Dim temp() As String = {trans("Номера столбцов через запятую")}
            Return temp

        ElseIf meth = UCase(trans("Вставить столбец")) Then
            Dim temp() As String = {trans("Номер столбца куда вставлять"), trans("Текст заголовка столбца")}
            Return temp

        ElseIf meth = UCase(trans("Добавить столбец")) Then
            Dim temp() As String = {trans("Текст заголовка столбца")}
            Return temp

        ElseIf meth = UCase(trans("Открыть Access")) Or meth = UCase(trans("Открыть Excel")) Then
            Dim temp() As String = {trans("Путь к файлу"), trans("Название таблицы")}
            Return temp

        ElseIf meth = UCase(trans("SQL запрос выборки")) Then
            Dim temp() As String = {trans("Тип базы данных"), trans("Путь к файлу"), _
                                    trans("SQL запрос выборки из базы данных")}
            Return temp

        ElseIf meth = UCase(trans("SQL запрос изменения")) Then
            Dim temp() As String = {trans("Тип базы данных"), trans("Путь к файлу"), _
                                    trans("SQL запрос изменения базы данных")}
            Return temp

        ElseIf meth = UCase(trans("Сортировать")) Then
            Dim temp() As String = {trans("Номер столбца"), trans("Сортировать по возрастанию")}
            Return temp

        ElseIf meth = UCase(trans("Запись по номеру")) Then
            Dim temp() As String = {trans("Номер записи в списке"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Найти номер записи")) Then
            Dim temp() As String = {trans("Запись из списка"), "неважно"}
            Return temp

        ElseIf meth = UCase(trans("Добавить запись")) Or meth = UCase(trans("Удалить запись")) Then
            Dim temp() As String = {trans("Текст записи")}
            Return temp

        ElseIf meth = UCase(trans("Вставить запись")) Then
            Dim temp() As String = {trans("Место для записи в списке"), trans("Текст записи")}
            Return temp

        ElseIf meth = UCase(trans("Удалить запись по номеру")) Then
            Dim temp() As String = {trans("Номер записи в списке")}
            Return temp

        ElseIf meth = UCase(trans("Поиск в таблице")) Then
            Dim temp() As String = {trans("Что искать в таблице"), trans("C учетом регистра"), trans("Слово целиком"), _
                                    trans("Строка откуда начинать поиск"), trans("Столбец откуда начинать поиск"), ""}
            Return temp

        ElseIf meth = UCase(trans("Поиск с выделением")) Then
            Dim temp() As String = {trans("Что искать в таблице"), trans("C учетом регистра"), trans("Слово целиком"), _
                                    trans("Строка откуда начинать поиск"), trans("Столбец откуда начинать поиск")}
            Return temp

        ElseIf meth = UCase(trans("Поиск в выделеных ячейках")) Then
            Dim temp() As String = {trans("Что искать в таблице"), trans("C учетом регистра"), trans("Слово целиком"), ""}
            Return temp




            ' ТЕКСТ ПОЛЕЗНЫЙ ОБЪЕКТ

        ElseIf meth = MyZnak & UCase(trans("Символ по номеру")) Then
            Dim temp() As String = {trans("Исходный текст"), trans("Порядковый номер символа в тексте"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Сравнить тексты")) Then
            Dim temp() As String = {trans("Исходный текст"), trans("Текст с которым сравнивать"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Поиск в тексте")) Or meth = MyZnak & UCase(trans("Поиск номера строки")) _
        Or meth = MyZnak & UCase(trans("Поиск с учетом регистра")) _
        Or meth = MyZnak & UCase(trans("Поиск в тексте с конца")) _
        Or meth = MyZnak & UCase(trans("Поиск без кавычек")) _
        Then
            Dim temp() As String = {trans("Исходный текст"), trans("Что искать в тексте"), _
                                    trans("Номер символа откуда начинать поиск"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Поиск с регулярными выражениями")) Then
            Dim temp() As String = {trans("Исходный текст"), trans("Шаблон регулярного выражения"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Количество символов")) _
        Or meth = MyZnak & UCase(trans("Кавычки убрать")) Or meth = MyZnak & UCase(trans("Кавычками обособить")) _
        Or meth = MyZnak & UCase(trans("Количество строк")) _
        Or meth = MyZnak & UCase(trans("Сделать буквы прописными")) _
        Or meth = MyZnak & UCase(trans("Сделать буквы заглавными")) _
        Or meth = MyZnak & UCase(trans("Убрать пробелы")) _
        Or meth = MyZnak & UCase(trans("Убрать пробелы в начале")) _
        Or meth = MyZnak & UCase(trans("Убрать пробелы в конце")) _
        Or meth = MyZnak & UCase(trans("Текст есть число")) _
        Or meth = MyZnak & UCase(trans("Текст есть цифры")) _
        Then
            Dim temp() As String = {trans("Исходный текст"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Разбить на части")) _
        Or meth = MyZnak & UCase(trans("Разбить на части без кавычек")) _
        Then
            Dim temp() As String = {trans("Исходный текст"), trans("Символ разделения частей"), _
                                    trans("Номер нужной части"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Взять кусок текста")) _
        Or meth = MyZnak & UCase(trans("Удалить кусок текста")) Then
            Dim temp() As String = {trans("Исходный текст"), trans("Номер символа начала куска"), _
                                    trans("Длинна куска"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Количество частей текста")) _
        Or meth = MyZnak & UCase(trans("Количество частей без кавычек")) _
        Then
            Dim temp() As String = {trans("Исходный текст"), trans("Символ разделения частей"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Текст содержит")) Then
            Dim temp() As String = {trans("Исходный текст"), trans("Подряд символы которые должен содержать текст"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Текст не содержит")) Then
            Dim temp() As String = {trans("Исходный текст"), _
                                    trans("Подряд символы которые не должен содержать текст"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Текст состоит из")) Then
            Dim temp() As String = {trans("Исходный текст"), _
                                    trans("Подряд символы из которых должен состоять текст"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Строка по номеру")) Then
            Dim temp() As String = {trans("Исходный текст"), trans("Порядковый номер строки в тексте"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Вставить символы в текст")) Then
            Dim temp() As String = {trans("Исходный текст"), trans("Номер символа куда вставлять"), _
                                    trans("Текст который надо вставить"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Заменить")) Or meth = MyZnak & UCase(trans("Заменить все")) Then
            Dim temp() As String = {trans("Исходный текст"), trans("Что заменять"), trans("На что заменять"), "неважно"}
            Return temp

            ' Сообщение 

        ElseIf meth = MyZnak & UCase(trans("Запустить сообщение")) Then
            Dim temp() As String = {trans("Текст сообщения"), trans("Кнопки сообщения"), trans("Тип сообщения"), _
                                    trans("Заголовок")}
            Return temp

            ' ДАТА

        ElseIf meth = MyZnak & UCase(trans("День месяца")) Or meth = MyZnak & UCase(trans("День года")) _
        Or meth = MyZnak & UCase(trans("День в неделе")) Or meth = MyZnak & UCase(trans("Час")) _
        Or meth = MyZnak & UCase(trans("Минута")) Or meth = MyZnak & UCase(trans("Секунда")) _
        Or meth = MyZnak & UCase(trans("Квартал")) Or meth = MyZnak & UCase(trans("Неделя в году")) _
        Or meth = MyZnak & UCase(trans("Год")) Or meth = MyZnak & UCase(trans("Месяц")) _
        Or meth = MyZnak & UCase(trans("Секунд всего в дате")) Or meth = MyZnak & UCase(trans("День недели")) _
        Or meth = MyZnak & UCase(trans("Название месяца")) Or meth = MyZnak & UCase(trans("Время")) _
        Then
            Dim temp() As String = {trans("Дата из которой брать"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Прибавить дни")) Or meth = MyZnak & UCase(trans("Прибавить часы")) _
        Or meth = MyZnak & UCase(trans("Прибавить минуты")) Or meth = MyZnak & UCase(trans("Прибавить секунды")) _
        Or meth = MyZnak & UCase(trans("Прибавить кварталы")) Or meth = MyZnak & UCase(trans("Прибавить недели")) _
        Or meth = MyZnak & UCase(trans("Прибавить годы")) Or meth = MyZnak & UCase(trans("Прибавить месяцы")) _
        Then
            Dim temp() As String = {trans("Дата к которой прибавлять"), trans("Сколько прибавить"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Разница в днях")) Or meth = MyZnak & UCase(trans("Разница в часах")) _
        Or meth = MyZnak & UCase(trans("Разница в минутах")) Or meth = MyZnak & UCase(trans("Разница в секундах")) _
        Or meth = MyZnak & UCase(trans("Разница в кварталах")) Or meth = MyZnak & UCase(trans("Разница в неделях")) _
        Or meth = MyZnak & UCase(trans("Разница в годах")) Or meth = MyZnak & UCase(trans("Разница в месяцах")) _
        Then
            Dim temp() As String = {trans("Дата1 которую вычитать"), trans("Дата2 из которой вычитать"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Дней в месяце")) Then
            Dim temp() As String = {trans("Год"), trans("Месяц"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Дата в определенном формате")) Then
            Dim temp() As String = {trans("Дата"), trans("Номер формата вывода (от 1 до 52)"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Изменить время компьютера")) Then
            Dim temp() As String = {trans("Новая дата и время")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Выполнить код VBScript")) Then
            Dim temp() As String = {trans("Код VBScript")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Выполнить код Алгоритма2")) Then
            Dim temp() As String = {trans("Код Алгоритма 2")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Выполнить код VBNet")) Then
            Dim temp() As String = {trans("Код VBNet")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Выполнить код CSharp")) Then
            Dim temp() As String = {trans("Код CSharp")}
            Return temp

        ElseIf meth = UCase(trans("Ключ активации выдать")) Then
            Dim temp() As String = {trans("ID пользователя"), trans("Показать в окне"), ""}
            Return temp

        ElseIf meth = UCase(trans("Ключ активации проверить")) Then
            Dim temp() As String = {trans("Ключ активации"), trans("Показать в окне"), ""}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Переименовать")) Then
            Dim temp() As String = {trans("Путь к файлу или папке"), trans("Новое имя"), ""}
            Return temp

            ' КЛИЕНТ - СЕРВЕР
        ElseIf meth = UCase(trans("Ip клиента")) Then
            Dim temp() As String = {trans("Имя клиента"), ""}
            Return temp

        ElseIf meth = UCase(trans("Отправить серверу")) Or meth = UCase(trans("Отправить клиентам")) Then
            Dim temp() As String = {trans("Содержимое сообщения")}
            Return temp

        ElseIf meth = UCase(trans("Отправить файл серверу")) Or meth = UCase(trans("Отправить файл клиентам")) _
        Or meth = UCase(MyZnak & trans("Открыть папку")) _
        Then
            Dim temp() As String = {trans("Путь к файлу или папке")}
            Return temp

        ElseIf meth = UCase(trans("Отправить клиентам кроме")) Then
            Dim temp() As String = {trans("Имена клиентов, которым не отправлять"), trans("Содержимое сообщения")}
            Return temp

        ElseIf meth = UCase(trans("Отправить клиенту")) Then
            Dim temp() As String = {trans("Имена клиентов"), trans("Содержимое сообщения")}
            Return temp

        ElseIf meth = UCase(trans("Отправить файл клиентам кроме")) Then
            Dim temp() As String = {trans("Имена клиентов, которым не отправлять"), trans("Путь к файлу или папке")}
            Return temp

        ElseIf meth = UCase(trans("Отправить файл клиенту")) Then
            Dim temp() As String = {trans("Имена клиентов"), trans("Путь к файлу или папке")}
            Return temp

        ElseIf meth = UCase(trans("Добавить в лог")) Then
            Dim temp() As String = {trans("Добавляемый текст")}
            Return temp

        ElseIf meth = UCase(trans("Выполнить команду")) Then
            Dim temp() As String = {trans("Команда")}
            Return temp

            ' ИНТЕРНЕТ
        ElseIf meth = UCase(trans("Получить код страницы")) Then
            Dim temp() As String = {trans("Ссылка")}
            Return temp

        ElseIf meth = UCase(trans("Скачать файл")) Then
            Dim temp() As String = {trans("Ссылка"), trans("Ждать пока скачается")}
            Return temp

            ' ПРОЧЕЕ
        ElseIf meth = MyZnak & UCase(trans("Количество файлов")) Or meth = MyZnak & UCase(trans("Количество папок")) Then
            Dim temp() As String = {trans("Путь к папке"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Зашифровать текст")) Or meth = MyZnak & UCase(trans("Расшифровать текст")) Then
            Dim temp() As String = {trans("Текст"), trans("Ключ шифрования текста"), "неважно"}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Процесс убить")) Then
            Dim temp() As String = {trans("Имя процесса")}
            Return temp

        ElseIf meth = MyZnak & UCase(trans("Окно в фокусе")) Then
            Dim temp() As String = {trans("Заголовок окна")}
            Return temp

        Else
            Return Nothing
        End If

    End Function

    ' ПОЛУЧИТЬ ЗНАЧЕНИЕ АРГУМЕНТА У СВОЙСТВА ИЛИ МЕТОДА ПО УМОЛЧАНИЮ
    Public Function DefaultValue(ByVal arg As String) As String
        arg = UCase(arg)
        If arg = UCase(trans("Путь к файлу")) Or arg = UCase(trans("Новый путь к файлу")) _
        Or arg = UCase(trans("Путь к файлу или папке")) Then
            Return """\" & proj.iPathShort & "\" & proj.pPicNameDef & ".jpg"""
        ElseIf arg = UCase(trans("Путь к папке")) Then
            Return """\" & proj.iPathShort & """"
        ElseIf arg = UCase(trans("Новое имя")) Then
            Return """" & trans("Файл") & ".txt"""
        ElseIf arg = UCase(trans("Что сохранять")) Then
            Return trans("Окно") & "1." & trans("Окно") & "1." & trans("Текст")
        ElseIf arg = UCase(trans("Что искать")) Then
            Return """*.*"""
        ElseIf arg = UCase(trans("Рисунок для сохранения")) Then
            Return trans("Окно") & "1." & trans("Окно") & "1." & trans("Фоновой рисунок")
        ElseIf arg = UCase(trans("Заменять совпадающие файлы")) Then
            Return trans("Да")
        ElseIf arg = UCase(trans("Только активное окно")) Then
            Return trans("Нет")
        ElseIf arg = UCase(trans("Симулировать набор следующего текста")) Then
            Return """" & trans("Этот текст печатает программа") & """"
        ElseIf arg = UCase(trans("Команда Windows или имя файла")) Then
            Return """" & trans("explorer.exe") & """"
        ElseIf arg = UCase(trans("Аргументы")) Then
            Return """" & trans("C:\") & """"
        ElseIf arg = UCase(trans("Размер вращения")) Then
            Return """" & trans("100") & """"
        ElseIf arg = UCase(trans("Путь реестра")) Then
            Return """" & trans("HKEY_CURRENT_USER\Control Panel\Mouse") & """"
        ElseIf arg = UCase(trans("Тип ключа")) Then
            Return trans("Строка")
        ElseIf arg = UCase(trans("X")) Or arg = UCase(trans("X")) Or arg = UCase(trans("Порядковый номер строки")) _
        Or arg = UCase(trans("Порядковый номер символа")) Or arg = UCase(trans("Y")) Or arg = UCase(trans("У")) Then
            Return trans("0")
        ElseIf arg = UCase(trans("Обновить страницу")) Then
            Return trans("Обычно")
        ElseIf arg = UCase(trans("Область выборки")) Then
            Return trans("Вся таблица")
        ElseIf arg = UCase(trans("Область выборки")) Then
            Return trans("Вся таблица")
        ElseIf arg = UCase(trans("Сортировать по возрастанию")) Then
            Return trans("Да")
        ElseIf arg = UCase(trans("Порядковый номер символа в тексте")) _
        Or arg = UCase(trans("Номер символа откуда начинать поиск")) _
        Or arg = UCase(trans("Номер нужной части")) _
        Or arg = UCase(trans("Номер символа начала куска")) Or arg = UCase(trans("Длинна куска")) _
        Or arg = UCase(trans("Подряд символы которые должен содержать текст")) _
        Or arg = UCase(trans("Подряд символы которые должен не содержать текст")) _
        Or arg = UCase(trans("Порядковый номер строки в тексте")) _
        Or arg = UCase(trans("Номер символа куда вставлять")) _
        Then
            Return "1"
        ElseIf arg = UCase(trans("Кнопки сообщения")) Then
            Return trans("Ок")
        ElseIf arg = UCase(trans("Тип сообщения")) Then
            Return trans("Обычный")
        ElseIf arg = UCase(trans("Кодировка текста")) Then
            Return trans("По умолчанию")
        ElseIf arg = UCase(trans("Новая дата и время")) _
        Or arg = UCase(trans("Дата")) Or arg = UCase(trans("Дата1 которую вычитать")) _
        Or arg = UCase(trans("Дата2 из которой вычитать")) Or arg = UCase(trans("Дата к которой прибавлять")) _
        Or arg = UCase(trans("Дата из которой брать")) _
        Then
            Return ToMyDate(Now)
        ElseIf arg = UCase(trans("Номер формата вывода (от 1 до 52)")) Then
            Return "11"
        ElseIf arg = UCase(trans("Год")) Then
            Return Now.Year
        ElseIf arg = UCase(trans("Месяц")) Then
            Return Now.Month
        ElseIf arg = UCase(trans("Сколько прибавить")) Then
            Return "1"
        ElseIf arg = UCase(trans("Код VBScript")) Then
            Return """Sub main()" & Chr(182) & " msgbox(""""" & trans("Привет") & "!"""")" & Chr(182) & "End Sub"""
        ElseIf arg = UCase(trans("Код Алгоритма 2")) Then
            Return """_" & trans("Полезные объекты") & "._" & trans("Показать сообщение") & "._" & _
                    trans("Запустить сообщение") & "(""""" & trans("Привет") & "!"""", " & _
                    trans("Ок") & ", " & trans("Обычный") & ", )"""
        ElseIf arg = UCase(trans("Код VBNet")) Then
            Return """Imports System.Windows.Forms" & Chr(182) & _
                    "'" & trans("Класс MainClass и функция Main должны обязательно присутствовать") & Chr(182) & _
                    "Public Class MainClass " & Chr(182) & _
                    "   Public Function Main()" & Chr(182) & _
                    "       Dim frm as New Form" & Chr(182) & _
                    "       frm.Text=""""" & trans("Привет") & "!""""" & Chr(182) & _
                    "       frm.Show" & Chr(182) & _
                    "   End Function" & Chr(182) & _
                    "End Class"""
        ElseIf arg = UCase(trans("Код CSharp")) Then
            Return """using System.Windows.Forms;" & Chr(182) & _
                    "//" & trans("Класс MainClass и функция Main должны обязательно присутствовать") & Chr(182) & _
                    "public class MainClass  {" & Chr(182) & _
                    "   public void Main() {" & Chr(182) & _
                    "       Form frm = new Form();" & Chr(182) & _
                    "       frm.Text=""""" & trans("Привет") & "!"""";" & Chr(182) & _
                    "       frm.Show();" & Chr(182) & _
                    "   }" & Chr(182) & _
                    "}"""
        ElseIf arg = UCase(trans("SQL запрос выборки из базы данных")) Then
            Return """SELECT * FROM " & trans("Таблица") & "1"""
        ElseIf arg = UCase(trans("SQL запрос изменения базы данных")) Then
            Return """INSERT INTO " & trans("Таблица") & "1 VALUES ('1', 'a')"""
        ElseIf arg = UCase(trans("Тип базы данных")) Then
            Return "Access"
        ElseIf arg = UCase(trans("Название таблицы")) Then
            Return """" & trans("Таблица") & "1"""
        ElseIf arg = UCase(trans("Имена клиентов")) Or arg = UCase(trans("Имена клиентов, которым не отправлять")) Then
            Return """" & trans("Клиент") & "1," & trans("Клиент") & "2," & trans("Клиент") & "3" & """"
        ElseIf arg = UCase(trans("Тип файла")) Then
            Return """" & trans("image/gif") & """"
        ElseIf arg = UCase(trans("Ждать пока скачается")) Then
            Return trans("Да")
        ElseIf arg = UCase(trans("Текст сообщения")) Then
            Return """" & trans("Текст сообщения") & """"
        ElseIf arg = UCase(trans("Заголовок")) Then
            Return """" & trans("Заголовок") & """"
        ElseIf arg = UCase(trans("Ключ шифрования текста")) Then
            Return """" & trans("абвгд12345") & """"
        ElseIf arg = UCase(trans("Что искать в таблице")) Then
            Return """" & trans("Текст") & """"
        ElseIf arg = UCase(trans("C учетом регистра")) Then
            Return trans("Нет")
        ElseIf arg = UCase(trans("Слово целиком")) Then
            Return trans("Нет")
        ElseIf arg = UCase(trans("Строка откуда начинать поиск")) Then
            Return 0
        ElseIf arg = UCase(trans("Столбец откуда начинать поиск")) Then
            Return 0
        ElseIf arg = UCase(trans("Объект съемки")) Then
            Return """" & trans("Окно") & "1"""


        Else
            Return ""
        End If
    End Function

    ' ПРОВЕРЯЕТ, МОЖНО ЛИ ИСПОЛЬЗОВАТЬ ТАКОЕ ИМЯ
    Function ValidName(ByVal name As String) As Boolean
        Dim i As Integer
        ' Длинна имени
        If name.Length = 0 Then
            If IsHttpCompil = False Then MsgBox(Errors.NameInvalidLength(name), MsgBoxStyle.Exclamation)
            Return False
        End If
        ' Недопустимые символы
        For i = 0 To name.Length - 1
            If Char.IsLetter(name(i)) = False And Char.IsDigit(name(i)) = False And name(i) <> " " Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidSimvols(name), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        ' Пробел в начале
        If name(0) = " " Then
            If IsHttpCompil = False Then MsgBox(Errors.NameInvalidProbels(name), MsgBoxStyle.Exclamation)
            Return False
        End If
        If Char.IsDigit(name(0)) Then
            If IsHttpCompil = False Then MsgBox(Errors.NameInvalidDigit(name), MsgBoxStyle.Exclamation)
            Return False
        End If
        ' Совпадение с именем функции
        For i = 0 To AllFuncs.Length - 1
            If LCase(AllFuncs(i)) = LCase(name) Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidFuns(AllFuncs(i)), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        ' Совпадение с вспомогательными словами
        For i = 0 To AllHW.Length - 1
            If LCase(AllHW(i)) = LCase(name) Then
                If IsHttpCompil = False Then MsgBox(Errors.NameInvalidHW(AllHW(i)), MsgBoxStyle.Exclamation)
                Return False
            End If
        Next
        ' Совпадение с прочими ключевыми словами
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

    ' ЧТОБЫ ЗАНЕСТИ Х И У В СВОЙСТВА. И В КТРЛ+З ТОЖЕ.
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
            izmenit(UCase(trans("Текст")), myObj.obj.Text, myObj, mozhno)
        End If
        If Iz.IsTr(myObj) Then
            izmenit(UCase(trans("Текст поля")), myObj.obj.TextB.Text, myObj, mozhno)
        End If
        If Iz.IsFORM(myObj) = False Then
            izmenit(UCase(trans("X")), myObj.obj.Left, myObj, mozhno)
            izmenit(UCase(trans("Y")), myObj.obj.Top, myObj, mozhno)
        End If
        izmenit(UCase(trans("Вышина")), myObj.obj.Height, myObj, mozhno)
        izmenit(UCase(trans("Ширина")), myObj.obj.Width, myObj, mozhno)
        If Iz.IsDP(myObj) Then
            izmenit(UCase(trans("Расстояние разделителя")), myObj.obj.SplitterDistance, myObj, mozhno)
        End If
        If Iz.IsTP(myObj) Then
            izmenit(UCase(trans("Позиция выделенной закладки")), myObj.obj.SelectedIndex, myObj, mozhno)
        End If
        If Iz.IsC(myObj) Or Iz.IsL(myObj) Or Iz.IsCL(myObj) Then
            izmenit(UCase(trans("Номер выделенной записи")), myObj.obj.SelectedIndex, myObj, mozhno)
            izmenit(UCase(trans("Выделенная запись")), myObj.obj.SelectedItem, myObj, mozhno)
        End If
        If Iz.IsL(myObj) Then
            izmenit(UCase(trans("Номера выделенных записей")), myObj.obj.SelectedIndex, myObj, mozhno)
            izmenit(UCase(trans("Выделенные записи")), myObj.obj.SelectedItem, myObj, mozhno)
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
    ' ЧТОБЫ ЗАНЕСТИ В МОЙОБЪЕКТ И В СПИСОК В СВОЙСТВА, КОТОРЫМ НЕТ АЛЬТЕРНАТИВ В ВИЗУАЛСТУДИИ
    Sub IzmenenieByloExpert()
        Dim i As Integer, MyObj As Object, bilo As Boolean = False
        If fromIzmenenieBylo = True Then Exit Sub
        fromIzmenenieBylo = True
        If proj.ActiveForm Is Nothing Then Exit Sub
        If proj.ActiveForm.ActiveObj Is Nothing Then Exit Sub
        For i = 0 To proj.ActiveForm.ActiveObj.Length - 1
            MyObj = proj.ActiveForm.ActiveObj(i)

            If Iz.IsTl(MyObj) Then
                izmenitExp(UCase(trans("Номера выделенных строк")), MyObj.obj.Props.selRows, MyObj.obj.Props.SelectedRows, bilo)
                izmenitExp(UCase(trans("Номера выделенных столбцов")), MyObj.obj.Props.selCol, MyObj.obj.Props.SelectedColumns, bilo)
                izmenitExp(UCase(trans("Ширина столбцов")), MyObj.obj.Props.colsWids, MyObj.obj.Props.WidthOfColumns, bilo)
                izmenitExp(UCase(trans("Вышина строк")), MyObj.obj.Props.RowsH, MyObj.obj.Props.HeightOfRows, bilo)
            End If

        Next
        If bilo Then MainForm.ReSelectedListViewOneItem()
        fromIzmenenieBylo = False
    End Sub
    Sub izmenitExp(ByVal prop As String, ByRef varPrivatePropertys As Object, ByVal varPublicPropertys As Object, ByRef bilo As Boolean)
        varPrivatePropertys = varPublicPropertys : bilo = True
        MainForm.RefreshListViewOneItem(prop, varPublicPropertys)
    End Sub

    ' ВСПОМОГАТЕЛЬНЫЕ СЛОВА КОТОРЫЕ НАДО ПЕРЕВОДИТЬ В СТРОКИ
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

    ' CОЗДАНИЕ СПУТНИКОВ СВОЙСТВ, ТАКИХ КАК КОНСТАНТЫ, МЕНЮ И Т.Д.
    Sub CreateConstants()
        Try
            IO.Path.GetTempFileName()
        Catch ex As Exception
            MsgBox(trans("Папка с временными файлами переполнена! Очистите её. Она откроется, когда вы нажмете Ok."))
            Diagnostics.Process.Start("explorer", IO.Path.GetTempPath)
            End
        End Try
        Dim i As Integer
        ' СОЗДАНИЕ ЦВЕТОВЫХ КОНСТАНТ
        Colors.Clear()
        Colors.Add(LCase(trans("аква")), Color.Aqua)
        Colors.Add(LCase(trans("черный")), Color.Black)
        Colors.Add(LCase(trans("синий")), Color.Blue)
        Colors.Add(LCase(trans("коричневый")), Color.Brown)
        Colors.Add(LCase(trans("шоколадный")), Color.Chocolate)
        Colors.Add(LCase(trans("кораловый")), Color.Coral)
        Colors.Add(LCase(trans("серый")), Color.Gray)
        Colors.Add(LCase(trans("салатовый")), Color.GreenYellow)
        Colors.Add(LCase(trans("индиго")), Color.Indigo)
        Colors.Add(LCase(trans("лайм")), Color.Lime)
        Colors.Add(LCase(trans("розовый")), Color.Magenta)
        Colors.Add(LCase(trans("фиолетовый")), Color.Violet)
        Colors.Add(LCase(trans("серебряный")), Color.Silver)
        Colors.Add(LCase(trans("оранжевый")), Color.Orange)
        Colors.Add(LCase(trans("хаки")), Color.DarkKhaki)
        Colors.Add(LCase(trans("море")), Color.Teal)
        Colors.Add(LCase(trans("яркосиний")), Color.DodgerBlue)
        Colors.Add(LCase(trans("пурпурный")), Color.Purple)
        Colors.Add(LCase(trans("системный")), SystemColors.Control)
        Colors.Add(LCase(trans("системный темный")), SystemColors.ControlDark)
        Colors.Add(LCase(trans("белый")), Color.White)
        Colors.Add(LCase(trans("красный")), Color.Red)
        Colors.Add(LCase(trans("зеленый")), Color.Green)
        Colors.Add(LCase(trans("желтый")), Color.Yellow)

        ' СОЗДАНИЕ КОНСТАНТ ПРИВЯЗКИ
        Anchors.Clear()
        Anchors.Add(LCase(trans("Никакой")), 0)
        Anchors.Add(LCase(trans("Слева")), 4)
        Anchors.Add(LCase(trans("Справа")), 8)
        Anchors.Add(LCase(trans("Сверху")), 1)
        Anchors.Add(LCase(trans("Снизу")), 2)
        Anchors.Add(LCase(trans("Слева_Сверху")), 5)
        Anchors.Add(LCase(trans("Слева_Снизу")), 6)
        Anchors.Add(LCase(trans("Справа_Слева")), 12)
        Anchors.Add(LCase(trans("Справа_Сверху")), 9)
        Anchors.Add(LCase(trans("Справа_Снизу")), 10)
        Anchors.Add(LCase(trans("Сверху_Снизу")), 3)
        Anchors.Add(LCase(trans("Слева_Сверху_Снизу")), 7)
        Anchors.Add(LCase(trans("Справа_Сверху_Снизу")), 11)
        Anchors.Add(LCase(trans("Справа_Слева_Сверху")), 13)
        Anchors.Add(LCase(trans("Справа_Слева_Снизу")), 14)
        Anchors.Add(LCase(trans("Справа_Слева_Сверху_Снизу")), 15)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ ФОНА   
        bkImStyles.Clear()
        bkImStyles.Add(LCase(trans("Никакой")), ImageLayout.None)
        bkImStyles.Add(LCase(trans("Плитка")), ImageLayout.Tile)
        bkImStyles.Add(LCase(trans("По центру")), ImageLayout.Center)
        bkImStyles.Add(LCase(trans("Растянутый")), ImageLayout.Stretch)
        bkImStyles.Add(LCase(trans("Масштабированный")), ImageLayout.Zoom)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ ФОНА  
        Cursori.Clear()
        Cursori.Add(LCase(trans("Обычный")), Cursors.Default)
        Cursori.Add(LCase(trans("Старт приложения")), Cursors.AppStarting)
        Cursori.Add(LCase(trans("Пересечение")), Cursors.Cross)
        Cursori.Add(LCase(trans("Рука")), Cursors.Hand)
        Cursori.Add(LCase(trans("Помощь")), Cursors.Help)
        Cursori.Add(LCase(trans("Горизонтальный разделитель")), Cursors.HSplit)
        Cursori.Add(LCase(trans("Текстовый")), Cursors.IBeam)
        Cursori.Add(LCase(trans("Запрещающий")), Cursors.No)
        Cursori.Add(LCase(trans("Запрещающий перемещение")), Cursors.NoMove2D)
        Cursori.Add(LCase(trans("Запрещающий по горизонтали")), Cursors.NoMoveHoriz)
        Cursori.Add(LCase(trans("Запрещающий по вертикали")), Cursors.NoMoveVert)
        Cursori.Add(LCase(trans("Направление восток")), Cursors.PanEast)
        Cursori.Add(LCase(trans("Направление СВ")), Cursors.PanNE)
        Cursori.Add(LCase(trans("Направление север")), Cursors.PanNorth)
        Cursori.Add(LCase(trans("Направление СЗ")), Cursors.PanNW)
        Cursori.Add(LCase(trans("Направление ЮВ")), Cursors.PanSE)
        Cursori.Add(LCase(trans("Направление юг")), Cursors.PanSouth)
        Cursori.Add(LCase(trans("Направление ЮЗ")), Cursors.PanSW)
        Cursori.Add(LCase(trans("Направление запад")), Cursors.PanWest)
        Cursori.Add(LCase(trans("Растянивание везде")), Cursors.SizeAll)
        Cursori.Add(LCase(trans("Растянивание СВЮЗ")), Cursors.SizeNESW)
        Cursori.Add(LCase(trans("Растянивание СЮ")), Cursors.SizeNS)
        Cursori.Add(LCase(trans("Растянивание СЗЮВ")), Cursors.SizeNWSE)
        Cursori.Add(LCase(trans("Растянивание ЗВ")), Cursors.SizeWE)
        Cursori.Add(LCase(trans("Стрелка вверх")), Cursors.UpArrow)
        Cursori.Add(LCase(trans("Вертикальный разделитель")), Cursors.VSplit)
        Cursori.Add(LCase(trans("Ожидание")), Cursors.WaitCursor)

        ' СОЗДАНИЕ КОНСТАНТ РАСТЯЖЕНИЯ
        Docks.Clear()
        Docks.Add(LCase(trans("Никакой")), DockStyle.None)
        Docks.Add(LCase(trans("По верху")), DockStyle.Top)
        Docks.Add(LCase(trans("По низу")), DockStyle.Bottom)
        Docks.Add(LCase(trans("Слева")), DockStyle.Left)
        Docks.Add(LCase(trans("Справа")), DockStyle.Right)
        Docks.Add(LCase(trans("Везде")), DockStyle.Fill)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ КНОПКИ
        FlatStyles.Clear()
        FlatStyles.Add(LCase(trans("Плоский")), FlatStyle.Flat)
        FlatStyles.Add(LCase(trans("Поднимающийся")), FlatStyle.Popup)
        FlatStyles.Add(LCase(trans("Обычный")), FlatStyle.Standard)
        FlatStyles.Add(LCase(trans("Системный")), FlatStyle.System)

        ' СОЗДАНИЕ КОНСТАНТ ШРИФТА
        Dim ff As New Drawing.Text.InstalledFontCollection
        Fonts.Clear()
        For i = 0 To ff.Families.Length - 1
            Fonts.Add(LCase(ff.Families(i).Name), ff.Families(i).Name)
        Next

        ' СОЗДАНИЕ КОНСТАНТ ПОЛОЖЕНИЯ
        Aligns.Clear()
        Aligns.Add(LCase(trans("Верх слева")), ContentAlignment.TopLeft)
        Aligns.Add(LCase(trans("Верх")), ContentAlignment.TopCenter)
        Aligns.Add(LCase(trans("Верх справа")), ContentAlignment.TopRight)
        Aligns.Add(LCase(trans("Слева")), ContentAlignment.MiddleLeft)
        Aligns.Add(LCase(trans("Центр")), ContentAlignment.MiddleCenter)
        Aligns.Add(LCase(trans("Справа")), ContentAlignment.MiddleRight)
        Aligns.Add(LCase(trans("Низ слева")), ContentAlignment.BottomLeft)
        Aligns.Add(LCase(trans("Низ")), ContentAlignment.BottomCenter)
        Aligns.Add(LCase(trans("Низ справа")), ContentAlignment.BottomRight)

        ' СОЗДАНИЕ КОНСТАНТ ПОЛОЖЕНИЯ
        TextImages.Clear()
        TextImages.Add(LCase(trans("Поверх")), TextImageRelation.Overlay)
        TextImages.Add(LCase(trans("Слева")), TextImageRelation.TextBeforeImage)
        TextImages.Add(LCase(trans("Сверху")), TextImageRelation.TextAboveImage)
        TextImages.Add(LCase(trans("Снизу")), TextImageRelation.ImageAboveText)
        TextImages.Add(LCase(trans("Справа")), TextImageRelation.ImageBeforeText)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ РАМКИ
        BorderStyles.Clear()
        BorderStyles.Add(LCase(trans("Никакой")), BorderStyle.None)
        BorderStyles.Add(LCase(trans("Линия")), BorderStyle.FixedSingle)
        BorderStyles.Add(LCase(trans("Объем")), BorderStyle.Fixed3D)

        ' СОЗДАНИЕ КОНСТАНТ ПАНЕЛЕЙ
        FixedPanels.Clear()
        FixedPanels.Add(LCase(trans("Никакой")), FixedPanel.None)
        FixedPanels.Add(LCase(trans("Панель1")), FixedPanel.Panel1)
        FixedPanels.Add(LCase(trans("Панель2")), FixedPanel.Panel2)

        ' СОЗДАНИЕ КОНСТАНТ ОРИЕНТАЦИИ
        Orientations.Clear()
        Orientations.Add(LCase(trans("Горизонтальная")), Orientation.Horizontal)
        Orientations.Add(LCase(trans("Вертикальная")), Orientation.Vertical)

        ' СОЗДАНИЕ КОНСТАНТ ПАПОК
        Papks.Clear()
        If isHelp = False Then
            Papks.Add(LCase(trans("Папка проекта")), proj.pPath)
            Papks.Add(LCase(trans("Рисунки проекта")), proj.iPath)
        Else
            Papks.Add(LCase(trans("Папка проекта")), "")
            Papks.Add(LCase(trans("Рисунки проекта")), "")
        End If
        Papks.Add(MyZnak & LCase(trans("Куки")), Environment.GetFolderPath(Environment.SpecialFolder.Cookies) & "\")
        Papks.Add(MyZnak & LCase(trans("Рабочий стол")), Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\")
        Papks.Add(MyZnak & LCase(trans("Избранное")), Environment.GetFolderPath(Environment.SpecialFolder.Favorites) & "\")
        Papks.Add(MyZnak & LCase(trans("Журнал")), Environment.GetFolderPath(Environment.SpecialFolder.History) & "\")
        Papks.Add(MyZnak & LCase(trans("Интернет кэш")), Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\")
        Papks.Add(MyZnak & LCase("ApplicationData"), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\")
        Papks.Add(MyZnak & LCase(trans("Мои документы")), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\")
        Papks.Add(MyZnak & LCase(trans("Мой компьютер")), Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) & "\")
        Papks.Add(MyZnak & LCase(trans("Моя музыка")), Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) & "\")
        Papks.Add(MyZnak & LCase(trans("Мои рисунки")), Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) & "\")
        Papks.Add(MyZnak & LCase("ProgramFiles"), Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\")
        Papks.Add(MyZnak & LCase(trans("Пуск-программы")), Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\")
        Papks.Add(MyZnak & LCase(trans("Недавние файлы")), Environment.GetFolderPath(Environment.SpecialFolder.Recent) & "\")
        Papks.Add(MyZnak & LCase(trans("Отправить")), Environment.GetFolderPath(Environment.SpecialFolder.SendTo) & "\")
        Papks.Add(MyZnak & LCase(trans("Пуск")), Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\")
        Papks.Add(MyZnak & LCase(trans("Автозагрузка")), Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\")
        Papks.Add(MyZnak & LCase("System32"), Environment.GetFolderPath(Environment.SpecialFolder.System) & "\")
        Papks.Add(MyZnak & LCase("Windows"), IO.Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.System)) & "\")
        Papks.Add(MyZnak & LCase(trans("Временная папка")), IO.Path.GetTempPath & "\")
        Papks.Add(MyZnak & LCase(trans("Временный файл")), IO.Path.GetTempFileName)
        Papks.Add(MyZnak & LCase(trans("Папка пользователя")), Environment.GetEnvironmentVariable("USERPROFILE") & "\")
        Papks.Add(MyZnak & LCase(trans("Все пользователи")), Environment.GetEnvironmentVariable("ALLUSERSPROFILE") & "\")
        If Environment.GetCommandLineArgs.Length > 0 Then
            Papks.Add(LCase(trans("Имя файла")), Environment.GetCommandLineArgs(0))
        End If

        ' СОЗДАНИЕ КОНСТАНТ КЛАВИШ
        Dim a As New Keys
        Dim mass() As Object = {[Enum].GetNames(a.GetType()), [Enum].GetValues(a.GetType())}
        Keyz.Clear()
        For i = 0 To mass(0).Length - 1
            Keyz.Add(LCase(mass(0)(i)), mass(1)(i))
        Next

        ' СОЗДАНИЕ КОНСТАНТ РИСУНКА РАБОЧЕГО СТОЛА
        DeskStyle.Clear()
        DeskStyle.Add(LCase(trans("Плитка")), "0,1")
        DeskStyle.Add(LCase(trans("По центру")), "1,0")
        DeskStyle.Add(LCase(trans("Растянутый")), "2,0")

        ' СОЗДАНИЕ КОНСТАНТ ДЛЯ ТИПА КЛЮЧА РЕГИСТРА
        TypeRegistry.Clear()
        TypeRegistry.Add(LCase(trans("Двоичное число")), Microsoft.Win32.RegistryValueKind.Binary)
        TypeRegistry.Add(LCase(trans("Число")), Microsoft.Win32.RegistryValueKind.DWord)
        TypeRegistry.Add(LCase(trans("Расширенная строка")), Microsoft.Win32.RegistryValueKind.ExpandString)
        TypeRegistry.Add(LCase(trans("Мультистрока")), Microsoft.Win32.RegistryValueKind.MultiString)
        TypeRegistry.Add(LCase(trans("Большое число")), Microsoft.Win32.RegistryValueKind.QWord)
        TypeRegistry.Add(LCase(trans("Строка")), Microsoft.Win32.RegistryValueKind.String)

        ' СОЗДАНИЕ КОНСТАНТ СКРОЛБАРОВ
        ScrollBarz.Clear()
        ScrollBarz.Add(LCase(trans("Нет")), ScrollBars.None)
        ScrollBarz.Add(LCase(trans("Горизонтальная")), ScrollBars.Horizontal)
        ScrollBarz.Add(LCase(trans("Вертикальная")), ScrollBars.Vertical)
        ScrollBarz.Add(LCase(trans("Обе")), ScrollBars.Both)

        ' СОЗДАНИЕ КОНСТАНТ РАСПОЛОЖЕНИЯ ТЕКСТА 
        TextPositions.Clear()
        TextPositions.Add(LCase(trans("Слева")), HorizontalAlignment.Left)
        TextPositions.Add(LCase(trans("Справа")), HorizontalAlignment.Right)
        TextPositions.Add(LCase(trans("Центр")), HorizontalAlignment.Center)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ ОТОБРАЖЕНИЯ
        DisplayStyles.Clear()
        DisplayStyles.Add(LCase(trans("Нет")), ToolStripItemDisplayStyle.None)
        DisplayStyles.Add(LCase(trans("Текст")), ToolStripItemDisplayStyle.Text)
        DisplayStyles.Add(LCase(trans("Рисунок")), ToolStripItemDisplayStyle.Image)
        DisplayStyles.Add(LCase(trans("Рисунок и текст")), ToolStripItemDisplayStyle.ImageAndText)

        ' СОЗДАНИЕ КОНСТАНТ НАПРАВЛЕНИЕ ТЕКТСА
        TextDirections.Clear()
        TextDirections.Add(LCase(trans("Горизонтальный")), ToolStripTextDirection.Horizontal)
        TextDirections.Add(LCase(trans("Вертикальный 90")), ToolStripTextDirection.Vertical90)
        TextDirections.Add(LCase(trans("Вертикальный 270")), ToolStripTextDirection.Vertical270)

        ' СОЗДАНИЕ КОНСТАНТ СТАТУСА ГОТОВНОСТИ
        ReadyStates.Clear()
        ReadyStates.Add(LCase(trans("Страницы нет")), WebBrowserReadyState.Uninitialized)
        ReadyStates.Add(LCase(trans("Страница загружается")), WebBrowserReadyState.Loading)
        ReadyStates.Add(LCase(trans("Страница загружена")), WebBrowserReadyState.Loaded)
        ReadyStates.Add(LCase(trans("Пользователькая активность")), WebBrowserReadyState.Interactive)
        ReadyStates.Add(LCase(trans("Страница полностью готова")), WebBrowserReadyState.Complete)

        ' СОЗДАНИЕ КОНСТАНТ КОДИРОВОК
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

        ' СОЗДАНИЕ КОНСТАНТ ОБНОВЛЕНИЯ
        Refreshs.Clear()
        Refreshs.Add(LCase(trans("Обычно")), WebBrowserRefreshOption.Normal)
        Refreshs.Add(LCase(trans("Полностью")), WebBrowserRefreshOption.Completely)
        Refreshs.Add(LCase(trans("Если устарела")), WebBrowserRefreshOption.IfExpired)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ ОКНА
        FormBorderStyles.Clear()
        FormBorderStyles.Add(LCase(trans("Никакой")), FormBorderStyle.None)
        FormBorderStyles.Add(LCase(trans("Фиксированное простое")), FormBorderStyle.FixedSingle)
        FormBorderStyles.Add(LCase(trans("Фиксированное объемное")), FormBorderStyle.Fixed3D)
        FormBorderStyles.Add(LCase(trans("Фиксированное окно")), FormBorderStyle.FixedDialog)
        FormBorderStyles.Add(LCase(trans("Нормальный")), FormBorderStyle.Sizable)
        FormBorderStyles.Add(LCase(trans("Окно инструментов")), FormBorderStyle.SizableToolWindow)
        FormBorderStyles.Add(LCase(trans("Фиксированное окно инструментов")), FormBorderStyle.FixedToolWindow)

        ' СОЗДАНИЕ КОНСТАНТ СТАРТОВОЙ ПОЗИЦИИ
        StartPositions.Clear()
        StartPositions.Add(LCase(trans("Заданная координатами")), FormStartPosition.Manual)
        StartPositions.Add(LCase(trans("По центру экрана")), FormStartPosition.CenterScreen)
        StartPositions.Add(LCase(trans("Размер по умолчанию")), FormStartPosition.WindowsDefaultBounds)
        StartPositions.Add(LCase(trans("Расположение по умолчанию")), FormStartPosition.WindowsDefaultLocation)

        ' СОЗДАНИЕ КОНСТАНТ СТАТУС ОКНА
        WindowStates.Clear()
        WindowStates.Add(LCase(trans("Нормальный")), FormWindowState.Normal)
        WindowStates.Add(LCase(trans("Свернуто")), FormWindowState.Minimized)
        WindowStates.Add(LCase(trans("Развернуто")), FormWindowState.Maximized)

        ' СОЗДАНИЕ КОНСТАНТ ПОЛОЖЕНИЯ ЗАКЛАДОК ТАБА
        Alignments.Clear()
        Alignments.Add(LCase(trans("Сверху")), TabAlignment.Top)
        Alignments.Add(LCase(trans("Снизу")), TabAlignment.Bottom)
        Alignments.Add(LCase(trans("Слева")), TabAlignment.Left)
        Alignments.Add(LCase(trans("Справа")), TabAlignment.Right)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ РАМКИ ЯЧЕЙКИ
        CellBorderStyles.Clear()
        CellBorderStyles.Add(LCase(trans("Никакой")), DataGridViewCellBorderStyle.None)
        CellBorderStyles.Add(LCase(trans("Выпуклый")), DataGridViewCellBorderStyle.Raised)
        CellBorderStyles.Add(LCase(trans("Выпуклый вертикальный")), DataGridViewCellBorderStyle.RaisedVertical)
        CellBorderStyles.Add(LCase(trans("Выпуклый горизонтальный")), DataGridViewCellBorderStyle.RaisedHorizontal)
        CellBorderStyles.Add(LCase(trans("Обычный")), DataGridViewCellBorderStyle.Single)
        CellBorderStyles.Add(LCase(trans("Обычный вертикальный")), DataGridViewCellBorderStyle.SingleVertical)
        CellBorderStyles.Add(LCase(trans("Обычный горизонтальный")), DataGridViewCellBorderStyle.SingleHorizontal)
        CellBorderStyles.Add(LCase(trans("Вогнутый")), DataGridViewCellBorderStyle.Sunken)
        CellBorderStyles.Add(LCase(trans("Вогнутый вертикальный")), DataGridViewCellBorderStyle.SunkenVertical)
        CellBorderStyles.Add(LCase(trans("Вогнутый горизонтальный")), DataGridViewCellBorderStyle.SunkenHorizontal)

        ' СОЗДАНИЕ КОНСТАНТ РЕЖИМА РЕДАКТИРОВАНИЯ
        EditModes.Clear()
        EditModes.Add(LCase(trans("Нет")), DataGridViewEditMode.EditProgrammatically)
        EditModes.Add(LCase(trans("При получении фокуса")), DataGridViewEditMode.EditOnEnter)
        EditModes.Add(LCase(trans("По клавише F2")), DataGridViewEditMode.EditOnF2)
        EditModes.Add(LCase(trans("Обычный")), DataGridViewEditMode.EditOnKeystroke)
        EditModes.Add(LCase(trans("Обычный и F2")), DataGridViewEditMode.EditOnKeystrokeOrF2)

        ' СОЗДАНИЕ КОНСТАНТ РЕЖИМА ВЫДЕЛЕНИЯ
        SelectionModes.Clear()
        SelectionModes.Add(LCase(trans("Ячейки")), DataGridViewSelectionMode.CellSelect)
        SelectionModes.Add(LCase(trans("Строки")), DataGridViewSelectionMode.FullRowSelect)
        SelectionModes.Add(LCase(trans("Ячейки и строки")), DataGridViewSelectionMode.RowHeaderSelect)

        ' СОЗДАНИЕ КОНСТАНТ РЕЖИМА ВЫДЕЛЕНИЯ
        Filters.Clear()
        Filters.Add(LCase(trans("Вся таблица")), DataGridViewElementStates.None)
        Filters.Add(LCase(trans("Отображаемое на экране")), DataGridViewElementStates.Displayed)
        Filters.Add(LCase(trans("Выделенные стоки")), DataGridViewElementStates.Selected)

        ' СОЗДАНИЕ КОНСТАНТ РЕЖИМА ВЫДЕЛЕНИЯ
        LinkBehaviors.Clear()
        LinkBehaviors.Add(LCase(trans("По умолчанию")), LinkBehavior.SystemDefault)
        LinkBehaviors.Add(LCase(trans("Всегда")), LinkBehavior.AlwaysUnderline)
        LinkBehaviors.Add(LCase(trans("При наведении")), LinkBehavior.HoverUnderline)
        LinkBehaviors.Add(LCase(trans("Никогда")), LinkBehavior.NeverUnderline)

        ' СОЗДАНИЕ КОНСТАНТ КНОПОК СООБЩЕНИЯ
        MsgStyleButtons.Clear()
        MsgStyleButtons.Add(LCase(trans("Прервать Поворить Пропустить")), MsgBoxStyle.AbortRetryIgnore)
        MsgStyleButtons.Add(LCase(trans("Ок Справка")), MsgBoxStyle.MsgBoxHelp)
        MsgStyleButtons.Add(LCase(trans("Ок Отмена")), MsgBoxStyle.OkCancel)
        MsgStyleButtons.Add(LCase(trans("Ок")), MsgBoxStyle.OkOnly)
        MsgStyleButtons.Add(LCase(trans("Повторить Отмена")), MsgBoxStyle.RetryCancel)
        MsgStyleButtons.Add(LCase(trans("Да Нет")), MsgBoxStyle.YesNo)
        MsgStyleButtons.Add(LCase(trans("Да Нет Отмена")), MsgBoxStyle.YesNoCancel)

        ' СОЗДАНИЕ КОНСТАНТ ТИПА СООБЩЕНИЯ
        MsgStyleTypes.Clear()
        MsgStyleTypes.Add(LCase(trans("Обычный")), 0)
        MsgStyleTypes.Add(LCase(trans("Ошибка")), MsgBoxStyle.Critical)
        MsgStyleTypes.Add(LCase(trans("Внимание")), MsgBoxStyle.Exclamation)
        MsgStyleTypes.Add(LCase(trans("Информационное")), MsgBoxStyle.Information)
        MsgStyleTypes.Add(LCase(trans("Вопросительное")), MsgBoxStyle.Question)

        ' СОЗДАНИЕ КОНСТАНТ ТИПА БАЗЫ ДАННЫХ
        BdTypes.Clear()
        BdTypes.Add(LCase("Access"), "Access")
        BdTypes.Add(LCase("Excel"), "Excel")

        ' СОЗДАНИЕ КОНСТАНТ ФОРМАТА ДАТЫ В КАЛЕНДАРЕ
        DateFormats.Clear()
        DateFormats.Add(LCase(trans("Длинная дата")), DateTimePickerFormat.Long)
        DateFormats.Add(LCase(trans("Короткая дата")), DateTimePickerFormat.Short)
        DateFormats.Add(LCase(trans("Время")), DateTimePickerFormat.Time)
        DateFormats.Add(LCase(trans("По выбору")), DateTimePickerFormat.Custom)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ БЕГУНКА
        TickStyles.Clear()
        TickStyles.Add(LCase(trans("Верхний")), Windows.Forms.TickStyle.TopLeft)
        TickStyles.Add(LCase(trans("Нижний")), Windows.Forms.TickStyle.BottomRight)
        TickStyles.Add(LCase(trans("Средний")), Windows.Forms.TickStyle.Both)
        TickStyles.Add(LCase(trans("Никакой")), Windows.Forms.TickStyle.None)

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ БЕГУНКА
        FileEncodings.Clear()
        FileEncodings.Add(LCase(trans("По умолчанию")), System.Text.Encoding.Default)
        FileEncodings.Add(LCase("ASCII"), System.Text.Encoding.ASCII)
        FileEncodings.Add(LCase("BigEndian"), System.Text.Encoding.BigEndianUnicode)
        FileEncodings.Add(LCase(trans("Юникод")), System.Text.Encoding.Unicode)
        FileEncodings.Add(LCase(trans("Юникод") & "32"), System.Text.Encoding.UTF32)
        FileEncodings.Add(LCase(trans("Юникод") & "7"), System.Text.Encoding.UTF7)
        FileEncodings.Add(LCase(trans("Юникод") & "8"), System.Text.Encoding.UTF8)
        FileEncodings.Add("""" & "DOS-866" & """", System.Text.Encoding.GetEncoding(866))
        Dim encs() As EncodingInfo = System.Text.Encoding.GetEncodings
        For i = 0 To encs.Length - 1
            If FileEncodings.ContainsKey("""" & encs(i).Name & """") = False Then
                FileEncodings.Add("""" & encs(i).Name & """", encs(i).GetEncoding)
            End If
        Next

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ РИСУНКА
        SizeModes.Clear()
        SizeModes.Add(LCase(trans("По умолчанию")), PictureBoxSizeMode.Normal)
        SizeModes.Add(LCase(trans("Растянутый")), PictureBoxSizeMode.StretchImage)
        SizeModes.Add(LCase(trans("Авторазмер")), PictureBoxSizeMode.AutoSize)
        SizeModes.Add(LCase(trans("По центру")), PictureBoxSizeMode.CenterImage)
        SizeModes.Add(LCase(trans("Масштабированный")), PictureBoxSizeMode.Zoom)

        ' СОЗДАНИЕ КОНСТАНТ ТИПА ВВОДА
        InputTypes.Clear()
        InputTypes.Add(LCase(trans("Все")), trans("Все"))
        InputTypes.Add(LCase(trans("Только цифры")), trans("Только цифры"))
        InputTypes.Add(LCase(trans("Только буквы")), trans("Только буквы"))
        InputTypes.Add(LCase(trans("Только латинские буквы")), trans("Только латинские буквы"))
        InputTypes.Add(LCase(trans("Только буквы и цифры")), trans("Только буквы и цифры"))
        InputTypes.Add(LCase(trans("Только латинские буквы и цифры")), trans("Только латинские буквы и цифры"))

        ' СОЗДАНИЕ КОНСТАНТ СТАТУСОВ КЛИЕНТ-СЕРВЕРА
        ClientServStates.Clear()
        ClientServStates.Add(LCase(trans("Закрыт")), 0)
        ClientServStates.Add(LCase(trans("Прослушивается")), 1)
        ClientServStates.Add(LCase(trans("Вычисляется хост")), 2)
        ClientServStates.Add(LCase(trans("Вычислился хост")), 3)
        ClientServStates.Add(LCase(trans("Соединение")), 4)
        ClientServStates.Add(LCase(trans("Соединился")), 5)
        ClientServStates.Add(LCase(trans("Закрытие")), 6)

        ' СОЗДАНИЕ КОНСТАНТ ТИПОВ КЛИЕНТ-СЕРВЕРА
        ClientServerTypes.Clear()
        ClientServerTypes.Add(LCase(trans("Клиент")), trans("Клиент"))
        ClientServerTypes.Add(LCase(trans("Сервер")), trans("Сервер"))

        ' СОЗДАНИЕ КОНСТАНТ ТИПОВ СОДЕРЖИМОГО ЗАПРОСА
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

        ' СОЗДАНИЕ КОНСТАНТ МЕТОДА ЗАПРОСА
        HttpMethods.Clear()
        HttpMethods.Add(("GET"), """GET""")
        HttpMethods.Add(("POST"), """POST""")

        ' СОЗДАНИЕ КОНСТАНТ СТИЛЯ ПОЛОСЫ ЗАГРУЗКИ
        StylesProgress.Clear()
        StylesProgress.Add(LCase(trans("Блоки")), ProgressBarStyle.Blocks)
        StylesProgress.Add(LCase(trans("Непрерывность")), ProgressBarStyle.Continuous)
        StylesProgress.Add(LCase(trans("Анимация")), ProgressBarStyle.Marquee)

    End Sub
    Sub CreateHelpWords()
        ' ОБОЗНАЧЕНИЕ СВОЙСТВ ТОЛЬКО ДЛЯ ЧТЕНИЯ
        SetReadOnlys()

        Dim i, j, ind As Integer
        ' СОЗДАНИЕ СПИСКА ВСЕХ ВСПОМОГАТЕЛЬНЫХ СЛОВ
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

        ' ДаНет
        ind = 0 : ReDim Preserve HWDaNet(ind) : HWDaNet(ind) = trans("Да")
        ind += 1 : ReDim Preserve HWDaNet(ind) : HWDaNet(ind) = trans("Нет")
        ' КнопкиМыши
        ind = 0 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("Левая")
        ind += 1 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("Правая")
        ind += 1 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("Колесико")
        ind += 1 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("ДопКнопка1")
        ind += 1 : ReDim Preserve HWKnopkiMishi(ind) : HWKnopkiMishi(ind) = trans("ДопКнопка2")
        ' Разрешения экрана
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
        ' прочее
        ind = 0 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("Никакой")
        ind += 1 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("Да")
        ind += 1 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("Нет")
        ind += 1 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("Все")
        ind += 1 : ReDim Preserve HWOthers(ind) : HWOthers(ind) = trans("Символ новой строки")

        ' Все вспомогательные слова
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
        ' Все вспомогательные слова в высоком регистре
        ReDim AllHWUp(AllHW.Length - 1)
        For i = 0 To AllHW.Length - 1 : AllHWUp(i) = UCase(AllHW(i)) : Next

        CreateHWCategrs()
        If isDevelop And isRUN() = False Then CreateHWMenu()
    End Sub
    Sub CreateHWCategrs()
        ' Запись в HWCategrs всех категорий вспомогателных слов
        Dim tempHWCats() As String = { _
            trans("Прочие"), trans("Цвета"), trans("Папки"), trans("Кнопки мыши"), trans("Клавиши") _
            , trans("Привязки"), trans("Стиль фона"), trans("Курсоры"), trans("Растяжки"), trans("Стиль кнопки"), trans("Шрифт") _
            , trans("Положения"), trans("Текст и рисунок"), trans("Фиксированная панель"), trans("Стиль рамки"), trans("Ориентация") _
            , trans("Стиль рабочего стола"), trans("Разрешение экрана"), trans("Тип ключа реестра"), trans("Расположение текста"), trans("Полосы прокрутки") _
            , trans("Стиль отображения"), trans("Направление текста"), trans("Статус готовности"), trans("Кодировка") _
            , trans("Обновить страницу"), trans("Стиль окна"), trans("Стартовая позиция"), trans("Статус окна") _
            , trans("Положение закладок"), trans("Стиль рамки ячейки"), trans("Режим редактирования"), trans("Режим выделения") _
            , trans("Фильтры"), trans("Стиль подчеркивания"), trans("Кнопки сообщения"), trans("Тип сообщения") _
            , trans("Тип базы данных"), trans("Формат даты календаря"), trans("Стиль бегунка") _
            , trans("Кодировка текста"), trans("Стиль рисунка"), trans("Тип ввода"), trans("Статус клиент сервера") _
            , trans("Тип клиент сервера"), trans("Тип содержимого"), trans("Метод запроса"), trans("Стиль загрузки") _
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
    ' СОЗДАНИЕ НАБОРОВ И СПИСКОВ ДЛЯ МАСТЕРА
    Sub CreateArrays()
        Dim i, j As Integer
        ' Создание списка дополнительных функций
        Dim TempF() As String = { _
            trans("Нет"), trans("Корень"), trans("Корень3"), trans("Квадрат"), trans("Модуль"), _
            trans("Синус"), trans("Косинус"), trans("Тангенс"), _
            trans("АркСинус"), trans("АркКосинус"), trans("АркТангенс"), _
            trans("Экспонента"), trans("Логарифм"), trans("Логарифм10"), _
            trans("Округлить"), trans("Округлить денежное"), trans("Сменить знак (+/-)"), _
            trans("Инвертировать (Да/Нет)"), trans("Случайное число (от 1 до введенного)")}
        DopFuns = TempF

        ' Создание списка дополнительных функций, не считая за функцию первую строку - "Нет"
        ReDim DopFunsSimple(DopFuns.Length - 2)
        For i = 0 To DopFuns.Length - 2
            If DopFuns(i + 1).IndexOf(" (") <> -1 Then
                DopFunsSimple(i) = UCase(DopFuns(i + 1).Substring(0, DopFuns(i + 1).IndexOf(" (")))
            Else
                DopFunsSimple(i) = UCase(DopFuns(i + 1))
            End If
        Next

        ' Создание списка математических операций
        Dim TempO() As String = {"&    (" & transInfc("Склеить строки") & ")", _
            "+    (" & transInfc("Сложить") & ")", "-     (" & transInfc("Вычесть") & ")", _
            "*    (" & transInfc("Умножить") & ")", "/    (" & transInfc("Разделить") & ")", _
            "\    (" & transInfc("Разделить нацело") & ")", "%    (" & transInfc("Остаток деления") & ")", _
            "^    (" & transInfc("Возведение в степень") & ")"}
        Operations = TempO
        ReDim opers(Operations.Length - 1)
        For i = 0 To Operations.Length - 1
            opers(i) = Operations(i)
            If Operations(i).IndexOf(" (") <> -1 Then
                opers(i) = opers(i).Substring(0, opers(i).IndexOf(" ("))
            End If
            opers(i) = Trim(opers(i))
        Next
        ' Создание списка логических операций
        Dim TempU() As String = { _
            "=    (" & transInfc("Если равно") & ")", "<=>    (" & transInfc("Равно c учетом регистра") & ")", _
            "<>   (" & transInfc("Если неравно") & ")", _
            ">    (" & transInfc("Если больше") & ")", "<   (" & transInfc("Если меньше") & ")", _
            ">=    (" & transInfc("Больше либо равно") & ")", "<=   (" & transInfc("Меньше либо равно") & ")", _
            trans("_И"), trans("_ИЛИ")}
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

        ' Разбиение всех операторов по приоритетам
        Dim TempP0() As String = {"&"}
        Dim TempP1() As String = {"^"}
        Dim TempP2() As String = {"*", "/", "\", "%"}
        Dim TempP3() As String = {"+", "-"}
        Dim TempP4() As String = {"=", "<=>", "<", ">", "<>", "<=", ">=", "=<", "=>"}
        Dim TempP5() As String = {trans("_И"), trans("_ИЛИ")}
        Dim TempP() As Object = {TempP0, TempP1, TempP2, TempP3, TempP4, TempP5}
        Prioritets = TempP
        ' Создание списка прочих зарезервированных символов
        Dim TempOther() As String = {",", "(", ")", "[", "]", """"}
        othersSimb = TempOther
        ' Создание полного списка зарезервированных символов
        Dim mass() As Object = {uslovs, othersSimb}
        For i = 0 To mass.Length - 1
            For j = 0 To mass(i).Length - 1
                ReDim Preserve allSimb(i + j) : allSimb(i + j) = mass(i)(j)
            Next
        Next
        ' Список ключевых слов VB для избежания ошибок в компиляторе
        VBKeyWords = New String() {"and", "or", "not", "nothing", "is", "isnot", _
                                   "dim", "as", "string", "object", "integer", "char", "new", "public", "private", _
                                   "class", "module", "array", "function", "event", "handles", "redim", "preserve", _
                                   "if", "then", "else", "elseif", "end", _
                                   "for", "to", "next", "step", "while", "do", "loop", "until"}
        ' создание регярной строки запретных символов
        noSimb = "[^\."
        For i = 0 To allSimb.Length - 1
            noSimb &= "\" & allSimb(i)
        Next : noSimb &= "]"

        ' СОЗДАНИЕ СПИСКА ВСЕХ ВОЗМОЖНЫХ ФУНКЦИЙ
        ind = 0 : Dim Massivs() As Object = {DopFunsSimple}
        For i = 0 To Massivs.Length - 1
            For j = 0 To Massivs(i).Length - 1
                ReDim Preserve AllFuncs(ind) : AllFuncs(ind) = Massivs(i)(j) : ind += 1
            Next
        Next
    End Sub

    ' СОЗДАНИЕ ОБЪЕКТОВ
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
        Pustishki.Add("Сr", New Calendar(True))
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
        ' Если это большой сборный объект, то настроить его так, чтобы обработчики событий не работали в самой среде
        If isDevelop And isRun = False Then SettingDevelop(MyObjs(MyObjs.Length - 1))
    End Sub
    Sub CreatePoleznie()
        PoleznieObjs = Nothing
        ' Создание массива полезных объектов
        Dim ind As Integer = 0 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Экран"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Файлы и папки"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Прерывания"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Система"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Реестр"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Вызвать событие"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Текст"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Показать сообщение"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Дата"))
        ind += 1 : ReDim Preserve PoleznieObjs(ind)
        PoleznieObjs(ind) = New Poleznie(MyZnak & trans("Расширенные возможности"))
    End Sub
    ' ЕСЛИ ОБЪЕКТ USERCONTROL
    Function ObjectsInPaths(ByVal ListTypes() As String) As ArrayList
        ' Объекты хранящиеся в отдельных папках. Нужно их найти, чтобы подключить при компиляции
        Dim sourcs As New ArrayList
        ' ВНИМАНИЕ! Незабудь подставно объявить в Peremens3.vb этот класс!
        If Array.IndexOf(ListTypes, "ClientServer") <> -1 Then sourcs.Add(" """ & CompilPath & "ClientServer\*.vb""")
        If Array.IndexOf(ListTypes, "Internet") <> -1 Then sourcs.Add(" """ & CompilPath & "Internet\*.vb""")
        ' ВНИМАНИЕ! Незабудь подставно объявить в Peremens3.vb этот класс!
        Return sourcs
    End Function
    Sub SettingDevelop(ByVal MyObj As Object)
        ' Если это большой сборный объект, то настроить его так, чтобы обработчики событий не работали в самой среде
        If Iz.IsI(MyObj) Or Iz.IsCS(MyObj) Then
            MyObj.obj.isDevelop = True
        End If
    End Sub


    ' Доп. Фунции
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
        If Trim(vl) = "1" Or UCase(Trim(vl)) = UCase(Trim(trans("Да"))) Then
            Return """" & trans("Нет") & """"
        ElseIf Trim(vl) = "0" Or UCase(Trim(vl)) = UCase(Trim(trans("Нет"))) Then
            Return """" & trans("Да") & """"
        Else
            Return ""
        End If
    End Function


End Module