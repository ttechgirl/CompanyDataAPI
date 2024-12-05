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
        [DisplayName("Wages($)")]
        public double WagesInDollar { get; set; }
        public Guid DepartmentId { get; set; }

    }
}
