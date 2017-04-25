// ---------------------------------------------------------
// <copyright file="ISPCurrencyRateService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface ISPCurrencyRateService
    /// </summary>
    public interface ISPCurrencyRateService
    {
        /// <summary>
        /// Creates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>Interface ISPCurrencyRate</returns>
        ISPCurrencyRate CreateCurrency(ISPCurrencyRate currency);

        /// <summary>
        /// Gets all currency rate.
        /// </summary>
        /// <returns>List of interface</returns>
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
        /// <returns>Interface ISPCurrencyRate</returns>
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
