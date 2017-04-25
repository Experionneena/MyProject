//----------------------------------------------------------
// <copyright file="SORoleModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

using System;
using System.Collections.Generic;
using tempMvc = System.Web.Mvc;

namespace RI.SolutionOwner.WebAPI.Ingest.Models
{
    /// <summary>
    /// SORoleModel class 
    /// </summary>
    public class SORoleModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the edited date.
        /// </summary>
        /// <value>
        /// The edited date.
        /// </value>
        public DateTime EditedDate { get; set; }

        /// <summary>
        /// Gets or sets the so menu identifier.
        /// </summary>
        /// <value>
        /// The so menu identifier.
        /// </value>
        public int SOMenuId { get; set; }

        /// <summary>
        /// Gets or sets the so menu select list.
        /// </summary>
        /// <value>
        /// The so menu list.
        /// </value>
        public List<tempMvc.SelectListItem> SOMenuList { get; set; }

        /// <summary>
        /// Gets or sets the feature view model.
        /// </summary>
        /// <value>
        /// The feature view model.
        /// </value>
        public IEnumerable<FeatureViewModel> FeatureViewModel { get; set; }

        /// <summary>
        /// Gets or sets the role feature permission Dto.
        /// </summary>
        /// <value>
        /// The role feature permission Dto.
        /// </value>
        public IEnumerable<SORolePermissionModel> RoleFeaturePermissionDto { get; set; }
    }
}