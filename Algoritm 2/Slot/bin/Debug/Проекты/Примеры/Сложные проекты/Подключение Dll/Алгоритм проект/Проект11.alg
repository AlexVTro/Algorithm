Language = Russian
F
Текст
Окно1
X
0
Y
0
Ассоциировать с расширениями

Видимый
Да
Всплывающее меню
Никакой
Вспомогательное поле

Вышина
419
Главная форма
Да
Главное меню
Никакой
Добавить в автозагрузку
Нет
Запретить закрытие
Нет
Запретить минимизировать
Нет
Запретить разворачивать
Нет
Иконка
Никакой
Имя
Окно1
Курсор
Обычный
Максимальная вышина
0
Максимальная ширина
0
Минимальная вышина
0
Минимальная ширина
0
Номер
0
Оконные кнопки и меню
Да
Отображать в панели задач
Да
Отображать в трее
Нет
Поверх всех окон
Нет
Подсказка

Показывать иконку
Да
Прозрачность
100
Прозрачный цвет
Никакой
Прокрутка
Нет
Прокрутка минимальная вышина
0
Прокрутка минимальная ширина
0
Прокручено по X
0
Прокручено по Y
0
Работает
Да
Разрешить запуск копий
Да
Стартовая позиция
По центру экрана
Статус окна
Нормальный
Стиль окна
Нормальный
Стиль фона
Плитка
ТабНомер
0
ТабСтоп
Да
Фоновой рисунок
Никакой
Цвет
240; 240; 240;
Цвет шрифта
Черный
Ширина
1051
#Conteiner

#TreeNode
#Parent
Окно1(0)
#Index
0
Окно1
Окно1
window
window
Obj
#End

B
X
824
Y
356
АвтоТроеточие
Да
Видимый
Да
Всплывающее меню
Никакой
Вспомогательное поле

Вышина
47
Имя
Кнопка1
Курсор
Обычный
Максимальная вышина
0
Максимальная ширина
0
Минимальная вышина
0
Минимальная ширина
0
Номер
0
Подсказка

Поле сверху
0
Поле слева
0
Поле снизу
0
Поле справа
0
Положение рисунка
Центр
Положение текста
центр
Привязка
Слева_Сверху
Работает
Да
Растяжка
Никакой
Рисунок
Никакой
Стиль кнопки
Обычный
Стиль фона
Плитка
ТабНомер
0
ТабСтоп
Да
Текст
Выполнить код
Текст и рисунок
Поверх
Фоновой рисунок
Никакой
Цвет
Никакой
Цвет шрифта
Черный
Ширина
207
Шрифт
Microsoft Sans Serif
Шрифт жирный
Нет
Шрифт зачеркнутый
Нет
Шрифт курсив
Нет
Шрифт подчеркнутый
Нет
Шрифт размер
8
#Conteiner
Окно1.Окно1[0]
#HistoryLevel
1
#TreeNode
#Parent
Окно1(0)
#Index
2
Кнопка1
Кнопка1
button
button
Obj
 Клик
 TNRBjpWFOg
 Click
 Click
 Sobyt
  _Полезные объекты._Расширенные возможности._Выполнить код VBNet(Окно1.Текст1.Текст & Окно1.Текст2.Текст)
  YHLbqEPNLq
  deist
  deist
  Deist
  Окно1.Надпись4.Текст = _Полезные объекты._Система._Текст буфера обмена
  pKoVmhNpuf
  deist
  deist
  Deist
#End

T
X
8
Y
36
Видимый
Да
Всплывающее меню
Никакой
Вспомогательное поле

Выделенный текст

Вышина
371
Длинна выделения
0
Имя
Текст1
Максимальная вышина
0
Максимальная длинна
32767
Максимальная ширина
0
Минимальная вышина
0
Минимальная ширина
0
Многострочность
Да
Начало выделения
1
Номер
0
Перенос по словам
Да
Подсказка

Полосы прокрутки
вертикальная
Привязка
Слева_Сверху
Работает
Да
Разрешить вводить
Все
Расположение текста
Слева
Растяжка
Никакой
Символ пароля

Скрывать выделение
Нет
Стиль рамки
объем
ТабНомер
0
ТабСтоп
Да
Текст
Imports System¶Imports System.Windows.Forms¶Imports VB = Microsoft.VisualBasic¶Imports Microsoft.VisualBasic.Strings¶Imports Microsoft.VisualBasic.Conversion¶Imports Microsoft.VisualBasic.Interaction¶Imports System.Runtime.InteropServices¶Imports System.Text¶¶Public Module Astro¶    Private Structure orient¶        Dim i As Integer¶        <VB.VBFixedString(16), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, _¶SizeConst:=16)> Public s() As Char¶    End Structure¶¶#Region "Declare Function "¶¶¶¶¶¶    <DllImport("swedll32.dll", CharSet:=CharSet.Ansi, EntryPoint:="swe_calc_ut")> _¶    Private Function swe_calc_ut(ByVal tjd_ut As Double, ByVal ipl As Integer, ByVal iflag As Integer, ByVal xx As Double(), ByVal serr As StringBuilder) As Integer¶    End Function¶¶    ''' <summary>¶    ''' swe_calc_ut - Compute a planet or other bodies¶    ''' </summary>¶    ''' <param name="tjd_ut">Julian day, Universal Time</param>¶    ''' <param name="ipl">planet number</param>¶    ''' <param name="addFlags">a 32bit integercontaining bit flags that indicate what kind of computation wanted</param>¶    ''' <param name="xx">array of 6 doubles for Longitude,latitude,distance,speed in long, speed in lat and speed in dist</param>¶¶¶    <DllImport("swedll32.dll", CharSet:=CharSet.Ansi, EntryPoint:="_swe_rise_trans@52")> _¶    Private Function xyz_swe_rise_trans(ByVal tjd_ut As Double, ByVal ipl As Integer, ByVal starname As String, ByVal epheflag As Integer, ByVal rsmi As Integer, ByVal geopos As Double(), _¶ ByVal atpress As Double, ByVal attemp As Double, ByVal tret As Double(), ByVal serr As StringBuilder) As Integer¶    End Function¶¶¶¶¶    Public Declare Function swe_rise_trans Lib "swedll32.dll" _¶        Alias "_swe_rise_trans@52" ( _¶          ByVal tjd_ut As Double, _¶          ByVal ipl As Long, _¶          ByVal starname As String, _¶          ByVal epheflag As Long, _¶          ByVal rsmi As Long, _¶          ByRef geopos As Double, _¶          ByVal atpress As Double, _¶          ByVal attemp As Double, _¶          ByRef tret As Double, _¶          ByVal serr As String _¶        ) As Long¶¶¶    Private Declare Function swe_calc Lib "swedll32.dll" Alias "_swe_calc@24" (ByVal tjd As Double, ByVal ipl As Integer, ByVal iflag As Integer, ByRef x As Double, ByVal serr As String) As Integer ' x must be first of six array elements¶    ' serr must be able to hold 256 bytes¶¶    Private Declare Function swe_calc_d Lib "swedll32.dll" Alias "_swe_calc_d@20" (ByRef tjd As Double, ByVal ipl As Integer, ByVal iflag As Integer, ByRef x As Double, ByVal serr As String) As Integer ' x must be first of six array elements¶    ' serr must be able to hold 256 bytes¶¶    Private Declare Function swe_close Lib "swedll32.dll" Alias "_swe_close@0" () As Integer¶¶    Private Declare Function swe_close_d Lib "swedll32.dll" Alias "_swe_close_d@4" (ByVal ivoid As Integer) As Integer ' argument ivoid is ignored¶¶    Private Declare Sub swe_cotrans Lib "swedll32.dll" Alias "_swe_cotrans@16" (ByRef xpo As Double, ByRef xpn As Double, ByVal eps As Double)¶¶    Private Declare Function swe_cotrans_d Lib "swedll32.dll" Alias "_swe_cotrans_d@12" (ByRef xpo As Double, ByRef xpn As Double, ByRef eps As Double) As Integer¶¶    Private Declare Sub swe_cotrans_sp Lib "swedll32.dll" Alias "_swe_cotrans_sp@16" (ByRef xpo As Double, ByRef xpn As Double, ByVal eps As Double)¶¶    Private Declare Function swe_cotrans_sp_d Lib "swedll32.dll" Alias "_swe_cotrans_sp_d@12" (ByRef xpo As Double, ByRef xpn As Double, ByRef eps As Double) As Integer¶¶    Private Declare Sub swe_cs2degstr Lib "swedll32.dll" Alias "_swe_cs2degstr@8" (ByVal t As Integer, ByVal s As String)¶¶    Private Declare Function swe_cs2degstr_d Lib "swedll32.dll" Alias "_swe_cs2degstr_d@8" (ByVal t As Integer, ByVal s As String) As Integer¶¶    Private Declare Sub swe_cs2lonlatstr Lib "swedll32.dll" Alias "_swe_cs2lonlatstr@16" (ByVal t As Integer, ByVal pchar As Byte, ByVal mchar As Byte, ByVal s As String)¶¶    Private Declare Function swe_cs2lonlatstr_d Lib "swedll32.dll" Alias "_swe_cs2lonlatstr_d@16" (ByVal t As Integer, ByRef pchar As Byte, ByRef mchar As Byte, ByVal s As String) As Integer¶¶    Private Declare Sub swe_cs2timestr Lib "swedll32.dll" Alias "_swe_cs2timestr@16" (ByVal t As Integer, ByVal sep As Integer, ByVal supzero As Integer, ByVal s As String)¶¶    Private Declare Function swe_cs2timestr_d Lib "swedll32.dll" Alias "_swe_cs2timestr_d@16" (ByVal t As Integer, ByVal sep As Integer, ByVal supzero As Integer, ByVal s As String) As Integer¶¶    Private Declare Function swe_csnorm Lib "swedll32.dll" Alias "_swe_csnorm@4" (ByVal p As Integer) As Integer¶¶    Private Declare Function swe_csnorm_d Lib "swedll32.dll" Alias "_swe_csnorm_d@4" (ByVal p As Integer) As Integer¶¶    Private Declare Function swe_csroundsec Lib "swedll32.dll" Alias "_swe_csroundsec@4" (ByVal p As Integer) As Integer¶¶    Private Declare Function swe_csroundsec_d Lib "swedll32.dll" Alias "_swe_csroundsec_d@4" (ByVal p As Integer) As Integer¶¶    Private Declare Function swe_d2l Lib "swedll32.dll" Alias "_swe_d2l@8" () As Integer¶¶    Private Declare Function swe_d2l_d Lib "swedll32.dll" Alias "_swe_d2l_d@4" () As Integer¶¶¶    Private Declare Function swe_date_conversion Lib "swedll32.dll" Alias "_swe_date_conversion@28" (ByVal Year_Renamed As Integer, ByVal Month_Renamed As Integer, ByVal Day_Renamed As Integer, ByVal utime As Double, ByVal cal As Byte, ByRef tjd As Double) As Integer¶¶¶    Private Declare Function swe_date_conversion_d Lib "swedll32.dll" Alias "_swe_date_conversion_d@24" (ByVal Year_Renamed As Integer, ByVal Month_Renamed As Integer, ByVal Day_Renamed As Integer, ByRef utime As Double, ByRef cal As Byte, ByRef tjd As Double) As Integer¶¶    Private Declare Function swe_day_of_week Lib "swedll32.dll" Alias "_swe_day_of_week@8" (ByVal jd As Double) As Integer¶¶    Private Declare Function swe_day_of_week_d Lib "swedll32.dll" Alias "_swe_day_of_week_d@4" (ByRef jd As Double) As Integer¶¶    Private Declare Function swe_degnorm Lib "swedll32.dll" Alias "_swe_degnorm@8" (ByVal jd As Double) As Double¶¶    Private Declare Function swe_degnorm_d Lib "swedll32.dll" Alias "_swe_degnorm_d@4" (ByRef jd As Double) As Integer¶¶    Private Declare Function swe_deltat Lib "swedll32.dll" Alias "_swe_deltat@8" (ByVal jd As Double) As Double¶¶    Private Declare Function swe_deltat_d Lib "swedll32.dll" Alias "_swe_deltat_d@8" (ByRef jd As Double, ByRef deltat As Double) As Integer¶¶    Private Declare Function swe_difcs2n Lib "swedll32.dll" Alias "_swe_difcs2n@8" (ByVal p1 As Integer, ByVal p2 As Integer) As Integer¶¶    Private Declare Function swe_difcs2n_d Lib "swedll32.dll" Alias "_swe_difcs2n_d@8" (ByVal p1 As Integer, ByVal p2 As Integer) As Integer¶¶    Private Declare Function swe_difcsn Lib "swedll32.dll" Alias "_swe_difcsn@8" (ByVal p1 As Integer, ByVal p2 As Integer) As Integer¶¶    Private Declare Function swe_difcsn_d Lib "swedll32.dll" Alias "_swe_difcsn_d@8" (ByVal p1 As Integer, ByVal p2 As Integer) As Integer¶¶    Private Declare Function swe_difdeg2n Lib "swedll32.dll" Alias "_swe_difdeg2n@16" (ByVal p1 As Double, ByVal p2 As Double) As Double¶¶    Private Declare Function swe_difdeg2n_d Lib "swedll32.dll" Alias "_swe_difdeg2n_d@12" (ByRef p1 As Double, ByRef p2 As Double, ByRef diff As Double) As Integer¶¶    Private Declare Function swe_difdegn Lib "swedll32.dll" Alias "_swe_difdegn@16" (ByVal p1 As Double, ByVal p2 As Double) As Integer¶¶    Private Declare Function swe_difdegn_d Lib "swedll32.dll" Alias "_swe_difdegn_d@12" (ByRef p1 As Double, ByRef p2 As Double, ByRef diff As Double) As Integer¶¶    Private Declare Function swe_fixstar Lib "swedll32.dll" Alias "_swe_fixstar@24" (ByVal star As String, ByVal tjd As Double, ByVal iflag As Integer, ByRef x As Double, ByVal serr As String) As Integer ' x must be first of six array elements¶    ' serr must be able to hold 256 bytes¶    ' star must be able to hold 40 bytes¶¶    Private Declare Function swe_fixstar_d Lib "swedll32.dll" Alias "_swe_fixstar_d@20" (ByVal star As String, ByRef tjd As Double, ByVal iflag As Integer, ByRef x As Double, ByVal serr As String) As Integer ' x must be first of six array elements¶    ' serr must be able to hold 256 bytes¶    ' star must be able to hold 40 bytes¶¶    Private Declare Function swe_get_ayanamsa Lib "swedll32.dll" Alias "_swe_get_ayanamsa@8" (ByVal tjd_et As Double) As Double¶¶    Private Declare Function swe_get_ayanamsa_d Lib "swedll32.dll" Alias "_swe_get_ayanamsa_d@8" (ByRef tjd_et As Double, ByRef ayan As Double) As Integer¶¶    Private Declare Sub swe_get_planet_name Lib "swedll32.dll" Alias "_swe_get_planet_name@8" (ByVal ipl As Integer, ByVal pname As String)¶¶    Private Declare Function swe_get_planet_name_d Lib "swedll32.dll" Alias "_swe_get_planet_name_d@8" (ByVal ipl As Integer, ByVal pname As String) As Integer¶¶    Private Declare Function swe_get_tid_acc Lib "swedll32.dll" Alias "_swe_get_tid_acc@0" () As Double¶¶    Private Declare Function swe_get_tid_acc_d Lib "swedll32.dll" Alias "_swe_get_tid_acc_d@4" (ByRef x As Double) As Integer¶¶    Private Declare Function swe_houses Lib "swedll32.dll" Alias "_swe_houses@36" (ByVal tjd_ut As Double, ByVal geolat As Double, ByVal geolon As Double, ByVal ihsy As Integer, ByRef hcusps As Double, ByRef ascmc As Double) As Integer ' hcusps must be first of 13 array elements¶    ' ascmc must be first of 10 array elements¶¶    Private Declare Function swe_houses_d Lib "swedll32.dll" Alias "_swe_houses_d@24" (ByRef tjd_ut As Double, ByRef geolat As Double, ByRef geolon As Double, ByVal ihsy As Integer, ByRef hcusps As Double, ByRef ascmc As Double) As Integer ' hcusps must be first of 13 array elements¶    ' ascmc must be first of 10 array elements¶¶    Private Declare Function swe_houses_ex Lib "swedll32.dll" Alias "_swe_houses_ex@40" (ByVal tjd_ut As Double, ByVal iflag As Integer, ByVal geolat As Double, ByVal geolon As Double, ByVal ihsy As Integer, ByRef hcusps As Double, ByRef ascmc As Double) As Integer ' hcusps must be first of 13 array elements¶    ' ascmc must be first of 10 array elements¶¶    Private Declare Function swe_houses_ex_d Lib "swedll32.dll" Alias "_swe_houses_ex_d@28" (ByRef tjd_ut As Double, ByVal iflag As Integer, ByRef geolat As Double, ByRef geolon As Double, ByVal ihsy As Integer, ByRef hcusps As Double, ByRef ascmc As Double) As Integer ' hcusps must be first of 13 array elements¶    ' ascmc must be first of 10 array elements¶¶    Private Declare Function swe_houses_armc Lib "swedll32.dll" Alias "_swe_houses_armc@36" (ByVal armc As Double, ByVal geolat As Double, ByVal eps As Double, ByVal ihsy As Integer, ByRef hcusps As Double, ByRef ascmc As Double) As Integer ' hcusps must be first of 13 array elements¶    ' ascmc must be first of 10 array elements¶¶    Private Declare Function swe_houses_armc_d Lib "swedll32.dll" Alias "_swe_houses_armc_d@24" (ByRef armc As Double, ByRef geolat As Double, ByRef eps As Double, ByVal ihsy As Integer, ByRef hcusps As Double, ByRef ascmc As Double) As Integer ' hcusps must be first of 13 array elements¶    ' ascmc must be first of 10 array elements¶¶    Private Declare Function swe_house_pos Lib "swedll32.dll" Alias "_swe_house_pos@36" (ByVal armc As Double, ByVal geolat As Double, ByVal eps As Double, ByVal ihsy As Integer, ByRef xpin As Double, ByVal serr As String) As Double¶    ' xpin must be first of 2 array elements¶¶    Private Declare Function swe_house_pos_d Lib "swedll32.dll" Alias "_swe_house_pos_d@28" (ByRef armc As Double, ByRef geolat As Double, ByRef eps As Double, ByVal ihsy As Integer, ByRef xpin As Double, ByRef hpos As Double, ByVal serr As String) As Integer¶¶    Private Declare Function swe_julday Lib "swedll32.dll" Alias "_swe_julday@24" (ByVal Year_Renamed As Integer, ByVal Month_Renamed As Integer, ByVal Day_Renamed As Integer, ByVal hour_Renamed As Double, ByVal gregflg As Integer) As Double¶¶    Private Declare Function swe_julday_d Lib "swedll32.dll" Alias "_swe_julday_d@24" (ByVal Year_Renamed As Integer, ByVal Month_Renamed As Integer, ByVal Day_Renamed As Integer, ByRef hour_Renamed As Double, ByVal gregflg As Integer, ByRef tjd As Double) As Integer¶¶    Private Declare Sub swe_revjul Lib "swedll32.dll" Alias "_swe_revjul@28" (ByVal tjd As Double, ByVal gregflg As Integer, ByRef Year_Renamed As Integer, ByRef Month_Renamed As Integer, ByRef Day_Renamed As Integer, ByRef hour_Renamed As Double)¶¶    Private Declare Function swe_revjul_d Lib "swedll32.dll" Alias "_swe_revjul_d@24" (ByRef tjd As Double, ByVal gregflg As Integer, ByRef Year_Renamed As Integer, ByRef Month_Renamed As Integer, ByRef Day_Renamed As Integer, ByRef hour_Renamed As Double) As Integer¶¶    Private Declare Function swe_set_sid_mode Lib "swedll32.dll" Alias "_swe_set_sid_mode@20" (ByVal sid_mode As Integer, ByVal t0 As Double, ByVal ayan_t0 As Double) As Integer¶¶    Private Declare Function swe_set_sid_mode_d Lib "swedll32.dll" Alias "_swe_sid_mode_d@12" (ByVal sid_mode As Integer, ByRef t0 As Double, ByRef ayan_t0 As Double) As Integer¶¶    Private Declare Function swe_set_topo Lib "swedll32.dll" Alias "_swe_set_topo@24" (ByVal geolon As Double, ByVal geolat As Double, ByVal altitude As Double) As Object¶¶    Private Declare Function swe_set_topo_d Lib "swedll32.dll" Alias "_swe_set_topo_d@12" (ByRef geolon As Double, ByRef geolat As Double, ByRef altitude As Double) As Object¶¶    Private Declare Function swe_lun_eclipse_how Lib "swedll32.dll" Alias "_swe_lun_eclipse_how@24" (ByVal tjd_ut As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef attr As Double, ByVal serr As String) As Integer¶¶    Private Declare Function swe_lun_eclipse_how_d Lib "swedll32.dll" Alias "_swe_lun_eclipse_how_d@20" (ByRef tjd_ut As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef attr As Double, ByVal serr As String) As Integer¶¶    Private Declare Function swe_lun_eclipse_when Lib "swedll32.dll" Alias "_swe_lun_eclipse_when@28" (ByVal tjd_start As Double, ByVal ifl As Integer, ByVal ifltype As Integer, ByRef tret As Double, ByVal backward As Integer, ByVal serr As String) As Integer¶¶    Private Declare Function swe_lun_eclipse_when_d Lib "swedll32.dll" Alias "_swe_lun_eclipse_when_d@24" (ByRef tjd_start As Double, ByVal ifl As Integer, ByVal ifltype As Integer, ByRef tret As Double, ByVal backward As Integer, ByVal serr As String) As Integer¶¶    Private Declare Function swe_sol_eclipse_how Lib "swedll32.dll" Alias "_swe_sol_eclipse_how@24" (ByVal tjd_ut As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef attr As Double, ByVal serr As String) As Integer¶¶    Private Declare Function swe_sol_eclipse_how_d Lib "swedll32.dll" Alias "_swe_sol_eclipse_how_d@20" (ByRef tjd_ut As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef attr As Double, ByVal serr As String) As Integer¶¶    Private Declare Function swe_sol_eclipse_when_glob Lib "swedll32.dll" Alias "_swe_sol_eclipse_when_glob@28" (ByVal tjd_start As Double, ByVal ifl As Integer, ByVal ifltype As Integer, ByRef tret As Double, ByVal backward As Integer, ByVal serr As String) As Integer¶¶    Private Declare Function swe_sol_eclipse_when_glob_d Lib "swedll32.dll" Alias "_swe_sol_eclipse_when_glob_d@24" (ByRef tjd_start As Double, ByVal ifl As Integer, ByVal ifltype As Integer, ByRef tret As Double, ByVal backward As Integer, ByVal serr As String) As Integer¶¶    Private Declare Function swe_sol_eclipse_when_loc Lib "swedll32.dll" Alias "_swe_sol_eclipse_when_loc@32" (ByVal tjd_start As Double, ByVal ifl As Integer, ByRef tret As Double, ByRef attr As Double, ByVal backward As Integer, ByVal serr As String) As Integer¶¶    Private Declare Function swe_sol_eclipse_when_loc_d Lib "swedll32.dll" Alias "_swe_sol_eclipse_when_loc_d@28" (ByRef tjd_start As Double, ByVal ifl As Integer, ByRef tret As Double, ByRef attr As Double, ByVal backward As Integer, ByVal serr As String) As Integer¶¶    Private Declare Function swe_sol_eclipse_where Lib "swedll32.dll" Alias "_swe_sol_eclipse_where@24" (ByVal tjd_ut As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef attr As Double, ByVal backward As Integer, ByVal serr As String) As Integer¶¶    Private Declare Function swe_sol_eclipse_where_d Lib "swedll32.dll" Alias "_swe_sol_eclipse_where_d@20" (ByRef tjd_ut As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef attr As Double, ByVal backward As Integer, ByVal serr As String) As Integer¶¶    Private Declare Function swe_pheno Lib "swedll32.dll" Alias "_swe_pheno@24" (ByVal tjd As Double, ByVal ipl As Integer, ByVal iflag As Integer, ByRef attr As Double, ByVal serr As String) As Integer¶¶    Private Declare Function swe_pheno_d Lib "swedll32.dll" Alias "_swe_pheno_d@20" (ByRef tjd As Double, ByVal ipl As Integer, ByVal iflag As Integer, ByRef attr As Double, ByVal serr As String) As Integer¶¶    Private Declare Sub swe_set_ephe_path Lib "swedll32.dll" Alias "_swe_set_ephe_path@4" (ByVal path As String)¶¶    Private Declare Function swe_set_ephe_path_d Lib "swedll32.dll" Alias "_swe_set_ephe_path_d@4" (ByVal path As String) As Integer¶¶    Private Declare Sub swe_set_jpl_file Lib "swedll32.dll" Alias "_swe_set_jpl_file@4" (ByVal file As String)¶¶    Private Declare Function swe_set_jpl_file_d Lib "swedll32.dll" Alias "_swe_set_jpl_file_d@4" (ByVal file As String) As Integer¶¶    Private Declare Sub swe_set_tid_acc Lib "swedll32.dll" Alias "_swe_set_tid_acc@8" (ByVal x As Double)¶¶    Private Declare Function swe_set_tid_acc_d Lib "swedll32.dll" Alias "_swe_set_tid_acc_d@4" (ByRef x As Double) As Integer¶¶    Private Declare Function swe_sidtime0 Lib "swedll32.dll" Alias "_swe_sidtime0@24" (ByVal tjd_ut As Double, ByVal ecl As Double, ByVal nut As Double) As Double¶¶    Private Declare Function swe_sidtime0_d Lib "swedll32.dll" Alias "_swe_sidtime0_d@16" (ByRef tjd_ut As Double, ByRef ecl As Double, ByRef nut As Double, ByRef sidt As Double) As Integer¶¶    Private Declare Function swe_sidtime Lib "swedll32.dll" Alias "_swe_sidtime@8" (ByVal tjd_ut As Double) As Double¶¶    Private Declare Function swe_sidtime_d Lib "swedll32.dll" Alias "_swe_sidtime_d@8" (ByRef tjd_ut As Double, ByRef sidt As Double) As Integer¶¶    Private Declare Function swe_time_equ Lib "swedll32.dll" Alias "_swe_time_equ@16" (ByVal tjd_ut As Double, ByVal e As Double, ByRef serr As String) As Integer¶¶    ' planet and body numbers (parameter ipl) for swe_calc()¶    Const SE_SUN As Short = 0¶    Const SE_MOON As Short = 1¶    Const SE_MERCURY As Short = 2¶    Const SE_VENUS As Short = 3¶    Const SE_MARS As Short = 4¶    Const SE_JUPITER As Short = 5¶    Const SE_SATURN As Short = 6¶    Const SE_URANUS As Short = 7¶    Const SE_NEPTUNE As Short = 8¶    Const SE_PLUTO As Short = 9¶    Const SE_MEAN_NODE As Short = 10¶    Const SE_TRUE_NODE As Short = 11¶    Const SE_MEAN_APOG As Short = 12¶    Const SE_OSCU_APOG As Short = 13¶    Const SE_EARTH As Short = 14¶    Const SE_CHIRON As Short = 15¶    Const SE_PHOLUS As Short = 16¶    Const SE_CERES As Short = 17¶    Const SE_PALLAS As Short = 18¶    Const SE_JUNO As Short = 19¶    Const SE_VESTA As Short = 20¶    ' Hamburger or Uranian "planets"¶    Const SE_CUPIDO As Short = 40¶    Const SE_HADES As Short = 41¶    Const SE_ZEUS As Short = 42¶    Const SE_KRONOS As Short = 43¶    Const SE_APOLLON As Short = 44¶    Const SE_ADMETOS As Short = 45¶    Const SE_VULKANUS As Short = 46¶    Const SE_POSEIDON As Short = 47¶    ' other ficticious bodies¶    Const SE_ISIS As Short = 48¶    Const SE_NIBIRU As Short = 49¶    Const SE_HARRINGTON As Short = 50¶    Const SE_NEPTUNE_LEVERRIER As Short = 51¶    Const SE_NEPTUNE_ADAMS As Short = 52¶    Const SE_PLUTO_LOWELL As Short = 53¶    Const SE_PLUTO_PICKERING As Short = 54¶¶    ' iflag values for swe_calc() and swe_fixstar()¶    Const SEFLG_JPLEPH As Integer = 1¶    Const SEFLG_SWIEPH As Integer = 2¶    Const SEFLG_MOSEPH As Integer = 4¶    Const SEFLG_SPEED As Integer = 256¶    Const SEFLG_SPEED3 As Integer = 128¶    Const SEFLG_HELCTR As Integer = 8¶    Const SEFLG_TRUEPOS As Integer = 16¶    Const SEFLG_J2000 As Integer = 32¶    Const SEFLG_NONUT As Integer = 64¶    Const SEFLG_NOGDEFL As Integer = 512¶    Const SEFLG_NOABERR As Integer = 1024¶    Const SEFLG_EQUATORIAL As Integer = 2048¶    Const SEFLG_XYZ As Integer = 4096¶    Const SEFLG_RADIANS As Integer = 8192¶    Const SEFLG_BARYCTR As Integer = 16384¶    Const SEFLG_TOPOCTR As Integer = 32768¶    Const SEFLG_SIDEREAL As Integer = 65536¶¶    'eclipse codes¶    Const SE_ECL_CENTRAL As Integer = 1¶    Const SE_ECL_NONCENTRAL As Integer = 2¶    Const SE_ECL_TOTAL As Integer = 4¶    Const SE_ECL_ANNULAR As Integer = 8¶    Const SE_ECL_PARTIAL As Integer = 16¶    Const SE_ECL_ANNULAR_TOTAL As Integer = 32¶    Const SE_ECL_PENUMBRAL As Integer = 64¶    Const SE_ECL_VISIBLE As Integer = 128¶    Const SE_ECL_MAX_VISIBLE As Integer = 256¶    Const SE_ECL_1ST_VISIBLE As Integer = 512¶    Const SE_ECL_2ND_VISIBLE As Integer = 1024¶    Const SE_ECL_3RD_VISIBLE As Integer = 2048¶    Const SE_ECL_4TH_VISIBLE As Integer = 4096¶¶    'sidereal modes¶    Const SE_SIDM_FAGAN_BRADLEY As Integer = 0¶    Const SE_SIDM_LAHIRI As Integer = 1¶    Const SE_SIDM_DELUCE As Integer = 2¶    Const SE_SIDM_RAMAN As Integer = 3¶    Const SE_SIDM_USHASHASHI As Integer = 4¶    Const SE_SIDM_KRISHNAMURTI As Integer = 5¶    Const SE_SIDM_DJWHAL_KHUL As Integer = 6¶    Const SE_SIDM_YUKTESHWAR As Integer = 7¶    Const SE_SIDM_JN_BHASIN As Integer = 8¶    Const SE_SIDM_BABYL_KUGLER1 As Integer = 9¶    Const SE_SIDM_BABYL_KUGLER2 As Integer = 10¶    Const SE_SIDM_BABYL_KUGLER3 As Integer = 11¶    Const SE_SIDM_BABYL_HUBER As Integer = 12¶    Const SE_SIDM_BABYL_ETPSC As Integer = 13¶    Const SE_SIDM_ALDEBARAN_15TAU As Integer = 14¶    Const SE_SIDM_HIPPARCHOS As Integer = 15¶    Const SE_SIDM_SASSANIAN As Integer = 16¶    Const SE_SIDM_GALCENT_0SAG As Integer = 17¶    Const SE_SIDM_J2000 As Integer = 18¶    Const SE_SIDM_J1900 As Integer = 19¶    Const SE_SIDM_B1950 As Integer = 20¶    Const SE_SIDM_USER As Integer = 255¶¶    Const SE_NSIDM_PREDEF As Integer = 21¶¶    Const SE_SIDBITS As Integer = 256¶    'for projection onto ecliptic of t0¶    Const SE_SIDBIT_ECL_T0 As Integer = 256¶    'for projection onto solar system plane¶    Const SE_SIDBIT_SSY_PLANE As Integer = 512¶    Private Const ONE_RADIAN As Single = Math.PI * 2¶    '==================================¶    Const SE_NPLANETS As Integer = 21¶    Const SE_AST_OFFSET As Integer = 10000¶    Const SE_VARUNA As Integer = (SE_AST_OFFSET + 20000)¶¶    ' Hamburger or Uranian ficticious "planets"¶    Const SE_FICT_OFFSET As Integer = 40¶    Const SE_FICT_MAX As Integer = 999 'maximum number for ficticious planets¶    'if taken from file seorbel.txt¶    Const SE_NFICT_ELEM As Integer = 19 'number of built-in ficticious planets¶¶    ' other ficticious bodies¶¶    Const SE_VULCAN As Integer = 55¶    Const SE_WHITE_MOON As Integer = 56¶    Const SE_PROSERPINA As Integer = 57¶    Const SE_WALDEMATH As Integer = 58¶¶    ' points returned by swe_houses() and swe_houses_armc()¶    ' in array ascmc(0...10)¶    Const SE_ASC As Integer = 0¶    Const SE_MC As Integer = 1¶    Const SE_ARMC As Integer = 2¶    Const SE_VERTEX As Integer = 3¶    Const SE_EQUASC As Integer = 4  ' "equatorial ascendant"¶    Const SE_COASC1 As Integer = 5  ' "co-ascendant (W. Koch)"¶    Const SE_COASC2 As Integer = 6  ' "co-ascendant (M. Munkasey)"¶    Const SE_POLASC As Integer = 7  ' "polar ascendant (M. Munkasey)"¶    Const SE_NASCMC As Integer = 8  ' number of such points¶¶¶    ' used with swe_nod_aps()¶    Const SE_NOTBIT_MEAN As Long = 1 ' mean nodes/apsides¶    Const SE_NOTBIT_OSCU As Long = 2 ' osculating nodes/apsides¶    Const SE_NOTBIT_OSCU_BAR As Long = 4 ' same, but motion about solar system barycenter considered¶    Const SE_NOTBIT_FOPOINT As Long = 256 ' focal point of orbit instead of aphelion¶¶    'eclipse codes¶¶    Const SE_ECL_ONE_TRY As Long = 32768¶¶¶    'for projection onto ecliptic of t0¶    ' Const SE_SIDBIT_ECL_T0        As Long = 256¶    'for projection onto solar system plane¶    ' Const SE_SIDBIT_SSY_PLANE     As Long = 512¶¶    ' modes for planetary nodes/apsides, swe_nod_aps(), swe_nod_aps_ut()¶    Const SE_NODBIT_MEAN As Long = 1¶    Const SE_NODBIT_OSCU As Long = 2¶    Const SE_NODBIT_OSCU_BAR As Long = 3¶    Const SE_NODBIT_FOPOINT As Long = 256¶¶    ' indices for swe_rise_trans()¶    Const SE_CALC_RISE As Long = 1¶    Const SE_CALC_SET As Long = 2¶    Const SE_CALC_MTRANSIT As Long = 4¶    Const SE_CALC_ITRANSIT As Long = 8¶    Const SE_BIT_DISC_CENTER As Long = 256 '/* to be added to SE_CALC_RISE/SET */¶    '/* if rise or set of disc center is */¶    '/* requried */¶    Const SE_BIT_NO_REFRACTION As Long = 512 '/* to be added to SE_CALC_RISE/SET, */¶    '/* if refraction is not to be considered */¶¶¶¶    ' bits for data conversion with swe_azalt() and swe_azalt_rev()¶    Const SE_ECL2HOR As Long = 0¶    Const SE_EQU2HOR As Long = 1¶    Const SE_HOR2ECL As Long = 0¶    Const SE_HOR2EQU As Long = 1¶¶    ' for swe_refrac()¶    Const SE_TRUE_TO_APP As Long = 0¶    Const SE_APP_TO_TRUE As Long = 1¶    'Const MOSHPLEPH_START       As Long = -999999999¶    'Const MOSHPLEPH_END         As Long = -999999999¶    Const BEG_YEAR As Long = -50000¶    Const END_YEAR As Long = 50000¶    Const MOSHLUEPH_START As Double = -225000.5¶    Const MOSHLUEPH_END As Double = 3600000.5¶¶#End Region¶¶¶    Dim iday As Short¶    Dim imonth As Short¶    Dim iyear As Short¶    Dim ihour As Short¶    Dim imin As Double¶    Dim starname As String¶    Dim lon As Double¶    Dim lat As Double¶    Dim tjd_ut As Double¶    Dim tdj_et As Double¶#Region "function"¶¶¶    Public Function ASPECT(ByVal x As Double, ByVal y As Double) As Double¶        Return Math.Abs(swe_difdeg2n(x, y))¶    End Function¶¶    Public Function ASPECT2(ByVal x As Double, ByVal y As Double) As Double¶        Return swe_difdeg2n(x, y)¶    End Function¶¶    Public Function DegInSign(ByVal x As Double) As Double¶        Return x - (VB.Conversion.Fix(x / (360 / 12)) * 30)¶    End Function¶¶    Public Function GetDMS(ByVal Deg As Double, Optional ByVal par As String = "1") As String¶        Dim fract As Double = Math.Abs(Deg) - VB.Conversion.Int(Math.Abs(Deg))¶        Dim min As Double = VB.Conversion.Int(fract * 60)¶        Dim sec As Double = fract * 3600 - min * 60¶        GetDMS = Format(Math.Sign(Deg) * VB.Conversion.Int(Math.Abs(Deg)), "000") & "° " + Format(min, "00") & "' " + Format(sec, "00.0000") & "''"¶        If par = "1" Or par = "grad" Then GetDMS = Format(Math.Sign(Deg) * VB.Conversion.Int(Math.Abs(Deg)), "000")¶        If par = "2" Or par = "min" Then GetDMS = Format(min, "00")¶        If par = "3" Or par = "sec" Then GetDMS = Format(sec, "00.0000") & "''"¶    End Function¶¶    Public Function DegInSign1(ByVal x As Double) As String¶        Return GetDMS((x - (VB.Conversion.Fix(x / (360 / 12)) * 30)), 0)¶    End Function¶¶    Public Function ZodSec(ByVal sig As Double, ByVal sectors As Double) As Double¶        Return VB.Conversion.Fix(sig / (360 / sectors) + 1)¶    End Function¶    Public Function znname(ByVal n As Double) As Object¶        Dim sig As Integer¶        Dim znn() As String = {"", "Ове", "Тел", "Бли", "Рак", "Лев", "Дев", "Вес", "Ско", "Стр", "Коз", "Вод", "Рыб"}¶        sig = ZodSec(n, 12)¶        Return znn(sig)¶    End Function¶¶¶    Public Function hsname(ByVal n As Double) As Object¶        Dim hs As Integer¶        Dim hsn() As String = {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"}¶        hs = VB.Conversion.Fix(n / 30 + 1)¶        Return hsn(hs)¶    End Function¶    Public Function NAKSATRA(ByVal LPlan As Double) As Integer¶        Return VB.Conversion.Fix(LPlan / (360 / 27)) + 1¶    End Function¶¶    Public Function CHouse(ByVal JD As Double, ByVal HSys As String, ByVal CType_ As String, ByVal csp As Integer, ByVal LonH As Double, ByVal LonM As Double, ByVal LatH As Double, ByVal LatM As Double) As Double¶        Dim x(6) As Double, iflag As Integer¶        Dim cusp(13) As Double¶        Dim ascmc(10) As Double, asss As Long¶        iflag = SEFLG_SPEED + SEFLG_MOSEPH¶        If CType_ = "SSid" Or CType_ = "MSid" Then iflag = SEFLG_SPEED + SEFLG_MOSEPH + SEFLG_SIDEREAL¶        If CType_ = "SHel" Or CType_ = "MHel" Then iflag = SEFLG_HELCTR + SEFLG_MOSEPH¶        lon = LonH + 1 / 60 * LonM¶        lat = LatH + 1 / 60 * LatM¶        asss = swe_houses_ex(JD, iflag, lon, lat, Asc(HSys), cusp(0), ascmc(0))¶        If csp < 13 Then¶            Return cusp(csp)¶        Else¶            Return ascmc(csp - 13)¶        End If¶    End Function¶¶    Public Function Plc(ByVal JD As Double, ByVal pl As Integer, ByVal CType_ As String, ByVal XPos As String) As Double¶        Dim x(6) As Double, iflag As Integer, asss As Long, csp As Integer¶        Dim cusp(13) As Double¶        Dim ascmc(10) As Double¶        '\sweph\ephe¶        '  swe_set_ephe_path(Chr(34) & Application.StartupPath & "\sweph" & Chr(34))¶        ' swe_set_ephe_path("C:\sweph")¶        swe_set_ephe_path("C:\swep")¶¶        iflag = SEFLG_SPEED + SEFLG_MOSEPH¶        If pl > 99990 And pl < 100018 Then¶            asss = swe_houses_ex(JD, iflag, CType_, XPos, Asc("P"), cusp(0), ascmc(0))¶            csp = pl - 99990¶            Plc = cusp(csp)¶            Call swe_close()¶            Exit Function¶        End If¶¶        If CType_ = "Def" Then iflag = SEFLG_SPEED + SEFLG_MOSEPH¶¶        If CType_ = "STrop" Then iflag = SEFLG_TRUEPOS + SEFLG_SWIEPH¶        If CType_ = "SSid" Then iflag = SEFLG_SIDEREAL + SEFLG_SWIEPH¶        If CType_ = "SHel" Then iflag = SEFLG_HELCTR + SEFLG_SWIEPH¶        If CType_ = "SXYZ" Then iflag = SEFLG_XYZ + SEFLG_SWIEPH¶        If CType_ = "SRad" Then iflag = SEFLG_RADIANS + SEFLG_SWIEPH¶        If CType_ = "SEq" Then iflag = SEFLG_EQUATORIAL + SEFLG_SWIEPH¶        If CType_ = "SEqR" Then iflag = SEFLG_RADIANS + SEFLG_EQUATORIAL + SEFLG_SWIEPH¶¶¶        If CType_ = "MTrop" Then iflag = SEFLG_TRUEPOS + SEFLG_MOSEPH¶        If CType_ = "MSid" Then iflag = SEFLG_SIDEREAL + SEFLG_MOSEPH¶        If CType_ = "MHel" Then iflag = SEFLG_HELCTR + SEFLG_MOSEPH¶        If CType_ = "MXYZ" Then iflag = SEFLG_XYZ + SEFLG_MOSEPH¶        If CType_ = "MRad" Then iflag = SEFLG_RADIANS + SEFLG_MOSEPH¶        If CType_ = "MEq" Then iflag = SEFLG_EQUATORIAL + SEFLG_MOSEPH¶        If CType_ = "MEqR" Then iflag = SEFLG_RADIANS + SEFLG_EQUATORIAL + SEFLG_MOSEPH¶        '  Call swe_calc_ut() Попытка чтения или записи в защищенную память. Это часто свидетельствует о том, что другая память повреждена.¶        Dim serr As New String(Chr(0), 255)¶¶        Dim serr1 As New StringBuilder(256)¶        swe_calc_ut(JD, pl, iflag, x, serr1)¶¶        '    Call swe_calc_ut(JD, pl, iflag, x(0), serr)¶        ' serr$ = set_strlen(serr$)¶        Plc = x(0)¶¶        If XPos = 1 Or XPos = "Lat" Then Plc = x(1)¶        If XPos = 2 Or XPos = "Lon" Then Plc = x(2)¶        If XPos = 3 Or XPos = "Dis" Then Plc = x(3)¶        If XPos = 4 Or XPos = "SpdLat" Then Plc = x(4)¶        If XPos = 5 Or XPos = "SpdLon" Then Plc = x(5)¶        If XPos = 6 Or XPos = "SpdDis" Then Plc = x(6)¶        If XPos = 7 Or XPos = "Er" Then Plc = serr¶        Application.DoEvents()¶    End Function¶¶    Public Function PlAsc(ByVal JD As Double, ByVal HSys As String, ByVal CType_ As String, ByVal csp As Integer _¶    , ByVal LonH As Double, ByVal LonM As Double, ByVal LatH As Double, ByVal LatM As Double, ByVal pl As Integer) As Object¶        Dim Pll As Double = Plc(JD, pl, CType_, 0)¶        Dim Hss As Double = CHouse(JD, HSys, CType_, csp, LonH, LonM, LatH, LatM)¶        PlAsc = FixY(swe_difdeg2n(Pll, Hss) + 360, 360)¶    End Function¶    Public Function FixY(ByVal x As Double, ByVal y As Double) As Double¶        While x >= y¶            x = x - y¶        End While¶        While x < 0¶            x = x + y¶        End While¶        FixY = x¶    End Function¶¶    Public Function Harmonica(ByVal pl As Double, ByVal har As Double) As Double¶        Harmonica = FixY(pl, 360 / har) * har¶    End Function¶¶    Public Function calcayan(ByVal JD As Double) As Double¶        Dim d2r As Double = 3.14159265358979 / 180¶        Dim t As Double = (JD - 2415020) / 36525¶        Dim om1 As Double = 259.183275 - 1934.14200833321 * t + 0.0020777778 * t * t + 0.0000022222222 * t * t * t¶        Dim ls1 As Double = 279.696678 + 36000.76892 * t + 0.0003025 * t * t¶        Dim aya As Double = 17.23 * Math.Sin(d2r * om1) + 1.27 * Math.Sin(d2r * ls1 * 2) - (5025.64 + 1.11 * t) * t¶        Return (aya - 80861.27) / 3600¶    End Function¶¶    Public Function parans(ByVal JD As Double, ByVal pl As Long, ByVal CType_ As String, ByVal LonH As Double, _¶    ByVal LatH As Double, ByVal Alt As Double, ByVal rsmi As Long) As Double¶        Dim x(6) As Double¶        Dim GPos(3) As Double¶        Dim tret(0) As Double¶        lon = LonH¶        lat = LatH¶¶        '8.3595233971179379¶        '50.081876088649643¶¶        GPos(0) = lon¶        GPos(1) = lat¶        GPos(2) = Alt¶        Dim atpress As Double = 800¶        Dim attemp As Double = 15¶        Dim serr As New StringBuilder(256)¶        Dim strname As New String(Chr(0), 255)¶        Dim iflag As Integer = SEFLG_SPEED + SEFLG_MOSEPH¶        If CType_ = "Def" Then iflag = SEFLG_SPEED + SEFLG_MOSEPH¶        If CType_ = "STrop" Then iflag = SEFLG_TRUEPOS + SEFLG_SWIEPH¶        If CType_ = "SSid" Then iflag = SEFLG_SIDEREAL + SEFLG_SWIEPH¶        If CType_ = "SHel" Then iflag = SEFLG_HELCTR + SEFLG_SWIEPH¶        If CType_ = "SXYZ" Then iflag = SEFLG_XYZ + SEFLG_SWIEPH¶        If CType_ = "SRad" Then iflag = SEFLG_RADIANS + SEFLG_SWIEPH¶        If CType_ = "MTrop" Then iflag = SEFLG_TRUEPOS + SEFLG_MOSEPH¶        If CType_ = "MSid" Then iflag = SEFLG_SIDEREAL + SEFLG_MOSEPH¶        If CType_ = "MHel" Then iflag = SEFLG_HELCTR + SEFLG_MOSEPH¶        If CType_ = "MXYZ" Then iflag = SEFLG_XYZ + SEFLG_MOSEPH¶        If CType_ = "MRad" Then iflag = SEFLG_RADIANS + SEFLG_MOSEPH¶        swe_set_ephe_path(Application.StartupPath & "\sweph")¶¶        Call xyz_swe_rise_trans(JD, pl, starname$, iflag, rsmi, GPos, atpress, attemp, tret, serr)¶¶        swe_close()¶¶        Return tret(0)¶    End Function¶¶¶¶¶    Public Function parans(ByVal JD As Double, ByVal pl As Long, ByVal CType_ As String, ByVal LonH As Double, ByVal LonM As Double, _¶        ByVal LatH As Double, ByVal LatM As Double, ByVal Alt As Double, ByVal rsmi As Long) As Double¶        Dim x(6) As Double¶        Dim GPos(3) As Double¶        Dim tret(0) As Double¶        lon = LonH + 1 / 60 * LonM¶        lat = LatH + 1 / 60 * LatM¶        GPos(0) = lon¶        GPos(1) = lat¶        GPos(2) = Alt¶        Dim atpress As Double = 800¶        Dim attemp As Double = 15¶        Dim serr As New StringBuilder(256)¶        Dim strname$ = New String(Chr(0), 255)¶        Dim iflag As Integer = SEFLG_SPEED + SEFLG_MOSEPH¶        If CType_ = "Def" Then iflag = SEFLG_SPEED + SEFLG_MOSEPH¶        If CType_ = "STrop" Then iflag = SEFLG_TRUEPOS + SEFLG_SWIEPH¶        If CType_ = "SSid" Then iflag = SEFLG_SIDEREAL + SEFLG_SWIEPH¶        If CType_ = "SHel" Then iflag = SEFLG_HELCTR + SEFLG_SWIEPH¶        If CType_ = "SXYZ" Then iflag = SEFLG_XYZ + SEFLG_SWIEPH¶        If CType_ = "SRad" Then iflag = SEFLG_RADIANS + SEFLG_SWIEPH¶        If CType_ = "MTrop" Then iflag = SEFLG_TRUEPOS + SEFLG_MOSEPH¶        If CType_ = "MSid" Then iflag = SEFLG_SIDEREAL + SEFLG_MOSEPH¶        If CType_ = "MHel" Then iflag = SEFLG_HELCTR + SEFLG_MOSEPH¶        If CType_ = "MXYZ" Then iflag = SEFLG_XYZ + SEFLG_MOSEPH¶        If CType_ = "MRad" Then iflag = SEFLG_RADIANS + SEFLG_MOSEPH¶        swe_set_ephe_path(Application.StartupPath & "\sweph")¶¶        Call xyz_swe_rise_trans(JD, pl, starname$, iflag, rsmi, GPos, atpress, attemp, tret, serr)¶¶        swe_close()¶¶        Return tret(0)¶    End Function¶¶    Function JDToDay(ByVal JD As Double, ByVal per As Long) As Double¶        Dim z1 As Double = JD + 0.5¶        Dim z2 As Double = VB.Conversion.Fix(z1)¶        Dim f As Double = z1 - z2¶        Dim a As Double, alf As Double, kmon As Double, kyear As Double, hh1 As Double, khr As Double, kmin As Double, ksek As Double¶¶        kyear = 0¶        If z2 < 2299161 Then¶            a = z2¶        Else¶            alf = VB.Conversion.Fix((z2 - 1867216.25) / 36524.25)¶            a = z2 + 1 + alf - VB.Conversion.Fix(alf / 4)¶        End If¶        Dim b As Double = a + 1524¶        Dim c As Double = VB.Conversion.Fix((b - 122.1) / 365.25)¶        Dim d As Double = VB.Conversion.Fix(365.25 * c)¶        Dim e As Double = VB.Conversion.Fix((b - d) / 30.6001)¶        Dim days As Double = b - d - VB.Conversion.Fix(30.6001 * e) + f¶        Dim kday As Double = VB.Conversion.Fix(days)¶        If e < 13.5 Then¶            kmon = e - 1¶        Else¶            kmon = e - 13¶        End If¶        If kmon > 2.5 Then¶            kyear = c - 4716¶        End If¶        If kmon < 2.5 Then¶            kyear = c - 4715¶        End If¶        hh1 = (days - kday) * 24¶        khr = VB.Conversion.Fix(hh1)¶        kmin = hh1 - khr¶        ksek = kmin * 60¶        kmin = VB.Conversion.Fix(ksek)¶        ksek = VB.Conversion.Fix((ksek - kmin) * 60)¶        '  ,  xday = kday¶        ' ,  xmon = kmon¶        ' , xyear = kyear¶        ' s = kday + "." + kmon + "." + kyear + " " + khr + ":" + kmin¶        If per = 1 Then Return kday¶        If per = 2 Then Return kmon¶        If per = 3 Then Return kyear¶        If per = 4 Then Return khr¶        If per = 5 Then Return kmin¶        If per = 6 Then Return ksek¶¶    End Function¶    Function JDToDay(ByVal JD As Double) As Date¶        Dim z1 As Double = JD + 0.5¶        Dim z2 As Double = VB.Conversion.Fix(z1)¶        Dim f As Double = z1 - z2¶        Dim a As Double, alf As Double, kmon As Double, kyear As Double, hh1 As Double, khr As Double, kmin As Double, ksek As Double¶¶        kyear = 0¶        If z2 < 2299161 Then¶            a = z2¶        Else¶            alf = VB.Conversion.Fix((z2 - 1867216.25) / 36524.25)¶            a = z2 + 1 + alf - VB.Conversion.Fix(alf / 4)¶        End If¶        Dim b As Double = a + 1524¶        Dim c As Double = VB.Conversion.Fix((b - 122.1) / 365.25)¶        Dim d As Double = VB.Conversion.Fix(365.25 * c)¶        Dim e As Double = VB.Conversion.Fix((b - d) / 30.6001)¶        Dim days As Double = b - d - VB.Conversion.Fix(30.6001 * e) + f¶        Dim kday As Double = VB.Conversion.Fix(days)¶        If e < 13.5 Then¶            kmon = e - 1¶        Else¶            kmon = e - 13¶        End If¶        If kmon > 2.5 Then¶            kyear = c - 4716¶        End If¶        If kmon < 2.5 Then¶            kyear = c - 4715¶        End If¶        hh1 = (days - kday) * 24¶        khr = VB.Conversion.Fix(hh1)¶        kmin = hh1 - khr¶        ksek = kmin * 60¶        kmin = VB.Conversion.Fix(ksek)¶        ksek = VB.Conversion.Fix((ksek - kmin) * 60)¶        '  ,  xday = kday¶        ' ,  xmon = kmon¶        ' , xyear = kyear¶        ' s = kday + "." + kmon + "." + kyear + " " + khr + ":" + kmin¶        Return CDate(kday & "." & kmon & "." & kyear & " " & khr & ":" & kmin & ":" & ksek)¶¶    End Function¶¶¶¶    Public Function parans2(ByVal JD As Double, ByVal pl As Long, ByVal CType_ As String, ByVal LonH As Double, ByVal LatH As Double, _¶       ByVal Alt As Double, ByVal rsmi As Long, ByVal popr As Double, ByRef Jul_dey As Double) As Date¶        popr = (1 / 24) * popr¶        Jul_dey = parans(JD, pl, CType_, LonH, LatH, Alt, rsmi) + popr¶¶        Return JDToDay(Jul_dey)¶    End Function¶¶¶¶    Public Function parans2(ByVal JD As Double, ByVal pl As Long, ByVal CType_ As String, ByVal LonH As Double, ByVal LonM As Double, ByVal LatH As Double, ByVal LatM As Double, _¶        ByVal Alt As Double, ByVal rsmi As Long, ByVal t As Integer, ByVal popr As Double) As Double¶        popr = (1 / 24) * popr¶        Return JDToDay(parans(JD, pl, CType_, LonH, LonM, LatH, LatM, Alt, rsmi) + popr, t)¶    End Function¶    Private Function set_strlen(ByRef c As String) As String¶        Dim i As Integer¶        i = InStr(c, Chr(0))¶        If (i > 0) Then c = VB.Left(c, i - 1)¶        set_strlen = c¶    End Function¶¶    Public Function plname(ByVal n As Object) As String¶        swe_set_ephe_path(Application.StartupPath & "\sweph")¶        Dim plnam As New String(Chr(0), 20)¶        Call swe_get_planet_name(n, plnam$)¶        plnam$ = set_strlen(plnam$)¶        plnam$ = Left(plnam$, 100)¶        plname = plnam$¶        Call swe_close()¶    End Function¶¶    Function jday(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal hour As Integer, _¶ByVal min As Integer, ByVal sec As Double, Optional ByVal greg As Integer = 0) As Double¶¶        Dim a As Double¶        Dim b As Integer¶        a = 10000.0# * year + 100.0# * month + day¶        If (a < -47120101) Then MsgBox("Warning: date too early for algorithm")¶        If (month <= 2) Then¶            month = month + 12¶            year = year - 1¶        End If¶        If (greg = 0) Then¶            b = -2 + VB.Conversion.Fix((year + 4716) / 4) - 1179¶        Else¶            b = VB.Conversion.Fix(year / 400) - VB.Conversion.Fix(year / 100) + VB.Conversion.Fix(year / 4)¶        End If¶        a = 365.0# * year + 1720996.5¶        jday = a + b + VB.Conversion.Fix(30.6001 * (month + 1)) + day + (hour + min / 60 + sec / 3600) / 24¶¶¶    End Function¶¶¶#End Region¶¶    Public Function jday(ByVal day_start As Date) As Object¶¶        '\sweph\ephe¶        swe_set_ephe_path(Application.StartupPath & "\sweph")¶¶        Dim retval As Object¶        Dim h As Object¶        Dim x(6) As Double¶        Dim x0(6) As Double¶        Dim cusp(13) As Double¶        Dim ascmc(10) As Double¶        Dim cal As Byte¶        Dim ss As New String(Chr(0), 16)¶¶        h = day_start.Hour + day_start.Minute / 60.0#¶¶        iday = day_start.Day¶        imonth = day_start.Month¶        iyear = day_start.Year¶¶        Dim D_start As Double = swe_julday(iyear, imonth, iday, h, 1)¶¶        retval = swe_date_conversion(iyear, imonth, iday, h, cal, tjd_ut)¶¶        Call swe_close()¶        Return D_start¶¶    End Function¶¶¶¶¶¶¶¶End Module¶
Только для чтения
Нет
Цвет
Белый
Цвет шрифта
Черный
Ширина
599
Шрифт
Microsoft Sans Serif
Шрифт жирный
Нет
Шрифт зачеркнутый
Нет
Шрифт курсив
Нет
Шрифт подчеркнутый
Нет
Шрифт размер
8
#Conteiner
Окно1.Окно1[0]
#HistoryLevel
2
#TreeNode
#Parent
Окно1(0)
#Index
3
Текст1
Текст1
textboks
textboks
Obj
#End

T
X
628
Y
36
Видимый
Да
Всплывающее меню
Никакой
Вспомогательное поле

Выделенный текст

Вышина
211
Длинна выделения
0
Имя
Текст2
Максимальная вышина
0
Максимальная длинна
32767
Максимальная ширина
0
Минимальная вышина
0
Минимальная ширина
0
Многострочность
Да
Начало выделения
1
Номер
0
Перенос по словам
Да
Подсказка

Полосы прокрутки
Нет
Привязка
Слева_Сверху
Работает
Да
Разрешить вводить
Все
Расположение текста
Слева
Растяжка
Никакой
Символ пароля

Скрывать выделение
Нет
Стиль рамки
объем
ТабНомер
0
ТабСтоп
Да
Текст
'Класс MainClass и функция Main должны обязательно присутствовать¶Public Class MainClass ¶   Public Function Main()¶      Clipboard.SetText(Astro.jday(2014, 10, 10, 10, 10, 10))¶   End Function¶End Class
Только для чтения
Нет
Цвет
Белый
Цвет шрифта
Черный
Ширина
403
Шрифт
Microsoft Sans Serif
Шрифт жирный
Нет
Шрифт зачеркнутый
Нет
Шрифт курсив
Нет
Шрифт подчеркнутый
Нет
Шрифт размер
8
#Conteiner
Окно1.Окно1[0]
#HistoryLevel
0
#TreeNode
#Parent
Окно1(0)
#Index
1
Текст2
Текст2
textboks
textboks
Obj
#End

Lb
X
12
Y
12
АвтоТроеточие
Да
Видимый
Да
Всплывающее меню
Никакой
Вспомогательное поле

Вышина
15
Имя
Надпись1
Курсор
Обычный
Максимальная вышина
0
Максимальная ширина
0
Минимальная вышина
0
Минимальная ширина
0
Номер
0
Подсказка

Поле сверху
0
Поле слева
0
Поле снизу
0
Поле справа
0
Положение рисунка
Центр
Положение текста
слева
Привязка
Слева_Сверху
Работает
Да
Растяжка
Никакой
Рисунок
Никакой
Стиль рамки
Никакой
Стиль фона
Плитка
ТабНомер
0
ТабСтоп
Да
Текст
Код обработчик библиотеки:
Фоновой рисунок
Никакой
Цвет
240; 240; 240;
Цвет шрифта
Черный
Ширина
155
Шрифт
Microsoft Sans Serif
Шрифт жирный
Нет
Шрифт зачеркнутый
Нет
Шрифт курсив
Нет
Шрифт подчеркнутый
Нет
Шрифт размер
8
#Conteiner
Окно1.Окно1[0]
#HistoryLevel
3
#TreeNode
#Parent
Окно1(0)
#Index
4
Надпись1
Надпись1
label
label
Obj
#End

Lb
X
632
Y
12
АвтоТроеточие
Да
Видимый
Да
Всплывающее меню
Никакой
Вспомогательное поле

Вышина
15
Имя
Надпись2
Курсор
Обычный
Максимальная вышина
0
Максимальная ширина
0
Минимальная вышина
0
Минимальная ширина
0
Номер
0
Подсказка

Поле сверху
0
Поле слева
0
Поле снизу
0
Поле справа
0
Положение рисунка
Центр
Положение текста
слева
Привязка
Слева_Сверху
Работает
Да
Растяжка
Никакой
Рисунок
Никакой
Стиль рамки
Никакой
Стиль фона
Плитка
ТабНомер
0
ТабСтоп
Да
Текст
Наш код:
Фоновой рисунок
Никакой
Цвет
240; 240; 240;
Цвет шрифта
Черный
Ширина
155
Шрифт
Microsoft Sans Serif
Шрифт жирный
Нет
Шрифт зачеркнутый
Нет
Шрифт курсив
Нет
Шрифт подчеркнутый
Нет
Шрифт размер
8
#Conteiner
Окно1.Окно1[0]
#HistoryLevel
4
#TreeNode
#Parent
Окно1(0)
#Index
5
Надпись2
Надпись2
label
label
Obj
#End

Lb
X
628
Y
312
АвтоТроеточие
Да
Видимый
Да
Всплывающее меню
Никакой
Вспомогательное поле

Вышина
15
Имя
Надпись3
Курсор
Обычный
Максимальная вышина
0
Максимальная ширина
0
Минимальная вышина
0
Минимальная ширина
0
Номер
0
Подсказка

Поле сверху
0
Поле слева
0
Поле снизу
0
Поле справа
0
Положение рисунка
Центр
Положение текста
центр
Привязка
Слева_Сверху
Работает
Да
Растяжка
Никакой
Рисунок
Никакой
Стиль рамки
Никакой
Стиль фона
Плитка
ТабНомер
0
ТабСтоп
Да
Текст
Результат работы:
Фоновой рисунок
Никакой
Цвет
240; 240; 240;
Цвет шрифта
Черный
Ширина
103
Шрифт
Microsoft Sans Serif
Шрифт жирный
Нет
Шрифт зачеркнутый
Нет
Шрифт курсив
Нет
Шрифт подчеркнутый
Нет
Шрифт размер
8
#Conteiner
Окно1.Окно1[0]
#HistoryLevel
5
#TreeNode
#Parent
Окно1(0)
#Index
6
Надпись3
Надпись3
label
label
Obj
#End

Lb
X
744
Y
312
АвтоТроеточие
Да
Видимый
Да
Всплывающее меню
Никакой
Вспомогательное поле

Вышина
15
Имя
Надпись4
Курсор
Обычный
Максимальная вышина
0
Максимальная ширина
0
Минимальная вышина
0
Минимальная ширина
0
Номер
0
Подсказка

Поле сверху
0
Поле слева
0
Поле снизу
0
Поле справа
0
Положение рисунка
Центр
Положение текста
слева
Привязка
Слева_Сверху
Работает
Да
Растяжка
Никакой
Рисунок
Никакой
Стиль рамки
Никакой
Стиль фона
Плитка
ТабНомер
0
ТабСтоп
Да
Текст

Фоновой рисунок
Никакой
Цвет
240; 240; 240;
Цвет шрифта
Черный
Ширина
279
Шрифт
Microsoft Sans Serif
Шрифт жирный
Нет
Шрифт зачеркнутый
Нет
Шрифт курсив
Нет
Шрифт подчеркнутый
Нет
Шрифт размер
8
#Conteiner
Окно1.Окно1[0]
#HistoryLevel
6
#TreeNode
#Parent
Окно1(0)
#Index
7
Надпись4
Надпись4
label
label
Obj
#End

#ProjectParams
#PoleznieDistance
5
#EndPoleznieDistance
#Expands
Окно1
Окно1
Кнопка1
TNRBjpWFOg
#EndExpands
#SelNode
pKoVmhNpuf
#ActiveForm
Окно1.Окно1[0]
#ActiveObj
Окно1.Текст1[0]
#ImagePath
Рисунки\
#ImageDefName
Рисунок
#pProgressForm
yes
#Icon

#EndProjectParams
