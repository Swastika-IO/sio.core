// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocProductModule
    {
        public int ModuleId { get; set; }
        public string ProductId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Specificulture { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocModule SiocModule { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}