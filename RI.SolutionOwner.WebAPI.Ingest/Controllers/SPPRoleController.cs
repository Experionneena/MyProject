﻿//---------------------------------------------------------------
// <copyright file="SPPRoleController.cs" company="RechargeIndia">
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
    public class SPPRoleController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The role service
        /// </summary>
        private ISPPRoleService roleService;

        /// <summary>
        /// The feature service
        /// </summary>
        private ISPFeatureService featureService;

        /// <summary>
        /// The role permission service
        /// </summary>
        private ISPPRoleFeatureService rolePermissionService = null;

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
        /// Initializes a new instance of the <see cref="SPPRoleController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="roleService">The role service.</param>
        /// <param name="featureService">The feature service.</param>
        /// <param name="rolePermissionService">The role permission service.</param>
        /// <param name="logger">The logger.</param>
        public SPPRoleController(
            IServiceProvider serviceProvider,
            ISPPRoleService roleService,
            ISPFeatureService featureService,
            ISPPRoleFeatureService rolePermissionService,
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
        [Route("SPPRole/GetRoles")]
        public async Task<HttpResponseMessage> GetRoles()
        {
            try
            {
                var collection = await roleService.GetAllRoles();
                return CreateHttpResponse<IEnumerable<ISPPRole>>(HttpStatusCode.OK, HttpCustomStatus.Success, collection, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISPPRole>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the new so role.
        /// </summary>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("SPPRole/GetNewSPPRole")]
        public HttpResponseMessage GetNewSPPRole()
        {
            try
            {
                var role = (ISPPRole)serviceProvider.GetService(typeof(ISPPRole));
                return CreateHttpResponse<ISPPRole>(HttpStatusCode.OK, HttpCustomStatus.Success, role, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the role by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("SPPRole/GetRoleById/{id}")]
        public HttpResponseMessage GetRoleById(int id)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await roleService.GetById(id);
                });
                return CreateHttpResponse<ISPPRole>(HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Creates the so role.
        /// </summary>
        /// <param name="roleEntity">The role entity.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPost]
        [Route("SPPRole/CreateSPPRole")]
        public HttpResponseMessage CreateSPPRole([ModelBinder(typeof(IocCustomCreationConverter))] ISPPRole roleEntity)
        {
            try
            {
                var permissions = roleEntity.SPPRolePermissions;
                var creationResponse = roleService.CreateRole(roleEntity);
                if (creationResponse == null)
                {
                    return CreateHttpResponse<ISPPRole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, creationResponse, GetLocalisedString("msgRoleDuplicate"));
                }

                foreach (var item in permissions)
                {
                    item.RoleId = roleEntity.Id;
                    rolePermissionService.CreateRolePermission(item);
                }

                return CreateHttpResponse<ISPPRole>(HttpStatusCode.Created, HttpCustomStatus.Success, creationResponse, GetLocalisedString("msgRoleCreation"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Updates the so role.
        /// </summary>
        /// <param name="roleEntity">The role entity.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("SPPRole/UpdateSPPRole")]
        public async Task<HttpResponseMessage> UpdateSPPRole([ModelBinder(typeof(IocCustomCreationConverter))] ISPPRole roleEntity)
        {
            try
            {
                var permissionsEntity = roleEntity.SPPRolePermissions;
                var updationResponse = await roleService.UpdateRole(roleEntity);
                if (updationResponse == false)
                {
                    return CreateHttpResponse<ISPPRole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleDuplicate"));
                }

                foreach (var item in permissionsEntity)
                {
                    item.RoleId = roleEntity.Id;
                    await rolePermissionService.UpdatePermission(item);
                }

                return CreateHttpResponse<ISPPRole>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleUpdation"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpDelete]
        [Route("SPPRole/DeleteRole/{id}")]
        public async Task<HttpResponseMessage> DeleteRole(int id)
        {
            try
            {
                var deleted = await roleService.DeleteRole(id);
                if (!deleted)
                {
                    return CreateHttpResponse<ISPPRole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleDeleteWarning"));
                }

                return CreateHttpResponse<ISPPRole>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgDeleteSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPRole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Activates or deactivate role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("SPPRole/ActivateDeactivateRole/{id}/{flag}")]
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