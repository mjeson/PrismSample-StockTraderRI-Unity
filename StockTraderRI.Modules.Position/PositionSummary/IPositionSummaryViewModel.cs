using System.Windows.Input;
using StockTraderRI.Infrastructure.Interfaces;

namespace StockTraderRI.Modules.Position.PositionSummary
{
    public interface IPositionSummaryViewModel : IHeaderInfoProvider<string>
    {
        IObservablePosition Position { get; }

        ICommand BuyCommand { get; }

        ICommand SellCommand { get; }
    }
}