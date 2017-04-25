//----------------------------------------------------------------------
// <copyright file="IPOSParameter.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------
using System;
using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface IPOSParameter
    /// </summary>
    public interface IPOSParameter : IEntity
    {
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        /// <value>
        /// The name of the parameter.
        /// </value>
        string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the display order.
        /// </summary>
        /// <value>
        /// The display order.
        /// </value>
        string DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the position parameter category identifier.
        /// </summary>
        /// <value>
        /// The POS parameter category identifier.
        /// </value>
        int POSParameterCategoryId { get; set; }
    }
}
