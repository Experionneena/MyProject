//----------------------------------------------------------
// <copyright file="POSParameterCategoryDto.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------
using System;

namespace RI.SolutionOwner.Web.DTOs
{
    /// <summary>
    /// Class POSParameterCategoryDto
    /// </summary>
    public class POSParameterCategoryDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the edited date.
        /// </summary>
        /// <value>
        /// The edited date.
        /// </value>
        public DateTime? EditedDate { get; set; }

        /// <summary>
        /// Gets or sets the parameter category.
        /// </summary>
        /// <value>
        /// The parameter category.
        /// </value>
        public string ParameterCategory { get; set; }
    }
}