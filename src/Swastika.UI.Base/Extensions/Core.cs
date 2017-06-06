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


                ExtensionInfo extInfo = new ExtensionInfo();
                extInfo.References = new List<Assembly>();

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

                    if (dllFile.Name == extension.Name + ".dll")
                    {
                        extInfo.Name = extension.Name;
                        extInfo.Assembly = assembly;
                        extInfo.AbsolutePath = extFolder.FullName;
                    }
                    else
                    {
                        extInfo.References.Add(assembly);
                    }
                }
                extensions.Add(extInfo);
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
            // ref:
            // https://www.codeproject.com/Articles/1109475/WebControls/
            // https://github.com/aspnet/Mvc/issues/4686
            // https://github.com/aspnet/Razor/issues/755

            var mvcBuilder = services
                .AddMvc(mvcOption =>
                {
                    mvcOption.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider());
                })
                .AddRazorOptions(razorViewEngineOption =>
                {
                    // Adding the extensions assemblies to the list of compilation assemblies directly
                    foreach (var extension in extensionsInfo)
                    {
                        razorViewEngineOption.AdditionalCompilationReferences.Add(MetadataReference.CreateFromFile(extension.Assembly.Location));

                        // Adding the extension's references assemblies to the list of compilation assemblies directly
                        foreach (var reference in extension.References)
                        {
                            razorViewEngineOption.AdditionalCompilationReferences.Add(MetadataReference.CreateFromFile(reference.Location));

                        }
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
                
                AutoMapper.Mapper.Initialize(cfg => cfg.AddProfiles(extension.Assembly));
                AutoMapper.Mapper.Initialize(cfg => cfg.AddProfiles(extension.References));
                
            }

            return services;
        }
    }
}
