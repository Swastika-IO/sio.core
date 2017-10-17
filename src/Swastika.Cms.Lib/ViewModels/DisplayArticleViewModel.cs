using Swastika.Cms.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Infrastructure.Data.Repository;

namespace Swastika.Cms.Lib.ViewModels
{
    public class DisplayArticleViewModel: 
        Swastika.Infrastructure.Data.ViewModels.ViewModelBase<Stag_swastika_ioContext, SiocArticle, DisplayArticleViewModel>
    {
        public string Id { get; set; }
        public string Specificulture { get; set; }
        public string Template { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }

        public CultureViewModel Culture { get; set; }

        public DisplayArticleViewModel(SiocArticle model
            , Stag_swastika_ioContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
        }
        

        public override DisplayArticleViewModel ParseView(Stag_swastika_ioContext _context = null, IDbContextTransaction _transaction = null)
        {
            var vm = base.ParseView(_context, _transaction);
            var getCulture = CultureViewModel.Repository.GetSingleModel
                (c => c.Specificulture == Specificulture, _context, _transaction);
            if (getCulture.IsSucceed)
            {
                vm.Culture = getCulture.Data;
            }
            return vm;
        }
    }


    public class ArticleViewModel :
        Swastika.Infrastructure.Data.ViewModels.ViewModelBase<Stag_swastika_ioContext, SiocArticle, ArticleViewModel>
    {
        public string Id { get; set; }
        public string Specificulture { get; set; }
        public string Template { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }

        public ArticleViewModel(SiocArticle model
            , Stag_swastika_ioContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }
       
    }


}
