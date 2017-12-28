using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.IO.Common.Helper;

namespace Swastika.Cms.Lib.ViewModels.Cms
{
    public class _BlankViewModel
        : ViewModelBase<SiocCmsContext, SiocArticle, _BlankViewModel>
    {
        #region Properties
        //[JsonProperty("id")]

        #region Models

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public _BlankViewModel() : base()
        {
        }

        public _BlankViewModel(SiocArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
