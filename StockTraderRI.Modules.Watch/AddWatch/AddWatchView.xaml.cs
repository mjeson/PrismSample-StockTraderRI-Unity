using System.Windows.Controls;

namespace StockTraderRI.Modules.Watch.AddWatch
{
    public partial class AddWatchView : UserControl
    {
        public AddWatchView(AddWatchViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        AddWatchViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
