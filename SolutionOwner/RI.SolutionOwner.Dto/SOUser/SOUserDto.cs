using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Dto
{
    public class SOUserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<string> RoleNameList { get; set; }

        public List<int> RoleIdList { get; set; }

        public DateTime LastLoginDate { get; set; }

        public bool IsActive { get; set; }

        public bool? IsBlocked { get; set; }

        public string RoleNames { get; set; }

        public string RoleIds { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditedDate { get; set; }
    }
}
