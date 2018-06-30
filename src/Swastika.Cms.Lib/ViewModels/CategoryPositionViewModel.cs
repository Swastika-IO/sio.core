// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels
{
    public class CategoryPositionViewModel : ViewModelBase<SiocCmsContext, SiocCategoryPosition, CategoryPositionViewModel>
    {
        public CategoryPositionViewModel(SiocCategoryPosition model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public CategoryPositionViewModel() : base()
        {
        }
        [JsonProperty("positionId")]
        public int PositionId { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        #region overrides
        public override SiocCategoryPosition ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Priority == 0)
            {
                Priority = Repository.Max(n => n.Priority).Data + 1;
            }
            return base.ParseModel(_context, _transaction);
        }
        #region Async

        #endregion Async

        #endregion overrides
    }
}
