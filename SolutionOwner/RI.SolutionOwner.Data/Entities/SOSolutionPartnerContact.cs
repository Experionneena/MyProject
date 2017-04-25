//---------------------------------------------------------
// <copyright file="SOSolutionPartnerContact.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// The Solution Partner contact entity.
    /// </summary>
    public class SOSolutionPartnerContact : BaseEntity, ISOSolutionPartnerContact
    {
        /// <summary>
        /// Gets or sets the solution partner identifier.
        /// </summary>
        /// <value>
        /// The solution partner identifier.
        /// </value>
        public int SolutionPartnerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        /// <value>
        /// The name of the person.
        /// </value>
        public string PersonName { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the working contact.
        /// </summary>
        /// <value>
        /// The work phone number.
        /// </value>
        public string PhoneWork { get; set; }

        /// <summary>
        /// Gets or sets the personal contact.
        /// </summary>
        /// <value>
        /// The personal contact number.
        /// </value>
        public string PhonePersonal { get; set; }

        /// <summary>
        /// Gets or sets the E-mail.
        /// </summary>
        /// <value>
        /// The E-mail.
        /// </value>
        public string EMail { get; set; }

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the solution partner.
        /// </summary>
        /// <value>
        /// The solution partner.
        /// </value>
        public virtual SOSolutionPartner SolutionPartner { get; set; }
    }
}
