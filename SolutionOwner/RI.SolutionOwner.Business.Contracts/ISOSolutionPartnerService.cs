//---------------------------------------------------------------
// <copyright file="ISOSolutionPartnerService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface ISOSolutionPartnerService
    /// </summary>
    public interface ISOSolutionPartnerService
    {
        /// <summary>
        /// Creates the solution partner.
        /// </summary>
        /// <param name="solutionPartner">The solution partner.</param>
        /// <returns>The interface</returns>
        Task<ISOSolutionPartner> CreateSolutionPartner(ISOSolutionPartner solutionPartner);

        /// <summary>
        /// Gets the solution partner by identifier.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>The interface</returns>
        Task<ISOSolutionPartner> GetSolutionPartnerById(int solutionPartnerId);

        /// <summary>
        /// Gets all solution partners.
        /// </summary>
        /// <returns>list of interface</returns>
        Task<IEnumerable<ISOSolutionPartner>> GetAllSolutionPartners();

        /// <summary>
        /// Updates the solution partner.
        /// </summary>
        /// <param name="solutionPartner">The solution partner.</param>
        /// <returns>The interface</returns>
        Task<bool> UpdateSolutionPartner(ISOSolutionPartner solutionPartner);

        /// <summary>
        /// Deletes the solution partner.
        /// </summary>
        /// <param name="solutionpartnerId">The solutionpartner identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> DeleteSolutionPartner(int solutionpartnerId);

        /// <summary>
        /// Activates the solution partner.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> ActivateSolutionPartner(int id);

        /// <summary>
        /// Deactivates the solution partner.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> DeactivateSolutionPartner(int id);
    }
}
