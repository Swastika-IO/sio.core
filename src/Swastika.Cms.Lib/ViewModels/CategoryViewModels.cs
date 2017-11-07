using Swastika.Cms.Lib.Models;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.IO.Cms.Lib.Models;

namespace Swastika.Cms.Lib.ViewModels
{
    public class InfoCategoryViewModel : ViewModelBase<SiocCmsContext, SiocCategory, InfoCategoryViewModel>
    {
        public int Id { get; set; }
        public string Specificulture { get; set; }
        public string Template { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string StaticUrl { get; set; }
        public string Excerpt { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public int Priority { get; set; }
        public string Tags { get; set; }

        public InfoCategoryViewModel(SiocCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {

        }
    }
}
