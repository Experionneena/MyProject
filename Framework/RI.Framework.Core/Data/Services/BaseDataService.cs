using RI.Framework.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RI.Framework.Core.Data.Services
{
    public abstract class BaseDataService : IDataService
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        public IUnitOfWork UnitOfWork;

        /// <summary>
        /// The _disposed
        /// </summary>
        private bool _disposed;

        public BaseDataService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        ///// <summary>
        ///// Adds the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public TEntity Add<TEntity>(TEntity entity) where TEntity : IEntity
        //{
        //    var repository = UnitOfWork.Repository<TEntity>();
        //    repository.Add(entity);
        //    UnitOfWork.Commit();

        //    return entity;
        //}

        ///// <summary>
        ///// Adds the asynchronous.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : IEntity
        //{
        //    var repository = UnitOfWork.Repository<TEntity>();
        //    repository.Add(entity);
        //    await UnitOfWork.CommitAsync();

        //    return entity;
        //}

        ///// <summary>
        ///// Deletes the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        ///// <exception cref="NotImplementedException"></exception>
        //public void Delete<TEntity>(TEntity entity) where TEntity : IEntity
        //{
        //    var repository = UnitOfWork.Repository<TEntity>();
        //    repository.Delete(entity);
        //    UnitOfWork.Commit();
        //}

        ///// <summary>
        ///// Deletes the asynchronous.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public Task DeleteAsync<TEntity>(TEntity entity) where TEntity : IEntity
        //{
        //    var repository = UnitOfWork.Repository<TEntity>();
        //    repository.Delete(entity);
        //    return UnitOfWork.CommitAsync();
        //}

        ///// <summary>
        ///// Gets all asynchronous.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public Task<List<TEntity>> GetAllAsyn<TEntity>() where TEntity : IEntity
        //{
        //    var repository = UnitOfWork.Repository<TEntity>();
        //    return repository.GetAllAsync();
        //}

        ///// <summary>
        ///// Gets the by identifier asynchronous.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : IEntity
        //{
        //    var repository = UnitOfWork.Repository<TEntity>();
        //    return repository.GetByIdAsync(id);
        //}

        ///// <summary>
        ///// Updates the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        ///// <exception cref="NotImplementedException"></exception>
        //public void Update<TEntity>(TEntity entity) where TEntity : IEntity
        //{
        //    var repository = UnitOfWork.Repository<TEntity>();
        //    repository.Update(entity);
        //    UnitOfWork.Commit();
        //}

        ///// <summary>
        ///// Updates the asynchronous.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public Task UpdateAsync<TEntity>(TEntity entity) where TEntity : IEntity
        //{
        //    var repository = UnitOfWork.Repository<TEntity>();
        //    repository.Update(entity);
        //    return UnitOfWork.CommitAsync();
        //}

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                UnitOfWork.Dispose();
            }
            _disposed = true;
        }
    }
}
