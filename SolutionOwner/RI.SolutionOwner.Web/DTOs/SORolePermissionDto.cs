// ---------------------------------------------------------
// <copyright file="SORolePermissionDto.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;

namespace RI.SolutionOwner.Web.DTOs
{
    public class SORolePermissionDto
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
        /// Gets or sets a value indicating whether [edit permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [edit permission]; otherwise, <c>false</c>.
        /// </value>
        public bool UpdatePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [delete permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [delete permission]; otherwise, <c>false</c>.
        /// </value>        
        public bool DeletePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [deactivate permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [deactivate permission]; otherwise, <c>false</c>.
        /// </value> 
        public bool DeAvtivatePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [approve permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [approve permission]; otherwise, <c>false</c>.
        /// </value>
        public bool ApprovePermission { get; set; }
    }
}