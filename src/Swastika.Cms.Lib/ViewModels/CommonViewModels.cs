// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Common.Helper;
using Swastika.Domain.Core.Models;
using Swastika.Identity.Models;
using System;
using System.Collections.Generic;
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
        [JsonProperty("dataBaseServer")]
        public string DataBaseServer { get; set; }

        [JsonProperty("dataBaseName")]
        public string DataBaseName { get; set; }

        [JsonProperty("dataBaseUser")]
        public string DataBaseUser { get; set; }

        [JsonProperty("dataBasePassword")]
        public string DataBasePassword { get; set; }

        [JsonProperty("isUseLocal")]
        public bool IsUseLocal { get; set; }

        [JsonProperty("localDbName")]
        public string LocalDbName { get; set; }

        [JsonProperty("localDbConnectionString")]
        public string LocalDbConnectionString { get; set; }

        [JsonProperty("superAdmin")]
        public string SuperAdmin { get; set; }

        [JsonProperty("adminPasseord")]
        public string AdminPassword { get; set; }
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
        private string _fullPath = string.Empty;
        private string _webPath = string.Empty;
        [JsonProperty("fullPath")]
        public string FullPath {
            get {
                _fullPath = CommonHelper.GetFullPath(new string[] {
                    FileFolder,
                    FolderName,
                    $"{Filename}{Extension}"
                });

                return _fullPath;
            }
            set {
                _fullPath = value;
            }
        }
        [JsonProperty("webPath")]
        public string WebPath
        {
            get
            {
                _webPath = CommonHelper.GetFullPath(new string[] {
                    FileFolder,
                    $"{Filename}{Extension}"
                });
                return _webPath;
            }
            set
            {
                _webPath = value;
            }
        }
        [JsonProperty("folderName")]
        public string FolderName { get; set; }
        [JsonProperty("fileFolder")]
        public string FileFolder { get; set; }
        [JsonProperty("fileName")]
        public string Filename { get; set; }
        [JsonProperty("extension")]
        public string Extension { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("fileStream")]
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

        [JsonProperty("options")]
        public JArray Options { get; set; } = new JArray();

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }

        [JsonProperty("isDisplay")]
        public bool IsDisplay { get; set; }

        [JsonProperty("isSelect")]
        public bool IsSelect { get; set; }

        [JsonProperty("isGroupBy")]
        public bool IsGroupBy { get; set; }

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
        [JsonProperty("isDisplay")]
        public bool IsDisplay { get; set; }
        [JsonProperty("isSelect")]
        public bool IsSelect { get; set; }
        [JsonProperty("isGroupBy")]
        public bool IsGroupBy { get; set; }
        [JsonProperty("options")]
        public JArray Options { get; set; } = new JArray();
    }

    public class SpaModuleDataValueViewModel
    {
        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dataType")]
        public SWCmsConstants.DataType DataType { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }

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

        public InfoUserViewModel UserData { get; set; }
    }

    public class SiteSettingsViewModel
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("themeId")]
        public int ThemeId { get; set; }

        [JsonProperty("cultures")]
        public List<SupportedCulture> Cultures { get; set; }

        [JsonProperty("pageTypes")]
        public List<string> PageTypes { get; set; }
    }
}
