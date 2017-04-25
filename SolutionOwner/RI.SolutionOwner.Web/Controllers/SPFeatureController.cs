//-----------------------------------------------------------
// <copyright file="SPFeatureController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ---------------------------------------------------------
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
    /// The Solution owner Feature Controller.
    /// </summary>
    public class SPFeatureController : BaseController
    {
        // GET: Feature
        #region Private Members      

        /// <summary>
        /// The hierarchy mapper
        /// </summary>
        private ObjectMapper<HierarchyDto, HierarchyViewModel> hierarchyMapper = null;

        /// <summary>
        /// The feature mapper.
        /// </summary>
        private ObjectMapper<SPFeatureDto, SPFeatureViewModel> featureMapper = null;

        /// <summary>
        /// The category mapper.
        /// </summary>
        private ObjectMapper<SPCategoryDto, SPCategoryViewModel> categoryMapper = null;

        /// <summary>
        /// The logger.
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPFeatureController" /> class.
        /// </summary>
        /// <param name="featureMapper">The feature mapper.</param>
        /// <param name="categoryMapper">The category mapper.</param>
        /// <param name="hierarchyMapper">The hierarchy mapper.</param>
        /// <param name="logger">The logger.</param>
        public SPFeatureController(
            ObjectMapper<SPFeatureDto, SPFeatureViewModel> featureMapper,
            ObjectMapper<SPCategoryDto, SPCategoryViewModel> categoryMapper,
            ObjectMapper<HierarchyDto, HierarchyViewModel> hierarchyMapper,
            ILoggerExtension logger)
        {
            this.featureMapper = featureMapper;
            this.categoryMapper = categoryMapper;
            this.hierarchyMapper = hierarchyMapper;
            this.logger = logger;
        }

        #endregion

        #region Public Methods / Actions

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
        /// <returns>Partial View </returns>
        public async Task<ActionResult> LoadHierarchies()
        {
            try
            {
                SPFeatureViewModel featureVM = new SPFeatureViewModel();
                List<SPFeatureViewModel> featureVMList = new List<SPFeatureViewModel>();
                var hierarchyVMList = await GetAllHierarchies();
                hierarchyVMList = hierarchyVMList.ToList();

                if (hierarchyVMList.Count == 0)
                {
                    return Json(new { Status = 0, Data = "Hierarchies not available", Message = "Hierarchies not available" });
                }

                featureVM.HierarchyViewModelList = hierarchyVMList;
                featureVMList.Add(featureVM);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_Hierarchy", featureVMList) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = -1, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Loads the add pop up.
        /// </summary>
        /// <returns>returns _AddPopUp partial view</returns>
        public async Task<ActionResult> LoadAddPopUp()
        {
            try
            {
                SPFeatureViewModel featureVM = new SPFeatureViewModel();
                var categoryVMList = await GetAllCategories();
                var hierarchyVMList = await GetAllHierarchies();

                categoryVMList
                    .ForEach(c => c.Children = categoryVMList
                    .Where(x => x.ParentId == c.Id)
                    .OrderBy(x => x.SortOrder)
                    .ToList());
                categoryVMList = categoryVMList
                    .Where(x => x.ParentId == 0 || x.ParentId == null)
                    .ToList();
                featureVM.CategoryViewModelList = categoryVMList;
                hierarchyVMList = hierarchyVMList.ToList();
                featureVM.HierarchyViewModelList = hierarchyVMList;
                return Json(new { Status = 1, Data = RenderRazorViewToString("_AddPopUp", featureVM), Message = " " });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the feature list.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>Partial View</returns>
        public async Task<ActionResult> GetFeatureList(int hierarchyId)
        {
            try
            {
                var featureList = await GetFeatureByHierarchy(hierarchyId);
                var categoryListViewModel = await GetAllCategories();
                var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_FeatureList", featureListForRendering), Message = " " }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the feature by identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>Partial View</returns>
        public async Task<ActionResult> DeleteFeatureById(int featureId, int hierarchyId)
        {
            try
            {
                List<SPFeatureViewModel> featureList = new List<SPFeatureViewModel>();

                var response = await Delete("SPFeature/DeleteFeature/" + featureId);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    featureList = await GetFeatureByHierarchy(hierarchyId);
                    var categoryListViewModel = await GetAllCategories();
                    var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_FeatureList", featureListForRendering), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Activates the deactivate.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>returns _FeatureList partial view</returns>
        public async Task<ActionResult> ActivateDeactivate(int featureId, int flag, int hierarchyId)
        {
            try
            {
                List<SPFeatureViewModel> featureList = new List<SPFeatureViewModel>();
                var response = await Get("SPFeature/ActivateDeactivateFeature/" + featureId + "/" + flag);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    featureList = await GetFeatureByHierarchy(hierarchyId);
                    var categoryListViewModel = await GetAllCategories();
                    var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_FeatureList", featureListForRendering), Message = response.ReasonPhrase });
                }
                else
                {
                    featureList = await GetFeatureByHierarchy(hierarchyId);
                    var categoryListViewModel = await GetAllCategories();
                    var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                    return Json(new { Status = 0, Data = RenderRazorViewToString("_FeatureList", featureListForRendering), Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>returns _FeatureList partial view</returns>
        public async Task<ActionResult> GetFeatureById(int featureId)
        {
            try
            {
                var featureVM = new SPFeatureViewModel();
                var categoryVMList = await GetAllCategories();
                var hierarchyVMList = await GetAllHierarchies();
                var responseFeatures = await Get("SPFeature/GetFeatureById/" + featureId);

                if (responseFeatures.IsSuccessStatusCode)
                {
                    var feature = await responseFeatures.Content.ReadAsAsync<SPFeatureDto>();
                    featureVM = featureMapper.ToObject(feature);

                    categoryVMList
                        .ForEach(c => c.Children = categoryVMList
                        .Where(x => x.ParentId == c.Id)
                        .OrderBy(x => x.SortOrder)
                        .ToList());

                    categoryVMList = categoryVMList
                        .Where(x => x.ParentId == 0 || x.ParentId == null)
                        .ToList();
                    featureVM.CategoryViewModelList = categoryVMList;
                    hierarchyVMList = hierarchyVMList.ToList();
                    featureVM.HierarchyViewModelList = hierarchyVMList;
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_EditPopUp", featureVM), Message = " " });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Creates the feature.
        /// </summary>
        /// <param name="featureModel">The feature model.</param>
        /// <returns>returns _FeatureList partial view</returns>
        public async Task<ActionResult> CreateFeature(SPFeatureViewModel featureModel)
        {
            try
            {
                var featureEntity = featureMapper.ToEntity(featureModel);
                var response = await Post("SPFeature/CreateFeature", featureEntity);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.Created)
                {
                    List<SPFeatureViewModel> featureList = new List<SPFeatureViewModel>();
                    featureList = await GetFeatureByHierarchy(featureModel.HierarchyId);
                    var categoryListViewModel = await GetAllCategories();

                    featureList
                        .ForEach(x => x.SPCategoryViewModel = categoryListViewModel
                        .Where(c => c.Id == x.CategoryId)
                        .FirstOrDefault());
                    var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_FeatureList", featureListForRendering), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Edits the feature.
        /// </summary>
        /// <param name="featureModel">The feature model.</param>
        /// <returns>returns _FeatureList partial view</returns>
        public async Task<ActionResult> EditFeature(SPFeatureViewModel featureModel)
        {
            try
            {
                var featureEntity = featureMapper.ToEntity(featureModel);
                var response = await Put("SPFeature/EditFeature", featureEntity);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    List<SPFeatureViewModel> featureList = new List<SPFeatureViewModel>();
                    featureList = await GetFeatureByHierarchy(featureModel.HierarchyId);
                    var categoryListViewModel = await GetAllCategories();

                    featureList
                        .ForEach(x => x.SPCategoryViewModel = categoryListViewModel
                        .Where(c => c.Id == x.CategoryId)
                        .FirstOrDefault());
                    var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_FeatureList", featureListForRendering), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        #endregion

        #region Private Methods       

        /// <summary>
        /// Gets the feature by hierarchy.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns> List SPFeatureViewModel</returns>
        public async Task<List<SPFeatureViewModel>> GetFeatureByHierarchy(int id)
        {
            try
            {
                var featureListVM = new List<SPFeatureViewModel>();
                var responseFeatures = await Get("Hierarchy/GetFeatureByHierarchy/" + id);

                if (responseFeatures.IsSuccessStatusCode)
                {
                    var features = await responseFeatures.Content.ReadAsAsync<List<SPFeatureDto>>();
                    featureListVM = featureMapper.ToObjects(features).ToList();
                }

                return featureListVM;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns> List of Category View Model</returns>
        private async Task<List<SPCategoryViewModel>> GetAllCategories()
        {
            try
            {
                var categoryVM = new List<SPCategoryViewModel>();
                var responseCategory = await Get("SPCategory/GetAllCategories");

                if (responseCategory.IsSuccessStatusCode)
                {
                    var categories = await responseCategory.Content.ReadAsAsync<List<SPCategoryDto>>();
                    categoryVM = categoryMapper.ToObjects(categories).ToList();
                }

                return categoryVM;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets all hierarchies.
        /// </summary>
        /// <returns>List Hierarchy View Model</returns>
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
        /// Sets the feature view model.
        /// </summary>
        /// <param name="catergoryModel">The catergory model.</param>
        /// <param name="featureModel">The feature model.</param>
        /// <returns>SPFeature View Model</returns>
        private SPFeatureViewModel SetFeatureViewModel(List<SPCategoryViewModel> catergoryModel, List<SPFeatureViewModel> featureModel)
        {
            SPFeatureViewModel feature = new SPFeatureViewModel();
            feature.CategoryViewModelList = new List<SPCategoryViewModel>();
            List<SPCategoryViewModel> categoryList = new List<SPCategoryViewModel>();
            try
            {
                var categoryListToAdd = catergoryModel.Where(x => x.ParentId == null).ToList();
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

                List<SPCategoryViewModel> subcategoryListToAdd = SetFeatureViewModelSplit(catergoryModel, featureModel);

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

                feature.CategoryViewModelList.AddRange(categoryListToAdd);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }

            return feature;
        }

        /// <summary>
        /// Sets the feature view model split.
        /// </summary>
        /// <param name="catergoryModel">The catergory model.</param>
        /// <param name="featureModel">The feature model.</param>
        /// <returns> List of SPcategoryViewModel</returns>
        private static List<SPCategoryViewModel> SetFeatureViewModelSplit(List<SPCategoryViewModel> catergoryModel, List<SPFeatureViewModel> featureModel)
        {
            var subcategoryListToAdd = catergoryModel.Where(x => x.ParentId != null).ToList();
            foreach (var subcatagory in subcategoryListToAdd)
            {
                subcatagory.FeatureList = new List<SPFeatureViewModel>();
                foreach (var featfeatureItem in featureModel)
                {
                    if (subcatagory.Id == featfeatureItem.CategoryId)
                    {
                        subcatagory.FeatureList.Add(featfeatureItem);
                    }
                }
            }

            return subcategoryListToAdd;
        }
        #endregion
    }
}