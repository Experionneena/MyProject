// ---------------------------------------------------------
// <copyright file="ISOUserDataService.cs" company="RechargeIndia">
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
    /// Interface ISOUserDataService
    /// </summary>
    public interface ISOUserDataService : IDataService
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
        /// Delete users
        /// </summary>
        /// <param name="userId">User id to delete a user</param>
        /// <returns>boolean value</returns>
        Task<bool> DeleteUser(int userId);

        /// <summary>
        /// Create owner users
        /// </summary>
        /// <param name="ownerUser">Create a user</param>
        /// <returns>ISOUser interface</returns>
        ISOUser CreateOwnerUser(ISOUser ownerUser);

        /// <summary>
        /// Update owner users
        /// </summary>
        /// <param name="ownerUser">Update a user</param>
        /// <returns>ISOUser interface</returns>
        Task<bool> UpdateOwnerUser(ISOUser ownerUser);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId">Get a user by id</param>
        /// <returns>ISOUser interface</returns>
        Task<ISOUser> GetUserById(int userId);

        /// <summary>
        /// Get roleid by userId
        /// </summary>
        /// <param name="userId">Get roleid by user id</param>
        /// <returns>integer value</returns>
        Task<List<int>> GetRoleIdByUserId(int userId);

        /// <summary>
        /// Get all user roles
        /// </summary>
        /// <returns>List of ISOUser interface</returns>
        Task<IEnumerable<ISOUserRole>> GetAllUserRoles();

        /// <summary>
        /// Get user for role Id
        /// </summary>
        /// <param name="roleId">Role id to get user</param>
        /// <returns>boolean value</returns>
        bool GetUserForRoleId(int roleId);
    }
}
