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

        public Task<EmployeeDto?> CreateEmployee(EmployeeViewModel company)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetCompanyByEmployeeId(Guid Id)
        {
            var sproc = "sp_get_employee";
            var parameters = new DynamicParameters();
            parameters.Add("id", Id ,DbType.Guid,ParameterDirection.Input);
            using(var connection = _dbContext.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<Company>
                             (sproc, parameters, commandType: CommandType.StoredProcedure);

                return company;
            }
        }

        public Task<EmployeeDto?> GetEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDto?>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeDetails(Guid Id, EmployeeViewModel company)
        {
            throw new NotImplementedException();
        }

        Task<EmployeeDto> IEmployeeRepository.GetCompanyByEmployeeId(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
