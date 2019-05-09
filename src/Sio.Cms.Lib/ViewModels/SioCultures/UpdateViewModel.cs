using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Services;
using Sio.Domain.Core.ViewModels;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib.ViewModels.SioCultures
{
    public class UpdateViewModel
      : ViewModelBase<SioCmsContext, SioCulture, UpdateViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("lcid")]
        public string Lcid { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("status")]
        public SioContentStatus Status { get; set; }
        #endregion Models

        #region Views

        [JsonProperty("configurations")]
        public List<SioConfigurations.ReadMvcViewModel> Configurations { get; set; }

        #endregion
        #endregion Properties

        #region Contructors

        public UpdateViewModel() : base()
        {
        }

        public UpdateViewModel(SioCulture model, SioCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides
        public override SioCulture ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                Id = Repository.Max(m => m.Id).Data + 1;
                CreatedDateTime = DateTime.UtcNow;
            }
            return base.ParseModel(_context, _transaction);
        }
        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getConfigurations = SioConfigurations.ReadMvcViewModel.Repository.GetModelListBy(c => c.Specificulture == Specificulture, _context, _transaction);
            if (getConfigurations.IsSucceed)
            {
                Configurations = getConfigurations.Data;
            }
        }
        #region Async
        public override async Task<RepositoryResponse<UpdateViewModel>> SaveModelAsync(bool isSaveSubModels = false, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                SioService.LoadFromDatabase();
                SioService.SaveSettings();
            }
            return result;
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SioCulture parent, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            var getPages = await SioPages.ReadViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
            if (getPages.IsSucceed)
            {
                foreach (var p in getPages.Data)
                {
                    p.Specificulture = Specificulture;
                    p.CreatedDateTime = DateTime.UtcNow;
                    p.LastModified = DateTime.UtcNow;
                    var saveResult = await p.SaveModelAsync(false, _context, _transaction);
                    result.IsSucceed = saveResult.IsSucceed;
                    if (!saveResult.IsSucceed)
                    {
                        result.Errors.Add("Error: Clone Pages");
                        result.Errors.AddRange(saveResult.Errors);
                        result.Exception = saveResult.Exception;
                        break;
                    }
                }
            }
            if (result.IsSucceed)
            {
                var getConfigurations = await SioConfigurations.ReadMvcViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getConfigurations.IsSucceed)
                {
                    foreach (var c in getConfigurations.Data)
                    {
                        c.Specificulture = Specificulture;
                        c.CreatedDateTime = DateTime.UtcNow;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Configurations");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }

            }
            if (result.IsSucceed)
            {
                var getLanguages = await SioLanguages.ReadMvcViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getLanguages.IsSucceed)
                {
                    foreach (var c in getLanguages.Data)
                    {
                        c.Specificulture = Specificulture;
                        c.CreatedDateTime = DateTime.UtcNow;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Languages");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }
            
            if (result.IsSucceed)
            {
                var getMedias = await SioMedias.UpdateViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getMedias.IsSucceed)
                {
                    foreach (var c in getMedias.Data)
                    {
                        c.Specificulture = Specificulture;
                        c.CreatedDateTime = DateTime.UtcNow;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Medias");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }
            if (result.IsSucceed)
            {
                // Clone Module from Default culture
                var getModules = await SioModules.ReadListItemViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getModules.IsSucceed)
                {
                    foreach (var c in getModules.Data)
                    {
                        c.Specificulture = Specificulture;
                        c.CreatedDateTime = DateTime.UtcNow;
                        c.LastModified = DateTime.UtcNow;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Module");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }

            // Clone ModuleData from Default culture
            if (result.IsSucceed)
            {
                var getModuleDatas = await SioModuleDatas.ReadViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getModuleDatas.IsSucceed)
                {
                    foreach (var c in getModuleDatas.Data)
                    {
                        c.Specificulture = Specificulture;
                        c.CreatedDateTime = DateTime.UtcNow;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Module Data");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }
            // Clone Article from Default culture
            if (result.IsSucceed)
            {
                var getArticles = await SioArticles.ReadListItemViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getArticles.IsSucceed)
                {
                    foreach (var c in getArticles.Data)
                    {
                        c.Specificulture = Specificulture;
                        c.CreatedDateTime = DateTime.UtcNow;
                        c.LastModified = DateTime.UtcNow;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Articles");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }
            if (result.IsSucceed)
            {
                // Clone PageModule from Default culture
                var getPageModules = await SioPageModules.ReadMvcViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getPageModules.IsSucceed)
                {
                    foreach (var c in getPageModules.Data)
                    {
                        c.Specificulture = Specificulture;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Page Module");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }

            if (result.IsSucceed)
            {
                // Clone PagePosition from Default culture
                var getPagePositions = await SioPagePositions.ReadListItemViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getPagePositions.IsSucceed)
                {
                    foreach (var c in getPagePositions.Data)
                    {
                        c.Specificulture = Specificulture;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Page Position");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }

            // Clone PageArticle from Default culture
            if (result.IsSucceed)
            {
                var getPageArticles = await SioPageArticles.ReadViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getPageArticles.IsSucceed)
                {
                    foreach (var c in getPageArticles.Data)
                    {
                        c.Specificulture = Specificulture;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Page Article");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }
            // Clone ModuleArticle from Default culture
            if (result.IsSucceed)
            {

                var getModuleArticles = await SioModuleArticles.ReadViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getModuleArticles.IsSucceed)
                {
                    foreach (var c in getModuleArticles.Data)
                    {
                        c.Specificulture = Specificulture;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Module Article");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }
            // Clone ArticleArticle from Default culture
            if (result.IsSucceed)
            {
                var getArticleArticles = await SioArticleArticles.ReadViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getArticleArticles.IsSucceed)
                {
                    foreach (var c in getArticleArticles.Data)
                    {
                        c.Specificulture = Specificulture;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Article Article");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }

            // Clone ArticleMedia from Default culture
            if (result.IsSucceed)
            {
                var getArticleMedias = await SioArticleMedias.ReadViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getArticleMedias.IsSucceed)
                {
                    foreach (var c in getArticleMedias.Data)
                    {
                        c.Specificulture = Specificulture;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Article Media");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }
            
            // Clone ArticleMedia from Default culture
            if (result.IsSucceed)
            {
                var getUrlAlias = await SioUrlAliases.UpdateViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getUrlAlias.IsSucceed)
                {
                    foreach (var c in getUrlAlias.Data)
                    {
                        c.Specificulture = Specificulture;
                        var saveResult = await c.SaveModelAsync(false, _context, _transaction);
                        result.IsSucceed = saveResult.IsSucceed;
                        if (!saveResult.IsSucceed)
                        {
                            result.Errors.Add("Error: Clone Article Media");
                            result.Errors.AddRange(saveResult.Errors);
                            result.Exception = saveResult.Exception;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(UpdateViewModel view, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };

            var configs = await _context.SioConfiguration.Where(c => c.Specificulture == Specificulture).ToListAsync();
            configs.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var languages = await _context.SioLanguage.Where(l => l.Specificulture == Specificulture).ToListAsync();
            languages.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var PageModules = await _context.SioPageModule.Where(l => l.Specificulture == Specificulture).ToListAsync();
            PageModules.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var PagePositions = await _context.SioPagePosition.Where(l => l.Specificulture == Specificulture).ToListAsync();
            PagePositions.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var PageArticles = await _context.SioPageArticle.Where(l => l.Specificulture == Specificulture).ToListAsync();
            PageArticles.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var ModuleArticles = await _context.SioModuleArticle.Where(l => l.Specificulture == Specificulture).ToListAsync();
            ModuleArticles.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var ArticleMedias = await _context.SioArticleMedia.Where(l => l.Specificulture == Specificulture).ToListAsync();
            ArticleMedias.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var ModuleDatas = await _context.SioModuleData.Where(l => l.Specificulture == Specificulture).ToListAsync();
            ModuleDatas.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var ArticleArticles = await _context.SioRelatedArticle.Where(l => l.Specificulture == Specificulture).ToListAsync();
            ArticleArticles.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var medias = await _context.SioMedia.Where(c => c.Specificulture == Specificulture).ToListAsync();
            medias.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);
            
            var cates = await _context.SioPage.Where(c => c.Specificulture == Specificulture).ToListAsync();
            cates.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var modules = await _context.SioModule.Where(c => c.Specificulture == Specificulture).ToListAsync();
            modules.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var articles = await _context.SioArticle.Where(c => c.Specificulture == Specificulture).ToListAsync();
            articles.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var products = await _context.SioProduct.Where(c => c.Specificulture == Specificulture).ToListAsync();
            products.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var aliases = await _context.SioUrlAlias.Where(c => c.Specificulture == Specificulture).ToListAsync();
            aliases.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            result.IsSucceed = (await _context.SaveChangesAsync() > 0);
            return result;
        }

        public override async Task<RepositoryResponse<SioCulture>> RemoveModelAsync(bool isRemoveRelatedModels = false, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                if (result.IsSucceed)
                {
                    SioService.LoadFromDatabase();
                    SioService.SaveSettings();
                }
            }
            return result;
        }

        #endregion

        #endregion Overrides
    }
}
