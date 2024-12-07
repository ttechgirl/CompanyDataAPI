using CompanyData.Shared.Dto;
using CompanyDataAPI.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.ViewModel
{
    public class EmployeeViewModel
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? JobRole { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int Gender { get; set; }
        public double WagesInDollar { get; set; }
        public Guid DepartmentId { get; set; }


        public static explicit operator EmployeeDto(EmployeeViewModel source)
        {
            var destination = new EmployeeDto
            {
                LastName = source.LastName,
                FirstName = source.FirstName,
                MiddleName = source.MiddleName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                Address = source.Address,
                JobRole = source.JobRole,
                City = source.City,
                State = source.State,
                Gender =(Gender)source.Gender,
                WagesInDollar = source.WagesInDollar,
                DepartmentId = source.DepartmentId,
            };
            return destination;
        }
    }
}
