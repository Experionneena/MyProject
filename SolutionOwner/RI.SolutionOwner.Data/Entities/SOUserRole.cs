// ---------------------------------------------------------
// <copyright file="SOUserRole.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// Class SOUserRole
    /// </summary>
    public class SOUserRole : BaseEntity, ISOUserRole
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the so user.
        /// </summary>
        /// <value>
        /// The so user.
        /// </value>
        public virtual SOUser SOUser { get; set; }

        /// <summary>
        /// Gets or sets the so role.
        /// </summary>
        /// <value>
        /// The so role.
        /// </value>
        public virtual SORole SORole { get; set; }
    }
}
