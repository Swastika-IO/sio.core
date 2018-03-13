// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocCategoryArticle
    {
        public string ArticleId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public int? Priority { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public SiocArticle SiocArticle { get; set; }
        public SiocCategory SiocCategory { get; set; }
    }
}
