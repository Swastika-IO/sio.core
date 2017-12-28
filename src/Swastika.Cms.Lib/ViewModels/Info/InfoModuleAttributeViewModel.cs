using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Swastika.IO.Domain.Core.ViewModels;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoModuleAttributeViewModel
        : ViewModelBase<SiocCmsContext, SiocModuleAttributeValue, InfoModuleAttributeViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("dataType")]
        public int DataType { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        #endregion

        #region Views

        #endregion

        #endregion

        #region Contructors

        public InfoModuleAttributeViewModel() : base()
        {
        }

        public InfoModuleAttributeViewModel(SiocModuleAttributeValue model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion
    }

}
