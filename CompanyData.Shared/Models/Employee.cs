using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? JobRole { get; set; }
        public double WagesInDollar{ get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public string? CreatedBy { get; set; } = "HR";
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; } 
        public string? ModifiedBy { get; set; } = "HR";

    }
}
