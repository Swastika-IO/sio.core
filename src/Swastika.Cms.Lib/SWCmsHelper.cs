using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib.ViewModels.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Swastika.Cms.Lib
{
    public class SWCmsHelper
    {
        public static List<InfoCategoryViewModel> GetCategory(IUrlHelper Url, string culture, SWCmsConstants.CatePosition position, string activePath = "")
        {

            var getTopCates = InfoCategoryViewModel.Repository.GetModelListBy
            (c => c.Specificulture == culture && c.SiocCategoryPosition.Count(
              p => p.PositionId == (int)position) > 0
            );
            var cates = getTopCates.Data ?? new List<InfoCategoryViewModel>();
            
            foreach (var cate in cates)
            {                
                switch (cate.Type)
                {
                    case SWCmsConstants.CateType.Blank:
                        break;                   
                    case SWCmsConstants.CateType.StaticUrl:
                        cate.Href = cate.StaticUrl;
                        break;
                    case SWCmsConstants.CateType.Home:
                    case SWCmsConstants.CateType.List:
                    case SWCmsConstants.CateType.Article:                        
                    case SWCmsConstants.CateType.Modules:
                    default:
                        cate.Href = Url.RouteUrl("Page", new { culture = culture, pageName = cate.SeoName });
                        break;
                }
                cate.IsActived = cate.Href == activePath;
            }
            return cates;
        }

        public static RSAParameters GenerateKey()
        {
            using (var key = new RSACryptoServiceProvider(2048))
            {
                return key.ExportParameters(true);
            }
        }
        
        public static string GetFullPath(string[] subPaths)
        {
            string result = string.Empty;
            string strFormat = string.Empty;
            for (int i = 0; i < subPaths.Length; i++)
            {
                strFormat += @"{" + i + "}" + (i < subPaths.Length - 1 ? "/" : string.Empty);
            }
            return string.Format(strFormat, subPaths);
        }

        public static string GetRandomName(string filename)
        {
            string ext = filename.Split('.')[1];
            return string.Format("{0}.{1}", Guid.NewGuid().ToString("N"), ext);
        }

        public static bool SaveFileBase64(string folder, string filename, string strBase64)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            try
            {
                string webFolder = SWCmsHelper.GetFullPath(new string[]
               {
                    SWCmsConstants.Parameters.WebRootPath,
                    folder
               });
                string fullPath = SWCmsHelper.GetFullPath(new string[]
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
            catch//(Exception ex)
            {
                return false;
            }
        }

        public static bool RemoveFile(string filePath)
        {
            bool result = false;
            try
            {
                string fullPath = SWCmsHelper.GetFullPath(new string[]
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

            }
            return result;
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
    }
}
