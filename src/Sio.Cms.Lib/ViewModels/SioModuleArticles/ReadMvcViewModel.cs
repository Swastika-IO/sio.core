using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioModuleArticles
{
    public class ReadMvcViewModel
       : ViewModelBase<SioCmsContext, SioModuleArticle, ReadMvcViewModel>
    {
        public ReadMvcViewModel(SioModuleArticle model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadMvcViewModel() : base()
        {
        }

        [JsonProperty("articleId")]
        public int ArticleId { get; set; }

        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("status")]
        public SioEnums.SioContentStatus Status { get; set; }
        #region Views
        [JsonProperty("article")]
        public SioArticles.ReadMvcViewModel Article { get; set; }

        #endregion Views

        #region overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getArticle = SioArticles.ReadMvcViewModel.Repository.GetSingleModel(p => p.Id == ArticleId && p.Specificulture == Specificulture
                , _context: _context, _transaction: _transaction
            );
            if (getArticle.IsSucceed)
            {
                Article = getArticle.Data;
            }
        }

        #region Async

        #endregion Async

        #endregion overrides


        #region Expand


        public static RepositoryResponse<List<SioModuleArticles.ReadViewModel>> GetModuleArticleNavAsync(int articleId, string specificulture
           , SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            SioCmsContext context = _context ?? new SioCmsContext();
            var transaction = _transaction ?? context.Database.BeginTransaction();
            try
            {
                var navCategoryArticleViewModels = context.SioModule.Include(cp => cp.SioModuleArticle).Where(a => a.Specificulture == specificulture && a.Type == (int)SioEnums.SioModuleType.ListArticle)
                    .Select(p => new SioModuleArticles.ReadViewModel(
                        new SioModuleArticle()
                        {
                            ArticleId = articleId,
                            ModuleId = p.Id,
                            Specificulture = specificulture
                        },
                        _context, _transaction)
                    {
                        IsActived = p.SioModuleArticle.Any(cp => cp.ArticleId == articleId && cp.Specificulture == specificulture),
                        Description = p.Title
                    });
                return new RepositoryResponse<List<ReadViewModel>>()
                {
                    IsSucceed = true,
                    Data = navCategoryArticleViewModels.ToList()
                };
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                if (_transaction == null)
                {
                    transaction.Rollback();
                }
                return new RepositoryResponse<List<SioModuleArticles.ReadViewModel>>()
                {
                    IsSucceed = true,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                if (_context == null)
                {
                    //if current Context is Root
                    transaction.Dispose();
                    context.Dispose();
                }
            }
        }

        #endregion
    }
}
