using RI.Framework.Audit.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Framework.Audit.EntityFramework
{
    public class AuditLogger : IAuditLogger
    {
        /// <summary>
        /// The database context
        /// </summary>
        private DbContext dbContext;

        /// <summary>
        /// Initializes the specified components.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Init(params object[] components)
        {
            dbContext = (DbContext)components[0];
        }

        /// <summary>
        /// Saves the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int Save(DbContext dbContext)
        {
            var result = 0;
            var addedEntityEntries = dbContext.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Added).ToList();
            var modifiedEntityEntries = dbContext.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified).ToList();
            var deletedEntityEntries = dbContext.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Detached).ToList();

            var auditLogs = AuditLogBuilder.GetModifiedAuditList(modifiedEntityEntries, deletedEntityEntries);
            result = dbContext.SaveChanges();

            auditLogs.AddRange(AuditLogBuilder.GetAddedAuditList(addedEntityEntries));
            dbContext.Set<AuditLog>().AddRange(auditLogs.Cast<AuditLog>());
            result += dbContext.SaveChanges();

            return result;
        }
    }
}
