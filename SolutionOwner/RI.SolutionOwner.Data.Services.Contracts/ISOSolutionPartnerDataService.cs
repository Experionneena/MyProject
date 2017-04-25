//---------------------------------------------------------------
// <copyright file="ISOSolutionPartnerDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// Interface ISOSolutionPartnerDataService
    /// </summary>
    public interface ISOSolutionPartnerDataService : IDataService
    {
        /// <summary>
        /// Creates the solution partner.
        /// </summary>
        /// <param name="solutionPartner">The so solution partner.</param>
        /// <returns>Interface ISOSolutionPartner</returns>
        ISOSolutionPartner CreateSolutionPartner(ISOSolutionPartner solutionPartner);

        /// <summary>
        /// Gets the solution partner by identifier.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>Interface ISOSolutionPartner</returns>
        Task<ISOSolutionPartner> GetSolutionPartnerById(int solutionPartnerId);

        /// <summary>
        /// Gets all so solution partners.
        /// </summary>
        /// <returns>List of ISOSolutionPartner</returns>
        Task<IEnumerable<ISOSolutionPartner>> GetAllSOSolutionPartners();

        /// <summary>
        /// Updates the so solution partner.
        /// </summary>
        /// <param name="solutionPartner">The so solution partner.</param>
        /// <returns>Booelan value</returns>
        Task<bool> UpdateSOSolutionPartner(ISOSolutionPartner solutionPartner);

        /// <summary>
        /// Deletes the solution partner.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>Boolean value</returns>
        Task<bool> DeleteSolutionPartner(int solutionPartnerId);

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
