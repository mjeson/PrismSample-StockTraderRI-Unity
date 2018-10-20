using Microsoft.Practices.Unity;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using StockTraderRI.Infrastructure;
using StockTraderRI.Modules.Watch.AddWatch;
using StockTraderRI.Modules.Watch.Services;
using StockTraderRI.Modules.Watch.WatchList;
using Unity;

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
            this.regionManager.RegisterViewWithRegion(RegionNames.MainToolBarRegion,
                                                       () => this.container.Resolve<AddWatchView>());
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                                                       () => this.container.Resolve<WatchListView>());
        }

        public void OnInitialized(IContainerProvider containerProvider) => this.Initialize();

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IWatchListService, WatchListService>();
            //containerRegistry.RegisterType<AddWatchViewModel, AddWatchViewModel>();
            //this.container.RegisterType<WatchListViewModel, WatchListViewModel>();
        }
    }
}