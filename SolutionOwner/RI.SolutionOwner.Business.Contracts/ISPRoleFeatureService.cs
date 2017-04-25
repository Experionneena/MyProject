//-----------------------------------------------------------
// <copyright file="ISPRoleFeatureService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface for RoleFeatureService. Contains declaration of methods in RoleFeatureService.
    /// </summary>
    public interface ISPRoleFeatureService
    {
        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>List of ISPRolePermission</returns>
        Task<IEnumerable<ISPRolePermission>> GetAllFeaturePermissions();

        /// <summary>
        /// Creates the role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>ISP RolePermission </returns>
        ISPRolePermission CreateRolePermission(ISPRolePermission rolePermission);

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdatePermission(ISPRolePermission rolePermission);
    }
}
