using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sio.Domain.Core.ViewModels;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.ViewModels;
using Sio.Cms.Lib.Models.Account;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Sio.Cms.Lib.SioEnums;
using Sio.Cms.Lib.Repositories;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Sio.Cms.Messenger.Models.Data;
using Sio.Common.Helper;

namespace Sio.Cms.Lib.Services
{
    public class InitCmsService
    {
        public InitCmsService()
        {
        }

        public async Task<RepositoryResponse<bool>> InitCms(string siteName, InitCulture culture)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>();
            SioCmsContext context = null;
            SioCmsAccountContext accountContext = null;
            SioChatServiceContext messengerContext;
            IDbContextTransaction transaction = null;
            IDbContextTransaction accTransaction = null;
            bool isSucceed = true;
            try
            {
                if (!string.IsNullOrEmpty(SioService.GetConnectionString(SioConstants.CONST_CMS_CONNECTION)))
                {
                    context = new SioCmsContext();
                    accountContext = new SioCmsAccountContext();
                    messengerContext = new SioChatServiceContext();
                    //SioChatServiceContext._cnn = SioService.GetConnectionString(SioConstants.CONST_CMS_CONNECTION);
                    await context.Database.MigrateAsync();
                    await accountContext.Database.MigrateAsync();
                    await messengerContext.Database.MigrateAsync();
                    transaction = context.Database.BeginTransaction();

                    var countCulture = context.SioCulture.Count();

                    var isInit = countCulture > 0;

                    if (!isInit)
                    {
                        SioService.SetConfig<string>("SiteName", siteName);
                        isSucceed = InitCultures(culture, context, transaction);
                        if (isSucceed)
                        {
                            isSucceed = isSucceed && InitPositions(context, transaction);
                        }
                        else
                        {
                            result.Errors.Add("Cannot init Cultures");
                        }
                        if (isSucceed)
                        {
                            isSucceed = isSucceed && await InitConfigurationsAsync(siteName, culture, context, transaction);
                        }
                        else
                        {
                            result.Errors.Add("Cannot init Positions");
                        }
                        if (isSucceed)
                        {
                            isSucceed = isSucceed && await InitLanguagesAsync(culture, context, transaction);
                        }
                        else
                        {
                            result.Errors.Add("Cannot init Configurations");
                        }
                        if (isSucceed)
                        {
                            var initTheme = await InitThemesAsync(siteName, context, transaction);
                            isSucceed = isSucceed && initTheme.IsSucceed;
                            result.Errors.AddRange(initTheme.Errors);
                            result.Exception = initTheme.Exception;
                        }
                        else
                        {                            
                            result.Errors.Add("Cannot init Languages");
                        }
                    }
                    else
                    {
                        isSucceed = true;
                    }

                    if (isSucceed && context.SioPage.Count() == 0)
                    {
                        InitPages(culture.Specificulture, context, transaction);
                        isSucceed = (await context.SaveChangesAsync().ConfigureAwait(false)) > 0;
                    }
                    else
                    {
                        result.Errors.Add("Cannot init Themes");
                    }
                    if (isSucceed)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                result.IsSucceed = isSucceed;
                return result;
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                transaction?.Rollback();
                accTransaction?.Rollback();
                result.IsSucceed = false;
                result.Exception = ex;
                return result;
            }
            finally
            {
                context?.Dispose();
                accountContext?.Dispose();
            }
        }


        private async Task<bool> InitConfigurationsAsync(string siteName, InitCulture culture, SioCmsContext context, IDbContextTransaction transaction)
        {
            /* Init Configs */
            var configurations = FileRepository.Instance.GetFile(SioConstants.CONST_FILE_CONFIGURATIONS, "data", true, "{}");
            var obj = JObject.Parse(configurations.Content);
            var arrConfiguration = obj["data"].ToObject<List<SioConfiguration>>();
            if (!string.IsNullOrEmpty(siteName))
            {
                arrConfiguration.Find(c => c.Keyword == "SiteName").Value = siteName;
                arrConfiguration.Find(c => c.Keyword == "ThemeName").Value = Common.Helper.SeoHelper.GetSEOString(siteName);
                arrConfiguration.Find(c => c.Keyword == "ThemeFolder").Value = Common.Helper.SeoHelper.GetSEOString(siteName);
            }
            var result = await ViewModels.SioConfigurations.ReadMvcViewModel.ImportConfigurations(arrConfiguration, culture.Specificulture, context, transaction);
            return result.IsSucceed;

        }

        private async Task<bool> InitLanguagesAsync(InitCulture culture, SioCmsContext context, IDbContextTransaction transaction)
        {
            /* Init Languages */
            var configurations = FileRepository.Instance.GetFile(SioConstants.CONST_FILE_LANGUAGES, "data", true, "{}");
            var obj = JObject.Parse(configurations.Content);
            var arrLanguage = obj["data"].ToObject<List<SioLanguage>>();
            var result = await ViewModels.SioLanguages.ReadMvcViewModel.ImportLanguages(arrLanguage, culture.Specificulture, context, transaction);
            return result.IsSucceed;

        }

        private async Task<RepositoryResponse<ViewModels.SioThemes.InitViewModel>> InitThemesAsync(string siteName, SioCmsContext context, IDbContextTransaction transaction)
        {
            var getThemes = ViewModels.SioThemes.InitViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
            if (!context.SioTheme.Any())
            {
                ViewModels.SioThemes.InitViewModel theme = new ViewModels.SioThemes.InitViewModel(new SioTheme()
                {
                    Id = 1,
                    Title = siteName,
                    Name = SeoHelper.GetSEOString(siteName),
                    CreatedDateTime = DateTime.UtcNow,
                    CreatedBy = "Admin",
                    Status = (int)SioContentStatus.Published,
                }, context, transaction);

                return await theme.SaveModelAsync(true, context, transaction);
            }

            return new RepositoryResponse<ViewModels.SioThemes.InitViewModel>() { IsSucceed = true };
        }

        protected bool InitCultures(InitCulture culture, SioCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            try
            {
                if (context.SioCulture.Count() == 0)
                {

                    // EN-US

                    var enCulture = new SioCulture()
                    {
                        Id = 1,
                        Specificulture = culture.Specificulture,
                        FullName = culture.FullName,
                        Description = culture.Description,
                        Icon = culture.Icon,
                        Alias = culture.Alias,
                        Status = (int)SioEnums.SioContentStatus.Published,
                        CreatedDateTime = DateTime.UtcNow
                    };
                    context.Entry(enCulture).State = EntityState.Added;

                    context.SaveChanges();
                }
            }
            catch
            {
                isSucceed = false;
            }
            return isSucceed;
        }

        protected bool InitPositions(SioCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            var count = context.SioPortalPage.Count();
            if (count == 0)
            {
                var p = new SioPosition()
                {
                    Id = 1,
                    Description = nameof(SioEnums.CatePosition.Nav)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SioPosition()
                {
                    Id = 2,
                    Description = nameof(SioEnums.CatePosition.Top)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SioPosition()
                {
                    Id = 3,
                    Description = nameof(SioEnums.CatePosition.Left)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SioPosition()
                {
                    Id = 4,
                    Description = nameof(SioEnums.CatePosition.Footer)
                };
                context.Entry(p).State = EntityState.Added;

                context.SaveChanges();
            }
            return isSucceed;
        }

        protected void InitPages(string culture, SioCmsContext context, IDbContextTransaction transaction)
        {
            /* Init Languages */
            var pages = FileRepository.Instance.GetFile(SioConstants.CONST_FILE_PAGES, "data", true, "{}");
            var obj = JObject.Parse(pages.Content);
            var arrPage = obj["data"].ToObject<List<SioPage>>();
            foreach (var page in arrPage)
            {
                page.Specificulture = culture;
                page.SeoTitle = page.Title.ToLower();
                page.SeoName = SeoHelper.GetSEOString(page.Title);
                page.SeoDescription = page.Title.ToLower();
                page.SeoKeywords = page.Title.ToLower();
                page.CreatedDateTime = DateTime.UtcNow;
                page.CreatedBy = "SuperAdmin";
                context.Entry(page).State = EntityState.Added;
                var alias = new SioUrlAlias()
                {
                    Id = page.Id,
                    SourceId = page.Id.ToString(),
                    Type = (int)UrlAliasType.Page,
                    Specificulture = culture,
                    CreatedDateTime = DateTime.UtcNow,
                    Alias = page.Title.ToLower(),
                    Status = (int)SioContentStatus.Published
                };
                context.Entry(alias).State = EntityState.Added;
            }
        }
    }
}
