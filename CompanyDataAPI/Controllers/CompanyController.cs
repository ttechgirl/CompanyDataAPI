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

        [HttpGet("get-company/{id}",Name = "CompanyById")] 
        public async Task<IActionResult> GetACompany(Guid id)
        {
            var company = await _companyRepository.GetCompany(id);
            if(company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost("create-company")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto company)
        {
            var createdCompany = await _companyRepository.CreateCompany(company);
            if (createdCompany == null)
            {
                return BadRequest();
            }
           return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPut("update-company/{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyDto company)
        {
            var getCompany =await _companyRepository.GetCompany(id);
            if (getCompany == null)
                return NotFound();

           await _companyRepository.UpdateCompany(id, company); 
            return Ok(getCompany);
        }

        [HttpDelete("delete-company/{id}")]
        public async Task<IActionResult> DeleteCompany(Guid Id)
        { 
            var getCompany = await _companyRepository.GetCompany(Id);
            if(getCompany == null)
                return NotFound();
            await _companyRepository.DeleteCompany(Id); 
            return Ok(getCompany);
        }
    }
}
