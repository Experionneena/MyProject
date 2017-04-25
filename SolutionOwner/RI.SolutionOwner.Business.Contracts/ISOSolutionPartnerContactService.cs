//---------------------------------------------------------
// <copyright file="ISOSolutionPartnerContactService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// The Solution owner Solution partner Contact Service abstarction.
    /// </summary>
    public interface ISOSolutionPartnerContactService
    {
        /// <summary>
        /// Gets the contacts by partner identifier.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>The collection of Contacts.</returns>
        IEnumerable<ISOSolutionPartnerContact> GetContactsByPartnerId(int solutionPartnerId);

        /// <summary>
        /// Gets the contact by partner identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>The contact.</returns>
        ISOSolutionPartnerContact GetContactById(int contactId);

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The Creation status.</returns>
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
        /// <returns>The deletion status.</returns>
        bool DeleteContact(int contactId);
    }
}
