using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using Sio.Common.Helper;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioModules
{
    public class ReadListItemViewModel : ViewModelBase<SioCmsContext, SioModule, ReadListItemViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }
        [JsonIgnore]
        public string Domain { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("fields")]
        public string Fields { get; set; }

        [JsonProperty("type")]
        public ModuleType Type { get; set; }

        [JsonProperty("status")]
        public SioContentStatus Status { get; set; }
        #endregion Models

        #endregion Properties

        #region Contructors

        public ReadListItemViewModel() : base()
        {
        }

        public ReadListItemViewModel(SioModule model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Domain = SioService.GetConfig<string>("Domain", Specificulture) ?? "/";
            if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
            {
                ImageUrl = CommonHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
            }
            else
            {
                ImageUrl = Image;
            }
        }

        public override Task<bool> ExpandViewAsync(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            Domain = SioService.GetConfig<string>("Domain", Specificulture) ?? "/";
            if (Image != null && (Image.IndexOf("http") == -1 && Image[0] != '/'))
            {
                ImageUrl = CommonHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
            }
            else
            {
                ImageUrl = Image;
            }
            return base.ExpandViewAsync(_context, _transaction);
        }

        #endregion
    }
}
