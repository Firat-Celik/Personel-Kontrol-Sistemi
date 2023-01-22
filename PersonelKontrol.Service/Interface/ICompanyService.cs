using PersonelKontrol.Domain.Entities.Concrates;

namespace PersonelKontrol.Service.Services
{
    public interface ICompanyService
    {
        void DeleteCompany(int id);
        Task<IEnumerable<Firma>> GetAllCompanyAsync();
        Task<Firma> GetCompany(int id);
        void InsertCompany(Firma Company);
        void UpdateCompany(Firma Company);
    }
}