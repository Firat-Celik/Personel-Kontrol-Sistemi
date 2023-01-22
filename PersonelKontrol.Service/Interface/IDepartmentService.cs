using PersonelKontrol.Domain.Entities.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKontrol.Service.Interface
{
    public interface IDepartmentService
    {
        IEnumerable<Sube> GetAllDepartment();
        Sube GetDepartment(int id);
        void InsertDepartment(Sube Department);
        void UpdateDepartment(Sube Department);
        void DeleteDepartment(int id);
    }
}
