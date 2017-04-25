//-----------------------------------------------------------
// <copyright file="POSParmeterCategoryModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------

using System.Collections.Generic;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// This class defines properties for POSParameterCategoryModel.
    /// </summary>
    public class POSParmeterCategoryModel
    {
        /// <summary>
        /// Gets or sets the parameter id.
        /// </summary>
        /// <value>
        /// The parameter id.
        /// </value>
        public int Id { get; set; }

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
        public List<POSParameterModel> POSParameters { get; set; }
    }
}