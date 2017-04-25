//---------------------------------------------------------------
// <copyright file="IPOSService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface for POSService. Declaration of methods in POSService.
    /// </summary>
    public interface IPOSService
    {
        /// <summary>
        /// Gets all POS parameter categories.
        /// </summary>
        /// <returns>List of POS Parameter Categories</returns>
        Task<IEnumerable<IPOSParameterCategory>> GetAllPOSParameterCategories();

        /// <summary>
        /// Gets all position parameters.
        /// </summary>
        /// <returns>List of POS parameters</returns>
        Task<IEnumerable<IPOSParameter>> GetAllPOSParameters();

        /// <summary>
        /// Gets the POS parameter by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPOSParameter interface</returns>
        Task<IPOSParameter> GetPOSParameterById(int id);

        /// <summary>
        /// Adds the position parameter.
        /// </summary>
        /// <param name="posParameter">The POS parameter.</param>
        /// <returns>boolean value</returns>
        bool AddPOSParameter(IPOSParameter posParameter);

        /// <summary>
        /// Updates the POS parameter.
        /// </summary>
        /// <param name="posParameter">The POS parameter.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdatePOSParameter(IPOSParameter posParameter);

        /// <summary>
        /// Deletes the POS parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeletePOSParameter(int parameterId);

        /// <summary>
        /// Activates the POS parameter.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> ActivatePOSParameter(int roleId);

        /// <summary>
        /// Deactivates the POS parameter.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeactivatePOSParameter(int roleId);
    }
}
