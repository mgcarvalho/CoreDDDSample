// <copyright file="IRepository.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Domain.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Core.Domain.Entity;

    /// <summary>
    /// General Interface for Repository contract
    /// </summary>
    /// <typeparam name="T">Generic Object</typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        #region Async calls       
        /// <summary>
        /// Call asynchronous task to create a new register on repository
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Asynchronous task</returns>
        Task CreateAsync(T entity);

        /// <summary>
        /// Call asynchronous task to get all registers of a repository
        /// </summary>
        /// <returns>IEnumerable containing a list of all elements</returns>
        Task<IEnumerable<T>> ReadAllAsync();

        /// <summary>
        /// Call asynchronous task to get all registers of a repository by a filter
        /// </summary>
        /// <param name="predicate">Filter expression</param>
        /// <returns>Task containing a list</returns>
        Task<IEnumerable<T>> ReadWhereAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Call asynchronous task to get an entity on repository by register identification (guid)
        /// </summary>
        /// <param name="guid">Register identification</param>
        /// <returns>Entity filtered by guid</returns>
        Task<T> ReadByGuidAsync(Guid guid);

        /// <summary>
        /// Call asynchronous task to update an entity on repository
        /// </summary>
        /// <param name="entity">The entity updated by the key element</param>
        /// <returns>Asynchronous task</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Call asynchronous task to delete an entity on repository
        /// </summary>
        /// <param name="entity">The entity that will be eliminated</param>
        /// <returns>Asynchronous task</returns>
        Task DeleteAsync(T entity);
        #endregion

        #region sync calls
        /// <summary>
        /// Create a new register on repository
        /// </summary>
        /// <param name="entity">Entity to save</param>
        void Create(T entity);

        /// <summary>
        /// Get all registers of a repository
        /// </summary>
        /// <returns>IEnumerable containing a list of all elements</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Get all registers of a repository by a filter
        /// </summary>
        /// <param name="predicate">Filter expression</param>
        /// <returns>IEnumerable containing a list filtered</returns>
        IEnumerable<T> ReadWhere(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get an entity on repository by register identification (guid)
        /// </summary>
        /// <param name="guid">Register identification</param>
        /// <returns>Entity filtered by guid</returns>
        T ReadByGuid(Guid guid);

        /// <summary>
        /// Update an entity on repository
        /// </summary>
        /// <param name="entity">The entity updated by the key element</param>
        void Update(T entity);

        /// <summary>
        /// Delete an entity on repository
        /// </summary>
        /// <param name="entity">The entity that will be eliminated</param>
        void Delete(T entity);
        #endregion
    }
}
