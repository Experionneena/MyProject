﻿//--------------------------------------------------------------
// <copyright file="ISPHierarchyDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// ISolutionPartnerDataService interface
    /// </summary>
    public interface ISPHierarchyDataService : IDataService
    {
        /// <summary>
        /// Adds the sp hierarchy.
        /// </summary>
        /// <param name="partnerHierarchy">The partner hierarchy.</param>
        /// <returns>boolean value</returns>
        bool AddSPHierarchy(ISPHierarchy partnerHierarchy);

        /// <summary>
        /// Gets the sp hierarchy by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ISPHierarchy interface</returns>
        Task<ISPHierarchy> GetSPHierarchyById(int id);

        /// <summary>
        /// Updates the sp hierarchy.
        /// </summary>
        /// <param name="partnerHierarchy">The partner hierarchy.</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdateSPHierarchy(ISPHierarchy partnerHierarchy);
    }
}
