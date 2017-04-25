//----------------------------------------------------------
// <copyright file="Hierarchy.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------
using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// Hierarchy Class
    /// </summary>
    public class Hierarchy : BaseEntity, IHierarchy
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the feature.
        /// </summary>
        /// <value>
        /// The feature.
        /// </value>
        public virtual ICollection<SPFeature> Feature { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public virtual ICollection<SPRole> Role { get; set; }

        /// <summary>
        /// Gets or sets the partner portal role.
        /// </summary>
        /// <value>
        /// The partner portal role.
        /// </value>
        public virtual ICollection<SPPRole> PartnerPortalRole { get; set; }

        /// <summary>
        /// Gets or sets the partner portal users.
        /// </summary>
        /// <value>
        /// The partner portal users.
        /// </value>
        public virtual ICollection<SPPUser> PartnerPortalUsers { get; set; }

    }
}
