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

        [HttpGet("{userId}")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(int userId)
        {
            try
            {
                return await this.userService.RetrieveUserByIdAsync(userId);
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        [HttpDelete("{userId}")]
        public async ValueTask<ActionResult<User>> DeleteUserByIdAsync(int userId)
        {
            try
            {
                User deletedUser = await this.userService.RemoveUserByIdAsync(userId);

                return Ok(deletedUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}