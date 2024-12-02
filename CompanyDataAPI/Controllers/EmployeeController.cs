using CompanyData.Shared.Services.Interface;
using CompanyData.Shared.Services.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("ByEmployee/{id}")]
        public async Task<IActionResult> GetCompanyByEmployeeId(Guid id)
        {
            var company = await _employeeRepository.GetCompanyByEmployeeId(id);
            if (company == null)
                return NotFound();

            return Ok(company);
            
        }
    }
}
