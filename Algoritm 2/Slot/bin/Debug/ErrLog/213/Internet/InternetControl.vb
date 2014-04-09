Public Class InternetControl
    Implements IInternetEvents

#Region "Internet"
    Public myHttpWebRequest As Net.HttpWebRequest
    Public myHttpWebResponse As Net.HttpWebResponse
    Dim WithEvents Tmr As New System.Windows.Forms.Timer()

    Public Event SendingQuery(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Implements IInternetEvents.SendingQuery
    Public Event SentQuery(ByVal sender As Object, ByVal e As EventArgs) Implements IInternetEvents.SentQuery
    Public Event ReceivedResponse(ByVal sender As Object, ByVal e As EventArgs) Implements IInternetEvents.ReceivedResponse
    Public Event ReceiveProgress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs) Implements IInternetEvents.ReceiveProgress
    Public Event DownloadCancelled(ByVal sender As Object, ByVal e As EventArgs) Implements IInternetEvents.DownloadCancelled
    Dim KpAlv As Boolean
    Property KeepAlive() As Boolean
        Get
            Return KpAlv
        End Get
        Set(ByVal value As Boolean)
            KpAlv = value
        End Set
    End Property
    Dim AlAuRd As Boolean
    Property AllowAutoRedirect() As Boolean
        Get
            Return AlAuRd
        End Get
        Set(ByVal value As Boolean)
            AlAuRd = value
        End Set
    End Property
    Dim UrTG As String = SiteAlg
    Property UrlToGo() As String
        Get
            Return UrTG
        End Get
        Set(ByVal value As String)
            UrTG = value
            TextBox1.Text = value
        End Set
    End Property
    Dim UrlRf As String
    Property UrlReferer() As String
        Get
            Return UrlRf
        End Get
        Set(ByVal value As String)
            UrlRf = value
        End Set
    End Property
    Dim UrlRdr As String
    Property UrlRedirect() As String
        Get
            Return UrlRdr
        End Get
        Set(ByVal value As String)
            UrlRdr = value
            TextBox4.Text = value
        End Set
    End Property
    Dim UsAg As String = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;"
    Property UserAgent() As String
        Get
            Return UsAg
        End Get
        Set(ByVal value As String)
            UsAg = value
        End Set
    End Property
    Dim Acpt As String = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
    Property Accept() As String
        Get
            Return Acpt
        End Get
        Set(ByVal value As String)
            Acpt = value
        End Set
    End Property
    Dim PrxIp As String = ""
    Property ProxyIp() As String
        Get
            Return PrxIp
        End Get
        Set(ByVal value As String)
            PrxIp = value
        End Set
    End Property
    Dim PrxPt As String = ""
    Property ProxyPort() As String
        Get
            Return PrxPt
        End Get
        Set(ByVal value As String)
            PrxPt = value
        End Set
    End Property
    Dim Encod As String = "windows-1251"
    Property EncodingPage() As String
        Get
            Return Encod
        End Get
        Set(ByVal value As String)
            Encod = value
        End Set
    End Property
    Dim LngP As String = ""
    Property LanguagePage() As String
        Get
            Return LngP
        End Get
        Set(ByVal value As String)
            LngP = value
        End Set
    End Property
    Dim Prms As String = ""
    Property ContentQuery() As String
        Get
            Return Prms
        End Get
        Set(ByVal value As String)
            Prms = value
            TextBox2.Text = value
        End Set
    End Property
    Dim ConTyp As String = "application/x-www-form-urlencoded"
    Property ContentType() As String
        Get
            Return ConTyp
        End Get
        Set(ByVal value As String)
            ConTyp = value
            ComboBox1.Text = value
        End Set
    End Property
    Dim ConLen As Integer = 0
    Property ContentLength() As String
        Get
            Return ConLen
        End Get
        Set(ByVal value As String)
            ConLen = value
        End Set
    End Property
    Dim Mtd As String = "POST"
    Property HttpMethod() As String
        Get
            Return Mtd
        End Get
        Set(ByVal value As String)
            Mtd = value
            ComboBox2.Text = value
        End Set
    End Property
    Dim ResCd As String = ""
    Property ResultCode() As String
        Get
            Return ResCd
        End Get
        Set(ByVal value As String)
            ResCd = value
        End Set
    End Property
    Dim tmOut As String = "10000"
    Property TimeOut() As String
        Get
            Return tmOut
        End Get
        Set(ByVal value As String)
            tmOut = value
        End Set
    End Property
    Dim tmd As String = "0"
    Property TimeDelay() As String
        Get
            Return tmd
        End Get
        Set(ByVal value As String)
            If value > 0 Then
                tmd = value : Tmr.Interval = value
            Else
                tmd = 0 : Tmr.Interval = 1
            End If
        End Set
    End Property
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr.Tick
        Tmr.Stop()
    End Sub

    Dim Hdrs As String = ""
    Property Headers() As String
        Get
            Return Hdrs
        End Get
        Set(ByVal value As String)
            Hdrs = value
        End Set
    End Property
    Function GetHeadersToMy(ByVal hs As Net.WebHeaderCollection) As String
        Dim i As Integer, str As String = ""
        For i = 0 To hs.Keys.Count - 1
            str &= hs.AllKeys(i) & ":" & hs.Item(i) & vbCrLf
        Next
        Return str
    End Function
    Dim Cooc As String = ""
    Property CookiesQueries() As String
        Get
            Return Cooc
        End Get
        Set(ByVal value As String)
            Cooc = value
        End Set
    End Property
    Function GetCookiesToMy(ByVal cc As Net.CookieCollection) As String
        Dim i As Integer, str As String = ""
        For i = 0 To cc.Count - 1
            str &= cc.Item(i).Name & "=" & cc.Item(i).Value & vbCrLf
            str &= "Создан" & ":" & cc.Item(i).TimeStamp.ToString() & "; "
            If cc.Item(i).Expires.Ticks = 0 Then
                str &= "Уничтожится" & ":" & "не указано" & "; "
            Else
                str &= "Уничтожится" & ":" & cc.Item(i).Expires.ToString() & "; "
            End If
            str &= "Путь" & ":" & cc.Item(i).Path & "; "
            str &= "Домен" & ":" & cc.Item(i).Domain & "; "
            str &= "HttpOnly" & ":" & cc.Item(i).HttpOnly & "; " & vbCrLf
        Next
        Return str
    End Function
    Function GetCookiesFromoMy(ByVal str As String) As Net.CookieCollection
        Dim i, j As Integer, cc As New Net.CookieCollection()
        Dim ch() As String = str.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        If ch.Length < 2 Then Return cc
        For i = 0 To ch.Length - 1 Step 2
            Dim co As New Net.Cookie(ch(i).Split("=")(0).Trim, ch(i).Substring(ch(i).IndexOf("=") + 1).Trim)
            Dim cParams() As String = ch(i + 1).Split(New String() {"; ", ";"}, StringSplitOptions.RemoveEmptyEntries)
            ' задаем основные параметры из заголовка
            For j = 0 To cParams.Length - 1
                Dim prm As String = cParams(j).Substring(cParams(j).IndexOf(":") + 1)
                If cParams(j).IndexOf("Уничтожится" & ":") = 0 Then
                    If prm.ToUpper <> "не указано".ToUpper Then co.Expires = prm
                ElseIf cParams(j).IndexOf("Путь" & ":") = 0 Then
                    co.Path = prm
                ElseIf cParams(j).IndexOf("Домен" & ":") = 0 Then
                    co.Domain = prm
                ElseIf cParams(j).IndexOf("HttpOnly" & ":") = 0 Then
                    co.HttpOnly = prm
                End If
            Next
            cc.Add(co)
        Next
        Return cc
    End Function
    Dim src As String
    Public Property ResultQuery() As String
        Get
            Return src
        End Get
        Set(ByVal value As String)
            src = value
            TextBox3.Text = value
        End Set
    End Property

    Dim buf As Integer = 50000
    Public Property BufferSize() As Integer
        Get
            Return buf
        End Get
        Set(ByVal value As Integer)
            buf = value
        End Set
    End Property
    Dim PathForDownl As String
    Public Property PathForDownloads() As String
        Get
            Return PathForDownl
        End Get
        Set(ByVal value As String)
            PathForDownl = value
        End Set
    End Property
    Dim FileDnlng As Boolean = False
    Public Property FileDownloading() As Boolean
        Get
            Return FileDnlng
        End Get
        Set(ByVal value As Boolean)
            FileDnlng = value
            If value = False Then DownloadPause = False
        End Set
    End Property
    Dim DnlngPs As Boolean = False
    Public Property DownloadPause() As Boolean
        Get
            Return DnlngPs
        End Get
        Set(ByVal value As Boolean)
            DnlngPs = value
        End Set
    End Property
    Public Property CheckConnect() As Boolean
        Get
            Dim oldUrl As String = UrlToGo
            Dim oldMet As String = HttpMethod
            Try
                UrlToGo = "http://google.com"
                HttpMethod = "GET"
                PeredQuery()
                UrlToGo = oldUrl
                HttpMethod = oldMet
                System.Windows.Forms.Application.DoEvents()
                myHttpWebResponse = myHttpWebRequest.GetResponse()
                Return True
            Catch ex As Exception
                UrlToGo = oldUrl
                HttpMethod = oldMet
                Return False
            End Try
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property


    ' ПОШЛИ МЕТОДЫ
    Sub DownloadCancel()
        FileDownloading = False
    End Sub
    Sub DownloadResume()
        DownloadPause = False
    End Sub
    Public Sub ClearCookies()
        CookiesQueries = ""
    End Sub

    ' Задержка
    Sub DelayQuery()
        If TimeDelay <> 0 Then
            Tmr.Start()
            While Tmr.Enabled : System.Windows.Forms.Application.DoEvents() : End While
        End If
    End Sub
    ' Объединения ссылок. Например, http://job.yuga.ru/addresume/index.shtml и /img/spamfilter/4tynk3lh143zogpdhkxpyc956imq06ol.gif
    Function ConnectUris(ByVal BeginUri As String, ByVal EndUri As String) As String
        If EndUri = "" Then Return ""
        If EndUri.IndexOf("http") <> 0 Then
            If BeginUri <> "" Then
                Dim ur As New Uri(BeginUri)
                If EndUri.IndexOf("/") = 0 Then
                    EndUri = ur.Scheme & "://" & ur.Host & EndUri
                Else
                    Dim ind As Integer = ur.AbsolutePath.LastIndexOf("/")
                    If ind <> -1 Then
                        EndUri = ur.Scheme & "://" & ur.Host & ur.AbsolutePath.Substring(0, ind + 1) & EndUri
                    End If
                End If
            End If
        End If
        Return EndUri
    End Function

    ' ПОЛУЧИТЬ КОД СТРАНИЦЫ
    Function GetSourceCodePage(ByVal page As String) As String
        UrlToGo = page
        If UrlToGo = "" Then Return ""

        ' Выполнить запрос
        ExecuteQuery()

        myHttpWebResponse.Close()
        DelayQuery()

        Return ResultQuery
    End Function

    Dim thr As Threading.Thread
    Dim FlName As String
    ' СКАЧАТЬ ФАЙЛ
    Sub DownloadFile(ByVal fl As String, ByVal WaitForDownload As Boolean)

        If FileDownloading Then
            MsgBox(trans("Уже идет скачивание файла. Сначала дождитесь его завершения.")) : Exit Sub
        End If

        ' Вызов события ОтправляетсяЗапроса
        Dim e As New System.ComponentModel.CancelEventArgs()
        RaiseEvent SendingQuery(Me, e)
        If e.Cancel Then Exit Sub

        ' Стандартизировать ссылку. Например, если рисунок задан относительно, а не абсолютно
        fl = ConnectUris(UrlToGo, fl.Trim)
        UrlToGo = fl

        Dim oldMet As String = Me.HttpMethod
        HttpMethod = "GET"

        ' Выполнить запрос
        ExecuteQuery(False)

        HttpMethod = oldMet

        ' Получить собственно файл
        If PathForDownl = "" Then
            FlName = IO.Path.GetTempPath & IO.Path.GetFileName(fl)
        Else
            PathForDownloads = GetMaxPath(PathForDownloads)
            If IO.Directory.Exists(PathForDownloads) = False Then
                IO.Directory.CreateDirectory(PathForDownloads)
            End If
            FlName = PathForDownloads & "\" & IO.Path.GetFileName(fl)
        End If
        If IO.Path.GetFileName(FlName).Split(IO.Path.GetInvalidFileNameChars).Length > 1 Then
            FlName = IO.Path.GetTempPath & GetUIN() & ".tmp"
        End If

        ' Получить асинхронно
        If WaitForDownload = False Then
            thr = New Threading.Thread(AddressOf AsyncDownload)
            thr.Start(myHttpWebResponse.GetResponseStream)

            ' Получить синхронно
        Else
            FileDownloading = True
            Dim myStreamReader As New IO.BinaryReader(myHttpWebResponse.GetResponseStream)
            Dim all As New System.Collections.Generic.List(Of Byte)
            Do
                ' Собственно получения порции данных
                Dim bts() As Byte = myStreamReader.ReadBytes(BufferSize)
                If bts.Length = 0 Then Exit Do
                all.AddRange(bts)
                ' Вызов события Идет прием данных
                ReceiveProgressInvoke(all.Count)
            Loop
            DownloadSuccess(all)
        End If
    End Sub
    ' Функция реализующая поток, который скачивайт файл порциями BufferSize
    Sub AsyncDownload(ByVal stream As Object)
        FileDownloading = True
        Dim myStreamReader As New IO.BinaryReader(stream)
        Dim all As New System.Collections.Generic.List(Of Byte)
        Do
            ' Всякие Прерывания и Паузы потока
            If FileDownloading = False Then DownloadCancelledInvoke() : myStreamReader.Close() : Exit Sub
            While DownloadPause
                System.Windows.Forms.Application.DoEvents()
                If FileDownloading = False Then DownloadCancelledInvoke() : myStreamReader.Close() : Exit Sub
            End While

            ' Собственно получения порции данных
            Dim bts() As Byte = myStreamReader.ReadBytes(BufferSize)
            If bts.Length = 0 Then Exit Do
            all.AddRange(bts)
            ' Вызов события Идет прием данных
            ReceiveProgressInvoke(all.Count)
        Loop
        DownloadSuccess(all)
    End Sub
    Delegate Sub dDownloadSuccess(ByVal lst As System.Collections.Generic.List(Of Byte))
    Sub DownloadSuccess(ByVal lst As System.Collections.Generic.List(Of Byte))
        If Me.InvokeRequired Then
            Dim d As New dDownloadSuccess(AddressOf DownloadSuccess)
            Me.Invoke(d, New Object() {lst})
        Else
            ' Собственно завершение загрузки
            IO.File.WriteAllBytes(FlName, lst.ToArray)
            ResultQuery = FlName

            ' Снимаем синхблок
            FileDownloading = False

            ' Вызов события ПолученОтвет
            RaiseEvent ReceivedResponse(Me, New EventArgs)
        End If
    End Sub
    Delegate Sub dReceiveProgressInvoke(ByVal count As Long)
    Sub ReceiveProgressInvoke(ByVal count As Long)
        If Me.InvokeRequired Then
            Dim d As New dReceiveProgressInvoke(AddressOf ReceiveProgressInvoke)
            Me.Invoke(d, New Object() {count})
        Else
            ' Вызов события Идет прием данных
            RaiseEvent ReceiveProgress(Me, New WinsockReceiveProgressEventArgs(UrlToGo, count, ContentLength))
        End If
    End Sub
    Delegate Sub dDownloadCancelledInvoke()
    Sub DownloadCancelledInvoke()
        If Me.InvokeRequired Then
            Dim d As New dDownloadCancelledInvoke(AddressOf DownloadCancelledInvoke)
            Me.Invoke(d, New Object() {})
        Else
            ' Вызов события Идет прием данных
            RaiseEvent DownloadCancelled(Me, New EventArgs)
        End If
    End Sub

    ' ВЫПОЛНИТЬ ПРОСТО ЗАПРОС
    Public Sub ExecuteQuery(Optional ByVal withClose As Boolean = True)

        If UrlToGo = "" Then Exit Sub

        ' Вызов события ОтправляетсяЗапроса
        If withClose Then
            Dim e As New System.ComponentModel.CancelEventArgs()
            RaiseEvent SendingQuery(Me, e)
            If e.Cancel Then Exit Sub
        End If

        ' Подготовка хттп-класса к запросу
        PeredQuery()

        ' запрос!
        Try
            System.Windows.Forms.Application.DoEvents()
            myHttpWebResponse = myHttpWebRequest.GetResponse()
        Catch ex As Exception
            Me.ResultCode = ex.Message
            If IgnorEr = False Then Throw ex
            Exit Sub
        End Try

        ' Вызов события ОтправилсяЗапрос
        RaiseEvent SentQuery(Me, New EventArgs())

        ' Занесение результатов запроса в хттп-класс
        PosleQuery()

        If withClose Then
            ' Получить собственно код страницы
            Dim myStreamReader As New IO.StreamReader(myHttpWebResponse.GetResponseStream, System.Text.Encoding.GetEncoding(EncodingPage))
            ResultQuery = myStreamReader.ReadToEnd()
            myStreamReader.Close()

            ' Вызов события ПолученОтвет
            RaiseEvent ReceivedResponse(Me, New EventArgs)

            myHttpWebResponse.Close()
            DelayQuery()
        End If

    End Sub

    ' Подготовка хттп-класса к запросу
    Sub PeredQuery()
        ' Задаем заголовки, в зависимости от настроек
        myHttpWebRequest = Net.HttpWebRequest.Create(UrlToGo)
        If ProxyIp <> "" Then myHttpWebRequest.Proxy = New Net.WebProxy(ProxyIp, Convert.ToInt32(ProxyPort))
        myHttpWebRequest.Referer = UrlReferer
        myHttpWebRequest.UserAgent = UserAgent
        myHttpWebRequest.Accept = Accept
        myHttpWebRequest.Method = HttpMethod
        myHttpWebRequest.Timeout = TimeOut
        myHttpWebRequest.Headers.Add("Accept-Language", LanguagePage)
        myHttpWebRequest.KeepAlive = KeepAlive
        myHttpWebRequest.AllowAutoRedirect = AllowAutoRedirect
        myHttpWebRequest.ContentType = ContentType
        'myHttpWebRequest.Headers.Add(HttpRequestHeader.Cookie, Cookies)
        ' Dim cc As CookieCollection = GetCookiesFromoMy(Cookies)
        myHttpWebRequest.CookieContainer = New Net.CookieContainer()
        'If cc IsNot Nothing Then
        myHttpWebRequest.CookieContainer.Add(GetCookiesFromoMy(CookiesQueries))
        'Dim cooo As New CookieCollection
        'myHttpWebRequest.CookieContainer = New CookieContainer()
        'If cooo IsNot Nothing Then
        '    myHttpWebRequest.CookieContainer.Add(cooo)
        'End If

        ' передаем переменные
        If ContentQuery.Length > 0 Then
            Dim ByteArr As Byte() = System.Text.Encoding.GetEncoding(EncodingPage).GetBytes(ContentQuery)
            myHttpWebRequest.ContentLength = ByteArr.Length()
            Dim sw As New IO.BinaryWriter(myHttpWebRequest.GetRequestStream(), System.Text.Encoding.GetEncoding(EncodingPage))
            sw.Write(ByteArr, 0, ByteArr.Length)
            sw.Close()
        End If
    End Sub
    ' Занесение результатов запроса в хттп-класс
    Sub PosleQuery()
        'получаем куки, которые возвратил UrlToGo
        ''Cookies = ""
        'If Not String.IsNullOrEmpty(myHttpWebResponse.Headers("Set-Cookie")) Then
        '    Cookies = myHttpWebResponse.Headers("Set-Cookie")
        'End If

        Dim cooo As Net.CookieCollection = GetCookiesFromoMy(CookiesQueries)
        'myHttpWebResponse.Cookies = myHttpWebRequest.CookieContainer.GetCookies(myHttpWebRequest.RequestUri)
        'If myHttpWebResponse.Cookies IsNot Nothing Then
        '    ' cooo.Add(myHttpWebResponse.Cookies)
        ' Также надо добавить куки из заголовка, если такие есть.
        If Not String.IsNullOrEmpty(myHttpWebResponse.Headers("Set-Cookie")) Then
            ' Разбираем куки 
            Dim i, j As Integer
            Dim ch() As String = myHttpWebResponse.Headers("Set-Cookie").Replace(", ", "~!@#$%v").Split(",")
            Dim cc As New Net.CookieContainer()
            For i = 0 To ch.Length - 1
                Dim cParams() As String = ch(i).Replace("~!@#$%v", ", ").Split(New String() {"; "}, StringSplitOptions.None)
                Dim co As New Net.Cookie(cParams(0).Split("=")(0), cParams(0).Substring(cParams(0).IndexOf("=") + 1))
                ' задаем основные параметры из заголовка
                For j = 1 To cParams.Length - 1
                    If cParams(j).IndexOf("expires=") = 0 Then
                        co.Expires = cParams(j).Substring(cParams(j).IndexOf("=") + 1)
                    ElseIf cParams(j).IndexOf("path=") = 0 Then
                        co.Path = cParams(j).Substring(cParams(j).IndexOf("=") + 1)
                    ElseIf cParams(j).IndexOf("domain=") = 0 Then
                        co.Domain = cParams(j).Substring(cParams(j).IndexOf("=") + 1)
                    ElseIf UCase(cParams(j)).IndexOf(UCase("httponly")) = 0 Then
                        co.HttpOnly = True
                    End If
                Next
                ' если в заголовке небыли явно указаны параметры, то указываим их сами
                If co.Path = "" Then co.Path = myHttpWebRequest.RequestUri.AbsolutePath
                If co.Domain = "" Then co.Domain = myHttpWebRequest.RequestUri.Host
                ' добавить кук
                cooo.Add(co)
            Next
            'End If
        End If
        CookiesQueries = GetCookiesToMy(cooo)

        ' Основные данные запроса
        ResultCode = myHttpWebResponse.StatusCode
        ContentType = myHttpWebResponse.ContentType
        If ContentType.IndexOf("charset=") <> -1 Then
            EncodingPage = ContentType.Substring(ContentType.IndexOf("charset=") + "charset=".Length)
        End If
        ContentQuery = ""
        ContentLength = myHttpWebResponse.ContentLength
        Headers = GetHeadersToMy(myHttpWebResponse.Headers)

        ' урл редиректа приводим в божеский вид
        UrlRedirect = myHttpWebResponse.Headers("Location")
        ' Стандартизировать ссылку. Например, если ссылка вернута относительно, а не абсолютно
        UrlRedirect = ConnectUris(myHttpWebResponse.ResponseUri.AbsoluteUri, UrlRedirect)
    End Sub
#End Region


#Region "UserInterface"
    Public IsDevelop As Boolean = False

    Private Sub Internet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tmr.Interval = 1

        Label1.Text = trans(Label1.Text.Split(":")(0)) & ":"
        Label2.Text = trans(Label2.Text.Split(":")(0)) & ":"
        Label3.Text = trans(Label3.Text.Split(":")(0)) & ":"
        Label4.Text = trans(Label4.Text.Split(":")(0)) & ":"
        Label5.Text = trans(Label5.Text.Split(":")(0)) & ":"
        Button1.Text = trans(Button1.Text)
        TextBox1.Text = UrlToGo
        TextBox4.Text = UrlRedirect

        Dim arr(ContentTypes.Values.Count - 1) As String, i As Integer
        ContentTypes.Keys.CopyTo(arr, 0)
        For i = 0 To arr.Length - 1
            arr(i) = arr(i).Replace("""", "")
        Next
        ComboBox1.Items.AddRange(arr)
        ComboBox1.Text = ContentType

        Dim arr2(HttpMethods.Values.Count - 1) As String
        HttpMethods.Keys.CopyTo(arr2, 0)
        ComboBox2.Items.AddRange(arr2)
        ComboBox2.Text = HttpMethod
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If IsDevelop = False Then
            UrlToGo = TextBox1.Text
            ContentQuery = TextBox2.Text
            ContentType = ComboBox1.Text
            HttpMethod = ComboBox2.SelectedItem
            ExecuteQuery()
        End If
    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        ConTyp = sender.text
    End Sub
    Private Sub ComboBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.TextChanged
        Mtd = sender.text
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        UrTG = sender.text
    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Prms = sender.text
    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        src = sender.text
    End Sub
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        UrlRdr = sender.text
    End Sub
#End Region

End Class
