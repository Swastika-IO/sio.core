// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocCategoryModule
    {
        public SiocCategoryModule()
        {
            SiocModuleAttributeSet = new HashSet<SiocModuleAttributeSet>();
            SiocModuleData = new HashSet<SiocModuleData>();
        }

        public int ModuleId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }

        public SiocCategory SiocCategory { get; set; }
        public SiocModule SiocModule { get; set; }
        public ICollection<SiocModuleAttributeSet> SiocModuleAttributeSet { get; set; }
        public ICollection<SiocModuleData> SiocModuleData { get; set; }
    }
}
