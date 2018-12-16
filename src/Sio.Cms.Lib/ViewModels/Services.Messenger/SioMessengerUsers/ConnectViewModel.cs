using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Sio.Cms.Messenger.Models;
using Sio.Cms.Messenger.Models.Data;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sio.Cms.Messenger.ViewModels.SioMessengerUsers
{
    public class ConnectViewModel
    {
        #region Properties
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("device")]
        public SioMessengerUserDevice Device { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        #endregion

        #region Contructor
        
        public ConnectViewModel(MessengerConnection connection)
        {
            Id = connection.Id;
            Name = connection.Name;
            Avatar = connection.Avatar;
            Device = new SioMessengerUserDevice()
            {
                UserId = connection.Id,
                ConnectionId = connection.ConnectionId,
                DeviceId = connection.DeviceId,
            };
            // TODO - verify cnn before add/update connections
        }
        #endregion

        #region Override

        #region Async
        public async Task<RepositoryResponse<bool>> Join()
        {
            using(SioChatServiceContext _context = new SioChatServiceContext())
            {
                var result = new RepositoryResponse<bool>() { IsSucceed = true };
                try
                {
                    var user = new SioMessengerUser()
                    {
                        Id = Id,
                        FacebookId = Id,
                        Avatar = Avatar,
                        CreatedDate = DateTime.UtcNow,
                        Name = Name,
                        Status = (int)SioChatEnums.OnlineStatus.Connected
                    };
                    if (_context.SioMessengerUser.Any(u=>u.Id == user.Id))
                    {
                        _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                    if (Device != null)
                    {
                        //var cnn = _context.SioMessengerUserDevice.FirstOrDefault(c => c.UserId == Device.UserId && c.DeviceId == Device.DeviceId);
                        if (_context.SioMessengerUserDevice.Any(c => c.UserId == Device.UserId && c.DeviceId == Device.DeviceId))
                        {
                            Device.ConnectionId = Device.ConnectionId;
                            Device.Status = (int)SioChatEnums.DeviceStatus.Actived;
                            Device.StartDate = DateTime.UtcNow;
                            _context.Entry(Device).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        }
                        else
                        {
                            Device.Status = (int)SioChatEnums.DeviceStatus.Actived;
                            Device.StartDate = DateTime.UtcNow;
                            _context.Entry(Device).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                        }
                        
                    }
                    result.IsSucceed = (await _context.SaveChangesAsync()) > 0;
                }
                catch (Exception ex)
                {
                    result.IsSucceed = false;
                    result.Exception = ex;
                }
                return result;
            }
            
        }
        #endregion

        #endregion
    }
}
