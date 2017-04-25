// ---------------------------------------------------------
// <copyright file="OwnerUserModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// This class defines properties for OwnerUserModel.
    /// </summary>
    public class SPPUserViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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
        /// Gets or sets the work phone.
        /// </summary>
        /// <value>
        /// The work phone.
        /// </value>
        public string WorkPhone { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy identifier.
        /// </summary>
        /// <value>
        /// The hierarchy identifier.
        /// </value>
        public int HierarchyId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy.
        /// </summary>
        /// <value>
        /// The hierarchy.
        /// </value>
        public virtual HierarchyViewModel Hierarchy { get; set; }

        /// <summary>
        /// Gets or sets the hierarchy list.
        /// </summary>
        /// <value>
        /// The hierarchy list.
        /// </value>
        public virtual ICollection<HierarchyViewModel> HierarchyList { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public virtual SPPUserViewModel Parent { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public virtual ICollection<SPPUserViewModel> Children { get; set; }

        /// <summary>
        /// Gets or sets the superiors list.
        /// </summary>
        /// <value>
        /// The superiors list.
        /// </value>
        public virtual ICollection<SPPUserViewModel> SuperiorsList { get; set; }

        /// <summary>
        /// Gets or sets the SPP user roles.
        /// </summary>
        /// <value>
        /// The SPP user roles.
        /// </value>
        public virtual ICollection<SPPUserRoleViewModel> SPPUserRoles { get; set; }

        /// <summary>
        /// Gets or sets the role list.
        /// </summary>
        /// <value>
        /// The role list.
        /// </value>
        public List<SPPRoleViewModel> RoleList { get; set; }

        /// <summary>
        /// Gets or sets the role name list.
        /// </summary>
        /// <value>
        /// The role name list.
        /// </value>
        public List<string> RoleNameList { get; set; }

        /// <summary>
        /// Gets or sets the role identifier list.
        /// </summary>
        /// <value>
        /// The role identifier list.
        /// </value>
        public List<int> RoleIdList { get; set; }

        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        /// <value>
        /// The last login date.
        /// </value>
        public string LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is blocked.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is blocked; otherwise, <c>false</c>.
        /// </value>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets the role names.
        /// </summary>
        /// <value>
        /// The role names.
        /// </value>
        public string RoleNames { get; set; }

        /// <summary>
        /// Gets or sets the role ids.
        /// </summary>
        /// <value>
        /// The role ids.
        /// </value>
        public string RoleIds { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public string CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the edited date.
        /// </summary>
        /// <value>
        /// The edited date.
        /// </value>
        public string EditedDate { get; set; }

        public virtual List<SPPUserViewModel> UserList { get; set; }
    }
}