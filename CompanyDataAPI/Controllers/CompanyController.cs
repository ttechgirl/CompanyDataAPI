using CompanyData.Shared.Dto;
using CompanyData.Shared.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet("get-companies")]
        public async Task<IActionResult> GetACompanies()
        {
            var companies = await _companyRepository.GetCompanies();
            return Ok(companies);
        }

        [HttpGet("get-company-{Id}",Name = "CompanyById")]
        public async Task<IActionResult> GetACompany(Guid Id)
        {
            var company = await _companyRepository.GetCompany(Id);
            if(company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost("create-company")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateDto company)
        {
            var createdCompany = await _companyRepository.CreateCompany(company);
            if (createdCompany == null)
            {
                return BadRequest();
            }
           //return Ok(createdCompany);
           return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

    }
}
