Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Net

<ToolboxBitmap(GetType(Winsock), "Winsock.png")> _
<DefaultEvent("ErrorReceived")> _
Public Class Winsock
    Inherits Component
    Implements IWinsock

    Public Sub New()
        _localPort = 8080
        _remotePort = 8080
        _remoteHost = "localhost"
        _maxPendingConnections = 1
        _legacySupport = False
        _protocol = WinsockProtocol.Tcp
        _wsState = WinsockStates.Closed
        _asSock = New AsyncSocket(Me)
    End Sub

#Region " Events "

    ''' <summary>
    ''' Triggers an event declared at module level within a class, form, or document in a thread-safe manner.
    ''' </summary>
    ''' <param name="ev">The event to be raised.</param>
    ''' <param name="args">The arguements for the event.</param>
    Private Sub RaiseEventSafe(ByVal ev As System.Delegate, ByRef args() As Object)
        Dim bFired As Boolean
        If ev IsNot Nothing Then
            For Each singleCast As System.Delegate In ev.GetInvocationList()
                bFired = False
                Try
                    Dim syncInvoke As ISynchronizeInvoke = CType(singleCast.Target, ISynchronizeInvoke)
                    If syncInvoke IsNot Nothing AndAlso syncInvoke.InvokeRequired Then
                        bFired = True
                        syncInvoke.BeginInvoke(singleCast, args)
                    Else
                        bFired = True
                        singleCast.DynamicInvoke(args)
                    End If
                Catch ex As Exception
                    If Not bFired Then singleCast.DynamicInvoke(args)
                End Try
            Next
        End If
    End Sub

    ''' <summary>
    ''' Occurs when connection is achieved (client and server).
    ''' </summary>
    Public Event Connected(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs) Implements IWinsock.Connected
    ''' <summary>
    ''' Occurs on the server when a client is attempting to connect.
    ''' </summary>
    ''' <remarks>Client registers connected at this point. Server must Accept in order for it to be connected.</remarks>
    Public Event ConnectionRequest(ByVal sender As Object, ByVal e As WinsockConnectionRequestEventArgs) Implements IWinsock.ConnectionRequest
    ''' <summary>
    ''' Occurs when data arrives on the socket.
    ''' </summary>
    ''' <remarks>Raised only after all parts of the data have been collected.</remarks>
    Public Event DataArrival(ByVal sender As Object, ByVal e As WinsockDataArrivalEventArgs) Implements IWinsock.DataArrival
    ''' <summary>
    ''' Occurs when disconnected from the remote computer (client and server).
    ''' </summary>
    Public Event Disconnected(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWinsock.Disconnected
    ''' <summary>
    ''' Occurs when an error is detected in the socket.
    ''' </summary>
    ''' <remarks>May also be raised on disconnected (depending on disconnect circumstance).</remarks>
    Public Event ErrorReceived(ByVal sender As Object, ByVal e As WinsockErrorReceivedEventArgs) Implements IWinsock.ErrorReceived
    ''' <summary>
    ''' Occurs while the receive buffer is being filled with data.
    ''' </summary>
    Public Event ReceiveProgress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs) Implements IWinsock.ReceiveProgress
    ''' <summary>
    ''' Occurs when sending of data is completed.
    ''' </summary>
    Public Event SendComplete(ByVal sender As Object, ByVal e As WinsockSendEventArgs) Implements IWinsock.SendComplete
    ''' <summary>
    ''' Occurs when the send buffer has been sent but not all the data has been sent yet.
    ''' </summary>
    Public Event SendProgress(ByVal sender As Object, ByVal e As WinsockSendEventArgs) Implements IWinsock.SendProgress
    ''' <summary>
    ''' Occurs when the state of the socket changes.
    ''' </summary>
    Public Event StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs) Implements IWinsock.StateChanged

    ''' <summary>
    ''' Raises the Connected event.
    ''' </summary>
    Public Sub OnConnected(ByVal e As WinsockConnectedEventArgs) Implements IWinsock.OnConnected
        RaiseEventSafe(ConnectedEvent, New Object() {Me, e})
    End Sub

    ''' <summary>
    ''' Raises the ConnectionRequest event.
    ''' </summary>
    Public Sub OnConnectionRequest(ByVal e As WinsockConnectionRequestEventArgs) Implements IWinsock.OnConnectionRequest
        RaiseEventSafe(ConnectionRequestEvent, New Object() {Me, e})
        If e.Cancel Then
            e.Client.Disconnect(False)
            e.Client.Close()
        End If
    End Sub

    ''' <summary>
    ''' Raises the DataArrival event.
    ''' </summary>
    Public Sub OnDataArrival(ByVal e As WinsockDataArrivalEventArgs) Implements IWinsock.OnDataArrival
        RaiseEventSafe(DataArrivalEvent, New Object() {Me, e})
    End Sub

    ''' <summary>
    ''' Raises the Disconnected event.
    ''' </summary>
    Public Sub OnDisconnected() Implements IWinsock.OnDisconnected
        RaiseEventSafe(DisconnectedEvent, New Object() {Me, New System.EventArgs})
    End Sub

    ''' <summary>
    ''' Raises the ErrorReceived event.
    ''' </summary>
    Public Sub OnErrorReceived(ByVal e As WinsockErrorReceivedEventArgs) Implements IWinsock.OnErrorReceived
        RaiseEventSafe(ErrorReceivedEvent, New Object() {Me, e})
    End Sub

    ''' <summary>
    ''' Raises the ReceiveProgress event.
    ''' </summary>
    Public Sub OnReceiveProgress(ByVal e As WinsockReceiveProgressEventArgs) Implements IWinsock.OnReceiveProgress
        RaiseEventSafe(ReceiveProgressEvent, New Object() {Me, e})
    End Sub

    ''' <summary>
    ''' Raises the SendComplete event.
    ''' </summary>
    Public Sub OnSendComplete(ByVal e As WinsockSendEventArgs) Implements IWinsock.OnSendComplete
        RaiseEventSafe(SendCompleteEvent, New Object() {Me, e})
    End Sub

    ''' <summary>
    ''' Raises the SendProgress event.
    ''' </summary>
    Public Sub OnSendProgress(ByVal e As WinsockSendEventArgs) Implements IWinsock.OnSendProgress
        RaiseEventSafe(SendProgressEvent, New Object() {Me, e})
    End Sub

    ''' <summary>
    ''' Raises the StateChanged event.
    ''' </summary>
    Private Sub OnStateChanged(ByVal e As WinsockStateChangedEventArgs) 'Implements IWinsock.OnStateChanged
        If _wsState <> e.New_State Then
            _wsState = e.New_State
            RaiseEventSafe(StateChangedEvent, New Object() {Me, e})
        End If
    End Sub

#End Region

#Region " Private Members "

    Private _asSock As AsyncSocket
    Private _wsState As WinsockStates
    Private _localPort As Integer
    Private _maxPendingConnections As Integer
    Private _remoteHost As String
    Private _remotePort As Integer
    Private _legacySupport As Boolean
    Private _protocol As WinsockProtocol

#End Region

#Region " Helper Methods "

    ''' <summary>
    ''' Encapsulates the OnStateChanged methods so the AsyncSocket
    ''' doesn't have to build the EventArgs parameter all the time.
    ''' </summary>
    ''' <param name="new_state">The new state of the Winsock.</param>
    Protected Friend Sub ChangeState(ByVal new_state As WinsockStates) Implements IWinsock.ChangeState
        OnStateChanged(New WinsockStateChangedEventArgs(_wsState, new_state))
    End Sub

    ''' <summary>
    ''' When the port is set dynamically by using port 0, the socket can now update the property of the component.
    ''' </summary>
    ''' <param name="new_port">The port we are now listening on.</param>
    Protected Friend Sub ChangeLocalPort(ByVal new_port As Integer) Implements IWinsock.ChangeLocalPort
        _localPort = new_port
    End Sub

#End Region

#Region " Public Properties "

    ''' <summary>
    ''' Gets or sets a value indicating the interal size of the byte buffers.
    ''' </summary>
    Public Property BufferSize() As Integer
        Get
            Return _asSock.BufferSize
        End Get
        Set(ByVal value As Integer)
            _asSock.BufferSize = value
        End Set
    End Property

    ''' <summary>
    ''' Gets a value indicating whether the buffer has data for retrieval.
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property HasData() As Boolean
        Get
            Return _asSock.BufferCount > 0
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating if Legacy support should be used or not.
    ''' </summary>
    ''' <remarks>Legacy support is to support older winsock style connections.</remarks>
    Public Property LegacySupport() As Boolean Implements IWinsock.LegacySupport
        Get
            Return _legacySupport
        End Get
        Set(ByVal value As Boolean)
            If Not value AndAlso Protocol = WinsockProtocol.Udp Then
                Throw New Exception("LegacySupport is required for UDP connections.")
            End If
            _legacySupport = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the local machine's IP address(es).
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property LocalIP() As String()
        Get
            Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
            Dim s(h.AddressList.Length - 1) As String
            For i As Integer = 0 To h.AddressList.Length - 1
                s(i) = CType(h.AddressList.GetValue(i), Net.IPAddress).ToString
            Next
            Return s
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating the port the <see cref="Winsock" /> control should listen on.
    ''' </summary>
    ''' <remarks>Cannot change while listening, connected, or connecting - but can change while closing.</remarks>
    Public Property LocalPort() As Integer
        Get
            Return _localPort
        End Get
        Set(ByVal value As Integer)
            Select Case State
                Case WinsockStates.Listening
                    Throw New Exception("Cannot change the local port while already listening on a port.")
                Case WinsockStates.Connected
                    Throw New Exception("Cannot change the local port of a connection that is already active.")
                Case Else
                    If State <> WinsockStates.Closed AndAlso State <> WinsockStates.Closing Then
                        Throw New Exception("Cannot change the local port while the component is processing, it may have adverse effects on the connection process.")
                    End If
            End Select
            _localPort = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value that control the length of the maximum length of the pending connections queue.
    ''' </summary>
    ''' <remarks>Cannot change while listening.</remarks>
    Public Property MaxPendingConnections() As Integer
        Get
            Return _maxPendingConnections
        End Get
        Set(ByVal value As Integer)
            Select Case State
                Case WinsockStates.Listening
                    Throw New Exception("Cannot change the pending connections value while already listening.")
            End Select
            _maxPendingConnections = value
        End Set
    End Property

    ''' <summary>
    ''' Gets a NetworkStream that this Winsock object is based on.
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property NetworkStream() As System.Net.Sockets.NetworkStream
        Get
            Return _asSock.UnderlyingStream
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the winsock protocol to use when communicating with the remote computer.
    ''' </summary>
    <RefreshProperties(RefreshProperties.All)> _
       Public Property Protocol() As WinsockProtocol Implements IWinsock.Protocol
        Get
            Return _protocol
        End Get
        Set(ByVal value As WinsockProtocol)
            If State <> WinsockStates.Closed Then
                Throw New Exception("Cannot change the protocol while listening or connected to a remote computer.")
            End If
            _protocol = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value that determines what remote computer to connect to, or is currently connected to.
    ''' </summary>
    ''' <remarks>Can only change if closed or listening.</remarks>
    Public Property RemoteHost() As String Implements IWinsock.RemoteHost
        Get
            Return _remoteHost
        End Get
        Set(ByVal value As String)
            If State <> WinsockStates.Closed AndAlso State <> WinsockStates.Listening Then
                Throw New Exception("Cannot change the remote host while already connected to a remote computer.")
            End If
            _remoteHost = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value that determines which port on the remote computer to connect on, or is currently connected on.
    ''' </summary>
    ''' <remarks>Can only change if closed or listening.</remarks>
    Public Property RemotePort() As Integer Implements IWinsock.RemotePort
        Get
            Return _remotePort
        End Get
        Set(ByVal value As Integer)
            If State <> WinsockStates.Closed AndAlso State <> WinsockStates.Listening Then
                Throw New Exception("Cannot change the remote port while already connected to a remote computer.")
            End If
            _remotePort = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the state of the <see cref="Winsock">Winsock</see> control.
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property State() As WinsockStates Implements IWinsock.State
        Get
            Return _wsState
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Places a <see cref="Winsock">Winsock</see> in a listening state.
    ''' </summary>
    Public Sub Listen()
        _asSock.Listen(LocalPort, MaxPendingConnections)
    End Sub
    ''' <summary>
    ''' Places a <see cref="Winsock">Winsock</see> in a listening state.
    ''' </summary>
    ''' <param name="port">The port <see cref="Winsock">Winsock</see> should listen on.</param>
    Public Sub Listen(ByVal port As Integer)
        If port < 0 Then
            Throw New ArgumentException("Port cannot be less than zero.", "port")
        End If
        LocalPort = port
        Listen()
    End Sub
    ''' <summary>
    ''' Places a <see cref="Winsock">Winsock</see> in a listening state.
    ''' </summary>
    ''' <param name="ip">The IP address the <see cref="Winsock">Winsock</see> should listen on.  This must be an ip address.</param>
    Public Sub Listen(ByVal ip As String)
        If ip Is Nothing Then
            Listen()
        Else
            Dim ipAddr As IPAddress = Nothing
            If Not IPAddress.TryParse(ip, ipAddr) Then
                Throw New ArgumentException("IP address specified is not a valid IP address.", "ip")
            End If
            _asSock.Listen(LocalPort, MaxPendingConnections, ipAddr)
        End If
    End Sub
    ''' <summary>
    ''' Places a <see cref="Winsock">Winsock</see> in a listening state.
    ''' </summary>
    ''' <param name="ip">The IP address the <see cref="Winsock">Winsock</see> should listen on.</param>
    ''' <param name="port">The port <see cref="Winsock">Winsock</see> should listen on.</param>
    Public Sub Listen(ByVal ip As String, ByVal port As Integer)
        If port < 0 Then
            Throw New ArgumentException("Port cannot be less than zero.", "port")
        End If
        LocalPort = port
        If ip Is Nothing Then
            Listen()
        Else
            Dim ipAddr As IPAddress = Nothing
            If Not IPAddress.TryParse(ip, ipAddr) Then
                Throw New ArgumentException("IP address specified is not a valid IP address.", "ip")
            End If
            _asSock.Listen(LocalPort, MaxPendingConnections, ipAddr)
        End If
    End Sub

    ''' <summary>
    ''' Accepts a client connect as valid and begins to monitor it for incoming data.
    ''' </summary>
    ''' <param name="client">A <see cref="System.Net.Sockets.Socket">System.Net.Sockets.Socket</see> that represents the client being accepted.</param>
    Public Sub Accept(ByVal client As Sockets.Socket)
        If _asSock.Accept(client) Then
            _localPort = _asSock.LocalPort
            ' also set remote host and port
        End If
    End Sub

    ''' <summary>
    ''' Creates an new <see cref="Winsock">Winsock</see> and accepts the client connection on it.
    ''' </summary>
    ''' <param name="client">A <see cref="System.Net.Sockets.Socket">System.Net.Sockets.Socket</see> that represents the client being accepted.</param>
    ''' <remarks>
    ''' This was created to be used by the listener, to keep the listener listening while
    ''' also accepting a connection.
    ''' </remarks>
    Public Function AcceptNew(ByVal client As Sockets.Socket) As Winsock
        Dim wskReturn As New Winsock()
        wskReturn.Protocol = Me.Protocol
        wskReturn.LegacySupport = Me.LegacySupport
        wskReturn.Accept(client)
        Return wskReturn
    End Function

    Public Sub StopFile()
        _asSock.StopSendFile = True
    End Sub

    ''' <summary>
    ''' Closes an open <see cref="Winsock">Winsock</see> connection.
    ''' </summary>
    Public Sub Close()
        _asSock.Close()
    End Sub

    ''' <summary>
    ''' Establishes a connection to a remote host.
    ''' </summary>
    Public Sub Connect()
        _asSock.Connect(RemoteHost, RemotePort)
    End Sub
    ''' <summary>
    ''' Establishes a connection to a remote host.
    ''' </summary>
    ''' <param name="remoteHostOrIP">A <see cref="System.String">System.String</see> containing the Hostname or IP address of the remote host.</param>
    ''' <param name="remote_port">A value indicating the port on the remote host to connect to.</param>
    Public Sub Connect(ByVal remoteHostOrIP As String, ByVal remote_port As Integer)
        RemoteHost = remoteHostOrIP
        RemotePort = remote_port
        Connect()
    End Sub

    ''' <summary>
    ''' Sends an object to a connected socket on a remote computer.
    ''' </summary>
    ''' <param name="data">The object to send.</param>
    ''' <remarks>
    ''' The object is first serialized using a BinaryFormatter - unless
    ''' it is already a byte array, in which case it just sends the byte array.
    ''' </remarks>
    Public Sub Send(ByVal data As Object)
        Dim byt() As Byte
        If LegacySupport AndAlso data.GetType Is GetType(String) Then
            byt = System.Text.Encoding.Default.GetBytes(CStr(data))
        Else
            byt = ObjectPacker.GetBytes(data)
        End If
        _asSock.Send(byt)
    End Sub
    ''' <summary>
    ''' Sends a file to a connected socket on a remote computer.
    ''' </summary>
    ''' <param name="filename">The full path to the file you want to send.</param>
    ''' <remarks>
    ''' Creates a special file object to send, so the receiving end knows what to do with it.
    ''' </remarks>
    Public Sub SendFile(ByVal filename As String)
        Dim wsf As New WinsockFileData()
        Try
            If Not wsf.ReadFile(filename) Then
                Throw New Exception("File does not exist, or there was a problem reading the file.")
            End If
            If LegacySupport Then
                Send(wsf.FileData)
            Else
                Send(wsf)
            End If
        Catch ex As Exception
            SharedMethods.RaiseError(Me, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Gets the next object from the buffer, removing it from the buffer.
    ''' </summary>
    ''' <returns>
    ''' A Deserialized object or if it can't be deserialized the byte array.
    ''' </returns>
    Public Function [Get]() As Object
        Dim byt() As Byte = _asSock.GetData()
        Return ObjectPacker.GetObject(byt)
    End Function
    ''' <summary>
    ''' Gets the next object from the buffer as the supplied type, removing it from the buffer.
    ''' </summary>
    ''' <typeparam name="dataType">The System.Type you wish to have the data returned as.</typeparam>
    ''' <returns>
    ''' A Deserialized object converted to the data type you wish.
    ''' </returns>
    ''' <remarks>
    ''' This function was added to make it easier for Option Strict users.
    ''' It allows for easier conversion instead of the user using CType, DirectCast, or the like.
    ''' Can throw an error if you specify the wrong type.
    ''' </remarks>
    Public Function [Get](Of dataType)() As dataType
        Dim byt() As Byte = _asSock.GetData()
        Dim obj As Object
        If LegacySupport AndAlso GetType(dataType) Is GetType(String) Then
            obj = System.Text.Encoding.Default.GetString(byt)
        Else
            obj = ObjectPacker.GetObject(byt)
        End If
        Return DirectCast(obj, dataType)
    End Function

    ''' <summary>
    ''' Gets the next object from the buffer, leaving it ing the buffer.
    ''' </summary>
    ''' <returns>
    ''' A Deserialized object or if it can't be deserialized the byte array.
    ''' </returns>
    Public Function Peek() As Object
        Dim byt() As Byte = _asSock.PeekData()
        Return ObjectPacker.GetObject(byt)
    End Function
    ''' <summary>
    ''' Gets the next object from the buffer as the supplied type, leaving it in the buffer.
    ''' </summary>
    ''' <typeparam name="dataType">The System.Type you wish to have the data returned as.</typeparam>
    ''' <returns>
    ''' A Deserialized object converted to the data type you wish.
    ''' </returns>
    ''' <remarks>
    ''' This function was added to make it easier for Option Strict users.
    ''' It allows for easier conversion instead of the user using CType, DirectCast, or the like.
    ''' Can throw an error if you specify the wrong type.
    ''' </remarks>
    Public Function Peek(Of dataType)() As dataType
        Dim byt() As Byte = _asSock.PeekData()
        Dim obj As Object
        If LegacySupport AndAlso GetType(dataType) Is GetType(String) Then
            obj = System.Text.Encoding.Default.GetString(byt)
        Else
            obj = ObjectPacker.GetObject(byt)
        End If
        Return DirectCast(obj, dataType)
    End Function

#End Region

End Class