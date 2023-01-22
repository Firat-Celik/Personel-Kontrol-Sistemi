using PersonelKontrol.Domain.Entities.Concrates;

namespace PersonelKontrol.Service.Services
{
    public interface IEmployeeService
    {
        Task<bool> DeleteEmployee(int id);
        Task<IEnumerable<Personel>> GetAllEmployeeAsync();
        Task<Personel> GetEmployee(int id);
        Task<bool> InsertEmployee(Personel Employee);
        Task<bool> UpdateEmployee(Personel Employee);
    }
}