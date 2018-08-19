// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.FrontEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Swastika.Cms.Lib
{
    public static class SwCmsHelper
    {
        public static Translator GetTranslator(string culture)
        {
            Translator t = new Translator(culture);
            return t;
        }

        public static RSAParameters GenerateKey()
        {
            using (var key = new RSACryptoServiceProvider(2048))
            {
                return key.ExportParameters(true);
            }
        }

        public static FEModuleViewModel GetModule(string name, string culture)
        {
            var getModule = FEModuleViewModel.Repository.GetSingleModel(m => m.Name == name);
            return getModule.Data;
        }

        public static List<InfoCategoryViewModel> GetCategory(IUrlHelper Url, string culture, SWCmsConstants.CatePosition position, string activePath = "")
        {
            var getTopCates = InfoCategoryViewModel.Repository.GetModelListBy
            (c => c.Specificulture == culture && c.SiocCategoryPosition.Any(
              p => p.PositionId == (int)position)
            );
            var cates = getTopCates.Data ?? new List<InfoCategoryViewModel>();
            activePath = activePath.ToLower();
            foreach (var cate in cates)
            {
                switch (cate.Type)
                {
                    case SWCmsConstants.CateType.Blank:
                        foreach (var child in cate.Childs)
                        {
                            child.DetailsUrl = Url.RouteUrl("Page", new { culture, seoName = child.SeoName });
                        }
                        break;

                    case SWCmsConstants.CateType.StaticUrl:
                        cate.DetailsUrl = cate.StaticUrl;
                        break;

                    case SWCmsConstants.CateType.Home:
                    case SWCmsConstants.CateType.List:
                    case SWCmsConstants.CateType.Article:
                    case SWCmsConstants.CateType.Modules:
                    default:
                        cate.DetailsUrl = Url.RouteUrl("Page", new { culture, seoName = cate.SeoName });
                        break;
                }
                cate.IsActived = (cate.DetailsUrl == activePath
                    || (cate.Type == SWCmsConstants.CateType.Home && activePath == string.Format("/{0}/home", culture)));
                cate.Childs.ForEach((Action<InfoCategoryViewModel>)(c =>
                {
                    c.IsActived = (
                    c.DetailsUrl == activePath);
                    cate.IsActived = cate.IsActived || c.IsActived;
                }));
            }
            return cates;
        }

        public static List<InfoCategoryViewModel> GetCategoryByAlias(IUrlHelper Url, string culture, SWCmsConstants.CatePosition position, string activePath = "")
        {
            var getTopCates = InfoCategoryViewModel.Repository.GetModelListBy
            (c => c.Specificulture == culture && c.SiocCategoryPosition.Any(
              p => p.PositionId == (int)position)
            );
            var cates = getTopCates.Data ?? new List<InfoCategoryViewModel>();
            activePath = activePath.ToLower();
            foreach (var cate in cates)
            {
                switch (cate.Type)
                {
                    case SWCmsConstants.CateType.Blank:
                        foreach (var child in cate.Childs)
                        {
                            child.DetailsUrl = Url.RouteUrl("Page", new { culture, seoName = child.SeoName });
                        }
                        break;

                    case SWCmsConstants.CateType.StaticUrl:
                        cate.DetailsUrl = cate.StaticUrl;
                        break;

                    case SWCmsConstants.CateType.Home:
                    case SWCmsConstants.CateType.List:
                    case SWCmsConstants.CateType.Article:
                    case SWCmsConstants.CateType.Modules:
                    default:
                        cate.DetailsUrl = Url.RouteUrl("Page", new { culture, seoName = cate.SeoName });
                        break;
                }
                cate.IsActived = (cate.UrlAlias.Alias == activePath
                    || (cate.Type == SWCmsConstants.CateType.Home && activePath == string.Empty));
                cate.Childs.ForEach((Action<InfoCategoryViewModel>)(c =>
                {
                    c.IsActived = (
                    c.UrlAlias.Alias == activePath);
                    cate.IsActived = cate.IsActived || c.IsActived;
                }));
            }
            return cates;
        }

        public static List<InfoCategoryViewModel> GetCategory(IUrlHelper Url, string culture, SWCmsConstants.CateType cateType, string activePath = "")
        {
            var getTopCates = InfoCategoryViewModel.Repository.GetModelListBy
            (c => c.Specificulture == culture && c.Type == (int)cateType
            );
            var cates = getTopCates.Data ?? new List<InfoCategoryViewModel>();
            activePath = activePath.ToLower();
            foreach (var cate in cates)
            {
                switch (cate.Type)
                {
                    case SWCmsConstants.CateType.Blank:
                        foreach (var child in cate.Childs)
                        {
                            child.DetailsUrl = Url.RouteUrl("Page", new { culture, pageName = child.SeoName });
                        }
                        break;

                    case SWCmsConstants.CateType.StaticUrl:
                        cate.DetailsUrl = cate.StaticUrl;
                        break;

                    case SWCmsConstants.CateType.Home:
                    case SWCmsConstants.CateType.List:
                    case SWCmsConstants.CateType.Article:
                    case SWCmsConstants.CateType.Modules:
                    default:
                        cate.DetailsUrl = Url.RouteUrl("Page", new { culture, pageName = cate.SeoName });
                        break;
                }

                cate.IsActived = (
                    cate.DetailsUrl == activePath || (cate.Type == SWCmsConstants.CateType.Home && activePath == string.Format("/{0}/home", culture))
                    );

                cate.Childs.ForEach((Action<InfoCategoryViewModel>)(c =>
                {
                    c.IsActived = (
                    c.DetailsUrl == activePath);
                    cate.IsActived = cate.IsActived || c.IsActived;
                }));
            }
            return cates;
        }

        public static string GetFullPath(string[] subPaths)
        {
            string result = string.Empty;
            StringBuilder strFormat = new StringBuilder();
            for (int i = 0; i < subPaths.Length; i++)
            {

                string connector = string.Empty;
                if ((i < subPaths.Length - 1) && !string.IsNullOrEmpty(subPaths[i + 1]))
                {
                    connector = "/";
                }
                strFormat.Append(@"{" + i + "}" + connector);

            }
            result = string.Format(strFormat.ToString(), subPaths).Replace("//", "/").Replace(":/", "://");
            return result;
        }

        public static string GetRandomName(string filename)
        {
            string ext = filename.Split('.')[1];
            return string.Format("{0}.{1}", Guid.NewGuid().ToString("N"), ext);
        }

        public static string GetRouterUrl(string routerName, object routeValues, HttpRequest request, IUrlHelper Url)
        {
            return string.Format("{0}://{1}{2}", request.Scheme, request.Host,
                        Url.RouteUrl(routerName, routeValues)
                        );
        }

        public static bool RemoveFile(string filePath)
        {
            bool result = false;
            try
            {
                string fullPath = SwCmsHelper.GetFullPath(new string[]
               {
                    SWCmsConstants.Parameters.WebRootPath,
                    filePath
               });
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public static bool SaveFileBase64(string folder, string filename, string strBase64)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            try
            {
                string webFolder = SwCmsHelper.GetFullPath(new string[]
               {
                    SWCmsConstants.Parameters.WebRootPath,
                    folder
               });
                string fullPath = SwCmsHelper.GetFullPath(new string[]
                {
                    webFolder,
                    filename
                });
                string fileData = strBase64.Substring(strBase64.IndexOf(',') + 1);
                byte[] bytes = Convert.FromBase64String(fileData);

                if (!Directory.Exists(webFolder))
                {
                    Directory.CreateDirectory(webFolder);
                }

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                FileStream fs = new FileStream(fullPath, FileMode.Create);
                BinaryWriter w = new BinaryWriter(fs);
                try
                {
                    w.Write(bytes);
                }
                finally
                {
                    fs.Close();
                    w.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void WriteBytesToFile(string fullPath, string strBase64)
        {
            string fileData = strBase64.Substring(strBase64.IndexOf(',') + 1);
            byte[] bytes = Convert.FromBase64String(fileData);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            FileStream fs = new FileStream(fullPath, FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            try
            {
                w.Write(bytes);
            }
            finally
            {
                fs.Close();
                w.Close();
            }
        }

        public static string SubString(string src, int length)
        {
            return src.Length <= length ? src
                : src.Substring(0, length) + "...";
        }

        public static string FormatPrice(double? price, string oldPrice = "0")
        {
            string strPrice = price?.ToString();
            if (string.IsNullOrEmpty(strPrice))
            {
                return "0";
            }
            string s1 = strPrice.Replace(",", string.Empty);
            if (CheckIsPrice(s1))
            {
                Regex rgx = new Regex("(\\d+)(\\d{3})");
                while (rgx.IsMatch(s1))
                {
                    s1 = rgx.Replace(s1, "$1" + "," + "$2");
                }
                return s1;
            }
            return oldPrice;
        }

        public static bool CheckIsPrice(string number)
        {
            if (number == null)
            {
                return false;
            }
            number = number.Replace(",", "");

            return double.TryParse(number, out double t);
        }

        public static double ReversePrice(string formatedPrice)
        {
            try
            {
                if (string.IsNullOrEmpty(formatedPrice))
                {
                    return 0;
                }
                return double.Parse(formatedPrice.Replace(",", string.Empty));
            }
            catch
            {
                return 0;
            }
        }
    }
}
