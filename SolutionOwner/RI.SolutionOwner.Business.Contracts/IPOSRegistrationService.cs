//---------------------------------------------------------------
// <copyright file="IPOSRegistrationService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface for POSRegistrationService. Declaration of methods in POSService.
    /// </summary>
    public interface IPOSRegistrationService
    {
        /// <summary>
        /// Gets all POS parameter.
        /// </summary>
        /// <returns>List of POS Parameter Categories</returns>
        Task<IEnumerable<IPOS>> GetAllPOS();

        /// <summary>
        /// Gets the POS by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPOSParameter interface</returns>
        Task<IPOS> GetPOSById(int id);

        /// <summary>
        /// Adds the pos.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>boolean value</returns>
        bool CreatePOS(IPOS pos);

        /// <summary>
        /// Updates the POS parameter.
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
        /// Deactivates the POS parameter.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeactivatePOS(int posId);
    }
}
