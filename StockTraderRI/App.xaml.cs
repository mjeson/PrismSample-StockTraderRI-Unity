using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;
using System.IO;
using System.Reflection;
using System.Windows;

namespace StockTraderRI
{
    public partial class App : Application
    {
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override Window CreateShell()
        {
            // Use the container to create an instance of the shell.
            Shell view = this.Container.Resolve<Shell>();
            view.DataContext = this.Container.Resolve<ShellViewModel>();
            return view;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // containerRegistry.RegisterSingleton(typeof(StockTraderRI.Infrastructure.StockTraderRICommandProxy));
            containerRegistry.RegisterSingleton<IStockTraderRICommandProxy, StockTraderRICommandProxy>();

            return;
            var ssa = System.AppDomain.CurrentDomain.BaseDirectory;
            var moduleRootFolder = new DirectoryInfo(Path.Combine(ssa, "netcoreapp2.1"));
            var moduleFolders = moduleRootFolder.GetDirectories();
            foreach (var moduleFolder in moduleFolders)
            {
                var binFolder = new DirectoryInfo(Path.Combine(moduleFolder.FullName, "bin"));
                if (!binFolder.Exists)
                {
                    continue;
                }

                foreach (var file in binFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories))
                {
                    Assembly assembly = null;
                    try
                    {
                        assembly = Assembly.LoadFrom(file.FullName);
                    }
                    catch (FileLoadException ex)
                    {
                        if (ex.Message == "Assembly with same name is already loaded")
                        {
                            // Get loaded assembly
                            assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(file.Name)));
                        }
                        else
                        {
                            throw;
                        }
                    }

                    if (assembly.FullName.Contains(moduleFolder.Name))
                    {
                        // modules.Add(new ModuleInfo { Name = moduleFolder.Name, Assembly =
                        // assembly, Path = moduleFolder.FullName });
                    }
                }
            }
        }
    }
}