using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.FSE2.Company.DataLayer
{
   public interface ICompanyRepository
    {
        public void Addcompanyasync(CompanyBE c);
        public bool Iscodeexist(string code);
        public StockMarketEntity GetCompany(string code);
        public List<StockMarketEntity> GetallCompanies();
        public void delete(string code);

    }
}
