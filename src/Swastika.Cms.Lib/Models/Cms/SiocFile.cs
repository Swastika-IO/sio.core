using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocFile
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Extension { get; set; }
        public string FileFolder { get; set; }
        public string FileName { get; set; }
        public string FolderType { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int Priority { get; set; }
        public int? ThemeId { get; set; }
        public string ThemeName { get; set; }
        public int Status { get; set; }

        public SiocTheme Theme { get; set; }
    }
}
