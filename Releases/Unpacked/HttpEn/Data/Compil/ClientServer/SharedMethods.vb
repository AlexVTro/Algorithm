Imports System.Net.Sockets

''' <summary>
''' This call contains shared methods that any class can use.
''' </summary>
Public Class SharedMethods

    ''' <summary>
    ''' Raises an error on the parent Winsock object.
    ''' </summary>
    ''' <param name="iParent">The parent Winsock object to raise the error on.</param>
    ''' <param name="msg">A String containing a message describing the error being raised.</param>
    Protected Friend Shared Sub RaiseError(ByRef iParent As IWinsock, ByVal msg As String)
        ' First use the StackTrace to get the calling class and function.
        Dim CurrentStack As New System.Diagnostics.StackTrace()
        Dim callingFunction As String = CurrentStack.GetFrame(1).GetMethod.Name
        Dim callingClass As String = CurrentStack.GetFrame(1).GetMethod.DeclaringType.ToString()
        Dim caller As String = CStr(IIf(callingFunction.StartsWith("."), callingClass & callingFunction, callingClass & "." & callingFunction))
        ' Create the event arguement
        Dim e As New WinsockErrorReceivedEventArgs(msg, caller)
        ' Raise the event only if there really is a parent
        If iParent IsNot Nothing Then
            iParent.OnErrorReceived(e)
        End If
    End Sub

    ''' <summary>
    ''' Raises an error on the parent Winsock object.
    ''' </summary>
    ''' <param name="iParent">The parent Winsock object to raise the error on.</param>
    ''' <param name="msg">A String containing a message describing the error being raised.</param>
    ''' <param name="details">A String containing extra details describing the error being raised.</param>
    Protected Friend Shared Sub RaiseError(ByRef iParent As IWinsock, ByVal msg As String, ByVal details As String)
        ' First use the StackTrace to get the calling class and function
        Dim CurrentStack As New System.Diagnostics.StackTrace()
        Dim callingFunction As String = CurrentStack.GetFrame(1).GetMethod.Name
        Dim callingClass As String = CurrentStack.GetFrame(1).GetMethod.DeclaringType.ToString()
        Dim caller As String = CStr(IIf(callingFunction.StartsWith("."), callingClass & callingFunction, callingClass & "." & callingFunction))
        ' Create the event arguement
        Dim e As New WinsockErrorReceivedEventArgs(msg, caller, details)
        ' Raise the event only if there really is a parent
        If iParent IsNot Nothing Then
            iParent.OnErrorReceived(e)
        End If
    End Sub

    ''' <summary>
    ''' Raises an error on the parent Winsock object.
    ''' </summary>
    ''' <param name="iParent">The parent Winsock object to raise the error on.</param>
    ''' <param name="msg">A String containing a message describing the error being raised.</param>
    ''' <param name="details">A String containing extra details describing the error being raised.</param>
    ''' <param name="errCode">A value containing the socket's error code.</param>
    Protected Friend Shared Sub RaiseError(ByRef iParent As IWinsock, ByVal msg As String, ByVal details As String, ByVal errCode As SocketError)
        ' First use the StackTrace to get the calling class and function
        Dim CurrentStack As New System.Diagnostics.StackTrace()
        Dim callingFunction As String = CurrentStack.GetFrame(1).GetMethod.Name
        Dim callingClass As String = CurrentStack.GetFrame(1).GetMethod.DeclaringType.ToString()
        Dim caller As String = CStr(IIf(callingFunction.StartsWith("."), callingClass & callingFunction, callingClass & "." & callingFunction))
        ' Create the event arguement
        Dim e As New WinsockErrorReceivedEventArgs(msg, caller, details, errCode)
        ' Raise the event only if there really is a parent
        If iParent IsNot Nothing Then
            iParent.OnErrorReceived(e)
        End If
    End Sub

    ''' <summary>
    ''' Removes items from the beginning of an array.
    ''' </summary>
    Protected Friend Shared Function ShrinkArray(Of arrayType)(ByRef arr() As arrayType, ByVal desiredLengthToTrim As Integer) As arrayType()
        ' Grab desired length from array - this will be returned
        Dim retArr(desiredLengthToTrim - 1) As arrayType
        Array.Copy(arr, 0, retArr, 0, desiredLengthToTrim)
        ' Trim what we grabbed out of the array
        Dim tmpArr(arr.GetUpperBound(0) - desiredLengthToTrim) As arrayType
        Array.Copy(arr, desiredLengthToTrim, tmpArr, 0, arr.Length - desiredLengthToTrim)
        arr = DirectCast(tmpArr.Clone(), arrayType())
        ' Return the data
        Return retArr
    End Function

End Class
