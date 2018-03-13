// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Common.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Swastika.Cms.Lib.ViewModels
{
    public class DashboardViewModel
    {
        [JsonProperty("totalPage")]
        public int TotalPage { get; set; }

        [JsonProperty("totalArticle")]
        public int TotalArticle { get; set; }

        [JsonProperty("totalProduct")]
        public int TotalProduct { get; set; }

        [JsonProperty("totalModule")]
        public int TotalModule { get; set; }

        [JsonProperty("totalUser")]
        public int TotalUser { get; set; }

        public DashboardViewModel()
        {
            using (SiocCmsContext context = new SiocCmsContext())
            {
                TotalPage = context.SiocCategory.Count();
                TotalArticle = context.SiocArticle.Count();
                TotalProduct = context.SiocProduct.Count();
            }
        }
    }

    public class InitCmsViewModel
    {
        public string DataBaseServer { get; set; }
        public string DataBaseName { get; set; }
        public string DataBaseUser { get; set; }
        public string DataBasePassword { get; set; }
        public bool IsUseLocal { get; set; }
    }

    public class FileStreamViewModel
    {
        public string Base64 { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
    }

    public class FileViewModel
    {
        public string FullPath {
            get {
                return CommonHelper.GetFullPath(new string[] {
                    "",
                    SWCmsConstants.Parameters.FileFolder,
                    FileFolder,
                    string.Format("{0}{1}", Filename, Extension)
                });
            }
            set {
            }
        }

        public string FolderName { get; set; }
        public string FileFolder { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string Content { get; set; }
        public string FileStream { get; set; }
    }

    public class TemplateViewModel
    {
        public string FileFolder { get; set; }

        [Required]
        public string Filename { get; set; }

        public string Extension { get; set; }
        public string Content { get; set; }
        public string Scripts { get; set; }
        public string Styles { get; set; }
        public string FileStream { get; set; }
    }

    public class ModuleFieldViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }

        [JsonProperty("isDisplay")]
        public bool IsDisplay { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class ModuleDataValueViewModel
    {
        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }

        [JsonProperty("value")]
        public IConvertible Value { get; set; }

        [JsonProperty("stringValue")]
        public string StringValue { get; set; }

        public T GetValue<T>()
        {
            return this.Value != null ? (T)Value : default(T);
        }
    }

    public class ExtraProperty
    {
        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        //public T GetValue<T>()
        //{
        //    return this.Value != null ? (T)Value : default(T);
        //}
    }

    public class AccessTokenViewModel
    {
        [JsonProperty("access_token")]
        public string Access_token { get; set; }

        [JsonProperty("token_type")]
        public string Token_type { get; set; }

        [JsonProperty("refresh_token")]
        public string Refresh_token { get; set; }

        [JsonProperty("expires_in")]
        public int Expires_in { get; set; }

        [JsonProperty("client_id")]
        public string Client_id { get; set; }

        [JsonProperty("issued")]
        public DateTime Issued { get; set; }

        [JsonProperty("expires")]
        public DateTime Expires { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        //public ApplicationUser UserData { get; set; }
    }
}
