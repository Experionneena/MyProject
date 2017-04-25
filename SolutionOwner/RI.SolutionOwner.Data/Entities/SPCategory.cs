// ---------------------------------------------------------
// <copyright file="SPCategory.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// Solution Partner Category
    /// </summary>
    public class SPCategory : BaseEntity, ISPCategory
    {
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
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public virtual SPCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        /// <value>
        /// The features.
        /// </value>
        public virtual ICollection<SPFeature> Features { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public virtual ICollection<SPCategory> Categories { get; set; }
    }
}
