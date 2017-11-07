using Swastika.Cms.Lib.Models;
using Swastika.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.IO.Cms.Lib.Models;

namespace Swastika.Cms.Lib.ViewModels
{
    public class ModuleArticleViewModel: ViewModelBase<SiocCmsContext, SiocModuleArticle, ModuleArticleViewModel>
    {
        public ModuleArticleViewModel(SiocModuleArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        public string ArticleId { get; set; }
        public int ModuleId { get; set; }
        public string Specificulture { get; set; }
        public bool IsActived { get; set; }
        public string Description { get; set; }
    }
}
