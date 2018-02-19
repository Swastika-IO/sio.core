// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Swastika.Cms.Lib
{
    public class SWCmsConstants
    {
        public const string CONST_DEFAULT_CONNECTION = "CmsConnection";

        public enum CatePosition
        {
            Top = 1,
            Left = 2,
            Footer = 3
        }

        public enum CateType
        {
            Blank = 0,
            Article = 1,
            List = 2,
            Home = 3,
            StaticUrl = 4,
            Modules = 5,
            ListProduct
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

        public enum FileFolderEnum
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
        }

        public enum SearchType
        {
            All,
            Article,
            Module,
            Page
        }

        public enum TemplateFolderEnum
        {
            Layouts,
            Pages,
            Modules,
            Articles,
            Products,
            Widgets
        }

        public enum ViewModelType
        {
            FrontEnd = 0,
            BackEnd = 1
        }

        public class AuthConfiguration
        {
            public const string ApiEndPoint = "/";
            public const string AuthCookieAccessDeniedPath = "";
            public const int AuthCookieExpiration = 30;
            public const string AuthCookieLoginPath = "";
            public const string AuthCookieLogoutPath = "";

            // In Seconds
            public const int AuthCookieRefreshExpiration = 3000;

            public const string AuthTokenIssuer = "Swastika";
            public const string ConnectionString = @"Server=115.77.190.113,4444;Database=stag_swastika_io;UID=sa;Pwd=sqlP@ssw0rd;MultipleActiveResultSets=true";
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

            public static RsaSecurityKey AuthTokenKey { get; } = new RsaSecurityKey(SWCmsHelper.GenerateKey());
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

        public class ConfigurationKeyword
        {
            public const string ConnectionString = "ConnectionString";
            public const string Theme = "Theme";
            public const string ThemeId = "ThemeId";
        }

        public class ConfigurationType
        {
            public const string System = "System";
            public const string User = "User";
        }

        public enum ConfigurationCategory
        {
            PageSize,
            Site,
            Email
        }

        public class Default
        {
            public const string DefaultTemplate = @"_Default";
            public const string DefaultTemplateFolder = @"Default-Templates";
            public const string DefaultTemplateLayout = @"_Layout";
            public const string DefaultTemplateLayoutBody = "<div>@RenderBody();</div>";
            public const string OrderBy = @"Priority";
            public const int PageSizeArticle = 20;
            public const string Password = @"1234qwe@";
            public const string Specificulture = @"vi-vn";
        }

        public class FileFolder
        {
            public const string Fonts = "Fonts";
            public const string Images = "Images";
            public const string Others = "Others";
            public const string Scripts = "Scripts";
            public const string Styles = "Styles";
        }

        public class JWTSettings
        {
            public const string AUDIENCE = "http://localhost:58510/";
            public const int EXPIRED_IN = 10;
            public const string ISSUER = "http://localhost:58510/";
            public const string SECRET_KEY = "swastika-secret-key";
            // MINUTES
        }

        public class Parameters
        {
            public const string FileFolder = @"Content";
            public const string TemplateExtension = @".cshtml";
            public const string TemplatesAssetFolder = @"Templates";
            public const string TemplatesFolder = @"Views/Shared/Templates";
            public const string UploadFolder = @"Content/Uploads";
            public const string WebRootPath = @"wwwroot";
        }

        public class TemplateFolder
        {
            public const string Articles = "Articles";
            public const string Products = "Products";
            public const string Layouts = "Layouts";
            public const string Modules = "Modules";
            public const string Pages = "Pages";
            public const string Widgets = "Widgets";
        }
    }
}