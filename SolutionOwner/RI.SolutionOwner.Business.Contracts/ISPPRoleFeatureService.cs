//-----------------------------------------------------------
// <copyright file="ISPPRoleFeatureService.cs" company="RechargeIndia">
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
    public interface ISPPRoleFeatureService
    {
        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>List of ISPPRolePermission</returns>
        Task<IEnumerable<ISPPRolePermission>> GetAllFeaturePermissions();

        /// <summary>
        /// Creates the role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>ISP RolePermission </returns>
        ISPPRolePermission CreateRolePermission(ISPPRolePermission rolePermission);

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdatePermission(ISPPRolePermission rolePermission);
    }
}
