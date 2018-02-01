using System;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Domain.Core.ViewModels;
using Swastika.Cms.Lib.Repositories;
using System.Threading.Tasks;
using Swastika.Common.Helper;
using Swastika.Cms.Lib.Services;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
    public class SpaTemplateViewModel
       : ViewModelBase<SiocCmsContext, SiocTemplate, SpaTemplateViewModel>
    {
        #region Properties

        #region Models
        [JsonIgnore]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonIgnore]
        [JsonProperty("templateId")]
        public int TemplateId { get; set; }
        [JsonIgnore]
        [JsonProperty("templateName")]
        public string TemplateName { get; set; }
        [JsonProperty("spaContent")]
        public string SpaContent { get; set; }
        #endregion

        #region Views
        #endregion

        #endregion

        #region Contructors

        public SpaTemplateViewModel()
            : base()
        {
        }

        public SpaTemplateViewModel(SiocTemplate model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #region Common

        #endregion



        #endregion
        #region Expands

        /// <summary>
        /// Gets the template by path.
        /// </summary>
        /// <param name="path">The path.</param> Ex: "Pages/_Home"
        /// <returns></returns>
        public static RepositoryResponse<SpaTemplateViewModel> GetTemplateByPath(string path, string culture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<SpaTemplateViewModel> result = new RepositoryResponse<SpaTemplateViewModel>();
            string[] temp = path.Split('/');
            if (temp.Length < 2)
            {
                result.IsSucceed = false;
                result.Errors.Add("Template Not Found");
            }
            else
            {
                int activeThemeId = GlobalConfigurationService.Instance.GetLocalInt(
                    SWCmsConstants.ConfigurationKeyword.ThemeId, culture, 0);

                result = Repository.GetSingleModel(t => t.FolderType == temp[0] && t.FileName == temp[1].Split('.')[0] && t.TemplateId == activeThemeId
                    , _context, _transaction);
            }
            return result;
        }


        #endregion

    }
}
