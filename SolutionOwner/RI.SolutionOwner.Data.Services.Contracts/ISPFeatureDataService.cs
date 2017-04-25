// ---------------------------------------------------------
// <copyright file="ISPFeatureDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Entities;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// Solution Partner Data Service Interface
    /// </summary>
    public interface ISPFeatureDataService : IDataService
    {
        /// <summary>
        /// Gets the hierarchy.
        /// </summary>
        /// <returns>IHierarchy Object</returns>
        Task<IEnumerable<IHierarchy>> GetHierarchy();

        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>All features.</returns>
        Task<IEnumerable<ISPFeature>> GetAllFeatures();

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The feature instance.</returns>
        Task<ISPFeature> GetFeatureById(int id);

        /// <summary>
        /// Creates a new feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The creation status.</returns>
        bool CreateFeature(ISPFeature feature);

        /// <summary>
        /// Modifies the feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The modification status.</returns>
        bool UpdateFeature(ISPFeature feature);

        /// <summary>
        /// Removes the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The removal status.</returns>
        Task<bool> DeleteFeature(int featureId);
               
        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The feature colection.</returns>
        IEnumerable<ISPFeature> GetFeatures(ISPFeature filter);

        /// <summary>
        /// Gets the feature for category.
        /// </summary>
        /// <param name="id">The category identifier.</param>
        /// <returns>The collection of feature in specific category.</returns>
        bool GetFeatureForCategory(int id);

        /// <summary>
        /// Activates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The process Status</returns>
        Task<bool> ActivateFeature(int featureId);

        /// <summary>
        /// Deactivates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The process Status</returns>
        Task<bool> DeactivateFeature(int featureId);
    }
}
