using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Repositories;

namespace WashCarCrm.Application.Foundations.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository ServiceRepository;
        public ServiceService(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }
        public async ValueTask<Service> AddServiceAsync(int washCompanyId, Service service)
        {
            service.washCompanyId = washCompanyId;
           return await this.ServiceRepository.InsertServiceAsync(service);
        }
        public IQueryable<Service> RetrieveAllServices()
        {
            return this.ServiceRepository.SelectAll();
        }

        public async ValueTask<Service> RetrieveServiceByIdAsync(int id)
        {
            return await this.ServiceRepository.SelectServiceByIdAsync(id);
        }

        public async ValueTask<Service> ModifyServiceAsync(int washCompanyId, Service service)
        {
            service.washCompanyId = washCompanyId;
            return await this.ServiceRepository.UpdateServiceAsync(service);
        }

        public async ValueTask<Service> RemoveServiceByIdAsync(int id)
        {
            Service maybeService = await this.ServiceRepository.SelectServiceByIdAsync(id);
            return await this.ServiceRepository.DeleteServiceAsync(maybeService);
        }
    }
}