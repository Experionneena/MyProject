//---------------------------------------------------------------
// <copyright file="POSParameterCategoryController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// This controller handles the request for CRUD operations on POSParameterCategory
    /// </summary>
    public class POSParameterCategoryController : BaseController
    {
        #region Private Members
        /// <summary>
        /// private member posService
        /// </summary>
        private IPOSService posService;

        /// <summary>
        /// private member posService
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="POSParameterCategoryController"/> class.
        /// </summary>
        /// <param name="posService">The POS service.</param>
        /// <param name="logger">The logger.</param>
        public POSParameterCategoryController(IPOSService posService, ILoggerExtension logger)
        {
            this.posService = posService;
            this.logger = logger;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all POS parameter categories.
        /// </summary>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllPOSParameterCategories()
        {
            try
            {
                var posParamCategoryList = await posService.GetAllPOSParameterCategories();
                return CreateHttpResponse<IEnumerable<IPOSParameterCategory>>(HttpStatusCode.OK, HttpCustomStatus.Success, posParamCategoryList, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<IPOSParameterCategory>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }
        #endregion
    }
}
