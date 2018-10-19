using Prism.Events;

namespace StockTraderRI.Infrastructure
{
    public class AddWatchTickerSymbolEvent : PubSubEvent<bool>
    {
    }

    public class TickerSymbolSelectedEvent : PubSubEvent<string>
    {
    }
}