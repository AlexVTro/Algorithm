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
240; 240; 240;
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
320
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
Window1
TopMost
No
Transparentcy key
Nothing
Visible
Yes
Width
500
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
 ldpdeLhFwt
 Created
 Created
 Sobyt
  _Useful objects._Call event.Window1_ButtonRefresh_Click
  jlqKNIjvTf
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
14
Font strikeout
No
Font underline
No
Fore color
Black
Height
32
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
LabelLast
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
There were:               days
Text align
center
Visible
Yes
Width
281
X
116
Y
63
#Conteiner
Window1.Window1[0]
#HistoryLevel
3
#TreeNode
#Parent
Window1(0)
#Index
1
LabelLast
LabelLast
label
label
Obj
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
14
Font strikeout
No
Font underline
No
Fore color
Black
Height
32
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
LabelDays
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

Text align
on right
Visible
Yes
Width
66
X
253
Y
63
#Conteiner
Window1.Window1[0]
#HistoryLevel
4
#TreeNode
#Parent
Window1(0)
#Index
2
LabelDays
LabelDays
label
label
Obj
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
14
Font strikeout
No
Font underline
No
Fore color
Black
Height
32
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
Registered:       
Text align
center
Visible
Yes
Width
236
X
113
Y
92
#Conteiner
Window1.Window1[0]
#HistoryLevel
5
#TreeNode
#Parent
Window1(0)
#Index
3
Label1
Label1
label
label
Obj
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
14
Font strikeout
No
Font underline
No
Fore color
Black
Height
32
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
LabelRegistered
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
 
Text align
on right
Visible
Yes
Width
56
X
270
Y
91
#Conteiner
Window1.Window1[0]
#HistoryLevel
6
#TreeNode
#Parent
Window1(0)
#Index
4
LabelRegistered
LabelRegistered
label
label
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
61
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
ButtonRefresh
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
Refresh
Text align
center
Text image relation
Overlay
Visible
Yes
Width
70
X
7
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
5
ButtonRefresh
ButtonRefresh
button
button
Obj
 Click
 ORCQkDYIcV
 Click
 Click
 Sobyt
  Window1.LabelStarted.Text = Window1.Trial1.Trial started
  UlQMpKUcEp
  deist
  deist
  Deist
  Window1.LabelDays.Text = Window1.Trial1.Days left
  mqoIWpFCVm
  deist
  deist
  Deist
  Window1.LabelRegistered.Text = Window1.Trial1.Activation
  IHtxCTaYqa
  deist
  deist
  Deist
  IF Window1.Trial1.Days left = 0 THEN
  lYbbYvUdSD
  if
  if
  If
   Window1.LabelRemark.Text = "Remark: " & Window1.Trial1.Remark
   lGrdrWbrrt
   deist
   deist
   Deist
  End If
  wVkoMNpRKV
  endif
  endif
  EndIf
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
Red
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
LabelRemark
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

Text align
center
Visible
Yes
Width
482
X
11
Y
127
#Conteiner
Window1.Window1[0]
#HistoryLevel
9
#TreeNode
#Parent
Window1(0)
#Index
6
LabelRemark
LabelRemark
label
label
Obj
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
User ID:
Text align
on left
Visible
Yes
Width
212
X
12
Y
152
#Conteiner
Window1.Window1[0]
#HistoryLevel
10
#TreeNode
#Parent
Window1(0)
#Index
7
Label2
Label2
label
label
Obj
#End

T
Anchor
Left_top
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
TextId
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
434
Word wrap
Yes
X
59
Y
150
#Conteiner
Window1.Window1[0]
#HistoryLevel
12
#TreeNode
#Parent
Window1(0)
#Index
8
TextId
TextId
textboks
textboks
Obj
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
14
Font strikeout
No
Font underline
No
Fore color
Black
Height
32
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
LabelStarted
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
 
Text align
on right
Visible
Yes
Width
52
X
295
Y
37
#Conteiner
Window1.Window1[0]
#HistoryLevel
11
#TreeNode
#Parent
Window1(0)
#Index
9
LabelStarted
LabelStarted
label
label
Obj
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
14
Font strikeout
No
Font underline
No
Fore color
Black
Height
32
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
Trial started:       
Text align
center
Visible
Yes
Width
236
X
123
Y
37
#Conteiner
Window1.Window1[0]
#HistoryLevel
0
#TreeNode
#Parent
Window1(0)
#Index
10
Label4
Label4
label
label
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
12
Font strikeout
No
Font underline
No
Fore color
Black
Height
36
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
ButtonIssue
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
Get activation KEY!
Text align
center
Text image relation
Overlay
Visible
Yes
Width
213
X
147
Y
191
#Conteiner
Window1.Window1[0]
#HistoryLevel
8
#TreeNode
#Parent
Window1(0)
#Index
11
ButtonIssue
ButtonIssue
button
button
Obj
 Click
 FCSvSpUOYe
 Click
 Click
 Sobyt
  Window1.Trial1.Key issue(Window1.TextId.Text, Yes)
  HNIRaVnQoL
  deist
  deist
  Deist
  _Useful objects._Call event.Window1_ButtonRefresh_Click
  wYLecBOnAn
  deist
  deist
  Deist
#End

Tr
Anchor
Left_top
Back color
Nothing
Background image
Nothing
Background image layout
Tile
Border style
Line
Context menu
Nothing
Cursor
Default
Days all
30
Dock
Nothing
Enabled
Yes
Height
30
Id program
2100960370
Id registry program
1012359994
Index
0
Key encryption
<RSAKeyValue><Modulus>rD8nVBV77MO10VRQjc3tKb1DmmpbctCLdvGVbFxwzSOLijEiIbfnukBCK9i+kPYizpcgNYpEwZGKClTkVXQwlKziMglKFtW/WLuXajWB7Rz2hi58vInLSSgpKKYp/mN8GN2ptAS7kfySWqI3hoFYz3muzSVJX91RF01t7dOvoxU=</Modulus><Exponent>AQAB</Exponent><P>52AnY986Z1ExmgkGgnzpWcX8A8TPVPV1VtFSLgUQrebe5bBiLvXT4VHWI9HBg0Rkf+BNqZxhWCYlwKUYOlYL0Q==</P><Q>vpQHMmg85TgZ91Su1rKT5ETh5uuROeQDwwPsBB5Q3R7ncSnLULczQPm4WHeeFwlarxv6m2ubsJlv2rEnD4zoBQ==</Q><DP>o1ReGgM/oCVRxXGvlbeFpmi7URHCZi/ryAB1aaULtCbwm+WaOZoxGrKBXsG4P+ispRR63ktU8DvllIs2gh+xsQ==</DP><DQ>B3HA1jc8KbgHS6IDMl/HZyNJr7uD8L73ZqbAkWidwAV1BPac+ootdlxK1ynVAxFaeXyeTXPmoP9dXy2MWQ8oAQ==</DQ><InverseQ>SuHtezofUxzlQZwoJqbcUOOm9GhvIsiHaqCpav78Ut18UYrngpZu529jw9x8wXh0TkPcpAhqZ6sXF4if9bkAog==</InverseQ><D>l22uFa4NlMk6Px3w87nmlptdo5N9ciMFeTxKMUnToYVuV796Ukpr3sI/amzSnH7HevhByNAWQlbBFPQtCTNswNWGymGCHN90NX653NcVYmSIqRVxxCuKC2+NNsFqTtm+rC74ozq23junojJ2fJ0CjQAekdLVqR1YDr2TNE7RNAE=</D></RSAKeyValue>
Maximum height
0
Maximum width
0
Message invalid
The key is invalid.
Message valid
The key is valid!
Minimum height
0
Minimum width
0
Name
Trial1
Tab index
0
Tab stop
Yes
Tag

Text button
Activate
Text field

Visible
No
Width
172
X
10
Y
283
#Conteiner
Window1.Window1[0]
#HistoryLevel
2
#TreeNode
#Parent
Window1(0)
#Index
12
Trial1
Trial1
trial
trial
Obj
#End

#ProjectParams
#PoleznieDistance
0
#EndPoleznieDistance
#Expands
Window1
Window1
ldpdeLhFwt
ORCQkDYIcV
lYbbYvUdSD
FCSvSpUOYe
#EndExpands
#SelNode
Trial1
#ActiveForm
Window1.Window1[0]
#ActiveObj
Window1.LabelStarted[0]
#ImagePath
Рисунки
#ImageDefName
Рисунок
#pProgressForm
yes
#Icon

#EndProjectParams
