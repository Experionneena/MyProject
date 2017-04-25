//---------------------------------------------------------------
// <copyright file="SPRoleController.cs" company="RechargeIndia">
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
using RI.SolutionOwner.WebAPI.Ingest.Models;
using RI.SolutionOwner.WebAPI.Ingest.Controllers;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// This controller class has methods for CRUD operations on Solution Owner Role resource.
    /// </summary>
    public class SPRoleController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The role service
        /// </summary>
        private ISPRoleService roleService;

        /// <summary>
        /// The feature service
        /// </summary>
        private ISPFeatureService featureService;

        /// <summary>
        /// The role permission service
        /// </summary>
        private ISPRoleFeatureService rolePermissionService = null;

        /// <summary>
        /// The service provider
        /// </summary>
        private IServiceProvider serviceProvider;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="roleService">The role service.</param>
        /// <param name="featureService">The feature service.</param>
        /// <param name="rolePermissionService">The role permission service.</param>
        /// <param name="logger">The logger.</param>
        public SPRoleController(
            IServiceProvider serviceProvider,
            ISPRoleService roleService,
            ISPFeatureService featureService,
            ISPRoleFeatureService rolePermissionService,
            ILoggerExtension logger)
        {
            this.serviceProvider = serviceProvider;
            this.roleService = roleService;
            this.featureService = featureService;
            this.rolePermissionService = rolePermissionService;
            this.logger = logger;
        }

        #endregion

        #region Public Membres / Actions

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("SPRole/GetRoles")]
        public async Task<HttpResponseMessage> GetRoles()
        {
            try
            {
                var collection = await roleService.GetAllRoles();
                return CreateHttpResponse<IEnumerable<ISPRole>>(HttpStatusCode.OK, HttpCustomStatus.Success, collection, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISPRole>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the new so role.
        /// </summary>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("SPRole/GetNewSPRole")]
        public HttpResponseMessage GetNewSPRole()
        {
            try
            {
                var role = (ISPRole)serviceProvider.GetService(typeof(ISPRole));
                return CreateHttpResponse<ISPRole>(HttpStatusCode.OK, HttpCustomStatus.Success, role, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the role by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("SPRole/GetRoleById/{id}")]
        public HttpResponseMessage GetRoleById(int id)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await roleService.GetById(id);
                });
                return CreateHttpResponse<ISPRole>(HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Creates the so role.
        /// </summary>
        /// <param name="roleEntity">The role entity.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPost]
        [Route("SPRole/CreateSPRole")]
        public HttpResponseMessage CreateSPRole([ModelBinder(typeof(IocCustomCreationConverter))] ISPRole roleEntity)
        {
            try
            {
                var permissions = roleEntity.SPRolePermissions;
                var creationResponse = roleService.CreateRole(roleEntity);
                if (creationResponse == null)
                {
                    return CreateHttpResponse<ISPRole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, creationResponse, GetLocalisedString("msgRoleDuplicate"));
                }

                foreach (var item in permissions)
                {
                    item.RoleId = roleEntity.Id;
                    rolePermissionService.CreateRolePermission(item);
                }

                return CreateHttpResponse<ISPRole>(HttpStatusCode.Created, HttpCustomStatus.Success, creationResponse, GetLocalisedString("msgRoleCreation"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Updates the so role.
        /// </summary>
        /// <param name="roleEntity">The role entity.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("SPRole/UpdateSPRole")]
        public async Task<HttpResponseMessage> UpdateSPRole([ModelBinder(typeof(IocCustomCreationConverter))] ISPRole roleEntity)
        {
            try
            {
                var permissionsEntity = roleEntity.SPRolePermissions;
                var updationResponse = await roleService.UpdateRole(roleEntity);
                if (updationResponse == false)
                {
                    return CreateHttpResponse<ISPRole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleDuplicate"));
                }

                foreach (var item in permissionsEntity)
                {
                    item.RoleId = roleEntity.Id;
                    await rolePermissionService.UpdatePermission(item);
                }

                return CreateHttpResponse<ISPRole>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleUpdation"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpDelete]
        [Route("SPRole/DeleteRole/{id}")]
        public async Task<HttpResponseMessage> DeleteRole(int id)
        {
            try
            {
                var deleted = await roleService.DeleteRole(id);
                if (!deleted)
                {
                    return CreateHttpResponse<ISPRole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleDeleteWarning"));
                }

                return CreateHttpResponse<ISPRole>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgDeleteSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Activates or deactivate role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("SPRole/ActivateDeactivateRole/{id}/{flag}")]
        public async Task<HttpResponseMessage> ActivateDeactivateRole([FromUri] int id, [FromUri] int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await roleService.ActivateRole(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, "Role is already Active.");
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "Role activated successfully.");
                    }
                }

                if (flag == 0)
                {
                    var result = await roleService.DeactivateRole(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, "Role is already Inactive.");
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "Role deactivated successfully.");
                    }
                }

                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Operation failed.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISORole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }
        #endregion
    }
}