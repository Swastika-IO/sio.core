using Microsoft.Extensions.DependencyInjection;
using Swastika.UI.Base.Extensions;

namespace Swastika.Extension.Blog
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Swastika.UI.Base.Extensions.IExtensionStartup" />
    public class Startup : IExtensionStartup
    {

        /// <summary>
        /// The constant authentication policy canwriteBlogdata
        /// </summary>
        public const string CONST_AUTH_POLICY_CANWRITEBlogDATA = "CanWriteBlogData";
        /// <summary>
        /// The constant authentication policy canremoveBlogdata
        /// </summary>
        public const string CONST_AUTH_POLICY_CANREMOVEBlogDATA = "CanRemoveBlogData";

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup()
        {
            // Do something on startup
        }

        /// <summary>
        /// Extensions the startup.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        public void ExtensionStartup(IServiceCollection serviceCollection)
        {
            AddAuthorization(serviceCollection);
            ConfigureServices(serviceCollection);
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //// Blog
            //serviceCollection.AddScoped<IBlogAppService, BlogAppService>();

            //// Domain - Events
            //serviceCollection.AddScoped<IHandler<BlogRegisteredEvent>, BlogEventHandler>();
            //serviceCollection.AddScoped<IHandler<BlogUpdatedEvent>, BlogEventHandler>();
            //serviceCollection.AddScoped<IHandler<BlogRemovedEvent>, BlogEventHandler>();

            //// Domain - Commands
            //serviceCollection.AddScoped<IHandler<RegisterNewBlogCommand>, BlogCommandHandler>();
            //serviceCollection.AddScoped<IHandler<UpdateBlogCommand>, BlogCommandHandler>();
            //serviceCollection.AddScoped<IHandler<RemoveBlogCommand>, BlogCommandHandler>();

            //// Infra - Data
            //serviceCollection.AddScoped<IBlogRepository, BlogRepository>();
            //serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            //serviceCollection.AddScoped<SwastikaExtensionBlogContext>();
        }

        public void AddAuthorization(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(options =>
            {
                //options.AddPolicy(CONST_AUTH_POLICY_CANWRITEBlogDATA, policy => policy.Requirements.Add(new ClaimRequirement("Blogs", "Write")));
                //options.AddPolicy(CONST_AUTH_POLICY_CANREMOVEBlogDATA, policy => policy.Requirements.Add(new ClaimRequirement("Blogs", "Remove")));
            });
        }
    }
}
