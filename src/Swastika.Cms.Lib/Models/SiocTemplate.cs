using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocTemplate
    {
        public SiocTemplate()
        {
            SiocTemplateFile = new HashSet<SiocTemplateFile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Priority { get; set; }

        public ICollection<SiocTemplateFile> SiocTemplateFile { get; set; }
    }
}
