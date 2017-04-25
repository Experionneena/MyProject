﻿//-----------------------------------------------------
// <copyright file="SPPRole.cs" company="RechargeIndia">
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
    /// Solution Partner Role class
    /// </summary>
    public class SPPRole : BaseEntity, ISPPRole
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
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        public int HierarchyId { get; set; }

        /// <summary>
        /// Gets or sets the sp user roles.
        /// </summary>
        /// <value>
        /// The sp user roles.
        /// </value>
        public virtual ICollection<SPUserRole> SPUserRoles { get; set; }

        /// <summary>
        /// Gets or sets the role permissions.
        /// </summary>
        /// <value>
        /// The role permissions.
        /// </value>
        public virtual ICollection<SPPRolePermission> RolePermissions { get; set; }

        /// <summary>
        /// Gets or sets the sp role permissions.
        /// </summary>
        /// <value>
        /// The sp role permissions.
        /// </value>
        public List<ISPPRolePermission> SPPRolePermissions { get; set; }

        /// <summary>
        /// Gets or sets the partner portal role permissions.
        /// </summary>
        /// <value>
        /// The partner portal role permissions.
        /// </value>
        public virtual ICollection<SPPRolePermission> PartnerPortalRolePermissions { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy.
        /// </summary>
        /// <value>
        /// The hierarchy.
        /// </value>
        public virtual Hierarchy Hierarchy { get; set; }

        /// <summary>
        /// Gets or sets the SPP user roles.
        /// </summary>
        /// <value>
        /// The SPP user roles.
        /// </value>
        public virtual ICollection<SPPUserRole> SPPUserRoles { get; set; }
    }
}
