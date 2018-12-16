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

                        isSucceed = isSucceed && InitPositions(context, transaction);

                        isSucceed = isSucceed && await InitConfigurationsAsync(siteName, culture, context, transaction);
                        isSucceed = isSucceed && await InitLanguagesAsync(culture, context, transaction);

                        isSucceed = isSucceed && InitThemes(context, transaction);

                        
                    }
                    else
                    {
                        isSucceed = true;
                    }

                    if (isSucceed && context.SioPage.Count()==0)
                    {
                        var cate = new SioPage()
                        {
                            Id = 1,
                            Level = 0,
                            Title = "Home",
                            Specificulture = culture.Specificulture,
                            Template = "Pages/_Home.cshtml",
                            Type = (int)SioPageType.Home,
                            CreatedBy = "Admin",
                            CreatedDateTime = DateTime.UtcNow,
                            Status = (int)PageStatus.Published
                        };


                        context.Entry(cate).State = EntityState.Added;
                        var alias = new SioUrlAlias()
                        {
                            Id = 1,
                            SourceId = "1",
                            Type = (int)UrlAliasType.Page,
                            Specificulture = culture.Specificulture,
                            CreatedDateTime = DateTime.UtcNow,
                            Alias = cate.Title.ToLower()
                        };
                        context.Entry(alias).State = EntityState.Added;

                        var createVNHome = await context.SaveChangesAsync().ConfigureAwait(false);
                        isSucceed = createVNHome > 0;

                        var cate404 = new SioPage()
                        {
                            Id = 2,
                            Title = "404",
                            Level = 0,
                            Specificulture = culture.Specificulture,
                            Template = "Pages/_404.cshtml",
                            Type = (int)SioPageType.Article,
                            CreatedBy = "Admin",
                            CreatedDateTime = DateTime.UtcNow,
                            Status = (int)PageStatus.Published
                        };

                        var alias404 = new SioUrlAlias()
                        {
                            Id = 2,
                            SourceId = "2",
                            Type = (int)UrlAliasType.Page,
                            Specificulture = culture.Specificulture,
                            CreatedDateTime = DateTime.UtcNow,
                            Alias = cate404.Title.ToLower()
                        };
                        context.Entry(cate404).State = EntityState.Added;
                        context.Entry(alias404).State = EntityState.Added;

                        var create404 = await context.SaveChangesAsync().ConfigureAwait(false);
                        isSucceed = create404 > 0;
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
            }
            var result = await ViewModels.SioConfigurations.ReadMvcViewModel.ImportConfigurations(arrConfiguration, culture.Specificulture,  context, transaction);
            return result.IsSucceed;

        }

        private async Task<bool> InitLanguagesAsync(InitCulture culture, SioCmsContext context, IDbContextTransaction transaction)
        {
            /* Init Languages */
            var configurations = FileRepository.Instance.GetFile(SioConstants.CONST_FILE_LANGUAGES, "data", true, "{}");
            var obj = JObject.Parse(configurations.Content);
            var arrLanguage = obj["data"].ToObject<List<SioLanguage>>();
            var result = await ViewModels.SioLanguages.ReadMvcViewModel.ImportLanguages(arrLanguage, culture.Specificulture,  context, transaction);
            return result.IsSucceed;

        }

        private bool InitThemes(SioCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            var getThemes = ViewModels.SioThemes.UpdateViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
            if (!context.SioTheme.Any())
            {
                ViewModels.SioThemes.UpdateViewModel theme = new ViewModels.SioThemes.UpdateViewModel(new SioTheme()
                {
                    Name = "Default",
                    CreatedBy = "Admin",
                    Status = (int)SioContentStatus.Published
                }, context, transaction);

                isSucceed = isSucceed && theme.SaveModel(true, context, transaction).IsSucceed;
            }

            return isSucceed;
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
                        Specificulture = culture.Specificulture,
                        FullName = culture.FullName,
                        Description = culture.Description,
                        Icon = culture.Icon,
                        Alias = culture.Alias,
                        Status = (int)SioEnums.SioContentStatus.Published
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
                    Description = nameof(SioEnums.CatePosition.Nav)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SioPosition()
                {
                    Description = nameof(SioEnums.CatePosition.Top)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SioPosition()
                {
                    Description = nameof(SioEnums.CatePosition.Left)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SioPosition()
                {
                    Description = nameof(SioEnums.CatePosition.Footer)
                };
                context.Entry(p).State = EntityState.Added;

                context.SaveChanges();
            }
            return isSucceed;
        }

    }
}
