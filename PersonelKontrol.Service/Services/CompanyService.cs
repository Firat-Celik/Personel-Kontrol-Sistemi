using InfrastructureLayer.Repositories.Interfaces;
using PersonelKontrol.Domain.Entities.Concrates;
using PersonelKontrol.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKontrol.Service.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryBase<Firma> _repository;

        public CompanyService(IRepositoryBase<Firma> repository)
        {
            _repository = repository;
        }




        public async Task<IEnumerable<Firma>> GetAllCompanyAsync()
        {
            
            return await _repository.GetAll();
        }

        public async Task<Firma> GetCompany(int id)
        {
            return await _repository.GetById(id);
        }

        public async void InsertCompany(Firma Company)
        {
            await _repository.Add(Company);
        }

        public async void UpdateCompany(Firma Company)
        {
            await _repository.Update(Company);
        }
        public async void DeleteCompany(int id)
        {
            var Company = await GetCompany(id);
            await _repository.Remove(Company);

        }

    }
}
