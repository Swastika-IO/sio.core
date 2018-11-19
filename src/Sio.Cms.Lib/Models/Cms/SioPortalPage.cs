using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioPortalPage
    {
        public SioPortalPage()
        {
            SioPortalPageNavigationIdNavigation = new HashSet<SioPortalPageNavigation>();
            SioPortalPageNavigationParent = new HashSet<SioPortalPageNavigation>();
            SioPortalPagePosition = new HashSet<SioPortalPagePosition>();
            SioPortalPageRole = new HashSet<SioPortalPageRole>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Priority { get; set; }
        public string Icon { get; set; }
        public string TextKeyword { get; set; }
        public int Status { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string TextDefault { get; set; }
        public int Level { get; set; }

        public ICollection<SioPortalPageNavigation> SioPortalPageNavigationIdNavigation { get; set; }
        public ICollection<SioPortalPageNavigation> SioPortalPageNavigationParent { get; set; }
        public ICollection<SioPortalPagePosition> SioPortalPagePosition { get; set; }
        public ICollection<SioPortalPageRole> SioPortalPageRole { get; set; }
    }
}
