using WashCarCrm.Application.Foundations.Services;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ServiceController : RESTFulController
    {
        private readonly IServiceService serviceService;
        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }
        [HttpPost("{washCompanyId}/insertService")]
        public async ValueTask<ActionResult<Service>> PostServiceAsync(int washCompanyId, Service service)
        {
            try
            {
                return await this.serviceService.AddServiceAsync(washCompanyId, service);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<Service>> GetAllServices()
        {
            try
            {
                IQueryable<Service> allServices = this.serviceService.RetrieveAllServices();

                return Ok(allServices);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("{serviceId}")]
        public async ValueTask<ActionResult<Service>> GetServiceByIdAsync(int serviceId)
        {
            try
            {
                return await this.serviceService.RetrieveServiceByIdAsync(serviceId);
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        [HttpPut("{washCompanyId}/updateService")]
        public async ValueTask<ActionResult<Service>> PutServiceAsync(int washCompanyId,Service Service)
        {
            try
            {
                Service modifiedService = await this.serviceService.ModifyServiceAsync(washCompanyId, Service);

                return Ok(modifiedService);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}