//---------------------------------------------------------
// <copyright file="ISolutionPartnerService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using RI.SolutionOwner.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Interface for SolutionPartnerService. Declaration of methods in SolutionPartnerService.
    /// </summary>
    public interface ISolutionPartnerService
    {
        /// <summary>
        /// Adds the sp hierarchy.
        /// </summary>
        /// <param name="spHierarchy">The sp hierarchy.</param>
        /// <returns>boolean value</returns>
        bool AddSPHierarchy(ISPHierarchy spHierarchy);

        /// <summary>
        /// Gets the sp hierarchy by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ISPHierarchy interface</returns>
        Task<ISPHierarchy> GetSPHierarchyById(int id);

        /// <summary>
        /// Updates the sp hierarchy.
        /// </summary>
        /// <param name="spHierarchy">The sp hierarchy.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdateSPHierarchy(ISPHierarchy spHierarchy);
    }
}
