//-----------------------------------------------------------
// <copyright file="PrintTemplateService.cs" company="RechargeIndia">
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
    /// This class implements the busines rules for performing CRUD operations on Solution partner print template entity.
    /// </summary>
    public class PrintTemplateService : IPrintTemplateService
    {
        /// <summary>
        /// Print template data service
        /// </summary>
        private IPrintTemplateDataService printTemplateSrv;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintTemplateService"/> class.
        /// </summary>
        /// <param name="printTemplatesrv">Print template data service</param>
        public PrintTemplateService(IPrintTemplateDataService printTemplatesrv)
        {
            this.printTemplateSrv = printTemplatesrv;
        }

        /// <summary>
        /// Get all print templates
        /// </summary>
        /// <returns>list of print templates</returns>
        public async Task<IEnumerable<ISPPrintTemplate>> GetAll()
        {
            return await this.printTemplateSrv.GetAll();
        }

        /// <summary>
        /// Get specified print template details
        /// </summary>
        /// <param name="id">print template id</param>
        /// <returns>print template entity</returns>
        public async Task<ISPPrintTemplate> GetById(int id)
        {
            return await this.printTemplateSrv.GetById(id);
        }

        /// <summary>
        /// Create a print template
        /// </summary>
        /// <param name="printTemplate">print template entity</param>
        /// <returns>created print template</returns>
        public ISPPrintTemplate Create(ISPPrintTemplate printTemplate)
        {
            return this.printTemplateSrv.Create(printTemplate);
        }

        /// <summary>
        /// Update template details or status change of print template
        /// </summary>
        /// <param name="printTemplate">print template to be updated</param>
        /// <returns>status of operation result</returns>
        public bool Update(ISPPrintTemplate printTemplate)
        {
            return this.printTemplateSrv.Update(printTemplate);
        }

        /// <summary>
        /// Deletes the print template
        /// </summary>
        /// <param name="id">template id to be deleted</param>
        /// <returns>status of operation result</returns>
        public Task<bool> Delete(int id)
        {
            return this.printTemplateSrv.Delete(id);
        }
    }
}