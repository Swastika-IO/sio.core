// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Swastika.Cms.Lib.Models.Account;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastika.Cms.Lib.Services
{
    public class GlobalConfigurationService
    {
        public CmsCultureConfiguration CmsCulture { get; set; }
        public CmsConfiguration CmsConfigurations { get; set; }

        public static GlobalConfigurationService Instance { get; }
        static GlobalConfigurationService()
        {
            Instance = new GlobalConfigurationService();
            Instance.RefreshAll();
        }

        public GlobalConfigurationService()
        {

        }

        public string Translate(string culture, string key)
        {
            return Instance.CmsCulture.Translator[culture][key]?.ToString() ?? key;
        }

        public async Task<RepositoryResponse<bool>> InitSWCms(InitCulture culture)
        {
            RepositoryResponse<bool> result = new RepositoryResponse<bool>();
            SiocCmsContext context = null;
            SiocCmsAccountContext accountContext = null;
            IDbContextTransaction transaction = null;
            IDbContextTransaction accTransaction = null;
            bool isSucceed = true;
            try
            {
                if (!string.IsNullOrEmpty(CmsConfigurations.CmsConnectionString))
                {
                    context = new SiocCmsContext();
                    accountContext = new SiocCmsAccountContext();
                    await context.Database.MigrateAsync();
                    await accountContext.Database.MigrateAsync();
                    transaction = context.Database.BeginTransaction();

                    var countCulture = context.SiocCulture.Count();

                    var isInit = countCulture > 0;

                    if (!isInit)
                    {
                        isSucceed = InitCultures(culture, context, transaction);

                        isSucceed = isSucceed && InitPositions(context, transaction);

                        isSucceed = isSucceed && InitThemes(context, transaction);

                        isSucceed = isSucceed && InitConfigurations(culture, context, transaction);
                    }
                    else
                    {
                        isSucceed = true;
                    }

                    if (isSucceed && BECategoryViewModel.Repository.Count(context, transaction).Data == 0)
                    {
                        var cate = new SiocCategory()
                        {
                            Id = 1,
                            Level = 0,
                            Title = "Home",
                            Specificulture = culture.Specificulture,
                            Template = "Pages/_Home.cshtml",
                            Type = (int)SWCmsConstants.CateType.Home,
                            CreatedBy = "Admin",
                            CreatedDateTime = DateTime.UtcNow,
                            Status = (int)SWStatus.Published
                        };


                        context.Entry(cate).State = EntityState.Added;
                        var alias = new SiocUrlAlias()
                        {
                            Id = 1,
                            SourceId = "1",
                            Type = (int)SWCmsConstants.UrlAliasType.Page,
                            Specificulture = culture.Specificulture,
                            CreatedDateTime = DateTime.UtcNow,
                            Alias = cate.Title.ToLower()
                        };
                        context.Entry(alias).State = EntityState.Added;

                        var createVNHome = await context.SaveChangesAsync().ConfigureAwait(false);
                        isSucceed = createVNHome > 0;

                        var cate404 = new SiocCategory()
                        {
                            Id = 2,
                            Title = "404",
                            Level = 0,
                            Specificulture = culture.Specificulture,
                            Template = "Pages/_404.cshtml",
                            Type = (int)SWCmsConstants.CateType.Article,
                            CreatedBy = "Admin",
                            CreatedDateTime = DateTime.UtcNow,
                            Status = (int)SWStatus.Published
                        };

                        var alias404 = new SiocUrlAlias()
                        {
                            Id = 2,
                            SourceId = "2",
                            Type = (int)SWCmsConstants.UrlAliasType.Page,
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

        private async Task<bool> InitUsersAsync(SiocCmsAccountContext context, IDbContextTransaction transaction, UserManager<ApplicationUser> userManager)
        {
            bool isSucceed = true;
            var getUsers = await UserViewModel.Repository.GetModelListAsync(context, transaction);
            if (getUsers.IsSucceed && getUsers.Data.Count == 0)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Admin",
                    Email = "admin@swastika.com",
                };

                var saveResult = await userManager.CreateAsync(user, "123123");
                await userManager.AddToRoleAsync(user, "SuperAdmin");
                isSucceed = saveResult.Succeeded;
            }
            return isSucceed;
        }

        private bool InitConfigurations(InitCulture culture, SiocCmsContext context, IDbContextTransaction transaction)
        {
            /* Init Configs */
            bool isSucceed = true;
            var count = context.SiocConfiguration.Count(); //ConfigurationViewModel.Repository.Count(_context: context, _transaction: transaction).Data;
            if (count == 0)
            {
                var config = new SiocConfiguration()
                {
                    Keyword = SWCmsConstants.ConfigurationKeyword.Theme,
                    Specificulture = culture.Specificulture,
                    Category = SWCmsConstants.ConfigurationType.User,
                    DataType = (int)SWCmsConstants.DataType.String,
                    Description = "Cms Theme",

                    Value = "Default"
                };
                context.Entry(config).State = EntityState.Added;

                var config1 = new SiocConfiguration()
                {
                    Keyword = SWCmsConstants.ConfigurationKeyword.ThemeId,
                    Specificulture = culture.Specificulture,
                    Category = SWCmsConstants.ConfigurationType.User,
                    DataType = (int)SWCmsConstants.DataType.String,
                    Description = "Cms Theme",

                    Value = "1"
                };
                context.Entry(config1).State = EntityState.Added;

                context.SaveChanges();
                GlobalConfigurationService.Instance.RefreshConfigurations(context, transaction);
            }


            return isSucceed;

        }

        private bool InitThemes(SiocCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            var getThemes = BEThemeViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
            if (getThemes.IsSucceed && getThemes.Data.Count == 0)
            {

                BEThemeViewModel theme = new BEThemeViewModel(new SiocTheme()
                {
                    Name = "Default",

                    CreatedBy = "Admin"
                }, context, transaction);

                isSucceed = isSucceed && theme.SaveModel(true, context, transaction).IsSucceed;

            }

            return isSucceed;
        }

        protected bool InitCultures(InitCulture culture, SiocCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            try
            {
                if (context.SiocCulture.Count() == 0)
                {

                    // EN-US

                    var enCulture = new SiocCulture()
                    {
                        Specificulture = culture.Specificulture,
                        FullName = culture.FullName,
                        Description = culture.Description,
                        Icon = culture.Icon,
                        Alias = culture.Alias
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

        protected bool InitPositions(SiocCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            var count = context.SiocPortalPage.Count();
            if (count == 0)
            {
                var p = new SiocPosition()
                {
                    Description = nameof(SWCmsConstants.CatePosition.Nav)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SiocPosition()
                {
                    Description = nameof(SWCmsConstants.CatePosition.Top)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SiocPosition()
                {
                    Description = nameof(SWCmsConstants.CatePosition.Left)
                };
                context.Entry(p).State = EntityState.Added;
                p = new SiocPosition()
                {
                    Description = nameof(SWCmsConstants.CatePosition.Footer)
                };
                context.Entry(p).State = EntityState.Added;

                context.SaveChanges();
            }
            return isSucceed;
        }

        public void RefreshAll(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            RefreshConfigurations(_context, _transaction);
            RefreshCultures(_context, _transaction);
        }

        public void RefreshConfigurations(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.CmsConfigurations = new CmsConfiguration();
            if (!string.IsNullOrEmpty(CmsConfigurations.CmsConnectionString))
            {
                CmsConfigurations.Init(_context, _transaction);
            }
        }

        public void RefreshCultures(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            this.CmsCulture = new CmsCultureConfiguration();
            if (!string.IsNullOrEmpty(CmsConfigurations.CmsConnectionString))
            {
                CmsCulture.Init(_context, _transaction);
            }
        }

        public string GetLocalString(string key, string culture, string defaultValue = null)
        {
            return this.CmsConfigurations.GetLocalString(key, culture, defaultValue);
        }

        public int GetLocalInt(string key, string culture, int defaultValue = 0)
        {
            return this.CmsConfigurations.GetLocalInt(key, culture, defaultValue);
        }

    }
}