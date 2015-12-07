namespace StockTraderRI.Modules.Position.PositionSummary
{
    public class PositionPieChartViewModel : IPositionPieChartViewModel
    {
        public IObservablePosition Position { get; private set; }

        public PositionPieChartViewModel(IObservablePosition observablePosition)
        {
            this.Position = observablePosition;
        }
    }
}
