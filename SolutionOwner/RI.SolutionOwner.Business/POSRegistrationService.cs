// ---------------------------------------------------------
// <copyright file="POSRegistrationService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Solution Partner Category Service
    /// </summary>
    public class POSRegistrationService : IPOSRegistrationService
    {
        #region private members       
        /// <summary>
        /// The pos registration data service
        /// </summary>
        private IPOSRegistrationDataService posRegistrationDataService;

        #endregion
        #region constructor    
        /// <summary>
        /// Initializes a new instance of the <see cref="POSRegistrationService"/> class.
        /// </summary>
        /// <param name="posRegistrationDataService">The position registration data service.</param>
        public POSRegistrationService(IPOSRegistrationDataService posRegistrationDataService)
        {
            this.posRegistrationDataService = posRegistrationDataService;
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Gets all POS.
        /// </summary>
        /// <returns>List of POS</returns>
        public async Task<IEnumerable<IPOS>> GetAllPOS()
        {
            return await posRegistrationDataService.GetAllPOS();
        }

        /// <summary>
        /// Gets the pos by identifier.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>IPOS interface</returns>
        public async Task<IPOS> GetPOSById(int posId)
        {
            return await posRegistrationDataService.GetPOSById(posId);
        }

        /// <summary>
        /// Adds the POS.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>boolean value</returns>
        public bool CreatePOS(IPOS pos)
        {
            return posRegistrationDataService.CreatePOS(pos);
        }

        /// <summary>
        /// Updates the POS.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdatePOS(IPOS pos)
        {
            return await posRegistrationDataService.UpdatePOS(pos);
        }

        /// <summary>
        /// Deletes the POS.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeletePOS(int posId)
        {
            return await posRegistrationDataService.DeletePOS(posId);
        }

        /// <summary>
        /// Activates the pos.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivatePOS(int posId)
        {
            return await posRegistrationDataService.ActivatePOS(posId);
        }

        /// <summary>
        /// Deactivates the pos.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivatePOS(int posId)
        {
            return await posRegistrationDataService.DeactivatePOS(posId);
        }
        #endregion
    }
}
