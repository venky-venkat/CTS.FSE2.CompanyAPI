using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTS.FSE2.Company.BusinessLayer
{
   public class CompanyDTO
    {
        [Required(ErrorMessage = "CompanyCode Required")]
        public string CompanyCode { get; set; }

        [Required(ErrorMessage = "CompanyName Required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "CompanyCEO Required")]
        public string CompanyCEO { get; set; }

        [Required(ErrorMessage = "CompanyTurnOver Required")]
        [Range(10, int.MaxValue, ErrorMessage = "CompanyTurnOver should be greater than 10 Cr")]
        public int CompanyTurnOver { get; set; }

        [Required(ErrorMessage = "CompanyWebsite Required")]
        public string CompanyWebsite { get; set; }

        [Required(ErrorMessage = "StockExchange Required")]
        public string StockExchange { get; set; }
    }
}
