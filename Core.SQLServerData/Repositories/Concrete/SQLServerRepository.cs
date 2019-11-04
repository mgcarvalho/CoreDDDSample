namespace Core.SQLServerData.Repositories.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Core.Domain.Entity;
    using Core.Domain.Repository;

    public class SQLServerRepository<T> : IRepository<T> where T : EntityBase
    {
        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> ReadByGuidAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ReadWhereAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
