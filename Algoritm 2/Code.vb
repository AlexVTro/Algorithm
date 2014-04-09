Module CodeAlg

    Public WithEvents Окно10Окно10 As New runF
    Public WithEvents Окно10Кнопка10 As New runB
    Public WithEvents Окно10Текст10 As New runT
    Public WithEvents Окно10Iнтернет10 As New runI
    Public WithEvents Окно10Память10 As New runM
    Public WithEvents Окно10Надпись10 As New runLb
    Public WithEvents Окно10Память20 As New runM
    Public WithEvents Окно10Секундомер10 As New runTm
    Public WithEvents Окно10Текст20 As New runT
    Public WithEvents Окно10Надпись20 As New runLb
    Public WithEvents Окно10Кнопка20 As New runB
    Public WithEvents Окно10Аудио10 As New runA
    Public WithEvents _Полезные_объекты0_Полезные_объекты0 As New runF
    Public WithEvents _Полезные_объекты0_Экран0 As New PoleznieObj("_Экран")
    Public WithEvents _Полезные_объекты0_Файлы_и_папки0 As New PoleznieObj("_Файлы и папки")
    Public WithEvents _Полезные_объекты0_Прерывания0 As New PoleznieObj("_Прерывания")
    Public WithEvents _Полезные_объекты0_Система0 As New PoleznieObj("_Система")
    Public WithEvents _Полезные_объекты0_Реестр0 As New PoleznieObj("_Реестр")
    Public WithEvents _Полезные_объекты0_Вызвать_событие0 As New PoleznieObj("_Вызвать событие")
    Public WithEvents _Полезные_объекты0_Текст0 As New PoleznieObj("_Текст")
    Public WithEvents _Полезные_объекты0_Показать_сообщение0 As New PoleznieObj("_Показать сообщение")
    Public WithEvents _Полезные_объекты0_Дата0 As New PoleznieObj("_Дата")
    Public WithEvents _Полезные_объекты0_Расширенные_возможности0 As New PoleznieObj("_Расширенные возможности")


    Sub Initial()
        RunProj.isINITIALIZATED = True

        ' Задание переменных
        RunProj.iPathShort = "Рисунки"
        RunProj.iPath = RunProj.pPath & RunProj.iPathShort

        ' Отображение полосы загрузки
        ProgressForm.Label1.Text = "Load..."
        ProgressForm.Show()
        Application.DoEvents()
        ProgressForm.ProgressBarValue = 1

        ' Создание всех объектов
        ProgressForm.ProgressBar1.Value = 0
        Окно10Окно10.MyObj = New Forms(True, , True)
        Окно10Окно10.MyObj.proj = proj
        Окно10Окно10.MyObj.obj = Окно10Окно10
        Окно10Окно10.MyObj.VBname = "Окно10Окно10"
        Окно10Окно10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = Окно10Окно10.MyObj
        ReDimsO(Окно10Окно10.MyObj.MyForm.MyObjs) : Окно10Окно10.MyObj.MyForm.MyObjs(Окно10Окно10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Окно10.MyObj

        Окно10Кнопка10.MyObj = New Button(True, True)
        Окно10Кнопка10.MyObj.proj = proj
        Окно10Кнопка10.MyObj.obj = Окно10Кнопка10
        Окно10Кнопка10.MyObj.VBname = "Окно10Кнопка10"
        Окно10Кнопка10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Кнопка10.MyObj.MyForm.MyObjs) : Окно10Кнопка10.MyObj.MyForm.MyObjs(Окно10Кнопка10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Кнопка10.MyObj

        Окно10Текст10.MyObj = New TextBoks(True, True)
        Окно10Текст10.MyObj.proj = proj
        Окно10Текст10.MyObj.obj = Окно10Текст10
        Окно10Текст10.MyObj.VBname = "Окно10Текст10"
        Окно10Текст10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Текст10.MyObj.MyForm.MyObjs) : Окно10Текст10.MyObj.MyForm.MyObjs(Окно10Текст10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст10.MyObj

        Окно10Iнтернет10.MyObj = New Internet(True, True)
        Окно10Iнтернет10.MyObj.proj = proj
        Окно10Iнтернет10.MyObj.obj = Окно10Iнтернет10
        Окно10Iнтернет10.MyObj.VBname = "Окно10Iнтернет10"
        Окно10Iнтернет10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Iнтернет10.MyObj.MyForm.MyObjs) : Окно10Iнтернет10.MyObj.MyForm.MyObjs(Окно10Iнтернет10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Iнтернет10.MyObj

        Окно10Память10.MyObj = New Memory(True, True)
        Окно10Память10.MyObj.proj = proj
        Окно10Память10.MyObj.obj = Окно10Память10
        Окно10Память10.MyObj.VBname = "Окно10Память10"
        Окно10Память10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Память10.MyObj.MyForm.MyObjs) : Окно10Память10.MyObj.MyForm.MyObjs(Окно10Память10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Память10.MyObj

        ProgressForm.ProgressBar1.Value = 5
        Окно10Надпись10.MyObj = New Label(True, True)
        Окно10Надпись10.MyObj.proj = proj
        Окно10Надпись10.MyObj.obj = Окно10Надпись10
        Окно10Надпись10.MyObj.VBname = "Окно10Надпись10"
        Окно10Надпись10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Надпись10.MyObj.MyForm.MyObjs) : Окно10Надпись10.MyObj.MyForm.MyObjs(Окно10Надпись10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись10.MyObj

        Окно10Память20.MyObj = New Memory(True, True)
        Окно10Память20.MyObj.proj = proj
        Окно10Память20.MyObj.obj = Окно10Память20
        Окно10Память20.MyObj.VBname = "Окно10Память20"
        Окно10Память20.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Память20.MyObj.MyForm.MyObjs) : Окно10Память20.MyObj.MyForm.MyObjs(Окно10Память20.MyObj.MyForm.MyObjs.Length - 1) = Окно10Память20.MyObj

        Окно10Секундомер10.MyObj = New Timer(True, True)
        Окно10Секундомер10.MyObj.proj = proj
        Окно10Секундомер10.MyObj.obj = Окно10Секундомер10
        Окно10Секундомер10.MyObj.VBname = "Окно10Секундомер10"
        Окно10Секундомер10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Секундомер10.MyObj.MyForm.MyObjs) : Окно10Секундомер10.MyObj.MyForm.MyObjs(Окно10Секундомер10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Секундомер10.MyObj

        Окно10Текст20.MyObj = New TextBoks(True, True)
        Окно10Текст20.MyObj.proj = proj
        Окно10Текст20.MyObj.obj = Окно10Текст20
        Окно10Текст20.MyObj.VBname = "Окно10Текст20"
        Окно10Текст20.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Текст20.MyObj.MyForm.MyObjs) : Окно10Текст20.MyObj.MyForm.MyObjs(Окно10Текст20.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст20.MyObj

        Окно10Надпись20.MyObj = New Label(True, True)
        Окно10Надпись20.MyObj.proj = proj
        Окно10Надпись20.MyObj.obj = Окно10Надпись20
        Окно10Надпись20.MyObj.VBname = "Окно10Надпись20"
        Окно10Надпись20.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Надпись20.MyObj.MyForm.MyObjs) : Окно10Надпись20.MyObj.MyForm.MyObjs(Окно10Надпись20.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись20.MyObj

        ProgressForm.ProgressBar1.Value = 11
        Окно10Кнопка20.MyObj = New Button(True, True)
        Окно10Кнопка20.MyObj.proj = proj
        Окно10Кнопка20.MyObj.obj = Окно10Кнопка20
        Окно10Кнопка20.MyObj.VBname = "Окно10Кнопка20"
        Окно10Кнопка20.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Кнопка20.MyObj.MyForm.MyObjs) : Окно10Кнопка20.MyObj.MyForm.MyObjs(Окно10Кнопка20.MyObj.MyForm.MyObjs.Length - 1) = Окно10Кнопка20.MyObj

        Окно10Аудио10.MyObj = New Audio(True, True)
        Окно10Аудио10.MyObj.proj = proj
        Окно10Аудио10.MyObj.obj = Окно10Аудио10
        Окно10Аудио10.MyObj.VBname = "Окно10Аудио10"
        Окно10Аудио10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
        ReDimsO(Окно10Аудио10.MyObj.MyForm.MyObjs) : Окно10Аудио10.MyObj.MyForm.MyObjs(Окно10Аудио10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Аудио10.MyObj

        _Полезные_объекты0_Полезные_объекты0.MyObj = New Forms(True, , True)
        _Полезные_объекты0_Полезные_объекты0.MyObj.proj = proj
        _Полезные_объекты0_Полезные_объекты0.MyObj.obj = _Полезные_объекты0_Полезные_объекты0
        _Полезные_объекты0_Полезные_объекты0.MyObj.VBname = "_Полезные_объекты0_Полезные_объекты0"
        _Полезные_объекты0_Полезные_объекты0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Полезные_объекты0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Полезные_объекты0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Полезные_объекты0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Полезные_объекты0.MyObj

        _Полезные_объекты0_Экран0.MyObj = New Poleznie("_Экран")
        _Полезные_объекты0_Экран0.MyObj.proj = proj
        _Полезные_объекты0_Экран0.MyObj.obj = _Полезные_объекты0_Экран0
        _Полезные_объекты0_Экран0.MyObj.VBname = "_Полезные_объекты0_Экран0"
        _Полезные_объекты0_Экран0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Экран0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Экран0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Экран0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Экран0.MyObj

        _Полезные_объекты0_Файлы_и_папки0.MyObj = New Poleznie("_Файлы и папки")
        _Полезные_объекты0_Файлы_и_папки0.MyObj.proj = proj
        _Полезные_объекты0_Файлы_и_папки0.MyObj.obj = _Полезные_объекты0_Файлы_и_папки0
        _Полезные_объекты0_Файлы_и_папки0.MyObj.VBname = "_Полезные_объекты0_Файлы_и_папки0"
        _Полезные_объекты0_Файлы_и_папки0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Файлы_и_папки0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Файлы_и_папки0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Файлы_и_папки0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Файлы_и_папки0.MyObj

        ProgressForm.ProgressBar1.Value = 16
        _Полезные_объекты0_Прерывания0.MyObj = New Poleznie("_Прерывания")
        _Полезные_объекты0_Прерывания0.MyObj.proj = proj
        _Полезные_объекты0_Прерывания0.MyObj.obj = _Полезные_объекты0_Прерывания0
        _Полезные_объекты0_Прерывания0.MyObj.VBname = "_Полезные_объекты0_Прерывания0"
        _Полезные_объекты0_Прерывания0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Прерывания0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Прерывания0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Прерывания0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Прерывания0.MyObj

        _Полезные_объекты0_Система0.MyObj = New Poleznie("_Система")
        _Полезные_объекты0_Система0.MyObj.proj = proj
        _Полезные_объекты0_Система0.MyObj.obj = _Полезные_объекты0_Система0
        _Полезные_объекты0_Система0.MyObj.VBname = "_Полезные_объекты0_Система0"
        _Полезные_объекты0_Система0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Система0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Система0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Система0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Система0.MyObj

        _Полезные_объекты0_Реестр0.MyObj = New Poleznie("_Реестр")
        _Полезные_объекты0_Реестр0.MyObj.proj = proj
        _Полезные_объекты0_Реестр0.MyObj.obj = _Полезные_объекты0_Реестр0
        _Полезные_объекты0_Реестр0.MyObj.VBname = "_Полезные_объекты0_Реестр0"
        _Полезные_объекты0_Реестр0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Реестр0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Реестр0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Реестр0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Реестр0.MyObj

        _Полезные_объекты0_Вызвать_событие0.MyObj = New Poleznie("_Вызвать событие")
        _Полезные_объекты0_Вызвать_событие0.MyObj.proj = proj
        _Полезные_объекты0_Вызвать_событие0.MyObj.obj = _Полезные_объекты0_Вызвать_событие0
        _Полезные_объекты0_Вызвать_событие0.MyObj.VBname = "_Полезные_объекты0_Вызвать_событие0"
        _Полезные_объекты0_Вызвать_событие0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Вызвать_событие0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Вызвать_событие0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Вызвать_событие0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Вызвать_событие0.MyObj

        _Полезные_объекты0_Текст0.MyObj = New Poleznie("_Текст")
        _Полезные_объекты0_Текст0.MyObj.proj = proj
        _Полезные_объекты0_Текст0.MyObj.obj = _Полезные_объекты0_Текст0
        _Полезные_объекты0_Текст0.MyObj.VBname = "_Полезные_объекты0_Текст0"
        _Полезные_объекты0_Текст0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Текст0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Текст0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Текст0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Текст0.MyObj

        ProgressForm.ProgressBar1.Value = 22
        _Полезные_объекты0_Показать_сообщение0.MyObj = New Poleznie("_Показать сообщение")
        _Полезные_объекты0_Показать_сообщение0.MyObj.proj = proj
        _Полезные_объекты0_Показать_сообщение0.MyObj.obj = _Полезные_объекты0_Показать_сообщение0
        _Полезные_объекты0_Показать_сообщение0.MyObj.VBname = "_Полезные_объекты0_Показать_сообщение0"
        _Полезные_объекты0_Показать_сообщение0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Показать_сообщение0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Показать_сообщение0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Показать_сообщение0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Показать_сообщение0.MyObj

        _Полезные_объекты0_Дата0.MyObj = New Poleznie("_Дата")
        _Полезные_объекты0_Дата0.MyObj.proj = proj
        _Полезные_объекты0_Дата0.MyObj.obj = _Полезные_объекты0_Дата0
        _Полезные_объекты0_Дата0.MyObj.VBname = "_Полезные_объекты0_Дата0"
        _Полезные_объекты0_Дата0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Дата0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Дата0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Дата0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Дата0.MyObj

        _Полезные_объекты0_Расширенные_возможности0.MyObj = New Poleznie("_Расширенные возможности")
        _Полезные_объекты0_Расширенные_возможности0.MyObj.proj = proj
        _Полезные_объекты0_Расширенные_возможности0.MyObj.obj = _Полезные_объекты0_Расширенные_возможности0
        _Полезные_объекты0_Расширенные_возможности0.MyObj.VBname = "_Полезные_объекты0_Расширенные_возможности0"
        _Полезные_объекты0_Расширенные_возможности0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
        ReDimsO(_Полезные_объекты0_Расширенные_возможности0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Расширенные_возможности0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Расширенные_возможности0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Расширенные_возможности0.MyObj



        ' Размещение объектов на окнах
        ProgressForm.ProgressBar1.Value = 25
        Окно10Окно10.Controls.Add(Окно10Кнопка10)
        Окно10Окно10.Controls.Add(Окно10Текст10)
        Окно10Окно10.Controls.Add(Окно10Iнтернет10)
        ProgressForm.ProgressBar1.Value = 27
        Окно10Окно10.Controls.Add(Окно10Надпись10)
        Окно10Окно10.Controls.Add(Окно10Текст20)
        Окно10Окно10.Controls.Add(Окно10Надпись20)
        ProgressForm.ProgressBar1.Value = 29
        Окно10Окно10.Controls.Add(Окно10Кнопка20)
        ProgressForm.ProgressBar1.Value = 32
        ProgressForm.ProgressBar1.Value = 34


        ' Уровнять по уровням объекты
        ProgressForm.ProgressBar1.Value = 35
        Окно10Кнопка10.BringToFront()
        Окно10Текст10.BringToFront()
        Окно10Iнтернет10.BringToFront()
        Окно10Память10.BringToFront()
        Окно10Надпись10.BringToFront()
        Окно10Память20.BringToFront()
        Окно10Секундомер10.BringToFront()
        Окно10Текст20.BringToFront()
        Окно10Надпись20.BringToFront()
        Окно10Кнопка20.BringToFront()
        Окно10Аудио10.BringToFront()
        ProgressForm.ProgressBar1.Value = 37
        ProgressForm.ProgressBar1.Value = 39
        ProgressForm.ProgressBar1.Value = 42
        ProgressForm.ProgressBar1.Value = 44


        ' Настройка свойств объектов
        ProgressForm.ProgressBar1.Value = 45
        Окно10Окно10.Props.X = perevesti("0", True)
        Окно10Окно10.Props.Y = perevesti("0", True)
        Окно10Окно10.Props.Associatewithextensions = perevesti("", True)
        Окно10Окно10.Props.Contextmenu(True) = perevesti("Никакой", True)
        Окно10Окно10.Props.Tag = perevesti("", True)
        Окно10Окно10.Props.Mainform = perevesti("Да", True)
        Окно10Окно10.Props.Mainmenustrip(True) = perevesti("Никакой", True)
        Окно10Окно10.Props.AutoRun = perevesti("Нет", True)
        Окно10Окно10.Props.Forbidclose = perevesti("Нет", True)
        Окно10Окно10.Props.Forbidminimize = perevesti("Нет", True)
        Окно10Окно10.Props.Forbidmaximize = perevesti("Нет", True)
        Окно10Окно10.Props.Icon = perevesti("Никакой", True)
        Окно10Окно10.Props.Name = perevesti("Окно1", True)
        Окно10Окно10.Props.Cursor = perevesti("Обычный", True)
        Окно10Окно10.Props.Maximumheight = perevesti("0", True)
        Окно10Окно10.Props.Maximumwidth = perevesti("0", True)
        Окно10Окно10.Props.Minimumheight = perevesti("0", True)
        Окно10Окно10.Props.Minimumwidth = perevesti("0", True)
        Окно10Окно10.Props.Index = perevesti("0", True)
        Окно10Окно10.Props.Controlbox = perevesti("Да", True)
        Окно10Окно10.Props.Showintaskbar = perevesti("Да", True)
        Окно10Окно10.Props.Showintray = perevesti("Нет", True)
        Окно10Окно10.Props.TopMost = perevesti("Да", True)
        Окно10Окно10.Props.ToolTip = perevesti("", True)
        Окно10Окно10.Props.Showicon = perevesti("Да", True)
        Окно10Окно10.Props.Opacity = perevesti("100", True)
        Окно10Окно10.Props.Transparentcykey = perevesti("Никакой", True)
        Окно10Окно10.Props.Scroll = perevesti("Нет", True)
        Окно10Окно10.Props.AutoscrollminSizeheight = perevesti("0", True)
        Окно10Окно10.Props.AutoscrollminSizewidth = perevesti("0", True)
        Окно10Окно10.Props.AutoscrollpositionX = perevesti("0", True)
        Окно10Окно10.Props.AutoscrollpositionY = perevesti("0", True)
        Окно10Окно10.Props.Enabled = perevesti("Да", True)
        Окно10Окно10.Props.Allowruncopies = perevesti("Да", True)
        Окно10Окно10.Props.Startposition = perevesti("Заданная координатами", True)
        Окно10Окно10.StatusTemp = "Нормальный"
        Окно10Окно10.Props.Formborderstyle = perevesti("Нормальный", True)
        Окно10Окно10.Props.Backgroundimagelayout = perevesti("Плитка", True)
        Окно10Окно10.Props.Tabindex = perevesti("0", True)
        Окно10Окно10.Props.Tabstop = perevesti("Да", True)
        Окно10Окно10.Props.Text = perevesti("EU Realms Status", True)
        Окно10Окно10.Props.Backgroundimage = perevesti("Никакой", True)
        Окно10Окно10.Props.Backcolor = perevesti("244; 244; 244;", True)
        Окно10Окно10.Props.Forecolor = perevesti("Черный", True)
        Окно10Окно10.Props.Height = perevesti("123", True)
        Окно10Окно10.Props.Width = perevesti("147", True)
        Окно10Окно10.Props.Visible = perevesti("Да", True)
        Окно10Окно10.Props.Height = perevesti("123", True)
        Окно10Окно10.Props.Width = perevesti("147", True)

        ProgressForm.ProgressBar1.Value = 47
        Окно10Кнопка10.Props.X = perevesti("14", True)
        Окно10Кнопка10.Props.Y = perevesti("59", True)
        Окно10Кнопка10.Props.Autoellipsis = perevesti("Да", True)
        Окно10Кнопка10.Props.Contextmenu(True) = perevesti("Никакой", True)
        Окно10Кнопка10.Props.Tag = perevesti("", True)
        Окно10Кнопка10.Props.Name = perevesti("Кнопка1", True)
        Окно10Кнопка10.Props.Cursor = perevesti("Обычный", True)
        Окно10Кнопка10.Props.Maximumheight = perevesti("0", True)
        Окно10Кнопка10.Props.Maximumwidth = perevesti("0", True)
        Окно10Кнопка10.Props.Minimumheight = perevesti("0", True)
        Окно10Кнопка10.Props.Minimumwidth = perevesti("0", True)
        Окно10Кнопка10.Props.Index = perevesti("0", True)
        Окно10Кнопка10.Props.ToolTip = perevesti("", True)
        Окно10Кнопка10.Props.Paddingtop = perevesti("0", True)
        Окно10Кнопка10.Props.Paddingleft = perevesti("0", True)
        Окно10Кнопка10.Props.Paddingbottom = perevesti("0", True)
        Окно10Кнопка10.Props.Paddingright = perevesti("0", True)
        Окно10Кнопка10.Props.Imagealign = perevesti("Центр", True)
        Окно10Кнопка10.Props.Textalign = perevesti("центр", True)
        Окно10Кнопка10.Props.Anchor = perevesti("Слева_Сверху", True)
        Окно10Кнопка10.Props.Enabled = perevesti("Да", True)
        Окно10Кнопка10.Props.Dock = perevesti("Никакой", True)
        Окно10Кнопка10.Props.Image = perevesti("Никакой", True)
        Окно10Кнопка10.Props.Flatstyle = perevesti("Обычный", True)
        Окно10Кнопка10.Props.Backgroundimagelayout = perevesti("Плитка", True)
        Окно10Кнопка10.Props.Tabindex = perevesti("0", True)
        Окно10Кнопка10.Props.Tabstop = perevesti("Да", True)
        Окно10Кнопка10.Props.Text = perevesti("Start", True)
        Окно10Кнопка10.Props.Textimagerelation = perevesti("Поверх", True)
        Окно10Кнопка10.Props.Backgroundimage = perevesti("Никакой", True)
        Окно10Кнопка10.Props.Backcolor = perevesti("Никакой", True)
        Окно10Кнопка10.Props.Forecolor = perevesti("Черный", True)
        Окно10Кнопка10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Окно10Кнопка10.Props.Fontbold = perevesti("Нет", True)
        Окно10Кнопка10.Props.Fontstrikeout = perevesti("Нет", True)
        Окно10Кнопка10.Props.Fontitalic = perevesti("Нет", True)
        Окно10Кнопка10.Props.Fontunderline = perevesti("Нет", True)
        Окно10Кнопка10.Props.Fontsize = perevesti("8", True)
        Окно10Кнопка10.Props.Height = perevesti("23", True)
        Окно10Кнопка10.Props.Width = perevesti("55", True)
        Окно10Кнопка10.Props.Visible = perevesti("Да", True)
        Окно10Кнопка10.Props.Height = perevesti("23", True)
        Окно10Кнопка10.Props.Width = perevesti("55", True)

        ProgressForm.ProgressBar1.Value = 50
        Окно10Текст10.Props.X = perevesti("16", True)
        Окно10Текст10.Props.Y = perevesti("16", True)
        Окно10Текст10.Props.Contextmenu(True) = perevesti("Никакой", True)
        Окно10Текст10.Props.Tag = perevesti("", True)
        Окно10Текст10.Props.Selectedtext = perevesti("", True)
        Окно10Текст10.Props.Selectionlength = perevesti("0", True)
        Окно10Текст10.Props.Name = perevesti("Текст1", True)
        Окно10Текст10.Props.Maximumheight = perevesti("0", True)
        Окно10Текст10.Props.Maximumlength = perevesti("32767", True)
        Окно10Текст10.Props.Maximumwidth = perevesti("0", True)
        Окно10Текст10.Props.Minimumheight = perevesti("0", True)
        Окно10Текст10.Props.Minimumwidth = perevesti("0", True)
        Окно10Текст10.Props.Multiline = perevesti("Да", True)
        Окно10Текст10.Props.Selectionstart = perevesti("1", True)
        Окно10Текст10.Props.Index = perevesti("0", True)
        Окно10Текст10.Props.Wordwrap = perevesti("Да", True)
        Окно10Текст10.Props.ToolTip = perevesti("", True)
        Окно10Текст10.Props.Scrollbars = perevesti("Нет", True)
        Окно10Текст10.Props.Anchor = perevesti("Слева_Сверху", True)
        Окно10Текст10.Props.Enabled = perevesti("Да", True)
        Окно10Текст10.Props.Allowinput = perevesti("Все", True)
        Окно10Текст10.Props.Textposition = perevesti("Слева", True)
        Окно10Текст10.Props.Dock = perevesti("Никакой", True)
        Окно10Текст10.Props.Passwordchar = perevesti("", True)
        Окно10Текст10.Props.Hideselection = perevesti("Нет", True)
        Окно10Текст10.Props.Borderstyle = perevesti("объем", True)
        Окно10Текст10.Props.Tabindex = perevesti("0", True)
        Окно10Текст10.Props.Tabstop = perevesti("Да", True)
        Окно10Текст10.Props.Text = perevesti("Wrathbringer", True)
        Окно10Текст10.Props.Readonly = perevesti("Нет", True)
        Окно10Текст10.Props.Backcolor = perevesti("Белый", True)
        Окно10Текст10.Props.Forecolor = perevesti("Черный", True)
        Окно10Текст10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Окно10Текст10.Props.Fontbold = perevesti("Нет", True)
        Окно10Текст10.Props.Fontstrikeout = perevesti("Нет", True)
        Окно10Текст10.Props.Fontitalic = perevesti("Нет", True)
        Окно10Текст10.Props.Fontunderline = perevesti("Нет", True)
        Окно10Текст10.Props.Fontsize = perevesti("8", True)
        Окно10Текст10.Props.Height = perevesti("20", True)
        Окно10Текст10.Props.Width = perevesti("115", True)
        Окно10Текст10.Props.Visible = perevesti("Да", True)
        Окно10Текст10.Props.Height = perevesti("20", True)
        Окно10Текст10.Props.Width = perevesti("115", True)

        ProgressForm.ProgressBar1.Value = 52
        Окно10Iнтернет10.Props.X = perevesti("444", True)
        Окно10Iнтернет10.Props.Y = perevesti("224", True)
        Окно10Iнтернет10.Props.Allowautoredirect = perevesti("Нет", True)
        Окно10Iнтернет10.Props.Timedelay = perevesti("0", True)
        Окно10Iнтернет10.Props.Tag = perevesti("", True)
        Окно10Iнтернет10.Props.Name = perevesti("Iнтернет1", True)
        Окно10Iнтернет10.Props.Encodingpage = perevesti("windows-1251", True)
        Окно10Iнтернет10.Props.Cookiesqueries = perevesti("", True)
        Окно10Iнтернет10.Props.Maximumheight = perevesti("0", True)
        Окно10Iнтернет10.Props.Maximumwidth = perevesti("0", True)
        Окно10Iнтернет10.Props.Httpmethod = perevesti("GET", True)
        Окно10Iнтернет10.Props.Minimumheight = perevesti("0", True)
        Окно10Iнтернет10.Props.Minimumwidth = perevesti("0", True)
        Окно10Iнтернет10.Props.Index = perevesti("0", True)
        Окно10Iнтернет10.Props.Pathfordownloads = perevesti("", True)
        Окно10Iнтернет10.Props.ToolTip = perevesti("", True)
        Окно10Iнтернет10.Props.Anchor = perevesti("Слева_Сверху", True)
        Окно10Iнтернет10.Props.Accept = perevesti("image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*", True)
        Окно10Iнтернет10.Props.ProxyIP = perevesti("", True)
        Окно10Iнтернет10.Props.Proxyport = perevesti("0", True)
        Окно10Iнтернет10.Props.Enabled = perevesti("Да", True)
        Окно10Iнтернет10.Props.Buffersize = perevesti("50000", True)
        Окно10Iнтернет10.Props.Dock = perevesti("Никакой", True)
        Окно10Iнтернет10.Props.Resultquery = perevesti("", True)
        Окно10Iнтернет10.Props.Filedownloading = perevesti("Нет", True)
        Окно10Iнтернет10.Props.Downloadpause = perevesti("Нет", True)
        Окно10Iнтернет10.Props.Contentquery = perevesti("", True)
        Окно10Iнтернет10.Props.Urltogo = perevesti("http://www.wow-europe.com/realmstatus/index.xml", True)
        Окно10Iнтернет10.Props.Urlreferer = perevesti("", True)
        Окно10Iнтернет10.Props.Urlredirect = perevesti("", True)
        Окно10Iнтернет10.Props.Borderstyle = perevesti("Никакой", True)
        Окно10Iнтернет10.Props.Backgroundimagelayout = perevesti("Плитка", True)
        Окно10Iнтернет10.Props.Tabindex = perevesti("0", True)
        Окно10Iнтернет10.Props.Tabstop = perevesti("Да", True)
        Окно10Iнтернет10.Props.Timeout = perevesti("10000", True)
        Окно10Iнтернет10.Props.Useragent = perevesti("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;", True)
        Окно10Iнтернет10.Props.Contenttype = perevesti("text/plain", True)
        Окно10Iнтернет10.Props.Keepalive = perevesti("Нет", True)
        Окно10Iнтернет10.Props.Backgroundimage = perevesti("Никакой", True)
        Окно10Iнтернет10.Props.Backcolor = perevesti("Никакой", True)
        Окно10Iнтернет10.Props.Languagepage = perevesti("", True)
        Окно10Iнтернет10.Props.Height = perevesti("79", True)
        Окно10Iнтернет10.Props.Width = perevesti("99", True)
        Окно10Iнтернет10.Props.Visible = perevesti("Да", True)
        Окно10Iнтернет10.Props.Height = perevesti("79", True)
        Окно10Iнтернет10.Props.Width = perevesti("99", True)

        ProgressForm.ProgressBar1.Value = 55
        Окно10Память10.Props.X = perevesti("4", True)
        Окно10Память10.Props.Y = perevesti("4", True)
        Окно10Память10.Props.Tag = perevesti("", True)
        Окно10Память10.Props.Name = perevesti("Память1", True)
        Окно10Память10.Props.Index = perevesti("0", True)
        Окно10Память10.Props.Enabled = perevesti("Да", True)
        Окно10Память10.Props.Value = perevesti("", True)

        ProgressForm.ProgressBar1.Value = 57
        Окно10Надпись10.Props.X = perevesti("91", True)
        Окно10Надпись10.Props.Y = perevesti("63", True)
        Окно10Надпись10.Props.Autoellipsis = perevesti("Нет", True)
        Окно10Надпись10.Props.Contextmenu(True) = perevesti("Никакой", True)
        Окно10Надпись10.Props.Tag = perevesti("", True)
        Окно10Надпись10.Props.Name = perevesti("Надпись1", True)
        Окно10Надпись10.Props.Cursor = perevesti("Обычный", True)
        Окно10Надпись10.Props.Maximumheight = perevesti("0", True)
        Окно10Надпись10.Props.Maximumwidth = perevesti("0", True)
        Окно10Надпись10.Props.Minimumheight = perevesti("0", True)
        Окно10Надпись10.Props.Minimumwidth = perevesti("0", True)
        Окно10Надпись10.Props.Index = perevesti("0", True)
        Окно10Надпись10.Props.ToolTip = perevesti("", True)
        Окно10Надпись10.Props.Paddingtop = perevesti("0", True)
        Окно10Надпись10.Props.Paddingleft = perevesti("0", True)
        Окно10Надпись10.Props.Paddingbottom = perevesti("0", True)
        Окно10Надпись10.Props.Paddingright = perevesti("0", True)
        Окно10Надпись10.Props.Imagealign = perevesti("Центр", True)
        Окно10Надпись10.Props.Textalign = perevesti("центр", True)
        Окно10Надпись10.Props.Anchor = perevesti("Слева_Сверху", True)
        Окно10Надпись10.Props.Enabled = perevesti("Да", True)
        Окно10Надпись10.Props.Dock = perevesti("Никакой", True)
        Окно10Надпись10.Props.Image = perevesti("Никакой", True)
        Окно10Надпись10.Props.Borderstyle = perevesti("Никакой", True)
        Окно10Надпись10.Props.Backgroundimagelayout = perevesti("Плитка", True)
        Окно10Надпись10.Props.Tabindex = perevesti("0", True)
        Окно10Надпись10.Props.Tabstop = perevesti("Да", True)
        Окно10Надпись10.Props.Text = perevesti("Status", True)
        Окно10Надпись10.Props.Backgroundimage = perevesti("Никакой", True)
        Окно10Надпись10.Props.Backcolor = perevesti("244; 244; 244;", True)
        Окно10Надпись10.Props.Forecolor = perevesti("Черный", True)
        Окно10Надпись10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Окно10Надпись10.Props.Fontbold = perevesti("Нет", True)
        Окно10Надпись10.Props.Fontstrikeout = perevesti("Нет", True)
        Окно10Надпись10.Props.Fontitalic = perevesti("Нет", True)
        Окно10Надпись10.Props.Fontunderline = perevesti("Нет", True)
        Окно10Надпись10.Props.Fontsize = perevesti("8", True)
        Окно10Надпись10.Props.Height = perevesti("15", True)
        Окно10Надпись10.Props.Width = perevesti("47", True)
        Окно10Надпись10.Props.Visible = perevesti("Да", True)
        Окно10Надпись10.Props.Height = perevesti("15", True)
        Окно10Надпись10.Props.Width = perevesti("47", True)

        ProgressForm.ProgressBar1.Value = 59
        Окно10Память20.Props.X = perevesti("36", True)
        Окно10Память20.Props.Y = perevesti("4", True)
        Окно10Память20.Props.Tag = perevesti("", True)
        Окно10Память20.Props.Name = perevesti("Память2", True)
        Окно10Память20.Props.Index = perevesti("0", True)
        Окно10Память20.Props.Enabled = perevesti("Да", True)
        Окно10Память20.Props.Value = perevesti("", True)

        ProgressForm.ProgressBar1.Value = 62
        Окно10Секундомер10.Props.X = perevesti("8", True)
        Окно10Секундомер10.Props.Y = perevesti("8", True)
        Окно10Секундомер10.Props.Tag = perevesti("", True)
        Окно10Секундомер10.Props.Name = perevesti("Секундомер1", True)
        Окно10Секундомер10.Props.Interval = perevesti("1000", True)
        Окно10Секундомер10.Props.Index = perevesti("0", True)
        Окно10Секундомер10.Props.Intervalcount = perevesti("0", True)
        Окно10Секундомер10.Props.Enabled = perevesti("Нет", True)

        ProgressForm.ProgressBar1.Value = 64
        Окно10Текст20.Props.X = perevesti("100", True)
        Окно10Текст20.Props.Y = perevesti("37", True)
        Окно10Текст20.Props.Contextmenu(True) = perevesti("Никакой", True)
        Окно10Текст20.Props.Tag = perevesti("", True)
        Окно10Текст20.Props.Selectedtext = perevesti("", True)
        Окно10Текст20.Props.Selectionlength = perevesti("0", True)
        Окно10Текст20.Props.Name = perevesti("Текст2", True)
        Окно10Текст20.Props.Maximumheight = perevesti("0", True)
        Окно10Текст20.Props.Maximumlength = perevesti("32767", True)
        Окно10Текст20.Props.Maximumwidth = perevesti("0", True)
        Окно10Текст20.Props.Minimumheight = perevesti("0", True)
        Окно10Текст20.Props.Minimumwidth = perevesti("0", True)
        Окно10Текст20.Props.Multiline = perevesti("Нет", True)
        Окно10Текст20.Props.Selectionstart = perevesti("1", True)
        Окно10Текст20.Props.Index = perevesti("0", True)
        Окно10Текст20.Props.Wordwrap = perevesti("Да", True)
        Окно10Текст20.Props.ToolTip = perevesti("", True)
        Окно10Текст20.Props.Scrollbars = perevesti("Нет", True)
        Окно10Текст20.Props.Anchor = perevesti("Слева_Сверху", True)
        Окно10Текст20.Props.Enabled = perevesti("Да", True)
        Окно10Текст20.Props.Allowinput = perevesti("Все", True)
        Окно10Текст20.Props.Textposition = perevesti("Слева", True)
        Окно10Текст20.Props.Dock = perevesti("Никакой", True)
        Окно10Текст20.Props.Passwordchar = perevesti("", True)
        Окно10Текст20.Props.Hideselection = perevesti("Нет", True)
        Окно10Текст20.Props.Borderstyle = perevesti("объем", True)
        Окно10Текст20.Props.Tabindex = perevesti("0", True)
        Окно10Текст20.Props.Tabstop = perevesti("Да", True)
        Окно10Текст20.Props.Text = perevesti("30", True)
        Окно10Текст20.Props.Readonly = perevesti("Нет", True)
        Окно10Текст20.Props.Backcolor = perevesti("Белый", True)
        Окно10Текст20.Props.Forecolor = perevesti("Черный", True)
        Окно10Текст20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Окно10Текст20.Props.Fontbold = perevesti("Нет", True)
        Окно10Текст20.Props.Fontstrikeout = perevesti("Нет", True)
        Окно10Текст20.Props.Fontitalic = perevesti("Нет", True)
        Окно10Текст20.Props.Fontunderline = perevesti("Нет", True)
        Окно10Текст20.Props.Fontsize = perevesti("8", True)
        Окно10Текст20.Props.Height = perevesti("20", True)
        Окно10Текст20.Props.Width = perevesti("31", True)
        Окно10Текст20.Props.Visible = perevesti("Да", True)
        Окно10Текст20.Props.Height = perevesti("20", True)
        Окно10Текст20.Props.Width = perevesti("31", True)

        ProgressForm.ProgressBar1.Value = 67
        Окно10Надпись20.Props.X = perevesti("6", True)
        Окно10Надпись20.Props.Y = perevesti("40", True)
        Окно10Надпись20.Props.Autoellipsis = perevesti("Да", True)
        Окно10Надпись20.Props.Contextmenu(True) = perevesti("Никакой", True)
        Окно10Надпись20.Props.Tag = perevesti("", True)
        Окно10Надпись20.Props.Name = perevesti("Надпись2", True)
        Окно10Надпись20.Props.Cursor = perevesti("Обычный", True)
        Окно10Надпись20.Props.Maximumheight = perevesti("0", True)
        Окно10Надпись20.Props.Maximumwidth = perevesti("0", True)
        Окно10Надпись20.Props.Minimumheight = perevesti("0", True)
        Окно10Надпись20.Props.Minimumwidth = perevesti("0", True)
        Окно10Надпись20.Props.Index = perevesti("0", True)
        Окно10Надпись20.Props.ToolTip = perevesti("", True)
        Окно10Надпись20.Props.Paddingtop = perevesti("0", True)
        Окно10Надпись20.Props.Paddingleft = perevesti("0", True)
        Окно10Надпись20.Props.Paddingbottom = perevesti("0", True)
        Окно10Надпись20.Props.Paddingright = perevesti("0", True)
        Окно10Надпись20.Props.Imagealign = perevesti("Центр", True)
        Окно10Надпись20.Props.Textalign = perevesti("центр", True)
        Окно10Надпись20.Props.Anchor = perevesti("Слева_Сверху", True)
        Окно10Надпись20.Props.Enabled = perevesti("Да", True)
        Окно10Надпись20.Props.Dock = perevesti("Никакой", True)
        Окно10Надпись20.Props.Image = perevesti("Никакой", True)
        Окно10Надпись20.Props.Borderstyle = perevesti("Никакой", True)
        Окно10Надпись20.Props.Backgroundimagelayout = perevesti("Плитка", True)
        Окно10Надпись20.Props.Tabindex = perevesti("0", True)
        Окно10Надпись20.Props.Tabstop = perevesti("Да", True)
        Окно10Надпись20.Props.Text = perevesti("Timer sec.:", True)
        Окно10Надпись20.Props.Backgroundimage = perevesti("Никакой", True)
        Окно10Надпись20.Props.Backcolor = perevesti("244; 244; 244;", True)
        Окно10Надпись20.Props.Forecolor = perevesti("Черный", True)
        Окно10Надпись20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Окно10Надпись20.Props.Fontbold = perevesti("Нет", True)
        Окно10Надпись20.Props.Fontstrikeout = perevesti("Нет", True)
        Окно10Надпись20.Props.Fontitalic = perevesti("Нет", True)
        Окно10Надпись20.Props.Fontunderline = perevesti("Нет", True)
        Окно10Надпись20.Props.Fontsize = perevesti("8", True)
        Окно10Надпись20.Props.Height = perevesti("15", True)
        Окно10Надпись20.Props.Width = perevesti("75", True)
        Окно10Надпись20.Props.Visible = perevesti("Да", True)
        Окно10Надпись20.Props.Height = perevesti("15", True)
        Окно10Надпись20.Props.Width = perevesti("75", True)

        ProgressForm.ProgressBar1.Value = 69
        Окно10Кнопка20.Props.X = perevesti("14", True)
        Окно10Кнопка20.Props.Y = perevesti("84", True)
        Окно10Кнопка20.Props.Autoellipsis = perevesti("Да", True)
        Окно10Кнопка20.Props.Contextmenu(True) = perevesti("Никакой", True)
        Окно10Кнопка20.Props.Tag = perevesti("", True)
        Окно10Кнопка20.Props.Name = perevesti("Кнопка2", True)
        Окно10Кнопка20.Props.Cursor = perevesti("Обычный", True)
        Окно10Кнопка20.Props.Maximumheight = perevesti("0", True)
        Окно10Кнопка20.Props.Maximumwidth = perevesti("0", True)
        Окно10Кнопка20.Props.Minimumheight = perevesti("0", True)
        Окно10Кнопка20.Props.Minimumwidth = perevesti("0", True)
        Окно10Кнопка20.Props.Index = perevesti("0", True)
        Окно10Кнопка20.Props.ToolTip = perevesti("", True)
        Окно10Кнопка20.Props.Paddingtop = perevesti("0", True)
        Окно10Кнопка20.Props.Paddingleft = perevesti("0", True)
        Окно10Кнопка20.Props.Paddingbottom = perevesti("0", True)
        Окно10Кнопка20.Props.Paddingright = perevesti("0", True)
        Окно10Кнопка20.Props.Imagealign = perevesti("Центр", True)
        Окно10Кнопка20.Props.Textalign = perevesti("центр", True)
        Окно10Кнопка20.Props.Anchor = perevesti("Слева_Сверху", True)
        Окно10Кнопка20.Props.Enabled = perevesti("Да", True)
        Окно10Кнопка20.Props.Dock = perevesti("Никакой", True)
        Окно10Кнопка20.Props.Image = perevesti("Никакой", True)
        Окно10Кнопка20.Props.Flatstyle = perevesti("Обычный", True)
        Окно10Кнопка20.Props.Backgroundimagelayout = perevesti("Плитка", True)
        Окно10Кнопка20.Props.Tabindex = perevesti("0", True)
        Окно10Кнопка20.Props.Tabstop = perevesti("Да", True)
        Окно10Кнопка20.Props.Text = perevesti("Stop", True)
        Окно10Кнопка20.Props.Textimagerelation = perevesti("Поверх", True)
        Окно10Кнопка20.Props.Backgroundimage = perevesti("Никакой", True)
        Окно10Кнопка20.Props.Backcolor = perevesti("Никакой", True)
        Окно10Кнопка20.Props.Forecolor = perevesti("Черный", True)
        Окно10Кнопка20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Окно10Кнопка20.Props.Fontbold = perevesti("Нет", True)
        Окно10Кнопка20.Props.Fontstrikeout = perevesti("Нет", True)
        Окно10Кнопка20.Props.Fontitalic = perevesti("Нет", True)
        Окно10Кнопка20.Props.Fontunderline = perevesti("Нет", True)
        Окно10Кнопка20.Props.Fontsize = perevesti("8", True)
        Окно10Кнопка20.Props.Height = perevesti("23", True)
        Окно10Кнопка20.Props.Width = perevesti("55", True)
        Окно10Кнопка20.Props.Visible = perevesti("Да", True)
        Окно10Кнопка20.Props.Height = perevesti("23", True)
        Окно10Кнопка20.Props.Width = perevesti("55", True)

        ProgressForm.ProgressBar1.Value = 71
        Окно10Аудио10.Props.X = perevesti("12", True)
        Окно10Аудио10.Props.Y = perevesti("8", True)
        Окно10Аудио10.Props.Balance = perevesti("1000", True)
        Окно10Аудио10.Props.Contextmenu(True) = perevesti("Никакой", True)
        Окно10Аудио10.Props.Tag = perevesti("", True)
        Окно10Аудио10.Props.Volume = perevesti("1000", True)
        Окно10Аудио10.Props.Mute = perevesti("Нет", True)
        Окно10Аудио10.Props.Name = perevesti("Аудио1", True)
        Окно10Аудио10.Props.Cursor = perevesti("Обычный", True)
        Окно10Аудио10.Props.Maximumheight = perevesti("0", True)
        Окно10Аудио10.Props.Maximumwidth = perevesti("0", True)
        Окно10Аудио10.Props.Minimumheight = perevesti("0", True)
        Окно10Аудио10.Props.Minimumwidth = perevesti("0", True)
        Окно10Аудио10.Props.Index = perevesti("0", True)
        Окно10Аудио10.Props.ToolTip = perevesti("", True)
        Окно10Аудио10.Props.Playposition = perevesti("0", True)
        Окно10Аудио10.Props.Anchor = perevesti("Слева_Сверху", True)
        Окно10Аудио10.Props.Playtime = perevesti("00:00:00.00", True)
        Окно10Аудио10.Props.Played = perevesti("Нет", True)
        Окно10Аудио10.Props.Enabled = perevesti("Да", True)
        Окно10Аудио10.Props.Dock = perevesti("Никакой", True)
        Окно10Аудио10.Props.Speed = perevesti("0", True)
        Окно10Аудио10.Props.Backgroundimagelayout = perevesti("Плитка", True)
        Окно10Аудио10.Props.Filenameplayed = perevesti("Никакой", True)
        Окно10Аудио10.Props.Backgroundimage = perevesti("Никакой", True)
        Окно10Аудио10.Props.Backcolor = perevesti("Никакой", True)
        Окно10Аудио10.Props.Height = perevesti("16", True)
        Окно10Аудио10.Props.Width = perevesti("16", True)
        Окно10Аудио10.Props.Visible = perevesti("Да", True)
        Окно10Аудио10.Props.Height = perevesti("16", True)
        Окно10Аудио10.Props.Width = perevesti("16", True)

        ProgressForm.ProgressBar1.Value = 74
        _Полезные_объекты0_Полезные_объекты0.Props.Name = "_Полезные объекты"

        ProgressForm.ProgressBar1.Value = 76
        _Полезные_объекты0_Экран0.Props.Name = "_Экран"

        ProgressForm.ProgressBar1.Value = 78
        _Полезные_объекты0_Файлы_и_папки0.Props.Name = "_Файлы и папки"

        ProgressForm.ProgressBar1.Value = 81
        _Полезные_объекты0_Прерывания0.Props.Name = "_Прерывания"

        ProgressForm.ProgressBar1.Value = 83
        _Полезные_объекты0_Система0.Props.Name = "_Система"

        ProgressForm.ProgressBar1.Value = 86
        _Полезные_объекты0_Реестр0.Props.Name = "_Реестр"

        ProgressForm.ProgressBar1.Value = 88
        _Полезные_объекты0_Вызвать_событие0.Props.Name = "_Вызвать событие"

        ProgressForm.ProgressBar1.Value = 90
        _Полезные_объекты0_Текст0.Props.Name = "_Текст"

        ProgressForm.ProgressBar1.Value = 93
        _Полезные_объекты0_Показать_сообщение0.Props.Name = "_Показать сообщение"

        ProgressForm.ProgressBar1.Value = 95
        _Полезные_объекты0_Дата0.Props.Name = "_Дата"

        ProgressForm.ProgressBar1.Value = 98
        _Полезные_объекты0_Расширенные_возможности0.Props.Name = "_Расширенные возможности"


        ' Окончательная загрузка
        Окно10Окно10.load()
        Окно10Кнопка10.load()
        Окно10Текст10.load()
        Окно10Iнтернет10.load()
        Окно10Память10.load()
        Окно10Надпись10.load()
        Окно10Память20.load()
        Окно10Секундомер10.load()
        Окно10Текст20.load()
        Окно10Надпись20.load()
        Окно10Кнопка20.load()
        Окно10Аудио10.load()

        RunProj.GetAllObjects()
        RunProj.isINITIALIZATED = False

        Окно10Кнопка10.RaiseCreate()
        Окно10Текст10.RaiseCreate()
        Окно10Iнтернет10.RaiseCreate()
        Окно10Память10.RaiseCreate()
        Окно10Надпись10.RaiseCreate()
        Окно10Память20.RaiseCreate()
        RemoveHandler Окно10Секундомер10.Tick, AddressOf Окно10Секундомер10_Tick
        AddHandler Окно10Секундомер10.Tick, AddressOf Окно10Секундомер10_Tick

        Окно10Секундомер10.RaiseCreate()
        Окно10Текст20.RaiseCreate()
        Окно10Надпись20.RaiseCreate()
        Окно10Кнопка20.RaiseCreate()
        Окно10Аудио10.RaiseCreate()
        Окно10Окно10.RaiseCreate()

        ProgressForm.Hide()
    End Sub

    ' Обязательные события
    Public Sub Окно10Окно10_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Окно10.Disposed
        If DaOrNet(Окно10Окно10.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
    End Sub

    Public Sub Окно10Окно10_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Окно10Окно10.FormClosing
        If DaOrNet(Окно10Окно10.Props.ForbidClose) Then e.Cancel = True : Exit Sub
        If UCase(Окно10Окно10.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
            Окно10Окно10.Hide() : Application.Exit()
        Else
            e.Cancel = True : Окно10Окно10.Hide()
        End If
    End Sub

    Public Sub Окно10Текст10_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно10Текст10.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub Окно10Секундомер10_TickNado(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Секундомер10.Tick
        Окно10Секундомер10.Props.IntervalCount += 1
    End Sub

    Public Sub Окно10Текст20_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно10Текст20.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub _Полезные_объекты0_Полезные_объекты0_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Полезные_объекты0_Полезные_объекты0.Disposed
        If DaOrNet(_Полезные_объекты0_Полезные_объекты0.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
    End Sub

    Public Sub _Полезные_объекты0_Полезные_объекты0_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles _Полезные_объекты0_Полезные_объекты0.FormClosing
        If DaOrNet(_Полезные_объекты0_Полезные_объекты0.Props.ForbidClose) Then e.Cancel = True : Exit Sub
        If UCase(_Полезные_объекты0_Полезные_объекты0.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
            _Полезные_объекты0_Полезные_объекты0.Hide() : Application.Exit()
        Else
            e.Cancel = True : _Полезные_объекты0_Полезные_объекты0.Hide()
        End If
    End Sub



    ' Все события
    Public Sub Окно10Кнопка10_Mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Окно10Кнопка10.Mousedown
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Окно10Кнопка10.MyObj, e, Nothing, "Нажатие кнопки мыши")

        RunProj.GetObjFromUniqName("Окно1.Секундомер1").Props.Interval = ToDouble(RunProj.GetObjFromUniqName("Окно1.Текст2").Props.Text) * 1000
        RunProj.GetObjFromUniqName("Окно1.Секундомер1").Props.Start()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Окно10Iнтернет10_Receivedresponse(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Iнтернет10.Receivedresponse
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Окно10Iнтернет10.MyObj, e, Nothing, "Пришел ответ")

        RunProj.GetObjFromUniqName("Окно1.Память1").Props.Value = RunProj.GetObjFromUniqName("_Полезные объекты._Текст").Props.Indexofignorecase(RunProj.GetObjFromUniqName("Окно1.Iнтернет1").Props.Resultquery, RunProj.GetObjFromUniqName("Окно1.Текст1").Props.Text, 1)
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Окно10Iнтернет10_Sendingquery(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Окно10Iнтернет10.SendingQuery
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Окно10Iнтернет10.MyObj, e, Nothing, "Отправляется запрос")

        RunProj.GetObjFromUniqName("Окно1.Надпись1").Props.Text = "Loading..."
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Окно10Память10_Changedvalue(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Память10.Changedvalue
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Окно10Память10.MyObj, e, Nothing, "Изменилось значение")

        RunProj.GetObjFromUniqName("Окно1.Память2").Props.Value = RunProj.GetObjFromUniqName("_Полезные объекты._Текст").Props.Indexofignorecase(RunProj.GetObjFromUniqName("Окно1.Iнтернет1").Props.Resultquery, "Realm ", RunProj.GetObjFromUniqName("Окно1.Память1").Props.Value)
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Окно10Память20_Changedvalue(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Память20.Changedvalue
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Окно10Память20.MyObj, e, Nothing, "Изменилось значение")

        RunProj.GetObjFromUniqName("Окно1.Надпись1").Props.Text = RunProj.GetObjFromUniqName("_Полезные объекты._Текст").Props.Substring(RunProj.GetObjFromUniqName("Окно1.Iнтернет1").Props.Resultquery, ToDouble(RunProj.GetObjFromUniqName("Окно1.Память2").Props.Value) + 6, 4)
        If returnBoolean(UCase(RunProj.GetObjFromUniqName("Окно1.Надпись1").Props.Text) = UCase("Up -")) Then
            RunProj.GetObjFromUniqName("Окно1.Аудио1").Props.Playmovie()
        End If
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Окно10Секундомер10_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Секундомер10.Tick
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Окно10Секундомер10.MyObj, e, Nothing, "Тикнул")

        RunProj.GetObjFromUniqName("Окно1.Iнтернет1").Props.Executequery()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Окно10Кнопка20_Mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Окно10Кнопка20.Mousedown
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Окно10Кнопка20.MyObj, e, Nothing, "Нажатие кнопки мыши")

        RunProj.GetObjFromUniqName("Окно1.Аудио1").Props.Stopmovie()
        RunProj.GetObjFromUniqName("Окно1.Секундомер1").Props.Stop()
        CurrentEvent.Zavershit()
    End Sub



End Module



