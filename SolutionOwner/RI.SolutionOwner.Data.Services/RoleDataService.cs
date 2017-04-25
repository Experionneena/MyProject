//-------------------------------------------------------------
// <copyright file="RoleDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------

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
    /// This class implements CRUD operations on Solution Owner Role entity
    /// </summary>
    public class RoleDataService : BaseDataService, IRoleDataService
    {
        #region Private Members

        /// <summary>
        /// The roles
        /// </summary>
        private IRepository<ISORole> roles;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RoleDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.roles = UnitOfWork.Repository<ISORole>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get all roles
        /// </summary>        
        /// <returns>List of roles</returns>
        public async Task<IEnumerable<ISORole>> GetAllRoles()
        {
            return await roles.GetAllAsync();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>
        /// ISORole entity.
        /// </returns>
        public async Task<ISORole> GetById(int roleId)
        {
            var collection = await roles.GetByIdAsync(roleId);
            return collection;
        }

        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// ISORole entity.
        /// </returns>
        public ISORole CreateRole(ISORole role)
        {
            try
            {
                var roleExist = roles.Entities
                .Where(x => (x.RoleName.Trim().ToLower() == role.RoleName))
                .Any();
                if (!roleExist)
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
                throw ex;
            }
        }

        /// <summary>
        /// Edits the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// boolean value.
        /// </returns>
        public async Task<bool> EditRole(ISORole role)
        {
            try
            {
                bool roleExist = false;

                var roleList = new List<ISORole>(await roles.GetAllAsync());
                if (roleList.Count() > 1)
                {
                    var item = roleList.FirstOrDefault(x => x.Id == role.Id);
                    roleList.Remove(item);
                    roleExist = roleList.Where(x => x.RoleName.Trim().ToLower() == role.RoleName.Trim().ToLower()).Any();
                }

                if (!roleExist)
                {
                    var roleEntity = await roles.GetByIdAsync(role.Id);
                    roleEntity.Id = role.Id;
                    roleEntity.RoleName = role.RoleName;
                    roleEntity.SORolePermissions = role.SORolePermissions;
                    roleEntity.ActiveStatus = role.ActiveStatus;
                    roleEntity.CreatedDate = role.CreatedDate;
                    roleEntity.Description = role.Description;
                    roleEntity.EditedDate = role.EditedDate;
                    roleEntity.FeatureId = role.FeatureId;
                    roles.Update(roleEntity);
                    var updatedrole = UnitOfWork.Commit();
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
        /// Deletes the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>
        /// boolean value.
        /// </returns>
        public async Task<bool> DeleteRole(int roleId)
        {
            try
            {
                var role = await roles.GetByIdAsync(roleId);
                roles.Delete(role);
                var deleteResponse = UnitOfWork.Commit();
                return deleteResponse == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
