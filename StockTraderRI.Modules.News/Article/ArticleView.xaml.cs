using System.Windows.Controls;
using System.Windows.Media.Animation;
using StockTraderRI.Modules.News.Controllers;

namespace StockTraderRI.Modules.News.Article
{
    public partial class ArticleView : UserControl
    {
        // Note - this import is here so that the controller is created and gets wired to the article and news reader
        // view models, which are shared instances
        private INewsController _newsController { get; set; }

        public ArticleView(ArticleViewModel viewModel, INewsController newsController)
        {
            InitializeComponent();
            ViewModel = viewModel;
            _newsController = newsController;
        }

        ArticleViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NewsList.SelectedItem != null)
            {
                var storyboard = (Storyboard)this.Resources["Details"];
                storyboard.Begin();
            }
            else
            {
                var storyboard = (Storyboard)this.Resources["List"];
                storyboard.Begin();
            }
        }
    }
}
