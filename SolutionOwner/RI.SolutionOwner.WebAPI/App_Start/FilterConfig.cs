using System.Web;
using System.Web.Mvc;

namespace RI.SolutionOwner.WebAPI
{
    /// <summary>
    /// FilterConfig class.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
