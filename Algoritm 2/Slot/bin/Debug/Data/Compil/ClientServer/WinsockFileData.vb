''' <summary>
''' A class that wraps a file allowing you to serialize it for transport.
''' </summary>
<Serializable()> _
Public Class WinsockFileData

#Region " Private Members "

    Private _fileData() As Byte ' Stores the file data
    Private _fileName As String ' Stores the file name

#End Region

#Region " Constructor "

    ''' <summary>
    ''' Initializes a new instance of the WinsockFileData class.
    ''' </summary>
    Public Sub New()
        _fileData = Nothing
        _fileName = Nothing
    End Sub

#End Region

#Region " Properties "

    ''' <summary>
    ''' Gets or sets the name of the file.
    ''' </summary>
    Public Property FileName() As String
        Get
            Return _fileName
        End Get
        Set(ByVal value As String)
            _fileName = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the contents of the file.
    ''' </summary>
    Public Property FileData() As Byte()
        Get
            Return _fileData
        End Get
        Set(ByVal value As Byte())
            _fileData = value
        End Set
    End Property

#End Region

#Region " Methods "

    ''' <summary>
    ''' Saves the file to the specified path.
    ''' </summary>
    ''' <param name="save_path">The full path of the file to save to.</param>
    ''' <param name="append">Whether you want to append the data to the end of an existing file or not.</param>
    Public Sub SaveFile(ByVal save_path As String, Optional ByVal append As Boolean = False)
        Microsoft.VisualBasic.FileIO.FileSystem.WriteAllBytes(save_path, _fileData, append)
    End Sub

    ''' <summary>
    ''' Reads a file into the WinsockFileData class.
    ''' </summary>
    ''' <param name="file_path">The full path of the file you want to read.</param>
    Public Function ReadFile(ByVal file_path As String) As Boolean
        Dim fi As IO.FileInfo = Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(file_path)
        If fi.Exists Then
            ReDim _fileData(0)
            _fileName = fi.Name
            _fileData = Microsoft.VisualBasic.FileIO.FileSystem.ReadAllBytes(fi.FullName)
        Else
            Return False
        End If
        Return True
    End Function

#End Region

End Class
