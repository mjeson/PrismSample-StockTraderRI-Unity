using System.Windows.Controls;

namespace StockTraderRI.Modules.Position.PositionSummary
{
    public partial class PositionSummaryView : UserControl
    {
        public PositionSummaryView(IPositionSummaryViewModel viewModel)
        {
            InitializeComponent();
            Model = viewModel;
        }

        #region IPositionSummaryView Members

        public IPositionSummaryViewModel Model
        {
            get
            {
                return DataContext as IPositionSummaryViewModel;
            }
            set
            {
                DataContext = value;
            }
        }
        #endregion
    }
}
