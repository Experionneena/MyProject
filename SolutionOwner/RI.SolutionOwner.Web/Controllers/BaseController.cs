//-----------------------------------------------------------
// <copyright file="BaseController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ---------------------------------------------------------
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using RI.SolutionOwner.Web.App_Resources;

namespace RI.SolutionOwner.Web.Controllers
{
    /// <summary>
    /// This controller has action methods common for all controllers.
    /// </summary>
    public class BaseController : Controller
    {
        // GET: Base

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        public BaseController()
        {
        }

        /// <summary>
        /// Defaults the page.
        /// </summary>
        /// <returns>returns default view page.</returns>
        public ActionResult DefaultPage()
        {
            return View("DefaultPage");
        }

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <returns>returns instance of http client</returns>
        public static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            var baseAddress = ConfigurationManager.AppSettings["ServicePath"] ?? string.Empty;
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        /// <summary>
        /// Posts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="obj">The object.</param>
        /// <returns>returns response</returns>
        public async Task<HttpResponseMessage> Post(string resource, object obj)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync(client.BaseAddress + resource, obj);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>returns response.</returns>
        public async Task<HttpResponseMessage> Delete(string resource)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync(client.BaseAddress + resource);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Puts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="obj">The object.</param>
        /// <returns>returns response.</returns>
        public async Task<HttpResponseMessage> Put(string resource, object obj)
        {
            var client = GetHttpClient();
            var response = await client.PutAsJsonAsync(client.BaseAddress + resource, obj);
            return response;
        }      

        /// <summary>
        /// Gets the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>returns response.</returns>
        public async Task<HttpResponseMessage> Get(string resource)
        {
            var client = GetHttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.GetAsync(resource);
            response.EnsureSuccessStatusCode();
            return response;
        }

        /// <summary>
        /// Renders the razor view to string.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The model.</param>
        /// <returns>returns string.</returns>
        public string RenderRazorViewToString(string viewName, object model)
        {
            try
            {
                ViewData.Model = model;
                using (var sw = new StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the localised string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>returns string.</returns>
        public static string GetLocalisedString(string key)
        {
            return Resource1.ResourceManager.GetString(key);
        }
    }
}