//---------------------------------------------------------------
// <copyright file="SORoleController.cs" company="RechargeIndia">
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

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// This controller class has methods for CRUD operations on Solution Owner Role resource.
    /// </summary>
    public class SORoleController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The role service
        /// </summary>
        private IRoleService roleService;

        /// <summary>
        /// The feature service
        /// </summary>
        private IFeatureService featureService;

        /// <summary>
        /// The role permission service
        /// </summary>
        private IRoleFeatureService rolePermissionService = null;

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
        /// Initializes a new instance of the <see cref="SORoleController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="roleService">The role service.</param>
        /// <param name="featureService">The feature service.</param>
        /// <param name="rolePermissionService">The role permission service.</param>
        /// <param name="logger">The logger.</param>
        public SORoleController(
            IServiceProvider serviceProvider,
            IRoleService roleService,
            IFeatureService featureService,
            IRoleFeatureService rolePermissionService,
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
        [Route("SORole/GetRoles")]
        public async Task<HttpResponseMessage> GetRoles()
        {
            try
            {
                var collection = await roleService.GetAllRoles();
                return CreateHttpResponse<IEnumerable<ISORole>>(HttpStatusCode.OK, HttpCustomStatus.Success, collection, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISORole>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the new so role.
        /// </summary>
        /// <returns>HttpResponseMessage object</returns>
        ////[HttpGet]
        //////public HttpResponseMessage GetNewSORole()
        //////{
        //////    try
        //////    {
        //////        var role = (ISORole)serviceProvider.GetService(typeof(ISORole));
        //////        return CreateHttpResponse<ISORole>(HttpStatusCode.OK, HttpCustomStatus.Success, role, GetLocalisedString("msgSuccess"));
        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        logger.Error(ex.Message);
        //////        return CreateHttpResponse<ISORole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
        //////    }
        //////}

        /// <summary>
        /// Gets the role by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("SORole/GetRoleById/{id}")]
        public HttpResponseMessage GetRoleById(int id)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await roleService.GetById(id);
                });
                return CreateHttpResponse<ISORole>(HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISORole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Creates the so role.
        /// </summary>
        /// <param name="roleEntity">The role entity.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPost]
        [Route("SORole/CreateSORole")]
        public HttpResponseMessage CreateSORole([ModelBinder(typeof(IocCustomCreationConverter))] ISORole roleEntity)
        {
            try
            {
                var permissions = roleEntity.SORolePermissions;
                var creationResponse = roleService.CreateRole(roleEntity);
                if (creationResponse == null)
                {
                    return CreateHttpResponse<ISORole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, creationResponse, GetLocalisedString("msgRoleDuplicate"));
                }

                foreach (var item in permissions)
                {
                    item.RoleId = roleEntity.Id;
                    rolePermissionService.CreateRolePermission(item);
                }

                return CreateHttpResponse<ISORole>(HttpStatusCode.Created, HttpCustomStatus.Success, creationResponse, GetLocalisedString("msgRoleCreation"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISORole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Updates the so role.
        /// </summary>
        /// <param name="roleEntity">The role entity.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("SORole/UpdateSORole")]
        public async Task<HttpResponseMessage> UpdateSORole([ModelBinder(typeof(IocCustomCreationConverter))] ISORole roleEntity)
        {
            try
            {
                var permissionsEntity = roleEntity.SORolePermissions;
                var updationResponse = await roleService.UpdateRole(roleEntity);
                if (!updationResponse)
                {
                    return CreateHttpResponse<ISORole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleDuplicate"));
                }

                foreach (var item in permissionsEntity)
                {
                    item.RoleId = roleEntity.Id;
                    await rolePermissionService.UpdatePermission(item);
                }

                return CreateHttpResponse<ISORole>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleUpdation"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISORole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpDelete]
        [Route("SORole/DeleteRole/{id}")]
        public async Task<HttpResponseMessage> DeleteRole(int id)
        {
            try
            {
                var deleted = await roleService.DeleteRole(id);
                if (!deleted)
                {
                    return CreateHttpResponse<ISORole>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgRoleDeleteWarning"));
                }

                return CreateHttpResponse<ISORole>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgDeleteSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISORole>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Activates or deactivate role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>HttpResponseMessage object</returns>
        [HttpPut]
        [Route("SORole/ActivateDeactivateRole/{id}/{flag}")]
        public async Task<HttpResponseMessage> ActivateDeactivateRole([FromUri] int id, [FromUri] int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await roleService.ActivateRole(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgAlreadyActivated"));
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
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, GetLocalisedString("msgAlreadyDeactivated"));
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