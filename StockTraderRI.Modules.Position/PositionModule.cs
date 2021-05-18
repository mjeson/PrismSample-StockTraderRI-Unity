using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;
using StockTraderRI.Modules.Position.Controllers;
using StockTraderRI.Modules.Position.Interfaces;
using StockTraderRI.Modules.Position.Orders;
using StockTraderRI.Modules.Position.PositionSummary;
using StockTraderRI.Modules.Position.Services;

namespace StockTraderRI.Modules.Position
{
    public class PositionModule : IModule
    {
        public void Initialize()
        {
        }

        public void OnInitialized(Prism.Ioc.IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                                                        () => containerProvider.Resolve<PositionSummaryView>());
            var _ordersController = containerProvider.Resolve<OrdersController>();

            ;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IAccountPositionService, AccountPositionService>();
            containerRegistry.Register<IOrdersService, XmlOrdersService>();
            containerRegistry.Register<IOrdersController, OrdersController>();
            containerRegistry.Register<IObservablePosition, ObservablePosition>();
            containerRegistry.Register<IPositionSummaryViewModel, PositionSummaryViewModel>();
            containerRegistry.Register<IPositionPieChartViewModel, PositionPieChartViewModel>();

            containerRegistry.Register<IOrderCompositeViewModel, OrderCompositeViewModel>();
            containerRegistry.Register<IOrderDetailsViewModel, OrderDetailsViewModel>();

            containerRegistry.Register<IOrdersView, OrdersView>();
        }
    }
}