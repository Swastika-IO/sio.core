using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Domain.Data.ViewModels;
using Swastika.IO.Cms.Lib.Models;
using Swastika.IO.Cms.Lib.Services;
using System.ComponentModel.DataAnnotations;

namespace Swastika.IO.Cms.Lib.ViewModels
{
    public class ConfigurationViewModel:
        ViewModelBase
        <SiocCmsContext, SiocConfiguration, ConfigurationViewModel>
    {
        [Required]
        public string Keyword { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
        public int DataType { get; set; }
        public string Description { get; set; }


        public ConfigurationViewModel(): base()
        {
        }

        public ConfigurationViewModel(
            SiocConfiguration model
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null) 
            : base(model, _context, _transaction)
        {
            
        }

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = ApplicationConfigService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported =
            (string.IsNullOrEmpty(Keyword) && c.Specificulture == Specificulture)
            || Repository.CheckIsExists(a => a.Keyword == Keyword && a.Specificulture == c.Specificulture, _context, _transaction)
            );
        }

        #endregion
    }
}
