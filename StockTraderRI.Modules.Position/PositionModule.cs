using Microsoft.Practices.Unity;

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
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        private OrdersController _ordersController;

        public PositionModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            this.RegisterTypes();
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                                                       () => this.container.Resolve<PositionSummaryView>());
            this._ordersController = this.container.Resolve<OrdersController>();
        }

        private void RegisterTypes()
        {
            this.container.RegisterType<IAccountPositionService, AccountPositionService>();
            this.container.RegisterType<IOrdersService, XmlOrdersService>();
            this.container.RegisterType<IOrdersController, OrdersController>();
            this.container.RegisterType<IObservablePosition, ObservablePosition>();
            this.container.RegisterType<IPositionSummaryViewModel, PositionSummaryViewModel>();
            this.container.RegisterType<IPositionPieChartViewModel, PositionPieChartViewModel>();

            this.container.RegisterType<IOrderCompositeViewModel, OrderCompositeViewModel>();
            this.container.RegisterType<IOrderDetailsViewModel, OrderDetailsViewModel>();

            this.container.RegisterType<IOrdersView, OrdersView>();
        }
    }
}