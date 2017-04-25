//-----------------------------------------------------------
// <copyright file="BrandingService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.SolutionOwner.Business.Contracts;
    using RI.SolutionOwner.Data.Contracts;
    using RI.SolutionOwner.Data.Services.Contracts;

    /// <summary>
    /// This class implements the business rules for performing CRUD operations on Solution Owner Branding Entity.
    /// </summary>
    public class BrandingService : IBrandingService
    {
        /// <summary>
        /// Branding data service
        /// </summary>
        private IBrandingDataService brandingSrv;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandingService"/> class.
        /// </summary>
        /// <param name="brandingSrv">Branding data service</param>
        public BrandingService(IBrandingDataService brandingSrv)
        {
            this.brandingSrv = brandingSrv;
        }

        /// <summary>
        /// Create operation of branding service
        /// </summary>
        /// <param name="branding">branding entity to be created</param>
        /// <returns>branding entity</returns>
        public ISOBranding Create(ISOBranding branding)
        {
            return this.brandingSrv.Create(branding);
        }

        /// <summary>
        /// update operation of branding service
        /// </summary>
        /// <param name="branding">branding entity to be updated</param>
        /// <returns>branding entity</returns>
        public ISOBranding Update(ISOBranding branding)
        {
            return this.brandingSrv.Update(branding);
        }

        /// <summary>
        /// Retrieves branding information
        /// </summary>
        /// <returns>branding information</returns>
        public async Task<IEnumerable<ISOBranding>> GetAll()
        {
            return await this.brandingSrv.GetAll();
        }
    }
}