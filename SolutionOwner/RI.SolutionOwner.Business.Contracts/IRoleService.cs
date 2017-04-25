//-----------------------------------------------------------
// <copyright file="IRoleService.cs" company="RechargeIndia">
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
    public interface IRoleService
    {
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ISORole entity.</returns>
        ISORole CreateRole(ISORole role);

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdateRole(ISORole role);

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
        /// <returns>List of ISORole </returns>
        Task<IEnumerable<ISORole>> GetAllRoles();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>ISORole entity.</returns>
        Task<ISORole> GetById(int roleId);
    }
}
