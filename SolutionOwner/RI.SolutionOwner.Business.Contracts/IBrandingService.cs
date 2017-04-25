//-----------------------------------------------------------
// <copyright file="IBrandingService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Business.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.SolutionOwner.Data.Contracts;

    /// <summary>
    /// Interface for Branding sevice. Declaration of methods in branding service
    /// </summary>
    public interface IBrandingService
    {
        /// <summary>
        /// This signifies create operation of branding service 
        /// </summary>
        /// <param name="branding">branding entity to be created</param>
        /// <returns>branding entity</returns>
        ISOBranding Create(ISOBranding branding);

        /// <summary>
        /// This signifies update operation of branding service
        /// </summary>
        /// <param name="branding">branding entity to be updated</param>
        /// <returns>branding entity</returns>
        ISOBranding Update(ISOBranding branding);
        
        /// <summary>
        ///  Retrieves branding information
        /// </summary>
       /// <returns>branding information</returns>
        Task<IEnumerable<ISOBranding>> GetAll();
    }
}
