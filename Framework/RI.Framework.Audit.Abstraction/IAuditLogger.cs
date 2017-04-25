// <copyright file="IAuditLogger.cs" company="Recharge India" CreatedOn="15/03/2017" CreatedBy="Deepak K V">
// Copyright (c) Recharge India. All rights reserved.
// </copyright>

using System.Data.Entity;

namespace RI.Framework.Audit.Abstraction
{
    public interface IAuditLogger
    {
        /// <summary>
        /// Initializes the specified components.
        /// </summary>
        /// <param name="components">The components.</param>
        void Init(params object[] components);

        /// <summary>
        /// Saves the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        int Save(DbContext dbContext);
    }
}
