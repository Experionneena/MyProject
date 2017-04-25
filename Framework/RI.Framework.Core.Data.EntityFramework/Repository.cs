using RI.Framework.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RI.Framework.Core.Data.EntityFramework
{
    public class Repository<TContract, TEntity> : IRepository<TContract>
        where TContract : IEntity
         where TEntity : class, TContract
    {
        private DbContext _dbContext;

        private DbSet<TEntity> _dbSet;

        private static readonly object LockObject = new object();

        private static List<Expression<Func<TEntity, object>>> navigationproperties
          = new List<Expression<Func<TEntity, object>>>();

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public TContract Add(TContract entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            _dbContext.Entry((TEntity)entity).State = EntityState.Added;
            return _dbSet.Add((TEntity)entity);
        }

        public void Update(TContract entity)
        {
            entity.EditedDate = DateTime.UtcNow;
            _dbSet.Attach((TEntity)entity);
            _dbContext.Entry((TEntity)entity).State = EntityState.Modified;
            _dbContext.Entry((TEntity)entity).Property(x => x.CreatedDate).IsModified = false;
        }

        public void Insert(IEnumerable<TContract> entities)
        {
            lock (LockObject)
            {
                var items = entities.Cast<TEntity>();
                foreach (var item in items)
                {
                    item.CreatedDate = DateTime.UtcNow;
                }

                _dbSet.AddRange(items);
            }
        }

        public void Delete(TContract entity)
        {
            if (_dbContext.Entry((TEntity)entity).State == EntityState.Detached)
            {
                _dbSet.Attach((TEntity)entity);
            }
            _dbSet.Remove((TEntity)entity);
        }

        public async Task<IEnumerable<TContract>> GetAllAsync()
        {
            var items = await _dbSet.ToListAsync() as IEnumerable<TContract>;
            return items;
        }

        public async Task<TContract> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }

        IQueryable<TContract> IRepository<TContract>.Entities
        {
            get
            {
                if (navigationproperties.Count == 0)
                {
                    var entities = _dbSet.AsNoTracking()
                        .AsQueryable<TContract>();
                    return entities;
                }
                else
                {
                    var entities = GetQueryable()
                        .Select(x => (TContract)x)
                        .AsQueryable();
                    return entities;
                }
            }
        }

        public void Include(Expression<Func<TEntity, object>> navigationProperty)
        {
            navigationproperties.Add(navigationProperty);
        }

        private IQueryable<TContract> GetQueryable()
        {
            if (navigationproperties.Count == 0)
            {
                return _dbSet;
            }
            else
            {
                IQueryable<TEntity> queryable = _dbSet.AsNoTracking();
                foreach (var navigationProperty in navigationproperties)
                {
                    queryable = (IQueryable<TEntity>)queryable.Include(navigationProperty);
                }

                return queryable;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion
    }
}
