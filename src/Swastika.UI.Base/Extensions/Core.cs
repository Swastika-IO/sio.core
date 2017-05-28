using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Swastika.UI.Base.Extensions
{
    public static class Core
    {
        public static IServiceCollection LoadExtensions(this IServiceCollection services)
        {
            Assembly assembly;
            try
            {
                assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"D:\_Workspace\_Github\Swastika-Core\src\ClassLibrary\bin\Debug\netcoreapp1.1\" + "ClassLibrary.dll");
                var type = assembly.GetType("ClassLibrary.Class");
                dynamic obj = Activator.CreateInstance(type);

                Console.WriteLine(obj.SayHello());
                Console.WriteLine(obj.SayHello("John Doe"));
            }
            catch (FileLoadException)
            {
                // Get loaded assembly
                assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(@"D:\_Workspace\_Github\Swastika-Core\src\ClassLibrary\bin\Debug\netcoreapp1.1\" + "ClassLibrary")));

                if (assembly == null)
                {
                    throw;
                }
            }
            return services;
        }
    }
}
