Public Class Progress
    Public Property ProgressBarValue() As Integer
        Get
            Return ProgressBar1.Value
        End Get
        Set(ByVal value As Integer)
            ProgressBar1.Value = value
        End Set
    End Property
End Class