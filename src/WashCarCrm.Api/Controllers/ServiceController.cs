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
        private readonly IServiceService ServiceService;
        public ServiceController(IServiceService orederService)
        {
            this.ServiceService = ServiceService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<Service>> PostServiceAsync(Service Service)
        {
            try
            {
                return await this.ServiceService.AddServiceAsync(Service);
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
                IQueryable<Service> allServices = this.ServiceService.RetrieveAllServices();

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
                return await this.ServiceService.RetrieveServiceByIdAsync(id);
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
                Service modifiedService = await this.ServiceService.ModifyServiceAsync(Service);

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
                Service deletedService = await this.ServiceService.RemoveServiceByIdAsync(id);

                return Ok(deletedService);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}