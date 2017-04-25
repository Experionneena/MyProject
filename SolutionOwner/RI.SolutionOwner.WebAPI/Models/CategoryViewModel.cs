//-------------------------------------------------------------
// <copyright file="CategoryViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------
using System;
namespace RI.SolutionOwner.WebAPI.Models
{
    /// <summary>
    /// This class defines properties for CategoryViewModel.
    /// </summary>
    public class CategoryViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        /// <value>
        /// The CategoryName.
        /// </value>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the DisplayName.
        /// </summary>
        /// <value>
        /// The DisplayName.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the CategoryDescription.
        /// </summary>
        /// <value>
        /// The CategoryDescription.
        /// </value>
        public string CategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets the IconClass.
        /// </summary>
        /// <value>
        /// The IconClass.
        /// </value>
        public string IconClass { get; set; }

        /// <summary>
        /// Gets or sets the SortOrder.
        /// </summary>
        /// <value>
        /// The SortOrder.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId.
        /// </summary>
        /// <value>
        /// The CategoryId.
        /// </value>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate.
        /// </summary>
        /// <value>
        /// The CreatedDate.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the EditedDate.
        /// </summary>
        /// <value>
        /// The EditedDate.
        /// </value>
        public DateTime EditedDate { get; set; }
    }
}