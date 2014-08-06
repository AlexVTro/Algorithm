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
Sys
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
341
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
Network game
ToolTip

TopMost
No
Transparentcy key
Nothing
Visible
Yes
Width
413
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

CS
Anchor
Right_left_top
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Border style
Nothing
Client server type
Server
Command symbol
~~
Dock
Nothing
Enabled
Yes
File is sent
No
Height
45
Hide combo box
No
Hide sending files
No
Hide sending text
No
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
ClientServer1
Name in network

Path for downloads

Received command

Received file

Received text

Remote host
127.0.0.1
Remote port
8080
Sent command

Sent file

Sent text

Tab index
0
Tab stop
Yes
Tag

Text box log

Text box string

ToolTip

Visible
Yes
Width
398
X
8
Y
32
#Conteiner
Window1.Window1[0]
#HistoryLevel
1
#TreeNode
#Parent
Window1(0)
#Index
1
ClientServer1
ClientServer1
clientserver
clientserver
Obj
 Connection client
 dnMRmKhfKn
 Connection client
 Connection client
 Sobyt
  Window1.ClientServer1.Close listener
  nSgQBFBsUP
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_NewGame_Changed value
  WLmirIPorX
  deist
  deist
  Deist
 Connected to server
 VFDDpFEsvd
 Connected to server
 Connected to server
 Sobyt
  _Useful objects._Call event.Window1_NewGame_Changed value
  KgUvmSBiTe
  deist
  deist
  Deist
 Text received
 xaVSfQBdYe
 Text received
 Text received
 Sobyt
  IF _Useful objects._Text._Split(Window1.ClientServer1.Received text, " ", 1) = "OpponentScores:" THEN
  srllRhOdYu
  if
  if
  If
   Window1.LabelOpponentScores.Text = _Useful objects._Text._Split(Window1.ClientServer1.Received text, " ", 2)
   AHvqEpoouY
   deist
   deist
   Deist
   Window1.ButtonBones.Text = "Throw bones!"
   GgTMYuijVX
   deist
   deist
   Deist
   Window1.ButtonBones.Enabled = Yes
   DYSRiRsieE
   deist
   deist
   Deist
   _Useful objects._Call event.Window1_CheckWinner_Changed value
   DWJXdqddNn
   deist
   deist
   Deist
  End If
  aKhxWMXXLV
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
No
Flat style
Default
Font bold
No
Font family
Microsoft Sans Serif
Font italic
No
Font size
18
Font strikeout
No
Font underline
No
Fore color
Black
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
ButtonBones
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
Wait players...
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
245
X
84
Y
229
#Conteiner
Window1.Window1[0]
#HistoryLevel
8
#TreeNode
#Parent
Window1(0)
#Index
2
ButtonBones
ButtonBones
button
button
Obj
 Click
 xeGAqameHl
 Click
 Click
 Sobyt
  Window1.LabelBones.Text = Random number("6")
  uGKpViVtih
  deist
  deist
  Deist
  Window1.LabelYourScores.Text = Window1.LabelYourScores.Text + Window1.LabelBones.Text
  QEUhwrqTsV
  deist
  deist
  Deist
  IF Window1.ClientServer1.Client server type = Server THEN
  sUVIEWQIfD
  if
  if
  If
   Window1.ClientServer1.Send to clients("OpponentScores: " & Window1.LabelYourScores.Text)
   DxVarSxpcn
   deist
   deist
   Deist
  Else
  ocodEtIXCw
  else
  else
  Else
   Window1.ClientServer1.Send to server("OpponentScores: " & Window1.LabelYourScores.Text)
   hSjjrYjClw
   deist
   deist
   Deist
  End If
  QNNedRhsnd
  endif
  endif
  EndIf
  Window1.ButtonBones.Text = "Opponent's turn..."
  sBpFgQfqEJ
  deist
  deist
  Deist
  Window1.ButtonBones.Enabled = No
  OrFhUjNkhR
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_CheckWinner_Changed value
  ivDeVaNKAk
  deist
  deist
  Deist
#End

Lb
Anchor
Right_letf_top_bottom
Auto ellipsis
Yes
Back color
Sys
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
72
Font strikeout
No
Font underline
No
Fore color
Black
Height
146
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
LabelBones
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
0
Text align
center
ToolTip

Visible
Yes
Width
387
X
11
Y
80
#Conteiner
Window1.Window1[0]
#HistoryLevel
9
#TreeNode
#Parent
Window1(0)
#Index
3
LabelBones
LabelBones
label
label
Obj
#End

Lb
Anchor
On bottom
Auto ellipsis
Yes
Back color
Sys
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
Summ of our scores:
Text align
on right
ToolTip

Visible
Yes
Width
141
X
32
Y
288
#Conteiner
Window1.Window1[0]
#HistoryLevel
2
#TreeNode
#Parent
Window1(0)
#Index
4
Label1
Label1
label
label
Obj
#End

Lb
Anchor
On bottom
Auto ellipsis
Yes
Back color
Sys
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
Summ of opponent's scores:
Text align
on right
ToolTip

Visible
Yes
Width
141
X
32
Y
312
#Conteiner
Window1.Window1[0]
#HistoryLevel
3
#TreeNode
#Parent
Window1(0)
#Index
5
Label2
Label2
label
label
Obj
#End

Lb
Anchor
On bottom
Auto ellipsis
Yes
Back color
Sys
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
LabelYourScores
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
0
Text align
on left
ToolTip

Visible
Yes
Width
34
X
176
Y
288
#Conteiner
Window1.Window1[0]
#HistoryLevel
4
#TreeNode
#Parent
Window1(0)
#Index
6
LabelYourScores
LabelYourScores
label
label
Obj
#End

Lb
Anchor
On bottom
Auto ellipsis
Yes
Back color
Sys
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
LabelOpponentScores
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
0
Text align
on left
ToolTip

Visible
Yes
Width
34
X
176
Y
312
#Conteiner
Window1.Window1[0]
#HistoryLevel
5
#TreeNode
#Parent
Window1(0)
#Index
7
LabelOpponentScores
LabelOpponentScores
label
label
Obj
#End

M
Enabled
Yes
Index
0
Name
CheckWinner
Tag

Value

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
8
CheckWinner
CheckWinner
memory
memory
Obj
 Changed value
 LNiXEfbdDa
 Changed value
 Changed value
 Sobyt
  IF Window1.LabelYourScores.Text >= "33" THEN
  srwbiXIfIr
  if
  if
  If
   _Useful objects._Show messange._Show message("Congratulation! You winner!", Ok, Default, "Success!")
   DuKVtvvLhF
   deist
   deist
   Deist
   _Useful objects._Call event.Window1_NewGame_Changed value
   CUqRvAJfdn
   deist
   deist
   Deist
  ELSEIF Window1.LabelOpponentScores.Text >= "33" THEN
  IjgHWpxbtw
  elseif
  elseif
  ElseIf
   _Useful objects._Show messange._Show message("Sorry. You lose.", Ok, Default, "Game over...")
   QhBGgPCMdH
   deist
   deist
   Deist
   _Useful objects._Call event.Window1_NewGame_Changed value
   iOuvXXAedh
   deist
   deist
   Deist
  End If
  OcCTiSNDwD
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
NewGame
Tag

Value

X
72
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
9
NewGame
NewGame
memory
memory
Obj
 Changed value
 wUPimTSjjg
 Changed value
 Changed value
 Sobyt
  Window1.ButtonBones.Text = "Opponent's turn..."
  vuBUFrmjhx
  deist
  deist
  Deist
  Window1.ButtonBones.Enabled = No
  oSvLinegVN
  deist
  deist
  Deist
  Window1.LabelYourScores.Text = "0"
  BxNYJMwLJD
  deist
  deist
  Deist
  Window1.LabelOpponentScores.Text = "0"
  EOtvkRafNp
  deist
  deist
  Deist
  IF Window1.ClientServer1.Client server type = Server THEN
  edTwNdWDAx
  if
  if
  If
   Window1.ButtonBones.Text = "Throw bones!"
   nlMVewhaLq
   deist
   deist
   Deist
   Window1.ButtonBones.Enabled = Yes
   sbYetYXAaQ
   deist
   deist
   Deist
  End If
  NxRfiVdOLe
  endif
  endif
  EndIf
#End

Lb
Anchor
On bottom
Auto ellipsis
Yes
Back color
Sys
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
Yes
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
Label3
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
Game goes to 33 scores
Text align
center
ToolTip

Visible
Yes
Width
178
X
211
Y
296
#Conteiner
Window1.Window1[0]
#HistoryLevel
10
#TreeNode
#Parent
Window1(0)
#Index
10
Label3
Label3
label
label
Obj
#End

Lb
Anchor
On top
Auto ellipsis
Yes
Back color
Sys
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
Label4
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
Server Ip:
Text align
center
ToolTip

Visible
Yes
Width
70
X
44
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
11
Label4
Label4
label
label
Obj
#End

T
Allow input
All
Anchor
On top
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
127.0.0.1
Text position
On left
ToolTip

Visible
Yes
Width
85
Word wrap
Yes
X
108
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
13
#TreeNode
#Parent
Window1(0)
#Index
12
Text1
Text1
textboks
textboks
Obj
#End

Lb
Anchor
On top
Auto ellipsis
Yes
Back color
Sys
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
Label5
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
Port:
Text align
center
ToolTip

Visible
Yes
Width
41
X
196
Y
8
#Conteiner
Window1.Window1[0]
#HistoryLevel
12
#TreeNode
#Parent
Window1(0)
#Index
13
Label5
Label5
label
label
Obj
#End

T
Allow input
All
Anchor
On top
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
Text2
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
8080
Text position
On left
ToolTip

Visible
Yes
Width
38
Word wrap
Yes
X
236
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
14
Text2
Text2
textboks
textboks
Obj
#End

B
Anchor
On top
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
ButtonApply
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
Apply
Text align
center
Text image relation
Overlay
ToolTip

Visible
Yes
Width
94
X
284
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
15
ButtonApply
ButtonApply
button
button
Obj
 Click
 osLKNQCWQl
 Click
 Click
 Sobyt
  Window1.ClientServer1.Remote host = Window1.Text1.Text
  ixSUuCDoDm
  deist
  deist
  Deist
  Window1.ClientServer1.Remote port = Window1.Text2.Text
  FWchjoSfmH
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
ClientServer1
dnMRmKhfKn
VFDDpFEsvd
xaVSfQBdYe
srllRhOdYu
ButtonBones
xeGAqameHl
sUVIEWQIfD
ocodEtIXCw
CheckWinner
LNiXEfbdDa
srwbiXIfIr
IjgHWpxbtw
NewGame
wUPimTSjjg
edTwNdWDAx
ButtonApply
osLKNQCWQl
#EndExpands
#SelNode
DxVarSxpcn
#ActiveForm
Window1.Window1[0]
#ActiveObj
Window1.ButtonBones[0]
#ImagePath
Pictures
#ImageDefName
Рисунок
#pProgressForm
yes
#Icon

#EndProjectParams
