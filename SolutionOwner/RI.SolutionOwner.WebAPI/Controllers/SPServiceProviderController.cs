//---------------------------------------------------------
// <copyright file="POSParameter.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// The Service Provider controller.
    /// </summary>
    public class SPServiceProviderController : BaseController
    {
        #region Private Methods

        private ISPProductGroupService productGroupService = null;

        #endregion

        #region Constructor
        public SPServiceProviderController(
            ISPProductGroupService productGroupService)
        {
            this.productGroupService = productGroupService;
        }
        #endregion

        #region Public Methods / APIs
        /// <summary>
        /// Gets the service providers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllServiceProviders()
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await productGroupService.GetServiceProviders();
                });

                return CreateHttpResponse<IEnumerable<ISPServiceProvider>>(
                    HttpStatusCode.OK,
                    HttpCustomStatus.Success,
                    item.Result,
                    "Success.");
            }
            catch (Exception)
            {
                return CreateHttpResponse<IEnumerable<ISPServiceProvider>>(
                    HttpStatusCode.ExpectationFailed, 
                    HttpCustomStatus.Failure, 
                    null,
                    "Web Service Error: Please report this problem or try again later.");
            }
        }
        #endregion
    }
}