Module CodeAlg

Public WithEvents Окно10Окно10 As New runF
Public WithEvents Окно10Надпись72 As New runLb
Public WithEvents Окно10Панель_10 As New runP
Public WithEvents Окно10Текст10 As New runT
Public WithEvents Окно10Текст20 As New runT
Public WithEvents Окно10Текст30 As New runT
Public WithEvents Окно10Текст40 As New runT
Public WithEvents Окно10Текст50 As New runT
Public WithEvents Окно10Текст60 As New runT
Public WithEvents Окно10Кнопка10 As New runB
Public WithEvents Окно10Надпись73 As New runLb
Public WithEvents Окно10Надпись74 As New runLb
Public WithEvents Окно10Надпись75 As New runLb
Public WithEvents Окно10Надпись76 As New runLb
Public WithEvents Окно10Надпись77 As New runLb
Public WithEvents Окно10Текст70 As New runT
Public WithEvents Окно10Надпись71 As New runLb
Public WithEvents Окно10Кнопка20 As New runB
Public WithEvents Окно10Кнопка30 As New runB
Public WithEvents Окно10Окно_открытия10 As New runOD
Public WithEvents Окно20Окно20 As New runF
Public WithEvents Окно20Рисунок10 As New runPb
Public WithEvents Окно20Кнопка10 As New runB
Public WithEvents Окно20Кнопка20 As New runB
Public WithEvents Окно20Текст10 As New runT
Public WithEvents Окно20Окно_открытия10 As New runOD
Public WithEvents Окно30Окно30 As New runF
Public WithEvents Окно30Текстовый_документ10 As New runRT
Public WithEvents Окно30Кнопка10 As New runB
Public WithEvents Окно30Кнопка20 As New runB
Public WithEvents Окно30Текст10 As New runT
Public WithEvents Окно30Окно_открытия10 As New runOD
Public WithEvents Окно30Кнопка30 As New runB
Public WithEvents Окно40Окно40 As New runF
Public WithEvents Окно40Текстовый_документ10 As New runRT
Public WithEvents Окно40Кнопка10 As New runB
Public WithEvents Окно40Кнопка20 As New runB
Public WithEvents Окно40Память10 As New runM
Public WithEvents Окно40Память20 As New runM
Public WithEvents Окно40Память30 As New runM
Public WithEvents Окно40Окно_сохранения10 As New runSD
Public WithEvents Окно40Надпись10 As New runLb
Public WithEvents Окно50Окно50 As New runF
Public WithEvents Окно50Текстовый_документ10 As New runRT
Public WithEvents Окно50Кнопка10 As New runB
Public WithEvents Окно50Окно_сохранения10 As New runSD
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
RunProj.iPathShort = "image"
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

Окно10Надпись72.MyObj = New Label(True, True)
Окно10Надпись72.MyObj.proj = proj
Окно10Надпись72.MyObj.obj = Окно10Надпись72
Окно10Надпись72.MyObj.VBname = "Окно10Надпись72"
Окно10Надпись72.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись72.MyObj.MyForm.MyObjs) : Окно10Надпись72.MyObj.MyForm.MyObjs(Окно10Надпись72.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись72.MyObj

Окно10Панель_10.MyObj = New Panel(True, True)
Окно10Панель_10.MyObj.proj = proj
Окно10Панель_10.MyObj.obj = Окно10Панель_10
Окно10Панель_10.MyObj.VBname = "Окно10Панель_10"
Окно10Панель_10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Панель_10.MyObj.MyForm.MyObjs) : Окно10Панель_10.MyObj.MyForm.MyObjs(Окно10Панель_10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Панель_10.MyObj

Окно10Текст10.MyObj = New TextBoks(True, True)
Окно10Текст10.MyObj.proj = proj
Окно10Текст10.MyObj.obj = Окно10Текст10
Окно10Текст10.MyObj.VBname = "Окно10Текст10"
Окно10Текст10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Текст10.MyObj.MyForm.MyObjs) : Окно10Текст10.MyObj.MyForm.MyObjs(Окно10Текст10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст10.MyObj

Окно10Текст20.MyObj = New TextBoks(True, True)
Окно10Текст20.MyObj.proj = proj
Окно10Текст20.MyObj.obj = Окно10Текст20
Окно10Текст20.MyObj.VBname = "Окно10Текст20"
Окно10Текст20.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Текст20.MyObj.MyForm.MyObjs) : Окно10Текст20.MyObj.MyForm.MyObjs(Окно10Текст20.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст20.MyObj

ProgressForm.ProgressBar1.Value = 2
Окно10Текст30.MyObj = New TextBoks(True, True)
Окно10Текст30.MyObj.proj = proj
Окно10Текст30.MyObj.obj = Окно10Текст30
Окно10Текст30.MyObj.VBname = "Окно10Текст30"
Окно10Текст30.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Текст30.MyObj.MyForm.MyObjs) : Окно10Текст30.MyObj.MyForm.MyObjs(Окно10Текст30.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст30.MyObj

Окно10Текст40.MyObj = New TextBoks(True, True)
Окно10Текст40.MyObj.proj = proj
Окно10Текст40.MyObj.obj = Окно10Текст40
Окно10Текст40.MyObj.VBname = "Окно10Текст40"
Окно10Текст40.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Текст40.MyObj.MyForm.MyObjs) : Окно10Текст40.MyObj.MyForm.MyObjs(Окно10Текст40.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст40.MyObj

Окно10Текст50.MyObj = New TextBoks(True, True)
Окно10Текст50.MyObj.proj = proj
Окно10Текст50.MyObj.obj = Окно10Текст50
Окно10Текст50.MyObj.VBname = "Окно10Текст50"
Окно10Текст50.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Текст50.MyObj.MyForm.MyObjs) : Окно10Текст50.MyObj.MyForm.MyObjs(Окно10Текст50.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст50.MyObj

Окно10Текст60.MyObj = New TextBoks(True, True)
Окно10Текст60.MyObj.proj = proj
Окно10Текст60.MyObj.obj = Окно10Текст60
Окно10Текст60.MyObj.VBname = "Окно10Текст60"
Окно10Текст60.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Текст60.MyObj.MyForm.MyObjs) : Окно10Текст60.MyObj.MyForm.MyObjs(Окно10Текст60.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст60.MyObj

Окно10Кнопка10.MyObj = New Button(True, True)
Окно10Кнопка10.MyObj.proj = proj
Окно10Кнопка10.MyObj.obj = Окно10Кнопка10
Окно10Кнопка10.MyObj.VBname = "Окно10Кнопка10"
Окно10Кнопка10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Кнопка10.MyObj.MyForm.MyObjs) : Окно10Кнопка10.MyObj.MyForm.MyObjs(Окно10Кнопка10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Кнопка10.MyObj

ProgressForm.ProgressBar1.Value = 4
Окно10Надпись73.MyObj = New Label(True, True)
Окно10Надпись73.MyObj.proj = proj
Окно10Надпись73.MyObj.obj = Окно10Надпись73
Окно10Надпись73.MyObj.VBname = "Окно10Надпись73"
Окно10Надпись73.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись73.MyObj.MyForm.MyObjs) : Окно10Надпись73.MyObj.MyForm.MyObjs(Окно10Надпись73.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись73.MyObj

Окно10Надпись74.MyObj = New Label(True, True)
Окно10Надпись74.MyObj.proj = proj
Окно10Надпись74.MyObj.obj = Окно10Надпись74
Окно10Надпись74.MyObj.VBname = "Окно10Надпись74"
Окно10Надпись74.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись74.MyObj.MyForm.MyObjs) : Окно10Надпись74.MyObj.MyForm.MyObjs(Окно10Надпись74.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись74.MyObj

Окно10Надпись75.MyObj = New Label(True, True)
Окно10Надпись75.MyObj.proj = proj
Окно10Надпись75.MyObj.obj = Окно10Надпись75
Окно10Надпись75.MyObj.VBname = "Окно10Надпись75"
Окно10Надпись75.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись75.MyObj.MyForm.MyObjs) : Окно10Надпись75.MyObj.MyForm.MyObjs(Окно10Надпись75.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись75.MyObj

Окно10Надпись76.MyObj = New Label(True, True)
Окно10Надпись76.MyObj.proj = proj
Окно10Надпись76.MyObj.obj = Окно10Надпись76
Окно10Надпись76.MyObj.VBname = "Окно10Надпись76"
Окно10Надпись76.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись76.MyObj.MyForm.MyObjs) : Окно10Надпись76.MyObj.MyForm.MyObjs(Окно10Надпись76.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись76.MyObj

Окно10Надпись77.MyObj = New Label(True, True)
Окно10Надпись77.MyObj.proj = proj
Окно10Надпись77.MyObj.obj = Окно10Надпись77
Окно10Надпись77.MyObj.VBname = "Окно10Надпись77"
Окно10Надпись77.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись77.MyObj.MyForm.MyObjs) : Окно10Надпись77.MyObj.MyForm.MyObjs(Окно10Надпись77.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись77.MyObj

ProgressForm.ProgressBar1.Value = 7
Окно10Текст70.MyObj = New TextBoks(True, True)
Окно10Текст70.MyObj.proj = proj
Окно10Текст70.MyObj.obj = Окно10Текст70
Окно10Текст70.MyObj.VBname = "Окно10Текст70"
Окно10Текст70.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Текст70.MyObj.MyForm.MyObjs) : Окно10Текст70.MyObj.MyForm.MyObjs(Окно10Текст70.MyObj.MyForm.MyObjs.Length - 1) = Окно10Текст70.MyObj

Окно10Надпись71.MyObj = New Label(True, True)
Окно10Надпись71.MyObj.proj = proj
Окно10Надпись71.MyObj.obj = Окно10Надпись71
Окно10Надпись71.MyObj.VBname = "Окно10Надпись71"
Окно10Надпись71.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Надпись71.MyObj.MyForm.MyObjs) : Окно10Надпись71.MyObj.MyForm.MyObjs(Окно10Надпись71.MyObj.MyForm.MyObjs.Length - 1) = Окно10Надпись71.MyObj

Окно10Кнопка20.MyObj = New Button(True, True)
Окно10Кнопка20.MyObj.proj = proj
Окно10Кнопка20.MyObj.obj = Окно10Кнопка20
Окно10Кнопка20.MyObj.VBname = "Окно10Кнопка20"
Окно10Кнопка20.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Кнопка20.MyObj.MyForm.MyObjs) : Окно10Кнопка20.MyObj.MyForm.MyObjs(Окно10Кнопка20.MyObj.MyForm.MyObjs.Length - 1) = Окно10Кнопка20.MyObj

Окно10Кнопка30.MyObj = New Button(True, True)
Окно10Кнопка30.MyObj.proj = proj
Окно10Кнопка30.MyObj.obj = Окно10Кнопка30
Окно10Кнопка30.MyObj.VBname = "Окно10Кнопка30"
Окно10Кнопка30.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Кнопка30.MyObj.MyForm.MyObjs) : Окно10Кнопка30.MyObj.MyForm.MyObjs(Окно10Кнопка30.MyObj.MyForm.MyObjs.Length - 1) = Окно10Кнопка30.MyObj

Окно10Окно_открытия10.MyObj = New OpenDialog(True, True)
Окно10Окно_открытия10.MyObj.proj = proj
Окно10Окно_открытия10.MyObj.obj = Окно10Окно_открытия10
Окно10Окно_открытия10.MyObj.VBname = "Окно10Окно_открытия10"
Окно10Окно_открытия10.MyObj.MyObj.MyForm = Окно10Окно10.MyObj
ReDimsO(Окно10Окно_открытия10.MyObj.MyForm.MyObjs) : Окно10Окно_открытия10.MyObj.MyForm.MyObjs(Окно10Окно_открытия10.MyObj.MyForm.MyObjs.Length - 1) = Окно10Окно_открытия10.MyObj

ProgressForm.ProgressBar1.Value = 9
Окно20Окно20.MyObj = New Forms(True, , True)
Окно20Окно20.MyObj.proj = proj
Окно20Окно20.MyObj.obj = Окно20Окно20
Окно20Окно20.MyObj.VBname = "Окно20Окно20"
Окно20Окно20.MyObj.MyObj.MyForm = Окно20Окно20.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = Окно20Окно20.MyObj
ReDimsO(Окно20Окно20.MyObj.MyForm.MyObjs) : Окно20Окно20.MyObj.MyForm.MyObjs(Окно20Окно20.MyObj.MyForm.MyObjs.Length - 1) = Окно20Окно20.MyObj

Окно20Рисунок10.MyObj = New PictureBoks(True, True)
Окно20Рисунок10.MyObj.proj = proj
Окно20Рисунок10.MyObj.obj = Окно20Рисунок10
Окно20Рисунок10.MyObj.VBname = "Окно20Рисунок10"
Окно20Рисунок10.MyObj.MyObj.MyForm = Окно20Окно20.MyObj
ReDimsO(Окно20Рисунок10.MyObj.MyForm.MyObjs) : Окно20Рисунок10.MyObj.MyForm.MyObjs(Окно20Рисунок10.MyObj.MyForm.MyObjs.Length - 1) = Окно20Рисунок10.MyObj

Окно20Кнопка10.MyObj = New Button(True, True)
Окно20Кнопка10.MyObj.proj = proj
Окно20Кнопка10.MyObj.obj = Окно20Кнопка10
Окно20Кнопка10.MyObj.VBname = "Окно20Кнопка10"
Окно20Кнопка10.MyObj.MyObj.MyForm = Окно20Окно20.MyObj
ReDimsO(Окно20Кнопка10.MyObj.MyForm.MyObjs) : Окно20Кнопка10.MyObj.MyForm.MyObjs(Окно20Кнопка10.MyObj.MyForm.MyObjs.Length - 1) = Окно20Кнопка10.MyObj

Окно20Кнопка20.MyObj = New Button(True, True)
Окно20Кнопка20.MyObj.proj = proj
Окно20Кнопка20.MyObj.obj = Окно20Кнопка20
Окно20Кнопка20.MyObj.VBname = "Окно20Кнопка20"
Окно20Кнопка20.MyObj.MyObj.MyForm = Окно20Окно20.MyObj
ReDimsO(Окно20Кнопка20.MyObj.MyForm.MyObjs) : Окно20Кнопка20.MyObj.MyForm.MyObjs(Окно20Кнопка20.MyObj.MyForm.MyObjs.Length - 1) = Окно20Кнопка20.MyObj

Окно20Текст10.MyObj = New TextBoks(True, True)
Окно20Текст10.MyObj.proj = proj
Окно20Текст10.MyObj.obj = Окно20Текст10
Окно20Текст10.MyObj.VBname = "Окно20Текст10"
Окно20Текст10.MyObj.MyObj.MyForm = Окно20Окно20.MyObj
ReDimsO(Окно20Текст10.MyObj.MyForm.MyObjs) : Окно20Текст10.MyObj.MyForm.MyObjs(Окно20Текст10.MyObj.MyForm.MyObjs.Length - 1) = Окно20Текст10.MyObj

ProgressForm.ProgressBar1.Value = 11
Окно20Окно_открытия10.MyObj = New OpenDialog(True, True)
Окно20Окно_открытия10.MyObj.proj = proj
Окно20Окно_открытия10.MyObj.obj = Окно20Окно_открытия10
Окно20Окно_открытия10.MyObj.VBname = "Окно20Окно_открытия10"
Окно20Окно_открытия10.MyObj.MyObj.MyForm = Окно20Окно20.MyObj
ReDimsO(Окно20Окно_открытия10.MyObj.MyForm.MyObjs) : Окно20Окно_открытия10.MyObj.MyForm.MyObjs(Окно20Окно_открытия10.MyObj.MyForm.MyObjs.Length - 1) = Окно20Окно_открытия10.MyObj

Окно30Окно30.MyObj = New Forms(True, , True)
Окно30Окно30.MyObj.proj = proj
Окно30Окно30.MyObj.obj = Окно30Окно30
Окно30Окно30.MyObj.VBname = "Окно30Окно30"
Окно30Окно30.MyObj.MyObj.MyForm = Окно30Окно30.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = Окно30Окно30.MyObj
ReDimsO(Окно30Окно30.MyObj.MyForm.MyObjs) : Окно30Окно30.MyObj.MyForm.MyObjs(Окно30Окно30.MyObj.MyForm.MyObjs.Length - 1) = Окно30Окно30.MyObj

Окно30Текстовый_документ10.MyObj = New RichText(True, True)
Окно30Текстовый_документ10.MyObj.proj = proj
Окно30Текстовый_документ10.MyObj.obj = Окно30Текстовый_документ10
Окно30Текстовый_документ10.MyObj.VBname = "Окно30Текстовый_документ10"
Окно30Текстовый_документ10.MyObj.MyObj.MyForm = Окно30Окно30.MyObj
ReDimsO(Окно30Текстовый_документ10.MyObj.MyForm.MyObjs) : Окно30Текстовый_документ10.MyObj.MyForm.MyObjs(Окно30Текстовый_документ10.MyObj.MyForm.MyObjs.Length - 1) = Окно30Текстовый_документ10.MyObj

Окно30Кнопка10.MyObj = New Button(True, True)
Окно30Кнопка10.MyObj.proj = proj
Окно30Кнопка10.MyObj.obj = Окно30Кнопка10
Окно30Кнопка10.MyObj.VBname = "Окно30Кнопка10"
Окно30Кнопка10.MyObj.MyObj.MyForm = Окно30Окно30.MyObj
ReDimsO(Окно30Кнопка10.MyObj.MyForm.MyObjs) : Окно30Кнопка10.MyObj.MyForm.MyObjs(Окно30Кнопка10.MyObj.MyForm.MyObjs.Length - 1) = Окно30Кнопка10.MyObj

Окно30Кнопка20.MyObj = New Button(True, True)
Окно30Кнопка20.MyObj.proj = proj
Окно30Кнопка20.MyObj.obj = Окно30Кнопка20
Окно30Кнопка20.MyObj.VBname = "Окно30Кнопка20"
Окно30Кнопка20.MyObj.MyObj.MyForm = Окно30Окно30.MyObj
ReDimsO(Окно30Кнопка20.MyObj.MyForm.MyObjs) : Окно30Кнопка20.MyObj.MyForm.MyObjs(Окно30Кнопка20.MyObj.MyForm.MyObjs.Length - 1) = Окно30Кнопка20.MyObj

ProgressForm.ProgressBar1.Value = 13
Окно30Текст10.MyObj = New TextBoks(True, True)
Окно30Текст10.MyObj.proj = proj
Окно30Текст10.MyObj.obj = Окно30Текст10
Окно30Текст10.MyObj.VBname = "Окно30Текст10"
Окно30Текст10.MyObj.MyObj.MyForm = Окно30Окно30.MyObj
ReDimsO(Окно30Текст10.MyObj.MyForm.MyObjs) : Окно30Текст10.MyObj.MyForm.MyObjs(Окно30Текст10.MyObj.MyForm.MyObjs.Length - 1) = Окно30Текст10.MyObj

Окно30Окно_открытия10.MyObj = New OpenDialog(True, True)
Окно30Окно_открытия10.MyObj.proj = proj
Окно30Окно_открытия10.MyObj.obj = Окно30Окно_открытия10
Окно30Окно_открытия10.MyObj.VBname = "Окно30Окно_открытия10"
Окно30Окно_открытия10.MyObj.MyObj.MyForm = Окно30Окно30.MyObj
ReDimsO(Окно30Окно_открытия10.MyObj.MyForm.MyObjs) : Окно30Окно_открытия10.MyObj.MyForm.MyObjs(Окно30Окно_открытия10.MyObj.MyForm.MyObjs.Length - 1) = Окно30Окно_открытия10.MyObj

Окно30Кнопка30.MyObj = New Button(True, True)
Окно30Кнопка30.MyObj.proj = proj
Окно30Кнопка30.MyObj.obj = Окно30Кнопка30
Окно30Кнопка30.MyObj.VBname = "Окно30Кнопка30"
Окно30Кнопка30.MyObj.MyObj.MyForm = Окно30Окно30.MyObj
ReDimsO(Окно30Кнопка30.MyObj.MyForm.MyObjs) : Окно30Кнопка30.MyObj.MyForm.MyObjs(Окно30Кнопка30.MyObj.MyForm.MyObjs.Length - 1) = Окно30Кнопка30.MyObj

Окно40Окно40.MyObj = New Forms(True, , True)
Окно40Окно40.MyObj.proj = proj
Окно40Окно40.MyObj.obj = Окно40Окно40
Окно40Окно40.MyObj.VBname = "Окно40Окно40"
Окно40Окно40.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = Окно40Окно40.MyObj
ReDimsO(Окно40Окно40.MyObj.MyForm.MyObjs) : Окно40Окно40.MyObj.MyForm.MyObjs(Окно40Окно40.MyObj.MyForm.MyObjs.Length - 1) = Окно40Окно40.MyObj

Окно40Текстовый_документ10.MyObj = New RichText(True, True)
Окно40Текстовый_документ10.MyObj.proj = proj
Окно40Текстовый_документ10.MyObj.obj = Окно40Текстовый_документ10
Окно40Текстовый_документ10.MyObj.VBname = "Окно40Текстовый_документ10"
Окно40Текстовый_документ10.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDimsO(Окно40Текстовый_документ10.MyObj.MyForm.MyObjs) : Окно40Текстовый_документ10.MyObj.MyForm.MyObjs(Окно40Текстовый_документ10.MyObj.MyForm.MyObjs.Length - 1) = Окно40Текстовый_документ10.MyObj

ProgressForm.ProgressBar1.Value = 15
Окно40Кнопка10.MyObj = New Button(True, True)
Окно40Кнопка10.MyObj.proj = proj
Окно40Кнопка10.MyObj.obj = Окно40Кнопка10
Окно40Кнопка10.MyObj.VBname = "Окно40Кнопка10"
Окно40Кнопка10.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDimsO(Окно40Кнопка10.MyObj.MyForm.MyObjs) : Окно40Кнопка10.MyObj.MyForm.MyObjs(Окно40Кнопка10.MyObj.MyForm.MyObjs.Length - 1) = Окно40Кнопка10.MyObj

Окно40Кнопка20.MyObj = New Button(True, True)
Окно40Кнопка20.MyObj.proj = proj
Окно40Кнопка20.MyObj.obj = Окно40Кнопка20
Окно40Кнопка20.MyObj.VBname = "Окно40Кнопка20"
Окно40Кнопка20.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDimsO(Окно40Кнопка20.MyObj.MyForm.MyObjs) : Окно40Кнопка20.MyObj.MyForm.MyObjs(Окно40Кнопка20.MyObj.MyForm.MyObjs.Length - 1) = Окно40Кнопка20.MyObj

Окно40Память10.MyObj = New Memory(True, True)
Окно40Память10.MyObj.proj = proj
Окно40Память10.MyObj.obj = Окно40Память10
Окно40Память10.MyObj.VBname = "Окно40Память10"
Окно40Память10.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDimsO(Окно40Память10.MyObj.MyForm.MyObjs) : Окно40Память10.MyObj.MyForm.MyObjs(Окно40Память10.MyObj.MyForm.MyObjs.Length - 1) = Окно40Память10.MyObj

Окно40Память20.MyObj = New Memory(True, True)
Окно40Память20.MyObj.proj = proj
Окно40Память20.MyObj.obj = Окно40Память20
Окно40Память20.MyObj.VBname = "Окно40Память20"
Окно40Память20.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDimsO(Окно40Память20.MyObj.MyForm.MyObjs) : Окно40Память20.MyObj.MyForm.MyObjs(Окно40Память20.MyObj.MyForm.MyObjs.Length - 1) = Окно40Память20.MyObj

Окно40Память30.MyObj = New Memory(True, True)
Окно40Память30.MyObj.proj = proj
Окно40Память30.MyObj.obj = Окно40Память30
Окно40Память30.MyObj.VBname = "Окно40Память30"
Окно40Память30.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDimsO(Окно40Память30.MyObj.MyForm.MyObjs) : Окно40Память30.MyObj.MyForm.MyObjs(Окно40Память30.MyObj.MyForm.MyObjs.Length - 1) = Окно40Память30.MyObj

ProgressForm.ProgressBar1.Value = 18
Окно40Окно_сохранения10.MyObj = New SaveDialog(True, True)
Окно40Окно_сохранения10.MyObj.proj = proj
Окно40Окно_сохранения10.MyObj.obj = Окно40Окно_сохранения10
Окно40Окно_сохранения10.MyObj.VBname = "Окно40Окно_сохранения10"
Окно40Окно_сохранения10.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDimsO(Окно40Окно_сохранения10.MyObj.MyForm.MyObjs) : Окно40Окно_сохранения10.MyObj.MyForm.MyObjs(Окно40Окно_сохранения10.MyObj.MyForm.MyObjs.Length - 1) = Окно40Окно_сохранения10.MyObj

Окно40Надпись10.MyObj = New Label(True, True)
Окно40Надпись10.MyObj.proj = proj
Окно40Надпись10.MyObj.obj = Окно40Надпись10
Окно40Надпись10.MyObj.VBname = "Окно40Надпись10"
Окно40Надпись10.MyObj.MyObj.MyForm = Окно40Окно40.MyObj
ReDimsO(Окно40Надпись10.MyObj.MyForm.MyObjs) : Окно40Надпись10.MyObj.MyForm.MyObjs(Окно40Надпись10.MyObj.MyForm.MyObjs.Length - 1) = Окно40Надпись10.MyObj

Окно50Окно50.MyObj = New Forms(True, , True)
Окно50Окно50.MyObj.proj = proj
Окно50Окно50.MyObj.obj = Окно50Окно50
Окно50Окно50.MyObj.VBname = "Окно50Окно50"
Окно50Окно50.MyObj.MyObj.MyForm = Окно50Окно50.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = Окно50Окно50.MyObj
ReDimsO(Окно50Окно50.MyObj.MyForm.MyObjs) : Окно50Окно50.MyObj.MyForm.MyObjs(Окно50Окно50.MyObj.MyForm.MyObjs.Length - 1) = Окно50Окно50.MyObj

Окно50Текстовый_документ10.MyObj = New RichText(True, True)
Окно50Текстовый_документ10.MyObj.proj = proj
Окно50Текстовый_документ10.MyObj.obj = Окно50Текстовый_документ10
Окно50Текстовый_документ10.MyObj.VBname = "Окно50Текстовый_документ10"
Окно50Текстовый_документ10.MyObj.MyObj.MyForm = Окно50Окно50.MyObj
ReDimsO(Окно50Текстовый_документ10.MyObj.MyForm.MyObjs) : Окно50Текстовый_документ10.MyObj.MyForm.MyObjs(Окно50Текстовый_документ10.MyObj.MyForm.MyObjs.Length - 1) = Окно50Текстовый_документ10.MyObj

Окно50Кнопка10.MyObj = New Button(True, True)
Окно50Кнопка10.MyObj.proj = proj
Окно50Кнопка10.MyObj.obj = Окно50Кнопка10
Окно50Кнопка10.MyObj.VBname = "Окно50Кнопка10"
Окно50Кнопка10.MyObj.MyObj.MyForm = Окно50Окно50.MyObj
ReDimsO(Окно50Кнопка10.MyObj.MyForm.MyObjs) : Окно50Кнопка10.MyObj.MyForm.MyObjs(Окно50Кнопка10.MyObj.MyForm.MyObjs.Length - 1) = Окно50Кнопка10.MyObj

ProgressForm.ProgressBar1.Value = 20
Окно50Окно_сохранения10.MyObj = New SaveDialog(True, True)
Окно50Окно_сохранения10.MyObj.proj = proj
Окно50Окно_сохранения10.MyObj.obj = Окно50Окно_сохранения10
Окно50Окно_сохранения10.MyObj.VBname = "Окно50Окно_сохранения10"
Окно50Окно_сохранения10.MyObj.MyObj.MyForm = Окно50Окно50.MyObj
ReDimsO(Окно50Окно_сохранения10.MyObj.MyForm.MyObjs) : Окно50Окно_сохранения10.MyObj.MyForm.MyObjs(Окно50Окно_сохранения10.MyObj.MyForm.MyObjs.Length - 1) = Окно50Окно_сохранения10.MyObj

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

_Полезные_объекты0_Прерывания0.MyObj = New Poleznie("_Прерывания")
_Полезные_объекты0_Прерывания0.MyObj.proj = proj
_Полезные_объекты0_Прерывания0.MyObj.obj = _Полезные_объекты0_Прерывания0
_Полезные_объекты0_Прерывания0.MyObj.VBname = "_Полезные_объекты0_Прерывания0"
_Полезные_объекты0_Прерывания0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
ReDimsO(_Полезные_объекты0_Прерывания0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Прерывания0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Прерывания0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Прерывания0.MyObj

ProgressForm.ProgressBar1.Value = 22
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

_Полезные_объекты0_Показать_сообщение0.MyObj = New Poleznie("_Показать сообщение")
_Полезные_объекты0_Показать_сообщение0.MyObj.proj = proj
_Полезные_объекты0_Показать_сообщение0.MyObj.obj = _Полезные_объекты0_Показать_сообщение0
_Полезные_объекты0_Показать_сообщение0.MyObj.VBname = "_Полезные_объекты0_Показать_сообщение0"
_Полезные_объекты0_Показать_сообщение0.MyObj.MyObj.MyForm = _Полезные_объекты0_Полезные_объекты0.MyObj
ReDimsO(_Полезные_объекты0_Показать_сообщение0.MyObj.MyForm.MyObjs) : _Полезные_объекты0_Показать_сообщение0.MyObj.MyForm.MyObjs(_Полезные_объекты0_Показать_сообщение0.MyObj.MyForm.MyObjs.Length - 1) = _Полезные_объекты0_Показать_сообщение0.MyObj

ProgressForm.ProgressBar1.Value = 24
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
Окно10Окно10.Controls.Add(Окно10Надпись72)
Окно10Окно10.Controls.Add(Окно10Панель_10)
Окно10Окно10.Controls.Add(Окно10Текст10)
Окно10Панель_10.Controls.Add(Окно10Текст20)
ProgressForm.ProgressBar1.Value = 26
Окно10Панель_10.Controls.Add(Окно10Текст30)
Окно10Панель_10.Controls.Add(Окно10Текст40)
Окно10Панель_10.Controls.Add(Окно10Текст50)
Окно10Панель_10.Controls.Add(Окно10Текст60)
Окно10Окно10.Controls.Add(Окно10Кнопка10)
ProgressForm.ProgressBar1.Value = 27
Окно10Панель_10.Controls.Add(Окно10Надпись73)
Окно10Панель_10.Controls.Add(Окно10Надпись74)
Окно10Панель_10.Controls.Add(Окно10Надпись75)
Окно10Панель_10.Controls.Add(Окно10Надпись76)
Окно10Панель_10.Controls.Add(Окно10Надпись77)
ProgressForm.ProgressBar1.Value = 28
Окно10Окно10.Controls.Add(Окно10Текст70)
Окно10Окно10.Controls.Add(Окно10Надпись71)
Окно10Окно10.Controls.Add(Окно10Кнопка20)
Окно10Окно10.Controls.Add(Окно10Кнопка30)
ProgressForm.ProgressBar1.Value = 29
Окно20Окно20.Controls.Add(Окно20Рисунок10)
Окно20Окно20.Controls.Add(Окно20Кнопка10)
Окно20Окно20.Controls.Add(Окно20Кнопка20)
Окно20Окно20.Controls.Add(Окно20Текст10)
ProgressForm.ProgressBar1.Value = 29
Окно30Окно30.Controls.Add(Окно30Текстовый_документ10)
Окно30Окно30.Controls.Add(Окно30Кнопка10)
Окно30Окно30.Controls.Add(Окно30Кнопка20)
ProgressForm.ProgressBar1.Value = 30
Окно30Окно30.Controls.Add(Окно30Текст10)
Окно30Окно30.Controls.Add(Окно30Кнопка30)
Окно40Окно40.Controls.Add(Окно40Текстовый_документ10)
ProgressForm.ProgressBar1.Value = 31
Окно40Окно40.Controls.Add(Окно40Кнопка10)
Окно40Окно40.Controls.Add(Окно40Кнопка20)
ProgressForm.ProgressBar1.Value = 32
Окно40Окно40.Controls.Add(Окно40Надпись10)
Окно50Окно50.Controls.Add(Окно50Текстовый_документ10)
Окно50Окно50.Controls.Add(Окно50Кнопка10)
ProgressForm.ProgressBar1.Value = 33
ProgressForm.ProgressBar1.Value = 34
ProgressForm.ProgressBar1.Value = 35


' Уровнять по уровням объекты
ProgressForm.ProgressBar1.Value = 35
Окно10Панель_10.BringToFront()
Окно10Текст10.BringToFront()
Окно10Надпись72.BringToFront()
Окно10Надпись73.BringToFront()
Окно10Текст20.BringToFront()
Окно10Надпись74.BringToFront()
Окно10Текст30.BringToFront()
Окно10Надпись75.BringToFront()
Окно10Текст40.BringToFront()
Окно10Надпись76.BringToFront()
Окно10Текст50.BringToFront()
Окно10Надпись77.BringToFront()
Окно10Текст60.BringToFront()
Окно10Кнопка10.BringToFront()
Окно10Текст70.BringToFront()
Окно10Надпись71.BringToFront()
Окно10Кнопка20.BringToFront()
Окно10Кнопка30.BringToFront()
Окно10Окно_открытия10.BringToFront()
ProgressForm.ProgressBar1.Value = 36
ProgressForm.ProgressBar1.Value = 37
ProgressForm.ProgressBar1.Value = 38
ProgressForm.ProgressBar1.Value = 39
Окно20Рисунок10.BringToFront()
Окно20Кнопка10.BringToFront()
Окно20Кнопка20.BringToFront()
Окно20Текст10.BringToFront()
Окно20Окно_открытия10.BringToFront()
ProgressForm.ProgressBar1.Value = 39
Окно30Текстовый_документ10.BringToFront()
Окно30Кнопка10.BringToFront()
Окно30Кнопка20.BringToFront()
Окно30Текст10.BringToFront()
Окно30Окно_открытия10.BringToFront()
Окно30Кнопка30.BringToFront()
ProgressForm.ProgressBar1.Value = 40
Окно40Текстовый_документ10.BringToFront()
Окно40Кнопка10.BringToFront()
Окно40Кнопка20.BringToFront()
Окно40Память10.BringToFront()
Окно40Память20.BringToFront()
Окно40Память30.BringToFront()
Окно40Окно_сохранения10.BringToFront()
Окно40Надпись10.BringToFront()
ProgressForm.ProgressBar1.Value = 41
ProgressForm.ProgressBar1.Value = 42
Окно50Текстовый_документ10.BringToFront()
Окно50Кнопка10.BringToFront()
Окно50Окно_сохранения10.BringToFront()
ProgressForm.ProgressBar1.Value = 43
ProgressForm.ProgressBar1.Value = 44
ProgressForm.ProgressBar1.Value = 45


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
Окно10Окно10.Props.Showintray = perevesti("Нет", True)
Окно10Окно10.Props.TopMost = perevesti("Нет", True)
Окно10Окно10.Props.ToolTip = perevesti("", True)
Окно10Окно10.Props.Showicon = perevesti("Нет", True)
Окно10Окно10.Props.Opacity = perevesti("100", True)
Окно10Окно10.Props.Transparentcykey = perevesti("Никакой", True)
Окно10Окно10.Props.Scroll = perevesti("Нет", True)
Окно10Окно10.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно10Окно10.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно10Окно10.Props.AutoscrollpositionX = perevesti("0", True)
Окно10Окно10.Props.AutoscrollpositionY = perevesti("0", True)
Окно10Окно10.Props.Enabled = perevesti("Да", True)
Окно10Окно10.Props.Allowruncopies = perevesti("Да", True)
Окно10Окно10.Props.Startposition = perevesti("по центру экрана", True)
Окно10Окно10.StatusTemp = "Нормальный"
Окно10Окно10.Props.Formborderstyle = perevesti("фиксированное окно", True)
Окно10Окно10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Окно10.Props.Tabindex = perevesti("0", True)
Окно10Окно10.Props.Tabstop = perevesti("Да", True)
Окно10Окно10.Props.Text = perevesti("Иконки", True)
Окно10Окно10.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Окно10.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Окно10.Props.Forecolor = perevesti("Черный", True)
Окно10Окно10.Props.Height = perevesti("367", True)
Окно10Окно10.Props.Width = perevesti("503", True)
Окно10Окно10.Props.Visible = perevesti("Да", True)
Окно10Окно10.Props.Height = perevesti("367", True)
Окно10Окно10.Props.Width = perevesti("503", True)

ProgressForm.ProgressBar1.Value = 46
Окно10Надпись72.Props.X = perevesti("8", True)
Окно10Надпись72.Props.Y = perevesti("8", True)
Окно10Надпись72.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись72.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись72.Props.Tag = perevesti("", True)
Окно10Надпись72.Props.Name = perevesti("Надпись7", True)
Окно10Надпись72.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись72.Props.Maximumheight = perevesti("0", True)
Окно10Надпись72.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись72.Props.Minimumheight = perevesti("0", True)
Окно10Надпись72.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись72.Props.Index = perevesti("2", True)
Окно10Надпись72.Props.ToolTip = perevesti("", True)
Окно10Надпись72.Props.Paddingtop = perevesti("0", True)
Окно10Надпись72.Props.Paddingleft = perevesti("0", True)
Окно10Надпись72.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись72.Props.Paddingright = perevesti("0", True)
Окно10Надпись72.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись72.Props.Textalign = perevesti("центр", True)
Окно10Надпись72.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись72.Props.Enabled = perevesti("Да", True)
Окно10Надпись72.Props.Dock = perevesti("Никакой", True)
Окно10Надпись72.Props.Image = perevesti("Никакой", True)
Окно10Надпись72.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись72.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись72.Props.Tabindex = perevesti("0", True)
Окно10Надпись72.Props.Tabstop = perevesti("Да", True)
Окно10Надпись72.Props.Text = perevesti("Иконка темы", True)
Окно10Надпись72.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись72.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись72.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись72.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись72.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись72.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись72.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись72.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись72.Props.Fontsize = perevesti("8", True)
Окно10Надпись72.Props.Height = perevesti("15", True)
Окно10Надпись72.Props.Width = perevesti("75", True)
Окно10Надпись72.Props.Visible = perevesti("Да", True)
Окно10Надпись72.Props.Height = perevesti("15", True)
Окно10Надпись72.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 47
Окно10Панель_10.Props.X = perevesti("4", True)
Окно10Панель_10.Props.Y = perevesti("8", True)
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
Окно10Панель_10.Props.Height = perevesti("283", True)
Окно10Панель_10.Props.Width = perevesti("491", True)
Окно10Панель_10.Props.Visible = perevesti("Да", True)
Окно10Панель_10.Props.Height = perevesti("283", True)
Окно10Панель_10.Props.Width = perevesti("491", True)

ProgressForm.ProgressBar1.Value = 48
Окно10Текст10.Props.X = perevesti("8", True)
Окно10Текст10.Props.Y = perevesti("24", True)
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
Окно10Текст10.Props.Multiline = perevesti("Нет", True)
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
Окно10Текст10.Props.Text = perevesti("", True)
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
Окно10Текст10.Props.Width = perevesti("483", True)
Окно10Текст10.Props.Visible = perevesti("Да", True)
Окно10Текст10.Props.Height = perevesti("20", True)
Окно10Текст10.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 49
Окно10Текст20.Props.X = perevesti("4", True)
Окно10Текст20.Props.Y = perevesti("64", True)
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
Окно10Текст20.Props.Text = perevesti("", True)
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
Окно10Текст20.Props.Width = perevesti("483", True)
Окно10Текст20.Props.Visible = perevesti("Да", True)
Окно10Текст20.Props.Height = perevesti("20", True)
Окно10Текст20.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 50
Окно10Текст30.Props.X = perevesti("4", True)
Окно10Текст30.Props.Y = perevesti("112", True)
Окно10Текст30.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Текст30.Props.Tag = perevesti("", True)
Окно10Текст30.Props.Selectedtext = perevesti("", True)
Окно10Текст30.Props.Selectionlength = perevesti("0", True)
Окно10Текст30.Props.Name = perevesti("Текст3", True)
Окно10Текст30.Props.Maximumheight = perevesti("0", True)
Окно10Текст30.Props.Maximumlength = perevesti("32767", True)
Окно10Текст30.Props.Maximumwidth = perevesti("0", True)
Окно10Текст30.Props.Minimumheight = perevesti("0", True)
Окно10Текст30.Props.Minimumwidth = perevesti("0", True)
Окно10Текст30.Props.Multiline = perevesti("Нет", True)
Окно10Текст30.Props.Selectionstart = perevesti("1", True)
Окно10Текст30.Props.Index = perevesti("0", True)
Окно10Текст30.Props.Wordwrap = perevesti("Да", True)
Окно10Текст30.Props.ToolTip = perevesti("", True)
Окно10Текст30.Props.Scrollbars = perevesti("Нет", True)
Окно10Текст30.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Текст30.Props.Enabled = perevesti("Да", True)
Окно10Текст30.Props.Allowinput = perevesti("Все", True)
Окно10Текст30.Props.Textposition = perevesti("Слева", True)
Окно10Текст30.Props.Dock = perevesti("Никакой", True)
Окно10Текст30.Props.Passwordchar = perevesti("", True)
Окно10Текст30.Props.Hideselection = perevesti("Нет", True)
Окно10Текст30.Props.Borderstyle = perevesti("объем", True)
Окно10Текст30.Props.Tabindex = perevesti("0", True)
Окно10Текст30.Props.Tabstop = perevesti("Да", True)
Окно10Текст30.Props.Text = perevesti("", True)
Окно10Текст30.Props.Readonly = perevesti("Нет", True)
Окно10Текст30.Props.Backcolor = perevesti("Белый", True)
Окно10Текст30.Props.Forecolor = perevesti("Черный", True)
Окно10Текст30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Текст30.Props.Fontbold = perevesti("Нет", True)
Окно10Текст30.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Текст30.Props.Fontitalic = perevesti("Нет", True)
Окно10Текст30.Props.Fontunderline = perevesti("Нет", True)
Окно10Текст30.Props.Fontsize = perevesti("8", True)
Окно10Текст30.Props.Height = perevesti("20", True)
Окно10Текст30.Props.Width = perevesti("483", True)
Окно10Текст30.Props.Visible = perevesti("Да", True)
Окно10Текст30.Props.Height = perevesti("20", True)
Окно10Текст30.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 51
Окно10Текст40.Props.X = perevesti("4", True)
Окно10Текст40.Props.Y = perevesti("160", True)
Окно10Текст40.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Текст40.Props.Tag = perevesti("", True)
Окно10Текст40.Props.Selectedtext = perevesti("", True)
Окно10Текст40.Props.Selectionlength = perevesti("0", True)
Окно10Текст40.Props.Name = perevesti("Текст4", True)
Окно10Текст40.Props.Maximumheight = perevesti("0", True)
Окно10Текст40.Props.Maximumlength = perevesti("32767", True)
Окно10Текст40.Props.Maximumwidth = perevesti("0", True)
Окно10Текст40.Props.Minimumheight = perevesti("0", True)
Окно10Текст40.Props.Minimumwidth = perevesti("0", True)
Окно10Текст40.Props.Multiline = perevesti("Нет", True)
Окно10Текст40.Props.Selectionstart = perevesti("1", True)
Окно10Текст40.Props.Index = perevesti("0", True)
Окно10Текст40.Props.Wordwrap = perevesti("Да", True)
Окно10Текст40.Props.ToolTip = perevesti("", True)
Окно10Текст40.Props.Scrollbars = perevesti("Нет", True)
Окно10Текст40.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Текст40.Props.Enabled = perevesti("Да", True)
Окно10Текст40.Props.Allowinput = perevesti("Все", True)
Окно10Текст40.Props.Textposition = perevesti("Слева", True)
Окно10Текст40.Props.Dock = perevesti("Никакой", True)
Окно10Текст40.Props.Passwordchar = perevesti("", True)
Окно10Текст40.Props.Hideselection = perevesti("Нет", True)
Окно10Текст40.Props.Borderstyle = perevesti("объем", True)
Окно10Текст40.Props.Tabindex = perevesti("0", True)
Окно10Текст40.Props.Tabstop = perevesti("Да", True)
Окно10Текст40.Props.Text = perevesti("", True)
Окно10Текст40.Props.Readonly = perevesti("Нет", True)
Окно10Текст40.Props.Backcolor = perevesti("Белый", True)
Окно10Текст40.Props.Forecolor = perevesti("Черный", True)
Окно10Текст40.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Текст40.Props.Fontbold = perevesti("Нет", True)
Окно10Текст40.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Текст40.Props.Fontitalic = perevesti("Нет", True)
Окно10Текст40.Props.Fontunderline = perevesti("Нет", True)
Окно10Текст40.Props.Fontsize = perevesti("8", True)
Окно10Текст40.Props.Height = perevesti("20", True)
Окно10Текст40.Props.Width = perevesti("483", True)
Окно10Текст40.Props.Visible = perevesti("Да", True)
Окно10Текст40.Props.Height = perevesti("20", True)
Окно10Текст40.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 52
Окно10Текст50.Props.X = perevesti("4", True)
Окно10Текст50.Props.Y = perevesti("208", True)
Окно10Текст50.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Текст50.Props.Tag = perevesti("", True)
Окно10Текст50.Props.Selectedtext = perevesti("", True)
Окно10Текст50.Props.Selectionlength = perevesti("0", True)
Окно10Текст50.Props.Name = perevesti("Текст5", True)
Окно10Текст50.Props.Maximumheight = perevesti("0", True)
Окно10Текст50.Props.Maximumlength = perevesti("32767", True)
Окно10Текст50.Props.Maximumwidth = perevesti("0", True)
Окно10Текст50.Props.Minimumheight = perevesti("0", True)
Окно10Текст50.Props.Minimumwidth = perevesti("0", True)
Окно10Текст50.Props.Multiline = perevesti("Нет", True)
Окно10Текст50.Props.Selectionstart = perevesti("1", True)
Окно10Текст50.Props.Index = perevesti("0", True)
Окно10Текст50.Props.Wordwrap = perevesti("Да", True)
Окно10Текст50.Props.ToolTip = perevesti("", True)
Окно10Текст50.Props.Scrollbars = perevesti("Нет", True)
Окно10Текст50.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Текст50.Props.Enabled = perevesti("Да", True)
Окно10Текст50.Props.Allowinput = perevesti("Все", True)
Окно10Текст50.Props.Textposition = perevesti("Слева", True)
Окно10Текст50.Props.Dock = perevesti("Никакой", True)
Окно10Текст50.Props.Passwordchar = perevesti("", True)
Окно10Текст50.Props.Hideselection = perevesti("Нет", True)
Окно10Текст50.Props.Borderstyle = perevesti("объем", True)
Окно10Текст50.Props.Tabindex = perevesti("0", True)
Окно10Текст50.Props.Tabstop = perevesti("Да", True)
Окно10Текст50.Props.Text = perevesti("", True)
Окно10Текст50.Props.Readonly = perevesti("Нет", True)
Окно10Текст50.Props.Backcolor = perevesti("Белый", True)
Окно10Текст50.Props.Forecolor = perevesti("Черный", True)
Окно10Текст50.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Текст50.Props.Fontbold = perevesti("Нет", True)
Окно10Текст50.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Текст50.Props.Fontitalic = perevesti("Нет", True)
Окно10Текст50.Props.Fontunderline = perevesti("Нет", True)
Окно10Текст50.Props.Fontsize = perevesti("8", True)
Окно10Текст50.Props.Height = perevesti("20", True)
Окно10Текст50.Props.Width = perevesti("483", True)
Окно10Текст50.Props.Visible = perevesti("Да", True)
Окно10Текст50.Props.Height = perevesti("20", True)
Окно10Текст50.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 53
Окно10Текст60.Props.X = perevesti("4", True)
Окно10Текст60.Props.Y = perevesti("256", True)
Окно10Текст60.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Текст60.Props.Tag = perevesti("", True)
Окно10Текст60.Props.Selectedtext = perevesti("", True)
Окно10Текст60.Props.Selectionlength = perevesti("0", True)
Окно10Текст60.Props.Name = perevesti("Текст6", True)
Окно10Текст60.Props.Maximumheight = perevesti("0", True)
Окно10Текст60.Props.Maximumlength = perevesti("32767", True)
Окно10Текст60.Props.Maximumwidth = perevesti("0", True)
Окно10Текст60.Props.Minimumheight = perevesti("0", True)
Окно10Текст60.Props.Minimumwidth = perevesti("0", True)
Окно10Текст60.Props.Multiline = perevesti("Нет", True)
Окно10Текст60.Props.Selectionstart = perevesti("1", True)
Окно10Текст60.Props.Index = perevesti("0", True)
Окно10Текст60.Props.Wordwrap = perevesti("Да", True)
Окно10Текст60.Props.ToolTip = perevesti("", True)
Окно10Текст60.Props.Scrollbars = perevesti("Нет", True)
Окно10Текст60.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Текст60.Props.Enabled = perevesti("Да", True)
Окно10Текст60.Props.Allowinput = perevesti("Все", True)
Окно10Текст60.Props.Textposition = perevesti("Слева", True)
Окно10Текст60.Props.Dock = perevesti("Никакой", True)
Окно10Текст60.Props.Passwordchar = perevesti("", True)
Окно10Текст60.Props.Hideselection = perevesti("Нет", True)
Окно10Текст60.Props.Borderstyle = perevesti("объем", True)
Окно10Текст60.Props.Tabindex = perevesti("0", True)
Окно10Текст60.Props.Tabstop = perevesti("Да", True)
Окно10Текст60.Props.Text = perevesti("", True)
Окно10Текст60.Props.Readonly = perevesti("Нет", True)
Окно10Текст60.Props.Backcolor = perevesti("Белый", True)
Окно10Текст60.Props.Forecolor = perevesti("Черный", True)
Окно10Текст60.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Текст60.Props.Fontbold = perevesti("Нет", True)
Окно10Текст60.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Текст60.Props.Fontitalic = perevesti("Нет", True)
Окно10Текст60.Props.Fontunderline = perevesti("Нет", True)
Окно10Текст60.Props.Fontsize = perevesti("8", True)
Окно10Текст60.Props.Height = perevesti("20", True)
Окно10Текст60.Props.Width = perevesti("483", True)
Окно10Текст60.Props.Visible = perevesti("Да", True)
Окно10Текст60.Props.Height = perevesti("20", True)
Окно10Текст60.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 54
Окно10Кнопка10.Props.X = perevesti("424", True)
Окно10Кнопка10.Props.Y = perevesti("340", True)
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
Окно10Кнопка10.Props.Text = perevesti("Далее", True)
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
Окно10Кнопка10.Props.Width = perevesti("75", True)
Окно10Кнопка10.Props.Visible = perevesti("Да", True)
Окно10Кнопка10.Props.Height = perevesti("23", True)
Окно10Кнопка10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 55
Окно10Надпись73.Props.X = perevesti("4", True)
Окно10Надпись73.Props.Y = perevesti("44", True)
Окно10Надпись73.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись73.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись73.Props.Tag = perevesti("", True)
Окно10Надпись73.Props.Name = perevesti("Надпись7", True)
Окно10Надпись73.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись73.Props.Maximumheight = perevesti("0", True)
Окно10Надпись73.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись73.Props.Minimumheight = perevesti("0", True)
Окно10Надпись73.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись73.Props.Index = perevesti("3", True)
Окно10Надпись73.Props.ToolTip = perevesti("", True)
Окно10Надпись73.Props.Paddingtop = perevesti("0", True)
Окно10Надпись73.Props.Paddingleft = perevesti("0", True)
Окно10Надпись73.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись73.Props.Paddingright = perevesti("0", True)
Окно10Надпись73.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись73.Props.Textalign = perevesti("центр", True)
Окно10Надпись73.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись73.Props.Enabled = perevesti("Да", True)
Окно10Надпись73.Props.Dock = perevesti("Никакой", True)
Окно10Надпись73.Props.Image = perevesti("Никакой", True)
Окно10Надпись73.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись73.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись73.Props.Tabindex = perevesti("0", True)
Окно10Надпись73.Props.Tabstop = perevesti("Да", True)
Окно10Надпись73.Props.Text = perevesti("Иконка компьютера", True)
Окно10Надпись73.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись73.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись73.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись73.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись73.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись73.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись73.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись73.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись73.Props.Fontsize = perevesti("8", True)
Окно10Надпись73.Props.Height = perevesti("15", True)
Окно10Надпись73.Props.Width = perevesti("111", True)
Окно10Надпись73.Props.Visible = perevesti("Да", True)
Окно10Надпись73.Props.Height = perevesti("15", True)
Окно10Надпись73.Props.Width = perevesti("111", True)

ProgressForm.ProgressBar1.Value = 56
Окно10Надпись74.Props.X = perevesti("4", True)
Окно10Надпись74.Props.Y = perevesti("92", True)
Окно10Надпись74.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись74.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись74.Props.Tag = perevesti("", True)
Окно10Надпись74.Props.Name = perevesti("Надпись7", True)
Окно10Надпись74.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись74.Props.Maximumheight = perevesti("0", True)
Окно10Надпись74.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись74.Props.Minimumheight = perevesti("0", True)
Окно10Надпись74.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись74.Props.Index = perevesti("4", True)
Окно10Надпись74.Props.ToolTip = perevesti("", True)
Окно10Надпись74.Props.Paddingtop = perevesti("0", True)
Окно10Надпись74.Props.Paddingleft = perevesti("0", True)
Окно10Надпись74.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись74.Props.Paddingright = perevesti("0", True)
Окно10Надпись74.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись74.Props.Textalign = perevesti("центр", True)
Окно10Надпись74.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись74.Props.Enabled = perevesti("Да", True)
Окно10Надпись74.Props.Dock = perevesti("Никакой", True)
Окно10Надпись74.Props.Image = perevesti("Никакой", True)
Окно10Надпись74.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись74.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись74.Props.Tabindex = perevesti("0", True)
Окно10Надпись74.Props.Tabstop = perevesti("Да", True)
Окно10Надпись74.Props.Text = perevesti("Иконка пользователей", True)
Окно10Надпись74.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись74.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись74.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись74.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись74.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись74.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись74.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись74.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись74.Props.Fontsize = perevesti("8", True)
Окно10Надпись74.Props.Height = perevesti("15", True)
Окно10Надпись74.Props.Width = perevesti("127", True)
Окно10Надпись74.Props.Visible = perevesti("Да", True)
Окно10Надпись74.Props.Height = perevesti("15", True)
Окно10Надпись74.Props.Width = perevesti("127", True)

ProgressForm.ProgressBar1.Value = 57
Окно10Надпись75.Props.X = perevesti("4", True)
Окно10Надпись75.Props.Y = perevesti("140", True)
Окно10Надпись75.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись75.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись75.Props.Tag = perevesti("", True)
Окно10Надпись75.Props.Name = perevesti("Надпись7", True)
Окно10Надпись75.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись75.Props.Maximumheight = perevesti("0", True)
Окно10Надпись75.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись75.Props.Minimumheight = perevesti("0", True)
Окно10Надпись75.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись75.Props.Index = perevesti("5", True)
Окно10Надпись75.Props.ToolTip = perevesti("", True)
Окно10Надпись75.Props.Paddingtop = perevesti("0", True)
Окно10Надпись75.Props.Paddingleft = perevesti("0", True)
Окно10Надпись75.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись75.Props.Paddingright = perevesti("0", True)
Окно10Надпись75.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись75.Props.Textalign = perevesti("центр", True)
Окно10Надпись75.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись75.Props.Enabled = perevesti("Да", True)
Окно10Надпись75.Props.Dock = perevesti("Никакой", True)
Окно10Надпись75.Props.Image = perevesti("Никакой", True)
Окно10Надпись75.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись75.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись75.Props.Tabindex = perevesti("0", True)
Окно10Надпись75.Props.Tabstop = perevesti("Да", True)
Окно10Надпись75.Props.Text = perevesti("Иконка интернета", True)
Окно10Надпись75.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись75.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись75.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись75.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись75.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись75.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись75.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись75.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись75.Props.Fontsize = perevesti("8", True)
Окно10Надпись75.Props.Height = perevesti("15", True)
Окно10Надпись75.Props.Width = perevesti("103", True)
Окно10Надпись75.Props.Visible = perevesti("Да", True)
Окно10Надпись75.Props.Height = perevesti("15", True)
Окно10Надпись75.Props.Width = perevesti("103", True)

ProgressForm.ProgressBar1.Value = 58
Окно10Надпись76.Props.X = perevesti("4", True)
Окно10Надпись76.Props.Y = perevesti("188", True)
Окно10Надпись76.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись76.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись76.Props.Tag = perevesti("", True)
Окно10Надпись76.Props.Name = perevesti("Надпись7", True)
Окно10Надпись76.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись76.Props.Maximumheight = perevesti("0", True)
Окно10Надпись76.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись76.Props.Minimumheight = perevesti("0", True)
Окно10Надпись76.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись76.Props.Index = perevesti("6", True)
Окно10Надпись76.Props.ToolTip = perevesti("", True)
Окно10Надпись76.Props.Paddingtop = perevesti("0", True)
Окно10Надпись76.Props.Paddingleft = perevesti("0", True)
Окно10Надпись76.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись76.Props.Paddingright = perevesti("0", True)
Окно10Надпись76.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись76.Props.Textalign = perevesti("центр", True)
Окно10Надпись76.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись76.Props.Enabled = perevesti("Да", True)
Окно10Надпись76.Props.Dock = perevesti("Никакой", True)
Окно10Надпись76.Props.Image = perevesti("Никакой", True)
Окно10Надпись76.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись76.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись76.Props.Tabindex = perevesti("0", True)
Окно10Надпись76.Props.Tabstop = perevesti("Да", True)
Окно10Надпись76.Props.Text = perevesti("Иконка полной корзины", True)
Окно10Надпись76.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись76.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись76.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись76.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись76.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись76.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись76.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись76.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись76.Props.Fontsize = perevesti("8", True)
Окно10Надпись76.Props.Height = perevesti("15", True)
Окно10Надпись76.Props.Width = perevesti("135", True)
Окно10Надпись76.Props.Visible = perevesti("Да", True)
Окно10Надпись76.Props.Height = perevesti("15", True)
Окно10Надпись76.Props.Width = perevesti("135", True)

ProgressForm.ProgressBar1.Value = 59
Окно10Надпись77.Props.X = perevesti("4", True)
Окно10Надпись77.Props.Y = perevesti("236", True)
Окно10Надпись77.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись77.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись77.Props.Tag = perevesti("", True)
Окно10Надпись77.Props.Name = perevesti("Надпись7", True)
Окно10Надпись77.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись77.Props.Maximumheight = perevesti("0", True)
Окно10Надпись77.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись77.Props.Minimumheight = perevesti("0", True)
Окно10Надпись77.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись77.Props.Index = perevesti("7", True)
Окно10Надпись77.Props.ToolTip = perevesti("", True)
Окно10Надпись77.Props.Paddingtop = perevesti("0", True)
Окно10Надпись77.Props.Paddingleft = perevesti("0", True)
Окно10Надпись77.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись77.Props.Paddingright = perevesti("0", True)
Окно10Надпись77.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись77.Props.Textalign = perevesti("центр", True)
Окно10Надпись77.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись77.Props.Enabled = perevesti("Да", True)
Окно10Надпись77.Props.Dock = perevesti("Никакой", True)
Окно10Надпись77.Props.Image = perevesti("Никакой", True)
Окно10Надпись77.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись77.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись77.Props.Tabindex = perevesti("0", True)
Окно10Надпись77.Props.Tabstop = perevesti("Да", True)
Окно10Надпись77.Props.Text = perevesti("Иконка пустой корзины", True)
Окно10Надпись77.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись77.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись77.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись77.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись77.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись77.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись77.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись77.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись77.Props.Fontsize = perevesti("8", True)
Окно10Надпись77.Props.Height = perevesti("15", True)
Окно10Надпись77.Props.Width = perevesti("135", True)
Окно10Надпись77.Props.Visible = perevesti("Да", True)
Окно10Надпись77.Props.Height = perevesti("15", True)
Окно10Надпись77.Props.Width = perevesti("135", True)

ProgressForm.ProgressBar1.Value = 59
Окно10Текст70.Props.X = perevesti("4", True)
Окно10Текст70.Props.Y = perevesti("316", True)
Окно10Текст70.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Текст70.Props.Tag = perevesti("", True)
Окно10Текст70.Props.Selectedtext = perevesti("", True)
Окно10Текст70.Props.Selectionlength = perevesti("0", True)
Окно10Текст70.Props.Name = perevesti("Текст7", True)
Окно10Текст70.Props.Maximumheight = perevesti("0", True)
Окно10Текст70.Props.Maximumlength = perevesti("32767", True)
Окно10Текст70.Props.Maximumwidth = perevesti("0", True)
Окно10Текст70.Props.Minimumheight = perevesti("0", True)
Окно10Текст70.Props.Minimumwidth = perevesti("0", True)
Окно10Текст70.Props.Multiline = perevesti("Нет", True)
Окно10Текст70.Props.Selectionstart = perevesti("1", True)
Окно10Текст70.Props.Index = perevesti("0", True)
Окно10Текст70.Props.Wordwrap = perevesti("Да", True)
Окно10Текст70.Props.ToolTip = perevesti("", True)
Окно10Текст70.Props.Scrollbars = perevesti("Нет", True)
Окно10Текст70.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Текст70.Props.Enabled = perevesti("Да", True)
Окно10Текст70.Props.Allowinput = perevesti("Все", True)
Окно10Текст70.Props.Textposition = perevesti("Слева", True)
Окно10Текст70.Props.Dock = perevesti("Никакой", True)
Окно10Текст70.Props.Passwordchar = perevesti("", True)
Окно10Текст70.Props.Hideselection = perevesti("Нет", True)
Окно10Текст70.Props.Borderstyle = perevesti("объем", True)
Окно10Текст70.Props.Tabindex = perevesti("0", True)
Окно10Текст70.Props.Tabstop = perevesti("Да", True)
Окно10Текст70.Props.Text = perevesti("", True)
Окно10Текст70.Props.Readonly = perevesti("Нет", True)
Окно10Текст70.Props.Backcolor = perevesti("Белый", True)
Окно10Текст70.Props.Forecolor = perevesti("Черный", True)
Окно10Текст70.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Текст70.Props.Fontbold = perevesti("Нет", True)
Окно10Текст70.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Текст70.Props.Fontitalic = perevesti("Нет", True)
Окно10Текст70.Props.Fontunderline = perevesti("Нет", True)
Окно10Текст70.Props.Fontsize = perevesti("8", True)
Окно10Текст70.Props.Height = perevesti("20", True)
Окно10Текст70.Props.Width = perevesti("495", True)
Окно10Текст70.Props.Visible = perevesti("Да", True)
Окно10Текст70.Props.Height = perevesti("20", True)
Окно10Текст70.Props.Width = perevesti("495", True)

ProgressForm.ProgressBar1.Value = 60
Окно10Надпись71.Props.X = perevesti("4", True)
Окно10Надпись71.Props.Y = perevesti("296", True)
Окно10Надпись71.Props.Autoellipsis = perevesti("Да", True)
Окно10Надпись71.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Надпись71.Props.Tag = perevesti("", True)
Окно10Надпись71.Props.Name = perevesti("Надпись7", True)
Окно10Надпись71.Props.Cursor = perevesti("Обычный", True)
Окно10Надпись71.Props.Maximumheight = perevesti("0", True)
Окно10Надпись71.Props.Maximumwidth = perevesti("0", True)
Окно10Надпись71.Props.Minimumheight = perevesti("0", True)
Окно10Надпись71.Props.Minimumwidth = perevesti("0", True)
Окно10Надпись71.Props.Index = perevesti("1", True)
Окно10Надпись71.Props.ToolTip = perevesti("", True)
Окно10Надпись71.Props.Paddingtop = perevesti("0", True)
Окно10Надпись71.Props.Paddingleft = perevesti("0", True)
Окно10Надпись71.Props.Paddingbottom = perevesti("0", True)
Окно10Надпись71.Props.Paddingright = perevesti("0", True)
Окно10Надпись71.Props.Imagealign = perevesti("Центр", True)
Окно10Надпись71.Props.Textalign = perevesti("центр", True)
Окно10Надпись71.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Надпись71.Props.Enabled = perevesti("Да", True)
Окно10Надпись71.Props.Dock = perevesti("Никакой", True)
Окно10Надпись71.Props.Image = perevesti("Никакой", True)
Окно10Надпись71.Props.Borderstyle = perevesti("Никакой", True)
Окно10Надпись71.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Надпись71.Props.Tabindex = perevesti("0", True)
Окно10Надпись71.Props.Tabstop = perevesti("Да", True)
Окно10Надпись71.Props.Text = perevesti("Помощь", True)
Окно10Надпись71.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Надпись71.Props.Backcolor = perevesti("240; 240; 240;", True)
Окно10Надпись71.Props.Forecolor = perevesti("Черный", True)
Окно10Надпись71.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Надпись71.Props.Fontbold = perevesti("Нет", True)
Окно10Надпись71.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Надпись71.Props.Fontitalic = perevesti("Нет", True)
Окно10Надпись71.Props.Fontunderline = perevesti("Нет", True)
Окно10Надпись71.Props.Fontsize = perevesti("8", True)
Окно10Надпись71.Props.Height = perevesti("15", True)
Окно10Надпись71.Props.Width = perevesti("51", True)
Окно10Надпись71.Props.Visible = perevesti("Да", True)
Окно10Надпись71.Props.Height = perevesti("15", True)
Окно10Надпись71.Props.Width = perevesti("51", True)

ProgressForm.ProgressBar1.Value = 61
Окно10Кнопка20.Props.X = perevesti("80", True)
Окно10Кнопка20.Props.Y = perevesti("340", True)
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
Окно10Кнопка20.Props.Text = perevesti("Копировать", True)
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
Окно10Кнопка20.Props.Width = perevesti("75", True)
Окно10Кнопка20.Props.Visible = perevesti("Да", True)
Окно10Кнопка20.Props.Height = perevesti("23", True)
Окно10Кнопка20.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 62
Окно10Кнопка30.Props.X = perevesti("4", True)
Окно10Кнопка30.Props.Y = perevesti("340", True)
Окно10Кнопка30.Props.Autoellipsis = perevesti("Да", True)
Окно10Кнопка30.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно10Кнопка30.Props.Tag = perevesti("", True)
Окно10Кнопка30.Props.Name = perevesti("Кнопка3", True)
Окно10Кнопка30.Props.Cursor = perevesti("Обычный", True)
Окно10Кнопка30.Props.Maximumheight = perevesti("0", True)
Окно10Кнопка30.Props.Maximumwidth = perevesti("0", True)
Окно10Кнопка30.Props.Minimumheight = perevesti("0", True)
Окно10Кнопка30.Props.Minimumwidth = perevesti("0", True)
Окно10Кнопка30.Props.Index = perevesti("0", True)
Окно10Кнопка30.Props.ToolTip = perevesti("", True)
Окно10Кнопка30.Props.Paddingtop = perevesti("0", True)
Окно10Кнопка30.Props.Paddingleft = perevesti("0", True)
Окно10Кнопка30.Props.Paddingbottom = perevesti("0", True)
Окно10Кнопка30.Props.Paddingright = perevesti("0", True)
Окно10Кнопка30.Props.Imagealign = perevesti("Центр", True)
Окно10Кнопка30.Props.Textalign = perevesti("центр", True)
Окно10Кнопка30.Props.Anchor = perevesti("Слева_Сверху", True)
Окно10Кнопка30.Props.Enabled = perevesti("Да", True)
Окно10Кнопка30.Props.Dock = perevesti("Никакой", True)
Окно10Кнопка30.Props.Image = perevesti("Никакой", True)
Окно10Кнопка30.Props.Flatstyle = perevesti("Обычный", True)
Окно10Кнопка30.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно10Кнопка30.Props.Tabindex = perevesti("0", True)
Окно10Кнопка30.Props.Tabstop = perevesti("Да", True)
Окно10Кнопка30.Props.Text = perevesti("Открыть", True)
Окно10Кнопка30.Props.Textimagerelation = perevesti("Поверх", True)
Окно10Кнопка30.Props.Backgroundimage = perevesti("Никакой", True)
Окно10Кнопка30.Props.Backcolor = perevesti("Никакой", True)
Окно10Кнопка30.Props.Forecolor = perevesti("Черный", True)
Окно10Кнопка30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно10Кнопка30.Props.Fontbold = perevesti("Нет", True)
Окно10Кнопка30.Props.Fontstrikeout = perevesti("Нет", True)
Окно10Кнопка30.Props.Fontitalic = perevesti("Нет", True)
Окно10Кнопка30.Props.Fontunderline = perevesti("Нет", True)
Окно10Кнопка30.Props.Fontsize = perevesti("8", True)
Окно10Кнопка30.Props.Height = perevesti("23", True)
Окно10Кнопка30.Props.Width = perevesti("75", True)
Окно10Кнопка30.Props.Visible = perevesti("Да", True)
Окно10Кнопка30.Props.Height = perevesti("23", True)
Окно10Кнопка30.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 63
Окно10Окно_открытия10.Props.X = perevesti("8", True)
Окно10Окно_открытия10.Props.Y = perevesti("8", True)
Окно10Окно_открытия10.Props.Tag = perevesti("", True)
Окно10Окно_открытия10.Props.Multiselectfiles = perevesti("Нет", True)
Окно10Окно_открытия10.Props.Defaultext = perevesti("", True)
Окно10Окно_открытия10.Props.Title = perevesti("", True)
Окно10Окно_открытия10.Props.Name = perevesti("Окно открытия1", True)
Окно10Окно_открытия10.Props.Filename = perevesti("", True)
Окно10Окно_открытия10.Props.Initialdirectory = perevesti("", True)
Окно10Окно_открытия10.Props.Index = perevesti("0", True)
Окно10Окно_открытия10.Props.Filterindex = perevesti("1", True)
Окно10Окно_открытия10.Props.Checkpathexists = perevesti("Да", True)
Окно10Окно_открытия10.Props.Checkfileexists = perevesti("Да", True)
Окно10Окно_открытия10.Props.Filter = perevesti("Рисунки|*.jpg;*.bmp;*.png|Все файлы|*.*", True)

ProgressForm.ProgressBar1.Value = 64
Окно20Окно20.Props.X = perevesti("0", True)
Окно20Окно20.Props.Y = perevesti("0", True)
Окно20Окно20.Props.Associatewithextensions = perevesti("", True)
Окно20Окно20.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно20Окно20.Props.Tag = perevesti("", True)
Окно20Окно20.Props.Mainform = perevesti("Нет", True)
Окно20Окно20.Props.Mainmenustrip(True) = perevesti("Никакой", True)
Окно20Окно20.Props.AutoRun = perevesti("Нет", True)
Окно20Окно20.Props.Forbidclose = perevesti("Нет", True)
Окно20Окно20.Props.Forbidminimize = perevesti("Нет", True)
Окно20Окно20.Props.Forbidmaximize = perevesti("Да", True)
Окно20Окно20.Props.Icon = perevesti("Никакой", True)
Окно20Окно20.Props.Name = perevesti("Окно2", True)
Окно20Окно20.Props.Cursor = perevesti("Обычный", True)
Окно20Окно20.Props.Maximumheight = perevesti("0", True)
Окно20Окно20.Props.Maximumwidth = perevesti("0", True)
Окно20Окно20.Props.Minimumheight = perevesti("0", True)
Окно20Окно20.Props.Minimumwidth = perevesti("0", True)
Окно20Окно20.Props.Index = perevesti("0", True)
Окно20Окно20.Props.Controlbox = perevesti("Да", True)
Окно20Окно20.Props.Showintaskbar = perevesti("Да", True)
Окно20Окно20.Props.Showintray = perevesti("Нет", True)
Окно20Окно20.Props.TopMost = perevesti("Нет", True)
Окно20Окно20.Props.ToolTip = perevesti("", True)
Окно20Окно20.Props.Showicon = perevesti("Нет", True)
Окно20Окно20.Props.Opacity = perevesti("100", True)
Окно20Окно20.Props.Transparentcykey = perevesti("Никакой", True)
Окно20Окно20.Props.Scroll = perevesti("Нет", True)
Окно20Окно20.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно20Окно20.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно20Окно20.Props.AutoscrollpositionX = perevesti("0", True)
Окно20Окно20.Props.AutoscrollpositionY = perevesti("0", True)
Окно20Окно20.Props.Enabled = perevesti("Нет", True)
Окно20Окно20.Props.Allowruncopies = perevesti("Да", True)
Окно20Окно20.Props.Startposition = perevesti("по центру экрана", True)
Окно20Окно20.StatusTemp = "Нормальный"
Окно20Окно20.Props.Formborderstyle = perevesti("фиксированное окно", True)
Окно20Окно20.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно20Окно20.Props.Tabindex = perevesti("0", True)
Окно20Окно20.Props.Tabstop = perevesti("Да", True)
Окно20Окно20.Props.Text = perevesti("Рисунок рабочего стола", True)
Окно20Окно20.Props.Backgroundimage = perevesti("Никакой", True)
Окно20Окно20.Props.Backcolor = perevesti("Системный", True)
Окно20Окно20.Props.Forecolor = perevesti("Черный", True)
Окно20Окно20.Props.Height = perevesti("203", True)
Окно20Окно20.Props.Width = perevesti("315", True)
Окно20Окно20.Props.Visible = perevesti("Нет", True)
Окно20Окно20.Props.Height = perevesti("203", True)
Окно20Окно20.Props.Width = perevesti("315", True)

ProgressForm.ProgressBar1.Value = 65
Окно20Рисунок10.Props.X = perevesti("4", True)
Окно20Рисунок10.Props.Y = perevesti("4", True)
Окно20Рисунок10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно20Рисунок10.Props.Tag = perevesti("", True)
Окно20Рисунок10.Props.Name = perevesti("Рисунок1", True)
Окно20Рисунок10.Props.Cursor = perevesti("Обычный", True)
Окно20Рисунок10.Props.Maximumheight = perevesti("0", True)
Окно20Рисунок10.Props.Maximumwidth = perevesti("0", True)
Окно20Рисунок10.Props.Minimumheight = perevesti("0", True)
Окно20Рисунок10.Props.Minimumwidth = perevesti("0", True)
Окно20Рисунок10.Props.Index = perevesti("0", True)
Окно20Рисунок10.Props.ToolTip = perevesti("", True)
Окно20Рисунок10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно20Рисунок10.Props.Enabled = perevesti("Да", True)
Окно20Рисунок10.Props.Dock = perevesti("Никакой", True)
Окно20Рисунок10.Props.Image = perevesti("Никакой", True)
Окно20Рисунок10.Props.Borderstyle = perevesti("Никакой", True)
Окно20Рисунок10.Props.Sizemode = perevesti("растянутый", True)
Окно20Рисунок10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно20Рисунок10.Props.Tabindex = perevesti("0", True)
Окно20Рисунок10.Props.Tabstop = perevesti("Да", True)
Окно20Рисунок10.Props.Backgroundimage = perevesti("Никакой", True)
Окно20Рисунок10.Props.Backcolor = perevesti("172; 172; 172;", True)
Окно20Рисунок10.Props.Height = perevesti("173", True)
Окно20Рисунок10.Props.Width = perevesti("230", True)
Окно20Рисунок10.Props.Visible = perevesti("Да", True)
Окно20Рисунок10.Props.Height = perevesti("173", True)
Окно20Рисунок10.Props.Width = perevesti("230", True)

ProgressForm.ProgressBar1.Value = 66
Окно20Кнопка10.Props.X = perevesti("236", True)
Окно20Кнопка10.Props.Y = perevesti("4", True)
Окно20Кнопка10.Props.Autoellipsis = perevesti("Да", True)
Окно20Кнопка10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно20Кнопка10.Props.Tag = perevesti("", True)
Окно20Кнопка10.Props.Name = perevesti("Кнопка1", True)
Окно20Кнопка10.Props.Cursor = perevesti("Обычный", True)
Окно20Кнопка10.Props.Maximumheight = perevesti("0", True)
Окно20Кнопка10.Props.Maximumwidth = perevesti("0", True)
Окно20Кнопка10.Props.Minimumheight = perevesti("0", True)
Окно20Кнопка10.Props.Minimumwidth = perevesti("0", True)
Окно20Кнопка10.Props.Index = perevesti("0", True)
Окно20Кнопка10.Props.ToolTip = perevesti("", True)
Окно20Кнопка10.Props.Paddingtop = perevesti("0", True)
Окно20Кнопка10.Props.Paddingleft = perevesti("0", True)
Окно20Кнопка10.Props.Paddingbottom = perevesti("0", True)
Окно20Кнопка10.Props.Paddingright = perevesti("0", True)
Окно20Кнопка10.Props.Imagealign = perevesti("Центр", True)
Окно20Кнопка10.Props.Textalign = perevesti("центр", True)
Окно20Кнопка10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно20Кнопка10.Props.Enabled = perevesti("Да", True)
Окно20Кнопка10.Props.Dock = perevesti("Никакой", True)
Окно20Кнопка10.Props.Image = perevesti("Никакой", True)
Окно20Кнопка10.Props.Flatstyle = perevesti("Обычный", True)
Окно20Кнопка10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно20Кнопка10.Props.Tabindex = perevesti("0", True)
Окно20Кнопка10.Props.Tabstop = perevesti("Да", True)
Окно20Кнопка10.Props.Text = perevesti("Открыть", True)
Окно20Кнопка10.Props.Textimagerelation = perevesti("Поверх", True)
Окно20Кнопка10.Props.Backgroundimage = perevesti("Никакой", True)
Окно20Кнопка10.Props.Backcolor = perevesti("Никакой", True)
Окно20Кнопка10.Props.Forecolor = perevesti("Черный", True)
Окно20Кнопка10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно20Кнопка10.Props.Fontbold = perevesti("Нет", True)
Окно20Кнопка10.Props.Fontstrikeout = perevesti("Нет", True)
Окно20Кнопка10.Props.Fontitalic = perevesti("Нет", True)
Окно20Кнопка10.Props.Fontunderline = perevesti("Нет", True)
Окно20Кнопка10.Props.Fontsize = perevesti("8", True)
Окно20Кнопка10.Props.Height = perevesti("23", True)
Окно20Кнопка10.Props.Width = perevesti("75", True)
Окно20Кнопка10.Props.Visible = perevesti("Да", True)
Окно20Кнопка10.Props.Height = perevesti("23", True)
Окно20Кнопка10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 67
Окно20Кнопка20.Props.X = perevesti("236", True)
Окно20Кнопка20.Props.Y = perevesti("28", True)
Окно20Кнопка20.Props.Autoellipsis = perevesti("Да", True)
Окно20Кнопка20.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно20Кнопка20.Props.Tag = perevesti("", True)
Окно20Кнопка20.Props.Name = perevesti("Кнопка2", True)
Окно20Кнопка20.Props.Cursor = perevesti("Обычный", True)
Окно20Кнопка20.Props.Maximumheight = perevesti("0", True)
Окно20Кнопка20.Props.Maximumwidth = perevesti("0", True)
Окно20Кнопка20.Props.Minimumheight = perevesti("0", True)
Окно20Кнопка20.Props.Minimumwidth = perevesti("0", True)
Окно20Кнопка20.Props.Index = perevesti("0", True)
Окно20Кнопка20.Props.ToolTip = perevesti("", True)
Окно20Кнопка20.Props.Paddingtop = perevesti("0", True)
Окно20Кнопка20.Props.Paddingleft = perevesti("0", True)
Окно20Кнопка20.Props.Paddingbottom = perevesti("0", True)
Окно20Кнопка20.Props.Paddingright = perevesti("0", True)
Окно20Кнопка20.Props.Imagealign = perevesti("Центр", True)
Окно20Кнопка20.Props.Textalign = perevesti("центр", True)
Окно20Кнопка20.Props.Anchor = perevesti("Слева_Сверху", True)
Окно20Кнопка20.Props.Enabled = perevesti("Да", True)
Окно20Кнопка20.Props.Dock = perevesti("Никакой", True)
Окно20Кнопка20.Props.Image = perevesti("Никакой", True)
Окно20Кнопка20.Props.Flatstyle = perevesti("Обычный", True)
Окно20Кнопка20.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно20Кнопка20.Props.Tabindex = perevesti("0", True)
Окно20Кнопка20.Props.Tabstop = perevesti("Да", True)
Окно20Кнопка20.Props.Text = perevesti("Далее", True)
Окно20Кнопка20.Props.Textimagerelation = perevesti("Поверх", True)
Окно20Кнопка20.Props.Backgroundimage = perevesti("Никакой", True)
Окно20Кнопка20.Props.Backcolor = perevesti("Никакой", True)
Окно20Кнопка20.Props.Forecolor = perevesti("Черный", True)
Окно20Кнопка20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно20Кнопка20.Props.Fontbold = perevesti("Нет", True)
Окно20Кнопка20.Props.Fontstrikeout = perevesti("Нет", True)
Окно20Кнопка20.Props.Fontitalic = perevesti("Нет", True)
Окно20Кнопка20.Props.Fontunderline = perevesti("Нет", True)
Окно20Кнопка20.Props.Fontsize = perevesti("8", True)
Окно20Кнопка20.Props.Height = perevesti("23", True)
Окно20Кнопка20.Props.Width = perevesti("75", True)
Окно20Кнопка20.Props.Visible = perevesti("Да", True)
Окно20Кнопка20.Props.Height = perevesti("23", True)
Окно20Кнопка20.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 68
Окно20Текст10.Props.X = perevesti("4", True)
Окно20Текст10.Props.Y = perevesti("180", True)
Окно20Текст10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно20Текст10.Props.Tag = perevesti("", True)
Окно20Текст10.Props.Selectedtext = perevesti("", True)
Окно20Текст10.Props.Selectionlength = perevesti("0", True)
Окно20Текст10.Props.Name = perevesti("Текст1", True)
Окно20Текст10.Props.Maximumheight = perevesti("0", True)
Окно20Текст10.Props.Maximumlength = perevesti("32767", True)
Окно20Текст10.Props.Maximumwidth = perevesti("0", True)
Окно20Текст10.Props.Minimumheight = perevesti("0", True)
Окно20Текст10.Props.Minimumwidth = perevesti("0", True)
Окно20Текст10.Props.Multiline = perevesti("Нет", True)
Окно20Текст10.Props.Selectionstart = perevesti("1", True)
Окно20Текст10.Props.Index = perevesti("0", True)
Окно20Текст10.Props.Wordwrap = perevesti("Да", True)
Окно20Текст10.Props.ToolTip = perevesti("", True)
Окно20Текст10.Props.Scrollbars = perevesti("Нет", True)
Окно20Текст10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно20Текст10.Props.Enabled = perevesti("Да", True)
Окно20Текст10.Props.Allowinput = perevesti("Все", True)
Окно20Текст10.Props.Textposition = perevesti("Слева", True)
Окно20Текст10.Props.Dock = perevesti("Никакой", True)
Окно20Текст10.Props.Passwordchar = perevesti("", True)
Окно20Текст10.Props.Hideselection = perevesti("Нет", True)
Окно20Текст10.Props.Borderstyle = perevesti("объем", True)
Окно20Текст10.Props.Tabindex = perevesti("0", True)
Окно20Текст10.Props.Tabstop = perevesti("Да", True)
Окно20Текст10.Props.Text = perevesti("", True)
Окно20Текст10.Props.Readonly = perevesti("Нет", True)
Окно20Текст10.Props.Backcolor = perevesti("Белый", True)
Окно20Текст10.Props.Forecolor = perevesti("Черный", True)
Окно20Текст10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно20Текст10.Props.Fontbold = perevesti("Нет", True)
Окно20Текст10.Props.Fontstrikeout = perevesti("Нет", True)
Окно20Текст10.Props.Fontitalic = perevesti("Нет", True)
Окно20Текст10.Props.Fontunderline = perevesti("Нет", True)
Окно20Текст10.Props.Fontsize = perevesti("8", True)
Окно20Текст10.Props.Height = perevesti("20", True)
Окно20Текст10.Props.Width = perevesti("307", True)
Окно20Текст10.Props.Visible = perevesti("Да", True)
Окно20Текст10.Props.Height = perevesti("20", True)
Окно20Текст10.Props.Width = perevesti("307", True)

ProgressForm.ProgressBar1.Value = 69
Окно20Окно_открытия10.Props.X = perevesti("4", True)
Окно20Окно_открытия10.Props.Y = perevesti("4", True)
Окно20Окно_открытия10.Props.Tag = perevesti("", True)
Окно20Окно_открытия10.Props.Multiselectfiles = perevesti("Нет", True)
Окно20Окно_открытия10.Props.Defaultext = perevesti("", True)
Окно20Окно_открытия10.Props.Title = perevesti("", True)
Окно20Окно_открытия10.Props.Name = perevesti("Окно открытия1", True)
Окно20Окно_открытия10.Props.Filename = perevesti("", True)
Окно20Окно_открытия10.Props.Initialdirectory = perevesti("", True)
Окно20Окно_открытия10.Props.Index = perevesti("0", True)
Окно20Окно_открытия10.Props.Filterindex = perevesti("1", True)
Окно20Окно_открытия10.Props.Checkpathexists = perevesti("Да", True)
Окно20Окно_открытия10.Props.Checkfileexists = perevesti("Да", True)
Окно20Окно_открытия10.Props.Filter = perevesti("Рисунки|*.jpg;*.bmp;*.png|Все файлы|*.*", True)

ProgressForm.ProgressBar1.Value = 70
Окно30Окно30.Props.X = perevesti("0", True)
Окно30Окно30.Props.Y = perevesti("0", True)
Окно30Окно30.Props.Associatewithextensions = perevesti("", True)
Окно30Окно30.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно30Окно30.Props.Tag = perevesti("", True)
Окно30Окно30.Props.Mainform = perevesti("Нет", True)
Окно30Окно30.Props.Mainmenustrip(True) = perevesti("Никакой", True)
Окно30Окно30.Props.AutoRun = perevesti("Нет", True)
Окно30Окно30.Props.Forbidclose = perevesti("Нет", True)
Окно30Окно30.Props.Forbidminimize = perevesti("Нет", True)
Окно30Окно30.Props.Forbidmaximize = perevesti("Да", True)
Окно30Окно30.Props.Icon = perevesti("Никакой", True)
Окно30Окно30.Props.Name = perevesti("Окно3", True)
Окно30Окно30.Props.Cursor = perevesti("Обычный", True)
Окно30Окно30.Props.Maximumheight = perevesti("0", True)
Окно30Окно30.Props.Maximumwidth = perevesti("0", True)
Окно30Окно30.Props.Minimumheight = perevesti("0", True)
Окно30Окно30.Props.Minimumwidth = perevesti("0", True)
Окно30Окно30.Props.Index = perevesti("0", True)
Окно30Окно30.Props.Controlbox = perevesti("Да", True)
Окно30Окно30.Props.Showintaskbar = perevesti("Да", True)
Окно30Окно30.Props.Showintray = perevesti("Нет", True)
Окно30Окно30.Props.TopMost = perevesti("Нет", True)
Окно30Окно30.Props.ToolTip = perevesti("", True)
Окно30Окно30.Props.Showicon = perevesti("Нет", True)
Окно30Окно30.Props.Opacity = perevesti("100", True)
Окно30Окно30.Props.Transparentcykey = perevesti("Никакой", True)
Окно30Окно30.Props.Scroll = perevesti("Нет", True)
Окно30Окно30.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно30Окно30.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно30Окно30.Props.AutoscrollpositionX = perevesti("0", True)
Окно30Окно30.Props.AutoscrollpositionY = perevesti("0", True)
Окно30Окно30.Props.Enabled = perevesti("Нет", True)
Окно30Окно30.Props.Allowruncopies = perevesti("Да", True)
Окно30Окно30.Props.Startposition = perevesti("по центру экрана", True)
Окно30Окно30.StatusTemp = "Нормальный"
Окно30Окно30.Props.Formborderstyle = perevesti("фиксированное окно", True)
Окно30Окно30.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно30Окно30.Props.Tabindex = perevesti("0", True)
Окно30Окно30.Props.Tabstop = perevesti("Да", True)
Окно30Окно30.Props.Text = perevesti("Звуки", True)
Окно30Окно30.Props.Backgroundimage = perevesti("Никакой", True)
Окно30Окно30.Props.Backcolor = perevesti("Системный", True)
Окно30Окно30.Props.Forecolor = perevesti("Черный", True)
Окно30Окно30.Props.Height = perevesti("320", True)
Окно30Окно30.Props.Width = perevesti("500", True)
Окно30Окно30.Props.Visible = perevesti("Нет", True)
Окно30Окно30.Props.Height = perevesti("320", True)
Окно30Окно30.Props.Width = perevesti("500", True)

ProgressForm.ProgressBar1.Value = 71
Окно30Текстовый_документ10.Props.X = perevesti("4", True)
Окно30Текстовый_документ10.Props.Y = perevesti("4", True)
Окно30Текстовый_документ10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно30Текстовый_документ10.Props.Tag = perevesti("", True)
Окно30Текстовый_документ10.Props.Selectedtext = perevesti("", True)
Окно30Текстовый_документ10.Props.Selectionlength = perevesti("0", True)
Окно30Текстовый_документ10.Props.Name = perevesti("Текстовый документ1", True)
Окно30Текстовый_документ10.Props.Maximumheight = perevesti("0", True)
Окно30Текстовый_документ10.Props.Maximumlength = perevesti("32767", True)
Окно30Текстовый_документ10.Props.Maximumwidth = perevesti("0", True)
Окно30Текстовый_документ10.Props.Zoomfactor = perevesti("1", True)
Окно30Текстовый_документ10.Props.Minimumheight = perevesti("0", True)
Окно30Текстовый_документ10.Props.Minimumwidth = perevesti("0", True)
Окно30Текстовый_документ10.Props.Multiline = perevesti("Да", True)
Окно30Текстовый_документ10.Props.Selectionstart = perevesti("1", True)
Окно30Текстовый_документ10.Props.Index = perevesti("0", True)
Окно30Текстовый_документ10.Props.Wordwrap = perevesti("Нет", True)
Окно30Текстовый_документ10.Props.Internetlink = perevesti("Да", True)
Окно30Текстовый_документ10.Props.Detecturls = perevesti("Да", True)
Окно30Текстовый_документ10.Props.ToolTip = perevesti("", True)
Окно30Текстовый_документ10.Props.Enableautodragdrop = perevesti("Да", True)
Окно30Текстовый_документ10.Props.Scrollbars = perevesti("Вертикальная", True)
Окно30Текстовый_документ10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно30Текстовый_документ10.Props.Enabled = perevesti("Да", True)
Окно30Текстовый_документ10.Props.Dock = perevesti("Никакой", True)
Окно30Текстовый_документ10.Props.Hideselection = perevesti("Нет", True)
Окно30Текстовый_документ10.Props.Borderstyle = perevesti("объем", True)
Окно30Текстовый_документ10.Props.Tabindex = perevesti("0", True)
Окно30Текстовый_документ10.Props.Tabstop = perevesti("Да", True)
Окно30Текстовый_документ10.Props.Text = perevesti("[Sounds]·; IDS_SCHEME_DEFAULT·SchemeName=Gears of War Glass·[AppEvents\Schemes\Apps\.Default\.Default]·DefaultValue=%SystemRoot%\Resources\Themes\ //звонок.wav·[AppEvents\Schemes\Apps\.Default\ChangeTheme]·DefaultValue=%SystemRoot%\Resources\Themes\ //вход звука.wav·[AppEvents\Schemes\Apps\.Default\CriticalBatteryAlarm]·DefaultValue=%SystemRoot%\Resources\Themes\ //батарея критична.wav·[AppEvents\Schemes\Apps\.Default\DeviceConnect]·DefaultValue=%SystemRoot%\Resources\Themes\ //аппаратная вставки.wav·[AppEvents\Schemes\Apps\.Default\DeviceDisconnect]·DefaultValue=%SystemRoot%\Resources\Themes\ //аппаратного удаления.wav·[AppEvents\Schemes\Apps\.Default\DeviceFail]·DefaultValue=%SystemRoot%\Resources\Themes\ //аппаратная не удача.wav·[AppEvents\Schemes\Apps\.Default\FaxBeep]·DefaultValue=%SystemRoot%\Resources\Themes\ //подписаться.wav·[AppEvents\Schemes\Apps\.Default\LowBatteryAlarm]·DefaultValue=%SystemRoot%\Resources\Themes\ //батарея разряжена.wav·[AppEvents\Schemes\Apps\.Default\MailBeep]·DefaultValue=%SystemRoot%\Resources\Themes\ //майл сигнал.wav·[AppEvents\Schemes\Apps\.Default\PrintComplete]·DefaultValue=%SystemRoot%\Resources\Themes\ //печать завершена.wav·[AppEvents\Schemes\Apps\.Default\SystemAsterisk]·DefaultValue=%SystemRoot%\Resources\Themes\ //ошибка.wav·[AppEvents\Schemes\Apps\.Default\SystemExclamation]·DefaultValue=%SystemRoot%\Resources\Themes\ //восклицание.wav·[AppEvents\Schemes\Apps\.Default\SystemExit]·DefaultValue=%SystemRoot%\Resources\Themes\ //выключение.wav·[AppEvents\Schemes\Apps\.Default\SystemHand]·DefaultValue=%SystemRoot%\Resources\Themes\ //критическая остановка.wav·[AppEvents\Schemes\Apps\.Default\SystemNotification]·DefaultValue=%SystemRoot%\Resources\Themes\ //модификация не сделана.wav·[AppEvents\Schemes\Apps\.Default\WindowsLogoff]·DefaultValue=%SystemRoot%\Resources\Themes\ //выход звука.wav·[AppEvents\Schemes\Apps\.Default\WindowsLogon]·DefaultValue=%SystemRoot%\Resources\Themes\ //вход звука.wav·[AppEvents\Schemes\Apps\.Default\WindowsUAC]·DefaultValue=%SystemRoot%\Resources\Themes\ //контроль учетных записей.wav·[AppEvents\Schemes\Apps\Explorer\BlockedPopup]·DefaultValue=%SystemRoot%\Resources\Themes\ //окно не отвечает.wav·[AppEvents\Schemes\Apps\Explorer\EmptyRecycleBin]·DefaultValue=%SystemRoot%\Resources\Themes\ // рецикл.wav·[AppEvents\Schemes\Apps\Explorer\FaxError]·DefaultValue=%SystemRoot%\Resources\Themes\ //звонок ошибки.wav·[AppEvents\Schemes\Apps\Explorer\FaxLineRings]·DefaultValue=%SystemRoot%\Resources\Themes\ //кольца линии факса.wav·[AppEvents\Schemes\Apps\Explorer\FeedDiscovered]·DefaultValue=%SystemRoot%\Resources\Themes\ //питание есть.wav·[AppEvents\Schemes\Apps\Explorer\Navigating]·DefaultValue=%SystemRoot%\Resources\Themes\ //навигация старт.wav·[AppEvents\Schemes\Apps\Explorer\SecurityBand]·DefaultValue=%SystemRoot%\Resources\Themes\ //инфо панель.wav·", True)
Окно30Текстовый_документ10.Props.Readonly = perevesti("Нет", True)
Окно30Текстовый_документ10.Props.Backcolor = perevesti("Белый", True)
Окно30Текстовый_документ10.Props.Forecolor = perevesti("Черный", True)
Окно30Текстовый_документ10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно30Текстовый_документ10.Props.Fontbold = perevesti("Нет", True)
Окно30Текстовый_документ10.Props.Fontstrikeout = perevesti("Нет", True)
Окно30Текстовый_документ10.Props.Fontitalic = perevesti("Нет", True)
Окно30Текстовый_документ10.Props.Fontunderline = perevesti("Нет", True)
Окно30Текстовый_документ10.Props.Fontsize = perevesti("8", True)
Окно30Текстовый_документ10.Props.Height = perevesti("287", True)
Окно30Текстовый_документ10.Props.Width = perevesti("411", True)
Окно30Текстовый_документ10.Props.Visible = perevesti("Да", True)
Окно30Текстовый_документ10.Props.Height = perevesti("287", True)
Окно30Текстовый_документ10.Props.Width = perevesti("411", True)
Окно30Текстовый_документ10.Props.Rtf = perevesti("{\rtf1\ansi\ansicpg1251\deff0{\fonttbl{\f0\fnil\fcharset204 Microsoft Sans Serif;}}¶\viewkind4\uc1\pard\lang1049\f0\fs17 [Sounds]\par¶; IDS_SCHEME_DEFAULT\par¶SchemeName=Gears of War Glass\par¶[AppEvents\\Schemes\\Apps\\.Default\\.Default]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e7\'e2\'ee\'ed\'ee\'ea.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\ChangeTheme]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'f5\'ee\'e4 \'e7\'e2\'f3\'ea\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\CriticalBatteryAlarm]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e1\'e0\'f2\'e0\'f0\'e5\'ff \'ea\'f0\'e8\'f2\'e8\'f7\'ed\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\DeviceConnect]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e0\'ef\'ef\'e0\'f0\'e0\'f2\'ed\'e0\'ff \'e2\'f1\'f2\'e0\'e2\'ea\'e8.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\DeviceDisconnect]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e0\'ef\'ef\'e0\'f0\'e0\'f2\'ed\'ee\'e3\'ee \'f3\'e4\'e0\'eb\'e5\'ed\'e8\'ff.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\DeviceFail]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e0\'ef\'ef\'e0\'f0\'e0\'f2\'ed\'e0\'ff \'ed\'e5 \'f3\'e4\'e0\'f7\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\FaxBeep]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ef\'ee\'e4\'ef\'e8\'f1\'e0\'f2\'fc\'f1\'ff.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\LowBatteryAlarm]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e1\'e0\'f2\'e0\'f0\'e5\'ff \'f0\'e0\'e7\'f0\'ff\'e6\'e5\'ed\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\MailBeep]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ec\'e0\'e9\'eb \'f1\'e8\'e3\'ed\'e0\'eb.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\PrintComplete]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ef\'e5\'f7\'e0\'f2\'fc \'e7\'e0\'e2\'e5\'f0\'f8\'e5\'ed\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\SystemAsterisk]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ee\'f8\'e8\'e1\'ea\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\SystemExclamation]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'ee\'f1\'ea\'eb\'e8\'f6\'e0\'ed\'e8\'e5.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\SystemExit]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'fb\'ea\'eb\'fe\'f7\'e5\'ed\'e8\'e5.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\SystemHand]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ea\'f0\'e8\'f2\'e8\'f7\'e5\'f1\'ea\'e0\'ff \'ee\'f1\'f2\'e0\'ed\'ee\'e2\'ea\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\SystemNotification]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ec\'ee\'e4\'e8\'f4\'e8\'ea\'e0\'f6\'e8\'ff \'ed\'e5 \'f1\'e4\'e5\'eb\'e0\'ed\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\WindowsLogoff]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'fb\'f5\'ee\'e4 \'e7\'e2\'f3\'ea\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\WindowsLogon]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'f5\'ee\'e4 \'e7\'e2\'f3\'ea\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\.Default\\WindowsUAC]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ea\'ee\'ed\'f2\'f0\'ee\'eb\'fc \'f3\'f7\'e5\'f2\'ed\'fb\'f5 \'e7\'e0\'ef\'e8\'f1\'e5\'e9.wav\par¶[AppEvents\\Schemes\\Apps\\Explorer\\BlockedPopup]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ee\'ea\'ed\'ee \'ed\'e5 \'ee\'f2\'e2\'e5\'f7\'e0\'e5\'f2.wav\par¶[AppEvents\\Schemes\\Apps\\Explorer\\EmptyRecycleBin]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ // \'f0\'e5\'f6\'e8\'ea\'eb.wav\par¶[AppEvents\\Schemes\\Apps\\Explorer\\FaxError]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e7\'e2\'ee\'ed\'ee\'ea \'ee\'f8\'e8\'e1\'ea\'e8.wav\par¶[AppEvents\\Schemes\\Apps\\Explorer\\FaxLineRings]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ea\'ee\'eb\'fc\'f6\'e0 \'eb\'e8\'ed\'e8\'e8 \'f4\'e0\'ea\'f1\'e0.wav\par¶[AppEvents\\Schemes\\Apps\\Explorer\\FeedDiscovered]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ef\'e8\'f2\'e0\'ed\'e8\'e5 \'e5\'f1\'f2\'fc.wav\par¶[AppEvents\\Schemes\\Apps\\Explorer\\Navigating]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ed\'e0\'e2\'e8\'e3\'e0\'f6\'e8\'ff \'f1\'f2\'e0\'f0\'f2.wav\par¶[AppEvents\\Schemes\\Apps\\Explorer\\SecurityBand]\par¶DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e8\'ed\'f4\'ee \'ef\'e0\'ed\'e5\'eb\'fc.wav\par¶\par¶}¶", True)

ProgressForm.ProgressBar1.Value = 72
Окно30Кнопка10.Props.X = perevesti("420", True)
Окно30Кнопка10.Props.Y = perevesti("4", True)
Окно30Кнопка10.Props.Autoellipsis = perevesti("Да", True)
Окно30Кнопка10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно30Кнопка10.Props.Tag = perevesti("", True)
Окно30Кнопка10.Props.Name = perevesti("Кнопка1", True)
Окно30Кнопка10.Props.Cursor = perevesti("Обычный", True)
Окно30Кнопка10.Props.Maximumheight = perevesti("0", True)
Окно30Кнопка10.Props.Maximumwidth = perevesti("0", True)
Окно30Кнопка10.Props.Minimumheight = perevesti("0", True)
Окно30Кнопка10.Props.Minimumwidth = perevesti("0", True)
Окно30Кнопка10.Props.Index = perevesti("0", True)
Окно30Кнопка10.Props.ToolTip = perevesti("", True)
Окно30Кнопка10.Props.Paddingtop = perevesti("0", True)
Окно30Кнопка10.Props.Paddingleft = perevesti("0", True)
Окно30Кнопка10.Props.Paddingbottom = perevesti("0", True)
Окно30Кнопка10.Props.Paddingright = perevesti("0", True)
Окно30Кнопка10.Props.Imagealign = perevesti("Центр", True)
Окно30Кнопка10.Props.Textalign = perevesti("центр", True)
Окно30Кнопка10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно30Кнопка10.Props.Enabled = perevesti("Да", True)
Окно30Кнопка10.Props.Dock = perevesti("Никакой", True)
Окно30Кнопка10.Props.Image = perevesti("Никакой", True)
Окно30Кнопка10.Props.Flatstyle = perevesti("Обычный", True)
Окно30Кнопка10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно30Кнопка10.Props.Tabindex = perevesti("0", True)
Окно30Кнопка10.Props.Tabstop = perevesti("Да", True)
Окно30Кнопка10.Props.Text = perevesti("Далее", True)
Окно30Кнопка10.Props.Textimagerelation = perevesti("Поверх", True)
Окно30Кнопка10.Props.Backgroundimage = perevesti("Никакой", True)
Окно30Кнопка10.Props.Backcolor = perevesti("Никакой", True)
Окно30Кнопка10.Props.Forecolor = perevesti("Черный", True)
Окно30Кнопка10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно30Кнопка10.Props.Fontbold = perevesti("Нет", True)
Окно30Кнопка10.Props.Fontstrikeout = perevesti("Нет", True)
Окно30Кнопка10.Props.Fontitalic = perevesti("Нет", True)
Окно30Кнопка10.Props.Fontunderline = perevesti("Нет", True)
Окно30Кнопка10.Props.Fontsize = perevesti("8", True)
Окно30Кнопка10.Props.Height = perevesti("23", True)
Окно30Кнопка10.Props.Width = perevesti("75", True)
Окно30Кнопка10.Props.Visible = perevesti("Да", True)
Окно30Кнопка10.Props.Height = perevesti("23", True)
Окно30Кнопка10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 73
Окно30Кнопка20.Props.X = perevesti("424", True)
Окно30Кнопка20.Props.Y = perevesti("296", True)
Окно30Кнопка20.Props.Autoellipsis = perevesti("Да", True)
Окно30Кнопка20.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно30Кнопка20.Props.Tag = perevesti("", True)
Окно30Кнопка20.Props.Name = perevesti("Кнопка2", True)
Окно30Кнопка20.Props.Cursor = perevesti("Обычный", True)
Окно30Кнопка20.Props.Maximumheight = perevesti("0", True)
Окно30Кнопка20.Props.Maximumwidth = perevesti("0", True)
Окно30Кнопка20.Props.Minimumheight = perevesti("0", True)
Окно30Кнопка20.Props.Minimumwidth = perevesti("0", True)
Окно30Кнопка20.Props.Index = perevesti("0", True)
Окно30Кнопка20.Props.ToolTip = perevesti("", True)
Окно30Кнопка20.Props.Paddingtop = perevesti("0", True)
Окно30Кнопка20.Props.Paddingleft = perevesti("0", True)
Окно30Кнопка20.Props.Paddingbottom = perevesti("0", True)
Окно30Кнопка20.Props.Paddingright = perevesti("0", True)
Окно30Кнопка20.Props.Imagealign = perevesti("Центр", True)
Окно30Кнопка20.Props.Textalign = perevesti("центр", True)
Окно30Кнопка20.Props.Anchor = perevesti("Слева_Сверху", True)
Окно30Кнопка20.Props.Enabled = perevesti("Да", True)
Окно30Кнопка20.Props.Dock = perevesti("Никакой", True)
Окно30Кнопка20.Props.Image = perevesti("Никакой", True)
Окно30Кнопка20.Props.Flatstyle = perevesti("Обычный", True)
Окно30Кнопка20.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно30Кнопка20.Props.Tabindex = perevesti("0", True)
Окно30Кнопка20.Props.Tabstop = perevesti("Да", True)
Окно30Кнопка20.Props.Text = perevesti("Открыть", True)
Окно30Кнопка20.Props.Textimagerelation = perevesti("Поверх", True)
Окно30Кнопка20.Props.Backgroundimage = perevesti("Никакой", True)
Окно30Кнопка20.Props.Backcolor = perevesti("Никакой", True)
Окно30Кнопка20.Props.Forecolor = perevesti("Черный", True)
Окно30Кнопка20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно30Кнопка20.Props.Fontbold = perevesti("Нет", True)
Окно30Кнопка20.Props.Fontstrikeout = perevesti("Нет", True)
Окно30Кнопка20.Props.Fontitalic = perevesti("Нет", True)
Окно30Кнопка20.Props.Fontunderline = perevesti("Нет", True)
Окно30Кнопка20.Props.Fontsize = perevesti("8", True)
Окно30Кнопка20.Props.Height = perevesti("23", True)
Окно30Кнопка20.Props.Width = perevesti("75", True)
Окно30Кнопка20.Props.Visible = perevesti("Да", True)
Окно30Кнопка20.Props.Height = perevesti("23", True)
Окно30Кнопка20.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 74
Окно30Текст10.Props.X = perevesti("4", True)
Окно30Текст10.Props.Y = perevesti("296", True)
Окно30Текст10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно30Текст10.Props.Tag = perevesti("", True)
Окно30Текст10.Props.Selectedtext = perevesti("", True)
Окно30Текст10.Props.Selectionlength = perevesti("0", True)
Окно30Текст10.Props.Name = perevesti("Текст1", True)
Окно30Текст10.Props.Maximumheight = perevesti("0", True)
Окно30Текст10.Props.Maximumlength = perevesti("32767", True)
Окно30Текст10.Props.Maximumwidth = perevesti("0", True)
Окно30Текст10.Props.Minimumheight = perevesti("0", True)
Окно30Текст10.Props.Minimumwidth = perevesti("0", True)
Окно30Текст10.Props.Multiline = perevesti("Нет", True)
Окно30Текст10.Props.Selectionstart = perevesti("1", True)
Окно30Текст10.Props.Index = perevesti("0", True)
Окно30Текст10.Props.Wordwrap = perevesti("Да", True)
Окно30Текст10.Props.ToolTip = perevesti("", True)
Окно30Текст10.Props.Scrollbars = perevesti("Нет", True)
Окно30Текст10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно30Текст10.Props.Enabled = perevesti("Да", True)
Окно30Текст10.Props.Allowinput = perevesti("Все", True)
Окно30Текст10.Props.Textposition = perevesti("Слева", True)
Окно30Текст10.Props.Dock = perevesti("Никакой", True)
Окно30Текст10.Props.Passwordchar = perevesti("", True)
Окно30Текст10.Props.Hideselection = perevesti("Нет", True)
Окно30Текст10.Props.Borderstyle = perevesti("объем", True)
Окно30Текст10.Props.Tabindex = perevesti("0", True)
Окно30Текст10.Props.Tabstop = perevesti("Да", True)
Окно30Текст10.Props.Text = perevesti("", True)
Окно30Текст10.Props.Readonly = perevesti("Нет", True)
Окно30Текст10.Props.Backcolor = perevesti("Белый", True)
Окно30Текст10.Props.Forecolor = perevesti("Черный", True)
Окно30Текст10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно30Текст10.Props.Fontbold = perevesti("Нет", True)
Окно30Текст10.Props.Fontstrikeout = perevesti("Нет", True)
Окно30Текст10.Props.Fontitalic = perevesti("Нет", True)
Окно30Текст10.Props.Fontunderline = perevesti("Нет", True)
Окно30Текст10.Props.Fontsize = perevesti("8", True)
Окно30Текст10.Props.Height = perevesti("20", True)
Окно30Текст10.Props.Width = perevesti("343", True)
Окно30Текст10.Props.Visible = perevesti("Да", True)
Окно30Текст10.Props.Height = perevesti("20", True)
Окно30Текст10.Props.Width = perevesti("343", True)

ProgressForm.ProgressBar1.Value = 75
Окно30Окно_открытия10.Props.X = perevesti("4", True)
Окно30Окно_открытия10.Props.Y = perevesti("4", True)
Окно30Окно_открытия10.Props.Tag = perevesti("", True)
Окно30Окно_открытия10.Props.Multiselectfiles = perevesti("Нет", True)
Окно30Окно_открытия10.Props.Defaultext = perevesti("", True)
Окно30Окно_открытия10.Props.Title = perevesti("", True)
Окно30Окно_открытия10.Props.Name = perevesti("Окно открытия1", True)
Окно30Окно_открытия10.Props.Filename = perevesti("", True)
Окно30Окно_открытия10.Props.Initialdirectory = perevesti("", True)
Окно30Окно_открытия10.Props.Index = perevesti("0", True)
Окно30Окно_открытия10.Props.Filterindex = perevesti("1", True)
Окно30Окно_открытия10.Props.Checkpathexists = perevesti("Да", True)
Окно30Окно_открытия10.Props.Checkfileexists = perevesti("Да", True)
Окно30Окно_открытия10.Props.Filter = perevesti("Рисунки|*.wav;*.mp3|Все файлы|*.*", True)

ProgressForm.ProgressBar1.Value = 76
Окно30Кнопка30.Props.X = perevesti("348", True)
Окно30Кнопка30.Props.Y = perevesti("296", True)
Окно30Кнопка30.Props.Autoellipsis = perevesti("Да", True)
Окно30Кнопка30.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно30Кнопка30.Props.Tag = perevesti("", True)
Окно30Кнопка30.Props.Name = perevesti("Кнопка3", True)
Окно30Кнопка30.Props.Cursor = perevesti("Обычный", True)
Окно30Кнопка30.Props.Maximumheight = perevesti("0", True)
Окно30Кнопка30.Props.Maximumwidth = perevesti("0", True)
Окно30Кнопка30.Props.Minimumheight = perevesti("0", True)
Окно30Кнопка30.Props.Minimumwidth = perevesti("0", True)
Окно30Кнопка30.Props.Index = perevesti("0", True)
Окно30Кнопка30.Props.ToolTip = perevesti("", True)
Окно30Кнопка30.Props.Paddingtop = perevesti("0", True)
Окно30Кнопка30.Props.Paddingleft = perevesti("0", True)
Окно30Кнопка30.Props.Paddingbottom = perevesti("0", True)
Окно30Кнопка30.Props.Paddingright = perevesti("0", True)
Окно30Кнопка30.Props.Imagealign = perevesti("Центр", True)
Окно30Кнопка30.Props.Textalign = perevesti("центр", True)
Окно30Кнопка30.Props.Anchor = perevesti("Слева_Сверху", True)
Окно30Кнопка30.Props.Enabled = perevesti("Да", True)
Окно30Кнопка30.Props.Dock = perevesti("Никакой", True)
Окно30Кнопка30.Props.Image = perevesti("Никакой", True)
Окно30Кнопка30.Props.Flatstyle = perevesti("Обычный", True)
Окно30Кнопка30.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно30Кнопка30.Props.Tabindex = perevesti("0", True)
Окно30Кнопка30.Props.Tabstop = perevesti("Да", True)
Окно30Кнопка30.Props.Text = perevesti("Копировать", True)
Окно30Кнопка30.Props.Textimagerelation = perevesti("Поверх", True)
Окно30Кнопка30.Props.Backgroundimage = perevesti("Никакой", True)
Окно30Кнопка30.Props.Backcolor = perevesti("Никакой", True)
Окно30Кнопка30.Props.Forecolor = perevesti("Черный", True)
Окно30Кнопка30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно30Кнопка30.Props.Fontbold = perevesti("Нет", True)
Окно30Кнопка30.Props.Fontstrikeout = perevesti("Нет", True)
Окно30Кнопка30.Props.Fontitalic = perevesti("Нет", True)
Окно30Кнопка30.Props.Fontunderline = perevesti("Нет", True)
Окно30Кнопка30.Props.Fontsize = perevesti("8", True)
Окно30Кнопка30.Props.Height = perevesti("23", True)
Окно30Кнопка30.Props.Width = perevesti("75", True)
Окно30Кнопка30.Props.Visible = perevesti("Да", True)
Окно30Кнопка30.Props.Height = perevesti("23", True)
Окно30Кнопка30.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 77
Окно40Окно40.Props.X = perevesti("0", True)
Окно40Окно40.Props.Y = perevesti("0", True)
Окно40Окно40.Props.Associatewithextensions = perevesti("", True)
Окно40Окно40.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно40Окно40.Props.Tag = perevesti("", True)
Окно40Окно40.Props.Mainform = perevesti("Нет", True)
Окно40Окно40.Props.Mainmenustrip(True) = perevesti("Никакой", True)
Окно40Окно40.Props.AutoRun = perevesti("Нет", True)
Окно40Окно40.Props.Forbidclose = perevesti("Нет", True)
Окно40Окно40.Props.Forbidminimize = perevesti("Нет", True)
Окно40Окно40.Props.Forbidmaximize = perevesti("Да", True)
Окно40Окно40.Props.Icon = perevesti("Никакой", True)
Окно40Окно40.Props.Name = perevesti("Окно4", True)
Окно40Окно40.Props.Cursor = perevesti("Обычный", True)
Окно40Окно40.Props.Maximumheight = perevesti("0", True)
Окно40Окно40.Props.Maximumwidth = perevesti("0", True)
Окно40Окно40.Props.Minimumheight = perevesti("0", True)
Окно40Окно40.Props.Minimumwidth = perevesti("0", True)
Окно40Окно40.Props.Index = perevesti("0", True)
Окно40Окно40.Props.Controlbox = perevesti("Да", True)
Окно40Окно40.Props.Showintaskbar = perevesti("Да", True)
Окно40Окно40.Props.Showintray = perevesti("Нет", True)
Окно40Окно40.Props.TopMost = perevesti("Нет", True)
Окно40Окно40.Props.ToolTip = perevesti("", True)
Окно40Окно40.Props.Showicon = perevesti("Нет", True)
Окно40Окно40.Props.Opacity = perevesti("100", True)
Окно40Окно40.Props.Transparentcykey = perevesti("Никакой", True)
Окно40Окно40.Props.Scroll = perevesti("Нет", True)
Окно40Окно40.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно40Окно40.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно40Окно40.Props.AutoscrollpositionX = perevesti("0", True)
Окно40Окно40.Props.AutoscrollpositionY = perevesti("0", True)
Окно40Окно40.Props.Enabled = perevesti("Нет", True)
Окно40Окно40.Props.Allowruncopies = perevesti("Да", True)
Окно40Окно40.Props.Startposition = perevesti("по центру экрана", True)
Окно40Окно40.StatusTemp = "Нормальный"
Окно40Окно40.Props.Formborderstyle = perevesti("фиксированное окно", True)
Окно40Окно40.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно40Окно40.Props.Tabindex = perevesti("0", True)
Окно40Окно40.Props.Tabstop = perevesti("Да", True)
Окно40Окно40.Props.Text = perevesti("Меняющиеся картинка", True)
Окно40Окно40.Props.Backgroundimage = perevesti("Никакой", True)
Окно40Окно40.Props.Backcolor = perevesti("Системный", True)
Окно40Окно40.Props.Forecolor = perevesti("Черный", True)
Окно40Окно40.Props.Height = perevesti("323", True)
Окно40Окно40.Props.Width = perevesti("503", True)
Окно40Окно40.Props.Visible = perevesti("Нет", True)
Окно40Окно40.Props.Height = perevesti("323", True)
Окно40Окно40.Props.Width = perevesti("503", True)

ProgressForm.ProgressBar1.Value = 78
Окно40Текстовый_документ10.Props.X = perevesti("4", True)
Окно40Текстовый_документ10.Props.Y = perevesti("4", True)
Окно40Текстовый_документ10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно40Текстовый_документ10.Props.Tag = perevesti("", True)
Окно40Текстовый_документ10.Props.Selectedtext = perevesti("", True)
Окно40Текстовый_документ10.Props.Selectionlength = perevesti("0", True)
Окно40Текстовый_документ10.Props.Name = perevesti("Текстовый документ1", True)
Окно40Текстовый_документ10.Props.Maximumheight = perevesti("0", True)
Окно40Текстовый_документ10.Props.Maximumlength = perevesti("32767", True)
Окно40Текстовый_документ10.Props.Maximumwidth = perevesti("0", True)
Окно40Текстовый_документ10.Props.Zoomfactor = perevesti("1", True)
Окно40Текстовый_документ10.Props.Minimumheight = perevesti("0", True)
Окно40Текстовый_документ10.Props.Minimumwidth = perevesti("0", True)
Окно40Текстовый_документ10.Props.Multiline = perevesti("Да", True)
Окно40Текстовый_документ10.Props.Selectionstart = perevesti("1", True)
Окно40Текстовый_документ10.Props.Index = perevesti("0", True)
Окно40Текстовый_документ10.Props.Wordwrap = perevesti("Нет", True)
Окно40Текстовый_документ10.Props.Internetlink = perevesti("Да", True)
Окно40Текстовый_документ10.Props.Detecturls = perevesti("Да", True)
Окно40Текстовый_документ10.Props.ToolTip = perevesti("", True)
Окно40Текстовый_документ10.Props.Enableautodragdrop = perevesti("Да", True)
Окно40Текстовый_документ10.Props.Scrollbars = perevesti("Вертикальная", True)
Окно40Текстовый_документ10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно40Текстовый_документ10.Props.Enabled = perevesti("Да", True)
Окно40Текстовый_документ10.Props.Dock = perevesti("Никакой", True)
Окно40Текстовый_документ10.Props.Hideselection = perevesti("Нет", True)
Окно40Текстовый_документ10.Props.Borderstyle = perevesti("объем", True)
Окно40Текстовый_документ10.Props.Tabindex = perevesti("0", True)
Окно40Текстовый_документ10.Props.Tabstop = perevesti("Да", True)
Окно40Текстовый_документ10.Props.Text = perevesti("··[Slideshow]·Interval=1800000·Shuffle=0·ImagesRootPath=%SystemRoot%\Resources\Themes\ //папка с рисунками·Item0Path=%SystemRoot%\Resources\Themes\ //1 рисунок·Item1Path=%SystemRoot%\Resources\Themes\ //2 рисунок·Item2Path=%SystemRoot%\Resources\Themes\ //3 рисунок·Item3Path=%SystemRoot%\Resources\Themes\ //4 рисунок·Item4Path=%SystemRoot%\Resources\Themes\ //5 рисунок·Item5Path=%SystemRoot%\Resources\Themes\ //6 рисунок··", True)
Окно40Текстовый_документ10.Props.Readonly = perevesti("Нет", True)
Окно40Текстовый_документ10.Props.Backcolor = perevesti("Белый", True)
Окно40Текстовый_документ10.Props.Forecolor = perevesti("Черный", True)
Окно40Текстовый_документ10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно40Текстовый_документ10.Props.Fontbold = perevesti("Нет", True)
Окно40Текстовый_документ10.Props.Fontstrikeout = perevesti("Нет", True)
Окно40Текстовый_документ10.Props.Fontitalic = perevesti("Нет", True)
Окно40Текстовый_документ10.Props.Fontunderline = perevesti("Нет", True)
Окно40Текстовый_документ10.Props.Fontsize = perevesti("8", True)
Окно40Текстовый_документ10.Props.Height = perevesti("315", True)
Окно40Текстовый_документ10.Props.Width = perevesti("419", True)
Окно40Текстовый_документ10.Props.Visible = perevesti("Да", True)
Окно40Текстовый_документ10.Props.Height = perevesti("315", True)
Окно40Текстовый_документ10.Props.Width = perevesti("419", True)
Окно40Текстовый_документ10.Props.Rtf = perevesti("{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset204 Microsoft Sans Serif;}}¶\viewkind4\uc1\pard\lang1049\f0\fs17\par¶\par¶[Slideshow]\par¶Interval=1800000\par¶Shuffle=0\par¶ImagesRootPath=%SystemRoot%\\Resources\\Themes\\ //\'ef\'e0\'ef\'ea\'e0 \'f1 \'f0\'e8\'f1\'f3\'ed\'ea\'e0\'ec\'e8\par¶Item0Path=%SystemRoot%\\Resources\\Themes\\ //1 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par¶Item1Path=%SystemRoot%\\Resources\\Themes\\ //2 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par¶Item2Path=%SystemRoot%\\Resources\\Themes\\ //3 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par¶Item3Path=%SystemRoot%\\Resources\\Themes\\ //4 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par¶Item4Path=%SystemRoot%\\Resources\\Themes\\ //5 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par¶Item5Path=%SystemRoot%\\Resources\\Themes\\ //6 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par¶\par¶\par¶}¶", True)

ProgressForm.ProgressBar1.Value = 79
Окно40Кнопка10.Props.X = perevesti("424", True)
Окно40Кнопка10.Props.Y = perevesti("4", True)
Окно40Кнопка10.Props.Autoellipsis = perevesti("Да", True)
Окно40Кнопка10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно40Кнопка10.Props.Tag = perevesti("", True)
Окно40Кнопка10.Props.Name = perevesti("Кнопка1", True)
Окно40Кнопка10.Props.Cursor = perevesti("Обычный", True)
Окно40Кнопка10.Props.Maximumheight = perevesti("0", True)
Окно40Кнопка10.Props.Maximumwidth = perevesti("0", True)
Окно40Кнопка10.Props.Minimumheight = perevesti("0", True)
Окно40Кнопка10.Props.Minimumwidth = perevesti("0", True)
Окно40Кнопка10.Props.Index = perevesti("0", True)
Окно40Кнопка10.Props.ToolTip = perevesti("", True)
Окно40Кнопка10.Props.Paddingtop = perevesti("0", True)
Окно40Кнопка10.Props.Paddingleft = perevesti("0", True)
Окно40Кнопка10.Props.Paddingbottom = perevesti("0", True)
Окно40Кнопка10.Props.Paddingright = perevesti("0", True)
Окно40Кнопка10.Props.Imagealign = perevesti("Центр", True)
Окно40Кнопка10.Props.Textalign = perevesti("центр", True)
Окно40Кнопка10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно40Кнопка10.Props.Enabled = perevesti("Да", True)
Окно40Кнопка10.Props.Dock = perevesti("Никакой", True)
Окно40Кнопка10.Props.Image = perevesti("Никакой", True)
Окно40Кнопка10.Props.Flatstyle = perevesti("Обычный", True)
Окно40Кнопка10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно40Кнопка10.Props.Tabindex = perevesti("0", True)
Окно40Кнопка10.Props.Tabstop = perevesti("Да", True)
Окно40Кнопка10.Props.Text = perevesti("Создать", True)
Окно40Кнопка10.Props.Textimagerelation = perevesti("Поверх", True)
Окно40Кнопка10.Props.Backgroundimage = perevesti("Никакой", True)
Окно40Кнопка10.Props.Backcolor = perevesti("Никакой", True)
Окно40Кнопка10.Props.Forecolor = perevesti("Черный", True)
Окно40Кнопка10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно40Кнопка10.Props.Fontbold = perevesti("Нет", True)
Окно40Кнопка10.Props.Fontstrikeout = perevesti("Нет", True)
Окно40Кнопка10.Props.Fontitalic = perevesti("Нет", True)
Окно40Кнопка10.Props.Fontunderline = perevesti("Нет", True)
Окно40Кнопка10.Props.Fontsize = perevesti("8", True)
Окно40Кнопка10.Props.Height = perevesti("23", True)
Окно40Кнопка10.Props.Width = perevesti("75", True)
Окно40Кнопка10.Props.Visible = perevesti("Да", True)
Окно40Кнопка10.Props.Height = perevesti("23", True)
Окно40Кнопка10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 80
Окно40Кнопка20.Props.X = perevesti("424", True)
Окно40Кнопка20.Props.Y = perevesti("28", True)
Окно40Кнопка20.Props.Autoellipsis = perevesti("Да", True)
Окно40Кнопка20.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно40Кнопка20.Props.Tag = perevesti("", True)
Окно40Кнопка20.Props.Name = perevesti("Кнопка2", True)
Окно40Кнопка20.Props.Cursor = perevesti("Обычный", True)
Окно40Кнопка20.Props.Maximumheight = perevesti("0", True)
Окно40Кнопка20.Props.Maximumwidth = perevesti("0", True)
Окно40Кнопка20.Props.Minimumheight = perevesti("0", True)
Окно40Кнопка20.Props.Minimumwidth = perevesti("0", True)
Окно40Кнопка20.Props.Index = perevesti("0", True)
Окно40Кнопка20.Props.ToolTip = perevesti("", True)
Окно40Кнопка20.Props.Paddingtop = perevesti("0", True)
Окно40Кнопка20.Props.Paddingleft = perevesti("0", True)
Окно40Кнопка20.Props.Paddingbottom = perevesti("0", True)
Окно40Кнопка20.Props.Paddingright = perevesti("0", True)
Окно40Кнопка20.Props.Imagealign = perevesti("Центр", True)
Окно40Кнопка20.Props.Textalign = perevesti("центр", True)
Окно40Кнопка20.Props.Anchor = perevesti("Слева_Сверху", True)
Окно40Кнопка20.Props.Enabled = perevesti("Да", True)
Окно40Кнопка20.Props.Dock = perevesti("Никакой", True)
Окно40Кнопка20.Props.Image = perevesti("Никакой", True)
Окно40Кнопка20.Props.Flatstyle = perevesti("Обычный", True)
Окно40Кнопка20.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно40Кнопка20.Props.Tabindex = perevesti("0", True)
Окно40Кнопка20.Props.Tabstop = perevesti("Да", True)
Окно40Кнопка20.Props.Text = perevesti("Помощь", True)
Окно40Кнопка20.Props.Textimagerelation = perevesti("Поверх", True)
Окно40Кнопка20.Props.Backgroundimage = perevesti("Никакой", True)
Окно40Кнопка20.Props.Backcolor = perevesti("Никакой", True)
Окно40Кнопка20.Props.Forecolor = perevesti("Черный", True)
Окно40Кнопка20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно40Кнопка20.Props.Fontbold = perevesti("Нет", True)
Окно40Кнопка20.Props.Fontstrikeout = perevesti("Нет", True)
Окно40Кнопка20.Props.Fontitalic = perevesti("Нет", True)
Окно40Кнопка20.Props.Fontunderline = perevesti("Нет", True)
Окно40Кнопка20.Props.Fontsize = perevesti("8", True)
Окно40Кнопка20.Props.Height = perevesti("23", True)
Окно40Кнопка20.Props.Width = perevesti("75", True)
Окно40Кнопка20.Props.Visible = perevesti("Да", True)
Окно40Кнопка20.Props.Height = perevesti("23", True)
Окно40Кнопка20.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 81
Окно40Память10.Props.X = perevesti("4", True)
Окно40Память10.Props.Y = perevesti("4", True)
Окно40Память10.Props.Tag = perevesti("", True)
Окно40Память10.Props.Name = perevesti("Память1", True)
Окно40Память10.Props.Index = perevesti("0", True)
Окно40Память10.Props.Enabled = perevesti("Да", True)
Окно40Память10.Props.Value = perevesti("", True)

ProgressForm.ProgressBar1.Value = 82
Окно40Память20.Props.X = perevesti("32", True)
Окно40Память20.Props.Y = perevesti("4", True)
Окно40Память20.Props.Tag = perevesti("", True)
Окно40Память20.Props.Name = perevesti("Память2", True)
Окно40Память20.Props.Index = perevesti("0", True)
Окно40Память20.Props.Enabled = perevesti("Да", True)
Окно40Память20.Props.Value = perevesti("·[Control Panel\Cursors]·AppStarting=%SystemRoot%\cursors\aero_working.ani·Arrow=%SystemRoot%\cursors\aero_arrow.cur·Crosshair=·Hand=%SystemRoot%\cursors\aero_link.cur·Help=%SystemRoot%\cursors\aero_helpsel.cur·IBeam=·No=%SystemRoot%\cursors\aero_unavail.cur·NWPen=%SystemRoot%\cursors\aero_pen.cur·SizeAll=%SystemRoot%\cursors\aero_move.cur·SizeNESW=%SystemRoot%\cursors\aero_nesw.cur·SizeNS=%SystemRoot%\cursors\aero_ns.cur·SizeNWSE=%SystemRoot%\cursors\aero_nwse.cur·SizeWE=%SystemRoot%\cursors\aero_ew.cur·UpArrow=%SystemRoot%\cursors\aero_up.cur·Wait=%SystemRoot%\cursors\aero_busy.ani·DefaultValue=Windows Aero·Link=··[Control Panel\Desktop]·Wallpaper=%SystemRoot%\Resources\Themes\", True)

ProgressForm.ProgressBar1.Value = 83
Окно40Память30.Props.X = perevesti("60", True)
Окно40Память30.Props.Y = perevesti("4", True)
Окно40Память30.Props.Tag = perevesti("·TileWallpaper=0·WallpaperStyle=10·Pattern=··[VisualStyles]·Path=%SystemRoot%\Resources\Themes\new\new.msstyles·ColorStyle=NormalColor·Size=NormalSize·ColorizationColor=0X1A000000·Transparency=1·Composition=1·VisualStyleVersion=10··[boot]·SCRNSAVE.EXE=··[MasterThemeSelector]·MTSM=DABJDKT·", True)
Окно40Память30.Props.Name = perevesti("Память3", True)
Окно40Память30.Props.Index = perevesti("0", True)
Окно40Память30.Props.Enabled = perevesti("Да", True)
Окно40Память30.Props.Value = perevesti("", True)

ProgressForm.ProgressBar1.Value = 84
Окно40Окно_сохранения10.Props.X = perevesti("8", True)
Окно40Окно_сохранения10.Props.Y = perevesti("8", True)
Окно40Окно_сохранения10.Props.Tag = perevesti("", True)
Окно40Окно_сохранения10.Props.Defaultext = perevesti("", True)
Окно40Окно_сохранения10.Props.Title = perevesti("", True)
Окно40Окно_сохранения10.Props.Name = perevesti("Окно сохранения1", True)
Окно40Окно_сохранения10.Props.Filename = perevesti("", True)
Окно40Окно_сохранения10.Props.Initialdirectory = perevesti("", True)
Окно40Окно_сохранения10.Props.Index = perevesti("0", True)
Окно40Окно_сохранения10.Props.Filterindex = perevesti("1", True)
Окно40Окно_сохранения10.Props.Checkpathexists = perevesti("Да", True)
Окно40Окно_сохранения10.Props.Checkfileexists = perevesti("Нет", True)
Окно40Окно_сохранения10.Props.Filter = perevesti("Тема|*.theme", True)

ProgressForm.ProgressBar1.Value = 85
Окно40Надпись10.Props.X = perevesti("428", True)
Окно40Надпись10.Props.Y = perevesti("304", True)
Окно40Надпись10.Props.Autoellipsis = perevesti("Да", True)
Окно40Надпись10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно40Надпись10.Props.Tag = perevesti("", True)
Окно40Надпись10.Props.Name = perevesti("Надпись1", True)
Окно40Надпись10.Props.Cursor = perevesti("Обычный", True)
Окно40Надпись10.Props.Maximumheight = perevesti("0", True)
Окно40Надпись10.Props.Maximumwidth = perevesti("0", True)
Окно40Надпись10.Props.Minimumheight = perevesti("0", True)
Окно40Надпись10.Props.Minimumwidth = perevesti("0", True)
Окно40Надпись10.Props.Index = perevesti("0", True)
Окно40Надпись10.Props.ToolTip = perevesti("", True)
Окно40Надпись10.Props.Paddingtop = perevesti("0", True)
Окно40Надпись10.Props.Paddingleft = perevesti("0", True)
Окно40Надпись10.Props.Paddingbottom = perevesti("0", True)
Окно40Надпись10.Props.Paddingright = perevesti("0", True)
Окно40Надпись10.Props.Imagealign = perevesti("Центр", True)
Окно40Надпись10.Props.Textalign = perevesti("центр", True)
Окно40Надпись10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно40Надпись10.Props.Enabled = perevesti("Да", True)
Окно40Надпись10.Props.Dock = perevesti("Никакой", True)
Окно40Надпись10.Props.Image = perevesti("Никакой", True)
Окно40Надпись10.Props.Borderstyle = perevesti("Никакой", True)
Окно40Надпись10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно40Надпись10.Props.Tabindex = perevesti("0", True)
Окно40Надпись10.Props.Tabstop = perevesti("Да", True)
Окно40Надпись10.Props.Text = perevesti("Доработать", True)
Окно40Надпись10.Props.Backgroundimage = perevesti("Никакой", True)
Окно40Надпись10.Props.Backcolor = perevesti("Системный", True)
Окно40Надпись10.Props.Forecolor = perevesti("Черный", True)
Окно40Надпись10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно40Надпись10.Props.Fontbold = perevesti("Нет", True)
Окно40Надпись10.Props.Fontstrikeout = perevesti("Нет", True)
Окно40Надпись10.Props.Fontitalic = perevesti("Нет", True)
Окно40Надпись10.Props.Fontunderline = perevesti("Нет", True)
Окно40Надпись10.Props.Fontsize = perevesti("8", True)
Окно40Надпись10.Props.Height = perevesti("15", True)
Окно40Надпись10.Props.Width = perevesti("71", True)
Окно40Надпись10.Props.Visible = perevesti("Да", True)
Окно40Надпись10.Props.Height = perevesti("15", True)
Окно40Надпись10.Props.Width = perevesti("71", True)

ProgressForm.ProgressBar1.Value = 86
Окно50Окно50.Props.X = perevesti("0", True)
Окно50Окно50.Props.Y = perevesti("0", True)
Окно50Окно50.Props.Associatewithextensions = perevesti("", True)
Окно50Окно50.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно50Окно50.Props.Tag = perevesti("", True)
Окно50Окно50.Props.Mainform = perevesti("Нет", True)
Окно50Окно50.Props.Mainmenustrip(True) = perevesti("Никакой", True)
Окно50Окно50.Props.AutoRun = perevesti("Нет", True)
Окно50Окно50.Props.Forbidclose = perevesti("Нет", True)
Окно50Окно50.Props.Forbidminimize = perevesti("Нет", True)
Окно50Окно50.Props.Forbidmaximize = perevesti("Да", True)
Окно50Окно50.Props.Icon = perevesti("Никакой", True)
Окно50Окно50.Props.Name = perevesti("Окно5", True)
Окно50Окно50.Props.Cursor = perevesti("Обычный", True)
Окно50Окно50.Props.Maximumheight = perevesti("0", True)
Окно50Окно50.Props.Maximumwidth = perevesti("0", True)
Окно50Окно50.Props.Minimumheight = perevesti("0", True)
Окно50Окно50.Props.Minimumwidth = perevesti("0", True)
Окно50Окно50.Props.Index = perevesti("0", True)
Окно50Окно50.Props.Controlbox = perevesti("Да", True)
Окно50Окно50.Props.Showintaskbar = perevesti("Да", True)
Окно50Окно50.Props.Showintray = perevesti("Нет", True)
Окно50Окно50.Props.TopMost = perevesti("Нет", True)
Окно50Окно50.Props.ToolTip = perevesti("", True)
Окно50Окно50.Props.Showicon = perevesti("Нет", True)
Окно50Окно50.Props.Opacity = perevesti("100", True)
Окно50Окно50.Props.Transparentcykey = perevesti("Никакой", True)
Окно50Окно50.Props.Scroll = perevesti("Нет", True)
Окно50Окно50.Props.AutoscrollminSizeheight = perevesti("0", True)
Окно50Окно50.Props.AutoscrollminSizewidth = perevesti("0", True)
Окно50Окно50.Props.AutoscrollpositionX = perevesti("0", True)
Окно50Окно50.Props.AutoscrollpositionY = perevesti("0", True)
Окно50Окно50.Props.Enabled = perevesti("Нет", True)
Окно50Окно50.Props.Allowruncopies = perevesti("Да", True)
Окно50Окно50.Props.Startposition = perevesti("по центру экрана", True)
Окно50Окно50.StatusTemp = "Нормальный"
Окно50Окно50.Props.Formborderstyle = perevesti("фиксированное окно", True)
Окно50Окно50.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно50Окно50.Props.Tabindex = perevesti("0", True)
Окно50Окно50.Props.Tabstop = perevesti("Да", True)
Окно50Окно50.Props.Text = perevesti("Доработка", True)
Окно50Окно50.Props.Backgroundimage = perevesti("Никакой", True)
Окно50Окно50.Props.Backcolor = perevesti("Системный", True)
Окно50Окно50.Props.Forecolor = perevesti("Черный", True)
Окно50Окно50.Props.Height = perevesti("320", True)
Окно50Окно50.Props.Width = perevesti("500", True)
Окно50Окно50.Props.Visible = perevesti("Нет", True)
Окно50Окно50.Props.Height = perevesti("320", True)
Окно50Окно50.Props.Width = perevesti("500", True)

ProgressForm.ProgressBar1.Value = 86
Окно50Текстовый_документ10.Props.X = perevesti("4", True)
Окно50Текстовый_документ10.Props.Y = perevesti("4", True)
Окно50Текстовый_документ10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно50Текстовый_документ10.Props.Tag = perevesti("", True)
Окно50Текстовый_документ10.Props.Selectedtext = perevesti("", True)
Окно50Текстовый_документ10.Props.Selectionlength = perevesti("0", True)
Окно50Текстовый_документ10.Props.Name = perevesti("Текстовый документ1", True)
Окно50Текстовый_документ10.Props.Maximumheight = perevesti("0", True)
Окно50Текстовый_документ10.Props.Maximumlength = perevesti("32767", True)
Окно50Текстовый_документ10.Props.Maximumwidth = perevesti("0", True)
Окно50Текстовый_документ10.Props.Zoomfactor = perevesti("1", True)
Окно50Текстовый_документ10.Props.Minimumheight = perevesti("0", True)
Окно50Текстовый_документ10.Props.Minimumwidth = perevesti("0", True)
Окно50Текстовый_документ10.Props.Multiline = perevesti("Да", True)
Окно50Текстовый_документ10.Props.Selectionstart = perevesti("1", True)
Окно50Текстовый_документ10.Props.Index = perevesti("0", True)
Окно50Текстовый_документ10.Props.Wordwrap = perevesti("Да", True)
Окно50Текстовый_документ10.Props.Internetlink = perevesti("Да", True)
Окно50Текстовый_документ10.Props.Detecturls = perevesti("Да", True)
Окно50Текстовый_документ10.Props.ToolTip = perevesti("", True)
Окно50Текстовый_документ10.Props.Enableautodragdrop = perevesti("Да", True)
Окно50Текстовый_документ10.Props.Scrollbars = perevesti("Вертикальная", True)
Окно50Текстовый_документ10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно50Текстовый_документ10.Props.Enabled = perevesti("Да", True)
Окно50Текстовый_документ10.Props.Dock = perevesti("Никакой", True)
Окно50Текстовый_документ10.Props.Hideselection = perevesti("Нет", True)
Окно50Текстовый_документ10.Props.Borderstyle = perevesti("объем", True)
Окно50Текстовый_документ10.Props.Tabindex = perevesti("0", True)
Окно50Текстовый_документ10.Props.Tabstop = perevesti("Да", True)
Окно50Текстовый_документ10.Props.Text = perevesti("", True)
Окно50Текстовый_документ10.Props.Readonly = perevesti("Нет", True)
Окно50Текстовый_документ10.Props.Backcolor = perevesti("Белый", True)
Окно50Текстовый_документ10.Props.Forecolor = perevesti("Черный", True)
Окно50Текстовый_документ10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно50Текстовый_документ10.Props.Fontbold = perevesti("Нет", True)
Окно50Текстовый_документ10.Props.Fontstrikeout = perevesti("Нет", True)
Окно50Текстовый_документ10.Props.Fontitalic = perevesti("Нет", True)
Окно50Текстовый_документ10.Props.Fontunderline = perevesti("Нет", True)
Окно50Текстовый_документ10.Props.Fontsize = perevesti("8", True)
Окно50Текстовый_документ10.Props.Height = perevesti("311", True)
Окно50Текстовый_документ10.Props.Width = perevesti("411", True)
Окно50Текстовый_документ10.Props.Visible = perevesti("Да", True)
Окно50Текстовый_документ10.Props.Height = perevesti("311", True)
Окно50Текстовый_документ10.Props.Width = perevesti("411", True)
Окно50Текстовый_документ10.Props.Rtf = perevesti("{\rtf1\ansi\ansicpg1251\deff0\deflang1049{\fonttbl{\f0\fnil\fcharset204 Microsoft Sans Serif;}}¶\viewkind4\uc1\pard\f0\fs17\par¶}¶", True)

ProgressForm.ProgressBar1.Value = 87
Окно50Кнопка10.Props.X = perevesti("420", True)
Окно50Кнопка10.Props.Y = perevesti("4", True)
Окно50Кнопка10.Props.Autoellipsis = perevesti("Да", True)
Окно50Кнопка10.Props.Contextmenu(True) = perevesti("Никакой", True)
Окно50Кнопка10.Props.Tag = perevesti("", True)
Окно50Кнопка10.Props.Name = perevesti("Кнопка1", True)
Окно50Кнопка10.Props.Cursor = perevesti("Обычный", True)
Окно50Кнопка10.Props.Maximumheight = perevesti("0", True)
Окно50Кнопка10.Props.Maximumwidth = perevesti("0", True)
Окно50Кнопка10.Props.Minimumheight = perevesti("0", True)
Окно50Кнопка10.Props.Minimumwidth = perevesti("0", True)
Окно50Кнопка10.Props.Index = perevesti("0", True)
Окно50Кнопка10.Props.ToolTip = perevesti("", True)
Окно50Кнопка10.Props.Paddingtop = perevesti("0", True)
Окно50Кнопка10.Props.Paddingleft = perevesti("0", True)
Окно50Кнопка10.Props.Paddingbottom = perevesti("0", True)
Окно50Кнопка10.Props.Paddingright = perevesti("0", True)
Окно50Кнопка10.Props.Imagealign = perevesti("Центр", True)
Окно50Кнопка10.Props.Textalign = perevesti("центр", True)
Окно50Кнопка10.Props.Anchor = perevesti("Слева_Сверху", True)
Окно50Кнопка10.Props.Enabled = perevesti("Да", True)
Окно50Кнопка10.Props.Dock = perevesti("Никакой", True)
Окно50Кнопка10.Props.Image = perevesti("Никакой", True)
Окно50Кнопка10.Props.Flatstyle = perevesti("Обычный", True)
Окно50Кнопка10.Props.Backgroundimagelayout = perevesti("Плитка", True)
Окно50Кнопка10.Props.Tabindex = perevesti("0", True)
Окно50Кнопка10.Props.Tabstop = perevesti("Да", True)
Окно50Кнопка10.Props.Text = perevesti("Сохранить", True)
Окно50Кнопка10.Props.Textimagerelation = perevesti("Поверх", True)
Окно50Кнопка10.Props.Backgroundimage = perevesti("Никакой", True)
Окно50Кнопка10.Props.Backcolor = perevesti("Никакой", True)
Окно50Кнопка10.Props.Forecolor = perevesti("Черный", True)
Окно50Кнопка10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
Окно50Кнопка10.Props.Fontbold = perevesti("Нет", True)
Окно50Кнопка10.Props.Fontstrikeout = perevesti("Нет", True)
Окно50Кнопка10.Props.Fontitalic = perevesti("Нет", True)
Окно50Кнопка10.Props.Fontunderline = perevesti("Нет", True)
Окно50Кнопка10.Props.Fontsize = perevesti("8", True)
Окно50Кнопка10.Props.Height = perevesti("23", True)
Окно50Кнопка10.Props.Width = perevesti("75", True)
Окно50Кнопка10.Props.Visible = perevesti("Да", True)
Окно50Кнопка10.Props.Height = perevesti("23", True)
Окно50Кнопка10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 88
Окно50Окно_сохранения10.Props.X = perevesti("4", True)
Окно50Окно_сохранения10.Props.Y = perevesti("4", True)
Окно50Окно_сохранения10.Props.Tag = perevesti("", True)
Окно50Окно_сохранения10.Props.Defaultext = perevesti("", True)
Окно50Окно_сохранения10.Props.Title = perevesti("", True)
Окно50Окно_сохранения10.Props.Name = perevesti("Окно сохранения1", True)
Окно50Окно_сохранения10.Props.Filename = perevesti("", True)
Окно50Окно_сохранения10.Props.Initialdirectory = perevesti("", True)
Окно50Окно_сохранения10.Props.Index = perevesti("0", True)
Окно50Окно_сохранения10.Props.Filterindex = perevesti("1", True)
Окно50Окно_сохранения10.Props.Checkpathexists = perevesti("Да", True)
Окно50Окно_сохранения10.Props.Checkfileexists = perevesti("Нет", True)
Окно50Окно_сохранения10.Props.Filter = perevesti("Тема|*.theme", True)

ProgressForm.ProgressBar1.Value = 89
_Полезные_объекты0_Полезные_объекты0.Props.Name = "_Полезные объекты"

ProgressForm.ProgressBar1.Value = 90
_Полезные_объекты0_Экран0.Props.Name = "_Экран"

ProgressForm.ProgressBar1.Value = 91
_Полезные_объекты0_Файлы_и_папки0.Props.Name = "_Файлы и папки"

ProgressForm.ProgressBar1.Value = 92
_Полезные_объекты0_Прерывания0.Props.Name = "_Прерывания"

ProgressForm.ProgressBar1.Value = 93
_Полезные_объекты0_Система0.Props.Name = "_Система"

ProgressForm.ProgressBar1.Value = 94
_Полезные_объекты0_Реестр0.Props.Name = "_Реестр"

ProgressForm.ProgressBar1.Value = 95
_Полезные_объекты0_Вызвать_событие0.Props.Name = "_Вызвать событие"

ProgressForm.ProgressBar1.Value = 96
_Полезные_объекты0_Текст0.Props.Name = "_Текст"

ProgressForm.ProgressBar1.Value = 97
_Полезные_объекты0_Показать_сообщение0.Props.Name = "_Показать сообщение"

ProgressForm.ProgressBar1.Value = 98
_Полезные_объекты0_Дата0.Props.Name = "_Дата"

ProgressForm.ProgressBar1.Value = 99
_Полезные_объекты0_Расширенные_возможности0.Props.Name = "_Расширенные возможности"


' Окончательная загрузка
Окно10Окно10.load()
Окно10Надпись72.load()
Окно10Панель_10.load()
Окно10Текст10.load()
Окно10Текст20.load()
Окно10Текст30.load()
Окно10Текст40.load()
Окно10Текст50.load()
Окно10Текст60.load()
Окно10Кнопка10.load()
Окно10Надпись73.load()
Окно10Надпись74.load()
Окно10Надпись75.load()
Окно10Надпись76.load()
Окно10Надпись77.load()
Окно10Текст70.load()
Окно10Надпись71.load()
Окно10Кнопка20.load()
Окно10Кнопка30.load()
Окно10Окно_открытия10.load()
Окно20Окно20.load()
Окно20Рисунок10.load()
Окно20Кнопка10.load()
Окно20Кнопка20.load()
Окно20Текст10.load()
Окно20Окно_открытия10.load()
Окно30Окно30.load()
Окно30Текстовый_документ10.load()
Окно30Кнопка10.load()
Окно30Кнопка20.load()
Окно30Текст10.load()
Окно30Окно_открытия10.load()
Окно30Кнопка30.load()
Окно40Окно40.load()
Окно40Текстовый_документ10.load()
Окно40Кнопка10.load()
Окно40Кнопка20.load()
Окно40Память10.load()
Окно40Память20.load()
Окно40Память30.load()
Окно40Окно_сохранения10.load()
Окно40Надпись10.load()
Окно50Окно50.load()
Окно50Текстовый_документ10.load()
Окно50Кнопка10.load()
Окно50Окно_сохранения10.load()

RunProj.GetAllObjects()
RunProj.isINITIALIZATED = False

Окно10Надпись72.RaiseCreate()
Окно10Панель_10.RaiseCreate()
Окно10Текст10.RaiseCreate()
Окно10Текст20.RaiseCreate()
Окно10Текст30.RaiseCreate()
Окно10Текст40.RaiseCreate()
Окно10Текст50.RaiseCreate()
Окно10Текст60.RaiseCreate()
Окно10Кнопка10.RaiseCreate()
Окно10Надпись73.RaiseCreate()
Окно10Надпись74.RaiseCreate()
Окно10Надпись75.RaiseCreate()
Окно10Надпись76.RaiseCreate()
Окно10Надпись77.RaiseCreate()
Окно10Текст70.RaiseCreate()
Окно10Надпись71.RaiseCreate()
Окно10Кнопка20.RaiseCreate()
Окно10Кнопка30.RaiseCreate()
Окно10Окно_открытия10.RaiseCreate()
Окно10Окно10.RaiseCreate()
Окно20Рисунок10.RaiseCreate()
Окно20Кнопка10.RaiseCreate()
Окно20Кнопка20.RaiseCreate()
Окно20Текст10.RaiseCreate()
Окно20Окно_открытия10.RaiseCreate()
Окно20Окно20.RaiseCreate()
Окно30Текстовый_документ10.RaiseCreate()
Окно30Кнопка10.RaiseCreate()
Окно30Кнопка20.RaiseCreate()
Окно30Текст10.RaiseCreate()
Окно30Окно_открытия10.RaiseCreate()
Окно30Кнопка30.RaiseCreate()
Окно30Окно30.RaiseCreate()
Окно40Текстовый_документ10.RaiseCreate()
Окно40Кнопка10.RaiseCreate()
Окно40Кнопка20.RaiseCreate()
Окно40Память10.RaiseCreate()
Окно40Память20.RaiseCreate()
Окно40Память30.RaiseCreate()
Окно40Окно_сохранения10.RaiseCreate()
Окно40Надпись10.RaiseCreate()
Окно40Окно40.RaiseCreate()
Окно50Текстовый_документ10.RaiseCreate()
Окно50Кнопка10.RaiseCreate()
Окно50Окно_сохранения10.RaiseCreate()
Окно50Окно50.RaiseCreate()

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

Public Sub Окно10Текст20_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно10Текст20.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub Окно10Текст30_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно10Текст30.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub Окно10Текст40_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно10Текст40.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub Окно10Текст50_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно10Текст50.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub Окно10Текст60_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно10Текст60.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub Окно10Текст70_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно10Текст70.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub Окно20Окно20_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно20Окно20.Disposed
    If DaOrNet(Окно20Окно20.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub Окно20Окно20_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Окно20Окно20.FormClosing
    If DaOrNet(Окно20Окно20.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(Окно20Окно20.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
        Окно20Окно20.Hide() : Application.Exit()
    Else
        e.Cancel = True : Окно20Окно20.Hide()
    End If
End Sub

Public Sub Окно20Текст10_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно20Текст10.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub Окно30Окно30_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно30Окно30.Disposed
    If DaOrNet(Окно30Окно30.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub Окно30Окно30_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Окно30Окно30.FormClosing
    If DaOrNet(Окно30Окно30.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(Окно30Окно30.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
        Окно30Окно30.Hide() : Application.Exit()
    Else
        e.Cancel = True : Окно30Окно30.Hide()
    End If
End Sub

Public Sub Окно30Текстовый_документ10_LinkClickedNado(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles Окно30Текстовый_документ10.LinkClicked
    If DaOrNet(Окно30Текстовый_документ10.Props.InternetLink) Then Окно30Текстовый_документ10.Props.GoInternetLink(e.LinkText)
End Sub

Public Sub Окно30Текст10_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Окно30Текст10.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub Окно40Окно40_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно40Окно40.Disposed
    If DaOrNet(Окно40Окно40.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub Окно40Окно40_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Окно40Окно40.FormClosing
    If DaOrNet(Окно40Окно40.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(Окно40Окно40.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
        Окно40Окно40.Hide() : Application.Exit()
    Else
        e.Cancel = True : Окно40Окно40.Hide()
    End If
End Sub

Public Sub Окно40Текстовый_документ10_LinkClickedNado(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles Окно40Текстовый_документ10.LinkClicked
    If DaOrNet(Окно40Текстовый_документ10.Props.InternetLink) Then Окно40Текстовый_документ10.Props.GoInternetLink(e.LinkText)
End Sub

Public Sub Окно50Окно50_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно50Окно50.Disposed
    If DaOrNet(Окно50Окно50.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub Окно50Окно50_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Окно50Окно50.FormClosing
    If DaOrNet(Окно50Окно50.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(Окно50Окно50.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
        Окно50Окно50.Hide() : Application.Exit()
    Else
        e.Cancel = True : Окно50Окно50.Hide()
    End If
End Sub

Public Sub Окно50Текстовый_документ10_LinkClickedNado(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles Окно50Текстовый_документ10.LinkClicked
    If DaOrNet(Окно50Текстовый_документ10.Props.InternetLink) Then Окно50Текстовый_документ10.Props.GoInternetLink(e.LinkText)
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
Public Sub Окно10Кнопка10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Кнопка10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10Кнопка10.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно2.Окно2").Props.Visible = "Да"
RunProj.GetObjFromUniqName("Окно2.Окно2").Props.Enabled = "Да"
CurrentEvent.Zavershit()
End Sub


Public Sub Окно10Кнопка20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Кнопка20.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10Кнопка20.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно1.Текст7").Props.Copy
CurrentEvent.Zavershit()
End Sub


Public Sub Окно10Кнопка30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно10Кнопка30.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно10Кнопка30.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно1.Окно открытия1").Props.Showdialog
RunProj.GetObjFromUniqName("Окно1.Текст7").Props.Text = RunProj.GetObjFromUniqName("Окно1.Окно открытия1").Props.Filename
CurrentEvent.Zavershit()
End Sub


Public Sub Окно20Кнопка10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно20Кнопка10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно20Кнопка10.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно2.Окно открытия1").Props.Showdialog
RunProj.GetObjFromUniqName("Окно2.Рисунок1").Props.Image = RunProj.GetObjFromUniqName("Окно2.Окно открытия1").Props.Filename
RunProj.GetObjFromUniqName("Окно2.Текст1").Props.Text = RunProj.GetObjFromUniqName("Окно2.Окно открытия1").Props.Filename
CurrentEvent.Zavershit()
End Sub


Public Sub Окно20Кнопка20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно20Кнопка20.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно20Кнопка20.MyObj, e, nothing,"Клик")

If returnBoolean( UCase( RunProj.GetObjFromUniqName("Окно2.Текст1" ).Props.Text )  =  UCase( "" )  ) Then
RunProj.GetObjFromUniqName("_Полезные объекты._Показать сообщение").Props.Showmessage ( "Вы не указали путь к рисунку рабочего стола." , "ок" , "ошибка" , "" ) 
Else
RunProj.GetObjFromUniqName("Окно3.Окно3").Props.Enabled = "Да"
RunProj.GetObjFromUniqName("Окно3.Окно3").Props.Visible = "Да"
End If
CurrentEvent.Zavershit()
End Sub


Public Sub Окно30Кнопка10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно30Кнопка10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно30Кнопка10.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно4.Окно4").Props.Enabled = "Да"
RunProj.GetObjFromUniqName("Окно4.Окно4").Props.Visible = "Да"
CurrentEvent.Zavershit()
End Sub


Public Sub Окно30Кнопка20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно30Кнопка20.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно30Кнопка20.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно3.Окно открытия1").Props.Showdialog
RunProj.GetObjFromUniqName("Окно3.Текст1").Props.Text = RunProj.GetObjFromUniqName("Окно3.Окно открытия1").Props.Filename
CurrentEvent.Zavershit()
End Sub


Public Sub Окно30Кнопка30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно30Кнопка30.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно30Кнопка30.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно3.Текст1").Props.Copy
CurrentEvent.Zavershit()
End Sub


Public Sub Окно40Кнопка10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно40Кнопка10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно40Кнопка10.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = "; Copyright © Microsoft Corp." & vbCrLf & "" & vbCrLf & "[Theme]" & vbCrLf & "; Windows 7 - IDS_THEME_DISPLAYNAME_AERO" & vbCrLf & "DisplayName=Biohazard" & vbCrLf & "BrandImage=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст1").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "" & vbCrLf & "; Computer - SHIDI_SERVER" & vbCrLf & "[CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст2").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "" & vbCrLf & "; UsersFiles - SHIDI_USERFILES" & vbCrLf & "[CLSID\{59031A47-3F72-44A7-89C5-5595FE6B30EE}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст3").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "; Network - SHIDI_MYNETWORK" & vbCrLf & "[CLSID\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст4").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "" & vbCrLf & "; Recycle Bin - SHIDI_RECYCLERFULL SHIDI_RECYCLER" & vbCrLf & "[CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\DefaultIcon]" & vbCrLf & "Full=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст5").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "" & vbCrLf & "Empty=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст6").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно4.Память2").Props.Value
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно2.Текст1").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно4.Память3").Props.Value
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно3.Текстовый документ1").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно4.Текстовый документ1").Props.Text
RunProj.GetObjFromUniqName("Окно4.Окно сохранения1").Props.Showdialog
(RunProj.GetObjFromUniqName("Окно4.Окно сохранения1").Props.(RunProj.GetObjFromUniqName) ( "Окно4.Окно сохранения1" ) .Props.Filename , RunProj.GetObjFromUniqName ( "Окно4.Память1" ) .Props.Value , "по умолчанию" ) )
CurrentEvent.Zavershit()
End Sub


Public Sub Окно40Кнопка20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно40Кнопка20.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно40Кнопка20.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("_Полезные объекты._Система").Props.Run ( "Themes\help.txt" , "C:\" ) 
CurrentEvent.Zavershit()
End Sub


Public Sub Окно40Надпись10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно40Надпись10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно40Надпись10.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = "; Copyright © Microsoft Corp." & vbCrLf & "" & vbCrLf & "[Theme]" & vbCrLf & "; Windows 7 - IDS_THEME_DISPLAYNAME_AERO" & vbCrLf & "DisplayName=Biohazard" & vbCrLf & "BrandImage=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст1").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "" & vbCrLf & "; Computer - SHIDI_SERVER" & vbCrLf & "[CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст2").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "" & vbCrLf & "; UsersFiles - SHIDI_USERFILES" & vbCrLf & "[CLSID\{59031A47-3F72-44A7-89C5-5595FE6B30EE}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст3").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "; Network - SHIDI_MYNETWORK" & vbCrLf & "[CLSID\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст4").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "" & vbCrLf & "; Recycle Bin - SHIDI_RECYCLERFULL SHIDI_RECYCLER" & vbCrLf & "[CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\DefaultIcon]" & vbCrLf & "Full=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст5").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & "" & vbCrLf & "Empty=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно1.Текст6").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно4.Память2").Props.Value
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно2.Текст1").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно4.Память3").Props.Value
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно3.Текстовый документ1").Props.Text
RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value = RunProj.GetObjFromUniqName("Окно4.Память1").Props.Value & RunProj.GetObjFromUniqName("Окно4.Текстовый документ1").Props.Text
RunProj.GetObjFromUniqName("Окно5.Окно5").Props.Visible = "Да"
RunProj.GetObjFromUniqName("Окно5.Окно5").Props.Enabled = "Да"
CurrentEvent.Zavershit()
End Sub


Public Sub Окно50Кнопка10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Окно50Кнопка10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(Окно50Кнопка10.MyObj, e, nothing,"Клик")

RunProj.GetObjFromUniqName("Окно5.Окно сохранения1").Props.Showdialog
RunProj.GetObjFromUniqName("_Полезные объекты._Файлы и папки").Props.Saveinfile ( RunProj.GetObjFromUniqName ( "Окно5.Окно сохранения1" ) .Props.Filename , RunProj.GetObjFromUniqName ( "Окно5.Текстовый документ1" ) .Props.Text , "по умолчанию" ) 
CurrentEvent.Zavershit()
End Sub



End Module



