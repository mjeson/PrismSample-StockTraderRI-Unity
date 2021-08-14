using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using StockTraderRI.Modules.Watch.Services;
using StockTraderRI.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using Prism.Regions;
using StockTraderRI.Infrastructure.Interfaces;
using StockTraderRI.Modules.Watch.Properties;
using System.Globalization;

namespace StockTraderRI.Modules.Watch.WatchList
{
    public class WatchListViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IMarketFeedService marketFeedService;
        private readonly IRegionManager regionManager;
        private readonly ICommand removeWatchCommand;
        private readonly IStockTraderRICommandProxy stockTraderRICommandProxy;
        private readonly IWatchListService watchListService;
        private WatchItem currentWatchItem;
        private string headerInfo;
        private ObservableCollection<WatchItem> watchListItems;

        public WatchListViewModel(IStockTraderRICommandProxy stockTraderRICommandProxy, IWatchListService watchListService, IMarketFeedService marketFeedService, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            if (watchListService == null)
            {
                throw new ArgumentNullException("watchListService");
            }
            if (stockTraderRICommandProxy == null)
            {
                throw new ArgumentNullException("stockTraderRICommandProxy");
            }
            if (eventAggregator == null)
            {
                throw new ArgumentNullException("eventAggregator");
            }

            //Init Prperties
            this.stockTraderRICommandProxy = stockTraderRICommandProxy;
            this.eventAggregator = eventAggregator;
            this.watchListService = watchListService;
            this.HeaderInfo = Resources.WatchListTitle;
            this.WatchListItems = new ObservableCollection<WatchItem>();
            this.marketFeedService = marketFeedService;
            this.regionManager = regionManager;

            // Setup Commands
            this.removeWatchCommand = new DelegateCommand<string>(this.RemoveWatch);
            // this.AddWatchCommand = new DelegateCommand<string>(AddWatch);
            this.stockTraderRICommandProxy.AddToWatchListCommand.RegisterCommand(this.watchListService.AddWatchCommand);

            //Setup Subscribers
            this.eventAggregator.GetEvent<MarketPricesUpdatedEvent>().Subscribe(this.MarketPricesUpdated, ThreadOption.UIThread);
            this.eventAggregator.GetEvent<AddWatchTickerSymbolEvent>().Subscribe(i =>
            {
                this.PopulateWatchItemsList(watchListService.RetrieveWatchList());
            }, ThreadOption.UIThread, true
           );

            // Populate Watch Items to views
            this.PopulateWatchItemsList(watchListService.RetrieveWatchList());
        }

        public ICommand AddWatchCommand { get; set; }

        public WatchItem CurrentWatchItem
        {
            get
            {
                return this.currentWatchItem;
            }

            set
            {
                if (value != null)
                {
                    SetProperty(ref this.currentWatchItem, value);
                    this.eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish(this.currentWatchItem.TickerSymbol);
                }
            }
        }

        public string HeaderInfo
        {
            get
            {
                return this.headerInfo;
            }

            set
            {
                SetProperty(ref this.headerInfo, value);
            }
        }

        public ICommand RemoveWatchCommand { get { return this.removeWatchCommand; } }

        public ObservableCollection<WatchItem> WatchListItems
        {
            get => this.watchListItems;

            set
            {
                SetProperty(ref this.watchListItems, value);
            }
        }

        //private void AddWatch(string tickerSymbol)
        //{
        //    if (!String.IsNullOrEmpty(tickerSymbol))
        //    {
        //        string upperCasedTrimmedSymbol = tickerSymbol.ToUpper(CultureInfo.InvariantCulture).Trim();
        //        this.PopulateWatchItemsList(watchListService.RetrieveWatchList());
        //    }
        //}

        private void MarketPricesUpdated(IDictionary<string, decimal> updatedPrices)
        {
            if (updatedPrices == null)
            {
                throw new ArgumentNullException("updatedPrices");
            }

            foreach (WatchItem watchItem in this.WatchListItems)
            {
                if (updatedPrices.ContainsKey(watchItem.TickerSymbol))
                {
                    watchItem.CurrentPrice = updatedPrices[watchItem.TickerSymbol];
                }
            }
        }

        private void PopulateWatchItemsList(IEnumerable<string> watchItemsList)
        {
            this.WatchListItems.Clear();
            foreach (string tickerSymbol in watchItemsList)
            {
                decimal? currentPrice;
                try
                {
                    currentPrice = this.marketFeedService.GetPrice(tickerSymbol);
                }
                catch (ArgumentException)
                {
                    currentPrice = null;
                }

                this.WatchListItems.Add(new WatchItem(tickerSymbol, currentPrice));
            }
        }

        private void RemoveWatch(string tickerSymbol)
        {
            //this.watchList.Remove(tickerSymbol);
        }

        //private void WatchListItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == NotifyCollectionChangedAction.Add)
        //    {
        //        regionManager.Regions[RegionNames.MainRegion].RequestNavigate("/WatchListView", nr => { });
        //    }
        //}
    }
}