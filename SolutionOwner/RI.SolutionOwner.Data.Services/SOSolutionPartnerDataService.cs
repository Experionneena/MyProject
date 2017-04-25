// ---------------------------------------------------------
// <copyright file="SOSolutionPartnerDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// Class SOSolutionPartnerDataService
    /// </summary>
    public class SOSolutionPartnerDataService : BaseDataService, ISOSolutionPartnerDataService
    {
        #region Private Members
        /// <summary>
        /// The solution partners
        /// </summary>
        private IRepository<ISOSolutionPartner> solutionPartners;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SOSolutionPartnerDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            solutionPartners = UnitOfWork.Repository<ISOSolutionPartner>();
        }
        #endregion

        #region Pubic Functions

        /// <summary>
        /// Creates the solution partner.
        /// </summary>
        /// <param name="solutionPartner">The so solution partner.</param>
        /// <returns>Interface ISOSolutionPartner</returns>
        public ISOSolutionPartner CreateSolutionPartner(ISOSolutionPartner solutionPartner)
        {
            try
            {
                var partner = solutionPartners.Add(solutionPartner);
                UnitOfWork.Commit();
                return partner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the solution partner by identifier.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>Interface ISOSolutionPartner</returns>
        public async Task<ISOSolutionPartner> GetSolutionPartnerById(int solutionPartnerId)
        {
            try
            {
                var solutionPartner = await solutionPartners.GetByIdAsync(solutionPartnerId);
                return solutionPartner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all so solution partners.
        /// </summary>
        /// <returns>List of ISOSolutionPartner</returns>
        public async Task<IEnumerable<ISOSolutionPartner>> GetAllSOSolutionPartners()
        {
            try
            {
                var solutionPartnerList = await solutionPartners.GetAllAsync();
                return solutionPartnerList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the so solution partner.
        /// </summary>
        /// <param name="solutionPartner">The so solution partner.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> UpdateSOSolutionPartner(ISOSolutionPartner solutionPartner)
        {
            try
            {
                var partner = await solutionPartners.GetByIdAsync(solutionPartner.Id);
                partner.AdminEmail = solutionPartner.AdminEmail;
                partner.CR = solutionPartner.CR;
                partner.CRExpiryDate = solutionPartner.CRExpiryDate;
                partner.CRProof = solutionPartner.CRProof;
                partner.CurrencyId = solutionPartner.CurrencyId;
                partner.EmailPassword = solutionPartner.EmailPassword;
                partner.IsActive = solutionPartner.IsActive;
                partner.Logo = solutionPartner.Logo;
                partner.LogoThumbNail = solutionPartner.LogoThumbNail;
                partner.Name = solutionPartner.Name;
                partner.Password = solutionPartner.Password;
                partner.POSPrintingQty = solutionPartner.POSPrintingQty;
                partner.ResetPasswordNextLogin = solutionPartner.ResetPasswordNextLogin;
                partner.SchedulerTime = solutionPartner.SchedulerTime;
                partner.SftpFolderPath = solutionPartner.SftpFolderPath;

                solutionPartners.Update(partner);
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the solution partner.
        /// </summary>
        /// <param name="solutionPartnerId">The solution partner identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> DeleteSolutionPartner(int solutionPartnerId)
        {
            try
            {
                var solutionPartner = await solutionPartners.GetByIdAsync(solutionPartnerId);
                solutionPartners.Delete(solutionPartner);
                UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Activates the solution partner.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> ActivateSolutionPartner(int id)
        {
            try
            {
                var solutionPartner = await solutionPartners.GetByIdAsync(id);
                if (solutionPartner.IsActive == true)
                {
                    return false;
                }

                if (solutionPartner.IsActive == false)
                {
                    solutionPartner.IsActive = true;
                    solutionPartners.Update(solutionPartner);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deactivates the solution partner.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean Value</returns>
        public async Task<bool> DeactivateSolutionPartner(int id)
        {
            try
            {
                var solutionPartner = await solutionPartners.GetByIdAsync(id);
                if (solutionPartner.IsActive == false)
                {
                    return false;
                }

                if (solutionPartner.IsActive == true)
                {
                    solutionPartner.IsActive = false;
                    solutionPartners.Update(solutionPartner);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
