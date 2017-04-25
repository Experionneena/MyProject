//----------------------------------------------------------
// <copyright file="RoleController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Controllers;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// This controller has action methods for CRUD operations on SORole.
    /// </summary>
    public class RoleController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The _role mapper
        /// </summary>
        private ObjectMapper<SORoleDto, RoleViewModel> roleMapper;

        /// <summary>
        /// The _feature view model
        /// </summary>
        private ObjectMapper<SOFeatureDto, FeatureViewModel> featureViewModel;

        /// <summary>
        /// The _category view model
        /// </summary>
        private ObjectMapper<SOCategoryDto, CategoryViewModel> categoryViewModel;

        /// <summary>
        /// The _role feature permission mapper
        /// </summary>
        private ObjectMapper<SORolePermissionDto, RoleFeaturePermissionViewModel> roleFeaturePermissionMapper;

        /// <summary>
        /// The _feature mapper
        /// </summary>
        private ObjectMapper<SOFeatureDto, FeatureViewModel> featureMapper;

        /// <summary>
        /// The _category mapper
        /// </summary>
        private ObjectMapper<SOCategoryDto, CategoryViewModel> categoryMapper;

        /// <summary>
        /// The _logger
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController" /> class.
        /// </summary>
        /// <param name="roleMapper">The role mapper.</param>
        /// <param name="featureMapper">The feature mapper.</param>
        /// <param name="categoryMapper">The category mapper.</param>
        /// <param name="roleFeaturePermissionMapper">The role feature permission mapper.</param>
        /// <param name="logger">The logger.</param>
        public RoleController(
                    ObjectMapper<SORoleDto, RoleViewModel> roleMapper,
                    ObjectMapper<SOFeatureDto, FeatureViewModel> featureMapper,
                    ObjectMapper<SOCategoryDto, CategoryViewModel> categoryMapper,
                    ObjectMapper<SORolePermissionDto, RoleFeaturePermissionViewModel> roleFeaturePermissionMapper,
                    ILoggerExtension logger)
        {
            this.roleMapper = roleMapper;
            this.featureViewModel = featureMapper;
            this.roleFeaturePermissionMapper = roleFeaturePermissionMapper;
            this.featureMapper = featureMapper;
            this.categoryViewModel = categoryMapper;
            this.categoryMapper = categoryMapper;
            this.logger = logger;
        }

        #endregion

        #region  Public Methods / Actions 

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>returns index view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Loads the add role pop up.
        /// </summary>
        /// <returns>returns _AddPopUp partial view</returns>
        public async Task<ActionResult> LoadAddRolePopUp()
        {
            try
            {
                RoleViewModel roleVM = new RoleViewModel();
                var responseFeatures = await Get("sofeature/GetAllFeatures");
                List<FeatureViewModel> features = new List<FeatureViewModel>();
                if (responseFeatures.StatusCode == HttpStatusCode.OK)
                {
                    var featureList = await responseFeatures.Content.ReadAsAsync<IEnumerable<SOFeatureDto>>();
                    features = featureMapper.ToObjects(featureList).ToList();
                }

                var responseCategories = await Get("category/GetAllCategories");
                List<CategoryViewModel> categories = new List<CategoryViewModel>();
                if (responseFeatures.StatusCode == HttpStatusCode.OK)
                {
                    var categoryList = await responseCategories.Content.ReadAsAsync<IEnumerable<SOCategoryDto>>();
                    categories = categoryMapper.ToObjects(categoryList).ToList();
                }

                roleVM = SetRoleViewModel(roleVM, categories, features);

                return Json(new { Status = 1, Data = RenderRazorViewToString("_AddPopUp", roleVM) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Sets the role view model.
        /// </summary>
        /// <param name="roleviewModel">The roleview model.</param>
        /// <param name="catergoryModel">The catergory model.</param>
        /// <param name="featureModel">The feature model.</param>
        /// <returns>returns RoleViewModel model</returns>
        private RoleViewModel SetRoleViewModel(RoleViewModel roleviewModel, List<CategoryViewModel> catergoryModel, List<FeatureViewModel> featureModel)
        {
            roleviewModel.CategoryList = new List<CategoryViewModel>();
            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();

            if (catergoryModel != null)
            {
                var categoryListToAdd = catergoryModel.Where(x => x.ParentId == null).ToList();
                if (categoryListToAdd != null)
                {
                    foreach (var category in categoryListToAdd)
                    {
                        category.FeatureList = new List<FeatureViewModel>();
                        foreach (var featureItem in featureModel)
                        {
                            if (category.Id == featureItem.CategoryId)
                            {
                                category.FeatureList.Add(featureItem);
                            }
                        }
                    }
                }

                var subcategoryListToAdd = catergoryModel.Where(x => x.ParentId != null).ToList();
                if (subcategoryListToAdd != null)
                {
                    foreach (var subcatagory in subcategoryListToAdd)
                    {
                        subcatagory.FeatureList = new List<FeatureViewModel>();
                        foreach (var featureItem in featureModel)
                        {
                            if (subcatagory.Id == featureItem.CategoryId)
                            {
                                subcatagory.FeatureList.Add(featureItem);
                            }
                        }
                    }
                }

                SetRoleViewModelSplitUp(roleviewModel, categoryListToAdd, subcategoryListToAdd);
            }

            return roleviewModel;
        }

        /// <summary>
        /// Sets the role view model split up.
        /// </summary>
        /// <param name="roleviewModel">The roleview model.</param>
        /// <param name="categoryListToAdd">The category list to add.</param>
        /// <param name="subcategoryListToAdd">The subcategory list to add.</param>
        private static void SetRoleViewModelSplitUp(RoleViewModel roleviewModel, List<CategoryViewModel> categoryListToAdd, List<CategoryViewModel> subcategoryListToAdd)
        {
            if (categoryListToAdd != null)
            {
                foreach (var category in categoryListToAdd)
                {
                    category.Children = new List<CategoryViewModel>();
                    foreach (var subcategoryItem in subcategoryListToAdd)
                    {
                        if (category.Id == subcategoryItem.ParentId)
                        {
                            category.Children.Add(subcategoryItem);
                        }
                    }
                }

                roleviewModel.CategoryList.AddRange(categoryListToAdd);
            }
        }

        /// <summary>
        /// Creates the so role.
        /// </summary>
        /// <param name="roleModel">The role model.</param>
        /// <returns>returns _RoleList partial view</returns>
        public async Task<ActionResult> CreateSORole(RoleViewModel roleModel)
        {
            try
            {
                var roleVM = new List<RoleViewModel>();
                if (roleModel != null)
                {
                    var role = roleMapper.ToEntity(roleModel);
                    var creationResponse = await Post("sorole/CreateSORole", role);
                    if (creationResponse.StatusCode == HttpStatusCode.Created)
                    {
                        roleVM = await GetAllRoles();
                        return Json(new { Status = 1, Data = RenderRazorViewToString("_RoleList", roleVM), Message = creationResponse.ReasonPhrase });
                    }
                    else
                    {
                        return Json(new { Status = 0, Message = creationResponse.ReasonPhrase });
                    }
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_RoleList", roleVM) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Get Role By Id
        /// </summary>
        /// <param name="id">role id</param>
        /// <returns>returns _EditPopUp partial view</returns>
        public async Task<ActionResult> LoadEditRolePopUp(int id)
        {
            try
            {
                RoleViewModel roleVM = new RoleViewModel();
                var roleList = new SORoleDto();
                var responseRoles = await Get("sorole/GetRoleById/" + id);
                if (responseRoles.StatusCode == HttpStatusCode.OK)
                {
                    roleList = await responseRoles.Content.ReadAsAsync<SORoleDto>();
                    roleVM = roleMapper.ToObject(roleList);
                }

                var responseFeatures = await Get("sofeature/GetAllFeatures");
                List<FeatureViewModel> features = new List<FeatureViewModel>();
                if (responseFeatures.StatusCode == HttpStatusCode.OK)
                {
                    var featureList = await responseFeatures.Content.ReadAsAsync<IEnumerable<SOFeatureDto>>();
                    features = featureMapper.ToObjects(featureList).ToList();
                }

                var responseCategories = await Get("category/GetAllCategories");
                List<CategoryViewModel> categories = new List<CategoryViewModel>();
                if (responseCategories.StatusCode == HttpStatusCode.OK)
                {
                    var categoryList = await responseCategories.Content.ReadAsAsync<IEnumerable<SOCategoryDto>>();
                    categories = categoryMapper.ToObjects(categoryList).ToList();
                }

                roleVM = SetRoleViewModel(roleVM, categories, features);
                List<string> checkedPermissions = new List<string>();
                checkedPermissions = SetPermissions(roleList, checkedPermissions);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_EditPopUp", roleVM), IsActive = roleVM.IsActive, checkedPermissions, SelectedHomePage = roleVM.SOMenuId });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Sets the permissions.
        /// </summary>
        /// <param name="roleList">The i role.</param>
        /// <param name="checkedPermissions">The checked permissions.</param>
        /// <returns>return permissions</returns>
        public List<string> SetPermissions(SORoleDto roleList, List<string> checkedPermissions)
        {
            try
            {
                foreach (var item in roleList.SORolePermissions)
                {
                    if (item.ReadPermission == true)
                    {
                        checkedPermissions.Add("readcheckboxEdit_" + item.FeatureId);
                    }

                    if (item.CreatePermission == true)
                    {
                        checkedPermissions.Add("createcheckboxEdit_" + item.FeatureId);
                    }

                    if (item.UpdatePermission == true)
                    {
                        checkedPermissions.Add("updatecheckboxEdit_" + item.FeatureId);
                    }

                    if (item.DeletePermission == true)
                    {
                        checkedPermissions.Add("deletecheckboxEdit_" + item.FeatureId);
                    }

                    if (item.ApprovePermission == true)
                    {
                        checkedPermissions.Add("approvecheckboxEdit_" + item.FeatureId);
                    }

                    if (item.DeAvtivatePermission == true)
                    {
                        checkedPermissions.Add("deactivatecheckboxEdit_" + item.FeatureId);
                    }
                }

                return checkedPermissions;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Updates the owner role.
        /// </summary>
        /// <param name="roleModel">The role model.</param>
        /// <returns>returns _RoleList partial view</returns>
        public async Task<ActionResult> UpdateOwnerRole(RoleViewModel roleModel)
        {
            try
            {
                var roleVM = new List<RoleViewModel>();
                var role = roleMapper.ToEntity(roleModel);
                var creationResponse = await Put("sorole/UpdateSORole", role);
                if (creationResponse.StatusCode == HttpStatusCode.OK)
                {
                    roleVM = await GetAllRoles();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_RoleList", roleVM), Message = creationResponse.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = creationResponse.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete Role by Id
        /// </summary>
        /// <param name="id">role id</param>
        /// <returns>returns _RoleList partial view</returns>
        public async Task<ActionResult> DeleteRole(int id)
        {
            try
            {
                List<RoleViewModel> roleVM = new List<RoleViewModel>();
                var creationResponse = await Delete("sorole/DeleteRole/" + id);
                if (creationResponse.StatusCode == HttpStatusCode.OK)
                {
                    roleVM = await GetAllRoles();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_RoleList", roleVM), Message = creationResponse.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = creationResponse.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Activates the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns _RoleList partial view</returns>
        public async Task<ActionResult> ActivateRole(int id)
        {
            try
            {
                List<RoleViewModel> roleVM = new List<Web.Models.RoleViewModel>();
                var creationResponse = await Put("sorole/ActivateDeactivateRole/" + id + "/1", null);
                if (creationResponse.StatusCode == HttpStatusCode.OK)
                {
                    roleVM = await GetAllRoles();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_RoleList", roleVM), Message = creationResponse.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = creationResponse.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = -1, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Deactivates the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns _RoleList partial view</returns>
        public async Task<ActionResult> DeactivateRole(int id)
        {
            try
            {
                List<RoleViewModel> roleVM = new List<Web.Models.RoleViewModel>();
                var creationResponse = await Put("sorole/ActivateDeactivateRole/" + id + "/0", null);
                if (creationResponse.StatusCode == HttpStatusCode.OK)
                {
                    roleVM = await GetAllRoles();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_RoleList", roleVM), Message = creationResponse.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = creationResponse.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = -1, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>returns RoleViewModel model</returns>
        private async Task<List<RoleViewModel>> GetAllRoles()
        {
            try
            {
                List<RoleViewModel> roles = new List<RoleViewModel>();
                var responseRoles = await Get("sorole/GetRoles");
                if (responseRoles.StatusCode == HttpStatusCode.OK)
                {
                    var roleList = await responseRoles.Content.ReadAsAsync<List<SORoleDto>>();
                    if (roleList != null)
                    {
                        roles = roleMapper.ToObjects(roleList)
                            .ToList();
                    }
                }

                return roles;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>returns _RoleList partial view</returns>
        public async Task<ActionResult> GetRoles()
        {
            try
            {
                var roleList = await GetAllRoles();
                if (roleList != null)
                {
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_RoleList", roleList) });
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_EditPopUp", roleList) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }
    }
}
#endregion