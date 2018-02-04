using Microsoft.EntityFrameworkCore.Storage;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.Services
{
    public class GlobalLanguageService
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
        private static List<BELanguageViewModel> _listLanguage;
        public static List<BELanguageViewModel> ListLanguage
        {
            get
            {
                if (_listLanguage == null)
                {
                    InitLanguages();
                }
                return _listLanguage;
            }
            set
            {
                _listLanguage = value;
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
        private static GlobalLanguageService _instance;
        public static GlobalLanguageService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalLanguageService();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        //private readonly LanguageRepository _repo;
        public GlobalLanguageService()
        {
            //_repo = LanguageRepository.GetInstance();
            //InitCultures();
            //InitLanguages();
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
            InitLanguages();
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

        static void InitLanguages(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getLanguages = BELanguageViewModel.Repository.GetModelList(_context, _transaction);
            _listLanguage = getLanguages.Data ?? new List<BELanguageViewModel>();
        }

        public bool UpdateLanguage(string key, string culture, string value)
        {
            var config = ListLanguage.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            string oldValue = config.Value;

            config.Value = value;
            var result = BELanguageViewModel.Repository.SaveModel(config);

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
            var config = ListLanguage.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            return config != null ? config.Value : key;
        }

        public string GetLocalString(string key, string culture, string defaultValue)
        {
            var config = ListLanguage.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            return config != null ? config.Value : defaultValue;
        }

        public static int GetLocalInt(string key, string culture)
        {
            return 10;
            //var config = ListLanguage.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            //return config != null ? config.Value : key;
        }

        public int GetLocalInt(string key, string culture, int defaultValue)
        {
            var config = ListLanguage.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
            if (!int.TryParse(config?.Value, out int result))
            {
                result = defaultValue;
            }
            return result;
        }
    }
}
