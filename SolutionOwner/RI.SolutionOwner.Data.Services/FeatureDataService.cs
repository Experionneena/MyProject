//----------------------------------------------------------
// <copyright file="FeatureDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// The Solution owner Data Service.
    /// </summary>
    public class FeatureDataService : BaseDataService, IFeatureDataService
    {
        #region Private Members

        /// <summary>
        /// The features repository.
        /// </summary>
        private IRepository<ISOFeature> features;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public FeatureDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            features = UnitOfWork.Repository<ISOFeature>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>
        /// All features.
        /// </returns>
        public async Task<IEnumerable<ISOFeature>> GetAllFeatures()
        {
            return await features.GetAllAsync();
        }

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The feature instance.
        /// </returns>
        public async Task<ISOFeature> GetFeatureById(int id)
        {
            return await features.GetByIdAsync(id);
        }

        /// <summary>
        /// Creates a new feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>
        /// The creation status.
        /// </returns>
        public bool CreateFeature(ISOFeature feature)
        {
            var featureName = feature.Name.Trim().ToLower();
            var displayName = feature.DisplayName.Trim().ToLower();
            var featureLink = feature.ProgramLink.Trim().ToLower();
            var featureExists = features.Entities
                .Where(x => (x.Name.Trim().ToLower() == featureName
                    || x.DisplayName.Trim().ToLower() == displayName
                    || x.ProgramLink.Trim().ToLower() == featureLink)
                    && x.IsActive == true)
                .Any();
            if (!featureExists)
            {
                var newFeature = features.Add(feature);
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Modifies the feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>
        /// The modification status.
        /// </returns>
        public bool UpdateFeature(ISOFeature feature)
        {
            var featureName = feature.Name.Trim().ToLower();
            var displayName = feature.DisplayName.Trim().ToLower();
            var featureLink = feature.ProgramLink.Trim().ToLower();
            var featureExists = features.Entities
                .Where(x => (x.Name.Trim().ToLower() == featureName
                    || x.DisplayName.Trim().ToLower() == displayName
                    || x.ProgramLink.Trim().ToLower() == featureLink)
                    && x.IsActive == true
                    && x.Id != feature.Id)
                .Any();
            if (!featureExists)
            {
                features.Update(feature);
                var updatedResult = UnitOfWork.Commit();
                return updatedResult == 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>
        /// The removal status.
        /// </returns>
        public async Task<bool> DeleteFeature(int featureId)
        {
            var feature = await features.GetByIdAsync(featureId);
            features.Delete(feature);
            var deleteResponse = UnitOfWork.Commit();
            return deleteResponse == 0 ? true : false;
        }

        /// <summary>
        /// Activates the deactivate feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>
        /// The process status.
        /// </returns>
        public async Task<bool> ActivateDeactivateFeature(int featureId, int flag)
        {
            var feature = await features.GetByIdAsync(featureId);
            if (flag == 1)
            {
                feature.IsActive = true;
            }
            else
            {
                feature.IsActive = false;
            }

            feature.EditedDate = DateTime.Now;
            features.Update(feature);
            var updatedResult = UnitOfWork.Commit();
            return updatedResult == 0 ? true : false;
        }

        /// <summary>
        /// Activates the feature.
        /// </summary>
        /// <param name="featureId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivateFeature(int featureId)
        {
            try
            {
                var entity = await features.GetByIdAsync(featureId);
                if (entity.IsActive == true)
                {
                    return false;
                }

                if (entity.IsActive == false)
                {
                    entity.IsActive = true;
                    features.Update(entity);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deactivates the feature.
        /// </summary>
        /// <param name="featureId">The role identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivateFeature(int featureId)
        {
            try
            {
                var entity = await features.GetByIdAsync(featureId);
                if (entity.IsActive == false)
                {
                    return false;
                }

                if (entity.IsActive == true)
                {
                    entity.IsActive = false;
                    features.Update(entity);
                    UnitOfWork.Commit();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The feature colection.
        /// </returns>
        public IEnumerable<ISOFeature> GetFeatures(ISOFeature filter)
        {
            return features.Entities.Where(x => (x.Name.Contains(filter.Name) || x.Name == null) && (x.IsActive == filter.IsActive));
        }

        /// <summary>
        /// Gets the feature for category.
        /// </summary>
        /// <param name="id">The category identifier.</param>
        /// <returns>
        /// The collection of feature in specific category.
        /// </returns>
        public bool GetFeatureForCategory(int id)
        {
            return features.Entities.Where(x => x.CategoryId == id).Any();
        }
        #endregion
    }
}
