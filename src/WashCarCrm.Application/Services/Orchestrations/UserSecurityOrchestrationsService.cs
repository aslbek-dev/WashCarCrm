using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Application.Foundations.Users;
using WashCarCrm.Application.Services.Foundations.Securities;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Services.Orchestrations
{
    public partial class UserSecurityOrchestrationsService: IUserSecurityOrchestrationService
    {
        private readonly IUserService userService;
        private readonly ISecurityService securityService;
        public UserSecurityOrchestrationsService(
            IUserService userService,
            ISecurityService securityService
        )
        {
            this.userService = userService;
            this.securityService = securityService;
        }

        public async ValueTask<User> CreateUserAccountAsync(User user)
        {

            User persistedUser = await this.userService.AddUserAsync(user);
            return persistedUser;
        }

        public UserToken CreateUserToken(string email, string password)
        {
            try
            {
                ValidateEmailAndPassword(email, password);
                User maybeUser = RetrieveUserByEmailAndPassword(email, password);
                ValidateUserExists(maybeUser);
                string token = this.securityService.CreateToken(maybeUser);

                return new UserToken
                {
                    UserId = maybeUser.Id,
                    Token = token
                };
            }
            catch(InvalidUserCredentialOrchestrationsException invalidUserCreadentialOrchestrationException)
            {
                throw invalidUserCreadentialOrchestrationException;
            }
            catch(NotFoundUserException notFoundUserException)
            {
                throw notFoundUserException;
            }
        }
        private User RetrieveUserByEmailAndPassword(string email, string password)
        {
            IQueryable<User> allUser = this.userService.RetrieveAllUsers();

            return allUser.FirstOrDefault(retrievedUser => retrievedUser.Email.Equals(email)
                    && retrievedUser.Password.Equals(password));
        }

    }
}