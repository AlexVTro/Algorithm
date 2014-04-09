''' <summary>
''' Represents both a last-in, first-out (LIFO) and a first-in, first-out (FIFO) non-generic collection of objects.
''' </summary>
''' <remarks>
''' While the System.Collections.Stack and the System.Collections.Queue
''' have seemingly different ways of operating, they can be combined easily
''' by just manipulating the way in which an item in inserted into the list.
''' 
''' This allows the removal from the list to remain the same, whether you
''' are treating this class like a Stack or a Queue.  The also allows the
''' Peek() method to work for both at the same time.
''' 
''' Helping tidbit - Deque is pronounced like "deck."
''' </remarks>
Public Class Deque
    Implements ICollection, IEnumerable, ICloneable

#Region " Private Members "

    ''' <summary>
    ''' Stores the list of items within this instance.
    ''' </summary>
    Private llList As System.Collections.Generic.LinkedList(Of Object)

#End Region

#Region " Constructor "

    ''' <summary>
    ''' Initializes a new instance of the Deque class that is empty and has the default initial capacity.
    ''' </summary>
    Public Sub New()
        llList = New System.Collections.Generic.LinkedList(Of Object)
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the Deque class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
    ''' </summary>
    ''' <param name="col">The collection whose elements are copied to the new Deque.</param>
    Public Sub New(ByVal col As ICollection)
        llList = New System.Collections.Generic.LinkedList(Of Object)(CType(col, System.Collections.Generic.IEnumerable(Of Object)))
    End Sub

#End Region

#Region " Interface Method Implementations "

    ''' <summary>
    ''' Copies the entire Deque to a compatible one-dimensional array, starting at the specified index of the target array.
    ''' </summary>
    ''' <param name="array">The one-dimensional Array that is the destination of the elements copied from Deque. The Array must have zero-based indexing.</param>
    ''' <param name="index">The zero-based index in array at which copying begins.</param>
    Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
        If array.Rank > 1 Then Throw New ArgumentException("Array must have only a single dimension.", "array")
        llList.CopyTo(CType(array, Object()), index)
    End Sub

    ''' <summary>
    ''' Gets the number of elements actually contained in the Deque.
    ''' </summary>
    ''' <value>The number of elements actually contained in the Deque.</value>
    Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
        Get
            Return llList.Count
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating whether access to the ICollection is synchronized (thread safe).
    ''' </summary>
    ''' <value>true if access to the ICollection is synchronized (thread safe); otherwise, false. In the default implementation of List, this property always returns false.</value>
    Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
        Get
            Return CType(llList, ICollection).IsSynchronized
        End Get
    End Property

    ''' <summary>
    ''' Gets an object that can be used to synchronize access to the ICollection.
    ''' </summary>
    ''' <value>An object that can be used to synchronize access to the ICollection. In the default implementation of List, this property always returns the current instance.</value>
    Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
        Get
            Return CType(llList, ICollection).SyncRoot
        End Get
    End Property

    ''' <summary>
    ''' Returns an enumerator that iterates through the Queue.
    ''' </summary>
    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return llList.GetEnumerator()
    End Function

    ''' <summary>
    ''' Creates a shallow copy of the Queue.
    ''' </summary>
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return New Deque(llList)
    End Function

#End Region

#Region " Methods common to both Queues and Stacks "

    ''' <summary>
    ''' Removes all elements from the Deque.
    ''' </summary>
    Public Sub Clear()
        llList.Clear()
    End Sub

    ''' <summary>
    ''' Determines whether an element is in the Deque.
    ''' </summary>
    ''' <param name="obj">The object to locate in the Deque. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
    Public Function Contains(ByVal obj As Object) As Boolean
        Return llList.Contains(obj)
    End Function

    ''' <summary>
    ''' Returns the object at the beginning (top) of the Deque without removing it.
    ''' </summary>
    ''' <returns>The object at the beginning (top) of the Deque.</returns>
    Public Function Peek(Of dataType)() As dataType
        If llList.Count = 0 Then Return Nothing
        Return DirectCast(llList.First().Value, dataType)
    End Function

    ''' <summary>
    ''' Copies the elements of the Deque to a new array.
    ''' </summary>
    ''' <returns>An array containing copies of the elements of the Deque.</returns>
    Public Function ToArray() As Object()
        Dim retObj(llList.Count - 1) As Object
        Dim i As Integer = 0
        For Each obj As Object In llList
            retObj(i) = obj
            i += 1
        Next
        Return retObj
    End Function

    ''' <summary>
    ''' Returns a String that represents the current Object.
    ''' </summary>
    ''' <returns>A String that represents the current Object.</returns>
    Public Overrides Function ToString() As String
        Return llList.ToString()
    End Function

#End Region

#Region " Queue methods "

    ''' <summary>
    ''' Removes and returns the object at the beginning of the Deque.
    ''' </summary>
    ''' <returns>The object that is removed from the beginning of the Deque.</returns>
    ''' <remarks>Synonymous with Pop().</remarks>
    Public Function Dequeue(Of dataType)() As dataType
        Dim oRet As dataType = Peek(Of dataType)()
        llList.RemoveFirst()
        Return oRet
    End Function

    ''' <summary>
    ''' Adds an object to the end of the Deque.
    ''' </summary>
    ''' <param name="obj">The object to add to the Deque. The value can be a null reference (Nothing in Visual Basic).</param>
    Public Sub Enqueue(ByVal obj As Object)
        llList.AddLast(obj)
    End Sub

#End Region

#Region " Stack methods "

    ''' <summary>
    ''' Removes and returns the object at the top of the Deque.
    ''' </summary>
    ''' <returns>The Object removed from the top of the Deque.</returns>
    ''' <remarks>Synonymous with Dequeue().</remarks>
    Public Function Pop(Of dataType)() As dataType
        Return Dequeue(Of dataType)()
    End Function

    ''' <summary>
    ''' Inserts an object at the top of the Deque.
    ''' </summary>
    ''' <param name="obj">The Object to push onto the Deque. The value can be a null reference (Nothing in Visual Basic).</param>
    Public Sub Push(ByVal obj As Object)
        llList.AddFirst(obj)
    End Sub

#End Region

End Class