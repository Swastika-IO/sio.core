using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models
{
    public partial class SiocCulture
    {
        public SiocCulture()
        {
            SiocArticle = new HashSet<SiocArticle>();
            SiocCategory = new HashSet<SiocCategory>();
            SiocConfiguration = new HashSet<SiocConfiguration>();
            SiocModule = new HashSet<SiocModule>();
        }

        public int Id { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string Icon { get; set; }
        public string Lcid { get; set; }
        public string Specificulture { get; set; }

        public ICollection<SiocArticle> SiocArticle { get; set; }
        public ICollection<SiocCategory> SiocCategory { get; set; }
        public ICollection<SiocConfiguration> SiocConfiguration { get; set; }
        public ICollection<SiocModule> SiocModule { get; set; }
    }
}
