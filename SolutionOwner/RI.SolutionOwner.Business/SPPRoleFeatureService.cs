//---------------------------------------------------------
// <copyright file="SPPRoleFeatureService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// SP Role Feature Service Class
    /// </summary>
    public class SPPRoleFeatureService : ISPPRoleFeatureService
    {
        #region Private Members

        /// <summary>
        /// The spprole feature data service
        /// </summary>
        private ISPPRoleFeatureDataService spproleFeatureDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPPRoleFeatureService"/> class.
        /// </summary>
        /// <param name="roleFeatureDataService">The role feature data service.</param>
        public SPPRoleFeatureService(ISPPRoleFeatureDataService roleFeatureDataService)
        {
            spproleFeatureDataService = roleFeatureDataService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>
        /// List of ISPPRolePermission
        /// </returns>
        public async Task<IEnumerable<ISPPRolePermission>> GetAllFeaturePermissions()
        {
            return await spproleFeatureDataService.GetAllFeaturePermissions();
        }

        /// <summary>
        /// Creates the role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>
        /// ISP RolePermission
        /// </returns>
        public ISPPRolePermission CreateRolePermission(ISPPRolePermission rolePermission)
        {
            return spproleFeatureDataService.CreateRolePermission(rolePermission);
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public async Task<bool> UpdatePermission(ISPPRolePermission rolePermission)
        {
            return await spproleFeatureDataService.UpdatePermission(rolePermission);
        }

        #endregion
    }
}
