using Microsoft.Extensions.DependencyInjection;

namespace Swastika.UI.Base.Extensions {

    public interface IExtensionStartup {

        /// <summary>
        /// Extensions the startup.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        void ExtensionStartup(IServiceCollection serviceCollection);

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        void ConfigureServices(IServiceCollection serviceCollection);

        /// <summary>
        /// Adds the authorization.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        void AddAuthorization(IServiceCollection serviceCollection);
    }
}