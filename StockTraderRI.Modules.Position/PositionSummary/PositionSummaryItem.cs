using Prism.Mvvm;

namespace StockTraderRI.Modules.Position.PositionSummary
{
    public class PositionSummaryItem : BindableBase
    {
        private decimal _costBasis;

        private decimal _currentPrice;

        private long _shares;

        private string _tickerSymbol;

        public PositionSummaryItem(string tickerSymbol, decimal costBasis, long shares, decimal currentPrice)
        {
            TickerSymbol = tickerSymbol;
            CostBasis = costBasis;
            Shares = shares;
            CurrentPrice = currentPrice;
        }

        public decimal CostBasis
        {
            get
            {
                return _costBasis;
            }
            set
            {
                if (SetProperty(ref _costBasis, value))
                {
                    this.RaisePropertyChanged();
                }
            }
        }

        public decimal CurrentPrice
        {
            get
            {
                return _currentPrice;
            }
            set
            {
                if (SetProperty(ref _currentPrice, value))
                {
                    this.RaisePropertyChanged(nameof(this.MarketValue));
                    this.RaisePropertyChanged(nameof(this.GainLossPercent));
                }
            }
        }

        public decimal GainLossPercent { get => ((CurrentPrice * Shares - CostBasis) * 100 / CostBasis); }

        public decimal MarketValue { get => (_shares * _currentPrice); }

        public long Shares
        {
            get
            {
                return _shares;
            }
            set
            {
                if (SetProperty(ref _shares, value))
                {
                    this.RaisePropertyChanged(nameof(MarketValue));
                    this.RaisePropertyChanged(nameof(GainLossPercent));
                }
            }
        }

        public string TickerSymbol
        {
            get => _tickerSymbol;

            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }

                SetProperty(ref _tickerSymbol, value);
            }
        }
    }
}