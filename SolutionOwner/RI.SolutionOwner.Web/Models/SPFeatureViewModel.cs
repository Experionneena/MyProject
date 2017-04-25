//-----------------------------------------------------------
// <copyright file="SPFeatureViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ---------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// Solution Partner Feature View Model
    /// </summary>
    public class SPFeatureViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        /// <value>
        /// The icon class.
        /// </value>
        public string IconClass { get; set; }

        /// <summary>
        /// Gets or sets the program link.
        /// </summary>
        /// <value>
        /// The program link.
        /// </value>
        public string ProgramLink { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy identifier.
        /// </summary>
        /// <value>
        /// The hierarchy identifier.
        /// </value>
        public int HierarchyId { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the parent cat identifier.
        /// </summary>
        /// <value>
        /// The parent cat identifier.
        /// </value>
        public int ParentCatId { get; set; }      

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the category view model list.
        /// </summary>
        /// <value>
        /// The category view model list.
        /// </value>
        public List<SPCategoryViewModel> CategoryViewModelList { get; set; }

        /// <summary>
        /// Gets or sets the category view model.
        /// </summary>
        /// <value>
        /// The category view model.
        /// </value>        
        public SPCategoryViewModel SPCategoryViewModel { get; set; }

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