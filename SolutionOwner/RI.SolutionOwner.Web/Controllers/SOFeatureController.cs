//---------------------------------------------------------
// <copyright file="SOFeatureController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------
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
    public class SOFeatureController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The feature mapper.
        /// </summary>
        private ObjectMapper<SOFeatureDto, FeatureViewModel> featureMapper = null;

        /// <summary>
        /// The category mapper.
        /// </summary>
        private ObjectMapper<SOCategoryDto, CategoryViewModel> categoryMapper = null;

        /// <summary>
        /// The logger.
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SOFeatureController"/> class.
        /// </summary>
        /// <param name="featureMapper">The feature mapper.</param>
        /// <param name="categoryMapper">The category mapper.</param>
        /// <param name="logger">The logger.</param>
        public SOFeatureController(
            ObjectMapper<SOFeatureDto, FeatureViewModel> featureMapper,
            ObjectMapper<SOCategoryDto, CategoryViewModel> categoryMapper,
            ILoggerExtension logger)
        {
            this.featureMapper = featureMapper;
            this.categoryMapper = categoryMapper;
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
        /// Loads the add pop up.
        /// </summary>
        /// <returns>returns _AddPopUp partial view</returns>
        public async Task<ActionResult> LoadAddPopUp()
        {
            try
            {
                FeatureViewModel featureVM = new FeatureViewModel();
                var categoryVMList = await GetAllCategories();
                categoryVMList
                    .ForEach(c => c.Children = categoryVMList
                    .Where(x => x.ParentId == c.Id)
                    .OrderBy(x => x.SortOrder)
                    .ToList());
                categoryVMList = categoryVMList
                    .Where(x => x.ParentId == 0 || x.ParentId == null)
                    .ToList();
                featureVM.CategoryViewModelList = categoryVMList;
                ////return PartialView("_AddPopUp", featureVM);
                return Json(new
                {
                    Status = 1,
                    Data = RenderRazorViewToString("_AddPopUp", featureVM),
                    Message = string.Empty
                });
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
        /// <returns>returns _FeatureList partial view</returns>
        public async Task<ActionResult> GetFeatureList()
        {
            try
            {
                var featureList = await GetAllFeatures();
                var categoryListViewModel = await GetAllCategories();
                var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                return Json(
                    new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_FeatureList", featureListForRendering),
                        Message = string.Empty
                    },
                JsonRequestBehavior.AllowGet);
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
        /// <returns>returns _FeatureList partial view</returns>
        public async Task<ActionResult> DeleteFeatureById(int featureId)
        {
            try
            {
                List<FeatureViewModel> featureList = new List<FeatureViewModel>();
                var response = await Delete("SOFeature/DeleteFeature/" + featureId);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    featureList = await GetAllFeatures();
                    var categoryListViewModel = await GetAllCategories();
                    var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                    return Json(new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_FeatureList", featureListForRendering),
                        Message = response.ReasonPhrase
                    });
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
        /// <returns>returns _FeatureList partial view</returns>
        public async Task<ActionResult> ActivateDeactivate(int featureId, int flag)
        {
            try
            {
                List<FeatureViewModel> featureList = new List<FeatureViewModel>();
                var response = await Get("SOFeature/ActivateDeactivateFeature/" + featureId + "/" + flag);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        featureList = await GetAllFeatures();
                        var categoryListViewModel = await GetAllCategories();

                        var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                        return Json(new
                        {
                            Status = 1,
                            Data = RenderRazorViewToString("_FeatureList", featureListForRendering),
                            Message = response.ReasonPhrase
                        });
                    }

                    return Json(new { Status = 0, Data = "error", Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = -1, Data = "error", Message = response.ReasonPhrase });
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
                var featureVM = new FeatureViewModel();
                var categoryVMList = await GetAllCategories();
                var responseFeatures = await Get("SOFeature/GetFeatureById/" + featureId);
                if (responseFeatures.IsSuccessStatusCode)
                {
                    var feature = await responseFeatures.Content.ReadAsAsync<SOFeatureDto>();
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
                }

                return Json(new
                {
                    Status = 1,
                    Data = RenderRazorViewToString("_EditPopUp", featureVM),
                    Message = string.Empty
                });
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
        public async Task<ActionResult> CreateFeature(FeatureViewModel featureModel)
        {
            try
            {
                var featureEntity = featureMapper.ToEntity(featureModel);
                var response = await Post("SOFeature/CreateFeature", featureEntity);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.Created)
                {
                    List<FeatureViewModel> featureList = new List<FeatureViewModel>();
                    featureList = await GetAllFeatures();
                    var categoryListViewModel = await GetAllCategories();
                    featureList
                        .ForEach(x => x.CategoryViewModel = categoryListViewModel
                        .Where(c => c.Id == x.CategoryId)
                        .FirstOrDefault());
                    var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                    return Json(new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_FeatureList", featureListForRendering),
                        Message = response.ReasonPhrase
                    });
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
        public async Task<ActionResult> EditFeature(FeatureViewModel featureModel)
        {
            try
            {
                var featureEntity = featureMapper.ToEntity(featureModel);
                var response = await Put("SOFeature/EditFeature", featureEntity);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { Status = 0, Message = response.ReasonPhrase });
                }
                else if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    List<FeatureViewModel> featureList = new List<FeatureViewModel>();
                    featureList = await GetAllFeatures();
                    var categoryListViewModel = await GetAllCategories();

                    featureList
                        .ForEach(x => x.CategoryViewModel = categoryListViewModel
                        .Where(c => c.Id == x.CategoryId)
                        .FirstOrDefault());
                    var featureListForRendering = SetFeatureViewModel(categoryListViewModel, featureList);
                    return Json(new
                    {
                        Status = 1,
                        Data = RenderRazorViewToString("_FeatureList", featureListForRendering),
                        Message = response.ReasonPhrase
                    });
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
        /// Gets all features.
        /// </summary>
        /// <returns>List of FeatureViewModel</returns>
        private async Task<List<FeatureViewModel>> GetAllFeatures()
        {
            try
            {
                var featureListVM = new List<FeatureViewModel>();
                var responseFeatures = await Get("SOFeature/GetAllFeatures");
                if (responseFeatures.IsSuccessStatusCode)
                {
                    var features = await responseFeatures.Content.ReadAsAsync<List<SOFeatureDto>>();
                    featureListVM = featureMapper.ToObjects(features).OrderBy(x => x.SortOrder)
                        .ToList();
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
        /// <returns>List of CategoryViewModel</returns>
        private async Task<List<CategoryViewModel>> GetAllCategories()
        {
            try
            {
                var categoryVM = new List<CategoryViewModel>();
                var responseCategory = await Get("Category/GetAllCategories");
                if (responseCategory.IsSuccessStatusCode)
                {
                    var categories = await responseCategory.Content.ReadAsAsync<List<SOCategoryDto>>();
                    categoryVM = categoryMapper.ToObjects(categories).OrderBy(x => x.SortOrder)
                        .ToList();
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
        /// Sets the feature view model.
        /// </summary>
        /// <param name="catergoryModel">The catergory model.</param>
        /// <param name="featureModel">The feature model.</param>
        /// <returns>FeatureViewModel object</returns>
        private FeatureViewModel SetFeatureViewModel(List<CategoryViewModel> catergoryModel, List<FeatureViewModel> featureModel)
        {
            FeatureViewModel feature = new FeatureViewModel();
            feature.CategoryViewModelList = new List<CategoryViewModel>();
            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            try
            {
                List<CategoryViewModel> categoryListToAdd = MaptoCategory(catergoryModel, featureModel);

                List<CategoryViewModel> subcategoryListToAdd = MaptoSubCategory(catergoryModel, featureModel);

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
        /// Maptoes the sub category.
        /// </summary>
        /// <param name="catergoryModel">The catergory model.</param>
        /// <param name="featureModel">The feature model.</param>
        /// <returns>List of CategoryViewModel</returns>
        private static List<CategoryViewModel> MaptoSubCategory(List<CategoryViewModel> catergoryModel, List<FeatureViewModel> featureModel)
        {
            var subcategoryListToAdd = catergoryModel.Where(x => x.ParentId != null).ToList();
            foreach (var subcatagory in subcategoryListToAdd)
            {
                subcatagory.FeatureList = new List<FeatureViewModel>();
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

        /// <summary>
        /// Maptoes the category.
        /// </summary>
        /// <param name="catergoryModel">The catergory model.</param>
        /// <param name="featureModel">The feature model.</param>
        /// <returns>List of CategoryViewModel</returns>
        private static List<CategoryViewModel> MaptoCategory(List<CategoryViewModel> catergoryModel, List<FeatureViewModel> featureModel)
        {
            var categoryListToAdd = catergoryModel.Where(x => x.ParentId == null).ToList();
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

            return categoryListToAdd;
        }
        #endregion
    }
}