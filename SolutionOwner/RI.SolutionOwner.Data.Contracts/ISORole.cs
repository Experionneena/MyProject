﻿//-----------------------------------------------------
// <copyright file="ISORole.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------

using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface for Solution Owner Role Entity
    /// </summary>
    public interface ISORole : IEntity
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [active status].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [active status]; otherwise, <c>false</c>.
        /// </value>
        bool ActiveStatus { get; set; }

        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        int FeatureId { get; set; }

        /// <summary>
        /// Gets or sets the so role permissions.
        /// </summary>
        /// <value>
        /// The so role permissions.
        /// </value>
        List<ISORolePermission> SORolePermissions { get; set; }
    }
}
