//-------------------------------------------------------------
// <copyright file="CategoryController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------

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
    /// class CategoryController
    /// </summary>
    public class CategoryController : BaseController
    {
        // GET: Category
        #region private members      

        /// <summary>
        /// private member categoryMapper
        /// </summary>
        private ObjectMapper<SOCategoryDto, CategoryViewModel> categoryMapper;

        /// <summary>
        /// private member editcategoryMapper
        /// </summary>
        private ObjectMapper<SOCategoryDto, EditCategoryModel> editcategoryMapper;

        /// <summary>
        /// private member logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController" /> class.
        /// </summary>
        /// <param name="categoryMapper">categoryMapper instance</param>
        /// <param name="editcategoryMapper">editcategoryMapper instance</param>
        /// <param name="logger">logger instance</param>
        public CategoryController(ObjectMapper<SOCategoryDto, CategoryViewModel> categoryMapper, ObjectMapper<SOCategoryDto, EditCategoryModel> editcategoryMapper, ILoggerExtension logger)
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
        /// <returns>returns index view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  Loads the add category pop up.
        /// </summary>
        /// <returns>returns _AddPopUp partial view</returns>
        public async Task<ActionResult> LoadCategoryAddPopup()
        {
            try
            {
                List<CategoryViewModel> categoryList = new List<CategoryViewModel>();

                var responseCategories = await Get("Category/GetAllCategories");

                if (responseCategories.StatusCode == HttpStatusCode.OK)
                {
                    var categories = await responseCategories.Content.ReadAsAsync<IEnumerable<SOCategoryDto>>();
                    categoryList = this.categoryMapper.ToObjects(categories).OrderBy(x => x.SortOrder).ToList();
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_AddPopUp", categoryList) });
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>returns CategoryViewModel model</returns>
        public async Task<ActionResult> GetAllCategories()



        {
            try
            {



                List<CategoryViewModel> categoryList = new List<CategoryViewModel>();


                var response = await Get("Category/GetAllCategories");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    categoryList = this.categoryMapper.ToObjects(await response.Content.ReadAsAsync<List<SOCategoryDto>>()).OrderBy(x => x.SortOrder).ToList();
                }

                return Json(new { Status = 1, Data = RenderRazorViewToString("_CategoryList", categoryList) });
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="categoryModal">The category model.</param>
        /// <returns>returns _CategoryList partial view</returns>
        public async Task<ActionResult> CreateCategory(CategoryViewModel categoryModal)
        {
            try
            {
                var category = this.categoryMapper.ToEntity(categoryModal);
                var response = await Post("Category/Create", category);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
                    var responseCategories = await Get("Category/GetAllCategories");

                    if (responseCategories.IsSuccessStatusCode)
                    {
                        categoryList = this.categoryMapper.ToObjects(await responseCategories.Content.ReadAsAsync<List<SOCategoryDto>>()).OrderBy(x => x.SortOrder).ToList();
                        //// categoryList = categoryList.OrderBy(x => x.SortOrder).ToList();
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
                this.logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Get CategoryEdit By Id
        /// </summary>
        /// <param name="categoryId">the Category identifier</param>
        /// <returns>returns EditPopup Partial view.</returns>
        public async Task<ActionResult> GetCategoryEditById(int categoryId)
        {
            try
            {
                var categoryModel = await GetCategoryById(categoryId);
                return Json(new { Status = 1, Data = RenderRazorViewToString("_EditPopUp", categoryModel) });
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="categoryId">category identifier</param>
        /// <returns>the category</returns>
        public async Task<CategoryViewModel> GetCategoryById(int categoryId)
        {
            CategoryViewModel category = new CategoryViewModel();
            try
            {
                var response = await Get("Category/GetCategoryById/" + categoryId);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    category = this.categoryMapper.ToObject(await response.Content.ReadAsAsync<SOCategoryDto>());
                }

                var categoryResponse = await Get("Category/GetAllCategories");

                if (categoryResponse.IsSuccessStatusCode)
                {
                    List<EditCategoryModel> categoryList = new List<EditCategoryModel>();

                    if (category.ParentId != null)
                    {
                        categoryList = this.editcategoryMapper.ToObjects(await categoryResponse.Content.ReadAsAsync<List<SOCategoryDto>>()).Where(x => x.Id != categoryId).ToList();
                        category.CategoryNameList = categoryList;
                    }
                }

                return category;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Delete Category By Id
        /// </summary>
        /// <param name="categoryId">the category identifier</param>
        /// <returns>the _CategoryList Partial View</returns>
        public async Task<ActionResult> DeleteCategoryId(int categoryId)
        {
            try
            {
                List<CategoryViewModel> categoryList = new List<CategoryViewModel>();

                var response = await Delete("Category/DeleteCategory/" + categoryId);

                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    var responseCategories = await Get("Category/GetAllCategories");

                    if (responseCategories.IsSuccessStatusCode)
                    {
                        categoryList = this.categoryMapper.ToObjects(await responseCategories.Content.ReadAsAsync<List<SOCategoryDto>>()).OrderBy(x => x.SortOrder).ToList();
                    }

                    return Json(new { Status = 1, Data = RenderRazorViewToString("_CategoryList", categoryList), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Edit Category
        /// </summary>
        /// <param name="category">the category model</param>
        /// <returns>the _CategoryList Partial View</returns>
        public async Task<ActionResult> EditCategory(CategoryViewModel category)
        {
            try
            {
                var response = await Put("Category/UpdateCategory", category);

                List<CategoryViewModel> categoryList = new List<CategoryViewModel>();

                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    var responseCategories = await Get("Category/GetAllCategories");
                    categoryList = this.categoryMapper.ToObjects(await responseCategories.Content.ReadAsAsync<List<SOCategoryDto>>()).OrderBy(x => x.SortOrder).ToList();
                    return Json(new { Status = 1, Data = RenderRazorViewToString("_CategoryList", categoryList), Message = response.ReasonPhrase });
                }
                else
                {
                    return Json(new { Status = 0, Data = "Error", Message = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return Json(new { Status = 0, Data = "error", Message = ex.Message });
            }
        }
        #endregion
    }
}