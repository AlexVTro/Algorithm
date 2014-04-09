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
240; 240; 240;
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
93
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
Download master
ToolTip

TopMost
No
Transparentcy key
Nothing
Visible
Yes
Width
453
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
#End

B
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
ButtonDownload
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
Download
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
82
X
8
Y
56
#Conteiner
Window1.Window1[0]
#HistoryLevel
1
#TreeNode
#Parent
Window1(0)
#Index
1
ButtonDownload
ButtonDownload
button
button
Obj
 Click
 FBXxXVNiej
 Click
 Click
 Sobyt
  Window1.Internet1.Download file("http://algorithm2.com/download/Algoritm2EngLast.exe", No)
  gdHwkgeRQF
  deist
  deist
  Deist
  Window1.Save dialog1.File name = _Useful objects._Files and paths._Get file name(Window1.Internet1.Url to go)
  TrmTUXLlGv
  deist
  deist
  Deist
  Window1.Save dialog1.Show dialog
  URGoCOAfKT
  deist
  deist
  Deist
  IF Window1.Save dialog1.Was cancel = Yes THEN
  aSFDaRUuiJ
  if
  if
  If
   _Useful objects._Call event.Window1_ButtonCancel_Click
   unMAILMEdA
   deist
   deist
   Deist
  End If
  JabgOOVQuV
  endif
  endif
  EndIf
#End

B
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
ButtonPause
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
Pause
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
82
X
272
Y
56
#Conteiner
Window1.Window1[0]
#HistoryLevel
2
#TreeNode
#Parent
Window1(0)
#Index
2
ButtonPause
ButtonPause
button
button
Obj
 Click
 RJTfermVGR
 Click
 Click
 Sobyt
  IF Window1.ButtonPause.Text = "Pause" THEN
  SsxSFGJlFn
  if
  if
  If
   Window1.Internet1.Download pause = Yes
   uecNNasQwH
   deist
   deist
   Deist
   Window1.ButtonPause.Text = "Resume"
   nnPxROsbaC
   deist
   deist
   Deist
  Else
  LFVFLuGqgf
  else
  else
  Else
   Window1.Internet1.Download pause = No
   EaOWglgFQE
   deist
   deist
   Deist
   Window1.ButtonPause.Text = "Pause"
   wUWxdddAAp
   deist
   deist
   Deist
  End If
  LgKCbpIWCR
  endif
  endif
  EndIf
#End

B
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
ButtonCancel
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
Cancel
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
82
X
360
Y
56
#Conteiner
Window1.Window1[0]
#HistoryLevel
3
#TreeNode
#Parent
Window1(0)
#Index
3
ButtonCancel
ButtonCancel
button
button
Obj
 Click
 TBjRDMXqQf
 Click
 Click
 Sobyt
  Window1.Internet1.Download cancel
  hmJVEogWag
  deist
  deist
  Deist
#End

Lb
Anchor
Left_top
Auto ellipsis
Yes
Back color
240; 240; 240;
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
21
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
LabelProgress
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
0%
Text align
center
ToolTip

Visible
Yes
Width
58
X
211
Y
56
#Conteiner
Window1.Window1[0]
#HistoryLevel
4
#TreeNode
#Parent
Window1(0)
#Index
4
LabelProgress
LabelProgress
label
label
Obj
#End

PrB
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
Nothing
Enabled
Yes
Height
18
Index
0
Marquee animation speed
100
Maximum
100
Maximum height
0
Maximum width
0
Minimum
0
Minimum height
0
Minimum width
0
Name
Progress bar1
Right to left layout
No
Step progress
10
Style progress
blocks
Tab index
0
Tab stop
Yes
Tag

ToolTip

Value
0
Visible
Yes
Width
117
X
96
Y
59
#Conteiner
Window1.Window1[0]
#HistoryLevel
5
#TreeNode
#Parent
Window1(0)
#Index
5
Progress bar1
Progress bar1
progressbar
progressbar
Obj
#End

Lb
Anchor
Left_top
Auto ellipsis
Yes
Back color
240; 240; 240;
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
Yes
Font family
Microsoft Sans Serif
Font italic
No
Font size
16
Font strikeout
No
Font underline
No
Fore color
82; 130; 254;
Height
37
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
Algorithm download 
Text align
center
ToolTip

Visible
Yes
Width
447
X
3
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
Label1
Label1
label
label
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
Программы|*.exe|Все файлы|*.*
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
8
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
Save dialog1
Save dialog1
savedialog
savedialog
Obj
#End

I
Accept
image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*
Allow auto redirect
No
Anchor
Left_top
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Border style
Nothing
Buffer size
5000
Content query

Content type
application/x-www-form-urlencoded
Cookies queries

Dock
Nothing
Download pause
No
Enabled
Yes
Encoding page
windows-1251
File downloading
No
Height
15
Http method
POST
Index
0
Keep alive
No
Language page

Maximum height
0
Maximum width
0
Minimum height
0
Minimum width
0
Name
Internet1
Path for downloads

Proxy IP

Proxy port
0
Result query

Tab index
0
Tab stop
Yes
Tag

Time delay
0
Time out
10000
ToolTip

Url redirect

Url referer

Url to go
http://www.Algoritm2.ru
User agent
Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;
Visible
Yes
Width
10
X
431
Y
6
#Conteiner
Window1.Window1[0]
#HistoryLevel
8
#TreeNode
#Parent
Window1(0)
#Index
8
Internet1
Internet1
internet
internet
Obj
 Received response
 IPsCQNWVqC
 Received response
 Received response
 Sobyt
  _Useful objects._Files and paths._Move(Window1.Internet1.Result query, Window1.Save dialog1.File name)
  IgcdNjbrRt
  deist
  deist
  Deist
  _Useful objects._Files and paths._Open directory(Window1.Save dialog1.File name)
  qjGrIMgQRG
  deist
  deist
  Deist
 Receive progress
 fGVABbKNjL
 Receive progress
 Receive progress
 Sobyt
  Window1.LabelProgress.Text = Window1.Internet1._Received percent & "%"
  xqHcTdVaFe
  deist
  deist
  Deist
  Window1.Progress bar1.Value = Window1.Internet1._Received percent
  TRrBnWIArE
  deist
  deist
  Deist
 Download cancelled
 gFEkUCJbbk
 Download cancelled
 Download cancelled
 Sobyt
  Window1.LabelProgress.Text = "0%"
  YNIGuxbcWe
  deist
  deist
  Deist
  Window1.Progress bar1.Value = "0"
  oFLllNNULc
  deist
  deist
  Deist
#End

#ProjectParams
#PoleznieDistance
25
#EndPoleznieDistance
#Expands
Window1
ButtonDownload
FBXxXVNiej
aSFDaRUuiJ
ButtonPause
RJTfermVGR
SsxSFGJlFn
LFVFLuGqgf
ButtonCancel
TBjRDMXqQf
Internet1
IPsCQNWVqC
fGVABbKNjL
gFEkUCJbbk
#EndExpands
#SelNode
wUWxdddAAp
#ActiveForm
Window1.Window1[0]
#ActiveObj
Window1.Window1[0]
#ImagePath
Pictures
#ImageDefName
Рисунок
#pProgressForm
yes
#Icon

#EndProjectParams
