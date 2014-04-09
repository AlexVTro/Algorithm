Public Class RunProject
    Public tree As TreeView = Nothing
    Dim withOtladka As Boolean
    Dim objects As String
    Public pPath, iPath, iPathShort, pFileName, pIcon, pPicNameDef, pProgressForm As String   ' Папка данного проекта и папка его рисунков
    Dim debugNodes(), sledNode As TreeNode
    Public f() As Forms
    Public isRUN, isSTEP, isCLOSING, isINITIALIZATED, isONLYFORM As Boolean
    Public Param As PropertysSobyt
    Public Event NodeStop(ByVal node As TreeNode, ByVal param As PropertysSobyt)
    Public Event StopRun()
    Public Sub New(ByVal objects As String)
        withOtladka = False : Me.objects = objects
    End Sub
    Public Sub New(ByVal tree As TreeView, ByVal objects As String)
        Me.tree = tree : withOtladka = True : Me.objects = objects
    End Sub

    ' <<<<<< ОБЩИЕ ФУНКЦИИ RUN ПРОЕКТА >>>>>>>
#Region "COMMON"
    ' ВСЕ СПОСОБЫ УКАЗАНИЯ "никакой" ПРЕОБРАЗУЮТСЯ В "Никакой"
    Function NetTakNet(ByVal str As String)
        If str = "" Or UCase(str) = UCase(trans("Никакой")) Then
            Return trans("Никакой")
        Else : Return str : End If
    End Function
    Sub GotFocus()
        Dim i As Integer
        For i = 0 To f.Length - 1
            If f(i).obj.Visible = True Then f(i).obj.Activate()
        Next
    End Sub
    ' ПОЛУЧИТЬ ВСЕ МОИОБЪЕКТЫ С ТАКИМ ИМЕНЕМ
    Function GetMyAllFromName(ByVal name As Object, Optional ByVal index As String = "", Optional ByVal formName As String = "") As Object()
        ' Вернуть объекты с таким именем
        Dim ind As Integer = 0, i, j As Integer
        Dim Massive() As Object = Nothing, Forms() As Object = Nothing
        If proj.f Is Nothing Or name = "" Then Return Nothing
        ' Если форму задали, то искать в ней, иначе в форме с именем name
        If formName <> "" Then
            Forms = GetMyFormsFromName(formName)
        Else
            Forms = GetMyFormsFromName(name, index)
        End If
        ' Если формы с именем name нет, то берется активная форма
        If Forms Is Nothing Then
            If ActiveForm() Is Nothing Then Return Massive
            Forms = GetMyFormsFromName(ActiveForm.obj.Props.name)
        End If
        If Forms Is Nothing Then Return Nothing
        For i = 0 To Forms.Length - 1
            If Forms(i).MyObjs Is Nothing Then Return Nothing
            For j = 0 To Forms(i).MyObjs.Length - 1
                ' Если у объекта нужное имя, и не является сам собой
                If UCase(Forms(i).MyObjs(j).obj.Props.name) = UCase(name) _
                And (Forms(i).MyObjs(j).obj.Props.index.indexof(index) = 0 Or UCase(index) = UCase(trans("Все"))) Then
                    ReDim Preserve Massive(ind) : Massive(ind) = Forms(i).MyObjs(j) : ind += 1
                End If
            Next
        Next
        Return Massive
    End Function
    ' ПРОВЕРИТЬ, СУЩЕСТВУЕТ ЛИ ТАКОЕ ИМЯ
    Function ExistName(ByVal name As String, Optional ByVal obj As Object = Nothing, Optional ByVal myForms As Object = Nothing) As Boolean
        Dim i, j As Integer
        ' Форма, в которой надо искать существование имени name
        Dim myForm() = myForms
        ' Если такое имя есть у формы
        If f Is Nothing Then Return False
        For i = 0 To f.Length - 1
            If f(i) Is Nothing = False Then
                ' Если эта форма не сам объект obj, для которого скорее всего подбирается имя
                If f(i).obj Is obj = False Then
                    ' Если форма с таким именем есть
                    If UCase(f(i).obj.Props.Name) = UCase(name) Then Return True
                End If
            End If
        Next
        ' Если форму не передали в функцию, то ищем в активной форме
        If myForm Is Nothing Then myForm = GetMyObjFromObj(obj).getMyForm
        If myForm Is Nothing Then Return False
        For i = 0 To myForm.Length - 1
            If myForm(i).MyObjs Is Nothing Then Continue For
            For j = 0 To myForm(i).MyObjs.Length - 1
                ' Если это не сам объект obj, для которого скорее всего подбирается имя
                If myForm(i).MyObjs(j).obj Is obj = False Then
                    ' Если объект с таким именем есть
                    If UCase(myForm(i).MyObjs(j).obj.Props.name) = UCase(name) Then Return True
                End If
            Next
        Next
        Return False ' Если совпадений имён с str не найдено
    End Function
    ' ПОЛУЧИТЬ МОЙОБЪЕКТ ЗНАЯ ТОЛЬКО КОНТРОЛ, Т.Е. obj
    Function GetMyObjFromObj(ByVal obj As Object) As Object
        Dim i, j As Integer
        'If obj.MyObj Is Nothing = False Then Return obj.MyObj ' Слишком рано доступен
        If f Is Nothing Then Return Nothing
        ' Просматриваем все формы
        For i = 0 To f.Length - 1
            If f(i) Is Nothing = False Then
                ' Есть ли форма с таким объектом
                If f(i).obj Is obj Then Return f(i)
                If f(i).MyObjs Is Nothing = False Then
                    ' Есть ли в форме мойобъект с таким объектом
                    For j = 0 To f(i).MyObjs.Length - 1
                        If obj Is f(i).MyObjs(j).obj Then Return f(i).MyObjs(j)
                    Next
                End If
            End If
        Next : Return Nothing
    End Function
    Function FindSobyt(ByVal sobyt As String, ByVal root As TreeNode) As TreeNode
        Dim i As Integer
        If root Is Nothing Then Return Nothing
        For i = 0 To root.Nodes.Count - 1
            If UCase(root.Nodes(i).Text) = UCase(sobyt) Then Return root.Nodes(i)
        Next
        Return Nothing
    End Function
    Function FindSobyt(ByVal childSobytTreeNode As TreeNode) As TreeNode
        While childSobytTreeNode Is Nothing = False
            If childSobytTreeNode.Tag = "Sobyt" Then Return childSobytTreeNode
            childSobytTreeNode = childSobytTreeNode.Parent
        End While
        Return Nothing
    End Function
    ' ПОЛУЧЕНИЕ ОБЪЕКТА ПО УНИКАЛЬНОМУ ИМЕНИ
    'Public Function GetMyObjFromUniqName(ByVal uniqName As String) As Object
    '    Dim i, j As Integer, forma, obj, dop, index As String
    '    If uniqName = "" Then Return Nothing
    '    If uniqName.IndexOf(".") = -1 Then
    '        If ActiveForm Is Nothing Then Return Nothing
    '        uniqName = ActiveForm.obj.Props.name & "." & uniqName
    '    End If
    '    forma = uniqName.Split(".")(0)
    '    If uniqName.IndexOf("[") <> -1 Then
    '        obj = uniqName.Split(".")(1).Split("[")(0)
    '        index = uniqName.Split(".")(1).Split("[")(1).Split("]")(0)
    '        index = UbratKovich(index).str
    '    Else
    '        obj = uniqName.Split(".")(1)
    '        index = "0"
    '    End If
    '    If obj.IndexOf("(") <> -1 Then
    '        dop = obj.Split("(")(1).Split(")")(0)
    '        obj = obj.Split("(")(0)
    '    End If
    '    Dim forms() As Object = GetMyFormsFromName(forma)
    '    If forms Is Nothing Then Return Nothing
    '    For i = 0 To forms.Length - 1
    '        For j = 0 To forms(i).MyObjs.Length - 1
    '            If forms(i).MyObjs(j).obj.Props.name = obj And forms(i).MyObjs(j).obj.Props.index = index Then
    '                ' Активировать одну из панелей сплитПанели, дабы не спрашивать, куда вставлять объекты
    '                If Iz.IsDP(forms(i).MyObjs(j)) Then forms(i).MyObjs(j).ActivePanel = dop
    '                Return forms(i).MyObjs(j)
    '            End If
    '        Next
    '    Next
    '    Return Nothing
    'End Function

    Dim objs As Hashtable = Nothing
    Function GetAllObjects()
        Dim i, j As Integer, namF, namO, indO As String
        objs = New Hashtable
        For i = 0 To f.Length - 1
            For j = 0 To f(i).MyObjs.Length - 1
                namf = f(i).obj.props.Name
                namO = f(i).MyObjs(j).obj.props.name
                indO = f(i).MyObjs(j).obj.props.index
                objs.Add(namF & "." & namO & "[" & indO & "]", f(i).MyObjs(j))
            Next
        Next
    End Function
    ' ПОЛУЧЕНИЕ ОБЪЕКТА ПО УНИКАЛЬНОМУ ИМЕНИ
    Public Function GetObjFromUniqName(ByVal uniqName As String) As Object
        ' Быстрый поиск объекта по Хэш-таблице
        'If objs IsNot Nothing Then
        '    Dim index As String = ""
        '    If uniqName.IndexOf("[") = -1 Then index = "[0]"
        '    Dim rtn As Object = objs(uniqName & index)
        '    If rtn IsNot Nothing Then Return rtn.obj
        'End If
        Dim ob As Object = GetMyObjFromUniqName(uniqName)
        If ob IsNot Nothing Then
            If ob(0) IsNot Nothing Then
                ob = ob(0).obj
            End If
        End If
        Return ob
    End Function
    Public Function GetMyObjFromUniqName(ByVal uniqName As String) As Object()
        Dim i, j As Integer, forma, obj, dop, index As String, ret() As Object = Nothing
        If uniqName = "" Then Return Nothing
        If uniqName.IndexOf(".") = -1 Then
            If ActiveForm() Is Nothing Then Return Nothing
            uniqName = ActiveForm.obj.Props.name & "." & uniqName
        End If
        forma = uniqName.Split(".")(0)
        If uniqName.IndexOf("[") <> -1 Then
            obj = uniqName.Split(".")(1).Split("[")(0)
            index = uniqName.Substring(uniqName.IndexOf("[") + 1)
            i = index.LastIndexOf("]")
            If i > index.IndexOf("[") Then index = Left(index, i)
            If isCompilBest = False Then
                Dim es As ErrString = TranslateALL("(" & index & ")")
                If es.err <> "" Then Errors.MessangeCritic(es.err) : Return Nothing
                index = es.str
            End If
            index = UbratKovich(index).str
        Else
            obj = uniqName.Split(".")(1)
            index = "0"
        End If
        If obj.IndexOf("(") <> -1 Then
            dop = obj.Split("(")(1).Split(")")(0)
            obj = obj.Split("(")(0)
        End If
        'If uniqName = "" Then Return Nothing
        'forma = uniqName.Split(".")(0)
        'obj = uniqName.Split(".")(1).Split("[")(0)
        'If uniqName.IndexOf("[") <> -1 Then
        '    index = uniqName.Split(".")(1).Split("[")(1).Split("]")(0)
        '    If (index.Chars(0) = """" And index.Chars(index.Length - 1) = """") Then
        '        If index.Length > 1 Then
        '            index = index.Substring(1, index.Length - 2)
        '        Else
        '            Return Nothing
        '        End If
        '    End If
        'Else
        '    index = trans("Все")
        'End If
        'If obj.IndexOf("(") <> -1 Then
        '    dop = obj.Split("(")(1).Split(")")(0)
        '    obj = obj.Split("(")(0)
        'End If



        If UCase(obj) = UCase(MyZnak & trans("Объект события")) Then
            ReDims(ret) : ret(ret.Length - 1) = Param.MyObj
            Return ret
        End If
        If UCase(obj).IndexOf(UCase(MyZnak & trans("Хозяин") & " ")) = 0 Then
            Dim nam As String = obj.Substring((MyZnak & trans("Хозяин") & " ").Length)
            ' получаем сначала само меню
            Dim ob() As Object = GetMyAllFromName(nam, , forma)
            If ob Is Nothing Then Return Nothing
            ' а затем получаем объект-хозяина меню
            If ob(0) IsNot Nothing Then
                ob = GetMyAllFromName(ob(0).obj.props.OwnerObject, , forma)
            End If
            If ob Is Nothing Then Return Nothing

            ReDims(ret) : ret(ret.Length - 1) = ob(0)
            Return ret
        End If
        If UCase(obj) = UCase(MyZnak & trans("Окно события")) Then
            ReDims(ret)
            If Param.MyObj IsNot Nothing Then ret(ret.Length - 1) = Param.MyObj.GetMyForm()
            Return ret
        End If

        ' Быстрый поиск объекта по Хэш-таблице
        If objs IsNot Nothing Then
            Dim rtn As Object = objs(forma & "." & obj & "[" & index & "]")
            If rtn IsNot Nothing Then Return New Object() {rtn}
        End If

        ' Если не подходит поиск по Хэш-таблице, то по-старинке
        Dim forms() As Object = GetMyFormsFromName(forma)
        If forms Is Nothing Then Return Nothing
        For i = 0 To forms.Length - 1
            For j = 0 To forms(i).MyObjs.Length - 1
                If UCase(forms(i).MyObjs(j).obj.Props.name) = UCase(obj) _
                And (forms(i).MyObjs(j).obj.Props.index = index Or index = trans("Все")) Then
                    ' Активировать одну из панелей сплитПанели, дабы не спрашивать, куда вставлять объекты
                    If Iz.IsDP(forms(i).MyObjs(j)) Then forms(i).MyObjs(j).ActivePanel = dop
                    ReDims(ret) : ret(ret.Length - 1) = forms(i).MyObjs(j)
                    ' ПРИ СУПЕР-КОМПИЛЯТОРЕ НЕМОЖЕТ БЫТЬ ВОЗВРАЩЕНО БОЛЕЕ ОДНОГО ОБЪЕКТА
                    If isCompilBest Then Return ret
                End If
            Next
        Next
        If ret Is Nothing Then Errors.MessangeCritic(Errors.ObjIsNothing(uniqName))
        Return ret
    End Function
    ' ПОЛУЧИТЬ ФОРМУ ЧЕРЕЗ ИМЯ
    Function GetMyFormsFromName(ByVal name As Object, Optional ByVal index As String = "") As Object()
        Dim ind = 0, i As Integer, Massive() As Object = Nothing
        If f Is Nothing Then Return Nothing
        ' Есть ли форма с таким именем
        For i = 0 To f.Length - 1
            If f(i) Is Nothing Then Continue For
            ' Если у объекта нужное имя, и не является сам собой, т.е. другой индекс
            If UCase(f(i).obj.Props.name) = UCase(name) And f(i).obj.Props.index.indexof(index) = 0 Then
                ReDim Preserve Massive(ind) : Massive(ind) = f(i) : ind += 1
            End If
        Next
        If UCase(name) = UCase(MyZnak & trans("Окно события")) Then
            ReDim Massive(0)
            If Param.MyObj IsNot Nothing Then
                Massive(0) = Param.MyObj.GetMyForm()
            ElseIf Param.sender IsNot Nothing Then
                Massive(0) = Param.sender.GetMyForm()
            End If
        End If
        Return Massive
    End Function
    Function giveName(ByVal o As Object)
        Return ""
    End Function
    Function ChangeName(ByVal o As Object, ByVal b As Object)
        If objs IsNot Nothing Then
            Dim MyObj As Object = GetMyObjFromObj(o)
            Dim MyForm As Object = MyObj.getMyForm
            Dim namf As String = MyForm.obj.props.Name
            Dim namO As String = o.props.name
            Dim indO As String = o.props.index
            objs.Remove(namf & "." & b & "[" & indO & "]")
            objs.Add(namf & "." & namO & "[" & indO & "]", MyObj)
        End If
        Return ""
    End Function
    Function ChangeIndex(ByVal o As Object, ByVal b As Object)
        If objs IsNot Nothing Then
            Dim MyObj As Object = GetMyObjFromObj(o)
            Dim MyForm As Object = MyObj.getMyForm
            Dim namf As String = MyForm.obj.props.Name
            Dim namO As String = o.props.name
            Dim indO As String = o.props.index
            objs.Remove(namf & "." & namO & "[" & b & "]")
            objs.Add(namf & "." & namO & "[" & indO & "]", MyObj)
        End If
        Return ""
    End Function
    Function ActiveForm() As Forms
        If f Is Nothing Then Return Nothing
        'Return f(f.Length - 1)
    End Function
#End Region

    ' Структура содержащая все флаги для работы с потоком
    Public isPotok As Boolean = False
    Public StopPr As Boolean = False
    Public ClosAl As Boolean = False
    Public GotFoc As Boolean = False
    Public Pause As Boolean = False
    Public CallRunBlock As Boolean = False
    Public newParent As TreeNode
    Public newIndex As Integer
    Public newParam As PropertysSobyt
    Public newStepOver As Boolean = False
    Public newStepOut As Boolean = False
    Public outRunString As Boolean = False
    Public outString, outType As String
    Public outResult As ErrString
    Public UndoRedoNoWrite As Boolean = False
    ' <<<<<< RUN ФУНКЦИИ ПРОЕКТА >>>>>>>
#Region "RUN"
    Sub StopProject()
        isCLOSING = True : CloseAll() : RaiseEvent StopRun() : isRUN = False
    End Sub
    Sub CloseAll()
        Dim i, j As Integer
        For i = 0 To f.Length - 1
            f(i).obj.close()
            For j = 0 To f(i).MyObjs.Length - 1
                If Iz.IsCS(f(i).MyObjs(j)) Then f(i).MyObjs(j).obj.props.CloseServer()
            Next
        Next
    End Sub

    ' Функция определения не прервали ли поток
    Function PrervaliPotok() As Boolean
        If StopPr Then StopProject() : Return True
        If ClosAl Then CloseAll() : Return True
        If GotFoc Then GotFoc = False : GotFocus()
        ' Если надо получить результат выполнения RunString
        If outRunString Then outResult = RunProj.RunString(outString, outType, Param) : outRunString = False

        Return False
    End Function

    ' ЗАПУСК ПРОЕКТА
    Sub Run()
        ' Прогресс-Форма показать
        If pProgressForm = "yes" Then
            If ProgressForm.InvokeRequired Then
                ' Если это поток то надо через потоконезависимую Invoke выполнять
                ProgressForm.Invoke(delegatProgressShow, New Object() {transInfc("Загрузка") & "..."})
            Else
                ProgressFormShow(transInfc("Загрузка") & "...")
            End If
        End If

        isINITIALIZATED = True
        isRUN = True : CreateObjects(objects, withOtladka, True, f, tree, Breaks, Me)
        isINITIALIZATED = False

        ' Прогресс-Форма скрыть
        If pProgressForm = "yes" Then
            If ProgressForm.InvokeRequired Then
                ' Если это поток то надо через потоконезависимую Invoke выполнять
                Application.DoEvents()
                ProgressForm.Invoke(delegatProgressHide, New Object() {""})
            Else
                ProgressForm.Hide()
            End If
        End If

        ' Если проект запускают как отдельный поток из среды разработки
        If isPotok Then
            Do
                If Pause = False And isRUN Then Windows.Forms.Application.DoEvents()
                Threading.Thread.Sleep(timeSleep * (pauseCount * Int(Pause)))
                If Pause = True And isRUN = True Then isRUN = False
                If PrervaliPotok() Then Exit Do
                If CallRunBlock Then
                    If isSTEP = False And newStepOut = False And newStepOver = False Then GotFocus()
                    CallRunBlock = False
                    If newParent Is Nothing = False Then RunBlock(newParent, newIndex, newParam, True)
                End If
            Loop
        End If
    End Sub

    'Sub Pause()
    '    isRUN = False
    '    If isPotok Then
    '        While (1)
    '            Threading.Thread.Sleep(timeSleep * pauseCount)
    '            If PrervaliPotok() Or isRUN = True Then Exit While
    '        End While
    '    End If
    'End Sub

    ' ЗАПУСК НА ВЫПОЛНЕНИЕ БЛОКА УЗЛОВ
    Public NowNode As TreeNode
    Public recurs As Integer = 0, alreadyRun As Boolean = False
    Function RunBlock(ByVal parentNode As TreeNode, ByVal ind As Integer, ByVal param As PropertysSobyt, ByVal IdtiNaVerhUrovni As Boolean, Optional ByVal WhileCount As Integer = 0) As ErrString
        Dim runNode, whileBeen As TreeNode
        Dim StepOverLocal, StepOutLocal, bylBreak, IgnoreErrors As Boolean
        If parentNode Is Nothing Then Exit Function
        If parentNode.Nodes.Count = 0 Or isRUN = False Then Exit Function
        Dim i = ind, j As Integer, es As ErrString

        alreadyRun = True
        ' Подсчет уровня вложенности рекурсии
        'recurs += 1
        'If recurs > maxRecurs Then
        '    Dim text As String = Errors.MoreRecurs(parentNode.Nodes(ind).Text, maxRecurs)
        '    If MsgBox(text, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return es
        '    recurs = 0
        'End If

        While i < parentNode.Nodes.Count
            Me.Param = param
            ' Пропуск комментариев
            While parentNode.Nodes(i).Tag = "Comm" Or parentNode.Nodes(i).text.indexof("'") = 0 _
            Or parentNode.Nodes(i).text.indexof("#") = 0 Or parentNode.Nodes(i).text.indexof("/") = 0
                i += 1 : If i > parentNode.Nodes.Count - 1 Then alreadyRun = False : Exit Function
            End While
            runNode = parentNode.Nodes(i)
            NowNode = runNode
            If Breaks Is Nothing Then ReDim Breaks(0)

            ' Если нажали паузу во время зависания зацикливания
            Dim nadoTormoznut As Boolean 'Флаг говорящий что надо однозначно паузнуть на текущем действии
            If Pause And isPotok Then nadoTormoznut = True

            If isPotok Then If PrervaliPotok() Then alreadyRun = False : Return es

            ' Прерывание степа, который не входит внутрь
            If newStepOver Then newStepOver = False : StepOverLocal = True

            ' ВЫПОЛНИТЬ СТРОКУ, если на узле нет контр. точки
            If nadoTormoznut = False And _
            ((Array.IndexOf(Breaks, runNode) = -1 And isSTEP = False And StepOverLocal = False And newStepOut = False) _
             Or param.bylBreakpoint Is parentNode.Nodes(i)) Then
                param.bylBreakpoint = Nothing
                If isPotok = False Then Windows.Forms.Application.DoEvents() ' чтобы действие ниже сразу отрисовалось

                Try
                    es = RunString(runNode.Text, runNode.Tag, param)
                Catch ex As Exception
                    If IgnorEr = False Then
                        Dim deist As String
                        If peremens.isRUN Then
                            If NowNode Is Nothing = False Then
                                deist = vbCrLf & trans("Действие") & ": """ & NowNode.Text & """"
                            End If
                        End If
                        Errors.MessangeCritic(ex.Message & vbCrLf & trans("Событие") & ": """ & parentNode.FullPath & """" & deist)
                    Else
                        es = New ErrString
                    End If
                End Try


            Else 'Рас на узле есть контр. точка(или пошаговое выполнение), то остоновить выполнение программы
                isRUN = False
                ' Если проект запускают как отдельный поток из среды разработки
BreakNode:      If isRunAlg2Code And es.err <> "" Then Return es
                If isPotok Then
                    ' Чтобы вызываемой функции (в данном случае RunProj_NodeStop) были доступны функции потока
                    ' (в данном случае RunString) её надо вызывать в паралельно потоке
                    param.err = es
                    Dim th As New Threading.Thread(AddressOf MnFrmPotok.RunProj_NodeStop)
                    th.Start(New Object() {runNode, param})
                    ' Ожидать пока не запустят или не вырубят проект
                    While isRUN = False
                        Threading.Thread.Sleep(timeSleep * pauseCount)
                        If PrervaliPotok() Then alreadyRun = False : Exit Function
                    End While
                    ' После паузы поток запустили
                    bylBreak = True
                    nadoTormoznut = False : StepOverLocal = False : StepOutLocal = False
                    If newStepOut Then newStepOut = False : StepOutLocal = True
                    ' Если захотели выполнить далеко (в разных событиях) не то действие на котором остановился BreakPoint
                    If FindSobyt(newParent) Is FindSobyt(parentNode) = False Then
                        RunBlock(newParent, newIndex, newParam, True)
                        alreadyRun = False : es.err = "CloseRecurs"
                        If IgnoreErrors = False Then Return es
                    End If
                    ' Рас можно продолжать выполнение в этом событии
                    parentNode = newParent : i = newIndex : param = newParam
                    ' Выполнить действие на котором остановились
                    Windows.Forms.Application.DoEvents() ' чтобы действие ниже сразу отрисовалось
                    Continue While
                Else ' Если проект не одельный поток 
                    ' (внимание, так не будет работать контр.точки в вызываемых искусственно событиях и рекурсии)
                    RaiseEvent NodeStop(runNode, param)
                    alreadyRun = False : Exit Function
                End If
            End If

            ' Выйти из программы (условия,цикла) если такая команда произошла
            If es.err = "BreakApplication" Then
                If StepOutLocal Then newStepOut = True ' Отладка степОут должна продолжиться
                StopProject() : alreadyRun = False : Exit Function
            ElseIf es.err = "BreakEvent" Then
                If StepOutLocal Then newStepOut = True ' Отладка степОут должна продолжиться
                alreadyRun = False : Return es
            ElseIf es.err = "BreakLoop" Then
                If StepOutLocal Then newStepOut = True ' Отладка степОут должна продолжиться
                If EstIfOrWhile(runNode, "While", "EndWhile") Then alreadyRun = False : Return es Else es.err = ""
            ElseIf es.err = "StopIf" Then
                If StepOutLocal Then newStepOut = True ' Отладка степОут должна продолжиться
                If EstIfOrWhile(runNode, "If", "EndIf") Then alreadyRun = False : Return es Else es.err = ""
            ElseIf es.err = "IgnoreErrors" Then
                If StepOutLocal Then newStepOut = True ' Отладка степОут должна продолжиться
                es.err = "" : IgnoreErrors = True
            ElseIf es.err = "Empty" Then
                If StepOutLocal Then newStepOut = True ' Отладка степОут должна продолжиться
                alreadyRun = False : Return es
            ElseIf es.err <> "" And IgnoreErrors = False Then
                isRUN = False : ShowError(es, parentNode.Nodes(i), param) : GoTo BreakNode
            End If
            ' Выполнять подветки в зависимости от результата данной ветки
            If Iz.IsContenerIfs(runNode) Then
                es = UbratKovich(es.str)
                If es.err <> "" And IgnoreErrors = False Then isRUN = False : ShowError(es, parentNode.Nodes(i), param) : GoTo BreakNode
                ' Если условие было истинно, то выполнить действия внутри условия
                Dim GoToEndIf As Boolean = False
                If UCase(es.str) = UCase(trans("Да")) Then
                    newStepOver = StepOverLocal ' Чтобы прерываться внутри условия, при степе без входа внутрь
                    es = RunBlock(runNode, 0, param, False) : GoToEndIf = True
                End If
                If es.err <> "" And es.err <> "StopIf" And IgnoreErrors = False Then alreadyRun = False : Return es
                If es.err = "CloseRecurs" Then alreadyRun = False : Return es
                If isRUN = False Then alreadyRun = False : Exit Function
                ' Перескок run'a на EndIf
                Do
                    ' Если ендиф так и не нашли
                    i += 1
                    If i >= parentNode.Nodes.Count Then
                        If IgnoreErrors Then Exit Do
                        isRUN = False : ShowError(New ErrString("", Errors.NotEndIF(runNode.Text)), parentNode.Nodes(i - 1), param) : alreadyRun = False : Exit Function
                    End If

                    If (parentNode.Nodes(i).tag = "ElseIf" Or parentNode.Nodes(i).tag = "Else") And GoToEndIf = False Then i -= 1 : Exit Do
                    If parentNode.Nodes(i).tag = "EndIf" Then i -= 1 : Exit Do
                Loop
            ElseIf runNode.Tag = "While" Then
                es = UbratKovich(es.str)
                If es.err <> "" And IgnoreErrors = False Then isRUN = False : ShowError(es, parentNode.Nodes(i), param) : GoTo BreakNode
                ' Если условие было истинно, то выполнить действия внутри цикла
                If UCase(es.str) = UCase(trans("Да")) Then
                    newStepOver = StepOverLocal ' Чтобы прерываться внутри цикла, при степе без входа внутрь
                    es = RunBlock(runNode, 0, param, False)
                    If (es.err <> "" And es.err <> "BreakLoop" And IgnoreErrors = False) Or isRUN = False Then
                        alreadyRun = False : Return es
                    End If
                    If es.err = "CloseRecurs" Then alreadyRun = False : Return es
                    ' цикл пройден, теперь надо проверить не бесконечный ли он?
                    'WhileCount += 1
                    'If WhileCount > maxWhileCount Then
                    '    Dim text As String = MoreCycles(runNode.Text, maxWhileCount)
                    '    If MsgBox(text, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    '        es.err = "BreakLoop" : Return es
                    '    End If
                    '    WhileCount = 0
                    'End If
                    Application.DoEvents()
                    If isRUN = False Then Return es
                    ' цикл пройден, теперь надо вызвать его заново, этот ранблок завершить
                    If es.err = "BreakLoop" Then i += 2 : Continue While 'es = RunBlock(parentNode, i, param, IdtiNaVerhUrovni, WhileCount) : Return es
                Else
                    If whileBeen Is runNode Then i += 2 : Continue While
                End If
            End If
            ' Именно при доходе до ендвайла нужно определиться, проходить ли цикл заново
            If runNode.Tag = "EndWhile" Then
                If i > 0 Then
                    Dim wi As Integer = i
                    Do ' Поиск вайла, принадлежащего этому эндвайлу
                        wi -= 1
                        If wi < 0 Then Exit Do
                        If parentNode.Nodes(wi).Tag = "While" Then whileBeen = parentNode.Nodes(wi) : Exit Do
                    Loop
                    If wi >= 0 Then i = wi : Continue While ' Перейти заново на вайл
                End If
                'If isRUN = False Then Exit Function
                '' Перескок run'a на EndIf
                'Do
                '    ' Если ендиф так и не нашли
                '    If i >= parentNode.Nodes.Count Then
                '        isRUN = False : ShowError(New ErrString("", Errors.NotEndIF(runNode.Text)), parentNode.Nodes(i - 1), param) : Exit Function
                '    End If
                '    If parentNode.Nodes(i).tag = "EndWhile" Then i -= 1 : Exit Do
                '    i += 1
                'Loop
            End If
            If parentNode.Nodes(i).tag = "EndIf" Then
                If i - 1 < 0 Then es.err = trans("Лишнее действие ""Конец условия""") : Return es
                If Iz.IsContenerIfs(parentNode.Nodes(i - 1)) = False Then es.err = trans("Лишнее действие ""Конец условия""") : Return es
            End If
            i += 1
        End While
        ' Прерывание степа, который не входит внутрь
        If StepOverLocal Then newStepOver = True
        If StepOutLocal Then newStepOut = True

        ' Надо ли искать действия более высокого уроня, чтобы их выполнить
        If IdtiNaVerhUrovni Then
            If parentNode.Parent.Tag <> "Obj" Then
                ind = parentNode.Parent.Nodes.IndexOf(parentNode) + 1
                If ind >= parentNode.Parent.Nodes.Count Then alreadyRun = False : Exit Function
                Dim nextNode As TreeNode = parentNode.Parent.Nodes(ind)
                ' Если следующий узел это ЕлсеИф или Елсе, то идти на ЕндИф
                If Iz.IsVnutreniyIf(nextNode) Then
                    i = nextNode.Index + 1
                    Do ' Перескок run'a на EndIf
                        ' Если ендиф так и не нашли
                        If i >= parentNode.Parent.Nodes.Count Then
                            If IgnoreErrors Then Exit Do
                            isRUN = False : ShowError(New ErrString("", Errors.NotEndIF(nextNode.Text)), parentNode.Parent.Nodes(i - 1), param) : alreadyRun = False : Exit Function
                        End If
                        If parentNode.Parent.Nodes(i).tag = "EndIf" Then nextNode = parentNode.Parent.Nodes(i)
                        i += 1
                    Loop
                End If
                es = RunBlock(parentNode.Parent, nextNode.Index, param, False)
                If isRUN = False Then alreadyRun = False : Exit Function
            End If
        End If
        If bylBreak Then GotFocus()
        alreadyRun = False
    End Function
    ' ВЫВОД ОШИБОК
    Sub ShowError(ByVal es As ErrString, ByVal node As TreeNode, ByVal param As PropertysSobyt)
        If es.err = "!" Then es.err = trans("Непредвиденная ошибка")
        param.err = es
        ' Если выполняется команда Выполнить код алгоритма2
        If isRunAlg2Code Then
            Dim cs As New CodeString(UbratKluchSlova(node.Tag, node.Text), , False)
            Dim txt As String = OutputRun(node.Tag, cs.Split("naOdnomUrovne").texty, param)
            isRUN = True
            Errors.MessangeCritic(txt)
            Exit Sub
        End If
        ' Если проект запускают как отдельный поток из среды разработки
        If isPotok Then
            ' Чтобы вызываемой функции (в данном случае RunProj_NodeStop) были доступны функции потока
            ' (в данном случае RunString) её надо вызывать в паралельно потоке
            Dim th As New Threading.Thread(AddressOf MnFrmPotok.RunProj_NodeStop)
            th.Start(New Object() {node, param})
        Else
            RaiseEvent NodeStop(node, param)
        End If
    End Sub
    Function EstIfOrWhile(ByVal node As TreeNode, ByVal IfOrWhile As String, ByVal EndIfOrEndWhile As String) As Boolean
        ' Переходим на уровень узлов, на котором будем искать условия
        Dim parentNode As TreeNode = node.Parent
        If parentNode Is Nothing Then Return False
        While parentNode.Tag <> "Sobyt"
            ' получаем индекс первого узла, с которого начнем просмотр
            Dim i As Integer = parentNode.Index + 1
            ' Получаем родителя внутрит которого и ищутся условия
            parentNode = parentNode.Parent
            If parentNode Is Nothing Then Return False
            ' Поиск EndIf'a
            Do
                ' Если ендиф так и не нашли
                If i >= parentNode.Nodes.Count Then Exit Do
                If parentNode.Nodes(i).Tag = IfOrWhile Then Exit Do
                If parentNode.Nodes(i).Tag = EndIfOrEndWhile Then Return True
                i += 1
            Loop
        End While
        Return False
    End Function
    ' ВЫПОЛНИТЬ СТРОКУ, УЗЕЛ В ДЕРЕВЕ ДЕЙСТВИЙ
    Function RunString(ByVal str As String, ByVal type As String, ByVal param As PropertysSobyt) As ErrString
        Dim ret As ErrString, st As SolvingTree
        Dim es As ErrString, cs As CodeString
        Dim i, j As Integer
        If type.IndexOf("Empty") = 0 Then es = New ErrString(str, "Empty") : Return es

        MyClass.Param = param
        If type = "Deist" Then
            Dim sp() As String
            cs = New CodeString(str, , False)
            sp = cs.Split("naOdnomUrovne", "=").texty
            ' Присвоить результат, если действие было присваиваительное
            If sp.Length = 2 Then
                ret = TranslateALL("(" & sp(1) & ")")
                If ret.err <> "" Then Return ret
            ElseIf sp.Length = 1 Then
                If isRUN = False Then ret = TranslateALL("(" & sp(0) & ")")
            ElseIf sp.Length > 2 Then
                Return New ErrString(str, Errors.MnogoRavno)
            End If
            Dim obStr As ErrString = isObj(sp(0))
            If sp.Length = 2 Or (obStr.str <> "" And obStr.err = "") Then
                If obStr.err <> "" Then Return obStr
                Dim args(), prop As String, MyObjs() As Object
                ' Функция, что бы получить по ссылке переменные prop, args, MyObjs
                es = GetMyObjWithProps(sp(0), obStr.str, prop, args, MyObjs)
                ' ЕСЛИ ИДЕТ СУПЕР-КОМПИЛЯЦИЯ А НЕ ДЕБАГ
                If isCompilBest Then
                    ' Если небыло ошибки при трансляторизации объекта до '='
                    If es.err = "" Then
                        es = GetVBCodeNameObjWithProps(sp(0), obStr.str, prop, args, MyObjs)
                        ' Если объект имел сложную структуру (например с индексами) то тут нужно через TranslateALL
                    Else
                        es = TranslateALL("(" & sp(0) & ")")
                        If es.str.Length > 2 Then es.str = es.str.Substring(1, es.str.Length - 2)
                    End If
                    ' If args IsNot Nothing Then es.str &= "(" & Join(args, ", ") & ")"
                    ' Убираем скобки
                    If ret.str.Length > 2 Then
                        ret.str = ret.str.Substring(1, ret.str.Length - 2)
                    Else ' Если хотели присвоить пустоту, то в базике она обозначается так - ""
                        ret.str = """"""
                    End If
                    If sp.Length = 2 Then
                        Return New ErrString(es.str & " = " & ret.str)
                    ElseIf sp.Length = 1 Then
                        Return New ErrString(ret.str)
                    ElseIf sp.Length > 2 Then
                        Return New ErrString(str, Errors.MnogoRavno)
                    End If
                End If
                If es.err <> "" Then Return es
                ' Убрать кавычки из присваимаевого значения и аргументов
                ret = UbratKovich(ret.str)
                If ret.err <> "" Then Return ret
                If args Is Nothing = False Then
                    For j = 0 To args.Length - 1
                        If Iz.isCode(args(j)) Then
                            cs.Text = args(j)
                            es = TranslateALL(args(j))
                            If es.err <> "" Then Return es
                            es = UbratKovich(es.str)
                        Else
                            es = UbratKovich(args(j))
                        End If
                        If es.err <> "" Then Return es Else args(j) = es.str
                    Next
                End If
                ' Если идет отладка тогда вернуть получившееся значение
                If isRUN = False Then
                    For i = 0 To MyObjs.Length - 1
                        es = GetPropertyMethod(MyObjs(i), prop, "", args)
                        If es.err <> "" Then Return es
                        If es.str = "" Then Return New ErrString("")
                        If es.str <> ret.str And sp.Length > 1 Then Return New ErrString(trans("Эти значения не равны"))
                    Next
                    If sp.Length > 1 Then Return New ErrString(trans("Эти значения одинаковы"))
                    Return ret
                End If
                ' Пройтись по объектам (в 99% это один объект) и присвоить значение свойтву или выполнить метод
                For i = 0 To MyObjs.Length - 1
                    es = SetPropertyMethod(MyObjs(i), prop, ret.str, args)
                    If es.err <> "" Then Return es
                Next
            Else
                ' Если идет отладка тогда вернуть получившееся значение
                If isRUN = False Then Return ret
                MsgBox(ret.str)
            End If
        ElseIf type = "Else" Then
            If isCompilBest = False Then
                ret.str = trans("Да") : Return ret
            Else
                ret.str = type : Return ret
            End If
        ElseIf Iz.IsContenerIfs(type) Or type = "While" Then
            Dim expr As String = str
            ' Отшелушивание всяких Если и ИлиЕсли если требуется
            If isRUN = True Then
                expr = "(" & UbratKluchSlova(type, expr) & ")"
            ElseIf isCompilBest Then
                expr = "returnBoolean(" & UbratKluchSlova(type, expr) & ")"
            Else
                expr = "(" & expr & ")"
            End If
            ' Создание дерева решения с помощью рекурсивной функции CreateSolvingTree
            st = New SolvingTree(expr, 0, CreateSolvingTree(New MySplitStruct(False, expr)))
            st = CorrectingSolvingTree(st)
            ' Перевести дерево в одну строку, и выполнить все переводы в текст
            ret = TranslateSolvingTree(st)
            ' Если была ошибка тогда вернуть получившееся значение
            If ret.err <> "" Then ret.str = str : Return ret
            If isCompilBest Then
                ret.str = type & " " & ret.str
                If type = "If" Or type = "ElseIf" Then ret.str &= " " & trans("тогда", True)
                If type = "While" Then ret.str &= vbCrLf & "Application.DoEvents()"
            End If
            ' Вернуть истинно условие или ложно
            Return ret
        ElseIf (type = "EndIf" Or type = "EndWhile") And isCompilBest Then
            ret.str = trans(str, True) : Return ret
        End If
    End Function
    ' Отсекает лишние корни, которые образовались для удобства рекурсии CreateSolvingTree
    Function CorrectingSolvingTree(ByVal st As SolvingTree) As SolvingTree
        'While st.chld Is Nothing = False
        '    If st.chld.Length <> 1 Then Exit While
        '    ' Если ветка и ее потомок идиентичны, то оставить из них двоих одну
        '    If st.txt = st.chld(0).txt _
        '    And st.index = st.chld(0).index _
        '    And st.oldvalue = st.chld(0).oldvalue Then
        '        If st.chld(0).chld Is Nothing Then
        '            st = st.chld(0)
        '        ElseIf st.chld.Length = st.chld(0).chld.Length Then
        '            st = st.chld(0)
        '        Else
        '            Exit While
        '        End If
        '    Else
        '        Exit While
        '    End If
        'End While
        st = st.chld(0)
        If st.chld Is Nothing = False Then st.chld(0).top = st ' Сделать у chld'а ссылку на родительский элемент
        st.top = Nothing
        Return st
    End Function
    Function TranslateALL(ByVal myCode As String) As ErrString
        Dim ret As ErrString, st As SolvingTree
        ' Создание дерева решения с помощью рекурсивной функции CreateSolvingTree
        st = New SolvingTree(myCode, 0, CreateSolvingTree(New MySplitStruct(False, myCode)))
        ' лишние корни, которые образовались для удобства рекурсии CreateSolvingTree
        st = CorrectingSolvingTree(st)
        ' Перевести дерево в одну строку, и выполнить все переводы в текст
        ret = TranslateSolvingTree(st)
        ' Если была ошибка тогда вернуть получившееся значение
        If ret.err <> "" Then ret.str = myCode
        Return ret
    End Function
    ' СОЗДАНИЕ ДЕРЕВА РЕШЕНИЙ, В КОТОРОМ ЧЕМ БОЛЬШЕ ВЛОЖЕННОСТЬ В СКОБКИ, ТЕМ ДАЛЬШЕ ОТ КОРНЯ ДЕРЕВА
    Function CreateSolvingTree(ByVal SplStr As MySplitStruct) As SolvingTree()
        Dim i, j As Integer, ret() As SolvingTree = Nothing
        For i = 0 To SplStr.texty.Length - 1
            Dim st As SolvingTree
            Dim SplStr2lev As MySplitStruct = New CodeString(SplStr.texty(i), , False).Split("naVtoromUrovne")
            ' Если на втором уровне сплит смог разбить строку на состовляющие
            If SplStr2lev.texty(0) <> SplStr.texty(i) Then
                st = New SolvingTree(SplStr.texty(i), SplStr.indexy(i), CreateSolvingTree(SplStr2lev))
                ' Сделать у всех chld'ов топы
                For j = 0 To st.chld.Length - 1 : st.chld(j).top = st : Next
            Else ' если это высший уровень и дальше уже разбить строку нельзя
                st = New SolvingTree(SplStr.texty(i), SplStr.indexy(i), Nothing)
            End If
            ReDims(ret) : ret(ret.Length - 1) = st
        Next
        Return ret
    End Function
    
    ' РЕШЕНИЕ ДЕРЕВА РЕШЕНИЙ И СБОРКА ЕГО В ОДНУ СТРОКУ
    Function TranslateSolvingTree(ByRef st As SolvingTree) As ErrString
        Dim i, len As Integer, es As ErrString
        ' Если это лист дерева
        If st.chld Is Nothing Then
            '  If st.txt = st.oldvalue Then es = TranslateKuso4ek(st.txt) Else es = New ErrString(st.txt)
            ' Заменить значение
            es = TranslateKuso4ek(st.txt)
            If es.err <> "" Then Return es ' если была ошибка, то она сохранилась в err
            st.txt = es.str
            ' если этот лист одновременно не является корнем дерева
            If st.top Is Nothing = False Then
                Dim sb As New System.Text.StringBuilder(st.top.txt) ' у StringBuilder хорошая ф-я Replace
                ' Индекс листа в родительской ветки
                Dim ind As Integer = Array.IndexOf(st.top.chld, st)
                ' Заменить в родительской ветке старое значение листа на новое
                If st.oldvalue.Length > 0 Then
                    len = st.oldvalue.Length + 1
                    If len + st.index > sb.Length Then len = sb.Length - st.index
                    sb = sb.Replace(st.oldvalue, st.txt, st.index, len)
                    st.top.txt = sb.ToString
                    ' Подстроить все индексы листов, которые правее данного, под изменение, сделанное выше
                    Dim delta As Integer = st.txt.Length - st.oldvalue.Length
                    For i = ind + 1 To st.top.chld.Length - 1
                        st.top.chld(i).index += delta
                    Next
                End If
                ' Удаление листа дерева
                DelDims(st.top.chld, ind)
            End If
        Else
            ' рас это не лист а ветка, то пройтись по всем веткам
            For i = st.chld.Length - 1 To 0 Step -1
                es = TranslateSolvingTree(st.chld(i))
                If es.err <> "" Then Return es
            Next
        End If
        If st.top Is Nothing Then
            ' Если все листья дерева не свернулись до корня, то еще раз пройтись по всем листьям, сворачивая их на один уровень ниже
            If st.chld Is Nothing = False Then
                es = TranslateSolvingTree(st)
                If es.err <> "" Then Return es
            End If
            If st.chld Is Nothing Then
                If isCompilBest = False Then Return TranslateWord(st.txt) Else Return New ErrString(st.txt)
            End If

        End If
    End Function
    ' ПЕРЕВОД КУСОЧКА СТРОКИ, СОПОСТОВИМОГО ПО РАЗМЕРАМ СО СКОБКОЙ
    Function TranslateKuso4ek(ByVal kusok As String) As ErrString
        If kusok = "" Then Return New ErrString(kusok)
        If (kusok.Chars(0) = "(" And kusok.Chars(kusok.Length - 1) = ")") Or (kusok.Chars(0) = "[" And kusok.Chars(kusok.Length - 1) = "]") Then
            'op_skobka = kusok.Chars(0) : cl_skobka = kusok.Chars(kusok.Length - 1)
            Dim cs2 As New CodeString(kusok, "None", False)
            While cs2.PropuskSkobok(0, kusok.Chars(0), kusok.Chars(kusok.Length - 1)) = kusok.Length - 1
                kusok = kusok.Substring(1, kusok.Length - 2)
                If kusok = "" Then Return New ErrString(kusok)
            End While
        End If
        Dim cs As CodeString ', Razdelitel As String = "All"
        If isCompilBest = False Then
            cs = New CodeString(kusok, "UslovsBezZapyatoi", False)
        Else
            'If kusok.IndexOf("RunProj.GetObjFromUniqName") = -1 Then
            '    Razdelitel = "All"
            'Else
            '    Razdelitel = "AllWithAndOr"
            'End If
            cs = New CodeString(kusok, "AllWithAndOr", False)
        End If
        Dim sb As New System.Text.StringBuilder(kusok)
        Dim splt As MySplitStruct = cs.Split("vezde")
        Dim tmp As String, i = 1, j As Integer = 0
        ' После разбития куска на числа, свойства и методы, текст и т.д., а между ними +,-,& и т.д. пройтись по ним и сосчитать
        Dim priors() As Object = Prioritets
        If isCompilBest Then
            ReDim Preserve priors(Prioritets.Length) : priors(priors.Length - 1) = New String() {"AND", "OR"}
        End If
        If splt.splity Is Nothing = False Then
            For j = 0 To priors.Length - 1
                i = 0
                While i < splt.texty.Length - 1
                    i += 1
                    Dim spl As String = splt.splity(i - 1)
                    ' Раобтаем только c операторами определенного уровня приоритета
                    If Array.IndexOf(priors(j), spl) = -1 Then
                        ' And (isCompilBest = False And (spl <> "[" Or spl <> "]")) Then Continue While
                        If isCompilBest = False And (spl <> "[" Or spl <> "]") Then
                            Continue While
                        ElseIf isCompilBest = True Then
                            'If Razdelitel = "AllWithAndOr" Then
                            If spl <> "[" And spl <> "]" And spl <> "(" And spl <> ")" And spl <> "," Then
                                Continue While
                            End If
                            'Else
                            '    If spl <> "[" And spl <> "]" And spl <> "(" And spl <> ")" And spl <> "," And UCase(spl) <> UCase("And") And UCase(spl) <> UCase("Or") Then
                            '        Continue While
                            '    End If
                            'End If
                        End If
                    End If
                    ' Получаем два значения, находящиеся по краям знака
                    Dim val1, val2 As ErrString
                    val1 = TranslateWord(splt.texty(i - 1))
                    If val1.err <> "" Then Return val1
                    val2 = TranslateWord(splt.texty(i))
                    If val2.err <> "" Then Return val2
                    ' ЕСЛИ ИДЕТ ОКОНЧАТЕЛЬНАЯ КОМПИЛЯЦИЯ А НЕ ДЕБАГ
                    If isCompilBest Then
                        ' Сделать возможность, чтобы ничего можно было бы обозначать пустотой, а не ""
                        If val2.str = "" Then
                            If Array.IndexOf(uslovs, spl) <> -1 Or Array.IndexOf(opers, spl) <> -1 Or spl = "," Or spl = "[" Or spl = "(" Then
                                If i = splt.texty.Length - 1 Then
                                    val2.str = """"""
                                Else
                                    If Array.IndexOf(uslovs, splt.splity(i)) <> -1 Or Array.IndexOf(opers, splt.splity(i)) <> -1 _
                                    Or splt.splity(i) = "," Or splt.splity(i) = "]" Or splt.splity(i) = ")" Then
                                        val2.str = """"""
                                    End If
                                End If
                            End If
                        End If
                        If spl = "+" Or spl = "-" Or spl = "*" Or spl = "/" Or spl = "\" Or spl = "^" Or spl = ">" Or spl = "<" Or spl = ">=" Or spl = "=>" Or spl = "<=" Or spl = "=<" Then
                            If IsNumeric(val1.str) = False Then val1.str = InsertToDouble(val1.str)
                            If IsNumeric(val2.str) = False Then val2.str = InsertToDouble(val2.str)
                            ' Супер прием, позволяющий базику рассматривать строки как числа
                            ' val1.str &= " + 0 "
                            tmp = val1.str & " " & spl & " " & val2.str
                        ElseIf spl = "=" Then
                            tmp = val1.str & " <=> " & val2.str
                        ElseIf spl = "<=>" Then
                            tmp = val1.str & " = " & val2.str
                        ElseIf spl = trans("_И") Then
                            tmp = val1.str & " And " & val2.str
                        ElseIf spl = trans("_ИЛИ") Then
                            tmp = val1.str & " Or " & val2.str
                        ElseIf spl = "%" Then
                            If IsNumeric(val1.str) = False Then val1.str = InsertToDouble(val1.str)
                            If IsNumeric(val2.str) = False Then val2.str = InsertToDouble(val2.str)
                            tmp = val1.str & " Mod " & val2.str
                        ElseIf spl = "[" Then
                            Dim cs2 As New CodeString(val1.str, , False)
                            Dim mss2 As MySplitStruct = cs2.Split("vezde")
                            Dim tmp2 As String = mss2.texty(mss2.texty.Length - 1)
                            tmp = val1.str.Substring(0, val1.str.Length - tmp2.Length)
                            tmp &= GetVBCodeNameObjWithProps("", tmp2, "", Nothing, Nothing).str
                            ' If splt.splity(i) <> "]" Then
                            tmp &= " & ""["" & " & val2.str
                            'End If
                        ElseIf spl = "]" Then
                            tmp = val1.str & " & ""]"")" & val2.str
                        ElseIf (spl = "AND" Or spl = "OR") Then 'And Razdelitel = "AllWithAndOr" Then
                            tmp = " returnBoolean( " & val1.str & " ) " & spl & " returnBoolean( " & val2.str & " ) "
                        Else
                            tmp = val1.str & " " & spl & " " & val2.str
                        End If
                    Else
                        ' РЕЖИМ ДЕБАГА
                        ' Математические операции
                        If spl = "+" Or spl = "-" Or spl = "*" Or spl = "/" Or spl = "\" Or spl = "%" Or spl = "^" Then
                            val1 = TranslateToDouble(val1.str)
                            If val1.err <> "" Then Return val1
                            val2 = TranslateToDouble(val2.str)
                            If val2.err <> "" Then Return val2
                            If spl = "+" Then
                                tmp = ToDouble(val1.str) + ToDouble(val2.str)
                            ElseIf spl = "-" Then
                                tmp = ToDouble(val1.str) - ToDouble(val2.str)
                            ElseIf spl = "*" Then
                                tmp = ToDouble(val1.str) * ToDouble(val2.str)
                            ElseIf spl = "/" Then
                                If ToDouble(val2.str) = 0 Then Return New ErrString(kusok, Errors.DivideByZero(kusok))
                                tmp = ToDouble(val1.str) / ToDouble(val2.str)
                            ElseIf spl = "\" Then
                                If ToDouble(val2.str) = 0 Then Return New ErrString(kusok, Errors.DivideByZero(kusok))
                                tmp = ToDouble(val1.str) \ ToDouble(val2.str)
                            ElseIf spl = "%" Then
                                tmp = ToDouble(val1.str) Mod ToDouble(val2.str)
                            ElseIf spl = "^" Then
                                tmp = ToDouble(val1.str) ^ ToDouble(val2.str)
                            End If
                            tmp = """" & tmp & """"
                        ElseIf spl = ">" Or spl = "<" Or spl = ">=" Or spl = "=>" Or spl = "<=" Or spl = "=<" Then
                            ' Математическо-логические операции
                            val1 = TranslateToDouble(val1.str)
                            If val1.err <> "" Then Return val1
                            val2 = TranslateToDouble(val2.str)
                            If val2.err <> "" Then Return val2
                            If spl = ">" Then
                                If ToDouble(val1.str) > ToDouble(val2.str) Then tmp = trans("Да") Else tmp = trans("Нет")
                            ElseIf spl = "<" Then
                                If ToDouble(val1.str) < ToDouble(val2.str) Then tmp = trans("Да") Else tmp = trans("Нет")
                            ElseIf spl = ">=" Or spl = "=>" Then
                                If ToDouble(val1.str) >= ToDouble(val2.str) Then tmp = trans("Да") Else tmp = trans("Нет")
                            ElseIf spl = "<=" Or spl = "=<" Then
                                If ToDouble(val1.str) <= ToDouble(val2.str) Then tmp = trans("Да") Else tmp = trans("Нет")
                            End If
                        Else
                            ' Логические операции и склеивание
                            val1 = UbratKovich(val1.str)
                            If val1.err <> "" Then Return val1
                            val2 = UbratKovich(val2.str)
                            If val2.err <> "" Then Return val2
                            If spl = "=" Then
                                If UCase(val1.str) = UCase(val2.str) Then tmp = trans("Да") Else tmp = trans("Нет")
                            ElseIf spl = "<=>" Then
                                If val1.str = val2.str Then tmp = trans("Да") Else tmp = trans("Нет")
                            ElseIf spl = "<>" Then
                                If val1.str <> val2.str Then tmp = trans("Да") Else tmp = trans("Нет")
                            ElseIf spl = trans("_И") Then
                                If val1.str = trans("Да") And val2.str = trans("Да") Then tmp = trans("Да") Else tmp = trans("Нет")
                            ElseIf spl = trans("_ИЛИ") Then
                                If val1.str = trans("Да") Or val2.str = trans("Да") Then tmp = trans("Да") Else tmp = trans("Нет")
                            ElseIf spl = "&" Then
                                tmp = """" & CreateKovich(val1.str & val2.str) & """"
                            End If
                        End If
                    End If

                    DelDims(splt.splity, i - 1) : DelDims(splt.texty, i - 1)
                    splt.texty(i - 1) = tmp
                    i -= 1
                End While
            Next
        ElseIf isCompilBest Then
            Return TranslateWord(kusok)
        End If

        ' If op_skobka <> "" Then kusok = op_skobka & kusok & cl_skobka
        If splt.texty.Length = 1 And isCompilBest = False Then
            Dim es As ErrString = TranslateWord(splt.texty(0))
            If es.err <> "" Then Return es
            splt.texty(splt.texty.Length - 1) = es.str
            ' СУПЕР-КОМПИЛЯЦИЯ
            'ElseIf splt.texty.Length > 1 And isCompilBest Then
            '    tmp = ""
            '    For i = 0 To splt.splity.Length - 1
            '        'If splt.splity(i) = "[" Then
            '        '    tmp &= GetVBCodeNameObjWithProps("", splt.texty(i), "", Nothing, Nothing).str
            '        '    If splt.splity(i) <> "]" Then
            '        '        tmp &= " & ""["" & "
            '        '    End If
            '        'ElseIf splt.splity(i) = "]" Then
            '        '    splt.texty(i) = TranslateWord(splt.texty(i)).str
            '        '    tmp &= splt.texty(i) & " & ""]"")"
            '        'Else
            '        '    splt.texty(i) = TranslateWord(splt.texty(i)).str
            '        '    'If splt.splity(i) = "+" Then
            '        '    '    tmp = " toDouble(" & splt.texty(i) & ") " & splt.splity(i) & " "
            '        '    'Else
            '        '    tmp &= " " & splt.texty(i) & " " & splt.splity(i) & " "
            '        '    'End If
            '        'End If
            '    Next
            '    splt.texty(i) = tmp & " " & splt.texty(i)
            '    'Return New ErrString(tmp)
        End If

        Dim myCode As String = splt.texty(splt.texty.Length - 1)
        cs = New CodeString(myCode, , False)
        If cs.IndexOf("<=>") <> -1 Then
            Dim ret As ErrString, st As SolvingTree
            ' Создание дерева решения с помощью рекурсивной функции CreateSolvingTree
            ret.str = CreateSolvingTreeRavno(myCode)
            Return ret
        End If

        ' cs = New CodeString("(" & splt.texty(splt.texty.Length - 1) & ")", "<=> and high", False)
        'Dim mss As MySplitStruct = cs.Split("naVtoromUrovne")

        Return New ErrString(splt.texty(splt.texty.Length - 1))
    End Function
    Function InsertToDouble(ByVal str As String)
        'str = "RunProj.GetObjFromUniqName(""Окно0.Тбл003"").Props.Itemvalue ( 0 , 0 ) "
        Dim ind = 0, i = 0, openSkobok = 0, closeSkobok As Integer = 0
        ' Подсчет открытых и закрытых скобок
        ind = str.IndexOf("(")
        While ind <> -1
            openSkobok += 1
            If ind + 1 >= str.Length Then Exit While
            ind = str.IndexOf("(", ind + 1)
        End While
        ind = str.IndexOf(")")
        While ind <> -1
            closeSkobok += 1
            If ind + 1 >= str.Length Then Exit While
            ind = str.IndexOf(")", ind + 1)
        End While
        ' Вставка в нужное место в зависимости от количества скобок
        If openSkobok > closeSkobok Then
            'ind = 0
            'For i = 1 To openSkobok - closeSkobok
            '    ind = str.IndexOf("(", ind)
            '    ind = ind + 1
            'Next
            'str = str.Insert(ind, "ToDouble(") & ")"
        ElseIf closeSkobok > openSkobok Then
            'ind = str.Length
            'For i = 0 To closeSkobok - openSkobok
            '    If str.LastIndexOf(")", ind) <= -1 Then Exit For
            '    ind = str.LastIndexOf(")", ind)
            '    ind = ind - 1
            'Next
            'If str.IndexOf("ToDouble(") <> 0 Then str = "ToDouble(" & str.Insert(ind + 1, ")")
        Else
            If str.IndexOf("ToDouble(") <> 0 And str.IndexOf("ToDouble ( ") Then
                ' нельзя чтобы ) была раньше чем (
                If str.IndexOf("(") > str.IndexOf(")") Then Return str

                ' Если есть ЗАПЯТЫЕ, то это уже не единая лексема
                Dim cs As New CodeString(str, , False)
                Dim ind_zap As Integer = cs.IndexOf(",", , True) ' False)
                If ind_zap <> -1 Then Return str
                'If ind_zap <> -1 Then
                '    ' Причем если
                '    openSkobok = 0 : closeSkobok = 0
                '    ind = cs.LastIndexOf("(", str.Length - ind_zap)
                '    While ind <> -1
                '        openSkobok += 1
                '        If ind <= 0 Then Exit While
                '        ind = cs.LastIndexOf("(", str.Length - (ind - 1))
                '    End While
                '    ind = cs.IndexOf(")", ind_zap)
                '    While ind <> -1
                '        closeSkobok += 1
                '        If ind + 1 >= str.Length Then Exit While
                '        ind = str.IndexOf(")", ind + 1)
                '    End While
                '    If closeSkobok > openSkobok Then Return str
                'End If

                ' Сделать числом
                str = "ToDouble(" & str & ")"
            End If
        End If
        Return str
    End Function
    ' СОЗДАНИЕ ДЕРЕВА РЕШЕНИЙ, В КОТОРОМ ЧЕМ БОЛЬШЕ ВЛОЖЕННОСТЬ В СКОБКИ, ТЕМ ДАЛЬШЕ ОТ КОРНЯ ДЕРЕВА
    Function CreateSolvingTreeRavno(ByVal myCode As String, Optional ByVal bezSkovok As Boolean = False) As String
        If bezSkovok = False Then myCode = "(" & myCode & ")"
        Dim i As Integer, str As String = "", txt As String
        Dim st As SolvingTree
        Dim SplStr2lev As MySplitStruct = New CodeString(myCode, "<=> and high", False).Split("naVtoromUrovne")
        ' Если на втором уровне сплит смог разбить строку на состовляющие
        If SplStr2lev.splity IsNot Nothing Then
            For i = 0 To SplStr2lev.splity.Length - 1
                If SplStr2lev.splity(i) = "<=>" Then
                    str &= SdelatUCase(CreateSolvingTreeRavno(SplStr2lev.texty(i))) & " = "
                Else
                    If i > 0 Then
                        If SplStr2lev.splity(i - 1) = "<=>" Then
                            str &= SdelatUCase(CreateSolvingTreeRavno(SplStr2lev.texty(i))) & " " & SplStr2lev.splity(i) & " "
                            Continue For
                        End If
                    End If
                    str &= CreateSolvingTreeRavno(SplStr2lev.texty(i)) & " " & SplStr2lev.splity(i) & " "
                End If
            Next
            If SplStr2lev.splity(i - 1) = "<=>" Then
                str &= SdelatUCase(CreateSolvingTreeRavno(SplStr2lev.texty(i))) & " "
            Else
                str &= " " & CreateSolvingTreeRavno(SplStr2lev.texty(i))
            End If
            Return str
        Else
            ' если это высший уровень и дальше уже разбить строку нельзя
            If myCode = SplStr2lev.texty(SplStr2lev.texty.Length - 1) Then
                Return myCode
            Else
                ' ЕСЛИ ЕСТЬ ЕЩЕ УРОВНИ, ГДЕ МОЖЕТ СКРЫВАТЬСЯ <=>
                txt = SplStr2lev.texty(SplStr2lev.texty.Length - 1)
                ' Ищем слудующий уровень простым способом - самая левая "(" и самая правая ")"
                Dim indL, indR As Integer
                Dim vtorNow As String = GetStrIncludesSkobki(txt, indL, indR)
                ' Ищем следующий уровень прогрессивным способом - с подсчетом откр. и закр. скобок
                Dim vtorReal As String = New CodeString(txt, "None").Split("naVtoromUrovne").texty(0)

                ' ЕСЛИ ВТОРОЙ УРОВЕНЬ ОБЫКНОВЕННЫЙ А НЕ ДВОЙНОЙ (напр., "Окно1("1").Команда("арги"))
                If Trim(vtorNow) = Trim(vtorReal) Then
                    ' Находим все что до скобок, и все что после них
                    Return Left(txt, indL) & CreateSolvingTreeRavno(txt, True) & Right(txt, txt.Length - indR) & " "
                Else
                    ' ЕСЛИ ВТОРОЙ УРОВЕНЬ ДВОЙНОЙ
                    Dim SplStr As MySplitStruct = New CodeString(txt, "Uslovs", False).Split("naOdnomUrovne")
                    If SplStr.texty.Length = 1 Then
                        ' Разбиваем его на подстроки (напр., 'Окно1("1").Команда("арги")' = 'Окно1("1")' и '.Команда("арги")')
                        Dim part1 As String = txt.Substring(0, txt.Length - vtorReal.Length - 2)
                        Dim ind As Integer = part1.LastIndexOf(")")
                        part1 = txt.Substring(0, ind + 1)
                        Dim part2 As String = txt.Substring(ind + 1)

                        ' Склеиваем подстроки 
                        Dim indL1, indR1, indL2, indR2 As String
                        GetStrIncludesSkobki(part1, indL1, indR1)
                        GetStrIncludesSkobki(part2, indL2, indR2)
                        Return Left(part1, indL1) & CreateSolvingTreeRavno(part1, True) & Right(part1, part1.Length - indR1) & " " _
                            & Left(part2, indL2) & CreateSolvingTreeRavno(part2, True) & Right(part2, part2.Length - indR2) & " "
                    Else
                        str = ""
                        For i = 0 To SplStr.texty.Length - 1
                            str &= CreateSolvingTreeRavno("(" & SplStr.texty(i) & ")", True)
                            If i < SplStr.splity.Length Then str &= " " & SplStr.splity(i) & " "
                        Next
                        Return str
                    End If
                End If

            End If
        End If
    End Function
    Function GetStrIncludesSkobki(ByVal txt As String, ByRef indL As Integer, ByRef indR As Integer)
        Dim cs As New CodeString(txt, , False)

        ' Находим все что до скобок и все что после них
        indL = cs.IndexOf("(")
        indR = cs.LastIndexOf(")")
        Dim indL2 As Integer = cs.IndexOf("[")
        Dim indR2 As Integer = cs.LastIndexOf("]")
        If indL2 < indL And indL2 <> -1 Then indL = indL2 : indR = indR2
        If indL = -1 Then indL = 0 Else indL += 1
        If indR = -1 Then indR = txt.Length

        Return txt.Substring(indL, indR - indL)
    End Function
    Private Function SdelatUCase(ByVal str As String) As String
        If str = "" Then Return ""
        If str.Replace(" ", "").IndexOf("UCase(") = 0 Then Return str
        Return " UCase( " & str & ") "
    End Function
    Function TranslateWord(ByVal word As String) As ErrString
        Dim ret, es As New ErrString(Trim(word)), obStr As ErrString, i, j As Integer
        If ret.str = "" Then Return ret
        ' возможно выражение просто в скобках
        While (word.Chars(0) = "(" And word.Chars(word.Length - 1) = ")") Or (word.Chars(0) = "[" And word.Chars(word.Length - 1) = "]")
            word = Trim(word.Substring(1, word.Length - 2)) : ret.str = word
            If ret.str = "" Then Return ret
        End While

        ' Если это и так строка то вернуть её без изменений
        If (word.Chars(0) = """" And word.Chars(word.Length - 1) = """") Then
            If ret.str.Length > 1 Then
                If isCompilBest Then ret.str = perevesti(getCompilLineLength(ret.str), """ & vbCrLf & """)
                Return ret
            End If
        End If

        ' Если это число, то вернуть его без изменений
        If IsNumeric(word) Then Return ret

        ' Если это объект со свойством или методом
        obStr = isObj(word)
        If obStr.err = "" Then
            Dim args(), prop As String, MyObjs() As Object
            es = GetMyObjWithProps(word, obStr.str, prop, args, MyObjs)
            ' ЕСЛИ ИДЕТ СУПЕР-КОМПИЛЯЦИЯ А НЕ ДЕБАГ
            If isCompilBest Then
                Return GetVBCodeNameObjWithProps(word, obStr.str, prop, args, MyObjs)
            End If
            If es.err <> "" Then Return es
            'Dim old_str As String, isOdinak As Boolean
            ' Пройтись по объектам (в 99% это один объект) и записать результат обращения к свойтву или методу
            For i = 0 To MyObjs.Length - 1
                If args Is Nothing = False Then
                    For j = 0 To args.Length - 1
                        If Iz.isCode(args(j)) Then
                            es = TranslateALL(args(j))
                        Else
                            es = UbratKovich(args(j))
                        End If
                        If es.err <> "" Then Return es Else args(j) = es.str
                    Next
                End If
                es = GetPropertyMethod(MyObjs(i), prop, word, args)
                If es.err <> "" Then Return es
                ' Если объектов несколько то результаты записать через запятую
                'If i > 0 And i < MyObjs.Length - 1 Then es.str = ", " & es.str
                If i = 0 Then ret.str = es.str
                If ret.str <> es.str Then ret.str = "" : Exit For
            Next
            If UbratKovich(ret.str).str = ret.str Then
                If ret.str <> Nothing Then ret.str = CreateKovich(ret.str)
                ret.str = """" & ret.str & """"
            End If
            Return ret
        End If

        ' ЕСЛИ ЭТО ФУНКЦИЯ
        Dim SelFun As Integer = -1
        For i = 0 To DopFunsSimple.Length - 1
            If UCase(word).IndexOf(DopFunsSimple(i)) = 0 Then
                ' Если уже было совпадение функции
                If SelFun <> -1 Then
                    ' если функция с более коротким названием поошибке сейчас выбрана
                    If DopFunsSimple(SelFun).Length > DopFunsSimple(i).Length Then Continue For
                End If
                SelFun = i
            End If
        Next
        ' Если функция найдена
        If SelFun <> -1 Then
            Dim strVal As String, vl As Double
            If isCompilBest Then
                If DopFunsSimple(SelFun).ToUpper = ret.str.ToUpper Then ret.str = trans(ret.str, True).Replace(" ", "")
                Return ret
            End If

            If word.IndexOf("""") <> -1 Then
                strVal = word.Split("""")(1)
            Else
                If word.IndexOf("(") = -1 Then Return ret
                strVal = Trim(word.Split("(")(1).Split(")")(0))
            End If
            ' Все функции кроме Инвертировать требует в аргументе числа
            If DopFunsSimple(SelFun) <> UCase(trans("Инвертировать")) Then
                If Iz.isDouble(strVal) = False Then ret.err = Errors.notDouble(strVal, DopFunsSimple(SelFun)) : Return ret
                vl = ToDouble(strVal)
            End If
            Select Case DopFunsSimple(SelFun)
                Case UCase(trans("Корень"))
                    ret.str = """" & Radical(vl).ToString & """"
                Case UCase(trans("Корень3"))
                    ret.str = """" & Radical3(vl).ToString & """"
                Case UCase(trans("Квадрат"))
                    ret.str = """" & Square(vl).ToString & """"
                Case UCase(trans("Модуль"))
                    ret.str = """" & Absolute(vl).ToString & """"
                Case UCase(trans("Синус"))
                    ret.str = """" & Sine(vl) & """"
                Case UCase(trans("Косинус"))
                    ret.str = """" & Cosine(vl).ToString & """"
                Case UCase(trans("Тангенс"))
                    ret.str = """" & Tangent(vl).ToString & """"
                Case UCase(trans("АркСинус"))
                    ret.str = """" & ArcSine(vl).ToString & """"
                Case UCase(trans("АркКосинус"))
                    ret.str = """" & ArcCosine(vl).ToString & """"
                Case UCase(trans("АркТангенс"))
                    ret.str = """" & ArcTangent(vl).ToString & """"
                Case UCase(trans("Экспонента"))
                    ret.str = """" & Exhibitor(vl).ToString & """"
                Case UCase(trans("Логарифм"))
                    ret.str = """" & Logarithm(vl).ToString & """"
                Case UCase(trans("Логарифм10"))
                    ret.str = """" & Logarithm10(vl).ToString & """"
                Case UCase(trans("Округлить"))
                    ret.str = """" & Round(vl).ToString & """"
                Case UCase(trans("Округлить денежное"))
                    ret.str = """" & RoundMoney(vl).ToString & """"
                Case UCase(trans("Сменить знак"))
                    ret.str = """" & ChangeSign(vl).ToString & """"
                Case UCase(trans("Инвертировать"))
                    If Trim(strVal) = "1" Or UCase(Trim(strVal)) = UCase(Trim(trans("Да"))) Then
                        ret.str = """" & trans("Нет") & """"
                    ElseIf Trim(strVal) = "0" Or UCase(Trim(strVal)) = UCase(Trim(trans("Нет"))) Then
                        ret.str = """" & trans("Да") & """"
                    Else
                        Return New ErrString(Errors.notInvers(strVal))
                    End If
                Case UCase(trans("Случайное число"))
                    ret.str = """" & RandomNumber(vl).ToString & """"
            End Select
            Return ret
        End If

        ' Если это имя объекта, то вернуть его без изменений
        If proj.GetMyObjFromUniqName(word) Is Nothing = False Then Return ret

        ' Если это вспомогательное слово
        If Array.IndexOf(AllHWUp, UCase(word)) <> -1 Then
            Dim val As String = SrazuPerevoditHW(AllHW(Array.IndexOf(AllHWUp, UCase(word))))
            If val Is Nothing Then
                If isCompilBest Then
                    Return New ErrString("""" & AllHW(Array.IndexOf(AllHWUp, UCase(word))) & """")
                Else
                    Return New ErrString("""" & AllHW(Array.IndexOf(AllHWUp, UCase(word))) & """")
                End If
            Else
                Return New ErrString(val)
            End If
        End If

        If isCompilBest Then
            If word.IndexOf(".") = 0 And word.IndexOf(".Props.") <> 0 Then
                Return GetVBCodeNameObjWithProps("", "", word.Substring(1), Nothing, Nothing) ' New ErrString(".Props." & trans(word.Substring(1), True))
            Else
                Return New ErrString(word)
            End If
        End If

        ' Во всех остальных случаях
        Return New ErrString("???", Errors.notUnderstand(word))
    End Function
    ' ПЕРЕВОД ИМЯ ОБЪЕКТА В КОД VB
    Function GetVBCodeNameObjWithProps(ByVal allStr As String, ByVal objStr As String, ByRef prop As String, ByRef args() As String, ByRef MyObjs() As Object) As ErrString
        Dim es As ErrString, objName = "", argstr = "", proptxt As String = "", bylMyZnak As Boolean
        If prop = "" Then
            Dim m As System.Text.RegularExpressions.Match
            m = System.Text.RegularExpressions.Regex.Match(objStr, noSimb & "+\." & noSimb & "+")
            If Trim(m.Value) <> Trim(objStr) Then Return New ErrString(objStr)
            es.str = "RunProj.GetObjFromUniqName(""" & CreateKovich(objStr) & """"
        Else
            If objStr <> "" Then
                objName = objStr.Substring(0, objStr.Length - prop.Length - 1)
                es.str = "RunProj.GetObjFromUniqName(""" & CreateKovich(objName) & """)"
            End If

            ' Запись обычного свойства
            If prop.IndexOf(MyZnak) = 0 Then prop = prop.Substring(1) : bylMyZnak = True
            proptxt = ".Props." & trans(prop, True).Replace(" ", "")
            es.str &= proptxt

            Dim polezStr As String = MyZnak & trans("Полезные объекты") & "."
            Dim polezObjStr As String = MyZnak & trans("Объект события")
            If bylMyZnak And (objName.indexOf(polezStr) <> 0 Or objName.indexOf(polezObjStr) = polezStr.Length) Then
                ' Если это свойство события
                If rp.Param.ParamyUp Is Nothing Then rp.Param = New PropertysSobyt(Nothing, Nothing, Nothing, MyZnak & "All")
                If rp.Param.ParamyUp.IndexOfKey(MyZnak & UCase(prop)) <> -1 Then
                    es.str = "CurrentEvent.ParamyUp(MyZnak & """ & UCase(prop) & """)"
                End If
            End If

            ' Прерывания это отдельная тема
            If UCase(prop) = UCase(trans("Завершить программу")) Then es.str = "End" & vbCrLf
            If UCase(prop) = UCase(trans("Завершить событие")) Then es.str = "Exit sub" & vbCrLf
            If UCase(prop) = UCase(trans("Завершить цикл")) Then es.str = "Exit while" & vbCrLf
            If UCase(prop) = UCase(trans("Пропускать ошибки")) Then es.str = "On Error Resume Next" & vbCrLf & es.str

            ' Некоторые Полезные объекты имеют свое преобразование в VB код
            Dim spl() As String = objName.Split(".")
            If UCase(spl(0)) = MyZnak & UCase(trans("Полезные объекты")) And spl.Length > 1 Then
                '  Вызов события
                If UCase(spl(1)) = MyZnak & UCase(trans("Вызвать событие")) Then
                    Dim ob As Object = proj.GetMyAllFromName(prop.Split("_")(1), , prop.Split("_")(0))
                    If ob IsNot Nothing Then
                        es.str = GetCompilName(ob(0)) & "_" & trans(prop.Split("_")(2), True).Replace(" ", "")
                        es.str &= "(" & GetCompilName(ob(0)) & ", nothing)" & vbCrLf
                    End If
                End If
            End If
            If spl.Length > 1 And bylMyZnak = False Then
                '  Объект события
                If UCase(spl(1)) = MyZnak & UCase(trans("Объект события")) Then
                    es.str = "CurrentEvent.MyObj.obj" & proptxt
                    '  окно события
                ElseIf UCase(spl(1)) = MyZnak & UCase(trans("Окно события")) Then
                    es.str = "CurrentEvent.MyObj.GetMyForm.obj" & proptxt
                ElseIf objName = "CurrentEvent.MyObj" Then
                    Return New ErrString(allStr)
                    '  Хозяин меню
                ElseIf UCase(spl(1)).IndexOf(MyZnak & UCase(trans("Хозяин")) & " ") = 0 Then
                    Dim nam As String = spl(1).Substring((MyZnak & trans("Хозяин") & " ").Length)
                    es.str = "RunProj.GetObjFromUniqName(""" & spl(0) & "." & nam & """).props.OwnerObject"
                    es.str = "RunProj.GetObjFromUniqName(""" & spl(0) & "."" & " & es.str & ")" & proptxt
                End If
            End If


            ' записываем аргументы
            If args IsNot Nothing Then
                Dim i As Integer
                For i = 0 To args.Length - 1
                    args(i) = TranslateKuso4ek(args(i)).str
                Next
                es.str &= "(" & Join(args, ", ") & ")"
            End If
        End If
        Return es
    End Function
    ' ПЕРЕВОД ТЕКСТА В ОБЪЕКТ СО СВОЙСТВАМИ И МЕТОДАМИ
    Function GetMyObjWithProps(ByVal allStr As String, ByVal objStr As String, ByRef prop As String, ByRef args() As String, ByRef MyObjs() As Object) As ErrString
        ' Извлечь свойство или метод
        prop = objStr.Substring(objStr.LastIndexOf(".") + 1)
        ' Извлечь аргументы, если они есть
        If objStr.Length = allStr.Length Then
            args = Nothing
        ElseIf allStr.IndexOf("(", objStr.Length - 1) = objStr.Length Then
            args = New CodeString(allStr.Substring(objStr.Length - 1), , False).Split("naVtoromUrovne").texty
        Else
            Return New ErrString(allStr, Errors.InvalidPropObj)
        End If
        ' Получить объект
        MyObjs = GetMyObjFromUniqName(objStr)
        If MyObjs Is Nothing Then Return New ErrString(allStr, Errors.ObjIsNothing)
    End Function
    Function isObj(ByVal str As String) As ErrString
        Dim m As System.Text.RegularExpressions.Match
        m = System.Text.RegularExpressions.Regex.Match(str, noSimb & "+\." & noSimb & "+(\[.*\])?\." & noSimb & "+")
        If m.Success And m.Index = 0 Then Return New ErrString(m.Value)
        'If isCompilBest Then
        '    m = System.Text.RegularExpressions.Regex.Match(str, noSimb & "+\." & noSimb & "+")
        '    If Trim(m.Value) = Trim(str) Then Return New ErrString(m.Value)
        'End If
        Return New ErrString(str, Errors.ObjIsNothing)
    End Function
    'Function TranslateToDouble(ByVal word As String) As ErrString
    '    If word = "" Or word = """""" Then word = 0
    '    Dim ret As ErrString = UbratKovich(word)
    '    If ret.err <> "" Then Return ret
    '    Dim m As System.Text.RegularExpressions.Match
    '    m = System.Text.RegularExpressions.Regex.Match(ret.str, "(\-|\+)?[0-9]{0,300}(\.([0-9]){0,15})?")
    '    If m.Value <> ret.str Then Return New ErrString(ret.str, """" & word & """ - " & trans("это не число"))
    '    Return ret
    'End Function
    Function TranslateToDouble(ByVal word As String) As ErrString
        If word = "" Or word = """""" Then word = 0
        If UCase(word) = UCase(trans("Да")) Then word = 1
        If UCase(word) = UCase(trans("Нет")) Then word = 0
        ' возможно выражение просто в скобках
        While (word.Chars(0) = "(" And word.Chars(word.Length - 1) = ")") Or (word.Chars(0) = "[" And word.Chars(word.Length - 1) = "]")
            word = word.Substring(1, word.Length - 2)
        End While
        Dim ret As ErrString = UbratKovich(word)
        If ret.err <> "" Then Return ret
        Dim m As System.Text.RegularExpressions.Match
        If Iz.isDouble(ret.str) = False Then Return New ErrString(ret.str, """" & word & """ - " & trans("это не число"))
        Return ret
    End Function
#End Region

End Class





