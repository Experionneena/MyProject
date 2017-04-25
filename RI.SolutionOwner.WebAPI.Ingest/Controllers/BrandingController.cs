//-----------------------------------------------------------
// <copyright file="BrandingController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using RI.Framework.Core.Logging.Contracts;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// This controller class has api methods for CRUD operations on Solution Owner Branding module.
    /// </summary>
    public class BrandingController : BaseController
    {
        #region Private members
        /// <summary>
        /// branding business service variable
        /// </summary>
        private IBrandingService brandingSrv;

        /// <summary>
        /// logger interface variable
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region Constructor
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
        #endregion

        #region Methods
        /// <summary>
        /// Get branding details
        /// </summary>
        /// <returns>brand entity</returns>
        [HttpGet]
        [Route("Branding/GetAll")]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var brandEntity = (await brandingSrv.GetAll()).FirstOrDefault();
                if (brandEntity != null)
                {
                    var result = CreateHttpResponse<ISOBranding>(HttpStatusCode.OK, HttpCustomStatus.Success, brandEntity, GetLocalisedString("msgBrandingSuccess"));
                    return result;
                }
                else
                {
                    return CreateHttpResponse<ISOBranding>(HttpStatusCode.NoContent, HttpCustomStatus.Success, null, GetLocalisedString("msgNoRecord"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOBranding>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError") + ex.Message);
            }
        }
      
        /// <summary>
        /// Create brand entity
        /// </summary>
        /// <param name="brandEntity">brand entity</param>
        /// <returns>created brand entity</returns>
        [HttpPost]
        [Route("Branding/Create")]
        public HttpResponseMessage Create([System.Web.Http.ModelBinding.ModelBinder(typeof(IocCustomCreationConverter))] ISOBranding brandEntity)
        {
            try
            {
                var result = brandingSrv.Create(brandEntity);
                if (result != null)
                {
                    return CreateHttpResponse<ISOBranding>(HttpStatusCode.Created, HttpCustomStatus.Success, result, GetLocalisedString("msgBrandingSuccess"));
                }
                else
                {
                    return CreateHttpResponse<ISOBranding>(HttpStatusCode.Accepted, HttpCustomStatus.Success, result, GetLocalisedString("msgWebServiceError"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOBranding>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError") + ex.Message);
            }
        }

        /// <summary>
        /// Updates brand entity
        /// </summary>
        /// <param name="brandEntity">brand entity</param>
        /// <returns>updated brand entity</returns>
        [HttpPut]
        [Route("Branding/Update")]
        public HttpResponseMessage Update([System.Web.Http.ModelBinding.ModelBinder(typeof(IocCustomCreationConverter))] ISOBranding brandEntity)
        {           
            try
            {
                var result = brandingSrv.Update(brandEntity);
               
                if (result != null)
                {
                   return CreateHttpResponse<ISOBranding>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgBrandingSuccess"));
                }
                else
                {
                   return CreateHttpResponse<ISOBranding>(HttpStatusCode.Accepted, HttpCustomStatus.Success, result, GetLocalisedString("msgWebServiceError"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOBranding>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError") + ex.Message);
            }
        }
        #endregion
    }
}
