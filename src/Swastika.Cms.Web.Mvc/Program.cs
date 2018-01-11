using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Services;

namespace Swastika.Cms.Web.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            GlobalConfigurationService.Instance.InitSWCms();                
            BuildWebHost(args).Run();
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .UseApplicationInsights()
                .Build();
    }
}
