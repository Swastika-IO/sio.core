using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Common.Helper;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.ViewModels.SioPortalPagePortalPages
{
    public class ReadViewModel
       : ViewModelBase<SioCmsContext, SioPortalPageNavigation, ReadViewModel>
    {
        public ReadViewModel(SioPortalPageNavigation model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public ReadViewModel() : base()
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
        public SioPortalPages.ReadRolePermissionViewModel Page { get; set; }


        #endregion Views

        #region overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCategory = SioPortalPages.ReadRolePermissionViewModel.Repository.GetSingleModel(p => p.Id == Id
               
            );
            if (getCategory.IsSucceed)
            {
                Page = getCategory.Data;
            }
        }

        #endregion overrides

        #region Expands

        public static async System.Threading.Tasks.Task<RepositoryResponse<List<ReadViewModel>>> UpdateInfosAsync(List<SioPortalPagePortalPages.ReadViewModel> cates)
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
