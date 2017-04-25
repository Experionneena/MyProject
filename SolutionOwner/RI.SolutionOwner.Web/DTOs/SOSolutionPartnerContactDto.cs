//---------------------------------------------------------
// <copyright file="SOSolutionPartnerContactDto.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------
using System;

namespace RI.SolutionOwner.Web.DTOs
{
    public class SOSolutionPartnerContactDto
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
    }
}