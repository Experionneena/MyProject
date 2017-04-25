//---------------------------------------------------------
// <copyright file="IUser.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Contracts
{
    /// <summary>
    /// The User entity abstarction.
    /// </summary>
    public interface IUser : IEntity
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }
    }
}
