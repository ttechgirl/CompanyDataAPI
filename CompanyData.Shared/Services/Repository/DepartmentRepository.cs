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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ConfigDbContext _dbContext;

        public DepartmentRepository(ConfigDbContext dbContext)
        {
            _dbContext =dbContext;
        }

        public async Task<DepartmentDto?> CreateDepartment(DepartmentViewModel model)
        {

            var query = "INSERT INTO Department(Name,Supervisor,CreatedOn) " +
                       " VALUES (@Name,@Supervisor,@CreatedOn)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", model.Name);
            parameters.Add("Supervisor", model.Supervisor);
            parameters.Add("CreatedOn", DateTime.Now);


            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
               
                return (DepartmentDto)model;
            }
        }

        public async Task DeleteDepartment(Guid id)
        {

            var query = "DELETE FROM Department WHERE Id=@Id";
            using(var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,new {id});
            }
        }

        public async Task<IEnumerable<DepartmentDto?>> GetDepartments()
        {
            var query = "SELECT * FROM Department ";
            using (var connection = _dbContext.CreateConnection())
            {
                var response = await connection.QueryAsync<DepartmentDto>(query);
                return response.ToList();  
            }
        }

        public async Task<DepartmentDto?> GetDepartment(Guid id)
        {

            var query = "SELECT * FROM Department WHERE Id =@id ";
           
            using (var connection = _dbContext.CreateConnection())
            {
                var department = await connection.QueryFirstOrDefaultAsync<DepartmentDto>(query,new {id});
                return department;
            }
        }

        public async Task UpdateDepartment(Guid id, DepartmentViewModel model)
        {

            var query = "UPDATE Department " +
                        "SET Name=@Name ,Supervisor = @Supervisor,ModifiedOn=@ModifiedOn WHERE Id = @id ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("Name", model.Name);
            parameters.Add("Supervisor", model.Supervisor);
            parameters.Add("ModifiedOn", DateTime.Now);

            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
