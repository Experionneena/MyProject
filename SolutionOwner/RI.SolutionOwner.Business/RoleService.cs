//---------------------------------------------------------
// <copyright file="RoleService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// This class implements the busines rules for performing CRUD operations on Solution Owner Role Entity.
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// The role data service
        /// </summary>
        private IRoleDataService roleDataService;

        /// <summary>
        /// The user data service
        /// </summary>
        private ISOUserDataService userDataService;

        /// <summary>
        /// The role feature data service
        /// </summary>
        private IRoleFeatureDataService roleFeatureDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="roleDataService">The role data service.</param>
        /// <param name="userDataService">The user data service.</param>
        /// <param name="roleFeatureDataService">The role feature data service.</param>
        public RoleService(IRoleDataService roleDataService, ISOUserDataService userDataService, IRoleFeatureDataService roleFeatureDataService)
        {
            this.roleDataService = roleDataService;
            this.userDataService = userDataService;
            this.roleFeatureDataService = roleFeatureDataService;
        }

        /// <summary>
        /// Delete Role By Id
        /// </summary>
        /// <param name="roleId">The role identifier</param>
        /// <returns>returns boolean value</returns>
        public async Task<bool> DeleteRole(int roleId)
        {
            bool result = false;
            result = userDataService.GetUserForRoleId(roleId);
            if (result)
            {
                return false;
            }
            else
            {
                return await roleDataService.DeleteRole(roleId);
            }
        }

        /// <summary>
        /// Get all Roles
        /// </summary>
        /// <returns>returns IEnumerable of ISORole. </returns>
        public async Task<IEnumerable<ISORole>> GetAllRoles()
        {
            return await roleDataService.GetAllRoles();
        }

        /// <summary>
        /// Get Role By Id.
        /// </summary>
        /// <param name="roleId">The role identifier</param>
        /// <returns>returns ISORole entity.</returns>
        public async Task<ISORole> GetById(int roleId)
        {
            return await roleDataService.GetById(roleId);
        }

        /// <summary>
        /// Activates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivateRole(int roleId)
        {
            return await roleDataService.ActivateRole(roleId);
        }

        /// <summary>
        /// Deactivates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivateRole(int roleId)
        {
            return await roleDataService.DeactivateRole(roleId);
        }

        /// <summary>
        /// Create Role.
        /// </summary>
        /// <param name="role">The role entity interface</param>
        /// <returns>returns ISORole entity.</returns>
        public ISORole CreateRole(ISORole role)
        {
            role.CreatedDate = DateTime.Now;
            role.EditedDate = DateTime.Now;
            return roleDataService.CreateRole(role);
        }

        /// <summary>
        /// Update Role.
        /// </summary>
        /// <param name="role">ISORole entity</param>
        /// <returns>returns ISORole entity.</returns>
        public async Task<bool> UpdateRole(ISORole role)
        {
            var result = roleFeatureDataService.DeleteExistingRolePermissions(role.Id);
            var success = await roleDataService.EditRole(role);
            var permissions = role.SORolePermissions;
            foreach (var item in permissions)
            {
                item.RoleId = role.Id;
                roleFeatureDataService.CreateRolePermission(item);
            }

            return success;
        }
    }
}
