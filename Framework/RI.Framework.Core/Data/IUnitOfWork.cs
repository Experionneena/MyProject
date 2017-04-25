using RI.Framework.Core.Data.Entities;
using System;
using System.Threading.Tasks;

namespace RI.Framework.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IServiceProvider _serviceProvider { get; set; }

        /// <summary>
        /// Repositories this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        void BeginTransaction();


        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        void Dispose(bool disposing);
    }
}
