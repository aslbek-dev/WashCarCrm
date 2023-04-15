using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Repositories;

namespace WashCarCrm.Application.Foundations.WashCompanies
{
    public class WashCompanyService : IWashCompanyService
    {
        private readonly IWashCompanyRepository washCompanyRepository;
        public WashCompanyService(IWashCompanyRepository washCompanyRepository)
        {
            this.washCompanyRepository = washCompanyRepository;
        }
        public async ValueTask<WashCompany> AddWashCompanyAsync(WashCompany washCompany)
        {
            
           return await this.washCompanyRepository.InsertWashCompanyAsync(washCompany);
        }
        public IQueryable<WashCompany> RetrieveAllWashCompanies()
        {
            return this.washCompanyRepository.SelectAll();
        }

        public async ValueTask<WashCompany> RetrieveWashCompanyByIdAsync(int id)
        {
            return await this.washCompanyRepository.SelectWashCompanyByIdAsync(id);
        }

        public async ValueTask<WashCompany> ModifyWashCompanyAsync(WashCompany washCompany)
        {
            return await this.washCompanyRepository.UpdateWashCompanyAsync(washCompany);
        }

        public async ValueTask<WashCompany> RemoveWashCompanyByIdAsync(WashCompany washCompany)
        {
            return await this.washCompanyRepository.DeleteWashCompanyAsync(washCompany);
        }

    }
}