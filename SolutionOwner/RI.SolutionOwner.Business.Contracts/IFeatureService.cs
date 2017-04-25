//----------------------------------------------------------
// <copyright file="IFeatureService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// The feature entity abstraction.
    /// </summary>
    public interface IFeatureService
    {
        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>Returns all features.</returns>
        Task<IEnumerable<ISOFeature>> GetAllFeatures();

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The feature entity.</returns>
        Task<ISOFeature> GetFeatureById(int featureId);

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
        /// Deletes the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The removal status.</returns>
        Task<bool> DeleteFeature(int featureId);

        /// <summary>
        /// Activates the deactivate feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="flag">if set to <c>1</c> if active, else <c>0</c>.</param>
        /// <returns>The process status.</returns>
        Task<bool> ActivateDeactivateFeature(int featureId, int flag);

        /// <summary>
        /// Activates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> ActivateFeature(int featureId);

        /// <summary>
        /// Deactivates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>boolean value</returns>
        Task<bool> DeactivateFeature(int featureId);

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The collection of ISOfeature.</returns>
        IEnumerable<ISOFeature> GetFeatures(ISOFeature filter);
    }
}