Public Structure MySplitStruct
    Public splity(), texty() As String
    Public indexy() As Integer
    Sub New(ByVal splits() As String, ByVal texts() As String)
        splity = splits : texty = texts
    End Sub
    Sub New(ByVal nennuzhnaya_peremennaya As Boolean, ByVal ParamArray texts() As String)
        texty = texts : ReDim indexy(0) : indexy(0) = 0
    End Sub
    Sub New(ByVal splits() As String, ByVal texts() As String, ByVal indexs() As Integer)
        splity = splits : texty = texts : indexy = indexs
    End Sub
    Sub New(ByVal texts As String)
        ReDim splity(0) : splity(0) = 0 : ReDim texty(0) : texty(0) = texts : ReDim indexy(0) : indexy(0) = 0
    End Sub
End Structure

Public Class CodeString
    Dim txt As String
    Dim withFormating As Boolean = True
    Dim Razdeliteli As String
    Dim splits() As String

    Public Sub New(ByVal str As String, Optional ByVal Razdeliteli As String = "All", Optional ByVal withFormating As Boolean = True)
        Me.withFormating = withFormating
        Me.Razdeliteli = Razdeliteli

        If Razdeliteli.IndexOf("All") = 0 Then
            ' splits = uslovs
            ' withUslovie = True
            ' ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = ","
            'Text = str

            splits = uslovs
            ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = ","
            ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = "("
            ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = ")"
            ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = "["
            ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = "]"
            If Razdeliteli = "AllWithAndOr" Then
                ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = "And"
                ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = "Or"
            End If
            Text = str 'Text
        ElseIf Razdeliteli = "Uslovs" Or Razdeliteli = "True" Then
            splits = uslovs
            ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = ","
            Text = str
        ElseIf Razdeliteli = "UslovsBezZapyatoi" Then
            splits = uslovs
            Text = str
        ElseIf Razdeliteli = "Opers" Or Razdeliteli = "False" Then
            splits = opers
            ReDim Preserve splits(splits.Length) : splits(splits.Length - 1) = ","
            Text = str
        ElseIf Razdeliteli = "<=> and high" Then
            ReDims(splits) : splits(splits.Length - 1) = "<=>"
            ReDims(splits) : splits(splits.Length - 1) = "And"
            ReDims(splits) : splits(splits.Length - 1) = "Or"
            Text = str
        ElseIf Razdeliteli = "None" Then
            txt = str
        Else
            Exit Sub
        End If
    End Sub
    Public Property Text() As String
        Get
            Return txt
        End Get
        Set(ByVal value As String)
            txt = value
            If withFormating Then AutoKovichki()
        End Set
    End Property
    ' АВТОМАТИЧЕСКИ ПОСТАВИТ ПО КРАЯМ КОВЫЧКИ, ТАМ, ГДЕ НАДО
    Public Sub AutoKovichki()
        Dim i As Integer, str As String = "", actStr As String, indStr As Integer
        Dim splt As MySplitStruct
        'If proj.isString(txt) = False Then
        splt = Split("vezde")
        'Else
        'splt = Split(txt & txt)
        'End If
        For i = 0 To splt.texty.Length - 1
            ' Если первый символ кавычка, то расставлять больше ничего не надо
            If splt.texty(i) <> "" Then
                actStr = splt.texty(i) : indStr = 0
                ' If splt.texty.Length > 1 Then
                'If (splt.texty(i).Chars(0) = "(" Or splt.texty(i).Chars(splt.texty(i).Length - 1) = ")") Then
                '    Dim m As System.Text.RegularExpressions.Match
                '    m = System.Text.RegularExpressions.Regex.Match(splt.texty(i), "[^(].*")
                '    indStr += m.Index
                '    m = System.Text.RegularExpressions.Regex.Match(m.Value, ".*[^)]")
                '    actStr = Trim(m.Value) : indStr += m.Index
                '    ' записать, очищенную от пробелов активную строку (actStr)
                '    splt.texty(i) = splt.texty(i).Substring(0, indStr) & actStr & splt.texty(i).Substring(indStr + 1 + m.Length - 1)
                'End If
                ' End If
                If IsNumeric(actStr) = False Then
                    If proj.isString(actStr) Then
                        Dim trimChrs() As Char = {"(", ")", "[", "]", " "}
                        Dim temp As String = actStr.Trim(trimChrs)
                        If temp <> "" Then
                            If temp.Chars(0) <> """" Or temp.Chars(temp.Length - 1) <> """" Then
                                ' записать, исправленную от нечетных кавычек активную строку (actStr)
                                splt.texty(i) = splt.texty(i).Replace(actStr, CreateKovich(actStr))
                                actStr = CreateKovich(actStr)
                                splt.texty(i) = splt.texty(i).Insert(indStr, """")
                                splt.texty(i) = splt.texty(i).Insert(indStr + actStr.Length + 1, """")
                            End If
                        End If
                    End If
                End If
                str &= splt.texty(i)
            End If
            If splt.splity Is Nothing = False Then
                If i < splt.splity.Length Then
                    If splt.splity(i) = "," Then
                        str &= splt.splity(i) & " "
                    ElseIf splt.splity(i) = "(" Or splt.splity(i) = ")" Or splt.splity(i) = "[" Or splt.splity(i) = "]" Then
                        str &= splt.splity(i)
                    Else
                        str &= " " & splt.splity(i) & " "
                    End If
                End If
            End If
        Next
        txt = str
    End Sub
    Function PerviyNeSkobka(ByVal str As String) As Integer
        Dim i As Integer
        For i = 0 To str.Length - 1
            If str(i) <> "(" Then Return i
        Next
        Return 0
    End Function
    Function PosledniyNeSkobka(ByVal str As String) As Integer
        Dim i As Integer
        For i = str.Length - 1 To 0 Step -1
            If str(i) <> ")" Then Return i
        Next
        Return 0
    End Function
    Public Function IndexOf(ByVal str As String, Optional ByVal start As Integer = 0, Optional ByVal naOdnomUrovne As Boolean = False) As Integer
        Dim ind As Integer = start
        If txt = "" Then Return -1
        While ind <= txt.Length - 1
            ' Если желают искать только на первом уровне скобок, а встретился новый уровень, то пропустить все его внутренности
            If txt(ind) = "(" And naOdnomUrovne Then
                ind = PropuskSkobok(ind, "(", ")")
            ElseIf txt(ind) = "[" And naOdnomUrovne Then
                ind = PropuskSkobok(ind, "[", "]")
            ElseIf (txt(ind) = ")" Or txt(ind) = "]") And naOdnomUrovne Then
                Return -1
            End If
            If ind = -1 Then Return -1
            ' Если встретилась кавычка то пропустить все ее внутренности
            If txt(ind) = """" Then
                ind = PropuskKovich(ind)
                If ind = -1 Then Return -1
            End If
            If ind > Text.Length - 1 Then Return -1
            If str.Length - 1 > txt.Length - 1 - ind Then Return -1
            If UCase(txt.Substring(ind, str.Length)) = UCase(str) Then Return ind
            ind += 1
        End While

        Return -1
    End Function
    Public Function LastIndexOf(ByVal str As String, Optional ByVal start As Integer = 0, Optional ByVal naOdnomUrovne As Boolean = False) As Integer
        If start = 0 Then start = str.Length
        If txt = "" Then Return -1
        ' ОЧЕНЬ СТРАННО! ПОЧЕМУ Я ВЫЧИТЮ ЗДЕСЬ? ОН ИЩЕТ НЕ С ТОГО ИНДЕКСА С КОТОРОГО НАДО!
        Dim ind As Integer = txt.Length - start
        While ind > -1
            ' Если желают искать только на первом уровне скобок, а встретился новый уровень, то пропустить все его внутренности
            If txt(ind) = ")" And naOdnomUrovne Then
                ind = PropuskSkobokLast(ind, ")", "(")
            ElseIf txt(ind) = "]" And naOdnomUrovne Then
                ind = PropuskSkobokLast(ind, "]", "[")
            ElseIf (txt(ind) = "(" Or txt(ind) = "[") And naOdnomUrovne Then
                Return -1
            End If
            If ind = -1 Then Return -1
            ' Если встретилась кавычка то пропустить все ее внутренности
            If txt(ind) = """" Then
                ind = PropuskKovichLast(ind)
                If ind = -1 Then Return -1
            End If
            If UCase(txt.Substring(ind, str.Length)) = UCase(str) Then Return ind
            ind -= 1
        End While

        Return -1
    End Function
    Function PropuskSkobok(ByVal ind As Integer, ByVal skobkaOpen As String, ByVal skobkaClose As String)
        Dim vlozen As Integer = 1, skobka1, skobka2 As Integer
        Do
            If ind + 1 > txt.Length - 1 Then Return -1
            skobka1 = IndexOf(skobkaOpen, ind + 1)
            skobka2 = IndexOf(skobkaClose, ind + 1)
            If skobka2 = -1 Then Return -1
            If skobka1 = -1 Then skobka1 = txt.Length
            If skobka1 < skobka2 Then
                vlozen += 1 : ind = skobka1
            Else
                vlozen -= 1 : ind = skobka2
            End If
            If vlozen <= 0 Then Return skobka2
        Loop
        'Return ind
    End Function
    Function PropuskSkobokLast(ByVal ind As Integer, ByVal skobkaOpen As String, ByVal skobkaClose As String)
        Dim vlozen As Integer = 1, skobka1, skobka2 As Integer
        Do
            If ind - 1 < 0 Then Return -1
            skobka1 = LastIndexOf(skobkaOpen, ind - 1)
            skobka2 = LastIndexOf(skobkaClose, ind - 1)
            If skobka2 = -1 Then Return -1
            If skobka1 = -1 Then skobka1 = 0
            If skobka1 < skobka2 Then
                vlozen += 1 : ind = skobka1
            Else
                vlozen -= 1 : ind = skobka2
            End If
            If vlozen <= 0 Then Return skobka2
        Loop
        'Return ind
    End Function
    Function PropuskKovich(ByVal ind As Integer) As Integer
        Dim kovi4ka1, kovi4ka2 As Integer
        ' Просматриваем все открывающиеся кавычки
        kovi4ka1 = ind
        ' Ищем закрывающуюся кавычку
        kovi4ka2 = txt.IndexOf("""", kovi4ka1 + 1)
        ' Если эта кавычка не последний символ в строке
        If kovi4ka2 + 1 < txt.Length - 1 Then
            ' Если это две подряд кавычки, то ищем одинарную
            While txt.Chars(kovi4ka2 + 1) = """"
                kovi4ka2 = txt.IndexOf("""", kovi4ka2 + 2)
                If kovi4ka2 = -1 Then Return -1
                If kovi4ka2 + 1 > txt.Length - 1 Then Exit While
            End While
        End If
        If kovi4ka2 <= kovi4ka1 Then Return -1
        Return kovi4ka2
    End Function
    Function PropuskKovichLast(ByVal ind As Integer) As Integer
        Dim kovi4ka1, kovi4ka2 As Integer
        ' Просматриваем все открывающиеся кавычки
        kovi4ka1 = ind
        ' Ищем закрывающуюся кавычку
        kovi4ka2 = txt.LastIndexOf("""", kovi4ka1 - 1)
        ' Если эта кавычка не последний символ в строке
        If kovi4ka2 > 1 Then
            ' Если это две подряд кавычки, то ищем одинарную
            While txt.Chars(kovi4ka2 - 1) = """"
                kovi4ka2 = txt.LastIndexOf("""", kovi4ka2 - 2)
                If kovi4ka2 = -1 Then Return -1
                If kovi4ka2 < 2 Then Exit While
            End While
        End If
        If kovi4ka2 >= kovi4ka1 Then Return -1
        Return kovi4ka2
    End Function
    Function Split(ByVal naUrovne As String, ByVal ParamArray spl() As String) As MySplitStruct
        Dim kovi4ka2, skobka2 As Integer, bilInd As Integer = -1
        Dim ind = 0, lastInd = 0, lev2popravka = 0, lev2ind = 0, i As Integer
        Dim splity() As String = Nothing
        Dim texty() As String = Nothing
        Dim indexy() As Integer = Nothing
        Dim newSplit As String = ""
        Dim newText As String = ""
        Dim VtoroyLev As Boolean = False
        Dim NePribavlyat As Boolean = False
        If spl.Length = 0 Then spl = splits
        If spl Is Nothing Then spl = New String() {"~)!(@*#&$^%A:SLDK"}
        While ind <= txt.Length - 1
            ' Если вначале кавычка
            If txt(ind) = """" Then
                kovi4ka2 = PropuskKovich(ind)
                If kovi4ka2 <> -1 Then ind = kovi4ka2 + 1
            End If
            '"Imports System¶Imports System.Windows.Forms¶'Класс MainClass и функция Main должны обязательно присутствовать¶Public Class MainClass ¶    Public Function Main() As Object¶        Clipboard.SetText("" = "" &" & 1 & ")¶    End Function¶End Class")
            If ind > txt.Length - 1 Then Exit While
            If naUrovne = "naOdnomUrovne" Or (naUrovne = "naVtoromUrovne" And VtoroyLev) Then
                If txt(ind) = "(" Or (txt(ind) = "," And spl(0) <> "." And spl(0) <> "," And spl(0) <> "~)!(@*#&$^%A:SLDK") Then
                    ' Если это дополнительная функция типа "корень"
                    'If Array.IndexOf(DopFunsSimple, Trim(UCase(Left(txt, ind)))) <> -1 And bilInd <> ind Then
                    'newText = Trim(Left(txt, ind)) : newSplit = ""
                    'txt = " " & txt.Substring(ind - 1) : ind = 0 : lastInd = 0
                    'Else
                    If txt(ind) = "," Then
                        newText = Trim(txt.Substring(lastInd, ind - lastInd)) : newSplit = ","
                    Else
                        skobka2 = PropuskSkobok(ind, "(", ")")
                        If skobka2 <> -1 Then ind = skobka2 + 1 : NePribavlyat = True
                    End If
                    'End If
                ElseIf txt(ind) = "[" Then
                    skobka2 = PropuskSkobok(ind, "[", "]")
                    If skobka2 <> -1 Then ind = skobka2 + 1
                ElseIf txt(ind) = ")" Or txt(ind) = "]" Then
                    If naUrovne = "naVtoromUrovne" Then
                        lev2popravka = txt.Length - ind : VtoroyLev = False : ind += 1 : NePribavlyat = True
                    Else
                        Exit While
                    End If
                End If
            ElseIf naUrovne = "naVtoromUrovne" And VtoroyLev = False Then
                If txt(ind) = "(" Or txt(ind) = "[" Then
                    lev2ind += ind + 1
                    txt = txt.Substring(ind + 1)
                    lastInd = 0
                    VtoroyLev = True
                    ind = 0 : Continue While
                Else
                    ' Если на втором уровне несколько скобок, и эта похоже не последняя
                    If lev2popravka = 0 Then ind += 1 : Continue While
                End If
            End If
            If ind > txt.Length - 1 Then Exit While
            ' If txt(ind) = ")" Or txt(ind) = "]" Then
            'If naUrovne = "naVtoromUrovne" Then lev2popravka = txt.Length - ind
            'End If
            If txt(ind) = """" Then
                kovi4ka2 = PropuskKovich(ind)
                ' Если вторая кавычка не найдена
                'If kovi4ka2 = -1 Then
                ' If texty Is Nothing Then
                ' ReDim Preserve texty(0)
                'Else
                '    ReDim Preserve texty(texty.Length)
                'End If
                'texty(texty.Length - 1) = txt.Substring(lastInd, txt.Length - 1 - lastInd)
                'End If
                If kovi4ka2 <> -1 Then ind = kovi4ka2
            End If
            If ind > txt.Length - 1 Then Exit While

            If newSplit = "" And newText = "" And (VtoroyLev = False Or (VtoroyLev And naUrovne = "naVtoromUrovne" And spl(0) = "<=>")) Then
                For i = 0 To spl.Length - 1
                    If spl(i).Length - 1 > txt.Length - 1 - ind Then Continue For
                    If UCase(txt.Substring(ind, spl(i).Length)) = UCase(spl(i)) Then
                        If newSplit <> "" And newText <> "" Then
                            If spl(i).Length < newSplit.Length Then Continue For
                        End If

                        ' Если _И и _ИЛИ это не ключевое слово, а ЧАСТЬ ТЕКСТА
                        If UCase(spl(i)) = UCase(MyZnak & trans("И")) Or UCase(spl(i)) = UCase(MyZnak & trans("ИЛИ")) _
                        Or (UCase(spl(i)) = MyZnak & UCase("And") Or UCase(spl(i)) = MyZnak & UCase("Or")) _
                        Then
                            If txt.Length > ind + spl(i).Length And ind > 0 Then
                                If (Char.IsLetterOrDigit(txt(ind + spl(i).Length)) Or txt(ind + spl(i).Length) = "_") _
                                Or (Char.IsLetterOrDigit(txt(ind - 1)) Or txt(ind - 1) = "_") Then
                                    Continue For
                                End If
                            ElseIf txt.Length >= ind + spl(i).Length And ind > 0 Then
                                If Char.IsLetterOrDigit(txt(ind - 1)) Or txt(ind - 1) = "_" Then Continue For
                            End If
                            ' Есть особая ситуация (посткомпиляциионные расставления UCase),
                            ' когда надо чтобы искались слова And и Or без MyZnak.
                            ' Благо все слова типо "files and path" уже в кавычках
                        ElseIf (UCase(spl(i)) = UCase("And") Or UCase(spl(i)) = UCase("Or")) Then
                            If Razdeliteli <> "<=> and high" And Razdeliteli <> "AllWithAndOr" Then
                                Continue For
                            Else
                                ' Тут нужно аккуратно узнать часть слова ли And и Or или нет
                                If txt.Length > ind + spl(i).Length And ind > 0 Then
                                    If (Char.IsLetterOrDigit(txt(ind + spl(i).Length)) Or txt(ind + spl(i).Length) = "_") _
                                    Or (Char.IsLetterOrDigit(txt(ind - 1)) Or txt(ind - 1) = "_") Then
                                        Continue For
                                    End If
                                ElseIf txt.Length >= ind + spl(i).Length And ind > 0 Then
                                    If Char.IsLetterOrDigit(txt(ind - 1)) Or txt(ind - 1) = "_" Then Continue For
                                End If
                                ' Если AND это часть Files and path
                                Dim FndFls As Integer = txt.IndexOf(MyZnak & trans("Файлы и папки", True))
                                If FndFls <> -1 And ind < FndFls + (MyZnak & trans("Файлы и папки", True)).Length Then
                                    Continue For
                                End If
                            End If

                        End If

                        newSplit = spl(i)
                        If lev2popravka = 0 Then
                            newText = txt.Substring(lastInd, ind - lastInd)
                        ElseIf (txt.Length - lev2popravka) - lastInd >= 0 Then
                            newText = txt.Substring(lastInd, (txt.Length - lev2popravka) - lastInd) : lev2popravka = 0
                        End If
                        ' Если знак обозначает положительное или отрицательное это число, то не считать его за сплит
                        If (newSplit = "-" Or newSplit = "+") And Trim(newText) = "" Then
                            If splity Is Nothing = False Then
                                If Array.IndexOf(uslovs, splity(splity.Length - 1)) <> -1 Then
                                    newSplit = "" : newText = "" : Exit For
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            If newSplit <> "" Or newText <> "" Then
                ReDims(splity) : splity(splity.Length - 1) = UCase(Trim(newSplit))
                ReDims(texty) : texty(texty.Length - 1) = Trim(newText)
                ReDims(indexy) : indexy(indexy.Length - 1) = lastInd + lev2ind
                lastInd = ind + newSplit.Length : newSplit = "" : newText = ""
                bilInd = ind : ind = lastInd - 1
            End If
            ind += 1
            If NePribavlyat And spl(0) <> "," Then ind -= 1 : NePribavlyat = False
        End While

        newText = txt.Substring(lastInd, txt.Length - lastInd - lev2popravka)
        ReDims(texty) : texty(texty.Length - 1) = Trim(newText)
        ReDims(indexy) : indexy(indexy.Length - 1) = lastInd + lev2ind

        Return New MySplitStruct(splity, texty, indexy)
    End Function
    Sub temp()
        Dim kovi4ka1, kovi4ka2, ind, texty, lastInd

        ' Просматриваем все открывающиеся кавычки
        kovi4ka1 = ind
        ' Ищем закрывающуюся кавычку
        kovi4ka2 = txt.IndexOf("""", kovi4ka1 + 1)
        If kovi4ka2 = -1 Then
            'txt = txt.Insert(kovi4ka1, """""")
            kovi4ka2 = kovi4ka1 '+ 2
        End If
        ' Если эта кавычка не последний символ в строке
        If kovi4ka2 + 1 < txt.Length - 1 Then
            ' Если это две подряд кавычки, то ищем одинарную
            While txt.Chars(kovi4ka2 + 1) = """"
                kovi4ka2 = txt.IndexOf("""", kovi4ka2 + 2)
                If kovi4ka2 + 1 >= txt.Length - 1 Or kovi4ka2 = -1 Then Exit While
            End While
        End If
        If kovi4ka2 = -1 Then
            'txt = txt.Insert(kovi4ka1, """""")
            kovi4ka2 = kovi4ka1
        End If
        ' Если вторая кавычка не найдена
        If kovi4ka2 < kovi4ka1 Then
            If texty Is Nothing Then
                ReDim Preserve texty(0)
            Else
                ReDim Preserve texty(texty.Length)
            End If
            texty(texty.Length - 1) = txt.Substring(lastInd, txt.Length - 1 - lastInd)
        End If
        ind = kovi4ka2
    End Sub
End Class
