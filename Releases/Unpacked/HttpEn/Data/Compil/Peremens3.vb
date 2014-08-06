' МОДУЛЬ ДЛЯ ОБХОДА ОТЛИЧИЙ МЕЖДУ СРЕДОЙ РАЗРАБОТКИ И КОМПИЛЯТОРОМ
Public Module peremens2
    Public MnFrm As Object ' Главная форма
    Public MnFrmPotok As mainClass ' Главная форма
    Public MainForm, WindowsApplication1 As Object

    Public proj As Object  ' Проект, сейчас запущенный

    Public CreateDs As Object
    Public CreateIfs As Object
    Public CreateCycles As Object
    Public EditPrComm As Object

    Public intr As Object
    Public ProgressForm As New Progress

    Class Blok
        Sub New(ByVal a, ByVal b)
        End Sub
    End Class
    Class Master
        Inherits Control
        Sub New(ByVal a, ByVal b)
        End Sub
        Sub Ok_Click(ByVal a, ByVal b)
        End Sub
    End Class
    ' Класс на случай запуска в многопоточном режиме
    Class mainClass
        Public Sub RunProj_NodeStop(ByVal objs As Object)
            RunProj_NodeStop(objs(0), objs(1))
        End Sub
        Public Sub RunProj_NodeStop(ByVal node As TreeNode, ByVal param As PropertysSobyt)
            Dim f As Object = My.Forms
            f.Main1.RunProj_NodeStop(node, param)
        End Sub
    End Class
    Public Sub WebBrowser_NewWindowNado(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If proj.Param.ParamyUp Is Nothing = False Then
            If proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить в новом окне"))) = trans("Да") Then
                proj.Param.ParamyUp(UCase(MyZnak & trans("Отменить в новом окне"))) = ""
                e.Cancel = True : Exit Sub
            End If
        ElseIf e.Cancel = True Then
            Exit Sub
        End If
        If e.Cancel = False Then
            If UCase(sender.Props.OpenNewWindowLink) = UCase(trans("В данном браузере")) Then
                sender.Navigate(sender.lastLink)
                e.Cancel = True
            ElseIf UCase(sender.Props.OpenNewWindowLink) = UCase(trans("По умолчанию")) Then
            Else
                ' Пробуем получить переданный браузер
                Dim brws As Object = RunProj.GetObjFromUniqName(sender.Props.OpenNewWindowLink)
                If brws Is Nothing Then Errors.MessangeExclamen(Errors.InvalidWebBrowser(sender.Props.OpenNewWindowLink)) : Exit Sub
                brws.props.Url = sender.lastLink
                e.Cancel = True
            End If
        End If
    End Sub
    Class EditProperty

    End Class
    Sub ShowPropInEditProperty(ByVal o As Object)

    End Sub

    Public Class ClientServerMy
        Inherits Control
    End Class
    Public Class InternetControl
        Inherits Control
    End Class
End Module
