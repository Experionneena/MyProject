//---------------------------------------------------------
// <copyright file="ISOSolutionPartnerContactDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// The SO Solution partner Contact data service abstraction.
    /// </summary>
    public interface ISOSolutionPartnerContactDataService : IDataService
    {
        /// <summary>
        /// Gets the contacts by partner identifier.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>The Collection of contacts.</returns>
        IEnumerable<ISOSolutionPartnerContact> GetContactsByPartnerId(int solutionPartnerId);

        /// <summary>
        /// Gets the contact by partner identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>
        /// The contact.
        /// </returns>
        ISOSolutionPartnerContact GetContactById(int contactId);

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The creation status.</returns>
        bool CreateContact(ISOSolutionPartnerContact contact);

        /// <summary>
        /// Modifies the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The Modification status.</returns>
        bool ModifyContact(ISOSolutionPartnerContact contact);

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>The Deletion status.</returns>
        bool DeleteContact(int contactId);
    }
}
