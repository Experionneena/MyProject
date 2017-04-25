//----------------------------------------------------------
// <copyright file="SPRoleController.cs" company="RechargeIndia">
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
    /// This controller has action methods for CRUD operations on SPRole.
    /// </summary>
    public class SPRoleController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The _hiearchy mapper
        /// </summary>
        private ObjectMapper<HierarchyDto, HierarchyViewModel> hierarchyMapper = null;

        /// <summary>
        /// The _role mapper
        /// </summary>
        private ObjectMapper<SPRoleDto, SPRoleViewModel> roleMapper;

        /// <summary>
        /// The _feature view model
        /// </summary>
        private ObjectMapper<SPFeatureDto, SPFeatureViewModel> featureViewModel;

        /// <summary>
        /// The _category view model
        /// </summary>
        private ObjectMapper<SPCategoryDto, SPCategoryViewModel> categoryViewModel;

        /// <summary>
        /// The _role feature permission mapper
        /// </summary>
        private ObjectMapper<SPRolePermissionDto, SPRoleFeaturePermissionViewModel> roleFeaturePermissionMapper;

        /// <summary>
        /// The _feature mapper
        /// </summary>
        private ObjectMapper<SPFeatureDto, SPFeatureViewModel> featureMapper;

        /// <summary>
        /// The _category mapper
        /// </summary>
        private ObjectMapper<SPCategoryDto, SPCategoryViewModel> categoryMapper;

        /// <summary>
        /// The _logger
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleController"/> class.
        /// </summary>
        /// <param name="roleMapper">The role mapper.</param>
        /// <param name="featureMapper">The feature mapper.</param>
        /// <param name="categoryMapper">The category mapper.</param>
        /// <param name="hierarchyMapper">The hierarchy mapper.</param>
        /// <param name="roleFeaturePermissionMapper">The role feature permission mapper.</param>
        /// <param name="logger">The logger.</param>
        public SPRoleController(
                    ObjectMapper<SPRoleDto, SPRoleViewModel> roleMapper,
                    ObjectMapper<SPFeatureDto, SPFeatureViewModel> featureMapper,
                    ObjectMapper<SPCategoryDto, SPCategoryViewModel> categoryMapper,
                    ObjectMapper<HierarchyDto, HierarchyViewModel> hierarchyMapper,
                    ObjectMapper<SPRolePermissionDto, SPRoleFeaturePermissionViewModel> roleFeaturePermissionMapper,
                    ILoggerExtension logger)
        {
            this.roleMapper = roleMapper;
            this.featureViewModel = featureMapper;
            this.roleFeaturePermissionMapper = roleFeaturePermissionMapper;
            this.featureMapper = featureMapper;
            this.categoryViewModel = categoryMapper;
            this.categoryMapper = categoryMapper;
            this.hierarchyMapper = hierarchyMapper;
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
        /// Loads the hierarchies.
        /// </summary>
        /// <returns>Hierarchy Partial View</returns>
        public async Task<ActionResult> LoadHierarchies()
        {
            try
            {
                SPRoleViewModel roleVM = new SPRoleViewModel();
                List<SPRoleViewModel> roleVMList = new List<SPRoleViewModel>();
                var hierarchyVMList = await GetAllHierarchies();
                hierarchyVMList = hierarchyVMList.ToList();
                if (hierarchyVMList.Count == 0)
                {
                    return Json(new { Status = 0, Data = "Hierarchies not available", Message = "Hierarchies not available" });
                }

                roleVM.HierarchyViewModelList = hierarchyVMList;
                roleVMList.Add(roleVM);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_Hierarchy", roleVMList) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = -1, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the role list.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>Role List Partial View</returns>
        public async Task<ActionResult> GetRoleList(int hierarchyId)
        {
            try
            {
                List<SPRoleViewModel> roleVMList = new List<SPRoleViewModel>();
                roleVMList = await GetRoleByHierarchy(hierarchyId);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_RoleList", roleVMList), Message = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Loads the add role pop up.
        /// </summary>
        /// <returns>returns _AddPopUp partial view</returns>
        public async Task<ActionResult> LoadAddRolePopUp()
        {
            try
            {
                SPRoleViewModel roleVM = new SPRoleViewModel();
                List<SPFeatureViewModel> features = new List<SPFeatureViewModel>();
                var responseCategories = await Get("SPCategory/GetAllCategories");
                List<SPCategoryViewModel> categories = new List<SPCategoryViewModel>();
                if (responseCategories.StatusCode == HttpStatusCode.OK)
                {
                    var categoryList = await responseCategories.Content.ReadAsAsync<IEnumerable<SPCategoryDto>>();
                    categories = categoryMapper.ToObjects(categoryList).ToList();
                }

                var hierarchies = await GetAllHierarchies();

                roleVM = SetSPRoleViewModel(roleVM, categories, features, hierarchies);

                return Json(new { Status = 1, Data = RenderRazorViewToString("_AddPopUp", roleVM) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Sets the sp role view model.
        /// </summary>
        /// <param name="roleviewModel">The roleview model.</param>
        /// <param name="catergoryModel">The catergory model.</param>
        /// <param name="featureModel">The feature model.</param>
        /// <param name="hierarchyModel">The hierarchy model.</param>
        /// <returns>SP Role View Model</returns>
        private SPRoleViewModel SetSPRoleViewModel(SPRoleViewModel roleviewModel, List<SPCategoryViewModel> catergoryModel, List<SPFeatureViewModel> featureModel, List<HierarchyViewModel> hierarchyModel)
        {
            roleviewModel.CategoryList = new List<SPCategoryViewModel>();
            List<SPCategoryViewModel> categoryList = new List<SPCategoryViewModel>();
            roleviewModel.HierarchyViewModelList = new List<HierarchyViewModel>();
            roleviewModel.HierarchyViewModelList = hierarchyModel;
            if (catergoryModel != null)
            {
                var categoryListToAdd = catergoryModel.Where(x => x.ParentId == null).ToList();
                if (categoryListToAdd != null)
                {
                    foreach (var category in categoryListToAdd)
                    {
                        category.FeatureList = new List<SPFeatureViewModel>();
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
                        subcatagory.FeatureList = new List<SPFeatureViewModel>();
                        foreach (var featureItem in featureModel)
                        {
                            if (subcatagory.Id == featureItem.CategoryId)
                            {
                                subcatagory.FeatureList.Add(featureItem);
                            }
                        }
                    }
                }

                SetSPRoleViewModelSplitUp(roleviewModel, categoryListToAdd, subcategoryListToAdd);
            }

            return roleviewModel;
        }

        /// <summary>
        /// Sets the role view model split up.
        /// </summary>
        /// <param name="roleviewModel">The roleview model.</param>
        /// <param name="categoryListToAdd">The category list to add.</param>
        /// <param name="subcategoryListToAdd">The subcategory list to add.</param>
        private static void SetSPRoleViewModelSplitUp(SPRoleViewModel roleviewModel, List<SPCategoryViewModel> categoryListToAdd, List<SPCategoryViewModel> subcategoryListToAdd)
        {
            if (categoryListToAdd != null)
            {
                foreach (var category in categoryListToAdd)
                {
                    category.Children = new List<SPCategoryViewModel>();
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
        public async Task<ActionResult> CreateSPRole(SPRoleViewModel roleModel)
        {
            try
            {
                var roleVM = new List<SPRoleViewModel>();
                if (roleModel != null)
                {
                    var role = roleMapper.ToEntity(roleModel);
                    var creationResponse = await Post("SPRole/CreateSPRole", role);
                    if (creationResponse.StatusCode == HttpStatusCode.Created)
                    {
                        roleVM = await GetRoleByHierarchy(roleModel.HierarchyId);
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
                SPRoleViewModel roleVM = new SPRoleViewModel();
                var roleList = new SPRoleDto();
                var responseRoles = await Get("SPRole/GetRoleById/" + id);
                if (responseRoles.StatusCode == HttpStatusCode.OK)
                {
                    roleList = await responseRoles.Content.ReadAsAsync<SPRoleDto>();
                    roleVM = roleMapper.ToObject(roleList);
                    Session["role"] = roleList;
                }

                var responseFeatures = await Get("Hierarchy/GetFeatureByHierarchy/" + roleVM.HierarchyId);
                List<SPFeatureViewModel> features = new List<SPFeatureViewModel>();
                if (responseFeatures.StatusCode == HttpStatusCode.OK)
                {
                    var featureList = await responseFeatures.Content.ReadAsAsync<IEnumerable<SPFeatureDto>>();
                    features = featureMapper.ToObjects(featureList).ToList();
                }

                var responseCategories = await Get("SPCategory/GetAllCategories");
                List<SPCategoryViewModel> categories = new List<SPCategoryViewModel>();
                if (responseCategories.StatusCode == HttpStatusCode.OK)
                {
                    var categoryList = await responseCategories.Content.ReadAsAsync<IEnumerable<SPCategoryDto>>();
                    categories = categoryMapper.ToObjects(categoryList).ToList();
                }

                var hierarchies = await GetAllHierarchies();

                roleVM = SetSPRoleViewModel(roleVM, categories, features, hierarchies);
                List<string> checkedPermissions = new List<string>();
                checkedPermissions = SetPermissions(roleList, checkedPermissions);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_EditPopUp", roleVM), IsActive = roleVM.IsActive, checkedPermissions, SelectedHomePage = roleVM.SPMenuId });
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
        public List<string> SetPermissions(SPRoleDto roleList, List<string> checkedPermissions)
        {
            try
            {
                foreach (var item in roleList.RolePermissions)
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
        public async Task<ActionResult> UpdatePartnerRole(SPRoleViewModel roleModel)
        {
            try
            {
                var roleVM = new List<SPRoleViewModel>();
                if (roleModel != null)
                {
                    if (Session["role"] != null)
                    {
                        var roleEdited = (SPRoleDto)Session["role"];
                        foreach (var item in roleEdited.RolePermissions)
                        {
                            foreach (var permission in roleModel.SPRoleFeaturePermissionViewModel)
                            {
                                if (item.FeatureId == permission.FeatureId)
                                {
                                    permission.Id = item.Id;
                                }
                            }
                        }
                    }

                    var role = roleMapper.ToEntity(roleModel);
                    var creationResponse = await Put("SPRole/UpdateSPRole", role);
                    if (creationResponse.StatusCode == HttpStatusCode.OK)
                    {
                        roleVM = await GetRoleByHierarchy(roleModel.HierarchyId);
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
        /// Deletes the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="hierarchyid">The hierarchyid.</param>
        /// <returns>Role List partial view</returns>
        public async Task<ActionResult> DeleteRole(int id, int hierarchyid)
        {
            try
            {
                List<SPRoleViewModel> roleVM = new List<SPRoleViewModel>();
                var creationResponse = await Delete("SPRole/DeleteRole/" + id);
                if (creationResponse.StatusCode == HttpStatusCode.OK)
                {
                    roleVM = await GetRoleByHierarchy(hierarchyid);
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
        /// <param name="hierarchyid">The hierarchyid.</param>
        /// <returns>Role List partial view</returns>
        public async Task<ActionResult> ActivateRole(int id, int hierarchyid)
        {
            try
            {
                List<SPRoleViewModel> roleVM = new List<Web.Models.SPRoleViewModel>();
                var creationResponse = await Put("SPRole/ActivateDeactivateRole/" + id + "/1", null);
                if (creationResponse.StatusCode == HttpStatusCode.OK)
                {
                    roleVM = await GetRoleByHierarchy(hierarchyid);
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
        /// Deactivates the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="hierarchyid">The hierarchyid.</param>
        /// <returns>Role List partial view.</returns>
        public async Task<ActionResult> DeactivateRole(int id, int hierarchyid)
        {
            try
            {
                List<SPRoleViewModel> roleVM = new List<Web.Models.SPRoleViewModel>();
                var creationResponse = await Put("SPRole/ActivateDeactivateRole/" + id + "/0", null);
                if (creationResponse.StatusCode == HttpStatusCode.OK)
                {
                    roleVM = await GetRoleByHierarchy(hierarchyid);
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
        /// Gets all roles.
        /// </summary>
        /// <returns>returns SPRoleViewModel model</returns>
        private async Task<List<SPRoleViewModel>> GetAllRoles()
        {
            try
            {
                List<SPRoleViewModel> roles = new List<SPRoleViewModel>();
                var responseRoles = await Get("SPRole/GetRoles");
                if (responseRoles.StatusCode == HttpStatusCode.OK)
                {
                    var roleList = await responseRoles.Content.ReadAsAsync<List<SPRoleDto>>();
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

        /// <summary>
        /// Gets all hierarchies.
        /// </summary>
        /// <returns>HierarchyViewModel List</returns>
        private async Task<List<HierarchyViewModel>> GetAllHierarchies()
        {
            try
            {
                var hierarchyVM = new List<HierarchyViewModel>();
                var responseCategory = await Get("Hierarchy/GetHierarchy");

                if (responseCategory.IsSuccessStatusCode)
                {
                    var hierarchies = await responseCategory.Content.ReadAsAsync<List<HierarchyDto>>();
                    hierarchyVM = hierarchyMapper.ToObjects(hierarchies).ToList();
                }

                return hierarchyVM;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the role by hierarchy.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>SPRoleViewModel List</returns>
        private async Task<List<SPRoleViewModel>> GetRoleByHierarchy(int hierarchyId)
        {
            try
            {
                var roleListVM = new List<SPRoleViewModel>();
                var responseRoles = await Get("SPRoleHierarchy/GetRoleByHierarchy/" + hierarchyId);

                if (responseRoles.IsSuccessStatusCode)
                {
                    var roles = await responseRoles.Content.ReadAsAsync<List<SPRoleDto>>();
                    roleListVM = roleMapper.ToObjects(roles).ToList();
                }

                return roleListVM;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Reloads the feature permissions.
        /// </summary>
        /// <param name="id">The role identifier.</param>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>Partial View</returns>
        public async Task<ActionResult> ReloadFeaturePermissions(int id, int hierarchyId)
        {
            try
            {
                SPRoleViewModel roleVM = new SPRoleViewModel();
                var roleList = new SPRoleDto();
                var responseRoles = await Get("SPRole/GetRoleById/" + id);
                if (responseRoles.StatusCode == HttpStatusCode.OK)
                {
                    roleList = await responseRoles.Content.ReadAsAsync<SPRoleDto>();
                    roleVM = roleMapper.ToObject(roleList);
                    Session["role"] = roleList;
                }

                var responseFeatures = await Get("Hierarchy/GetFeatureByHierarchy/" + hierarchyId);
                List<SPFeatureViewModel> features = new List<SPFeatureViewModel>();
                if (responseFeatures.StatusCode == HttpStatusCode.OK)
                {
                    var featureList = await responseFeatures.Content.ReadAsAsync<IEnumerable<SPFeatureDto>>();
                    features = featureMapper.ToObjects(featureList).ToList();
                }

                var responseCategories = await Get("SPCategory/GetAllCategories");
                List<SPCategoryViewModel> categories = new List<SPCategoryViewModel>();
                if (responseCategories.StatusCode == HttpStatusCode.OK)
                {
                    var categoryList = await responseCategories.Content.ReadAsAsync<IEnumerable<SPCategoryDto>>();
                    categories = categoryMapper.ToObjects(categoryList).ToList();
                }

                var hierarchies = await GetAllHierarchies();

                roleVM = SetSPRoleViewModel(roleVM, categories, features, hierarchies);
                List<string> checkedPermissions = new List<string>();
                checkedPermissions = SetPermissions(roleList, checkedPermissions);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_FeaturePermissionsList", roleVM), IsActive = roleVM.IsActive, checkedPermissions, SelectedHomePage = roleVM.SPMenuId });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Reloads the feature permissions add.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>Partial View</returns>
        public async Task<ActionResult> ReloadFeaturePermissionsAdd(int hierarchyId)
        {
            try
            {
                SPRoleViewModel roleVM = new SPRoleViewModel();
                var responseFeatures = await Get("Hierarchy/GetFeatureByHierarchy/" + hierarchyId);
                List<SPFeatureViewModel> features = new List<SPFeatureViewModel>();
                if (responseFeatures.StatusCode == HttpStatusCode.OK)
                {
                    var featureList = await responseFeatures.Content.ReadAsAsync<IEnumerable<SPFeatureDto>>();
                    features = featureMapper.ToObjects(featureList).ToList();
                }

                var responseCategories = await Get("SPCategory/GetAllCategories");
                List<SPCategoryViewModel> categories = new List<SPCategoryViewModel>();
                if (responseCategories.StatusCode == HttpStatusCode.OK)
                {
                    var categoryList = await responseCategories.Content.ReadAsAsync<IEnumerable<SPCategoryDto>>();
                    categories = categoryMapper.ToObjects(categoryList).ToList();
                }

                var hierarchies = await GetAllHierarchies();

                roleVM = SetSPRoleViewModel(roleVM, categories, features, hierarchies);

                return Json(new { Status = 1, Data = RenderRazorViewToString("_FeaturePermissionsListAdd", roleVM) });
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