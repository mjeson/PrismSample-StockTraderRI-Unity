using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockTraderRI
{
    public class StockTraderRIBootstrapper : UnityBootstrapper
    {
        protected override Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();
            return factory;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            //TODO: To remove -> must be done in extra method from base class
            this.Container.RegisterType<IStockTraderRICommandProxy, StockTraderRICommandProxy>(new ContainerControlledLifetimeManager());
            // Use the container to create an instance of the shell.
            Shell view = this.Container.TryResolve<Shell>();
            view.DataContext = new ShellViewModel();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }
    }
}