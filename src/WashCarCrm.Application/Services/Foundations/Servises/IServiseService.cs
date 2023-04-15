using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Foundations.Servises
{
    public interface IServiseService
    {
        ValueTask<Service> AddServiceAsync(Service Service);
        IQueryable<Service> RetrieveAllServices();
        ValueTask<Service> RetrieveServiceByIdAsync(int id);
        ValueTask<Service> ModifyServiceAsync(Service Service);
        ValueTask<Service> RemoveServiceByIdAsync(Service Service);
    }
}