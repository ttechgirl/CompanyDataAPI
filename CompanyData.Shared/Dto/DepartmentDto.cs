﻿using CompanyData.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Dto
{
    public class DepartmentDto
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }
        public string? Supervisor { get; set; }
      
    }
}
