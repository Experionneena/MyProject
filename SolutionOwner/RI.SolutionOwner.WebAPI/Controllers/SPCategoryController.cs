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
using System.Web.Http;
using System.Web.Http.ModelBinding;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Entities;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// Solution Partner Category Controller
    /// </summary>
    public class SPCategoryController : BaseController
    {
        #region private members
        /// <summary>
        /// The category service
        /// </summary>
        private ISPCategoryService categoryService;

        /// <summary>
        /// The feature service
        /// </summary>
        private ISPFeatureService featureService;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion
        #region constructor


        /// <summary>
        /// Initializes a new instance of the <see cref="SPCategoryController"/> class.
        /// </summary>
        /// <param name="categoryService">The category service.</param>
        /// <param name="featureService">The feature service.</param>
        /// <param name="logger">The logger.</param>
        public SPCategoryController(ISPCategoryService categoryService, ISPFeatureService featureService, ILoggerExtension logger)
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
        /// <param name="categoryEntity">category Entity</param>
        /// <returns>HttpResponse Message</returns>
        [HttpPost]
        public HttpResponseMessage Create([ModelBinder(typeof(IocCustomCreationConverter))] ISPCategory categoryEntity)
        {
            {
                bool result = false;
                try
                {
                    result = categoryService.CreateCategory(categoryEntity);
                    if (!result)
                    {
                        return CreateHttpResponse<ISPCategory>(HttpStatusCode.OK, HttpCustomStatus.Failure, null, GetLocalisedString("msgCategoryDuplicate"));
                    }

                    return CreateHttpResponse<ISPCategory>(HttpStatusCode.Created, HttpCustomStatus.Success, null, GetLocalisedString("msgCategoryCreation"));
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return CreateHttpResponse<ISPCategory>(HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
                }
            }
        }

        /// <summary>
        /// Get all categories from DB for listing
        /// </summary>
        /// <returns>HttpResponse Message</returns>
        [HttpGet]
        public HttpResponseMessage GetAllCategories()
        {
            try
            {
                var item = Task.Run(async () =>
                {
                 return await categoryService.GetAllCategories();
                });
                if (item.Result == null)
                {
                    return CreateHttpResponse<IEnumerable<ISPCategory>>(HttpStatusCode.OK, HttpCustomStatus.Failure, null, GetLocalisedString("msgNoRecord"));
                }
                else
                {
                    var categories = CreateHttpResponse<IEnumerable<ISPCategory>>(HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, GetLocalisedString("msgSuccess"));
                    return categories;
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISPCategory>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Delete a particular category according to the id passed
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponse Message</returns>
        [HttpDelete]
        public HttpResponseMessage DeleteCategory(int id)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await categoryService.DeleteCategory(id);
                });
                if (item.Result == false)
                {
                    return CreateHttpResponse<IEnumerable<ISPCategory>>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgCategoryDeleteWarning"));
                }

                return CreateHttpResponse<IEnumerable<ISPCategory>>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgCategoryDeleteSuccess"));
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISPCategory>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Get a particular category according to the id passed
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponse Message</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetCategoryById(int id)
        {
            try
            {
                var result = await categoryService.GetCategoryById(id);
                if (result == null)
                {
                    return CreateHttpResponse<ISPCategory>(HttpStatusCode.NotFound, HttpCustomStatus.Failure, null, GetLocalisedString("msgNoRecord"));
                }

                var categories = CreateHttpResponse<ISPCategory>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgSuccess"));
                return categories;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<ISPCategory>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Update a category according to the id passed in the model
        /// </summary>
        /// <param name="categoryEntity">category Entity</param>
        /// <returns>HttpResponse Message</returns>
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCategory([ModelBinder(typeof(IocCustomCreationConverter))] ISPCategory categoryEntity)
        {
            try
            {
                var result = await categoryService.UpdateCategory(categoryEntity);
                if (!result)
                {
                    return CreateHttpResponse<ISPCategory>(HttpStatusCode.OK, HttpCustomStatus.Failure, null, GetLocalisedString("msgCategoryDuplicate"));
                }

                return CreateHttpResponse<ISPCategory>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgCategoryupdation"));
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<ISPCategory>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        #endregion
    }
}
