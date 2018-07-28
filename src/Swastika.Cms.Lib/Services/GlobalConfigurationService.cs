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
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.Services
{
    public class GlobalConfigurationService
    {
        private static GlobalConfigurationService _instance;

        public static GlobalConfigurationService Instance
        {
            get
            {
                return _instance ?? (_instance = new GlobalConfigurationService());
            }
            set
            {
                _instance = value;
            }
        }

        public GlobalConfigurationService()
        {

        }
        public CmsCultureConfiguration CmsCulture { get; set; }
        public CmsConfiguration CmsConfigurations { get; set; }

        public async Task<RepositoryResponse<bool>> InitSWCms(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
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
                        isSucceed = InitCultures(context, transaction);

                        isSucceed = isSucceed && InitPositions(context, transaction);

                        isSucceed = isSucceed && InitThemes(context, transaction);

                        isSucceed = isSucceed && InitConfigurations(context, transaction);
                    }
                    else
                    {
                        isSucceed = true;
                    }

                    if (isSucceed && BECategoryViewModel.Repository.Count(context, transaction).Data == 0)
                    {

                        BECategoryViewModel cate = new BECategoryViewModel(new SiocCategory()
                        {
                            Title = "Home",
                            Specificulture = "vi-vn",
                            Template = "_Home",
                            Type = (int)SWCmsConstants.CateType.Home,
                            CreatedBy = "Admin"
                        }, context, transaction);

                        var createVNHome = await cate.SaveModelAsync(false, context, transaction).ConfigureAwait(false);
                        isSucceed = createVNHome.IsSucceed;
                        
                        BECategoryViewModel uscate = new BECategoryViewModel(new SiocCategory()
                        {
                            Id = cate.Model.Id,
                            Title = "Home",
                            Specificulture = "en-us",
                            Template = "_Home",
                            Type = (int)SWCmsConstants.CateType.Home,
                            CreatedBy = "Admin",
                            CreatedDateTime = DateTime.UtcNow,
                        }, context, transaction);

                        var createUSHome = await uscate.SaveModelAsync(false, context, transaction).ConfigureAwait(false);
                        isSucceed = createUSHome.IsSucceed;

                    }

                    if (isSucceed)
                    {
                        GlobalConfigurationService.Instance.RefreshAll(context, transaction);

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

        private bool InitConfigurations(SiocCmsContext context, IDbContextTransaction transaction)
        {
            /* Init Configs */
            bool isSucceed = true;
            var count = context.SiocConfiguration.Count(); //ConfigurationViewModel.Repository.Count(_context: context, _transaction: transaction).Data;
            if (count == 0)
            {
                var config = new SiocConfiguration()
                {
                    Keyword = SWCmsConstants.ConfigurationKeyword.Theme,
                    Specificulture = "vi-vn",
                    Category = SWCmsConstants.ConfigurationType.User,
                    DataType = (int)SWCmsConstants.DataType.String,
                    Description = "Cms Theme",

                    Value = "Default"
                };
                context.Entry(config).State = EntityState.Added;

                var config1 = new SiocConfiguration()
                {
                    Keyword = SWCmsConstants.ConfigurationKeyword.ThemeId,
                    Specificulture = "vi-vn",
                    Category = SWCmsConstants.ConfigurationType.User,
                    DataType = (int)SWCmsConstants.DataType.String,
                    Description = "Cms Theme",

                    Value = "1"
                };
                context.Entry(config1).State = EntityState.Added;

                var config2 = new SiocConfiguration()
                {
                    Keyword = SWCmsConstants.ConfigurationKeyword.Theme,
                    Specificulture = "en-us",
                    Category = SWCmsConstants.ConfigurationType.User,
                    DataType = (int)SWCmsConstants.DataType.String,
                    Description = "Cms Theme",

                    Value = "Default"
                };

                context.Entry(config2).State = EntityState.Added;


                var config3 = new SiocConfiguration()
                {
                    Keyword = SWCmsConstants.ConfigurationKeyword.ThemeId,
                    Specificulture = "en-us",
                    Category = SWCmsConstants.ConfigurationType.User,
                    DataType = (int)SWCmsConstants.DataType.String,
                    Description = "Cms Theme",

                    Value = "1"
                };
                context.Entry(config3).State = EntityState.Added;
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
                //if (getThemes.Data.Count == 0)
                //{
                    BEThemeViewModel theme = new BEThemeViewModel(new SiocTheme()
                    {
                        Name = "Default",

                        CreatedBy = "Admin"
                    }, context, transaction);

                    isSucceed = isSucceed && theme.SaveModel(true, context, transaction).IsSucceed;
                //}
                //else
                //{
                //    foreach (var theme in getThemes.Data)
                //    {
                //        string folderPath = CommonHelper.GetFullPath(new string[]
                //        {
                //            SWCmsConstants.Parameters.TemplatesFolder,
                //            theme.Name
                //        });

                //        FileRepository.Instance.DeleteFolder(folderPath);

                //        foreach (var item in theme.Templates)
                //        {
                //            isSucceed = isSucceed && item.SaveModel(true, _context: context, _transaction: transaction).IsSucceed;
                //        }
                //    }
                //}
            }

            return isSucceed;
        }

        protected bool InitCultures(SiocCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            try
            {
                if (context.SiocCulture.Count() == 0)
                {

                    // EN-US

                    var enCulture = new SiocCulture()
                    {
                        Specificulture = "en-us",
                        FullName = "United States",
                        Description = "United States",
                        Icon = "flag-icon-us",
                        Alias = "US"
                    };
                    context.Entry(enCulture).State = EntityState.Added;

                    var vnCulture = new SiocCulture()
                    {
                        Specificulture = "vi-vn",
                        FullName = "Vietnam",
                        Description = "Việt Nam",
                        Icon = "flag-icon-vn",
                        Alias = "VN"
                    };
                    context.Entry(vnCulture).State = EntityState.Added;

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