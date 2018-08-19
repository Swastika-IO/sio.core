// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Swastika.Cms.Lib
{
    public class SWCmsConstants
    {
        public const string CONST_FILE_APPSETTING = "appSettings.json";

        public const string CONST_DEFAULT_CONNECTION = "CmsConnection";

        /// The constant path home access denied
        /// </summary>
        public const string CONST_PATH_HOME_ACCESS_DENIED = "/home/access-denied";

        /// <summary>
        /// The constant path home error
        /// </summary>
        public const string CONST_PATH_HOME_ERROR = "/Home/Error";

        /// <summary>
        /// The constant section logging
        /// </summary>
        public const string CONST_SECTION_LOGGING = "Logging";

        /// <summary>
        /// The constant route default
        /// </summary>
        public const string CONST_ROUTE_DEFAULT = "default";

        /// <summary>
        /// The constant appid
        /// </summary>
        public const string CONST_APPID = "SetYourDataHere";

        /// <summary>
        /// The constant appsecret
        /// </summary>
        public const string CONST_APPSECRET = "SetYourDataHere";

        /// <summary>
        /// The constant domain notification key commit{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        public const string CONST_DOMAIN_NOTIFICATION_KEY_COMMIT = "Commit";

        /// <summary>
        /// The constant domain notification key commit value{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        public const string CONST_DOMAIN_NOTIFICATION_KEY_COMMIT_VALUE = "We had a problem during saving your data.";

        /// <summary>
        /// The constant domain notification{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        public const string CONST_DOMAIN_NOTIFICATION = "DomainNotification";

        /// <summary>
        /// The constant default extension path
        /// </summary>
        public const string CONST_DEFAULT_EXTENSIONS_FILE_PATH = "\\Contents\\Extensions\\";

        /// <summary>
        /// The constant default extension file name
        /// </summary>
        public const string CONST_DEFAULT_EXTENSION_FILE_NAME = "extensions.json";

        public enum CatePosition
        {
            Nav = 1,
            Top = 2,
            Left = 3,
            Footer = 4
        }

        public enum CateType
        {
            Blank = 0,
            Article = 1,
            List = 2,
            Home = 3,
            StaticUrl = 4,
            Modules = 5,
            ListProduct = 6
        }

        public enum ConfigurationCategory
        {
            PageSize,
            Site,
            Email
        }

        public enum DataType
        {
            String = 0,
            Int = 1,
            Image = 2,
            Icon = 3,
            CodeEditor = 4,
            Html = 5,
            TextArea = 6,
            Boolean = 7,
            MdTextArea = 8
        }

        public enum EnumFileFolder
        {
            Styles,
            Scripts,
            Images,
            Fonts,
            Others
        }

        public enum ModuleType
        {
            Root,
            SubPage,
            SubArticle,
            SubProduct,
            Form
        }

        public enum UrlAliasType
        {
            Page,
            Article,
            Product,
            Module,
            ModuleData
        }

        public enum SearchType
        {
            All,
            Article,
            Module,
            Page
        }

        public enum EnumTemplateFolder
        {
            Layouts,
            Pages,
            Modules,
            Articles,
            Products,
            Widgets,
            Masters,
        }

        public enum ViewModelType
        {
            FrontEnd = 0,
            BackEnd = 1
        }

        public static class AuthConfiguration
        {
            public const string ApiEndPoint = "/";
            public const string AuthCookieAccessDeniedPath = "";
            public const int AuthCookieExpiration = 30;
            public const string AuthCookieLoginPath = "";
            public const string AuthCookieLogoutPath = "";

            // In Seconds
            public const int AuthCookieRefreshExpiration = 3000;

            public const string AuthTokenIssuer = "Swastika";
            public const string ConnectionString = @"";
            public const string FacebookId = "";
            public const string FacebookSecret = "";

            public const string GoogleId = "";
            public const string GoogleSecret = "";

            public const string MicrosoftId = "";
            public const string MicrosoftSecret = "";

            public const string OpenIdAuthority = "";
            public const string OpenIdClientId = "";
            public const string TwitterKey = "";
            public const string TwitterSecret = "";

            // In Seconds
            public static string Audience { get; } = "MyAudience";

            public static RsaSecurityKey AuthTokenKey { get; } = new RsaSecurityKey(SwCmsHelper.GenerateKey());
            public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(AuthTokenKey, SecurityAlgorithms.RsaSha256Signature);
            public static string TokenType { get; } = "Bearer";

            public static List<string> UserClaims { get; set; }
                = new List<string>
                {
                    "Add User",
                    "Edit User",
                    "Delete User"
                };
        }

        public static class ConfigurationKeyword
        {
            public const string ConnectionString = "ConnectionString";
            public const string Theme = "Theme";
            public const string Language = "Language";
            public const string IsSqlite = "IsSqlite";
            public const string ThemeId = "ThemeId";
        }

        public static class ConfigurationType
        {
            public const string System = "System";
            public const string User = "User";
        }

        public static class Default
        {
            public const string DefaultTemplate = @"_Default";
            public const string DefaultTemplateFolder = @"Default_Blank";
            public const string DefaultTemplateLayout = @"_Layout";
            public const string DefaultTemplateLayoutBody = "<div>@RenderBody();</div>";
            public const string OrderBy = @"Priority";
            public const int PageSizeArticle = 20;
            public const string Password = @"";
            //public static string Specificulture { get; set; } = @"en-us";
        }

        public class FileFolder
        {
            public const string Fonts = "Fonts";
            public const string Images = "Images";
            public const string Others = "Others";
            public const string Scripts = "Scripts";
            public const string Styles = "Styles";
            public const string Medias = "Medias";
        }

        public static class JwtSettings
        {
            public const string AUDIENCE = "http://localhost:58510/";
            public const int EXPIRED_IN = 10;
            public const string ISSUER = "http://localhost:58510/";
            public const string SECRET_KEY = "swastika-secret-key";
            // MINUTES
        }

        public static class Parameters
        {
            public const string FileFolder = @"Content";
            public const string TemplateExtension = @".cshtml";
            public const string TemplatesAssetFolder = @"Templates";
            public const string TemplatesFolder = @"Views/Shared/Templates";
            public const string UploadFolder = @"Content/Uploads";
            public const string WebRootPath = @"wwwroot";
        }

        public static class TemplateFolder
        {
            public const string Articles = "Articles";
            public const string Layouts = "Layouts";
            public const string Modules = "Modules";
            public const string Pages = "Pages";
            public const string Products = "Products";
            public const string Widgets = "Widgets";
        }
    }
}
