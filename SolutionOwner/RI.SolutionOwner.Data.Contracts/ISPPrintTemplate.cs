//-----------------------------------------------------------
// <copyright file="ISPPrintTemplate.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.Framework.Core.Data.Entities;

    /// <summary>
    /// ISPPrintTemplate exposes print template entities to services
    /// </summary>
    public interface ISPPrintTemplate : IEntity
    {
        /// <summary>
        /// Gets or sets name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets print text
        /// </summary>
        string PrintText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether merchant copy is true or false
        /// </summary>
        bool MerchantCopy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active is true or false
        /// </summary>
        bool IsActive { get; set; }
    }
}
