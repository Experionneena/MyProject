//---------------------------------------------------------
// <copyright file="SPHierarchyDataService.cs" company="RechargeIndia">
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
    public class SPHierarchyDataService : BaseDataService, ISPHierarchyDataService
    {
        #region Private Members

        /// <summary>
        /// The solution partners
        /// </summary>
        private IRepository<ISOSolutionPartner> solutionPartners;

        /// <summary>
        /// The sp hierarchies
        /// </summary>
        private IRepository<ISPHierarchy> partnerHierarchies;

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="SPHierarchyDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SPHierarchyDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            solutionPartners = UnitOfWork.Repository<ISOSolutionPartner>();
            partnerHierarchies = UnitOfWork.Repository<ISPHierarchy>();
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
                var hierarchy = partnerHierarchies.Add(partnerHierarchy);
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
            return await partnerHierarchies.GetByIdAsync(id);
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
            var hierarchyEntity = await partnerHierarchies.GetByIdAsync(partnerHierarchy.Id);
            hierarchyEntity.Id = partnerHierarchy.Id;
            hierarchyEntity.CreatedDate = partnerHierarchy.CreatedDate;
            hierarchyEntity.EditedDate = partnerHierarchy.EditedDate;
            hierarchyEntity.EnableDistributor = partnerHierarchy.EnableDistributor;
            hierarchyEntity.EnableModernTrade = partnerHierarchy.EnableModernTrade;
            hierarchyEntity.EnableSubDistributor = partnerHierarchy.EnableSubDistributor;
            hierarchyEntity.EnableWholesaler = partnerHierarchy.EnableWholesaler;
            partnerHierarchies.Update(hierarchyEntity);
            var updateStatus = UnitOfWork.Commit();
            return updateStatus == 0 ? true : false;
        }
    }
}
