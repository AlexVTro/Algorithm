Module CodeAlg

Public WithEvents ����10����10 As New runF
Public WithEvents ����10�������72 As New runLb
Public WithEvents ����10������_10 As New runP
Public WithEvents ����10�����10 As New runT
Public WithEvents ����10�����20 As New runT
Public WithEvents ����10�����30 As New runT
Public WithEvents ����10�����40 As New runT
Public WithEvents ����10�����50 As New runT
Public WithEvents ����10�����60 As New runT
Public WithEvents ����10������10 As New runB
Public WithEvents ����10�������73 As New runLb
Public WithEvents ����10�������74 As New runLb
Public WithEvents ����10�������75 As New runLb
Public WithEvents ����10�������76 As New runLb
Public WithEvents ����10�������77 As New runLb
Public WithEvents ����10�����70 As New runT
Public WithEvents ����10�������71 As New runLb
Public WithEvents ����10������20 As New runB
Public WithEvents ����10������30 As New runB
Public WithEvents ����10����_��������10 As New runOD
Public WithEvents ����20����20 As New runF
Public WithEvents ����20�������10 As New runPb
Public WithEvents ����20������10 As New runB
Public WithEvents ����20������20 As New runB
Public WithEvents ����20�����10 As New runT
Public WithEvents ����20����_��������10 As New runOD
Public WithEvents ����30����30 As New runF
Public WithEvents ����30���������_��������10 As New runRT
Public WithEvents ����30������10 As New runB
Public WithEvents ����30������20 As New runB
Public WithEvents ����30�����10 As New runT
Public WithEvents ����30����_��������10 As New runOD
Public WithEvents ����30������30 As New runB
Public WithEvents ����40����40 As New runF
Public WithEvents ����40���������_��������10 As New runRT
Public WithEvents ����40������10 As New runB
Public WithEvents ����40������20 As New runB
Public WithEvents ����40������10 As New runM
Public WithEvents ����40������20 As New runM
Public WithEvents ����40������30 As New runM
Public WithEvents ����40����_����������10 As New runSD
Public WithEvents ����40�������10 As New runLb
Public WithEvents ����50����50 As New runF
Public WithEvents ����50���������_��������10 As New runRT
Public WithEvents ����50������10 As New runB
Public WithEvents ����50����_����������10 As New runSD
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
RunProj.iPathShort = "image"
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

����10�������72.MyObj = New Label(True, True)
����10�������72.MyObj.proj = proj
����10�������72.MyObj.obj = ����10�������72
����10�������72.MyObj.VBname = "����10�������72"
����10�������72.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������72.MyObj.MyForm.MyObjs) : ����10�������72.MyObj.MyForm.MyObjs(����10�������72.MyObj.MyForm.MyObjs.Length - 1) = ����10�������72.MyObj

����10������_10.MyObj = New Panel(True, True)
����10������_10.MyObj.proj = proj
����10������_10.MyObj.obj = ����10������_10
����10������_10.MyObj.VBname = "����10������_10"
����10������_10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10������_10.MyObj.MyForm.MyObjs) : ����10������_10.MyObj.MyForm.MyObjs(����10������_10.MyObj.MyForm.MyObjs.Length - 1) = ����10������_10.MyObj

����10�����10.MyObj = New TextBoks(True, True)
����10�����10.MyObj.proj = proj
����10�����10.MyObj.obj = ����10�����10
����10�����10.MyObj.VBname = "����10�����10"
����10�����10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�����10.MyObj.MyForm.MyObjs) : ����10�����10.MyObj.MyForm.MyObjs(����10�����10.MyObj.MyForm.MyObjs.Length - 1) = ����10�����10.MyObj

����10�����20.MyObj = New TextBoks(True, True)
����10�����20.MyObj.proj = proj
����10�����20.MyObj.obj = ����10�����20
����10�����20.MyObj.VBname = "����10�����20"
����10�����20.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�����20.MyObj.MyForm.MyObjs) : ����10�����20.MyObj.MyForm.MyObjs(����10�����20.MyObj.MyForm.MyObjs.Length - 1) = ����10�����20.MyObj

ProgressForm.ProgressBar1.Value = 2
����10�����30.MyObj = New TextBoks(True, True)
����10�����30.MyObj.proj = proj
����10�����30.MyObj.obj = ����10�����30
����10�����30.MyObj.VBname = "����10�����30"
����10�����30.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�����30.MyObj.MyForm.MyObjs) : ����10�����30.MyObj.MyForm.MyObjs(����10�����30.MyObj.MyForm.MyObjs.Length - 1) = ����10�����30.MyObj

����10�����40.MyObj = New TextBoks(True, True)
����10�����40.MyObj.proj = proj
����10�����40.MyObj.obj = ����10�����40
����10�����40.MyObj.VBname = "����10�����40"
����10�����40.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�����40.MyObj.MyForm.MyObjs) : ����10�����40.MyObj.MyForm.MyObjs(����10�����40.MyObj.MyForm.MyObjs.Length - 1) = ����10�����40.MyObj

����10�����50.MyObj = New TextBoks(True, True)
����10�����50.MyObj.proj = proj
����10�����50.MyObj.obj = ����10�����50
����10�����50.MyObj.VBname = "����10�����50"
����10�����50.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�����50.MyObj.MyForm.MyObjs) : ����10�����50.MyObj.MyForm.MyObjs(����10�����50.MyObj.MyForm.MyObjs.Length - 1) = ����10�����50.MyObj

����10�����60.MyObj = New TextBoks(True, True)
����10�����60.MyObj.proj = proj
����10�����60.MyObj.obj = ����10�����60
����10�����60.MyObj.VBname = "����10�����60"
����10�����60.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�����60.MyObj.MyForm.MyObjs) : ����10�����60.MyObj.MyForm.MyObjs(����10�����60.MyObj.MyForm.MyObjs.Length - 1) = ����10�����60.MyObj

����10������10.MyObj = New Button(True, True)
����10������10.MyObj.proj = proj
����10������10.MyObj.obj = ����10������10
����10������10.MyObj.VBname = "����10������10"
����10������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10������10.MyObj.MyForm.MyObjs) : ����10������10.MyObj.MyForm.MyObjs(����10������10.MyObj.MyForm.MyObjs.Length - 1) = ����10������10.MyObj

ProgressForm.ProgressBar1.Value = 4
����10�������73.MyObj = New Label(True, True)
����10�������73.MyObj.proj = proj
����10�������73.MyObj.obj = ����10�������73
����10�������73.MyObj.VBname = "����10�������73"
����10�������73.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������73.MyObj.MyForm.MyObjs) : ����10�������73.MyObj.MyForm.MyObjs(����10�������73.MyObj.MyForm.MyObjs.Length - 1) = ����10�������73.MyObj

����10�������74.MyObj = New Label(True, True)
����10�������74.MyObj.proj = proj
����10�������74.MyObj.obj = ����10�������74
����10�������74.MyObj.VBname = "����10�������74"
����10�������74.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������74.MyObj.MyForm.MyObjs) : ����10�������74.MyObj.MyForm.MyObjs(����10�������74.MyObj.MyForm.MyObjs.Length - 1) = ����10�������74.MyObj

����10�������75.MyObj = New Label(True, True)
����10�������75.MyObj.proj = proj
����10�������75.MyObj.obj = ����10�������75
����10�������75.MyObj.VBname = "����10�������75"
����10�������75.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������75.MyObj.MyForm.MyObjs) : ����10�������75.MyObj.MyForm.MyObjs(����10�������75.MyObj.MyForm.MyObjs.Length - 1) = ����10�������75.MyObj

����10�������76.MyObj = New Label(True, True)
����10�������76.MyObj.proj = proj
����10�������76.MyObj.obj = ����10�������76
����10�������76.MyObj.VBname = "����10�������76"
����10�������76.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������76.MyObj.MyForm.MyObjs) : ����10�������76.MyObj.MyForm.MyObjs(����10�������76.MyObj.MyForm.MyObjs.Length - 1) = ����10�������76.MyObj

����10�������77.MyObj = New Label(True, True)
����10�������77.MyObj.proj = proj
����10�������77.MyObj.obj = ����10�������77
����10�������77.MyObj.VBname = "����10�������77"
����10�������77.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������77.MyObj.MyForm.MyObjs) : ����10�������77.MyObj.MyForm.MyObjs(����10�������77.MyObj.MyForm.MyObjs.Length - 1) = ����10�������77.MyObj

ProgressForm.ProgressBar1.Value = 7
����10�����70.MyObj = New TextBoks(True, True)
����10�����70.MyObj.proj = proj
����10�����70.MyObj.obj = ����10�����70
����10�����70.MyObj.VBname = "����10�����70"
����10�����70.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�����70.MyObj.MyForm.MyObjs) : ����10�����70.MyObj.MyForm.MyObjs(����10�����70.MyObj.MyForm.MyObjs.Length - 1) = ����10�����70.MyObj

����10�������71.MyObj = New Label(True, True)
����10�������71.MyObj.proj = proj
����10�������71.MyObj.obj = ����10�������71
����10�������71.MyObj.VBname = "����10�������71"
����10�������71.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10�������71.MyObj.MyForm.MyObjs) : ����10�������71.MyObj.MyForm.MyObjs(����10�������71.MyObj.MyForm.MyObjs.Length - 1) = ����10�������71.MyObj

����10������20.MyObj = New Button(True, True)
����10������20.MyObj.proj = proj
����10������20.MyObj.obj = ����10������20
����10������20.MyObj.VBname = "����10������20"
����10������20.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10������20.MyObj.MyForm.MyObjs) : ����10������20.MyObj.MyForm.MyObjs(����10������20.MyObj.MyForm.MyObjs.Length - 1) = ����10������20.MyObj

����10������30.MyObj = New Button(True, True)
����10������30.MyObj.proj = proj
����10������30.MyObj.obj = ����10������30
����10������30.MyObj.VBname = "����10������30"
����10������30.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10������30.MyObj.MyForm.MyObjs) : ����10������30.MyObj.MyForm.MyObjs(����10������30.MyObj.MyForm.MyObjs.Length - 1) = ����10������30.MyObj

����10����_��������10.MyObj = New OpenDialog(True, True)
����10����_��������10.MyObj.proj = proj
����10����_��������10.MyObj.obj = ����10����_��������10
����10����_��������10.MyObj.VBname = "����10����_��������10"
����10����_��������10.MyObj.MyObj.MyForm = ����10����10.MyObj
ReDimsO(����10����_��������10.MyObj.MyForm.MyObjs) : ����10����_��������10.MyObj.MyForm.MyObjs(����10����_��������10.MyObj.MyForm.MyObjs.Length - 1) = ����10����_��������10.MyObj

ProgressForm.ProgressBar1.Value = 9
����20����20.MyObj = New Forms(True, , True)
����20����20.MyObj.proj = proj
����20����20.MyObj.obj = ����20����20
����20����20.MyObj.VBname = "����20����20"
����20����20.MyObj.MyObj.MyForm = ����20����20.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = ����20����20.MyObj
ReDimsO(����20����20.MyObj.MyForm.MyObjs) : ����20����20.MyObj.MyForm.MyObjs(����20����20.MyObj.MyForm.MyObjs.Length - 1) = ����20����20.MyObj

����20�������10.MyObj = New PictureBoks(True, True)
����20�������10.MyObj.proj = proj
����20�������10.MyObj.obj = ����20�������10
����20�������10.MyObj.VBname = "����20�������10"
����20�������10.MyObj.MyObj.MyForm = ����20����20.MyObj
ReDimsO(����20�������10.MyObj.MyForm.MyObjs) : ����20�������10.MyObj.MyForm.MyObjs(����20�������10.MyObj.MyForm.MyObjs.Length - 1) = ����20�������10.MyObj

����20������10.MyObj = New Button(True, True)
����20������10.MyObj.proj = proj
����20������10.MyObj.obj = ����20������10
����20������10.MyObj.VBname = "����20������10"
����20������10.MyObj.MyObj.MyForm = ����20����20.MyObj
ReDimsO(����20������10.MyObj.MyForm.MyObjs) : ����20������10.MyObj.MyForm.MyObjs(����20������10.MyObj.MyForm.MyObjs.Length - 1) = ����20������10.MyObj

����20������20.MyObj = New Button(True, True)
����20������20.MyObj.proj = proj
����20������20.MyObj.obj = ����20������20
����20������20.MyObj.VBname = "����20������20"
����20������20.MyObj.MyObj.MyForm = ����20����20.MyObj
ReDimsO(����20������20.MyObj.MyForm.MyObjs) : ����20������20.MyObj.MyForm.MyObjs(����20������20.MyObj.MyForm.MyObjs.Length - 1) = ����20������20.MyObj

����20�����10.MyObj = New TextBoks(True, True)
����20�����10.MyObj.proj = proj
����20�����10.MyObj.obj = ����20�����10
����20�����10.MyObj.VBname = "����20�����10"
����20�����10.MyObj.MyObj.MyForm = ����20����20.MyObj
ReDimsO(����20�����10.MyObj.MyForm.MyObjs) : ����20�����10.MyObj.MyForm.MyObjs(����20�����10.MyObj.MyForm.MyObjs.Length - 1) = ����20�����10.MyObj

ProgressForm.ProgressBar1.Value = 11
����20����_��������10.MyObj = New OpenDialog(True, True)
����20����_��������10.MyObj.proj = proj
����20����_��������10.MyObj.obj = ����20����_��������10
����20����_��������10.MyObj.VBname = "����20����_��������10"
����20����_��������10.MyObj.MyObj.MyForm = ����20����20.MyObj
ReDimsO(����20����_��������10.MyObj.MyForm.MyObjs) : ����20����_��������10.MyObj.MyForm.MyObjs(����20����_��������10.MyObj.MyForm.MyObjs.Length - 1) = ����20����_��������10.MyObj

����30����30.MyObj = New Forms(True, , True)
����30����30.MyObj.proj = proj
����30����30.MyObj.obj = ����30����30
����30����30.MyObj.VBname = "����30����30"
����30����30.MyObj.MyObj.MyForm = ����30����30.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = ����30����30.MyObj
ReDimsO(����30����30.MyObj.MyForm.MyObjs) : ����30����30.MyObj.MyForm.MyObjs(����30����30.MyObj.MyForm.MyObjs.Length - 1) = ����30����30.MyObj

����30���������_��������10.MyObj = New RichText(True, True)
����30���������_��������10.MyObj.proj = proj
����30���������_��������10.MyObj.obj = ����30���������_��������10
����30���������_��������10.MyObj.VBname = "����30���������_��������10"
����30���������_��������10.MyObj.MyObj.MyForm = ����30����30.MyObj
ReDimsO(����30���������_��������10.MyObj.MyForm.MyObjs) : ����30���������_��������10.MyObj.MyForm.MyObjs(����30���������_��������10.MyObj.MyForm.MyObjs.Length - 1) = ����30���������_��������10.MyObj

����30������10.MyObj = New Button(True, True)
����30������10.MyObj.proj = proj
����30������10.MyObj.obj = ����30������10
����30������10.MyObj.VBname = "����30������10"
����30������10.MyObj.MyObj.MyForm = ����30����30.MyObj
ReDimsO(����30������10.MyObj.MyForm.MyObjs) : ����30������10.MyObj.MyForm.MyObjs(����30������10.MyObj.MyForm.MyObjs.Length - 1) = ����30������10.MyObj

����30������20.MyObj = New Button(True, True)
����30������20.MyObj.proj = proj
����30������20.MyObj.obj = ����30������20
����30������20.MyObj.VBname = "����30������20"
����30������20.MyObj.MyObj.MyForm = ����30����30.MyObj
ReDimsO(����30������20.MyObj.MyForm.MyObjs) : ����30������20.MyObj.MyForm.MyObjs(����30������20.MyObj.MyForm.MyObjs.Length - 1) = ����30������20.MyObj

ProgressForm.ProgressBar1.Value = 13
����30�����10.MyObj = New TextBoks(True, True)
����30�����10.MyObj.proj = proj
����30�����10.MyObj.obj = ����30�����10
����30�����10.MyObj.VBname = "����30�����10"
����30�����10.MyObj.MyObj.MyForm = ����30����30.MyObj
ReDimsO(����30�����10.MyObj.MyForm.MyObjs) : ����30�����10.MyObj.MyForm.MyObjs(����30�����10.MyObj.MyForm.MyObjs.Length - 1) = ����30�����10.MyObj

����30����_��������10.MyObj = New OpenDialog(True, True)
����30����_��������10.MyObj.proj = proj
����30����_��������10.MyObj.obj = ����30����_��������10
����30����_��������10.MyObj.VBname = "����30����_��������10"
����30����_��������10.MyObj.MyObj.MyForm = ����30����30.MyObj
ReDimsO(����30����_��������10.MyObj.MyForm.MyObjs) : ����30����_��������10.MyObj.MyForm.MyObjs(����30����_��������10.MyObj.MyForm.MyObjs.Length - 1) = ����30����_��������10.MyObj

����30������30.MyObj = New Button(True, True)
����30������30.MyObj.proj = proj
����30������30.MyObj.obj = ����30������30
����30������30.MyObj.VBname = "����30������30"
����30������30.MyObj.MyObj.MyForm = ����30����30.MyObj
ReDimsO(����30������30.MyObj.MyForm.MyObjs) : ����30������30.MyObj.MyForm.MyObjs(����30������30.MyObj.MyForm.MyObjs.Length - 1) = ����30������30.MyObj

����40����40.MyObj = New Forms(True, , True)
����40����40.MyObj.proj = proj
����40����40.MyObj.obj = ����40����40
����40����40.MyObj.VBname = "����40����40"
����40����40.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = ����40����40.MyObj
ReDimsO(����40����40.MyObj.MyForm.MyObjs) : ����40����40.MyObj.MyForm.MyObjs(����40����40.MyObj.MyForm.MyObjs.Length - 1) = ����40����40.MyObj

����40���������_��������10.MyObj = New RichText(True, True)
����40���������_��������10.MyObj.proj = proj
����40���������_��������10.MyObj.obj = ����40���������_��������10
����40���������_��������10.MyObj.VBname = "����40���������_��������10"
����40���������_��������10.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDimsO(����40���������_��������10.MyObj.MyForm.MyObjs) : ����40���������_��������10.MyObj.MyForm.MyObjs(����40���������_��������10.MyObj.MyForm.MyObjs.Length - 1) = ����40���������_��������10.MyObj

ProgressForm.ProgressBar1.Value = 15
����40������10.MyObj = New Button(True, True)
����40������10.MyObj.proj = proj
����40������10.MyObj.obj = ����40������10
����40������10.MyObj.VBname = "����40������10"
����40������10.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDimsO(����40������10.MyObj.MyForm.MyObjs) : ����40������10.MyObj.MyForm.MyObjs(����40������10.MyObj.MyForm.MyObjs.Length - 1) = ����40������10.MyObj

����40������20.MyObj = New Button(True, True)
����40������20.MyObj.proj = proj
����40������20.MyObj.obj = ����40������20
����40������20.MyObj.VBname = "����40������20"
����40������20.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDimsO(����40������20.MyObj.MyForm.MyObjs) : ����40������20.MyObj.MyForm.MyObjs(����40������20.MyObj.MyForm.MyObjs.Length - 1) = ����40������20.MyObj

����40������10.MyObj = New Memory(True, True)
����40������10.MyObj.proj = proj
����40������10.MyObj.obj = ����40������10
����40������10.MyObj.VBname = "����40������10"
����40������10.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDimsO(����40������10.MyObj.MyForm.MyObjs) : ����40������10.MyObj.MyForm.MyObjs(����40������10.MyObj.MyForm.MyObjs.Length - 1) = ����40������10.MyObj

����40������20.MyObj = New Memory(True, True)
����40������20.MyObj.proj = proj
����40������20.MyObj.obj = ����40������20
����40������20.MyObj.VBname = "����40������20"
����40������20.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDimsO(����40������20.MyObj.MyForm.MyObjs) : ����40������20.MyObj.MyForm.MyObjs(����40������20.MyObj.MyForm.MyObjs.Length - 1) = ����40������20.MyObj

����40������30.MyObj = New Memory(True, True)
����40������30.MyObj.proj = proj
����40������30.MyObj.obj = ����40������30
����40������30.MyObj.VBname = "����40������30"
����40������30.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDimsO(����40������30.MyObj.MyForm.MyObjs) : ����40������30.MyObj.MyForm.MyObjs(����40������30.MyObj.MyForm.MyObjs.Length - 1) = ����40������30.MyObj

ProgressForm.ProgressBar1.Value = 18
����40����_����������10.MyObj = New SaveDialog(True, True)
����40����_����������10.MyObj.proj = proj
����40����_����������10.MyObj.obj = ����40����_����������10
����40����_����������10.MyObj.VBname = "����40����_����������10"
����40����_����������10.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDimsO(����40����_����������10.MyObj.MyForm.MyObjs) : ����40����_����������10.MyObj.MyForm.MyObjs(����40����_����������10.MyObj.MyForm.MyObjs.Length - 1) = ����40����_����������10.MyObj

����40�������10.MyObj = New Label(True, True)
����40�������10.MyObj.proj = proj
����40�������10.MyObj.obj = ����40�������10
����40�������10.MyObj.VBname = "����40�������10"
����40�������10.MyObj.MyObj.MyForm = ����40����40.MyObj
ReDimsO(����40�������10.MyObj.MyForm.MyObjs) : ����40�������10.MyObj.MyForm.MyObjs(����40�������10.MyObj.MyForm.MyObjs.Length - 1) = ����40�������10.MyObj

����50����50.MyObj = New Forms(True, , True)
����50����50.MyObj.proj = proj
����50����50.MyObj.obj = ����50����50
����50����50.MyObj.VBname = "����50����50"
����50����50.MyObj.MyObj.MyForm = ����50����50.MyObj
ReDims(RunProj.f) : RunProj.f(RunProj.f.Length - 1) = ����50����50.MyObj
ReDimsO(����50����50.MyObj.MyForm.MyObjs) : ����50����50.MyObj.MyForm.MyObjs(����50����50.MyObj.MyForm.MyObjs.Length - 1) = ����50����50.MyObj

����50���������_��������10.MyObj = New RichText(True, True)
����50���������_��������10.MyObj.proj = proj
����50���������_��������10.MyObj.obj = ����50���������_��������10
����50���������_��������10.MyObj.VBname = "����50���������_��������10"
����50���������_��������10.MyObj.MyObj.MyForm = ����50����50.MyObj
ReDimsO(����50���������_��������10.MyObj.MyForm.MyObjs) : ����50���������_��������10.MyObj.MyForm.MyObjs(����50���������_��������10.MyObj.MyForm.MyObjs.Length - 1) = ����50���������_��������10.MyObj

����50������10.MyObj = New Button(True, True)
����50������10.MyObj.proj = proj
����50������10.MyObj.obj = ����50������10
����50������10.MyObj.VBname = "����50������10"
����50������10.MyObj.MyObj.MyForm = ����50����50.MyObj
ReDimsO(����50������10.MyObj.MyForm.MyObjs) : ����50������10.MyObj.MyForm.MyObjs(����50������10.MyObj.MyForm.MyObjs.Length - 1) = ����50������10.MyObj

ProgressForm.ProgressBar1.Value = 20
����50����_����������10.MyObj = New SaveDialog(True, True)
����50����_����������10.MyObj.proj = proj
����50����_����������10.MyObj.obj = ����50����_����������10
����50����_����������10.MyObj.VBname = "����50����_����������10"
����50����_����������10.MyObj.MyObj.MyForm = ����50����50.MyObj
ReDimsO(����50����_����������10.MyObj.MyForm.MyObjs) : ����50����_����������10.MyObj.MyForm.MyObjs(����50����_����������10.MyObj.MyForm.MyObjs.Length - 1) = ����50����_����������10.MyObj

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

ProgressForm.ProgressBar1.Value = 22
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

ProgressForm.ProgressBar1.Value = 24
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
����10����10.Controls.Add(����10�������72)
����10����10.Controls.Add(����10������_10)
����10����10.Controls.Add(����10�����10)
����10������_10.Controls.Add(����10�����20)
ProgressForm.ProgressBar1.Value = 26
����10������_10.Controls.Add(����10�����30)
����10������_10.Controls.Add(����10�����40)
����10������_10.Controls.Add(����10�����50)
����10������_10.Controls.Add(����10�����60)
����10����10.Controls.Add(����10������10)
ProgressForm.ProgressBar1.Value = 27
����10������_10.Controls.Add(����10�������73)
����10������_10.Controls.Add(����10�������74)
����10������_10.Controls.Add(����10�������75)
����10������_10.Controls.Add(����10�������76)
����10������_10.Controls.Add(����10�������77)
ProgressForm.ProgressBar1.Value = 28
����10����10.Controls.Add(����10�����70)
����10����10.Controls.Add(����10�������71)
����10����10.Controls.Add(����10������20)
����10����10.Controls.Add(����10������30)
ProgressForm.ProgressBar1.Value = 29
����20����20.Controls.Add(����20�������10)
����20����20.Controls.Add(����20������10)
����20����20.Controls.Add(����20������20)
����20����20.Controls.Add(����20�����10)
ProgressForm.ProgressBar1.Value = 29
����30����30.Controls.Add(����30���������_��������10)
����30����30.Controls.Add(����30������10)
����30����30.Controls.Add(����30������20)
ProgressForm.ProgressBar1.Value = 30
����30����30.Controls.Add(����30�����10)
����30����30.Controls.Add(����30������30)
����40����40.Controls.Add(����40���������_��������10)
ProgressForm.ProgressBar1.Value = 31
����40����40.Controls.Add(����40������10)
����40����40.Controls.Add(����40������20)
ProgressForm.ProgressBar1.Value = 32
����40����40.Controls.Add(����40�������10)
����50����50.Controls.Add(����50���������_��������10)
����50����50.Controls.Add(����50������10)
ProgressForm.ProgressBar1.Value = 33
ProgressForm.ProgressBar1.Value = 34
ProgressForm.ProgressBar1.Value = 35


' �������� �� ������� �������
ProgressForm.ProgressBar1.Value = 35
����10������_10.BringToFront()
����10�����10.BringToFront()
����10�������72.BringToFront()
����10�������73.BringToFront()
����10�����20.BringToFront()
����10�������74.BringToFront()
����10�����30.BringToFront()
����10�������75.BringToFront()
����10�����40.BringToFront()
����10�������76.BringToFront()
����10�����50.BringToFront()
����10�������77.BringToFront()
����10�����60.BringToFront()
����10������10.BringToFront()
����10�����70.BringToFront()
����10�������71.BringToFront()
����10������20.BringToFront()
����10������30.BringToFront()
����10����_��������10.BringToFront()
ProgressForm.ProgressBar1.Value = 36
ProgressForm.ProgressBar1.Value = 37
ProgressForm.ProgressBar1.Value = 38
ProgressForm.ProgressBar1.Value = 39
����20�������10.BringToFront()
����20������10.BringToFront()
����20������20.BringToFront()
����20�����10.BringToFront()
����20����_��������10.BringToFront()
ProgressForm.ProgressBar1.Value = 39
����30���������_��������10.BringToFront()
����30������10.BringToFront()
����30������20.BringToFront()
����30�����10.BringToFront()
����30����_��������10.BringToFront()
����30������30.BringToFront()
ProgressForm.ProgressBar1.Value = 40
����40���������_��������10.BringToFront()
����40������10.BringToFront()
����40������20.BringToFront()
����40������10.BringToFront()
����40������20.BringToFront()
����40������30.BringToFront()
����40����_����������10.BringToFront()
����40�������10.BringToFront()
ProgressForm.ProgressBar1.Value = 41
ProgressForm.ProgressBar1.Value = 42
����50���������_��������10.BringToFront()
����50������10.BringToFront()
����50����_����������10.BringToFront()
ProgressForm.ProgressBar1.Value = 43
ProgressForm.ProgressBar1.Value = 44
ProgressForm.ProgressBar1.Value = 45


' ��������� ������� ��������
ProgressForm.ProgressBar1.Value = 45
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
����10����10.Props.Showintray = perevesti("���", True)
����10����10.Props.TopMost = perevesti("���", True)
����10����10.Props.ToolTip = perevesti("", True)
����10����10.Props.Showicon = perevesti("���", True)
����10����10.Props.Opacity = perevesti("100", True)
����10����10.Props.Transparentcykey = perevesti("�������", True)
����10����10.Props.Scroll = perevesti("���", True)
����10����10.Props.AutoscrollminSizeheight = perevesti("0", True)
����10����10.Props.AutoscrollminSizewidth = perevesti("0", True)
����10����10.Props.AutoscrollpositionX = perevesti("0", True)
����10����10.Props.AutoscrollpositionY = perevesti("0", True)
����10����10.Props.Enabled = perevesti("��", True)
����10����10.Props.Allowruncopies = perevesti("��", True)
����10����10.Props.Startposition = perevesti("�� ������ ������", True)
����10����10.StatusTemp = "����������"
����10����10.Props.Formborderstyle = perevesti("������������� ����", True)
����10����10.Props.Backgroundimagelayout = perevesti("������", True)
����10����10.Props.Tabindex = perevesti("0", True)
����10����10.Props.Tabstop = perevesti("��", True)
����10����10.Props.Text = perevesti("������", True)
����10����10.Props.Backgroundimage = perevesti("�������", True)
����10����10.Props.Backcolor = perevesti("240; 240; 240;", True)
����10����10.Props.Forecolor = perevesti("������", True)
����10����10.Props.Height = perevesti("367", True)
����10����10.Props.Width = perevesti("503", True)
����10����10.Props.Visible = perevesti("��", True)
����10����10.Props.Height = perevesti("367", True)
����10����10.Props.Width = perevesti("503", True)

ProgressForm.ProgressBar1.Value = 46
����10�������72.Props.X = perevesti("8", True)
����10�������72.Props.Y = perevesti("8", True)
����10�������72.Props.Autoellipsis = perevesti("��", True)
����10�������72.Props.Contextmenu(True) = perevesti("�������", True)
����10�������72.Props.Tag = perevesti("", True)
����10�������72.Props.Name = perevesti("�������7", True)
����10�������72.Props.Cursor = perevesti("�������", True)
����10�������72.Props.Maximumheight = perevesti("0", True)
����10�������72.Props.Maximumwidth = perevesti("0", True)
����10�������72.Props.Minimumheight = perevesti("0", True)
����10�������72.Props.Minimumwidth = perevesti("0", True)
����10�������72.Props.Index = perevesti("2", True)
����10�������72.Props.ToolTip = perevesti("", True)
����10�������72.Props.Paddingtop = perevesti("0", True)
����10�������72.Props.Paddingleft = perevesti("0", True)
����10�������72.Props.Paddingbottom = perevesti("0", True)
����10�������72.Props.Paddingright = perevesti("0", True)
����10�������72.Props.Imagealign = perevesti("�����", True)
����10�������72.Props.Textalign = perevesti("�����", True)
����10�������72.Props.Anchor = perevesti("�����_������", True)
����10�������72.Props.Enabled = perevesti("��", True)
����10�������72.Props.Dock = perevesti("�������", True)
����10�������72.Props.Image = perevesti("�������", True)
����10�������72.Props.Borderstyle = perevesti("�������", True)
����10�������72.Props.Backgroundimagelayout = perevesti("������", True)
����10�������72.Props.Tabindex = perevesti("0", True)
����10�������72.Props.Tabstop = perevesti("��", True)
����10�������72.Props.Text = perevesti("������ ����", True)
����10�������72.Props.Backgroundimage = perevesti("�������", True)
����10�������72.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������72.Props.Forecolor = perevesti("������", True)
����10�������72.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������72.Props.Fontbold = perevesti("���", True)
����10�������72.Props.Fontstrikeout = perevesti("���", True)
����10�������72.Props.Fontitalic = perevesti("���", True)
����10�������72.Props.Fontunderline = perevesti("���", True)
����10�������72.Props.Fontsize = perevesti("8", True)
����10�������72.Props.Height = perevesti("15", True)
����10�������72.Props.Width = perevesti("75", True)
����10�������72.Props.Visible = perevesti("��", True)
����10�������72.Props.Height = perevesti("15", True)
����10�������72.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 47
����10������_10.Props.X = perevesti("4", True)
����10������_10.Props.Y = perevesti("8", True)
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
����10������_10.Props.Height = perevesti("283", True)
����10������_10.Props.Width = perevesti("491", True)
����10������_10.Props.Visible = perevesti("��", True)
����10������_10.Props.Height = perevesti("283", True)
����10������_10.Props.Width = perevesti("491", True)

ProgressForm.ProgressBar1.Value = 48
����10�����10.Props.X = perevesti("8", True)
����10�����10.Props.Y = perevesti("24", True)
����10�����10.Props.Contextmenu(True) = perevesti("�������", True)
����10�����10.Props.Tag = perevesti("", True)
����10�����10.Props.Selectedtext = perevesti("", True)
����10�����10.Props.Selectionlength = perevesti("0", True)
����10�����10.Props.Name = perevesti("�����1", True)
����10�����10.Props.Maximumheight = perevesti("0", True)
����10�����10.Props.Maximumlength = perevesti("32767", True)
����10�����10.Props.Maximumwidth = perevesti("0", True)
����10�����10.Props.Minimumheight = perevesti("0", True)
����10�����10.Props.Minimumwidth = perevesti("0", True)
����10�����10.Props.Multiline = perevesti("���", True)
����10�����10.Props.Selectionstart = perevesti("1", True)
����10�����10.Props.Index = perevesti("0", True)
����10�����10.Props.Wordwrap = perevesti("��", True)
����10�����10.Props.ToolTip = perevesti("", True)
����10�����10.Props.Scrollbars = perevesti("���", True)
����10�����10.Props.Anchor = perevesti("�����_������", True)
����10�����10.Props.Enabled = perevesti("��", True)
����10�����10.Props.Allowinput = perevesti("���", True)
����10�����10.Props.Textposition = perevesti("�����", True)
����10�����10.Props.Dock = perevesti("�������", True)
����10�����10.Props.Passwordchar = perevesti("", True)
����10�����10.Props.Hideselection = perevesti("���", True)
����10�����10.Props.Borderstyle = perevesti("�����", True)
����10�����10.Props.Tabindex = perevesti("0", True)
����10�����10.Props.Tabstop = perevesti("��", True)
����10�����10.Props.Text = perevesti("", True)
����10�����10.Props.Readonly = perevesti("���", True)
����10�����10.Props.Backcolor = perevesti("�����", True)
����10�����10.Props.Forecolor = perevesti("������", True)
����10�����10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�����10.Props.Fontbold = perevesti("���", True)
����10�����10.Props.Fontstrikeout = perevesti("���", True)
����10�����10.Props.Fontitalic = perevesti("���", True)
����10�����10.Props.Fontunderline = perevesti("���", True)
����10�����10.Props.Fontsize = perevesti("8", True)
����10�����10.Props.Height = perevesti("20", True)
����10�����10.Props.Width = perevesti("483", True)
����10�����10.Props.Visible = perevesti("��", True)
����10�����10.Props.Height = perevesti("20", True)
����10�����10.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 49
����10�����20.Props.X = perevesti("4", True)
����10�����20.Props.Y = perevesti("64", True)
����10�����20.Props.Contextmenu(True) = perevesti("�������", True)
����10�����20.Props.Tag = perevesti("", True)
����10�����20.Props.Selectedtext = perevesti("", True)
����10�����20.Props.Selectionlength = perevesti("0", True)
����10�����20.Props.Name = perevesti("�����2", True)
����10�����20.Props.Maximumheight = perevesti("0", True)
����10�����20.Props.Maximumlength = perevesti("32767", True)
����10�����20.Props.Maximumwidth = perevesti("0", True)
����10�����20.Props.Minimumheight = perevesti("0", True)
����10�����20.Props.Minimumwidth = perevesti("0", True)
����10�����20.Props.Multiline = perevesti("���", True)
����10�����20.Props.Selectionstart = perevesti("1", True)
����10�����20.Props.Index = perevesti("0", True)
����10�����20.Props.Wordwrap = perevesti("��", True)
����10�����20.Props.ToolTip = perevesti("", True)
����10�����20.Props.Scrollbars = perevesti("���", True)
����10�����20.Props.Anchor = perevesti("�����_������", True)
����10�����20.Props.Enabled = perevesti("��", True)
����10�����20.Props.Allowinput = perevesti("���", True)
����10�����20.Props.Textposition = perevesti("�����", True)
����10�����20.Props.Dock = perevesti("�������", True)
����10�����20.Props.Passwordchar = perevesti("", True)
����10�����20.Props.Hideselection = perevesti("���", True)
����10�����20.Props.Borderstyle = perevesti("�����", True)
����10�����20.Props.Tabindex = perevesti("0", True)
����10�����20.Props.Tabstop = perevesti("��", True)
����10�����20.Props.Text = perevesti("", True)
����10�����20.Props.Readonly = perevesti("���", True)
����10�����20.Props.Backcolor = perevesti("�����", True)
����10�����20.Props.Forecolor = perevesti("������", True)
����10�����20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�����20.Props.Fontbold = perevesti("���", True)
����10�����20.Props.Fontstrikeout = perevesti("���", True)
����10�����20.Props.Fontitalic = perevesti("���", True)
����10�����20.Props.Fontunderline = perevesti("���", True)
����10�����20.Props.Fontsize = perevesti("8", True)
����10�����20.Props.Height = perevesti("20", True)
����10�����20.Props.Width = perevesti("483", True)
����10�����20.Props.Visible = perevesti("��", True)
����10�����20.Props.Height = perevesti("20", True)
����10�����20.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 50
����10�����30.Props.X = perevesti("4", True)
����10�����30.Props.Y = perevesti("112", True)
����10�����30.Props.Contextmenu(True) = perevesti("�������", True)
����10�����30.Props.Tag = perevesti("", True)
����10�����30.Props.Selectedtext = perevesti("", True)
����10�����30.Props.Selectionlength = perevesti("0", True)
����10�����30.Props.Name = perevesti("�����3", True)
����10�����30.Props.Maximumheight = perevesti("0", True)
����10�����30.Props.Maximumlength = perevesti("32767", True)
����10�����30.Props.Maximumwidth = perevesti("0", True)
����10�����30.Props.Minimumheight = perevesti("0", True)
����10�����30.Props.Minimumwidth = perevesti("0", True)
����10�����30.Props.Multiline = perevesti("���", True)
����10�����30.Props.Selectionstart = perevesti("1", True)
����10�����30.Props.Index = perevesti("0", True)
����10�����30.Props.Wordwrap = perevesti("��", True)
����10�����30.Props.ToolTip = perevesti("", True)
����10�����30.Props.Scrollbars = perevesti("���", True)
����10�����30.Props.Anchor = perevesti("�����_������", True)
����10�����30.Props.Enabled = perevesti("��", True)
����10�����30.Props.Allowinput = perevesti("���", True)
����10�����30.Props.Textposition = perevesti("�����", True)
����10�����30.Props.Dock = perevesti("�������", True)
����10�����30.Props.Passwordchar = perevesti("", True)
����10�����30.Props.Hideselection = perevesti("���", True)
����10�����30.Props.Borderstyle = perevesti("�����", True)
����10�����30.Props.Tabindex = perevesti("0", True)
����10�����30.Props.Tabstop = perevesti("��", True)
����10�����30.Props.Text = perevesti("", True)
����10�����30.Props.Readonly = perevesti("���", True)
����10�����30.Props.Backcolor = perevesti("�����", True)
����10�����30.Props.Forecolor = perevesti("������", True)
����10�����30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�����30.Props.Fontbold = perevesti("���", True)
����10�����30.Props.Fontstrikeout = perevesti("���", True)
����10�����30.Props.Fontitalic = perevesti("���", True)
����10�����30.Props.Fontunderline = perevesti("���", True)
����10�����30.Props.Fontsize = perevesti("8", True)
����10�����30.Props.Height = perevesti("20", True)
����10�����30.Props.Width = perevesti("483", True)
����10�����30.Props.Visible = perevesti("��", True)
����10�����30.Props.Height = perevesti("20", True)
����10�����30.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 51
����10�����40.Props.X = perevesti("4", True)
����10�����40.Props.Y = perevesti("160", True)
����10�����40.Props.Contextmenu(True) = perevesti("�������", True)
����10�����40.Props.Tag = perevesti("", True)
����10�����40.Props.Selectedtext = perevesti("", True)
����10�����40.Props.Selectionlength = perevesti("0", True)
����10�����40.Props.Name = perevesti("�����4", True)
����10�����40.Props.Maximumheight = perevesti("0", True)
����10�����40.Props.Maximumlength = perevesti("32767", True)
����10�����40.Props.Maximumwidth = perevesti("0", True)
����10�����40.Props.Minimumheight = perevesti("0", True)
����10�����40.Props.Minimumwidth = perevesti("0", True)
����10�����40.Props.Multiline = perevesti("���", True)
����10�����40.Props.Selectionstart = perevesti("1", True)
����10�����40.Props.Index = perevesti("0", True)
����10�����40.Props.Wordwrap = perevesti("��", True)
����10�����40.Props.ToolTip = perevesti("", True)
����10�����40.Props.Scrollbars = perevesti("���", True)
����10�����40.Props.Anchor = perevesti("�����_������", True)
����10�����40.Props.Enabled = perevesti("��", True)
����10�����40.Props.Allowinput = perevesti("���", True)
����10�����40.Props.Textposition = perevesti("�����", True)
����10�����40.Props.Dock = perevesti("�������", True)
����10�����40.Props.Passwordchar = perevesti("", True)
����10�����40.Props.Hideselection = perevesti("���", True)
����10�����40.Props.Borderstyle = perevesti("�����", True)
����10�����40.Props.Tabindex = perevesti("0", True)
����10�����40.Props.Tabstop = perevesti("��", True)
����10�����40.Props.Text = perevesti("", True)
����10�����40.Props.Readonly = perevesti("���", True)
����10�����40.Props.Backcolor = perevesti("�����", True)
����10�����40.Props.Forecolor = perevesti("������", True)
����10�����40.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�����40.Props.Fontbold = perevesti("���", True)
����10�����40.Props.Fontstrikeout = perevesti("���", True)
����10�����40.Props.Fontitalic = perevesti("���", True)
����10�����40.Props.Fontunderline = perevesti("���", True)
����10�����40.Props.Fontsize = perevesti("8", True)
����10�����40.Props.Height = perevesti("20", True)
����10�����40.Props.Width = perevesti("483", True)
����10�����40.Props.Visible = perevesti("��", True)
����10�����40.Props.Height = perevesti("20", True)
����10�����40.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 52
����10�����50.Props.X = perevesti("4", True)
����10�����50.Props.Y = perevesti("208", True)
����10�����50.Props.Contextmenu(True) = perevesti("�������", True)
����10�����50.Props.Tag = perevesti("", True)
����10�����50.Props.Selectedtext = perevesti("", True)
����10�����50.Props.Selectionlength = perevesti("0", True)
����10�����50.Props.Name = perevesti("�����5", True)
����10�����50.Props.Maximumheight = perevesti("0", True)
����10�����50.Props.Maximumlength = perevesti("32767", True)
����10�����50.Props.Maximumwidth = perevesti("0", True)
����10�����50.Props.Minimumheight = perevesti("0", True)
����10�����50.Props.Minimumwidth = perevesti("0", True)
����10�����50.Props.Multiline = perevesti("���", True)
����10�����50.Props.Selectionstart = perevesti("1", True)
����10�����50.Props.Index = perevesti("0", True)
����10�����50.Props.Wordwrap = perevesti("��", True)
����10�����50.Props.ToolTip = perevesti("", True)
����10�����50.Props.Scrollbars = perevesti("���", True)
����10�����50.Props.Anchor = perevesti("�����_������", True)
����10�����50.Props.Enabled = perevesti("��", True)
����10�����50.Props.Allowinput = perevesti("���", True)
����10�����50.Props.Textposition = perevesti("�����", True)
����10�����50.Props.Dock = perevesti("�������", True)
����10�����50.Props.Passwordchar = perevesti("", True)
����10�����50.Props.Hideselection = perevesti("���", True)
����10�����50.Props.Borderstyle = perevesti("�����", True)
����10�����50.Props.Tabindex = perevesti("0", True)
����10�����50.Props.Tabstop = perevesti("��", True)
����10�����50.Props.Text = perevesti("", True)
����10�����50.Props.Readonly = perevesti("���", True)
����10�����50.Props.Backcolor = perevesti("�����", True)
����10�����50.Props.Forecolor = perevesti("������", True)
����10�����50.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�����50.Props.Fontbold = perevesti("���", True)
����10�����50.Props.Fontstrikeout = perevesti("���", True)
����10�����50.Props.Fontitalic = perevesti("���", True)
����10�����50.Props.Fontunderline = perevesti("���", True)
����10�����50.Props.Fontsize = perevesti("8", True)
����10�����50.Props.Height = perevesti("20", True)
����10�����50.Props.Width = perevesti("483", True)
����10�����50.Props.Visible = perevesti("��", True)
����10�����50.Props.Height = perevesti("20", True)
����10�����50.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 53
����10�����60.Props.X = perevesti("4", True)
����10�����60.Props.Y = perevesti("256", True)
����10�����60.Props.Contextmenu(True) = perevesti("�������", True)
����10�����60.Props.Tag = perevesti("", True)
����10�����60.Props.Selectedtext = perevesti("", True)
����10�����60.Props.Selectionlength = perevesti("0", True)
����10�����60.Props.Name = perevesti("�����6", True)
����10�����60.Props.Maximumheight = perevesti("0", True)
����10�����60.Props.Maximumlength = perevesti("32767", True)
����10�����60.Props.Maximumwidth = perevesti("0", True)
����10�����60.Props.Minimumheight = perevesti("0", True)
����10�����60.Props.Minimumwidth = perevesti("0", True)
����10�����60.Props.Multiline = perevesti("���", True)
����10�����60.Props.Selectionstart = perevesti("1", True)
����10�����60.Props.Index = perevesti("0", True)
����10�����60.Props.Wordwrap = perevesti("��", True)
����10�����60.Props.ToolTip = perevesti("", True)
����10�����60.Props.Scrollbars = perevesti("���", True)
����10�����60.Props.Anchor = perevesti("�����_������", True)
����10�����60.Props.Enabled = perevesti("��", True)
����10�����60.Props.Allowinput = perevesti("���", True)
����10�����60.Props.Textposition = perevesti("�����", True)
����10�����60.Props.Dock = perevesti("�������", True)
����10�����60.Props.Passwordchar = perevesti("", True)
����10�����60.Props.Hideselection = perevesti("���", True)
����10�����60.Props.Borderstyle = perevesti("�����", True)
����10�����60.Props.Tabindex = perevesti("0", True)
����10�����60.Props.Tabstop = perevesti("��", True)
����10�����60.Props.Text = perevesti("", True)
����10�����60.Props.Readonly = perevesti("���", True)
����10�����60.Props.Backcolor = perevesti("�����", True)
����10�����60.Props.Forecolor = perevesti("������", True)
����10�����60.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�����60.Props.Fontbold = perevesti("���", True)
����10�����60.Props.Fontstrikeout = perevesti("���", True)
����10�����60.Props.Fontitalic = perevesti("���", True)
����10�����60.Props.Fontunderline = perevesti("���", True)
����10�����60.Props.Fontsize = perevesti("8", True)
����10�����60.Props.Height = perevesti("20", True)
����10�����60.Props.Width = perevesti("483", True)
����10�����60.Props.Visible = perevesti("��", True)
����10�����60.Props.Height = perevesti("20", True)
����10�����60.Props.Width = perevesti("483", True)

ProgressForm.ProgressBar1.Value = 54
����10������10.Props.X = perevesti("424", True)
����10������10.Props.Y = perevesti("340", True)
����10������10.Props.Autoellipsis = perevesti("��", True)
����10������10.Props.Contextmenu(True) = perevesti("�������", True)
����10������10.Props.Tag = perevesti("", True)
����10������10.Props.Name = perevesti("������1", True)
����10������10.Props.Cursor = perevesti("�������", True)
����10������10.Props.Maximumheight = perevesti("0", True)
����10������10.Props.Maximumwidth = perevesti("0", True)
����10������10.Props.Minimumheight = perevesti("0", True)
����10������10.Props.Minimumwidth = perevesti("0", True)
����10������10.Props.Index = perevesti("0", True)
����10������10.Props.ToolTip = perevesti("", True)
����10������10.Props.Paddingtop = perevesti("0", True)
����10������10.Props.Paddingleft = perevesti("0", True)
����10������10.Props.Paddingbottom = perevesti("0", True)
����10������10.Props.Paddingright = perevesti("0", True)
����10������10.Props.Imagealign = perevesti("�����", True)
����10������10.Props.Textalign = perevesti("�����", True)
����10������10.Props.Anchor = perevesti("�����_������", True)
����10������10.Props.Enabled = perevesti("��", True)
����10������10.Props.Dock = perevesti("�������", True)
����10������10.Props.Image = perevesti("�������", True)
����10������10.Props.Flatstyle = perevesti("�������", True)
����10������10.Props.Backgroundimagelayout = perevesti("������", True)
����10������10.Props.Tabindex = perevesti("0", True)
����10������10.Props.Tabstop = perevesti("��", True)
����10������10.Props.Text = perevesti("�����", True)
����10������10.Props.Textimagerelation = perevesti("������", True)
����10������10.Props.Backgroundimage = perevesti("�������", True)
����10������10.Props.Backcolor = perevesti("�������", True)
����10������10.Props.Forecolor = perevesti("������", True)
����10������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10������10.Props.Fontbold = perevesti("���", True)
����10������10.Props.Fontstrikeout = perevesti("���", True)
����10������10.Props.Fontitalic = perevesti("���", True)
����10������10.Props.Fontunderline = perevesti("���", True)
����10������10.Props.Fontsize = perevesti("8", True)
����10������10.Props.Height = perevesti("23", True)
����10������10.Props.Width = perevesti("75", True)
����10������10.Props.Visible = perevesti("��", True)
����10������10.Props.Height = perevesti("23", True)
����10������10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 55
����10�������73.Props.X = perevesti("4", True)
����10�������73.Props.Y = perevesti("44", True)
����10�������73.Props.Autoellipsis = perevesti("��", True)
����10�������73.Props.Contextmenu(True) = perevesti("�������", True)
����10�������73.Props.Tag = perevesti("", True)
����10�������73.Props.Name = perevesti("�������7", True)
����10�������73.Props.Cursor = perevesti("�������", True)
����10�������73.Props.Maximumheight = perevesti("0", True)
����10�������73.Props.Maximumwidth = perevesti("0", True)
����10�������73.Props.Minimumheight = perevesti("0", True)
����10�������73.Props.Minimumwidth = perevesti("0", True)
����10�������73.Props.Index = perevesti("3", True)
����10�������73.Props.ToolTip = perevesti("", True)
����10�������73.Props.Paddingtop = perevesti("0", True)
����10�������73.Props.Paddingleft = perevesti("0", True)
����10�������73.Props.Paddingbottom = perevesti("0", True)
����10�������73.Props.Paddingright = perevesti("0", True)
����10�������73.Props.Imagealign = perevesti("�����", True)
����10�������73.Props.Textalign = perevesti("�����", True)
����10�������73.Props.Anchor = perevesti("�����_������", True)
����10�������73.Props.Enabled = perevesti("��", True)
����10�������73.Props.Dock = perevesti("�������", True)
����10�������73.Props.Image = perevesti("�������", True)
����10�������73.Props.Borderstyle = perevesti("�������", True)
����10�������73.Props.Backgroundimagelayout = perevesti("������", True)
����10�������73.Props.Tabindex = perevesti("0", True)
����10�������73.Props.Tabstop = perevesti("��", True)
����10�������73.Props.Text = perevesti("������ ����������", True)
����10�������73.Props.Backgroundimage = perevesti("�������", True)
����10�������73.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������73.Props.Forecolor = perevesti("������", True)
����10�������73.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������73.Props.Fontbold = perevesti("���", True)
����10�������73.Props.Fontstrikeout = perevesti("���", True)
����10�������73.Props.Fontitalic = perevesti("���", True)
����10�������73.Props.Fontunderline = perevesti("���", True)
����10�������73.Props.Fontsize = perevesti("8", True)
����10�������73.Props.Height = perevesti("15", True)
����10�������73.Props.Width = perevesti("111", True)
����10�������73.Props.Visible = perevesti("��", True)
����10�������73.Props.Height = perevesti("15", True)
����10�������73.Props.Width = perevesti("111", True)

ProgressForm.ProgressBar1.Value = 56
����10�������74.Props.X = perevesti("4", True)
����10�������74.Props.Y = perevesti("92", True)
����10�������74.Props.Autoellipsis = perevesti("��", True)
����10�������74.Props.Contextmenu(True) = perevesti("�������", True)
����10�������74.Props.Tag = perevesti("", True)
����10�������74.Props.Name = perevesti("�������7", True)
����10�������74.Props.Cursor = perevesti("�������", True)
����10�������74.Props.Maximumheight = perevesti("0", True)
����10�������74.Props.Maximumwidth = perevesti("0", True)
����10�������74.Props.Minimumheight = perevesti("0", True)
����10�������74.Props.Minimumwidth = perevesti("0", True)
����10�������74.Props.Index = perevesti("4", True)
����10�������74.Props.ToolTip = perevesti("", True)
����10�������74.Props.Paddingtop = perevesti("0", True)
����10�������74.Props.Paddingleft = perevesti("0", True)
����10�������74.Props.Paddingbottom = perevesti("0", True)
����10�������74.Props.Paddingright = perevesti("0", True)
����10�������74.Props.Imagealign = perevesti("�����", True)
����10�������74.Props.Textalign = perevesti("�����", True)
����10�������74.Props.Anchor = perevesti("�����_������", True)
����10�������74.Props.Enabled = perevesti("��", True)
����10�������74.Props.Dock = perevesti("�������", True)
����10�������74.Props.Image = perevesti("�������", True)
����10�������74.Props.Borderstyle = perevesti("�������", True)
����10�������74.Props.Backgroundimagelayout = perevesti("������", True)
����10�������74.Props.Tabindex = perevesti("0", True)
����10�������74.Props.Tabstop = perevesti("��", True)
����10�������74.Props.Text = perevesti("������ �������������", True)
����10�������74.Props.Backgroundimage = perevesti("�������", True)
����10�������74.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������74.Props.Forecolor = perevesti("������", True)
����10�������74.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������74.Props.Fontbold = perevesti("���", True)
����10�������74.Props.Fontstrikeout = perevesti("���", True)
����10�������74.Props.Fontitalic = perevesti("���", True)
����10�������74.Props.Fontunderline = perevesti("���", True)
����10�������74.Props.Fontsize = perevesti("8", True)
����10�������74.Props.Height = perevesti("15", True)
����10�������74.Props.Width = perevesti("127", True)
����10�������74.Props.Visible = perevesti("��", True)
����10�������74.Props.Height = perevesti("15", True)
����10�������74.Props.Width = perevesti("127", True)

ProgressForm.ProgressBar1.Value = 57
����10�������75.Props.X = perevesti("4", True)
����10�������75.Props.Y = perevesti("140", True)
����10�������75.Props.Autoellipsis = perevesti("��", True)
����10�������75.Props.Contextmenu(True) = perevesti("�������", True)
����10�������75.Props.Tag = perevesti("", True)
����10�������75.Props.Name = perevesti("�������7", True)
����10�������75.Props.Cursor = perevesti("�������", True)
����10�������75.Props.Maximumheight = perevesti("0", True)
����10�������75.Props.Maximumwidth = perevesti("0", True)
����10�������75.Props.Minimumheight = perevesti("0", True)
����10�������75.Props.Minimumwidth = perevesti("0", True)
����10�������75.Props.Index = perevesti("5", True)
����10�������75.Props.ToolTip = perevesti("", True)
����10�������75.Props.Paddingtop = perevesti("0", True)
����10�������75.Props.Paddingleft = perevesti("0", True)
����10�������75.Props.Paddingbottom = perevesti("0", True)
����10�������75.Props.Paddingright = perevesti("0", True)
����10�������75.Props.Imagealign = perevesti("�����", True)
����10�������75.Props.Textalign = perevesti("�����", True)
����10�������75.Props.Anchor = perevesti("�����_������", True)
����10�������75.Props.Enabled = perevesti("��", True)
����10�������75.Props.Dock = perevesti("�������", True)
����10�������75.Props.Image = perevesti("�������", True)
����10�������75.Props.Borderstyle = perevesti("�������", True)
����10�������75.Props.Backgroundimagelayout = perevesti("������", True)
����10�������75.Props.Tabindex = perevesti("0", True)
����10�������75.Props.Tabstop = perevesti("��", True)
����10�������75.Props.Text = perevesti("������ ���������", True)
����10�������75.Props.Backgroundimage = perevesti("�������", True)
����10�������75.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������75.Props.Forecolor = perevesti("������", True)
����10�������75.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������75.Props.Fontbold = perevesti("���", True)
����10�������75.Props.Fontstrikeout = perevesti("���", True)
����10�������75.Props.Fontitalic = perevesti("���", True)
����10�������75.Props.Fontunderline = perevesti("���", True)
����10�������75.Props.Fontsize = perevesti("8", True)
����10�������75.Props.Height = perevesti("15", True)
����10�������75.Props.Width = perevesti("103", True)
����10�������75.Props.Visible = perevesti("��", True)
����10�������75.Props.Height = perevesti("15", True)
����10�������75.Props.Width = perevesti("103", True)

ProgressForm.ProgressBar1.Value = 58
����10�������76.Props.X = perevesti("4", True)
����10�������76.Props.Y = perevesti("188", True)
����10�������76.Props.Autoellipsis = perevesti("��", True)
����10�������76.Props.Contextmenu(True) = perevesti("�������", True)
����10�������76.Props.Tag = perevesti("", True)
����10�������76.Props.Name = perevesti("�������7", True)
����10�������76.Props.Cursor = perevesti("�������", True)
����10�������76.Props.Maximumheight = perevesti("0", True)
����10�������76.Props.Maximumwidth = perevesti("0", True)
����10�������76.Props.Minimumheight = perevesti("0", True)
����10�������76.Props.Minimumwidth = perevesti("0", True)
����10�������76.Props.Index = perevesti("6", True)
����10�������76.Props.ToolTip = perevesti("", True)
����10�������76.Props.Paddingtop = perevesti("0", True)
����10�������76.Props.Paddingleft = perevesti("0", True)
����10�������76.Props.Paddingbottom = perevesti("0", True)
����10�������76.Props.Paddingright = perevesti("0", True)
����10�������76.Props.Imagealign = perevesti("�����", True)
����10�������76.Props.Textalign = perevesti("�����", True)
����10�������76.Props.Anchor = perevesti("�����_������", True)
����10�������76.Props.Enabled = perevesti("��", True)
����10�������76.Props.Dock = perevesti("�������", True)
����10�������76.Props.Image = perevesti("�������", True)
����10�������76.Props.Borderstyle = perevesti("�������", True)
����10�������76.Props.Backgroundimagelayout = perevesti("������", True)
����10�������76.Props.Tabindex = perevesti("0", True)
����10�������76.Props.Tabstop = perevesti("��", True)
����10�������76.Props.Text = perevesti("������ ������ �������", True)
����10�������76.Props.Backgroundimage = perevesti("�������", True)
����10�������76.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������76.Props.Forecolor = perevesti("������", True)
����10�������76.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������76.Props.Fontbold = perevesti("���", True)
����10�������76.Props.Fontstrikeout = perevesti("���", True)
����10�������76.Props.Fontitalic = perevesti("���", True)
����10�������76.Props.Fontunderline = perevesti("���", True)
����10�������76.Props.Fontsize = perevesti("8", True)
����10�������76.Props.Height = perevesti("15", True)
����10�������76.Props.Width = perevesti("135", True)
����10�������76.Props.Visible = perevesti("��", True)
����10�������76.Props.Height = perevesti("15", True)
����10�������76.Props.Width = perevesti("135", True)

ProgressForm.ProgressBar1.Value = 59
����10�������77.Props.X = perevesti("4", True)
����10�������77.Props.Y = perevesti("236", True)
����10�������77.Props.Autoellipsis = perevesti("��", True)
����10�������77.Props.Contextmenu(True) = perevesti("�������", True)
����10�������77.Props.Tag = perevesti("", True)
����10�������77.Props.Name = perevesti("�������7", True)
����10�������77.Props.Cursor = perevesti("�������", True)
����10�������77.Props.Maximumheight = perevesti("0", True)
����10�������77.Props.Maximumwidth = perevesti("0", True)
����10�������77.Props.Minimumheight = perevesti("0", True)
����10�������77.Props.Minimumwidth = perevesti("0", True)
����10�������77.Props.Index = perevesti("7", True)
����10�������77.Props.ToolTip = perevesti("", True)
����10�������77.Props.Paddingtop = perevesti("0", True)
����10�������77.Props.Paddingleft = perevesti("0", True)
����10�������77.Props.Paddingbottom = perevesti("0", True)
����10�������77.Props.Paddingright = perevesti("0", True)
����10�������77.Props.Imagealign = perevesti("�����", True)
����10�������77.Props.Textalign = perevesti("�����", True)
����10�������77.Props.Anchor = perevesti("�����_������", True)
����10�������77.Props.Enabled = perevesti("��", True)
����10�������77.Props.Dock = perevesti("�������", True)
����10�������77.Props.Image = perevesti("�������", True)
����10�������77.Props.Borderstyle = perevesti("�������", True)
����10�������77.Props.Backgroundimagelayout = perevesti("������", True)
����10�������77.Props.Tabindex = perevesti("0", True)
����10�������77.Props.Tabstop = perevesti("��", True)
����10�������77.Props.Text = perevesti("������ ������ �������", True)
����10�������77.Props.Backgroundimage = perevesti("�������", True)
����10�������77.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������77.Props.Forecolor = perevesti("������", True)
����10�������77.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������77.Props.Fontbold = perevesti("���", True)
����10�������77.Props.Fontstrikeout = perevesti("���", True)
����10�������77.Props.Fontitalic = perevesti("���", True)
����10�������77.Props.Fontunderline = perevesti("���", True)
����10�������77.Props.Fontsize = perevesti("8", True)
����10�������77.Props.Height = perevesti("15", True)
����10�������77.Props.Width = perevesti("135", True)
����10�������77.Props.Visible = perevesti("��", True)
����10�������77.Props.Height = perevesti("15", True)
����10�������77.Props.Width = perevesti("135", True)

ProgressForm.ProgressBar1.Value = 59
����10�����70.Props.X = perevesti("4", True)
����10�����70.Props.Y = perevesti("316", True)
����10�����70.Props.Contextmenu(True) = perevesti("�������", True)
����10�����70.Props.Tag = perevesti("", True)
����10�����70.Props.Selectedtext = perevesti("", True)
����10�����70.Props.Selectionlength = perevesti("0", True)
����10�����70.Props.Name = perevesti("�����7", True)
����10�����70.Props.Maximumheight = perevesti("0", True)
����10�����70.Props.Maximumlength = perevesti("32767", True)
����10�����70.Props.Maximumwidth = perevesti("0", True)
����10�����70.Props.Minimumheight = perevesti("0", True)
����10�����70.Props.Minimumwidth = perevesti("0", True)
����10�����70.Props.Multiline = perevesti("���", True)
����10�����70.Props.Selectionstart = perevesti("1", True)
����10�����70.Props.Index = perevesti("0", True)
����10�����70.Props.Wordwrap = perevesti("��", True)
����10�����70.Props.ToolTip = perevesti("", True)
����10�����70.Props.Scrollbars = perevesti("���", True)
����10�����70.Props.Anchor = perevesti("�����_������", True)
����10�����70.Props.Enabled = perevesti("��", True)
����10�����70.Props.Allowinput = perevesti("���", True)
����10�����70.Props.Textposition = perevesti("�����", True)
����10�����70.Props.Dock = perevesti("�������", True)
����10�����70.Props.Passwordchar = perevesti("", True)
����10�����70.Props.Hideselection = perevesti("���", True)
����10�����70.Props.Borderstyle = perevesti("�����", True)
����10�����70.Props.Tabindex = perevesti("0", True)
����10�����70.Props.Tabstop = perevesti("��", True)
����10�����70.Props.Text = perevesti("", True)
����10�����70.Props.Readonly = perevesti("���", True)
����10�����70.Props.Backcolor = perevesti("�����", True)
����10�����70.Props.Forecolor = perevesti("������", True)
����10�����70.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�����70.Props.Fontbold = perevesti("���", True)
����10�����70.Props.Fontstrikeout = perevesti("���", True)
����10�����70.Props.Fontitalic = perevesti("���", True)
����10�����70.Props.Fontunderline = perevesti("���", True)
����10�����70.Props.Fontsize = perevesti("8", True)
����10�����70.Props.Height = perevesti("20", True)
����10�����70.Props.Width = perevesti("495", True)
����10�����70.Props.Visible = perevesti("��", True)
����10�����70.Props.Height = perevesti("20", True)
����10�����70.Props.Width = perevesti("495", True)

ProgressForm.ProgressBar1.Value = 60
����10�������71.Props.X = perevesti("4", True)
����10�������71.Props.Y = perevesti("296", True)
����10�������71.Props.Autoellipsis = perevesti("��", True)
����10�������71.Props.Contextmenu(True) = perevesti("�������", True)
����10�������71.Props.Tag = perevesti("", True)
����10�������71.Props.Name = perevesti("�������7", True)
����10�������71.Props.Cursor = perevesti("�������", True)
����10�������71.Props.Maximumheight = perevesti("0", True)
����10�������71.Props.Maximumwidth = perevesti("0", True)
����10�������71.Props.Minimumheight = perevesti("0", True)
����10�������71.Props.Minimumwidth = perevesti("0", True)
����10�������71.Props.Index = perevesti("1", True)
����10�������71.Props.ToolTip = perevesti("", True)
����10�������71.Props.Paddingtop = perevesti("0", True)
����10�������71.Props.Paddingleft = perevesti("0", True)
����10�������71.Props.Paddingbottom = perevesti("0", True)
����10�������71.Props.Paddingright = perevesti("0", True)
����10�������71.Props.Imagealign = perevesti("�����", True)
����10�������71.Props.Textalign = perevesti("�����", True)
����10�������71.Props.Anchor = perevesti("�����_������", True)
����10�������71.Props.Enabled = perevesti("��", True)
����10�������71.Props.Dock = perevesti("�������", True)
����10�������71.Props.Image = perevesti("�������", True)
����10�������71.Props.Borderstyle = perevesti("�������", True)
����10�������71.Props.Backgroundimagelayout = perevesti("������", True)
����10�������71.Props.Tabindex = perevesti("0", True)
����10�������71.Props.Tabstop = perevesti("��", True)
����10�������71.Props.Text = perevesti("������", True)
����10�������71.Props.Backgroundimage = perevesti("�������", True)
����10�������71.Props.Backcolor = perevesti("240; 240; 240;", True)
����10�������71.Props.Forecolor = perevesti("������", True)
����10�������71.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10�������71.Props.Fontbold = perevesti("���", True)
����10�������71.Props.Fontstrikeout = perevesti("���", True)
����10�������71.Props.Fontitalic = perevesti("���", True)
����10�������71.Props.Fontunderline = perevesti("���", True)
����10�������71.Props.Fontsize = perevesti("8", True)
����10�������71.Props.Height = perevesti("15", True)
����10�������71.Props.Width = perevesti("51", True)
����10�������71.Props.Visible = perevesti("��", True)
����10�������71.Props.Height = perevesti("15", True)
����10�������71.Props.Width = perevesti("51", True)

ProgressForm.ProgressBar1.Value = 61
����10������20.Props.X = perevesti("80", True)
����10������20.Props.Y = perevesti("340", True)
����10������20.Props.Autoellipsis = perevesti("��", True)
����10������20.Props.Contextmenu(True) = perevesti("�������", True)
����10������20.Props.Tag = perevesti("", True)
����10������20.Props.Name = perevesti("������2", True)
����10������20.Props.Cursor = perevesti("�������", True)
����10������20.Props.Maximumheight = perevesti("0", True)
����10������20.Props.Maximumwidth = perevesti("0", True)
����10������20.Props.Minimumheight = perevesti("0", True)
����10������20.Props.Minimumwidth = perevesti("0", True)
����10������20.Props.Index = perevesti("0", True)
����10������20.Props.ToolTip = perevesti("", True)
����10������20.Props.Paddingtop = perevesti("0", True)
����10������20.Props.Paddingleft = perevesti("0", True)
����10������20.Props.Paddingbottom = perevesti("0", True)
����10������20.Props.Paddingright = perevesti("0", True)
����10������20.Props.Imagealign = perevesti("�����", True)
����10������20.Props.Textalign = perevesti("�����", True)
����10������20.Props.Anchor = perevesti("�����_������", True)
����10������20.Props.Enabled = perevesti("��", True)
����10������20.Props.Dock = perevesti("�������", True)
����10������20.Props.Image = perevesti("�������", True)
����10������20.Props.Flatstyle = perevesti("�������", True)
����10������20.Props.Backgroundimagelayout = perevesti("������", True)
����10������20.Props.Tabindex = perevesti("0", True)
����10������20.Props.Tabstop = perevesti("��", True)
����10������20.Props.Text = perevesti("����������", True)
����10������20.Props.Textimagerelation = perevesti("������", True)
����10������20.Props.Backgroundimage = perevesti("�������", True)
����10������20.Props.Backcolor = perevesti("�������", True)
����10������20.Props.Forecolor = perevesti("������", True)
����10������20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10������20.Props.Fontbold = perevesti("���", True)
����10������20.Props.Fontstrikeout = perevesti("���", True)
����10������20.Props.Fontitalic = perevesti("���", True)
����10������20.Props.Fontunderline = perevesti("���", True)
����10������20.Props.Fontsize = perevesti("8", True)
����10������20.Props.Height = perevesti("23", True)
����10������20.Props.Width = perevesti("75", True)
����10������20.Props.Visible = perevesti("��", True)
����10������20.Props.Height = perevesti("23", True)
����10������20.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 62
����10������30.Props.X = perevesti("4", True)
����10������30.Props.Y = perevesti("340", True)
����10������30.Props.Autoellipsis = perevesti("��", True)
����10������30.Props.Contextmenu(True) = perevesti("�������", True)
����10������30.Props.Tag = perevesti("", True)
����10������30.Props.Name = perevesti("������3", True)
����10������30.Props.Cursor = perevesti("�������", True)
����10������30.Props.Maximumheight = perevesti("0", True)
����10������30.Props.Maximumwidth = perevesti("0", True)
����10������30.Props.Minimumheight = perevesti("0", True)
����10������30.Props.Minimumwidth = perevesti("0", True)
����10������30.Props.Index = perevesti("0", True)
����10������30.Props.ToolTip = perevesti("", True)
����10������30.Props.Paddingtop = perevesti("0", True)
����10������30.Props.Paddingleft = perevesti("0", True)
����10������30.Props.Paddingbottom = perevesti("0", True)
����10������30.Props.Paddingright = perevesti("0", True)
����10������30.Props.Imagealign = perevesti("�����", True)
����10������30.Props.Textalign = perevesti("�����", True)
����10������30.Props.Anchor = perevesti("�����_������", True)
����10������30.Props.Enabled = perevesti("��", True)
����10������30.Props.Dock = perevesti("�������", True)
����10������30.Props.Image = perevesti("�������", True)
����10������30.Props.Flatstyle = perevesti("�������", True)
����10������30.Props.Backgroundimagelayout = perevesti("������", True)
����10������30.Props.Tabindex = perevesti("0", True)
����10������30.Props.Tabstop = perevesti("��", True)
����10������30.Props.Text = perevesti("�������", True)
����10������30.Props.Textimagerelation = perevesti("������", True)
����10������30.Props.Backgroundimage = perevesti("�������", True)
����10������30.Props.Backcolor = perevesti("�������", True)
����10������30.Props.Forecolor = perevesti("������", True)
����10������30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����10������30.Props.Fontbold = perevesti("���", True)
����10������30.Props.Fontstrikeout = perevesti("���", True)
����10������30.Props.Fontitalic = perevesti("���", True)
����10������30.Props.Fontunderline = perevesti("���", True)
����10������30.Props.Fontsize = perevesti("8", True)
����10������30.Props.Height = perevesti("23", True)
����10������30.Props.Width = perevesti("75", True)
����10������30.Props.Visible = perevesti("��", True)
����10������30.Props.Height = perevesti("23", True)
����10������30.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 63
����10����_��������10.Props.X = perevesti("8", True)
����10����_��������10.Props.Y = perevesti("8", True)
����10����_��������10.Props.Tag = perevesti("", True)
����10����_��������10.Props.Multiselectfiles = perevesti("���", True)
����10����_��������10.Props.Defaultext = perevesti("", True)
����10����_��������10.Props.Title = perevesti("", True)
����10����_��������10.Props.Name = perevesti("���� ��������1", True)
����10����_��������10.Props.Filename = perevesti("", True)
����10����_��������10.Props.Initialdirectory = perevesti("", True)
����10����_��������10.Props.Index = perevesti("0", True)
����10����_��������10.Props.Filterindex = perevesti("1", True)
����10����_��������10.Props.Checkpathexists = perevesti("��", True)
����10����_��������10.Props.Checkfileexists = perevesti("��", True)
����10����_��������10.Props.Filter = perevesti("�������|*.jpg;*.bmp;*.png|��� �����|*.*", True)

ProgressForm.ProgressBar1.Value = 64
����20����20.Props.X = perevesti("0", True)
����20����20.Props.Y = perevesti("0", True)
����20����20.Props.Associatewithextensions = perevesti("", True)
����20����20.Props.Contextmenu(True) = perevesti("�������", True)
����20����20.Props.Tag = perevesti("", True)
����20����20.Props.Mainform = perevesti("���", True)
����20����20.Props.Mainmenustrip(True) = perevesti("�������", True)
����20����20.Props.AutoRun = perevesti("���", True)
����20����20.Props.Forbidclose = perevesti("���", True)
����20����20.Props.Forbidminimize = perevesti("���", True)
����20����20.Props.Forbidmaximize = perevesti("��", True)
����20����20.Props.Icon = perevesti("�������", True)
����20����20.Props.Name = perevesti("����2", True)
����20����20.Props.Cursor = perevesti("�������", True)
����20����20.Props.Maximumheight = perevesti("0", True)
����20����20.Props.Maximumwidth = perevesti("0", True)
����20����20.Props.Minimumheight = perevesti("0", True)
����20����20.Props.Minimumwidth = perevesti("0", True)
����20����20.Props.Index = perevesti("0", True)
����20����20.Props.Controlbox = perevesti("��", True)
����20����20.Props.Showintaskbar = perevesti("��", True)
����20����20.Props.Showintray = perevesti("���", True)
����20����20.Props.TopMost = perevesti("���", True)
����20����20.Props.ToolTip = perevesti("", True)
����20����20.Props.Showicon = perevesti("���", True)
����20����20.Props.Opacity = perevesti("100", True)
����20����20.Props.Transparentcykey = perevesti("�������", True)
����20����20.Props.Scroll = perevesti("���", True)
����20����20.Props.AutoscrollminSizeheight = perevesti("0", True)
����20����20.Props.AutoscrollminSizewidth = perevesti("0", True)
����20����20.Props.AutoscrollpositionX = perevesti("0", True)
����20����20.Props.AutoscrollpositionY = perevesti("0", True)
����20����20.Props.Enabled = perevesti("���", True)
����20����20.Props.Allowruncopies = perevesti("��", True)
����20����20.Props.Startposition = perevesti("�� ������ ������", True)
����20����20.StatusTemp = "����������"
����20����20.Props.Formborderstyle = perevesti("������������� ����", True)
����20����20.Props.Backgroundimagelayout = perevesti("������", True)
����20����20.Props.Tabindex = perevesti("0", True)
����20����20.Props.Tabstop = perevesti("��", True)
����20����20.Props.Text = perevesti("������� �������� �����", True)
����20����20.Props.Backgroundimage = perevesti("�������", True)
����20����20.Props.Backcolor = perevesti("���������", True)
����20����20.Props.Forecolor = perevesti("������", True)
����20����20.Props.Height = perevesti("203", True)
����20����20.Props.Width = perevesti("315", True)
����20����20.Props.Visible = perevesti("���", True)
����20����20.Props.Height = perevesti("203", True)
����20����20.Props.Width = perevesti("315", True)

ProgressForm.ProgressBar1.Value = 65
����20�������10.Props.X = perevesti("4", True)
����20�������10.Props.Y = perevesti("4", True)
����20�������10.Props.Contextmenu(True) = perevesti("�������", True)
����20�������10.Props.Tag = perevesti("", True)
����20�������10.Props.Name = perevesti("�������1", True)
����20�������10.Props.Cursor = perevesti("�������", True)
����20�������10.Props.Maximumheight = perevesti("0", True)
����20�������10.Props.Maximumwidth = perevesti("0", True)
����20�������10.Props.Minimumheight = perevesti("0", True)
����20�������10.Props.Minimumwidth = perevesti("0", True)
����20�������10.Props.Index = perevesti("0", True)
����20�������10.Props.ToolTip = perevesti("", True)
����20�������10.Props.Anchor = perevesti("�����_������", True)
����20�������10.Props.Enabled = perevesti("��", True)
����20�������10.Props.Dock = perevesti("�������", True)
����20�������10.Props.Image = perevesti("�������", True)
����20�������10.Props.Borderstyle = perevesti("�������", True)
����20�������10.Props.Sizemode = perevesti("����������", True)
����20�������10.Props.Backgroundimagelayout = perevesti("������", True)
����20�������10.Props.Tabindex = perevesti("0", True)
����20�������10.Props.Tabstop = perevesti("��", True)
����20�������10.Props.Backgroundimage = perevesti("�������", True)
����20�������10.Props.Backcolor = perevesti("172; 172; 172;", True)
����20�������10.Props.Height = perevesti("173", True)
����20�������10.Props.Width = perevesti("230", True)
����20�������10.Props.Visible = perevesti("��", True)
����20�������10.Props.Height = perevesti("173", True)
����20�������10.Props.Width = perevesti("230", True)

ProgressForm.ProgressBar1.Value = 66
����20������10.Props.X = perevesti("236", True)
����20������10.Props.Y = perevesti("4", True)
����20������10.Props.Autoellipsis = perevesti("��", True)
����20������10.Props.Contextmenu(True) = perevesti("�������", True)
����20������10.Props.Tag = perevesti("", True)
����20������10.Props.Name = perevesti("������1", True)
����20������10.Props.Cursor = perevesti("�������", True)
����20������10.Props.Maximumheight = perevesti("0", True)
����20������10.Props.Maximumwidth = perevesti("0", True)
����20������10.Props.Minimumheight = perevesti("0", True)
����20������10.Props.Minimumwidth = perevesti("0", True)
����20������10.Props.Index = perevesti("0", True)
����20������10.Props.ToolTip = perevesti("", True)
����20������10.Props.Paddingtop = perevesti("0", True)
����20������10.Props.Paddingleft = perevesti("0", True)
����20������10.Props.Paddingbottom = perevesti("0", True)
����20������10.Props.Paddingright = perevesti("0", True)
����20������10.Props.Imagealign = perevesti("�����", True)
����20������10.Props.Textalign = perevesti("�����", True)
����20������10.Props.Anchor = perevesti("�����_������", True)
����20������10.Props.Enabled = perevesti("��", True)
����20������10.Props.Dock = perevesti("�������", True)
����20������10.Props.Image = perevesti("�������", True)
����20������10.Props.Flatstyle = perevesti("�������", True)
����20������10.Props.Backgroundimagelayout = perevesti("������", True)
����20������10.Props.Tabindex = perevesti("0", True)
����20������10.Props.Tabstop = perevesti("��", True)
����20������10.Props.Text = perevesti("�������", True)
����20������10.Props.Textimagerelation = perevesti("������", True)
����20������10.Props.Backgroundimage = perevesti("�������", True)
����20������10.Props.Backcolor = perevesti("�������", True)
����20������10.Props.Forecolor = perevesti("������", True)
����20������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����20������10.Props.Fontbold = perevesti("���", True)
����20������10.Props.Fontstrikeout = perevesti("���", True)
����20������10.Props.Fontitalic = perevesti("���", True)
����20������10.Props.Fontunderline = perevesti("���", True)
����20������10.Props.Fontsize = perevesti("8", True)
����20������10.Props.Height = perevesti("23", True)
����20������10.Props.Width = perevesti("75", True)
����20������10.Props.Visible = perevesti("��", True)
����20������10.Props.Height = perevesti("23", True)
����20������10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 67
����20������20.Props.X = perevesti("236", True)
����20������20.Props.Y = perevesti("28", True)
����20������20.Props.Autoellipsis = perevesti("��", True)
����20������20.Props.Contextmenu(True) = perevesti("�������", True)
����20������20.Props.Tag = perevesti("", True)
����20������20.Props.Name = perevesti("������2", True)
����20������20.Props.Cursor = perevesti("�������", True)
����20������20.Props.Maximumheight = perevesti("0", True)
����20������20.Props.Maximumwidth = perevesti("0", True)
����20������20.Props.Minimumheight = perevesti("0", True)
����20������20.Props.Minimumwidth = perevesti("0", True)
����20������20.Props.Index = perevesti("0", True)
����20������20.Props.ToolTip = perevesti("", True)
����20������20.Props.Paddingtop = perevesti("0", True)
����20������20.Props.Paddingleft = perevesti("0", True)
����20������20.Props.Paddingbottom = perevesti("0", True)
����20������20.Props.Paddingright = perevesti("0", True)
����20������20.Props.Imagealign = perevesti("�����", True)
����20������20.Props.Textalign = perevesti("�����", True)
����20������20.Props.Anchor = perevesti("�����_������", True)
����20������20.Props.Enabled = perevesti("��", True)
����20������20.Props.Dock = perevesti("�������", True)
����20������20.Props.Image = perevesti("�������", True)
����20������20.Props.Flatstyle = perevesti("�������", True)
����20������20.Props.Backgroundimagelayout = perevesti("������", True)
����20������20.Props.Tabindex = perevesti("0", True)
����20������20.Props.Tabstop = perevesti("��", True)
����20������20.Props.Text = perevesti("�����", True)
����20������20.Props.Textimagerelation = perevesti("������", True)
����20������20.Props.Backgroundimage = perevesti("�������", True)
����20������20.Props.Backcolor = perevesti("�������", True)
����20������20.Props.Forecolor = perevesti("������", True)
����20������20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����20������20.Props.Fontbold = perevesti("���", True)
����20������20.Props.Fontstrikeout = perevesti("���", True)
����20������20.Props.Fontitalic = perevesti("���", True)
����20������20.Props.Fontunderline = perevesti("���", True)
����20������20.Props.Fontsize = perevesti("8", True)
����20������20.Props.Height = perevesti("23", True)
����20������20.Props.Width = perevesti("75", True)
����20������20.Props.Visible = perevesti("��", True)
����20������20.Props.Height = perevesti("23", True)
����20������20.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 68
����20�����10.Props.X = perevesti("4", True)
����20�����10.Props.Y = perevesti("180", True)
����20�����10.Props.Contextmenu(True) = perevesti("�������", True)
����20�����10.Props.Tag = perevesti("", True)
����20�����10.Props.Selectedtext = perevesti("", True)
����20�����10.Props.Selectionlength = perevesti("0", True)
����20�����10.Props.Name = perevesti("�����1", True)
����20�����10.Props.Maximumheight = perevesti("0", True)
����20�����10.Props.Maximumlength = perevesti("32767", True)
����20�����10.Props.Maximumwidth = perevesti("0", True)
����20�����10.Props.Minimumheight = perevesti("0", True)
����20�����10.Props.Minimumwidth = perevesti("0", True)
����20�����10.Props.Multiline = perevesti("���", True)
����20�����10.Props.Selectionstart = perevesti("1", True)
����20�����10.Props.Index = perevesti("0", True)
����20�����10.Props.Wordwrap = perevesti("��", True)
����20�����10.Props.ToolTip = perevesti("", True)
����20�����10.Props.Scrollbars = perevesti("���", True)
����20�����10.Props.Anchor = perevesti("�����_������", True)
����20�����10.Props.Enabled = perevesti("��", True)
����20�����10.Props.Allowinput = perevesti("���", True)
����20�����10.Props.Textposition = perevesti("�����", True)
����20�����10.Props.Dock = perevesti("�������", True)
����20�����10.Props.Passwordchar = perevesti("", True)
����20�����10.Props.Hideselection = perevesti("���", True)
����20�����10.Props.Borderstyle = perevesti("�����", True)
����20�����10.Props.Tabindex = perevesti("0", True)
����20�����10.Props.Tabstop = perevesti("��", True)
����20�����10.Props.Text = perevesti("", True)
����20�����10.Props.Readonly = perevesti("���", True)
����20�����10.Props.Backcolor = perevesti("�����", True)
����20�����10.Props.Forecolor = perevesti("������", True)
����20�����10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����20�����10.Props.Fontbold = perevesti("���", True)
����20�����10.Props.Fontstrikeout = perevesti("���", True)
����20�����10.Props.Fontitalic = perevesti("���", True)
����20�����10.Props.Fontunderline = perevesti("���", True)
����20�����10.Props.Fontsize = perevesti("8", True)
����20�����10.Props.Height = perevesti("20", True)
����20�����10.Props.Width = perevesti("307", True)
����20�����10.Props.Visible = perevesti("��", True)
����20�����10.Props.Height = perevesti("20", True)
����20�����10.Props.Width = perevesti("307", True)

ProgressForm.ProgressBar1.Value = 69
����20����_��������10.Props.X = perevesti("4", True)
����20����_��������10.Props.Y = perevesti("4", True)
����20����_��������10.Props.Tag = perevesti("", True)
����20����_��������10.Props.Multiselectfiles = perevesti("���", True)
����20����_��������10.Props.Defaultext = perevesti("", True)
����20����_��������10.Props.Title = perevesti("", True)
����20����_��������10.Props.Name = perevesti("���� ��������1", True)
����20����_��������10.Props.Filename = perevesti("", True)
����20����_��������10.Props.Initialdirectory = perevesti("", True)
����20����_��������10.Props.Index = perevesti("0", True)
����20����_��������10.Props.Filterindex = perevesti("1", True)
����20����_��������10.Props.Checkpathexists = perevesti("��", True)
����20����_��������10.Props.Checkfileexists = perevesti("��", True)
����20����_��������10.Props.Filter = perevesti("�������|*.jpg;*.bmp;*.png|��� �����|*.*", True)

ProgressForm.ProgressBar1.Value = 70
����30����30.Props.X = perevesti("0", True)
����30����30.Props.Y = perevesti("0", True)
����30����30.Props.Associatewithextensions = perevesti("", True)
����30����30.Props.Contextmenu(True) = perevesti("�������", True)
����30����30.Props.Tag = perevesti("", True)
����30����30.Props.Mainform = perevesti("���", True)
����30����30.Props.Mainmenustrip(True) = perevesti("�������", True)
����30����30.Props.AutoRun = perevesti("���", True)
����30����30.Props.Forbidclose = perevesti("���", True)
����30����30.Props.Forbidminimize = perevesti("���", True)
����30����30.Props.Forbidmaximize = perevesti("��", True)
����30����30.Props.Icon = perevesti("�������", True)
����30����30.Props.Name = perevesti("����3", True)
����30����30.Props.Cursor = perevesti("�������", True)
����30����30.Props.Maximumheight = perevesti("0", True)
����30����30.Props.Maximumwidth = perevesti("0", True)
����30����30.Props.Minimumheight = perevesti("0", True)
����30����30.Props.Minimumwidth = perevesti("0", True)
����30����30.Props.Index = perevesti("0", True)
����30����30.Props.Controlbox = perevesti("��", True)
����30����30.Props.Showintaskbar = perevesti("��", True)
����30����30.Props.Showintray = perevesti("���", True)
����30����30.Props.TopMost = perevesti("���", True)
����30����30.Props.ToolTip = perevesti("", True)
����30����30.Props.Showicon = perevesti("���", True)
����30����30.Props.Opacity = perevesti("100", True)
����30����30.Props.Transparentcykey = perevesti("�������", True)
����30����30.Props.Scroll = perevesti("���", True)
����30����30.Props.AutoscrollminSizeheight = perevesti("0", True)
����30����30.Props.AutoscrollminSizewidth = perevesti("0", True)
����30����30.Props.AutoscrollpositionX = perevesti("0", True)
����30����30.Props.AutoscrollpositionY = perevesti("0", True)
����30����30.Props.Enabled = perevesti("���", True)
����30����30.Props.Allowruncopies = perevesti("��", True)
����30����30.Props.Startposition = perevesti("�� ������ ������", True)
����30����30.StatusTemp = "����������"
����30����30.Props.Formborderstyle = perevesti("������������� ����", True)
����30����30.Props.Backgroundimagelayout = perevesti("������", True)
����30����30.Props.Tabindex = perevesti("0", True)
����30����30.Props.Tabstop = perevesti("��", True)
����30����30.Props.Text = perevesti("�����", True)
����30����30.Props.Backgroundimage = perevesti("�������", True)
����30����30.Props.Backcolor = perevesti("���������", True)
����30����30.Props.Forecolor = perevesti("������", True)
����30����30.Props.Height = perevesti("320", True)
����30����30.Props.Width = perevesti("500", True)
����30����30.Props.Visible = perevesti("���", True)
����30����30.Props.Height = perevesti("320", True)
����30����30.Props.Width = perevesti("500", True)

ProgressForm.ProgressBar1.Value = 71
����30���������_��������10.Props.X = perevesti("4", True)
����30���������_��������10.Props.Y = perevesti("4", True)
����30���������_��������10.Props.Contextmenu(True) = perevesti("�������", True)
����30���������_��������10.Props.Tag = perevesti("", True)
����30���������_��������10.Props.Selectedtext = perevesti("", True)
����30���������_��������10.Props.Selectionlength = perevesti("0", True)
����30���������_��������10.Props.Name = perevesti("��������� ��������1", True)
����30���������_��������10.Props.Maximumheight = perevesti("0", True)
����30���������_��������10.Props.Maximumlength = perevesti("32767", True)
����30���������_��������10.Props.Maximumwidth = perevesti("0", True)
����30���������_��������10.Props.Zoomfactor = perevesti("1", True)
����30���������_��������10.Props.Minimumheight = perevesti("0", True)
����30���������_��������10.Props.Minimumwidth = perevesti("0", True)
����30���������_��������10.Props.Multiline = perevesti("��", True)
����30���������_��������10.Props.Selectionstart = perevesti("1", True)
����30���������_��������10.Props.Index = perevesti("0", True)
����30���������_��������10.Props.Wordwrap = perevesti("���", True)
����30���������_��������10.Props.Internetlink = perevesti("��", True)
����30���������_��������10.Props.Detecturls = perevesti("��", True)
����30���������_��������10.Props.ToolTip = perevesti("", True)
����30���������_��������10.Props.Enableautodragdrop = perevesti("��", True)
����30���������_��������10.Props.Scrollbars = perevesti("������������", True)
����30���������_��������10.Props.Anchor = perevesti("�����_������", True)
����30���������_��������10.Props.Enabled = perevesti("��", True)
����30���������_��������10.Props.Dock = perevesti("�������", True)
����30���������_��������10.Props.Hideselection = perevesti("���", True)
����30���������_��������10.Props.Borderstyle = perevesti("�����", True)
����30���������_��������10.Props.Tabindex = perevesti("0", True)
����30���������_��������10.Props.Tabstop = perevesti("��", True)
����30���������_��������10.Props.Text = perevesti("[Sounds]�; IDS_SCHEME_DEFAULT�SchemeName=Gears of War Glass�[AppEvents\Schemes\Apps\.Default\.Default]�DefaultValue=%SystemRoot%\Resources\Themes\ //������.wav�[AppEvents\Schemes\Apps\.Default\ChangeTheme]�DefaultValue=%SystemRoot%\Resources\Themes\ //���� �����.wav�[AppEvents\Schemes\Apps\.Default\CriticalBatteryAlarm]�DefaultValue=%SystemRoot%\Resources\Themes\ //������� ��������.wav�[AppEvents\Schemes\Apps\.Default\DeviceConnect]�DefaultValue=%SystemRoot%\Resources\Themes\ //���������� �������.wav�[AppEvents\Schemes\Apps\.Default\DeviceDisconnect]�DefaultValue=%SystemRoot%\Resources\Themes\ //����������� ��������.wav�[AppEvents\Schemes\Apps\.Default\DeviceFail]�DefaultValue=%SystemRoot%\Resources\Themes\ //���������� �� �����.wav�[AppEvents\Schemes\Apps\.Default\FaxBeep]�DefaultValue=%SystemRoot%\Resources\Themes\ //�����������.wav�[AppEvents\Schemes\Apps\.Default\LowBatteryAlarm]�DefaultValue=%SystemRoot%\Resources\Themes\ //������� ���������.wav�[AppEvents\Schemes\Apps\.Default\MailBeep]�DefaultValue=%SystemRoot%\Resources\Themes\ //���� ������.wav�[AppEvents\Schemes\Apps\.Default\PrintComplete]�DefaultValue=%SystemRoot%\Resources\Themes\ //������ ���������.wav�[AppEvents\Schemes\Apps\.Default\SystemAsterisk]�DefaultValue=%SystemRoot%\Resources\Themes\ //������.wav�[AppEvents\Schemes\Apps\.Default\SystemExclamation]�DefaultValue=%SystemRoot%\Resources\Themes\ //�����������.wav�[AppEvents\Schemes\Apps\.Default\SystemExit]�DefaultValue=%SystemRoot%\Resources\Themes\ //����������.wav�[AppEvents\Schemes\Apps\.Default\SystemHand]�DefaultValue=%SystemRoot%\Resources\Themes\ //����������� ���������.wav�[AppEvents\Schemes\Apps\.Default\SystemNotification]�DefaultValue=%SystemRoot%\Resources\Themes\ //����������� �� �������.wav�[AppEvents\Schemes\Apps\.Default\WindowsLogoff]�DefaultValue=%SystemRoot%\Resources\Themes\ //����� �����.wav�[AppEvents\Schemes\Apps\.Default\WindowsLogon]�DefaultValue=%SystemRoot%\Resources\Themes\ //���� �����.wav�[AppEvents\Schemes\Apps\.Default\WindowsUAC]�DefaultValue=%SystemRoot%\Resources\Themes\ //�������� ������� �������.wav�[AppEvents\Schemes\Apps\Explorer\BlockedPopup]�DefaultValue=%SystemRoot%\Resources\Themes\ //���� �� ��������.wav�[AppEvents\Schemes\Apps\Explorer\EmptyRecycleBin]�DefaultValue=%SystemRoot%\Resources\Themes\ // ������.wav�[AppEvents\Schemes\Apps\Explorer\FaxError]�DefaultValue=%SystemRoot%\Resources\Themes\ //������ ������.wav�[AppEvents\Schemes\Apps\Explorer\FaxLineRings]�DefaultValue=%SystemRoot%\Resources\Themes\ //������ ����� �����.wav�[AppEvents\Schemes\Apps\Explorer\FeedDiscovered]�DefaultValue=%SystemRoot%\Resources\Themes\ //������� ����.wav�[AppEvents\Schemes\Apps\Explorer\Navigating]�DefaultValue=%SystemRoot%\Resources\Themes\ //��������� �����.wav�[AppEvents\Schemes\Apps\Explorer\SecurityBand]�DefaultValue=%SystemRoot%\Resources\Themes\ //���� ������.wav�", True)
����30���������_��������10.Props.Readonly = perevesti("���", True)
����30���������_��������10.Props.Backcolor = perevesti("�����", True)
����30���������_��������10.Props.Forecolor = perevesti("������", True)
����30���������_��������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����30���������_��������10.Props.Fontbold = perevesti("���", True)
����30���������_��������10.Props.Fontstrikeout = perevesti("���", True)
����30���������_��������10.Props.Fontitalic = perevesti("���", True)
����30���������_��������10.Props.Fontunderline = perevesti("���", True)
����30���������_��������10.Props.Fontsize = perevesti("8", True)
����30���������_��������10.Props.Height = perevesti("287", True)
����30���������_��������10.Props.Width = perevesti("411", True)
����30���������_��������10.Props.Visible = perevesti("��", True)
����30���������_��������10.Props.Height = perevesti("287", True)
����30���������_��������10.Props.Width = perevesti("411", True)
����30���������_��������10.Props.Rtf = perevesti("{\rtf1\ansi\ansicpg1251\deff0{\fonttbl{\f0\fnil\fcharset204 Microsoft Sans Serif;}}�\viewkind4\uc1\pard\lang1049\f0\fs17 [Sounds]\par�; IDS_SCHEME_DEFAULT\par�SchemeName=Gears of War Glass\par�[AppEvents\\Schemes\\Apps\\.Default\\.Default]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e7\'e2\'ee\'ed\'ee\'ea.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\ChangeTheme]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'f5\'ee\'e4 \'e7\'e2\'f3\'ea\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\CriticalBatteryAlarm]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e1\'e0\'f2\'e0\'f0\'e5\'ff \'ea\'f0\'e8\'f2\'e8\'f7\'ed\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\DeviceConnect]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e0\'ef\'ef\'e0\'f0\'e0\'f2\'ed\'e0\'ff \'e2\'f1\'f2\'e0\'e2\'ea\'e8.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\DeviceDisconnect]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e0\'ef\'ef\'e0\'f0\'e0\'f2\'ed\'ee\'e3\'ee \'f3\'e4\'e0\'eb\'e5\'ed\'e8\'ff.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\DeviceFail]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e0\'ef\'ef\'e0\'f0\'e0\'f2\'ed\'e0\'ff \'ed\'e5 \'f3\'e4\'e0\'f7\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\FaxBeep]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ef\'ee\'e4\'ef\'e8\'f1\'e0\'f2\'fc\'f1\'ff.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\LowBatteryAlarm]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e1\'e0\'f2\'e0\'f0\'e5\'ff \'f0\'e0\'e7\'f0\'ff\'e6\'e5\'ed\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\MailBeep]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ec\'e0\'e9\'eb \'f1\'e8\'e3\'ed\'e0\'eb.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\PrintComplete]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ef\'e5\'f7\'e0\'f2\'fc \'e7\'e0\'e2\'e5\'f0\'f8\'e5\'ed\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\SystemAsterisk]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ee\'f8\'e8\'e1\'ea\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\SystemExclamation]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'ee\'f1\'ea\'eb\'e8\'f6\'e0\'ed\'e8\'e5.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\SystemExit]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'fb\'ea\'eb\'fe\'f7\'e5\'ed\'e8\'e5.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\SystemHand]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ea\'f0\'e8\'f2\'e8\'f7\'e5\'f1\'ea\'e0\'ff \'ee\'f1\'f2\'e0\'ed\'ee\'e2\'ea\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\SystemNotification]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ec\'ee\'e4\'e8\'f4\'e8\'ea\'e0\'f6\'e8\'ff \'ed\'e5 \'f1\'e4\'e5\'eb\'e0\'ed\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\WindowsLogoff]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'fb\'f5\'ee\'e4 \'e7\'e2\'f3\'ea\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\WindowsLogon]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e2\'f5\'ee\'e4 \'e7\'e2\'f3\'ea\'e0.wav\par�[AppEvents\\Schemes\\Apps\\.Default\\WindowsUAC]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ea\'ee\'ed\'f2\'f0\'ee\'eb\'fc \'f3\'f7\'e5\'f2\'ed\'fb\'f5 \'e7\'e0\'ef\'e8\'f1\'e5\'e9.wav\par�[AppEvents\\Schemes\\Apps\\Explorer\\BlockedPopup]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ee\'ea\'ed\'ee \'ed\'e5 \'ee\'f2\'e2\'e5\'f7\'e0\'e5\'f2.wav\par�[AppEvents\\Schemes\\Apps\\Explorer\\EmptyRecycleBin]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ // \'f0\'e5\'f6\'e8\'ea\'eb.wav\par�[AppEvents\\Schemes\\Apps\\Explorer\\FaxError]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e7\'e2\'ee\'ed\'ee\'ea \'ee\'f8\'e8\'e1\'ea\'e8.wav\par�[AppEvents\\Schemes\\Apps\\Explorer\\FaxLineRings]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ea\'ee\'eb\'fc\'f6\'e0 \'eb\'e8\'ed\'e8\'e8 \'f4\'e0\'ea\'f1\'e0.wav\par�[AppEvents\\Schemes\\Apps\\Explorer\\FeedDiscovered]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ef\'e8\'f2\'e0\'ed\'e8\'e5 \'e5\'f1\'f2\'fc.wav\par�[AppEvents\\Schemes\\Apps\\Explorer\\Navigating]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'ed\'e0\'e2\'e8\'e3\'e0\'f6\'e8\'ff \'f1\'f2\'e0\'f0\'f2.wav\par�[AppEvents\\Schemes\\Apps\\Explorer\\SecurityBand]\par�DefaultValue=%SystemRoot%\\Resources\\Themes\\ //\'e8\'ed\'f4\'ee \'ef\'e0\'ed\'e5\'eb\'fc.wav\par�\par�}�", True)

ProgressForm.ProgressBar1.Value = 72
����30������10.Props.X = perevesti("420", True)
����30������10.Props.Y = perevesti("4", True)
����30������10.Props.Autoellipsis = perevesti("��", True)
����30������10.Props.Contextmenu(True) = perevesti("�������", True)
����30������10.Props.Tag = perevesti("", True)
����30������10.Props.Name = perevesti("������1", True)
����30������10.Props.Cursor = perevesti("�������", True)
����30������10.Props.Maximumheight = perevesti("0", True)
����30������10.Props.Maximumwidth = perevesti("0", True)
����30������10.Props.Minimumheight = perevesti("0", True)
����30������10.Props.Minimumwidth = perevesti("0", True)
����30������10.Props.Index = perevesti("0", True)
����30������10.Props.ToolTip = perevesti("", True)
����30������10.Props.Paddingtop = perevesti("0", True)
����30������10.Props.Paddingleft = perevesti("0", True)
����30������10.Props.Paddingbottom = perevesti("0", True)
����30������10.Props.Paddingright = perevesti("0", True)
����30������10.Props.Imagealign = perevesti("�����", True)
����30������10.Props.Textalign = perevesti("�����", True)
����30������10.Props.Anchor = perevesti("�����_������", True)
����30������10.Props.Enabled = perevesti("��", True)
����30������10.Props.Dock = perevesti("�������", True)
����30������10.Props.Image = perevesti("�������", True)
����30������10.Props.Flatstyle = perevesti("�������", True)
����30������10.Props.Backgroundimagelayout = perevesti("������", True)
����30������10.Props.Tabindex = perevesti("0", True)
����30������10.Props.Tabstop = perevesti("��", True)
����30������10.Props.Text = perevesti("�����", True)
����30������10.Props.Textimagerelation = perevesti("������", True)
����30������10.Props.Backgroundimage = perevesti("�������", True)
����30������10.Props.Backcolor = perevesti("�������", True)
����30������10.Props.Forecolor = perevesti("������", True)
����30������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����30������10.Props.Fontbold = perevesti("���", True)
����30������10.Props.Fontstrikeout = perevesti("���", True)
����30������10.Props.Fontitalic = perevesti("���", True)
����30������10.Props.Fontunderline = perevesti("���", True)
����30������10.Props.Fontsize = perevesti("8", True)
����30������10.Props.Height = perevesti("23", True)
����30������10.Props.Width = perevesti("75", True)
����30������10.Props.Visible = perevesti("��", True)
����30������10.Props.Height = perevesti("23", True)
����30������10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 73
����30������20.Props.X = perevesti("424", True)
����30������20.Props.Y = perevesti("296", True)
����30������20.Props.Autoellipsis = perevesti("��", True)
����30������20.Props.Contextmenu(True) = perevesti("�������", True)
����30������20.Props.Tag = perevesti("", True)
����30������20.Props.Name = perevesti("������2", True)
����30������20.Props.Cursor = perevesti("�������", True)
����30������20.Props.Maximumheight = perevesti("0", True)
����30������20.Props.Maximumwidth = perevesti("0", True)
����30������20.Props.Minimumheight = perevesti("0", True)
����30������20.Props.Minimumwidth = perevesti("0", True)
����30������20.Props.Index = perevesti("0", True)
����30������20.Props.ToolTip = perevesti("", True)
����30������20.Props.Paddingtop = perevesti("0", True)
����30������20.Props.Paddingleft = perevesti("0", True)
����30������20.Props.Paddingbottom = perevesti("0", True)
����30������20.Props.Paddingright = perevesti("0", True)
����30������20.Props.Imagealign = perevesti("�����", True)
����30������20.Props.Textalign = perevesti("�����", True)
����30������20.Props.Anchor = perevesti("�����_������", True)
����30������20.Props.Enabled = perevesti("��", True)
����30������20.Props.Dock = perevesti("�������", True)
����30������20.Props.Image = perevesti("�������", True)
����30������20.Props.Flatstyle = perevesti("�������", True)
����30������20.Props.Backgroundimagelayout = perevesti("������", True)
����30������20.Props.Tabindex = perevesti("0", True)
����30������20.Props.Tabstop = perevesti("��", True)
����30������20.Props.Text = perevesti("�������", True)
����30������20.Props.Textimagerelation = perevesti("������", True)
����30������20.Props.Backgroundimage = perevesti("�������", True)
����30������20.Props.Backcolor = perevesti("�������", True)
����30������20.Props.Forecolor = perevesti("������", True)
����30������20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����30������20.Props.Fontbold = perevesti("���", True)
����30������20.Props.Fontstrikeout = perevesti("���", True)
����30������20.Props.Fontitalic = perevesti("���", True)
����30������20.Props.Fontunderline = perevesti("���", True)
����30������20.Props.Fontsize = perevesti("8", True)
����30������20.Props.Height = perevesti("23", True)
����30������20.Props.Width = perevesti("75", True)
����30������20.Props.Visible = perevesti("��", True)
����30������20.Props.Height = perevesti("23", True)
����30������20.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 74
����30�����10.Props.X = perevesti("4", True)
����30�����10.Props.Y = perevesti("296", True)
����30�����10.Props.Contextmenu(True) = perevesti("�������", True)
����30�����10.Props.Tag = perevesti("", True)
����30�����10.Props.Selectedtext = perevesti("", True)
����30�����10.Props.Selectionlength = perevesti("0", True)
����30�����10.Props.Name = perevesti("�����1", True)
����30�����10.Props.Maximumheight = perevesti("0", True)
����30�����10.Props.Maximumlength = perevesti("32767", True)
����30�����10.Props.Maximumwidth = perevesti("0", True)
����30�����10.Props.Minimumheight = perevesti("0", True)
����30�����10.Props.Minimumwidth = perevesti("0", True)
����30�����10.Props.Multiline = perevesti("���", True)
����30�����10.Props.Selectionstart = perevesti("1", True)
����30�����10.Props.Index = perevesti("0", True)
����30�����10.Props.Wordwrap = perevesti("��", True)
����30�����10.Props.ToolTip = perevesti("", True)
����30�����10.Props.Scrollbars = perevesti("���", True)
����30�����10.Props.Anchor = perevesti("�����_������", True)
����30�����10.Props.Enabled = perevesti("��", True)
����30�����10.Props.Allowinput = perevesti("���", True)
����30�����10.Props.Textposition = perevesti("�����", True)
����30�����10.Props.Dock = perevesti("�������", True)
����30�����10.Props.Passwordchar = perevesti("", True)
����30�����10.Props.Hideselection = perevesti("���", True)
����30�����10.Props.Borderstyle = perevesti("�����", True)
����30�����10.Props.Tabindex = perevesti("0", True)
����30�����10.Props.Tabstop = perevesti("��", True)
����30�����10.Props.Text = perevesti("", True)
����30�����10.Props.Readonly = perevesti("���", True)
����30�����10.Props.Backcolor = perevesti("�����", True)
����30�����10.Props.Forecolor = perevesti("������", True)
����30�����10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����30�����10.Props.Fontbold = perevesti("���", True)
����30�����10.Props.Fontstrikeout = perevesti("���", True)
����30�����10.Props.Fontitalic = perevesti("���", True)
����30�����10.Props.Fontunderline = perevesti("���", True)
����30�����10.Props.Fontsize = perevesti("8", True)
����30�����10.Props.Height = perevesti("20", True)
����30�����10.Props.Width = perevesti("343", True)
����30�����10.Props.Visible = perevesti("��", True)
����30�����10.Props.Height = perevesti("20", True)
����30�����10.Props.Width = perevesti("343", True)

ProgressForm.ProgressBar1.Value = 75
����30����_��������10.Props.X = perevesti("4", True)
����30����_��������10.Props.Y = perevesti("4", True)
����30����_��������10.Props.Tag = perevesti("", True)
����30����_��������10.Props.Multiselectfiles = perevesti("���", True)
����30����_��������10.Props.Defaultext = perevesti("", True)
����30����_��������10.Props.Title = perevesti("", True)
����30����_��������10.Props.Name = perevesti("���� ��������1", True)
����30����_��������10.Props.Filename = perevesti("", True)
����30����_��������10.Props.Initialdirectory = perevesti("", True)
����30����_��������10.Props.Index = perevesti("0", True)
����30����_��������10.Props.Filterindex = perevesti("1", True)
����30����_��������10.Props.Checkpathexists = perevesti("��", True)
����30����_��������10.Props.Checkfileexists = perevesti("��", True)
����30����_��������10.Props.Filter = perevesti("�������|*.wav;*.mp3|��� �����|*.*", True)

ProgressForm.ProgressBar1.Value = 76
����30������30.Props.X = perevesti("348", True)
����30������30.Props.Y = perevesti("296", True)
����30������30.Props.Autoellipsis = perevesti("��", True)
����30������30.Props.Contextmenu(True) = perevesti("�������", True)
����30������30.Props.Tag = perevesti("", True)
����30������30.Props.Name = perevesti("������3", True)
����30������30.Props.Cursor = perevesti("�������", True)
����30������30.Props.Maximumheight = perevesti("0", True)
����30������30.Props.Maximumwidth = perevesti("0", True)
����30������30.Props.Minimumheight = perevesti("0", True)
����30������30.Props.Minimumwidth = perevesti("0", True)
����30������30.Props.Index = perevesti("0", True)
����30������30.Props.ToolTip = perevesti("", True)
����30������30.Props.Paddingtop = perevesti("0", True)
����30������30.Props.Paddingleft = perevesti("0", True)
����30������30.Props.Paddingbottom = perevesti("0", True)
����30������30.Props.Paddingright = perevesti("0", True)
����30������30.Props.Imagealign = perevesti("�����", True)
����30������30.Props.Textalign = perevesti("�����", True)
����30������30.Props.Anchor = perevesti("�����_������", True)
����30������30.Props.Enabled = perevesti("��", True)
����30������30.Props.Dock = perevesti("�������", True)
����30������30.Props.Image = perevesti("�������", True)
����30������30.Props.Flatstyle = perevesti("�������", True)
����30������30.Props.Backgroundimagelayout = perevesti("������", True)
����30������30.Props.Tabindex = perevesti("0", True)
����30������30.Props.Tabstop = perevesti("��", True)
����30������30.Props.Text = perevesti("����������", True)
����30������30.Props.Textimagerelation = perevesti("������", True)
����30������30.Props.Backgroundimage = perevesti("�������", True)
����30������30.Props.Backcolor = perevesti("�������", True)
����30������30.Props.Forecolor = perevesti("������", True)
����30������30.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����30������30.Props.Fontbold = perevesti("���", True)
����30������30.Props.Fontstrikeout = perevesti("���", True)
����30������30.Props.Fontitalic = perevesti("���", True)
����30������30.Props.Fontunderline = perevesti("���", True)
����30������30.Props.Fontsize = perevesti("8", True)
����30������30.Props.Height = perevesti("23", True)
����30������30.Props.Width = perevesti("75", True)
����30������30.Props.Visible = perevesti("��", True)
����30������30.Props.Height = perevesti("23", True)
����30������30.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 77
����40����40.Props.X = perevesti("0", True)
����40����40.Props.Y = perevesti("0", True)
����40����40.Props.Associatewithextensions = perevesti("", True)
����40����40.Props.Contextmenu(True) = perevesti("�������", True)
����40����40.Props.Tag = perevesti("", True)
����40����40.Props.Mainform = perevesti("���", True)
����40����40.Props.Mainmenustrip(True) = perevesti("�������", True)
����40����40.Props.AutoRun = perevesti("���", True)
����40����40.Props.Forbidclose = perevesti("���", True)
����40����40.Props.Forbidminimize = perevesti("���", True)
����40����40.Props.Forbidmaximize = perevesti("��", True)
����40����40.Props.Icon = perevesti("�������", True)
����40����40.Props.Name = perevesti("����4", True)
����40����40.Props.Cursor = perevesti("�������", True)
����40����40.Props.Maximumheight = perevesti("0", True)
����40����40.Props.Maximumwidth = perevesti("0", True)
����40����40.Props.Minimumheight = perevesti("0", True)
����40����40.Props.Minimumwidth = perevesti("0", True)
����40����40.Props.Index = perevesti("0", True)
����40����40.Props.Controlbox = perevesti("��", True)
����40����40.Props.Showintaskbar = perevesti("��", True)
����40����40.Props.Showintray = perevesti("���", True)
����40����40.Props.TopMost = perevesti("���", True)
����40����40.Props.ToolTip = perevesti("", True)
����40����40.Props.Showicon = perevesti("���", True)
����40����40.Props.Opacity = perevesti("100", True)
����40����40.Props.Transparentcykey = perevesti("�������", True)
����40����40.Props.Scroll = perevesti("���", True)
����40����40.Props.AutoscrollminSizeheight = perevesti("0", True)
����40����40.Props.AutoscrollminSizewidth = perevesti("0", True)
����40����40.Props.AutoscrollpositionX = perevesti("0", True)
����40����40.Props.AutoscrollpositionY = perevesti("0", True)
����40����40.Props.Enabled = perevesti("���", True)
����40����40.Props.Allowruncopies = perevesti("��", True)
����40����40.Props.Startposition = perevesti("�� ������ ������", True)
����40����40.StatusTemp = "����������"
����40����40.Props.Formborderstyle = perevesti("������������� ����", True)
����40����40.Props.Backgroundimagelayout = perevesti("������", True)
����40����40.Props.Tabindex = perevesti("0", True)
����40����40.Props.Tabstop = perevesti("��", True)
����40����40.Props.Text = perevesti("���������� ��������", True)
����40����40.Props.Backgroundimage = perevesti("�������", True)
����40����40.Props.Backcolor = perevesti("���������", True)
����40����40.Props.Forecolor = perevesti("������", True)
����40����40.Props.Height = perevesti("323", True)
����40����40.Props.Width = perevesti("503", True)
����40����40.Props.Visible = perevesti("���", True)
����40����40.Props.Height = perevesti("323", True)
����40����40.Props.Width = perevesti("503", True)

ProgressForm.ProgressBar1.Value = 78
����40���������_��������10.Props.X = perevesti("4", True)
����40���������_��������10.Props.Y = perevesti("4", True)
����40���������_��������10.Props.Contextmenu(True) = perevesti("�������", True)
����40���������_��������10.Props.Tag = perevesti("", True)
����40���������_��������10.Props.Selectedtext = perevesti("", True)
����40���������_��������10.Props.Selectionlength = perevesti("0", True)
����40���������_��������10.Props.Name = perevesti("��������� ��������1", True)
����40���������_��������10.Props.Maximumheight = perevesti("0", True)
����40���������_��������10.Props.Maximumlength = perevesti("32767", True)
����40���������_��������10.Props.Maximumwidth = perevesti("0", True)
����40���������_��������10.Props.Zoomfactor = perevesti("1", True)
����40���������_��������10.Props.Minimumheight = perevesti("0", True)
����40���������_��������10.Props.Minimumwidth = perevesti("0", True)
����40���������_��������10.Props.Multiline = perevesti("��", True)
����40���������_��������10.Props.Selectionstart = perevesti("1", True)
����40���������_��������10.Props.Index = perevesti("0", True)
����40���������_��������10.Props.Wordwrap = perevesti("���", True)
����40���������_��������10.Props.Internetlink = perevesti("��", True)
����40���������_��������10.Props.Detecturls = perevesti("��", True)
����40���������_��������10.Props.ToolTip = perevesti("", True)
����40���������_��������10.Props.Enableautodragdrop = perevesti("��", True)
����40���������_��������10.Props.Scrollbars = perevesti("������������", True)
����40���������_��������10.Props.Anchor = perevesti("�����_������", True)
����40���������_��������10.Props.Enabled = perevesti("��", True)
����40���������_��������10.Props.Dock = perevesti("�������", True)
����40���������_��������10.Props.Hideselection = perevesti("���", True)
����40���������_��������10.Props.Borderstyle = perevesti("�����", True)
����40���������_��������10.Props.Tabindex = perevesti("0", True)
����40���������_��������10.Props.Tabstop = perevesti("��", True)
����40���������_��������10.Props.Text = perevesti("��[Slideshow]�Interval=1800000�Shuffle=0�ImagesRootPath=%SystemRoot%\Resources\Themes\ //����� � ���������Item0Path=%SystemRoot%\Resources\Themes\ //1 �������Item1Path=%SystemRoot%\Resources\Themes\ //2 �������Item2Path=%SystemRoot%\Resources\Themes\ //3 �������Item3Path=%SystemRoot%\Resources\Themes\ //4 �������Item4Path=%SystemRoot%\Resources\Themes\ //5 �������Item5Path=%SystemRoot%\Resources\Themes\ //6 ������귷", True)
����40���������_��������10.Props.Readonly = perevesti("���", True)
����40���������_��������10.Props.Backcolor = perevesti("�����", True)
����40���������_��������10.Props.Forecolor = perevesti("������", True)
����40���������_��������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����40���������_��������10.Props.Fontbold = perevesti("���", True)
����40���������_��������10.Props.Fontstrikeout = perevesti("���", True)
����40���������_��������10.Props.Fontitalic = perevesti("���", True)
����40���������_��������10.Props.Fontunderline = perevesti("���", True)
����40���������_��������10.Props.Fontsize = perevesti("8", True)
����40���������_��������10.Props.Height = perevesti("315", True)
����40���������_��������10.Props.Width = perevesti("419", True)
����40���������_��������10.Props.Visible = perevesti("��", True)
����40���������_��������10.Props.Height = perevesti("315", True)
����40���������_��������10.Props.Width = perevesti("419", True)
����40���������_��������10.Props.Rtf = perevesti("{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset204 Microsoft Sans Serif;}}�\viewkind4\uc1\pard\lang1049\f0\fs17\par�\par�[Slideshow]\par�Interval=1800000\par�Shuffle=0\par�ImagesRootPath=%SystemRoot%\\Resources\\Themes\\ //\'ef\'e0\'ef\'ea\'e0 \'f1 \'f0\'e8\'f1\'f3\'ed\'ea\'e0\'ec\'e8\par�Item0Path=%SystemRoot%\\Resources\\Themes\\ //1 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par�Item1Path=%SystemRoot%\\Resources\\Themes\\ //2 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par�Item2Path=%SystemRoot%\\Resources\\Themes\\ //3 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par�Item3Path=%SystemRoot%\\Resources\\Themes\\ //4 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par�Item4Path=%SystemRoot%\\Resources\\Themes\\ //5 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par�Item5Path=%SystemRoot%\\Resources\\Themes\\ //6 \'f0\'e8\'f1\'f3\'ed\'ee\'ea\par�\par�\par�}�", True)

ProgressForm.ProgressBar1.Value = 79
����40������10.Props.X = perevesti("424", True)
����40������10.Props.Y = perevesti("4", True)
����40������10.Props.Autoellipsis = perevesti("��", True)
����40������10.Props.Contextmenu(True) = perevesti("�������", True)
����40������10.Props.Tag = perevesti("", True)
����40������10.Props.Name = perevesti("������1", True)
����40������10.Props.Cursor = perevesti("�������", True)
����40������10.Props.Maximumheight = perevesti("0", True)
����40������10.Props.Maximumwidth = perevesti("0", True)
����40������10.Props.Minimumheight = perevesti("0", True)
����40������10.Props.Minimumwidth = perevesti("0", True)
����40������10.Props.Index = perevesti("0", True)
����40������10.Props.ToolTip = perevesti("", True)
����40������10.Props.Paddingtop = perevesti("0", True)
����40������10.Props.Paddingleft = perevesti("0", True)
����40������10.Props.Paddingbottom = perevesti("0", True)
����40������10.Props.Paddingright = perevesti("0", True)
����40������10.Props.Imagealign = perevesti("�����", True)
����40������10.Props.Textalign = perevesti("�����", True)
����40������10.Props.Anchor = perevesti("�����_������", True)
����40������10.Props.Enabled = perevesti("��", True)
����40������10.Props.Dock = perevesti("�������", True)
����40������10.Props.Image = perevesti("�������", True)
����40������10.Props.Flatstyle = perevesti("�������", True)
����40������10.Props.Backgroundimagelayout = perevesti("������", True)
����40������10.Props.Tabindex = perevesti("0", True)
����40������10.Props.Tabstop = perevesti("��", True)
����40������10.Props.Text = perevesti("�������", True)
����40������10.Props.Textimagerelation = perevesti("������", True)
����40������10.Props.Backgroundimage = perevesti("�������", True)
����40������10.Props.Backcolor = perevesti("�������", True)
����40������10.Props.Forecolor = perevesti("������", True)
����40������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����40������10.Props.Fontbold = perevesti("���", True)
����40������10.Props.Fontstrikeout = perevesti("���", True)
����40������10.Props.Fontitalic = perevesti("���", True)
����40������10.Props.Fontunderline = perevesti("���", True)
����40������10.Props.Fontsize = perevesti("8", True)
����40������10.Props.Height = perevesti("23", True)
����40������10.Props.Width = perevesti("75", True)
����40������10.Props.Visible = perevesti("��", True)
����40������10.Props.Height = perevesti("23", True)
����40������10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 80
����40������20.Props.X = perevesti("424", True)
����40������20.Props.Y = perevesti("28", True)
����40������20.Props.Autoellipsis = perevesti("��", True)
����40������20.Props.Contextmenu(True) = perevesti("�������", True)
����40������20.Props.Tag = perevesti("", True)
����40������20.Props.Name = perevesti("������2", True)
����40������20.Props.Cursor = perevesti("�������", True)
����40������20.Props.Maximumheight = perevesti("0", True)
����40������20.Props.Maximumwidth = perevesti("0", True)
����40������20.Props.Minimumheight = perevesti("0", True)
����40������20.Props.Minimumwidth = perevesti("0", True)
����40������20.Props.Index = perevesti("0", True)
����40������20.Props.ToolTip = perevesti("", True)
����40������20.Props.Paddingtop = perevesti("0", True)
����40������20.Props.Paddingleft = perevesti("0", True)
����40������20.Props.Paddingbottom = perevesti("0", True)
����40������20.Props.Paddingright = perevesti("0", True)
����40������20.Props.Imagealign = perevesti("�����", True)
����40������20.Props.Textalign = perevesti("�����", True)
����40������20.Props.Anchor = perevesti("�����_������", True)
����40������20.Props.Enabled = perevesti("��", True)
����40������20.Props.Dock = perevesti("�������", True)
����40������20.Props.Image = perevesti("�������", True)
����40������20.Props.Flatstyle = perevesti("�������", True)
����40������20.Props.Backgroundimagelayout = perevesti("������", True)
����40������20.Props.Tabindex = perevesti("0", True)
����40������20.Props.Tabstop = perevesti("��", True)
����40������20.Props.Text = perevesti("������", True)
����40������20.Props.Textimagerelation = perevesti("������", True)
����40������20.Props.Backgroundimage = perevesti("�������", True)
����40������20.Props.Backcolor = perevesti("�������", True)
����40������20.Props.Forecolor = perevesti("������", True)
����40������20.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����40������20.Props.Fontbold = perevesti("���", True)
����40������20.Props.Fontstrikeout = perevesti("���", True)
����40������20.Props.Fontitalic = perevesti("���", True)
����40������20.Props.Fontunderline = perevesti("���", True)
����40������20.Props.Fontsize = perevesti("8", True)
����40������20.Props.Height = perevesti("23", True)
����40������20.Props.Width = perevesti("75", True)
����40������20.Props.Visible = perevesti("��", True)
����40������20.Props.Height = perevesti("23", True)
����40������20.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 81
����40������10.Props.X = perevesti("4", True)
����40������10.Props.Y = perevesti("4", True)
����40������10.Props.Tag = perevesti("", True)
����40������10.Props.Name = perevesti("������1", True)
����40������10.Props.Index = perevesti("0", True)
����40������10.Props.Enabled = perevesti("��", True)
����40������10.Props.Value = perevesti("", True)

ProgressForm.ProgressBar1.Value = 82
����40������20.Props.X = perevesti("32", True)
����40������20.Props.Y = perevesti("4", True)
����40������20.Props.Tag = perevesti("", True)
����40������20.Props.Name = perevesti("������2", True)
����40������20.Props.Index = perevesti("0", True)
����40������20.Props.Enabled = perevesti("��", True)
����40������20.Props.Value = perevesti("�[Control Panel\Cursors]�AppStarting=%SystemRoot%\cursors\aero_working.ani�Arrow=%SystemRoot%\cursors\aero_arrow.cur�Crosshair=�Hand=%SystemRoot%\cursors\aero_link.cur�Help=%SystemRoot%\cursors\aero_helpsel.cur�IBeam=�No=%SystemRoot%\cursors\aero_unavail.cur�NWPen=%SystemRoot%\cursors\aero_pen.cur�SizeAll=%SystemRoot%\cursors\aero_move.cur�SizeNESW=%SystemRoot%\cursors\aero_nesw.cur�SizeNS=%SystemRoot%\cursors\aero_ns.cur�SizeNWSE=%SystemRoot%\cursors\aero_nwse.cur�SizeWE=%SystemRoot%\cursors\aero_ew.cur�UpArrow=%SystemRoot%\cursors\aero_up.cur�Wait=%SystemRoot%\cursors\aero_busy.ani�DefaultValue=Windows Aero�Link=��[Control Panel\Desktop]�Wallpaper=%SystemRoot%\Resources\Themes\", True)

ProgressForm.ProgressBar1.Value = 83
����40������30.Props.X = perevesti("60", True)
����40������30.Props.Y = perevesti("4", True)
����40������30.Props.Tag = perevesti("�TileWallpaper=0�WallpaperStyle=10�Pattern=��[VisualStyles]�Path=%SystemRoot%\Resources\Themes\new\new.msstyles�ColorStyle=NormalColor�Size=NormalSize�ColorizationColor=0X1A000000�Transparency=1�Composition=1�VisualStyleVersion=10��[boot]�SCRNSAVE.EXE=��[MasterThemeSelector]�MTSM=DABJDKT�", True)
����40������30.Props.Name = perevesti("������3", True)
����40������30.Props.Index = perevesti("0", True)
����40������30.Props.Enabled = perevesti("��", True)
����40������30.Props.Value = perevesti("", True)

ProgressForm.ProgressBar1.Value = 84
����40����_����������10.Props.X = perevesti("8", True)
����40����_����������10.Props.Y = perevesti("8", True)
����40����_����������10.Props.Tag = perevesti("", True)
����40����_����������10.Props.Defaultext = perevesti("", True)
����40����_����������10.Props.Title = perevesti("", True)
����40����_����������10.Props.Name = perevesti("���� ����������1", True)
����40����_����������10.Props.Filename = perevesti("", True)
����40����_����������10.Props.Initialdirectory = perevesti("", True)
����40����_����������10.Props.Index = perevesti("0", True)
����40����_����������10.Props.Filterindex = perevesti("1", True)
����40����_����������10.Props.Checkpathexists = perevesti("��", True)
����40����_����������10.Props.Checkfileexists = perevesti("���", True)
����40����_����������10.Props.Filter = perevesti("����|*.theme", True)

ProgressForm.ProgressBar1.Value = 85
����40�������10.Props.X = perevesti("428", True)
����40�������10.Props.Y = perevesti("304", True)
����40�������10.Props.Autoellipsis = perevesti("��", True)
����40�������10.Props.Contextmenu(True) = perevesti("�������", True)
����40�������10.Props.Tag = perevesti("", True)
����40�������10.Props.Name = perevesti("�������1", True)
����40�������10.Props.Cursor = perevesti("�������", True)
����40�������10.Props.Maximumheight = perevesti("0", True)
����40�������10.Props.Maximumwidth = perevesti("0", True)
����40�������10.Props.Minimumheight = perevesti("0", True)
����40�������10.Props.Minimumwidth = perevesti("0", True)
����40�������10.Props.Index = perevesti("0", True)
����40�������10.Props.ToolTip = perevesti("", True)
����40�������10.Props.Paddingtop = perevesti("0", True)
����40�������10.Props.Paddingleft = perevesti("0", True)
����40�������10.Props.Paddingbottom = perevesti("0", True)
����40�������10.Props.Paddingright = perevesti("0", True)
����40�������10.Props.Imagealign = perevesti("�����", True)
����40�������10.Props.Textalign = perevesti("�����", True)
����40�������10.Props.Anchor = perevesti("�����_������", True)
����40�������10.Props.Enabled = perevesti("��", True)
����40�������10.Props.Dock = perevesti("�������", True)
����40�������10.Props.Image = perevesti("�������", True)
����40�������10.Props.Borderstyle = perevesti("�������", True)
����40�������10.Props.Backgroundimagelayout = perevesti("������", True)
����40�������10.Props.Tabindex = perevesti("0", True)
����40�������10.Props.Tabstop = perevesti("��", True)
����40�������10.Props.Text = perevesti("����������", True)
����40�������10.Props.Backgroundimage = perevesti("�������", True)
����40�������10.Props.Backcolor = perevesti("���������", True)
����40�������10.Props.Forecolor = perevesti("������", True)
����40�������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����40�������10.Props.Fontbold = perevesti("���", True)
����40�������10.Props.Fontstrikeout = perevesti("���", True)
����40�������10.Props.Fontitalic = perevesti("���", True)
����40�������10.Props.Fontunderline = perevesti("���", True)
����40�������10.Props.Fontsize = perevesti("8", True)
����40�������10.Props.Height = perevesti("15", True)
����40�������10.Props.Width = perevesti("71", True)
����40�������10.Props.Visible = perevesti("��", True)
����40�������10.Props.Height = perevesti("15", True)
����40�������10.Props.Width = perevesti("71", True)

ProgressForm.ProgressBar1.Value = 86
����50����50.Props.X = perevesti("0", True)
����50����50.Props.Y = perevesti("0", True)
����50����50.Props.Associatewithextensions = perevesti("", True)
����50����50.Props.Contextmenu(True) = perevesti("�������", True)
����50����50.Props.Tag = perevesti("", True)
����50����50.Props.Mainform = perevesti("���", True)
����50����50.Props.Mainmenustrip(True) = perevesti("�������", True)
����50����50.Props.AutoRun = perevesti("���", True)
����50����50.Props.Forbidclose = perevesti("���", True)
����50����50.Props.Forbidminimize = perevesti("���", True)
����50����50.Props.Forbidmaximize = perevesti("��", True)
����50����50.Props.Icon = perevesti("�������", True)
����50����50.Props.Name = perevesti("����5", True)
����50����50.Props.Cursor = perevesti("�������", True)
����50����50.Props.Maximumheight = perevesti("0", True)
����50����50.Props.Maximumwidth = perevesti("0", True)
����50����50.Props.Minimumheight = perevesti("0", True)
����50����50.Props.Minimumwidth = perevesti("0", True)
����50����50.Props.Index = perevesti("0", True)
����50����50.Props.Controlbox = perevesti("��", True)
����50����50.Props.Showintaskbar = perevesti("��", True)
����50����50.Props.Showintray = perevesti("���", True)
����50����50.Props.TopMost = perevesti("���", True)
����50����50.Props.ToolTip = perevesti("", True)
����50����50.Props.Showicon = perevesti("���", True)
����50����50.Props.Opacity = perevesti("100", True)
����50����50.Props.Transparentcykey = perevesti("�������", True)
����50����50.Props.Scroll = perevesti("���", True)
����50����50.Props.AutoscrollminSizeheight = perevesti("0", True)
����50����50.Props.AutoscrollminSizewidth = perevesti("0", True)
����50����50.Props.AutoscrollpositionX = perevesti("0", True)
����50����50.Props.AutoscrollpositionY = perevesti("0", True)
����50����50.Props.Enabled = perevesti("���", True)
����50����50.Props.Allowruncopies = perevesti("��", True)
����50����50.Props.Startposition = perevesti("�� ������ ������", True)
����50����50.StatusTemp = "����������"
����50����50.Props.Formborderstyle = perevesti("������������� ����", True)
����50����50.Props.Backgroundimagelayout = perevesti("������", True)
����50����50.Props.Tabindex = perevesti("0", True)
����50����50.Props.Tabstop = perevesti("��", True)
����50����50.Props.Text = perevesti("���������", True)
����50����50.Props.Backgroundimage = perevesti("�������", True)
����50����50.Props.Backcolor = perevesti("���������", True)
����50����50.Props.Forecolor = perevesti("������", True)
����50����50.Props.Height = perevesti("320", True)
����50����50.Props.Width = perevesti("500", True)
����50����50.Props.Visible = perevesti("���", True)
����50����50.Props.Height = perevesti("320", True)
����50����50.Props.Width = perevesti("500", True)

ProgressForm.ProgressBar1.Value = 86
����50���������_��������10.Props.X = perevesti("4", True)
����50���������_��������10.Props.Y = perevesti("4", True)
����50���������_��������10.Props.Contextmenu(True) = perevesti("�������", True)
����50���������_��������10.Props.Tag = perevesti("", True)
����50���������_��������10.Props.Selectedtext = perevesti("", True)
����50���������_��������10.Props.Selectionlength = perevesti("0", True)
����50���������_��������10.Props.Name = perevesti("��������� ��������1", True)
����50���������_��������10.Props.Maximumheight = perevesti("0", True)
����50���������_��������10.Props.Maximumlength = perevesti("32767", True)
����50���������_��������10.Props.Maximumwidth = perevesti("0", True)
����50���������_��������10.Props.Zoomfactor = perevesti("1", True)
����50���������_��������10.Props.Minimumheight = perevesti("0", True)
����50���������_��������10.Props.Minimumwidth = perevesti("0", True)
����50���������_��������10.Props.Multiline = perevesti("��", True)
����50���������_��������10.Props.Selectionstart = perevesti("1", True)
����50���������_��������10.Props.Index = perevesti("0", True)
����50���������_��������10.Props.Wordwrap = perevesti("��", True)
����50���������_��������10.Props.Internetlink = perevesti("��", True)
����50���������_��������10.Props.Detecturls = perevesti("��", True)
����50���������_��������10.Props.ToolTip = perevesti("", True)
����50���������_��������10.Props.Enableautodragdrop = perevesti("��", True)
����50���������_��������10.Props.Scrollbars = perevesti("������������", True)
����50���������_��������10.Props.Anchor = perevesti("�����_������", True)
����50���������_��������10.Props.Enabled = perevesti("��", True)
����50���������_��������10.Props.Dock = perevesti("�������", True)
����50���������_��������10.Props.Hideselection = perevesti("���", True)
����50���������_��������10.Props.Borderstyle = perevesti("�����", True)
����50���������_��������10.Props.Tabindex = perevesti("0", True)
����50���������_��������10.Props.Tabstop = perevesti("��", True)
����50���������_��������10.Props.Text = perevesti("", True)
����50���������_��������10.Props.Readonly = perevesti("���", True)
����50���������_��������10.Props.Backcolor = perevesti("�����", True)
����50���������_��������10.Props.Forecolor = perevesti("������", True)
����50���������_��������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����50���������_��������10.Props.Fontbold = perevesti("���", True)
����50���������_��������10.Props.Fontstrikeout = perevesti("���", True)
����50���������_��������10.Props.Fontitalic = perevesti("���", True)
����50���������_��������10.Props.Fontunderline = perevesti("���", True)
����50���������_��������10.Props.Fontsize = perevesti("8", True)
����50���������_��������10.Props.Height = perevesti("311", True)
����50���������_��������10.Props.Width = perevesti("411", True)
����50���������_��������10.Props.Visible = perevesti("��", True)
����50���������_��������10.Props.Height = perevesti("311", True)
����50���������_��������10.Props.Width = perevesti("411", True)
����50���������_��������10.Props.Rtf = perevesti("{\rtf1\ansi\ansicpg1251\deff0\deflang1049{\fonttbl{\f0\fnil\fcharset204 Microsoft Sans Serif;}}�\viewkind4\uc1\pard\f0\fs17\par�}�", True)

ProgressForm.ProgressBar1.Value = 87
����50������10.Props.X = perevesti("420", True)
����50������10.Props.Y = perevesti("4", True)
����50������10.Props.Autoellipsis = perevesti("��", True)
����50������10.Props.Contextmenu(True) = perevesti("�������", True)
����50������10.Props.Tag = perevesti("", True)
����50������10.Props.Name = perevesti("������1", True)
����50������10.Props.Cursor = perevesti("�������", True)
����50������10.Props.Maximumheight = perevesti("0", True)
����50������10.Props.Maximumwidth = perevesti("0", True)
����50������10.Props.Minimumheight = perevesti("0", True)
����50������10.Props.Minimumwidth = perevesti("0", True)
����50������10.Props.Index = perevesti("0", True)
����50������10.Props.ToolTip = perevesti("", True)
����50������10.Props.Paddingtop = perevesti("0", True)
����50������10.Props.Paddingleft = perevesti("0", True)
����50������10.Props.Paddingbottom = perevesti("0", True)
����50������10.Props.Paddingright = perevesti("0", True)
����50������10.Props.Imagealign = perevesti("�����", True)
����50������10.Props.Textalign = perevesti("�����", True)
����50������10.Props.Anchor = perevesti("�����_������", True)
����50������10.Props.Enabled = perevesti("��", True)
����50������10.Props.Dock = perevesti("�������", True)
����50������10.Props.Image = perevesti("�������", True)
����50������10.Props.Flatstyle = perevesti("�������", True)
����50������10.Props.Backgroundimagelayout = perevesti("������", True)
����50������10.Props.Tabindex = perevesti("0", True)
����50������10.Props.Tabstop = perevesti("��", True)
����50������10.Props.Text = perevesti("���������", True)
����50������10.Props.Textimagerelation = perevesti("������", True)
����50������10.Props.Backgroundimage = perevesti("�������", True)
����50������10.Props.Backcolor = perevesti("�������", True)
����50������10.Props.Forecolor = perevesti("������", True)
����50������10.Props.Fontfamily = perevesti("Microsoft Sans Serif", True)
����50������10.Props.Fontbold = perevesti("���", True)
����50������10.Props.Fontstrikeout = perevesti("���", True)
����50������10.Props.Fontitalic = perevesti("���", True)
����50������10.Props.Fontunderline = perevesti("���", True)
����50������10.Props.Fontsize = perevesti("8", True)
����50������10.Props.Height = perevesti("23", True)
����50������10.Props.Width = perevesti("75", True)
����50������10.Props.Visible = perevesti("��", True)
����50������10.Props.Height = perevesti("23", True)
����50������10.Props.Width = perevesti("75", True)

ProgressForm.ProgressBar1.Value = 88
����50����_����������10.Props.X = perevesti("4", True)
����50����_����������10.Props.Y = perevesti("4", True)
����50����_����������10.Props.Tag = perevesti("", True)
����50����_����������10.Props.Defaultext = perevesti("", True)
����50����_����������10.Props.Title = perevesti("", True)
����50����_����������10.Props.Name = perevesti("���� ����������1", True)
����50����_����������10.Props.Filename = perevesti("", True)
����50����_����������10.Props.Initialdirectory = perevesti("", True)
����50����_����������10.Props.Index = perevesti("0", True)
����50����_����������10.Props.Filterindex = perevesti("1", True)
����50����_����������10.Props.Checkpathexists = perevesti("��", True)
����50����_����������10.Props.Checkfileexists = perevesti("���", True)
����50����_����������10.Props.Filter = perevesti("����|*.theme", True)

ProgressForm.ProgressBar1.Value = 89
_��������_�������0_��������_�������0.Props.Name = "_�������� �������"

ProgressForm.ProgressBar1.Value = 90
_��������_�������0_�����0.Props.Name = "_�����"

ProgressForm.ProgressBar1.Value = 91
_��������_�������0_�����_�_�����0.Props.Name = "_����� � �����"

ProgressForm.ProgressBar1.Value = 92
_��������_�������0_����������0.Props.Name = "_����������"

ProgressForm.ProgressBar1.Value = 93
_��������_�������0_�������0.Props.Name = "_�������"

ProgressForm.ProgressBar1.Value = 94
_��������_�������0_������0.Props.Name = "_������"

ProgressForm.ProgressBar1.Value = 95
_��������_�������0_�������_�������0.Props.Name = "_������� �������"

ProgressForm.ProgressBar1.Value = 96
_��������_�������0_�����0.Props.Name = "_�����"

ProgressForm.ProgressBar1.Value = 97
_��������_�������0_��������_���������0.Props.Name = "_�������� ���������"

ProgressForm.ProgressBar1.Value = 98
_��������_�������0_����0.Props.Name = "_����"

ProgressForm.ProgressBar1.Value = 99
_��������_�������0_�����������_�����������0.Props.Name = "_����������� �����������"


' ������������� ��������
����10����10.load()
����10�������72.load()
����10������_10.load()
����10�����10.load()
����10�����20.load()
����10�����30.load()
����10�����40.load()
����10�����50.load()
����10�����60.load()
����10������10.load()
����10�������73.load()
����10�������74.load()
����10�������75.load()
����10�������76.load()
����10�������77.load()
����10�����70.load()
����10�������71.load()
����10������20.load()
����10������30.load()
����10����_��������10.load()
����20����20.load()
����20�������10.load()
����20������10.load()
����20������20.load()
����20�����10.load()
����20����_��������10.load()
����30����30.load()
����30���������_��������10.load()
����30������10.load()
����30������20.load()
����30�����10.load()
����30����_��������10.load()
����30������30.load()
����40����40.load()
����40���������_��������10.load()
����40������10.load()
����40������20.load()
����40������10.load()
����40������20.load()
����40������30.load()
����40����_����������10.load()
����40�������10.load()
����50����50.load()
����50���������_��������10.load()
����50������10.load()
����50����_����������10.load()

RunProj.GetAllObjects()
RunProj.isINITIALIZATED = False

����10�������72.RaiseCreate()
����10������_10.RaiseCreate()
����10�����10.RaiseCreate()
����10�����20.RaiseCreate()
����10�����30.RaiseCreate()
����10�����40.RaiseCreate()
����10�����50.RaiseCreate()
����10�����60.RaiseCreate()
����10������10.RaiseCreate()
����10�������73.RaiseCreate()
����10�������74.RaiseCreate()
����10�������75.RaiseCreate()
����10�������76.RaiseCreate()
����10�������77.RaiseCreate()
����10�����70.RaiseCreate()
����10�������71.RaiseCreate()
����10������20.RaiseCreate()
����10������30.RaiseCreate()
����10����_��������10.RaiseCreate()
����10����10.RaiseCreate()
����20�������10.RaiseCreate()
����20������10.RaiseCreate()
����20������20.RaiseCreate()
����20�����10.RaiseCreate()
����20����_��������10.RaiseCreate()
����20����20.RaiseCreate()
����30���������_��������10.RaiseCreate()
����30������10.RaiseCreate()
����30������20.RaiseCreate()
����30�����10.RaiseCreate()
����30����_��������10.RaiseCreate()
����30������30.RaiseCreate()
����30����30.RaiseCreate()
����40���������_��������10.RaiseCreate()
����40������10.RaiseCreate()
����40������20.RaiseCreate()
����40������10.RaiseCreate()
����40������20.RaiseCreate()
����40������30.RaiseCreate()
����40����_����������10.RaiseCreate()
����40�������10.RaiseCreate()
����40����40.RaiseCreate()
����50���������_��������10.RaiseCreate()
����50������10.RaiseCreate()
����50����_����������10.RaiseCreate()
����50����50.RaiseCreate()

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

Public Sub ����10�����10_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����10�����10.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����10�����20_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����10�����20.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����10�����30_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����10�����30.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����10�����40_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����10�����40.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����10�����50_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����10�����50.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����10�����60_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����10�����60.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����10�����70_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����10�����70.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����20����20_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����20����20.Disposed
    If DaOrNet(����20����20.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub ����20����20_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles ����20����20.FormClosing
    If DaOrNet(����20����20.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(����20����20.Props.MainForm) = UCase(trans("��")) Or proj.isCLOSING Then
        ����20����20.Hide() : Application.Exit()
    Else
        e.Cancel = True : ����20����20.Hide()
    End If
End Sub

Public Sub ����20�����10_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����20�����10.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����30����30_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����30����30.Disposed
    If DaOrNet(����30����30.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub ����30����30_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles ����30����30.FormClosing
    If DaOrNet(����30����30.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(����30����30.Props.MainForm) = UCase(trans("��")) Or proj.isCLOSING Then
        ����30����30.Hide() : Application.Exit()
    Else
        e.Cancel = True : ����30����30.Hide()
    End If
End Sub

Public Sub ����30���������_��������10_LinkClickedNado(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles ����30���������_��������10.LinkClicked
    If DaOrNet(����30���������_��������10.Props.InternetLink) Then ����30���������_��������10.Props.GoInternetLink(e.LinkText)
End Sub

Public Sub ����30�����10_KeyPressNado(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ����30�����10.KeyPress
    e.Handled = TextBoxAllow(sender, e)
End Sub

Public Sub ����40����40_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����40����40.Disposed
    If DaOrNet(����40����40.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub ����40����40_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles ����40����40.FormClosing
    If DaOrNet(����40����40.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(����40����40.Props.MainForm) = UCase(trans("��")) Or proj.isCLOSING Then
        ����40����40.Hide() : Application.Exit()
    Else
        e.Cancel = True : ����40����40.Hide()
    End If
End Sub

Public Sub ����40���������_��������10_LinkClickedNado(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles ����40���������_��������10.LinkClicked
    If DaOrNet(����40���������_��������10.Props.InternetLink) Then ����40���������_��������10.Props.GoInternetLink(e.LinkText)
End Sub

Public Sub ����50����50_DisposedEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����50����50.Disposed
    If DaOrNet(����50����50.Props.MainForm) Then proj.isCLOSING = True : Application.Exit()
End Sub

Public Sub ����50����50_FormClosingNado(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles ����50����50.FormClosing
    If DaOrNet(����50����50.Props.ForbidClose) Then e.Cancel = True : Exit Sub
    If UCase(����50����50.Props.MainForm) = UCase(trans("��")) Or proj.isCLOSING Then
        ����50����50.Hide() : Application.Exit()
    Else
        e.Cancel = True : ����50����50.Hide()
    End If
End Sub

Public Sub ����50���������_��������10_LinkClickedNado(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles ����50���������_��������10.LinkClicked
    If DaOrNet(����50���������_��������10.Props.InternetLink) Then ����50���������_��������10.Props.GoInternetLink(e.LinkText)
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
Public Sub ����10������10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10������10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10������10.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����2.����2").Props.Visible = "��"
RunProj.GetObjFromUniqName("����2.����2").Props.Enabled = "��"
CurrentEvent.Zavershit()
End Sub


Public Sub ����10������20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10������20.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10������20.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����1.�����7").Props.Copy
CurrentEvent.Zavershit()
End Sub


Public Sub ����10������30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����10������30.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����10������30.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����1.���� ��������1").Props.Showdialog
RunProj.GetObjFromUniqName("����1.�����7").Props.Text = RunProj.GetObjFromUniqName("����1.���� ��������1").Props.Filename
CurrentEvent.Zavershit()
End Sub


Public Sub ����20������10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����20������10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����20������10.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����2.���� ��������1").Props.Showdialog
RunProj.GetObjFromUniqName("����2.�������1").Props.Image = RunProj.GetObjFromUniqName("����2.���� ��������1").Props.Filename
RunProj.GetObjFromUniqName("����2.�����1").Props.Text = RunProj.GetObjFromUniqName("����2.���� ��������1").Props.Filename
CurrentEvent.Zavershit()
End Sub


Public Sub ����20������20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����20������20.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����20������20.MyObj, e, nothing,"����")

If returnBoolean( UCase( RunProj.GetObjFromUniqName("����2.�����1" ).Props.Text )  =  UCase( "" )  ) Then
RunProj.GetObjFromUniqName("_�������� �������._�������� ���������").Props.Showmessage ( "�� �� ������� ���� � ������� �������� �����." , "��" , "������" , "" ) 
Else
RunProj.GetObjFromUniqName("����3.����3").Props.Enabled = "��"
RunProj.GetObjFromUniqName("����3.����3").Props.Visible = "��"
End If
CurrentEvent.Zavershit()
End Sub


Public Sub ����30������10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����30������10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����30������10.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����4.����4").Props.Enabled = "��"
RunProj.GetObjFromUniqName("����4.����4").Props.Visible = "��"
CurrentEvent.Zavershit()
End Sub


Public Sub ����30������20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����30������20.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����30������20.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����3.���� ��������1").Props.Showdialog
RunProj.GetObjFromUniqName("����3.�����1").Props.Text = RunProj.GetObjFromUniqName("����3.���� ��������1").Props.Filename
CurrentEvent.Zavershit()
End Sub


Public Sub ����30������30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����30������30.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����30������30.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����3.�����1").Props.Copy
CurrentEvent.Zavershit()
End Sub


Public Sub ����40������10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����40������10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����40������10.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����4.������1").Props.Value = "; Copyright � Microsoft Corp." & vbCrLf & "" & vbCrLf & "[Theme]" & vbCrLf & "; Windows 7 - IDS_THEME_DISPLAYNAME_AERO" & vbCrLf & "DisplayName=Biohazard" & vbCrLf & "BrandImage=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����1").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "" & vbCrLf & "; Computer - SHIDI_SERVER" & vbCrLf & "[CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����2").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "" & vbCrLf & "; UsersFiles - SHIDI_USERFILES" & vbCrLf & "[CLSID\{59031A47-3F72-44A7-89C5-5595FE6B30EE}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����3").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "; Network - SHIDI_MYNETWORK" & vbCrLf & "[CLSID\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����4").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "" & vbCrLf & "; Recycle Bin - SHIDI_RECYCLERFULL SHIDI_RECYCLER" & vbCrLf & "[CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\DefaultIcon]" & vbCrLf & "Full=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����5").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "" & vbCrLf & "Empty=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����6").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����4.������2").Props.Value
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����2.�����1").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����4.������3").Props.Value
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����3.��������� ��������1").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����4.��������� ��������1").Props.Text
RunProj.GetObjFromUniqName("����4.���� ����������1").Props.Showdialog
(RunProj.GetObjFromUniqName("����4.���� ����������1").Props.(RunProj.GetObjFromUniqName) ( "����4.���� ����������1" ) .Props.Filename , RunProj.GetObjFromUniqName ( "����4.������1" ) .Props.Value , "�� ���������" ) )
CurrentEvent.Zavershit()
End Sub


Public Sub ����40������20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����40������20.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����40������20.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("_�������� �������._�������").Props.Run ( "Themes\help.txt" , "C:\" ) 
CurrentEvent.Zavershit()
End Sub


Public Sub ����40�������10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����40�������10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����40�������10.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����4.������1").Props.Value = "; Copyright � Microsoft Corp." & vbCrLf & "" & vbCrLf & "[Theme]" & vbCrLf & "; Windows 7 - IDS_THEME_DISPLAYNAME_AERO" & vbCrLf & "DisplayName=Biohazard" & vbCrLf & "BrandImage=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����1").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "" & vbCrLf & "; Computer - SHIDI_SERVER" & vbCrLf & "[CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����2").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "" & vbCrLf & "; UsersFiles - SHIDI_USERFILES" & vbCrLf & "[CLSID\{59031A47-3F72-44A7-89C5-5595FE6B30EE}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����3").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "; Network - SHIDI_MYNETWORK" & vbCrLf & "[CLSID\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\DefaultIcon]" & vbCrLf & "DefaultValue=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����4").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "" & vbCrLf & "; Recycle Bin - SHIDI_RECYCLERFULL SHIDI_RECYCLER" & vbCrLf & "[CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\DefaultIcon]" & vbCrLf & "Full=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����5").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & "" & vbCrLf & "Empty=%SystemRoot%\Resources\Themes\"
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����1.�����6").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����4.������2").Props.Value
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����2.�����1").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����4.������3").Props.Value
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����3.��������� ��������1").Props.Text
RunProj.GetObjFromUniqName("����4.������1").Props.Value = RunProj.GetObjFromUniqName("����4.������1").Props.Value & RunProj.GetObjFromUniqName("����4.��������� ��������1").Props.Text
RunProj.GetObjFromUniqName("����5.����5").Props.Visible = "��"
RunProj.GetObjFromUniqName("����5.����5").Props.Enabled = "��"
CurrentEvent.Zavershit()
End Sub


Public Sub ����50������10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ����50������10.Click
If RunProj.isINITIALIZATED Then Exit Sub
Dim CurrentEvent as New PropertysSobyt(����50������10.MyObj, e, nothing,"����")

RunProj.GetObjFromUniqName("����5.���� ����������1").Props.Showdialog
RunProj.GetObjFromUniqName("_�������� �������._����� � �����").Props.Saveinfile ( RunProj.GetObjFromUniqName ( "����5.���� ����������1" ) .Props.Filename , RunProj.GetObjFromUniqName ( "����5.��������� ��������1" ) .Props.Text , "�� ���������" ) 
CurrentEvent.Zavershit()
End Sub



End Module



