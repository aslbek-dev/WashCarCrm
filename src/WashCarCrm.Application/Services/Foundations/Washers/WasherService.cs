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
        public async ValueTask<Washer> AddWasherAsync(Washer Washer)
        {
            
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

        public async ValueTask<Washer> ModifyWasherAsync(Washer Washer)
        {
            return await this.WasherRepository.UpdateWasherAsync(Washer);
        }

        public async ValueTask<Washer> RemoveWasherByIdAsync(Washer Washer)
        {
            return await this.WasherRepository.DeleteWasherAsync(Washer);
        }
    }
}