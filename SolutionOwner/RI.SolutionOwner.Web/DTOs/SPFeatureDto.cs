//----------------------------------------------------------
// <copyright file="SOFeatureDto.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------
using System;
using System.Collections.Generic;

namespace RI.SolutionOwner.Web.DTOs
{
    /// <summary>
    /// Class SOFeatureDto
    /// </summary>
    public class SPFeatureDto
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
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy identifier.
        /// </summary>
        /// <value>
        /// The hierarchy identifier.
        /// </value>
        public int HierarchyId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public virtual SPCategoryDto Category { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy.
        /// </summary>
        /// <value>
        /// The hierarchy.
        /// </value>
        public virtual HierarchyDto Hierarchy { get; set; }

        /// <summary>
        /// Gets or sets the role permissions.
        /// </summary>
        /// <value>
        /// The role permissions.
        /// </value>
        public virtual ICollection<SPRolePermissionDto> RolePermissions { get; set; }
    }
}