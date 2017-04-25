//---------------------------------------------------------
// <copyright file="ISOSolutionPartnerContact.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// The Solution Partner contact entity abstraction.
    /// </summary>
    public interface ISOSolutionPartnerContact : IEntity
    {
        /// <summary>
        /// Gets or sets the solution partner identifier.
        /// </summary>
        /// <value>
        /// The solution partner identifier.
        /// </value>
        int SolutionPartnerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        /// <value>
        /// The name of the person.
        /// </value>
        string PersonName { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        string Designation { get; set; }

        /// <summary>
        /// Gets or sets the working contact.
        /// </summary>
        /// <value>
        /// The work phone number.
        /// </value>
        string PhoneWork { get; set; }

        /// <summary>
        /// Gets or sets the personal contact.
        /// </summary>
        /// <value>
        /// The personal contact number.
        /// </value>
        string PhonePersonal { get; set; }

        /// <summary>
        /// Gets or sets the E-mail.
        /// </summary>
        /// <value>
        /// The E-mail.
        /// </value>
        string EMail { get; set; }

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        string Remarks { get; set; }
    }
}
