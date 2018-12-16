using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: HostingStartup(typeof(Sio.Cms.Hub.SignalRStartup))]
namespace Sio.Cms.Hub
{
    public class SignalRStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            Console.Write(builder);
            //SioChatServiceContext context = new SioChatServiceContext();
            //context.Database.Migrate();
        }
    }
}
