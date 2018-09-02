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
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Common.Helper;
using Swastika.Domain.Core.ViewModels;
using Swastika.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastika.Cms.Lib.Services
{
    public class CmsConfiguration
    {
        public CmsConfiguration()
        {
            Configuration = LoadConfiguration();
            InitParams();
        }

        public void Init(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            InitConfigurations(_context, _transaction);
        }

        public string CmsConnectionString { get; set; }
        public string AccountConnectionString { get; set; }
        public bool IsSqlite { get; set; }
        public string Language { get; set; }
        public int DefaultStatus { get; set; }
        public List<InfoConfigurationViewModel> ListConfiguration { get; set; }
        public IConfiguration Configuration { get; set; }

        private void InitParams()
        {
            CmsConnectionString = Configuration.GetConnectionString(SWCmsConstants.CONST_DEFAULT_CONNECTION);
            AccountConnectionString = Configuration.GetConnectionString(SWCmsConstants.CONST_DEFAULT_CONNECTION);
            Language = Configuration[SWCmsConstants.ConfigurationKeyword.Language];
            var stt = Configuration[SWCmsConstants.ConfigurationKeyword.DefaultStatus]?.ToString();
            DefaultStatus = stt != null ? int.Parse(stt) : 2;
            bool.TryParse(Configuration[SWCmsConstants.ConfigurationKeyword.IsSqlite], out bool isSqlite);
            IsSqlite = isSqlite;
        }

        private void InitConfigurations(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getConfigurations = InfoConfigurationViewModel.Repository.GetModelList(_context, _transaction);
            ListConfiguration = getConfigurations.Data ?? new List<InfoConfigurationViewModel>();
        }

        public IConfiguration LoadConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(System.IO.Directory.GetCurrentDirectory())
               .AddJsonFile(Common.Utility.Const.CONST_FILE_APPSETTING)
               .Build();

            return configuration;
        }

        public string GetLocalString(string key, string culture = null, string defaultValue = null)
        {
            var config = ListConfiguration.Find(c => c.Keyword == key && (culture == null || c.Specificulture == culture));
            return config != null ? config.Value : defaultValue;
        }

        public int GetLocalInt(string key, string culture, int defaultValue = 0)
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
