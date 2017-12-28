using Swastika.Cms.Lib.ViewModels;
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

        //private readonly ConfigurationRepository _repo;
        public ApplicationConfigService()
        {
            //_repo = ConfigurationRepository.GetInstance();
            InitCultures();
            InitConfigurations();
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

        public int GetLocalInt(string key, string culture, string defaultValue)
        {
            return 10;
            //var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            //return config != null ? config.Value : defaultValue;
        }
    }
}
