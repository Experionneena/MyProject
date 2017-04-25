//-------------------------------------------------------------
// <copyright file="SOCategory.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------
using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// class SOCategory
    /// </summary>
    public class SOCategory : BaseEntity, ISOCategory
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the display name of the category.
        /// </summary>
        /// <value>
        /// The display name of the category.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the category description of the category.
        /// </summary>
        /// <value>
        /// The category description of the category.
        /// </value>
        public string CategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets the Icon Class of the category.
        /// </summary>
        /// <value>
        /// The Icon Class of the category.
        /// </value>
        public string IconClass { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the category.
        /// </summary>
        /// <value>
        /// The Icon Class of the category.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the parent Id of the category.
        /// </summary>
        /// <value>
        /// The parent Id of the category.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets category
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public virtual SOCategory Category { get; set; }

        /// <summary>
        /// Gets or sets features
        /// </summary>
        /// <value>
        /// features of categories
        /// </value>
        public virtual ICollection<SOFeature> Features { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// category collection.
        /// </value>
        public virtual ICollection<SOCategory> Categories { get; set; }
    }
}
