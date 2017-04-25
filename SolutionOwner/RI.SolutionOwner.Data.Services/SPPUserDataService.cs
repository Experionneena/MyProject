// ---------------------------------------------------------
// <copyright file="SPPUserDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Entities;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// Class SPPUserDataService
    /// </summary>
    public class SPPUserDataService : BaseDataService, ISPPUserDataService
    {
        #region Private Members
        /// <summary>
        /// The partner users
        /// </summary>
        private IRepository<ISPPUser> partnerUsers;

        /// <summary>
        /// The user roles
        /// </summary>
        private IRepository<ISPPUserRole> userRoles;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPPUserDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SPPUserDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.partnerUsers = UnitOfWork.Repository<ISPPUser>();
            this.userRoles = UnitOfWork.Repository<ISPPUserRole>();
        }
        #endregion

        #region Public Functions

        /// <summary>
        /// Activates the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> ActivateUser(int id)
        {
            try
            {
                var user = await partnerUsers.GetByIdAsync(id);
                if (user.IsActive == true)
                {
                    return false;
                }

                if (user.IsActive == false)
                {
                    user.IsActive = true;
                    partnerUsers.Update(user);
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
        /// Deactivates the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> DeactivateUser(int id)
        {
            try
            {
                var user = await partnerUsers.GetByIdAsync(id);
                if (user.IsActive == false)
                {
                    return false;
                }

                if (user.IsActive == true)
                {
                    user.IsActive = false;
                    partnerUsers.Update(user);
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
        /// Get all the users
        /// </summary>
        /// <returns>List of interfaceS</returns>
        public async Task<IEnumerable<ISPPUser>> GetAllUsers()
        {
            try
            {
                return await partnerUsers.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var userRoleList = (await userRoles.GetAllAsync()).Where(x => x.UserId == userId).ToList();

                foreach (var userRole in userRoleList)
                {
                    userRoles.Delete(userRole);
                }

                var user = await partnerUsers.GetByIdAsync(userId);
                partnerUsers.Delete(user);
                var updatedUser = UnitOfWork.Commit();
                return updatedUser == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="partnerUser">partner User</param>
        /// <returns>Interface interface</returns>
        public ISPPUser CreatePartnerUser(ISPPUser partnerUser)
        {
            try
            {
                ////partnerUser.LastLoginDate = DateTime.UtcNow;
                var savedUser = partnerUsers.Add(partnerUser);

                var result = CreateUserRole(partnerUser.RoleIdList as List<int>, savedUser.Id);
                UnitOfWork.Commit();
                return savedUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create user role
        /// </summary>
        /// <param name="roleIdList">role Id List</param>
        /// <param name="userId">user Id</param>
        /// <returns>Boolean value</returns>
        public bool CreateUserRole(List<int> roleIdList, int userId)
        {
            if (roleIdList != null)
            {
                var userRole = new SPPUserRole();
                userRole.UserId = userId;

                foreach (var id in roleIdList)
                {
                    userRole.RoleId = id;
                    var savedUserRole = userRoles.Add(userRole);
                    UnitOfWork.Commit();
                }

                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Get all user roles
        /// </summary>
        /// <returns>List of interfaces</returns>
        public async Task<IEnumerable<ISPPUserRole>> GetAllUserRoles()
        {
            return await userRoles.GetAllAsync();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="partnerUser">partner User</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> UpdatePartnerUser(ISPPUser partnerUser)
        {
            try
            {
                var userRoleList = (await userRoles.GetAllAsync()).Where(x => x.UserId == partnerUser.Id).ToList();

                if (userRoleList.Count > 0)
                {
                    foreach (var userRole in userRoleList)
                    {
                        userRoles.Delete(userRole);
                        UnitOfWork.Commit();
                    }
                }

                var user = await partnerUsers.GetByIdAsync(partnerUser.Id);

                user.IsActive = partnerUser.IsActive;
                user.Name = partnerUser.Name;
                user.IsBlocked = partnerUser.IsBlocked;
                user.Email = partnerUser.Email;
                user.RoleIdList = partnerUser.RoleIdList;
                user.RoleNameList = partnerUser.RoleNameList;
                ////user.LastLoginDate = DateTime.UtcNow;

                partnerUsers.Update(user);

                var result = CreateUserRole(partnerUser.RoleIdList as List<int>, partnerUser.Id);
                var updatedUser = UnitOfWork.Commit();

                return (updatedUser == 0 && result == true) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get roleId userId
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <returns>List of integers</returns>
        public async Task<List<int>> GetRoleIdByUserId(int userId)
        {
            var roleIdList = (await userRoles.GetAllAsync()).Where(x => x.UserId == userId).Select(x => x.RoleId).ToList();
            return roleIdList;
        }

        /// <summary>
        /// Get a user by Id
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <returns>Interface ISPPUser</returns>
        public async Task<ISPPUser> GetUserById(int userId)
        {
            return await partnerUsers.GetByIdAsync(userId);
        }

        /// <summary>
        /// Get user for role Id
        /// </summary>
        /// <param name="roleId">role Id</param>
        /// <returns>Boolean value</returns>
        public bool GetUserForRoleId(int roleId)
        {
            return userRoles.Entities.Where(x => x.RoleId == roleId).Any();
        }
        #endregion
    }
}