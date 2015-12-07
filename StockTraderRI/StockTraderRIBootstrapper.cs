using System.Windows;
using Prism.Modularity;
using Prism.Unity;

namespace StockTraderRI
{
    public class StockTraderRIBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(StockTraderRI.Modules.Market.MarketModule));
            moduleCatalog.AddModule(typeof(StockTraderRI.Modules.Position.PositionModule));
            moduleCatalog.AddModule(typeof(StockTraderRI.Modules.Watch.WatchModule));
            moduleCatalog.AddModule(typeof(StockTraderRI.Modules.News.NewsModule));
        }

        protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            Shell view = this.Container.TryResolve<Shell>();
            view.DataContext = new ShellViewModel();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();
            return factory;
        }
    }
}
