// ---------------------------------------------------------
// <copyright file="SPPUserController.cs" company="RechargeIndia">
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
using System.Linq;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// Class SPPUserController
    /// </summary>
    public class SPPUserController : BaseController
    {
        #region Private Members

        /// <summary>
        /// Private member _logger
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// Private member _partnerService
        /// </summary>
        private ISPPUserService partnerUserService;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPPUserController"/> class.
        /// </summary>
        /// <param name="partnerService">The partner service.</param>
        /// <param name="logger">The logger.</param>
        public SPPUserController(ISPPUserService partnerUserService, ILoggerExtension logger)
        {
            this.logger = logger;
            this.partnerUserService = partnerUserService;
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="souser">Create a user</param>
        /// <returns>Http Response Message</returns>
        [HttpPost]
        [Route("SPPUser/CreatePartnerUser")]
        public async Task<HttpResponseMessage> CreatePartnerUser([ModelBinder(typeof(IocCustomCreationConverter))] ISPPUser souser)
        {
            try
            {
                var user = await partnerUserService.CreatePartnerUser(souser);

                if (user == null)
                {
                    return CreateHttpResponse<ISPPUser>(HttpStatusCode.Created, HttpCustomStatus.Success, user, GetLocalisedString("msgUserCreation"));

                }
                else
                {
                    return CreateHttpResponse<ISPPUser>(HttpStatusCode.OK, HttpCustomStatus.Failure, user, GetLocalisedString("msgUserDuplication"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id">Id to get user</param>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        [Route("SPPUser/GetUser/{id}")]
        public async Task<HttpResponseMessage> GetUser(int id)
        {
            try
            {
                var user = await partnerUserService.GetUserById(id);

                if (user != null)
                {
                    return CreateHttpResponse<ISPPUser>(HttpStatusCode.OK, HttpCustomStatus.Success, user, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<ISPPUser>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, user, GetLocalisedString("msgWebServiceError"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        [Route("SPPUser/GetAllUsers")]
        public async Task<HttpResponseMessage> GetAllUsers()
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await partnerUserService.GetAllUsers();
                });
                if (item.Result == null)
                {
                    return CreateHttpResponse<IEnumerable<ISPPUser>>(HttpStatusCode.NoContent, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
                }
                else
                {
                    return CreateHttpResponse<IEnumerable<ISPPUser>>(HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, GetLocalisedString("msgSuccess"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="souser">Update a user</param>
        /// <returns>Http Response Message</returns>
        [HttpPut]
        [Route("SPPUser/UpdatePartnerUser")]
        public async Task<HttpResponseMessage> UpdatePartnerUser([ModelBinder(typeof(IocCustomCreationConverter))] ISPPUser souser)
        {
            try
            {
                var userUpdated = await partnerUserService.UpdatePartnerUser(souser);

                if (userUpdated)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Success, userUpdated, GetLocalisedString("msgUserUpdation"));
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
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Http Response Message</returns>
        [HttpDelete]
        [Route("SPPUser/DeleteUser/{id}")]
        public async Task<HttpResponseMessage> DeleteUser(int id)
        {
            try
            {
                var user = await partnerUserService.DeleteUser(id);

                if (!user)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, user, GetLocalisedString("msgWebServiceError"));
                }
                else
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, user, GetLocalisedString("msgUserDeleteSuccess"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Activate or deactivate user
        /// </summary>
        /// <param name="id">Id to activate or deactivate</param>
        /// <param name="flag">flag to activate or deactivate</param>
        /// <returns>Http Response Message</returns>
        [HttpPut]
        [Route("SPPUser/ActivateDeactivate/{id}/{flag}")]
        public async Task<HttpResponseMessage> ActivateDeactivate([FromUri] int id, [FromUri] int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await partnerUserService.ActivateUser(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgAlreadyActivated"));
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "User activated successfully.");
                    }
                }

                if (flag == 0)
                {
                    var result = await partnerUserService.DeactivateUser(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgAlreadyDeactivated"));
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "User deactivated successfully.");
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