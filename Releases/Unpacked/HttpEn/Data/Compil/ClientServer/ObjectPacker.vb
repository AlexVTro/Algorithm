Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' Contains function for serializing/deserializing an object to and from a byte array.
''' </summary>
Public Class ObjectPacker

    ''' <summary>
    ''' Serializes an object to a byte array.
    ''' </summary>
    ''' <param name="obj">The object to be serialized.</param>
    Public Shared Function GetBytes(ByVal obj As Object) As Byte()
        If obj.GetType Is GetType(Byte).MakeArrayType Then
            Return CType(obj, Byte())
        End If
        Dim ret() As Byte = Nothing
        Dim blnRetAfterClose As Boolean = False
        Dim ms As New MemoryStream()
        Dim tip As System.Type
        If obj.GetType Is "".GetType Then
            tip = "".GetType
        Else
            tip = (New WinsockFileData).GetType
        End If
        'Dim bf As New BinaryFormatter
        Dim bf As New XmlSerializer(tip)
        Try
            bf.Serialize(ms, obj)
        Catch ex As Exception
            blnRetAfterClose = True
        Finally
            ms.Close()
        End Try
        If blnRetAfterClose Then Return ret
        ret = ms.ToArray()
        Return ret
    End Function

    ''' <summary>
    ''' Deserializes an object from a byte array.
    ''' </summary>
    ''' <param name="byt">The byte array from which to obtain the object.</param>
    Public Shared Function GetObject(ByVal byt() As Byte) As Object
        Dim ms As New MemoryStream(byt, False)
        Dim ms2 As New MemoryStream(byt, False)
        'Dim bf As New BinaryFormatter
        Dim bf As New XmlSerializer(GetType(String))
        Dim bf2 As New XmlSerializer(GetType(WinsockFileData))
        Dim x As Object
        Try
            x = bf.Deserialize(ms)
        Catch ex As Exception
            Try
                x = bf2.Deserialize(ms2)
            Catch ex2 As Exception
                x = byt
            Finally
                ms.Close()
                ms2.Close()
            End Try
        Finally
            ms.Close()
            ms2.Close()
        End Try
        Return x
    End Function

End Class
