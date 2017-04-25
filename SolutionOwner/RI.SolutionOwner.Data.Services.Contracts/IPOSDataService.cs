//----------------------------------------------------------------------
// <copyright file="IPOSDataService.cs" company="RechargeIndia">
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
    /// Interface for POSDataService. Contains declaration of methods in POSDataService.
    /// </summary>
    public interface IPOSDataService : IDataService
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
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> ActivatePOSParameter(int parameterId);

        /// <summary>
        /// Deactivates the POS parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeactivatePOSParameter(int parameterId);
    }
}
