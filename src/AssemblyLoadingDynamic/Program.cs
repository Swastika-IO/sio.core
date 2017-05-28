using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;
using System.IO;

namespace AssemblyLoadingDynamic
{
    class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly;
            try
            {
                assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"D:\_Workspace\_Github\Swastika-Core\src\ClassLibrary\bin\Debug\netcoreapp1.1\" + "ClassLibrary.dll");
                var type = assembly.GetType("ClassLibrary.Class");
                dynamic obj = Activator.CreateInstance(type);

                Console.WriteLine(obj.SayHello());
                Console.WriteLine(obj.SayHello("John Doe"));
                Console.Read();
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


            //var asl = new AssemblyLoader();
            //Assembly asm = null;
            //try
            //{

            //    asm = asl.LoadFromAssemblyPath(@"D:\_Workspace\_Github\Swastika-Core\src\ClassLibrary\bin\Debug\netcoreapp1.1\" + "ClassLibrary.dll");

            //    var type = asm.GetType("ClassLibrary.Class");
            //    dynamic obj = Activator.CreateInstance(type);

            //    Console.WriteLine(obj.SayHello());
            //    Console.WriteLine(obj.SayHello("John Doe"));
            //    Console.Read();
            //}
            //catch (System.IO.FileLoadException ex)
            //{
            //    if (ex.Message == "Assembly with same name is already loaded")
            //    {
            //        // Get loaded assembly
            //        asm = Assembly.Load(new AssemblyName("ClassLibrary"));
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
        }

        public class AssemblyLoader : AssemblyLoadContext
        {
            // Not exactly sure about this
            protected override Assembly Load(AssemblyName assemblyName)
            {
                var deps = DependencyContext.Default;
                var res = deps.CompileLibraries.Where(d => d.Name.Contains(assemblyName.Name)).ToList();
                var assembly = Assembly.Load(new AssemblyName(res.First().Name));
                return assembly;
            }
        }
    }
}