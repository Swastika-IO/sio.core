using Swastika.Cms.Lib.ViewModels;
using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swastika.IO.Cms.Lib.Services
{
    public class ApplicationConfigService
    {
        public string Culture { get; set; }
        public string Name { get; set; }
        //public List<ConfigurationViewModel> ListConfiguration { get; set; }
        public static List<SupportedCulture> ListSupportedCulture { get; set; } = new List<SupportedCulture>();
        //private readonly ConfigurationRepository _repo;
        public ApplicationConfigService()
        {
            //_repo = ConfigurationRepository.GetInstance();
            InitCultures();
        }
       
        public void Refresh()
        {
            InitCultures();
        }

        public void RefreshCultures()
        {
            InitCultures();
        }

        public void InitCultures()
        {
            var getCultures = CultureViewModel.Repository.GetModelList();
            if (getCultures.IsSucceed)
            {
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
                }
            }
        }

        //public bool UpdateConfiguration(string key, string culture, string value)
        //{
        //    var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
        //    string oldValue = config.Value;

        //    config.Value = value;
        //    var result = _repo.SaveModel(config);

        //    if (result.IsSucceed)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        config.Value = oldValue;
        //        return false;
        //    }
        //}

        //public string GetLocalString(string key, string culture)
        //{
        //    var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
        //    return config != null ? config.Value : key;
        //}

        //public string GetLocalString(string key, string culture, string defaultValue)
        //{
        //    var config = ListConfiguration.FirstOrDefault(c => c.Keyword == key && c.Specificulture == culture);
        //    return config != null ? config.Value : defaultValue;
        //}
    }
}
