namespace Core.Data.Repositories.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Core.Domain.Entity;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : EntityBase
    {

        private CoreContext _context;

        public Repository(CoreContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ReadWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> ReadByGuidAsync(Guid guid)
        {
            return await _context.Set<T>().Where(x => x.Id.Equals(guid)).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
