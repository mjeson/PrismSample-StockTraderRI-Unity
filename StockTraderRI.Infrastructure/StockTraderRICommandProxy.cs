using Prism.Commands;
using StockTraderRI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTraderRI.Infrastructure
{
    public class StockTraderRICommandProxy : IStockTraderRICommandProxy
    {
        virtual public CompositeCommand AddToWatchListCommand
        {
            get { return StockTraderRICommands.AddToWatchListCommand; }
        }

        virtual public CompositeCommand CancelAllOrdersCommand
        {
            get { return StockTraderRICommands.CancelAllOrdersCommand; }
        }

        virtual public CompositeCommand CancelOrderCommand
        {
            get { return StockTraderRICommands.CancelOrderCommand; }
        }

        virtual public CompositeCommand SubmitAllOrdersCommand
        {
            get { return StockTraderRICommands.SubmitAllOrdersCommand; }
        }

        virtual public CompositeCommand SubmitOrderCommand
        {
            get { return StockTraderRICommands.SubmitOrderCommand; }
        }
    }
}