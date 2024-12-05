using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Models
{
    public class Department
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Supervisor { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? CreatedBy { get; set; } = "HR";
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; } 
        public string? ModifiedBy { get; set; } = "HR";
    }
}
