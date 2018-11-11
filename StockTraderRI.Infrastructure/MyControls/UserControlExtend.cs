using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StockTraderRI.Infrastructure.MyControls
{
    public class UserControlExtend : ContentControl
    {
        /// <summary>
        /// Identifies the BBCode dependency property.
        /// </summary>
        public static DependencyProperty IsChromiumableProperty = DependencyProperty.Register("IsChromiumable", typeof(bool), typeof(UserControlExtend), new PropertyMetadata(new PropertyChangedCallback(OnUrlChanged)));

        public UserControlExtend()
        {
            // ensures the implicit BBCodeBlock style is used
            this.DefaultStyleKey = typeof(UserControlExtend);
        }

        /// <summary>
        /// Gets or sets the BB code.
        /// </summary>
        /// <value>The BB code.</value>
        public bool IsChromiumable
        {
            get { return (bool)GetValue(IsChromiumableProperty); }
            set { SetValue(IsChromiumableProperty, value); }
        }

        private static void OnUrlChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var ok = (o as UserControlExtend).IsChromiumable;
        }
    }
}