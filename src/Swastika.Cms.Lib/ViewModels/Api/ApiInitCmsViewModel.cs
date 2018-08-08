using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Lib.ViewModels.Account;
using Swastika.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiInitCmsViewModel
    {
        #region Properties
        [JsonProperty("connectionString")]
        public string ConnectionString
        {
            get
            {
                return IsUseLocal
                    ? IsSqlite ? SqliteDbConnectionString : LocalDbConnectionString
                    : $"Server={DataBaseServer};Database={DataBaseName}" +
                    $";UID={DataBaseUser};Pwd={DataBasePassword};MultipleActiveResultSets=true;"
                    ;
            }
        }

        [JsonProperty("dataBaseServer")]
        public string DataBaseServer { get; set; }

        [JsonProperty("dataBaseName")]
        public string DataBaseName { get; set; }

        [JsonProperty("dataBaseUser")]
        public string DataBaseUser { get; set; }

        [JsonProperty("dataBasePassword")]
        public string DataBasePassword { get; set; }

        [JsonProperty("isUseLocal")]
        public bool IsUseLocal { get; set; }

        [JsonProperty("localDbConnectionString")]
        public string LocalDbConnectionString { get; set; } =
            $"Server=(localdb)\\MSSQLLocalDB;Initial Catalog=sw-cms.db;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";

        [JsonProperty("sqliteDbConnectionString")]
        public string SqliteDbConnectionString { get; set; } = $"Data Source=sw-cms.db";

        [JsonProperty("superAdminsuperAdmin")]
        public string SuperAdmin { get; set; }

        [JsonProperty("adminPassword")]
        public string AdminPassword { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("isSqlite")]
        public bool IsSqlite { get; set; }

        [JsonProperty("culture")]
        public InitCulture Culture { get; set; }
        #endregion

        public ApiInitCmsViewModel()
        {

        }


    }

    public class InitCulture
    {
        [JsonProperty("specificulture")]
        public string Specificulture { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("alias")]
        public string Alias { get; set; }
    }
}
