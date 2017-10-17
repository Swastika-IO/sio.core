using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocCulture
    {
        public SiocCulture()
        {
            BaseConfiguration = new HashSet<BaseConfiguration>();
            SiocArticle = new HashSet<SiocArticle>();
            SiocBanner = new HashSet<SiocBanner>();
            SiocCategory = new HashSet<SiocCategory>();
            SiocModule = new HashSet<SiocModule>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Lcid { get; set; }
        public string Alias { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public ICollection<BaseConfiguration> BaseConfiguration { get; set; }
        public ICollection<SiocArticle> SiocArticle { get; set; }
        public ICollection<SiocBanner> SiocBanner { get; set; }
        public ICollection<SiocCategory> SiocCategory { get; set; }
        public ICollection<SiocModule> SiocModule { get; set; }
    }
}
