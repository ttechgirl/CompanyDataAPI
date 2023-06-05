using CompanyData.Shared.Dto;
using CompanyData.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Services.Interface
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company?>> GetCompanies();
        Task<Company?> GetCompany(Guid Id);
        Task<Company?> CreateCompany(CreateDto company);
        Task<Company?> UpdateCompany(UpdateDto company);
        Task<Company?> DeleteCompany(Guid Id);


    }
}
