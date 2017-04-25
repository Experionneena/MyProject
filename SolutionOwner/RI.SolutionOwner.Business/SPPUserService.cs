// ---------------------------------------------------------
// <copyright file="SPPUserService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Class SPPUserService
    /// </summary>
    public class SPPUserService : ISPPUserService
    {
        #region Private Members

        /// <summary>
        /// The partner user data service
        /// </summary>
        private ISPPUserDataService partnerUserDataService;

        /// <summary>
        /// The role data service
        /// </summary>
        private ISPPRoleDataService roleDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPPUserService"/> class.
        /// </summary>
        /// <param name="partnerDataService">The partner data service.</param>
        /// <param name="roleDataService">The role data service.</param>
        public SPPUserService(ISPPUserDataService partnerDataService, ISPPRoleDataService roleDataService)
        {
            this.partnerUserDataService = partnerDataService;
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
            return await partnerUserDataService.ActivateUser(id);
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
            return await partnerUserDataService.DeactivateUser(id);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of interface</returns>
        public async Task<IEnumerable<ISPPUser>> GetAllUsers()
        {
            var userList = await partnerUserDataService.GetAllUsers();
            var userRoleList = await GetAllUserRoles();
            var roleList = (await roleDataService.GetAllRoles()).Where(x => x.ActiveStatus == true);

            List<ISPPUser> newUserList = new List<ISPPUser>();

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
            return await partnerUserDataService.DeleteUser(userId);
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <returns>Interface ISPPUser</returns>
        public async Task<ISPPUser> GetUserById(int userId)
        {
            var user = await partnerUserDataService.GetUserById(userId);
            user.RoleIdList = await partnerUserDataService.GetRoleIdByUserId(userId);
            return user;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="partnerUser">partner User</param>
        /// <returns>Interface ISPPUser</returns>
        public async Task<ISPPUser> CreatePartnerUser(ISPPUser partnerUser)
        {
            IEnumerable<ISPPUser> userList = await GetAllUsers();
            var user = userList.Where(x => x.Email == partnerUser.Email).FirstOrDefault();

            if (user == null)
            {
                var userCreated = partnerUserDataService.CreatePartnerUser(partnerUser);
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
            var a = await partnerUserDataService.GetRoleIdByUserId(userId);
            return a;
        }

        /// <summary>
        /// Get all user roles
        /// </summary>
        /// <returns>List of interfaces</returns>
        public async Task<IEnumerable<ISPPUserRole>> GetAllUserRoles()
        {
            return await partnerUserDataService.GetAllUserRoles();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="partnerUser">partner User</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> UpdatePartnerUser(ISPPUser partnerUser)
        {
            var user = (await partnerUserDataService.GetAllUsers()).Where(x => x.Email == partnerUser.Email).FirstOrDefault();

            if (user == null || user.Id == partnerUser.Id)
            {
                var userUpdated = await partnerUserDataService.UpdatePartnerUser(partnerUser);
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