//----------------------------------------------------------
// <copyright file="SPRoleFeatureDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Entities;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// SP Role Feature Data Service class
    /// </summary>
    public class SPRoleFeatureDataService : BaseDataService, ISPRoleFeatureDataService
    {
        #region Private Members

        /// <summary>
        /// SP Role Permission Repository
        /// </summary>
        private IRepository<ISPRolePermission> sproleFeature;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleFeatureDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="logger">The logger.</param>
        public SPRoleFeatureDataService(IUnitOfWork unitOfWork, ILoggerExtension logger) : base(unitOfWork)
        {
            sproleFeature = UnitOfWork.Repository<ISPRolePermission>();
            this.logger = logger;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates the SP role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>ISP Role Permission</returns>
        public ISPRolePermission CreateRolePermission(ISPRolePermission rolePermission)
        {
            try
            {
                rolePermission.CreatedDate = DateTime.Now;
                rolePermission.EditedDate = DateTime.Now;
                var item = sproleFeature.Add(rolePermission);
                UnitOfWork.Commit();
                return item;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Updates the SP role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdatePermission(ISPRolePermission rolePermission)
        {
            try
            {
                var rolePermissions = await sproleFeature.GetByIdAsync(rolePermission.Id);
                rolePermissions.ApprovePermission = rolePermission.ApprovePermission;
                rolePermissions.CreatePermission = rolePermission.CreatePermission;
                rolePermissions.DeAvtivatePermission = rolePermission.DeAvtivatePermission;
                rolePermissions.DeletePermission = rolePermission.DeletePermission;
                rolePermissions.ReadPermission = rolePermission.ReadPermission;
                rolePermissions.UpdatePermission = rolePermission.UpdatePermission;
                rolePermissions.RoleId = rolePermission.RoleId;
                rolePermissions.FeatureId = rolePermission.FeatureId;
                rolePermissions.CreatedDate = DateTime.Now;
                rolePermissions.Id = rolePermission.Id;

                sproleFeature.Update(rolePermissions);
                var updated = UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Gets the roles that have access to the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>ISP Role Permission List</returns>
        public List<ISPRolePermission> GetRolesForFeatureId(int featureId)
        {
            var roleFeature = sproleFeature.Entities.Where(x => x.FeatureId == featureId).ToList();
            return roleFeature;
        }

        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>ISP Role Permission List</returns>
        public async Task<IEnumerable<ISPRolePermission>> GetAllFeaturePermissions()
        {
            return await sproleFeature.GetAllAsync();
        }

        /// <summary>
        /// Deletes the existing role permissions.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public bool DeleteExistingRolePermissions(int roleId)
        {
            var permissionList = sproleFeature.Entities.Where(x => x.RoleId == roleId).ToList();
            foreach (var item in permissionList)
            {
                sproleFeature.Delete(item);
            }

            var deleteResponse = UnitOfWork.Commit();
            return deleteResponse == 0 ? true : false;
        }

        #endregion
    }
}
