Public Class MyEventArgs
    Inherits System.EventArgs

    Private _data As String

    Sub New(ByVal dat As String)
        _data = dat
    End Sub
    Public ReadOnly Property Data()
        Get
            Return _data
        End Get
    End Property
End Class

''' <summary>
''' Provides data for the Winsock.ErrorReceived event.
''' </summary>
Public Class WinsockErrorReceivedEventArgs
    Inherits System.EventArgs

    Private m_errorMsg As String
    Private m_function As String
    Private m_errorCode As System.Net.Sockets.SocketError
    Private m_Details As String

    ''' <summary>
    ''' Initializes a new instance of the WinsockErrorEventArgs class.
    ''' </summary>
    ''' <param name="error_message">A String containing the error message.</param>
    Public Sub New(ByVal error_message As String)
        Me.New(error_message, Nothing)
    End Sub
    ''' <summary>
    ''' Initializes a new instance of the WinsockErrorEventArgs class.
    ''' </summary>
    ''' <param name="error_message">A String containing the error message.</param>
    ''' <param name="function_name">A String containing the name of the function that produced the error.</param>
    Public Sub New(ByVal error_message As String, ByVal function_name As String)
        Me.New(error_message, function_name, Nothing)
    End Sub
    ''' <summary>
    ''' Initializes a new instance of the WinsockErrorEventArgs class.
    ''' </summary>
    ''' <param name="error_message">A String containing the error message.</param>
    ''' <param name="function_name">A String containing the name of the function that produced the error.</param>
    ''' <param name="extra_details">A String containing extra details for the error message.</param>
    Public Sub New(ByVal error_message As String, ByVal function_name As String, ByVal extra_details As String)
        Me.New(error_message, function_name, extra_details, Net.Sockets.SocketError.Success)
    End Sub
    ''' <summary>
    ''' Initializes a new instance of the WinsockErrorEventArgs class.
    ''' </summary>
    ''' <param name="error_message">A String containing the error message.</param>
    ''' <param name="function_name">A String containing the name of the function that produced the error.</param>
    ''' <param name="extra_details">A String containing extra details for the error message.</param>
    ''' <param name="error_code">A value containing the socket's ErrorCode.</param>
    Public Sub New(ByVal error_message As String, ByVal function_name As String, ByVal extra_details As String, ByVal error_code As System.Net.Sockets.SocketError)
        m_errorMsg = error_message
        m_function = function_name
        m_Details = extra_details
        m_errorCode = error_code
    End Sub

    ''' <summary>
    ''' Gets a value containing the error message.
    ''' </summary>
    Public ReadOnly Property Message() As String
        Get
            Return m_errorMsg
        End Get
    End Property

    ''' <summary>
    ''' Gets a value containing the name of the function that produced the error.
    ''' </summary>
    Public ReadOnly Property [Function]() As String
        Get
            Return m_function
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the error code returned by the socket.
    ''' </summary>
    ''' <remarks>If it wasn't returned by the socket, it defaults to success.</remarks>
    Public ReadOnly Property ErrorCode() As System.Net.Sockets.SocketError
        Get
            Return m_errorCode
        End Get
    End Property

    ''' <summary>
    ''' Gets a value containing more details than the typical error message.
    ''' </summary>
    Public ReadOnly Property Details() As String
        Get
            Return m_Details
        End Get
    End Property
End Class

''' <summary>
''' Provides data for the Winsock.ConnectionRequest event.
''' </summary>
Public Class WinsockConnectionRequestEventArgs
    Inherits System.EventArgs

    Private _client As System.Net.Sockets.Socket
    Private _cancel As Boolean = False

    ''' <summary>
    ''' Initializes a new instance of the WinsockClientReceivedEventArgs class.
    ''' </summary>
    ''' <param name="new_client">A Socket object containing the new client that needs to be accepted.</param>
    Public Sub New(ByVal new_client As System.Net.Sockets.Socket)
        _client = new_client
    End Sub

    ''' <summary>
    ''' Gets a value containing the client information.
    ''' </summary>
    ''' <remarks>Used in accepting the client.</remarks>
    Public ReadOnly Property Client() As System.Net.Sockets.Socket
        Get
            Return _client
        End Get
    End Property

    ''' <summary>
    ''' Gets a value containing the incoming clients IP address.
    ''' </summary>
    Public ReadOnly Property ClientIP() As String
        Get
            Dim rEP As System.Net.IPEndPoint = CType(_client.RemoteEndPoint, System.Net.IPEndPoint)
            Return rEP.Address.ToString()
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether the incoming client request should be cancelled.
    ''' </summary>
    Public Property Cancel() As Boolean
        Get
            Return _cancel
        End Get
        Set(ByVal value As Boolean)
            _cancel = value
        End Set
    End Property
End Class

''' <summary>
''' Provides data for the Winsock.StateChanged event.
''' </summary>
Public Class WinsockStateChangedEventArgs
    Inherits System.EventArgs

    Private m_OldState As WinsockStates
    Private m_NewState As WinsockStates

    ''' <summary>
    ''' Initializes a new instance of the WinsockStateChangingEventArgs class.
    ''' </summary>
    ''' <param name="oldState">The old state of the Winsock control.</param>
    ''' <param name="newState">The state the Winsock control is changing to.</param>
    Public Sub New(ByVal oldState As WinsockStates, ByVal newState As WinsockStates)
        m_OldState = oldState
        m_NewState = newState
    End Sub

    ''' <summary>
    ''' Gets a value indicating the previous state of the Winsock control.
    ''' </summary>
    Public ReadOnly Property Old_State() As WinsockStates
        Get
            Return m_OldState
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the new state of the Winsock control.
    ''' </summary>
    Public ReadOnly Property New_State() As WinsockStates
        Get
            Return m_NewState
        End Get
    End Property
End Class

''' <summary>
''' Provides data for the Winsock.DataArrival event.
''' </summary>
Public Class WinsockDataArrivalEventArgs
    Inherits System.EventArgs

    Private _bTotal As Integer
    Private _IP As String
    Private _Port As Integer

    ''' <summary>
    ''' Initializes a new instance of the WinsockDataArrivalEventArgs class.
    ''' </summary>
    ''' <param name="bytes_total">The number of bytes that were received.</param>
    ''' <param name="source_ip">The source address of the bytes.</param>
    ''' <param name="source_port">The source port of the bytes.</param>
    Public Sub New(ByVal bytes_total As Integer, ByVal source_ip As String, ByVal source_port As Integer)
        _bTotal = bytes_total
        _IP = source_ip
        _Port = source_port
    End Sub

    ''' <summary>
    ''' Gets a value indicating the number of bytes received.
    ''' </summary>
    Public ReadOnly Property TotalBytes() As Integer
        Get
            Return _bTotal
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the data's originating address.
    ''' </summary>
    Public ReadOnly Property SourceIP() As String
        Get
            Return _IP
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the data's originating port.
    ''' </summary>
    Public ReadOnly Property SourcePort() As Integer
        Get
            Return _Port
        End Get
    End Property
End Class

''' <summary>
''' Provides data for the Winsock.Connected event.
''' </summary>
Public Class WinsockConnectedEventArgs
    Inherits System.EventArgs

    Private _IP As String
    Private _Port As Integer

    ''' <summary>
    ''' Initializes a new instance of the WinsockConnectedEventArgs class.
    ''' </summary>
    ''' <param name="source_ip">The source address of the connection.</param>
    ''' <param name="source_port">The source port of the connection.</param>
    Public Sub New(ByVal source_ip As String, ByVal source_port As Integer)
        _IP = source_ip
        _Port = source_port
    End Sub

    ''' <summary>
    ''' Gets a value indicating the remote address of the connection.
    ''' </summary>
    Public ReadOnly Property SourceIP() As String
        Get
            Return _IP
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the remote port of the connection.
    ''' </summary>
    Public ReadOnly Property SourcePort() As Integer
        Get
            Return _Port
        End Get
    End Property
End Class

''' <summary>
''' Provides data for the Winsock.SendComplete event.
''' </summary>
Public Class WinsockSendEventArgs
    Inherits System.EventArgs

    Private _bTotal As Integer
    Private _bSent As Integer
    Private _IP As String

    ''' <summary>
    ''' Initializes a new instance of the WinsockSendEventArgs class.
    ''' </summary>
    ''' <param name="dest_ip">The destination of the bytes sent.</param>
    ''' <param name="bytes_sent">The total number of bytes sent.</param>
    ''' <param name="bytes_total">The total number of bytes that were supposed to be sent.</param>
    Public Sub New(ByVal dest_ip As String, ByVal bytes_sent As Integer, ByVal bytes_total As Integer)
        _IP = dest_ip
        _bTotal = bytes_total
        _bSent = bytes_sent
    End Sub

    ''' <summary>
    ''' Gets a value indicating the destination of the bytes sent.
    ''' </summary>
    Public ReadOnly Property DestinationIP() As String
        Get
            Return _IP
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the number of bytes sent.
    ''' </summary>
    Public ReadOnly Property BytesSent() As Integer
        Get
            Return _bSent
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the total number of bytes that should have been sent.
    ''' </summary>
    Public ReadOnly Property BytesTotal() As Integer
        Get
            Return _bTotal
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the percentage (0-100) of bytes that where sent.
    ''' </summary>
    Public ReadOnly Property SentPercent() As Double
        Get
            Return Math.Round((_bSent / _bTotal) * 100, 2)
        End Get
    End Property

End Class

''' <summary>
''' Provides data for the WinsockCollection.CountChanged event.
''' </summary>
Public Class WinsockCollectionCountChangedEventArgs
    Inherits System.EventArgs

    Private _oldCount As Integer
    Private _newCount As Integer

    ''' <summary>
    ''' Initializes a new instance of the WinsockCollectionCountChangedEventArgs class.
    ''' </summary>
    ''' <param name="old_count">The old number of items in the collection.</param>
    ''' <param name="new_count">The new number of items in the collection.</param>
    Public Sub New(ByVal old_count As Integer, ByVal new_count As Integer)
        _oldCount = old_count
        _newCount = new_count
    End Sub

    ''' <summary>
    ''' Gets a value indicating the previous number of items in the collection.
    ''' </summary>
    Public ReadOnly Property OldCount() As Integer
        Get
            Return _oldCount
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the current number of items in the collection.
    ''' </summary>
    Public ReadOnly Property NewCount() As Integer
        Get
            Return _newCount
        End Get
    End Property
End Class

''' <summary>
''' Provides data for the Winsock.ReceiveProgress event.
''' </summary>
Public Class WinsockReceiveProgressEventArgs
    Inherits System.EventArgs

    Private _bTotal As Integer
    Private _bIn As Integer
    Private _IP As String

    ''' <summary>
    ''' Initializes a new instance of the WinsockReceiveProgressEventArgs class.
    ''' </summary>
    ''' <param name="source_ip">The source ip of the bytes received.</param>
    ''' <param name="bytes_received">The total number of bytes received.</param>
    ''' <param name="bytes_total">The total number of bytes that were supposed to be received.</param>
    Public Sub New(ByVal source_ip As String, ByVal bytes_received As Integer, ByVal bytes_total As Integer)
        _IP = source_ip
        _bTotal = bytes_total
        _bIn = bytes_received
    End Sub

    ''' <summary>
    ''' Gets a value indicating the source of the bytes sent.
    ''' </summary>
    Public ReadOnly Property SourceIP() As String
        Get
            Return _IP
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the number of bytes received.
    ''' </summary>
    Public ReadOnly Property BytesReceived() As Integer
        Get
            Return _bIn
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the total number of bytes that should be received.
    ''' </summary>
    Public ReadOnly Property BytesTotal() As Integer
        Get
            Return _bTotal
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating the percentage (0-100) of bytes that where received.
    ''' </summary>
    Public ReadOnly Property ReceivedPercent() As Double
        Get
            Return Math.Round((_bIn / _bTotal) * 100, 2)
        End Get
    End Property

End Class