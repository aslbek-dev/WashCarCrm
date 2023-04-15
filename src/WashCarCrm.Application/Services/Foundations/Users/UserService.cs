using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Repositories;

namespace WashCarCrm.Application.Foundations.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        public UserService(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }
        public async ValueTask<User> AddUserAsync(User User)
        {
            
           return await this.UserRepository.InsertUserAsync(User);
        }
        public IQueryable<User> RetrieveAllUsers()
        {
            return this.UserRepository.SelectAll();
        }

        public async ValueTask<User> RetrieveUserByIdAsync(int id)
        {
            return await this.UserRepository.SelectUserByIdAsync(id);
        }

        public async ValueTask<User> ModifyUserAsync(User User)
        {
            return await this.UserRepository.UpdateUserAsync(User);
        }

        public async ValueTask<User> RemoveUserByIdAsync(User User)
        {
            return await this.UserRepository.DeleteUserAsync(User);
        }
    }
}