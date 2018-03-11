// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using System;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocFile
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Extension { get; set; }
        public string FileFolder { get; set; }
        public string FileName { get; set; }
        public string FolderType { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int Priority { get; set; }
        public int? ThemeId { get; set; }
        public string ThemeName { get; set; }
        public int Status { get; set; }

        public SiocTheme Theme { get; set; }
    }
}
