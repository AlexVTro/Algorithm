Public Class Project
    Public f() As Forms = Nothing   ' ������ ����
    Public ActiveForm As Forms      ' �����, �������� � ������ ������
    Public pPath, iPath, iPathShort, pFileName, pIcon, pPicNameDef, pProgressForm As String   ' ����� ������� ������� � ����� ��� ��������
    Public SobytMyObjs() As Object  ' ���������, �������� ������� ������� ��������
    'Public Undo, Redo As String
    Public UndoAr(), RedoAr() As String
    Public UndoRedoCount As Integer
    Public UndoRedoNoWrite As Boolean
    Public lastForm As Object

    ' <<<<<<<< �������� � ��������� ������� >>>>>>>>>
#Region "CREATE"

    ' �������� ������� � ������������ ������
    Sub New(ByVal pname As String)
        Dim i As Integer = 1
        If IO.Directory.Exists(ProjectsPath) = False Then
            ProjectsPath = AppPath & trans("�������") & "\"
        End If
        While System.IO.Directory.Exists(ProjectsPath & "\" & pname & i)
            If System.IO.Directory.GetDirectories(ProjectsPath & "\" & pname & i).Length + System.IO.Directory.GetFiles(ProjectsPath & "\" & pname & i).Length = 0 Then Exit While
            i += 1
        End While
        ' ������� ��������� �����
        pPath = ProjectsPath & pname & i & "\"
        iPathShort = ProjIpath
        iPath = pPath & iPathShort
        pFileName = pname & i & ".alg"
        pPicNameDef = trans("�������")
        pProgressForm = "yes"
        IO.Directory.CreateDirectory(pPath)
        MainForm.Text = pPath & pFileName & " - " & trans("�������� 2")
        ' ������� ������ �������� �������� �� �����
        ReDim Preserve f(0) : f(0) = New Forms(, True)
        ' �������� ������ �����
        AddForm()
    End Sub

    ' ������ ������� ������ ������, ��� ������� � ��� ��������
    Sub New()
    End Sub

    ' ��������� ����� � ������
    Sub AddForm(Optional ByVal form As Forms = Nothing)
        Dim NewInd As Integer
        If f Is Nothing Then NewInd = 0 Else NewInd = f.Length
        ReDim Preserve f(NewInd)
        ' ����������� ������ �������� �������� � �����
        f(NewInd) = f(NewInd - 1)
        ' �� ����� ������� �������� �������� �������� ����� �����
        If form Is Nothing Then
            f(NewInd - 1) = New Forms() : ActiveForm = f(NewInd - 1)
            MainForm.TabControl1.SelectTab(f(NewInd - 1).obj.Parent.Parent.Parent)
            f(NewInd - 1).obj.Parent.Parent.Panel2.ContextMenuStrip = MainForm.SplitPanelMenu
        Else
            f(NewInd - 1) = form
        End If
        f(NewInd - 1).SetActiveObject(f(NewInd - 1), True) : f(NewInd - 1).marker_vis()
        If CreateDs Is Nothing = False Then CreateDs.SetProperty(True)

    End Sub

#End Region

    ' <<<<<<<< ������ ������� ������� >>>>>>>>>
#Region "FUNCTIONS"

    ' ��������� ��� ������� �� ������ str
    Function GiveName(ByVal str As String) As String
        Dim i As Integer = 1
        While ExistName(str & i) : i += 1 : End While
        Return str & i
    End Function

    ' ���� �������� ��� �� ���������� ��� �������
    Public Sub ChangeName(ByVal obj As Object, ByVal oldName As String)
        Dim myObj As Object = GetMyObjFromObj(obj)
        If myObj Is Nothing Then Exit Sub
        Dim exp As Boolean
        If myObj.getNode(oldName) Is Nothing = False Then
            exp = myObj.getNode(oldName).IsExpanded()
        End If
        If UndoAr Is Nothing = False Then
            ' �������� ����� ����� �� ������� ����� �� �����
            If UndoAr(UndoAr.Length - 1).LastIndexOf("#Union Undos(Redos)") = UndoAr(UndoAr.Length - 1).Length - "#Union Undos(Redos)".Length And UndoAr(UndoAr.Length - 1).LastIndexOf("#Union Undos(Redos)") <> -1 Then
            Else ' ����
                UndoRedo("#Reverses", "", "", "")
            End If
        End If
        If myObj Is Nothing = False Then myObj.NodeRefresh(oldName)

        ' ������������� ������ ����� � ������ ��������
        Dim old_frm As String
        If Iz.IsFORM(myObj) Then old_frm = oldName Else old_frm = myObj.getmyform.obj.name
        If isOpening = False And isTranslate = False Then
            If isConsole = False Then
                'Dim ReN As New ReNameThread(Nothing, New reName(obj.name, myObj.getmyform.obj.name, oldName, old_frm))
                'Dim runProc As New Threading.Thread(AddressOf ReN.transTree)
                'runProc.Start()
                transTree(Nothing, New reName(obj.name, myObj.getmyform.obj.name, oldName, old_frm))
            Else
                ochered &= obj.name & "." & myObj.getmyform.obj.name & "." & oldName & "." & old_frm & "&"
            End If
        End If

        If exp Then
            If myObj.getNode Is Nothing = False Then myObj.getNode.ExpandAll()
        End If
    End Sub
    Function ChangeIndex(ByVal o As Object, ByVal b As Object)
        Return ""
    End Function

    ' ���������, ���������� �� ����� ���
    Function ExistName(ByVal name As String, Optional ByVal obj As Object = Nothing, Optional ByVal myForms As Object = Nothing) As Boolean
        Dim i, j As Integer
        ' �����, � ������� ���� ������ ������������� ����� name
        Dim myForm() = myForms
        ' ���� ����� ��� ���� � �����
        If f Is Nothing Then Return False
        For i = 0 To f.Length - 1
            If f(i) Is Nothing = False Then
                ' ���� ��� ����� �� ��� ������ obj, ��� �������� ������ ����� ����������� ���
                If f(i).obj Is obj = False Then
                    ' ���� ����� � ����� ������ ����
                    If UCase(f(i).obj.Props.Name) = UCase(name) Then Return True
                End If
            End If
        Next
        ' ���� ����� �� �������� � �������, �� ���� � �������� �����
        If myForm Is Nothing Then
            If obj IsNot Nothing AndAlso obj.myobj IsNot Nothing AndAlso obj.myobj.getmyform IsNot Nothing Then
                myForm = New Object() {obj.myobj.getmyform}
            Else
                If ActiveForm Is Nothing = False Then myForm = GetMyFormsFromName(ActiveForm.obj.Props.name) Else Return False
            End If
        End If
        If myForm Is Nothing Then Return False
        For i = 0 To myForm.Length - 1
            If myForm(i).MyObjs Is Nothing Then Continue For
            For j = 0 To myForm(i).MyObjs.Length - 1
                ' ���� ��� �� ��� ������ obj, ��� �������� ������ ����� ����������� ���
                If myForm(i).MyObjs(j).obj Is obj = False Then
                    ' ���� ������ � ����� ������ ����
                    If UCase(myForm(i).MyObjs(j).obj.Props.name) = UCase(name) Then Return True
                End If
            Next
        Next
        Return False ' ���� ���������� ��� � str �� �������
    End Function

    ' ������������ ������ �������� �������, ���������� ��������
    Function GetPropertyNames(ByVal IncludeReadOnly As Boolean, ByVal ParamArray MyObjs() As Object) As String()
        Dim props() As String = Nothing, i, j, ind As Integer, adds As String
        ' ����������� ��� �������
        For i = 0 To MyObjs.Length - 1
            ' ���� props ����
            If props Is Nothing Then ind = 0 : ReDim Preserve props(ind) : props(ind) = ""
            ' ���� props �� ����, �������� �� ��������, ������� ��� ��� ���
            If MyObjs(i).Propertys Is Nothing = False Then
                For j = 0 To MyObjs(i).Propertys.Length - 1
                    If Array.IndexOf(props, MyObjs(i).Propertys(j)) = -1 Then
                        ' ���� �� ����� �������� ������ ��� ������
                        If Array.IndexOf(ReadOnlyProps, MyObjs(i).PropertysUp(j)) <> -1 And IncludeReadOnly = False Then
                            adds = "  -  [" & trans("���� � ������� ������� ��������") & "]" : Else : adds = "" ' Continue For
                        End If
                        ReDim Preserve props(ind)
                        props(ind) = MyObjs(i).Propertys(j) & adds : ind += 1
                    End If
                Next
            End If
        Next
        If props(0) = "" Then props = Nothing
        Return props
    End Function

    ' ������������ ������ �������� �������, ���������� ��������
    Function GetMethodNames(ByVal ParamArray MyObjs() As Object) As String()
        Dim meths() As String = Nothing, i, j As Integer
        ' ����������� ��� �������
        For i = 0 To MyObjs.Length - 1
            ' ���� meths ����, ������� � ���� ��� ������ �������
            If meths Is Nothing Then
                meths = MyObjs(i).Methods
            Else
                ' ���� meths �� ����, �������� �� ������, ������� ��� ��� ���
                For j = 0 To MyObjs(i).Methods.Length - 1
                    If Array.IndexOf(meths, MyObjs(i).Methods(j)) = -1 Then
                        ReDim Preserve meths(meths.Length)
                        meths(meths.Length - 1) = MyObjs(i).Methods(j)
                    End If
                Next
            End If
        Next
        Return meths
    End Function

   

    ' �������� ��������� ������(����. ����������) �� ������ ��������(����������)
    Public Function GetSostObjFromIncludeObj(ByVal MyObj As Object) As Object
        Dim SostObj As Object, fl As Integer
        ' ���� ��� ��������� ������ � ��� ��� �� �������� ��������, �� ��������� ����� ������ �������� ������ �� ���� ��� ��� ������������
        SostObj = ActiveForm.ActiveObj(0)
        If fl <> 1 Then
            ' ���� ����������� ������ � �������� ����������� �����
            If SostObj.GetType.ToString = MyObj.GetType.ToString _
            Or (Iz.IsCM(SostObj) And Iz.IsMMs(MyObj)) Or (Iz.IsTPl(SostObj) And Iz.IsMMs(MyObj)) Then
                fl = 1
                If Iz.IsTPs(SostObj) Then SostObj = SostObj.conteiner
                '   If (Iz.IsMMs(SostObj) Or Iz.IsCM(SostObj) Or Iz.IsTPl(SostObj)) And isConsole Then
                ' � ���� ������ ����� ���� ��������� ����� ���� ��� ��������
                ' Else
                ' SostObj = SostObj.conteiner
                '  End If
            End If
        End If
        If fl <> 1 Then
            ' ���� ����������� ������ � �������� ����������� ����� (��� s �� �����)
            If SostObj.GetType.ToString = MyObj.GetType.ToString.Substring(0, MyObj.GetType.ToString.Length - 1) Then
                fl = 1
            End If
        End If
        If fl = 1 Then Return SostObj Else Return Nothing
    End Function


    ' �������� �������� �������� ��� ���� ���� ������� ����� �������� ��� ����
    Function ProtivoDeist(ByVal deistv As String) As String
        Dim protivo As String
        If deistv = "�������" Then
            protivo = "�������"
        ElseIf deistv = "�������" Then
            protivo = "�������"
        ElseIf deistv = "�� �������� ����" Then
            protivo = "�� ������ ����"
        ElseIf deistv = "�� ������ ����" Then
            protivo = "�� �������� ����"
        Else
            protivo = deistv
        End If
        Return protivo
    End Function
    Sub ReDimUndoRedo()
        If UndoAr Is Nothing = False Then
            ' ���� ��� ����� ������ � ����� �����, �� ���� �������� �����
            If UndoAr(UndoAr.Length - 1).LastIndexOf("#Union Undos(Redos)") = UndoAr(UndoAr.Length - 1).Length - "#Union Undos(Redos)".Length And UndoAr(UndoAr.Length - 1).LastIndexOf("#Union Undos(Redos)") <> -1 Then
                UndoAr(UndoAr.Length - 1) &= vbCrLf : RedoAr(RedoAr.Length - 1) &= vbCrLf
            ElseIf UndoAr(UndoAr.Length - 1) = "#Revers Undo" & vbCrLf Or RedoAr(RedoAr.Length - 1) = "#Revers Redo" & vbCrLf Then
                ' ���� ����� ����� � ���� ��� ������������� ������� ��������, �� �� ��� ���������
            Else
                ReDims(UndoAr) : ReDims(RedoAr)
            End If
        Else
            ReDims(UndoAr) : ReDims(RedoAr)
        End If
    End Sub
    ' ������ � ���������� ���������� ���� � ���� ������ �����������
    Public Sub UndoRedo(ByVal Deistv As String, ByVal tip As String, ByVal Chto As String, _
    Optional ByVal protivoChto As String = "~tozhe chto i chto~", Optional ByVal onlyUndo As Boolean = False)
        Dim Undo, Redo As String
        If protivoChto = "~tozhe chto i chto~" Then protivoChto = Chto

        If UndoRedoNoWrite = True Or bistro_UnRe Then Exit Sub
        UndoRedoRemoveIspolzovanie()
        MainForm.UndoPanel.Enabled = True : MainForm.UndoMenu.Enabled = True
        MainForm.RedoPanel.Enabled = False : MainForm.RedoMenu.Enabled = False
        MainForm.RedoPanel.ToolTipText = "" : MainForm.RedoMenu.ToolTipText = ""
        tokaSohranil = False

        If Deistv = "#Union Undos(Redos)" Then
            If UndoAr Is Nothing Then Exit Sub
            UndoAr(UndoAr.Length - 1) &= Deistv : RedoAr(RedoAr.Length - 1) &= Deistv
            Exit Sub
        ElseIf Deistv = "#Revers Undo" Then
            ReDimUndoRedo()
            UndoAr(UndoAr.Length - 1) &= Deistv & vbCrLf : RedoAr(RedoAr.Length - 1) &= ""
            Exit Sub
        ElseIf Deistv = "#Revers Redo" Then
            ReDimUndoRedo()
            RedoAr(RedoAr.Length - 1) &= Deistv & vbCrLf : UndoAr(UndoAr.Length - 1) &= ""
            Exit Sub
        ElseIf Deistv = "#Reverses" Then
            ReDimUndoRedo()
            RedoAr(RedoAr.Length - 1) &= "#Revers Redo" & vbCrLf : UndoAr(UndoAr.Length - 1) &= "#Revers Undo" & vbCrLf
            Exit Sub
        End If


        Undo = "#New" & vbCrLf
        Undo &= trans(Deistv) & " " & trans(tip) & vbCrLf
        Undo &= ProtivoDeist(Deistv) & ":" & tip & vbCrLf
        Undo &= protivoChto & vbCrLf

        ' �.�. �� ������ �������� � ��������� � ����, ��� ������, �� ���� ������ ���, � ���� ������ ���� �������� ������, ������� ����� �������� �� �����
        If tip.Split(".").Length = 3 Then
            If tip.Split(".")(2) = trans("���") Then
                Dim index As String = "[" & tip.Split(".")(1).Split("[")(1)
                ' ���� ������ ��� �����
                If GetMyObjFromUniqName(tip).obj.GetType.ToString = ClassAplication & "F" Then
                    tip = protivoChto & "." & protivoChto & index & "." & tip.Split(".")(2)
                Else
                    ' ���� ������ ��� �������� �������
                    tip = tip.Split(".")(0) & "." & protivoChto & index & "." & tip.Split(".")(2)
                End If
            ElseIf tip.Split(".")(2) = trans("�����") Then
                tip = tip.Replace(tip.Split(".")(1).Split("[")(1), protivoChto & "]")
            End If
        End If
        If onlyUndo = False Then
            Redo = "#New" & vbCrLf
            Redo &= trans(Deistv) & " " & trans(tip) & vbCrLf
            Redo &= Deistv & ":" & tip & vbCrLf
            Redo &= Chto & vbCrLf
        End If

        ReDimUndoRedo()

        UndoAr(UndoAr.Length - 1) &= Undo
        RedoAr(RedoAr.Length - 1) &= Redo

        MainForm.RichTextBox1.Text = RedoAr(RedoAr.Length - 1)
        MainForm.RichTextBox2.Text = UndoAr(UndoAr.Length - 1)
    End Sub
    ' ������ � ���������� ���������� ���� � ���� ����������\�������� ������ �������� ������
    Sub UndoRedoTree(ByVal withUnion As Boolean, ByVal SozdOrUdal As Boolean, ByVal ParamArray nodes() As TreeNode)
        If bistro_UnRe Then Exit Sub
        If nodes Is Nothing Then Exit Sub
        If nodes.Length = 0 Then Exit Sub
        If withUnion Then UndoRedo("#Union Undos(Redos)", "", "", "")
        Dim str As String = MainForm.GetCopyTree(nodes, True)
        If SozdOrUdal = True Then
            UndoRedo("�������", "������� ������", str, str)
        Else
            UndoRedo("�������", "������� ������", str, str)
        End If
    End Sub

    Sub UndoRedoRemoveIspolzovanie()
        Dim i As Integer
        For i = 0 To UndoRedoCount - 1
            DelDims(UndoAr, 0) : DelDims(RedoAr, RedoAr.Length - 1)
        Next
        UndoRedoCount = 0
    End Sub

    'Sub UndoRedoReplaceNodeNames(gdeMenyat,)

    'End Sub

    ' ��������� ������� �� ����������� �����
    Public Function GetMyObjFromUniqName(ByVal uniqName As String) As Object
        If isCompilBest Then Return Nothing

        Dim i, j As Integer, forma, obj, dop, index As String
        If uniqName = "" Then Return Nothing
        If uniqName.IndexOf(".") = -1 Then
            If ActiveForm Is Nothing Then Return Nothing
            uniqName = ActiveForm.obj.Props.name & "." & uniqName
        End If
        forma = uniqName.Split(".")(0)
        If uniqName.IndexOf("[") <> -1 Then
            obj = uniqName.Split(".")(1).Split("[")(0)
            index = uniqName.Split(".")(1).Split("[")(1).Split("]")(0)
            index = UbratKovich(index).str
        Else
            obj = uniqName.Split(".")(1)
            index = "0"
        End If
        If obj.IndexOf("(") <> -1 Then
            dop = obj.Split("(")(1).Split(")")(0)
            obj = obj.Split("(")(0)
        End If
        Dim forms() As Object = GetMyFormsFromName(forma)
        If forms Is Nothing Then Return Nothing
        For i = 0 To forms.Length - 1
            For j = 0 To forms(i).MyObjs.Length - 1
                If forms(i).MyObjs(j).obj.Props.name = obj And forms(i).MyObjs(j).obj.Props.index = index Then
                    ' ������������ ���� �� ������� �����������, ���� �� ����������, ���� ��������� �������
                    If Iz.IsDP(forms(i).MyObjs(j)) Then forms(i).MyObjs(j).ActivePanel = dop
                    Return forms(i).MyObjs(j)
                End If
            Next
        Next
        Return Nothing
    End Function


    
   

#End Region

    ' <<<<<<<< ������ � ������� �������� >>>>>>>>>
#Region "VETKI"

    ' ����������� ����� �������, ������� ��� ��������
    Sub CopySobyts(ByVal oldNode As TreeNode, ByVal newNode As TreeNode)
        Dim i, j As Integer, clon As TreeNode
        For i = 0 To oldNode.Nodes.Count - 1
            ' ���� � ����� ����� ������ ������� ���, �� ����������� ���
            If GetNode(oldNode.Nodes(i), newNode) Is Nothing Then
                ' ���� �������� ��������, � ��� ��� ���������, �� �� ���� ���������� ��
                If GetNode(oldNode.Nodes(i), newNode, 1, True) Is Nothing = False Then Continue For
                ' ������� ����� ����������� �����
                clon = CloneTreeNode(oldNode.Nodes(i))
                ' � ���������� � � ����� ����� newNode
                newNode.Nodes.Add(clon)
                UndoRedoTree(True, True, clon)
            Else
                ' ���� � ����� ����� ����� ������� ����, �� ����������� ��� ��� ��������
                If oldNode.Nodes(i).Nodes Is Nothing Then Continue For
                For j = 0 To oldNode.Nodes(i).Nodes.Count - 1
                    ' ������� ����� ����������� �����
                    clon = CloneTreeNode(oldNode.Nodes(i).Nodes(j))
                    ' � ���������� � � ����� ����� newNode
                    GetNode(oldNode.Nodes(i), newNode).Nodes.Add(clon)
                    UndoRedoTree(True, True, clon)
                Next
            End If
        Next
    End Sub

    ' ���� �� � ������ ����� ����� �������
    Function ExistNodeFromText(ByVal text As String, ByVal node As TreeNode) As TreeNode
        Dim i As Integer
        For i = 0 To node.Nodes.Count - 1
            If node.Nodes(i).Text = text Then Return node.Nodes(i)
        Next
        Return Nothing
    End Function

    ' ����������� ������� �������� ����� �����, ������ �� ����� ����������
    Function CloneTreeNode(ByVal Node As TreeNode, Optional ByVal withUniqName As Boolean = True, Optional ByVal clon As TreeNode = Nothing) As TreeNode
        Dim i As Integer
        If Node Is Nothing Then Return Nothing
        ' ���� ������ ����� ��� �� ������, �� ������� ��� �� ������ � ������� Node
        If clon Is Nothing Then
            clon = New TreeNode(Node.Text) : clon.Name = Node.Name : clon.Tag = Node.Tag
            clon.ImageKey = Node.ImageKey : clon.SelectedImageKey = Node.SelectedImageKey
            If clon.Tag <> "Obj" And withUniqName Then clon.Name = GetUIN()
        End If
        ' �������� �� ���� ���������
        For i = 0 To Node.Nodes.Count - 1
            ' �������� ��������������� ��������
            clon.Nodes.Add(Node.Nodes(i).Name, Node.Nodes(i).Text, Node.Nodes(i).ImageKey, Node.Nodes(i).SelectedImageKey)
            clon.Nodes(i).Tag = Node.Nodes(i).Tag
            If clon.Nodes(i).Tag <> "Obj" And withUniqName Then clon.Nodes(i).Name = GetUIN()
            ' ������� ������ ������������ ��� �������� ������� ��������
            CloneTreeNode(Node.Nodes(i), withUniqName, clon.Nodes(i))
        Next
        Return clon
    End Function

    ' ��� ������ � ��������� ����, ����� �������� ���� ������������� �� ����� ����� � ������
    Sub PerebrosatTreeNodes(ByVal newNode As Object, ByVal oldNode As TreeNode, ByVal MyObj As Object)
        ' ������� ����������
        Dim i, j As Integer, clon As TreeNode ' �������� ����� �����
        If newNode Is Nothing Then
            ' ���� ������������� �� ����, �.�. ��������� ����� ��� �������� ��� ���� �������
            If MyObj.nodeTemp Is Nothing = False Then MyObj.AddNode(MyObj.obj.Props.name) : Exit Sub
            If oldNode Is Nothing Then Exit Sub
            MyObj.AddNode(MyObj.obj.Props.name, oldNode.Index)
            newNode = MyObj.GetNode(MyObj.obj.Props.name)
        End If
        If oldNode Is Nothing Then Exit Sub

        Dim newName As String = newNode.Name ' �������� ��������� ��� �������
        Dim oldName As String = oldNode.Name ' �������� ������ ��� �������
        'Dim oldNode As TreeNode = MyObj.GetNode(oldName) ' �������� ������ ����� �������
        'Dim newNode As TreeNode = MyObj.GetNode(newName) ' �������� ��������� ����� �������
        Dim forms() As Object = proj.GetMyFormsFromName(newName) ' ��� ����� � ����� ������ ��� � myForm
        Dim ToRemove() As TreeNode = Nothing ' ������ �� �������� �����

        If UndoRedoNoWrite = False Then
            ' �������� ������� � ����� ����� ������ ����� �����
            For i = 0 To oldNode.Nodes.Count - 1
                Dim ExistNode As TreeNode = GetNode(oldNode.Nodes(i), newNode)
                ' ���� � ����� ����� ������ �������/������� ���, �� ����������� ���
                If ExistNode Is Nothing Then
                    If MyObj.obj.GetType.ToString = ClassAplication & "F" Then
                        ' ���� ������ ������� �� ����� ���
                        If MyObj.ExistName(oldNode.Nodes(i).Name, MyObj.obj) = False Then
                            ' ���� ��� ����� �� ������� ��������� �����, �� ����������� ��� ������
                            If oldNode.Nodes(i).Name = oldName Then
                                CopySobyts(oldNode.Nodes(i), newNode.Nodes(MyObj.obj.Props.Name))
                                UndoRedo("#Union Undos(Redos)", "", "", "")
                            End If
                            Continue For
                        End If
                    End If
                    clon = CloneTreeNode(oldNode.Nodes(i)) ' ������� ����� ����������� �����
                    newNode.Nodes.Add(clon) ' � ���������� � � ����� �����
                    UndoRedoTree(True, True, clon)
                    UndoRedo("#Union Undos(Redos)", "", "", "")
                ElseIf MyObj.obj.GetType.ToString = ClassAplication & "F" Then
                    ' ���� � ����� ����� ����� ������ ��� ����, �� ������� ���� ����� �� ����
                    CopySobyts(oldNode.Nodes(i), newNode.Nodes(oldNode.Nodes(i).Name))
                Else
                    ' ���� � ����� ����� ����� ������� ��� ����, �� �������� ���� ����� �� ����
                    CopySobyts(oldNode.Nodes(i), ExistNode)
                End If
            Next
        End If
        If MyObj.obj.GetType.ToString = ClassAplication & "F" Then
            forms = proj.GetMyFormsFromName(oldName)
            ' ������� �����, ���� ���� � ����� ������ ������ ���
            If forms Is Nothing Then
                ' ���� �������� �� ������ ������ �� ��������
                '  If proj.ExistName(oldName) = False Then
                UndoRedoTree(True, False, MainForm.TreeToArray(oldNode, False))
                If MainForm.TreeToArray(oldNode, False).Length > 0 Then UndoRedo("#Union Undos(Redos)", "", "", "")
                ' ���� ������ �������������
                ' If GetMyAllFromName(newName).Length = 1 Then
                ' �������� �� ������ ��������, � � ��� �� ������ �������� � ������� � ����� ����� ����� �������� �������� ��� � ������
                'For j = 0 To oldNode.Nodes.Count - 1
                '    Dim k As Integer
                '     For k = 0 To oldNode.Nodes(j).Nodes.Count - 1
                '         Dim newOldNode As TreeNode = oldNode.Nodes(j).Nodes(k)
                '         Dim oldNewNode As TreeNode = ExistNodeFromText(oldNode.Nodes(j).Nodes(k).Text, newNode.Nodes(j))
                '         newOldNode.Remove()
                '         newNode.Nodes(j).Nodes.Insert(oldNewNode.Index, newOldNode)
                '         oldNewNode.Remove()
                '      Next
                '   Next
                'Else
                ' �������� ����-� ����� ������ ������ �� ���� ���� ��������
                '  Dim tmp As String : proj.UndoRedoCount = 0
                '  tmp = UndoAr(UndoAr.Length - 1) : ReDim UndoAr(0) : UndoAr(0) = tmp
                '  tmp = RedoAr(RedoAr.Length - 1) : ReDim RedoAr(0) : RedoAr(0) = tmp
                ' End If
                'UndoRedo("#Union Undos(Redos)", "", "", "")
                'MainForm.DeleteTree(True, oldNode)
                oldNode.Remove()
                'UndoRedo("#Union Undos(Redos)", "", "", "")
                'oldNode.Remove()
                ' If MainForm.TreeToArray(oldNode, False).Length > 0 Then UndoRedo("#Union Undos(Redos)", "", "", "")
                'End If
                ' oldNode.Remove()
            Else
                ' ���� � ����� ������ ��� �������� �����, �� ������� �������, ������� �� ��� ���
                Dim fl As Byte, ind As Integer = 0
                For i = 0 To oldNode.Nodes.Count - 1
                    fl = 0
                    ' ����������� ��� ����� �� ������ ������
                    For j = 0 To forms.Length - 1
                        If forms(j).ExistName(oldNode.Nodes(i).Name) Then fl = 1
                    Next
                    ' ���� ������ ������� ��� �� �� ����� �����, � � ������ ����, �� ������� � ������ �� ��������
                    If fl = 0 And oldNode.Nodes(i) Is Nothing = False Then
                        ' ������� � ������ �� ��������
                        ReDim Preserve ToRemove(ind) : ToRemove(ind) = oldNode.Nodes(i) : ind += 1
                    End If
                Next
                ' ������� �����, ���������� � ������ �� ��������
                If ToRemove Is Nothing = False Then
                    For i = 0 To ToRemove.Length - 1
                        UndoRedoTree(True, False, ToRemove(i))
                        ToRemove(i).Remove()
                    Next
                    UndoRedo("#Union Undos(Redos)", "", "", "")
                End If
                ' �������� ����-� ����� ������ ������ �� ���� ���� ��������
                'Dim tmp As String : proj.UndoRedoCount = 0
                'tmp = UndoAr(UndoAr.Length - 1) : ReDim UndoAr(0) : UndoAr(0) = tmp
                'tmp = RedoAr(RedoAr.Length - 1) : ReDim RedoAr(0) : RedoAr(0) = tmp
            End If
        Else
            ' ���� �������� �� ������ ������ �� ��������
            If proj.ExistName(oldName) = False Then
                If oldNode.Tag = "Obj" And oldNode.Name <> MyZnak & "none" Then
                    UndoRedoTree(True, False, MainForm.TreeToArray(oldNode, False))
                    If MainForm.TreeToArray(oldNode, False).Length > 0 Then UndoRedo("#Union Undos(Redos)", "", "", "")
                End If
                ' ���� ������ �������������
                'If GetMyAllFromName(newName).Length = 1 Then
                ' �������� �� ������ �������� � ������� � ����� ����� ����� �������� �������� ��� � ������
                'For j = 0 To oldNode.Nodes.Count - 1
                '   Dim newOldNode As TreeNode = oldNode.Nodes(j)
                '    Dim oldNewNode As TreeNode = ExistNodeFromText(oldNode.Nodes(j).Text, newNode)
                '     newOldNode.Remove()
                '      newNode.Nodes.Insert(oldNewNode.Index, newOldNode)
                '       oldNewNode.Remove()
                '    Next
                ' Else
                ' �������� ����-� ����� ������ ������ �� ���� ���� ��������
                '  Dim tmp As String : proj.UndoRedoCount = 0
                '  tmp = UndoAr(UndoAr.Length - 1) : ReDim UndoAr(0) : UndoAr(0) = tmp
                '  tmp = RedoAr(RedoAr.Length - 1) : ReDim RedoAr(0) : RedoAr(0) = tmp
                'End If
                oldNode.Remove()
            End If
        End If
        ' ���� ������ �� ������ � ������, �� ��������� ��� �������, � ������������ �������, ������� �� ��������
        Dim obs() As Object = GetMyAllFromName(newName)
        If obs Is Nothing = False Then
            If obs.Length = 1 Then
                newNode.ImageKey = MyObj.picture : newNode.SelectedImageKey = newNode.ImageKey
            End If
        End If
        ' �������� �����
        ' newNode.Expand()
    End Sub

#End Region

    ' <<<<<<<< ��������� ���������� >>>>>>>>>
#Region "PODSVETKA"

    Public Function Podsvetka(ByVal str As String) As Boolean
        Dim text As New RichTextBox : text.Text = str : Return Podsvetka(text)
    End Function
    Public Function Podsvetka(ByVal text As RichTextBox, Optional ByVal vsegda As Boolean = False) As Boolean
        Dim ind = -1, i As Integer
        Dim isStr As Boolean = True  ' ��������� true ���� � ������ ��� �������� � ������� (�.�. ��� ������)
        If text Is Nothing Then Return True
        If text.TextLength > 1000 And vsegda = False Then Return True
        ' ��� ��������� ��������� � ��������� RichTextBox, � ������ ������������� RichTextBox ���������
        Dim t As New RichTextBox : t.Multiline = True : t.Text = text.Text
        Dim oldT As New RichTextBox : oldT.Multiline = True : oldT.Rtf = text.Rtf
        Dim start As Integer = text.SelectionStart, len As Integer = text.SelectionLength
        ' �������� ���� ����� ������ �� ���� �� ���������
        RichSelectColor(t, 0, t.TextLength, ColKode)

        ' ���������� ������� (������, ������� � �.�.)
        If bistro_podsvFun = False Then
            For i = 0 To AllFuncs.Length - 1
                ind = -1
                Do
                    If t.Text.Length - ind = 1 Then Exit Do ' ���� ��� ��������� ������, �� ������ ���������� ����� �� �����, ����� ��������
                    ind = t.Find(AllFuncs(i), ind + 1, RichTextBoxFinds.None)
                    If ind = -1 Then Exit Do
                    ' ���� ��� ������� ���� ������ ������� �����
                    If ind > 0 Then If Char.IsLetterOrDigit(t.Text.Chars(ind - 1)) Then ind += 1 : Continue Do
                    If ind + AllFuncs(i).Length < t.Text.Length Then If Char.IsLetterOrDigit(t.Text.Chars(ind + AllFuncs(i).Length)) Then ind += 1 : Continue Do
                    ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                    RichSelectColor(t, ind, AllFuncs(i).Length, ColFunction) : isStr = False
                Loop
            Next
        End If

        ' ���������� ��������������� ���� (����� ������, ������ � �.�.)
        If bistro_podsvHW = False Then
            For i = 0 To AllHW.Length - 1
                ind = -1
                Do
                    If t.Text.Length - ind <= 1 Then Exit Do ' ���� ��� ��������� ������, �� ������ ���������� ����� �� �����, ����� ��������
                    ind = t.Find(AllHW(i), ind + 1, RichTextBoxFinds.None)
                    If ind = -1 Then Exit Do
                    ' ���� ��� ������� ���� ������ ������� �����
                    If ind > 0 Then If Char.IsLetterOrDigit(t.Text.Chars(ind - 1)) Or t.Text.Chars(ind - 1) = "_" Then ind += 1 : Continue Do
                    If ind + AllHW(i).Length < t.Text.Length Then
                        If Char.IsLetterOrDigit(t.Text.Chars(ind + AllHW(i).Length)) Or t.Text.Chars(ind + AllHW(i).Length) = "_" Then ind += 1 : Continue Do
                    End If
                    ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                    RichSelectColor(t, ind, AllHW(i).Length, ColConsts) : isStr = False
                Loop
            Next
        End If

        ' ���������� �������� ����
        If bistro_podsvObs = False Then
            Dim AllObjs = proj.GetAllObjNames.ToArray
            For i = 0 To AllObjs.Length - 1
                ind = -1
                Do
                    If t.Text.Length - ind = 1 Then Exit Do ' ���� ��� ��������� ������, �� ������ ���������� ����� �� �����, ����� ��������
                    ind = t.Find(AllObjs(i), ind + 1, RichTextBoxFinds.None)
                    If ind = -1 Then Exit Do
                    ' ���� ��� ������� ���� ������ ������� �����
                    If ind > 0 Then If Char.IsLetterOrDigit(t.Text.Chars(ind - 1)) Then ind += 1 : Continue Do
                    If ind + AllObjs(i).Length < t.Text.Length Then If Char.IsLetterOrDigit(t.Text.Chars(ind + AllObjs(i).Length)) Then ind += 1 : Continue Do
                    ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                    RichSelectColor(t, ind, AllObjs(i).Length, ColObject) : isStr = False
                    If t.Text.Length - ind = 1 Then Exit Do ' ���� ������ ��������� ������, �� ������ ���������� ����� �� �����, ����� ��������
                Loop
            Next
        End If

        If bistro_podsvPMs = False Then
            ' ���������� ������� ��������
            Dim AllPropertys = proj.GetAllPropNames.ToArray
            For i = 0 To AllPropertys.Length - 1
                ind = -1
                Do
                    If t.Text.Length - ind <= 1 Then Exit Do ' ���� ��� ��������� ������, �� ������ ���������� ����� �� �����, ����� ��������
                    ind = t.Find(AllPropertys(i), ind + 1, RichTextBoxFinds.None)
                    If ind = -1 Then Exit Do
                    ' ���� ��� ������� ���� ������ ������� �����
                    If ind > 0 Then If Char.IsLetterOrDigit(t.Text.Chars(ind - 1)) Then ind += 1 : Continue Do
                    If ind + AllPropertys(i).Length < t.Text.Length Then If Char.IsLetterOrDigit(t.Text.Chars(ind + AllPropertys(i).Length)) Then ind += 1 : Continue Do
                    ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                    RichSelectColor(t, ind, AllPropertys(i).Length, ColProperty) : isStr = False
                    If t.Text.Length - ind = 1 Then Exit Do ' ���� ������ ��������� ������, �� ������ ���������� ����� �� �����, ����� ��������
                Loop
            Next
            ' ���������� ������� ��������
            Dim AllMethods = proj.GetAllMethNames.ToArray
            For i = 0 To AllMethods.Length - 1
                ind = -1
                Do
                    If t.Text.Length - ind = 1 Then Exit Do ' ���� ��� ��������� ������, �� ������ ���������� ����� �� �����, ����� ��������
                    ind = t.Find(AllMethods(i), ind + 1, RichTextBoxFinds.None)
                    If ind = -1 Then Exit Do
                    ' ���� ��� ������� ���� ������ ������� �����
                    If ind > 0 Then If Char.IsLetterOrDigit(t.Text.Chars(ind - 1)) Then ind += 1 : Continue Do
                    If ind + AllMethods(i).Length < t.Text.Length Then If Char.IsLetterOrDigit(t.Text.Chars(ind + AllMethods(i).Length)) Then ind += 1 : Continue Do
                    ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                    RichSelectColor(t, ind, AllMethods(i).Length, ColMethod) : isStr = False
                    If t.Text.Length - ind = 1 Then Exit Do ' ���� ������ ��������� ������, �� ������ ���������� ����� �� �����, ����� ��������
                Loop
            Next
        End If


        ' ���� �������, � ������ �� ��� ������
        If bistro_podsvKov = False Then
            Dim kovi4ka1, kovi4ka2 As Integer
            kovi4ka1 = t.Find("""", 0, RichTextBoxFinds.None)
            ' ������������� ��� ������������� �������
            While kovi4ka1 <> -1
                ' ���� ������������� �������
                kovi4ka2 = t.Find("""", kovi4ka1 + 1, RichTextBoxFinds.None)
                ' ���� ����� ������� ���� ��� �����
                If kovi4ka2 + 1 < t.TextLength - 1 Then
                    ' ���� ��� ��� ������ �������, �� ���� ���������
                    While t.Text.Chars(kovi4ka2 + 1) = """"
                        kovi4ka2 = t.Find("""", kovi4ka2 + 2, RichTextBoxFinds.None)
                        If kovi4ka2 + 1 >= t.TextLength - 1 Or kovi4ka2 = -1 Then Exit While
                    End While
                End If
                ' ���� ������ ������� ������� �������
                If kovi4ka2 <= kovi4ka1 Then Exit While
                ' ����������� ���� ����� � �������� ������ � ���������
                RichSelectColor(t, kovi4ka1, kovi4ka2 - kovi4ka1 + 1, ColKovi4ki, oldT)
                ' ���� ������� �� ���� �� ������ ������, �� ����� ���������
                If kovi4ka2 + 1 >= t.TextLength - 1 Then Exit While
                kovi4ka1 = t.Find("""", kovi4ka2 + 1, RichTextBoxFinds.None)
            End While
        End If

        text.Tag = "obrabotka" : text.Visible = False
        text.Rtf = t.Rtf : text.SelectionStart = start : text.SelectionLength = len
        text.Visible = True : text.Tag = Nothing
        text.Focus()

        Return isStr
    End Function
    Function isStr(ByVal str As String) As Boolean
        ' ���� �������, � ������ �� ��� ������
        Dim kovi4ka1, kovi4ka2 As Integer
        Do
            ' ������������� ��� ������������� �������
            kovi4ka1 = str.IndexOf("""")
            If kovi4ka1 = -1 Then Exit Do
            ' ���� ������������� �������
            kovi4ka2 = str.IndexOf("""", kovi4ka1 + 1)
            ' ���� ����� ������� ���� ��� �����
            If kovi4ka2 + 1 < str.Length - 1 Then
                ' ���� ��� ��� ������ �������, �� ���� ���������
                While str.Chars(kovi4ka2 + 1) = """"
                    kovi4ka2 = str.IndexOf("""", kovi4ka2 + 2)
                    If kovi4ka2 + 1 >= str.Length - 1 Or kovi4ka2 = -1 Then Exit While
                End While
            End If
            ' ���� ������ ������� ������� �������
            If kovi4ka2 <= kovi4ka1 Then Exit Do
            ' ������� ���� ����� � �������� ������ � ���������
            str = str.Substring(0, kovi4ka1) & str.Substring(kovi4ka2 + 1)
        Loop
        str = Trim(str) : str = LCase(str)
        If str = "" Then Return True

        ' �������� �� ��������������� ���������
        Dim ind = -1, fl = 0, i As Integer
        For i = 0 To AllHW.Length - 1
            Do
                ind = str.IndexOf(LCase(AllHW(i)), ind + 1)
                If ind = -1 Then Exit Do
                If ind + AllHW(i).Length = str.Length Then fl += 1
                If ind = 0 Then fl += 1
                If ind > 0 Then ' ���� ������ �� �������� ������ - ����������
                    ' ����� ���� �� �����������(������, �������), ������ ��� �� ������
                    If Char.IsLetterOrDigit(str(ind - 1)) = False Then fl += 1
                End If
                If ind + AllHW(i).Length + 1 < str.Length Then ' ���� ������ ����� �������� ������ - ����������
                    ' ����� ���� �� �����������(������, �������), ������ ��� �� ������
                    If Char.IsLetterOrDigit(str(ind + AllHW(i).Length + 1)) = False Then fl += 1
                End If
                If fl >= 2 Then Return False Else fl = 0
            Loop
        Next

        ' �������� �� ��, ��� ��� �����
        If Iz.isDouble(str) Then Return False

        Return True
    End Function


    ' ��������� ���������� � ������� text (���������� true ���� � ������ ��� �������� � �������)
    Public Function Podsvetka2(ByVal text As RichTextBox) As Boolean

        Dim cm
        ' �������� ������������ ���� ��������
        Dim cmItem, cmMassiv As ToolStripMenuItem, cmSeparat As ToolStripSeparator
        'cm = New ContextMenuStrip : AddHandler cm.Opening, AddressOf proj.cm_Opening
        ' �������
        cmSeparat = New ToolStripSeparator() : cmSeparat.Name = "MassiveUp" : cm.Items.Add(cmSeparat)

        cmItem = New ToolStripMenuItem(trans("������� ������")) : cmItem.Name = cmItem.Text
        cmItem.ToolTipText = trans("����������� ��������� ����� ������. ����������� ��� ����� �� ��������.")
        ' cm.Items.Add(cmItem) : AddHandler cmItem.Click, AddressOf proj.MassiveCreate_Click

        cmItem = New ToolStripMenuItem(trans("������� ���������")) : cmItem.Name = cmItem.Text
        cmItem.ToolTipText = trans("������� ������, � ��� ������������ �������.")
        ' cm.Items.Add(cmItem) : AddHandler cmItem.Click, AddressOf proj.podMassiveCreate_Click

        cmMassiv = New ToolStripMenuItem(trans("������ � ���������")) : cmMassiv.Name = cmMassiv.Text
        cmMassiv.ToolTipText = trans("������� ��� �������� �������������� ����� ��������.")
        cm.Items.Add(cmMassiv)

        cmItem = New ToolStripMenuItem(trans("���������� � ����������")) : cmItem.Name = cmItem.Text
        cmItem.ToolTipText = trans("���������� ������� � ����� ������� �������.")
        '  cmMassiv.DropDownItems.Add(cmItem) : AddHandler cmItem.Click, AddressOf proj.podMassiveUnited_Click

        cmItem = New ToolStripMenuItem(trans("�������� ������")) : cmItem.Name = cmItem.Text
        cmItem.ToolTipText = trans("��������� ��� �������, � �������� ������ ������ ��������� � �������.")
        '  cmMassiv.DropDownItems.Add(cmItem) : AddHandler cmItem.Click, AddressOf proj.MassiveSelect_Click

        cmItem = New ToolStripMenuItem(trans("�������� ���������")) : cmItem.Name = cmItem.Text
        cmItem.ToolTipText = trans("��������� ��� �������, � �������� ������ ������ ��������� � ����������.")
        '  cmMassiv.DropDownItems.Add(cmItem) : AddHandler cmItem.Click, AddressOf proj.podMassiveSelect_Click

        cmItem = New ToolStripMenuItem(trans("�������� � ������")) : cmItem.Name = cmItem.Text
        cmItem.ToolTipText = trans("�������� ������ � ��� ������������ ������.")
        cmMassiv.DropDownItems.Add(cmItem)

        cmItem = New ToolStripMenuItem(trans("��������� �� �������")) : cmItem.Name = cmItem.Text
        cmItem.ToolTipText = trans("������� ���������� ����� ���, � ��������� ������.")
        '   cmMassiv.DropDownItems.Add(cmItem) : AddHandler cmItem.Click, AddressOf proj.MassiveExecute_Click
        ' ��������������
        cmSeparat = New ToolStripSeparator() : cmSeparat.Name = "EditUp" : cm.Items.Add(cmSeparat)

        cmItem = New ToolStripMenuItem(trans("���������")) : cmItem.Name = cmItem.Text
        cmItem.ToolTipText = trans("����������� �� ������ ������-���������.")
        cm.Items.Add(cmItem)







        Dim i, wasEdit As Integer
        Dim isStr As Boolean = True  ' ��������� true ���� � ������ ��� �������� � ������� (�.�. ��� ������)
        ' ��� ��������� ��������� � ��������� RichTextBox, � ������ ������������� RichTextBox ���������
        Dim t As New RichTextBox : t.Text = text.Text
        Dim oldT As New RichTextBox : oldT.Rtf = text.Rtf
        Dim start As Integer = text.SelectionStart, len As Integer = text.SelectionLength
        ' �������� ���� ���� �� ���� �� ���������
        RichSelectColor(t, 0, t.TextLength, ColKode)
        ' t.SelectAll() : t.SelectionColor = ColKode

        ' ���� ������, � ����� �� ��� ��� �������
        Dim skobka As Integer
        skobka = t.Find("(", 0, RichTextBoxFinds.None)
        If skobka = -1 Then skobka = t.TextLength
        ' ������������� ��� ������������� ������
        While skobka <> -1
            ' ���� ����� �� ������ ��� �������
            For i = skobka - 1 To 0 Step -1
                'Try
                ' ���� ������� ������ ����������� (������, ������� � �.�.)
                If Char.IsLetterOrDigit(t.Text.Chars(i)) = False Then
                    ' �� ������ ���� ������ ��� �� 0 ��������
                    If skobka - i - 1 > 0 Then
                        ' ���� ����� ������� ����������
                        Dim funS As String = proj.isFunction(t.Text.Substring(i + 1, skobka - i - 1))
                        If funS <> "" Then
                            If funS <> t.Text.Substring(i + 1, skobka - i - 1) Then
                                t.Text = t.Text.Substring(0, i + 1) & funS & t.Text.Substring(i + 1 + funS.Length)
                            End If
                            ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                            wasEdit += RichSelectColor(t, i + 1, skobka - i - 1, ColFunction, oldT) : isStr = False : Exit For
                        End If
                    End If
                End If
                If i = 0 Then
                    ' ���� ����� �� ������ ������, ��������� ���� �� �� ������ ��� �������
                    Dim funS As String = proj.isFunction(t.Text.Substring(i, skobka))
                    If funS <> "" Then
                        If funS <> t.Text.Substring(i, skobka) Then
                            t.Text = funS & t.Text.Substring(funS.Length)
                        End If
                        ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                        wasEdit += RichSelectColor(t, i, skobka, ColFunction, oldT) : isStr = False : Exit For
                    End If
                End If
                'Catch ex As Exception
                'End Try
            Next
            ' ���� ������ �� ���� �� ������ ������, �� ����� ���������
            If t.TextLength > skobka + 1 Then
                skobka = t.Find("(", skobka + 1, RichTextBoxFinds.None)
            Else
                skobka = -1
            End If
        End While

        ' ���� �����, � ����� �� ��� ��� �������, ������ - �������� ��������
        Dim to4ka As Integer
        to4ka = t.Find(".", 0, RichTextBoxFinds.None)
        ' ������������� ��� �����
        While to4ka <> -1
            ' ���� ����� �� ����� ��� �������
            For i = to4ka To 0 Step -1
                'Try
                ' ���� ������� ������ ����������� (������, ������� � �.�.)
                If Char.IsLetterOrDigit(t.Text.Chars(i)) = False Then
                    ' �� ����� ���� ������ ��� �� 0 ��������
                    If to4ka - i - 1 > 0 Then
                        ' ���� ����� ������ ����
                        Dim obS As String = proj.isObject(t.Text.Substring(i + 1, to4ka - i - 1))
                        If obS <> "" Then
                            If obS <> t.Text.Substring(i + 1, to4ka - i - 1) Then
                                t.Text = t.Text.Substring(0, i + 1) & obS & t.Text.Substring(i + 1 + obS.Length)
                            End If
                            ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                            wasEdit += RichSelectColor(t, i + 1, to4ka - i - 1, ColObject, oldT) : isStr = False : Exit For
                        End If
                    End If
                End If
                If i = 0 Then
                    ' ���� ����� �� ������ ������, ��������� ���� �� �� ����� ��� �������
                    Dim obS As String = proj.isObject(t.Text.Substring(i, to4ka))
                    If obS <> "" Then
                        If obS <> t.Text.Substring(i, to4ka) Then
                            t.Text = t.Text.Substring(0, i) & obS & t.Text.Substring(i + obS.Length)
                        End If
                        ' ����������� ��� �������, � ����������, ��� ��� ��� �� ������ ������
                        wasEdit += RichSelectColor(t, i, to4ka, ColObject, oldT) : isStr = False : Exit For
                    End If
                End If
                'Catch ex As Exception
                'End Try
            Next
            ' ���� ������ �� ����� �������� ��������
            For i = to4ka + 1 To t.TextLength - 1
                'Try
                ' ���� ������� ������ ����������� (������, ������� � �.�.)
                If Char.IsLetterOrDigit(t.Text.Chars(i)) = False Then
                    ' �� ����� ���� ������ ��� �� 0 ��������
                    If i - to4ka - 1 > 0 Then
                        ' ���� ����� �������� ����������
                        Dim prS As String = proj.isProperty(t.Text.Substring(to4ka + 1, i - to4ka - 1))
                        If prS <> "" Then
                            If prS <> t.Text.Substring(to4ka + 1, i - to4ka - 1) Then
                                t.Text = t.Text.Substring(0, to4ka + 1) & prS & t.Text.Substring(to4ka + 1 + prS.Length)
                            End If
                            ' ����������� �������� ��������, � ����������, ��� ��� ��� �� ������ ������
                            wasEdit += RichSelectColor(t, to4ka + 1, i - to4ka - 1, ColProperty, oldT) : isStr = False : Exit For
                        End If
                    End If
                End If
                If i = t.TextLength - 1 Then
                    ' ���� ����� �� ����� ������, ��������� ���� �� �� ����� �������� ��������
                    Dim prS As String = proj.isProperty(t.Text.Substring(to4ka + 1, i - to4ka))
                    If prS <> "" Then
                        If prS <> t.Text.Substring(to4ka + 1, i - to4ka) Then
                            t.Text = t.Text.Substring(0, to4ka + 1) & prS & t.Text.Substring(to4ka + 1 + prS.Length)
                        End If
                        ' ����������� �������� ��������, � ����������, ��� ��� ��� �� ������ ������
                        wasEdit += RichSelectColor(t, to4ka + 1, i - to4ka, ColProperty, oldT) : isStr = False : Exit For
                    End If
                End If
                If t.Text.Chars(i) = "." Then Exit For
                'Catch ex As Exception
                'End Try
            Next
            ' ���� ����� �� ���� �� ������ ������, �� ����� ���������
            If to4ka + 1 < t.TextLength Then
                to4ka = t.Find(".", to4ka + 1, RichTextBoxFinds.None)
            Else
                to4ka = -1
            End If
        End While



        ' ���� �������, � ������ �� ��� ������
        Dim kovi4ka1, kovi4ka2 As Integer
        kovi4ka1 = t.Find("""", 0, RichTextBoxFinds.None)
        ' ������������� ��� ������������� �������
        While kovi4ka1 <> -1
            ' ���� ������������� �������
            kovi4ka2 = t.Find("""", kovi4ka1 + 1, RichTextBoxFinds.None)
            ' ���� ����� ������� ���� ��� �����
            If kovi4ka2 + 1 < t.TextLength - 1 Then
                ' ���� ��� ��� ������ �������, �� ���� ���������
                While t.Text.Chars(kovi4ka2 + 1) = """"
                    kovi4ka2 = t.Find("""", kovi4ka2 + 2, RichTextBoxFinds.None)
                    If kovi4ka2 + 1 >= t.TextLength - 1 Or kovi4ka2 = -1 Then Exit While
                End While
            End If
            ' ���� ������ ������� ������� �������
            If kovi4ka2 <= kovi4ka1 Then Exit While
            ' ����������� ���� ����� � �������� ������ � ���������
            wasEdit += RichSelectColor(t, kovi4ka1, kovi4ka2 - kovi4ka1 + 1, ColKovi4ki, oldT)
            ' ���� ������� �� ���� �� ������ ������, �� ����� ���������
            If kovi4ka2 + 1 >= t.TextLength - 1 Then Exit While
            kovi4ka1 = t.Find("""", kovi4ka2 + 1, RichTextBoxFinds.None)
        End While

        ' �������� �� ����� ������. ���� ���, �� ����� ��� �� ������ (isStr = False) 
        Dim fl As Integer = 0
        For i = 0 To text.TextLength - 1
            If Char.IsDigit(text.Text(i)) = False And text.Text(i) <> "(" And text.Text(i) <> ")" And text.Text(i) <> "." Then fl = 1
        Next
        If fl = 0 Then isStr = False

        'If text.Rtf.Substring(text.Rtf.IndexOf("\viewkind4\")) <> t.Rtf.Substring(t.Rtf.IndexOf("\viewkind4\")) Then

        ' ������� ���������������� ����� � �������� RichTextBox
        Dim m As System.Text.RegularExpressions.Match, result1, result2 As String, ind1, ind2 As Integer
        wasEdit = 0
        'Do
        ' m = System.Text.RegularExpressions.Regex.Match(t.Rtf.Substring(ind1), "\\cf[^ ]*( |\\')([^\\]|\\( |')|(\\par[^\\]*\\))*")
        ' ind1 += m.Index + m.Length - 1
        ' result = m.Value
        ' m = System.Text.RegularExpressions.Regex.Match(text.Rtf.Substring(ind2), "\\cf[^ ]*( |\\')([^\\]|\\( |')|(\\par[^\\]*\\))*")
        ' ind2 += m.Index + m.Length - 1
        'If m.Value = "" And result = "" Then Exit Do
        'If result <> m.Value Then wasEdit = 1 : Exit Do
        'Loop
        ind1 = t.Rtf.IndexOf("\viewkind")
        ind2 = text.Rtf.IndexOf("\viewkind")
        Dim str As String = System.Text.RegularExpressions.Regex.Replace(text.Rtf.Substring(ind2), "\\(f1 )*", "\\'")
        result1 = System.Text.RegularExpressions.Regex.Replace(t.Rtf.Substring(ind1), "\\(c[^f]|[^cp' ]|cf0)*", "")
        'result1 = System.Text.RegularExpressions.Regex.Replace(t.Rtf.Substring(ind1), "\\[^cp' ]*", "")
        result2 = System.Text.RegularExpressions.Regex.Replace(text.Rtf.Substring(ind2), "\\(c[^f]|[^cp' ]|cf0)*", "")
        'If wasEdit = 0 Then
        '    For i = 0 To t.TextLength - 1
        '        t.SelectionStart = 10 : t.SelectionLength = 20 't.TextLength
        '        oldT.SelectionStart = 10 : oldT.SelectionLength = 20 't.TextLength
        '        If t.SelectedRtf <> oldT.SelectedRtf Then wasEdit = 1 : Exit For
        '    Next
        'End If

        If result1.Length + 1 <> result2.Length Then text.Rtf = t.Rtf : text.SelectionLength = len : text.SelectionStart = start
        ' ������� true ���� ���������� ������� ��� �������
        Return isStr
    End Function

    ' ���������, �������� �� name ������ �������
    Function isObject(ByVal name As String) As String
        If proj.f Is Nothing Then Return False
        Dim i, j As Integer
        ' ��������� ������� ���� �� �� �� ����� �� �����
        name = Trim(UCase(name))
        If name.IndexOf("(") <> -1 Then name = Left(name, name.IndexOf("("))
        For i = 0 To proj.f.Length - 1
            ' ���� ������� ����� � ����� ������
            If UCase(proj.f(i).obj.Props.name) = name Then Return proj.f(i).obj.Props.name
            If proj.f(i).MyObjs Is Nothing Then Return False
            For j = 0 To proj.f(i).MyObjs.Length - 1
                ' ���� � ������� ������ ���
                If UCase(proj.f(i).MyObjs(j).obj.Props.name) = name Then Return proj.f(i).MyObjs(j).obj.Props.name
            Next
        Next
        Return ""
    End Function
    ' �������� ��� �������
    Function GetAllObjs() As ArrayList
        Dim arr As New ArrayList
        If proj.f Is Nothing Then Return Nothing
        Dim i, j As Integer
        For i = 0 To proj.f.Length - 2
            If proj.f(i).MyObjs Is Nothing = False Then
                For j = 0 To proj.f(i).MyObjs.Length - 1
                    arr.Add(proj.f(i).MyObjs(j))
                Next
            End If
        Next
        Return arr
    End Function
    ' �������� ��� ����� �������
    Function GetAllObjNames() As ArrayList
        Dim arr As New ArrayList
        If proj.f Is Nothing Then Return Nothing
        Dim i, j As Integer
        For i = 0 To proj.f.Length - 1
            arr.Add(proj.f(i).obj.Props.name)
            If proj.f(i).MyObjs Is Nothing = False Then
                For j = 0 To proj.f(i).MyObjs.Length - 1
                    arr.Add(proj.f(i).MyObjs(j).obj.Props.name)
                    If Iz.IsCM(proj.f(i).MyObjs(j)) Then arr.Add(MyZnak & trans("������") & " " & proj.f(i).MyObjs(j).obj.Props.name)
                Next
            End If
        Next
        arr.Add(MyZnak & trans("���� �������"))
        arr.Add(MyZnak & trans("������ �������"))
        Return arr
    End Function
    ' �������� ��� ��������� �������
    Function GetAllPropNames(Optional ByVal bezPoleznih As Boolean = False, Optional ByVal includeReadOnly As Boolean = True) As ArrayList
        Dim arr, arrUp As New ArrayList
        If proj.f Is Nothing Then Return Nothing
        Dim i, j, z As Integer
        For i = 0 To proj.f.Length - 1 - Convert.ToByte(bezPoleznih)
            ' ����������� �� ���� ��������� �����
            'For z = 0 To proj.f(i).Propertys.Length - 1
            ' If arr.IndexOf(proj.f(i).PropertysUp(z)) = -1 Then arr.Add(proj.f(i).Propertys(z))
            'Next
            If proj.f(i).MyObjs Is Nothing Then Continue For
            ' ����������� �� ���� �������� �����
            For j = 0 To proj.f(i).MyObjs.Length - 1
                ' ����������� �� ���� ��������� �������
                If proj.f(i).MyObjs(j).Propertys Is Nothing = False Then
                    For z = 0 To proj.f(i).MyObjs(j).Propertys.Length - 1
                        ' ���� ������� ������ �������� � ������� 
                        If arrUp.IndexOf(proj.f(i).MyObjs(j).PropertysUp(z)) = -1 Then
                            arrUp.Add(proj.f(i).MyObjs(j).Propertysup(z))
                            arr.Add(proj.f(i).MyObjs(j).Propertys(z))
                        End If
                    Next
                End If
            Next
        Next
        Dim sobytObj As Sobitiya = GetSobytObj(MyZnak & "All")
        ' ����������� �� ���� �������� ���������, ������� ��������
        For i = 0 To sobytObj.Propertys.Length - 1
            If includeReadOnly Or Array.IndexOf(SobytsNotReadOnly, sobytObj.PropertysUp(i)) <> -1 Then
                If arrUp.IndexOf(sobytObj.PropertysUp(i)) = -1 Then
                    arrUp.Add(sobytObj.PropertysUp(i))
                    arr.Add(sobytObj.Propertys(i))
                End If
            End If
        Next
        Return arr
    End Function
    ' ���������, �������� �� prop ��������� ��������
    Function GetAllMethNames(Optional ByVal bezPoleznih As Boolean = False) As ArrayList
        Dim arr, arrUp As New ArrayList
        If proj.f Is Nothing Then Return Nothing
        Dim i, j, z As Integer
        For i = 0 To proj.f.Length - 1 - Convert.ToByte(bezPoleznih)
            If proj.f(i).MyObjs Is Nothing Then Continue For
            ' ����������� �� ���� �������� �����
            For j = 0 To proj.f(i).MyObjs.Length - 1
                ' ����������� �� ���� ������� �������
                If proj.f(i).MyObjs(j).Methods Is Nothing = False Then
                    For z = 0 To proj.f(i).MyObjs(j).Methods.Length - 1
                        ' ���� ������� ������ �������� � ������� 
                        If arrUp.IndexOf(proj.f(i).MyObjs(j).MethodsUp(z)) = -1 Then
                            arrUp.Add(proj.f(i).MyObjs(j).MethodsUp(z))
                            arr.Add(proj.f(i).MyObjs(j).Methods(z))
                        End If
                    Next
                End If
            Next
        Next
        'Dim sobytObj As Other = GetSobytObj(MyZnak & "All")
        ' ����������� �� ���� �������� ���������, ������� ��������
        'For i = 0 To sobytObj.Methods.Length - 1
        ' If arr.IndexOf(sobytObj.MethodsUp(i)) = -1 Then arr.Add(sobytObj.MethodsUp(i))
        ' Next
        Return arr
    End Function
    ' ���������, �������� �� prop ��������� ��������
    Function isProperty(ByVal prop As String) As String
        If proj.f Is Nothing Then Return False
        Dim i, j, z As Integer
        ' ��������� ������� ���� �� �� �� ����� �� �����
        prop = Trim(UCase(prop))
        For i = 0 To proj.f.Length - 1
            ' ����������� �� ���� ��������� �����
            'For z = 0 To proj.f(i).Propertys.Length - 1
            '    ' ���� ������� �������� � ����� � ����� �� ���������
            '    If proj.f(i).PropertysUp(z) = prop Then Return proj.f(i).Propertys(z)
            'Next
            If proj.f(i).MyObjs Is Nothing Then Return False
            ' ����������� �� ���� �������� �����
            For j = 0 To proj.f(i).MyObjs.Length - 1
                ' ����������� �� ���� ��������� �������
                If proj.f(i).MyObjs(j).Propertys Is Nothing = False Then
                    For z = 0 To proj.f(i).MyObjs(j).Propertys.Length - 1
                        ' ���� ������� ������ �������� � ������� 
                        If proj.f(i).MyObjs(j).PropertysUp(z) = prop Then Return proj.f(i).MyObjs(j).Propertys(z)
                    Next
                End If
            Next
        Next
        Dim sobytObj As Sobitiya = GetSobytObj(MyZnak & "All")
        ' ����������� �� ���� �������� ���������, ������� ��������
        For i = 0 To sobytObj.Propertys.Length - 1
            If sobytObj.PropertysUp(i) = prop Then Return sobytObj.Propertys(i)
        Next
        Return ""
    End Function
    ' ���������, �������� �� prop ��������� �������� ��� ������
    Function isPropertyMethod(ByVal prop As String) As String
        If proj.f Is Nothing Then Return False
        Dim i, j, z As Integer
        ' ��������� ������� ���� �� �� �� ����� �� �����
        prop = Trim(UCase(prop))
        For i = 0 To proj.f.Length - 1
            If proj.f(i).MyObjs Is Nothing Then Return False
            ' ����������� �� ���� �������� �����
            For j = 0 To proj.f(i).MyObjs.Length - 1
                ' ����������� �� ���� ��������� �������
                If proj.f(i).MyObjs(j).Propertys Is Nothing = False Then
                    For z = 0 To proj.f(i).MyObjs(j).Propertys.Length - 1
                        ' ���� ������� ������ �������� � ������� 
                        If proj.f(i).MyObjs(j).PropertysUp(z) = prop Then Return proj.f(i).MyObjs(j).Propertys(z)
                    Next
                End If
                ' ����������� �� ���� ������� �������
                If proj.f(i).MyObjs(j).Methods Is Nothing = False Then
                    For z = 0 To proj.f(i).MyObjs(j).Methods.Length - 1
                        ' ���� ������� ������ �������� � ������� 
                        If proj.f(i).MyObjs(j).MethodsUp(z) = prop Then Return proj.f(i).MyObjs(j).Methods(z)
                    Next
                End If
            Next
        Next
        Dim sobytObj As Sobitiya = GetSobytObj(MyZnak & "All")
        ' ����������� �� ���� �������� ���������, ������� ��������
        For i = 0 To sobytObj.Propertys.Length - 1
            If sobytObj.PropertysUp(i) = prop Then Return sobytObj.Propertys(i)
        Next
        Return ""
    End Function

    ' ���������, �������� �� prop ������ �������
    Function isFunction(ByVal prop As String) As String
        Dim i As Integer
        ' ��������� ������� ���� �� �� �� ����� �� �����
        prop = Trim(UCase(prop))
        For i = 0 To AllFuncs.Length - 1
            If prop = UCase(AllFuncs(i)) Then Return AllFuncs(i)
        Next
        Return ""
    End Function

    ' ������������� �����, �������� �����������
    Function RichSelectColor(ByVal t As RichTextBox, ByVal start As Integer, ByVal len As Integer, ByVal col As Color, Optional ByVal oldT As RichTextBox = Nothing) As Integer
        t.SelectionStart = start : t.SelectionLength = len : t.SelectionColor = col
        If oldT Is Nothing = False Then
            oldT.SelectionStart = start : oldT.SelectionLength = len
            If oldT.SelectionColor = col Then Return 0
        End If
        Return 1
    End Function

    ' ���������, �������� �� text �������, ��� ��� ��� ��������� � ��������� � ���������
    Public Function isString(ByVal text As String) As Boolean
        Dim richText As New RichTextBox
        richText.Text = text
        ' ���� �������� ������ ������� ��� �������, ��� �� ���������
        Return Podsvetka(richText)
    End Function

    Function PodshetSkobok(ByVal str As String) As Integer
        Dim code As New CodeString(str, "None")
        Dim openS, closeS, skobs As Integer
        openS = code.IndexOf("(")
        While openS <> -1
            skobs += 1
            openS = code.IndexOf("(", openS + 1)
        End While
        closeS = code.IndexOf(")")
        While closeS <> -1
            skobs -= 1
            closeS = code.IndexOf(")", closeS + 1)
        End While
        Return skobs
    End Function

#End Region

    ' <<<<<<<< ��������� ���� � �������� >>>>>>>>>
#Region "GETMYOBJ"

    ' �������� ����� ����� ���
    Function GetMyFormsFromName(ByVal name As Object, Optional ByVal index As String = "") As Object()
        Dim ind = 0, i As Integer, Massive() As Object = Nothing
        If proj.f Is Nothing Then Return Nothing
        ' ���� �� ����� � ����� ������
        For i = 0 To proj.f.Length - 1
            If proj.f(i) Is Nothing Then Continue For
            ' ���� � ������� ������ ���, � �� �������� ��� �����, �.�. ������ ������
            If UCase(proj.f(i).obj.Props.name) = UCase(name) And proj.f(i).obj.Props.index.indexof(index) = 0 Then
                ReDim Preserve Massive(ind) : Massive(ind) = proj.f(i) : ind += 1
            End If
        Next
        If UCase(name) = UCase(MyZnak & trans("���� �������")) Then
            ReDim Massive(0) : Massive(0) = New Forms(True)
            Massive(0).obj.props.name = MyZnak & trans("���� �������")
            Massive(0).MyObjs = proj.GetAllObjs.ToArray
        End If
        Return Massive
    End Function

    ' �������� ��� ���������� � ����� ������
    Function GetMyAllFromName(ByVal name As Object, Optional ByVal index As String = "", Optional ByVal formName As String = "", Optional ByVal includeReadOnly As Boolean = True) As Object()
        ' ������� ������� � ����� ������
        Dim ind As Integer = 0, i, j As Integer
        Dim Massive() As Object = Nothing, Forms() As Object = Nothing
        If proj.f Is Nothing Then Return Nothing
        ' ���� ����� ������, �� ������ � ���, ����� � ����� � ������ name
        If formName <> "" Then
            Forms = GetMyFormsFromName(formName)
        Else
            Forms = GetMyFormsFromName(name, index)
        End If
        ' ���� ����� � ������ name ���, �� ������� �������� �����
        If Forms Is Nothing Then
            If ActiveForm Is Nothing Then Return Massive
            Forms = GetMyFormsFromName(ActiveForm.obj.Props.name)
        End If
        If Forms Is Nothing Then Return Nothing
        For i = 0 To Forms.Length - 1
            If Forms(i).MyObjs Is Nothing Then Return Nothing
            For j = 0 To Forms(i).MyObjs.Length - 1
                ' ���� � ������� ������ ���, � �� �������� ��� �����
                If (UCase(Forms(i).MyObjs(j).obj.Props.name) = UCase(name) Or name = "") And Forms(i).MyObjs(j).obj.Props.index.indexof(index) = 0 Then
                    ReDim Preserve Massive(ind) : Massive(ind) = Forms(i).MyObjs(j) : ind += 1
                End If
            Next
        Next
        If name <> "" Then
            If UCase(name) = UCase(MyZnak & trans("������ �������")) _
                   Or UCase(name).IndexOf(UCase(MyZnak & trans("������") & " ")) = 0 Then
                ReDim Massive(0) : Massive(0) = New Button(True)
                Massive(0).obj.props.name = MyZnak & trans("������ �������")
                Massive(0).Propertys = proj.GetAllPropNames(True, includeReadOnly).ToArray("".GetType)
                Massive(0).Methods = proj.GetAllMethNames(True).ToArray("".GetType)
                CreatePropertySobytsUp(Massive(0))
            ElseIf UCase(name) = UCase(MyZnak & trans("���� �������")) Then
                ReDim Massive(0) : Massive(0) = New Forms(True)
                Massive(0).obj.props.name = MyZnak & trans("���� �������")
                If includeReadOnly Then
                    Dim mass() As String = New Sobitiya(MyZnak & "All").Propertys
                    If mass Is Nothing = False Then
                        Dim props() As String = Massive(0).Propertys
                        ReDim Preserve props(Massive(0).Propertys.length + mass.Length - 1)
                        Array.Copy(mass, 0, props, Massive(0).Propertys.Length, mass.Length)
                        Massive(0).Propertys = props
                    End If
                    CreatePropertySobytsUp(Massive(0))
                End If
            End If
        End If
        Return Massive
    End Function

 

    ' ���������� ��� ������� ������� ���� ������ MyObj
    Function GetDo4ernieMyObjs(ByVal ParamArray MyObj() As Object) As Object()
        Dim i, j As Integer, MyObjs(), ContObjs() As Object
        If MyObj Is Nothing Then Return Nothing
        ' �������� ��� ������� ������� ���� ������ MyObj � ���� ������ MyObjs
        For i = 0 To MyObj.Length - 1
            ' ����������� ���� �������� ������� ���� ����������
            If Iz.isPanel(MyObj(i).obj) Then
                ' ���� ���� �� ��������� ��������, �� �������� ���������� � ��� ���������� ��������
                ContObjs = proj.GetMyObjsFromConteiner(MyObj(i))
            ElseIf Iz.isSostObj(MyObj(i).obj) Then
                ' ���� ��������� ��������� ������, �� �� ���� � �������� ��� ������ ������� ������. ��� ���������� ������� ����.
                If MyObj(i).VstavkaOrCreate = True Then
                    ReDim ContObjs(0) : ContObjs(0) = MyObj(i)
                Else
                    ContObjs = proj.GetMyObjsFromConteiner(MyObj(i))
                End If
            Else
                ReDim ContObjs(0) : ContObjs(0) = MyObj(i)
            End If
            ' ����������� ��� ������� ��� ����������� � ���� ������ MyObjs
            ReDims(MyObjs, ContObjs.Length - 1, ContObjs.Length - 1)
            For j = 0 To ContObjs.Length - 1
                If Array.IndexOf(MyObjs, ContObjs(j)) = -1 Then
                    MyObjs(MyObjs.Length - ContObjs.Length + j) = ContObjs(j)
                Else
                    ReDim Preserve MyObjs(MyObjs.Length - 2)
                End If
            Next
        Next
        Return MyObjs
    End Function

    ' �������� ��������� ���� ������ �������, �.�. obj
    Function GetMyObjFromObj(ByVal obj As Object) As Object
        Dim i, j As Integer
        'If obj.MyObj Is Nothing = False Then Return obj.MyObj ' ������� ���� ��������
        If f Is Nothing Then Return Nothing
        ' ������������� ��� �����
        For i = 0 To f.Length - 1
            If f(i) Is Nothing = False Then
                ' ���� �� ����� � ����� ��������
                If f(i).obj Is obj Then Return f(i)
                If f(i).MyObjs Is Nothing = False Then
                    ' ���� �� � ����� ��������� � ����� ��������
                    For j = 0 To f(i).MyObjs.Length - 1
                        If obj Is f(i).MyObjs(j).obj Then Return f(i).MyObjs(j)
                    Next
                End If
            End If
        Next : Return Nothing
    End Function

    Function GetMyObjsFromConteiner(ByVal cont As Object) ', Optional ByVal withSortLevel As Boolean = False)
        Dim MyObjs(0) As Object, i, j As Integer ', level(0) As Integer
        MyObjs(0) = cont ': level(0) = 0
        If f Is Nothing Then Return MyObjs
        ' ������������� �� ���� ������ ��� �������
        For i = 0 To f.Length - 1
            If f(i) Is Nothing = False Then
                If f(i).MyObjs Is Nothing = False Then
                    For j = 0 To f(i).MyObjs.Length - 1
                        ' ���� �����, �� � ��� ������ ���� � ��� �����������
                        If Iz.IsFORM(cont) Then
                            If Iz.isPoluObj(f(i).MyObjs(j).obj) And f(i) Is cont Then
                                ReDim Preserve MyObjs(MyObjs.Length)
                                MyObjs(MyObjs.Length - 1) = f(i).MyObjs(j)
                            End If
                        End If
                        ' �������� �� cont ���������� ������� ������� ����� ���� � 10 ���������(level)
                        Dim tempCont As Object = f(i).MyObjs(j).conteiner
                        ' Dim tempLevel As Integer = 1
                        While tempCont Is Nothing = False
                            ' ���� �� , �� �������� ��� � ������ �������� ����� ���������
                            If tempCont Is cont Then
                                ReDim Preserve MyObjs(MyObjs.Length)
                                ' ReDim Preserve level(level.Length)
                                MyObjs(MyObjs.Length - 1) = f(i).MyObjs(j)
                                ' level(level.Length - 1) = tempLevel
                                Exit While
                            End If
                            ' ���� ��� ����������, �� �� ������������� �� ����� ������ �� ������� ��������� � ���������� �������� ������ �����������
                            If tempCont.GetType.ToString = "System.Windows.Forms.SplitterPanel" Then tempCont = Nothing : Continue While
                            tempCont = tempCont.conteiner ': tempLevel += 1
                        End While
                    Next
                End If
            End If
        Next
        ' ������������� �� ������ ����������� � �������� (level)
        'If withSortLevel Then
        ' Dim fl As Boolean = True, temp As Object
        ' While fl = True
        ' fl = False
        ' For i = 0 To level.Length - 2
        ' If level(i) > level(i + 1) Then
        ' temp = level(i) : level(i) = level(i + 1) : level(i + 1) = temp
        ' temp = MyObjs(i) : MyObjs(i) = MyObjs(i + 1) : MyObjs(i + 1) = temp
        ' fl = True
        ' End If
        ' Next
        ' End While
        ' End If

        Return MyObjs
    End Function
    Function GetSortMyObjsByLevelConteiner(ByVal ParamArray MyObjs() As Object) As Object()
        Dim i As Integer, fl As Boolean = True, cont As Object
        While fl = True
            fl = False
            For i = 0 To MyObjs.Length - 2
                ' ������� � objs ��� �������� ������� , ��������������� ���� ������� i
                Dim objs(MyObjs.Length - 1) As Object
                Array.Copy(MyObjs, i + 1, objs, 0, MyObjs.Length - (i + 1))
                cont = MyObjs(i).conteiner
                If MyObjs(i).obj.TypeObj = "PoluObj" Then Continue For
                ' ������������� ��� ��������� ������� ������ �� ������ ����������
                While cont Is Nothing = False
                    ' ���� ������ � ������� ������, ���������� ���������� ������������ �������, �� ����������� �������� ������ � �����
                    If Array.IndexOf(objs, cont) <> -1 Then
                        Dim k = 0, l As Integer = 0
                        Dim temp(MyObjs.Length - 1) As Object
                        ' �������� ����������� i-�� �������� ������� � ����� ����� ������� (������������ ReDims ����������, ��� ������� ����� �������)
                        For k = 0 To MyObjs.Length - 1
                            If l <> i Then l += 1 Else l += 2
                            If l > MyObjs.Length Then l = i + 1
                            temp(k) = MyObjs(l - 1)
                        Next
                        MyObjs = temp
                        fl = True : i -= 1 : Exit While
                    End If
                    If cont.obj.TypeObj = "PoluObj" Then Exit While
                    cont = cont.conteiner
                End While
                If Iz.IsMMs(MyObjs(i)) Then
                    MyObjs(i) = MyObjs(i)
                End If
            Next
        End While
        '        MyObjs = GetSortTPsByPosition(MyObjs)
        Return MyObjs
    End Function
    Function GetSortMyObjsByFormsLast(ByVal ParamArray MyObjs() As Object) As Object()
        Dim i As Integer, fl As Boolean = True, temp As Object
        While fl = True
            fl = False
            For i = 0 To MyObjs.Length - 2
                If Iz.IsFORM(MyObjs(i)) And Iz.IsFORM(MyObjs(i + 1)) = False Then
                    temp = MyObjs(i) : MyObjs(i) = MyObjs(i + 1) : MyObjs(i + 1) = temp
                    fl = True
                End If
            Next
        End While
        Return MyObjs
    End Function
    Function GetSortMyObjsByIndexTemp(ByVal MyObjs() As Object) As Object()
        Dim i As Integer, fl As Boolean = True, temp As Object
        While fl = True
            fl = False
            For i = 0 To MyObjs.Length - 2
                If MyObjs(i).IndexTemp = "" Or MyObjs(i + 1).IndexTemp = "" Then Return MyObjs
                If Convert.ToInt16(MyObjs(i).IndexTemp) > Convert.ToInt16(MyObjs(i + 1).IndexTemp) Then
                    temp = MyObjs(i) : MyObjs(i) = MyObjs(i + 1) : MyObjs(i + 1) = temp
                    fl = True
                End If
            Next
        End While
        Return MyObjs
    End Function
    Function GetSortMyObjsByHistoryTemp(ByVal MyObjs() As Object) As Object()
        Dim i As Integer, fl As Boolean = True, temp As Object
        While fl = True
            fl = False
            For i = 0 To MyObjs.Length - 2
                If MyObjs(i).HistoryTemp = "" Or MyObjs(i + 1).HistoryTemp = "" Then Return MyObjs
                If Convert.ToInt16(MyObjs(i).HistoryTemp) > Convert.ToInt16(MyObjs(i + 1).HistoryTemp) Then
                    temp = MyObjs(i) : MyObjs(i) = MyObjs(i + 1) : MyObjs(i + 1) = temp
                    fl = True
                End If
            Next
        End While
        Return MyObjs
    End Function

    Function GetMyAllTypes() As String()
        Dim ret As New ArrayList, i, j As Integer
        ' ������������� �� ���� ������ ��� �������
        For i = 0 To f.Length - 1
            If f(i) Is Nothing = False AndAlso f(i).MyObjs Is Nothing = False Then
                For j = 0 To f(i).MyObjs.Length - 1
                    Dim tip As String = f(i).MyObjs(j).GetType.ToString.Replace(ClassAplication, "")
                    If ret.IndexOf(tip) = -1 Then ret.Add(tip)
                Next
            End If
        Next
        Return ret.ToArray("".GetType)
    End Function
#End Region

    ' <<<<<<<< �������� � ��������� >>>>>>>>>
#Region "SOBYTS"

    ' ��������� ������� ����� � ��������� ��������
    Function GetSobyts(ByVal ParamArray MyObjs() As Object) As String()
        Dim sobyts() As String = Nothing, i, j, ind As Integer
        If MyObjs Is Nothing Then Return Nothing
        If MyObjs(0) Is Nothing Then Return Nothing
        ' ������� � sobyts ��� �������� ������� ����������
        For i = 0 To MyObjs.Length - 1
            ' ����������� ��� ������� ������� �������
            For j = 0 To MyObjs(i).Sobyts.Length - 1
                ' ���� ��������������� �� ������ ������
                If sobyts Is Nothing = False Then
                    ' ���� ������� ��� ���� � ������ �������, �� ������� � ���������� �������
                    If Array.IndexOf(sobyts, MyObjs(i).Sobyts(j)) <> -1 Then Continue For
                End If
                ' ���� ��� ���� ����� � ����� ��������
                If MyObjs(i) Is Nothing Then Continue For
                If MyObjs(i).getNode(, True) Is Nothing Then Continue For
                If proj.FindSobyt(MyObjs(i).Sobyts(j), MyObjs(i).getNode(, True)) Is Nothing = False Then Continue For
                ' ���� ��� ������ ������, ������� ���������������
                If sobyts Is Nothing Then ind = 0 Else ind = sobyts.Length
                ' ������� ������� � ������
                ReDim Preserve sobyts(ind) : sobyts(ind) = MyObjs(i).Sobyts(j)
            Next
        Next
        Return sobyts
    End Function

    ' �������� �������
    Sub SetSobyts(ByVal sobyt As String, ByVal ParamArray MyObjs() As Object)
        Dim i As Integer, selNode, node, SobytNode As TreeNode, fl As Boolean
        If MyObjs Is Nothing Or sobyt = "" Then Exit Sub
        ' ������� ������� � ������ �������
        For i = 0 To MyObjs.Length - 1
            ' ���� � ������� ���������� ����������� ������ �������
            If Array.IndexOf(MyObjs(i).SobytsUp, UCase(sobyt)) <> -1 Then
                ' �������� ����� �������
                node = MyObjs(i).GetNode(, True)
                If node Is Nothing Then Exit Sub
                ' �������� ����� � ������ �������, �� ����� �������
                SobytNode = FindSobyt(sobyt, node)
                ' ���� � ������� ��� ������ �������, �� �������� ���
                If SobytNode Is Nothing Then
                    node.Nodes.Add(GetUIN(), sobyt, trans(sobyt, True), trans(sobyt, True))
                    node.Nodes(node.Nodes.Count - 1).Tag = "Sobyt"
                    node.Expand()
                    selNode = node.LastNode
                    ' �������� ��������
                    UndoRedoTree(fl, True, node.LastNode) : fl = True
                End If
            End If
        Next
        ' ��������� ����� �� ����� ���������� ��������
        If selNode Is Nothing = False Then
            Tree.SelectedNode = selNode : tab.SelectedTab = tab.TabPages("deistviya")
        End If
        ' ������� ����� ������ �������-������� ��� ���������� ���������
        old_sobytAll = Nothing
    End Sub

    ' �������� ��������
    Sub SetDeistvs(ByVal deist As String)
        Dim ind As Integer ', selNode, node, SobytNode As TreeNode
        Dim ParentAddNode As TreeNode = Nothing
        If deist = "" Then Exit Sub
        GetParentAddNode(ind, ParentAddNode)
        If ParentAddNode Is Nothing Then Exit Sub
        ' �������� ������ ��������������� ��������
        RemoveEmpty(ind)
        ParentAddNode.Nodes.Insert(ind, GetUIN(), deist, "deist", "deist")
        ParentAddNode.Nodes(ind).Tag = "Deist"
        ' �������� ��������
        UndoRedoTree(False, True, ParentAddNode.Nodes(ind))
        ' ��������� ����� �� ����� ���������� ��������
        ParentAddNode.Expand()
        MainForm.SelNode = ParentAddNode.Nodes(ind) : Tree.SelectedNode = MainForm.SelNode
    End Sub

    ' �������� ����
    Sub SetCycles(ByVal cycl As String)
        Dim ind As Integer ', selNode, node, SobytNode As TreeNode
        Dim ParentAddNode As TreeNode = Nothing
        If cycl = "" Then Exit Sub
        GetParentAddNode(ind, ParentAddNode)
        If ParentAddNode Is Nothing Then Exit Sub
        ' �������� ������ ��������������� ��������
        RemoveEmpty(ind)
        ParentAddNode.Nodes.Insert(ind, GetUIN(), cycl, "while", "while")
        ParentAddNode.Nodes(ind).Tag = "While"
        ParentAddNode.Nodes.Insert(ind + 1, GetUIN(), trans("����� �����"), "endwhile", "endwhile")
        ParentAddNode.Nodes(ind + 1).Tag = "EndWhile"
        ParentAddNode.Nodes(ind).Nodes.Add(GetUIN(), trans("�������� ���� ��������"), "Nothing", "Nothing")
        ParentAddNode.Nodes(ind).Nodes(0).Tag = "EmptyCycle"
        ' �������� ��������
        UndoRedoTree(False, True, ParentAddNode.Nodes(ind), ParentAddNode.Nodes(ind).Nodes(0), ParentAddNode.Nodes(ind + 1))
        ' �������� ������ ��������������� ��������
        RemoveEmpty(ind)
        ' ��������� ����� �� ����� ���������� ��������
        ParentAddNode.Expand()
        Tree.SelectedNode = ParentAddNode.Nodes(ind).Nodes(0)
        tab.SelectedTab = tab.TabPages("deistviya")
    End Sub

    ' �������� �������
    Sub SetIfs(ByVal ifs As String, ByVal type As String)
        Dim ind As Integer ', selNode, node, SobytNode As TreeNode
        Dim ParentAddNode As TreeNode = Nothing
        If ifs = "" Then Exit Sub
        If type = "Usually" Then
            GetParentAddNode(ind, ParentAddNode)
            If ParentAddNode Is Nothing Then Exit Sub
            ' �������� ������ ��������������� ��������
            RemoveEmpty(ind)
            ParentAddNode.Nodes.Insert(ind, GetUIN(), ifs, "if", "if")
            ParentAddNode.Nodes(ind).Tag = "If"
            ' ���������� ����� �� ��� ��������� ����� ��� �� ��� ���� � ������
            Dim nn As TreeNode = ParentAddNode.Nodes(ind).NextNode, tag As String = ""
            If nn Is Nothing = False Then tag = nn.Tag
            If tag <> "Else" And tag <> "ElseIf" And tag <> "EndIf" Then
                ParentAddNode.Nodes.Insert(ind + 1, GetUIN(), trans("����� �������"), "endif", "endif")
                ParentAddNode.Nodes(ind + 1).Tag = "EndIf"
                UndoRedoTree(False, True, ParentAddNode.Nodes(ind), ParentAddNode.Nodes(ind + 1))
            Else
                UndoRedoTree(False, True, ParentAddNode.Nodes(ind))
            End If
        ElseIf type = "podIf" Or type = "Else" Then
            ParentAddNode = GetIfNameFromTreeNode()
            If ParentAddNode Is Nothing Then Exit Sub
            ind = ParentAddNode.Index + 1
            ParentAddNode = ParentAddNode.Parent
            If ParentAddNode.Nodes.Count <= ind Then
                ParentAddNode.Nodes.Insert(ParentAddNode.Nodes.Count, GetUIN(), trans("����� �������"), "endif", "endif")
                ParentAddNode.Nodes(ParentAddNode.Nodes.Count - 1).Tag = "EndIf"
                UndoRedoTree(False, True, ParentAddNode.Nodes(ParentAddNode.Nodes.Count - 2), ParentAddNode.Nodes(ParentAddNode.Nodes.Count - 1))
                Exit Sub
            End If
            If type = "podIf" Then
                ' ���� ����� ���������� ������ ����� ����
                If ParentAddNode.Nodes(ind).Tag = "EndIf" And ParentAddNode.Nodes(ind - 1).Tag = "Else" Then ind -= 1
                ParentAddNode.Nodes.Insert(ind, GetUIN(), ifs, "elseif", "elseif")
                ParentAddNode.Nodes(ind).Tag = "ElseIf"
            ElseIf type = "Else" Then
                ' ���� ���� ��� � ����� �������
                If GetElseOrElseIf(ParentAddNode.Nodes(ind)) Is Nothing Then
                    ' ��������� ���� � ����� �������
                    While ParentAddNode.Nodes(ind).Tag <> "EndIf"
                        ind += 1
                        If ind > ParentAddNode.Nodes.Count - 1 Then Exit Sub
                    End While
                    ParentAddNode.Nodes.Insert(ind, GetUIN(), ifs, "else", "else")
                    ParentAddNode.Nodes(ind).Tag = "Else"
                Else
                    MsgBox(Errors.AlreadyHaveElse) : Exit Sub
                End If
            End If
            UndoRedoTree(False, True, ParentAddNode.Nodes(ind))
        End If

        ParentAddNode.Nodes(ind).Nodes.Add(GetUIN(), trans("�������� ���� ��������"), "Nothing", "Nothing")
        ParentAddNode.Nodes(ind).Nodes(0).Tag = "EmptyIf"
        UndoRedoTree(True, True, ParentAddNode.Nodes(ind).Nodes(0))
        ' �������� ������ ��������������� ��������
        If type = "Usually" Then RemoveEmpty(ind, "do")

        ' ��������� ����� �� ����� ���������� ��������
        ParentAddNode.Expand()
        On Error Resume Next
        MainForm.SelNode = ParentAddNode.Nodes(ind).Nodes(0) : Tree.SelectedNode = MainForm.SelNode
        tab.SelectedTab = tab.TabPages("deistviya")
    End Sub

    ' �������� �����������
    Sub SetComm(ByVal comm As String, Optional ByVal fromEdit As Boolean = False)
        If Tree.SelectedNode Is Nothing Then Exit Sub
        'Dim bylNext As Boolean = False
        'If Tree.SelectedNode.NextNode Is Nothing = False Then
        ' bylNext = True : MainForm.SelNode = Tree.SelectedNode.NextNode : Tree.SelectedNode = Tree.SelectedNode.NextNode
        ' End If
        Dim ind As Integer = Tree.SelectedNode.Index + 1 'Convert.ToInt16(fromEdit)  ', selNode, node, SobytNode As TreeNode
        Dim ParentAddNode As Object = Tree.SelectedNode
        'If Tree.SelectedNode.Nodes.Count = 0 Then ParentAddNode = ParentAddNode.parent Else ind = 0
        ParentAddNode = ParentAddNode.parent
        If ParentAddNode Is Nothing Then ParentAddNode = Tree
        If ind > 0 And Tree.SelectedNode.Nodes.Count > 0 Then ind -= 1
        ' If ind = ParentAddNode.nodes.count - 1 And Tree.SelectedNode.Tag <> "Sobyt" Then ind += 1
        ' �������� ������ ��������������� ��������
        RemoveEmpty(ind)
        ParentAddNode.Nodes.Insert(ind, GetUIN(), comm, "comm", "comm")
        ParentAddNode.Nodes(ind).Tag = "Comm"
        ' �������� ��������
        UndoRedoTree(False, True, ParentAddNode.Nodes(ind))
        ' ��������� ����� �� ����� ���������� ��������
        If ParentAddNode Is Tree = False Then ParentAddNode.Expand()
        MainForm.SelNode = ParentAddNode.Nodes(ind) : Tree.SelectedNode = MainForm.SelNode
        '        If bylNext Then
        '            MainForm.SelNode = Tree.SelectedNode.PrevNode : Tree.SelectedNode = Tree.SelectedNode.PrevNode
        '        End If
    End Sub
    ' �������� ���� ������ (� ������� ���� ��������� ����� �������� ��� �������) � ������ � ���� ���� 
    Sub GetParentAddNode(ByRef ind As Integer, ByRef AddToNode As TreeNode)
        If Tree.SelectedNode Is Nothing Then Exit Sub
        If Tree.SelectedNode.Level < 2 Then
            Exit Sub
        ElseIf Tree.SelectedNode.Level < 3 Or Tree.SelectedNode.Nodes.Count > 0 _
        Or GetIfNameFromTreeNode(False) Is Nothing = False Or Tree.SelectedNode.Tag = "While" Then
            ind = 0 : AddToNode = Tree.SelectedNode
        Else
            ind = Tree.SelectedNode.Index + 1 : AddToNode = Tree.SelectedNode.Parent
        End If
    End Sub
    ' �������� ������ ��������������� ��������
    Sub RemoveEmpty(ByRef ind As Integer, Optional ByVal union As String = "")
        Dim i As Integer
        For i = 0 To Tree.SelectedNode.Nodes.Count - 1
            If Tree.SelectedNode.Nodes(i).Tag = "EmptyIf" Or Tree.SelectedNode.Nodes(i).Tag = "EmptyCycle" Then
                ' �������� ��������
                If union = "do" Then UndoRedo("#Union Undos(Redos)", "", "", "")
                If union <> "" Then UndoRedoTree(False, False, Tree.SelectedNode.Nodes(i))
                If union = "posle" Then UndoRedo("#Union Undos(Redos)", "", "", "")
                ' ���������� ��������
                Tree.SelectedNode.Nodes(i).Remove() : ind = 0
            End If
        Next
        If Tree.SelectedNode.Tag = "EmptyIf" Or Tree.SelectedNode.Tag = "EmptyCycle" Then
            ' �������� ��������
            If union = "do" Then UndoRedo("#Union Undos(Redos)", "", "", "")
            If union <> "" Then UndoRedoTree(False, False, Tree.SelectedNode)
            If union = "posle" Then UndoRedo("#Union Undos(Redos)", "", "", "")
            ' ���������� ��������
            Tree.SelectedNode.Remove() : ind = 0
        End If
    End Sub
    ' ���������� �� � ������ ������� ������ "�� ���� ��������� �������" ��� "��� ����"
    Function GetElseOrElseIf(ByVal node As TreeNode, Optional ByVal ChtoIshem As String = "Else") As TreeNode
        If node Is Nothing Then Return Nothing
        While node Is Nothing = False
            If node.Tag = "If" Then Exit While
            node = node.PrevNode
        End While
        While node Is Nothing = False
            If node.Tag = ChtoIshem Then Return node
            If node.Tag = "EndIf" Then Exit While
            node = node.NextNode
        End While
        Return Nothing
    End Function


    ' �������� ����� �� ����� (� ������� �� ������) � �������� �����, ��������� ������ �������� ������
    Function GetNode(ByVal chto As TreeNode, Optional ByVal root As TreeNode = Nothing, Optional ByVal level As Integer = -1, _
    Optional ByVal IskatPoTextu As Boolean = False) As TreeNode
        Dim i As Integer, node As TreeNode = Nothing
        If root Is Nothing Then root = ActiveForm.GetNode
        If level = -1 Then level = root.Level
        If root.Name = chto.Name Then Return root
        If (chto.Tag = "Sobyt" And root.Tag = "Sobyt") Or IskatPoTextu Then
            If root.Text = chto.Text Then Return root
        End If
        If root.Nodes.Count > 0 Then
            ' ����������� ��� ��������
            For i = 0 To root.Nodes.Count - 1
                ' ���������� ����������� ��� �������� ������ ��������
                node = Nothing : node = GetNode(chto, root.Nodes(i), level, IskatPoTextu)
                ' ���� ������� ����� � ������ ������
                If node Is Nothing = False Then Return node
            Next
        End If
        ' ���� �������� � ������ ������ �� �������, �� �� ���������� ��������� ������� ��� �� ���������
        If level >= root.Level Then Return Nothing
    End Function
    Function FindSobyt(ByVal sobyt As String, ByVal root As TreeNode) As TreeNode
        Dim i As Integer
        If root Is Nothing Then Return Nothing
        For i = 0 To root.Nodes.Count - 1
            If UCase(root.Nodes(i).Text) = UCase(sobyt) Then Return root.Nodes(i)
        Next
        Return Nothing
    End Function
    ' �������� ����� �� �����
    Function GetNodeFromName(ByVal name As String, Optional ByVal root As Object = Nothing, Optional ByVal isObj As Boolean = False) As Object
        Dim i As Integer, ret As TreeNode
        If root Is Nothing Then root = Tree
        If name = "" Then Return root
        ' ���� �������� ������ ���� ����
        If name.Split("\").Length = 2 Then
            root = Tree.Nodes(name.Split("\")(0))
            If root Is Nothing Then Return Nothing
            ' ���� � ���� ����� ���� ������ ������� ����
            If name.Split("\")(1).IndexOf("(") <> -1 Then
                Dim ind As Integer = name.Substring(name.IndexOf("(") + 1, name.Length - name.IndexOf("(") - 2)
                name = Left(name, name.IndexOf("("))
                If ind >= root.nodes.count Then Return root.Nodes(name.Split("\")(1))
                If root.Nodes(ind).name <> name.Split("\")(1) Then Return Nothing
                Return root.Nodes(ind)
            End If
            ret = root.Nodes(name.Split("\")(1))
            Return ret
        End If

        For i = 0 To root.Nodes.Count - 1
            If isObj = True Or root.Nodes(i).level > 0 Then
                If name.IndexOf("(") <> -1 Then name = Left(name, name.IndexOf("("))
                If root.Nodes(i).name = name Then Return root.Nodes(i)
            End If
            ret = GetNodeFromName(name, root.Nodes(i), isObj)
            If ret Is Nothing = False Then Return ret
        Next
        Return Nothing
    End Function

    Function PasteTree(ByVal kuda As Object, ByVal CopyNodes As String, Optional ByVal sVoprosom As Boolean = True, Optional ByVal fromMove As Boolean = False) As TreeNode()
        Return MainForm.PasteTree(kuda, CopyNodes, sVoprosom, fromMove)
    End Function
    Public old_sobytAll As Sobitiya = Nothing
    ' �������� ������ ������� �� ����� ����������
    Function GetSobytObj(Optional ByVal sobyt As String = Nothing) As Object
        ' ���� ������� �� ������, �� ����������� ���������� ��� ������������� �� ������
        If sobyt = Nothing Then
            If GetSobytNameFromTreeNode() = Nothing Then Return Nothing
            sobyt = GetSobytNameFromTreeNode()
        End If
        If sobyt = MyZnak & "All" Then
            If old_sobytAll Is Nothing Then old_sobytAll = New Sobitiya(sobyt)
            Return old_sobytAll
        End If
        Return New Sobitiya(sobyt)
    End Function

    ' �������� ��������� �� ��������
    Function GetSobytObjObject() As Object()
        Return GetMyObjsFromTreeNode(Tree.SelectedNode)
    End Function

    ' �������� ��� �������, ������� �������� � ������
    Function GetSobytNameFromTreeNode(Optional ByVal node As TreeNode = Nothing) As String
        If node Is Nothing Then node = Tree.SelectedNode
        If node Is Nothing Then Return ""
        If node.Level < 2 Then Return Nothing
        While node.Level > 2 : node = node.Parent : End While
        Return node.Text
    End Function

    ' �������� ��� �������, ������� �������� � ������
    Function GetIfNameFromTreeNode(Optional ByVal withKonec As Boolean = True, Optional ByVal node As TreeNode = Nothing) As TreeNode
        If node Is Nothing Then node = Tree.SelectedNode
        If node Is Nothing Then Return Nothing
        If node.Level < 3 Then Return Nothing
        If node.Tag = "If" Or node.Tag = "ElseIf" Or node.Tag = "Else" Then
            Return node
        ElseIf node.Tag = "EndIf" And withKonec = True Then
            Return node.PrevNode
        Else
            Return Nothing
        End If
    End Function

    ' ������� ���� ������������ ��������
    Sub DeistvRefresh(ByVal ParamArray MyObjs() As Object)
        Dim i, ind As Integer, names As String = ""
        SobytMyObjs = MyObjs : MainForm.ComboBox1.Items.Clear()
        tab.TabPages.Remove(CommTab) ' ������� �����������

        ' �������
        Dim s() As String = GetSobyts(SobytMyObjs)
        If s Is Nothing = False Then
            MainForm.ComboBox1.Items.AddRange(s)
            If MainForm.ComboBox1.Items.IndexOf(SobytMyObjs(0).obj.lastSobyt) <> -1 Then
                MainForm.ComboBox1.SelectedIndex = MainForm.ComboBox1.Items.IndexOf(SobytMyObjs(0).obj.lastSobyt)
            Else
                MainForm.ComboBox1.SelectedIndex = 0
                If MainForm.ComboBox1.Items.IndexOf(trans("����")) <> -1 Then
                    MainForm.ComboBox1.SelectedIndex = MainForm.ComboBox1.Items.IndexOf(trans("����"))
                End If
            End If

         
            For i = 0 To SobytMyObjs.Length - 1
                If names.IndexOf(", " & SobytMyObjs(i).obj.Props.name) = -1 Then
                    names &= ", " & SobytMyObjs(i).obj.Props.name
                End If
            Next
            MainForm.Label1.Text = trans("������� ������� ���") & " " & names.Substring(2)
            ind = SobytsTab.Tag
            If tab.TabPages.Count < ind Then ind = tab.TabPages.Count
            If tab.TabPages(SobytsTab.Name) Is Nothing Then tab.TabPages.Insert(ind, SobytsTab) : tab.SelectedTab = SobytsTab
        Else
            Dim o = SobytsTab
            If tab.TabPages(SobytsTab.Name) Is Nothing = False Then tab.TabPages.Remove(SobytsTab)
        End If

        If Tree.SelectedNode Is Nothing And Tree.Nodes.Count > 0 Then Tree.SelectedNode = Tree.Nodes(0)
        If Tree.SelectedNode Is Nothing Then Exit Sub

        If Tree.SelectedNode.Level < 2 Or (Tree.SelectedNode.Level <= 2 And Tree.SelectedNode.Tag = "Comm") Then
            If tab.TabPages(DeistTab.Name) Is Nothing = False Then tab.TabPages.Remove(DeistTab)
            If tab.TabPages(ifTab.Name) Is Nothing = False Then tab.TabPages.Remove(ifTab)
            If tab.TabPages(CycleTab.Name) Is Nothing = False Then tab.TabPages.Remove(CycleTab)

            '   If tab.TabPages(CommTab.Name) Is Nothing = False Then tab.TabPages.Remove(CommTab)
        Else
            ' If GetMyObjsFromTreeNode()(0).GetType.ToString = "System.Windows.Forms.TreeNode" Then
            ' GetMyObjsFromTreeNode()(0).parent.remove()
            ' MainForm.TabControl2_SelectedIndexChanged(tab, New EventArgs)
            'End If
            ' ��������
            ind = DeistTab.Tag
            If tab.TabPages.Count < ind Then ind = tab.TabPages.Count
            If tab.TabPages(DeistTab.Name) Is Nothing Then tab.TabPages.Insert(ind, DeistTab) : tab.SelectedTab = DeistTab
            MainForm.DeistLabel.Text = trans("������� ��������, ��� �������") & " " & _
                GetSobytNameFromTreeNode() & " " & trans("�������") & " " & GetMyObjsFromTreeNode()(0).obj.Props.name
            CreateDs.SetProperty()
            ' �������
            ind = ifTab.Tag
            If tab.TabPages.Count < ind Then ind = tab.TabPages.Count
            If tab.TabPages(ifTab.Name) Is Nothing Then tab.TabPages.Insert(ind, ifTab)
            MainForm.IfLabel.Text = trans("������� �������, ��� �������") & " " & _
                GetSobytNameFromTreeNode() & " " & trans("�������") & " " & GetMyObjsFromTreeNode()(0).obj.Props.name
            CreateIfs.Shown()
            ' �����
            ind = CycleTab.Tag
            If tab.TabPages.Count < ind Then ind = tab.TabPages.Count
            If tab.TabPages(CycleTab.Name) Is Nothing Then tab.TabPages.Insert(ind, CycleTab)
            MainForm.CycleLabel.Text = trans("������� ����, ��� �������") & " " & _
                GetSobytNameFromTreeNode() & " " & trans("�������") & " " & GetMyObjsFromTreeNode()(0).obj.Props.name
        End If

        ' �����������
        ind = CommTab.Tag
        If tab.TabPages.Count < ind Then ind = tab.TabPages.Count
        If tab.TabPages(CommTab.Name) Is Nothing Then tab.TabPages.Insert(ind, CommTab)

        ' ������� ������ ������� �����
        MainForm.TabControl2_SelectedIndexChanged(tab, New EventArgs)
    End Sub
#End Region

End Class
