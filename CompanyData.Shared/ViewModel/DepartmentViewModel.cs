using CompanyData.Shared.Dto;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.ViewModel
{
    public class DepartmentViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Supervisor { get; set; }
     

        public static explicit operator DepartmentViewModel(DepartmentDto source)
        {
            var destination = new DepartmentViewModel
            {
                Name = source.Name,
                Supervisor = source.Supervisor,
               
            };
            return destination;
        }

        public static explicit operator DepartmentDto(DepartmentViewModel source)
        {
            var destination = new DepartmentDto
            {
                Name = source.Name,
                Supervisor = source.Supervisor,
                
            };
            return destination;
        }
    }
}
