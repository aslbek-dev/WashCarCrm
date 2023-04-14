using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.Repositories
{
   public interface IServiceRepository : IGenericRepository<Service, int>
    {
        ValueTask<Service> InsertServiceAsync(Service Service);
        IQueryable<Service> SelectAllServices();
        ValueTask<Service> SelectServiceByIdAsync(int id);
        ValueTask<Service> UpdateServiceAsync(Service Service);
        ValueTask<Service> DeleteServiceAsync(Service Service);
    }
}