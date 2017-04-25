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
using RI.SolutionOwner.WebAPI.Ingest.Models;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// This controller class has api methods for CRUD operations on Solution Partner Print Template module.
    /// </summary>
    public class PrintTemplateController : BaseController
    {
        #region Private members
        /// <summary>
        /// print template service variable
        /// </summary>
        private IPrintTemplateService printTemplateSrv;

        /// <summary>
        /// logger service
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region Constructor
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
        #endregion

        #region Methods
        /// <summary>
        /// Get all print templates
        /// </summary>
        /// <returns>list of print templates</returns>
        [HttpGet]
        [Route("PrintTemplate/GetAll")]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var result = await printTemplateSrv.GetAll();
                if (result != null)
                {
                    return CreateHttpResponse<IEnumerable<ISPPrintTemplate>>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<IEnumerable<ISPPrintTemplate>>(HttpStatusCode.NoContent, HttpCustomStatus.Success, result, GetLocalisedString("msgNoRecord"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISPPrintTemplate>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError") + ex.Message);
            }
        }

        /// <summary>
        /// Get specified print template details
        /// </summary>
        /// <param name="id">print template id</param>
        /// <returns>print template entity</returns>
        [HttpGet]
        [Route("PrintTemplate/GetById/{id}")]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            try
            {
                var result = await printTemplateSrv.GetById(id);
                if (result != null)
                {
                    return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.OK, HttpCustomStatus.Success, result, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.NoContent, HttpCustomStatus.Success, null, GetLocalisedString("msgNoRecord"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError") + ex.Message);
            }
        }

        /// <summary>
        /// Create a print template
        /// </summary>
        /// <param name="printTemplate">print template entity</param>
        /// <returns>created print template</returns>
        [HttpPost]
        [Route("PrintTemplate/Create")]
        public HttpResponseMessage Create([System.Web.Http.ModelBinding.ModelBinder(typeof(IocCustomCreationConverter))] ISPPrintTemplate printTemplate)
        {
            try
            {
                var result = printTemplateSrv.Create(printTemplate);
              
                if (result != null)
                {
                    return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.Created, HttpCustomStatus.Success, result, GetLocalisedString("msgPrintTemplateCreation"));
                }
                else 
                {
                    return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.Accepted, HttpCustomStatus.Success, result, GetLocalisedString("msgPrintTemplateDuplicate"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError") + ex.Message);
            }
        }

        /// <summary>
        /// Update template details or status change of print template
        /// </summary>
        /// <param name="printTemplate">print template to be updated</param>
        /// <returns>status of operation result</returns>
        [HttpPut]
        [Route("PrintTemplate/Update")]
        public HttpResponseMessage Update([System.Web.Http.ModelBinding.ModelBinder(typeof(IocCustomCreationConverter))] ISPPrintTemplate printTemplate)
        {
            try
            {
                var result = printTemplateSrv.Update(printTemplate);
                if (string.IsNullOrEmpty(printTemplate.Name))
                {
                    if (result)
                    {
                        return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.OK, HttpCustomStatus.Success, null, printTemplate.IsActive? GetLocalisedString("msgPrintTemplateActivate") : GetLocalisedString("msgPrintTemplateDeactivate"));
                    }
                    else 
                    {
                        return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.NotModified, HttpCustomStatus.Success, null, printTemplate.IsActive ? GetLocalisedString("msgAlreadyActivated") : GetLocalisedString("msgAlreadyDeactivated"));
                    }
                }
                else
                {
                    if (result)
                    {
                        return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgPrintTemplateUpdate"));
                    }
                    else
                    {
                        return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.Accepted, HttpCustomStatus.Success, null, GetLocalisedString("msgPrintTemplateDuplicate"));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError") + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the print template
        /// </summary>
        /// <param name="id">template id to be deleted</param>
        /// <returns>status of operation result</returns>
        [HttpDelete]
        [Route("PrintTemplate/Delete/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var result = await printTemplateSrv.Delete(id);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.OK, HttpCustomStatus.Success, null, GetLocalisedString("msgPrintTemplateDeleteSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISPPrintTemplate>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError") + ex.Message);
            }
        }
        #endregion
    }
}