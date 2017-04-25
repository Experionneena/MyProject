//---------------------------------------------------------
// <copyright file="POSParameterCategory.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// POS Parameter Category Entity
    /// </summary>
    public class POSParameterCategory : BaseEntity, IPOSParameterCategory
    {
        /// <summary>
        /// Gets or sets the parameter category.
        /// </summary>
        /// <value>
        /// The parameter category.
        /// </value>
        public string ParameterCategory { get; set; }

        /// <summary>
        /// Gets or sets the position parameters.
        /// </summary>
        /// <value>
        /// The position parameters.
        /// </value>
        public virtual List<POSParameter> POSParameters { get; set; }
    }
}
