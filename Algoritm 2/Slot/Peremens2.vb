' МОДУЛЬ ДЛЯ ОБХОДА ОТЛИЧИЙ МЕЖДУ СРЕДОЙ РАЗРАБОТКИ И КОМПИЛЯТОРОМ
Imports System.Diagnostics

Module peremens2
    Public MnFrm As MainForm = Application.OpenForms.Item("MainForm") ' Главная форма
    Public MnFrmPotok As MainForm = Application.OpenForms.Item("MainForm") ' Главная форма

    Public proj As Project ' Проект, сейчас запущенный

    Public CreateDs As CreateDeistv
    Public CreateIfs As CreateIf
    Public CreateCycles As CreateCycle
    Public EditPrComm As EditProperty

    Public intr As Object = New intro
    Public ProgressForm As New Progress

    Public lwEditProperty As EditProperty ' Мой элемент

    ' ДВУСВЯЗНЫЙ СПИСОК БЛОКОВ, КОТОРЫЕ ВЫСТРАИВАЮТСЯ В РЯД В МАСТЕРЕ ДЕЙСТВИЙ
    Public Structure BlokiVRyad
        Dim top As Blok
        Sub Add(ByVal bl As Blok)
            If top Is Nothing Then
                top = bl
            Else
                Dim temp As Blok = Last()
                temp.rLink = bl : bl.lLink = temp
            End If
        End Sub
        Sub Insert(ByVal bl As Blok, Optional ByVal pered As Blok = Nothing)
            If pered Is Nothing Then pered = top
            If pered Is Nothing Then
                top = bl
            ElseIf pered.lLink Is Nothing Then
                pered.lLink = bl : bl.rLink = pered : top = bl
            Else
                Dim temp As Blok = pered.lLink
                pered.lLink = bl : bl.lLink = temp : temp.rLink = bl : bl.rLink = pered
            End If
        End Sub
        Function Last() As Blok
            Dim bl As Blok = top
            Do Until bl.rLink Is Nothing : bl = bl.rLink : Loop
            Return bl
        End Function
        Sub Remove(ByVal bl As Blok)
            Dim temp As Blok = top, i As Integer
            If bl Is top Then
                If bl.rLink Is Nothing Then Exit Sub
                top = bl.rLink : top.lLink = Nothing
            ElseIf bl Is Last() Then
                bl.lLink.rLink = Nothing
            Else
                bl.lLink.rLink = bl.rLink : bl.rLink.lLink = bl.lLink
            End If
            For i = 0 To bl.Tag.length - 1 : bl.Tag(i).Dispose() : Next : bl.Dispose()
        End Sub
    End Structure

    Public Sub ShowPropInEditProperty(ByVal EditPr As EditProperty)
        Dim PropValue As String = "", kovi As String = ""
        With EditPr
            If .MayChangeProperty = False Then kovi = """"
            If .type = "" Then
                .EditText.Visible = True : .ActiveTextBox = .TextBox1
            ElseIf .type = trans("Текст") Or .type = trans("Число") Then
                .EditText.Visible = True : .ActiveTextBox = .TextBox1
                PropValue = proj.ActiveForm.GetPropertys(.prop, .MyObjs).str
            ElseIf .type = trans("Рисунок") Then
                .TextBox2.Left = .PictureBox1.Left + .PictureBox1.Width : .TextBox2.Width = .Button2.Left - 1 - .PictureBox1.Width
                .EditPicColor.Visible = True : .Button1.Visible = True : .Button2.Visible = False : .PictureBox1.Visible = True
                .ActiveTextBox = .TextBox2
                PropValue = GetMinPath(proj.ActiveForm.GetPropertys(.prop, .MyObjs).str)
                If PropValue <> trans("Никакой") Then
                    Try
                        .PictureBox1.Image = Image.FromFile(UbratKovich(GetMaxPath(PropValue)).str)
                    Catch ex As Exception
                        .PictureBox1.Image = Nothing
                    End Try
                    .PictureBox1.BackColor = Color.Transparent
                Else
                    .PictureBox1.Image = Nothing : .PictureBox1.BackColor = SystemColors.Control
                End If
            ElseIf .type = trans("Файл") Then
                .TextBox2.Left = .PictureBox1.Left : .TextBox2.Width = .Button2.Left - 1
                .EditPicColor.Visible = True : .Button1.Visible = True : .Button2.Visible = False : .PictureBox1.Visible = False
                .ActiveTextBox = .TextBox2
                PropValue = GetMinPath(proj.ActiveForm.GetPropertys(.prop, .MyObjs).str)
            ElseIf .type = trans("Цвет") Then
                .EditPicColor.Visible = True : .PictureBox1.Image = Nothing
                .Button1.Visible = False : .Button2.Visible = True : .ActiveTextBox = .TextBox2
                PropValue = proj.ActiveForm.GetPropertys(.prop, .MyObjs).str
                If PropValue <> trans("Никакой") Then
                    Try
                        .PictureBox1.BackColor = FromMyColor(PropValue)
                    Catch ex As Exception
                        .PictureBox1.BackColor = Color.Transparent
                    End Try
                Else
                    .PictureBox1.BackColor = Color.Transparent
                End If
            Else
                .EditOther.Visible = True : .ActiveTextBox = .TextBox3
                If proj.ActiveForm Is Nothing Then Exit Sub
                PropValue = proj.ActiveForm.GetPropertys(.prop, .MyObjs).str
                .Button3.Visible = True : .List.Items.Clear()
                If UCase(.type) = UCase(trans("ДаНет")) Then
                    .List.Items.AddRange(HWDaNet) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Привязка")) Then
                    .List.Items.AddRange(HWAnchors) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль фона")) Or UCase(.type) = UCase(trans("Стиль фона1")) _
                Or UCase(.type) = UCase(trans("Стиль фона2")) Then
                    .List.Items.AddRange(HWbkImStyles) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Курсор")) Or UCase(.type) = UCase(trans("Курсор1")) _
                Or UCase(.type) = UCase(trans("Курсор2")) Then
                    .List.Items.AddRange(HWCursori) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Растяжка")) Then
                    .List.Items.AddRange(HWDocks) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль кнопки")) Then
                    .List.Items.AddRange(HWFlatStyles) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль рамки")) Then
                    .List.Items.AddRange(HWBorderStyles) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Шрифт")) Or UCase(.type) = UCase(trans("Выделенный Шрифт")) Then
                    .List.Items.AddRange(HWFonts) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Положение")) Then
                    .List.Items.AddRange(HWAligns) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Текст и рисунок")) Then
                    .List.Items.AddRange(HWTextImages) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Фиксированная часть")) Then
                    .List.Items.AddRange(HWFixedPanels) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Ориентация инструментов")) Or UCase(.type) = UCase(trans("Ориентация")) Then
                    .List.Items.AddRange(HWOrientations) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = MyZnak & UCase(trans("Стиль рабочего стола")) Then
                    .List.Items.AddRange(HWDeskStyle) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = MyZnak & UCase(trans("Разрешение экрана")) Then
                    .List.Items.AddRange(HWDeskResolution) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = MyZnak & UCase(trans("Тип ключа")) Or UCase(.type) = UCase(trans("Тип ключа")) Then
                    .List.Items.AddRange(HWTypeRegistry) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Полосы прокрутки")) Then
                    .List.Items.AddRange(HWScrollBarz) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль отображения")) Then
                    .List.Items.AddRange(HWDisplayStyles) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Направление текста")) Then
                    .List.Items.AddRange(HWTextDirections) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Статус готовности")) Then
                    .List.Items.AddRange(HWReadyStates) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Кодировка")) Or UCase(.type) = UCase(trans("Кодировка по умолчанию")) _
                Or UCase(.type) = UCase(trans("Кодировка страницы")) Then
                    .List.Items.AddRange(HWDocumentEncodings) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Обновить страницу")) Then
                    .List.Items.AddRange(HWRefreshs) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль окна")) Then
                    .List.Items.AddRange(HWFormBorderStyles) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стартовая позиция")) Then
                    .List.Items.AddRange(HWStartPositions) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Статус окна")) Then
                    .List.Items.AddRange(HWWindowStates) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Положение закладок")) Then
                    .List.Items.AddRange(HWAlignments) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль рамки ячейки")) Then
                    .List.Items.AddRange(HWCellBorderStyles) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Режим выделения")) Then
                    .List.Items.AddRange(HWSelectionModes) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Режим редактирования")) Then
                    .List.Items.AddRange(HWEditModes) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Область выборки")) Then
                    .List.Items.AddRange(HWFilters) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль подчеркивания")) Then
                    .List.Items.AddRange(HWLinkBehaviors) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Расположение текста")) Then
                    .List.Items.AddRange(HWTextPositions) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Кнопки сообщения")) Then
                    .List.Items.AddRange(HWMsgStyleButtons) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Горячая клавиша")) Then
                    .List.Items.Add("control; alt; shift; a;") : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Тип сообщения")) Then
                    .List.Items.AddRange(HWMsgStyleTypes) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Тип базы данных")) Then
                    .List.Items.AddRange(HWBdTypes) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Формат даты")) Then
                    .List.Items.AddRange(HWDateFormats) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль бегунка")) Then
                    .List.Items.AddRange(HWTickStyles) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Кодировка текста")) Then
                    .List.Items.AddRange(HWFileEncodings) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль рисунка")) Then
                    .List.Items.AddRange(HWSizeModes) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Разрешить вводить")) Then
                    .List.Items.AddRange(HWInputTypes) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Тип клиент сервера")) Then
                    .List.Items.AddRange(HWClientServerTypes) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Тип содержимого")) _
                Or UCase(.type) = UCase(trans("Тип файла")) Then
                    .List.Items.AddRange(HWContentTypes) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Метод запроса")) Then
                    .List.Items.AddRange(HWHttpMethods) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Стиль загрузки")) Then
                    .List.Items.AddRange(HWStylesProgress) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Ассоциировать с расширениями")) Then
                    Dim strs() As String = {""".txt""", """.jpg, .gif, .bmp""", """.mp3, .wav""", """.avi, .mpeg, .vob"""}
                    .List.Items.AddRange(strs) : .List.Height = 10 + .List.ItemHeight * .List.Items.Count

                ElseIf UCase(.type) = UCase(trans("Всплывающее меню")) Then
                    Dim i As Integer
                    ' Создание списка контекстных меню
                    For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                        If Iz.IsCM(proj.ActiveForm.MyObjs(i)) Then
                            If proj.ActiveForm.MyObjs(i).obj.Props.index = 0 Then
                                .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & kovi)
                            Else
                                .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & _
                                                "[" & proj.ActiveForm.MyObjs(i).obj.Props.index & "]" & kovi)
                            End If
                        End If
                    Next
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Документ на печать")) Then
                    Dim i As Integer
                    ' Создание списка контекстных меню
                    For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                        If Iz.IsRT(proj.ActiveForm.MyObjs(i)) Then
                            If proj.ActiveForm.MyObjs(i).obj.Props.index = 0 Then
                                .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & kovi)
                            Else
                                .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & _
                                                "[" & proj.ActiveForm.MyObjs(i).obj.Props.index & "]" & kovi)
                            End If
                        End If
                    Next
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Таблица на печать")) Then
                    Dim i As Integer
                    ' Создание списка контекстных меню
                    For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                        If Iz.IsTl(proj.ActiveForm.MyObjs(i)) Then
                            If proj.ActiveForm.MyObjs(i).obj.Props.index = 0 Then
                                .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & kovi)
                            Else
                                .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & _
                                                "[" & proj.ActiveForm.MyObjs(i).obj.Props.index & "]" & kovi)
                            End If
                        End If
                    Next
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Объект на печать")) Or UCase(.type) = UCase(trans("Объект съемки")) Then
                    Dim i As Integer
                    ' Создание списка контекстных меню
                    For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                        .List.Items.Add(kovi & GetUNameObj(proj.ActiveForm.MyObjs(i)) & kovi)
                    Next
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Главное меню")) Then
                    Dim i As Integer
                    ' Создание списка глваных меню
                    For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                        If Iz.IsMM(proj.ActiveForm.MyObjs(i)) Then
                            If proj.ActiveForm.MyObjs(i).obj.Props.index = 0 Then
                                .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & kovi)
                            Else
                                .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & _
                                                "[" & proj.ActiveForm.MyObjs(i).obj.Props.index & "]" & kovi)
                            End If
                        End If
                    Next
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Хозяин объект")) Then
                    Dim i As Integer
                    ' Создание списка глваных меню
                    For i = 0 To proj.ActiveForm.MyObjs.Length - 1
                        If proj.ActiveForm.MyObjs(i).obj.Props.index = 0 Then
                            .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & kovi)
                        Else
                            .List.Items.Add(kovi & proj.ActiveForm.MyObjs(i).obj.Props.name & _
                                            "[" & proj.ActiveForm.MyObjs(i).obj.Props.index & "]" & kovi)
                        End If
                    Next
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count

                ElseIf UCase(.type) = UCase(trans("Позиция")) Then
                    Dim i, max As Integer
                    ' Определение максимального количества позиций
                    For i = 0 To .MyObjs.Length - 1
                        If Iz.IsTP(.MyObjs(i).conteiner) Then
                            If max < .MyObjs(i).conteiner.obj.TabCount Then max = .MyObjs(i).conteiner.obj.TabCount
                        End If
                        If Iz.IsMMs(.MyObjs(i).conteiner) Then
                            If max < .MyObjs(i).conteiner.obj.DropDownItems.Count Then max = .MyObjs(i).conteiner.obj.DropDownItems.Count
                        End If
                        If Iz.IsMM(.MyObjs(i).conteiner) Or Iz.IsCM(.MyObjs(i).conteiner) Or Iz.IsTPl(.MyObjs(i).conteiner) Then
                            If max < .MyObjs(i).conteiner.obj.Items.Count Then max = .MyObjs(i).conteiner.obj.Items.Count
                        End If
                    Next
                    For i = 0 To max - 1
                        .List.Items.Add(i)
                    Next
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Номер столбца")) _
                Or UCase(.type) = UCase(trans("Номера столбцов через запятую")) Then
                    Dim i, max As Integer, str() As String = Nothing
                    ' Определение максимального количества позиций
                    If .MyObjs Is Nothing = False Then
                        For i = 0 To .MyObjs.Length - 1
                            If Iz.IsTl(.MyObjs(i)) Then
                                If max < .MyObjs(i).obj.props.ColumnsCount Then max = .MyObjs(i).obj.props.ColumnsCount
                            End If
                        Next
                        For i = 0 To max - 1
                            .List.Items.Add(i) : ReDims(str) : str(str.Length - 1) = i
                        Next
                        If UCase(.type) = UCase(trans("Номера столбцов через запятую")) Then
                            If str IsNot Nothing Then .List.Items.Add("""" & Join(str, ",") & """")
                            .List.Items.Add(trans("Все"))
                        End If
                    End If
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Номер строки")) _
                Or UCase(.type) = UCase(trans("Номера строк через запятую")) Then
                    Dim i, max As Integer, str() As String = Nothing
                    ' Определение максимального количества позиций
                    If .MyObjs Is Nothing = False Then
                        For i = 0 To .MyObjs.Length - 1
                            If Iz.IsTl(.MyObjs(i)) Then
                                If max < .MyObjs(i).obj.props.RowsCount Then max = .MyObjs(i).obj.props.RowsCount
                            End If
                        Next
                        For i = 0 To max - 1
                            .List.Items.Add(i) : ReDims(str) : str(str.Length - 1) = i
                        Next
                        If UCase(.type) = UCase(trans("Номера строк через запятую")) Then
                            If str IsNot Nothing Then .List.Items.Add("""" & Join(str, ",") & """")
                            .List.Items.Add(trans("Все"))
                        End If
                    End If
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Место для записи в списке")) Then
                    Dim i, max As Integer
                    ' Определение максимального количества позиций
                    If .MyObjs Is Nothing = False Then
                        For i = 0 To .MyObjs.Length - 1
                            If Iz.IsCB(.MyObjs(i)) Or Iz.IsL(.MyObjs(i)) Or Iz.IsCL(.MyObjs(i)) Then
                                If max < .MyObjs(i).obj.props.ItemsCount Then max = .MyObjs(i).obj.props.ItemsCount
                            End If
                        Next
                        For i = 0 To max
                            .List.Items.Add(i)
                        Next
                    End If
                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                ElseIf UCase(.type) = UCase(trans("Открытие ссылок нового окна")) Then
                    Dim i, j As Integer, str As String
                    .List.Items.Add(trans("По умолчанию"))
                    .List.Items.Add(trans("В данном браузере"))
                    ' Создание списка браузеров
                    For j = 0 To proj.f.Length - 1
                        For i = 0 To proj.f(j).MyObjs.Length - 1
                            ' Если попался объект браузер
                            If Iz.IsW(proj.f(j).MyObjs(i)) Then
                                If proj.f(j).MyObjs(i).obj.Props.index = 0 Then
                                    str = proj.f(j).MyObjs(i).obj.Props.name
                                Else
                                    str = proj.f(j).MyObjs(i).obj.Props.name & "[" & proj.f(j).MyObjs(i).obj.Props.index & "]"
                                End If
                                .List.Items.Add(kovi & proj.f(j).obj.Props.name & "." & str & kovi)
                            End If
                        Next
                    Next

                    .List.Height = 10 + .List.ItemHeight * .List.Items.Count
                End If

                ListBoxWidthHeight(.List)
            End If
            If PropValue = Nothing Then PropValue = ""
            PropValue = perevesti(PropValue, False)
            ' Если сейчас отображаются а не меняются свойства объектов
            If .MayChangeProperty = False Then
                ' закавычить все что строка а не код
                If .type = trans("Текст") _
                Or (proj.isStr(PropValue) And UbratKovich(PropValue).str = PropValue And Iz.isDouble(PropValue.ToString) = False) Then
                    PropValue = """" & CreateKovich(PropValue) & """"
                End If
            End If
            .ActiveTextBox.Text = PropValue
            .ActiveTextBox.Font = New Font(FontFamily.GenericSansSerif, .ActiveTextBox.Font.Size)
            If UCase(.type) = UCase(trans("Шрифт")) Then
                If Fonts.IndexOfKey(LCase(.ActiveTextBox.Text)) <> -1 Then
                    Try
                        .ActiveTextBox.Font = New Font(.ActiveTextBox.Text.ToString, .ActiveTextBox.Font.Size, .MyObjs(0).obj.Font.Style, .ActiveTextBox.Font.Unit)
                    Catch ex As Exception
                        MsgBox(Errors.FontNotSupport(.ActiveTextBox.Text) & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End If
            End If
            ' Если нельзя изменять свойства объектов из этого элемента то нужно подсвечивать синтаксис
            If .MayChangeProperty = False Then proj.Podsvetka(.ActiveTextBox)
            .ShowHideBut.Visible = True : .ShowHideBut.BringToFront() : .ShowHideBut.BringToFront() : .ShowHideBut.BringToFront() : .ShowHideBut.BringToFront()
        End With
    End Sub

    ' getUserID Получение идиентификационного номера пользователя
    Function LoadProgress() As String
        Dim dt As String = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Hardware\Description\System").GetValue("SystemBiosDate")
        Dim vr As Object = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Hardware\Description\System").GetValue("SystemBiosVersion")
        If IsArray(vr) Then vr = vr(0)
        Dim all As String = dt & vr
        Dim i As Integer, ret As Double
        For i = 0 To all.Length - 1 Step 2
            ret += AscW(all(i))
        Next
        Dim l As Long = Math.Sin(ret) * 1000000000000000000
        ' Расставляем левые буквы в псевдослучайном порядке
        Dim uid As String = Math.Abs(l)
        Dim rn As New Random(uid.Substring(0, 5))
        For i = 0 To uid.Length - 1
            Dim ind As Integer = rn.Next(65, 90)
            Debug.WriteLine(Chr(ind))
            uid = uid.Insert(rn.Next(0, uid.Length), Chr(ind))
        Next
        Return uid
    End Function
    ' GetIDFromKey Получение идиентификационного номера пользователя по ключу регистрации
    Function ElapsedTime(ByVal Key As String) As String
#If Full Or DebugFull Or Http Then
        ' Убираем левые буквы
        Dim i As Integer, k As String = ""
        For i = 0 To Key.Length - 1
            If Char.IsDigit(Key(i)) Then k &= Key(i)
        Next
        If k = "" Then Return 0
        ' Вычисляем ID
        k /= 100000
        Return (k * k + 2 * Math.Sqrt(k)) / (8 * Math.Sqrt(k)) \ 1
#Else
        Return Now.ToShortTimeString
#End If
    End Function
    ' Зарегистрирована ли программа
    Function PerfomanceProgress(Optional ByVal projectName As String = "") As Boolean

        ' ОРИГИНАЛЬНЫЙ АЛГОРИТМ

        'If key = "" Then
        '    Try
        '        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Notepad").GetValue("ShowTimeP")
        '    Catch ex As Exception
        '        Return False
        '    End Try
        '    If key = "" Then Return False
        'End If
        'Dim uid As String = GetIDFromKey(key)
        '' Убираем левые буквы
        'Dim i As Integer, u As String = ""
        'For i = 0 To uid.Length - 1
        '    If Char.IsDigit(uid(i)) Then u &= uid(i)
        'Next
        '' Убираем левые буквы
        'Dim u2 As String = "" : Dim id As String = getUserID()
        'For i = 0 To id.Length - 1
        '    If Char.IsDigit(id(i)) Then u2 &= id(i)
        'Next
        '' Сравниваем
        'Dim l As Long = u2
        'Return (u - 5000 <= l And u + 5000 >= l)

        ' ОБФУСЦИРОВАННЫЙ АЛГОРИТМ

#If Full Or DebugFull Or Http Then
        Dim num As Integer
        Dim str As String
        Dim flag As Boolean
        Dim str2 As String
        Dim str3 As String
        Dim iDFromKey As String
        Dim num3 As Integer
        Dim num4 As Integer
        If (projectName <> "") Then
            GoTo Label_02AE
        End If
        Try
            projectName = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Notepad").GetValue("ShowTimeP")
            GoTo Label_029F
        Catch exception1 As Exception
            Return False
        End Try
        If (num <= UInt32.MaxValue) Then
            If (0 = 0) Then
                GoTo Label_029F
            End If
            GoTo Label_02C9
        End If
        GoTo Label_01E9
Label_00C3:
        If (num <= num4) Then
            GoTo Label_0155
        End If
        Dim num2 As Long = str3
        If (num2 < 0) Then
            GoTo Label_02C9
        End If
        Return ((Convert.ToDouble(str2) - 70000 <= num2) And ((Convert.ToDouble(str2) + 70000) >= num2))
Label_00EA:
        num += 1
        GoTo Label_00C3
Label_00F2:
        If (num2 >= 0) Then
            If (num3 > UInt32.MaxValue) Then
                GoTo Label_00C3
            End If
            If ((num + num3) < 0) Then
                GoTo Label_016C
            End If
            GoTo Label_00EA
        End If
Label_0155:
        If Not Char.IsDigit(str.Chars(num)) Then
            If ((num - num2) > UInt32.MaxValue) Then
                GoTo Label_00F2
            End If
            GoTo Label_00EA
        End If
Label_016C:
        str3 = (str3 & Convert.ToString(str.Chars(num)))
        If (&HFF <> 0) Then
            GoTo Label_00F2
        End If
Label_019B:
        str3 = ""
        If ((flag + num2) >= 0) Then
            str = peremens2.LoadProgress
            If ((num2 + num) >= 0) Then
                num4 = (str.Length - 1)
                num = 0
                GoTo Label_00C3
            End If
            GoTo Label_0155
        End If
Label_01E9:
        If (num <= num3) Then
            If Char.IsDigit(iDFromKey.Chars(num)) Then
                If (((flag) And 0) <> 0) Then
                    GoTo Label_00EA
                End If
                If ((flag - num2) <= UInt32.MaxValue) Then
                    str2 = (str2 & Convert.ToString(iDFromKey.Chars(num)))
                    If (((num3 + num3) <= UInt32.MaxValue) AndAlso ((num4 Or &H7FFFFFFF) = 0)) Then
                        GoTo Label_01E9
                    End If
                End If
            End If
            num += 1
            GoTo Label_01E9
        End If
        GoTo Label_019B
Label_029F:
        If (projectName = "") Then
            GoTo Label_02C9
        End If
Label_02AE:
        Do
            iDFromKey = peremens2.ElapsedTime(projectName)
            str2 = ""
            num3 = (iDFromKey.Length - 1)
            num = 0
        Loop While (0 <> 0)
        GoTo Label_01E9
Label_02C9:
        Return False

#Else
        If projectName = "" Then Return False Else Return True
#End If


    End Function



End Module


