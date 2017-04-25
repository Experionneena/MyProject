// ---------------------------------------------------------
// <copyright file="SPCurrencyDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// Class SPCurrencyDataService
    /// </summary>
    public class SPCurrencyDataService : BaseDataService, ISPCurrencyDataService
    {
        #region Private Members
        /// <summary>
        /// The currency
        /// </summary>
        private IRepository<ISPCurrency> currency;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SPCurrencyDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.currency = UnitOfWork.Repository<ISPCurrency>();
        }

        /// <summary>
        /// Gets all currency.
        /// </summary>
        /// <returns>
        /// List of interface
        /// </returns>
        public async Task<IEnumerable<ISPCurrency>> GetAllCurrency()
        {
            try
            {
                var currencyList = await currency.GetAllAsync();
                return currencyList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Interface ISPCurrency</returns>
        public async Task<ISPCurrency> GetCurrencyById(int id)
        {
            try
            {
                var currencyDetails = await currency.GetByIdAsync(id);
                return currencyDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
