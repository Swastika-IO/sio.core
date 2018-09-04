// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Domain.Data.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiCommentViewModel
      : ViewModelBase<SiocCmsContext, SiocComment, ApiCommentViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public Guid Id { get; set; }
        [Required]
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("customerId")]
        public string CreatedBy { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("rating")]
        public double Rating { get; set; }

        #endregion Models

        #region Views


        #endregion Views

        #endregion Properties

        #region Contructors

        public ApiCommentViewModel() : base()
        {
        }

        public ApiCommentViewModel(SiocComment model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        public override void Validate(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            base.Validate(_context, _transaction);
            if (IsValid)
            {
                if (!ApiOrderViewModel.Repository.CheckIsExists(o=>o.Id==OrderId && o.Specificulture==Specificulture))
                {
                    Errors.Add("Invalid Order");
                    IsValid = false;
                }
            }
        }

        public override SiocComment ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == default(Guid))
            {
                Id = Guid.NewGuid();
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }

        
    }
}
