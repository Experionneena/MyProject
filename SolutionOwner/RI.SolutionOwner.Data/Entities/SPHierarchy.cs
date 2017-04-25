//----------------------------------------------------------------------
// <copyright file="SPHierarchy.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// The Solution Partner Heirarchy entity.
    /// </summary>
    public class SPHierarchy : BaseEntity, ISPHierarchy
    {
        /// <summary>
        /// Gets or sets a value indicating whether [enable distributor].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable distributor]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableDistributor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable sub distributor].
        /// </summary>
        /// <value>
        /// <c>true</c> if [enable sub distributor]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableSubDistributor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable wholesaler].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable wholesaler]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableWholesaler { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable modern trade].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable modern trade]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableModernTrade { get; set; }

        /// <summary>
        /// Gets or sets the so solution partner.
        /// </summary>
        /// <value>
        /// The so solution partner.
        /// </value>
        ////[Required]
        public virtual SOSolutionPartner SOSolutionPartner { get; set; }
    }
}
