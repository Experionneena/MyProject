// ---------------------------------------------------------
// <copyright file="POSRegistrationService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Solution Partner Category Service
    /// </summary>
    public class SupplierService : ISupplierService
    {
        #region private members       
        /// <summary>
        /// The pos registration data service
        /// </summary>
        private ISupplierDataService supplierDataService;

        #endregion
        #region constructor    
        /// <summary>
        /// Initializes a new instance of the <see cref="POSRegistrationService"/> class.
        /// </summary>
        /// <param name="posRegistrationDataService">The position registration data service.</param>
        public SupplierService(ISupplierDataService supplierDataService)
        {
            this.supplierDataService = supplierDataService;
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Gets all POS.
        /// </summary>
        /// <returns>List of POS</returns>
        public async Task<IEnumerable<ISupplier>> GetAllSuppliers()
        {
            return await supplierDataService.GetAllSuppliers();
        }
        #endregion
    }
}
