//---------------------------------------------------------
// <copyright file="RoleFeatureService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Class RoleFeatureService
    /// </summary>
    public class RoleFeatureService : IRoleFeatureService
    {
        #region Private Members

        /// <summary>
        /// The role feature data service
        /// </summary>
        private IRoleFeatureDataService roleFeatureDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleFeatureService"/> class.
        /// </summary>
        /// <param name="roleFeatureDataService">The role feature data service.</param>
        public RoleFeatureService(IRoleFeatureDataService roleFeatureDataService)
        {
            this.roleFeatureDataService = roleFeatureDataService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>
        /// List of ISORolePermission
        /// </returns>
        public async Task<IEnumerable<ISORolePermission>> GetAllFeaturePermissions()
        {
            return await roleFeatureDataService.GetAllFeaturePermissions();
        }

        /// <summary>
        /// Creates the role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>
        /// ISORolePermission entity.
        /// </returns>
        public bool CreateRolePermission(ISORolePermission rolePermission)
        {
            return roleFeatureDataService.CreateRolePermission(rolePermission);
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public async Task<bool> UpdatePermission(ISORolePermission rolePermission)
        {
            return await roleFeatureDataService.UpdatePermission(rolePermission);
        }

        #endregion
    }
}
