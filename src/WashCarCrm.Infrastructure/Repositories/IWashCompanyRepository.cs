using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.Repositories
{
    public interface IWashCompanyRepository : IGenericRepository<WashCompany, int>
    {
        ValueTask<WashCompany> InsertWashCompanyAsync(WashCompany washCompany);
        IQueryable<WashCompany> SelectAllWashCompanies();
        ValueTask<WashCompany> SelectWashCompanyByIdAsync(int id);
        ValueTask<WashCompany> UpdateWashCompanyAsync(WashCompany washCompany);
        ValueTask<WashCompany> DeleteWashCompanyAsync(WashCompany washCompany);
    }
}