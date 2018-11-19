using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioSetAttribute
    {
        public SioSetAttribute()
        {
            SioArticle = new HashSet<SioArticle>();
            SioPage = new HashSet<SioPage>();
            SioProduct = new HashSet<SioProduct>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int Type { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<SioArticle> SioArticle { get; set; }
        public ICollection<SioPage> SioPage { get; set; }
        public ICollection<SioProduct> SioProduct { get; set; }
    }
}
