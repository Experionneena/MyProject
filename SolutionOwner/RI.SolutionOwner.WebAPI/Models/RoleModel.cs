using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.WebAPI.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }

        public bool ActiveStatus { get; set; }
    }
}