// ---------------------------------------------------------
// <copyright file="SOUserDto.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;

namespace RI.SolutionOwner.Web.DTOs
{
    public class SOUserDto
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        /// <value>
        /// The last login date.
        /// </value>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the is blocked.
        /// </summary>
        /// <value>
        /// The is blocked.
        /// </value>
        public bool? IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets the role identifier list.
        /// </summary>
        /// <value>
        /// The role identifier list.
        /// </value>
        public IList<int> RoleIdList { get; set; }

        /// <summary>
        /// Gets or sets the role name list.
        /// </summary>
        /// <value>
        /// The role name list.
        /// </value>
        public IList<string> RoleNameList { get; set; }
    }
}