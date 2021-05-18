using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;
using StockTraderRI.Modules.Market.Services;
using StockTraderRI.Modules.Market.TrendLine;

namespace StockTraderRI.Modules.Market
{
    public class MarketModule : IModule
    {
        public void OnInitialized(Prism.Ioc.IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.ResearchRegion,
                                                        () => containerProvider.Resolve<TrendLineView>());
        }

        public void RegisterTypes(Prism.Ioc.IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMarketFeedService, MarketFeedService>();
            containerRegistry.Register<IMarketHistoryService, MarketHistoryService>();
            containerRegistry.Register<TrendLineViewModel, TrendLineViewModel>();
        }
    }
}