// ---------------------------------------------------------
// <copyright file="ISPPUserService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface ISPPUserService
    /// </summary>
    public interface ISPPUserService
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
        /// <returns>ISPPUser interface</returns>
        Task<IEnumerable<ISPPUser>> GetAllUsers();

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId">User id to delete a user</param>
        /// <returns>Boolean value</returns>
        Task<bool> DeleteUser(int userId);

        /// <summary>
        /// Creates the partner user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>ISPPUser interface</returns>
        Task<ISPPUser> CreatePartnerUser(ISPPUser user);

        /// <summary>
        /// Updates the partner user.
        /// </summary>
        /// <param name="user">The so user.</param>
        /// <returns>ISPPUser interface</returns>
        Task<bool> UpdatePartnerUser(ISPPUser user);

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>ISPPUser interface</returns>
        Task<ISPPUser> GetUserById(int userId);

        /// <summary>
        /// Gets the role ids by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>list of integers</returns>
        Task<List<int>> GetRoleIdsByUserId(int userId);

        /// <summary>
        /// Gets all user roles.
        /// </summary>
        /// <returns>List of ISPPUser interface</returns>
        Task<IEnumerable<ISPPUserRole>> GetAllUserRoles();
    }
}
