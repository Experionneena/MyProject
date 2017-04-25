// ---------------------------------------------------------
// <copyright file="SPAddressDataService.cs" company="RechargeIndia">
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
    /// Class SP Address Data Service
    /// </summary>
    public class SPAddressDataService : BaseDataService, ISPAddressDataService
    {
        #region Private Members

        /// <summary>
        /// The addresses
        /// </summary>
        private IRepository<ISPAddress> partnerAddresses;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPAddressDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SPAddressDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.partnerAddresses = UnitOfWork.Repository<ISPAddress>();
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Creates the sp address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>Interface ISPAddress</returns>
        public ISPAddress CreateSPAddress(ISPAddress address)
        {
            try
            {
                var savedAddress = partnerAddresses.Add(address);
                UnitOfWork.Commit();
                return savedAddress;
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
        /// <returns>Interface ISPAddress</returns>
        public async Task<ISPAddress> GetAddressById(int addressId)
        {
            return await partnerAddresses.GetByIdAsync(addressId);
        }

        /// <summary>
        /// Gets all address.
        /// </summary>
        /// <returns>List of ISPAddress</returns>
        public async Task<IEnumerable<ISPAddress>> GetAllAddress()
        {
            try
            {
                return await partnerAddresses.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                var partnerAddress = await partnerAddresses.GetByIdAsync(address.Id);
                partnerAddress.Address = address.Address;
                partnerAddress.Area = address.Area;
                partnerAddress.City = address.City;
                partnerAddress.ContactPerson = address.ContactPerson;
                partnerAddress.ContactPersonEmail = address.ContactPersonEmail;
                partnerAddress.Country = address.Country;
                partnerAddress.MobileNumber = address.MobileNumber;
                partnerAddress.NFC = address.NFC;
                partnerAddress.POBox = address.POBox;
                partnerAddress.State = address.State;
                partnerAddress.Street = address.Street;
                partnerAddress.TimeZoneId = address.TimeZoneId;
                partnerAddress.Zone = address.Zone;

                partnerAddresses.Update(partnerAddress);
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
