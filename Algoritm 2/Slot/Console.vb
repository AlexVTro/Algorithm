Public Module Console
    Sub Run(ByVal str As String, Optional ByVal revers As Boolean = False)
        Dim i, j, k, t As Integer
        Dim rtb As New RichTextBox() : rtb.Text = str
        Dim s() As String = rtb.Lines
        ochered = ""

        Dim SelNodes() As TreeNode = Nothing, SelObjs() As Object = Nothing
        If revers = True Then i = s.Length + 3
        Do
            If revers = True Then i -= 4
            Do
                If i >= s.Length Or i < 0 Then GoTo ExitDo
                If s(i) = "#New" Then Exit Do
                If revers = False Then i += 1 Else i -= 1
            Loop : j = i + 1 : t = 1
            Do
                If j >= s.Length Then Exit Do
                If s(j) = "#New" Then Exit Do
                If s(j) = "#Union Undos(Redos)" Then t += 1
                j += 1
            Loop
            i += 1 : j -= t

            Dim capt As String = s(i) : i += 1
            Dim deist As String = s(i).Split(":")(0)
            Dim tip As String = s(i).Split(":")(1) : i += 1

            isConsole = True ' глобальная переменная, обозначает что все действия делает консоль (в основном нужно чтобы имена не подбирались новые)
            If tip = "элемент дерева" Then
                If deist = "Создать" Then
                    ' Вставить узлы
                    Dim toSel() As TreeNode = MainForm.PasteTree(Nothing, getStrFromArray(s, i, j))
                    ' Выделить только что вставленное
                    If toSel Is Nothing = False Then
                        'MainForm.ReSortMyObjs(toSel(0))
                        For k = 0 To toSel.Length - 1
                            ReDims(SelNodes) : SelNodes(SelNodes.Length - 1) = toSel(k)
                        Next
                    End If
                ElseIf deist = "Удалить" Then
                    ' ОПРЕДЕЛЕНИЕ МЕСТА (ПРИ ПОМОЩИ #Parent) ОТКУДА УДАЛЯТЬ
                    Dim strs() As String, toDel() As Object = Nothing
                    ' Создание массива строк
                    rtb.Text = getStrFromArray(s, i, j) : strs = rtb.Lines
                    ' Проход по каждой строке
                    For k = 0 To strs.Length - 1
                        If strs(k) = "" Then Continue For
                        If strs(k) <> "#Parent" Then Continue For

                        Dim isObj As Boolean, isOb As String = ""
                        'If strs(k + 1).Split("\").Length = 2 Then isOb = proj.isObject(strs(k + 1).Split("/")(1))
                        isOb = proj.isObject(strs(k + 1))
                        If isOb = "" Then isObj = False Else isObj = True

                        ReDims(toDel) : toDel(toDel.Length - 1) = proj.GetNodeFromName(strs(k + 1), , isObj)
                        If toDel(toDel.Length - 1) Is Nothing = False Then
                            If toDel(toDel.Length - 1).Nodes.Count > Convert.ToInt16(strs(k + 3)) Then
                                toDel(toDel.Length - 1) = toDel(toDel.Length - 1).Nodes(Convert.ToInt16(strs(k + 3)))
                            Else
                                DelDims(toDel, toDel.Length - 1)
                            End If
                        Else
                            DelDims(toDel, toDel.Length - 1)
                        End If
                    Next
                    ' СОБСТВЕНО УДАЛЕНИЕ УЗЛОВ
                    If toDel Is Nothing = False Then MainForm.DeleteTree(True, toDel)
                End If
            ElseIf tip = "объект" Then
                If deist = "Создать" Then
                    Dim objStr As String = getStrFromArray(s, i, j)
                    Dim cont As String = GetNuzhPunkt("#Conteiner", objStr)
                    Dim contener As Object = proj.GetMyObjFromUniqName(cont)
                    ' Вставить объект
                    Dim toSel() As Object = MainForm.PasteObj(objStr, contener)
                    ' Выделить только что вставленное
                    If toSel Is Nothing = False Then
                        For k = 0 To toSel.Length - 1
                            If ReExist(SelObjs, toSel(k)) = False Then ReDims(SelObjs) : SelObjs(SelObjs.Length - 1) = toSel(k)
                        Next
                    End If
                ElseIf deist = "Удалить" Then
                    Dim objStr As String = getStrFromArray(s, i, j)
                    While GetNuzhPunkt(trans("Имя"), objStr) <> ""
                        Dim name As String = GetNuzhPunkt(trans("Имя"), objStr)
                        Dim index As String = GetNuzhPunkt(trans("Номер"), objStr)
                        Dim cont As String = GetNuzhPunkt("#Conteiner", objStr)
                        Dim contener As Object = proj.GetMyObjFromUniqName(cont)
                        Dim forma As Object = Nothing
                        If contener Is Nothing = False Then forma = contener.GetMyForm()
                        Dim formaName As String = ""
                        If forma Is Nothing = False Then formaName = forma.obj.Props.name() : MainForm.TabControl1.SelectedTab = forma.tab
                        If forma Is Nothing = False Or cont = "" Then
                            MainForm.DeleteObj(proj.GetMyAllFromName(name, index, formaName))
                        End If
                        ' Есть ли еще объекы
                        Dim ind As Integer = objStr.IndexOf(vbCrLf & "#End" & vbCrLf)
                        If ind = -1 Then Exit While
                        objStr = objStr.Substring(ind + (vbCrLf & "#End" & vbCrLf).Length)
                    End While

                    'End If
                End If
            ElseIf deist = "На задний план" Or deist = "На передний план" Then
                ' Получить объект
                Dim MyObj As Object = proj.GetMyObjFromUniqName(tip) : If MyObj Is Nothing Then Continue Do
                ' Получить форму объекта
                Dim forma As Forms = MyObj.GetMyForm : If forma Is Nothing Then Continue Do
                ' собственно выполнить задание
                forma.HistoryLevelRun(getStrFromArray(s, i, j), MyObj)
            ElseIf deist = "Переместить объект" Then
                ' Получить объект
                Dim MyObj As Object = proj.GetMyObjFromUniqName(tip) : If MyObj Is Nothing Then Continue Do
                ' Получить контенер объекта
                Dim kuda As Object = proj.GetMyObjFromUniqName(getStrFromArray(s, i, j))
                If kuda Is Nothing Then isConsole = False : Exit Sub
                ' собственно выполнить задание
                MainForm.MoveObj(kuda, MyObj)
            ElseIf deist = "Изменение свойства" Then
                ' Получить объект
                Dim MyObj As Object = proj.GetMyObjFromUniqName(tip) : If MyObj Is Nothing Then Continue Do
                ' Получить наименование свойства
                Dim prop As Object = tip.Split(".")(2) : If prop Is Nothing Then Continue Do
                ' Получить значение свойства
                Dim value As String = getStrFromArray(s, i, j)
                value = value.Split(vbCrLf)(0)
                ' собственно выполнить задание
                SetProperty(MyObj, prop, value)
                ' Выделить только что меняет свойства
                If ReExist(SelObjs, MyObj) = False Then ReDims(SelObjs) : SelObjs(SelObjs.Length - 1) = MyObj
            ElseIf deist = "Изменение текста узла" Then
                Dim node As TreeNode = proj.GetNodeFromName(tip)
                If node Is Nothing = False Then
                    node.Text = getStrFromArray(s, i, j).Trim()
                End If
            End If
        Loop
ExitDo:
        MainForm.SelNodes = SelNodes
        If MainForm.SelNodes Is Nothing = False Then MainForm.SelNode = MainForm.SelNodes(0) : Tree.SelectedNode = MainForm.SelNode
        MainForm.TreePaint(ColKode)
        If SelObjs Is Nothing = False Then
            If SelObjs(0).GetMyForm Is Nothing = False Then
                SelObjs(0).GetMyForm.ClearActiveObject()
                SelObjs(0).GetMyForm.SelectTab()
                SelObjs(0).GetMyForm.ActiveObj = SelObjs
                SelObjs(0).GetMyForm.marker_vis()
                SelObjs(0).GetMyForm.FillListView()
                SelObjs(0).obj.refresh()
            End If
            ProgressForm.Hide()
            proj.ActiveForm.marker_vis()
        End If

        ' Переименовывает объекты в действиях, после завершения ундо-реда
        OtlozhenieReNames()

        isConsole = False
    End Sub

    ' Переименовывает объекты в действиях, после завершения ундо-реда
    Public ochered As String = ""
    Sub OtlozhenieReNames()
        Dim i As Integer
        If ochered = "" Then Exit Sub
        Dim iters() As String = ochered.Split("&")
        For i = 0 To iters.Length - 2
            transTree(Nothing, New reName(iters(i).Split(".")(0), iters(i).Split(".")(1), iters(i).Split(".")(2), iters(i).Split(".")(3)))
        Next
        ochered = ""
    End Sub
End Module
