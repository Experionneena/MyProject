//----------------------------------------------------------------------
// <copyright file="IPOSRegistrationDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface for POSRegistrationDataService. Contains declaration of methods in POSRegistrationDataService.
    /// </summary>
    public interface ISupplierDataService : IDataService
    {

        /// <summary>
        /// Gets all pos.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ISupplier>> GetAllSuppliers();
    }
}
