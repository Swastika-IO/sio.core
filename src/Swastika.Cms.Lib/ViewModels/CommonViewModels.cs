using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swastika.IO.Cms.Lib.ViewModels
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
        public string FileFolder { get; set; }
        [Required]
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


}
