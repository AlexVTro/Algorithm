<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:param name="msdnTemp" />
  <xsl:param name="vlozhen" />
  <xsl:param name="papka" />
  <xsl:param name="obj" />
  <xsl:param name="objEng" />
  <xsl:param name="prop" />
  <xsl:param name="propEng" />
  <xsl:param name="useful" />
  <xsl:param name="php" />
  <xsl:param name="onlyMenu" />

  <xsl:template match="menu">
<HTML>
 <HEAD>
  <link href="_TemplateMSDN_files/menuStyles.css" type="text/css" rel="stylesheet"/>
   <script language="javascript">var gCHM=true;</script>
   <script language="javascript" src="{$vlozhen}{$msdnTemp}/common.js">var a;</script>
   <script language="javascript" src="{$vlozhen}{$msdnTemp}/script.js">var b;</script>
 </HEAD>
<BODY class="xsl_menu"><xsl:apply-templates select="node"/></BODY></HTML>
</xsl:template>

<xsl:template match="node">
 <table class="xsl_menu_tbl"><tr>
   
   <xsl:choose>
     <xsl:when test="$onlyMenu">
     </xsl:when>
     <xsl:otherwise>
       <td class="xsl_menu_rt">
         <xsl:if test="@icon">
           <xsl:if test="count(node) &gt; 0">
             <xsl:attribute name="onClick">
               javascript:SwapDisplay(&apos;<xsl:value-of select="@id"/>div&apos;, &apos;<xsl:value-of select="@id"/>img&apos;, true);
             </xsl:attribute>
             <img id="{@id}img" src="{$vlozhen}{$msdnTemp}/minus_small.gif" border="0"/>
           </xsl:if>
           <xsl:if test="count(node) = 0">
             <img src="{$vlozhen}{$msdnTemp}/nothing_small.gif" border="0" />
           </xsl:if>
           <img class="xsl_menu" align="absmiddle" border="0" src="{$vlozhen}{$msdnTemp}/{@icon}"  />
         </xsl:if>
       </td>
     </xsl:otherwise>
   </xsl:choose>
   
  <td class="xsl_menu_lt">
  <xsl:choose>
   <xsl:when test="@file!=''">
    <a class="xsl_menu">
      <xsl:attribute name="href"><xsl:value-of select="$php"/><xsl:value-of select="@file"/></xsl:attribute>
       <xsl:choose>
                  <xsl:when test="$php"></xsl:when>
                  <xsl:otherwise><xsl:attribute name="target">mainFrame</xsl:attribute></xsl:otherwise>
       </xsl:choose>
      <xsl:attribute name="onClick">
        javascript:SwapDisplay(&apos;<xsl:value-of select="@id"/>div&apos;, &apos;<xsl:value-of select="@id"/>img&apos;, true);
      </xsl:attribute>
     <xsl:value-of select="@title"/>
    </a>
   </xsl:when>
   <xsl:otherwise>
    <span class="xsl_menu_nolink"><xsl:value-of select="@title"/></span>
   </xsl:otherwise>
  </xsl:choose>
 </td></tr></table>
  <xsl:if test="count(node) &gt; 0">
    <div id="{@id}div" class="xsl_file_container">
      <div class="xsl_menu15Left">
        <xsl:for-each select=".">
          <xsl:apply-templates select="node" />
        </xsl:for-each>
      </div>
    </div>
  </xsl:if>
  <script language="javascript">
    SwapDisplay(&apos;<xsl:value-of select="@id"/>div&apos;, &apos;<xsl:value-of select="@id"/>img&apos;, true);
  </script>
</xsl:template>

</xsl:stylesheet>
