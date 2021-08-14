using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;
using StockTraderRI.Modules.News.Article;
using StockTraderRI.Modules.News.Controllers;
using StockTraderRI.Modules.News.Services;

namespace StockTraderRI.Modules.News
{
    public class NewsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.ResearchRegion,
                                                       () => containerProvider.Resolve<ArticleView>());

            regionManager.RegisterViewWithRegion(RegionNames.SecondaryRegion,
                                                       () => containerProvider.Resolve<NewsReaderView>());
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<INewsFeedService, NewsFeedService>();

            containerRegistry.Register<INewsController, NewsController>();
        }
    }
}