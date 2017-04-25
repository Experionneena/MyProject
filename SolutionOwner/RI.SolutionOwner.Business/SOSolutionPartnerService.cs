// ---------------------------------------------------------
// <copyright file="SOSolutionPartnerService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Class SOSolutionPartnerService 
    /// </summary>
    public class SOSolutionPartnerService : ISOSolutionPartnerService
    {
        #region Private Members

        /// <summary>
        /// The solution partner data service
        /// </summary>
        private ISOSolutionPartnerDataService solutionPartnerDataService;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerService"/> class.
        /// </summary>
        /// <param name="solutionPartnerDataService">The solution partner data service.</param>
        public SOSolutionPartnerService(ISOSolutionPartnerDataService solutionPartnerDataService)
        {
            this.solutionPartnerDataService = solutionPartnerDataService;
        }
        #endregion

        #region Public Functions

        /// <summary>
        /// Creates the solution partner.
        /// </summary>
        /// <param name="solutionPartner">The solution partner.</param>
        /// <returns>The interface</returns>
        public async Task<ISOSolutionPartner> CreateSolutionPartner(ISOSolutionPartner solutionPartner)
        {
            var solutionPartnerDetails = (await solutionPartnerDataService.GetAllSOSolutionPartners()).Where(x => x.AdminEmail == solutionPartner.AdminEmail).FirstOrDefault();
            if (solutionPartnerDetails == null)
            {
                var solutionPartnerCreated = solutionPartnerDataService.CreateSolutionPartner(solutionPartner);
                return null;
            }
            else
            {
                return solutionPartnerDetails;
            }
        }

        /// <summary>
        /// Gets the solution partner by identifier.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>Interface ISOSolutionPartner</returns>
        public async Task<ISOSolutionPartner> GetSolutionPartnerById(int solutionPartnerId)
        {
            var solutionPartner = await solutionPartnerDataService.GetSolutionPartnerById(solutionPartnerId);
            return solutionPartner;
        }

        /// <summary>
        /// Gets all solution partners.
        /// </summary>
        /// <returns>List of ISOSolutionPartner</returns>
        public async Task<IEnumerable<ISOSolutionPartner>> GetAllSolutionPartners()
        {
            var solutionPartnerList = await solutionPartnerDataService.GetAllSOSolutionPartners();
            return solutionPartnerList;
        }

        /// <summary>
        /// Updates the solution partner.
        /// </summary>
        /// <param name="solutionPartner">The solution partner.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> UpdateSolutionPartner(ISOSolutionPartner solutionPartner)
        {
            var solutionPartnerDetail = (await solutionPartnerDataService.GetAllSOSolutionPartners()).Where(x => x.AdminEmail == solutionPartner.AdminEmail).FirstOrDefault();
            if (solutionPartnerDetail == null || solutionPartnerDetail.Id == solutionPartner.Id)
            {
                var updatedSolutionPartner = await solutionPartnerDataService.UpdateSOSolutionPartner(solutionPartner);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the solution partner.
        /// </summary>
        /// <param name="solutionpartnerId">The solutionpartner identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> DeleteSolutionPartner(int solutionpartnerId)
        {
            return await solutionPartnerDataService.DeleteSolutionPartner(solutionpartnerId);
        }

        /// <summary>
        /// Activates the solution partner.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> ActivateSolutionPartner(int id)
        {
            return await solutionPartnerDataService.ActivateSolutionPartner(id);
        }

        /// <summary>
        /// Deactivates the solution partner.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> DeactivateSolutionPartner(int id)
        {
            return await solutionPartnerDataService.DeactivateSolutionPartner(id);
        }

        #endregion
    }
}
