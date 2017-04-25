//---------------------------------------------------------
// <copyright file="SPProductGroupController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using RI.Framework.Core.Logging.Contracts;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// The Solution partner controller.
    /// </summary>
    public class SPProductGroupController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The product group service.
        /// </summary>
        private ISPProductGroupService productGroupService = null;

        /// <summary>
        /// The logger.
        /// </summary>
        private ILoggerExtension logger = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPProductGroupController"/> class.
        /// </summary>
        /// <param name="productGroupService">The product group service.</param>
        public SPProductGroupController(
            ILoggerExtension logger,
            ISPProductGroupService productGroupService
            )
        {
            this.logger = logger;
            this.productGroupService = productGroupService;
        }

        #endregion

        #region Public Methods / APIs

        /// <summary>
        /// Gets all product groups.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SPProductGroup/GetAllProductGroups")]
        public HttpResponseMessage GetAllProductGroups()
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await productGroupService.Get();
                });
                if (null != item.Result)
                {
                    return CreateHttpResponse(
                        HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, "Success");
                }
                return CreateHttpResponse(
                        HttpStatusCode.NotFound, HttpCustomStatus.Failure, item.Result, "No records found.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.NotFound, HttpCustomStatus.Failure, null,
                        "Web Service Error: Please report this problem or try again later.");
            }
        }

        /// <summary>
        /// Gets the product group by identifier.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SPProductGroup/GetProductGroupById/{productGroupId}")]
        public HttpResponseMessage GetProductGroupById([FromUri] int productGroupId)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await productGroupService.Get(productGroupId);
                });

                if (null != item.Result)
                {
                    return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, "Feature collected successfully.");
                }
                return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Accepted, HttpCustomStatus.Success, item.Result, "No Recorrd Find.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPProductGroup>(
                    HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, null,
                    "Web Service Error: Please report this problem or try again later.");
            }
        }

        /// <summary>
        /// Creates the product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SPProductGroup/CreateProductGroup")]
        public HttpResponseMessage CreateProductGroup([ModelBinder(typeof(IocCustomCreationConverter))] ISPProductGroup productGroup)
        {
            try
            {
                var creationStatus = productGroupService.Create(productGroup);

                if (creationStatus)
                {
                    return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Created, HttpCustomStatus.Success, null, "Product Group created successfully.");
                }
                return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Accepted, 
                        HttpCustomStatus.Failure, 
                        null, 
                        "Product group exists for the service provider.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPProductGroup>(
                    HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, null,
                    "Web Service Error: Please report this problem or try again later.");
            }
        }

        /// <summary>
        /// Modifies the product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns<>he product group./returns>
        [HttpPut]
        [Route("SPProductGroup/EditProductGroup")]
        public HttpResponseMessage EditProductGroup([ModelBinder(typeof(IocCustomCreationConverter))] ISPProductGroup productGroup)
        {
            try
            {
                var modificationStatus = productGroupService.Modify(productGroup);

                if (modificationStatus)
                {
                    return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Created, HttpCustomStatus.Success, null, "Product Group updated successfully.");
                }
                return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Accepted, HttpCustomStatus.Failure, null, "Product group exists for the service provider.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPProductGroup>(
                    HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, null,
                    "Web Service Error: Please report this problem or try again later.");
            }
        }

        /// <summary>
        /// Changes the active status.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <param name="statusFlag">The status flag.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("SPProductGroup/ChangeActiveStatus/{productGroupId}/{statusFlag}")]
        public HttpResponseMessage ChangeActiveStatus([FromUri] int productGroupId, [FromUri] int statusFlag)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await productGroupService.ChangeActiveStatus(productGroupId, statusFlag);
                });

                var responseMessage = 
                    (statusFlag == 1) ? "Product group activated successfully." 
                    : "Product group de-activated successfully.";
                if (item.Result)
                {
                    return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.OK, HttpCustomStatus.Success, null, responseMessage);
                }
                return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Accepted, HttpCustomStatus.Failure, null, "Something seems wrong.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPProductGroup>(
                    HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, null,
                    "Web Service Error: Please report this problem or try again later.");
            }
        }

        /// <summary>
        /// Deletes the product group.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("SPProductGroup/DeleteProductGroup/{productGroupId}")]
        public HttpResponseMessage DeleteProductGroup([FromUri] int productGroupId)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await productGroupService.DeleteProductGroup(productGroupId);
                });
                
                if (item.Result)
                {
                    return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.OK, HttpCustomStatus.Success, null, "Product group deleted successfully.");
                }
                return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Accepted, HttpCustomStatus.Failure, null, "Something seems wrong.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPProductGroup>(
                    HttpStatusCode.ExpectationFailed, 
                    HttpCustomStatus.Failure, 
                    null,
                    "Web Service Error: Please report this problem or try again later.");
            }
        }

        /// <summary>
        /// Gets the service providers.
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("api/productgroup/serviceprovider")]
        //public HttpResponseMessage GetServiceProviders()
        //{
        //    try
        //    {
        //        var item = Task.Run(async () =>
        //        {
        //            return await _productGroupService.GetServiceProviders();
        //        });
        //
        //        return CreateHttpResponse<IEnumerable<ISPServiceProvider>>(
        //            HttpStatusCode.OK, HttpCustomStatus.Success, item.Result, "Success.");
        //    }
        //    catch (Exception)
        //    {
        //        return CreateHttpResponse<IEnumerable<ISPServiceProvider>>(
        //            HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, null,
        //            "Web Service Error: Please report this problem or try again later.");
        //    }
        //}
        #endregion
    }
}