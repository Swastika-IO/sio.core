using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioUrlAlias
    {
        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string SourceId { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public SioCulture SpecificultureNavigation { get; set; }
    }
}
