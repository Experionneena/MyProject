// ---------------------------------------------------------
// <copyright file="SPCurrencyRateController.cs" company="RechargeIndia">
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
using System.Web.Http.ModelBinding;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// Class SPCurrencyRateController
    /// </summary>
    public class SPCurrencyRateController : BaseController
    {
        #region Private Members
        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// The sp currency rate service
        /// </summary>
        private ISPCurrencyRateService currencyRateService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyRateController"/> class.
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="currencyRateService">The sp currency service</param>
        public SPCurrencyRateController(ILoggerExtension logger, ISPCurrencyRateService currencyRateService)
        {
            this.logger = logger;
            this.currencyRateService = currencyRateService;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Creates the currency description.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>Http Response Message</returns>
        [HttpPost]
        public HttpResponseMessage CreateCurrencyDescription([ModelBinder(typeof(IocCustomCreationConverter))] ISPCurrencyRate currency)
        {
            try
            {
                var currencyCreated = currencyRateService.CreateCurrency(currency);

                if (currencyCreated == null)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, false, "Operation failed.");
                }
                else
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.Created, HttpCustomStatus.Success, true, "Currency created successfully.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Internal server error.");
            }
        }

        /// <summary>
        /// Gets all currency rate.
        /// </summary>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllCurrencyRate()
        {
            try
            {
                var currencyList = (await currencyRateService.GetAllCurrencyRate()).ToList();
                if (currencyList.Count == 0)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.NoContent, HttpCustomStatus.Success, false, null);
                }
                else
                {
                    return CreateHttpResponse<List<ISPCurrencyRate>>(HttpStatusCode.OK, HttpCustomStatus.Success, currencyList, null);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Internal server error");
            }
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetCurrency(int id)
        {
            try
            {
                var currency = await currencyRateService.GetCurrencyById(id);

                if (currency == null)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.NotFound, HttpCustomStatus.Failure, false, null);
                }
                else
                {
                    return CreateHttpResponse<ISPCurrencyRate>(HttpStatusCode.OK, HttpCustomStatus.Success, currency, null);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Internal server error");
            }
        }

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>Http Response Message</returns>
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCurrency([ModelBinder(typeof(IocCustomCreationConverter))] ISPCurrencyRate currency)
        {
            try
            {
                var currencyUpdated = await currencyRateService.UpdateCurrency(currency);

                if (!currencyUpdated)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, currencyUpdated, "Operational failed.");
                }
                else
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, currencyUpdated, "Currency updated successfully.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Http Response Message</returns>
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCurrency(int id)
        {
            try
            {
                var deleted = await currencyRateService.DeleteCurrency(id);

                if (!deleted)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, deleted, "Operational failed.");
                }
                else
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, deleted, "Currency deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Internal server error");
            }
        }

        /// <summary>
        /// Activates the deactivate currency rate.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>Http Response Message</returns>
        [HttpPut]
        public async Task<HttpResponseMessage> ActivateDeactivateCurrencyRate([FromUri] int id, [FromUri] int flag)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await currencyRateService.ActivateCurrency(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, "Currency already activated.");
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "Currency activated successfully.");
                    }
                }

                if (flag == 0)
                {
                    var result = await currencyRateService.DeactivateCurrency(id);
                    if (!result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Failure, result, "Currency already deactivated.");
                    }

                    if (result)
                    {
                        return CreateHttpResponse<bool>(HttpStatusCode.OK, HttpCustomStatus.Success, result, "Currency deactivated successfully.");
                    }
                }

                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Operation failed.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Operation failed.");
            }
        }
        #endregion
    }
}