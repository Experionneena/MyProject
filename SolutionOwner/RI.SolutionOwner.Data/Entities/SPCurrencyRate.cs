// ---------------------------------------------------------
// <copyright file="SPCurrencyRate.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// Class SPCurrencyRate
    /// </summary>
    public class SPCurrencyRate : BaseEntity, ISPCurrencyRate
    {
        /// <summary>
        /// Gets or sets the currency description.
        /// </summary>
        /// <value>
        /// The currency description.
        /// </value>
        public string CurrencyDescription { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency list.
        /// </summary>
        /// <value>
        /// The currency list.
        /// </value>
        public IList<string> CurrencyList { get; set; }

        /// <summary>
        /// Gets or sets the sp currency.
        /// </summary>
        /// <value>
        /// The sp currency.
        /// </value>
        public virtual SPCurrency SPCurrency { get; set; }
    }
}
