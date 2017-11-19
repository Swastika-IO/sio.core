using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Swastika.IO.Cms.Lib
{
    public class SWCmsConstants
    {
        public const string TemplatesFolder = @"Views/Templates";
        public const string TemplateExtension = @".cshtml";
        public const string WebRootPath = @"wwwroot";
        public const string UploadFolder = @"sw-content/uploads";

        public class AuthConfiguration
        {
            public const string ConnectionString = @"Server=115.77.190.113,4444;Database=stag_swastika_io;UID=sa;Pwd=sqlP@ssw0rd;MultipleActiveResultSets=true";
            public const string ApiEndPoint = "/";

            public const string FacebookId = "";
            public const string FacebookSecret = "";

            public const string GoogleId = "";
            public const string GoogleSecret = "";

            public const string MicrosoftId = "";
            public const string MicrosoftSecret = "";

            public const string TwitterKey = "";
            public const string TwitterSecret = "";

            public const string OpenIdAuthority = "";
            public const string OpenIdClientId = "";

            public const int AuthCookieExpiration = 30; // In Seconds
            public const int AuthCookieRefreshExpiration = 3000; // In Seconds
            public const string AuthCookieLoginPath = "";
            public const string AuthCookieLogoutPath = "";
            public const string AuthCookieAccessDeniedPath = "";

            public static string Audience { get; } = "MyAudience";
            public const string AuthTokenIssuer = "Swastika";
            public static RsaSecurityKey AuthTokenKey { get; } = new RsaSecurityKey(SWCmsHelper.GenerateKey());
            public static string TokenType { get; } = "Bearer";
            public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(AuthTokenKey, SecurityAlgorithms.RsaSha256Signature);

            public static List<string> UserClaims { get; set; }
                = new List<string>
                {
                    "Add User",
                    "Edit User",
                    "Delete User"
                };
        }

        public class Default
        {
            public const string ArticleTemplate = @"_Default.cshtml";
            public const string Specificulture = @"vi-vn";
            public const string Password = @"1234qwe@";
        }

        public enum ModuleType
        {
            Root,
            SubPage,
            SubArticle,
        }

        public enum SearchType
        {
            All,
            Article,
            Module,
            Page
        }

        public enum TemplateFolder
        {
            Layouts,
            Pages,
            Modules,
            Articles,
            Widgets,
        }

        public enum FileFolder
        {
            Styles,
            Scripts,
            Images,
            Fonts,
            Others
        }

        public enum ViewModelType
        {
            FrontEnd = 0,
            BackEnd = 1
        }

        public enum CateType
        {
            Blank = 0,
            Article = 1,
            List = 2,
            Home = 3,
            StaticUrl = 4,
            Modules = 5
        }

        public enum CatePosition
        {
            Top = 1,
            Left = 2,
            Footer = 3
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
            Boolean = 7
        }
    }
}