Language = English
F
Auto scroll minSize height
0
Auto scroll minSize width
0
Auto scroll position X
0
Auto scroll position Y
0
Back color
235; 233; 237;
Background image
Nothing
Background image layout
Tile
Cancel close
No
Context menu
Nothing
Control box
Yes
Cursor
Default
Enabled
Yes
Fore color
Black
Form border style
Normal
Height
277
Icon
Nothing
Index
0
Main form
Yes
Main menu strip
Nothing
Maximum height
0
Maximum width
0
Minimum height
0
Minimum width
0
Name
Window1
Opacity
100
Scroll
No
Show icon
Yes
Show in taskbar
Yes
Show in tray
No
Start position
Specified coordinates
Tab index
0
Tab stop
Yes
Tag

Text
File Manadger
TopMost
No
Transparentcy key
Nothing
Visible
Yes
Width
437
Window state
Normal
X
0
Y
0
#Conteiner

#HistoryLevel
0
#TreeNode
#Parent
Window1(0)
#Index
0
Window1
Window1
window
window
Obj
 Created
 afOkGeNkwI
 Created
 Created
 Sobyt
  _Useful objects._Call event.Window1_Table1_Size changed
  ODQffwglIx
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_ButtonGo_Click
  cBSsMAfvKn
  deist
  deist
  Deist
#End

T
Anchor
Right_left_top
Back color
White
Border style
3D
Context menu
Nothing
Dock
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Height
20
Hide selection
No
Index
0
Maximum height
0
Maximum length
32767
Maximum width
0
Minimum height
0
Minimum width
0
Multiline
No
Name
Text1
Password char

Read only
No
Scroll bars
No
Selected text

Selection length
0
Selection start
1
Tab index
0
Tab stop
Yes
Tag

Text

Text position
On left
Visible
Yes
Width
325
Word wrap
Yes
X
47
Y
34
#Conteiner
Window1.Window1[0]
#HistoryLevel
9
#TreeNode
#Parent
Window1(0)
#Index
1
Text1
Text1
textboks
textboks
Obj
 Key down
 PiPUafktLb
 Key down
 Key down
 Sobyt
  IF Window1.Text1._Key pressed = enter THEN
  GBKMoxxiDw
  if
  if
  If
   _Useful objects._Call event.Window1_ButtonGo_Click
   YoiIjijeLM
   deist
   deist
   Deist
  End If
  PfRkXrvYvL
  endif
  endif
  EndIf
#End

B
Anchor
Right_top
Auto ellipsis
Yes
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Context menu
Nothing
Cursor
Default
Dock
Nothing
Enabled
Yes
Flat style
Default
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Height
22
Image
Nothing
Image align
Center
Index
0
Maximum height
0
Maximum width
0
Minimum height
0
Minimum width
0
Name
ButtonGo
Padding bottom
0
Padding left
0
Padding right
0
Padding top
0
Tab index
0
Tab stop
Yes
Tag

Text
Go
Text align
center
Text image relation
Overlay
Visible
Yes
Width
59
X
376
Y
33
#Conteiner
Window1.Window1[0]
#HistoryLevel
1
#TreeNode
#Parent
Window1(0)
#Index
2
ButtonGo
ButtonGo
button
button
Obj
 Click
 NaSQipkGDp
 Click
 Click
 Sobyt
  _Useful objects._Call event.Window1_ToolStop_Click
  tOavoWntsH
  deist
  deist
  Deist
  Window1.Table1.Rows = ""
  lPiLrwMFft
  deist
  deist
  Deist
  IF Window1.Text1.Text = "" THEN
  hVRnAViMkv
  if
  if
  If
   Window1.MemoryFiles.Value = _Useful objects._Files and paths._Get drives
   mFPfKhpcSI
   deist
   deist
   Deist
   Window1.MemoryQuantityFiles.Value = _Useful objects._Text._Split count(Window1.MemoryFiles.Value, ";")
   FqoosvqGWk
   deist
   deist
   Deist
   Window1.MemoryCounter.Value = 1
   cfaHHXvkvS
   deist
   deist
   Deist
   WHILE Window1.MemoryCounter.Value <= Window1.MemoryQuantityFiles.Value
   mbJuTfACAJ
   while
   while
   While
    Window1.MemoryFile.Value = _Useful objects._Text._Split(Window1.MemoryFiles.Value, ";", Window1.MemoryCounter.Value)
    GjlWopgbsC
    deist
    deist
    Deist
    Window1.MemoryFile.Value = _Useful objects._Text._Trim all(Window1.MemoryFile.Value)
    ebnATHdHXl
    deist
    deist
    Deist
    Window1.Table1.Rows = Window1.Table1.Rows & ", """ & Window1.MemoryFile.Value & """ | ""< Drive >"" | ""0"""
    kFexTdhrUN
    deist
    deist
    Deist
    Window1.LabelLoad.Text = Round(100 * (Window1.MemoryCounter.Value / Window1.MemoryQuantityFiles.Value)) & "%"
    vnGNdrrDRQ
    deist
    deist
    Deist
    Window1.MemoryCounter.Value = Window1.MemoryCounter.Value + 1
    qUpsmLlJbL
    deist
    deist
    Deist
   End While
   BqcNXBElCL
   endwhile
   endwhile
   EndWhile
  Else
  ImFfFoUaUa
  else
  else
  Else
   Window1.MemoryFiles.Value = _Useful objects._Files and paths._Get paths(Window1.Text1.Text)
   NaoHtONkLI
   deist
   deist
   Deist
   IF Window1.MemoryFiles.Value <> "" THEN
   pXQILELqoc
   if
   if
   If
    Window1.MemoryQuantityFiles.Value = _Useful objects._Text._Split count(Window1.MemoryFiles.Value, ";")
    nFAGHDOJmw
    deist
    deist
    Deist
    Window1.MemoryCounter.Value = 1
    oLmAvaCUSI
    deist
    deist
    Deist
    WHILE Window1.MemoryCounter.Value <= Window1.MemoryQuantityFiles.Value
    lRasTiVvTB
    while
    while
    While
     Window1.MemoryFile.Value = _Useful objects._Text._Split(Window1.MemoryFiles.Value, ";", Window1.MemoryCounter.Value)
     ddjrlHYhxp
     deist
     deist
     Deist
     Window1.MemoryFile.Value = _Useful objects._Text._Trim all(Window1.MemoryFile.Value)
     AEvNRejPKj
     deist
     deist
     Deist
     Window1.MemoryFile.Value = _Useful objects._Files and paths._Get file name without extension(Window1.MemoryFile.Value)
     BoXfoUeFkW
     deist
     deist
     Deist
     Window1.Table1.Rows = Window1.Table1.Rows & ", """ & Window1.MemoryFile.Value & """ | ""< Folder >"" | ""0"""
     gRnlSLasNn
     deist
     deist
     Deist
     Window1.LabelLoad.Text = Round(100 * (Window1.MemoryCounter.Value / Window1.MemoryQuantityFiles.Value)) & "%"
     ASVbIhTMao
     deist
     deist
     Deist
     Window1.MemoryCounter.Value = Window1.MemoryCounter.Value + 1
     xGkjxnEDCP
     deist
     deist
     Deist
    End While
    cSvaJgOKsG
    endwhile
    endwhile
    EndWhile
    IF Window1.MemoryCounter.Value = 99999 THEN
    DpBUihSuWH
    if
    if
    If
     _Useful objects._Interrupts._Break event
     AReuXYgEme
     deist
     deist
     Deist
    End If
    GVpvLgVtRa
    endif
    endif
    EndIf
   End If
   RJSSkHEOAP
   endif
   endif
   EndIf
   Window1.MemoryFiles.Value = _Useful objects._Files and paths._Get files(Window1.Text1.Text)
   UIfsPKnBBi
   deist
   deist
   Deist
   IF Window1.MemoryFiles.Value <> "" THEN
   AJWNAgxEJC
   if
   if
   If
    Window1.MemoryQuantityFiles.Value = _Useful objects._Text._Split count(Window1.MemoryFiles.Value, ";")
    LWcuopxKJQ
    deist
    deist
    Deist
    Window1.MemoryCounter.Value = 1
    UQEVJvpugB
    deist
    deist
    Deist
    WHILE Window1.MemoryCounter.Value <= Window1.MemoryQuantityFiles.Value
    qUsiaIlESE
    while
    while
    While
     Window1.MemoryFile.Value = _Useful objects._Text._Split(Window1.MemoryFiles.Value, ";", Window1.MemoryCounter.Value)
     IAEvEvfiEX
     deist
     deist
     Deist
     Window1.MemoryFile.Value = _Useful objects._Text._Trim all(Window1.MemoryFile.Value)
     KcpjMhFADD
     deist
     deist
     Deist
     Window1.MemoryExtention.Value = _Useful objects._Files and paths._Get extension(Window1.MemoryFile.Value)
     oCVIKocrUf
     deist
     deist
     Deist
     Window1.MemorySize.Value = _Useful objects._Files and paths._Get file size(Window1.MemoryFile.Value) / 1024
     EsqFHUMGQL
     deist
     deist
     Deist
     Window1.MemorySize.Value = Round(Window1.MemorySize.Value) & " Кб"
     QGqHoNeJVq
     deist
     deist
     Deist
     Window1.MemoryFile.Value = _Useful objects._Files and paths._Get file name without extension(Window1.MemoryFile.Value)
     CkAONGculN
     deist
     deist
     Deist
     Window1.Table1.Rows = Window1.Table1.Rows & ", """ & Window1.MemoryFile.Value & """ | """ & Window1.MemoryExtention.Value & """ | """ & Window1.MemorySize.Value & """"
     TlMXTQkjbq
     deist
     deist
     Deist
     Window1.LabelLoad.Text = Round(100 * (Window1.MemoryCounter.Value / Window1.MemoryQuantityFiles.Value)) & "%"
     UwhqkiKNRu
     deist
     deist
     Deist
     Window1.MemoryCounter.Value = Window1.MemoryCounter.Value + 1
     KSVccRsbqB
     deist
     deist
     Deist
    End While
    qPTCqerSmX
    endwhile
    endwhile
    EndWhile
   End If
   csgdVECIde
   endif
   endif
   EndIf
  End If
  tNcpDAOitC
  endif
  endif
  EndIf
#End

M
Enabled
Yes
Index
0
Name
MemoryFiles
Tag

Value

X
8
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
2
#TreeNode
#Parent
Window1(0)
#Index
3
MemoryFiles
MemoryFiles
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryFile
Tag

Value

X
40
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
5
#TreeNode
#Parent
Window1(0)
#Index
4
MemoryFile
MemoryFile
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryQuantityFiles
Tag

Value

X
72
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
4
#TreeNode
#Parent
Window1(0)
#Index
5
MemoryQuantityFiles
MemoryQuantityFiles
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryCounter
Tag

Value

X
104
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
3
#TreeNode
#Parent
Window1(0)
#Index
6
MemoryCounter
MemoryCounter
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryExtention
Tag

Value

X
136
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
6
#TreeNode
#Parent
Window1(0)
#Index
7
MemoryExtention
MemoryExtention
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemorySize
Tag

Value

X
168
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
7
#TreeNode
#Parent
Window1(0)
#Index
8
MemorySize
MemorySize
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryRowNumber
Tag

Value

X
256
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
11
#TreeNode
#Parent
Window1(0)
#Index
9
MemoryRowNumber
MemoryRowNumber
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryCopy
Tag

Value

X
376
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
14
#TreeNode
#Parent
Window1(0)
#Index
10
MemoryCopy
MemoryCopy
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryNewName
Tag

Value

X
408
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
15
#TreeNode
#Parent
Window1(0)
#Index
11
MemoryNewName
MemoryNewName
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryCut
Tag

Value

X
480
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
27
#TreeNode
#Parent
Window1(0)
#Index
12
MemoryCut
MemoryCut
memory
memory
Obj
#End

M
Enabled
Yes
Index
0
Name
MemoryToCreatePath
Tag

Value

X
288
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
17
#TreeNode
#Parent
Window1(0)
#Index
13
MemoryToCreatePath
MemoryToCreatePath
memory
memory
Obj
 Changing value
 VIraxFdfxG
 Changing value
 Changing value
 Sobyt
  Window1.MemoryFile.Value = ""
  oqasRQkrGX
  deist
  deist
  Deist
  Window1.MemoryFiles.Value = Window1.MemoryRowNumber.Value
  OjwLFdldxp
  deist
  deist
  Deist
  Window1.MemoryQuantityFiles.Value = _Useful objects._Text._Split count(Window1.MemoryFiles.Value, ",")
  OIXkBSBGeQ
  deist
  deist
  Deist
  Window1.MemoryCounter.Value = 1
  aVIWnDliWk
  deist
  deist
  Deist
  WHILE Window1.MemoryCounter.Value <= Window1.MemoryQuantityFiles.Value
  NVcUllKfTT
  while
  while
  While
   Window1.MemoryRowNumber.Value = _Useful objects._Text._Split(Window1.MemoryFiles.Value, ",", Window1.MemoryCounter.Value)
   RAfHpfSoqw
   deist
   deist
   Deist
   IF Window1.Text1.Text = "" THEN
   PeMowqaYVC
   if
   if
   If
    Window1.MemoryFile.Value = Window1.MemoryFile.Value & Window1.Table1.Item value(Window1.MemoryRowNumber.Value, 0)
    pDFMcrfCwO
    deist
    deist
    Deist
   Else
   ITlJwYpBgI
   else
   else
   Else
    IF _Useful objects._Text._Chars(Window1.Text1.Text, _Useful objects._Text._Chars length(Window1.Text1.Text)) = "\" THEN
    jvpXUiIlWt
    if
    if
    If
     Window1.MemoryFile.Value = Window1.MemoryFile.Value & Window1.Text1.Text & Window1.Table1.Item value(Window1.MemoryRowNumber.Value, 0)
     KjIRdOsRew
     deist
     deist
     Deist
    Else
    xPpcotqDqW
    else
    else
    Else
     Window1.MemoryFile.Value = Window1.MemoryFile.Value & Window1.Text1.Text & "\" & Window1.Table1.Item value(Window1.MemoryRowNumber.Value, 0)
     BYrNQrLgpr
     deist
     deist
     Deist
    End If
    iseCDWKTfh
    endif
    endif
    EndIf
    IF Window1.Table1.Item value(Window1.MemoryRowNumber.Value, 1) <> "< Folder >" THEN
    fWUhISFMha
    if
    if
    If
     Window1.MemoryFile.Value = Window1.MemoryFile.Value & Window1.Table1.Item value(Window1.MemoryRowNumber.Value, 1)
     pFsxsjqtAj
     deist
     deist
     Deist
    End If
    CLblNFkmXQ
    endif
    endif
    EndIf
   End If
   iWWIpcEJFv
   endif
   endif
   EndIf
   Window1.MemoryCounter.Value = Window1.MemoryCounter.Value + 1
   mwwPBcxeIS
   deist
   deist
   Deist
   IF Window1.MemoryCounter.Value <= Window1.MemoryQuantityFiles.Value THEN
   fPStfTuiSD
   if
   if
   If
    Window1.MemoryFile.Value = Window1.MemoryFile.Value & ";"
    hQmPpRhkIP
    deist
    deist
    Deist
   Else
   fgoCvEMKjj
   else
   else
   Else
    _Useful objects._Interrupts._Break loop
    FGeFkSEbcV
    deist
    deist
    Deist
   End If
   gToCOUJhXi
   endif
   endif
   EndIf
  End While
  tNUrlwaPwa
  endwhile
  endwhile
  EndWhile
#End

Lb
Anchor
Left_top
Auto ellipsis
Yes
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Border style
Nothing
Context menu
Nothing
Cursor
Default
Dock
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Height
13
Image
Nothing
Image align
Center
Index
0
Maximum height
0
Maximum width
0
Minimum height
0
Minimum width
0
Name
Label1
Padding bottom
0
Padding left
0
Padding right
0
Padding top
0
Tab index
0
Tab stop
Yes
Tag

Text
Address:
Text align
center
Visible
Yes
Width
50
X
-1
Y
36
#Conteiner
Window1.Window1[0]
#HistoryLevel
8
#TreeNode
#Parent
Window1(0)
#Index
14
Label1
Label1
label
label
Obj
#End

Lb
Anchor
Right_top
Auto ellipsis
Yes
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Border style
Nothing
Context menu
Nothing
Cursor
Default
Dock
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Height
20
Image
Nothing
Image align
Center
Index
0
Maximum height
0
Maximum width
0
Minimum height
0
Minimum width
0
Name
Label2
Padding bottom
0
Padding left
0
Padding right
0
Padding top
0
Tab index
0
Tab stop
Yes
Tag

Text
Загрузка:
Text align
center
Visible
Yes
Width
62
X
330
Y
4
#Conteiner
Window1.Window1[0]
#HistoryLevel
18
#TreeNode
#Parent
Window1(0)
#Index
15
Label2
Label2
label
label
Obj
#End

Lb
Anchor
Right_top
Auto ellipsis
Yes
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Border style
Nothing
Context menu
Nothing
Cursor
Default
Dock
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Height
20
Image
Nothing
Image align
Center
Index
0
Maximum height
0
Maximum width
0
Minimum height
0
Minimum width
0
Name
LabelLoad
Padding bottom
0
Padding left
0
Padding right
0
Padding top
0
Tab index
0
Tab stop
Yes
Tag

Text
100%
Text align
center
Visible
Yes
Width
46
X
386
Y
4
#Conteiner
Window1.Window1[0]
#HistoryLevel
26
#TreeNode
#Parent
Window1(0)
#Index
16
LabelLoad
LabelLoad
label
label
Obj
#End

TPl
Anchor
Left_top
Back color
Sys
Background image
Nothing
Background image layout
Tile
Context menu
Nothing
Cursor
Default
Dock
Top
Enabled
Yes
Height
30
Index
0
Maximum height
0
Maximum width
0
Minimum height
0
Minimum width
0
Name
Tool panel1
Orientation tools
Horizontal
Tab index
0
Tab stop
Yes
Tag

Visible
Yes
Width
437
X
0
Y
0
#Conteiner
Window1.Window1[0]
#HistoryLevel
25
#TreeNode
#Parent
Window1(0)
#Index
17
Tool panel1
Tool panel1
tpanel
tpanel
Obj
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Pictures\Picture1.png
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolUp
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
0
Shortcut keys
control; up;
Show shortcut keys
Yes
Tag

Text
Панель инструментов1 Пункт1
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
24
#TreeNode
#Parent
Window1(0)
#Index
18
ToolUp
ToolUp
mmenu
mmenu
Obj
 Click
 eSKlpYwGjc
 Click
 Click
 Sobyt
  Window1.Text1.Text = _Useful objects._Files and paths._Get parent(Window1.Text1.Text)
  QapcbIpuac
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_ButtonGo_Click
  QOnDugNErf
  deist
  deist
  Deist
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Nothing
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolSplit1
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
1
Shortcut keys
Nothing
Show shortcut keys
Yes
Tag

Text
-
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
19
#TreeNode
#Parent
Window1(0)
#Index
19
ToolSplit1
ToolSplit1
mmenu
mmenu
Obj
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Pictures\Picture2.png
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolRefresh
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
2
Shortcut keys
F5
Show shortcut keys
Yes
Tag

Text
Панель инструментов1 Пункт1
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
10
#TreeNode
#Parent
Window1(0)
#Index
20
ToolRefresh
ToolRefresh
mmenu
mmenu
Obj
 Click
 TawkDmkcYO
 Click
 Click
 Sobyt
  _Useful objects._Call event.Window1_ButtonGo_Click
  RFJLoOeCqN
  deist
  deist
  Deist
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Pictures\Picture3.png
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolStop
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
3
Shortcut keys
F6
Show shortcut keys
Yes
Tag

Text
Панель инструментов1 Пункт1
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
23
#TreeNode
#Parent
Window1(0)
#Index
21
ToolStop
ToolStop
mmenu
mmenu
Obj
 Click
 GmcVgawwrE
 Click
 Click
 Sobyt
  Window1.MemoryCounter.Value = 99998
  oBOpeXbGVl
  deist
  deist
  Deist
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Nothing
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolSplit2
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
4
Shortcut keys
Nothing
Show shortcut keys
Yes
Tag

Text
-
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
12
#TreeNode
#Parent
Window1(0)
#Index
22
ToolSplit2
ToolSplit2
mmenu
mmenu
Obj
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Pictures\Picture4.png
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolCopy
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
5
Shortcut keys
control; c;
Show shortcut keys
Yes
Tag

Text
Панель инструментов1 Пункт3
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
22
#TreeNode
#Parent
Window1(0)
#Index
23
ToolCopy
ToolCopy
mmenu
mmenu
Obj
 Click
 oihxrQbjeA
 Click
 Click
 Sobyt
  Window1.Window1.Enabled = No
  lBbpfELGTm
  deist
  deist
  Deist
  Window1.MemoryRowNumber.Value = Window1.Table1.Selected rows
  vWNAwgLLVu
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_MemoryToCreatePath_Changing value
  MwMVlVEccO
  deist
  deist
  Deist
  Window1.MemoryCopy.Value = Window1.MemoryFile.Value
  xNRrRnXXKY
  deist
  deist
  Deist
  Window1.Window1.Enabled = Yes
  MTlhoQUhAL
  deist
  deist
  Deist
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Pictures\Picture5.png
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolCut
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
6
Shortcut keys
control; x;
Show shortcut keys
Yes
Tag

Text
Панель инструментов1 Пункт4
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
21
#TreeNode
#Parent
Window1(0)
#Index
24
ToolCut
ToolCut
mmenu
mmenu
Obj
 Click
 nHRsqOeHoJ
 Click
 Click
 Sobyt
  _Useful objects._Call event.Window1_ToolCopy_Click
  LrNDHobFXn
  deist
  deist
  Deist
  Window1.MemoryCut.Value = Yes
  WNULKKEbMf
  deist
  deist
  Deist
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Pictures\Picture6.png
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolPaste
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
7
Shortcut keys
control; v;
Show shortcut keys
Yes
Tag

Text
Панель инструментов1 Пункт5
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
20
#TreeNode
#Parent
Window1(0)
#Index
25
ToolPaste
ToolPaste
mmenu
mmenu
Obj
 Click
 CLMdpLIDrm
 Click
 Click
 Sobyt
  Window1.Window1.Enabled = No
  HdlODXqFDA
  deist
  deist
  Deist
  Window1.MemoryFiles.Value = Window1.MemoryCopy.Value
  lXdCpYlFif
  deist
  deist
  Deist
  Window1.MemoryQuantityFiles.Value = _Useful objects._Text._Split count(Window1.MemoryFiles.Value, ";")
  KCsJHAejMu
  deist
  deist
  Deist
  Window1.MemoryCounter.Value = 1
  gXLjfsbGIk
  deist
  deist
  Deist
  WHILE Window1.MemoryCounter.Value <= Window1.MemoryQuantityFiles.Value
  SxWMschKmQ
  while
  while
  While
   Window1.MemoryFile.Value = _Useful objects._Text._Split(Window1.MemoryFiles.Value, ";", Window1.MemoryCounter.Value)
   YCTMcFicGD
   deist
   deist
   Deist
   Window1.MemoryNewName.Value = _Useful objects._Files and paths._Get file name(Window1.MemoryFile.Value)
   sHrHRMLrUu
   deist
   deist
   Deist
   _Useful objects._Files and paths._Copy(Window1.MemoryFile.Value, Window1.Text1.Text & "\" & Window1.MemoryNewName.Value)
   wevvLLdfOe
   deist
   deist
   Deist
   IF Window1.MemoryCut.Value = Yes THEN
   QTuuVeExHa
   if
   if
   If
    _Useful objects._Files and paths._Delete(Window1.MemoryFile.Value)
    JwxFqKFPsf
    deist
    deist
    Deist
   End If
   QnnpRsEVAQ
   endif
   endif
   EndIf
   Window1.MemoryCounter.Value = Window1.MemoryCounter.Value + 1
   aCMbkXKvkm
   deist
   deist
   Deist
  End While
  IMjslxfqFB
  endwhile
  endwhile
  EndWhile
  Window1.MemoryCut.Value = No
  FNkhNceFcb
  deist
  deist
  Deist
  Window1.Window1.Enabled = Yes
  YgwpAGkVTR
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_ButtonGo_Click
  AIdGVDDsDR
  deist
  deist
  Deist
#End

MMs
Alignment
Yes
Auto tooltip
No
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Check on click
No
Checked
No
Display style
Image
Drop down
Nothing
Enabled
Yes
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
8
Font strikeout
No
Font underline
No
Fore color
Black
Image
Pictures\Picture7.png
Image align
Center
Image scaling
No
Image transparent color
Nothing
Index
0
Name
ToolDelete
Padding bottom
0
Padding left
10
Padding right
0
Padding top
0
Position
8
Shortcut keys
delete
Show shortcut keys
Yes
Tag

Text
Панель инструментов1 Пункт6
Text direction
Horizontal0
Text image relation
Overlay
Tooltip text

Visible
Yes
#Conteiner
Window1.Tool panel1[0]
#HistoryLevel
13
#TreeNode
#Parent
Window1(0)
#Index
26
ToolDelete
ToolDelete
mmenu
mmenu
Obj
 Click
 NMPxKMQdNH
 Click
 Click
 Sobyt
  Window1.Window1.Enabled = No
  sFSINbNsse
  deist
  deist
  Deist
  Window1.MemoryRowNumber.Value = Window1.Table1.Selected rows
  NIWmAvieLJ
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_MemoryToCreatePath_Changing value
  XjBKNLQwem
  deist
  deist
  Deist
  Window1.MemoryFiles.Value = Window1.MemoryFile.Value
  oGILXsnTrt
  deist
  deist
  Deist
  Window1.MemoryQuantityFiles.Value = _Useful objects._Text._Split count(Window1.MemoryFiles.Value, ";")
  nJAWDEobwM
  deist
  deist
  Deist
  Window1.MemoryCounter.Value = 1
  ckRDiIDHtB
  deist
  deist
  Deist
  WHILE Window1.MemoryCounter.Value <= Window1.MemoryQuantityFiles.Value
  JONGoHxKOG
  while
  while
  While
   Window1.MemoryFile.Value = _Useful objects._Text._Split(Window1.MemoryFiles.Value, ";", Window1.MemoryCounter.Value)
   INlPTOjcHI
   deist
   deist
   Deist
   _Useful objects._Files and paths._Delete(Window1.MemoryFile.Value)
   UnARJDmEbO
   deist
   deist
   Deist
   Window1.MemoryCounter.Value = Window1.MemoryCounter.Value + 1
   ofYpjXtsht
   deist
   deist
   Deist
  End While
  EdMqENxCiT
  endwhile
  endwhile
  EndWhile
  Window1.Window1.Enabled = Yes
  XaAkfUOuuk
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_ButtonGo_Click
  TtiAPbnueu
  deist
  deist
  Deist
#End

Tl
AllowUserToAddRows
No
AllowUserToDeleteRows
No
AllowUserToOrderColumns
No
AllowUserToResizeColumns
Yes
AllowUserToResizeRows
No
Anchor
Right_letf_top_bottom
Back color
128; 128; 128;
Border style
Nothing
Cell border style
Default
Column headers height
23
Column headers visible
Yes
Columns
"Name", "Type", "Size"
Columns count
3
Context menu
Nothing
Cursor
Default
DefaultCellStyleBackColor
255; 255; 255;
DefaultCellStyleForeColor
0; 0; 0;
DefaultCellStyleSelectionBackColor
51; 94; 168;
DefaultCellStyleSelectionForeColor
255; 255; 255;
Dock
Nothing
Edit mode
No
Enabled
Yes
Grid color
SystemDark
Height
219
Index
0
Maximum height
0
Maximum width
0
Minimum height
0
Minimum width
0
Multi select
Yes
Name
Table1
Read only table
No
Row headers visible
Yes
Rows
"Row1" | "Row1" | "", "Row2" | "Row2" | ""
Rows count
2
Scroll bars
Vertical
Selected columns
0,1,2
Selected rows
0
Selection mode
Rows
Tab index
0
Tab stop
Yes
Tag

Visible
Yes
Width
437
X
0
Y
58
#Conteiner
Window1.Window1[0]
#HistoryLevel
16
#TreeNode
#Parent
Window1(0)
#Index
27
Table1
Table1
panel
panel
Obj
 Size changed
 wgqDEXFGJl
 Size changed
 Size changed
 Sobyt
  Window1.Table1.Columns width(0) = Round(Window1.Table1.Width * "0,5")
  cRQfdaAGjp
  deist
  deist
  Deist
  Window1.Table1.Columns width(1) = Round(Window1.Table1.Width * "0,25")
  tFhwKaiXnu
  deist
  deist
  Deist
  Window1.Table1.Columns width(2) = Round(Window1.Table1.Width * "0,2")
  BYkpAqvfDL
  deist
  deist
  Deist
 Cell double click
 dcUYjwOlHv
 Cell double click
 Cell double click
 Sobyt
  Window1.MemoryRowNumber.Value = Window1.Table1._Line number
  ronGPqwsqd
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_MemoryToCreatePath_Changing value
  ofRNjCfYek
  deist
  deist
  Deist
  IF _Useful objects._Files and paths._Exist path(Window1.MemoryFile.Value) THEN
  cTDXMRjIMM
  if
  if
  If
   Window1.Text1.Text = Window1.MemoryFile.Value
   LuQpCKjeaH
   deist
   deist
   Deist
   _Useful objects._Call event.Window1_ButtonGo_Click
   sDmXUvJGng
   deist
   deist
   Deist
  ELSEIF _Useful objects._Files and paths._Exist file(Window1.MemoryFile.Value) THEN
  QnGVTXlPrw
  elseif
  elseif
  ElseIf
   _Useful objects._System._Run(Window1.MemoryFile.Value, )
   HofdRrObKX
   deist
   deist
   Deist
  Else
  RBwWpYfdCP
  else
  else
  Else
   _Useful objects._Show messange._Show message("Path " & Window1.MemoryFile.Value & " does not exist.", Ok, Information, "File manadger")
   HcSeuVotVd
   deist
   deist
   Deist
  End If
  XTlcAEVJGc
  endif
  endif
  EndIf
#End

#ProjectParams
#PoleznieDistance
25
#EndPoleznieDistance
#Expands
Window1
afOkGeNkwI
PiPUafktLb
GBKMoxxiDw
NaSQipkGDp
hVRnAViMkv
mbJuTfACAJ
ImFfFoUaUa
pXQILELqoc
lRasTiVvTB
DpBUihSuWH
AJWNAgxEJC
qUsiaIlESE
VIraxFdfxG
NVcUllKfTT
PeMowqaYVC
ITlJwYpBgI
jvpXUiIlWt
xPpcotqDqW
fWUhISFMha
fPStfTuiSD
fgoCvEMKjj
eSKlpYwGjc
TawkDmkcYO
GmcVgawwrE
oihxrQbjeA
nHRsqOeHoJ
CLMdpLIDrm
SxWMschKmQ
QTuuVeExHa
NMPxKMQdNH
JONGoHxKOG
wgqDEXFGJl
dcUYjwOlHv
cTDXMRjIMM
QnGVTXlPrw
RBwWpYfdCP
#EndExpands
#SelNode
Window1
#ActiveForm
Window1.Window1[0]
#ActiveObj
Window1.Table1[0]
#ImagePath
\Pictures
#ImageDefName
Picture
#pProgressForm
yes
#Icon
Pictures\icon.ico
#EndProjectParams
