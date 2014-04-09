Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

''' <summary>
''' A class that encapsulates all the raw functions of the System.Net.Sockets.Socket
''' </summary>
Public Class AsyncSocket

    Private myParent As IWinsock '                 The parent Winsock - allows access to properties and event raising
    Private mSock1 As Socket '                     for IPv4 (listening) or both IPv4 and IPv6 (connections)
    Private mSock2 As Socket '                     for IPv6 (listening) only
    Private byteBuffer() As Byte '                 Stores the incoming bytes waiting to be processed
    Private incBufferSize As Integer = 100000 '      The buffer size of the socket
    Private _buff As ByteBufferCol '               Temporary byte buffer - used while an object is being assembled
    Private _closing As Boolean = False '          Prevents the Close() method from being run while it already running
    Private qBuffer As Queue '                     The Buffer Queue - where objects wait to be picked up by the Get() method
    Private phProcessor As PacketHeader '          The PacketHeader processor - looks for and reads the packet header added to the byte array
    Private sBufferMutex As New Mutex()
    Private sendBuffer As Deque '                  The Sending Buffer Queue - where objects wait to be sent.
    Private thdSendLoop As Thread '                Used to send everything in the sendBuffer
    Private lckSendLoop As Object '                Used for a syncronized lock on the SendLoop thread
    Private bIsSending As Boolean '                Used internally to tell if a sending loop is in progress.
    Public StopSendFile As Boolean = False

    Public Sub New(ByRef parent As IWinsock)
        Try
            myParent = parent
            phProcessor = New PacketHeader
            qBuffer = New Queue
            _buff = New ByteBufferCol
            sendBuffer = New Deque
            lckSendLoop = New Object()
            ReDim byteBuffer(incBufferSize)
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, "Unable to initialize the AsyncSocket.")
        End Try
    End Sub

    ''' <summary>
    ''' Gets a value containing the remote IP address.
    ''' </summary>
    Protected Friend ReadOnly Property RemoteIP() As String
        Get
            Dim rEP As System.Net.IPEndPoint = CType(mSock1.RemoteEndPoint, System.Net.IPEndPoint)
            Return rEP.Address.ToString()
        End Get
    End Property

    ''' <summary>
    ''' Gets a value containing the remote port number.
    ''' </summary>
    Protected Friend ReadOnly Property RemotePort() As Integer
        Get
            Dim rEP As System.Net.IPEndPoint = CType(mSock1.RemoteEndPoint, System.Net.IPEndPoint)
            Return rEP.Port
        End Get
    End Property

    ''' <summary>
    ''' Gets a value containing the local port number.
    ''' </summary>
    Protected Friend ReadOnly Property LocalPort() As Integer
        Get
            Dim lEP As System.Net.IPEndPoint = CType(mSock1.LocalEndPoint, IPEndPoint)
            Return lEP.Port
        End Get
    End Property

    Protected Friend ReadOnly Property BufferCount() As Integer
        Get
            Return qBuffer.Count
        End Get
    End Property

    Protected Friend Property BufferSize() As Integer
        Get
            Return incBufferSize
        End Get
        Set(ByVal value As Integer)
            incBufferSize = value
        End Set
    End Property

    Protected Friend ReadOnly Property UnderlyingStream() As Net.Sockets.NetworkStream
        Get
            If mSock1 IsNot Nothing Then Return New Net.Sockets.NetworkStream(mSock1, IO.FileAccess.ReadWrite, False)
            Return Nothing
        End Get
    End Property

#Region " Public Methods "

    ''' <summary>
    ''' Accepts an incoming connection and starts the data listener.
    ''' </summary>
    ''' <param name="client">The client to accept.</param>
    Public Function Accept(ByVal client As Socket) As Boolean
        Try
            If myParent.State <> WinsockStates.Closed Then
                Throw New Exception("Cannot accept a connection while the State is not closed.")
            End If
            mSock1 = client
            Receive()
            myParent.ChangeState(WinsockStates.Connected)
            Dim e As New WinsockConnectedEventArgs(CType(mSock1.RemoteEndPoint, System.Net.IPEndPoint).Address.ToString, CType(mSock1.RemoteEndPoint, System.Net.IPEndPoint).Port)
            myParent.OnConnected(e)
            Return True
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Closes the socket if its already open or listening.
    ''' </summary>
    Public Sub Close()
        Try
            ' If we are already closing then exit the subroutine
            If _closing Then Exit Sub
            ' Set the closing flag so that this doesn't get run more than once
            '  at a time.
            _closing = True
            ' If we are already closed - exit the subroutine
            If myParent.State = WinsockStates.Closed Then _closing = False : Exit Sub
            Dim bAllowDisconnect As Boolean = False
            ' Close the Socket(s) as necessary
            Select Case myParent.State
                Case WinsockStates.Connected
                    ' Change the state to Closing
                    myParent.ChangeState(WinsockStates.Closing)
                    If mSock1 IsNot Nothing Then mSock1.Close()
                    ' Allow disconnect event to raise
                    bAllowDisconnect = True
                Case WinsockStates.Listening
                    ' Change the state to Closing
                    myParent.ChangeState(WinsockStates.Closing)
                    If mSock1 IsNot Nothing Then mSock1.Close()
                    If mSock2 IsNot Nothing Then mSock2.Close()
                    ' Do not allow Disconnect event - we weren't connected to anything
                    '  only listening.
                    bAllowDisconnect = False
            End Select
            ' Change state to Closed
            myParent.ChangeState(WinsockStates.Closed)
            ' Raise the Disconnected event - if allowed to
            If bAllowDisconnect Then myParent.OnDisconnected()
            _closing = False
        Catch ex As Exception
            _closing = False
            If ex.InnerException IsNot Nothing Then
                SharedMethods.RaiseError(myParent, ex.Message, ex.InnerException.Message)
            Else
                SharedMethods.RaiseError(myParent, ex.Message)
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Starts Listening for incoming connections.  For UDP sockets it starts listening for incoming data.
    ''' </summary>
    ''' <param name="port">The port to start listening on.</param>
    ''' <param name="max_pending">The maximum length of the pending connections queue.</param>
    Public Sub Listen(ByVal port As Integer, ByVal max_pending As Integer)
        Try
            If myParent.Protocol = WinsockProtocol.Tcp Then
                Dim blnChangePort As Boolean = False
                ' Start listening on IPv4 - if available
                If Socket.SupportsIPv4 Then
                    mSock1 = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    Dim ipLocal As New IPEndPoint(IPAddress.Any, port)
                    mSock1.Bind(ipLocal)
                    mSock1.Listen(max_pending)
                    mSock1.BeginAccept(New AsyncCallback(AddressOf ListenCallback), mSock1)
                End If
                ' if port was 0 find port used for IPv4 and use it for IPv6
                If port = 0 Then
                    Dim lEP As System.Net.IPEndPoint = CType(mSock1.LocalEndPoint, IPEndPoint)
                    port = lEP.Port
                    blnChangePort = True
                End If
                ' Start listening on IPv6 - if available
                If Socket.OSSupportsIPv6 Then
                    mSock2 = New Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp)
                    Dim ipLocal As New IPEndPoint(IPAddress.IPv6Any, port)
                    mSock2.Bind(ipLocal)
                    mSock2.Listen(max_pending)
                    mSock2.BeginAccept(New AsyncCallback(AddressOf ListenCallback), mSock2)
                End If
                If blnChangePort Then
                    myParent.ChangeLocalPort(port)
                End If
                ' Change state to Listening
                myParent.ChangeState(WinsockStates.Listening)
            ElseIf myParent.Protocol = WinsockProtocol.Udp Then
                If port <= 0 Then
                    Throw New ArgumentException("While port 0 works for getting random port for UPD, there is no way for the server operator to know the port used until a completed send/receive method call is used which means the port is known already.", "port")
                End If
                ' Start data listening on IPv4 - if available
                If Socket.SupportsIPv4 Then
                    mSock1 = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)

                    Dim ipLocal As New IPEndPoint(IPAddress.Any, port)
                    Dim ipeSender As New IPEndPoint(IPAddress.Any, 0)

                    Dim xe As New UdpReceiveState()
                    xe.SendingSocket = mSock1
                    xe.ReceivingEndpoint = ipeSender

                    mSock1.Bind(ipLocal)
                    mSock1.BeginReceiveFrom(byteBuffer, 0, incBufferSize, SocketFlags.None, xe.ReceivingEndpoint, New AsyncCallback(AddressOf ReceiveCallbackUDP), xe)
                End If
                ' Start data listening on IPv6 - if available
                If Socket.OSSupportsIPv6 Then
                    mSock2 = New Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp)

                    Dim ipLocal As New IPEndPoint(IPAddress.IPv6Any, port)
                    Dim ipeSender As New IPEndPoint(IPAddress.IPv6Any, 0)

                    Dim xe As New UdpReceiveState()
                    xe.SendingSocket = mSock2
                    xe.ReceivingEndpoint = ipeSender

                    mSock2.Bind(ipLocal)
                    mSock2.BeginReceiveFrom(byteBuffer, 0, incBufferSize, SocketFlags.None, xe.ReceivingEndpoint, New AsyncCallback(AddressOf ReceiveCallbackUDP), xe)
                End If
                myParent.ChangeState(WinsockStates.Listening)
            End If
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Starts Listening for incoming connections on the specified IP address.  For UDP sockets it starts listening for incoming data.
    ''' </summary>
    ''' <param name="port">The port to start listening on.</param>
    ''' <param name="max_pending">The maximum length of the pending connections queue.</param>
    ''' <param name="ip">The IP address on which to listen.</param>
    Public Sub Listen(ByVal port As Integer, ByVal max_pending As Integer, ByVal ip As IPAddress)
        Try
            ' IP contains information on type (IPv4 vs. IPv6) so we can just work with that
            If myParent.Protocol = WinsockProtocol.Tcp Then
                mSock1 = New Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                Dim ipLocal As New IPEndPoint(ip, port)
                mSock1.Bind(ipLocal)
                mSock1.Listen(max_pending)
                mSock1.BeginAccept(New AsyncCallback(AddressOf ListenCallback), mSock1)
                If port = 0 Then
                    Dim lEP As System.Net.IPEndPoint = CType(mSock1.LocalEndPoint, IPEndPoint)
                    myParent.ChangeLocalPort(lEP.Port)
                End If
            ElseIf myParent.Protocol = WinsockProtocol.Udp Then
                If port <= 0 Then
                    Throw New ArgumentException("While port 0 works for getting random port for UPD, there is no way for the server operator to know the port used until a completed send/receive method call is used which means the port is known already.", "port")
                End If
                mSock1 = New Socket(ip.AddressFamily, SocketType.Dgram, ProtocolType.Udp)

                Dim ipLocal As New IPEndPoint(ip, port)
                Dim ipeSender As New IPEndPoint(ip, 0)

                Dim xe As New UdpReceiveState()
                xe.SendingSocket = mSock1
                xe.ReceivingEndpoint = ipeSender

                mSock1.Bind(ipLocal)
                mSock1.BeginReceiveFrom(byteBuffer, 0, incBufferSize, SocketFlags.None, xe.ReceivingEndpoint, New AsyncCallback(AddressOf ReceiveCallbackUDP), xe)
            End If
            myParent.ChangeState(WinsockStates.Listening)
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Gets the first object in the buffer without removing it.
    ''' </summary>
    Public Function PeekData() As Byte()
        If qBuffer.Count = 0 Then Return Nothing
        Return DirectCast(qBuffer.Peek(), Byte())
    End Function

    ''' <summary>
    ''' Gets and removes the first object in the buffer.
    ''' </summary>
    Public Function GetData() As Byte()
        If qBuffer.Count = 0 Then Return Nothing
        Return DirectCast(qBuffer.Dequeue, Byte())
    End Function

    ''' <summary>
    ''' Attemps to connect to a remote computer.
    ''' </summary>
    ''' <param name="remoteHostOrIp">The remote host or IP address of the remote computer.</param>
    ''' <param name="remote_port">The port number on which to connect to the remote computer.</param>
    Public Sub Connect(ByVal remoteHostOrIp As String, ByVal remote_port As Integer)
        Try
            If myParent.State <> WinsockStates.Closed Then
                Throw New Exception("Cannot connect to a remote host when the Winsock State is not closed.")
            End If

            myParent.ChangeState(WinsockStates.ResolvingHost)

            Dim resolvedIP As IPAddress = Nothing
            If IPAddress.TryParse(remoteHostOrIp, resolvedIP) Then
                myParent.ChangeState(WinsockStates.HostResolved)
                Connect(resolvedIP, remote_port)
            Else
                Dns.BeginGetHostEntry(remoteHostOrIp, New AsyncCallback(AddressOf DoConnectCallback), remote_port)
            End If
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Attempts to connect to a remote computer.
    ''' </summary>
    ''' <param name="remIP">The IP address of the remote computer.</param>
    ''' <param name="port">The port number on which to connect to the remote computer.</param>
    Public Sub Connect(ByVal remIP As IPAddress, ByVal port As Integer)
        Try
            Dim remEP As New IPEndPoint(remIP, port)
            If myParent.State <> WinsockStates.HostResolved Then Exit Sub
            mSock1 = New Socket(remIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            myParent.ChangeState(WinsockStates.Connecting)
            mSock1.BeginConnect(remEP, New AsyncCallback(AddressOf ConnectCallback), mSock1)
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message, ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Sends data to the remote computer.
    ''' </summary>
    ''' <param name="byt">The byte array of data to send.</param>
    Public Sub Send(ByVal byt() As Byte)
        Try
            StopSendFile = False
            ' If it's going out UDP, get the location it's going to
            Dim remEP As IPEndPoint = Nothing
            If myParent.Protocol = WinsockProtocol.Udp Then
                Dim ihe As IPHostEntry = Dns.GetHostEntry(myParent.RemoteHost)
                remEP = New IPEndPoint(ihe.AddressList(0), myParent.RemotePort)
            End If

            ' LegacySupport doesn't need a header, so if it's NOT active we can add one
            If Not myParent.LegacySupport Then
                ' LegacySupport INACTIVE - add a packet header, the other end knows how to decode it
                phProcessor.AddHeader(byt)
            End If

            ' Create the data object and add it to the queue
            Dim sqData As New SendQueueData(remEP, byt)
            ' We must lock access to the send buffer to prevent simultaneous access
            ' from multiple threads
            SyncLock sendBuffer.SyncRoot
                sendBuffer.Enqueue(sqData)
            End SyncLock

            ' Start the sending process - if the process isn't already started.
            SyncLock lckSendLoop
                If Not bIsSending Then
                    thdSendLoop = New Thread(AddressOf DoSend)
                    thdSendLoop.Start()
                End If
            End SyncLock
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

#End Region

#Region " Callback Methods "

    ''' <summary>
    ''' The callback for the listener - only used for a TCP listener.
    ''' </summary>
    ''' <remarks>This routine starts again when finished making it loop to continuously receive connections.</remarks>
    Private Sub ListenCallback(ByVal ar As IAsyncResult)
        Try
            ' Get the socket doing the listening, if it's not there
            ' we can't continue.
            Dim listener As Socket = TryCast(ar.AsyncState, Socket)
            If listener Is Nothing Then
                Throw New Exception("Listener object no longer exists.")
            End If

            ' End the Accept that was started
            Dim client As Socket = listener.EndAccept(ar)
            ' Raise ConnectionRequest event
            Dim e As New WinsockConnectionRequestEventArgs(client)
            myParent.OnConnectionRequest(e)

            ' If the Winsock is no longer in the listening state
            ' close and exit gracefully.
            If myParent.State <> WinsockStates.Listening Then
                listener.Close()
                Exit Sub
            End If
            ' start listening again
            listener.BeginAccept(New AsyncCallback(AddressOf ListenCallback), listener)
        Catch exO As ObjectDisposedException
            ' Close was called, destroying the object - exit without
            ' displaying an error.
            Exit Try
        Catch exS As SocketException
            ' There was a problem with the connection
            ' If the SocketError is not Success, then close and 
            ' show an error message
            Select Case exS.SocketErrorCode
                Case Is <> SocketError.Success
                    'Close()
                    SharedMethods.RaiseError(myParent, exS.Message, "", exS.SocketErrorCode)
                    Exit Try
            End Select
        Catch ex As Exception
            ' General execption - show an error message.
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' The callback method for the Receive method (UDP only) - used when there is incoming data.
    ''' </summary>
    Private Sub ReceiveCallbackUDP(ByVal ar As IAsyncResult)
        Try
            ' Get actively receiving socket and IPEndPoint
            Dim xe As UdpReceiveState = CType(ar.AsyncState, UdpReceiveState)
            Dim cb_UDP As Socket = CType(xe.SendingSocket, Socket)
            ' Get the size of the received data
            Dim iSize As Integer = cb_UDP.EndReceiveFrom(ar, xe.ReceivingEndpoint)
            Dim remEP As IPEndPoint = TryCast(xe.ReceivingEndpoint, IPEndPoint)
            If iSize < 1 Then
                If _buff.Count > 0 Then _buff.Clear()
                Close()
                Exit Sub
            End If
            ' Process the receieved data
            ProcessIncoming(byteBuffer, iSize, remEP.Address.ToString, remEP.Port)
            ' Clear and resize the buffer
            ReDim byteBuffer(incBufferSize)
            ' Restart data listener
            Dim ipeSender As IPEndPoint
            If remEP.AddressFamily = AddressFamily.InterNetwork Then
                ipeSender = New IPEndPoint(IPAddress.Any, 0)
            Else
                ipeSender = New IPEndPoint(IPAddress.IPv6Any, 0)
            End If
            xe.ReceivingEndpoint = ipeSender
            cb_UDP.BeginReceiveFrom(byteBuffer, 0, incBufferSize, SocketFlags.None, xe.ReceivingEndpoint, New AsyncCallback(AddressOf ReceiveCallbackUDP), xe)
        Catch exO As ObjectDisposedException
            ' Close was called, destroying the object - exit without
            ' displaying an error.
            Exit Try
        Catch exS As SocketException
            ' There was a problem with the connection
            ' If the SocketError is not Success, then close and 
            ' show an error message
            Select Case exS.SocketErrorCode
                Case Is <> SocketError.Success
                    'Close()
                    SharedMethods.RaiseError(myParent, exS.Message, "", exS.SocketErrorCode)
                    Exit Try
            End Select
        Catch ex As Exception
            ' General execption - show an error message.
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' The callback for the Connect method - used on the client to start looking for data.
    ''' </summary>
    Private Sub ConnectCallback(ByVal ar As IAsyncResult)
        Try
            If myParent.State <> WinsockStates.Connecting Then Exit Sub
            Dim sock As Socket = CType(ar.AsyncState, Socket)
            sock.EndConnect(ar)
            If myParent.State <> WinsockStates.Connecting Then sock.Close() : Exit Sub
            ' start listening for data
            Receive()
            ' Finished - raise events...
            myParent.ChangeState(WinsockStates.Connected)
            ' Raise the Connected event
            Dim ipE As IPEndPoint = DirectCast(sock.RemoteEndPoint, IPEndPoint)
            Dim e As New WinsockConnectedEventArgs(ipE.Address.ToString, ipE.Port)
            myParent.OnConnected(e)
        Catch exS As SocketException
            Select Case exS.SocketErrorCode
                Case Is <> SocketError.Success
                    Close()
                    SharedMethods.RaiseError(myParent, exS.Message, "", exS.SocketErrorCode)
                    Exit Try
            End Select
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' The callback method for the Receive method (TCP only) - used when there is incoming data.
    ''' </summary>
    Private Sub ReceiveCallback(ByVal ar As IAsyncResult)
        Try
            ' Get the possible error code
            Dim errCode As SocketError = CType(ar.AsyncState, SocketError)
            ' Get the size of the incoming data while ending the receive
            Dim iSize As Integer = mSock1.EndReceive(ar)
            If iSize < 1 Then
                ' no size identified - connection closed
                If _buff.Count > 0 Then _buff.Clear()
                Close()
                Exit Sub
            End If
            ' Get the remote IP address
            Dim ipE As IPEndPoint = CType(mSock1.RemoteEndPoint, IPEndPoint)
            ' Process the incoming data (also raises DataArrival)
            ProcessIncoming(byteBuffer, iSize, ipE.Address.ToString, ipE.Port)
            ReDim byteBuffer(incBufferSize)
            ' Start listening for data again
            mSock1.BeginReceive(byteBuffer, 0, incBufferSize, SocketFlags.None, errCode, New AsyncCallback(AddressOf ReceiveCallback), errCode)
        Catch exS As SocketException
            Select Case exS.SocketErrorCode
                Case Is <> SocketError.Success
                    Close()
                    SharedMethods.RaiseError(myParent, exS.Message, "", exS.SocketErrorCode)
            End Select
        Catch exO As ObjectDisposedException
            Exit Try
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' The callback method for the Send method (TCP only) - loops if not all the data was sent.
    ''' </summary>
    Private Sub SendCallback(ByVal ar As IAsyncResult)
        Try
            ' Retrieve the AsyncState
            Dim ssState As SendState = DirectCast(ar.AsyncState, SendState)
            ' Update the total sent - while ending this send call
            ssState.TotalSent += ssState.SendingSocket.EndSend(ar)
            ' Build the event args for the event that will be raised
            Dim e As New WinsockSendEventArgs(RemoteIP, ssState.TotalSent, ssState.Length)
            If ssState.SendCompleted Then
                ' Object finished sending - raise the SendComplete event
                myParent.OnSendComplete(e)
                ' Check for more items in the buffer - if so run the send again
                ' we can't run DoSend from within the SyncLock, or we'll run into
                ' a deadlock
                Dim blnRunAgain As Boolean = False
                SyncLock sendBuffer.SyncRoot
                    If sendBuffer.Count > 0 Then
                        blnRunAgain = True
                    End If
                End SyncLock
                If blnRunAgain Then DoSend()
            Else
                ' Raise SendProgress event
                myParent.OnSendProgress(e)
                ' Object still has more data in the buffer, get the next part and send it
                Dim byt() As Byte
                SyncLock sendBuffer.SyncRoot
                    Dim sqData As SendQueueData = sendBuffer.Dequeue(Of SendQueueData)()
                    byt = sqData.Data
                    If byt.GetUpperBound(0) > incBufferSize Then
                        Dim tmpByt() As Byte = SharedMethods.ShrinkArray(Of Byte)(byt, incBufferSize + 1)
                        sqData.Data = DirectCast(byt.Clone(), Byte())
                        sendBuffer.Push(sqData)
                        byt = DirectCast(tmpByt.Clone(), Byte())
                    End If
                End SyncLock
                ssState.SendingSocket.BeginSend(byt, 0, byt.Length, SocketFlags.None, ssState.ErrCode, New AsyncCallback(AddressOf SendCallback), ssState)
            End If
        Catch exS As SocketException
            Select Case exS.SocketErrorCode
                Case Is <> SocketError.Success
                    Close()
                    SharedMethods.RaiseError(myParent, exS.Message, "", exS.SocketErrorCode)
            End Select
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' The callback method for the Send method (UDP only) - loops if not all the data was sent.
    ''' </summary>
    Private Sub SendToCallback(ByVal ar As IAsyncResult)
        Try
            ' Retrieve the AsyncState
            Dim ssState As SendState = DirectCast(ar.AsyncState, SendState)
            ' Update the total sent - while ending this send call
            ssState.TotalSent += ssState.SendingSocket.EndSendTo(ar)
            ' Build the event args for the event that will be raised
            Dim e As New WinsockSendEventArgs(ssState.SendToAddress.Address.ToString(), ssState.TotalSent, ssState.Length)
            If ssState.SendCompleted Then
                ' Object finished sending - raise the SendComplete event
                myParent.OnSendComplete(e)
                ' Check for more items in the buffer - if so run the send again
                ' we can't run DoSend from within the SyncLock, or we'll run into
                ' a deadlock
                Dim blnRunAgain As Boolean = False
                SyncLock sendBuffer.SyncRoot
                    If sendBuffer.Count > 0 Then
                        blnRunAgain = True
                    End If
                End SyncLock
                If blnRunAgain Then DoSend()
            Else
                ' Raise the SendProgress event
                myParent.OnSendProgress(e)
                ' Object still has more data in the buffer, get it and send it.
                Dim byt() As Byte
                SyncLock sendBuffer.SyncRoot
                    Dim sqData As SendQueueData = sendBuffer.Dequeue(Of SendQueueData)()
                    byt = sqData.Data
                    If byt.GetUpperBound(0) > incBufferSize Then
                        Dim tmpByt() As Byte = SharedMethods.ShrinkArray(Of Byte)(byt, incBufferSize + 1)
                        sqData.Data = DirectCast(byt.Clone(), Byte())
                        sendBuffer.Push(sqData)
                        byt = DirectCast(tmpByt.Clone(), Byte())
                    End If
                End SyncLock
                ssState.SendingSocket.BeginSendTo(byt, 0, byt.Length, SocketFlags.None, ssState.SendToAddress, New AsyncCallback(AddressOf SendToCallback), ssState)
            End If
        Catch exS As SocketException
            Select Case exS.SocketErrorCode
                Case Is <> SocketError.Success
                    Close()
                    SharedMethods.RaiseError(myParent, exS.Message, "", exS.SocketErrorCode)
            End Select
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' The callback method for resolving the address given - starts the socket on connecting.
    ''' </summary>
    Public Sub DoConnectCallback(ByVal ar As IAsyncResult)
        Try
            Dim port As Integer = DirectCast(ar.AsyncState, Integer)
            Dim resolved As IPHostEntry
            Try
                resolved = Dns.EndGetHostEntry(ar)
            Catch ex As SocketException
                resolved = Nothing
            End Try
            If resolved Is Nothing OrElse resolved.AddressList.Length = 0 Then
                Dim name As String = CStr(IIf(resolved IsNot Nothing, """" & resolved.HostName & """ ", ""))
                Throw New Exception("Hostname " & name & "could not be resolved.")
            End If
            myParent.ChangeState(WinsockStates.HostResolved)
            Connect(resolved.AddressList(0), port)
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Processes raw data that was received from the socket and places it into the appropriate buffer.
    ''' </summary>
    ''' <param name="byt">The raw byte buffer containing the data received from the socket.</param>
    ''' <param name="iSize">The size of the data received from the socket (reported from the EndReceive).</param>
    ''' <param name="source_ip">The IP address the data came from, used for event raising.</param>
    ''' <param name="source_port">The Port the data arrived on, used for event raising.</param>
    Private Sub ProcessIncoming(ByVal byt() As Byte, ByVal iSize As Integer, ByVal source_ip As String, ByVal source_port As Integer)
        'check if we are using LegacySupport
        If myParent.LegacySupport Then
            ' legacy support is active just output the data to the buffer
            '  if we actually received some data
            If iSize > 0 Then
                ' yes we received some data - resize the array
                ResizeArray(byt, iSize)
                ' add the byte array to the buffer queue
                qBuffer.Enqueue(byt)
                ' raise the DataArrival event
                Dim e As New WinsockDataArrivalEventArgs(iSize, source_ip, source_port)
                myParent.OnDataArrival(e)
            End If
        Else
            ' legacy support is inactive
            ' if total size is <= 0 no data came in - exit
            If iSize <= 0 Then Exit Sub
            ' reduce the size of the array to the reported size (fixes trailling zeros)
            ResizeArray(byt, iSize)
            ' Do we have a packet header?
            If Not phProcessor.Completed And _buff.Count > 1 Then
                ' no packet header and already have more than enough data for a header
                ' most likely no header is coming - throw an error to use LegacySupport
                phProcessor.Reset()
                Throw New Exception("Unable to determine size of incoming packet.  It's possible you may need to use Legacy Support.")
            ElseIf Not phProcessor.Completed Then
                phProcessor.ProcessHeader(byt, _buff)
                If Not phProcessor.Completed Then
                    ProcessIncoming(byt, byt.Length, source_ip, source_port)
                End If
            End If


            ' Packet Header obtained... Process data, raise data arrival when all is received
            If _buff.Count = 0 AndAlso byt.Length >= phProcessor.Size Then
                ' everything is located in the byte array
                If byt.GetUpperBound(0) > phProcessor.Size Then
                    ' everything and MORE in byte array
                    '  remove our data, and run process again on the rest
                    Dim tmp() As Byte = SharedMethods.ShrinkArray(Of Byte)(byt, phProcessor.Size)
                    ' add the data to the queue
                    qBuffer.Enqueue(tmp)
                    ' reset the packet header processor
                    phProcessor.Reset()
                    ' raise the received progress event
                    Dim eR As New WinsockReceiveProgressEventArgs(source_ip, tmp.Length, phProcessor.Size)
                    myParent.OnReceiveProgress(eR)
                    ' raise the DataArrival event
                    Dim e As New WinsockDataArrivalEventArgs(tmp.Length, source_ip, source_port)
                    myParent.OnDataArrival(e)
                    ' process the extra data
                    ProcessIncoming(byt, byt.Length, source_ip, source_port)
                Else
                    ' add everything to the queue
                    qBuffer.Enqueue(byt)
                    ' raise the received progress event
                    Dim eR As New WinsockReceiveProgressEventArgs(source_ip, byt.Length, phProcessor.Size)
                    myParent.OnReceiveProgress(eR)
                    ' reset the packet header processor
                    phProcessor.Reset()
                    ' raise the DataArrival event
                    Dim e As New WinsockDataArrivalEventArgs(byt.Length, source_ip, source_port)
                    myParent.OnDataArrival(e)
                End If
            ElseIf _buff.Count > 0 AndAlso _buff.Combine().Length + byt.Length >= phProcessor.Size Then
                ' if you include the temp buffer, we have all the data
                ' get everything
                _buff.Add(byt)
                Dim tmp() As Byte = _buff.Combine()
                ' clear the temp buffer
                _buff.Clear()
                If tmp.GetUpperBound(0) > phProcessor.Size Then
                    ' tmp contains more than what we need
                    '  remove what wee need, and then run the process again on the rest
                    Dim t2() As Byte = SharedMethods.ShrinkArray(Of Byte)(tmp, phProcessor.Size)
                    ' add the data to the queue
                    qBuffer.Enqueue(t2)
                    ' raise the received progress event
                    Dim eR As New WinsockReceiveProgressEventArgs(source_ip, tmp.Length, phProcessor.Size)
                    myParent.OnReceiveProgress(eR)
                    ' reset the packet header processor
                    phProcessor.Reset()
                    ' raise the DataArrival event
                    Dim e As New WinsockDataArrivalEventArgs(tmp.Length, source_ip, source_port)
                    myParent.OnDataArrival(e)
                    ' process the extra data
                    ProcessIncoming(tmp, tmp.Length, source_ip, source_port)
                Else
                    ' tmp contains only what we need - add it to the queue
                    qBuffer.Enqueue(tmp)
                    ' raise the received progress event
                    Dim eR As New WinsockReceiveProgressEventArgs(source_ip, tmp.Length, phProcessor.Size)
                    myParent.OnReceiveProgress(eR)
                    ' reset the packet header processor
                    phProcessor.Reset()
                    ' raise the DataArrival event
                    Dim e As New WinsockDataArrivalEventArgs(tmp.Length, source_ip, source_port)
                    myParent.OnDataArrival(e)
                End If
            Else
                _buff.Add(byt)
                ' raise the received progress event
                Dim eR As New WinsockReceiveProgressEventArgs(source_ip, _buff.Combine.Length, phProcessor.Size)
                myParent.OnReceiveProgress(eR)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Resizes an array to the desired length - preserving the data at the begining of the array.
    ''' </summary>
    ''' <param name="byt">The array to be resized.</param>
    ''' <param name="iSize">The size to resize the array to.</param>
    Private Sub ResizeArray(ByRef byt() As Byte, ByVal iSize As Integer)
        If iSize - 1 < byt.GetUpperBound(0) Then
            ReDim Preserve byt(iSize - 1)
        End If
    End Sub

    ''' <summary>
    ''' Starts listening for incoming packets on the socket.
    ''' </summary>
    ''' <remarks>The is private because, the user should never have to call this.</remarks>
    Private Sub Receive()
        Try
            Dim errorState As SocketError
            mSock1.BeginReceive(byteBuffer, 0, incBufferSize, SocketFlags.None, errorState, New AsyncCallback(AddressOf ReceiveCallback), errorState)
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Starts the sending of an object in the send buffer.
    ''' </summary>
    Private Sub DoSend()
        Try
            ' Retrieve the bytes to send
            Dim byt() As Byte
            Dim fullSize As Integer
            Dim remEP As IPEndPoint
            SyncLock sendBuffer.SyncRoot
                If sendBuffer.Count = 0 Then Exit Sub
                Dim sqData As SendQueueData = sendBuffer.Dequeue(Of SendQueueData)()
                If sqData Is Nothing Then
                    Throw New Exception("Buffer count was greater than zero, yet a nothing was retrieved.  Something broke.")
                End If
                remEP = sqData.IPAddress
                byt = sqData.Data()
                fullSize = byt.GetUpperBound(0)
                If byt.GetUpperBound(0) > incBufferSize Then
                    Dim tmpByt() As Byte = SharedMethods.ShrinkArray(Of Byte)(byt, incBufferSize + 1)
                    sqData.Data = DirectCast(byt.Clone(), Byte())
                    sendBuffer.Push(sqData)
                    byt = DirectCast(tmpByt.Clone(), Byte())
                End If
            End SyncLock

            ' Send according to the appropriate protocol
            If myParent.Protocol = WinsockProtocol.Tcp Then
                Dim ssState As SendState = SendState.Build(fullSize, mSock1, incBufferSize)
                mSock1.BeginSend(byt, 0, byt.Length, SocketFlags.None, ssState.ErrCode, New AsyncCallback(AddressOf SendCallback), ssState)
            ElseIf myParent.Protocol = WinsockProtocol.Udp Then
                Dim tmpSock As New Socket(remEP.AddressFamily, SocketType.Dgram, ProtocolType.Udp)

                Dim ssState As SendState = SendState.Build(fullSize, tmpSock, incBufferSize)
                ssState.SendToAddress = remEP
                tmpSock.BeginSendTo(byt, 0, byt.Length, SocketFlags.None, remEP, New AsyncCallback(AddressOf SendToCallback), ssState)
            End If
        Catch ex As Exception
            SharedMethods.RaiseError(myParent, ex.Message)
        End Try
    End Sub

#End Region

#Region " Private Classes "

    ''' <summary>
    ''' A class that decodes and stores the packet header information.
    ''' </summary>
    Public Class PacketHeader

        Private _delimiter As Byte
        Private _hasDelim As Boolean
        Private _size As Integer

        Public Sub New()
            _size = -1
            _delimiter = Byte.MinValue
            _hasDelim = False
        End Sub

        ''' <summary>
        ''' A Boolean value to determine if the class has found a delimiter yet.
        ''' </summary>
        Public ReadOnly Property HasDelimiter() As Boolean
            Get
                Return _hasDelim
            End Get
        End Property

        ''' <summary>
        ''' A Boolean value to determine if the class has found the size or not.
        ''' </summary>
        Public ReadOnly Property HasSize() As Boolean
            Get
                Return _size > -1
            End Get
        End Property

        ''' <summary>
        ''' A Boolean value to determine if the header processing has been completed or not.
        ''' </summary>
        ''' <remarks>Based on HasDelimiter and HasSize</remarks>
        Public ReadOnly Property Completed() As Boolean
            Get
                Return HasDelimiter AndAlso HasSize
            End Get
        End Property

        ''' <summary>
        ''' The determined Size that was contained within the header.
        ''' </summary>
        Public ReadOnly Property Size() As Integer
            Get
                Return _size
            End Get
        End Property

        ''' <summary>
        ''' The delimiter found within the header (typically the first byte).
        ''' </summary>
        Public Property Delimiter() As Byte
            Get
                Return _delimiter
            End Get
            Set(ByVal value As Byte)
                _delimiter = value
                _hasDelim = True
            End Set
        End Property

        ''' <summary>
        ''' Processes a received byte array for possible header information to decode the length of the data received.
        ''' </summary>
        ''' <param name="byt">The byte array to process.</param>
        ''' <param name="_buff">A temporary byte buffer to stored data in.</param>
        ''' <remarks>The parameters must be passed ByRef to allow the other routines to work with the exact same data (and modified data).</remarks>
        Public Sub ProcessHeader(ByRef byt() As Byte, ByRef _buff As ByteBufferCol)
            ' Do we have an opening delimiter?
            If Not HasDelimiter Then
                ' We do now
                Delimiter = SharedMethods.ShrinkArray(Of Byte)(byt, 1)(0)
                If byt Is Nothing OrElse byt.Length = 0 Then Exit Sub
            End If
            ' check for the next instance of the delimiter
            Dim idx As Integer = Array.IndexOf(byt, _delimiter)
            If idx = -1 Then
                ' delimiter not found - add bytes to temp buffer
                _buff.Add(byt)
                Exit Sub
            End If
            ' delimiter was found, grab the size (part may be in the temp buffer) so combine them
            Dim temp() As Byte = SharedMethods.ShrinkArray(Of Byte)(byt, (idx + 1))
            ReDim Preserve temp(temp.GetUpperBound(0) - 1)
            _buff.Add(temp)
            temp = _buff.Combine()
            ' Clear the temp buffer
            _buff.Clear()
            ' convert the bytes containing the size back to string
            Dim strSize As String = System.Text.Encoding.ASCII.GetString(temp)
            ' try converting the string back to an integer
            If Not Integer.TryParse(strSize, _size) Then
                ' data not an integer, maybe legacy support should be used
                ' reset the delimiter and the size
                Reset()
                ' throw the exception
                Throw New Exception("Unable to determine size of incoming packet.  It's possible you may need to use Legacy Support.")
            End If
            ' is there data to follow?
            If _size = 0 Then
                ' no data followed the size
                ' reset the size and the delimiter
                Reset()
                ' exit
                Exit Sub
            End If
        End Sub

        ''' <summary>
        ''' Resets the packet processor for another run.
        ''' </summary>
        Public Sub Reset()
            _delimiter = Byte.MinValue
            _hasDelim = False
            _size = -1
        End Sub

        ''' <summary>
        ''' Adds a packet header to the byte array given.
        ''' </summary>
        ''' <param name="byt">The byte array to prepend with a packet header.</param>
        Public Sub AddHeader(ByRef byt() As Byte)
            'Dim arrSize As Integer = byt.GetUpperBound(0) 'Gets the size of the data to be sent
            Dim arrSize As Integer = byt.Length ' Gets the size of the data to be sent
            Dim strSize() As Byte = System.Text.Encoding.ASCII.GetBytes(arrSize.ToString) ' Converts the size to a string (to handle sizes larger than 255) and converts that to a byte array
            Dim fByte As Byte = FreeByte(strSize) ' Determines a byte not used by the size (delimiter)
            strSize = EncloseByte(fByte, strSize) ' Put the delimeter around the size header
            byt = AppendByte(strSize, byt) ' Combine the header with the data
        End Sub

        ''' <summary>
        ''' Determines which byte value was not used in the byte array.
        ''' </summary>
        ''' <param name="byt">The byte array to check.</param>
        Private Function FreeByte(ByVal byt() As Byte) As Byte
            'look for a free byte between 1 and 255
            Dim lowest As Byte = 0
            For i As Integer = 1 To 255
                If Array.IndexOf(byt, CByte(i)) = -1 Then
                    lowest = CByte(i)
                    Exit For
                End If
            Next
            Return lowest
        End Function

        ''' <summary>
        ''' Encloses a byte array with another byte.
        ''' </summary>
        ''' <param name="byt">A byte to enclose around a byte array.</param>
        ''' <param name="bytArr">The byte array that needs a byte enclosed around it.</param>
        Private Function EncloseByte(ByVal byt As Byte, ByVal bytArr() As Byte) As Byte()
            Dim orig As Integer = bytArr.GetUpperBound(0)
            Dim newa As Integer = orig + 2
            Dim ar(newa) As Byte
            ar(0) = byt
            Array.Copy(bytArr, 0, ar, 1, bytArr.Length)
            ar(newa) = byt
            Return ar
        End Function

        ''' <summary>
        ''' Combines two byte arrays.
        ''' </summary>
        Private Function AppendByte(ByVal first() As Byte, ByVal sec() As Byte) As Byte()
            Dim orig As Integer = first.GetUpperBound(0) + sec.Length
            Dim ar(orig) As Byte
            Array.Copy(first, 0, ar, 0, first.Length)
            Array.Copy(sec, 0, ar, first.GetUpperBound(0) + 1, sec.Length)
            Return ar
        End Function

    End Class

    ''' <summary>
    ''' A class that allows a state to be transfered from the calling method to the asyncrounous callback method.
    ''' This class is used for receiving data via UDP.
    ''' </summary>
    Private Class UdpReceiveState

        ''' <summary>
        ''' The incoming socket information - allows UDP to determine the sender.
        ''' </summary>
        Public SendingSocket As Object
        ''' <summary>
        ''' The EndPoint on which the data was received (server side).
        ''' </summary>
        Public ReceivingEndpoint As EndPoint

    End Class

    ''' <summary>
    ''' A class that helps store data waiting to be sent in the SendQueue
    ''' </summary>
    ''' <remarks>
    ''' This class was borne out of necessity - not for TCP, but for UDP.
    ''' I realized that if you are sending large data chunks out via UDP
    ''' to different remote addresses, you could end up sending data to
    ''' the wrong remote host.  This class allows the component to recognize
    ''' that it needs to send to a different remote host.
    ''' </remarks>
    Private Class SendQueueData

        ''' <summary>
        ''' Initializes a new instance of the SendQueueData class.
        ''' </summary>
        ''' <param name="ip">An IPEndPoint containing the IP address that you will be sending to.</param>
        ''' <param name="byt">The data that needs to be sent.</param>
        Public Sub New(ByVal ip As IPEndPoint, ByVal byt() As Byte)
            _ip = ip
            _data = byt
        End Sub

        Private _data() As Byte
        Private _ip As IPEndPoint

        ''' <summary>
        ''' The IPEndPoint that contains the IP address information needed to send the data.
        ''' </summary>
        Public ReadOnly Property IPAddress() As IPEndPoint
            Get
                Return _ip
            End Get
        End Property

        ''' <summary>
        ''' The data that needs to be sent.
        ''' </summary>
        Public Property Data() As Byte()
            Get
                Return _data
            End Get
            Set(ByVal value As Byte())
                _data = value
            End Set
        End Property

    End Class

    ''' <summary>
    ''' A class that allows a state to be transfered from the calling method to the asyncrounous callback method.
    ''' This class is used when sending data.
    ''' </summary>
    Private Class SendState

        ''' <summary>
        ''' The total length of the original byte array to be sent. (Includes packet header)
        ''' </summary>
        Public Length As Integer
        ''' <summary>
        ''' The error code as reported by the socket - used during the callback method.
        ''' </summary>
        Public ErrCode As SocketError
        ' '' <summary>
        ' '' The bytes that are to be sent.
        ' '' </summary>
        'Public Bytes() As Byte
        ''' <summary>
        ''' The index at which to start sending - usefull when sending packets larger than the buffer size.
        ''' </summary>
        Public StartIndex As Integer
        ''' <summary>
        ''' The number of bytes to send during this time - usefull when sending packets larger than the buffer size.
        ''' </summary>
        Public SendLength As Integer
        ''' <summary>
        ''' The total number of bytes actually transmitted.
        ''' </summary>
        Public TotalSent As Integer
        ''' <summary>
        ''' The socket that is doing the sending - used for UDP statistic information during the callback method.
        ''' </summary>
        Public SendingSocket As Socket
        ''' <summary>
        ''' The IP address of the computer you are sending to - used for UDP statistic information during the callback method.
        ''' </summary>
        Public SendToAddress As IPEndPoint

        ''' <summary>
        ''' Builds and returns an instance of the SendState class.
        ''' </summary>
        ''' <param name="bytUpperBound">The UpperBound of the byte array that will be sent.</param>
        ''' <param name="sock">The socket to assign to the SendState.</param>
        ''' <param name="buffer_size">The socket's buffer size.</param>
        Public Shared Function Build(ByVal bytUpperBound As Integer, ByRef sock As Socket, ByVal buffer_size As Integer) As SendState
            Dim ret As New SendState
            ret.Length = bytUpperBound + 1
            ret.StartIndex = 0
            If bytUpperBound > buffer_size Then
                ret.SendLength = buffer_size + 1
            Else
                ret.SendLength = bytUpperBound
            End If
            ret.SendingSocket = sock
            Return ret
        End Function

        ''' <summary>
        ''' Returns a boolean indicating whether the object being sent has completed or not.
        ''' </summary>
        Public ReadOnly Property SendCompleted() As Boolean
            Get
                Return Not (TotalSent < Length)
            End Get
        End Property
    End Class

#End Region

End Class

''' <summary>
''' A special collection class to act as a byte buffer.
''' </summary>
Public Class ByteBufferCol
    Inherits CollectionBase

    ''' <summary>
    ''' Adds a byte to the byte buffer.
    ''' </summary>
    ''' <param name="byt">The byte to add to the buffer.</param>
    Public Sub Add(ByVal byt As Byte)
        List.Add(byt)
    End Sub

    ''' <summary>
    ''' Adds a byte array to the byte buffer.
    ''' </summary>
    ''' <param name="byt">The byte array to add to the buffer.</param>
    ''' <remarks>Adds all the bytes in the array individually - not the array itself.</remarks>
    Public Sub Add(ByVal byt() As Byte)
        For i As Integer = 0 To UBound(byt)
            List.Add(byt(i))
        Next
    End Sub

    ''' <summary>
    ''' Combines all the bytes in the buffer into one byte array.
    ''' </summary>
    Public Function Combine() As Byte()
        If List.Count = 0 Then Return Nothing
        Dim ar(List.Count - 1) As Byte
        For i As Integer = 0 To List.Count - 1
            ar(i) = CByte(List.Item(i))
        Next
        Return ar
    End Function

End Class