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

        public async Task<Company?> CreateCompany(CreateCompanyDto company)
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
                await connection.ExecuteAsync(query,parameters);
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

        public async Task DeleteCompany(Guid id)
        {
            var query = "DELETE FROM Company WHERE Id=@Id";
            using(var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,new {id});
            }
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

        public async Task<Company?> GetCompany(Guid id)
        {
            var query = "SELECT * FROM Company WHERE id=@id ";
            var query1= "SELECT * FROM Employee WHERE CompanyId= @id";
           
            using (var connection = _dbContext.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<Company>(query,new {id});
                var employee = await connection.QueryAsync<Employee>(query1, new { id }) ;
                company.Employees= employee.ToList();
                return company;
            }
        }

        public async Task UpdateCompany(Guid id, UpdateCompanyDto company)
        {
            var query = "UPDATE Company " +
                        "SET address=@Address,city=@City,state= @State";
            var parameters = new DynamicParameters();
            parameters.Add("id", id,DbType.Guid);
            parameters.Add("address", company.Address);
            parameters.Add("city", company.City);
            parameters.Add("state", company.State);

            using(var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
