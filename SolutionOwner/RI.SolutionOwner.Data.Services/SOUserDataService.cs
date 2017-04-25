// ---------------------------------------------------------
// <copyright file="SOUserDataService.cs" company="RechargeIndia">
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
    /// Class SOUserDataService
    /// </summary>
    public class SOUserDataService : BaseDataService, ISOUserDataService
    {
        #region Private Members
        /// <summary>
        /// The owner users
        /// </summary>
        private IRepository<ISOUser> ownerUsers;

        /// <summary>
        /// The user roles
        /// </summary>
        private IRepository<ISOUserRole> userRoles;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SOUserDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SOUserDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.ownerUsers = UnitOfWork.Repository<ISOUser>();
            this.userRoles = UnitOfWork.Repository<ISOUserRole>();
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
                var user = await ownerUsers.GetByIdAsync(id);
                if (user.IsActive == true)
                {
                    return false;
                }

                if (user.IsActive == false)
                {
                    user.IsActive = true;
                    ownerUsers.Update(user);
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
                var user = await ownerUsers.GetByIdAsync(id);
                if (user.IsActive == false)
                {
                    return false;
                }

                if (user.IsActive == true)
                {
                    user.IsActive = false;
                    ownerUsers.Update(user);
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
        public async Task<IEnumerable<ISOUser>> GetAllUsers()
        {
            try
            {
                return await ownerUsers.GetAllAsync();
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

                var user = await ownerUsers.GetByIdAsync(userId);
                ownerUsers.Delete(user);
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
        /// <param name="ownerUser">owner User</param>
        /// <returns>Interface interface</returns>
        public ISOUser CreateOwnerUser(ISOUser ownerUser)
        {
            try
            {
                ////ownerUser.LastLoginDate = DateTime.UtcNow;
                var savedUser = ownerUsers.Add(ownerUser);

                var result = CreateUserRole(ownerUser.RoleIdList as List<int>, savedUser.Id);
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
                var userRole = new SOUserRole();
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
        public async Task<IEnumerable<ISOUserRole>> GetAllUserRoles()
        {
            return await userRoles.GetAllAsync();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="ownerUser">owner User</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> UpdateOwnerUser(ISOUser ownerUser)
        {
            try
            {
                var userRoleList = (await userRoles.GetAllAsync()).Where(x => x.UserId == ownerUser.Id).ToList();

                if (userRoleList.Count > 0)
                {
                    foreach (var userRole in userRoleList)
                    {
                        userRoles.Delete(userRole);
                        UnitOfWork.Commit();
                    }
                }

                var user = await ownerUsers.GetByIdAsync(ownerUser.Id);

                user.IsActive = ownerUser.IsActive;
                user.Name = ownerUser.Name;
                user.IsBlocked = ownerUser.IsBlocked;
                user.Email = ownerUser.Email;
                user.RoleIdList = ownerUser.RoleIdList;
                user.RoleNameList = ownerUser.RoleNameList;
                ////user.LastLoginDate = DateTime.UtcNow;

                ownerUsers.Update(user);

                var result = CreateUserRole(ownerUser.RoleIdList as List<int>, ownerUser.Id);
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
        /// <returns>Interface ISOUser</returns>
        public async Task<ISOUser> GetUserById(int userId)
        {
            return await ownerUsers.GetByIdAsync(userId);
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