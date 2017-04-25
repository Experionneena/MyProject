//---------------------------------------------------------
// <copyright file="ISOSolutionPartner.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// The Solution owner Solution partner entity contract.
    /// </summary>
    public interface ISOSolutionPartner : IEntity
    {
        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        byte[] Logo { get; set; }

        /// <summary>
        /// Gets or sets the logo thumb nail.
        /// </summary>
        /// <value>
        /// The logo thumb nail.
        /// </value>
        byte[] LogoThumbNail { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the admin email.
        /// </summary>
        /// <value>
        /// The admin email.
        /// </value>
        string AdminEmail { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the scheduler time.
        /// </summary>
        /// <value>
        /// The scheduler time.
        /// </value>
        DateTime? SchedulerTime { get; set; }

        /// <summary>
        /// Gets or sets the position printing qty.
        /// </summary>
        /// <value>
        /// The position printing qty.
        /// </value>
        int POSPrintingQty { get; set; }

        /// <summary>
        /// Gets or sets the cr.
        /// </summary>
        /// <value>
        /// The cr.
        /// </value>
        string CR { get; set; }

        /// <summary>
        /// Gets or sets the cr expiry date.
        /// </summary>
        /// <value>
        /// The cr expiry date.
        /// </value>
        DateTime CRExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the cr proof.
        /// </summary>
        /// <value>
        /// The cr proof.
        /// </value>
        byte[] CRProof { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [email password].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [email password]; otherwise, <c>false</c>.
        /// </value>
        bool EmailPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [reset password next login].
        /// </summary>
        /// <value>
        /// <c>true</c> if [reset password next login]; otherwise, <c>false</c>.
        /// </value>
        bool ResetPasswordNextLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the SFTP folder path.
        /// </summary>
        /// <value>
        /// The SFTP folder path.
        /// </value>
        string SftpFolderPath { get; set; }
    }
}
