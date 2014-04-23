﻿Imports System.Net
Imports System.Text
Imports System.IO

Module HttpCompil
    Dim CompilPath As String = CurDir()
    Public ProjFile As String = CompilPath & "\Compil.alg"
    Public OutFile As String = CompilPath & "\Compil.exe"
    Public uid_in, uid_out As String

#If Http = False Then
    Sub Main()
    End Sub
#Else
    Dim bProxy As Boolean = True
    Dim sProxyAddress As String = "127.0.0.1", iProxyPort As Integer = 8888
    Dim Langs() As String = {"Russian", "English"}
    Dim counter As Integer = 0


    Dim pp As InternetControl
    Sub Main()
        MainForm.Timer3.Stop()
        Dim myHttpWebRequest As HttpWebRequest ' = HttpWebRequest.Create("http://www.algoritm2.ru/httpcompil/ochered.php")
        Dim nowLang As String = Langs(counter Mod 2)
        counter += 1
        Try
            Dim SitePath As String
            If nowLang = "Russian" Then
                SitePath = "httpcompil"
            Else
                SitePath = "httpcompileng"
            End If
            myHttpWebRequest = HttpWebRequest.Create("http://www.algoritm2.ru/" & SitePath & "/ochered.php")
            ' ПОЛУЧАЕМ ФАЙЛ ПРОЕКТА ИЗ ОЧЕРЕДИ
            myHttpWebRequest.Timeout = 3000
            myHttpWebRequest.KeepAlive = False
            '  myHttpWebRequest.Proxy = Nothing
            Dim myHttpWebResponse As HttpWebResponse = myHttpWebRequest.GetResponse()
            ' получаем проект
            Dim myStreamReader As New StreamReader(myHttpWebResponse.GetResponseStream, Encoding.GetEncoding(UTF8Encoding.UTF8.CodePage))
            Dim cod As String = myStreamReader.ReadToEnd()
            myHttpWebResponse.Close()
            If cod.IndexOf("|") <> 15 Or cod.Length <= 15 Then MainForm.Timer3.Start() : Exit Sub

            ' Если проект есть то надо подогнать язык
            If nowLang <> lang_name Then
                ProgressFormShow(transInfc("Перевод"))
                ' задание нового языка программирования, старый острается храниться в old'ах
                lang_name = trans(nowLang, True) : setLangs(False)
                ' Перезапись всех ключевых слов и функций
                CreatePoleznie() : CreateArrays() : CreateConstants() : CreateHelpWords()
                proj.f(proj.f.Length - 1).obj.name = MyZnak & trans("Полезные объекты")
                proj.f(proj.f.Length - 1).MyObjs = PoleznieObjs
                ' Возврат переменных языка к обычному состоянию равенства
                lang_name_old = lang_name : langOld = lang : langLwOld = langLw
                ProgressForm.Hide()
            End If

            ' Получаем код проекта и uid_in
            uid_in = cod.Split("|")(0)
            uid_out = ""
            cod = cod.Substring(uid_in.Length + 1)

            ' Язык проекта
            Dim ind As Integer
            ind = Trim(cod).IndexOf("Language = ") + "Language = ".Length
            If ind = "Language = ".Length Then
                Dim newLang As String = Trim(cod).Substring(ind, Trim(cod).IndexOf(vbCrLf) - ind)
                If newLang <> lang_name Then uid_out = "ErrorOpen" : ProgressForm.Hide() : GoTo out
            End If

            ' КОМПИЛИРУЕМ
            IO.File.WriteAllText(ProjFile, cod, Encoding.UTF8)
            Try
                MainForm.OpenProj(ProjFile)
            Catch ex As Exception
                uid_out = "ErrorOpen" : ProgressForm.Hide() : GoTo out
            End Try
            Try
                MainForm.BuildProgramMenu_Click(Nothing, Nothing)
                If uid_out.IndexOf("ErrorCompil") = 0 Then ProgressForm.Hide() : GoTo out
            Catch ex As Exception
                uid_out = "ErrorCompil" : ProgressForm.Hide() : GoTo out
            End Try

            ' ЗАГРУЖАЕМ НА ФПТ
            uid_out = GetUIN()
            Upload(OutFile, SitePath)

            ' СООБЩАЕМ ПРОГРАММЕ НОВОЕ ИМЯ ФАЙЛА
out:
            'pp = New InternetControl
            'pp.UrlToGo = "http://www.algoritm2.ru/" & SitePath & "/ochered2.php"
            'pp.HttpMethod = "POST"
            'pp.EncodingPage = "utf-8"
            'pp.ContentQuery = "uid_in=" & uid_in & "&uid_out=" & uid_out
            'pp.ExecuteQuery(True)
            'pp.ResultQuery = pp.ResultQuery

            Dim str = "http://www.algoritm2.ru/" & SitePath & "/ochered2.php?uid_in=" & uid_in & "&uid_out=" & uid_out
            Dim myHttpWebRequest2 As HttpWebRequest = HttpWebRequest.Create(str)
            myHttpWebRequest2.Timeout = 3000
            myHttpWebRequest2.KeepAlive = False
            Dim myHttpWebResponse2 As HttpWebResponse = myHttpWebRequest2.GetResponse()
            myHttpWebRequest2.Abort()
            myHttpWebResponse2.Close()
            Dim a = 1

        Catch ex As Exception
            myHttpWebRequest.Abort()
            'myHttpWebRequest2.Abort()
            'MsgBox("uid_in:" & uid_in & "uid_out:" & uid_out & vbCrLf & vbCrLf & ex.Message)
        End Try
        MainForm.Timer3.Start()
    End Sub
    Public Sub Upload(ByVal filename As String, ByVal SitePath As String)

        'Dim ftpServerIP As String = "80.90.114.50"
        'Dim ftpUserID As String = "algor140"
        'Dim ftpPassword As String = "n72bpd64"
        'Dim ftpServerIP As String = "algoritm2.vladimirov-resto.ru"
        'Dim ftpUserID As String = "algoritm2@vladimirov-resto.ru"
        'Dim ftpPassword As String = "qwer68mmm"
        'Dim fileInf As New IO.FileInfo(filename)
        'Dim uri As String = "ftp://" + ftpServerIP + "/" & SitePath & "/compils/"
        'Dim reqFTP As System.Net.FtpWebRequest
        Dim ftpServerIP As String = "algoritm2.ru/public_html"
        Dim ftpUserID As String = "alg"
        Dim ftpPassword As String = "tT2NI2gP"
        Dim fileInf As New IO.FileInfo(filename)
        Dim uri As String = "ftp://" + ftpServerIP + "/" & SitePath & "/compils/"
        Dim reqFTP As System.Net.FtpWebRequest
        '' СОЗДАНИЕ ПАПКИ
        'reqFTP = System.Net.FtpWebRequest.Create(New Uri(uri))
        '' Аунтификация
        'reqFTP.Credentials = New System.Net.NetworkCredential(ftpUserID, ftpPassword)
        '' Обрывать соединение после выполнения команды
        'reqFTP.KeepAlive = False
        '' Specify the data transfer type.
        'reqFTP.UseBinary = True
        '' Команда "Создать папку"
        'reqFTP.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory
        '' выполнить запрос
        'Try
        '    reqFTP.GetResponse()
        'Catch ex As Exception
        'End Try


        ' ПЕРЕДАЧА ФАЙЛА
        reqFTP = System.Net.FtpWebRequest.Create(New Uri(uri & uid_out & ".exe"))
        reqFTP.Proxy = Nothing
        ' Аунтификация
        reqFTP.Credentials = New System.Net.NetworkCredential(ftpUserID, ftpPassword)
        ' Обрывать соединение после выполнения команды
        reqFTP.KeepAlive = False
        ' Команда аплоад
        reqFTP.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        ' Notify the server about the size of the uploaded file
        reqFTP.ContentLength = fileInf.Length
        ' The buffer size is set to 2kb
        Dim buffLength As Integer = 32768
        Dim buff(buffLength) As Byte
        Dim contentLen As Integer

        ' Opens a file stream (System.IO.FileStream) to read the file to be uploaded
        Dim fs As IO.FileStream = fileInf.OpenRead()
        Try
            ' Stream to which the file to be upload is written
            Dim strm As IO.Stream = reqFTP.GetRequestStream()
            ' Read from the file stream 2kb at a time
            contentLen = fs.Read(buff, 0, buffLength)
            ' Till Stream content ends
            While contentLen <> 0
                ' Write Content from the file stream to the 
                ' FTP Upload Stream
                strm.Write(buff, 0, contentLen)
                contentLen = fs.Read(buff, 0, buffLength)
            End While
            ' Close the file stream and the Request Stream
            strm.Close()
            fs.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Upload Error")
        End Try
    End Sub
#End If
    

End Module
