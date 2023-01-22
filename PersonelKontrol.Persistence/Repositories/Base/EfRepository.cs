using InfrastructureLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using PersonelKontrol.Domain.Entities.Abstract;
using PersonelKontrol.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKontrol.Persistence.Repositories.Base
{
    public class EfRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {

        #region Fields

        protected PersonelDbContext Context;

        #endregion

        public EfRepository(PersonelDbContext context)
        {
            Context = context;
        }

        #region Public Methods

        public async Task<T> GetById(int id) =>await  Context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id&&x.AktifMi==true&&x.SilindiMi==false);

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => await Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            entity.OlusturulmaZamani = DateTime.Now;
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public   Task Update(T entity)
        {
            entity.DuzenlenmeZamani = DateTime.Now;
            Context.Entry(entity).State = EntityState.Modified;
            return   Context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return  Context.Set<T>().Where(x=>x.AktifMi==true&&x.SilindiMi==false).ToList();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => Context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().CountAsync(predicate);

        #endregion

    }
}
