using CTS.FSE2.Company.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS.FSE2.CompanyAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/market/company/")]
    public class CompanyController : ControllerBase
    {
        public readonly ICompanyBL _companyBL;
        public CompanyController(ICompanyBL companyBL)
        {
            _companyBL = companyBL;
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(CompanyDTO c)
        {
            if (ModelState.IsValid)
            {
               var status =  _companyBL.Addcompanyasync(c).ToString();
                if (status != "")
                {
                    return Conflict(status);
                }
                return Ok("Company Registered");
            }
            return BadRequest("Invalid data");
        }

        [HttpGet]
        [Route("Info")]
        public IActionResult GetCompanybyCode(string code)
        {
            var result = _companyBL.GetCompany(code);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Company not found");
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetallCompanies()
        {
            var result = _companyBL.GetallCompanies();
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult deleteCompany(string code)
        {
             _companyBL.delete(code);

            return NoContent();
        }
    }
}
