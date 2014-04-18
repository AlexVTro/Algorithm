'#Const Ver = "DebugAll" ' -  DebugAll, DebugFree, Free, All, Http
'#Const Lang = "Ru" ' -  Ru, En
Imports System.Diagnostics

Public Module peremens
    Public isDevelop As Boolean = True ' ОБОЗНАЧАЕТ ЧТО ИДЕТ РАЗРАБОТКА ПРОЕКТА А НЕ ВЫПОЛНЕНИЕ ГОТОВОЙ ПРОГРАММЫ
    Public isHelp As Boolean  ' ОБОЗНАЧАЕТ ЧТО ИДЕТ РАЗРАБОТКА ПРОЕКТА А НЕ ВЫПОЛНЕНИЕ ГОТОВОЙ ПРОГРАММЫ
    Public isCompilBest As Boolean  ' ОБОЗНАЧАЕТ ЧТО ИДЕТ СУПЕР-КОМПИЛЯЦИЯ ПРОЕКТА
    Public isRunAlg2Code As Boolean  ' ОБОЗНАЧАЕТ ЧТО ИДЕТ СУПЕР-КОМПИЛЯЦИЯ ПРОЕКТА

#If Ver = "Http" Then
    Public IsHttpCompil As Boolean = True ' ОБОЗНАЧАЕТ ЧТО ИСПОЛЬЗУЮТ В КАЧЕСТВЕ ОНЛАЙН-КОМПИЛЯТОРА
#Else
    Public IsHttpCompil As Boolean = False ' ОБОЗНАЧАЕТ ЧТО НЕ ИСПОЛЬЗУЮТ В КАЧЕСТВЕ ОНЛАЙН-КОМПИЛЯТОРА
#End If

    ' ЯЗЫКОЗАВИСИМЫЕ КОНСТАНТЫ
#If lang = "Ru" Then
    Public Const AppName As String = "Алгоритм"
    Private Const AlgDirName As String = "Алгоритм 2"
    Public Const IntroImage As String = "AlgorithmRu.jpg"
    Private Const ProjectsDirName As String = "Проекты"
    Private Const SamplesDirName As String = "Примеры"
    Private Const PicturesDirName As String = "Рисунки"
    Public lang_def As String = "Russian" ' язык программирования по умолчанию
    Public lang_interface As String = "Russian"  ' язык среды разработки
    Public lastVersionUrl As String = "http://algoritm2.ru/api/LastVersionRu.php"
    Public lastFreeVersionDownloadUrl As String = "http://algoritm2.ru/download/Algoritm2RuLast.exe"
#Else
    Public Const AppName As String = "Algorithm"
    Public Const IntroImage As String = "AlgorithmEn.jpg"
    Private Const AlgDirName As String = "Algorithm 2"
    Private Const ProjectsDirName As String = "Projects"
    Private Const SamplesDirName As String = "Examples"
    Private Const PicturesDirName As String = "Pictures"
    Public lang_def As String = "English" ' язык программирования по умолчанию
    Public lang_interface As String = "English"  ' язык среды разработки
    Public lastVersionUrl As String = "http://algorithm2.com/api/LastVersionEn.php" 
    Public lastFreeVersionDownloadUrl As String = "http://algorithm2.com/download/Algoritm2EnLast.exe"
#End If

    Public referral As String
    Public Version As String = "2.7"
    Public AppNameWithVersion As String = AppName & " " & Version

    Public AppPath As String = AppDomain.CurrentDomain.BaseDirectory() ' Папка с программой
    Public UserPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\" & AlgDirName & "\" ' Папка юзера
    Public AppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & AlgDirName & "\" ' Папка юзера
    Public ProjectsPath As String = UserPath & ProjectsDirName & "\" ' Папка с проектами
    Public SamplesPathDefault As String = AppPath & ProjectsDirName & "\" & SamplesDirName & "\" ' Папка с примерами проектов сразу после установки
    Public SamplesPath As String = ProjectsPath & SamplesDirName & "\" ' Папка с примерами проектов
    Public DataPath As String = AppPath & "Data\" ' Папка с данными
    Public LessonsPath As String = DataPath & "VideoLessons\" ' Папка с видеоуроками
    Public lang_name As String = lang_def ' язык программирования
    Public lang_name_old As String = lang_def ' язык программирования
    Public lang_interface_old As String = lang_interface  ' язык среды разработки
    Public ParamFilePathDefault As String = AppPath & "Parametrs.ini"
    Public ParamFilePath As String = AppDataPath & "Parametrs.ini"
    Public OptionsFilePathDefault As String = AppPath & "Options.ini"
    Public OptionsFilePath As String = AppDataPath & "Options.ini"

    Public LanguagePath As String = DataPath & "Languages\" ' Папка с языками
    Public CompilPathDefault As String = DataPath & "Compil\" ' Папка с исходниками
    Public CompilPath As String = AppDataPath & "Compile\" ' Папка с исходниками
    'Public CompilBatFilePath As String = AppDataPath & "Compil.bat" ' Батник проводящий компиляцию

    Public ObjectsPath As String = DataPath & "Objects\" ' Папка с прочими объектами
    Public ObjectFile As String = ObjectsPath & "Compil.exe" ' 
    Public DllKenMan As String = AppPath & "Kennedy.ManagedHooks.dll" ' Папка с языками
    Public DllCoreHook As String = AppPath & "SystemHookCore.dll" ' Папка с языками
    Public DllVBScript As String = AppPath & "Interop.MSScriptControl.dll" ' Папка с языками
    Public SkinsPath As String = DataPath & "Pictures\" ' Папка со скинами
    Public OblozhkaPath As String = SkinsPath & IntroImage ' Папка со скинами
    Public ProjIpath As String = PicturesDirName & "\" ' Папка рисунков у проекта по умолчанию
    Public XMLPathChld As String = "XML Help\" ' Папка с проектами
    Public HelpPath As String = DataPath & "Help" ' Папка с проектами
    Public Skin As String = "Simple" ' Скин
    Public StartEdu As String = "Yes"
    Public StartUved As String = "Yes"
    Public PicturesPath As String = "" ' Папка с рисунками, задается в InitializeBeforeProject
    Public SkinColors, SkinPictures, SkinOptions, HWCategrsSort As New System.Collections.SortedList
    Public ClassAplication As String = "WindowsApplication1." ' Название класса этой программы
    Public twoSpace = 6, markerX = 6, markerY = 6, setka As Integer = 4 ' ширина и вышина маркеров, размер сетки
    Public RecentProjcts As New ArrayList
    Public iHeight As Integer = 14 ' Вышина одной строки в списке свойств
    Public formX = 3, formY As Integer = 3 ' х и у формы в табе
    Public Tree As TreeView ' Хранит дерево действий
    Public tab As TabControl ' Хранит конструктор действий
    Public Pictures16, Pictures32 As New ImageList
    Public PicExten() As String = {".JPG", ".JPEG", ".GIF"}
    Public MyZnak As String = "_" ' знак обозначающий что это объект создан мной
    Public LiterWidth As Double = 6.9 ' ширина буквы
    Public oldLVselect As String
    Public SobytsTab, DeistTab, ifTab, CycleTab, CommTab As TabPage
    Public DopFuns(), DopFunsSimple(), Operations(), opers(), Usloviya(), uslovs(), othersSimb(), allSimb(), _
           VBKeyWords() As String
    Public PoleznieObjs(), Prioritets() As Object
    Public MasterHeight, MasterWidth, MasterSplit, OptionsHeight, OptionsWidth, _
           MainHeight, MainWidth, MainX, MainY As Integer ' Параметры форм
    Public SkippedVersion, PayLink As String
    Public BeginProgress As Integer = 0
    Public AlphaPik As Integer = 255
    Public AlphaNiz As Integer = 50
    Public MarkCount As Integer = 10
    Public ColObject, ColProperty, ColMethod, ColFunction, ColConsts, ColKovi4ki, ColKode, ColBreakpoint, ColDebugNode As Color ' Цвета подсветки
    Public maxWhileCount As Integer = 10000
    Public maxRecurs As Integer = 20
    Public maxRecentProjs As Integer = 15
    Public ReadOnlyProps(), SobytsNotReadOnly(), ArgTypes(), NoSaveProps() As String
    Public Colors, InfoObjs, InfoElems, InfoProps, _
            lang, langENG, langLw, langLwENG, langINFC, langLwINFC, _
            langOld, langLwOld, langINFCOld, langLwINFCOld As New SortedList
    Public MayChangeProps() As String = {}
    Public HelpObjs(0), HWCategrs2() As Object
    Public Breaks() As TreeNode
    Public RunProj As RunProject ', OandT As ObjectsAndTree
    Public isConsole, isTranslate, fromIzmenenieBylo, tokaSohranil As Boolean
    Public runProc As Threading.Thread, timeSleep As Integer = 20, pauseCount As Integer = 5
    Dim tempRich As New RichTextBox
    Public SiteAlg As String

    Public helps() As PictureBox
    Public associateError, noSimb As String
    Public PointSimb1 As String = "," ' (0.1).ToString.Chars(1)
    Public PointSimb2 As String = "."
    Public perenos, IgnorEr As Boolean, ProjEvents() As String
    ' Создание пустышек
    Public Pustishki As New SortedList

    ' БЫСТРОДЕЙСТВИЕ
    Public bistro_StatusLine As Boolean = False
    Public bistro_orfo As Boolean = False
    Public bistro_UnRe As Boolean = False
    Public bistro_HW As Boolean = True
    Public bistro_podsvFun As Boolean = False
    Public bistro_podsvHW As Boolean = False
    Public bistro_podsvObs As Boolean = False
    Public bistro_podsvPMs As Boolean = False
    Public bistro_podsvKov As Boolean = False
    '<<<<<<<< ОСНОВНЫЕ МАССИВЫ И КОЛЛЕКЦИИ >>>>>>>>>
#Region "Peremens"
    ' Коллекции
    Public Anchors, bkImStyles, Cursori, Docks, _
            FlatStyles, Fonts, Aligns, TextImages, BorderStyles, FixedPanels, Orientations, Papks, Keyz, DeskStyle, _
            TypeRegistry, ScrollBarz, TextPositions, DisplayStyles, TextDirections, ReadyStates, _
            DocumentEncodings, Refreshs, FormBorderStyles, StartPositions, WindowStates, Alignments, _
            CellBorderStyles, EditModes, SelectionModes, Filters, LinkBehaviors, MsgStyleButtons, _
            MsgStyleTypes, BdTypes, DateFormats, TickStyles, FileEncodings, SizeModes, InputTypes, _
            ClientServStates, ClientServerTypes, ContentTypes, HttpMethods, StylesProgress As New SortedList

    ' Вспомогательные слова
    Public AllFuncs(), AllHW(), AllHWUp(), HWCategrs(), _
            HWCols(), HWDaNet(), HWKnopkiMishi(), HWPapki(), HWKeys(), _
            HWAnchors(), HWbkImStyles(), HWCursori(), HWDocks(), HWFlatStyles(), HWFonts(), HWAligns(), _
            HWTextImages(), HWBorderStyles(), HWFixedPanels(), HWOrientations(), HWOthers(), HWDeskStyle(), _
            HWDeskResolution(), HWTypeRegistry(), HWScrollBarz(), HWTextPositions(), HWDisplayStyles(), _
            HWTextDirections(), HWReadyStates(), HWDocumentEncodings(), HWRefreshs(), HWFormBorderStyles(), _
            HWStartPositions(), HWWindowStates(), HWAlignments(), HWCellBorderStyles(), HWEditModes(), _
            HWSelectionModes(), HWFilters(), HWLinkBehaviors(), HWMsgStyleButtons(), HWMsgStyleTypes(), _
            HWBdTypes(), HWDateFormats(), HWTickStyles(), HWFileEncodings(), HWSizeModes(), HWInputTypes(), _
            HWClientServStates(), HWClientServerTypes(), HWContentTypes(), HWHttpMethods(), HWStylesProgress() As String
#End Region

    '<<<<<<<< РАБОТА С ЯЗЫКАМИ >>>>>>>>>
#Region "TRANS"
    Dim xmlp As String = ""
    Property XMLpath() As String
        Get
            If xmlp = "" Then Return LanguagePath & lang_name & "\" & XMLPathChld Else Return xmlp
        End Get
        Set(ByVal value As String)
            xmlp = value
        End Set
    End Property
    ' Создание языка
    Sub setLangs(Optional ByVal withOld As Boolean = True, Optional ByVal withFolder As Boolean = True)
        Dim lang_name_path, lang_eng_path, lang_interface_path As String
        ' если языки должны находиться каждый в отдельной папке
        If withFolder Then
            lang_name_path = lang_name & "\"
            lang_eng_path = "English\"
            lang_interface_path = lang_interface & "\"
        End If
        ' создать списки языков
        lang = Get2List(LanguagePath & lang_name_path & lang_name & ".lng", "~~")
        langLw = Get2List(LanguagePath & lang_name_path & lang_name & ".lng", "~~", , True)
        langENG = Get2List(LanguagePath & lang_eng_path & "English.lng", "~~")
        langLwENG = Get2List(LanguagePath & lang_eng_path & "English.lng", "~~", , True)
        langINFC = Get2List(LanguagePath & lang_interface_path & lang_interface & ".lng", "~~")
        langLwINFC = Get2List(LanguagePath & lang_interface_path & lang_interface & ".lng", "~~", , True)
        If withOld Then
            lang_name_old = lang_name : langOld = lang : langLwOld = langLw
            lang_interface_old = lang_interface : langINFCOld = langINFC : langLwINFCOld = langLwINFC
        End If
    End Sub
    ' ВЫПОЛНЯЕТ ПЕРЕВОДЫ ТЕКСТОВ ИНТЕРФЕСА СРЕДЫ РАЗРАБОТКИ АЛГОРИТМ2
    Function transInfc(ByVal word As String) As String
        Dim l As String = lang_name, lo As String = lang_name
        Dim tempLang, tempLangLw, tempLangOld, tempLangLwOld As SortedList

        l = lang_name : lang_name = lang_interface : lo = lang_name_old : lang_name_old = lang_interface_old
        tempLang = lang : tempLangLw = langLw : tempLangOld = langOld : tempLangLwOld = langLwOld
        langOld = langINFCOld : langLwOld = langLwINFCOld : lang = langINFC : langLw = langLwINFC

        Dim ret As String = trans(word, False, False)

        lang = tempLang : langLw = tempLangLw : langOld = tempLangOld : langLwOld = tempLangLwOld
        lang_name = l : lang_name_old = lo
        Return ret
    End Function
    ' ВЫПОЛНЯЕТ ПЕРЕВОДЫ ВСЕХ ТЕКСТОВ В АЛГОРИТМЕ2
    Function trans(ByVal word As String, Optional ByVal toEng As Boolean = False, Optional ByVal fromEng As Boolean = False, Optional ByVal onOld As Boolean = False, Optional ByVal bezCifr As Boolean = False) As String
        Dim cfr = "", znk As String = "", ind As Integer, language, languageLw As System.Collections.SortedList
        word = Trim(word)

        ' Запись в znk моего знака, если таковой присутсвует в слове, дабы переводить без него
        If word.IndexOf(MyZnak) = 0 Then znk = MyZnak : word = word.Substring(1)
        ' Запись в cfr цифр в конце слова, если таковые присутсвуют в слове, дабы переводить без них
        If bezCifr Then
            Dim rgx As New RegularExpressions.Regex("[0-9]+$")
            Dim m As RegularExpressions.Match = rgx.Match(word)
            If m.Success Then
                cfr = m.Value
                word = word.Substring(0, m.Index)
            End If
        End If

        If word = "" Then Return ""

        ' Условие для ускорения работы русского. Рас и так руский, возвращаем слово
        If lang_name = "Russian" And toEng = False And fromEng = False And lang_name_old = lang_name Then
            Return znk & word & cfr ' Если язык и так русский 
        End If

        ' Если переводят строго с английского, то получить русское слово
        If fromEng = True Then
            ' Если язык и так английский 
            If lang_name = "English" And lang_name_old <> lang_name Then Return znk & word & cfr
            ' получить из английского слова русское
            ind = langLwENG.GetValueList.IndexOf(LCase(word))
            If ind <> -1 Then
                word = langENG.GetKeyList.Item(ind)
            Else
                Return znk & word & cfr
            End If
            ' Если язык русский то вывести слово (условие не обязательно, оно лишь для ускорения работы русского языка)
            If lang_name = "Russian" Then Return znk & word & cfr
        End If

        ' Если хотят узнать как звучало слово на прошлом языке (например для замены "Если" на "If")
        If onOld Then
            ind = langLwOld.GetKeyList.IndexOf(LCase(word))
            If ind <> -1 Then word = langOld.GetValueList.Item(ind)
            Return znk & word & cfr
        End If

        ' Получить слово с другого языка на русском
        If onOld = False Then 'lang_name_old <> lang_name And
            ind = langLwOld.GetValueList.IndexOf(LCase(word))
            If ind <> -1 Then word = langOld.GetKeyList.Item(ind)
        End If

        ' Перевести слово с русскного на нужный язык
        If toEng = False Then
            language = lang : languageLw = langLw
        Else
            languageLw = langLwENG : language = langENG
        End If
        ind = languageLw.GetKeyList.IndexOf(LCase(word))
        If ind = -1 Then
            Return znk & word & cfr ' если слово не перевелось
        Else
            Return znk & language.GetValueList.Item(ind).ToString.Trim & cfr
        End If
    End Function
    Public Sub transObjects()
        Dim k, i, j As Integer, lng As String = "", tempLang As SortedList

        For i = 0 To proj.f.Length - 1
            For j = 0 To proj.f(i).MyObjs.Length - 1
                ' Перевод всех свойств
                If proj.f(i).MyObjs(j).Propertys Is Nothing = False Then
                    For k = 0 To proj.f(i).MyObjs(j).Propertys.Length - 1
                        proj.f(i).MyObjs(j).Propertys(k) = sZaglavnoi(trans(proj.f(i).MyObjs(j).Propertys(k)))
                    Next
                End If
                ' Перевод всех методов
                If proj.f(i).MyObjs(j).Methods Is Nothing = False Then
                    For k = 0 To proj.f(i).MyObjs(j).Methods.Length - 1
                        proj.f(i).MyObjs(j).Methods(k) = sZaglavnoi(trans(proj.f(i).MyObjs(j).Methods(k)))
                    Next
                End If
                ' Перевод всех событий
                If proj.f(i).MyObjs(j).Sobyts Is Nothing = False Then
                    For k = 0 To proj.f(i).MyObjs(j).Sobyts.Length - 1
                        proj.f(i).MyObjs(j).Sobyts(k) = sZaglavnoi(trans(proj.f(i).MyObjs(j).Sobyts(k)))
                    Next
                End If
                CreatePropertySobytsUp(proj.f(i).MyObjs(j))
            Next
        Next


        Dim typs() As String = {UCase(trans("Текст")), UCase(trans("Число")), UCase(trans("Рисунок")), _
                                  UCase(trans("Файл")), UCase(trans("Всплывающее меню"))}
        For i = 0 To proj.f.Length - 2
            For j = 0 To proj.f(i).MyObjs.Length - 1
                ProgressForm.ProgressBarValue = 10 + (90 / (proj.f.Length - 1)) / proj.f(i).MyObjs.Length * (j) + ((90 / (proj.f.Length - 1)) * (i))
                ' Перевод всех свойств
                If proj.f(i).MyObjs(j).Propertys Is Nothing = False Then
                    For k = 0 To proj.f(i).MyObjs(j).Propertys.Length - 1

                        Dim typ As String = UCase(GetTypeProperty(proj.f(i).MyObjs(j).Propertys(k)))
                        Dim prop As String = proj.f(i).MyObjs(j).Propertys(k)

                        ' перевести значение свойства на требуемый язык
                        Dim value As String = GetProperty(proj.f(i).MyObjs(j), prop).str
                        ' Если свойтво такого типа, что надо перевести его на новый язык и это не полезный объект и оно не только для чтения
                        If (Array.IndexOf(typs, typ) = -1 Or UCase(trans(value)) = UCase(trans("Никакой"))) _
                        And Array.IndexOf(ReadOnlyProps, UCase(prop)) = -1 _
                        And Array.IndexOf(MayChangeProps, UCase(prop)) = -1 _
                        Then
                            SetProperty(proj.f(i).MyObjs(j), prop, trans(value))
                        End If
                        ' Если особые свойства, тоже требующие перевода
                        If UCase(trans(prop)) = UCase(trans("Имя")) Or UCase(trans(prop)) = UCase(trans("Всплывающее меню")) _
                        Or UCase(trans(prop)) = UCase(trans("Главное меню")) Then
                            SetProperty(proj.f(i).MyObjs(j), prop, trans(value, , , , True))
                        End If
                    Next
                End If
            Next
        Next
        transTree(Tree.Nodes(0).Parent)

    End Sub

    Public Class ReNameThread
        Public nodReN As Object
        Public objReN As Object
        Sub New(ByVal node As TreeNode, Optional ByVal neTransARename As reName = Nothing)
            nodReN = node : objReN = neTransARename
        End Sub
        Sub transTree()
            peremens.transTree(nodReN, objReN)
        End Sub
    End Class

    Sub SetTextNode(ByVal nod As TreeNode, ByVal str As String)
        nod.Text = str
    End Sub

    ' ПРОБЕГАЕТ ПО ДЕРЕВУ РЕКУРСИВНО И ПЕРЕВОДИТ ВСЕ ВЕТКИ ДЕРЕВА
    Sub transTree(ByVal node As TreeNode, Optional ByVal neTransARename As reName = Nothing)
        Dim i As Integer, nod As Object = node
        If nod Is Nothing Then nod = Tree
        For i = 0 To nod.Nodes.Count - 1
            'If Tree.InvokeRequired Then
            '    Dim txt As String = transNode(nod.Nodes(i), neTransARename)
            '    Tree.Invoke(delegatSetNodeText, New Object() {nod.Nodes(i), txt})
            'Else
            Dim txt As String = transNode(nod.Nodes(i), neTransARename)
            If nod.Nodes(i).Text <> txt Then nod.Nodes(i).Text = txt
            'End If
            transTree(nod.Nodes(i), neTransARename)
        Next
    End Sub

    ' Перевод веток дерева
    Public Function transNode(ByVal node As TreeNode, Optional ByVal neTransARename As reName = Nothing) As String
        Dim txt As String = Trim(node.Text)
        Dim fnd As String = UCase(txt)
        If node.Tag = "If" Then
            If fnd.IndexOf(UCase(trans("Если", , , True))) = 0 Then
                txt = txt.Substring(trans("Если", , , True).Length)
            End If
            If fnd.IndexOf(UCase(trans("Тогда", , , True))) = fnd.Length - trans("Тогда", , , True).Length Then
                txt = UCase(trans("Если")) & " " & transDeist(Left(txt, txt.Length - trans("Тогда", , , True).Length), neTransARename) & " " & UCase(trans("Тогда"))
            End If
        ElseIf node.Tag = "ElseIf" Then
            If fnd.IndexOf(UCase(trans("ИлиЕсли", , , True))) = 0 Then
                txt = txt.Substring(trans("ИлиЕсли", , , True).Length)
            End If
            If fnd.IndexOf(UCase(trans("Тогда", , , True))) = fnd.Length - trans("Тогда", , , True).Length Then
                txt = UCase(trans("ИлиЕсли")) & " " & transDeist(Left(txt, txt.Length - trans("Тогда", , , True).Length), neTransARename) & " " & UCase(trans("Тогда"))
            End If
        ElseIf node.Tag = "Else" Then
            If fnd.IndexOf(UCase(trans("В остальных случаях", , , True))) = 0 Then
                txt = trans("В остальных случаях") & txt.Substring(trans("В остальных случаях", , , True).Length)
            End If
        ElseIf node.Tag = "EndIf" Then
            If fnd.IndexOf(UCase(trans("Конец условия", , , True))) = 0 Then
                txt = trans("Конец условия") & txt.Substring(trans("Конец условия", , , True).Length)
            End If
        ElseIf node.Tag = "While" Then
            If fnd.IndexOf(UCase(trans("Повторяться пока", , , True))) = 0 Then
                txt = UCase(trans("Повторяться пока")) & " " & transDeist(txt.Substring(trans("Повторяться пока", , , True).Length), neTransARename)
            End If
        ElseIf node.Tag = "EndWhile" Then
            If fnd.IndexOf(UCase(trans("Конец цикла", , , True))) = 0 Then
                txt = trans("Конец цикла") & transDeist(txt.Substring(trans("Конец цикла", , , True).Length), neTransARename)
            End If
        ElseIf node.Tag = "Sobyt" Then
            txt = sZaglavnoi(trans(node.Text))
        ElseIf node.Tag = "Deist" Then
            txt = transDeist(node.Text, neTransARename)
        End If
        Return txt
    End Function


    ' Перевод действий дерева
    Public Function transDeist(ByVal txt As String, Optional ByVal neTransARename As reName = Nothing)
        Dim i As Integer, ret As String = "", wasChanged As Boolean = False
        Dim cs As New CodeString(txt, , False)
        Dim mss As MySplitStruct = cs.Split("")
        For i = 0 To mss.texty.Length - 1
            ' 1) Если данный сплит - это ИМЯ ОБЪЕКТА, разделенное точками
            cs = New CodeString(mss.texty(i), , False)
            Dim mss2 As MySplitStruct = cs.Split("naOdnomUrovne", ".")
            If mss2.texty.Length = 3 Then

                ' Если данная часть сплита - это объект ВЫЗВАТЬ СОБЫТИЕ, разделенные "_"
                If trans(mss2.texty(1), , , , True).ToUpper = MyZnak & trans("Вызвать событие").ToUpper Then
                    cs = New CodeString(mss2.texty(2), , False)
                    Dim mss3 As MySplitStruct = cs.Split("naOdnomUrovne", "_")
                    If mss3.texty.Length = 3 Then
                        ' Если в режиме ПЕРЕИМЕНОВАНИЯ ОБЪЕКТА
                        If neTransARename IsNot Nothing Then
                            If mss3.texty(0) = neTransARename.old_frmName Then
                                mss2.texty(2) = neTransARename.GetNewFormName(mss3.texty(0)) & mss3.splity(0) _
                                                                        & neTransARename.GetNewObjName(mss3.texty(1)) & mss3.splity(1) & mss3.texty(2)
                            End If
                        Else
                            ' Если в режиме ПЕРЕВОДА ДЕЙСТВИЙ
                            mss2.texty(2) = trans(mss3.texty(0), , , , True) & mss3.splity(0) & trans(mss3.texty(1), , , , True) & mss3.splity(1) & trans(mss3.texty(2), , , , True)
                        End If
                    End If
                End If

                ' Все соединяем
                ' Если в режиме ПЕРЕИМЕНОВАНИЯ ОБЪЕКТА
                If neTransARename IsNot Nothing Then
                    ' Чтобы не переименовывались объекты с тем же именем, но из других форм
                    If mss2.texty(0) = neTransARename.old_frmName Or mss2.texty(0) = MyZnak & trans("Полезные объекты") Then
                        Dim str As String = neTransARename.GetNewFormName(mss2.texty(0)) & mss2.splity(0) _
                                        & neTransARename.GetNewObjName(mss2.texty(1)) & mss2.splity(1) & mss2.texty(2)
                        If mss.texty(i) <> str Then mss.texty(i) = str : wasChanged = True
                    End If
                Else
                    ' Если в режиме ПЕРЕВОДА ДЕЙСТВИЙ
                    mss.texty(i) = trans(mss2.texty(0), , , , True) & mss2.splity(0) & trans(mss2.texty(1), , , , True) & mss2.splity(1) & trans(mss2.texty(2))
                End If

            ElseIf mss2.texty.Length = 2 Then
                If neTransARename IsNot Nothing Then
                    Dim str As String = neTransARename.GetNewFormName(mss2.texty(0)) & mss2.splity(0) _
                                                        & neTransARename.GetNewObjName(mss2.texty(1))
                    If mss.texty(i) <> str Then mss.texty(i) = str : wasChanged = True
                Else
                    ' Если в режиме ПЕРЕВОДА ДЕЙСТВИЙ
                    mss.texty(i) = trans(mss2.texty(0), , , , True) & mss2.splity(0) & trans(mss2.texty(1), , , , True)
                End If

            Else
                ' 2) Если данный сплит - это НЕЧТО, что ПЕРЕВОДИТСЯ (например. сюда попадают доп.функции)
                If neTransARename IsNot Nothing Then Continue For ' Если в режиме ПЕРЕИМЕНОВАНИЯ ОБЪЕКТА
                If trans(mss.texty(i)).Trim <> mss.texty(i).Trim Then
                    mss.texty(i) = trans(mss.texty(i))
                End If
            End If
        Next
        i = 0
        If mss.splity IsNot Nothing Then
            For i = 0 To mss.splity.Length - 1
                ret &= mss.texty(i) & mss.splity(i)
            Next
        End If
        ret &= mss.texty(i)
        If neTransARename IsNot Nothing And wasChanged = False Then Return txt.Trim
        Return (New CodeString(ret)).Text
    End Function
#End Region

    '<<<<<<<< ОСНОВНЫЕ ФУНКЦИИ >>>>>>>>>
#Region "FUNCTIONS"

    
    ' АССОЦИИРОВАТЬ С АЛДЖИ ФАЙЛЫ .alg
    Public Sub AssociateMyApp(ByVal sAppName As String, ByVal sEXE As String, ByVal sExt As String, Optional ByVal sIcon As String = "")
        Try
            Dim pr As New PropertysOther(Nothing)
            Const registrUrl As String = "HKCU\Software\Classes\"
            sEXE &= " %1" : sIcon &= ",-1"
            pr.CreateSubKey(New String() {registrUrl & sExt})
            pr.CreateKey(New String() {registrUrl & sExt, sAppName, Microsoft.Win32.RegistryValueKind.String})
            pr.CreateSubKey(New String() {registrUrl & sAppName})
            pr.CreateSubKey(New String() {registrUrl & sAppName & "\Shell"})
            pr.CreateSubKey(New String() {registrUrl & sAppName & "\Shell\Open"})
            pr.CreateSubKey(New String() {registrUrl & sAppName & "\Shell\Open\Command"})
            pr.CreateKey(New String() {registrUrl & sAppName & "\Shell\Open\Command", sEXE, Microsoft.Win32.RegistryValueKind.String})
            pr.CreateSubKey(New String() {registrUrl & sAppName & "\DefaultIcon"})
            pr.CreateKey(New String() {registrUrl & sAppName & "\DefaultIcon", sIcon, Microsoft.Win32.RegistryValueKind.String})
        Catch ex As Exception
            associateError = ex.Message
        End Try
    End Sub

    Function ConvetToStringArray(ByVal arr As Object()) As String()
        If arr Is Nothing Then Return Nothing
        Dim ret(arr.Length - 1) As String, i As Integer
        For i = 0 To arr.Length - 1
            ret(i) = arr(i)
        Next
        Return ret
    End Function

    Function ToMyDate(ByVal dat As Date) As String
        Return dat.GetDateTimeFormats()(25)
    End Function
    Function FromMyDate(ByVal dat As String) As Date
        If IsNumeric(dat) Then
            Return Date.FromBinary(dat)
        Else
            Dim res As Date
            'Dim tm As Date = DateAndTime.TimeValue("9:22:12")
            'Dim dt As Date = DateAndTime.DateValue("9:22:12")
            'Return dt.AddTicks(tm.Ticks)
            If Date.TryParse(dat, Nothing, Globalization.DateTimeStyles.None, res) Then Return res
        End If
        Return Nothing
    End Function
    Function getFirstDayOfWeek() As Global.Microsoft.VisualBasic.FirstDayOfWeek
        If lang_name = "Russian" Then Return FirstDayOfWeek.Monday Else Return FirstDayOfWeek.Sunday
    End Function
    Function ToMyTimeSpan(ByVal tim As Integer) As String
        Dim tm As String = TimeSpan.FromMilliseconds(tim).ToString()
        If tm.IndexOf(".") = -1 Then Return tm & ".00"
        If tm.IndexOf(".") + 3 <= tm.Length - 1 Then Return tm.Substring(0, tm.IndexOf(".") + 3)
        Return tm.PadRight(tm.IndexOf(".") + 3, "0")
    End Function
    Function FromMyTimeSpan(ByVal tim As String) As TimeSpan
        If tim = "" Then tim = 0
        If IsNumeric(tim) Then
            Return TimeSpan.FromMilliseconds(tim)
        Else
            Dim res As TimeSpan
            If TimeSpan.TryParse(tim, res) Then Return res
        End If
        Return TimeSpan.MaxValue
    End Function


    Public Function ReExist(ByVal arr As Array, ByVal val As Object) As Boolean
        If arr Is Nothing Then Return False
        Return (Array.IndexOf(arr, val) <> -1)
    End Function

    Function TextBoxAllow(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        If Iz.IsTbx(sender.MyObj) Then
            If Char.IsControl(e.KeyChar) Then Return False
            If UCase(sender.props.AllowInput) = UCase(trans("Только цифры")) Then
                If Char.IsDigit(e.KeyChar) = False Then Return True
            ElseIf UCase(sender.props.AllowInput) = UCase(trans("Только буквы")) Then
                If Char.GetUnicodeCategory(e.KeyChar) <> Globalization.UnicodeCategory.UppercaseLetter _
                And Char.GetUnicodeCategory(e.KeyChar) <> Globalization.UnicodeCategory.LowercaseLetter _
                Then
                    Return True
                End If
            ElseIf UCase(sender.props.AllowInput) = UCase(trans("Только буквы и цифры")) Then
                If Char.GetUnicodeCategory(e.KeyChar) <> Globalization.UnicodeCategory.DecimalDigitNumber _
                And Char.GetUnicodeCategory(e.KeyChar) <> Globalization.UnicodeCategory.UppercaseLetter _
                And Char.GetUnicodeCategory(e.KeyChar) <> Globalization.UnicodeCategory.LowercaseLetter _
                Then
                    Return True
                End If
            ElseIf UCase(sender.props.AllowInput) = UCase(trans("Только латинские буквы")) Then
                If Char.IsLetter(e.KeyChar) = False Then Return True
            ElseIf UCase(sender.props.AllowInput) = UCase(trans("Только латинские буквы и цифры")) Then
                If Char.IsLetterOrDigit(e.KeyChar) = False Then Return True
            End If
        End If
        Return False
    End Function


    ' ПОЛУЧЕНИЕ УНИКАЛЬНОГО ИДЕНТИФИКАТОРА
    Function GetUIN() As String
        Static rnd As New Random()
        Dim i, n As Integer, str As String = ""
        For i = 0 To 9
            n = rnd.Next(1, 50)
            If n > 25 Then n += 7
            str &= Chr(64 + n)
        Next
        Return str
    End Function

    ' Прогресс-Форма
    Sub ProgressFormShow(ByVal txt As String, Optional ByVal val As Integer = 0)
#If Ver <> "Http" Then
        ProgressForm.TopMost = True
        ProgressForm.ProgressBarValue = val
        ProgressForm.Label1.Text = txt
        ProgressForm.TopMost = True
        ProgressForm.Show()
        ProgressForm.Refresh()
#End If
    End Sub

    Function UbratKovich(ByVal str As String) As ErrString
        Dim ret As New ErrString(str)
        If ret.str = "" Then Return ret
        ' убрать кавычки, если есть
        If (ret.str.Chars(0) = """" And ret.str.Chars(ret.str.Length - 1) = """") Then
            Dim cs As New CodeString(str, "None", False)
            If ret.str.Length > 1 Then
                ' Если, после пропуска кавычек, замыкающая кавычка - это последний символ в строке, то это Строка и ее можно раскавычить
                If cs.PropuskKovich(0) = ret.str.Length - 1 Then
                    ret.str = ret.str.Substring(1, ret.str.Length - 2)
                Else
                    Return ret
                End If
            ElseIf ret.str = """" Then
                ret.err = Errors.InvalidKovich : Return ret
            End If
            ' Рас сняли кавычки по бокам, то заменить двойные кавычки на простые одинарные
            ret.str = ret.str.Replace("""""", """")
        End If
        Return ret
    End Function
    Function CreateKovich(ByVal str As String) As String
        If str Is Nothing Then Return str
        str = str.Replace("""", """""").Replace(Char.ConvertFromUtf32(8220), """""").Replace(Char.ConvertFromUtf32(8221), """""")
        Return str
    End Function

    ' ВСЕ СПОСОБЫ УКАЗАНИЯ "никакой" ПРЕОБРАЗУЮТСЯ В "Никакой"
    Function NikakoiEsli(ByVal str As String) As String
        If str = "" Or UCase(str) = UCase(trans("Никакой")) Then
            Return trans("Никакой")
        Else : Return str : End If
    End Function
    ' Когда либо "да", либо "нет"
    Function NetTakNet(ByVal str As String) As String
        If str = "" Or UCase(str) = UCase(trans("Нет")) Or str = "0" Then
            Return trans("Нет")
        ElseIf UCase(str) = UCase(trans("Да")) Or str = "1" Then
            Return trans("Да")
        Else : Return trans("Никакой") : End If
    End Function
    Function returnBoolean(ByVal str As String) As Boolean
        If str = "True" Or str = "False" Then Return str
        If UCase(str) = UCase(trans("Да")) Then Return True
        If UCase(str) = UCase(trans("Нет")) Then Return False
    End Function

    Function FileExistInArgs(ByVal value As String, ByVal es As ErrString) As ErrString
        Dim args() As String = {value}
        Return FileExistInArgs(args, 0, es)
    End Function
    Function FileExistInArgs(ByVal args() As String, ByVal index As Integer, ByVal es As ErrString) As ErrString
        If args Is Nothing = False Then
            If args.Length > index Then
                Dim path As String = UbratKovich(GetMaxPath(args(index))).str
                If NikakoiEsli(path) = trans("Никакой") Then Return es
                If System.IO.File.Exists(path) = False And System.IO.Directory.Exists(path) = False Then
                    es.err = Errors.FilePathNotExist(args(index)) : Return es
                End If
            Else
                es.err = Errors.FilePathNotExist(args(index)) : Return es
            End If
        Else
            es.err = Errors.noArguments("") : Return es
        End If
        Return es
    End Function

    ' Когда либо пустота это ноль
    Function NullTakNull(ByVal str As String) As String
        If str = "" Or str = trans("Никакой") Then str = "0"
        Return str
    End Function
    ' БАЗИКОВСКИЙ ТРУ ФОЛСЕ ПРЕОБРАЗУЕТСЯ В МОИ ДА ИЛИ НЕТ
    Function DaOrNet(ByVal bool As Boolean) As String
        If bool = True Then Return trans("Да") Else Return trans("Нет")
    End Function
    Function DaOrNet(ByVal bool As String) As Boolean
        If bool = trans("Да") Then Return True Else Return False
    End Function
    Function YesOrNo(ByVal bool As Boolean) As String
        If bool = True Then Return "Yes" Else Return "No"
    End Function
    Function YesOrNo(ByVal bool As String) As Boolean
        If bool = "Yes" Then Return True Else Return False
    End Function

    ' ПЕРЕВЕСТИ МЕНЮ (РЕКУРСИВНО)
    Sub transMenu(ByVal menu As Object, Optional ByVal dontRecurs As Boolean = False)
        Dim i As Integer
        For i = 0 To menu.Items.Count - 1
            If menu.Items(i).Text <> "" Then transMenuRecurs(menu.Items(i), , dontRecurs)
        Next
    End Sub
    Sub transMenuRecurs(ByRef mItem As Object, Optional ByVal transInfsOrNot As Boolean = True, Optional ByVal dontRecurs As Boolean = False) ' ToolStripDropDownItem) ', Optional ByVal TransOrTransPr As Boolean = True)
        Dim i As Integer
        '  If mItem.Text <> "Вспомогательные слова" Then
        ' If TransOrTransPr = True Then
        ' mItem.Text = trans(mItem.Text)
        ' Else
        ' mItem.Text = transPr(mItem.Text)
        ' End If
        ' Else
        ' mItem.Text = trans(mItem.Text) : TransOrTransPr = False
        ' End If
        Dim Name As String = System.Text.RegularExpressions.Regex.Match(mItem.Name, "[^0-9]*").Value
        mItem.Image = Pictures32.Images(Name)
        mItem.ImageTransparentColor = Color.Black
        If transInfsOrNot Then mItem.ToolTipText = transInfc(mItem.ToolTipText) Else mItem.ToolTipText = trans(mItem.ToolTipText)
        If transInfsOrNot Then mItem.Text = transInfc(mItem.Text) Else mItem.Text = trans(mItem.Text)
        If mItem.owner Is MainForm.MenuStrip1 Then mItem.foreColor = SkinColors("MenuColor")
        If mItem.Text <> "" And dontRecurs = False Then
            For i = 0 To mItem.DropDownItems.Count - 1
                transMenuRecurs(mItem.DropDownItems(i), transInfsOrNot)
            Next
        End If
    End Sub
    ' ПЕРЕВЕСТИ ПАНЕЛЬ
    Sub transPanel(ByVal panel As Object)
        Dim i As Integer, Name As String
        For i = 0 To panel.Items.Count - 1
            Name = System.Text.RegularExpressions.Regex.Match(panel.Items(i).Name, "[^0-9]*").Value
            If Name.IndexOf("Panel") >= 2 Then
                Name = Name.Replace("Panel", "Menu")
            Else
                If panel.Items(i).tag Is Nothing = False Then panel.Items(i).ToolTipText = InfoObjs(panel.Items(i).tag)
            End If
            panel.Items(i).Image = Pictures32.Images(Name)
            panel.Items(i).ImageTransparentColor = Color.Fuchsia
            panel.Items(i).Text = transInfc(panel.Items(i).Text)
            panel.Items(i).foreColor = SkinColors("MenuColor")
            panel.Items(i).ToolTipText = transInfc(panel.Items(i).ToolTipText)
            If InfoObjs(panel.Items(i).Name) Is Nothing = False Then
                panel.Items(i).ToolTipText &= ". " & InfoObjs(panel.Items(i).Name)
            End If
            If panel.Items(i).GetType.ToString = "System.Windows.Forms.ToolStripSplitButton" Then
                If panel.Items(i).DropDownItems.Count > 0 Then
                    transMenu(panel.Items(i).DropDown)
                End If
            End If
        Next
    End Sub
    ' ПЕРЕВЕСТИ МАССИВ
    Function transArray(ByVal ozhidaem() As String, Optional ByVal FromEng As Boolean = False) As String()
        Dim j As Integer
        For j = 0 To ozhidaem.Length - 1
            ozhidaem(j) = trans(ozhidaem(j), , FromEng)
        Next
        Return ozhidaem
    End Function
    ' Задний фон элементов пенелей инструментов, которые не влезли в размер формы и теперь находятся в списке в конце
    Sub backgroundPanel(ByVal panel As Object)
        Dim i As Integer
        For i = 0 To panel.Items.Count - 1
            If panel.Items(i).IsOnOverflow = True Then
                panel.Items(i).BackgroundImage = SkinPictures("Menu")
            Else
                panel.Items(i).BackgroundImage = Nothing
            End If
        Next
    End Sub
    ' ОТСОРТИРОВАТЬ ПАНЕЛЬ
    Sub sortPanel(ByVal panel As Object)
        Dim tsis(panel.Items.Count - 1) As ToolStripItem, i As Integer
        For i = 0 To panel.Items.Count - 1
            tsis(i) = panel.Items(i)
        Next
        panel.Items.Clear()
        Array.Sort(tsis, New SortByText)
        panel.Items.AddRange(tsis)
    End Sub
    Public Class SortByText
        Implements IComparer
        Public Function CompareTo(ByVal first As Object, ByVal second As Object) As Integer Implements IComparer.Compare
            Return String.Compare(first.Text, second.Text)
        End Function
    End Class
    Class SortByDataGridCell
        Implements IComparer
        Function Compare(ByVal first As Object, ByVal second As Object) As Integer Implements IComparer.Compare
            ' Передвинуть вверх, если номер строки меньше
            If first.RowIndex < second.RowIndex Then
                Return -1
            ElseIf first.RowIndex > second.RowIndex Then
                Return 1
            Else
                ' Передвинуть вверх, если номер столбца меньше
                If first.ColumnIndex < second.ColumnIndex Then
                    Return -1
                Else
                    Return 1
                End If
            End If
        End Function
    End Class

    ' ОТСОРТИРОВАТЬ МЕНЮ
    Sub sortMenu(ByVal mItem As Object)
        Dim tsis(mItem.DropDownItems.Count - 1) As ToolStripItem, i As Integer
        For i = 0 To mItem.DropDownItems.Count - 1
            tsis(i) = mItem.DropDownItems(i)
        Next
        mItem.DropDownItems.Clear()
        Array.Sort(tsis, New SortByTextMenu)
        mItem.DropDownItems.AddRange(tsis)
    End Sub
    Public Class SortByTextMenu
        Implements IComparer
        Public Function CompareTo(ByVal first As Object, ByVal second As Object) As Integer Implements IComparer.Compare
            If first.DropDownItems.Count = 0 And second.DropDownItems.Count > 0 Then
                Return 1
            ElseIf first.DropDownItems.Count > 0 And second.DropDownItems.Count = 0 Then
                Return -1
            Else
                Return String.Compare(first.Text, second.Text)
            End If
        End Function
    End Class

    ' ПЕРЕВОД ИНТЕРОВ В МОИ СИМВОЛЫ (|Р) И ОБРАТНО
    Function perevesti(ByVal chto As String, ByVal SdelatEnterOrSpecsimvol As Boolean) As String
        If chto Is Nothing Then Return ""
        If SdelatEnterOrSpecsimvol = True Then
            Return chto.Replace(Chr(182), vbCrLf).Replace(Chr(183), Chr(10))
        Else
            Return chto.Replace(vbCrLf, Chr(182)).Replace(Chr(10), Chr(183))
        End If
    End Function
    Function perevesti(ByVal chto As String, ByVal SdelatVmestoEnter As String) As String
        If chto Is Nothing Then Return chto
        Return chto.Replace(Chr(182), SdelatVmestoEnter).Replace(Chr(183), Chr(10))
    End Function
    Sub perevesti(ByRef chto As RichTextBox, ByRef kuda As RichTextBox, ByVal chtoZamen() As String, ByVal naChtoZamen As String)
        Dim ind, i As Integer
        If kuda Is Nothing Or chto Is Nothing Then Exit Sub
        If tempRich.Multiline = False Then tempRich.Multiline = True
        tempRich.Rtf = chto.Rtf
        For i = 0 To chtoZamen.Length - 1
            Do
                ind = tempRich.Text.IndexOf(chtoZamen(i))
                If ind = -1 Then Exit Do
                tempRich.SelectionStart = ind
                tempRich.SelectionLength = chtoZamen(i).Length
                tempRich.SelectedText = naChtoZamen
            Loop
        Next
        '        tempRich.Rtf = tempRich.Rtf.Substring(tempRich.Rtf.IndexOf("viewkind")).Replace(chtoZamen, naChtoZamen)
        kuda.Rtf = tempRich.Rtf
    End Sub

    ' ПОЛУЧЕНИЕ ВЫСОКОГО РЕГИСТРА ВСЕХ СВОЙСТВ И СОБЫТИЙ ОБЪЕКТОВ
    Public Sub CreatePropertySobytsUp(ByVal MyObj As Object)
        If MyObj Is Nothing Then Exit Sub
        Dim i As Integer, Up() As String
        ' Сортировка массивов
        Dim start As Integer = 0
        If MyObj.Propertys Is Nothing = False Then start = Array.IndexOf(MyObj.Propertys, trans("Имя"))
        If MnFrm Is Nothing = False Then start = 0
        If start = -1 Then start = 0
        If MyObj.Propertys Is Nothing = False Then Array.Sort(MyObj.Propertys, start, MyObj.Propertys.length - start)
        If MyObj.Methods Is Nothing = False Then Array.Sort(MyObj.Methods)
        If MyObj.Sobyts Is Nothing = False Then Array.Sort(MyObj.Sobyts)
        ' Увеличить регистр у свойств
        If MyObj.Propertys Is Nothing = False Then
            ReDim Up(MyObj.Propertys.Length - 1)
            For i = 0 To MyObj.Propertys.Length - 1 : Up(i) = UCase(MyObj.Propertys(i)) : Next
            MyObj.PropertysUp = Up
        End If
        ' Увеличить регистр у методов
        Try
            If MyObj.Methods Is Nothing = False Then
                ReDim Up(MyObj.Methods.Length - 1)
                For i = 0 To MyObj.Methods.Length - 1 : Up(i) = UCase(MyObj.Methods(i)) : Next
                MyObj.MethodsUp = Up
            End If
        Catch ex As Exception
        End Try
        ' Увеличить регистр у событий
        If MyObj.Sobyts Is Nothing = False Then
            ReDim Up(MyObj.Sobyts.Length - 1)
            For i = 0 To MyObj.Sobyts.Length - 1 : Up(i) = UCase(MyObj.Sobyts(i)) : Next
            MyObj.SobytsUp = Up
        End If
    End Sub

    ' ПОЛУЧЕНИЕ ШИРИНЫ КОМБОБОКСА, В ЗАВИСИМОСТИ ОТ МАКСИМАЛЬНОГО КОЛИЧЕСТВА БУКВ В ДАННОМ КОМБОБОКСЕ
    Sub ComboBoxWidth(ByVal combo As ComboBox)
        Dim i, widthCombo As Integer
        For i = 0 To combo.Items.Count - 1
            If widthCombo < combo.Items(i).ToString.Length * LiterWidth Then
                widthCombo = combo.Items(i).ToString.Length * LiterWidth
            End If
        Next
        combo.DropDownWidth = widthCombo
        combo.MaxDropDownItems = 30
    End Sub
    ' ПОЛУЧЕНИЕ ШИРИНЫ ЛИСТБОКСА, В ЗАВИСИМОСТИ ОТ МАКСИМАЛЬНОГО КОЛИЧЕСТВА БУКВ В ДАННОМ ЛИСТБОКСЕ
    Sub ListBoxWidthHeight(ByVal combo As ListBox)
        Dim i, widthCombo As Integer
        For i = 0 To combo.Items.Count - 1
            If widthCombo < combo.Items(i).ToString.Length * LiterWidth Then
                widthCombo = combo.Items(i).ToString.Length * LiterWidth
            End If
        Next
        If widthCombo < 60 Then widthCombo = 60
        combo.Width = widthCombo + 3
        If combo.Height > 10 + combo.ItemHeight * 20 Then combo.Height = 10 + combo.ItemHeight * 20
    End Sub

    ' ПОЛУЧЕНИЕ ИНДКСА В КОМБОБОКСЕ ПО ТЕКСТУ
    Public Function GetIndexInCombo(ByVal str As String, ByVal combo As ComboBox) As Integer
        Dim i As Integer
        str = UCase(Trim(str))
        For i = 0 To combo.Items.Count - 1
            If UCase(combo.Items(i)) = str Then Return i
        Next
        Return -1
    End Function

    ' ПОЛУЧЕНИЕ ТЕКСТА ПО МАССИВУ СТРОК
    Function getStrFromArray(ByVal arr() As String, Optional ByVal i1 As Integer = 0, Optional ByVal i2 As Integer = -1) As String
        'Dim i As Integer, str As String = ""
        'If i2 = -1 Then i2 = arr.Length - 1
        'For i = i1 To i2
        '    str &= arr(i) & vbCrLf
        'Next
        'Return str
        Dim i As Integer
        If i2 = -1 Then i2 = arr.Length - 1
        Dim arr2(i2 - i1) As String
        For i = 0 To i2 - i1
            arr2(i) = arr(i1 + i)
        Next
        Return Join(arr2, vbCrLf) & vbCrLf
    End Function

    ' ПОЛУЧИТЬ НУЖНЫЙ ПАРАМЕТР ИЗ ОБЪЕКТА ИЛИ УЗЛА, СОХРАНЕННОГО В ТЕКСТОВОМ ВИДЕ
    Function GetNuzhPunkt(ByVal punkt As String, ByVal gde As String) As String
        Dim p As String
        p = vbCrLf & punkt & vbCrLf
        Dim ind As Integer = gde.IndexOf(p)
        If ind = -1 Then
            p = punkt & vbCrLf : ind = gde.IndexOf(p)
            If ind <> 0 Then Return Nothing
        End If
        Dim len As Integer = gde.IndexOf(vbCrLf, ind + p.Length - 1) - ind - p.Length
        If len < 0 Then Return gde.Substring(ind + p.Length)
        Return gde.Substring(ind + p.Length, len)
    End Function

    Function IsNull(ByVal val1 As String, ByVal val2 As String)
        If val1 Is Nothing Or String.IsNullOrEmpty(val1.Trim()) Then
            Return val2
        Else
            Return val1
        End If
    End Function

    ' СОЗДАНИЕ ВСЕХ ОБЪЕКТОВ И ДЕРЕВА ЕСЛИ НАДО
    Public isOpening As Boolean = False
    Sub CreateObjects(ByVal objects As String, ByVal withTree As Boolean, ByVal isRun As Boolean, ByRef f() As Forms, ByRef tree As TreeView, ByRef Breaks() As TreeNode, ByRef proj As Object, Optional ByVal fromEng As Boolean = False)
        Dim i, j, oldi, ind As Integer, ProjectParams As String

        ' Язык проекта
        ind = Trim(objects).IndexOf("Language = ") + "Language = ".Length
        If ind = "Language = ".Length Or ind = "Language = ".Length + 1 Then
            Dim newLang As String = Trim(objects).Substring(ind, Trim(objects).IndexOf(vbCrLf) - ind)
            If isDevelop = False Then
                lang_name = newLang
                CreatePoleznie() : CreateArrays()
            ElseIf newLang <> lang_name Then
                If IsHttpCompil = False Then
                    lang_name = newLang : setLangs()
                    ' Перезапись всех ключевых слов и функций
                    CreatePoleznie() : CreateArrays()
                    CreateConstants() : CreateHelpWords()
                End If
            Else
                CreatePoleznie() : CreateArrays()
            End If
            objects = objects.Substring(objects.IndexOf(vbCrLf) + 2)
        Else
            lang_name = lang_def : setLangs()
            ' Перезапись всех ключевых слов и функций
            CreatePoleznie() : CreateArrays() : CreateConstants() : CreateHelpWords()
        End If

        isOpening = True 'Для того, что бы copyImage не копировал рисунки

        ' СОБСТВЕНО СОЗДАНИЕ ВСЕХ ОБЪЕКТОВ
        Dim MyObjs() As Object = Perevodi.ToObjFromStr(objects, isRun, fromEng, ProjectParams)
        isOpening = False

        If Breaks Is Nothing Then ReDims(Breaks)
        If tree Is Nothing Then tree = New TreeView


        ' Создать массив полезных объектов на форме
        ReDims(f) : f(f.Length - 1) = New Forms(, True)

        Dim prevFrm As Object = Nothing
        ' Настройка всех объектов
        If MyObjs Is Nothing = False Then
            For i = 0 To MyObjs.Length - 1
                If Iz.IsFORM(MyObjs(i)) Then
                    ' Окна самые последнии вызывают событие Создане
                    If isRun Then If prevFrm IsNot Nothing Then prevFrm.obj.RaiseCreate()
                    prevFrm = MyObjs(i)
                    ' Если сейчас происходит не загрузка проекта
                    If fromEng = False Then
                        ReDims(f) : f(f.Length - 1) = MyObjs(i)
                        ReDims(f(f.Length - 1).MyObjs) : f(f.Length - 1).MyObjs(f(f.Length - 1).MyObjs.Length - 1) = MyObjs(i)
                    End If
                    ' Если дерево не передали, то его создаем из объекта
                    If withTree = False Then
                        If tree.Nodes.IndexOfKey(MyObjs(i).NodeTemp.Text) = -1 Then
                            ' ведь у формы две одинкаковых ветки идущие с самого начала дерева, поэтому делаем клон
                            Dim clon As New TreeNode(MyObjs(i).NodeTemp.Text)
                            clon.ImageKey = MyObjs(i).NodeTemp.ImageKey : clon.SelectedImageKey = MyObjs(i).NodeTemp.SelectedImageKey : clon.Tag = MyObjs(i).NodeTemp.Tag : clon.Name = MyObjs(i).NodeTemp.Name
                            tree.Nodes.Add(clon) : tree.Nodes(tree.Nodes.Count - 1).Nodes.Add(MyObjs(i).NodeTemp)
                        End If
                    End If

                    ' МиниМеню для панели полуобъектов
                    If isRun = False Then MyObjs(i).obj.Parent.Parent.Panel2.ContextMenuStrip = MainForm.SplitPanelMenu
                Else
                    Dim frm As Object = MyObjs(i).GetMyForm
                    If frm Is Nothing Then Continue For
                    If Array.IndexOf(frm.MyObjs, MyObjs(i)) = -1 Then
                        ReDimsO(MyObjs(i).GetMyForm.MyObjs)
                        MyObjs(i).GetMyForm.MyObjs(MyObjs(i).GetMyForm.MyObjs.length - 1) = MyObjs(i)
                    End If
                    ' Если дерево не передали, то его создаем из объекта
                    If withTree = False Then
                        If MyObjs(i).NodeTemp IsNot Nothing Then
                            If MyObjs(i).GetMyForm.GetNode.nodes.IndexOfKey(MyObjs(i).NodeTemp.Text) = -1 Then
                                MyObjs(i).GetMyForm.GetNode.nodes.add(MyObjs(i).NodeTemp)
                            End If
                        End If
                    End If
                End If
                MyObjs(i).NodeTemp = Nothing
                If withTree = False Then MyObjs(i).tree = tree

                ' Вызвать моеСобытие - создание объекта
                If isRun Then If Iz.IsFORM(MyObjs(i)) = False Then MyObjs(i).obj.RaiseCreate()
            Next
        End If
        ' Окна самые последнии вызывают событие Создане
        If isRun Then If prevFrm IsNot Nothing Then prevFrm.obj.RaiseCreate()

        ' Донастройка проекта, если он создается полностью из файла с листингом кода программы
        ' Создание хистори левелов
        'If fromEng Or withTree = False Then
        For i = 0 To f.Length - 1
            f(i).HistoryLevel = New ArrayList()
            f(i).HistoryLevel.AddRange(f(i).MyObjs) ': f(i).HistoryLevel.RemoveAt(0)
            For j = 0 To f(i).MyObjs.Length - 1
                ' элементы, которые изза глюка пропали в хистори левели и теперь никак не могут там вновь появиться
                'If f(i).MyObjs(j).HistoryTemp = Nothing Then
                '    ReDims(hhh) : hhh(hhh.Length - 1) = f(i).MyObjs(j)
                'End If
                f(i).HistoryLevel.Remove(f(i).MyObjs(j))
                If f(i).HistoryLevel.Count > f(i).MyObjs(j).HistoryTemp Then
                    f(i).HistoryLevel.Insert(f(i).MyObjs(j).HistoryTemp, f(i).MyObjs(j))
                Else
                    f(i).HistoryLevel.Add(f(i).MyObjs(j))
                End If
            Next
            ' элементы, которые изза глюка пропали в хистори левели и теперь никак не могут там вновь появиться
            'If hhh Is Nothing = False Then f(i).HistoryLevel.AddRange(hhh)
            ' Расстановка элементов по созданному хисторилевелу
            For j = 0 To f(i).HistoryLevel.Count - 1
                f(i).HistoryLevel(j).obj.BringToFront()
            Next
        Next
        'End If

        ' Занесение ПАРАМЕТРОВ ПРОЕКТА (например контрольных точек, папки с рисунками)
        CreateProjParams(ProjectParams)

        ' Окончательная загрузка элементов
        If isRun And MyObjs Is Nothing = False Then
            For i = 0 To MyObjs.Length - 1
                MyObjs(i).obj.load()
            Next
        End If
    End Sub
    Sub CreateProjParams(ByVal prParams As String, Optional ByVal findIhInCode As Boolean = False)
        Dim i As Integer = 0
        If findIhInCode Then
            Dim fndS As String = vbCrLf & "#ProjectParams" & vbCrLf
            Dim ind As Integer = prParams.LastIndexOf(fndS)
            If ind = -1 Then Exit Sub
            prParams = prParams.Substring(ind + fndS.Length)
        End If
        Dim rtb As New RichTextBox() : rtb.Text = prParams
        Dim ProjParams() As String = rtb.Lines
        If ProjParams.Length > 0 Then
            If ProjParams(i) = "#Comms" Then
                i += 1
                Dim comm As String = ""
                While ProjParams(i) <> "#EndComms"
                    comm &= ProjParams(i) & vbCrLf : i += 1
                    '   ReDims(Breaks) : Breaks(Breaks.Length - 1) = proj.GetNodeFromName(ProjParams(i), tree) 
                End While
                proj.PasteTree(Nothing, comm, False)
                i += 1
            End If
            If ProjParams(i) = "#Breaks" Then
                i += 1
                While ProjParams(i) <> "#EndBreaks"
                    ReDims(Breaks) : Breaks(Breaks.Length - 1) = proj.GetNodeFromName(ProjParams(i), Tree) : i += 1
                End While
                i += 1
            End If
            If ProjParams(i) = "#PoleznieDistance" Then
                i += 1 : Dim j As Integer = 0
                While ProjParams(i) <> "#EndPoleznieDistance"
                    If proj.f(j).SplitCont IsNot Nothing Then
                        proj.f(j).SplitCont.SplitterDistance = proj.f(j).SplitCont.Height - ProjParams(i) + proj.f(j).SplitCont.SplitterWidth
                    End If
                    j += 1 : i += 1
                End While
                i += 1
            End If
            If ProjParams(i) = "#Expands" Then
                i += 1
                While ProjParams(i) <> "#EndExpands"
                    Dim node As TreeNode = proj.GetNodeFromName(ProjParams(i), Tree, True)
                    If node IsNot Nothing Then
                        If node.IsExpanded Then node = proj.GetNodeFromName(ProjParams(i), node, False)
                        If node Is Nothing = False Then node.Expand()
                    End If
                    i += 1
                End While
                i += 1
            End If
            If ProjParams(i) = "#SelNode" Then
                i += 1
                Tree.SelectedNode = proj.GetNodeFromName(ProjParams(i), Tree)
                i += 1
            End If
            If ProjParams(i) = "#ActiveForm" Then
                i += 1 : proj.ActiveForm = proj.GetMyObjFromUniqName(ProjParams(i)) : i += 1
                If proj.ActiveForm Is Nothing Then proj.ActiveForm = proj.f(0)
                If proj.ActiveForm IsNot Nothing Then proj.ActiveForm.SelectTab()
            End If
            If ProjParams(i) = "#ActiveObj" Then
                If proj.ActiveForm Is Nothing = False Then
                    i += 1 : proj.ActiveForm.SetActiveObject(proj.GetMyObjFromUniqName(ProjParams(i)))
                    proj.ActiveForm.marker_vis() : i += 1
                End If
            End If
            If ProjParams(i) = "#ImagePath" Then
                i += 1 : proj.iPathShort = ProjParams(i) : proj.iPath = (proj.pPath & proj.iPathShort).Replace("\\", "\") : i += 1
                If proj.iPath.Chars(proj.iPath.Length - 1) <> "\" Then proj.iPath &= "\"
                Papks(LCase(trans("Рисунки проекта"))) = proj.iPath
            End If
            If ProjParams(i) = "#ImageDefName" Then
                i += 1 : proj.pPicNameDef = ProjParams(i) : i += 1
            End If
            If ProjParams(i) = "#pProgressForm" Then
                i += 1 : proj.pProgressForm = ProjParams(i) : i += 1
            End If
            If ProjParams(i) = "#Icon" Then
                i += 1 : proj.pIcon = ProjParams(i) : i += 1
            End If
        End If
    End Sub

    ' ПОЛУЧИТЬ ВЕТКИ ПО ТИПУ
    Dim retNs() As TreeNode
    Function GetNodesFromTypeTag(ByVal tag As String, Optional ByVal root As Object = Nothing, Optional ByVal isObj As Boolean = False, Optional ByVal vnutriRecurs As Boolean = False) As TreeNode()
        Dim i As Integer
        If root Is Nothing Then root = Tree
        If tag = "" Then Return root
        If vnutriRecurs = False Then retNs = Nothing

        For i = 0 To root.Nodes.Count - 1
            If isObj = True Or root.Nodes(i).level > 0 Then
                If root.Nodes(i).tag = tag Then ReDims(retNs) : retNs(retNs.Length - 1) = root.Nodes(i)
            End If
            GetNodesFromTypeTag(tag, root.Nodes(i), isObj, True)
        Next
        Return retNs
    End Function

    ' ПОЛУЧИТЬ ОБЪЕКТ ЗНАЯ ХОТЬ КАКУЮ-НИБУДЬ ВЕТКУ ИЛИ ПОДВЕТКУ ДЕРЕВА
    Function GetMyObjsFromTreeNode(Optional ByVal node As TreeNode = Nothing, Optional ByVal includeToo As Boolean = False) As Object()
        ' Если ветки не передали, то берем выделенный
        If node Is Nothing Then node = Tree.SelectedNode
        If node Is Nothing Then Return Nothing
        Dim MyObjs() = Nothing, temp() As Object, i, j, ind As Integer
        ' Идем до первого уровня ветки, если уровень больше 1
        While node.Level > 1 : node = node.Parent : End While
        ' Нулевой уровень - уровень форм
        If node.Level = 0 Then
            Return proj.GetMyFormsFromName(node.Text)
        Else
            ' Берем имя формы из родителя ветки
            Dim forms() = proj.GetMyFormsFromName(node.Parent.Text)
            If forms Is Nothing Then ReDim temp(0) : temp(0) = node : Return temp
            ' Ищем в найденых формах объекты, с именами, как текст ветки
            For i = 0 To forms.Length - 1
                temp = forms(i).GetMyObjsFromName(node.Text)
                If temp Is Nothing = False Then
                    ' Заносим объекты, с именами, как текст ветки в массив
                    For j = 0 To temp.Length - 1
                        ReDim Preserve MyObjs(ind) : MyObjs(ind) = temp(j) : ind += 1
                    Next
                End If
            Next
        End If : Return MyObjs
    End Function
    ' ПЕРЕВОДИТ МОЮ СТРОКУ В ДАБЛ
    Public Function ToDouble(ByVal str As String) As Double
        Dim del As Integer, ret As Double, simb = PointSimb1
        If str = "" Or str = """""" Then str = 0
        Dim ind As Integer = str.IndexOf(PointSimb1)
        If ind = -1 Then
            ind = str.IndexOf(PointSimb2)
            simb = PointSimb2
            If ind = -1 Then Return str
        End If
        Dim mantisa As String = ""
        If str.IndexOf("E") <> -1 Then
            mantisa = str.Substring(str.IndexOf("E"))
            str = Left(str, str.IndexOf("E"))
        End If
        del = str.Length - 1 - ind
        ret = str.Replace(simb, "")
        ret /= "1" & StrDup(del, "0")
        ret = ret & mantisa
        Return ret
    End Function
    Public Function ToDouble() As Double
        Return 0
    End Function

    ' РАБОТА С КЛЮЧАМИ РЕЕСТРА
    Function GetRegistryKey(ByVal allPath As String, ByRef name As String) As RegistryKey
        Dim key, rootKey As RegistryKey
        Dim vetv As String = allPath & "\"
        ' определение изначального корня
        Dim koren As String = vetv.Split("\")(0)
        If koren.Length >= vetv.Length - 1 Then vetv &= "\" ' если передали чисто корень
        If koren = "HKEY_CLASSES_ROOT" Or koren = "HKCR" Then
            rootKey = Registry.ClassesRoot
        ElseIf koren = "HKEY_CURRENT_CONFIG" Or koren = "HKCR" Then
            rootKey = Registry.CurrentConfig
        ElseIf koren = "HKEY_CURRENT_USER" Or koren = "HKCU" Then
            rootKey = Registry.CurrentUser
        ElseIf koren = "HKEY_DYNDATA" Or koren = "HKDD" Then
            rootKey = Registry.DynData
        ElseIf koren = "HKEY_LOCAL_MACHINE" Or koren = "HKLM" Then
            rootKey = Registry.LocalMachine
        ElseIf koren = "HKEY_PERFORMANCE_DATA" Or koren = "HKPD" Then
            rootKey = Registry.PerformanceData
        ElseIf koren = "HKEY_USERS" Or koren = "HKU" Then
            rootKey = Registry.Users
        Else
            Errors.MessangeExclamen(Errors.notRegistry(koren))
            Return Nothing
        End If
        ' Если нужно значение папки реестра
        name = vetv.Substring(vetv.LastIndexOf("\") + 1)
        vetv = vetv.Substring(koren.Length + 1, vetv.Length - koren.Length - 1 - name.Length - 1)
        key = rootKey.OpenSubKey(vetv, True)
        ' Если нужно значение листа реестра
        If key Is Nothing Then
            vetv = allPath
            name = vetv.Substring(vetv.LastIndexOf("\") + 1)
            Dim len As Integer = vetv.Length - koren.Length - 1 - name.Length - 1
            If len < 0 Then len = 0
            vetv = vetv.Substring(koren.Length + 1, len)
            key = rootKey.OpenSubKey(vetv, True)
            If key Is Nothing Then Errors.MessangeExclamen(Errors.notRegistry(koren & "\" & vetv)) : Return Nothing
        End If
        ' вернуть вычисленный ключ
        Return key
    End Function
    Sub CreateRegistryKey(ByVal k As RegistryKey, ByVal nam As String, ByVal value As String, ByVal type As Microsoft.Win32.RegistryValueKind)
        Try
            If type = RegistryValueKind.Binary Then
                Dim i As Integer
                value = Trim(value)
                Dim str() As String = value.Split(" ")

                ' если битовая строка пустая, занести битовый массив нулевой длинны
                If str.Length = 0 Or NikakoiEsli(value) = trans("Никакой") Then
                    Dim b() As Byte = {}
                    k.SetValue(nam, b, type)
                    Exit Sub
                End If

                ' Перевод из битовой строки в массив byte()
                Dim byt(str.Length - 1) As Byte
                For i = 0 To byt.Length - 1
                    If IsNumeric(str(i)) And str(i) < 255 And str(i) >= 0 Then
                        byt(i) = str(i)
                    Else
                        MsgBox(Errors.InvalidFormatRegistry(value, k.ToString), MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Next

                k.SetValue(nam, byt, type)
            ElseIf type = RegistryValueKind.DWord Or type = RegistryValueKind.QWord Then
                If NikakoiEsli(value) = trans("Никакой") Then value = 0

                ' если передали не число
                If IsNumeric(value) = False Then
                    MsgBox(Errors.InvalidFormatRegistry(value, k.ToString), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                k.SetValue(nam, value, type)
            Else
                k.SetValue(nam, value, type)
            End If
        Catch ex As Exception
            Errors.MessangeCritic(ex.Message)
        End Try
    End Sub

    ' ПОЛУЧИТЬ ПО ИМЕНИ МЕНЮ КОНТЕСТНОЕ МЕНЮ
    Public Function GetContextMenu(ByVal MyObj As Object, ByVal CxtMenuName As String) As Object
        If MyObj Is Nothing Then Return Nothing
        Dim myF As Object = MyObj.getmyform : If myF Is Nothing Then Return Nothing
        Dim CnMn = MyObj.proj.GetMyObjFromUniqName(myF.obj.name & "." & CxtMenuName)
        If IsArray(CnMn) Then CnMn = CnMn(0)
        Return CnMn
    End Function
    ' НАЙТИ ОБЪЕКТ ХОЗЯИН КОНТЕКСТНОГО МЕНЮ ПО ЭЛЕМЕНТУ МЕНЮ
    Public Function FindOwnerContextMenu(ByVal mItem As Object) As Object
        If Iz.IsCM(mItem.myObj) Then
            Return mItem.CnMn.SourceControl
        End If

        ' Поиск корневого меню
        While mItem.myObj.conteiner Is Nothing = False And Iz.IsCM(mItem.myObj.conteiner) = False And Iz.IsMM(mItem.myObj.conteiner) = False
            mItem = mItem.myObj.conteiner
        End While


        If mItem.myObj.conteiner Is Nothing Then Return Nothing
        Return mItem.myObj.conteiner.obj
        ' если это главное меню
        ' If mItem.Owner.GetType.ToString <> "System.Windows.Forms.ContextMenuStrip" Then Return mItem.Owner
        ' Если это контекстное меню
        ' Return CType(mItem.Owner, ContextMenuStrip)
    End Function

    ' ЗАПУЩЕН ЛИ ПРОЕКТ
    Function isRUN() As Boolean
        If RunProj Is Nothing Then Return False
        If RunProj.isRUN = False Then Return False
        Return True
    End Function
    ' ЗАПУЩЕН ЛИ ПРОЕКТ
    Function isRUNorPause() As Boolean
        If RunProj Is Nothing Then Return False
        If RunProj.isRUN = False And RunProj.Pause = False Then Return False
        Return True
    End Function

    ' ПОЛУЧЕНИЕ URi ПО СТРОКЕ
    Function GetUrlFromString(ByVal str As String) As Uri
        Dim ur As Uri = Nothing, oldStr As String = str

        If Uri.TryCreate(str, UriKind.Absolute, ur) = True Then Return ur

        str = "http://" & str
        If Uri.TryCreate(str, UriKind.Absolute, ur) = True Then Return ur

        MsgBox(Errors.InvalidUrl(oldStr))
        Return Nothing
    End Function

    ' УБИРАНИЕ КЛЮЧЕВЫХ СЛОВ
    Function UbratKluchSlova(ByVal type As String, ByVal str As String) As String
        Dim slovo As String : str = Trim(str)
        If type = "While" Then
            slovo = UCase(trans("Повторяться пока")) & " "
            If UCase(str).IndexOf(slovo) = 0 Then str = str.Substring(slovo.Length)
        End If
        If type = "If" Then
            slovo = UCase(trans("Если")) & " "
            If UCase(str).IndexOf(slovo) = 0 Then str = str.Substring(slovo.Length)
            slovo = " " & UCase(trans("Тогда"))
            If UCase(str).LastIndexOf(Trim(slovo)) = 0 Then str = ""
            If UCase(str).LastIndexOf(slovo) <> -1 Then
                If UCase(str).LastIndexOf(slovo) = str.Length - slovo.Length Then str = str.Substring(0, str.Length - slovo.Length)
            End If
        End If
        If type = "ElseIf" Then
            slovo = UCase(trans("ИлиЕсли"))
            If UCase(str).IndexOf(slovo) = 0 Then str = str.Substring(slovo.Length)
            slovo = " " & UCase(trans("Тогда"))
            If UCase(str).LastIndexOf(Trim(slovo)) = 0 Then str = ""
            If UCase(str).LastIndexOf(slovo) = str.Length - slovo.Length And str.Length - slovo.Length <> -1 Then str = str.Substring(0, str.Length - slovo.Length)
        End If
        If type = "Else" Then str = ""
        Return Trim(str)
    End Function
    ' УБИРАНИЕ КЛЮЧЕВЫХ СЛОВ
    Function SozdatKluchSlova(ByVal type As String, ByVal str As String) As String
        str = Trim(str)
        If type = "If" Then
            str = UCase(trans("Если")) & " " & str & " " & UCase(trans("тогда"))
        ElseIf type = "ElseIf" Then
            str = UCase(trans("ИлиЕсли")) & " " & str & " " & UCase(trans("тогда"))
        ElseIf type = "Else" Then
            str = trans("В остальных случаях")
        ElseIf type = "EndIf" Then
            str = trans("Конец условия")
        ElseIf type = "While" Then
            str = UCase(trans("ПОВТОРЯТЬСЯ ПОКА")) & " " & str
        ElseIf type = "EndWhile" Then
            str = trans("Конец цикла")
        End If
        Return str
    End Function

    ' Преобразование массива строк в массив байтов
    Public Function toByteArray(ByVal str As String) As Byte()
        Dim i As Integer, bts(str.Length / 3 - 1) As Byte
        Try
            For i = 0 To bts.Length - 1
                bts(i) = str(3 * i) & str(3 * i + 1) & str(3 * i + 2)
            Next
        Catch ex As Exception
            Return Nothing
        End Try
        Return bts
    End Function
    ' Преобразование массива байтов в массив строк
    Public Function toStrArray(ByVal bts() As Byte) As String
        Dim i As Integer, str(bts.Length - 1) As String
        For i = 0 To bts.Length - 1
            str(i) = String.Format(bts(i), "00#")
            If str(i).Length = 1 Then str(i) = "00" & str(i)
            If str(i).Length = 2 Then str(i) = "0" & str(i)
        Next
        Return Join(str, "")
    End Function

    ' ИЗМЕНИТЬ КОДИРОВКУ ФАЙЛОВ  ChangeFileEncoding("E:\Work\Alg\Algoritm 2", "*.vb", SearchOption.AllDirectories)
    Function ChangeFileEncoding(pPathFolder As String, pExtension As String, pDirOption As IO.SearchOption) As Integer
        Dim Counter As Integer
        Dim s As String
        Dim reader As IO.StreamReader
        Dim gEnc As System.Text.Encoding
        Dim direc As IO.DirectoryInfo = New IO.DirectoryInfo(pPathFolder)
        For Each fi As IO.FileInfo In direc.GetFiles(pExtension, pDirOption)
            s = ""
            reader = New IO.StreamReader(fi.FullName, System.Text.Encoding.Default, True)
            s = reader.ReadToEnd
            gEnc = reader.CurrentEncoding
            reader.Close()

            If (gEnc.EncodingName <> System.Text.Encoding.UTF8.EncodingName) Then
                s = IO.File.ReadAllText(fi.FullName, gEnc)
                IO.File.WriteAllText(fi.FullName, s, System.Text.Encoding.UTF8)
                Counter += 1
                Debug.Write("<br>Saved #" & Counter & ": " & fi.FullName & " - <i>Encoding was: " & gEnc.EncodingName & "</i>")
            End If
        Next

        Return Counter
    End Function

#End Region

    ' <<<<<<<< ОПЕРАЦИИ ОБРАБОТКИ ЦВЕТОВ >>>>>>>>>
#Region "COLORS"

    ' ВОЗВРАЩАЕТ СТРОКУ str НО СДЕЛАННУЮ С ЗАГЛАВНОЙ БУКВОЙ
    Function sZaglavnoi(ByVal str As String) As String
        If str.Length > 0 Then str = UCase(str.Chars(0)) + str.Substring(1)
        Return str
    End Function

    ' ПЕРЕВОДИТ ЦВЕТ БАЗИКА, В МОЙ ЦВЕТ
    Public Function ToMyColor(ByVal col As Color) As String
        If col = Nothing Then Return Nothing
        If col = Color.Transparent Then Return trans("Никакой")
        ' Если у цвета есть название буквами
        If Colors.ContainsValue(col) Then
            Return sZaglavnoi(trans(Colors.GetKey(Colors.IndexOfValue(col))))
        Else
            ' Перевести цвет в мой цвет
            Return col.R & "; " & col.G & "; " & col.B & ";"
        End If
    End Function
    Function Int(ByVal str As String) As Integer
        If str = "True" Then Return 1
        If str = "False" Then Return 0
        Return Val(str)
    End Function

    ' ПЕРЕВОДИТ МОЙ ЦВЕТ, В МОЙ ЦВЕТ
    Public Function FromMyColor(ByVal col As String, Optional ByVal notError As Boolean = False) As Color
        If NikakoiEsli(col) = trans("Никакой") Then Return Color.Transparent
        ' Если у цвета есть название буквами
        If Colors.ContainsKey(LCase(trans(col))) Then
            Return Colors.Item(LCase(trans(col)))
        Else
            ' Если путь папки в кавычках то вытащить его из кавычек
            If col.Length > 2 Then
                If col(0) = """" And col(col.Length - 1) = """" Then col = col.Substring(1, col.Length - 2)
            End If
            Dim sp() As String = col.Split(";"), i As Integer
            ' Разбить строку на красный, зеленый, синий
            If sp.Length = 4 Then
                For i = 0 To sp.Length - 1 : sp(i) = Trim(sp(i)) : Next
                Try
                    Return Drawing.Color.FromArgb(sp(0), sp(1), sp(2))
                Catch ex As Exception
                    If notError = True Then Errors.MessangeInfo(ex.Message) : Return Nothing
                End Try
            End If
        End If
        Return Nothing
    End Function

#End Region

    ' <<<<<<<< ОПЕРАЦИИ ОБРАБОТКИ ФАЙЛОВ И ПАПОК >>>>>>>>>
#Region "PATHS"

    ' КОПИРОВАНИЕ РИСУНКА В ПАПКУ С ПРОЕКТОМ
    Public Function copyImage(ByVal fromFile As String, Optional ByVal prinuditalno As Boolean = False) As String
        If isOpening Then Return fromFile
        If NikakoiEsli(fromFile) = trans("Никакой") Then
            Return trans("Никакой")
        Else
            Dim newName As String = fromFile
            If fromFile.IndexOf(proj.iPath) = -1 Or prinuditalno Then
                ' Получить уникальное имя для рисунка в папке с рисунками
                newName = GetCorrectFileName(proj.pPicNameDef, fromFile.Substring(fromFile.LastIndexOf(".")), proj.iPath)
                Dim fl As New IO.FileInfo(fromFile)
                If fl.Length / 1024 / 1024 > 10 Then ProgressFormShow(transInfc("Копирование"), 10)
                IO.File.Copy(fromFile, newName)
                ProgressForm.Hide()
            End If
            Return newName
        End If
    End Function

    ' ПОЛУЧИТЬ УНИКАЛЬНОЕ ИМЯ ДЛЯ ФАЙЛА В ПАПКЕ path
    Function GetCorrectFileName(ByVal FileNameWithoutExtended As String, ByVal Extended As String, ByVal Path As String) As String
        Dim newName As String, i As Integer
        If IO.Directory.Exists(Path) = False Then IO.Directory.CreateDirectory(Path)
        Do ' подобрать, изменяя i, уникальное имя файла
            i += 1 : newName = "\" & FileNameWithoutExtended & i & Extended
            If IO.File.Exists(Path & newName) = False Then Return Path & newName
        Loop
    End Function

    ' ПОЛУЧИТЬ МАКСИМАЛЬНО СОКРАЩЕННУЮ СТРОКУ, СОДЕРЖАЩУЮ ПУТЬ К ФАЙЛУ
    Function GetMinPath(ByVal path As String) As String
        path = Trim(path)
        If NikakoiEsli(path) = trans("Никакой") Then Return trans("Никакой")
        ' Если в имене папки есть папка проекта, то её можно убрать
        If path.IndexOf(proj.pPath) <> -1 Then : Return path.Substring(proj.pPath.Length)
        Else : Return path
        End If
    End Function
    ' ПОЛУЧИТЬ ТОЧНЫЙ, ПОЛНЫЙ ПУТЬ К ФАЙЛУ
    Function GetMaxPath(ByVal path As String) As String
        Dim inKovi4 As Boolean
        path = Trim(path)
        If NikakoiEsli(path) = trans("Никакой") Then Return trans("Никакой")
        ' Если путь папки в кавычках то вытащить его из кавычек
        If path.Length > 2 Then
            If path(0) = """" And path(path.Length - 1) = """" Then
                inKovi4 = True : path = path.Substring(1, path.Length - 2)
            End If
        End If
        If path <> "" Then
            ' Если нехватало папки проекта
            If IO.File.Exists(proj.pPath & path) Then : Return (proj.pPath & path).Replace("\\", "\")
            ElseIf IO.Directory.Exists(proj.pPath & path) Then : Return (proj.pPath & path).Replace("\\", "\")
            End If
        End If
        If path.Length >= 2 Then
            ' Если путь без указания диска, значит файла в папке с проэктом нет, но путь точно начинается от туда
            If path.Substring(1, 1) <> ":" Then
                ' If path.Chars(0) = "/" Or path.Chars(0) = "\" Then
                Return proj.pPath & path
                'Else
                'Return proj.pPath & "\" & path
                'End If
            End If
        End If
        If inKovi4 Then path = """" & path & """"
        Return path
    End Function
    ' ПОЛУЧИТЬ ТОЧНЫЙ, ПОЛНЫЙ ПУТЬ К ФАЙЛУ
    Function GetPathBezSlash(ByVal path As String) As String
        Dim inKovi4 As Boolean
        path = Trim(path)
        If NikakoiEsli(path) = trans("Никакой") Then Return trans("Никакой")
        If path.Length < 2 Then Return path
        If (path.Chars(path.Length - 1) = "\" Or path.Chars(path.Length - 1) = "/") And path.Chars(path.Length - 2) <> ":" Then
            path = path.Substring(0, path.Length - 1)
        End If
        Return path
    End Function



#End Region

    '<<<<<<<< МОИ СТРУКТУРЫ >>>>>>>>>
#Region "STRUCTURES"

    ' СТРУКТУРА ШАБЛОНА, КОТОРЫЙ ПЕРЕДАЕТСЯ В МАСТЕР И СОДЕРЖИТ ВСЮ НУЖНУЮ ЕМУ ИНФОРМАЦИЮ
    Public Structure MasterPattern
        Dim withUslovie As Boolean
        Dim Show As String
        ' При true выводятся все свойства, включая "только для чтения" и полезные свойства
        Dim IncludeReadOnly As Boolean
        Dim ownTextBox As Object
        Dim Text As String
        Dim Bloki As MySplitStruct
        Public estBls As Boolean
        Sub New(ByVal ownTextBox As Object, Optional ByVal show As String = "Propertys", Optional ByVal IncludeReadOnly As Boolean = True, Optional ByVal withUslovie As Boolean = False)
            Me.ownTextBox = ownTextBox
            If ownTextBox Is Nothing = False Then Me.Text = ownTextBox.text 'New CodeString(ownTextBox.text).Text
            Me.Show = show
            Me.IncludeReadOnly = IncludeReadOnly
            Me.withUslovie = withUslovie
        End Sub
        Public Sub SetBloki(ByVal bloki As MySplitStruct)
            Me.Bloki = bloki
            estBls = True
        End Sub
    End Structure

    ' Расширенная строка - строка с возможностью возврата ошибки
    Public Structure ErrString
        Public str, err As String ', ind As Integer
        Sub New(ByVal str As String)
            Me.str = str
        End Sub
        Sub New(ByVal str As String, ByVal err As String)
            Me.str = str : Me.err = err
        End Sub
    End Structure

    Public Class SolvingTree
        Public top, chld() As SolvingTree
        Public oldvalue As String
        Public txt As String
        Public index As Integer
        Sub New(ByVal txt As String, ByVal index As Integer, ByVal chld() As SolvingTree)
            Me.txt = txt : Me.oldvalue = txt : Me.index = index : Me.chld = chld
        End Sub
    End Class

    ' МОЙ АНАЛОГ СТРУКТУРЫ location
    Public Structure locat
        Dim left, top As Integer
        Public Property x()
            Get
                Return left
            End Get
            Set(ByVal value)
                left = value
            End Set
        End Property
        Public Property y()
            Get
                Return top
            End Get
            Set(ByVal value)
                top = value
            End Set
        End Property
    End Structure

    ' ВСЕ ПАРАМЕТРЫ ПРОЕКТА
    Class ProjParam
        Dim IconForm As Image
        Dim pname, ppath, ipath As String
        Sub load(ByVal str As String)

        End Sub
    End Class

    Public Class reName
        Public objName, old_objName, frmName, old_frmName As String
        Sub New(ByVal objName As String, ByVal frmName As String, ByVal old_objName As String, ByVal old_frmName As String)
            Me.objName = objName : Me.frmName = frmName : Me.old_objName = old_objName : Me.old_frmName = old_frmName
        End Sub
        Function GetNewFormName(ByVal frm As String)
            If frm.ToUpper = old_frmName.ToUpper Then Return frmName Else Return frm
        End Function
        Function GetNewObjName(ByVal obj As String)
            If obj.ToUpper = old_objName.ToUpper Then Return objName Else Return obj
        End Function
    End Class

    Class ObjsTreesText
        Public Objs() As Object, Origs() As String
        Public Starts(), Lengs(), popravka As Integer
        Sub New(ByVal MyObs() As Object)
            Objs = MyObs
            ReDim Starts(Objs.Length - 1) : ReDim Lengs(Objs.Length - 1) : ReDim Origs(Objs.Length - 1)
        End Sub
    End Class
#End Region

    '<<<<<<<< ФУНКЦИИ МАССИВОВ >>>>>>>>>
#Region "REDIMS"
    Sub ReDimsO(ByRef mass() As Object, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As Object, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDimsO(ByRef mass As Object, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As DataGridViewRow, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Function ReDimsFun(ByVal mass() As Object, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0) As Object()
        Dim NewMass(0) As Object
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
            NewMass = mass
        Else
            Dim i As Integer
            ReDim Preserve NewMass(mass.Length + ifEstPlus)
            For i = 0 To NewMass.Length - 1
                If mass.Length > i Then NewMass(i) = mass(i)
            Next
        End If
        Return NewMass
    End Function
    Sub ReDims(ByRef mass() As String, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As Integer, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As Double, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As Point, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As TreeNode, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As Forms, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As TabPage, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As SolvingTree, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub ReDims(ByRef mass() As DataGridViewCell, Optional ByVal ifNoth As Integer = 0, Optional ByVal ifEstPlus As Integer = 0)
        If mass Is Nothing Then
            ReDim Preserve mass(ifNoth)
        Else
            ReDim Preserve mass(mass.Length + ifEstPlus)
        End If
    End Sub
    Sub DelDims(ByRef mass() As String, ByVal ind As Integer)
        If mass Is Nothing Then Exit Sub
        If ind >= 0 And ind <= mass.Length - 1 Then
            If mass.Length <= 1 Then mass = Nothing : Exit Sub
            Dim i As Integer
            For i = ind To mass.Length - 2
                mass(i) = mass(i + 1)
            Next
            ReDims(mass, , -2)
        End If
    End Sub
    Sub DelDims(ByRef mass() As SolvingTree, ByVal ind As Integer)
        If mass Is Nothing Then Exit Sub
        If ind >= 0 And ind <= mass.Length - 1 Then
            If mass.Length <= 1 Then mass = Nothing : Exit Sub
            Dim i As Integer
            For i = ind To mass.Length - 2
                mass(i) = mass(i + 1)
            Next
            ReDims(mass, , -2)
        End If
    End Sub
    Sub DelDims(ByRef mass() As Object, ByVal ind As Integer)
        If mass Is Nothing Then Exit Sub
        If ind >= 0 And ind <= mass.Length - 1 Then
            If mass.Length <= 1 Then mass = Nothing : Exit Sub
            Dim i As Integer
            For i = ind To mass.Length - 2
                mass(i) = mass(i + 1)
            Next
            mass = ReDimsFun(mass, , -2)
        End If
    End Sub
    Function DelDimsFun(ByVal mass() As Object, ByVal ind As Integer) As Object()
        If mass Is Nothing Then Return Nothing
        If ind >= 0 And ind <= mass.Length - 1 Then
            If mass.Length <= 1 Then mass = Nothing : Return Nothing
            Dim i As Integer
            For i = ind To mass.Length - 2
                mass(i) = mass(i + 1)
            Next
            mass = ReDimsFun(mass, , -2)
        End If
        Return mass
    End Function
    Sub DelDims(ByRef mass() As Forms, ByVal ind As Integer)
        If mass Is Nothing Then Exit Sub
        If ind >= 0 And ind <= mass.Length - 1 Then
            If mass.Length <= 1 Then mass = Nothing : Exit Sub
            Dim i As Integer
            For i = ind To mass.Length - 2
                mass(i) = mass(i + 1)
            Next
            ReDims(mass, , -2)
        End If
    End Sub
    Sub DelDims(ByRef mass() As TreeNode, ByVal ind As Integer)
        If mass Is Nothing Then Exit Sub
        If ind >= 0 And ind <= mass.Length - 1 Then
            If mass.Length <= 1 Then mass = Nothing : Exit Sub
            Dim i As Integer
            For i = ind To mass.Length - 2
                mass(i) = mass(i + 1)
            Next
            ReDims(mass, , -2)
        End If
    End Sub

#End Region

    '<<<<<<<< ФУНКЦИИ HOOKS >>>>>>>>>
#Region "HOOKS"

    Enum MouseEvent
        LeftButtonDown = &H201
        LeftButtonUp = &H202
        Move = &H200
        MouseWheel = &H20A
        RightButtonDown = &H204
        RightButtonUp = &H205
    End Enum

    Public Enum KeyboardEvents
        KeyDown = &H100
        KeyUp = &H101
        SystemKeyDown = &H104
        SystemKeyUp = &H105
    End Enum

    Public WithEvents mouseHook As Object = "mouse" 'New Kennedy.ManagedHooks.MouseHook
    Public WithEvents keyboardHook As Object = "key"
    Public ks As New ArrayList() ' хранятся нажатые клавиши клавиатуры
    Public ms As New ArrayList() ' хранятся нажатые клавиши мыши
    Public shft, ctrl, alt, mleft, mright, mwheel, msX, msY As Boolean
    Public Sub HookRun(ByVal hook As Object)
        If RunProj Is Nothing Then Exit Sub
        If RunProj.isRUN = False Then Exit Sub

        If hook Is "mouse" Then
            Dim h As New Kennedy.ManagedHooks.MouseHook
            AddHandler h.MouseEvent, AddressOf mouseHook_MouseEvent
            mouseHook = h : hook = mouseHook
        ElseIf hook Is "key" Then
            Dim h As New Kennedy.ManagedHooks.KeyboardHookExt
            AddHandler h.KeyboardEvent, AddressOf keyboardHook_KeyboardEvent
            AddHandler h.SystemKeyDown, AddressOf keyboardHook_SystemKeyDown
            AddHandler h.SystemKeyUp, AddressOf keyboardHook_SystemKeyUp
            keyboardHook = h : hook = keyboardHook
            'Else
            'Exit Sub
            'If hook.IsHooked = False Then : mouseHook = "mouse"
            ' If hook.IsHooked = False Then hook.InstallHook()
        End If


        If hook.IsHooked = False Then hook.InstallHook()
    End Sub
    Public Sub HookStops()
        If keyboardHook Is "key" = False Then If keyboardHook.IsHooked Then keyboardHook.UninstallHook()
        If mouseHook Is "mouse" = False Then If mouseHook.IsHooked Then mouseHook.UninstallHook()
    End Sub
    Private Sub mouseHook_MouseEvent(ByVal mEvent As Kennedy.ManagedHooks.MouseEvents, ByVal point As Point) 'Handles mouseHook.MouseEvent
        If mEvent = Kennedy.ManagedHooks.MouseEvents.MouseWheel Then mwheel = True Else mwheel = False

        If mEvent = Kennedy.ManagedHooks.MouseEvents.Move Then Exit Sub

        If mEvent = Kennedy.ManagedHooks.MouseEvents.LeftButtonDown Then
            mleft = True
        ElseIf mEvent = Kennedy.ManagedHooks.MouseEvents.LeftButtonUp Then
            mleft = False
        ElseIf mEvent = Kennedy.ManagedHooks.MouseEvents.RightButtonDown Then
            mright = True
        ElseIf mEvent = Kennedy.ManagedHooks.MouseEvents.RightButtonUp Then
            mright = False
        End If
    End Sub
    Private Sub keyboardHook_KeyboardEvent(ByVal kEvent As Integer, ByVal key As Keys) ' Handles keyboardHook.KeyboardEvent
        If kEvent = KeyboardEvents.KeyDown Then
            If key = Keys.Shift Then shft = True : Exit Sub
            If key = Keys.Alt Then alt = True : Exit Sub
            If key = Keys.Control Then ctrl = True : Exit Sub

            If ks.Contains(key.ToString) = False Then ks.Add(key.ToString)
        ElseIf kEvent = KeyboardEvents.KeyUp Then
            If key = Keys.Shift Then shft = False : Exit Sub
            If key = Keys.Alt Then alt = False : Exit Sub
            If key = Keys.Control Then ctrl = False : Exit Sub

            If ks.Contains(key.ToString) Then ks.Remove(key.ToString)
        End If
    End Sub
    Private Sub keyboardHook_SystemKeyDown(ByVal key As System.Windows.Forms.Keys) ' Handles keyboardHook.SystemKeyDown
        keyboardHook_KeyboardEvent(KeyboardEvents.KeyDown, key)
    End Sub
    Private Sub keyboardHook_SystemKeyUp(ByVal key As System.Windows.Forms.Keys) 'Handles keyboardHook.SystemKeyUp
        keyboardHook_KeyboardEvent(KeyboardEvents.KeyUp, key)
    End Sub
#End Region

    '<<<<<<<< ФУНКЦИИ WINAPI >>>>>>>>>
#Region " P/Invoke "

    <DllImport("user32.dll")> _
    Public Function GetForegroundWindow() As IntPtr
    End Function
    <DllImport("user32.dll")> _
    Public Function SetForegroundWindow(ByVal hWnd As IntPtr) As IntPtr
    End Function


    <DllImport("KERNEL32.DLL", EntryPoint:="BeginUpdateResourceW", SetLastError:=True, CharSet:=CharSet.Unicode, _
     ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Function BeginUpdateResource(ByVal pFileName As String, ByVal bDeleteExistingResources As Boolean) As IntPtr
    End Function

    <DllImport("KERNEL32.DLL", EntryPoint:="UpdateResourceW", SetLastError:=True, CharSet:=CharSet.Unicode, _
     ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Function UpdateResource(ByVal hUpdate As IntPtr, ByVal pType As UInt32, ByVal pName As UInt32, ByVal wLanguage As UInt16, ByVal pData() As Byte, ByVal cbData As UInt32) As Boolean
    End Function

    <DllImport("KERNEL32.DLL", EntryPoint:="EndUpdateResourceW", SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Function EndUpdateResource(ByVal hUpdate As IntPtr, ByVal bDiscard As Boolean) As Boolean
    End Function

    ' MEDIA
    Public Declare Function mciSendString Lib "Winmm.dll" Alias "mciSendStringA" (ByVal lpszCommand As String, ByVal lpszReturnString As String, ByVal cchReturn As Integer, ByVal hwndCallback As IntPtr) As Integer
    Public Const MCI_NOTIFY_SUCCESSFUL As Integer = &H1
    Public Const MM_MCINOTIFY As Integer = 129
    Public Const MCIERR_BASE As Integer = 256

    ' EKRAN
    ' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/gdi/devcons_84oj.asp
    <DllImport("user32.dll", CharSet:=CharSet.Ansi)> _
    Public Function EnumDisplaySettings(ByVal lpszDeviceName As String, ByVal iModeNum As Integer, ByRef lpDevMode As DevMode) As Integer
    End Function
    ' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/gdi/devcons_7gz7.asp
    <DllImport("user32.dll", CharSet:=CharSet.Ansi)> _
    Public Function ChangeDisplaySettings(ByRef lpDevMode As DevMode, ByVal dwFlags As Integer) As ReturnCodes
    End Function
    Public Const ENUM_CURRENT_SETTINGS As Integer = -1

    <DllImport("user32", SetLastError:=True)> _
    Public Function SystemParametersInfo( _
        ByVal uiAction As UInteger, _
        ByVal uiParam As Integer, _
        ByVal pvParam As StringBuilder, _
        ByVal fWinIni As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Structure SYSTEMTIME
        Dim wYear As Short
        Dim wMonth As Short
        Dim wDayOfWeek As Short
        Dim wDay As Short
        Dim wHour As Short
        Dim wMinute As Short
        Dim wSecond As Short
        Dim wMilliseconds As Short
    End Structure
    Public Declare Function SetSystemTime Lib "kernel32" (ByRef lpSystemTime As SYSTEMTIME) As Long

#Region " SystemParameters "

    ' Encapsulate the magic numbers for the return value in an enumeration
    Public Enum ReturnCodes As Integer
        DISP_CHANGE_SUCCESSFUL = 0
        DISP_CHANGE_BADDUALVIEW = -6
        DISP_CHANGE_BADFLAGS = -4
        DISP_CHANGE_BADMODE = -2
        DISP_CHANGE_BADPARAM = -5
        DISP_CHANGE_FAILED = -1
        DISP_CHANGE_NOTUPDATED = -3
        DISP_CHANGE_RESTART = 1
    End Enum
    ' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/gdi/prntspol_8nle.asp
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure DevMode
        ' The MarshallAs attribute is covered in the Background section of the article
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> _
        Public dmDeviceName As String
        Public dmSpecVersion As Short
        Public dmDriverVersion As Short
        Public dmSize As Short
        Public dmDriverExtra As Short
        Public dmFields As Integer
        Public dmPositionX As Integer
        Public dmPositionY As Integer
        Public dmDisplayOrientation As Integer
        Public dmDisplayFixedOutput As Integer
        Public dmColor As Short
        Public dmDuplex As Short
        Public dmYResolution As Short
        Public dmTTOption As Short
        Public dmCollate As Short
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> _
        Public dmFormName As String
        Public dmLogPixels As Short
        Public dmBitsPerPel As Short
        Public dmPelsWidth As Integer
        Public dmPelsHeight As Integer
        Public dmDisplayFlags As Integer
        Public dmDisplayFrequency As Integer
        Public dmICMMethod As Integer
        Public dmICMIntent As Integer
        Public dmMediaType As Integer
        Public dmDitherType As Integer
        Public dmReserved1 As Integer
        Public dmReserved2 As Integer
        Public dmPanningWidth As Integer
        Public dmPanningHeight As Integer
        Public Overrides Function ToString() As String
            Return dmPelsWidth.ToString() + " x " + dmPelsHeight.ToString()
        End Function
        Public Function GetInfoArray() As String()
            Dim items() As String = New String(5) {}
            items(0) = dmDeviceName
            items(1) = dmPelsWidth.ToString()
            items(2) = dmPelsHeight.ToString()
            items(3) = dmDisplayFrequency.ToString()
            items(4) = dmBitsPerPel.ToString()
            Return items
        End Function
    End Structure


    Public Enum SystemParameters As UInteger
        NoParameter = 0
        SPIF_UPDATEINIFILE = &H1&
        SPIF_SENDWININICHANGE = &H2&
        SPI_GETBEEP = &H1
        SPI_SETBEEP = &H2
        SPI_GETMOUSE = &H3
        SPI_SETMOUSE = &H4
        SPI_GETBORDER = &H5
        SPI_SETBORDER = &H6
        SPI_GETKEYBOARDSPEED = &HA
        SPI_SETKEYBOARDSPEED = &HB
        SPI_LANGDRIVER = &HC
        SPI_ICONHORIZONTALSPACING = &HD
        SPI_GETSCREENSAVETIMEOUT = &HE
        SPI_SETSCREENSAVETIMEOUT = &HF
        SPI_GETSCREENSAVEACTIVE = &H10
        SPI_SETSCREENSAVEACTIVE = &H11
        SPI_GETGRIDGRANULARITY = &H12
        SPI_SETGRIDGRANULARITY = &H13
        SPI_SETDESKWALLPAPER = &H14
        SPI_SETDESKPATTERN = &H15
        SPI_GETKEYBOARDDELAY = &H16
        SPI_SETKEYBOARDDELAY = &H17
        SPI_ICONVERTICALSPACING = &H18
        SPI_GETICONTITLEWRAP = &H19
        SPI_SETICONTITLEWRAP = &H1A
        SPI_GETMENUDROPALIGNMENT = &H1B
        SPI_SETMENUDROPALIGNMENT = &H1C
        SPI_SETDOUBLECLKWIDTH = &H1D
        SPI_SETDOUBLECLKHEIGHT = &H1E
        SPI_GETICONTITLELOGFONT = &H1F
        SPI_SETDOUBLECLICKTIME = &H20
        SPI_SETMOUSEBUTTONSWAP = &H21
        SPI_SETICONTITLELOGFONT = &H22
        SPI_GETFASTTASKSWITCH = &H23
        SPI_SETFASTTASKSWITCH = &H24
        SPI_SETDRAGFULLWINDOWS = &H25
        SPI_GETDRAGFULLWINDOWS = &H26
        SPI_GETNONCLIENTMETRICS = &H29
        SPI_SETNONCLIENTMETRICS = &H2A
        SPI_GETMINIMIZEDMETRICS = &H2B
        SPI_SETMINIMIZEDMETRICS = &H2C
        SPI_GETICONMETRICS = &H2D
        SPI_SETICONMETRICS = &H2E
        SPI_SETWORKAREA = &H2F
        SPI_GETWORKAREA = &H30
        SPI_SETPENWINDOWS = &H31
        SPI_GETHIGHCONTRAST = &H42
        SPI_SETHIGHCONTRAST = &H43
        SPI_GETKEYBOARDPREF = &H44
        SPI_SETKEYBOARDPREF = &H45
        SPI_GETSCREENREADER = &H46
        SPI_SETSCREENREADER = &H47
        SPI_GETANIMATION = &H48
        SPI_SETANIMATION = &H49
        SPI_GETFONTSMOOTHING = &H4A
        SPI_SETFONTSMOOTHING = &H4B
        SPI_SETDRAGWIDTH = &H4C
        SPI_SETDRAGHEIGHT = &H4D
        SPI_SETHANDHELD = &H4E
        SPI_GETLOWPOWERTIMEOUT = &H4F
        SPI_GETPOWEROFFTIMEOUT = &H50
        SPI_SETLOWPOWERTIMEOUT = &H51
        SPI_SETPOWEROFFTIMEOUT = &H52
        SPI_GETLOWPOWERACTIVE = &H53
        SPI_GETPOWEROFFACTIVE = &H54
        SPI_SETLOWPOWERACTIVE = &H55
        SPI_SETPOWEROFFACTIVE = &H56
        SPI_SETCURSORS = &H57
        SPI_SETICONS = &H58
        SPI_GETDEFAULTINPUTLANG = &H59
        SPI_SETDEFAULTINPUTLANG = &H5A
        SPI_SETLANGTOGGLE = &H5B
        SPI_GETWINDOWSEXTENSION = &H5C
        SPI_SETMOUSETRAILS = &H5D
        SPI_GETMOUSETRAILS = &H5E
        SPI_SETSCREENSAVERRUNNING = &H61
        SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING
        SPI_GETFILTERKEYS = &H32
        SPI_SETFILTERKEYS = &H33
        SPI_GETTOGGLEKEYS = &H34
        SPI_SETTOGGLEKEYS = &H35
        SPI_GETMOUSEKEYS = &H36
        SPI_SETMOUSEKEYS = &H37
        SPI_GETSHOWSOUNDS = &H38
        SPI_SETSHOWSOUNDS = &H39
        SPI_GETSTICKYKEYS = &H3A
        SPI_SETSTICKYKEYS = &H3B
        SPI_GETACCESSTIMEOUT = &H3C
        SPI_SETACCESSTIMEOUT = &H3D
        SPI_GETSERIALKEYS = &H3E
        SPI_SETSERIALKEYS = &H3F
        SPI_GETSOUNDSENTRY = &H40
        SPI_SETSOUNDSENTRY = &H41
        SPI_GETSNAPTODEFBUTTON = &H5F
        SPI_SETSNAPTODEFBUTTON = &H60
        SPI_GETMOUSEHOVERWIDTH = &H62
        SPI_SETMOUSEHOVERWIDTH = &H63
        SPI_GETMOUSEHOVERHEIGHT = &H64
        SPI_SETMOUSEHOVERHEIGHT = &H65
        SPI_GETMOUSEHOVERTIME = &H66
        SPI_SETMOUSEHOVERTIME = &H67
        SPI_GETWHEELSCROLLLINES = &H68
        SPI_SETWHEELSCROLLLINES = &H69
        SPI_GETMENUSHOWDELAY = &H6A
        SPI_SETMENUSHOWDELAY = &H6B
        SPI_GETSHOWIMEUI = &H6E
        SPI_SETSHOWIMEUI = &H6F
        SPI_GETMOUSESPEED = &H70
        SPI_SETMOUSESPEED = &H71
        SPI_GETSCREENSAVERRUNNING = &H72
        SPI_GETDESKWALLPAPER = &H73
        SPI_GETACTIVEWINDOWTRACKING = &H1000
        SPI_SETACTIVEWINDOWTRACKING = &H1001
        SPI_GETMENUANIMATION = &H1002
        SPI_SETMENUANIMATION = &H1003
        SPI_GETCOMBOBOXANIMATION = &H1004
        SPI_SETCOMBOBOXANIMATION = &H1005
        SPI_GETLISTBOXSMOOTHSCROLLING = &H1006
        SPI_SETLISTBOXSMOOTHSCROLLING = &H1007
        SPI_GETGRADIENTCAPTIONS = &H1008
        SPI_SETGRADIENTCAPTIONS = &H1009
        SPI_GETKEYBOARDCUES = &H100A
        SPI_SETKEYBOARDCUES = &H100B
        SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES
        SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES
        SPI_GETACTIVEWNDTRKZORDER = &H100C
        SPI_SETACTIVEWNDTRKZORDER = &H100D
        SPI_GETHOTTRACKING = &H100E
        SPI_SETHOTTRACKING = &H100F
        SPI_GETMENUFADE = &H1012
        SPI_SETMENUFADE = &H1013
        SPI_GETSELECTIONFADE = &H1014
        SPI_SETSELECTIONFADE = &H1015
        SPI_GETTOOLTIPANIMATION = &H1016
        SPI_SETTOOLTIPANIMATION = &H1017
        SPI_GETTOOLTIPFADE = &H1018
        SPI_SETTOOLTIPFADE = &H1019
        SPI_GETCURSORSHADOW = &H101A
        SPI_SETCURSORSHADOW = &H101B
        SPI_GETMOUSESONAR = &H101C
        SPI_SETMOUSESONAR = &H101D
        SPI_GETMOUSECLICKLOCK = &H101E
        SPI_SETMOUSECLICKLOCK = &H101F
        SPI_GETMOUSEVANISH = &H1020
        SPI_SETMOUSEVANISH = &H1021
        SPI_GETFLATMENU = &H1022
        SPI_SETFLATMENU = &H1023
        SPI_GETDROPSHADOW = &H1024
        SPI_SETDROPSHADOW = &H1025
        SPI_GETBLOCKSENDINPUTRESETS = &H1026
        SPI_SETBLOCKSENDINPUTRESETS = &H1027
        SPI_GETUIEFFECTS = &H103E
        SPI_SETUIEFFECTS = &H103F
        SPI_GETFOREGROUNDLOCKTIMEOUT = &H2000
        SPI_SETFOREGROUNDLOCKTIMEOUT = &H2001
        SPI_GETACTIVEWNDTRKTIMEOUT = &H2002
        SPI_SETACTIVEWNDTRKTIMEOUT = &H2003
        SPI_GETFOREGROUNDFLASHCOUNT = &H2004
        SPI_SETFOREGROUNDFLASHCOUNT = &H2005
        SPI_GETCARETWIDTH = &H2006
        SPI_SETCARETWIDTH = &H2007
        SPI_GETMOUSECLICKLOCKTIME = &H2008
        SPI_SETMOUSECLICKLOCKTIME = &H2009
        SPI_GETFONTSMOOTHINGTYPE = &H200A
        SPI_SETFONTSMOOTHINGTYPE = &H200B
        SPI_GETFONTSMOOTHINGCONTRAST = &H200C
        SPI_SETFONTSMOOTHINGCONTRAST = &H200D
        SPI_GETFOCUSBORDERWIDTH = &H200E
        SPI_SETFOCUSBORDERWIDTH = &H200F
        SPI_GETFOCUSBORDERHEIGHT = &H2010
        SPI_SETFOCUSBORDERHEIGHT = &H2011
        SPI_GETFONTSMOOTHINGORIENTATION = &H2012
        SPI_SETFONTSMOOTHINGORIENTATION = &H2013
    End Enum
#End Region

#End Region

    '<<<<<<<< ФУНКЦИИ НАЖАТИЯ КЛАВИШ >>>>>>>>>
#Region "INPUTS"

    '   Public Sub DoMouse(ByVal flags As NativeMethods.MOUSEEVENTF, ByVal newPoint As Point, Optional ByVal wheelCount As Integer = 0)
    Public Sub DoMouse(ByVal flags As Object, ByVal newPoint As Point, Optional ByVal wheelCount As Integer = 0)
        Dim input As New NativeMethods.INPUT
        Dim mi As New NativeMethods.MOUSEINPUT
        input.dwType = NativeMethods.InputType.Mouse
        input.mi = mi
        input.mi.dwExtraInfo = IntPtr.Zero
        ' mouse co-ords: top left is (0,0), bottom right is (65535, 65535)
        ' convert screen co-ord to mouse co-ords...
        input.mi.dx = newPoint.X * (65535 / Screen.PrimaryScreen.Bounds.Width)
        input.mi.dy = newPoint.Y * (65535 / Screen.PrimaryScreen.Bounds.Height)
        input.mi.time = 0
        input.mi.mouseData = wheelCount  ' can be used for WHEEL event see msdn
        input.mi.dwFlags = flags
        Dim cbSize As Integer = Marshal.SizeOf(GetType(NativeMethods.INPUT))
        Dim result As Integer = NativeMethods.SendInput(1, input, cbSize)
        If result = 0 Then MsgBox(Marshal.GetLastWin32Error)
    End Sub

    'Public Sub DoKeyBoard(ByVal flags As NativeMethods.KEYEVENTF, ByVal key As Keys)
    Public Sub DoKeyBoard(ByVal flags As Object, ByVal key As Keys)
        Dim input As New NativeMethods.INPUT
        Dim ki As New NativeMethods.KEYBDINPUT
        input.dwType = NativeMethods.InputType.Keyboard
        input.ki = ki
        input.ki.wVk = Convert.ToInt16(key)
        input.ki.wScan = 0
        input.ki.time = 0
        input.ki.dwFlags = flags
        input.ki.dwExtraInfo = IntPtr.Zero
        Dim cbSize As Integer = Marshal.SizeOf(GetType(NativeMethods.INPUT))
        Dim result As Integer = NativeMethods.SendInput(1, input, cbSize)
        If result = 0 Then MsgBox(Marshal.GetLastWin32Error)
    End Sub
    Public Class NativeMethods

        <DllImport("user32.dll", SetLastError:=True)> _
        Friend Shared Function SendInput(ByVal cInputs As Int32, ByRef pInputs As INPUT, ByVal cbSize As Int32) As Int32
        End Function

        <StructLayout(LayoutKind.Explicit, pack:=1, Size:=28)> _
        Friend Structure INPUT
            <FieldOffset(0)> Public dwType As InputType
            <FieldOffset(4)> Public mi As MOUSEINPUT
            <FieldOffset(4)> Public ki As KEYBDINPUT
            <FieldOffset(4)> Public hi As HARDWAREINPUT
        End Structure

        <StructLayout(LayoutKind.Sequential, pack:=1)> _
        Friend Structure MOUSEINPUT
            Public dx As Int32
            Public dy As Int32
            Public mouseData As Int32
            Public dwFlags As MOUSEEVENTF
            Public time As Int32
            Public dwExtraInfo As IntPtr
        End Structure

        <StructLayout(LayoutKind.Sequential, pack:=1)> _
        Friend Structure KEYBDINPUT
            Public wVk As Int16
            Public wScan As Int16
            Public dwFlags As KEYEVENTF
            Public time As Int32
            Public dwExtraInfo As IntPtr
        End Structure

        <StructLayout(LayoutKind.Sequential, pack:=1)> _
        Friend Structure HARDWAREINPUT
            Public uMsg As Int32
            Public wParamL As Int16
            Public wParamH As Int16
        End Structure

        Friend Enum InputType As Integer
            Mouse = 0
            Keyboard = 1
            Hardware = 2
        End Enum

        <Flags()> _
        Friend Enum MOUSEEVENTF As Integer
            MOVE = &H1
            LEFTDOWN = &H2
            LEFTUP = &H4
            RIGHTDOWN = &H8
            RIGHTUP = &H10
            MIDDLEDOWN = &H20
            MIDDLEUP = &H40
            XDOWN = &H80
            XUP = &H100
            VIRTUALDESK = &H400
            WHEEL = &H800
            ABSOLUTE = &H8000
        End Enum

        <Flags()> _
        Friend Enum KEYEVENTF As Integer
            KEYDOWN = 0
            EXTENDEDKEY = 1
            KEYUP = 2
            [UNICODE] = 4
            SCANCODE = 8
        End Enum
    End Class

#End Region

    '<<<<<<<< ДЕЛЕГАТЫ ДЛЯ ПОТОКА RUNPROJ >>>>>>>>>
#Region "DELEGATES"

    ' Остановка проекта
    Delegate Sub RunProj_NodeStop_delegate(ByVal node As TreeNode, ByVal param As PropertysSobyt)
    Delegate Sub Enableds_delegate(ByVal rn As Boolean, ByVal ps As Boolean, ByVal so As Boolean, ByVal sin As Boolean, ByVal sout As Boolean)
    Public delegatNodeStop As RunProj_NodeStop_delegate
    Public delegatEnableds As Enableds_delegate

    ' Прогресс форма
    Delegate Sub ProgressSub(ByVal value As Object)
    Public delegatProgress As New ProgressSub(AddressOf ProgressN)
    Public delegatProgressShow As New ProgressSub(AddressOf ProgressShow)
    Public delegatProgressHide As New ProgressSub(AddressOf ProgressHide)
    Public Sub ProgressN(ByVal value As Object)
        ProgressForm.ProgressBarValue = value
    End Sub
    Public Sub ProgressShow(ByVal value As Object)
        ProgressFormShow(value)
    End Sub
    Public Sub ProgressHide(ByVal value As Object)
        ProgressForm.Hide()
    End Sub

    ' Прочие
    Delegate Sub SetNodeText_delegate(ByVal nod As TreeNode, ByVal txt As String)
    Public delegatSetNodeText As New SetNodeText_delegate(AddressOf SetTextNode)

#End Region

    ' <<<<<<<< ФУНКЦИИ ИЗ PROJECTS КОТОРЫЕ НУЖНЫ RUNPROJECTS >>>>>>>>>
#Region "PROJECTS"
    ' Получить список со всеми свойствами и описаниями к ним из XML-файлов
    Public Function Get2ListInfoProps() As SortedList
        Dim xp, nod As Xml.XPath.XPathNavigator, i As Integer, ret As New SortedList
        ' формирование списка xml-файлов свойств команд событий
        If IO.Directory.Exists(XMLpath) = False Then Return ret
        Dim fls() As String = IO.Directory.GetFiles(XMLpath & "/PropertiesCommands")
        Dim fls2() As String = IO.Directory.GetFiles(XMLpath & "/Events")
        ReDim Preserve fls(fls.Length - 1 + fls2.Length)
        fls2.CopyTo(fls, fls.Length - fls2.Length)
        For i = 0 To fls.Length - 1
            xp = (New Xml.XPath.XPathDocument(fls(i))).CreateNavigator
            xp = xp.SelectSingleNode("//xml/file/descriptionarticle//text")
            If xp Is Nothing Then Continue For
            ' очистка от лишних пробелов
            Dim str As String = Trim(xp.Value.Replace(vbCrLf, ""))
            While str.IndexOf("  ") <> -1 : str = str.Replace("  ", " ") : End While

            ret.Add(LCase(trans(IO.Path.GetFileNameWithoutExtension(fls(i)), , True)), str)
        Next
        ' формирование списка xml-файлов агрументов
        xp = (New Xml.XPath.XPathDocument(XMLpath & "/Arguments.xml")).CreateNavigator
        i = 1
        Do
            nod = xp.SelectSingleNode("//arguments/argument[position()=" & i & "]")
            If nod Is Nothing Then Exit Do
            ' очистка от лишних пробелов
            Dim str As String = Trim(nod.Value.Replace(vbCrLf, ""))
            While str.IndexOf("  ") <> -1 : str = str.Replace("  ", " ") : End While

            Dim key As String = LCase(trans(nod.SelectSingleNode("@name").Value, , True))
            If ret.IndexOfKey(key) = -1 Then ret.Add(key, str)
            i += 1
        Loop
        Return ret
    End Function
    ' Получить список со всеми объектами и описаниями к ним из XML-файлов
    Public Function Get2ListInfoObjs() As SortedList
        Dim xp As Xml.XPath.XPathNavigator, i As Integer, ret As New SortedList
        If IO.Directory.Exists(XMLpath) = False Then Return ret
        ' Просмотр каждого объекта
        For i = 0 To Pustishki.Count - 1
            Dim fl As String = "Objects/" & trans(Pustishki.GetByIndex(i).obj.props.type, True)

            ' Рас есть xml-файл который описывает данный объект, то сгенерировать всю вложенную справку для этого объекта
            If IO.File.Exists(XMLpath & "\" & fl & ".xml") Then
                ' Записать в descr описание объекта из xml файла данного объекта
                xp = (New Xml.XPath.XPathDocument(XMLpath & "\" & fl & ".xml")).CreateNavigator
                ' очистка от лишних пробелов
                Dim str As String = Trim(xp.SelectSingleNode("//xml/file/descriptionarticle//text").Value.Replace(vbCrLf, ""))
                While str.IndexOf("  ") <> -1 : str = str.Replace("  ", " ") : End While
                ' Записья
                ret.Add(trans(Pustishki.GetByIndex(i).obj.props.type, True), Pustishki.GetByIndex(i).obj.props.type & ". " & str)
            End If
        Next
        Return ret
    End Function
    ' ВОЗВРАЩАЕТ КОЛЛЕКЦИЮ, РАЗБИВАЯ str НА ИМЯ ПЕРЕМЕННОЙ И ЗНАЧЕНИЕ
    Delegate Function GetVal(ByVal str As String) As Object
    Function Get2List(ByVal file As String, ByVal razdel As String, Optional ByVal fun As GetVal = Nothing, Optional ByVal withLCase As Boolean = False) As System.Collections.SortedList
        If IO.File.Exists(file) = False Then Return New SortedList
        Return Get2ListFromString(IO.File.OpenText(file).ReadToEnd, razdel, fun, withLCase)
    End Function
    Function Get2ListFromString(ByVal txt As String, ByVal razdel As String, Optional ByVal fun As GetVal = Nothing, Optional ByVal withLCase As Boolean = False) As System.Collections.SortedList
        Dim i, ind As Integer, val As Object
        Dim list As New System.Collections.SortedList
        ' разбитие файла на строки
        Dim sp(0) As String : sp(0) = Environment.NewLine.ToString()
        Dim str() As String = (txt & Environment.NewLine).Split(sp, StringSplitOptions.RemoveEmptyEntries)
        ' просмотр каждой строки
        For i = 0 To str.Length - 1
            ' Если строка комментарий
            If str(i).ToCharArray(0, 1) = "#" Then Continue For
            ' найти номер символа, который отделяет ключ от значения
            ind = str(i).IndexOf(razdel)
            If ind <> -1 Then
                val = str(i).Substring(ind + razdel.Length)
                ' fun обрабатывает значение и возвращает готовое
                If fun <> Nothing Then val = fun(val)
                If withLCase Then
                    list.Add(LCase(str(i).Substring(0, ind)), LCase(val))
                Else
                    list.Add(str(i).Substring(0, ind), val)
                End If
            End If
        Next
        Return list
    End Function
    ' ПОЛУЧЕНИЕ УНИКАЛЬНОГО ИМЕНИ ОБЪЕКТА
    Public Function GetUNameObj(ByVal myObj As Object, Optional ByVal forDP As Object = Nothing) As String
        Dim nam As String = ""
        If myObj.GetMyForm Is Nothing = False Then
            nam = myObj.GetMyForm.obj.Props.name & "."
        End If
        nam &= myObj.obj.Props.name

        ' Если это дубль панель то надо сохранить еще и какая именно панель содержит объект
        If Iz.IsDP(myObj) And forDP Is Nothing = False Then
            If forDP.obj.Parent IsNot Nothing Then nam &= "(" & forDP.obj.Parent.tag & ")"
        End If


        nam &= "[" & myObj.obj.Props.index & "]"
        Return nam
    End Function
    ' ПОЛУЧЕНИЕ ТОЛЬКО ИМЕНИ ОБЪЕКТА ПО УНИКАЛЬНОМУ ИМЕНИ
    Public Function GetObjNameFromUName(ByVal nam As String) As String
        If nam = "" Then Return ""
        If nam.IndexOf("(") = -1 Then
            Return nam.Split(".")(1).Split("[")(0)
        Else
            Return nam.Split(".")(1).Split("(")(0)
        End If
    End Function
    ' ПОЛУЧЕНИЕ ТОЛЬКО ИМЕНИ ОБЪЕКТА ПО УНИКАЛЬНОМУ ИМЕНИ
    Public Function GetIndexFromUName(ByVal nam As String) As String
        If nam = "" Then Return ""
        Return nam.Split("[")(1).Split("]")(0)
    End Function

    ' ФОРМАТИРОВАНИЕ ИМЕНИ ОБЪЕКТА
    Public Function GetCorrectUName(ByVal uName As String) As String
        If uName.IndexOf("(") <> -1 And uName.IndexOf(")") <> -1 Then
            Return uName.Split("(")(0) & uName.Split(")")(1)
        Else
            Return uName
        End If
    End Function
    Function GetSortTPsByPosition(ByVal Objs() As Object) As Object()
        Dim i As Integer, fl As Boolean = True, temp As Object
        If Objs Is Nothing Then Return Objs
        While fl = True
            fl = False
            For i = 0 To Objs.Length - 2
                If Objs(i).obj.GetType.ToString = ClassAplication & "TPs" Then
                    Dim k As Integer = i + 1
                    While k < Objs.Length
                        If Objs(k).obj.GetType.ToString = ClassAplication & "TPs" Then Exit While
                        k += 1
                    End While
                    If k < Objs.Length Then
                        If Objs(i).obj.Props.pos > Objs(k).obj.Props.pos Then 'Or (Objs(i).pos = Objs(i + 1).pos And Objs(i + 1) Is prioritet) Then
                            temp = Objs(i) : Objs(i) = Objs(k) : Objs(k) = temp : fl = True
                        End If
                    End If
                End If

                'If Objs(i).obj.GetType.ToString = ClassAplication & "MMs" Then
                '    Dim k As Integer = i + 1
                '    While k < Objs.Length
                '        If Objs(k).obj.GetType.ToString = ClassAplication & "MMs" Then Exit While
                '        k += 1
                '    End While
                '    If k < Objs.Length Then
                '        If Objs(i).obj.Props.pos > Objs(k).obj.Props.pos Then 'Or (Objs(i).pos = Objs(i + 1).pos And Objs(i + 1) Is prioritet) Then
                '            If Objs(i).conteiner Is Objs(k).conteiner Then
                '                temp = Objs(i) : Objs(i) = Objs(k) : Objs(k) = temp : fl = True
                '            End If
                '        End If
                '    End If
                'End If
            Next
        End While
        Return Objs
    End Function

    Function OutputRun(ByVal type As String, ByVal outps() As String, ByVal param As PropertysSobyt) As String
        Dim i As Integer, str As String = ""
        If param.err.err <> "" Then
            str = trans("Произошла ошибка, при выполнении проекта") & ": " & param.err.str & ". " & param.err.err & vbCrLf
        End If
        If RunProj Is Nothing Then Exit Function

        Dim slovo As String = ""
        For i = 0 To outps.Length - 1

            ' Убирание ключевых слов ("If","While")
            outps(i) = UbratKluchSlova(type, outps(i))

            ' Получение результата выполнения строки 
            Dim rn As ErrString
            If RunProj.isPotok Then
                RunProj.outString = outps(i) : RunProj.outType = type : RunProj.outRunString = True
                If RunProj Is Nothing Then Exit Function
                While RunProj.outRunString
                    Application.DoEvents() : Threading.Thread.Sleep(timeSleep)
                    If isRunAlg2Code Then RunProj.PrervaliPotok()
                End While
                rn = RunProj.outResult
            Else
                rn = RunProj.RunString(outps(i), type, param)
            End If

            ' Вывод результата
            If rn.err <> "" Then
                str &= outps(i) & " = ???" & vbCrLf
                If rn.err = "!" Then rn.err = trans("Непредвиденная ошибка")
                str &= trans("Ошибка в строке") & ": " & rn.str & ". " & vbCrLf & trans("Описание ошибки") & ": " & rn.err & vbCrLf & vbCrLf
            Else
                str &= outps(i) & " = " & rn.str & vbCrLf & vbCrLf
            End If
        Next
        ' If Output.InvokeRequired = False Then Output.Text = str
        Return str
    End Function
#End Region

End Module
