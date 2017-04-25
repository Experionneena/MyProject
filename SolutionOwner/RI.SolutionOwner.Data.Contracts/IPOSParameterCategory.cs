//---------------------------------------------------------------
// <copyright file="IPOSParameterCategory.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System;
using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface IPOSParameterCategory
    /// </summary>
    public interface IPOSParameterCategory : IEntity
    {
        /// <summary>
        /// Gets or sets the parameter category.
        /// </summary>
        /// <value>
        /// The parameter category.
        /// </value>
        string ParameterCategory { get; set; }
    }
}
