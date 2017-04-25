// ---------------------------------------------------------
// <copyright file="ISPFeatureService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Solution Partner Feature Service Interface
    /// </summary>
    public interface ISPFeatureService
    {
        /// <summary>
        /// Gets the feature by hierarchy.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>The ISPFeature instance.</returns>
        Task<IEnumerable<ISPFeature>> GetFeatureByHierarchy(int hierarchyId);

        /// <summary>
        /// Gets the hierarchy.
        /// </summary>
        /// <returns>The Ihierarchy Instance.</returns>
        Task<IEnumerable<IHierarchy>> GetHierarchy();

        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>Returns all features.</returns>
        Task<IEnumerable<ISPFeature>> GetAllFeatures();

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The feature entity.</returns>
        Task<ISPFeature> GetFeatureById(int featureId);

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
        /// Deletes the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The removal status.</returns>
        Task<bool> DeleteFeature(int featureId);

        /// <summary>
        /// Deactivates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The process status</returns>
        Task<bool> DeactivateFeature(int featureId);

        /// <summary>
        /// Activates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The process status</returns>
        Task<bool> ActivateFeature(int featureId);

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>ISPFeature Object</returns>
        IEnumerable<ISPFeature> GetFeatures(ISPFeature filter);
    }
}
