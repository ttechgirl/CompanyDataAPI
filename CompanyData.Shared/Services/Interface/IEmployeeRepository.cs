using CompanyData.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Services.Interface
{
    public interface IEmployeeRepository
    {
        Task<Company> GetCompanyByEmployeeId(Guid Id);
    }
}
