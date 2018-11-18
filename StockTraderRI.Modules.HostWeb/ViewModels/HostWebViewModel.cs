using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using StockTraderRI.Infrastructure;
using StockTraderRI.Modules.HostWeb.Interfaces;
using StockTraderRI.Modules.HostWeb.Views;
using System;
using System.Windows.Input;

namespace StockTraderRI.Modules.HostWeb.ViewModels
{
    public class HostWebViewModel : BindableBase, IHostWebViewModel
    {
        private readonly IRegionManager regionManager;
        private object contentInfo;
        private ICommand showWebPageCommand;
        private string url;

        public HostWebViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.url = "www.facebook.de";
            this.contentInfo = "KKKKKKKKKKKKKKKKKKKK";
            this.showWebPageCommand = new DelegateCommand<string>(p => this.ExecuteShowWebPage(p));
        }

        public ICommand BackCommand => throw new NotImplementedException();

        public string CommandName { get => "Show Web"; }
        public object ContentInfo { get => this.contentInfo; }

        public ICommand ForwarCommand => throw new NotImplementedException();

        public string HeaderInfo { get => "WebApp"; }
        public bool IsChromiumable { get => true; }

        public ICommand ShowWebPageCommand { get => this.showWebPageCommand; }
        public string Url { get => this.url; }

        private void ExecuteShowWebPage(string parameter)
        {
            this.ShowWebPage(parameter);
        }

        private void ShowWebPage(string pramater)
        {
            IRegion region = this.regionManager.Regions[RegionNames.WebRegion];

            object topoView = region.GetView("TopoView");
            if (topoView == null)
            {
                topoView = ServiceLocator.Current.GetInstance<HostWebView>();
                region.Add(topoView, "TopoView");
            }

            region.Activate(topoView);
        }
    }
}