// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocMedia
    {
        public SiocMedia()
        {
            SiocArticleMedia = new HashSet<SiocArticleMedia>();
            SiocProductMedia = new HashSet<SiocProductMedia>();
        }

        public int Id { get; set; }
        public string Specificulture { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Extension { get; set; }
        public string FileFolder { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileProperties { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public long FileSize { get; set; }
        public string Title { get; set; }

        public ICollection<SiocArticleMedia> SiocArticleMedia { get; set; }
        public ICollection<SiocProductMedia> SiocProductMedia { get; set; }
    }
}
