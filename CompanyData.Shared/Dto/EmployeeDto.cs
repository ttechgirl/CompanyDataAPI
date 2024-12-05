using CompanyData.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Dto
{
    public record EmployeeDto(
        Guid Id,
        string? LastName,
        string? FirstName,
        string? MiddleName ,
        string? PhoneNumber,
        string? Email ,
        string? Department ,
        string? Address ,
        string? JobRole,
        string? Supervisor,
        double WagesInDollar,
        Guid CompanyId
    );
    
}
