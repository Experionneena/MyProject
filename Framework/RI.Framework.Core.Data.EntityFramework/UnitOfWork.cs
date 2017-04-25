//---------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Entities;
using System.Collections;
using System.Reflection;
using RI.Framework.Audit.Abstraction;

namespace RI.Framework.Core.Data.EntityFramework
{
    /// <summary>
    /// This class helps to maintain in memory updates and commits these updates as a transaction to the database.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Members        
        /// <summary>
        /// The audit logger
        /// </summary>
        private IAuditLogger auditLogger;
        /// <summary>
        /// The _DB context
        /// </summary>
        private DbContext _dbContext;
        /// <summary>
        /// The _repositories
        /// </summary>
        private Hashtable _repositories;
        
        /// <summary>
        /// Gets or sets the repositories.
        /// </summary>
        /// <value>
        /// The repositories.
        /// </value>
        public Dictionary<Type, object> Repositories { get; set; }
        /// <summary>
        /// Gets or sets the _service provider.
        /// </summary>
        /// <value>
        /// The _service provider.
        /// </value>
        public IServiceProvider _serviceProvider { get; set; }
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="auditLoggerService">The audit logger service.</param>
        public UnitOfWork(DbContext dbContext, IServiceProvider serviceProvider, IAuditLogger auditLoggerService)
        {
            _serviceProvider = serviceProvider;
            _dbContext = dbContext;
            Repositories = new Dictionary<Type, object>();
            auditLogger = auditLoggerService;
        }
        #endregion

        #region Public Methods
        public void BeginTransaction()
        {
            ////_transaction = _dbContext.Database.BeginTransaction();
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            ////BeginTransaction();
            auditLogger.Save(_dbContext);
            var result = _dbContext.SaveChanges();
            ////_transaction.Commit();
            return result;
        }

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<int> CommitAsync()
        {
            auditLogger.Save(_dbContext);
            var result = _dbContext.SaveChangesAsync();
            ////_transaction.Commit();
            return result;
        }

        /// <summary>
        /// Repositories this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var typeName = typeof(TEntity).Name;
            var keyType = typeof(TEntity);
            if (Repositories.ContainsKey(keyType))
            {
                return (IRepository<TEntity>)_repositories[typeName];
            }
            else
            {
                var instance = _serviceProvider.GetService(typeof(TEntity));
                var instanceType = instance.GetType();
                var setMethod = GetType().GetTypeInfo()
                            .GetMethod("CreateRepository").MakeGenericMethod(typeof(TEntity), instanceType);
                var repository = (IRepository<TEntity>)setMethod.Invoke(this, new object[] { });
                Repositories[keyType] = repository;
                return repository;
            }
        }

        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public virtual object CreateRepository<TContract, TEntity>()
          where TContract : IEntity
          where TEntity : class, TContract
        {
            var dbset = _dbContext.Set<TEntity>();
            var repository = new Repository<TContract, TEntity>(_dbContext);
            return repository;
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public void Rollback()
        {
            ////_transaction.Rollback();
        }
        #endregion

        #region IDisposable Support        
        /// <summary>
        /// The disposed value
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    foreach (IDisposable rep in _repositories)
                    {
                        rep.Dispose();
                    }
                }

                //// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                //// TODO: set large fields to null.

                disposedValue = true;
            }
        }

        //// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        //// ~UnitOfWork() {
        ////   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        ////   Dispose(false);
        //// }

        //// This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            //// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            //// TODO: uncomment the following line if the finalizer is overridden above.
            //// GC.SuppressFinalize(this);
        }
        #endregion
    }
}
