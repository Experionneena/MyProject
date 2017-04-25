using RI.Framework.Audit.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace RI.Framework.Audit.EntityFramework
{
    public class AuditLogBuilder
    {
        /// <summary>
        /// The key seperator
        /// </summary>
        private const string KeySeperator = ";";

        /// <summary>
        /// Gets the modified audit list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="modifiedEntityEntries">The modified entity entries.</param>
        /// <param name="deletedEntityEntries">The deleted entity entries.</param>
        /// <returns></returns>
        public static List<IAuditLog> GetModifiedAuditList(
            IEnumerable<DbEntityEntry> modifiedEntityEntries,
            IEnumerable<DbEntityEntry> deletedEntityEntries)
        {
            var auditLogs = new List<IAuditLog>();

            foreach (var auditRecordsForEntityEntry in modifiedEntityEntries.Select(
                changedEntity => GenerateChangeLogs(changedEntity, EntityState.Modified)))
            {
                auditLogs.AddRange(auditRecordsForEntityEntry);
            }

            foreach (var auditRecordsForEntityEntry in deletedEntityEntries.Select(
                changedEntity => GenerateChangeLogs(changedEntity, EntityState.Deleted)))
            {
                auditLogs.AddRange(auditRecordsForEntityEntry);
            }

            return auditLogs;
        }

        /// <summary>
        /// Gets the added audit list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="addedEntityEntries">The added entity entries.</param>
        /// <returns></returns>
        public static List<IAuditLog> GetAddedAuditList(IEnumerable<DbEntityEntry> addedEntityEntries)
        {
            var auditLogs = new List<IAuditLog>();

            foreach (var auditRecordsForEntityEntry in addedEntityEntries.Select(
                changedEntity => GenerateChangeLogs(changedEntity, EntityState.Added)))
            {
                auditLogs.AddRange(auditRecordsForEntityEntry);
            }

            return auditLogs;
        }

        /// <summary>
        /// Generates the change logs.
        /// </summary>
        /// <param name="entityEntry">The entity entry.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="entityState">State of the entity.</param>
        /// <returns></returns>
        private static IEnumerable<IAuditLog> GenerateChangeLogs(DbEntityEntry entityEntry,
            EntityState entityState)
        {
            var returnValue = new List<IAuditLog>();
            var keyRepresentation = GetPrimaryKeyInfo(entityEntry, KeySeperator);

            var auditedPropertyNames = entityEntry.Entity.GetType().GetProperties()
                .Select(info => info.Name);

            var propertyEntries = entityEntry.Entity.GetType().GetProperties()
                .Where(x => auditedPropertyNames.Contains(x.Name))
                .Select(property =>
                 {
                     try
                     {
                         return entityEntry.Property(property.Name);
                     }
                     catch
                     {
                         return null;
                     }

                 }).Where(k => null != k);

            foreach (var propertyEntry in propertyEntries)
            {
                try
                {
                    if (entityState == EntityState.Modified)
                    {
                        if (Convert.ToString(propertyEntry.OriginalValue) == Convert.ToString(propertyEntry.CurrentValue))
                            continue;
                    }

                    returnValue.Add(new AuditLog
                    {
                        PrimaryKeyNames = keyRepresentation.Key,
                        PrimaryKeyValues = keyRepresentation.Value,
                        OriginalValue = entityState != EntityState.Added ? Convert.ToString(propertyEntry.OriginalValue) : null,
                        NewValue = entityState == EntityState.Modified || entityState == EntityState.Added ? Convert.ToString(propertyEntry.CurrentValue) : null,
                        PropertyName = propertyEntry.Name,
                        TimeStamp = DateTime.Now,
                        EventType = entityState.ToString(),
                        ////UserId = userId,
                        TableName = entityEntry.Entity.GetType().Name
                    });
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the primary key information.
        /// </summary>
        /// <param name="entityEntry">The entity entry.</param>
        /// <param name="seperator">The seperator.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">The key doesn't exist</exception>
        private static KeyValuePair<string, string> GetPrimaryKeyInfo(DbEntityEntry entityEntry, string seperator)
        {

            var keyProperties = entityEntry.Entity.GetType().GetProperties()
                  .Where(prop => prop.Name == "Id").ToList();

            if (keyProperties == null)
                throw new ArgumentException("The key doesn't exist");
            var keyPropertyEntries = keyProperties.Select(keyProperty => entityEntry.Property(keyProperty.Name)).ToList();

            var keyNameString = new StringBuilder();
            foreach (var keyProperty in keyProperties)
            {
                keyNameString.Append(keyProperty.Name);
                keyNameString.Append(seperator);
            }

            keyNameString.Remove(keyNameString.Length - 1, 1);
            var keyValueString = new StringBuilder();
            foreach (var keyPropertyEntry in keyPropertyEntries)
            {
                keyValueString.Append(keyPropertyEntry.CurrentValue);
                keyValueString.Append(seperator);
            }

            keyValueString.Remove(keyValueString.Length - 1, 1);
            var key = keyNameString.ToString();
            var value = keyValueString.ToString();

            return new KeyValuePair<string, string>(key, value);
        }

    }
}
