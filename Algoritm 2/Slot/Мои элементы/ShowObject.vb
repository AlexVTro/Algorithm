Public Class ShowObject
    Public MyObj, MyForm, MySobyt As Object, Sobyt As String ' Для хранения свойства и объектов
    Dim oldForm, oldObj, oldProp, oldInd As String
    Public Event PropertyChange(ByVal nowProp As String, ByVal propOld As String, ByVal MyObj As Object)
    Public Event ObjectChange(ByVal nowObj As String)
    Dim Pattern As MasterPattern
    Public args As New Arguments()
    Public Event SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public border As Integer = 0
    Public colBorder As Color
    Dim nelzyaP, nelzyaO, nelzyaS As Boolean
    Public Sub ShowObj(ByVal Pattern As Object, Optional ByVal sobyt As String = "")
        Dim i As Integer
        Me.Pattern = Pattern
        If sobyt = "" Then sobyt = proj.GetSobytNameFromTreeNode()
        Me.Sobyt = sobyt : MySobyt = proj.GetSobytObj()
        oldForm = forms.SelectedItem : oldObj = objects.SelectedItem : oldProp = propertys.SelectedItem : oldInd = indexs.SelectedItem
        forms.Items.Clear() : objects.Items.Clear() : indexs.Items.Clear() : propertys.Items.Clear()
        If proj.f Is Nothing Then Exit Sub
        For i = 0 To proj.f.Length - 1
            If proj.f(i) Is Nothing = False Then
                If forms.Items.IndexOf(proj.f(i).obj.Props.name) = -1 Then forms.Items.Add(proj.f(i).obj.Props.name)
            End If
        Next
        forms.Items.Add(MyZnak & trans("Окно события"))


        forms.BackColor = SkinColors("MainText")
        objects.BackColor = SkinColors("MainText")
        indexs.BackColor = SkinColors("MainText")
        propertys.BackColor = SkinColors("MainText")


        SelectedItem(forms)
    End Sub
    Function SetObj(ByVal str As String, Optional ByVal Formattingovat As Boolean = True) As Boolean
        'Dim m As System.Text.RegularExpressions.Match
        'm = System.Text.RegularExpressions.Regex.Match(str, "(\w| )+\.(\w| )+\.(\w| )+")
        'If m.Success = False Then Return False
        'If Trim(m.Value).Length < Trim(str).Length Then Return False
        'Dim mass() As String = Trim(m.Value).Split(".")
        nelzyaP = True : nelzyaO = True
        Dim ind, i As Integer, index As CodeString = Nothing, arguments() As String = Nothing
        Dim cs As New CodeString(Trim(str), , Formattingovat)
        ' Если присутствуют символы вычислений (+, - и т.д.), то сообщить о неудаче
        If cs.Split("naOdnomUrovne").texty.Length > 1 Then nelzyaP = False : nelzyaO = False : Return False
        Dim mass() As String = cs.Split("naOdnomUrovne", ".").texty
        If mass.Length < 3 Then nelzyaP = False : nelzyaO = False : Return False

        Dim ob As New CodeString(mass(1), , False)
        ind = ob.IndexOf("[")
        If ind <> -1 Then
            index = New CodeString(ob.Text.Substring(ind + 1, ob.IndexOf("]", , True) - ind - 1), , False)
            ob = New CodeString(ob.Text.Substring(0, ind), , False)
        End If

        Dim pr As New CodeString(mass(2), , False)
        ind = pr.IndexOf("(")
        If ind <> -1 And pr.IndexOf(")", , True) <> -1 Then
            Dim aa As CodeString = New CodeString(pr.Text.Substring(ind + 1, pr.IndexOf(")", , True) - ind - 1), , False)
            arguments = aa.Split("naOdnomUrovne", ",").texty
            pr = New CodeString(pr.Text.Substring(0, ind), , False)
        End If

        forms.SelectedIndex = GetIndexInCombo(mass(0), forms)
        nelzyaO = False
        If objects.SelectedIndex <> GetIndexInCombo(ob.Text, objects) Then
            objects.SelectedIndex = GetIndexInCombo(ob.Text, objects)
        Else
            objects_SelectedIndexChanged(objects, Nothing)
        End If
        If index Is Nothing = False Then indexs.Text = index.Text
        nelzyaP = False
        If propertys.SelectedIndex <> GetIndexInCombo(pr.Text, propertys) Then
            propertys.SelectedIndex = GetIndexInCombo(pr.Text, propertys)
        Else
            propertys_SelectedIndexChanged(propertys, Nothing)
        End If
        If arguments Is Nothing = False And args.Args Is Nothing = False Then
            For i = 0 To args.Args.Length - 1
                If i >= arguments.Length Then Exit For
                args.Args(i).Text = arguments(i)
            Next
        End If
        Return True
    End Function
    Function GetText() As String
        Dim str As String = forms.SelectedItem & "." & objects.SelectedItem
        If indexs.Visible = True Then str &= "[" & indexs.Text & "]"
        str &= "." & propertys.SelectedItem
        str &= args.GetText
        Return str
    End Function
    Function GetProperty() As String
        Return propertys.SelectedItem
    End Function
    Function GetObject() As Object()
        Return objects.SelectedItem
    End Function
    Function GetMyObjs() As Object()
        Return proj.GetMyAllFromName(objects.SelectedItem, , forms.SelectedItem, Pattern.IncludeReadOnly)
    End Function

    Private Sub forms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles forms.SelectedIndexChanged
        Dim i, j As Integer
        objects.Items.Clear() : MyForm = proj.GetMyFormsFromName(forms.SelectedItem)
        If MyForm Is Nothing Then
            Exit Sub
        Else
            For i = 0 To MyForm.Length - 1
                If MyForm(i).MyObjs Is Nothing Then Continue For
                For j = 0 To MyForm(i).MyObjs.Length - 1
                    If objects.Items.IndexOf(MyForm(i).MyObjs(j).obj.Props.name) = -1 Then
                        If Pattern.Show = "Methods" Then
                            If MyForm(i).MyObjs(j).Methods = Nothing Then Continue For
                        End If
                        ' Не показывать при различном IncludeReadOnly некоторые полезные объекты, т.к. у некоторых только свойства для чтения, а у некоторых только методы
                        If Pattern.IncludeReadOnly = False Then
                            'If Iz.IsTextPolezniy(MyForm(i).MyObjs(j)) Then Continue For
                        Else
                            If Iz.IsSobytCalls(MyForm(i).MyObjs(j)) Then Continue For
                        End If
                        objects.Items.Add(MyForm(i).MyObjs(j).obj.Props.name)
                        If Iz.IsCM(MyForm(i).MyObjs(j)) Then
                            objects.Items.Add(MyZnak & trans("Хозяин") & " " & MyForm(i).MyObjs(j).obj.Props.name)
                        End If
                    End If
                Next
            Next
            objects.Items.Add(MyZnak & trans("Объект события"))
            objects.Items.Add(MyZnak & trans("Окно события"))
        End If
        objects.Sorted = True
        proj.lastForm = forms.SelectedItem
        ' Создания значка быстрой справки
        help1.Tag = MainForm.GetHelpLink(forms.Text)
        ' вызвать искуственно разрешенно смену объекта в списке объектов
        SelectedItem(objects)
    End Sub
    Public Sub objects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objects.SelectedIndexChanged
        If nelzyaO Then Exit Sub
        If ProgressForm.Visible = True And ProgressForm.ProgressBarValue < 90 Then Exit Sub
        Dim MyObjs(0) As Object, i As Integer, adds As String : indexs.Items.Clear() : propertys.Items.Clear()
        MyObj = proj.GetMyAllFromName(objects.SelectedItem, , forms.SelectedItem, Pattern.IncludeReadOnly)
        If MyObj Is Nothing Then
            Exit Sub
        Else
            MyObjs = proj.GetMyAllFromName(MyObj(0).obj.Props.name, , forms.SelectedItem, Pattern.IncludeReadOnly)
            ' У полезного объекта Вызвать событие надо загрузить в методы все события
            If MyObjs Is Nothing = False Then
                If Iz.IsSobytCalls(MyObjs(0)) Then MyObjs(0).CreateSobytCalls()
            End If
            If Pattern.Show = "Propertys" Or Pattern.Show = "All" Then
                ' Занести в props все названия свойств выделенных объектов
                Dim props() As String = proj.GetPropertyNames(Pattern.IncludeReadOnly, MyObjs)
                If props Is Nothing = False Then
                    propertys.Items.AddRange(props)
                End If
            End If
            If Pattern.Show = "Methods" Or Pattern.Show = "All" Then
                ' Занести в meths все названия методов, выделенных объектов
                Dim meths() As String = proj.GetMethodNames(MyObjs)
                If meths Is Nothing = False Then propertys.Items.AddRange(meths)
            End If
            ' Если у СОБЫТИЯ есть свойства, которые надо отобразить, то добавить их список свойств
            If MySobyt Is Nothing = False Then
                If MySobyt.Propertys Is Nothing = False And objects.SelectedItem = proj.GetSobytObjObject(0).obj.Props.name Then
                    For i = 0 To MySobyt.Propertys.Length - 1
                        If Array.IndexOf(SobytsNotReadOnly, MySobyt.PropertysUp(i)) = -1 And Pattern.IncludeReadOnly = False Then
                            adds = "  -  [" & trans("есть в мастере сложных действий") & "]" : Else : adds = ""
                        End If
                        propertys.Items.Add(MySobyt.Propertys(i) & adds)
                    Next
                End If
            End If
            ' Происходит когда вызов приходит из главной формы, чтобы добавить свойства событОбъекта
            If sender Is MainForm Then
                nelzyaP = True
                propertys.Sorted = True
                propertys.Sorted = False
                If oldProp Is Nothing Then oldProp = ""
                If propertys.Items.IndexOf(oldProp) <> -1 Then
                    propertys.SelectedItem = oldProp
                Else
                    nelzyaP = False
                    If propertys.Items.Count > 0 Then propertys.SelectedIndex = 0
                End If
                nelzyaP = False : Exit Sub
            End If
        End If

        ' СОРТИРОВКА СВОЙСТВ
        propertys.Sorted = True
        propertys.Sorted = False
        'Dim prps() As String = proj.GetPropertyNames(Pattern.IncludeReadOnly, MyObjs)
        'If prps Is Nothing = False Then
        '    For i = 0 To Array.IndexOf(prps, trans("Имя")) - 1
        '        propertys.Items.Remove(prps(i))
        '        propertys.Items.Insert(i, prps(i))
        '    Next
        'End If

        If MyObjs.Length > 1 _
        And objects.SelectedItem <> MyZnak & trans("Объект события") _
        And objects.SelectedItem <> MyZnak & trans("Окно события") Then
            For i = 0 To MyObjs.Length - 1 : indexs.Items.Add("""" & MyObjs(i).obj.Props.index & """") : Next
            ' indexs.Items.Add(trans("Все"))
            indexs.Visible = True : Palka1.Visible = True : Label3.Visible = True : help3.Visible = True
            Label4.Top = indexs.Top + indexs.Height
            help4.Top = indexs.Top + indexs.Height
            propertys.Top = Label4.Top + Label4.Height
        Else
            indexs.Visible = False : Palka1.Visible = False : Label3.Visible = False : help3.Visible = False
            Label4.Top = Label3.Top
            help4.Top = Label3.Top
            propertys.Top = indexs.Top
        End If
        ' запись этот объект в форму, как последнее выбранное для него свойство
        If MyForm Is Nothing = False Then
            For i = 0 To MyForm.length - 1
                MyForm(i).obj.lastObj = objects.Text
            Next
        End If

        SelectedItem(indexs) : SelectedItem(propertys)
        RaiseEvent ObjectChange(objects.SelectedItem)
        oldObj = objects.SelectedItem

        ' Создания значка быстрой справки
        help2.Tag = MainForm.GetHelpLink(objects.Text)
        help3.Tag = MainForm.GetHelpLink(forms.Text & "." & objects.Text & "." & propertys.Text)

        Dim forma As Object = Me.TopLevelControl
        If forma Is Nothing = False Then forma.InfoPropsShow(propertys.Text, proj.GetMyAllFromName(objects.Text, , forms.Text))
    End Sub
    Sub SelectedItem(ByVal combo As ComboBox)
        Dim old As String
        If combo.Items.Count = 0 Then Exit Sub
        If combo Is forms Then
            If proj.lastForm IsNot Nothing Then
                old = proj.lastForm
            Else
                old = oldForm
            End If
        End If
        If combo Is objects Then
            ' В разделе действий формы, будет в списке свойств сначала то свойство, что было у ПРЕДЫДУЩЕГО объекта
            ' а если такого нет, то то что было последним у ЭТОГО объекта.
            If Me.TopLevelControl Is MainForm Then
                old = oldObj
                If old = Nothing Then old = trans("Окно") & "1"
                If old = "" Or combo.Items.IndexOf(old) = -1 Then old = MyForm(0).obj.lastObj
                ' В мастере сначала выбирается свойство которое в последний раз выбиралось для ЭТОГО объекта
            Else
                If MyForm IsNot Nothing Then
                    old = MyForm(0).obj.lastObj
                End If
                If old = Nothing Then old = ""
                If old = "" Or combo.Items.IndexOf(old) = -1 Then old = oldObj
            End If
        End If
        If combo Is indexs Then old = oldInd
        If combo Is propertys Then
            ' В разделе действий формы, будет в списке свойств сначала то свойство, что было у ПРЕДЫДУЩЕГО объекта
            ' а если такого нет, то то что было последним у ЭТОГО объекта.
            '   If Me.TopLevelControl Is MainForm Then
            old = oldProp
            If old = Nothing Then old = ""
            If old = "" Or combo.Items.IndexOf(old) = -1 Then old = MyObj(0).obj.lastProp : odinak = False
            ' В мастере сначала выбирается свойство которое в последний раз выбиралось для ЭТОГО объекта
            'Else
            '    old = MyObj(0).obj.lastProp
            '    If old = Nothing Then old = ""
            '    If old = "" Or combo.Items.IndexOf(old) = -1 Then old = oldProp : odinak = False
            'End If
        End If
        If old = Nothing Then old = ""
        If old <> "" And combo.Items.IndexOf(old) <> -1 Then
            'Dim nel As Boolean = nelzyaP
            combo.SelectedItem = old
        Else
            If combo Is objects Then
                If combo.Items.Count > 2 Then combo.SelectedIndex = 2 Else combo.SelectedIndex = 0
            Else
                combo.SelectedIndex = 0
            End If
        End If
        odinak = False
        ComboBoxWidth(combo)
    End Sub
    Dim odinak As Boolean
    Private Sub comboBoxs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles propertys.KeyDown, objects.KeyUp, forms.KeyUp, indexs.KeyUp
        If e.KeyData = Keys.Escape Then
            Dim masterForm As New Master(Nothing, True)
            If Me.TopLevelControl.GetType Is masterForm.GetType Then
                Dim bl As New Blok(Nothing, True), obj As Object = Me.Parent
                While obj Is Nothing = False
                    If obj.GetType Is bl.GetType Then obj.Remove1_Click(Nothing, Nothing) : Exit Sub
                    obj = obj.parent
                End While
            End If
        End If
    End Sub
    Private Sub propertys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles propertys.SelectedIndexChanged
        If nelzyaP Then Exit Sub
        If odinak Then Exit Sub
        If propertys.SelectedItem Is Nothing Then Exit Sub
        If propertys.SelectedItem.IndexOf(" - ") <> -1 Then
            MainForm.ShowUved(propertys.SelectedItem)
            nelzyaP = True
            propertys.SelectedItem = oldProp
            nelzyaP = False : Exit Sub
        End If
        ' запись этого свойства в объект, как последнее выбранное для него свойство
        Dim i As Integer
        If MyObj Is Nothing = False Then
            For i = 0 To MyObj.length - 1
                MyObj(i).obj.lastProp = propertys.Text
            Next
        End If
        ' Чтобы текстовое поле со значением свойства не менялось, если тип свойства и т.п. осталось прежним
        If propertys.SelectedItem <> "" Then
            If oldProp <> propertys.SelectedItem Or _
            ((oldForm <> forms.SelectedItem Or oldObj <> objects.SelectedItem) And UCase(MainForm.Create1.Text) <> UCase(trans("Изменить"))) Then
                If proj.isProperty(propertys.SelectedItem) <> "" Then
                    Dim temp() As String = GetArguments(propertys.SelectedItem, MyObj)
                    If temp Is Nothing = False Then
                        temp(temp.Length - 1) = Nothing
                    End If
                    args.ShowArgs(temp, MyObj, propertys.Text)
                    forArgs.Top = propertys.Top + propertys.Height + 3
                Else
                    args.ShowArgs(GetArguments(propertys.SelectedItem, MyObj), MyObj, propertys.Text)
                    forArgs.Top = propertys.Top + propertys.Height + 3
                End If
                RaiseEvent PropertyChange(propertys.SelectedItem, oldProp, MyObj)
            End If
        End If
        RaiseEvent SizeChanged(Me, Nothing) : Me.Refresh()
        oldProp = propertys.SelectedItem

        ' Создания значка быстрой справки
        help4.Tag = MainForm.GetHelpLink(forms.Text & "." & objects.Text & "." & propertys.Text)

        Dim forma As Object = Me.TopLevelControl
        If forma Is Nothing = False Then forma.InfoPropsShow(propertys.Text, MyObj)
    End Sub
    Private Sub ShowObject_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        Label1.ForeColor = Me.ForeColor
        Label2.ForeColor = Me.ForeColor
        Label3.ForeColor = Me.ForeColor
        Label4.ForeColor = Me.ForeColor
    End Sub
    Private Sub ShowObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = transInfc(Label1.Text) : Label2.Text = transInfc(Label2.Text)
        Label3.Text = transInfc(Label3.Text) : Label4.Text = transInfc(Label4.Text)
        forms.ForeColor = ColObject
        objects.ForeColor = colObject
        propertys.ForeColor = colProperty
        args.Dock = DockStyle.Top
        forArgs.Controls.Add(args)
        Palka1.RefreshPic(SkinPictures)
    End Sub
    Private Sub indexs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles indexs.SelectedIndexChanged
        oldInd = indexs.SelectedItem
    End Sub

    Private Sub Palka1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Palka1.click
        Dim master As New Master(New MasterPattern(indexs))
        master.ShowDialog(Me.TopLevelControl)
    End Sub
    Private Sub ShowObject_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If border > 0 Then
            e.Graphics.DrawRectangle(New Pen(colBorder, border), New Rectangle(border / 2, border / 2, Me.Width - border, Me.Height - border))
        End If
    End Sub

 
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()


        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        help1.Image = Pictures32.Images("HelpMenu") : AddHandler help1.Click, AddressOf MainForm.Helps_Click
        help2.Image = Pictures32.Images("HelpMenu") : AddHandler help2.Click, AddressOf MainForm.Helps_Click
        help3.Image = Pictures32.Images("HelpMenu") : AddHandler help3.Click, AddressOf MainForm.Helps_Click
        help4.Image = Pictures32.Images("HelpMenu") : AddHandler help4.Click, AddressOf MainForm.Helps_Click
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = help1
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = help2
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = help3
        ReDim Preserve HelpObjs(HelpObjs.Length) : HelpObjs(HelpObjs.Length - 1) = help4

    End Sub
End Class
