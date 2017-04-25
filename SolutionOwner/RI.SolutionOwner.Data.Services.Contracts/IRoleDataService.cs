//--------------------------------------------------------------
// <copyright file="IRoleDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// Interface for RoleDataService. Contains declaration of methods in RoleDataService.
    /// </summary>
    public interface IRoleDataService : IDataService
    {
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>ISORole entity.</returns>
        ISORole CreateRole(ISORole role);

        /// <summary>
        /// Edits the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>boolean value </returns>
        Task<bool> EditRole(ISORole role);

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
        /// <returns>
        /// List of ISORole
        /// </returns>
        Task<IEnumerable<ISORole>> GetAllRoles();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>ISORole entity.</returns>
        Task<ISORole> GetById(int roleId);
    }
}
