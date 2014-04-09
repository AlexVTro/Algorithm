Public Interface IWinsock

#Region " Events "

    ''' <summary>
    ''' Occurs when connection is achieved (client and server).
    ''' </summary>
    Event Connected(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs)
    ''' <summary>
    ''' Occurs on the server when a client is attempting to connect.
    ''' </summary>
    ''' <remarks>Client registers connected at this point. Server must Accept in order for it to be connected.</remarks>
    Event ConnectionRequest(ByVal sender As Object, ByVal e As WinsockConnectionRequestEventArgs)
    ''' <summary>
    ''' Occurs when data arrives on the socket.
    ''' </summary>
    ''' <remarks>Raised only after all parts of the data have been collected.</remarks>
    Event DataArrival(ByVal sender As Object, ByVal e As WinsockDataArrivalEventArgs)
    ''' <summary>
    ''' Occurs when disconnected from the remote computer (client and server).
    ''' </summary>
    Event Disconnected(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Occurs when an error is detected in the socket.
    ''' </summary>
    ''' <remarks>May also be raised on disconnected (depending on disconnect circumstance).</remarks>
    Event ErrorReceived(ByVal sender As Object, ByVal e As WinsockErrorReceivedEventArgs)
    ''' <summary>
    ''' Occurs while the receive buffer is being filled with data.
    ''' </summary>
    Event ReceiveProgress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs)
    ''' <summary>
    ''' Occurs when sending of data is completed.
    ''' </summary>
    Event SendComplete(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
    ''' <summary>
    ''' Occurs when the send buffer has been sent but not all the data has been sent yet.
    ''' </summary>
    Event SendProgress(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
    ''' <summary>
    ''' Occurs when the state of the socket changes.
    ''' </summary>
    Event StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs)

    ''' <summary>
    ''' Raises the Connected event.
    ''' </summary>
    Sub OnConnected(ByVal e As WinsockConnectedEventArgs)
    ''' <summary>
    ''' Raises the ConnectionRequest event.
    ''' </summary>
    Sub OnConnectionRequest(ByVal e As WinsockConnectionRequestEventArgs)
    ''' <summary>
    ''' Raises the DataArrival event.
    ''' </summary>
    Sub OnDataArrival(ByVal e As WinsockDataArrivalEventArgs)
    ''' <summary>
    ''' Raises the Disconnected event.
    ''' </summary>
    Sub OnDisconnected()
    ''' <summary>
    ''' Raises the ErrorReceived event.
    ''' </summary>
    Sub OnErrorReceived(ByVal e As WinsockErrorReceivedEventArgs)
    ''' <summary>
    ''' Raises the ReceiveProgress event.
    ''' </summary>
    Sub OnReceiveProgress(ByVal e As WinsockReceiveProgressEventArgs)
    ''' <summary>
    ''' Raises the SendComplete event.
    ''' </summary>
    Sub OnSendComplete(ByVal e As WinsockSendEventArgs)
    ''' <summary>
    ''' Raises the SendProgress event.
    ''' </summary>
    Sub OnSendProgress(ByVal e As WinsockSendEventArgs)
    ' '' <summary>
    ' '' Raises the StateChanged event.
    ' '' </summary>
    'Sub OnStateChanged(ByVal e As WinsockStateChangedEventArgs)

#End Region

#Region " Properties "

    Property LegacySupport() As Boolean
    Property Protocol() As WinsockProtocol
    Property RemoteHost() As String
    Property RemotePort() As Integer
    ''' <summary>
    ''' Gets the state of the <see cref="Winsock">Winsock</see> control.
    ''' </summary>
    ReadOnly Property State() As WinsockStates

#End Region

    ''' <summary>
    ''' Encapsulates the OnStateChanged methods so the AsyncSocket
    ''' doesn't have to build the EventArgs parameter all the time.
    ''' </summary>
    ''' <param name="new_state">The new state of the Winsock.</param>
    Sub ChangeState(ByVal new_state As WinsockStates)

    ''' <summary>
    ''' When the port is set dynamically by using port 0, the socket can now update the property of the component.
    ''' </summary>
    ''' <param name="new_port">The port we are now listening on.</param>
    Sub ChangeLocalPort(ByVal new_port As Integer)
End Interface