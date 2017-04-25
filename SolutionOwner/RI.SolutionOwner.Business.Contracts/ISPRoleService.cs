//-----------------------------------------------------------
// <copyright file="ISPRoleService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface for RoleService. Declaration of methods in Role.
    /// </summary>
    public interface ISPRoleService
    {
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ISP Role </returns>
        ISPRole CreateRole(ISPRole role);

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ISP Role </returns>
        Task<bool> UpdateRole(ISPRole role);

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value </returns>
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
        /// <returns>List of ISPRole </returns>
        Task<IEnumerable<ISPRole>> GetAllRoles();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>ISP Role </returns>
        Task<ISPRole> GetById(int roleId);

        /// <summary>
        /// Gets the role by hierarchy.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>ISPRole List</returns>
        Task<IEnumerable<ISPRole>> GetRoleByHierarchy(int hierarchyId);
    }
}
