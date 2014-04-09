Public Class Main1
    Private Sub Main1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' ЧТЕНИЕ КОДА ПРОГРАММЫ ИЗ ЕХЕ ФАЙЛА
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
        ' Получение программного кода
        fs.Position = start
        ReDim code_bytes(fs.Length - fs.Position - 6 - 1)
        fs.Read(code_bytes, 0, code_bytes.Length)
        code_chars = System.Text.Encoding.UTF8.GetChars(code_bytes)
        code = String.Concat(code_chars)
        fs.Close()
        ' code = System.IO.File.OpenText("1.txt").ReadToEnd

        ' ЗАДАНИЕ ОСНОВНЫХ ПЕРЕМЕННЫХ
        ' Сначала извлечь язык
        Dim langStr As String = code.Substring(0, code.IndexOf("~~~"))
        code = code.Substring(code.IndexOf("~~~") + 3)
        lang = Get2ListFromString(langStr, "~~")
        langLw = Get2ListFromString(langStr, "~~", , True)
        langINFC = lang : langLwINFC = langLw
        langOld = lang : langLwOld = langLw
        lang_name = "Russian" : lang_interface = lang_name : lang_name_old = lang_name

        ' Извлечь английский
        Dim langEngStr As String = code.Substring(0, code.IndexOf("~~~"))
        code = code.Substring(code.IndexOf("~~~") + 3)
        langENG = Get2ListFromString(langEngStr, "~~")
        langLwENG = Get2ListFromString(langEngStr, "~~", , True)

        ' Делегат
        delegatNodeStop = New RunProj_NodeStop_delegate(AddressOf RunProj_NodeStop)
        ' Создание ранпректа
        RunProj = New RunProject(code)
        AddHandler RunProj.NodeStop, AddressOf RunProj_NodeStop
        AddHandler RunProj.StopRun, AddressOf RunProj_StopRun
        ' Задание переменных проекта
        Pers(fname)
        CreateProjParams(code, True)
        CreateArrays() : CreateConstants() : CreateHelpWords() : CreatePoleznie()

        ' ЗАПУСК КОДА
        RunProj.Run()
        Me.Hide()
    End Sub
    Private Sub Pers(ByVal file As String)
        isDevelop = False
        proj = RunProj
        ClassAplication = "Compil."
        RunProj.pPath = System.IO.Path.GetDirectoryName(file)
        RunProj.pFileName = System.IO.Path.GetFileName(file)
        RunProj.iPath = RunProj.pPath & "\Pictures"
    End Sub
    ' Вызывается при событии Ошибка в проекте
    Public Sub RunProj_NodeStop(ByVal node As TreeNode, ByVal param As PropertysSobyt)
        Dim str As String
        str = trans("Ошибка в строке") & ": " & vbCrLf & node.Text & "." & vbCrLf & vbCrLf & _
              trans("Описание ошибки") & ": " & vbCrLf & param.err.err & vbCrLf & vbCrLf ' & _ 
        '  trans("Промежуточное представление") & ": " & vbCrLf & param.err.str & vbCrLf & vbCrLf

        Dim msRes As MsgBoxResult = MsgBox(str, MsgBoxStyle.AbortRetryIgnore + MsgBoxStyle.Critical)
        ' Обработка ответа в однопоточном режиме
        If RunProj.isPotok = False Then
            ' Если нажали пропустить берем следующую ветку
            If msRes = MsgBoxResult.Ignore Then
                RunProj.isRUN = True
                If node.Parent.Nodes.Count > node.Index + 1 Then
                    RunProj.RunBlock(node.Parent, node.Index + 1, param, True)
                End If
                ' Если нажали повторить
            ElseIf msRes = MsgBoxResult.Retry Then
                RunProj.isRUN = True
                RunProj.RunBlock(node.Parent, node.Index, param, True)
                ' Если нажали прервать
            Else
                RunProj.isRUN = True
            End If
        End If
    End Sub
    ' Вызывается при событии Завершение проекта
    Private Sub RunProj_StopRun()
        End
    End Sub
End Class
