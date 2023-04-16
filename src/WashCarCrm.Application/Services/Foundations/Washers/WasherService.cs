using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Repositories;

namespace WashCarCrm.Application.Foundations.Washers
{
    public class WasherService : IWasherService
    {
        private readonly IWasherRepository WasherRepository;
        public WasherService(IWasherRepository WasherRepository)
        {
            this.WasherRepository = WasherRepository;
        }
        public async ValueTask<Washer> AddWasherAsync(int washerCompanyId, Washer Washer)
        {
            Washer.WashCompanyId = washerCompanyId;
            return await this.WasherRepository.InsertWasherAsync(Washer);
        }
        public IQueryable<Washer> RetrieveAllWashers()
        {
            return this.WasherRepository.SelectAll();
        }

        public async ValueTask<Washer> RetrieveWasherByIdAsync(int id)
        {
            return await this.WasherRepository.SelectWasherByIdAsync(id);
        }

        public async ValueTask<Washer> ModifyWasherAsync(int washCompanyId, Washer Washer)
        {
            Washer.WashCompanyId = washCompanyId;
            return await this.WasherRepository.UpdateWasherAsync(Washer);
        }

        public async ValueTask<Washer> RemoveWasherByIdAsync(int id)
        {
            Washer maybeWasher = await this.WasherRepository.SelectWasherByIdAsync(id);
            return await this.WasherRepository.DeleteWasherAsync(maybeWasher);
        }
    }
}