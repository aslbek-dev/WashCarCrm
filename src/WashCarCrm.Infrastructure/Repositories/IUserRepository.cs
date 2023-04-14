using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.Repositories
{
   public interface IUserRepository : IGenericRepository<User, int>
    {
        ValueTask<User> InsertUserAsync(User User);
        IQueryable<User> SelectAllUsers();
        ValueTask<User> SelectUserByIdAsync(int id);
        ValueTask<User> UpdateUserAsync(User User);
        ValueTask<User> DeleteUserAsync(User User);
    }
}