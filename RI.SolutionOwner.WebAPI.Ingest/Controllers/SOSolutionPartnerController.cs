using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Security;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// Class SO Solution Partner Controller
    /// </summary>
    public class SOSolutionPartnerController : BaseController
    {
        #region Private Members
        /// <summary>
        /// Private member _logger
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// The solution partner service
        /// </summary>
        private ISOSolutionPartnerService solutionPartnerService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="solutionPartnerService">The solution partner service.</param>
        public SOSolutionPartnerController(ILoggerExtension logger, ISOSolutionPartnerService solutionPartnerService)
        {
            this.logger = logger;
            this.solutionPartnerService = solutionPartnerService;
        }
        #endregion

        #region public Functions
        /// <summary>
        /// Creates the solution partner.
        /// </summary>
        /// <param name="solutionPartner">The solution partner.</param>
        /// <returns>Http Response Message</returns>
        [HttpPost]
        [Route("SOSolutionPartner/CreateSolutionPartner")]
        public async Task<HttpResponseMessage> CreateSolutionPartner([ModelBinder(typeof(IocCustomCreationConverter))] ISOSolutionPartner solutionPartner)
        {
            try
            {
                var solutionpartner = await solutionPartnerService.CreateSolutionPartner(solutionPartner);
                if (solutionpartner == null)
                {
                    return CreateHttpResponse<ISOSolutionPartner>(HttpStatusCode.Created, HttpCustomStatus.Success, solutionpartner, GetLocalisedString("msgSolutionPartnerCreation"));
                }
                else
                {
                    return CreateHttpResponse<ISOSolutionPartner>(HttpStatusCode.OK, HttpCustomStatus.Failure, solutionpartner, GetLocalisedString("msgUserDuplication"));
                }
            }

            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the solutionpartner.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        [Route("SOSolutionPartner/GetSolutionpartner/{id}")]
        public async Task<HttpResponseMessage> GetSolutionpartner(int id)
        {
            try
            {
                var solutionPartner = await solutionPartnerService.GetSolutionPartnerById(id);
                if (solutionPartner != null)
                {
                    return CreateHttpResponse<ISOSolutionPartner>(HttpStatusCode.OK, HttpCustomStatus.Success, solutionPartner, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<ISOSolutionPartner>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, solutionPartner, GetLocalisedString("msgWebServiceError"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets all solution partner.
        /// </summary>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        [Route("SOSolutionPartner/GetAllSolutionPartner")]
        public async Task<HttpResponseMessage> GetAllSolutionPartner()
        {
            try
            {
                var solutionPartnerList = (await solutionPartnerService.GetAllSolutionPartners()).ToList();
                if (solutionPartnerList.Count != 0)
                {
                    return CreateHttpResponse<IEnumerable<ISOSolutionPartner>>(HttpStatusCode.OK, HttpCustomStatus.Success, solutionPartnerList, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<IEnumerable<ISOSolutionPartner>>(HttpStatusCode.NoContent, HttpCustomStatus.Failure, solutionPartnerList, GetLocalisedString("msgWebServiceError"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Updates the solution partner.
        /// </summary>
        /// <param name="solutionPartner">The solution partner.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("SOSolutionPartner/UpdateSolutionPartner")]
        public async Task<HttpResponseMessage> UpdateSolutionPartner([ModelBinder(typeof(IocCustomCreationConverter))] ISOSolutionPartner solutionPartner)
        {
            try
            {
                var userUpdated = await solutionPartnerService.UpdateSolutionPartner(solutionPartner);
                if (userUpdated)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Success, userUpdated, GetLocalisedString("msgSolutionPartnerUpdation"));
                }
                else
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Failure, userUpdated, GetLocalisedString("msgUserDuplication"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Deletes the solution partner.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("SOSolutionPartner/DeleteSolutionPartner")]
        public async Task<HttpResponseMessage> DeleteSolutionPartner(int id)
        {
            try
            {
                var result = await solutionPartnerService.DeleteSolutionPartner(id);
                if (!result)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, result, GetLocalisedString("msgWebServiceError"));
                }
                else
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgSolutionPartnerDeleteSuccess"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Activates the deactivate.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>Http Response Message</returns>
        [HttpPut]
        [Route("SOSolutionPartner/ActivateDeactivate")]
        public async Task<HttpResponseMessage> ActivateDeactivate([FromUri] int id, [FromUri] int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await solutionPartnerService.ActivateSolutionPartner(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgAlreadyActivated"));
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgSolutionPartnerActivate"));
                    }
                }

                if (flag == 0)
                {
                    var result = await solutionPartnerService.DeactivateSolutionPartner(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgAlreadyDeactivated"));
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgSolutionPartnerDeactivate"));
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

        /// <summary>
        /// Generates the password.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SOSolutionPartner/GeneratePassword")]
        public HttpResponseMessage GeneratePassword()
        {
            try
            {
                var password= Membership.GeneratePassword(8, 2);
                return CreateHttpResponse<string>(HttpStatusCode.OK, HttpCustomStatus.Success, password, GetLocalisedString("msgSuccess"));
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
