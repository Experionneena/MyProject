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
    public interface ISupplier : IEntity
    {
        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the name of the street.
        /// </summary>
        /// <value>
        /// The name of the street.
        /// </value>
        string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        string Country { get; set; }

        /// <summary>
        /// Gets or sets the contact person.
        /// </summary>
        /// <value>
        /// The contact person.
        /// </value>
        string ContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        string Designation { get; set; }

        /// <summary>
        /// Gets or sets the work phone.
        /// </summary>
        /// <value>
        /// The work phone.
        /// </value>
        string WorkPhone { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the lpo contact person.
        /// </summary>
        /// <value>
        /// The lpo contact person.
        /// </value>
        string LPOContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the lpo designation.
        /// </summary>
        /// <value>
        /// The lpo designation.
        /// </value>
        string LPODesignation { get; set; }

        /// <summary>
        /// Gets or sets the lpo work phone.
        /// </summary>
        /// <value>
        /// The lpo work phone.
        /// </value>
        string LPOWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets the lpo mobile number.
        /// </summary>
        /// <value>
        /// The lpo mobile number.
        /// </value>
        string LPOMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the lpo email.
        /// </summary>
        /// <value>
        /// The lpo email.
        /// </value>
        string LPOEmail { get; set; }
    }
}
