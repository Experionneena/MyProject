// ---------------------------------------------------------
// <copyright file="SPFeatureController.cs" company="RechargeIndia">
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
using RI.SolutionOwner.WebAPI.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// The Solution owner Feature controller.
    /// </summary>
    public class SPFeatureController : BaseController
    {
        #region Private Membres

        /// <summary>
        /// The feature service.
        /// </summary>
        private ISPFeatureService featureService;

        /// <summary>
        /// The logger.
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPFeatureController"/> class.
        /// </summary>
        /// <param name="featureService">The feature service.</param>
        /// <param name="logger">The logger.</param>
        public SPFeatureController(
            ISPFeatureService featureService,
            ILoggerExtension logger)
        {
            this.featureService = featureService;
            this.logger = logger;
        }

        #endregion

        #region Public Methods / APIs     
        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        public HttpResponseMessage GetAllFeatures()
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await featureService.GetAllFeatures();
                });
                var features = item.Result;
                return CreateHttpResponse<IEnumerable<ISPFeature>>(
                    HttpStatusCode.OK, HttpCustomStatus.Success, features, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPFeature>(
                    HttpStatusCode.ExpectationFailed,
                    HttpCustomStatus.Failure,
                    null,
                     GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        public HttpResponseMessage GetFeatureById([FromUri] int id)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await featureService.GetFeatureById(id);
                });
                if (null != item.Result)
                {
                    return CreateHttpResponse<ISPFeature>(
                        HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, GetLocalisedString("msgSuccess"));
                }

                return CreateHttpResponse<ISPFeature>(
                    HttpStatusCode.NotFound, HttpCustomStatus.Failure, null, GetLocalisedString("msgNoRecord"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPFeature>(
                    HttpStatusCode.ExpectationFailed,
                    HttpCustomStatus.Failure,
                    null,
                    GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Creates the feature.
        /// </summary>
        /// <param name="featureEntity">The feature entity.</param>
        /// <returns>Http Response Message</returns>
        [HttpPost]
        public HttpResponseMessage CreateFeature([ModelBinder(typeof(IocCustomCreationConverter))] ISPFeature featureEntity)
        {
            try
            {
                var isSuccess = featureService.CreateFeature(featureEntity);

                if (isSuccess)
                {
                    return CreateHttpResponse<ISPFeature>(
                        HttpStatusCode.Created, HttpCustomStatus.Success, null, GetLocalisedString("msgFeatureCreation"));
                }

                return CreateHttpResponse<ISPFeature>(
                    HttpStatusCode.Accepted, HttpCustomStatus.Failure, null, GetLocalisedString("msgFeatureDuplicate"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPFeature>(
                    HttpStatusCode.ExpectationFailed,
                    HttpCustomStatus.Failure,
                    null,
                   GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Edits the feature.
        /// </summary>
        /// <param name="featureEntity">The feature entity.</param>
        /// <returns>Http Response Message</returns>
        [HttpPut]
        public HttpResponseMessage EditFeature([ModelBinder(typeof(IocCustomCreationConverter))]ISPFeature featureEntity)
        {
            try
            {
                var isSuccess = featureService.UpdateFeature(featureEntity);
                if (isSuccess)
                {
                    return CreateHttpResponse<ISPFeature>(
                        HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgFeatureUpdation"));
                }

                return CreateHttpResponse<ISPFeature>(
                    HttpStatusCode.Accepted, HttpCustomStatus.Failure, null, GetLocalisedString("msgFeatureDuplicate"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPFeature>(
                    HttpStatusCode.ExpectationFailed,
                    HttpCustomStatus.Failure,
                    null,
                   GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Deletes the feature.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Http Response Message</returns>
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteFeature(int id)
        {
            try
            {
                var item = await featureService.DeleteFeature(id);
                if (item)
                {
                    return CreateHttpResponse<bool>(
                        HttpStatusCode.OK, HttpCustomStatus.Success, item, GetLocalisedString("msgFeatureDeletion"));
                }

                return CreateHttpResponse<bool>(
                    HttpStatusCode.Accepted,
                    HttpCustomStatus.Failure,
                    item,
                     GetLocalisedString("msgFeatureDeleteWarning"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPFeature>(
                    HttpStatusCode.ExpectationFailed,
                    HttpCustomStatus.Failure,
                    null,
                     GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Activates the deactivate feature.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>Http Response Message</returns>
        [HttpPut]
        public async Task<HttpResponseMessage> ActivateDeactivateFeature([FromUri] int id, [FromUri] int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await featureService.ActivateFeature(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgFeatureActivateFailure"));
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgFeatureActivate"));
                    }
                }

                if (flag == 0)
                {
                    var result = await featureService.DeactivateFeature(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgFeatureDeactivateFailure"));
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgFeatureDeActivate"));
                    }
                }

                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Operation failed.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPFeature>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        #endregion
    }
}