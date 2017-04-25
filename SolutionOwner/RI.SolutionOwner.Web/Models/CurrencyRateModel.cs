// ---------------------------------------------------------
// <copyright file="CurrencyRateModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.Collections.Generic;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// Class Currency Rate Model
    /// </summary>
    public class CurrencyRateModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
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
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the base currency.
        /// </summary>
        /// <value>
        /// The base currency.
        /// </value>
        public string BaseCurrency { get; set; }

        /// <summary>
        /// Gets or sets the currency name list.
        /// </summary>
        /// <value>
        /// The currency name list.
        /// </value>
        public List<string> CurrencyNameList { get; set; }

        /// <summary>
        /// Gets or sets the symbol identifier.
        /// </summary>
        /// <value>
        /// The symbol identifier.
        /// </value>
        public Dictionary<string, int> SymbolId { get; set; }
    }
}