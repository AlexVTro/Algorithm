Language = English
F
Allow run copies
Yes
Associate with extensions

Auto scroll minSize height
0
Auto scroll minSize width
0
Auto scroll position X
0
Auto scroll position Y
0
AutoRun
No
Back color
235; 233; 237;
Background image
Nothing
Background image layout
Tile
Context menu
Nothing
Control box
Yes
Cursor
Default
Enabled
Yes
Forbid close
No
Forbid maximize
No
Forbid minimize
No
Fore color
Black
Form border style
Normal
Height
363
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
Center screen
Tab index
0
Tab stop
Yes
Tag

Text
Window1
ToolTip

TopMost
No
Transparentcy key
Nothing
Visible
Yes
Width
503
Window state
Normal
X
0
Y
0
#Conteiner

#HistoryLevel
1
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
 FomuUJDjDq
 Created
 Created
 Sobyt
  Window1.Table1.Open Excel("Data base.xlsx", "Food list$")
  YktYaPoLYi
  deist
  deist
  Deist
  Window1.Table1.Columns width(0) = 30
  kFwjQkFXwM
  deist
  deist
  Deist
  Window1.Table1.Columns width(1) = 250
  oAALePKTbg
  deist
  deist
  Deist
#End

Tl
AllowUserToAddRows
Yes
AllowUserToDeleteRows
Yes
AllowUserToOrderColumns
No
AllowUserToResizeColumns
Yes
AllowUserToResizeRows
Yes
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
"Column1", "Column2"
Columns count
2
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
Default
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
Grid color
Systemdark
Height
303
Height of rows
22,22,22
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
No
Rows
"Row1" | "Row1", "Row2" | "Row2"
Rows count
3
Scroll bars
Both
Selected columns
0,1
Selected items value
"Row1","Row1"
Selected rows
0
Selection mode
Rows
Tab index
0
Tab stop
Yes
Tag

ToolTip

Visible
Yes
Width
507
Width of columns
100,100
X
0
Y
0
#Conteiner
Window1.Window1[0]
#HistoryLevel
0
#TreeNode
#Parent
Window1(0)
#Index
1
Table1
Table1
panel
panel
Obj
#End

B
Anchor
On bottom
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
23
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
OpenButton
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
Open
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
75
X
273
Y
308
#Conteiner
Window1.Window1[0]
#HistoryLevel
2
#TreeNode
#Parent
Window1(0)
#Index
2
OpenButton
OpenButton
button
button
Obj
 Click
 MGeuTRMkvu
 Click
 Click
 Sobyt
  Window1.Open dialog1.Show dialog
  pshlClnAkv
  deist
  deist
  Deist
  IF Window1.Open dialog1.Was cancel THEN
  OUTCPwHorW
  if
  if
  If
   _Useful objects._Interrupts._Break event
   UPtLqaTXwI
   deist
   deist
   Deist
  End If
  NsAKEEspTC
  endif
  endif
  EndIf
  IF _Useful objects._Files and paths._Get extension(Window1.Open dialog1.File name) = ".xlsx" THEN
  qLoqvqkcfU
  if
  if
  If
   Window1.Table1.Open Excel(Window1.Open dialog1.File name, Window1.TextSheetName.Text & "$")
   JVqXYawVsa
   deist
   deist
   Deist
  Else
  ROCchUTIvK
  else
  else
  Else
   Window1.Table1.Open table(Window1.Open dialog1.File name)
   EQUofJYDNA
   deist
   deist
   Deist
  End If
  oqqbxqBajd
  endif
  endif
  EndIf
#End

B
Anchor
On bottom
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
23
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
SaveButton
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
Save
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
75
X
353
Y
308
#Conteiner
Window1.Window1[0]
#HistoryLevel
3
#TreeNode
#Parent
Window1(0)
#Index
3
SaveButton
SaveButton
button
button
Obj
 Click
 ofoOHfgcLt
 Click
 Click
 Sobyt
  Window1.Save dialog1.Show dialog
  DaTBdheGrj
  deist
  deist
  Deist
  IF Window1.Open dialog1.Was cancel THEN
  lISMYtRavO
  if
  if
  If
   _Useful objects._Interrupts._Break event
   akMiDhqjXF
   deist
   deist
   Deist
  End If
  hxTRabevGt
  endif
  endif
  EndIf
  Window1.Table1.Save table(Window1.Save dialog1.File name)
  xbdVofLboM
  deist
  deist
  Deist
#End

B
Anchor
On bottom
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
23
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
PreviewButton
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
Preview
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
165
X
140
Y
336
#Conteiner
Window1.Window1[0]
#HistoryLevel
4
#TreeNode
#Parent
Window1(0)
#Index
4
PreviewButton
PreviewButton
button
button
Obj
 Click
 OendAOogrb
 Click
 Click
 Sobyt
  Window1.Print dialog1.Print table = "Table1"
  GWurjbIMIb
  deist
  deist
  Deist
  Window1.Print dialog1.Print text = "Printout of FoodTable"
  pxhTdKOCGK
  deist
  deist
  Deist
  Window1.Print dialog1.ShowPrevDialog
  CAwkddiVHc
  deist
  deist
  Deist
#End

B
Anchor
On bottom
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
23
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
PrintButton
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
Print
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
75
X
308
Y
336
#Conteiner
Window1.Window1[0]
#HistoryLevel
5
#TreeNode
#Parent
Window1(0)
#Index
5
PrintButton
PrintButton
button
button
Obj
 Click
 hIcEXbOrjh
 Click
 Click
 Sobyt
  Window1.Print dialog1.Print table = "Table1"
  VbeUQrACrP
  deist
  deist
  Deist
  Window1.Print dialog1.Print text = "Printout of FoodTable"
  AMsldMLVJF
  deist
  deist
  Deist
  Window1.Print dialog1.ShowPrinDialog
  vsEFFLugtr
  deist
  deist
  Deist
#End

PrD
Copies
1
Dialog color
0; 0; 0;
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
From page
1
Index
0
Name
Print dialog1
Padding bottom
10
Padding left
30
Padding right
10
Padding top
10
Print document

Print object

Print picture
Nothing
Print table

Print text

Table on center
Yes
Tag

To page
999
X
8
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
6
Print dialog1
Print dialog1
printdialog
printdialog
Obj
#End

OD
Check file exists
Yes
Check path exists
Yes
Default ext

File name
Таблица
Filter
Excel|*.xlsx|Таблицы|*.txt|Все файлы|*.*
Filter index
1
Index
0
Initial directory

Multi select files
No
Name
Open dialog1
Tag

Title

X
32
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
7
Open dialog1
Open dialog1
opendialog
opendialog
Obj
#End

Lb
Anchor
On bottom
Auto ellipsis
Yes
Back color
235; 233; 237;
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
15
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
Excel's sheet name
Text align
on left
ToolTip

Visible
Yes
Width
107
X
72
Y
312
#Conteiner
Window1.Window1[0]
#HistoryLevel
8
#TreeNode
#Parent
Window1(0)
#Index
8
Label1
Label1
label
label
Obj
#End

T
Allow input
All
Anchor
On bottom
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
TextSheetName
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
Food list
Text position
On left
ToolTip

Visible
Yes
Width
95
Word wrap
Yes
X
173
Y
310
#Conteiner
Window1.Window1[0]
#HistoryLevel
9
#TreeNode
#Parent
Window1(0)
#Index
9
TextSheetName
TextSheetName
textboks
textboks
Obj
#End

SD
Check file exists
No
Check path exists
Yes
Default ext

File name

Filter
Таблицы|*.txt|Все файлы|*.*
Filter index
1
Index
0
Initial directory

Name
Save dialog1
Tag

Title

X
56
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
10
#TreeNode
#Parent
Window1(0)
#Index
10
Save dialog1
Save dialog1
savedialog
savedialog
Obj
#End

#ProjectParams
#PoleznieDistance
25
#EndPoleznieDistance
#Expands
Window1
Window1
FomuUJDjDq
OpenButton
MGeuTRMkvu
OUTCPwHorW
qLoqvqkcfU
ROCchUTIvK
SaveButton
ofoOHfgcLt
lISMYtRavO
PreviewButton
OendAOogrb
PrintButton
hIcEXbOrjh
#EndExpands
#SelNode
pxhTdKOCGK
#ActiveForm
Window1.Window1[0]
#ActiveObj
Window1.Window1[0]
#ImagePath
Рисунки
#ImageDefName
Рисунок
#pProgressForm
yes
#Icon

#EndProjectParams
