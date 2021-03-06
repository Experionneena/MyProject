﻿//---------------------------------------------------------
// <copyright file="SPHierarchyService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// This class implements the busines rules for performing CRUD operations on Solution Partner related entities
    /// </summary>
    public class SPHierarchyService : ISPHierarchyService
    {
        #region Private Members

        /// <summary>
        /// The solution partner data service
        /// </summary>
        private ISPHierarchyDataService solutionPartnerDataService;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPHierarchyService"/> class.
        /// </summary>
        /// <param name="solutionPartnerDataService">The solution partner data service.</param>
        public SPHierarchyService(ISPHierarchyDataService solutionPartnerDataService)
        {
            this.solutionPartnerDataService = solutionPartnerDataService;
        }
        #endregion

        /// <summary>
        /// Adds the sp hierarchy.
        /// </summary>
        /// <param name="partnerHierarchy">The partner hierarchy.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public bool AddSPHierarchy(ISPHierarchy partnerHierarchy)
        {
            try
            {
                return solutionPartnerDataService.AddSPHierarchy(partnerHierarchy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the sp hierarchy by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// ISPHierarchy interface
        /// </returns>
        public async Task<ISPHierarchy> GetSPHierarchyById(int id)
        {
            return await solutionPartnerDataService.GetSPHierarchyById(id);
        }

        /// <summary>
        /// Updates the sp hierarchy.
        /// </summary>
        /// <param name="partnerHierarchy">The partner hierarchy.</param>
        /// <returns>
        /// boolean value
        /// </returns>
        public async Task<bool> UpdateSPHierarchy(ISPHierarchy partnerHierarchy)
        {
            return await solutionPartnerDataService.UpdateSPHierarchy(partnerHierarchy);
        }
    }
}
