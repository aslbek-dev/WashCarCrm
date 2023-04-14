using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Context;

namespace WashCarCrm.Infrastructure.Repositories
{
    public class WashCompanyRepository : GenericRepository<WashCompany, int>, IWashCompanyRepository
    {
        public WashCompanyRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {  }

        public ValueTask<WashCompany> InsertWashCompanyAsync(WashCompany washCompany)=>
            base.InsertAsync(washCompany);
        public IQueryable<WashCompany> SelectAllWashCompanies() =>
            base.SelectAll();
        public ValueTask<WashCompany> SelectWashCompanyByIdAsync(int id) =>
             base.SelectByIdAsync(id);
        public ValueTask<WashCompany> UpdateWashCompanyAsync(WashCompany washCompany) =>
            base.UpdateAsync(washCompany);

        public ValueTask<WashCompany> DeleteWashCompanyAsync(WashCompany washCompany) =>
            base.DeleteAsync(washCompany);
    }
}