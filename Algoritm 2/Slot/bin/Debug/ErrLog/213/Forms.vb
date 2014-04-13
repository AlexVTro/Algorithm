Public Class Forms
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Работает"), trans("Прокрутка"), trans("Цвет шрифта"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Видимый"), trans("Главная форма"), trans("Запретить закрытие"), _
        trans("Оконные кнопки и меню"), trans("Стиль окна"), trans("Главное меню"), _
        trans("Прозрачность"), trans("Показывать иконку"), trans("Отображать в панели задач"), _
        trans("Стартовая позиция"), trans("Поверх всех окон"), trans("Статус окна"), _
        trans("Прокрутка минимальная ширина"), trans("Прокрутка минимальная вышина"), _
        trans("Прокручено по X"), trans("Прокручено по Y"), trans("Высота заголовка"), _
        trans("Иконка"), trans("Прозрачный цвет"), trans("Тип"), trans("Подсказка"), trans("Отображать в трее"), _
        trans("Добавить в автозагрузку"), trans("Разрешить запуск копий"), _
        trans("Запретить минимизировать"), trans("Запретить разворачивать"), _
        trans("Ассоциировать с расширениями"), trans("Ассоциированый принятый файл") _
      }

    'Запретить минимизировать~~ForbidMinimize
    'Запретить разворачивать~~ForbidMaximize
    'Ассоциировать с расширениями~~AssociateWithExtensions
    'Ассоциированый принятый файл~~AssociationPassedFile

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Скрыть"), trans("Показать"), trans("Получить фокус"), _
                                  trans("Закрыть"), trans("Свернуть в трей"), trans("Развернуть из трея")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), _
                                trans("Закрытие окна"), trans("Прокрутка"), trans("Сворачивание"), _
                                trans("Изменилась видимость"), trans("Двойной клик по трею") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "window"
    Public HistoryLevel As New ArrayList
    Public recur As Boolean
    Dim WithEvents EventObjRun As runF

    Public tab As TabPage
    Public SplitCont As SplitContainer
    Public ActiveObj() As Object ' Активные объекты формы
    Public MyObjs() As Object ' Все объекты формы
    Public ctrl As Boolean

    ' <<<<<<<< ОБЩИЕ ФУНКЦИИ ФОРМЫ >>>>>>>>>
#Region "COMMON"
    Private i


    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal polezniy As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' If holostoi Then CreatePropertySobytsUp(Me) : CreateObject(New F, True) : Exit Sub
        If polezniy Then
            Dim Props() As String = {trans("Имя"), trans("Текст"), trans("Номер")} ' Все свойства данного объекта
            Propertys = Props : CreatePropertySobytsUp(Me)
            Dim poolezForm As New F : poolezForm.TypeObj = "Polezniy"
            MyObjs = PoleznieObjs : CreateObject(poolezForm)
            obj.Props.name = MyZnak & trans("Полезные объекты")
            Exit Sub
        End If
        ' Создание и настройка формы
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        If isRun Then
            CreateObject(New runF, holostoi, isRun, fromEng)
        Else
            CreateObject(New F, holostoi, isRun, fromEng)
        End If
    End Sub
    Function AddObject(ByVal MyObj As Object, Optional ByVal withSelect As Boolean = True) As Object  ' Добавить новый объект на форму
        Dim NewInd As Integer
        If MyObj.obj.props.name = "#NotCreateDP" Then Exit Function
        If proj Is Nothing = False Then
            If proj.f Is Nothing = False Then
                If proj.f.Length <= 1 And MyObj.GetType.ToString <> ClassAplication & "Forms" Then Exit Function
                If isOpening Then Exit Function
            End If
        End If

        If MyObj.obj.Props.name = "" Then Return Nothing
        If MyObjs Is Nothing Then NewInd = 0 Else NewInd = MyObjs.Length ' вычислить индекс нового объекта
        ReDim Preserve MyObjs(NewInd) : MyObjs(NewInd) = MyObj

        If MyObj.obj.TypeObj <> "IncludeObj" Then
            ' Выделить новый объект
            If withSelect Then SetActiveObject(MyObj) : marker_vis(True)
        End If

        If CreateDs Is Nothing = False And isRun = False And proj.ActiveForm IsNot Nothing Then CreateDs.SetProperty(True)
        Return MyObj
    End Function
    Sub TabTextRefresh()
        If isRun Then Exit Sub
        tab.Text = obj.Props.name : tab.Name = obj.Props.name
        If proj Is Nothing Then Exit Sub
        If proj.ExistName(obj.Props.name, obj) Or obj.Props.index <> 0 Then tab.Text &= " (" & obj.Props.index & ")"
    End Sub
    Public Sub SelectTab()
        proj.ActiveForm = MyObj
        MainForm.TabControl1.SelectedTab = MainForm.TabControl1.TabPages(tab.Name)
    End Sub

    ' ВЕРНУТЬ ОБЪЕКТЫ С ТАКИМ ИМЕНЕМ И ИНДЕКСОМ НА ДАННОЙ ФОРМЕ
    Function GetMyObjsFromName(ByVal name As Object, Optional ByVal index As String = "") As Object()
        ' Вернуть объекты с таким именем
        Dim ind = 0, i As Integer, Massive() As Object = Nothing
        If MyObjs Is Nothing Then Return Nothing
        For i = 0 To MyObjs.Length - 1
            ' Если у объекта нужное имя, и не является сам собой
            If MyObjs(i).obj.Props.name = name And MyObjs(i).obj.Props.index.indexof(index) = 0 Then
                ReDim Preserve Massive(ind) : Massive(ind) = MyObjs(i) : ind += 1
            End If
        Next
        Return Massive
    End Function

    Public Sub HistoryLevelRun(ByVal kuda As String, ByVal ParamArray MyObjs() As Object)
        Dim i, j As Integer
        If MyObjs Is Nothing Then Exit Sub
        If kuda Is Nothing Then kuda = ""
        kuda = kuda.ToLower
        If kuda = "" Or kuda = "на передний план" Then
            For i = MyObjs.Length - 1 To 0 Step -1
                HistoryLevel.Remove(MyObjs(i)) : HistoryLevel.Add(MyObjs(i)) : MyObjs(i).obj.BringToFront()
            Next
        ElseIf kuda = "на задний план" Then
            For i = MyObjs.Length - 1 To 0 Step -1
                HistoryLevel.Remove(MyObjs(i)) : HistoryLevel.Insert(0, MyObjs(i)) : MyObjs(i).obj.SendToBack()
            Next
            '  ElseIf kuda = "просто добавить" Then
            '     For i = MyObjs.Length - 1 To 0 Step -1
            ' HistoryLevel.Add(MyObjs(i))
            ' Next
        Else
            ' Если в kuda содержится индекс места, куда надо бринг то фронтить
            If kuda = -1 Then Exit Sub
            For i = MyObjs.Length - 1 To 0 Step -1
                HistoryLevel.Remove(MyObjs(i))
                If kuda < HistoryLevel.Count Then
                    HistoryLevel.Insert(kuda, MyObjs(i))
                Else
                    HistoryLevel.Add(MyObjs(i)) : MyObjs(i).obj.BringToFront() : Continue For
                End If
                For j = kuda To 0 Step -1
                    HistoryLevel(j).obj.SendToBack()
                Next
            Next
        End If
    End Sub

#End Region

    ' <<<<<<<< ОПЕРАЦИИ С АКТИВНЫМИ ОБЪЕКТАМИ >>>>>>>>>
#Region "VIDELENIYA"
    Sub AddActiveObject(ByVal MyObj As Object, Optional ByVal noRefresh As Boolean = False) ' Выделить плюс еще один объект
        Dim NewInd, i, j As Integer
        If ActiveObj Is Nothing Then ' Если активных объектов небыло, то он будет первым
            ReDim Preserve ActiveObj(0) : ActiveObj(0) = MyObj
        Else
            If Array.IndexOf(ActiveObj, MyObj) <> -1 Then
                ' Раз объект уже содержится в вписке активных, то удалить его от туда
                Dim temp() As Object = Nothing ' сюда записывается новый список объектов
                For i = 0 To ActiveObj.Length - 1
                    If ActiveObj(i) Is MyObj = False Then ' исключить объект из списка
                        ReDim Preserve temp(j) : temp(j) = ActiveObj(i) : j += 1
                    End If
                Next
                If temp Is Nothing Then ' Если объект был единственным выделеным
                    ClearActiveObject() : Exit Sub
                Else
                    ReDim ActiveObj(temp.Length - 1) : ActiveObj = temp
                End If
            Else ' Если объект не был выделен то добавить его в список активных
                NewInd = ActiveObj.Length
                ReDim Preserve ActiveObj(NewInd) : ActiveObj(NewInd) = MyObj
            End If
        End If
        If noRefresh = False Then FillListView() ' Заполнить список свойств
    End Sub
    Sub ClearActiveObject() ' Убрать выделение со всех выделеных объектов (выделится форма)
        ActiveObj = Nothing : FillListView()
    End Sub
    Sub SetActiveObject(ByVal MyObj As Object, Optional ByVal onlySelect As Boolean = False) ' Выделить какой-то один объект
        If ProgressForm.Visible = True And ProgressForm.ProgressBarValue < 70 Then Exit Sub
        ReDim Preserve ActiveObj(0) : ActiveObj(0) = MyObj
        FillListView(onlySelect)
    End Sub
    Function IsActiveObject(ByVal MyObj As Object) As Boolean ' Является ли объект активным
        If ActiveObj Is Nothing Then Return False
        If Array.IndexOf(ActiveObj, MyObj) = -1 Then : Return False
        Else : Return True : End If
    End Function
    Function inRectangle(ByVal obj As Object, ByVal na4Point As Point, ByVal endPoint As Point) As Boolean
        Dim x1, y1, x2, y2 As Integer ' Координаты левого верхнего и правого нижнего угла
        If na4Point.X < endPoint.X Then
            x1 = na4Point.X : x2 = endPoint.X
        Else
            x1 = endPoint.X : x2 = na4Point.X
        End If
        If na4Point.Y < endPoint.Y Then
            y1 = na4Point.Y : y2 = endPoint.Y
        Else
            y1 = endPoint.Y : y2 = na4Point.Y
        End If
        If (obj.left + obj.width > x1 And obj.left < x2) And (obj.top + obj.height > y1 And obj.top < y2) Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

    ' <<<<<<<< ОПЕРАЦИИ С МАРКЕРАМИ ФОРМЫ И ВИДИМОСТЬ МАРКЕРОВ >>>>>>>>>
#Region "MARKERI"
    Function ContenerAbsXY(ByVal MyObj As Object) As Point
        Dim contLeft, contTop As Integer, oldCont As Object, cont As Object = MyObj.conteiner
        contLeft = 0 : contTop = 0 ' х и у контейнера относительно таба
        If MyObj Is Nothing Then Return New Point(contLeft, contTop)
        If MyObj.obj.TypeObj = "PoluObj" Then
            If cont.GetType.ToString = "System.Windows.Forms.SplitterPanel" Then
                contLeft += cont.Parent.Left - markerX
                contTop += cont.Parent.SplitterDistance + cont.Parent.SplitterRectangle.Height - 1
            Else
                contLeft += cont.obj.Parent.Parent.Left - markerX
                contTop += cont.obj.Parent.Parent.SplitterDistance + cont.obj.Parent.Parent.SplitterRectangle.Height - 1
            End If
        Else ' Объет может быть внутри сразу нескольких вложеных контенеров
            oldCont = MyObj
            Do Until cont Is Nothing ' Пока не пройдет форму складывать координаты контенеров
                If cont.obj.TypeObj = "PoluObj" Then
                    Try
                        contLeft += cont.conteiner.Parent.Left - markerX
                        contTop += cont.conteiner.Parent.SplitterDistance + cont.conteiner.Parent.SplitterRectangle.Height - 1
                    Catch ex As Exception
                        i = i
                    End Try
                    Exit Do
                End If
                ' У двойной панели надо учитывать в какой панели объект
                If cont.obj.GetType.ToString = ClassAplication & "DP" Then
                    contLeft += cont.obj.ParentPanelLeft(oldCont.obj)
                    contTop += cont.obj.ParentPanelTop(oldCont.obj)
                Else
                    contLeft += cont.obj.Left : contTop += cont.obj.Top
                End If
                ' If iz.isPanel(cont.obj) Then
                ' contLeft -= cont.obj.HorizontalScroll.Value
                ' contTop -= cont.obj.VerticalScroll.Value
                ' End If
                oldCont = cont
                cont = cont.conteiner
            Loop
        End If
        Return New Point(contLeft, contTop)
    End Function
    Sub marker_vis(Optional ByVal vis As Boolean = True)
        Dim i, j As Integer
        If ProgressForm.Visible = True Then fromIzmenenieBylo = False : Exit Sub ' если происходит вставка и т.п. что не требует показа маркеров
        ' Убрать все маркеры
        If MyObjs Is Nothing = False Then
            For j = 0 To MyObjs.Length - 1
                For i = 0 To MyObjs(j).markers.Length - 1
                    ' У полуобъекта маркеров нет кроме 8-го
                    If MyObjs(j).obj.TypeObj <> "PoluObj" Or i = 8 Or i = 9 Then
                        If MyObjs(j).markers(i) Is Nothing = False Then MyObjs(j).markers(i).Visible = False
                    End If
                Next
            Next
        End If
        If ActiveObj Is Nothing Then Exit Sub
        If ActiveObj(0) Is Nothing Then Exit Sub
        ' Выделить маркерами активные объекты если надо (если vis=true)
        If vis Then
            For j = 0 To ActiveObj.Length - 1 ' Выделить маркерами все объекты
                Dim cont As Point = ContenerAbsXY(ActiveObj(j))
                With ActiveObj(j)
                    Dim ddx As Integer = 0, ddy As Integer = 0
                    If .markers(0) Is Nothing Then Continue For
                    ' Сделать объект пунктменю видимым
                    If Iz.IsMMs(ActiveObj(j)) Then
                        Dim it As MMs = .obj.OwnerItem ', flag As Boolean = False
                        Dim its() As Object
                        ' Раскрытие всех элементов меню
                        If it Is Nothing = False Then
                            While it Is Nothing = False
                                ReDimsO(its) : its(its.Length - 1) = it
                                it = it.OwnerItem
                            End While
                            For i = its.Length - 1 To 0 Step -1
                                its(i).ShowDropDown()
                            Next
                            it = its(0)
                            ddx = it.DropLocation.X - MainForm.ToolStripContainer1.LeftToolStripPanel.Bounds.Width - MainForm.Left
                            ddy = it.DropLocation.Y - MainForm.ToolStripContainer1.TopToolStripPanel.Bounds.Height - tab.Bounds.Y - MainForm.PreferredSize.Height - MainForm.Top
                            'proj.ActiveForm.AddActiveObject(ActiveObj(j), True)
                            '                         flag = True
                        Else
                            If Iz.IsCM(.conteiner) Then
                                ActiveObj(j).conteiner.obj.CnMn.Show(ActiveObj(j).conteiner.obj, ActiveObj(j).conteiner.dx, ActiveObj(j).conteiner.dy)
                                If .obj.owner IsNot Nothing Then
                                    ddx = .obj.owner.MousePosition.X - ActiveObj(j).dx - MainForm.ToolStripContainer1.LeftToolStripPanel.Bounds.Width - MainForm.Left
                                    ddy = .obj.owner.MousePosition.y - ActiveObj(j).dy - .obj.Props.pos * .obj.height - MainForm.ToolStripContainer1.TopToolStripPanel.Bounds.Height - tab.Bounds.Y - MainForm.PreferredSize.Height - MainForm.Top
                                End If
                            End If
                        End If
                    End If
                    .markers(0).Left = cont.X + .obj.Bounds.X - markerX
                    .markers(0).Top = cont.Y + .obj.Bounds.Y - markerY
                    .markers(1).Left = cont.X + .obj.Bounds.X + (.obj.Width - markerX) / 2
                    .markers(1).Top = cont.Y + .obj.Bounds.Y - markerY
                    .markers(2).Left = cont.X + .obj.Bounds.X + .obj.Width
                    .markers(2).Top = cont.Y + .obj.Bounds.Y - markerY
                    .markers(3).Left = cont.X + .obj.Bounds.X - markerX
                    .markers(3).Top = cont.Y + .obj.Bounds.Y + (.obj.Height - markerY) / 2
                    .markers(5).Left = cont.X + .obj.Bounds.X - markerX
                    .markers(5).Top = cont.Y + .obj.Bounds.Y + .obj.Height
                    .markers(4).Left = cont.X + .obj.Bounds.X + .obj.Width
                    .markers(4).Top = cont.Y + .obj.Bounds.Y + (.obj.Height - markerY) / 2
                    .markers(6).Left = cont.X + .obj.Bounds.X + (.obj.Width - markerX) / 2
                    .markers(6).Top = cont.Y + .obj.Bounds.Y + .obj.Height
                    .markers(7).Left = cont.X + .obj.Bounds.X + .obj.Width
                    .markers(7).Top = cont.Y + .obj.Bounds.Y + .obj.Height
                    .markers(8).Left = cont.X + .obj.Bounds.X + markerX
                    .markers(8).Top = cont.Y + .obj.bounds.y - markerY * 1.5
                    If ddx = 0 Then
                        If .obj.TypeObj <> "PoluObj" Then
                            .markers(9).Left = cont.X + .obj.Bounds.X + .obj.Width - markerX * 2.5
                        Else
                            .markers(9).Left = cont.X + .obj.Bounds.X + .obj.Width - markerX * 0.5
                        End If
                        .markers(9).Top = cont.Y + .obj.Bounds.Y - markerY * 1.5
                    Else
                        If Iz.isNoMove(.obj) Then
                            .markers(8).Left = ddx - markerX * 2.5 - 3 '+ markerX
                            .markers(8).Top = ddy + .obj.bounds.y - markerY * 1.5
                        End If
                        .markers(9).Left = ddx + .obj.Width - markerX - 2
                        .markers(9).Top = ddy + .obj.Bounds.Y - markerY * 1.5
                    End If
                    ' Сделать маркеры видимыми
                    If Iz.isNoSizeChange(.obj) = False Then
                        For i = 0 To .markers.Length - 1
                            If i = 9 Then Continue For ' плюсик делается отдельно
                            ' У формы есть только 4,6,7 маркеры
                            If .obj.GetType.ToString <> ClassAplication & "F" Or i = 4 Or i = 6 Or i = 7 Then
                                .markers(i).Visible = True : .markers(i).BringToFront()
                            End If
                        Next
                    Else
                        If Iz.isNoMove(.obj) = False Then .markers(8).cursor = Cursors.Hand
                        .markers(8).Visible = True : .markers(8).BringToFront()
                    End If
                    '.markers(8).height = 1000
                    '.markers(8).width = 1000
                    ' Показывать плюсик только у особых объектов
                    If Iz.isHavePlusik(.obj) Then
                        .markers(9).Visible = True : .markers(9).BringToFront()
                    End If
                End With
            Next
        End If
        fromIzmenenieBylo = False
    End Sub
#End Region

    ' <<<<<<<< ОПЕРАЦИИ С МАССИВАМИ >>>>>>>>>
#Region "MASSIVES"
    Function ExistIndex(ByVal obj As Object, ByVal name As String, ByVal ind As String) As Boolean ' СУЩЕСТВУЕТ ЛИ ТАКОЙ ИНДЕКС
        Dim i, j As Integer
        Dim myObj As Object
        If obj Is Nothing Then
            myObj = proj.GetMyAllFromName(name)
            If myObj Is Nothing Then Return False
            myObj = myObj(0)
        Else
            If proj Is Nothing Then Return False
            myObj = proj.GetMyObjFromObj(obj)
        End If
        If myObj Is Nothing Then Return False
        Dim Forms() As Object = proj.GetMyFormsFromName(myObj.GetMyForm.obj.Props.name)
        If Forms Is Nothing Then ReDim Forms(0) : Forms(0) = Me
        For i = 0 To Forms.Length - 1
            If Forms(i) Is Nothing = False Then
                If Forms(i).obj Is obj = False Then ' Если это не сам объект obj
                    If Forms(i).obj.Props.Name = name And Forms(i).obj.Props.index = ind Then Return True
                End If
                If Forms(i).MyObjs Is Nothing = False Then
                    For j = 0 To Forms(i).MyObjs.Length - 1
                        If Forms(i).MyObjs(j).obj Is obj = False Then ' Если это не сам объект obj
                            If Forms(i).MyObjs(j).obj.Props.Name = name And Forms(i).MyObjs(j).obj.Props.index = ind Then Return True
                        End If
                    Next
                End If
            End If
        Next
        Return False ' Если совпадений имён и индексов не найдено
    End Function
    Sub CreateMassive(ByVal name As String, ByVal ParamArray MyObjs() As Object) ' СОЗДАТЬ МАССИВ ИЗ ОБЪЕКТОВ o
        If MyObjs Is Nothing Then Exit Sub
        Dim i As Integer
        If name = "" Then name = MyObjs(0).obj.Props.name
        MyObjs = proj.GetSortMyObjsByFormsLast(MyObjs)
        For i = 0 To MyObjs.Length - 1
            recur = False
            If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "") Else proj.UndoRedo("#Reverses", "", "", "")
            Dim oldindex As String = MyObjs(i).obj.Props.index
            MyObjs(i).GetMyForm.SetPropertys(trans("Номер"), GetIndex(name), MyObjs(i))
            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            Dim oldname As String = MyObjs(i).obj.Props.name
            MyObjs(i).GetMyForm.SetPropertys(trans("Имя"), name, MyObjs(i))
            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            If Iz.IsFORM(MyObjs(i)) Then
                proj.UndoRedo("Изменение свойства", oldname & "." & oldname & "[" & oldindex & "]" & "." & trans("Номер"), MyObjs(i).obj.Props.index, oldindex) ', True)
            Else
                proj.UndoRedo("Изменение свойства", MyObjs(i).getmyform.obj.Props.name & "." & oldname & "[" & oldindex & "]" & "." & trans("Номер"), MyObjs(i).obj.Props.index, oldindex) ', True)
            End If
            MyObjs(i).obj.refresh()
        Next
        FillListView()
        If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)
    End Sub
    Sub CreatePodMassive(ByVal obj As Object, ByVal ParamArray MyObj() As Object) ' СОЗДАТЬ МАССИВ ИЗ ОБЪЕКТОВ o
        If MyObjs Is Nothing Then Exit Sub
        Dim i, j, fl As Integer, name, ind, subInd As String
        ' Найти имя массива, на основе которого создавать подмассив
        Dim massiveobject = GetMassiveobjectFromObjs(obj, MyObj)
        If massiveobject Is Nothing Then Exit Sub ' Если не нашли массивов
        name = massiveobject.props.name : ind = massiveobject.props.index : subInd = 1
        ' Получить массив по найденому имени
        Dim Massive() As Object = proj.GetMyAllFromName(name)
        If Massive Is Nothing Then Exit Sub
        For i = 0 To Massive.Length - 1
            For j = 0 To MyObj.Length - 1
                If MyObj(j).obj Is Massive(i).obj Then fl = 1 : Exit For
            Next
            ' Заменить индексы у всех объектов массива, не входящих в MyObj
            If fl = 0 Then
                proj.UndoRedo("#Revers Undo", "", "", "")
                Massive(i).GetMyForm.SetPropertys(trans("Номер"), Massive(i).obj.Props.index & ",1", Massive(i))
                proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                Massive(i).obj.refresh()
            End If
            fl = 0
        Next
        For i = 0 To MyObj.Length - 1
            ' Заменить индексы у всех объектов MyObj
            MyObj(i).GetMyForm.SetPropertys(trans("Номер"), ind & "," & subInd, MyObj(i))
            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            subInd += 1
            MyObj(i).GetMyForm.SetPropertys(trans("Имя"), name, MyObj(i))
            If i < MyObj.Length - 1 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            MyObj(i).obj.refresh()
        Next : FillListView()
        If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)
    End Sub

    ' СОЗДАТЬ МАССИВ ИЗ ОБЪЕКТОВ MyObj
    Sub UnitedPodMassive(ByVal obj As Object, ByVal ParamArray MyObj() As Object)
        If MyObjs Is Nothing Then Exit Sub
        Dim i As Integer, name, ind As String
        ' Найти имя массива, на основе которого создавать подмассив
        Dim massiveobject = GetMassiveobjectFromObjs(obj, MyObj)
        If massiveobject Is Nothing Then Exit Sub ' Если не нашли массивов
        If massiveobject.index.split(",").length <= 1 Then Exit Sub ' Только массивы второй степени и выше
        name = massiveobject.name
        ind = massiveobject.index.Substring(0, massiveobject.index.Length - 1)
        For i = 0 To MyObj.Length - 1
            ' Заменить индексы у всех объектов MyObj
            If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "") Else proj.UndoRedo("#Revers Undo", "", "", "")
            MyObj(i).GetMyForm.SetPropertys(trans("Номер"), GetIndex(name, MyObj(i).obj, ind & "1"), MyObj(i))
            proj.UndoRedo("#Union Undos(Redos)", "", "", "")
            MyObj(i).GetMyForm.SetPropertys(trans("Имя"), name, MyObj(i))

            MyObj(i).obj.refresh()
        Next : FillListView()
        If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)
    End Sub
    Function GetMassiveobjectFromObjs(ByVal MainObj As Object, ByVal ParamArray MyObj() As Object) As Object
        ' Возвращение из данных объектов того объекта, который в массиве
        Dim massives() As String = GetAllMassives(), i As Integer
        ' Если у главного объекта mainobj есть массив, то вернуть его
        If Array.IndexOf(massives, MainObj.Props.name) <> -1 Then
            Return MainObj
        Else ' Иначе брать первый попавшийся масив из MyObj
            For i = 0 To MyObj.Length - 1
                If Array.IndexOf(massives, MyObj(i).obj.Props.name) <> -1 Then
                    Return MyObj(i).obj
                End If
            Next
        End If : Return Nothing ' Если не нашли массивов
    End Function
    Function GetObjsFromMyObjs(ByVal ParamArray MyObjs() As Object) As Object
        Dim Objs() As Object = Nothing, ind As Integer = 0, i As Integer
        For i = 0 To MyObjs.Length - 1
            ReDim Preserve Objs(ind) : Objs(ind) = MyObjs(i).obj : ind += 1
        Next : Return Objs
    End Function
    Sub MassiveSelect(ByVal obj As Object, Optional ByVal index As String = "") ' Выделить массив
        If MyObjs Is Nothing Then Exit Sub
        Dim i As Integer
        For i = 0 To MyObjs.Length - 1
            ' Если объект входит в массив, и не является сам собой
            If MyObjs(i).obj.Props.name = obj.Props.Name And MyObjs(i).obj Is obj = False Then
                If MyObjs(i).obj.Props.index.indexof(index) = 0 Then ' Если нужный уровень подмассива
                    ' Выделить, если небыл выделен
                    If IsActiveObject(MyObjs(i)) = False Or ctrl = True Then
                        AddActiveObject(MyObjs(i), True)
                    End If
                End If
            End If
        Next : FillListView() : marker_vis(True)
    End Sub
    Sub MassiveExecute(ByVal Myobj() As Object) ' Выделить массив
        If Myobj Is Nothing Then Exit Sub
        Dim i As Integer, oldname As String
        Myobj = proj.GetSortMyObjsByFormsLast(Myobj)
        For i = 0 To Myobj.Length - 1
            ' Если объект входит в какой либо массив, и не является сам собой
            If proj.ExistName(Myobj(i).obj.Props.name, Myobj(i).obj) Then
                If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "") Else proj.UndoRedo("#Reverses", "", "", "")
                oldname = GetUNameObj(Myobj(i))
                If Iz.IsFORM(Myobj(i)) Then
                    proj.UndoRedo("Изменение свойства", proj.GiveName(Myobj(i).obj.Props.name) & "." & proj.GiveName(Myobj(i).obj.Props.name) & "[" & Myobj(i).obj.Props.index & "]" & "." & trans("Номер"), "0", Myobj(i).obj.Props.index) ', True)
                Else
                    proj.UndoRedo("Изменение свойства", Myobj(i).getmyform.obj.Props.name & "." & proj.GiveName(Myobj(i).obj.Props.name) & "[" & Myobj(i).obj.Props.index & "]" & "." & trans("Номер"), "0", Myobj(i).obj.Props.index) ', True)
                End If
                proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                Myobj(i).GetMyForm.SetPropertys(trans("Имя"), proj.GiveName(Myobj(i).obj.Props.name), Myobj(i))
                proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                Myobj(i).GetMyForm.SetPropertys(trans("Номер"), "0", oldname, Myobj(i))

                Myobj(i).obj.refresh()
            ElseIf Myobj(i).obj.Props.index <> 0 Then ' Если у объекта без массива не нулевой индекс
                If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "") Else proj.UndoRedo("#Revers Undo", "", "", "")
                Myobj(i).GetMyForm.SetPropertys(trans("Номер"), 0, Myobj(i))

                Myobj(i).obj.refresh()
            End If
        Next : FillListView()
        If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)
    End Sub
    Function GetIndex(ByVal name As String, Optional ByVal obj As Object = Nothing, Optional ByVal ind As String = "1") As String
        ' Получить массив по найденому имени
        Dim i As Integer = 1, j As Integer
        '   If ExistIndex(obj, name, ind) = False Then Return ind
        Dim Massive() As Object = proj.GetMyAllFromName(name) : If Massive Is Nothing Then Return ind
        ' Если размерность индекса не совпадает со степенью массива
        If ind.Split(",").Length < Massive(0).obj.Props.index.Split(",").Length Then : ind = ""
            For j = 0 To Massive(0).obj.Props.index.Split(",").Length - 2 : ind &= ",1" : Next
            While (ExistIndex(obj, name, i & ind)) : i += 1 : End While
            Return i & ind
        End If
        ' найти индекс, которого еще небыло
        If ind.Split(",").Length > 1 Then ind = ind.Substring(0, ind.LastIndexOf(",") + 1) Else ind = ""
        While (ExistIndex(obj, name, ind & i)) : i += 1 : End While
        Return ind & i
    End Function
    Function GetAllMassives() As String()
        Dim i, newInd As Integer, str(0) As String : str(0) = ""
        If MyObjs Is Nothing Then Return Nothing
        For i = 0 To MyObjs.Length - 1
            ' Если имя объекта есть еще у когото и он еще не в списке массивов
            If proj.ExistName(MyObjs(i).obj.Props.name, MyObjs(i).obj) And Array.IndexOf(str, MyObjs(i).obj.Props.name) = -1 Then
                If str(0) = "" Then newInd = 0 Else newInd = str.Length
                ReDim Preserve str(newInd) : str(newInd) = MyObjs(i).obj.Props.name
            End If
        Next
        If str(0) = "" Then Return Nothing Else Return str
    End Function
    Function ExistName(ByVal name As String, Optional ByVal obj As Object = Nothing) As Boolean ' СУЩЕСТВУЕТ ЛИ ТАКОЕ ИМЯ
        Dim i As Integer
        If MyObjs Is Nothing Then
            If obj Is Nothing Then Return False
            If obj.Props.name = name Then Return True
        End If
        For i = 0 To MyObjs.Length - 1
            If MyObjs(i).obj Is obj = False Then ' Если это не сам объект obj
                If MyObjs(i).obj.Props.name = name Then Return True
            End If
        Next
        Return False ' Если совпадений имён с str не найдено
    End Function
#End Region

    ' <<<<<<<< ОПЕРАЦИИ СО СВОЙСТВАМИ >>>>>>>>>
#Region "PROPERTYS"
    ' Получение значения свойства сразу множества объектов
    Function GetPropertys(ByVal prop As String, ByVal ParamArray MyObjs() As Object) As ErrString
        If MyObjs Is Nothing Then Return New ErrString(Nothing)

        If MyObjs.Length = 1 Then Return GetProperty(MyObjs(0), prop)

        Dim i, StrInd As Integer, ret(MyObjs.Length - 1) As ErrString
        ' Занести в ret значения свойства prop у каждого объекта objects
        For i = 0 To MyObjs.Length - 1
            ret(i) = GetProperty(MyObjs(i), prop)
        Next
        StrInd = -1
        For i = 0 To ret.Length - 1
            ' Вернуть "" если значение свойства не у всех объектов одинаково
            If StrInd <> -1 Then
                If ret(i).str <> Nothing Then
                    If ret(i).str <> ret(StrInd).str Then Return New ErrString(Nothing)
                End If
                If ret(i).err <> "" Then Return ret(i)
            End If
            ' Сохранить в strInd индекс от ret у объекта, имеющего данное свойство
            If ret(i).str <> Nothing And StrInd = -1 Then StrInd = i
        Next
        ' Если ни у одного объекта свойства нет, то вернуть ничто, иначе вернуть значение свойства
        If StrInd = -1 Then Return ret(0) Else Return ret(StrInd)
    End Function
    ' Присвоение значения свойства сразу множеству объектов
    Function SetPropertys(ByVal prop As String, ByVal value As String, ByVal ParamArray MyObjs() As Object) As Boolean
        Return SetPropertys(prop, value, "", MyObjs)
    End Function
    ' Присвоение значения свойства сразу множеству объектов
    Function SetPropertys(ByVal prop As String, ByVal value As String, ByVal oldname As String, ByVal ParamArray MyObjs() As Object) As Boolean
        Dim i As Integer, oldValue, objName As String, fl As Boolean
        ' Нельзя менять свойства во время запущенного проекта
        '' If RunProj Is Nothing = False Then Return True
        ' Неприсваивать пустоту, если значения свойств объектов расходятся
        If GetPropertys(prop, MyObjs).str = "" And value = "" Then Exit Function
        For i = 0 To MyObjs.Length - 1
            oldValue = GetProperty(MyObjs(i), prop).str
            ' Система, благодаря которой не пишется одна и та же информация в ундоредо. Проблема в рекурсивном вызове данной процедуры
            'If recur = True Then fl = True
            'recur = True
            ' Собственно измен.свойства
            Dim gladko As MsgBoxResult = SetProperty(MyObjs(i), prop, value)
            If gladko = MsgBoxResult.No Or gladko = MsgBoxResult.Cancel Then Return False ' Если при присвоении свойства произошла ошибка
            'recur = False
            ' Создание ундо редо
            If recur = False And isDevelop Then
                If i > 0 Then proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                proj.UndoRedo("Изменение свойства", GetUNameObj(MyObjs(i)) & "." & trans(prop), value, oldValue)
                If oldname <> "" Then
                    proj.UndoRedo("#Union Undos(Redos)", "", "", "")
                    proj.UndoRedo("Изменение свойства", oldname & "." & trans(prop), value, oldValue, True)
                End If
            End If
        Next
        recur = False
        Return True
    End Function
    Function getSpisName(ByVal MyObj As Object) As String
        Dim str As String
        str = MyObj.obj.name
        If MyObj.obj.props.index <> 0 Then str &= "[" & MyObj.obj.props.index & "]"
        Return str & " - " & "{" & MyObj.obj.props.type & "}"
    End Function
    Sub FillListView(Optional ByVal onlySelect As Boolean = False) ' Заполнение списка свойств
        Dim MyObjs() As Object, props() As String = Nothing, i, j As Integer
        Try
            MainForm.ListView.Items.Clear()
        Catch ex As Exception
            FillListView(onlySelect)
        End Try
        MyObjs = ActiveObj
        If proj Is Nothing = False And onlySelect = False Then proj.DeistvRefresh(ActiveObj)
        If MyObjs Is Nothing Then MainForm.lwEditPropertySet() : Exit Sub
        If MyObjs(0) Is Nothing Then MainForm.lwEditPropertySet() : Exit Sub
        ' Выбор в списке объектов, который над разделом свойств
        If proj IsNot Nothing Then
            Dim alls() As Object = proj.GetMyAllFromName("")
            If alls IsNot Nothing Then
                Dim strs() As String : ReDims(strs, alls.Length - 1)
                For i = 0 To alls.Length - 1
                    strs(i) = getSpisName(alls(i))
                Next
                MainForm.ComboBox2.Items.Clear()
                MainForm.ComboBox2.Items.AddRange(strs)
                MainForm.ComboBox2.Sorted = True
            End If
        End If
        MainForm.ComboBox2.Tag = "obrabotka"
        If MyObjs.Length = 1 Then
            Dim nam As String = getSpisName(MyObjs(0))
            If MainForm.ComboBox2.Items.IndexOf(nam) = -1 Then MainForm.ComboBox2.Items.Add(nam)
            MainForm.ComboBox2.Text = nam
        Else
            MainForm.ComboBox2.Text = ""
        End If
        MainForm.ComboBox2.Tag = ""
        ' Занести в props все названия свойств выделенных объектов
        For i = 0 To MyObjs.Length - 1
            If props Is Nothing Then ' Если props пуст, занести в него все свойства объекта
                props = MyObjs(i).Propertys
            Else ' Если props не пуст, добавить те свойства, которых еще нет
                For j = 0 To MyObjs(i).Propertys.Length - 1
                    If Array.IndexOf(props, MyObjs(i).Propertys(j)) = -1 Then
                        ReDim Preserve props(props.Length)
                        props(props.Length - 1) = MyObjs(i).Propertys(j)
                    End If
                Next
            End If
            MyObjs(i).NodeRefresh()
        Next
        If CreateDs Is Nothing = False Then CreateDs.SetProperty()
        ' Заполнить список свойств свойствами из props
        Dim its(props.Length - 1) As ListViewItem, num As Integer = 0
        For i = 0 To props.Length - 1
            ' Если свойство не только для чтения
            If Array.IndexOf(MayChangeProps, props(i).ToUpper) = -1 Then
                Dim es As ErrString = GetPropertys(props(i), MyObjs)
                If es.err = "" Then
                    its(num) = New ListViewItem(props(i), props(i))
                    its(num).Name = props(i)
                    its(num).SubItems.Add(es.str)
                    num += 1
                End If
            End If
        Next
        num -= 1 : ReDim Preserve its(num)
        Dim s = MainForm.ListView.Items
        ' Собственно заполнение списка
        MainForm.ListView.Items.AddRange(its)
        ' Выделение свойства, которое было активным последний раз
        If oldLVselect <> "" Then
            If MainForm.ListView.Items(oldLVselect) Is Nothing = False Then
                MainForm.ListView.Items(oldLVselect).Selected = True
                MainForm.ListView.Items(oldLVselect).BeginEdit()
                MainForm.ListView.LabelEdit = False : MainForm.ListView.LabelEdit = True
                MainForm.ListView.Items(oldLVselect).Focused = False
            End If
        End If
        ' Настроить и вывести мой элемент
        If obj.GetType.ToString = ClassAplication & "F" Then MyObj.TabTextRefresh()
        MainForm.lwEditPropertySet()
    End Sub
#End Region

End Class