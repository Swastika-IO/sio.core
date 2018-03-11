// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using System;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocModuleAttributeValue
    {
        public Guid Id { get; set; }
        public Guid AttributeSetId { get; set; }
        public string Specificulture { get; set; }
        public int DataType { get; set; }
        public string DefaultValue { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public SiocModuleAttributeSet SiocModuleAttributeSet { get; set; }
    }
}
