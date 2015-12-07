using System;
using System.Windows.Controls;
using Prism.Events;

namespace StockTraderRI.Modules.Position.PositionSummary
{
    public partial class PositionPieChartView : UserControl
    {
        public event EventHandler<DataEventArgs<string>> PositionSelected = delegate { };

        public PositionPieChartView()
        {
            InitializeComponent();
        }

        public IPositionPieChartViewModel Model
        {
            get
            {
                return this.DataContext as IPositionPieChartViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
