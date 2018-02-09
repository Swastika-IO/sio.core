using Newtonsoft.Json;
using Swastika.Common.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swastika.Cms.Lib.ViewModels
{
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

        public string FullPath
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] {
                    "",
                    SWCmsConstants.Parameters.FileFolder,
                    FileFolder,
                    string.Format("{0}{1}", Filename, Extension)
                });                
            }
            set { }
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
