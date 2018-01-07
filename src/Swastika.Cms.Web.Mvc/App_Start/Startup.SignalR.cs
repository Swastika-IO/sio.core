using Swastika.Messenger.Lib.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Sockets;
using Microsoft.Extensions.DependencyInjection;
using System;
using Messenger.Lib.SignalR.Hubs;

namespace Swastika.Cms.Web.Mvc
{
    public partial class Startup
    {
        public void ConfigureSignalRServices(IServiceCollection services)
        {
            services.BuildServiceProvider();
            services.AddSignalR();
        }

        public void ConfigurationSignalR(IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<MessengerHub>("Messenger");
            });

        }

    }
    }
