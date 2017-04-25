//----------------------------------------------------------------------
// <copyright file="IPOSRegistrationDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface for POSRegistrationDataService. Contains declaration of methods in POSRegistrationDataService.
    /// </summary>
    public interface IPOSRegistrationDataService : IDataService
    {

        /// <summary>
        /// Gets all pos.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IPOS>> GetAllPOS();

        /// <summary>
        /// Gets the POS by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPOS interface</returns>
        Task<IPOS> GetPOSById(int id);

        /// <summary>
        /// Adds the pos.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>boolean value</returns>
        bool CreatePOS(IPOS posRegistration);

        /// <summary>
        /// Updates the POSr.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdatePOS(IPOS pos);

        /// <summary>
        /// Deletes the POS.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeletePOS(int posId);

        /// <summary>
        /// Activates the POS.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> ActivatePOS(int posId);

        /// <summary>
        /// Deactivates the POS.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeactivatePOS(int posId);
    }
}
