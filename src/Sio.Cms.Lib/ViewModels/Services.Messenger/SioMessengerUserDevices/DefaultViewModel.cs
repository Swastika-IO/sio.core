using Microsoft.EntityFrameworkCore.Storage;
using Sio.Domain.Data.ViewModels;
using Sio.Cms.Messenger.Models.Data;
using Newtonsoft.Json;
using System;

namespace Sio.Cms.Messenger.ViewModels.SioMessengerUserDevices
{
    public class DefaultViewModel : ViewModelBase<SioChatServiceContext, SioMessengerUserDevice, DefaultViewModel>
    {
        #region Properties
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty("status")]
        public SioChatEnums.DeviceStatus Status { get; set; }
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }
        #endregion

        public DefaultViewModel()
        {
        }
        public DefaultViewModel(SioMessengerUserDevice model, SioChatServiceContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }
    }
}
