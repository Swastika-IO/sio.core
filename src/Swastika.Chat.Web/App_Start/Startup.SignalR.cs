using ChatRoom.Lib.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Sockets;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Swastika.Messenger.Web
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
