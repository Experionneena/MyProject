//---------------------------------------------------------------------
// <copyright file="IRoleFeatureDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// Interface for RoleFeatureDataService. Contains declaration of methods in RoleFeatureDataService.
    /// </summary>
    public interface IRoleFeatureDataService : IDataService
    {
        /// <summary>
        /// Gets the roles for feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>List of ISORolePermission</returns>
        List<ISORolePermission> GetRolesForFeatureId(int featureId);

        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>List of ISORolePermission</returns>
        Task<IEnumerable<ISORolePermission>> GetAllFeaturePermissions();

        /// <summary>
        /// Creates the role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>ISORolePermission entity.</returns>
        bool CreateRolePermission(ISORolePermission rolePermission);

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdatePermission(ISORolePermission rolePermission);

        /// <summary>
        /// Deletes the existing role permissions.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        bool DeleteExistingRolePermissions(int roleId);
    }
}
