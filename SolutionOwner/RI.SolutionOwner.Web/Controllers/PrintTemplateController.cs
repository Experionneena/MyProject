//-----------------------------------------------------------
// <copyright file="PrintTemplateController.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Framework.Core.Logging.Contracts;
    using RI.SolutionOwner.Mapper;
    using RI.SolutionOwner.Web.Models;
    using DTOs;
    /// <summary>
    /// This class implements the client side functionality of manage print template module
    /// </summary>
    public class PrintTemplateController : BaseController
    {
        #region Private members
        /// <summary>
        /// Declare templatemapper variable that maps print template entity to view model
        /// </summary>
        private ObjectMapper<SPPrintTemplateDto, PrintTemplateViewModel> templateMapper;

        /// <summary>
        /// logger service
        /// </summary>
        private ILoggerExtension logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintTemplateController"/> class.
        /// </summary>
        /// <param name="templateMapper">Maps print template entity to view model</param>
        /// <param name="logger">logger service</param>
        public PrintTemplateController(
            ObjectMapper<SPPrintTemplateDto, PrintTemplateViewModel> templateMapper,
            ILoggerExtension logger)
        {
            this.templateMapper = templateMapper;
            this.logger = logger;
        }
        #endregion

        #region Methods and actions
        /// <summary>
        /// Action that loads index view
        /// </summary>
        /// <returns>index view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action that load grid data in partial view
        /// </summary>
        /// <returns>partial view with model data</returns>
        public async Task<ActionResult> _Grid()
        {
           return PartialView("~/Views/PrintTemplate/_Grid.cshtml", await GetData());
        }

        /// <summary>
        /// Loads the data for partial view
        /// </summary>
        /// <returns>list of print template</returns>
        public async Task<List<PrintTemplateViewModel>> GetData()
        {
            List<PrintTemplateViewModel> listTemplates = null;
            try
            {
                HttpResponseMessage response = await Get("PrintTemplate/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsAsync<IEnumerable<SPPrintTemplateDto>>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK && responseContent != null)
                    {
                        listTemplates = this.templateMapper.ToObjects(responseContent).OrderByDescending(s => s.CreatedDate).ToList();
                    }
                    else
                    {
                        listTemplates = new List<PrintTemplateViewModel>();
                    }
                }
                else
                {
                    listTemplates = new List<PrintTemplateViewModel>();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

             return listTemplates;
        }

        /// <summary>
        /// Action that performs activate or deactivate operation
        /// </summary>
        /// <param name="printTemplatePostData">template id and status to be changed</param>
        /// <returns>status response and data for reloading grid</returns>
        public async Task<ActionResult> ActiveDeactivateTemplate(PrintTemplateViewModel printTemplatePostData)
        {
            string message = string.Empty;
            bool status = false;
            try
            {
                printTemplatePostData.IsActive = printTemplatePostData.Activate == 1 ? true : false;
                HttpResponseMessage response = await Put("PrintTemplate/Update", printTemplatePostData);
                if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    status = true;
                }

                message = response.ReasonPhrase;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return Json(new { Status = status, Msg = message, Data = RenderRazorViewToString("_Grid", await GetData()) });
        }

        /// <summary>
        /// Action that deletes the print template
        /// </summary>
        /// <param name="printTemplatePostData">template id</param>
        /// <returns>status response and data for reloading grid</returns>
        public async Task<ActionResult> DeleteTemplate(PrintTemplateViewModel printTemplatePostData)
        {
            bool status = false;
            string message = string.Empty;
            HttpResponseMessage response = null;
            try
            {
                response = await Delete("PrintTemplate/Delete/" + printTemplatePostData.Id);
                if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    status = true;
                }

                message = response.ReasonPhrase;
            }
            catch (Exception ex)
            {
                message = response.ReasonPhrase;
                logger.Error(ex.Message);
            }

            return Json(new { Status = status, Msg = message, Data = RenderRazorViewToString("_Grid", await GetData()) });
        }

        /// <summary>
        /// Action that loads the template details in a popup
        /// </summary>
        /// <param name="id">template id</param>
        /// <returns>print template view model</returns>
        [HttpGet]
        public async Task<ActionResult> LoadPopup(int? id = 0)
        {
            PrintTemplateViewModel model = new PrintTemplateViewModel();
            try
            {
                if (id > 0)
                {
                    HttpResponseMessage response = await Get("PrintTemplate/GetById/" + id);
                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responseContent = await response.Content.ReadAsAsync<SPPrintTemplateDto>();
                        model = this.templateMapper.ToObject(responseContent);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
           
            return PartialView("~/Views/PrintTemplate/_Add.cshtml", model);
        }

        /// <summary>
        /// Action that posts print template data for add/edit
        /// </summary>
        /// <param name="model">print template view model</param>
        /// <returns>status response</returns>
        [HttpPost]
        public async Task<ActionResult> Add(PrintTemplateViewModel model)
        {
            bool status = false;
            string message = string.Empty;
            HttpResponseMessage response = null;
            int id = 0;
            try
            {
                if (model.Id > 0)
                {
                    id = model.Id;
                    response = await Put("PrintTemplate/Update", this.templateMapper.ToEntity(model));
                    message = response.ReasonPhrase;
                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        status = true;
                    }
                }
                else
                {
                    response = await Post("PrintTemplate/Create", this.templateMapper.ToEntity(model));
                    message = response.ReasonPhrase;
                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return Json(new { status = status, msg = message, id = id }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}