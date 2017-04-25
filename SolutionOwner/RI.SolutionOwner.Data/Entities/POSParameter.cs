//---------------------------------------------------------
// <copyright file="POSParameter.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// POS Parameter Entity
    /// </summary>
    public class POSParameter : BaseEntity, IPOSParameter
    {
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        /// <value>
        /// The name of the parameter.
        /// </value>
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the display order.
        /// </summary>
        /// <value>
        /// The display order.
        /// </value>
        public string DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [active status].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [active status]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the position parameter category identifier.
        /// </summary>
        /// <value>
        /// The POS parameter category identifier.
        /// </value>
        public int POSParameterCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the POS parameter category.
        /// </summary>
        /// <value>
        /// The position parameter category.
        /// </value>
        public virtual POSParameterCategory POSParameterCategory { get; set; }
    }
}
