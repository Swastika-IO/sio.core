using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioTheme
    {
        public SioTheme()
        {
            SioFile = new HashSet<SioFile>();
            SioTemplate = new HashSet<SioTemplate>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string PreviewUrl { get; set; }

        public ICollection<SioFile> SioFile { get; set; }
        public ICollection<SioTemplate> SioTemplate { get; set; }
    }
}
