//-----------------------------------------------------------
// <copyright file="SPPrintTemplateDto.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;

namespace RI.SolutionOwner.Web.DTOs
{
    /// <summary>
    /// Class SPPrintTemplateDto
    /// </summary>
    public class SPPrintTemplateDto
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
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets print text
        /// </summary>
        public string PrintText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether merchant copy is true or false
        /// </summary>
        public bool MerchantCopy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active is true or false
        /// </summary>
        public bool IsActive { get; set; }
    }
}