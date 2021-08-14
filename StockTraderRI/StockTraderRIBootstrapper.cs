using System.Windows;
using Prism.Ioc;
using Prism.Unity;

namespace StockTraderRI
{
    public class StockTraderRIBootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //TODO: To remove -> must be done in extra method from base class
            //this.Container.RegisterType<IStockTraderRICommandProxy, StockTraderRICommandProxy>(new ContainerControlledLifetimeManager());
            // Use the container to create an instance of the shell.
            Shell view = this.Container.Resolve<Shell>();
            view.DataContext = new ShellViewModel();
            return view;
        }

        //protected override void InitializeShell()
        //{
        //    base.InitializeShell();
        //    App.Current.MainWindow = (Window)this.Shell;
        //    App.Current.MainWindow.Show();
        //}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}