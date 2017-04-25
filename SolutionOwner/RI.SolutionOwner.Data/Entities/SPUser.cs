using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Data.Entities
{
    public class SPUser : BaseEntity, ISPUser
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime LastLoginDate { get; set; }

        public bool IsActive { get; set; }

        public bool? IsBlocked { get; set; }        

        public virtual ICollection<SPUserRole> SPUserRoles { get; set; }

        public IList<int> RoleIdList { get; set; }

        public IList<string> RoleNameList { get; set; }
       

    }
}
