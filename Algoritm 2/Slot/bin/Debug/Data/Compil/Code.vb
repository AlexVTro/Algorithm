Module CodeAlg

Public WithEvents Окно10Окно10 As New runF
Public WithEvents Окно10Закладки10 As New runTP
Public WithEvents Окно10Окно_сохранения10 As New runSD
Public WithEvents Окно10Интернет10 As New runI
Public WithEvents Окно10Надпись10 As New runLb
Public WithEvents Окно10Надпись20 As New runLb
Public WithEvents Окно10Панель_10 As New runP
Public WithEvents Окно10Надпись30 As New runLb
Public WithEvents Окно10Надпись40 As New runLb
Public WithEvents Окно10Надпись50 As New runLb
Public WithEvents Окно10Закладки1_Закладка10 As New runTPs
Public WithEvents Окно10Закладки1_Закладка20 As New runTPs
Public WithEvents Окно10КнопкаСкачать0 As New runB
Public WithEvents Окно10КнопкаОтменить0 As New runB
Public WithEvents Окно10КнопкаПауза0 As New runB
Public WithEvents Окно10Полоса_загрузки10 As New runPrB
Public WithEvents Окно10НадписьПроцент0 As New runLb
Public WithEvents Окно10Рисунок10 As New runPb
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

Окно10Закладки10.MyObj = New TPage(True, True)
Окно10Закладки10.MyObj.proj = proj
Окно10Закладки10.MyObj.obj = Окно10Закладки10
Окно10Закладки10.MyObj.VBname = "Окно10Закладки10"
Окно10Закладки10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Закладки10.MyObj.MyForm.MyObjs) : Окно10Закладки10.MyObj.MyForm.MyObjs(Окно10Закладки10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Закладки10.MyObj

Окно10Окно_сохранения10.MyObj = New SaveDialog(True, True)
Окно10Окно_сохранения10.MyObj.proj = proj
Окно10Окно_сохранения10.MyObj.obj = Окно10Окно_сохранения10
Окно10Окно_сохранения10.MyObj.VBname = "Окно10Окно_сохранения10"
Окно10Окно_сохранения10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Окно_сохранения10.MyObj.MyForm.MyObjs) : Окно10Окно_сохранения10.MyObj.MyForm.MyObjs(Окно10Окно_сохранения10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Окно_сохранения10.MyObj

Окно10Интернет10.MyObj = New Internet(True, True)
Окно10Интернет10.MyObj.proj = proj
Окно10Интернет10.MyObj.obj = Окно10Интернет10
Окно10Интернет10.MyObj.VBname = "Окно10Интернет10"
Окно10Интернет10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Интернет10.MyObj.MyForm.MyObjs) : Окно10Интернет10.MyObj.MyForm.MyObjs(Окно10Интернет10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Интернет10.MyObj

Окно10Надпись10.MyObj = New Label(True, True)
Окно10Надпись10.MyObj.proj = proj
Окно10Надпись10.MyObj.obj = Окно10Надпись10
Окно10Надпись10.MyObj.VBname = "Окно10Надпись10"
Окно10Надпись10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись10.MyObj.MyForm.MyObjs) : Окно10Надпись10.MyObj.MyForm.MyObjs(Окно10Надпись10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись10.MyObj

ProgressForm.ProgressBar1.Value = 4
Окно10Надпись20.MyObj = New Label(True, True)
Окно10Надпись20.MyObj.proj = proj
Окно10Надпись20.MyObj.obj = Окно10Надпись20
Окно10Надпись20.MyObj.VBname = "Окно10Надпись20"
Окно10Надпись20.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись20.MyObj.MyForm.MyObjs) : Окно10Надпись20.MyObj.MyForm.MyObjs(Окно10Надпись20.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись20.MyObj

Окно10Панель_10.MyObj = New Panel(True, True)
Окно10Панель_10.MyObj.proj = proj
Окно10Панель_10.MyObj.obj = Окно10Панель_10
Окно10Панель_10.MyObj.VBname = "Окно10Панель_10"
Окно10Панель_10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Панель_10.MyObj.MyForm.MyObjs) : Окно10Панель_10.MyObj.MyForm.MyObjs(Окно10Панель_10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Панель_10.MyObj

Окно10Надпись30.MyObj = New Label(True, True)
Окно10Надпись30.MyObj.proj = proj
Окно10Надпись30.MyObj.obj = Окно10Надпись30
Окно10Надпись30.MyObj.VBname = "Окно10Надпись30"
Окно10Надпись30.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись30.MyObj.MyForm.MyObjs) : Окно10Надпись30.MyObj.MyForm.MyObjs(Окно10Надпись30.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись30.MyObj

Окно10Надпись40.MyObj = New Label(True, True)
Окно10Надпись40.MyObj.proj = proj
Окно10Надпись40.MyObj.obj = Окно10Надпись40
Окно10Надпись40.MyObj.VBname = "Окно10Надпись40"
Окно10Надпись40.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись40.MyObj.MyForm.MyObjs) : Окно10Надпись40.MyObj.MyForm.MyObjs(Окно10Надпись40.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись40.MyObj

Окно10Надпись50.MyObj = New Label(True, True)
Окно10Надпись50.MyObj.proj = proj
Окно10Надпись50.MyObj.obj = Окно10Надпись50
Окно10Надпись50.MyObj.VBname = "Окно10Надпись50"
Окно10Надпись50.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись50.MyObj.MyForm.MyObjs) : Окно10Надпись50.MyObj.MyForm.MyObjs(Окно10Надпись50.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись50.MyObj

ProgressForm.ProgressBar1.Value = 9
Окно10Закладки1_Закладка10.MyObj = New TPages(True, True)
Окно10Закладки1_Закладка10.MyObj.proj = proj
Окно10Закладки1_Закладка10.MyObj.obj = Окно10Закладки1_Закладка10
Окно10Закладки1_Закладка10.MyObj.VBname = "Окно10Закладки1_Закладка10"
Окно10Закладки1_Закладка10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Закладки1_Закладка10.MyObj.MyForm.MyObjs) : Окно10Закладки1_Закладка10.MyObj.MyForm.MyObjs(Окно10Закладки1_Закладка10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Закладки1_Закладка10.MyObj

Окно10Закладки1_Закладка20.MyObj = New TPages(True, True)
Окно10Закладки1_Закладка20.MyObj.proj = proj
Окно10Закладки1_Закладка20.MyObj.obj = Окно10Закладки1_Закладка20
Окно10Закладки1_Закладка20.MyObj.VBname = "Окно10Закладки1_Закладка20"
Окно10Закладки1_Закладка20.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Закладки1_Закладка20.MyObj.MyForm.MyObjs) : Окно10Закладки1_Закладка20.MyObj.MyForm.MyObjs(Окно10Закладки1_Закладка20.MyObj.MyForm.MyObjs.Length - 1) = Окно10Закладки1_Закладка20.MyObj

Окно10КнопкаСкачать0.MyObj = New Button(True, True)
Окно10КнопкаСкачать0.MyObj.proj = proj
Окно10КнопкаСкачать0.MyObj.obj = Окно10КнопкаСкачать0
Окно10КнопкаСкачать0.MyObj.VBname = "Окно10КнопкаСкачать0"
Окно10КнопкаСкачать0.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10КнопкаСкачать0.MyObj.MyForm.MyObjs) : Окно10КнопкаСкачать0.MyObj.MyForm.MyObjs(Окно10КнопкаСкачать0.MyObj.MyForm.MyObjs.Length - 1) = Окно10КнопкаСкачать0.MyObj

Окно10КнопкаОтменить0.MyObj = New Button(True, True)
Окно10КнопкаОтменить0.MyObj.proj = proj
Окно10КнопкаОтменить0.MyObj.obj = Окно10КнопкаОтменить0
Окно10КнопкаОтменить0.MyObj.VBname = "Окно10КнопкаОтменить0"
Окно10КнопкаОтменить0.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10КнопкаОтменить0.MyObj.MyForm.MyObjs) : Окно10КнопкаОтменить0.MyObj.MyForm.MyObjs(Окно10КнопкаОтменить0.MyObj.MyForm.MyObjs.Length - 1) = Окно10КнопкаОтменить0.MyObj

Окно10КнопкаПауза0.MyObj = New Button(True, True)
Окно10КнопкаПауза0.MyObj.proj = proj
Окно10КнопкаПауза0.MyObj.obj = Окно10КнопкаПауза0
Окно10КнопкаПауза0.MyObj.VBname = "Окно10КнопкаПауза0"
Окно10КнопкаПауза0.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10КнопкаПауза0.MyObj.MyForm.MyObjs) : Окно10КнопкаПауза0.MyObj.MyForm.MyObjs(Окно10КнопкаПауза0.MyObj.MyForm.MyObjs.Length - 1) = Окно10КнопкаПауза0.MyObj

ProgressForm.ProgressBar1.Value = 13
Окно10Полоса_загрузки10.MyObj = New ProgressBar(True, True)
Окно10Полоса_загрузки10.MyObj.proj = proj
Окно10Полоса_загрузки10.MyObj.obj = Окно10Полоса_загрузки10
Окно10Полоса_загрузки10.MyObj.VBname = "Окно10Полоса_загрузки10"
Окно10Полоса_загрузки10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Полоса_загрузки10.MyObj.MyForm.MyObjs) : Окно10Полоса_загрузки10.MyObj.MyForm.MyObjs(Окно10Полоса_загрузки10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Полоса_загрузки10.MyObj

Окно10НадписьПроцент0.MyObj = New Label(True, True)
Окно10НадписьПроцент0.MyObj.proj = proj
Окно10НадписьПроцент0.MyObj.obj = Окно10НадписьПроцент0
Окно10НадписьПроцент0.MyObj.VBname = "Окно10НадписьПроцент0"
Окно10НадписьПроцент0.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10НадписьПроцент0.MyObj.MyForm.MyObjs) : Окно10НадписьПроцент0.MyObj.MyForm.MyObjs(Окно10НадписьПроцент0.MyObj.MyForm.MyObjs.Length - 1) = Окно10НадписьПроцент0.MyObj

Окно10Рисунок10.MyObj = New PictureBoks(True, True)
Окно10Рисунок10.MyObj.proj = proj
Окно10Рисунок10.MyObj.obj = Окно10Рисунок10
Окно10Рисунок10.MyObj.VBname = "Окно10Рисунок10"
Окно10Рисунок10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Рисунок10.MyObj.MyForm.MyObjs) : Окно10Рисунок10.MyObj.MyForm.MyObjs(Окно10Рисунок10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Рисунок10.MyObj

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

ProgressForm.ProgressBar1.Value = 17
_Полезные_объекты0_Файлы_и_папки0.MyObj = New Poleznie("_Файлы и папки")
_Полезные_объекты0_Файлы_и_папки0.MyObj.proj = proj
_Полезные_объекты0_Файлы_и_папки0.MyObj.obj = _Полезные_объекты0_Файлы_и_папки0
_Полезные_объекты0_Файлы_и_папки0.MyObj.VBname = "_Полезные_объекты0_Файлы_и_папки0"
_Полезные_объекты0_Файлы_и_папки0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
ReDimsO(_Полезные_объекты0_Файлы_и_папки0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Файлы_и_папки0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Файлы_и_папки0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Файлы_и_папки0.MyObj

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

ProgressForm.ProgressBar1.Value = 22
_Полезные_объекты0_Текст0.MyObj = New Poleznie("_Текст")
_Полезные_объекты0_Текст0.MyObj.proj = proj
_Полезные_объекты0_Текст0.MyObj.obj = _Полезные_объекты0_Текст0
_Полезные_объекты0_Текст0.MyObj.VBname = "_Полезные_объекты0_Текст0"
_Полезные_объекты0_Текст0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
ReDimsO(_Полезные_объекты0_Текст0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Текст0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Текст0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Текст0.MyObj

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
Окно10Окно10.Controls.Add(Окно10Закладки10)
Окно10Окно10.Controls.Add(Окно10Интернет10)
Окно10Окно10.Controls.Add(Окно10Надпись10)
ProgressForm.ProgressBar1.Value = 27
Окно10Окно10.Controls.Add(Окно10Надпись20)
Окно10Окно10.Controls.Add(Окно10Панель_10)
Окно10Панель_10.Controls.Add(Окно10Надпись30)
Окно10Панель_10.Controls.Add(Окно10Надпись40)
Окно10Панель_10.Controls.Add(Окно10Надпись50)
ProgressForm.ProgressBar1.Value = 28
Окно10Закладки10.Controls.Add(Окно10Закладки1_Закладка10)
Окно10Закладки10.Controls.Add(Окно10Закладки1_Закладка20)
Окно10Закладки1_Закладка10.Controls.Add(Окно10КнопкаСкачать0)
Окно10Закладки1_Закладка10.Controls.Add(Окно10КнопкаОтменить0)
Окно10Закладки1_Закладка10.Controls.Add(Окно10КнопкаПауза0)
ProgressForm.ProgressBar1.Value = 30
Окно10Закладки1_Закладка10.Controls.Add(Окно10Полоса_загрузки10)
Окно10Закладки1_Закладка10.Controls.Add(Окно10НадписьПроцент0)
Окно10Закладки1_Закладка20.Controls.Add(Окно10Рисунок10)
ProgressForm.ProgressBar1.Value = 32
ProgressForm.ProgressBar1.Value = 34


' Уровнять по уровням объекты
ProgressForm.ProgressBar1.Value = 35
Окно10Закладки1_Закладка10.BringToFront()
Окно10Закладки1_Закладка20.BringToFront()
Окно10Закладки10.BringToFront()
Окно10КнопкаСкачать0.BringToFront()
Окно10КнопкаОтменить0.BringToFront()
Окно10КнопкаПауза0.BringToFront()
Окно10Полоса_загрузки10.BringToFront()
Окно10НадписьПроцент0.BringToFront()
Окно10Панель_10.BringToFront()
Окно10Окно_сохранения10.BringToFront()
Окно10Интернет10.BringToFront()
Окно10Надпись10.BringToFront()
Окно10Надпись20.BringToFront()
Окно10Надпись30.BringToFront()
Окно10Надпись40.BringToFront()
Окно10Рисунок10.BringToFront()
Окно10Надпись50.BringToFront()
ProgressForm.ProgressBar1.Value = 37
ProgressForm.ProgressBar1.Value = 38
ProgressForm.ProgressBar1.Value = 40
ProgressForm.ProgressBar1.Value = 42
ProgressForm.ProgressBar1.Value = 44


' Настройка свойств объектов
ProgressForm.ProgressBar1.Value = 45
Окно10Окно10.Props.Text = perevesti("ШаурмаПрограмм", True)
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
Окно10Окно10.Props.Forbidmaximize = perevesti("Да", True)
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
Окно10Окно10.Props.Showintray = perevesti("Да", True)
Окно10Окно10.Props.TopMost = perevesti("Нет", True)
Окно10Окно10.Props.ToolTip = perevesti("", True)
Окно10Окно10.Props.Showicon = perevesti("Нет", True)
Окно10Окно10.Props.Opacity = perevesti("90", True)
Окно10Окно10.Props.Transparentcykey = perevesti("Никакой", True)
Окно10Окно10.Props.Scroll = perevesti("Нет", True)
Окно10Окно10.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно10Окно10.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно10Окно10.Props.AutoscrollpositionX = perevesti("0", True)
Окно10Окно10.Props.AutoscrollpositionY = perevesti("0", True)
Окно10Окно10.Props.Enabled = perevesti("Да", True)
Окно10Окно10.Props.Allowruncopies = perevesti("Нет", True)
Окно10Окно10.Props.Startposition = perevesti("Заданная координатами", True)
Окно10Окно10.StatusTemp = "Нормальный"
Окно10Окно10.Props.Formborderstyle = perevesti("Нормальный", True)
Окно10Окно10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Окно10.Props.Tabindex = perevesti("0", True)
Окно10Окно10.Props.Tabstop = perevesti("Да", True)
Окно10Окно10.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Окно10.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Окно10.Props.Forecolor = perevesti("Черный", True)
Окно10Окно10.Props.Height = perevesti("395", True)
Окно10Окно10.Props.Width = perevesti("631", True)
Окно10Окно10.Props.Visible = perevesti("Да", True)
Окно10Окно10.Props.Height = perevesti("395", True)
Окно10Окно10.Props.Width = perevesti("631", True)

ProgressForm.ProgressBar1.Value = 47
Окно10Закладки10.Props.X = perevesti("0", True)
Окно10Закладки10.Props.Y = perevesti("0", True)
Окно10Закладки10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Закладки10.Props.Tag = perevesti("", True)
Окно10Закладки10.Props.Name = perevesti("Закладки1", True)
Окно10Закладки10.Props.Cursor = perevesti("Обычный", True)
Окно10Закладки10.Props.Maximumheight = perevesti("0", True)
Окно10Закладки10.Props.Maximumwidth = perevesti("0", True)
Окно10Закладки10.Props.Minimumheight = perevesti("0", True)
Окно10Закладки10.Props.Minimumwidth = perevesti("0", True)
Окно10Закладки10.Props.Multiline = perevesti("Нет", True)
Окно10Закладки10.Props.Index = perevesti("0", True)
Окно10Закладки10.Props.ToolTip = perevesti("", True)
Окно10Закладки10.Props.Selectedtabposition = perevesti("0", True)
Окно10Закладки10.Props.PaddingY = perevesti("3", True)
Окно10Закладки10.Props.PaddingX = perevesti("6", True)
Окно10Закладки10.Props.Tabalignment = perevesti("Сверху", True)
Окно10Закладки10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Закладки10.Props.Enabled = perevesti("Да", True)
Окно10Закладки10.Props.Dock = perevesti("Никакой", True)
Окно10Закладки10.Props.Tabindex = perevesti("0", True)
Окно10Закладки10.Props.Tabstop = perevesti("Да", True)
Окно10Закладки10.Props.Height = perevesti("371", True)
Окно10Закладки10.Props.Width = perevesti("631", True)
Окно10Закладки10.Props.Visible = perevesti("Да", True)
Окно10Закладки10.Props.Height = perevesti("371", True)
Окно10Закладки10.Props.Width = perevesti("631", True)

ProgressForm.ProgressBar1.Value = 49
Окно10Окно_сохранения10.Props.X = perevesti("12", True)
Окно10Окно_сохранения10.Props.Y = perevesti("12", True)
Окно10Окно_сохранения10.Props.Tag = perevesti("", True)
Окно10Окно_сохранения10.Props.Defaultext = perevesti("", True)
Окно10Окно_сохранения10.Props.Title = perevesti("", True)
Окно10Окно_сохранения10.Props.Name = perevesti("Окно сохранения1", True)
Окно10Окно_сохранения10.Props.Filename = perevesti("", True)
Окно10Окно_сохранения10.Props.Initialdirectory = perevesti("", True)
Окно10Окно_сохранения10.Props.Index = perevesti("0", True)
Окно10Окно_сохранения10.Props.Filterindex = perevesti("1", True)
Окно10Окно_сохранения10.Props.Checkpathexists = perevesti("Да", True)
Окно10Окно_сохранения10.Props.Checkfileexists = perevesti("Нет", True)
Окно10Окно_сохранения10.Props.Filter = perevesti("Программы|*.exe|Все файлы|*.*", True)

ProgressForm.ProgressBar1.Value = 51
Окно10Интернет10.Props.X = perevesti("612", True)
Окно10Интернет10.Props.Y = perevesti("372", True)
Окно10Интернет10.Props.Allowautoredirect = perevesti("Нет", True)
Окно10Интернет10.Props.Timedelay = perevesti("0", True)
Окно10Интернет10.Props.Tag = perevesti("", True)
Окно10Интернет10.Props.Name = perevesti("Интернет1", True)
Окно10Интернет10.Props.Encodingpage = perevesti("windows-1251", True)
Окно10Интернет10.Props.Cookiesqueries = perevesti("", True)
Окно10Интернет10.Props.Maximumheight = perevesti("0", True)
Окно10Интернет10.Props.Maximumwidth = perevesti("0", True)
Окно10Интернет10.Props.Httpmethod = perevesti("POST", True)
Окно10Интернет10.Props.Minimumheight = perevesti("0", True)
Окно10Интернет10.Props.Minimumwidth = perevesti("0", True)
Окно10Интернет10.Props.Index = perevesti("0", True)
Окно10Интернет10.Props.Pathfordownloads = perevesti("", True)
Окно10Интернет10.Props.ToolTip = perevesti("", True)
Окно10Интернет10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Интернет10.Props.Accept = perevesti("image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*", True)
Окно10Интернет10.Props.ProxyIP = perevesti("", True)
Окно10Интернет10.Props.Proxyport = perevesti("0", True)
Окно10Интернет10.Props.Enabled = perevesti("Да", True)
Окно10Интернет10.Props.Buffersize = perevesti("5000", True)
Окно10Интернет10.Props.Dock = perevesti("Никакой", True)
Окно10Интернет10.Props.Resultquery = perevesti("", True)
Окно10Интернет10.Props.Filedownloading = perevesti("Нет", True)
Окно10Интернет10.Props.Downloadpause = perevesti("Нет", True)
Окно10Интернет10.Props.Contentquery = perevesti("", True)
Окно10Интернет10.Props.Urltogo = perevesti("http://www.Algoritm2.ru", True)
Окно10Интернет10.Props.Urlreferer = perevesti("", True)
Окно10Интернет10.Props.Urlredirect = perevesti("", True)
Окно10Интернет10.Props.Borderstyle = perevesti("Никакой", True)
Окно10Интернет10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Интернет10.Props.Tabindex = perevesti("0", True)
Окно10Интернет10.Props.Tabstop = perevesti("Да", True)
Окно10Интернет10.Props.Timeout = perevesti("10000", True)
Окно10Интернет10.Props.Useragent = perevesti("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;", True)
Окно10Интернет10.Props.Contenttype = perevesti("application/x-www-form-urlencoded", True)
Окно10Интернет10.Props.Keepalive = perevesti("Нет", True)
Окно10Интернет10.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Интернет10.Props.Backcolor = perevesti("Никакой", True)
Окно10Интернет10.Props.Languagepage = perevesti("", True)
Окно10Интернет10.Props.Height = perevesti("23", True)
Окно10Интернет10.Props.Width = perevesti("11", True)
Окно10Интернет10.Props.Visible = perevesti("Да", True)
Окно10Интернет10.Props.Height = perevesti("23", True)
Окно10Интернет10.Props.Width = perevesti("11", True)

ProgressForm.ProgressBar1.Value = 53
Окно10Надпись10.Props.Text = perevesti("Пробная версия программы возможно дальнейшего продвижения", True)
Окно10Надпись10.Props.X = perevesti("0", True)
Окно10Надпись10.Props.Y = perevesti("372", True)
Окно10Надпись10.Props.Autoellipsis = perevesti("Да", True)
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
Окно10Надпись10.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись10.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись10.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись10.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись10.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись10.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись10.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись10.Props.Fontsize = perevesti("8", True)
Окно10Надпись10.Props.Height = perevesti("23", True)
Окно10Надпись10.Props.Width = perevesti("631", True)
Окно10Надпись10.Props.Visible = perevesti("Да", True)
Окно10Надпись10.Props.Height = perevesti("23", True)
Окно10Надпись10.Props.Width = perevesti("631", True)

ProgressForm.ProgressBar1.Value = 54
Окно10Надпись20.Props.Text = perevesti("Тут может быть ваша реклама которая будет меняться на вашем сайте.", True)
Окно10Надпись20.Props.X = perevesti("436", True)
Окно10Надпись20.Props.Y = perevesti("24", True)
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
Окно10Надпись20.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись20.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись20.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись20.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись20.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись20.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись20.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись20.Props.Fontsize = perevesti("8", True)
Окно10Надпись20.Props.Height = perevesti("79", True)
Окно10Надпись20.Props.Width = perevesti("95", True)
Окно10Надпись20.Props.Visible = perevesti("Да", True)
Окно10Надпись20.Props.Height = perevesti("79", True)
Окно10Надпись20.Props.Width = perevesti("95", True)

ProgressForm.ProgressBar1.Value = 56
Окно10Панель_10.Props.X = perevesti("432", True)
Окно10Панель_10.Props.Y = perevesti("20", True)
Окно10Панель_10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Панель_10.Props.Tag = perevesti("", True)
Окно10Панель_10.Props.Name = perevesti("Панель 1", True)
Окно10Панель_10.Props.Cursor = perevesti("Обычный", True)
Окно10Панель_10.Props.Maximumheight = perevesti("0", True)
Окно10Панель_10.Props.Maximumwidth = perevesti("0", True)
Окно10Панель_10.Props.Minimumheight = perevesti("0", True)
Окно10Панель_10.Props.Minimumwidth = perevesti("0", True)
Окно10Панель_10.Props.Index = perevesti("0", True)
Окно10Панель_10.Props.ToolTip = perevesti("", True)
Окно10Панель_10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Панель_10.Props.Scroll = perevesti("Нет", True)
Окно10Панель_10.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно10Панель_10.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно10Панель_10.Props.AutoscrollpositionX = perevesti("0", True)
Окно10Панель_10.Props.AutoscrollpositionY = perevesti("0", True)
Окно10Панель_10.Props.Enabled = perevesti("Да", True)
Окно10Панель_10.Props.Dock = perevesti("Никакой", True)
Окно10Панель_10.Props.Borderstyle = perevesti("линия", True)
Окно10Панель_10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Панель_10.Props.Tabindex = perevesti("0", True)
Окно10Панель_10.Props.Tabstop = perevesti("Да", True)
Окно10Панель_10.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Панель_10.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Панель_10.Props.Height = perevesti("315", True)
Окно10Панель_10.Props.Width = perevesti("199", True)
Окно10Панель_10.Props.Visible = perevesti("Да", True)
Окно10Панель_10.Props.Height = perevesti("315", True)
Окно10Панель_10.Props.Width = perevesti("199", True)

ProgressForm.ProgressBar1.Value = 58
Окно10Надпись30.Props.Text = perevesti("Либо можно добавить новости по игровому серверу которая так же будет меняться у вас на сайте.", True)
Окно10Надпись30.Props.X = perevesti("4", True)
Окно10Надпись30.Props.Y = perevesti("92", True)
Окно10Надпись30.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись30.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись30.Props.Tag = perevesti("", True)
Окно10Надпись30.Props.Name = perevesti("Надпись3", True)
Окно10Надпись30.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись30.Props.Maximumheight = perevesti("0", True)
Окно10Надпись30.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись30.Props.Minimumheight = perevesti("0", True)
Окно10Надпись30.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись30.Props.Index = perevesti("0", True)
Окно10Надпись30.Props.ToolTip = perevesti("", True)
Окно10Надпись30.Props.Paddingtop = perevesti("0", True)
Окно10Надпись30.Props.Paddingleft = perevesti("0", True)
Окно10Надпись30.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись30.Props.Paddingright = perevesti("0", True)
Окно10Надпись30.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись30.Props.Textalign = perevesti("центр", True)
Окно10Надпись30.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись30.Props.Enabled = perevesti("Да", True)
Окно10Надпись30.Props.Dock = perevesti("Никакой", True)
Окно10Надпись30.Props.Image = perevesti("Никакой", True)
Окно10Надпись30.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись30.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись30.Props.Tabindex = perevesti("0", True)
Окно10Надпись30.Props.Tabstop = perevesti("Да", True)
Окно10Надпись30.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись30.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись30.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись30.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись30.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись30.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись30.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись30.Props.Fontsize = perevesti("8", True)
Окно10Надпись30.Props.Height = perevesti("95", True)
Окно10Надпись30.Props.Width = perevesti("107", True)
Окно10Надпись30.Props.Visible = perevesti("Да", True)
Окно10Надпись30.Props.Height = perevesti("95", True)
Окно10Надпись30.Props.Width = perevesti("107", True)

ProgressForm.ProgressBar1.Value = 60
Окно10Надпись40.Props.Text = perevesti("Что то типа форгейма кто помнит", True)
Окно10Надпись40.Props.X = perevesti("128", True)
Окно10Надпись40.Props.Y = perevesti("8", True)
Окно10Надпись40.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись40.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись40.Props.Tag = perevesti("", True)
Окно10Надпись40.Props.Name = perevesti("Надпись4", True)
Окно10Надпись40.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись40.Props.Maximumheight = perevesti("0", True)
Окно10Надпись40.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись40.Props.Minimumheight = perevesti("0", True)
Окно10Надпись40.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись40.Props.Index = perevesti("0", True)
Окно10Надпись40.Props.ToolTip = perevesti("", True)
Окно10Надпись40.Props.Paddingtop = perevesti("0", True)
Окно10Надпись40.Props.Paddingleft = perevesti("0", True)
Окно10Надпись40.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись40.Props.Paddingright = perevesti("0", True)
Окно10Надпись40.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись40.Props.Textalign = perevesti("центр", True)
Окно10Надпись40.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись40.Props.Enabled = perevesti("Да", True)
Окно10Надпись40.Props.Dock = perevesti("Никакой", True)
Окно10Надпись40.Props.Image = perevesti("Никакой", True)
Окно10Надпись40.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись40.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись40.Props.Tabindex = perevesti("0", True)
Окно10Надпись40.Props.Tabstop = perevesti("Да", True)
Окно10Надпись40.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись40.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись40.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись40.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись40.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись40.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись40.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись40.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись40.Props.Fontsize = perevesti("8", True)
Окно10Надпись40.Props.Height = perevesti("91", True)
Окно10Надпись40.Props.Width = perevesti("59", True)
Окно10Надпись40.Props.Visible = perevesti("Да", True)
Окно10Надпись40.Props.Height = perevesti("91", True)
Окно10Надпись40.Props.Width = perevesti("59", True)

ProgressForm.ProgressBar1.Value = 62
Окно10Надпись50.Props.Text = perevesti("Это пробная программа собранная· не брежно:) всё это можно исправить.", True)
Окно10Надпись50.Props.X = perevesti("4", True)
Окно10Надпись50.Props.Y = perevesti("200", True)
Окно10Надпись50.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись50.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись50.Props.Tag = perevesti("", True)
Окно10Надпись50.Props.Name = perevesti("Надпись5", True)
Окно10Надпись50.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись50.Props.Maximumheight = perevesti("0", True)
Окно10Надпись50.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись50.Props.Minimumheight = perevesti("0", True)
Окно10Надпись50.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись50.Props.Index = perevesti("0", True)
Окно10Надпись50.Props.ToolTip = perevesti("", True)
Окно10Надпись50.Props.Paddingtop = perevesti("0", True)
Окно10Надпись50.Props.Paddingleft = perevesti("0", True)
Окно10Надпись50.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись50.Props.Paddingright = perevesti("0", True)
Окно10Надпись50.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись50.Props.Textalign = perevesti("центр", True)
Окно10Надпись50.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись50.Props.Enabled = perevesti("Да", True)
Окно10Надпись50.Props.Dock = perevesti("Никакой", True)
Окно10Надпись50.Props.Image = perevesti("Никакой", True)
Окно10Надпись50.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись50.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись50.Props.Tabindex = perevesti("0", True)
Окно10Надпись50.Props.Tabstop = perevesti("Да", True)
Окно10Надпись50.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись50.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись50.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись50.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись50.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись50.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись50.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись50.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись50.Props.Fontsize = perevesti("8", True)
Окно10Надпись50.Props.Height = perevesti("71", True)
Окно10Надпись50.Props.Width = perevesti("115", True)
Окно10Надпись50.Props.Visible = perevesti("Да", True)
Окно10Надпись50.Props.Height = perevesti("71", True)
Окно10Надпись50.Props.Width = perevesti("115", True)

ProgressForm.ProgressBar1.Value = 64
Окно10Закладки1_Закладка10.Props.Text = perevesti("    Day-Z    ", True)
Окно10Закладки1_Закладка10.Props.X = perevesti("4", True)
Окно10Закладки1_Закладка10.Props.Y = perevesti("22", True)
Окно10Закладки1_Закладка10.Props.Tooltiptext = perevesti("", True)
Окно10Закладки1_Закладка10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Закладки1_Закладка10.Props.Tag = perevesti("", True)
Окно10Закладки1_Закладка10.Props.Name = perevesti("Закладки1 Закладка1", True)
Окно10Закладки1_Закладка10.Props.Cursor = perevesti("Обычный", True)
Окно10Закладки1_Закладка10.Props.Maximumheight = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.Maximumwidth = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.Minimumheight = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.Minimumwidth = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.Index = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.Position = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.Scroll = perevesti("Нет", True)
Окно10Закладки1_Закладка10.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.AutoscrollpositionX = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.AutoscrollpositionY = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.Enabled = perevesti("Да", True)
Окно10Закладки1_Закладка10.Props.Borderstyle = perevesti("Никакой", True)
Окно10Закладки1_Закладка10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Закладки1_Закладка10.Props.Tabindex = perevesti("0", True)
Окно10Закладки1_Закладка10.Props.Tabstop = perevesti("Да", True)
Окно10Закладки1_Закладка10.Props.Backgroundimage = perevesti("Рисунки\Рисунок3.png", True)
Окно10Закладки1_Закладка10.Props.Backcolor = perevesti("Системный", True)
Окно10Закладки1_Закладка10.Props.Height = perevesti("345", True)
Окно10Закладки1_Закладка10.Props.Width = perevesti("623", True)
Окно10Закладки1_Закладка10.Props.Height = perevesti("345", True)
Окно10Закладки1_Закладка10.Props.Width = perevesti("623", True)

ProgressForm.ProgressBar1.Value = 66
Окно10Закладки1_Закладка20.Props.Text = perevesti("     Cs:Source     ", True)
Окно10Закладки1_Закладка20.Props.X = perevesti("4", True)
Окно10Закладки1_Закладка20.Props.Y = perevesti("22", True)
Окно10Закладки1_Закладка20.Props.Tooltiptext = perevesti("", True)
Окно10Закладки1_Закладка20.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Закладки1_Закладка20.Props.Tag = perevesti("", True)
Окно10Закладки1_Закладка20.Props.Name = perevesti("Закладки1 Закладка2", True)
Окно10Закладки1_Закладка20.Props.Cursor = perevesti("Обычный", True)
Окно10Закладки1_Закладка20.Props.Maximumheight = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.Maximumwidth = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.Minimumheight = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.Minimumwidth = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.Index = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.Position = perevesti("1", True)
Окно10Закладки1_Закладка20.Props.Scroll = perevesti("Нет", True)
Окно10Закладки1_Закладка20.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.AutoscrollpositionX = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.AutoscrollpositionY = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.Enabled = perevesti("Да", True)
Окно10Закладки1_Закладка20.Props.Borderstyle = perevesti("Никакой", True)
Окно10Закладки1_Закладка20.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Закладки1_Закладка20.Props.Tabindex = perevesti("0", True)
Окно10Закладки1_Закладка20.Props.Tabstop = perevesti("Да", True)
Окно10Закладки1_Закладка20.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Закладки1_Закладка20.Props.Backcolor = perevesti("Системный", True)
Окно10Закладки1_Закладка20.Props.Height = perevesti("345", True)
Окно10Закладки1_Закладка20.Props.Width = perevesti("623", True)
Окно10Закладки1_Закладка20.Props.Height = perevesti("345", True)
Окно10Закладки1_Закладка20.Props.Width = perevesti("623", True)

ProgressForm.ProgressBar1.Value = 68
Окно10КнопкаСкачать0.Props.Text = perevesti(" ", True)
Окно10КнопкаСкачать0.Props.X = perevesti("-4", True)
Окно10КнопкаСкачать0.Props.Y = perevesti("308", True)
Окно10КнопкаСкачать0.Props.Autoellipsis = perevesti("Да", True)
Окно10КнопкаСкачать0.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10КнопкаСкачать0.Props.Tag = perevesti("", True)
Окно10КнопкаСкачать0.Props.Name = perevesti("КнопкаСкачать", True)
Окно10КнопкаСкачать0.Props.Cursor = perevesti("Обычный", True)
Окно10КнопкаСкачать0.Props.Maximumheight = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Maximumwidth = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Minimumheight = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Minimumwidth = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Index = perevesti("0", True)
Окно10КнопкаСкачать0.Props.ToolTip = perevesti("", True)
Окно10КнопкаСкачать0.Props.Paddingtop = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Paddingleft = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Paddingbottom = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Paddingright = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Imagealign = perevesti("Центр", True)
Окно10КнопкаСкачать0.Props.Textalign = perevesti("центр", True)
Окно10КнопкаСкачать0.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10КнопкаСкачать0.Props.Enabled = perevesti("Да", True)
Окно10КнопкаСкачать0.Props.Dock = perevesti("Никакой", True)
Окно10КнопкаСкачать0.Props.Image = perevesti("Никакой", True)
Окно10КнопкаСкачать0.Props.Flatstyle = perevesti("Обычный", True)
Окно10КнопкаСкачать0.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10КнопкаСкачать0.Props.Tabindex = perevesti("0", True)
Окно10КнопкаСкачать0.Props.Tabstop = perevesti("Да", True)
Окно10КнопкаСкачать0.Props.Textimagerelation = perevesti("Поверх", True)
Окно10КнопкаСкачать0.Props.Backgroundimage = perevesti("Рисунки\Рисунок4.png", True)
Окно10КнопкаСкачать0.Props.Backcolor = perevesti("Никакой", True)
Окно10КнопкаСкачать0.Props.Forecolor = perevesti("Черный", True)
Окно10КнопкаСкачать0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10КнопкаСкачать0.Props.Fontbold = perevesti("Нет", True)
Окно10КнопкаСкачать0.Props.Fontstrikeout = perevesti("Нет", True)
Окно10КнопкаСкачать0.Props.Fontitalic = perevesti("Нет", True)
Окно10КнопкаСкачать0.Props.Fontunderline = perevesti("Нет", True)
Окно10КнопкаСкачать0.Props.Fontsize = perevesti("8", True)
Окно10КнопкаСкачать0.Props.Height = perevesti("39", True)
Окно10КнопкаСкачать0.Props.Width = perevesti("47", True)
Окно10КнопкаСкачать0.Props.Visible = perevesti("Да", True)
Окно10КнопкаСкачать0.Props.Height = perevesti("39", True)
Окно10КнопкаСкачать0.Props.Width = perevesti("47", True)

ProgressForm.ProgressBar1.Value = 70
Окно10КнопкаОтменить0.Props.Text = perevesti("..", True)
Окно10КнопкаОтменить0.Props.X = perevesti("592", True)
Окно10КнопкаОтменить0.Props.Y = perevesti("320", True)
Окно10КнопкаОтменить0.Props.Autoellipsis = perevesti("Да", True)
Окно10КнопкаОтменить0.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10КнопкаОтменить0.Props.Tag = perevesti("", True)
Окно10КнопкаОтменить0.Props.Name = perevesti("КнопкаОтменить", True)
Окно10КнопкаОтменить0.Props.Cursor = perevesti("Обычный", True)
Окно10КнопкаОтменить0.Props.Maximumheight = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Maximumwidth = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Minimumheight = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Minimumwidth = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Index = perevesti("0", True)
Окно10КнопкаОтменить0.Props.ToolTip = perevesti("", True)
Окно10КнопкаОтменить0.Props.Paddingtop = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Paddingleft = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Paddingbottom = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Paddingright = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Imagealign = perevesti("Центр", True)
Окно10КнопкаОтменить0.Props.Textalign = perevesti("центр", True)
Окно10КнопкаОтменить0.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10КнопкаОтменить0.Props.Enabled = perevesti("Да", True)
Окно10КнопкаОтменить0.Props.Dock = perevesti("Никакой", True)
Окно10КнопкаОтменить0.Props.Image = perevesti("Никакой", True)
Окно10КнопкаОтменить0.Props.Flatstyle = perevesti("Обычный", True)
Окно10КнопкаОтменить0.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10КнопкаОтменить0.Props.Tabindex = perevesti("0", True)
Окно10КнопкаОтменить0.Props.Tabstop = perevesti("Да", True)
Окно10КнопкаОтменить0.Props.Textimagerelation = perevesti("Поверх", True)
Окно10КнопкаОтменить0.Props.Backgroundimage = perevesti("Рисунки\Рисунок7.png", True)
Окно10КнопкаОтменить0.Props.Backcolor = perevesti("Никакой", True)
Окно10КнопкаОтменить0.Props.Forecolor = perevesti("Черный", True)
Окно10КнопкаОтменить0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10КнопкаОтменить0.Props.Fontbold = perevesti("Нет", True)
Окно10КнопкаОтменить0.Props.Fontstrikeout = perevesti("Нет", True)
Окно10КнопкаОтменить0.Props.Fontitalic = perevesti("Нет", True)
Окно10КнопкаОтменить0.Props.Fontunderline = perevesti("Нет", True)
Окно10КнопкаОтменить0.Props.Fontsize = perevesti("8", True)
Окно10КнопкаОтменить0.Props.Height = perevesti("27", True)
Окно10КнопкаОтменить0.Props.Width = perevesti("31", True)
Окно10КнопкаОтменить0.Props.Visible = perevesti("Да", True)
Окно10КнопкаОтменить0.Props.Height = perevesti("27", True)
Окно10КнопкаОтменить0.Props.Width = perevesti("31", True)

ProgressForm.ProgressBar1.Value = 72
Окно10КнопкаПауза0.Props.Text = perevesti(".", True)
Окно10КнопкаПауза0.Props.X = perevesti("44", True)
Окно10КнопкаПауза0.Props.Y = perevesti("320", True)
Окно10КнопкаПауза0.Props.Autoellipsis = perevesti("Да", True)
Окно10КнопкаПауза0.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10КнопкаПауза0.Props.Tag = perevesti("", True)
Окно10КнопкаПауза0.Props.Name = perevesti("КнопкаПауза", True)
Окно10КнопкаПауза0.Props.Cursor = perevesti("Обычный", True)
Окно10КнопкаПауза0.Props.Maximumheight = perevesti("0", True)
Окно10КнопкаПауза0.Props.Maximumwidth = perevesti("0", True)
Окно10КнопкаПауза0.Props.Minimumheight = perevesti("0", True)
Окно10КнопкаПауза0.Props.Minimumwidth = perevesti("0", True)
Окно10КнопкаПауза0.Props.Index = perevesti("0", True)
Окно10КнопкаПауза0.Props.ToolTip = perevesti("", True)
Окно10КнопкаПауза0.Props.Paddingtop = perevesti("0", True)
Окно10КнопкаПауза0.Props.Paddingleft = perevesti("0", True)
Окно10КнопкаПауза0.Props.Paddingbottom = perevesti("0", True)
Окно10КнопкаПауза0.Props.Paddingright = perevesti("0", True)
Окно10КнопкаПауза0.Props.Imagealign = perevesti("Центр", True)
Окно10КнопкаПауза0.Props.Textalign = perevesti("центр", True)
Окно10КнопкаПауза0.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10КнопкаПауза0.Props.Enabled = perevesti("Да", True)
Окно10КнопкаПауза0.Props.Dock = perevesti("Никакой", True)
Окно10КнопкаПауза0.Props.Image = perevesti("Никакой", True)
Окно10КнопкаПауза0.Props.Flatstyle = perevesti("Обычный", True)
Окно10КнопкаПауза0.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10КнопкаПауза0.Props.Tabindex = perevesti("0", True)
Окно10КнопкаПауза0.Props.Tabstop = perevesti("Да", True)
Окно10КнопкаПауза0.Props.Textimagerelation = perevesti("Поверх", True)
Окно10КнопкаПауза0.Props.Backgroundimage = perevesti("Рисунки\Рисунок6.png", True)
Окно10КнопкаПауза0.Props.Backcolor = perevesti("Никакой", True)
Окно10КнопкаПауза0.Props.Forecolor = perevesti("Черный", True)
Окно10КнопкаПауза0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10КнопкаПауза0.Props.Fontbold = perevesti("Нет", True)
Окно10КнопкаПауза0.Props.Fontstrikeout = perevesti("Нет", True)
Окно10КнопкаПауза0.Props.Fontitalic = perevesti("Нет", True)
Окно10КнопкаПауза0.Props.Fontunderline = perevesti("Нет", True)
Окно10КнопкаПауза0.Props.Fontsize = perevesti("8", True)
Окно10КнопкаПауза0.Props.Height = perevesti("27", True)
Окно10КнопкаПауза0.Props.Width = perevesti("31", True)
Окно10КнопкаПауза0.Props.Visible = perevesti("Да", True)
Окно10КнопкаПауза0.Props.Height = perevesti("27", True)
Окно10КнопкаПауза0.Props.Width = perevesti("31", True)

ProgressForm.ProgressBar1.Value = 73
Окно10Полоса_загрузки10.Props.X = perevesti("76", True)
Окно10Полоса_загрузки10.Props.Y = perevesti("320", True)
Окно10Полоса_загрузки10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Полоса_загрузки10.Props.Tag = perevesti("", True)
Окно10Полоса_загрузки10.Props.Name = perevesti("Полоса загрузки1", True)
Окно10Полоса_загрузки10.Props.Cursor = perevesti("Обычный", True)
Окно10Полоса_загрузки10.Props.Maximumheight = perevesti("0", True)
Окно10Полоса_загрузки10.Props.Maximumwidth = perevesti("0", True)
Окно10Полоса_загрузки10.Props.Maximum = perevesti("100", True)
Окно10Полоса_загрузки10.Props.Minimumheight = perevesti("0", True)
Окно10Полоса_загрузки10.Props.Minimumwidth = perevesti("0", True)
Окно10Полоса_загрузки10.Props.Minimum = perevesti("0", True)
Окно10Полоса_загрузки10.Props.Index = perevesti("0", True)
Окно10Полоса_загрузки10.Props.ToolTip = perevesti("", True)
Окно10Полоса_загрузки10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Полоса_загрузки10.Props.Enabled = perevesti("Да", True)
Окно10Полоса_загрузки10.Props.Dock = perevesti("Никакой", True)
Окно10Полоса_загрузки10.Props.Marqueeanimationspeed = perevesti("100", True)
Окно10Полоса_загрузки10.Props.Righttoleftlayout = perevesti("Нет", True)
Окно10Полоса_загрузки10.Props.Styleprogress = perevesti("блоки", True)
Окно10Полоса_загрузки10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Полоса_загрузки10.Props.Tabindex = perevesti("0", True)
Окно10Полоса_загрузки10.Props.Tabstop = perevesti("Да", True)
Окно10Полоса_загрузки10.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Полоса_загрузки10.Props.Backcolor = perevesti("Системный", True)
Окно10Полоса_загрузки10.Props.Stepprogress = perevesti("10", True)
Окно10Полоса_загрузки10.Props.Height = perevesti("27", True)
Окно10Полоса_загрузки10.Props.Width = perevesti("455", True)
Окно10Полоса_загрузки10.Props.Visible = perevesti("Да", True)
Окно10Полоса_загрузки10.Props.Height = perevesti("27", True)
Окно10Полоса_загрузки10.Props.Width = perevesti("455", True)
Окно10Полоса_загрузки10.Props.Value = perevesti("0", True)

ProgressForm.ProgressBar1.Value = 75
Окно10НадписьПроцент0.Props.Text = perevesti("0%", True)
Окно10НадписьПроцент0.Props.X = perevesti("532", True)
Окно10НадписьПроцент0.Props.Y = perevesti("320", True)
Окно10НадписьПроцент0.Props.Autoellipsis = perevesti("Да", True)
Окно10НадписьПроцент0.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10НадписьПроцент0.Props.Tag = perevesti("", True)
Окно10НадписьПроцент0.Props.Name = perevesti("НадписьПроцент", True)
Окно10НадписьПроцент0.Props.Cursor = perevesti("Обычный", True)
Окно10НадписьПроцент0.Props.Maximumheight = perevesti("0", True)
Окно10НадписьПроцент0.Props.Maximumwidth = perevesti("0", True)
Окно10НадписьПроцент0.Props.Minimumheight = perevesti("0", True)
Окно10НадписьПроцент0.Props.Minimumwidth = perevesti("0", True)
Окно10НадписьПроцент0.Props.Index = perevesti("0", True)
Окно10НадписьПроцент0.Props.ToolTip = perevesti("", True)
Окно10НадписьПроцент0.Props.Paddingtop = perevesti("0", True)
Окно10НадписьПроцент0.Props.Paddingleft = perevesti("0", True)
Окно10НадписьПроцент0.Props.Paddingbottom = perevesti("0", True)
Окно10НадписьПроцент0.Props.Paddingright = perevesti("0", True)
Окно10НадписьПроцент0.Props.Imagealign = perevesti("Центр", True)
Окно10НадписьПроцент0.Props.Textalign = perevesti("центр", True)
Окно10НадписьПроцент0.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10НадписьПроцент0.Props.Enabled = perevesti("Да", True)
Окно10НадписьПроцент0.Props.Dock = perevesti("Никакой", True)
Окно10НадписьПроцент0.Props.Image = perevesti("Никакой", True)
Окно10НадписьПроцент0.Props.Borderstyle = perevesti("Никакой", True)
Окно10НадписьПроцент0.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10НадписьПроцент0.Props.Tabindex = perevesti("0", True)
Окно10НадписьПроцент0.Props.Tabstop = perevesti("Да", True)
Окно10НадписьПроцент0.Props.Backgroundimage = perevesti("Никакой", True)
Окно10НадписьПроцент0.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10НадписьПроцент0.Props.Forecolor = perevesti("Черный", True)
Окно10НадписьПроцент0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10НадписьПроцент0.Props.Fontbold = perevesti("Нет", True)
Окно10НадписьПроцент0.Props.Fontstrikeout = perevesti("Нет", True)
Окно10НадписьПроцент0.Props.Fontitalic = perevesti("Нет", True)
Окно10НадписьПроцент0.Props.Fontunderline = perevesti("Нет", True)
Окно10НадписьПроцент0.Props.Fontsize = perevesti("8", True)
Окно10НадписьПроцент0.Props.Height = perevesti("31", True)
Окно10НадписьПроцент0.Props.Width = perevesti("59", True)
Окно10НадписьПроцент0.Props.Visible = perevesti("Да", True)
Окно10НадписьПроцент0.Props.Height = perevesti("31", True)
Окно10НадписьПроцент0.Props.Width = perevesti("59", True)

ProgressForm.ProgressBar1.Value = 77
Окно10Рисунок10.Props.X = perevesti("24", True)
Окно10Рисунок10.Props.Y = perevesti("56", True)
Окно10Рисунок10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Рисунок10.Props.Tag = perevesti("", True)
Окно10Рисунок10.Props.Name = perevesti("Рисунок1", True)
Окно10Рисунок10.Props.Cursor = perevesti("Обычный", True)
Окно10Рисунок10.Props.Maximumheight = perevesti("0", True)
Окно10Рисунок10.Props.Maximumwidth = perevesti("0", True)
Окно10Рисунок10.Props.Minimumheight = perevesti("0", True)
Окно10Рисунок10.Props.Minimumwidth = perevesti("0", True)
Окно10Рисунок10.Props.Index = perevesti("0", True)
Окно10Рисунок10.Props.ToolTip = perevesti("", True)
Окно10Рисунок10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Рисунок10.Props.Enabled = perevesti("Да", True)
Окно10Рисунок10.Props.Dock = perevesti("Никакой", True)
Окно10Рисунок10.Props.Image = perevesti("Рисунки\Рисунок8.png", True)
Окно10Рисунок10.Props.Borderstyle = perevesti("Никакой", True)
Окно10Рисунок10.Props.Sizemode = perevesti("по умолчанию", True)
Окно10Рисунок10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Рисунок10.Props.Tabindex = perevesti("0", True)
Окно10Рисунок10.Props.Tabstop = perevesti("Да", True)
Окно10Рисунок10.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Рисунок10.Props.Backcolor = perevesti("172; 172; 172;", True)
Окно10Рисунок10.Props.Height = perevesti("267", True)
Окно10Рисунок10.Props.Width = perevesti("359", True)
Окно10Рисунок10.Props.Visible = perevesti("Да", True)
Окно10Рисунок10.Props.Height = perevesti("267", True)
Окно10Рисунок10.Props.Width = perevesti("359", True)

ProgressForm.ProgressBar1.Value = 79
_Полезные_объекты0_Полезные_объекты0.Props.Name = "_Полезные объекты"

ProgressForm.ProgressBar1.Value = 81
_Полезные_объекты0_Экран0.Props.Name = "_Экран"

ProgressForm.ProgressBar1.Value = 83
_Полезные_объекты0_Файлы_и_папки0.Props.Name = "_Файлы и папки"

ProgressForm.ProgressBar1.Value = 85
_Полезные_объекты0_Прерывания0.Props.Name = "_Прерывания"

ProgressForm.ProgressBar1.Value = 87
_Полезные_объекты0_Система0.Props.Name = "_Система"

ProgressForm.ProgressBar1.Value = 89
_Полезные_объекты0_Реестр0.Props.Name = "_Реестр"

ProgressForm.ProgressBar1.Value = 91
_Полезные_объекты0_Вызвать_событие0.Props.Name = "_Вызвать событие"

ProgressForm.ProgressBar1.Value = 92
_Полезные_объекты0_Текст0.Props.Name = "_Текст"

ProgressForm.ProgressBar1.Value = 94
_Полезные_объекты0_Показать_сообщение0.Props.Name = "_Показать сообщение"

ProgressForm.ProgressBar1.Value = 96
_Полезные_объекты0_Дата0.Props.Name = "_Дата"

ProgressForm.ProgressBar1.Value = 98
_Полезные_объекты0_Расширенные_возможности0.Props.Name = "_Расширенные возможности"


' Окончательная загрузка
Окно10Окно10.load()
Окно10Закладки10.load()
Окно10Окно_сохранения10.load()
Окно10Интернет10.load()
Окно10Надпись10.load()
Окно10Надпись20.load()
Окно10Панель_10.load()
Окно10Надпись30.load()
Окно10Надпись40.load()
Окно10Надпись50.load()
Окно10Закладки1_Закладка10.load()
Окно10Закладки1_Закладка20.load()
Окно10КнопкаСкачать0.load()
Окно10КнопкаОтменить0.load()
Окно10КнопкаПауза0.load()
Окно10Полоса_загрузки10.load()
Окно10НадписьПроцент0.load()
Окно10Рисунок10.load()

RunProj.GetAllObjects()
RunProj.isINITIALIZATED = False

Окно10Закладки10.RaiseCreate()
Окно10Окно_сохранения10.RaiseCreate()
Окно10Интернет10.RaiseCreate()
Окно10Надпись10.RaiseCreate()
Окно10Надпись20.RaiseCreate()
Окно10Панель_10.RaiseCreate()
Окно10Надпись30.RaiseCreate()
Окно10Надпись40.RaiseCreate()
Окно10Надпись50.RaiseCreate()
Окно10Закладки1_Закладка10.RaiseCreate()
Окно10Закладки1_Закладка20.RaiseCreate()
Окно10КнопкаСкачать0.RaiseCreate()
Окно10КнопкаОтменить0.RaiseCreate()
Окно10КнопкаПауза0.RaiseCreate()
Окно10Полоса_загрузки10.RaiseCreate()
Окно10НадписьПроцент0.RaiseCreate()
Окно10Рисунок10.RaiseCreate()
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
Public Sub Окно10Интернет10_Receivedresponse(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Интернет10.Receivedresponse
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10Интернет10.MyObj, e, nothing,"Пришел ответ")

RunProj.GetObjFromUniqName("_Полезные объекты._Файлы и папки").Props.Move ( RunProj.GetObjFromUniqName ( "Окно1.Интернет1" ) .Props.Resultquery , RunProj.GetObjFromUniqName ( "Окно1.Окно сохранения1" ) .Props.Filename ) 
RunProj.GetObjFromUniqName("_Полезные объекты._Файлы и папки").Props.Opendirectory ( RunProj.GetObjFromUniqName ( "Окно1.Окно сохранения1" ) .Props.Filename ) 
CurrentEvent.Zavershit()
End Sub


Public Sub Окно10Интернет10_Receiveprogress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs) Handles Окно10Интернет10.Receiveprogress
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10Интернет10.MyObj, e, nothing,"Идет прием данных")

RunProj.GetObjFromUniqName("Окно1.НадписьПроцент").Props.Text = CurrentEvent.ParamyUp(MyZnak & "ПРОЦЕНТ ПОЛУЧЕННОГО") & "%"
RunProj.GetObjFromUniqName("Окно1.Полоса загрузки1").Props.Value = CurrentEvent.ParamyUp(MyZnak & "ПРОЦЕНТ ПОЛУЧЕННОГО")
CurrentEvent.Zavershit()
End Sub


Public Sub Окно10Интернет10_Downloadcancelled(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Интернет10.Downloadcancelled
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10Интернет10.MyObj, e, nothing,"Загрузка отменена")

RunProj.GetObjFromUniqName("Окно1.НадписьПроцент").Props.Text = "0%"
RunProj.GetObjFromUniqName("Окно1.Полоса загрузки1").Props.Value = "0"
CurrentEvent.Zavershit()
End Sub


Public Sub Окно10КнопкаСкачать0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10КнопкаСкачать0.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10КнопкаСкачать0.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно1.Интернет1").Props.Downloadfile ( "http://algoritm2.ru/download.php?d=2547" , "Нет" ) 
RunProj.GetObjFromUniqName("Окно1.Окно сохранения1").Props.Filename = RunProj.GetObjFromUniqName("_Полезные объекты._Файлы и папки").Props.Getfilename ( RunProj.GetObjFromUniqName ( "Окно1.Интернет1" ) .Props.Urltogo ) 
RunProj.GetObjFromUniqName("Окно1.Окно сохранения1").Props.Showdialog
If returnBoolean( UCase( RunProj.GetObjFromUniqName("Окно1.Окно сохранения1" ).Props.Wascancel )  =  UCase( "Да" )  ) Then
Окно10КнопкаОтменить0_Click(Окно10КнопкаОтменить0, nothing)

End If
CurrentEvent.Zavershit()
End Sub


Public Sub Окно10КнопкаОтменить0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10КнопкаОтменить0.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10КнопкаОтменить0.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно1.Интернет1").Props.Downloadcancel
CurrentEvent.Zavershit()
End Sub


Public Sub Окно10КнопкаПауза0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10КнопкаПауза0.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10КнопкаПауза0.MyObj, e, nothing,"Клик")

If returnBoolean( UCase( RunProj.GetObjFromUniqName("Окно1.КнопкаПауза" ).Props.Text )  =  UCase( "Пауза" )  ) Then
RunProj.GetObjFromUniqName("Окно1.Интернет1").Props.Downloadpause = "Да"
RunProj.GetObjFromUniqName("Окно1.КнопкаПауза").Props.Text = "Возобновить"
Else
RunProj.GetObjFromUniqName("Окно1.Интернет1").Props.Downloadpause = "Нет"
RunProj.GetObjFromUniqName("Окно1.КнопкаПауза").Props.Text = "Пауза"
End If
CurrentEvent.Zavershit()
End Sub



End Module



