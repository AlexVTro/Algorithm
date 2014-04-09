Public Module Iz
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ ТИПОМ ПАНЕЛИ
    Function isPanel(ByVal obj As Object) As Boolean
        Select Case obj.GetType.ToString
            Case ClassAplication & "F" : Return True
            Case ClassAplication & "runF" : Return True
            Case ClassAplication & "P" : Return True
            Case ClassAplication & "runP" : Return True
            Case ClassAplication & "DP" : Return True
                ' Case ClassAplication & "runDP" : Return True
            Case ClassAplication & "TPs" : Return True
            Case ClassAplication & "runTPs" : Return True
            Case Else : Return False
        End Select
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ СОСТАВНЫМ, Т.Е. СОДЕРЖИТ ВНУТРИ СЕБЯ ОБЪЕКТЫ ТИПА IncludeObj
    Function isSostObj(ByVal obj As Object) As Boolean
        Select Case obj.GetType.ToString
            Case ClassAplication & "TP" : Return True
            Case ClassAplication & "MM" : Return True
            Case ClassAplication & "MMs" : Return True
            Case ClassAplication & "CM" : Return True
            Case ClassAplication & "TPl" : Return True
            Case Else : Return False
        End Select
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ СОСТАВНЫМ, Т.Е. СОДЕРЖИТ ВНУТРИ СЕБЯ ОБЪЕКТЫ ТИПА IncludeObj
    Function isSostMyObj(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        Return isSostObj(MyObj.obj)
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ СОСТАВНЫМ, Т.Е. СОДЕРЖИТ ВНУТРИ СЕБЯ ОБЪЕКТЫ ТИПА IncludeObj
    Function isObjSobitiya(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If UCase(obj.name) = MyZnak & UCase(trans("Объект события")) Or UCase(obj.name) = MyZnak & UCase(trans("Окно события")) Then
            Return True
        Else
            Return False
        End If
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ СОСТАВНЫМ, Т.Е. СОДЕРЖИТ ВНУТРИ СЕБЯ ОБЪЕКТЫ ТИПА IncludeObj
    Function isMyObj(ByVal txt As String) As Boolean
        If txt.IndexOf(vbCrLf) = -1 Then Return False
        Dim tip As String = txt.Substring(0, txt.IndexOf(vbCrLf))
        If Pustishki.ContainsKey(tip) Then Return True Else Return False
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ СОСТАВНЫМ, Т.Е. СОДЕРЖИТ ВНУТРИ СЕБЯ ОБЪЕКТЫ ТИПА IncludeObj
    Function isPoluObj(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If obj.TypeObj = "PoluObj" Then Return True Else Return False
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ ПОЛЕЗНЫМ
    Function isPoleznie(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If obj.GetType.ToString = ClassAplication & "PoleznieObj" Then Return True
        If IsFORM(obj.myObj) Then
            If obj.myObj.myobjs IsNot Nothing Then
                If obj.myObj.myobjs.length > 1 Then Return isPoleznie(obj.myObj.myobjs(obj.myObj.myobjs.length - 1).obj)
            End If
        End If
        Return False
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ СТРОКА МОИМ КОДОМ ИЛИ ПРОСТО СТРОКОЙ
    Function isCode(ByVal cod As String) As Boolean
        cod = Trim(cod)
        If cod = "" Then Return True
        If cod(0) <> """" Then Return True
        Dim cs As New CodeString(cod, , False)
        If cs.PropuskKovich(0) <> cod.Length - 1 Then Return True
        Return False
    End Function
    ' ЕСЛИ ЭТО ЧИСЛО ТИПА ДАУБЛ
    Function isDouble(ByRef str1 As String) As Boolean
        Dim i As Integer, byloT, byloE, byloZ, byloCh, byloChE, byloChZ As Boolean
        If str1 = "" Then str1 = "0"
        Dim str As String = str1
        str = str
        For i = 0 To str.Length - 1
            If Char.IsDigit(str(i)) = False Then
                If (str(i) = "+" Or str(i) = "-") And i = 0 Then Continue For
                If (str(i) = PointSimb1 Or str(i) = PointSimb2) And byloT = False And byloE = False Then byloT = True : Continue For
                If str(i) = "E" And byloE = False Then byloE = True : Continue For
                If (str(i) = "+" Or str(i) = "-") And byloE = True And byloZ = False Then byloZ = True : Continue For
                Return False
            Else
                byloCh = True
                If byloE = False Then byloChE = True
                If byloZ = True Then byloChZ = True
            End If
        Next
        If byloCh = False Then Return False
        If byloE = True And byloChE = False Then Return False
        If byloZ = True And byloChZ = False Then Return False
        If str.Length > 300 Then Return False
        If byloE And byloZ = False Then Return False
        If byloE Then
            If Val(str.Substring(str.IndexOf("E") + 2)) > 300 Then Return False
        End If
        Return True
    End Function
    ' ЕСЛИ ЭТО ЧИСЛО ТИПА ИНТ
    Function isInteger(ByRef str1 As String) As Boolean
        Dim i As Integer
        If isDouble(str1) = False Then Return False
        Dim str As String = str1
        If str.IndexOf("E") = -1 Then
            For i = 0 To str.Length - 1
                If (str(i) = "+" Or str(i) = "-") And i = 0 Then Continue For
                If Char.IsDigit(str(i)) = False Then Return False
            Next
        Else
            Dim posleZ = 0, posleE As Integer
            If str.IndexOf(PointSimb1) <> -1 Then
                posleZ = str.IndexOf("E") - str.IndexOf(PointSimb1)
            ElseIf str.IndexOf(PointSimb2) <> -1 Then
                posleZ = str.IndexOf("E") - str.IndexOf(PointSimb2)
            End If
            posleE = str.Substring(str.IndexOf("E") + 2)
            If posleE < posleZ Then Return False
        End If
        Dim d As Double
        d = ToDouble(str)
        If d > Integer.MaxValue Then Return False
        Return True
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ ОБЪЕКТОМ С НЕИЗМЕННЫМИ РАЗМЕРАМИ
    Function isNoSizeChange(ByVal obj As Object) As Boolean
        If obj.TypeObj = "PoluObj" Then Return True
        Select Case obj.GetType.ToString
            '   Case ClassAplication & "MM" : Return True
            Case ClassAplication & "MMs" : Return True
            Case Else : Return False
        End Select
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ ОДНИМ ИЗ ТЕХ ОБЪЕКТОМ С КОТОРЫЕ НЕЛЬЗЯ ПЕРЕМЕЩАТЬ
    Function isNoMove(ByVal obj As Object) As Boolean
        Select Case obj.GetType.ToString
            Case ClassAplication & "MMs" : Return True
            Case Else : Return False
        End Select
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ ОДНИМ ИЗ ТЕХ ОБЪЕКТОМ С КОТОРЫЕ МОЖНО ПЕРЕМЕЩАТЬ ТОЛЬКО МАРКЕРОМ
    Function isMoveOnlyMarker(ByVal obj As Object) As Boolean
        Select Case obj.GetType.ToString
            Case ClassAplication & "Tl" : Return True
            Case ClassAplication & "T" : Return True
            Case ClassAplication & "C" : Return True
            Case ClassAplication & "L" : Return True
            Case ClassAplication & "RT" : Return True
            Case Else : Return False
        End Select
    End Function
    ' ПРОВЕРЯЕТ, НУЖНО ЛИ ПОКАЗЫВАТЬ ИКОНКУ ПЛЮСИКА, ТИПА МОЖНО ДОБАВЛЯТЬ НОВЫЕ ИНКЛУД ОБЪЕКТЫ
    Function isHavePlusik(ByVal obj As Object) As Boolean
        Select Case obj.GetType.ToString
            Case ClassAplication & "TP" : Return True
            Case ClassAplication & "MM" : Return True
            Case ClassAplication & "MMs" : Return True
            Case ClassAplication & "CM" : Return True
            Case ClassAplication & "TPl" : Return True
            Case Else : Return False
        End Select
    End Function
    ' ПРОВЕРЯЕТ, НУЖНО ЛИ ПОКАЗЫВАТЬ ИКОНКУ ПЛЮСИКА, ТИПА МОЖНО ДОБАВЛЯТЬ НОВЫЕ ИНКЛУД ОБЪЕКТЫ
    Function isNoControlObj(ByVal obj As Object) As Boolean
        Select Case obj.GetType.ToString
            Case ClassAplication & "runCD" : Return True
            Case ClassAplication & "runFD" : Return True
            Case ClassAplication & "runPD" : Return True
            Case ClassAplication & "runSD" : Return True
            Case ClassAplication & "runOD" : Return True
            Case ClassAplication & "runPrD" : Return True
            Case ClassAplication & "runTm" : Return True
            Case Else : Return False
        End Select
    End Function
    ' ПРОВЕРЯЕТ, ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ IncludeObj'ом
    Function isIncludeObj(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If obj.TypeObj = "IncludeObj" Then
            Return True : Else : Return False
        End If
    End Function

    Public Function IsContenerTree(ByVal node As Object) As Boolean
        If node Is Nothing Then Return False
        If node.Tag = "If" Or node.Tag = "ElseIf" Or node.Tag = "Else" Or node.Tag = "While" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsContenerIfs(ByVal node As TreeNode) As Boolean
        If node Is Nothing Then Return False
        If node.Tag = "If" Or node.Tag = "ElseIf" Or node.Tag = "Else" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsContenerIfs(ByVal type As String) As Boolean
        Dim nd As New TreeNode() : nd.Tag = type : Return IsContenerIfs(nd)
    End Function
    Public Function IsEndsTree(ByVal node As TreeNode) As Boolean
        If node Is Nothing Then Return False
        If node.Tag = "EndIf" Or node.Tag = "EndWhile" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsVnutreniyIf(ByVal node As TreeNode) As Boolean
        If node Is Nothing Then Return False
        If node.Tag = "ElseIf" Or node.Tag = "Else" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsIfs(ByVal node As TreeNode) As Boolean
        If node Is Nothing Then Return False
        If node.Tag = "If" Or node.Tag = "ElseIf" Or node.Tag = "Else" Or node.Tag = "EndIf" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsWhile(ByVal node As TreeNode) As Boolean
        If node Is Nothing Then Return False
        If node.Tag = "While" Or node.Tag = "EndWhile" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsRodnyeTree(ByVal node1 As TreeNode, ByVal node2 As TreeNode) As Boolean
        If node1 Is Nothing Or node2 Is Nothing Then Return False
        If ((IsIfs(node1) And IsIfs(node2)) Or (IsWhile(node1) And IsWhile(node2))) And node1.Tag <> node2.Tag Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsSobytCopy(ByVal copy As String) As Boolean
        If copy = "" Then Return False
        Dim sep() As String = {vbCrLf}
        Dim cops() As String = copy.Split(sep, StringSplitOptions.None)
        If cops.Length > 4 Then
            Return (cops(4) = "Sobyt")
        Else
            Return False
        End If
    End Function
    Public Function IsCommCopy(ByVal copy As String) As Boolean
        If copy = "" Then Return False
        Dim sep() As String = {vbCrLf}
        Dim cops() As String = copy.Split(sep, StringSplitOptions.None)
        If cops.Length > 4 Then
            Return (cops(4) = "Comm")
        Else
            Return False
        End If
    End Function
    Public Function IsFORM(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Forms" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsFORMobj(ByVal Obj As Object) As Boolean
        If Obj Is Nothing Then Return False
        If Obj.GetType.ToString = ClassAplication & "F" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsFORMRunObj(ByVal Obj As Object) As Boolean
        If Obj Is Nothing Then Return False
        If Obj.GetType.ToString = ClassAplication & "runF" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsDP(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "DPanel" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsMMs(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "MMenus" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsMM(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "MMenu" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsCM(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "CMenu" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTPl(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "TPanel" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTP(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "TPage" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTPs(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "TPages" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsM(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Memory" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsMd(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Media" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsA(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Audio" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsCB(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "CheckBoks" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsW(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "WBrowser" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTl(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Table" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsC(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "ComboBoks" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsL(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "ListBoks" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsCL(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "CheckedList" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsLLb(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "LinkLabel" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsRT(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "RichText" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsCDobj(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If obj.GetType.ToString = ClassAplication & "CD" Or obj.GetType.ToString = ClassAplication & "runCD" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsFDobj(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If obj.GetType.ToString = ClassAplication & "FD" Or obj.GetType.ToString = ClassAplication & "runFD" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTm(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Timer" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsCr(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Calendar" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTb(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "TrackBar" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTbx(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "TextBoks" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTr(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Trial" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsCS(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "ClientServer" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsI(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = ClassAplication & "Internet" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsPrD(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If obj.GetType.ToString = ClassAplication & "PrD" Or obj.GetType.ToString = ClassAplication & "runPrD" Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsSobytCalls(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.obj.TypeObj <> "Polezniy" Then Return False
        If MyObj.type = MyZnak & trans("Вызвать событие") Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsTextPolezniy(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.obj.TypeObj <> "Polezniy" Then Return False
        If MyObj.type = MyZnak & trans("Текст") Then
            Return True : Else : Return False
        End If
    End Function
    Public Function IsSplitterPanel(ByVal MyObj As Object) As Boolean
        If MyObj Is Nothing Then Return False
        If MyObj.GetType.ToString = "System.Windows.Forms.SplitterPanel" Then
            Return True : Else : Return False
        End If
    End Function
End Module
