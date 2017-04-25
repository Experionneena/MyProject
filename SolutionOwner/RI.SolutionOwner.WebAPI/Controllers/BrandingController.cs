//-----------------------------------------------------------
// <copyright file="BrandingController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Framework.Core.Logging.Contracts;
    using RI.SolutionOwner.Business.Contracts;
    using RI.SolutionOwner.Data.Contracts;
    using RI.SolutionOwner.Mapper;
    using RI.SolutionOwner.WebAPI.Extensions;
    using RI.SolutionOwner.WebAPI.Models;

    /// <summary>
    /// This controller class has api methods for CRUD operations on Solution Owner Branding module.
    /// </summary>
    public class BrandingController : BaseController
    {
        /// <summary>
        /// branding business service variable
        /// </summary>
        private IBrandingService brandingSrv;

        /// <summary>
        /// logger interface variable
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandingController"/> class.
        /// </summary>
        /// <param name="brandService">brand business service</param>
        /// <param name="logger">logger extension</param>
        public BrandingController(IBrandingService brandService, ILoggerExtension logger)
        {
           this.brandingSrv = brandService;
            this.logger = logger;
        }

        /// <summary>
        /// Get branding details
        /// </summary>
        /// <returns>brand entity</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                ISOBranding brandEntity = (await brandingSrv.GetAll()).FirstOrDefault();
                if (brandEntity != null)
                {
                    var result = CreateHttpResponse<ISOBranding>(HttpStatusCode.OK, HttpCustomStatus.Success, brandEntity, "Success");
                    return result;
                }
                else
                {
                    return CreateHttpResponse<ISOBranding>(HttpStatusCode.NoContent, HttpCustomStatus.Success, null, "No Records Found");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOBranding>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, "Web Service Error: Please report this problem or try again later." + ex.Message);
            }
        }
      
        /// <summary>
        /// Create brand entity
        /// </summary>
        /// <param name="brandEntity">brand entity</param>
        /// <returns>created brand entity</returns>
        [HttpPost]
        public HttpResponseMessage Create([System.Web.Http.ModelBinding.ModelBinder(typeof(IocCustomCreationConverter))] ISOBranding brandEntity)
        {
            try
            {
                var result = brandingSrv.Create(brandEntity);
                if (result != null)
                {
                    return CreateHttpResponse<ISOBranding>(HttpStatusCode.Created, HttpCustomStatus.Success, result, "Branding creation succcessfully!");
                }
                else
                {
                    return CreateHttpResponse<ISOBranding>(HttpStatusCode.Accepted, HttpCustomStatus.Success, result, "Branding creation unsuccessful");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOBranding>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, "Web Service Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Updates brand entity
        /// </summary>
        /// <param name="brandEntity">brand entity</param>
        /// <returns>updated brand entity</returns>
        [HttpPut]
        public HttpResponseMessage Update([System.Web.Http.ModelBinding.ModelBinder(typeof(IocCustomCreationConverter))] ISOBranding brandEntity)
        {           
            try
            {
                var result = brandingSrv.Update(brandEntity);
               
                if (result != null)
                {
                   return CreateHttpResponse<ISOBranding>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "Branding updation successful");
                }
                else
                {
                   return CreateHttpResponse<ISOBranding>(HttpStatusCode.Accepted, HttpCustomStatus.Success, result, "Branding updation not successful");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOBranding>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, "Web Service Error: " + ex.Message);
            }
        }
    }
}
