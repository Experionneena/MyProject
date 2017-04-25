// ---------------------------------------------------------
// <copyright file="HierarchyViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// Hierarchy View Model
    /// </summary>
    public class HierarchyViewModel
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
    }
}