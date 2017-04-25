//-----------------------------------------------------
// <copyright file="SPRoleService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Business;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// SPRoleService class
    /// </summary>
    public class SPRoleService : ISPRoleService
    {
        /// <summary>
        /// The _role data service
        /// </summary>
        private ISPRoleDataService sproleDataService;

        /// <summary>
        /// The _role feature data service
        /// </summary>
        private ISPRoleFeatureDataService sproleFeatureDataService;

        /// <summary>
        /// The _user data service
        /// </summary>
        private ISPUserDataService spuserDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleService"/> class.
        /// </summary>
        /// <param name="roleDataService">The role data service.</param>
        /// <param name="userDataService">The user data service.</param>
        /// <param name="roleFeatureDataService">The role feature data service.</param>
        public SPRoleService(ISPRoleDataService roleDataService, ISPUserDataService userDataService, ISPRoleFeatureDataService roleFeatureDataService)
        {
            this.sproleDataService = roleDataService;
            this.spuserDataService = userDataService;
            this.sproleFeatureDataService = roleFeatureDataService;
        }

        /// <summary>
        /// Delete Role By Id
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns>bool value</returns>
        public async Task<bool> DeleteRole(int roleId)
        {
            bool result = false;
            result = spuserDataService.GetUserForRoleId(roleId);
            if (result)
            {
                return false;
            }
            else
            {
                return await sproleDataService.DeleteRole(roleId);
            }
        }

        /// <summary>
        /// Get all Roles
        /// </summary>
        /// <returns>ISPRole List</returns>
        public async Task<IEnumerable<ISPRole>> GetAllRoles()
        {
            return await sproleDataService.GetAllRoles();
        }

        /// <summary>
        /// Get Role By Id
        /// </summary>
        /// <param name="roleId">Role Id</param>
        /// <returns>ISP Role</returns>
        public async Task<ISPRole> GetById(int roleId)
        {
            return await sproleDataService.GetById(roleId);
        }

        /// <summary>
        /// Activates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivateRole(int roleId)
        {
            return await sproleDataService.ActivateRole(roleId);
        }

        /// <summary>
        /// Deactivates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivateRole(int roleId)
        {
            return await sproleDataService.DeactivateRole(roleId);
        }

        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="role">The role</param>
        /// <returns>ISP Role</returns>
        public ISPRole CreateRole(ISPRole role)
        {
            role.CreatedDate = DateTime.Now;
            role.EditedDate = DateTime.Now;
            return sproleDataService.CreateRole(role);
        }

        /// <summary>
        /// Edit Role
        /// </summary>
        /// <param name="role">The role</param>
        /// <returns>ISP Role</returns>
        public async Task<bool> UpdateRole(ISPRole role)
        {
            var result = sproleFeatureDataService.DeleteExistingRolePermissions(role.Id);
            var success = await sproleDataService.EditRole(role);
            var permissions = role.SPRolePermissions;
            foreach (var item in permissions)
            {
                item.RoleId = role.Id;
                sproleFeatureDataService.CreateRolePermission(item);
            }

            return success;
        }

        /// <summary>
        /// Gets the feature by hierarchy.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>ISPRole List</returns>
        public async Task<IEnumerable<ISPRole>> GetRoleByHierarchy(int hierarchyId)
        {
            var roles = await sproleDataService.GetAllRoles();
            return roles.Where(x => x.HierarchyId == hierarchyId);
        }
    }
}
