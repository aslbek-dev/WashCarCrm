using WashCarCrm.Application.Foundations.WashCompanies;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WashCompanyController : RESTFulController
    {
        private readonly IWashCompanyService WashCompanyService;
        public WashCompanyController(IWashCompanyService washCompanyService)
        {
            this.WashCompanyService = washCompanyService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<WashCompany>> PostWashCompanyAsync(WashCompany WashCompany)
        {
            try
            {
                return await this.WashCompanyService.AddWashCompanyAsync(WashCompany);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<WashCompany>> GetAllWashCompanys()
        {
            try
            {
                IQueryable<WashCompany> allWashCompanys = 
                    this.WashCompanyService.RetrieveAllWashCompanies();

                return Ok(allWashCompanys);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("{washCompanyId}")]
        public async ValueTask<ActionResult<WashCompany>> GetWashCompanyByIdAsync(int washCompanyId)
        {
            try
            {
                return await this.WashCompanyService.RetrieveWashCompanyByIdAsync(washCompanyId);
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        [HttpPut]
        public async ValueTask<ActionResult<WashCompany>> PutWashCompanyAsync(WashCompany WashCompany)
        {
            try
            {
                WashCompany modifiedWashCompany = 
                    await this.WashCompanyService.ModifyWashCompanyAsync(WashCompany);

                return Ok(modifiedWashCompany);
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpDelete("{washCompanyId}")]
        public async ValueTask<ActionResult<WashCompany>> DeleteWashCompanyByIdAsync(int washCompanyId)
        {
            try
            {
                WashCompany deletedWashCompany = 
                    await this.WashCompanyService.RemoveWashCompanyByIdAsync(washCompanyId);

                return Ok(deletedWashCompany);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}