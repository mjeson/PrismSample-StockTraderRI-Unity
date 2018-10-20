using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;
using System.Windows;

namespace StockTraderRI
{
    public partial class App : PrismApplication
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
        }
    }
}