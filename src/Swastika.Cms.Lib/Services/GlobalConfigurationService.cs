// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Swastika.Cms.Lib.Models.Account;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Common.Helper;
using System;
using System.Collections.Generic;

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

        //private static List<SupportedCulture> _listSupportedLanguage;
        //public static List<SupportedCulture> ListSupportedCulture
        //{
        //    get
        //    {
        //        if (_listSupportedLanguage == null)
        //        {
        //            InitCultures();
        //        }
        //        return _listSupportedLanguage;
        //    }
        //    set
        //    {
        //        _listSupportedLanguage = value;
        //    }
        //}
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

        //private readonly ConfigurationRepository _repo;
        public GlobalConfigurationService()
        {
            //_repo = ConfigurationRepository.GetInstance();
            //InitCultures();
            //InitConfigurations();
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

                        //if (string.IsNullOrEmpty(ConnectionString))
                        //{
                        //    //Get Remote cnn string here (in future)
                        //    var getConnectionString = BEParameterViewModel.Repository.GetSingleModel(
                        //c => c.Name == SWCmsConstants.ConfigurationKeyword.ConnectionString);
                        //    if (getConnectionString.IsSucceed)
                        //    {
                        //        ConnectionString = getConnectionString.Data.Value;
                        //    }
                        //}
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

        public void InitSWCms()
        {
            SiocCmsContext context = null;
            SiocCmsAccountContext accountContext = null;
            IDbContextTransaction transaction = null;
            try
            {
                if (InitConnectionString())
                {
                    context = new SiocCmsContext();
                    accountContext = new SiocCmsAccountContext();
                    context.Database.Migrate();
                    accountContext.Database.Migrate();
                    transaction = context.Database.BeginTransaction();
                    bool isSucceed = true;
                    //var getConnectionString = BEParameterViewModel.Repository.GetSingleModel(
                    //    c => c.Name == SWCmsConstants.ConfigurationKeyword.ConnectionString,
                    //    _context: context, _transaction: transaction);

                    //if (!getConnectionString.IsSucceed)
                    //{
                    //    BEParameterViewModel cnn = new BEParameterViewModel()
                    //    {
                    //        Name = SWCmsConstants.ConfigurationKeyword.ConnectionString,
                    //        Value = ConnectionString,
                    //        Description = SWCmsConstants.ConfigurationType.System
                    //    };
                    //    cnn.SaveModel(_context: context, _transaction: transaction);
                    //}

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
                        isSucceed = isSucceed && cultureViewModel.SaveModel(_context: context, _transaction: transaction).IsSucceed;
                    }

                    // VI-VN
                    getCulture = BECultureViewModel.Repository.GetSingleModel(
                        c => c.Specificulture == "vi-vn",
                        _context: context,
                        _transaction: transaction);

                    if (!getCulture.IsSucceed)
                    {
                        BECultureViewModel cultureViewModel = new BECultureViewModel()
                        {
                            Specificulture = "vi-vn",
                            FullName = "Vietnam",
                            Description = "Việt Nam",
                            Icon = "flag-icon-vn",
                            Alias = "VN"
                        };
                        isSucceed = isSucceed && cultureViewModel.SaveModel(_context: context, _transaction: transaction).IsSucceed;
                    }

                    var getPosition = BEPositionViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
                    if (isSucceed && (!getPosition.IsSucceed || getPosition.Data.Count == 0))
                    {
                        BEPositionViewModel p = new BEPositionViewModel()
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
                    var getThemes = BEThemeViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
                    if (isSucceed && getThemes.IsSucceed)
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

                                var delFolder = FileRepository.Instance.DeleteFolder(folderPath);

                                foreach (var item in theme.Templates)
                                {
                                    try
                                    {
                                        isSucceed = isSucceed && item.SaveModel(true, _context: context, _transaction: transaction).IsSucceed;
                                    }
                                    catch { }
                                }
                            }
                        }
                    }

                    if (isSucceed)
                    {

                        BECategoryViewModel cate = new BECategoryViewModel( new SiocCategory()
                        {
                            Title = "Home",
                            Specificulture = "vi-vn",
                            Template = "_Home",
                            Type = (int)SWCmsConstants.CateType.Home,
                            CreatedBy = "Admin"

                        });

                        isSucceed = isSucceed && cate.SaveModel(false, context, transaction).IsSucceed;
                        BECategoryViewModel uscate = new BECategoryViewModel( new SiocCategory()
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
                        IsInit = true;
                    }
                }
            }
            catch (Exception ex) // TODO: Add more specific exeption types instead of Exception only
            {
                IsInit = false;
                transaction?.Rollback();
                throw ex;
            }
            finally
            {
                context?.Dispose();
                accountContext?.Dispose();
            }
        }

        //public SupportedCulture GetCulture(string specificulture)
        //{
        //    return ListSupportedCulture.FirstOrDefault(c => c.Specificulture == specificulture);
        //}

        //public List<SupportedCulture> GetSupportedCultures()
        //{
        //    return ListSupportedCulture;
        //}

        public void Refresh()
        {
            //InitCultures();
            InitConfigurations();
        }

        //public void RefreshCultures()
        //{
        //    InitCultures();
        //}

        //static void InitCultures(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        //{
        //    var getCultures = CultureViewModel.Repository.GetModelList(_context, _transaction);
        //    _listSupportedLanguage = new List<SupportedCulture>();
        //    if (getCultures.IsSucceed)
        //    {
        //        foreach (var culture in getCultures.Data)
        //        {
        //            _listSupportedLanguage.Add(
        //                new SupportedCulture()
        //                {
        //                    Icon = culture.Icon,
        //                    Specificulture = culture.Specificulture,
        //                    Alias = culture.Alias,
        //                    FullName = culture.FullName,
        //                    Description = culture.FullName,
        //                    Id = culture.Id,
        //                    Lcid = culture.Lcid
        //                });

        //        }
        //    }

        //}

        private static void InitConfigurations(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getConfigurations = ConfigurationViewModel.Repository.GetModelList(_context, _transaction);
            _listConfiguration = getConfigurations.Data ?? new List<ConfigurationViewModel>();
        }

        public bool UpdateConfiguration(string key, string culture, string value)
        {
            var config = ListConfiguration.Find(c => c.Keyword == key && c.Specificulture == culture);
            string oldValue = config.Value;

            config.Value = value;
            var result = ConfigurationViewModel.Repository.SaveModel(config);

            if (result.IsSucceed)
            {
                return true;
            }
            else
            {
                config.Value = oldValue;
                return false;
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
            return 10;
            //var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            //return config != null ? config.Value : key;
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
