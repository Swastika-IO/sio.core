using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.Services
{
    public class ApplicationConfigService
    {
        public string Culture { get; set; }
        public string Name { get; set; }


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
        private static ApplicationConfigService _instance;
        public static ApplicationConfigService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApplicationConfigService();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        //private readonly ConfigurationRepository _repo;
        public ApplicationConfigService()
        {
            //_repo = ConfigurationRepository.GetInstance();
            InitCultures();
            InitConfigurations();
        }

        public void InitSWCms()
        {
            var getCulture = CultureViewModel.Repository.GetSingleModel(c => c.Specificulture == "vi-vn");
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
                viCulture.SaveModel();
            }
            var getPosition = BEPositionViewModel.Repository.GetModelList();
            if (!getPosition.IsSucceed || getPosition.Data.Count == 0)
            {
                BEPositionViewModel p = new BEPositionViewModel()
                {
                    Description = SWCmsConstants.CatePosition.Top.ToString()
                };
                p.SaveModel();
                p = new BEPositionViewModel()
                {
                    Description = SWCmsConstants.CatePosition.Left.ToString()
                };
                p.SaveModel();
                p = new BEPositionViewModel()
                {
                    Description = SWCmsConstants.CatePosition.Footer.ToString()
                };
                p.SaveModel();
            }
            var getTemplates = InfoTemplateViewModel.Repository.GetModelList();
            if (getTemplates.IsSucceed)
            {
                foreach (var item in getTemplates.Data)
                {
                    try
                    {
                        item.SaveModel();
                    }
                    catch { }
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

        static void InitCultures()
        {
            var getCultures = CultureViewModel.Repository.GetModelList();
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

        static void InitConfigurations()
        {
            var getConfigurations = ConfigurationViewModel.Repository.GetModelList();
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
