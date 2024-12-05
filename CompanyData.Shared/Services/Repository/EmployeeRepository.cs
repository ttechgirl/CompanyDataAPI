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
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Services.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly ConfigDbContext _dbContext;

        public EmployeeRepository(ConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateEmployee(EmployeeViewModel employee)
        {
            var query = "INSERT INTO Employee(lastName,firstName,middleName,phoneNumber,email,department,jobRole,wagesInDollar,address,departmentId) " +
                        " VALUES (@LastName, @FirstName,@MiddleName,@PhoneNumber,@Email,@Department,@JobRole,@Supervisor,@WagesInDollar,@Address,@DepartmentId)";

            var parameters = new DynamicParameters();
            parameters.Add("lastName", employee.FirstName);
            parameters.Add("firstName", employee.LastName);
            parameters.Add("middleName", employee.MiddleName);
            parameters.Add("phoneNumber", employee.PhoneNumber);
            parameters.Add("email", employee.Email);
            parameters.Add("jobRole", employee.JobRole);
            parameters.Add("wagesInDollar", employee.WagesInDollar);
            parameters.Add("address", employee.Address);
            parameters.Add("departmentId", employee.DepartmentId);

            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
            return;
        }

        public Task DeleteEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDto?> GetEmployee(Guid Id)
        {
            var sproc = "sp_get_employee";
            var parameters = new DynamicParameters();
            parameters.Add("id", Id, DbType.Guid, ParameterDirection.Input);
            using (var connection = _dbContext.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<EmployeeDto>
                             (sproc, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<EmployeeDto?>> GetEmployees()
        {
            var query = "SELECT * FROM Employee ";
            using (var connection = _dbContext.CreateConnection())
            {
                var employees = await connection.QueryAsync<EmployeeDto>(query);
                return employees.ToList();
            }
        }

        public async Task UpdateEmployeeDetails(Guid Id, EmployeeViewModel employee)
        {
            var query = "UPDATE Department " +
                       "SET lastName,firstName,middleName,phoneNumber,email,department,jobRole,wagesInDollar,address,departmentId,modifiedOn" +
                        " VALUES (@LastName, @FirstName,@MiddleName,@PhoneNumber,@Email,@Department,@JobRole,@Supervisor,@WagesInDollar,@Address,@DepartmentId,ModifiedOn)";
            var modifiedOn = DateTime.Now;
            var parameters = new DynamicParameters();
            parameters.Add("lastName", employee.FirstName);
            parameters.Add("firstName", employee.LastName);
            parameters.Add("middleName", employee.MiddleName);
            parameters.Add("phoneNumber", employee.PhoneNumber);
            parameters.Add("email", employee.Email);
            parameters.Add("jobRole", employee.JobRole);
            parameters.Add("wagesInDollar", employee.WagesInDollar);
            parameters.Add("address", employee.Address);
            parameters.Add("departmentId", employee.DepartmentId);

            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}
