//---------------------------------------------------------
// <copyright file="SOSolutionPartnerContactController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// The Solution partner Contact controller.
    /// </summary>
    public class SOSolutionPartnerContactController : BaseController
    {
        #region Private Members

        /// <summary>
        /// The SO Solution partner contact service.
        /// </summary>
        private ISOSolutionPartnerContactService soContactService = null;

        /// <summary>
        /// The logger.
        /// </summary>
        private ILoggerExtension logger = null;

        #endregion

        #region Construcor

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerContactController"/> class.
        /// </summary>
        /// <param name="soContactService">The so contact service.</param>
        public SOSolutionPartnerContactController(
            ILoggerExtension logger,
            ISOSolutionPartnerContactService soContactService)
        {
            this.logger = logger;
            this.soContactService = soContactService;
        }

        #endregion

        #region Public Methods / APIs

        /// <summary>
        /// Gets the solution partner contact by Solution partner identifier.
        /// </summary>
        /// <param name="SOSPId">The sosp identifier.</param>
        /// <param name="dummyId">The dummy identifier.</param>
        /// <returns>The Http response message.</returns>
        [HttpGet]
        public HttpResponseMessage GetSolutionPartnerContactBySPId(int SOSPId, int dummyId)
        {
            try
            {
                var collection = soContactService.GetContactsByPartnerId(SOSPId);
                if (null != collection)
                {
                    return CreateHttpResponse(
                            HttpStatusCode.OK,
                            HttpCustomStatus.Success,
                            collection,
                            ""
                        );
                }
                return CreateHttpResponse(
                            HttpStatusCode.Accepted,
                            HttpCustomStatus.Failure,
                            collection,
                            "No data found."
                        );
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOSolutionPartnerContact>(
                            HttpStatusCode.ExpectationFailed,
                            HttpCustomStatus.Failure,
                            null,
                            "Web Service Error: Please report this problem or try again later."
                        );
            }
        }

        /// <summary>
        /// Gets the solution partner contact by Solution partner identifier.
        /// </summary>
        /// <param name="SOSPId">The sosp identifier.</param>
        /// <param name="dummyId">The dummy identifier.</param>
        /// <returns>The Http response message.</returns>
        [HttpGet]
        public HttpResponseMessage GetSolutionPartnerContactById(int id)
        {
            try
            {
                var collection = soContactService.GetContactById(id);
                if (null != collection)
                {
                    return CreateHttpResponse(
                            HttpStatusCode.OK,
                            HttpCustomStatus.Success,
                            collection,
                            ""
                        );
                }
                return CreateHttpResponse(
                            HttpStatusCode.Accepted,
                            HttpCustomStatus.Failure,
                            collection,
                            "No data found."
                        );
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOSolutionPartnerContact>(
                            HttpStatusCode.ExpectationFailed,
                            HttpCustomStatus.Failure,
                            null,
                            "Web Service Error: Please report this problem or try again later."
                        );
            }
        }

        /// <summary>
        /// Creates the solution partner contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateSolutionPartnerContact([ModelBinder(typeof(IocCustomCreationConverter))] ISOSolutionPartnerContact contact)
        {
            try
            {
                var creationStatus = soContactService.CreateContact(contact);

                if (creationStatus)
                {
                    return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Created,
                        HttpCustomStatus.Success,
                        null,
                        "New contact created successfully.");
                }
                return CreateHttpResponse<ISPProductGroup>(
                        HttpStatusCode.Accepted,
                        HttpCustomStatus.Failure,
                        null,
                        "Something seems wrong. Please contact administrator.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOSolutionPartnerContact>(
                            HttpStatusCode.ExpectationFailed,
                            HttpCustomStatus.Failure,
                            null,
                            "Web Service Error: Please report this problem or try again later."
                        );
            }
        }

        /// <summary>
        /// Edits the solution partner contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage EditSolutionPartnerContact([ModelBinder(typeof(IocCustomCreationConverter))] ISOSolutionPartnerContact contact)
        {
            try
            {
                var editStatus = soContactService.ModifyContact(contact);

                if (editStatus)
                {
                    return CreateHttpResponse<ISPProductGroup>(
                            HttpStatusCode.OK,
                            HttpCustomStatus.Success,
                            null,
                            "Contact updated successfully.");
                }
                return CreateHttpResponse<ISPProductGroup>(
                    HttpStatusCode.Accepted,
                    HttpCustomStatus.Failure,
                    null,
                    "Something seems wrong. Please contact administrator.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<ISOSolutionPartnerContact>(
                            HttpStatusCode.ExpectationFailed,
                            HttpCustomStatus.Failure,
                            null,
                            "Web Service Error: Please report this problem or try again later."
                        );
            }
        }

        /// <summary>
        /// Deletes the solution partner contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteSolutionPartnerContact([FromUri] int id)
        {
            try
            {
                var deletionStatus = soContactService.DeleteContact(id);

                if (deletionStatus)
                {
                    return CreateHttpResponse<ISPProductGroup>(
                            HttpStatusCode.OK,
                            HttpCustomStatus.Success,
                            null,
                            "Contact deleted successfully.");
                }
                return CreateHttpResponse<ISPProductGroup>(
                            HttpStatusCode.OK,
                            HttpCustomStatus.Success,
                            null,
                            "Something seems wrong. Please Contact administrator.");
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

        #endregion
    }
}