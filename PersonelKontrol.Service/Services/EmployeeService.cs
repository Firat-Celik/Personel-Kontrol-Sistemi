

using InfrastructureLayer.Repositories.Interfaces;
using PersonelKontrol.Application.Dtos;
using PersonelKontrol.Domain.Entities.Concrates;
using PersonelKontrol.Service.Interface;
using System.Security.Cryptography.X509Certificates;

namespace PersonelKontrol.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryBase<Personel> _repository;
        private readonly IRepositoryBase<PersonelHareketleri> _repositoryEmployeeMovement;

        public EmployeeService(IRepositoryBase<Personel> repository, IRepositoryBase<PersonelHareketleri> repositoryEmployeeMovement)
        {
            _repository = repository;
            _repositoryEmployeeMovement = repositoryEmployeeMovement;
        }




        public Task<IEnumerable<Personel>> GetAllEmployeeAsync()
        {
            return _repository.GetAll();
        }

        public async Task<Personel> GetEmployee(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> InsertEmployee(Personel Employee)
        {
           
            await _repository.Add(Employee);
            return true;
        }

        public async Task<bool> UpdateEmployee(Personel Employee)
        { 
          
            await _repository.Update(Employee);
            return true;
        }
        public async Task<bool> DeleteEmployee(int id)
        {         

            var Employee = await GetEmployee(id);
            Employee.AktifMi = false;
            Employee.SilindiMi = true; 
            await _repository.Update(Employee);
            return true;
        }

    }
}