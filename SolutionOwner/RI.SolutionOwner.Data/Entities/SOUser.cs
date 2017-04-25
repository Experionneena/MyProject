// ---------------------------------------------------------
// <copyright file="SOUser.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// Interface SOUser
    /// </summary>
    public class SOUser : BaseEntity, ISOUser
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        /// <value>
        /// The last login date.
        /// </value>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the is blocked.
        /// </summary>
        /// <value>
        /// The is blocked.
        /// </value>
        public bool? IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets the so user roles.
        /// </summary>
        /// <value>
        /// The so user roles.
        /// </value>
        public virtual ICollection<SOUserRole> SOUserRoles { get; set; }

        /// <summary>
        /// Gets or sets the role identifier list.
        /// </summary>
        /// <value>
        /// The role identifier list.
        /// </value>
        public IList<int> RoleIdList { get; set; }

        /// <summary>
        /// Gets or sets the role name list.
        /// </summary>
        /// <value>
        /// The role name list.
        /// </value>
        public IList<string> RoleNameList { get; set; }
    }
}
