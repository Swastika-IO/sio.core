using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Cms.Lib.Services
{
    public class CmsCultureConfiguration
    {
        public JObject Translator { get; set; }
        public List<SupportedCulture> ListSupportedCulture { get; private set; }
        public List<BELanguageViewModel> ListLanguage { get; set; }

        public CmsCultureConfiguration()
        {            
        }

        public SupportedCulture GetCulture(string specificulture)
        {
            return ListSupportedCulture.Find(c => c.Specificulture == specificulture);
        }

        public List<SupportedCulture> GetSupportedCultures()
        {
            return ListSupportedCulture;
        }

        public void Init(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            InitCultures(_context, _transaction);
            InitLanguages(_context, _transaction);
        }

        private void InitCultures(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCultures = BECultureViewModel.Repository.GetModelList(_context, _transaction);
            ListSupportedCulture = new List<SupportedCulture>();
            if (getCultures.IsSucceed)
            {
                Translator = new JObject();
                foreach (var culture in getCultures.Data)
                {
                    ListSupportedCulture.Add(
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

                    var getLanguages = BELanguageViewModel.Repository.GetModelListBy(l => l.Specificulture == culture.Specificulture, _context, _transaction);

                    JObject temp = new JObject();
                    foreach (var item in getLanguages.Data)
                    {
                        temp.Add(new JProperty(item.Keyword, item.Value));
                    }
                    if (Translator.GetValue(culture.Specificulture) == null)
                    {
                        Translator.Add(new JProperty(culture.Specificulture, temp));
                    }
                }
            }
        }

        private void InitLanguages(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getLanguages = BELanguageViewModel.Repository.GetModelList(_context, _transaction);
            ListLanguage = getLanguages.Data ?? new List<BELanguageViewModel>();
        }

        public string Translate(string culture, string key)
        {
            return Translator[culture][key]?.ToString() ?? key;
        }

        public bool UpdateLanguage(string key, string culture, string value)
        {
            var config = ListLanguage.Find(c => c.Keyword == key && c.Specificulture == culture);
            string oldValue = config.Value;

            config.Value = value;
            var result = BELanguageViewModel.Repository.SaveModel(config);

            if (result.IsSucceed)
            {
                Translator[culture][key] = value;
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
            var config = ListLanguage.Find(c => c.Keyword == key && c.Specificulture == culture);
            return config != null ? config.Value : key;
        }

        public string GetLocalString(string key, string culture, string defaultValue)
        {
            var config = ListLanguage.Find(c => c.Keyword == key && c.Specificulture == culture);
            return config != null ? config.Value : defaultValue;
        }

        public int GetLocalInt(string key, string culture, int defaultValue)
        {
            var config = ListLanguage.Find(c => c.Keyword == key && c.Specificulture == culture);
            if (!int.TryParse(config?.Value, out int result))
            {
                result = defaultValue;
            }
            return result;
        }
    }
    public class Translator
    {
        public string Culture { get; set; }

        public Translator(string culture)
        {
            this.Culture = culture;
        }

        public string Get(string key)
        {
            return GlobalConfigurationService.Instance.CmsCulture.Translator[Culture][key]?.ToString() ?? key;
        }
    }
}
