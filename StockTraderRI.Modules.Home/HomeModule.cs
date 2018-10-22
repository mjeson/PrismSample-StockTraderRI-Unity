namespace StockTraderRI.Modules.Home
{
    using Prism.Ioc;
    using Prism.Modularity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeModule : IModule
    {
        // private readonly IRegionManager regionManager;

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //private MainRegionController _mainRegionController;

        public HomeModule()
        {
        }

        public void Initialize()
        {
            //this._mainRegionController = this.container.Resolve<MainRegionController>();
            //this.regionManager.RegisterViewWithRegion(RegionNames.TabRegion,
            //                                           () => this.container.Resolve<EmployeeDetailsView>());
            //this.regionManager.RegisterViewWithRegion(RegionNames.TabRegion,
            //                                           () => this.container.Resolve<EmployeeProjectsView>());
        }

        public void OnInitialized(IContainerProvider containerProvider) => this.Initialize();

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //this.container.RegisterType<IMarketFeedService, MarketFeedService>();
            //this.container.RegisterType<IMarketHistoryService, MarketHistoryService>();
            //this.container.RegisterType<TrendLineViewModel, TrendLineViewModel>();
        }
    }
}