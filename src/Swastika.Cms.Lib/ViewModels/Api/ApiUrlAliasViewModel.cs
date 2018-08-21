// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Domain.Data.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Swastika.Cms.Lib.SWCmsConstants;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiUrlAliasViewModel
        : ViewModelBase<SiocCmsContext, SiocUrlAlias, ApiUrlAliasViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        //[Required]
        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        [Required]
        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public UrlAliasType Type { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion Models

        #endregion

        #region Contructors

        public ApiUrlAliasViewModel() : base()
        {
        }

        public ApiUrlAliasViewModel(SiocUrlAlias model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override SiocUrlAlias ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                Id = ApiUrlAliasViewModel.Repository.Max(c => c.Id, _context, _transaction).Data + 1;
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }
        
        public override void Validate(SiocCmsContext _context, IDbContextTransaction _transaction)
        {
            base.Validate(_context, _transaction);
            if (_context.SiocUrlAlias.Any(u => u.Alias == Alias && u.Specificulture == Specificulture && u.SourceId != SourceId))
            {
                IsValid = false;
                Errors.Add("Url Alias is existed");
            }
        }
        #endregion Overrides
    }

}