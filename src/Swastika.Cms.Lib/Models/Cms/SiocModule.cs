// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocModule
    {
        public SiocModule()
        {
            SiocArticleModule = new HashSet<SiocArticleModule>();
            SiocCategoryModule = new HashSet<SiocCategoryModule>();
            SiocModuleArticle = new HashSet<SiocModuleArticle>();
            SiocModuleAttributeSet = new HashSet<SiocModuleAttributeSet>();
            SiocModuleData = new HashSet<SiocModuleData>();
            SiocModuleProduct = new HashSet<SiocModuleProduct>();
            SiocProductModule = new HashSet<SiocProductModule>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string Image { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocCulture SpecificultureNavigation { get; set; }
        public ICollection<SiocArticleModule> SiocArticleModule { get; set; }
        public ICollection<SiocCategoryModule> SiocCategoryModule { get; set; }
        public ICollection<SiocModuleArticle> SiocModuleArticle { get; set; }
        public ICollection<SiocModuleAttributeSet> SiocModuleAttributeSet { get; set; }
        public ICollection<SiocModuleData> SiocModuleData { get; set; }
        public ICollection<SiocModuleProduct> SiocModuleProduct { get; set; }
        public ICollection<SiocProductModule> SiocProductModule { get; set; }
    }
}
