// ---------------------------------------------------------
// <copyright file="SPCurrencyService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Class SPCurrencyService
    /// </summary>
    public class SPCurrencyService : ISPCurrencyService
    {
        #region Private Members
        /// <summary>
        /// The currency data service
        /// </summary>
        private ISPCurrencyDataService currencyDataService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyService"/> class.
        /// </summary>
        /// <param name="currencyDataService">The currency data service.</param>
        public SPCurrencyService(ISPCurrencyDataService currencyDataService)
        {
            this.currencyDataService = currencyDataService;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Gets all currency.
        /// </summary>
        /// <returns>
        /// List of interface
        /// </returns>
        public async Task<IEnumerable<ISPCurrency>> GetAllCurrency()
        {
            var currencyList = await currencyDataService.GetAllCurrency();
            return currencyList;
        }

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Interface ISPCurrency
        /// </returns>
        public async Task<ISPCurrency> GetCurrencyById(int id)
        {
            var currencyDetails = await currencyDataService.GetCurrencyById(id);
            return currencyDetails;
        }
        #endregion
    }
}
