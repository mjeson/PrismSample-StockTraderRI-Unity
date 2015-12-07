using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using StockTraderRI.Infrastructure;
using StockTraderRI.Modules.Watch.AddWatch;
using StockTraderRI.Modules.Watch.Services;
using StockTraderRI.Modules.Watch.WatchList;

namespace StockTraderRI.Modules.Watch
{
    public class WatchModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public WatchModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            this.container.RegisterType<IWatchListService, WatchListService>();
            this.container.RegisterType<AddWatchViewModel, AddWatchViewModel>();
            this.container.RegisterType<WatchListViewModel, WatchListViewModel>();
            this.regionManager.RegisterViewWithRegion(RegionNames.MainToolBarRegion,
                                                       () => this.container.Resolve<AddWatchView>());
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                                                       () => this.container.Resolve<WatchListView>());
        }
    }
}
