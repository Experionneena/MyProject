//---------------------------------------------------
// <copyright file="SORole.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------

using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// Class SORole
    /// </summary>
    public class SORole : BaseEntity, ISORole
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [active status].
        /// </summary>
        /// <value>
        /// <c>true</c> if [active status]; otherwise, <c>false</c>.
        /// </value>
        public bool ActiveStatus { get; set; }

        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        public int FeatureId { get; set; }

        /// <summary>
        /// Gets or sets the so user roles.
        /// </summary>
        /// <value>
        /// The so user roles.
        /// </value>
        public virtual ICollection<SOUserRole> SOUserRoles { get; set; }

        /// <summary>
        /// Gets or sets the role permissions.
        /// </summary>
        /// <value>
        /// The role permissions.
        /// </value>
        public virtual ICollection<SORolePermission> RolePermissions { get; set; }

        /// <summary>
        /// Gets or sets the SOrole permissions.
        /// </summary>
        /// <value>
        /// The SO role permissions.
        /// </value>
        public List<ISORolePermission> SORolePermissions { get; set; }  
    }
}
