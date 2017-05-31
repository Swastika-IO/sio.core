using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swastika.Common.Utility;
using Swastika.UI.Base.Extensions.Models;
using Swastika.UI.Base.Extensions.Web.ModelBinders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Swastika.UI.Base.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class Core
    {
        /// <summary>
        /// Loads the extensions.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="extensionsFilePath">The extensions file path.</param>
        /// <param name="extensionsFileName">Name of the extensions file.</param>
        /// <returns></returns>
        public static IServiceCollection LoadExtensions(this IServiceCollection services,
            string extensionsFilePath = Const.CONST_DEFAULT_EXTENSIONS_FILE_PATH,
            string extensionsFileName = Const.CONST_DEFAULT_EXTENSION_FILE_NAME)
        {
            var extensions = new List<ExtensionInfo>();
            string physicalExtensionsFolerPath = Directory.GetCurrentDirectory() + extensionsFilePath;
            string json = File.ReadAllText(physicalExtensionsFolerPath + extensionsFileName);
            List<Extension> extensionsFromJson = JsonConvert.DeserializeObject<List<Extension>>(json);

            foreach (Extension extension in extensionsFromJson)
            {
                var extFolder = new DirectoryInfo(Path.Combine(physicalExtensionsFolerPath, extension.Name));
                if (!extFolder.Exists)
                {
                    continue;
                }

                foreach (var dllFile in extFolder.GetFileSystemInfos("*.dll"))
                {
                    Assembly assembly;
                    try
                    {
                        // Get new assembly from path
                        assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFile.FullName);
                    }
                    catch (FileLoadException)
                    {
                        // Get loaded assembly
                        assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(dllFile.Name)));

                        if (assembly == null)
                        {
                            throw;
                        }
                    }

                    if (dllFile.Name == extension.Name + ".dll" || dllFile.Name == extension.Name + ".UI.Api.dll")
                    {
                        extensions.Add(new ExtensionInfo
                        {
                            Name = extension.Name,
                            Assembly = assembly,
                            AbsolutePath = extFolder.FullName,
                        });
                    }
                }

            }
            ExtensionManager.Extensions = extensions;
            ExtensionManager.RelativePath = extensionsFilePath;
            return services;
        }

        /// <summary>
        /// Adds the MVC to extensions.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="extensionsInfo">The extensions information.</param>
        /// <returns></returns>
        public static IServiceCollection AddMvcToExtensions(this IServiceCollection services, IList<ExtensionInfo> extensionsInfo)
        {
            var mvcBuilder = services
                .AddMvc(o =>
                {
                    o.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider());
                })
                .AddRazorOptions(o =>
                {
                    foreach (var extension in extensionsInfo)
                    {
                        o.AdditionalCompilationReferences.Add(MetadataReference.CreateFromFile(extension.Assembly.Location));
                    }
                })
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            foreach (var extension in extensionsInfo)
            {
                // Register controller from extensions
                mvcBuilder.AddApplicationPart(extension.Assembly);

                // Register dependency in extensions
                var extensionInitializerType = extension.Assembly.GetTypes().FirstOrDefault(x => typeof(IExtensionStartup).IsAssignableFrom(x));
                if ((extensionInitializerType != null) && (extensionInitializerType != typeof(IExtensionStartup)))
                {
                    var extensionInitializer = (IExtensionStartup)Activator.CreateInstance(extensionInitializerType);

                    // Call extension startup class
                    extensionInitializer.ExtensionStartup(services);
                }
            }

            return services;
        }
    }
}
