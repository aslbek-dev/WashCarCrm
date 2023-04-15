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
        public WasherController(IWasherService orederService)
        {
            this.WasherService = WasherService;
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

        [HttpGet("{WasherId}")]
        public async ValueTask<ActionResult<Washer>> GetWasherByIdAsync(int id)
        {
            try
            {
                return await this.WasherService.RetrieveWasherByIdAsync(id);
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
        [HttpDelete("{WasherId}")]
        public async ValueTask<ActionResult<Washer>> DeleteWasherByIdAsync(int id)
        {
            try
            {
                Washer deletedWasher = await this.WasherService.RemoveWasherByIdAsync(id);

                return Ok(deletedWasher);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}