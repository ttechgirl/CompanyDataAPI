using CompanyData.Shared.Dto;
using CompanyData.Shared.Services.Interface;
using CompanyData.Shared.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _companyDepartment;
        public DepartmentController(IDepartmentRepository companyDepartment)
        {
            _companyDepartment = companyDepartment;
        }

        [HttpGet("get-department")]
        public async Task<IActionResult> GetACompanies()
        {
            var companies = await _companyDepartment.GetDepartments();
            return Ok(companies);
        }

        [HttpGet("get-department/{id}", Name = "CompanyById")] 
        public async Task<IActionResult> GetDepartment(Guid id)
        {
            var company = await _companyDepartment.GetDepartment(id);
            if(company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost("create-department")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentViewModel model)
        {
            var response = await _companyDepartment.CreateDepartment(model);
            if (response == null)
            {
                return BadRequest();
            }
           return CreatedAtRoute("CompanyById", new { id = response.Id }, response);
        }

        [HttpPut("update-department/{id}")]
        public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] DepartmentViewModel model)
        {
            var response = await _companyDepartment.GetDepartment(id);
            if (response == null)
                return NotFound();

           await _companyDepartment.UpdateDepartment(id, model); 
            return Ok(response);
        }

        [HttpDelete("delete-department/{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid Id)
        { 
            var response = await _companyDepartment.GetDepartment(Id);
            if(response == null)
                return NotFound();

            await _companyDepartment.DeleteDepartment(Id); 
            return NoContent();
        }
    }
}
