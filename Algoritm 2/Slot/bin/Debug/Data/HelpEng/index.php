<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link href="_TemplateMSDN_files/MSDNstyles.css" type="text/css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Справка Алгоритм 2</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.style2 {font-size: 11px}
.style3 {font-size: 12px}
-->
</style>
</head>
<table width="100%" border="0">
  <tr style="padding:0;margin:0;">
    <td width="20%" valign="top" style="padding:0;margin:0;">
  
        <? include 'Menu.html'; ?>
        <div class="xsl_file" id="xsl_file_spColexpAll" style="xml_file"><br /><br />
  
      <form method=GET action="http://google.ru/search" name=f style="padding:0;margin:0;">
        <div align="center" style="padding:0;margin:0;"> 
          <div align="center">Поиск:
            <input name="as_q" type="text" id="as_q" size="15"  />
            
              <input type="submit" name="button" id="button" value="Найти" />
              <input type="hidden" name="as_sitesearch" id="as_sitesearch" value="help.algoritm2.ru" />
              <input type="hidden" name="num" id="num" value="15"/>
            </div>
        </div>
    </form>
      <div align="center"><br />
        Язык:
          <a href="http://translate.google.ru/translate?&amp;sl=auto&amp;tl=en&amp;u=help.algoritm2.ru" target="_blank"><img src="_TemplateMSDN_files/Pictures/en.jpg" alt="Флаг сша" /></a>
<a href="http://translate.google.ru/translate?&sl=auto&tl=de&u=help.algoritm2.ru" target="_blank"><img src="_TemplateMSDN_files/Pictures/de.jpg" alt="Флаг гармании" /></a>       &nbsp;&nbsp;<a href="Menu2.html" style="xsl_file">Карта справки</a></div>
     
      </div>   </td>
           <td width="80%" valign="top" style="padding:0;margin:0;"><?	if ($page=='') $page = 'Introduce.html'; include $page; ?></td>
  </tr>
</table>
</html>
	<!--<frameset rows="44,*" cols="*"  framespacing="1" frameborder="yes" border="3" bordercolor="#0099ff">');
	  <frame src="Search.html" name="TopFrame" id="TopFrame" title="TopFrame" scrolling="No"/>');
	  <frameset rows="*" cols="25%,75%" framespacing="1" frameborder="yes" border="3" bordercolor="#0099ff">');
		<frame src="Menu.html" name="leftFrame" id="leftFrame" title="menuFrame" />');
		<frame src="<?	if ($page=='') $page = 'Introduce.html';	echo($page); ?>" name="mainFrame" id="mainFrame" title="mainFrame" />
	</frameset>
</frameset>
	<noframes></noframes>-->
</html>