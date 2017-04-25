// ---------------------------------------------------------
// <copyright file="SPFeatureDataService.cs" company="RechargeIndia">
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
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// The Solution owner Data Service.
    /// </summary>
    public class SPFeatureDataService : BaseDataService, ISPFeatureDataService
    {
        #region Private Members
        /// <summary>
        /// The features repository.
        /// </summary>
        private IRepository<ISPFeature> features;

        /// <summary>
        /// The hierarchy
        /// </summary>
        private IRepository<IHierarchy> hierarchy;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPFeatureDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SPFeatureDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.features = UnitOfWork.Repository<ISPFeature>();
            this.hierarchy = UnitOfWork.Repository<IHierarchy>();
        }
        #endregion

        #region Public Methods
       
        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>
        /// All features.
        /// </returns>
        public async Task<IEnumerable<ISPFeature>> GetAllFeatures()
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
        public async Task<ISPFeature> GetFeatureById(int id)
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
        public bool CreateFeature(ISPFeature feature)
        {
            var featureName = feature.Name.Trim().ToLower();
            var featureLink = feature.ProgramLink.Trim().ToLower();
            var displayName = feature.DisplayName.Trim().ToLower();
            var exists = features.Entities
                .Where(x => (x.Name.Trim().ToLower() == featureName
                    || x.ProgramLink.Trim().ToLower() == featureLink || x.DisplayName.Trim().ToLower() == displayName) && x.HierarchyId == feature.HierarchyId
                    && x.CategoryId == feature.CategoryId)
                .Any();
            if (!exists)
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
        public bool UpdateFeature(ISPFeature feature)
        {
            var featureName = feature.Name.Trim().ToLower();
            var featureLink = feature.ProgramLink.Trim().ToLower();
            var displayName = feature.DisplayName.Trim().ToLower();
            var exists = features.Entities
                .Where(x => (x.Name.Trim().ToLower() == featureName
                    || x.ProgramLink.Trim().ToLower() == featureLink || x.DisplayName.Trim().ToLower() == displayName) && x.HierarchyId == feature.HierarchyId
                    && x.Id != feature.Id && x.CategoryId == feature.CategoryId)
                .Any();
            if (!exists)
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
        /// Activates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The process Status</returns>
        public async Task<bool> ActivateFeature(int featureId)
        {
            var feature = await features.GetByIdAsync(featureId);
            if (feature.IsActive == true)
            {
                return false;
            }

            if (feature.IsActive == false)
            {
                feature.IsActive = true;
                features.Update(feature);
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deactivates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>Process Status</returns>
        public async Task<bool> DeactivateFeature(int featureId)
        {
            var feature = await features.GetByIdAsync(featureId);
            if (feature.IsActive == false)
            {
                return false;
            }

            if (feature.IsActive == true)
            {
                feature.IsActive = false;
                features.Update(feature);
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The feature colection.
        /// </returns>
        public IEnumerable<ISPFeature> GetFeatures(ISPFeature filter)
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

        /// <summary>
        /// Gets the hierarchy.
        /// </summary>
        /// <returns>
        /// IHierarchy Object
        /// </returns>
        public async Task<IEnumerable<IHierarchy>> GetHierarchy()
        {
            return await hierarchy.GetAllAsync();
        }

        #endregion
    }
}
