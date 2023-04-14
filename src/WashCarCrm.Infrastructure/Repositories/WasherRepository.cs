using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Context;

namespace WashCarCrm.Infrastructure.Repositories
{
    public class WasherRepository : GenericRepository<Washer, int>, IWasherRepository
    {
        public WasherRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {  }

        public ValueTask<Washer> InsertWasherAsync(Washer Washer)=>
            base.InsertAsync(Washer);
        public IQueryable<Washer> SelectAllWashers() =>
            base.SelectAll();
        public ValueTask<Washer> SelectWasherByIdAsync(int id) =>
             base.SelectByIdAsync(id);
        public ValueTask<Washer> UpdateWasherAsync(Washer Washer) =>
            base.UpdateAsync(Washer);

        public ValueTask<Washer> DeleteWasherAsync(Washer Washer) =>
            base.DeleteAsync(Washer);

    }
}