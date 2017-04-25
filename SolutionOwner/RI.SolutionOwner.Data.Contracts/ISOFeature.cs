//----------------------------------------------------------
// <copyright file="ISOFeature.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------
using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface for Solution Owner Feature Entity
    /// </summary>
    public interface ISOFeature : IEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        /// <value>
        /// The icon class.
        /// </value>
        string IconClass { get; set; }

        /// <summary>
        /// Gets or sets the program link.
        /// </summary>
        /// <value>
        /// The program link.
        /// </value>
        string ProgramLink { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        int SortOrder { get; set; }
    }
}
