//---------------------------------------------------------
// <copyright file="SOSolutionPartnerContactService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// The Solution partner contact service.
    /// </summary>
    public class SOSolutionPartnerContactService : ISOSolutionPartnerContactService
    {
        #region Private Members

        /// <summary>
        /// The Solution partner Contact data service.
        /// </summary>
        private ISOSolutionPartnerContactDataService contactDataService = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerContactService" /> class.
        /// </summary>
        /// <param name="contactDataService">The contact data service.</param>
        public SOSolutionPartnerContactService(ISOSolutionPartnerContactDataService contactDataService)
        {
            this.contactDataService = contactDataService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the contacts by partner identifier.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>The Collection of contact.</returns>
        public IEnumerable<ISOSolutionPartnerContact> GetContactsByPartnerId(int solutionPartnerId)
        {
            return contactDataService.GetContactsByPartnerId(solutionPartnerId);
        }

        /// <summary>
        /// Gets the contact by partner identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>The Contact.</returns>
        public ISOSolutionPartnerContact GetContactById(int contactId)
        {
            return contactDataService.GetContactById(contactId);
        }

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The creation status</returns>
        public bool CreateContact(ISOSolutionPartnerContact contact)
        {
            return contactDataService.CreateContact(contact);
        }

        /// <summary>
        /// Modifies the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The Modification status.</returns>
        public bool ModifyContact(ISOSolutionPartnerContact contact)
        {
            return contactDataService.ModifyContact(contact);
        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>The deletion status.</returns>
        public bool DeleteContact(int contactId)
        {
            return contactDataService.DeleteContact(contactId);
        }
        
        #endregion
    }
}
