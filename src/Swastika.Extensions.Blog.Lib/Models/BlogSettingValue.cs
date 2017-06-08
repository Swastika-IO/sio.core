using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Swastika.Extension.Blog.Models
{
    public partial class BlogSettingValue : Entity {
        public Guid SettingValueId { get; set; }
        public int SettingId { get; set; }
        public string SettingValues { get; set; }

        public virtual BlogSetting Setting { get; set; }
    }
}
