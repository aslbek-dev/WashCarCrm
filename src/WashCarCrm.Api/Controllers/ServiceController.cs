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

        [HttpGet("{ServiceId}")]
        public async ValueTask<ActionResult<Service>> GetServiceByIdAsync(int id)
        {
            try
            {
                return await this.serviceService.RetrieveServiceByIdAsync(id);
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
        [HttpDelete("{ServiceId}")]
        public async ValueTask<ActionResult<Service>> DeleteServiceByIdAsync(int id)
        {
            try
            {
                Service deletedService = await this.serviceService.RemoveServiceByIdAsync(id);

                return Ok(deletedService);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}