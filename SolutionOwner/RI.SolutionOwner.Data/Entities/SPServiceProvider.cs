//---------------------------------------------------------
// <copyright file="SPServiceProvider.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// The Solution partner Service provider entity.
    /// </summary>
    public class SPServiceProvider : BaseEntity, ISPServiceProvider
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [active status].
        /// </summary>
        /// <value>
        /// <c>true</c> if [active status]; otherwise, <c>false</c>.
        /// </value>
        public bool ActiveStatus { get; set; }

        /// <summary>
        /// Gets or sets the product groups.
        /// </summary>
        /// <value>
        /// The product groups.
        /// </value>
        public virtual ICollection<SPProductGroup> ProductGroups { get; set; }
    }
}
