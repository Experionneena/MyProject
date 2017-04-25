//---------------------------------------------------------------
// <copyright file="POSService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// This class implements the busines rules for performing CRUD operations on POSParameters Entity. and POSParameterCategory Entity
    /// </summary>
    public class POSService : IPOSService
    {
        #region Private Members

        /// <summary>
        /// The POS data service
        /// </summary>
        private IPOSDataService posDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="POSService"/> class.
        /// </summary>
        /// <param name="posDataService">The POS data service.</param>
        public POSService(IPOSDataService posDataService)
        {
            this.posDataService = posDataService;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all POS parameter categories.
        /// </summary>
        /// <returns>List of POS Parameter Categories</returns>
        public async Task<IEnumerable<IPOSParameterCategory>> GetAllPOSParameterCategories()
        {
            return await posDataService.GetAllPOSParameterCategories();
        }

        /// <summary>
        /// Gets all POS parameters.
        /// </summary>
        /// <returns>List of POS Parameters</returns>
        public async Task<IEnumerable<IPOSParameter>> GetAllPOSParameters()
        {
            return await posDataService.GetAllPOSParameters();
        }

        /// <summary>
        /// Gets the position parameter by identifier.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>IPOSParameter interface</returns>
        public async Task<IPOSParameter> GetPOSParameterById(int parameterId)
        {
            return await posDataService.GetPOSParameterById(parameterId);
        }

        /// <summary>
        /// Adds the POS parameter.
        /// </summary>
        /// <param name="posParameter">The POS parameter.</param>
        /// <returns>boolean value</returns>
        public bool AddPOSParameter(IPOSParameter posParameter)
        {
            return posDataService.AddPOSParameter(posParameter);
        }

        /// <summary>
        /// Updates the POS parameter.
        /// </summary>
        /// <param name="posParameter">The POS parameter.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdatePOSParameter(IPOSParameter posParameter)
        {
            return await posDataService.UpdatePOSParameter(posParameter);
        }

        /// <summary>
        /// Deletes the POS parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeletePOSParameter(int parameterId)
        {
            return await posDataService.DeletePOSParameter(parameterId);
        }

        /// <summary>
        /// Activates the position parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivatePOSParameter(int parameterId)
        {
            return await posDataService.ActivatePOSParameter(parameterId);
        }

        /// <summary>
        /// Deactivates the position parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivatePOSParameter(int parameterId)
        {
            return await posDataService.DeactivatePOSParameter(parameterId);
        }

        #endregion
    }
}
