Public Module Perevodi

    Public Function ToStrFromObj(ByVal MyObj As Object, Optional ByVal withParentTree As Boolean = False, Optional ByVal toEng As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal withProgres As Boolean = True, Optional ByRef ObjsTres As ObjsTreesText = Nothing) As String
        Dim myobjs() As Object : ReDims(myobjs) : myobjs(0) = MyObj
        Return ToStrFromObj(myobjs, withParentTree, toEng, isRun, withProgres, ObjsTres)
    End Function
    Public Function ToStrFromObj(ByVal MyObj() As Object, Optional ByVal withParentTree As Boolean = False, Optional ByVal toEng As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal withProgres As Boolean = True, Optional ByRef ObjsTres As ObjsTreesText = Nothing) As String
        Dim str As String = "", allstr As String = "", i, j As Integer, MyObjs() As Object
        ' Записать все объекты которые надо скопировать в один массив MyObjs
        MyObjs = proj.GetDo4ernieMyObjs(MyObj)
        If MyObj Is Nothing Then Return Nothing
        ' если это форма и ее пытаются сохранить в файле, то с ней надо сохранять все её объекты, включая полуобъекты
        If toEng Or isRun And MyObj.Length = 1 Then
            If Iz.IsFORM(MyObj(0)) Then MyObjs = MyObj(0).MyObjs
        End If
        MyObjs = proj.GetSortMyObjsByLevelConteiner(MyObjs)
        ' Теперь перевести каждый объект в текст
        For i = 0 To MyObjs.Length - 1
            ' Прогресс-форма
            If withProgres Then ProgressForm.ProgressBarValue = (100 / (MyObjs.Length)) * i

            ' Если редактируют код
            If ObjsTres IsNot Nothing Then
                Dim fnd As Integer = Array.IndexOf(ObjsTres.Objs, MyObjs(i))
                If fnd <> -1 Then
                    If allstr.Length > 0 Then ObjsTres.Starts(fnd) = ObjsTres.popravka + allstr.Length - 1 Else ObjsTres.Starts(fnd) = ObjsTres.popravka
                End If
            End If

            ' Задание типа объекта
            Dim tip As String = MyObjs(i).obj.GetType.ToString.Substring(ClassAplication.Length)
            str = tip & vbCrLf
            ' Сохранение всех свойств
            IzmenenieBylo2(MyObjs(i))
            Dim prop As ErrString
            For j = 0 To MyObjs(i).Propertys.Length - 1
                If Array.IndexOf(ReadOnlyProps, MyObjs(i).PropertysUp(j)) <> -1 Then Continue For
                prop = GetProperty(MyObjs(i), MyObjs(i).Propertys(j))
                ' если это не свойство по умолчанию и свойство без ошибки
                'If ((isRun = False Or prop.str <> GetProperty(Pustishki(tip), MyObjs(i).Propertys(j)).str _
                'Or Iz.IsFORM(MyObjs(i))) And prop.err = "" And Array.IndexOf(NoSaveProps, UCase(MyObjs(i).Propertys(j))) = -1) _
                'Or MyObjs(i).Propertys(j).toUpper = trans("Имя").ToUpper _
                'Or MyObjs(i).Propertys(j).toUpper = trans("Текст").ToUpper Then

                If prop.err = "" And Array.IndexOf(NoSaveProps, UCase(MyObjs(i).Propertys(j))) = -1 Then
                    str &= MyObjs(i).Propertys(j) & vbCrLf
                    prop.str = perevesti(prop.str, False)
                    str &= prop.str & vbCrLf
                End If
            Next
            ' Сохранение контенера (для некоторых случаев)
            str &= "#Conteiner" & vbCrLf
            If MyObjs(i).conteiner Is Nothing = False Then
                If MyObjs(i).obj.typeObj <> "PoluObj" Then
                    str &= GetUNameObj(MyObjs(i).conteiner, MyObjs(i))
                Else
                    str &= GetUNameObj(MyObjs(i).GetMyForm)
                End If
            End If
            str &= vbCrLf
            ' Сохранение хистори левела, если надо
            'If  fromEng = False Then
            Dim ind As Integer = MyObjs(i).GetMyForm.HistoryLevel.IndexOf(MyObjs(i))
            If ind <> -1 Then str &= "#HistoryLevel" & vbCrLf & ind & vbCrLf
            'End If
            ' Сохранение узла
            Dim nodes(0) As TreeNode
            nodes(0) = MyObjs(i).GetNode(, True)
            '  If Iz.IsFORM(MyObjs(i)) Then
            ' For j = 0 To nodes(0).Parent.Nodes.Count - 1
            ' If nodes(0).Parent.Nodes(j).Tag = "Comm" Then ReDims(nodes) : nodes(nodes.Length - 1) = nodes(0).Parent.Nodes(j)
            ' Next
            'End If
            str &= "#TreeNode" & vbCrLf

            'If ObjsTres IsNot Nothing Then ObjsTres.popravka += str.Length

            str &= MainForm.GetCopyTree(nodes, withParentTree, toEng, ObjsTres)
            ' Dim node As New TreeNode()
            ' node.Nodes.Add(proj.CloneTreeNode(MyObjs(i).GetNode(, True)))
            ' str &= ToStrFromTree(node) & vbCrLf

            ' Конец объекта
            str &= "#End" & vbCrLf & vbCrLf
            allstr &= str
            ' Если редактируют код
            If ObjsTres IsNot Nothing Then
                Dim fnd As Integer = Array.IndexOf(ObjsTres.Objs, MyObjs(i))
                If fnd <> -1 Then ObjsTres.Lengs(fnd) = ObjsTres.popravka + allstr.Length - ObjsTres.Starts(fnd)
            End If
        Next
        Return allstr
    End Function

    Public Function ToObjFromStr(ByVal str As String, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False, Optional ByRef ByRefProjParams As String = "") As Object
        Dim MyObjs() As Object = Nothing
        Dim i = 0, j As Integer
        Dim txt As New RichTextBox
        Dim lines(), conts(), txtNode As String
        If str = "" Then Return Nothing
        txt.Text = str : lines = txt.Lines
        While i < lines.Length - 1
            ' Прогресс-форма
            ' если идет разработка проекта а не запуск готовой программы
            If ProgressForm.InvokeRequired Then
                ' Если это поток то надо через потоконезависимую Invoke выполнять
                ProgressForm.Invoke(delegatProgress, New Object() {Int((100 / (lines.Length)) * i)})
            Else
                ProgressForm.ProgressBarValue = (100 / (lines.Length)) * i
            End If
            ' End If
            If lines(i) = "" Or lines(i).IndexOf("#") = 0 Then i += 1 : Continue While
            ' определение типа объекта
            ReDims(MyObjs)
            CreateNewMyObjs(lines(i), MyObjs, isRun, fromEng)
            'If MyObjs(MyObjs.Length - 1) Is Nothing Then DelDims(MyObjs, MyObjs.Length - 1) : Exit While
            If isRun Then
                If RunProj Is Nothing Then Exit Function
                MyObjs(MyObjs.Length - 1).proj = RunProj
                MyObjs(MyObjs.Length - 1).tree = RunProj.tree
            End If
            ' Воссановление всех сохраненных свойств
            i += 1
            Dim res As MsgBoxResult
            Dim estVis As Boolean = False, vis As String = ""
            Dim estMxH As Boolean = False, mxh As String = ""
            Dim estMxW As Boolean = False, mxw As String = ""
            Dim estSel As Boolean = False, sel As String = ""
            Dim estRtf As Boolean = False, rtf As String = ""
            Dim estVal As Boolean = False, val As String = ""
            Dim estSpD As Boolean = False, spd As String = ""
            Dim estAsE As Boolean = False, ase As String = ""
            Dim estAlS As Boolean = False, als As String = ""
            Dim estWC As Boolean = False, wco As String = ""
            Dim estHR As Boolean = False, hro As String = ""



            While lines(i).IndexOf("#") <> 0
                If i + 1 >= lines.Length - 1 Then Exit While
                If lines(i) = "" Then i += 1 : Continue While
                ' присвоение свойства
                ' Видимость и т.д. присваиваем в самом конце
                If UCase(lines(i)) = UCase(trans("Видимый")) Then estVis = True : vis = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("Вышина")) Then estMxH = True : mxh = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("Ширина")) Then estMxW = True : mxw = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("Выделенная запись")) Then estSel = True : sel = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("RTF код документа")) Then estRtf = True : rtf = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("Значение")) Then estVal = True : val = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("Расстояние разделителя")) Then estSpD = True : spd = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("Ширина столбцов")) Then estWC = True : wco = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("Вышина строк")) Then estHR = True : hro = lines(i + 1) : i += 2 : Continue While
                If UCase(lines(i)) = UCase(trans("Статус окна")) Then
                    If isRun Then MyObjs(MyObjs.Length - 1).obj.StatusTemp = lines(i + 1) : i += 2 : Continue While
                End If
                If UCase(lines(i)) = UCase(trans("Ассоциировать с расширениями")) Then estAsE = True : ase = lines(i + 1) : i += 2 : Continue While
                ' перевести все ключевые слова которые надо автоматом переводить в значения
                If isRun Then
                    If SrazuPerevoditHW(lines(i + 1)) <> Nothing Then lines(i + 1) = UbratKovich(SrazuPerevoditHW(lines(i + 1))).str
                End If
                ' имя свойства переводится с английского на местный язык
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(lines(i), , True), lines(i + 1), fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
                i += 2
            End While

            ' Видимость и т.д. присваиваем самым последним свойством
            If estRtf Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("RTF код документа"), , True), rtf, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            If estMxH Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Вышина"), , True), mxh, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If
            If estMxW Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Ширина"), , True), mxw, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            If estVis Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Видимый"), , True), vis, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            If estMxH Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Вышина"), , True), mxh, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If
            If estMxW Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Ширина"), , True), mxw, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            If estSpD Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Расстояние разделителя"), , True), spd, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If


            If estSel Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Выделенная запись"), , True), sel, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            If estVal Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Значение"), , True), val, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            If estWC Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Ширина столбцов"), , True), wco, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            If estHR Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Вышина строк"), , True), hro, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            If estAsE Then
                res = SetProperty(MyObjs(MyObjs.Length - 1), trans(trans("Ассоциировать с расширениями"), , True), ase, fromEng)
                If res = MsgBoxResult.Cancel Then Return Nothing
            End If

            ' Чтобы "Номера выделенных строк" действительно выделились в таблице
            If Iz.IsTl(MyObjs(MyObjs.Length - 1)) Then
                MyObjs(MyObjs.Length - 1).obj.Props.SelectedColumns = MyObjs(MyObjs.Length - 1).obj.Props.selCol
            End If


            ' У инклудобъектов имя должно отражать имя своего контенера
            'If MyObjs(MyObjs.Length - 1).obj.TypeObj = "IncludeObj" Then
            ' MyObjs(MyObjs.Length - 1).obj.defaultName = MyObjs(MyObjs.Length - 1).obj.name
            ' End If
            ' Определение контейнера
            If lines(i) = "#Conteiner" Then
                ReDims(conts) : conts(conts.Length - 1) = lines(i + 1) : i += 2
                MyObjs(MyObjs.Length - 1).OldFormTemp = conts(conts.Length - 1).Split(".")(0)
                If isOpening Then MyObjs(MyObjs.Length - 1).conteiner = Nothing
                ' полуобъекты уже кинуты на свою сплитерпанель
                ' If MyObjs(MyObjs.Length - 1).obj.typeObj = "PoluObj" And isRun = False Then conts(conts.Length - 1) = ""
            End If
            ' Определение хистори левела
            If lines(i) = "#HistoryLevel" Then
                i += 1
                MyObjs(MyObjs.Length - 1).HistoryTemp = lines(i)
                i += 1
            End If
            ' Загрузка узла
            txtNode = ""
            If lines(i) = "#TreeNode" Then
                i += 1
                While lines(i) <> "#End"
                    txtNode &= lines(i) & vbCrLf : i += 1
                End While
                If txtNode <> "" Then
                    MyObjs(MyObjs.Length - 1).NodeTemp = ToTreeFromStr(txtNode, fromEng).Nodes(0)
                    MyObjs(MyObjs.Length - 1).ParentTemp = GetNuzhPunkt("#Parent", txtNode)
                    MyObjs(MyObjs.Length - 1).IndexTemp = GetNuzhPunkt("#Index", txtNode)
                End If
                i += 1
            End If
            i += 1
            If i >= lines.Length - 1 Then Exit While
            If lines(i) = "#ProjectParams" Then
                i += 1
                While lines(i) <> "#EndProjectParams"
                    ByRefProjParams &= lines(i) & vbCrLf : i += 1
                End While
                i += 1
            End If
            ' Указать что объект куда-то вствляется
            'MyObjs(MyObjs.Length - 1).VstavkaOrCreate = True


        End While
        ' Если среди объектов есть те на которых надо разместить другие копируемые объекты
        MyObjs = GetSortTPsByPosition(MyObjs) ' сортировка чтобы вкладки были в строгой последовательности
        '       If proj.ActiveForm Is Nothing Then
        '       If Iz.IsFORM(MyObjs(0)) Then proj.ActiveForm = MyObjs(0) Else Exit Function
        '       End If
        If conts Is Nothing Then Return MyObjs
        For i = 0 To conts.Length - 1
            For j = 0 To MyObjs.Length - 1


                ' Если среди объектов есть контенер-панель, причем совпадает даже имена родительских форм (происходит при копировании в одной форме и вставке в другой)
                If Iz.isPanel(MyObjs(j).obj) And GetUNameObj(MyObjs(j)) = GetCorrectUName(conts(i)) Then

                    If MyObjs(j).obj.GetType.ToString = ClassAplication & "DP" Then
                        If conts(i).IndexOf("(") <> -1 Then
                            If conts(i).Split("(")(1).Split(")")(0) = "Panel1" Then
                                MyObjs(j).obj.Panel1.controls.add(MyObjs(i).obj) ' Добавить объект
                                If fromEng Then MyObjs(j).obj.Panel1.controls.add(MyObjs(i).HideMarker) ' Добавить скрытыймаркер
                            Else
                                MyObjs(j).obj.Panel2.controls.add(MyObjs(i).obj) ' Добавить объект
                                If fromEng Then MyObjs(j).obj.Panel2.controls.add(MyObjs(i).HideMarker) ' Добавить скрытыймаркер
                            End If
                        End If
                    ElseIf Iz.isPoluObj(MyObjs(i).obj) = False Then
                        ' Добавить объект
                        Try
                            MyObjs(j).obj.controls.add(MyObjs(i).obj)
                        Catch ex As Exception
                            Errors.MessangeCritic(ex.Message) : Continue For
                        End Try
                        If fromEng Then MyObjs(j).obj.controls.add(MyObjs(i).HideMarker) ' Добавить скрытыймаркер
                    End If
                    If MyObjs(i).conteiner Is Nothing Then MyObjs(i).conteiner = MyObjs(j)
                    If fromEng Then MyObjs(i).HideMarker.SendToBack()
                    Exit For


                    ' Если среди объектов есть контенер-составнойобъект, причем совпадает даже имена родительских форм (происходит при копировании в одной форме и вставке в другой)
                ElseIf Iz.isSostObj(MyObjs(j).obj) And GetUNameObj(MyObjs(j)) = GetCorrectUName(conts(i)) Then

                    If MyObjs(j).obj.GetType.ToString = ClassAplication & "TP" Then
                        MyObjs(j).addTabPage(MyObjs(i), , True)

                    ElseIf MyObjs(j).obj.GetType.ToString = ClassAplication & "MM" _
                    Or MyObjs(j).obj.GetType.ToString = ClassAplication & "MMs" _
                    Or MyObjs(j).obj.GetType.ToString = ClassAplication & "CM" _
                    Or MyObjs(j).obj.GetType.ToString = ClassAplication & "TPl" Then
                        MyObjs(j).addMMenuItem(MyObjs(i))
                    End If

                    MyObjs(i).conteiner = MyObjs(j)
                    Exit For


                    ' Если среди объектов есть контенер и совпадают только имена объектов (происходит при копировании и вставке в одной форме)
                ElseIf MyObjs(j).obj.Props.name = GetObjNameFromUName(conts(i)) And MyObjs(j).obj.Props.index = GetIndexFromUName(conts(i)) And (GetUNameObj(MyObjs(j)) = GetCorrectUName(conts(i)) Or isRun = False) Then 'And proj.isSostObj(MyObjs(j).obj) Then

                    ' Чтобы при открытии (в отличии от вставки), нельзя было вставлять элементы в объект, только
                    ' проверив его имя, не считаясь с окном, в котором он расположен!
                    Dim FormiRavni As Boolean = True
                    If MyObjs(j).getmyform IsNot Nothing Then
                        If MyObjs(j).getmyform.obj.name <> conts(i).Split(".")(0) Then FormiRavni = False
                    End If
                    If isOpening = False Or (isOpening And FormiRavni) Then

                        If MyObjs(j).obj.GetType.ToString = ClassAplication & "TP" _
                                            Or MyObjs(j).obj.GetType.ToString = ClassAplication & "runTP" Then
                            MyObjs(j).addTabPage(MyObjs(i), , True)

                        ElseIf MyObjs(j).obj.GetType.ToString = ClassAplication & "MM" _
                        Or MyObjs(j).obj.GetType.ToString = ClassAplication & "runMM" _
                        Or MyObjs(j).obj.GetType.ToString = ClassAplication & "CM" _
                        Or MyObjs(j).obj.GetType.ToString = ClassAplication & "runCM" _
                        Or MyObjs(j).obj.GetType.ToString = ClassAplication & "MMs" _
                        Or MyObjs(j).obj.GetType.ToString = ClassAplication & "runMMs" _
                        Or MyObjs(j).obj.GetType.ToString = ClassAplication & "TPl" _
                        Or MyObjs(j).obj.GetType.ToString = ClassAplication & "runTPl" Then
                            MyObjs(j).addMMenuItem(MyObjs(i))

                        ElseIf MyObjs(j).obj.GetType.ToString = ClassAplication & "DP" _
                        Or MyObjs(j).obj.GetType.ToString = ClassAplication & "runDP" _
                        Then
                            If conts(i).Split("(")(1).Split(")")(0) = "Panel1" Then
                                MyObjs(j).obj.Panel1.controls.add(MyObjs(i).obj)
                                If fromEng Then MyObjs(j).obj.Panel1.controls.add(MyObjs(i).HideMarker) ' Добавить скрытыймаркер
                            Else
                                MyObjs(j).obj.Panel2.controls.add(MyObjs(i).obj)
                                If fromEng Then MyObjs(j).obj.Panel2.controls.add(MyObjs(i).HideMarker) ' Добавить скрытыймаркер
                            End If
                        ElseIf Iz.isPoluObj(MyObjs(i).obj) = False Then
                            If Iz.isPanel(MyObjs(j).obj) = False Or isOpening Then Continue For
                            MyObjs(j).obj.controls.add(MyObjs(i).obj)
                            If fromEng Then MyObjs(j).obj.controls.add(MyObjs(i).HideMarker) ' Добавить скрытыймаркер
                        End If

                        MyObjs(i).conteiner = MyObjs(j) : If fromEng Then MyObjs(i).HideMarker.SendToBack()
                        Continue For
                    End If

                End If
            Next
        Next
        Return MyObjs
    End Function

    Public Function ToStrFromTree(ByVal node As TreeNode, Optional ByVal toEng As Boolean = False, Optional ByRef ObjsTres As ObjsTreesText = Nothing) As String
        Dim i, j, k As Integer, str = "", otst = "", txt As String = ""
        If node Is Nothing Then Return Nothing
        For i = 0 To node.Nodes.Count - 1
            For j = 0 To node.Level - 1 : otst = " " & otst : Next

            ' Если редактируют код
            'If ObjsTres IsNot Nothing Then
            '    For k = 0 To ObjsTres.Objs.Length - 1
            '        If ObjsTres.Objs(k).name = node.Nodes(i).Name Then
            '            ObjsTres.Starts(k) = ObjsTres.popravka
            '        End If
            '    Next
            'End If

            ' Если сохраняют проект, то перевести все на англ
            'If toEng Then str = otst & transNode(node.Nodes(i)) Else 
            str = otst & node.Nodes(i).Text
            str &= vbCrLf & otst & node.Nodes(i).Name & vbCrLf & otst & node.Nodes(i).ImageKey & _
                    vbCrLf & otst & node.Nodes(i).SelectedImageKey & vbCrLf & otst & node.Nodes(i).Tag
            txt &= str & vbCrLf
            otst = ""

            'If ObjsTres IsNot Nothing Then ObjsTres.popravka += str.Length

            If node.Nodes(i).Nodes.Count > 0 Then txt &= ToStrFromTree(node.Nodes(i), toEng, ObjsTres)

            ' Если редактируют код
            'If ObjsTres IsNot Nothing Then
            '    For k = 0 To ObjsTres.Objs.Length - 1
            '        If ObjsTres.Objs(k).name = node.Nodes(i).Name Then
            '            ObjsTres.Lengs(k) = str.Length
            '        End If
            '    Next
            'End If

        Next
        Return txt
    End Function
    Public Function ToStrFromTreeOneNode(ByVal node As TreeNode, Optional ByVal toEng As Boolean = False) As String
        Dim str = "", otst = "", txt As String = ""
        If node Is Nothing Then Return Nothing
        ' Если сохраняют проект, то перевести все на англ
        'If toEng Then str = otst & transNode(node) Else 
        str = otst & node.Text
        str &= vbCrLf & otst & node.Name & vbCrLf & otst & node.ImageKey & _
                vbCrLf & otst & node.SelectedImageKey & vbCrLf & otst & node.Tag
        txt &= str & vbCrLf
        otst = ""

        Return txt
    End Function

    Public Function ToTreeFromStr(ByVal txt As String, Optional ByVal fromEng As Boolean = False) As TreeNode
        Dim i, lev As Integer
        Dim TreeNodes As New TreeNode, node As TreeNode
        Dim strs() As String = Nothing
        If txt = Nothing Then Return Nothing
        ' Создание массива строк
        Dim rtb As New RichTextBox : rtb.Text = txt : strs = rtb.Lines
        ' Проход по каждой строке
        For i = 0 To strs.Length - 2
            ' найти куда добавлять узел
            If strs(i) = "" Or strs(i).IndexOf("#") = 0 Then i += 1 : Continue For
            node = TreeNodes
            While strs(i)(lev) = " "
                lev += 1
                If node.Nodes.Count > 0 Then node = node.Nodes(node.Nodes.Count - 1)
                If lev >= strs(i).Length Then Exit While
            End While
            ' добавить узел
            node.Nodes.Add(Trim(strs(i + 1)), Trim(strs(i)), Trim(strs(i + 2)), Trim(strs(i + 2)))
            node.Nodes(node.Nodes.Count - 1).Tag = Trim(strs(i + 4))
            ' Если загружают из файла, то перевести с английского, на котором все сохраняется
            ' If fromEng Then node.Nodes(node.Nodes.Count - 1).Text = transNodeFromEng(node.Nodes(node.Nodes.Count - 1))
            i += 4 : lev = 0
        Next
        Return TreeNodes
    End Function

    Public Function ToTreeFromAlgCode(ByRef parent As TreeNode, ByVal s() As String, ByVal ind As Integer) As Integer
        Dim i As Integer, fromRecur As Boolean = False
        For i = ind To s.Length - 1
            Dim addT As New TreeNode(s(i)) : addT.Name = GetUIN()
            If UCase(Trim(s(i))).IndexOf(UCase(trans("ЕСЛИ"))) = 0 Then 'And UCase(Trim(s(i))).LastIndexOf(UCase(trans("ТОГДА"))) = s(i).Length - trans("ТОГДА").Length Then
                addT.Tag = "If"
            ElseIf UCase(Trim(s(i))).IndexOf(UCase(trans("ИЛИЕСЛИ"))) = 0 Then
                addT.Tag = "ElseIf" : If fromRecur = False Then Return i - 1
            ElseIf UCase(Trim(s(i))).IndexOf(UCase(trans("В остальных случаях"))) = 0 Then
                addT.Tag = "Else" : If fromRecur = False Then Return i - 1
            ElseIf UCase(Trim(s(i))).IndexOf(UCase(trans("Конец условия"))) = 0 Then
                addT.Tag = "EndIf" : If fromRecur = False Then Return i - 1
            ElseIf UCase(Trim(s(i))).IndexOf(UCase(trans("ПОВТОРЯТЬСЯ ПОКА"))) = 0 Then
                addT.Tag = "While"
            ElseIf UCase(Trim(s(i))).IndexOf(UCase(trans("Конец цикла"))) = 0 Then
                addT.Tag = "EndWhile" : If fromRecur = False Then Return i - 1
            ElseIf Trim(s(i)).IndexOf("#") = 0 Or Trim(s(i)) = "" Then
                Continue For
            Else
                addT.Tag = "Deist"
            End If
            fromRecur = False
            parent.Nodes.Add(addT)
            If Iz.IsContenerTree(addT) Then i = ToTreeFromAlgCode(addT, s, i + 1) : fromRecur = True
        Next
        Return ind
    End Function
    ' ГЕНЕРАЦИЯ VB КОДА ИЗ ОБЪЕКТОВ
    Public rp As RunProject
    Public Function ToStrCodeFromObj(ByVal MyObj() As Object, Optional ByVal withParentTree As Boolean = False, Optional ByVal toEng As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal withProgres As Boolean = True) As String
        Dim declar, initial, added, histors, fill, loads, creates, nadoevents, events, str, prevFrm As String
        Dim i, j As Integer, MyObjs() As Object
        ' создаем новый ран проект
        rp = New RunProject("")
        rp.Param = New PropertysSobyt(Nothing, Nothing, Nothing, MyZnak & "All")

        ' Записать все объекты которые надо скопировать в один массив MyObjs
        Dim lst As New ArrayList()
        If MyObj Is Nothing Then Return Nothing
        For i = 0 To MyObj.Length - 1
            If Iz.isPoleznie(MyObj(i).obj) Then lst.Add(MyObj(i))
            MyObjs = proj.GetMyAllFromName("", , MyObj(i).obj.name) '(MyObj)
            lst.AddRange(MyObjs)
        Next
        MyObjs = lst.ToArray

        ' если это форма и ее пытаются сохранить в файле, то с ней надо сохранять все её объекты, включая полуобъекты
        'If toEng Or isRun And MyObj.Length = 1 Then
        '    If Iz.IsFORM(MyObj(0)) Then MyObjs = MyObj(0).MyObjs
        'End If
        'MyObjs = proj.GetSortMyObjsByLevelConteiner(MyObjs)
        'For i = 0 To PoleznieObjs.Length - 1
        '    ReDims(MyObjs) : MyObjs(MyObjs.Length - 1) = PoleznieObjs(i)
        'Next
        ' Теперь перевести каждый объект в текст
        For i = 0 To MyObjs.Length - 1
            ' Прогресс-форма
            If withProgres Then ProgressForm.ProgressBarValue = (100 / (MyObjs.Length)) * i
            If proj.pProgressForm = "yes" Then
                If (i Mod 5) = 0 Then
                    initial &= "ProgressForm.ProgressBar1.Value = " & Round((25 / (MyObjs.Length)) * i) & vbCrLf
                    added &= "ProgressForm.ProgressBar1.Value = " & 25 + Round((10 / (MyObjs.Length)) * i) & vbCrLf
                    histors &= "ProgressForm.ProgressBar1.Value = " & 35 + Round((10 / (MyObjs.Length)) * i) & vbCrLf
                End If
                fill &= "ProgressForm.ProgressBar1.Value = " & 45 + Round((55 / (MyObjs.Length)) * i) & vbCrLf
            End If

            ' ДЕКЛАРАЦИЯ И ИНИЦИАЛИЗАЦИЯ
            Dim Name As String = GetCompilName(MyObjs(i))
            Dim frmName As String = GetCompilName(MyObjs(i).getMyForm)
            Dim tip As String = MyObjs(i).obj.GetType.ToString.Substring(ClassAplication.Length)
            Dim tipMy As String = MyObjs(i).GetType.ToString.Substring(ClassAplication.Length)
            If isPoleznie(MyObjs(i).obj) And Iz.IsFORM(MyObjs(i)) = False Then
                declar &= "Public WithEvents " & Name & " As New PoleznieObj(""" & MyObjs(i).obj.Props.name & """)" & vbCrLf
                initial &= Name & ".MyObj = New " & tipMy & "(""" & MyObjs(i).obj.props.type & """)" & vbCrLf
            Else
                declar &= "Public WithEvents " & Name & " As New run" & tip & vbCrLf
                If Iz.IsFORM(MyObjs(i)) Then
                    initial &= Name & ".MyObj = New " & tipMy & "(True, , True)" & vbCrLf
                Else
                    initial &= Name & ".MyObj = New " & tipMy & "(True, True)" & vbCrLf
                End If
                If Iz.IsCM(MyObjs(i)) Then
                    declar &= "Public WithEvents " & Name & "CnMn As ContextMenuStrip = " & Name & ".CnMn" & vbCrLf
                End If
            End If
            initial &= Name & ".MyObj.proj = proj" & vbCrLf
            initial &= Name & ".MyObj.obj = " & Name & vbCrLf
            initial &= Name & ".MyObj.VBname = """ & Name & """" & vbCrLf
            initial &= Name & ".MyObj.MyObj.MyForm = " & frmName & ".MyObj" & vbCrLf

            If Iz.IsFORM(MyObjs(i)) Then
                initial &= "ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = " & Name & ".MyObj" & vbCrLf
            End If
            initial &= "ReDimsO(" & Name & ".MyObj.MyForm.MyObjs) : " & Name & ".MyObj.MyForm.MyObjs(" _
                    & Name & ".MyObj.MyForm.MyObjs.Length - 1) = " & Name & ".MyObj" & vbCrLf & vbCrLf

            ' СОХРАНЕНИЕ ВСЕХ СВОЙСТВ
            Dim otlozhProps() As String = {UCase(trans("Вышина")), UCase(trans("Ширина")), UCase(trans("Видимый")), _
                UCase(trans("Вышина")), UCase(trans("Ширина")), UCase(trans("Значение")), UCase(trans("Выделенная запись")), _
                UCase(trans("RTF код документа")), UCase(trans("Расстояние разделителя")), UCase(trans("Ссылка"))}
            If MyObjs(i).Propertys IsNot Nothing And Iz.isPoleznie(MyObjs(i).obj) = False Then
                IzmenenieBylo2(MyObjs(i))
                Dim prop As ErrString
                For j = 0 To MyObjs(i).Propertys.Length - 1
                    If Array.IndexOf(ReadOnlyProps, MyObjs(i).PropertysUp(j)) <> -1 Then Continue For
                    prop = GetProperty(MyObjs(i), MyObjs(i).Propertys(j))
                    ' если это не свойство по умолчанию и свойство без ошибки
                    If (isRun = False Or prop.str <> GetProperty(Pustishki(tip), MyObjs(i).Propertys(j)).str _
                    Or Iz.IsFORM(MyObjs(i))) And prop.err = "" And Array.IndexOf(NoSaveProps, UCase(MyObjs(i).Propertys(j))) = -1 _
                    And Array.IndexOf(otlozhProps, MyObjs(i).PropertysUp(j)) = -1 Then

                        Dim adds As String = ""
                        prop.str = CreateKovich(perevesti(prop.str, False))
                        If UCase(MyObjs(i).Propertys(j)) = UCase(trans("Статус окна")) Then
                            fill &= Name & ".StatusTemp = """ & MyObjs(i).obj.props.WindowState & """" & vbCrLf
                            Continue For
                        ElseIf UCase(MyObjs(i).Propertys(j)) = UCase(trans("Вложенное всплывающее меню")) _
                        Or UCase(MyObjs(i).Propertys(j)) = UCase(trans("Главное меню")) _
                        Or UCase(MyObjs(i).Propertys(j)) = UCase(trans("Всплывающее меню")) Then
                            adds = "(True)"
                        End If
                        fill &= Name & ".Props." & trans(MyObjs(i).Propertys(j), True).Replace(" ", "") & adds & _
                              " = perevesti(" & getCompilLineLength("""" & prop.str & """") & ", True)" & vbCrLf

                    End If
                Next
                ' Присвоить отложенные свойства, которые надо присваивать последними
                For j = 0 To otlozhProps.Length - 1
                    If Array.IndexOf(MyObjs(i).PropertysUp, otlozhProps(j)) <> -1 Then
                        prop.str = CreateKovich(perevesti(GetProperty(MyObjs(i), otlozhProps(j)).str, False))
                        fill &= Name & ".Props." & trans(otlozhProps(j), True).Replace(" ", "") & _
                              " = perevesti(" & getCompilLineLength("""" & prop.str & """") & ", True)" & vbCrLf
                    End If
                Next
                fill &= vbCrLf
            End If
            If Iz.isPoleznie(MyObjs(i).obj) Then
                fill &= Name & ".Props.Name = """ & MyObjs(i).obj.Props.name & """" & vbCrLf & vbCrLf
            End If

            ' СОХРАНЕНИЕ КОНТЕНЕРА
            If MyObjs(i).conteiner Is Nothing = False Then
                If MyObjs(i).obj.typeObj <> "PoluObj" Then
                    If Iz.IsMMs(MyObjs(i)) Then
                        added &= GetCompilName(MyObjs(i).conteiner) & ".MyObj.addMMenuItem(" & Name & ".MyObj)" & vbCrLf
                    ElseIf Iz.IsDP(MyObjs(i).conteiner) Then
                        If MyObjs(i).obj.Parent IsNot Nothing Then
                            added &= GetCompilName(MyObjs(i).conteiner) & "." & MyObjs(i).obj.Parent.name _
                                          & ".Controls.Add(" & Name & ")" & vbCrLf
                        End If
                    Else
                        added &= GetCompilName(MyObjs(i).conteiner) & ".Controls.Add(" & Name & ")" & vbCrLf
                    End If
                Else
                    'added &= frmName & ".Controls.Add(" & Name & ")" & vbCrLf
                End If
            End If

            ' СОХРАНЕНИЕ ХИСТОРИ ЛЕВЕЛА
            If Iz.IsFORM(MyObjs(i)) And Iz.isPoleznie(MyObjs(i).obj) = False Then
                For j = 0 To MyObjs(i).HistoryLevel.count - 1
                    If MyObjs(i).HistoryLevel(j).conteiner IsNot Nothing Then
                        histors &= GetCompilName(MyObjs(i).HistoryLevel(j)) & ".BringToFront()" & vbCrLf
                    End If
                Next
            End If

            ' СОЗДАНИЕ НУЖНЫХ СОБЫТИЙ
            If Iz.IsFORM(MyObjs(i)) Then
                nadoevents &= "Public Sub " & Name & "_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles " & Name & ".Disposed" & vbCrLf & _
                          "    If DaOrNet(" & Name & ".Props.MainForm) Then proj.isCLOSING = True : Application.Exit()" & vbCrLf & _
                          "End Sub" & vbCrLf & vbCrLf
                nadoevents &= "Public Sub " & Name & "_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles " & Name & ".FormClosing" & vbCrLf & _
                          "    If DaOrNet(" & Name & ".Props.ForbidClose) Then e.Cancel = True : Exit Sub" & vbCrLf & _
                          "    If UCase(" & Name & ".Props.MainForm) = UCase(trans(""Да"")) Or proj.isCLOSING Then" & vbCrLf & _
                          "        " & Name & ".Hide() : Application.Exit()" & vbCrLf & _
                          "    Else" & vbCrLf & _
                          "        e.Cancel = True : " & Name & ".Hide()" & vbCrLf & _
                          "    End If" & vbCrLf & _
                          "End Sub" & vbCrLf & vbCrLf
            ElseIf Iz.IsMd(MyObjs(i)) Then
                nadoevents &= "Public Sub " & Name & "_SizeChangedNado(ByVal sender As Object, ByVal e As System.EventArgs) Handles " & Name & ".SizeChanged" & vbCrLf & _
                            Name & ".Props.Refresh()" & vbCrLf & "End Sub" & vbCrLf & vbCrLf
            ElseIf Iz.IsRT(MyObjs(i)) Then
                nadoevents &= "Public Sub " & Name & "_LinkClickedNado(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles " & Name & ".LinkClicked" & vbCrLf & _
                          "    If DaOrNet(" & Name & ".Props.InternetLink) Then " & Name & ".Props.GoInternetLink(e.LinkText)" & vbCrLf & _
                          "End Sub" & vbCrLf & vbCrLf
            ElseIf Iz.IsLLb(MyObjs(i)) Then
                nadoevents &= "Public Sub " & Name & "_LinkClickedNado(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles " & Name & ".LinkClicked" & vbCrLf & _
                          "    If DaOrNet(" & Name & ".Props.InternetLink) Then " & Name & ".Props.GoInternetLink()" & vbCrLf & _
                          "End Sub" & vbCrLf & vbCrLf
            ElseIf Iz.IsTm(MyObjs(i)) Then
                nadoevents &= "Public Sub " & Name & "_TickNado(ByVal sender As Object, ByVal e As System.EventArgs) Handles " & Name & ".Tick" & vbCrLf & _
                           Name & ".Props.IntervalCount += 1" & vbCrLf & _
                          "End Sub" & vbCrLf & vbCrLf
            ElseIf Iz.IsW(MyObjs(i)) Then
                nadoevents &= "Public Sub " & Name & "_StatusTextChangedNado(ByVal sender As Object, ByVal e As System.EventArgs) Handles " & Name & ".StatusTextChanged" & vbCrLf & _
                              "    If sender.StatusText <> """" Then" & vbCrLf & _
                              "        If Uri.IsWellFormedUriString(sender.StatusText, UriKind.RelativeOrAbsolute) Then" & vbCrLf & _
                              "             sender.lastLink = sender.StatusText" & vbCrLf & _
                              "        End If" & vbCrLf & _
                              "    End If" & vbCrLf & _
                              "End Sub" & vbCrLf & _
                              "Public Sub " & Name & "_NewWindowNado(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles " & Name & ".NewWindow" & vbCrLf & _
                              "    peremens2.WebBrowser_NewWindowNado(sender, e)" & vbCrLf & _
                              "End Sub" & vbCrLf & vbCrLf
            ElseIf Iz.IsTbx(MyObjs(i)) Then
                nadoevents &= "Public Sub " & Name & "_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles " & Name & ".KeyPress" & vbCrLf & _
                              "    e.Handled = TextBoxAllow(sender, e)" & vbCrLf & _
                              "End Sub" & vbCrLf & vbCrLf
            End If

            ' СОХРАНЕНИЕ УЗЛА
            Dim node As TreeNode = MyObjs(i).GetNode(, True)
            If node IsNot Nothing Then
                isCompilBest = True
                For j = 0 To node.Nodes.Count - 1
                    events &= getCompilEvent(MyObjs(i), node.Nodes(j), Name) & vbCrLf & vbCrLf

                    ' ОЧЕРЕДНОСТЬ СОБЫТИЙ. Например, Tick и NadoTick чтобы очередность выполнения была правильной!
                    If node.Nodes(j).Text.ToUpper = trans("Тикнул").ToUpper Then
                        creates &= "RemoveHandler " & Name & ".Tick, AddressOf " & Name & "_Tick" & vbCrLf
                        creates &= "AddHandler " & Name & ".Tick, AddressOf " & Name & "_Tick" & vbCrLf & vbCrLf
                    End If

                Next
                isCompilBest = False
            End If

            ' ОКОНЧАТЕЛЬНАЯ ЗАГРУЗКА
            If Iz.isPoleznie(MyObjs(i).obj) = False Then
                loads &= Name & ".load()" & vbCrLf
                If Iz.IsFORM(MyObjs(i)) Then
                    If prevFrm <> "" Then creates &= prevFrm & ".RaiseCreate()" & vbCrLf
                    prevFrm = Name
                Else
                    creates &= Name & ".RaiseCreate()" & vbCrLf
                End If
            End If

        Next
        creates &= prevFrm & ".RaiseCreate()" & vbCrLf


        ' СОЕДИНЕНИЕ ВСЕГО В VB КОД
        str = "Module CodeAlg" & vbCrLf & vbCrLf
        ' str &= "Public LLLangNam As String = """ & lang_name & """" & vbCrLf & vbCrLf
        str &= declar & vbCrLf & vbCrLf
        str &= "    Sub Initial()" & vbCrLf & "RunProj.isINITIALIZATED = True" & vbCrLf & vbCrLf
        str &= "' Задание переменных" & vbCrLf
        str &= "RunProj.iPathShort = " & """" & proj.iPathShort & """" & vbCrLf
        str &= "RunProj.iPath = RunProj.pPath & RunProj.iPathShort" & vbCrLf & vbCrLf
        If proj.pProgressForm = "yes" Then
            str &= "' Отображение полосы загрузки" & vbCrLf
            str &= "ProgressForm.Label1.Text = """ & transInfc("Загрузка") & "...""" & vbCrLf
            str &= "ProgressForm.Show()" & vbCrLf
            str &= "Application.DoEvents()" & vbCrLf
            str &= "ProgressForm.ProgressBarValue = 1" & vbCrLf & vbCrLf
        End If
        str &= "' Создание всех объектов" & vbCrLf
        str &= initial & vbCrLf & vbCrLf
        str &= "' Размещение объектов на окнах" & vbCrLf
        str &= added & vbCrLf & vbCrLf
        str &= "' Уровнять по уровням объекты" & vbCrLf
        str &= histors & vbCrLf & vbCrLf
        str &= "' Настройка свойств объектов" & vbCrLf
        str &= fill & vbCrLf
        'str &= "initial2()" & vbCrLf & vbCrLf
        str &= "' Окончательная загрузка" & vbCrLf
        str &= loads & vbCrLf & "RunProj.GetAllObjects()" & vbCrLf & "RunProj.isINITIALIZATED = False" & vbCrLf & vbCrLf & creates & vbCrLf
        If proj.pProgressForm = "yes" Then str &= "ProgressForm.Hide()" & vbCrLf
        str &= "    End Sub" & vbCrLf & vbCrLf
        str &= "' Обязательные события" & vbCrLf
        str &= nadoevents & vbCrLf & vbCrLf
        str &= "' Все события" & vbCrLf
        str &= events & vbCrLf
        str &= "End Module" & vbCrLf & vbCrLf & vbCrLf & vbCrLf

        'str &= "Module CodeAlg2" & vbCrLf & vbCrLf
        'str &= "    ' Настройка свойств объектов" & vbCrLf
        'str &= "    Sub Initial2()" & vbCrLf & vbCrLf
        'str &= fill & vbCrLf & vbCrLf
        'str &= "    End Sub" & vbCrLf & vbCrLf
        'str &= "End Module" & vbCrLf & vbCrLf & vbCrLf & vbCrLf

        Return str
    End Function
    ' ПРЕОБРАЗОВАНИЕ ВЕТКИ СОБЫТИЯ ДЕРЕВА В ПРОЦЕДУРУ VB
    Function getCompilEvent(ByVal myObj As Object, ByVal node As TreeNode, ByVal name As String) As String
        Dim tip As String = trans(node.Text, True).Replace(" ", "")
        Dim ps As New PropertysSobyt(Nothing, Nothing, Nothing, node.Text)
        Dim str = "", intro = "", handls As String = name
        If node.Tag <> "Sobyt" Then Return ""

        ' Настройка под отдельные события
        If UCase(node.Text) = UCase(trans("Добавли строку")) Or UCase(node.Text) = UCase(trans("Удалили строку")) Then
            intro = "If " & name & ".Props.isSelecExecute Then Exit Sub" & vbCrLf
        ElseIf Iz.IsTbx(myObj) And UCase(node.Text) = UCase(trans("Нажатие клавиатуры")) Then
            intro = "e.Handled = TextBoxAllow(sender, e)" & vbCrLf
            intro &= "If e.Handled Then Exit Sub" & vbCrLf
        ElseIf UCase(node.Text) = UCase(trans("Клик по выделенной ячейке")) Then
            tip = "CellMouseDown"
            intro = "If e.RowIndex > -1 And e.ColumnIndex > -1 Then" & vbCrLf _
                  & "   If " & name & ".Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = False Then Exit Sub" & vbCrLf _
                  & "End If" & vbCrLf
        ElseIf UCase(node.Text) = UCase(trans("Движение бегунка")) Then
            tip = "Scroll"
        ElseIf Iz.IsCM(myObj) Then
            handls &= "CnMn"
        End If

        ' Строка заголовка события
        str = "Public Sub " & name & "_" & tip & "(ByVal sender As Object, ByVal e As "
        str &= ps.eType & ") Handles " & handls & "." & tip & vbCrLf
        ' Блокировка события, если еще идет инициализация
        str &= "If RunProj.isINITIALIZATED Then Exit Sub" & vbCrLf
        ' Переменная события, со всей информацией о данном событии и доступом
        str &= "Dim CurrentEvent as New PropertysSobyt(" & name & ".MyObj, e, nothing,""" & node.Text & """)" & vbCrLf
        str &= intro & vbCrLf

        ' Все действия события
        Dim i As Integer
        For i = 0 To node.Nodes.Count - 1
            If node.Nodes(i).Tag = "Comm" Or node.Nodes(i).Text.IndexOf("'") = 0 _
            Or node.Nodes(i).Text.IndexOf("#") = 0 Or node.Nodes(i).Text.IndexOf("/") = 0 Then
                Continue For
            End If
            str &= getCompilNode(node.Nodes(i))
        Next
        str &= "CurrentEvent.Zavershit()" & vbCrLf & "End Sub" & vbCrLf
        Return str
    End Function
    ' ПРЕОБРАЗОВАНИЕ УЗЛА ДЕРЕВА В СТРОКУ КОДА VB
    Function getCompilNode(ByVal node As TreeNode) As String
        Dim i As Integer, str As String, bylEndIfWhile As Boolean = False
        If UCase(node.Text) = UCase(trans("Добавьте сюда действия")) Then Return str
        str = rp.RunString(node.Text, node.Tag, rp.Param).str & vbCrLf
        For i = 0 To node.Nodes.Count - 1
            str &= getCompilNode(node.Nodes(i))
        Next
        Return str
    End Function
    ' СТРОКА БАЗИКА ОГРАНИЧЕНЕ 65555 СИМВОЛАМИ. РАЗБИВАЕМ СТРОКУ НА БЛОКИ ПО razbivkaCount СИМВОЛОВ
    Function getCompilLineLength(ByVal str As String) As String
        Dim i As Integer = 0, razbivkaCount As Integer = 9998, ret As String = ""
        While str.Length - i > razbivkaCount
            Dim kovich As Char = """"
            Dim popravka As Integer = 0
            Dim count As Integer = 0
            ' считаем количество кавычек до места разбива, чтобы не влезть в ""
            While str.Substring(razbivkaCount + i - count, 1) = """"
                count += 1
            End While
            ' если вслезли в "", то сделать поправку
            If count > 0 And count Mod 2 = 0 Then popravka = 1
            ' если предыдущий символ кавычка, то текст и так закончен, кавычки ставить не надо
            If count = 0 AndAlso str.Chars(razbivkaCount + i - 1) = """" Then
                Dim j As Integer = razbivkaCount + i - 1
                While j >= 0
                    If str.Substring(j, 1) = """" Then count += 1
                    j -= 1
                End While
                If count Mod 2 = 0 Then kovich = ""
            End If

            str = str.Substring(0, razbivkaCount + i - popravka) & kovich & " & _" & vbCrLf & kovich & str.Substring(razbivkaCount + i - popravka)
            i += razbivkaCount - popravka
        End While
        Return str
    End Function
    ' ПОЛУЧЕНИЕ ИМЕНИ ОБЪЕКТА, КОТОРОЕ БУДЕ У НЕГО В VB
    Function GetCompilName(ByVal myObj As Object) As String
        Return myObj.GetMyForm.obj.Props.name.Replace(" ", "_") & myObj.GetMyForm.obj.Props.Index.Replace(",", "_") & _
                myObj.obj.Props.name.Replace(" ", "_") & myObj.obj.Props.Index.Replace(",", "_")
    End Function
End Module
