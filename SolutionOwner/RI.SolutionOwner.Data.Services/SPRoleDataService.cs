//-----------------------------------------------------
// <copyright file="SPRoleDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// SP Role Data Service Class
    /// </summary>
    public class SPRoleDataService : BaseDataService, ISPRoleDataService
    {
        #region Private Members

        /// <summary>
        /// ISPRole Repository
        /// </summary>
        private IRepository<ISPRole> roles;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleDataService" /> class.
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work</param>
        /// <param name="logger">The Logger</param>
        public SPRoleDataService(IUnitOfWork unitOfWork, ILoggerExtension logger) : base(unitOfWork)
        {
            roles = UnitOfWork.Repository<ISPRole>();
            this.logger = logger;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all SP roles.
        /// </summary>
        /// <returns>ISP Role List</returns>
        public async Task<IEnumerable<ISPRole>> GetAllRoles()
        {
            return await roles.GetAllAsync();
        }

        /// <summary>
        /// Gets the SP role by identifier.
        /// </summary>
        /// <param name="roleId">The SP role identifier.</param>
        /// <returns>
        /// ISP Role
        /// </returns>
        public async Task<ISPRole> GetById(int roleId)
        {
            var collection = await roles.GetByIdAsync(roleId);
            return collection;
        }

        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// ISP Role
        /// </returns>
        public ISPRole CreateRole(ISPRole role)
        {
            try
            {
                var exists = roles.Entities
                .Where(x => (x.RoleName.Trim().ToLower() == role.RoleName && x.HierarchyId == role.HierarchyId))
                .Any();
                if (!exists)
                {
                    var savedRole = roles.Add(role);
                    UnitOfWork.Commit();
                    return savedRole;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Edits the SP role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public async Task<bool> EditRole(ISPRole role)
        {
            try
            {
                bool exists = false;

                var roleList = new List<ISPRole>(await roles.GetAllAsync());
                if (roleList.Count() > 1)
                {
                    var item = roleList.FirstOrDefault(x => x.Id == role.Id);
                    roleList.Remove(item);
                    exists = roleList.Where(x => x.RoleName.Trim().ToLower() == role.RoleName.Trim().ToLower()).Any();
                }

                if (!exists)
                {
                    var roleEntity = await roles.GetByIdAsync(role.Id);
                    roleEntity.Id = role.Id;
                    roleEntity.RoleName = role.RoleName;
                    roleEntity.SPRolePermissions = role.SPRolePermissions;
                    roleEntity.ActiveStatus = role.ActiveStatus;
                    roleEntity.Description = role.Description;
                    roleEntity.EditedDate = role.EditedDate;
                    roleEntity.FeatureId = role.FeatureId;
                    roleEntity.HierarchyId = role.HierarchyId;
                    roles.Update(roleEntity);
                    var updatedrole = UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Activates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivateRole(int roleId)
        {
            try
            {
                var entity = await roles.GetByIdAsync(roleId);
                if (entity.ActiveStatus == true)
                {
                    return false;
                }

                if (entity.ActiveStatus == false)
                {
                    entity.ActiveStatus = true;
                    roles.Update(entity);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deactivates the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivateRole(int roleId)
        {
            try
            {
                var entity = await roles.GetByIdAsync(roleId);
                if (entity.ActiveStatus == false)
                {
                    return false;
                }

                if (entity.ActiveStatus == true)
                {
                    entity.ActiveStatus = false;
                    roles.Update(entity);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the SP role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public async Task<bool> DeleteRole(int roleId)
        {
            try
            {
                var item = await roles.GetByIdAsync(roleId);
                roles.Delete(item);
                var deleteResponse = UnitOfWork.Commit();
                return deleteResponse == 0 ? true : false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }

        #endregion
    }
}
