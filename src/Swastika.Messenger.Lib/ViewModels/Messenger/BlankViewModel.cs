using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Messenger.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.IO.Common.Helper;
using ChatRoom.Lib.Helpers;

namespace Swastika.Messenger.Lib.ViewModels.Messenger
{
    public class BlankViewModel 
        : ViewModelBase<MessengerContext, Blank, BlankViewModel>
    {
        #region Properties
        [JsonProperty("id")]

        #region Models

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public BlankViewModel() : base()
        {
        }

        public BlankViewModel(Blank model, MessengerContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #endregion

        #region Expands

        #endregion

    }
}
