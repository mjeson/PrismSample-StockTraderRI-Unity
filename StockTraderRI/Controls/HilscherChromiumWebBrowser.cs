using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockTraderRI.Controls
{
    public class HilscherChromiumWebBrowser : ChromiumWebBrowser
    {
        /// <summary>
        /// Identifies the BBCode dependency property.
        /// </summary>
        public static DependencyProperty UrlProperty = DependencyProperty.Register("Url", typeof(string), typeof(HilscherChromiumWebBrowser), new PropertyMetadata(new PropertyChangedCallback(OnUrlChanged)));

        /// <summary>
        /// Initializes a new instance of the <see cref="BBCodeBlock"/> class.
        /// </summary>
        public HilscherChromiumWebBrowser()
        {
            this.Url = "www.ggogöe.de";
            // ensures the implicit BBCodeBlock style is used
            this.DefaultStyleKey = typeof(HilscherChromiumWebBrowser);
        }

        /// <summary>
        /// Gets or sets the BB code.
        /// </summary>
        /// <value>The BB code.</value>
        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        private static void OnUrlChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UrlProperty = ChromiumWebBrowser.AddressProperty;
        }
    }
}