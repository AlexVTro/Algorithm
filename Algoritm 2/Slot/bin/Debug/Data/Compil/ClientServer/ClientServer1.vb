Public Class ClientServerMy
    Implements IWinSockEvents

#Region " Events "
    Friend WithEvents wskListen As New Winsock With {.LegacySupport = True}
    Friend WithEvents wskClient As New Winsock With {.LegacySupport = True}
    Friend WithEvents wskClients As New WinsockCollection 
    Friend WithEvents dlgSave As New System.Windows.Forms.SaveFileDialog
    Friend WithEvents dlgOpen As New System.Windows.Forms.OpenFileDialog
    ''' <summary>
    ''' Occurs when connection is achieved (client and server).
    ''' </summary>
    Public Event ConnectedToServer(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs) Implements IWinSockEvents.ConnectedToServer
    Public Event ConnectionClient(ByVal sender As System.Object, ByVal e As WinsockConnectionRequestEventArgs) Implements IWinSockEvents.ConnectionClient
    ''' <summary>
    ''' Occurs when the number of items in the collection has changed.
    ''' </summary>
    Public Event CountChanged(ByVal sender As Object, ByVal e As WinsockCollectionCountChangedEventArgs) Implements IWinSockEvents.CountChanged
    ''' <summary>
    ''' Occurs when data arrives on the socket.
    ''' </summary>
    ''' <remarks>Raised only after all parts of the data have been collected.</remarks>
    Public Event TextReceived(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWinSockEvents.TextReceived
    Public Event CommandReceived(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWinSockEvents.CommandReceived
    Public Event FileReceived(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWinSockEvents.FileReceived
    ''' <summary>
    ''' Occurs when disconnected from the remote computer (client and server).
    ''' </summary>
    Public Event Disconnected(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWinSockEvents.Disconnected
    ''' <summary>
    ''' Occurs when an error is detected in the socket.
    ''' </summary>
    ''' <remarks>May also be raised on disconnected (depending on disconnect circumstance).</remarks>
    Public Event ErrorReceived(ByVal sender As Object, ByVal e As WinsockErrorReceivedEventArgs) Implements IWinSockEvents.ErrorReceived
    ''' <summary>
    ''' Occurs when sending of data is completed.
    ''' </summary>
    Public Event SendTextComplete(ByVal sender As Object, ByVal e As WinsockSendEventArgs) Implements IWinSockEvents.SendTextComplete
    Public Event SendFileComplete(ByVal sender As Object, ByVal e As WinsockSendEventArgs) Implements IWinSockEvents.SendFileComplete
    ''' <summary>
    ''' Occurs when the send buffer has been sent but not all the data has been sent yet.
    ''' </summary>
    Public Event SendProgress(ByVal sender As Object, ByVal e As WinsockSendEventArgs) Implements IWinSockEvents.SendProgress
    Public Event ReceiveProgress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs) Implements IWinSockEvents.ReceiveProgress
    ''' <summary>
    ''' Occurs when the state of the socket changes.
    ''' </summary>
    Public Event StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs) Implements IWinSockEvents.StateChanged
#End Region

#Region " GUI "
    Public IsDevelop As Boolean = False
    Sub cmdCreateConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateConn.Click
        If IsDevelop Then Exit Sub
        If TypeServer = "Server" Then
            CreateServer()
        Else
            ConnectToServer()
        End If
    End Sub

    Private Sub cmdServerClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If IsDevelop Then Exit Sub
        If TypeServer = "Server" Then
            If cmdClose.Text.ToUpper = trans("Стоп поиск").ToUpper Then
                CloseListener()
            Else
                CloseServer()
            End If
        Else
            CloseClient()
        End If
    End Sub

    Private Sub cmdSendText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendText.Click
        If IsDevelop Then Exit Sub
        If txtSend.Text.Trim() <> "" Then
            SendToClients(txtSend.Text.Trim())
            txtSend.Text = ""
            txtSend.Focus()
        End If
    End Sub

    Private Sub cmdSendFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendFile.Click
        If IsDevelop Then Exit Sub
        If dlgOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            SendFileToClients(dlgOpen.FileName)
        End If
    End Sub

    Private Sub ComboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboType.SelectedIndexChanged
        If IsDevelop Then Exit Sub
        If ComboType.SelectedItem.ToUpper = trans("Сервер").ToUpper Then
            TypeServer = "Server"
            cmdCreateConn.Text = trans("Создать")
            cmdClose.Text = trans("Стоп поиск")
        Else
            TypeServer = "Client"
            cmdCreateConn.Text = trans("Присоединиться")
            cmdClose.Text = trans("Отключиться")
        End If
    End Sub

    Private Sub txtSend_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSend.KeyDown
        If IsDevelop Then Exit Sub
        If e.KeyData = Keys.Enter Then cmdSendText_Click(Nothing, Nothing)
    End Sub

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


#End Region

#Region " Client Server "

    Private Sub wskListen_ConnectionRequest(ByVal sender As System.Object, ByVal e As WinsockConnectionRequestEventArgs) Handles wskListen.ConnectionRequest
        Log(trans("Запрос соединения") & " (" & e.ClientIP & ")")
        If e.ClientIP = "bad IP" Then
            Log(trans("Запрос отвергнут") & ": " & trans("Неверный IP"))
            e.Cancel = True
        Else
            RaiseEvent ConnectionClient(sender, e)
            If e.Cancel Then Exit Sub

            Dim key As String = GetUIN()
            wskClients.Accept(e.Client, key)
            wskClients.Item(key).LegacySupport = True
            SendToClient(key.ToString, CommandSymbol & "Name" & Spl(0) & key.ToString)
            SendToClient(key.ToString, CommandSymbol & "IPs" & Spl(0) & ClientsIPs)
            SendToClient(key.ToString, CommandSymbol & "Names" & Spl(0) & ClientsNames)
            wskClients.Item(key).BufferSize = wskClient.BufferSize
            'wskClients.Item(key).MaxPendingConnections = 3
            AddHandler wskClients.Item(key).ReceiveProgress, AddressOf wskServer_ReceiveProgress
            'AddHandler wskClients.Item(key).Disposed, AddressOf wskClient_Disposed
            'AddHandler wskClients.Item(key).DataArrival, AddressOf wskServer_DataArrival
            'AddHandler wskClients.Item(key).Disconnected, AddressOf wskClient_Disconnected
            'AddHandler wskClients.Item(key).StateChanged, AddressOf wsk_StateChanged
        End If
    End Sub

    Dim ConnSender, ConnE
    Private Sub wskClient_Connected(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs) Handles wskClient.Connected
        ConnSender = sender : ConnE = e
    End Sub

    Dim SavingFile As Boolean = False
    Dim SavingFileTo As String

    Private Sub wskServer_DataArrival(ByVal sender As System.Object, ByVal e As WinsockDataArrivalEventArgs) Handles wskClients.DataArrival, wskClient.DataArrival
        Try
            Dim obj As Object

            Log(trans("Пришли данные") & " (" & e.SourceIP & ": " & e.TotalBytes & " " & "bytes" & ")")
            If TypeServer = "Server" Then
                Dim uid As String = wskClients.findKey(CType(sender, Winsock))
                Try
                    obj = wskClients.Item(uid).Get()
                Catch ex As Exception
                    Exit Sub
                End Try
            Else
                obj = wskClient.Get()
            End If

            If obj.GetType() Is GetType(String) Then
                ' Получаем строку
                ReceivStr = CStr(obj)
                Log(trans("Получено") & ": " & """" & ReceivStr & """")
                RunCommand(ReceivStr)
            ElseIf obj.GetType() Is GetType(Byte()) Then
                ReceivStr = System.Text.Encoding.UTF8.GetString(obj)
                Log(trans("Получено") & ": " & """" & ReceivStr & """")
                RunCommand(ReceivStr)
            Else
                If obj.GetType() IsNot GetType(WinsockFileData) Then
                    MsgBox("Serialization error!") : Exit Sub
                End If
                ' Получаем файл
                Dim wfd As Object = obj ' = DirectCast(obj, WinsockFileData)
                ' Если не задана папка для закачек, то показать диалог
                If PathForDownloads = "" Then
                    dlgSave.FileName = wfd.FileName
                    SavingFile = True
                    If dlgSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        ReceivedFile = dlgSave.FileName
                    Else
                        ReceivedFile = ""
                    End If
                Else
                    ' Создаем директорию, если таковой еще нет
                    PathForDownloads = GetMaxPath(PathForDownloads)
                    If IO.Directory.Exists(PathForDownloads) = False Then
                        IO.Directory.CreateDirectory(PathForDownloads)
                    End If
                    Dim fl As String = (PathForDownloads & "\" & wfd.FileName).Replace("\\", "\")
                    ReceivedFile = fl
                    ' Если такой файл уже существует, то подобрать имя
                    Dim num As Integer = 1
                    While IO.File.Exists(ReceivedFile)
                        ReceivedFile = IO.Path.GetDirectoryName(fl) & "\" _
                            & IO.Path.GetFileNameWithoutExtension(fl) _
                            & "-" & num & IO.Path.GetExtension(fl)
                        num += 1
                    End While
                End If
                ' Сохранить полученный файл
                If ReceivedFile <> "" Then
                    wfd.SaveFile(ReceivedFile)
                    Log(trans("Файл получен") & ": " & ReceivedFile)
                    RaiseEvent FileReceived(sender, Nothing)
                Else
                    Log(trans("Отмена получения файла"))
                End If
                ' Если сохраняли файл, пока приходила команда, то она ничего не сохранила, надо её заново вызвать
                If SavingFile And SavingFileTo <> "" Then
                    SavingFile = False
                    RunCommand(SavingFileTo)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub wskClient_Disconnected(ByVal sender As Object, ByVal e As System.EventArgs) Handles wskClient.Disconnected, wskClients.Disconnected
        If TypeServer = "Server" Then
            Dim uid As String = wskClients.findKey(sender)
            Log(trans("Отключился клиент") & " " & uid)
            wskClients.Remove(uid)
            RaiseEvent Disconnected(sender, e)
            If wskClients.Count = 0 Then
                cmdClose.Text = trans("Стоп поиск")
                cmdClose.Enabled = True
            End If
        Else
            Log(trans("Соединение разорвано"))
            RaiseEvent Disconnected(sender, e)
            ClientsNames = ""
        End If
    End Sub

    Private Sub wsk_ErrorReceived(ByVal sender As System.Object, ByVal e As WinsockErrorReceivedEventArgs) Handles wskClient.ErrorReceived, wskClients.ErrorReceived, wskListen.ErrorReceived
        Dim name As String = ""
        If sender Is wskListen Then name = "wskListen"
        If sender Is wskClients Then name = "wskServer"
        If sender Is wskClient Then name = "wskClient"
        Dim msg As String = name & " - " & e.Function & "(" & e.ErrorCode.ToString & "): " & e.Message & vbCrLf & e.Details
        Log(msg)
        RaiseEvent ErrorReceived(sender, e)
    End Sub

    Private Sub wsk_StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs) Handles wskClient.StateChanged, wskListen.StateChanged, wskClients.StateChanged
        Dim name As String = ""
        If sender Is wskListen Then name = trans("Прослушка")
        If sender Is wskClient Then name = trans("Клиент")
        If name = "" Then name = trans("Сервер")
        Dim msg As String = name & ". " & trans("Статус соединения") & ": " _
                            & trans(e.New_State.ToString, , True)
        Select Case name
            Case trans("Прослушка")
                If wskListen.Protocol = WinsockProtocol.Tcp Then
                    Select Case wskListen.State
                        Case WinsockStates.Listening
                            cmdCreateConn.Enabled = False
                            cmdClose.Enabled = True
                            ComboType.Enabled = False
                        Case Else
                            cmdCreateConn.Enabled = True
                    End Select
                End If
                Log(msg)
            Case trans("Сервер")
                If wskListen.Protocol = WinsockProtocol.Tcp Then
                    Select Case sender.State
                        Case WinsockStates.Closed, WinsockStates.Closing
                            cmdClose.Enabled = False
                            ComboType.Enabled = True
                        Case Else
                            cmdClose.Enabled = True
                    End Select
                Else
                    Select Case sender.State
                        Case WinsockStates.Listening
                            cmdClose.Enabled = True
                        Case Else
                            cmdClose.Enabled = False
                    End Select
                End If
                Log(msg)
            Case trans("Клиент")
                If wskClient.Protocol = WinsockProtocol.Tcp Then
                    Select Case wskClient.State
                        Case WinsockStates.Closed
                            cmdCreateConn.Enabled = True
                            ComboType.Enabled = True
                            cmdClose.Enabled = False
                        Case WinsockStates.Closing
                            cmdCreateConn.Enabled = False
                            ComboType.Enabled = False
                            cmdClose.Enabled = False
                        Case Else
                            cmdCreateConn.Enabled = False
                            ComboType.Enabled = False
                            cmdClose.Enabled = True
                    End Select
                End If
                Log(msg)
        End Select
        HideSendingFiles = HideSendingFiles
        HideSendingText = HideSendingText
        HideComboBox = HideComboBox
        RaiseEvent StateChanged(sender, e)
    End Sub

    Private Sub wskCountChanged(ByVal sender As Object, ByVal e As WinsockCollectionCountChangedEventArgs) Handles wskClients.CountChanged
        Log(String.Format(trans("Клиентов") & ": {0}    ", e.NewCount))
        SendToClients(CommandSymbol & "Names" & Spl(0) & ClientsNames)
        SendToClients(CommandSymbol & "IPs" & Spl(0) & ClientsIPs)
        RaiseEvent CountChanged(sender, e)
    End Sub

    Private Sub wskListener_ConnectionRequest(ByVal sender As System.Object, ByVal e As WinsockConnectionRequestEventArgs) Handles wskClients.ConnectionRequest
        Dim gid As String = wskClients.Accept(e.Client)
        Log(trans("Новый клиент") & ": " & gid.ToString)
    End Sub

    Private Sub wskServer_SendProgress(ByVal sender As System.Object, ByVal e As WinsockSendEventArgs) Handles wskClients.SendProgress, wskClient.SendProgress
        If e.BytesTotal < 0 Then Exit Sub
        pbServer.Maximum = e.BytesTotal
        pbServer.Value = e.BytesSent
        RaiseEvent SendProgress(sender, e)
    End Sub

    Private Sub wskServer_SendComplete(ByVal sender As System.Object, ByVal e As WinsockSendEventArgs) Handles wskClients.SendComplete, wskClient.SendComplete
        If e.BytesTotal < 0 Then Exit Sub
        pbServer.Maximum = e.BytesTotal
        pbServer.Value = e.BytesSent
        If FileIsSent Then
            If TypeServer <> "Server" And FileAction <> "" Then SendToServer(FileAction)
            FileIsSent = False
            RaiseEvent SendFileComplete(sender, e)
        Else
            RaiseEvent SendTextComplete(sender, e)
        End If
    End Sub

    Private Sub wskServer_ReceiveProgress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs) Handles wskClient.ReceiveProgress
        If e.BytesTotal < 0 Then Exit Sub
        pbServer.Maximum = e.BytesTotal
        pbServer.Value = e.BytesReceived
        RaiseEvent ReceiveProgress(sender, e)
    End Sub

#End Region

#Region " Methods "

    Function ConvertToNames(ByVal str As String)
        Dim i As Integer, strs() As String = str.Split(",")
        For i = 0 To strs.Length - 1
            If IsNumeric(strs(i)) Then
                If wskClients.Count > strs(i) Then strs(i) = wskClients.findKey(wskClients.Item(CType(strs(i), Integer)))
            ElseIf wskClients.Item(strs(i)) Is Nothing Then
                strs(i) = UbratKovich(strs(i).Trim).str
            End If
        Next
        Return Join(strs, ",")
    End Function

    Public Sub SendToServer(ByVal msg As String)
        Log(trans("Отправлен серверу текст") & " """ & msg & """")
        SentCommand = msg
        wskClient.Send(msg)
    End Sub
    Public Sub SendFileToServer(ByVal file As String)
        Log(trans("Отправлен серверу файл") & " """ & file & """")
        SentFile = file
        wskClient.SendFile(file)
        FileIsSent = True : FileAction = ""
    End Sub

    Public Sub SendToClients(ByVal msg As String)
        Log(trans("Отправлен клиентам текст") & " """ & msg & """")
        If TypeServer = "Server" Then
            Dim i As Integer
            For i = 0 To wskClients.Count - 1
                If wskClients.Item(i).State = WinsockStates.Connected Then
                    SentCommand = msg
                    wskClients.Item(i).Send(msg)
                End If
            Next
        Else
            SendToServer(CommandSymbol & "AllFrom" & Spl(0) & NameInNetwork & Spl(0) & msg.Trim())
        End If
    End Sub
    Public Sub SendToClientsBut(ByVal but As String, ByVal msg As String)
        Log(trans("Отправлен клиентам, кроме *, текст").Replace("*", but) & " """ & msg & """")
        but = ConvertToNames(but)
        If TypeServer = "Server" Then
            For Each cl As Object In wskClients.Keys
                If Array.IndexOf(but.Split(","), cl) = -1 AndAlso wskClients.Item(cl).State = WinsockStates.Connected Then
                    SentCommand = msg
                    wskClients.Item(cl).Send(msg)
                End If
            Next
        Else
            SendToServer(CommandSymbol & "AllFrom" & Spl(0) & NameInNetwork & "," & but & Spl(0) & msg.Trim())
        End If
    End Sub
    Public Sub SendToClient(ByVal uid As String, ByVal msg As String)
        Log(trans("Отправлен клиенту *, текст").Replace("*", uid) & " """ & msg & """")
        uid = ConvertToNames(uid)
        If TypeServer = "Server" Then
            For Each cl As Object In wskClients.Keys
                If Array.IndexOf(uid.Split(","), cl) <> -1 AndAlso wskClients.Item(cl).State = WinsockStates.Connected Then
                    SentCommand = msg
                    wskClients.Item(cl).Send(msg)
                End If
            Next
        Else
            SendToServer(CommandSymbol & "To" & Spl(0) & uid & Spl(0) & msg.Trim())
        End If
    End Sub
    Public Sub SendFileToClients(ByVal msg As String)
        Log(trans("Отправлен клиентам файл") & " """ & msg & """")
        If TypeServer = "Server" Then
            Dim i As Integer
            For i = 0 To wskClients.Count - 1
                If wskClients.Item(i).State = WinsockStates.Connected Then
                    SentFile = msg
                    wskClients.Item(i).SendFile(msg)
                End If
            Next
        Else
            FileAction = CommandSymbol & "AllFileFrom" & Spl(0) & NameInNetwork
            SentFile = msg
            wskClient.SendFile(msg)
        End If
        FileIsSent = True
    End Sub
    Public Sub SendFileToClientsBut(ByVal but As String, ByVal msg As String)
        Log(trans("Отправлен клиентам, кроме *, файл").Replace("*", but) & " """ & msg & """")
        but = ConvertToNames(but)
        If TypeServer = "Server" Then
            For Each cl As Object In wskClients.Keys
                If Array.IndexOf(but.Split(","), cl) = -1 AndAlso wskClients.Item(cl).State = WinsockStates.Connected Then
                    SentFile = msg
                    wskClients.Item(cl).SendFile(msg)
                End If
            Next
        Else
            FileAction = CommandSymbol & "AllFileFrom" & Spl(0) & NameInNetwork & "," & but
            SentFile = msg
            wskClient.SendFile(msg)
        End If
        FileIsSent = True
    End Sub
    Public Sub SendFileToClient(ByVal uid As String, ByVal msg As String)
        Log(trans("Отправлен клиенту *, файл").Replace("*", uid) & " """ & msg & """")
        uid = ConvertToNames(uid)
        If TypeServer = "Server" Then
            For Each cl As Object In wskClients.Keys
                If Array.IndexOf(uid.Split(","), cl) <> -1 AndAlso wskClients.Item(cl).State = WinsockStates.Connected Then
                    SentFile = msg
                    wskClients.Item(cl).SendFile(msg)
                End If
            Next
        Else
            FileAction = CommandSymbol & "FileTo" & Spl(0) & uid
            SentFile = msg
            wskClient.SendFile(msg)
        End If
        FileIsSent = True
    End Sub

    Delegate Sub dLogger(ByVal str As String)
    Public Sub Log(ByVal str As String)
        If txtLog.InvokeRequired Then
            Dim d As New dLogger(AddressOf Log)
            txtLog.Invoke(d, New Object() {str})
        Else
            txtLog.AppendText(str & vbCrLf)
            txtLog.Select(txtLog.TextLength - 1, 0)
            txtLog.ScrollToCaret()
        End If
    End Sub

    Public Sub ConnectToServer()
        RemoteHost = RemoteHost
        RemotePort = RemotePort
        Log(trans("Соединяемся") & " (" & wskClient.RemoteHost & ")...")
        wskClient.Connect()
        cmdClose.Text = trans("Отключиться")
    End Sub
    Public Sub CreateServer()
        wskListen.Listen()
        cmdClose.Text = trans("Стоп поиск")
    End Sub
    Public Sub BeginListen()
        wskListen.Listen()
        cmdClose.Text = trans("Стоп поиск")
    End Sub
    Public Sub CloseServer()
        CloseListener()
        wskClients.Clear()
        cmdClose.Text = trans("Стоп поиск")
        cmdCreateConn.Text = trans("Создать")
        cmdClose.Enabled = False
        ComboType.Enabled = True
    End Sub
    Public Sub CloseListener()
        wskListen.Close()
        cmdClose.Text = trans("Стоп сервер")
        cmdCreateConn.Text = trans("Слушать")
    End Sub
    Public Sub CloseClient()
        wskClient.Close()
    End Sub

    Dim zhdemImya As Boolean
    Public Function RunCommand(ByVal str As String, Optional ByVal onlyRetTxt As Boolean = False)
        If str IsNot Nothing AndAlso str.IndexOf(CommandSymbol) = 0 Then
            Dim cmd As String = str
            str = str.Substring(CommandSymbol.Length)
            Dim Spls() As String = str.Split(Spl, StringSplitOptions.None)
            ' Если клиент передал команду - ОТПРАВИТЬ ВСЕМ кроме меня и/или еще кого-то
            If Spls(0) = "AllFrom" Then
                If Spls.Length > 1 Then
                    Dim startStr As Integer = "AllFrom".Length + Spls(1).Length + Spl(0).Length * 2
                    If onlyRetTxt Then Return str.Substring(startStr).Trim ' Если надо только узнать текст в команде
                    SendToClientsBut(Spls(1), str.Substring(startStr).Trim)
                End If
                ' Если клиент передал команду - ОТПРАВИТЬ ВСЕМ ФАЙЛ кроме меня и/или еще кого-то
            ElseIf Spls(0) = "AllFileFrom" Then
                If onlyRetTxt Then Return "" ' Если надо только узнать текст в команде
                If Spls.Length > 1 Then
                    ' Если сейчас открыто окно сохранения файла (т.е. файл еще не сохранили, а уже хотит отправить)
                    If SavingFile = True Then
                        SavingFileTo = CommandSymbol & str
                    Else
                        SendFileToClientsBut(Spls(1), ReceivedFile)
                    End If
                End If
                ' Если клиент передал команду - ОТПРАВИТЬ кому-то
            ElseIf Spls(0) = "To" Then
                If Spls.Length > 1 Then
                    Dim startStr As Integer = "To".Length + Spls(1).Length + Spl(0).Length * 2
                    If onlyRetTxt Then Return str.Substring(startStr).Trim ' Если надо только узнать текст в команде
                    SendToClient(Spls(1), str.Substring(startStr).Trim)
                End If
                ' Если клиент передал команду - ОТПРАВИТЬ ФАЙЛ кому-то
            ElseIf Spls(0) = "FileTo" Then
                If onlyRetTxt Then Return "" ' Если надо только узнать текст в команде
                If Spls.Length > 1 Then
                    ' Если сейчас открыто окно сохранения файла (т.е. файл еще не сохранили, а уже хотит отправить)
                    If SavingFile = True Then
                        SavingFileTo = CommandSymbol & str
                    Else
                        SendFileToClient(Spls(1), ReceivedFile)
                    End If
                End If
                ' Если клиенту отправили его ИМЯ
            ElseIf Spls(0) = "Name" Then
                If onlyRetTxt Then Return "" ' Если надо только узнать текст в команде
                If Spls.Length > 1 Then
                    If onlyRetTxt Then Exit Function ' Если надо только узнать текст в команде
                    If ClSrName = "" Or zhdemImya Then
                        zhdemImya = False
                        ClSrName = str.Substring("Name".Length + Spl(0).Length).Trim ' Задаем имя через закрытую переменную
                        ' Если токо подключились, то вывести соответствующее событие
                        If ConnSender IsNot Nothing Then
                            RaiseEvent ConnectedToServer(ConnSender, ConnE)
                            ConnSender = Nothing : ConnE = Nothing
                        End If
                    Else
                        zhdemImya = True
                        ' Симулируем переименование
                        Dim tmp As String = ClSrName
                        ClSrName = str.Substring("Name".Length + Spl(0).Length).Trim
                        NameInNetwork = tmp
                    End If
                End If
                ' Если клиенту отправили ВСЕ ИМЕНА
            ElseIf Spls(0) = "Names" Then
                If onlyRetTxt Then Return "" ' Если надо только узнать текст в команде
                If Spls.Length > 1 Then
                    ClientsNames = str.Substring("Names".Length + Spl(0).Length).Trim
                End If
                ' Если клиенту отправили ВСЕ ИМЕНА
            ElseIf Spls(0) = "IPs" Then
                If onlyRetTxt Then Return "" ' Если надо только узнать текст в команде
                If Spls.Length > 1 Then
                    ClientsIPs = str.Substring("IPs".Length + Spl(0).Length).Trim
                End If
                ' Если клиент захотел ПЕРЕИМЕНОВАТЬСЯ
            ElseIf Spls(0) = "Rename" Then
                If onlyRetTxt Then Return "" ' Если надо только узнать текст в команде
                If Spls.Length > 1 Then
                    Dim namOld As String = Spls(1).Split(",")(0)
                    Dim namNew As String = Spls(1).Split(",")(1)
                    Dim nams() As String = ClientsNames.Split(",")
                    Dim ind As Integer = Array.IndexOf(nams, namOld)
                    Dim indNew As Integer = Array.IndexOf(nams, namNew)
                    If ind <> -1 And indNew = -1 Then
                        ' меняем имя в коллекции сокетов
                        wskClients.ChangeKey(namOld, namNew)
                        ' меняем имя в свойствах
                        nams(ind) = namNew
                        ' отправить изменения
                        SendToClient(namNew, CommandSymbol & "Name" & Spl(0) & namNew)
                        SendToClients(CommandSymbol & "Names" & Spl(0) & ClientsNames)
                        SendToClients(CommandSymbol & "IPs" & Spl(0) & ClientsIPs)
                        ' Если сменили имя, то вызвать событие CountChanged
                        RaiseEvent CountChanged(wskClients(namNew), New WinsockCollectionCountChangedEventArgs(wskClients.Count, wskClients.Count))
                    End If
                End If
            End If
            If onlyRetTxt Then Return "" ' Если надо только узнать текст в команде
            ReceivCmd = cmd
            RaiseEvent CommandReceived(Nothing, Nothing)
        Else
            If onlyRetTxt Then Return str ' Если надо только узнать текст в команде
            RaiseEvent TextReceived(Nothing, Nothing)
        End If
        If onlyRetTxt Then Return ""
    End Function

#End Region

#Region " Properties "
    Dim FileAction As String
    Dim FileIsSentPrivate As Boolean = False
    Public Property FileIsSent() As Boolean
        Get
            Return FileIsSentPrivate
        End Get
        Set(ByVal value As Boolean)
            FileIsSentPrivate = value
            If value = False Then FileAction = ""
        End Set
    End Property
    Dim ComSymb As String = "~~"
    Dim Spl() As String = {" ~~ "}
    Public Property CommandSymbol() As String
        Get
            Return ComSymb
        End Get
        Set(ByVal value As String)
            ComSymb = value
            Spl(0) = " " & value & " "
        End Set
    End Property
    Dim ReceivCmd As String
    Public Property ReceivedCommand() As String
        Get
            Return ReceivCmd
        End Get
        Set(ByVal value As String)
            ReceivCmd = value
        End Set
    End Property
    Dim ReceivStr As String
    Public Property ReceivedText() As String
        Get
            Return ReceivStr
        End Get
        Set(ByVal value As String)
            ReceivStr = value
        End Set
    End Property
    Dim ReceivFl As String
    Public Property ReceivedFile() As String
        Get
            Return ReceivFl
        End Get
        Set(ByVal value As String)
            ReceivFl = value
        End Set
    End Property
    Dim SentCmd As String
    Public Property SentCommand() As String
        Get
            Return SentCmd
        End Get
        Set(ByVal value As String)
            SentCmd = value
        End Set
    End Property
    Dim SentStr As String
    Public Property SentText() As String
        Get
            SentStr = RunCommand(SentCommand, True)
            Return SentStr
        End Get
        Set(ByVal value As String)
            SentStr = value
        End Set
    End Property
    Dim SentFl As String
    Public Property SentFile() As String
        Get
            Return SentFl
        End Get
        Set(ByVal value As String)
            SentFl = value
        End Set
    End Property
    Dim ClSrName As String = ""
    Public Property NameInNetwork() As String
        Get
            Return ClSrName
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                ' Проверки на корректность имени
                If Array.IndexOf(ClientsNames.Split(","), value) <> -1 Then
                    zhdemImya = False
                    Throw New Exception(Errors.NameExist(value))
                ElseIf IsNumeric(value) Then
                    zhdemImya = False
                    Throw New Exception(trans("Имя не может состоять только из цифр") & " " & value)
                ElseIf value.IndexOf(CommandSymbol) <> -1 Then
                    zhdemImya = False
                    Throw New Exception(trans("Имя не может содержать") & " " & CommandSymbol)
                ElseIf value.IndexOf(",") <> -1 Then
                    zhdemImya = False
                    Throw New Exception(trans("Имя не может содержать") & " "",""")
                End If
                ' Если надо переименовать везде в сети 
                If (value <> NameInNetwork And ClientsNames <> "") Or zhdemImya Then
                    SendToServer(CommandSymbol & "Rename" & Spl(0) & ClSrName & "," & value)
                End If
            End If
            ClSrName = value
        End Set
    End Property
    Dim iptocon As String = "127.0.0.1"
    Public Property RemoteHost() As String
        Get
            Return iptocon
        End Get
        Set(ByVal value As String)
            iptocon = value
            If wskClient.State = WinsockStates.Closed Then wskClient.RemoteHost = value
        End Set
    End Property
    Dim portConnect As String = "8080"
    Public Property RemotePort() As String
        Get
            Return portConnect
        End Get
        Set(ByVal value As String)
            portConnect = value
            If wskClient.State = WinsockStates.Closed Then
                wskClient.RemotePort = value
                wskListen.LocalPort = value
            End If
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
    Dim TypeServer As String = "Server"
    Public Property ClientServerType() As String
        Get
            If TypeServer = "Server" Or TypeServer = "" Then
                TypeServer = "Server"
                Return trans("Сервер")
            Else
                TypeServer = "Client"
                Return trans("Клиент")
            End If
            Return ComboType.SelectedItem
        End Get
        Set(ByVal value As String)
            If value.ToUpper = trans("Сервер").ToUpper Or value = "" Then
                TypeServer = "Server"
                ComboType.SelectedItem = trans("Сервер")
            Else
                TypeServer = "Client"
                ComboType.SelectedItem = trans("Клиент")
            End If
        End Set
    End Property
    Dim HideFls As Boolean = False
    Public Property HideSendingFiles() As Boolean
        Get
            Return HideFls
        End Get
        Set(ByVal value As Boolean)
            HideFls = value
            If HideFls Or (wskClients.Count = 0 And wskClient.State <> WinsockStates.Connected) Then
                cmdSendFile.Enabled = False
            Else
                cmdSendFile.Enabled = True
            End If
        End Set
    End Property
    Dim HideTxt As Boolean = False
    Public Property HideSendingText() As Boolean
        Get
            Return HideTxt
        End Get
        Set(ByVal value As Boolean)
            HideTxt = value
            If HideTxt Or (wskClients.Count = 0 And wskClient.State <> WinsockStates.Connected) Then
                cmdSendText.Enabled = False
                txtSend.Enabled = False
            Else
                cmdSendText.Enabled = True
                txtSend.Enabled = True
            End If
        End Set
    End Property
    Dim HideCB As Boolean = False
    Public Property HideComboBox() As Boolean
        Get
            Return HideCB
        End Get
        Set(ByVal value As Boolean)
            HideCB = value
            If HideCB Then
                ComboType.Enabled = False
            Else
                ComboType.Enabled = True
            End If
        End Set
    End Property
    Dim nms As String = ""
    Public Property ClientsNames() As String
        Get
            If TypeServer = "Server" And wskClients.Keys.Count > 0 Then
                Dim arr(wskClients.Keys.Count - 1) As String
                wskClients.Keys.CopyTo(arr, 0)
                Return Join(arr, ",")
            Else
                Return nms
            End If
        End Get
        Set(ByVal value As String)
            If TypeServer <> "Server" And nms <> value Then
                If nms = Nothing Then nms = ""
                If value = Nothing Then value = ""
                Dim nmsCount As Integer = nms.Split(",").Length
                Dim valsCount As Integer = value.Split(",").Length
                nms = value
                RaiseEvent CountChanged(wskClient, New WinsockCollectionCountChangedEventArgs(nmsCount, valsCount))
            End If
        End Set
    End Property
    Public Property TextBoxString() As String
        Get
            Return txtSend.Text
        End Get
        Set(ByVal value As String)
            txtSend.Text = value
        End Set
    End Property
    Public Property TextBoxLog() As String
        Get
            Return txtLog.Text
        End Get
        Set(ByVal value As String)
            txtLog.Text = value
        End Set
    End Property
    Dim ips As String
    Public Property ClientsIPs() As String
        Get
            If TypeServer = "Server" And wskClients.Count > 0 Then
                Dim i As Integer, arr(wskClients.Count - 1) As String
                For i = 0 To wskClients.Count - 1
                    If wskClients.Item(i) IsNot Nothing Then
                        If wskClients.Item(i).LocalIP.Length > 1 Then
                            arr(i) = wskClients.Item(i).LocalIP(1)
                        ElseIf wskClients.Item(i).LocalIP.Length = 1 Then
                            arr(i) = wskClients.Item(i).LocalIP(0)
                        Else
                            arr(i) = 0
                        End If
                    Else
                        wskClients.RemoveAt(i)
                        i -= 1 : ReDim Preserve arr(arr.Length - 2)
                    End If
                Next
                Return Join(arr, ",")
            Else
                Return ips
            End If
        End Get
        Set(ByVal value As String)
            If TypeServer <> "Server" Then ips = value
        End Set
    End Property
    Public ReadOnly Property GetClientIp(ByVal uid As String) As String
        Get
            Dim nams As String = ClientsNames, ipas As String = ClientsIPs
            If nams = Nothing Then nams = ""
            If ipas = Nothing Then ipas = ""
            Dim ind As Integer = Array.IndexOf(ClientsNames.Split(","), uid)
            If ind <> -1 AndAlso ClientsIPs.Split(",").Length > ind Then
                Return ClientsIPs.Split(",")(ind)
            Else
                Return ""
            End If
        End Get
    End Property

#End Region

    'Private Sub wskClient_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles wskClient.Disposed
    '    sender.Close()
    'End Sub

    Private Sub ClientServerMy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wskClient.BufferSize = 100000
        wskListen.BufferSize = 100000
        ComboType.Items.Clear()
        ComboType.Items.Add(trans("Клиент"))
        ComboType.Items.Add(trans("Сервер"))
        ClientServerType = ClientServerType
        cmdSendText.Text = trans(cmdSendText.Text)
        cmdSendFile.Text = trans(cmdSendFile.Text)
        cmdCreateConn.Text = trans(cmdCreateConn.Text)
        cmdClose.Text = trans(cmdClose.Text)
    End Sub

    Private Sub ClientServerMy_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Me.Height < 40 Then
            cmdClose.Visible = False : cmdCreateConn.Visible = False : ComboType.Visible = False
        ElseIf Me.Height < 62 Then
            cmdClose.Visible = True : cmdCreateConn.Visible = True : ComboType.Visible = True
            txtSend.Visible = False : cmdSendFile.Visible = False : cmdSendText.Visible = False
        Else
            cmdClose.Visible = True : cmdCreateConn.Visible = True : ComboType.Visible = True
            txtSend.Visible = True : cmdSendFile.Visible = True : cmdSendText.Visible = True
        End If
    End Sub
End Class
