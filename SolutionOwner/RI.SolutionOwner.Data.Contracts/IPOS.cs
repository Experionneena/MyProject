//----------------------------------------------------------------------
// <copyright file="IPOS.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------
using System;
using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface IPOS
    /// </summary>
    public interface IPOS : IEntity
    {
        /// <summary>
        /// Gets or sets the pos number.
        /// </summary>
        /// <value>
        /// The pos number.
        /// </value>
        string POSNumber { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the model number.
        /// </summary>
        /// <value>
        /// The model number.
        /// </value>
        string ModelNumber { get; set; }

        /// <summary>
        /// Gets or sets the purchase lpo.
        /// </summary>
        /// <value>
        /// The purchase lpo.
        /// </value>
        string PurchaseLPO { get; set; }

        /// <summary>
        /// Gets or sets the warranty expiry.
        /// </summary>
        /// <value>
        /// The warranty expiry.
        /// </value>
        DateTime? WarrantyExpiry { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>
        /// The supplier.
        /// </value>
        int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>
        /// The manufacturer.
        /// </value>
        string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing year.
        /// </summary>
        /// <value>
        /// The manufacturing year.
        /// </value>
       string ManufacturingYear { get; set; }

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        string Remarks { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the os version.
        /// </summary>
        /// <value>
        /// The os version.
        /// </value>
        string OsVersion { get; set; }

        /// <summary>
        /// Gets or sets the managed by.
        /// </summary>
        /// <value>
        /// The managed by.
        /// </value>
        string ManagedBy { get; set; }

        /// <summary>
        /// Gets or sets the assigned to.
        /// </summary>
        /// <value>
        /// The assigned to.
        /// </value>
        string AssignedTo { get; set; }
    }
}
