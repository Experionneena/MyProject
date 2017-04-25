// ---------------------------------------------------------
// <copyright file="SPAddressService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Class SPAddressService
    /// </summary>
    public class SPAddressService : ISPAddressService
    {
        #region Private Members

        /// <summary>
        /// The address data service
        /// </summary>
        private ISPAddressDataService addressDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPAddressService"/> class.
        /// </summary>
        /// <param name="addressDataService">The address data service.</param>
        public SPAddressService(ISPAddressDataService addressDataService)
        {
            this.addressDataService = addressDataService;
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Creates the sp address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>The interface</returns>
        public ISPAddress CreateSPAddress(ISPAddress address)
        {
            try
            {
                var addressCreated = addressDataService.CreateSPAddress(address);
                return addressCreated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the address by identifier.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <returns>The interface</returns>
        public async Task<ISPAddress> GetAddressById(int addressId)
        {
            return await addressDataService.GetAddressById(addressId);
        }

        /// <summary>
        /// Gets all address.
        /// </summary>
        /// <returns>List of interfaces</returns>
        public async Task<IEnumerable<ISPAddress>> GetAllAddress()
        {
            return await addressDataService.GetAllAddress();
        }

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> UpdateAddress(ISPAddress address)
        {
            try
            {
                return await addressDataService.UpdateAddress(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
