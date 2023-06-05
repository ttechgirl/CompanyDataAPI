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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CompanyData.Shared.Services.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ConfigDbContext _dbContext;

        public CompanyRepository(ConfigDbContext dbContext)
        {
            _dbContext =dbContext;
        }

        public async Task<Company?> CreateCompany(CreateDto company)
        {
            var query = "INSERT INTO Company(id,address,city,state) " +
                       " VALUES (@Id,@Address, @City, @State)";
            company.Id = Guid.NewGuid();
            var parameters = new DynamicParameters();
            parameters.Add("id", company.Id);
            parameters.Add("address", company.Address);
            parameters.Add("city", company.City);
            parameters.Add("state", company.State);

            using (var connection = _dbContext.CreateConnection())
            {
                var response= await connection.ExecuteAsync(query,parameters);

                var createdCompany = new Company
                {
                    Id = company.Id,
                    Address = company.Address,
                    City = company.City,
                    State = company.State,
                };
                return createdCompany;
            }
        }

        public Task<Company?> DeleteCompany(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<Company?>> GetCompanies()
        {
            var query = "SELECT * FROM Company ";
            using (var connection = _dbContext.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();  
            }
        }

        public async Task<Company?> GetCompany(Guid Id)
        {
            var query = "SELECT * FROM Company WHERE id=@Id ";
            var query1= "SELECT * FROM Employee WHERE CompanyId= @Id";
            if (query == null)
            {
                return null;
            }
            using (var connection = _dbContext.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<Company>(query,new {Id});
                var employee = await connection.QueryAsync<Employee>(query1, new { Id }) ;
                company.Employees= employee.ToList();
                return company;
            }
        }

        public Task<Company?> UpdateCompany(UpdateDto company)
        {
            throw new NotImplementedException();
        }
    }
}
