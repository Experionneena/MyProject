//-----------------------------------------------------------
// <copyright file="POSParameterModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------

using System.Collections.Generic;
using System.Web.Mvc;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// This class defines properties for POSParameterModel.
    /// </summary>
    public class POSParameterModel
    {
        /// <summary>
        /// Gets or sets the id of the parameter.
        /// </summary>
        /// <value>
        /// The id of the parameter.
        /// </value>
        public int Id { get; set; }

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
        /// Gets or sets the position category list.
        /// </summary>
        /// <value>
        /// The position category list.
        /// </value>
        public List<SelectListItem> PosCategoryList { get; set; }
    }
}