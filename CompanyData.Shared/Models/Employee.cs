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
        public Guid Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public string? JobRole { get; set; }
        public Guid? Supervisor { get; set; }
        [DisplayName("Wages($)")]
        public double WagesInDollar{ get; set; }
       // [ForeignKey("Company")]
        public Guid CompanyId { get; set; }

    }
}
