Public Module HelpsHTML
    Public Hlps As New Helps  ' Папка с проектами
End Module
Public Delegate Function GetAlls(ByVal xmlTxt As String, ByVal ob As Object) As String

Public Class Helps
    ' Переменные, задающие XSLT-преобразование xml-файлов в html-файлы
    Dim templFils As String = "_TemplateMSDN_files"
    Dim templXsl As String = "\_TemplateMSDN.xsl"
    Dim templXslMenu As String = "\_TemplateMenu.xsl"
    Dim LangNameH As String = lang_name
    Dim xs As New Xml.Xsl.XslCompiledTransform
    Dim xsMenu As New Xml.Xsl.XslCompiledTransform
    Dim Menu As String = "<?xml version=""1.0"" encoding=""UTF-8""?>" & vbCrLf & "<menu>" & vbCrLf
    Dim counter As Integer = 0
    Dim php As String = "" '"index.php?page="
    Dim onlyMenu As Boolean = True

    Sub New()
        LanguagePath = "D:\DOCUMENTS\Visual Studio Projects\VB8 проекты\Algoritm 2\Slot\bin\Debug\Data\Languages\"
        setLangs()
    End Sub
    Sub New(ByVal xmlp As String, ByVal hlpp As String, ByVal tmplfs As String, ByVal LangPath As String, ByVal LangName As String)
        LanguagePath = LangPath : lang_name = LangName : setLangs()
        XMLpath = xmlp : HelpPath = hlpp
    End Sub
    'Sub langs()
    '    ' Задание языка
    '    lang = Get2List(LanguagePath & lang_name & "\" & lang_name & ".lng", "~~", , True)
    '    langENG = Get2List(LanguagePath & "\English\English.lng", "~~", , True)
    'End Sub
    

    ' ФУНКЦИЯ СОЗДАНИЯ ПОЛНОЙ СПРАВКИ АЛГОРИТМА

    Dim xlmFile As String
    Sub CreateHelp()
        ' Загрузка XSLT-преобразования
        Dim xsSeting As New Xml.Xsl.XsltSettings(True, True)
        xs.Load(XMLpath & templXsl, xsSeting, Nothing)
        Dim xsSetingMenu As New Xml.Xsl.XsltSettings(True, True)
        xsMenu.Load(XMLpath & templXslMenu, xsSetingMenu, Nothing)

        Dim htm As Xml.XmlTextWriter
        Dim args As New Xml.Xsl.XsltArgumentList()
        Dim xd As Xml.XmlDocument
        Dim titl As String

        Try
            ' Страница ПРИВЕТСВИЯ
            xlmFile = XMLpath & "\Introduce.xml"
            If IO.File.Exists(xlmFile) Then
                ' Выходной html-файл
                htm = New Xml.XmlTextWriter(HelpPath & "\Introduce.html", Encoding.UTF8)
                ' Аргументы
                args = New Xml.Xsl.XsltArgumentList()
                args.AddParam("msdnTemp", "", templFils)
                args.AddParam("php", "", php)
                ' Создание раздела в меню
                xd = New Xml.XmlDocument() : xd.Load(XMLpath & "\Introduce.xml")
                titl = xd.CreateNavigator().SelectSingleNode("//xml/file/title").Value : counter += 1
                Menu &= "<node title=""" & titl & """ file=""Introduce.html"" icon=""Icons/Algoritm.ico"" id=""" & counter & """/>" & vbCrLf
                ' Выполнить преобразование xml-файла в html-файл
                xs.Transform(XMLpath & "\Introduce.xml", args, htm)
                htm.Close()
            Else
                MsgBox("ПРИВЕТСВИЕ - не найдено. Пропущено")
            End If


            ' Страница МОЙ ПЕРВЫЙ ПРОЕКТ
            xlmFile = XMLpath & "\First.xml"
            If IO.File.Exists(xlmFile) Then
                ' Выходной html-файл
                htm = New Xml.XmlTextWriter(HelpPath & "\First.html", Encoding.UTF8)
                ' Аргументы
                args = New Xml.Xsl.XsltArgumentList()
                args.AddParam("msdnTemp", "", templFils)
                args.AddParam("php", "", php)
                ' Открыть xml-документ чтобы считать его и изменить уже в оперативной памяти, и xsl-трансформировать уже измененный
                xd = New Xml.XmlDocument() : xd.Load(xlmFile)
                ' Создание раздела в меню
                titl = xd.CreateNavigator().SelectSingleNode("//xml/file/title").Value : counter += 1
                Menu &= "<node title=""" & titl & """ file=""First.html"" icon=""Icons/Book.png"" id=""" & counter & """>" & vbCrLf
                ' Выполнить преобразование xml-файла в html-файл
                xs.Transform(WriteNewXml(GetAllFirst(xd.OuterXml)), args, htm)
                htm.Close() : Menu &= "</node>" & vbCrLf
            Else
                MsgBox("МОЙ ПЕРВЫЙ ПРОЕКТ - не найдено. Пропущено")
            End If

            xlmFile = XMLpath & "\Environment.xml"
            If IO.File.Exists(xlmFile) Then
                ' Выходной html-файл
                htm = New Xml.XmlTextWriter(HelpPath & "\Environment.html", Encoding.UTF8)
                ' Аргументы
                args = New Xml.Xsl.XsltArgumentList()
                args.AddParam("msdnTemp", "", templFils)
                args.AddParam("php", "", php)
                ' Открыть xml-документ чтобы считать его и изменить уже в оперативной памяти, и xsl-трансформировать уже измененный
                xd = New Xml.XmlDocument() : xd.Load(XMLpath & "\Environment.xml")
                ' Создание раздела в меню
                titl = xd.CreateNavigator().SelectSingleNode("//xml/file/title").Value : counter += 1
                Menu &= "<node title=""" & titl & """ file=""Environment.html"" icon=""Icons/Book.png"" id=""" & counter & """>" & vbCrLf
                ' Выполнить преобразование xml-файла в html-файл
                xs.Transform(WriteNewXml(GetAllEnvironment(xd.OuterXml)), args, htm)
                htm.Close() : Menu &= "</node>" & vbCrLf
            Else
                MsgBox("СРЕДА РАЗРАБОТКИ - не найдено. Пропущено")
            End If

            ' Страница ВСЕ ОБЪЕКТЫ
            xlmFile = XMLpath & "\Objects.xml"
            If IO.File.Exists(xlmFile) Then
                ' Выходной html-файл
                htm = New Xml.XmlTextWriter(HelpPath & "\Objects.html", Encoding.UTF8)
                ' Аргументы
                args = New Xml.Xsl.XsltArgumentList()
                args.AddParam("msdnTemp", "", templFils)
                args.AddParam("php", "", php)
                ' Открыть xml-документ чтобы считать его и изменить уже в оперативной памяти, и xsl-трансформировать уже измененный
                xd = New Xml.XmlDocument() : xd.Load(XMLpath & "\Objects.xml")
                ' Создание раздела в меню
                titl = xd.CreateNavigator().SelectSingleNode("//xml/file/title").Value : counter += 1
                Menu &= "<node title=""" & titl & """ file=""Objects.html"" icon=""Icons/Book.png"" id=""" & counter & """>" & vbCrLf
                ' Выполнить преобразование xml-файла в html-файл
                xs.Transform(WriteNewXml(GetAllObjs(xd.OuterXml)), args, htm)
                htm.Close() : Menu &= "</node>" & vbCrLf
            Else
                MsgBox("ОБЪЕКТЫ - не найдено. Пропущено")
            End If

            ' Страница ВСЕ ПОЛЕЗНЫЕ ОБЪЕКТЫ
            xlmFile = XMLpath & "\UsefulObjects.xml"
            If IO.File.Exists(xlmFile) Then
                ' Выходной html-файл
                htm = New Xml.XmlTextWriter(HelpPath & "\UsefulObjects.html", Encoding.UTF8)
                ' Аргументы
                args = New Xml.Xsl.XsltArgumentList()
                args.AddParam("msdnTemp", "", templFils)
                args.AddParam("php", "", php)
                ' Открыть xml-документ чтобы считать его и изменить уже в оперативной памяти, и xsl-трансформировать уже измененный
                xd = New Xml.XmlDocument() : xd.Load(XMLpath & "\UsefulObjects.xml")
                ' Создание раздела в меню
                titl = xd.CreateNavigator().SelectSingleNode("//xml/file/title").Value : counter += 1
                Menu &= "<node title=""" & titl & """ file=""UsefulObjects.html"" icon=""Icons/Book.png"" id=""" & counter & """>" & vbCrLf
                ' Выполнить преобразование xml-файла в html-файл
                xs.Transform(WriteNewXml(GetAllObjs(xd.OuterXml, "Useful")), args, htm)
                htm.Close() : Menu &= "</node>" & vbCrLf
            Else
                MsgBox("ПОЛЕЗНЫЕ ОБЪЕКТЫ - не найдено. Пропущено")
            End If

            ' Страница ПРОГРАММИРОВАНИЯ
            xlmFile = XMLpath & "\Programming.xml"
            If IO.File.Exists(xlmFile) Then
                ' Выходной html-файл
                htm = New Xml.XmlTextWriter(HelpPath & "\Programming.html", Encoding.UTF8)
                ' Аргументы
                args = New Xml.Xsl.XsltArgumentList()
                args.AddParam("msdnTemp", "", templFils)
                args.AddParam("php", "", php)
                ' Открыть xml-документ чтобы считать его и изменить уже в оперативной памяти, и xsl-трансформировать уже измененный
                xd = New Xml.XmlDocument() : xd.Load(XMLpath & "\Programming.xml")
                ' Создание раздела в меню
                titl = xd.CreateNavigator().SelectSingleNode("//xml/file/title").Value : counter += 1
                Menu &= "<node title=""" & titl & """ file=""Programming.html"" icon=""Icons/Book.png"" id=""" & counter & """>" & vbCrLf
                ' Выполнить преобразование xml-файла в html-файл
                xs.Transform(WriteNewXml(GetAllProgramming(xd.OuterXml)), args, htm)
                htm.Close() : Menu &= "</node>" & vbCrLf
            Else
                MsgBox("ПРОГРАММИРОВАНИЕ - не найдено. Пропущено")
            End If



            ' Страница ПРИМЕР
            xlmFile = XMLpath & "\Sample.xml"
            If IO.File.Exists(xlmFile) Then
                ' Выходной html-файл
                htm = New Xml.XmlTextWriter(HelpPath & "\Sample.html", Encoding.UTF8)
                ' Аргументы
                args = New Xml.Xsl.XsltArgumentList()
                args.AddParam("msdnTemp", "", templFils)
                args.AddParam("php", "", php)
                ' Создание раздела в меню
                xd = New Xml.XmlDocument() : xd.Load(XMLpath & "\Sample.xml")
                titl = xd.CreateNavigator().SelectSingleNode("//xml/file/title").Value : counter += 1
                Menu &= "<node title=""" & titl & """ file=""Sample.html"" icon=""Icons/Algoritm.ico"" id=""" & counter & """/>" & vbCrLf
                ' Выполнить преобразование xml-файла в html-файл
                xs.Transform(XMLpath & "\Sample.xml", args, htm)
                htm.Close()
            End If

            ' Страница МЕНЮ
            ' Выходной html-файл
            htm = New Xml.XmlTextWriter(HelpPath & "\Menu.html", Encoding.UTF8)
            ' Аргументы
            args = New Xml.Xsl.XsltArgumentList()
            args.AddParam("msdnTemp", "", templFils)
            If onlyMenu Then
                args.AddParam("onlyMenu", "", "1")
                args.AddParam("php", "", "") '"index.php?page=")
            Else
                args.AddParam("onlyMenu", "", "")
                args.AddParam("php", "", php)
            End If

            Menu &= "</menu>"
            ' Выполнить преобразование xml-файла в html-файл
            xsMenu.Transform(WriteNewXml(Menu), args, htm)
            htm.Close()

        Catch ex As Exception
            MsgBox(xlmFile & vbCrLf & vbCrLf & ex.Message)
        Finally
            htm.Close()
        End Try

        MsgBox("Готово!")

    End Sub
    ' генерация ПЕРВОГО ПРОЕКТА
    Function GetAllFirst(ByVal xmlTxt As String) As String
        Dim i As Integer
        Dim fils() As String = IO.Directory.GetFiles(XMLpath & "\First")
        Dim envs(66) As String
        ' Просмотр каждого файла папки Environment
        For i = 0 To fils.Length - 1
            xlmFile = fils(i)
            Dim titl = "", fl As String = IO.Path.GetFileNameWithoutExtension(fils(i))

            ' Записать в descr описание объекта из xml файла данного объекта
            Dim xp As Xml.XPath.XPathNavigator = (New Xml.XPath.XPathDocument(fils(i))).CreateNavigator
            titl = xp.SelectSingleNode("//xml/file/title").Value

            ' ГЕНЕРАЦИЯ СОБСТВЕННОЙ СТРАНИЧКИ части Первый проект
            CreateSobstvPage("../", HelpPath & "/First/" & fl, fils(i), _
                             AddressOf GetAllAsIs, XMLpath & "/First/", Nothing, "", "")

            ' Создание раздела в меню
            Dim icon As String = "Pictures/First.png"
            counter += 1
            Menu &= "<node title=""" & titl & """ file=""First/" & fl & _
                    ".html"" icon=""" & icon & """ id=""" & counter & """></node>" & vbCrLf

        Next

        Return xmlTxt
    End Function

    ' генерация СРЕДЫ РАЗРАБОТКИ
    Function GetAllEnvironment(ByVal xmlTxt As String) As String
        Dim ind As Integer = xmlTxt.IndexOf("</childlist>"), i As Integer
        If ind = -1 Then Return xmlTxt
        Dim fils() As String = IO.Directory.GetFiles(XMLpath & "\Environment")
        Dim envs(66), mnus(66) As String
        ' Просмотр каждого файла папки Environment
        For i = 0 To fils.Length - 1
            xlmFile = fils(i)
            Dim fl As String = IO.Path.GetFileNameWithoutExtension(fils(i))
            Dim num As String = IO.Path.GetFileNameWithoutExtension(fils(i)), descr, titl As String
            Dim razdel As String : razdel = " - "
            ' Циферка, обозначенная на картинке
            Select Case num
                Case "ObjectsPart" : num = "1" : razdel = num & razdel
                Case "WindowPart" : num = "2" : razdel = num & razdel
                Case "PropertiesPart" : num = "3" : razdel = num & razdel
                Case "TreePart" : num = "4" : razdel = num & razdel
                Case "EventPart" : num = "5" : razdel = num & razdel
                Case "ActionPart" : num = "6" : razdel = num & razdel
                Case "IfPart" : num = "7" : razdel = num & razdel
                Case "CyclePart" : num = "8" : razdel = num & razdel
                Case "CommPart" : num = "9" : razdel = num & razdel
                Case Else : num = i : razdel = ""
            End Select

            ' Записать в descr описание объекта из xml файла данного объекта
            Dim xp As Xml.XPath.XPathNavigator = (New Xml.XPath.XPathDocument(fils(i))).CreateNavigator
            descr = xp.SelectSingleNode("//xml/file/descriptionarticle//text").Value
            titl = xp.SelectSingleNode("//xml/file/title").Value

            ' ГЕНЕРАЦИЯ СОБСТВЕННОЙ СТРАНИЧКИ части Среды разработки
            CreateSobstvPage("../", HelpPath & "/Environment/" & fl, fils(i), _
                             AddressOf GetAllAsIs, XMLpath & "/Environment/", Nothing, "", "")

            ' Создание раздела в меню
            Dim icon As String = "Pictures/" & fl & ".ico"
            If IO.File.Exists(HelpPath & "\" & templFils & "\" & icon) = False Then icon = "Pictures/" & fl & ".png"
            counter += 1
            mnus(num) &= "<node title=""" & titl & """ file=""Environment/" & fl & _
                    ".html"" icon=""" & icon & """ id=""" & counter & """></node>" & vbCrLf

            If razdel = "" Then Continue For

            ' Собственно и создание списка частей Среды разработки
            envs(num) &= "<child iconMy=""" & icon & """ fileMy=""Environment/" & fl & ".html"">" & vbCrLf & _
                        "<name>" & razdel & titl & "</name>" & vbCrLf & _
                        "<descr>" & descr & "</descr>" & vbCrLf & "</child>" & vbCrLf
        Next
        Menu &= Join(mnus)
        Return xmlTxt.Insert(ind, Join(envs))
    End Function

    ' генерация ПРОГРАММИРОВАНИЯ
    Function GetAllProgramming(ByVal xmlTxt As String) As String
        Dim ind As Integer = xmlTxt.IndexOf("</childlist>"), i As Integer
        If ind = -1 Then Return xmlTxt
        Dim fils() As String = IO.Directory.GetFiles(XMLpath & "\Programming")
        Dim envs(66) As String
        ' Просмотр каждого файла папки Environment
        For i = 0 To fils.Length - 1
            xlmFile = fils(i)
            Dim fl As String = IO.Path.GetFileNameWithoutExtension(fils(i))
            Dim num As String = IO.Path.GetFileNameWithoutExtension(fils(i)), descr, titl As String

            ' Записать в descr описание объекта из xml файла данного объекта
            Dim xp As Xml.XPath.XPathNavigator = (New Xml.XPath.XPathDocument(fils(i))).CreateNavigator
            descr = xp.SelectSingleNode("//xml/file/descriptionarticle//text").Value
            titl = xp.SelectSingleNode("//xml/file/title").Value

            ' ГЕНЕРАЦИЯ СОБСТВЕННОЙ СТРАНИЧКИ данного раздела программирования
            If fl = "HelpWords" Then
                CreateSobstvPage("../", HelpPath & "/Programming/" & fl, fils(i), _
                             AddressOf GetAllHelpWords, XMLpath & "/Programming/", Nothing, "", "")
            Else
                CreateSobstvPage("../", HelpPath & "/Programming/" & fl, fils(i), _
                               AddressOf GetAllAsIs, XMLpath & "/Programming/", Nothing, "", "")
            End If

            ' Создание раздела в меню
            Dim icon As String = "Pictures/" & fl & ".ico"
            If IO.File.Exists(HelpPath & "\" & templFils & "\" & icon) = False Then icon = "Pictures/" & fl & ".png"
            counter += 1
            Menu &= "<node title=""" & titl & """ file=""Programming/" & fl & _
                    ".html"" icon=""" & icon & """ id=""" & counter & """></node>" & vbCrLf

            ' Собственно и создание списка частей Среды разработки
            envs(i) &= "<child iconMy=""" & icon & """ file=""Programming/" & fl & ".html"">" & vbCrLf & _
                        "<name>" & titl & "</name>" & vbCrLf & _
                        "<descr>" & descr & "</descr>" & vbCrLf & "</child>" & vbCrLf
        Next

        Return xmlTxt.Insert(ind, Join(envs))
    End Function

    ' генерация списка ВСЕХ ОБЪЕКТОВ и создание всех вложенных в них справок
    Function GetAllObjs(ByVal xmlTxt As String, Optional ByVal Useful As String = "") As String
        Dim ind As Integer = xmlTxt.IndexOf("</childlist>")
        If ind = -1 Then Return xmlTxt
        Dim objs As String = "", pust0 As New SortedList, pust As New SortedList, ob As Object, i As Integer
        CreatePustishki(pust0)
        If Useful = "Useful" Then
            CreatePoleznie()
            For i = 0 To PoleznieObjs.Length - 1
                pust.Add(trans(PoleznieObjs(i).obj.props.Type), PoleznieObjs(i))
            Next
            ' Получение всех свойств объекта Объект события
            Dim evObj As New Button(True)
            Dim obs(pust0.Count - 1) As Object : pust0.Values.CopyTo(obs, 0)
            Dim propsArr() As ArrayList = GetAllPropNames(obs)
            ReDim evObj.Propertys(propsArr(0).Count - 1) : propsArr(0).ToArray.CopyTo(evObj.Propertys, 0)
            ReDim evObj.PropertysUp(propsArr(1).Count - 1) : propsArr(1).ToArray.CopyTo(evObj.PropertysUp, 0)
            evObj.Sobyts = Nothing : evObj.SobytsUp = Nothing
            evObj.obj.defaultName = MyZnak & trans("Объект события")
            pust.Add(MyZnak & trans("Объект события"), evObj)
            ' Создание объекта Окно события
            Dim evFrm As New Forms(True)
            evFrm.obj.defaultName = MyZnak & trans("Окно события")
            pust.Add(MyZnak & trans("Окно события"), evFrm)
        Else
            For i = 0 To pust0.Count - 1
                pust.Add(trans(pust0.GetByIndex(i).obj.props.Type), pust0.GetByIndex(i))
            Next
        End If
        ' Просмотр каждого объекта
        i = 0
        For Each ob In pust
            Dim fl As String = Useful & "Objects/" & trans(pust.GetKey(i), True)
            Dim descr As String = ""

            ' Создание раздела в меню
            Dim icon As String = "Icons/" & trans(pust.GetKey(i), True) & ".ico"
            If IO.File.Exists(HelpPath & "\" & templFils & "\" & icon) = False Then
                icon = "Icons/" & trans(pust.GetKey(i), True) & ".png"
            End If
            If Useful = "Useful" Then icon = "Icons/6.png"
            counter += 1
            Menu &= "<node title=""" & pust.GetKey(i) & """ file=""" & fl & _
                    ".html"" icon=""" & icon & """ id=""" & counter & """>" & vbCrLf

            ' Рас есть xml-файл который описывает данный объект, то сгенерировать всю вложенную справку для этого объекта
            If IO.File.Exists(XMLpath & "\" & fl & ".xml") Then
                xlmFile = XMLpath & "\" & fl & ".xml"
                ' Записать в descr описание объекта из xml файла данного объекта
                Dim xp As Xml.XPath.XPathNavigator = (New Xml.XPath.XPathDocument(XMLpath & "\" & fl & ".xml")).CreateNavigator
                descr = xp.SelectSingleNode("//xml/file/descriptionarticle//text").Value

                ' ГЕНЕРАЦИЯ СОБСТВЕННОЙ СТРАНИЧКИ ОБЪЕКТА
                Dim PagePath As String = HelpPath & "\" & fl
                CreateSobstvPage("../", PagePath, XMLpath & "\" & fl & ".xml", _
                                 AddressOf GetAllAsIs, fl & "/", ob.value, "", Useful)

                ' Если это не _Объект события или _Форма события
                '  If ob.value Is MainForm = False Then
                ' ГЕНЕРАЦИЯ СОБСТВЕННОЙ СТРАНИЧКИ СВОЙСТВ И КОМАНД ОБЪЕКТА
                PagePath = PagePath & "\PropertiesCommands"
                CreateSobstvPage("../../", PagePath, XMLpath & "\PropertiesCommands.xml", _
                                 AddressOf GetAllProps, fl & "/PropertiesCommands/", ob.value, "", Useful)

                ' ГЕНЕРАЦИЯ СОБСТВЕННОЙ СТРАНИЧКИ СОБЫТИЙ
                PagePath = HelpPath & "\" & fl & "\Events"
                CreateSobstvPage("../../", PagePath, XMLpath & "\Events.xml", _
                        AddressOf GetAllEvents, fl & "/Events/", ob.value, "", Useful)
                'End If
            End If

            ' Собственно и создание списка объектов
            objs &= "<child iconMy=""" & icon & """ fileMy=""" & fl & ".html"">" & vbCrLf & _
                    "<name>" & sZaglav(pust.GetKey(i)) & "</name>" & vbCrLf & _
                    "<descr>" & descr & "</descr>" & vbCrLf & "</child>" & vbCrLf
            i += 1 : Menu &= "</node>" & vbCrLf
        Next

        Return xmlTxt.Insert(ind, objs)
    End Function

    ' Генерация списка ВСЕХ СВОЙСТВ И КОММАНД объкта, и создание всех вложенных в них справок
    Function GetAllProps(ByVal xmlTxt As String, ByVal ob As Object) As String
        Dim ind As Integer = xmlTxt.IndexOf("</childlist>")
        If ind = -1 Or ob Is Nothing Then Return xmlTxt
        Dim props As String = "", i, j As Integer, useful, icon As String
        ' Запись в alls всех свойст и команд
        Dim alls As New SortedList()
        If ob.propertys Is Nothing = False Then
            For i = 0 To ob.propertys.Length - 1
                alls.Add(ob.propertys(i), ob.propertys(i))
            Next
        End If
        If ob.methods Is Nothing = False Then
            For i = 0 To ob.methods.Length - 1
                alls.Add(ob.methods(i), ob.methods(i))
            Next
        End If
        If ob.sobyts Is Nothing = False Then
            For i = 0 To ob.sobyts.Length - 1
                Dim sbts() As String = (New Sobitiya(ob.sobyts(i).ToString)).Propertys
                For j = 0 To sbts.Length - 1
                    If alls.IndexOfKey(sbts(j)) = -1 Then alls.Add(sbts(j), sbts(j))
                Next
            Next
        End If


        ' Запись списка всех свойств и команд
        For i = 0 To alls.Count - 1
            If alls.GetKey(alls.Count - 1).ToString.Chars(0) = MyZnak _
                Or UCase(ob.obj.props.Type) = MyZnak & UCase(trans("Объект события")) _
                Or UCase(ob.obj.props.Type) = MyZnak & UCase(trans("Окно события")) Then useful = "Useful" Else useful = ""
            Dim fl As String = "PropertiesCommands/" & trans(alls.GetKey(i), True)
            Dim descr As String = ""

            ' Создание общего раздела в меню под наванием Свойства и команды
            If i = 0 Then
                counter += 1
                Menu &= "<node title=""" & trans("Свойства") & " " & LCase(trans("и")) & " " & LCase(trans("комманды")) & _
                        """ file=""" & useful & "Objects/" & trans(ob.obj.props.Type, True) & _
                        "/PropertiesCommands.html"" icon=""Icons/27.png"" id=""" & counter & """>" & vbCrLf
            End If

            ' Рас есть xml-файл который описывает данное свойство, то сгенерировать всю вложенную справку для свойства объекта
            If IO.File.Exists(XMLpath & "\" & fl & ".xml") Then
                xlmFile = XMLpath & "\" & fl & ".xml"
                ' Записать в descr описание объекта из xml файла данного объекта
                Dim xp As Xml.XPath.XPathNavigator = (New Xml.XPath.XPathDocument(XMLpath & "\" & fl & ".xml")).CreateNavigator
                descr = xp.SelectSingleNode("//xml/file/descriptionarticle/*/text").Value

                ' ГЕНЕРАЦИЯ СОБСТВЕННОЙ СТРАНИЧКИ СВОЙСТВА
                Dim PagePath As String = HelpPath & "\" & useful & "Objects/" & trans(ob.obj.props.Type, True) & "/" & fl
                CreateSobstvPage("../../../", PagePath, XMLpath & "\" & fl & ".xml", _
                                 AddressOf GetAllArgs, useful & "Objects/" & fl, ob, alls.GetKey(i), useful)

            End If

            ' Создание раздела в меню для этого свойства или команды
            counter += 1
            icon = "Icons/27.png"
            If php = "" Then
                Menu &= "<node title=""" & alls.GetKey(i) & """ file=""" & _
                        useful & "Objects/" & trans(ob.obj.props.Type, True) & "/" & fl & _
                        ".html"" icon=""" & icon & """ id=""" & counter & """></node>" & vbCrLf
            End If

            ' Собственно и создание списка свойств
            props &= "<child icon=""27"" fileMy=""" & trans(alls.GetKey(i), True) & ".html"">" & vbCrLf & _
                    "<name>" & alls.GetKey(i) & "</name>" & vbCrLf & _
                    "<descr>" & descr & "</descr>" & vbCrLf & "</child>" & vbCrLf
        Next
        If alls.Count > 0 Then Menu &= "</node>" & vbCrLf
        Return xmlTxt.Insert(ind, props)
    End Function

    ' генерация списка ВСЕХ СОБЫТИЙ объекта, и создание всех вложенных в них справок
    Function GetAllEvents(ByVal xmlTxt As String, ByVal ob As Object) As String
        If UCase(ob.obj.props.Type) = MyZnak & UCase(trans("Окно события")) Then Return xmlTxt
        Dim ind As Integer = xmlTxt.IndexOf("</childlist>")
        If ind = -1 Or ob Is Nothing Then Return xmlTxt
        Dim props As String = "", i As Integer, useful As String
        ' Запись в alls всех событий
        Dim alls As New SortedList()
        If ob.Sobyts Is Nothing Then Return xmlTxt
        For i = 0 To ob.Sobyts.Length - 1
            alls.Add(ob.Sobyts(i), ob.Sobyts(i))
        Next
        ' Запись списка всех событий
        For i = 0 To alls.Count - 1
            If alls.GetKey(i).ToString.Chars(0) = MyZnak Then useful = "Useful" Else useful = ""
            Dim fl As String = "Events/" & trans(alls.GetKey(i), True)
            Dim descr As String = ""

            ' Создание общего раздела в меню под наванием События
            If i = 0 Then
                counter += 1
                Menu &= "<node title=""" & trans("События") & _
                        """ file=""" & useful & "Objects/" & trans(ob.obj.props.Type, True) & _
                        "/Events.html"" icon=""Icons/0.png"" id=""" & counter & """>" & vbCrLf
            End If

            ' Рас есть xml-файл который описывает данное событие, то сгенерировать всю вложенную справку для свойства объекта
            If IO.File.Exists(XMLpath & "\" & fl & ".xml") Then
                xlmFile = XMLpath & "\" & fl & ".xml"
                ' Записать в descr описание объекта из xml файла данного объекта
                Dim xp As Xml.XPath.XPathNavigator = (New Xml.XPath.XPathDocument(XMLpath & "\" & fl & ".xml")).CreateNavigator
                descr = xp.SelectSingleNode("//xml/file/descriptionarticle/*/text").Value


                ' ГЕНЕРАЦИЯ СОБСТВЕННОЙ СТРАНИЧКИ СОБЫТИЯ
                Dim PagePath As String = HelpPath & "\" & "Objects/" & trans(ob.obj.props.Type, True) & "/" & fl
                CreateSobstvPage("../../../", PagePath, XMLpath & "\" & fl & ".xml", _
                                 AddressOf GetAllSobytProps, "Objects/" & fl, ob, alls.GetKey(i), useful)

            End If
            ' Создание раздела в меню для этого события
            counter += 1
            Dim icon As String = "Icons/Events/" & trans(alls.GetKey(i), True) & ".ico"
            If IO.File.Exists(HelpPath & "\" & templFils & "\" & icon) = False Then
                icon = "Icons/Events/" & trans(alls.GetKey(i), True) & ".png"
            End If
            If php = "" Then
                Menu &= "<node title=""" & alls.GetKey(i) & """ file=""" & _
                                   useful & "Objects/" & trans(ob.obj.props.Type, True) & "/" & fl & _
                                   ".html"" icon=""" & icon & """ id=""" & counter & """></node>" & vbCrLf
            End If

            ' Собственно и создание списка событий
            props &= "<child iconMy=""" & icon & """ fileMy=""" & trans(alls.GetKey(i), True) & ".html"">" & vbCrLf & _
                    "<name>" & alls.GetKey(i) & "</name>" & vbCrLf & _
                    "<descr>" & descr & "</descr>" & vbCrLf & "</child>" & vbCrLf
        Next
        If alls.Count > 0 Then Menu &= "</node>" & vbCrLf
        Return xmlTxt.Insert(ind, props)
    End Function

    ' генерация списка ВСЕХ АРГУМЕНТОВ свойства или команды, и создание всех вложенных в них справок
    Function GetAllArgs(ByVal xmlTxt As String, ByVal ob As Object) As String
        Dim aStr As String, i As Integer, descr As String, objStr As String = trans("Объекты")
        Dim ind As Integer = xmlTxt.IndexOf("</exceptions>")
        ' получить все аргументы свойтсва или команды
        Dim ii As Integer = xmlTxt.IndexOf("<title>") + "<title>".Length
        If ii = -1 Then Return xmlTxt
        Dim title As String = trans(xmlTxt.Substring(ii, xmlTxt.IndexOf("</title>") - ii))
        Dim args() As String = GetArguments(title, Nothing)
        If args Is Nothing Then args = GetArguments(MyZnak & title, Nothing) : objStr = MyZnak & trans("Полезные объекты")
        If ind = -1 Or args Is Nothing Then Return xmlTxt
        ' Если xml-файл с описанием аргументов отсутсвует
        If IO.File.Exists(XMLpath & "\Arguments.xml") = False Then Return xmlTxt
        xlmFile = XMLpath & "\Arguments.xml"
        ' Запись синтаксиса
        aStr = "<text>" & objStr & ".<objNoLink/>.<propNoLink/> ("
        For i = 0 To args.Length - 1
            If args(i) = "неважно" Then Exit For
            aStr &= "<b>" & args(i) & "</b>"
            If i < args.Length - 1 Then If args(i + 1) <> "неважно" Then aStr &= ", "
        Next
        aStr &= ")</text>"
        ' Запись списка всех аргументов
        For i = 0 To args.Length - 1
            If args(i) = "неважно" Then Exit For
            ' Записать в descr описание объекта из xml файла данного объекта
            Dim xp As Xml.XPath.XPathNavigator = (New Xml.XPath.XPathDocument(XMLpath & "\Arguments.xml")).CreateNavigator
            xp = xp.SelectSingleNode("//xml/file/arguments/argument[@name='" & trans(args(i), True) & "']")

            If xp Is Nothing Then descr = "" Else descr = xp.Value

            ' Собственно и создание списка аргументов
            aStr &= "<exception>" & vbCrLf & _
                    "<name>" & args(i) & "</name>" & vbCrLf & _
                    "<descr>" & descr & "</descr>" & vbCrLf & "</exception>" & vbCrLf
        Next
        Return xmlTxt.Insert(ind, aStr)
    End Function

    ' генерация списка ВСЕХ СВОЙСТВ СОБЫТИЯ объекта, и создание всех вложенных в них справок
    Function GetAllSobytProps(ByVal xmlTxt As String, ByVal ob As Object) As String
        Dim aStr As String, i As Integer, descr As String, objStr As String = trans("Объекты")
        Dim ind As Integer = xmlTxt.IndexOf("</exceptions>")
        ' получить все свойства события объекта
        Dim ii As Integer = xmlTxt.IndexOf("<title>") + "<title>".Length
        If ii = -1 Then Return xmlTxt
        Dim title As String = trans(xmlTxt.Substring(ii, xmlTxt.IndexOf("</title>") - ii))
        Dim sbpr() As String = (New Sobitiya(title)).Propertys
        If ind = -1 Or sbpr Is Nothing Then Return xmlTxt
        aStr = ""
        ' Запись списка всех аргументов
        For i = 0 To sbpr.Length - 1

            ' Записать в descr описание объекта из xml файла данного объекта
            descr = ""
            Dim fl As String = XMLpath & "\PropertiesCommands\" & trans(sbpr(i), True) & ".xml"
            If IO.File.Exists(fl) Then
                xlmFile = fl
                Dim xp As Xml.XPath.XPathNavigator = _
                    (New Xml.XPath.XPathDocument(fl)).CreateNavigator
                xp = xp.SelectSingleNode("//descriptionarticle//text")
                If xp Is Nothing Then descr = "" Else descr = xp.Value
            End If


            ' Собственно и создание списка аргументов
            aStr &= "<exception>" & vbCrLf & "<file>" & trans(sbpr(i), True) & "</file>" & _
                    "<name>" & sbpr(i) & "</name>" & vbCrLf & _
                    "<descr>" & descr & "</descr>" & vbCrLf & "</exception>" & vbCrLf
        Next
        Return xmlTxt.Insert(ind, aStr)
    End Function

    ' генерация собственной странички СВОЙСТВ И КОМАНД объекта
    Sub CreateSobstvPage(ByVal vlozhen As String, ByVal HtmlPathBezExt As String, ByVal xlmFile As String, _
                         ByVal GetAllsFun As GetAlls, _
                         ByVal argPapka As String, ByVal argObj As Object, ByVal argProp As String, _
                          ByVal argUseful As String)
        If IO.Directory.Exists(HtmlPathBezExt) = False Then IO.Directory.CreateDirectory(HtmlPathBezExt)
        ' Выходной html-файл
        Dim htm As New Xml.XmlTextWriter(HtmlPathBezExt & ".html", Encoding.UTF8)
        ' Аргументы
        Dim args As New Xml.Xsl.XsltArgumentList()
        args.AddParam("msdnTemp", "", templFils)
        args.AddParam("vlozhen", "", vlozhen)
        args.AddParam("papka", "", argPapka)
        If argObj Is Nothing = False Then
            args.AddParam("obj", "", sZaglav(argObj.obj.props.Type))
            args.AddParam("objEng", "", trans(argObj.obj.props.Type, True))
        End If
        args.AddParam("prop", "", sZaglav(argProp))
        args.AddParam("propEng", "", trans(argProp, True))
        args.AddParam("useful", "", argUseful)
        args.AddParam("php", "", php)
        ' Открыть xml-документ чтобы считать его и изменить уже в оперативной памяти, и xsl-трансформировать уже измененный
        Dim xd As New Xml.XmlDocument() : xd.Load(xlmFile)
        ' Выполнить преобразование xml-файла в html-файл
        xs.Transform(WriteNewXml(GetAllsFun(xd.OuterXml, argObj)), args, htm)
        htm.Close()
    End Sub
    ' Для делегата, чтобы выдавать не текст меняя, КАК ЕСТЬ
    Function GetAllAsIs(ByVal xmlTxt As String, ByVal ob As Object) As String
        Return xmlTxt
    End Function

    ' ГЕНЕРАЦИЯ СПИСКА ВСЕХ ВСПОМОГАТЕЛЬНЫХ СВОЙСТВ, И СОЗДАНИЕ ВСЕХ ВЛОЖЕННЫХ В НИХ СПРАВОК
    Function GetAllHelpWords(ByVal xmlTxt As String, ByVal ob As Object) As String
        Dim ind As Integer = xmlTxt.IndexOf("</childlist>")
        If ind = -1 Then Return xmlTxt
        Dim hws As String = "", i, j As Integer, descr As String = ""
        Dim fl As String = "Programming/HelpWords/HelpWordsCategories.xml"
        ' Запись в HWCategrs всех категорий вспомогателных слов
        'CreateHWCategrs()
        CreateHelpWords()
        For i = 0 To HWCategrs.Length - 1
            HWCategrsSort.Add(HWCategrs(i), HWCategrs2(i))
        Next
        ' Рас есть xml-файл который описывает все вспомогательные слова, то сгенерировать всю вложенную справку
        If IO.File.Exists(XMLpath & "/" & fl) Then
            xlmFile = XMLpath & "/" & fl
            ' Запись списка всех свойств и команд
            For i = 0 To HWCategrsSort.Count - 1

                ' Записать в descr описание объекта из xml файла данного объекта
                Dim xp As Xml.XPath.XPathNavigator = (New Xml.XPath.XPathDocument(XMLpath & "\" & fl)).CreateNavigator
                Dim nod As Xml.XPath.XPathNavigator = _
                            xp.SelectSingleNode("//hws/hw[@cat='" & LCase(trans(HWCategrsSort.GetKey(i), True)) & "']/text")
                If nod Is Nothing = False Then descr = nod.InnerXml Else descr = ""

                For j = 0 To HWCategrsSort.GetByIndex(i).Length - 1
                    descr &= HWCategrsSort.GetByIndex(i)(j)
                    If HWCategrsSort.GetByIndex(i).Length - 1 <> j Then descr &= ", " Else descr &= "<br/><br/>"
                Next
                ' Собственно и создание списка свойств
                hws &= "<child icon=""10"">" & vbCrLf & "<name>" & _
                        HWCategrsSort.GetKey(i) & "</name>" & vbCrLf & _
                        "<descr><a name=""" & trans(HWCategrsSort.GetKey(i), True) & """>" & descr & "</a>" & _
                        "</descr>" & vbCrLf & "</child>" & vbCrLf
            Next
        End If
        Return xmlTxt.Insert(ind, hws)
    End Function

    ' Создание XML-документа с содержимым xmlOutText
    Function WriteNewXml(ByVal xmlOutText As String) As Xml.XPath.XPathDocument
        Dim tmp As String = IO.Path.GetTempFileName
        Dim sw As New IO.StreamWriter(tmp, False, Encoding.UTF8)
        sw.Write(xmlOutText)
        sw.Close()
        Dim xr As New Xml.XmlTextReader(tmp)
        Return New Xml.XPath.XPathDocument(xr)
    End Function
    ' Написание аргумента с заглавной буквы
    Function sZaglav(ByVal str As String) As String
        If str.Length > 0 Then str = UCase(str.Chars(0)) & str.Substring(1)
        Return str
    End Function
    Function GetAllPropNames(ByVal Objs()) As ArrayList()
        Dim arr, arrUp As New ArrayList
        Dim i, j, z As Integer
        ' Пробежаться по всем объектам формы
        For j = 0 To Objs.Length - 1
            ' Пробежаться по всем свойствам объекта
            If Objs(j).Propertys Is Nothing = False Then
                For z = 0 To Objs(j).Propertys.Length - 1
                    ' Если найдено нужное свойство у объекта 
                    If arrUp.IndexOf(Objs(j).PropertysUp(z)) = -1 Then
                        arrUp.Add(Objs(j).Propertysup(z))
                        arr.Add(Objs(j).Propertys(z))
                    End If
                Next
            End If
        Next
        Dim sobytObj As Sobitiya = New Sobitiya(MyZnak & "All")
        ' Пробежаться по всем полезным свойствам, обычных объектов
        For i = 0 To sobytObj.Propertys.Length - 1
            If arrUp.IndexOf(sobytObj.PropertysUp(i)) = -1 Then
                arrUp.Add(sobytObj.PropertysUp(i))
                arr.Add(sobytObj.Propertys(i))
            End If
        Next
        Return New ArrayList() {arr, arrUp}
    End Function
End Class
