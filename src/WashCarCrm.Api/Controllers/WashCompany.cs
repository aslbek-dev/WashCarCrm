using WashCarCrm.Application.Foundations.WashCompanies;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WashCompanyController : RESTFulController
    {
        private readonly IWashCompanyService WashCompanyService;
        public WashCompanyController(IWashCompanyService orederService)
        {
            this.WashCompanyService = WashCompanyService;
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

        [HttpGet("{WashCompanyId}")]
        public async ValueTask<ActionResult<WashCompany>> GetWashCompanyByIdAsync(int id)
        {
            try
            {
                return await this.WashCompanyService.RetrieveWashCompanyByIdAsync(id);
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
        [HttpDelete("{WashCompanyId}")]
        public async ValueTask<ActionResult<WashCompany>> DeleteWashCompanyByIdAsync(int id)
        {
            try
            {
                WashCompany deletedWashCompany = 
                    await this.WashCompanyService.RemoveWashCompanyByIdAsync(id);

                return Ok(deletedWashCompany);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}