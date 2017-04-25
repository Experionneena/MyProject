//---------------------------------------------------------
// <copyright file="SolutionPartnerDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// This class implements CRUD operations on Solution Partner related entities
    /// </summary>
    public class SolutionPartnerDataService : BaseDataService, ISolutionPartnerDataService
    {
        #region Private Members

        /// <summary>
        /// The solution partners
        /// </summary>
        private IRepository<ISOSolutionPartner> solutionPartners;

        /// <summary>
        /// The sp hierarchies
        /// </summary>
        private IRepository<ISPHierarchy> spHierarchies;

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionPartnerDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SolutionPartnerDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            solutionPartners = UnitOfWork.Repository<ISOSolutionPartner>();
            spHierarchies = UnitOfWork.Repository<ISPHierarchy>();
        }
        #endregion

        #region Commented
        ////public ISOSolutionPartner GetSftpFolderPath(int solutionPartnerId)
        //// {
        ////     var solutionPartner = solutionPartners.Entities.Where(x => x.Id == solutionPartnerId).FirstOrDefault();
        ////     return solutionPartner;
        //// }

        //// public async Task<bool> UpdateSftpFolderPath(int solutionPartnerId, string sftpFolderPath)
        //// {
        ////     var solutionPartnerEntity = await solutionPartners.GetByIdAsync(solutionPartnerId);
        ////     solutionPartnerEntity.SftpFolderPath = sftpFolderPath;            
        ////     solutionPartners.Update(solutionPartnerEntity);
        ////     var updatedSolutionPartner = UnitOfWork.Commit();
        ////     return true;
        //// }
        #endregion

        /// <summary>
        /// Adds the Solution Partner hierarchy.
        /// </summary>
        /// <param name="spHierarchy">The sp hierarchy.</param>
        /// <returns>boolean value</returns>
        public bool AddSPHierarchy(ISPHierarchy spHierarchy)
        {
            try
            {
                var hierarchy = spHierarchies.Add(spHierarchy);
                UnitOfWork.Commit();
                var addStatus = UnitOfWork.Commit();
                return addStatus == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the SP hierarchy by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<ISPHierarchy> GetSPHierarchyById(int id)
        {
            return await spHierarchies.GetByIdAsync(id);
        }

        /// <summary>
        /// Updates the Solution Partner hierarchy.
        /// </summary>
        /// <param name="spHierarchy">The sp hierarchy.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdateSPHierarchy(ISPHierarchy spHierarchy)
        {
            var hierarchyEntity = await spHierarchies.GetByIdAsync(spHierarchy.Id);
            hierarchyEntity.Id = spHierarchy.Id;
            hierarchyEntity.CreatedDate = spHierarchy.CreatedDate;
            hierarchyEntity.EditedDate = spHierarchy.EditedDate;
            hierarchyEntity.EnableDistributor = spHierarchy.EnableDistributor;
            hierarchyEntity.EnableModernTrade = spHierarchy.EnableModernTrade;
            hierarchyEntity.EnableSubDistributor = spHierarchy.EnableSubDistributor;
            hierarchyEntity.EnableWholesaler = spHierarchy.EnableWholesaler;
            spHierarchies.Update(hierarchyEntity);
            var updateStatus = UnitOfWork.Commit();
            return updateStatus == 0 ? true : false;
        }
    }
}
