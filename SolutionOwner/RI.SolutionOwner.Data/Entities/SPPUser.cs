using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Data.Entities
{
    public class SPPUser : BaseEntity, ISPPUser
    {
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
        /// Gets or sets the hierarchy.
        /// </summary>
        /// <value>
        /// The hierarchy.
        /// </value>
        public virtual Hierarchy Hierarchy { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public virtual SPPUser Parent { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public virtual ICollection<SPPUser> Children { get; set; }

        /// <summary>
        /// Gets or sets the SPP user roles.
        /// </summary>
        /// <value>
        /// The SPP user roles.
        /// </value>
        public virtual ICollection<SPPUserRole> SPPUserRoles { get; set; }

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

        /// <summary>
        /// Gets or sets the position user list.
        /// </summary>
        /// <value>
        /// The pos user list.
        /// </value>
        public virtual ICollection<POS> PosUserList { get; set; }

    }
}
