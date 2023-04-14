using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.Repositories
{
    public interface IWasherRepository : IGenericRepository<Washer, int>
    {
        ValueTask<Washer> InsertWasherAsync(Washer Washer);
        IQueryable<Washer> SelectAllWashers();
        ValueTask<Washer> SelectWasherByIdAsync(int id);
        ValueTask<Washer> UpdateWasherAsync(Washer Washer);
        ValueTask<Washer> DeleteWasherAsync(Washer Washer);
    }
}