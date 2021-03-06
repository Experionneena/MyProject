﻿// ---------------------------------------------------------
// <copyright file="SPCategoryViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// Solution Partner Category View Model
    /// </summary>
    public class SPCategoryViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the category description.
        /// </summary>
        /// <value>
        /// The category description.
        /// </value>
        public string CategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        /// <value>
        /// The icon class.
        /// </value>
        public string IconClass { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the category name list.
        /// </summary>
        /// <value>
        /// The category name list.
        /// </value>
        public List<SPEditCategoryModel> CategoryNameList { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier list.
        /// </summary>
        /// <value>
        /// The parent identifier list.
        /// </value>
        public List<int> ParentIdList { get; set; }

        /// <summary>
        /// Gets or sets the feature list.
        /// </summary>
        /// <value>
        /// The feature list.
        /// </value>
        public List<SPFeatureViewModel> FeatureList { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public List<SPCategoryViewModel> Children { get; set; }
    }
}