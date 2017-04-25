using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    public interface ISPUserDataService : IDataService
    {
        /// <summary>
        /// Activate deactivate user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        Task<bool> ActivateDeactivateUser(int userId, int flag);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ISPUser>> GetAllUsers();

        /// <summary>
        /// Delete users
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> DeleteUser(int userId);

        /// <summary>
        /// Create owner users
        /// </summary>
        /// <param name="ownerUser"></param>
        /// <returns></returns>
        ISPUser CreateOwnerUser(ISPUser ownerUser);

        /// <summary>
        /// Update owner users
        /// </summary>
        /// <param name="ownerUser"></param>
        /// <returns></returns>
        Task<bool> UpdateOwnerUser(ISPUser ownerUser);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ISPUser> GetUserById(int userId);

        /// <summary>
        /// Get roleid by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<int>> GetRoleIdByUserId(int userId);

        /// <summary>
        /// Get all user roles
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ISPUserRole>> GetAllUserRoles();

        /// <summary>
        /// Get user for role Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        bool GetUserForRoleId(int roleId);

    }
}
