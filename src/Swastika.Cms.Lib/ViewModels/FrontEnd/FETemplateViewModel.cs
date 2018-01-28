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
    public class FETemplateViewModel
       : ViewModelBase<SiocCmsContext, SiocTemplate, FETemplateViewModel>
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
        [JsonIgnore]
        [JsonProperty("folderType")]
        public string FolderType { get; set; }
        [JsonIgnore]
        [JsonProperty("fileFolder")]
        public string FileFolder { get; set; }
        [JsonIgnore]
        [JsonProperty("fileName")]
        public string FileName { get; set; }
        [JsonIgnore]
        [JsonProperty("extension")]
        public string Extension { get; set; }
        [JsonIgnore]
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonIgnore]
        [JsonProperty("mobileContent")]
        public string MobileContent { get; set; }
        [JsonProperty("spaContent")]
        public string SpaContent { get; set; }
        [JsonProperty("scripts")]
        public string Scripts { get; set; }
        [JsonProperty("styles")]
        public string Styles { get; set; }
        [JsonIgnore]
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonIgnore]
        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        [JsonIgnore]
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion

        #region Views
        [JsonIgnore]
        [JsonProperty("assetFolder")]
        public string AssetFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] {
                    SWCmsConstants.Parameters.FileFolder,
                    SWCmsConstants.Parameters.TemplatesAssetFolder,
                    TemplateName });
            }
        }
        [JsonIgnore]
        [JsonProperty("templateFolder")]
        public string TemplateFolder
        {
            get
            {
                return CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesFolder, TemplateName });
            }
        }

        public string TemplatePath
        {
            get
            {
                return SWCmsHelper.GetFullPath(new string[]
                {
                    ""
                    , TemplateFolder
                    , FileFolder
                });
            }
        }
        [JsonIgnore]
        [JsonProperty("spaView")]
        public XElement SpaView
        {
            get
            {
                return !string.IsNullOrEmpty(SpaContent) ? XElement.Parse(Regex.Replace(SpaContent, "(?<!\r)\n|\r\n|\t", "").Trim()) : new XElement("div");
            }
        }
        [JsonProperty("mobileView")]
        public JObject MobileView
        {
            get
            {
                return !string.IsNullOrEmpty(MobileContent) ? JObject.Parse(MobileContent) : new JObject();
            }
        }
        [JsonProperty("mobileComponent")]
        public MobileComponent mobileComponent
        {
            get
            {
                return new MobileComponent(SpaView);
            }
        }
        #endregion

        #endregion

        #region Contructors

        public FETemplateViewModel()
            : base()
        {
        }

        public FETemplateViewModel(SiocTemplate model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        #region Common

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            //var file = FileRepository.Instance.GetFile(FileName, Extension, FileFolder);
            //if (!string.IsNullOrWhiteSpace(file?.Content))
            //{
            //    Content = file.Content;
            //}

        }
        public override SiocTemplate ParseModel()
        {
            if (Id == 0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            FileFolder = SWCmsHelper.GetFullPath(new string[]
                {
                    SWCmsConstants.Parameters.TemplatesFolder
                    , TemplateName
                    , FolderType
                });
            //if (FileName.IndexOf(Extension)==-1)
            //{
            //    FileName += Extension;
            //}
            Content = Content?.Trim();
            Scripts = Scripts?.Trim();
            Styles = Styles?.Trim();
            return base.ParseModel();
        }

        #endregion
        #region Async
        public override RepositoryResponse<bool> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                TemplateRepository.Instance.DeleteTemplate(FileName, FileFolder);
            }
            return result;
        }

        public override RepositoryResponse<bool> SaveSubModels(SiocTemplate parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            TemplateRepository.Instance.SaveTemplate(new TemplateViewModel()
            {
                Filename = FileName,
                Extension = Extension,
                Content = Content,
                FileFolder = FileFolder
            });
            return base.SaveSubModels(parent, _context, _transaction);
        }
        #endregion
        #region Async
        public override async Task<RepositoryResponse<bool>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                TemplateRepository.Instance.DeleteTemplate(FileName, FileFolder);
            }
            return result;
        }

        public override Task<RepositoryResponse<bool>> SaveSubModelsAsync(SiocTemplate parent, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            TemplateRepository.Instance.SaveTemplate(new TemplateViewModel()
            {
                Filename = FileName,
                Extension = Extension,
                Content = Content,
                FileFolder = FileFolder
            });
            return base.SaveSubModelsAsync(parent, _context, _transaction);
        }
        #endregion

        #endregion
        #region Expands

        /// <summary>
        /// Gets the template by path.
        /// </summary>
        /// <param name="path">The path.</param> Ex: "Pages/_Home"
        /// <returns></returns>
        public static RepositoryResponse<FETemplateViewModel> GetTemplateByPath(string path, string culture
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RepositoryResponse<FETemplateViewModel> result = new RepositoryResponse<FETemplateViewModel>();
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

    public class MobileComponent
    {
        public int Id { get; set; }
        public string ComponentType { get; set; }
        public string StyleName { get; set; }
        public string DataType { get; set; }
        public string DataValue { get; set; }
        public List<MobileComponent> DataSource { get; set; }
        
        public MobileComponent(XElement element)
        {
            if (element != null)
            {

                ComponentType = "View";
                StyleName = element.Attribute("class")?.Value;
                
                DataSource = new List<MobileComponent>();
                var subElements = element.Elements();
                if (subElements.Count()>0)
                {
                    DataType = "Component";
                    foreach (var subElement in subElements)
                    {
                        DataSource.Add(new MobileComponent(subElement));
                    }
                }
                else
                {
                    DataType = "Object";

                    DataValue = element.Value.Trim().Replace("Model.","").Replace("{{","").Replace("}}","");
                }

            }
        }
    }
}
