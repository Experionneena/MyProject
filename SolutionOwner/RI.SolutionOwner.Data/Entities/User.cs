//---------------------------------------------------------
// <copyright file="User.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// The User entity.
    /// </summary>
    public class User : BaseEntity, IUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get;
            set;
        }

        ////public UserSettings Settings
        ////{
        ////    get;
        ////    set;
        ////}

        ////IUserSettings IUser.Settings
        ////{
        ////    get
        ////    {
        ////        return Settings;
        ////    }
        ////    set
        ////    {
        ////        Settings = value as UserSettings;
        ////    }
        ////}
    }
}
