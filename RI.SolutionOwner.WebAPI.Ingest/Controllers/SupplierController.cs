// ---------------------------------------------------------
// <copyright file="SupplierController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Ingest.Models;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// POS Registration Controller
    /// </summary>
    public class SupplierController : BaseController
    {
        #region private members

        /// <summary>
        /// The pos registration service
        /// </summary>
        private ISupplierService supplierService;

        /// <summary>
        /// The logger
        /// </summary>
        private ILoggerExtension logger;
        #endregion
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="POSRegistrationController"/> class.
        /// </summary>
        /// <param name="posRegistrationService">The pos registration service.</param>
        /// <param name="logger">The logger.</param>
        public SupplierController(ISupplierService supplierService, ILoggerExtension logger)
        {
            this.supplierService = supplierService;
            this.logger = logger;
        }
        #endregion

        #region Public Methods

        ///// <summary>
        ///// Gets all POS.
        ///// </summary>
        ///// <returns>HttpResponseMessage object</returns>
        [HttpGet]
        [Route("Supplier/GetAllSuppliers")]
        public async Task<HttpResponseMessage> GetAllSuppliers()
        {
            try
            {
                var supplierList = await supplierService.GetAllSuppliers();
                return CreateHttpResponse<IEnumerable<ISupplier>>(HttpStatusCode.OK, HttpCustomStatus.Success, supplierList, GetLocalisedString("msgSuccess"));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<IEnumerable<ISupplier>>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, null, GetLocalisedString("msgWebServiceError"));
            }
        }
        #endregion
    }

}
