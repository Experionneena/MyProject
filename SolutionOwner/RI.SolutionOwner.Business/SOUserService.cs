// ---------------------------------------------------------
// <copyright file="SOUserService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Class SOUserService
    /// </summary>
    public class SOUserService : ISOUserService
    {
        #region Private Members

        /// <summary>
        /// The owner user data service
        /// </summary>
        private ISOUserDataService ownerUserDataService;

        /// <summary>
        /// The role data service
        /// </summary>
        private IRoleDataService roleDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SOUserService"/> class.
        /// </summary>
        /// <param name="ownerDataService">The owner data service.</param>
        /// <param name="roleDataService">The role data service.</param>
        public SOUserService(ISOUserDataService ownerDataService, IRoleDataService roleDataService)
        {
            this.ownerUserDataService = ownerDataService;
            this.roleDataService = roleDataService;
        }
        #endregion

        #region Public Functions

        /// <summary>
        /// Activates the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Boolean value
        /// </returns>
        public async Task<bool> ActivateUser(int id)
        {
            return await ownerUserDataService.ActivateUser(id);
        }

        /// <summary>
        /// Deactivates the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Boolean value
        /// </returns>
        public async Task<bool> DeactivateUser(int id)
        {
            return await ownerUserDataService.DeactivateUser(id);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of interface</returns>
        public async Task<IEnumerable<ISOUser>> GetAllUsers()
        {
            var userList = await ownerUserDataService.GetAllUsers();
            var userRoleList = await GetAllUserRoles();
            var roleList = (await roleDataService.GetAllRoles()).Where(x => x.ActiveStatus == true);

            List<ISOUser> newUserList = new List<ISOUser>();

            foreach (var user in userList)
            {
                var roleNameList = userList
                          .Where(
                          w => w.Id == user.Id)
                          .Join(
                          userRoleList,
                          u => u.Id,
                          r => r.UserId,
                          (u, r) => new { RoleId = r.RoleId })
                          .Join(
                          roleList,
                          u => u.RoleId,
                          r => r.Id,
                          (u, r) => new { RoleName = r.RoleName })
                          .Select(x => x.RoleName).ToList();

                user.RoleNameList = roleNameList;
                if (roleNameList.Count == 0)
                {
                    user.IsActive = false;
                }

                newUserList.Add(user);
            }

            return newUserList;
        }

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> DeleteUser(int userId)
        {
            return await ownerUserDataService.DeleteUser(userId);
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <returns>Interface ISOUser</returns>
        public async Task<ISOUser> GetUserById(int userId)
        {
            var user = await ownerUserDataService.GetUserById(userId);
            user.RoleIdList = await ownerUserDataService.GetRoleIdByUserId(userId);
            return user;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="ownerUser">owner User</param>
        /// <returns>Interface ISOUser</returns>
        public async Task<ISOUser> CreateOwnerUser(ISOUser ownerUser)
        {
            IEnumerable<ISOUser> userList = await GetAllUsers();
            var user = userList.Where(x => x.Email == ownerUser.Email).FirstOrDefault();

            if (user == null)
            {
                var userCreated = ownerUserDataService.CreateOwnerUser(ownerUser);
                return null;
            }
            else
            {
                return user;
            }
        }

        /// <summary>
        /// Get roleIds by user id
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <returns>List of integers</returns>
        public async Task<List<int>> GetRoleIdsByUserId(int userId)
        {
            var a = await ownerUserDataService.GetRoleIdByUserId(userId);
            return a;
        }

        /// <summary>
        /// Get all user roles
        /// </summary>
        /// <returns>List of interfaces</returns>
        public async Task<IEnumerable<ISOUserRole>> GetAllUserRoles()
        {
            return await ownerUserDataService.GetAllUserRoles();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="ownerUser">owner User</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> UpdateOwnerUser(ISOUser ownerUser)
        {
            var user = (await ownerUserDataService.GetAllUsers()).Where(x => x.Email == ownerUser.Email).FirstOrDefault();

            if (user == null || user.Id == ownerUser.Id)
            {
                var userUpdated = await ownerUserDataService.UpdateOwnerUser(ownerUser);
                return true;
            }
            else
            {
                string username = user.Name;
                return false;
            }
        }

        #endregion
    }
}