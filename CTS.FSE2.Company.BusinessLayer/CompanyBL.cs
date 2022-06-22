using CTS.FSE2.Company.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.FSE2.Company.BusinessLayer
{
    public class CompanyBL : ICompanyBL
    {
        public readonly ICompanyRepository _icompanyRepository;
        public CompanyBL(ICompanyRepository companyRepository)
        {
            _icompanyRepository = companyRepository;
        }

        public string Addcompanyasync(CompanyDTO c)
        {
            CompanyBE company = new CompanyBE
            {
                CompanyCEO = c.CompanyCEO,
                CompanyCode = c.CompanyCode,
                CompanyName = c.CompanyName,
                CompanyTurnOver = c.CompanyTurnOver,
                CompanyWebsite = c.CompanyWebsite,
                StockExchange = c.StockExchange
            };
            if (!_icompanyRepository.Iscodeexist(company.CompanyCode))
            {
                _icompanyRepository.Addcompanyasync(company);
                return "";
            }
            else
            {
                return "Company Code Already Exists";
            }
        }
        public StockMarketDTO GetCompany(string code)
        {
            StockMarketPriceDTO stockMarketDTO = null;
            var result = _icompanyRepository.GetCompany(code);
            if (result != null)
            {
                if (result.stockMarketPrices != null)
                {
                    foreach (var stock in result.stockMarketPrices)
                    {
                        stockMarketDTO = new StockMarketPriceDTO
                        {
                            StockDate = stock.StockDate.ToString("d"),
                            StockTime = stock.StockDate.ToString("hh:mm tt"),
                            StockPrice = stock.StockPrice
                        };
                    }
                }

                return new StockMarketDTO
                {
                    CompanyCEO = result.CompanyCEO,
                    CompanyCode = result.CompanyCode,
                    CompanyName = result.CompanyName,
                    CompanyTurnOver = result.CompanyTurnOver,
                    CompanyWebsite = result.CompanyWebsite,
                    StockExchange = result.StockExchange,
                    stockMarketPriceDTO = stockMarketDTO
                };
            }
            return null;
        }
        public List<StockMarketDTO> GetallCompanies()
        {
            List<StockMarketDTO> companies = new List<StockMarketDTO>();
            StockMarketPriceDTO stockMarketDTO = null;
            var result = _icompanyRepository.GetallCompanies();
            if (result != null)
            {
                foreach (var stock in result)
                {
                    if (stock.stockMarketPrices.Count > 0)
                    {
                        foreach (var val in stock.stockMarketPrices)
                        {
                            stockMarketDTO = new StockMarketPriceDTO
                            {
                                StockDate = val.StockDate.ToString("d"),
                                StockTime = val.StockDate.ToString("hh:mm tt"),
                                StockPrice = val.StockPrice
                            };
                        }
                    }
                    else
                    {
                        stockMarketDTO = null;
                    }
                    companies.Add(new StockMarketDTO
                    {
                        CompanyCEO = stock.CompanyCEO,
                        CompanyCode = stock.CompanyCode,
                        CompanyName = stock.CompanyName,
                        CompanyTurnOver = stock.CompanyTurnOver,
                        CompanyWebsite = stock.CompanyWebsite,
                        StockExchange = stock.StockExchange,
                        stockMarketPriceDTO = stockMarketDTO
                    });
                }
                return companies;
            }
            return null;
        }

        public void delete(string code)
        {
            if (_icompanyRepository.Iscodeexist(code))
            {
                _icompanyRepository.delete(code);
            }
        }

    }
}
