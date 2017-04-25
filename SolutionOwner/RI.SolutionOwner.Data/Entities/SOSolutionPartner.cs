//---------------------------------------------------------
// <copyright file="SOSolutionPartner.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// The Solution owner Solution partner entity.
    /// </summary>
    public class SOSolutionPartner : BaseEntity, ISOSolutionPartner
    {
        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Gets or sets the logo thumb nail.
        /// </summary>
        /// <value>
        /// The logo thumb nail.
        /// </value>
        public byte[] LogoThumbNail { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the admin email.
        /// </summary>
        /// <value>
        /// The admin email.
        /// </value>
        public string AdminEmail { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the scheduler time.
        /// </summary>
        /// <value>
        /// The scheduler time.
        /// </value>
        public DateTime? SchedulerTime { get; set; }

        /// <summary>
        /// Gets or sets the position printing qty.
        /// </summary>
        /// <value>
        /// The position printing qty.
        /// </value>
        public int POSPrintingQty { get; set; }

        /// <summary>
        /// Gets or sets the cr.
        /// </summary>
        /// <value>
        /// The cr.
        /// </value>
        public string CR { get; set; }

        /// <summary>
        /// Gets or sets the cr expiry date.
        /// </summary>
        /// <value>
        /// The cr expiry date.
        /// </value>
        public DateTime CRExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the cr proof.
        /// </summary>
        /// <value>
        /// The cr proof.
        /// </value>
        public byte[] CRProof { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [email password].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [email password]; otherwise, <c>false</c>.
        /// </value>
        public bool EmailPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [reset password next login].
        /// </summary>
        /// <value>
        /// <c>true</c> if [reset password next login]; otherwise, <c>false</c>.
        /// </value>
        public bool ResetPasswordNextLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the SFTP folder path.
        /// </summary>
        /// <value>
        /// The SFTP folder path.
        /// </value>
        public string SftpFolderPath { get; set; }

        /// <summary>
        /// Gets or sets the sp heirarchy.
        /// </summary>
        /// <value>
        /// The sp heirarchy.
        /// </value>        
        public virtual SPHierarchy SPHierarchy { get; set; }

        /// <summary>
        /// Gets or sets the sp address.
        /// </summary>
        /// <value>
        /// The sp address.
        /// </value>
        public virtual SPAddress SPAddress { get; set; }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        public virtual ICollection<SOSolutionPartnerContact> Contacts { get; set; }
    }
}
