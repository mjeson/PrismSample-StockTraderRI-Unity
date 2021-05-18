using Prism.Ioc;
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
        public void OnInitialized(Prism.Ioc.IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.MainToolBarRegion,
                                                      () => containerProvider.Resolve<AddWatchView>());
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                                                       () => containerProvider.Resolve<WatchListView>());
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IWatchListService, WatchListService>();
            containerRegistry.Register<WatchListViewModel, WatchListViewModel>();
            containerRegistry.Register<AddWatchViewModel, AddWatchViewModel>();
        }
    }
}