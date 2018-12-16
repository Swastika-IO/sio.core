using Microsoft.EntityFrameworkCore.Storage;
using Sio.Domain.Data.ViewModels;
using Sio.Cms.Messenger.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sio.Cms.Messenger.ViewModels.SioMessengerUsers
{
    public class DefaultViewModel : ViewModelBase<SioChatServiceContext, SioMessengerUser, DefaultViewModel>
    {
        #region Properties
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("connections")]
        List<SioMessengerUserDevices.DefaultViewModel> Connections { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonProperty("status")]
        public SioChatEnums.OnlineStatus Status { get; set; }
        #endregion

        #region Contructor
        public DefaultViewModel()
        {
        }

        public DefaultViewModel(SioMessengerUser model, SioChatServiceContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
        #endregion

        #region Override

        #region Sync
        public override void ExpandView(SioChatServiceContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.Connections = SioMessengerUserDevices.DefaultViewModel.Repository.GetModelListBy(m => m.UserId == this.Id).Data;
        }
        #endregion

        #region Async
        public override async Task<bool> ExpandViewAsync(SioChatServiceContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.Connections = ( await SioMessengerUserDevices.DefaultViewModel.Repository.GetModelListByAsync(m => m.UserId == this.Id)).Data;
            return Connections != null;
        }
        #endregion

        #endregion
    }
}
