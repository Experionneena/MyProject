//-----------------------------------------------------------
// <copyright file="SPPrintTemplate.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.Framework.Core.Data.Entities;
    using RI.SolutionOwner.Data.Contracts;

    /// <summary>
    /// This class implements the property exposed in the interface ISPPrintTemplate
    /// </summary>
    public class SPPrintTemplate : BaseEntity, ISPPrintTemplate
    {
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
