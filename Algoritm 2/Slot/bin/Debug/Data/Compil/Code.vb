Module CodeAlg

Public WithEvents ����10����10 As New runF
Public WithEvents ����10��������10 As New runTP
Public WithEvents ����10����_����������10 As New runSD
Public WithEvents ����10��������10 As New runI
Public WithEvents ����10�������10 As New runLb
Public WithEvents ����10�������20 As New runLb
Public WithEvents ����10������_10 As New runP
Public WithEvents ����10�������30 As New runLb
Public WithEvents ����10�������40 As New runLb
Public WithEvents ����10�������50 As New runLb
Public WithEvents ����10��������1_��������10 As New runTPs
Public WithEvents ����10��������1_��������20 As New runTPs
Public WithEvents ����10�������������0 As New runB
Public WithEvents ����10��������������0 As New runB
Public WithEvents ����10�����������0 As New runB
Public WithEvents ����10������_��������10 As New runPrB
Public WithEvents ����10��������������0 As New runLb
Public WithEvents ����10�������10 As New runPb
Public WithEvents _��������_�������0_��������_�������0 As New runF
Public WithEvents _��������_�������0_�����0 As New PoleznieObj("_�����")
Public WithEvents _��������_�������0_�����_�_�����0 As New PoleznieObj("_����� � �����")
Public WithEvents _��������_�������0_����������0 As New PoleznieObj("_����������")
Public WithEvents _��������_�������0_�������0 As New PoleznieObj("_�������")
Public WithEvents _��������_�������0_������0 As New PoleznieObj("_������")
Public WithEvents _��������_�������0_�������_�������0 As New PoleznieObj("_������� �������")
Public WithEvents _��������_�������0_�����0 As New PoleznieObj("_�����")
Public WithEvents _��������_�������0_��������_���������0 As New PoleznieObj("_�������� ���������")
Public WithEvents _��������_�������0_����0 As New PoleznieObj("_����")
Public WithEvents _��������_�������0_�����������_�����������0 As New PoleznieObj("_����������� �����������")


    Sub Initial()
RunProj.isINITIALIZATED = True

' ������� ����������
RunProj.iPathShort = "�������"
RunProj.iPath = RunProj.pPath & RunProj.iPathShort

' ����������� ������ ��������
ProgressForm.Label1.Text = "Load..."
ProgressForm.Show()
Application.DoEvents()
ProgressForm.ProgressBarValue = 1

' �������� ���� ��������
ProgressForm.ProgressBar1.Value = 0
����10����10.MyObj = New Forms(True, , True)
����10����10.MyObj.proj = proj
����10����10.MyObj.obj = ����10����10
����10����10.MyObj.VBname = "����10����10"
����10����10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = ����10����10.MyObj
ReDimsO(����10����10.MyObj.MyForm.MyObjs) : ����10����10.MyObj.MyForm.MyObjs(����10����10.MyObj.MyForm.MyObjs.Length - 1) = ����10����10.MyObj

����10��������10.MyObj = New TPage(True, True)
����10��������10.MyObj.proj = proj
����10��������10.MyObj.obj = ����10��������10
����10��������10.MyObj.VBname = "����10��������10"
����10��������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10��������10.MyObj.MyForm.MyObjs) : ����10��������10.MyObj.MyForm.MyObjs(����10��������10.MyObj.MyForm.MyObjs.Length - 1) = ����10��������10.MyObj

����10����_����������10.MyObj = New SaveDialog(True, True)
����10����_����������10.MyObj.proj = proj
����10����_����������10.MyObj.obj = ����10����_����������10
����10����_����������10.MyObj.VBname = "����10����_����������10"
����10����_����������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10����_����������10.MyObj.MyForm.MyObjs) : ����10����_����������10.MyObj.MyForm.MyObjs(����10����_����������10.MyObj.MyForm.MyObjs.Length - 1) = ����10����_����������10.MyObj

����10��������10.MyObj = New Internet(True, True)
����10��������10.MyObj.proj = proj
����10��������10.MyObj.obj = ����10��������10
����10��������10.MyObj.VBname = "����10��������10"
����10��������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10��������10.MyObj.MyForm.MyObjs) : ����10��������10.MyObj.MyForm.MyObjs(����10��������10.MyObj.MyForm.MyObjs.Length - 1) = ����10��������10.MyObj

����10�������10.MyObj = New Label(True, True)
����10�������10.MyObj.proj = proj
����10�������10.MyObj.obj = ����10�������10
����10�������10.MyObj.VBname = "����10�������10"
����10�������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������10.MyObj.MyForm.MyObjs) : ����10�������10.MyObj.MyForm.MyObjs(����10�������10.MyObj.MyForm.MyObjs.Length - 1) = ����10�������10.MyObj

ProgressForm.ProgressBar1.Value = 4
����10�������20.MyObj = New Label(True, True)
����10�������20.MyObj.proj = proj
����10�������20.MyObj.obj = ����10�������20
����10�������20.MyObj.VBname = "����10�������20"
����10�������20.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������20.MyObj.MyForm.MyObjs) : ����10�������20.MyObj.MyForm.MyObjs(����10�������20.MyObj.MyForm.MyObjs.Length - 1) = ����10�������20.MyObj

����10������_10.MyObj = New Panel(True, True)
����10������_10.MyObj.proj = proj
����10������_10.MyObj.obj = ����10������_10
����10������_10.MyObj.VBname = "����10������_10"
����10������_10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10������_10.MyObj.MyForm.MyObjs) : ����10������_10.MyObj.MyForm.MyObjs(����10������_10.MyObj.MyForm.MyObjs.Length - 1) = ����10������_10.MyObj

����10�������30.MyObj = New Label(True, True)
����10�������30.MyObj.proj = proj
����10�������30.MyObj.obj = ����10�������30
����10�������30.MyObj.VBname = "����10�������30"
����10�������30.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������30.MyObj.MyForm.MyObjs) : ����10�������30.MyObj.MyForm.MyObjs(����10�������30.MyObj.MyForm.MyObjs.Length - 1) = ����10�������30.MyObj

����10�������40.MyObj = New Label(True, True)
����10�������40.MyObj.proj = proj
����10�������40.MyObj.obj = ����10�������40
����10�������40.MyObj.VBname = "����10�������40"
����10�������40.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������40.MyObj.MyForm.MyObjs) : ����10�������40.MyObj.MyForm.MyObjs(����10�������40.MyObj.MyForm.MyObjs.Length - 1) = ����10�������40.MyObj

����10�������50.MyObj = New Label(True, True)
����10�������50.MyObj.proj = proj
����10�������50.MyObj.obj = ����10�������50
����10�������50.MyObj.VBname = "����10�������50"
����10�������50.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������50.MyObj.MyForm.MyObjs) : ����10�������50.MyObj.MyForm.MyObjs(����10�������50.MyObj.MyForm.MyObjs.Length - 1) = ����10�������50.MyObj

ProgressForm.ProgressBar1.Value = 9
����10��������1_��������10.MyObj = New TPages(True, True)
����10��������1_��������10.MyObj.proj = proj
����10��������1_��������10.MyObj.obj = ����10��������1_��������10
����10��������1_��������10.MyObj.VBname = "����10��������1_��������10"
����10��������1_��������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10��������1_��������10.MyObj.MyForm.MyObjs) : ����10��������1_��������10.MyObj.MyForm.MyObjs(����10��������1_��������10.MyObj.MyForm.MyObjs.Length - 1) = ����10��������1_��������10.MyObj

����10��������1_��������20.MyObj = New TPages(True, True)
����10��������1_��������20.MyObj.proj = proj
����10��������1_��������20.MyObj.obj = ����10��������1_��������20
����10��������1_��������20.MyObj.VBname = "����10��������1_��������20"
����10��������1_��������20.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10��������1_��������20.MyObj.MyForm.MyObjs) : ����10��������1_��������20.MyObj.MyForm.MyObjs(����10��������1_��������20.MyObj.MyForm.MyObjs.Length - 1) = ����10��������1_��������20.MyObj

����10�������������0.MyObj = New Button(True, True)
����10�������������0.MyObj.proj = proj
����10�������������0.MyObj.obj = ����10�������������0
����10�������������0.MyObj.VBname = "����10�������������0"
����10�������������0.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������������0.MyObj.MyForm.MyObjs) : ����10�������������0.MyObj.MyForm.MyObjs(����10�������������0.MyObj.MyForm.MyObjs.Length - 1) = ����10�������������0.MyObj

����10��������������0.MyObj = New Button(True, True)
����10��������������0.MyObj.proj = proj
����10��������������0.MyObj.obj = ����10��������������0
����10��������������0.MyObj.VBname = "����10��������������0"
����10��������������0.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10��������������0.MyObj.MyForm.MyObjs) : ����10��������������0.MyObj.MyForm.MyObjs(����10��������������0.MyObj.MyForm.MyObjs.Length - 1) = ����10��������������0.MyObj

����10�����������0.MyObj = New Button(True, True)
����10�����������0.MyObj.proj = proj
����10�����������0.MyObj.obj = ����10�����������0
����10�����������0.MyObj.VBname = "����10�����������0"
����10�����������0.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�����������0.MyObj.MyForm.MyObjs) : ����10�����������0.MyObj.MyForm.MyObjs(����10�����������0.MyObj.MyForm.MyObjs.Length - 1) = ����10�����������0.MyObj

ProgressForm.ProgressBar1.Value = 13
����10������_��������10.MyObj = New ProgressBar(True, True)
����10������_��������10.MyObj.proj = proj
����10������_��������10.MyObj.obj = ����10������_��������10
����10������_��������10.MyObj.VBname = "����10������_��������10"
����10������_��������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10������_��������10.MyObj.MyForm.MyObjs) : ����10������_��������10.MyObj.MyForm.MyObjs(����10������_��������10.MyObj.MyForm.MyObjs.Length - 1) = ����10������_��������10.MyObj

����10��������������0.MyObj = New Label(True, True)
����10��������������0.MyObj.proj = proj
����10��������������0.MyObj.obj = ����10��������������0
����10��������������0.MyObj.VBname = "����10��������������0"
����10��������������0.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10��������������0.MyObj.MyForm.MyObjs) : ����10��������������0.MyObj.MyForm.MyObjs(����10��������������0.MyObj.MyForm.MyObjs.Length - 1) = ����10��������������0.MyObj

����10�������10.MyObj = New PictureBoks(True, True)
����10�������10.MyObj.proj = proj
����10�������10.MyObj.obj = ����10�������10
����10�������10.MyObj.VBname = "����10�������10"
����10�������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������10.MyObj.MyForm.MyObjs) : ����10�������10.MyObj.MyForm.MyObjs(����10�������10.MyObj.MyForm.MyObjs.Length - 1) = ����10�������10.MyObj

_��������_�������0_��������_�������0.MyObj = New Forms(True, , True)
_��������_�������0_��������_�������0.MyObj.proj = proj
_��������_�������0_��������_�������0.MyObj.obj = _��������_�������0_��������_�������0
_��������_�������0_��������_�������0.MyObj.VBname = "_��������_�������0_��������_�������0"
_��������_�������0_��������_�������0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_��������_�������0.MyObj.MyForm.MyObjs) : _��������_�������0_��������_�������0.MyObj.MyForm.MyObjs(_��������_�������0_��������_�������0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_��������_�������0.MyObj

_��������_�������0_�����0.MyObj = New Poleznie("_�����")
_��������_�������0_�����0.MyObj.proj = proj
_��������_�������0_�����0.MyObj.obj = _��������_�������0_�����0
_��������_�������0_�����0.MyObj.VBname = "_��������_�������0_�����0"
_��������_�������0_�����0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_�����0.MyObj.MyForm.MyObjs) : _��������_�������0_�����0.MyObj.MyForm.MyObjs(_��������_�������0_�����0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_�����0.MyObj

ProgressForm.ProgressBar1.Value = 17
_��������_�������0_�����_�_�����0.MyObj = New Poleznie("_����� � �����")
_��������_�������0_�����_�_�����0.MyObj.proj = proj
_��������_�������0_�����_�_�����0.MyObj.obj = _��������_�������0_�����_�_�����0
_��������_�������0_�����_�_�����0.MyObj.VBname = "_��������_�������0_�����_�_�����0"
_��������_�������0_�����_�_�����0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_�����_�_�����0.MyObj.MyForm.MyObjs) : _��������_�������0_�����_�_�����0.MyObj.MyForm.MyObjs(_��������_�������0_�����_�_�����0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_�����_�_�����0.MyObj

_��������_�������0_����������0.MyObj = New Poleznie("_����������")
_��������_�������0_����������0.MyObj.proj = proj
_��������_�������0_����������0.MyObj.obj = _��������_�������0_����������0
_��������_�������0_����������0.MyObj.VBname = "_��������_�������0_����������0"
_��������_�������0_����������0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_����������0.MyObj.MyForm.MyObjs) : _��������_�������0_����������0.MyObj.MyForm.MyObjs(_��������_�������0_����������0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_����������0.MyObj

_��������_�������0_�������0.MyObj = New Poleznie("_�������")
_��������_�������0_�������0.MyObj.proj = proj
_��������_�������0_�������0.MyObj.obj = _��������_�������0_�������0
_��������_�������0_�������0.MyObj.VBname = "_��������_�������0_�������0"
_��������_�������0_�������0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_�������0.MyObj.MyForm.MyObjs) : _��������_�������0_�������0.MyObj.MyForm.MyObjs(_��������_�������0_�������0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_�������0.MyObj

_��������_�������0_������0.MyObj = New Poleznie("_������")
_��������_�������0_������0.MyObj.proj = proj
_��������_�������0_������0.MyObj.obj = _��������_�������0_������0
_��������_�������0_������0.MyObj.VBname = "_��������_�������0_������0"
_��������_�������0_������0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_������0.MyObj.MyForm.MyObjs) : _��������_�������0_������0.MyObj.MyForm.MyObjs(_��������_�������0_������0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_������0.MyObj

_��������_�������0_�������_�������0.MyObj = New Poleznie("_������� �������")
_��������_�������0_�������_�������0.MyObj.proj = proj
_��������_�������0_�������_�������0.MyObj.obj = _��������_�������0_�������_�������0
_��������_�������0_�������_�������0.MyObj.VBname = "_��������_�������0_�������_�������0"
_��������_�������0_�������_�������0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_�������_�������0.MyObj.MyForm.MyObjs) : _��������_�������0_�������_�������0.MyObj.MyForm.MyObjs(_��������_�������0_�������_�������0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_�������_�������0.MyObj

ProgressForm.ProgressBar1.Value = 22
_��������_�������0_�����0.MyObj = New Poleznie("_�����")
_��������_�������0_�����0.MyObj.proj = proj
_��������_�������0_�����0.MyObj.obj = _��������_�������0_�����0
_��������_�������0_�����0.MyObj.VBname = "_��������_�������0_�����0"
_��������_�������0_�����0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_�����0.MyObj.MyForm.MyObjs) : _��������_�������0_�����0.MyObj.MyForm.MyObjs(_��������_�������0_�����0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_�����0.MyObj

_��������_�������0_��������_���������0.MyObj = New Poleznie("_�������� ���������")
_��������_�������0_��������_���������0.MyObj.proj = proj
_��������_�������0_��������_���������0.MyObj.obj = _��������_�������0_��������_���������0
_��������_�������0_��������_���������0.MyObj.VBname = "_��������_�������0_��������_���������0"
_��������_�������0_��������_���������0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_��������_���������0.MyObj.MyForm.MyObjs) : _��������_�������0_��������_���������0.MyObj.MyForm.MyObjs(_��������_�������0_��������_���������0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_��������_���������0.MyObj

_��������_�������0_����0.MyObj = New Poleznie("_����")
_��������_�������0_����0.MyObj.proj = proj
_��������_�������0_����0.MyObj.obj = _��������_�������0_����0
_��������_�������0_����0.MyObj.VBname = "_��������_�������0_����0"
_��������_�������0_����0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_����0.MyObj.MyForm.MyObjs) : _��������_�������0_����0.MyObj.MyForm.MyObjs(_��������_�������0_����0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_����0.MyObj

_��������_�������0_�����������_�����������0.MyObj = New Poleznie("_����������� �����������")
_��������_�������0_�����������_�����������0.MyObj.proj = proj
_��������_�������0_�����������_�����������0.MyObj.obj = _��������_�������0_�����������_�����������0
_��������_�������0_�����������_�����������0.MyObj.VBname = "_��������_�������0_�����������_�����������0"
_��������_�������0_�����������_�����������0.MyObj.MyObj.MyForm = _��������_�������0_��������_�������0.MyObj
ReDimsO(_��������_�������0_�����������_�����������0.MyObj.MyForm.MyObjs) : _��������_�������0_�����������_�����������0.MyObj.MyForm.MyObjs(_��������_�������0_�����������_�����������0.MyObj.MyForm.MyObjs.Length - 1) = _��������_�������0_�����������_�����������0.MyObj



' ���������� �������� �� �����
ProgressForm.ProgressBar1.Value = 25
����10����10.Controls.Add(����10��������10)
����10����10.Controls.Add(����10��������10)
����10����10.Controls.Add(����10�������10)
ProgressForm.ProgressBar1.Value = 27
����10����10.Controls.Add(����10�������20)
����10����10.Controls.Add(����10������_10)
����10������_10.Controls.Add(����10�������30)
����10������_10.Controls.Add(����10�������40)
����10������_10.Controls.Add(����10�������50)
ProgressForm.ProgressBar1.Value = 28
����10��������10.Controls.Add(����10��������1_��������10)
����10��������10.Controls.Add(����10��������1_��������20)
����10��������1_��������10.Controls.Add(����10�������������0)
����10��������1_��������10.Controls.Add(����10��������������0)
����10��������1_��������10.Controls.Add(����10�����������0)
ProgressForm.ProgressBar1.Value = 30
����10��������1_��������10.Controls.Add(����10������_��������10)
����10��������1_��������10.Controls.Add(����10��������������0)
����10��������1_��������20.Controls.Add(����10�������10)
ProgressForm.ProgressBar1.Value = 32
ProgressForm.ProgressBar1.Value = 34


' �������� �� ������� �������
ProgressForm.ProgressBar1.Value = 35
����10��������1_��������10.BringToFront()
����10��������1_��������20.BringToFront()
����10��������10.BringToFront()
����10�������������0.BringToFront()
����10��������������0.BringToFront()
����10�����������0.BringToFront()
����10������_��������10.BringToFront()
����10��������������0.BringToFront()
����10������_10.BringToFront()
����10����_����������10.BringToFront()
����10��������10.BringToFront()
����10�������10.BringToFront()
����10�������20.BringToFront()
����10�������30.BringToFront()
����10�������40.BringToFront()
����10�������10.BringToFront()
����10�������50.BringToFront()
ProgressForm.ProgressBar1.Value = 37
ProgressForm.ProgressBar1.Value = 38
ProgressForm.ProgressBar1.Value = 40
ProgressForm.ProgressBar1.Value = 42
ProgressForm.ProgressBar1.Value = 44


' ��������� ������� ��������
ProgressForm.ProgressBar1.Value = 45
����10����10.Props.Text = perevesti("��������������", True)
����10����10.Props.X = perevesti("0", True)
����10����10.Props.Y = perevesti("0", True)
����10����10.Props.Associatewithextensions = perevesti("", True)
����10����10.Props.Contextmenu(True) = perevesti("�������", True)
����10����10.Props.Tag = perevesti("", True)
����10����10.Props.Mainform = perevesti("��", True)
����10����10.Props.Mainmenustrip(True) = perevesti("�������", True)
����10����10.Props.AutoRun = perevesti("���", True)
����10����10.Props.Forbidclose = perevesti("���", True)
����10����10.Props.Forbidminimize = perevesti("���", True)
����10����10.Props.Forbidmaximize = perevesti("��", True)
����10����10.Props.Icon = perevesti("�������", True)
����10����10.Props.Name = perevesti("����1", True)
����10����10.Props.Cursor = perevesti("�������", True)
����10����10.Props.Maximumheight = perevesti("0", True)
����10����10.Props.Maximumwidth = perevesti("0", True)
����10����10.Props.Minimumheight = perevesti("0", True)
����10����10.Props.Minimumwidth = perevesti("0", True)
����10����10.Props.Index = perevesti("0", True)
����10����10.Props.Controlbox = perevesti("��", True)
����10����10.Props.Showintaskbar = perevesti("��", True)
����10����10.Props.Showintray = perevesti("��", True)
����10����10.Props.TopMost = perevesti("���", True)
����10����10.Props.ToolTip = perevesti("", True)
����10����10.Props.Showicon = perevesti("���", True)
����10����10.Props.Opacity = perevesti("90", True)
����10����10.Props.Transparentcykey = perevesti("�������", True)
����10����10.Props.Scroll = perevesti("���", True)
����10����10.Props.AutoscrollminSizeheight = perevesti("0", True)
����10����10.Props.AutoscrollminSizewidth = perevesti("0", True)
����10����10.Props.AutoscrollpositionX = perevesti("0", True)
����10����10.Props.AutoscrollpositionY = perevesti("0", True)
����10����10.Props.Enabled = perevesti("��", True)
����10����10.Props.Allowruncopies = perevesti("���", True)
����10����10.Props.Startposition = perevesti("�������� ������������", True)
����10����10.StatusTemp = "����������"
����10����10.Props.Formborderstyle = perevesti("����������", True)
����10����10.Props.Backgroundimagelayout = perevesti("������", True)
����10����10.Props.Tabindex = perevesti("0", True)
����10����10.Props.Tabstop = perevesti("��", True)
����10����10.Props.Backgroundimage = perevesti("�������", True)
����10����10.Props.Backcolor = perevesti("240; 240; 240;", True)
����10����10.Props.Forecolor = perevesti("������", True)
����10����10.Props.Height = perevesti("395", True)
����10����10.Props.Width = perevesti("631", True)
����10����10.Props.Visible = perevesti("��", True)
����10����10.Props.Height = perevesti("395", True)
����10����10.Props.Width = perevesti("631", True)

ProgressForm.ProgressBar1.Value = 47
����10��������10.Props.X = perevesti("0", True)
����10��������10.Props.Y = perevesti("0", True)
����10��������10.Props.Contextmenu(True) = perevesti("�������", True)
����10��������10.Props.Tag = perevesti("", True)
����10��������10.Props.Name = perevesti("��������1", True)
����10��������10.Props.Cursor = perevesti("�������", True)
����10��������10.Props.Maximumheight = perevesti("0", True)
����10��������10.Props.Maximumwidth = perevesti("0", True)
����10��������10.Props.Minimumheight = perevesti("0", True)
����10��������10.Props.Minimumwidth = perevesti("0", True)
����10��������10.Props.Multiline = perevesti("���", True)
����10��������10.Props.Index = perevesti("0", True)
����10��������10.Props.ToolTip = perevesti("", True)
����10��������10.Props.Selectedtabposition = perevesti("0", True)
����10��������10.Props.PaddingY = perevesti("3", True)
����10��������10.Props.PaddingX = perevesti("6", True)
����10��������10.Props.Tabalignment = perevesti("������", True)
����10��������10.Props.Anchor = perevesti("�����_������", True)
����10��������10.Props.Enabled = perevesti("��", True)
����10��������10.Props.Dock = perevesti("�������", True)
����10��������10.Props.Tabindex = perevesti("0", True)
����10��������10.Props.Tabstop = perevesti("��", True)
����10��������10.Props.Height = perevesti("371", True)
����10��������10.Props.Width = perevesti("631", True)
����10��������10.Props.Visible = perevesti("��", True)
����10��������10.Props.Height = perevesti("371", True)
����10��������10.Props.Width = perevesti("631", True)

ProgressForm.ProgressBar1.Value = 49
����10����_����������10.Props.X = perevesti("12", True)
����10����_����������10.Props.Y = perevesti("12", True)
����10����_����������10.Props.Tag = perevesti("", True)
����10����_����������10.Props.Defaultext = perevesti("", True)
����10����_����������10.Props.Title = perevesti("", True)
����10����_����������10.Props.Name = perevesti("���� ����������1", True)
����10����_����������10.Props.Filename = perevesti("", True)
����10����_����������10.Props.Initialdirectory = perevesti("", True)
����10����_����������10.Props.Index = perevesti("0", True)
����10����_����������10.Props.Filterindex = perevesti("1", True)
����10����_����������10.Props.Checkpathexists = perevesti("��", True)
����10����_����������10.Props.Checkfileexists = perevesti("���", True)
����10����_����������10.Props.Filter = perevesti("���������|*.exe|��� �����|*.*", True)

ProgressForm.ProgressBar1.Value = 51
����10��������10.Props.X = perevesti("612", True)
����10��������10.Props.Y = perevesti("372", True)
����10��������10.Props.Allowautoredirect = perevesti("���", True)
����10��������10.Props.Timedelay = perevesti("0", True)
����10��������10.Props.Tag = perevesti("", True)
����10��������10.Props.Name = perevesti("��������1", True)
����10��������10.Props.Encodingpage = perevesti("windows-1251", True)
����10��������10.Props.Cookiesqueries = perevesti("", True)
����10��������10.Props.Maximumheight = perevesti("0", True)
����10��������10.Props.Maximumwidth = perevesti("0", True)
����10��������10.Props.Httpmethod = perevesti("POST", True)
����10��������10.Props.Minimumheight = perevesti("0", True)
����10��������10.Props.Minimumwidth = perevesti("0", True)
����10��������10.Props.Index = perevesti("0", True)
����10��������10.Props.Pathfordownloads = perevesti("", True)
����10��������10.Props.ToolTip = perevesti("", True)
����10��������10.Props.Anchor = perevesti("�����_������", True)
����10��������10.Props.Accept = perevesti("image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*", True)
����10��������10.Props.ProxyIP = perevesti("", True)
����10��������10.Props.Proxyport = perevesti("0", True)
����10��������10.Props.Enabled = perevesti("��", True)
����10��������10.Props.Buffersize = perevesti("5000", True)
����10��������10.Props.Dock = perevesti("�������", True)
����10��������10.Props.Resultquery = perevesti("", True)
����10��������10.Props.Filedownloading = perevesti("���", True)
����10��������10.Props.Downloadpause = perevesti("���", True)
����10��������10.Props.Contentquery = perevesti("", True)
����10��������10.Props.Urltogo = perevesti("http://www.Algoritm2.ru", True)
����10��������10.Props.Urlreferer = perevesti("", True)
����10��������10.Props.Urlredirect = perevesti("", True)
����10��������10.Props.Borderstyle = perevesti("�������", True)
����10��������10.Props.Backgroundimagelayout = perevesti("������", True)
����10��������10.Props.Tabindex = perevesti("0", True)
����10��������10.Props.Tabstop = perevesti("��", True)
����10��������10.Props.Timeout = perevesti("10000", True)
����10��������10.Props.Useragent = perevesti("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;", True)
����10��������10.Props.Contenttype = perevesti("application/x-www-form-urlencoded", True)
����10��������10.Props.Keepalive = perevesti("���", True)
����10��������10.Props.Backgroundimage = perevesti("�������", True)
����10��������10.Props.Backcolor = perevesti("�������", True)
����10��������10.Props.Languagepage = perevesti("", True)
����10��������10.Props.Height = perevesti("23", True)
����10��������10.Props.Width = perevesti("11", True)
����10��������10.Props.Visible = perevesti("��", True)
����10��������10.Props.Height = perevesti("23", True)
����10��������10.Props.Width = perevesti("11", True)

ProgressForm.ProgressBar1.Value = 53
����10�������10.Props.Text = perevesti("������� ������ ��������� �������� ����������� �����������", True)
����10�������10.Props.X = perevesti("0", True)
����10�������10.Props.Y = perevesti("372", True)
����10�������10.Props.Autoellipsis = perevesti("��", True)
����10�������10.Props.Contextmenu(True) = perevesti("�������", True)
����10�������10.Props.Tag = perevesti("", True)
����10�������10.Props.Name = perevesti("�������1", True)
����10�������10.Props.Cursor = perevesti("�������", True)
����10�������10.Props.Maximumheight = perevesti("0", True)
����10�������10.Props.Maximumwidth = perevesti("0", True)
����10�������10.Props.Minimumheight = perevesti("0", True)
����10�������10.Props.Minimumwidth = perevesti("0", True)
����10�������10.Props.Index = perevesti("0", True)
����10�������10.Props.ToolTip = perevesti("", True)
����10�������10.Props.Paddingtop = perevesti("0", True)
����10�������10.Props.Paddingleft = perevesti("0", True)
����10�������10.Props.Paddingbottom = perevesti("0", True)
����10�������10.Props.Paddingright = perevesti("0", True)
����10�������10.Props.Imagealign = perevesti("�����", True)
����10�������10.Props.Textalign = perevesti("�����", True)
����10�������10.Props.Anchor = perevesti("�����_������", True)
����10�������10.Props.Enabled = perevesti("��", True)
����10�������10.Props.Dock = perevesti("�������", True)
����10�������10.Props.Image = perevesti("�������", True)
����10�������10.Props.Borderstyle = perevesti("�������", True)
����10�������10.Props.Backgroundimagelayout = perevesti("������", True)
����10�������10.Props.Tabindex = perevesti("0", True)
����10�������10.Props.Tabstop = perevesti("��", True)
����10�������10.Props.Backgroundimage = perevesti("�������", True)
����10�������10.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������10.Props.Forecolor = perevesti("������", True)
����10�������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������10.Props.Fontbold = perevesti("���", True)
����10�������10.Props.Fontstrikeout = perevesti("���", True)
����10�������10.Props.Fontitalic = perevesti("���", True)
����10�������10.Props.Fontunderline = perevesti("���", True)
����10�������10.Props.Fontsize = perevesti("8", True)
����10�������10.Props.Height = perevesti("23", True)
����10�������10.Props.Width = perevesti("631", True)
����10�������10.Props.Visible = perevesti("��", True)
����10�������10.Props.Height = perevesti("23", True)
����10�������10.Props.Width = perevesti("631", True)

ProgressForm.ProgressBar1.Value = 54
����10�������20.Props.Text = perevesti("��� ����� ���� ���� ������� ������� ����� �������� �� ����� �����.", True)
����10�������20.Props.X = perevesti("436", True)
����10�������20.Props.Y = perevesti("24", True)
����10�������20.Props.Autoellipsis = perevesti("��", True)
����10�������20.Props.Contextmenu(True) = perevesti("�������", True)
����10�������20.Props.Tag = perevesti("", True)
����10�������20.Props.Name = perevesti("�������2", True)
����10�������20.Props.Cursor = perevesti("�������", True)
����10�������20.Props.Maximumheight = perevesti("0", True)
����10�������20.Props.Maximumwidth = perevesti("0", True)
����10�������20.Props.Minimumheight = perevesti("0", True)
����10�������20.Props.Minimumwidth = perevesti("0", True)
����10�������20.Props.Index = perevesti("0", True)
����10�������20.Props.ToolTip = perevesti("", True)
����10�������20.Props.Paddingtop = perevesti("0", True)
����10�������20.Props.Paddingleft = perevesti("0", True)
����10�������20.Props.Paddingbottom = perevesti("0", True)
����10�������20.Props.Paddingright = perevesti("0", True)
����10�������20.Props.Imagealign = perevesti("�����", True)
����10�������20.Props.Textalign = perevesti("�����", True)
����10�������20.Props.Anchor = perevesti("�����_������", True)
����10�������20.Props.Enabled = perevesti("��", True)
����10�������20.Props.Dock = perevesti("�������", True)
����10�������20.Props.Image = perevesti("�������", True)
����10�������20.Props.Borderstyle = perevesti("�������", True)
����10�������20.Props.Backgroundimagelayout = perevesti("������", True)
����10�������20.Props.Tabindex = perevesti("0", True)
����10�������20.Props.Tabstop = perevesti("��", True)
����10�������20.Props.Backgroundimage = perevesti("�������", True)
����10�������20.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������20.Props.Forecolor = perevesti("������", True)
����10�������20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������20.Props.Fontbold = perevesti("���", True)
����10�������20.Props.Fontstrikeout = perevesti("���", True)
����10�������20.Props.Fontitalic = perevesti("���", True)
����10�������20.Props.Fontunderline = perevesti("���", True)
����10�������20.Props.Fontsize = perevesti("8", True)
����10�������20.Props.Height = perevesti("79", True)
����10�������20.Props.Width = perevesti("95", True)
����10�������20.Props.Visible = perevesti("��", True)
����10�������20.Props.Height = perevesti("79", True)
����10�������20.Props.Width = perevesti("95", True)

ProgressForm.ProgressBar1.Value = 56
����10������_10.Props.X = perevesti("432", True)
����10������_10.Props.Y = perevesti("20", True)
����10������_10.Props.Contextmenu(True) = perevesti("�������", True)
����10������_10.Props.Tag = perevesti("", True)
����10������_10.Props.Name = perevesti("������ 1", True)
����10������_10.Props.Cursor = perevesti("�������", True)
����10������_10.Props.Maximumheight = perevesti("0", True)
����10������_10.Props.Maximumwidth = perevesti("0", True)
����10������_10.Props.Minimumheight = perevesti("0", True)
����10������_10.Props.Minimumwidth = perevesti("0", True)
����10������_10.Props.Index = perevesti("0", True)
����10������_10.Props.ToolTip = perevesti("", True)
����10������_10.Props.Anchor = perevesti("�����_������", True)
����10������_10.Props.Scroll = perevesti("���", True)
����10������_10.Props.AutoscrollminSizeheight = perevesti("0", True)
����10������_10.Props.AutoscrollminSizewidth = perevesti("0", True)
����10������_10.Props.AutoscrollpositionX = perevesti("0", True)
����10������_10.Props.AutoscrollpositionY = perevesti("0", True)
����10������_10.Props.Enabled = perevesti("��", True)
����10������_10.Props.Dock = perevesti("�������", True)
����10������_10.Props.Borderstyle = perevesti("�����", True)
����10������_10.Props.Backgroundimagelayout = perevesti("������", True)
����10������_10.Props.Tabindex = perevesti("0", True)
����10������_10.Props.Tabstop = perevesti("��", True)
����10������_10.Props.Backgroundimage = perevesti("�������", True)
����10������_10.Props.Backcolor = perevesti("240; 240; 240;", True)
����10������_10.Props.Height = perevesti("315", True)
����10������_10.Props.Width = perevesti("199", True)
����10������_10.Props.Visible = perevesti("��", True)
����10������_10.Props.Height = perevesti("315", True)
����10������_10.Props.Width = perevesti("199", True)

ProgressForm.ProgressBar1.Value = 58
����10�������30.Props.Text = perevesti("���� ����� �������� ������� �� �������� ������� ������� ��� �� ����� �������� � ��� �� �����.", True)
����10�������30.Props.X = perevesti("4", True)
����10�������30.Props.Y = perevesti("92", True)
����10�������30.Props.Autoellipsis = perevesti("��", True)
����10�������30.Props.Contextmenu(True) = perevesti("�������", True)
����10�������30.Props.Tag = perevesti("", True)
����10�������30.Props.Name = perevesti("�������3", True)
����10�������30.Props.Cursor = perevesti("�������", True)
����10�������30.Props.Maximumheight = perevesti("0", True)
����10�������30.Props.Maximumwidth = perevesti("0", True)
����10�������30.Props.Minimumheight = perevesti("0", True)
����10�������30.Props.Minimumwidth = perevesti("0", True)
����10�������30.Props.Index = perevesti("0", True)
����10�������30.Props.ToolTip = perevesti("", True)
����10�������30.Props.Paddingtop = perevesti("0", True)
����10�������30.Props.Paddingleft = perevesti("0", True)
����10�������30.Props.Paddingbottom = perevesti("0", True)
����10�������30.Props.Paddingright = perevesti("0", True)
����10�������30.Props.Imagealign = perevesti("�����", True)
����10�������30.Props.Textalign = perevesti("�����", True)
����10�������30.Props.Anchor = perevesti("�����_������", True)
����10�������30.Props.Enabled = perevesti("��", True)
����10�������30.Props.Dock = perevesti("�������", True)
����10�������30.Props.Image = perevesti("�������", True)
����10�������30.Props.Borderstyle = perevesti("�������", True)
����10�������30.Props.Backgroundimagelayout = perevesti("������", True)
����10�������30.Props.Tabindex = perevesti("0", True)
����10�������30.Props.Tabstop = perevesti("��", True)
����10�������30.Props.Backgroundimage = perevesti("�������", True)
����10�������30.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������30.Props.Forecolor = perevesti("������", True)
����10�������30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������30.Props.Fontbold = perevesti("���", True)
����10�������30.Props.Fontstrikeout = perevesti("���", True)
����10�������30.Props.Fontitalic = perevesti("���", True)
����10�������30.Props.Fontunderline = perevesti("���", True)
����10�������30.Props.Fontsize = perevesti("8", True)
����10�������30.Props.Height = perevesti("95", True)
����10�������30.Props.Width = perevesti("107", True)
����10�������30.Props.Visible = perevesti("��", True)
����10�������30.Props.Height = perevesti("95", True)
����10�������30.Props.Width = perevesti("107", True)

ProgressForm.ProgressBar1.Value = 60
����10�������40.Props.Text = perevesti("��� �� ���� �������� ��� ������", True)
����10�������40.Props.X = perevesti("128", True)
����10�������40.Props.Y = perevesti("8", True)
����10�������40.Props.Autoellipsis = perevesti("��", True)
����10�������40.Props.Contextmenu(True) = perevesti("�������", True)
����10�������40.Props.Tag = perevesti("", True)
����10�������40.Props.Name = perevesti("�������4", True)
����10�������40.Props.Cursor = perevesti("�������", True)
����10�������40.Props.Maximumheight = perevesti("0", True)
����10�������40.Props.Maximumwidth = perevesti("0", True)
����10�������40.Props.Minimumheight = perevesti("0", True)
����10�������40.Props.Minimumwidth = perevesti("0", True)
����10�������40.Props.Index = perevesti("0", True)
����10�������40.Props.ToolTip = perevesti("", True)
����10�������40.Props.Paddingtop = perevesti("0", True)
����10�������40.Props.Paddingleft = perevesti("0", True)
����10�������40.Props.Paddingbottom = perevesti("0", True)
����10�������40.Props.Paddingright = perevesti("0", True)
����10�������40.Props.Imagealign = perevesti("�����", True)
����10�������40.Props.Textalign = perevesti("�����", True)
����10�������40.Props.Anchor = perevesti("�����_������", True)
����10�������40.Props.Enabled = perevesti("��", True)
����10�������40.Props.Dock = perevesti("�������", True)
����10�������40.Props.Image = perevesti("�������", True)
����10�������40.Props.Borderstyle = perevesti("�������", True)
����10�������40.Props.Backgroundimagelayout = perevesti("������", True)
����10�������40.Props.Tabindex = perevesti("0", True)
����10�������40.Props.Tabstop = perevesti("��", True)
����10�������40.Props.Backgroundimage = perevesti("�������", True)
����10�������40.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������40.Props.Forecolor = perevesti("������", True)
����10�������40.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������40.Props.Fontbold = perevesti("���", True)
����10�������40.Props.Fontstrikeout = perevesti("���", True)
����10�������40.Props.Fontitalic = perevesti("���", True)
����10�������40.Props.Fontunderline = perevesti("���", True)
����10�������40.Props.Fontsize = perevesti("8", True)
����10�������40.Props.Height = perevesti("91", True)
����10�������40.Props.Width = perevesti("59", True)
����10�������40.Props.Visible = perevesti("��", True)
����10�������40.Props.Height = perevesti("91", True)
����10�������40.Props.Width = perevesti("59", True)

ProgressForm.ProgressBar1.Value = 62
����10�������50.Props.Text = perevesti("��� ������� ��������� ���������� �� ������:) �� ��� ����� ���������.", True)
����10�������50.Props.X = perevesti("4", True)
����10�������50.Props.Y = perevesti("200", True)
����10�������50.Props.Autoellipsis = perevesti("��", True)
����10�������50.Props.Contextmenu(True) = perevesti("�������", True)
����10�������50.Props.Tag = perevesti("", True)
����10�������50.Props.Name = perevesti("�������5", True)
����10�������50.Props.Cursor = perevesti("�������", True)
����10�������50.Props.Maximumheight = perevesti("0", True)
����10�������50.Props.Maximumwidth = perevesti("0", True)
����10�������50.Props.Minimumheight = perevesti("0", True)
����10�������50.Props.Minimumwidth = perevesti("0", True)
����10�������50.Props.Index = perevesti("0", True)
����10�������50.Props.ToolTip = perevesti("", True)
����10�������50.Props.Paddingtop = perevesti("0", True)
����10�������50.Props.Paddingleft = perevesti("0", True)
����10�������50.Props.Paddingbottom = perevesti("0", True)
����10�������50.Props.Paddingright = perevesti("0", True)
����10�������50.Props.Imagealign = perevesti("�����", True)
����10�������50.Props.Textalign = perevesti("�����", True)
����10�������50.Props.Anchor = perevesti("�����_������", True)
����10�������50.Props.Enabled = perevesti("��", True)
����10�������50.Props.Dock = perevesti("�������", True)
����10�������50.Props.Image = perevesti("�������", True)
����10�������50.Props.Borderstyle = perevesti("�������", True)
����10�������50.Props.Backgroundimagelayout = perevesti("������", True)
����10�������50.Props.Tabindex = perevesti("0", True)
����10�������50.Props.Tabstop = perevesti("��", True)
����10�������50.Props.Backgroundimage = perevesti("�������", True)
����10�������50.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������50.Props.Forecolor = perevesti("������", True)
����10�������50.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������50.Props.Fontbold = perevesti("���", True)
����10�������50.Props.Fontstrikeout = perevesti("���", True)
����10�������50.Props.Fontitalic = perevesti("���", True)
����10�������50.Props.Fontunderline = perevesti("���", True)
����10�������50.Props.Fontsize = perevesti("8", True)
����10�������50.Props.Height = perevesti("71", True)
����10�������50.Props.Width = perevesti("115", True)
����10�������50.Props.Visible = perevesti("��", True)
����10�������50.Props.Height = perevesti("71", True)
����10�������50.Props.Width = perevesti("115", True)

ProgressForm.ProgressBar1.Value = 64
����10��������1_��������10.Props.Text = perevesti("    Day-Z    ", True)
����10��������1_��������10.Props.X = perevesti("4", True)
����10��������1_��������10.Props.Y = perevesti("22", True)
����10��������1_��������10.Props.Tooltiptext = perevesti("", True)
����10��������1_��������10.Props.Contextmenu(True) = perevesti("�������", True)
����10��������1_��������10.Props.Tag = perevesti("", True)
����10��������1_��������10.Props.Name = perevesti("��������1 ��������1", True)
����10��������1_��������10.Props.Cursor = perevesti("�������", True)
����10��������1_��������10.Props.Maximumheight = perevesti("0", True)
����10��������1_��������10.Props.Maximumwidth = perevesti("0", True)
����10��������1_��������10.Props.Minimumheight = perevesti("0", True)
����10��������1_��������10.Props.Minimumwidth = perevesti("0", True)
����10��������1_��������10.Props.Index = perevesti("0", True)
����10��������1_��������10.Props.Position = perevesti("0", True)
����10��������1_��������10.Props.Scroll = perevesti("���", True)
����10��������1_��������10.Props.AutoscrollminSizeheight = perevesti("0", True)
����10��������1_��������10.Props.AutoscrollminSizewidth = perevesti("0", True)
����10��������1_��������10.Props.AutoscrollpositionX = perevesti("0", True)
����10��������1_��������10.Props.AutoscrollpositionY = perevesti("0", True)
����10��������1_��������10.Props.Enabled = perevesti("��", True)
����10��������1_��������10.Props.Borderstyle = perevesti("�������", True)
����10��������1_��������10.Props.Backgroundimagelayout = perevesti("������", True)
����10��������1_��������10.Props.Tabindex = perevesti("0", True)
����10��������1_��������10.Props.Tabstop = perevesti("��", True)
����10��������1_��������10.Props.Backgroundimage = perevesti("�������\�������3.png", True)
����10��������1_��������10.Props.Backcolor = perevesti("���������", True)
����10��������1_��������10.Props.Height = perevesti("345", True)
����10��������1_��������10.Props.Width = perevesti("623", True)
����10��������1_��������10.Props.Height = perevesti("345", True)
����10��������1_��������10.Props.Width = perevesti("623", True)

ProgressForm.ProgressBar1.Value = 66
����10��������1_��������20.Props.Text = perevesti("     Cs:Source     ", True)
����10��������1_��������20.Props.X = perevesti("4", True)
����10��������1_��������20.Props.Y = perevesti("22", True)
����10��������1_��������20.Props.Tooltiptext = perevesti("", True)
����10��������1_��������20.Props.Contextmenu(True) = perevesti("�������", True)
����10��������1_��������20.Props.Tag = perevesti("", True)
����10��������1_��������20.Props.Name = perevesti("��������1 ��������2", True)
����10��������1_��������20.Props.Cursor = perevesti("�������", True)
����10��������1_��������20.Props.Maximumheight = perevesti("0", True)
����10��������1_��������20.Props.Maximumwidth = perevesti("0", True)
����10��������1_��������20.Props.Minimumheight = perevesti("0", True)
����10��������1_��������20.Props.Minimumwidth = perevesti("0", True)
����10��������1_��������20.Props.Index = perevesti("0", True)
����10��������1_��������20.Props.Position = perevesti("1", True)
����10��������1_��������20.Props.Scroll = perevesti("���", True)
����10��������1_��������20.Props.AutoscrollminSizeheight = perevesti("0", True)
����10��������1_��������20.Props.AutoscrollminSizewidth = perevesti("0", True)
����10��������1_��������20.Props.AutoscrollpositionX = perevesti("0", True)
����10��������1_��������20.Props.AutoscrollpositionY = perevesti("0", True)
����10��������1_��������20.Props.Enabled = perevesti("��", True)
����10��������1_��������20.Props.Borderstyle = perevesti("�������", True)
����10��������1_��������20.Props.Backgroundimagelayout = perevesti("������", True)
����10��������1_��������20.Props.Tabindex = perevesti("0", True)
����10��������1_��������20.Props.Tabstop = perevesti("��", True)
����10��������1_��������20.Props.Backgroundimage = perevesti("�������", True)
����10��������1_��������20.Props.Backcolor = perevesti("���������", True)
����10��������1_��������20.Props.Height = perevesti("345", True)
����10��������1_��������20.Props.Width = perevesti("623", True)
����10��������1_��������20.Props.Height = perevesti("345", True)
����10��������1_��������20.Props.Width = perevesti("623", True)

ProgressForm.ProgressBar1.Value = 68
����10�������������0.Props.Text = perevesti(" ", True)
����10�������������0.Props.X = perevesti("-4", True)
����10�������������0.Props.Y = perevesti("308", True)
����10�������������0.Props.Autoellipsis = perevesti("��", True)
����10�������������0.Props.Contextmenu(True) = perevesti("�������", True)
����10�������������0.Props.Tag = perevesti("", True)
����10�������������0.Props.Name = perevesti("�������������", True)
����10�������������0.Props.Cursor = perevesti("�������", True)
����10�������������0.Props.Maximumheight = perevesti("0", True)
����10�������������0.Props.Maximumwidth = perevesti("0", True)
����10�������������0.Props.Minimumheight = perevesti("0", True)
����10�������������0.Props.Minimumwidth = perevesti("0", True)
����10�������������0.Props.Index = perevesti("0", True)
����10�������������0.Props.ToolTip = perevesti("", True)
����10�������������0.Props.Paddingtop = perevesti("0", True)
����10�������������0.Props.Paddingleft = perevesti("0", True)
����10�������������0.Props.Paddingbottom = perevesti("0", True)
����10�������������0.Props.Paddingright = perevesti("0", True)
����10�������������0.Props.Imagealign = perevesti("�����", True)
����10�������������0.Props.Textalign = perevesti("�����", True)
����10�������������0.Props.Anchor = perevesti("�����_������", True)
����10�������������0.Props.Enabled = perevesti("��", True)
����10�������������0.Props.Dock = perevesti("�������", True)
����10�������������0.Props.Image = perevesti("�������", True)
����10�������������0.Props.Flatstyle = perevesti("�������", True)
����10�������������0.Props.Backgroundimagelayout = perevesti("������", True)
����10�������������0.Props.Tabindex = perevesti("0", True)
����10�������������0.Props.Tabstop = perevesti("��", True)
����10�������������0.Props.Textimagerelation = perevesti("������", True)
����10�������������0.Props.Backgroundimage = perevesti("�������\�������4.png", True)
����10�������������0.Props.Backcolor = perevesti("�������", True)
����10�������������0.Props.Forecolor = perevesti("������", True)
����10�������������0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������������0.Props.Fontbold = perevesti("���", True)
����10�������������0.Props.Fontstrikeout = perevesti("���", True)
����10�������������0.Props.Fontitalic = perevesti("���", True)
����10�������������0.Props.Fontunderline = perevesti("���", True)
����10�������������0.Props.Fontsize = perevesti("8", True)
����10�������������0.Props.Height = perevesti("39", True)
����10�������������0.Props.Width = perevesti("47", True)
����10�������������0.Props.Visible = perevesti("��", True)
����10�������������0.Props.Height = perevesti("39", True)
����10�������������0.Props.Width = perevesti("47", True)

ProgressForm.ProgressBar1.Value = 70
����10��������������0.Props.Text = perevesti("..", True)
����10��������������0.Props.X = perevesti("592", True)
����10��������������0.Props.Y = perevesti("320", True)
����10��������������0.Props.Autoellipsis = perevesti("��", True)
����10��������������0.Props.Contextmenu(True) = perevesti("�������", True)
����10��������������0.Props.Tag = perevesti("", True)
����10��������������0.Props.Name = perevesti("��������������", True)
����10��������������0.Props.Cursor = perevesti("�������", True)
����10��������������0.Props.Maximumheight = perevesti("0", True)
����10��������������0.Props.Maximumwidth = perevesti("0", True)
����10��������������0.Props.Minimumheight = perevesti("0", True)
����10��������������0.Props.Minimumwidth = perevesti("0", True)
����10��������������0.Props.Index = perevesti("0", True)
����10��������������0.Props.ToolTip = perevesti("", True)
����10��������������0.Props.Paddingtop = perevesti("0", True)
����10��������������0.Props.Paddingleft = perevesti("0", True)
����10��������������0.Props.Paddingbottom = perevesti("0", True)
����10��������������0.Props.Paddingright = perevesti("0", True)
����10��������������0.Props.Imagealign = perevesti("�����", True)
����10��������������0.Props.Textalign = perevesti("�����", True)
����10��������������0.Props.Anchor = perevesti("�����_������", True)
����10��������������0.Props.Enabled = perevesti("��", True)
����10��������������0.Props.Dock = perevesti("�������", True)
����10��������������0.Props.Image = perevesti("�������", True)
����10��������������0.Props.Flatstyle = perevesti("�������", True)
����10��������������0.Props.Backgroundimagelayout = perevesti("������", True)
����10��������������0.Props.Tabindex = perevesti("0", True)
����10��������������0.Props.Tabstop = perevesti("��", True)
����10��������������0.Props.Textimagerelation = perevesti("������", True)
����10��������������0.Props.Backgroundimage = perevesti("�������\�������7.png", True)
����10��������������0.Props.Backcolor = perevesti("�������", True)
����10��������������0.Props.Forecolor = perevesti("������", True)
����10��������������0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10��������������0.Props.Fontbold = perevesti("���", True)
����10��������������0.Props.Fontstrikeout = perevesti("���", True)
����10��������������0.Props.Fontitalic = perevesti("���", True)
����10��������������0.Props.Fontunderline = perevesti("���", True)
����10��������������0.Props.Fontsize = perevesti("8", True)
����10��������������0.Props.Height = perevesti("27", True)
����10��������������0.Props.Width = perevesti("31", True)
����10��������������0.Props.Visible = perevesti("��", True)
����10��������������0.Props.Height = perevesti("27", True)
����10��������������0.Props.Width = perevesti("31", True)

ProgressForm.ProgressBar1.Value = 72
����10�����������0.Props.Text = perevesti(".", True)
����10�����������0.Props.X = perevesti("44", True)
����10�����������0.Props.Y = perevesti("320", True)
����10�����������0.Props.Autoellipsis = perevesti("��", True)
����10�����������0.Props.Contextmenu(True) = perevesti("�������", True)
����10�����������0.Props.Tag = perevesti("", True)
����10�����������0.Props.Name = perevesti("�����������", True)
����10�����������0.Props.Cursor = perevesti("�������", True)
����10�����������0.Props.Maximumheight = perevesti("0", True)
����10�����������0.Props.Maximumwidth = perevesti("0", True)
����10�����������0.Props.Minimumheight = perevesti("0", True)
����10�����������0.Props.Minimumwidth = perevesti("0", True)
����10�����������0.Props.Index = perevesti("0", True)
����10�����������0.Props.ToolTip = perevesti("", True)
����10�����������0.Props.Paddingtop = perevesti("0", True)
����10�����������0.Props.Paddingleft = perevesti("0", True)
����10�����������0.Props.Paddingbottom = perevesti("0", True)
����10�����������0.Props.Paddingright = perevesti("0", True)
����10�����������0.Props.Imagealign = perevesti("�����", True)
����10�����������0.Props.Textalign = perevesti("�����", True)
����10�����������0.Props.Anchor = perevesti("�����_������", True)
����10�����������0.Props.Enabled = perevesti("��", True)
����10�����������0.Props.Dock = perevesti("�������", True)
����10�����������0.Props.Image = perevesti("�������", True)
����10�����������0.Props.Flatstyle = perevesti("�������", True)
����10�����������0.Props.Backgroundimagelayout = perevesti("������", True)
����10�����������0.Props.Tabindex = perevesti("0", True)
����10�����������0.Props.Tabstop = perevesti("��", True)
����10�����������0.Props.Textimagerelation = perevesti("������", True)
����10�����������0.Props.Backgroundimage = perevesti("�������\�������6.png", True)
����10�����������0.Props.Backcolor = perevesti("�������", True)
����10�����������0.Props.Forecolor = perevesti("������", True)
����10�����������0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�����������0.Props.Fontbold = perevesti("���", True)
����10�����������0.Props.Fontstrikeout = perevesti("���", True)
����10�����������0.Props.Fontitalic = perevesti("���", True)
����10�����������0.Props.Fontunderline = perevesti("���", True)
����10�����������0.Props.Fontsize = perevesti("8", True)
����10�����������0.Props.Height = perevesti("27", True)
����10�����������0.Props.Width = perevesti("31", True)
����10�����������0.Props.Visible = perevesti("��", True)
����10�����������0.Props.Height = perevesti("27", True)
����10�����������0.Props.Width = perevesti("31", True)

ProgressForm.ProgressBar1.Value = 73
����10������_��������10.Props.X = perevesti("76", True)
����10������_��������10.Props.Y = perevesti("320", True)
����10������_��������10.Props.Contextmenu(True) = perevesti("�������", True)
����10������_��������10.Props.Tag = perevesti("", True)
����10������_��������10.Props.Name = perevesti("������ ��������1", True)
����10������_��������10.Props.Cursor = perevesti("�������", True)
����10������_��������10.Props.Maximumheight = perevesti("0", True)
����10������_��������10.Props.Maximumwidth = perevesti("0", True)
����10������_��������10.Props.Maximum = perevesti("100", True)
����10������_��������10.Props.Minimumheight = perevesti("0", True)
����10������_��������10.Props.Minimumwidth = perevesti("0", True)
����10������_��������10.Props.Minimum = perevesti("0", True)
����10������_��������10.Props.Index = perevesti("0", True)
����10������_��������10.Props.ToolTip = perevesti("", True)
����10������_��������10.Props.Anchor = perevesti("�����_������", True)
����10������_��������10.Props.Enabled = perevesti("��", True)
����10������_��������10.Props.Dock = perevesti("�������", True)
����10������_��������10.Props.Marqueeanimationspeed = perevesti("100", True)
����10������_��������10.Props.Righttoleftlayout = perevesti("���", True)
����10������_��������10.Props.Styleprogress = perevesti("�����", True)
����10������_��������10.Props.Backgroundimagelayout = perevesti("������", True)
����10������_��������10.Props.Tabindex = perevesti("0", True)
����10������_��������10.Props.Tabstop = perevesti("��", True)
����10������_��������10.Props.Backgroundimage = perevesti("�������", True)
����10������_��������10.Props.Backcolor = perevesti("���������", True)
����10������_��������10.Props.Stepprogress = perevesti("10", True)
����10������_��������10.Props.Height = perevesti("27", True)
����10������_��������10.Props.Width = perevesti("455", True)
����10������_��������10.Props.Visible = perevesti("��", True)
����10������_��������10.Props.Height = perevesti("27", True)
����10������_��������10.Props.Width = perevesti("455", True)
����10������_��������10.Props.Value = perevesti("0", True)

ProgressForm.ProgressBar1.Value = 75
����10��������������0.Props.Text = perevesti("0%", True)
����10��������������0.Props.X = perevesti("532", True)
����10��������������0.Props.Y = perevesti("320", True)
����10��������������0.Props.Autoellipsis = perevesti("��", True)
����10��������������0.Props.Contextmenu(True) = perevesti("�������", True)
����10��������������0.Props.Tag = perevesti("", True)
����10��������������0.Props.Name = perevesti("��������������", True)
����10��������������0.Props.Cursor = perevesti("�������", True)
����10��������������0.Props.Maximumheight = perevesti("0", True)
����10��������������0.Props.Maximumwidth = perevesti("0", True)
����10��������������0.Props.Minimumheight = perevesti("0", True)
����10��������������0.Props.Minimumwidth = perevesti("0", True)
����10��������������0.Props.Index = perevesti("0", True)
����10��������������0.Props.ToolTip = perevesti("", True)
����10��������������0.Props.Paddingtop = perevesti("0", True)
����10��������������0.Props.Paddingleft = perevesti("0", True)
����10��������������0.Props.Paddingbottom = perevesti("0", True)
����10��������������0.Props.Paddingright = perevesti("0", True)
����10��������������0.Props.Imagealign = perevesti("�����", True)
����10��������������0.Props.Textalign = perevesti("�����", True)
����10��������������0.Props.Anchor = perevesti("�����_������", True)
����10��������������0.Props.Enabled = perevesti("��", True)
����10��������������0.Props.Dock = perevesti("�������", True)
����10��������������0.Props.Image = perevesti("�������", True)
����10��������������0.Props.Borderstyle = perevesti("�������", True)
����10��������������0.Props.Backgroundimagelayout = perevesti("������", True)
����10��������������0.Props.Tabindex = perevesti("0", True)
����10��������������0.Props.Tabstop = perevesti("��", True)
����10��������������0.Props.Backgroundimage = perevesti("�������", True)
����10��������������0.Props.Backcolor = perevesti("240; 240; 240;", True)
����10��������������0.Props.Forecolor = perevesti("������", True)
����10��������������0.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10��������������0.Props.Fontbold = perevesti("���", True)
����10��������������0.Props.Fontstrikeout = perevesti("���", True)
����10��������������0.Props.Fontitalic = perevesti("���", True)
����10��������������0.Props.Fontunderline = perevesti("���", True)
����10��������������0.Props.Fontsize = perevesti("8", True)
����10��������������0.Props.Height = perevesti("31", True)
����10��������������0.Props.Width = perevesti("59", True)
����10��������������0.Props.Visible = perevesti("��", True)
����10��������������0.Props.Height = perevesti("31", True)
����10��������������0.Props.Width = perevesti("59", True)

ProgressForm.ProgressBar1.Value = 77
����10�������10.Props.X = perevesti("24", True)
����10�������10.Props.Y = perevesti("56", True)
����10�������10.Props.Contextmenu(True) = perevesti("�������", True)
����10�������10.Props.Tag = perevesti("", True)
����10�������10.Props.Name = perevesti("�������1", True)
����10�������10.Props.Cursor = perevesti("�������", True)
����10�������10.Props.Maximumheight = perevesti("0", True)
����10�������10.Props.Maximumwidth = perevesti("0", True)
����10�������10.Props.Minimumheight = perevesti("0", True)
����10�������10.Props.Minimumwidth = perevesti("0", True)
����10�������10.Props.Index = perevesti("0", True)
����10�������10.Props.ToolTip = perevesti("", True)
����10�������10.Props.Anchor = perevesti("�����_������", True)
����10�������10.Props.Enabled = perevesti("��", True)
����10�������10.Props.Dock = perevesti("�������", True)
����10�������10.Props.Image = perevesti("�������\�������8.png", True)
����10�������10.Props.Borderstyle = perevesti("�������", True)
����10�������10.Props.Sizemode = perevesti("�� ���������", True)
����10�������10.Props.Backgroundimagelayout = perevesti("������", True)
����10�������10.Props.Tabindex = perevesti("0", True)
����10�������10.Props.Tabstop = perevesti("��", True)
����10�������10.Props.Backgroundimage = perevesti("�������", True)
����10�������10.Props.Backcolor = perevesti("172; 172; 172;", True)
����10�������10.Props.Height = perevesti("267", True)
����10�������10.Props.Width = perevesti("359", True)
����10�������10.Props.Visible = perevesti("��", True)
����10�������10.Props.Height = perevesti("267", True)
����10�������10.Props.Width = perevesti("359", True)

ProgressForm.ProgressBar1.Value = 79
_��������_�������0_��������_�������0.Props.Name = "_�������� �������"

ProgressForm.ProgressBar1.Value = 81
_��������_�������0_�����0.Props.Name = "_�����"

ProgressForm.ProgressBar1.Value = 83
_��������_�������0_�����_�_�����0.Props.Name = "_����� � �����"

ProgressForm.ProgressBar1.Value = 85
_��������_�������0_����������0.Props.Name = "_����������"

ProgressForm.ProgressBar1.Value = 87
_��������_�������0_�������0.Props.Name = "_�������"

ProgressForm.ProgressBar1.Value = 89
_��������_�������0_������0.Props.Name = "_������"

ProgressForm.ProgressBar1.Value = 91
_��������_�������0_�������_�������0.Props.Name = "_������� �������"

ProgressForm.ProgressBar1.Value = 92
_��������_�������0_�����0.Props.Name = "_�����"

ProgressForm.ProgressBar1.Value = 94
_��������_�������0_��������_���������0.Props.Name = "_�������� ���������"

ProgressForm.ProgressBar1.Value = 96
_��������_�������0_����0.Props.Name = "_����"

ProgressForm.ProgressBar1.Value = 98
_��������_�������0_�����������_�����������0.Props.Name = "_����������� �����������"


' ������������� ��������
����10����10.load()
����10��������10.load()
����10����_����������10.load()
����10��������10.load()
����10�������10.load()
����10�������20.load()
����10������_10.load()
����10�������30.load()
����10�������40.load()
����10�������50.load()
����10��������1_��������10.load()
����10��������1_��������20.load()
����10�������������0.load()
����10��������������0.load()
����10�����������0.load()
����10������_��������10.load()
����10��������������0.load()
����10�������10.load()

RunProj.GetAllObjects()
RunProj.isINITIALIZATED = False

����10��������10.RaiseCreate()
����10����_����������10.RaiseCreate()
����10��������10.RaiseCreate()
����10�������10.RaiseCreate()
����10�������20.RaiseCreate()
����10������_10.RaiseCreate()
����10�������30.RaiseCreate()
����10�������40.RaiseCreate()
����10�������50.RaiseCreate()
����10��������1_��������10.RaiseCreate()
����10��������1_��������20.RaiseCreate()
����10�������������0.RaiseCreate()
����10��������������0.RaiseCreate()
����10�����������0.RaiseCreate()
����10������_��������10.RaiseCreate()
����10��������������0.RaiseCreate()
����10�������10.RaiseCreate()
����10����10.RaiseCreate()

ProgressForm.Hide()
    End Sub

' ������������ �������
Public Sub ����10����10_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10����10.Disposed
    If DaOrNet(����10����10.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub ����10����10_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles ����10����10.FormClosing
    If DaOrNet(����10����10.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(����10����10.Props.MainForm) = UCase(trans("��")) Or proj.isCLOSING Then
        ����10����10.Hide() : Application.Exit()
    Else
        e.Cancel = True : ����10����10.Hide()
    End If
End Sub

Public Sub _��������_�������0_��������_�������0_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles _��������_�������0_��������_�������0.Disposed
    If DaOrNet(_��������_�������0_��������_�������0.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub _��������_�������0_��������_�������0_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles _��������_�������0_��������_�������0.FormClosing
    If DaOrNet(_��������_�������0_��������_�������0.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(_��������_�������0_��������_�������0.Props.MainForm) = UCase(trans("��")) Or proj.isCLOSING Then
        _��������_�������0_��������_�������0.Hide() : Application.Exit()
    Else
        e.Cancel = True : _��������_�������0_��������_�������0.Hide()
    End If
End Sub



' ��� �������
Public Sub ����10��������10_Receivedresponse(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10��������10.Receivedresponse
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10��������10.MyObj, e, nothing,"������ �����")

RunProj.GetObjFromUniqName("_�������� �������._����� � �����").Props.Move ( RunProj.GetObjFromUniqName ( "����1.��������1" ) .Props.Resultquery , RunProj.GetObjFromUniqName ( "����1.���� ����������1" ) .Props.Filename ) 
RunProj.GetObjFromUniqName("_�������� �������._����� � �����").Props.Opendirectory ( RunProj.GetObjFromUniqName ( "����1.���� ����������1" ) .Props.Filename ) 
CurrentEvent.Zavershit()
End Sub


Public Sub ����10��������10_Receiveprogress(ByVal sender As Object, ByVal e As WinsockReceiveProgressEventArgs) Handles ����10��������10.Receiveprogress
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10��������10.MyObj, e, nothing,"���� ����� ������")

RunProj.GetObjFromUniqName("����1.��������������").Props.Text = CurrentEvent.ParamyUp(MyZnak & "������� �����������") & "%"
RunProj.GetObjFromUniqName("����1.������ ��������1").Props.Value = CurrentEvent.ParamyUp(MyZnak & "������� �����������")
CurrentEvent.Zavershit()
End Sub


Public Sub ����10��������10_Downloadcancelled(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10��������10.Downloadcancelled
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10��������10.MyObj, e, nothing,"�������� ��������")

RunProj.GetObjFromUniqName("����1.��������������").Props.Text = "0%"
RunProj.GetObjFromUniqName("����1.������ ��������1").Props.Value = "0"
CurrentEvent.Zavershit()
End Sub


Public Sub ����10�������������0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10�������������0.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10�������������0.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����1.��������1").Props.Downloadfile ( "http://algoritm2.ru/download.php?d=2547" , "���" ) 
RunProj.GetObjFromUniqName("����1.���� ����������1").Props.Filename = RunProj.GetObjFromUniqName("_�������� �������._����� � �����").Props.Getfilename ( RunProj.GetObjFromUniqName ( "����1.��������1" ) .Props.Urltogo ) 
RunProj.GetObjFromUniqName("����1.���� ����������1").Props.Showdialog
If returnBoolean( UCase( RunProj.GetObjFromUniqName("����1.���� ����������1" ).Props.Wascancel )  =  UCase( "��" )  ) Then
����10��������������0_Click(����10��������������0, nothing)

End If
CurrentEvent.Zavershit()
End Sub


Public Sub ����10��������������0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10��������������0.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10��������������0.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����1.��������1").Props.Downloadcancel
CurrentEvent.Zavershit()
End Sub


Public Sub ����10�����������0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10�����������0.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10�����������0.MyObj, e, nothing,"����")

If returnBoolean( UCase( RunProj.GetObjFromUniqName("����1.�����������" ).Props.Text )  =  UCase( "�����" )  ) Then
RunProj.GetObjFromUniqName("����1.��������1").Props.Downloadpause = "��"
RunProj.GetObjFromUniqName("����1.�����������").Props.Text = "�����������"
Else
RunProj.GetObjFromUniqName("����1.��������1").Props.Downloadpause = "���"
RunProj.GetObjFromUniqName("����1.�����������").Props.Text = "�����"
End If
CurrentEvent.Zavershit()
End Sub



End Module



