using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swastika.Cms.Lib.ViewModels
{
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
                string fullPath = string.Format(SWCmsConstants.Parameters.UploadFolder, FileFolder);
                return string.Format(@"/{0}/{1}.{2}", fullPath.Replace(@"wwwroot/", string.Empty), Filename, Extension);
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
        public string FileStream { get; set; }
    }
    public class ModuleFieldViewModel
    {
        public string Name { get; set; }
        public SWCmsConstants.DataType DataType { get; set; }
        public bool IsDisplay { get; set; }
        public int Width { get; set; }
    }
    public class AccessTokenViewModel
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public string Refresh_token { get; set; }
        public int Expires_in { get; set; }
        public string Client_id { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }
        public string DeviceId { get; set; }
        //public ApplicationUser UserData { get; set; }
    }

}
