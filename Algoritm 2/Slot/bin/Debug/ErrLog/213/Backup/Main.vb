Public Module MainClass
    Public Sub main()
        ' ЧТЕНИЕ ВЛОЖЕННЫХ ДАННЫХ ИЗ ЕХЕ ФАЙЛА
        Dim fname As String = System.Environment.GetCommandLineArgs()(0)
        Dim code_bytes(), start_bytes(5) As Byte
        Dim code_chars(), start_chars(5) As Char
        Dim code, start As String
        Dim fs As System.IO.FileStream
        Try
            fs = System.IO.File.OpenRead(fname)
        Catch ex As Exception
            Errors.FileNoAccess(ex.Message) : Exit Sub
        End Try
        ' Определение позиции, с которой идет код пользователя
        fs.Position = fs.Length - 6
        fs.Read(start_bytes, 0, start_bytes.Length)
        start_chars = System.Text.Encoding.UTF8.GetChars(start_bytes)
        start = String.Concat(start_chars)
        ' Если передали языки вложенными в файл (УСЛОВИЕ ВЕРНО КОГДА ЭКСПОРТИРОВАЛИ В ГОТОВУЮ ПРОГАММУ А НЕ В VB.NET)
        If IsNumeric(start) Then
            ' Получение вложенных в файл данных
            fs.Position = start
            ReDim code_bytes(fs.Length - fs.Position - 6 - 1)
            fs.Read(code_bytes, 0, code_bytes.Length)
            code_chars = System.Text.Encoding.UTF8.GetChars(code_bytes)
            code = String.Concat(code_chars)
            fs.Close()

            ' ЗАДАНИЕ ЯЗЫКОВ
            ' Сначала извлечь название языка
            Dim langNam As String = code.Substring(0, code.IndexOf("~~~"))
            code = code.Substring(code.IndexOf("~~~") + 3)
            lang_name = langNam : lang_interface = lang_name : lang_name_old = lang_name

            ' Сначала извлечь язык
            Dim langStr As String = code.Substring(0, code.IndexOf("~~~"))
            code = code.Substring(code.IndexOf("~~~") + 3)
            lang = Get2ListFromString(langStr, "~~")
            langLw = Get2ListFromString(langStr, "~~", , True)
            langINFC = lang : langLwINFC = langLw
            langOld = lang : langLwOld = langLw

            ' Извлечь английский
            Dim langEngStr As String = code.Substring(0, code.IndexOf("~~~"))
            code = code.Substring(code.IndexOf("~~~") + 3)
            langENG = Get2ListFromString(langEngStr, "~~")
            langLwENG = Get2ListFromString(langEngStr, "~~", , True)
        Else
            ' ПАПКА РАСПОЛОЖЕНИЯ ФАЙЛОВ ЯЗЫКОВ (*.lng)
            lang_name = "Russian"
            LanguagePath = System.IO.Path.GetDirectoryName(fname) & "\Languages\"
            setLangs(True, False)
        End If

        ' ЗАГРУЗКА ПРОЕКТА
        RunProj = New RunProject("")
        Pers(fname)
        CreateArrays() : CreateConstants() : CreateHelpWords()
        Application.EnableVisualStyles()
        Initial()
        Application.Run()

    End Sub
    Private Sub Pers(ByVal file As String)
        isDevelop = False
        isCompilBest = True
        RunProj.isRUN = True
        proj = RunProj
        If RunProj.GetType.ToString.IndexOf(".") = -1 Then
            ClassAplication = ""
        Else
            ClassAplication = RunProj.GetType.ToString.Split(".")(0) & "."
        End If
        RunProj.pPath = System.IO.Path.GetDirectoryName(file) & "\"
        RunProj.pFileName = System.IO.Path.GetFileName(file)
        RunProj.iPath = RunProj.pPath & "Pictures"
    End Sub
End Module

Namespace My
    Module my
        Public Function Forms()
        End Function
    End Module
End Namespace
