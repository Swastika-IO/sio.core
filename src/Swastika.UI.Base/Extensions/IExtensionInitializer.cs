using Microsoft.Extensions.DependencyInjection;

namespace Swastika.UI.Base.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IExtensionInitializer
    {
        /// <summary>
        /// Initializes the specified service collection.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        void Init(IServiceCollection serviceCollection);
    }
}
