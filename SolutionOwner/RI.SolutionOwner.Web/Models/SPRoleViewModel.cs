﻿//-----------------------------------------------------------
// <copyright file="SPRoleViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// This class defines properties for SPRoleViewModel.
    /// </summary>
    public class SPRoleViewModel
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
        /// Gets or sets the hierarchy identifier.
        /// </summary>
        /// <value>
        /// The hierarchy identifier.
        /// </value>
        public int HierarchyId { get; set; }

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
        public int SPMenuId { get; set; }

        /// <summary>
        /// Gets or sets the so menu list.
        /// </summary>
        /// <value>
        /// The so menu list.
        /// </value>
        public List<SelectListItem> SPMenuList { get; set; }

        /// <summary>
        /// Gets or sets the category list.
        /// </summary>
        /// <value>
        /// The category list.
        /// </value>
        public List<SPCategoryViewModel> CategoryList { get; set; }

        /// <summary>
        /// Gets or sets the role feature permission view model.
        /// </summary>
        /// <value>
        /// The role feature permission view model.
        /// </value>
        public IEnumerable<SPRoleFeaturePermissionViewModel> SPRoleFeaturePermissionViewModel { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy view model list.
        /// </summary>
        /// <value>
        /// The hierarchy view model list.
        /// </value>
        public List<HierarchyViewModel> HierarchyViewModelList { get; set; }

        /// <summary>
        /// Gets or sets the hierachy view model.
        /// </summary>
        /// <value>
        /// The hierachy view model.
        /// </value>
        public HierarchyViewModel HierachyViewModel { get; set; }
    }
}