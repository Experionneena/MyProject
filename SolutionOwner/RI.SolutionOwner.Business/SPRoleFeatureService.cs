//---------------------------------------------------------
// <copyright file="SPRoleFeatureService.cs" company="RechargeIndia">
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
    public class SPRoleFeatureService : ISPRoleFeatureService
    {
        #region Private Members

        /// <summary>
        /// The sprole feature data service
        /// </summary>
        private ISPRoleFeatureDataService sproleFeatureDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleFeatureService"/> class.
        /// </summary>
        /// <param name="roleFeatureDataService">The role feature data service.</param>
        public SPRoleFeatureService(ISPRoleFeatureDataService roleFeatureDataService)
        {
            sproleFeatureDataService = roleFeatureDataService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>
        /// List of ISPRolePermission
        /// </returns>
        public async Task<IEnumerable<ISPRolePermission>> GetAllFeaturePermissions()
        {
            return await sproleFeatureDataService.GetAllFeaturePermissions();
        }

        /// <summary>
        /// Creates the role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>
        /// ISP RolePermission
        /// </returns>
        public ISPRolePermission CreateRolePermission(ISPRolePermission rolePermission)
        {
            return sproleFeatureDataService.CreateRolePermission(rolePermission);
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public async Task<bool> UpdatePermission(ISPRolePermission rolePermission)
        {
            return await sproleFeatureDataService.UpdatePermission(rolePermission);
        }

        #endregion
    }
}
