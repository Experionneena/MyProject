//---------------------------------------------------------------
// <copyright file="HomeController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Web.Mvc;
using RI.Framework.Core.Logging.Contracts;

namespace RI.SolutionOwner.Web.Controllers
{
    /// <summary>
    /// The Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ILoggerExtension logger)
        {
            logger.Info("Log trace is working");           
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns> void </returns>
        public ActionResult Index()
        {
            ////var users = await accountService.GetAllUser();
            return View();
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>T</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}