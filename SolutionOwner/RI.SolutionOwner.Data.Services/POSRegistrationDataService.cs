// ---------------------------------------------------------
// <copyright file="POSRegistrationDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services
{

    /// <summary>
    /// POSRegistration Data Service
    /// </summary>
    public class POSRegistrationDataService : BaseDataService, IPOSRegistrationDataService
    {
        #region private members
        /// <summary>
        /// The pos
        /// </summary>
        private IRepository<IPOS> pos;

        #endregion
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="POSRegistrationDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public POSRegistrationDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            pos = UnitOfWork.Repository<IPOS>();
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Gets all POS.
        /// </summary>
        /// <returns>List of POSParameter Categories</returns>
        public async Task<IEnumerable<IPOS>> GetAllPOS()
        {
            return await pos.GetAllAsync();
        }

        /// <summary>
        /// Gets the POS by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPOS interface</returns>
        public async Task<IPOS> GetPOSById(int id)
        {
            return await pos.GetByIdAsync(id);
        }

        /// <summary>
        /// Adds the POS.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>boolean value</returns>
        public bool CreatePOS(IPOS posRegistration)
        {
            posRegistration.AssignedTo = "Not Assigned";
            var paramExists = pos.Entities.Where(x => x.POSNumber.Trim().ToLower() == posRegistration.POSNumber.Trim().ToLower()
                              && x.SerialNumber == posRegistration.SerialNumber && x.PurchaseLPO == posRegistration.PurchaseLPO).Any();
            if (paramExists)
            {
                return false;
            }

            var addedPos = pos.Add(posRegistration);
            UnitOfWork.Commit();
            return true;
        }

        /// <summary>
        /// Updates the POS.
        /// </summary>
        /// <param name="pos">The POS.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdatePOS(IPOS posUpdate)
        {
            bool posExists = pos.Entities.Where(x => x.POSNumber == posUpdate.POSNumber && x.SerialNumber.Trim().ToLower() == posUpdate.SerialNumber.Trim().ToLower()
                                && x.PurchaseLPO == posUpdate.PurchaseLPO && x.Id != posUpdate.Id).Any();
            if (posExists)
            {
                return false;
            }

            var posEntity = await pos.GetByIdAsync(posUpdate.Id);
            posEntity.Id = posUpdate.Id;
            posEntity.POSNumber = posUpdate.POSNumber;
            posEntity.SerialNumber = posUpdate.SerialNumber;
            posEntity.ModelNumber = posUpdate.ModelNumber;
            posEntity.PurchaseLPO = posUpdate.PurchaseLPO;
            posEntity.WarrantyExpiry = posUpdate.WarrantyExpiry;
            posEntity.SupplierId = posUpdate.SupplierId;
            posEntity.Manufacturer = posUpdate.Manufacturer;
            posEntity.ManufacturingYear = posUpdate.ManufacturingYear;
            posEntity.Remarks = posUpdate.Remarks;
            posEntity.CreatedDate = posUpdate.CreatedDate;
            posEntity.EditedDate = posUpdate.EditedDate;
            posEntity.IsActive = posUpdate.IsActive;
            pos.Update(posEntity);
            var updatedPos = UnitOfWork.Commit();
            return true;
        }

        /// <summary>
        /// Deletes the POS.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeletePOS(int posId)
        {
            var posDelete = await pos.GetByIdAsync(posId);
            pos.Delete(posDelete);
            var deleteResponse = UnitOfWork.Commit();
            return deleteResponse == 0 ? true : false;
        }

        /// <summary>
        /// Activates the POS.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivatePOS(int posId)
        {
            var entity = await pos.GetByIdAsync(posId);
            if (entity.IsActive == true)
            {
                return false;
            }

            if (entity.IsActive == false)
            {
                entity.IsActive = true;
                pos.Update(entity);
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deactivates the pos.
        /// </summary>
        /// <param name="posId">The pos identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivatePOS(int posId)
        {
            var entity = await pos.GetByIdAsync(posId);
            if (entity.IsActive == false)
            {
                return false;
            }

            if (entity.IsActive == true)
            {
                entity.IsActive = false;
                pos.Update(entity);
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }
        #endregion
    }
}
