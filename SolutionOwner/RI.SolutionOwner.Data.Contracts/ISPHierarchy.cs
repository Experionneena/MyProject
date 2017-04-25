//----------------------------------------------------------------------
// <copyright file="ISPHierarchy.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------

using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface IPOSParameter
    /// </summary>
    public interface ISPHierarchy : IEntity
    {
        ///// <summary>
        ///// Gets or sets the solution partner identifier.
        ///// </summary>
        ///// <value>
        ///// The solution partner identifier.
        ///// </value>
        ////int SolutionPartnerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable distributor].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable distributor]; otherwise, <c>false</c>.
        /// </value>
        bool EnableDistributor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable sub distributor].
        /// </summary>
        /// <value>
        /// <c>true</c> if [enable sub distributor]; otherwise, <c>false</c>.
        /// </value>
        bool EnableSubDistributor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable wholesaler].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable wholesaler]; otherwise, <c>false</c>.
        /// </value>
        bool EnableWholesaler { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable modern trade].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable modern trade]; otherwise, <c>false</c>.
        /// </value>
        bool EnableModernTrade { get; set; }
    }
}
