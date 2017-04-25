// ---------------------------------------------------------
// <copyright file="CategoryController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Ingest.Models;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// class CategoryController
    /// </summary>
    public class CategoryController : BaseController
    {
        #region private members

        /// <summary>
        /// private member categoryService
        /// </summary>
        private ICategoryService categoryService;

        /// <summary>
        /// private member featureService
        /// </summary>
        private IFeatureService featureService;

        /// <summary>
        /// private member logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController" /> class.
        /// </summary>
        /// <param name="categoryService"> categoryService instance</param>
        /// <param name="featureService"> featureService instance</param>
        /// <param name="logger"> logger instance</param>
        public CategoryController(ICategoryService categoryService, IFeatureService featureService, ILoggerExtension logger)
        {
            this.categoryService = categoryService;
            this.featureService = featureService;
            this.logger = logger;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="categoryEntity">categoryEntity model</param>
        /// <returns>boolean value</returns>
        [HttpPost]
        [Route("Category/Create")]
        public HttpResponseMessage Create([ModelBinder(typeof(IocCustomCreationConverter))] ISOCategory categoryEntity)
        {
            {
                bool result = false;
                try
                {
                    result = this.categoryService.CreateCategory(categoryEntity);
                    if (result)
                    {
                        return CreateHttpResponse<ISOCategory>(HttpStatusCode.Created, HttpCustomStatus.Success, null, GetLocalisedString("msgCategoryCreation"));
                    }
                    else
                    {
                        return CreateHttpResponse<ISOCategory>(HttpStatusCode.OK, HttpCustomStatus.Failure, null, GetLocalisedString("msgCategoryDuplicate"));
                    }
                }
                catch (Exception ex)
                {
                    this.logger.Error(ex.Message);
                    return CreateHttpResponse<ISOCategory>(HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
                }
            }
        }

        /// <summary>
        /// Get all categories from DB for listing
        /// </summary>
        /// <returns>Category Object List</returns>
        [HttpGet]
        [Route("Category/GetAllCategories")]
        public HttpResponseMessage GetAllCategories()
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await this.categoryService.GetAllCategories();
                });
                if (null != item.Result)
                {
                    var categories = CreateHttpResponse<IEnumerable<ISOCategory>>(HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, GetLocalisedString("msgSuccess"));
                    return categories;
                }
                else
                {
                    return CreateHttpResponse<IEnumerable<ISOCategory>>(HttpStatusCode.OK, HttpCustomStatus.Failure, null, GetLocalisedString("msgNoRecord"));
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISOCategory>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Delete a particular category according to the id passed
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns>boolean value</returns>
        [HttpDelete]
        [Route("Category/DeleteCategory/{id}")]
        public async Task<HttpResponseMessage> DeleteCategory(int id)
        {
            bool result = false;
            try
            {
                result = await this.categoryService.DeleteCategory(id);
                if (result)
                {
                    return CreateHttpResponse<IEnumerable<ISOCategory>>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgCategoryDeleteSuccess"));
                }
                else
                {
                    return CreateHttpResponse<IEnumerable<ISOCategory>>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgCategoryDeleteWarning"));
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISOCategory>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Get a particular category according to the id passed
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns>category object</returns>
        [HttpGet]
        [Route("Category/GetCategoryById/{id}")]
        public async Task<HttpResponseMessage> GetCategoryById(int id)
        {
            try
            {
                var result = await this.categoryService.GetCategoryById(id);
                if (result != null)
                {
                    var categories = CreateHttpResponse<ISOCategory>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgSuccess"));
                    return categories;
                }
                else
                {
                    return CreateHttpResponse<ISOCategory>(HttpStatusCode.NotFound, HttpCustomStatus.Failure, null, GetLocalisedString("msgNoRecord"));
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<ISOCategory>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Update a category according to the id passed in the model
        /// </summary>
        /// <param name="categoryEntity">categoryEntity model</param>
        /// <returns>boolean value</returns>
        [HttpPut]
        [Route("Category/UpdateCategory")]
        public async Task<HttpResponseMessage> UpdateCategory([ModelBinder(typeof(IocCustomCreationConverter))] ISOCategory categoryEntity)
        {
            try
            {
                var result = await this.categoryService.UpdateCategory(categoryEntity);
                if (result)
                {
                    return CreateHttpResponse<ISOCategory>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgCategoryupdation"));
                }
                else
                {
                    return CreateHttpResponse<ISOCategory>(HttpStatusCode.OK, HttpCustomStatus.Failure, null, GetLocalisedString("msgCategoryDuplicate"));
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<ISOCategory>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }
        #endregion
    }
}
