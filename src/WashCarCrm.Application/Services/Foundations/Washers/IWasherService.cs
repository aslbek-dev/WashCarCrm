using System;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Foundations.Washers
{
    public interface IWasherService
    {
        ValueTask<Washer> AddWasherAsync(int washCompanyId, Washer Washer);
        IQueryable<Washer> RetrieveAllWashers();
        ValueTask<Washer> RetrieveWasherByIdAsync(int id);
        ValueTask<Washer> ModifyWasherAsync(int washCompanyId, Washer Washer);
        ValueTask<Washer> RemoveWasherByIdAsync(int id);
    }
}