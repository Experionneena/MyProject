//---------------------------------------------------------
// <copyright file="IFeatureDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// The feature data service abstraction.
    /// </summary>
    public interface IFeatureDataService : IDataService
    {
        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>All features.</returns>
        Task<IEnumerable<ISOFeature>> GetAllFeatures();

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The feature instance.</returns>
        Task<ISOFeature> GetFeatureById(int id);

        /// <summary>
        /// Creates a new feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The creation status.</returns>
        bool CreateFeature(ISOFeature feature);

        /// <summary>
        /// Modifies the feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The modification status.</returns>
        bool UpdateFeature(ISOFeature feature);

        /// <summary>
        /// Removes the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The removal status.</returns>
        Task<bool> DeleteFeature(int featureId);

        /// <summary>
        /// Activates the deactivate feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>The process status.</returns>
        Task<bool> ActivateDeactivateFeature(int featureId, int flag);

        /// <summary>
        /// Activates the feature.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> ActivateFeature(int roleId);

        /// <summary>
        /// Deactivates the feature.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeactivateFeature(int roleId);

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The feature colection.</returns>
        IEnumerable<ISOFeature> GetFeatures(ISOFeature filter);

        /// <summary>
        /// Gets the feature for category.
        /// </summary>
        /// <param name="id">The category identifier.</param>
        /// <returns>The collection of feature in specific category.</returns>
        bool GetFeatureForCategory(int id);
    }
}
