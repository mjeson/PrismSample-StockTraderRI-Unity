using System;
using System.Windows.Input;
using Prism.Mvvm;
using StockTraderRI.Modules.Watch.Services;

namespace StockTraderRI.Modules.Watch.AddWatch
{
    public class AddWatchViewModel : BindableBase
    {
        private string stockSymbol;
        private IWatchListService watchListService;

        public AddWatchViewModel(IWatchListService watchListService)
        {
            if (watchListService == null)
            {
                throw new ArgumentNullException("watchListService");
            }

            this.watchListService = watchListService;
        }

        public string StockSymbol
        {
            get { return stockSymbol; }
            set
            {
                SetProperty(ref stockSymbol, value);
            }
        }

        public ICommand AddWatchCommand { get { return this.watchListService.AddWatchCommand; } }
    }
}
