﻿using CompanyData.Shared.Context;
using CompanyData.Shared.Services.Repository;
using CompanyData.Shared.Services.Interface;
using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CompanyDataAPI
{
    public static partial class Startup
    {
        public static WebApplicationBuilder RegisterDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddSingleton<ConfigDbContext>();
            //builder.Services.AddSingleton<IDbConnection>(db =>
            //{
            //    var connectionstring = builder.Configuration.GetConnectionString("Default");
            //    var connection = new SqlConnection(connectionstring);
            //    return connection;
            //});

            return builder;
        }
    }
}
