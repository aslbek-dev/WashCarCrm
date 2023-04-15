using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Foundations.WashCompanies
{
    public interface IWashCompanyService
    {
        ValueTask<WashCompany> AddWashCompanyAsync(WashCompany WashCompany);
        IQueryable<WashCompany> RetrieveAllWashCompanies();
        ValueTask<WashCompany> RetrieveWashCompanyByIdAsync(int id);
        ValueTask<WashCompany> ModifyWashCompanyAsync(WashCompany WashCompany);
        ValueTask<WashCompany> RemoveWashCompanyByIdAsync(int id);
    }
}