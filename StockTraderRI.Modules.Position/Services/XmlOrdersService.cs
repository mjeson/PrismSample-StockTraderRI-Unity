using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using StockTraderRI.Modules.Position.Interfaces;
using StockTraderRI.Modules.Position.Models;
using StockTraderRI.Modules.Position.Properties;

namespace StockTraderRI.Modules.Position.Services
{
    public class XmlOrdersService : IOrdersService
    {
        private string _fileName = "SubmittedOrders.xml";

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public void Submit(Order order)
        {
            XDocument document = File.Exists(FileName) ? XDocument.Load(FileName) : new XDocument();
            Submit(order, document);
            document.Save(FileName);
        }

        public void Submit(Order order, XDocument document)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            var ordersElement = document.Element("Orders");
            if (ordersElement == null)
            {
                ordersElement = new XElement("Orders");
                document.Add(ordersElement);
            }

            var orderElement = new XElement("Order",
                new XAttribute("OrderType", order.OrderType),
                new XAttribute("Shares", order.Shares),
                new XAttribute("StopLimitPrice", order.StopLimitPrice),
                new XAttribute("TickerSymbol", order.TickerSymbol),
                new XAttribute("TimeInForce", order.TimeInForce),
                new XAttribute("TransactionType", order.TransactionType),
                new XAttribute("Date", DateTime.Now.ToString(CultureInfo.InvariantCulture))
                );
            ordersElement.Add(orderElement);

            string message = String.Format(CultureInfo.CurrentCulture, Resources.LogOrderSubmitted,
                                           orderElement.ToString());
            //TODO@GhZe: Use Log to log the message
            Console.WriteLine(message + "Category.Debug " + "Priority.Low");
        }
    }
}