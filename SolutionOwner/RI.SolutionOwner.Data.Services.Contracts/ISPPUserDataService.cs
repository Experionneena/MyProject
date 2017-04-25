// ---------------------------------------------------------
// <copyright file="ISPPUserDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// Interface ISPPUserDataService
    /// </summary>
    public interface ISPPUserDataService : IDataService
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
        /// Delete users
        /// </summary>
        /// <param name="userId">User id to delete a user</param>
        /// <returns>boolean value</returns>
        Task<bool> DeleteUser(int userId);

        /// <summary>
        /// Create partner users
        /// </summary>
        /// <param name="partnerUser">Create a user</param>
        /// <returns>ISPPUser interface</returns>
      ISPPUser CreatePartnerUser(ISPPUser partnerUser);

        /// <summary>
        /// Update partner users
        /// </summary>
        /// <param name="partnerUser">Update a user</param>
        /// <returns>ISPPUser interface</returns>
       Task<bool> UpdatePartnerUser(ISPPUser partnerUser);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId">Get a user by id</param>
        /// <returns>ISPPUser interface</returns>
        Task<ISPPUser> GetUserById(int userId);

        /// <summary>
        /// Get roleid by userId
        /// </summary>
        /// <param name="userId">Get roleid by user id</param>
        /// <returns>integer value</returns>
        Task<List<int>> GetRoleIdByUserId(int userId);

        /// <summary>
        /// Get all user roles
        /// </summary>
        /// <returns>List of ISPPUser interface</returns>
       Task<IEnumerable<ISPPUserRole>> GetAllUserRoles();

        /// <summary>
        /// Get user for role Id
        /// </summary>
        /// <param name="roleId">Role id to get user</param>
        /// <returns>boolean value</returns>
        bool GetUserForRoleId(int roleId);
    }
}
