//-----------------------------------------------------------
// <copyright file="IPrintTemplateService.cs" company="RechargeIndia">
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
    /// Interface for print template service. Declaration of methods in print template service
    /// </summary>
    public interface IPrintTemplateService
    {
        /// <summary>
        /// Get all print templates
        /// </summary>
        /// <returns>list of print templates</returns>
        Task<IEnumerable<ISPPrintTemplate>> GetAll();

        /// <summary>
        /// Get specified print template details
        /// </summary>
        /// <param name="id">print template id</param>
        /// <returns>print tempalte</returns>
        Task<ISPPrintTemplate> GetById(int id);

        /// <summary>
        /// Create a print template
        /// </summary>
        /// <param name="printTemplate">print template entity</param>
        /// <returns>created print templated</returns>
        ISPPrintTemplate Create(ISPPrintTemplate printTemplate);

        /// <summary>
        /// Update details or status change of print template
        /// </summary>
        /// <param name="printTemplate">print template to be updated</param>
        /// <returns>status of the operation result</returns>
        bool Update(ISPPrintTemplate printTemplate);

        /// <summary>
        /// Deletes the print template
        /// </summary>
        /// <param name="id">template id to be deleted</param>
        /// <returns>status of operation result</returns>
        Task<bool> Delete(int id);
    }
}