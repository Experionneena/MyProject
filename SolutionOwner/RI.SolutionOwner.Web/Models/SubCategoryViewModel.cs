using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.Web.Models
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public bool HasChild { get; set; }
        public int? ParentId { get; set; }
        public List<FeatureViewModel> FeatureList { get; set; }
    }
}