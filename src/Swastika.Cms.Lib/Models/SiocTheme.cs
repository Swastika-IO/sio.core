using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocTheme
    {
        public SiocTheme()
        {
            SiocFile = new HashSet<SiocFile>();
            SiocTemplate = new HashSet<SiocTemplate>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }

        public ICollection<SiocFile> SiocFile { get; set; }
        public ICollection<SiocTemplate> SiocTemplate { get; set; }
    }
}
