using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Swastika.Extension.Blog.Models
{
    public partial class BlogSetting : Entity {
        public BlogSetting()
        {
            BlogSettingValue = new HashSet<BlogSettingValue>();
        }

        public int SettingId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SvgIcon { get; set; }

        public virtual ICollection<BlogSettingValue> BlogSettingValue { get; set; }
    }
}
