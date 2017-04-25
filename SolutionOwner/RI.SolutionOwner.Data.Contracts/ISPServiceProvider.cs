//---------------------------------------------------------
// <copyright file="ISPServiceProvider.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// The Solution partner Service provider entity abstraction.
    /// </summary>
    public interface ISPServiceProvider : IEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [active status].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [active status]; otherwise, <c>false</c>.
        /// </value>
        bool ActiveStatus { get; set; }
    }
}
