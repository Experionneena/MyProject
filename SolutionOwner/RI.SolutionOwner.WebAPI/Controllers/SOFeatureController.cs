//---------------------------------------------------------
// <copyright file="SOFeatureController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

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
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// The Solution owner Feature controller.
    /// </summary>
    public class SOFeatureController : BaseController
    {
        #region Private Membres

        /// <summary>
        /// The feature service.
        /// </summary>
        private IFeatureService featureService;

        /// <summary>
        /// The logger.
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SOFeatureController" /> class.
        /// </summary>
        /// <param name="featureService">The feature service.</param>
        /// <param name="logger">The logger.</param>
        public SOFeatureController(IFeatureService featureService, ILoggerExtension logger)
        {
            this.featureService = featureService;
            this.logger = logger;
        }

        #endregion

        #region Public Methods / APIs

        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>HttpResponseMessage object</returns>
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
                return CreateHttpResponse<IEnumerable<ISOFeature>>(
                    HttpStatusCode.OK, 
                    HttpCustomStatus.Success, 
                    features, 
                    GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOFeature>(
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
        /// <returns>HttpResponseMessage object</returns>
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
                    return CreateHttpResponse<ISOFeature>(
                        HttpStatusCode.OK, 
                        HttpCustomStatus.Success, 
                        item.Result, 
                        GetLocalisedString("msgSuccess"));
                }

                return CreateHttpResponse<ISOFeature>(
                    HttpStatusCode.Accepted, 
                    HttpCustomStatus.Failure, 
                    null, 
                    GetLocalisedString("msgNoRecord"));
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<ISOFeature>(
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
        /// <returns>HttpResponseMessage object</returns>
        [HttpPost]
        public HttpResponseMessage CreateFeature([ModelBinder(typeof(IocCustomCreationConverter))] ISOFeature featureEntity)
        {
            try
            {
                var result = featureService.CreateFeature(featureEntity);

                if (result)
                {
                    return CreateHttpResponse<ISOFeature>(
                        HttpStatusCode.Created, 
                        HttpCustomStatus.Success, 
                        null, 
                        GetLocalisedString("msgFeatureCreation"));
                }

                return CreateHttpResponse<ISOFeature>(
                    HttpStatusCode.Accepted, 
                    HttpCustomStatus.Failure, 
                    null, 
                    GetLocalisedString("msgFeatureDuplicate"));
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<ISOFeature>(HttpStatusCode.ExpectationFailed, 
                    HttpCustomStatus.Failure, 
                    null,
                    GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Edits the feature.
        /// </summary>
        /// <param name="featureEntity">The feature entity.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        public HttpResponseMessage EditFeature([ModelBinder(typeof(IocCustomCreationConverter))]ISOFeature featureEntity)
        {
            try
            {
                var result = featureService.UpdateFeature(featureEntity);
                if (result)
                {
                    return CreateHttpResponse<ISOFeature>(
                        HttpStatusCode.OK, 
                        HttpCustomStatus.Success, 
                        null, 
                        GetLocalisedString("msgFeatureUpdation"));
                }

                return CreateHttpResponse<ISOFeature>(
                    HttpStatusCode.Accepted, 
                    HttpCustomStatus.Failure, 
                    null, 
                    GetLocalisedString("msgFeatureDuplicate"));
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                return CreateHttpResponse<ISOFeature>(
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
        /// <returns>HttpResponseMessage object</returns>
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
                this.logger.Error(ex.Message);
                return CreateHttpResponse<ISOFeature>(
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
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> ActivateDeactivateFeature([FromUri] int id, [FromUri] int flag)
        {
            var result = await featureService.ActivateDeactivateFeature(id, flag);
            if (result)
            {
                if (flag == 1)
                {
                    return CreateHttpResponse<bool>(
                        HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgFeatureActivate"));
                }
                else
                {
                    return CreateHttpResponse<bool>(
                        HttpStatusCode.OK, 
                        HttpCustomStatus.Success,
                        result, 
                        GetLocalisedString("msgFeatureDeActivate"));
                }
            }
            else
            {
                return CreateHttpResponse<bool>(
                    HttpStatusCode.BadRequest, 
                    HttpCustomStatus.Failure,
                    result,
                    GetLocalisedString("msgWebServiceError"));
            }
        }

        #endregion
    }
}