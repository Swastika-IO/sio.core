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
            if (Id==0)
            {
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
                SioService.Save();
            }
            return result;
        }

        public override async Task<RepositoryResponse<bool>> SaveSubModelsAsync(SioCulture parent, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };
            if (Id == 0)
            {
                var getPages = await SioPages.ReadViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getPages.IsSucceed)
                {
                    foreach (var p in getPages.Data)
                    {
                        var page = new SioPage()
                        {
                            Specificulture = Specificulture,
                            Id = p.Id,
                            Content = p.Content,
                            CreatedBy = p.CreatedBy,
                            CreatedDateTime = DateTime.UtcNow,
                            Layout = p.Layout,
                            CssClass = p.CssClass,
                            Excerpt = p.Excerpt,
                            Icon = p.Icon,
                            Image = p.Image,
                            Level = p.Level,
                            ModifiedBy = p.ModifiedBy,
                            PageSize = p.PageSize,
                            Priority = p.Priority,
                            SeoDescription = p.SeoDescription,
                            SeoKeywords = p.SeoKeywords,
                            SeoName = p.SeoName,
                            SeoTitle = p.SeoTitle,
                            StaticUrl = p.StaticUrl,
                            Status = (int)p.Status,
                            Tags = p.Tags,
                            Template = p.Template,
                            Title = p.Title,
                            Type = (int)p.Type,
                        };
                        _context.Entry(page).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }
                var getConfigurations = await SioConfigurations.ReadMvcViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getConfigurations.IsSucceed)
                {
                    foreach (var c in getConfigurations.Data)
                    {
                        var cnf = new SioConfiguration()
                        {
                            Keyword = c.Keyword,
                            Specificulture = Specificulture,
                            Category = c.Category,
                            DataType = (int)c.DataType,
                            Description = c.Description,
                            Priority = c.Priority,
                            Status = (int)c.Status,
                            Value = c.Value
                        };
                        _context.Entry(cnf).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }

                var getLanguages = await SioLanguages.ReadMvcViewModel.Repository.GetModelListByAsync(c => c.Specificulture == SioService.GetConfig<string>(SioConstants.ConfigurationKeyword.DefaultCulture), _context, _transaction);
                if (getLanguages.IsSucceed)
                {
                    foreach (var c in getLanguages.Data)
                    {
                        var cnf = new SioLanguage()
                        {
                            Keyword = c.Keyword,
                            Specificulture = Specificulture,
                            Category = c.Category,
                            DataType = (int)c.DataType,
                            Description = c.Description,
                            Priority = c.Priority,
                            Status = (int)c.Status,
                            DefaultValue = c.DefaultValue
                        };
                        _context.Entry(cnf).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }
                _context.SaveChanges();
            }
            return result;
        }

        public override async Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(UpdateViewModel view, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true };

            var configs = _context.SioConfiguration.Where(c => c.Specificulture == Specificulture).ToList();
            configs.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var languages = _context.SioLanguage.Where(l => l.Specificulture == Specificulture).ToList();
            languages.ForEach(l => _context.Entry(l).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var cates = _context.SioPage.Where(c => c.Specificulture == Specificulture).ToList();
            cates.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var modules = _context.SioModule.Where(c => c.Specificulture == Specificulture).ToList();
            modules.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var articles = _context.SioArticle.Where(c => c.Specificulture == Specificulture).ToList();
            articles.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            var products = _context.SioProduct.Where(c => c.Specificulture == Specificulture).ToList();
            products.ForEach(c => _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted);

            await _context.SaveChangesAsync();

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
                    SioService.Save();
                }
            }
            return result;
        }

        #endregion

        #endregion Overrides
    }
}
