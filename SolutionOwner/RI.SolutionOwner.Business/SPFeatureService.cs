// ---------------------------------------------------------
// <copyright file="SPFeatureService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Business;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Solution Partner Feature Service
    /// </summary>
    public class SPFeatureService : ISPFeatureService
    {
        #region Private Members

        /// <summary>
        /// The Solution Partner feature data service.
        /// </summary>
        private ISPFeatureDataService featureDataService;

        /// <summary>
        /// The Solution Partner role feature data service.
        /// </summary>
        private ISPRoleFeatureDataService roleFeatureDataService;

        /// <summary>
        /// The Solution Partner role data service
        /// </summary>
        private ISPRoleDataService roleDataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPFeatureService" /> class.
        /// </summary>
        /// <param name="featureDataService">The feature data service.</param>
        /// <param name="roleFeatureDataService">The role feature data service.</param>
        /// <param name="roleDataService">The role data service.</param>
        public SPFeatureService(
            ISPFeatureDataService featureDataService, 
            ISPRoleFeatureDataService roleFeatureDataService, 
            ISPRoleDataService roleDataService)
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
        public async Task<IEnumerable<ISPFeature>> GetAllFeatures()
        {
            return await featureDataService.GetAllFeatures();
        }

        /// <summary>
        /// Gets the feature by identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The feature entity.</returns>
        public async Task<ISPFeature> GetFeatureById(int featureId)
        {
            return await featureDataService.GetFeatureById(featureId);
        }

        /// <summary>
        /// Creates a new feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The creation status.</returns>
        public bool CreateFeature(ISPFeature feature)
        {
            return featureDataService.CreateFeature(feature);
        }

        /// <summary>
        /// Modifies the feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The modification status.</returns>
        public bool UpdateFeature(ISPFeature feature)
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
            List<ISPRolePermission> roleFeatureList = new List<ISPRolePermission>();
            roleFeatureList = roleFeatureDataService.GetRolesForFeatureId(featureId);
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
        /// Activates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The process status.</returns>
        public async Task<bool> ActivateFeature(int featureId)
        {
            return await featureDataService.ActivateFeature(featureId);
        }

        /// <summary>
        /// Deactivates the feature.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The process status.</returns>
        public async Task<bool> DeactivateFeature(int featureId)
        {
            return await featureDataService.DeactivateFeature(featureId);
        }

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The ISPFeature Entity</returns>
        public IEnumerable<ISPFeature> GetFeatures(ISPFeature filter)
        {
            return featureDataService.GetFeatures(filter);
        }

        /// <summary>
        /// Gets the hierarchy.
        /// </summary>
        /// <returns>The IHierarchy Entity.</returns>
        public async Task<IEnumerable<IHierarchy>> GetHierarchy()
        {
            return await featureDataService.GetHierarchy();
        }

        /// <summary>
        /// Gets the feature by hierarchy.
        /// </summary>
        /// <param name="hierarchyId">The hierarchy identifier.</param>
        /// <returns>The ISPFeature Entity</returns>
        public async Task<IEnumerable<ISPFeature>> GetFeatureByHierarchy(int hierarchyId)
        {
           var features = await featureDataService.GetAllFeatures();
           return features.Where(x => x.HierarchyId == hierarchyId).OrderBy(x => x.SortOrder);
        }
        #endregion
    }
}
