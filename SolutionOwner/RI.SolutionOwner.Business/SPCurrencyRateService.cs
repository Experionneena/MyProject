// ---------------------------------------------------------
// <copyright file="SPCurrencyRateService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Class SPCurrencyRateService
    /// </summary>
    public class SPCurrencyRateService : ISPCurrencyRateService
    {
        #region Private Members
        /// <summary>
        /// The currency rate data service
        /// </summary>
        private ISPCurrencyRateDataService currencyRateDataService;

        /// <summary>
        /// The currency data service
        /// </summary>
        private ISPCurrencyDataService currencyDataService;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyRateService"/> class.
        /// </summary>
        /// <param name="currencyRateDataService">The currency rate data service.</param>
        /// <param name="currencyDataService">The currency data service.</param>
        public SPCurrencyRateService(ISPCurrencyRateDataService currencyRateDataService, ISPCurrencyDataService currencyDataService)
        {
            this.currencyRateDataService = currencyRateDataService;
            this.currencyDataService = currencyDataService;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Creates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>
        /// Interface ISPCurrencyRate
        /// </returns>
        public ISPCurrencyRate CreateCurrency(ISPCurrencyRate currency)
        {
            var currencyCreated = currencyRateDataService.CreateCurrency(currency);
            return currencyCreated;
        }

        /// <summary>
        /// Get all currency
        /// </summary>
        /// <returns>List of interfaces</returns>
        public async Task<IEnumerable<ISPCurrencyRate>> GetAllCurrencyRate()
        {
            var currencyRateList = await currencyRateDataService.GetAllCurrencyRate();
            var currencyList = await currencyDataService.GetAllCurrency();

            List<ISPCurrencyRate> newCurrencyRateList = new List<ISPCurrencyRate>();

            foreach (var currencyRate in currencyRateList)
            {
                var currencyName = currencyRateList
                    .Where(x => x.Id == currencyRate.Id)
                    .Join(
                    currencyList,
                    u => u.CurrencyId,
                    r => r.Id,
                    (u, r) => new { Currency = r.Currency })
                    .Select(x => x.Currency).ToList();

                currencyRate.CurrencyList = currencyName;
                newCurrencyRateList.Add(currencyRate);
            }

            return newCurrencyRateList;
        }

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>
        /// Interface ISPCurrencyRate
        /// </returns>
        public async Task<ISPCurrencyRate> GetCurrencyById(int currencyId)
        {
            var currency = await currencyRateDataService.GetCurrencyById(currencyId);
            return currency;
        }

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>
        /// Interface ISPCurrencyRate
        /// </returns>
        public async Task<bool> UpdateCurrency(ISPCurrencyRate currency)
        {
            var currencyUpdated = await currencyRateDataService.UpdateCurrency(currency);
            return currencyUpdated;
        }

        /// <summary>
        /// Deletes the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>
        /// Interface ISPCurrencyRate
        /// </returns>
        public async Task<bool> DeleteCurrency(int currencyId)
        {
            return await currencyRateDataService.DeleteCurrency(currencyId);
        }

        /// <summary>
        /// Activates the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Boolean value
        /// </returns>
        public async Task<bool> ActivateCurrency(int id)
        {
            return await currencyRateDataService.ActivateCurrency(id);
        }

        /// <summary>
        /// Deactivates the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Boolean value
        /// </returns>
        public async Task<bool> DeactivateCurrency(int id)
        {
            return await currencyRateDataService.DeactivateCurrency(id);
        }

        #endregion
    }
}
