//-----------------------------------------------------
// <copyright file="SPPRoleService.cs" company="RechargeIndia">
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
    /// SPPRoleService class
    /// </summary>
    public class SPPRoleService : ISPPRoleService
    {
        /// <summary>
        /// The _role data service
        /// </summary>
        private ISPPRoleDataService spproleDataService;

        /// <summary>
        /// The _role feature data service
        /// </summary>
        private ISPPRoleFeatureDataService spproleFeatureDataService;

        /// <summary>
        /// The _user data service
        /// </summary>
        private ISPUserDataService spuserDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPPRoleService"/> class.
        /// </summary>
        /// <param name="roleDataService">The role data service.</param>
        /// <param name="userDataService">The user data service.</param>
        /// <param name="roleFeatureDataService">The role feature data service.</param>
        public SPPRoleService(ISPPRoleDataService roleDataService, ISPUserDataService userDataService, ISPPRoleFeatureDataService roleFeatureDataService)
        {
            this.spproleDataService = roleDataService;
            this.spuserDataService = userDataService;
            this.spproleFeatureDataService = roleFeatureDataService;
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
                return await spproleDataService.DeleteRole(roleId);
            }
        }

        /// <summary>
        /// Get all Roles
        /// </summary>
        /// <returns>ISPPRole List</returns>
        public async Task<IEnumerable<ISPPRole>> GetAllRoles()
        {
            return await spproleDataService.GetAllRoles();
        }

        /// <summary>
        /// Get Role By Id
        /// </summary>
        /// <param name="roleId">Role Id</param>
        /// <returns>ISP Role</returns>
        public async Task<ISPPRole> GetById(int roleId)
        {
            return await spproleDataService.GetById(roleId);
        }

        /// <summary>
        /// Activates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivateRole(int roleId)
        {
            return await spproleDataService.ActivateRole(roleId);
        }

        /// <summary>
        /// Deactivates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivateRole(int roleId)
        {
            return await spproleDataService.DeactivateRole(roleId);
        }

        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="role">The role</param>
        /// <returns>ISP Role</returns>
        public ISPPRole CreateRole(ISPPRole role)
        {
            role.CreatedDate = DateTime.Now;
            role.EditedDate = DateTime.Now;
            return spproleDataService.CreateRole(role);
        }

        /// <summary>
        /// Edit Role
        /// </summary>
        /// <param name="role">The role</param>
        /// <returns>ISP Role</returns>
        public async Task<bool> UpdateRole(ISPPRole role)
        {
            var result = spproleFeatureDataService.DeleteExistingRolePermissions(role.Id);
            var success = await spproleDataService.EditRole(role);
            var permissions = role.SPPRolePermissions;
            foreach (var item in permissions)
            {
                item.RoleId = role.Id;
                spproleFeatureDataService.CreateRolePermission(item);
            }

            return success;
        }

        /// <summary>
        /// Gets the feature by hierarchy.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>ISPPRole List</returns>
        public async Task<IEnumerable<ISPPRole>> GetRoleByHierarchy(int hierarchyId)
        {
            var roles = await spproleDataService.GetAllRoles();
            return roles.Where(x => x.HierarchyId == hierarchyId);
        }
    }
}
