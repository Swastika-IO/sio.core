using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioModule
    {
        public SioModule()
        {
            SioArticleModule = new HashSet<SioArticleModule>();
            SioModuleArticle = new HashSet<SioModuleArticle>();
            SioModuleAttributeSet = new HashSet<SioModuleAttributeSet>();
            SioModuleData = new HashSet<SioModuleData>();
            SioModuleProduct = new HashSet<SioModuleProduct>();
            SioPageModule = new HashSet<SioPageModule>();
            SioProductModule = new HashSet<SioProductModule>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }
        public string Image { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string Template { get; set; }
        public string FormTemplate { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int? PageSize { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public SioCulture SpecificultureNavigation { get; set; }
        public ICollection<SioArticleModule> SioArticleModule { get; set; }
        public ICollection<SioModuleArticle> SioModuleArticle { get; set; }
        public ICollection<SioModuleAttributeSet> SioModuleAttributeSet { get; set; }
        public ICollection<SioModuleData> SioModuleData { get; set; }
        public ICollection<SioModuleProduct> SioModuleProduct { get; set; }
        public ICollection<SioPageModule> SioPageModule { get; set; }
        public ICollection<SioProductModule> SioProductModule { get; set; }
    }
}
