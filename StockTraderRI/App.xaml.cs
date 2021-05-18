using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;

namespace StockTraderRI
{
    public partial class App : PrismApplication
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        // //Add Custom assembly resolver // AppDomain.CurrentDomain.AssemblyResolve += Resolver;

        // StockTraderRIBootstrapper bootstrapper = new StockTraderRIBootstrapper(); bootstrapper.Run();

        //    this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        //}

        protected override IModuleCatalog CreateModuleCatalog() => new ConfigurationModuleCatalog();

        protected override Window CreateShell()
        {
            var shell = this.Container.Resolve<Shell>();
            shell.DataContext = this.Container.Resolve<ShellViewModel>();
            return shell;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 2. Common interface
            containerRegistry.Register<IStockTraderRICommandProxy, StockTraderRICommandProxy>();
        }
    }
}