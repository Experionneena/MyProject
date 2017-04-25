//---------------------------------------------------------------
// <copyright file="POSController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

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
    /// This controller handles the request for CRUD operations on POSParameter
    /// </summary>
    public class POSController : BaseController
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
        /// Initializes a new instance of the <see cref="POSController"/> class.
        /// </summary>
        /// <param name="posService">The POS service.</param>
        /// <param name="logger">The logger.</param>
        public POSController(IPOSService posService, ILoggerExtension logger)
        {
            this.posService = posService;
            this.logger = logger;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all POS parameters.
        /// </summary>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllPOSParameters()
        {
            try
            {
                var posParameterList = await posService.GetAllPOSParameters();
                return CreateHttpResponse<IEnumerable<IPOSParameter>>(HttpStatusCode.OK, HttpCustomStatus.Success, posParameterList, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<IPOSParameter>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the POS parameter by identifier.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetPOSParameterById(int parameterId)
        {
            try
            {
                var posParameter = await posService.GetPOSParameterById(parameterId);
                return CreateHttpResponse<IPOSParameter>(HttpStatusCode.OK, HttpCustomStatus.Success, posParameter, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IPOSParameter>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Adds the POS parameter.
        /// </summary>
        /// <param name="posParameter">The POS parameter.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPost]
        public HttpResponseMessage AddPOSParameter([ModelBinder(typeof(IocCustomCreationConverter))]IPOSParameter posParameter)
        {
            try
            {
                var status = posService.AddPOSParameter(posParameter);
                if (!status)
                {
                    return CreateHttpResponse<IPOSParameter>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSParameterDuplicate"));
                }

                return CreateHttpResponse<IPOSParameter>(HttpStatusCode.Created, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSParameterCreated"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IPOSParameterCategory>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Updates the POS parameter.
        /// </summary>
        /// <param name="posParameter">The POS parameter.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePOSParameter([ModelBinder(typeof(IocCustomCreationConverter))]IPOSParameter posParameter)
        {
            try
            {
                var status = await posService.UpdatePOSParameter(posParameter);
                if (!status)
                {
                    return CreateHttpResponse<IPOSParameter>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSParameterDuplicate"));
                }

                return CreateHttpResponse<IPOSParameter>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSParameterUpdated"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IPOSParameterCategory>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Deletes the POS parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePOSParameter(int parameterId)
        {
            try
            {
                var status = await posService.DeletePOSParameter(parameterId);
                return CreateHttpResponse<IPOSParameter>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgPOSParameterDeleted"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IPOSParameterCategory>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Changes the POS parameter status.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        public async Task<HttpResponseMessage> ChangePOSParameterStatus([FromUri] int parameterId, int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await posService.ActivatePOSParameter(parameterId);
                if (!result)
                {
                    return CreateHttpResponse<IPOSParameterCategory>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
                }

                    if (result)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgPOSParameterActivated"));
                }
                }
                
                if (flag == 0)
                {
                    var result = await posService.DeactivatePOSParameter(parameterId);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, "POS parameter is already Inaactive.");
            }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "POS parameter deactivated successfully.");
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
