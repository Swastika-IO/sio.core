using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocTemplateFile
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string FolderType { get; set; }
        public string FileFolder { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int Priority { get; set; }

        public SiocTemplate Template { get; set; }
    }
}
