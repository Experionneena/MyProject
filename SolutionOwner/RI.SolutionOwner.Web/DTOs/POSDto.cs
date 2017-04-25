using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.Web.DTOs
{
    /// <summary>
    ///  POSDto Class
    /// </summary>
    public class POSDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the edited date.
        /// </summary>
        /// <value>
        /// The edited date.
        /// </value>
        public DateTime? EditedDate { get; set; }
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
    }
}
