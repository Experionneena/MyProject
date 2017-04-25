// ---------------------------------------------------------
// <copyright file="SPHierarchyController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
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
    /// This controller handles the request for CRUD operations on SPHierarchy
    /// </summary>
    public class SPHierarchyController : BaseController
    {
        #region Private Members

        /// <summary>
        /// private member posService
        /// </summary>
        private ISPHierarchyService hierarchyService;

        /// <summary>
        /// private member posService
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerHierarchyController"/> class.
        /// </summary>
        /// <param name="solutionPartnerService">The solution partner service.</param>
        /// <param name="logger">The logger.</param>
        public SPHierarchyController(ISPHierarchyService hierarchyService, ILoggerExtension logger)
        {
            this.hierarchyService = hierarchyService;
            this.logger = logger;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the Solution Partner hierarchy by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("SPHierarchy/GetSPHierarchyById/{id}")]
        public async Task<HttpResponseMessage> GetSPHierarchyById(int id)
        {
            try
            {
                var spHierarchy = await hierarchyService.GetSPHierarchyById(id);
                return CreateHttpResponse<ISPHierarchy>(HttpStatusCode.OK, HttpCustomStatus.Success, spHierarchy, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPHierarchy>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Adds the sp hierarchy.
        /// </summary>
        /// <param name="partnerHierarchy">The partner hierarchy.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPost]
        [Route("PartnerHierarchy/AddSPHierarchy")]
        public HttpResponseMessage AddSPHierarchy([ModelBinder(typeof(IocCustomCreationConverter))]ISPHierarchy partnerHierarchy)
        {
            try
            {
                var status = hierarchyService.AddSPHierarchy(partnerHierarchy);
                if (!status)
                {
                    return CreateHttpResponse<ISPHierarchy>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, null, GetLocalisedString("Operation failed."));
                }

                return CreateHttpResponse<ISPHierarchy>(HttpStatusCode.Created, HttpCustomStatus.Success, null, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPHierarchy>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Updates the sp hierarchy.
        /// </summary>
        /// <param name="partnerHierarchy">The partner hierarchy.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("PartnerHierarchy/UpdateSPHierarchy")]
        public async Task<HttpResponseMessage> UpdateSPHierarchy([ModelBinder(typeof(IocCustomCreationConverter))]ISPHierarchy partnerHierarchy)
        {
            try
            {
                var status = await hierarchyService.UpdateSPHierarchy(partnerHierarchy);
                if (!status)
                {
                    return CreateHttpResponse<ISPHierarchy>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, null, GetLocalisedString("Operation failed."));
                }

                return CreateHttpResponse<ISPHierarchy>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPHierarchy>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        #endregion
    }
}
