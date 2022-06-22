using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.FSE2.Company.BusinessLayer
{
   public class StockMarketDTO
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCEO { get; set; }
        public int CompanyTurnOver { get; set; }
        public string CompanyWebsite { get; set; }
        public string StockExchange { get; set; }
        public StockMarketPriceDTO stockMarketPriceDTO { get; set; }
    }
    public class StockMarketPriceDTO
    {
        public double StockPrice { get; set; }
        public string StockDate { get; set; }

        public string StockTime { get; set; }

    }

    public class CompanyStockMarketDTO
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCEO { get; set; }
        public int CompanyTurnOver { get; set; }
        public string CompanyWebsite { get; set; }
        public string StockExchange { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public double AvgPrice { get; set; }
        public List<CompanyStockMarketPriceDTO> stockMarketPrice { get; set; }
    }
    public class CompanyStockMarketPriceDTO
    {
        public double StockPrice { get; set; }
        public string StockDate { get; set; }
        public string StockTime { get; set; }

    }
}
