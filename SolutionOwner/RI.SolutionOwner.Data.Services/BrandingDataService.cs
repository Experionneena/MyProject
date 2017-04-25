//-----------------------------------------------------------
// <copyright file="BrandingDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.Framework.Core.Data;
    using RI.Framework.Core.Data.Services;
    using RI.SolutionOwner.Data.Contracts;
    using RI.SolutionOwner.Data.Services.Contracts;

    /// <summary>
    ///  This class implements CRUD operations on solution owner branding entity
    /// </summary>
    public class BrandingDataService : BaseDataService, IBrandingDataService
    {
        /// <summary>
        /// repository interface variable 
        /// </summary>
        private IRepository<ISOBranding> brandingSrv;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandingDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">unit of work interface</param>
        public BrandingDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
          this.brandingSrv = UnitOfWork.Repository<ISOBranding>();
        }

        /// <summary>
        /// Add branding information
        /// </summary>
        /// <param name="branding">branding entity to be created</param>
        /// <returns>created branding entity</returns>
        public ISOBranding Create(ISOBranding branding)
        {
            try
            {
                var brandEntity = this.brandingSrv.Entities.Where(x => x.Id == branding.Id).FirstOrDefault();
                if (brandEntity == null)
                {
                    branding = this.brandingSrv.Add(branding);
                    int commitStatus = UnitOfWork.Commit();
                    return branding;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update branding information
        /// </summary>
        /// <param name="branding">branding entity to be updated</param>
        /// <returns>updated branding entity</returns>
        public ISOBranding Update(ISOBranding branding)
        {
            try
            {
                this.brandingSrv.Update(branding);
                int commitStatus = UnitOfWork.Commit();
                return branding;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Get branding information
        /// </summary>
        /// <returns>branding information</returns>
        public async Task<IEnumerable<ISOBranding>> GetAll()
        {
            return await this.brandingSrv.GetAllAsync();
        }
    }
}
