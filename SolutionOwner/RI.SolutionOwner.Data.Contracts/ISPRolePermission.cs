//-----------------------------------------------------
// <copyright file="ISPRolePermission.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------

using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface for Solution Owner Role Permission Entity
    /// </summary>
    public interface ISPRolePermission : IEntity
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        int FeatureId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [create permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [create permission]; otherwise, <c>false</c>.
        /// </value>
        bool CreatePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [read permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [read permission]; otherwise, <c>false</c>.
        /// </value>
        bool ReadPermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [edit permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [edit permission]; otherwise, <c>false</c>.
        /// </value>
        bool UpdatePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [delete permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [delete permission]; otherwise, <c>false</c>.
        /// </value>        
        bool DeletePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [deactivate permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [deactivate permission]; otherwise, <c>false</c>.
        /// </value> 
        bool DeAvtivatePermission { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [approve permission].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [approve permission]; otherwise, <c>false</c>.
        /// </value>
        bool ApprovePermission { get; set; }
    }
}
