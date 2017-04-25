// ---------------------------------------------------------
// <copyright file="SPCategoryController.cs" company="RechargeIndia">
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
    /// Solution Partner Category Controller
    /// </summary>
    public class SPCategoryController : BaseController
    {
        #region private members      
        /// <summary>
        /// The category mapper
        /// </summary>
        private ObjectMapper<SPCategoryDto, SPCategoryViewModel> categoryMapper;

        /// <summary>
        /// The editcategory mapper
        /// </summary>
        private ObjectMapper<SPCategoryDto, SPEditCategoryModel> editcategoryMapper;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion
        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCategoryController" /> class.
        /// </summary>
        /// <param name="categoryMapper">The category mapper.</param>
        /// <param name="editcategoryMapper">The editcategory mapper.</param>
        /// <param name="logger">The logger.</param>
        public SPCategoryController(ObjectMapper<SPCategoryDto, SPCategoryViewModel> categoryMapper, ObjectMapper<SPCategoryDto, SPEditCategoryModel> editcategoryMapper, ILoggerExtension logger)
        {
            this.categoryMapper = categoryMapper;
            this.editcategoryMapper = editcategoryMapper;
            this.logger = logger;
        }
        #endregion
        #region action methods
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns> Action Resul</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Loads the category add popup.
        /// </summary>
        /// <returns>Action Result</returns>
        public async Task<ActionResult> LoadCategoryAddPopup()
        {
            try
            {
                List<SPCategoryViewModel> categoryList = new List<SPCategoryViewModel>();

                var responseCategories = await Get("SPCategory/GetAllCategories");

                if (responseCategories.StatusCode == HttpStatusCode.OK)
                {
                    var categories = await responseCategories.Content.ReadAsAsync<IEnumerable<SPCategoryDto>>();
                    categoryList = categoryMapper.ToObjects(categories).OrderBy(x => x.SortOrder).ToList();
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_AddPopUp", categoryList) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>Action Result</returns>
        public async Task<ActionResult> GetAllCategories()
        {
            try
            {
                List<SPCategoryViewModel> categoryList = new List<SPCategoryViewModel>();
                var response = await Get("SPCategory/GetAllCategories");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    categoryList = categoryMapper.ToObjects(await response.Content.ReadAsAsync<List<SPCategoryDto>>()).OrderBy(x => x.SortOrder).ToList();
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_CategoryList", categoryList) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="categoryModal">The category modal.</param>
        /// <returns>Action Result</returns>
        public async Task<ActionResult> CreateCategory(SPCategoryViewModel categoryModal)
        {
            try
            {
                var category = categoryMapper.ToEntity(categoryModal);
                var response = await Post("SPCategory/Create", category);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    List<SPCategoryViewModel> categoryList = new List<SPCategoryViewModel>();
                    var responseCategories = await Get("SPCategory/GetAllCategories");
                    if (response.IsSuccessStatusCode)
                    {
                        categoryList = categoryMapper.ToObjects(await responseCategories.Content.ReadAsAsync<List<SPCategoryDto>>()).OrderBy(x => x.SortOrder).ToList();
                    }

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_CategoryList", categoryList), Message = response.ReasonPhrase });
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
        /// Gets the category edit by identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Action Result</returns>
        public async Task<ActionResult> GetCategoryEditById(int categoryId)
        {
            try
            {
                var categoryModel = await GetCategoryById(categoryId);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_EditPopUp", categoryModel) });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>SPCategoryView Model</returns>
        public async Task<SPCategoryViewModel> GetCategoryById(int categoryId)
        {
            SPCategoryViewModel category = new SPCategoryViewModel();
            try
            {
                var response = await Get("SPCategory/GetCategoryById/" + categoryId);
                if (response.IsSuccessStatusCode)
                {
                    category = categoryMapper.ToObject(await response.Content.ReadAsAsync<SPCategoryDto>());
                }

                var categoryResponse = await Get("SPCategory/GetAllCategories");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    List<SPEditCategoryModel> categoryList = new List<SPEditCategoryModel>();
                    if (category.ParentId != null)
                    {
                        categoryList = editcategoryMapper.ToObjects(await categoryResponse.Content.ReadAsAsync<List<SPCategoryDto>>()).Where(x => x.Id != categoryId).ToList();
                        category.CategoryNameList = categoryList;
                    }
                }

                return category;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Deletes the category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Action Result</returns>
        public async Task<ActionResult> DeleteCategoryId(int categoryId)
        {
            try
            {
                List<SPCategoryViewModel> categoryList = new List<SPCategoryViewModel>();
                var response = await Delete("SPCategory/DeleteCategory/" + categoryId);
                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    var responseCategories = await Get("SPCategory/GetAllCategories");
                    if (responseCategories.IsSuccessStatusCode)
                    {
                        categoryList = categoryMapper.ToObjects(await responseCategories.Content.ReadAsAsync<List<SPCategoryDto>>()).OrderBy(x => x.SortOrder).ToList();
                    }

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_CategoryList", categoryList), Message = response.ReasonPhrase });
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
        /// Edits the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Action Result</returns>
        public async Task<ActionResult> EditCategory(SPCategoryViewModel category)
        {
            try
            {
                var response = await Put("SPCategory/UpdateCategory", category);

                List<SPCategoryViewModel> categoryList = new List<SPCategoryViewModel>();

                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    var responseCategories = await Get("SPCategory/GetAllCategories");
                    categoryList = categoryMapper.ToObjects(await responseCategories.Content.ReadAsAsync<List<SPCategoryDto>>()).OrderBy(x => x.SortOrder).ToList();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_CategoryList", categoryList), Message = response.ReasonPhrase });
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