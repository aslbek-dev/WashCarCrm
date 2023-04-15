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
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync(User User)
        {
            try
            {
                return await this.userService.AddUserAsync(User);
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
                IQueryable<User> allUsers = this.userService.RetrieveAllUsers();

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
                return await this.userService.RetrieveUserByIdAsync(id);
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
                User modifiedUser = await this.userService.ModifyUserAsync(User);

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
                User deletedUser = await this.userService.RemoveUserByIdAsync(id);

                return Ok(deletedUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}