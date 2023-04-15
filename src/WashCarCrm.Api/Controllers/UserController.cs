using WashCarCrm.Application.Foundations.Users;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IUserService UserService;
        public UserController(IUserService orederService)
        {
            this.UserService = UserService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync(User User)
        {
            try
            {
                return await this.UserService.AddUserAsync(User);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<User>> GetAllUsers()
        {
            try
            {
                IQueryable<User> allUsers = this.UserService.RetrieveAllUsers();

                return Ok(allUsers);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("{UserId}")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(int id)
        {
            try
            {
                return await this.UserService.RetrieveUserByIdAsync(id);
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        [HttpPut]
        public async ValueTask<ActionResult<User>> PutUserAsync(User User)
        {
            try
            {
                User modifiedUser = await this.UserService.ModifyUserAsync(User);

                return Ok(modifiedUser);
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpDelete("{UserId}")]
        public async ValueTask<ActionResult<User>> DeleteUserByIdAsync(int id)
        {
            try
            {
                User deletedUser = await this.UserService.RemoveUserByIdAsync(id);

                return Ok(deletedUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}