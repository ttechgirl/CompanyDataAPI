using CompanyData.Shared.Context;
using CompanyData.Shared.Models;
using CompanyData.Shared.Services.Interface;
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
    }
}
