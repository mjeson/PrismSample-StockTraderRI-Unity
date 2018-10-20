using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTraderRI.Infrastructure.Interfaces
{
    public interface IStockTraderRICommandProxy
    {
        CompositeCommand AddToWatchListCommand
        {
            get;
        }

        CompositeCommand CancelAllOrdersCommand
        {
            get;
        }

        CompositeCommand CancelOrderCommand
        {
            get;
        }

        CompositeCommand SubmitAllOrdersCommand
        {
            get;
        }

        CompositeCommand SubmitOrderCommand
        {
            get;
        }
    }
}