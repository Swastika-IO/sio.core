using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swastika.IO.Cms.Lib.Services;
using Swastika.IO.Core.Server.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Swastika.IO.Core.Server.Controllers
{
  public class HomeController : Controller
  {
    private const string SessionKeyIsApp = "_IsApp";
    private const string RequestQueryIsApp = "app";
    private readonly ApplicationConfigService _appService;
    public HomeController(ApplicationConfigService service)
    {
      this._appService = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      if (HttpContext.Session.GetString(SessionKeyIsApp) == null)
      {
        HttpContext.Session.SetString(SessionKeyIsApp, "false");
      }
      if (HttpContext.Request.Query[RequestQueryIsApp].ToString() != String.Empty)
      {
        HttpContext.Session.SetString(SessionKeyIsApp, HttpContext.Request.Query[RequestQueryIsApp].ToString());
      }

      if (HttpContext.Session.GetString(SessionKeyIsApp).Equals("true"))
      {
        HttpContext.Session.SetString(SessionKeyIsApp, "true");

        var prerenderResult = await Request.BuildPrerender();

        ViewData["SpaHtml"] = prerenderResult.Html; // our <app-root /> from Angular
        ViewData["Title"] = prerenderResult.Globals["title"]; // set our <title> from Angular
        ViewData["Styles"] = prerenderResult.Globals["styles"]; // put styles in the correct place
        ViewData["Scripts"] = prerenderResult.Globals["scripts"]; // scripts (that were in our header)
        ViewData["Meta"] = prerenderResult.Globals["meta"]; // set our <meta> SEO tags
        ViewData["Links"] = prerenderResult.Globals["links"]; // set our <link rel="canonical"> etc SEO tags
        ViewData["TransferData"] = prerenderResult.Globals["transferData"]; // our transfer data set to window.TRANSFER_CACHE = {};

        return View("SpaIndex");
      }
      else
      {
        HttpContext.Session.SetString(SessionKeyIsApp, "false");
        return View();
      }
    }

    [HttpGet]
    [Route("sitemap.xml")]
    public async Task<IActionResult> SitemapXml()
    {
      String xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

      xml += "<sitemapindex xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">";
      xml += "<sitemap>";
      xml += "<loc>http://localhost:4251/home</loc>";
      xml += "<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>";
      xml += "</sitemap>";
      xml += "<sitemap>";
      xml += "<loc>http://localhost:4251/counter</loc>";
      xml += "<lastmod>" + DateTime.Now.ToString("yyyy-MM-dd") + "</lastmod>";
      xml += "</sitemap>";
      xml += "</sitemapindex>";

      return Content(xml, "text/xml");

    }

    public IActionResult Error()
    {
      ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
      return View();
    }
  }
}
