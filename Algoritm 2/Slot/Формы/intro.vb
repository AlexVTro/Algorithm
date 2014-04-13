Public Class intro
    Public Property ProgressBarValue() As Integer
        Get
            Return ProgressBar1.Value
        End Get
        Set(ByVal value As Integer)
            ProgressBar1.Value = value
        End Set
    End Property

    Private Sub intro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VerLabel.Text = AppNameWithVersion
        Panel1.BackgroundImage = Image.FromFile(OblozhkaPath)
    End Sub
End Class