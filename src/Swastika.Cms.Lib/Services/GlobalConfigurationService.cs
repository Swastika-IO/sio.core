using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Models.Account;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Domain.Core.Models;
using Swastika.Identity.Data;
using Swastika.Common.Helper;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

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




        private static List<SupportedCulture> _listSupportedLanguage;
        public static List<SupportedCulture> ListSupportedCulture
        {
            get
            {
                if (_listSupportedLanguage == null)
                {
                    InitCultures();
                }
                return _listSupportedLanguage;
            }
            set
            {
                _listSupportedLanguage = value;
            }
        }
        private static GlobalConfigurationService _instance;
        public static GlobalConfigurationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalConfigurationService();
                }
                return _instance;
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

                    var getConnectionString = BEParameterViewModel.Repository.GetSingleModel(
                        c => c.Name == SWCmsConstants.ConfigurationKeyword.ConnectionString,
                        _context: context, _transaction: transaction);

                    if (!getConnectionString.IsSucceed)
                    {
                        BEParameterViewModel cnn = new BEParameterViewModel()
                        {
                            Name = SWCmsConstants.ConfigurationKeyword.ConnectionString,
                            Value = ConnectionString,
                            Description = SWCmsConstants.ConfigurationType.System
                        };
                        cnn.SaveModel(_context: context, _transaction: transaction);
                    }

                    var getCulture = CultureViewModel.Repository.GetSingleModel(
                        c => c.Specificulture == "vi-vn",
                        _context: context, _transaction: transaction);
                    if (!getCulture.IsSucceed)
                    {
                        CultureViewModel viCulture = new CultureViewModel()
                        {
                            Specificulture = "vi-vn",
                            FullName = "Vietnam",
                            Description = "Việt Nam",
                            Icon = "flag-icon-vn",
                            Alias = "Vietnam"
                        };
                        viCulture.SaveModel(_context: context, _transaction: transaction);
                    }
                    var getPosition = BEPositionViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
                    if (!getPosition.IsSucceed || getPosition.Data.Count == 0)
                    {
                        BEPositionViewModel p = new BEPositionViewModel()
                        {
                            Description = SWCmsConstants.CatePosition.Top.ToString()
                        };
                        p.SaveModel(_context: context, _transaction: transaction);
                        p = new BEPositionViewModel()
                        {
                            Description = SWCmsConstants.CatePosition.Left.ToString()
                        };
                        p.SaveModel(_context: context, _transaction: transaction);
                        p = new BEPositionViewModel()
                        {
                            Description = SWCmsConstants.CatePosition.Footer.ToString()
                        };
                        p.SaveModel(_context: context, _transaction: transaction);
                    }
                    var getThemes = BEThemeViewModel.Repository.GetModelList(_context: context, _transaction: transaction);
                    if (getThemes.IsSucceed)
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
                                    item.SaveModel(true, _context: context, _transaction: transaction);
                                }
                                catch { }
                            }
                        }
                    }
                    InitCultures(context, transaction);
                    InitConfigurations(context, transaction);
                    transaction.Commit();
                    IsInit = true;
                }
            }
            // TODO: Add more specific exeption types instead of Exception only
            catch
            {
                IsInit = false;
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }

            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
                if (accountContext != null)
                {
                    accountContext.Dispose();
                }

            }

        }

        public SupportedCulture GetCulture(string specificulture)
        {
            return ListSupportedCulture.FirstOrDefault(c => c.Specificulture == specificulture);
        }

        public List<SupportedCulture> GetSupportedCultures()
        {
            return ListSupportedCulture;
        }

        public void Refresh()
        {
            InitCultures();
            InitConfigurations();
        }

        public void RefreshCultures()
        {
            InitCultures();
        }

        static void InitCultures(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCultures = CultureViewModel.Repository.GetModelList(_context, _transaction);
            _listSupportedLanguage = new List<SupportedCulture>();
            if (getCultures.IsSucceed)
            {
               
                foreach (var culture in getCultures.Data)
                {
                    _listSupportedLanguage.Add(
                        new SupportedCulture()
                        {
                            Icon = culture.Icon,
                            Specificulture = culture.Specificulture,
                            Alias = culture.Alias,
                            FullName = culture.FullName,
                            Description = culture.FullName,
                            Id = culture.Id,
                            Lcid = culture.Lcid
                        });

                   
                }
            }

        }

        static void InitConfigurations(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getConfigurations = ConfigurationViewModel.Repository.GetModelList(_context, _transaction);
            _listConfiguration = getConfigurations.Data ?? new List<ConfigurationViewModel>();
        }

        public bool UpdateConfiguration(string key, string culture, string value)
        {
            var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
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
            var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            return config != null ? config.Value : key;
        }

        public string GetLocalString(string key, string culture, string defaultValue)
        {
            var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
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
            var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            if (!int.TryParse(config?.Value, out int result))
            {
                result = defaultValue;
            }
            return result;
        }
    }
}
