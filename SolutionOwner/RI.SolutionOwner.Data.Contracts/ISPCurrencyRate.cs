// ---------------------------------------------------------
// <copyright file="ISPCurrencyRate.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// Interface ISPCurrencyRate
    /// </summary> 
    ////[JsonConverter(typeof(ConcreteConverter<SPCurrencyRate>))]
    public interface ISPCurrencyRate : IEntity
    {
        /// <summary>
        /// Gets or sets the currency description.
        /// </summary>
        /// <value>
        /// The currency description.
        /// </value>
        string CurrencyDescription { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency list.
        /// </summary>
        /// <value>
        /// The currency list.
        /// </value>
        IList<string> CurrencyList { get; set; }
    }
}
