using System.Windows.Controls;

namespace StockTraderRI.Modules.News.Article
{
    public partial class NewsReaderView : UserControl
    {
        public NewsReaderView(NewsReaderViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public static string Title
        {
            get
            {
                return Properties.Resources.NewsReaderViewTitle;
            }
        }

        NewsReaderViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
