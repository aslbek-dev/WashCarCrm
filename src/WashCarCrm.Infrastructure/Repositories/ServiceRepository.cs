using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Context;

namespace WashCarCrm.Infrastructure.Repositories
{
    public class ServiceRepository : GenericRepository<Service, int>, IServiceRepository
    {
        public ServiceRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {  }

        public ValueTask<Service> InsertServiceAsync(Service Service)=>
            base.InsertAsync(Service);
        public IQueryable<Service> SelectAllServices() =>
            base.SelectAll();
        public ValueTask<Service> SelectServiceByIdAsync(int id) =>
             base.SelectByIdAsync(id);
        public ValueTask<Service> UpdateServiceAsync(Service Service) =>
            base.UpdateAsync(Service);

        public ValueTask<Service> DeleteServiceAsync(Service Service) =>
            base.DeleteAsync(Service);
    }
}