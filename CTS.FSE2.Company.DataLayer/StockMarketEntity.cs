using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.FSE2.Company.DataLayer
{
   public class StockMarketEntity
    {
        public ObjectId _id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCEO { get; set; }
        public int CompanyTurnOver { get; set; }
        public string CompanyWebsite { get; set; }
        public string StockExchange { get; set; }
       public List<StockMarketPrice> stockMarketPrices { get; set; }
    }
    public class StockMarketPrice
    {
        public ObjectId _id { get; set; }
        public string CompanyCode { get; set; }
        public double StockPrice { get; set; }
        public DateTime StockDate { get; set; }
    }
}
