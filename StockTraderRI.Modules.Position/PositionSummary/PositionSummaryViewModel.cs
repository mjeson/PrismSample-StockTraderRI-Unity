using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using StockTraderRI.Infrastructure;
using StockTraderRI.Modules.Position.Controllers;

namespace StockTraderRI.Modules.Position.PositionSummary
{
    public class PositionSummaryViewModel : BindableBase, IPositionSummaryViewModel
    {
        private readonly IEventAggregator eventAggregator;
        private PositionSummaryItem currentPositionSummaryItem;

        public PositionSummaryViewModel(IOrdersController ordersController, IEventAggregator eventAggregator, IObservablePosition observablePosition)
        {
            if (ordersController == null)
            {
                throw new ArgumentNullException("ordersController");
            }

            this.eventAggregator = eventAggregator;
            this.Position = observablePosition;

            BuyCommand = ordersController.BuyCommand;
            SellCommand = ordersController.SellCommand;

            this.CurrentPositionSummaryItem = new PositionSummaryItem("FAKEINDEX", 0, 0, 0);
        }

        public ICommand AddToWatchCommand { get; private set; }
        public ICommand BuyCommand { get; private set; }

        public PositionSummaryItem CurrentPositionSummaryItem
        {
            get { return currentPositionSummaryItem; }
            set
            {
                if (SetProperty(ref currentPositionSummaryItem, value))
                {
                    if (currentPositionSummaryItem != null)
                    {
                        eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish(
                            CurrentPositionSummaryItem.TickerSymbol);
                    }
                }
            }
        }

        public string HeaderInfo
        {
            get { return "POSITION"; }
        }

        public IObservablePosition Position { get; private set; }
        public ICommand SellCommand { get; private set; }
    }
}