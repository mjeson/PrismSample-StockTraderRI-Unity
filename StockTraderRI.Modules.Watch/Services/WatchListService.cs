using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;

namespace StockTraderRI.Modules.Watch.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IMarketFeedService marketFeedService;

        public WatchListService(IMarketFeedService marketFeedService, IEventAggregator eventAggregator)
        {
            this.marketFeedService = marketFeedService;
            this.eventAggregator = eventAggregator;
            WatchItems = new ObservableCollection<string>();

            AddWatchCommand = new DelegateCommand<string>(AddWatch);
            //WatchItems.CollectionChanged += (s, e) => this.eventAggregator.GetEvent<AddWatchTickerSymbolEvent>().Publish(true);
        }

        public ICommand AddWatchCommand { get; set; }

        private ObservableCollection<string> WatchItems { get; set; }

        public ObservableCollection<string> RetrieveWatchList()
        {
            return WatchItems;
        }

        private void AddWatch(string tickerSymbol)
        {
            if (!String.IsNullOrEmpty(tickerSymbol))
            {
                string upperCasedTrimmedSymbol = tickerSymbol.ToUpper(CultureInfo.InvariantCulture).Trim();
                if (!WatchItems.Contains(upperCasedTrimmedSymbol))
                {
                    if (marketFeedService.SymbolExists(upperCasedTrimmedSymbol))
                    {
                        WatchItems.Add(upperCasedTrimmedSymbol);
                        this.eventAggregator.GetEvent<AddWatchTickerSymbolEvent>().Publish(true);
                    }
                }
                else
                {
                }
            }
        }
    }
}