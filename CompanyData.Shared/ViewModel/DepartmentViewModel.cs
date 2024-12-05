using CompanyData.Shared.Dto;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.ViewModel
{
    public class DepartmentViewModel
    {
        public string? Supervisor { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public static explicit operator DepartmentViewModel(DepartmentDto source)
        {
            var destination = new DepartmentViewModel
            {
                Supervisor = source.Supervisor,
                City = source.City,
                State = source.State,
            };
            return destination;
        }

        public static explicit operator DepartmentDto(DepartmentViewModel source)
        {
            var destination = new DepartmentDto
            {
                Supervisor = source.Supervisor,
                City = source.City,
                State = source.State,
            };
            return destination;
        }
    }
}
