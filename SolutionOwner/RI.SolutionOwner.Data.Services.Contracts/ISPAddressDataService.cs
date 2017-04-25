//---------------------------------------------------------
// <copyright file="ISPAddressDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// Interface ISPAddressDataService
    /// </summary>
    public interface ISPAddressDataService : IDataService
    {
        /// <summary>
        /// Creates the sp address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>The interface</returns>
        ISPAddress CreateSPAddress(ISPAddress address);

        /// <summary>
        /// Gets the address by identifier.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <returns>The interface</returns>
        Task<ISPAddress> GetAddressById(int addressId);

        /// <summary>
        /// Gets all address.
        /// </summary>
        /// <returns>List of interface</returns>
        Task<IEnumerable<ISPAddress>> GetAllAddress();

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>Boolean value</returns>
        Task<bool> UpdateAddress(ISPAddress address);
    }
}
