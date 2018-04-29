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
        private static string _connectionString;
        public string Culture { get; set; }
        public string Name { get; set; }
        public bool IsInit { get; set; }

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        private static List<ConfigurationViewModel> _listConfiguration;

        public static List<ConfigurationViewModel> ListConfiguration
        {
            get
            {
                if (_listConfiguration == null)
                {
                    InitConfigurations();
                }
                return _listConfiguration;
            }
            set
            {
                _listConfiguration = value;
            }
        }

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

        public string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                return ConnectionString;
            }
            else
            {
                InitConnectionString();
                return ConnectionString;
            }
        }

        public bool InitConnectionString()
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(ConnectionString))
                    {
                        ConnectionString = GetConfigConnectionKey();
                        return !string.IsNullOrEmpty(ConnectionString);
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public string GetConfigConnectionKey()
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(System.IO.Directory.GetCurrentDirectory())
               .AddJsonFile(Common.Utility.Const.CONST_FILE_APPSETTING)
               .Build();
            return configuration.GetConnectionString(SWCmsConstants.CONST_DEFAULT_CONNECTION);
        }

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
                if (InitConnectionString())
                {
                    context = new SiocCmsContext();
                    accountContext = new SiocCmsAccountContext();
                    await context.Database.MigrateAsync();
                    await accountContext.Database.MigrateAsync();
                    transaction = context.Database.BeginTransaction();
                    accTransaction = accountContext.Database.BeginTransaction();
                    var getCulture = await BECultureViewModel.Repository.GetModelListAsync();

                    var isInit = getCulture.IsSucceed && getCulture.Data.Count > 0;

                    if (!isInit)
                    {

                        isSucceed = InitCultures(context, transaction);

                        isSucceed = isSucceed && InitPositions(context, transaction);

                        isSucceed = isSucceed && InitThemes(context, transaction);

                    }
                    else
                    {
                        isSucceed = true;
                    }

                    if (isSucceed)
                    {
                        BECategoryViewModel cate = new BECategoryViewModel(new SiocCategory()
                        {
                            Title = "Home",
                            Specificulture = "vi-vn",
                            Template = "_Home",
                            Type = (int)SWCmsConstants.CateType.Home,
                            CreatedBy = "Admin"

                        });

                        isSucceed = cate.SaveModel(false, context, transaction).IsSucceed;
                        BECategoryViewModel uscate = new BECategoryViewModel(new SiocCategory()
                        {
                            Title = "Home",
                            Specificulture = "en-us",
                            Template = "_Home",
                            Type = (int)SWCmsConstants.CateType.Home,
                            CreatedBy = "Admin"
                        });
                        isSucceed = isSucceed && uscate.SaveModel(false, context, transaction).IsSucceed;
                    }


                    if (isSucceed)
                    {

                        GlobalLanguageService.Instance.RefreshCultures(context, transaction);

                        transaction.Commit();
                        accTransaction.Commit();
                        IsInit = true;
                    }
                    else
                    {
                        transaction.Rollback();
                        accTransaction.Rollback();
                        IsInit = false;
                    }

                }
                result.IsSucceed = isSucceed;
                return result;
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                IsInit = false;
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

        private bool InitThemes(SiocCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            var getThemes = BEThemeViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
            if (getThemes.IsSucceed && getThemes.Data.Count == 0)
            {
                if (getThemes.Data.Count == 0)
                {
                    BEThemeViewModel theme = new BEThemeViewModel(new SiocTheme()
                    {
                        Name = "Default",

                        CreatedBy = "Admin"
                    })
                    {
                        IsActived = true,
                        Specificulture = "vi-vn"
                    };

                    isSucceed = isSucceed && theme.SaveModel(true, context, transaction).IsSucceed;

                    if (isSucceed)
                    {
                        ConfigurationViewModel config = (ConfigurationViewModel.Repository.GetSingleModel(
                c => c.Keyword == SWCmsConstants.ConfigurationKeyword.Theme && c.Specificulture == "vi-vn", context, transaction)).Data;
                        if (config == null)
                        {
                            config = new ConfigurationViewModel()
                            {
                                Keyword = SWCmsConstants.ConfigurationKeyword.Theme,
                                Specificulture = "vi-vn",
                                Category = SWCmsConstants.ConfigurationType.User,
                                DataType = SWCmsConstants.DataType.String,
                                Description = "Cms Theme",

                                Value = ""
                            };
                        }
                        else
                        {
                            config.Value = theme.Name;
                        }
                        isSucceed = isSucceed && config.SaveModel(false, context, transaction).IsSucceed;
                    }

                    if (isSucceed)
                    {
                        ConfigurationViewModel config = (ConfigurationViewModel.Repository.GetSingleModel(
                c => c.Keyword == SWCmsConstants.ConfigurationKeyword.ThemeId && c.Specificulture == "vi-vn", context, transaction)).Data;
                        if (config == null)
                        {
                            config = new ConfigurationViewModel()
                            {
                                Keyword = SWCmsConstants.ConfigurationKeyword.Theme,
                                Specificulture = "vi-vn",
                                Category = SWCmsConstants.ConfigurationType.User,
                                DataType = SWCmsConstants.DataType.String,
                                Description = "Cms Theme",

                                Value = theme.Model.Id.ToString()
                            };
                        }
                        else
                        {
                            config.Value = theme.Model.Id.ToString();
                        }
                        isSucceed = isSucceed && config.SaveModel(false, context, transaction).IsSucceed;
                    }

                    if (isSucceed)
                    {
                        ConfigurationViewModel config = (ConfigurationViewModel.Repository.GetSingleModel(
                c => c.Keyword == SWCmsConstants.ConfigurationKeyword.Theme && c.Specificulture == "en-us", context, transaction)).Data;
                        if (config == null)
                        {
                            config = new ConfigurationViewModel()
                            {
                                Keyword = SWCmsConstants.ConfigurationKeyword.Theme,
                                Specificulture = "en-us",
                                Category = SWCmsConstants.ConfigurationType.User,
                                DataType = SWCmsConstants.DataType.String,
                                Description = "Cms Theme",

                                Value = theme.Name
                            };
                        }
                        else
                        {
                            config.Value = Name;
                        }
                        isSucceed = isSucceed && config.SaveModel(false, context, transaction).IsSucceed;
                    }

                    if (isSucceed)
                    {
                        ConfigurationViewModel config = (ConfigurationViewModel.Repository.GetSingleModel(
                c => c.Keyword == SWCmsConstants.ConfigurationKeyword.ThemeId && c.Specificulture == "en-us", context, transaction)).Data;
                        if (config == null)
                        {
                            config = new ConfigurationViewModel()
                            {
                                Keyword = SWCmsConstants.ConfigurationKeyword.ThemeId,
                                Specificulture = "en-us",
                                Category = SWCmsConstants.ConfigurationType.User,
                                DataType = SWCmsConstants.DataType.String,
                                Description = "Cms Theme",

                                Value = theme.Model.Id.ToString()
                            };
                        }
                        else
                        {
                            config.Value = theme.Model.Id.ToString();
                        }
                        isSucceed = isSucceed && config.SaveModel(false, context, transaction).IsSucceed;
                    }
                    if (isSucceed)
                    {
                        InitConfigurations(context, transaction);
                    }
                }
                else
                {
                    foreach (var theme in getThemes.Data)
                    {
                        string folderPath = CommonHelper.GetFullPath(new string[]
                        {
                            SWCmsConstants.Parameters.TemplatesFolder,
                            theme.Name
                        });

                        FileRepository.Instance.DeleteFolder(folderPath);

                        foreach (var item in theme.Templates)
                        {
                            isSucceed = isSucceed && item.SaveModel(true, _context: context, _transaction: transaction).IsSucceed;
                        }
                    }
                }
            }

            return isSucceed;
        }

        protected bool InitCultures(SiocCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            // EN-US
            var getCulture = BECultureViewModel.Repository.GetSingleModel(
                c => c.Specificulture == "en-us",
                _context: context,
                _transaction: transaction);

            if (!getCulture.IsSucceed)
            {
                BECultureViewModel cultureViewModel = new BECultureViewModel()
                {
                    Specificulture = "en-us",
                    FullName = "United States",
                    Description = "United States",
                    Icon = "flag-icon-us",
                    Alias = "US"
                };
                isSucceed = cultureViewModel.SaveModel(_context: context, _transaction: transaction).IsSucceed;
            }

            // VI-VN
            getCulture = BECultureViewModel.Repository.GetSingleModel(
                c => c.Specificulture == "vi-vn",
                _context: context,
                _transaction: transaction);

            if (isSucceed && !getCulture.IsSucceed)
            {
                BECultureViewModel cultureViewModel = new BECultureViewModel()
                {
                    Specificulture = "vi-vn",
                    FullName = "Vietnam",
                    Description = "Việt Nam",
                    Icon = "flag-icon-vn",
                    Alias = "VN"
                };
                isSucceed = cultureViewModel.SaveModel(_context: context, _transaction: transaction).IsSucceed;
            }
            return isSucceed;
        }
        protected bool InitPositions(SiocCmsContext context, IDbContextTransaction transaction)
        {
            bool isSucceed = true;
            var getPosition = BEPositionViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
            if (!getPosition.IsSucceed || getPosition.Data.Count == 0)
            {
                BEPositionViewModel p = new BEPositionViewModel()
                {
                    Description = nameof(SWCmsConstants.CatePosition.Nav)
                };
                isSucceed = p.SaveModel(_context: context, _transaction: transaction).IsSucceed;
                p = new BEPositionViewModel()
                {
                    Description = nameof(SWCmsConstants.CatePosition.Top)
                };
                isSucceed = isSucceed && p.SaveModel(_context: context, _transaction: transaction).IsSucceed;
                p = new BEPositionViewModel()
                {
                    Description = nameof(SWCmsConstants.CatePosition.Left)
                };
                isSucceed = isSucceed && p.SaveModel(_context: context, _transaction: transaction).IsSucceed;
                p = new BEPositionViewModel()
                {
                    Description = nameof(SWCmsConstants.CatePosition.Footer)
                };
                isSucceed = isSucceed && p.SaveModel(_context: context, _transaction: transaction).IsSucceed;
            }
            return isSucceed;
        }
        public void Refresh(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            InitConfigurations(_context, _transaction);
        }

        private static void InitConfigurations(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getConfigurations = ConfigurationViewModel.Repository.GetModelList(_context, _transaction);
            _listConfiguration = getConfigurations.Data ?? new List<ConfigurationViewModel>();
        }

        public void UpdateConfiguration(string key, string culture, string value)
        {
            var config = ListConfiguration.Find(c => c.Keyword == key && c.Specificulture == culture);
            if (config != null)
            {
                config.Value = value;
            }
        }

        public string GetLocalString(string key, string culture)
        {
            var config = ListConfiguration.Find(c => c.Keyword == key && c.Specificulture == culture);
            return config != null ? config.Value : key;
        }

        public string GetLocalString(string key, string culture, string defaultValue)
        {
            var config = ListConfiguration.Find(c => c.Keyword == key && c.Specificulture == culture);
            return config != null ? config.Value : defaultValue;
        }

        public static int GetLocalInt(string key, string culture)
        {
            var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            int.TryParse(config?.Value, out int result);
            return result;
        }

        public int GetLocalInt(string key, string culture, int defaultValue)
        {
            var config = ListConfiguration.Find(c => c.Keyword == key && c.Specificulture == culture);
            if (!int.TryParse(config?.Value, out int result))
            {
                result = defaultValue;
            }
            return result;
        }
    }
}
