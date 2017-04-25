//----------------------------------------------------------------------
// <copyright file="POS.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------
using System;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// Class POS
    /// </summary>
    public class POS : BaseEntity, IPOS
    {

        /// <summary>
        /// Gets or sets the pos number.
        /// </summary>
        /// <value>
        /// The pos number.
        /// </value>
        public string POSNumber { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the model number.
        /// </summary>
        /// <value>
        /// The model number.
        /// </value>
        public string ModelNumber { get; set; }

        /// <summary>
        /// Gets or sets the purchase lpo.
        /// </summary>
        /// <value>
        /// The purchase lpo.
        /// </value>
        public string PurchaseLPO { get; set; }

        /// <summary>
        /// Gets or sets the warranty expiry.
        /// </summary>
        /// <value>
        /// The warranty expiry.
        /// </value>
        public DateTime? WarrantyExpiry { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>
        /// The supplier.
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>
        /// The manufacturer.
        /// </value>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing year.
        /// </summary>
        /// <value>
        /// The manufacturing year.
        /// </value>
        public string ManufacturingYear { get; set; }

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the os version.
        /// </summary>
        /// <value>
        /// The os version.
        /// </value>
        public string OsVersion { get; set; }

        /// <summary>
        /// Gets or sets the managed by.
        /// </summary>
        /// <value>
        /// The managed by.
        /// </value>
        public string ManagedBy { get; set; }

        /// <summary>
        /// Gets or sets the assigned to.
        /// </summary>
        /// <value>
        /// The assigned to.
        /// </value>
        public string AssignedTo { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>
        /// The supplier.
        /// </value>
        public virtual Supplier Suppliers { get; set; }
    }
}
