//-----------------------------------------------------------
// <copyright file="ISPPRoleService.cs" company="RechargeIndia">
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
    public interface ISPPRoleService
    {
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ISP Role </returns>
        ISPPRole CreateRole(ISPPRole role);

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ISP Role </returns>
        Task<bool> UpdateRole(ISPPRole role);

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
        /// <returns>List of ISPPRole </returns>
        Task<IEnumerable<ISPPRole>> GetAllRoles();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>ISP Role </returns>
        Task<ISPPRole> GetById(int roleId);

        /// <summary>
        /// Gets the role by hierarchy.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>ISPPRole List</returns>
        Task<IEnumerable<ISPPRole>> GetRoleByHierarchy(int hierarchyId);
    }
}
