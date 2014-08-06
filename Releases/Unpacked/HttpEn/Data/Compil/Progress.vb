Public Class Progress
    Public Property ProgressBarValue() As Integer
        Get
            Return ProgressBar1.Value
        End Get
        Set(ByVal value As Integer)
            ProgressBar1.Value = value
            Me.TopMost = False
        End Set
    End Property


    Private Sub Progress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Progress_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Me.TopMost = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
    End Sub
End Class