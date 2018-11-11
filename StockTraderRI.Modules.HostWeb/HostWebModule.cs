using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using StockTradeRI.Common.WebApi;
using StockTraderRI.Infrastructure;
using StockTraderRI.Modules.HostWeb.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockTraderRI.Modules.HostWeb
{
    public class HostWebModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public HostWebModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            // You can start your server by given it the container

            this.RegisterTypes();

            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion, () => this.container.Resolve<HostWebView>());

            Program.Main(null);
        }

        private void RegisterTypes()
        {
            //this.container.RegisterType<IAccountPositionService, AccountPositionService>();
            //this.container.RegisterType<IOrdersService, XmlOrdersService>();
            //this.container.RegisterType<IOrdersController, OrdersController>();
            //this.container.RegisterType<IObservablePosition, ObservablePosition>();
            //this.container.RegisterType<IPositionSummaryViewModel, PositionSummaryViewModel>();
            //this.container.RegisterType<IPositionPieChartViewModel, PositionPieChartViewModel>();

            //this.container.RegisterType<IOrderCompositeViewModel, OrderCompositeViewModel>();
            //this.container.RegisterType<IOrderDetailsViewModel, OrderDetailsViewModel>();

            //this.container.RegisterType<IOrdersView, OrdersView>();
        }
    }
}