' ОБЪЕКТ СОБЫТИЙ    
#Region "SOBYTIYA"
' ТАК СКАЗАТЬ MyObj МОИХ СОБЫТИЙ.
Public Class Sobitiya
    Inherits Objetus
    Public Propertys(), Methods(), Sobyts() As String ' Все свойства и события данного объекта
    Public PropertysUp(), MethodsUp(), SobytsUp() As String
    Sub New(ByVal sobyt As String)
        ' занести все свойства события sobyt в propertys
        Dim Sobyts As New PropertysSobyt(Nothing, Nothing, Nothing, sobyt)
        ReDim Propertys(Sobyts.Paramy.Count - 1)
        Sobyts.Paramy.Keys.CopyTo(Propertys, 0)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
    End Sub
    Sub New(ByVal param As PropertysSobyt)
        ' занести все свойства события sobyt в propertys
        ReDim Propertys(param.Paramy.Count - 1)
        param.Paramy.Keys.CopyTo(Propertys, 0)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
    End Sub
    Public Function EstProperty(ByVal prop As String) As Boolean
        If PropertysUp Is Nothing Then Return False
        If Array.IndexOf(PropertysUp, prop) <> -1 Then Return True
        Return False
    End Function
End Class
#End Region

' ПОЛЕЗНЫЕ ОБЪЕКТЫ
#Region "POLEZNIE"
' ТАК СКАЗАТЬ Obj ВСЕХ ПОЛЕЗНЫХ ОБЪЕКТОВ
Public Class PoleznieObj
    Inherits Windows.Forms.Control
    Public TypeObj As String = "Polezniy"
    Public Props As New PropertysOther(Me)
    Public MyObj As Object
    Public defaultName As String
    Public LastProp As String
    Public LastSobyt As String
    Public LastObj As String
    Sub New(ByVal n As String)
        Props.Name = n
    End Sub
End Class
' ТАК СКАЗАТЬ MyObj ВСЕХ ПОЛЕЗНЫХ ОБЪЕКТОВ
Public Class Poleznie
    Inherits Objetus
    Public Propertys(), Sobyts(), Methods() As String ' Все свойства объекта
    Public PropertysUp(), SobytsUp(), MethodsUp(), type As String

    Sub New(ByVal tip As String)
        type = tip
        CreateObject(New PoleznieObj(type)) ' Создать контрол
        obj.defaultName = tip

        Select Case type
            Case MyZnak & trans("Экран")
                Dim tempP() As String = {MyZnak & trans("Рисунок рабочего стола"), MyZnak & trans("Стиль рабочего стола"), _
                    MyZnak & trans("Разрешение экрана"), _
                    MyZnak & trans("Скриншот"), MyZnak & trans("Скриншот объекта"), _
                    MyZnak & trans("Частота экрана"), MyZnak & trans("Качество цветопередачи"), MyZnak & trans("Заставка")}
                'Объект съемки~~Shooting object

                'Сделать скриншот~~ScreenshotToClipboard M
                'Скриншот~~Screenshot RO
                'Сделать скриншот объекта~~ScreenshotOfObjectToClipboard M
                'Скриншот объекта~~ScreenshotOfObject RO
                'Объект на печать~~PrintObject 
                Propertys = tempP
                Dim tempM() As String = {MyZnak & trans("Сделать скриншот")}
                Methods = tempM
                obj.LastProp = MyZnak & trans("Рисунок рабочего стола")
            Case MyZnak & trans("Файлы и папки")
                Dim tempP() As String = {MyZnak & trans("Скрытый"), MyZnak & trans("Только для чтения"), _
                    MyZnak & trans("Архивный"), MyZnak & trans("Папка"), MyZnak & trans("Зашифрованный"), _
                    MyZnak & trans("Не индексируется"), MyZnak & trans("Системный"), MyZnak & trans("Временный"), _
                    MyZnak & trans("Время создания"), MyZnak & trans("Время доступа"), _
                    MyZnak & trans("Время изменения"), MyZnak & trans("Существует файл"), _
                    MyZnak & trans("Существует папка"), MyZnak & trans("Получить файлы"), _
                    MyZnak & trans("Получить папки"), MyZnak & trans("Определить корневую"), _
                    MyZnak & trans("Определить родительскую"), MyZnak & trans("Получить диски"), _
                    MyZnak & trans("Определить имя папки"), MyZnak & trans("Определить имя файла"), _
                    MyZnak & trans("Определить расширение"), MyZnak & trans("Определить без расширения"), _
                    MyZnak & trans("Определить размер файла"), MyZnak & trans("Поиск файлов"), _
                    MyZnak & trans("Открыть файл"), _
                    MyZnak & trans("Количество файлов"), MyZnak & trans("Количество папок") _
                }
                Dim tempM() As String = {MyZnak & trans("Сохранить в файле"), MyZnak & trans("Копировать"), _
                     MyZnak & trans("Зашифровать"), MyZnak & trans("Расшифровать"), MyZnak & trans("Добавить текст"), _
                     MyZnak & trans("Переместить"), MyZnak & trans("Удалить"), MyZnak & trans("Создать папку"), _
                     MyZnak & trans("Сохранить рисунок"), MyZnak & trans("Переименовать"), _
                     MyZnak & trans("Открыть папку") _
                }
                Propertys = tempP
                Methods = tempM
                obj.LastProp = MyZnak & trans("Существует файл")
            Case MyZnak & trans("Прерывания")
                Dim tempP() As String = {}
                Propertys = tempP
                Dim tempM() As String = {MyZnak & trans("Завершить программу"), MyZnak & trans("Завершить событие"), _
                    MyZnak & trans("Завершить цикл"), MyZnak & trans("Пропускать ошибки")}
                Methods = tempM
                obj.LastProp = MyZnak & trans("Завершить программу")
            Case MyZnak & trans("Система")
                Dim tempP() As String = {MyZnak & trans("Мышь X"), MyZnak & trans("Мышь Y"), _
                    MyZnak & trans("Клавиша клавиатуры"), _
                    MyZnak & trans("Нажат альт"), MyZnak & trans("Нажат шифт"), _
                    MyZnak & trans("Нажат контрол"), MyZnak & trans("Нажата мыши левая"), _
                    MyZnak & trans("Нажата мыши правая"), MyZnak & trans("Вращается колесико"), _
                    MyZnak & trans("Рисунок буфера обмена"), MyZnak & trans("Текст буфера обмена"), _
                    MyZnak & trans("Выполнить с результатом"), _
                    MyZnak & trans("Окно в фокусе"), MyZnak & trans("Процессы системы"), _
                    MyZnak & trans("Окна системы") _
                    }
                Dim tempM() As String = {MyZnak & trans("Выполнить"), MyZnak & trans("Очистить буфер обмена"), _
                    MyZnak & trans("Вращать колесико"), MyZnak & trans("Выключить компьютер"), _
                    MyZnak & trans("Перезагрузить компьютер"), MyZnak & trans("Набрать текст"), _
                    MyZnak & trans("Процесс убить") _
                  }
                Propertys = tempP
                Methods = tempM
                obj.LastProp = MyZnak & trans("Выполнить")
            Case MyZnak & trans("Реестр")
                Dim tempP() As String = {MyZnak & trans("Значение реестра"), MyZnak & trans("Ключ существует"), _
                    MyZnak & trans("Папка существует"), MyZnak & trans("Тип ключа") _
                    }
                Dim tempM() As String = {MyZnak & trans("Удалить значение"), MyZnak & trans("Удалить папку"), _
                    MyZnak & trans("Создать подпапку"), MyZnak & trans("Создать ключ") _
                    }
                Propertys = tempP
                Methods = tempM
                obj.LastProp = MyZnak & trans("Значение реестра")
            Case MyZnak & trans("Вызвать событие")
                ' все создается здесь - CreateSobytCalls()
                Propertys = Nothing
                Methods = Nothing
            Case MyZnak & trans("Текст")
                Dim tempP() As String = {MyZnak & trans("Символ по номеру"), MyZnak & trans("Сравнить тексты"), _
                    MyZnak & trans("Поиск в тексте"), MyZnak & trans("Поиск номера строки"), MyZnak & trans("Поиск в тексте с конца"), _
                    MyZnak & trans("Поиск с учетом регистра"), MyZnak & trans("Поиск с регулярными выражениями"), _
                    MyZnak & trans("Количество символов"), MyZnak & trans("Разбить на части"), _
                    MyZnak & trans("Взять кусок текста"), MyZnak & trans("Количество частей текста"), _
                    MyZnak & trans("Кавычки убрать"), MyZnak & trans("Кавычками обособить"), _
                    MyZnak & trans("Поиск без кавычек"), MyZnak & trans("Разбить на части без кавычек"), _
                    MyZnak & trans("Количество частей без кавычек"), _
                    MyZnak & trans("Текст содержит"), MyZnak & trans("Текст не содержит"), _
                    MyZnak & trans("Строка по номеру"), MyZnak & trans("Количество строк"), _
                    MyZnak & trans("Вставить символы в текст"), _
                    MyZnak & trans("Удалить кусок текста"), MyZnak & trans("Заменить"), _
                    MyZnak & trans("Заменить все"), MyZnak & trans("Сделать буквы прописными"), _
                    MyZnak & trans("Сделать буквы заглавными"), MyZnak & trans("Убрать пробелы"), _
                    MyZnak & trans("Убрать пробелы в начале"), MyZnak & trans("Убрать пробелы в конце"), _
                    MyZnak & trans("Текст состоит из"), MyZnak & trans("Текст есть число"), _
                    MyZnak & trans("Текст есть цифры"), _
                    MyZnak & trans("Зашифровать текст"), MyZnak & trans("Расшифровать текст") _
                }
                Dim tempM() As String = {}
                Propertys = tempP
                Methods = tempM
                obj.LastProp = MyZnak & trans("Взять кусок текста")
            Case MyZnak & trans("Показать сообщение")
                Dim tempP() As String = {MyZnak & trans("Была нажата Отмена"), MyZnak & trans("Была нажата Ок") _
                    , MyZnak & trans("Была нажата Повторить"), MyZnak & trans("Была нажата Да") _
                    , MyZnak & trans("Была нажата Нет"), MyZnak & trans("Была нажата Прервать") _
                    , MyZnak & trans("Была нажата Пропустить"), MyZnak & trans("Была нажата Справка") _
                    }
                Dim tempM() As String = {MyZnak & trans("Запустить сообщение") _
                    }
                Propertys = tempP
                Methods = tempM
                obj.LastProp = MyZnak & trans("Запустить сообщение")
            Case MyZnak & trans("Дата")
                Dim tempP() As String = {MyZnak & trans("День месяца"), MyZnak & trans("День года") _
                    , MyZnak & trans("День в неделе"), MyZnak & trans("Час") _
                    , MyZnak & trans("Минута"), MyZnak & trans("Секунда") _
                    , MyZnak & trans("Квартал"), MyZnak & trans("Неделя в году") _
                    , MyZnak & trans("Год"), MyZnak & trans("Месяц"), MyZnak & trans("Время") _
                    , MyZnak & trans("Секунд всего в дате"), MyZnak & trans("Дней в месяце") _
                    , MyZnak & trans("Сейчас"), MyZnak & trans("Сегодня") _
                    , MyZnak & trans("Прибавить дни"), MyZnak & trans("Прибавить часы") _
                    , MyZnak & trans("Прибавить минуты"), MyZnak & trans("Прибавить секунды") _
                    , MyZnak & trans("Прибавить кварталы"), MyZnak & trans("Прибавить недели") _
                    , MyZnak & trans("Прибавить годы"), MyZnak & trans("Прибавить месяцы") _
                    , MyZnak & trans("Разница в днях"), MyZnak & trans("Разница в часах") _
                    , MyZnak & trans("Разница в минутах"), MyZnak & trans("Разница в секундах") _
                    , MyZnak & trans("Разница в кварталах"), MyZnak & trans("Разница в неделях") _
                    , MyZnak & trans("Разница в годах"), MyZnak & trans("Разница в месяцах") _
                    , MyZnak & trans("День недели"), MyZnak & trans("Название месяца") _
                    , MyZnak & trans("Дата в определенном формате") _
                    }
                Dim tempM() As String = {MyZnak & trans("Изменить время компьютера") _
                    }
                Propertys = tempP
                Methods = tempM
                obj.LastProp = MyZnak & trans("Сейчас")
            Case MyZnak & trans("Расширенные возможности")
                Dim tempP() As String = {}
                Dim tempM() As String = {MyZnak & trans("Выполнить код VBScript"), MyZnak & trans("Выполнить код Алгоритма2") _
                    , MyZnak & trans("Выполнить код VBNet"), MyZnak & trans("Выполнить код CSharp") _
                    }
                Propertys = tempP
                Methods = tempM
                obj.LastProp = MyZnak & trans("Выполнить код VBNet")
            Case Else
                Exit Sub
        End Select

        CreatePropertySobytsUp(Me) ' Настроить свойства
    End Sub
    ' Создание списка событий проекта
    Public Sub CreateSobytCalls()
        Dim tempM() As String = Nothing, i As Integer

        ' Чтобы не тормозило по чем зря
        If isDevelop = False And ProjEvents Is Nothing = False Then Exit Sub

        Dim tr As Object = tree
        If isDevelop = False Then tr = RunProj.tree
        Dim Nds() As TreeNode = GetNodesFromTypeTag("Sobyt", tr)
        ' Чтобы не тормозило по чем зря. Если количество событий не изменилось в проекте, то непересоздавать из заново
        If isDevelop And ProjEvents Is Nothing = False And peremens.isRUN Then
            If Nds.Length = ProjEvents.Length Then Exit Sub
        End If
        ' Создание списка событий
        If Nds Is Nothing = False Then
            For i = 0 To Nds.Length - 1
                Dim MyOs() As Object = GetMyObjsFromTreeNode(Nds(i))
                If MyOs Is Nothing = False Then
                    If MyOs(0).GetType.ToString = "System.Windows.Forms.TreeNode" Then Exit Sub
                    Dim frObj As Object = MyOs(0).getMyForm().obj
                    ' составление строки события
                    ReDims(tempM)
                    tempM(tempM.Length - 1) = frObj.name & "_" & MyOs(0).obj.name & "_" & Nds(i).Text
                End If
            Next
        End If

        Methods = tempM : ProjEvents = tempM
        CreatePropertySobytsUp(Me) ' Настроить свойства
    End Sub
End Class

#End Region

' ИНТЕРФЕЙС ДЛЯ СОБЫТИЙ, ИСКУССТВЕННО СОЗДАННЫХ МНОЙ
#Region "INTERFACE"
Interface MyEvents
    Event Created(ByVal sender As Object, ByVal e As EventArgs)
End Interface
Interface MyDialogs
    Property Name() As String
End Interface
#End Region

' ФОРМА FORM
#Region "FORM"
Public Class F
    Inherits Windows.Forms.Panel
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Окно")
    Public LastProp As String = trans("Текст")
    Public LastSobyt As String = trans("Клик")
    Public LastObj As String = ""
    Public Props As New Propertys(Me)
    Public MyObj As Object
    Public StatusTemp As String
    Sub New()
        If proj Is Nothing Then MyBase.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Text = Props.Name : Props.BackColor = ToMyColor(System.Drawing.SystemColors.ControlLight)
        Props.Width = 500 : Props.Height = 320
        Me.Left = formX : Me.Top = formY
        If isRUN() Then
            Me.Visible = False
        Else
            If isDevelop Then Props.BackColor = ToMyColor(SkinColors("FormsColor"))
        End If
    End Sub
    Public Sub Close()
    End Sub
End Class

Class runF
    Inherits Windows.Forms.Form
    Implements MyEvents
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Окно")
    ' Public Event MyFormClosing(ByRef cancel As Boolean)
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Event DoubleClickTray(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Minimize(ByVal sender As Object, ByVal e As EventArgs)
    Public MyObj As Object
    Public StatusTemp As String
    Public ni As New NotifyIcon
    Sub New()
        If isRUN() Then Me.Visible = False
        Me.DoubleBuffered = True
    End Sub
    'Form overrides dispose to clean up the component list.
    'Protected Overrides Sub Dispose(ByVal cancel_disposing As Boolean)
    '    Dim cancel As Boolean
    '    If cancel_disposing = False Then MyBase.Dispose(cancel_disposing) : Exit Sub
    '    RaiseEvent MyFormClosing(cancel)
    '    If cancel = False Then MyBase.Dispose(cancel_disposing) : Exit Sub
    'End Sub
    'Public Sub DisposeMyForm(ByVal cancel_disposing As Boolean)
    '    Dispose(cancel_disposing)
    'End Sub
    Public Shadows Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Props.AddContextMenu(, True) ' Присвоение главного меню
        If StatusTemp IsNot Nothing Then Props.WindowState = StatusTemp
        AddHandler ni.MouseDoubleClick, AddressOf ni_DoubleClickTray
        AddHandler Me.Resize, AddressOf ResizeF
        ' Props.Height = Props.Height + Props.CaptionHeight
    End Sub
    Sub ni_DoubleClickTray(ByVal s As Object, ByVal e As MouseEventArgs)
        RaiseEvent DoubleClickTray(Me, Nothing)
    End Sub
    Sub ResizeF(ByVal s As Object, ByVal e As EventArgs)
        If Props.Sem = False And Me.WindowState = FormWindowState.Minimized Then RaiseEvent Minimize(Me, Nothing)
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class
#End Region

' МЕДИА MEDIAPLAYER
#Region "MEDIAPLAYER"
Public Class Md
    Inherits Windows.Forms.Panel
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Медиа")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Плей")
    Public LastSobyt As String = trans("Конец проигрывания")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName)
        Props.Width = 100 : Props.Height = 80
        Props.MediaWindow = Me : Me.BackColor = Color.Black
    End Sub
End Class

Class runMd
    Inherits Md
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public WithEvents tmr As New Windows.Forms.Timer()
    Public Event OnEnd(ByVal sender As Object, ByVal e As System.EventArgs)
    Sub New()
        tmr.Interval = 100 : tmr.Start()
        Props.strAlias = GetUIN()
    End Sub
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Props.MediaWindow = Me
        If Props.nadoProigrat And NikakoiEsli(Props.FileNamePlayed) <> trans("Никакой") Then Props.PlayMovie()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Private Sub tmrScroll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        If Props.PlayPosition >= Props.TotalPosition And Props.bPlaying Then
            Props.StopMovie() : RaiseEvent OnEnd(Nothing, Nothing)
        End If
    End Sub
End Class

Public Class Media
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("Вспомогательное поле"), trans("Видимый"), trans("Тип"), trans("Подсказка"), _
        trans("Файл проигрывания"), trans("Проигрывается"), trans("Громкость"), _
        trans("Баланс"), trans("Звук отключен"), trans("Скорость"), _
        trans("Длительность общая"), trans("Длительность время"), _
        trans("Проигралось времени"), trans("Позиция проигрывания"), _
        trans("Оригинальная ширина"), trans("Оригинальная вышина"), trans("На весь экран") _
       }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Перенести наперед"), trans("Перенести назад"), _
        trans("Плей"), trans("Стоп медиа"), trans("Пауза"), trans("Открыть медиафайл"), trans("Закрыть файл")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Прорисовка"), trans("Конец проигрывания"), _
                                trans("Изменились размеры"), trans("Изменилась видимость") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "media"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runMd, holostoi, isRun, fromEng)
        Else
            CreateObject(New Md, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' МЕДИА AUDIOPLAYER
#Region "AUDIOPLAYER"
Public Class A
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Аудио")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Плей")
    Public LastSobyt As String = trans("Конец проигрывания")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        MyBase.BackColor = Color.Transparent
        Props.MediaWindow = Me
    End Sub
End Class

Class runA
    Inherits A
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public WithEvents tmr As New Windows.Forms.Timer()
    Public Event OnEnd(ByVal sender As Object, ByVal e As System.EventArgs)
    Sub New()
        tmr.Interval = 100 : tmr.Start()
        Props.strAlias = GetUIN()
    End Sub
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Props.MediaWindow = Me
        If Props.nadoProigrat Then Props.PlayMovie()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Private Sub tmrScroll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        If Props.PlayPosition >= Props.TotalPosition And Props.bPlaying Then
            Props.StopMovie() : RaiseEvent OnEnd(Nothing, Nothing)
        End If
    End Sub
End Class

Public Class Audio
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("Вспомогательное поле"), trans("Видимый"), trans("Тип"), trans("Подсказка"), _
        trans("Файл проигрывания"), trans("Проигрывается"), trans("Громкость"), _
        trans("Баланс"), trans("Звук отключен"), trans("Скорость"), _
        trans("Длительность общая"), trans("Длительность время"), _
        trans("Проигралось времени"), trans("Позиция проигрывания"), _
        trans("Оригинальная ширина"), trans("Оригинальная вышина") _
       }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Перенести наперед"), trans("Перенести назад"), _
        trans("Плей"), trans("Стоп медиа"), trans("Пауза"), trans("Открыть медиафайл"), trans("Закрыть файл")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Прорисовка"), trans("Конец проигрывания")}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "audio"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runA, holostoi, isRun, fromEng)
        Else
            CreateObject(New A, holostoi, isRun, fromEng)
        End If
        Me.obj.image = Pictures32.Images(Picture)
    End Sub
End Class
#End Region

' КНОПКА BUTTON
#Region "BUTTON"
Public Class B
    Inherits Windows.Forms.Button
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Кнопка")
    Public LastProp As String = trans("Текст")
    Public LastSobyt As String = trans("Клик")
    Public Props As New Propertys(Me)
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 23
        Props.BackColor = trans("Никакой")
        Me.UseVisualStyleBackColor = True
    End Sub
End Class

Class runB
    Inherits B
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class Button
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("АвтоТроеточие"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), trans("Стиль кнопки"), _
        trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый"), _
        trans("Шрифт зачеркнутый"), trans("Цвет шрифта"), trans("Рисунок"), trans("Положение рисунка"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Поле слева"), trans("Поле сверху"), _
        trans("Поле справа"), trans("Поле снизу"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Шрифт размер"), _
        trans("Положение текста"), trans("Текст и рисунок"), trans("Видимый"), trans("В фокусе"), trans("Тип"), _
        trans("Подсказка")}
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "button"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runB, holostoi, isRun, fromEng)
        Else
            CreateObject(New B, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ЗАКЛАДКИ TABPAGE
#Region "TABPAGE"
Public Class TP
    Inherits Windows.Forms.TabControl
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Закладки")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Номер выделенной закладки")
    Public LastSobyt As String = trans("Выделили закладку")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Me.Name
    End Sub
End Class

Class runTP
    Inherits TP
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public Shadows Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Props.SelectedTabPosition = Props.SelectedTabPosition
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class TPage
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), trans("Растяжка"), _
        trans("Всплывающее меню"), _
        trans("Курсор"), trans("Работает"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("Многострочность"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Видимый"), trans("Тип"), trans("Подсказка"), _
        trans("Положение закладок"), trans("Номер выделенной закладки"), trans("Позиция выделенной закладки"), _
        trans("Поле по горизонтали"), trans("Поле по вертикали") _
        }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Снялось выделение закладки"), trans("Снимается выделение закладки"), _
                                trans("Выделили закладку"), trans("Выделяют закладку") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "tpage"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runTP, holostoi, isRun, fromEng)
        Else
            CreateObject(New TP, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ЗАКЛАДКА TABPAGES
#Region "TABPAGES"
Public Class TPs
    Inherits Windows.Forms.TabPage
    Public TypeObj As String = "IncludeObj"
    Public defaultName As String = trans("Закладка")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Текст")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    Sub New()
        Me.Name = MyZnak & "none"
    End Sub
    Public Sub MoveToPosition()
        Dim cont As Object, i As Integer
        cont = Me.Parent
        If cont Is Nothing Then Exit Sub
        i = cont.TabPages.IndexOf(Me)
        If i <> Props.obj.props.Position And i <> -1 Then
            cont.TabPages.Remove(Me)
            If Props.obj.Props.pos > cont.TabPages.Count Then Props.obj.Props.pos = cont.TabPages.Count
            Dim bylo As Integer = cont.TabPages.Count
            cont.TabPages.Insert(Props.obj.Props.pos, Me)
            If bylo = cont.TabPages.Count Then cont.TabPages.add(Me) ' глупость vb
            cont.SelectedIndex = Props.pos
        End If

        For i = 0 To cont.TabPages.count - 1
            cont.TabPages(i).Props.pos = i
        Next
    End Sub
End Class

Class runTPs
    Inherits TPs
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Sub New()
        Me.Name = MyZnak & "none"
    End Sub
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class TPages
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Позиция"), trans("Номер"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Работает"), trans("Прокрутка"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Стиль рамки"), trans("Всплывающая подсказка"), _
        trans("Прокрутка минимальная ширина"), trans("Прокрутка минимальная вышина"), _
        trans("Прокручено по X"), trans("Прокручено по Y"), trans("Тип") _
        }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Прокрутка") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "tpage"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runTPs, holostoi, isRun, fromEng)
        Else
            CreateObject(New TPs, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ГЛАВНОЕ МЕНЮ MAINMENU
#Region "MAINMENU"
Public Class MM
    Inherits Windows.Forms.MenuStrip
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Меню")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Цвет")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.Name = proj.GiveName(defaultName) : Me.Text = Me.Name
        Me.GripStyle = ToolStripGripStyle.Hidden
        Me.Stretch = False
        Me.AutoSize = False
        Props.Width = 150 : Props.Height = 30
        Me.Dock = DockStyle.None
        Props.BackColor = ToMyColor(SystemColors.Control)
        Me.RenderMode = ToolStripRenderMode.Professional
    End Sub
End Class

Class runMM
    Inherits MM
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class MMenu
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
         trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
         trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), _
         trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
         trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
         trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
         trans("Ориентация инструментов"), trans("Видимый"), trans("В фокусе"), trans("Тип"), trans("Подсказка")}
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), _
                                trans("Изменились размеры"), trans("Изменилась видимость") _
                                 }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "mmenu"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runMM, holostoi, isRun, fromEng)
        Else
            CreateObject(New MM, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' КОНТЕКСТНОГО МЕНЮ CONTEXTMENU
#Region "CONTEXTMENU"
Public Class CM
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Всплывающее меню")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Имя")
    Public LastSobyt As String = trans("Клик")
    Public CnMn As New ContextMenuStrip
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        MyBase.BackColor = Color.Transparent
    End Sub
    ReadOnly Property items() As ToolStripItemCollection
        Get
            Return CnMn.Items
        End Get
    End Property
End Class

Class runCM
    Inherits CM
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Sub New()

    End Sub
    Public Sub Load()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class CMenu
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Хозяин объект"), trans("Номер"), trans("X"), trans("Y"), trans("Тип")}
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Открытие"), trans("Открылось"), trans("Закрытие"), trans("Закрылось")}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "cmenu"

    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runCM, holostoi, isRun, fromEng)
        Else
            CreateObject(New CM, holostoi, isRun, fromEng)
        End If
        Me.obj.image = Pictures32.Images(Picture)
    End Sub
End Class
#End Region

' ЭЛЕМЕНТА МЕНЮ MAINMENUS
#Region "MAINMENUS"
Public Class MMs
    Inherits System.Windows.Forms.ToolStripMenuItem
    Public TypeObj As String = "IncludeObj"
    Public defaultName As String = trans("Пункт")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Текст")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    Sub New()
        Me.Name = MyZnak & "none"
    End Sub
    Public Sub Refresh()
    End Sub
    Public Sub BringToFront()
    End Sub
    Public Sub SendToBack()
    End Sub
    Overloads Property DropLocation() As Point
        Get
            Return Me.DropDownLocation
        End Get
        Set(ByVal value As Point)
        End Set
    End Property
    Overloads Property Parent() As Object
        Get
            Return MyBase.Parent
        End Get
        Set(ByVal value As Object)
            MyBase.Parent = value
        End Set
    End Property
    Overloads Property Cursor() As Object
        Get
            Return Cursors.Default
        End Get
        Set(ByVal value As Object)
        End Set
    End Property
    Overloads Property Left() As Object
        Get
            Return 0
        End Get
        Set(ByVal value As Object)
        End Set
    End Property
    Overloads Property Top() As Object
        Get
            Return 0
        End Get
        Set(ByVal value As Object)
        End Set
    End Property
    Public Sub MoveToPosition()
        Dim cont As Object, i As Integer, obj As Object = Me
        cont = obj.Owner
        If cont Is Nothing Then
            If Me.Props.Sep Is Nothing Then Exit Sub
            obj = Me.Props.Sep : cont = obj.Owner
            If cont Is Nothing Then Exit Sub
        End If
        Dim contCollec As System.Windows.Forms.ToolStripItemCollection
        contCollec = cont.items
        i = contCollec.IndexOf(obj)
        If i <> Props.obj.Props.pos And i <> -1 Then
            contCollec.Remove(obj)
            If Props.obj.Props.pos > contCollec.Count Then Props.obj.Props.pos = contCollec.Count
            Dim bylo As Integer = contCollec.Count
            contCollec.Insert(Props.obj.Props.pos, obj)
            If bylo = contCollec.Count Then contCollec.Add(obj) ' глупость vb
        End If

        For i = 0 To contCollec.Count - 1
            Dim oo = contCollec(i)
            If oo.GetType.ToString = ClassAplication & "MMs" Then
                oo.Props.pos = i
            Else
                If oo.tag Is Nothing = False Then oo.tag.Props.pos = i
            End If
        Next
    End Sub
End Class

Class runMMs
    Inherits MMs
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public Sub Load()
        Me.Props.DropDown(True) = Me.Props.DropDown
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class MMenus
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Позиция"), _
        trans("Цвет"), trans("Фоновой рисунок"), _
        trans("Стиль фона"), trans("Работает"), _
        trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый"), _
        trans("Шрифт зачеркнутый"), trans("Цвет шрифта"), trans("Рисунок"), trans("Положение рисунка"), _
        trans("Поле слева"), trans("Поле сверху"), trans("Поле справа"), trans("Поле снизу"), _
        trans("Вспомогательное поле"), trans("Текст и рисунок"), _
        trans("Видимый"), trans("Шрифт размер"), trans("Тип"), _
        trans("Расположен слева"), trans("Показывать подсказку"), trans("Отмечено"), trans("Отметка по клику"), _
        trans("Стиль отображения"), trans("Родительское меню"), trans("Вложенное всплывающее меню"), _
        trans("Рисунок растянут"), trans("Прозрачный цвет рисунка"), trans("Горячая клавиша"), _
        trans("Отображать горячие клавиши"), trans("Направление текста"), trans("Всплывающая подсказка"), _
        trans("Родительский пункт") _
        }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Перенести наперед"), _
        trans("Перенести назад"), trans("Вложенное меню закрылось"), trans("Вложенное меню открылось"), _
        trans("Вложенное меню открывается")}

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменение отметки"), _
                                trans("Вложенное меню закрылось"), trans("Вложенное меню открылось"), _
                                trans("Вложенное меню открывается")}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "mmenu"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False, Optional ByVal ToolPanel As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runMMs, holostoi, isRun, fromEng)
        Else
            CreateObject(New MMs, holostoi, isRun, fromEng)
        End If
        If ToolPanel = True Then
            obj.props.Paddingleft = 10
            obj.props.DisplayStyle = trans("Рисунок")
            If IO.File.Exists(PicturesPath & "\Icons\Objects\tpanel.png") Then
                obj.props.Image = copyImage(PicturesPath & "\Icons\Objects\tpanel.png")
            End If
        End If
    End Sub
End Class
#End Region

' ПАМЯТЬ MEMORY 
#Region "MEMORY"
Public Class M
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Память")
    Public LastProp As String = trans("Значение")
    Public LastSobyt As String = trans("Изменилось значение")
    Public Props As New Propertys(Me)
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.CenterImage : MyBase.Height = 13 : MyBase.Width = 24
    End Sub
    Overloads Property Height()
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Width()
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value)
        End Set
    End Property
End Class

Class runM
    Inherits M
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Shadows Event ChangingValue(ByVal sender As Object, ByVal e As String)
    Shadows Event ChangedValue(ByVal sender As Object, ByVal e As EventArgs)
    Public Shadows Props As New PropertysRun(Me)
    Public Sub Load()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Public Sub RaiseChangingValue(ByVal val As String)
        RaiseEvent ChangingValue(Me, val)
    End Sub
    Public Sub RaiseChangedValue()
        RaiseEvent ChangedValue(Me, New EventArgs())
    End Sub
End Class

Public Class Memory
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Значение"), trans("Имя"), trans("Номер"), trans("Тип"), trans("Работает"), _
                                    trans("Вспомогательное поле"), trans("X"), trans("Y")}
    ' Все методы данного объекта
    Public Methods() As String = {}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Изменение значения"), trans("Изменилось значение")}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "memory"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runM, holostoi, isRun, fromEng)
        Else
            CreateObject(New M, holostoi, isRun, fromEng)
        End If
        Me.obj.image = Pictures32.Images(Picture)
    End Sub
End Class
#End Region

' ПАНЕЛЬ PANEL
#Region "PANEL"
Public Class P
    Inherits Windows.Forms.Panel
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Панель") & " "
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Ширина")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.BorderStyle = trans("линия")
    End Sub
End Class

Class runP
    Inherits P
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class Panel
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), trans("Растяжка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Работает"), trans("Прокрутка"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Видимый"), trans("Стиль рамки"), trans("Тип"), trans("Подсказка"), _
        trans("Прокрутка минимальная ширина"), trans("Прокрутка минимальная вышина"), _
        trans("Прокручено по X"), trans("Прокручено по Y") _
        }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Прокрутка") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "panel"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runP, holostoi, isRun, fromEng)
        Else
            CreateObject(New P, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ДВОЙНАЯ ПАНЕЛЬ DOUBLEPANEL
#Region "DOUBLEPANEL"
Public Class DP
    Inherits Windows.Forms.SplitContainer
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Двойная панель")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Расстояние разделителя")
    Public LastSobyt As String = trans("Разделитель перемещен")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Text = Me.Name
        Props.BorderStyle = trans("Линия")
        Props.Width = 200 : Props.Height = 150
        Props.SplitterDistance = Me.Width / 2
        Me.Panel1.Name = "Panel1" : Me.Panel2.Name = "Panel2"
        Me.Panel1.Tag = "Panel1" : Me.Panel2.Tag = "Panel2"
        Me.DoubleBuffered = True
    End Sub
    ReadOnly Property ParentPanelLeft(ByVal obj As Object)
        Get
            Dim Left = 0, BorderWidth As Integer = 0
            If Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle Then BorderWidth = 1
            If Me.BorderStyle = Windows.Forms.BorderStyle.Fixed3D Then BorderWidth = 2
            If obj.Parent Is Nothing Then Return 0
            If obj.Parent.name = "Panel2" Then
                If Me.Orientation = Windows.Forms.Orientation.Vertical Then
                    Left = Me.SplitterDistance + Me.SplitterRectangle.Width
                End If
                Return Me.Left + BorderWidth + Left
            Else
                Return Me.Left + BorderWidth
            End If
        End Get
    End Property
    ReadOnly Property ParentPanelTop(ByVal obj As Object)
        Get
            Dim Top = 0, BorderWidth As Integer = 0
            If Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle Then BorderWidth = 1
            If Me.BorderStyle = Windows.Forms.BorderStyle.Fixed3D Then BorderWidth = 2
            If obj.Parent Is Nothing Then Return 0
            If obj.Parent.Tag = "Panel2" Then
                If Me.Orientation = Windows.Forms.Orientation.Horizontal Then
                    Top = Me.SplitterDistance + Me.SplitterRectangle.Height
                End If
                Return Me.Top + BorderWidth + Top
            Else
                Return Me.Top + BorderWidth
            End If
        End Get
    End Property
End Class

Class runDP
    Inherits DP
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Sub New()

    End Sub
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Props.AddContextMenu("panel1") ' Присвоение контекстного меню
        Props.AddContextMenu("panel2") ' Присвоение контекстного меню
        Dim pw = Props.Width, ph As Integer = Props.Height
        Props.Anchor = Props.Anchor
        Props.Width = pw : Props.Height = ph
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class DPanel
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Цвет1"), trans("Цвет2"), trans("Фоновой рисунок"), trans("Фоновой рисунок1"), _
        trans("Фоновой рисунок2"), trans("Стиль фона1"), trans("Стиль фона2"), trans("Стиль рамки"), _
        trans("Всплывающее меню"), trans("Всплывающее меню1"), trans("Всплывающее меню2"), _
        trans("Курсор"), trans("Курсор1"), trans("Курсор2"), trans("Прокрутка1"), trans("Прокрутка2"), _
        trans("Растяжка"), trans("Работает"), trans("Фиксированная часть"), trans("Фиксированный разделитель"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Видимый"), _
        trans("Ориентация"), trans("Панель1 скрыта"), trans("Панель2 скрыта"), _
        trans("Ширина разделителя"), trans("Расстояние разделителя"), trans("Инкремент разделителя"), _
        trans("Панель1 минимум"), trans("Панель2 минимум"), trans("В фокусе"), trans("Подсказка"), trans("Тип") _
        }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), _
                                trans("Разделитель перемещается"), trans("Разделитель перемещен"), _
                                trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Прокрутка") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "dpanel"
    Public ActivePanel As String
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runDP, holostoi, isRun, fromEng)
        Else
            CreateObject(New DP, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ТЕКСТОВОЕ ПОЛЕ TEXTBOKS
#Region "TEXTBOKS"
Public Class T
    Inherits Windows.Forms.TextBox
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Текст")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Текст")
    Public LastSobyt As String = trans("Изменение текста")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 23
        Props.BackColor = ToMyColor(Color.White)
        Props.BorderStyle = LCase(trans("объем"))
        Props.HideSelection = trans("Нет")

    End Sub
End Class

Class runT
    Inherits T
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class TextBoks
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка") _
        , trans("Цвет"), trans("Стиль рамки") _
        , trans("Всплывающее меню"), trans("Растяжка"), trans("Работает") _
        , trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый") _
        , trans("Шрифт зачеркнутый"), trans("Шрифт размер"), trans("Цвет шрифта"), trans("Скрывать выделение") _
        , trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина") _
        , trans("Минимальная ширина"), trans("Минимальная вышина") _
        , trans("Максимальная длинна"), trans("Многострочность"), trans("Символ пароля") _
        , trans("Только для чтения"), trans("Полосы прокрутки"), trans("Ширина"), trans("Вышина") _
        , trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле") _
        , trans("Расположение текста"), trans("Видимый"), trans("Перенос по словам") _
        , trans("Выделенный текст"), trans("Начало выделения"), trans("Длинна выделения") _
        , trans("Номер символа по координатам"), trans("Номер первого символа строки") _
        , trans("Номер первого символа текущей строки"), trans("Номер строки по номеру символа") _
        , trans("X по номеру символа"), trans("Y по номеру символа") _
        , trans("Строка"), trans("Количество строк"), trans("Символ"), trans("Количество символов") _
        , trans("В фокусе"), trans("Тип"), trans("Подсказка"), trans("Разрешить вводить")}

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед") _
        , trans("Перенести назад"), trans("Копировать"), trans("Вырезать"), trans("Вставить"), trans("Выделить все") _
        , trans("Отменить"), trans("Повторить")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "textboks"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runT, holostoi, isRun, fromEng)
        Else
            CreateObject(New T, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ГАЛОЧКА CHECKBOKS
#Region "CHECKBOKS"
Public Class CB
    Inherits Windows.Forms.CheckBox
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Галочка")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Отмечено")
    Public LastSobyt As String = trans("Изменение отметки")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 23 : Props.ForeColor = "0;0;0;"
        Me.AutoCheck = False
        Me.UseVisualStyleBackColor = True
    End Sub
End Class

Class runCB
    Inherits CB
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Me.AutoCheck = True
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class CheckBoks
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("АвтоТроеточие"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), trans("Стиль кнопки"), _
        trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый"), _
        trans("Шрифт зачеркнутый"), trans("Цвет шрифта"), trans("Рисунок"), trans("Положение рисунка"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Поле слева"), trans("Поле сверху"), _
        trans("Поле справа"), trans("Поле снизу"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Положение текста"), trans("Текст и рисунок"), trans("Видимый"), trans("В фокусе"), trans("Тип") _
        , trans("Отмечено"), trans("Шрифт размер"), trans("Подсказка") _
        }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменение отметки"), _
                                trans("Изменились размеры"), trans("Изменилась видимость") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "checkboks"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runCB, holostoi, isRun, fromEng)
        Else
            CreateObject(New CB, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ГАЛОЧКА RADIOBUT
#Region "RADIOBUT"
Public Class RB
    Inherits Windows.Forms.RadioButton
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Точка")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Отмечено")
    Public LastSobyt As String = trans("Изменение отметки")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 23 : Props.ForeColor = "0;0;0;"
        Me.AutoCheck = False
        Me.UseVisualStyleBackColor = True
    End Sub
End Class

Class runRB
    Inherits RB
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Me.AutoCheck = True
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class RadioBut
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("АвтоТроеточие"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), trans("Стиль кнопки"), _
        trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый"), _
        trans("Шрифт зачеркнутый"), trans("Цвет шрифта"), trans("Рисунок"), trans("Положение рисунка"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Поле слева"), trans("Поле сверху"), _
        trans("Поле справа"), trans("Поле снизу"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Положение текста"), trans("Текст и рисунок"), trans("Видимый"), trans("В фокусе"), trans("Тип") _
        , trans("Отмечено"), trans("Шрифт размер"), trans("Подсказка") _
        }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменение отметки"), _
                                trans("Изменились размеры"), trans("Изменилась видимость") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "radiobut"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runRB, holostoi, isRun, fromEng)
        Else
            CreateObject(New RB, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ЭЛЕМЕНТА МЕНЮ TOOLPANEL
#Region "TOOLPANEL"
Public Class TPl
    Inherits Windows.Forms.ToolStrip
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Панель инструментов")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Ширина")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    Sub New()
        MyBase.New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.Name = proj.GiveName(defaultName) : Me.Text = Me.Name
        Me.GripStyle = ToolStripGripStyle.Hidden
        ' Me.Stretch = False
        Me.AutoSize = False
        Props.Width = 150 : Props.Height = 30
        Props.BackColor = ToMyColor(SystemColors.Control)
        Me.Dock = DockStyle.None
        Me.RenderMode = ToolStripRenderMode.Professional
    End Sub
End Class

Class runTPl
    Inherits TPl
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class TPanel
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
         trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
         trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), trans("Ориентация инструментов"), _
         trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
         trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
         trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
         trans("Видимый"), trans("В фокусе"), trans("Тип"), trans("Подсказка")}
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "tpanel"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runTPl, holostoi, isRun, fromEng)
        Else
            CreateObject(New TPl, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' БРАУЗЕР WEBBROWSER
#Region "WEBBROWSER"
Public Class W
    Inherits Windows.Forms.WebBrowser
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Браузер")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Ссылка")
    Public LastSobyt As String = trans("Страница загрузилась")
    Public lastLink As String
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName)
        Props.Width = 400 : Props.Height = 300
        Props.ScriptErrorsSuppressed = trans("Нет")
    End Sub
End Class

Class runW
    Inherits W
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class WBrowser
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Всплывающее меню"), trans("Растяжка"), trans("Работает"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Видимый"), trans("В фокусе"), trans("Тип"), _
        trans("Переходить по сссылкам"), trans("Разрешить перетаскивания"), trans("Назад возможно"), _
        trans("Вперед возможно"), trans("Текст страницы"), trans("Заголовок страницы"), _
        trans("Тип страницы"), trans("Браузер занят"), trans("Браузер offline"), _
        trans("Всплывающее меню браузера"), trans("Статус готовности"), trans("Статусная строка"), _
        trans("Отображать ошибки сценариев"), trans("Полосы прокрутки активны"), trans("Ссылка"), _
        trans("Горячие клавиши работают"), trans("Кодировка"), trans("Кодировка по умолчанию"), trans("Куки"), _
        trans("Открытие ссылок нового окна"), trans("Подсказка") _
    }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Получить фокус"), trans("Перенести наперед"), trans("Перенести назад"), _
        trans("Обновить страницу"), trans("Назад"), trans("Вперед"), trans("Домой"), trans("Страница поиска"), _
        trans("Открыть в новом окне"), trans("Открыть в фрейме"), trans("Печать"), trans("Окно параметров страницы"), _
        trans("Окно печати"), trans("Окно предварительного просмотра"), trans("Окно свойств"), _
        trans("Окно сохранить"), trans("Остановить") _
    }

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Назад можно изменилось"), trans("Вперед можно изменилось"), _
                                trans("Страница загрузилась"), trans("Страница загружается"), trans("Перешел по ссылке"), _
                                trans("Переходит по ссылке"), trans("Открытие в новом окне"), _
                                trans("Статусная строка изменилась"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "wbrowser"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runW, holostoi, isRun, fromEng)
        Else
            CreateObject(New W, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ТАБЛИЦА TABLE
#Region "TABLE"
Public Class Tl
    Inherits Windows.Forms.DataGridView
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Таблица")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Номера выделенных строк")
    Public LastSobyt As String = trans("Клик по ячейке")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.BackColor = ToMyColor(SystemColors.AppWorkspace)
        Props.Height = 130 : Props.Width = 244
        Props.ScrollBars = trans("обе")
        RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
        RowHeadersWidth = 20
    End Sub

    ' ПЕЧАТЬ ТАБЛИЦЫ
    Private TheDataGridView As DataGridView ' The DataGridView Control which will be printed
    Private ThePrintDocument As Printing.PrintDocument ' The PrintDocument to be used for printing
    Private IsCenterOnPage As Boolean ' Determine if the report will be printed in the Top-Center of the page
    Private IsWithTitle As Boolean ' Determine if the page contain title text
    Private TheTitleText As String ' The title text to be printed in each page (if IsWithTitle is set to true)
    Private TheTitleFont As Font ' The font to be used with the title text (if IsWithTitle is set to true)
    Private TheTitleColor As Color ' The color to be used with the title text (if IsWithTitle is set to true)
    Private IsWithPaging As Boolean ' Determine if paging is used
    Public CurrentRow As Integer ' A static parameter that keep track on which Row (in the DataGridView control) that should be printed
    Public PageNumber As Integer
    Private PageWidth As Integer
    Private PageHeight As Integer
    Private LeftMargin As Integer
    Private TopMargin As Integer
    Private RightMargin As Integer
    Private BottomMargin As Integer
    Private CurrentY As Double ' A parameter that keep track on the y coordinate of the page, so the next object to be printed will start from this y coordinate
    Private RowHeaderHeight As Double
    Private RowsHeight() As Double
    Private ColumnsWidth() As Double
    Private TheDataGridViewWidth As Double
    ' Maintain a generic list to hold start/stop points for the column printing
    ' This will be used for wrapping in situations where the DataGridView will not fit on a single page
    Private mColumnPoints() As Point
    Private mColumnPointsWidth() As Double
    Private mColumnPoint As Integer
    ' The class constructor
    Public Sub DataGridViewPrinter(ByVal aDataGridView As DataGridView, ByVal aPrintDocument As Printing.PrintDocument, _
                    ByVal CenterOnPage As Boolean, ByVal WithTitle As Boolean, ByVal aTitleText As String, _
                    ByVal aTitleFont As Font, ByVal aTitleColor As Color, ByVal WithPaging As Boolean)
        TheDataGridView = aDataGridView
        ThePrintDocument = aPrintDocument
        IsCenterOnPage = CenterOnPage
        IsWithTitle = WithTitle
        TheTitleText = aTitleText
        TheTitleFont = aTitleFont
        TheTitleColor = aTitleColor
        IsWithPaging = WithPaging

        PageNumber = 0

        RowsHeight = Nothing
        ColumnsWidth = Nothing

        mColumnPoints = Nothing
        mColumnPointsWidth = Nothing

        ' Claculating the PageWidth and the PageHeight
        If Not (ThePrintDocument.DefaultPageSettings.Landscape) Then
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height
        Else
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height
        End If

        ' Claculating the page margins
        LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left
        TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top
        RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Right
        BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom

        ' First, the current row to be printed is the first row in the DataGridView control
        CurrentRow = 0
    End Sub
    ' The function that calculate the height of each row (including the header row), 
    'the width of each column (according to the longest text in all its cells including the header cell), 
    'and the whole DataGridView width
    Private Sub Calculate(ByVal g As Graphics)
        If (PageNumber = 0) Then ' Just calculate once
            Dim tmpSize As New SizeF()
            Dim tmpFont As Font
            Dim tmpWidth As Double
            Dim i, j As Integer

            TheDataGridViewWidth = 0
            For i = 0 To TheDataGridView.Columns.Count - 1
                tmpFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font
                If (tmpFont Is Nothing) Then ' If there is no special HeaderFont style, then use the default DataGridView font style
                    tmpFont = TheDataGridView.DefaultCellStyle.Font
                End If

                tmpSize = g.MeasureString(TheDataGridView.Columns(i).HeaderText, tmpFont)
                ' tmpWidth = tmpSize.Width
                tmpWidth = TheDataGridView.Columns(i).Width
                RowHeaderHeight = tmpSize.Height

                For j = 0 To TheDataGridView.Rows.Count - 1
                    tmpFont = TheDataGridView.Rows(j).DefaultCellStyle.Font
                    If (tmpFont Is Nothing) Then ' If the there is no special font style of the CurrentRow, then use the default one associated with the DataGridView control
                        tmpFont = TheDataGridView.DefaultCellStyle.Font
                    End If

                    tmpSize = g.MeasureString("Anything", tmpFont)
                    ReDims(RowsHeight)
                    RowsHeight(RowsHeight.Length - 1) = TheDataGridView.Rows(j).Height ' tmpSize.Height

                    tmpSize = g.MeasureString(TheDataGridView.Rows(j).Cells(i).EditedFormattedValue.ToString(), tmpFont)
                    'If (tmpSize.Width > tmpWidth) Then
                    '    tmpWidth = tmpSize.Width
                    'End If
                Next
                If (TheDataGridView.Columns(i).Visible) Then
                    TheDataGridViewWidth += tmpWidth
                End If
                ReDims(ColumnsWidth) : ColumnsWidth(ColumnsWidth.Length - 1) = tmpWidth
            Next

            ' Define the start/stop column points based on the page width and the DataGridView Width
            ' We will use this to determine the columns which are drawn on each page and how wrapping will be handled
            ' By default, the wrapping will occurr such that the maximum number of columns for a page will be determine
            Dim k As Integer

            Dim mStartPoint As Integer = 0
            For k = 0 To TheDataGridView.Columns.Count - 1
                If (TheDataGridView.Columns(k).Visible) Then
                    mStartPoint = k
                    Exit For
                End If
            Next

            Dim mEndPoint As Integer = TheDataGridView.Columns.Count
            For k = TheDataGridView.Columns.Count - 1 To 0 Step -1
                If (TheDataGridView.Columns(k).Visible) Then
                    mEndPoint = k + 1
                    Exit For
                End If
            Next

            Dim mTempWidth As Double = TheDataGridViewWidth
            Dim mTempPrintArea As Double = PageWidth - LeftMargin - RightMargin

            ' We only care about handling where the total datagridview width is bigger then the print area
            If (TheDataGridViewWidth > mTempPrintArea) Then
                mTempWidth = 0.0F
                For k = 0 To TheDataGridView.Columns.Count - 1
                    If (TheDataGridView.Columns(k).Visible) Then
                        mTempWidth += ColumnsWidth(k)
                        ' If the width is bigger than the page area, then define a new column print range
                        If (mTempWidth > mTempPrintArea) Then
                            mTempWidth -= ColumnsWidth(k)
                            ReDims(mColumnPoints) : mColumnPoints(mColumnPoints.Length - 1) = New Point(mStartPoint, mEndPoint)
                            ReDims(mColumnPointsWidth) : mColumnPointsWidth(mColumnPointsWidth.Length - 1) = mTempWidth
                            mStartPoint = k
                            mTempWidth = ColumnsWidth(k)
                        End If
                    End If
                    ' Our end point is actually one index above the current index
                    mEndPoint = k + 1
                Next
            End If
            ' Add the last set of columns
            ReDims(mColumnPoints) : mColumnPoints(mColumnPoints.Length - 1) = New Point(mStartPoint, mEndPoint)
            ReDims(mColumnPointsWidth) : mColumnPointsWidth(mColumnPointsWidth.Length - 1) = mTempWidth
            mColumnPoint = 0
        End If
    End Sub
    ' The funtion that print the title, page number, and the header row
    Private Sub DrawHeader(ByVal g As Graphics)

        CurrentY = TopMargin

        ' Printing the page number (if isWithPaging is set to true)
        PageNumber += 1
        If (IsWithPaging) Then
            Dim PageString As String = trans("Страница") & " " & PageNumber.ToString()

            Dim PageStringFormat As New StringFormat()
            PageStringFormat.Trimming = StringTrimming.Word
            PageStringFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
            PageStringFormat.Alignment = StringAlignment.Far

            Dim PageStringFont As New Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point)

            Dim PageStringRectangle As New RectangleF(LeftMargin, CurrentY, PageWidth - RightMargin - LeftMargin, g.MeasureString(PageString, PageStringFont).Height)

            g.DrawString(PageString, PageStringFont, New SolidBrush(Color.Black), PageStringRectangle, PageStringFormat)

            CurrentY += g.MeasureString(PageString, PageStringFont).Height
        End If

        ' Printing the title (if IsWithTitle is set to true)
        If (IsWithTitle) Then
            Dim TitleFormat As New StringFormat()
            TitleFormat.Trimming = StringTrimming.Word
            TitleFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
            If (IsCenterOnPage) Then
                TitleFormat.Alignment = StringAlignment.Center
            Else
                TitleFormat.Alignment = StringAlignment.Near
            End If

            Dim TitleRectangle As New RectangleF(LeftMargin, CurrentY, PageWidth - RightMargin - LeftMargin, g.MeasureString(TheTitleText, TheTitleFont).Height)

            g.DrawString(TheTitleText, TheTitleFont, New SolidBrush(TheTitleColor), TitleRectangle, TitleFormat)

            CurrentY += g.MeasureString(TheTitleText, TheTitleFont).Height
        End If

        ' Calculating the starting x coordinate that the printing process will start from
        Dim CurrentX As Double = LeftMargin
        If (IsCenterOnPage) Then
            CurrentX += ((PageWidth - RightMargin - LeftMargin) - mColumnPointsWidth(mColumnPoint)) / 2.0F
        End If

        ' Setting the HeaderFore style
        Dim HeaderForeColor As Color = TheDataGridView.ColumnHeadersDefaultCellStyle.ForeColor
        If (HeaderForeColor.IsEmpty) Then ' If there is no special HeaderFore style, then use the default DataGridView style
            HeaderForeColor = TheDataGridView.DefaultCellStyle.ForeColor
        End If
        Dim HeaderForeBrush As New SolidBrush(HeaderForeColor)

        ' Setting the HeaderBack style
        Dim HeaderBackColor As Color = TheDataGridView.ColumnHeadersDefaultCellStyle.BackColor
        If (HeaderBackColor.IsEmpty) Then ' If there is no special HeaderBack style, then use the default DataGridView style
            HeaderBackColor = TheDataGridView.DefaultCellStyle.BackColor
        End If
        Dim HeaderBackBrush = New SolidBrush(HeaderBackColor)

        ' Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
        Dim TheLinePen As New Pen(TheDataGridView.GridColor, 1)

        ' Setting the HeaderFont style
        Dim HeaderFont As Font = TheDataGridView.ColumnHeadersDefaultCellStyle.Font
        If (HeaderFont Is Nothing) Then ' If there is no special HeaderFont style, then use the default DataGridView font style
            HeaderFont = TheDataGridView.DefaultCellStyle.Font
        End If

        ' Calculating and drawing the HeaderBounds        
        Dim HeaderBounds As New RectangleF(CurrentX, CurrentY, mColumnPointsWidth(mColumnPoint), RowHeaderHeight)
        g.FillRectangle(HeaderBackBrush, HeaderBounds)

        ' Setting the format that will be used to print each cell of the header row
        Dim CellFormat = New StringFormat()
        CellFormat.Trimming = StringTrimming.Word
        CellFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip

        ' Printing each visible cell of the header row
        Dim CellBounds As RectangleF
        Dim ColumnWidth As Double
        Dim i As Integer
        For i = mColumnPoints(mColumnPoint).X To mColumnPoints(mColumnPoint).Y - 1
            If Not (TheDataGridView.Columns(i).Visible) Then Continue For

            ColumnWidth = ColumnsWidth(i)

            ' Check the CurrentCell alignment and apply it to the CellFormat
            If (TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right")) Then
                CellFormat.Alignment = StringAlignment.Far
            ElseIf (TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center")) Then
                CellFormat.Alignment = StringAlignment.Center
            Else
                CellFormat.Alignment = StringAlignment.Near
            End If
            CellBounds = New RectangleF(CurrentX, CurrentY, ColumnWidth, RowHeaderHeight)

            ' Printing the cell text
            g.DrawString(TheDataGridView.Columns(i).HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat)

            ' Drawing the cell bounds
            If (TheDataGridView.RowHeadersBorderStyle <> DataGridViewHeaderBorderStyle.None) Then ' Draw the cell border only if the HeaderBorderStyle is not None
                g.DrawRectangle(TheLinePen, Int(CurrentX), Int(CurrentY), Int(ColumnWidth), Int(RowHeaderHeight))
            End If

            CurrentX += ColumnWidth
        Next

        CurrentY += RowHeaderHeight
    End Sub
    ' The function that print a bunch of rows that fit in one page
    ' When it returns true, meaning that there are more rows still not printed, so another PagePrint action is required
    ' When it returns false, meaning that all rows are printed (the CureentRow parameter reaches the last row of the DataGridView control) and no further PagePrint action is required
    Private Function DrawRows(ByVal g As Graphics) As Boolean
        ' Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
        Dim TheLinePen As New Pen(TheDataGridView.GridColor, 1)

        ' The style paramters that will be used to print each cell
        Dim RowFont As Font
        Dim RowForeColor As Color
        Dim RowBackColor As Color
        Dim RowForeBrush As SolidBrush
        Dim RowBackBrush As SolidBrush
        Dim RowAlternatingBackBrush As SolidBrush

        ' Setting the format that will be used to print each cell
        Dim CellFormat As New StringFormat()
        CellFormat.Trimming = StringTrimming.Word
        'CellFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit

        ' Printing each visible cell
        Dim RowBounds As RectangleF
        Dim CurrentX As Double
        Dim ColumnWidth As Double
        While (CurrentRow < TheDataGridView.Rows.Count)
            If (TheDataGridView.Rows(CurrentRow).Visible) Then ' Print the cells of the CurrentRow only if that row is visible
                ' Setting the row font style
                RowFont = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.Font
                If (RowFont Is Nothing) Then ' If the there is no special font style of the CurrentRow, then use the default one associated with the DataGridView control
                    RowFont = TheDataGridView.DefaultCellStyle.Font
                End If

                ' Setting the RowFore style
                RowForeColor = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.ForeColor
                If (RowForeColor.IsEmpty) Then ' If the there is no special RowFore style of the CurrentRow, then use the default one associated with the DataGridView control
                    RowForeColor = TheDataGridView.DefaultCellStyle.ForeColor
                    RowForeBrush = New SolidBrush(RowForeColor)

                    ' Setting the RowBack (for even rows) and the RowAlternatingBack (for odd rows) styles
                    RowBackColor = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.BackColor
                    If (RowBackColor.IsEmpty) Then ' If the there is no special RowBack style of the CurrentRow, then use the default one associated with the DataGridView control
                        RowBackBrush = New SolidBrush(TheDataGridView.DefaultCellStyle.BackColor)
                        RowAlternatingBackBrush = New SolidBrush(TheDataGridView.AlternatingRowsDefaultCellStyle.BackColor)
                    End If
                Else ' If the there is a special RowBack style of the CurrentRow, then use it for both the RowBack and the RowAlternatingBack styles

                    RowBackBrush = New SolidBrush(RowBackColor)
                    RowAlternatingBackBrush = New SolidBrush(RowBackColor)
                End If

                ' Calculating the starting x coordinate that the printing process will start from
                CurrentX = LeftMargin
                If (IsCenterOnPage) Then
                    CurrentX += ((PageWidth - RightMargin - LeftMargin) - mColumnPointsWidth(mColumnPoint)) / 2.0F
                End If

                ' Calculating the entire CurrentRow bounds                
                RowBounds = New RectangleF(CurrentX, CurrentY, mColumnPointsWidth(mColumnPoint), RowsHeight(CurrentRow))

                ' Filling the back of the CurrentRow
                If (CurrentRow Mod 2 = 0) Then
                    g.FillRectangle(RowBackBrush, RowBounds)
                Else
                    g.FillRectangle(RowAlternatingBackBrush, RowBounds)
                End If

                ' Printing each visible cell of the CurrentRow                
                Dim CurrentCell As Integer
                For CurrentCell = mColumnPoints(mColumnPoint).X To mColumnPoints(mColumnPoint).Y - 1
                    If Not (TheDataGridView.Columns(CurrentCell).Visible) Then Continue For ' If the cell is belong to invisible column, then ignore this iteration

                    ' Check the CurrentCell alignment and apply it to the CellFormat
                    If (TheDataGridView.Columns(CurrentCell).DefaultCellStyle.Alignment.ToString().Contains("Right")) Then
                        CellFormat.Alignment = StringAlignment.Far
                    ElseIf (TheDataGridView.Columns(CurrentCell).DefaultCellStyle.Alignment.ToString().Contains("Center")) Then
                        CellFormat.Alignment = StringAlignment.Center
                    Else
                        CellFormat.Alignment = StringAlignment.Near
                    End If

                    ColumnWidth = ColumnsWidth(CurrentCell)
                    Dim CellBounds As New RectangleF(CurrentX, CurrentY, ColumnWidth, RowsHeight(CurrentRow))

                    ' Printing the cell text
                    g.DrawString(TheDataGridView.Rows(CurrentRow).Cells(CurrentCell).EditedFormattedValue.ToString(), RowFont, RowForeBrush, CellBounds, CellFormat)

                    ' Drawing the cell bounds
                    If (TheDataGridView.CellBorderStyle <> DataGridViewCellBorderStyle.None) Then ' Draw the cell border only if the CellBorderStyle is not None
                        g.DrawRectangle(TheLinePen, Int(CurrentX), Int(CurrentY), Int(ColumnWidth), Int(RowsHeight(CurrentRow)))
                    End If

                    CurrentX += ColumnWidth
                Next
                CurrentY += RowsHeight(CurrentRow)

                ' Checking if the CurrentY is exceeds the page boundries
                ' If so then exit the function and returning true meaning another PagePrint action is required
                If (CurrentY > (PageHeight - TopMargin - BottomMargin)) Then
                    CurrentRow += 1
                    Return True
                End If
            End If
            CurrentRow += 1
        End While

        CurrentRow = 0
        mColumnPoint += 1 ' Continue to print the next group of columns

        If (mColumnPoint = mColumnPoints.Length) Then ' Which means all columns are printed
            mColumnPoint = 0
            Return False
        Else
            Return True
        End If
    End Function
    ' The method that calls all other functions
    Public Function DrawDataGridView(ByVal g As Graphics) As Boolean
        Try
            Calculate(g)
            DrawHeader(g)
            Dim bContinue As Boolean = DrawRows(g)
            Return bContinue
        Catch ex As Exception
            MessageBox.Show("Operation failed: " + ex.Message.ToString(), Application.ProductName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class

Class runTl
    Inherits Tl
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Props.SelectedColumns = Props.selCol
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class Table
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), trans("Растяжка"), _
        trans("Цвет"), trans("Всплывающее меню"), trans("Курсор"), trans("Работает"), trans("Полосы прокрутки"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Видимый"), trans("Стиль рамки"), _
        trans("Позволить добавлять строки"), trans("Позволить удалять строки"), trans("Позволить переставлять столбцы"), _
        trans("Позволить растягивать столбцы"), trans("Позволить растягивать строки"), trans("Стиль рамки ячейки"), _
        trans("Отображать заголовки столбцов"), trans("Вышина заголовков столбцов"), trans("Столбцы"), trans("Строки"), _
        trans("Цвет фона ячеек"), trans("Цвет фона выделенных ячеек"), trans("Цвет шрифта ячеек"), _
        trans("Цвет шрифта выделенных ячеек"), trans("Режим редактирования"), trans("Цвет сетки"), _
        trans("Выбор нескольких ячеек"), trans("Только для чтения таблица"), trans("Режим выделения"), _
        trans("Номера выделенных строк"), trans("Номера выделенных столбцов"), trans("Значение ячейки"), _
        trans("Ячейка выделена"), trans("Строка только для чтения"), trans("Столбец только для чтения"), _
        trans("Ячейка только для чтения"), trans("Ширина столбца"), _
        trans("Номер первой строки"), trans("Номер последней строки"), trans("Номер следующей строки"), _
        trans("Номер предыдущей строки"), trans("Значение по координатам"), trans("Номер строки по координатам"), _
        trans("Номер столбца по координатам"), trans("Количество строк таблицы"), trans("Количество столбцов"), _
        trans("Количество выделенных строк"), trans("Количество выделенных столбцов"), _
        trans("Отображать специальный столбец"), trans("Подсказка"), _
        trans("Значение выделеных ячеек"), trans("Поиск в таблице"), trans("Поиск в выделеных ячейках"), _
        trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый"), _
        trans("Шрифт зачеркнутый"), trans("Шрифт размер"), trans("Ширина столбцов"), trans("Вышина строки"), _
        trans("Вышина строк") _
    }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад"), trans("Выделить все"), trans("Очистить таблицу"), _
        trans("Добавить строку"), trans("Добавить копию строк"), _
        trans("Вставить строку"), trans("Вставить копию строк"), _
        trans("Удалить строку"), trans("Сохранить таблицу"), trans("Открыть таблицу"), _
        trans("Сортировать"), _
        trans("Открыть Access"), trans("Открыть Excel"), trans("Сохранить Access"), _
        trans("SQL запрос выборки"), trans("SQL запрос изменения"), _
        trans("Добавить столбец"), trans("Вставить столбец"), trans("Удалить столбец"), _
        trans("Поиск с выделением") _
    }

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Прокрутка"), _
                                trans("Изменилось выделение"), trans("Начало редактирования ячейки"), _
                                trans("Клик по ячейке"), trans("Двойной клик по ячейке"), _
                                trans("Конец редактирования ячеки"), trans("Ячейка в фокусе"), _
                                trans("Ячека потеряла фокус"), trans("Столбец переместили"), _
                                trans("Клик по заголовку столбца"), trans("Двойной клик по заголовку столбца"), _
                                trans("Сортировка столбца"), trans("Изменилась ширина столбца"), _
                                trans("Клик по заголовку строки"), trans("Изменилась вышина строки"), _
                                trans("Добавли строку"), trans("Удалили строку"), _
                                trans("Клик по выделенной ячейке") _
                                }

    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "panel"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runTl, holostoi, isRun, fromEng)
        Else
            CreateObject(New Tl, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' СПИСКОК COMBOBOX
#Region "COMBOBOX"
Public Class C
    Inherits Windows.Forms.ComboBox
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Список")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Выделенная запись")
    Public LastSobyt As String = trans("Изменение выбранной записи")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 23
        Props.DropDownStyle = trans("Нет")
        Props.BackColor = ToMyColor(SystemColors.Window)
    End Sub
End Class

Class runC
    Inherits C
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Me.SelectionLength = 0
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class ComboBoks
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка") _
        , trans("Цвет"), trans("Всплывающее меню"), trans("Растяжка"), trans("Работает") _
        , trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый") _
        , trans("Шрифт зачеркнутый"), trans("Шрифт размер"), trans("Цвет шрифта") _
        , trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина") _
        , trans("Минимальная ширина"), trans("Минимальная вышина") _
        , trans("Максимальная длинна"), trans("Ширина"), trans("Вышина") _
        , trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Видимый") _
        , trans("В фокусе"), trans("Тип") _
        , trans("Ширина раскрывающегося списка") _
        , trans("Список упрощенный"), trans("Высота записей списка") _
        , trans("Записи списка"), trans("Количество раскрывающихся записей") _
        , trans("Сортирован список"), trans("Список раскрыт"), trans("Номер выделенной записи") _
        , trans("Выделенная запись"), trans("Запись по номеру"), trans("Найти номер записи") _
        , trans("Количество записей"), trans("Подсказка") _
        }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед") _
        , trans("Перенести назад"), trans("Очистить"), trans("Добавить запись"), trans("Вставить запись") _
        , trans("Удалить запись"), trans("Удалить запись по номеру")}

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Изменение выбранной записи") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "comboboks"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runC, holostoi, isRun, fromEng)
        Else
            CreateObject(New C, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' СПИСОК ГАЛОЧЕК COMBOBOX
#Region "CHECKED LIST"
Public Class CL
    Inherits Windows.Forms.CheckedListBox
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Список галочек")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Отмеченные записи")
    Public LastSobyt As String = trans("Изменение выбранной записи")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 100
        Props.BackColor = ToMyColor(SystemColors.Window)
    End Sub
End Class

Class runCL
    Inherits CL
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class CheckedList
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка") _
        , trans("Цвет"), trans("Всплывающее меню"), trans("Растяжка"), trans("Работает") _
        , trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый") _
        , trans("Шрифт зачеркнутый"), trans("Шрифт размер"), trans("Цвет шрифта") _
        , trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина") _
        , trans("Минимальная ширина"), trans("Минимальная вышина") _
        , trans("Ширина"), trans("Вышина") _
        , trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Видимый") _
        , trans("В фокусе"), trans("Тип"), trans("Подсказка") _
        , trans("Записи списка"), trans("Сортирован список"), trans("Номер выделенной записи") _
        , trans("Выделенная запись"), trans("Запись по номеру"), trans("Найти номер записи") _
        , trans("Количество записей"), trans("Отметка по клику") _
        , trans("Ширина колонок списка"), trans("Горизонтальная прокрутка"), trans("Многоколонность") _
        , trans("Позволить выбирать записи"), trans("Номера отмеченых записей"), trans("Отмеченные записи") _
      }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед") _
        , trans("Перенести назад"), trans("Очистить"), trans("Добавить запись"), trans("Вставить запись") _
        , trans("Удалить запись"), trans("Удалить запись по номеру")}

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Изменение выбранной записи") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "checkedlist"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runCL, holostoi, isRun, fromEng)
        Else
            CreateObject(New CL, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' БОЛЬШОЙ COMBOBOX
#Region "LISTBOKS"
Public Class L
    Inherits Windows.Forms.ListBox
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Большой список")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Отмеченные записи")
    Public LastSobyt As String = trans("Изменение выбранной записи")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 100
        Props.BackColor = ToMyColor(SystemColors.Window)
    End Sub
    Public Sub SelectAll()
        Dim i As Integer
        For i = 0 To Me.Items.Count - 1
            Me.SelectedItems.Add(Me.Items.Item(i))
        Next
    End Sub
End Class

Class runL
    Inherits L
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        Props.MultiSelectItems = Props.MultiSelectItems
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class ListBoks
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка") _
        , trans("Цвет"), trans("Всплывающее меню"), trans("Растяжка"), trans("Работает") _
        , trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый") _
        , trans("Шрифт зачеркнутый"), trans("Шрифт размер"), trans("Цвет шрифта") _
        , trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина") _
        , trans("Минимальная ширина"), trans("Минимальная вышина") _
        , trans("Ширина"), trans("Вышина") _
        , trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Видимый") _
        , trans("В фокусе"), trans("Тип"), trans("Подсказка") _
        , trans("Записи списка"), trans("Сортирован список"), trans("Номер выделенной записи") _
        , trans("Выделенная запись"), trans("Запись по номеру"), trans("Найти номер записи") _
        , trans("Количество записей"), trans("Выбор нескольких записей") _
        , trans("Ширина колонок списка"), trans("Горизонтальная прокрутка"), trans("Многоколонность") _
        , trans("Позволить выбирать записи"), trans("Номера выделенных записей"), trans("Выделенные записи") _
      }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед") _
        , trans("Перенести назад"), trans("Очистить"), trans("Добавить запись"), trans("Вставить запись") _
        , trans("Удалить запись"), trans("Удалить запись по номеру"), trans("Выделить все")}

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Изменение выбранной записи") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "listboks"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runL, holostoi, isRun, fromEng)
        Else
            CreateObject(New L, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' НАДПИСЬ LABEL
#Region "LABEL"
Public Class Lb
    Inherits Windows.Forms.Label
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Надпись")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Текст")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 13
        Props.TextAlign = trans("Центр")
    End Sub
End Class

Class runLb
    Inherits Lb
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class Label
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("АвтоТроеточие"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), trans("Стиль рамки"), _
        trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый"), _
        trans("Шрифт зачеркнутый"), trans("Цвет шрифта"), trans("Рисунок"), trans("Положение рисунка"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Поле слева"), trans("Поле сверху"), _
        trans("Поле справа"), trans("Поле снизу"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Шрифт размер"), _
        trans("Положение текста"), trans("Видимый"), trans("В фокусе"), trans("Тип"), trans("Подсказка")}
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "label"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runLb, holostoi, isRun, fromEng)
        Else
            CreateObject(New Lb, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' НАДПИСЬ LINKLABEL
#Region "LinkLabel"
Public Class LLb
    Inherits Windows.Forms.LinkLabel
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Ссылка")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Ссылка надписи")
    Public LastSobyt As String = trans("Клик по ссылке")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 75 : Props.Height = 13
    End Sub
End Class

Class runLLb
    Inherits LLb
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class LinkLabel
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("АвтоТроеточие"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), trans("Стиль рамки"), _
        trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый"), _
        trans("Шрифт зачеркнутый"), trans("Цвет шрифта"), trans("Рисунок"), trans("Положение рисунка"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Поле слева"), trans("Поле сверху"), _
        trans("Поле справа"), trans("Поле снизу"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Шрифт размер"), _
        trans("Положение текста"), trans("Видимый"), trans("В фокусе"), trans("Тип"), _
        trans("Цвет активной ссылки"), trans("Цвет нерабочей ссылки"), trans("Цвет ссылки"), _
        trans("Цвет посещенной ссылки"), trans("Начало ссылки"), trans("Длинна ссылки"), _
        trans("Стиль подчеркивания"), trans("Ссылка посещена"), trans("Ссылка рабочая"), _
        trans("Переходить в интернет по ссылке"), trans("Ссылка надписи"), trans("Подсказка") _
    }
    'ActiveLinkColor("Цвет активной ссылки"), DisabledLinkColor("Цвет нерабочей ссылки"), LinkColor("Цвет ссылки"), _
    'VisitedLinkColor("Цвет посещенной ссылки"), LinkStart("Начало ссылки"), LinkLength("Длинна ссылки"), _
    'LinkBehavior("Стиль подчеркивания"), LinkVisited("Ссылка посещена"), LinkEnabled("Ссылка рабочая"), _
    'InternetLink("Переходить в интернет по ссылке"), LinkName("Ссылка надписи") _
    '
    ', GoInternetLink("Перейти в интернет по ссылке")

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад"), trans("Перейти в интернет по ссылке")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Клик по ссылке") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "linklabel"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runLLb, holostoi, isRun, fromEng)
        Else
            CreateObject(New LLb, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' РИСУНОК PICTUREBOKS
#Region "PictureBoks"
Public Class Pb
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Рисунок")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Рисунок")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName)
        Props.Width = 75 : Props.Height = 75
        Props.BackColor = "172; 172; 172;"
    End Sub
End Class

Class runPb
    Inherits Pb
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class PictureBoks
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), trans("Стиль рамки"), _
        trans("Рисунок"), trans("Стиль рисунка"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
         trans("Видимый"), trans("В фокусе"), trans("Тип"), trans("Подсказка")}
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "pictureboks"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runPb, holostoi, isRun, fromEng)
        Else
            CreateObject(New Pb, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ДОКУМЕНТ RICHTEXT
#Region "RICHTEXT"
Public Class RT
    Inherits Windows.Forms.RichTextBox
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Текстовый документ")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Текст")
    Public LastSobyt As String = trans("Изменение текста")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 100 : Props.Height = 100
        Props.BackColor = ToMyColor(Color.White)
        Props.BorderStyle = LCase(trans("объем"))
        Props.EnableAutoDragDrop = trans("Да")
        Props.HideSelection = trans("Нет")
        Props.MultiLine = trans("Да")
        Props.ScrollBars = trans("Вертикальная")
    End Sub
    ' Convert the unit that is used by the .NET framework (1/100 inch) 
    ' and the unit that is used by Win32 API calls (twips 1/1440 inch)
    Private Const AnInch As Double = 14.4

    <StructLayout(LayoutKind.Sequential)> _
     Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure CHARRANGE
        Public cpMin As Integer          ' First character of range (0 for start of doc)
        Public cpMax As Integer          ' Last character of range (-1 for end of doc)
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure FORMATRANGE
        Public hdc As IntPtr             ' Actual DC to draw on
        Public hdcTarget As IntPtr       ' Target DC for determining text formatting
        Public rc As Rect                ' Region of the DC to draw to (in twips)
        Public rcPage As Rect            ' Region of the whole DC (page size) (in twips)
        Public chrg As CHARRANGE         ' Range of text to draw (see above declaration)
    End Structure

    Private Const WM_USER As Integer = &H400
    Private Const EM_FORMATRANGE As Integer = WM_USER + 57

    Private Declare Function SendMessage Lib "USER32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

    ' Render the contents of the RichTextBox for printing
    '	Return the last character printed + 1 (printing start from this point for next page)
    Public Function Print(ByVal charFrom As Integer, ByVal charTo As Integer, _
                        ByVal e As System.Drawing.Printing.PrintPageEventArgs, Optional ByVal yPos As Single = 0) As Integer

        ' Mark starting and ending character 
        Dim cRange As CHARRANGE
        cRange.cpMin = charFrom
        cRange.cpMax = charTo

        ' Calculate the area to render and print
        Dim rectToPrint As RECT
        If yPos = 0 Then yPos = e.MarginBounds.Top
        rectToPrint.Top = yPos * AnInch
        rectToPrint.Bottom = e.MarginBounds.Bottom * AnInch
        rectToPrint.Left = e.MarginBounds.Left * AnInch
        rectToPrint.Right = e.MarginBounds.Right * AnInch

        ' Calculate the size of the page
        Dim rectPage As RECT
        rectPage.Top = e.PageBounds.Top * AnInch
        rectPage.Bottom = e.PageBounds.Bottom * AnInch
        rectPage.Left = e.PageBounds.Left * AnInch
        rectPage.Right = e.PageBounds.Right * AnInch

        Dim hdc As IntPtr = e.Graphics.GetHdc()

        Dim fmtRange As FORMATRANGE
        fmtRange.chrg = cRange                 ' Indicate character from to character to 
        fmtRange.hdc = hdc                     ' Use the same DC for measuring and rendering
        fmtRange.hdcTarget = hdc               ' Point at printer hDC
        fmtRange.rc = rectToPrint              ' Indicate the area on page to print
        fmtRange.rcPage = rectPage             ' Indicate whole size of page

        Dim res As IntPtr = IntPtr.Zero

        Dim wparam As IntPtr = IntPtr.Zero
        wparam = New IntPtr(1)

        ' Move the pointer to the FORMATRANGE structure in memory
        Dim lparam As IntPtr = IntPtr.Zero
        lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
        Marshal.StructureToPtr(fmtRange, lparam, False)

        ' Send the rendered data for printing 
        res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

        ' Free the block of memory allocated
        Marshal.FreeCoTaskMem(lparam)

        ' Release the device context handle obtained by a previous call
        e.Graphics.ReleaseHdc(hdc)

        ' Return last + 1 character printer
        Return res.ToInt32()
    End Function
End Class

Class runRT
    Inherits RT
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class RichText
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка") _
        , trans("Цвет"), trans("Стиль рамки") _
        , trans("Всплывающее меню"), trans("Растяжка"), trans("Работает") _
        , trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый") _
        , trans("Шрифт зачеркнутый"), trans("Цвет шрифта"), trans("Скрывать выделение") _
        , trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина") _
        , trans("Минимальная ширина"), trans("Минимальная вышина") _
        , trans("Максимальная длинна"), trans("Многострочность"), trans("Шрифт размер") _
        , trans("Только для чтения"), trans("Полосы прокрутки"), trans("Ширина"), trans("Вышина") _
        , trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле") _
        , trans("Видимый"), trans("Перенос по словам") _
        , trans("Выделенный текст"), trans("Начало выделения"), trans("Длинна выделения") _
        , trans("Номер символа по координатам"), trans("Номер первого символа строки") _
        , trans("Номер первого символа текущей строки"), trans("Номер строки по номеру символа") _
        , trans("X по номеру символа"), trans("Y по номеру символа") _
        , trans("Строка"), trans("Количество строк"), trans("Символ"), trans("Количество символов") _
        , trans("В фокусе"), trans("Тип"), trans("Переходить в интернет по ссылке") _
        , trans("Подсвечивать ссылки"), trans("Позволить перенос выделенного") _
        , trans("Масштаб"), trans("RTF код документа") _
        , trans("Выделенный RTF"), trans("Выделенное положение текста") _
        , trans("Выделенный задний фон"), trans("Выделенный цвет текста") _
        , trans("Выделенный размер красной строки"), trans("Выделенный отступ слева") _
        , trans("Выделенный отступ справа"), trans("Выделенный имеет маркер") _
        , trans("Выделенное вертикальное смещение"), trans("Выделенный шрифт размер") _
        , trans("Выделенный шрифт"), trans("Выделенный шрифт жирный"), trans("Выделенный шрифт курсив") _
        , trans("Выделенный шрифт подчеркнутый"), trans("Выделенный шрифт зачеркнутый") _
        , trans("Выделенный текст заблокирован"), trans("Подсказка") _
    }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед") _
        , trans("Перенести назад"), trans("Копировать"), trans("Вырезать"), trans("Вставить"), trans("Выделить все") _
        , trans("Отменить"), trans("Повторить") _
        , trans("Сохранить документ"), trans("Открыть документ"), trans("Прокрутить до курсора") _
        }
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Горизонтальная прокрутка"), trans("Вертикальная прокрутка"), _
                                trans("Клик по ссылке документа") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "richtext"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runRT, holostoi, isRun, fromEng)
        Else
            CreateObject(New RT, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' ОКНО ЦВЕТА COLORDIALOG 
#Region "COLORDIALOG"
Public Class CD
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно цвета")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Запустить окно")
    Public LastSobyt As String
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        MyBase.BackColor = Color.Transparent
    End Sub
    Overloads Property Height()
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Width()
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value)
        End Set
    End Property
End Class

Class runCD
    Inherits System.Windows.Forms.ColorDialog
    Implements MyEvents, MyDialogs
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно цвета")
    Public MyObj As Object
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)

    Public Sub Load()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Dim nam As String
    Property Name() As String Implements MyDialogs.Name
        Get
            If nam = "" Then nam = proj.GiveName(defaultName)
            Return nam
        End Get
        Set(ByVal value As String)
            nam = value
        End Set
    End Property
    Overloads Property Left()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Top()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Public Sub BringToFront()
    End Sub
    Public Sub SendToBack()
    End Sub
End Class

Public Class ColorDialog
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Тип"), trans("X"), trans("Y"), _
                                    trans("Вспомогательное поле"), trans("Выбранный цвет"), trans("Была нажата отмена")}
    ' Все методы данного объекта
    Public Methods() As String = {trans("Запустить окно")}
    ' Все события данного объекта
    Public Sobyts() As String = {}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "colordialog"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runCD, holostoi, isRun, fromEng)
        Else
            CreateObject(New CD, holostoi, isRun, fromEng)
            Me.obj.image = Pictures32.Images(Picture)
        End If
    End Sub
End Class
#End Region

' ОКНО ШРИФТА FONTDIALOG 
#Region "FONTDIALOG"
Public Class FD
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно шрифта")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Запустить окно")
    Public LastSobyt As String
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        MyBase.BackColor = Color.Transparent
    End Sub
    Overloads Property Height()
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Width()
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value)
        End Set
    End Property
End Class

Class runFD
    Inherits System.Windows.Forms.FontDialog
    Implements MyEvents, MyDialogs
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно шрифта")
    Public MyObj As Object
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)

    Public Sub Load()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Dim nam As String
    Property Name() As String Implements MyDialogs.Name
        Get
            If nam = "" Then nam = proj.GiveName(defaultName)
            Return nam
        End Get
        Set(ByVal value As String)
            nam = value
        End Set
    End Property
    Overloads Property Left()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Top()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Public Sub BringToFront()
    End Sub
    Public Sub SendToBack()
    End Sub
End Class

Public Class FontDialog
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Тип"), _
            trans("Вспомогательное поле"), trans("Выбранный цвет"), trans("Была нажата отмена") _
            , trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый") _
            , trans("Шрифт зачеркнутый"), trans("Шрифт размер"), trans("Позволить выбирать цвет") _
            , trans("Позволить выбирать подчеркивания"), trans("X"), trans("Y") _
        }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Запустить окно")}
    ' Все события данного объекта
    Public Sobyts() As String = {}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "fontdialog"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runFD, holostoi, isRun, fromEng)
        Else
            CreateObject(New FD, holostoi, isRun, fromEng)
            Me.obj.image = Pictures32.Images(Picture)
        End If
    End Sub
End Class
#End Region

' ОКНО ШРИФТА PATHDIALOG 
#Region "PATHDIALOG"
Public Class PD
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно папок")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Запустить окно")
    Public LastSobyt As String
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        MyBase.BackColor = Color.Transparent
    End Sub
    Overloads Property Height()
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Width()
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value)
        End Set
    End Property
End Class

Class runPD
    Inherits System.Windows.Forms.ColorDialog
    Implements MyEvents, MyDialogs
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно папок")
    Public MyObj As Object
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public dialog As New FolderBrowserDialog

    Public Sub Load()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Dim nam As String
    Property Name() As String Implements MyDialogs.Name
        Get
            If nam = "" Then nam = proj.GiveName(defaultName)
            Return nam
        End Get
        Set(ByVal value As String)
            nam = value
        End Set
    End Property
    Overloads Property Left()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Top()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Public Sub BringToFront()
    End Sub
    Public Sub SendToBack()
    End Sub
End Class

Public Class PathDialog
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Тип"), _
            trans("Вспомогательное поле"), trans("Была нажата отмена") _
            , trans("Надпись в окне"), trans("Выбранная папка"), trans("X"), trans("Y") _
        }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Запустить окно")}
    ' Все события данного объекта
    Public Sobyts() As String = {}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "pathdialog"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runPD, holostoi, isRun, fromEng)
        Else
            CreateObject(New PD, holostoi, isRun, fromEng)
            Me.obj.image = Pictures32.Images(Picture)
        End If
    End Sub
End Class
#End Region

' ОКНО СОХРАНЕНИЯ SAVEDIALOG 
#Region "SAVEDIALOG"
Public Class SD
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно сохранения")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Запустить окно")
    Public LastSobyt As String
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        MyBase.BackColor = Color.Transparent
        Props.CheckFileExists = trans("Нет")
    End Sub
    Overloads Property Height()
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Width()
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value)
        End Set
    End Property
End Class

Class runSD
    Inherits System.Windows.Forms.ColorDialog
    Implements MyEvents, MyDialogs
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно сохранения")
    Public MyObj As Object
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public dialog As New SaveFileDialog

    Public Sub Load()

    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Dim nam As String
    Property Name() As String Implements MyDialogs.Name
        Get
            If nam = "" Then nam = proj.GiveName(defaultName)
            Return nam
        End Get
        Set(ByVal value As String)
            nam = value
        End Set
    End Property
    Overloads Property Left()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Top()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Public Sub BringToFront()
    End Sub
    Public Sub SendToBack()
    End Sub
End Class

Public Class SaveDialog
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Тип"), _
            trans("Вспомогательное поле"), trans("Была нажата отмена"), trans("X"), trans("Y") _
            , trans("Добавлять расширение файлу"), trans("Проверять наличие файла") _
            , trans("Проверять наличие папки"), trans("Имя файла"), trans("Фильтр файлов") _
            , trans("Номер фильтра"), trans("Начальная папка"), trans("Заголовок") _
        }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Запустить окно")}
    ' Все события данного объекта
    Public Sobyts() As String = {}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "savedialog"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runSD, holostoi, isRun, fromEng)
        Else
            CreateObject(New SD, holostoi, isRun, fromEng)
            If holostoi = False Then obj.Props.Filter = trans("Рисунки") & "|*.jpg;*.bmp|" & trans("Все файлы") & "|*.*"
            Me.obj.image = Pictures32.Images(Picture)
        End If
    End Sub
End Class
#End Region

' ОКНО ЗАГРУЗКИ OPENDIALOG 
#Region "OPENDIALOG"
Public Class OD
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно открытия")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Запустить окно")
    Public LastSobyt As String
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        MyBase.BackColor = Color.Transparent
    End Sub
    Overloads Property Height()
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Width()
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value)
        End Set
    End Property
End Class

Class runOD
    Inherits System.Windows.Forms.ColorDialog
    Implements MyEvents, MyDialogs
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно открытия")
    Public MyObj As Object
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public dialog As New OpenFileDialog

    Public Sub Load()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Dim nam As String
    Property Name() As String Implements MyDialogs.Name
        Get
            If nam = "" Then nam = proj.GiveName(defaultName)
            Return nam
        End Get
        Set(ByVal value As String)
            nam = value
        End Set
    End Property
    Overloads Property Left()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Top()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Public Sub BringToFront()
    End Sub
    Public Sub SendToBack()
    End Sub
End Class

Public Class OpenDialog
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Тип"), _
            trans("Вспомогательное поле"), trans("Была нажата отмена"), trans("X"), trans("Y") _
            , trans("Добавлять расширение файлу"), trans("Проверять наличие файла") _
            , trans("Проверять наличие папки"), trans("Имя файла"), trans("Фильтр файлов") _
            , trans("Номер фильтра"), trans("Начальная папка"), trans("Заголовок") _
            , trans("Выбор нескольких файлов") _
        }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Запустить окно")}
    ' Все события данного объекта
    Public Sobyts() As String = {}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "opendialog"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runOD, holostoi, isRun, fromEng)
        Else
            CreateObject(New OD, holostoi, isRun, fromEng)
            If holostoi = False Then obj.Props.Filter = trans("Рисунки") & "|*.jpg;*.bmp|" & trans("Все файлы") & "|*.*"
            Me.obj.image = Pictures32.Images(Picture)
        End If
    End Sub
End Class
#End Region

' ОКНО ПЕЧАТИ PRINTDIALOG 
#Region "PRINTDIALOG"
Public Class PrD
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно печати")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Запустить окно печати")
    Public LastSobyt As String
    Public MyObj As Object

    Public rtfPrint As Object
    Public tablPrint As Object
    Public objPrint As String
    Public picPrint As Image
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        Props.PaddingLeft = 30
        Props.PaddingRight = 10
        Props.PaddingTop = 10
        Props.PaddingBottom = 10
        MyBase.BackColor = Color.Transparent
    End Sub
    Overloads Property Height()
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Width()
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value)
        End Set
    End Property
End Class

Class runPrD
    Inherits System.Windows.Forms.FontDialog
    Implements MyEvents, MyDialogs
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Окно печати")
    Public MyObj As Object
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)

    Public PageDialog As New PageSetupDialog
    Public PrinDialog As New Windows.Forms.PrintDialog
    Public PrevDialog As New PrintPreviewDialog
    Public WithEvents PrintDoc As New System.Drawing.Printing.PrintDocument

    Public Sub Load()
        PrinDialog.AllowSomePages = True
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Dim nam As String
    Property Name() As String Implements MyDialogs.Name
        Get
            If nam = "" Then nam = proj.GiveName(defaultName)
            Return nam
        End Get
        Set(ByVal value As String)
            nam = value
        End Set
    End Property

    ' ПЕЧАТАЕТ ТО ЧТО НАХОДИТСЯ В СВОЙСТВАХ ТЕКСТ НА ПЕЧАТЬ, РИСУНОК НАПЕЧАТЬ И Т.Д.
    Public rtfPrint As Object
    Public tablPrint As Object
    Public objPrint As String
    Public picPrint As Image
    Public isPreview As Boolean

    Dim imageTyped = False, objTyped = False, tableTyped = False, rtfTyped As Boolean = False
    Dim checkPrint As Integer, txtRT As runRT
    Dim imObj As String
    Public Sub PrintDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDoc.BeginPrint
        ' обнуление рисунка
        imageTyped = False : objTyped = False
        Threading.Thread.CurrentThread.Sleep(1)
        If objPrint <> "" Then imObj = New PropertysOther(Nothing).ScreenshotOfObject(objPrint)
        ' обнуление документа и текста
        checkPrint = 0 : txtRT = Nothing : rtfTyped = False
        ' обнуление таблицы
        tableTyped = False
        If tablPrint IsNot Nothing Then
            If IsArray(tablPrint) Then tablPrint = tablPrint(0)
            tablPrint.obj.DataGridViewPrinter(tablPrint.obj, PrintDoc, DaOrNet(Props.TableOnCenter), True, Props.PrintText, Font, Color, False)
        End If
    End Sub
    Dim numPage As Integer = 0
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        Try
            Do
                Dim yPosition = 0, xPosition = 0, wSize = e.MarginBounds.Width, hSize As Single
                e.Graphics.Clear(Drawing.Color.White)
                numPage += 1

                ' Если так и не нашлось страниц для печати, то всё отменить
                If isPreview = False Then
                    If numPage > e.PageSettings.PrinterSettings.ToPage Then
                        e.Cancel = True : e.HasMorePages = False : numPage = 0 : Exit Sub
                    End If
                End If

                ' РИСУНОК. Если рисунок еще небыл нарисован
                If imageTyped = False And picPrint Is Nothing = False Then
                    xPosition = e.MarginBounds.Left : yPosition = e.MarginBounds.Top
                    hSize = picPrint.Height : wSize = picPrint.Width
                    ' настройка рисунка по ширине
                    If e.MarginBounds.Width < wSize Then
                        Dim proporc As Double = e.MarginBounds.Width / wSize
                        hSize *= proporc : wSize *= proporc
                    End If
                    ' настройка рисунка по вышине
                    If e.MarginBounds.Height < hSize Then
                        Dim proporc As Double = e.MarginBounds.Height / hSize
                        hSize *= proporc : wSize *= proporc
                    End If
                    ' расположение рисунка по середине
                    If e.MarginBounds.Width > wSize Then xPosition = e.MarginBounds.Left + (e.MarginBounds.Width - wSize) / 2
                    ' рисование рисунка 
                    e.Graphics.DrawImage(picPrint, New Rectangle(xPosition, yPosition, wSize, hSize))
                    ' перенести указатель текущей позиции ниже рисунка
                    yPosition += hSize + Font.GetHeight(e.Graphics)
                    ' отметиться что рисунок уже напечатался
                    imageTyped = True
                End If

                ' ОБЪЕКТ. Если объект еще небыл нарисован
                If objTyped = False And objPrint <> "" And imObj <> "" Then
                    Dim picObj As Image = Image.FromFile(imObj)
                    If yPosition > 0 And yPosition + picObj.Height > e.MarginBounds.Height Then e.HasMorePages = True : GoTo cikl
                    xPosition = e.MarginBounds.Left
                    If yPosition = 0 Then yPosition = e.MarginBounds.Top
                    hSize = picObj.Height : wSize = picObj.Width
                    ' настройка рисунка по ширине
                    If e.MarginBounds.Width < wSize Then
                        Dim proporc As Double = e.MarginBounds.Width / wSize
                        hSize *= proporc : wSize *= proporc
                    End If
                    ' настройка рисунка по вышине
                    If e.MarginBounds.Height < hSize Then
                        Dim proporc As Double = e.MarginBounds.Height / hSize
                        hSize *= proporc : wSize *= proporc
                    End If
                    ' расположение рисунка по середине
                    If e.MarginBounds.Width > wSize Then xPosition = e.MarginBounds.Left + (e.MarginBounds.Width - wSize) / 2
                    ' рисование рисунка 
                    e.Graphics.DrawImage(picObj, New Rectangle(xPosition, yPosition, wSize, hSize))
                    ' перенести указатель текущей позиции ниже рисунка
                    yPosition += hSize + Font.GetHeight(e.Graphics)
                    ' отметиться что рисунок уже напечатался
                    objTyped = True
                End If

                ' ТЕКСТ. Подготовка текста на печать
                If Props.PrintText <> "" And txtRT Is Nothing And tablPrint Is Nothing Then
                    ' вклинить текст в ртф документ
                    txtRT = New runRT
                    txtRT.Text = Props.PrintText
                    txtRT.SelectAll() : txtRT.SelectionFont = Font : txtRT.SelectionColor = Color
                    txtRT.Text &= vbCrLf & vbCrLf
                End If
                ' ДОКУМЕНТ. Подготовка документа на печать
                If rtfPrint IsNot Nothing Then
                    If IsArray(rtfPrint) Then rtfPrint = rtfPrint(0)
                    ' Не было перед ним просто текста на печать или был
                    If txtRT Is Nothing Then
                        txtRT = rtfPrint.obj
                        ' Если был, то если он еще не присвоен, то дописать ртф к простому тексту
                    ElseIf checkPrint = 0 Then
                        txtRT.SelectionStart = txtRT.TextLength - 1
                        Dim tmpRt As New runRT : tmpRt.Rtf = rtfPrint.obj.rtf
                        tmpRt.SelectAll()
                        txtRT.SelectedRtf = tmpRt.SelectedRtf
                    End If
                End If
                ' Итоговая печать объединенного документа (Текст + ртф)
                If txtRT IsNot Nothing And rtfTyped = False Then
                    ' После рисунка не осталось места для текста на этой странице
                    If yPosition > e.MarginBounds.Height Then e.HasMorePages = True : GoTo cikl
                    ' Print the content of the RichTextBox. Store the last character printed.
                    checkPrint = txtRT.Print(checkPrint, txtRT.TextLength, e, yPosition)

                    ' Look for more pages
                    If checkPrint < txtRT.TextLength Then
                        e.HasMorePages = True : GoTo cikl
                    Else
                        e.HasMorePages = False : yPosition = 1 : rtfTyped = True
                    End If
                End If

                ' ТАБЛИЦА. Печать таблицы
                If tablPrint IsNot Nothing And tableTyped = False Then
                    ' пропустить страницу, т.к. на ней уже напечатали чтото
                    If yPosition > 0 Then e.HasMorePages = True : GoTo cikl
                    ' Печать таблицы
                    Dim more As Boolean = tablPrint.obj.DrawDataGridView(e.Graphics)

                    ' Look for more pages
                    If more Then
                        e.HasMorePages = True : GoTo cikl
                    Else
                        e.HasMorePages = False : yPosition = 1 : tableTyped = True
                    End If
                End If

                ' Тут смотрим, если еще не дошли до страницы, с которой надо начинать печатать, 
cikl:           ' то пройти этот раз будет холостым - пройдемся заново. Как бы уже следующей страницей
            Loop While numPage < (e.PageSettings.PrinterSettings.FromPage) And isPreview = False

            ' Чтобы если страницы кончились, то не печатать дальше ничего
            If isPreview = False Then
                If numPage >= e.PageSettings.PrinterSettings.ToPage Then
                    e.HasMorePages = False
                End If
            End If
            ' Обнулить данные если конец печати
            If e.HasMorePages = False Then numPage = 0

        Catch ex As Exception
            numPage = 0 : Throw ex
        End Try
    End Sub

    Overloads Property Left()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Top()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Public Sub BringToFront()
    End Sub
    Public Sub SendToBack()
    End Sub
End Class

Public Class PrintDialog
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Тип") _
            , trans("Вспомогательное поле"), trans("Выбранный цвет"), trans("Была нажата отмена") _
            , trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый") _
            , trans("Шрифт зачеркнутый"), trans("Шрифт размер") _
            , trans("Текст на печать"), trans("Документ на печать"), trans("Таблица на печать"), trans("Рисунок на печать") _
            , trans("Объект на печать") _
            , trans("Поле слева"), trans("Поле сверху"), trans("Поле справа"), trans("Поле снизу") _
            , trans("X"), trans("Таблица в центре"), trans("Y") _
            , trans("Страница начала печати"), trans("Страница конца печати"), trans("Число копий") _
        }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Запустить предварительный просмотр"), trans("Запустить настройки страницы") _
            , trans("Запустить окно печати"), trans("Напечатать")}

    ' trans("Текст на печать"), trans("Рисунок на печать") _
    '  trans("Запустить предварительный просмотр"), trans("Запустить настройки страницы") _
    ', trans("Запустить окно печати")

    ' Все события данного объекта
    Public Sobyts() As String = {}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "printdialog"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runPrD, holostoi, isRun, fromEng)
        Else
            CreateObject(New PrD, holostoi, isRun, fromEng)
            Me.obj.image = Pictures32.Images(Picture)
        End If
    End Sub
End Class
#End Region

' СЕКУНДОМЕР TIMER 
#Region "TIMER"
Public Class Tm
    Inherits Windows.Forms.PictureBox
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Секундомер")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Старт")
    Public LastSobyt As String = trans("Тикнул")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Me.Name = proj.GiveName(defaultName)
        Me.SizeMode = PictureBoxSizeMode.StretchImage : MyBase.Height = 16 : MyBase.Width = 16
        MyBase.BackColor = Color.Transparent
        Props.Enabled = trans("Нет")
    End Sub
    Overloads Property Height()
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Width()
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value)
        End Set
    End Property
End Class

Class runTm
    Inherits Windows.Forms.Timer
    Implements MyEvents, MyDialogs
    Public TypeObj As String = "PoluObj"
    Public defaultName As String = trans("Секундомер")
    Public MyObj As Object
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Props As New PropertysRun(Me)
    Public Sub Load()
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Dim nam As String
    Property Name() As String Implements MyDialogs.Name
        Get
            If nam = "" Then nam = proj.GiveName(defaultName)
            Return nam
        End Get
        Set(ByVal value As String)
            nam = value
        End Set
    End Property
    Overloads Property Left()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Overloads Property Top()
        Get
            Return 0
        End Get
        Set(ByVal value)
        End Set
    End Property
    Public Sub BringToFront()
    End Sub
    Public Sub SendToBack()
    End Sub

End Class

Public Class Timer
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Тип"), trans("Работает"), _
                                    trans("Интервал отсчета"), trans("Прошло интервалов"), trans("Вспомогательное поле") _
                                    , trans("X"), trans("Y")}
    ' Все методы данного объекта
    Public Methods() As String = {trans("Старт"), trans("Стоп")}

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Тикнул")}
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "timer"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runTm, holostoi, isRun, fromEng)
        Else
            CreateObject(New Tm, holostoi, isRun, fromEng)
            Me.obj.image = Pictures32.Images(Picture)
            '  If holostoi = False Then Me.obj.props.enabled = trans("Нет")
            If holostoi = False Then Me.obj.props.interval = 1000
        End If
    End Sub
End Class
#End Region

' КАЛЕНДАРЬ CALENDAR
#Region "CALENDAR"
Public Class Cr
    Inherits Windows.Forms.DateTimePicker
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Календарь")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Выбранная дата")
    Public LastSobyt As String = trans("Значение изменилось")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName)
        Props.Width = 175 : Props.Height = 13
        Props.CalendarDateFormat = trans("по выбору")
        Props.CustomDateFormat = "dd MMM yyyy" & " " & trans("г") & "."
    End Sub
End Class

Class runCr
    Inherits Cr
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class Calendar
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Текст"), trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Всплывающее меню"), trans("Курсор"), trans("Растяжка"), trans("Работает"), _
        trans("Шрифт"), trans("Шрифт жирный"), trans("Шрифт курсив"), trans("Шрифт подчеркнутый"), _
        trans("Шрифт зачеркнутый"), trans("Цвет шрифта"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Шрифт размер"), _
        trans("Видимый"), trans("В фокусе"), trans("Тип"), _
        trans("Формат даты"), trans("Формат даты по выбору"), trans("Кнопки вверх вниз"), _
        trans("Выбранная дата"), trans("Подсказка") _
    }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Значение изменилось"), trans("Календарь раскрылся"), trans("Календарь закрылся") _
                                }

    'trans("Формат даты"), trans("Формат даты по выбору"), trans("Кнопки вверх вниз"), _
    'trans("Выбранная дата") _

    'trans("Значение изменилось"), trans("Календарь раскрылся"), trans("Календарь закрылся") _

    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "calendar"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runCr, holostoi, isRun, fromEng)
        Else
            CreateObject(New Cr, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' БЕГУНОК TRACKBAR
#Region "TRACKBAR"
Public Class Tb
    Inherits Windows.Forms.TrackBar
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Бегунок")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Значение")
    Public LastSobyt As String = trans("Значение изменилось")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Me.AutoSize = False
        Props.Name = proj.GiveName(defaultName)
        Props.Width = 150 : Props.Height = 40
        Props.TickStyle = trans("Нижний")
        Props.Value = "0"
        Props.BackColor = ToMyColor(Me.BackColor)
        Props.Orientation = trans("горизонтальная")
    End Sub
End Class

Class runTb
    Inherits Tb
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class TrackBar
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Всплывающее меню"), trans("Курсор"), trans("Растяжка"), trans("Работает"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Видимый"), trans("В фокусе"), trans("Тип"), trans("Значение"), trans("Ориентация"), _
        trans("Сдвиг большой"), trans("Сдвиг малый"), trans("Максимум"), _
        trans("Минимум"), trans("Стиль бегунка"), trans("Частота отметок"), trans("Подсказка") _
    }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Значение изменилось"), trans("Движение бегунка") _
                                }

    'LargeChange("Сдвиг большой"), SmallChange("Сдвиг малый"), Maximum("Максимум"), _
    'Minimum("Минимум"), TickStyle("Стиль бегунка"), TickFrequency("Частота отметок") _

    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "trackbar"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runTb, holostoi, isRun, fromEng)
        Else
            CreateObject(New Tb, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' Триал Trial
#Region "TRIAL"
Public Class Tr
    Inherits Windows.Forms.Panel
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Триал")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Включить триальный отсчет")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    ' Переменные Триала
    Public TextB As TextBox
    Public Buttn As Windows.Forms.Button
    Sub New()
        If proj Is Nothing Then Me.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.BorderStyle = trans("линия")
        Props.Height = 29 : Props.Width = 291
        ' настройка объектов Триала
        Buttn = New Windows.Forms.Button
        Me.Controls.Add(Buttn)
        Buttn.Width = 90
        Buttn.Left = Me.Width - Buttn.Width - 3 : Buttn.Top = 3
        Buttn.Anchor = AnchorStyles.Bottom + AnchorStyles.Right
        Buttn.UseVisualStyleBackColor = True
        TextB = New TextBox
        Me.Controls.Add(TextB)
        TextB.Width = Me.Width - Buttn.Width - 9
        TextB.Left = 3 : TextB.Top = 3
        TextB.Anchor = AnchorStyles.Bottom + AnchorStyles.Right + AnchorStyles.Left + AnchorStyles.Top
        TextB.Multiline = True
        ' Настройка ключей
        Dim RSA As New Security.Cryptography.RSACryptoServiceProvider
        Props.KeyEncryption = RSA.ToXmlString(True)
        Dim rnd As New Random
        Props.IdProgram = rnd.Next(1000, Int32.MaxValue)
        Props.IdRegistryProgram = rnd.Next(1000, Int32.MaxValue)
        Buttn.Text = trans("Активировать")
    End Sub
End Class

Class runTr
    Inherits Tr
    Implements MyEvents
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Shadows Event ClickButton(ByVal sender As Object, ByVal e As EventArgs)
    Shadows Event ActivationSuccessul(ByVal sender As Object, ByVal e As EventArgs)
    Shadows Event ActivationFailed(ByVal sender As Object, ByVal e As EventArgs)
    Public Shadows Props As New PropertysRun(Me)
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
        AddHandler Buttn.Click, AddressOf Buttn_Click
        AddHandler TextB.KeyUp, AddressOf TextB_KeyUpRun
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
    Private Sub Buttn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent ClickButton(sender, e)
        Dim ret As String = Me.Props.KeyValidation(TextB.Text, trans("Да"))
        If DaOrNet(ret) Then RaiseEvent ActivationSuccessul(sender, e) Else RaiseEvent ActivationFailed(sender, e)
    End Sub
    Private Sub TextB_KeyUpRun(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then e.Handled = False : Buttn_Click(Nothing, Nothing)
    End Sub
End Class

Public Class Trial
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), trans("Растяжка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Работает"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Видимый"), trans("Стиль рамки"), trans("Тип"), trans("Подсказка"), _
 _
        trans("Текст кнопки"), trans("Текст поля"), trans("Сообщение успешной активации"), trans("Сообщение неудачной активации"), _
        trans("ID пользователя"), trans("ID программы"), _
        trans("ID в реестре"), trans("Ключ шифрования"), _
        trans("Ключ активации выдать"), trans("Ключ активации проверить"), _
        trans("Дней триала всего"), trans("Дней триала осталось"), trans("Активирована"), trans("Примечание"), _
        trans("Триальный период запущен") _
        }
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад"), trans("Триальный период запустить"), trans("Активацию отменить")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Нажатие клавиатуры"), trans("Нажатие вниз кнопки"), trans("Отжатие кнопки"), _
                                trans("Создание"), trans("Изменение текста"), trans("Прорисовка"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры"), trans("Изменилась видимость"), _
                                trans("Клик кнопки"), trans("Активация успешная"), trans("Активация неудачная") _
                                }
    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "trial"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runTr, holostoi, isRun, fromEng)
        Else
            CreateObject(New Tr, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region

' КлиентСервер CLIENTSERVER
#Region "ClientServer"
Public Class CS
    Inherits ClientServerMy
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("КлиентСервер")
    Public LastProp As String = trans("Принятый текст")
    Public LastSobyt As String = trans("Пришел текст")
    Public Props As New Propertys(Me)
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 290 : Props.Height = 290
        Props.BackColor = trans("Никакой")
    End Sub
End Class

Class runCS
    Inherits CS
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class ClientServer
    Inherits Objetus
    Public dx As Integer

    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Стиль фона"), trans("Растяжка"), _
        trans("Работает"), trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Видимый"), trans("В фокусе"), _
        trans("Тип"), trans("Подсказка"), trans("Стиль рамки"), _
        trans("Файл отправляется"), trans("Обозначение команд"), trans("Принятая команда"), trans("Принятый текст"), _
        trans("Принятый файл"), trans("Имя в сети"), trans("IP для соединения"), trans("Порт для соединения"), _
        trans("Папка для загрузок"), trans("Имена клиентов"), trans("Текст поля ввода"), trans("Текст поля лога"), _
        trans("Ip клиентов"), trans("Ip клиента"), trans("Тип клиент сервера"), _
        trans("Скрыть отправку файлов"), trans("Скрыть отправку текста"), trans("Скрыть список"), _
        trans("Отправленная команда"), trans("Отправленый текст"), trans("Отправленый файл") _
        }

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад"), _
        trans("Отправить серверу"), trans("Отправить файл серверу"), trans("Отправить клиентам"), _
        trans("Отправить клиентам кроме"), trans("Отправить клиенту"), trans("Отправить файл клиентам"), _
        trans("Отправить файл клиентам кроме"), trans("Отправить файл клиенту"), trans("Добавить в лог"), _
        trans("Соединиться с сервером"), trans("Создать сервер"), trans("Начать прослушку"), _
        trans("Отключить сервер"), trans("Отключить прослушку"), trans("Отключиться"), trans("Выполнить команду") _
      }

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Прорисовка"), trans("Создание"), _
        trans("Присоединились к серверу"), trans("Присоединился клиент"), trans("Изменилось число клиентов"), _
        trans("Пришел текст"), trans("Пришла команда"), trans("Пришел файл"), _
        trans("Отключение"), trans("Произошла ошибка"), trans("Отправился текст"), _
        trans("Отправился файл"), trans("Идет отправление"), trans("Идет прием данных"), _
        trans("Изменился статус") _
    }

    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "clientserver"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runCS, holostoi, isRun, fromEng)
        Else
            CreateObject(New CS, holostoi, isRun, fromEng)
        End If
    End Sub
End Class

Public Interface IWinSockEvents
    ''' <summary>
    ''' Occurs when connection is achieved (client and server).
    ''' </summary>
    Event ConnectedToServer(ByVal sender As Object, ByVal e As WinsockConnectedEventArgs)
    Event ConnectionClient(ByVal sender As System.Object, ByVal e As WinsockConnectionRequestEventArgs)
    ''' <summary>
    ''' Occurs when the number of items in the collection has changed.
    ''' </summary>
    Event CountChanged(ByVal sender As Object, ByVal e As WinsockCollectionCountChangedEventArgs)
    ''' <summary>
    ''' Occurs when data arrives on the socket.
    ''' </summary>
    ''' <remarks>Raised only after all parts of the data have been collected.</remarks>
    Event TextReceived(ByVal sender As Object, ByVal e As System.EventArgs)
    Event CommandReceived(ByVal sender As Object, ByVal e As System.EventArgs)
    Event FileReceived(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Occurs when disconnected from the remote computer (client and server).
    ''' </summary>
    Event Disconnected(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Occurs when an error is detected in the socket.
    ''' </summary>
    ''' <remarks>May also be raised on disconnected (depending on disconnect circumstance).</remarks>
    Event ErrorReceived(ByVal sender As Object, ByVal e As WinsockErrorReceivedEventArgs)
    ''' <summary>
    ''' Occurs when sending of data is completed.
    ''' </summary>
    Event SendTextComplete(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
    Event SendFileComplete(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
    ''' <summary>
    ''' Occurs when the send buffer has been sent but not all the data has been sent yet.
    ''' </summary>
    Event SendProgress(ByVal sender As Object, ByVal e As WinsockSendEventArgs)
    Event ReceiveProgress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs)
    ''' <summary>
    ''' Occurs when the state of the socket changes.
    ''' </summary>
    Event StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangedEventArgs)
End Interface

#End Region

' Интернет INTERNET
#Region "Internet"
Public Class I
    Inherits InternetControl
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Интернет")
    Public LastProp As String = trans("Выполнить запрос")
    Public LastSobyt As String = trans("Пришел ответ")
    Public Props As New Propertys(Me)
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Props.Name = proj.GiveName(defaultName) : Props.Text = Props.Name
        Props.Width = 490 : Props.Height = 200
        Props.BackColor = trans("Никакой")
    End Sub
End Class

Class runI
    Inherits I
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Shadows Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class Internet
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Стиль фона"), trans("Растяжка"), _
        trans("Работает"), trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), trans("Видимый"), trans("В фокусе"), _
        trans("Тип"), trans("Подсказка"), trans("Стиль рамки"), _
        trans("Удерживать соединение"), trans("Автоматически перенаправляться"), _
        trans("Ссылка запроса"), trans("Ссылка откуда пришли"), trans("Ссылка перенаправления"), _
        trans("Тип браузера"), trans("Принимать"), trans("Прокси IP"), trans("Прокси порт"), _
        trans("Кодировка страницы"), trans("Язык страницы"), trans("Содержимое запроса"), _
        trans("Тип содержимого"), trans("Длинна содержимого"), trans("Метод запроса"), _
        trans("Код результата"), trans("Таймаут"), trans("Время задержки"), _
        trans("Заголовки запроса"), trans("Куки запросов"), trans("Результат запроса"), _
        trans("Папка для загрузок"), trans("Размер буфера"), trans("Скачивается файл"), trans("Скачка пауза"), _
        trans("Наличие соединения") _
        }
    'Удерживать соединение~~KeepAlive
    'Автоматически перенаправляться~~AllowAutoRedirect
    'Ссылка запроса~~UrlToGo
    'Ссылка откуда пришли~~UrlReferer
    'Ссылка перенаправления~~UrlRedirect
    'Тип браузера~~UserAgent
    'Принимать~~Accept
    'Прокси IP~~ProxyIp
    'Прокси порт~~ProxyPort
    'Кодировка страницы~~EncodingPage
    'Язык страницы~~LanguagePage
    'Содержимое запроса~~ContentQuery
    'Тип содержимого~~ContentType
    'Длинна содержимого~~ContentLength   RO
    'Метод запроса~~HttpMethod   
    'Код результата~~ResultCode  RO
    'Таймаут~~TimeOut
    'Время задержки~~TimeDelay
    'Заголовки запроса~~Headers   RO
    'Куки запросов~~CookiesQueries
    'Результат запроса~~ResultQuery
    'Тип файла~~File type
    'Размер буфера~~BufferSize
    'Скачивается файл~~FileDownloading
    'Скачка пауза~~DownloadPause


    'Получить код страницы~~GetSourceCodePage
    'Скачать файл~~DownloadFile
    'Выполнить запрос~~ExecuteQuery
    'Очистить куки~~ClearCookie
    'Скачка отменить~~DownloadCancel
    'Скачка возобновить~~DownloadResume

    'Отправляется запрос~~SendingQuery
    'Отправился запрос~~SentQuery
    'Пришел ответ~~ReceivedResponse
    '"What is your pet&#039;s name?","What is the name of your favorite restaurant?","What is your favorite place to travel?","What is the title of your favorite book?","What is the title of your favorite movie?","What is your favorite computer game?","What is your favorite music album?","What is the name of your favorite sports team?","Who is your favorite artist?" 

    'action="/register/index.php
    'service=30&lg_id=&qtype=&
    'icq_ln=C8A0C6D073277840B57B0F2FC36AD5A90F939AEA316DB213C1965F17157BF2E2&
    'nickname=AlgoritmTest1&fname=&lname=&
    'email=algoritm2@mail.ru&gender=0&
    'age=20&
    'password=7895123&=password_confirm=7895123&
    'qa1=custom&userq1=What is the name of your favorite restaurant?&
    'answer1=aaaaa&
    'gnm=A1ED0&
    'word=123&

    'https://www.icq.com/register/index.php
    'service=30&lg_id=&qtype=&fname=&lname=&gender=0&qa1=custom&icq_ln=&
    'nickname=AlgoritmTest1&email=algoritm2@mail.ru&age=20&password=7895123&=password_confirm=7895123&
    'userq1=What is the name of your favorite restaurant?&answer1=aaaaa&gnm=A1ED0&word=123&

    'qa1=custom&age=20&key=&lang=en&service=30&lg_id=&qtype=user&fname=&lname=&gender=0&nickname=AlgoritmTest1&email=algoritm2@mail.ru&password=qwer68m&password_confirm=qwer68m&userq=SDAFSeettrr&userq=SDAFSeettrr&answer1=aaaaa&gnm=&word=&icq_ln=
    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад"), _
        trans("Получить код страницы"), trans("Скачать файл"), _
        trans("Выполнить запрос"), trans("Очистить куки"), _
        trans("Скачка отменить"), trans("Скачка возобновить") _
      }

    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Прорисовка"), trans("Создание"), _
        trans("Отправляется запрос"), trans("Отправился запрос"), trans("Пришел ответ"), _
        trans("Идет прием данных"), trans("Загрузка отменена") _
    }

    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "internet"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runI, holostoi, isRun, fromEng)
        Else
            CreateObject(New I, holostoi, isRun, fromEng)
        End If
    End Sub
End Class

Public Interface IInternetEvents
    Event SendingQuery(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    Event SentQuery(ByVal sender As Object, ByVal e As EventArgs)
    Event ReceivedResponse(ByVal sender As Object, ByVal e As EventArgs)
    Event ReceiveProgress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs)
    Event DownloadCancelled(ByVal sender As Object, ByVal e As EventArgs)
End Interface

#End Region

' Полоса загрузки PROGRESSBAR
#Region "ProgressBar"
Public Class PrB
    Inherits Windows.Forms.ProgressBar
    Public TypeObj As String = "Obi4niy"
    Public defaultName As String = trans("Полоса загрузки")
    Public Props As New Propertys(Me)
    Public LastProp As String = trans("Значение")
    Public LastSobyt As String = trans("Клик")
    Public MyObj As Object
    Sub New()
        If proj Is Nothing Then Props.Name = defaultName & "1" Else Props.Name = proj.GiveName(defaultName)
        Me.AutoSize = False
        Props.Name = proj.GiveName(defaultName)
        Props.Width = 250 : Props.Height = 20
        Props.Value = "0"
        Props.BackColor = ToMyColor(Me.BackColor)
    End Sub
End Class

Class runPrB
    Inherits PrB
    Implements MyEvents
    Public Shadows Props As New PropertysRun(Me)
    Shadows Event Created(ByVal sender As Object, ByVal e As EventArgs) Implements MyEvents.Created
    Public Sub Load()
        Props.AddContextMenu() ' Присвоение контекстного меню
    End Sub
    Public Sub RaiseCreate()
        RaiseEvent Created(Me, New EventArgs()) ' Вызов МоегоСобытия
    End Sub
End Class

Public Class ProgressBar
    Inherits Objetus
    ' Все свойства данного объекта
    Public Propertys() As String = {trans("Имя"), trans("Номер"), trans("Привязка"), _
        trans("Цвет"), trans("Фоновой рисунок"), trans("Всплывающее меню"), _
        trans("Стиль фона"), trans("Курсор"), trans("Растяжка"), trans("Работает"), _
        trans("X"), trans("Y"), trans("Максимальная ширина"), trans("Максимальная вышина"), _
        trans("Минимальная ширина"), trans("Минимальная вышина"), trans("Ширина"), trans("Вышина"), _
        trans("ТабНомер"), trans("ТабСтоп"), trans("Вспомогательное поле"), _
        trans("Видимый"), trans("В фокусе"), trans("Тип"), _
        trans("Подсказка"), trans("Максимум"), trans("Минимум"), trans("Значение"), _
        trans("Стиль загрузки"), trans("Скорость анимации"), trans("Шаг загрузки"), trans("Справа налево") _
    }

    'Стиль~~Style
    'Скорость анимации~~MarqueeAnimationSpeed
    'Шаг загрузки~~StepProgress
    'Справа налево~~RightToLeftLayout

    ' Все методы данного объекта
    Public Methods() As String = {trans("Обновить"), trans("Получить фокус"), trans("Перенести наперед"), _
        trans("Перенести назад")}
    ' Все события данного объекта
    Public Sobyts() As String = {trans("Клик"), trans("Нажатие кнопки мыши"), trans("Отжатие кнопки мыши"), _
                                trans("Движение курсора"), trans("Наведение курсора"), trans("Отведение курсора"), _
                                trans("Курсор на объекте"), trans("Двойной клик"), trans("Вращение колесика"), _
                                trans("Создание"), trans("Прорисовка"), trans("Изменилась видимость"), _
                                trans("Получение фокуса"), trans("Потеря фокуса"), trans("Изменились размеры") _
                                }

    Public PropertysUp(), SobytsUp(), MethodsUp() As String
    Public Picture As String = "progressbar"
    Sub New(Optional ByVal holostoi As Boolean = False, Optional ByVal isRun As Boolean = False, Optional ByVal fromEng As Boolean = False)
        ' Настроить свойства
        CreatePropertySobytsUp(Me)
        Sobytia = SobytsUp
        ' Создать контрол
        If isRun Then
            CreateObject(New runPrB, holostoi, isRun, fromEng)
        Else
            CreateObject(New PrB, holostoi, isRun, fromEng)
        End If
    End Sub
End Class
#End Region