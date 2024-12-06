using CompanyData.Shared.Services.Interface;
using CompanyData.Shared.Services.Repository;
using CompanyData.Shared.ViewModel;
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

        [HttpGet("get-employees")]
        public async Task<IActionResult> GetACompanies()
        {
            var response = await _employeeRepository.GetEmployees();
            return Ok(response);
        }

        [HttpGet("get-employee/{id}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {

            if (Guid.Empty.Equals(id))
            {
                return BadRequest("Invalid Id");
            }
            var response = await _employeeRepository.GetEmployee(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeViewModel model)
        {
            var response = await _employeeRepository.CreateEmployee(model);
            if (response == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("EmployeeById", new { id = response.Id }, response);
        }

        [HttpPut("update-employee/{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeViewModel model)
        {
            if (Guid.Empty.Equals(id))
            {
                return BadRequest("Invalid Id");
            }
            var response = await _employeeRepository.GetEmployee(id);
            if (response == null)
                return NotFound();

            await _employeeRepository.UpdateEmployeeDetails(id, model);
            return Ok();
        }

        [HttpDelete("delete-employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {

            if (Guid.Empty.Equals(id))
            {
                return BadRequest("Invalid Id");
            }

            var response = await _employeeRepository.GetEmployee(id);
            if (response == null)
                return NotFound();

            await _employeeRepository.DeleteEmployee(id);
            return NoContent();
        }
    }
}
