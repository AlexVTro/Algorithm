Module CodeAlg

    Public WithEvents Window10Window10 As New runF
    Public WithEvents Window10Double_panel10 As New runDP
    Public WithEvents Window10LabelGoodsNames0 As New runLb
    Public WithEvents Window10Table10 As New runTl
    Public WithEvents Window10TextId0 As New runT
    Public WithEvents Window10TextName0 As New runT
    Public WithEvents Window10TextCost0 As New runT
    Public WithEvents Window10ButtonAdd10 As New runB
    Public WithEvents Window10Label30 As New runLb
    Public WithEvents Window10Label40 As New runLb
    Public WithEvents Window10Label50 As New runLb
    Public WithEvents Window10Label60 As New runLb
    Public WithEvents Window10Calendar0 As New runCr
    Public WithEvents Window10CheckBoxDel0 As New runCB
    Public WithEvents Window10CheckBoxChanges0 As New runCB
    Public WithEvents Window10LabelGoodsExists0 As New runLb
    Public WithEvents Window10Table20 As New runTl
    Public WithEvents Window10TextId20 As New runT
    Public WithEvents Window10TextMarket0 As New runT
    Public WithEvents Window10TextCount0 As New runT
    Public WithEvents Window10ButtonAdd20 As New runB
    Public WithEvents Window10Label10 As New runLb
    Public WithEvents Window10Label20 As New runLb
    Public WithEvents Window10Label70 As New runLb
    Public WithEvents Window10CheckBoxSizes0 As New runCB
    Public WithEvents Window10CheckBoxSelections0 As New runCB
    Public WithEvents Window10MenuTables0 As New runCM
    Public WithEvents Window10MenuTables0CnMn As ContextMenuStrip = Window10MenuTables0.CnMn
    Public WithEvents Window10ItemDuplicate0 As New runMMs
    Public WithEvents Window10ItemDelete0 As New runMMs
    Public WithEvents Window10ItemSplit0 As New runMMs
    Public WithEvents Window10ItemSelectAll0 As New runMMs
    Public WithEvents Window10MemoryRowNumber0 As New runM
    Public WithEvents Window10Label80 As New runLb
    Public WithEvents Window10ComboBoxReports0 As New runC
    Public WithEvents Window10TextQuery0 As New runT
    Public WithEvents Window10ButtonReports0 As New runB
    Public WithEvents Window20Window20 As New runF
    Public WithEvents Window20TableReport0 As New runTl
    Public WithEvents Window20LabelReport0 As New runLb
    Public WithEvents Window20ButtonPreview0 As New runB
    Public WithEvents Window20ButtonPrint0 As New runB
    Public WithEvents Window20Print_dialog10 As New runPrD
    Public WithEvents _Useful_objects0_Useful_objects0 As New runF
    Public WithEvents _Useful_objects0_Screen0 As New PoleznieObj("_Screen")
    Public WithEvents _Useful_objects0_Files_and_paths0 As New PoleznieObj("_Files and paths")
    Public WithEvents _Useful_objects0_Interrupts0 As New PoleznieObj("_Interrupts")
    Public WithEvents _Useful_objects0_System0 As New PoleznieObj("_System")
    Public WithEvents _Useful_objects0_Registry0 As New PoleznieObj("_Registry")
    Public WithEvents _Useful_objects0_Call_event0 As New PoleznieObj("_Call event")
    Public WithEvents _Useful_objects0_Text0 As New PoleznieObj("_Text")
    Public WithEvents _Useful_objects0_Show_messange0 As New PoleznieObj("_Show messange")
    Public WithEvents _Useful_objects0_Date0 As New PoleznieObj("_Date")
    Public WithEvents _Useful_objects0_Advanced_tools0 As New PoleznieObj("_Advanced tools")


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
        Window10Window10.MyObj = New Forms(True, , True)
        Window10Window10.MyObj.proj = proj
        Window10Window10.MyObj.obj = Window10Window10
        Window10Window10.MyObj.VBname = "Window10Window10"
        Window10Window10.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = Window10Window10.MyObj
        ReDimsO(Window10Window10.MyObj.MyForm.MyObjs) : Window10Window10.MyObj.MyForm.MyObjs(Window10Window10.MyObj.MyForm.MyObjs.Length - 1) = Window10Window10.MyObj

        Window10Double_panel10.MyObj = New DPanel(True, True)
        Window10Double_panel10.MyObj.proj = proj
        Window10Double_panel10.MyObj.obj = Window10Double_panel10
        Window10Double_panel10.MyObj.VBname = "Window10Double_panel10"
        Window10Double_panel10.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Double_panel10.MyObj.MyForm.MyObjs) : Window10Double_panel10.MyObj.MyForm.MyObjs(Window10Double_panel10.MyObj.MyForm.MyObjs.Length - 1) = Window10Double_panel10.MyObj

        Window10LabelGoodsNames0.MyObj = New Label(True, True)
        Window10LabelGoodsNames0.MyObj.proj = proj
        Window10LabelGoodsNames0.MyObj.obj = Window10LabelGoodsNames0
        Window10LabelGoodsNames0.MyObj.VBname = "Window10LabelGoodsNames0"
        Window10LabelGoodsNames0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10LabelGoodsNames0.MyObj.MyForm.MyObjs) : Window10LabelGoodsNames0.MyObj.MyForm.MyObjs(Window10LabelGoodsNames0.MyObj.MyForm.MyObjs.Length - 1) = Window10LabelGoodsNames0.MyObj

        Window10Table10.MyObj = New Table(True, True)
        Window10Table10.MyObj.proj = proj
        Window10Table10.MyObj.obj = Window10Table10
        Window10Table10.MyObj.VBname = "Window10Table10"
        Window10Table10.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Table10.MyObj.MyForm.MyObjs) : Window10Table10.MyObj.MyForm.MyObjs(Window10Table10.MyObj.MyForm.MyObjs.Length - 1) = Window10Table10.MyObj

        Window10TextId0.MyObj = New TextBoks(True, True)
        Window10TextId0.MyObj.proj = proj
        Window10TextId0.MyObj.obj = Window10TextId0
        Window10TextId0.MyObj.VBname = "Window10TextId0"
        Window10TextId0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10TextId0.MyObj.MyForm.MyObjs) : Window10TextId0.MyObj.MyForm.MyObjs(Window10TextId0.MyObj.MyForm.MyObjs.Length - 1) = Window10TextId0.MyObj

        ProgressForm.ProgressBar1.Value = 2
        Window10TextName0.MyObj = New TextBoks(True, True)
        Window10TextName0.MyObj.proj = proj
        Window10TextName0.MyObj.obj = Window10TextName0
        Window10TextName0.MyObj.VBname = "Window10TextName0"
        Window10TextName0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10TextName0.MyObj.MyForm.MyObjs) : Window10TextName0.MyObj.MyForm.MyObjs(Window10TextName0.MyObj.MyForm.MyObjs.Length - 1) = Window10TextName0.MyObj

        Window10TextCost0.MyObj = New TextBoks(True, True)
        Window10TextCost0.MyObj.proj = proj
        Window10TextCost0.MyObj.obj = Window10TextCost0
        Window10TextCost0.MyObj.VBname = "Window10TextCost0"
        Window10TextCost0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10TextCost0.MyObj.MyForm.MyObjs) : Window10TextCost0.MyObj.MyForm.MyObjs(Window10TextCost0.MyObj.MyForm.MyObjs.Length - 1) = Window10TextCost0.MyObj

        Window10ButtonAdd10.MyObj = New Button(True, True)
        Window10ButtonAdd10.MyObj.proj = proj
        Window10ButtonAdd10.MyObj.obj = Window10ButtonAdd10
        Window10ButtonAdd10.MyObj.VBname = "Window10ButtonAdd10"
        Window10ButtonAdd10.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10ButtonAdd10.MyObj.MyForm.MyObjs) : Window10ButtonAdd10.MyObj.MyForm.MyObjs(Window10ButtonAdd10.MyObj.MyForm.MyObjs.Length - 1) = Window10ButtonAdd10.MyObj

        Window10Label30.MyObj = New Label(True, True)
        Window10Label30.MyObj.proj = proj
        Window10Label30.MyObj.obj = Window10Label30
        Window10Label30.MyObj.VBname = "Window10Label30"
        Window10Label30.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Label30.MyObj.MyForm.MyObjs) : Window10Label30.MyObj.MyForm.MyObjs(Window10Label30.MyObj.MyForm.MyObjs.Length - 1) = Window10Label30.MyObj

        Window10Label40.MyObj = New Label(True, True)
        Window10Label40.MyObj.proj = proj
        Window10Label40.MyObj.obj = Window10Label40
        Window10Label40.MyObj.VBname = "Window10Label40"
        Window10Label40.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Label40.MyObj.MyForm.MyObjs) : Window10Label40.MyObj.MyForm.MyObjs(Window10Label40.MyObj.MyForm.MyObjs.Length - 1) = Window10Label40.MyObj

        ProgressForm.ProgressBar1.Value = 5
        Window10Label50.MyObj = New Label(True, True)
        Window10Label50.MyObj.proj = proj
        Window10Label50.MyObj.obj = Window10Label50
        Window10Label50.MyObj.VBname = "Window10Label50"
        Window10Label50.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Label50.MyObj.MyForm.MyObjs) : Window10Label50.MyObj.MyForm.MyObjs(Window10Label50.MyObj.MyForm.MyObjs.Length - 1) = Window10Label50.MyObj

        Window10Label60.MyObj = New Label(True, True)
        Window10Label60.MyObj.proj = proj
        Window10Label60.MyObj.obj = Window10Label60
        Window10Label60.MyObj.VBname = "Window10Label60"
        Window10Label60.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Label60.MyObj.MyForm.MyObjs) : Window10Label60.MyObj.MyForm.MyObjs(Window10Label60.MyObj.MyForm.MyObjs.Length - 1) = Window10Label60.MyObj

        Window10Calendar0.MyObj = New Calendar(True, True)
        Window10Calendar0.MyObj.proj = proj
        Window10Calendar0.MyObj.obj = Window10Calendar0
        Window10Calendar0.MyObj.VBname = "Window10Calendar0"
        Window10Calendar0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Calendar0.MyObj.MyForm.MyObjs) : Window10Calendar0.MyObj.MyForm.MyObjs(Window10Calendar0.MyObj.MyForm.MyObjs.Length - 1) = Window10Calendar0.MyObj

        Window10CheckBoxDel0.MyObj = New CheckBoks(True, True)
        Window10CheckBoxDel0.MyObj.proj = proj
        Window10CheckBoxDel0.MyObj.obj = Window10CheckBoxDel0
        Window10CheckBoxDel0.MyObj.VBname = "Window10CheckBoxDel0"
        Window10CheckBoxDel0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10CheckBoxDel0.MyObj.MyForm.MyObjs) : Window10CheckBoxDel0.MyObj.MyForm.MyObjs(Window10CheckBoxDel0.MyObj.MyForm.MyObjs.Length - 1) = Window10CheckBoxDel0.MyObj

        Window10CheckBoxChanges0.MyObj = New CheckBoks(True, True)
        Window10CheckBoxChanges0.MyObj.proj = proj
        Window10CheckBoxChanges0.MyObj.obj = Window10CheckBoxChanges0
        Window10CheckBoxChanges0.MyObj.VBname = "Window10CheckBoxChanges0"
        Window10CheckBoxChanges0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10CheckBoxChanges0.MyObj.MyForm.MyObjs) : Window10CheckBoxChanges0.MyObj.MyForm.MyObjs(Window10CheckBoxChanges0.MyObj.MyForm.MyObjs.Length - 1) = Window10CheckBoxChanges0.MyObj

        ProgressForm.ProgressBar1.Value = 7
        Window10LabelGoodsExists0.MyObj = New Label(True, True)
        Window10LabelGoodsExists0.MyObj.proj = proj
        Window10LabelGoodsExists0.MyObj.obj = Window10LabelGoodsExists0
        Window10LabelGoodsExists0.MyObj.VBname = "Window10LabelGoodsExists0"
        Window10LabelGoodsExists0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10LabelGoodsExists0.MyObj.MyForm.MyObjs) : Window10LabelGoodsExists0.MyObj.MyForm.MyObjs(Window10LabelGoodsExists0.MyObj.MyForm.MyObjs.Length - 1) = Window10LabelGoodsExists0.MyObj

        Window10Table20.MyObj = New Table(True, True)
        Window10Table20.MyObj.proj = proj
        Window10Table20.MyObj.obj = Window10Table20
        Window10Table20.MyObj.VBname = "Window10Table20"
        Window10Table20.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Table20.MyObj.MyForm.MyObjs) : Window10Table20.MyObj.MyForm.MyObjs(Window10Table20.MyObj.MyForm.MyObjs.Length - 1) = Window10Table20.MyObj

        Window10TextId20.MyObj = New TextBoks(True, True)
        Window10TextId20.MyObj.proj = proj
        Window10TextId20.MyObj.obj = Window10TextId20
        Window10TextId20.MyObj.VBname = "Window10TextId20"
        Window10TextId20.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10TextId20.MyObj.MyForm.MyObjs) : Window10TextId20.MyObj.MyForm.MyObjs(Window10TextId20.MyObj.MyForm.MyObjs.Length - 1) = Window10TextId20.MyObj

        Window10TextMarket0.MyObj = New TextBoks(True, True)
        Window10TextMarket0.MyObj.proj = proj
        Window10TextMarket0.MyObj.obj = Window10TextMarket0
        Window10TextMarket0.MyObj.VBname = "Window10TextMarket0"
        Window10TextMarket0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10TextMarket0.MyObj.MyForm.MyObjs) : Window10TextMarket0.MyObj.MyForm.MyObjs(Window10TextMarket0.MyObj.MyForm.MyObjs.Length - 1) = Window10TextMarket0.MyObj

        Window10TextCount0.MyObj = New TextBoks(True, True)
        Window10TextCount0.MyObj.proj = proj
        Window10TextCount0.MyObj.obj = Window10TextCount0
        Window10TextCount0.MyObj.VBname = "Window10TextCount0"
        Window10TextCount0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10TextCount0.MyObj.MyForm.MyObjs) : Window10TextCount0.MyObj.MyForm.MyObjs(Window10TextCount0.MyObj.MyForm.MyObjs.Length - 1) = Window10TextCount0.MyObj

        ProgressForm.ProgressBar1.Value = 9
        Window10ButtonAdd20.MyObj = New Button(True, True)
        Window10ButtonAdd20.MyObj.proj = proj
        Window10ButtonAdd20.MyObj.obj = Window10ButtonAdd20
        Window10ButtonAdd20.MyObj.VBname = "Window10ButtonAdd20"
        Window10ButtonAdd20.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10ButtonAdd20.MyObj.MyForm.MyObjs) : Window10ButtonAdd20.MyObj.MyForm.MyObjs(Window10ButtonAdd20.MyObj.MyForm.MyObjs.Length - 1) = Window10ButtonAdd20.MyObj

        Window10Label10.MyObj = New Label(True, True)
        Window10Label10.MyObj.proj = proj
        Window10Label10.MyObj.obj = Window10Label10
        Window10Label10.MyObj.VBname = "Window10Label10"
        Window10Label10.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Label10.MyObj.MyForm.MyObjs) : Window10Label10.MyObj.MyForm.MyObjs(Window10Label10.MyObj.MyForm.MyObjs.Length - 1) = Window10Label10.MyObj

        Window10Label20.MyObj = New Label(True, True)
        Window10Label20.MyObj.proj = proj
        Window10Label20.MyObj.obj = Window10Label20
        Window10Label20.MyObj.VBname = "Window10Label20"
        Window10Label20.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Label20.MyObj.MyForm.MyObjs) : Window10Label20.MyObj.MyForm.MyObjs(Window10Label20.MyObj.MyForm.MyObjs.Length - 1) = Window10Label20.MyObj

        Window10Label70.MyObj = New Label(True, True)
        Window10Label70.MyObj.proj = proj
        Window10Label70.MyObj.obj = Window10Label70
        Window10Label70.MyObj.VBname = "Window10Label70"
        Window10Label70.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Label70.MyObj.MyForm.MyObjs) : Window10Label70.MyObj.MyForm.MyObjs(Window10Label70.MyObj.MyForm.MyObjs.Length - 1) = Window10Label70.MyObj

        Window10CheckBoxSizes0.MyObj = New CheckBoks(True, True)
        Window10CheckBoxSizes0.MyObj.proj = proj
        Window10CheckBoxSizes0.MyObj.obj = Window10CheckBoxSizes0
        Window10CheckBoxSizes0.MyObj.VBname = "Window10CheckBoxSizes0"
        Window10CheckBoxSizes0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10CheckBoxSizes0.MyObj.MyForm.MyObjs) : Window10CheckBoxSizes0.MyObj.MyForm.MyObjs(Window10CheckBoxSizes0.MyObj.MyForm.MyObjs.Length - 1) = Window10CheckBoxSizes0.MyObj

        ProgressForm.ProgressBar1.Value = 12
        Window10CheckBoxSelections0.MyObj = New CheckBoks(True, True)
        Window10CheckBoxSelections0.MyObj.proj = proj
        Window10CheckBoxSelections0.MyObj.obj = Window10CheckBoxSelections0
        Window10CheckBoxSelections0.MyObj.VBname = "Window10CheckBoxSelections0"
        Window10CheckBoxSelections0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10CheckBoxSelections0.MyObj.MyForm.MyObjs) : Window10CheckBoxSelections0.MyObj.MyForm.MyObjs(Window10CheckBoxSelections0.MyObj.MyForm.MyObjs.Length - 1) = Window10CheckBoxSelections0.MyObj

        Window10MenuTables0.MyObj = New CMenu(True, True)
        Window10MenuTables0.MyObj.proj = proj
        Window10MenuTables0.MyObj.obj = Window10MenuTables0
        Window10MenuTables0.MyObj.VBname = "Window10MenuTables0"
        Window10MenuTables0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10MenuTables0.MyObj.MyForm.MyObjs) : Window10MenuTables0.MyObj.MyForm.MyObjs(Window10MenuTables0.MyObj.MyForm.MyObjs.Length - 1) = Window10MenuTables0.MyObj

        Window10ItemDuplicate0.MyObj = New MMenus(True, True)
        Window10ItemDuplicate0.MyObj.proj = proj
        Window10ItemDuplicate0.MyObj.obj = Window10ItemDuplicate0
        Window10ItemDuplicate0.MyObj.VBname = "Window10ItemDuplicate0"
        Window10ItemDuplicate0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10ItemDuplicate0.MyObj.MyForm.MyObjs) : Window10ItemDuplicate0.MyObj.MyForm.MyObjs(Window10ItemDuplicate0.MyObj.MyForm.MyObjs.Length - 1) = Window10ItemDuplicate0.MyObj

        Window10ItemDelete0.MyObj = New MMenus(True, True)
        Window10ItemDelete0.MyObj.proj = proj
        Window10ItemDelete0.MyObj.obj = Window10ItemDelete0
        Window10ItemDelete0.MyObj.VBname = "Window10ItemDelete0"
        Window10ItemDelete0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10ItemDelete0.MyObj.MyForm.MyObjs) : Window10ItemDelete0.MyObj.MyForm.MyObjs(Window10ItemDelete0.MyObj.MyForm.MyObjs.Length - 1) = Window10ItemDelete0.MyObj

        Window10ItemSplit0.MyObj = New MMenus(True, True)
        Window10ItemSplit0.MyObj.proj = proj
        Window10ItemSplit0.MyObj.obj = Window10ItemSplit0
        Window10ItemSplit0.MyObj.VBname = "Window10ItemSplit0"
        Window10ItemSplit0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10ItemSplit0.MyObj.MyForm.MyObjs) : Window10ItemSplit0.MyObj.MyForm.MyObjs(Window10ItemSplit0.MyObj.MyForm.MyObjs.Length - 1) = Window10ItemSplit0.MyObj

        ProgressForm.ProgressBar1.Value = 14
        Window10ItemSelectAll0.MyObj = New MMenus(True, True)
        Window10ItemSelectAll0.MyObj.proj = proj
        Window10ItemSelectAll0.MyObj.obj = Window10ItemSelectAll0
        Window10ItemSelectAll0.MyObj.VBname = "Window10ItemSelectAll0"
        Window10ItemSelectAll0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10ItemSelectAll0.MyObj.MyForm.MyObjs) : Window10ItemSelectAll0.MyObj.MyForm.MyObjs(Window10ItemSelectAll0.MyObj.MyForm.MyObjs.Length - 1) = Window10ItemSelectAll0.MyObj

        Window10MemoryRowNumber0.MyObj = New Memory(True, True)
        Window10MemoryRowNumber0.MyObj.proj = proj
        Window10MemoryRowNumber0.MyObj.obj = Window10MemoryRowNumber0
        Window10MemoryRowNumber0.MyObj.VBname = "Window10MemoryRowNumber0"
        Window10MemoryRowNumber0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10MemoryRowNumber0.MyObj.MyForm.MyObjs) : Window10MemoryRowNumber0.MyObj.MyForm.MyObjs(Window10MemoryRowNumber0.MyObj.MyForm.MyObjs.Length - 1) = Window10MemoryRowNumber0.MyObj

        Window10Label80.MyObj = New Label(True, True)
        Window10Label80.MyObj.proj = proj
        Window10Label80.MyObj.obj = Window10Label80
        Window10Label80.MyObj.VBname = "Window10Label80"
        Window10Label80.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10Label80.MyObj.MyForm.MyObjs) : Window10Label80.MyObj.MyForm.MyObjs(Window10Label80.MyObj.MyForm.MyObjs.Length - 1) = Window10Label80.MyObj

        Window10ComboBoxReports0.MyObj = New ComboBoks(True, True)
        Window10ComboBoxReports0.MyObj.proj = proj
        Window10ComboBoxReports0.MyObj.obj = Window10ComboBoxReports0
        Window10ComboBoxReports0.MyObj.VBname = "Window10ComboBoxReports0"
        Window10ComboBoxReports0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10ComboBoxReports0.MyObj.MyForm.MyObjs) : Window10ComboBoxReports0.MyObj.MyForm.MyObjs(Window10ComboBoxReports0.MyObj.MyForm.MyObjs.Length - 1) = Window10ComboBoxReports0.MyObj

        Window10TextQuery0.MyObj = New TextBoks(True, True)
        Window10TextQuery0.MyObj.proj = proj
        Window10TextQuery0.MyObj.obj = Window10TextQuery0
        Window10TextQuery0.MyObj.VBname = "Window10TextQuery0"
        Window10TextQuery0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10TextQuery0.MyObj.MyForm.MyObjs) : Window10TextQuery0.MyObj.MyForm.MyObjs(Window10TextQuery0.MyObj.MyForm.MyObjs.Length - 1) = Window10TextQuery0.MyObj

        ProgressForm.ProgressBar1.Value = 17
        Window10ButtonReports0.MyObj = New Button(True, True)
        Window10ButtonReports0.MyObj.proj = proj
        Window10ButtonReports0.MyObj.obj = Window10ButtonReports0
        Window10ButtonReports0.MyObj.VBname = "Window10ButtonReports0"
        Window10ButtonReports0.MyObj.MyObj.MyForm = Window10Window10.MyObj
        ReDimsO(Window10ButtonReports0.MyObj.MyForm.MyObjs) : Window10ButtonReports0.MyObj.MyForm.MyObjs(Window10ButtonReports0.MyObj.MyForm.MyObjs.Length - 1) = Window10ButtonReports0.MyObj

        Window20Window20.MyObj = New Forms(True, , True)
        Window20Window20.MyObj.proj = proj
        Window20Window20.MyObj.obj = Window20Window20
        Window20Window20.MyObj.VBname = "Window20Window20"
        Window20Window20.MyObj.MyObj.MyForm = Window20Window20.MyObj
        ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = Window20Window20.MyObj
        ReDimsO(Window20Window20.MyObj.MyForm.MyObjs) : Window20Window20.MyObj.MyForm.MyObjs(Window20Window20.MyObj.MyForm.MyObjs.Length - 1) = Window20Window20.MyObj

        Window20TableReport0.MyObj = New Table(True, True)
        Window20TableReport0.MyObj.proj = proj
        Window20TableReport0.MyObj.obj = Window20TableReport0
        Window20TableReport0.MyObj.VBname = "Window20TableReport0"
        Window20TableReport0.MyObj.MyObj.MyForm = Window20Window20.MyObj
        ReDimsO(Window20TableReport0.MyObj.MyForm.MyObjs) : Window20TableReport0.MyObj.MyForm.MyObjs(Window20TableReport0.MyObj.MyForm.MyObjs.Length - 1) = Window20TableReport0.MyObj

        Window20LabelReport0.MyObj = New Label(True, True)
        Window20LabelReport0.MyObj.proj = proj
        Window20LabelReport0.MyObj.obj = Window20LabelReport0
        Window20LabelReport0.MyObj.VBname = "Window20LabelReport0"
        Window20LabelReport0.MyObj.MyObj.MyForm = Window20Window20.MyObj
        ReDimsO(Window20LabelReport0.MyObj.MyForm.MyObjs) : Window20LabelReport0.MyObj.MyForm.MyObjs(Window20LabelReport0.MyObj.MyForm.MyObjs.Length - 1) = Window20LabelReport0.MyObj

        Window20ButtonPreview0.MyObj = New Button(True, True)
        Window20ButtonPreview0.MyObj.proj = proj
        Window20ButtonPreview0.MyObj.obj = Window20ButtonPreview0
        Window20ButtonPreview0.MyObj.VBname = "Window20ButtonPreview0"
        Window20ButtonPreview0.MyObj.MyObj.MyForm = Window20Window20.MyObj
        ReDimsO(Window20ButtonPreview0.MyObj.MyForm.MyObjs) : Window20ButtonPreview0.MyObj.MyForm.MyObjs(Window20ButtonPreview0.MyObj.MyForm.MyObjs.Length - 1) = Window20ButtonPreview0.MyObj

        ProgressForm.ProgressBar1.Value = 19
        Window20ButtonPrint0.MyObj = New Button(True, True)
        Window20ButtonPrint0.MyObj.proj = proj
        Window20ButtonPrint0.MyObj.obj = Window20ButtonPrint0
        Window20ButtonPrint0.MyObj.VBname = "Window20ButtonPrint0"
        Window20ButtonPrint0.MyObj.MyObj.MyForm = Window20Window20.MyObj
        ReDimsO(Window20ButtonPrint0.MyObj.MyForm.MyObjs) : Window20ButtonPrint0.MyObj.MyForm.MyObjs(Window20ButtonPrint0.MyObj.MyForm.MyObjs.Length - 1) = Window20ButtonPrint0.MyObj

        Window20Print_dialog10.MyObj = New PrintDialog(True, True)
        Window20Print_dialog10.MyObj.proj = proj
        Window20Print_dialog10.MyObj.obj = Window20Print_dialog10
        Window20Print_dialog10.MyObj.VBname = "Window20Print_dialog10"
        Window20Print_dialog10.MyObj.MyObj.MyForm = Window20Window20.MyObj
        ReDimsO(Window20Print_dialog10.MyObj.MyForm.MyObjs) : Window20Print_dialog10.MyObj.MyForm.MyObjs(Window20Print_dialog10.MyObj.MyForm.MyObjs.Length - 1) = Window20Print_dialog10.MyObj

        _Useful_objects0_Useful_objects0.MyObj = New Forms(True, , True)
        _Useful_objects0_Useful_objects0.MyObj.proj = proj
        _Useful_objects0_Useful_objects0.MyObj.obj = _Useful_objects0_Useful_objects0
        _Useful_objects0_Useful_objects0.MyObj.VBname = "_Useful_objects0_Useful_objects0"
        _Useful_objects0_Useful_objects0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Useful_objects0.MyObj.MyForm.MyObjs) : _Useful_objects0_Useful_objects0.MyObj.MyForm.MyObjs(_Useful_objects0_Useful_objects0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Useful_objects0.MyObj

        _Useful_objects0_Screen0.MyObj = New Poleznie("_Screen")
        _Useful_objects0_Screen0.MyObj.proj = proj
        _Useful_objects0_Screen0.MyObj.obj = _Useful_objects0_Screen0
        _Useful_objects0_Screen0.MyObj.VBname = "_Useful_objects0_Screen0"
        _Useful_objects0_Screen0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Screen0.MyObj.MyForm.MyObjs) : _Useful_objects0_Screen0.MyObj.MyForm.MyObjs(_Useful_objects0_Screen0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Screen0.MyObj

        _Useful_objects0_Files_and_paths0.MyObj = New Poleznie("_Files and paths")
        _Useful_objects0_Files_and_paths0.MyObj.proj = proj
        _Useful_objects0_Files_and_paths0.MyObj.obj = _Useful_objects0_Files_and_paths0
        _Useful_objects0_Files_and_paths0.MyObj.VBname = "_Useful_objects0_Files_and_paths0"
        _Useful_objects0_Files_and_paths0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Files_and_paths0.MyObj.MyForm.MyObjs) : _Useful_objects0_Files_and_paths0.MyObj.MyForm.MyObjs(_Useful_objects0_Files_and_paths0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Files_and_paths0.MyObj

        ProgressForm.ProgressBar1.Value = 21
        _Useful_objects0_Interrupts0.MyObj = New Poleznie("_Interrupts")
        _Useful_objects0_Interrupts0.MyObj.proj = proj
        _Useful_objects0_Interrupts0.MyObj.obj = _Useful_objects0_Interrupts0
        _Useful_objects0_Interrupts0.MyObj.VBname = "_Useful_objects0_Interrupts0"
        _Useful_objects0_Interrupts0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Interrupts0.MyObj.MyForm.MyObjs) : _Useful_objects0_Interrupts0.MyObj.MyForm.MyObjs(_Useful_objects0_Interrupts0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Interrupts0.MyObj

        _Useful_objects0_System0.MyObj = New Poleznie("_System")
        _Useful_objects0_System0.MyObj.proj = proj
        _Useful_objects0_System0.MyObj.obj = _Useful_objects0_System0
        _Useful_objects0_System0.MyObj.VBname = "_Useful_objects0_System0"
        _Useful_objects0_System0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_System0.MyObj.MyForm.MyObjs) : _Useful_objects0_System0.MyObj.MyForm.MyObjs(_Useful_objects0_System0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_System0.MyObj

        _Useful_objects0_Registry0.MyObj = New Poleznie("_Registry")
        _Useful_objects0_Registry0.MyObj.proj = proj
        _Useful_objects0_Registry0.MyObj.obj = _Useful_objects0_Registry0
        _Useful_objects0_Registry0.MyObj.VBname = "_Useful_objects0_Registry0"
        _Useful_objects0_Registry0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Registry0.MyObj.MyForm.MyObjs) : _Useful_objects0_Registry0.MyObj.MyForm.MyObjs(_Useful_objects0_Registry0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Registry0.MyObj

        _Useful_objects0_Call_event0.MyObj = New Poleznie("_Call event")
        _Useful_objects0_Call_event0.MyObj.proj = proj
        _Useful_objects0_Call_event0.MyObj.obj = _Useful_objects0_Call_event0
        _Useful_objects0_Call_event0.MyObj.VBname = "_Useful_objects0_Call_event0"
        _Useful_objects0_Call_event0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Call_event0.MyObj.MyForm.MyObjs) : _Useful_objects0_Call_event0.MyObj.MyForm.MyObjs(_Useful_objects0_Call_event0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Call_event0.MyObj

        _Useful_objects0_Text0.MyObj = New Poleznie("_Text")
        _Useful_objects0_Text0.MyObj.proj = proj
        _Useful_objects0_Text0.MyObj.obj = _Useful_objects0_Text0
        _Useful_objects0_Text0.MyObj.VBname = "_Useful_objects0_Text0"
        _Useful_objects0_Text0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Text0.MyObj.MyForm.MyObjs) : _Useful_objects0_Text0.MyObj.MyForm.MyObjs(_Useful_objects0_Text0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Text0.MyObj

        ProgressForm.ProgressBar1.Value = 24
        _Useful_objects0_Show_messange0.MyObj = New Poleznie("_Show messange")
        _Useful_objects0_Show_messange0.MyObj.proj = proj
        _Useful_objects0_Show_messange0.MyObj.obj = _Useful_objects0_Show_messange0
        _Useful_objects0_Show_messange0.MyObj.VBname = "_Useful_objects0_Show_messange0"
        _Useful_objects0_Show_messange0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Show_messange0.MyObj.MyForm.MyObjs) : _Useful_objects0_Show_messange0.MyObj.MyForm.MyObjs(_Useful_objects0_Show_messange0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Show_messange0.MyObj

        _Useful_objects0_Date0.MyObj = New Poleznie("_Date")
        _Useful_objects0_Date0.MyObj.proj = proj
        _Useful_objects0_Date0.MyObj.obj = _Useful_objects0_Date0
        _Useful_objects0_Date0.MyObj.VBname = "_Useful_objects0_Date0"
        _Useful_objects0_Date0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Date0.MyObj.MyForm.MyObjs) : _Useful_objects0_Date0.MyObj.MyForm.MyObjs(_Useful_objects0_Date0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Date0.MyObj

        _Useful_objects0_Advanced_tools0.MyObj = New Poleznie("_Advanced tools")
        _Useful_objects0_Advanced_tools0.MyObj.proj = proj
        _Useful_objects0_Advanced_tools0.MyObj.obj = _Useful_objects0_Advanced_tools0
        _Useful_objects0_Advanced_tools0.MyObj.VBname = "_Useful_objects0_Advanced_tools0"
        _Useful_objects0_Advanced_tools0.MyObj.MyObj.MyForm = _Useful_objects0_Useful_objects0.MyObj
        ReDimsO(_Useful_objects0_Advanced_tools0.MyObj.MyForm.MyObjs) : _Useful_objects0_Advanced_tools0.MyObj.MyForm.MyObjs(_Useful_objects0_Advanced_tools0.MyObj.MyForm.MyObjs.Length - 1) = _Useful_objects0_Advanced_tools0.MyObj



        ' Размещение объектов на окнах
        ProgressForm.ProgressBar1.Value = 25
        Window10Window10.Controls.Add(Window10Double_panel10)
        Window10Double_panel10.Panel1.Controls.Add(Window10LabelGoodsNames0)
        Window10Double_panel10.Panel1.Controls.Add(Window10Table10)
        Window10Double_panel10.Panel1.Controls.Add(Window10TextId0)
        ProgressForm.ProgressBar1.Value = 26
        Window10Double_panel10.Panel1.Controls.Add(Window10TextName0)
        Window10Double_panel10.Panel1.Controls.Add(Window10TextCost0)
        Window10Double_panel10.Panel1.Controls.Add(Window10ButtonAdd10)
        Window10Double_panel10.Panel1.Controls.Add(Window10Label30)
        Window10Double_panel10.Panel1.Controls.Add(Window10Label40)
        ProgressForm.ProgressBar1.Value = 27
        Window10Double_panel10.Panel1.Controls.Add(Window10Label50)
        Window10Double_panel10.Panel1.Controls.Add(Window10Label60)
        Window10Double_panel10.Panel1.Controls.Add(Window10Calendar0)
        Window10Double_panel10.Panel1.Controls.Add(Window10CheckBoxDel0)
        Window10Double_panel10.Panel1.Controls.Add(Window10CheckBoxChanges0)
        ProgressForm.ProgressBar1.Value = 28
        Window10Double_panel10.Panel2.Controls.Add(Window10LabelGoodsExists0)
        Window10Double_panel10.Panel2.Controls.Add(Window10Table20)
        Window10Double_panel10.Panel2.Controls.Add(Window10TextId20)
        Window10Double_panel10.Panel2.Controls.Add(Window10TextMarket0)
        Window10Double_panel10.Panel2.Controls.Add(Window10TextCount0)
        ProgressForm.ProgressBar1.Value = 29
        Window10Double_panel10.Panel2.Controls.Add(Window10ButtonAdd20)
        Window10Double_panel10.Panel2.Controls.Add(Window10Label10)
        Window10Double_panel10.Panel2.Controls.Add(Window10Label20)
        Window10Double_panel10.Panel2.Controls.Add(Window10Label70)
        Window10Double_panel10.Panel2.Controls.Add(Window10CheckBoxSizes0)
        ProgressForm.ProgressBar1.Value = 30
        Window10Double_panel10.Panel2.Controls.Add(Window10CheckBoxSelections0)
        Window10MenuTables0.MyObj.addMMenuItem(Window10ItemDuplicate0.MyObj)
        Window10MenuTables0.MyObj.addMMenuItem(Window10ItemDelete0.MyObj)
        Window10MenuTables0.MyObj.addMMenuItem(Window10ItemSplit0.MyObj)
        ProgressForm.ProgressBar1.Value = 31
        Window10MenuTables0.MyObj.addMMenuItem(Window10ItemSelectAll0.MyObj)
        Window10Window10.Controls.Add(Window10Label80)
        Window10Window10.Controls.Add(Window10ComboBoxReports0)
        Window10Window10.Controls.Add(Window10TextQuery0)
        ProgressForm.ProgressBar1.Value = 32
        Window10Window10.Controls.Add(Window10ButtonReports0)
        Window20Window20.Controls.Add(Window20TableReport0)
        Window20Window20.Controls.Add(Window20LabelReport0)
        Window20Window20.Controls.Add(Window20ButtonPreview0)
        ProgressForm.ProgressBar1.Value = 33
        Window20Window20.Controls.Add(Window20ButtonPrint0)
        ProgressForm.ProgressBar1.Value = 33
        ProgressForm.ProgressBar1.Value = 34


        ' Уровнять по уровням объекты
        ProgressForm.ProgressBar1.Value = 35
        Window10ItemSelectAll0.BringToFront()
        Window10Double_panel10.BringToFront()
        Window10TextId0.BringToFront()
        Window10TextName0.BringToFront()
        Window10TextCost0.BringToFront()
        Window10Table10.BringToFront()
        Window10LabelGoodsNames0.BringToFront()
        Window10Label30.BringToFront()
        Window10Label40.BringToFront()
        Window10Label50.BringToFront()
        Window10Label60.BringToFront()
        Window10Calendar0.BringToFront()
        Window10ButtonAdd10.BringToFront()
        Window10CheckBoxDel0.BringToFront()
        Window10Table20.BringToFront()
        Window10LabelGoodsExists0.BringToFront()
        Window10TextId20.BringToFront()
        Window10TextMarket0.BringToFront()
        Window10TextCount0.BringToFront()
        Window10ButtonAdd20.BringToFront()
        Window10Label20.BringToFront()
        Window10Label70.BringToFront()
        Window10TextQuery0.BringToFront()
        Window10CheckBoxSizes0.BringToFront()
        Window10MemoryRowNumber0.BringToFront()
        Window10ButtonReports0.BringToFront()
        Window10ItemSplit0.BringToFront()
        Window10ItemDelete0.BringToFront()
        Window10ItemDuplicate0.BringToFront()
        Window10MenuTables0.BringToFront()
        Window10CheckBoxSelections0.BringToFront()
        Window10Label10.BringToFront()
        Window10CheckBoxChanges0.BringToFront()
        Window10Label80.BringToFront()
        Window10ComboBoxReports0.BringToFront()
        ProgressForm.ProgressBar1.Value = 36
        ProgressForm.ProgressBar1.Value = 37
        ProgressForm.ProgressBar1.Value = 38
        ProgressForm.ProgressBar1.Value = 39
        ProgressForm.ProgressBar1.Value = 40
        ProgressForm.ProgressBar1.Value = 41
        ProgressForm.ProgressBar1.Value = 42
        Window20TableReport0.BringToFront()
        Window20LabelReport0.BringToFront()
        Window20ButtonPreview0.BringToFront()
        Window20ButtonPrint0.BringToFront()
        Window20Print_dialog10.BringToFront()
        ProgressForm.ProgressBar1.Value = 43
        ProgressForm.ProgressBar1.Value = 43
        ProgressForm.ProgressBar1.Value = 44


        ' Настройка свойств объектов
        ProgressForm.ProgressBar1.Value = 45
        Window10Window10.Props.Allowruncopies = perevesti("Yes", True)
        Window10Window10.Props.Associatewithextensions = perevesti("", True)
        Window10Window10.Props.AutoscrollminSizeheight = perevesti("0", True)
        Window10Window10.Props.AutoscrollminSizewidth = perevesti("0", True)
        Window10Window10.Props.AutoscrollpositionX = perevesti("0", True)
        Window10Window10.Props.AutoscrollpositionY = perevesti("0", True)
        Window10Window10.Props.AutoRun = perevesti("No", True)
        Window10Window10.Props.Backcolor = perevesti("235; 233; 237;", True)
        Window10Window10.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Window10.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Window10.Props.Contextmenu(True) = perevesti("MenuTables", True)
        Window10Window10.Props.Controlbox = perevesti("Yes", True)
        Window10Window10.Props.Cursor = perevesti("Default", True)
        Window10Window10.Props.Enabled = perevesti("Yes", True)
        Window10Window10.Props.Forbidclose = perevesti("No", True)
        Window10Window10.Props.Forbidmaximize = perevesti("No", True)
        Window10Window10.Props.Forbidminimize = perevesti("No", True)
        Window10Window10.Props.Forecolor = perevesti("Black", True)
        Window10Window10.Props.Formborderstyle = perevesti("Normal", True)
        Window10Window10.Props.Icon = perevesti("Nothing", True)
        Window10Window10.Props.Index = perevesti("0", True)
        Window10Window10.Props.Mainform = perevesti("Yes", True)
        Window10Window10.Props.Mainmenustrip(True) = perevesti("Nothing", True)
        Window10Window10.Props.Maximumheight = perevesti("0", True)
        Window10Window10.Props.Maximumwidth = perevesti("0", True)
        Window10Window10.Props.Minimumheight = perevesti("0", True)
        Window10Window10.Props.Minimumwidth = perevesti("0", True)
        Window10Window10.Props.Name = perevesti("Window1", True)
        Window10Window10.Props.Opacity = perevesti("100", True)
        Window10Window10.Props.Scroll = perevesti("No", True)
        Window10Window10.Props.Showicon = perevesti("Yes", True)
        Window10Window10.Props.Showintaskbar = perevesti("Yes", True)
        Window10Window10.Props.Showintray = perevesti("No", True)
        Window10Window10.Props.Startposition = perevesti("Specified coordinates", True)
        Window10Window10.Props.Tabindex = perevesti("0", True)
        Window10Window10.Props.Tabstop = perevesti("Yes", True)
        Window10Window10.Props.Tag = perevesti("", True)
        Window10Window10.Props.Text = perevesti("Tables", True)
        Window10Window10.Props.ToolTip = perevesti("", True)
        Window10Window10.Props.TopMost = perevesti("No", True)
        Window10Window10.Props.Transparentcykey = perevesti("Nothing", True)
        Window10Window10.StatusTemp = "Normal"
        Window10Window10.Props.X = perevesti("0", True)
        Window10Window10.Props.Y = perevesti("0", True)
        Window10Window10.Props.Height = perevesti("475", True)
        Window10Window10.Props.Width = perevesti("685", True)
        Window10Window10.Props.Visible = perevesti("Yes", True)
        Window10Window10.Props.Height = perevesti("475", True)
        Window10Window10.Props.Width = perevesti("685", True)

        ProgressForm.ProgressBar1.Value = 46
        Window10Double_panel10.Props.Anchor = perevesti("Right_letf_top_bottom", True)
        Window10Double_panel10.Props.Backcolor = perevesti("Nothing", True)
        Window10Double_panel10.Props.Backcolor1 = perevesti("Nothing", True)
        Window10Double_panel10.Props.Backcolor2 = perevesti("Nothing", True)
        Window10Double_panel10.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Double_panel10.Props.Backgroundimagelayout1 = perevesti("Tile", True)
        Window10Double_panel10.Props.Backgroundimagelayout2 = perevesti("Tile", True)
        Window10Double_panel10.Props.Backgroundimage1 = perevesti("Nothing", True)
        Window10Double_panel10.Props.Backgroundimage2 = perevesti("Nothing", True)
        Window10Double_panel10.Props.Borderstyle = perevesti("Line", True)
        Window10Double_panel10.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Double_panel10.Props.Contextmenu1 = perevesti("Nothing", True)
        Window10Double_panel10.Props.Contextmenu2 = perevesti("Nothing", True)
        Window10Double_panel10.Props.Cursor = perevesti("Default", True)
        Window10Double_panel10.Props.Cursor1 = perevesti("Default", True)
        Window10Double_panel10.Props.Cursor2 = perevesti("Default", True)
        Window10Double_panel10.Props.Dock = perevesti("Top", True)
        Window10Double_panel10.Props.Enabled = perevesti("Yes", True)
        Window10Double_panel10.Props.Fixedpanel = perevesti("Nothing", True)
        Window10Double_panel10.Props.Fixedsplitter = perevesti("No", True)
        Window10Double_panel10.Props.Index = perevesti("0", True)
        Window10Double_panel10.Props.Maximumheight = perevesti("0", True)
        Window10Double_panel10.Props.Maximumwidth = perevesti("0", True)
        Window10Double_panel10.Props.Minimumheight = perevesti("0", True)
        Window10Double_panel10.Props.Minimumwidth = perevesti("0", True)
        Window10Double_panel10.Props.Name = perevesti("Double panel1", True)
        Window10Double_panel10.Props.Orientation = perevesti("Vertical", True)
        Window10Double_panel10.Props.Panel1collapsed = perevesti("No", True)
        Window10Double_panel10.Props.Panel1minSize = perevesti("25", True)
        Window10Double_panel10.Props.Panel2collapsed = perevesti("No", True)
        Window10Double_panel10.Props.Panel2minSize = perevesti("25", True)
        Window10Double_panel10.Props.Scroll1 = perevesti("No", True)
        Window10Double_panel10.Props.Scroll2 = perevesti("No", True)
        Window10Double_panel10.Props.Splitterincrement = perevesti("1", True)
        Window10Double_panel10.Props.Splitterwidth = perevesti("4", True)
        Window10Double_panel10.Props.Tabindex = perevesti("0", True)
        Window10Double_panel10.Props.Tabstop = perevesti("Yes", True)
        Window10Double_panel10.Props.Tag = perevesti("", True)
        Window10Double_panel10.Props.ToolTip = perevesti("", True)
        Window10Double_panel10.Props.X = perevesti("0", True)
        Window10Double_panel10.Props.Y = perevesti("0", True)
        Window10Double_panel10.Props.Height = perevesti("317", True)
        Window10Double_panel10.Props.Width = perevesti("685", True)
        Window10Double_panel10.Props.Visible = perevesti("Yes", True)
        Window10Double_panel10.Props.Height = perevesti("317", True)
        Window10Double_panel10.Props.Width = perevesti("685", True)
        Window10Double_panel10.Props.Splitterdistance = perevesti("338", True)

        ProgressForm.ProgressBar1.Value = 47
        Window10LabelGoodsNames0.Props.Anchor = perevesti("on top", True)
        Window10LabelGoodsNames0.Props.Autoellipsis = perevesti("Yes", True)
        Window10LabelGoodsNames0.Props.Backcolor = perevesti("Nothing", True)
        Window10LabelGoodsNames0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10LabelGoodsNames0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10LabelGoodsNames0.Props.Borderstyle = perevesti("Nothing", True)
        Window10LabelGoodsNames0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10LabelGoodsNames0.Props.Cursor = perevesti("Default", True)
        Window10LabelGoodsNames0.Props.Dock = perevesti("Nothing", True)
        Window10LabelGoodsNames0.Props.Enabled = perevesti("Yes", True)
        Window10LabelGoodsNames0.Props.Fontbold = perevesti("Yes", True)
        Window10LabelGoodsNames0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10LabelGoodsNames0.Props.Fontitalic = perevesti("No", True)
        Window10LabelGoodsNames0.Props.Fontsize = perevesti("11", True)
        Window10LabelGoodsNames0.Props.Fontstrikeout = perevesti("No", True)
        Window10LabelGoodsNames0.Props.Fontunderline = perevesti("No", True)
        Window10LabelGoodsNames0.Props.Forecolor = perevesti("Black", True)
        Window10LabelGoodsNames0.Props.Image = perevesti("Nothing", True)
        Window10LabelGoodsNames0.Props.Imagealign = perevesti("Center", True)
        Window10LabelGoodsNames0.Props.Index = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Maximumheight = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Maximumwidth = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Minimumheight = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Minimumwidth = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Name = perevesti("LabelGoodsNames", True)
        Window10LabelGoodsNames0.Props.Paddingbottom = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Paddingleft = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Paddingright = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Paddingtop = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Tabindex = perevesti("0", True)
        Window10LabelGoodsNames0.Props.Tabstop = perevesti("Yes", True)
        Window10LabelGoodsNames0.Props.Tag = perevesti("", True)
        Window10LabelGoodsNames0.Props.Text = perevesti("Goods names", True)
        Window10LabelGoodsNames0.Props.Textalign = perevesti("center", True)
        Window10LabelGoodsNames0.Props.ToolTip = perevesti("", True)
        Window10LabelGoodsNames0.Props.X = perevesti("-1", True)
        Window10LabelGoodsNames0.Props.Y = perevesti("2", True)
        Window10LabelGoodsNames0.Props.Height = perevesti("19", True)
        Window10LabelGoodsNames0.Props.Width = perevesti("330", True)
        Window10LabelGoodsNames0.Props.Visible = perevesti("Yes", True)
        Window10LabelGoodsNames0.Props.Height = perevesti("19", True)
        Window10LabelGoodsNames0.Props.Width = perevesti("330", True)

        ProgressForm.ProgressBar1.Value = 48
        Window10Table10.Props.AllowUserToAddRows = perevesti("Yes", True)
        Window10Table10.Props.AllowUserToDeleteRows = perevesti("Yes", True)
        Window10Table10.Props.AllowUserToOrderColumns = perevesti("No", True)
        Window10Table10.Props.AllowUserToResizeColumns = perevesti("Yes", True)
        Window10Table10.Props.AllowUserToResizeRows = perevesti("Yes", True)
        Window10Table10.Props.Anchor = perevesti("Right_letf_top_bottom", True)
        Window10Table10.Props.Backcolor = perevesti("128; 128; 128;", True)
        Window10Table10.Props.Borderstyle = perevesti("Nothing", True)
        Window10Table10.Props.Cellborderstyle = perevesti("Default", True)
        Window10Table10.Props.Columnheadersheight = perevesti("23", True)
        Window10Table10.Props.Columnheadersvisible = perevesti("Yes", True)
        Window10Table10.Props.Columns = perevesti("""Column1"", ""Column2"", """", """"", True)
        Window10Table10.Props.Columnscount = perevesti("4", True)
        Window10Table10.Props.Contextmenu(True) = perevesti("MenuTables", True)
        Window10Table10.Props.Cursor = perevesti("Default", True)
        Window10Table10.Props.DefaultCellStyleBackColor = perevesti("255; 255; 255;", True)
        Window10Table10.Props.DefaultCellStyleForeColor = perevesti("0; 0; 0;", True)
        Window10Table10.Props.DefaultCellStyleSelectionBackColor = perevesti("51; 94; 168;", True)
        Window10Table10.Props.DefaultCellStyleSelectionForeColor = perevesti("255; 255; 255;", True)
        Window10Table10.Props.Dock = perevesti("Nothing", True)
        Window10Table10.Props.Editmode = perevesti("Default", True)
        Window10Table10.Props.Enabled = perevesti("Yes", True)
        Window10Table10.Props.Fontbold = perevesti("No", True)
        Window10Table10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Table10.Props.Fontitalic = perevesti("No", True)
        Window10Table10.Props.Fontsize = perevesti("8", True)
        Window10Table10.Props.Fontstrikeout = perevesti("No", True)
        Window10Table10.Props.Fontunderline = perevesti("No", True)
        Window10Table10.Props.Gridcolor = perevesti("SystemDark", True)
        Window10Table10.Props.Heightofrows = perevesti("22,22,22", True)
        Window10Table10.Props.Index = perevesti("0", True)
        Window10Table10.Props.Maximumheight = perevesti("0", True)
        Window10Table10.Props.Maximumwidth = perevesti("0", True)
        Window10Table10.Props.Minimumheight = perevesti("0", True)
        Window10Table10.Props.Minimumwidth = perevesti("0", True)
        Window10Table10.Props.Multiselect = perevesti("Yes", True)
        Window10Table10.Props.Name = perevesti("Table1", True)
        Window10Table10.Props.Readonlytable = perevesti("No", True)
        Window10Table10.Props.Rowheadersvisible = perevesti("No", True)
        Window10Table10.Props.Rows = perevesti("""Row1"" | ""Row1"" | """" | """", ""Row2"" | ""Row2"" | """" | """"", True)
        Window10Table10.Props.Rowscount = perevesti("3", True)
        Window10Table10.Props.Scrollbars = perevesti("Both", True)
        Window10Table10.Props.Selectedcolumns = perevesti("0,1,2,3", True)
        Window10Table10.Props.Selecteditemsvalue = perevesti("""Row1"",""Row1"","""",""""", True)
        Window10Table10.Props.Selectedrows = perevesti("0", True)
        Window10Table10.Props.Selectionmode = perevesti("Rows", True)
        Window10Table10.Props.Tabindex = perevesti("0", True)
        Window10Table10.Props.Tabstop = perevesti("Yes", True)
        Window10Table10.Props.Tag = perevesti("", True)
        Window10Table10.Props.ToolTip = perevesti("", True)
        Window10Table10.Props.Widthofcolumns = perevesti("100,100,100,100", True)
        Window10Table10.Props.X = perevesti("-3", True)
        Window10Table10.Props.Y = perevesti("22", True)
        Window10Table10.Props.Height = perevesti("219", True)
        Window10Table10.Props.Width = perevesti("339", True)
        Window10Table10.Props.Visible = perevesti("Yes", True)
        Window10Table10.Props.Height = perevesti("219", True)
        Window10Table10.Props.Width = perevesti("339", True)

        ProgressForm.ProgressBar1.Value = 49
        Window10TextId0.Props.Allowinput = perevesti("All", True)
        Window10TextId0.Props.Anchor = perevesti("Left_bottom", True)
        Window10TextId0.Props.Backcolor = perevesti("White", True)
        Window10TextId0.Props.Borderstyle = perevesti("3D", True)
        Window10TextId0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10TextId0.Props.Dock = perevesti("Nothing", True)
        Window10TextId0.Props.Enabled = perevesti("Yes", True)
        Window10TextId0.Props.Fontbold = perevesti("No", True)
        Window10TextId0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10TextId0.Props.Fontitalic = perevesti("No", True)
        Window10TextId0.Props.Fontsize = perevesti("8", True)
        Window10TextId0.Props.Fontstrikeout = perevesti("No", True)
        Window10TextId0.Props.Fontunderline = perevesti("No", True)
        Window10TextId0.Props.Forecolor = perevesti("Black", True)
        Window10TextId0.Props.Hideselection = perevesti("No", True)
        Window10TextId0.Props.Index = perevesti("0", True)
        Window10TextId0.Props.Maximumheight = perevesti("0", True)
        Window10TextId0.Props.Maximumlength = perevesti("32767", True)
        Window10TextId0.Props.Maximumwidth = perevesti("0", True)
        Window10TextId0.Props.Minimumheight = perevesti("0", True)
        Window10TextId0.Props.Minimumwidth = perevesti("0", True)
        Window10TextId0.Props.Multiline = perevesti("No", True)
        Window10TextId0.Props.Name = perevesti("TextId", True)
        Window10TextId0.Props.Passwordchar = perevesti("", True)
        Window10TextId0.Props.Readonly = perevesti("No", True)
        Window10TextId0.Props.Scrollbars = perevesti("No", True)
        Window10TextId0.Props.Selectedtext = perevesti("", True)
        Window10TextId0.Props.Selectionlength = perevesti("0", True)
        Window10TextId0.Props.Selectionstart = perevesti("1", True)
        Window10TextId0.Props.Tabindex = perevesti("0", True)
        Window10TextId0.Props.Tabstop = perevesti("Yes", True)
        Window10TextId0.Props.Tag = perevesti("", True)
        Window10TextId0.Props.Text = perevesti("6", True)
        Window10TextId0.Props.Textposition = perevesti("On left", True)
        Window10TextId0.Props.ToolTip = perevesti("", True)
        Window10TextId0.Props.Wordwrap = perevesti("Yes", True)
        Window10TextId0.Props.X = perevesti("5", True)
        Window10TextId0.Props.Y = perevesti("261", True)
        Window10TextId0.Props.Height = perevesti("20", True)
        Window10TextId0.Props.Width = perevesti("30", True)
        Window10TextId0.Props.Visible = perevesti("Yes", True)
        Window10TextId0.Props.Height = perevesti("20", True)
        Window10TextId0.Props.Width = perevesti("30", True)

        ProgressForm.ProgressBar1.Value = 50
        Window10TextName0.Props.Allowinput = perevesti("All", True)
        Window10TextName0.Props.Anchor = perevesti("Right_left_bottom", True)
        Window10TextName0.Props.Backcolor = perevesti("White", True)
        Window10TextName0.Props.Borderstyle = perevesti("3D", True)
        Window10TextName0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10TextName0.Props.Dock = perevesti("Nothing", True)
        Window10TextName0.Props.Enabled = perevesti("Yes", True)
        Window10TextName0.Props.Fontbold = perevesti("No", True)
        Window10TextName0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10TextName0.Props.Fontitalic = perevesti("No", True)
        Window10TextName0.Props.Fontsize = perevesti("8", True)
        Window10TextName0.Props.Fontstrikeout = perevesti("No", True)
        Window10TextName0.Props.Fontunderline = perevesti("No", True)
        Window10TextName0.Props.Forecolor = perevesti("Black", True)
        Window10TextName0.Props.Hideselection = perevesti("No", True)
        Window10TextName0.Props.Index = perevesti("0", True)
        Window10TextName0.Props.Maximumheight = perevesti("0", True)
        Window10TextName0.Props.Maximumlength = perevesti("32767", True)
        Window10TextName0.Props.Maximumwidth = perevesti("0", True)
        Window10TextName0.Props.Minimumheight = perevesti("0", True)
        Window10TextName0.Props.Minimumwidth = perevesti("0", True)
        Window10TextName0.Props.Multiline = perevesti("No", True)
        Window10TextName0.Props.Name = perevesti("TextName", True)
        Window10TextName0.Props.Passwordchar = perevesti("", True)
        Window10TextName0.Props.Readonly = perevesti("No", True)
        Window10TextName0.Props.Scrollbars = perevesti("No", True)
        Window10TextName0.Props.Selectedtext = perevesti("", True)
        Window10TextName0.Props.Selectionlength = perevesti("0", True)
        Window10TextName0.Props.Selectionstart = perevesti("1", True)
        Window10TextName0.Props.Tabindex = perevesti("0", True)
        Window10TextName0.Props.Tabstop = perevesti("Yes", True)
        Window10TextName0.Props.Tag = perevesti("", True)
        Window10TextName0.Props.Text = perevesti("Goods", True)
        Window10TextName0.Props.Textposition = perevesti("On left", True)
        Window10TextName0.Props.ToolTip = perevesti("", True)
        Window10TextName0.Props.Wordwrap = perevesti("Yes", True)
        Window10TextName0.Props.X = perevesti("37", True)
        Window10TextName0.Props.Y = perevesti("262", True)
        Window10TextName0.Props.Height = perevesti("20", True)
        Window10TextName0.Props.Width = perevesti("91", True)
        Window10TextName0.Props.Visible = perevesti("Yes", True)
        Window10TextName0.Props.Height = perevesti("20", True)
        Window10TextName0.Props.Width = perevesti("91", True)

        ProgressForm.ProgressBar1.Value = 51
        Window10TextCost0.Props.Allowinput = perevesti("All", True)
        Window10TextCost0.Props.Anchor = perevesti("Right_bottom", True)
        Window10TextCost0.Props.Backcolor = perevesti("White", True)
        Window10TextCost0.Props.Borderstyle = perevesti("3D", True)
        Window10TextCost0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10TextCost0.Props.Dock = perevesti("Nothing", True)
        Window10TextCost0.Props.Enabled = perevesti("Yes", True)
        Window10TextCost0.Props.Fontbold = perevesti("No", True)
        Window10TextCost0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10TextCost0.Props.Fontitalic = perevesti("No", True)
        Window10TextCost0.Props.Fontsize = perevesti("8", True)
        Window10TextCost0.Props.Fontstrikeout = perevesti("No", True)
        Window10TextCost0.Props.Fontunderline = perevesti("No", True)
        Window10TextCost0.Props.Forecolor = perevesti("Black", True)
        Window10TextCost0.Props.Hideselection = perevesti("No", True)
        Window10TextCost0.Props.Index = perevesti("0", True)
        Window10TextCost0.Props.Maximumheight = perevesti("0", True)
        Window10TextCost0.Props.Maximumlength = perevesti("32767", True)
        Window10TextCost0.Props.Maximumwidth = perevesti("0", True)
        Window10TextCost0.Props.Minimumheight = perevesti("0", True)
        Window10TextCost0.Props.Minimumwidth = perevesti("0", True)
        Window10TextCost0.Props.Multiline = perevesti("No", True)
        Window10TextCost0.Props.Name = perevesti("TextCost", True)
        Window10TextCost0.Props.Passwordchar = perevesti("", True)
        Window10TextCost0.Props.Readonly = perevesti("No", True)
        Window10TextCost0.Props.Scrollbars = perevesti("No", True)
        Window10TextCost0.Props.Selectedtext = perevesti("", True)
        Window10TextCost0.Props.Selectionlength = perevesti("0", True)
        Window10TextCost0.Props.Selectionstart = perevesti("1", True)
        Window10TextCost0.Props.Tabindex = perevesti("0", True)
        Window10TextCost0.Props.Tabstop = perevesti("Yes", True)
        Window10TextCost0.Props.Tag = perevesti("", True)
        Window10TextCost0.Props.Text = perevesti("100", True)
        Window10TextCost0.Props.Textposition = perevesti("On left", True)
        Window10TextCost0.Props.ToolTip = perevesti("", True)
        Window10TextCost0.Props.Wordwrap = perevesti("Yes", True)
        Window10TextCost0.Props.X = perevesti("130", True)
        Window10TextCost0.Props.Y = perevesti("261", True)
        Window10TextCost0.Props.Height = perevesti("20", True)
        Window10TextCost0.Props.Width = perevesti("38", True)
        Window10TextCost0.Props.Visible = perevesti("Yes", True)
        Window10TextCost0.Props.Height = perevesti("20", True)
        Window10TextCost0.Props.Width = perevesti("38", True)

        ProgressForm.ProgressBar1.Value = 52
        Window10ButtonAdd10.Props.Anchor = perevesti("Right_bottom", True)
        Window10ButtonAdd10.Props.Autoellipsis = perevesti("Yes", True)
        Window10ButtonAdd10.Props.Backcolor = perevesti("Nothing", True)
        Window10ButtonAdd10.Props.Backgroundimage = perevesti("Nothing", True)
        Window10ButtonAdd10.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10ButtonAdd10.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10ButtonAdd10.Props.Cursor = perevesti("Default", True)
        Window10ButtonAdd10.Props.Dock = perevesti("Nothing", True)
        Window10ButtonAdd10.Props.Enabled = perevesti("Yes", True)
        Window10ButtonAdd10.Props.Flatstyle = perevesti("Default", True)
        Window10ButtonAdd10.Props.Fontbold = perevesti("No", True)
        Window10ButtonAdd10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10ButtonAdd10.Props.Fontitalic = perevesti("No", True)
        Window10ButtonAdd10.Props.Fontsize = perevesti("8", True)
        Window10ButtonAdd10.Props.Fontstrikeout = perevesti("No", True)
        Window10ButtonAdd10.Props.Fontunderline = perevesti("No", True)
        Window10ButtonAdd10.Props.Forecolor = perevesti("Black", True)
        Window10ButtonAdd10.Props.Image = perevesti("Nothing", True)
        Window10ButtonAdd10.Props.Imagealign = perevesti("Center", True)
        Window10ButtonAdd10.Props.Index = perevesti("0", True)
        Window10ButtonAdd10.Props.Maximumheight = perevesti("0", True)
        Window10ButtonAdd10.Props.Maximumwidth = perevesti("0", True)
        Window10ButtonAdd10.Props.Minimumheight = perevesti("0", True)
        Window10ButtonAdd10.Props.Minimumwidth = perevesti("0", True)
        Window10ButtonAdd10.Props.Name = perevesti("ButtonAdd1", True)
        Window10ButtonAdd10.Props.Paddingbottom = perevesti("0", True)
        Window10ButtonAdd10.Props.Paddingleft = perevesti("0", True)
        Window10ButtonAdd10.Props.Paddingright = perevesti("0", True)
        Window10ButtonAdd10.Props.Paddingtop = perevesti("0", True)
        Window10ButtonAdd10.Props.Tabindex = perevesti("0", True)
        Window10ButtonAdd10.Props.Tabstop = perevesti("Yes", True)
        Window10ButtonAdd10.Props.Tag = perevesti("", True)
        Window10ButtonAdd10.Props.Text = perevesti("Add", True)
        Window10ButtonAdd10.Props.Textalign = perevesti("center", True)
        Window10ButtonAdd10.Props.Textimagerelation = perevesti("Overlay", True)
        Window10ButtonAdd10.Props.ToolTip = perevesti("", True)
        Window10ButtonAdd10.Props.X = perevesti("261", True)
        Window10ButtonAdd10.Props.Y = perevesti("259", True)
        Window10ButtonAdd10.Props.Height = perevesti("23", True)
        Window10ButtonAdd10.Props.Width = perevesti("71", True)
        Window10ButtonAdd10.Props.Visible = perevesti("Yes", True)
        Window10ButtonAdd10.Props.Height = perevesti("23", True)
        Window10ButtonAdd10.Props.Width = perevesti("71", True)

        ProgressForm.ProgressBar1.Value = 53
        Window10Label30.Props.Anchor = perevesti("Left_bottom", True)
        Window10Label30.Props.Autoellipsis = perevesti("Yes", True)
        Window10Label30.Props.Backcolor = perevesti("Nothing", True)
        Window10Label30.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Label30.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Label30.Props.Borderstyle = perevesti("Nothing", True)
        Window10Label30.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Label30.Props.Cursor = perevesti("Default", True)
        Window10Label30.Props.Dock = perevesti("Nothing", True)
        Window10Label30.Props.Enabled = perevesti("Yes", True)
        Window10Label30.Props.Fontbold = perevesti("No", True)
        Window10Label30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Label30.Props.Fontitalic = perevesti("No", True)
        Window10Label30.Props.Fontsize = perevesti("8", True)
        Window10Label30.Props.Fontstrikeout = perevesti("No", True)
        Window10Label30.Props.Fontunderline = perevesti("No", True)
        Window10Label30.Props.Forecolor = perevesti("Black", True)
        Window10Label30.Props.Image = perevesti("Nothing", True)
        Window10Label30.Props.Imagealign = perevesti("Center", True)
        Window10Label30.Props.Index = perevesti("0", True)
        Window10Label30.Props.Maximumheight = perevesti("0", True)
        Window10Label30.Props.Maximumwidth = perevesti("0", True)
        Window10Label30.Props.Minimumheight = perevesti("0", True)
        Window10Label30.Props.Minimumwidth = perevesti("0", True)
        Window10Label30.Props.Name = perevesti("Label3", True)
        Window10Label30.Props.Paddingbottom = perevesti("0", True)
        Window10Label30.Props.Paddingleft = perevesti("0", True)
        Window10Label30.Props.Paddingright = perevesti("0", True)
        Window10Label30.Props.Paddingtop = perevesti("0", True)
        Window10Label30.Props.Tabindex = perevesti("0", True)
        Window10Label30.Props.Tabstop = perevesti("Yes", True)
        Window10Label30.Props.Tag = perevesti("", True)
        Window10Label30.Props.Text = perevesti("Id", True)
        Window10Label30.Props.Textalign = perevesti("center", True)
        Window10Label30.Props.ToolTip = perevesti("", True)
        Window10Label30.Props.X = perevesti("5", True)
        Window10Label30.Props.Y = perevesti("246", True)
        Window10Label30.Props.Height = perevesti("13", True)
        Window10Label30.Props.Width = perevesti("27", True)
        Window10Label30.Props.Visible = perevesti("Yes", True)
        Window10Label30.Props.Height = perevesti("13", True)
        Window10Label30.Props.Width = perevesti("27", True)

        ProgressForm.ProgressBar1.Value = 54
        Window10Label40.Props.Anchor = perevesti("Right_left_bottom", True)
        Window10Label40.Props.Autoellipsis = perevesti("Yes", True)
        Window10Label40.Props.Backcolor = perevesti("Nothing", True)
        Window10Label40.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Label40.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Label40.Props.Borderstyle = perevesti("Nothing", True)
        Window10Label40.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Label40.Props.Cursor = perevesti("Default", True)
        Window10Label40.Props.Dock = perevesti("Nothing", True)
        Window10Label40.Props.Enabled = perevesti("Yes", True)
        Window10Label40.Props.Fontbold = perevesti("No", True)
        Window10Label40.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Label40.Props.Fontitalic = perevesti("No", True)
        Window10Label40.Props.Fontsize = perevesti("8", True)
        Window10Label40.Props.Fontstrikeout = perevesti("No", True)
        Window10Label40.Props.Fontunderline = perevesti("No", True)
        Window10Label40.Props.Forecolor = perevesti("Black", True)
        Window10Label40.Props.Image = perevesti("Nothing", True)
        Window10Label40.Props.Imagealign = perevesti("Center", True)
        Window10Label40.Props.Index = perevesti("0", True)
        Window10Label40.Props.Maximumheight = perevesti("0", True)
        Window10Label40.Props.Maximumwidth = perevesti("0", True)
        Window10Label40.Props.Minimumheight = perevesti("0", True)
        Window10Label40.Props.Minimumwidth = perevesti("0", True)
        Window10Label40.Props.Name = perevesti("Label4", True)
        Window10Label40.Props.Paddingbottom = perevesti("0", True)
        Window10Label40.Props.Paddingleft = perevesti("0", True)
        Window10Label40.Props.Paddingright = perevesti("0", True)
        Window10Label40.Props.Paddingtop = perevesti("0", True)
        Window10Label40.Props.Tabindex = perevesti("0", True)
        Window10Label40.Props.Tabstop = perevesti("Yes", True)
        Window10Label40.Props.Tag = perevesti("", True)
        Window10Label40.Props.Text = perevesti("Name", True)
        Window10Label40.Props.Textalign = perevesti("center", True)
        Window10Label40.Props.ToolTip = perevesti("", True)
        Window10Label40.Props.X = perevesti("37", True)
        Window10Label40.Props.Y = perevesti("246", True)
        Window10Label40.Props.Height = perevesti("13", True)
        Window10Label40.Props.Width = perevesti("88", True)
        Window10Label40.Props.Visible = perevesti("Yes", True)
        Window10Label40.Props.Height = perevesti("13", True)
        Window10Label40.Props.Width = perevesti("88", True)

        ProgressForm.ProgressBar1.Value = 55
        Window10Label50.Props.Anchor = perevesti("Right_bottom", True)
        Window10Label50.Props.Autoellipsis = perevesti("Yes", True)
        Window10Label50.Props.Backcolor = perevesti("Nothing", True)
        Window10Label50.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Label50.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Label50.Props.Borderstyle = perevesti("Nothing", True)
        Window10Label50.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Label50.Props.Cursor = perevesti("Default", True)
        Window10Label50.Props.Dock = perevesti("Nothing", True)
        Window10Label50.Props.Enabled = perevesti("Yes", True)
        Window10Label50.Props.Fontbold = perevesti("No", True)
        Window10Label50.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Label50.Props.Fontitalic = perevesti("No", True)
        Window10Label50.Props.Fontsize = perevesti("8", True)
        Window10Label50.Props.Fontstrikeout = perevesti("No", True)
        Window10Label50.Props.Fontunderline = perevesti("No", True)
        Window10Label50.Props.Forecolor = perevesti("Black", True)
        Window10Label50.Props.Image = perevesti("Nothing", True)
        Window10Label50.Props.Imagealign = perevesti("Center", True)
        Window10Label50.Props.Index = perevesti("0", True)
        Window10Label50.Props.Maximumheight = perevesti("0", True)
        Window10Label50.Props.Maximumwidth = perevesti("0", True)
        Window10Label50.Props.Minimumheight = perevesti("0", True)
        Window10Label50.Props.Minimumwidth = perevesti("0", True)
        Window10Label50.Props.Name = perevesti("Label5", True)
        Window10Label50.Props.Paddingbottom = perevesti("0", True)
        Window10Label50.Props.Paddingleft = perevesti("0", True)
        Window10Label50.Props.Paddingright = perevesti("0", True)
        Window10Label50.Props.Paddingtop = perevesti("0", True)
        Window10Label50.Props.Tabindex = perevesti("0", True)
        Window10Label50.Props.Tabstop = perevesti("Yes", True)
        Window10Label50.Props.Tag = perevesti("", True)
        Window10Label50.Props.Text = perevesti("Cost", True)
        Window10Label50.Props.Textalign = perevesti("center", True)
        Window10Label50.Props.ToolTip = perevesti("", True)
        Window10Label50.Props.X = perevesti("130", True)
        Window10Label50.Props.Y = perevesti("245", True)
        Window10Label50.Props.Height = perevesti("13", True)
        Window10Label50.Props.Width = perevesti("35", True)
        Window10Label50.Props.Visible = perevesti("Yes", True)
        Window10Label50.Props.Height = perevesti("13", True)
        Window10Label50.Props.Width = perevesti("35", True)

        ProgressForm.ProgressBar1.Value = 56
        Window10Label60.Props.Anchor = perevesti("Right_bottom", True)
        Window10Label60.Props.Autoellipsis = perevesti("Yes", True)
        Window10Label60.Props.Backcolor = perevesti("Nothing", True)
        Window10Label60.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Label60.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Label60.Props.Borderstyle = perevesti("Nothing", True)
        Window10Label60.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Label60.Props.Cursor = perevesti("Default", True)
        Window10Label60.Props.Dock = perevesti("Nothing", True)
        Window10Label60.Props.Enabled = perevesti("Yes", True)
        Window10Label60.Props.Fontbold = perevesti("No", True)
        Window10Label60.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Label60.Props.Fontitalic = perevesti("No", True)
        Window10Label60.Props.Fontsize = perevesti("8", True)
        Window10Label60.Props.Fontstrikeout = perevesti("No", True)
        Window10Label60.Props.Fontunderline = perevesti("No", True)
        Window10Label60.Props.Forecolor = perevesti("Black", True)
        Window10Label60.Props.Image = perevesti("Nothing", True)
        Window10Label60.Props.Imagealign = perevesti("Center", True)
        Window10Label60.Props.Index = perevesti("0", True)
        Window10Label60.Props.Maximumheight = perevesti("0", True)
        Window10Label60.Props.Maximumwidth = perevesti("0", True)
        Window10Label60.Props.Minimumheight = perevesti("0", True)
        Window10Label60.Props.Minimumwidth = perevesti("0", True)
        Window10Label60.Props.Name = perevesti("Label6", True)
        Window10Label60.Props.Paddingbottom = perevesti("0", True)
        Window10Label60.Props.Paddingleft = perevesti("0", True)
        Window10Label60.Props.Paddingright = perevesti("0", True)
        Window10Label60.Props.Paddingtop = perevesti("0", True)
        Window10Label60.Props.Tabindex = perevesti("0", True)
        Window10Label60.Props.Tabstop = perevesti("Yes", True)
        Window10Label60.Props.Tag = perevesti("", True)
        Window10Label60.Props.Text = perevesti("Date", True)
        Window10Label60.Props.Textalign = perevesti("center", True)
        Window10Label60.Props.ToolTip = perevesti("", True)
        Window10Label60.Props.X = perevesti("170", True)
        Window10Label60.Props.Y = perevesti("245", True)
        Window10Label60.Props.Height = perevesti("13", True)
        Window10Label60.Props.Width = perevesti("86", True)
        Window10Label60.Props.Visible = perevesti("Yes", True)
        Window10Label60.Props.Height = perevesti("13", True)
        Window10Label60.Props.Width = perevesti("86", True)

        ProgressForm.ProgressBar1.Value = 57
        Window10Calendar0.Props.Anchor = perevesti("Right_bottom", True)
        Window10Calendar0.Props.Calendardateformat = perevesti("custom", True)
        Window10Calendar0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Calendar0.Props.Cursor = perevesti("Default", True)
        Window10Calendar0.Props.Customdateformat = perevesti("dd MMM yyyy", True)
        Window10Calendar0.Props.Dock = perevesti("Nothing", True)
        Window10Calendar0.Props.Enabled = perevesti("Yes", True)
        Window10Calendar0.Props.Fontbold = perevesti("No", True)
        Window10Calendar0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Calendar0.Props.Fontitalic = perevesti("No", True)
        Window10Calendar0.Props.Fontsize = perevesti("8", True)
        Window10Calendar0.Props.Fontstrikeout = perevesti("No", True)
        Window10Calendar0.Props.Fontunderline = perevesti("No", True)
        Window10Calendar0.Props.Forecolor = perevesti("Black", True)
        Window10Calendar0.Props.Index = perevesti("0", True)
        Window10Calendar0.Props.Maximumheight = perevesti("0", True)
        Window10Calendar0.Props.Maximumwidth = perevesti("0", True)
        Window10Calendar0.Props.Minimumheight = perevesti("0", True)
        Window10Calendar0.Props.Minimumwidth = perevesti("0", True)
        Window10Calendar0.Props.Name = perevesti("Calendar", True)
        Window10Calendar0.Props.Selecteddate = perevesti("15.06.2009 0:00:00", True)
        Window10Calendar0.Props.Showupdown = perevesti("No", True)
        Window10Calendar0.Props.Tabindex = perevesti("0", True)
        Window10Calendar0.Props.Tabstop = perevesti("Yes", True)
        Window10Calendar0.Props.Tag = perevesti("", True)
        Window10Calendar0.Props.Text = perevesti("15 июн 2009", True)
        Window10Calendar0.Props.ToolTip = perevesti("", True)
        Window10Calendar0.Props.X = perevesti("170", True)
        Window10Calendar0.Props.Y = perevesti("261", True)
        Window10Calendar0.Props.Height = perevesti("20", True)
        Window10Calendar0.Props.Width = perevesti("88", True)
        Window10Calendar0.Props.Visible = perevesti("Yes", True)
        Window10Calendar0.Props.Height = perevesti("20", True)
        Window10Calendar0.Props.Width = perevesti("88", True)

        ProgressForm.ProgressBar1.Value = 58
        Window10CheckBoxDel0.Props.Anchor = perevesti("Left_bottom", True)
        Window10CheckBoxDel0.Props.Autoellipsis = perevesti("Yes", True)
        Window10CheckBoxDel0.Props.Backcolor = perevesti("Nothing", True)
        Window10CheckBoxDel0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10CheckBoxDel0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10CheckBoxDel0.Props.Checked = perevesti("No", True)
        Window10CheckBoxDel0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10CheckBoxDel0.Props.Cursor = perevesti("Default", True)
        Window10CheckBoxDel0.Props.Dock = perevesti("Nothing", True)
        Window10CheckBoxDel0.Props.Enabled = perevesti("Yes", True)
        Window10CheckBoxDel0.Props.Flatstyle = perevesti("Default", True)
        Window10CheckBoxDel0.Props.Fontbold = perevesti("No", True)
        Window10CheckBoxDel0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10CheckBoxDel0.Props.Fontitalic = perevesti("No", True)
        Window10CheckBoxDel0.Props.Fontsize = perevesti("8", True)
        Window10CheckBoxDel0.Props.Fontstrikeout = perevesti("No", True)
        Window10CheckBoxDel0.Props.Fontunderline = perevesti("No", True)
        Window10CheckBoxDel0.Props.Forecolor = perevesti("0; 0; 0;", True)
        Window10CheckBoxDel0.Props.Image = perevesti("Nothing", True)
        Window10CheckBoxDel0.Props.Imagealign = perevesti("Center", True)
        Window10CheckBoxDel0.Props.Index = perevesti("0", True)
        Window10CheckBoxDel0.Props.Maximumheight = perevesti("0", True)
        Window10CheckBoxDel0.Props.Maximumwidth = perevesti("0", True)
        Window10CheckBoxDel0.Props.Minimumheight = perevesti("0", True)
        Window10CheckBoxDel0.Props.Minimumwidth = perevesti("0", True)
        Window10CheckBoxDel0.Props.Name = perevesti("CheckBoxDel", True)
        Window10CheckBoxDel0.Props.Paddingbottom = perevesti("0", True)
        Window10CheckBoxDel0.Props.Paddingleft = perevesti("0", True)
        Window10CheckBoxDel0.Props.Paddingright = perevesti("0", True)
        Window10CheckBoxDel0.Props.Paddingtop = perevesti("0", True)
        Window10CheckBoxDel0.Props.Tabindex = perevesti("0", True)
        Window10CheckBoxDel0.Props.Tabstop = perevesti("Yes", True)
        Window10CheckBoxDel0.Props.Tag = perevesti("", True)
        Window10CheckBoxDel0.Props.Text = perevesti("Not to allow to delete rows", True)
        Window10CheckBoxDel0.Props.Textalign = perevesti("on left", True)
        Window10CheckBoxDel0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10CheckBoxDel0.Props.ToolTip = perevesti("", True)
        Window10CheckBoxDel0.Props.X = perevesti("8", True)
        Window10CheckBoxDel0.Props.Y = perevesti("283", True)
        Window10CheckBoxDel0.Props.Height = perevesti("33", True)
        Window10CheckBoxDel0.Props.Width = perevesti("164", True)
        Window10CheckBoxDel0.Props.Visible = perevesti("Yes", True)
        Window10CheckBoxDel0.Props.Height = perevesti("33", True)
        Window10CheckBoxDel0.Props.Width = perevesti("164", True)

        ProgressForm.ProgressBar1.Value = 60
        Window10CheckBoxChanges0.Props.Anchor = perevesti("Right_left_bottom", True)
        Window10CheckBoxChanges0.Props.Autoellipsis = perevesti("Yes", True)
        Window10CheckBoxChanges0.Props.Backcolor = perevesti("Nothing", True)
        Window10CheckBoxChanges0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10CheckBoxChanges0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10CheckBoxChanges0.Props.Checked = perevesti("No", True)
        Window10CheckBoxChanges0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10CheckBoxChanges0.Props.Cursor = perevesti("Default", True)
        Window10CheckBoxChanges0.Props.Dock = perevesti("Nothing", True)
        Window10CheckBoxChanges0.Props.Enabled = perevesti("Yes", True)
        Window10CheckBoxChanges0.Props.Flatstyle = perevesti("Default", True)
        Window10CheckBoxChanges0.Props.Fontbold = perevesti("No", True)
        Window10CheckBoxChanges0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10CheckBoxChanges0.Props.Fontitalic = perevesti("No", True)
        Window10CheckBoxChanges0.Props.Fontsize = perevesti("8", True)
        Window10CheckBoxChanges0.Props.Fontstrikeout = perevesti("No", True)
        Window10CheckBoxChanges0.Props.Fontunderline = perevesti("No", True)
        Window10CheckBoxChanges0.Props.Forecolor = perevesti("0; 0; 0;", True)
        Window10CheckBoxChanges0.Props.Image = perevesti("Nothing", True)
        Window10CheckBoxChanges0.Props.Imagealign = perevesti("Center", True)
        Window10CheckBoxChanges0.Props.Index = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Maximumheight = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Maximumwidth = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Minimumheight = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Minimumwidth = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Name = perevesti("CheckBoxChanges", True)
        Window10CheckBoxChanges0.Props.Paddingbottom = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Paddingleft = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Paddingright = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Paddingtop = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Tabindex = perevesti("0", True)
        Window10CheckBoxChanges0.Props.Tabstop = perevesti("Yes", True)
        Window10CheckBoxChanges0.Props.Tag = perevesti("", True)
        Window10CheckBoxChanges0.Props.Text = perevesti("Not to allow to edit table", True)
        Window10CheckBoxChanges0.Props.Textalign = perevesti("on left", True)
        Window10CheckBoxChanges0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10CheckBoxChanges0.Props.ToolTip = perevesti("", True)
        Window10CheckBoxChanges0.Props.X = perevesti("177", True)
        Window10CheckBoxChanges0.Props.Y = perevesti("283", True)
        Window10CheckBoxChanges0.Props.Height = perevesti("34", True)
        Window10CheckBoxChanges0.Props.Width = perevesti("146", True)
        Window10CheckBoxChanges0.Props.Visible = perevesti("Yes", True)
        Window10CheckBoxChanges0.Props.Height = perevesti("34", True)
        Window10CheckBoxChanges0.Props.Width = perevesti("146", True)

        ProgressForm.ProgressBar1.Value = 61
        Window10LabelGoodsExists0.Props.Anchor = perevesti("on top", True)
        Window10LabelGoodsExists0.Props.Autoellipsis = perevesti("Yes", True)
        Window10LabelGoodsExists0.Props.Backcolor = perevesti("Nothing", True)
        Window10LabelGoodsExists0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10LabelGoodsExists0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10LabelGoodsExists0.Props.Borderstyle = perevesti("Nothing", True)
        Window10LabelGoodsExists0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10LabelGoodsExists0.Props.Cursor = perevesti("Default", True)
        Window10LabelGoodsExists0.Props.Dock = perevesti("Nothing", True)
        Window10LabelGoodsExists0.Props.Enabled = perevesti("Yes", True)
        Window10LabelGoodsExists0.Props.Fontbold = perevesti("Yes", True)
        Window10LabelGoodsExists0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10LabelGoodsExists0.Props.Fontitalic = perevesti("No", True)
        Window10LabelGoodsExists0.Props.Fontsize = perevesti("11", True)
        Window10LabelGoodsExists0.Props.Fontstrikeout = perevesti("No", True)
        Window10LabelGoodsExists0.Props.Fontunderline = perevesti("No", True)
        Window10LabelGoodsExists0.Props.Forecolor = perevesti("Black", True)
        Window10LabelGoodsExists0.Props.Image = perevesti("Nothing", True)
        Window10LabelGoodsExists0.Props.Imagealign = perevesti("Center", True)
        Window10LabelGoodsExists0.Props.Index = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Maximumheight = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Maximumwidth = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Minimumheight = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Minimumwidth = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Name = perevesti("LabelGoodsExists", True)
        Window10LabelGoodsExists0.Props.Paddingbottom = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Paddingleft = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Paddingright = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Paddingtop = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Tabindex = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Tabstop = perevesti("Yes", True)
        Window10LabelGoodsExists0.Props.Tag = perevesti("", True)
        Window10LabelGoodsExists0.Props.Text = perevesti("Goods exists", True)
        Window10LabelGoodsExists0.Props.Textalign = perevesti("center", True)
        Window10LabelGoodsExists0.Props.ToolTip = perevesti("", True)
        Window10LabelGoodsExists0.Props.X = perevesti("0", True)
        Window10LabelGoodsExists0.Props.Y = perevesti("2", True)
        Window10LabelGoodsExists0.Props.Height = perevesti("19", True)
        Window10LabelGoodsExists0.Props.Width = perevesti("341", True)
        Window10LabelGoodsExists0.Props.Visible = perevesti("Yes", True)
        Window10LabelGoodsExists0.Props.Height = perevesti("19", True)
        Window10LabelGoodsExists0.Props.Width = perevesti("341", True)

        ProgressForm.ProgressBar1.Value = 62
        Window10Table20.Props.AllowUserToAddRows = perevesti("Yes", True)
        Window10Table20.Props.AllowUserToDeleteRows = perevesti("Yes", True)
        Window10Table20.Props.AllowUserToOrderColumns = perevesti("No", True)
        Window10Table20.Props.AllowUserToResizeColumns = perevesti("Yes", True)
        Window10Table20.Props.AllowUserToResizeRows = perevesti("Yes", True)
        Window10Table20.Props.Anchor = perevesti("Right_letf_top_bottom", True)
        Window10Table20.Props.Backcolor = perevesti("128; 128; 128;", True)
        Window10Table20.Props.Borderstyle = perevesti("Nothing", True)
        Window10Table20.Props.Cellborderstyle = perevesti("Default", True)
        Window10Table20.Props.Columnheadersheight = perevesti("23", True)
        Window10Table20.Props.Columnheadersvisible = perevesti("Yes", True)
        Window10Table20.Props.Columns = perevesti("""Column1"", ""Column2"", ""Column3""", True)
        Window10Table20.Props.Columnscount = perevesti("3", True)
        Window10Table20.Props.Contextmenu(True) = perevesti("MenuTables", True)
        Window10Table20.Props.Cursor = perevesti("Default", True)
        Window10Table20.Props.DefaultCellStyleBackColor = perevesti("255; 255; 255;", True)
        Window10Table20.Props.DefaultCellStyleForeColor = perevesti("0; 0; 0;", True)
        Window10Table20.Props.DefaultCellStyleSelectionBackColor = perevesti("51; 94; 168;", True)
        Window10Table20.Props.DefaultCellStyleSelectionForeColor = perevesti("255; 255; 255;", True)
        Window10Table20.Props.Dock = perevesti("Nothing", True)
        Window10Table20.Props.Editmode = perevesti("Default", True)
        Window10Table20.Props.Enabled = perevesti("Yes", True)
        Window10Table20.Props.Fontbold = perevesti("No", True)
        Window10Table20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Table20.Props.Fontitalic = perevesti("No", True)
        Window10Table20.Props.Fontsize = perevesti("8", True)
        Window10Table20.Props.Fontstrikeout = perevesti("No", True)
        Window10Table20.Props.Fontunderline = perevesti("No", True)
        Window10Table20.Props.Gridcolor = perevesti("SystemDark", True)
        Window10Table20.Props.Heightofrows = perevesti("22,22,22", True)
        Window10Table20.Props.Index = perevesti("0", True)
        Window10Table20.Props.Maximumheight = perevesti("0", True)
        Window10Table20.Props.Maximumwidth = perevesti("0", True)
        Window10Table20.Props.Minimumheight = perevesti("0", True)
        Window10Table20.Props.Minimumwidth = perevesti("0", True)
        Window10Table20.Props.Multiselect = perevesti("Yes", True)
        Window10Table20.Props.Name = perevesti("Table2", True)
        Window10Table20.Props.Readonlytable = perevesti("No", True)
        Window10Table20.Props.Rowheadersvisible = perevesti("No", True)
        Window10Table20.Props.Rows = perevesti("""Row1"" | ""Row1"" | ""Row1"", ""Row2"" | ""Row2"" | ""Row2""", True)
        Window10Table20.Props.Rowscount = perevesti("3", True)
        Window10Table20.Props.Scrollbars = perevesti("Both", True)
        Window10Table20.Props.Selectedcolumns = perevesti("0,1,2", True)
        Window10Table20.Props.Selecteditemsvalue = perevesti("""Row1"",""Row1"",""Row1""", True)
        Window10Table20.Props.Selectedrows = perevesti("0", True)
        Window10Table20.Props.Selectionmode = perevesti("Rows", True)
        Window10Table20.Props.Tabindex = perevesti("0", True)
        Window10Table20.Props.Tabstop = perevesti("Yes", True)
        Window10Table20.Props.Tag = perevesti("", True)
        Window10Table20.Props.ToolTip = perevesti("", True)
        Window10Table20.Props.Widthofcolumns = perevesti("100,100,100", True)
        Window10Table20.Props.X = perevesti("1", True)
        Window10Table20.Props.Y = perevesti("22", True)
        Window10Table20.Props.Height = perevesti("218", True)
        Window10Table20.Props.Width = perevesti("341", True)
        Window10Table20.Props.Visible = perevesti("Yes", True)
        Window10Table20.Props.Height = perevesti("218", True)
        Window10Table20.Props.Width = perevesti("341", True)

        ProgressForm.ProgressBar1.Value = 63
        Window10TextId20.Props.Allowinput = perevesti("All", True)
        Window10TextId20.Props.Anchor = perevesti("Left_bottom", True)
        Window10TextId20.Props.Backcolor = perevesti("White", True)
        Window10TextId20.Props.Borderstyle = perevesti("3D", True)
        Window10TextId20.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10TextId20.Props.Dock = perevesti("Nothing", True)
        Window10TextId20.Props.Enabled = perevesti("Yes", True)
        Window10TextId20.Props.Fontbold = perevesti("No", True)
        Window10TextId20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10TextId20.Props.Fontitalic = perevesti("No", True)
        Window10TextId20.Props.Fontsize = perevesti("8", True)
        Window10TextId20.Props.Fontstrikeout = perevesti("No", True)
        Window10TextId20.Props.Fontunderline = perevesti("No", True)
        Window10TextId20.Props.Forecolor = perevesti("Black", True)
        Window10TextId20.Props.Hideselection = perevesti("No", True)
        Window10TextId20.Props.Index = perevesti("0", True)
        Window10TextId20.Props.Maximumheight = perevesti("0", True)
        Window10TextId20.Props.Maximumlength = perevesti("32767", True)
        Window10TextId20.Props.Maximumwidth = perevesti("0", True)
        Window10TextId20.Props.Minimumheight = perevesti("0", True)
        Window10TextId20.Props.Minimumwidth = perevesti("0", True)
        Window10TextId20.Props.Multiline = perevesti("No", True)
        Window10TextId20.Props.Name = perevesti("TextId2", True)
        Window10TextId20.Props.Passwordchar = perevesti("", True)
        Window10TextId20.Props.Readonly = perevesti("No", True)
        Window10TextId20.Props.Scrollbars = perevesti("No", True)
        Window10TextId20.Props.Selectedtext = perevesti("", True)
        Window10TextId20.Props.Selectionlength = perevesti("0", True)
        Window10TextId20.Props.Selectionstart = perevesti("1", True)
        Window10TextId20.Props.Tabindex = perevesti("0", True)
        Window10TextId20.Props.Tabstop = perevesti("Yes", True)
        Window10TextId20.Props.Tag = perevesti("", True)
        Window10TextId20.Props.Text = perevesti("1", True)
        Window10TextId20.Props.Textposition = perevesti("On left", True)
        Window10TextId20.Props.ToolTip = perevesti("", True)
        Window10TextId20.Props.Wordwrap = perevesti("Yes", True)
        Window10TextId20.Props.X = perevesti("5", True)
        Window10TextId20.Props.Y = perevesti("261", True)
        Window10TextId20.Props.Height = perevesti("20", True)
        Window10TextId20.Props.Width = perevesti("30", True)
        Window10TextId20.Props.Visible = perevesti("Yes", True)
        Window10TextId20.Props.Height = perevesti("20", True)
        Window10TextId20.Props.Width = perevesti("30", True)

        ProgressForm.ProgressBar1.Value = 64
        Window10TextMarket0.Props.Allowinput = perevesti("All", True)
        Window10TextMarket0.Props.Anchor = perevesti("Right_left_bottom", True)
        Window10TextMarket0.Props.Backcolor = perevesti("White", True)
        Window10TextMarket0.Props.Borderstyle = perevesti("3D", True)
        Window10TextMarket0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10TextMarket0.Props.Dock = perevesti("Nothing", True)
        Window10TextMarket0.Props.Enabled = perevesti("Yes", True)
        Window10TextMarket0.Props.Fontbold = perevesti("No", True)
        Window10TextMarket0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10TextMarket0.Props.Fontitalic = perevesti("No", True)
        Window10TextMarket0.Props.Fontsize = perevesti("8", True)
        Window10TextMarket0.Props.Fontstrikeout = perevesti("No", True)
        Window10TextMarket0.Props.Fontunderline = perevesti("No", True)
        Window10TextMarket0.Props.Forecolor = perevesti("Black", True)
        Window10TextMarket0.Props.Hideselection = perevesti("No", True)
        Window10TextMarket0.Props.Index = perevesti("0", True)
        Window10TextMarket0.Props.Maximumheight = perevesti("0", True)
        Window10TextMarket0.Props.Maximumlength = perevesti("32767", True)
        Window10TextMarket0.Props.Maximumwidth = perevesti("0", True)
        Window10TextMarket0.Props.Minimumheight = perevesti("0", True)
        Window10TextMarket0.Props.Minimumwidth = perevesti("0", True)
        Window10TextMarket0.Props.Multiline = perevesti("No", True)
        Window10TextMarket0.Props.Name = perevesti("TextMarket", True)
        Window10TextMarket0.Props.Passwordchar = perevesti("", True)
        Window10TextMarket0.Props.Readonly = perevesti("No", True)
        Window10TextMarket0.Props.Scrollbars = perevesti("No", True)
        Window10TextMarket0.Props.Selectedtext = perevesti("", True)
        Window10TextMarket0.Props.Selectionlength = perevesti("0", True)
        Window10TextMarket0.Props.Selectionstart = perevesti("1", True)
        Window10TextMarket0.Props.Tabindex = perevesti("0", True)
        Window10TextMarket0.Props.Tabstop = perevesti("Yes", True)
        Window10TextMarket0.Props.Tag = perevesti("", True)
        Window10TextMarket0.Props.Text = perevesti("Market #15", True)
        Window10TextMarket0.Props.Textposition = perevesti("On left", True)
        Window10TextMarket0.Props.ToolTip = perevesti("", True)
        Window10TextMarket0.Props.Wordwrap = perevesti("Yes", True)
        Window10TextMarket0.Props.X = perevesti("37", True)
        Window10TextMarket0.Props.Y = perevesti("262", True)
        Window10TextMarket0.Props.Height = perevesti("20", True)
        Window10TextMarket0.Props.Width = perevesti("145", True)
        Window10TextMarket0.Props.Visible = perevesti("Yes", True)
        Window10TextMarket0.Props.Height = perevesti("20", True)
        Window10TextMarket0.Props.Width = perevesti("145", True)

        ProgressForm.ProgressBar1.Value = 65
        Window10TextCount0.Props.Allowinput = perevesti("All", True)
        Window10TextCount0.Props.Anchor = perevesti("Right_bottom", True)
        Window10TextCount0.Props.Backcolor = perevesti("White", True)
        Window10TextCount0.Props.Borderstyle = perevesti("3D", True)
        Window10TextCount0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10TextCount0.Props.Dock = perevesti("Nothing", True)
        Window10TextCount0.Props.Enabled = perevesti("Yes", True)
        Window10TextCount0.Props.Fontbold = perevesti("No", True)
        Window10TextCount0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10TextCount0.Props.Fontitalic = perevesti("No", True)
        Window10TextCount0.Props.Fontsize = perevesti("8", True)
        Window10TextCount0.Props.Fontstrikeout = perevesti("No", True)
        Window10TextCount0.Props.Fontunderline = perevesti("No", True)
        Window10TextCount0.Props.Forecolor = perevesti("Black", True)
        Window10TextCount0.Props.Hideselection = perevesti("No", True)
        Window10TextCount0.Props.Index = perevesti("0", True)
        Window10TextCount0.Props.Maximumheight = perevesti("0", True)
        Window10TextCount0.Props.Maximumlength = perevesti("32767", True)
        Window10TextCount0.Props.Maximumwidth = perevesti("0", True)
        Window10TextCount0.Props.Minimumheight = perevesti("0", True)
        Window10TextCount0.Props.Minimumwidth = perevesti("0", True)
        Window10TextCount0.Props.Multiline = perevesti("No", True)
        Window10TextCount0.Props.Name = perevesti("TextCount", True)
        Window10TextCount0.Props.Passwordchar = perevesti("", True)
        Window10TextCount0.Props.Readonly = perevesti("No", True)
        Window10TextCount0.Props.Scrollbars = perevesti("No", True)
        Window10TextCount0.Props.Selectedtext = perevesti("", True)
        Window10TextCount0.Props.Selectionlength = perevesti("0", True)
        Window10TextCount0.Props.Selectionstart = perevesti("1", True)
        Window10TextCount0.Props.Tabindex = perevesti("0", True)
        Window10TextCount0.Props.Tabstop = perevesti("Yes", True)
        Window10TextCount0.Props.Tag = perevesti("", True)
        Window10TextCount0.Props.Text = perevesti("20", True)
        Window10TextCount0.Props.Textposition = perevesti("On left", True)
        Window10TextCount0.Props.ToolTip = perevesti("", True)
        Window10TextCount0.Props.Wordwrap = perevesti("Yes", True)
        Window10TextCount0.Props.X = perevesti("189", True)
        Window10TextCount0.Props.Y = perevesti("262", True)
        Window10TextCount0.Props.Height = perevesti("20", True)
        Window10TextCount0.Props.Width = perevesti("70", True)
        Window10TextCount0.Props.Visible = perevesti("Yes", True)
        Window10TextCount0.Props.Height = perevesti("20", True)
        Window10TextCount0.Props.Width = perevesti("70", True)

        ProgressForm.ProgressBar1.Value = 66
        Window10ButtonAdd20.Props.Anchor = perevesti("Right_bottom", True)
        Window10ButtonAdd20.Props.Autoellipsis = perevesti("Yes", True)
        Window10ButtonAdd20.Props.Backcolor = perevesti("Nothing", True)
        Window10ButtonAdd20.Props.Backgroundimage = perevesti("Nothing", True)
        Window10ButtonAdd20.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10ButtonAdd20.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10ButtonAdd20.Props.Cursor = perevesti("Default", True)
        Window10ButtonAdd20.Props.Dock = perevesti("Nothing", True)
        Window10ButtonAdd20.Props.Enabled = perevesti("Yes", True)
        Window10ButtonAdd20.Props.Flatstyle = perevesti("Default", True)
        Window10ButtonAdd20.Props.Fontbold = perevesti("No", True)
        Window10ButtonAdd20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10ButtonAdd20.Props.Fontitalic = perevesti("No", True)
        Window10ButtonAdd20.Props.Fontsize = perevesti("8", True)
        Window10ButtonAdd20.Props.Fontstrikeout = perevesti("No", True)
        Window10ButtonAdd20.Props.Fontunderline = perevesti("No", True)
        Window10ButtonAdd20.Props.Forecolor = perevesti("Black", True)
        Window10ButtonAdd20.Props.Image = perevesti("Nothing", True)
        Window10ButtonAdd20.Props.Imagealign = perevesti("Center", True)
        Window10ButtonAdd20.Props.Index = perevesti("0", True)
        Window10ButtonAdd20.Props.Maximumheight = perevesti("0", True)
        Window10ButtonAdd20.Props.Maximumwidth = perevesti("0", True)
        Window10ButtonAdd20.Props.Minimumheight = perevesti("0", True)
        Window10ButtonAdd20.Props.Minimumwidth = perevesti("0", True)
        Window10ButtonAdd20.Props.Name = perevesti("ButtonAdd2", True)
        Window10ButtonAdd20.Props.Paddingbottom = perevesti("0", True)
        Window10ButtonAdd20.Props.Paddingleft = perevesti("0", True)
        Window10ButtonAdd20.Props.Paddingright = perevesti("0", True)
        Window10ButtonAdd20.Props.Paddingtop = perevesti("0", True)
        Window10ButtonAdd20.Props.Tabindex = perevesti("0", True)
        Window10ButtonAdd20.Props.Tabstop = perevesti("Yes", True)
        Window10ButtonAdd20.Props.Tag = perevesti("", True)
        Window10ButtonAdd20.Props.Text = perevesti("Add", True)
        Window10ButtonAdd20.Props.Textalign = perevesti("center", True)
        Window10ButtonAdd20.Props.Textimagerelation = perevesti("Overlay", True)
        Window10ButtonAdd20.Props.ToolTip = perevesti("", True)
        Window10ButtonAdd20.Props.X = perevesti("264", True)
        Window10ButtonAdd20.Props.Y = perevesti("259", True)
        Window10ButtonAdd20.Props.Height = perevesti("23", True)
        Window10ButtonAdd20.Props.Width = perevesti("72", True)
        Window10ButtonAdd20.Props.Visible = perevesti("Yes", True)
        Window10ButtonAdd20.Props.Height = perevesti("23", True)
        Window10ButtonAdd20.Props.Width = perevesti("72", True)

        ProgressForm.ProgressBar1.Value = 67
        Window10Label10.Props.Anchor = perevesti("Left_bottom", True)
        Window10Label10.Props.Autoellipsis = perevesti("Yes", True)
        Window10Label10.Props.Backcolor = perevesti("Nothing", True)
        Window10Label10.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Label10.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Label10.Props.Borderstyle = perevesti("Nothing", True)
        Window10Label10.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Label10.Props.Cursor = perevesti("Default", True)
        Window10Label10.Props.Dock = perevesti("Nothing", True)
        Window10Label10.Props.Enabled = perevesti("Yes", True)
        Window10Label10.Props.Fontbold = perevesti("No", True)
        Window10Label10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Label10.Props.Fontitalic = perevesti("No", True)
        Window10Label10.Props.Fontsize = perevesti("8", True)
        Window10Label10.Props.Fontstrikeout = perevesti("No", True)
        Window10Label10.Props.Fontunderline = perevesti("No", True)
        Window10Label10.Props.Forecolor = perevesti("Black", True)
        Window10Label10.Props.Image = perevesti("Nothing", True)
        Window10Label10.Props.Imagealign = perevesti("Center", True)
        Window10Label10.Props.Index = perevesti("0", True)
        Window10Label10.Props.Maximumheight = perevesti("0", True)
        Window10Label10.Props.Maximumwidth = perevesti("0", True)
        Window10Label10.Props.Minimumheight = perevesti("0", True)
        Window10Label10.Props.Minimumwidth = perevesti("0", True)
        Window10Label10.Props.Name = perevesti("Label1", True)
        Window10Label10.Props.Paddingbottom = perevesti("0", True)
        Window10Label10.Props.Paddingleft = perevesti("0", True)
        Window10Label10.Props.Paddingright = perevesti("0", True)
        Window10Label10.Props.Paddingtop = perevesti("0", True)
        Window10Label10.Props.Tabindex = perevesti("0", True)
        Window10Label10.Props.Tabstop = perevesti("Yes", True)
        Window10Label10.Props.Tag = perevesti("", True)
        Window10Label10.Props.Text = perevesti("Goods id", True)
        Window10Label10.Props.Textalign = perevesti("center", True)
        Window10Label10.Props.ToolTip = perevesti("", True)
        Window10Label10.Props.X = perevesti("-4", True)
        Window10Label10.Props.Y = perevesti("246", True)
        Window10Label10.Props.Height = perevesti("13", True)
        Window10Label10.Props.Width = perevesti("62", True)
        Window10Label10.Props.Visible = perevesti("Yes", True)
        Window10Label10.Props.Height = perevesti("13", True)
        Window10Label10.Props.Width = perevesti("62", True)

        ProgressForm.ProgressBar1.Value = 68
        Window10Label20.Props.Anchor = perevesti("Right_left_bottom", True)
        Window10Label20.Props.Autoellipsis = perevesti("Yes", True)
        Window10Label20.Props.Backcolor = perevesti("Nothing", True)
        Window10Label20.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Label20.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Label20.Props.Borderstyle = perevesti("Nothing", True)
        Window10Label20.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Label20.Props.Cursor = perevesti("Default", True)
        Window10Label20.Props.Dock = perevesti("Nothing", True)
        Window10Label20.Props.Enabled = perevesti("Yes", True)
        Window10Label20.Props.Fontbold = perevesti("No", True)
        Window10Label20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Label20.Props.Fontitalic = perevesti("No", True)
        Window10Label20.Props.Fontsize = perevesti("8", True)
        Window10Label20.Props.Fontstrikeout = perevesti("No", True)
        Window10Label20.Props.Fontunderline = perevesti("No", True)
        Window10Label20.Props.Forecolor = perevesti("Black", True)
        Window10Label20.Props.Image = perevesti("Nothing", True)
        Window10Label20.Props.Imagealign = perevesti("Center", True)
        Window10Label20.Props.Index = perevesti("0", True)
        Window10Label20.Props.Maximumheight = perevesti("0", True)
        Window10Label20.Props.Maximumwidth = perevesti("0", True)
        Window10Label20.Props.Minimumheight = perevesti("0", True)
        Window10Label20.Props.Minimumwidth = perevesti("0", True)
        Window10Label20.Props.Name = perevesti("Label2", True)
        Window10Label20.Props.Paddingbottom = perevesti("0", True)
        Window10Label20.Props.Paddingleft = perevesti("0", True)
        Window10Label20.Props.Paddingright = perevesti("0", True)
        Window10Label20.Props.Paddingtop = perevesti("0", True)
        Window10Label20.Props.Tabindex = perevesti("0", True)
        Window10Label20.Props.Tabstop = perevesti("Yes", True)
        Window10Label20.Props.Tag = perevesti("", True)
        Window10Label20.Props.Text = perevesti("Market", True)
        Window10Label20.Props.Textalign = perevesti("center", True)
        Window10Label20.Props.ToolTip = perevesti("", True)
        Window10Label20.Props.X = perevesti("37", True)
        Window10Label20.Props.Y = perevesti("246", True)
        Window10Label20.Props.Height = perevesti("13", True)
        Window10Label20.Props.Width = perevesti("142", True)
        Window10Label20.Props.Visible = perevesti("Yes", True)
        Window10Label20.Props.Height = perevesti("13", True)
        Window10Label20.Props.Width = perevesti("142", True)

        ProgressForm.ProgressBar1.Value = 69
        Window10Label70.Props.Anchor = perevesti("Right_bottom", True)
        Window10Label70.Props.Autoellipsis = perevesti("Yes", True)
        Window10Label70.Props.Backcolor = perevesti("Nothing", True)
        Window10Label70.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Label70.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Label70.Props.Borderstyle = perevesti("Nothing", True)
        Window10Label70.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Label70.Props.Cursor = perevesti("Default", True)
        Window10Label70.Props.Dock = perevesti("Nothing", True)
        Window10Label70.Props.Enabled = perevesti("Yes", True)
        Window10Label70.Props.Fontbold = perevesti("No", True)
        Window10Label70.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Label70.Props.Fontitalic = perevesti("No", True)
        Window10Label70.Props.Fontsize = perevesti("8", True)
        Window10Label70.Props.Fontstrikeout = perevesti("No", True)
        Window10Label70.Props.Fontunderline = perevesti("No", True)
        Window10Label70.Props.Forecolor = perevesti("Black", True)
        Window10Label70.Props.Image = perevesti("Nothing", True)
        Window10Label70.Props.Imagealign = perevesti("Center", True)
        Window10Label70.Props.Index = perevesti("0", True)
        Window10Label70.Props.Maximumheight = perevesti("0", True)
        Window10Label70.Props.Maximumwidth = perevesti("0", True)
        Window10Label70.Props.Minimumheight = perevesti("0", True)
        Window10Label70.Props.Minimumwidth = perevesti("0", True)
        Window10Label70.Props.Name = perevesti("Label7", True)
        Window10Label70.Props.Paddingbottom = perevesti("0", True)
        Window10Label70.Props.Paddingleft = perevesti("0", True)
        Window10Label70.Props.Paddingright = perevesti("0", True)
        Window10Label70.Props.Paddingtop = perevesti("0", True)
        Window10Label70.Props.Tabindex = perevesti("0", True)
        Window10Label70.Props.Tabstop = perevesti("Yes", True)
        Window10Label70.Props.Tag = perevesti("", True)
        Window10Label70.Props.Text = perevesti("Count", True)
        Window10Label70.Props.Textalign = perevesti("center", True)
        Window10Label70.Props.ToolTip = perevesti("", True)
        Window10Label70.Props.X = perevesti("189", True)
        Window10Label70.Props.Y = perevesti("246", True)
        Window10Label70.Props.Height = perevesti("13", True)
        Window10Label70.Props.Width = perevesti("67", True)
        Window10Label70.Props.Visible = perevesti("Yes", True)
        Window10Label70.Props.Height = perevesti("13", True)
        Window10Label70.Props.Width = perevesti("67", True)

        ProgressForm.ProgressBar1.Value = 70
        Window10CheckBoxSizes0.Props.Anchor = perevesti("Left_bottom", True)
        Window10CheckBoxSizes0.Props.Autoellipsis = perevesti("Yes", True)
        Window10CheckBoxSizes0.Props.Backcolor = perevesti("Nothing", True)
        Window10CheckBoxSizes0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10CheckBoxSizes0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10CheckBoxSizes0.Props.Checked = perevesti("No", True)
        Window10CheckBoxSizes0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10CheckBoxSizes0.Props.Cursor = perevesti("Default", True)
        Window10CheckBoxSizes0.Props.Dock = perevesti("Nothing", True)
        Window10CheckBoxSizes0.Props.Enabled = perevesti("Yes", True)
        Window10CheckBoxSizes0.Props.Flatstyle = perevesti("Default", True)
        Window10CheckBoxSizes0.Props.Fontbold = perevesti("No", True)
        Window10CheckBoxSizes0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10CheckBoxSizes0.Props.Fontitalic = perevesti("No", True)
        Window10CheckBoxSizes0.Props.Fontsize = perevesti("8", True)
        Window10CheckBoxSizes0.Props.Fontstrikeout = perevesti("No", True)
        Window10CheckBoxSizes0.Props.Fontunderline = perevesti("No", True)
        Window10CheckBoxSizes0.Props.Forecolor = perevesti("0; 0; 0;", True)
        Window10CheckBoxSizes0.Props.Image = perevesti("Nothing", True)
        Window10CheckBoxSizes0.Props.Imagealign = perevesti("Center", True)
        Window10CheckBoxSizes0.Props.Index = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Maximumheight = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Maximumwidth = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Minimumheight = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Minimumwidth = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Name = perevesti("CheckBoxSizes", True)
        Window10CheckBoxSizes0.Props.Paddingbottom = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Paddingleft = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Paddingright = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Paddingtop = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Tabindex = perevesti("0", True)
        Window10CheckBoxSizes0.Props.Tabstop = perevesti("Yes", True)
        Window10CheckBoxSizes0.Props.Tag = perevesti("", True)
        Window10CheckBoxSizes0.Props.Text = perevesti("Not to allow to resize", True)
        Window10CheckBoxSizes0.Props.Textalign = perevesti("on left", True)
        Window10CheckBoxSizes0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10CheckBoxSizes0.Props.ToolTip = perevesti("", True)
        Window10CheckBoxSizes0.Props.X = perevesti("8", True)
        Window10CheckBoxSizes0.Props.Y = perevesti("283", True)
        Window10CheckBoxSizes0.Props.Height = perevesti("33", True)
        Window10CheckBoxSizes0.Props.Width = perevesti("158", True)
        Window10CheckBoxSizes0.Props.Visible = perevesti("Yes", True)
        Window10CheckBoxSizes0.Props.Height = perevesti("33", True)
        Window10CheckBoxSizes0.Props.Width = perevesti("158", True)

        ProgressForm.ProgressBar1.Value = 71
        Window10CheckBoxSelections0.Props.Anchor = perevesti("Right_left_bottom", True)
        Window10CheckBoxSelections0.Props.Autoellipsis = perevesti("Yes", True)
        Window10CheckBoxSelections0.Props.Backcolor = perevesti("Nothing", True)
        Window10CheckBoxSelections0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10CheckBoxSelections0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10CheckBoxSelections0.Props.Checked = perevesti("No", True)
        Window10CheckBoxSelections0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10CheckBoxSelections0.Props.Cursor = perevesti("Default", True)
        Window10CheckBoxSelections0.Props.Dock = perevesti("Nothing", True)
        Window10CheckBoxSelections0.Props.Enabled = perevesti("Yes", True)
        Window10CheckBoxSelections0.Props.Flatstyle = perevesti("Default", True)
        Window10CheckBoxSelections0.Props.Fontbold = perevesti("No", True)
        Window10CheckBoxSelections0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10CheckBoxSelections0.Props.Fontitalic = perevesti("No", True)
        Window10CheckBoxSelections0.Props.Fontsize = perevesti("8", True)
        Window10CheckBoxSelections0.Props.Fontstrikeout = perevesti("No", True)
        Window10CheckBoxSelections0.Props.Fontunderline = perevesti("No", True)
        Window10CheckBoxSelections0.Props.Forecolor = perevesti("0; 0; 0;", True)
        Window10CheckBoxSelections0.Props.Image = perevesti("Nothing", True)
        Window10CheckBoxSelections0.Props.Imagealign = perevesti("Center", True)
        Window10CheckBoxSelections0.Props.Index = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Maximumheight = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Maximumwidth = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Minimumheight = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Minimumwidth = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Name = perevesti("CheckBoxSelections", True)
        Window10CheckBoxSelections0.Props.Paddingbottom = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Paddingleft = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Paddingright = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Paddingtop = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Tabindex = perevesti("0", True)
        Window10CheckBoxSelections0.Props.Tabstop = perevesti("Yes", True)
        Window10CheckBoxSelections0.Props.Tag = perevesti("", True)
        Window10CheckBoxSelections0.Props.Text = perevesti("Cell select mode", True)
        Window10CheckBoxSelections0.Props.Textalign = perevesti("on left", True)
        Window10CheckBoxSelections0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10CheckBoxSelections0.Props.ToolTip = perevesti("", True)
        Window10CheckBoxSelections0.Props.X = perevesti("179", True)
        Window10CheckBoxSelections0.Props.Y = perevesti("284", True)
        Window10CheckBoxSelections0.Props.Height = perevesti("34", True)
        Window10CheckBoxSelections0.Props.Width = perevesti("159", True)
        Window10CheckBoxSelections0.Props.Visible = perevesti("Yes", True)
        Window10CheckBoxSelections0.Props.Height = perevesti("34", True)
        Window10CheckBoxSelections0.Props.Width = perevesti("159", True)

        ProgressForm.ProgressBar1.Value = 72
        Window10MenuTables0.Props.Index = perevesti("0", True)
        Window10MenuTables0.Props.Name = perevesti("MenuTables", True)
        Window10MenuTables0.Props.Ownerobject = perevesti("Nothing", True)
        Window10MenuTables0.Props.X = perevesti("34", True)
        Window10MenuTables0.Props.Y = perevesti("6", True)

        ProgressForm.ProgressBar1.Value = 73
        Window10ItemDuplicate0.Props.Alignment = perevesti("Yes", True)
        Window10ItemDuplicate0.Props.Autotooltip = perevesti("No", True)
        Window10ItemDuplicate0.Props.Backcolor = perevesti("Nothing", True)
        Window10ItemDuplicate0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10ItemDuplicate0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10ItemDuplicate0.Props.Checkonclick = perevesti("No", True)
        Window10ItemDuplicate0.Props.Checked = perevesti("No", True)
        Window10ItemDuplicate0.Props.Displaystyle = perevesti("Image and text", True)
        Window10ItemDuplicate0.Props.Dropdown(True) = perevesti("Nothing", True)
        Window10ItemDuplicate0.Props.Enabled = perevesti("Yes", True)
        Window10ItemDuplicate0.Props.Fontbold = perevesti("No", True)
        Window10ItemDuplicate0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10ItemDuplicate0.Props.Fontitalic = perevesti("No", True)
        Window10ItemDuplicate0.Props.Fontsize = perevesti("8", True)
        Window10ItemDuplicate0.Props.Fontstrikeout = perevesti("No", True)
        Window10ItemDuplicate0.Props.Fontunderline = perevesti("No", True)
        Window10ItemDuplicate0.Props.Forecolor = perevesti("Black", True)
        Window10ItemDuplicate0.Props.Image = perevesti("Nothing", True)
        Window10ItemDuplicate0.Props.Imagealign = perevesti("Center", True)
        Window10ItemDuplicate0.Props.Imagescaling = perevesti("No", True)
        Window10ItemDuplicate0.Props.Imagetransparentcolor = perevesti("Nothing", True)
        Window10ItemDuplicate0.Props.Index = perevesti("0", True)
        Window10ItemDuplicate0.Props.Name = perevesti("ItemDuplicate", True)
        Window10ItemDuplicate0.Props.Paddingbottom = perevesti("0", True)
        Window10ItemDuplicate0.Props.Paddingleft = perevesti("0", True)
        Window10ItemDuplicate0.Props.Paddingright = perevesti("0", True)
        Window10ItemDuplicate0.Props.Paddingtop = perevesti("0", True)
        Window10ItemDuplicate0.Props.Position = perevesti("0", True)
        Window10ItemDuplicate0.Props.Shortcutkeys = perevesti("control; shift; c;", True)
        Window10ItemDuplicate0.Props.Showshortcutkeys = perevesti("Yes", True)
        Window10ItemDuplicate0.Props.Tag = perevesti("", True)
        Window10ItemDuplicate0.Props.Text = perevesti("Дублировать", True)
        Window10ItemDuplicate0.Props.Textdirection = perevesti("Horizontal0", True)
        Window10ItemDuplicate0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10ItemDuplicate0.Props.Tooltiptext = perevesti("", True)
        Window10ItemDuplicate0.Props.Visible = perevesti("Yes", True)

        ProgressForm.ProgressBar1.Value = 74
        Window10ItemDelete0.Props.Alignment = perevesti("Yes", True)
        Window10ItemDelete0.Props.Autotooltip = perevesti("No", True)
        Window10ItemDelete0.Props.Backcolor = perevesti("Nothing", True)
        Window10ItemDelete0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10ItemDelete0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10ItemDelete0.Props.Checkonclick = perevesti("No", True)
        Window10ItemDelete0.Props.Checked = perevesti("No", True)
        Window10ItemDelete0.Props.Displaystyle = perevesti("Image and text", True)
        Window10ItemDelete0.Props.Dropdown(True) = perevesti("Nothing", True)
        Window10ItemDelete0.Props.Enabled = perevesti("Yes", True)
        Window10ItemDelete0.Props.Fontbold = perevesti("No", True)
        Window10ItemDelete0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10ItemDelete0.Props.Fontitalic = perevesti("No", True)
        Window10ItemDelete0.Props.Fontsize = perevesti("8", True)
        Window10ItemDelete0.Props.Fontstrikeout = perevesti("No", True)
        Window10ItemDelete0.Props.Fontunderline = perevesti("No", True)
        Window10ItemDelete0.Props.Forecolor = perevesti("Black", True)
        Window10ItemDelete0.Props.Image = perevesti("Nothing", True)
        Window10ItemDelete0.Props.Imagealign = perevesti("Center", True)
        Window10ItemDelete0.Props.Imagescaling = perevesti("No", True)
        Window10ItemDelete0.Props.Imagetransparentcolor = perevesti("Nothing", True)
        Window10ItemDelete0.Props.Index = perevesti("0", True)
        Window10ItemDelete0.Props.Name = perevesti("ItemDelete", True)
        Window10ItemDelete0.Props.Paddingbottom = perevesti("0", True)
        Window10ItemDelete0.Props.Paddingleft = perevesti("0", True)
        Window10ItemDelete0.Props.Paddingright = perevesti("0", True)
        Window10ItemDelete0.Props.Paddingtop = perevesti("0", True)
        Window10ItemDelete0.Props.Position = perevesti("1", True)
        Window10ItemDelete0.Props.Shortcutkeys = perevesti("Nothing", True)
        Window10ItemDelete0.Props.Showshortcutkeys = perevesti("Yes", True)
        Window10ItemDelete0.Props.Tag = perevesti("", True)
        Window10ItemDelete0.Props.Text = perevesti("Удалить", True)
        Window10ItemDelete0.Props.Textdirection = perevesti("Horizontal0", True)
        Window10ItemDelete0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10ItemDelete0.Props.Tooltiptext = perevesti("", True)
        Window10ItemDelete0.Props.Visible = perevesti("Yes", True)

        ProgressForm.ProgressBar1.Value = 75
        Window10ItemSplit0.Props.Alignment = perevesti("Yes", True)
        Window10ItemSplit0.Props.Autotooltip = perevesti("No", True)
        Window10ItemSplit0.Props.Backcolor = perevesti("Nothing", True)
        Window10ItemSplit0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10ItemSplit0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10ItemSplit0.Props.Checkonclick = perevesti("No", True)
        Window10ItemSplit0.Props.Checked = perevesti("No", True)
        Window10ItemSplit0.Props.Displaystyle = perevesti("Image and text", True)
        Window10ItemSplit0.Props.Dropdown(True) = perevesti("Nothing", True)
        Window10ItemSplit0.Props.Enabled = perevesti("Yes", True)
        Window10ItemSplit0.Props.Fontbold = perevesti("No", True)
        Window10ItemSplit0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10ItemSplit0.Props.Fontitalic = perevesti("No", True)
        Window10ItemSplit0.Props.Fontsize = perevesti("8", True)
        Window10ItemSplit0.Props.Fontstrikeout = perevesti("No", True)
        Window10ItemSplit0.Props.Fontunderline = perevesti("No", True)
        Window10ItemSplit0.Props.Forecolor = perevesti("Black", True)
        Window10ItemSplit0.Props.Image = perevesti("Nothing", True)
        Window10ItemSplit0.Props.Imagealign = perevesti("Center", True)
        Window10ItemSplit0.Props.Imagescaling = perevesti("No", True)
        Window10ItemSplit0.Props.Imagetransparentcolor = perevesti("Nothing", True)
        Window10ItemSplit0.Props.Index = perevesti("0", True)
        Window10ItemSplit0.Props.Name = perevesti("ItemSplit", True)
        Window10ItemSplit0.Props.Paddingbottom = perevesti("0", True)
        Window10ItemSplit0.Props.Paddingleft = perevesti("0", True)
        Window10ItemSplit0.Props.Paddingright = perevesti("0", True)
        Window10ItemSplit0.Props.Paddingtop = perevesti("0", True)
        Window10ItemSplit0.Props.Position = perevesti("2", True)
        Window10ItemSplit0.Props.Shortcutkeys = perevesti("Nothing", True)
        Window10ItemSplit0.Props.Showshortcutkeys = perevesti("Yes", True)
        Window10ItemSplit0.Props.Tag = perevesti("", True)
        Window10ItemSplit0.Props.Text = perevesti("-", True)
        Window10ItemSplit0.Props.Textdirection = perevesti("Horizontal0", True)
        Window10ItemSplit0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10ItemSplit0.Props.Tooltiptext = perevesti("", True)
        Window10ItemSplit0.Props.Visible = perevesti("Yes", True)

        ProgressForm.ProgressBar1.Value = 76
        Window10ItemSelectAll0.Props.Alignment = perevesti("Yes", True)
        Window10ItemSelectAll0.Props.Autotooltip = perevesti("No", True)
        Window10ItemSelectAll0.Props.Backcolor = perevesti("Nothing", True)
        Window10ItemSelectAll0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10ItemSelectAll0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10ItemSelectAll0.Props.Checkonclick = perevesti("No", True)
        Window10ItemSelectAll0.Props.Checked = perevesti("No", True)
        Window10ItemSelectAll0.Props.Displaystyle = perevesti("Image and text", True)
        Window10ItemSelectAll0.Props.Dropdown(True) = perevesti("Nothing", True)
        Window10ItemSelectAll0.Props.Enabled = perevesti("Yes", True)
        Window10ItemSelectAll0.Props.Fontbold = perevesti("No", True)
        Window10ItemSelectAll0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10ItemSelectAll0.Props.Fontitalic = perevesti("No", True)
        Window10ItemSelectAll0.Props.Fontsize = perevesti("8", True)
        Window10ItemSelectAll0.Props.Fontstrikeout = perevesti("No", True)
        Window10ItemSelectAll0.Props.Fontunderline = perevesti("No", True)
        Window10ItemSelectAll0.Props.Forecolor = perevesti("Black", True)
        Window10ItemSelectAll0.Props.Image = perevesti("Nothing", True)
        Window10ItemSelectAll0.Props.Imagealign = perevesti("Center", True)
        Window10ItemSelectAll0.Props.Imagescaling = perevesti("No", True)
        Window10ItemSelectAll0.Props.Imagetransparentcolor = perevesti("Nothing", True)
        Window10ItemSelectAll0.Props.Index = perevesti("0", True)
        Window10ItemSelectAll0.Props.Name = perevesti("ItemSelectAll", True)
        Window10ItemSelectAll0.Props.Paddingbottom = perevesti("0", True)
        Window10ItemSelectAll0.Props.Paddingleft = perevesti("0", True)
        Window10ItemSelectAll0.Props.Paddingright = perevesti("0", True)
        Window10ItemSelectAll0.Props.Paddingtop = perevesti("0", True)
        Window10ItemSelectAll0.Props.Position = perevesti("3", True)
        Window10ItemSelectAll0.Props.Shortcutkeys = perevesti("Nothing", True)
        Window10ItemSelectAll0.Props.Showshortcutkeys = perevesti("Yes", True)
        Window10ItemSelectAll0.Props.Tag = perevesti("", True)
        Window10ItemSelectAll0.Props.Text = perevesti("Выделить всё", True)
        Window10ItemSelectAll0.Props.Textdirection = perevesti("Horizontal0", True)
        Window10ItemSelectAll0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10ItemSelectAll0.Props.Tooltiptext = perevesti("", True)
        Window10ItemSelectAll0.Props.Visible = perevesti("Yes", True)

        ProgressForm.ProgressBar1.Value = 77
        Window10MemoryRowNumber0.Props.Enabled = perevesti("Yes", True)
        Window10MemoryRowNumber0.Props.Index = perevesti("0", True)
        Window10MemoryRowNumber0.Props.Name = perevesti("MemoryRowNumber", True)
        Window10MemoryRowNumber0.Props.Tag = perevesti("", True)
        Window10MemoryRowNumber0.Props.X = perevesti("56", True)
        Window10MemoryRowNumber0.Props.Y = perevesti("10", True)
        Window10MemoryRowNumber0.Props.Value = perevesti("", True)

        ProgressForm.ProgressBar1.Value = 78
        Window10Label80.Props.Anchor = perevesti("Right_left_bottom", True)
        Window10Label80.Props.Autoellipsis = perevesti("Yes", True)
        Window10Label80.Props.Backcolor = perevesti("Nothing", True)
        Window10Label80.Props.Backgroundimage = perevesti("Nothing", True)
        Window10Label80.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10Label80.Props.Borderstyle = perevesti("Nothing", True)
        Window10Label80.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10Label80.Props.Cursor = perevesti("Default", True)
        Window10Label80.Props.Dock = perevesti("Nothing", True)
        Window10Label80.Props.Enabled = perevesti("Yes", True)
        Window10Label80.Props.Fontbold = perevesti("Yes", True)
        Window10Label80.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10Label80.Props.Fontitalic = perevesti("No", True)
        Window10Label80.Props.Fontsize = perevesti("11", True)
        Window10Label80.Props.Fontstrikeout = perevesti("No", True)
        Window10Label80.Props.Fontunderline = perevesti("No", True)
        Window10Label80.Props.Forecolor = perevesti("Black", True)
        Window10Label80.Props.Image = perevesti("Nothing", True)
        Window10Label80.Props.Imagealign = perevesti("Center", True)
        Window10Label80.Props.Index = perevesti("0", True)
        Window10Label80.Props.Maximumheight = perevesti("0", True)
        Window10Label80.Props.Maximumwidth = perevesti("0", True)
        Window10Label80.Props.Minimumheight = perevesti("0", True)
        Window10Label80.Props.Minimumwidth = perevesti("0", True)
        Window10Label80.Props.Name = perevesti("Label8", True)
        Window10Label80.Props.Paddingbottom = perevesti("0", True)
        Window10Label80.Props.Paddingleft = perevesti("0", True)
        Window10Label80.Props.Paddingright = perevesti("0", True)
        Window10Label80.Props.Paddingtop = perevesti("0", True)
        Window10Label80.Props.Tabindex = perevesti("0", True)
        Window10Label80.Props.Tabstop = perevesti("Yes", True)
        Window10Label80.Props.Tag = perevesti("", True)
        Window10Label80.Props.Text = perevesti("REPORTS:", True)
        Window10Label80.Props.Textalign = perevesti("center", True)
        Window10Label80.Props.ToolTip = perevesti("", True)
        Window10Label80.Props.X = perevesti("7", True)
        Window10Label80.Props.Y = perevesti("323", True)
        Window10Label80.Props.Height = perevesti("19", True)
        Window10Label80.Props.Width = perevesti("674", True)
        Window10Label80.Props.Visible = perevesti("Yes", True)
        Window10Label80.Props.Height = perevesti("19", True)
        Window10Label80.Props.Width = perevesti("674", True)

        ProgressForm.ProgressBar1.Value = 79
        Window10ComboBoxReports0.Props.Anchor = perevesti("Left_bottom", True)
        Window10ComboBoxReports0.Props.Backcolor = perevesti("255; 255; 255;", True)
        Window10ComboBoxReports0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10ComboBoxReports0.Props.Dock = perevesti("Nothing", True)
        Window10ComboBoxReports0.Props.Dropdownstyle = perevesti("No", True)
        Window10ComboBoxReports0.Props.Dropdownwidth = perevesti("275", True)
        Window10ComboBoxReports0.Props.DroppedDown = perevesti("No", True)
        Window10ComboBoxReports0.Props.Enabled = perevesti("Yes", True)
        Window10ComboBoxReports0.Props.Fontbold = perevesti("No", True)
        Window10ComboBoxReports0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10ComboBoxReports0.Props.Fontitalic = perevesti("No", True)
        Window10ComboBoxReports0.Props.Fontsize = perevesti("8", True)
        Window10ComboBoxReports0.Props.Fontstrikeout = perevesti("No", True)
        Window10ComboBoxReports0.Props.Fontunderline = perevesti("No", True)
        Window10ComboBoxReports0.Props.Forecolor = perevesti("Black", True)
        Window10ComboBoxReports0.Props.Index = perevesti("0", True)
        Window10ComboBoxReports0.Props.Items = perevesti("""The goods, cost more than 100$"", ""The Goods starting on the character """"b"""""", ""The Goods made after June, 25th 2008"", ""Quantity of shoes in all shops"", ""Total cost of everyone of the goods in each shop"", ""Total cost of each goods""", True)
        Window10ComboBoxReports0.Props.Maxdropdownitems = perevesti("8", True)
        Window10ComboBoxReports0.Props.Maximumheight = perevesti("0", True)
        Window10ComboBoxReports0.Props.Maximumlength = perevesti("32767", True)
        Window10ComboBoxReports0.Props.Maximumwidth = perevesti("0", True)
        Window10ComboBoxReports0.Props.Minimumheight = perevesti("0", True)
        Window10ComboBoxReports0.Props.Minimumwidth = perevesti("0", True)
        Window10ComboBoxReports0.Props.Name = perevesti("ComboBoxReports", True)
        Window10ComboBoxReports0.Props.Selectedindex = perevesti("0", True)
        Window10ComboBoxReports0.Props.Sorted = perevesti("No", True)
        Window10ComboBoxReports0.Props.Tabindex = perevesti("0", True)
        Window10ComboBoxReports0.Props.Tabstop = perevesti("Yes", True)
        Window10ComboBoxReports0.Props.Tag = perevesti("", True)
        Window10ComboBoxReports0.Props.Text = perevesti("The goods, cost more than 100$", True)
        Window10ComboBoxReports0.Props.ToolTip = perevesti("", True)
        Window10ComboBoxReports0.Props.X = perevesti("7", True)
        Window10ComboBoxReports0.Props.Y = perevesti("345", True)
        Window10ComboBoxReports0.Props.Height = perevesti("21", True)
        Window10ComboBoxReports0.Props.Width = perevesti("494", True)
        Window10ComboBoxReports0.Props.Visible = perevesti("Yes", True)
        Window10ComboBoxReports0.Props.Height = perevesti("21", True)
        Window10ComboBoxReports0.Props.Width = perevesti("494", True)
        Window10ComboBoxReports0.Props.Selecteditem = perevesti("The goods, cost more than 100$", True)

        ProgressForm.ProgressBar1.Value = 80
        Window10TextQuery0.Props.Allowinput = perevesti("All", True)
        Window10TextQuery0.Props.Anchor = perevesti("Right_left_bottom", True)
        Window10TextQuery0.Props.Backcolor = perevesti("White", True)
        Window10TextQuery0.Props.Borderstyle = perevesti("3D", True)
        Window10TextQuery0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10TextQuery0.Props.Dock = perevesti("Nothing", True)
        Window10TextQuery0.Props.Enabled = perevesti("Yes", True)
        Window10TextQuery0.Props.Fontbold = perevesti("No", True)
        Window10TextQuery0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10TextQuery0.Props.Fontitalic = perevesti("No", True)
        Window10TextQuery0.Props.Fontsize = perevesti("8", True)
        Window10TextQuery0.Props.Fontstrikeout = perevesti("No", True)
        Window10TextQuery0.Props.Fontunderline = perevesti("No", True)
        Window10TextQuery0.Props.Forecolor = perevesti("Black", True)
        Window10TextQuery0.Props.Hideselection = perevesti("No", True)
        Window10TextQuery0.Props.Index = perevesti("0", True)
        Window10TextQuery0.Props.Maximumheight = perevesti("0", True)
        Window10TextQuery0.Props.Maximumlength = perevesti("32767", True)
        Window10TextQuery0.Props.Maximumwidth = perevesti("0", True)
        Window10TextQuery0.Props.Minimumheight = perevesti("0", True)
        Window10TextQuery0.Props.Minimumwidth = perevesti("0", True)
        Window10TextQuery0.Props.Multiline = perevesti("Yes", True)
        Window10TextQuery0.Props.Name = perevesti("TextQuery", True)
        Window10TextQuery0.Props.Passwordchar = perevesti("", True)
        Window10TextQuery0.Props.Readonly = perevesti("No", True)
        Window10TextQuery0.Props.Scrollbars = perevesti("Vertical", True)
        Window10TextQuery0.Props.Selectedtext = perevesti("", True)
        Window10TextQuery0.Props.Selectionlength = perevesti("0", True)
        Window10TextQuery0.Props.Selectionstart = perevesti("1", True)
        Window10TextQuery0.Props.Tabindex = perevesti("0", True)
        Window10TextQuery0.Props.Tabstop = perevesti("Yes", True)
        Window10TextQuery0.Props.Tag = perevesti("", True)
        Window10TextQuery0.Props.Text = perevesti("SELECT * FROM Goods_names WHERE Cost > 100", True)
        Window10TextQuery0.Props.Textposition = perevesti("On left", True)
        Window10TextQuery0.Props.ToolTip = perevesti("", True)
        Window10TextQuery0.Props.Wordwrap = perevesti("Yes", True)
        Window10TextQuery0.Props.X = perevesti("8", True)
        Window10TextQuery0.Props.Y = perevesti("370", True)
        Window10TextQuery0.Props.Height = perevesti("103", True)
        Window10TextQuery0.Props.Width = perevesti("670", True)
        Window10TextQuery0.Props.Visible = perevesti("Yes", True)
        Window10TextQuery0.Props.Height = perevesti("103", True)
        Window10TextQuery0.Props.Width = perevesti("670", True)

        ProgressForm.ProgressBar1.Value = 81
        Window10ButtonReports0.Props.Anchor = perevesti("Right_bottom", True)
        Window10ButtonReports0.Props.Autoellipsis = perevesti("Yes", True)
        Window10ButtonReports0.Props.Backcolor = perevesti("Nothing", True)
        Window10ButtonReports0.Props.Backgroundimage = perevesti("Nothing", True)
        Window10ButtonReports0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window10ButtonReports0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window10ButtonReports0.Props.Cursor = perevesti("Default", True)
        Window10ButtonReports0.Props.Dock = perevesti("Nothing", True)
        Window10ButtonReports0.Props.Enabled = perevesti("Yes", True)
        Window10ButtonReports0.Props.Flatstyle = perevesti("Default", True)
        Window10ButtonReports0.Props.Fontbold = perevesti("No", True)
        Window10ButtonReports0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window10ButtonReports0.Props.Fontitalic = perevesti("No", True)
        Window10ButtonReports0.Props.Fontsize = perevesti("8", True)
        Window10ButtonReports0.Props.Fontstrikeout = perevesti("No", True)
        Window10ButtonReports0.Props.Fontunderline = perevesti("No", True)
        Window10ButtonReports0.Props.Forecolor = perevesti("Black", True)
        Window10ButtonReports0.Props.Image = perevesti("Nothing", True)
        Window10ButtonReports0.Props.Imagealign = perevesti("Center", True)
        Window10ButtonReports0.Props.Index = perevesti("0", True)
        Window10ButtonReports0.Props.Maximumheight = perevesti("0", True)
        Window10ButtonReports0.Props.Maximumwidth = perevesti("0", True)
        Window10ButtonReports0.Props.Minimumheight = perevesti("0", True)
        Window10ButtonReports0.Props.Minimumwidth = perevesti("0", True)
        Window10ButtonReports0.Props.Name = perevesti("ButtonReports", True)
        Window10ButtonReports0.Props.Paddingbottom = perevesti("0", True)
        Window10ButtonReports0.Props.Paddingleft = perevesti("0", True)
        Window10ButtonReports0.Props.Paddingright = perevesti("0", True)
        Window10ButtonReports0.Props.Paddingtop = perevesti("0", True)
        Window10ButtonReports0.Props.Tabindex = perevesti("0", True)
        Window10ButtonReports0.Props.Tabstop = perevesti("Yes", True)
        Window10ButtonReports0.Props.Tag = perevesti("", True)
        Window10ButtonReports0.Props.Text = perevesti("Show report!", True)
        Window10ButtonReports0.Props.Textalign = perevesti("center", True)
        Window10ButtonReports0.Props.Textimagerelation = perevesti("Overlay", True)
        Window10ButtonReports0.Props.ToolTip = perevesti("", True)
        Window10ButtonReports0.Props.X = perevesti("507", True)
        Window10ButtonReports0.Props.Y = perevesti("344", True)
        Window10ButtonReports0.Props.Height = perevesti("23", True)
        Window10ButtonReports0.Props.Width = perevesti("169", True)
        Window10ButtonReports0.Props.Visible = perevesti("Yes", True)
        Window10ButtonReports0.Props.Height = perevesti("23", True)
        Window10ButtonReports0.Props.Width = perevesti("169", True)

        ProgressForm.ProgressBar1.Value = 82
        Window20Window20.Props.Allowruncopies = perevesti("Yes", True)
        Window20Window20.Props.Associatewithextensions = perevesti("", True)
        Window20Window20.Props.AutoscrollminSizeheight = perevesti("0", True)
        Window20Window20.Props.AutoscrollminSizewidth = perevesti("0", True)
        Window20Window20.Props.AutoscrollpositionX = perevesti("0", True)
        Window20Window20.Props.AutoscrollpositionY = perevesti("0", True)
        Window20Window20.Props.AutoRun = perevesti("No", True)
        Window20Window20.Props.Backcolor = perevesti("Sys", True)
        Window20Window20.Props.Backgroundimage = perevesti("Nothing", True)
        Window20Window20.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window20Window20.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window20Window20.Props.Controlbox = perevesti("Yes", True)
        Window20Window20.Props.Cursor = perevesti("Default", True)
        Window20Window20.Props.Enabled = perevesti("Yes", True)
        Window20Window20.Props.Forbidclose = perevesti("No", True)
        Window20Window20.Props.Forbidmaximize = perevesti("No", True)
        Window20Window20.Props.Forbidminimize = perevesti("No", True)
        Window20Window20.Props.Forecolor = perevesti("Black", True)
        Window20Window20.Props.Formborderstyle = perevesti("Normal", True)
        Window20Window20.Props.Icon = perevesti("Nothing", True)
        Window20Window20.Props.Index = perevesti("0", True)
        Window20Window20.Props.Mainform = perevesti("No", True)
        Window20Window20.Props.Mainmenustrip(True) = perevesti("Nothing", True)
        Window20Window20.Props.Maximumheight = perevesti("0", True)
        Window20Window20.Props.Maximumwidth = perevesti("0", True)
        Window20Window20.Props.Minimumheight = perevesti("0", True)
        Window20Window20.Props.Minimumwidth = perevesti("0", True)
        Window20Window20.Props.Name = perevesti("Window2", True)
        Window20Window20.Props.Opacity = perevesti("100", True)
        Window20Window20.Props.Scroll = perevesti("No", True)
        Window20Window20.Props.Showicon = perevesti("Yes", True)
        Window20Window20.Props.Showintaskbar = perevesti("Yes", True)
        Window20Window20.Props.Showintray = perevesti("No", True)
        Window20Window20.Props.Startposition = perevesti("Specified coordinates", True)
        Window20Window20.Props.Tabindex = perevesti("0", True)
        Window20Window20.Props.Tabstop = perevesti("Yes", True)
        Window20Window20.Props.Tag = perevesti("", True)
        Window20Window20.Props.Text = perevesti("Reports", True)
        Window20Window20.Props.ToolTip = perevesti("", True)
        Window20Window20.Props.TopMost = perevesti("No", True)
        Window20Window20.Props.Transparentcykey = perevesti("Nothing", True)
        Window20Window20.StatusTemp = "Normal"
        Window20Window20.Props.X = perevesti("0", True)
        Window20Window20.Props.Y = perevesti("0", True)
        Window20Window20.Props.Height = perevesti("320", True)
        Window20Window20.Props.Width = perevesti("500", True)
        Window20Window20.Props.Visible = perevesti("No", True)
        Window20Window20.Props.Height = perevesti("320", True)
        Window20Window20.Props.Width = perevesti("500", True)

        ProgressForm.ProgressBar1.Value = 83
        Window20TableReport0.Props.AllowUserToAddRows = perevesti("No", True)
        Window20TableReport0.Props.AllowUserToDeleteRows = perevesti("Yes", True)
        Window20TableReport0.Props.AllowUserToOrderColumns = perevesti("No", True)
        Window20TableReport0.Props.AllowUserToResizeColumns = perevesti("Yes", True)
        Window20TableReport0.Props.AllowUserToResizeRows = perevesti("Yes", True)
        Window20TableReport0.Props.Anchor = perevesti("Right_letf_top_bottom", True)
        Window20TableReport0.Props.Backcolor = perevesti("171; 171; 171;", True)
        Window20TableReport0.Props.Borderstyle = perevesti("Nothing", True)
        Window20TableReport0.Props.Cellborderstyle = perevesti("Default", True)
        Window20TableReport0.Props.Columnheadersheight = perevesti("23", True)
        Window20TableReport0.Props.Columnheadersvisible = perevesti("Yes", True)
        Window20TableReport0.Props.Columns = perevesti("""Column1"", ""Column2""", True)
        Window20TableReport0.Props.Columnscount = perevesti("2", True)
        Window20TableReport0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window20TableReport0.Props.Cursor = perevesti("Default", True)
        Window20TableReport0.Props.DefaultCellStyleBackColor = perevesti("255; 255; 255;", True)
        Window20TableReport0.Props.DefaultCellStyleForeColor = perevesti("0; 0; 0;", True)
        Window20TableReport0.Props.DefaultCellStyleSelectionBackColor = perevesti("51; 153; 255;", True)
        Window20TableReport0.Props.DefaultCellStyleSelectionForeColor = perevesti("255; 255; 255;", True)
        Window20TableReport0.Props.Dock = perevesti("Nothing", True)
        Window20TableReport0.Props.Editmode = perevesti("Default", True)
        Window20TableReport0.Props.Enabled = perevesti("Yes", True)
        Window20TableReport0.Props.Fontbold = perevesti("No", True)
        Window20TableReport0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window20TableReport0.Props.Fontitalic = perevesti("No", True)
        Window20TableReport0.Props.Fontsize = perevesti("8", True)
        Window20TableReport0.Props.Fontstrikeout = perevesti("No", True)
        Window20TableReport0.Props.Fontunderline = perevesti("No", True)
        Window20TableReport0.Props.Gridcolor = perevesti("SystemDark", True)
        Window20TableReport0.Props.Heightofrows = perevesti("22,22", True)
        Window20TableReport0.Props.Index = perevesti("0", True)
        Window20TableReport0.Props.Maximumheight = perevesti("0", True)
        Window20TableReport0.Props.Maximumwidth = perevesti("0", True)
        Window20TableReport0.Props.Minimumheight = perevesti("0", True)
        Window20TableReport0.Props.Minimumwidth = perevesti("0", True)
        Window20TableReport0.Props.Multiselect = perevesti("Yes", True)
        Window20TableReport0.Props.Name = perevesti("TableReport", True)
        Window20TableReport0.Props.Readonlytable = perevesti("Yes", True)
        Window20TableReport0.Props.Rowheadersvisible = perevesti("Yes", True)
        Window20TableReport0.Props.Rows = perevesti("""Row1"" | ""Row1"", ""Row2"" | ""Row2""", True)
        Window20TableReport0.Props.Rowscount = perevesti("2", True)
        Window20TableReport0.Props.Scrollbars = perevesti("Both", True)
        Window20TableReport0.Props.Selectedcolumns = perevesti("0", True)
        Window20TableReport0.Props.Selecteditemsvalue = perevesti("""Row1""", True)
        Window20TableReport0.Props.Selectedrows = perevesti("0", True)
        Window20TableReport0.Props.Selectionmode = perevesti("Row header select", True)
        Window20TableReport0.Props.Tabindex = perevesti("0", True)
        Window20TableReport0.Props.Tabstop = perevesti("Yes", True)
        Window20TableReport0.Props.Tag = perevesti("", True)
        Window20TableReport0.Props.ToolTip = perevesti("", True)
        Window20TableReport0.Props.Widthofcolumns = perevesti("100,100", True)
        Window20TableReport0.Props.X = perevesti("-1", True)
        Window20TableReport0.Props.Y = perevesti("30", True)
        Window20TableReport0.Props.Height = perevesti("263", True)
        Window20TableReport0.Props.Width = perevesti("502", True)
        Window20TableReport0.Props.Visible = perevesti("Yes", True)
        Window20TableReport0.Props.Height = perevesti("263", True)
        Window20TableReport0.Props.Width = perevesti("502", True)

        ProgressForm.ProgressBar1.Value = 84
        Window20LabelReport0.Props.Anchor = perevesti("Right_left_top", True)
        Window20LabelReport0.Props.Autoellipsis = perevesti("Yes", True)
        Window20LabelReport0.Props.Backcolor = perevesti("Nothing", True)
        Window20LabelReport0.Props.Backgroundimage = perevesti("Nothing", True)
        Window20LabelReport0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window20LabelReport0.Props.Borderstyle = perevesti("Nothing", True)
        Window20LabelReport0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window20LabelReport0.Props.Cursor = perevesti("Default", True)
        Window20LabelReport0.Props.Dock = perevesti("Nothing", True)
        Window20LabelReport0.Props.Enabled = perevesti("Yes", True)
        Window20LabelReport0.Props.Fontbold = perevesti("Yes", True)
        Window20LabelReport0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window20LabelReport0.Props.Fontitalic = perevesti("No", True)
        Window20LabelReport0.Props.Fontsize = perevesti("11", True)
        Window20LabelReport0.Props.Fontstrikeout = perevesti("No", True)
        Window20LabelReport0.Props.Fontunderline = perevesti("No", True)
        Window20LabelReport0.Props.Forecolor = perevesti("Black", True)
        Window20LabelReport0.Props.Image = perevesti("Nothing", True)
        Window20LabelReport0.Props.Imagealign = perevesti("Center", True)
        Window20LabelReport0.Props.Index = perevesti("0", True)
        Window20LabelReport0.Props.Maximumheight = perevesti("0", True)
        Window20LabelReport0.Props.Maximumwidth = perevesti("0", True)
        Window20LabelReport0.Props.Minimumheight = perevesti("0", True)
        Window20LabelReport0.Props.Minimumwidth = perevesti("0", True)
        Window20LabelReport0.Props.Name = perevesti("LabelReport", True)
        Window20LabelReport0.Props.Paddingbottom = perevesti("0", True)
        Window20LabelReport0.Props.Paddingleft = perevesti("0", True)
        Window20LabelReport0.Props.Paddingright = perevesti("0", True)
        Window20LabelReport0.Props.Paddingtop = perevesti("0", True)
        Window20LabelReport0.Props.Tabindex = perevesti("0", True)
        Window20LabelReport0.Props.Tabstop = perevesti("Yes", True)
        Window20LabelReport0.Props.Tag = perevesti("", True)
        Window20LabelReport0.Props.Text = perevesti("Report", True)
        Window20LabelReport0.Props.Textalign = perevesti("center", True)
        Window20LabelReport0.Props.ToolTip = perevesti("", True)
        Window20LabelReport0.Props.X = perevesti("-1", True)
        Window20LabelReport0.Props.Y = perevesti("5", True)
        Window20LabelReport0.Props.Height = perevesti("19", True)
        Window20LabelReport0.Props.Width = perevesti("494", True)
        Window20LabelReport0.Props.Visible = perevesti("Yes", True)
        Window20LabelReport0.Props.Height = perevesti("19", True)
        Window20LabelReport0.Props.Width = perevesti("494", True)

        ProgressForm.ProgressBar1.Value = 85
        Window20ButtonPreview0.Props.Anchor = perevesti("on bottom", True)
        Window20ButtonPreview0.Props.Autoellipsis = perevesti("Yes", True)
        Window20ButtonPreview0.Props.Backcolor = perevesti("Nothing", True)
        Window20ButtonPreview0.Props.Backgroundimage = perevesti("Nothing", True)
        Window20ButtonPreview0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window20ButtonPreview0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window20ButtonPreview0.Props.Cursor = perevesti("Default", True)
        Window20ButtonPreview0.Props.Dock = perevesti("Nothing", True)
        Window20ButtonPreview0.Props.Enabled = perevesti("Yes", True)
        Window20ButtonPreview0.Props.Flatstyle = perevesti("Default", True)
        Window20ButtonPreview0.Props.Fontbold = perevesti("No", True)
        Window20ButtonPreview0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window20ButtonPreview0.Props.Fontitalic = perevesti("No", True)
        Window20ButtonPreview0.Props.Fontsize = perevesti("8", True)
        Window20ButtonPreview0.Props.Fontstrikeout = perevesti("No", True)
        Window20ButtonPreview0.Props.Fontunderline = perevesti("No", True)
        Window20ButtonPreview0.Props.Forecolor = perevesti("Black", True)
        Window20ButtonPreview0.Props.Image = perevesti("Nothing", True)
        Window20ButtonPreview0.Props.Imagealign = perevesti("Center", True)
        Window20ButtonPreview0.Props.Index = perevesti("0", True)
        Window20ButtonPreview0.Props.Maximumheight = perevesti("0", True)
        Window20ButtonPreview0.Props.Maximumwidth = perevesti("0", True)
        Window20ButtonPreview0.Props.Minimumheight = perevesti("0", True)
        Window20ButtonPreview0.Props.Minimumwidth = perevesti("0", True)
        Window20ButtonPreview0.Props.Name = perevesti("ButtonPreview", True)
        Window20ButtonPreview0.Props.Paddingbottom = perevesti("0", True)
        Window20ButtonPreview0.Props.Paddingleft = perevesti("0", True)
        Window20ButtonPreview0.Props.Paddingright = perevesti("0", True)
        Window20ButtonPreview0.Props.Paddingtop = perevesti("0", True)
        Window20ButtonPreview0.Props.Tabindex = perevesti("0", True)
        Window20ButtonPreview0.Props.Tabstop = perevesti("Yes", True)
        Window20ButtonPreview0.Props.Tag = perevesti("", True)
        Window20ButtonPreview0.Props.Text = perevesti("Preview", True)
        Window20ButtonPreview0.Props.Textalign = perevesti("center", True)
        Window20ButtonPreview0.Props.Textimagerelation = perevesti("Overlay", True)
        Window20ButtonPreview0.Props.ToolTip = perevesti("", True)
        Window20ButtonPreview0.Props.X = perevesti("178", True)
        Window20ButtonPreview0.Props.Y = perevesti("294", True)
        Window20ButtonPreview0.Props.Height = perevesti("23", True)
        Window20ButtonPreview0.Props.Width = perevesti("76", True)
        Window20ButtonPreview0.Props.Visible = perevesti("Yes", True)
        Window20ButtonPreview0.Props.Height = perevesti("23", True)
        Window20ButtonPreview0.Props.Width = perevesti("76", True)

        ProgressForm.ProgressBar1.Value = 87
        Window20ButtonPrint0.Props.Anchor = perevesti("on bottom", True)
        Window20ButtonPrint0.Props.Autoellipsis = perevesti("Yes", True)
        Window20ButtonPrint0.Props.Backcolor = perevesti("Nothing", True)
        Window20ButtonPrint0.Props.Backgroundimage = perevesti("Nothing", True)
        Window20ButtonPrint0.Props.Backgroundimagelayout = perevesti("Tile", True)
        Window20ButtonPrint0.Props.Contextmenu(True) = perevesti("Nothing", True)
        Window20ButtonPrint0.Props.Cursor = perevesti("Default", True)
        Window20ButtonPrint0.Props.Dock = perevesti("Nothing", True)
        Window20ButtonPrint0.Props.Enabled = perevesti("Yes", True)
        Window20ButtonPrint0.Props.Flatstyle = perevesti("Default", True)
        Window20ButtonPrint0.Props.Fontbold = perevesti("No", True)
        Window20ButtonPrint0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window20ButtonPrint0.Props.Fontitalic = perevesti("No", True)
        Window20ButtonPrint0.Props.Fontsize = perevesti("8", True)
        Window20ButtonPrint0.Props.Fontstrikeout = perevesti("No", True)
        Window20ButtonPrint0.Props.Fontunderline = perevesti("No", True)
        Window20ButtonPrint0.Props.Forecolor = perevesti("Black", True)
        Window20ButtonPrint0.Props.Image = perevesti("Nothing", True)
        Window20ButtonPrint0.Props.Imagealign = perevesti("Center", True)
        Window20ButtonPrint0.Props.Index = perevesti("0", True)
        Window20ButtonPrint0.Props.Maximumheight = perevesti("0", True)
        Window20ButtonPrint0.Props.Maximumwidth = perevesti("0", True)
        Window20ButtonPrint0.Props.Minimumheight = perevesti("0", True)
        Window20ButtonPrint0.Props.Minimumwidth = perevesti("0", True)
        Window20ButtonPrint0.Props.Name = perevesti("ButtonPrint", True)
        Window20ButtonPrint0.Props.Paddingbottom = perevesti("0", True)
        Window20ButtonPrint0.Props.Paddingleft = perevesti("0", True)
        Window20ButtonPrint0.Props.Paddingright = perevesti("0", True)
        Window20ButtonPrint0.Props.Paddingtop = perevesti("0", True)
        Window20ButtonPrint0.Props.Tabindex = perevesti("0", True)
        Window20ButtonPrint0.Props.Tabstop = perevesti("Yes", True)
        Window20ButtonPrint0.Props.Tag = perevesti("", True)
        Window20ButtonPrint0.Props.Text = perevesti("Print", True)
        Window20ButtonPrint0.Props.Textalign = perevesti("center", True)
        Window20ButtonPrint0.Props.Textimagerelation = perevesti("Overlay", True)
        Window20ButtonPrint0.Props.ToolTip = perevesti("", True)
        Window20ButtonPrint0.Props.X = perevesti("256", True)
        Window20ButtonPrint0.Props.Y = perevesti("294", True)
        Window20ButtonPrint0.Props.Height = perevesti("23", True)
        Window20ButtonPrint0.Props.Width = perevesti("75", True)
        Window20ButtonPrint0.Props.Visible = perevesti("Yes", True)
        Window20ButtonPrint0.Props.Height = perevesti("23", True)
        Window20ButtonPrint0.Props.Width = perevesti("75", True)

        ProgressForm.ProgressBar1.Value = 88
        Window20Print_dialog10.Props.Copies = perevesti("1", True)
        Window20Print_dialog10.Props.Dialogcolor = perevesti("0; 0; 0;", True)
        Window20Print_dialog10.Props.Fontbold = perevesti("Yes", True)
        Window20Print_dialog10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
        Window20Print_dialog10.Props.Fontitalic = perevesti("No", True)
        Window20Print_dialog10.Props.Fontsize = perevesti("11", True)
        Window20Print_dialog10.Props.Fontstrikeout = perevesti("No", True)
        Window20Print_dialog10.Props.Fontunderline = perevesti("No", True)
        Window20Print_dialog10.Props.Frompage = perevesti("1", True)
        Window20Print_dialog10.Props.Index = perevesti("0", True)
        Window20Print_dialog10.Props.Name = perevesti("Print dialog1", True)
        Window20Print_dialog10.Props.Paddingbottom = perevesti("10", True)
        Window20Print_dialog10.Props.Paddingleft = perevesti("30", True)
        Window20Print_dialog10.Props.Paddingright = perevesti("10", True)
        Window20Print_dialog10.Props.Paddingtop = perevesti("10", True)
        Window20Print_dialog10.Props.Printdocument = perevesti("", True)
        Window20Print_dialog10.Props.Printobject = perevesti("", True)
        Window20Print_dialog10.Props.Printpicture = perevesti("Nothing", True)
        Window20Print_dialog10.Props.Printtable = perevesti("", True)
        Window20Print_dialog10.Props.Printtext = perevesti("", True)
        Window20Print_dialog10.Props.Tableoncenter = perevesti("Yes", True)
        Window20Print_dialog10.Props.Tag = perevesti("", True)
        Window20Print_dialog10.Props.Topage = perevesti("999", True)
        Window20Print_dialog10.Props.X = perevesti("8", True)
        Window20Print_dialog10.Props.Y = perevesti("8", True)

        ProgressForm.ProgressBar1.Value = 89
        _Useful_objects0_Useful_objects0.Props.Name = "_Useful objects"

        ProgressForm.ProgressBar1.Value = 90
        _Useful_objects0_Screen0.Props.Name = "_Screen"

        ProgressForm.ProgressBar1.Value = 91
        _Useful_objects0_Files_and_paths0.Props.Name = "_Files and paths"

        ProgressForm.ProgressBar1.Value = 92
        _Useful_objects0_Interrupts0.Props.Name = "_Interrupts"

        ProgressForm.ProgressBar1.Value = 93
        _Useful_objects0_System0.Props.Name = "_System"

        ProgressForm.ProgressBar1.Value = 94
        _Useful_objects0_Registry0.Props.Name = "_Registry"

        ProgressForm.ProgressBar1.Value = 95
        _Useful_objects0_Call_event0.Props.Name = "_Call event"

        ProgressForm.ProgressBar1.Value = 96
        _Useful_objects0_Text0.Props.Name = "_Text"

        ProgressForm.ProgressBar1.Value = 97
        _Useful_objects0_Show_messange0.Props.Name = "_Show messange"

        ProgressForm.ProgressBar1.Value = 98
        _Useful_objects0_Date0.Props.Name = "_Date"

        ProgressForm.ProgressBar1.Value = 99
        _Useful_objects0_Advanced_tools0.Props.Name = "_Advanced tools"


        ' Окончательная загрузка
        Window10Window10.load()
        Window10Double_panel10.load()
        Window10LabelGoodsNames0.load()
        Window10Table10.load()
        Window10TextId0.load()
        Window10TextName0.load()
        Window10TextCost0.load()
        Window10ButtonAdd10.load()
        Window10Label30.load()
        Window10Label40.load()
        Window10Label50.load()
        Window10Label60.load()
        Window10Calendar0.load()
        Window10CheckBoxDel0.load()
        Window10CheckBoxChanges0.load()
        Window10LabelGoodsExists0.load()
        Window10Table20.load()
        Window10TextId20.load()
        Window10TextMarket0.load()
        Window10TextCount0.load()
        Window10ButtonAdd20.load()
        Window10Label10.load()
        Window10Label20.load()
        Window10Label70.load()
        Window10CheckBoxSizes0.load()
        Window10CheckBoxSelections0.load()
        Window10MenuTables0.load()
        Window10ItemDuplicate0.load()
        Window10ItemDelete0.load()
        Window10ItemSplit0.load()
        Window10ItemSelectAll0.load()
        Window10MemoryRowNumber0.load()
        Window10Label80.load()
        Window10ComboBoxReports0.load()
        Window10TextQuery0.load()
        Window10ButtonReports0.load()
        Window20Window20.load()
        Window20TableReport0.load()
        Window20LabelReport0.load()
        Window20ButtonPreview0.load()
        Window20ButtonPrint0.load()
        Window20Print_dialog10.load()

        RunProj.GetAllObjects()
        RunProj.isINITIALIZATED = False

        Window10Double_panel10.RaiseCreate()
        Window10LabelGoodsNames0.RaiseCreate()
        Window10Table10.RaiseCreate()
        Window10TextId0.RaiseCreate()
        Window10TextName0.RaiseCreate()
        Window10TextCost0.RaiseCreate()
        Window10ButtonAdd10.RaiseCreate()
        Window10Label30.RaiseCreate()
        Window10Label40.RaiseCreate()
        Window10Label50.RaiseCreate()
        Window10Label60.RaiseCreate()
        Window10Calendar0.RaiseCreate()
        Window10CheckBoxDel0.RaiseCreate()
        Window10CheckBoxChanges0.RaiseCreate()
        Window10LabelGoodsExists0.RaiseCreate()
        Window10Table20.RaiseCreate()
        Window10TextId20.RaiseCreate()
        Window10TextMarket0.RaiseCreate()
        Window10TextCount0.RaiseCreate()
        Window10ButtonAdd20.RaiseCreate()
        Window10Label10.RaiseCreate()
        Window10Label20.RaiseCreate()
        Window10Label70.RaiseCreate()
        Window10CheckBoxSizes0.RaiseCreate()
        Window10CheckBoxSelections0.RaiseCreate()
        Window10MenuTables0.RaiseCreate()
        Window10ItemDuplicate0.RaiseCreate()
        Window10ItemDelete0.RaiseCreate()
        Window10ItemSplit0.RaiseCreate()
        Window10ItemSelectAll0.RaiseCreate()
        Window10MemoryRowNumber0.RaiseCreate()
        Window10Label80.RaiseCreate()
        Window10ComboBoxReports0.RaiseCreate()
        Window10TextQuery0.RaiseCreate()
        Window10ButtonReports0.RaiseCreate()
        Window10Window10.RaiseCreate()
        Window20TableReport0.RaiseCreate()
        Window20LabelReport0.RaiseCreate()
        Window20ButtonPreview0.RaiseCreate()
        Window20ButtonPrint0.RaiseCreate()
        Window20Print_dialog10.RaiseCreate()
        Window20Window20.RaiseCreate()

        ProgressForm.Hide()
    End Sub

    ' Обязательные события
    Public Sub Window10Window10_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10Window10.Disposed
        If DaOrNet(Window10Window10.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
    End Sub

    Public Sub Window10Window10_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Window10Window10.FormClosing
        If DaOrNet(Window10Window10.Props.ForbidClose) Then e.Cancel = True : Exit Sub
        If UCase(Window10Window10.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
            Window10Window10.Hide() : Application.Exit()
        Else
            e.Cancel = True : Window10Window10.Hide()
        End If
    End Sub

    Public Sub Window10TextId0_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Window10TextId0.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub Window10TextName0_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Window10TextName0.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub Window10TextCost0_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Window10TextCost0.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub Window10TextId20_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Window10TextId20.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub Window10TextMarket0_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Window10TextMarket0.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub Window10TextCount0_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Window10TextCount0.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub Window10TextQuery0_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Window10TextQuery0.KeyPress
        e.Handled = TextBoxAllow(sender, e)
    End Sub

    Public Sub Window20Window20_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window20Window20.Disposed
        If DaOrNet(Window20Window20.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
    End Sub

    Public Sub Window20Window20_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Window20Window20.FormClosing
        If DaOrNet(Window20Window20.Props.ForbidClose) Then e.Cancel = True : Exit Sub
        If UCase(Window20Window20.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
            Window20Window20.Hide() : Application.Exit()
        Else
            e.Cancel = True : Window20Window20.Hide()
        End If
    End Sub

    Public Sub _Useful_objects0_Useful_objects0_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Useful_objects0_Useful_objects0.Disposed
        If DaOrNet(_Useful_objects0_Useful_objects0.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
    End Sub

    Public Sub _Useful_objects0_Useful_objects0_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles _Useful_objects0_Useful_objects0.FormClosing
        If DaOrNet(_Useful_objects0_Useful_objects0.Props.ForbidClose) Then e.Cancel = True : Exit Sub
        If UCase(_Useful_objects0_Useful_objects0.Props.MainForm) = UCase(trans("Да")) Or proj.isCLOSING Then
            _Useful_objects0_Useful_objects0.Hide() : Application.Exit()
        Else
            e.Cancel = True : _Useful_objects0_Useful_objects0.Hide()
        End If
    End Sub



    ' Все события
    Public Sub Window10Window10_Created(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10Window10.Created
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Window10.MyObj, e, Nothing, "Created")

        RunProj.GetObjFromUniqName("Window1.Table1").Props.OpenAccess("Data base.accdb", "Goods_names")
        Window10Table10_Sizechanged(Window10Table10, Nothing)

        RunProj.GetObjFromUniqName("Window1.Table2").Props.OpenAccess("Data base.accdb", "Goods_exists")
        Window10Table20_Sizechanged(Window10Table20, Nothing)

        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table10_Sizechanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10Table10.Sizechanged
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table10.MyObj, e, Nothing, "Size changed")

        RunProj.GetObjFromUniqName("Window1.Table1").Props.Columnswidth(0) = 30
        RunProj.GetObjFromUniqName("Window1.Table1").Props.Columnswidth(1) = ToDouble(RunProj.GetObjFromUniqName("Window1.Table1").Props.Width) - 205
        RunProj.GetObjFromUniqName("Window1.Table1").Props.Columnswidth(2) = 50
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table10_Cellendedit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Window10Table10.Cellendedit
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table10.MyObj, e, Nothing, "Cell end edit")

        RunProj.GetObjFromUniqName("Window1.Table1").Props.SaveAccess()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table10_Rowsremoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles Window10Table10.Rowsremoved
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table10.MyObj, e, Nothing, "Rows removed")
        If Window10Table10.Props.isSelecExecute Then Exit Sub

        RunProj.GetObjFromUniqName("Window1.Table1").Props.SaveAccess()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table10_Rowsadded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Window10Table10.Rowsadded
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table10.MyObj, e, Nothing, "Rows added")
        If Window10Table10.Props.isSelecExecute Then Exit Sub

        RunProj.GetObjFromUniqName("Window1.Table1").Props.SaveAccess()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table10_Gotfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10Table10.Gotfocus
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table10.MyObj, e, Nothing, "Got focus")

        RunProj.GetObjFromUniqName("Window1.MenuTables").Props.Ownerobject = "Table1"
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10ButtonAdd10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10ButtonAdd10.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10ButtonAdd10.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window1.Table1").Props.Rowsadd(RunProj.GetObjFromUniqName("Window1.TextId").Props.Text, RunProj.GetObjFromUniqName("Window1.TextName").Props.Text, RunProj.GetObjFromUniqName("Window1.TextCost").Props.Text, RunProj.GetObjFromUniqName("Window1.Calendar").Props.Selecteddate)
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10CheckBoxDel0_Checkedchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10CheckBoxDel0.Checkedchanged
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10CheckBoxDel0.MyObj, e, Nothing, "Checked changed")

        RunProj.GetObjFromUniqName("Window1.Table1").Props.AllowUserToDeleteRows = Invert(RunProj.GetObjFromUniqName("Window1.CheckBoxDel").Props.Checked)
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10CheckBoxChanges0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10CheckBoxChanges0.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10CheckBoxChanges0.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window1.Table1").Props.Readonlytable = RunProj.GetObjFromUniqName("Window1.CheckBoxChanges").Props.Checked
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table20_Sizechanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10Table20.Sizechanged
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table20.MyObj, e, Nothing, "Size changed")

        RunProj.GetObjFromUniqName("Window1.Table2").Props.Columnswidth(0) = 80
        RunProj.GetObjFromUniqName("Window1.Table2").Props.Columnswidth(1) = ToDouble(RunProj.GetObjFromUniqName("Window1.Table2").Props.Width) - 180
        RunProj.GetObjFromUniqName("Window1.Table2").Props.Columnswidth(2) = 70
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table20_Cellendedit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Window10Table20.Cellendedit
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table20.MyObj, e, Nothing, "Cell end edit")

        RunProj.GetObjFromUniqName("Window1.Table2").Props.SaveAccess()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table20_Rowsremoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles Window10Table20.Rowsremoved
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table20.MyObj, e, Nothing, "Rows removed")
        If Window10Table20.Props.isSelecExecute Then Exit Sub

        RunProj.GetObjFromUniqName("Window1.Table2").Props.SaveAccess()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table20_Rowsadded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Window10Table20.Rowsadded
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table20.MyObj, e, Nothing, "Rows added")
        If Window10Table20.Props.isSelecExecute Then Exit Sub

        RunProj.GetObjFromUniqName("Window1.Table2").Props.SaveAccess()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10Table20_Gotfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10Table20.Gotfocus
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10Table20.MyObj, e, Nothing, "Got focus")

        RunProj.GetObjFromUniqName("Window1.MenuTables").Props.Ownerobject = "Table2"
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10ButtonAdd20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10ButtonAdd20.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10ButtonAdd20.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window1.Table2").Props.Rowsadd(RunProj.GetObjFromUniqName("Window1.TextId2").Props.Text, RunProj.GetObjFromUniqName("Window1.TextMarket").Props.Text, RunProj.GetObjFromUniqName("Window1.TextCount").Props.Text)
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10CheckBoxSizes0_Checkedchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10CheckBoxSizes0.Checkedchanged
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10CheckBoxSizes0.MyObj, e, Nothing, "Checked changed")

        RunProj.GetObjFromUniqName("Window1.Table2").Props.AllowUserToResizeColumns = Invert(RunProj.GetObjFromUniqName("Window1.CheckBoxSizes").Props.Checked)
        RunProj.GetObjFromUniqName("Window1.Table2").Props.AllowUserToResizeRows = Invert(RunProj.GetObjFromUniqName("Window1.CheckBoxSizes").Props.Checked)
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10CheckBoxSelections0_Checkedchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10CheckBoxSelections0.Checkedchanged
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10CheckBoxSelections0.MyObj, e, Nothing, "Checked changed")

        If returnBoolean(UCase(RunProj.GetObjFromUniqName("Window1.CheckBoxSelections").Props.Checked) = UCase("Yes")) Then
            RunProj.GetObjFromUniqName("Window1.Table2").Props.Selectionmode = "cell select"
        Else
            RunProj.GetObjFromUniqName("Window1.Table2").Props.Selectionmode = "rows"
        End If
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10ItemDuplicate0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10ItemDuplicate0.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10ItemDuplicate0.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window1." & RunProj.GetObjFromUniqName("Window1.MenuTables").props.OwnerObject).Props.Rowsaddcopies(RunProj.GetObjFromUniqName("Window1." & RunProj.GetObjFromUniqName("Window1.MenuTables").Props.props.OwnerObject).Props.Selectedrows, RunProj.GetObjFromUniqName("Window1." & RunProj.GetObjFromUniqName("Window1.MenuTables").Props.props.OwnerObject).Props.Selectedrowscount)
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10ItemDelete0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10ItemDelete0.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10ItemDelete0.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window1." & RunProj.GetObjFromUniqName("Window1.MenuTables").props.OwnerObject).Props.Rowsremove(RunProj.GetObjFromUniqName("Window1." & RunProj.GetObjFromUniqName("Window1.MenuTables").Props.props.OwnerObject).Props.Selectedrows)
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10ItemSelectAll0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10ItemSelectAll0.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10ItemSelectAll0.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window1.MemoryRowNumber").Props.Value = RunProj.GetObjFromUniqName("Window1." & RunProj.GetObjFromUniqName("Window1.MenuTables").props.OwnerObject).Props.Getfirstrow("whole table")
        While returnBoolean(RunProj.GetObjFromUniqName("Window1.MemoryRowNumber").Props.Value <> "-1")
            Application.DoEvents()
            RunProj.GetObjFromUniqName("Window1." & RunProj.GetObjFromUniqName("Window1.MenuTables").props.OwnerObject).Props.Itemselected(RunProj.GetObjFromUniqName("Window1.MemoryRowNumber").Props.Value, "All") = "Yes"
            RunProj.GetObjFromUniqName("Window1.MemoryRowNumber").Props.Value = RunProj.GetObjFromUniqName("Window1." & RunProj.GetObjFromUniqName("Window1.MenuTables").props.OwnerObject).Props.Getnextrow(RunProj.GetObjFromUniqName("Window1.MemoryRowNumber").Props.Value, "whole table")
        End While
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10ComboBoxReports0_Selectedindexchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10ComboBoxReports0.Selectedindexchanged
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10ComboBoxReports0.MyObj, e, Nothing, "Selected index changed")

        If returnBoolean(UCase(RunProj.GetObjFromUniqName("Window1.ComboBoxReports").Props.Selectedindex) = UCase(0)) Then
            RunProj.GetObjFromUniqName("Window1.TextQuery").Props.Text = "SELECT * FROM Goods_names WHERE Cost > 100"
        ElseIf returnBoolean(UCase(RunProj.GetObjFromUniqName("Window1.ComboBoxReports").Props.Selectedindex) = UCase(1)) Then
            RunProj.GetObjFromUniqName("Window1.TextQuery").Props.Text = "SELECT * FROM Goods_names WHERE Name LIKE 'b%'"
        ElseIf returnBoolean(UCase(RunProj.GetObjFromUniqName("Window1.ComboBoxReports").Props.Selectedindex) = UCase(2)) Then
            RunProj.GetObjFromUniqName("Window1.TextQuery").Props.Text = "SELECT * FROM Goods_names WHERE Date > #06/25/2008# ORDER BY Date DESC"
        ElseIf returnBoolean(UCase(RunProj.GetObjFromUniqName("Window1.ComboBoxReports").Props.Selectedindex) = UCase(3)) Then
            RunProj.GetObjFromUniqName("Window1.TextQuery").Props.Text = "SELECT SUM(Count) as Count_of_shoes FROM Goods_exists WHERE Goods_id = 1"
        ElseIf returnBoolean(UCase(RunProj.GetObjFromUniqName("Window1.ComboBoxReports").Props.Selectedindex) = UCase(4)) Then
            RunProj.GetObjFromUniqName("Window1.TextQuery").Props.Text = "SELECT Market," & vbCrLf & "    (SELECT Name FROM Goods_names WHERE Id=Goods_id) as Name," & vbCrLf & "    (SELECT Cost FROM Goods_names WHERE Id=Goods_id) * Count as Summ_cost" & vbCrLf & "FROM Goods_exists" & vbCrLf & "ORDER BY Market"
        ElseIf returnBoolean(UCase(RunProj.GetObjFromUniqName("Window1.ComboBoxReports").Props.Selectedindex) = UCase(5)) Then
            RunProj.GetObjFromUniqName("Window1.TextQuery").Props.Text = "SELECT Name, SUM(Summ_cost) as Summary_cost " & vbCrLf & "FROM" & vbCrLf & "    (SELECT Market," & vbCrLf & "        (SELECT Name FROM Goods_names WHERE Id=Goods_id) as Name, " & vbCrLf & "        (SELECT Cost FROM Goods_names WHERE Id=Goods_id) * Count as Summ_cost" & vbCrLf & "     FROM Goods_exists)" & vbCrLf & "GROUP BY Name"
        End If
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window10ButtonReports0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window10ButtonReports0.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window10ButtonReports0.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window2.TableReport").Props.SQLqueryselect("access", "Data base.accdb", RunProj.GetObjFromUniqName("Window1.TextQuery").Props.Text)
        RunProj.GetObjFromUniqName("Window2.LabelReport").Props.Text = RunProj.GetObjFromUniqName("Window1.ComboBoxReports").Props.Text
        RunProj.GetObjFromUniqName("Window2.Window2").Props.Show()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window20ButtonPreview0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window20ButtonPreview0.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window20ButtonPreview0.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window2.Print dialog1").Props.Printtable = "TableReport"
        RunProj.GetObjFromUniqName("Window2.Print dialog1").Props.Printtext = RunProj.GetObjFromUniqName("Window2.LabelReport").Props.Text
        RunProj.GetObjFromUniqName("Window2.Print dialog1").Props.ShowPrevDialog()
        CurrentEvent.Zavershit()
    End Sub


    Public Sub Window20ButtonPrint0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Window20ButtonPrint0.Click
        If RunProj.isINITIALIZATED Then Exit Sub
        Dim CurrentEvent As New PropertysSobyt(Window20ButtonPrint0.MyObj, e, Nothing, "Click")

        RunProj.GetObjFromUniqName("Window2.Print dialog1").Props.Printtable = "TableReport"
        RunProj.GetObjFromUniqName("Window2.Print dialog1").Props.Printtext = RunProj.GetObjFromUniqName("Window2.LabelReport").Props.Text
        RunProj.GetObjFromUniqName("Window2.Print dialog1").Props.ShowPrinDialog()
        CurrentEvent.Zavershit()
    End Sub



End Module



