using RI.Framework.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Data.Contracts
{
    public interface ISPPUser : IEntity
    {
        string Name { get; set; }

        string Email { get; set; }

        string WorkPhone { get; set; }

        string Mobile { get; set; }

        int HierarchyId { get; set; }

        string Password { get; set; }

        int? ParentId { get; set; }

        DateTime? LastLoginDate { get; set; }

        bool IsActive { get; set; }

        bool? IsBlocked { get; set; }

        IList<int> RoleIdList { get; set; }

        IList<string> RoleNameList { get; set; }
    }
}
