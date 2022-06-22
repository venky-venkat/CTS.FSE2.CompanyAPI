using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTS.FSE2.Company.DataLayer
{
   public class StockBE
    {
      
        public string CompanyCode { get; set; }
        public double StockPrice { get; set; }
        public DateTime StockDate { get; set; }

    }
}
