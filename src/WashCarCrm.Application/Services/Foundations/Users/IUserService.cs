using System;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Foundations.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User User);
        IQueryable<User> RetrieveAllUsers();
        ValueTask<User> RetrieveUserByIdAsync(int id);
        ValueTask<User> ModifyUserAsync(User User);
        ValueTask<User> RemoveUserByIdAsync(User User);
    }
}