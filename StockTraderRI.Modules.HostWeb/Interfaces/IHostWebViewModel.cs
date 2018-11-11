using StockTraderRI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockTraderRI.Modules.HostWeb.Interfaces
{
    public interface IHostWebViewModel : IHeaderInfoProvider<string>
    {
        ICommand BackCommand { get; }

        //TODO  why not ??? becsue we just nedd adderess like www.google.de --> see url
        object ContentInfo { get; }

        ICommand ForwarCommand { get; }
        ICommand ShowWebPageCommand { get; }

        string Url { get; }
    }
}