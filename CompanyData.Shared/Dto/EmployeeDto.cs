using CompanyData.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Dto
{
    public record EmployeeDto(Guid Id, string? Address, string? City);
   
}
