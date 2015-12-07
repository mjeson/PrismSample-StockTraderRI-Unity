using System.Windows.Controls;

namespace StockTraderRI.Modules.Market.TrendLine
{
    public partial class TrendLineView : UserControl
    {
        public TrendLineView(TrendLineViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        TrendLineViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
