using WashCarCrm.Application.Foundations.Services;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : RESTFulController
    {
        private readonly IServiceService serviceService;
        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<Service>> PostServiceAsync(Service Service)
        {
            try
            {
                return await this.serviceService.AddServiceAsync(Service);
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
        
        [HttpPut]
        public async ValueTask<ActionResult<Service>> PutServiceAsync(Service Service)
        {
            try
            {
                Service modifiedService = await this.serviceService.ModifyServiceAsync(Service);

                return Ok(modifiedService);
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpDelete("{serviceId}")]
        public async ValueTask<ActionResult<Service>> DeleteServiceByIdAsync(int serviceId)
        {
            try
            {
                Service deletedService = await this.serviceService.RemoveServiceByIdAsync(serviceId);

                return Ok(deletedService);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}