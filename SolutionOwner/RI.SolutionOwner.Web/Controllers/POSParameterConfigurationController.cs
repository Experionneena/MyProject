using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RI.SolutionOwner.Web.Controllers
{
    public class POSParameterConfigurationController : BaseController
    {
        // GET: POSParameterConfiguration        
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Main View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Loads the add pop up.
        /// </summary>
        /// <returns>returns _AddPopUp partial view</returns>
        //public async Task<ActionResult> LoadAddPopUp()
        //{
        //    try
        //    {
        //        return Json(new { Status = 1, Data = RenderRazorViewToString("_AddPopUp",""/* ,Data to be bound*/), Message = " " });
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message);
        //        return Json(new { Status = 0, Data = "error", Message = ex.Message });
        //    }
        //}
    }
}