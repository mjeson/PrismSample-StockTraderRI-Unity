using Prism.Commands;
using StockTraderRI.Infrastructure.Interfaces;

namespace StockTraderRI.Infrastructure
{
    public static class StockTraderRICommands
    {
        private static CompositeCommand addToWatchListCommand = new CompositeCommand();
        private static CompositeCommand cancelAllOrdersCommand = new CompositeCommand();
        private static CompositeCommand cancelOrderCommand = new CompositeCommand(true);
        private static CompositeCommand submitAllOrdersCommand = new CompositeCommand();
        private static CompositeCommand submitOrderCommand = new CompositeCommand(true);

        public static CompositeCommand AddToWatchListCommand
        {
            get { return addToWatchListCommand; }
            set { addToWatchListCommand = value; }
        }

        public static CompositeCommand CancelAllOrdersCommand
        {
            get { return cancelAllOrdersCommand; }
            set { cancelAllOrdersCommand = value; }
        }

        public static CompositeCommand CancelOrderCommand
        {
            get { return cancelOrderCommand; }
            set { cancelOrderCommand = value; }
        }

        public static CompositeCommand SubmitAllOrdersCommand
        {
            get { return submitAllOrdersCommand; }
            set { submitAllOrdersCommand = value; }
        }

        public static CompositeCommand SubmitOrderCommand
        {
            get { return submitOrderCommand; }
            set { submitOrderCommand = value; }
        }
    }
}