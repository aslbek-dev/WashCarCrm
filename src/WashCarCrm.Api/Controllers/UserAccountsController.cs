using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Application.Services.Orchestrations;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserAccountsController : RESTFulController
    {
        private readonly IUserSecurityOrchestrationService userSecurityOrchestrationService;
        public UserAccountsController(IUserSecurityOrchestrationService userSecurityOrchestrationService)
        {
            this.userSecurityOrchestrationService = userSecurityOrchestrationService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<User>> SignUpAsync(User user)
        {
            try
            {
                User createdUserAccount = await this.userSecurityOrchestrationService
                    .CreateUserAccountAsync(user);

                return Created(createdUserAccount);
            }
            catch(Exception)
            {
                throw;
            }

        }
        [HttpGet]
        public ActionResult<UserToken> Login(string email, string password)
        {
            try
            {
                return this.userSecurityOrchestrationService.CreateUserToken(email, password);
            }
            catch(InvalidUserCredentialOrchestrationsException invalidUserCredentialOrchestrationsException)
            {
                return BadRequest(invalidUserCredentialOrchestrationsException.Message);
            }
            catch(NotFoundUserException notFoundUserException)
            {
                return NotFound(notFoundUserException.Message);
            }
        }
    }
}