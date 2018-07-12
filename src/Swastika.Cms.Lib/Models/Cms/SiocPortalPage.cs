using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocPortalPage
    {
        public SiocPortalPage()
        {
            SiocPortalPageNavigationIdNavigation = new HashSet<SiocPortalPageNavigation>();
            SiocPortalPageNavigationParent = new HashSet<SiocPortalPageNavigation>();
            SiocPortalPageRole = new HashSet<SiocPortalPageRole>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? ParentId { get; set; }
        public int Priority { get; set; }
        public string RouteAction { get; set; }
        public string RouteName { get; set; }
        public string RouteValue { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public ICollection<SiocPortalPageNavigation> SiocPortalPageNavigationIdNavigation { get; set; }
        public ICollection<SiocPortalPageNavigation> SiocPortalPageNavigationParent { get; set; }
        public ICollection<SiocPortalPageRole> SiocPortalPageRole { get; set; }
    }
}
