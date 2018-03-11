// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocConfiguration
    {
        public string Keyword { get; set; }
        public string Specificulture { get; set; }
        public string Category { get; set; }
        public int DataType { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocCulture SpecificultureNavigation { get; set; }
    }
}
