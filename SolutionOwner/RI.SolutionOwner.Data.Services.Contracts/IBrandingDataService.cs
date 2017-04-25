//-----------------------------------------------------------
// <copyright file="IBrandingDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

namespace RI.SolutionOwner.Data.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.Framework.Core.Data.Services;
    using RI.SolutionOwner.Data.Contracts;

    /// <summary>
    /// Interface for Branding data sevice. Declaration of methods in branding data service
    /// </summary>
    public interface IBrandingDataService : IDataService
    {
        /// <summary>
        /// Create operation of branding data service
        /// </summary>
        /// <param name="branding">branding entity to be created</param>
        /// <returns>created branding entity</returns>
        ISOBranding Create(ISOBranding branding);

        /// <summary>
        /// Update operation of branding data service
        /// </summary>
        /// <param name="branding">branding entity to be updated</param>
        /// <returns>updated branding entity</returns>
        ISOBranding Update(ISOBranding branding);

        /// <summary>
        /// Get branding information
        /// </summary>
        /// <returns>branding information</returns>
        Task<IEnumerable<ISOBranding>> GetAll();
    }
}
