// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels.Navigation
{
    public class NavProductMediaViewModel
        : ViewModelBase<SiocCmsContext, SiocProductMedia, NavProductMediaViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("mediaId")]
        public int MediaId { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("media")]
        public BEMediaViewModel Media { get; set; }

        #endregion Views

        #endregion Properties

        #region Contructors

        public NavProductMediaViewModel() : base()
        {
        }

        public NavProductMediaViewModel(SiocProductMedia model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getMedia = BEMediaViewModel.Repository.GetSingleModel(m => m.Id == MediaId && m.Specificulture == Specificulture
            , _context: _context, _transaction: _transaction
            );
            Media = getMedia.Data;
            Description = Media?.FileName;
            Image = Media?.FullPath;
        }

        public override SiocProductMedia ParseModel()
        {
            Description = Description ?? Media?.FileName;
            Image = Media?.FullPath;
            return base.ParseModel();
        }
        #endregion Overrides
    }
}