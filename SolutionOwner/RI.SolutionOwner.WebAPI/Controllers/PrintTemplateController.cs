//-----------------------------------------------------------
// <copyright file="PrintTemplateController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// This controller class has api methods for CRUD operations on Solution Partner Print Template module.
    /// </summary>
    public class PrintTemplateController : BaseController
    {
        /// <summary>
        /// print template service variable
        /// </summary>
        private IPrintTemplateService printTemplateSrv;

        /// <summary>
        /// logger service
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintTemplateController"/> class.
        /// </summary>
        /// <param name="printTemplateSrv">print template service</param>
        /// <param name="logger">logger service</param>
        public PrintTemplateController(IPrintTemplateService printTemplateSrv, ILoggerExtension logger)
        {
            this.printTemplateSrv = printTemplateSrv;
            this.logger = logger;
        }

        /// <summary>
        /// Get all print templates
        /// </summary>
        /// <returns>list of print templates</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var result = await printTemplateSrv.GetAll();
                if (result != null)
                {
                    return CreateHttpResponse<IEnumerable<ISPPrintTemplate>>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "Success");
                }
                else
                {
                    return CreateHttpResponse<IEnumerable<ISPPrintTemplate>>(HttpStatusCode.NoContent, HttpCustomStatus.Success, result, "No Records Found");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISPPrintTemplate>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, "Web Service Error: Please report this problem or try again later." + ex.Message);
            }
        }

        /// <summary>
        /// Get specified print template details
        /// </summary>
        /// <param name="id">print template id</param>
        /// <returns>print template entity</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            try
            {
                var result = await printTemplateSrv.GetById(id);
                if (result != null)
                {
                    return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "Success");
                }
                else
                {
                    return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.NoContent, HttpCustomStatus.Success, null, "No Records Found");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, "Web Service Error: Please report this problem or try again later." + ex.Message);
            }
        }

        /// <summary>
        /// Create a print template
        /// </summary>
        /// <param name="printTemplate">print template entity</param>
        /// <returns>created print template</returns>
        [HttpPost]
        public HttpResponseMessage Create([System.Web.Http.ModelBinding.ModelBinder(typeof(IocCustomCreationConverter))] ISPPrintTemplate printTemplate)
        {
            try
            {
                var result = printTemplateSrv.Create(printTemplate);
              
                if (result != null)
                {
                    return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.Created, HttpCustomStatus.Success, result, "Template created successfully");
                }
                else 
                {
                    return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.Accepted, HttpCustomStatus.Success, result, "Name already exists, please try another name");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, "Web Service Error: Please report this problem or try again later." + ex.Message);
            }
        }

        /// <summary>
        /// Update template details or status change of print template
        /// </summary>
        /// <param name="printTemplate">print template to be updated</param>
        /// <returns>status of operation result</returns>
        [HttpPut]
        public HttpResponseMessage Update([System.Web.Http.ModelBinding.ModelBinder(typeof(IocCustomCreationConverter))] ISPPrintTemplate printTemplate)
        {
            try
            {
                var result = printTemplateSrv.Update(printTemplate);
                if (string.IsNullOrEmpty(printTemplate.Name))
                {
                    if (result)
                    {
                        return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.OK, HttpCustomStatus.Success, null, string.Format("Template {0} successfully", printTemplate.IsActive ? "activated" : "deactivated"));
                    }
                    else 
                    {
                        return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.NotModified, HttpCustomStatus.Success, null, string.Format("Template already {0}", printTemplate.IsActive ? "activated" : "deactivated"));
                    }
                }
                else
                {
                    if (result)
                    {
                        return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.OK, HttpCustomStatus.Success, null, "Template updated successfully");
                    }
                    else
                    {
                        return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, "Name already exists, please try another name");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, "Web Service Error: Please report this problem or try again later." + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the print template
        /// </summary>
        /// <param name="id">template id to be deleted</param>
        /// <returns>status of operation result</returns>
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var result = await printTemplateSrv.Delete(id);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.OK, HttpCustomStatus.Success, null, "Print template removed successfully");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, "Internal Server Error" + ex.Message);
            }
        }
    }
}