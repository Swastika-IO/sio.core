<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0"
                xmlns:html="http://www.w3.org/TR/REC-html40"
				xmlns:image="http://www.google.com/schemas/sitemap-image/1.1"
                xmlns:sitemap="http://www.sitemaps.org/schemas/sitemap/0.9"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
  <xsl:template match="/">
    <xsl:variable name="fileType">
      <xsl:choose>
        <xsl:when test="//sitemap:url">Sitemap</xsl:when>
        <xsl:otherwise>SitemapIndex</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <html xmlns="http://www.w3.org/1999/xhtml">
      <head>
        <title>
          <xsl:choose>
            <xsl:when test="$fileType='Sitemap'">Sitemap</xsl:when>
            <xsl:otherwise>Sitemap Index</xsl:otherwise>
          </xsl:choose>
        </title>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <style type="text/css" rel="stylesheet">
          body {
          font-family: Helvetica, Arial, sans-serif;
          font-size: 68.5%;
          }
          table {
          border: none;
          border-collapse: collapse;
          }
          table { font-size:1em; width:75% }
          th {  text-align:left; 	padding:5px }
          tr.stripe { background-color:#f7f7f7; }
        </style>
      </head>
      <body>
        <div id="content">
          <h1>XML Sitemap</h1>
          <div>
            <p>
              <xsl:choose>
                <xsl:when test="$fileType='Sitemap'">
                  This sitemap contains <xsl:value-of select="count(sitemap:urlset/sitemap:url)"></xsl:value-of> URLs
                </xsl:when>
                <xsl:otherwise>
                  This sitemap index contains <xsl:value-of select="count(sitemap:sitemapindex/sitemap:sitemap)"></xsl:value-of> sitemaps
                </xsl:otherwise>
              </xsl:choose>
            </p>
          </div>
          <xsl:choose>
            <xsl:when test="$fileType='Sitemap'">
              <xsl:call-template name="sitemapTable"/>
            </xsl:when>
            <xsl:otherwise>
              <xsl:call-template name="siteindexTable"/>
            </xsl:otherwise>
          </xsl:choose>

        </div>
      </body>
    </html>
  </xsl:template>
  <xsl:template name="siteindexTable">
    <table cellpadding="3">
      <thead>
        <tr>
          <th width="50%">URL</th>
          <th>LastChange</th>
        </tr>
      </thead>
      <tbody>
        <xsl:variable name="lower" select="'abcdefghijklmnopqrstuvwxyz'"/>
        <xsl:variable name="upper" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'"/>
        <xsl:for-each select="sitemap:sitemapindex/sitemap:sitemap">
          <tr>
            <xsl:if test="position() mod 2 != 1">
              <xsl:attribute name="class">stripe</xsl:attribute>
            </xsl:if>
            <td>
              <xsl:variable name="itemURL">
                <xsl:value-of select="sitemap:loc"/>
              </xsl:variable>
              <a href="{$itemURL}">
                <xsl:value-of select="sitemap:loc"/>
              </a>
            </td>
            <td>
              <xsl:value-of select="concat(substring(sitemap:lastmod,0,11),concat(' ', substring(sitemap:lastmod,12,5)))"/>
            </td>
          </tr>
        </xsl:for-each>
      </tbody>
    </table>
  </xsl:template>
  <xsl:template name="sitemapTable">
    <table cellpadding="3">
      <thead>
        <tr>
          <th width="50%">URL</th>
          <th>Priority</th>
          <th>Change Frequency</th>
          <th>LastChange</th>
        </tr>
      </thead>
      <tbody>
        <xsl:variable name="lower" select="'abcdefghijklmnopqrstuvwxyz'"/>
        <xsl:variable name="upper" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'"/>
        <xsl:for-each select="sitemap:urlset/sitemap:url">
          <tr>
            <xsl:if test="position() mod 2 != 1">
              <xsl:attribute name="class">stripe</xsl:attribute>
            </xsl:if>
            <td>
              <xsl:variable name="itemURL">
                <xsl:value-of select="sitemap:loc"/>
              </xsl:variable>
              <a href="{$itemURL}">
                <xsl:value-of select="sitemap:loc"/>
              </a>
            </td>
            <td>
              <xsl:if test="string(number(sitemap:priority))!='NaN'">
                <xsl:value-of select="concat(sitemap:priority*100,'%')"/>
              </xsl:if>
            </td>
            <td>
              <xsl:value-of select="concat(translate(substring(sitemap:changefreq, 1, 1),concat($lower, $upper),concat($upper, $lower)),substring(sitemap:changefreq, 2))"/>
            </td>
            <td>
              <xsl:value-of select="concat(substring(sitemap:lastmod,0,11),concat(' ', substring(sitemap:lastmod,12,5)))"/>
            </td>
          </tr>
        </xsl:for-each>
      </tbody>
    </table>
  </xsl:template>
</xsl:stylesheet>