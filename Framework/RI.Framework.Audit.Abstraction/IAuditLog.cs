// <copyright file="IAuditLogger.cs" company="Recharge India" CreatedOn="15/03/2017" CreatedBy="Deepak K V">
// Copyright (c) Recharge India. All rights reserved.
// </copyright>

using System;

namespace RI.Framework.Audit.Abstraction
{
    public interface IAuditLog
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        long Id { get; set; }        

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        string TableName { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>
        /// The type of the event.
        /// </value>
        string EventType { get; set; }

        /// <summary>
        /// Gets or sets the primary key names.
        /// </summary>
        /// <value>
        /// The primary key names.
        /// </value>
        string PrimaryKeyNames { get; set; }

        /// <summary>
        /// Gets or sets the primary key values.
        /// </summary>
        /// <value>
        /// The primary key values.
        /// </value>
        string PrimaryKeyValues { get; set; }

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        /// <value>
        /// The new value.
        /// </value>
        string NewValue { get; set; }

        /// <summary>
        /// Gets or sets the original value.
        /// </summary>
        /// <value>
        /// The original value.
        /// </value>
        string OriginalValue { get; set; }

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        DateTime TimeStamp { get; set; }
    }
}
