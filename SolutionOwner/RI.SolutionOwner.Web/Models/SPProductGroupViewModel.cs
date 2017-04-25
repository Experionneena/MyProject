//---------------------------------------------------------
// <copyright file="SPProductGroupViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// The Solution partner Product group ViewModel.
    /// </summary>
    public class SPProductGroupViewModel
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
        /// Gets or sets the service provider identifier.
        /// </summary>
        /// <value>
        /// The service provider identifier.
        /// </value>
        public int ServiceProviderId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service provider.
        /// </summary>
        /// <value>
        /// The name of the service provider.
        /// </value>
        public string ServiceProviderName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [active status].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [active status]; otherwise, <c>false</c>.
        /// </value>
        public bool ActiveStatus { get; set; }

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
        /// Gets or sets the service providet list.
        /// </summary>
        /// <value>
        /// The service providet list.
        /// </value>
        public List<SelectListItem> ServiceProvidetList { get; set; }
    }
}