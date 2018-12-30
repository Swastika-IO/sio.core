using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Common.Helper;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sio.Cms.Lib.ViewModels.SioPortalPagePortalPages
{
    public class UpdateViewModel
       : ViewModelBase<SioCmsContext, SioPortalPageNavigation, UpdateViewModel>
    {
        public UpdateViewModel(SioPortalPageNavigation model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public UpdateViewModel() : base()
        {
        }


        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parentId")]
        public int ParentId { get; set; }


        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }


        #region Views

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("page")]
        public SioPortalPages.UpdateRolePermissionViewModel Page { get; set; }

        [JsonProperty("parent")]
        public SioPortalPages.ReadViewModel ParentPage { get; set; }

        #endregion Views

        #region overrides
        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SioPortalPageNavigation parent, SioCmsContext _context, IDbContextTransaction _transaction)
        {
            if (Page != null)
            {
                var result = await Page.SaveModelAsync(false, _context, _transaction);
                return new RepositoryResponse<bool>()
                {
                    IsSucceed = result.IsSucceed,
                    Data = result.IsSucceed,
                    Errors = result.Errors,
                    Exception = result.Exception
                };
            }
            else
            {
                return await base.SaveSubModelsAsync(parent, _context, _transaction);
            }

        }
        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCategory = SioPortalPages.UpdateRolePermissionViewModel.Repository.GetSingleModel(p => p.Id == Id

            );
            if (getCategory.IsSucceed)
            {
                Page = getCategory.Data;
            }
            //var getParent = SioPortalPages.ReadViewModel.Repository.GetSingleModel(p => p.Id == ParentId
            //    , _context: _context, _transaction: _transaction
            //);
            //if (getParent.IsSucceed)
            //{
            //    ParentPage = getParent.Data;
            //}
        }

        #endregion overrides

        #region Expands

        public static async System.Threading.Tasks.Task<RepositoryResponse<List<UpdateViewModel>>> UpdateInfosAsync(List<SioPortalPagePortalPages.UpdateViewModel> cates)
        {
            SioCmsContext context = new SioCmsContext();
            var transaction = context.Database.BeginTransaction();
            var result = new RepositoryResponse<List<UpdateViewModel>>();
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
                UnitOfWorkHelper<SioCmsContext>.HandleException<UpdateViewModel>(ex, true, transaction);
                return new RepositoryResponse<List<UpdateViewModel>>()
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
