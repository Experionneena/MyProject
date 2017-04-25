//---------------------------------------------------------
// <copyright file="SOSolutionPartnerDto.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------
using System;

namespace RI.SolutionOwner.Web.DTOs
{
    /// <summary>
    /// Class SOSolutionPartnerDto
    /// </summary>
    public class SOSolutionPartnerDto
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
        /// Gets or sets the logo.
        /// </summary>
        /// <value>
        /// The logo.
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
    }
}