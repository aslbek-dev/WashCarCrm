using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Context;

namespace WashCarCrm.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {  }

        public ValueTask<User> InsertUserAsync(User User)=>
            base.InsertAsync(User);
        public IQueryable<User> SelectAllUsers() =>
            base.SelectAll();
        public ValueTask<User> SelectUserByIdAsync(int id) =>
             base.SelectByIdAsync(id);
        public ValueTask<User> UpdateUserAsync(User User) =>
            base.UpdateAsync(User);

        public ValueTask<User> DeleteUserAsync(User User) =>
            base.DeleteAsync(User);
    }
}