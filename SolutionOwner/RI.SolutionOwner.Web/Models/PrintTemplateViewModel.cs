//-----------------------------------------------------------
// <copyright file="PrintTemplateViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// This class defines property for print template view model
    /// </summary>
    public class PrintTemplateViewModel
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the print text
        /// </summary>
        public string PrintText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this property is true or false
        /// </summary>
        public bool MerchantCopy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the activate status
        /// </summary>
        public int Activate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}