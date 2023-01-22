

using PersonelKontrol.Application.DTOs;
using PersonelKontrol.Domain.Entities.Concrates;

namespace PersonelKontrol.Service.Interface
{
    public interface IEmployeeMovementsService
    {
        Task<bool> DeleteEmployeeMovements(int id);
        Task<List<PersonelHareketleri>> GetEmployeeMovementListByPersonelId(int id);
        Task<IEnumerable<PersonelHareketleri>> GetAllEmployeeMovementsAsync();
        Task<PersonelHareketleri> GetEmployeeMovements(int id);
        Task<bool> InsertEmployeeMovements(AddEmployeeMovementsDto EmployeeMovements);
        Task<bool> UpdateEmployeeMovements(AddEmployeeMovementsDto EmployeeMovements);
    }
}
