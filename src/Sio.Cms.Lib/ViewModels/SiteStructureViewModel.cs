using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sio.Cms.Lib.ViewModels
{
    public class SiteStructureViewModel
    {
        public List<SioPages.ImportViewModel> Pages { get; set; }
        
        public SiteStructureViewModel()
        {

        }
        public async Task InitAsync(string culture)
        {
            Pages = (await SioPages.ImportViewModel.Repository.GetModelListByAsync(p => p.Specificulture == culture)).Data;
        }

        public async Task<RepositoryResponse<bool>> Import(List<SioModule> arrModule, string destCulture)
        {
            return await SioPages.Helper.ImportAsync(Pages, destCulture);
        }
    }
}
