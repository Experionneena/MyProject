using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RI.SolutionOwner.WebAPI.Ingest.Models
{
    /// <summary>
    /// The Solution owner menu Dto.
    /// </summary>
    public class SOMenuModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the menu.
        /// </summary>
        /// <value>
        /// The name of the menu.
        /// </value>
        public string MenuName { get; set; }

        /// <summary>
        /// Gets or sets icon class of the menu.
        /// </summary>
        /// <value>
        /// The menu icon class.
        /// </value>
        public string MenuIcon { get; set; }

        /// <summary>
        /// Gets or sets the menu description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the feature.
        /// </summary>
        /// <value>
        /// The name of the feature.
        /// </value>
        public int FeatureId { get; set; }

        /// <summary>
        /// Gets or sets the name of the feature.
        /// </summary>
        /// <value>
        /// The name of the feature.
        /// </value>
        public string URLPath { get; set; }

        /// <summary>
        /// Gets or sets the active status.
        /// </summary>
        /// <value>
        /// The active status.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the parent menu identifier.
        /// </summary>
        /// <value>
        /// The parent menu identifier.
        /// </value>
        public int ParentMenuId { get; set; }

        /// <summary>
        /// Gets or sets the parent menu name.
        /// </summary>
        /// <value>
        /// The parent menu name.
        /// </value>
        public int ParentMenuName { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int? SortOrder { get; set; }
        
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Gets or sets the edited date.
        /// </summary>
        /// <value>
        /// The edited date.
        /// </value>
        public DateTime EditedDate { get; set; }

        /// <summary>
        /// Gets or sets the menu list.
        /// </summary>
        /// <value>
        /// The menu list.
        /// </value>
        public List<SelectListItem> MenuList { get; set; }
    }
}