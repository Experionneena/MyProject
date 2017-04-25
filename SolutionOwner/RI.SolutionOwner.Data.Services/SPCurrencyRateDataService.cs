// ---------------------------------------------------------
// <copyright file="SPCurrencyRateDataService.cs" company="RechargeIndia">
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
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// Class SP Currency Data Service
    /// </summary>
    public class SPCurrencyRateDataService : BaseDataService, ISPCurrencyRateDataService
    {
        #region Private Members

        /// <summary>
        /// Private member _spCurrencyDescriptions
        /// </summary>
        private IRepository<ISPCurrencyRate> currencyRate;

        /// <summary>
        /// The currency
        /// </summary>
        private IRepository<ISPCurrency> currency;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyRateDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SPCurrencyRateDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.currencyRate = UnitOfWork.Repository<ISPCurrencyRate>();
            this.currency = UnitOfWork.Repository<ISPCurrency>();
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Create currency
        /// </summary>
        /// <param name="currency">new currency to be created</param>
        /// <returns>ISPCurrencyDescription interface</returns>
        public ISPCurrencyRate CreateCurrency(ISPCurrencyRate currency)
        {
            try
            {
                var savedCurrency = currencyRate.Add(currency);
                UnitOfWork.Commit();
                return savedCurrency;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all currency
        /// </summary>
        /// <returns>IEnumerable ISPCurrencyDescription interface</returns>
        public async Task<IEnumerable<ISPCurrencyRate>> GetAllCurrencyRate()
        {
            try
            {
                var currencyRateList = (await currencyRate.GetAllAsync()).ToList();
                return currencyRateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get currency by id
        /// </summary>
        /// <param name="currencyId">currency Id</param>
        /// <returns>ISPCurrencyDescription interface</returns>
        public async Task<ISPCurrencyRate> GetCurrencyById(int currencyId)
        {
            try
            {
                var currency = await currencyRate.GetByIdAsync(currencyId);
                return currency;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update currency
        /// </summary>
        /// <param name="currency">update a currency</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdateCurrency(ISPCurrencyRate currency)
        {
            try
            {
                var currencyData = await currencyRate.GetByIdAsync(currency.Id);

                currencyData.Id = currency.Id;
                currencyData.CurrencyDescription = currency.CurrencyDescription;
                currencyData.CurrencyId = currency.CurrencyId;
                currencyData.IsActive = currency.IsActive;
                currencyData.Rate = currency.Rate;

                currencyRate.Update(currencyData);
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete currency
        /// </summary>
        /// <param name="currencyId">currency Id</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeleteCurrency(int currencyId)
        {
            try
            {
                var currency = await currencyRate.GetByIdAsync(currencyId);
                currencyRate.Delete(currency);
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Activates the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Booelan value</returns>
        public async Task<bool> ActivateCurrency(int id)
        {
            try
            {
                var currency = await currencyRate.GetByIdAsync(id);
                if (currency.IsActive == true)
                {
                    return false;
                }

                if (currency.IsActive == false)
                {
                    currency.IsActive = true;
                    currencyRate.Update(currency);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deactivates the currency.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> DeactivateCurrency(int id)
        {
            try
            {
                var currency = await currencyRate.GetByIdAsync(id);
                if (currency.IsActive == false)
                {
                    return false;
                }

                if (currency.IsActive == true)
                {
                    currency.IsActive = false;
                    currencyRate.Update(currency);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
