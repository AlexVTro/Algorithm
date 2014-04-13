Imports System.ComponentModel

''' <summary>
''' A collection of Winsock objects.
''' </summary>
Public Class WinsockCollection
    Inherits CollectionBase


#Region " Private Members "

    ' These two hashtables store the key's and the values.
    ' The base class's List store the string that ties the
    '  keys to the values
    Private _keys As Hashtable
    Private _values As Hashtable

    ' These are for auto removal of the Winsock object
    '  when the Winsock's Disconnected event is raised.
    Private _autoRemoval As Queue
    Private _autoRemove As Boolean = False

    ' These are for timing and removal of every Winsock
    '  object in the collection - only used when the
    '  Clear() method is run.
    Private _clearRemoval As Queue
    Private _clearRemove As Boolean = False
    Private _clearOK As Boolean = False

    ' Allows LegacySupport to work in a multi-client
    '  environment
    Private _legacySupport As Boolean = False

#End Region

#Region " Constructor "

    ''' <summary>
    ''' Initializes a new instance of the WinsockCollection class.
    ''' </summary>
    ''' <param name="auto_remove">
    ''' Determines if the collection should automatically remove the
    ''' connection when the Disconnected event is fired.
    ''' </param>
    ''' <param name="legacy_support">
    ''' Enables LegacySupport for connections accepted using the
    ''' collections Accept method.
    ''' </param>
    Public Sub New(Optional ByVal auto_remove As Boolean = False, Optional ByVal legacy_support As Boolean = False)
        _keys = New Hashtable
        _values = New Hashtable
        _autoRemoval = New Queue
        _autoRemove = auto_remove
        _clearRemoval = New Queue
        _legacySupport = legacy_support
    End Sub

#End Region

#Region " Overriden Methods "

    ''' <summary>
    ''' Run when the base class's list is finished clearing.
    ''' Triggers clearing of the keys and values - closing
    ''' all connections.
    ''' </summary>
    Protected Overrides Sub OnClearComplete()
        MyBase.OnClearComplete()
        _keys.Clear()
        Dim b As Boolean = _autoRemove : _autoRemove = False
        _clearOK = False
        _clearRemove = True
        For Each wsk As Winsock In _values.Values
            wsk.Close()
        Next
        _clearOK = True
        _autoRemove = b
    End Sub

    ''' <summary>
    ''' Causes the CountChanged event to be triggered when an item is added to the collection.
    ''' </summary>
    Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
        MyBase.OnInsertComplete(index, value)
        OnCountChanged(List.Count - 1, List.Count)
    End Sub

    ''' <summary>
    ''' Causes the CountChanged event to be triggered when an item is removed from the collection.
    ''' </summary>
    Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
        MyBase.OnRemoveComplete(index, value)
        OnCountChanged(List.Count + 1, List.Count)
    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Run during the Clearing of the collection.
    ''' The method actually clears the values safely
    ''' so as not to cause exceptions.  Triggered via
    ''' the last Disconnected event.
    ''' </summary>
    Private Sub ClearAllValues()
        While _values.Count > 0
            If _clearOK AndAlso _clearRemoval.Count > 0 Then
                Dim i As Integer = _values.Count
                Dim gid2Rem As String = CType(_clearRemoval.Dequeue(), String)
                _values.Remove(gid2Rem)
                OnCountChanged(i, _values.Count)
            End If
        End While
    End Sub

    ''' <summary>
    ''' Attemps to retrieve the string of the item at the index specified.
    ''' </summary>
    ''' <param name="index">The zero-based index of the string you are attempting to find.</param>
    Private Function getGID(ByVal index As Integer) As String
        Return CType(List.Item(index), String)
    End Function

    ''' <summary>
    ''' Attempts to retrieve the string of the item using the Key given to the item.
    ''' </summary>
    ''' <param name="key">The key whose string you are looking for.</param>
    Private Function getGID(ByVal key As Object) As String
        For Each gid As String In _keys.Keys
            If Object.ReferenceEquals(_keys(gid), key) Then Return gid
        Next
        Return String.Empty
    End Function

    ''' <summary>
    ''' Removes the given string and it's ties from the collections.
    ''' </summary>
    ''' <param name="gid">The string to remove.</param>
    Private Sub RemoveGID(ByVal gid As String)
        If gid <> String.Empty Then
            CType(_values(gid), Winsock).Dispose()
            _values.Remove(gid)
            _keys.Remove(gid)
            List.Remove(gid)
        End If
    End Sub

    ''' <summary>
    ''' Adds a winsock value to the collection.
    ''' </summary>
    ''' <param name="gid">The string of the object.</param>
    ''' <param name="key">The Key of the object (may be nothing).</param>
    ''' <param name="value">The Winsock that is to be added to the collection.</param>
    ''' <remarks>Attaches handlers to each Winsock event so the collection can act as a proxy.</remarks>
    Private Sub Add(ByVal gid As String, ByVal key As Object, ByVal value As Winsock)
        AddHandler value.Connected, AddressOf OnConnected
        AddHandler value.ConnectionRequest, AddressOf OnConnectionRequest
        AddHandler value.DataArrival, AddressOf OnDataArrival
        AddHandler value.Disconnected, AddressOf OnDisconnected
        AddHandler value.ErrorReceived, AddressOf OnErrorReceived
        AddHandler value.SendComplete, AddressOf OnSendComplete
        AddHandler value.SendProgress, AddressOf OnSendProgress
        AddHandler value.StateChanged, AddressOf OnStateChanged
        _keys.Add(gid, key)
        _values.Add(gid, value)
        List.Add(gid)
    End Sub

    ''' <summary>
    ''' Method to remove an object automatically - threaded to avoid problems.
    ''' </summary>
    Private Sub RemovalThread()
        Threading.Thread.Sleep(50)
        Dim gid As String = CType(_autoRemoval.Dequeue(), String)
        RemoveGID(gid)
    End Sub

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Retrieves the string assigned to the specified Winsock object in the collection.
    ''' </summary>
    ''' <param name="value">The Winsock object to find the string of.</param>
    Public Function findGID(ByVal value As Winsock) As String
        If Not ContainsValue(value) Then Return String.Empty
        For Each gid As String In _values.Keys
            If Object.ReferenceEquals(_values(gid), value) Then Return gid
        Next
        Return String.Empty
    End Function

    ''' <summary>
    ''' Retrieves the Key assigned to the specified Winsock object in the collection.
    ''' </summary>
    ''' <param name="value">The Winsock object to find the Key of.</param>
    ''' <returns>The key object that was assigned to the Winsock - may be Nothing.</returns>
    Public Function findKey(ByVal value As Winsock) As Object
        Dim gid As String = findGID(value)
        If gid = String.Empty Then Return Nothing
        Return _keys(gid)
    End Function

    ''' <summary>
    ''' Determines if the collection contains the key specified.
    ''' </summary>
    ''' <param name="key">The key to search the collection for.</param>
    Public Function ContainsKey(ByVal key As Object) As Boolean
        If key Is Nothing Then
            Throw New ArgumentNullException("key")
        End If
        Return _keys.ContainsValue(key)
    End Function

    ''' <summary>
    ''' Determines if the collection contains the specified value.
    ''' </summary>
    ''' <param name="value">The value to search the collection for.</param>
    Public Function ContainsValue(ByVal value As Winsock) As Boolean
        Return _values.ContainsValue(value)
    End Function

    ''' <summary>
    ''' Removes the value at the specified index.  Use this instead of RemoveAt.
    ''' </summary>
    ''' <param name="index">The zero-based index of the item you wish to remove.</param>
    Public Sub Remove(ByVal index As Integer)
        Dim gid As String = getGID(index)
        RemoveGID(gid)
    End Sub

    ''' <summary>
    ''' Removes the value with the specified key.
    ''' </summary>
    ''' <param name="key">The key of the value you wish to remove.</param>
    Public Sub Remove(ByVal key As Object)
        If TypeOf (key) Is Integer Then
            Dim gidIndex As String = getGID(CInt(key))
            RemoveGID(gidIndex)
            Exit Sub
        End If
        If Not ContainsKey(key) Then Exit Sub
        Dim gid As String = getGID(key)
        RemoveGID(gid)
    End Sub

    ''' <summary>
    ''' Removes the value with the specified string.
    ''' </summary>
    ''' <param name="gid">The string of the value you wish to remove.</param>
    Public Sub Remove(ByVal gid As String)
        RemoveGID(gid)
    End Sub

    
    Public Sub ChangeKey(ByVal Oldkey As String, ByVal Newkey As String)
        Dim winsk As Winsock = Item(Oldkey)
        _values.Remove(Oldkey)
        _keys.Remove(Oldkey)
        MyBase.InnerList.Remove(Oldkey)
        _keys.Add(Newkey, Newkey)
        _values.Add(Newkey, winsk)
        MyBase.InnerList.Add(Newkey)
        'list
    End Sub

    ''' <summary>
    ''' Adds a value to the collection.
    ''' </summary>
    ''' <param name="value">The Winsock object to add to the collection.</param>
    ''' <returns>Returns the string assigned to the element.</returns>
    Public Function Add(ByVal value As Winsock) As String
        Dim gid As String = Guid.NewGuid.ToString()
        Add(gid, Nothing, value)
        Return gid
    End Function
    ''' <summary>
    ''' Adds a value to the collection.
    ''' </summary>
    ''' <param name="value">The Winsock object to add to the collection.</param>
    ''' <param name="key">The Key of the element to add.</param>
    ''' <returns>Returns the string assigned to the element.</returns>
    Public Function Add(ByVal value As Winsock, ByVal key As Object) As String
        Dim gid As String = key
        Add(gid, key, value)
        Return gid
    End Function

    ''' <summary>
    ''' Accepts an incoming connection and adds it to the collection.
    ''' </summary>
    ''' <param name="client">The client to accept.</param>
    ''' <returns>Returns the string assigned to the element.</returns>
    Public Function Accept(ByVal client As System.Net.Sockets.Socket) As String
        Dim wsk As New Winsock()
        wsk.LegacySupport = _legacySupport
        Dim gid As String = Add(wsk, Nothing)
        wsk.Accept(client)
        Return gid
    End Function
    ''' <summary>
    ''' Accepts an incoming connection and adds it to the collection.
    ''' </summary>
    ''' <param name="client">The client to accept.</param>
    ''' <param name="key">The Key of the element to add.</param>
    ''' <returns>Returns the string assigned to the element.</returns>
    Public Function Accept(ByVal client As System.Net.Sockets.Socket, ByVal key As Object) As String
        Dim wsk As New Winsock()
        wsk.LegacySupport = _legacySupport
        Dim gid As String = Me.Add(wsk, key)
        wsk.Accept(client)
        Return gid
    End Function

    ''' <summary>
    ''' Connects to a remote host and adds it to the collection.
    ''' </summary>
    ''' <param name="remoteHostOrIP">A <see cref="System.String" /> containing the Hostname or IP address of the remote host.</param>
    ''' <param name="remotePort">A value indicating the port on the remote host to connect to.</param>
    ''' <returns>Return the string assigned to the element.</returns>
    Public Function Connect(ByVal remoteHostOrIP As String, ByVal remotePort As Integer) As String
        Dim wsk As New Winsock()
        wsk.Protocol = WinsockProtocol.Tcp
        wsk.LegacySupport = _legacySupport
        Dim gid As String = Add(wsk, Nothing)
        CType(_values(gid), Winsock).Connect(remoteHostOrIP, remotePort)
    End Function
    ''' <summary>
    ''' Connects to a remote host and adds it to the collection.
    ''' </summary>
    ''' <param name="remoteHostOrIP">A <see cref="System.String" /> containing the Hostname or IP address of the remote host.</param>
    ''' <param name="remotePort">A value indicating the port on the remote host to connect to.</param>
    ''' <param name="key">The Key of the element to add.</param>
    ''' <returns>Return the string assigned to the element.</returns>
    Public Function Connect(ByVal remoteHostOrIP As String, ByVal remotePort As Integer, ByVal key As Object) As String
        Dim wsk As New Winsock()
        wsk.Protocol = WinsockProtocol.Tcp
        wsk.LegacySupport = _legacySupport
        Dim gid As String = Add(wsk, key)
        CType(_values(gid), Winsock).Connect(remoteHostOrIP, remotePort)
    End Function

    ''' <summary>
    ''' Gets an Array of all the remote IP addresses of each connection in this collection.
    ''' </summary>
    Public Function GetRemoteIPs() As ArrayList
        Dim ar As New ArrayList
        For Each key As Object In _values.Keys
            ar.Add(CType(_values(key), Winsock).RemoteHost)
        Next
        Return ar
    End Function

#End Region

#Region " Public Properties "

    ''' <summary>
    ''' Gets a Collection containing all the keys in this collection.
    ''' </summary>
    Public ReadOnly Property Keys() As System.Collections.ICollection
        Get
            Return _keys.Values()
        End Get
    End Property

    ''' <summary>
    ''' Gets a Collection containing all the values in this collection.
    ''' </summary>
    Public ReadOnly Property Values() As System.Collections.ICollection
        Get
            Return _values.Values
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the Winsock at the specified index.
    ''' </summary>
    ''' <param name="index">A zero-based index of the Winsock to get or set.</param>
    Default Public Property Item(ByVal index As Integer) As Winsock
        Get
            Dim gid As String = getGID(index)
            Return CType(_values(gid), Winsock)
        End Get
        Set(ByVal value As Winsock)
            Dim gid As String = getGID(index)
            If Not _values.ContainsKey(gid) Then
                Add(gid, Nothing, value)
            Else
                _values(gid) = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the Winsock associated with the specified key.
    ''' </summary>
    ''' <param name="key">The key whose value to get or set.</param>
    Default Public Property Item(ByVal key As Object) As Winsock
        Get
            Dim gid As String = getGID(key)
            Return CType(_values(gid), Winsock)
        End Get
        Set(ByVal value As Winsock)
            Dim gid As String = getGID(key)
            If Not _values.ContainsKey(gid) Then
                Add(gid, Nothing, value)
            Else
                _values(gid) = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the Winsock associated with the specified string.
    ''' </summary>
    ''' <param name="gid">The string whose value to get or set.</param>
    Default Public Property Item(ByVal gid As String) As Winsock
        Get
            Dim aa(9) As Object
            _values.Keys.CopyTo(aa, 0)
            Return CType(_values(gid), Winsock)
        End Get
        Set(ByVal value As Winsock)
            If Not _values.ContainsKey(gid) Then
                Add(gid, Nothing, value)
            Else
                _values(gid) = value
            End If
        End Set
    End Property

#End Region

#Region " Events "

    ''' <summary>
    ''' Occurs when connection is achieved (client and server).
    ''' </summary>
    Public Event Connected(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs)
    ''' <summary>
    ''' Occurs on the server when a client is attempting to connect.
    ''' </summary>
    ''' <remarks>Client registers connected at this point. Server must Accept in order for it to be connected.</remarks>
    Public Event ConnectionRequest(ByVal sender As Object, ByVal e As WinsockConnectionRequestEventArgs)
    ''' <summary>
    ''' Occurs when the number of items in the collection has changed.
    ''' </summary>
    Public Event CountChanged(ByVal sender As Object, ByVal e As WinsockCollectionCountChangedEventArgs)
    ''' <summary>
    ''' Occurs when data arrives on the socket.
    ''' </summary>
    ''' <remarks>Raised only after all parts of the data have been collected.</remarks>
    Public Event DataArrival(ByVal sender As Object, ByVal e As WinsockDataArrivalEventArgs)
    ''' <summary>
    ''' Occurs when disconnected from the remote computer (client and server).
    ''' </summary>
    Public Event Disconnected(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Occurs when an error is detected in the socket.
    ''' </summary>
    ''' <remarks>May also be raised on disconnected (depending on disconnect circumstance).</remarks>
    Public Event ErrorReceived(ByVal sender As Object, ByVal e As WinsockErrorReceivedEventArgs)
    ''' <summary>
    ''' Occurs when sending of data is completed.
    ''' </summary>
    Public Event SendComplete(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
    ''' <summary>
    ''' Occurs when the send buffer has been sent but not all the data has been sent yet.
    ''' </summary>
    Public Event SendProgress(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
    ''' <summary>
    ''' Occurs when the state of the socket changes.
    ''' </summary>
    Public Event StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs)

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
    ''' Raises the Connected event.
    ''' </summary>
    Protected Friend Sub OnConnected(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs)
        RaiseEventSafe(ConnectedEvent, New Object() {sender, e})
    End Sub

    ''' <summary>
    ''' Raises the ConnectionRequest event, and closes the socket if the ConnectionRequest was rejected.
    ''' </summary>
    Protected Friend Sub OnConnectionRequest(ByVal sender As Object, ByVal e As WinsockConnectionRequestEventArgs)
        RaiseEventSafe(ConnectionRequestEvent, New Object() {sender, e})
    End Sub

    ''' <summary>
    ''' Raises the DataArrival event.
    ''' </summary>
    Protected Friend Sub OnDataArrival(ByVal sender As Object, ByVal e As WinsockDataArrivalEventArgs)
        RaiseEventSafe(DataArrivalEvent, New Object() {sender, e})
    End Sub

    ''' <summary>
    ''' Raises the Disconnected Event.
    ''' </summary>
    Protected Friend Sub OnDisconnected(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEventSafe(DisconnectedEvent, New Object() {sender, e})
        If _clearRemove Then
            Dim gid As String = findGID(CType(sender, Winsock))
            _clearRemoval.Enqueue(gid)
            If _clearRemoval.Count = _values.Count Then
                Dim thd As New Threading.Thread(AddressOf ClearAllValues)
                thd.Start()
                _clearRemove = False
            End If
        ElseIf _autoRemove Then
            Dim gid As String = findGID(CType(sender, Winsock))
            _autoRemoval.Enqueue(gid)
            Dim thd As New Threading.Thread(AddressOf RemovalThread)
            thd.Start()
        End If
    End Sub

    ''' <summary>
    ''' Raises the ErrorReceived event.
    ''' </summary>
    Protected Friend Sub OnErrorReceived(ByVal sender As Object, ByVal e As WinsockErrorReceivedEventArgs)
        RaiseEventSafe(ErrorReceivedEvent, New Object() {sender, e})
    End Sub

    ''' <summary>
    ''' Raises the SendComplete event.
    ''' </summary>
    Protected Friend Sub OnSendComplete(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
        RaiseEventSafe(SendCompleteEvent, New Object() {sender, e})
    End Sub

    ''' <summary>
    ''' Raises the SendProgress event.
    ''' </summary>
    Protected Friend Sub OnSendProgress(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
        RaiseEventSafe(SendProgressEvent, New Object() {sender, e})
    End Sub

    ''' <summary>
    ''' Raises the StateChanged event.
    ''' </summary>
    Protected Friend Sub OnStateChanged(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs)
        RaiseEventSafe(StateChangedEvent, New Object() {sender, e})
    End Sub

    ''' <summary>
    ''' Raises the count changed event.
    ''' </summary>
    Private Sub OnCountChanged(ByVal old_count As Integer, ByVal new_count As Integer)
        Dim e As New WinsockCollectionCountChangedEventArgs(old_count, new_count)
        RaiseEventSafe(CountChangedEvent, New Object() {Me, e})
    End Sub

#End Region

End Class