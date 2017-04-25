//---------------------------------------------------------
// <copyright file="SOSolutionPartnerContactDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// The SO Solution partner Contact data service.
    /// </summary>
    public class SOSolutionPartnerContactDataService : BaseDataService, ISOSolutionPartnerContactDataService
    {
        #region Private Members

        /// <summary>
        /// The contacts.
        /// </summary>
        private IRepository<ISOSolutionPartnerContact> contacts = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerContactDataService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SOSolutionPartnerContactDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            contacts = UnitOfWork.Repository<ISOSolutionPartnerContact>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the contacts by partner identifier.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>The Collection of contacts.</returns>
        public IEnumerable<ISOSolutionPartnerContact> GetContactsByPartnerId(int solutionPartnerId)
        {
            var item = Task.Run(async () =>
            {
                return await contacts.GetAllAsync();
            });
            return item.Result
                .Where(x => x.SolutionPartnerId == solutionPartnerId)
                .Select(x => x);
        }

        /// <summary>
        /// Gets the contact by partner identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>
        /// The contact.
        /// </returns>
        public ISOSolutionPartnerContact GetContactById(int contactId)
        {
            var item = Task.Run(async () =>
            {
                return await contacts.GetAllAsync();
            });
            return item.Result
                .Where(x => x.Id == contactId)
                .Select(x => x)
                .SingleOrDefault();
        }
        
        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The creation status.</returns>
        public bool CreateContact(ISOSolutionPartnerContact contact)
        {
            var newContact = contacts.Add(contact);
            var creationStatus = UnitOfWork.Commit();
            return (creationStatus == 0) ? true : false;
        }

        /// <summary>
        /// Modifies the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The Modification status.</returns>
        public bool ModifyContact(ISOSolutionPartnerContact contact)
        {
            contacts.Update(contact);
            var updateStatus = UnitOfWork.Commit();
            return (updateStatus == 0) ? true : false;
        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>The Deletion status.</returns>
        public bool DeleteContact(int contactId)
        {
            var contact = this.GetContactById(contactId);

            contacts.Delete(contact);
            var updateStatus = UnitOfWork.Commit();
            return (updateStatus == 0) ? true : false;
        }

        #endregion
    }
} 