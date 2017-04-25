// ---------------------------------------------------------
// <copyright file="SOUserController.cs" company="RechargeIndia">
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
    /// Class SOUserController
    /// </summary>
    public class SOUserController : BaseController
    {
        #region Private Members

        /// <summary>
        /// Private member _logger
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// Private member _ownerService
        /// </summary>
        private ISOUserService ownerUserService;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SOUserController"/> class.
        /// </summary>
        /// <param name="ownerService">The owner service.</param>
        /// <param name="logger">The logger.</param>
        public SOUserController(ISOUserService ownerUserService, ILoggerExtension logger)
        {
            this.logger = logger;
            this.ownerUserService = ownerUserService;
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="souser">Create a user</param>
        /// <returns>Http Response Message</returns>
        [HttpPost]
        [Route("SOUser/CreateOwnerUser")]
        public async Task<HttpResponseMessage> CreateOwnerUser([ModelBinder(typeof(IocCustomCreationConverter))] ISOUser souser)
        {
            try
            {
                var user = await ownerUserService.CreateOwnerUser(souser);

                if (user == null)
                {
                    return CreateHttpResponse<ISOUser>(HttpStatusCode.Created, HttpCustomStatus.Success, user, GetLocalisedString("msgUserCreation"));
                }
                else
                {
                    return CreateHttpResponse<ISOUser>(HttpStatusCode.OK, HttpCustomStatus.Failure, user, GetLocalisedString("msgUserDuplication"));
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
        [Route("SOUser/GetUser/{id}")]
        public async Task<HttpResponseMessage> GetUser(int id)
        {
            try
            {
                var user = await ownerUserService.GetUserById(id);

                if (user != null)
                {
                    return CreateHttpResponse<ISOUser>(HttpStatusCode.OK, HttpCustomStatus.Success, user, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<ISOUser>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, user, GetLocalisedString("msgWebServiceError"));
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
        [Route("SOUser/GetAllUsers")]
        public async Task<HttpResponseMessage> GetAllUsers()
        {
            try
            {
                var users = (await ownerUserService.GetAllUsers()).ToList();

                if (users.Count != 0)
                {
                    return CreateHttpResponse<IEnumerable<ISOUser>>(HttpStatusCode.OK, HttpCustomStatus.Success, users, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<IEnumerable<ISOUser>>(HttpStatusCode.NoContent, HttpCustomStatus.Failure, users, GetLocalisedString("msgWebServiceError"));
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
        [Route("SOUser/UpdateOwnerUser")]
        public async Task<HttpResponseMessage> UpdateOwnerUser([ModelBinder(typeof(IocCustomCreationConverter))] ISOUser souser)
        {
            try
            {
                var userUpdated = await ownerUserService.UpdateOwnerUser(souser);

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
        [Route("SOUser/DeleteUser/{id}")]
        public async Task<HttpResponseMessage> DeleteUser(int id)
        {
            try
            {
                var user = await ownerUserService.DeleteUser(id);

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
        [Route("SOUser/ActivateDeactivate/{id}/{flag}")]
        public async Task<HttpResponseMessage> ActivateDeactivate([FromUri] int id, [FromUri] int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await ownerUserService.ActivateUser(id);
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
                    var result = await ownerUserService.DeactivateUser(id);
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