// ---------------------------------------------------------
// <copyright file="POSRegistrationController.cs" company="RechargeIndia">
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
    /// POS Registration Controller
    /// </summary>
    public class POSRegistrationController : BaseController
    {
        #region private members

        /// <summary>
        /// The pos registration service
        /// </summary>
        private IPOSRegistrationService posRegistrationService;

        /// <summary>
        /// The supplier service
        /// </summary>
        private ISupplierService supplierService;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="POSRegistrationController"/> class.
        /// </summary>
        /// <param name="posRegistrationService">The pos registration service.</param>
        /// <param name="logger">The logger.</param>
        public POSRegistrationController(IPOSRegistrationService posRegistrationService, ISupplierService supplierService, ILoggerExtension logger)
        {
            this.posRegistrationService = posRegistrationService;
            this.supplierService = supplierService;
            this.logger = logger;
        }
        #endregion

        #region Public Methods

        ///// <summary>
        ///// Gets all POS.
        ///// </summary>
        ///// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("POSRegistration/GetAllPOS")]
        public async Task<HttpResponseMessage> GetAllPOS()
        {
            try
            {
                var posList = await posRegistrationService.GetAllPOS();
                return CreateHttpResponse<IEnumerable<IPOS>>(HttpStatusCode.OK, HttpCustomStatus.Success, posList, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<IPOS>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the POS by identifier.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("POSRegistration/GetPOSById/{posId}")]
        public async Task<HttpResponseMessage> GetPOSById(int posId)
        {
            try
            {
                var pos = await posRegistrationService.GetPOSById(posId);
                return CreateHttpResponse<IPOS>(HttpStatusCode.OK, HttpCustomStatus.Success, pos, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IPOS>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Adds the POS.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPost]
        [Route("POSRegistration/CreatePOS")]
        public HttpResponseMessage CreatePOS([ModelBinder(typeof(IocCustomCreationConverter))]IPOS pos)
        {
            try
            {
                var status = posRegistrationService.CreatePOS(pos);
                if (!status)
                {
                    return CreateHttpResponse<IPOS>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSDuplicate"));
                }

                return CreateHttpResponse<IPOS>(HttpStatusCode.Created, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSCreated"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IPOS>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Updates the POS.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("POSRegistration/UpdatePOS")]
        public async Task<HttpResponseMessage> UpdatePOS([ModelBinder(typeof(IocCustomCreationConverter))]IPOS pos)
        {
            try
            {
                var status = await posRegistrationService.UpdatePOS(pos);
                if (!status)
                {
                    return CreateHttpResponse<IPOS>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSDuplicate"));
                }

                return CreateHttpResponse<IPOS>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSUpdated"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IPOS>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Deletes the POS.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpDelete]
        [Route("POSRegistration/DeletePOS/{posId}")]
        public async Task<HttpResponseMessage> DeletePOS(int posId)
        {
            try
            {
                var status = await posRegistrationService.DeletePOS(posId);
                return CreateHttpResponse<IPOS>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSDeleted"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IPOS>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Changes the POS status.
        /// </summary>
        /// <param name="posId">The parameter identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("POSRegistration/ActivateDeactivatePOS/{posId}/{flag}")]
        public async Task<HttpResponseMessage> ActivateDeactivatePOS([FromUri] int posId, [FromUri] int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await posRegistrationService.ActivatePOS(posId);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgPOSActivateFailure"));
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgPOSActivated"));
                    }
                }

                if (flag == 0)
                {
                    var result = await posRegistrationService.DeactivatePOS(posId);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgPOSDeactivateFailure"));
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgPOSDeactivated"));
                    }
                }

                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Operation failed.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }
        #endregion
    }

}
