// ---------------------------------------------------------
// <copyright file="SPHierarchyController.cs" company="RechargeIndia">
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
using RI.SolutionOwner.WebAPI.Ingest.Controllers;
using RI.SolutionOwner.WebAPI.Ingest.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// The Solution owner Feature controller.
    /// </summary>
    public class HierarchyController : BaseController
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
        /// Initializes a new instance of the <see cref="SPHierarchyController"/> class.
        /// </summary>
        /// <param name="featureService">The feature service.</param>
        /// <param name="logger">The logger.</param>
        public HierarchyController(
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
        /// <param name="id">The hierarchy identifier.</param>
        /// <returns>
        /// Http Response Message
        /// </returns>
        [HttpGet]
        [Route("Hierarchy/GetFeatureByHierarchy/{id}")]
        public HttpResponseMessage GetFeatureByHierarchy([FromUri] int id)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await featureService.GetFeatureByHierarchy(id);
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
        /// Gets the hierarchy.
        /// </summary>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        [Route("Hierarchy/GetHierarchy")]
        public HttpResponseMessage GetHierarchy()
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await featureService.GetHierarchy();
                });
                var hierarchy = item;
                return CreateHttpResponse<IEnumerable<IHierarchy>>(
                HttpStatusCode.OK,
                HttpCustomStatus.Success,
                hierarchy.Result,
                GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IHierarchy>(
                    HttpStatusCode.ExpectationFailed,
                    HttpCustomStatus.Failure,
                    null,
                   GetLocalisedString("msgWebServiceError"));
            }
        }
        #endregion
    }
}
