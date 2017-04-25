// ---------------------------------------------------------
// <copyright file="SPCurrencyRateDto.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;

namespace RI.SolutionOwner.Web.DTOs
{
    /// <summary>
    /// Class SPCurrencyRateDto
    /// </summary>
    public class SPCurrencyRateDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
      public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the edited date.
        /// </summary>
        /// <value>
        /// The edited date.
        /// </value>
        public DateTime? EditedDate { get; set; }

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
        /// Gets or sets the currency list.
        /// </summary>
        /// <value>
        /// The currency list.
        /// </value>
        public IList<string> CurrencyList { get; set; }
    }
}