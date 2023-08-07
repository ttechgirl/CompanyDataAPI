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

        [HttpGet("Get-Companies")]
        public async Task<IActionResult> GetACompanies()
        {
            var companies = await _companyRepository.GetCompanies();
            return Ok(companies);
        }

        [HttpGet("Get-Company/{Id}",Name = "CompanyById")] 
        public async Task<IActionResult> GetACompany(Guid Id)
        {
            var company = await _companyRepository.GetCompany(Id);
            if(company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost("Create-Company")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto company)
        {
            var createdCompany = await _companyRepository.CreateCompany(company);
            if (createdCompany == null)
            {
                return BadRequest();
            }
           //return Ok(createdCompany);
           return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPut("Update-Company/{Id}")]
        public async Task<IActionResult> UpdateCompany(Guid Id, [FromBody] UpdateCompanyDto company)
        {
            var getCompany =await _companyRepository.GetCompany(Id);
            if (getCompany == null)
                return NotFound();

           await _companyRepository.UpdateCompany(Id, company); 
            return Ok(getCompany);
        }

        [HttpDelete("Delete-Company/{Id}")]
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
