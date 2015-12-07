using System.Windows;

namespace StockTraderRI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
        }

        ShellViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
