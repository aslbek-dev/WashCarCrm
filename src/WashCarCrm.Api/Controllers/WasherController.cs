using WashCarCrm.Application.Foundations.Washers;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WasherController : RESTFulController
    {
        private readonly IWasherService WasherService;
        public WasherController(IWasherService washerService)
        {
            this.WasherService = washerService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<Washer>> PostWasherAsync(Washer Washer)
        {
            try
            {
                return await this.WasherService.AddWasherAsync(Washer);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
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

        [HttpGet("{washerId}")]
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
        
        [HttpPut]
        public async ValueTask<ActionResult<Washer>> PutWasherAsync(Washer Washer)
        {
            try
            {
                Washer modifiedWasher = await this.WasherService.ModifyWasherAsync(Washer);

                return Ok(modifiedWasher);
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpDelete("{washerId}")]
        public async ValueTask<ActionResult<Washer>> DeleteWasherByIdAsync(int washerId)
        {
            try
            {
                Washer deletedWasher = await this.WasherService.RemoveWasherByIdAsync(washerId);

                return Ok(deletedWasher);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}