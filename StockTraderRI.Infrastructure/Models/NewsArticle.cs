using System;

namespace StockTraderRI.Infrastructure.Models
{
    public class NewsArticle
    {
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string IconUri { get; set; }
    }
}
