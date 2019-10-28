// <copyright file="BaseService.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Services.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Data.Repository;
    using Core.Domain.Contract;
    using Core.Domain.Entity;
    using FluentValidation;

    /// <summary>
    /// Base Service class
    /// </summary>
    /// <typeparam name="T">Entity object</typeparam>
    public class BaseService<T> : IService<T> where T : EntityBase
    {
        /// <summary>
        /// private repository call
        /// </summary>
        private BaseRepository<T> repository = new BaseRepository<T>();

        /// <summary>
        /// Post an entity
        /// </summary>
        /// <typeparam name="V">Object Validator</typeparam>
        /// <param name="obj">Value object parameter</param>
        /// <returns>Value object</returns>
        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            this.Validate(obj, Activator.CreateInstance<V>());
            this.repository.Create(obj);
            return obj;
        }

        /// <summary>
        /// Put an entity
        /// </summary>
        /// <typeparam name="V">Object Validator</typeparam>
        /// <param name="obj">Value object parameter</param>
        /// <returns>Value object</returns>
        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            this.Validate(obj, Activator.CreateInstance<V>());
            this.repository.Update(obj);
            return obj;
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="obj">Entity that will be delete</param>
        public void Delete(T obj)
        {
            this.repository.Delete(obj);
        }

        /// <summary>
        /// Get all elements of entity
        /// </summary>
        /// <returns>All elements of entity</returns>
        public IEnumerable<T> GetAll() => this.repository.ReadAll();

        /// <summary>
        /// Return an entity
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Entity found</returns>
        public T Get(Guid id)
        {
            return this.repository.ReadByGuid(id);
        }

        /// <summary>
        /// Post an entity async
        /// </summary>
        /// <typeparam name="V">Object Validator</typeparam>
        /// <param name="obj">Value object parameter</param>
        /// <returns>Value object</returns>
        public async Task<T> PostAsync<V>(T obj) where V : AbstractValidator<T>
        {
            this.Validate(obj, Activator.CreateInstance<V>());
            await this.repository.CreateAsync(obj);
            return obj;
        }

        /// <summary>
        /// Put an entity async
        /// </summary>
        /// <typeparam name="V">Object Validator</typeparam>
        /// <param name="obj">Value object parameter</param>
        /// <returns>Value object</returns>
        public async Task<T> PutAsync<V>(T obj) where V : AbstractValidator<T>
        {
            this.Validate(obj, Activator.CreateInstance<V>());
            await this.repository.UpdateAsync(obj);
            return obj;
        }

        /// <summary>
        /// Delete async
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Task of async</returns>
        public async Task DeleteAsync(T id)
        {
            await this.repository.DeleteAsync(id);
        }

        /// <summary>
        /// Return an entity
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Entity found</returns>
        public async Task<T> GetAsync(Guid id)
        {
            return await this.repository.ReadByGuidAsync(id);
        }

        /// <summary>
        /// Get all elements of entity async
        /// </summary>
        /// <returns>All elements of entity</returns>
        public async Task<IEnumerable<T>> GetAllAsync() => await this.repository.ReadAllAsync();

        /// <summary>
        /// Validate entities
        /// </summary>
        /// <param name="obj">Entity to validate</param>
        /// <param name="validator">Class validator</param>
        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
            {
                throw new Exception("Object not found!");
            }

            validator.ValidateAndThrow(obj);
        }
    }
}
