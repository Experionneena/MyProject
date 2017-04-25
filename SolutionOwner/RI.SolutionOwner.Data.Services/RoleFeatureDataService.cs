//--------------------------------------------------------------------
// <copyright file="RoleFeatureDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// This class implements CRUD operations on Solution Owner Role Permission entity
    /// </summary>
    public class RoleFeatureDataService : BaseDataService, IRoleFeatureDataService
    {
        #region Private Members        
        /// <summary>
        /// The _role feature
        /// </summary>
        private IRepository<ISORolePermission> roleFeature;

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleFeatureDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RoleFeatureDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            roleFeature = UnitOfWork.Repository<ISORolePermission>();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates the role permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>ISORolePermission interface</returns>
        public bool CreateRolePermission(ISORolePermission rolePermission)
        {
            try
            {
                rolePermission.CreatedDate = DateTime.Now;
                rolePermission.EditedDate = DateTime.Now;
                var item = roleFeature.Add(rolePermission);
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="rolePermission">The role permission.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdatePermission(ISORolePermission rolePermission)
        {
            try
            {
                var rolePermissions = await roleFeature.GetByIdAsync(rolePermission.Id);
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

                roleFeature.Update(rolePermissions);
                var updated = UnitOfWork.Commit();
                ////return isUpdated == 1 ? true : false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the roles for feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>List of RolePermissions</returns>
        public List<ISORolePermission> GetRolesForFeatureId(int featureId)
        {
            var roleFeatures = roleFeature.Entities.Where(x => x.FeatureId == featureId).ToList();
            return roleFeatures;
        }

        /// <summary>
        /// Gets all feature permissions.
        /// </summary>
        /// <returns>List of RolePermissions</returns>
        public async Task<IEnumerable<ISORolePermission>> GetAllFeaturePermissions()
        {
            return await roleFeature.GetAllAsync();
        }

        /// <summary>
        /// Deletes the existing role permissions.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public bool DeleteExistingRolePermissions(int roleId)
        {
            var permissionList = roleFeature.Entities.Where(x => x.RoleId == roleId).ToList();            
            foreach (var item in permissionList)
            {
                roleFeature.Delete(item);
            }

            var deleteResponse = UnitOfWork.Commit();
            return deleteResponse == 0 ? true : false;
        }

        #endregion
    }
}
