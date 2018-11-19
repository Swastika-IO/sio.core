using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioCulture
    {
        public SioCulture()
        {
            SioArticle = new HashSet<SioArticle>();
            SioConfiguration = new HashSet<SioConfiguration>();
            SioLanguage = new HashSet<SioLanguage>();
            SioModule = new HashSet<SioModule>();
            SioPage = new HashSet<SioPage>();
            SioProduct = new HashSet<SioProduct>();
            SioUrlAlias = new HashSet<SioUrlAlias>();
        }

        public int Id { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string Icon { get; set; }
        public string Lcid { get; set; }
        public int Priority { get; set; }
        public string Specificulture { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<SioArticle> SioArticle { get; set; }
        public ICollection<SioConfiguration> SioConfiguration { get; set; }
        public ICollection<SioLanguage> SioLanguage { get; set; }
        public ICollection<SioModule> SioModule { get; set; }
        public ICollection<SioPage> SioPage { get; set; }
        public ICollection<SioProduct> SioProduct { get; set; }
        public ICollection<SioUrlAlias> SioUrlAlias { get; set; }
    }
}
