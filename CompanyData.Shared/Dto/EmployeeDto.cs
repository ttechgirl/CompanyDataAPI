using CompanyData.Shared.Models;
using CompanyDataAPI.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; } 
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? JobRole { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public Gender Gender { get; set; }
        public double WagesInDollar { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
