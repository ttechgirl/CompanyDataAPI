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
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDto?>> GetDepartments();
        Task<DepartmentDto?> GetDepartment(Guid id);
        Task<DepartmentDto?> CreateDepartment(DepartmentViewModel model);
        Task UpdateDepartment(Guid id, DepartmentViewModel model);
        Task DeleteDepartment(Guid id);


    }
}
