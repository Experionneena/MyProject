// ---------------------------------------------------------
// <copyright file="POSRegistrationDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services
{

    /// <summary>
    /// Supplier Data Service
    /// </summary>
    public class SupplierDataService : BaseDataService, ISupplierDataService
    {
        #region private members
        /// <summary>
        /// The supplier
        /// </summary>
        private IRepository<ISupplier> supplier;

        #endregion
        #region constructor

     
        public SupplierDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            supplier = UnitOfWork.Repository<ISupplier>();
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Gets all suppliers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ISupplier>> GetAllSuppliers()
        {
            return await supplier.GetAllAsync();
        }
        #endregion
    }
}
