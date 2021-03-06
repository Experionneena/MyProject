﻿//-----------------------------------------------------
// <copyright file="ISPRoleDataService.cs" company="RechargeIndia">
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
    /// Interface for RoleDataService. Declaration of methods in RoleDataService.
    /// </summary>
    public interface ISPRoleDataService : IDataService
    {
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ISP Role</returns>
        ISPRole CreateRole(ISPRole role);

        /// <summary>
        /// Edits the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>boolean value</returns>
        Task<bool> EditRole(ISPRole role);

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeleteRole(int roleId);

        /// <summary>
        /// Activates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> ActivateRole(int roleId);

        /// <summary>
        /// Deactivates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeactivateRole(int roleId);

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>ISP Role List</returns>
        Task<IEnumerable<ISPRole>> GetAllRoles();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>ISP Role</returns>
        Task<ISPRole> GetById(int roleId);
    }
}
