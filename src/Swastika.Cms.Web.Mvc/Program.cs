using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Swastika.Cms.Lib.Services;

namespace Swastika.Cms.Web.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationConfigService.Instance.InitTemplates();
            BuildWebHost(args).Run();
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .UseApplicationInsights()
                .Build();
    }
}
