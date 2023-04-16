using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Foundations.Services
{
    public interface IServiceService
    {
        ValueTask<Service> AddServiceAsync(int washCompanyId, Service service);
        IQueryable<Service> RetrieveAllServices();
        ValueTask<Service> RetrieveServiceByIdAsync(int id);
        ValueTask<Service> ModifyServiceAsync(int washCompany, Service service);
        ValueTask<Service> RemoveServiceByIdAsync(int id);
    }
}