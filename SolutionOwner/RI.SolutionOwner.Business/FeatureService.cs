//---------------------------------------------------------
// <copyright file="FeatureService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// The Solution owner fearure service.
    /// </summary>
    public class FeatureService : IFeatureService
    {
        #region Private Members

        /// <summary>
        /// The feature data service.
        /// </summary>
        private IFeatureDataService featureDataService;

        /// <summary>
        /// The role feature data service.
        /// </summary>
        private IRoleFeatureDataService roleFeatureDataService;

        /// <summary>
        /// The role data service.
        /// </summary>
        private IRoleDataService roleDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureService" /> class.
        /// </summary>
        /// <param name="featureDataService">The feature data service.</param>
        /// <param name="roleFeatureDataService">The role feature data service.</param>
        /// <param name="roleDataService">The role data service.</param>
        public FeatureService(
            IFeatureDataService featureDataService,
            IRoleFeatureDataService roleFeatureDataService,
            IRoleDataService roleDataService)
        {
            this.featureDataService = featureDataService;
            this.roleFeatureDataService = roleFeatureDataService;
            this.roleDataService = roleDataService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>Returns all features.</returns>
        public async Task<IEnumerable<ISOFeature>> GetAllFeatures()
        {
            return await featureDataService.GetAllFeatures();
        }

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The feature entity.</returns>
        public async Task<ISOFeature> GetFeatureById(int featureId)
        {
            return await featureDataService.GetFeatureById(featureId);
        }

        /// <summary>
        /// Creates a new feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The creation status.</returns>
        public bool CreateFeature(ISOFeature feature)
        {
            return featureDataService.CreateFeature(feature);
        }

        /// <summary>
        /// Modifies the feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The modification status.</returns>
        public bool UpdateFeature(ISOFeature feature)
        {
            bool result = false;
            result = featureDataService.UpdateFeature(feature);
            return result;
        }

        /// <summary>
        /// Deletes the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The removal status.</returns>
        public async Task<bool> DeleteFeature(int featureId)
        {
            List<ISORolePermission> roleFeatureList = new List<ISORolePermission>();
            roleFeatureList = roleFeatureDataService.GetRolesForFeatureId(featureId);
            ////menuList = _menuOptionDataService.GetMenuItemsByFeatureId(featureId);
            if (roleFeatureList.Count() == 0 /*&& menuList.Count() == 0*/)
            {
                return await featureDataService.DeleteFeature(featureId);
            }
            else
            {
                List<string> taggedMenuItems = new List<string>();
                List<string> roleNames = new List<string>();

                foreach (var item in roleFeatureList)
                {
                    var role = await roleDataService.GetById(item.RoleId);
                    roleNames.Add(role.RoleName);
                }

                return false;
            }
        }

        /// <summary>
        /// Activates the deactivate feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="flag">if set to <c>1</c> if active, else <c>0</c>.</param>
        /// <returns>The process status.</returns>
        public async Task<bool> ActivateDeactivateFeature(int featureId, int flag)
        {
            return await featureDataService.ActivateDeactivateFeature(featureId, flag);
        }

        /// <summary>
        /// Activates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> ActivateFeature(int featureId)
        {
            return await featureDataService.ActivateFeature(featureId);
        }

        /// <summary>
        /// Deactivates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeactivateFeature(int featureId)
        {
            return await featureDataService.DeactivateFeature(featureId);
        }

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The collection of feature.</returns>
        public IEnumerable<ISOFeature> GetFeatures(ISOFeature filter)
        {
            return featureDataService.GetFeatures(filter);
        }

        #endregion
    }
}
