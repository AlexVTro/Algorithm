Public Structure PropertysSobyt
    Public err As ErrString
    Public bylBreakpoint As TreeNode
    Public MyObj As Object
    Public Paramy As System.Collections.SortedList
    Public ParamyUp As System.Collections.SortedList
    Public eType As String
    Public e, sender As Object

    Sub New(ByVal sender As Object, ByVal e As Object, ByVal type As System.Type, Optional ByVal sobyt As String = "")
        Paramy = New System.Collections.SortedList()
        If type Is Nothing Then type = Me.GetType
        Me.e = e : Me.sender = sender
        If isCompilBest And isDevelop = False Then RunProj.Param = Me
        ' Создать для каждого события свои свойства
        'If type.ToString = "System.Windows.Forms.EventArgs" Or type.ToString = "System.Windows.Forms.ScrollEventArgs" _
        'Or sobyt = trans("Наведение курсора") Or sobyt = trans("Отведение курсора") _
        'Or sobyt = trans("Курсор на объекте") Or sobyt = trans("Изменение текста") _
        'Or sobyt = trans("Получение фокуса") Or sobyt = trans("Потеря фокуса") _
        'Or sobyt = trans("Прокрутка") Or sobyt = trans("Прокрутка1") Or sobyt = trans("Прокрутка2") _
        'Or sobyt = trans("Изменились размеры") Or sobyt = trans("Изменилось выделение") _
        'Or sobyt = trans("Создание") Or sobyt = trans("Прорисовка") Or sobyt = MyZnak & "All" Then

        'End If
        If e Is Nothing Then eType = "System.EventArgs"

        If type.ToString = "System.Windows.Forms.MouseEventArgs" _
        Or sobyt = trans("Нажатие кнопки мыши") Or sobyt = trans("Отжатие кнопки мыши") _
        Or sobyt = trans("Движение курсора") _
        Or sobyt = trans("Вращение колесика") Or sobyt = MyZnak & "All" Then
            Paramy.Add(MyZnak & trans("Кнопка мыши"), MyZnak & "last") ' Определение кнопки мыши
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), OpredKnopky(e.Button))
            Paramy.Add(MyZnak & trans("Мышь X"), MyZnak & "last") ' Определение положения Х мыши
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.X)
            Paramy.Add(MyZnak & trans("Мышь Y"), MyZnak & "last") ' Определение положения Y мыши
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Y)
            Paramy.Add(MyZnak & trans("Прокручено колесиком"), MyZnak & "last") ' сколько прокручено колесиком раз
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Delta)
            Paramy.Add(MyZnak & trans("Количество кликов"), MyZnak & "last") ' кол-во кликов (один или двойной)
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Clicks)
            If e Is Nothing Then eType = "System.Windows.Forms.MouseEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.KeyPressEventArgs" _
        Or sobyt = trans("Нажатие клавиатуры") Or sobyt = MyZnak & "All" Then
            Paramy.Add(MyZnak & trans("Введенный символ"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.KeyChar)
            Paramy.Add(MyZnak & trans("Отменить ввод"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), DaOrNet(e.handled))
            If e Is Nothing Then eType = "System.Windows.Forms.KeyPressEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.KeyEventArgs" _
        Or sobyt = trans("Нажатие вниз кнопки") Or sobyt = trans("Отжатие кнопки") Or sobyt = MyZnak & "All" Then
            Dim a As Windows.Forms.Keys
            Paramy.Add(MyZnak & trans("Нажатая клавиша"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), [Enum].GetName(a.GetType(), e.KeyCode))
            Paramy.Add(MyZnak & trans("Нажат шифт"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), DaOrNet(e.Shift))
            Paramy.Add(MyZnak & trans("Нажат контрол"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), DaOrNet(e.Control))
            Paramy.Add(MyZnak & trans("Нажат альт"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), DaOrNet(e.Alt))
            If e Is Nothing Then eType = "System.Windows.Forms.KeyEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.SplitterEventArgs" _
        Or sobyt = trans("Разделитель перемещен") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Разделитель X"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.SplitX)
            Paramy.Add(MyZnak & trans("Разделитель Y"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.SplitY)
            Paramy.Add(MyZnak & trans("Мышь X"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.X)
            Paramy.Add(MyZnak & trans("Мышь Y"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Y)
            If e Is Nothing Then eType = "System.Windows.Forms.SplitterEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.SplitterCancelEventArgs" _
        Or sobyt = trans("Разделитель перемещается") Or sobyt = MyZnak & "All" Then
            On Error Resume Next

            Paramy.Add(MyZnak & trans("Разделитель X"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.SplitX)
            Paramy.Add(MyZnak & trans("Разделитель Y"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.SplitY)
            Paramy.Add(MyZnak & trans("Мышь X"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.MouseCursorX)
            Paramy.Add(MyZnak & trans("Мышь Y"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.MouseCursorY)
            Paramy.Add(MyZnak & trans("Отменить перемещение"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), trans("Нет"))
            If e Is Nothing Then eType = "System.Windows.Forms.SplitterCancelEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.WebBrowserDocumentCompletedEventArgs" _
        Or sobyt = trans("Страница загрузилась") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Ссылка"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Url.AbsoluteUri)
            If e Is Nothing Then eType = "System.Windows.Forms.WebBrowserDocumentCompletedEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.WebBrowserNavigatingEventArgs" _
        Or sobyt = trans("Переходит по ссылке") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Ссылка"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Url.AbsoluteUri)
            If e Is Nothing Then eType = "System.Windows.Forms.WebBrowserNavigatingEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.WebBrowserNavigatedEventArgs" _
        Or sobyt = trans("Перешел по ссылке") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Ссылка"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Url.AbsoluteUri)
            If e Is Nothing Then eType = "System.Windows.Forms.WebBrowserNavigatedEventArgs"
        End If

        If type.ToString = "System.ComponentModel.CancelEventArgs" _
        Or sobyt = trans("Открытие в новом окне") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Отменить в новом окне"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), trans("Нет"))
            If e Is Nothing Then eType = "System.Windows.Forms.CancelEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.TabControlCancelEventArgs" _
        Or sobyt = trans("Снимается выделение закладки") Or sobyt = trans("Выделяют закладку") _
        Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер выделенной закладки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.tabPage.props.Index)
            Paramy.Add(MyZnak & trans("Отменить событие"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), trans("Нет"))
            If e Is Nothing Then eType = "System.Windows.Forms.TabControlCancelEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.TabControlEventArgs" Or sobyt = trans("Снялось выделение закладки") _
        Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер выделенной закладки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.tabPage.props.Index)
            If e Is Nothing Then eType = "System.Windows.Forms.TabControlEventArgs"
        End If

        If sobyt = trans("Выделили закладку") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер выделенной закладки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), sender.obj.props.SelectedTabIndex)
        End If

        If type.ToString = "System.String" Or sobyt = trans("Изменение значения") _
        Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Отменить событие"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), trans("Нет"))
            If e Is Nothing Then eType = "String"
        End If

        If type.ToString = "System.Windows.Forms.DataGridViewCellCancelEventArgs" _
            Or sobyt = trans("Начало редактирования ячейки") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер строки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.RowIndex)
            Paramy.Add(MyZnak & trans("Номер столбца"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.ColumnIndex)
            Paramy.Add(MyZnak & trans("Отменить событие"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), trans("Нет"))
            If e Is Nothing Then eType = "System.Windows.Forms.DataGridViewCellCancelEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.DataGridViewCellEventArgs" _
        Or sobyt = trans("Клик по ячейке") Or sobyt = trans("Двойной клик по ячейке") _
        Or sobyt = trans("Конец редактирования ячеки") Or sobyt = trans("Ячейка в фокусе") _
        Or sobyt = trans("Ячека потеряла фокус") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер строки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.RowIndex)
            Paramy.Add(MyZnak & trans("Номер столбца"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.ColumnIndex)
            If e Is Nothing Then eType = "System.Windows.Forms.DataGridViewCellEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.DataGridViewColumnEventArgs" _
        Or sobyt = trans("Столбец переместили") Or sobyt = trans("Сортировка столбца") _
        Or sobyt = trans("Изменилась ширина столбца") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер столбца"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Column.Index)
            If e Is Nothing Then eType = "System.Windows.Forms.DataGridViewColumnEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.DataGridViewCellMouseEventArgs" _
        Or sobyt = trans("Двойной клик по заголовку столбца") Or sobyt = trans("Клик по заголовку строки") _
        Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Кнопка мыши"), MyZnak & "last") ' Определение кнопки мыши
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), OpredKnopky(e.Button))
            Paramy.Add(MyZnak & trans("Мышь X"), MyZnak & "last") ' Определение положения Х мыши
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.X)
            Paramy.Add(MyZnak & trans("Мышь Y"), MyZnak & "last") ' Определение положения Y мыши
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Y)
            Paramy.Add(MyZnak & trans("Прокручено колесиком"), MyZnak & "last") ' сколько прокручено колесиком раз
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Delta)
            Paramy.Add(MyZnak & trans("Количество кликов"), MyZnak & "last") ' кол-во кликов (один или двойной)
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Clicks)
            Paramy.Add(MyZnak & trans("Номер строки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.RowIndex)
            Paramy.Add(MyZnak & trans("Номер столбца"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.ColumnIndex)
            If e Is Nothing Then eType = "System.Windows.Forms.DataGridViewCellMouseEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.DataGridViewRowEventArgs" _
        Or sobyt = trans("Изменилась вышина строки") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер строки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.Row.Index)
            If e Is Nothing Then eType = "System.Windows.Forms.DataGridViewRowEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.DataGridViewRowsAddedEventArgs" _
        Or sobyt = trans("Добавли строку") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер начальной строки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.RowIndex)
            Paramy.Add(MyZnak & trans("Количество строк"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.RowCount)
            If e Is Nothing Then eType = "System.Windows.Forms.DataGridViewRowsAddedEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.DataGridViewRowsRemovedEventArgs" _
        Or sobyt = trans("Удалили строку") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Номер начальной строки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.RowIndex)
            Paramy.Add(MyZnak & trans("Количество строк"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.RowCount)
            If e Is Nothing Then eType = "System.Windows.Forms.DataGridViewRowsRemovedEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.LinkClickedEventArgs" _
        Or sobyt = trans("Клик по ссылке документа") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Текст ссылки"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.LinkText)
            If e Is Nothing Then eType = "System.Windows.Forms.LinkClickedEventArgs"
        End If

        If type.ToString = "System.ComponentModel.CancelEventArgs" Or sobyt = trans("Открытие") _
        Or sobyt = trans("Отправляется запрос") Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Отменить событие"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), trans("Нет"))
            If e Is Nothing Then eType = "System.ComponentModel.CancelEventArgs"
        End If

        If type.ToString = "System.Windows.Forms.ToolStripDropDownClosingEventArgs" Or sobyt = trans("Закрытие") _
        Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Отменить событие"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), trans("Нет"))
            If e Is Nothing Then eType = "System.Windows.Forms.ToolStripDropDownClosingEventArgs"
        End If

        ' СЕРВЕР-КЛИЕНТ

        If type.ToString = ClassAplication & "WinsockConnectionRequestEventArgs" Or sobyt = trans("Присоединился клиент") _
        Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Отменить событие"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), trans("Нет"))
            Paramy.Add(MyZnak & trans("Ip клиента"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.ClientIP)
            eType = "WinsockConnectionRequestEventArgs"
        End If

        If type.ToString = ClassAplication & "WinsockCollectionCountChangedEventArgs" _
        Or sobyt = trans("Изменилось число клиентов") _
        Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Было клиентов"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.OldCount)
            Paramy.Add(MyZnak & trans("Стало клиентов"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.NewCount)
            eType = "WinsockCollectionCountChangedEventArgs"
        End If

        If type.ToString = ClassAplication & "WinsockErrorReceivedEventArgs" _
        Or sobyt = trans("Произошла ошибка") _
        Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Ошибка приема"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.ErrorCode & e.Function & "   " & e.Message & e.Details)
            eType = "WinsockErrorReceivedEventArgs"
        End If

        If type.ToString = ClassAplication & "WinsockSendEventArgs" _
      Or sobyt = trans("Отправился текст") Or sobyt = trans("Отправился файл") Or sobyt = trans("Отправилась команда") _
      Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Процент переданного"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.SentPercent)
            Paramy.Add(MyZnak & trans("Ip получателя"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.DestinationIP)
            Paramy.Add(MyZnak & trans("Всего байт"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.BytesTotal)
            Paramy.Add(MyZnak & trans("Отправлено байт"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.BytesSent)
            eType = "WinsockSendEventArgs"
        End If

        If type.ToString = ClassAplication & "WinsockReceiveProgressEventArgs" _
          Or sobyt = trans("Идет прием данных") _
          Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Процент полученного"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.ReceivedPercent)
            Paramy.Add(MyZnak & trans("Ip источника"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.SourceIP)
            Paramy.Add(MyZnak & trans("Всего байт"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.BytesTotal)
            Paramy.Add(MyZnak & trans("Получено байт"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), e.BytesReceived)
            eType = "WinsockReceiveProgressEventArgs"
        End If

        If type.ToString = ClassAplication & "WinsockStateChangedEventArgs" _
          Or sobyt = trans("Изменился статус") _
          Or sobyt = MyZnak & "All" Then
            On Error Resume Next
            Paramy.Add(MyZnak & trans("Старый статус"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), ClientServStates.GetByIndex(ClientServStates.IndexOfValue(e.Old_State)))
            Paramy.Add(MyZnak & trans("Новый статус"), MyZnak & "last")
            If e Is Nothing = False Then Paramy.SetByIndex(Paramy.IndexOfValue(MyZnak & "last"), ClientServStates.GetByIndex(ClientServStates.IndexOfValue(e.New_State)))
            eType = "WinsockStateChangedEventArgs"
        End If

        If sobyt = trans("Прорисовка") Then
            If e Is Nothing Then eType = "System.Windows.Forms.PaintEventArgs"
        ElseIf sobyt = trans("Клик по выделенной ячейке") Then
            If e Is Nothing Then eType = "System.Windows.Forms.DataGridViewCellMouseEventArgs"
        ElseIf sobyt = trans("Открытие в новом окне") Then
            If e Is Nothing Then eType = "System.ComponentModel.CancelEventArgs"
        ElseIf sobyt = trans("Прокрутка") Then
            If e Is Nothing Then eType = "System.Windows.Forms.ScrollEventArgs"
        ElseIf sobyt = trans("Закрытие окна") Then
            If e Is Nothing Then eType = "System.Windows.Forms.FormClosingEventArgs"
        ElseIf sobyt = trans("Закрылось") Then
            If e Is Nothing Then eType = "System.Windows.Forms.ToolStripDropDownClosedEventArgs"
        ElseIf sobyt = trans("Клик по ссылке") Then
            If e Is Nothing Then eType = "System.Windows.Forms.LinkLabelLinkClickedEventArgs"
        ElseIf sobyt = trans("Присоединились к серверу") Then
            eType = "WinsockConnectedEventArgs"
        End If
        Dim i As Integer
        ParamyUp = New System.Collections.SortedList()
        For i = 0 To Paramy.Count - 1
            ParamyUp.Add(UCase(Paramy.GetKey(i)), Paramy.GetByIndex(i))
        Next

        MyObj = sender
        If isCompilBest And isDevelop = False Then RunProj.Param = Me
    End Sub

    Function OpredKnopky(ByVal but As Windows.Forms.MouseButtons) As String
        ' Определение кнопки мыши
        Dim knopka As String = trans("Никакой")
        Select Case but
            Case MouseButtons.Left : knopka = trans("Левая")
            Case MouseButtons.Right : knopka = trans("Правая")
            Case MouseButtons.Middle : knopka = trans("Колесико")
            Case MouseButtons.XButton1 : knopka = trans("ДопКнопка1")
            Case MouseButtons.XButton2 : knopka = trans("ДопКнопка2")
        End Select
        Return knopka
    End Function

    Public Sub Zavershit()
        Dim i As Integer
        If e IsNot Nothing Then
            For i = 0 To ParamyUp.Count - 1
                ' Если захотели отменить событие, то сделать это благодаря переменной e, переданной ByRef
                If Array.IndexOf(SobytsNotReadOnly, ParamyUp.GetKey(i)) <> -1 Then
                    If ParamyUp.GetKey(i) = UCase(MyZnak & trans("Отменить ввод")) Then
                        e.Handled = DaOrNet(ParamyUp.GetByIndex(i))
                    Else
                        e.Cancel = DaOrNet(ParamyUp.GetByIndex(i))
                    End If
                End If
            Next
        End If
    End Sub
End Structure

Public Class PropertysOther
    Public obj As Object
    Sub New(ByVal ob As Object)
        obj = ob
    End Sub
    Overloads Property Name() As String
        Get
            Return obj.Name
        End Get
        Set(ByVal value As String)
            Dim oldName As String = obj.Name : obj.Name = value
            If proj Is Nothing = False Then proj.ChangeName(Me, oldName)
        End Set
    End Property
    Overloads Property Index() As String
        Get
            Return "0"
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Property Type() As String
        Get
            Dim myObj = obj.MyObj
            If myObj Is Nothing = False Then
                Return myObj.obj.defaultName
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    ' FILEPATH
    Function GetAttribs(ByVal args() As String, ByVal attr As String) As String
        Dim path As String = UbratKovich(GetMaxPath(args(0))).str
        Dim attribs As IO.FileAttributes = IO.File.GetAttributes(path)
        Dim est As Integer = [Enum].Format(attribs.GetType, attribs, "g").IndexOf(attr)
        If est <> -1 Then Return trans("Да") Else Return trans("Нет")
    End Function
    Sub SetAttribs(ByVal args() As String, ByVal value As String, ByVal attr As String)
        Dim path As String = GetMaxPath(args(0))
        Dim attribs As IO.FileAttributes = IO.File.GetAttributes(path)
        Dim est As Integer = [Enum].Format(attribs.GetType, attribs, "g").IndexOf(attr)
        If est = -1 And value = trans("Да") Then
            attribs += IO.FileAttributes.Hidden : IO.File.SetAttributes(path, attribs)
        ElseIf est <> -1 And value = trans("Нет") Then
            attribs -= IO.FileAttributes.Hidden : IO.File.SetAttributes(path, attribs)
        End If
    End Sub
    Overloads Property Hider(ByVal ParamArray args() As String)
        Get
            Return GetAttribs(args, "Hidden")
        End Get
        Set(ByVal value)
            SetAttribs(args, value, "Hidden")
        End Set
    End Property
    Overloads Property FileReadOnly(ByVal ParamArray args() As String)
        Get
            Return GetAttribs(args, "ReadOnly")
        End Get
        Set(ByVal value)
            SetAttribs(args, value, "ReadOnly")
        End Set
    End Property
    Overloads Property Archive(ByVal ParamArray args() As String)
        Get
            Return GetAttribs(args, "Archive")
        End Get
        Set(ByVal value)
            SetAttribs(args, value, "Archive")
        End Set
    End Property
    Overloads Property Folder(ByVal ParamArray args() As String)
        Get
            Return GetAttribs(args, "Directory")
        End Get
        Set(ByVal value)
            SetAttribs(args, value, "Directory")
        End Set
    End Property
    Overloads Property Encrypted(ByVal ParamArray args() As String)
        Get
            Return GetAttribs(args, "Encrypted")
        End Get
        Set(ByVal value)
            SetAttribs(args, value, "Encrypted")
        End Set
    End Property
    Overloads Property notIndexer(ByVal ParamArray args() As String)
        Get
            Return GetAttribs(args, "NotContentIndexed")
        End Get
        Set(ByVal value)
            SetAttribs(args, value, "NotContentIndexed")
        End Set
    End Property
    Overloads Property Sys(ByVal ParamArray args() As String)
        Get
            Return GetAttribs(args, "System")
        End Get
        Set(ByVal value)
            SetAttribs(args, value, "System")
        End Set
    End Property
    Overloads Property Temp(ByVal ParamArray args() As String)
        Get
            Return GetAttribs(args, "Temporary")
        End Get
        Set(ByVal value)
            SetAttribs(args, value, "Temporary")
        End Set
    End Property
    Overloads Property CreateTime(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return ToMyDate(IO.File.GetCreationTime(path))
        End Get
        Set(ByVal value)
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            If IO.File.Exists(path) Then
                IO.File.SetCreationTime(path, value)
            ElseIf IO.Directory.Exists(path) Then
                IO.Directory.SetCreationTime(path, value)
            End If
        End Set
    End Property
    Overloads Property AccessTime(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return ToMyDate(IO.File.GetLastAccessTime(path))
        End Get
        Set(ByVal value)
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            If IO.File.Exists(path) Then
                IO.File.SetLastAccessTime(path, value)
            ElseIf IO.Directory.Exists(path) Then
                IO.Directory.SetLastAccessTime(path, value)
            End If
        End Set
    End Property
    Overloads Property EditTime(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return ToMyDate(IO.File.GetLastWriteTime(path))
        End Get
        Set(ByVal value)
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            If IO.File.Exists(path) Then
                IO.File.SetLastWriteTime(path, value)
            ElseIf IO.Directory.Exists(path) Then
                IO.Directory.SetLastWriteTime(path, value)
            End If
        End Set
    End Property
    Overloads Property ExistFile(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return DaOrNet(IO.File.Exists(path))
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property ExistPath(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return DaOrNet(IO.Directory.Exists(path))
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetFiles(ByVal ParamArray args() As String)
        Get
            Dim str As String = "", i As Integer
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Dim strs() As String = System.IO.Directory.GetFiles(path)
            For i = 0 To strs.Length - 1
                str &= strs(i)
                If i < strs.Length - 1 Then str &= "; "
            Next
            Return str
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetPaths(ByVal ParamArray args() As String)
        Get
            Dim str As String = "", i As Integer
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Dim strs() As String = System.IO.Directory.GetDirectories(path)
            For i = 0 To strs.Length - 1
                str &= strs(i)
                If i < strs.Length - 1 Then str &= "; "
            Next
            Return str
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetRoot(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return System.IO.Directory.GetDirectoryRoot(path)
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetParent(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return System.IO.Path.GetDirectoryName(path)
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetDrives()
        Get
            Dim str As String = "", i As Integer
            Dim strs() As String = System.IO.Directory.GetLogicalDrives()
            For i = 0 To strs.Length - 1
                str &= strs(i)
                If i < strs.Length - 1 Then str &= "; "
            Next
            Return str
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetPathName(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return System.IO.Directory.GetParent(path).Name
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetFileName(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(args(0)).str
            Return System.IO.Path.GetFileName(path)
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetExtension(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(args(0)).str
            Return System.IO.Path.GetExtension(path)
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetFileNameWithoutExtension(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            If IO.Directory.Exists(path) Then Return System.IO.Path.GetFileName(path)
            Return System.IO.Path.GetFileNameWithoutExtension(path)
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property GetFileSize(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            If NikakoiEsli(path) = trans("Никакой") Then Return "0"
            Try
                Dim fi As New IO.FileInfo(path)
                Return fi.Length
            Catch ex As Exception
                If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
            End Try
        End Get
        Set(ByVal value)
        End Set
    End Property
    Sub SaveInFile(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            System.IO.File.WriteAllText(args(0), args(1), GetEncodText(args(2)))
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Function OpenFile(ByVal ParamArray args() As String) As String
        Try
            If NikakoiEsli(args(0)) = trans("Никакой") Then Return ""
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            ' Return System.IO.File.ReadAllText(args(0), GetEncodText(args(1)))
            'Dim fl As New IO.StreamReader(args(0)), GetEncodText(args(1))
            'Dim txt = fl.ReadToEnd
            'txt = fl.ReadLine : fl.Close()
            'Return txt
            Dim buf As Integer = 500000
            Dim myStreamReader As New IO.BinaryReader(New IO.StreamReader(args(0)).BaseStream, GetEncodText(args(1)))
            Dim all As New System.Collections.Generic.List(Of Byte)
            Do
                Application.DoEvents()
                ' Собственно получения порции данных
                Dim bts() As Byte = myStreamReader.ReadBytes(buf)
                If bts.Length = 0 Then Exit Do
                all.AddRange(bts)
            Loop
            myStreamReader.Close()
            Dim i As Integer
            Dim btsAll() As Byte = all.ToArray
            For i = 0 To btsAll.Length - 1
                If btsAll(i) = 0 Then btsAll(i) = 48
            Next
            Return GetEncodText(args(1)).GetString(btsAll)
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
            Return ""
        End Try
    End Function
    Sub AppendText(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            Dim fl As System.IO.File
            fl.AppendAllText(UbratKovich(args(0)).str, args(1), GetEncodText(args(2)))
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Sub SavePicture(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            args(1) = GetMaxPath(UbratKovich(args(1)).str)
            IO.File.Copy(args(1), args(0), True)
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Sub Copy(ByVal ParamArray args() As String)
        Try
            Dim fso = CreateObject("Scripting.FileSystemObject") 'Dim fso As new FileSystemObject 
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            args(1) = GetMaxPath(UbratKovich(args(1)).str)
            If IO.File.Exists(args(0)) Then
                fso.copyfile(args(0), args(1), True)
            Else
                fso.copyfolder(GetPathBezSlash(args(0)), args(1), True)
            End If
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Sub Rename(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            Dim pth As String = IO.Path.GetDirectoryName(args(0))
            Microsoft.VisualBasic.FileSystem.Rename(args(0), pth & "\" & args(1))
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Sub Move(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            args(1) = GetMaxPath(UbratKovich(args(1)).str)
            If IO.File.Exists(args(0)) Then
                If IO.File.Exists(args(1)) Then IO.File.Delete(args(1))
                IO.File.Move(args(0), args(1))
            Else
                IO.Directory.Move(args(0), args(1))
            End If
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message) & " " & trans("Советуем воспользоваться более надежным методом, таким как ""_Копировать"""))
        End Try
    End Sub
    Sub OpenDirectory(ByVal ParamArray args() As String)
        Run("explorer.exe", IO.Path.GetDirectoryName(args(0)) & "," & IO.Path.GetFileName(args(0)))
    End Sub
    Overloads Sub Encrypt(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            System.IO.File.Encrypt(args(0))
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Overloads Sub Decrypt(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            System.IO.File.Decrypt(args(0))
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Overloads Sub Delete(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            Dim fso = CreateObject("Scripting.FileSystemObject") 'Dim fso As new FileSystemObject 
            If IO.File.Exists(args(0)) Then
                fso.deletefile(args(0))
            Else
                fso.deletefolder(args(0))
            End If
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Overloads Sub CreateDirectory(ByVal ParamArray args() As String)
        Try
            System.IO.Directory.CreateDirectory(GetMaxPath(UbratKovich(args(0)).str))
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Public errFind, top As String
    Overloads Function FindFile(ByVal ParamArray args() As String) As String
        Try
            args(0) = GetMaxPath(UbratKovich(args(0)).str)
            Dim dir As New IO.DirectoryInfo(args(0))
            Dim fls() As IO.FileSystemInfo = dir.GetFileSystemInfos(args(1))
            Dim drs() As IO.DirectoryInfo = dir.GetDirectories(args(1))
            Dim child_dirs() As IO.DirectoryInfo = dir.GetDirectories()
            If top = "" Then top = args(0)
            Dim i As Integer, str As String = ""
            For i = 0 To fls.Length - 1
                str &= fls(i).FullName & "; "
            Next
            For i = 0 To drs.Length - 1
                str &= drs(i).FullName & "; "
            Next
            For i = 0 To child_dirs.Length - 1
                Application.DoEvents()
                str &= FindFile(New String() {child_dirs(i).FullName, args(1)})
            Next
            ' если это корень рекурсии
            If top = args(0) Then
                Dim errTmp As String = errFind
                top = "" : errFind = ""
                If errTmp <> "" Then MessangeCritic(Errors.FileNotCreate(errTmp))
            End If
            Return str
        Catch ex As Exception
            If IgnorEr = False Then errFind &= ex.Message & vbCrLf
        End Try
        ' если это корень рекурсии
        If top = args(0) Then
            Dim errTmp As String = errFind
            top = "" : errFind = ""
            If errTmp <> "" Then MessangeCritic(Errors.FileNotCreate(errTmp))
        End If
    End Function
    Overloads Property FilesCount(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return System.IO.Directory.GetFiles(path).Length
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property DirectoriesCount(ByVal ParamArray args() As String)
        Get
            Dim path As String = UbratKovich(GetMaxPath(args(0))).str
            Return System.IO.Directory.GetDirectories(path).Length
        End Get
        Set(ByVal value)
        End Set
    End Property
 
    ' EKRAN
    Overloads Property WallPaper() As String
        Get
            Dim path As New StringBuilder(256)
            SystemParametersInfo(SystemParameters.SPI_GETDESKWALLPAPER, path.Capacity, path, 0)
            If isDevelop And isRUN() = False Then Return """" & path.ToString & """"
            Return path.ToString
        End Get
        Set(ByVal value As String)
            value = GetMaxPath(value)
            Dim path As New StringBuilder(value, 256)
            If NikakoiEsli(value) <> trans("Никакой") Then
                Try
                    SystemParametersInfo(SystemParameters.SPI_SETDESKWALLPAPER, 0, path, SystemParameters.SPIF_UPDATEINIFILE Or SystemParameters.SPIF_SENDWININICHANGE)
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
                End Try
            Else
                SystemParametersInfo(SystemParameters.SPI_SETDESKWALLPAPER, 0, New StringBuilder(256), SystemParameters.SPIF_UPDATEINIFILE Or SystemParameters.SPIF_SENDWININICHANGE)
            End If
        End Set
    End Property
    Overloads Property DesktopStyle() As String
        Get
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", True)
            Dim vals As String = key.GetValue("WallpaperStyle") & "," & key.GetValue("TileWallpaper")
            Dim ind As Integer = DeskStyle.IndexOfValue(vals)
            If ind <> -1 Then Return DeskStyle.GetKey(ind) Else Return trans("Никакой")
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then Exit Property
            Dim path As New StringBuilder(UbratKovich(WallPaper).str, 256)
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", True)
            Dim vals() As String = DeskStyle.GetByIndex(DeskStyle.IndexOfKey(LCase(value))).Split(",")
            If vals.Length < 2 Then Exit Property
            Try
                key.SetValue("WallpaperStyle", vals(0))
                key.SetValue("TileWallpaper", vals(1))
                SystemParametersInfo(SystemParameters.SPI_SETDESKWALLPAPER, 0, path, SystemParameters.SPIF_UPDATEINIFILE Or SystemParameters.SPIF_SENDWININICHANGE)
            Catch ex As Exception
            End Try
        End Set
    End Property
    Function getErrString(ByVal iRet As Integer, ByVal val As String) As String
        Dim errorMessage As String = ""
        Select Case iRet
            Case ReturnCodes.DISP_CHANGE_SUCCESSFUL
            Case ReturnCodes.DISP_CHANGE_RESTART
                errorMessage = "Please restart your system"
            Case ReturnCodes.DISP_CHANGE_FAILED
                errorMessage = "ChangeDisplaySettigns API failed"
            Case ReturnCodes.DISP_CHANGE_BADDUALVIEW
                errorMessage = "The settings change was unsuccessful because system is DualView capable."
            Case ReturnCodes.DISP_CHANGE_BADFLAGS
                errorMessage = "An invalid set of flags was passed in."
            Case ReturnCodes.DISP_CHANGE_BADPARAM
                errorMessage = "An invalid parameter was passed in. This can include an invalid flag or combination of flags."
            Case ReturnCodes.DISP_CHANGE_NOTUPDATED
                errorMessage = "Unable to write settings to the registry."
            Case ReturnCodes.DISP_CHANGE_BADMODE
                errorMessage = "Invalid value the display setting. Value """ & val & """ is not admissible."
            Case Else
                errorMessage = "Unknown return value from ChangeDisplaySettings API"
        End Select
        Return errorMessage
    End Function
    Overloads Property DesktopResolution() As String
        Get
            Dim devmode As DevMode
            EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, devmode)
            Return devmode.dmPelsWidth & "x" & devmode.dmPelsHeight
        End Get
        Set(ByVal value As String)
            Dim devmode As DevMode, errorMessage As String = ""
            EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, devmode)
            devmode.dmPelsWidth = value.Split("x")(0)
            devmode.dmPelsHeight = value.Split("x")(1)
            errorMessage = getErrString(ChangeDisplaySettings(devmode, 0), value)
            If errorMessage <> "" Then Errors.MessangeCritic(errorMessage) : Exit Property
        End Set
    End Property
    Overloads Property DesktopBits() As String
        Get
            Dim devmode As DevMode
            EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, devmode)
            Return devmode.dmBitsPerPel
        End Get
        Set(ByVal value As String)
            Dim devmode As DevMode, errorMessage As String = ""
            EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, devmode)
            devmode.dmBitsPerPel = value
            errorMessage = getErrString(ChangeDisplaySettings(devmode, 0), value)
            If errorMessage <> "" Then Errors.MessangeCritic(errorMessage) : Exit Property
        End Set
    End Property
    Overloads Property DesktopFrequency() As String
        Get
            Dim devmode As DevMode
            EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, devmode)
            Return devmode.dmDisplayFrequency
        End Get
        Set(ByVal value As String)
            Dim devmode As DevMode, errorMessage As String = ""
            EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, devmode)
            devmode.dmDisplayFrequency = value
            errorMessage = getErrString(ChangeDisplaySettings(devmode, 0), value)
            If errorMessage <> "" Then Errors.MessangeCritic(errorMessage) : Exit Property
        End Set
    End Property
    Overloads Property ScreenSaver() As String
        Get
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", True)
            If isDevelop And isRUN() = False Then Return """" & key.GetValue("SCRNSAVE.EXE") & """"
            Return key.GetValue("SCRNSAVE.EXE")
        End Get
        Set(ByVal value As String)
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", True)
            key.SetValue("SCRNSAVE.EXE", value)
        End Set
    End Property
    Overloads Property Screenshot(ByVal ParamArray args() As String) As String
        Get
            Application.DoEvents()
            ' Если скриншот всего а не только активного окна
            If NetTakNet(args(0)) = trans("Нет") Then
                DoKeyBoard(0, Keys.PrintScreen)
                DoKeyBoard(NativeMethods.KEYEVENTF.KEYUP, Keys.PrintScreen)
                ' SendKeys.SendWait("+{PRTSC}")
            Else ' скрин активного окна
                DoKeyBoard(0, Keys.Menu)
                DoKeyBoard(0, Keys.PrintScreen)
                DoKeyBoard(NativeMethods.KEYEVENTF.KEYUP, Keys.PrintScreen)
                DoKeyBoard(NativeMethods.KEYEVENTF.KEYUP, Keys.Menu)
                '  SendKeys.SendWait("{PRTSC}")
            End If
            ' return the bitmap now in the clipboard
11:         args(0) = IO.Path.GetTempFileName.Replace(".tmp", ".jpg")
            Application.DoEvents()
            If Clipboard.GetDataObject().GetData(DataFormats.Bitmap) Is Nothing Then GoTo 11
            Try
                DirectCast(Clipboard.GetDataObject().GetData(DataFormats.Bitmap), Image).Save(args(0))
            Catch ex As Exception
                If IgnorEr = False Then MessangeCritic(ex.Message)
                Return ""
            End Try
            '  Clipboard.SetData(DataFormats.Text, clb)
            Return args(0)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Sub ScreenshotToClipboard(ByVal ParamArray args() As String)
        ' Если скриншот всего а не только активного окна
        If NetTakNet(args(0)) = trans("Нет") Then
            SendKeys.SendWait("+{PRTSC}")
        Else ' скрин активного окна
            SendKeys.SendWait("%{PRTSC 2}")
            SendKeys.SendWait("%{PRTSC 2}")
            SendKeys.SendWait("%{PRTSC 2}")
            SendKeys.SendWait("%{PRTSC 5}")
        End If
    End Sub
    Overloads Property ScreenshotOfObject(ByVal ParamArray args() As String) As String
        Get
            '            Application.DoEvents()
            '            ' Если скриншот всего а не только активного окна
            '            DoKeyBoard(0, Keys.PrintScreen)
            '            DoKeyBoard(NativeMethods.KEYEVENTF.KEYUP, Keys.PrintScreen)
            '            ' Получаем рисунок в bmp
            '11:         Application.DoEvents()
            '            If Clipboard.GetDataObject().GetData(DataFormats.Bitmap) Is Nothing Then GoTo 11
            '            Try
            '                bmp = DirectCast(Clipboard.GetDataObject().GetData(DataFormats.Bitmap), Image)
            '            Catch ex As Exception
            '                If IgnorEr = False Then MessangeCritic(ex.Message)
            '                Return ""
            '            End Try
            ' Определяем кого фотать
            Dim ScObj As Object = RunProj.GetMyObjFromUniqName(args(0))
            If ScObj Is Nothing Then
                If IgnorEr = False Then MessangeCritic(trans("Невозможно сфотографировать объект *, так как такого объекта не существует!").Replace("*", args(0)))
                Return ""
            End If
            ' Создаем битмап максимально правильного размера
            Dim widt As Integer = DesktopResolution.Split("x")(0)
            Dim heig As Integer = DesktopResolution.Split("x")(1)
            If widt < ScObj(0).obj.Width Then widt = ScObj(0).obj.Width
            If heig < ScObj(0).obj.Height Then heig = ScObj(0).obj.Height
            Dim bmp As New Bitmap(widt, heig)
            ' Теперь вырезаем рисунок
            ' Dim loc As Point = ScObj(0).obj.PointToScreen(New Point(0, 0))
            ScObj(0).obj.DrawToBitmap(bmp, New Rectangle(New Point(0, 0), ScObj(0).obj.Size))
            Dim loc As Point = New Point(0, 0)
            'If Iz.IsFORM(ScObj(0)) Then
            '    loc = ScObj(0).obj.DesktopLocation
            'End If
            bmp = bmp.Clone(New Rectangle(loc, ScObj(0).obj.Size), Imaging.PixelFormat.Undefined)
            'Сохраняем получившийся рисунок и возвращаем путь к нему
            args(0) = IO.Path.GetTempFileName.Replace(".tmp", ".jpg")
            bmp.Save(args(0))
            Return args(0)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    'Sub ScreenshotOfObjectToClipboard(ByVal ParamArray args() As String)
    '    ' Если скриншот всего а не только активного окна
    '    If NetTakNet(args(0)) = trans("Нет") Then
    '        SendKeys.SendWait("+{PRTSC}")
    '    Else ' скрин активного окна
    '        SendKeys.SendWait("%{PRTSC 2}")
    '        SendKeys.SendWait("%{PRTSC 2}")
    '        SendKeys.SendWait("%{PRTSC 2}")
    '        SendKeys.SendWait("%{PRTSC 5}")
    '    End If
    'End Sub

    'Сделать скриншот~~ScreenshotToClipboard
    'Скриншот~~Screenshot
    'Скриншот объекта~~ScreenshotOfObject
    'Сделать скриншот объекта~~ScreenshotOfObjectToClipboard
    'Объект на печать~~PrintObject

    ' COMMAND
    Function BreakApplication() As ErrString
        Return New ErrString("", "BreakApplication")
    End Function
    Function BreakEvent() As ErrString
        Return New ErrString("", "BreakEvent")
    End Function
    Function BreakLoop() As ErrString
        Return New ErrString("", "BreakLoop")
    End Function
    Function IgnoreErrors() As ErrString
        IgnorEr = True
        Return New ErrString("", "IgnoreErrors")
    End Function

    ' SYSTEM
    Overloads Property MouseX() As String
        Get
            Return Cursor.Position.X
        End Get
        Set(ByVal value As String)
            Cursor.Position = New Point(value, Cursor.Position.Y)
        End Set
    End Property
    Overloads Property MouseY() As String
        Get
            Return Cursor.Position.Y
        End Get
        Set(ByVal value As String)
            Cursor.Position = New Point(Cursor.Position.X, value)
        End Set
    End Property
    Overloads Property MouseLeft() As String
        Get
            HookRun(mouseHook)

            Return DaOrNet(peremens.mleft)
        End Get
        Set(ByVal value As String)
            If value = trans("Да") Then
                DoMouse(NativeMethods.MOUSEEVENTF.LEFTDOWN, Windows.Forms.Cursor.Position)
            Else
                DoMouse(NativeMethods.MOUSEEVENTF.LEFTUP, Windows.Forms.Cursor.Position)
            End If
        End Set
    End Property
    Overloads Property MouseRight() As String
        Get
            HookRun(mouseHook)

            Return DaOrNet(peremens.mright)
        End Get
        Set(ByVal value As String)
            If value = trans("Да") Then
                DoMouse(NativeMethods.MOUSEEVENTF.RIGHTDOWN, Windows.Forms.Cursor.Position)
            Else
                DoMouse(NativeMethods.MOUSEEVENTF.RIGHTUP, Windows.Forms.Cursor.Position)
            End If
        End Set
    End Property
    Overloads ReadOnly Property MouseWheel() As String
        Get
            HookRun(mouseHook)

            Return DaOrNet(peremens.mwheel)
        End Get
    End Property
    Overloads Property KeyboardKey() As String
        Get
            If RunProj Is Nothing Then Return """Menu; Tab;"""
            If RunProj.isRUN = False Then Return """Menu; Tab;"""

            HookRun(keyboardHook)

            Dim i As Integer, str As String = ""
            For i = 0 To ks.Count - 1
                str &= ks(i)
                If ks.Count > 1 Then str &= "; "
            Next
            Return str
        End Get
        Set(ByVal value As String)
            '  Dim tm As New Timer()
            '  tm.Interval = 1 : tm.Tag = value
            '  AddHandler tm.Tick, AddressOf tm_tick
            '  tm.Start()
            Dim i As Integer
            Dim mass() As String = value.Split(";")
            Application.DoEvents()
            For i = 0 To mass.Length - 1
                If Trim(mass(i)) = "" Then Continue For
                DoKeyBoard(0, Keyz(Trim(LCase(mass(i)))))
            Next
            Application.DoEvents()
            For i = 0 To mass.Length - 1
                If Trim(mass(i)) = "" Then Continue For
                DoKeyBoard(NativeMethods.KEYEVENTF.KEYUP, Keyz(Trim(LCase(mass(i)))))
            Next
        End Set
    End Property
    '  Sub tm_tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '      sender.stop() : SendKeys.SendWait(sender.tag)
    '  End Sub
    Overloads Property KeyboardShift() As String
        Get
            HookRun(keyboardHook)

            Return DaOrNet(peremens.shft)
        End Get
        Set(ByVal value As String)
            If value = trans("Да") Then
                DoKeyBoard(0, Keys.ShiftKey)
            Else
                DoKeyBoard(NativeMethods.KEYEVENTF.KEYUP, Keys.ShiftKey)
            End If
        End Set
    End Property
    Overloads Property KeyboardAlt() As String
        Get
            HookRun(keyboardHook)

            Return DaOrNet(peremens.alt)
        End Get
        Set(ByVal value As String)
            If value = trans("Да") Then
                DoKeyBoard(0, Keys.Menu)
            Else
                DoKeyBoard(NativeMethods.KEYEVENTF.KEYUP, Keys.Menu)
            End If
        End Set
    End Property
    Overloads Property KeyboardControl() As String
        Get
            HookRun(keyboardHook)

            Return DaOrNet(peremens.ctrl)
        End Get
        Set(ByVal value As String)
            If value = trans("Да") Then
                DoKeyBoard(0, Keys.ControlKey)
            Else
                DoKeyBoard(NativeMethods.KEYEVENTF.KEYUP, Keys.ControlKey)
            End If
        End Set
    End Property
    Overloads Property ClipboardPicture() As String
        Get
            Dim pth As String
            If Clipboard.ContainsImage = False Then Return ""
            ' return the bitmap now in the clipboard
            Try
                pth = IO.Path.GetTempFileName.Replace(".tmp", ".jpg")
                DirectCast(Clipboard.GetDataObject().GetData(DataFormats.Bitmap), Image).Save(pth)
            Catch ex As Exception
                If IgnorEr = False Then MessangeCritic(ex.Message)
                Return ""
            End Try
            Return pth
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) <> trans("Никакой") Then
                Try
                    Clipboard.SetImage(Image.FromFile(GetMaxPath(value)))
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
                End Try
            Else
                Clipboard.Clear()
            End If
        End Set
    End Property
    Overloads Property ClipboardText() As String
        Get
            Try
                If Clipboard.ContainsFileDropList Then
                    Dim i As Integer, str As String = ""
                    For i = 0 To Clipboard.GetFileDropList.Count - 1
                        str &= Clipboard.GetFileDropList.Item(i)
                        If Clipboard.GetFileDropList.Count > 1 Then str &= "; "
                    Next
                    Return str
                End If
                If Clipboard.ContainsText Then Return Clipboard.GetText(TextDataFormat.UnicodeText)
                Return ""
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(ex.Message)
            End Try
        End Get
        Set(ByVal value As String)
            Try
                Clipboard.SetText(value, TextDataFormat.UnicodeText)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(ex.Message)
            End Try
        End Set
    End Property
    Sub Run(ByVal ParamArray args() As String)
        Try
            Diagnostics.Process.Start(args(0), args(1))
        Catch ex As Exception
            If IgnorEr = False Then Errors.MessangeExclamen(ex.Message & ". " & trans("Выполнялось") & ": """ & args(0) & """ """ & args(1) & """")
        End Try
    End Sub
    Function RunWithResult(ByVal ParamArray args() As String)
        Try
            Dim i As Integer : Dim ret As String = ""
            Dim strs() As String = args(0).Split(New String() {vbCrLf}, StringSplitOptions.None)

            Dim proc As New Diagnostics.Process
            proc.StartInfo.UseShellExecute = False
            proc.StartInfo.CreateNoWindow = True
            proc.StartInfo.RedirectStandardOutput = True
            proc.StartInfo.RedirectStandardInput = True
            proc.StartInfo.RedirectStandardError = True
            proc.StartInfo.FileName = strs(0)
            proc.StartInfo.Arguments = args(1)
            proc.Start()
            ' Пишем в процесс команды, если больше чем одна строка в args(0).
            Dim stremW As New IO.StreamWriter(proc.StandardInput.BaseStream, GetEncodText(args(2)))
            For i = 1 To strs.Length - 1
                stremW.WriteLine(strs(i))
            Next
            stremW.Close()
            proc.WaitForExit(100)
            ' Получаем результат
            Dim stremR As New IO.StreamReader(proc.StandardOutput.BaseStream, GetEncodText(args(2)))
            ret &= stremR.ReadToEnd
            stremR.Close()
            ' Получаем все ошибки 
            Dim stremRE As New IO.StreamReader(proc.StandardError.BaseStream, GetEncodText(args(2)))
            ret &= stremRE.ReadToEnd
            stremRE.Close()

            proc.Close()
            Return ret
        Catch ex As Exception
            If IgnorEr = False Then Errors.MessangeExclamen(ex.Message & ". " & trans("Выполнялось") & ": """ & args(0) & """ """ & args(1) & """")
        End Try
    End Function
    Function GetEncodText(ByVal enc As String) As Encoding
        Dim ind = FileEncodings.IndexOfKey(LCase(enc))
        If ind = -1 Then
            Try
                If IsNumeric(enc) Then
                    Return System.Text.Encoding.GetEncoding(Int(enc))
                Else
                    Return System.Text.Encoding.GetEncoding(enc)
                End If
            Catch ex As Exception
                Throw New Exception(trans("Кодировка * не поддерживается").Replace("*", enc))
            End Try
        Else
            Return FileEncodings.GetByIndex(ind)
        End If
    End Function
    Sub ClipboardClear()
        Try
            Clipboard.Clear()
        Catch ex As Exception
            If IgnorEr = False Then MsgBox(ex.Message)
        End Try
    End Sub
    Sub WheelRun(ByVal ParamArray args() As String)
        DoMouse(NativeMethods.MOUSEEVENTF.WHEEL, Windows.Forms.Cursor.Position, args(0))
    End Sub
    Sub ShutDown()
        Try
            Diagnostics.Process.Start("shutdown", "-s -t 00 -f")
        Catch ex As Exception
            If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
        End Try
    End Sub
    Sub Restart()
        Try
            Diagnostics.Process.Start("shutdown", "-r -t 00 -f")
        Catch ex As Exception
            If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
        End Try
    End Sub
    Sub TypeText(ByVal ParamArray args() As String)
        SendKeys.SendWait(args(0))
    End Sub
    Function ProcessesList() As String
        Dim i As Integer, ret As String = ""
        Dim procs() As Diagnostics.Process = Diagnostics.Process.GetProcesses
        For i = 0 To procs.Length - 1
            ret &= procs(i).ProcessName
            If i < procs.Length - 1 Then ret &= ","
        Next
        Return ret
    End Function
    Sub KillProcess(ByVal ParamArray args() As String)
        Dim i As Integer, ret As String = ""
        Dim procs() As Diagnostics.Process = Diagnostics.Process.GetProcesses
        For i = 0 To procs.Length - 1
            If procs(i).ProcessName.ToUpper = args(0).ToUpper Then
                procs(i).Kill()
            ElseIf procs(i).MainWindowTitle = args(0) Then
                procs(i).Kill()
            ElseIf procs(i).MainWindowHandle.ToString = args(0) Then
                procs(i).Kill()
            End If
        Next
        'Dim i As Integer
        'Dim prcs() As Diagnostics.Process = Diagnostics.Process.GetProcessesByName(args(0))
        'For i = 0 To prcs.Length - 1
        '    prcs(i).Kill()
        'Next
    End Sub
    Function WindowsList() As String
        Dim i As Integer, ret As String = ""
        Dim procs() As Diagnostics.Process = Diagnostics.Process.GetProcesses
        For i = 0 To procs.Length - 1
            If procs(i).MainWindowHandle <> 0 Then
                If procs(i).MainWindowTitle <> "" Then
                    ret &= procs(i).MainWindowTitle
                Else
                    ret &= procs(i).MainWindowHandle.ToString
                End If
                If i < procs.Length - 1 Then ret &= ","
            End If
        Next
        If ret.LastIndexOf(",") = ret.Length - 1 And ret.Length > 0 Then ret = ret.Substring(0, ret.Length - 1)
        Return ret
    End Function
    Property WindowInFocus() As String
        Get
            Dim i As Integer
            Dim hndl As IntPtr = GetForegroundWindow()
            Dim procs() As Diagnostics.Process = Diagnostics.Process.GetProcesses
            For i = 0 To procs.Length - 1
                If procs(i).MainWindowHandle = hndl Then
                    If procs(i).MainWindowTitle <> "" Then
                        Return procs(i).MainWindowTitle
                    Else
                        Return procs(i).MainWindowHandle
                    End If
                End If
            Next
            Return ""
        End Get
        Set(ByVal value As String)
            Dim i As Integer, ret As String = ""
            Dim procs() As Diagnostics.Process = Diagnostics.Process.GetProcesses
            For i = 0 To procs.Length - 1
                If procs(i).MainWindowHandle <> 0 Then
                    If procs(i).MainWindowTitle.ToUpper = value.ToUpper Or procs(i).MainWindowHandle.ToString = value Then
                        SetForegroundWindow(procs(i).MainWindowHandle)
                    End If
                End If
            Next
        End Set
    End Property


    ' REGISTRY
    Overloads Property Key(ByVal ParamArray args() As String) As String
        Get
            Dim nam As String = ""
            Dim k As RegistryKey = GetRegistryKey(args(0), nam)

            If ExistKey(args) = trans("Нет") And nam <> "" Then
                MsgBox(Errors.notRegistry(args(0))) : Return trans("")
            End If
            If k.GetValueKind(nam) = RegistryValueKind.Binary Then
                Dim byt() As Byte = k.GetValue(nam)
                If byt.Length = 0 Then Return trans("Никакой")

                ' построение битовой строки
                Dim i As Integer
                Dim str As String = ""
                For i = 0 To byt.Length - 1
                    str &= byt(i) & " "
                Next

                Return Trim(str)
            Else
                Return k.GetValue(nam, "")
            End If
        End Get
        Set(ByVal value As String)
            Dim nam As String = ""
            Dim k As RegistryKey = GetRegistryKey(args(0), nam)

            ' получение типа ключа
            Dim kind As Microsoft.Win32.RegistryValueKind = RegistryValueKind.String
            If ExistKey(args) = trans("Нет") Then
                If nam <> "" Then MsgBox(Errors.notRegistry(args(0))) : Exit Property
            Else
                kind = k.GetValueKind(nam)
            End If

            CreateRegistryKey(k, nam, value, kind)
        End Set
    End Property
    Overloads Property TypeKey(ByVal ParamArray args() As String) As String
        Get
            Dim nam As String = ""
            Dim k As RegistryKey = GetRegistryKey(args(0), nam)
            If ExistKey(args) = trans("Нет") And nam <> "" Then
                MsgBox(Errors.notRegistry(args(0))) : Return trans("никакой")
            End If

            Return TypeRegistry.GetKey(TypeRegistry.IndexOfValue(k.GetValueKind(nam)))
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property ExistKey(ByVal ParamArray args() As String) As String
        Get
            Dim nam As String = ""
            Dim k As RegistryKey = GetRegistryKey(args(0), nam)
            If nam = "" Then Return trans("Нет")
            Try
                ' эта функция вызывает ошибку, если ключа нет
                k.GetValueKind(nam)

                Return trans("Да")
            Catch ex As Exception
                Return trans("Нет")
            End Try
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property ExistSubKey(ByVal ParamArray args() As String) As String
        Get
            Dim nam As String = ""
            Dim k As RegistryKey = GetRegistryKey(args(0), nam)
            If k Is Nothing Then Return trans("Нет")

            If nam = "" Then Return trans("Да") Else Return trans("Нет")
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Sub DeleteKey(ByVal ParamArray args() As String)
        Dim nam As String = ""
        Dim k As RegistryKey = GetRegistryKey(args(0), nam)
        If ExistKey(args) = trans("Нет") Then MsgBox(Errors.notRegistry(args(0))) : Exit Sub
        k.DeleteValue(nam)
    End Sub
    Sub DeleteSubKey(ByVal ParamArray args() As String)
        Dim nam As String = ""
        Dim k As RegistryKey = GetRegistryKey(args(0), nam)
        If k Is Nothing Then Exit Sub
        If ExistSubKey(args) = trans("Нет") Then MsgBox(Errors.notRegistry(args(0))) : Exit Sub
        k.DeleteSubKeyTree(nam)
    End Sub
    Sub CreateKey(ByVal ParamArray args() As String)
        Dim nam As String = ""
        Dim k As RegistryKey = GetRegistryKey(args(0), nam)
        If IsNumeric(args(2)) Then CreateRegistryKey(k, nam, args(1), args(2)) : Exit Sub ' Если я использую эту функцию, напр. для ассоциации с .alg

        CreateRegistryKey(k, nam, args(1), TypeRegistry.GetByIndex(TypeRegistry.IndexOfKey(LCase(args(2)))))
    End Sub
    Sub CreateSubKey(ByVal ParamArray args() As String)
        Dim nam As String = ""
        Dim k As RegistryKey = GetRegistryKey(args(0), nam)
        If k Is Nothing Then Exit Sub

        k.CreateSubKey(nam)
    End Sub

    ' TEXTS
    Sub UladitVbCrlf(ByRef txt As String, ByRef str As String)
        If txt Is Nothing Then Exit Sub
        If txt.IndexOf(vbCrLf) = -1 Then
            If txt.IndexOf(vbCrLf.Substring(1)) <> -1 Then
                str = str.Replace(vbCrLf, vbCrLf.Substring(1))
            End If
        End If
    End Sub
    Overloads ReadOnly Property Chars(ByVal ParamArray args() As String) As String
        Get
            If args(0).Length <= args(1) - 1 Then Return "" Else Return args(0).Chars(args(1) - 1)
        End Get
    End Property
    Overloads ReadOnly Property Compare(ByVal ParamArray args() As String) As String
        Get
            Return String.Compare(args(0), args(1))
        End Get
    End Property
    Overloads ReadOnly Property IndexOfLine(ByVal ParamArray args() As String) As String
        Get
            Dim ret As Integer = 0, vbcr As String = vbCrLf
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Dim ind As Integer = args(0).IndexOf(args(1), Int(args(2)) - 1, StringComparison.CurrentCultureIgnoreCase)
            UladitVbCrlf(args(0), vbcr)
            While ind <> -1
                If ind > 0 Then ind -= 1
                ind = args(0).LastIndexOf(vbcr, ind, StringComparison.CurrentCultureIgnoreCase)
                ret += 1
            End While
            Return ret
        End Get
    End Property
    Overloads ReadOnly Property IndexOfIgnoreCase(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Return args(0).IndexOf(args(1), Int(args(2)) - 1, StringComparison.CurrentCultureIgnoreCase) + 1
        End Get
    End Property
    Overloads ReadOnly Property IndexOf(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Return args(0).IndexOf(args(1), Int(args(2)) - 1) + 1
        End Get
    End Property
    Overloads ReadOnly Property LastIndexOfIgnoreCase(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            If args(2) > args(0).Length + 1 Then args(2) = args(0).Length
            Return args(0).LastIndexOf(args(1), Int(args(2)) - 1, StringComparison.CurrentCultureIgnoreCase) + 1
        End Get
    End Property
    Overloads ReadOnly Property IndexOfRegular(ByVal ParamArray args() As String) As String
        Get
            Dim re As RegularExpressions.Match
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            re = RegularExpressions.Regex.Match(args(0), args(1))
            If re.Success Then Return re.Index + 1 Else Return 0
        End Get
    End Property
    Overloads ReadOnly Property CharsLength(ByVal ParamArray args() As String) As String
        Get
            Return args(0).Length
        End Get
    End Property
    Overloads ReadOnly Property Split(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Dim sss() As String = {args(1)}
            Dim sts() As String = args(0).Split(sss, StringSplitOptions.None)
            If args(2) - 1 >= sts.Length Then Return "" Else Return sts(args(2) - 1)
        End Get
    End Property
    Overloads ReadOnly Property Substring(ByVal ParamArray args() As String) As String
        Get
            args(1) = args(1) - 1
            If Int(args(2)) + args(1) > args(0).Length Then args(2) = args(0).Length - args(1)
            If args(2) > -1 Then
                Return args(0).Substring(args(1), args(2))
            Else
                Return args(0).Substring(args(1))
            End If
        End Get
    End Property
    Overloads ReadOnly Property SplitCount(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Return args(0).Split(args(1)).Length
        End Get
    End Property
    Overloads ReadOnly Property DeleteQuotes(ByVal ParamArray args() As String) As String
        Get
            Dim ret As String = UbratKovich(args(0)).str
            If ret = args(0) And ret.Length > 1 Then
                If (ret.Chars(0) = """" And ret.Chars(ret.Length - 1) = """") Then
                    ret = ret.Substring(1, ret.Length - 2)
                End If
            End If
            Return ret
        End Get
    End Property
    Overloads ReadOnly Property PutInQuotes(ByVal ParamArray args() As String) As String
        Get
            Return """" & CreateKovich(CreateKovich(args(0))) & """"
        End Get
    End Property
    Overloads ReadOnly Property IndexOfWithoutQuotes(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Dim cs As New CodeString(args(0), "None", False)
            Return cs.IndexOf(args(1), args(2) - 1) + 1
        End Get
    End Property
    Overloads ReadOnly Property SplitWithoutQuotes(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Dim cs As New CodeString(args(0), "None", False)
            Dim sts() As String = cs.Split("", args(1)).texty
            If args(2) - 1 >= sts.Length Then Return "" Else Return sts(args(2) - 1)
        End Get
    End Property
    Overloads ReadOnly Property SplitWithoutQuotesCount(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Dim cs As New CodeString(args(0), "None", False)
            Dim sts() As String = cs.Split("", args(1)).texty
            Return sts.Length
        End Get
    End Property
    Overloads ReadOnly Property Consist(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Return args(0).IndexOfAny(args(1).ToCharArray) + 1
        End Get
    End Property
    Overloads ReadOnly Property ConsistNo(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Return DaOrNet(args(0).IndexOfAny(args(1).ToCharArray) = -1)
        End Get
    End Property
    Overloads ReadOnly Property IsNumericText(ByVal ParamArray args() As String) As String
        Get
            Return ConsistAll(New String() {args(0), "1234567890"})
        End Get
    End Property
    Overloads ReadOnly Property isNumberText(ByVal ParamArray args() As String) As String
        Get
            Return DaOrNet(isDouble(args(0)))
        End Get
    End Property
    Overloads ReadOnly Property ConsistAll(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            args(1) = args(1).Replace("^", "\^").Replace("[", "\[").Replace("]", "\]")
            Return DaOrNet(RegularExpressions.Regex.Match(args(0), "[" & args(1) & "]*").Value = args(0))
        End Get
    End Property
    Overloads ReadOnly Property Line(ByVal ParamArray args() As String) As String
        Get
            Dim tb As New TextBox() : tb.Text = args(0)
            If tb.Lines.Length <= args(1) - 1 Then Return "" Else Return tb.Lines(args(1) - 1)
        End Get
    End Property
    Overloads ReadOnly Property LinesCount(ByVal ParamArray args() As String) As String
        Get
            Dim tb As New TextBox() : tb.Text = args(0)
            Return tb.Lines.Length
        End Get
    End Property
    Overloads ReadOnly Property Insert(ByVal ParamArray args() As String) As String
        Get
            Return args(0).Insert(args(1) - 1, args(2))
        End Get
    End Property
    Overloads ReadOnly Property Remove(ByVal ParamArray args() As String) As String
        Get
            args(1) = args(1) - 1
            If Int(args(2)) + args(1) > args(0).Length Then args(2) = args(0).Length - args(1)
            If args(2) <> -1 Then
                Return args(0).Remove(args(1), args(2))
            Else
                Return args(0).Remove(args(1))
            End If
        End Get
    End Property
    Overloads ReadOnly Property ReplaceOne(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Dim ind As Integer = args(0).IndexOf(args(1), StringComparison.CurrentCultureIgnoreCase)
            If ind = -1 Then Return args(0)
            args(0) = args(0).Remove(ind, args(1).Length)
            Return args(0).Insert(ind, args(2))
        End Get
    End Property
    Overloads ReadOnly Property ReplaceAll(ByVal ParamArray args() As String) As String
        Get
            If args(0) Is Nothing Then Return 0
            UladitVbCrlf(args(0), args(1))
            Return args(0).Replace(args(1), args(2))
        End Get
    End Property
    Overloads ReadOnly Property toUpper(ByVal ParamArray args() As String) As String
        Get
            Return UCase(args(0))
        End Get
    End Property
    Overloads ReadOnly Property toLower(ByVal ParamArray args() As String) As String
        Get
            Return LCase(args(0))
        End Get
    End Property
    Overloads ReadOnly Property TrimAll(ByVal ParamArray args() As String) As String
        Get
            Return args(0).Trim()
        End Get
    End Property
    Overloads ReadOnly Property TrimStart(ByVal ParamArray args() As String) As String
        Get
            Return args(0).TrimStart()
        End Get
    End Property
    Overloads ReadOnly Property TrimEnd(ByVal ParamArray args() As String) As String
        Get
            Return args(0).TrimEnd()
        End Get
    End Property

    Dim IV As Byte() = {16, 2, 3, 41, 5, 6, 7, 81, 9, 10, 11, 12, 13, 14, 15, 16} 'Вектор инициализации
    Overloads ReadOnly Property EncryptText(ByVal ParamArray args() As String)
        Get
            ' Формируем КЛЮЧ. Это должен быть массив bytes() c длинной либо 16 (128 бит), либо 32 (256 бит)
            Dim Key() As Byte = getKeySimmetric(args(1))
            ' Создаём CryptoStream
            Dim fs As New IO.MemoryStream() 'Создаём FileStream, туда будет записана зашифрованная информация
            Dim RMCrypto As New Security.Cryptography.RijndaelManaged
            Dim CryptStream As New Security.Cryptography.CryptoStream(fs, RMCrypto.CreateEncryptor(Key, IV), Security.Cryptography.CryptoStreamMode.Write)
            Dim SWriter As New IO.StreamWriter(CryptStream)
            ' СОБСТВЕННО ПИШЕМ
            SWriter.Write(args(0))
            SWriter.Close()
            ' Возвращаем результат
            Dim str As String = Convert.ToBase64String(fs.ToArray)
            fs.Close()
            CryptStream.Close()
            Return str
        End Get
    End Property
    Overloads ReadOnly Property DecryptText(ByVal ParamArray args() As String)
        Get
            Try
                ' Формируем КЛЮЧ. Это должен быть массив bytes() c длинной либо 16 (128 бит), либо 32 (256 бит)
                Dim Key() As Byte = getKeySimmetric(args(1))
                ' Приводим строку в вид байтового массива
                Dim inputByteArray() As Byte = Convert.FromBase64String(args(0))
                Dim fs As New IO.MemoryStream(inputByteArray)
                'Создаём CryptoStream
                Dim RMCrypto As New Security.Cryptography.RijndaelManaged
                Dim CryptStream As New Security.Cryptography.CryptoStream(fs, RMCrypto.CreateDecryptor(Key, IV), Security.Cryptography.CryptoStreamMode.Read)
                Dim SReader As New IO.StreamReader(CryptStream)
                ' СОБСТВЕННО ЧИТАЕМ расшифрованную информацию из CryptoStream 
                Dim str As String = SReader.ReadToEnd
                'Закрываем все объекты
                SReader.Close()
                fs.Close()
                CryptStream.Close()
                '  If str.IndexOf(vbCrLf) = -1 Then str = str.Replace(vbCrLf.Substring(1), vbCrLf)
                Return str.Replace(vbCrLf.Substring(1), vbCrLf)
            Catch ex As Exception
                return trans("Ошибка при дешифрации. Либо неверный ключ шифрования, либо данные для дешифрации некорректны.")
                ' Throw New Exception(trans("Ошибка при дешифрации. Либо неверный ключ шифрования, либо данные для дешифрации некорректны.") _
                '    & vbCrLf & vbCrLf & ex.Message)
            End Try
        End Get
    End Property
    Function getKeySimmetric(ByVal k As String) As Byte()
        If k = "" Then Throw New Exception(trans("Ключ шифрования должен обязательно присутствовать!"))
        ' Формируем КЛЮЧ. Это должен быть массив bytes() c длинной либо 16 (128 бит), либо 32 (256 бит)
        Dim keyUser() As Byte = Encoding.UTF8.GetBytes(k)
        Dim len As Integer = keyUser.Length, i As Integer
        If len <= 16 Then
            len = 16
        Else
            len = 32
        End If
        Dim Key(len - 1) As Byte
        For i = 0 To len - 1
            If i < keyUser.Length Then
                Key(i) = keyUser(i)
            Else
                Key(i) = 1
            End If
        Next
        Return Key
    End Function


    ' SHOWMESSAGE
    Dim WCCan As String = trans("Нет")
    Overloads Property WasCancel() As String
        Get
            Return WCCan
        End Get
        Set(ByVal value As String)
            WCCan = value
        End Set
    End Property
    Dim WCOk As String = trans("Нет")
    Overloads Property WasOk() As String
        Get
            Return WCOk
        End Get
        Set(ByVal value As String)
            WCOk = value
        End Set
    End Property
    Dim WCRet As String = trans("Нет")
    Overloads Property WasRetry() As String
        Get
            Return WCRet
        End Get
        Set(ByVal value As String)
            WCRet = value
        End Set
    End Property
    Dim WCYes As String = trans("Нет")
    Overloads Property WasYes() As String
        Get
            Return WCYes
        End Get
        Set(ByVal value As String)
            WCYes = value
        End Set
    End Property
    Dim WCNo As String = trans("Нет")
    Overloads Property WasNo() As String
        Get
            Return WCNo
        End Get
        Set(ByVal value As String)
            WCNo = value
        End Set
    End Property
    Dim WCAb As String = trans("Нет")
    Overloads Property WasAbort() As String
        Get
            Return WCAb
        End Get
        Set(ByVal value As String)
            WCAb = value
        End Set
    End Property
    Dim WCIgn As String = trans("Нет")
    Overloads Property WasIgnore() As String
        Get
            Return WCIgn
        End Get
        Set(ByVal value As String)
            WCIgn = value
        End Set
    End Property
    Dim WCHelp As String = trans("Нет")
    Overloads Property WasHelp() As String
        Get
            Return WCHelp
        End Get
        Set(ByVal value As String)
            WCHelp = value
        End Set
    End Property
    Sub ShowMessage(ByVal ParamArray args() As String)
        Dim res As MsgBoxResult
        Dim msBut As Integer = MsgStyleButtons.GetByIndex(MsgStyleButtons.IndexOfKey(LCase(args(1))))
        Dim msTyp As Integer = MsgStyleTypes.GetByIndex(MsgStyleTypes.IndexOfKey(LCase(args(2))))

        res = MsgBox(args(0), msBut + msTyp, args(3))
        If res = MsgBoxResult.Abort Then WasAbort = trans("Да") Else WasAbort = trans("Нет")
        If res = MsgBoxResult.Cancel Then WasCancel = trans("Да") Else WasCancel = trans("Нет")
        If res = MsgBoxResult.Ignore Then WasIgnore = trans("Да") Else WasIgnore = trans("Нет")
        If res = MsgBoxResult.No Then WasNo = trans("Да") Else WasNo = trans("Нет")
        If res = MsgBoxResult.Ok Then WasOk = trans("Да") Else WasOk = trans("Нет")
        If res = MsgBoxResult.Retry Then WasRetry = trans("Да") Else WasRetry = trans("Нет")
        If res = MsgBoxResult.Yes Then WasYes = trans("Да") Else WasYes = trans("Нет")
    End Sub

    ' DATE
    Function DayOfMonth(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.Day
    End Function
    Function DayOfYear(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.DayOfYear
    End Function
    Function DayOfWeek(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.DayOfWeek
    End Function
    Function Hour(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.Hour
    End Function
    Function Minute(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.Minute
    End Function
    Function Second(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.Second
    End Function
    Function Quarter(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return DateAndTime.DatePart(DateInterval.Quarter, dt, FirstDayOfWeek.System)
    End Function
    Function WeekOfYear(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return DateAndTime.DatePart(DateInterval.WeekOfYear, dt, FirstDayOfWeek.System)
    End Function
    Function Year(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.Year
    End Function
    Function Month(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.Month
    End Function
    Function Ticks(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.ToBinary
    End Function
    Function Time(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.GetDateTimeFormats()(45)
    End Function
    Function DaysInMonth(ByVal ParamArray args() As String) As String
        Return Date.DaysInMonth(args(0), args(1))
    End Function
    Function Now() As String
        Return ToMyDate(Date.Now)
    End Function
    Function Today() As String
        Return ToMyDate(Date.Today).Split(" ")(0)
    End Function
    Function DateAddDay(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return ToMyDate(DateAndTime.DateAdd(DateInterval.Day, Val(args(1)), dt))
    End Function
    Function DateAddHour(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return ToMyDate(DateAndTime.DateAdd(DateInterval.Hour, Val(args(1)), dt))
    End Function
    Function DateAddMinute(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return ToMyDate(DateAndTime.DateAdd(DateInterval.Minute, Val(args(1)), dt))
    End Function
    Function DateAddSecond(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return ToMyDate(DateAndTime.DateAdd(DateInterval.Second, Val(args(1)), dt))
    End Function
    Function DateAddQuarter(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return ToMyDate(DateAndTime.DateAdd(DateInterval.Quarter, Val(args(1)), dt))
    End Function
    Function DateAddWeek(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return ToMyDate(DateAndTime.DateAdd(DateInterval.WeekOfYear, Val(args(1)), dt))
    End Function
    Function DateAddYear(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return ToMyDate(DateAndTime.DateAdd(DateInterval.Year, Val(args(1)), dt))
    End Function
    Function DateAddMonth(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return ToMyDate(DateAndTime.DateAdd(DateInterval.Month, Val(args(1)), dt))
    End Function
    Function DateDiffDay(ByVal ParamArray args() As String) As String
        Dim dt1 As Date = FromMyDate(args(0))
        Dim dt2 As Date = FromMyDate(args(1))
        If dt1 <> Nothing And dt2 <> Nothing Then
            Return DateAndTime.DateDiff(DateInterval.Day, dt1, dt2, FirstDayOfWeek.System)
        Else
            Return ""
        End If
    End Function
    Function DateDiffHour(ByVal ParamArray args() As String) As String
        Dim dt1 As Date = FromMyDate(args(0))
        Dim dt2 As Date = FromMyDate(args(1))
        If dt1 <> Nothing And dt2 <> Nothing Then
            Return DateAndTime.DateDiff(DateInterval.Hour, dt1, dt2, FirstDayOfWeek.System)
        Else
            Return ""
        End If
    End Function
    Function DateDiffMinute(ByVal ParamArray args() As String) As String
        Dim dt1 As Date = FromMyDate(args(0))
        Dim dt2 As Date = FromMyDate(args(1))
        If dt1 <> Nothing And dt2 <> Nothing Then
            Return DateAndTime.DateDiff(DateInterval.Minute, dt1, dt2, FirstDayOfWeek.System)
        Else
            Return ""
        End If
    End Function
    Function DateDiffSecond(ByVal ParamArray args() As String) As String
        Dim dt1 As Date = FromMyDate(args(0))
        Dim dt2 As Date = FromMyDate(args(1))
        If dt1 <> Nothing And dt2 <> Nothing Then
            Return DateAndTime.DateDiff(DateInterval.Second, dt1, dt2, FirstDayOfWeek.System)
        Else
            Return ""
        End If
    End Function
    Function DateDiffQuarter(ByVal ParamArray args() As String) As String
        Dim dt1 As Date = FromMyDate(args(0))
        Dim dt2 As Date = FromMyDate(args(1))
        If dt1 <> Nothing And dt2 <> Nothing Then
            Return DateAndTime.DateDiff(DateInterval.Quarter, dt1, dt2, FirstDayOfWeek.System)
        Else
            Return ""
        End If
    End Function
    Function DateDiffWeek(ByVal ParamArray args() As String) As String
        Dim dt1 As Date = FromMyDate(args(0))
        Dim dt2 As Date = FromMyDate(args(1))
        If dt1 <> Nothing And dt2 <> Nothing Then
            Return DateAndTime.DateDiff(DateInterval.WeekOfYear, dt1, dt2, FirstDayOfWeek.System)
        Else
            Return ""
        End If
    End Function
    Function DateDiffYear(ByVal ParamArray args() As String) As String
        Dim dt1 As Date = FromMyDate(args(0))
        Dim dt2 As Date = FromMyDate(args(1))
        If dt1 <> Nothing And dt2 <> Nothing Then
            Return DateAndTime.DateDiff(DateInterval.Year, dt1, dt2, FirstDayOfWeek.System)
        Else
            Return ""
        End If
    End Function
    Function DateDiffMonth(ByVal ParamArray args() As String) As String
        Dim dt1 As Date = FromMyDate(args(0))
        Dim dt2 As Date = FromMyDate(args(1))
        If dt1 <> Nothing And dt2 <> Nothing Then
            Return DateAndTime.DateDiff(DateInterval.Month, dt1, dt2, FirstDayOfWeek.System)
        Else
            Return ""
        End If
    End Function
    Function WeekdayName(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt <> Nothing Then
            Return trans(DateAndTime.WeekdayName(DateAndTime.Weekday(dt, FirstDayOfWeek.System)), , True)
        Else
            Return ""
        End If
    End Function
    Function MonthName(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt <> Nothing Then
            Return trans(DateAndTime.MonthName(DateAndTime.Month(dt)), , True)
        Else
            Return ""
        End If
    End Function
    Function GetDateTimeFormats(ByVal ParamArray args() As String) As String
        Dim dt As Date = FromMyDate(args(0))
        If dt = Nothing Then Return "" Else Return dt.GetDateTimeFormats()(args(1) - 1)
    End Function
    Sub SetSystemData(ByVal ParamArray args() As String)
        Dim dt As Date = FromMyDate(args(0))
        If dt <> Nothing Then
            Dim timeStru As SYSTEMTIME
            timeStru.wDay = dt.Day
            timeStru.wDayOfWeek = 0
            timeStru.wHour = dt.Hour
            timeStru.wMilliseconds = dt.Millisecond
            timeStru.wMinute = dt.Minute
            timeStru.wMonth = dt.Month
            timeStru.wSecond = dt.Second
            timeStru.wYear = dt.Year
            SetSystemTime(timeStru)
        End If
    End Sub

    ' RASSHIRENNIE VOZMOZHNOSTI
    Sub RunVBScript(ByVal ParamArray args() As String)
        Try
            'Dim nn As New MSScriptControl.ScriptControl()
            Dim nn As Object = CreateObject("MSScriptControl.ScriptControl")
            nn.Language = "VBScript"
            nn.AddCode(args(0))
            nn.Run("main")
        Catch ex As Exception
            If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
        End Try
    End Sub
    Sub RunAlgoritm2(ByVal ParamArray args() As String)
        Dim tmp As Boolean = isCompilBest : isCompilBest = False
        Try
            Dim cs As New CodeString(args(0), "None", False)
            Dim s() As String = cs.Split("", New String() {Chr(182), vbCrLf, vbCrLf.Substring(1)}).texty
            Dim t As New TreeNode()
            ' Генерируем ветки-узлы из кода Алг
            ToTreeFromAlgCode(t, s, 0)
            ' Запускаем код на выполнение в флагах
            isRunAlg2Code = True
            RunProj.RunBlock(t, 0, Nothing, False)
            isRunAlg2Code = False

            'For i = 0 To t.Lines.Length - 1
            '    es = RunProj.RunString(t.Lines(i), "Deist", New PropertysSobyt(Nothing, Nothing, (New System.EventArgs).GetType))
            '    If es.err <> "" Then Errors.MessangeCritic(vbCrLf & trans("В строке") & " """ & t.Lines(i) & """:" & vbCrLf & es.err)
            'Next
        Catch ex As Exception
            isRunAlg2Code = False
            If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
        End Try
        isCompilBest = tmp
    End Sub
    Sub RunVBNet(ByVal ParamArray args() As String)
        ' создали объект нашего компилятора
        Dim objCodeCompiler As System.CodeDom.Compiler.ICodeCompiler = New VBCodeProvider().CreateCompiler

        Dim objCompilerParameters As New System.CodeDom.Compiler.CompilerParameters()
        ' а это параметры к нему (что-то типа imports, можно конечно и без этого, 
        ' но тогда это все придется дописывать к программе самому пользователю)
        objCompilerParameters.ReferencedAssemblies.Add("System.dll")
        objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        objCompilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
        ' добавили нужные нам ссылки
        objCompilerParameters.GenerateInMemory = True
        ' а также укажем что это все надо генерировать в памяти

        Dim objCompileResults As System.CodeDom.Compiler.CompilerResults = _
        objCodeCompiler.CompileAssemblyFromSource(objCompilerParameters, args(0))
        ' попытаемся скомпилировать все это дело
        If objCompileResults.Errors.HasErrors Then
            ' если присутствуют какие-либо ошибки выведем пользователю первую
            ' можно бы было и все загнать в какой-нибудь listbox но было лень...
            Errors.MessangeCritic(vbCrLf & trans("В строке") & ": " & objCompileResults.Errors(0).Line.ToString & ", " & _
            objCompileResults.Errors(0).ErrorText)
            Exit Sub
        End If

        Dim objAssembly As System.Reflection.Assembly = objCompileResults.CompiledAssembly
        ' создаем сборку
        ' выполнение программы начнется с класса MainClass
        Dim objTheClass As Object = objAssembly.CreateInstance("MainClass")
        If objTheClass Is Nothing Then
            ' если такового класса нет, то увы...
            Errors.MessangeCritic(Errors.notMainClass(args(0)))
            Exit Sub
        End If
        ' а вот если он есть то вызываем его метод ExecuteCode и вперед...
        Try
            objTheClass.GetType.InvokeMember("Main", System.Reflection.BindingFlags.InvokeMethod, Nothing, objTheClass, Nothing)
        Catch ex As Exception
            If IgnorEr = False Then Errors.MessangeCritic(ex.Message & ". " & ex.InnerException.Message)
        End Try
    End Sub
    Sub RunCSharp(ByVal ParamArray args() As String)
        ' создали объект нашего компилятора
        Dim objCodeCompiler As System.CodeDom.Compiler.ICodeCompiler = New Microsoft.CSharp.CSharpCodeProvider().CreateCompiler

        Dim objCompilerParameters As New System.CodeDom.Compiler.CompilerParameters()
        ' а это параметры к нему (что-то типа imports, можно конечно и без этого, 
        ' но тогда это все придется дописывать к программе самому пользователю)
        objCompilerParameters.ReferencedAssemblies.Add("System.dll")
        objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        objCompilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
        ' добавили нужные нам ссылки
        objCompilerParameters.GenerateInMemory = True
        ' а также укажем что это все надо генерировать в памяти

        Dim objCompileResults As System.CodeDom.Compiler.CompilerResults = _
        objCodeCompiler.CompileAssemblyFromSource(objCompilerParameters, args(0))
        ' попытаемся скомпилировать все это дело
        If objCompileResults.Errors.HasErrors Then
            ' если присутствуют какие-либо ошибки выведем пользователю первую
            ' можно бы было и все загнать в какой-нибудь listbox но было лень...
            Errors.MessangeCritic(vbCrLf & trans("В строке") & ": " & objCompileResults.Errors(0).Line.ToString & ", " & _
            objCompileResults.Errors(0).ErrorText)
            Exit Sub
        End If

        Dim objAssembly As System.Reflection.Assembly = objCompileResults.CompiledAssembly
        ' создаем сборку
        ' выполнение программы начнется с класса MainClass
        Dim objTheClass As Object = objAssembly.CreateInstance("MainClass")
        If objTheClass Is Nothing Then
            ' если такового класса нет, то увы...
            Errors.MessangeCritic(Errors.notMainClass(args(0)))
            Exit Sub
        End If
        ' а вот если он есть то вызываем его метод ExecuteCode и вперед...
        Try
            objTheClass.GetType.InvokeMember("Main", System.Reflection.BindingFlags.InvokeMethod, Nothing, objTheClass, Nothing)
        Catch ex As Exception
            If IgnorEr = False Then MsgBox("Error:" & ex.Message)
        End Try
    End Sub


End Class

Public Class Propertys
    Public obj As Object
    Sub New(ByVal ob As Object)
        obj = ob
    End Sub
    Overloads Property Name() As String
        Get
            Return obj.Name
        End Get
        Set(ByVal value As String)
            Dim oldName As String = obj.Name : obj.Name = value
            If proj Is Nothing = False Then proj.ChangeName(obj, oldName)
        End Set
    End Property
    Dim CM As String = trans("Никакой")
    Overloads Property ContextMenu() As String
        Get
            Return CM
        End Get
        Set(ByVal value As String)
            CM = value
        End Set
    End Property
    Dim CM1 As String = trans("Никакой")
    Overloads Property ContextMenu1() As String
        Get
            Return CM1
        End Get
        Set(ByVal value As String)
            CM1 = value
        End Set
    End Property
    Dim CM2 As String = trans("Никакой")
    Overloads Property ContextMenu2() As String
        Get
            Return CM2
        End Get
        Set(ByVal value As String)
            CM2 = value
        End Set
    End Property
    Dim ind As String = "0"
    Overloads Property Index() As String
        Get
            Return ind
        End Get
        Set(ByVal value As String)
            Dim oldInd As String = ind : ind = value
            If proj Is Nothing = False Then proj.ChangeIndex(obj, oldInd)
        End Set
    End Property
    Dim anch As String = trans("Слева_Сверху")
    Overloads Property Anchor() As String
        Get
            Return anch
        End Get
        Set(ByVal value As String)
            anch = value
            obj.Anchor = Anchors.GetByIndex(Anchors.IndexOfKey(LCase(anch)))
        End Set
    End Property
    Dim AutoTr As String = trans("Да")
    Overloads Property AutoEllipsis() As String
        Get
            Return AutoTr
        End Get
        Set(ByVal value As String)
            AutoTr = value
            obj.AutoEllipsis = DaOrNet(AutoTr)
        End Set
    End Property
    Dim niv As String = trans("Нет")
    Overloads Property ShowInTray() As String
        Get
            Return niv
        End Get
        Set(ByVal value As String)
            niv = value
            If IsFORMRunObj(obj) Then
                If DaOrNet(value) = True Then
                    obj.ni.visible = True
                Else
                    obj.ni.visible = False
                End If
            End If
        End Set
    End Property
    Public Sem As Boolean = False
    Sub MinimizeToTray()
        Sem = True
        Application.DoEvents()
        obj.Props.ShowInTaskbar = trans("Нет")
        obj.Props.ShowInTray = trans("Да")
        obj.Props.visible = trans("Нет")
        If UCase(obj.Props.WindowState) <> UCase(trans("Свернуто")) Then obj.Props.WindowState = trans("Свернуто")
        Sem = False
    End Sub
    Sub MaximizeFromTray()
        Sem = True
        Application.DoEvents()
        obj.Props.WindowState = trans("Нормальный")
        obj.Props.ShowInTaskbar = trans("Да")
        obj.Props.ShowInTray = trans("Нет")
        obj.Props.visible = trans("Да")
        Sem = False
    End Sub

    Dim BkColor As String = trans("Никакой")
    Overloads Property BackColor() As String
        Get
            If Iz.IsTl(obj.MyObj) Then
                Return ToMyColor(obj.BackgroundColor)
            Else
                Return ToMyColor(obj.BackColor)
            End If
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.BackColor = Color.Transparent
                    BkColor = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                BkColor = value
                If Iz.IsTl(obj.MyObj) Then
                    obj.BackgroundColor = FromMyColor(BkColor)
                Else
                    obj.BackColor = FromMyColor(BkColor)
                End If
            End If
        End Set
    End Property
    Dim BkColor1 As String = trans("Никакой")
    Overloads Property BackColor1() As String
        Get
            Return ToMyColor(obj.Panel1.BackColor)
        End Get
        Set(ByVal value As String)
            BkColor1 = value
            If NikakoiEsli(BkColor1) = trans("Никакой") Then
                obj.Panel1.BackColor = Color.Transparent
            Else
                obj.Panel1.BackColor = FromMyColor(BkColor1)
            End If
        End Set
    End Property
    Dim BkColor2 As String = trans("Никакой")
    Overloads Property BackColor2() As String
        Get
            Return ToMyColor(obj.Panel2.BackColor)
        End Get
        Set(ByVal value As String)
            BkColor2 = value
            If NikakoiEsli(BkColor2) = trans("Никакой") Then
                obj.Panel2.BackColor = Color.Transparent
            Else
                obj.Panel2.BackColor = FromMyColor(BkColor2)
            End If
        End Set
    End Property
    Dim backImage As String = trans("Никакой")
    Overloads Property BackgroundImage() As String
        Get
            Return GetMinPath(backImage)
        End Get
        Set(ByVal value As String)
            backImage = GetMaxPath(value)
            If IsHttpCompil = False Then
                If NikakoiEsli(backImage) <> trans("Никакой") Then
                    Try
                        obj.BackgroundImage = Drawing.Image.FromFile(backImage)
                    Catch ex As Exception
                        obj.BackgroundImage = Nothing
                        If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
                    End Try
                Else
                    obj.BackgroundImage = Nothing
                End If
            End If
        End Set
    End Property
    Dim backImage1 As String = trans("Никакой")
    Overloads Property BackgroundImage1() As String
        Get
            Return GetMinPath(backImage1)
        End Get
        Set(ByVal value As String)
            backImage1 = GetMaxPath(value)
            If IsHttpCompil = False Then
                If NikakoiEsli(backImage1) <> trans("Никакой") Then
                    Try
                        obj.Panel1.BackgroundImage = Drawing.Image.FromFile(backImage1)
                    Catch ex As Exception
                        obj.Panel1.BackgroundImage = Nothing
                        If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
                    End Try
                Else
                    obj.Panel1.BackgroundImage = Nothing
                End If
            End If
        End Set
    End Property
    Dim backImage2 As String = trans("Никакой")
    Overloads Property BackgroundImage2() As String
        Get
            Return GetMinPath(backImage2)
        End Get
        Set(ByVal value As String)
            backImage2 = GetMaxPath(value)
            If IsHttpCompil = False Then
                If NikakoiEsli(backImage2) <> trans("Никакой") Then
                    Try
                        obj.Panel2.BackgroundImage = Drawing.Image.FromFile(backImage2)
                    Catch ex As Exception
                        obj.Panel2.BackgroundImage = Nothing
                        If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
                    End Try
                Else
                    obj.Panel2.BackgroundImage = Nothing
                End If
            End If
        End Set
    End Property
    Dim bkImageStyle As String = trans("Плитка")
    Overloads Property BackgroundImageLayout() As String
        Get
            Return bkImageStyle
        End Get
        Set(ByVal value As String)
            bkImageStyle = value
            obj.BackgroundImageLayout = bkImStyles.GetByIndex(bkImStyles.IndexOfKey(LCase(bkImageStyle)))
        End Set
    End Property
    Dim bkImageStyle1 As String = trans("Плитка")
    Overloads Property BackgroundImageLayout1() As String
        Get
            Return bkImageStyle1
        End Get
        Set(ByVal value As String)
            bkImageStyle1 = value
            obj.Panel1.BackgroundImageLayout = bkImStyles.GetByIndex(bkImStyles.IndexOfKey(LCase(bkImageStyle1)))
        End Set
    End Property
    Dim bkImageStyle2 As String = trans("Плитка")
    Overloads Property BackgroundImageLayout2() As String
        Get
            Return bkImageStyle2
        End Get
        Set(ByVal value As String)
            bkImageStyle2 = value
            obj.Panel2.BackgroundImageLayout = bkImStyles.GetByIndex(bkImStyles.IndexOfKey(LCase(bkImageStyle2)))
        End Set
    End Property
    Dim curs As String = trans("Обычный")
    Overloads Property Cursor() As String
        Get
            Return curs
        End Get
        Set(ByVal value As String)
            curs = value
            obj.Cursor = Cursori.GetByIndex(Cursori.IndexOfKey(LCase(curs)))
        End Set
    End Property
    Dim curs1 As String = trans("Обычный")
    Overloads Property Cursor1() As String
        Get
            Return curs1
        End Get
        Set(ByVal value As String)
            curs1 = value
            obj.Panel1.Cursor = Cursori.GetByIndex(Cursori.IndexOfKey(LCase(curs1)))
        End Set
    End Property
    Dim curs2 As String = trans("Обычный")
    Overloads Property Cursor2() As String
        Get
            Return curs2
        End Get
        Set(ByVal value As String)
            curs2 = value
            obj.Panel2.Cursor = Cursori.GetByIndex(Cursori.IndexOfKey(LCase(curs2)))
        End Set
    End Property
    Dim dok As String = trans("Никакой")
    Overloads Property Dock() As String
        Get
            Return dok
        End Get
        Set(ByVal value As String)
            dok = value
            obj.Dock = Docks.GetByIndex(Docks.IndexOfKey(LCase(dok)))
        End Set
    End Property
    Dim enab As String = trans("Да")
    Overloads Property Enabled() As String
        Get
            Return enab
        End Get
        Set(ByVal value As String)
            enab = value
        End Set
    End Property
    Dim styl As String = trans("Обычный")
    Overloads Property FlatStyle() As String
        Get
            Return styl
        End Get
        Set(ByVal value As String)
            styl = value
            obj.FlatStyle = FlatStyles.GetByIndex(FlatStyles.IndexOfKey(LCase(styl)))
        End Set
    End Property
    Dim bstyl As String = trans("Никакой")
    Overloads Property BorderStyle() As String
        Get
            Return bstyl
        End Get
        Set(ByVal value As String)
            bstyl = value
            obj.BorderStyle = BorderStyles.GetByIndex(BorderStyles.IndexOfKey(LCase(bstyl)))
        End Set
    End Property
    Dim fontFam As String = trans("Microsoft Sans Serif")
    Overloads Property FontFamily() As String
        Get
            Return fontFam
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then Exit Property
            Dim styleF As FontStyle = obj.Font.Style
            Try
                obj.Font = New Font(Fonts.GetByIndex(Fonts.IndexOfKey(LCase(value))).ToString, obj.Font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(value) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
            fontFam = value
        End Set
    End Property
    Dim fontBol As String = trans("Нет")
    Overloads Property FontBold() As String
        Get
            Return fontBol
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle = Int(DaOrNet(value)) * FontStyle.Bold + Int(DaOrNet(fontItal)) * FontStyle.Italic + Int(DaOrNet(fontUnder)) * FontStyle.Underline + Int(DaOrNet(fontStrike)) * FontStyle.Strikeout
            Dim ffam As FontFamily = obj.Font.FontFamily
            Try
                obj.Font = New Font(ffam, obj.Font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(ffam.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
            fontBol = value
        End Set
    End Property
    Dim fontItal As String = trans("Нет")
    Overloads Property FontItalic() As String
        Get
            Return fontItal
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle = Int(DaOrNet(fontBol)) * FontStyle.Bold + Int(DaOrNet(value)) * FontStyle.Italic + Int(DaOrNet(fontUnder)) * FontStyle.Underline + Int(DaOrNet(fontStrike)) * FontStyle.Strikeout
            Dim ffam As FontFamily = obj.Font.FontFamily
            Try
                obj.Font = New Font(ffam, obj.Font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(ffam.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
            fontItal = value
        End Set
    End Property
    Dim fontUnder As String = trans("Нет")
    Overloads Property FontUnderline() As String
        Get
            Return fontUnder
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle = Int(DaOrNet(fontBol)) * FontStyle.Bold + Int(DaOrNet(fontItal)) * FontStyle.Italic + Int(DaOrNet(value)) * FontStyle.Underline + Int(DaOrNet(fontStrike)) * FontStyle.Strikeout
            Dim ffam As FontFamily = obj.Font.FontFamily
            Try
                obj.Font = New Font(ffam, obj.Font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(ffam.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
            fontUnder = value
        End Set
    End Property
    Dim fontStrike As String = trans("Нет")
    Overloads Property FontStrikeout() As String
        Get
            Return fontStrike
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle = Int(DaOrNet(fontBol)) * FontStyle.Bold + Int(DaOrNet(fontItal)) * FontStyle.Italic + Int(DaOrNet(fontUnder)) * FontStyle.Underline + Int(DaOrNet(value)) * FontStyle.Strikeout
            Dim ffam As FontFamily = obj.Font.FontFamily
            Try
                obj.Font = New Font(ffam, obj.Font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(ffam.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
            fontStrike = value
        End Set
    End Property
    Overloads Property FontSize() As Integer
        Get
            Return obj.font.size
        End Get
        Set(ByVal value As Integer)
            Dim styleF As FontStyle = obj.Font.Style
            Try
                obj.Font = New Font(obj.font.fontfamily.name.ToString, value, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(value) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
        End Set
    End Property
    Dim fontCol As String = trans("Черный")
    Overloads Property ForeColor() As String
        Get
            Return fontCol
        End Get
        Set(ByVal value As String)
            fontCol = value
            If NikakoiEsli(fontCol) = trans("Никакой") Then
                obj.ForeColor = Color.Transparent
            Else
                obj.ForeColor = FromMyColor(fontCol)
            End If
        End Set
    End Property
    Dim Img As String = trans("Никакой")
    Overloads Property Image() As String
        Get
            Return GetMinPath(Img)
        End Get
        Set(ByVal value As String)
            Img = GetMaxPath(value)
            If IsHttpCompil = False Then
                If NikakoiEsli(Img) <> trans("Никакой") Then
                    Try
                        obj.Image = Drawing.Image.FromFile(Img)
                    Catch ex As Exception
                        obj.Image = Nothing
                        If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
                    End Try
                Else
                    obj.Image = Nothing
                End If
            End If
        End Set
    End Property
    Overloads Property SizeMode() As String
        Get
            Return SizeModes.GetKey(SizeModes.IndexOfValue(obj.SizeMode))
        End Get
        Set(ByVal value As String)
            obj.SizeMode = SizeModes.GetByIndex(SizeModes.IndexOfKey(LCase(value)))
        End Set
    End Property
    Dim ImgAl As String = trans("Центр")
    Overloads Property ImageAlign() As String
        Get
            Return ImgAl
        End Get
        Set(ByVal value As String)
            ImgAl = value
            obj.ImageAlign = Aligns.GetByIndex(Aligns.IndexOfKey(LCase(ImgAl)))
        End Set
    End Property
    Dim lft As Integer = 0
    Overloads Property X() As Integer
        Get
            Return lft
        End Get
        Set(ByVal value As Integer)
            lft = value
            If Iz.IsFORMobj(obj) = False Then obj.left = lft
        End Set
    End Property
    Dim tp As Integer = 0
    Overloads Property Y() As Integer
        Get
            Return tp
        End Get
        Set(ByVal value As Integer)
            tp = value
            If Iz.IsFORMobj(obj) = False Then obj.Top = tp
        End Set
    End Property
    Dim maxWidth As Integer = 0
    Overloads Property MaximumWidth() As Integer
        Get
            Return maxWidth
        End Get
        Set(ByVal value As Integer)
            maxWidth = value
            obj.MaximumSize = New Size(maxWidth, MaximumHeight)
        End Set
    End Property
    Dim maxHeight As Integer = 0
    Overloads Property MaximumHeight() As Integer
        Get
            Return maxHeight
        End Get
        Set(ByVal value As Integer)
            maxHeight = value
            obj.MaximumSize = New Size(MaximumWidth, maxHeight)
        End Set
    End Property
    Dim minWidth As Integer = 0
    Overloads Property MinimumWidth() As Integer
        Get
            Return minWidth
        End Get
        Set(ByVal value As Integer)
            minWidth = value
            obj.MinimumSize = New Size(minWidth, MinimumHeight)
        End Set
    End Property
    Dim minHeight As Integer = 0
    Overloads Property MinimumHeight() As Integer
        Get
            Return minHeight
        End Get
        Set(ByVal value As Integer)
            minHeight = value
            obj.MinimumSize = New Size(MinimumWidth, minHeight)
        End Set
    End Property
    Dim padLeft As Integer = 0
    Overloads Property PaddingLeft() As Integer
        Get
            Return padLeft
        End Get
        Set(ByVal value As Integer)
            padLeft = value
            If Iz.IsPrD(obj) = False Then
                obj.Padding = New Padding(padLeft, PaddingTop, PaddingRight, PaddingBottom)
            ElseIf isRUN() Then
                obj.PrintDoc.DefaultPageSettings.Margins.Left = value
            End If
        End Set
    End Property
    Dim padTop As Integer = 0
    Overloads Property PaddingTop() As Integer
        Get
            Return padTop
        End Get
        Set(ByVal value As Integer)
            padTop = value
            If Iz.IsPrD(obj) = False Then
                obj.Padding = New Padding(PaddingLeft, padTop, PaddingRight, PaddingBottom)
            ElseIf isRUN() Then
                obj.PrintDoc.DefaultPageSettings.Margins.Top = value
            End If
        End Set
    End Property
    Dim padRight As Integer = 0
    Overloads Property PaddingRight() As Integer
        Get
            Return padRight
        End Get
        Set(ByVal value As Integer)
            padRight = value
            If Iz.IsPrD(obj) = False Then
                obj.Padding = New Padding(PaddingLeft, PaddingTop, padRight, PaddingBottom)
            ElseIf isRUN() Then
                obj.PrintDoc.DefaultPageSettings.Margins.Right = value
            End If
        End Set
    End Property
    Dim padBottom As Integer = 0
    Overloads Property PaddingBottom() As Integer
        Get
            Return padBottom
        End Get
        Set(ByVal value As Integer)
            padBottom = value
            If Iz.IsPrD(obj) = False Then
                obj.Padding = New Padding(PaddingLeft, PaddingTop, PaddingRight, padBottom)
            ElseIf isRUN() Then
                obj.PrintDoc.DefaultPageSettings.Margins.Bottom = value
            End If
        End Set
    End Property
    Dim Wid As Integer = 0
    Overloads Property Width() As Integer
        Get
            Return Wid
        End Get
        Set(ByVal value As Integer)
            Wid = value
            obj.Width = Wid
        End Set
    End Property
    Dim Hei As Integer = 0
    Overloads Property Height() As Integer
        Get
            Return Hei
        End Get
        Set(ByVal value As Integer)
            Hei = value
            obj.Height = Hei
        End Set
    End Property
    Dim tabInd As Integer = 0
    Overloads Property TabIndex() As Integer
        Get
            Return tabInd
        End Get
        Set(ByVal value As Integer)
            tabInd = value
            obj.TabIndex = tabInd
        End Set
    End Property
    Dim tabStp As String = trans("Да")
    Overloads Property TabStop() As String
        Get
            Return tabStp
        End Get
        Set(ByVal value As String)
            tabStp = value
            obj.TabStop = DaOrNet(tabStp)
        End Set
    End Property
    Dim tg As String = ""
    Overloads Property Tag() As String
        Get
            Return tg
        End Get
        Set(ByVal value As String)
            tg = value
        End Set
    End Property
    Public txt As String = "mkjhg"
    Public Sep As Object
    Property Text() As String
        Get
            If obj.MyObj.GetType.ToString = ClassAplication & "TextBoks" Then txt = obj.text
            Return txt
        End Get
        Set(ByVal value As String)
            ' Преобразовать сепаратор в меню или панели в обычный пункт
            If txt = "-" And value <> "-" And Iz.IsMMs(obj.myObj) Then
                If OwnerItem <> trans("Никакой") Then
                    If Iz.IsTPl(ownIt.myObj) Or Iz.IsMM(ownIt.myObj) Then
                        If Sep Is Nothing = False Then ownIt.Items.Remove(Sep)
                        ownIt.Items.Insert(Position, obj)
                    ElseIf Iz.IsMMs(ownIt.myObj) Then
                        If Sep Is Nothing = False Then ownIt.DropDownItems.Remove(Sep)
                        ownIt.DropDownItems.Insert(Position, obj)
                    End If
                End If
            End If
            txt = value
            If Iz.IsCr(obj.myObj) Then Try : obj.Text = value : Catch ex As Exception : End Try : Exit Property
            obj.Text = value
            If Iz.IsLLb(obj.myObj) Then
                Dim len As Integer = LinkLength
                If LinkNam = "" Then
                    If LinkStart >= 0 And LinkStart < Text.Length Then
                        If LinkLength > 0 Then
                            If LinkStart + LinkLength > Text.Length Then len = Text.Length - LinkStart
                            LinkNam = Text.Substring(LinkStart, len)
                        End If
                    End If
                End If
            End If
            ' Сделать сепаратор в меню или панели из обычного пункта
            If value = "-" And Iz.IsMMs(obj.myObj) Then
                If OwnerItem <> trans("Никакой") Then
                    Sep = New ToolStripSeparator() : Sep.tag = obj
                    If Iz.IsTPl(ownIt.myObj) Or Iz.IsMM(ownIt.myObj) Or Iz.IsCM(ownIt.myObj) Then
                        ownIt.Items.Insert(Position, Sep)
                        ownIt.Items.Remove(obj)
                    ElseIf Iz.IsMMs(ownIt.myObj) Then
                        ownIt.DropDownItems.Insert(Position, Sep)
                        ownIt.DropDownItems.Remove(obj)
                    End If
                End If
            End If
        End Set
    End Property
    Dim txtAl As String = trans("Центр")
    Overloads Property TextAlign() As String
        Get
            Return Aligns.GetKey(Aligns.IndexOfValue(obj.TextAlign))
        End Get
        Set(ByVal value As String)
            txtAl = value
            obj.TextAlign = Aligns.GetByIndex(Aligns.IndexOfKey(LCase(txtAl)))
        End Set
    End Property
    Dim txtPos As String = trans("Слева")
    Overloads Property TextPosition() As String
        Get
            Return txtPos
        End Get
        Set(ByVal value As String)
            txtPos = value
            obj.TextAlign = TextPositions.GetByIndex(TextPositions.IndexOfKey(LCase(txtPos)))
        End Set
    End Property
    Dim txtImRel As String = trans("Поверх")
    Overloads Property TextImageRelation() As String
        Get
            Return txtImRel
        End Get
        Set(ByVal value As String)
            txtImRel = value
            obj.TextImageRelation = TextImages.GetByIndex(TextImages.IndexOfKey(LCase(txtImRel)))
        End Set
    End Property
    Dim vis As String = trans("Да")
    Overloads Property Visible() As String
        Get
            Return vis
        End Get
        Set(ByVal value As String)
            vis = value
        End Set
    End Property
    Dim mf As String = trans("Да")
    Overloads Property MainForm() As String
        Get
            Return mf
        End Get
        Set(ByVal value As String)
            mf = value
        End Set
    End Property
    Dim cancelCl As String = trans("Нет")
    Overloads Property ForbidClose() As String
        Get
            Return cancelCl
        End Get
        Set(ByVal value As String)
            cancelCl = value
        End Set
    End Property
    Dim mab As String = trans("Нет")
    Overloads Property ForbidMaximize() As String
        Get
            Return mab
        End Get
        Set(ByVal value As String)
            mab = value
        End Set
    End Property
    Dim mib As String = trans("Нет")
    Overloads Property ForbidMinimize() As String
        Get
            Return mib
        End Get
        Set(ByVal value As String)
            mib = value
        End Set
    End Property
    Dim AssocExts As String = ""
    Overloads Property AssociateWithExtensions() As String
        Get
            Return AssocExts
        End Get
        Set(ByVal value As String)
            AssocExts = value
        End Set
    End Property
    Overloads Property AssociationPassedFile() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public pos As Integer = 0
    Overloads Property Position() As Integer
        Get
            Return pos
        End Get
        Set(ByVal value As Integer)
            pos = value
            obj.MoveToPosition()
        End Set
    End Property
    Dim aScrl As String = trans("Нет")
    Overloads Property Scroll() As String
        Get
            Return aScrl
        End Get
        Set(ByVal value As String)
            aScrl = value
            obj.autoScroll = DaOrNet(aScrl)
        End Set
    End Property
    Overloads Property Checked() As String
        Get
            Return DaOrNet(obj.Checked)
        End Get
        Set(ByVal value As String)
            obj.Checked = DaOrNet(value)
        End Set
    End Property
    Dim orientTl As String = trans("Горизонтальная")
    Overloads Property OrientationTools() As String
        Get
            Return orientTl
        End Get
        Set(ByVal value As String)
            orientTl = value
            obj.LayoutStyle = Orientations.GetByIndex(Orientations.IndexOfKey(LCase(orientTl))) + 1
        End Set
    End Property
    Dim alig As String = trans("Да")
    Overloads Property Alignment() As String
        Get
            Return alig
        End Get
        Set(ByVal value As String)
            alig = value
            obj.Alignment = Int(Not DaOrNet(alig))
        End Set
    End Property
    Dim aTT As String = trans("Нет")
    Overloads Property AutoToolTip() As String
        Get
            Return aTT
        End Get
        Set(ByVal value As String)
            aTT = value
            obj.AutoToolTip = DaOrNet(aTT)
        End Set
    End Property
    Dim ChOnCl As String = trans("Нет")
    Overloads Property CheckOnClick() As String
        Get
            Return ChOnCl
        End Get
        Set(ByVal value As String)
            ChOnCl = value
            obj.CheckOnClick = DaOrNet(ChOnCl)
        End Set
    End Property
    Dim dispSt As String = trans("Рисунок и текст")
    Overloads Property DisplayStyle() As String
        Get
            Return dispSt
        End Get
        Set(ByVal value As String)
            dispSt = value
            obj.DisplayStyle = DisplayStyles.GetByIndex(DisplayStyles.IndexOfKey(LCase(dispSt)))
        End Set
    End Property
    Public lastSource As Object
    Overloads Property OwnerObject() As String
        Get
            Dim sorc As Object = FindOwnerContextMenu(obj)
            If sorc Is Nothing Then sorc = lastSource
            If sorc Is Nothing Then Return trans("Никакой")
            lastSource = sorc

            If sorc.Props.index = 0 Then
                Return sorc.Props.name
            Else
                Return sorc.Props.name & "[" & sorc.Props.index & "]"
            End If
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then lastSource = Nothing : Exit Property
            ' определение объекта по имени value
            If obj.MyObj.getmyform IsNot Nothing Then
                lastSource = obj.MyObj.proj.GetMyObjFromUniqName(obj.MyObj.getmyform.obj.name & "." & value)
            End If
            If IsArray(lastSource) Then lastSource = lastSource(0)
            ' Присвоить объекту-хозяину это контекстное меню
            If lastSource IsNot Nothing Then
                lastSource = lastSource.obj
                Try
                    If Index = 0 Then
                        lastSource.props.ContextMenu = Name
                    Else
                        lastSource.props.ContextMenu = Name & "[" & Index & "]"
                    End If
                Catch ex As Exception
                    ' чтобы могли также быть хозяином объекты, не имеющие свойства "всплывающее меню"
                End Try
            End If
        End Set
    End Property
    Overloads Property OwnerMenu() As String
        Get
            Dim sorc As Object = FindOwnerContextMenu(obj)
            If sorc Is Nothing Then Return trans("Никакой")
            'return myobj.proj.GetMyObjFromObj( sorc)
            ' Return obj.myobj.GetUNameObj(sorc.myobj)
            If sorc.Props.index = 0 Then
                Return sorc.Props.name
            Else
                Return sorc.Props.name & "[" & sorc.Props.index & "]"
            End If
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public ownIt As Object
    Public MyOwnIt As Object
    Overloads Property OwnerItem() As String
        Get
            If ownIt Is Nothing Then ownIt = obj.OwnerItem
            If ownIt Is Nothing Then ownIt = obj.Owner
            If ownIt Is Nothing Then Return trans("Никакой")
            If ownIt.GetType.ToString = "System.Windows.Forms.ContextMenuStrip" Then ownIt = obj.myobj.conteiner.obj
            If ownIt.Props.index = 0 Then
                Return ownIt.Props.name
            Else
                Return ownIt.Props.name & "[" & ownIt.Props.index & "]"
            End If
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Dim dm As String = trans("Никакой")
    Dim oldMenu As ToolStripDropDownMenu = Nothing
    Overloads Property DropDown(Optional ByVal fromLoad As Boolean = False) As String
        Get
            Return dm
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) <> trans("Никакой") Then

                ' Получить контекстное меню по имени
                Dim CnMn = GetContextMenu(obj.MyObj, value)

                ' присвоить объекту его, если таковое существует
                If CnMn Is Nothing = False Then
                    oldMenu = obj.DropDown
                    obj.DropDown = CnMn.obj.CnMn
                Else
                    ' если меню не нашлось и проект не запущен, то выйти
                    If isRUN() Then dm = value : Exit Property
                    ' если проект запущен
                    Errors.MessangeExclamen(Errors.InvalidContextMenu(value, Name)) : Exit Property
                End If
            Else
                If fromLoad Then dm = value : Exit Property
                obj.DropDown = oldMenu
            End If

            dm = value
        End Set
    End Property
    Dim imScal As String = trans("Нет")
    Overloads Property ImageScaling() As String
        Get
            Return imScal
        End Get
        Set(ByVal value As String)
            imScal = value
            obj.ImageScaling = Int(Not DaOrNet(imScal))
            '             i = (New ToolStripMenuItem). = True
        End Set
    End Property
    Dim imTranspCol As String = trans("Никакой")
    Overloads Property ImageTransparentColor() As String
        Get
            Return imTranspCol
        End Get
        Set(ByVal value As String)
            imTranspCol = value
            If NikakoiEsli(imTranspCol) = trans("Никакой") Then
                obj.ImageTransparentColor = Nothing 'Color.Transparent
            Else
                obj.ImageTransparentColor = FromMyColor(imTranspCol)
            End If
        End Set
    End Property
    Dim shortK As String = trans("Никакой")
    Overloads Property ShortcutKeys() As String
        Get
            Return shortK
        End Get
        Set(ByVal value As String)
            Dim i As Integer, key As Keys
            Dim mass() As String = value.Split(";")
            For i = 0 To mass.Length - 1
                key += Keyz(Trim(LCase(mass(i))))
            Next
            Try
                obj.ShortcutKeys = key
            Catch ex As Exception
                If IgnorEr = False Then Errors.MessangeCritic(Errors.InvalidKeys(value, obj.name))
                Exit Property
            End Try
            shortK = value
        End Set
    End Property
    Dim shSK As String = trans("Да")
    Overloads Property ShowShortcutKeys() As String
        Get
            Return shSK
        End Get
        Set(ByVal value As String)
            shSK = value
            obj.ShowShortcutKeys = DaOrNet(shSK)
        End Set
    End Property
    Dim txtDirc As String = trans("Горизонтальный")
    Overloads Property TextDirection() As String
        Get
            Return txtDirc
        End Get
        Set(ByVal value As String)
            txtDirc = value
            obj.TextDirection = TextDirections.GetByIndex(TextDirections.IndexOfKey(LCase(txtDirc)))
        End Set
    End Property
    Dim toolTT As String = trans("")
    Overloads Property ToolTipText() As String
        Get
            Return toolTT
        End Get
        Set(ByVal value As String)
            toolTT = value
            obj.ToolTipText = toolTT
        End Set
    End Property
    Dim Aligz As String = trans("Сверху")
    Overloads Property TabAlignment() As String
        Get
            Return Aligz
        End Get
        Set(ByVal value As String)
            Aligz = value
            obj.Alignment = Alignments.GetByIndex(Alignments.IndexOfKey(LCase(Aligz)))
        End Set
    End Property
    Overloads Property SelectedTabIndex() As Integer
        Get
            Return obj.selectedTab.props.index
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property
    Dim SelTabPos As Integer = 0
    Overloads Property SelectedTabPosition() As Integer
        Get
            Return SelTabPos
        End Get
        Set(ByVal value As Integer)
            SelTabPos = value
            obj.selectedIndex = SelTabPos
        End Set
    End Property
    Dim padX As Integer = 6
    Overloads Property PaddingX() As Integer
        Get
            Return padX
        End Get
        Set(ByVal value As Integer)
            padX = value
            obj.Padding = New Point(padX, padY)
        End Set
    End Property
    Dim padY As Integer = 3
    Overloads Property PaddingY() As Integer
        Get
            Return padY
        End Get
        Set(ByVal value As Integer)
            padY = value
            obj.Padding = New Point(padX, padY)
        End Set
    End Property
    Dim val As String = ""
    Overloads Property Value() As String
        Get
            If Iz.IsM(obj.MyObj) = False Then Return obj.value
            Return val
        End Get
        Set(ByVal value As String)
            If isRUN() And obj.GetType.ToString = ClassAplication & "runM" Then
                obj.RaiseChangingValue(value)
                If obj.myobj.proj.Param.ParamyUp Is Nothing = False Then
                    If obj.myobj.proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить событие"))) = trans("Да") Then Exit Property
                End If
            End If
            val = value
            If Iz.IsM(obj.MyObj) = False Then
                Try
                    obj.value = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeInfo(ex.Message)
                End Try
            End If
            If isRUN() And obj.GetType.ToString = ClassAplication & "runM" Then obj.RaiseChangedValue()
        End Set
    End Property
    Dim AuRu As String = trans("Нет")
    Overloads Property AutoRun() As String
        Get
            Return AuRu
        End Get
        Set(ByVal value As String)
            AuRu = value
            If DaOrNet(AuRu) = True And isRUN() Then
                Dim nam As String ', path As String = "HKLM\Software\Microsoft\Windows\CurrentVersion\Run"
                Dim k As RegistryKey = GetRegistryKey("HKLM\Software\Microsoft\Windows\CurrentVersion\Run", nam)
                k.SetValue(IO.Path.GetFileNameWithoutExtension(System.Environment.GetCommandLineArgs()(0)) _
                            , System.Environment.GetCommandLineArgs()(0))

            End If
        End Set
    End Property
    Dim AuRC As String = trans("Да")
    Overloads Property AllowRunCopies() As String
        Get
            Return AuRC
        End Get
        Set(ByVal value As String)
            AuRC = value
            If DaOrNet(AuRC) = False And isRUN() And isDevelop = False Then
                If (UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0) Then
                    MsgBox(trans("Программа уже запущена"), MsgBoxStyle.Exclamation)
                    End
                End If
            End If
        End Set
    End Property
    Dim AllInp As String = trans("Все")
    Overloads Property AllowInput() As String
        Get
            Return AllInp
        End Get
        Set(ByVal value As String)
            AllInp = value
        End Set
    End Property


    ' только для чтения
    Overloads Property Focused() As String
        Get
            Return DaOrNet(obj.Focused)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Property Type() As String
        Get
            Dim myObj = obj.MyObj
            If myObj Is Nothing = False Then
                Return myObj.obj.defaultName
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    ' DPanel
    Dim aScrl1 As String = trans("Нет")
    Overloads Property Scroll1() As String
        Get
            Return aScrl1
        End Get
        Set(ByVal value As String)
            aScrl1 = value
            obj.Panel1.autoScroll = DaOrNet(aScrl1)
        End Set
    End Property
    Dim aScrl2 As String = trans("Нет")
    Overloads Property Scroll2() As String
        Get
            Return aScrl2
        End Get
        Set(ByVal value As String)
            aScrl2 = value
            obj.Panel2.autoScroll = DaOrNet(aScrl2)
        End Set
    End Property
    Dim fxPn As String = trans("Никакой")
    Overloads Property FixedPanel() As String
        Get
            Return fxPn
        End Get
        Set(ByVal value As String)
            fxPn = value
            obj.FixedPanel = FixedPanels.GetByIndex(FixedPanels.IndexOfKey(LCase(fxPn)))
        End Set
    End Property
    Dim orient As String = trans("Вертикальная")
    Overloads Property Orientation() As String
        Get
            Return orient
        End Get
        Set(ByVal value As String)
            orient = value
            obj.Orientation = Orientations.GetByIndex(Orientations.IndexOfKey(LCase(orient)))
        End Set
    End Property
    Dim fxSplit As String = trans("Нет")
    Overloads Property FixedSplitter() As String
        Get
            Return fxSplit
        End Get
        Set(ByVal value As String)
            fxSplit = value
            obj.IsSplitterFixed = DaOrNet(fxSplit)
        End Set
    End Property
    Dim pn1Coll As String = trans("Нет")
    Overloads Property Panel1Collapsed() As String
        Get
            Return pn1Coll
        End Get
        Set(ByVal value As String)
            pn1Coll = value
            obj.Panel1Collapsed = DaOrNet(pn1Coll)
        End Set
    End Property
    Dim pn2Coll As String = trans("Нет")
    Overloads Property Panel2Collapsed() As String
        Get
            Return pn2Coll
        End Get
        Set(ByVal value As String)
            pn2Coll = value
            obj.Panel2Collapsed = DaOrNet(pn2Coll)
        End Set
    End Property
    Dim splWid As Integer = 4
    Overloads Property SplitterWidth() As Integer
        Get
            Return splWid
        End Get
        Set(ByVal value As Integer)
            splWid = value
            obj.SplitterWidth = splWid
        End Set
    End Property
    Dim splDis As Integer = 25
    Overloads Property SplitterDistance() As Integer
        Get
            Return splDis
        End Get
        Set(ByVal value As Integer)
            splDis = value
            obj.SplitterDistance = splDis
        End Set
    End Property
    Dim splInc As Integer = 1
    Overloads Property SplitterIncrement() As Integer
        Get
            Return splInc
        End Get
        Set(ByVal value As Integer)
            splInc = value
            obj.SplitterIncrement = splInc
        End Set
    End Property
    Dim pn1MinS As Integer = 25
    Overloads Property Panel1MinSize() As Integer
        Get
            Return pn1MinS
        End Get
        Set(ByVal value As Integer)
            pn1MinS = value
            obj.Panel1MinSize = pn1MinS
        End Set
    End Property
    Dim pn2MinS As Integer = 25
    Overloads Property Panel2MinSize() As Integer
        Get
            Return pn2MinS
        End Get
        Set(ByVal value As Integer)
            pn2MinS = value
            obj.Panel2MinSize = pn2MinS
        End Set
    End Property

    ' media
    Private ctrWindow As Control
    Public StopedFlag As Boolean = True
    Public Property MediaWindow() As Control
        Get
            Return ctrWindow
        End Get
        Set(ByVal ctrValue As Control)
            ctrWindow = ctrValue
        End Set
    End Property
    Private strFileName As String = trans("Никакой")
    Public Property FileNamePlayed() As String
        Get
            Return GetMinPath(strFileName)
        End Get
        Set(ByVal strValue As String)
            strFileName = GetMaxPath(strValue)
            If isRUN() Then CloseMovie()
        End Set
    End Property
    Dim pld As String = trans("Нет")
    Public Property Played() As String
        Get
            Return pld
        End Get
        Set(ByVal value As String)
            pld = value
        End Set
    End Property
    Private iVolume As Integer = 1000
    Public Property Volume() As Integer
        Get
            Return iVolume
        End Get
        Set(ByVal Value As Integer)
            iVolume = Value
            'mciSendString("SETAUDIO " & strAlias & " VOLUME TO " & iVolume, 0&, 0, IntPtr.Zero)
            Balance = iBalance
        End Set
    End Property
    Private iBalance As Integer = 1000
    Public Property Balance() As Integer
        Get
            Return iBalance
        End Get
        Set(ByVal Value As Integer)
            iBalance = Value
            Dim lb As Integer = iVolume
            Dim rb As Integer = iVolume
            If iBalance < 1000 Then lb = iBalance * (iVolume / 1000)
            If iBalance > 1000 Then rb = (2000 - iBalance) * (iVolume / 1000)
            mciSendString("setaudio " & strAlias & " left volume to " & CStr(rb), vbNullString, 0, IntPtr.Zero)
            mciSendString("setaudio " & strAlias & " right volume to " & CStr(lb), vbNullString, 0, IntPtr.Zero)
        End Set
    End Property
    Private iMute As String = trans("Нет")
    Public Property Mute() As String
        Get
            Return iMute
        End Get
        Set(ByVal Value As String)
            iMute = Value
            Select Case DaOrNet(iMute)
                Case False
                    mciSendString("set " & strAlias & " audio all on", vbNullString, 0, IntPtr.Zero)
                Case True
                    mciSendString("set " & strAlias & " audio all off", vbNullString, 0, IntPtr.Zero)
            End Select
        End Set
    End Property
    Private iSpeed As Integer
    Public Property Speed() As Integer
        Get
            Return iSpeed
        End Get
        Set(ByVal Value As Integer)
            iSpeed = Value
            mciSendString("SET " & strAlias & " SPEED " & iSpeed, 0&, 0, IntPtr.Zero)
        End Set
    End Property
    Public ReadOnly Property TotalPosition() As Integer
        Get
            Dim strTime As String = Space(128)
            mciSendString("SET " & strAlias & " TIME FORMAT MS", 0&, 0, IntPtr.Zero)
            If mciSendString("STATUS " & strAlias & " LENGTH", strTime, Len(strTime), IntPtr.Zero) = 0 Then
                Return CInt(Trim(strTime))
            End If
            Return 0
        End Get
    End Property
    Public ReadOnly Property TotalTime() As String
        Get
            Return ToMyTimeSpan(TotalPosition)
        End Get
    End Property
    Public Property PlayPosition() As Integer
        Get
            Dim strPos As String = Space(128)
            If mciSendString("STATUS " & strAlias & " POSITION", strPos, Len(strPos), IntPtr.Zero) = 0 Then
                Return CInt(Trim(strPos))
            End If
            Return 0
        End Get
        Set(ByVal value As Integer)
            If bPlaying = True Then
                mciSendString("PLAY " & strAlias & " FROM " & value, 0&, 0, IntPtr.Zero)
            Else
                mciSendString("SEEK " & strAlias & " TO " & value, 0&, 0, IntPtr.Zero)
            End If
        End Set
    End Property
    Public Sub PlayInNewHandle(ByVal handle As Control)
        MediaWindow = handle
        bOpened = False
        Dim pp As Integer = PlayPosition
        CloseMovie()
        OpenMovie(strFileName)
        PlayPosition = pp
    End Sub
    Public Property PlayTime() As String
        Get
            Return ToMyTimeSpan(PlayPosition)
        End Get
        Set(ByVal value As String)
            value = FromMyTimeSpan(value).TotalMilliseconds
            PlayPosition = value
        End Set
    End Property
    Public Property OriginalHeight() As String
        Get
            Dim strSize As String = Space(128)

            If mciSendString("WHERE " & strAlias & " source", strSize, Len(strSize), IntPtr.Zero) = 0 Then

                Dim coords() As String = Split(Trim(strSize), " ")
                Dim Size As New Size(CInt(coords(2)), CInt(coords(3)))

                Return Size.Height
            End If
            Return 0
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property OriginalWidth() As String
        Get
            Dim strSize As String = Space(128)

            If mciSendString("WHERE " & strAlias & " source", strSize, Len(strSize), IntPtr.Zero) = 0 Then

                Dim coords() As String = Split(Trim(strSize), " ")
                Dim Size As New Size(CInt(coords(2)), CInt(coords(3)))

                Return Size.Width
            End If
            Return 0
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Private bOpened As Boolean = False
    Public Function OpenMovie(ByVal ParamArray args() As String) As Boolean
        If bOpened = False Then
            If ctrWindow Is Nothing Then ctrWindow = obj
            strAlias = "video1" & (New Random).Next(1, 10000)
            If mciSendString("OPEN """ & args(0) & """ alias " & strAlias & " TYPE MPEGVIDEO PARENT " & ctrWindow.Handle.ToString & " STYLE CHILD", 0&, 0, IntPtr.Zero) <> 0 Then
                Errors.MessangeExclamen(trans("Невозможно открыть/воспроизвести файл") & " """ & args(0) & """. " & _
                trans("Возможно, формат файла не поддерживается и требуется установить кодеки. Либо файл не существует.")) : Exit Function
            End If
            Filename = args(0)
            bOpened = True
        End If
        mciSendString("SET " & strAlias & " TIME FORMAT MS", 0&, 0, IntPtr.Zero)
        Fit()
    End Function
    Public Function CloseMovie() As Boolean
        If bOpened = True And mciSendString("CLOSE " & strAlias, 0&, 0, IntPtr.Zero) = 0 Then
            bOpened = False
        End If
    End Function
    Public bPlaying As Boolean = False
    Public strAlias As String = "video1"
    Dim OnFullS As String = trans("Нет")
    Public Property OnFullScreen() As String
        Get
            Return OnFullS
        End Get
        Set(ByVal value As String)
            OnFullS = value
        End Set
    End Property
    Public Function PlayMovie() As Boolean
        If bOpened = False Then OpenMovie(strFileName)
        If bPlaying = False And mciSendString("PLAY " & strAlias, 0&, 0, IntPtr.Zero) = 0 Then
            bPlaying = True
        End If
        Fit()
        Return bPlaying
    End Function
    Public Function StopMovie() As Boolean
        If bOpened = True And mciSendString("STOP " & strAlias, 0&, 0, IntPtr.Zero) = 0 Then
            mciSendString("SEEK " & strAlias & " TO START", 0&, 0, IntPtr.Zero)
            bPlaying = False
        End If
        Return Not bPlaying
    End Function
    Public Function PauseMovie() As Boolean
        If bPlaying = True And mciSendString("PAUSE " & strAlias, 0&, 0, IntPtr.Zero) = 0 Then
            bPlaying = False
        End If
        Return Not bPlaying
    End Function
    Public Function Fit() As Boolean
        Dim strSize As String = Space(128)
        If ctrWindow Is Nothing Then Exit Function
        If mciSendString("WHERE " & strAlias & " source", strSize, Len(strSize), IntPtr.Zero) = 0 Then

            Dim coords() As String = Split(Trim(strSize), " ")
            Dim Size As New Size(CInt(coords(2)), CInt(coords(3)))

            If Not Size.IsEmpty Then
                Dim dblRatio As Double

                dblRatio = ctrWindow.Width / Size.Width

                If Size.Height * dblRatio > ctrWindow.Height Then
                    dblRatio = ctrWindow.Height / Size.Height
                End If

                Dim iWidth As Integer = CInt(Size.Width * dblRatio)
                Dim iHeight As Integer = CInt(Size.Height * dblRatio)
                Dim iLeft As Integer = CInt((ctrWindow.Width - iWidth) / 2)
                Dim iTop As Integer = CInt((ctrWindow.Height - iHeight) / 2)

                Return (mciSendString("PUT " & strAlias & " WINDOW AT " & CStr(iLeft) & " " & CStr(iTop) & " " & CStr(iWidth) & " " & CStr(iHeight), 0&, 0, IntPtr.Zero) = 0)
            Else
                Return False
            End If

        End If

    End Function

    ' TextBoks
    Overloads Property HideSelection() As String
        Get
            Return DaOrNet(obj.HideSelection)
        End Get
        Set(ByVal value As String)
            obj.HideSelection = DaOrNet(value)
        End Set
    End Property
    Overloads Property WordWrap() As String
        Get
            Return DaOrNet(obj.WordWrap)
        End Get
        Set(ByVal value As String)
            obj.WordWrap = DaOrNet(value)
        End Set
    End Property
    Dim maxLen As Integer = 32767
    Overloads Property MaximumLength() As Integer
        Get
            Return maxLen
        End Get
        Set(ByVal value As Integer)
            maxLen = value
            obj.MaxLength = maxLen
        End Set
    End Property
    Dim MuLine As String = trans("Нет")
    Overloads Property MultiLine() As String
        Get
            Return MuLine
        End Get
        Set(ByVal value As String)
            MuLine = value
            obj.MultiLine = DaOrNet(MuLine)
        End Set
    End Property
    Dim passCh As String = ""
    Overloads Property PasswordChar() As String
        Get
            Return passCh
        End Get
        Set(ByVal value As String)
            passCh = value
            obj.PasswordChar = passCh
        End Set
    End Property
    Dim rOnly As String = trans("Нет")
    Overloads Property [ReadOnly]() As String
        Get
            Return rOnly
        End Get
        Set(ByVal value As String)
            rOnly = value
            obj.ReadOnly = DaOrNet(rOnly)
        End Set
    End Property
    Dim scrlBars As String = trans("Нет")
    Overloads Property ScrollBars() As String
        Get
            Return scrlBars
        End Get
        Set(ByVal value As String)
            scrlBars = value
            obj.ScrollBars = ScrollBarz.GetByIndex(ScrollBarz.IndexOfKey(LCase(scrlBars)))
        End Set
    End Property
    Overloads Property SelectedText() As String
        Get
            Return obj.SelectedText
        End Get
        Set(ByVal value As String)
            obj.SelectedText = value
        End Set
    End Property
    Overloads Property SelectionStart() As String
        Get
            Return obj.SelectionStart + 1
        End Get
        Set(ByVal value As String)
            If value = 0 Then value = 1
            obj.SelectionStart = value - 1
        End Set
    End Property
    Overloads Property SelectionLength() As String
        Get
            Return obj.SelectionLength
        End Get
        Set(ByVal value As String)
            obj.SelectionLength = value
        End Set
    End Property
    Overloads Property GetCharIndexFromPosition(ByVal ParamArray args() As String) As String
        Get
            Return obj.GetCharIndexFromPosition(New Point(args(0), args(1))) + 1
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property GetFirstCharIndexFromLine(ByVal ParamArray args() As String) As String
        Get
            If obj.lines.Length <= args(0) - 1 Then Return "" Else Return obj.GetFirstCharIndexFromLine(args(0) - 1) + 1
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property GetFirstCharIndexOfCurrentLine() As String
        Get
            Return obj.GetFirstCharIndexOfCurrentLine() + 1
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property GetLineFromCharIndex(ByVal ParamArray args() As String) As String
        Get
            If obj.text.Length <= args(0) - 1 Then Return "" Else Return obj.GetLineFromCharIndex(args(0) - 1) + 1
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property GetXFromCharIndex(ByVal ParamArray args() As String) As String
        Get
            If obj.text.Length <= args(0) - 1 Then Return "" Else Return obj.GetPositionFromCharIndex(args(0) - 1).X
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property GetYFromCharIndex(ByVal ParamArray args() As String) As String
        Get
            If obj.text.Length <= args(0) - 1 Then Return "" Else Return obj.GetPositionFromCharIndex(args(0) - 1).Y
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property Line(ByVal ParamArray args() As String) As String
        Get
            If obj.Lines.Length <= args(0) - 1 Then Return "" Else Return obj.Lines(args(0) - 1)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property LinesCount() As String
        Get
            Return obj.Lines.Length
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property Chars(ByVal ParamArray args() As String) As String
        Get
            If obj.text.Length <= args(0) - 1 Then Return "" Else Return obj.Text.Chars(args(0) - 1)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property CharsLength() As String
        Get
            Return obj.Text.Length
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    ' WebBrowser
    Dim allowNav As String = trans("Да")
    Overloads Property AllowNavigation() As String
        Get
            Return allowNav
        End Get
        Set(ByVal value As String)
            allowNav = value
            obj.AllowNavigation = DaOrNet(allowNav)
        End Set
    End Property
    Dim allowDrop As String = trans("Да")
    Overloads Property AllowWebBrowserDrop() As String
        Get
            Return allowDrop
        End Get
        Set(ByVal value As String)
            allowDrop = value
            obj.AllowWebBrowserDrop = DaOrNet(allowDrop)
        End Set
    End Property
    Overloads Property CanGoBack() As String
        Get
            Return DaOrNet(obj.CanGoBack)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property CanGoForward() As String
        Get
            Return DaOrNet(obj.CanGoForward)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property DocumentText() As String
        Get
            Return obj.DocumentText
        End Get
        Set(ByVal value As String)
            obj.DocumentText = value
        End Set
    End Property
    Overloads Property DocumentTitle() As String
        Get
            Return obj.DocumentTitle
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property DocumentType() As String
        Get
            Return obj.DocumentType
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property isBusy() As String
        Get
            Return DaOrNet(obj.isBusy)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property isOffline() As String
        Get
            Return DaOrNet(obj.IsOffline)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Dim cmBrowser As String = trans("Да")
    Overloads Property isWebBrowserContextMunuEnabled() As String
        Get
            Return cmBrowser
        End Get
        Set(ByVal value As String)
            cmBrowser = value
            obj.IsWebBrowserContextMenuEnabled = DaOrNet(cmBrowser)
        End Set
    End Property
    Overloads Property ReadyState() As String
        Get
            Return ReadyStates.GetKey(ReadyStates.IndexOfValue(obj.ReadyState))
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property StatusText() As String
        Get
            Try
                Return obj.StatusText
            Catch ex As Exception
                Return ""
            End Try
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Dim scrpErrs As String = trans("Нет")
    Overloads Property ScriptErrorsSuppressed() As String
        Get
            Return scrpErrs
        End Get
        Set(ByVal value As String)
            scrpErrs = value
            obj.ScriptErrorsSuppressed = Not (DaOrNet(scrpErrs))
        End Set
    End Property
    Dim scrBarsEn As String = trans("Да")
    Overloads Property ScrollBarsEnabled() As String
        Get
            Return scrBarsEn
        End Get
        Set(ByVal value As String)
            scrBarsEn = value
            obj.ScrollBarsEnabled = DaOrNet(scrBarsEn)
        End Set
    End Property
    Dim ur As String = ""
    Overloads Property Url() As String
        Get
            Return GetMinPath(ur)
        End Get
        Set(ByVal value As String)
            ur = GetMaxPath(value)
        End Set
    End Property
    Dim ShCutEn As String = trans("Да")
    Overloads Property WebBrowserShortcutsEnabled() As String
        Get
            Return ShCutEn
        End Get
        Set(ByVal value As String)
            ShCutEn = value
            obj.WebBrowserShortcutsEnabled = DaOrNet(ShCutEn)
        End Set
    End Property
    Dim docEnc As String = trans("cyrillic (windows)")
    Overloads Property DocumentEncoding() As String
        Get
            If obj.Document Is Nothing Or isRUN() = False Then Return docEnc
            If DocumentEncodings.IndexOfValue(LCase(obj.Document.Encoding)) = -1 Then Return obj.Document.Encoding
            Return DocumentEncodings.GetKey(DocumentEncodings.IndexOfValue(LCase(obj.Document.Encoding)))
        End Get
        Set(ByVal value As String)
            docEnc = value
            If obj.Document Is Nothing Or isRUN() = False Then Exit Property
            If DocumentEncodings.IndexOfKey(LCase(value)) = -1 Then
                Try
                    obj.Document.Encoding = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeCritic(Errors.notCollection(trans("Кодировка"), value, HWDocumentEncodings))
                End Try
                obj.Refresh(WebBrowserRefreshOption.IfExpired)
                Exit Property
            End If
            obj.Document.Encoding = DocumentEncodings.GetByIndex(DocumentEncodings.IndexOfKey(LCase(docEnc)))
            obj.Refresh(WebBrowserRefreshOption.IfExpired)
        End Set
    End Property
    Overloads Property EncodingDefault() As String
        Get
            '   If isRUN() = False Then Return "cyrillic (windows)"
            If obj.Document Is Nothing Then Return ""
            If DocumentEncodings.IndexOfValue(LCase(obj.Document.DefaultEncoding)) = -1 Then Return obj.Document.DefaultEncoding
            Return DocumentEncodings.GetKey(DocumentEncodings.IndexOfValue(LCase(obj.Document.DefaultEncoding)))
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property Cookie() As String
        Get
            If obj.Document Is Nothing Then Return ""
            Return obj.Document.Cookie
        End Get
        Set(ByVal value As String)
            If obj.Document Is Nothing Then Exit Property
            obj.Document.Cookie = value
        End Set
    End Property
    Sub NavigateNewPage(ByVal ParamArray args() As String)
        Dim ur As Uri = GetUrlFromString(args(0))
        If ur Is Nothing = False Then obj.Navigate(ur, True)
    End Sub
    Sub NavigateInFrame(ByVal ParamArray args() As String)
        Dim ur As Uri = GetUrlFromString(args(0))
        If ur Is Nothing = False Then obj.Navigate(ur, args(1))
    End Sub
    Sub RefreshPage(ByVal ParamArray args() As String)
        obj.Refresh(Refreshs.GetByIndex(Refreshs.IndexOfKey(LCase(args(0)))))
    End Sub
    Dim newWin As String = trans("В данном браузере")
    Overloads Property OpenNewWindowLink() As String
        Get
            Return newWin
        End Get
        Set(ByVal value As String)
            newWin = value
        End Set
    End Property


    ' Form
    Dim CnBox As String = trans("Да")
    Overloads Property ControlBox() As String
        Get
            Return CnBox
        End Get
        Set(ByVal value As String)
            CnBox = value
        End Set
    End Property
    Dim FrStyle As String = trans("Нормальный")
    Overloads Property FormBorderStyle() As String
        Get
            Return FrStyle
        End Get
        Set(ByVal value As String)
            FrStyle = value
        End Set
    End Property
    Dim MM As String = trans("Никакой")
    Overloads Property MainMenuStrip() As String
        Get
            Return MM
        End Get
        Set(ByVal value As String)
            MM = value
        End Set
    End Property
    Private opac As Integer = 100
    Public Property Opacity() As Integer
        Get
            Return opac
        End Get
        Set(ByVal Value As Integer)
            opac = Value
        End Set
    End Property
    Dim ShIc As String = trans("Да")
    Overloads Property ShowIcon() As String
        Get
            Return ShIc
        End Get
        Set(ByVal value As String)
            ShIc = value
        End Set
    End Property
    Dim ShTB As String = trans("Да")
    Overloads Property ShowInTaskbar() As String
        Get
            Return ShTB
        End Get
        Set(ByVal value As String)
            ShTB = value
        End Set
    End Property
    Dim StPos As String = trans("Заданная координатами")
    Overloads Property StartPosition() As String
        Get
            Return StPos
        End Get
        Set(ByVal value As String)
            StPos = value
        End Set
    End Property
    Dim TMst As String = trans("Нет")
    Overloads Property TopMost() As String
        Get
            Return TMst
        End Get
        Set(ByVal value As String)
            TMst = value
        End Set
    End Property
    Dim WiStat As String = trans("Нормальный")
    Overloads Property WindowState() As String
        Get
            Return WiStat
        End Get
        Set(ByVal value As String)
            WiStat = value
        End Set
    End Property
    Private AutScrMinW As Integer = 0
    Public Property AutoScrollMinSizeWidth() As Integer
        Get
            Return AutScrMinW
        End Get
        Set(ByVal Value As Integer)
            AutScrMinW = Value
            obj.AutoScrollMinSize = New Size(AutScrMinW, AutScrMinH)
        End Set
    End Property
    Private AutScrMinH As Integer = 0
    Public Property AutoScrollMinSizeHeight() As Integer
        Get
            Return AutScrMinH
        End Get
        Set(ByVal Value As Integer)
            AutScrMinH = Value
            obj.AutoScrollMinSize = New Size(AutScrMinW, AutScrMinH)
        End Set
    End Property
    Private AutScrPosX As Integer = 0
    Public Property AutoScrollPositionX() As Integer
        Get
            Return obj.AutoScrollPosition.X
        End Get
        Set(ByVal Value As Integer)
            AutScrPosX = Value
            obj.AutoScrollPosition = New Point(AutScrPosX, AutScrPosY)
        End Set
    End Property
    Public Property CaptionHeight() As Integer
        Get
            If isRUN() = False Then
                Try
                    Return WindowsApplication1.MainForm.Height - WindowsApplication1.MainForm.ClientSize.Height
                Catch ex As Exception
                End Try
            End If
            Return obj.Height - obj.ClientSize.Height
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property
    Public Property CaptionWidth() As Integer
        Get
            If isRUN() = False Then
                Try
                    Return WindowsApplication1.MainForm.Width - WindowsApplication1.MainForm.ClientSize.Width
                Catch ex As Exception
                End Try
            End If
            Return obj.Width - obj.ClientSize.Width
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property
    Private AutScrPosY As Integer = 0
    Public Property AutoScrollPositionY() As Integer
        Get
            Return obj.AutoScrollPosition.Y
        End Get
        Set(ByVal Value As Integer)
            AutScrPosY = Value
            obj.AutoScrollPosition = New Point(AutScrPosX, AutScrPosY)
        End Set
    End Property
    Dim Icn As String = trans("Никакой")
    Overloads Property Icon() As String
        Get
            Return GetMinPath(Icn)
        End Get
        Set(ByVal value As String)
            Icn = GetMaxPath(value)
        End Set
    End Property
    Dim TrCol As String = trans("Никакой")
    Overloads Property TransparentcyKey() As String
        Get
            Return TrCol
        End Get
        Set(ByVal value As String)
            TrCol = value
        End Set
    End Property

    ' DataGrid
    Dim AUtAR As String = trans("Да")
    Overloads Property AllowUserToAddRows() As String
        Get
            Return AUtAR
        End Get
        Set(ByVal value As String)
            AUtAR = value
            obj.AllowUserToAddRows = DaOrNet(AUtAR)
        End Set
    End Property
    Dim AUtDR As String = trans("Да")
    Overloads Property AllowUserToDeleteRows() As String
        Get
            Return AUtDR
        End Get
        Set(ByVal value As String)
            AUtDR = value
            obj.AllowUserToDeleteRows = DaOrNet(AUtDR)
        End Set
    End Property
    Dim AUtOC As String = trans("Нет")
    Overloads Property AllowUserToOrderColumns() As String
        Get
            Return AUtOC
        End Get
        Set(ByVal value As String)
            AUtOC = value
            obj.AllowUserToOrderColumns = DaOrNet(AUtOC)
        End Set
    End Property
    Dim AUtRC As String = trans("Да")
    Overloads Property AllowUserToResizeColumns() As String
        Get
            Return AUtRC
        End Get
        Set(ByVal value As String)
            AUtRC = value
            obj.AllowUserToResizeColumns = DaOrNet(AUtRC)
        End Set
    End Property
    Dim AUtRR As String = trans("Да")
    Overloads Property AllowUserToResizeRows() As String
        Get
            Return AUtRR
        End Get
        Set(ByVal value As String)
            AUtRR = value
            obj.AllowUserToResizeRows = DaOrNet(AUtRR)
        End Set
    End Property
    Dim cBorSt As String = trans("Обычный")
    Overloads Property CellBorderStyle() As String
        Get
            Return cBorSt
        End Get
        Set(ByVal value As String)
            cBorSt = value
            obj.CellBorderStyle = CellBorderStyles.GetByIndex(CellBorderStyles.IndexOfKey(LCase(cBorSt)))
        End Set
    End Property
    Dim HeadVis As String = trans("Да")
    Overloads Property ColumnHeadersVisible() As String
        Get
            Return HeadVis
        End Get
        Set(ByVal value As String)
            HeadVis = value
            obj.ColumnHeadersVisible = DaOrNet(HeadVis)
        End Set
    End Property
    Overloads Property RowHeadersVisible() As String
        Get
            Return DaOrNet(obj.RowHeadersVisible)
        End Get
        Set(ByVal value As String)
            obj.RowHeadersVisible = DaOrNet(value)
        End Set
    End Property
    Public Property ColumnHeadersHeight() As Integer
        Get
            Return obj.ColumnHeadersHeight
        End Get
        Set(ByVal Value As Integer)
            obj.ColumnHeadersHeight = Value
        End Set
    End Property
    Overloads Property Columns() As String
        Get
            Dim cl As DataGridViewColumn = obj.Columns.GetFirstColumn(DataGridViewElementStates.None)
            Dim cols As String = ""
            ' компоновка строки колонок
            While cl Is Nothing = False
                cols &= ", """ & CreateKovich(cl.HeaderText) & """"
                cl = obj.Columns.GetNextColumn(cl, DataGridViewElementStates.None, DataGridViewElementStates.None)
            End While
            If cols <> "" Then cols = cols.Substring(2)
            Return cols
        End Get
        Set(ByVal value As String)
            Dim cl As DataGridViewColumn = obj.Columns.GetFirstColumn(DataGridViewElementStates.None)
            Dim cols As New CodeString(value, "None", False)
            Dim mSpl As MySplitStruct = cols.Split("naOdnomUrovne", ",")
            Dim j As Integer
            If obj.DataSource IsNot Nothing Then obj.DataSource = Nothing
            ' разбор строки с колонками и создание по ней колонок
            If mSpl.texty(0) <> "" Then
                For j = 0 To mSpl.texty.Length - 1
                    mSpl.texty(j) = UbratKovich(mSpl.texty(j)).str
                    If j < obj.Columns.Count Then
                        obj.Columns(j).HeaderText = mSpl.texty(j)
                    Else
                        obj.Columns.Add(mSpl.texty(j), mSpl.texty(j))
                    End If
                Next
            End If
            ' Уделение колонок, если их количество больше чем пришло в строке
            Dim k As Integer = j
            For k = obj.Columns.Count - 1 To j Step -1
                obj.Columns.RemoveAt(k)
            Next
        End Set
    End Property
    Overloads Property Rows() As String
        Get
            Dim rw As Integer = obj.Rows.GetFirstRow(DataGridViewElementStates.None)
            Dim rws As String = "", j As Integer
            While rw <> -1
                Dim row As String = ""
                If obj.Rows(rw).IsNewRow Then Exit While ' если дошли до последней строки добавления новой записи
                Dim cels As DataGridViewCellCollection = obj.Rows(rw).Cells
                ' занесение в строку ячеек
                For j = 0 To cels.Count - 1
                    Dim cel As Object = cels(j).Value
                    If cels(j).Value Is DBNull.Value Then cel = ""
                    row &= " | """ & CreateKovich(cel) & """"
                Next
                If row <> "" Then row = row.Substring(3)
                ' занесении в строку строчку таблицы
                rws &= ", " & row
                rw = obj.Rows.GetNextRow(rw, DataGridViewElementStates.None)
            End While
            If rws <> "" Then rws = rws.Substring(2)
            Return rws
        End Get
        Set(ByVal value As String)
            Dim rws As New CodeString(value, "None", False)
            Dim mSpl As MySplitStruct = rws.Split("naOdnomUrovne", ",")
            Dim j As Integer
            ' разбор строки с колонками и создание по ней колонок
            If obj.DataSource IsNot Nothing Then obj.DataSource = Nothing
            obj.Rows.Clear()
            Dim dataRows() As DataGridViewRow = Nothing
            For j = 0 To mSpl.texty.Length - 1
                If mSpl.texty(j) <> "" Then
                    ReDims(dataRows)
                    ' создание в dataRows структуры ячеек как в таблице
                    dataRows(dataRows.Length - 1) = New DataGridViewRow : dataRows(dataRows.Length - 1).CreateCells(obj)
                    ' Разбиение строки на ячейки
                    Dim row As New CodeString(mSpl.texty(j), False, False)
                    Dim mSpl2 As MySplitStruct = row.Split("naOdnomUrovne", "|")
                    Dim k As Integer
                    If mSpl2.texty(0) <> "" Then
                        ' Занесение значения ячеек в ячейки dataRows
                        For k = 0 To mSpl2.texty.Length - 1
                            mSpl2.texty(k) = UbratKovich(mSpl2.texty(k)).str
                            If k < dataRows(dataRows.Length - 1).Cells.Count Then
                                dataRows(dataRows.Length - 1).Cells(k).Value = mSpl2.texty(k)
                            End If
                        Next
                    End If
                End If
            Next
            ' Занесение полученных строк в таблицу
            If dataRows Is Nothing = False Then obj.Rows.AddRange(dataRows)
        End Set
    End Property
    Dim CSBkColor As String = "255;255;255;"
    Overloads Property DefaultCellStyleBackColor() As String
        Get
            Return CSBkColor
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.DefaultCellStyle.BackColor = Color.Transparent
                    CSBkColor = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                CSBkColor = value
                obj.DefaultCellStyle.BackColor = FromMyColor(CSBkColor)
            End If
        End Set
    End Property
    Dim CSSBkColor As String = ToMyColor(SystemColors.Highlight)
    Overloads Property DefaultCellStyleSelectionBackColor() As String
        Get
            Return CSSBkColor
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.DefaultCellStyle.SelectionBackColor = Color.Transparent
                    CSSBkColor = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                CSSBkColor = value
                obj.DefaultCellStyle.SelectionBackColor = FromMyColor(CSSBkColor)
            End If
        End Set
    End Property
    Dim CSFrColor As String = ToMyColor(SystemColors.ControlText)
    Overloads Property DefaultCellStyleForeColor() As String
        Get
            Return CSFrColor
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.DefaultCellStyle.ForeColor = Color.Transparent
                    CSFrColor = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                CSFrColor = value
                obj.DefaultCellStyle.ForeColor = FromMyColor(CSFrColor)
            End If
        End Set
    End Property
    Dim CSSFrColor As String = ToMyColor(SystemColors.HighlightText)
    Overloads Property DefaultCellStyleSelectionForeColor() As String
        Get
            Return CSSFrColor
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.DefaultCellStyle.SelectionForeColor = Color.Transparent
                    CSSFrColor = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                CSSFrColor = value
                obj.DefaultCellStyle.SelectionForeColor = FromMyColor(CSSFrColor)
            End If
        End Set
    End Property
    Dim EdMd As String = trans("Обычный")
    Overloads Property EditMode() As String
        Get
            Return EdMd
        End Get
        Set(ByVal value As String)
            EdMd = value
            obj.EditMode = EditModes.GetByIndex(EditModes.IndexOfKey(LCase(EdMd)))
        End Set
    End Property
    Dim GrCol As String = ToMyColor(SystemColors.ControlDark)
    Overloads Property GridColor() As String
        Get
            Return GrCol
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.GridColor = Color.Transparent
                    GrCol = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                GrCol = value
                obj.GridColor = FromMyColor(GrCol)
            End If
        End Set
    End Property
    Dim MultSel As String = trans("Да")
    Overloads Property MultiSelect() As String
        Get
            Return MultSel
        End Get
        Set(ByVal value As String)
            MultSel = value
            obj.MultiSelect = DaOrNet(MultSel)
        End Set
    End Property
    Dim RdOlTb As String = trans("Нет")
    Overloads Property ReadOnlyTable() As String
        Get
            Return RdOlTb
        End Get
        Set(ByVal value As String)
            RdOlTb = value
        End Set
    End Property
    Dim SelMode As String = trans("Ячейки и строки")
    Overloads Property SelectionMode() As String
        Get
            Return SelMode
        End Get
        Set(ByVal value As String)
            SelMode = value
            obj.SelectionMode = SelectionModes.GetByIndex(SelectionModes.IndexOfKey(LCase(SelMode)))
        End Set
    End Property
    Public selRows As String = "0"
    Public semaforSelect As Boolean = False
    Overloads Property SelectedRows() As String
        Get
            If obj.SelectedCells.Count = 0 Then Return ""
            Dim rws() As String, j As Integer
            ' Создание массива строк
            For j = 0 To obj.SelectedCells.Count - 1
                If rws Is Nothing Then
                    ReDims(rws) : rws(rws.Length - 1) = obj.SelectedCells(j).RowIndex
                ElseIf Array.IndexOf(rws, obj.SelectedCells(j).RowIndex.ToString) = -1 Then
                    ReDims(rws) : rws(rws.Length - 1) = obj.SelectedCells(j).RowIndex
                End If
            Next
            ' вывод результата
            If rws Is Nothing Then Return ""
            rws.Sort(rws)
            Return Join(rws, ",")
        End Get
        Set(ByVal value As String)
            value = UbratKovich(value).str
            selRows = value
            semaforSelect = True
            While obj.SelectedCells.Count > 0
                obj.SelectedCells(0).Selected = False
            End While
            Dim nRows() As String = value.Split(","), j As Integer
            ' если снимают выделения
            'If nRows(0) = "" Then
            '    For j = 0 To obj.SelectedRows.Count - 1
            '        obj.Rows(j).Selected = False
            '    Next
            'End If
            '' Выделить строки nRows
            For j = 0 To nRows.Length - 1
                If Iz.isInteger(nRows(j)) = False Or nRows(j) = "" Then Continue For
                If nRows(j) < obj.Rows.Count Then

                    ' А теперь столбцы
                    ' Dim k As Integer
                    ' For k = 0 To obj.Columns.Count - 1
                    Dim nCols() As String = selCol.Split(","), p As Integer
                    ' если снимают выделения
                    'If nCols(0) = "" Then
                    '    For p = 0 To obj.SelectedColumns.Count - 1
                    '        obj.Columns(p).Selected = False
                    '    Next
                    'End If
                    ' Выделить столбцы nCols
                    For p = 0 To nCols.Length - 1
                        If Iz.isInteger(nCols(p)) = False Or nCols(p) = "" Then Continue For
                        If nCols(p) < obj.Columns.Count Then
                            obj.Rows(nRows(j)).Cells(Convert.ToInt16(nCols(p))).Selected = True
                        End If
                    Next
                    ' Next

                    ' obj.Rows(nRows(j)).Selected = True
                End If
            Next
            semaforSelect = False
        End Set
    End Property
    Public selCol As String = "0"
    Overloads Property SelectedColumns() As String
        Get
            If obj.SelectedCells.Count = 0 Then Return ""
            Dim clns() As String, j As Integer
            ' Создание массива строк
            For j = 0 To obj.SelectedCells.Count - 1
                If clns Is Nothing Then
                    ReDims(clns) : clns(clns.Length - 1) = obj.SelectedCells(j).ColumnIndex
                ElseIf Array.IndexOf(clns, obj.SelectedCells(j).ColumnIndex.ToString) = -1 Then
                    ReDims(clns) : clns(clns.Length - 1) = obj.SelectedCells(j).ColumnIndex
                End If
            Next
            ' вывод результата
            If clns Is Nothing Then Return ""
            clns.Sort(clns)
            Return Join(clns, ",")
        End Get
        Set(ByVal value As String)
            selCol = value
            SelectedRows = selRows
        End Set
    End Property
    Function getCells(ByVal rows As String, ByVal cols As String) As DataGridViewCell()
        Dim i, j As Integer, Cells() As DataGridViewCell = Nothing
        If Trim(rows) = "" Or Trim(cols) = "" Then Return Nothing

        ' Если хотят взять ячейки из всех строк, то записать в rows все строки через запятую
        If UCase(Trim(rows)) = UCase(trans("Все")) Then
            rows = ""
            Dim rr(obj.Rows.Count - 1) As String
            For i = 0 To obj.Rows.Count - 1
                If obj.Rows(i).IsNewRow Then Continue For
                rr(i) &= i
            Next
            ReDim Preserve rr(i)
            rows = Join(rr, ",")
        End If
        ' Если хотят взять ячейки из всех столбцов, то записать в cols все столбцы через запятую
        If Trim(cols) = "" Or UCase(Trim(cols)) = UCase(trans("Все")) Then
            cols = ""
            For i = 0 To obj.Columns.Count - 1
                If i > 0 Then cols &= ","
                cols &= i
            Next
        End If

        ' Взять все ячейки, описанные в rows и cols
        Dim splR() As String = rows.Split(","), splC() As String = cols.Split(",")
        For i = 0 To splR.Length - 1
            splR(i) = Trim(splR(i))
            ' если номер строки указан верно
            If Iz.isInteger(splR(i)) And splR(i) < obj.rows.count Then
                ' если это новая пустая строка, то она не в счет
                If obj.Rows(splR(i)).IsNewRow Then Continue For

                For j = 0 To splC.Length - 1
                    splC(j) = Trim(splC(j))
                    ' если номер строки указан верно
                    If Iz.isInteger(splC(j)) And splC(j) < obj.columns.count Then
                        ReDims(Cells) : Cells(Cells.Length - 1) = obj.Rows(splR(i)).Cells(Convert.ToInt16(splC(j)))
                    End If
                Next

            End If
        Next
        Return Cells
    End Function
    Overloads Property ItemValue(ByVal ParamArray args() As String) As String
        Get
            args(0) = UbratKovich(args(0)).str : args(1) = UbratKovich(args(1)).str
            Dim splR As String = Trim(args(0).Split(",")(0))
            Dim splC As String = Trim(args(1).Split(",")(0))
            If Iz.isInteger(splC) And splC < obj.columns.count Then
                If Iz.isInteger(splR) And splR < obj.rows.count Then
                    If obj.Rows(splR).IsNewRow = False Then
                        Try
                            Return obj.Rows(splR).Cells(Convert.ToInt16(splC)).Value
                        Catch ex As Exception
                            Return ""
                        End Try
                    End If
                End If
            End If
        End Get
        Set(ByVal value As String)
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(args(0), args(1))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                cells(i).Value = value
            Next
        End Set
    End Property
    Overloads Property ItemSelected(ByVal ParamArray args() As String) As String
        Get
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(args(0), args(1))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                If cells(i).Selected = False Then Return DaOrNet(False)
            Next
            Return DaOrNet(True)
        End Get
        Set(ByVal value As String)
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(args(0), args(1))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                cells(i).Selected = DaOrNet(value)
            Next
        End Set
    End Property
    Overloads Property RowsReadOnly(ByVal ParamArray args() As String) As String
        Get
            'return obj.Rows(args(0)).ReadOnly 
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(args(0), trans("Все"))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                If cells(i).ReadOnly = False Then Return DaOrNet(False)
            Next
            Return DaOrNet(True)
        End Get
        Set(ByVal value As String)
            ' obj.Rows(args(0)).ReadOnly = DaOrNet(value)
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(args(0), trans("Все"))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                cells(i).ReadOnly = DaOrNet(value)
                obj.Rows(cells(i).RowIndex).ReadOnly = DaOrNet(value)
            Next
        End Set
    End Property
    Overloads Property ColumnReadOnly(ByVal ParamArray args() As String) As String
        Get
            'Return obj.Columns(Convert.ToInt16(args(0))).ReadOnly
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(trans("Все"), args(0))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                If cells(i).ReadOnly = False Then Return DaOrNet(False)
            Next
            Return DaOrNet(True)
        End Get
        Set(ByVal value As String)
            'obj.Columns(Convert.ToInt16(args(0))).ReadOnly = DaOrNet(value)
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(trans("Все"), args(0))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                cells(i).ReadOnly = DaOrNet(value)
                obj.Columns(cells(i).ColumnIndex).ReadOnly = DaOrNet(value)
            Next
        End Set
    End Property
    Overloads Property ItemReadOnly(ByVal ParamArray args() As String) As String
        Get
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(args(0), args(1))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                If cells(i).ReadOnly = False Then Return DaOrNet(False)
            Next
            Return DaOrNet(True)
        End Get
        Set(ByVal value As String)
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(args(0), args(1))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                cells(i).ReadOnly = DaOrNet(value)
            Next
        End Set
    End Property
    Overloads Property ColumnsWidth(ByVal ParamArray args() As String) As String
        Get
            args(0) = UbratKovich(args(0)).str
            Return obj.Columns(Convert.ToInt16(Trim(args(0).Split(",")(0)))).Width
        End Get
        Set(ByVal value As String)
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(0, args(0))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                obj.Columns(Convert.ToInt16(cells(i).ColumnIndex)).Width = value
            Next
        End Set
    End Property
    Overloads Property RowsHeight(ByVal ParamArray args() As String) As String
        Get
            args(0) = UbratKovich(args(0)).str
            Return obj.Rows(Convert.ToInt16(Trim(args(0).Split(",")(0)))).Height
        End Get
        Set(ByVal value As String)
            ' Получить все ячейки
            Dim cells() As DataGridViewCell = getCells(0, args(0))
            If cells Is Nothing Then Exit Property
            ' Произвести над ячейками нужные действия
            Dim i As Integer
            For i = 0 To cells.Length - 1
                obj.Rows(Convert.ToInt16(cells(i).ColumnIndex)).Height = value
            Next
        End Set
    End Property
    Overloads Property RowsCount() As String
        Get
            Return obj.Rows.Count
        End Get
        Set(ByVal value As String)
            Dim i As Integer, str As String = ""
            If value < obj.Rows.Count Then
                For i = value To obj.Rows.Count - 1
                    str &= i : If i < obj.Rows.Count - 1 Then str &= ","
                Next
                RowsRemove(str)
            ElseIf value > obj.Rows.Count Then
                For i = obj.Rows.Count To value - 1
                    RowsAdd("")
                Next
            End If
        End Set
    End Property
    Overloads Property ColumnsCount() As String
        Get
            Return obj.Columns.Count
        End Get
        Set(ByVal value As String)
            Dim i As Integer, str As String = ""
            If value < obj.Columns.Count Then
                For i = value To obj.Columns.Count - 1
                    str &= i : If i < obj.Columns.Count - 1 Then str &= ","
                Next
                ColumnsRemove(str)
            ElseIf value > obj.Columns.Count Then
                For i = obj.Columns.Count To value - 1
                    ColumnsAdd(New String() {"", ""})
                Next
            End If
        End Set
    End Property
    Sub copyContentRows(ByVal eInd As Integer, ByVal bInd As Integer, ByVal count As Integer)
        Dim i, j As Integer
        ' В случает если хотять вставить новые строки внутри тех которые и хотят копировать
        ' разбить задачу на две подзадачи копирования сначала всего снизу, потом всего сверху
        If eInd > bInd And eInd < bInd + count Then
            copyContentRows(eInd, bInd, eInd - bInd)
            copyContentRows(eInd + (eInd - bInd), eInd + count, (bInd + count) - eInd)
            Exit Sub
        End If
        ' перенос данных из строк с bInd в строки eInd
        For i = eInd To eInd + count - 1
            For j = 0 To obj.Rows(i).cells.count - 1
                obj.Rows(i).cells(j).value = obj.Rows(bInd + (i - eInd)).cells(j).value
            Next
        Next
    End Sub
    Function getVals(ByVal ParamArray args() As String) As String
        Dim vals As String = "", i As Integer
        For i = 0 To args.Length - 1
            vals &= "'" & args(i) & "'"
            If i < args.Length - 1 Then vals &= ","
        Next
        Return vals
    End Function
    Function getVals(ByVal args As DataGridViewCellCollection) As String
        Dim vals As String = "", i As Integer
        For i = 0 To args.Count - 1
            vals &= "'" & args(i).Value & "'"
            If i < args.Count - 1 Then vals &= ","
        Next
        Return vals
    End Function
    Function isDBconnect() As Boolean
        If dbName <> "" And tablName <> "" And lastSelect <> "" Then Return True Else Return False
    End Function
    Sub RowsAdd(ByVal ParamArray args() As String)
        ' Если таблица связана с данными то вставлять строку надо по бд-шному
        If isDBconnect() Then
            Dim vals As String = "", i As Integer
            Dim selrows As String = SelectedRows
            For i = 0 To args.Length - 1
                vals &= "'" & args(i) & "'"
                If i < args.Length - 1 Then vals &= ","
            Next
            SQLqueryInto(typeName, dbName, "INSERT INTO " & tablName & " VALUES(" & getVals(args) & ")")
            SQLquerySelect(typeName, dbName, lastSelect)
            SelectedRows = selrows
        Else
            ' Таблица не связанная с данными
            obj.Rows.Add(args)
        End If
    End Sub
    Sub ColumnsAdd(ByVal ParamArray args() As String)
        obj.Columns.Add(args(0), args(1))
    End Sub
    Sub RowsAddCopies(ByVal ParamArray args() As String)
        ' Если таблица связана с данными то вставлять строку надо по бд-шному
        If isDBconnect() Then
            Dim i As Integer
            Dim selrows As String = SelectedRows
            For i = args(0) To Int(args(0)) + args(1) - 1
                SQLqueryInto(typeName, dbName, "INSERT INTO " & tablName & " VALUES(" & getVals(obj.rows(i).cells) & ")")
            Next
            SQLquerySelect(typeName, dbName, lastSelect)
            SelectedRows = selrows
        Else
            ' Таблица не связанная с данными
            Dim eInd As Integer = obj.Rows.Count - Int(obj.AllowUserToAddRows)
            obj.Rows.AddCopies(args(0), args(1))
            copyContentRows(eInd, args(0), args(1))
        End If
    End Sub
    Function GetFirstRow(ByVal ParamArray args() As String) As String
        Return obj.Rows.GetFirstRow(Filters.GetByIndex(Filters.IndexOfKey(LCase(args(0)))))
    End Function
    Function GetLastRow(ByVal ParamArray args() As String) As String
        Return obj.Rows.GetLastRow(Filters.GetByIndex(Filters.IndexOfKey(LCase(args(0)))))
    End Function
    Function GetNextRow(ByVal ParamArray args() As String) As String
        Return obj.Rows.GetNextRow(args(0), Filters.GetByIndex(Filters.IndexOfKey(LCase(args(1)))))
    End Function
    Function GetPreviousRow(ByVal ParamArray args() As String) As String
        Return obj.Rows.GetPreviousRow(args(0), Filters.GetByIndex(Filters.IndexOfKey(LCase(args(1)))))
    End Function
    Sub RowsInsert(ByVal ParamArray args() As String)
        args(0) = UbratKovich(args(0)).str
        Dim ind As Integer = args(0).Split(",")(0)
        DelDims(args, 0)
        If isDBconnect() Then
            RowsAdd(args)
        Else
            obj.Rows.Insert(ind, args)
        End If
    End Sub
    Sub ColumnsInsert(ByVal ParamArray args() As String)
        args(0) = UbratKovich(args(0)).str : args(1) = UbratKovich(args(1)).str
        Dim c As New DataGridViewTextBoxColumn
        Dim col As New DataGridViewColumn(c.CellTemplate) 'obj.Rows(0).Cells(0))
        col.Name = args(1) : col.HeaderText = args(1)
        obj.Columns.Insert(args(0).Split(",")(0), col)
    End Sub
    Sub RowsInsertCopies(ByVal ParamArray args() As String)
        ' Если таблица связана с данными то вставлять строку надо по бд-шному
        If isDBconnect() Then
            Dim i As Integer
            Dim selrows As String = SelectedRows
            For i = args(1) To Int(args(1)) + args(2) - 1
                SQLqueryInto(typeName, dbName, "INSERT INTO " & tablName & " VALUES(" & getVals(obj.rows(i).cells) & ")")
            Next
            SQLquerySelect(typeName, dbName, lastSelect)
            SelectedRows = selrows
        Else
            ' Таблица не связанная с данными
            obj.Rows.InsertCopies(args(1), args(0), args(2))
            If Int(args(0)) <= args(1) Then args(1) += Int(args(2))
            copyContentRows(args(0), args(1), args(2))
        End If
    End Sub
    Sub RowsRemove(ByVal ParamArray args() As String)
        args(0) = UbratKovich(args(0)).str
        Dim i As Integer, spl() As String = args(0).Split(","), splI() As Integer
        For i = 0 To spl.Length - 1
            ReDims(splI) : splI(splI.Length - 1) = spl(i)
        Next
        Array.Sort(splI)
        For i = splI.Length - 1 To 0 Step -1
            ' если номер строки указан верно
            If Iz.isInteger(splI(i)) And splI(i) < obj.rows.count Then
                ' если это не новая пустая строка, которую нельзя удалить
                If obj.Rows(splI(i)).IsNewRow = False Then obj.Rows.RemoveAt(splI(i))
            Else
                MessangeCritic(Errors.noRows(trans("удалить строку"), args(0)))
            End If
        Next
        If isDBconnect() Then
            '  SQLquerySelect(typeName, dbName, lastSelect)
        End If
    End Sub
    Sub ColumnsRemove(ByVal ParamArray args() As String)
        args(0) = UbratKovich(args(0)).str
        Dim i As Integer, spl() As String = args(0).Split(","), splI() As Integer
        For i = 0 To spl.Length - 1
            'If isInteger(spl(i)) = False Then Continue For
            ReDims(splI) : splI(splI.Length - 1) = spl(i)
        Next
        Array.Sort(splI)
        For i = splI.Length - 1 To 0 Step -1
            ' если номер столбца указан верно
            If Iz.isInteger(splI(i)) And splI(i) < obj.Columns.count Then
                obj.Columns.RemoveAt(splI(i))
            Else
                MessangeCritic(Errors.noColumns(trans("удалить столбец"), args(0)))

            End If
        Next
    End Sub
    Overloads Property SelectedRowsCount() As String
        Get
            Dim selCs As String = SelectedRows
            If selCs = "" Then Return 0
            Return selCs.Split(",").Length
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property SelectedColumnsCount() As String
        Get
            Dim selCs As String = SelectedColumns
            If selCs = "" Then Return 0
            Return selCs.Split(",").Length
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public colsWids As String
    Overloads Property WidthOfColumns() As String
        Get
            Dim i As Integer, ret As String = ""
            For i = 0 To obj.ColumnCount - 1
                ret &= obj.Columns(i).Width
                If i < obj.ColumnCount - 1 Then ret &= ","
            Next
            Return ret
        End Get
        Set(ByVal value As String)
            colsWids = value
            Dim wids() As String = value.Split(",")
            Dim i, wid As Integer, ret As String = ""
            For i = 0 To obj.ColumnCount - 1
                ' Если ширину передали нормально то устанавливаем её, если нет, то 100
                If i < wids.Length Then
                    wids(i) = wids(i).Trim
                    If wids(i) = "" Or IsNumeric(wids(i)) = False Then
                        wid = 100
                    Else
                        wid = wids(i)
                    End If
                Else
                    wid = 100
                End If
                ' Ставим определеную ширину
                obj.Columns(i).Width = wid
            Next
        End Set
    End Property
    Public rowsH As String
    Overloads Property HeightOfRows() As String
        Get
            Dim i As Integer, ret As String = ""
            For i = 0 To obj.RowCount - 1
                ret &= obj.Rows(i).Height
                If i < obj.RowCount - 1 Then ret &= ","
            Next
            Return ret
        End Get
        Set(ByVal value As String)
            rowsH = value
            Dim heights() As String = value.Split(",")
            Dim i, hei As Integer, ret As String = ""
            For i = 0 To obj.RowCount - 1
                ' Если ширину передали нормально то устанавливаем её, если нет, то 'obj.Font.Height'
                If i < heights.Length Then
                    heights(i) = heights(i).Trim
                    If heights(i) = "" Or IsNumeric(heights(i)) = False Then
                        hei = obj.Font.Height
                    Else
                        hei = heights(i)
                    End If
                Else
                    hei = obj.Font.Height
                End If
                ' Ставим определеную ширину
                obj.Rows(i).Height = hei
            Next
        End Set
    End Property



    Function getSortCells(ByVal coll As DataGridViewSelectedCellCollection) As DataGridViewCell()
        ' Копируем все ячейки в массив
        Dim cls(coll.Count - 1) As DataGridViewCell
        coll.CopyTo(cls, 0)
        ' Сортируем
        Array.Sort(cls, New SortByDataGridCell)
        Return cls
    End Function
    Overloads Property SelectedItemsValue() As String
        Get
            Dim i As Integer, oldval As String = Nothing
            Dim ret As String = ""
            ' Сортируем выделеные ячейки, а то они в дибильном порядке
            Dim clls() As DataGridViewCell = getSortCells(obj.SelectedCells)
            ' Собираем ячейки в сроку
            For i = 0 To clls.Length - 1
                ret &= """" & clls(i).Value & """"
                If i < clls.Length - 1 Then ret &= ","
            Next
            Return ret
        End Get
        Set(ByVal value As String)
            Dim i As Integer, val As String = ""
            ' Сортируем выделеные ячейки, а то они в дибильном порядке
            Dim clls() As DataGridViewCell = getSortCells(obj.SelectedCells)
            ' Присваиваем ячейкам преданный текст
            Dim cels As New CodeString(value, "None", False)
            Dim mSpl As MySplitStruct = cels.Split("naOdnomUrovne", ",")
            For i = 0 To clls.Length - 1
                If mSpl.texty.Length > i Then val = UbratKovich(mSpl.texty(i)).str
                clls(i).Value = val
            Next
        End Set
    End Property
    Function SearchInTable(ByVal ParamArray args() As String) As String
        Dim ri = -1, rj = -1, i, j As Integer
        ' Записываем в переменные основные аргументы
        Dim FndStr As String = args(0)
        Dim CaseSens As StringComparison
        If DaOrNet(args(1)) Then
            CaseSens = StringComparison.CurrentCulture
        Else
            CaseSens = StringComparison.CurrentCultureIgnoreCase
        End If
        Dim WholeWord As Boolean = DaOrNet(args(2))
        args(3) = args(3).Split(",")(0)
        args(4) = args(4).Split(",")(0)
        If args(3) = "" Then args(3) = 0
        If args(4) = "" Then args(4) = 0
        ' Ищем FndStr
        For i = args(3) To obj.Rows.Count - 1
            For j = args(4) To obj.Columns.Count - 1
                Dim currCel As String = obj.Rows(i).Cells(j).value
                If currCel Is Nothing Then Continue For
                Dim ind As Integer = currCel.IndexOf(FndStr, 0, CaseSens)
                ' Если что-то нашли
                While ind <> -1
                    ' Если надо искать слово целиком
                    If ind <> -1 And WholeWord = True Then
                        If currCel.Length > ind + FndStr.Length Then
                            If Char.IsLetterOrDigit(currCel.Chars(ind + FndStr.Length)) Then
                                ' Если найденая строке не подошла по "слово целиком"
                                ind = currCel.IndexOf(FndStr, ind + FndStr.Length, CaseSens)
                                Continue While
                            End If
                        End If
                    End If
                    ' ЕСЛИ НАЙДЕНО УСПЕШНО
                    If ind <> -1 Then Return i & "," & j
                End While
            Next
            args(4) = 0
        Next
        Return "-1,-1"
    End Function
    Function SearchInSelectedCells(ByVal ParamArray args() As String) As String
        Dim i As Integer
        ' Записываем в переменные основные аргументы
        Dim FndStr As String = args(0)
        Dim CaseSens As StringComparison
        If DaOrNet(args(1)) Then
            CaseSens = StringComparison.CurrentCulture
        Else
            CaseSens = StringComparison.CurrentCultureIgnoreCase
        End If
        Dim WholeWord As Boolean = DaOrNet(args(2))
        ' Сортируем выделеные ячейки, а то они в дибильном порядке
        Dim clls() As DataGridViewCell = getSortCells(obj.SelectedCells)
        ' Собираем ячейки в сроку
        For i = 0 To clls.Length - 1
            Dim ind As Integer = clls(i).Value.IndexOf(FndStr, 0, CaseSens)
            ' Если что-то нашли
            While ind <> -1
                ' Если надо искать слово целиком
                If ind <> -1 And WholeWord = True Then
                    If clls(i).Value.Length > ind + FndStr.Length Then
                        If Char.IsLetterOrDigit(clls(i).Value.Chars(ind + FndStr.Length)) Then
                            ' Если найденая строке не подошла по "слово целиком"
                            ind = clls(i).Value.IndexOf(FndStr, ind + FndStr.Length, CaseSens)
                            Continue While
                        End If
                    End If
                End If
                ' ЕСЛИ НАЙДЕНО УСПЕШНО
                If ind <> -1 Then Return clls(i).RowIndex & "," & clls(i).ColumnIndex
            End While
        Next
        Return "-1,-1"
    End Function
    Sub SearchWithSelect(ByVal ParamArray args() As String)
        Dim ri = -1, rj = -1, i, j As Integer
        ' Снимаем выделение
        While obj.SelectedCells.Count > 0
            obj.SelectedCells(0).Selected = False
        End While
        ' Записываем в переменные основные аргументы
        Dim FndStr As String = args(0)
        Dim CaseSens As StringComparison
        If DaOrNet(args(1)) Then
            CaseSens = StringComparison.CurrentCulture
        Else
            CaseSens = StringComparison.CurrentCultureIgnoreCase
        End If
        Dim WholeWord As Boolean = DaOrNet(args(2))
        args(3) = args(3).Split(",")(0)
        args(4) = args(4).Split(",")(0)
        If args(3) = "" Then args(3) = 0
        If args(4) = "" Then args(4) = 0
        ' Ищем FndStr
        For i = args(3) To obj.Rows.Count - 1
            For j = args(4) To obj.Columns.Count - 1
                Dim currCel As String = obj.Rows(i).Cells(j).value
                If currCel Is Nothing Then Continue For
                Dim ind As Integer = currCel.IndexOf(FndStr, 0, CaseSens)
                ' Если что-то нашли
                While ind <> -1
                    ' Если надо искать слово целиком
                    If ind <> -1 And WholeWord = True Then
                        If currCel.Length > ind + FndStr.Length Then
                            If Char.IsLetterOrDigit(currCel.Chars(ind + FndStr.Length)) Then
                                ' Если найденая строке не подошла по "слово целиком"
                                ind = currCel.IndexOf(FndStr, ind + FndStr.Length, CaseSens)
                                Continue While
                            End If
                        End If
                    End If
                    ' Если найдено успешно
                    If ind <> -1 Then
                        obj.Rows(i).Cells(j).Selected = True : Exit While
                    End If
                End While
            Next
            args(4) = 0
        Next
    End Sub

    Sub SaveTable(ByVal ParamArray args() As String)
        Try
            args(0) = GetMaxPath(args(0))
            System.IO.File.WriteAllText(UbratKovich(args(0)).str, Columns & "~""""""~" & Rows, System.Text.Encoding.UTF8)
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Sub OpenTable(ByVal ParamArray args() As String)
        typeName = "" : dbName = "" : tablName = ""
        args(0) = GetMaxPath(args(0))
        Dim dat As String = System.IO.File.ReadAllText(UbratKovich(args(0)).str, System.Text.Encoding.UTF8)
        Dim sep() As String = {"~""""""~"}
        Columns = dat.Split(sep, StringSplitOptions.None)(0)
        Rows = dat.Split(sep, StringSplitOptions.None)(1)
    End Sub

    ' БЛОК РАБОТЫ С БД-ых
    Public isSelecExecute As Boolean
    Dim tablName, dbName, typeName, lastSelect As String
    Dim cn As New Data.OleDb.OleDbConnection
    Dim cmd As Data.OleDb.OleDbCommand
    Dim dr As Data.OleDb.OleDbDataReader
    Dim dt As Data.DataTable
    Sub OpenAccess(ByVal ParamArray args() As String)
        typeName = "Access" : dbName = args(0) : tablName = args(1)
        lastSelect = "SELECT * FROM [" & tablName & "]"
        SQLquerySelect(typeName, dbName, lastSelect)
    End Sub
    Sub OpenExcel(ByVal ParamArray args() As String)
        typeName = "Excel" : dbName = args(0) : tablName = args(1)
        lastSelect = "SELECT * FROM [" & tablName & "]"
        SQLquerySelect(typeName, dbName, lastSelect)
    End Sub
    Sub SaveAccess(ByVal ParamArray args() As String)
        ' Ацесс можно сохранять только если до этого открыли его
        If typeName <> "Access" Then
            If IgnorEr = False Then MsgBox(notTableAccess)
            Exit Sub
        End If
        cn.Close()
        If openOleSql() = False Then Exit Sub
        Dim i, j As Integer, tmp As Object, constr As String

        For i = 0 To obj.RowCount - 2
            constr = "Insert into [" & tablName & "] values("
            For j = 0 To obj.ColumnCount - 1
                tmp = obj.Rows(i).Cells(j).Value
                If tmp Is Nothing Or tmp Is DBNull.Value Then
                    constr &= "null"
                Else
                    constr &= "'" & tmp & "'"
                End If
                If j < obj.ColumnCount - 1 Then constr &= ","
            Next
            constr &= ")"
            cmd = New Data.OleDb.OleDbCommand(constr, cn)
            cmd.ExecuteNonQuery()
        Next
        ' MessageBox.Show(i & " Record Saved Successfully", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cn.Close()
    End Sub
    Public Sub SQLquerySelect(ByVal ParamArray args() As String)
        Dim i, j As Integer
        cmd = ConnectToDB(args(0), args(1), args(2))
        If cmd Is Nothing Then Exit Sub
        ' Выполнение select'a
        dr = cmd.ExecuteReader
        lastSelect = args(2)
        If dr.IsClosed Then MsgBox(trans("Соединение к БД закрыто")) : Exit Sub

        ' критическая секция очистки события (чтобы не сработало событие удаление строки)
        isSelecExecute = True
        ' Редактирование существующих колонок и добавление необходимых новых из бд
        For i = 0 To dr.FieldCount - 1
            If i < obj.Columns.Count Then
                obj.Columns(i).HeaderText = dr.GetName(i)
                obj.Columns(i).ValueType = dr.GetFieldType(i)
            Else
                obj.Columns.Add(dr.GetName(i), dr.GetName(i))
                obj.Columns(i).ValueType = dr.GetFieldType(i)
            End If
        Next
        ' удаление лишних колонок, если их было больше, чем в бд
        For i = obj.Columns.Count - 1 To i Step -1
            obj.Columns.RemoveAt(i)
        Next
        ' добавление строк из бд
        Dim vals(obj.Columns.count - 1) As Object : i = 0
        While dr.Read
            dr.GetValues(vals)
            ' Либо редактировать существующюю строку
            If i < obj.rows.Count Then
                If obj.rows(i).isNewRow = False Then
                    For j = 0 To vals.Length - 1
                        obj.rows(i).cells(j).value = vals(j)
                    Next
                Else
                    obj.Rows.Add(vals)
                End If
            Else ' Либо добавить новую
                obj.Rows.Add(vals)
            End If
            i += 1
        End While
        ' удаление лишних строк, если их было больше, чем в бд
        For i = obj.rows.Count - 1 To i Step -1
            If obj.rows(i).isNewRow = False Then obj.rows.RemoveAt(i)
        Next
        If i < 0 Then obj.rows.clear()
        dr.Close()
        cn.Close()
        ' Конец критической секции
        isSelecExecute = False
    End Sub
    Public Sub SQLqueryInto(ByVal ParamArray args() As String)
        cmd = ConnectToDB(args(0), args(1), args(2))
        If cmd IsNot Nothing Then cmd.ExecuteReader()
        cn.Close()
    End Sub
    ' Коннект к базе данных на основе типа бд, файла бд и sql-действия, которое хотят сделать
    Function ConnectToDB(ByRef tip As String, ByRef file As String, ByRef command As String) As Data.OleDb.OleDbCommand
        Dim conStr As String = ""
        file = GetMaxPath(file)
        ' Генерируем строку соединения на основании типа бд и файла бд
        If UCase(tip) = UCase("Access") Then ' Microsoft.Jet.OLEDB.4.0
            conStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " & file & "; Persist Security Info = false"
        ElseIf UCase(tip) = UCase("Excel") Then
            conStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " & file & "; Extended Properties = 'Excel 12.0; HDR = Yes'"
        Else
            Return Nothing
        End If
        dt = New Data.DataTable("Temp")
        ' если еще не конектились к этой бд
        If conStr <> cn.ConnectionString Then
            cn.Close()
            cn.ConnectionString = conStr
            If openOleSql() = False Then Return Nothing
        Else
            ' если к этой бд конектились и закрыли соединение (это нормально), то открыть соединение
            If cn.State <> Data.ConnectionState.Open Then If openOleSql() = False Then Return Nothing
        End If
        Return New Data.OleDb.OleDbCommand(command, cn)
    End Function
    ' Открытие оле соединения с бд
    Function openOleSql() As Boolean
        Try
            cn.Open()
            Return True
        Catch ex As Exception
            If ex.InnerException IsNot Nothing Then
                InputBox("Ошибка" & ": " & ex.Message & vbCrLf & vbCrLf & "Обратитесь на support@algoritm2.ru, если не поможет переустановка MDAC отсюда:", "MDAC", _
                                 "http://download.microsoft.com/download/c/f/2/cf2b5cd9-7ffd-4c19-971f-9ccaf0b57d48/MDAC_TYP.EXE")
            Else
                Errors.MessangeExclamen(ex.Message)
            End If
            Return False
        End Try
    End Function



    Sub SortTable(ByVal ParamArray args() As String)
        If DaOrNet(args(1)) = True Then
            obj.Sort(obj.Columns(Convert.ToInt16(args(0))), System.ComponentModel.ListSortDirection.Ascending)
        Else
            obj.Sort(obj.Columns(Convert.ToInt16(args(0))), System.ComponentModel.ListSortDirection.Descending)
        End If
    End Sub
    Function HitTest(ByVal ParamArray args() As String) As String
        Dim ht As DataGridView.HitTestInfo = obj.HitTest(args(0), args(1))
        If ht.ColumnIndex <> -1 And ht.RowIndex <> -1 Then
            Return obj.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Value
        End If
        Return ""
    End Function
    Function HitTestColumn(ByVal ParamArray args() As String) As String
        Return obj.HitTest(args(0), args(1)).ColumnIndex
    End Function
    Function HitTestRow(ByVal ParamArray args() As String) As String
        Return obj.HitTest(args(0), args(1)).RowIndex
    End Function

    ' Списки
    Private DrDnHeight As Integer = 106
    Public Property DropDownHeight() As Integer
        Get
            Return DrDnHeight
        End Get
        Set(ByVal Value As Integer)
            DrDnHeight = Value
            obj.DropDownHeight = DrDnHeight
        End Set
    End Property
    Private DrDnWidth As Integer = 75
    Public Property DropDownWidth() As Integer
        Get
            Return DrDnWidth
        End Get
        Set(ByVal Value As Integer)
            DrDnWidth = Value
            obj.DropDownWidth = DrDnWidth
        End Set
    End Property
    Dim DrDnStyl As String = trans("Нет")
    Overloads Property DropDownStyle() As String
        Get
            Return DrDnStyl
        End Get
        Set(ByVal value As String)
            DrDnStyl = value
            If DaOrNet(DrDnStyl) = True Then
                obj.DropDownStyle = ComboBoxStyle.DropDown
            Else
                obj.DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End Set
    End Property
    Public Property ItemHeight() As Integer
        Get
            Return obj.ItemHeight
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property
    Overloads Property Items() As String
        Get
            Dim its As String = "", i As Integer
            ' компоновка строки колонок
            For i = 0 To obj.items.Count - 1
                its &= ", """ & CreateKovich(obj.items(i)) & """"
            Next
            If its <> "" Then its = its.Substring(2)
            Return its
        End Get
        Set(ByVal value As String)
            Dim its As New CodeString(value, "None", False)
            Dim mSpl As MySplitStruct = its.Split("naOdnomUrovne", ",")
            Dim j As Integer
            ' разбор строки с записями и создание по ней записей списка
            For j = 0 To mSpl.texty.Length - 1
                mSpl.texty(j) = UbratKovich(mSpl.texty(j)).str
            Next
            obj.items.clear()
            obj.items.addrange(mSpl.texty)
            obj.props.text = obj.props.text
        End Set
    End Property
    Private MaxDrDn As Integer = 8
    Public Property MaxDropDownItems() As Integer
        Get
            Return MaxDrDn
        End Get
        Set(ByVal Value As Integer)
            MaxDrDn = Value
            obj.MaxDropDownItems = MaxDrDn
        End Set
    End Property
    Dim Srtd As String = trans("Нет")
    Overloads Property Sorted() As String
        Get
            Return Srtd
        End Get
        Set(ByVal value As String)
            Srtd = value
            obj.Sorted = DaOrNet(Srtd)
        End Set
    End Property
    Overloads Property DroppedDown() As String
        Get
            Return DaOrNet(obj.DroppedDown)
        End Get
        Set(ByVal value As String)
            obj.DroppedDown = DaOrNet(value)
        End Set
    End Property
    Private selIn As Integer = 0
    Public Property SelectedIndex() As Integer
        Get
            Return selIn
        End Get
        Set(ByVal value As Integer)
            selIn = value
            If Iz.IsL(obj.myobj) Then
                If obj.selectionmode = 0 Then Exit Property
            End If
            If selIn >= 0 Then obj.SelectedIndex = selIn
        End Set
    End Property
    Private selIt As String = ""
    Public Property SelectedItem() As String
        Get
            Return selIt
        End Get
        Set(ByVal value As String)
            selIt = value
            If Iz.IsL(obj.myobj) Then
                If obj.selectionmode = 0 Then Exit Property
            End If
            obj.SelectedItem = selIt
        End Set
    End Property
    Overloads Property ItemsItem(ByVal ParamArray args() As String) As String
        Get
            Return obj.Items.Item(args(0))
        End Get
        Set(ByVal value As String)
            obj.Items.Item(args(0)) = value
        End Set
    End Property
    Overloads Property ItemsIndexOf(ByVal ParamArray args() As String) As String
        Get
            Return obj.Items.IndexOf(args(0))
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property ItemsCount() As Integer
        Get
            Return obj.Items.Count
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property
    Sub ItemsAdd(ByVal ParamArray args() As String)
        obj.Items.Add(args(0))
    End Sub
    Sub ItemsInsert(ByVal ParamArray args() As String)
        obj.Items.Insert(args(0), args(1))
    End Sub
    Sub ItemsRemove(ByVal ParamArray args() As String)
        obj.Items.Remove(args(0))
    End Sub
    Sub ItemsRemoveAt(ByVal ParamArray args() As String)
        obj.Items.RemoveAt(args(0))
    End Sub
    Private colWid As Integer = 0
    Public Property ColumnWidth() As Integer
        Get
            Return colWid
        End Get
        Set(ByVal value As Integer)
            colWid = value
            obj.ColumnWidth = colWid
        End Set
    End Property
    Dim HorScBar As String = trans("Нет")
    Overloads Property HorizontalScrollBar() As String
        Get
            Return HorScBar
        End Get
        Set(ByVal value As String)
            HorScBar = value
            obj.HorizontalScrollBar = DaOrNet(HorScBar)
        End Set
    End Property
    Dim multCol As String = trans("Нет")
    Overloads Property MultiColumn() As String
        Get
            Return multCol
        End Get
        Set(ByVal value As String)
            multCol = value
            obj.MultiColumn = DaOrNet(multCol)
        End Set
    End Property
    Dim selModeList As String = trans("Да")
    Overloads Property SelectionModeList() As String
        Get
            Return selModeList
        End Get
        Set(ByVal value As String)
            selModeList = value
            If DaOrNet(selModeList) Then
                obj.SelectionMode = Windows.Forms.SelectionMode.One
            Else
                obj.SelectionMode = Windows.Forms.SelectionMode.None
            End If
        End Set
    End Property
    Overloads Property CheckedIndices() As String
        Get
            Dim its As String = "", i As Integer
            ' компоновка строки колонок
            For i = 0 To obj.CheckedIndices.Count - 1
                its &= ", " & obj.CheckedIndices(i)
            Next
            If its <> "" Then its = its.Substring(2)
            Return its
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property CheckedItems() As String
        Get
            Dim its As String = "", i As Integer
            ' компоновка строки колонок
            For i = 0 To obj.CheckedItems.Count - 1
                its &= ", """ & CreateKovich(obj.CheckedItems(i)) & """"
            Next
            If its <> "" Then its = its.Substring(2)
            Return its
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property SelectedIndices() As String
        Get
            Dim its As String = "", i As Integer
            ' компоновка строки колонок
            For i = 0 To obj.SelectedIndices.Count - 1
                its &= ", " & obj.SelectedIndices(i)
            Next
            If its <> "" Then its = its.Substring(2)
            Return its
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property SelectedItems() As String
        Get
            Dim its As String = "", i As Integer
            ' компоновка строки колонок
            For i = 0 To obj.SelectedItems.Count - 1
                its &= ", """ & CreateKovich(obj.SelectedItems(i)) & """"
            Next
            If its <> "" Then its = its.Substring(2)
            Return its
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    ' Ссылка
    Dim ActLinkCol As String = ToMyColor(Color.Red)
    Overloads Property ActiveLinkColor() As String
        Get
            Return ActLinkCol
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.ActiveLinkColor = Color.Transparent
                    ActLinkCol = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                ActLinkCol = value
                obj.ActiveLinkColor = FromMyColor(ActLinkCol)
            End If
        End Set
    End Property
    Dim DisLiCol As String = "150; 151; 155;"
    Overloads Property DisabledLinkColor() As String
        Get
            Return DisLiCol
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.DisabledLinkColor = Color.Transparent
                    DisLiCol = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                DisLiCol = value
                obj.DisabledLinkColor = FromMyColor(DisLiCol)
            End If
        End Set
    End Property
    Dim LiCo As String = "0; 0; 255;"
    Overloads Property LinkColor() As String
        Get
            Return LiCo
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.LinkColor = Color.Transparent
                    LiCo = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                LiCo = value
                obj.LinkColor = FromMyColor(LiCo)
            End If
        End Set
    End Property
    Dim VisLiCol As String = "128; 0; 128;"
    Overloads Property VisitedLinkColor() As String
        Get
            Return VisLiCol
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.VisitedLinkColor = Color.Transparent
                    VisLiCol = value
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                VisLiCol = value
                obj.VisitedLinkColor = FromMyColor(VisLiCol)
            End If
        End Set
    End Property
    Private LiSt As Integer = 0
    Public Property LinkStart() As Integer
        Get
            Return LiSt
        End Get
        Set(ByVal value As Integer)
            LiSt = value
            obj.Links(0).Start = LiSt
        End Set
    End Property
    Private LiLe As Integer = 100
    Public Property LinkLength() As Integer
        Get
            Return LiLe
        End Get
        Set(ByVal value As Integer)
            LiLe = value
            obj.Links(0).Length = LiLe
        End Set
    End Property
    Dim LinBeh As String = trans("По умолчанию")
    Overloads Property LinkBehavior() As String
        Get
            Return LinBeh
        End Get
        Set(ByVal value As String)
            LinBeh = value
            obj.LinkBehavior = LinkBehaviors.GetByIndex(LinkBehaviors.IndexOfKey(LCase(LinBeh)))
        End Set
    End Property
    Dim LiVis As String = trans("Нет")
    Overloads Property LinkVisited() As String
        Get
            Return LiVis
        End Get
        Set(ByVal value As String)
            LiVis = value
            obj.Links(0).Visited = DaOrNet(LiVis)
        End Set
    End Property
    Dim LiEn As String = trans("Да")
    Overloads Property LinkEnabled() As String
        Get
            Return LiEn
        End Get
        Set(ByVal value As String)
            LiEn = value
            obj.Links(0).Enabled = DaOrNet(LiEn)
        End Set
    End Property
    Dim InetLin As String = trans("Да")
    Overloads Property InternetLink() As String
        Get
            Return InetLin
        End Get
        Set(ByVal value As String)
            InetLin = value
        End Set
    End Property
    Dim LinkNam As String = txt
    Overloads Property LinkName() As String
        Get
            'Dim len As Integer = LinkLength
            'If LinkStart >= 0 And LinkStart < Text.Length Then
            '    If LinkLength > 0 Then
            '        If LinkStart + LinkLength > Text.Length Then len = Text.Length - LinkStart
            '        Return Text.Substring(LinkStart, len)
            '    End If
            'End If
            'Return ""
            Return LinkNam
        End Get
        Set(ByVal value As String)
            LinkNam = value
        End Set
    End Property
    Sub GoInternetLink(Optional ByVal link As String = Nothing)
        If link = Nothing Then link = LinkName
        Dim ur As Uri = GetUrlFromString(link)
        Try
            If ur Is Nothing = False Then
                System.Diagnostics.Process.Start(ur.AbsoluteUri)
            Else
                System.Diagnostics.Process.Start(link)
            End If
        Catch ex As Exception
            If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
        End Try
    End Sub

    ' Тексовый документ
    Dim DetUr As String = trans("Да")
    Overloads Property DetectUrls() As String
        Get
            Return DetUr
        End Get
        Set(ByVal value As String)
            DetUr = value
            obj.DetectUrls = DaOrNet(DetUr)
        End Set
    End Property
    Overloads Property EnableAutoDragDrop() As String
        Get
            Return DaOrNet(obj.EnableAutoDragDrop)
        End Get
        Set(ByVal value As String)
            obj.EnableAutoDragDrop = DaOrNet(value)
        End Set
    End Property
    Public Property ZoomFactor() As Integer
        Get
            Return obj.ZoomFactor
        End Get
        Set(ByVal value As Integer)
            obj.ZoomFactor = value
        End Set
    End Property
    Public Property Rtf() As String
        Get
            Return obj.Rtf
        End Get
        Set(ByVal value As String)
            Try
                obj.Rtf = value
            Catch ex As Exception
                If IgnorEr = False Then Errors.MessangeCritic(ex.Message & " " & trans("Ошибка в написании RTF кода."))
            End Try
        End Set
    End Property
    Public Property SelectedRtf() As String
        Get
            Return obj.SelectedRtf
        End Get
        Set(ByVal value As String)
            obj.SelectedRtf = value
        End Set
    End Property
    Overloads Property SelectionAlignment() As String
        Get
            Return TextPositions.GetKey(TextPositions.IndexOfValue(obj.SelectionAlignment))
        End Get
        Set(ByVal value As String)
            obj.SelectionAlignment = TextPositions.GetByIndex(TextPositions.IndexOfKey(LCase(value)))
        End Set
    End Property
    Overloads Property SelectionBackColor() As String
        Get
            Return ToMyColor(obj.SelectionBackColor)
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.SelectionBackColor = Color.Transparent
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                obj.SelectionBackColor = FromMyColor(value)
            End If
        End Set
    End Property
    Overloads Property SelectionColor() As String
        Get
            Return ToMyColor(obj.SelectionColor)
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.SelectionColor = Color.Transparent
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                obj.SelectionColor = FromMyColor(value)
            End If
        End Set
    End Property
    Public Property SelectionHangingIndent() As Integer
        Get
            Return obj.SelectionHangingIndent
        End Get
        Set(ByVal value As Integer)
            obj.SelectionHangingIndent = value
        End Set
    End Property
    Public Property SelectionIndent() As Integer
        Get
            Return obj.SelectionIndent
        End Get
        Set(ByVal value As Integer)
            obj.SelectionIndent = value
        End Set
    End Property
    Public Property SelectionRightIndent() As Integer
        Get
            Return obj.SelectionRightIndent
        End Get
        Set(ByVal value As Integer)
            obj.SelectionRightIndent = value
        End Set
    End Property
    Overloads Property SelectionBullet() As String
        Get
            Return DaOrNet(obj.SelectionBullet)
        End Get
        Set(ByVal value As String)
            obj.SelectionBullet = DaOrNet(value)
        End Set
    End Property
    Public Property SelectionCharOffset() As Integer
        Get
            Return obj.SelectionCharOffset
        End Get
        Set(ByVal value As Integer)
            obj.SelectionCharOffset = value
        End Set
    End Property
    Overloads Property SelectionFontFamily() As String
        Get
            Dim styleF As FontStyle, font As Font = obj.SelectionFont
            If font Is Nothing Then
                Dim l As Integer = obj.SelectionLength
                obj.SelectionLength = 1
                font = obj.SelectionFont
                obj.SelectionLength = l
            End If
            If font Is Nothing Then Return ""
            If Fonts.IndexOfKey(LCase(font.FontFamily.Name)) = -1 Then Return ""
            Return Fonts.GetValueList(Fonts.IndexOfKey(LCase(font.FontFamily.Name)))
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle, font As Font = obj.SelectionFont
            If font Is Nothing Then
                Dim l As Integer = obj.SelectionLength
                obj.SelectionLength = 1
                font = obj.SelectionFont
                obj.SelectionLength = l
            End If
            If font Is Nothing Then Exit Property
            Try
                obj.SelectionFont = New Font(Fonts.GetByIndex(Fonts.IndexOfKey(LCase(value))).ToString, font.Size, font.Style)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(value) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
        End Set
    End Property
    Overloads Property SelectionFontBold() As String
        Get
            If obj.SelectionFont Is Nothing Then Return ""
            Return DaOrNet(obj.SelectionFont.Bold)
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle, font As Font = obj.SelectionFont
            If font Is Nothing Then
                Dim l As Integer = obj.SelectionLength
                obj.SelectionLength = 1
                font = obj.SelectionFont
                obj.SelectionLength = l
            End If
            If font Is Nothing Then Exit Property
            styleF = Int(DaOrNet(value)) * FontStyle.Bold _
                   + Int(font.Italic) * FontStyle.Italic _
                   + Int(font.Underline) * FontStyle.Underline _
                   + Int(font.Strikeout) * FontStyle.Strikeout
            Try
                obj.SelectionFont = New Font(font.FontFamily, font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(font.FontFamily.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
        End Set
    End Property
    Overloads Property SelectionFontItalic() As String
        Get
            If obj.SelectionFont Is Nothing Then Return ""
            Return DaOrNet(obj.SelectionFont.Italic)
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle, font As Font = obj.SelectionFont
            If font Is Nothing Then
                Dim l As Integer = obj.SelectionLength
                obj.SelectionLength = 1
                font = obj.SelectionFont
                obj.SelectionLength = l
            End If
            If font Is Nothing Then Exit Property
            styleF = Int(font.Bold) * FontStyle.Bold _
                   + Int(DaOrNet(value)) * FontStyle.Italic _
                   + Int(font.Underline) * FontStyle.Underline _
                   + Int(font.Strikeout) * FontStyle.Strikeout
            Try
                obj.SelectionFont = New Font(font.FontFamily, font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(font.FontFamily.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
        End Set
    End Property
    Overloads Property SelectionFontUnderline() As String
        Get
            If obj.SelectionFont Is Nothing Then Return ""
            Return DaOrNet(obj.SelectionFont.Underline)
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle, font As Font = obj.SelectionFont
            If font Is Nothing Then
                Dim l As Integer = obj.SelectionLength
                obj.SelectionLength = 1
                font = obj.SelectionFont
                obj.SelectionLength = l
            End If
            If font Is Nothing Then Exit Property
            styleF = Int(font.Bold) * FontStyle.Bold _
                   + Int(font.Italic) * FontStyle.Italic _
                   + Int(DaOrNet(value)) * FontStyle.Underline _
                   + Int(font.Strikeout) * FontStyle.Strikeout
            Try
                obj.SelectionFont = New Font(font.FontFamily, font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(font.FontFamily.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
        End Set
    End Property
    Overloads Property SelectionFontStrikeout() As String
        Get
            If obj.SelectionFont Is Nothing Then Return ""
            Return DaOrNet(obj.SelectionFont.Strikeout)
        End Get
        Set(ByVal value As String)
            Dim styleF As FontStyle, font As Font = obj.SelectionFont
            If font Is Nothing Then
                Dim l As Integer = obj.SelectionLength
                obj.SelectionLength = 1
                font = obj.SelectionFont
                obj.SelectionLength = l
            End If
            If font Is Nothing Then Exit Property
            styleF = Int(font.Bold) * FontStyle.Bold _
                                + Int(font.Italic) * FontStyle.Italic _
                                + Int(font.Underline) * FontStyle.Underline _
                                + Int(DaOrNet(value)) * FontStyle.Strikeout
            Try
                obj.SelectionFont = New Font(font.FontFamily, font.Size, styleF)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(font.FontFamily.ToString) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
        End Set
    End Property
    Overloads Property SelectionFontSize() As Integer
        Get
            If obj.SelectionFont Is Nothing Then Return obj.font.size
            Return obj.SelectionFont.size
        End Get
        Set(ByVal value As Integer)
            Dim font As Font = obj.SelectionFont
            If font Is Nothing Then
                Dim l As Integer = obj.SelectionLength
                obj.SelectionLength = 1
                font = obj.SelectionFont
                obj.SelectionLength = l
            End If
            If font Is Nothing Then Exit Property
            Try
                obj.SelectionFont = New Font(font.FontFamily.Name.ToString, value, font.Style)
            Catch ex As Exception
                If IgnorEr = False Then MsgBox(Errors.FontNotSupport(value) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                Exit Property
            End Try
        End Set
    End Property
    Overloads Property SelectionProtected() As String
        Get
            If obj.SelectionProtected Is Nothing Then Return ""
            Return DaOrNet(obj.SelectionProtected)
        End Get
        Set(ByVal value As String)
            obj.SelectionProtected = DaOrNet(value)
        End Set
    End Property
    Sub SaveFile(ByVal ParamArray args() As String)
        Try
            obj.SaveFile(args(0))
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub
    Sub OpenFile(ByVal ParamArray args() As String)
        Try
            If args(0) = "" Then Exit Sub
            obj.LoadFile(args(0))
        Catch ex As Exception
            If IgnorEr = False Then MessangeCritic(Errors.FileNotCreate(ex.Message))
        End Try
    End Sub

    ' диалоги
    Dim dCol As String = "0; 0; 0;"
    Overloads Property DialogColor() As String
        Get
            Return dCol
        End Get
        Set(ByVal value As String)
            dCol = value
        End Set
    End Property
    Dim cnl As String = trans("Нет")
    Overloads Property WasCancel() As String
        Get
            Return cnl
        End Get
        Set(ByVal value As String)
            cnl = value
        End Set
    End Property
    Sub ShowDialog()
        Dim d As DialogResult
        If Iz.IsCDobj(obj) Or Iz.IsFDobj(obj) Then d = obj.ShowDialog Else d = obj.dialog.ShowDialog()

        If Iz.IsFDobj(obj) Then
            FontFamily = obj.font.FontFamily.Name
            FontBold = DaOrNet(obj.font.bold)
            FontItalic = DaOrNet(obj.font.italic)
            FontUnderline = DaOrNet(obj.font.underline)
            FontStrikeout = DaOrNet(obj.font.Strikeout)
        End If
        If d = Windows.Forms.DialogResult.OK Then WasCancel = trans("Нет") Else WasCancel = trans("Да")
    End Sub
    Dim ShCols As String = trans("Нет")
    Overloads Property ShowColor() As String
        Get
            Return ShCols
        End Get
        Set(ByVal value As String)
            ShCols = value
        End Set
    End Property
    Dim ShEff As String = trans("Да")
    Overloads Property ShowEffects() As String
        Get
            Return ShEff
        End Get
        Set(ByVal value As String)
            ShEff = value
        End Set
    End Property
    Dim descr As String = ""
    Overloads Property Description() As String
        Get
            Return descr
        End Get
        Set(ByVal value As String)
            descr = value
        End Set
    End Property
    Dim sePath As String = ""
    Overloads Property SelectedPath() As String
        Get
            Return sePath
        End Get
        Set(ByVal value As String)
            sePath = value
        End Set
    End Property
    Dim defEx As String = ""
    Overloads Property DefaultExt() As String
        Get
            Return defEx
        End Get
        Set(ByVal value As String)
            defEx = value
        End Set
    End Property
    Dim ChFEx As String = trans("Да")
    Overloads Property CheckFileExists() As String
        Get
            Return ChFEx
        End Get
        Set(ByVal value As String)
            ChFEx = value
        End Set
    End Property
    Dim ChPEx As String = trans("Да")
    Overloads Property CheckPathExists() As String
        Get
            Return ChPEx
        End Get
        Set(ByVal value As String)
            ChPEx = value
        End Set
    End Property
    Dim flNm As String = ""
    Overloads Property FileName() As String
        Get
            Return flNm
        End Get
        Set(ByVal value As String)
            flNm = value
        End Set
    End Property
    Dim fltr As String = ""
    Overloads Property Filter() As String
        Get
            Return fltr
        End Get
        Set(ByVal value As String)
            fltr = value
        End Set
    End Property
    Dim flIn As Integer = 1
    Overloads Property FilterIndex() As Integer
        Get
            Return flIn
        End Get
        Set(ByVal value As Integer)
            flIn = value
        End Set
    End Property
    Dim iniDir As String = ""
    Overloads Property InitialDirectory() As String
        Get
            Return iniDir
        End Get
        Set(ByVal value As String)
            iniDir = value
        End Set
    End Property
    Dim ttl As String = ""
    Overloads Property Title() As String
        Get
            Return ttl
        End Get
        Set(ByVal value As String)
            ttl = value
        End Set
    End Property
    Dim MuSeFil As String = trans("Нет")
    Overloads Property MultiSelectFiles() As String
        Get
            Return MuSeFil
        End Get
        Set(ByVal value As String)
            MuSeFil = value
        End Set
    End Property
    Dim prPic As String = trans("Никакой")
    Overloads Property PrintPicture() As String
        Get
            Return GetMinPath(prPic)
        End Get
        Set(ByVal value As String)
            prPic = GetMaxPath(value)
            If IsHttpCompil = False Then
                If NikakoiEsli(prPic) <> trans("Никакой") Then
                    Try
                        obj.picPrint = Drawing.Image.FromFile(prPic)
                    Catch ex As Exception
                        obj.picPrint = Nothing
                        If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
                    End Try
                Else
                    obj.picPrint = Nothing
                End If
            End If
        End Set
    End Property
    Dim prTx As String = ""
    Overloads Property PrintText() As String
        Get
            Return prTx
        End Get
        Set(ByVal value As String)
            prTx = value
        End Set
    End Property
    Dim prDc As String = ""
    Overloads Property PrintDocument() As String
        Get
            Return prDc
        End Get
        Set(ByVal value As String)
            prDc = value
            If RunProj IsNot Nothing Then
                If obj.myobj.getmyform IsNot Nothing Then
                    obj.rtfPrint = RunProj.GetMyAllFromName(value, , obj.myobj.getmyform.obj.name)
                End If
            End If
        End Set
    End Property
    Dim prTl As String = ""
    Overloads Property PrintTable() As String
        Get
            Return prTl
        End Get
        Set(ByVal value As String)
            prTl = value
            If RunProj IsNot Nothing Then
                If obj.myobj.getmyform IsNot Nothing Then
                    obj.tablPrint = RunProj.GetMyAllFromName(value, , obj.myobj.getmyform.obj.name)
                End If
            End If

        End Set
    End Property
    Dim prOb As String = ""
    Overloads Property PrintObject() As String
        Get
            Return prOb
        End Get
        Set(ByVal value As String)
            prOb = value
            obj.objPrint = value
            'If RunProj IsNot Nothing Then
            '    If obj.myobj.getmyform IsNot Nothing Then
            '        obj.objPrint = RunProj.GetMyAllFromName(value, , obj.myobj.getmyform.obj.name)
            '    End If
            'End If
        End Set
    End Property
    Dim TbCn As String = trans("Да")
    Overloads Property TableOnCenter() As String
        Get
            Return TbCn
        End Get
        Set(ByVal value As String)
            TbCn = value
        End Set
    End Property
    Dim FrmPg As Integer = 1
    Overloads Property FromPage() As Integer
        Get
            Return FrmPg
        End Get
        Set(ByVal value As Integer)
            FrmPg = value
            If isRUN() Then obj.PrintDoc.PrinterSettings.FromPage = value
        End Set
    End Property
    Dim ToPg As Integer = 999
    Overloads Property ToPage() As Integer
        Get
            Return ToPg
        End Get
        Set(ByVal value As Integer)
            ToPg = value
            If isRUN() Then obj.PrintDoc.PrinterSettings.ToPage = value
        End Set
    End Property
    Dim Cops As Integer = 1
    Overloads Property Copies() As Integer
        Get
            Return Cops
        End Get
        Set(ByVal value As Integer)
            Cops = value
            If isRUN() Then obj.PrintDoc.PrinterSettings.Copies = value
        End Set
    End Property

    Sub ShowPrevDialog()
        obj.prevdialog.Document = obj.PrintDoc
        'obj.prevdialog.Document.DefaultPageSettings.Margins.Left = PaddingLeft
        'obj.prevdialog.Document.DefaultPageSettings.Margins.Right = PaddingRight
        'obj.prevdialog.Document.DefaultPageSettings.Margins.Top = PaddingTop
        'obj.prevdialog.Document.DefaultPageSettings.Margins.Bottom = PaddingBottom
        obj.isPreview = True
        If obj.prevdialog.showdialog = Windows.Forms.DialogResult.OK Then
            WasCancel = trans("Нет")
        Else
            WasCancel = trans("Да")
        End If
        obj.isPreview = False
    End Sub
    Sub ShowPageDialog()
        obj.pagedialog.Document = obj.PrintDoc
        'obj.PrintDoc.DefaultPageSettings.Margins.Left = PaddingLeft
        'obj.PrintDoc.DefaultPageSettings.Margins.Right = PaddingRight
        'obj.PrintDoc.DefaultPageSettings.Margins.Top = PaddingTop
        'obj.PrintDoc.DefaultPageSettings.Margins.Bottom = PaddingBottom
        'obj.PrintDoc.PrinterSettings.Copies = Copies
        'obj.PrintDoc.PrinterSettings.ToPage = ToPage
        'obj.PrintDoc.PrinterSettings.FromPage = FromPage
        If obj.pagedialog.showdialog = Windows.Forms.DialogResult.OK Then
            WasCancel = trans("Нет")
            obj.PrintDoc.DefaultPageSettings = obj.PageDialog.PageSettings
            PaddingLeft = obj.PageDialog.PageSettings.Margins.Left
            PaddingRight = obj.PageDialog.PageSettings.Margins.Right
            PaddingTop = obj.PageDialog.PageSettings.Margins.Top
            PaddingBottom = obj.PageDialog.PageSettings.Margins.Bottom
            obj.PrintDoc.PrinterSettings.Copies = Copies
            obj.PrintDoc.PrinterSettings.ToPage = ToPage
            obj.PrintDoc.PrinterSettings.FromPage = FromPage
        Else
            WasCancel = trans("Да")
        End If
    End Sub
    Sub ShowPrinDialog()
        obj.isPreview = False
        obj.prindialog.Document = obj.PrintDoc
        obj.prindialog.PrinterSettings = obj.PrintDoc.PrinterSettings
        Try
            If obj.prindialog.showdialog = Windows.Forms.DialogResult.OK Then
                WasCancel = trans("Нет")
                obj.PrintDoc.PrinterSettings = obj.prindialog.PrinterSettings
                Copies = obj.PrintDoc.PrinterSettings.Copies
                ToPage = obj.PrintDoc.PrinterSettings.ToPage
                FromPage = obj.PrintDoc.PrinterSettings.FromPage
                obj.PrintDoc.Print()
            Else
                WasCancel = trans("Да")
            End If
        Catch ex As Exception
            MsgBox("fff" & ex.Message)
        End Try
    End Sub

    ' Календарь
    Overloads Property CalendarDateFormat() As String
        Get
            Return DateFormats.GetKey(DateFormats.IndexOfValue(obj.Format))
        End Get
        Set(ByVal value As String)
            obj.Format = DateFormats.GetByIndex(DateFormats.IndexOfKey(LCase(value)))
        End Set
    End Property
    Overloads Property CustomDateFormat() As String
        Get
            Return obj.CustomFormat
        End Get
        Set(ByVal value As String)
            obj.CustomFormat = value
        End Set
    End Property
    Overloads Property ShowUpDown() As String
        Get
            Return DaOrNet(obj.ShowUpDown)
        End Get
        Set(ByVal value As String)
            obj.ShowUpDown = DaOrNet(value)
        End Set
    End Property
    Overloads Property SelectedDate() As String
        Get
            Return ToMyDate(obj.value)
        End Get
        Set(ByVal value As String)
            Dim d As Date = FromMyDate(value)
            If d <= obj.MaxDate And d >= obj.MinDate Then
                obj.value = d
            Else
                If IgnorEr = False Then MsgBox(Errors.notDateLimit(value, obj.MinDate.ToString, obj.MaxDate.ToString))
            End If
        End Set
    End Property

    ' Бегунок
    Overloads Property LargeChange() As String
        Get
            Return obj.LargeChange
        End Get
        Set(ByVal value As String)
            obj.LargeChange = value
        End Set
    End Property
    Overloads Property SmallChange() As String
        Get
            Return obj.SmallChange
        End Get
        Set(ByVal value As String)
            obj.SmallChange = value
        End Set
    End Property
    Overloads Property Maximum() As String
        Get
            Return obj.Maximum
        End Get
        Set(ByVal value As String)
            obj.Maximum = value
        End Set
    End Property
    Overloads Property Minimum() As String
        Get
            Return obj.Minimum
        End Get
        Set(ByVal value As String)
            obj.Minimum = value
        End Set
    End Property
    Overloads Property TickStyle() As String
        Get
            Return TickStyles.GetKey(TickStyles.IndexOfValue(obj.TickStyle))
        End Get
        Set(ByVal value As String)
            obj.TickStyle = TickStyles.GetByIndex(TickStyles.IndexOfKey(LCase(value)))
        End Set
    End Property
    Overloads Property TickFrequency() As String
        Get
            Return obj.TickFrequency
        End Get
        Set(ByVal value As String)
            obj.TickFrequency = value
        End Set
    End Property

    ' Триал
    Dim kpri As String
    Overloads Property KeyEncryption() As String
        Get
            Return kpri
        End Get
        Set(ByVal value As String)
            kpri = value
        End Set
    End Property
    Function getBiDat() As String
        Dim biosVer = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Hardware\Description\System").GetValue("SystemBiosVersion")
        If IsArray(biosVer) Then
            biosVer = String.Join(" ", biosVer)
        End If
        If biosVer.Length > 5 Then
            biosVer = biosVer.Substring(0, 5)
        End If
        Return biosVer
    End Function
    Dim idpr As String
    Overloads Property IdProgram() As String
        Get
            Return idpr
        End Get
        Set(ByVal value As String)
            idpr = value
        End Set
    End Property
    Dim rkey As String
    Overloads Property IdRegistryProgram() As String
        Get
            Return rkey
        End Get
        Set(ByVal value As String)
            rkey = value
        End Set
    End Property
    Overloads Property IdUser() As String
        Get
            Return EncryptRSA(getBiDat)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Dim btnT As String = trans("Активировать")
    Overloads Property TextButton() As String
        Get
            Return btnT
        End Get
        Set(ByVal value As String)
            btnT = value
            obj.Buttn.Text = btnT
        End Set
    End Property
    Dim tF As String = ""
    Overloads Property TextField() As String
        Get
            Return tF
        End Get
        Set(ByVal value As String)
            tF = value
            obj.TextB.Text = tF
        End Set
    End Property
    Dim msDa As String = trans("Ключ верный!")
    Overloads Property MessageValid() As String
        Get
            Return msDa
        End Get
        Set(ByVal value As String)
            msDa = value
        End Set
    End Property
    Dim msNet As String = trans("Ключ неверный.")
    Overloads Property MessageInvalid() As String
        Get
            Return msNet
        End Get
        Set(ByVal value As String)
            msNet = value
        End Set
    End Property
    Function KeyValidation(ByVal ParamArray args() As String) As String
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & IdRegistryProgram).SetValue("K", args(0))
        Dim act As String = Activation

        ' Показать в окне, если это задано
        If args.Length > 1 Then
            If DaOrNet(args(1)) Then
                If DaOrNet(act) Then MsgBox(MessageValid) Else MsgBox(MessageInvalid)
            End If
        End If

        Return act
    End Function
    Function KeyIssue(ByVal ParamArray args() As String) As String
        ' Получаем дату биоса юзера
        Dim usBi As String = DecryptRSA(args(0))
        ' Шифруем дату биоса юзера с идом программы
        Dim key As String = EncryptRSA(usBi & IdProgram)

        ' Показать в окне, если это задано
        If args.Length > 1 Then
            If DaOrNet(args(1)) Then
                InputBox(trans("Ваш ключ активации") & ":", , KeyIssue(args(0)))
            End If
        End If

        Return key
    End Function
    Dim dnVs As String = 30
    Overloads Property DaysAll() As String
        Get
            Return dnVs
        End Get
        Set(ByVal value As String)
            dnVs = value
        End Set
    End Property
    Function EncryptRSA(ByVal str As String) As String
        Dim Data() As Byte
        Dim RSA As New Security.Cryptography.RSACryptoServiceProvider
        If KeyEncryption Is Nothing Then Return ""
        ' Для шифрования нам достаточно публичного ключа
        RSA.FromXmlString(KeyEncryption)
        ' Получаем данные
        Data = System.Text.Encoding.UTF8.GetBytes(str)
        ' Шифруем данные
        Data = RSA.Encrypt(Data, True)
        ' Преобразуем байтовый массив в строку и покажем юзеру
        Return toStrArray(Data)
    End Function
    Function DecryptRSA(ByVal str As String) As String
        Dim Data() As Byte
        Dim RSA As New Security.Cryptography.RSACryptoServiceProvider
        If KeyEncryption Is Nothing Then Return ""
        ' Для дешифрования нам понадобится закрытый ключ
        RSA.FromXmlString(KeyEncryption)
        ' Получаем данные
        '    Data = System.Text.Encoding.UTF8.GetBytes(str)
        Data = toByteArray(str)
        ' Дешифруем данные
        Data = RSA.Decrypt(Data, True)
        ' Преобразуем байтовый массив в строку и покажем юзеру
        Return System.Text.Encoding.UTF8.GetString(Data)
    End Function
    Sub TrialStart()
        Dim dniTrial As Long = DaysAll * 60 * 60 * 24 : dniTrial *= 10000000
        Dim trSt As String = EncryptRSA(Now.Ticks + dniTrial)
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & IdRegistryProgram).SetValue("D", trSt)
        Dim lsSt As String = EncryptRSA(Now.Ticks)
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Microsoft\" & IdRegistryProgram).SetValue("L", lsSt)
    End Sub
    Sub ActivationCancel()
        Activation = DaOrNet(False)
    End Sub
    Overloads Property DaysLeft() As String
        Get
            Dim dt As String = "", nowtime As Long = Now.Ticks
            ' Если колдовали с временем
            dt = Remark()
            If status = 1 Then Return 0
            If status = 2 Then nowtime = LastTime()
            If status = 3 Then Return 0
            ' Получаем дату начала триала
            Try
                dt = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\" & IdRegistryProgram).GetValue("D")
            Catch ex As Exception
                Return 0
            End Try
            If dt Is Nothing Then Return 0
            If dt.Length Mod 3 <> 0 Then Return 0
            dt = DecryptRSA(dt)
            ' Определяем разность 
            If IsNumeric(dt) = False Then Return 0
            Dim lft As Long = dt - nowtime
            If lft < 0 Then Return 0
            Return Math.Round(lft / 10000000 / 60 / 60 / 24, 1)
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Function LastTime() As String
        Dim dt As String = ""
        Try
            dt = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\" & IdRegistryProgram).GetValue("L")
        Catch ex As Exception
            Return 0
        End Try
        If dt Is Nothing Then Return 0
        If dt.Length Mod 3 <> 0 Then Return 0
        Return DecryptRSA(dt)
    End Function
    Overloads Property TrialStarted() As String
        Get
            Dim ret As Boolean = True
            ' не должен существовать Programms
            Try
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\" & IdRegistryProgram) Is Nothing Then ret = False
            Catch ex As Exception
                ret = False
            End Try
            ' и не должен существовать Microsoft
            If ret = False Then
                Try
                    If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\" & IdRegistryProgram) IsNot Nothing Then ret = True
                Catch ex As Exception
                End Try
            End If
            Return DaOrNet(ret)
        End Get
        Set(ByVal value As String)
            If DaOrNet(value) Then
                TrialStart()
            Else
                Try
                    Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("Software\" & IdRegistryProgram)
                    Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("Software\Microsoft\" & IdRegistryProgram)
                Catch ex As Exception
                End Try
            End If
        End Set
    End Property
    Overloads Property Activation() As String
        Get
            Dim dt As String
            dt = Remark()
            ' Получаем дату начала триала
            Try
                dt = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\" & IdRegistryProgram).GetValue("K")
            Catch ex As Exception
                Return DaOrNet(False)
            End Try
            ' Дешифруем данные
            If dt Is Nothing Then Return trans("Нет")
            If dt.Length = 0 Or dt.Length Mod 3 <> 0 Then Return trans("Нет")
            Try
                dt = DecryptRSA(dt)
            Catch ex As Exception
                Return DaOrNet(False)
            End Try
            ' Проверяем активацию
            If getBiDat() & IdProgram = dt Then Return DaOrNet(True) Else Return DaOrNet(False)
        End Get
        Set(ByVal value As String)
            If DaOrNet(value) = True Then
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & IdRegistryProgram).SetValue("K", KeyIssue(IdUser))
            Else
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\" & IdRegistryProgram).SetValue("K", "")
            End If
        End Set
    End Property
    Public status As Integer = 0
    Overloads Property Remark() As String
        Get
            Dim dt As String = ""
            status = 0
            If DaOrNet(TrialStarted) = False Then Return trans("Триальный период еще не запускался, либо был удален.")
            If LastTime() = 0 Then status = 3 : Return trans("Попытка удалить триальный период.")
            ' Проверка на переводы часов
            Try
                dt = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\" & IdRegistryProgram).GetValue("D")
            Catch ex As Exception
                Return trans("Попытка удалить триальный период.")
            End Try
            If dt Is Nothing Then Return ""
            If dt.Length Mod 3 <> 0 Then Return ""
            dt = DecryptRSA(dt)

            If LastTime() > dt Then
                status = 1 : Return trans("Поледний запуск был после окончания триального периода.")
            ElseIf Now.Ticks < LastTime() Then
                status = 2 : Return trans("Системное время было изменено на более раннее.")
            Else
                Dim lsSt As String = EncryptRSA(Now.Ticks)
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Microsoft\" & IdRegistryProgram).SetValue("L", lsSt)
            End If

            Return ""
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Dim TlTp As String = ""
    Overloads Property ToolTip() As String
        Get
            Return TlTp
        End Get
        Set(ByVal value As String)
            TlTp = value
            obj.Myobj.ToolTipa.SetToolTip(obj, TlTp)
            If Iz.IsTr(obj.Myobj) Then
                obj.Myobj.ToolTipa.SetToolTip(obj.TextB, TlTp)
                obj.Myobj.ToolTipa.SetToolTip(obj.Buttn, TlTp)
            End If
        End Set
    End Property
    Dim MultSelIts As String = trans("Нет")
    Overloads Property MultiSelectItems() As String
        Get
            Return MultSelIts
        End Get
        Set(ByVal value As String)
            MultSelIts = value
            If DaOrNet(MultSelIts) Then
                obj.SelectionMode = Windows.Forms.SelectionMode.MultiExtended
            Else
                obj.SelectionMode = Windows.Forms.SelectionMode.One
            End If
        End Set
    End Property

    ' КлиентСервер
    Public Property FileIsSent() As String
        Get
            Return DaOrNet(obj.FileIsSent)
        End Get
        Set(ByVal value As String)
            obj.FileIsSent = DaOrNet(value)
        End Set
    End Property
    Public Property HideSendingText() As String
        Get
            Return DaOrNet(obj.HideSendingText)
        End Get
        Set(ByVal value As String)
            obj.HideSendingText = DaOrNet(value)
        End Set
    End Property
    Public Property HideSendingFiles() As String
        Get
            Return DaOrNet(obj.HideSendingFiles)
        End Get
        Set(ByVal value As String)
            obj.HideSendingFiles = DaOrNet(value)
        End Set
    End Property
    Public Property HideComboBox() As String
        Get
            Return DaOrNet(obj.HideComboBox)
        End Get
        Set(ByVal value As String)
            obj.HideComboBox = DaOrNet(value)
        End Set
    End Property
    Public Property CommandSymbol() As String
        Get
            Return obj.CommandSymbol
        End Get
        Set(ByVal value As String)
            obj.CommandSymbol = value
        End Set
    End Property
    Public Property ReceivedCommand() As String
        Get
            Return obj.ReceivedCommand
        End Get
        Set(ByVal value As String)
            obj.ReceivedCommand = value
        End Set
    End Property
    Public Property ReceivedText() As String
        Get
            Return obj.ReceivedText
        End Get
        Set(ByVal value As String)
            obj.ReceivedText = value
        End Set
    End Property
    Public Property ReceivedFile() As String
        Get
            Return obj.ReceivedFile
        End Get
        Set(ByVal value As String)
            obj.ReceivedFile = value
        End Set
    End Property
    Public Property SentCommand() As String
        Get
            Return obj.SentCommand
        End Get
        Set(ByVal value As String)
            obj.SentCommand = value
        End Set
    End Property
    Public Property SentText() As String
        Get
            Return obj.SentText
        End Get
        Set(ByVal value As String)
            obj.SentText = value
        End Set
    End Property
    Public Property SentFile() As String
        Get
            Return obj.SentFile
        End Get
        Set(ByVal value As String)
            obj.SentFile = value
        End Set
    End Property
    Public Property NameInNetwork() As String
        Get
            Return obj.NameInNetwork
        End Get
        Set(ByVal value As String)
            obj.NameInNetwork = value
        End Set
    End Property
    Public Property RemoteHost() As String
        Get
            Return obj.RemoteHost
        End Get
        Set(ByVal value As String)
            obj.RemoteHost = value
        End Set
    End Property
    Public Property RemotePort() As String
        Get
            Return obj.RemotePort
        End Get
        Set(ByVal value As String)
            obj.RemotePort = value
        End Set
    End Property
    Public Property PathForDownloads() As String
        Get
            Return obj.PathForDownloads
        End Get
        Set(ByVal value As String)
            obj.PathForDownloads = value
        End Set
    End Property
    Public Property ClientServerType() As String
        Get
            Return obj.ClientServerType
        End Get
        Set(ByVal value As String)
            obj.ClientServerType = value
        End Set
    End Property
    Public Property ClientsNames() As String
        Get
            Return obj.ClientsNames
        End Get
        Set(ByVal value As String)
            obj.ClientsNames = value
        End Set
    End Property
    Public Property TextBoxString() As String
        Get
            Return obj.TextBoxString
        End Get
        Set(ByVal value As String)
            obj.TextBoxString = value
        End Set
    End Property
    Public Property TextBoxLog() As String
        Get
            Return obj.TextBoxLog
        End Get
        Set(ByVal value As String)
            obj.TextBoxLog = value
        End Set
    End Property
    Public Property ClientsIPs() As String
        Get
            Return obj.ClientsIPs
        End Get
        Set(ByVal value As String)
            obj.ClientsIPs = value
        End Set
    End Property
    Public Property GetClientIp(ByVal ParamArray args() As String) As String
        Get
            Return obj.GetClientIp(args(0))
        End Get
        Set(ByVal value As String)
            obj.GetClientIp(args(0)) = value
        End Set
    End Property
    ' Методы
    Public Sub SendToServer(ByVal ParamArray args() As String)
        obj.SendToServer(args(0))
    End Sub
    Public Sub SendFileToServer(ByVal ParamArray args() As String)
        obj.SendFileToServer(args(0))
    End Sub
    Public Sub SendToClients(ByVal ParamArray args() As String)
        obj.SendToClients(args(0))
    End Sub
    Public Sub SendToClientsBut(ByVal ParamArray args() As String)
        obj.SendToClientsBut(args(0), args(1))
    End Sub
    Public Sub SendToClient(ByVal ParamArray args() As String)
        obj.SendToClient(args(0), args(1))
    End Sub
    Public Sub SendFileToClients(ByVal ParamArray args() As String)
        obj.SendFileToClients(args(0))
    End Sub
    Public Sub SendFileToClientsBut(ByVal ParamArray args() As String)
        obj.SendFileToClientsBut(args(0), args(1))
    End Sub
    Public Sub SendFileToClient(ByVal ParamArray args() As String)
        obj.SendFileToClient(args(0), args(1))
    End Sub
    Public Sub Log(ByVal ParamArray args() As String)
        obj.Log(args(0))
    End Sub
    Public Sub RunCommand(ByVal ParamArray args() As String)
        obj.RunCommand(args(0))
    End Sub
    Public Sub ConnectToServer()
        obj.ConnectToServer()
    End Sub
    Public Sub CreateServer()
        obj.CreateServer()
    End Sub
    Public Sub BeginListen()
        obj.BeginListen()
    End Sub
    Public Sub CloseServer()
        obj.CloseServer()
    End Sub
    Public Sub CloseListener()
        obj.CloseListener()
    End Sub
    Public Sub CloseClient()
        obj.CloseClient()
    End Sub

    ' Интренет
    Property KeepAlive() As String
        Get
            Return DaOrNet(obj.KeepAlive)
        End Get
        Set(ByVal value As String)
            obj.KeepAlive = DaOrNet(value)
        End Set
    End Property
    Property AllowAutoRedirect() As String
        Get
            Return DaOrNet(obj.AllowAutoRedirect)
        End Get
        Set(ByVal value As String)
            obj.AllowAutoRedirect = DaOrNet(value)
        End Set
    End Property
    Property UrlToGo() As String
        Get
            Return obj.UrlToGo
        End Get
        Set(ByVal value As String)
            obj.UrlToGo = value
        End Set
    End Property
    Property UrlReferer() As String
        Get
            Return obj.UrlReferer
        End Get
        Set(ByVal value As String)
            obj.UrlReferer = value
        End Set
    End Property
    Property UrlRedirect() As String
        Get
            Return obj.UrlRedirect
        End Get
        Set(ByVal value As String)
            obj.UrlRedirect = value
        End Set
    End Property
    Property UserAgent() As String
        Get
            Return obj.UserAgent
        End Get
        Set(ByVal value As String)
            obj.UserAgent = value
        End Set
    End Property
    Property Accept() As String
        Get
            Return obj.Accept
        End Get
        Set(ByVal value As String)
            obj.Accept = value
        End Set
    End Property
    Property ProxyIp() As String
        Get
            Return obj.ProxyIp
        End Get
        Set(ByVal value As String)
            obj.ProxyIp = value
        End Set
    End Property
    Property ProxyPort() As String
        Get
            Return obj.ProxyPort
        End Get
        Set(ByVal value As String)
            obj.ProxyPort = value
        End Set
    End Property
    Property EncodingPage() As String
        Get
            Return obj.EncodingPage
        End Get
        Set(ByVal value As String)
            obj.EncodingPage = value
        End Set
    End Property
    Property LanguagePage() As String
        Get
            Return obj.LanguagePage
        End Get
        Set(ByVal value As String)
            obj.LanguagePage = value
        End Set
    End Property
    Property ContentQuery() As String
        Get
            Return obj.ContentQuery
        End Get
        Set(ByVal value As String)
            obj.ContentQuery = value
        End Set
    End Property
    Property ContentType() As String
        Get
            Return obj.ContentType
        End Get
        Set(ByVal value As String)
            obj.ContentType = value
        End Set
    End Property
    Property ContentLength() As String
        Get
            Return obj.ContentLength
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Property HttpMethod() As String
        Get
            Return obj.HttpMethod
        End Get
        Set(ByVal value As String)
            obj.HttpMethod = value
        End Set
    End Property
    Property ResultCode() As String
        Get
            Return obj.ResultCode
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Property TimeOut() As String
        Get
            Return obj.TimeOut
        End Get
        Set(ByVal value As String)
            obj.TimeOut = value
        End Set
    End Property
    Property TimeDelay() As String
        Get
            Return obj.TimeDelay
        End Get
        Set(ByVal value As String)
            obj.TimeDelay = value
        End Set
    End Property
    Property Headers() As String
        Get
            Return obj.Headers
        End Get
        Set(ByVal value As String)
            obj.Headers = value
        End Set
    End Property
    Property CookiesQueries() As String
        Get
            Return obj.CookiesQueries
        End Get
        Set(ByVal value As String)
            obj.CookiesQueries = value
        End Set
    End Property
    Public Property ResultQuery() As String
        Get
            Return obj.ResultQuery
        End Get
        Set(ByVal value As String)
            obj.ResultQuery = value
        End Set
    End Property
    Property FileDownloading() As String
        Get
            Return DaOrNet(obj.FileDownloading)
        End Get
        Set(ByVal value As String)
            obj.FileDownloading = DaOrNet(value)
        End Set
    End Property
    Property DownloadPause() As String
        Get
            Return DaOrNet(obj.DownloadPause)
        End Get
        Set(ByVal value As String)
            obj.DownloadPause = DaOrNet(value)
        End Set
    End Property
    Property BufferSize() As String
        Get
            Return obj.BufferSize
        End Get
        Set(ByVal value As String)
            obj.BufferSize = value
        End Set
    End Property
    Property CheckConnect() As String
        Get
            If isDevelop And isRUN() = False Then Return True
            Return DaOrNet(obj.CheckConnect)
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Sub ClearCookie()
        CookiesQueries = ""
    End Sub
    Sub GetSourceCodePage(ByVal ParamArray args() As String)  ' ПОЛУЧИТЬ КОД СТРАНИЦЫ
        Try
            obj.GetSourceCodePage(args(0))
        Catch ex As Exception
            If IgnorEr = False Then Throw ex
        End Try
    End Sub
    Sub DownloadFile(ByVal ParamArray args() As String)  ' СКАЧАТЬ ФАЙЛ
        Try
            obj.DownloadFile(args(0), DaOrNet(args(1)))
        Catch ex As Exception
            obj.FileDownloading = False
            If IgnorEr = False Then Throw ex
        End Try
    End Sub
    Public Sub ExecuteQuery() ' ВЫПОЛНИТЬ ПРОСТО ЗАПРОС
        Try
            obj.ExecuteQuery()
        Catch ex As Exception
            If IgnorEr = False Then Throw ex
        End Try
    End Sub
    Public Sub DownloadCancel()
        obj.DownloadCancel()
    End Sub
    Public Sub DownloadResume()
        obj.DownloadResume()
    End Sub

    ' ПрогрессБар
    Overloads Property StyleProgress() As String
        Get
            Return StylesProgress.GetKey(StylesProgress.IndexOfValue(obj.Style))
        End Get
        Set(ByVal value As String)
            obj.Style = StylesProgress.GetByIndex(StylesProgress.IndexOfKey(LCase(value)))
        End Set
    End Property
    Property MarqueeAnimationSpeed() As String
        Get
            Return obj.MarqueeAnimationSpeed
        End Get
        Set(ByVal value As String)
            obj.MarqueeAnimationSpeed = value
        End Set
    End Property
    Property StepProgress() As String
        Get
            Return obj.Step
        End Get
        Set(ByVal value As String)
            obj.Step = value
        End Set
    End Property
    Property RightToLeftLayout() As String
        Get
            Return DaOrNet(obj.RightToLeftLayout)
        End Get
        Set(ByVal value As String)
            obj.RightToLeftLayout = DaOrNet(value)
        End Set
    End Property


    ' Простейшие методы
    Sub Refresh()
        obj.Refresh()
        If Iz.IsMd(obj.MyObj) Then Fit()
    End Sub
    Sub Focus()
        obj.Focus()
        Try
            obj.select()
        Catch ex As Exception
        End Try
    End Sub
    Sub BringToFront()
        obj.BringToFront()
    End Sub
    Sub SendToBack()
        obj.SendToBack()
    End Sub
    Sub Clear()
        obj.items.clear()
    End Sub
    Sub Cut()
        obj.Cut()
    End Sub
    Sub Copy()
        obj.Copy()
    End Sub
    Sub Paste()
        obj.Paste()
    End Sub
    Sub SelectAll()
        obj.SelectAll()
    End Sub
    Sub Undo()
        obj.Undo()
    End Sub
    Sub Redo()
        obj.Redo()
    End Sub
    Sub GoBack()
        obj.GoBack()
    End Sub
    Sub GoForward()
        obj.GoForward()
    End Sub
    Sub GoHome()
        obj.GoHome()
    End Sub
    Sub GoSearch()
        obj.GoSearch()
    End Sub
    Sub Printing()
        obj.Print()
    End Sub
    Sub ShowPageSetupDialog()
        obj.ShowPageSetupDialog()
    End Sub
    Sub ShowPrintDialog()
        obj.ShowPrintDialog()
    End Sub
    Sub ShowPrintPreviewDialog()
        obj.ShowPrintPreviewDialog()
    End Sub
    Sub ShowPropertiesDialog()
        obj.ShowPropertiesDialog()
    End Sub
    Sub ShowSaveAsDialog()
        obj.ShowSaveAsDialog()
    End Sub
    Sub [Stop]()
        obj.Stop()
    End Sub
    Sub Hide()
        obj.Hide()
    End Sub
    Sub Close()
        If DaOrNet(Me.MainForm) Then
            Dim po As New PropertysOther(obj)
            po.BreakApplication()
        End If
        obj.Close()
    End Sub
    Sub Show()
        obj.Show()
        obj.focus()
    End Sub
    Sub ClearTable()
        If isDBconnect() Then
            Dim i As Integer
            For i = obj.rows.count - 1 To 0 Step -1
                If obj.Rows(i).IsNewRow = False Then obj.Rows.removeAt(i)
            Next
        Else
            obj.Rows.Clear()
        End If
    End Sub
    Sub ScrollToCaret()
        obj.ScrollToCaret()
    End Sub
    Sub Print()
        obj.PrintDoc.Print()
    End Sub
    Sub Start()
        obj.Start()
    End Sub
    Dim Intr As Integer = 100
    Overloads Property Interval() As Integer
        Get
            Return Intr
        End Get
        Set(ByVal value As Integer)
            Intr = value
        End Set
    End Property
    Dim IntrCou As Integer = 0
    Overloads Property IntervalCount() As Integer
        Get
            Return IntrCou
        End Get
        Set(ByVal value As Integer)
            IntrCou = value
        End Set
    End Property
End Class

Public Class PropertysRun
    Inherits Propertys
    Sub New(ByVal ob As Object)
        MyBase.New(ob)
    End Sub
    Overloads Property Enabled() As String
        Get
            Return MyBase.Enabled
        End Get
        Set(ByVal value As String)
            MyBase.Enabled = value
            If Iz.IsW(obj.myobj) = False Then obj.Enabled = DaOrNet(MyBase.Enabled)
        End Set
    End Property
    Overloads Property Visible() As String
        Get
            Return MyBase.Visible
        End Get
        Set(ByVal value As String)
            MyBase.Visible = value
            obj.Visible = DaOrNet(MyBase.Visible)
        End Set
    End Property
    Overloads Property ContextMenu(Optional ByVal fromLoad As Boolean = False) As String
        Get
            Return MyBase.ContextMenu
        End Get
        Set(ByVal value As String)
            MyBase.ContextMenu = value
            If fromLoad = False Then AddContextMenu()
        End Set
    End Property
    Overloads Property ContextMenu1(Optional ByVal fromLoad As Boolean = False) As String
        Get
            Return MyBase.ContextMenu1
        End Get
        Set(ByVal value As String)
            MyBase.ContextMenu1 = value
            If fromLoad = False Then AddContextMenu("panel1")
        End Set
    End Property
    Overloads Property ContextMenu2(Optional ByVal fromLoad As Boolean = False) As String
        Get
            Return MyBase.ContextMenu2
        End Get
        Set(ByVal value As String)
            MyBase.ContextMenu2 = value
            If fromLoad = False Then AddContextMenu("panel2")
        End Set
    End Property
    Overloads Property Height() As Integer
        Get
            If Iz.IsFORM(obj.MyObj) Then Return obj.Height - CaptionHeight
            Return obj.Height
        End Get
        Set(ByVal value As Integer)
            If Iz.IsFORM(obj.MyObj) Then value += CaptionHeight
            obj.Height = value
        End Set
    End Property
    Overloads Property Width() As Integer
        Get
            If Iz.IsFORM(obj.MyObj) Then Return obj.Width - CaptionWidth
            Return obj.Width
        End Get
        Set(ByVal value As Integer)
            If Iz.IsFORM(obj.MyObj) Then value += CaptionWidth
            obj.Width = value
        End Set
    End Property
    Overloads Property MaximumHeight() As Integer
        Get
            If Iz.IsFORM(obj.MyObj) Then
                If obj.MaximumSize.Height - CaptionHeight > 0 Then
                    Return obj.MaximumSize.Height - CaptionHeight
                Else
                    Return 0
                End If
            End If
            Return obj.MaximumSize.Height
        End Get
        Set(ByVal value As Integer)
            If Iz.IsFORM(obj.MyObj) And value <> 0 Then
                obj.MaximumSize = New Size(MaximumWidth + CaptionWidth, value + CaptionHeight)
                Exit Property
            End If
            obj.MaximumSize = New Size(MaximumWidth, value)
        End Set
    End Property
    Overloads Property MaximumWidth() As Integer
        Get
            If Iz.IsFORM(obj.MyObj) Then
                If obj.MaximumSize.Width - CaptionWidth > 0 Then
                    Return obj.MaximumSize.Width - CaptionWidth
                Else
                    Return 0
                End If
            End If
            Return obj.MaximumSize.Width
        End Get
        Set(ByVal value As Integer)
            If Iz.IsFORM(obj.MyObj) And value <> 0 Then
                obj.MaximumSize = New Size(value + CaptionWidth, MaximumHeight + CaptionHeight)
                Exit Property
            End If
            obj.MaximumSize = New Size(value, MaximumHeight)
        End Set
    End Property
    Overloads Property X() As Integer
        Get
            Return obj.left
        End Get
        Set(ByVal value As Integer)
            obj.left = value
        End Set
    End Property
    Overloads Property Y() As Integer
        Get
            Return obj.top
        End Get
        Set(ByVal value As Integer)
            obj.top = value
        End Set
    End Property
    Overloads Property SplitterDistance() As Integer
        Get
            Return obj.SplitterDistance
        End Get
        Set(ByVal value As Integer)
            obj.SplitterDistance = value
        End Set
    End Property
    Public nadoProigrat As Boolean = False
    Public Overloads Property Played() As String
        Get
            Dim strStatus As String = Space(128)
            If mciSendString("STATUS " & strAlias & " MODE", strStatus, Len(strStatus), IntPtr.Zero) = 0 Then
                strStatus = Replace(Trim(strStatus), Chr(0), "")
                Return DaOrNet(strStatus = "playing")
            End If
            Return trans("Нет")
        End Get
        Set(ByVal value As String)
            If DaOrNet(value) Then
                If MediaWindow Is Nothing Then nadoProigrat = True : Exit Property
                PlayMovie()
            End If
        End Set
    End Property
    Dim ur As Uri
    Overloads Property Url() As String
        Get
            If obj.url Is Nothing Then Return ur.AbsoluteUri
            Return obj.Url.AbsoluteUri
        End Get
        Set(ByVal value As String)
            ur = GetUrlFromString(value)
            If ur Is Nothing = False Then
                obj.Url = ur
            End If
        End Set
    End Property
    Overloads Property MainMenuStrip(Optional ByVal fromLoad As Boolean = False) As String
        Get
            Return MyBase.MainMenuStrip
        End Get
        Set(ByVal value As String)
            MyBase.MainMenuStrip = value
            If fromLoad = False Then AddContextMenu(, True)
        End Set
    End Property
    Overloads Property Icon() As String
        Get
            Return MyBase.Icon
        End Get
        Set(ByVal value As String)
            MyBase.Icon = value
            If IsHttpCompil = False Then
                If NikakoiEsli(value) <> trans("Никакой") Then
                    Try
                        obj.Icon = New Icon(value)
                    Catch ex As Exception
                        obj.Icon = Nothing
                        If IgnorEr = False Then Errors.MessangeCritic(ex.Message & notIcon(value))
                    End Try
                Else
                    obj.Icon = Nothing
                End If
            End If
            If IsFORMRunObj(obj) Then obj.ni.icon = obj.Icon
        End Set
    End Property
    Overloads Property StartPosition() As String
        Get
            Return MyBase.StartPosition
        End Get
        Set(ByVal value As String)
            MyBase.StartPosition = value
            obj.StartPosition = StartPositions.GetByIndex(StartPositions.IndexOfKey(LCase(value)))
            ''obj.Left = MyBase.X : obj.Top = MyBase.Y
        End Set
    End Property
    Overloads Property WindowState() As String
        Get
            Return WindowStates.GetKey(WindowStates.IndexOfValue(obj.WindowState))
        End Get
        Set(ByVal value As String)
            MyBase.WindowState = value
            obj.WindowState = WindowStates.GetByIndex(WindowStates.IndexOfKey(LCase(value)))
        End Set
    End Property
    Overloads Property FormBorderStyle() As String
        Get
            Return MyBase.FormBorderStyle
        End Get
        Set(ByVal value As String)
            MyBase.FormBorderStyle = value
            obj.FormBorderStyle = FormBorderStyles.GetByIndex(FormBorderStyles.IndexOfKey(LCase(value)))
        End Set
    End Property
    Public Property Opacity() As Integer
        Get
            Return MyBase.Opacity
        End Get
        Set(ByVal Value As Integer)
            MyBase.Opacity = Value
            obj.Opacity = Value / 100
        End Set
    End Property
    Overloads Property ShowIcon() As String
        Get
            Return MyBase.ShowIcon
        End Get
        Set(ByVal value As String)
            MyBase.ShowIcon = value
            obj.ShowIcon = DaOrNet(value)
        End Set
    End Property
    Overloads Property ShowInTaskbar() As String
        Get
            Return MyBase.ShowInTaskbar
        End Get
        Set(ByVal value As String)
            MyBase.ShowInTaskbar = value
            obj.ShowInTaskbar = DaOrNet(value)
        End Set
    End Property
    Overloads Property ControlBox() As String
        Get
            Return MyBase.ControlBox
        End Get
        Set(ByVal value As String)
            MyBase.ControlBox = value
            obj.ControlBox = DaOrNet(value)
        End Set
    End Property
    Overloads Property TopMost() As String
        Get
            Return MyBase.TopMost
        End Get
        Set(ByVal value As String)
            MyBase.TopMost = value
            obj.TopMost = DaOrNet(value)
        End Set
    End Property
    Overloads Property TransparentcyKey() As String
        Get
            Return MyBase.TransparentcyKey
        End Get
        Set(ByVal value As String)
            MyBase.TransparentcyKey = value
            If NikakoiEsli(value) = trans("Никакой") Then
                obj.TransparencyKey = Nothing
            Else
                obj.TransparencyKey = FromMyColor(value)
            End If
        End Set
    End Property
    Overloads Property SelectedTabPosition() As Integer
        Get
            Return obj.selectedIndex
        End Get
        Set(ByVal value As Integer)
            obj.selectedIndex = value
        End Set
    End Property
    Overloads Property ReadOnlyTable() As String
        Get
            Return MyBase.ReadOnlyTable
        End Get
        Set(ByVal value As String)
            MyBase.ReadOnlyTable = value
            obj.ReadOnly = DaOrNet(value)
        End Set
    End Property
    Overloads Property SelectedIndex() As Integer
        Get
            Return obj.SelectedIndex
        End Get
        Set(ByVal value As Integer)
            MyBase.SelectedIndex = value
            If Iz.IsL(obj.myobj) Then
                If obj.selectionmode = 0 Then Exit Property
            End If
            obj.SelectedIndex = value
        End Set
    End Property
    Overloads Property SelectedItem() As String
        Get
            Return obj.SelectedItem
        End Get
        Set(ByVal value As String)
            MyBase.SelectedItem = value
            If Iz.IsL(obj.myobj) Then
                If obj.selectionmode = 0 Then Exit Property
            End If
            obj.SelectedItem = value
        End Set
    End Property
    Overloads Property Text() As String
        Get
            Return obj.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            obj.Text = value
        End Set
    End Property
    Overloads Property DialogColor() As String
        Get
            Return ToMyColor(obj.Color)
        End Get
        Set(ByVal value As String)
            If NikakoiEsli(value) = trans("Никакой") Then
                Try
                    obj.color = Color.Transparent
                Catch ex As Exception
                    If IgnorEr = False Then Errors.MessangeExclamen(ex.Message)
                End Try
            Else
                obj.Color = FromMyColor(value)
            End If
        End Set
    End Property
    Overloads Property ShowColor() As String
        Get
            Return DaOrNet(obj.ShowColor)
        End Get
        Set(ByVal value As String)
            obj.ShowColor = DaOrNet(value)
        End Set
    End Property
    Overloads Property ShowEffects() As String
        Get
            Return DaOrNet(obj.ShowEffects)
        End Get
        Set(ByVal value As String)
            obj.ShowEffects = DaOrNet(value)
            obj.ShowColor = True
        End Set
    End Property
    Overloads Property Description() As String
        Get
            Return obj.dialog.Description
        End Get
        Set(ByVal value As String)
            obj.dialog.Description = value
        End Set
    End Property
    Overloads Property SelectedPath() As String
        Get
            Return obj.dialog.SelectedPath
        End Get
        Set(ByVal value As String)
            obj.dialog.SelectedPath = value
        End Set
    End Property
    Overloads Property DefaultExt() As String
        Get
            Return obj.dialog.DefaultExt
        End Get
        Set(ByVal value As String)
            obj.dialog.DefaultExt = value
        End Set
    End Property
    Overloads Property CheckFileExists() As String
        Get
            Return DaOrNet(obj.dialog.CheckFileExists)
        End Get
        Set(ByVal value As String)
            obj.dialog.CheckFileExists = DaOrNet(value)
        End Set
    End Property
    Overloads Property CheckPathExists() As String
        Get
            Return DaOrNet(obj.dialog.CheckPathExists)
        End Get
        Set(ByVal value As String)
            obj.dialog.CheckPathExists = DaOrNet(value)
        End Set
    End Property
    Overloads Property FileName() As String
        Get
            Return Join(obj.dialog.FileNames, "; ")
        End Get
        Set(ByVal value As String)
            obj.dialog.FileName = value
        End Set
    End Property
    Overloads Property Filter() As String
        Get
            Return obj.dialog.Filter
        End Get
        Set(ByVal value As String)
            Try
                obj.dialog.Filter = value
            Catch ex As Exception
                If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
            End Try
        End Set
    End Property
    Overloads Property FilterIndex() As String
        Get
            Return obj.dialog.FilterIndex
        End Get
        Set(ByVal value As String)
            Try
                obj.dialog.FilterIndex = value
            Catch ex As Exception
                If IgnorEr = False Then Errors.MessangeCritic(ex.Message)
            End Try
        End Set
    End Property
    Overloads Property InitialDirectory() As String
        Get
            Return obj.dialog.InitialDirectory
        End Get
        Set(ByVal value As String)
            obj.dialog.InitialDirectory = value
        End Set
    End Property
    Overloads Property Title() As String
        Get
            Return obj.dialog.Title
        End Get
        Set(ByVal value As String)
            obj.dialog.Title = value
        End Set
    End Property
    Overloads Property MultiSelectFiles() As String
        Get
            Return DaOrNet(obj.dialog.MultiSelect)
        End Get
        Set(ByVal value As String)
            obj.dialog.MultiSelect = DaOrNet(value)
        End Set
    End Property
    Overloads Property Interval() As Integer
        Get
            Return obj.Interval
        End Get
        Set(ByVal value As Integer)
            MyBase.Interval = value
            obj.Interval = value
        End Set
    End Property
    Overloads Property AssociateWithExtensions() As String
        Get
            Return MyBase.AssociateWithExtensions
        End Get
        Set(ByVal value As String)
            Dim i As Integer
            Dim pname As String = IO.Path.GetFileNameWithoutExtension(proj.pFileName)
            Dim exts() As String = value.Replace("""", "").Split(",")
            For i = 0 To exts.Length - 1
                exts(i) = exts(i).Trim
                If exts(i) <> "" Then
                    AssociateMyApp(pname, Environment.GetCommandLineArgs()(0), exts(i), Icon)
                End If
            Next
        End Set
    End Property
    Overloads Property AssociationPassedFile() As String
        Get
            If Environment.GetCommandLineArgs().Length >= 2 Then
                Dim result As String = ""
                For i As Integer = 1 To Environment.GetCommandLineArgs().Length - 1
                    result &= Environment.GetCommandLineArgs()(i) & " "
                Next
                result = result.Trim()
                Return result
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Overloads Property ForbidMaximize() As String
        Get
            Return DaOrNet(Not obj.MaximizeBox)
        End Get
        Set(ByVal value As String)
            obj.MaximizeBox = Not DaOrNet(value)
        End Set
    End Property
    Overloads Property ForbidMinimize() As String
        Get
            Return DaOrNet(Not obj.MinimizeBox)
        End Get
        Set(ByVal value As String)
            obj.MinimizeBox = Not DaOrNet(value)
        End Set
    End Property
    Dim f As Form
    Public Overloads Property OnFullScreen() As String
        Get
            Return MyBase.OnFullScreen
        End Get
        Set(ByVal value As String)
            MyBase.OnFullScreen = value
            If DaOrNet(value) Then
                f = New Form
                f.WindowState = FormWindowState.Maximized
                f.BackColor = Color.Black
                f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                f.ShowInTaskbar = False
                f.TopMost = True
                PlayInNewHandle(f)
                f.Show()
            Else
                If f IsNot Nothing Then
                    PlayInNewHandle(obj)
                    f.Close()
                End If
            End If
        End Set
    End Property

    ' Присвоение контекстного меню
    Public Sub AddContextMenu(Optional ByVal panel As String = "", Optional ByVal mainmenu As Boolean = False)
        Dim CxtMenu As String = ContextMenu
        If mainmenu Then CxtMenu = MainMenuStrip
        If panel = "panel1" Then
            CxtMenu = ContextMenu1
        ElseIf panel = "panel2" Then
            CxtMenu = ContextMenu2
        End If
        If NikakoiEsli(CxtMenu) <> trans("Никакой") Then

            ' Получить контекстное меню по имени
            Dim myO As Object = obj.MyObj : If myO Is Nothing Then Exit Sub
            Dim myF As Object = myO.getmyform : If myF Is Nothing Then Exit Sub
            Dim CnMn = GetContextMenu(myO, CxtMenu)

            ' присвоить объекту его, если таковое существует
            If CnMn Is Nothing = False Then
                If panel = "" Then
                    If mainmenu Then
                        obj.MainMenuStrip = CnMn.obj
                    Else
                        obj.ContextMenuStrip = CnMn.obj.CnMn
                        If IsFORMRunObj(obj) Then obj.ni.ContextMenuStrip = obj.ContextMenuStrip
                    End If
                ElseIf panel = "panel1" Then
                    obj.Panel1.ContextMenuStrip = CnMn.obj.CnMn
                ElseIf panel = "panel2" Then
                    obj.Panel2.ContextMenuStrip = CnMn.obj.CnMn
                End If
            Else
                ' Если проект полностью загрузился
                If myF.MyObjs Is Nothing = False Then
                    Errors.MessangeExclamen(Errors.InvalidContextMenu(CxtMenu, Name))
                End If
            End If
        Else
            If panel = "" Then
                If mainmenu Then
                    obj.MainMenuStrip = Nothing
                Else
                    obj.ContextMenuStrip = Nothing
                End If
            ElseIf panel = "panel1" Then
                obj.Panel1.ContextMenuStrip = Nothing
            ElseIf panel = "panel2" Then
                obj.Panel2.ContextMenuStrip = Nothing
            End If
        End If
    End Sub
End Class


