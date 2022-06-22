using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.FSE2.Company.DataLayer
{

    public class CompanyRepository : ICompanyRepository
    {

        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _db;
        public CompanyRepository(IOptions<DBModel> dbmodel)
        {
            _mongoClient = new MongoClient(dbmodel.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(dbmodel.Value.Database);
        }

        public void Addcompanyasync(CompanyBE c)
        {
            _db.GetCollection<CompanyBE>("company").InsertOne(c);

        }
        public bool Iscodeexist(string code)
        {
            return _db.GetCollection<CompanyBE>("company").Find(x => x.CompanyCode == code).Any();
        }

        public StockMarketEntity GetCompany(string code)
        {
            var stockmarketlist = _db.GetCollection<CompanyBE>("company").Aggregate()
               .Lookup("stock", "CompanyCode", "CompanyCode", "stockMarketPrices")
               .As<StockMarketEntity>().ToList();

            var result =  stockmarketlist.Where(x => x.CompanyCode == code).FirstOrDefault();

            //var result = _db.GetCollection<CompanyBE>("company").aggr.Find(x => x.CompanyCode == code).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public List<StockMarketEntity> GetallCompanies()
        {
            var stockmarketlist = _db.GetCollection<CompanyBE>("company").Aggregate()
                .Lookup("stock", "CompanyCode", "CompanyCode", "stockMarketPrices")
                .As<StockMarketEntity>().ToList();

            foreach (var stock in stockmarketlist)
            {
                if (stock.stockMarketPrices.Count > 1)
                {
                    var st = stock.stockMarketPrices.OrderByDescending(x => x.StockDate).First();
                    stock.stockMarketPrices.Clear();
                    stock.stockMarketPrices.Add(st);
                }
            }
            if (stockmarketlist != null)
            {
                return stockmarketlist;
            }
            else
            {
                return null;
            }
        }

        public void delete(string code)
        {
            _db.GetCollection<CompanyBE>("company").DeleteOne(x => x.CompanyCode == code);
            _db.GetCollection<StockBE>("stock").DeleteMany(x => x.CompanyCode == code);
        }
    }
}
