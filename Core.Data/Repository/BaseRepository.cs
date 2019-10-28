namespace Core.Data.Repository
{
    using Core.Data.Context;
    using Core.Domain.Contract;
    using Core.Domain.Entity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;


    public class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly MySqlContext context = new MySqlContext();

        #region Async
        public async Task CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ReadWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> ReadByGuidAsync(Guid guid)
        {
            return await context.Set<T>().Where(x => x.Id.Equals(guid)).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Sync
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> ReadAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> ReadWhere(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public T ReadByGuid(Guid guid)
        {
            return context.Set<T>().Where(x => x.Id.Equals(guid)).FirstOrDefault();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        #endregion
    }
}
