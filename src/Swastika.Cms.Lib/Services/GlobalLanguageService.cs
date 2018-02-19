// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Cms.Lib.Services
{
    public class GlobalLanguageService
    {
        /// <summary>
        /// The synchronize root
        /// </summary>
        private static object syncRoot = new Object();

        private static string _connectionString;
        public string Culture { get; set; }
        public string Name { get; set; }
        public bool IsInit { get; set; }
        private static JObject _translator { get; set; }

        public JObject Translator
        {
            get
            {
                return _translator;
            }
            set
            {
                _translator = value;
            }
        }

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
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new GlobalLanguageService();
                    }
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
            InitCultures();
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

        public void RefreshCultures(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            InitCultures(_context, _transaction);
        }

        private static void InitCultures(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCultures = CultureViewModel.Repository.GetModelList(_context, _transaction);
            _listSupportedLanguage = new List<SupportedCulture>();
            if (getCultures.IsSucceed)
            {
                _translator = new JObject();
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

                    var getLanguages = BELanguageViewModel.Repository.GetModelListBy(l => l.Specificulture == culture.Specificulture, _context, _transaction);

                    JObject temp = new JObject();
                    foreach (var item in getLanguages.Data)
                    {
                        temp.Add(new JProperty(item.Keyword, item.Value));
                    }
                    _translator.Add(new JProperty(culture.Specificulture, temp));
                }
            }
        }

        private static void InitLanguages(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getLanguages = BELanguageViewModel.Repository.GetModelList(_context, _transaction);
            _listLanguage = getLanguages.Data ?? new List<BELanguageViewModel>();
        }

        public string Translate(string culture, string key)
        {
            return Translator[culture][key]?.ToString() ?? key;
        }

        public bool UpdateLanguage(string key, string culture, string value)
        {
            var config = ListLanguage.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
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

    public class Translator
    {
        public string Culture { get; set; }

        public Translator(string culture)
        {
            this.Culture = culture;
        }

        public string Get(string key)
        {
            return GlobalLanguageService.Instance.Translator[Culture][key]?.ToString() ?? key;
        }
    }
}