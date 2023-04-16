using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Application.Foundations.Users;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Services.Processings
{
    public class UserProcessingService : IUserProcessingService
    {
        private readonly IUserService userService;
        public UserProcessingService(IUserService userService)
        {
            this.userService = userService;
        }
        public User RetrieveUserByCredentails(string email, string password)
        {
            IQueryable<User> allUser = this.userService.RetrieveAllUsers();

            return allUser.FirstOrDefault(retrievedUser => retrievedUser.Email.Equals(email)
                    && retrievedUser.Password.Equals(password));
        }
    }
}