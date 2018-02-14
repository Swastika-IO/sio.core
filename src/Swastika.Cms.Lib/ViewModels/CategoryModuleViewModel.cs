using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;

namespace Swastika.Cms.Lib.ViewModels
{
    public class CategoryModuleViewModel
        : ViewModelBase<SiocCmsContext, SiocCategoryModule, CategoryModuleViewModel>
    {
        public CategoryModuleViewModel()
        {
        }

        public CategoryModuleViewModel(SiocCategoryModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public int ModuleId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActived { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}