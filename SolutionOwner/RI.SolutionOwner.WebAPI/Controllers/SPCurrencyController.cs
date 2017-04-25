// ---------------------------------------------------------
// <copyright file="SPCurrencyController.cs" company="RechargeIndia">
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
using RI.SolutionOwner.WebAPI.Models;

namespace RI.SolutionOwner.WebAPI.Controllers
{
    /// <summary>
    /// class SPCurrencyController
    /// </summary>
    public class SPCurrencyController : BaseController
    {
        #region Private Members
        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// The sp currency service
        /// </summary>
        private ISPCurrencyService currencyService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="currencyService">The sp currency service.</param>
        public SPCurrencyController(ILoggerExtension logger, ISPCurrencyService currencyService)
        {
            this.logger = logger;
            this.currencyService = currencyService;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Gets all currency.
        /// </summary>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllCurrency()
        {
            try
            {
                var currencyList = (await currencyService.GetAllCurrency()).ToList();
                if (currencyList.Count == 0)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.NoContent, HttpCustomStatus.Success, false, null);
                }
                else
                {
                    return CreateHttpResponse<List<ISPCurrency>>(HttpStatusCode.OK, HttpCustomStatus.Success, currencyList, null);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Internal server error");
            }
        }

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetCurrencyById(int id)
        {
            try
            {
                var currencyDetails = await currencyService.GetCurrencyById(id);
                if (currencyDetails == null)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.ExpectationFailed, HttpCustomStatus.Failure, false, null);
                }
                else
                {
                    return CreateHttpResponse<ISPCurrency>(HttpStatusCode.OK, HttpCustomStatus.Success, currencyDetails, null);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, "Internal server error");
            }
        }

        #endregion
    }
}