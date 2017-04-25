// ---------------------------------------------------------
// <copyright file="ISPCurrencyRateDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// Interface ISPCurrencyRateDataService
    /// </summary>
    public interface ISPCurrencyRateDataService : IDataService
    {
        /// <summary>
        /// Creates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>ISPCurrencyRate interface</returns>
        ISPCurrencyRate CreateCurrency(ISPCurrencyRate currency);

        /// <summary>
        /// Gets all currency rate.
        /// </summary>
        /// <returns>List of interfaces</returns>
        Task<IEnumerable<ISPCurrencyRate>> GetAllCurrencyRate();

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>Interface ISPCurrencyRate</returns>
        Task<ISPCurrencyRate> GetCurrencyById(int currencyId);

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>Interface ISPCurrencyRate</returns>
        Task<bool> UpdateCurrency(ISPCurrencyRate currency);

        /// <summary>
        /// Deletes the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> DeleteCurrency(int currencyId);

        /// <summary>
        /// Activates the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> ActivateCurrency(int id);

        /// <summary>
        /// Deactivates the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> DeactivateCurrency(int id);
    }
}
