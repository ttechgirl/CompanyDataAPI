﻿using CompanyData.Shared.Dto;
using CompanyData.Shared.Models;
using CompanyData.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Services.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto?>> GetEmployees();
        Task<EmployeeDto?> GetEmployee(Guid id);
        Task<EmployeeDto> CreateEmployee(EmployeeViewModel employee);
        Task UpdateEmployeeDetails(Guid Id, EmployeeViewModel company);
        Task DeleteEmployee(Guid Id);
    }
}
