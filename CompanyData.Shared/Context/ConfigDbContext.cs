using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Context
{
    public class ConfigDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ConfigDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectingToDB");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
