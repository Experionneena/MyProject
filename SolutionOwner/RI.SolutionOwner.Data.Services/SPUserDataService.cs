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
    public class SPUserDataService : BaseDataService, ISPUserDataService
    {
        #region Properties
        private IRepository<ISPUser> _ownerUsers;

        private IRepository<ISPUserRole> _userRoles;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public SPUserDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _ownerUsers = UnitOfWork.Repository<ISPUser>();
            _userRoles = UnitOfWork.Repository<ISPUserRole>();
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Activate and Deactivate a user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public async Task<bool> ActivateDeactivateUser(int userId, int flag)
        {
            try
            {
                var user = await _ownerUsers.GetByIdAsync(userId);
                if (flag == 1)
                {
                    user.IsActive = true;
                }
                else
                {
                    user.IsActive = false;
                }
                _ownerUsers.Update(user);
                var updatedUser = UnitOfWork.Commit();
                return updatedUser == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ISPUser>> GetAllUsers()
        {
            try
            {
                return await _ownerUsers.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var userRoles = (await _userRoles.GetAllAsync()).Where(x => x.UserId == userId).ToList();
                foreach (var userRole in userRoles)
                {
                    _userRoles.Delete(userRole);
                }

                var user = await _ownerUsers.GetByIdAsync(userId);
                _ownerUsers.Delete(user);
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
        /// <param name="ownerUser"></param>
        /// <returns></returns>
        public ISPUser CreateOwnerUser(ISPUser ownerUser)
        {
            try
            {
                ownerUser.LastLoginDate = DateTime.UtcNow;
                var savedUser = _ownerUsers.Add(ownerUser);

                //var userId = (await _ownerUsers.GetAllAsync()).Max(x => x.Id);
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
        /// <param name="roleIdList"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CreateUserRole(List<int> roleIdList, int userId)
        {
            if (roleIdList != null)
            {
                var userRole = new SPUserRole();
                userRole.UserId = userId;
                foreach (var id in roleIdList)
                {
                    userRole.RoleId = id;
                    var savedUserRole = _userRoles.Add(userRole);
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
        /// <returns></returns>
        public async Task<IEnumerable<ISPUserRole>> GetAllUserRoles()
        {
            return await _userRoles.GetAllAsync();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="ownerUser"></param>
        /// <returns></returns>
        public async Task<bool> UpdateOwnerUser(ISPUser ownerUser)
        {
            try
            {
                var userRoleList = (await _userRoles.GetAllAsync()).Where(x => x.UserId == ownerUser.Id).ToList();
                if (userRoleList.Count > 0)
                {
                    foreach (var userRole in userRoleList)
                    {
                        _userRoles.Delete(userRole);
                        UnitOfWork.Commit();
                    }
                }

                var user = await _ownerUsers.GetByIdAsync(ownerUser.Id);

                user.LastLoginDate = ownerUser.LastLoginDate;
                user.IsActive = ownerUser.IsActive;
                user.Name = ownerUser.Name;
                user.IsBlocked = ownerUser.IsBlocked;
                user.Email = ownerUser.Email;
                user.RoleIdList = ownerUser.RoleIdList;
                user.RoleNameList = ownerUser.RoleNameList;
                user.LastLoginDate = DateTime.UtcNow;

                _ownerUsers.Update(user);

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
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<int>> GetRoleIdByUserId(int userId)
        {
            var roleIdList = (await _userRoles.GetAllAsync()).Where(x => x.UserId == userId).Select(x => x.RoleId).ToList();
            return roleIdList;
        }

        /// <summary>
        /// Get a user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ISPUser> GetUserById(int userId)
        {
            return await _ownerUsers.GetByIdAsync(userId);
        }

        /// <summary>
        /// Get user for role Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool GetUserForRoleId(int roleId)
        {
            return _userRoles.Entities.Where(x => x.RoleId == roleId).Any();
        }
        #endregion
    }
}
