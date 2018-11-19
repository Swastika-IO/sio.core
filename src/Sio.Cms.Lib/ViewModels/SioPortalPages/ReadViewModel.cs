using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Common.Helper;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sio.Cms.Lib.ViewModels.SioPortalPages
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioPortalPage, ReadViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("textKeyword")]
        public string TextKeyword { get; set; }

        [JsonProperty("textDefault")]
        public string TextDefault { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Descriotion { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion Models
        #region Views
        [JsonProperty("childNavs")]
        public List<SioPortalPagePortalPages.ReadViewModel> ChildNavs { get; set; }
        #endregion
        #endregion Properties

        #region Contructors

        public ReadViewModel() : base()
        {
        }

        public ReadViewModel(SioPortalPage model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getChilds = SioPortalPagePortalPages.ReadViewModel.Repository.GetModelListBy(n => n.ParentId == Id, _context, _transaction);
            if (getChilds.IsSucceed)
            {
                ChildNavs = getChilds.Data.OrderBy(c => c.Priority).ToList();
            }
        }
        public override SioPortalPage ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (CreatedDateTime == default(DateTime))
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(ReadViewModel view, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            var navPages = _context.SioPortalPageNavigation.Where(p => p.ParentId == Id || p.Id == Id);
            await navPages.ForEachAsync(n => _context.Entry(n).State = EntityState.Deleted);
            var navRoles = _context.SioPortalPageRole.Where(p => p.PageId == Id);
            await navPages.ForEachAsync(n => _context.Entry(n).State = EntityState.Deleted);
            await _context.SaveChangesAsync();
            return result;
        }


        #endregion
        #region Expands
        
        public static async System.Threading.Tasks.Task<RepositoryResponse<List<ReadViewModel>>> UpdateInfosAsync(List<ReadViewModel> cates)
        {
            SioCmsContext context = new SioCmsContext();
            var transaction = context.Database.BeginTransaction();
            var result = new RepositoryResponse<List<ReadViewModel>>();
            try
            {

                foreach (var item in cates)
                {
                    var saveResult = await item.SaveModelAsync(false, context, transaction);
                    result.IsSucceed = saveResult.IsSucceed;
                    if (!result.IsSucceed)
                    {
                        result.Errors.AddRange(saveResult.Errors);
                        result.Exception = saveResult.Exception;
                        break;
                    }
                }
                UnitOfWorkHelper<SioCmsContext>.HandleTransaction(result.IsSucceed, true, transaction);
                return result;
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                UnitOfWorkHelper<SioCmsContext>.HandleException<ReadViewModel>(ex, true, transaction);
                return new RepositoryResponse<List<ReadViewModel>>()
                {
                    IsSucceed = false,
                    Data = null,
                    Exception = ex
                };
            }
            finally
            {
                //if current Context is Root
                transaction.Dispose();
                context.Dispose();
            }
        }
        #endregion
    }
}
