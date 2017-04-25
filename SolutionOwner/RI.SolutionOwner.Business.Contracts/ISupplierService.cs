//---------------------------------------------------------------
// <copyright file="ISupplierService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// ISupplierService Interface
    /// </summary>
    public interface ISupplierService
    {
        /// <summary>
        /// Gets all suppliers.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ISupplier>> GetAllSuppliers();
    }
}
