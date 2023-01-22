using AutoMapper;
using InfrastructureLayer.Repositories.Interfaces;
using PersonelKontrol.Application.DTOs;
using PersonelKontrol.Domain.Entities.Concrates;
using PersonelKontrol.Service.Interface;
using System;
namespace PersonelKontrol.Service.Services
{
    public class EmployeeMovementsService : IEmployeeMovementsService
    {
        private readonly IRepositoryBase<PersonelHareketleri> _repository;

        public EmployeeMovementsService(IRepositoryBase<PersonelHareketleri> repository)
        {
            _repository = repository;
        }



        public Task<IEnumerable<PersonelHareketleri>> GetAllEmployeeMovementsAsync()
        {
         
            return _repository.GetAll();
        }
        public async Task<List<PersonelHareketleri>> GetEmployeeMovementListByPersonelId(int id)
        {
            return  _repository.GetWhere(x=>x.PersonelId==id&&x.AktifMi==true&&x.SilindiMi==false).Result.ToList();
        }
        public async Task<PersonelHareketleri> GetEmployeeMovements(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> InsertEmployeeMovements(AddEmployeeMovementsDto EmployeeMovements)
        {
            //Map İşlemini araştırmaya vaktim yetmedi klasik yöntemle yapıyorum
            var newData = new PersonelHareketleri();
            newData.PersonelId = EmployeeMovements.PersonelId;
            newData.Tarih = EmployeeMovements.Tarih;
            newData.GirisSaati = EmployeeMovements.GirisSaati;
            newData.CikisSaati = EmployeeMovements.CikisSaati;
            newData.AktifMi = EmployeeMovements.AktifMi;
            newData.OlusturulmaZamani = DateTime.Now;
            newData.SilindiMi = false;
            await _repository.Add(newData);
            return true;
        }

        public async Task<bool> UpdateEmployeeMovements(AddEmployeeMovementsDto EmployeeMovements)
        {
            //Map İşlemini araştırmaya vaktim yetmedi klasik yöntemle yapıyorum
            var newData = await _repository.FirstOrDefault(x => x.Id == EmployeeMovements.Id && x.AktifMi == true && x.SilindiMi == false);
            newData.PersonelId = EmployeeMovements.PersonelId;
            newData.Tarih = EmployeeMovements.Tarih;
            newData.GirisSaati = EmployeeMovements.GirisSaati;
            newData.CikisSaati = EmployeeMovements.CikisSaati;
            newData.AktifMi = EmployeeMovements.AktifMi;
            newData.DuzenlenmeZamani = DateTime.Now; 
            await _repository.Update(newData);
            return true;
        }
        public async Task<bool> DeleteEmployeeMovements(int id)
        {
            var EmployeeMovements = await GetEmployeeMovements(id);
            EmployeeMovements.AktifMi = false;
            EmployeeMovements.SilindiMi = true;
            await _repository.Update(EmployeeMovements);
            return true;
        }

    }
}
