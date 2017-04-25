// ---------------------------------------------------------
// <copyright file="ISOUserService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface ISOUserService
    /// </summary>
    public interface ISOUserService
    {
        /// <summary>
        /// Activates the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> ActivateUser(int id);

        /// <summary>
        /// Deactivates the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> DeactivateUser(int id);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>ISOUser interface</returns>
        Task<IEnumerable<ISOUser>> GetAllUsers();

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId">User id to delete a user</param>
        /// <returns>Boolean value</returns>
        Task<bool> DeleteUser(int userId);

        /// <summary>
        /// Creates the owner user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>ISOUser interface</returns>
        Task<ISOUser> CreateOwnerUser(ISOUser user);

        /// <summary>
        /// Updates the owner user.
        /// </summary>
        /// <param name="user">The so user.</param>
        /// <returns>ISOUser interface</returns>
        Task<bool> UpdateOwnerUser(ISOUser user);

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>ISOUser interface</returns>
        Task<ISOUser> GetUserById(int userId);

        /// <summary>
        /// Gets the role ids by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>list of integers</returns>
        Task<List<int>> GetRoleIdsByUserId(int userId);

        /// <summary>
        /// Gets all user roles.
        /// </summary>
        /// <returns>List of ISOUser interface</returns>
        Task<IEnumerable<ISOUserRole>> GetAllUserRoles();
    }
}
