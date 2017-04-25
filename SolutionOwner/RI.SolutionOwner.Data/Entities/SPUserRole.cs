//-----------------------------------------------------
// <copyright file="SPUserRole.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// SP User Role class
    /// </summary>
    public class SPUserRole : BaseEntity, ISPUserRole
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
        /// Gets or sets the sp user.
        /// </summary>
        /// <value>
        /// The sp user.
        /// </value>
        public virtual SPUser SPUser { get; set; }

        /// <summary>
        /// Gets or sets the sp role.
        /// </summary>
        /// <value>
        /// The sp role.
        /// </value>
        public virtual SPRole SPRole { get; set; }
    }
}
