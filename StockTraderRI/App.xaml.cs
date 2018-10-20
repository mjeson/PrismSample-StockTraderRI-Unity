using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace StockTraderRI
{
    public partial class App : PrismApplication
    {
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule(typeof(StockTraderRI.Modules.Market.MarketModule));
            moduleCatalog.AddModule(typeof(StockTraderRI.Modules.Position.PositionModule));
            moduleCatalog.AddModule(typeof(StockTraderRI.Modules.Watch.WatchModule));
            moduleCatalog.AddModule(typeof(StockTraderRI.Modules.News.NewsModule));
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
        }
    }
}