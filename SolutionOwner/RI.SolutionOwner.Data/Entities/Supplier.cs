//----------------------------------------------------------------------
// <copyright file="POS.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------
using System;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;
using System.Collections.Generic;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// Class POS
    /// </summary>
    public class Supplier : BaseEntity, ISupplier
    {
        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the name of the street.
        /// </summary>
        /// <value>
        /// The name of the street.
        /// </value>
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the contact person.
        /// </summary>
        /// <value>
        /// The contact person.
        /// </value>
        public string ContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the work phone.
        /// </summary>
        /// <value>
        /// The work phone.
        /// </value>
        public string WorkPhone { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the lpo contact person.
        /// </summary>
        /// <value>
        /// The lpo contact person.
        /// </value>
        public string LPOContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the lpo designation.
        /// </summary>
        /// <value>
        /// The lpo designation.
        /// </value>
        public string LPODesignation { get; set; }

        /// <summary>
        /// Gets or sets the lpo work phone.
        /// </summary>
        /// <value>
        /// The lpo work phone.
        /// </value>
        public string LPOWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets the lpo mobile number.
        /// </summary>
        /// <value>
        /// The lpo mobile number.
        /// </value>
        public string LPOMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the lpo email.
        /// </summary>
        /// <value>
        /// The lpo email.
        /// </value>
        public string LPOEmail { get; set; }

        /// <summary>
        /// Gets or sets the position list.
        /// </summary>
        /// <value>
        /// The pos list.
        /// </value>
        public virtual ICollection<POS> PosList { get; set; }

    }
}
