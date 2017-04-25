// ---------------------------------------------------------
// <copyright file="UserController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Controllers
{
    /// <summary>
    /// This controller has action methods for CRUD operations on SOUser.
    /// </summary>
    public class UserController : BaseController
    {
        #region Properties
        /// <summary>
        /// The service provider
        /// </summary>
        private IServiceProvider serviceProvider;

        /// <summary>
        /// The _user mapper
        /// </summary>
        private ObjectMapper<SOUserDto, OwnerUserModel> userMapper;

        /// <summary>
        /// The _role mapper
        /// </summary>
        private ObjectMapper<SORoleDto, RoleViewModel> roleMapper;

        /// <summary>
        /// The _logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="userMapper">The user mapper.</param>
        /// <param name="roleMapper">The role mapper.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="logger">The logger.</param>
        public UserController(
               ObjectMapper<SOUserDto, OwnerUserModel> userMapper, ObjectMapper<SORoleDto, RoleViewModel> roleMapper, IServiceProvider serviceProvider, ILoggerExtension logger)
        {
            this.userMapper = userMapper;
            this.roleMapper = roleMapper;
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }
        #endregion

        #region Public Functions        
        /// <summary>
        /// Index View
        /// </summary>
        /// <returns>returns index view</returns>
        public ActionResult Index()
        {
            List<OwnerUserModel> userList = new List<OwnerUserModel>();
            return View(userList);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>returns List of OwnerUserModel</returns>
        public async Task<List<OwnerUserModel>> GetAllUsers()
        {
            try
            {
                List<OwnerUserModel> userModelList = new List<OwnerUserModel>();
                var response = await Get("souser/GetAllUsers");

                if (response.IsSuccessStatusCode)
                {
                    var souser = await response.Content.ReadAsAsync<IEnumerable<SOUserDto>>();

                    var userList = userMapper.ToObjects(souser).ToList();

                    foreach (var userModel in userList)
                    {
                        string roleNames = string.Join(",", userModel.RoleNameList);
                        userModel.RoleNames = roleNames;
                        userModelList.Add(userModel);
                    }
                }

                return userModelList;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Add user popup
        /// </summary>
        /// <returns>returns _AddUserPopUp partial view</returns>
        public async Task<ActionResult> AddUserPopUp()
        {
            try
            {
                OwnerUserModel user = new OwnerUserModel();
                var responseRoles = await Get("sorole/GetRoles");
                if (responseRoles.IsSuccessStatusCode)
                {
                    var roleListToAdd = (await responseRoles.Content.ReadAsAsync<IEnumerable<SORoleDto>>()).Where(x => x.ActiveStatus == true);
                    user.RoleList = roleMapper.ToObjects(roleListToAdd).ToList();
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_AddUserPopUp", user) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete user Id
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <returns>returns _UserList partial view</returns>
        public async Task<ActionResult> DeleteUserById(int userId)
        {
            try
            {
                List<OwnerUserModel> userList = new List<OwnerUserModel>();

                var response = await Delete("souser/DeleteUser/" + userId);

                if (response.IsSuccessStatusCode)
                {
                    userList = await GetAllUsers();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_UserList", userList), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Activate deactivate user
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <param name="flag">flag to set.</param>
        /// <returns>returns _UserList partial view</returns>
        public async Task<ActionResult> ActivateDeactivateUser(int userId, int flag)
        {
            try
            {
                List<OwnerUserModel> userList = new List<OwnerUserModel>();

                var response = await Put("souser/ActivateDeactivate/" + userId + "/" + flag, null);
                userList = await GetAllUsers();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_UserList", userList), Message = response.ReasonPhrase });
                }

                return Json(new { Status = 0, Message = response.ReasonPhrase });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// User edit
        /// </summary>
        /// <param name="user">OwnerUserModel model.</param>
        /// <returns>returns _UserList partial view</returns>
        public async Task<ActionResult> UserEdit(OwnerUserModel user)
        {
            try
            {
                var userData = userMapper.ToEntity(user);
                var response = await Put("souser/UpdateOwnerUser", userData);
                List<OwnerUserModel> userList = new List<OwnerUserModel>();

                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    userList = await GetAllUsers();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_UserList", userList), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>returns list of roles.</returns>
        public async Task<ActionResult> GetAllRoles()
        {
            try
            {
                var roleList = new List<RoleViewModel>();
                var response = await Get("sorole/GetRoles");

                if (response.IsSuccessStatusCode)
                {
                    var roleListToAdd = await response.Content.ReadAsAsync<IEnumerable<SORoleDto>>();
                    roleList = roleMapper.ToObjects(roleListToAdd).ToList();
                    return Json(roleList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>returns user</returns>
        public async Task<OwnerUserModel> GetUserById(int userId)
        {
            OwnerUserModel user = new OwnerUserModel();
            try
            {
                var response = await Get("souser/GetUser/" + userId);

                if (response.IsSuccessStatusCode)
                {
                    user = userMapper.ToObject(await response.Content.ReadAsAsync<SOUserDto>());
                }

                return user;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get user details for editing
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <returns>returns user details for edit.</returns>
        public async Task<ActionResult> GetUserDetailsForEditById(int userId)
        {
            try
            {
                var userModel = await GetUserById(userId);
                var responseRoles = await Get("sorole/GetRoles");
                if (responseRoles.IsSuccessStatusCode)
                {
                    var roleList = (await responseRoles.Content.ReadAsAsync<IEnumerable<SORoleDto>>()).Where(x => x.ActiveStatus == true);
                    userModel.RoleList = roleMapper.ToObjects(roleList).ToList();

                    userModel.RoleNames = string.Join(",", userModel.RoleList.Select(x => x.RoleName));

                    userModel.RoleIds = string.Join(",", userModel.RoleIdList);

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_EditUserPopUp", userModel), RoleList = userModel.RoleIds, IsActive = userModel.IsActive, IsBlocked = userModel.IsBlocked });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = responseRoles.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Get user list
        /// </summary>
        /// <returns>returns _UserList partial view</returns>
        public async Task<ActionResult> GetUserList()
        {
            try
            {
                List<OwnerUserModel> userList = new List<OwnerUserModel>();

                userList = await GetAllUsers();
                return Json(new { Status = 1, Data = RenderRazorViewToString("_UserList", userList) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Adding user
        /// </summary>
        /// <param name="userModel">OwnerUserModel model.</param>
        /// <returns>returns _UserList partial view</returns>
        public async Task<ActionResult> UserAdd(OwnerUserModel userModel)
        {
            try
            {
                var user = userMapper.ToEntity(userModel);
                var response = await Post("souser/CreateOwnerUser", user);
                List<OwnerUserModel> userList = new List<OwnerUserModel>();
                userList = await GetAllUsers();

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_UserList", userList), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }
        #endregion
    }
}