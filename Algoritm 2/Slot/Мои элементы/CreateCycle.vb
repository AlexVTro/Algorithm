Public Class CreateCycle
    Dim EditPrWhile As EditProperty
    Dim args As New Arguments()
    Public border As Integer = 0
    Public colBorder As Color
    Private Sub CreateIf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EditPrWhile = New EditProperty() : forEditPrWhile.Controls.Add(EditPrWhile)
        EditPrWhile.Dock = DockStyle.Fill
        WhileLabel.Text = transInfc(WhileLabel.Text)
        EditPrWhile.Text = proj.ActiveForm.obj.Props.name & "." & proj.ActiveForm.obj.Props.name & "." & _
            trans("Текст") & " = " & proj.ActiveForm.obj.Props.name & "." & proj.ActiveForm.obj.Props.name & _
            "." & trans("Текст")
        PalkaWhile.RefreshPic(SkinPictures)
    End Sub

    Public Function getText() As String
        Return Text
    End Function
    Public Property Text() As String
        Get
            Dim txt As String = EditPrWhile.Text
            If bistro_orfo = False Then txt = New CodeString(EditPrWhile.Text).Text
            Return SozdatKluchSlova("While", txt)
        End Get
        Set(ByVal value As String)
            If EditPrWhile Is Nothing Then Exit Property
            value = UbratKluchSlova("While", value)
            EditPrWhile.Text = value
        End Set
    End Property

    Private Sub PalkaWhile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PalkaWhile.click
        Dim master As New Master(New MasterPattern(EditPrWhile, , , True))
        master.ShowDialog(Me.TopLevelControl)
    End Sub

End Class
