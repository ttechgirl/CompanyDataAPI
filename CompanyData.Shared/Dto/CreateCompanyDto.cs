﻿using CompanyData.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Dto
{
    public class CreateCompanyDto
    {
        public Guid Id { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
       // public List<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
