//----------------------------------------------------------
// <copyright file="SPRoleHierarchyController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Ingest.Controllers;
using RI.SolutionOwner.WebAPI.Ingest.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// This controller class has methods for CRUD operations on Solution Partner Role Hierarchy resource.
    /// </summary>
    public class SPRoleHierarchyController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The role service
        /// </summary>
        private ISPRoleService roleService;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleHierarchyController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="roleService">The role service.</param>
        /// <param name="featureService">The feature service.</param>
        /// <param name="rolePermissionService">The role permission service.</param>
        /// <param name="logger">The logger.</param>
        public SPRoleHierarchyController(
            IServiceProvider serviceProvider,
            ISPRoleService roleService,
            ISPFeatureService featureService,
            ISPRoleFeatureService rolePermissionService,
            ILoggerExtension logger)
        {
            this.roleService = roleService;
            this.logger = logger;
        }

        #endregion

        #region Public Membres / Actions

        /// <summary>
        /// Gets the role by hierarchy.
        /// </summary>
        /// <param name="id">The hierarchy identifier.</param>
        /// <returns>HttpResponseMessage object.</returns>
        [HttpGet]
        [Route("SPRoleHierarchy/GetRoleByHierarchy/{hierarchyId}")]
        public HttpResponseMessage GetRoleByHierarchy([FromUri] int hierarchyId)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await roleService.GetRoleByHierarchy(hierarchyId);
                });
                var roles = item.Result;
                return CreateHttpResponse<IEnumerable<ISPRole>>(
                    HttpStatusCode.OK, HttpCustomStatus.Success, roles, "Success.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPRole>(HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, null, "Web Service Error: Please report this problem or try again later.");
            }
        }

        #endregion
    }
}