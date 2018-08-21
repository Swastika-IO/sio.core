// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavPortalPagePositionViewModel : ViewModelBase<SiocCmsContext, SiocPortalPagePosition, NavPortalPagePositionViewModel>
    {
        public NavPortalPagePositionViewModel(SiocPortalPagePosition model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public NavPortalPagePositionViewModel() : base()
        {
        }
        [JsonProperty("positionId")]
        public int PositionId { get; set; }
        [JsonProperty("portalPageId")]
        public int PortalPageId { get; set; }
        [JsonProperty("isActived")]
        public bool IsActived { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        #region overrides
        public override SiocPortalPagePosition ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
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
