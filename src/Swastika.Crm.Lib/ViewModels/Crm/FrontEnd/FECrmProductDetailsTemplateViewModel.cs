using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Crm.Lib.Models.Crm;

namespace Swastika.Crm.Lib.ViewModels.Crm.FrontEnd
{
    public class FECrmProductDetailsTemplateViewModel
        : ViewModelBase<SwastikaCrmContext, CrmProductDetailsTemplate, FECrmProductDetailsTemplateViewModel>
    {
        #region Properties

        #region Models

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public FECrmProductDetailsTemplateViewModel() : base()
        {
        }

        public FECrmProductDetailsTemplateViewModel(CrmProductDetailsTemplate model, SwastikaCrmContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
