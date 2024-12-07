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

        [HttpGet("get-departments")]
        public async Task<IActionResult> GetDepartments()
        {
            var response = await _companyDepartment.GetDepartments();
            if (!response.Any())
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("get-department/{id}", Name = "DepartmentById")] 
        public async Task<IActionResult> GetDepartment(Guid id)
        {

            if (Guid.Empty.Equals(id))
            {
                return BadRequest("Invalid Id");
            }
            var response = await _companyDepartment.GetDepartment(id);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("create-department")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentViewModel model)
        {
            var response = await _companyDepartment.CreateDepartment(model);
            if (response == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("DepartmentById", new { id = response.Id }, response);
        }

        [HttpPut("update-department/{id}")]
        public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] DepartmentViewModel model)
        {

            if (Guid.Empty.Equals(id))
            {
                return BadRequest("Invalid Id");
            }
            if (ModelState == null)
            {
                return BadRequest("Kindly enter required fields");
            }
            var response = await _companyDepartment.GetDepartment(id);
            if (response == null)
                return NotFound();

           await _companyDepartment.UpdateDepartment(id, model); 
            return NoContent();
        }

        [HttpDelete("delete-department/{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {

            if (Guid.Empty.Equals(id))
            {
                return BadRequest("Invalid Id");
            }
            var response = await _companyDepartment.GetDepartment(id);
            if(response == null)
                return NotFound();

            await _companyDepartment.DeleteDepartment(id); 
            return NoContent();
        }
    }
}
