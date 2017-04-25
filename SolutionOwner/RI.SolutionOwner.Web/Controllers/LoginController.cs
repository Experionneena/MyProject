//---------------------------------------------------------------
// <copyright file="LoginController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Web.Mvc;

namespace RI.SolutionOwner.Web.Controllers
{
    /// <summary>
    /// The Login controller.
    /// </summary>
    public class LoginController : BaseController
    {
        //// GET: Login        
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}