//-----------------------------------------------------
// <copyright file="ISPPRoleFeatureDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// SP Role Feature Data Service Interface
    /// </summary>
    public interface ISPPRoleFeatureDataService : IDataService
    {
        /// <summary>
        /// Gets the roles for feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>ISPPRolePermission List</returns>
        List<ISPPRolePermission> GetRolesForFeatureId(int featureId);

        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>ISPPRolePermission List</returns>
        Task<IEnumerable<ISPPRolePermission>> GetAllFeaturePermissions();

        /// <summary>
        /// Creates the role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>ISP Role Permission</returns>
        ISPPRolePermission CreateRolePermission(ISPPRolePermission rolePermission);

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdatePermission(ISPPRolePermission rolePermission);

        /// <summary>
        /// Deletes the existing role permissions.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        bool DeleteExistingRolePermissions(int roleId);
    }
}
