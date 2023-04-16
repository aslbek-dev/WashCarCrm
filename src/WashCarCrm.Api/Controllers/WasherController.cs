using WashCarCrm.Application.Foundations.Washers;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class WasherController : RESTFulController
    {
        private readonly IWasherService WasherService;
        public WasherController(IWasherService washerService)
        {
            this.WasherService = washerService;
        }
        [HttpPost("{washCompanyId}/insertWasher")]
        public async ValueTask<ActionResult<Washer>> PostWasherAsync(int washCompanyId, Washer Washer)
        {
            try
            {
                return await this.WasherService.AddWasherAsync(washCompanyId, Washer);
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpGet("{washCompanyId}/searchByName")]
        public ActionResult<IQueryable<Washer>> GetWasherByName([FromQuery] string name,int washCompanyId)
        {
            try
            {
                return Ok(this.WasherService.GetWasherByName(name));
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("allWashers")]
        public ActionResult<IQueryable<Washer>> GetAllWashers()
        {
            try
            {
                IQueryable<Washer> allWashers = this.WasherService.RetrieveAllWashers();

                return Ok(allWashers);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("{washerId}/getById")]
        public async ValueTask<ActionResult<Washer>> GetWasherByIdAsync(int washerId)
        {
            try
            {
                return await this.WasherService.RetrieveWasherByIdAsync(washerId);
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        [HttpPut("{washCompanyId}/updateWasher")]
        public async ValueTask<ActionResult<Washer>> PutWasherAsync(int washCompanyId, Washer Washer)
        {
            try
            {
                Washer modifiedWasher = await this.WasherService.ModifyWasherAsync(washCompanyId, Washer);

                return Ok(modifiedWasher);
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}