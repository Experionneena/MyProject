﻿//---------------------------------------------------------
// <copyright file="POSDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// This class implements CRUD operations on POSParameter entity and POSParameterCategory entity
    /// </summary>
    public class POSDataService : BaseDataService, IPOSDataService
    {
        #region Private Members
        /// <summary>
        /// The features repository.
        /// </summary>
        private IRepository<IPOSParameter> posParameters;

        /// <summary>
        /// The posParameterCategory repository
        /// </summary>
        private IRepository<IPOSParameterCategory> posParameterCategories;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="POSDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public POSDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            posParameters = UnitOfWork.Repository<IPOSParameter>();
            posParameterCategories = UnitOfWork.Repository<IPOSParameterCategory>();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all POS parameter categories.
        /// </summary>
        /// <returns>List of POSParameter Categories</returns>
        public async Task<IEnumerable<IPOSParameterCategory>> GetAllPOSParameterCategories()
        {
            return await posParameterCategories.GetAllAsync();
        }

        /// <summary>
        /// Gets all POS parameters.
        /// </summary>
        /// <returns>List of POS Parameters</returns>
        public async Task<IEnumerable<IPOSParameter>> GetAllPOSParameters()
        {
            return await posParameters.GetAllAsync();
        }

        /// <summary>
        /// Gets the POS parameter by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPOSParameter interface</returns>
        public async Task<IPOSParameter> GetPOSParameterById(int id)
        {
            return await posParameters.GetByIdAsync(id);
        }

        /// <summary>
        /// Adds the POS parameter.
        /// </summary>
        /// <param name="posParameter">The POS parameter.</param>
        /// <returns>boolean value</returns>
        public bool AddPOSParameter(IPOSParameter posParameter)
        {
            var paramExists = posParameters.Entities.Where(x => x.ParameterName.Trim().ToLower() == posParameter.ParameterName.Trim().ToLower() && x.POSParameterCategoryId == posParameter.POSParameterCategoryId).Any();
            if (paramExists)
            {
                return false;
            }

            var addedParameter = posParameters.Add(posParameter);
            UnitOfWork.Commit();
            return true;
        }

        /// <summary>
        /// Updates the POS parameter.
        /// </summary>
        /// <param name="posParameter">The POS parameter.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdatePOSParameter(IPOSParameter posParameter)
        {
            bool paramExists = posParameters.Entities.Where(x => x.POSParameterCategoryId == posParameter.POSParameterCategoryId && x.ParameterName.Trim().ToLower() == posParameter.ParameterName.Trim().ToLower() && x.Id != posParameter.Id).Any();
            if (paramExists)
            {
                return false;
            }

            var posParameterEntity = await posParameters.GetByIdAsync(posParameter.Id);
            posParameterEntity.IsActive = posParameter.IsActive;
            posParameterEntity.CreatedDate = posParameter.CreatedDate;
            posParameterEntity.DisplayOrder = posParameter.DisplayOrder;
            posParameterEntity.EditedDate = posParameter.EditedDate;
            posParameterEntity.Id = posParameter.Id;
            posParameterEntity.ParameterName = posParameter.ParameterName;
            posParameterEntity.POSParameterCategoryId = posParameter.POSParameterCategoryId;
            posParameters.Update(posParameterEntity);
            var updatedrole = UnitOfWork.Commit();
            return true;
        }

        /// <summary>
        /// Deletes the POS parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeletePOSParameter(int parameterId)
        {
            var role = await posParameters.GetByIdAsync(parameterId);
            posParameters.Delete(role);
            var deleteResponse = UnitOfWork.Commit();
            return deleteResponse == 0 ? true : false;
        }

        /// <summary>
        /// Activates the POS parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivatePOSParameter(int parameterId)
        {
                var entity = await posParameters.GetByIdAsync(parameterId);
                if (entity.IsActive == true)
                {
                    return false;
                }

                if (entity.IsActive == false)
                {
                    entity.IsActive = true;
                    posParameters.Update(entity);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
        }

        /// <summary>
        /// Deactivates the position parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivatePOSParameter(int parameterId)
        {
                var entity = await posParameters.GetByIdAsync(parameterId);
                if (entity.IsActive == false)
                {
                    return false;
                }

                if (entity.IsActive == true)
                {
                    entity.IsActive = false;
                    posParameters.Update(entity);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
        }

        #endregion
    }
}
