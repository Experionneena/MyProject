// ---------------------------------------------------------
// <copyright file="ISPCurrencyDataService.cs" company="RechargeIndia">
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
    /// Interface ISPCurrencyDataService
    /// </summary>
    public interface ISPCurrencyDataService : IDataService
    {
        /// <summary>
        /// Gets all currency.
        /// </summary>
        /// <returns>List of interface</returns>
        Task<IEnumerable<ISPCurrency>> GetAllCurrency();

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Interface ISPCurrency</returns>
        Task<ISPCurrency> GetCurrencyById(int id);
    }
}
