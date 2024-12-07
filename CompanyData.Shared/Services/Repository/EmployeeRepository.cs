using CompanyData.Shared.Context;
using CompanyData.Shared.Dto;
using CompanyData.Shared.Models;
using CompanyData.Shared.Services.Interface;
using CompanyData.Shared.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Services.Repository
{
    
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly ConfigDbContext _dbContext;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeRepository(ConfigDbContext dbContext, IDepartmentRepository departmentRepository)
        {
            _dbContext = dbContext;
            _departmentRepository = departmentRepository;
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeViewModel employee)
        {
            var getDepartment = await _departmentRepository.GetDepartment(employee.DepartmentId);
            if(getDepartment == null)
            {

                return null;
            }

            var query = "INSERT INTO Employee(Id,LastName,FirstName,MiddleName,PhoneNumber,Email,JobRole,WagesInDollar,Address,City,State,DepartmentId,Gender,CreatedOn,IsDeleted) " +
                        " VALUES (@Id,@LastName, @FirstName,@MiddleName,@PhoneNumber,@Email,@JobRole,@WagesInDollar,@Address,@City,@State,@DepartmentId,@Gender,@CreatedOn,@IsDeleted)";

            var id = Guid.NewGuid();

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("LastName", employee.LastName);
            parameters.Add("FirstName", employee.FirstName);
            parameters.Add("MiddleName", employee.MiddleName);
            parameters.Add("PhoneNumber", employee.PhoneNumber);
            parameters.Add("Email", employee.Email);
            parameters.Add("JobRole", employee.JobRole);
            parameters.Add("WagesInDollar", employee.WagesInDollar);
            parameters.Add("Address", employee.Address);
            parameters.Add("DepartmentId", employee.DepartmentId);
            parameters.Add("City", employee.City);
            parameters.Add("State", employee.State);
            parameters.Add("Gender", employee.Gender);
            parameters.Add("CreatedOn", DateTime.Now);
            parameters.Add("IsDeleted", false);

            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
            var response= (EmployeeDto)employee;
            response.Id = id;
            return response;
        }

        public async Task DeleteEmployee(Guid Id)
        {
            
            var query = "UPDATE Employee " +
                        "SET IsDeleted = @IsDeleted,DeletedOn = @DeletedOn WHERE Id = @Id AND IsDeleted <> 1";

            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            parameters.Add("IsDeleted", true);
            parameters.Add("DeletedOn", DateTime.Now);
           
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<EmployeeDto?> GetEmployee(Guid id)
        {
            var query = "SELECT * FROM Employee WHERE Id =@id AND IsDeleted <> 1";

            using (var connection = _dbContext.CreateConnection())
            {
                var employee = await connection.QueryFirstOrDefaultAsync<EmployeeDto>(query, new { id });
                return employee;
            }
        }

        public async Task<IEnumerable<EmployeeDto?>> GetEmployees()
        {
            var query = "SELECT * FROM Employee WHERE IsDeleted <> 1";
            using (var connection = _dbContext.CreateConnection())
            {
                var employees = await connection.QueryAsync<EmployeeDto>(query);
                return employees.ToList();
            }
        }

        public async Task UpdateEmployeeDetails(Guid id, EmployeeViewModel employee)
        {
            var query = "UPDATE Employee " +
                       "SET LastName = @LastName,FirstName = @FirstName,MiddleName = @MiddleName,PhoneNumber = @PhoneNumber,Email = @Email,JobRole = @JobRole,Gender = @Gender" +
                       "WagesInDollar = @WagesInDollar,Address = @Address,City = @City,State =@State,DepartmentId = @DepartmentId,ModifiedOn = @ModifiedOn " +
                        "WHERE Id = @id AND IsDeleted <> 1";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("LastName", employee.LastName);
            parameters.Add("FirstName", employee.FirstName);
            parameters.Add("MiddleName", employee.MiddleName);
            parameters.Add("PhoneNumber", employee.PhoneNumber);
            parameters.Add("Email", employee.Email);
            parameters.Add("JobRole", employee.JobRole);
            parameters.Add("WagesInDollar", employee.WagesInDollar);
            parameters.Add("Address", employee.Address);
            parameters.Add("DepartmentId", employee.DepartmentId);
            parameters.Add("City", employee.City);
            parameters.Add("State", employee.State);
            parameters.Add("Gender", employee.Gender);
            parameters.Add("ModifiedOn", DateTime.Now);

            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
