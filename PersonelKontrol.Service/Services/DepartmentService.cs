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
    public class DepartmentService 
    {
        private readonly IRepositoryBase<Sube> _repository;

        public DepartmentService(IRepositoryBase<Sube> repository)
        {
            _repository = repository;
        }

        //public void DeleteDepartment(int id)
        //{
        //    var Department = GetDepartment(id);
        //    _repository.Delete(Department);
        //    _repository.SaveChanges();
        //}
        //public void DeleteRangeDepartment(int id)
        //{
        //    var Department = GetDepartment(id);
        //    _repository.DeleteRange(Department);
        //    _repository.SaveChanges();
        //}

        //public IEnumerable<Sube> GetAllDepartment()
        //{
        //    return _repository.GetAll();
        //}

        //public Sube GetDepartment(int id)
        //{
        //    return _repository.Get(id);
        //}

        //public void InsertDepartment(Sube Department)
        //{
        //    _repository.Insert(Department);
        //}

        //public void UpdateDepartment(Sube Department)
        //{
        //    _repository.Update(Department);
        //}
    }
}
