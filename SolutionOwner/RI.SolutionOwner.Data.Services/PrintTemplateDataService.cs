//-----------------------------------------------------------
// <copyright file="PrintTemplateDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using RI.Framework.Core.Data;
    using RI.Framework.Core.Data.Services;
    using RI.SolutionOwner.Data.Contracts;
    using RI.SolutionOwner.Data.Services.Contracts;

    /// <summary>
    ///  This class implements CRUD operations on solution partner print template entity
    /// </summary>
    public class PrintTemplateDataService : BaseDataService, IPrintTemplateDataService
    {
        /// <summary>
        /// repository interface variable 
        /// </summary>
        private IRepository<ISPPrintTemplate> printTemplateSrv;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintTemplateDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">unit of work interface</param>
        public PrintTemplateDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.printTemplateSrv = unitOfWork.Repository<ISPPrintTemplate>();
        }

        /// <summary>
        /// Get all print templates
        /// </summary>
        /// <returns>list of print templates</returns>
        public async Task<IEnumerable<ISPPrintTemplate>> GetAll()
        {
            return await this.printTemplateSrv.GetAllAsync();
        }

        /// <summary>
        /// Get specified print template details
        /// </summary>
        /// <param name="id">print template id</param>
        /// <returns>print template</returns>
        public async Task<ISPPrintTemplate> GetById(int id)
        {
           return await this.printTemplateSrv.GetByIdAsync(id);
        }

        /// <summary>
        /// Create a print template
        /// </summary>
        /// <param name="printTemplate">print template entity</param>
        /// <returns>created print template</returns>
        public ISPPrintTemplate Create(ISPPrintTemplate printTemplate)
        {
            try
            {
                bool exists = this.printTemplateSrv.Entities.Where(s => s.Name.ToLower() == printTemplate.Name.ToLower()).Count() > 0 ? true : false;
                if (!exists)
                {
                    printTemplate = this.printTemplateSrv.Add(printTemplate);
                    UnitOfWork.Commit();
                }
                else
                {
                    printTemplate = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return printTemplate;
        }

        /// <summary>
        /// Update details or status change of print template
        /// </summary>
        /// <param name="printTemplate">print template to be updated</param>
        /// <returns>status of the operation result</returns>
        public bool Update(ISPPrintTemplate printTemplate)
        {
            bool status = false;
            try
            {
                if (string.IsNullOrEmpty(printTemplate.Name))
                {
                    var templateEntity = this.printTemplateSrv.Entities.Where(s => s.Id == printTemplate.Id).FirstOrDefault();

                    if (printTemplate.IsActive != templateEntity.IsActive)
                    {
                        templateEntity.IsActive = !templateEntity.IsActive;
                        this.printTemplateSrv.Update(templateEntity);
                        UnitOfWork.Commit();
                        status = true;
                    }
                }
                else
                {
                    bool exists = this.printTemplateSrv.Entities.Where(s => s.Name.ToLower() == printTemplate.Name.ToLower() && s.Id != printTemplate.Id).Count() > 0 ? true : false;
                    if (!exists)
                    {
                        this.printTemplateSrv.Update(printTemplate);
                        UnitOfWork.Commit();
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
     
        /// <summary>
        /// Deletes the print template
        /// </summary>
        /// <param name="id">template id to be deleted</param>
        /// <returns>status of operation result</returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                var templateObj = await this.printTemplateSrv.GetByIdAsync(id);
                if (templateObj != null)
                {
                    this.printTemplateSrv.Delete(templateObj);
                    UnitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        /// <summary>
        /// Delete Multi selected templates
        /// </summary>
        /// <param name="ids">template ids to be deleted</param>
        /// <returns>status of operation result</returns>
        public async Task<bool> DeleteMulti(string ids)
        {
            try
            {
                string[] templateIds = null;
                if (!string.IsNullOrEmpty(ids))
                {
                    templateIds = ids.Split(',');
                    foreach (var item in templateIds)
                    {
                        var templateObj = await this.printTemplateSrv.GetByIdAsync(Convert.ToInt32(item));
                        if (templateObj != null)
                        {
                            this.printTemplateSrv.Delete(templateObj);
                        }
                    }
                }

                UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
