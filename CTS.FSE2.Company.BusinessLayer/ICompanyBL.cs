using CTS.FSE2.Company.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.FSE2.Company.BusinessLayer
{
   public  interface ICompanyBL
    {
        public string Addcompanyasync(CompanyDTO c);
        public StockMarketDTO GetCompany(string code);
        public List<StockMarketDTO> GetallCompanies();
        public void delete(string code);
    }
}
