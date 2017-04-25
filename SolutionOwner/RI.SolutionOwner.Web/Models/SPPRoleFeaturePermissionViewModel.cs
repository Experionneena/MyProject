//---------------------------------------------------------------------------
// <copyright file="SPPRoleFeaturePermissionViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// The Role-feature permission Viewmodel.
    /// </summary>
    public class SPPRoleFeaturePermissionViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        public int FeatureId { get; set; }

        /// <summary>
        /// Gets or sets the name of the feature.
        /// </summary>
        /// <value>
        /// The name of the feature.
        /// </value>
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [create permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [create permission]; otherwise, <c>false</c>.
        /// </value>
        public bool CreatePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [read permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [read permission]; otherwise, <c>false</c>.
        /// </value>
        public bool ReadPermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [update permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [update permission]; otherwise, <c>false</c>.
        /// </value>
        public bool UpdatePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [de avtivate permission].
        /// </summary>
        /// <value>
        /// <c>true</c> if [de avtivate permission]; otherwise, <c>false</c>.
        /// </value>
        public bool DeletePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [approve permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [approve permission]; otherwise, <c>false</c>.
        /// </value>
        public bool ApprovePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [approve permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [approve permission]; otherwise, <c>false</c>.
        /// </value>
        public bool ActivateOrDeactivatePermission { get; set; }
    }
}